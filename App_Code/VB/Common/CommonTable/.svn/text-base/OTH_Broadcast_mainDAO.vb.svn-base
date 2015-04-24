Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class OTH_Broadcast_mainDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO OTH_Broadcast_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,broadcast_date1, ")
            StrSQL.Append(" broadcast_time1,broadcast_date2,broadcast_time2,broadcast_floors,broadcast_content, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@User_id,@User_unit,@broadcast_date1, ")
            StrSQL.Append(" @broadcast_time1,@broadcast_date2,@broadcast_time2,@broadcast_floors,@broadcast_content, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE OTH_Broadcast_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,User_id=@User_id,User_unit=@User_unit,broadcast_date1=@broadcast_date1, ")
            StrSQL.Append(" broadcast_time1=@broadcast_time1,broadcast_date2=@broadcast_date2,broadcast_time2=@broadcast_time2,broadcast_floors=@broadcast_floors,broadcast_content=@broadcast_content, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,broadcast_date1, ")
            StrSQL.Append(" broadcast_time1,broadcast_date2,broadcast_time2,broadcast_floors,broadcast_content ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM OTH_Broadcast_main  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,broadcast_date1, ")
            StrSQL.Append(" broadcast_time1,broadcast_date2,broadcast_time2,broadcast_floors,broadcast_content ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM OTH_Broadcast_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Flow_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM OTH_Broadcast_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace