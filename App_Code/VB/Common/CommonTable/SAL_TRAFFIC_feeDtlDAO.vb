Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_TRAFFIC_feeDtlDAO
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


            StrSQL.Append(" INSERT INTO SAL_TRAFFIC_feeDtl ( ")
            StrSQL.Append(" main_id,Cost_date,Apply_amt,Apply_desc,Org_code, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @main_id,@Cost_date,@Apply_amt,@Apply_desc,@Org_code, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_TRAFFIC_feeDtl SET  ")
            StrSQL.Append(" main_id=@main_id,Cost_date=@Cost_date,Apply_amt=@Apply_amt,Apply_desc=@Apply_desc,Org_code=@Org_code, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Cost_date,Apply_amt,Apply_desc,Org_code ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_TRAFFIC_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Integer.MinValue <> main_id Then
                StrSQL.Append("  AND main_id=@main_id  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@main_id", main_id), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Cost_date,Apply_amt,Apply_desc,Org_code ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_TRAFFIC_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@id", id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_TRAFFIC_feeDtl WHERE  id=@id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@id", id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


        Public Function DeleteByMainId(mainId As Integer) As Integer
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_TRAFFIC_feeDtl WHERE  main_id=@mainId  ")
            Dim ps() As SqlParameter = {New SqlParameter("@mainId", mainId)}

            Return Execute(StrSQL.ToString(), ps)
        End Function

    End Class
End Namespace