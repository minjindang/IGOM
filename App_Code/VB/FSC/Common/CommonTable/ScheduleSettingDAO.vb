Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Namespace FSC.Logic
    Public Class ScheduleSettingDAO
        Inherits BaseDAO

        Public Function GetMaxDataByScheId(ByVal orgcode As String, ByVal yymm As String, ByVal scheduleId As String) As DataTable
            Dim sql As New StringBuilder()
            Dim len As Integer = yymm.Length

            sql.AppendLine(" select * from FSC_Schedule_setting ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine("    and sche_date = ")
            sql.AppendLine("    (select max(sche_date) from FSC_Schedule_setting where substring(sche_date,1," & len & ")=@yymm and schedule_id=@scheduleId) ")


            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@yymm", yymm), _
                New SqlParameter("@scheduleId", scheduleId)}

            Return Query(sql.ToString(), params)
        End Function


        Public Function getDataByQuery(ByVal orgcode As String, ByVal id_card As String, ByVal sche_date As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.*, b.Sche_type ")
            sql.AppendLine(" from FSC_Schedule a ")
            sql.AppendLine(" left outer join FSC_Schedule_setting b on a.schedule_id=b.schedule_id ")
            sql.AppendLine(" where b.orgcode=@orgcode ")
            sql.AppendLine(" and b.id_card=@id_card ")
            sql.AppendLine(" and b.sche_date=@sche_date ")
            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@id_card", SqlDbType.VarChar), _
            New SqlParameter("@sche_date", SqlDbType.VarChar)}
            ps(0).Value = orgcode
            ps(1).Value = id_card
            ps(2).Value = sche_date
            Return Query(sql.ToString(), ps)
        End Function


        Public Function DeleteData(ByVal orgcode As String, ByVal yyymm As String, ByVal scheduleId As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" delete from FSC_Schedule_setting ")
            sql.AppendLine(" where orgcode=@orgcode and substring(sche_date,1,5)=@yyymm and schedule_id=@scheduleId ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@yyymm", yyymm), _
                New SqlParameter("@scheduleId", scheduleId)}

            Return Execute(sql.ToString(), params)
        End Function

        Public Function getCheckData(ByVal Orgcode As String, ByVal Schedule_id As String, ByVal Sche_date As String, ByVal id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from ")
            sql.AppendLine(" FSC_Schedule_setting ")
            sql.AppendLine(" where Orgcode=@Orgcode ")
            sql.AppendLine(" and Schedule_id=@Schedule_id ")
            sql.AppendLine(" and Sche_date=@Sche_date ")
            sql.AppendLine(" and id <> @id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Schedule_id", Schedule_id), _
            New SqlParameter("@Sche_date", Sche_date), _
            New SqlParameter("@id", id)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function updateSchedulehours(ByVal schedule_hours As Integer, ByVal Sche_date As String, ByVal id_card As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update ")
            sql.AppendLine(" FSC_Schedule_setting ")
            sql.AppendLine(" set schedule_hours=@schedule_hours ")
            sql.AppendLine(" where  ")
            sql.AppendLine(" Sche_date=@Sche_date ")
            sql.AppendLine(" and id_card=@id_card ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@schedule_hours", schedule_hours), _
            New SqlParameter("@Sche_date", Sche_date), _
            New SqlParameter("@id_card", id_card)}

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace