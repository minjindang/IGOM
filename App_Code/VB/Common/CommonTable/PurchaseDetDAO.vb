Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace MAT.Logic
    Public Class PurchaseDetDAO
        Inherits BaseDAO

        Public Function GetDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As DataTable
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@Flow_id", flow_Id)}
            Return Query("select * from MAT_Purchase_det where Orgcode=@orgcode and Flow_id=@Flow_id", params)
        End Function

        Public Function DeleteDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As Integer
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@Flow_id", flow_Id)}
            Return Execute("Delete from MAT_Purchase_det where Orgcode=@orgcode and Flow_id=@Flow_id", params)
        End Function
    End Class
End Namespace