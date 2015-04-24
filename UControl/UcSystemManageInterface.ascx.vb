Imports System.Data.SqlClient
Imports System.Data
Imports FSCPLM.Logic
Imports IGOM.Logic

Partial Class UControl_utl_SystemManageInterface
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        InitBind()
    End Sub

    Protected Sub InitBind()
        Dim account As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim psn As New FSC.Logic.Personnel()
        Dim dep As New FSC.Logic.DepartEmp()
        Dim r As New SYS.Logic.Role()

        Dim origOrgcode As String = ""
        Dim origDepartid As String = ""
        Dim origRoleId As String = psn.GetColumnValue("Role_id", account)
        Dim sysloginFlag As String = psn.GetColumnValue("Syslogin_flag", account)
        Dim isManager As Boolean = False

        Dim dt As DataTable = r.GetRole(LoginManager.OrgCode, origRoleId)
        For Each dr As DataRow In dt.Rows
            If dr("Manager_flag").ToString() = "Y" Then
                isManager = True
            End If
        Next
        hfIsManager.Value = isManager

        If isManager Then
            tb.Visible = True
            ddlOrgcode.Enabled = False

            BindOrg()
            BindDep()
            BindSubDep(True)
            BindUser()
        Else
            BindLoginOrgcode()
            BindLoginDepart()
            BindLoginSubDepart()
            BindLoginUser()

            tb.Visible = ddlOrgcode.Items.Count > 1 Or ddlDepart.Items.Count > 1 Or ddlSubDepart.Items.Count > 1
            'tb.Visible = False
        End If
    End Sub

#Region "下拉式選單"
    Protected Sub BindOrg()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlOrgcode.DataSource = New FSC.Logic.Org().GetOrgcode()
        ddlOrgcode.DataBind()
        ddlOrgcode.SelectedValue = orgcode
    End Sub

    Protected Sub BindDep()
        Dim orgcode As String = ddlOrgcode.SelectedValue
        Dim departid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        ddlDepart.DataSource = New FSC.Logic.Org().GetDataByParentDepartid(orgcode, "")
        ddlDepart.DataBind()

        Dim r As DataRow = New FSC.Logic.Org().GetDataByDepartid(orgcode, departid)
        If r IsNot Nothing AndAlso Not String.IsNullOrEmpty(r("parent_depart_id").ToString()) Then
            departid = r("parent_depart_id").ToString()
        End If

        Try
            ddlDepart.SelectedValue = departid
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub BindSubDep(Optional ByVal isInit As Boolean = False)
        Dim orgcode As String = ddlOrgcode.SelectedValue
        Dim departid As String = IIf(isInit, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), ddlDepart.SelectedValue)

        Dim dt As New DataTable()
        If Not String.IsNullOrEmpty(departid) Then
            Dim r As DataRow = New FSC.Logic.Org().GetDataByDepartid(orgcode, departid)
            If Not String.IsNullOrEmpty(r("parent_depart_id").ToString()) Then
                dt = New FSC.Logic.Org().GetDataByParentDepartid(orgcode, r("parent_depart_id").ToString())
            Else
                dt = New FSC.Logic.Org().GetDataByParentDepartid(orgcode, departid)
            End If
        End If
        ddlSubDepart.DataSource = dt
        ddlSubDepart.DataBind()
        ddlSubDepart.Items.Insert(0, New ListItem("請選擇", ""))

        Try
            ddlSubDepart.SelectedValue = departid
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BindUser()
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim orgcode As String = ddlOrgcode.SelectedValue
        Dim departId As String = ddlDepart.SelectedValue
        If Not String.IsNullOrEmpty(ddlSubDepart.SelectedValue) Then
            departId = ddlSubDepart.SelectedValue
        End If

        Dim psn As New FSC.Logic.Personnel()
        ddlUser.DataSource = psn.GetDataByOrgDep(orgcode, departId)
        ddlUser.DataBind()
        Try
            ddlUser.SelectedValue = idCard
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlDepart_name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart.SelectedIndexChanged
        If hfIsManager.Value = "True" Then
            BindSubDep()
            BindUser()
        Else
            BindLoginSubDepart()
            BindLoginUser()
        End If
    End Sub

    Protected Sub ddlSubDep_name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubDepart.SelectedIndexChanged
        If hfIsManager.Value = "True" Then
            BindUser()
        Else
            BindLoginUser()
        End If
    End Sub

#End Region


    Protected Sub lkbLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkbLogin.Click
        Dim account As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)  '登入者id_card
        Dim idCard As String = ddlUser.SelectedValue

        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(idCard)
        If psn IsNot Nothing Then
            Dim UserData As String = LoginInfo.GetUserData(ddlOrgcode.SelectedValue, ddlSubDepart.SelectedValue, psn, account)
            '設定驗證票
            If Not String.IsNullOrEmpty(UserData) Then
                LoginManager.SetAuthenTicket(UserData, idCard)
                Response.Redirect("~/FSC/FSC0/FSC0101_01.aspx")
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "登入失敗!")
            End If
        End If
    End Sub


    Protected Sub BindLoginOrgcode()
        Dim departEmp As New FSC.Logic.DepartEmp()
        Dim dt As DataTable = departEmp.GetDataByIdcard("", LoginManager.UserId, FSC.Logic.DateTimeInfo.GetRocDate(Now))
        Dim dtGroup As DataTable = dt.DefaultView.ToTable(True, "Orgcode", "Orgcode_name")
        ddlOrgcode.DataTextField = "Orgcode_name"
        ddlOrgcode.DataValueField = "Orgcode"
        ddlOrgcode.DataSource = dtGroup
        ddlOrgcode.DataBind()
        ddlOrgcode.SelectedValue = LoginManager.OrgCode

    End Sub

    Protected Sub BindLoginDepart()
        Dim orgcode As String = ddlOrgcode.SelectedValue
        Dim departid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        ddlDepart.DataSource = New FSC.Logic.DepartEmp().GetParentDepartByIdCard(ddlOrgcode.SelectedValue, LoginManager.UserId)
        ddlDepart.DataBind()

        Dim r As DataRow = New FSC.Logic.Org().GetDataByDepartid(orgcode, departid)
        If Not String.IsNullOrEmpty(r("parent_depart_id").ToString()) Then
            departid = r("parent_depart_id").ToString()
        End If

        Try
            ddlDepart.SelectedValue = departid
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BindLoginSubDepart()
        Dim departEmp As New FSC.Logic.DepartEmp()
        Dim dt As DataTable = departEmp.GetDepartByParentDepartId(ddlOrgcode.SelectedValue, ddlDepart.SelectedValue, LoginManager.UserId)
        ddlSubDepart.DataTextField = "Depart_name"
        ddlSubDepart.DataValueField = "Depart_id"
        ddlSubDepart.DataSource = dt
        ddlSubDepart.DataBind()
        Try
            ddlSubDepart.SelectedValue = LoginManager.Depart_id
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlOrgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrgcode.SelectedIndexChanged
        BindLoginDepart()
        BindLoginSubDepart()
        BindLoginUser()
    End Sub


    Protected Sub BindLoginUser()
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim psn As New FSC.Logic.Personnel()
        ddlUser.DataSource = psn.GetDataByIdCard(idCard)
        ddlUser.DataBind()
    End Sub
End Class
