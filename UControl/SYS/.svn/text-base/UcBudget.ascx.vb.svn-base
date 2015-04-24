
Partial Class UControl_SYS_UcBudget
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)


    Public Property BudgetType() As String
        Get
            Return hfBudgetType.Value
        End Get
        Set(ByVal value As String)
            hfBudgetType.Value = value
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(value As String)
            hfOrgcode.Value = value
            Bind()
        End Set
    End Property

    Protected Sub Bind()
        Dim code As New FSCPLM.Logic.SACode()
        ddlBudgetType.DataSource = code.GetData("002", "018")
        ddlBudgetType.DataBind()

    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        btnQuery_ModalPopupExtender.Hide()
        hfBudgetType.Value = ddlBudgetType.SelectedValue

        RaiseEvent Click(sender, e)
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub

    Protected Sub cbBudget_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
    End Sub
End Class
