Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic

    Public Class RewordDetDAO
        Inherits BaseDAO

        Public Sub New()
        End Sub

        Public Function DeletTempData(orgcode As String, id_card As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" delete from FSC_Reword_det ")
            sql.AppendLine("    where flow_id=@id_card ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@id_card", id_card)}

            Return Execute(sql.ToString(), params)
        End Function


        Public Function GetTempData(orgcode As String, id_card As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from FSC_Reword_det ")
            sql.AppendLine("    where flow_id=@id_card ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@id_card", id_card)}

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
