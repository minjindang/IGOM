Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowIdDAO
        Inherits BaseDAO

        Public Function GetDataByQuery(orgcode As String, flowKind As String, flowType As String, flowYear As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_kind", flowKind)
            d.Add("Flow_type", flowType)
            d.Add("Flow_year", flowYear)

            Return GetDataByExample("SYS_Flow_id", d)
        End Function

        Public Function insertData(orgcode As String, flowKind As String, flowType As String, flowYear As String, flowId As String, changeUserid As String, changeDate As Date) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_kind", flowKind)
            d.Add("Flow_type", flowType)
            d.Add("Flow_year", flowYear)
            d.Add("Flow_id", flowId)
            d.Add("Change_userid", changeUserid)
            d.Add("Change_date", changeDate)

            Return InsertByExample("SYS_Flow_id", d)
        End Function

        Public Function UpdateFlowId(orgcode As String, flowKind As String, flowType As String, flowYear As String, flowId As String, changeUserid As String, changeDate As Date) As Integer
            Dim d As New Dictionary(Of String, Object)
            Dim v As New Dictionary(Of String, Object)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_kind", flowKind)
            d.Add("Flow_type", flowType)
            d.Add("Flow_year", flowYear)

            v.Add("Flow_id", flowId)
            v.Add("Change_userid", changeUserid)
            v.Add("Change_date", changeDate)
            Return UpdateByExample("SYS_Flow_id", v, d)
        End Function

    End Class
End Namespace