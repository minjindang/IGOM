Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class PAY_LendPetty_main

        Public DAO As PAY_LendPetty_mainDAO

        Public Sub New()
            DAO = New PAY_LendPetty_mainDAO
        End Sub

        Public Function GetNextPettyCash_nos(Orgocde As String) As String

            Return (DAO.GetMaxPettyCash_nos(Orgocde) + 1).ToString().PadLeft(6, "0")
        End Function

        Public Function GetNextPrePayID(Orgocde As String, rocYear As String) As String
            Return rocYear.PadLeft(2, "0") & (DAO.GetMaxPrePayID(Orgocde, rocYear) + 1).ToString().PadLeft(3, "0")

        End Function

        Public Function GetAll(Orgocde As String, fiscalYear_id As String, Prepay_id_S As String, Prepay_id_E As String, PCList_id As String _
                             , writeOff_date As String, borrow_date_S As String, borrow_date_E As String, pettyCash_nos_S As String, pettyCash_nos_E As String _
                             , beneficiary_id As String, use_type As String, invoice_date As String, paymentVoucher_id As String, PettyCash_type As String) As DataTable
            Return DAO.GetAll(Orgocde, fiscalYear_id, Prepay_id_S, Prepay_id_E, PCList_id, _
                              writeOff_date, borrow_date_S, borrow_date_E, pettyCash_nos_S, pettyCash_nos_E, _
                              beneficiary_id, use_type, invoice_date, paymentVoucher_id, PettyCash_type)

        End Function

        Public Function GetOne(Orgocde As String, SerialNumber_id As Integer) As DataRow
            Dim dt As DataTable = DAO.GetOne(Orgocde, SerialNumber_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
            Return Nothing
        End Function

        Public Sub Add(OrgCode As String, PettyCash_type As String, FiscalYear_id As String, PettyCash_nos As String, Prepay_id As String, _
                        PCList_id As String, PurchaseForm_id As String, Invoice_date As String, Beneficiary_id As String, Middleman_name As String, _
                        Use_type As String, Receipt_cnt As Double, PurchaseTotal_amt As Double, PurchaseAbstract_desc As String, Balance_amt As Double, _
                        WriteOff_date As String, PaymentVoucher_id As String, Income_date As String, Income_amt As Double, Borrow_date As String, ModUser_id As String, Mod_date As DateTime, _
                        PurchaseForm_sn As String, Middleman_id As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                psList.Add(New SqlParameter("@PettyCash_type", PettyCash_type))
            Else
                psList.Add(New SqlParameter("@PettyCash_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(FiscalYear_id) Then
                psList.Add(New SqlParameter("@FiscalYear_id", FiscalYear_id))
            Else
                psList.Add(New SqlParameter("@FiscalYear_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PettyCash_nos) Then
                psList.Add(New SqlParameter("@PettyCash_nos", PettyCash_nos))
            Else
                psList.Add(New SqlParameter("@PettyCash_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Prepay_id) Then
                psList.Add(New SqlParameter("@Prepay_id", Prepay_id))
            Else
                psList.Add(New SqlParameter("@Prepay_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PCList_id) Then
                psList.Add(New SqlParameter("@PCList_id", PCList_id))
            Else
                psList.Add(New SqlParameter("@PCList_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PurchaseForm_id) Then
                psList.Add(New SqlParameter("@PurchaseForm_id", PurchaseForm_id))
            Else
                psList.Add(New SqlParameter("@PurchaseForm_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Invoice_date) Then
                psList.Add(New SqlParameter("@Invoice_date", Invoice_date))
            Else
                psList.Add(New SqlParameter("@Invoice_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                psList.Add(New SqlParameter("@Beneficiary_id", Beneficiary_id))
            Else
                psList.Add(New SqlParameter("@Beneficiary_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Middleman_id) Then
                psList.Add(New SqlParameter("@Middleman_id", Middleman_id))
            Else
                psList.Add(New SqlParameter("@Middleman_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Middleman_name) Then
                psList.Add(New SqlParameter("@Middleman_name", Middleman_name))
            Else
                psList.Add(New SqlParameter("@Middleman_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Use_type) Then
                psList.Add(New SqlParameter("@Use_type", Use_type))
            Else
                psList.Add(New SqlParameter("@Use_type", DBNull.Value))
            End If
            If Not Receipt_cnt = Double.MinValue Then
                psList.Add(New SqlParameter("@Receipt_cnt", Receipt_cnt))
            Else
                psList.Add(New SqlParameter("@Receipt_cnt", DBNull.Value))
            End If
            If Not PurchaseTotal_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PurchaseTotal_amt", PurchaseTotal_amt))
            Else
                psList.Add(New SqlParameter("@PurchaseTotal_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PurchaseAbstract_desc) Then
                psList.Add(New SqlParameter("@PurchaseAbstract_desc", PurchaseAbstract_desc))
            Else
                psList.Add(New SqlParameter("@PurchaseAbstract_desc", DBNull.Value))
            End If
            If Not Balance_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Balance_amt", Balance_amt))
            Else
                psList.Add(New SqlParameter("@Balance_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(WriteOff_date) Then
                psList.Add(New SqlParameter("@WriteOff_date", WriteOff_date))
            Else
                psList.Add(New SqlParameter("@WriteOff_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Income_date) Then
                psList.Add(New SqlParameter("@Income_date", Income_date))
            Else
                psList.Add(New SqlParameter("@Income_date", DBNull.Value))
            End If
            If Not Income_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Income_amt", Income_amt))
            Else
                psList.Add(New SqlParameter("@Income_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Borrow_date) Then
                psList.Add(New SqlParameter("@Borrow_date", Borrow_date))
            Else
                psList.Add(New SqlParameter("@Borrow_date", DBNull.Value))
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

            If Not String.IsNullOrEmpty(PurchaseForm_sn) Then
                psList.Add(New SqlParameter("@PurchaseForm_sn", PurchaseForm_sn))
            End If

            DAO.Insert(psList.ToArray())
        End Sub

        Public Function Modify(SerialNumber_id As Integer, OrgCode As String, PettyCash_type As String, FiscalYear_id As String, PettyCash_nos As String, Prepay_id As String, _
                            PCList_id As String, PurchaseForm_id As String, Invoice_date As String, Beneficiary_id As String, Middleman_name As String, _
                            Use_type As String, Receipt_cnt As Double, PurchaseTotal_amt As Double, PurchaseAbstract_desc As String, Balance_amt As Double, _
                            WriteOff_date As String, PaymentVoucher_id As String, Income_date As String, Income_amt As Double, Borrow_date As String, ModUser_id As String, Mod_date As DateTime, _
                            PurchaseForm_sn As String, Middleman_id As String) As Boolean

            Dim dr As DataRow = GetOne(OrgCode, SerialNumber_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@SerialNumber_id", SerialNumber_id))
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                psList.Add(New SqlParameter("@PettyCash_type", PettyCash_type))
            Else
                psList.Add(New SqlParameter("@PettyCash_type", dr("PettyCash_type")))
            End If
            If Not String.IsNullOrEmpty(FiscalYear_id) Then
                psList.Add(New SqlParameter("@FiscalYear_id", FiscalYear_id))
            Else
                psList.Add(New SqlParameter("@FiscalYear_id", dr("FiscalYear_id")))
            End If
            If Not String.IsNullOrEmpty(PettyCash_nos) Then
                psList.Add(New SqlParameter("@PettyCash_nos", PettyCash_nos))
            Else
                psList.Add(New SqlParameter("@PettyCash_nos", dr("PettyCash_nos")))
            End If
            If Not String.IsNullOrEmpty(Prepay_id) Then
                psList.Add(New SqlParameter("@Prepay_id", Prepay_id))
            Else
                psList.Add(New SqlParameter("@Prepay_id", dr("Prepay_id")))
            End If
            If Not String.IsNullOrEmpty(PCList_id) Then
                psList.Add(New SqlParameter("@PCList_id", PCList_id))
            Else
                psList.Add(New SqlParameter("@PCList_id", dr("PCList_id")))
            End If
            If Not String.IsNullOrEmpty(PurchaseForm_id) Then
                psList.Add(New SqlParameter("@PurchaseForm_id", PurchaseForm_id))
            Else
                psList.Add(New SqlParameter("@PurchaseForm_id", dr("PurchaseForm_id")))
            End If
            If Not String.IsNullOrEmpty(PurchaseForm_sn) Then
                psList.Add(New SqlParameter("@PurchaseForm_sn", PurchaseForm_sn))
            Else
                psList.Add(New SqlParameter("@PurchaseForm_sn", dr("PurchaseForm_sn")))
            End If
            If Not String.IsNullOrEmpty(Invoice_date) Then
                psList.Add(New SqlParameter("@Invoice_date", Invoice_date))
            Else
                psList.Add(New SqlParameter("@Invoice_date", dr("Invoice_date")))
            End If
            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                psList.Add(New SqlParameter("@Beneficiary_id", Beneficiary_id))
            Else
                psList.Add(New SqlParameter("@Beneficiary_id", dr("Beneficiary_id")))
            End If
            If Not String.IsNullOrEmpty(Middleman_name) Then
                psList.Add(New SqlParameter("@Middleman_name", Middleman_name))
            Else
                psList.Add(New SqlParameter("@Middleman_name", dr("Middleman_name")))
            End If
            If Not String.IsNullOrEmpty(Middleman_id) Then
                psList.Add(New SqlParameter("@Middleman_id", Middleman_id))
            Else
                psList.Add(New SqlParameter("@Middleman_id", dr("Middleman_id")))
            End If
            If Not String.IsNullOrEmpty(Use_type) Then
                psList.Add(New SqlParameter("@Use_type", Use_type))
            Else
                psList.Add(New SqlParameter("@Use_type", dr("Use_type")))
            End If
            If Not Receipt_cnt = Double.MinValue Then
                psList.Add(New SqlParameter("@Receipt_cnt", Receipt_cnt))
            Else
                psList.Add(New SqlParameter("@Receipt_cnt", dr("Receipt_cnt")))
            End If
            If Not PurchaseTotal_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PurchaseTotal_amt", PurchaseTotal_amt))
            Else
                psList.Add(New SqlParameter("@PurchaseTotal_amt", dr("PurchaseTotal_amt")))
            End If
            If Not String.IsNullOrEmpty(PurchaseAbstract_desc) Then
                psList.Add(New SqlParameter("@PurchaseAbstract_desc", PurchaseAbstract_desc))
            Else
                psList.Add(New SqlParameter("@PurchaseAbstract_desc", dr("PurchaseAbstract_desc")))
            End If
            If Not Balance_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Balance_amt", Balance_amt))
            Else
                psList.Add(New SqlParameter("@Balance_amt", dr("Balance_amt")))
            End If
            If Not String.IsNullOrEmpty(WriteOff_date) Then
                psList.Add(New SqlParameter("@WriteOff_date", WriteOff_date))
            Else
                psList.Add(New SqlParameter("@WriteOff_date", dr("WriteOff_date")))
            End If
            If Not String.IsNullOrEmpty(PaymentVoucher_id) Then
                psList.Add(New SqlParameter("@PaymentVoucher_id", PaymentVoucher_id))
            Else
                psList.Add(New SqlParameter("@PaymentVoucher_id", dr("PaymentVoucher_id")))
            End If
            If Not String.IsNullOrEmpty(Income_date) Then
                psList.Add(New SqlParameter("@Income_date", Income_date))
            Else
                psList.Add(New SqlParameter("@Income_date", dr("Income_date")))
            End If
            If Not Income_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Income_amt", Income_amt))
            Else
                psList.Add(New SqlParameter("@Income_amt", dr("Income_amt")))
            End If
            If Not String.IsNullOrEmpty(Borrow_date) Then
                psList.Add(New SqlParameter("@Borrow_date", Borrow_date))
            Else
                psList.Add(New SqlParameter("@Borrow_date", dr("Borrow_date")))
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

            Return DAO.Update(psList.ToArray()) > 0
        End Function

        Public Sub Remove(OrgCode As String, SerialNumber_id As Integer)
            DAO.Delete(OrgCode, SerialNumber_id)
        End Sub

        Public Function CheckData(Orgcode As String, beneficiary_id As String) As Integer
            Return DAO.CheckData(Orgcode, beneficiary_id)
        End Function

    End Class
End Namespace
