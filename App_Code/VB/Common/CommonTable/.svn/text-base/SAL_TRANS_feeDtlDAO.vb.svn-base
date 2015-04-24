Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_TRANS_feeDtlDAO
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


            StrSQL.Append(" INSERT INTO SAL_TRANS_feeDtl ( ")
            StrSQL.Append(" main_id,Apply_amt,Non_id,Org_code,ModUser_id, ")
            StrSQL.Append(" Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @main_id,@Apply_amt,@Non_id,@Org_code,@ModUser_id, ")
            StrSQL.Append(" @Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_TRANS_feeDtl SET  ")
            StrSQL.Append(" main_id=@main_id,Apply_amt=@Apply_amt,Non_id=@Non_id,Org_code=@Org_code,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Apply_amt,Non_id,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_TRANS_feeDtl  ")
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
            StrSQL.Append(" main_id,Apply_amt,Non_id,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_TRANS_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_TRANS_feeDtl WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function getDataByOrgFid(ByVal Orgcode As String, ByVal flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select d.*, m.Apply_ym, ")
            sql.AppendLine(" d.Non_id Id_card, ")
            sql.AppendLine(" (select top 1 User_Name from FSC_Personnel p where p.id_card=d.Non_id ) as User_Name, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org where Depart_id = (select top 1 Depart_id from FSC_Depart_emp where id_card=Non_id)) as Depart_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code where code_sys='023' and code_type='022' and code_no = (select top 1 Employee_type from FSC_Personnel p where p.id_card=d.Non_id )) as Employee_type ")
            sql.AppendLine(" from SAL_TRANS_feeDtl d ")
            sql.AppendLine(" inner join SAL_TRANS_fee m on m.id=d.main_id ")
            sql.AppendLine(" where m.Org_code=@Orgcode and flow_id=@flow_id ")

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param(0).Value = Orgcode
            param(1) = New SqlParameter("@flow_id", SqlDbType.VarChar)
            param(1).Value = flow_id

            Return Query(sql.ToString(), param)
        End Function

        Public Sub DeleteByOrgFid(ByVal Orgcode As String, ByVal flow_id As String)
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" delete from SAL_TRANS_feeDtl where main_id in ")
            sql.AppendLine(" (select id from SAL_TRANS_fee where Org_code=@Orgcode and flow_id=@flow_id )")

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param(0).Value = Orgcode
            param(1) = New SqlParameter("@flow_id", SqlDbType.VarChar)
            param(1).Value = flow_id

            Execute(sql.ToString(), param)
        End Sub
    End Class
End Namespace