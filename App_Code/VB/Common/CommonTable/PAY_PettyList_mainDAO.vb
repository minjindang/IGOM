Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_PettyList_mainDAO
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


            StrSQL.Append(" INSERT INTO PAY_PettyList_main ( ")
            StrSQL.Append(" OrgCode,FiscalYear_id,PCList_id,PettyCash_type,PettyCashStart_nos, ")
            StrSQL.Append(" PettyCashEnd_nos,PrepayStart_nos,PrepayEnd_nos,CurrentBalances_amt,LastBalances_amt, ")
            StrSQL.Append(" PayBalances_amt,PaymentVoucher_id,Memo,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@FiscalYear_id,@PCList_id,@PettyCash_type,@PettyCashStart_nos, ")
            StrSQL.Append(" @PettyCashEnd_nos,@PrepayStart_nos,@PrepayEnd_nos,@CurrentBalances_amt,@LastBalances_amt, ")
            StrSQL.Append(" @PayBalances_amt,@PaymentVoucher_id,@Memo,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_PettyList_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,FiscalYear_id=@FiscalYear_id,PCList_id=@PCList_id,PettyCash_type=@PettyCash_type,PettyCashStart_nos=@PettyCashStart_nos, ")
            StrSQL.Append(" PettyCashEnd_nos=@PettyCashEnd_nos,PrepayStart_nos=@PrepayStart_nos,PrepayEnd_nos=@PrepayEnd_nos,CurrentBalances_amt=@CurrentBalances_amt,LastBalances_amt=@LastBalances_amt, ")
            StrSQL.Append(" PayBalances_amt=@PayBalances_amt,PaymentVoucher_id=@PaymentVoucher_id,Memo=@Memo,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND FiscalYear_id=@FiscalYear_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND PCList_id=@PCList_id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,FiscalYear_id,PCList_id,PettyCash_type,PettyCashStart_nos, ")
            StrSQL.Append(" PettyCashEnd_nos,PrepayStart_nos,PrepayEnd_nos,CurrentBalances_amt,LastBalances_amt, ")
            StrSQL.Append(" PayBalances_amt,PaymentVoucher_id,Memo,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PAY_PettyList_main  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(FiscalYear_id As String, OrgCode As String, PCList_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,FiscalYear_id,PCList_id,PettyCash_type,PettyCashStart_nos, ")
            StrSQL.Append(" PettyCashEnd_nos,PrepayStart_nos,PrepayEnd_nos,CurrentBalances_amt,LastBalances_amt, ")
            StrSQL.Append(" PayBalances_amt,PaymentVoucher_id,Memo,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PAY_PettyList_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND FiscalYear_id=@FiscalYear_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND PCList_id=@PCList_id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@FiscalYear_id", FiscalYear_id), _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@PCList_id", PCList_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(FiscalYear_id As String, OrgCode As String, PCList_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_PettyList_main WHERE  FiscalYear_id=@FiscalYear_id AND OrgCode=@OrgCode AND PCList_id=@PCList_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@FiscalYear_id", FiscalYear_id), New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@PCList_id", PCList_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace