Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT1103
        Private DAO As MAT1103DAO
        Private AMMDAO As ApplyMaterialMain

        Public Sub New()
            DAO = New MAT1103DAO()
            AMMDAO = New ApplyMaterialMain
        End Sub

        Public Function isBatch(flowID As String) As Boolean
            Dim dt As DataTable = getFlowByMergeFlowID(flowID)
            Return Not dt Is Nothing AndAlso dt.Rows.Count > 0
        End Function

        Public Function queryFlowOne(flowID As String, orgCode As String) As DataRow
            Dim dt As DataTable = DAO.queryFlowOne(flowID, orgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
            Return Nothing
        End Function

        Public Function getFlowByMergeFlowID(flowID As String) As DataTable
            Return DAO.getFlowByMergeFlowID(flowID)
        End Function

        Public Function getFormType(flowID As String, orgCode As String) As String
            Dim formType As String = String.Empty
            Dim dr As DataRow = AMMDAO.GetOne(flowID, orgCode)
            If Not dr Is Nothing Then
                formType = CommonFun.SetDataRow(dr, "Form_type")
            End If
            Return formType
        End Function

        Public Function GetByFlow(flow_id As String, orgCode As String) As DataTable
            Return DAO.GetByFlow(flow_id, orgCode)
        End Function

        Public Sub UpdateOutCnt(flow_id As String, orgCode As String, details_id As String, Out_cnt As Integer)
            DAO.UpdateOutCnt(flow_id, orgCode, details_id, Out_cnt)
        End Sub


    End Class
End Namespace
