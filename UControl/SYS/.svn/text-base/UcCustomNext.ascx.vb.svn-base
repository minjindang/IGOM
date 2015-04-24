
Partial Class UControl_SYS_UcCustomNext
    Inherits System.Web.UI.UserControl
    Private Org As New FSC.Logic.Org()
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property Text() As String
        Get
            Return cbNext.Text
        End Get
        Set(ByVal value As String)
            cbNext.Text = value
        End Set
    End Property

    Public Property NextOrgcode() As String
        Get
            Return hfNextOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfNextOrgcode.Value = value
        End Set
    End Property
    Public Property NextDepartid() As String
        Get
            Return hfNextDepartid.Value
        End Get
        Set(ByVal value As String)
            hfNextDepartid.Value = value
        End Set
    End Property
    Public Property NextPosid() As String
        Get
            Return hfNextposid.Value
        End Get
        Set(ByVal value As String)
            hfNextposid.Value = value
        End Set
    End Property
    Public Property NextIdcard() As String
        Get
            Return hfNextIdcard.Value
        End Get
        Set(ByVal value As String)
            hfNextIdcard.Value = value
        End Set
    End Property
    Public Property NextName() As String
        Get
            Return hfNextName.Value
        End Get
        Set(ByVal value As String)
            hfNextName.Value = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        BindOrgcode()
        UcDDLDepart.Orgcode = ddlOrgcode.SelectedValue
        BindUser()
    End Sub
    
    Protected Sub cbNext_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub BindOrgcode()
        ddlOrgcode.DataSource = Org.GetOrgcode()
        ddlOrgcode.DataBind()
        ddlOrgcode.SelectedValue = LoginManager.OrgCode
        ddlOrgcode.Enabled = False
    End Sub

    Protected Sub BindUser()
        UcDDLMember.Orgcode = ddlOrgcode.SelectedValue
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
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

        hfNextOrgcode.Value = ddlOrgcode.SelectedValue
        hfNextDepartid.Value = New FSC.Logic.DepartEmp().GetDepartId(UcDDLMember.SelectedValue)
        hfNextIdcard.Value = UcDDLMember.SelectedValue
        hfNextposid.Value = New FSC.Logic.Personnel().GetColumnValue("Title_no", hfNextIdcard.Value)

        Dim name As String = UcDDLMember.SelectedItem.Text
        If name.Contains("/") Then
            name = name.Split("/")(1)
        End If
        hfNextName.Value = name

        ddlOrgcode.SelectedIndex = -1
        UcDDLDepart.SelectedValue = ""
        UcDDLMember.SelectedValue = ""
        RaiseEvent Click(sender, e)
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub

End Class
