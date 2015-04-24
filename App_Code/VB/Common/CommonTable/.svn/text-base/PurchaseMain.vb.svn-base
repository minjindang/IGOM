Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web


Namespace FSCPLM.Logic
    Public Class PurchaseMain
        Public DAO As PurchaseMainDAO

        Public Sub New()
            DAO = New PurchaseMainDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New PurchaseMainDAO(conn)
        End Sub

        Public Function GetCountByFlowId(ByVal flow_Id As Integer) As Integer
            Return DAO.GetCountByFlowId(flow_Id)
        End Function

        Public Function GetDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As DataTable
            Return DAO.GetDataByFlowId(orgcode, flow_Id)
        End Function

        Public Function GetImporrtOtMtrNOTYData(orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetImporrtOtMtrNOTYData(orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Sub UpdateImportOtMtr(ByVal ImportOtMtr As String, ByVal flow_id As String)
            DAO.UpdateImportOtMtr(ImportOtMtr, flow_id)
        End Sub

        Public Function DeleteDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As Boolean
            Return DAO.DeleteDataByFlowId(orgcode, flow_Id) > 0
        End Function
    End Class
End Namespace