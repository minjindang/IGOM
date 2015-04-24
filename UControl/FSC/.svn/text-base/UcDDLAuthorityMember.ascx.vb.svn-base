Imports System.Data

Partial Class UControl_UcDDLAuthorityMember
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
            BindMember()
        End Set
    End Property

    Private _depart_id As String
    Public Property Depart_id() As String
        Get
            Return hfDepart_id.Value
        End Get
        Set(ByVal value As String)
            hfDepart_id.Value = value
            BindMember()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            If String.IsNullOrEmpty(ddlMember.SelectedValue) Then
                Return ddlMember.SelectedValue
            End If
            Return ddlMember.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlMember.SelectedValue = value
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
    End Sub

    Protected Sub BindMember()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim Boss_Level_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id)

        ddlMember.Items.Clear()
        If Not String.IsNullOrEmpty(Orgcode) AndAlso Not String.IsNullOrEmpty(Depart_id) Then
            Dim dv As DataView = New FSC.Logic.Personnel().GetDataByQuery(Orgcode, Depart_id, "", "").DefaultView
            dv.Sort = " User_name "
            Dim tmpdt As DataTable = dv.ToTable
            Dim dt As DataTable = tmpdt.Clone()
            If Role_id.IndexOf("Secretariat") >= 0 Then
                For Each dr As DataRow In tmpdt.Rows
                    If dr("Employee_type") = "3" OrElse dr("Employee_type") = "8" Then
                        dt.ImportRow(dr)
                    End If
                Next
                ddlMember.DataSource = dt
            Else
                ddlMember.DataSource = tmpdt
            End If
            ddlMember.DataBind()
        End If
        ddlMember.Items.Insert(0, New ListItem("請選擇", ""))

        If Role_id.IndexOf("Personnel") < 0 AndAlso Role_id.IndexOf("Secretariat") < 0 AndAlso _
            Role_id.IndexOf("OrgHead") < 0 AndAlso Role_id.IndexOf("DeptHead") < 0 AndAlso _
            Role_id.IndexOf("Master") < 0 AndAlso Boss_Level_id = "0" Then
            ddlMember.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            ddlMember.Enabled = False
        End If
    End Sub

End Class
