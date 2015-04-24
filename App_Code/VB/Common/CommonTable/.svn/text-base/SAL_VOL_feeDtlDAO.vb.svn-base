Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_VOL_feeDtlDAO
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


            StrSQL.Append(" INSERT INTO SAL_VOL_feeDtl ( ")
            StrSQL.Append(" main_id,vol_user_id,Apply_amt,Org_code,ModUser_id, ")
            StrSQL.Append(" Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @main_id,@vol_user_id,@Apply_amt,@Org_code,@ModUser_id, ")
            StrSQL.Append(" @Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_VOL_feeDtl SET  ")
            StrSQL.Append(" main_id=@main_id,vol_user_id=@vol_user_id,Apply_amt=@Apply_amt,Org_code=@Org_code,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,vol_user_id,Apply_amt,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_VOL_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")

            If main_id <> Integer.MinValue Then
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
            StrSQL.Append(" main_id,vol_user_id,Apply_amt,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_VOL_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@id", id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_VOL_feeDtl WHERE  id=@id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@id", id)}

            Execute(StrSQL.ToString(), ps)
        End Sub
        '1030528_Ray
        Public Function getDataByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select c.BASE_SEQNO, c.BASE_NAME, a.*, b.* from SAL_VOL_fee AS a ")
            sql.AppendLine(" INNER JOIN SAL_VOL_feeDtl AS b ON a.Id=b.main_id ")
            sql.AppendLine(" INNER JOIN SAL_SABASE AS c ON c.BASE_SEQNO= b.vol_user_id WHERE a.org_code=@Orgcode and a.Flow_id=@Flow_id ")
            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id

            Return Query(sql.ToString(), params)
        End Function
        '1030619 DeleteAfterModify
        Public Sub DeleteAfterModify(idcard As String, mainid As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_VOL_feeDtl WHERE  vol_user_id=@idcard  AND main_id=@mainid")
            Dim ps() As SqlParameter = { _
            New SqlParameter("@idcard", idcard), _
            New SqlParameter("@mainid", mainid)}

            Execute(StrSQL.ToString(), ps)
        End Sub
        Public Sub RemoveMainId(mainid As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_VOL_feeDtl WHERE  main_id=@mainid  ")
            Dim ps() As SqlParameter = {New SqlParameter("@mainid", mainid)}

            Execute(StrSQL.ToString(), ps)
        End Sub
    End Class
End Namespace