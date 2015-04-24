Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Collections.Generic
Imports FSC.Logic

Partial Class FSC4102_03
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Dim leave_type As String = Request.QueryString("lt")
        lbLeave_name.Text = New SYS.Logic.LeaveType().GetLeaveName(leave_type)
        hfLeave_type.Value = leave_type

        Dep_Bind()
        Title_Bind()
        Name_Bind()
        ShowList()
    End Sub

#Region "顯示下拉選單"
    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Title_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlTitle_Name.DataSource = New SYS.Logic.CODE().GetData("023", "012")
        ddlTitle_Name.DataBind()
        ddlTitle_Name.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Name_Bind()
        ddlUser_name.Items.Clear()
        If Not String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            ddlUser_name.DataSource = New Personnel().GetDataByQuery(Orgcode, UcDDLDepart.SelectedValue, ddlTitle_Name.SelectedValue, "")
            ddlUser_name.DataBind()
        End If
        ddlUser_name.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub ddlTitle_Name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTitle_Name.SelectedIndexChanged
        Name_Bind()
    End Sub

#End Region


    Public Sub ShowList()
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Me.gvList.DataSource = New NoticePerson().getDataByLeaveType(strOrgcode, Request.QueryString("lt"))
        Me.gvList.DataBind()
    End Sub


    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim change_userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        If String.IsNullOrEmpty(ddlUser_name.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員!")
            Return
        End If

        Try
            Dim bll As New NoticePerson
            bll.Orgcode = strOrgcode
            bll.Depart_id = UcDDLDepart.SelectedValue
            bll.Leave_type = Request.QueryString("lt")
            bll.Id_card = ddlUser_name.SelectedValue
            bll.change_userid = change_userid

            bll.insert()

            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            ShowList()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC4102_02.aspx")
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim leave_type As String = hfLeave_type.Value
        Dim id_card As String = CType(gvr.FindControl("hfID_card"), HiddenField).Value
        Dim bll As New NoticePerson()

        Try
            bll.Orgcode = orgcode
            bll.Leave_type = leave_type
            bll.Id_card = id_card
            bll.delete()
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            ShowList()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
