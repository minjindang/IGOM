Imports System.Data
Imports System.Transactions
Imports PRO.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC0101_33
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Public Sub Bind()
        Dim bll As New PRO_SwRegister_Trans()
        Dim org As String = Request.QueryString("org")
        Dim fid As String = Request.QueryString("fid")

        UcFlowDetail.Orgcode = org
        UcFlowDetail.FlowId = fid

        Dim tmp As DataTable = bll.getDataByOrgFid(org, fid)
        Dim dt As DataTable = New FSCPLM.Logic.PRO_SwRegister_main().GetAll().Clone()

        For Each dr As DataRow In tmp.Rows
            dt.ImportRow(New FSCPLM.Logic.PRO_SwRegister_main().GetOne(dr("SR_Flow_id"), org))
        Next

        If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
            lbOldUnit_name.Text = New FSC.Logic.Org().GetDepartName(org, tmp.Rows(0)("OldUnit_code"))
            lbOldKeeper_name.Text = New FSC.Logic.Personnel().GetColumnValue("User_name", tmp.Rows(0)("OldKeeper_id"))
            lbNewUnit_name.Text = New FSC.Logic.Org().GetDepartName(org, tmp.Rows(0)("NewUnit_code"))
            lbNewKeeper_name.Text = New FSC.Logic.Personnel().GetColumnValue("User_name", tmp.Rows(0)("NewKeeper_id"))
        End If

        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Dim url As String = ViewState("BackUrl")
        If url IsNot Nothing Then
            Response.Redirect(url)
        End If
    End Sub

End Class
