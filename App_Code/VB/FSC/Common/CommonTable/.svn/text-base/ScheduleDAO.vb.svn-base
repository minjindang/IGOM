Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSC.Logic
    Public Class ScheduleDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetMaxScheduleId(ByVal orgcode As String) As Object
            Dim sql As New StringBuilder()
            sql.AppendLine("select max(schedule_id) from FSC_schedule where orgcode=@orgcode ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode)}

            Return Scalar(sql.ToString(), params)
        End Function
    End Class
End Namespace