Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2131DAO
        Inherits BaseDAO

        Function GetQueryData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal POIDNO As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable

            Dim sql As New StringBuilder()

            sql.AppendLine(" select ")
            sql.AppendLine("     poidno, pocard, poname, povdays, povdateb, povtimeb, povdatee, povtimee ")
            sql.AppendLine(" from  ")
            sql.AppendLine("    FSC_cpapo15m  ")
            sql.AppendLine(" where  ")
            sql.AppendLine("    povdateb >= @StartDate and povdatee <= @EndDate ")
            sql.AppendLine("    and Orgcode=@Orgcode ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(POIDNO) Then
                sql.AppendLine(" and POIDNO=@POIDNO ")
            End If

            sql.AppendLine(" order by ")
            sql.AppendLine("    poidno, povdateb, povtimeb, povdatee, povtimee ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@POIDNO", POIDNO), _
            New SqlParameter("@StartDate", StartDate), _
            New SqlParameter("@EndDate", EndDate)}

            Return Query(sql.ToString, params)
        End Function

        Function GetQueryDetailData(ByVal poidno As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select ")
            sql.AppendLine("    poidno, pocard, poname, povtype, povdays, povdateb, povtimeb, povdatee, povtimee, poremark ")
            sql.AppendLine(" from  ")
            sql.AppendLine("    FSC_cpapo15m  ")
            sql.AppendLine(" where  ")
            sql.AppendLine("    (povdateb + povtimeb >= @StartDate and povdatee + povtimee <= @EndDate) ")
            sql.AppendLine("    and poidno=@poidno order by povdateb, povtimeb")

            Dim params() As SqlParameter = { _
            New SqlParameter("@StartDate", StartDate), _
            New SqlParameter("@EndDate", EndDate), _
            New SqlParameter("@poidno", poidno)}

            Return Query(sql.ToString, params)

        End Function

        Function GetWorkDays(ByVal StartDate As String, ByVal EndDate As String) As Object
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select count(pbddate) as cnt from  ")
            StrSQL.Append(" FSC_cpapb02m ")
            StrSQL.Append(" where ")
            StrSQL.Append(" pbddate >= @StartDate and pbddate<=@EndDate ")
            StrSQL.Append(" and pbdtype = '0' ")

            Dim params() As SqlParameter = {New SqlParameter("@StartDate", StartDate), New SqlParameter("@EndDate", EndDate)}

            Return Scalar(StrSQL.ToString(), params)
        End Function
    End Class
End Namespace
