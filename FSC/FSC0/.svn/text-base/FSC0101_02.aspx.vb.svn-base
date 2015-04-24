Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0101_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLForm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        bindLeaveData()
        Bind()
        AuthorityButton()
    End Sub

    ''' <summary>
    ''' 按鈕控管
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AuthorityButton()
        Dim r As New SYS.Logic.Role()
        Dim b As String = r.GetRoleButton(LoginManager.OrgCode, LoginManager.RoleId)

        If b.IndexOf("MERGE") >= 0 Then
            cbMerge.Visible = True
        End If
        'If b.IndexOf("CUSTOM") >= 0 Then
        '    UcCustomNext.Visible = True
        'End If
        If b.IndexOf("REWORD") >= 0 Then
            UcReword.Visible = True
        End If
        If b.IndexOf("OVLIST") >= 0 Then
            cbPrintRPT.Visible = True
        End If
        If b.IndexOf("BUDGET") >= 0 Then
            UcBudget.Orgcode = LoginManager.OrgCode
            UcBudget.Visible = True
        End If

        'If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") < 0 Then
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
            cbQuery.Visible = False

            Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(LoginManager.UserId)
            If p IsNot Nothing AndAlso p.Boss_level_id <> "0" Then
                cbAgree.Text = "同意"
                cbNotAgree.Text = "不同意/退件"
            End If
        Else
            cbAgree.Text = "同意"
            cbNotAgree.Text = "不同意/退件"
        End If

    End Sub

    Protected Sub UcDDLForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLForm.SelectedIndexChanged
        If UcDDLForm.SelectedValue = "001001" Then
            ddlLeave_type.Visible = True
        Else
            ddlLeave_type.Visible = False
            ddlLeave_type.SelectedValue = ""
        End If
        ddlLeave_type_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub bindLeaveData()
        ddlLeave_type.DataSource = New SYS.Logic.LeaveType().GetLeaveType(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), "A")
        ddlLeave_type.DataBind()
        ddlLeave_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlLeave_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLeave_type.SelectedIndexChanged
        If ddlLeave_type.SelectedValue = "03" AndAlso UcDDLForm.SelectedValue = "001001" Then
            cbInterTravelFlag.Visible = True
        Else
            cbInterTravelFlag.Visible = False
            cbInterTravelFlag.Checked = False
        End If
    End Sub

    Protected Sub Bind()
        Dim level As String = Request.QueryString("level")
        Dim nextOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim nextDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim nextIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim bll As New FSC.Logic.FSC0101()

        Dim formId As String = UcDDLForm.SelectedValue
        Dim flowId As String = tbFlowId.Text.Trim()
        Dim dispatchDate As String = UcDate.Text
        Dim Leave_type As String = ddlLeave_type.SelectedValue
        Dim InterTravelFlag As String = IIf(cbInterTravelFlag.Checked, "1", "")
        Dim dt As New DataTable()
        Dim psn As New FSC.Logic.Personnel()

        If level IsNot Nothing Then

            Dim parentDepartId As String = ""
            Dim dr As DataRow = New FSC.Logic.Org().GetDataByDepartid(nextOrgcode, nextDepartId)
            If dr IsNot Nothing Then
                parentDepartId = dr("parent_depart_id").ToString()

                Dim pdt As DataTable = psn.GetDataByBossLevelId(nextOrgcode, parentDepartId, level)
                If pdt IsNot Nothing AndAlso pdt.Rows.Count > 0 Then
                    For Each pdr As DataRow In pdt.Rows
                        dt.Merge(bll.GetNextData(formId, flowId, dispatchDate, pdr("orgcode").ToString(), pdr("depart_id").ToString(), pdr("Id_card").ToString(), Leave_type, InterTravelFlag))
                    Next
                End If
            End If

        Else
            dt = bll.GetNextData(formId, flowId, dispatchDate, nextOrgcode, nextDepartId, nextIdcard, Leave_type, InterTravelFlag)
        End If

        Dim dv As DataView = dt.DefaultView
        dv.Sort = " Form_id ASC "
        dt = dv.ToTable()

        ViewState("DataTable") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC0101_01.aspx")
    End Sub

    Protected Sub cbAgree_Click(sender As Object, e As EventArgs)
        RunFlow(1)
    End Sub

    Protected Sub cbNotAgree_Click(sender As Object, e As EventArgs)
        RunFlow(2)
    End Sub

    Protected Sub RunFlow(agreeFlag As Integer)
        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()
        Dim chk As Boolean = False
        Dim fdList As New List(Of SYS.Logic.FlowDetail)

        For Each gvr As GridViewRow In gv.Rows
            If Not CType(gvr.FindControl("gvcbx"), CheckBox).Checked Then
                Continue For
            End If
            Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
            Dim comment As String = CType(gvr.FindControl("gvUcComment"), UControl_SYS_UcComment).Text
            Dim groupId As String = CType(gvr.FindControl("gvhfGroupId"), HiddenField).Value
            Dim nextStep As String = CType(gvr.FindControl("gvhfNextStep"), HiddenField).Value

            Try
                'checkReword(orgcode, flowId) '敘獎申請最後一關檢核

                If agreeFlag = "1" Then
                    checkApply(orgcode, flowId) '批核同意前最後檢核
                End If

                If agreeFlag = "2" AndAlso String.IsNullOrEmpty(comment) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "退件時批核意見不可空白")
                    Return
                End If

                If 2 = agreeFlag And "0" <> groupId Then
                    Throw New FlowException("不可退件!")
                End If

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
                fd.Comment = comment
                fd.ChangeDate = Now
                fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                fd.AgreeStep = nextStep
                fdList.Add(fd)


                Using trans As New TransactionScope
                    SYS.Logic.CommonFlow.RunFlow(fd)

                    trans.Complete()
                    chk = True
                End Using

            Catch fex As FlowException
                err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
                err.Append("批核表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
            End Try
        Next

        If chk Then
            For Each fd As SYS.Logic.FlowDetail In fdList
                SendNotice.sendAll(fd.Orgcode, fd.FlowId, fd.Comment)
            Next
        Else
            If err.Length <= 0 Then
                err.Append("至少需勾選一筆。\n")
            End If
        End If

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "批核成功!")
        End If

        Bind()
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        Bind()
    End Sub

    '成批造冊
    Protected Sub cbMerge_Click(sender As Object, e As EventArgs)
        Dim list As New List(Of Hashtable)
        Dim count As Integer = 0
        'Dim formKind As String = ""
        Dim tmpFormId As String = ""
        Dim tmpCode As String = ""
        Dim tmpEmpType As String = ""

        Dim r As New SYS.Logic.Role()
        Dim formStrList As String = r.GetFormButton(LoginManager.OrgCode, LoginManager.RoleId, "MERGE")

        For Each gvr As GridViewRow In gv.Rows
            If Not CType(gvr.FindControl("gvcbx"), CheckBox).Checked Then
                Continue For
            End If
            Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
            Dim formId As String = CType(gvr.FindControl("gvlbFormId"), Label).Text
            Dim budgetCode As String = CType(gvr.FindControl("gvhfBudgetCode"), HiddenField).Value
            Dim applyIdcard As String = CType(gvr.FindControl("gvhfApply_id"), HiddenField).Value

            If formStrList.IndexOf(formId) < 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "此表單不適用成批造冊!")
                Return
            End If

            'If Not String.IsNullOrEmpty(formKind) Then
            '    If formKind <> formId.Substring(0, 3) Then
            '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請種類需相同!")
            '        Return
            '    End If
            'End If
            'formKind = formId.Substring(0, 3)

            If Not String.IsNullOrEmpty(tmpFormId) Then
                If tmpFormId <> formId Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請項目需相同!")
                    Return
                End If
            End If
            tmpFormId = formId

            If formId = "002002" Then
                '差旅費
                Dim empType As String = New FSC.Logic.Personnel().GetColumnValue("Employee_type", applyIdcard)
                If Not String.IsNullOrEmpty(tmpEmpType) Then
                    If tmpEmpType <> empType And (empType = "3" Or empType = "14") Then     '3:技工工友, 14:替代役
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "技工工友駕駛不可與其他類別成批!")
                        Return
                    End If
                End If
                tmpEmpType = empType
            End If

            If Not String.IsNullOrEmpty(tmpCode) Then
                If tmpCode <> budgetCode Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請項目需同預算類別!")
                    Return
                End If
            End If
            tmpCode = budgetCode

            Dim ht As New Hashtable
            ht.Add("Orgcode", orgcode)
            ht.Add("Flow_id", flowId)
            list.Add(ht)
            count += 1
        Next

        If count < 2 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "至少需勾選兩筆!")
            Return
        End If

        Try
            Using trans As New TransactionScope
                SYS.Logic.CommonFlow.MergeFlow(list)
                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "成批/造冊完成!")
            Bind()
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

    Protected Sub UcCustomNext_Click(sender As Object, e As EventArgs)
        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()
        Dim chk As Boolean = False
        Dim fdList As New List(Of SYS.Logic.FlowDetail)

        For Each gvr As GridViewRow In gv.Rows
            If Not CType(gvr.FindControl("gvcbx"), CheckBox).Checked Then
                Continue For
            End If
            Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
            Dim comment As String = CType(gvr.FindControl("gvUcComment"), UControl_SYS_UcComment).Text
            Dim nextStep As String = CType(gvr.FindControl("gvhfNextStep"), HiddenField).Value

            Dim fd As New SYS.Logic.FlowDetail()
            fd.Orgcode = orgcode
            fd.FlowId = flowId
            fd.LastOrgcode = lastOrgcode
            fd.LastDepartid = lastDepartId
            fd.LastPosid = lastPosid
            fd.LastIdcard = lastIdcard
            fd.LastName = lastName
            fd.AgreeFlag = "1"
            fd.AgreeTime = Now
            fd.Comment = comment
            fd.ChangeDate = Now
            fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            fd.AgreeStep = nextStep
            fdList.Add(fd)

            Dim fn As New SYS.Logic.FlowNext()
            fn.Orgcode = orgcode
            fn.FlowId = flowId
            fn.NextOrgcode = UcCustomNext.NextOrgcode
            fn.NextDepartid = UcCustomNext.NextDepartid
            fn.NextPosid = UcCustomNext.NextPosid
            fn.NextIdcard = UcCustomNext.NextIdcard
            fn.NextName = UcCustomNext.NextName

            Try
                Using trans As New TransactionScope
                    SYS.Logic.CommonFlow.RunFlow(fd, fn)
                    trans.Complete()
                    chk = True
                End Using

            Catch fex As FlowException
                err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
            Catch ex As Exception
                err.Append("批核表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
            End Try
        Next

        If chk Then
            For Each fd As SYS.Logic.FlowDetail In fdList
                SendNotice.sendAll(fd.Orgcode, fd.FlowId)
            Next
        Else
            If err.Length <= 0 Then
                err.Append("至少需勾選一筆。\n")
            End If
        End If

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "批核成功!", "FSC0101_02.aspx")
        End If
    End Sub


    Protected Sub UcReword_Click(sender As Object, e As EventArgs)
        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()
        Dim chk As Boolean = False
        Dim fdList As New List(Of SYS.Logic.FlowDetail)

        For Each gvr As GridViewRow In gv.Rows
            If Not CType(gvr.FindControl("gvcbx"), CheckBox).Checked OrElse CType(gvr.FindControl("gvlbFormId"), Label).Text <> "001008" Then
                Continue For
            End If
            Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
            Dim comment As String = CType(gvr.FindControl("gvUcComment"), UControl_SYS_UcComment).Text
            Dim groupId As String = CType(gvr.FindControl("gvhfGroupId"), HiddenField).Value
            Dim nextStep As String = CType(gvr.FindControl("gvhfNextStep"), HiddenField).Value

            Dim dt As DataTable = New FSC.Logic.RewordMain().getDataByFid(flowId)
            Dim list As List(Of FSC.Logic.RewordMain) = CommonFun.ConvertToList(Of FSC.Logic.RewordMain)(dt)
            Dim rm As FSC.Logic.RewordMain = New FSC.Logic.RewordMain
            rm = list(0)
            rm.Council_name = UcReword.Council_name
            rm.Council_date = UcReword.Council_date
            rm.Council_approve = UcReword.Council_approve
            rm.Reword_date = UcReword.Reword_date
            rm.Reword_Doc = UcReword.Reword_Doc
            rm.flow_id = flowId

            Dim fd As New SYS.Logic.FlowDetail()
            fd.Orgcode = orgcode
            fd.FlowId = flowId
            fd.LastOrgcode = lastOrgcode
            fd.LastDepartid = lastDepartId
            fd.LastPosid = lastPosid
            fd.LastIdcard = lastIdcard
            fd.LastName = lastName
            fd.AgreeFlag = "1"
            fd.AgreeTime = Now
            fd.Comment = comment
            fd.ChangeDate = Now
            fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            fd.AgreeStep = nextStep
            fdList.Add(fd)

            Try
                Using trans As New TransactionScope
                    SYS.Logic.CommonFlow.RunFlow(fd)
                    rm.updateReword()
                    trans.Complete()
                    chk = True
                End Using
            Catch fex As FlowException
                err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
            Catch ex As Exception
                err.Append("批核表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
            End Try
        Next

        If chk Then
            For Each fd As SYS.Logic.FlowDetail In fdList
                SendNotice.sendAll(fd.Orgcode, fd.FlowId)
            Next
        Else
            If err.Length <= 0 Then
                err.Append("至少需勾選一筆敘獎申請。\n")
            End If
        End If

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "批核成功!")
            Bind()
        End If
    End Sub

    Protected Sub checkReword(ByVal orgcode As String, ByVal flow_id As String)
        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
        f = f.GetObject(orgcode, flow_id)
        Dim fopdt As DataTable = SYS.Logic.Outpost.GetFlowOutpost(f.Orgcode, f.DepartId, f.ApplyIdcard, f.FormId)
        If fopdt Is Nothing OrElse fopdt.Rows.Count <= 0 Then
            '沒有對應的關卡檔
            Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
        End If
        Dim lastRow As DataRow = fopdt.Rows(fopdt.Rows.Count - 1)
        Dim lastStep As Integer = CommonFun.getInt(lastRow("Outpost_seq").ToString())   '最後一關step
        Dim nextdt As DataTable = New SYS.Logic.FlowNext().getDataByFid(flow_id)

        Dim nowStep As Integer = 0

        If nextdt IsNot Nothing AndAlso nextdt.Rows.Count > 0 Then
            nowStep = nextdt.Rows(nextdt.Rows.Count - 1)("next_step")
        End If

        If lastStep <= nowStep AndAlso f.FormId = "001008" Then
            Throw New FlowException("敘獎申請最後一關請發佈獎懲令!")
        End If
    End Sub


    Protected Sub cbPrintRPT_Click(sender As Object, e As EventArgs)
        Dim chk As Boolean = False
        Dim err As StringBuilder = New StringBuilder
        Dim dt As DataTable = New DataTable
        Dim ddt As DataTable = New DataTable
        Dim tmpddt As DataTable = New DataTable
        Dim isOvertime As Boolean = False
        Dim isOffical As Boolean = False
        Dim tmpFormId As String = ""

        Using trans As New TransactionScope
            For Each gvr As GridViewRow In gv.Rows
                If Not CType(gvr.FindControl("gvcbx"), CheckBox).Checked OrElse _
                    (CType(gvr.FindControl("gvlbFormId"), Label).Text <> "002002" AndAlso _
                        CType(gvr.FindControl("gvlbFormId"), Label).Text <> "002001") Then
                    Continue For
                End If

                If Not String.IsNullOrEmpty(tmpFormId) AndAlso tmpFormId <> CType(gvr.FindControl("gvlbFormId"), Label).Text Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請勾選同一種類申請表單列印!")
                    Return
                End If

                chk = True
                Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
                Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text

                If CType(gvr.FindControl("gvlbFormId"), Label).Text = "002001" Then
                    isOvertime = True
                    Dim tmpdt As DataTable

                    Dim ofm As SAL.Logic.OvertimeFeeMaster = New SAL.Logic.OvertimeFeeMaster
                    tmpdt = ofm.GetData(orgcode, flowId)
                    If tmpdt IsNot Nothing AndAlso tmpdt.Rows.Count > 0 Then
                        dt = New DataTable
                        dt.Merge(tmpdt)
                    End If
                    ofm.updateSumPrint(orgcode, flowId, DateTimeInfo.GetRocDate(Now), "Y")


                    Dim labofm As SAL.Logic.LabOvertimeFeeMaster = New SAL.Logic.LabOvertimeFeeMaster
                    tmpdt = labofm.getDataByFlowid(orgcode, flowId)
                    If tmpdt IsNot Nothing AndAlso tmpdt.Rows.Count > 0 Then
                        tmpdt.Columns.Add("User_name")
                        tmpdt.Columns.Add("Title_name")
                        tmpdt.Columns.Add("Total_hour")
                        tmpdt.Columns.Add("Total_pay")
                        For Each dr As DataRow In tmpdt.Rows
                            dr("User_name") = New FSC.Logic.Personnel().GetColumnValue("User_name", dr("id_card").ToString())
                            dr("Title_name") = New SYS.Logic.CODE().GetFSCTitleName(New FSC.Logic.Personnel().GetColumnValue("title_no", dr("id_card").ToString()))
                            dr("Total_hour") = dr("hours")
                            dr("Total_pay") = dr("Overtime_fee")
                        Next

                        If tmpdt IsNot Nothing AndAlso tmpdt.Rows.Count > 0 Then
                            dt = New DataTable
                            dt.Merge(tmpdt)
                        End If
                    End If

                    Dim CPAPB02M As New FSC.Logic.CPAPB02M
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        ddt = CPAPB02M.GetDayByDate(dt.Rows(0)("Fee_YM").ToString + "01", dt.Rows(0)("Fee_YM").ToString + "31")
                        ddt.Columns.Add("Fee_YM")
                        ddt.Columns.Add("Depart_name")
                        ddt.Columns.Add("Title_name")
                        ddt.Columns.Add("User_name")
                        ddt.Columns.Add("Day")
                        ddt.Columns.Add("Reason")
                        ddt.Columns.Add("Normal_Hour")
                        ddt.Columns.Add("Project_Hour")
                        ddt.Columns.Add("PRTIME")
                        ddt.Columns.Add("Total_Hour") '總加班時數
                        ddt.Columns.Add("Pay_Hour") '請領時數
                        ddt.Columns.Add("BASE_HOUR_SAL") '時薪
                        ddt.Columns.Add("month_pay") '月薪
                        ddt.Columns.Add("main_pay") '本俸
                        ddt.Columns.Add("pro_pay") '專業加給
                        ddt.Columns.Add("boss_pay") '主管加給
                        ddt.Columns.Add("Normal_pay") '一般加給
                        ddt.Columns.Add("Total_pay")
                        ddt.Columns.Add("Flow_id")

                        Dim Total_Hour As Integer = 0
                        Dim Pay_hour As Integer = 0

                        For Each dr As DataRow In dt.Rows
                            Pay_hour += CommonFun.getInt(dr("Total_hour").ToString())
                        Next

                        Dim dt18 As DataTable = New FSC.Logic.CPAPR18M().getAllDataByYm(dt.Rows(0)("Id_card"), dt.Rows(0)("Fee_YM"))
                        If dt18 Is Nothing OrElse dt18.Rows.Count <= 0 Then
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "表單編號：" + flowId + "查無加班資料!")
                            Continue For
                        Else
                            For Each row18 As DataRow In dt18.Rows
                                Total_Hour += CommonFun.getInt(row18("PRADDH").ToString)
                            Next
                        End If

                        Dim sdt As DataTable = New SAL.Logic.SAL1111().getSALData(dt.Rows(0)("Orgcode"), dt.Rows(0)("Id_card"), (CommonFun.getInt(Left(dt.Rows(0)("Fee_YM"), 3)) + 1911).ToString & Right(dt.Rows(0)("Fee_YM"), 2))
                        If sdt Is Nothing OrElse sdt.Rows.Count <= 0 Then
                            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "表單編號：" + flowId + "查無薪水檔!")
                            'Continue For
                            Dim sdr As DataRow = sdt.NewRow
                            sdt.Rows.Add(sdr)
                        End If

                        For Each ddr As DataRow In ddt.Rows
                            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(dt.Rows(0)("Id_card"))
                            ddr("Fee_YM") = Left(dt.Rows(0)("Fee_YM"), 3) & "年" & Right(dt.Rows(0)("Fee_YM"), 2) & "月份"
                            ddr("Depart_name") = New FSC.Logic.Org().GetDepartNameWithoutSubDepart(dt.Rows(0)("Orgcode"), dt.Rows(0)("Depart_id"))
                            ddr("Title_name") = New SYS.Logic.CODE().GetFSCTitleName(psn.TitleNo)
                            ddr("User_name") = psn.UserName
                            ddr("Day") = CommonFun.getInt(Right(ddr("PBDDATE"), 2))
                            ddr("BASE_HOUR_SAL") = CommonFun.getInt(sdt.Rows(0)("BASE_HOUR_SAL").ToString)
                            ddr("month_pay") = CommonFun.getInt(sdt.Rows(0)("month_pay").ToString)
                            ddr("main_pay") = CommonFun.getInt(sdt.Rows(0)("main_pay").ToString)
                            ddr("pro_pay") = CommonFun.getInt(sdt.Rows(0)("pro_pay").ToString)
                            ddr("boss_pay") = CommonFun.getInt(sdt.Rows(0)("boss_pay").ToString)
                            ddr("Normal_pay") = 0
                            ddr("Total_Hour") = Total_Hour
                            ddr("Total_pay") = Pay_hour * CommonFun.getInt(sdt.Rows(0)("BASE_HOUR_SAL").ToString)
                            ddr("Pay_Hour") = Pay_hour
                            ddr("Flow_id") = flowId

                            Dim rows18 As DataRow() = dt18.Select(String.Format(" PRADDD = '{0}'", ddr("PBDDATE").ToString()))
                            For Each row18 As DataRow In rows18
                                ddr("Reason") = row18("PRREASON").ToString()
                                ddr("PRTIME") = ddr("PRTIME").ToString + IIf(String.IsNullOrEmpty(ddr("PRTIME").ToString), "", " ") + row18("PRSTIME").ToString() + "~" + row18("PRETIME").ToString()
                                If row18("PRATYPE").ToString = "1" Then
                                    ddr("Normal_Hour") = ddr("Normal_Hour").ToString + IIf(String.IsNullOrEmpty(ddr("Normal_Hour").ToString), "", "+") + row18("PRADDH").ToString
                                ElseIf row18("PRATYPE").ToString = "2" Then
                                    ddr("Project_Hour") = ddr("Project_Hour").ToString + IIf(String.IsNullOrEmpty(ddr("Project_Hour").ToString), "", "+") + row18("PRADDH").ToString
                                End If
                            Next
                        Next

                        tmpddt.Merge(ddt)
                    End If

                ElseIf CType(gvr.FindControl("gvlbFormId"), Label).Text = "002002" Then
                    isOffical = True
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
                    If Not String.IsNullOrEmpty(f.MergeFlowid) Then
                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(orgcode, f.MergeFlowid)
                        For Each dr As DataRow In fdt.Rows
                            dt.Merge(New FSC.Logic.FSC0101().getOfficialoutFee(dr("Orgcode").ToString, dr("Flow_id").ToString))
                        Next
                    Else
                        dt.Merge(New FSC.Logic.FSC0101().getOfficialoutFee(orgcode, flowId))
                    End If
                End If

                tmpFormId = CType(gvr.FindControl("gvlbFormId"), Label).Text
            Next
            trans.Complete()
        End Using

        If isOvertime Then
            Print_OvertimeFee(tmpddt)
        ElseIf isOffical Then
            Print_OfficalFee(dt)
        End If

        If Not chk Then
            err.Append("至少需勾選一筆申請。\n")
        End If

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        End If

    End Sub

    Protected Sub Print_OvertimeFee(ByVal dt As DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            'dt.Columns.Add("No")
            'Dim Total As Integer = 0
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    dt.Rows(i)("No") = i + 1
            '    Total += CommonFun.ConvertToInt(dt.Rows(i)("Total_pay").ToString())
            'Next

            Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC0101_02_RPT.mht"), dt)
            'Dim params(7) As String
            'params(0) = New FSC.Logic.Org().GetOrgcodeName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
            'params(1) = New FSC.Logic.Org().GetDepartName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
            'params(2) = ""
            'params(3) = ""
            'params(4) = "公務預算"
            'params(5) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            'params(6) = (Now.Year - 1911).ToString.PadLeft(3, "0") & "/" & Now.ToString("MM/dd HH:mm")
            'params(7) = Total

            Dim group() As String = {"Fee_YM", "Depart_name", "Title_name", "User_name", "Total_Hour", "BASE_HOUR_SAL", _
                                     "month_pay", "main_pay", "pro_pay", "boss_pay", "Normal_pay", "Total_pay", "Pay_Hour", "Flow_id"}

            rpt.ExportFileName = "加班費印領清冊"
            'rpt.Param = params
            rpt.PageGroupColumns = group
            rpt.PageGroupKeyColumns = group
            rpt.ExportToWord()
        End If
    End Sub

    Protected Sub Print_OfficalFee(ByVal dt As DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim Total As Integer = 0

            dt.Columns.Add("no")
            dt.Columns.Add("Memo")
            For i As Integer = 0 To dt.Rows.Count - 1
                Total += CommonFun.ConvertToInt(dt.Rows(i)("PPBEFOREM").ToString())
                dt.Rows(i)("no") = i + 1
                dt.Rows(i)("Memo") = FSC.Logic.DateTimeInfo.ConvertToDisplay(dt.Rows(i)("PPBUSDATEB").ToString()) + "~" + _
                    FSC.Logic.DateTimeInfo.ConvertToDisplay(dt.Rows(i)("PPBUSDATEE").ToString())
            Next

            Dim params(1) As String
            params(0) = New FSC.Logic.Org().GetDepartNameWithoutSubDepart(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
            params(1) = Total

            Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC0101_02_2_RPT.mht"), dt)

            rpt.ExportFileName = "印領總表"
            rpt.Param = params
            rpt.ExportToExcel()
        End If
    End Sub

    Protected Sub gv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        Bind()
    End Sub

    Protected Sub gv_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim gvlbwrite_time As Label = e.Row.FindControl("gvlbwrite_time")
            Dim dt As DateTime = CommonFun.getYYYMMDD(gvlbwrite_time.Text)
            gvlbwrite_time.Text = CommonFun.getYYYMMDD2(dt)
        End If
    End Sub

    Protected Sub checkApply(ByVal Orgcode As String, ByVal flow_id As String)
        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(Orgcode, flow_id)
        Dim t As String = String.Empty
        If f.FormId <> "" Then
            t = f.FormId.Substring(3)
        End If

        If t = "006" Then '刷卡補登
            Dim list As List(Of FSC.Logic.ForgotClockApply) = New FSC.Logic.ForgotClockApply().GetObjects(f.Orgcode, f.FlowId)
            For Each fca As FSC.Logic.ForgotClockApply In list
                Dim yymm As String = fca.Forgot_date.Substring(0, 5)
                Dim phyymm As New FSC.Logic.CPAPHYYMM(yymm)

                Dim chdt As DataTable = phyymm.GetData(fca.Apply_idcard, fca.Forgot_date, fca.Card_type)
                If chdt IsNot Nothing AndAlso chdt.Rows.Count > 0 Then
                    Throw New FlowException("已有該日期卡別刷卡資料!(" + New FSC.Logic.Org().GetDepartName(fca.Orgcode, fca.Depart_id) + _
                                            "、" + fca.Apply_idcard + "、" + fca.Apply_name + "、原刷卡時間：" + chdt.Rows(0)("PHITIME").ToString + ")")
                End If
            Next
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


    '設定預算來源
    Protected Sub UcBudget_Click(sender As Object, e As EventArgs)

        Dim r As New SYS.Logic.Role()
        Dim f As String = r.GetFormButton(LoginManager.OrgCode, LoginManager.RoleId, "BUDGET")
        Dim bll As New FSC.Logic.FSC0101()
        Dim budgetType As String = UcBudget.BudgetType


        For Each gvr As GridViewRow In gv.Rows
            Dim orgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
            Dim formId As String = CType(gvr.FindControl("gvlbFormId"), Label).Text
            Dim cbx As CheckBox = CType(gvr.FindControl("gvcbx"), CheckBox)
            If Not cbx.Checked Then
                Continue For
            End If

            If f.IndexOf(formId) < 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "此表單不適用設定預算來源!")
                Return
            End If

            bll.SetBudgetType(orgcode, flowId, formId, budgetType)

        Next

        Bind()
    End Sub
End Class