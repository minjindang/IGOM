Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class BulletinDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetDataByToday(ByVal Orgcode As String, ByVal Bulletin_date As String) As DataSet
            Dim sql As New StringBuilder
            sql.Append("SELECT  * FROM Bulletin WHERE Orgcode=@Orgcode AND Bulletin_date>=@Bulletin_date AND Bulletin_flag='Y' ORDER BY Bulletin_seq")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_date", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Bulletin_date

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByFlag(ByVal Orgcode As String, ByVal Bulletin_flag As String) As DataSet

            Dim sql As New StringBuilder
            sql.Append("SELECT  * FROM Bulletin WHERE Orgcode=@Orgcode AND Bulletin_flag=@Bulletin_flag ORDER BY Bulletin_seq ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_flag", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Bulletin_flag

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Bulletin_date_s As String, ByVal Bulletin_date_e As String, ByVal Bulletin_flag As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT CONVERT(varchar(10),b.Bulletin_date,111) AS Bulletin_date, b.*, m.User_name "
            StrSQL &= "FROM Bulletin b INNER JOIN Member m ON b.Orgcode=m.Orgcode AND b.Bulletin_userid=m.ID_card WHERE b.Orgcode=@Orgcode AND "

            If Not String.IsNullOrEmpty(Bulletin_date_s) Then
                StrSQL &= "Bulletin_date>=@Bulletin_date_s AND "
            End If
            If Not String.IsNullOrEmpty(Bulletin_date_e) Then
                StrSQL &= "Bulletin_date<=@Bulletin_date_e AND "
            End If
            If Not String.IsNullOrEmpty(Bulletin_flag) Then
                StrSQL &= "Bulletin_flag=@Bulletin_flag AND "
            End If
            StrSQL &= "1=1 ORDER BY Bulletin_seq, Bulletin_date DESC"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_date_s", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_date_e", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_flag", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Bulletin_date_s
            params(2).Value = Bulletin_date_e
            params(3).Value = Bulletin_flag

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function GetDataBySerialNos(ByVal Serial_nos As Integer) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT * FROM Bulletin WHERE Serial_nos=@Serial_nos "
            Dim param As SqlParameter = New SqlParameter("@Serial_nos", SqlDbType.Int)
            param.Value = Serial_nos

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function


        Public Function InsertData(ByVal Orgcode As String, ByVal Bulletin_userid As String, ByVal Bulletin_content As String, ByVal Bulletin_date As String, ByVal Change_userid As String) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO Bulletin "
            StrSQL &= "(Orgcode, Bulletin_userid, Bulletin_content, Bulletin_date, Bulletin_flag, Change_userid, Change_date) "
            StrSQL &= "VALUES "
            StrSQL &= "(@Orgcode, @Bulletin_userid, @Bulletin_content, @Bulletin_date, 'N', @Change_userid, Getdate())"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_userid", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_content", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_date", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Bulletin_userid
            params(2).Value = Bulletin_content
            params(3).Value = Bulletin_date
            params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function UpdateData(ByVal Orgcode As String, ByVal Bulletin_userid As String, ByVal Bulletin_content As String, ByVal Bulletin_date As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Integer
            Dim StrSQL As String = String.Empty

            StrSQL = "UPDATE Bulletin SET " & _
                     "Orgcode=@Orgcode, Bulletin_userid=@Bulletin_userid, Bulletin_date=@Bulletin_date, Bulletin_content=@Bulletin_content, " & _
                     "Change_userid=@Change_userid, Change_date = Getdate() "
            StrSQL &= "WHERE Serial_nos=@Serial_nos "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_userid", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_date", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_content", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar), _
            New SqlParameter("@Serial_nos", SqlDbType.Int)}
            params(0).Value = Orgcode
            params(1).Value = Bulletin_userid
            params(2).Value = Bulletin_date
            params(3).Value = Bulletin_content
            params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            params(5).Value = Serial_nos

            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function DeleteData(ByVal Serial_nos As Integer) As String
            Dim StrSQL As String = "DELETE FROM Bulletin WHERE Serial_nos = @Serial_nos"
            Dim param As SqlParameter = New SqlParameter("@Serial_nos", SqlDbType.Int)
            param.Value = Serial_nos
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function


        Public Function UpdateDataFlag(ByVal Bulletin_flag As String, ByVal Serial_nos As Integer, ByVal Bulletin_seq As Integer) As String
            Dim StrSQL As String = "UPDATE Bulletin SET Bulletin_flag=@Bulletin_flag, Bulletin_seq=@Bulletin_seq WHERE Serial_nos=@Serial_nos"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Bulletin_flag", SqlDbType.VarChar), _
            New SqlParameter("@Bulletin_seq", SqlDbType.VarChar), _
            New SqlParameter("@Serial_nos", SqlDbType.Int)}
            params(0).Value = Bulletin_flag
            params(1).Value = Bulletin_seq
            params(2).Value = Serial_nos
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function
    End Class
End Namespace