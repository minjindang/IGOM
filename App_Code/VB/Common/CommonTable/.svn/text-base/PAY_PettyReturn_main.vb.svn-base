Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_PettyReturn_main
        Public DAO As PAY_PettyReturn_mainDAO

        Public Sub New()
            DAO = New PAY_PettyReturn_mainDAO()
        End Sub

        Public Function GetOne(FiscalYear_id As String, OrgCode As String, PettyCashInventory_id As String, Receive_date As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(FiscalYear_id, OrgCode, PettyCashInventory_id, Receive_date)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional FiscalYear_id As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, FiscalYear_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, FiscalYear_id As String, Receive_date As String, PettyCashInventory_id As String, YearInitial_amt As Double, _
                        BroughtForward_amt As Double, Balances_amt As Double, PaymentVoucher_id As String, Income_amt As Double, Memo As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(FiscalYear_id) Then
                psList.Add(New SqlParameter("@FiscalYear_id", FiscalYear_id))
            Else
                psList.Add(New SqlParameter("@FiscalYear_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Receive_date) Then
                psList.Add(New SqlParameter("@Receive_date", Receive_date))
            Else
                psList.Add(New SqlParameter("@Receive_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCashInventory_id) Then
                psList.Add(New SqlParameter("@PettyCashInventory_id", PettyCashInventory_id))
            Else
                psList.Add(New SqlParameter("@PettyCashInventory_id", DBNull.Value))
            End If
            If Not YearInitial_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@YearInitial_amt", YearInitial_amt))
            Else
                psList.Add(New SqlParameter("@YearInitial_amt", DBNull.Value))
            End If
            If Not BroughtForward_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@BroughtForward_amt", BroughtForward_amt))
            Else
                psList.Add(New SqlParameter("@BroughtForward_amt", DBNull.Value))
            End If
            If Not Balances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Balances_amt", Balances_amt))
            Else
                psList.Add(New SqlParameter("@Balances_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", DBNull.Value))
            End If
            If Not Income_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Income_amt", Income_amt))
            Else
                psList.Add(New SqlParameter("@Income_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", DBNull.Value))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(OrgCode As String, FiscalYear_id As String, Receive_date As String, PettyCashInventory_id As String, YearInitial_amt As Double, _
                            BroughtForward_amt As Double, Balances_amt As Double, PaymentVoucher_id As String, Income_amt As Double, Memo As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(FiscalYear_id, OrgCode, PettyCashInventory_id, Receive_date)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@FiscalYear_id", FiscalYear_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@PettyCashInventory_id", PettyCashInventory_id))
            psList.Add(New SqlParameter("@Receive_date", Receive_date))
            If Not YearInitial_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@YearInitial_amt", YearInitial_amt))
            Else
                psList.Add(New SqlParameter("@YearInitial_amt", dr("YearInitial_amt")))
            End If
            If Not BroughtForward_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@BroughtForward_amt", BroughtForward_amt))
            Else
                psList.Add(New SqlParameter("@BroughtForward_amt", dr("BroughtForward_amt")))
            End If
            If Not Balances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Balances_amt", Balances_amt))
            Else
                psList.Add(New SqlParameter("@Balances_amt", dr("Balances_amt")))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", dr("PaymentVoucher_id")))
            End If
            If Not Income_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Income_amt", Income_amt))
            Else
                psList.Add(New SqlParameter("@Income_amt", dr("Income_amt")))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", dr("Memo")))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(FiscalYear_id As String, OrgCode As String, PettyCashInventory_id As String, Receive_date As String)
            DAO.Delete(FiscalYear_id, OrgCode, PettyCashInventory_id, Receive_date)
        End Sub

    End Class
End Namespace
