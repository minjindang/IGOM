Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_UcPayer
    Inherits System.Web.UI.UserControl

    Dim DAO As New PAY_ExaminePayer_main

    Private _Payer_id As String
    Public Property Payer_id() As String
        Get
            Return Me.txtPayer_id.Text
        End Get
        Set(ByVal value As String)
            _Payer_id = value
            Me.txtPayer_id.Text = value
        End Set
    End Property

    Private _Payer_name As String
    Public Property Payer_name() As String
        Get
            Return Me.txtPayer_name.Text
        End Get
        Set(ByVal value As String)
            _Payer_name = value
            Me.txtPayer_name.Text = value
        End Set
    End Property

    Private _enabled As Boolean
    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            btnQuery.Enabled = value
            _enabled = value
        End Set
    End Property



    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        btnQuery_ModalPopupExtender.Show()
        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewA.SelectedIndexChanged
        btnQuery_ModalPopupExtender.Hide()
        txtPayer_id.Text = Me.GridViewA.SelectedRow.Cells(1).Text
        txtPayer_name.Text = Me.GridViewA.SelectedRow.Cells(2).Text
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'btnQuery_ModalPopupExtender.Show()
        Dim dt As DataTable = DAO.GetAll()
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        'dt.Dispose()
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class
