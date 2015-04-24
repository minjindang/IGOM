Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_PettyList_main
        Public DAO As PAY_PettyList_mainDAO

        Public Sub New()
            DAO = New PAY_PettyList_mainDAO()
        End Sub

        Public Function GetOne(FiscalYear_id As String, OrgCode As String, PCList_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(FiscalYear_id, OrgCode, PCList_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As DataTable
            Dim dt As DataTable = DAO.SelectAll()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, FiscalYear_id As String, PCList_id As String, PettyCash_type As String, PettyCashStart_nos As String, _
PettyCashEnd_nos As String, PrepayStart_nos As String, PrepayEnd_nos As String, CurrentBalances_amt As Double, LastBalances_amt As Double, _
PayBalances_amt As Double, PaymentVoucher_id As String, Memo As String, ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(PCList_id) Then
                psList.Add(New SqlParameter("@PCList_id", PCList_id))
            Else
                psList.Add(New SqlParameter("@PCList_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                psList.Add(New SqlParameter("@PettyCash_type", PettyCash_type))
            Else
                psList.Add(New SqlParameter("@PettyCash_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCashStart_nos) Then
                psList.Add(New SqlParameter("@PettyCashStart_nos", PettyCashStart_nos))
            Else
                psList.Add(New SqlParameter("@PettyCashStart_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCashEnd_nos) Then
                psList.Add(New SqlParameter("@PettyCashEnd_nos", PettyCashEnd_nos))
            Else
                psList.Add(New SqlParameter("@PettyCashEnd_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PrepayStart_nos) Then
                psList.Add(New SqlParameter("@PrepayStart_nos", PrepayStart_nos))
            Else
                psList.Add(New SqlParameter("@PrepayStart_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PrepayEnd_nos) Then
                psList.Add(New SqlParameter("@PrepayEnd_nos", PrepayEnd_nos))
            Else
                psList.Add(New SqlParameter("@PrepayEnd_nos", DBNull.Value))
            End If
            If Not CurrentBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@CurrentBalances_amt", CurrentBalances_amt))
            Else
                psList.Add(New SqlParameter("@CurrentBalances_amt", DBNull.Value))
            End If
            If Not LastBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@LastBalances_amt", LastBalances_amt))
            Else
                psList.Add(New SqlParameter("@LastBalances_amt", DBNull.Value))
            End If
            If Not PayBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PayBalances_amt", PayBalances_amt))
            Else
                psList.Add(New SqlParameter("@PayBalances_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", DBNull.Value))
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

        Public Sub Modify(OrgCode As String, FiscalYear_id As String, PCList_id As String, PettyCash_type As String, PettyCashStart_nos As String, _
PettyCashEnd_nos As String, PrepayStart_nos As String, PrepayEnd_nos As String, CurrentBalances_amt As Double, LastBalances_amt As Double, _
PayBalances_amt As Double, PaymentVoucher_id As String, Memo As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(FiscalYear_id, OrgCode, PCList_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@FiscalYear_id", FiscalYear_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@PCList_id", PCList_id))
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                psList.Add(New SqlParameter("@PettyCash_type", PettyCash_type))
            Else
                psList.Add(New SqlParameter("@PettyCash_type", dr("PettyCash_type")))
            End If
            If Not String.IsNullOrEmpty(PettyCashStart_nos) Then
                psList.Add(New SqlParameter("@PettyCashStart_nos", PettyCashStart_nos))
            Else
                psList.Add(New SqlParameter("@PettyCashStart_nos", dr("PettyCashStart_nos")))
            End If
            If Not String.IsNullOrEmpty(PettyCashEnd_nos) Then
                psList.Add(New SqlParameter("@PettyCashEnd_nos", PettyCashEnd_nos))
            Else
                psList.Add(New SqlParameter("@PettyCashEnd_nos", dr("PettyCashEnd_nos")))
            End If
            If Not String.IsNullOrEmpty(PrepayStart_nos) Then
                psList.Add(New SqlParameter("@PrepayStart_nos", PrepayStart_nos))
            Else
                psList.Add(New SqlParameter("@PrepayStart_nos", dr("PrepayStart_nos")))
            End If
            If Not String.IsNullOrEmpty(PrepayEnd_nos) Then
                psList.Add(New SqlParameter("@PrepayEnd_nos", PrepayEnd_nos))
            Else
                psList.Add(New SqlParameter("@PrepayEnd_nos", dr("PrepayEnd_nos")))
            End If
            If Not CurrentBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@CurrentBalances_amt", CurrentBalances_amt))
            Else
                psList.Add(New SqlParameter("@CurrentBalances_amt", dr("CurrentBalances_amt")))
            End If
            If Not LastBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@LastBalances_amt", LastBalances_amt))
            Else
                psList.Add(New SqlParameter("@LastBalances_amt", dr("LastBalances_amt")))
            End If
            If Not PayBalances_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PayBalances_amt", PayBalances_amt))
            Else
                psList.Add(New SqlParameter("@PayBalances_amt", dr("PayBalances_amt")))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", dr("PaymentVoucher_id")))
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

        Public Sub Remove(FiscalYear_id As String, OrgCode As String, PCList_id As String)
            DAO.Delete(FiscalYear_id, OrgCode, PCList_id)
        End Sub

    End Class
End Namespace
