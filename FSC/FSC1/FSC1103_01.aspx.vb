Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1103_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        InitData()
        ShowReSendData()
    End Sub

    Protected Sub ShowReSendData()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then
            cbSubmit.Text = "確認"
            cbBack.Visible = True

            Dim list As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            For Each lm As FSC.Logic.LeaveMain In list
                rblType.SelectedValue = lm.LeaveType
                UcDate.Text = lm.StartDate
                tbTimeb.Text = lm.StartTime
                tbTimee.Text = lm.EndTime
                tbReason.Text = lm.Reason
                lbApplyName.Text = lm.UserName
            Next
            UcAttachment.BindUploadFile(org, fid)
        End If
    End Sub

    Protected Sub InitData()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim userName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)

        tbTimeb.Attributes.Add("onchange", "checkTime2(this.id)")
        tbTimee.Attributes.Add("onchange", "checkTime2(this.id)")
        rblType.Attributes.Add("onclick", "showProject()")

        lbApplyName.Text = userName
        UcDate.Text = DateTimeInfo.GetRocDate(Now)

        Dim por As New FSC.Logic.ProjectOvertimeRule()

        Dim dt As DataTable = por.GetDataByIdCard(orgcode, departId, idCard, "1", "1")
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ddlProject.DataSource = dt
            ddlProject.DataBind()
            BindProject_Detail()
        Else
            rblType.Items.Remove(rblType.Items(1))
        End If

        BindTime(idCard)
        'Memo_Bind()
    End Sub

    Protected Sub Memo_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim bll As New FSC.Logic.FSC1101()
        Dim dt As DataTable = bll.GetOvertimeData(Orgcode, Id_card)
        Dim hours As Integer = 0
        For Each dr As DataRow In dt.Rows
            hours += (CommonFun.getInt(dr("PRADDH")) - CommonFun.getInt(dr("PRPAYH")) - CommonFun.getInt(dr("PRMNYH")))
        Next

        lbMemo.Text = "您目前可補休的時數為" + CommonFun.getShowDayHours(FSC.Logic.Content.ConvertDayHours(hours))
    End Sub

    Protected Sub BindTime(ByVal Apply_id As String)
        Dim ht As Hashtable = FSC.Logic.Content.getWorkTime(Apply_id, UcDate.Text)
        If ht IsNot Nothing Then
            tbTimeb.Text = ht("WORKTIMEE").ToString()
            tbTimee.Text = DateTimeInfo.GetRocDateTime(DateTimeInfo.GetPublicDate(UcDate.Text & ht("WORKTIMEE").ToString()).AddHours(1)).Substring(7, 4)
        End If
    End Sub

    Protected Function CheckField() As Boolean
        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班日期不可空白，請重新輸入!")
            Return False
        End If
        If String.IsNullOrEmpty(tbTimeb.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可空白，請重新輸入!")
            Return False
        End If
        If String.IsNullOrEmpty(tbTimee.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班迄時不可空白，請重新輸入!")
            Return False
        End If
        If tbTimeb.Text > tbTimee.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可大於迄時，請重新輸入!")
            Return False
        End If
        If String.IsNullOrEmpty(tbReason.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班事由不可空白，請重新輸入!")
            Return False
        ElseIf tbReason.Text.Trim.Length > 30 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班事由請勿超過30字!")
            Return False
        End If
        If rblType.SelectedValue = "80" Then
            Dim today As String = DateTimeInfo.GetRocTodayString("yyyyMMdd")
            If UcDate.Text < today Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班需事前申請!")
                Return False
            End If
        End If

        Dim psn As New FSC.Logic.Personnel()
        Dim degreeCode As String = psn.GetColumnValue("degree_code", LoginManager.UserId)
        If degreeCode.Substring(0, 1) = "P" Then
            If degreeCode.Substring(1) >= 10 And tbReason.Text.IndexOf("颱風假加班") < 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "簡任級主管不能申請加班!")
                Return False
            End If
        End If


        Return True
    End Function

    Protected Function checkProjectHours(ByVal hours As Integer) As Boolean
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim applyIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        If hfisOnlyLeave.Value = "1" Then
            Dim lm As New FSC.Logic.LeaveMain
            Dim dt As DataTable = lm.getDataByProjectCode(Orgcode, applyIdcard, ddlProject.SelectedValue)
            For Each dr As DataRow In dt.Rows
                hours += CommonFun.getInt(("Leave_hours").ToString())
            Next

            If hours > CommonFun.getInt(hfLeaveHours.Value) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已超過" + ddlProject.SelectedItem.Text + "可申請的補休上限" + hfLeaveHours.Value + "小時")
                Return False
            End If
        End If

        Return True
    End Function

    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim applyIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim applyName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)

        If Not CheckField() Then
            Return
        End If

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        Dim reason As String = tbReason.Text.Trim()
        Dim fid As String = String.Empty
        Dim hours As Integer = 0
        Dim fList As New List(Of SYS.Logic.Flow)

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, "001005", rblType.SelectedValue))

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.CaseStatus = "2"
                    f.Update()

                    Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(u_org, u_fid)
                    For Each lm As FSC.Logic.LeaveMain In lmList
                        lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                        lm.Change_date = Date.Now
                        hours = FSC.Logic.Content.computeHourForOvertime(UcDate.Text & tbTimeb.Text, UcDate.Text & tbTimee.Text, lm.IdCard)
                        lm.StartDate = UcDate.Text
                        lm.EndDate = UcDate.Text
                        lm.StartTime = tbTimeb.Text
                        lm.EndTime = tbTimee.Text
                        lm.LeaveHours = hours
                        lm.Reason = reason
                        If rblType.SelectedValue <> "80" Then
                            lm.Project_code = ddlProject.SelectedValue
                            lm.isCard = hfisCard.Value
                            lm.isOnlyLeave = hfisOnlyLeave.Value
                            lm.CheckType = hfCheckType.Value

                            If hfisOnlyLeave.Value = "1" And Not checkProjectHours(hours) Then
                                Return
                            End If
                        End If
                        lm.UpdateLeaveMain()
                    Next
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = applyIdcard
                    f.ApplyName = applyName
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "001005"
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    Dim lm As New FSC.Logic.LeaveMain()
                    lm.FlowId = fid
                    lm.Orgcode = Orgcode
                    lm.DepartId = Depart_id
                    lm.IdCard = applyIdcard
                    lm.UserName = applyName
                    lm.LeaveGroup = "E"
                    lm.LeaveNgroup = "E1"
                    lm.LeaveType = rblType.SelectedValue
                    lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    lm.Change_date = Date.Now
                    hours = FSC.Logic.Content.computeHourForOvertime(UcDate.Text & tbTimeb.Text, UcDate.Text & tbTimee.Text, applyIdcard)
                    lm.StartDate = UcDate.Text
                    lm.EndDate = UcDate.Text
                    lm.StartTime = tbTimeb.Text
                    lm.EndTime = tbTimee.Text
                    lm.LeaveHours = hours
                    lm.Reason = reason
                    If rblType.SelectedValue <> "80" Then
                        lm.Project_code = ddlProject.SelectedValue
                        lm.isCard = hfisCard.Value
                        lm.isOnlyLeave = hfisOnlyLeave.Value
                        lm.CheckType = hfCheckType.Value

                        If hfisOnlyLeave.Value = "1" And Not checkProjectHours(hours) Then
                            Return
                        End If
                    End If

                    SYS.Logic.CommonFlow.AddFlow(f, lm)
                End If

                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(Orgcode, fid)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1103_01.aspx")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        BindProject_Detail()
    End Sub

    Protected Sub BindProject_Detail()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim por As New FSC.Logic.ProjectOvertimeRule()
        Dim dt As DataTable = por.getDataByCode(orgcode, departId, idCard, ddlProject.SelectedValue)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            lbPProjectDesc.Text = dt.Rows(0)("Project_desc").ToString()
            lbProjectKind.Text = dt.Rows(0)("Project_kind_name").ToString()
            UcShowDateS.Text = dt.Rows(0)("Start_date").ToString()
            UcShowDateE.Text = dt.Rows(0)("End_date").ToString()
            hfisCard.Value = dt.Rows(0)("isCard").ToString()
            hfisOnlyLeave.Value = dt.Rows(0)("isOnlyLeave").ToString()
            hfLeaveHours.Value = dt.Rows(0)("LeaveHours").ToString()
            hfCheckType.Value = dt.Rows(0)("CheckType").ToString()
        End If
    End Sub
End Class
