Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Public Class UnusualnotifyDAO
    Dim con As String

    Public Sub New()
        con = ConnectDB.GetDBString
    End Sub

    Public Function InsertData(ByVal orgcode As String, ByVal id_card As String, ByVal notice_date As String, ByVal notice_flag As String) As Integer
        Dim sql As New StringBuilder

        sql.AppendLine(" insert into Unusual_notify ")
        sql.AppendLine(" (orgcode, id_card, notice_date, notice_flag, builddate, builduser) ")
        sql.AppendLine(" values ")
        sql.AppendLine(" (@orgcode, @id_card, @notice_date, @notice_flag, getdate(), @builduser) ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@orgcode", SqlDbType.VarChar), _
        New SqlParameter("@id_card", SqlDbType.VarChar), _
        New SqlParameter("@notice_date", SqlDbType.VarChar), _
        New SqlParameter("@notice_flag", SqlDbType.VarChar), _
        New SqlParameter("@builduser", SqlDbType.VarChar)}

        params(0).Value = orgcode
        params(1).Value = id_card
        params(2).Value = notice_date
        params(3).Value = notice_flag
        params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        Return SqlAccessHelper.ExecuteNonQuery(Me.con, CommandType.Text, sql.ToString(), params)
    End Function

    Public Function GetData(ByVal orgcode As String, ByVal id_card As String, ByVal notice_date As String) As DataSet
        Dim sql As New StringBuilder
        sql.AppendLine(" select * from Unusual_notify ")
        sql.AppendLine(" where ")
        sql.AppendLine(" orgcode=@orgcode and id_card=@id_card and notice_date=@notice_date ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@orgcode", SqlDbType.VarChar), _
        New SqlParameter("@id_card", SqlDbType.VarChar), _
        New SqlParameter("@notice_date", SqlDbType.VarChar)}

        params(0).Value = orgcode
        params(1).Value = id_card
        params(2).Value = notice_date

        Return SqlAccessHelper.ExecuteDataset(Me.con, CommandType.Text, sql.ToString(), params)
    End Function
End Class
