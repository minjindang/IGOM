Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class CPAPKYYMMDAO
        Inherits BaseDAO
        Private tableName As String = ""

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            Me.tableName = tableName
        End Sub

        Public Sub New(ByVal tableName As String, ByVal conn As SqlConnection)
            MyBase.New(conn)
            Me.tableName = tableName
        End Sub

        Public Function CheckHasTable() As Integer
            Dim StrSQL As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES where table_name = @table_name"
            Dim param As SqlParameter = New SqlParameter("@table_name", SqlDbType.VarChar)
            param.Value = Me.tableName

            Return Scalar(StrSQL, param)
        End Function

        Public Function GetUnNoramlData(ByVal PKIDNO As String) As DataTable

            Dim StrSQL As String = "SELECT * FROM " & tableName & " WHERE PKIDNO=@PKIDNO AND PKWKTPE<>'5' AND PKWKTPE<>'6' AND PKWDATE<@NOW "
            Dim param() As SqlParameter = { _
            New SqlParameter("@PKIDNO", SqlDbType.VarChar), _
            New SqlParameter("@NOW", SqlDbType.VarChar)}
            param(0).Value = PKIDNO
            param(1).Value = DateTimeInfo.GetRocDate(Now)


            Return Query(StrSQL, param)
        End Function


        Public Function GetUnNoramlData(ByVal PKCARD As String, ByVal PKWDATE As String) As DataTable

            Dim StrSQL As String = "SELECT * FROM " & tableName & " WHERE PKCARD=@PKCARD AND PKWKTPE<>'5' AND PKWKTPE<>'6' AND PKWDATE=@PKWDATE "
            Dim param() As SqlParameter = { _
            New SqlParameter("@PKCARD", SqlDbType.VarChar), _
            New SqlParameter("@PKWDATE", SqlDbType.VarChar)}
            param(0).Value = PKCARD
            param(1).Value = PKWDATE


            Return Query(StrSQL, param)
        End Function

        Public Function GetDataByPKWDATE(ByVal PKIDNO As String, ByVal PKWDATE As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select * from " & tableName & " ")
            sql.AppendLine(" where  pkidno=@pkidno and pkwdate=@pkwdate ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@pkidno", SqlDbType.VarChar), _
            New SqlParameter("@pkwdate", SqlDbType.VarChar)}
            params(0).Value = PKIDNO
            params(1).Value = PKWDATE

            Return Query(sql.ToString, params)
        End Function

        Public Function DeleteData(ByVal PKIDNO As String, ByVal PKWDATE As String) As Integer
            Dim StrSQL As String = "DELETE FROM " & tableName & " WHERE PKIDNO=@PKIDNO AND PKWDATE=@PKWDATE"
            Dim params() As SqlParameter = {New SqlParameter("@PKCARD", SqlDbType.VarChar), _
                                            New SqlParameter("@PKWDATE", SqlDbType.VarChar)}
            params(0).Value = PKIDNO
            params(1).Value = PKWDATE

            Return Execute(StrSQL, params)
        End Function

        Public Function UpdateSTIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKSTIME As String, ByVal PKFORGET As String) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE " & tableName & " ")
            StrSQL.Append("     SET PKSTIME=@PKSTIME, PKFORGET=@PKFORGET ")
            StrSQL.Append("WHERE PKIDNO=@PKIDNO AND PKWDATE=@PKWDATE ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@PKIDNO", SqlDbType.VarChar)
            params(0).Value = PKIDNO
            params(1) = New SqlParameter("@PKWDATE", SqlDbType.VarChar)
            params(1).Value = PKWDATE
            params(2) = New SqlParameter("@PKSTIME", SqlDbType.VarChar)
            params(2).Value = PKSTIME
            params(3) = New SqlParameter("@PKFORGET", SqlDbType.VarChar)
            params(3).Value = PKFORGET

            Return Execute(StrSQL.ToString(), params)
        End Function

        Public Function UpdateETIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKETIME As String, ByVal PKFORGET As String) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE " & tableName & " ")
            StrSQL.Append("     SET PKETIME=@PKETIME, PKFORGET=@PKFORGET ")
            StrSQL.Append("WHERE PKIDNO=@PKIDNO AND PKWDATE=@PKWDATE ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@PKIDNO", SqlDbType.VarChar)
            params(0).Value = PKIDNO
            params(1) = New SqlParameter("@PKWDATE", SqlDbType.VarChar)
            params(1).Value = PKWDATE
            params(2) = New SqlParameter("@PKETIME", SqlDbType.VarChar)
            params(2).Value = PKETIME
            params(3) = New SqlParameter("@PKFORGET", SqlDbType.VarChar)
            params(3).Value = PKFORGET

            Return Execute(StrSQL.ToString(), params)
        End Function


        Public Function UpdateNTIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKNTIME As String, ByVal PKFORGET As String) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE " & tableName & " ")
            StrSQL.Append("     SET PKNTIME=@PKNTIME, PKFORGET=@PKFORGET ")
            StrSQL.Append("WHERE PKIDNO=@PKIDNO AND PKWDATE=@PKWDATE ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@PKIDNO", SqlDbType.VarChar)
            params(0).Value = PKIDNO
            params(1) = New SqlParameter("@PKWDATE", SqlDbType.VarChar)
            params(1).Value = PKWDATE
            params(2) = New SqlParameter("@PKNTIME", SqlDbType.VarChar)
            params(2).Value = PKNTIME
            params(3) = New SqlParameter("@PKFORGET", SqlDbType.VarChar)
            params(3).Value = PKFORGET

            Return Execute(StrSQL.ToString(), params)
        End Function

        Public Function GetCountByPKWDATE(ByVal PKWDATE As String, ByVal Card_type As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT COUNT(*) FROM " & tableName & " WHERE PKWDATE=@PKWDATE ")
            If Card_type = "1" Then
                StrSQL.Append("AND (PKSTIME='' OR PKSTIME IS NULL)")
            Else
                StrSQL.Append("AND (PKETIME='' OR PKETIME IS NULL)")
            End If
            Dim param As SqlParameter = New SqlParameter("@PKWDATE", SqlDbType.VarChar)
            param.Value = PKWDATE

            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetCountByPKWKTPE(ByVal PKCARD As String, ByVal PKWKTPE As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT COUNT(*) FROM " & tableName & " WHERE PKCARD=@PKCARD AND PKWKTPE=@PKWKTPE ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@PKCARD", SqlDbType.VarChar), _
            New SqlParameter("@PKWKTPE", SqlDbType.VarChar)}
            param(0).Value = PKCARD
            param(1).Value = PKWKTPE

            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetDataByPKIDNOandPKWDATE(ByVal PKIDNO As String, ByVal PKWDATE As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine("select * from " & tableName & " ")
            sql.AppendLine("where PKIDNO=@PKIDNO and PKWDATE=@PKWDATE ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PKIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PKWDATE", SqlDbType.VarChar)}
            params(0).Value = PKIDNO
            params(1).Value = PKWDATE

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace