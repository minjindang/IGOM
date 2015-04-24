
Partial Class UControl_UcMaterialId
    Inherits System.Web.UI.UserControl
    Public Event Checked(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
            Bind()
        End Set
    End Property

    Public Property MaterialId() As String
        Get
            Return hfMaterialId.Value
        End Get
        Set(ByVal value As String)
            hfMaterialId.Value = value
        End Set
    End Property


    Protected Sub Bind()
        Dim mcd As New FSCPLM.Logic.MaterialClass_data()
        ddlClass.DataSource = mcd.GetDataByOrgCode(hfOrgcode.Value)
        ddlClass.DataBind()
    End Sub

    Protected Sub cbPick_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        Dim mm As New FSCPLM.Logic.Material_main()
        Dim orgcode As String = LoginManager.OrgCode
        Dim classId As String = ddlClass.SelectedValue
        gv.DataSource = mm.GetDataByClassId2(orgcode, classId)
        gv.DataBind()
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub cbClose_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub

    Protected Sub rb_CheckedChanged(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
        Dim gvr As GridViewRow = CType(sender, RadioButton).NamingContainer
        hfMaterialId.Value = CType(gvr.FindControl("Material_id"), Label).Text
        CType(gvr.FindControl("rb"), RadioButton).Checked = False
        RaiseEvent Checked(sender, e)
    End Sub

End Class
