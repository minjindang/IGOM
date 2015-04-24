Imports Microsoft.VisualBasic
Imports Pemis2009.SQLAdapter
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Imports System

Public Class BaseDAO

    Private _connstr As String = String.Empty
    Private _conn As SqlConnection
    Public Property connstr() As String
        Get
            Return _connstr
        End Get
        Set(ByVal value As String)
            _connstr = value
        End Set
    End Property
    Public Property conn() As SqlConnection
        Get
            Return _conn
        End Get
        Set(ByVal value As SqlConnection)
            _conn = value
        End Set
    End Property

    Public Sub New()
        _connstr = ConnectDB.GetDBString()
    End Sub

    Public Sub New(ByVal conn As SqlConnection)
        _conn = conn
    End Sub

    Public Sub New(ByVal conStr As String)
        _connstr = conStr
    End Sub


    Public Function InsertByExample(ByVal table_name As String, ByVal values As Dictionary(Of String, Object)) As Integer
        Dim sql As New StringBuilder()
        Dim params() As SqlParameter = Nothing

        sql.AppendLine("INSERT INTO ")
        sql.Append(table_name)
        sql.Append(" ( ")

        If Not IsNothing(values) AndAlso values.Keys.Count > 0 Then

            ReDim params(values.Keys.Count - 1)

            Dim keys As Dictionary(Of String, Object).KeyCollection = values.Keys

            Dim isFirstCondition As Boolean = True
            Dim count As Integer = 0

            For Each key As String In keys
                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sql.Append(", ")
                End If
                sql.Append(key)
            Next
            sql.Append(" ) ")
            sql.AppendLine(" VALUES ")
            sql.Append(" ( ")

            isFirstCondition = True
            For Each key As String In keys
                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sql.Append(", ")
                End If
                sql.Append("@" & key)

                params(count) = New SqlParameter("@" & key, GetSqlDbType(values(key)))
                params(count).Value = values(key)
                count += 1
            Next

            sql.Append(" ) ")

        End If

        Return Execute(sql.ToString(), params)
    End Function

    Public Function UpdateByExample(ByVal table_name As String, ByVal values As Dictionary(Of String, Object), ByVal condition As Dictionary(Of String, Object)) As Integer
        Dim sql As New StringBuilder()
        Dim params() As SqlParameter = Nothing

        sql.AppendLine("UPDATE ")
        sql.Append(table_name)
        sql.Append(" SET ")

        If Not IsNothing(values) AndAlso values.Keys.Count > 0 Then

            ReDim params(values.Keys.Count + condition.Keys.Count - 1)

            Dim keys As Dictionary(Of String, Object).KeyCollection = values.Keys

            Dim ckeys As Dictionary(Of String, Object).KeyCollection = condition.Keys

            Dim isFirstCondition As Boolean = True
            Dim count As Integer = 0

            For Each key As String In keys
                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sql.Append(", ")
                End If
                sql.Append(key & "=@" & key)

                params(count) = New SqlParameter("@" + key, GetSqlDbType(values(key)))
                params(count).Value = values(key)
                count += 1
            Next

            sql.AppendLine(" WHERE ")

            isFirstCondition = True
            For Each key As String In ckeys
                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sql.Append(" AND ")
                End If
                sql.Append(key & "=@" & key)

                params(count) = New SqlParameter("@" + key, GetSqlDbType(condition(key)))
                params(count).Value = condition(key)
                count += 1
            Next

        End If

        Return Execute(sql.ToString(), params)
    End Function

    Public Function DeleteByExample(ByVal table_name As String, ByVal condition As Dictionary(Of String, Object)) As Integer
        Dim sqlStr As New StringBuilder
        Dim params() As SqlParameter = Nothing

        sqlStr.Append(" DELETE ")
        sqlStr.Append(" FROM ")
        sqlStr.Append(table_name)

        If Not IsNothing(condition) AndAlso condition.Keys.Count > 0 Then
            sqlStr.AppendLine(" WHERE ")

            ReDim params(condition.Keys.Count - 1)

            Dim keys As Dictionary(Of String, Object).KeyCollection = condition.Keys

            Dim isFirstCondition As Boolean = True
            Dim count As Integer = 0

            For Each key As String In keys

                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sqlStr.Append(" AND ")
                End If

                sqlStr.Append(" ")
                sqlStr.Append(key)
                sqlStr.Append(" = @")
                sqlStr.Append(key)
                sqlStr.Append(" ")
                params(count) = New SqlParameter("@" + key, GetSqlDbType(condition(key)))
                params(count).Value = condition(key)
                count += 1
            Next

        End If

        Return Execute(sqlStr.ToString, params)
    End Function

    Public Function GetDataByExample(ByVal table_name As String, ByVal condition As Dictionary(Of String, Object)) As DataTable
        Dim sqlStr As New StringBuilder
        Dim params() As SqlParameter = Nothing

        sqlStr.Append(" SELECT * ")
        sqlStr.Append(" FROM ")
        sqlStr.Append(table_name)

        If Not IsNothing(condition) AndAlso condition.Keys.Count > 0 Then
            sqlStr.AppendLine(" WHERE ")

            ReDim params(condition.Keys.Count - 1)

            Dim keys As Dictionary(Of String, Object).KeyCollection = condition.Keys

            Dim isFirstCondition As Boolean = True
            Dim count As Integer = 0

            For Each key As String In keys

                If isFirstCondition Then
                    isFirstCondition = False
                Else
                    sqlStr.Append(" AND ")
                End If

                sqlStr.Append(" ")
                sqlStr.Append(key)
                sqlStr.Append(" = @")
                sqlStr.Append(key)
                sqlStr.Append(" ")
                params(count) = New SqlParameter("@" + key, GetSqlDbType(condition(key)))
                params(count).Value = condition(key)
                count += 1
            Next

        End If

        Return Query(sqlStr.ToString, params)
    End Function

    Private Function GetSqlDbType(ByVal value As Object) As SqlDbType
        If value Is Nothing Then
            Return SqlDbType.VarChar
        ElseIf value.GetType.Equals(GetType(Date)) Then
            Return SqlDbType.DateTime
        ElseIf value.GetType.Equals(GetType(Integer)) Then
            Return SqlDbType.Int
        Else
            Return SqlDbType.VarChar
        End If
    End Function


    Function Query(ByVal sSQL As String) As DataTable
        Try
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteDataset(_connstr, CommandType.Text, sSQL).Tables(0)
            Else
                Return SqlAccessHelper.ExecuteDataset(_conn, CommandType.Text, sSQL).Tables(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function Query(ByVal sSQL As String, ByVal ParamArray parms As SqlParameter()) As DataTable
        Try
            DBUtil.SetParamsNull(parms)
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteDataset(_connstr, CommandType.Text, sSQL, parms).Tables(0)
            Else
                Return SqlAccessHelper.ExecuteDataset(_conn, CommandType.Text, sSQL, parms).Tables(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function Scalar(ByVal sSQL As String, ByVal ParamArray parms As SqlParameter()) As Object
        Try
            DBUtil.SetParamsNull(parms)
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteScalar(_connstr, CommandType.Text, sSQL, parms)
            Else
                Return SqlAccessHelper.ExecuteScalar(_conn, CommandType.Text, sSQL, parms)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function Execute(ByVal sSQL As String, ByVal ParamArray parms As SqlParameter()) As Integer
        Try
            DBUtil.SetParamsNull(parms)
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteNonQuery(_connstr, CommandType.Text, sSQL, parms)
            Else
                Return SqlAccessHelper.ExecuteNonQuery(_conn, CommandType.Text, sSQL, parms)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 資料有問題時，需要刪除tmp資料表
    ''' </summary>
    ''' <param name="sSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DelTmpSchedule(ByVal sSQL As String) As Boolean
        Try
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteNonQuery(_connstr, CommandType.Text, sSQL, Nothing)
            Else
                Return SqlAccessHelper.ExecuteNonQuery(_conn, CommandType.Text, sSQL, Nothing)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 將tmp排班資料表的資料，匯入真正的排班資料表 by jessica add 20131213
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertToSchedule_setting(ByVal sSQL As String) As Boolean
        Try
            If IsNothing(_conn) Then
                Return SqlAccessHelper.ExecuteNonQuery(_connstr, CommandType.Text, sSQL, Nothing)
            Else
                Return SqlAccessHelper.ExecuteNonQuery(_conn, CommandType.Text, sSQL, Nothing)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Sql 批次更新 by jessica add 20131213
    ''' </summary>
    ''' <param name="dt">DataTable 與 StoredProcedure 參數相符的欄位</param>
    ''' <param name="uRowSourceType"></param>
    Public Sub SqlBatch(dt As DataTable, uRowSourceType As UpdateRowSource, ByVal sSQL As String, ByVal ParamArray CmdParameters As SqlParameter())
        Dim cn As New SqlConnection(connstr)

        Try
            '必須先指定SqlParameter的SourceColumn 與 DataTable 的欄位名稱對應
            For i As Integer = 0 To CmdParameters.Length - 1
                If String.IsNullOrEmpty(CmdParameters(i).SourceColumn) Then
                    CmdParameters(i).SourceColumn = dt.Columns(i).ColumnName
                End If
            Next

            cn.Open()
            Using cmd As New SqlCommand(sSQL, cn)
                cmd.CommandType = CommandType.Text

                For Each parameter As SqlParameter In CmdParameters
                    cmd.Parameters.Add(parameter)
                Next

                For i As Integer = 0 To cmd.Parameters.Count - 1
                    cmd.Parameters(i).Direction = CmdParameters(i).Direction
                Next

                cmd.UpdatedRowSource = uRowSourceType

                Using adapter As New SqlDataAdapter()
                    adapter.InsertCommand = cmd
                    adapter.UpdateCommand = cmd
                    adapter.UpdateBatchSize = dt.Rows.Count

                    adapter.Update(dt)

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

End Class
