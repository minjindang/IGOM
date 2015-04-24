Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2130DAO
        Inherits BaseDAO

        Public Function getSumData(ByVal employee_type As String, ByVal yyymm As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select PYIDNO, sum(PYMON" + CommonFun.getInt(Right(yyymm, 2)).ToString() + ") as TotalHours ")
            sql.AppendLine(" from fsc_cpap" + Left(yyymm, 3).ToString.PadLeft(3, "0") + "s ")
            sql.AppendLine(" inner join FSC_Personnel p on PYIDNO=id_card ")
            sql.AppendLine(" inner join SYS_leave_type l on l.leave_type=PYVTYPE ")
            sql.AppendLine(" where employee_type=@employee_type ")
            sql.AppendLine(" and leave_table = '15' ")
            sql.AppendLine(" group by PYIDNO ")

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@employee_type", SqlDbType.VarChar)
            params(0).Value = employee_type

            Return Query(sql.ToString(), params)
        End Function

        Public Function getData(ByVal id_card As String, ByVal yyymm As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select l.*, t.Leave_name ")
            sql.AppendLine(" from fsc_leave_main l ")
            sql.AppendLine(" inner join Sys_flow f on f.flow_id=l.flow_id ")
            sql.AppendLine(" inner join sys_leave_type t on t.leave_type = l.leave_type ")
            sql.AppendLine(" where 1=1 ")
            sql.AppendLine(" and f.case_status = 1 and f.last_pass = 1 ")
            sql.AppendLine(" and t.leave_table = '15' ")

            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and l.id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(yyymm) Then
                sql.AppendLine(" and ( substring(l.Start_date,1,5) = @yyymm or substring(l.end_date,1,5) = @yyymm) ")
            End If

            sql.AppendLine(" order by l.Start_date ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(0).Value = id_card
            params(1) = New SqlParameter("@yyymm", SqlDbType.VarChar)
            params(1).Value = yyymm

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
