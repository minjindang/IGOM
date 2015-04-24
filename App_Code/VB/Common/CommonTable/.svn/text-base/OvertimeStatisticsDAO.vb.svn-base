Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Public Class OvertimeStatisticsDAO
    Dim ConnectionString As String = String.Empty

    Public Sub New()
        Me.ConnectionString = ConnectDB.GetDBString()
    End Sub

    Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Overtime_YM As String) As DataSet
        Dim sql As New StringBuilder
        sql.Append(" SELECT * ")
        sql.Append(" FROM  ")
        sql.Append("  Overtime_Statistics   ")
        sql.Append(" WHERE  ")
        sql.Append("  Orgcode = @Orgcode ")
        sql.Append("  AND Depart_id = @Depart_id ")
        sql.Append("  AND Id_card = @Id_card ")
        sql.Append("  AND Overtime_YM = @Overtime_YM ")
        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Depart_id", SqlDbType.VarChar), _
        New SqlParameter("@Id_card", SqlDbType.VarChar), _
        New SqlParameter("@Overtime_YM", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        params(1).Value = Depart_id
        params(2).Value = Id_card
        params(3).Value = Overtime_YM
        Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
    End Function


    Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Overtime_YM As String, _
                                ByVal Normal As Integer, ByVal Project As Integer, ByVal Normal_Paid As Integer, ByVal Project_Paid As Integer, _
                                ByVal Normal_Rest As Integer, ByVal Project_Rest As Integer, ByVal Normal_Fee As Integer, ByVal Project_Fee As Integer, _
                                ByVal create_date As Date, ByVal update_date As Date, ByVal create_userid As String, ByVal update_userid As String) As Integer
        Dim SqlConn As SqlConnection = New SqlConnection()
        Dim SqlCmd As New SqlCommand()
        Dim sql As New StringBuilder
        Dim rowaffact As Integer = 0

        SqlConn.ConnectionString = Me.ConnectionString.Trim()
        SqlCmd.Connection = SqlConn

        sql.Append(" INSERT INTO Overtime_Statistics  ")
        sql.Append(" (     ")
        sql.Append("   Orgcode, ")
        sql.Append("   Depart_id, ")
        sql.Append("   Id_card, ")
        sql.Append("   Overtime_YM, ")
        sql.Append("   Normal, ")
        sql.Append("   Project, ")
        sql.Append("   Normal_Paid, ")
        sql.Append("   Project_Paid, ")
        sql.Append("   Normal_Rest, ")
        sql.Append("   Project_Rest, ")
        sql.Append("   Normal_Fee, ")
        sql.Append("   Project_Fee, ")
        sql.Append("   create_date, ")
        sql.Append("   update_date, ")
        sql.Append("   create_userid, ")
        sql.Append("   update_userid ")
        sql.Append(" )   ")
        sql.Append(" VALUES ")
        sql.Append(" (   ")
        sql.Append("   @Orgcode, ")
        sql.Append("   @Depart_id, ")
        sql.Append("   @Id_card, ")
        sql.Append("   @Overtime_YM, ")
        sql.Append("   @Normal, ")
        sql.Append("   @Project, ")
        sql.Append("   @Normal_Paid, ")
        sql.Append("   @Project_Paid, ")
        sql.Append("   @Normal_Rest, ")
        sql.Append("   @Project_Rest, ")
        sql.Append("   @Normal_Fee, ")
        sql.Append("   @Project_Fee, ")
        sql.Append("   @create_date, ")
        sql.Append("   @update_date, ")
        sql.Append("   @create_userid, ")
        sql.Append("   @update_userid ")
        sql.Append(" )  ")

        SqlCmd.Parameters.AddWithValue("@Orgcode", Orgcode)
        SqlCmd.Parameters.AddWithValue("@Depart_id", Depart_id)
        SqlCmd.Parameters.AddWithValue("@Id_card", Id_card)
        SqlCmd.Parameters.AddWithValue("@Overtime_YM", Overtime_YM)
        SqlCmd.Parameters.AddWithValue("@Normal", Normal)
        SqlCmd.Parameters.AddWithValue("@Project", Project)
        SqlCmd.Parameters.AddWithValue("@Normal_Paid", Normal_Paid)
        SqlCmd.Parameters.AddWithValue("@Project_Paid", Project_Paid)
        SqlCmd.Parameters.AddWithValue("@Normal_Rest", Normal_Rest)
        SqlCmd.Parameters.AddWithValue("@Project_Rest", Project_Rest)
        SqlCmd.Parameters.AddWithValue("@Normal_Fee", Normal_Fee)
        SqlCmd.Parameters.AddWithValue("@Project_Fee", Project_Fee)
        SqlCmd.Parameters.AddWithValue("@create_date", create_date)
        SqlCmd.Parameters.AddWithValue("@update_date", update_date)
        SqlCmd.Parameters.AddWithValue("@create_userid", create_userid)
        SqlCmd.Parameters.AddWithValue("@update_userid", update_userid)

        Try
            Using (SqlCmd)
                If SqlCmd.Connection.State = ConnectionState.Closed Then
                    SqlCmd.Connection.Open()
                End If

                SqlCmd.CommandText = sql.ToString
                SqlCmd.CommandType = CommandType.Text
                rowaffact = SqlCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Return -1
        Finally
            SqlCmd.Connection.Close()
        End Try
        Return rowaffact
    End Function

    Public Function UpdateData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Overtime_YM As String, _
                                ByVal Normal As Integer, ByVal Project As Integer, ByVal Normal_Paid As Integer, ByVal Project_Paid As Integer, _
                                ByVal Normal_Rest As Integer, ByVal Project_Rest As Integer, ByVal Normal_Fee As Integer, ByVal Project_Fee As Integer, _
                                ByVal update_date As Date, ByVal update_userid As String) As Integer

        Dim SqlConn As SqlConnection = New SqlConnection()
        Dim SqlCmd As New SqlCommand()
        Dim sql As New StringBuilder
        Dim rowaffact As Integer = 0

        SqlConn.ConnectionString = Me.ConnectionString.Trim()
        SqlCmd.Connection = SqlConn

        sql.Append(" UPDATE Overtime_Statistics  ")
        sql.Append(" SET ")
        sql.Append("   Normal = @Normal, ")
        sql.Append("   Project = @Project, ")
        sql.Append("   Normal_Paid = @Normal_Paid, ")
        sql.Append("   Project_Paid = @Project_Paid, ")
        sql.Append("   Normal_Rest = @Normal_Rest, ")
        sql.Append("   Project_Rest = @Project_Rest, ")
        sql.Append("   Normal_Fee = @Normal_Fee, ")
        sql.Append("   Project_Fee = @Project_Fee, ")
        sql.Append("   update_date = @update_date, ")
        sql.Append("   update_userid = @update_userid ")
        sql.Append(" WHERE  ")
        sql.Append("  Orgcode = @Orgcode ")
        sql.Append("  AND Depart_id = @Depart_id ")
        sql.Append("  AND Id_card = @Id_card ")
        sql.Append("  AND Overtime_YM = @Overtime_YM ")

        SqlCmd.Parameters.AddWithValue("@Normal", Normal)
        SqlCmd.Parameters.AddWithValue("@Project", Project)
        SqlCmd.Parameters.AddWithValue("@Normal_Paid", Normal_Paid)
        SqlCmd.Parameters.AddWithValue("@Project_Paid", Project_Paid)
        SqlCmd.Parameters.AddWithValue("@Normal_Rest", Normal_Rest)
        SqlCmd.Parameters.AddWithValue("@Project_Rest", Project_Rest)
        SqlCmd.Parameters.AddWithValue("@Normal_Fee", Normal_Fee)
        SqlCmd.Parameters.AddWithValue("@Project_Fee", Project_Fee)
        SqlCmd.Parameters.AddWithValue("@update_date", update_date)
        SqlCmd.Parameters.AddWithValue("@update_userid", update_userid)
        SqlCmd.Parameters.AddWithValue("@Orgcode", Orgcode)
        SqlCmd.Parameters.AddWithValue("@Depart_id", Depart_id)
        SqlCmd.Parameters.AddWithValue("@Id_card", Id_card)
        SqlCmd.Parameters.AddWithValue("@Overtime_YM", Overtime_YM)

        Try
            Using (SqlCmd)
                If SqlCmd.Connection.State = ConnectionState.Closed Then
                    SqlCmd.Connection.Open()
                End If

                SqlCmd.CommandText = sql.ToString
                SqlCmd.CommandType = CommandType.Text
                rowaffact = SqlCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Return -1
        Finally
            SqlCmd.Connection.Close()
        End Try
        Return rowaffact
    End Function
End Class


