Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_EDU_feeDtlDAO
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


            StrSQL.Append(" INSERT INTO SAL_EDU_feeDtl ( ")
            StrSQL.Append(" main_id,Child_id,Child_name,ChildBirth_date,School_type, ")
            StrSQL.Append(" School_name,File_att,Study_nos,StudyLimit_nos,Apply_amt, ")
            StrSQL.Append(" Org_code,ModUser_id,Mod_date, Att_id ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @main_id,@Child_id,@Child_name,@ChildBirth_date,@School_type, ")
            StrSQL.Append(" @School_name,@File_att,@Study_nos,@StudyLimit_nos,@Apply_amt, ")
            StrSQL.Append(" @Org_code,@ModUser_id,@Mod_date, @Att_id ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_EDU_feeDtl SET  ")
            StrSQL.Append(" main_id=@main_id,Child_id=@Child_id,Child_name=@Child_name,ChildBirth_date=@ChildBirth_date,School_type=@School_type, ")
            StrSQL.Append(" School_name=@School_name,File_att=@File_att,Study_nos=@Study_nos,StudyLimit_nos=@StudyLimit_nos,Apply_amt=@Apply_amt, ")
            StrSQL.Append(" Org_code=@Org_code,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Child_id,Child_name,ChildBirth_date,School_type, ")
            StrSQL.Append(" School_name,File_att,Study_nos,StudyLimit_nos,Apply_amt ")
            StrSQL.Append(" ,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_EDU_feeDtl  ")
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
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Child_id,Child_name,ChildBirth_date,School_type, ")
            StrSQL.Append(" School_name,File_att,Study_nos,StudyLimit_nos,Apply_amt ")
            StrSQL.Append(" ,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_EDU_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_EDU_feeDtl WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Sub DeleteByFlowId(ByVal flow_id As String)
            Dim sql As String = " delete from SAL_EDU_feeDtl WHERE main_id in (select id from SAL_EDU_fee where flow_id=@flow_id) "
            Dim ps() As SqlParameter = {New SqlParameter("@flow_id", flow_id)}

            Execute(sql, ps)
        End Sub
    End Class
End Namespace