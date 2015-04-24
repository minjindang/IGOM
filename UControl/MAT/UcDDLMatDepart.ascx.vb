Imports System.Data
Imports EMP.Logic
Imports System.Collections.Generic

Partial Class UControl_UcDDLMatDepart
    Inherits System.Web.UI.UserControl
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private org As New FSC.Logic.Org()
    Private _orgcode As String
    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
            BindDepart()
            BindSubDepart()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            If String.IsNullOrEmpty(ddlSubDepart.SelectedValue) Then
                Return ddlDepart.SelectedValue
            End If
            Return ddlSubDepart.SelectedValue
        End Get
        Set(ByVal value As String)
            Try 
                Dim dr As DataRow = org.GetDataByDepartid(Orgcode, value)
                If String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Parent_depart_id")) Then
                    ddlDepart.SelectedValue = value
                Else
                    ddlDepart.SelectedValue = CommonFun.SetDataRow(dr, "Parent_depart_id")
                    BindSubDepart()
                    ddlSubDepart.SelectedValue = value
                End If

            Catch ex As Exception

            End Try
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As ListItem
        Get
            If String.IsNullOrEmpty(ddlSubDepart.SelectedValue) Then
                Return ddlDepart.SelectedItem
            End If
            Return ddlSubDepart.SelectedItem
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If


    End Sub

    Protected Sub BindDepart()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim Boss_Level_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable = New DataTable
        dt = org.GetDataByParentDepartid(Orgcode, "")
        ddlDepart.DataSource = dt
        ddlDepart.DataBind()
        ddlDepart.Items.Insert(0, New ListItem("請選擇", ""))

        If Role_id.Contains("MAT_UnitWindow") OrElse Role_id.Contains("Master") OrElse _
            Role_id.Contains("DeptHead") OrElse Role_id.Contains("General") AndAlso Not Role_id.Contains("TackleAdmin") Then
            'If Role_id.IndexOf("DeptHead") >= 0 OrElse Boss_Level_id = "2" Then
            '    ddlDepart.SelectedValue = Depart_id
            '    ddlDepart.Enabled = False
            'Else
            Dim dr As DataRow = org.GetDataByDepartid(Orgcode, Depart_id)
            ddlDepart.SelectedValue = CommonFun.SetDataRow(dr, "Parent_depart_id")
            ddlDepart.Enabled = False
            'End If
        End If
    End Sub

    Protected Sub BindSubDepart()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim Boss_Level_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        Dim dt As New DataTable
        If Not String.IsNullOrEmpty(ddlDepart.SelectedValue) Then
            dt = org.GetDataByParentDepartid(Orgcode, ddlDepart.SelectedValue)
        End If
        ddlSubDepart.DataSource = dt
        ddlSubDepart.DataBind()
        ddlSubDepart.Items.Insert(0, New ListItem("請選擇", ""))

        If Role_id.Contains("MAT_UnitWindow") OrElse Role_id.Contains("Master") OrElse _
            Role_id.Contains("General") AndAlso Not Role_id.Contains("DeptHead") AndAlso Not Role_id.Contains("TackleAdmin") Then
            ddlSubDepart.SelectedValue = Depart_id
            ddlSubDepart.Enabled = False
        End If
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart.SelectedIndexChanged
        BindSubDepart()
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub ddlSubDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubDepart.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
End Class
