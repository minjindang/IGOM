Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL4108DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="stan_type"></param>
        ''' <param name="stan_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal stan_type As String, ByVal stan_no As String) As DataTable
            Dim sbSQL As New StringBuilder()

            sbSQL.AppendLine(" SELECT stan_ym,(cast(cast(substring(stan_ym,1,4) AS INT) - 1911 AS VARCHAR) + ' 年 ' + substring(stan_ym,5,2) + ' 月') AS ymstr ")
            sbSQL.AppendLine(" FROM SAL_SASTAN ")
            sbSQL.AppendLine("WHERE 1=1 ")

            If Not String.IsNullOrEmpty(stan_type) Then
                sbSQL.AppendLine("AND stan_type=@stan_type ")
            End If

            If Not String.IsNullOrEmpty(stan_no) Then
                sbSQL.AppendLine("AND stan_no=@stan_no ")
            End If

            sbSQL.AppendLine(" GROUP BY stan_ym ")
            sbSQL.AppendLine(" ORDER BY stan_ym DESC ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@stan_type", stan_type), _
            New SqlParameter("@stan_no", stan_no)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="stan_ym"></param>
        ''' <param name="stan_type"></param>
        ''' <param name="stan_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal stan_ym As String, ByVal stan_type As String, ByVal stan_no As String) As DataTable
            Dim sbSQL As New StringBuilder()

            sbSQL.AppendLine(" SELECT * FROM SAL_SASTAN ")
            sbSQL.AppendLine("WHERE 1=1 ")

            If Not String.IsNullOrEmpty(stan_ym) Then
                sbSQL.AppendLine("AND stan_ym=@stan_ym ")
            End If

            If Not String.IsNullOrEmpty(stan_type) Then
                sbSQL.AppendLine("AND stan_type=@stan_type ")
            End If

            If Not String.IsNullOrEmpty(stan_no) Then
                sbSQL.AppendLine("AND stan_no=@stan_no ")
            End If

            sbSQL.AppendLine(" ORDER BY CAST(stan_sal AS INT)  ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@stan_ym", stan_ym), _
            New SqlParameter("@stan_type", stan_type), _
            New SqlParameter("@stan_no", stan_no)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal Stan_Sal_Point As String) As DataTable
            Dim sbSQL As New StringBuilder()

            sbSQL.AppendLine(" SELECT (cast(cast(substring(stan_ym,1,4) AS INT) - 1911 AS VARCHAR) + ' 年 ' + substring(stan_ym,5,2) + ' 月') AS ymstr,SYS_CODE.CODE_DESC1,* ")
            sbSQL.AppendLine(" FROM SAL_SASTAN LEFT JOIN SYS_CODE ON SAL_SASTAN.stan_no=SYS_CODE.CODE_NO ")
            sbSQL.AppendLine(" WHERE SYS_CODE.CODE_SYS='001' AND SYS_CODE.CODE_TYPE='001' ")

            If Not String.IsNullOrEmpty(STAN_YM) Then
                sbSQL.AppendLine("AND STAN_YM=@STAN_YM ")
            End If
            If Not String.IsNullOrEmpty(STAN_TYPE) Then
                sbSQL.AppendLine("AND STAN_TYPE=@STAN_TYPE ")
            End If
            If Not String.IsNullOrEmpty(STAN_NO) Then
                sbSQL.AppendLine("AND STAN_NO=@STAN_NO ")
            End If
            If Not String.IsNullOrEmpty(Stan_Sal_Point) Then
                sbSQL.AppendLine("AND Stan_Sal_Point=@Stan_Sal_Point ")
            End If
            Dim param() As SqlParameter = { _
            New SqlParameter("@STAN_YM", STAN_YM), _
          New SqlParameter("@STAN_TYPE", STAN_TYPE), _
          New SqlParameter("@STAN_NO", STAN_NO), _
          New SqlParameter("@Stan_Sal_Point", Stan_Sal_Point)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 修改資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <param name="Stan_Sal"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Update(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal Stan_Sal_Point As String, ByVal Stan_Sal As String, ByVal STAN_MUSER As String, ByVal STAN_MDATE As String) As Integer
            Dim StrSQL As New StringBuilder()

            StrSQL.Append(" UPDATE SAL_SASTAN   ")
            StrSQL.Append(" SET Stan_Sal=@Stan_Sal,STAN_MUSER=@STAN_MUSER,STAN_MDATE=@STAN_MDATE ")
            StrSQL.Append(" WHERE STAN_YM=@STAN_YM  and STAN_TYPE =@STAN_TYPE and STAN_NO=@STAN_NO and Stan_Sal_Point=@Stan_Sal_Point ")

            Dim param() As SqlParameter = { _
                New SqlParameter("@STAN_MUSER", STAN_MUSER), _
                New SqlParameter("@STAN_MDATE", STAN_MDATE), _
                New SqlParameter("@STAN_YM", STAN_YM), _
                  New SqlParameter("@STAN_TYPE", STAN_TYPE), _
                  New SqlParameter("@STAN_NO", STAN_NO), _
                  New SqlParameter("@Stan_Sal_Point", Stan_Sal_Point), _
                New SqlParameter("@Stan_Sal", Stan_Sal)}

            Return Execute(StrSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 新增資料
        ''' </summary>
        ''' <param name="STAN_YM"></param>
        ''' <param name="STAN_TYPE"></param>
        ''' <param name="STAN_NO"></param>
        ''' <param name="STAN_SAL_POINT"></param>
        ''' <param name="STAN_SAL"></param>
        ''' <param name="STAN_MUSER"></param>
        ''' <param name="STAN_MDATE"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Insert(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal STAN_SAL_POINT As String, ByVal STAN_SAL As String, ByVal STAN_MUSER As String, ByVal STAN_MDATE As String) As Integer
            Dim StrSQL As New StringBuilder()

            StrSQL.Append(" INSERT INTO SAL_SASTAN   ")
            StrSQL.Append(" (STAN_YM,STAN_TYPE,STAN_NO,STAN_SAL_POINT,STAN_SAL,STAN_MUSER,STAN_MDATE) ")
            StrSQL.Append(" VALUES  ")
            StrSQL.Append(" (  ")
            StrSQL.Append(" @STAN_YM, @STAN_TYPE, @STAN_NO, @STAN_SAL_POINT, @Stan_Sal, @STAN_MUSER, @STAN_MDATE")
            StrSQL.Append(" )  ")

            Dim param() As SqlParameter = { _
                New SqlParameter("@STAN_YM", STAN_YM), _
                New SqlParameter("@STAN_TYPE", STAN_TYPE), _
                New SqlParameter("@STAN_NO", STAN_NO), _
                New SqlParameter("@STAN_SAL_POINT", STAN_SAL_POINT), _
                New SqlParameter("@STAN_SAL", STAN_SAL), _
                New SqlParameter("@STAN_MUSER", STAN_MUSER), _
                New SqlParameter("@STAN_MDATE", STAN_MDATE)}

            Return Execute(StrSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 刪除資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Delete(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal STAN_SAL_POINT As String) As Integer
            Dim StrSQL As New StringBuilder()

            StrSQL.Append(" DELETE SAL_SASTAN   ")
            StrSQL.Append(" WHERE STAN_YM=@STAN_YM  and STAN_TYPE =@STAN_TYPE and STAN_NO=@STAN_NO and Stan_Sal_Point=@Stan_Sal_Point  ")

            Dim param() As SqlParameter = { _
                New SqlParameter("@STAN_YM", STAN_YM), _
                New SqlParameter("@STAN_TYPE", STAN_TYPE), _
                New SqlParameter("@STAN_NO", STAN_NO), _
                New SqlParameter("@STAN_SAL_POINT", STAN_SAL_POINT)}

            Return Execute(StrSQL.ToString(), param)
        End Function
    End Class
End Namespace
