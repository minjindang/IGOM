Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter


Namespace FSCPLM.Logic

    Public Class NoticePersonDAO
        '  '0980827 人立增加
        Dim ConnectionString As String = String.Empty
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Leave_type As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = " select  b.Id_card,b.User_name,Email from  Notice_person a inner join Member b"
            StrSQL += "  on a.Orgcode=b.Orgcode"
            StrSQL += "  and a.id_card=b.Id_card"
            StrSQL += " and  a.Leave_type=@Leave_type"
            StrSQL += " and  a.Orgcode=@Orgcode"


            Dim params() As SqlParameter = {New SqlParameter("@Leave_type", SqlDbType.VarChar), New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Leave_type
            params(1).Value = Orgcode

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function DeleteData(ByVal Orgcode As String, ByVal Leave_type As String) As Integer
            Dim StrSQL As String = String.Empty

            StrSQL = " delete from   Notice_person "
            StrSQL += " where Leave_type=@Leave_type"
            StrSQL += " and  Orgcode=@Orgcode"

            Dim params() As SqlParameter = {New SqlParameter("@Leave_type", SqlDbType.VarChar), New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Leave_type
            params(1).Value = Orgcode
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function DeleteData(ByVal Orgcode As String, ByVal Leave_type As String, ByVal id_card As String) As Integer
            Dim StrSQL As String = String.Empty

            StrSQL = " delete from   Notice_person "
            StrSQL += " where Leave_type=@Leave_type "
            StrSQL += " and id_card=@id_card "
            StrSQL += " and  Orgcode=@Orgcode"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Leave_type", SqlDbType.VarChar), _
            New SqlParameter("@id_card", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Leave_type
            params(1).Value = id_card
            params(2).Value = Orgcode

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function InsertData(ByVal Orgcode As String, ByVal Leave_type As String, _
                                  ByVal Id_card As String, ByVal change_userid As String, ByVal change_date As DateTime) As Integer
            Dim StrSQL As String = String.Empty

            StrSQL = " insert into  Notice_person(Orgcode,Leave_type,Id_card,change_userid, change_date) "
            StrSQL += " values (@Orgcode,@Leave_type,@Id_card,@change_userid, @change_date) "



            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                                            New SqlParameter("@Leave_type", SqlDbType.Int), _
                                            New SqlParameter("@Id_card", SqlDbType.VarChar), _
                                            New SqlParameter("@change_userid", SqlDbType.VarChar), _
                                            New SqlParameter("@change_date", SqlDbType.DateTime)}
            params(0).Value = Orgcode
            params(1).Value = Integer.Parse(Leave_type)
            params(2).Value = Id_card
            params(3).Value = change_userid
            params(4).Value = change_date

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function


    End Class
    'Orgcode                                            Leave_type  Id_card    change_userid change_date

End Namespace

