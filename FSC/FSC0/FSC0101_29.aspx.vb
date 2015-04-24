Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC0101_29
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Public Sub Bind()
        Dim bll As New SAL.Logic.SAL1111()
        Dim org As String = Request.QueryString("org")
        Dim fid As String = Request.QueryString("fid")
        Dim dt As DataTable = New DataTable()

        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(org, fid)
        If String.IsNullOrEmpty(f.MergeFlag) Then
            dt = bll.GetDataByOrgFid(org, fid)

            dt.Columns.Add("Flow_id")
            dt.Columns.Add("Depart_name")
            For Each dr As DataRow In dt.Rows
                dr("Flow_id") = fid
                dr("Depart_name") = New FSC.Logic.Org().GetDepartName(dr("Orgcode").ToString(), dr("Depart_id").ToString())
            Next

        Else
            Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(f.MergeOrgcode, f.MergeFlowid)

            For Each dr As DataRow In fdt.Rows
                Dim ddt As DataTable = bll.GetDataByOrgFid(dr("Orgcode").ToString(), dr("Flow_id").ToString())
                ddt.Columns.Add("Flow_id")
                ddt.Columns.Add("Depart_name")
                For Each ddr As DataRow In ddt.Rows
                    ddr("Flow_id") = dr("Flow_id").ToString()
                    ddr("Depart_name") = New FSC.Logic.Org().GetDepartName(dr("Orgcode").ToString(), dr("Depart_id").ToString())
                Next

                dt.Merge(ddt)
            Next

        End If

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
