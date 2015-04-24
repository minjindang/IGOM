Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib

Partial Class FSC3110_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        bindDDL()
        Memo_Bind()
    End Sub

#Region "下拉式選單"
    Protected Sub bindDDL()
        Dep_Bind()


        UcDate.Text = DateTimeInfo.GetRocDate(Now)
    End Sub

    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Member_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        lbUnSelectMember.DataSource = New Member().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue())
        lbUnSelectMember.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Member_Bind()
    End Sub

    Protected Sub Memo_Bind()
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
            Dim bll As New SYS.Logic.Func
            Dim dt As DataTable = bll.getDataByUrl(Split(aryPageName(aryPageName.Length - 1).Replace(".aspx", ""), "_")(0))
            For Each dr As DataRow In dt.Rows
                lbMemo.Text = dr("Func_Memo").ToString()
            Next
        End If
    End Sub
#End Region

    Protected Sub cbToR_Click(sender As Object, e As System.EventArgs) Handles cbToR.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In lbUnSelectMember.Items
            If item.Selected Then
                If lbMember.Items.Count <= 0 Then
                    list.Add(item)
                Else
                    Dim had As Boolean = False
                    For Each sitem As ListItem In lbMember.Items
                        If item.Value = sitem.Value Then
                            had = True
                        End If
                    Next
                    If Not had Then
                        list.Add(item)
                    End If
                End If
            End If
        Next
        For Each item As ListItem In list
            lbMember.Items.Add(item)
        Next
        lbUnSelectMember.SelectedIndex = -1
        lbMember.SelectedIndex = -1
    End Sub

    Protected Sub cbToL_Click(sender As Object, e As System.EventArgs) Handles cbToL.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In lbMember.Items
            If item.Selected Then
                list.Add(item)
            End If
        Next
        For Each item As ListItem In list
            lbMember.Items.Remove(item)
        Next
        lbUnSelectMember.SelectedIndex = -1
        lbMember.SelectedIndex = -1
    End Sub

    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        If lbMember.Items.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "表單申請人不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班日期不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(tbTimeb.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(tbTimee.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班迄時不可空白，請重新輸入!")
            Return
        End If
        If tbTimeb.Text > tbTimee.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可大於迄時，請重新輸入!")
            Return
        End If
        If rblmemo.SelectedIndex < 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請類型不可空白，請重新輸入!")
            Return
        End If

        Submit()
    End Sub

    Protected Sub Submit()
        '檢核訊息
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim userId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim name As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim posid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim case_type As String = rblType.SelectedValue

        Try

            For Each item As ListItem In lbMember.Items
                Dim id_card As String = item.Value
                Dim title_no As String = New Personnel().GetDataByIdCard(id_card).Rows(0)("Title_no").ToString()
                Dim user_name As String = item.Text

                Dim hours As Integer = FSC.Logic.Content.computeHourForOvertime(UcDate.Text & tbTimeb.Text.Trim(), _
                                                                        UcDate.Text & tbTimee.Text.Trim(), _
                                                                        id_card)

                If Not String.IsNullOrEmpty(Me.tbHours.Text) Then
                    hours = Convert.ToDouble(Me.tbHours.Text)
                End If
                If (tbReason.Text.Length > 30) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「事由」不可輸入超過30個字。")
                    Return
                End If
                '開始 transaction
                Using trans As New TransactionScope()
                    Dim flowId As String = New SYS.Logic.FlowId().GetFlowId(orgcode, "001005", "80")

                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow()
                    f.FlowId = flowId
                    f.Orgcode = orgcode
                    f.DepartId = UcDDLDepart.SelectedValue
                    f.ApplyPosid = title_no
                    f.ApplyIdcard = id_card
                    f.ApplyName = user_name
                    f.Reason = tbReason.Text.Trim()
                    f.CaseStatus = "1"
                    f.LastPass = "1"
                    f.LastDate = Now
                    f.WriterIdcard = userId
                    f.WriterName = name
                    f.WriteTime = Now
                    f.FormId = "001005"

                    'PLM.Flow_detail
                    Dim fd As New SYS.Logic.FlowDetail()
                    fd.FlowId = flowId
                    fd.Orgcode = orgcode
                    fd.LastOrgcode = orgcode
                    fd.LastDepartid = UcDDLDepart.SelectedValue
                    fd.LastPosid = posid
                    fd.LastIdcard = userId
                    fd.LastName = name
                    fd.AgreeFlag = "1"
                    fd.AgreeTime = Now
                    fd.Comment = ""
                    fd.LastDate = Now
                    fd.LastPass = "1"

                    Dim lmain As LeaveMain = New LeaveMain()
                    lmain.FlowId = flowId
                    lmain.Orgcode = orgcode
                    lmain.DepartId = UcDDLDepart.SelectedValue
                    lmain.IdCard = id_card
                    lmain.UserName = user_name
                    lmain.LeaveGroup = "E"
                    lmain.LeaveNgroup = "E" + case_type
                    lmain.LeaveType = "80"
                    lmain.StartDate = UcDate.Text
                    lmain.EndDate = UcDate.Text
                    lmain.StartTime = tbTimeb.Text.Trim()
                    lmain.EndTime = tbTimee.Text.Trim()
                    lmain.LeaveHours = hours
                    lmain.Reason = tbReason.Text.Trim()
                    lmain.OvertimeFlag = rblmemo.SelectedValue
                    lmain.Change_date = Now
                    lmain.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddSelfFlow(f, fd, lmain)

                    trans.Complete()
                End Using

            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "送出成功", "FSC3110_01.aspx")

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

End Class
