Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Transactions
Imports System.IO

Namespace FSCPLM.Logic

    Public Class MAI3202

        Dim emdDAO As ElecMaintain_det
        Dim emmDAO As ElecMaintain_main
        Dim saDAO As SACode

        Public Sub New()
            emdDAO = New ElecMaintain_det()
            emmDAO = New ElecMaintain_main()
            saDAO = New SACode()
        End Sub

        Public Sub GetBy(flow_id As String, ByRef detDT As DataTable, ByRef mainDR As DataRow)
            Dim newDetDT As New DataTable
            newDetDT.Columns.Add(New DataColumn("Index"))
            newDetDT.Columns.Add(New DataColumn("MtClass_typeName"))
            newDetDT.Columns.Add(New DataColumn("Problem_desc"))
            newDetDT.Columns.Add(New DataColumn("MtStatus_desc"))
            newDetDT.Columns.Add(New DataColumn("MtStatus_type"))
            newDetDT.Columns.Add(New DataColumn("Maintainer_name"))
            newDetDT.Columns.Add(New DataColumn("MtClass_type"))
            newDetDT.Columns.Add(New DataColumn("MtStartTime"))

            mainDR = emmDAO.GetOne(flow_id, LoginManager.OrgCode)


            Dim det As DataTable = emdDAO.GetAll(LoginManager.OrgCode, flow_id)

            Dim index As Integer = 1
            For Each dr As DataRow In det.Rows
                Dim newDetDR As DataRow = newDetDT.NewRow()
                newDetDR("Index") = index
                newDetDR("Problem_desc") = dr("Problem_desc")
                newDetDR("MtStatus_desc") = dr("MtStatus_desc")
                newDetDR("MtClass_typeName") = saDAO.GetCodeDesc("019", "008", CommonFun.SetDataRow(dr, "MtClass_type"))
                newDetDR("Maintainer_name") = dr("Maintainer_name")
                newDetDR("MtStatus_type") = saDAO.GetCodeDesc("019", "006", CommonFun.SetDataRow(dr, "MtStatus_type"))
                newDetDR("MtClass_type") = dr("MtClass_type")
                If Not String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "MtStartTime")) Then
                    newDetDR("MtStartTime") = CommonFun.getYYYMMDD(CommonFun.SetDataRow(dr, "MtStartTime"))
                Else
                    newDetDR("MtStartTime") = ""
                End If


                newDetDT.Rows.Add(newDetDR)
                index += 1
            Next 

            detDT = newDetDT

        End Sub

        Public Sub Done(detDR As DataTable)
            For Each dr As DataRow In detDR.Rows
                Modify(dr("Flow_id"), dr("OrgCode"), dr("MtClassType"), dr("Satisfaction_type"))
            Next
        End Sub

        Private Sub Modify(Flow_id As String, OrgCode As String, MtClassType As String, Satisfaction_type As String)
            emdDAO.Modify(Flow_id, MtClassType, OrgCode, "", "", "", "", DateTime.MinValue, DateTime.MinValue, _
                          0, "", "", "", "", Satisfaction_type, LoginManager.UserId, Now)
        End Sub

    End Class

End Namespace
