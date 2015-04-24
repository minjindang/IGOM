Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_DeputyDialog
    Inherits System.Web.UI.UserControl
    Private Org As New FSC.Logic.Org()

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        BindOrgcode()
        BindUser()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

    End Sub

    Public Property Text() As String
        Get
            Return txtUnitInMemberName.Text
        End Get
        Set(value As String)
            txtUnitInMemberName.Text = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return hfUnitInMemberName.Value
        End Get
        Set(value As String)
            hfUnitInMemberName.Value = value
        End Set
    End Property

    Public Property DepartId() As String
        Get
            Return UcDDLDepart.SelectedValue
        End Get
        Set(ByVal value As String)
            UcDDLDepart.SelectedValue = value
        End Set
    End Property

    Protected Sub imgbtnGetUnitInTitleName_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnGetUnitInTitleName.Click
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub BindOrgcode()
        ddlOrgcode.DataSource = Org.GetOrgcode()
        ddlOrgcode.DataBind()
        ddlOrgcode.SelectedValue = LoginManager.OrgCode
    End Sub

    Protected Sub BindUser()
        ddlMember.Orgcode = LoginManager.OrgCode
        ddlMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub ddlOrgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrgcode.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Show()
        UcDDLDepart.Orgcode = ddlOrgcode.SelectedValue
        BindUser()
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Show()
        BindUser()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        btnQuery_ModalPopupExtender.Hide()
        Dim orgName As String = ddlOrgcode.SelectedItem.Text
        Dim depName As String = IIf(UcDDLDepart.SelectedValue = "", "", UcDDLDepart.SelectedItem.Text)

        txtUnitInMemberName.Text = ddlMember.SelectedItem.Text & "(" & orgName & depName & ")"
        Dim arr() As String = {"3", ddlMember.SelectedValue, ddlOrgcode.SelectedValue, UcDDLDepart.SelectedValue}
        hfUnitInMemberName.Value = CommonFun.CombineString(arr, ",")

        ddlOrgcode.SelectedIndex = -1
        UcDDLDepart.SelectedValue = ""
        ddlMember.SelectedValue = ""
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class