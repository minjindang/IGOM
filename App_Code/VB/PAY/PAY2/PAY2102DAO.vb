Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace PAY.Logic
    Public Class PAY2102DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        Public Function Select_01_01(ByVal PettyCash_nosS As String, _
                                      ByVal PettyCash_nosE As String, _
                                      ByVal Beneficiary_id As String, _
                                      ByVal Year As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            StrSQL &= "select FiscalYear_id, PAY_Beneficiary_data.Beneficiary_name, PAY_Beneficiary_data.BankAccount_nos, PAY_LendPetty_main.PurchaseTotal_amt, PAY_LendPetty_main.PettyCash_nos, PAY_LendPetty_main.Invoice_date, (PAY_LendPetty_main.PurchaseAbstract_desc+ '/' + PAY_LendPetty_main.PurchaseForm_id) as AbstractRequisitions from PAY_LendPetty_main "
            StrSQL &= "inner join PAY_Beneficiary_data on PAY_LendPetty_main.Beneficiary_id=PAY_Beneficiary_data.Beneficiary_id "
            StrSQL &= "where 1=1 AND PAY_LendPetty_main.PettyCash_type='002' "
            If Not String.IsNullOrEmpty(PettyCash_nosS) Then
                StrSQL &= "and PAY_LendPetty_main.PettyCash_nos >= @PettyCash_nosS "
            End If
            If Not String.IsNullOrEmpty(PettyCash_nosE) Then
                StrSQL &= "and PAY_LendPetty_main.PettyCash_nos <= @PettyCash_nosE "
            End If
            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                StrSQL &= "and PAY_LendPetty_main.Beneficiary_id = @Beneficiary_id "
            End If
            If Not String.IsNullOrEmpty(Year) Then
                StrSQL &= "and FiscalYear_id = @Year "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@PettyCash_nosS", PettyCash_nosS), _
                                        New SqlParameter("@PettyCash_nosE", PettyCash_nosE), _
                                        New SqlParameter("@Beneficiary_id", Beneficiary_id), _
                                        New SqlParameter("@Year", Year)}
            Return Query(StrSQL, ps)
        End Function
        Public Function Select_02_01(ByVal PettyCash_nosS As String, _
                                      ByVal PettyCash_nosE As String, _
                                      ByVal Beneficiary_id As String, _
                                      ByVal Year As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            StrSQL &= "select ROW_NUMBER() OVER(ORDER BY PurchaseTotal_amt desc) AS SerialNumber, '一般匯款' as PurchaseType, PurchaseTotal_amt, PAY_Beneficiary_data.Bank_id, PAY_LendPetty_main.OrgCode, BankAbbreviation_name, PAY_Beneficiary_data.BankAccount_nos, PAY_LendPetty_main.Beneficiary_id, PurchaseTotal_amt, Beneficiary_name from PAY_LendPetty_main "
            StrSQL &= "inner join PAY_Beneficiary_data on PAY_LendPetty_main.Beneficiary_id=PAY_Beneficiary_data.Beneficiary_id "
            StrSQL &= "inner join PAY_Bank_data on PAY_Bank_data.Bank_id=PAY_Beneficiary_data.Bank_id "
            StrSQL &= "where 1 = 1 AND PAY_LendPetty_main.PettyCash_type='002' "
            If Not String.IsNullOrEmpty(PettyCash_nosS) Then
                StrSQL &= "and PAY_LendPetty_main.PettyCash_nos >= @PettyCash_nosS "
            End If
            If Not String.IsNullOrEmpty(PettyCash_nosE) Then
                StrSQL &= "and PAY_LendPetty_main.PettyCash_nos <= @PettyCash_nosE "
            End If
            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                StrSQL &= "and PAY_LendPetty_main.Beneficiary_id = @Beneficiary_id "
            End If
            If Not String.IsNullOrEmpty(Year) Then
                StrSQL &= "and FiscalYear_id = @Year "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@PettyCash_nosS", PettyCash_nosS), _
                                        New SqlParameter("@PettyCash_nosE", PettyCash_nosE), _
                                        New SqlParameter("@Beneficiary_id", Beneficiary_id), _
                                        New SqlParameter("@Year", Year)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetSAUNIT(UNIT_NO As String) As DataTable
            Dim ps() As SqlParameter = {New SqlParameter("@UNIT_NO", UNIT_NO)}
            Return Query("select * from SAL_SAUNIT where UNIT_NO=@UNIT_NO", ps)
        End Function

    End Class
End Namespace