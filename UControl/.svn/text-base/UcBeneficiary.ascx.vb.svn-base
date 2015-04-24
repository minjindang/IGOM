Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_UcBeneficiary
    Inherits System.Web.UI.UserControl

    Dim DAO As New PAY_Beneficiary_data

    Private _Beneficiary_ID As String
    Public Property Beneficiary_ID() As String
        Get
            Return Me.txtBeneficiary_id.Text
        End Get
        Set(ByVal value As String)
            _Beneficiary_ID = value
            Me.txtBeneficiary_id.Text = value
        End Set
    End Property

    Private _Beneficiary_Name As String
    Public Property Beneficiary_Name() As String
        Get
            Return Me.txtBeneficiary_name.Text
        End Get
        Set(ByVal value As String)
            _Beneficiary_Name = value
            Me.txtBeneficiary_name.Text = value
        End Set
    End Property

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        btnQuery_ModalPopupExtender.Show()

        Dim dt As DataTable = DAO.GetAll(LoginManager.OrgCode, txtBeneficiary_id_Q.Text, txtBeneficiary_name_Q.Text)
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()

        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
    End Sub

    Protected Sub GridViewA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewA.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Hide()
        txtBeneficiary_id.Text = Me.GridViewA.SelectedRow.Cells(1).Text
        txtBeneficiary_name.Text = Me.GridViewA.SelectedRow.Cells(2).Text
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        btnQuery_ModalPopupExtender.Show()

        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()

    End Sub

End Class
