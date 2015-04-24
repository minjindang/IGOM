Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1105_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        BindProjectKind()
        BindReSend()
        initControl()
    End Sub

#Region "下拉選單"
    Protected Sub initControl()
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") < 0 Then
            Dim tbTimeS As TextBox = CType(UcDateTimeS.FindControl("tbTime"), TextBox)
            Dim tbTimeE As TextBox = CType(UcDateTimeE.FindControl("tbTime"), TextBox)
            tbTimeS.Enabled = False
            tbTimeE.Enabled = False
        End If
    End Sub

    Protected Sub BindProjectKind()
        Dim code As New FSCPLM.Logic.SACode()
        rblProjectKind.DataSource = code.GetData("023", "029")
        rblProjectKind.DataBind()
        rblProjectKind.SelectedIndex = 0
    End Sub

    Protected Sub BindMember()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = UcDDLDepart.SelectedValue
        Dim dt As DataTable = New FSC.Logic.Personnel().GetDataWithoutMaintainVendors(orgcode, departId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dt.Columns.Add("cos")
            For Each dr As DataRow In dt.Rows
                dr("cos") = dr("Title_no").ToString() & "," & dr("Id_card").ToString()
                dr("full_name") = UcDDLDepart.SelectedItem.Text & "/" & dr("full_name").ToString()
            Next
        End If

        lbUnSelectMember.DataSource = dt
        lbUnSelectMember.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMember()
    End Sub

    Protected Sub cbToR_Click(sender As Object, e As EventArgs)
        'Dim tmpList As New System.Collections.Generic.List(Of ListItem)
        For Each op As ListItem In lbUnSelectMember.Items
            If op.Selected Then
                'op.Value = UcDDLDepart.SelectedValue & "," & op.Value
                'op.Text = UcDDLDepart.SelectedItem.Text & "/" & op.Text

                Dim ins As Boolean = True
                For Each item As ListItem In lbMember.Items
                    If item.Value = op.Value Then
                        ins = False
                    End If
                Next

                If ins Then
                    op.Value = UcDDLDepart.SelectedValue & "," & op.Value
                    lbMember.Items.Add(op)
                End If

                'tmpList.Add(op)
                op.Selected = False
            End If
        Next
        'For j As Integer = 0 To tmpList.Count - 1
        '    lbMember.Items.Remove(tmpList(j))
        'Next
    End Sub

    Protected Sub cbToL_Click(sender As Object, e As EventArgs)
        Dim tmpList As New System.Collections.Generic.List(Of ListItem)
        For Each op As ListItem In lbMember.Items
            If op.Selected Then
                tmpList.Add(op)
            End If
        Next
        For j As Integer = 0 To tmpList.Count - 1
            lbMember.Items.Remove(tmpList(j))
        Next
    End Sub

    Protected Sub rblProjectKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblProjectKind.SelectedIndexChanged
        For Each i As ListItem In rblCheckType.Items
            If rblProjectKind.SelectedValue = "B" OrElse rblProjectKind.SelectedValue = "D" Then
                If i.Value = "1" Then
                    i.Selected = False
                    i.Enabled = False
                Else
                    i.Selected = True
                End If
            Else
                i.Selected = False
                i.Enabled = True
            End If
        Next

        For Each i As ListItem In rblLocation.Items
            If rblProjectKind.SelectedValue = "B" OrElse rblProjectKind.SelectedValue = "C" Then
                If i.Value = "1" Then
                    i.Selected = False
                    i.Enabled = False
                Else
                    i.Selected = True
                End If
            ElseIf rblProjectKind.SelectedValue = "D" Then
                If i.Value = "2" Then
                    i.Selected = False
                    i.Enabled = False
                Else
                    i.Selected = True
                End If
            Else
                i.Selected = False
                i.Enabled = True
            End If
        Next
    End Sub

    Protected Sub rblisOnlyLeave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblisOnlyLeave.SelectedIndexChanged
        If rblisOnlyLeave.SelectedValue = "1" Then
            spLeaveHours.Visible = True
        Else
            spLeaveHours.Visible = False
            tbLeaveHours.Text = ""
        End If
    End Sub
#End Region

    Protected Sub BindReSend()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then

            Dim por As New FSC.Logic.ProjectOvertimeRule()
            Dim list As List(Of FSC.Logic.ProjectOvertimeRule) = por.GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            Dim fscorg As New FSC.Logic.Org()
            Dim code As New FSCPLM.Logic.SACode()
            Dim i As Integer = 1
            For Each p As FSC.Logic.ProjectOvertimeRule In list

                If i = list.Count Then
                    lbProjectCode.Text = p.ProjectCode
                    tbProjectName.Text = p.ProjectName
                    tbProjectDesc.Text = p.ProjectDesc
                    rblProjectKind.SelectedValue = p.ProjectKind
                    rblProjectKind_SelectedIndexChanged(Nothing, Nothing)
                    UcDateTimeS.Text = p.StartDate
                    UcDateTimeE.Text = p.EndDate
                    tbDailyOTHr.Text = p.DailyOTHr
                    tbDailyOTPayHr.Text = p.DailyOTPayHr
                    tbMonOTHr.Text = p.MonOTHr
                    tbMonOTPayHr.Text = p.MonOTPayHr
                    UcDateTimeS.Time = p.Start_time
                    UcDateTimeE.Time = p.End_time
                    rblCheckType.SelectedValue = p.CheckType
                    rblLocation.SelectedValue = p.Location
                    rblisCard.SelectedValue = p.isCard
                    rblisOnlyLeave.SelectedValue = p.isOnlyLeave
                    rblisOnlyLeave_SelectedIndexChanged(Nothing, Nothing)
                    tbLeaveHours.Text = p.LeaveHours.ToString()
                End If

                Dim item As New ListItem
                item.Value = p.DepartId & "," & p.TitleNo & "," & p.IdCard
                item.Text = fscorg.GetDepartName(org, p.DepartId) & "/" & code.GetCodeDesc("023", "012", p.TitleNo) & "/" & p.UserName
                lbMember.Items.Add(item)
                i += 1
            Next

            lbTip.Visible = False

        End If
    End Sub

#Region "檢核"
    Protected Function CheckField() As Boolean
        If String.IsNullOrEmpty(tbProjectName.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專案名稱必需輸入!")
            Return False
        End If
        If tbProjectDesc.Text.Trim.Length > 255 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專案說明不可大於250字")
            Return False
        End If
        If String.IsNullOrEmpty(UcDateTimeS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專案加班起日必需輸入!")
            Return False
        End If
        If String.IsNullOrEmpty(UcDateTimeE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專案加班迄日必需輸入!")
            Return False
        End If
        If UcDateTimeS.Text > UcDateTimeE.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專案加班起日不可大於專案加班迄日")
            Return False
        End If
        If lbMember.Items.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "至少選取一位員工!")
            Return False
        End If
        If Not CommonFun.IsNum(tbDailyOTHr.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "每日加班時數上限請輸入數字!")
            Return False
        End If
        If Not CommonFun.IsNum(tbDailyOTPayHr.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "每日加班費時數上限請輸入數字!")
            Return False
        End If
        If Not CommonFun.IsNum(tbMonOTHr.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "每月加班時數上限請輸入數字!")
            Return False
        End If
        If Not CommonFun.IsNum(tbMonOTPayHr.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "每月加班費時數上限請輸入數字!")
            Return False
        End If
        If String.IsNullOrEmpty(rblisCard.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇是否刷卡!")
            Return False
        End If
        If String.IsNullOrEmpty(rblisOnlyLeave.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇是否僅限補休!")
            Return False
        End If
        If rblisOnlyLeave.SelectedValue = "1" AndAlso String.IsNullOrEmpty(tbLeaveHours.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入補休時數!")
            Return False
        End If
        If Not String.IsNullOrEmpty(tbLeaveHours.Text) AndAlso Not CommonFun.IsNum(tbLeaveHours.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "補休時數請輸入數字!")
            Return False
        End If

        Return True
    End Function
#End Region

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        If Not CheckField() Then
            Return
        End If

        Dim fid As String = ""
        Dim formId As String = IIf(UcDateTimeS.Text >= FSC.Logic.DateTimeInfo.GetRocTodayString(Now.ToString("yyyyMMdd")), "001009", "001013")
        Dim projectCode As String = lbProjectCode.Text

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        Try
            Using trans As New TransactionScope

                If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
                    isUpdate = True
                End If

                If Not isUpdate Then
                    Dim code As New FSCPLM.Logic.SACode()
                    Dim y As String = (Now.Year - 1911).ToString().PadLeft(3, "0")
                    Dim r As DataRow = code.GetRow("023", "029", rblProjectKind.SelectedValue)
                    Dim c As String = IIf(String.IsNullOrEmpty(r("code_desc2").ToString()), "0000", r("code_desc2").ToString())
                    projectCode = y & rblProjectKind.SelectedValue & c

                    If Not code.updateCodeDesc2("023", "P", "029", rblProjectKind.SelectedValue, (CommonFun.getInt(c) + 1).ToString().PadLeft(4, "0")) Then
                        Throw New FlowException("更新失敗!")
                    End If
                Else
                    Dim por As New FSC.Logic.ProjectOvertimeRule()
                    por.Orgcode = Request.QueryString("org")
                    por.FlowId = Request.QueryString("fid")
                    por.DeleteData()
                End If

                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(orgcode, formId))
           
                For Each item As ListItem In lbMember.Items
                    Dim por As New FSC.Logic.ProjectOvertimeRule()
                    por.FlowId = fid
                    por.Orgcode = orgcode
                    por.ProjectCode = projectCode
                    por.ProjectName = tbProjectName.Text
                    por.ProjectKind = rblProjectKind.SelectedValue
                    por.ProjectDesc = tbProjectDesc.Text
                    por.StartDate = UcDateTimeS.Text
                    por.EndDate = UcDateTimeE.Text
                    por.DepartId = item.Value.Split(",")(0)
                    por.IdCard = item.Value.Split(",")(2)
                    por.UserName = item.Text.Split("/")(2)
                    por.TitleNo = item.Value.Split(",")(1)
                    por.MonOTHr = tbMonOTHr.Text
                    por.MonOTPayHr = tbMonOTPayHr.Text
                    por.DailyOTHr = tbDailyOTHr.Text
                    por.DailyOTPayHr = tbDailyOTPayHr.Text
                    por.Start_time = UcDateTimeS.Time
                    por.End_time = UcDateTimeE.Time
                    por.CheckType = rblCheckType.SelectedValue
                    por.Location = rblLocation.SelectedValue
                    por.isCard = rblisCard.SelectedValue
                    por.isOnlyLeave = rblisOnlyLeave.SelectedValue
                    If rblisOnlyLeave.SelectedValue = "1" Then
                        por.LeaveHours = tbLeaveHours.Text.Trim
                    End If


                    If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 AndAlso rblisOnlyLeave.SelectedValue = "1" Then
                        por.isShow = "0"
                    Else
                        por.isShow = "1"
                    End If

                    por.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) '

                    por.InsertData()
                Next

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.Reason = tbProjectDesc.Text.Trim
                    f.CaseStatus = "2"
                    f.Update()
                Else
                    Dim f As New SYS.Logic.Flow
                    f.FlowId = fid
                    f.Orgcode = orgcode
                    f.DepartId = departId
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.WriterOrgcode = orgcode
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Now
                    f.FormId = formId
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.Reason = tbProjectDesc.Text.Trim

                    SYS.Logic.CommonFlow.AddFlow(f)
                End If

                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(orgcode, fid)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0101_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC0/FSC0101_01.aspx")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
