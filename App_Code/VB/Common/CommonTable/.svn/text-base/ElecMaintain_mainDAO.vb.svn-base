Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class ElecMaintain_mainDAO
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


            StrSQL.Append(" INSERT INTO MAI_ElecMaintain_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,Phone_nos,Unit_code,User_id, ")
            StrSQL.Append(" User_name,ApplyTime,Attachment,Memo,CaseClose_type, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Phone_nos,@Unit_code,@User_id, ")
            StrSQL.Append(" @User_name,@ApplyTime,@Attachment,@Memo,@CaseClose_type, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE MAI_ElecMaintain_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Phone_nos=@Phone_nos,Unit_code=@Unit_code,User_id=@User_id, ")
            StrSQL.Append(" User_name=@User_name,ApplyTime=@ApplyTime,Attachment=@Attachment,Memo=@Memo,CaseClose_type=@CaseClose_type, ")
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
            StrSQL.Append(" OrgCode,Flow_id,Phone_nos,Unit_code,User_id, ")
            StrSQL.Append(" User_name,ApplyTime,Attachment,Memo,CaseClose_type ")
            StrSQL.Append("  FROM MAI_ElecMaintain_main  ")
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
            StrSQL.Append(" OrgCode,Flow_id,Phone_nos,Unit_code,User_id, ")
            StrSQL.Append(" User_name,ApplyTime,Attachment,Memo,CaseClose_type ")
            StrSQL.Append("  FROM MAI_ElecMaintain_main  ")
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
            StrSQL.Append(" DELETE FROM MAI_ElecMaintain_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace