Imports System.Data
Imports FSCPLM.Logic

Partial Class UControl_UcInformation
    Inherits System.Web.UI.UserControl

#Region "Property"
    Dim _Orgcode As String
    Public Property Orgcode() As String
        Get
            Return _Orgcode
        End Get
        Set(ByVal value As String)
            _Orgcode = value
        End Set
    End Property

    Dim _Inf_type As String
    Public Property Inf_type() As String
        Get
            Return _Inf_type
        End Get
        Set(ByVal value As String)
            _Inf_type = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        bind()
    End Sub

    Protected Sub Bind()
        gv.DataSource = New Information().GetInformationByInf_orgcode(Inf_type, Orgcode)
        gv.DataBind()
    End Sub

    Protected Sub gv_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBinding
        For i As Integer = 0 To gv.Columns.Count - 1
            gv.Columns(i).Visible = True
        Next

        Select Case Inf_type
            Case "1"
                gv.Columns(1).Visible = False
                gv.Columns(2).Visible = False
            Case "2"
                gv.Columns(0).Visible = False
                gv.Columns(2).Visible = False
            Case "3", "4"
                gv.Columns(0).Visible = False
                gv.Columns(1).Visible = False
        End Select
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("gv_hl1"), HyperLink).NavigateUrl = "~/FSCPLM/FSC4/FSC43/FSC4301_01.aspx?snos=" & CType(e.Row.FindControl("gv_lbSerial_nos"), Label).Text.Trim()
        End If
    End Sub
End Class
