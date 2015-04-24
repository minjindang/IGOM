Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports NLog

Partial Class FSC0102_01
    Inherits BaseWebForm

    Private Shared logger As Logger = LogManager.GetLogger("FSC0102")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        InitBind()
    End Sub


    Protected Sub InitBind()
        Dim code As New SACode()
        UcDDLForm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        cblStatus.DataSource = code.GetData2("023", "P", "002")
        cblStatus.DataBind()

        Try
            If Not String.IsNullOrEmpty(Request.QueryString("t")) AndAlso Request.QueryString("t").Equals("q") AndAlso Session("FSC0102_01_Q") IsNot Nothing Then
                Dim q() As String = Session("FSC0102_01_Q").ToString().Split("|")
                UcDateS.Text = q(0)
                UcDateE.Text = q(1)
                UcDDLForm.SelectedValue = q(2)
                Dim status As String = q(3)
                For Each s As String In status.Split(";")
                    For Each i As ListItem In cblStatus.Items
                        If i.Value = s Then
                            i.Selected = True
                        End If
                    Next
                Next
                Session("FSC0102_01_Q") = Nothing
                Bind()
            End If

            For Each i As ListItem In cblStatus.Items
                If i.Value = "001" Or i.Value = "003" Then
                    i.Selected = True
                End If
            Next
            Bind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Session("FSC0102_01_Q") = Nothing
        Response.Redirect("FSC0101_01.aspx")
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        Dim isCheckApprove As Boolean = False
        For Each i As ListItem In cblStatus.Items
            If i.Selected AndAlso i.Value = "002" Then isCheckApprove = True
        Next
        If isCheckApprove And (String.IsNullOrEmpty(UcDateS.Text) Or String.IsNullOrEmpty(UcDateE.Text)) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢已核準案件時，請輸入申請期間起迄!")
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()
        Dim dt As New DataTable

        Dim dates As String = UcDateS.Text
        Dim datee As String = UcDateE.Text
        Dim formId As String = UcDDLForm.SelectedValue
        Dim status As String = ""

        logger.Info(Now & " : start bind")
        For Each i As ListItem In cblStatus.Items
            If i.Selected Then
                Dim r As DataRow = code.GetRow("023", "002", i.Value)

                Dim caseStatus As String = r("code_remark1").ToString()
                Dim lastPass As String = r("code_remark2").ToString()

                Dim tmp As DataTable = bll.GetApplyData(orgcode, departId, idCard, dates, datee, formId, caseStatus, lastPass)

                If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                    dt.Merge(tmp)
                End If
            End If
        Next

        For Each i As ListItem In cblStatus.Items
            If i.Selected Then
                If Not String.IsNullOrEmpty(status) Then
                    status += ";"
                End If
                status += i.Value
            End If
        Next

        Session("FSC0102_01_Q") = String.Join("|", New String() {dates, datee, formId, status})

        ViewState("DataTable") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        Dim dt As DataTable = ViewState("DataTable")
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim caseStatus As String = CType(e.Row.FindControl("gvhfCaseStatus"), HiddenField).Value
            Dim lastPass As String = CType(e.Row.FindControl("gvhfLastPass"), HiddenField).Value
            Dim mergeFlag As String = CType(e.Row.FindControl("gvhfMergeFlag"), HiddenField).Value
            Dim formId As String = CType(e.Row.FindControl("gvhfFormId"), HiddenField).Value
            Dim flowId As String = CType(e.Row.FindControl("gvlbFlowId"), Label).Text
            Dim orgcode As String = CType(e.Row.FindControl("gvhfOrgcode"), HiddenField).Value
            Dim applyIdcard As String = CType(e.Row.FindControl("gvhfApply_id"), HiddenField).Value
            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(applyIdcard)
            Dim pekind As String = ""
            Dim employeeType As String = ""
            Dim LeaveType As String = ""
            If psn IsNot Nothing Then
                pekind = psn.Pekind
                employeeType = psn.EmployeeType
            End If
            Dim list As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(orgcode, flowId)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                LeaveType = list(0).LeaveType
            End If
            '假別規則
            Dim ls As FSC.Logic.LeaveSetting = New FSC.Logic.LeaveSetting().GetObject(orgcode, pekind, LeaveType, employeeType)

            '表單控制
            Dim fc As SYS.Logic.FormControl = New SYS.Logic.FormControl().getObject(formId)

            Dim status As String = ""
            'If mergeFlag = "" Then
            Select Case caseStatus
                Case "0", "1"
                    If lastPass = "1" Then
                        'If Not String.IsNullOrEmpty(formId) AndAlso formId.Substring(0, 3) = "001" Then
                        '    CType(e.Row.FindControl("UcCancelFlow"), UControl_UcCancelFlow).Visible = True
                        'End If

                        CType(e.Row.FindControl("UcCancelFlow"), UControl_UcCancelFlow).Visible = True
                        If fc IsNot Nothing AndAlso fc.isCancel.ToString <> "1" Then
                            CType(e.Row.FindControl("UcCancelFlow"), UControl_UcCancelFlow).Visible = False
                        End If
                        status = "已核准"
                    Else
                        CType(e.Row.FindControl("gvcbDelete"), Button).Visible = True
                        status = "簽核中"

                        If caseStatus = "1" Then
                            If fc IsNot Nothing AndAlso fc.isBossApprove.ToString = "1" Then
                                Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(orgcode, flowId)
                                Dim rows() As DataRow = fd.Select(" Deputy_flag <> '1' or Deputy_flag is null ")
                                For Each dr As DataRow In rows
                                    Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(dr("last_idcard"))
                                    If p.Boss_level_id <> "0" Then
                                        CType(e.Row.FindControl("gvcbDelete"), Button).Visible = False
                                        Exit For
                                    End If
                                Next
                            End If
                        End If

                        If fc IsNot Nothing AndAlso fc.isDelete.ToString <> "1" Then
                            CType(e.Row.FindControl("gvcbDelete"), Button).Visible = False
                        End If
                    End If

                    CType(e.Row.FindControl("gvUcAttachUploadButton"), UControl_SYS_UcAttachUploadButton).Visible = True
                    If ls IsNot Nothing AndAlso ls.Ifattach_flag = "1" Then
                        CType(e.Row.FindControl("gvUcAttachUploadButton"), UControl_SYS_UcAttachUploadButton).Visible = False
                    End If

                Case "2"
                    CType(e.Row.FindControl("gvcbUpdate"), Button).Visible = True
                    CType(e.Row.FindControl("gvcbResent"), Button).Visible = True
                    CType(e.Row.FindControl("gvcbDelete"), Button).Visible = True

                    If mergeFlag = "" Then
                        CType(e.Row.FindControl("gvUcAttachUploadButton"), UControl_SYS_UcAttachUploadButton).Visible = True

                        If ls IsNot Nothing AndAlso ls.Ifattach_flag = "1" Then
                            CType(e.Row.FindControl("gvUcAttachUploadButton"), UControl_SYS_UcAttachUploadButton).Visible = False
                        End If
                    End If

                    status = "已退回"
                Case "3"
                    status = "已撤回"
                Case "4"
                    status = "已刪除"
            End Select
            'End If

            CType(e.Row.FindControl("gvlbStatus"), Label).Text = status

            If status = "已退回" Then
                Dim gvlbStatus As Label = CType(e.Row.FindControl("gvlbStatus"), Label)
                gvlbStatus.ForeColor = Drawing.Color.Red
                Dim gvlbFlowId As Label = CType(e.Row.FindControl("gvlbFlowId"), Label)
                gvlbFlowId.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    '重送
    Protected Sub gvcbResent_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("gvhfOrgcode"), HiddenField).Value
        Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

        Using trans As New TransactionScope

            If formId = "002006" Then
                Dim bll As New SAL.Logic.SAL1104()
                Dim dt As DataTable = bll.getDataByOrgFid(orgcode, flowId)
                dt.Columns.Add("exists")
                For Each dr As DataRow In dt.Rows
                    dr("exists") = dr("e").ToString()
                Next
                bll.Apply(dt, flowId, True)

            ElseIf formId = "002002" Then
                '差旅費

                Dim flow As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
                Dim ofee As New SAL.Logic.SAL_OfficialoutFee()
                If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                    Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                    Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                    For Each f As SYS.Logic.Flow In list
                        ofee.UpdateStatusBySysFlowID(f.FlowId, "yet")
                    Next
                Else
                    ofee.UpdateStatusBySysFlowID(flowId, "yet")
                End If

            End If

            RunFlow(orgcode, flowId, "1", "1")

            trans.Complete()
        End Using

        Bind()
        CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "案件已重送完成")
    End Sub

    '修改
    Protected Sub gvcbUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("gvhfOrgcode"), HiddenField).Value
        Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value
        Dim mergeFlag As String = CType(gvr.FindControl("gvhfMergeFlag"), HiddenField).Value

        If mergeFlag = "1" Then
            Response.Redirect("FSC0102_02.aspx?org=" & orgcode & "&fid=" & flowId)
        Else
            Dim k As String = formId.Substring(0, 3)
            Dim t As String = formId.Substring(3)
            Dim code As New FSCPLM.Logic.SACode()
            Dim r As DataRow = code.GetRow("024", k, t)
            Dim url As String = ""

            If "002001" = formId Then
                Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
                Dim employeeType As String = New FSC.Logic.Personnel().GetColumnValue("employee_type", f.ApplyIdcard)

                If employeeType <> "1" _
                    And employeeType <> "6" _
                    And employeeType <> "7" _
                    And employeeType <> "9" _
                    And employeeType <> "11" _
                    And employeeType <> "13" Then '2,3,4,5,8,10,12,14,15

                    url = r("CODE_REMARK2").ToString().Split(",")(1)
                Else
                    url = r("CODE_REMARK2").ToString().Split(",")(0)
                End If

            Else
                url = r("CODE_REMARK2").ToString()
            End If

            If Not String.IsNullOrEmpty(url) Then
                Response.Redirect(url & "?org=" & orgcode & "&fid=" & flowId)
            End If
        End If
    End Sub

    '取消
    Protected Sub gvcbDelete_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("gvhfOrgcode"), HiddenField).Value
        Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

        If "004003" <= formId And "004087" >= formId Then
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
            Dim WSStatus As String = ""

            '財產報廢 
            If "004003" <= formId And "004041" >= formId Then
                Dim dao As New PRO_PropertyScrap_main
                WSStatus = dao.getMaxWsStatus(flowId, orgcode)
            End If

            '財產移轉
            If "004042" <= formId And "004087" >= formId Then
                Dim dao As New PRO_PropertyTran_main
                WSStatus = dao.getMaxWsStatus(flowId, orgcode)
            End If
            If "1" = WSStatus Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "資料已送至財產系統，無法進行取消，若要修改，請審核人員退回!")
                Return
            End If

        End If

        RunFlow(orgcode, flowId, "4", "")
        Bind()

    End Sub

    '撤銷
    Protected Sub gvcbCancel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, Button).NamingContainer, UControl_UcCancelFlow).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("gvhfOrgcode"), HiddenField).Value
        Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value
        Dim reason As String = CType(gvr.FindControl("UcCancelFlow"), UControl_UcCancelFlow).Text

        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()
        Dim chk As Boolean = False

        Dim origFlow As New SYS.Logic.Flow()
        origFlow = origFlow.GetObject(orgcode, flowId)

        Dim f As New SYS.Logic.Flow()
        f.Orgcode = LoginManager.OrgCode
        'f.FlowId = New SYS.Logic.FlowId().GetFlowId(orgcode, formId.Substring(0, 3) + "085")
        f.FlowId = New SYS.Logic.FlowId().GetFlowId(orgcode, "001007")
        f.FormId = "001007"
        f.CancelFlowid = flowId
        f.DepartId = LoginManager.Depart_id
        f.ApplyIdcard = LoginManager.UserId
        f.ApplyName = LoginManager.UserName
        f.ApplyPosid = LoginManager.TitleNo
        f.DeputyOrgcode = origFlow.DeputyOrgcode
        f.DeputyDepartid = origFlow.DeputyDepartid
        f.DeputyIdcard = origFlow.DeputyIdcard
        f.DeputyName = origFlow.DeputyName
        f.DeputyPosid = origFlow.DeputyPosid
        f.Reason = reason


        Dim fd As New SYS.Logic.FlowDetail()
        fd.Orgcode = orgcode
        fd.FlowId = flowId
        fd.LastOrgcode = lastOrgcode
        fd.LastDepartid = lastDepartId
        fd.LastPosid = lastPosid
        fd.LastIdcard = lastIdcard
        fd.LastName = lastName
        fd.AgreeFlag = 3    '撤銷
        fd.AgreeTime = Now
        fd.Comment = reason
        fd.ChangeDate = Now
        fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        Try
            Using trans As New TransactionScope
                SYS.Logic.CommonFlow.RunCancel(f, fd)
                trans.Complete()
                chk = True
            End Using

        Catch fex As FlowException
            err.Append("撤銷表單(" & flowId & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("撤銷表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
        End Try

        If Err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "撤銷表單送出成功!")
            Bind()
        End If

    End Sub


    Private Sub RunFlow(ByVal orgcode As String, ByVal flowId As String, ByVal agreeFlag As String, ByVal resendFlag As String)
        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()
        Dim chk As Boolean = False

        Dim fd As New SYS.Logic.FlowDetail()
        fd.Orgcode = orgcode
        fd.FlowId = flowId
        fd.LastOrgcode = lastOrgcode
        fd.LastDepartid = lastDepartId
        fd.LastPosid = lastPosid
        fd.LastIdcard = lastIdcard
        fd.LastName = lastName
        fd.AgreeFlag = agreeFlag
        fd.AgreeTime = Now
        fd.Comment = ""
        fd.ChangeDate = Now
        fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        fd.ResendFlag = resendFlag

        Try
            Using trans As New TransactionScope
                SYS.Logic.CommonFlow.RunFlow(fd)
                trans.Complete()
                chk = True
            End Using

        Catch fex As FlowException
            err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
        End Try

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        End If

    End Sub

    Protected Sub gvUcAttachUploadButton_FileUploaded(sender As Object, e As EventArgs)
        Bind()
    End Sub

    Protected Sub gv_RowDataBound1(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim gvlbwrite_time As Label = e.Row.FindControl("gvlbwrite_time")
            Dim dt As DateTime = Convert.ToDateTime(gvlbwrite_time.Text)
            gvlbwrite_time.Text = CommonFun.getYYYMMDD2(dt)
        End If

    End Sub

    Protected Sub gv_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim SortExpression As String = e.SortExpression
        Dim SortDirection As String = e.SortDirection.ToString.ToUpper()

        If ViewState("SortDirection") Is Nothing OrElse ViewState("SortDirection") Is Nothing Then
            initSort(SortExpression)
        Else
            If ViewState("SortExpression").ToString() = SortExpression Then
                If ViewState("SortDirection").ToString() = "ASCENDING" Then
                    ViewState("SortDirection") = "DESCENDING"
                    Bind(SortExpression + " DESC")
                Else
                    initSort(SortExpression)
                End If
            Else
                initSort(SortExpression)
            End If
        End If
    End Sub

    Protected Sub initSort(ByVal SortExpression As String)
        ViewState("SortDirection") = "ASCENDING"
        ViewState("SortExpression") = SortExpression
        Bind(SortExpression + " ASC")
    End Sub

    Protected Sub Bind(ByVal sort As String)
        Dim dv As DataView = CType(ViewState("DataTable"), DataTable).DefaultView
        dv.Sort = sort
        ViewState("DataTable") = dv.ToTable()
        gv.DataSource = CType(ViewState("DataTable"), DataTable)
        gv.DataBind()
    End Sub
End Class