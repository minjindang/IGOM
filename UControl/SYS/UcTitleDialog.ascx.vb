Imports FSCPLM.Logic

Partial Class UControl_UcTitleDialog
    Inherits System.Web.UI.UserControl
    Private Org As New FSC.Logic.Org()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        BindOrgcode()
        BindTitle()
    End Sub

    Public Property Text() As String
        Get
            Return txtUnitInTitleName.Text
        End Get
        Set(value As String)
            txtUnitInTitleName.Text = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return hfUnitInTitleName.Value
        End Get
        Set(value As String)
            hfUnitInTitleName.Value = value
        End Set
    End Property

    Protected Sub imgbtnGetUnitInTitleName_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnGetUnitInTitleName.Click
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub BindOrgcode()
        ddlOrgcode.DataSource = Org.GetOrgcode()
        ddlOrgcode.DataBind()
    End Sub

    Protected Sub BindTitle()
        ddlTitle.Items.Clear()
        If Not String.IsNullOrEmpty(ddlOrgcode.SelectedValue) AndAlso Not String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            Dim personnel As New FSC.Logic.Personnel()
            ddlTitle.DataSource = personnel.GetTitleDataByOrgDep(ddlOrgcode.SelectedValue, UcDDLDepart.SelectedValue)
            ddlTitle.DataBind()
        End If
        ddlTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlOrgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrgcode.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Show()
        UcDDLDepart.Orgcode = ddlOrgcode.SelectedValue
        BindTitle()
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Show()
        BindTitle()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        btnQuery_ModalPopupExtender.Hide()
        Dim orgName As String = ddlOrgcode.SelectedItem.Text
        Dim depName As String = IIf(UcDDLDepart.SelectedValue = "", "", UcDDLDepart.SelectedItem.Text)
        txtUnitInTitleName.Text = ddlTitle.SelectedItem.Text & "(" & orgName & depName & ")"
        Dim arr() As String = {"2", ddlTitle.SelectedValue, ddlOrgcode.SelectedValue, UcDDLDepart.SelectedValue}
        hfUnitInTitleName.Value = CommonFun.CombineString(arr, ",")

        ddlOrgcode.SelectedIndex = -1
        UcDDLDepart.SelectedValue = ""
        ddlTitle.SelectedValue = ""
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class