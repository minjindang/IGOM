
Partial Class UControl_MAT_ucDDLMatMember
    Inherits System.Web.UI.UserControl
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private psn As New FSC.Logic.Personnel()

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
            BindMember()
        End Set
    End Property
    Public Property DepartId() As String
        Get
            Return hfDepartId.Value
        End Get
        Set(value As String)
            hfDepartId.Value = value
            BindMember()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            Return ddlMember.SelectedValue
        End Get
        Set(ByVal value As String)
            Try
                ddlMember.SelectedValue = value
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As ListItem
        Get
            Return ddlMember.SelectedItem
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        BindMember()
    End Sub

    Protected Sub BindMember()
        ddlMember.Items.Clear()
        If Not String.IsNullOrEmpty(Orgcode) AndAlso Not String.IsNullOrEmpty(DepartId) Then
            ddlMember.DataSource = psn.GetDataByOrgDep(Orgcode, DepartId)
            ddlMember.DataBind()
        End If
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        If Role_id.Contains("General") AndAlso Not Role_id.Contains("Master") _
            AndAlso Not Role_id.Contains("MAT_UnitWindow") AndAlso Not Role_id.Contains("DeptHead") _
            AndAlso Not Role_id.Contains("TackleAdmin") Then
            ddlMember.DataSource = psn.GetDataByOrgDep(LoginManager.OrgCode, LoginManager.Depart_id)
            ddlMember.DataBind()
            ddlMember.Enabled = False
            ddlMember.SelectedValue = LoginManager.UserId
        Else
            If Not ddlMember.Items.Contains(New ListItem("請選擇", "")) Then
                ddlMember.Items.Insert(0, New ListItem("請選擇", ""))
            End If
        End If
    End Sub


    Protected Sub ddlSubDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMember.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
End Class
