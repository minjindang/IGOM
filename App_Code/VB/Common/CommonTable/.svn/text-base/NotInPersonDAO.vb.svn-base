Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class NotInPersonDAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty
        Dim Connection As SqlConnection
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Sub New(ByVal connstr As String)
            Me.ConnectionString = connstr
        End Sub

        Public Function getDataByQuery(ByVal Orgcode As String, _
                                       ByVal Id_card As String, _
                                       ByVal sdate As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from Not_In_Person ")
            sql.AppendLine(" where Orgcode=@Orgcode ")
            sql.AppendLine(" and Id_card=@Id_card ")
            sql.AppendLine(" and Start_date<=@sdate ")
            sql.AppendLine(" and End_date>=@sdate ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@sdate", sdate)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetCountByNotInStime(ByVal Orgcode As String, ByVal Id_card As String, _
                            ByVal Not_in_date As String, ByVal Not_in_stime As String, _
                            ByVal Not_in_etime As String) As Object
            Dim SQL As New StringBuilder
            SQL.AppendLine("SELECT COUNT(*) FROM Not_In_Person WITH(NOLOCK) ")
            SQL.AppendLine("where ((Not_in_stime >= @Not_in_stime and Not_in_etime <= @Not_in_etime ) ")
            SQL.AppendLine("        or (Not_in_stime < @Not_in_etime and Not_in_etime > @Not_in_etime) ")
            SQL.AppendLine("        or (Not_in_stime < @Not_in_stime and Not_in_etime > @Not_in_stime)) ")
            SQL.AppendLine("        and Id_card=@Id_card AND Not_in_date=@Not_in_date ")
            SQL.AppendLine("        and Cancle_flag<>'Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Not_in_date", SqlDbType.VarChar), _
            New SqlParameter("@Not_in_stime", SqlDbType.VarChar), _
            New SqlParameter("@Not_in_etime", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card
            params(2).Value = Not_in_date
            params(3).Value = Not_in_stime
            params(4).Value = Not_in_etime

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteScalar(Me.Connection, CommandType.Text, SQL.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, SQL.ToString, params)
        End Function

        Public Function UpdateCancleFlag(ByVal Orgcode As String, ByVal Id As String) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE Not_In_Person SET Cancle_flag='Y',Change_userid=@Change_userid, Change_date= Getdate()  ")
            StrSQL.Append(" WHERE id=@id AND Orgcode=@Orgcode")
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@id", SqlDbType.VarChar)
            params(0).Value = Id
            params(1) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            params(1).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(2) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(2).Value = Orgcode
            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

    End Class

End Namespace