Imports System.Data
Imports System.IO
Imports System.Transactions
Imports CommonLib
Imports FSC.Logic

Partial Class FSC3109_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        bindLeaveData()
        Dep_Bind()
        Employee_type_Bind()
        Memo_Bind()

        UcLeaveDate.Start_date = DateTimeInfo.GetRocDate(Now)
        UcLeaveDate.End_date = DateTimeInfo.GetRocDate(Now)
    End Sub

#Region "下拉式選單"
    Protected Sub bindLeaveData()
        'ddlLeave_type.Items.Add(New ListItem("請選擇", ""))
        'ddlLeave_type.Items.Add(New ListItem("公傷假", "15"))
        'ddlLeave_type.Items.Add(New ListItem("延長病假", "16"))
        'ddlLeave_type.Items.Add(New ListItem("災防假", "18"))
        'ddlLeave_type.Items.Add(New ListItem("器官捐贈假", "23"))
        'ddlLeave_type.Items.Add(New ListItem("公假", "06"))
        'ddlLeave_type.Items.Add(New ListItem("事假", "01"))
        'ddlLeave_type.Items.Add(New ListItem("病假", "02"))
        'ddlLeave_type.Items.Add(New ListItem("休假", "03"))
        'ddlLeave_type.Items.Add(New ListItem("加班假", "04"))
        'ddlLeave_type.Items.Add(New ListItem("婚假", "08"))
        'ddlLeave_type.Items.Add(New ListItem("娩假", "09"))
        'ddlLeave_type.Items.Add(New ListItem("喪假", "10"))
        'ddlLeave_type.Items.Add(New ListItem("流產假", "13"))
        'ddlLeave_type.Items.Add(New ListItem("出差補休", "20"))
        'ddlLeave_type.Items.Add(New ListItem("值班補休", "32"))
        'ddlLeave_type.Items.Add(New ListItem("五一勞動節", "34"))
        'ddlLeave_type.Items.Add(New ListItem("家庭照顧假", "25"))
        'ddlLeave_type.Items.Add(New ListItem("產前假", "21"))
        'ddlLeave_type.Items.Add(New ListItem("陪產假", "22"))
        'ddlLeave_type.Items.Add(New ListItem("生理假", "24"))

        Dim lt As New SYS.Logic.LeaveType()
        ddlLeave_type.DataSource = lt.GetLeaveType(LoginManager.OrgCode, "Z")
        ddlLeave_type.DataBind()
        ddlLeave_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Employee_type_Bind()
        ddlEmployee_type.DataSource = New SYS.Logic.CODE().GetData("023", "022")
        ddlEmployee_type.DataBind()
        ddlEmployee_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Member_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DataTable
        Dim tmp As DataTable = New Member().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue())

        If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(ddlEmployee_type.SelectedValue) Then
                dt = tmp.Clone()
                Dim drs As DataRow() = tmp.Select(String.Format(" employee_type = '{0}'", ddlEmployee_type.SelectedValue))
                For Each dr As DataRow In drs
                    dt.ImportRow(dr)
                Next
            Else
                dt = tmp
            End If
        End If

        lbUnSelectMember.DataSource = dt
        lbUnSelectMember.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Member_Bind()
    End Sub

    Protected Sub ddlEmployee_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmployee_type.SelectedIndexChanged
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
        If String.IsNullOrEmpty(ddlLeave_type.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假別不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位不可空白，請重新輸入!")
            Return
        End If
        If lbMember.Items.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "表單申請人不可空白，請重新輸入!")
            Return
        End If
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

        Submit()
    End Sub

    Protected Sub Submit()
        '檢核訊息
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim userId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim name As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim posid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Try

            For Each item As ListItem In lbMember.Items
                Dim id_card As String = item.Value
                Dim title_no As String = New Personnel().GetDataByIdCard(id_card).Rows(0)("Title_no").ToString()
                Dim user_name As String = item.Text

                Dim hours As Integer = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, _
                                                                  UcLeaveDate.End_date, _
                                                                  UcLeaveDate.Start_time, _
                                                                  UcLeaveDate.End_time, _
                                                                  id_card)
                '開始 transaction
                Using trans As New TransactionScope()
                    Dim flowId As String = New SYS.Logic.FlowId().GetFlowId(orgcode, "001001", ddlLeave_type.SelectedValue)

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
                    f.WriterOrgcode = orgcode
                    f.WriterDepartid = departId
                    f.WriterIdcard = userId
                    f.WriterName = name
                    f.WriteTime = Now
                    f.FormId = "001001"

                    Dim fd As New SYS.Logic.FlowDetail()
                    fd.FlowId = flowId
                    fd.Orgcode = orgcode
                    fd.LastOrgcode = orgcode
                    fd.LastDepartid = departId
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
                    lmain.LeaveGroup = "A"
                    lmain.LeaveNgroup = "A4"
                    lmain.LeaveType = ddlLeave_type.SelectedValue
                    lmain.StartDate = UcLeaveDate.Start_date
                    lmain.EndDate = UcLeaveDate.End_date
                    lmain.StartTime = UcLeaveDate.Start_time
                    lmain.EndTime = UcLeaveDate.End_time
                    lmain.LeaveHours = hours
                    lmain.Reason = tbReason.Text.Trim()
                    lmain.Change_date = Now
                    lmain.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddSelfFlow(f, fd, lmain)

                    trans.Complete()
                End Using

            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "送出成功", "FSC3109_01.aspx")

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
