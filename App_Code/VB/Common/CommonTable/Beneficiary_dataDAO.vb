Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class PAY_Beneficiary_dataDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString

        End Sub

        Public Function SelectAll(Optional OrgCode As String = "", Optional Beneficiary_id As String = "", _
                               Optional Beneficiary_name As String = "", Optional Bank_id As String = "", _
                               Optional isDel As String = "N", Optional BankAccount_nos As String = "") As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " SELECT * FROM PAY_Beneficiary_data a WHERE 1= 1  "

            If Not String.IsNullOrEmpty(OrgCode) Then
                StrSQL += " AND a.OrgCode = @OrgCode "
            End If

            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                StrSQL += " AND a.Beneficiary_id = @Beneficiary_id "
            End If

            If Not String.IsNullOrEmpty(Beneficiary_name) Then
                StrSQL += " AND a.Beneficiary_name like '%' + @Beneficiary_name + '%' "
            End If

            If Not String.IsNullOrEmpty(Bank_id) Then
                StrSQL += " AND a.Bank_id =@Bank_id "
            End If

            If Not String.IsNullOrEmpty(isDel) Then
                StrSQL += " AND (a.isDel =@isDel OR a.isDel IS NULL)"
            End If

            '1030526Ray
            If Not String.IsNullOrEmpty(BankAccount_nos) Then
                StrSQL += " AND a.BankAccount_nos =@BankAccount_nos "
            End If

            Dim ps() As SqlParameter = { _
                New SqlParameter("@OrgCode", OrgCode), _
                New SqlParameter("@Beneficiary_id", Beneficiary_id), _
                New SqlParameter("@Beneficiary_name", Beneficiary_name), _
                New SqlParameter("@BankAccount_nos", BankAccount_nos), _
                New SqlParameter("@Bank_id", Bank_id), _
                New SqlParameter("@isDel", isDel) _
                                    }
            Return Query(StrSQL, ps)
        End Function


        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO PAY_Beneficiary_data ( ")
            StrSQL.Append(" OrgCode,Beneficiary_id,User_id,Beneficiary_name,Bank_id, ")
            StrSQL.Append(" BankAccount_nos,Email,ModUser_id,Mod_date,isDel ")
            StrSQL.Append("  ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Beneficiary_id,@User_id,@Beneficiary_name,@Bank_id, ")
            StrSQL.Append(" @BankAccount_nos,@Email,@ModUser_id,@Mod_date,@isDel ")
            StrSQL.Append("  ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_Beneficiary_data SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Beneficiary_id=@Beneficiary_id,User_id=@User_id,Beneficiary_name=@Beneficiary_name,Bank_id=@Bank_id, ")
            StrSQL.Append(" BankAccount_nos=@BankAccount_nos,Email=@Email,ModUser_id=@ModUser_id,Mod_date=@Mod_date,isDel=@isDel ")
            StrSQL.Append("  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Beneficiary_id=@Beneficiary_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub 

        'SELECT ONE
        Public Function SelectOne(Beneficiary_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Beneficiary_id,User_id,Beneficiary_name,Bank_id, ")
            StrSQL.Append(" BankAccount_nos,Email,ModUser_id,Mod_date,isDel ")
            StrSQL.Append("  FROM PAY_Beneficiary_data  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Beneficiary_id=@Beneficiary_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Beneficiary_id", Beneficiary_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Beneficiary_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            'StrSQL.Append(" DELETE FROM PAY_Beneficiary_data WHERE  Beneficiary_id=@Beneficiary_id AND OrgCode=@OrgCode  ")
            StrSQL.Append(" UPDATE PAY_Beneficiary_data SET isDel = 'Y' WHERE  Beneficiary_id=@Beneficiary_id AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = {New SqlParameter("@Beneficiary_id", Beneficiary_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function GetMaxBeneficiaryId(orgcode As String) As Object
            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", orgcode)}
            Return Scalar("select MAX(Beneficiary_id) from dbo.PAY_Beneficiary_data where orgcode=@orgcode and len(Beneficiary_id)=10 ", ps)
        End Function
    End Class
End Namespace
