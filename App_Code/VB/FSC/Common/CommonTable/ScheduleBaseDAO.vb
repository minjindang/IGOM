Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Namespace FSC.Logic
    Public Class ScheduleBaseDAO
        Inherits BaseDAO


        Public Function DeleteData(ByVal orgcode As String, ByVal yyymm As String, ByVal scheduleId As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" delete from FSC_Schedule_base ")
            sql.AppendLine(" where orgcode=@orgcode and substring(sche_date,1,5)=@yyymm and schedule_id=@scheduleId ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@yyymm", yyymm), _
                New SqlParameter("@scheduleId", scheduleId)}

            Return Execute(sql.ToString(), params)
        End Function

    End Class
End Namespace