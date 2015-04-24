Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1_FSC1104_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkConfirm()
        If IsPostBack Then Return


        lbApply_name.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        UcForgot_date.Text = DateTimeInfo.GetRocDate(Now)
        Memo_Bind()
        Bind()
    End Sub

    Protected Sub Memo_Bind()
        lbMemo.Text = New ForgotClockApply().getDesc(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card), UcForgot_date.Text)
    End Sub

    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        If target = "Memo_Bind" Then
            Memo_Bind()
        End If
    End Sub

    Protected Sub Bind()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then

            Dim fca As ForgotClockApply = New ForgotClockApply
            Dim list As List(Of FSC.Logic.ForgotClockApply) = fca.GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            For Each f As FSC.Logic.ForgotClockApply In list
                lbApply_name.Text = f.Apply_name
                UcForgot_date.Text = f.Forgot_date
                UcForgot_date.Text_Enabled = False
                UcForgot_date.Time = f.Forgot_time
                rblCard_type.SelectedValue = f.Card_type
                tbReason.Text = f.Reason
            Next
        End If
    End Sub

    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        Me.lbErr.Text = ""

        If String.IsNullOrEmpty(Me.UcForgot_date.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "忘刷日期不可空白，請重新輸入!")
            Return
        ElseIf Me.UcForgot_date.Text > DateTimeInfo.GetRocTodayString("yyyyMMdd") Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "忘刷日期不可為未來日!")
            Return
        End If

        If String.IsNullOrEmpty(Me.UcForgot_date.Time) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "忘刷時間不可空白，請重新輸入!")
            Return
        ElseIf UcForgot_date.Text & UcForgot_date.Time > DateTimeInfo.GetRocTodayString("yyyyMMdd") & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "忘刷時間不可晚於現在時間!")
            Return
        End If

        If String.IsNullOrEmpty(Me.rblCard_type.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "卡別不可空白，請重新點選!")
            Return
        End If

        If String.IsNullOrEmpty(tbReason.Text) And tbReason.Text.Trim.Length <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "事由不可空白，請重新輸入!")
            Return
        ElseIf tbReason.Text.Trim.Length > 30 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "事由請勿輸入超過30字!")
            Return
        End If

        Dim errmsg As String = String.Empty
        Dim issus As Boolean = False
        Dim fid As String = String.Empty
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim User_name As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim Account As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Title_no As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim FormId As String = "001006"
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        If Not isUpdate Then
            Dim dt As DataTable = New ForgotClockApply().getData(Id_card, UcForgot_date.Text, rblCard_type.SelectedValue)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該筆日期卡別申請!")
                Return
            End If

            dt = New CPAPHYYMM(Left(UcForgot_date.Text, 5)).GetData(Id_card, UcForgot_date.Text, rblCard_type.SelectedValue)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該日期卡別刷卡資料!")
                Return
            End If

            Dim bll As New FSC4103_01DAO
            Dim ds As DataSet = bll.GetData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
            If ds IsNot Nothing Then
                If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("Times").ToString() <> "0" Then
                        Dim msg As String = String.Empty
                        Dim YearTimes As String = ds.Tables(0).Rows(0)("YearTimes").ToString()
                        Dim MonthTimes As String = ds.Tables(0).Rows(0)("MonthTimes").ToString()
                        Dim YearCount As Integer = CommonFun.getInt(New ForgotClockApply().dao.GetCountByYear(Id_card, Left(UcForgot_date.Text, 3)))
                        Dim MonthCOunt As Integer = CommonFun.getInt(New ForgotClockApply().dao.GetCountByMonth(Id_card, Mid(UcForgot_date.Text, 4, 2)))

                        If Not String.IsNullOrEmpty(YearTimes) AndAlso Not String.IsNullOrEmpty(MonthTimes) Then
                            If YearCount >= YearTimes OrElse MonthCOunt >= MonthTimes Then
                                msg = "您已超過刷卡補登申請上限"
                            End If
                        ElseIf Not String.IsNullOrEmpty(YearTimes) Then
                            If YearCount >= YearTimes Then
                                msg = "您已超過刷卡補登申請上限"
                            End If
                        ElseIf Not String.IsNullOrEmpty(MonthTimes) Then
                            If MonthCOunt >= MonthTimes Then
                                msg = "您已超過刷卡補登申請上限"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(msg) Then
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
                            Return
                        End If
                    End If
                End If
            End If
        End If

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, FormId))

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = tbReason.Text.Trim
                    f.ChangeUserid = Account
                    f.CaseStatus = "2"
                    f.Update()

                    Dim fcalist As List(Of ForgotClockApply) = New ForgotClockApply().GetObjects(u_org, u_fid)
                    For Each fca As ForgotClockApply In fcalist
                        fca.Forgot_date = UcForgot_date.Text
                        fca.Forgot_time = UcForgot_date.Time
                        fca.Card_type = rblCard_type.SelectedValue
                        fca.Case_status = "1"
                        fca.Reason = tbReason.Text.Trim()
                        fca.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                        fca.Change_date = Now
                        fca.UpdateForgotClockApply()
                    Next
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = Id_card
                    f.ApplyName = User_name
                    f.ApplyPosid = Title_no
                    f.ApplyStype = "1"
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = Id_card
                    f.WriterName = User_name
                    f.WriterPosid = Title_no
                    f.WriteTime = Date.Now
                    f.FormId = FormId
                    f.Reason = tbReason.Text.Trim
                    f.ChangeUserid = Account

                    SYS.Logic.CommonFlow.AddFlow(f)

                    Dim fca As New ForgotClockApply()
                    fca.Flow_id = fid
                    fca.Orgcode = Orgcode
                    fca.Depart_id = Depart_id
                    fca.Apply_idcard = Id_card
                    fca.Apply_name = User_name
                    fca.Forgot_date = UcForgot_date.Text
                    fca.Forgot_time = UcForgot_date.Time
                    fca.Card_type = rblCard_type.SelectedValue
                    fca.Case_status = "1"
                    fca.Reason = tbReason.Text.Trim()
                    fca.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    fca.Change_date = Now

                    'If "A" = rblCard_type.SelectedValue Then
                    '    fca.Reason = fca.Reason & "上班卡" & "#" & tbReason.Text.Trim()
                    'ElseIf "D" = rblCard_type.SelectedValue Then
                    '    fca.Reason = fca.Reason & "下班卡" & "#" & tbReason.Text.Trim()
                    'End If
                    'fca.Reason &= "#刷卡補登申請"

                    '檢核資料
                    errmsg = fca.CheckInserData()
                    If Not String.IsNullOrEmpty(errmsg) Then
                        Throw New FlowException(errmsg)
                    End If

                    fca.Change_userid = fca.Apply_idcard

                    If Not fca.InsertForgotClockApply() Then
                        Throw New FlowException("新增失敗!")
                    End If
                End If

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                issus = True
                trans.Complete()
            End Using


            '如果交易成功寄送email
            If issus Then
                SendNotice.send(Orgcode, fid)
                If isUpdate Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0101_01.aspx")
                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC0/FSC0101_01.aspx")
                End If
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

End Class
