Imports System.Data
Imports System.Transactions
Imports SAL.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC0101_30
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Public Sub Bind()
        Dim org As String = Request.QueryString("org")
        Dim fid As String = Request.QueryString("fid")
        Dim dt As DataTable = New DataTable

        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(org, fid)
        If String.IsNullOrEmpty(f.MergeFlag) Then
            Dim odt As DataTable = New LabOvertimeFeeMaster().getDataByFlowid(org, fid)
            If odt IsNot Nothing AndAlso odt.Rows.Count > 0 Then
                dt = New SAL1112().doQuerySAL1112(org, odt.Rows(0)("Depart_id").ToString(), odt.Rows(0)("Fee_YM").ToString(), odt.Rows(0)("id_card").ToString())
            End If

            dt.Columns.Add("Flow_id")
            dt.Columns.Add("Depart_name")
            For Each dr As DataRow In dt.Rows
                dr("Flow_id") = fid
                dr("Depart_name") = New FSC.Logic.Org().GetDepartName(dr("Orgcode").ToString(), dr("Depart_id").ToString())
            Next

        Else
            Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(f.MergeOrgcode, f.MergeFlowid)
            For Each fdr As DataRow In fdt.Rows
                Dim odt As DataTable = New LabOvertimeFeeMaster().getDataByFlowid(fdr("orgcode").ToString(), fdr("flow_id").ToString())
                If odt IsNot Nothing AndAlso odt.Rows.Count > 0 Then

                    Dim ddt As DataTable = New SAL1112().doQuerySAL1112(org, odt.Rows(0)("Depart_id").ToString(), odt.Rows(0)("Fee_YM").ToString(), odt.Rows(0)("id_card").ToString())
                    ddt.Columns.Add("Flow_id")
                    ddt.Columns.Add("Depart_name")
                    For Each ddr As DataRow In ddt.Rows
                        ddr("Flow_id") = fdr("flow_id").ToString()
                        ddr("Depart_name") = New FSC.Logic.Org().GetDepartName(fdr("Orgcode").ToString(), fdr("Depart_id").ToString())
                    Next

                    dt.Merge(ddt)
                End If

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
