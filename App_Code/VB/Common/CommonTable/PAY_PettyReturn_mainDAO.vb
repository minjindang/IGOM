Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_PettyReturn_mainDAO
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


            StrSQL.Append(" INSERT INTO PAY_PettyReturn_main ( ")
            StrSQL.Append(" OrgCode,FiscalYear_id,Receive_date,PettyCashInventory_id,YearInitial_amt, ")
            StrSQL.Append(" BroughtForward_amt,Balances_amt,PaymentVoucher_id,Income_amt,Memo, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@FiscalYear_id,@Receive_date,@PettyCashInventory_id,@YearInitial_amt, ")
            StrSQL.Append(" @BroughtForward_amt,@Balances_amt,@PaymentVoucher_id,@Income_amt,@Memo, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_PettyReturn_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,FiscalYear_id=@FiscalYear_id,Receive_date=@Receive_date,PettyCashInventory_id=@PettyCashInventory_id,YearInitial_amt=@YearInitial_amt, ")
            StrSQL.Append(" BroughtForward_amt=@BroughtForward_amt,Balances_amt=@Balances_amt,PaymentVoucher_id=@PaymentVoucher_id,Income_amt=@Income_amt,Memo=@Memo, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND FiscalYear_id=@FiscalYear_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND PettyCashInventory_id=@PettyCashInventory_id  ")
            StrSQL.Append("  AND Receive_date=@Receive_date  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional FiscalYear_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,FiscalYear_id,Receive_date,PettyCashInventory_id,YearInitial_amt, ")
            StrSQL.Append(" BroughtForward_amt,Balances_amt,PaymentVoucher_id,Income_amt,Memo ")
            StrSQL.Append("  FROM PAY_PettyReturn_main  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(FiscalYear_id) Then
                StrSQL.Append("  AND FiscalYear_id=@FiscalYear_id  ")
            End If


            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@FiscalYear_id", FiscalYear_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(FiscalYear_id As String, OrgCode As String, PettyCashInventory_id As String, Receive_date As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,FiscalYear_id,Receive_date,PettyCashInventory_id,YearInitial_amt, ")
            StrSQL.Append(" BroughtForward_amt,Balances_amt,PaymentVoucher_id,Income_amt,Memo ")
            StrSQL.Append("  FROM PAY_PettyReturn_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND FiscalYear_id=@FiscalYear_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND PettyCashInventory_id=@PettyCashInventory_id  ")
            StrSQL.Append("  AND Receive_date=@Receive_date  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@FiscalYear_id", FiscalYear_id), _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@PettyCashInventory_id", PettyCashInventory_id), _
         New SqlParameter("@Receive_date", Receive_date)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(FiscalYear_id As String, OrgCode As String, PettyCashInventory_id As String, Receive_date As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_PettyReturn_main WHERE  FiscalYear_id=@FiscalYear_id AND OrgCode=@OrgCode AND PettyCashInventory_id=@PettyCashInventory_id AND Receive_date=@Receive_date  ")
            Dim ps() As SqlParameter = {New SqlParameter("@FiscalYear_id", FiscalYear_id), New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@PettyCashInventory_id", PettyCashInventory_id), New SqlParameter("@Receive_date", Receive_date)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace