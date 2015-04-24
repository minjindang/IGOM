Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_UcUserDialog
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

    Public Property Orgcode() As String
        Get
            Return ddlOrgcode.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlOrgcode.SelectedValue = value
        End Set
    End Property

    Protected Sub imgbtnGetUnitInTitleName_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnGetUnitInTitleName.Click
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub BindOrgcode()
        ddlOrgcode.DataSource = Org.GetOrgcode()
        ddlOrgcode.DataBind()
    End Sub

    Protected Sub BindUser()
        ddlMember.Items.Clear()
        If Not String.IsNullOrEmpty(ddlOrgcode.SelectedValue) Then
            Dim p As New FSC.Logic.Personnel()
            Dim dt As DataTable = p.GetDataByOrgDep(ddlOrgcode.SelectedValue, UcDDLDepart.SelectedValue)
            ddlMember.DataSource = dt
            ddlMember.DataBind()
        End If
        ddlMember.Items.Insert(0, New ListItem("請選擇", ""))
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
        Dim org As New FSC.Logic.Org()
        Dim dep As New FSC.Logic.DepartEmp()

        Dim depid As String = dep.GetDepartId(ddlMember.SelectedValue)
        Dim depName As String = org.GetDepartName(ddlOrgcode.SelectedValue, depid)

        txtUnitInMemberName.Text = ddlMember.SelectedItem.Text & "(" & orgName & depName & ")"
        Dim arr() As String = {"3", ddlMember.SelectedValue, ddlOrgcode.SelectedValue, depid}
        hfUnitInMemberName.Value = CommonFun.CombineString(arr, ",")

        ddlOrgcode.SelectedIndex = -1
        UcDDLDepart.SelectedValue = ""
        ddlMember.SelectedValue = ""
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class