Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text

Namespace FSC.Logic

    Public Class CPAPB02MDAO
        Inherits BaseDAO

        Public Sub New()
        End Sub

        Public Sub New(ByVal conn As String)
            MyBase.New(conn)
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            MyBase.New(conn)
        End Sub

        Function getPBDTypeByPBDDate(ByVal PBDDATE As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select PBDTYPE from FSC_CPAPB02M where PBDDATE = @PBDDATE ")
            sSQL.Append(" ORDER BY PBDTYPE ")
            Dim params() As SqlParameter = {New SqlParameter("@PBDDATE", PBDDATE)}
            Return Query(sSQL.ToString, params)
        End Function


        Function getWorkDays(ByVal yyymm As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select PBDTYPE from FSC_CPAPB02M where SUBSTRING(PBDDATE,1,5)=@yyymm and PBDTYPE='0' ")
            sSQL.Append(" ORDER BY PBDTYPE ")
            Dim params() As SqlParameter = {New SqlParameter("@yyymm", yyymm)}
            Return Query(sSQL.ToString, params)
        End Function

        Public Function GetDataByYYY(ByVal YYY As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM FSC_CPAPB02M WHERE PBDDATE like @YYY+'%' "
            Dim param As SqlParameter = New SqlParameter("@YYY", SqlDbType.VarChar)
            param.Value = YYY
            Return Query(sql, param)
        End Function

        Public Function GetDataByYYYMM(ByVal YYYMM As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM FSC_CPAPB02M WHERE PBDDATE like @YYYMM+'%' "
            Dim param As SqlParameter = New SqlParameter("@YYYMM", SqlDbType.VarChar)
            param.Value = YYYMM
            Return Query(sql, param)
        End Function

        Public Function GetDataByYYYMM(ByVal Orgcode As String, ByVal Depart_id As String, ByVal YYYMM As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM FSC_CPAPB02M WHERE PBDDATE like @YYYMM+'%' "
            If Not String.IsNullOrEmpty(Orgcode) AndAlso Orgcode <> "" Then
                sql += " and Orgcode=@Orgcode "
            End If
            If Not String.IsNullOrEmpty(Depart_id) AndAlso Depart_id <> "" Then
                sql += " and Depart_id=@Depart_id "
            End If

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@YYYMM", SqlDbType.VarChar)
            params(0).Value = YYYMM
            params(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(1).Value = Orgcode
            params(2) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(2).Value = Depart_id

            Return Query(sql, params)
        End Function

        Public Function GetOffDateByPBDDATE(ByVal Start_date As String, ByVal End_date As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT PBDDATE FROM FSC_CPAPB02M WHERE PBDTYPE=2 AND PBDDATE >= @Start_date AND PBDDATE <= @End_date")
            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            params(0).Value = Start_date
            params(1) = New SqlParameter("@End_date", SqlDbType.VarChar)
            params(1).Value = End_date

            DBUtil.SetParamsNull(params)
            Return Query(sSQL.ToString(), params)
        End Function

        Public Function GetDataByOccurDate(ByVal OccurDate As String, ByVal days As Integer, ByVal isworkday As Boolean) As DataTable

            Dim sql As New StringBuilder()
            sql.Append(" SELECT TOP ").Append(days).Append(" PBDDATE FROM FSC_CPAPB02M WHERE PBDDATE > @OccurDate ")

            If isworkday Then
                sql.Append(" AND PBDTYPE=0 ")
            End If

            sql.Append(" ORDER BY PBDDATE ")

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@OccurDate", SqlDbType.VarChar)
            params(0).Value = OccurDate

            DBUtil.SetParamsNull(params)
            Return Query(sql.ToString(), params)

        End Function

        Function getWorkDays(ByVal yyymm As String, ByVal quitDate As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select PBDTYPE from FSC_CPAPB02M where SUBSTRING(PBDDATE,1,5)=@yyymm and PBDTYPE='0' ")
            If Not String.IsNullOrEmpty(quitDate) Then
                sSQL.Append(" and PBDDATE < @quitDate ")
            End If
            sSQL.Append(" ORDER BY PBDTYPE ")
            Dim params() As SqlParameter = {New SqlParameter("@yyymm", yyymm), New SqlParameter("@quitDate", quitDate)}
            Return Query(sSQL.ToString, params)
        End Function

        Public Function GetDayByDate(ByVal Start_date As String, ByVal End_date As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT PBDDATE FROM FSC_CPAPB02M WHERE  PBDDATE >= @Start_date AND PBDDATE <= @End_date")
            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            params(0).Value = Start_date
            params(1) = New SqlParameter("@End_date", SqlDbType.VarChar)
            params(1).Value = End_date

            DBUtil.SetParamsNull(params)
            Return Query(sSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 查詢該員工的班表
        ''' </summary>
        ''' <param name="UserID"></param>
        ''' <param name="StartDate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByUserID(ByVal UserID As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT * FROM FSC_CPAPB02M WITH(NOLOCK) WHERE PBUSERID=@UserID and  PBDDATE >= @Start_date AND PBDDATE <= @End_date")
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            params(0).Value = StartDate
            params(1) = New SqlParameter("@End_date", SqlDbType.VarChar)
            params(1).Value = EndDate
            params(2) = New SqlParameter("@UserID", SqlDbType.VarChar)
            params(2).Value = UserID


            DBUtil.SetParamsNull(params)
            Return Query(sSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' for匯入年度行事曆，做批次更新
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Sub Batch_Insert(dt As DataTable)
            Dim sSQL As StringBuilder = New StringBuilder()

            sSQL.AppendLine("IF EXISTS(SELECT PBDDATE FROM FSC_CPAPB02M WITH(NOLOCK) WHERE PBDDATE = @PBDDATE)")
            sSQL.AppendLine("BEGIN")
            sSQL.AppendLine("   UPDATE [FSC_CPAPB02M]")
            sSQL.AppendLine("       SET [PBDTYPE] = @PBDTYPE")
            sSQL.AppendLine("           ,[PBDDESC] = @PBDDESC")
            sSQL.AppendLine("           ,[Change_userid] = @Change_userid")
            sSQL.AppendLine("           ,[Change_date] = @Change_date")
            sSQL.AppendLine("   WHERE PBDDATE = @PBDDATE and Orgcode=@Orgcode and Depart_id=@Depart_id ")
            sSQL.AppendLine("END")
            sSQL.AppendLine("ELSE")
            sSQL.AppendLine("BEGIN")
            sSQL.AppendLine("   INSERT INTO [FSC_CPAPB02M]")
            sSQL.AppendLine("       VALUES(@Orgcode,@Depart_id,@PBDDATE,@PBDWEEK,@PBDTYPE,@PBDDESC,@Change_userid,@Change_date)")
            sSQL.AppendLine("END")


            sSQL.AppendLine("if @@ERROR = 0")
            sSQL.AppendLine("   BEGIN")
            sSQL.AppendLine("      SET @RtnCode = 1")
            sSQL.AppendLine("   End")
            sSQL.AppendLine("Else")
            sSQL.AppendLine("   BEGIN")
            sSQL.AppendLine("      SET @RtnCode = 101")
            sSQL.AppendLine("   END")

            Dim ps() As SqlParameter = { _
                    New SqlParameter("@Orgcode", SqlDbType.VarChar, 10), _
                    New SqlParameter("@Depart_id", SqlDbType.VarChar, 6), _
                    New SqlParameter("@PBDDATE", SqlDbType.VarChar, 7), _
                    New SqlParameter("@PBDWEEK", SqlDbType.VarChar, 2), _
                    New SqlParameter("@PBDTYPE", SqlDbType.VarChar, 1), _
                    New SqlParameter("@PBDDESC", SqlDbType.VarChar, 40), _
                    New SqlParameter("@Change_userid", SqlDbType.VarChar, 10), _
                    New SqlParameter("@Change_date", SqlDbType.DateTime), _
                    New SqlParameter("@RtnCode", SqlDbType.Int, 4) _
                }

            ps(8).Direction = ParameterDirection.Output

            SqlBatch(dt, UpdateRowSource.OutputParameters, sSQL.ToString, ps)

        End Sub
    End Class
End Namespace

