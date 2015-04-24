Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class WorkserviceProofDAO
        Inherits BaseDAO

        Public Function UpdateData(wp As WorkserviceProof) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", wp.Orgcode)
            d.Add("Flow_id", wp.FlowId)

            Dim v As New Dictionary(Of String, Object)
            v.Add("Apply_type", wp.ApplyType)
            v.Add("Apply_copies", wp.ApplyCopies)
            v.Add("Purpose", wp.Purpose)
            v.Add("Notes", wp.Notes)
            v.Add("Change_userid", wp.ChangeUserid)
            v.Add("Change_date", wp.ChangeDate)

            Return UpdateByExample("FSC_Workservice_proof", v, d)
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("FSC_Workservice_proof", d)
        End Function

    End Class
End Namespace