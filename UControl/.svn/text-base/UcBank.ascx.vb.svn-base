Imports FSCPLM.Logic

Partial Class UControl_UcBank
    Inherits System.Web.UI.UserControl

    Dim DAO As New PAY_Bank_data

    Private _Bank_ID As String
    Public Property Bank_ID() As String
        Get
            Return Me.txtBank_id.Text
        End Get
        Set(ByVal value As String)
            _Bank_ID = value
            Me.txtBank_id.Text = value
        End Set
    End Property

    Private _Bank_Name As String
    Public Property Bank_Name() As String
        Get
            Return Me.txtBank_name.Text
        End Get
        Set(ByVal value As String)
            _Bank_Name = value
            Me.txtBank_name.Text = value
        End Set
    End Property

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        btnQuery_ModalPopupExtender.Show()
        Me.GridViewA.DataSource = DAO.GetAll(txtBank_id_Q.Text, txtBankAbbreviation_name_Q.Text, "")
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewA.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Hide()
        txtBank_id.Text = Me.GridViewA.SelectedRow.Cells(1).Text
        txtBank_name.Text = Me.GridViewA.SelectedRow.Cells(3).Text
    End Sub

End Class
