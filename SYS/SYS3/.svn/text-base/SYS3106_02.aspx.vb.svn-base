Imports System
Imports System.Data
Imports fscplm.Logic

Partial Class SYS3106_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load 'MyBase.Load, 
        If IsPostBack Then
            Return
        End If
        ShowDDL()
        Bind()
    End Sub

    Protected Sub ShowDDL()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim r As New SYS.Logic.Role()
        Dim dt As DataTable = r.GetData(orgcode)
        ddlBoss_Role.DataTextField = "Role_name"
        ddlBoss_Role.DataValueField = "Role_id"
        ddlBoss_Role.DataSource = dt
        ddlBoss_Role.DataBind()
        ddlBoss_Role.Items.Insert(0, New ListItem("--全部--", ""))
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        If String.IsNullOrEmpty(roleId) Then
            Return
        End If

        Dim list As System.Collections.Generic.List(Of SYS.Logic.Role) = r.GetObjects(orgcode, roleId)
        For Each role As SYS.Logic.Role In list
            txtRole_id.Text = role.RoleId
            txtRole_name.Text = role.RoleName
            ddlRole_status.SelectedValue = role.RoleStatus
            ddlBoss_Role.SelectedValue = role.BossRoleid
            ddlManager_flag.SelectedValue = role.ManagerFlag
        Next
    End Sub

#Region "新增角色"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        r.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        r.RoleId = txtRole_id.Text.Trim()
        r.RoleName = txtRole_name.Text.Trim()
        r.ManagerFlag = ddlManager_flag.SelectedValue
        r.RoleStatus = ddlRole_status.SelectedValue
        r.ManagerFlag = ddlManager_flag.SelectedValue
        r.BossRoleid = Me.ddlBoss_Role.SelectedValue
        r.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        r.ChangeDate = Now

        If String.IsNullOrEmpty(roleId) Then
            If r.InsertData() Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3106_01.aspx")
            End If
        Else
            If r.UpdateData() Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3106_01.aspx")
            End If
        End If

    End Sub
#End Region

    Protected Sub cbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBack.Click
        Response.Redirect("SYS3106_01.aspx")
    End Sub
End Class
