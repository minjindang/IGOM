Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_PettyList_mail_LogDAO
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


            StrSQL.Append(" INSERT INTO PAY_PettyList_mail_Log ( ")
            StrSQL.Append(" OrgCode,mail_type,mail_to,mail_cc,mail_bcc, ")
            StrSQL.Append(" mail_subject,mail_content,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@mail_type,@mail_to,@mail_cc,@mail_bcc, ")
            StrSQL.Append(" @mail_subject,@mail_content,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_PettyList_mail_Log SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,mail_type=@mail_type,mail_to=@mail_to,mail_cc=@mail_cc,mail_bcc=@mail_bcc, ")
            StrSQL.Append(" mail_subject=@mail_subject,mail_content=@mail_content,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND mail_id=@mail_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,mail_type,mail_to,mail_cc,mail_bcc ")
            StrSQL.Append("  FROM PAY_PettyList_mail_Log  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(mail_id As Integer, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,mail_type,mail_to,mail_cc,mail_bcc ")
            StrSQL.Append("  FROM PAY_PettyList_mail_Log  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND mail_id=@mail_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@mail_id", mail_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(mail_id As Integer, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_PettyList_mail_Log WHERE  mail_id=@mail_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@mail_id", mail_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace