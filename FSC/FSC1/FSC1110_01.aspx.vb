Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1110_01
    Inherits BaseWebForm

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack() Then Return
        showDDL()

        If Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            ShowReSendData()
        End If
    End Sub

    Public Sub showDDL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable
        Dim lt As New SYS.Logic.LeaveType
        Dim lg As New SYS.Logic.LeaveGroup

        dt = lg.GetCustomGroup(Orgcode)
        ddlleaveGroup.DataTextField = "Leave_group_name"
        ddlleaveGroup.DataValueField = "leave_group_id"
        ddlleaveGroup.DataSource = dt
        ddlleaveGroup.DataBind()

        dt = lt.GetLeaveType(Orgcode, ddlleaveGroup.SelectedValue)
        ddlLeaveType.DataTextField = "LeaveName"
        ddlLeaveType.DataValueField = "LeaveType"
        ddlLeaveType.DataSource = dt
        ddlLeaveType.DataBind()

        showColumn()
    End Sub

    Protected Sub ShowReSendData()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then
            Dim list As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            For Each lm As FSC.Logic.LeaveMain In list
                ddlleaveGroup.SelectedValue = lm.LeaveGroup
                ddlLeaveType.SelectedValue = lm.LeaveType
                UcLeaveDate.Start_date = lm.StartDate
                UcLeaveDate.End_date = lm.EndDate
                UcLeaveDate.Start_time = lm.StartTime
                UcLeaveDate.End_time = lm.EndTime
                UcLeaveDate.Apply_id = lm.UserName
                tbReason.Text = lm.Reason
            Next
        End If

        showColumn()
    End Sub

    Protected Sub ddlleaveGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlleaveGroup.SelectedIndexChanged
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lt As New SYS.Logic.LeaveType
        Dim dt As DataTable
        dt = lt.GetLeaveType(Orgcode, ddlleaveGroup.SelectedValue)
        ddlLeaveType.DataTextField = "LeaveName"
        ddlLeaveType.DataValueField = "LeaveType"
        ddlLeaveType.DataSource = dt
        ddlLeaveType.DataBind()
    End Sub

    Protected Sub ddlLeaveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLeaveType.SelectedIndexChanged
        showColumn()
    End Sub

    Public Sub showColumn()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim cls As New SYS.Logic.CustomLeaveSetting()
        Dim dt As DataTable
        Dim script As StringBuilder = New StringBuilder()
        dt = cls.GetData(Orgcode, ddlleaveGroup.SelectedValue, ddlLeaveType.SelectedValue)
        ViewState("dt") = dt

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                script.Append("<script type='text/javascript'>")
                script.Append("document.getElementById('trApply').style.display = '" + getDisplay(dr("isApply").ToString()) + "';")
                script.Append("document.getElementById('trApllyDate').style.display = '" + getDisplay(dr("isApllyDate").ToString()) + "';")
                script.Append("document.getElementById('trApllyDateSE').style.display = '" + getDisplay(dr("isApllyDateSE").ToString()) + "';")
                script.Append("document.getElementById('trReason').style.display = '" + getDisplay(dr("isReason").ToString()) + "';")
                script.Append("document.getElementById('trAttach').style.display = '" + getDisplay(dr("isAttach").ToString()) + "';")
                'script.Append("document.getElementById('trDetail').style.display = '" + getDisplay(dr("isDetail").ToString()) + "';")
                script.Append("document.getElementById('trCustom1').style.display = '" + getDisplay(dr("isCustom1").ToString()) + "';")
                script.Append("</script>")
                'lbDesc.Text = dr("Explanation").ToString()
                lbMemo.Text = dr("Mark").ToString()
            Next

            Dim P As System.Web.UI.Page = Me
            P.ClientScript.RegisterStartupScript(GetType(String), "", script.ToString())
        End If
    End Sub

    Protected Function getDisplay(ByVal result As String) As String
        If result = "Y" Then
            Return "table-row"
        Else
            Return "none"
        End If
    End Function

    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Rows(0)("isApply").ToString() = "Y" Then
                If String.IsNullOrEmpty(UcDate.Text) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期不可空白，請重新輸入!")
                    Return
                End If
            End If
            If dt.Rows(0)("isApllyDateSE").ToString() = "Y" Then
                If String.IsNullOrEmpty(UcLeaveDate.Start_date) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可空白，請重新輸入!")
                    Return
                End If
                If String.IsNullOrEmpty(UcLeaveDate.Start_time) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起時不可空白，請重新輸入!")
                    Return
                End If
                If String.IsNullOrEmpty(UcLeaveDate.End_date) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄日不可空白，請重新輸入!")
                    Return
                End If
                If String.IsNullOrEmpty(UcLeaveDate.End_time) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄時不可空白，請重新輸入!")
                    Return
                End If
                If UcLeaveDate.Start_date > UcLeaveDate.End_date Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                    Return
                ElseIf UcLeaveDate.Start_date = UcLeaveDate.End_date And UcLeaveDate.Start_time > UcLeaveDate.End_time Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                    Return
                End If
            End If
            If dt.Rows(0)("isReason").ToString() = "Y" Then
                If String.IsNullOrEmpty(tbReason.Text) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請事由不可空白，請重新輸入!")
                    Return
                End If
            End If
            'If dt.Rows(0)("isDetail").ToString() = "Y" Then
            '    If String.IsNullOrEmpty(tbDetail.Text) Then
            '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "摘要說明不可空白，請重新輸入!")
            '        Return
            '    End If
            'End If
            'If dt.Rows(0)("isAttach").ToString() = "Y" Then
            '    If String.IsNullOrEmpty(hdAttachID.Value) Then
            '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "必須要上傳附件!")
            '        Return
            '    End If
            'End If
        Else
            Return
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim issus As Boolean = False
        Dim errmsg As String = ""

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False
        Dim flow_id As String = ""

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        Try
            Dim cf As New SYS.Logic.CustomForm()
            cf.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            cf.Depart_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            cf.CFNAME = UcLeaveMember.Apply_name
            cf.CFCARD = UcLeaveMember.Apply_id
            cf.CFVTYPE = ddlLeaveType.SelectedValue
            cf.CFVDATEB = UcLeaveDate.Start_date
            cf.CFVDATEE = UcLeaveDate.End_date
            cf.CFVTIMEB = UcLeaveDate.Start_time
            cf.CFVTIMEE = UcLeaveDate.End_time
            cf.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Dim lm As New FSC.Logic.LeaveMain()
            lm.Orgcode = Orgcode
            lm.DepartId = New DepartEmp().GetDepartId(UcLeaveMember.Apply_id)
            lm.IdCard = UcLeaveMember.Apply_id
            lm.UserName = UcLeaveMember.Apply_name
            lm.LeaveGroup = "H"
            lm.LeaveType = ddlLeaveType.SelectedValue
            lm.Reason = tbReason.Text.Trim()
            lm.OccurDate = UcDate.Text
            lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            lm.Change_date = Date.Now
            Dim hours As Integer = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, UcLeaveDate.End_date, UcLeaveDate.Start_time, UcLeaveDate.End_time, UcLeaveMember.Apply_id)
            lm.StartDate = UcLeaveDate.Start_date
            lm.EndDate = UcLeaveDate.End_date
            lm.StartTime = UcLeaveDate.Start_time
            lm.EndTime = UcLeaveDate.End_time
            lm.LeaveHours = hours

            '開始 transaction
            Using trans As New TransactionScope()
                flow_id = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, "001014", Nothing))
                cf.CFGUID = flow_id
                lm.FlowId = flow_id

                UcAttachment.FlowId = flow_id
                UcAttachment.SaveFile()

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = tbReason.Text.Trim()
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.CaseStatus = "2"
                    f.Update()

                    cf.Update()
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = flow_id
                    f.Orgcode = Orgcode
                    f.DepartId = New DepartEmp().GetDepartId(UcLeaveMember.Apply_id)
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "001014"
                    f.Reason = tbReason.Text.Trim()
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    cf.Insert()
                    SYS.Logic.CommonFlow.AddFlow(f, lm)
                End If

                issus = True

                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(Orgcode, flow_id)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1110_01.aspx")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
