Imports System.Data
Imports System.Transactions
Imports SAL.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC0101_31
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Public Sub Bind()
        Dim org As String = Request.QueryString("org")
        Dim fid As String = Request.QueryString("fid")
        Dim dt As DataTable = New DataTable

        Dim outfee As New SAL.Logic.SAL_OfficialoutFee()
        Dim fscorg As New FSC.Logic.Org()
        Dim p As New FSC.Logic.Personnel()
        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(org, fid)

        If String.IsNullOrEmpty(f.MergeFlag) Then
            Dim odt As DataTable = outfee.GetDataByOrgFid(org, fid)
            dt.Merge(odt)

        Else
            Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(org, fid)
            For Each dr As DataRow In fdt.Rows
                Dim odt As DataTable = outfee.GetDataByOrgFid(dr("orgcode").ToString(), dr("flow_id").ToString())
                If odt IsNot Nothing AndAlso odt.Rows.Count > 0 Then
                    dt.Merge(odt)
                End If
            Next
        End If

        dt.Columns.Add("Depart_name")
        dt.Columns.Add("User_name")
        For Each dr As DataRow In dt.Rows
            dr("Depart_name") = fscorg.GetDepartName(dr("Orgcode").ToString(), dr("Depart_id").ToString())
            dr("User_name") = p.GetColumnValue("User_name", dr("Id_card").ToString())
        Next

        gv.DataSource = dt
        gv.DataBind()

        UcFlowDetail.Orgcode = org
        UcFlowDetail.FlowId = fid
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Dim url As String = ViewState("BackUrl")
        If url IsNot Nothing Then
            Response.Redirect(url)
        End If
    End Sub

End Class
