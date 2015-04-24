Imports FSC.Logic
Imports System.Data

Partial Class UControl_UcLeaveMember
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Enabled() As Boolean
        Get
            Return ddlMemberName.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlMemberName.Enabled = value
        End Set
    End Property

    Public Property Apply_name() As String
        Get
            Return hfApply_name.Value.Trim()
        End Get
        Set(ByVal value As String)
            hfApply_name.Value = value
        End Set
    End Property

    Public Property Apply_id() As String
        Get
            Return hfApply_id.Value
        End Get
        Set(ByVal value As String)
            hfApply_id.Value = value
            ddlMemberName.SelectedIndex = ddlMemberName.Items.IndexOf(ddlMemberName.Items.FindByValue(value))
        End Set
    End Property

    Public Property Apply_posid() As String
        Get
            Return hfApply_posid.Value
        End Get
        Set(ByVal value As String)
            hfApply_posid.Value = value
        End Set
    End Property

    Public Property Apply_stype() As String
        Get
            Return hfApply_stype.Value
        End Get
        Set(ByVal value As String)
            hfApply_stype.Value = value
        End Set
    End Property

    Public Property Depart_id() As String
        Get
            Return hfDepart_id.Value
        End Get
        Set(ByVal value As String)
            hfDepart_id.Value = value
            Bind_Member()
        End Set
    End Property
#End Region

    Public Event Apply_name_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        hfApply_name.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        hfApply_id.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        hfApply_posid.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)

        Bind_Member()

        'RaiseEvent Apply_name_ValueChanged(ddlMemberName, e)
    End Sub

    Protected Sub Bind_Member()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        If String.IsNullOrEmpty(hfDepart_id.Value) Then
            hfDepart_id.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        End If
        Dim m As New Personnel()

        ddlMemberName.DataTextField = "FULL_Name"
        ddlMemberName.DataValueField = "Id_card"
        ddlMemberName.DataSource = m.GetDataByOrgDep(Orgcode, hfDepart_id.Value)
        ddlMemberName.DataBind()

        If ddlMemberName.Items.IndexOf(ddlMemberName.Items.FindByValue(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))) > 0 Then
            ddlMemberName.SelectedIndex = ddlMemberName.Items.IndexOf(ddlMemberName.Items.FindByValue(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)))
        End If
        setValue()
    End Sub

    Protected Sub ddlMemberName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMemberName.SelectedIndexChanged
        setValue()
        RaiseEvent Apply_name_ValueChanged(ddlMemberName, e)
    End Sub

    Protected Sub setValue()
        Dim dt As DataTable = New Personnel().GetDataByIdCard(ddlMemberName.SelectedValue)
        Dim edt As DataTable = New DepartEmp().GetDataByIdcard(ddlMemberName.SelectedValue)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            hfApply_name.Value = dt.Rows(0)("User_name").ToString()
            hfApply_id.Value = dt.Rows(0)("Id_card").ToString()
            hfApply_posid.Value = dt.Rows(0)("Title_No").ToString()
            hfApply_stype.Value = edt.Rows(0)("Service_type").ToString()
        End If
    End Sub
End Class
