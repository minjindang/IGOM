Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web


Namespace MAT.Logic
    Public Class PurchaseDet
        Public DAO As PurchaseDetDAO

        Public Sub New()
            DAO = New PurchaseDetDAO()
        End Sub

        Public Function GetDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As DataTable
            Return DAO.GetDataByFlowId(orgcode, flow_Id)
        End Function

        Public Function DeleteDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As Boolean
            Return DAO.DeleteDataByFlowId(orgcode, flow_Id) > 0
        End Function
    End Class
End Namespace