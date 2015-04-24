Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_Bank_dataDAO
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


            StrSQL.Append(" INSERT INTO PAY_Bank_data ( ")
            StrSQL.Append(" OrgCode,Bank_id,BankAbbreviation_name,Bank_name,ModUser_id, ")
            StrSQL.Append(" Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Bank_id,@BankAbbreviation_name,@Bank_name,@ModUser_id, ")
            StrSQL.Append(" @Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_Bank_data SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Bank_id=@Bank_id,BankAbbreviation_name=@BankAbbreviation_name,Bank_name=@Bank_name,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Bank_id=@Bank_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional Bank_id As String = "", Optional BankAbbreviation_name As String = "", _
                                  Optional Bank_name As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Bank_id,BankAbbreviation_name,Bank_name,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM PAY_Bank_data  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(Bank_id) Then
                StrSQL.Append("  AND Bank_id=@Bank_id  ")
            End If

            If Not String.IsNullOrEmpty(BankAbbreviation_name) Then
                StrSQL.Append("  AND BankAbbreviation_name like '%' + @BankAbbreviation_name + '%'  ")
            End If

            If Not String.IsNullOrEmpty(Bank_name) Then
                StrSQL.Append("  AND Bank_name like '%' + @Bank_name + '%'  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@OrgCode", OrgCode), _
          New SqlParameter("@Bank_id", Bank_id), _
          New SqlParameter("@BankAbbreviation_name", BankAbbreviation_name), _
          New SqlParameter("@Bank_name", Bank_name)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Bank_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Bank_id,BankAbbreviation_name,Bank_name,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM PAY_Bank_data  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Bank_id=@Bank_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Bank_id", Bank_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Bank_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_Bank_data WHERE  Bank_id=@Bank_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Bank_id", Bank_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace