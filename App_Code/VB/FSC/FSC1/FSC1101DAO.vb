Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC1101DAO
        Inherits BaseDAO


        Public Function GetOvertimeData(ByVal PRIDNO As String, ByVal PRADDD As String) As DataTable
            Dim sql As New StringBuilder()
            sql.Append(" SELECT *, (isnull(PRADDH, 0) - isnull(PRPAYH, 0) - isnull(PRMNYH, 0)) NotApplyHours ")
            sql.Append(" FROM FSC_CPAPR18M WITH(NOLOCK) WHERE PRIDNO=@PRIDNO AND PRADDD>=@PRADDD ")
            sql.Append(" AND( (PRADDD<@NOW  and PRATYPE<>'3') or (PRATYPE='3'))")
            sql.Append(" AND (isnull(PRADDH, 0) - isnull(PRPAYH, 0) - isnull(PRMNYH, 0)) > 0 ")
            sql.Append(" ORDER BY PRADDD ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@PRIDNO", SqlDbType.VarChar)
            params(0).Value = PRIDNO
            params(1) = New SqlParameter("@PRADDD", SqlDbType.VarChar)
            params(1).Value = PRADDD
            params(2) = New SqlParameter("@NOW", SqlDbType.VarChar)
            params(2).Value = DateTimeInfo.GetRocDate(Now)
            Return Query(sql.ToString(), params)
        End Function


        Public Function GetBusinessData(ByVal PPIDNO As String, ByVal PPBUSDATEE As String) As DataTable
            Dim sql As New StringBuilder()
            sql.Append("SELECT * FROM FSC_CPAPP16M WITH(NOLOCK) ")
            sql.Append("     WHERE PPIDNO=@PPIDNO AND PPBUSDATEE>=@PPBUSDATEE AND PPBUSTYPE='1' AND PPHOLIDAY='1' AND PPBUSDATEE<@NOW AND PPHDAY<>'0' ")
            sql.Append(" ORDER BY PPBUSDATEB ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@PPIDNO", SqlDbType.VarChar)
            params(0).Value = PPIDNO
            params(1) = New SqlParameter("@PPBUSDATEE", SqlDbType.VarChar)
            params(1).Value = PPBUSDATEE
            params(2) = New SqlParameter("@NOW", SqlDbType.VarChar)
            params(2).Value = DateTimeInfo.GetRocDate(Now)

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetScheduleData(ByVal idCard As String, ByVal scheDate As String) As DataTable
            Dim sql As New StringBuilder()
            sql.Append("SELECT * FROM FSC_Schedule_setting WITH(NOLOCK) ")
            sql.Append("     WHERE id_card=@idCard AND sche_date>=@scheDate AND sche_date<@NOW ")
            sql.Append("     and isnull(schedule_hours, 0) > 0 ")
            sql.Append(" ORDER BY sche_date ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@idCard", SqlDbType.VarChar)
            params(0).Value = idCard
            params(1) = New SqlParameter("@scheDate", SqlDbType.VarChar)
            params(1).Value = scheDate
            params(2) = New SqlParameter("@NOW", SqlDbType.VarChar)
            params(2).Value = DateTimeInfo.GetRocDate(Now)

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
