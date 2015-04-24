Imports FSCPLM.Logic

Partial Class UControl_UcRoleDialog
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        BindOrgcode()
        BindRole()
    End Sub

    Public Property Text() As String
        Get
            Return txtUnitInRoleName.Text
        End Get
        Set(value As String)
            txtUnitInRoleName.Text = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return hfUnitInRoleName.Value
        End Get
        Set(value As String)
            hfUnitInRoleName.Value = value
        End Set
    End Property

    Protected Sub imgbtnGetUnitInTitleName_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnGetUnitInRoleName.Click
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub BindOrgcode()
        Dim Org As New FSC.Logic.Org()
        ddlOrgcode.DataSource = Org.GetOrgcode()
        ddlOrgcode.DataBind()
    End Sub

    Protected Sub BindRole()
        ddlRole.Items.Clear()
        If Not String.IsNullOrEmpty(ddlOrgcode.SelectedValue) Then
            Dim role As New SYS.Logic.Role()
            ddlRole.DataSource = role.GetDataByOrgDep(ddlOrgcode.SelectedValue)
            ddlRole.DataBind()
        End If
        ddlRole.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlOrgcode_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
        BindRole()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        btnQuery_ModalPopupExtender.Hide()
        Dim orgName As String = ddlOrgcode.SelectedItem.Text
        txtUnitInRoleName.Text = ddlRole.SelectedItem.Text & IIf(cbxUnitFlag.Checked, "(依申請單位)", "") & "(" & orgName & ")"
        Dim arr() As String = {"4", ddlRole.SelectedValue, ddlOrgcode.SelectedValue, "", IIf(cbxUnitFlag.Checked, "1", "0")}
        hfUnitInRoleName.Value = CommonFun.CombineString(arr, ",")

        ddlOrgcode.SelectedIndex = -1
        ddlRole.SelectedValue = ""
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub

End Class