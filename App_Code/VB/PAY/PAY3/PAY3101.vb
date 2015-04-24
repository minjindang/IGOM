Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class PAY3101
        Private LPMDAO As PAY_LendPetty_main
        Private SCDAO As SACode
        Private bll3101 As PAY3101DAO

        Public Sub New()
            LPMDAO = New PAY_LendPetty_main()
            SCDAO = New SACode()
            bll3101 = New PAY3101DAO()
        End Sub

        Public Function GetNextPettyCash_nos(Orgocde As String) As String
            Return LPMDAO.GetNextPettyCash_nos(Orgocde)
        End Function

        Public Function GetNextPrePayID(Orgocde As String, rocYear As String) As String
            Return LPMDAO.GetNextPrePayID(Orgocde, rocYear)
        End Function

        Public Function GetUse_type() As DataTable 
            Return SCDAO.GetData("018", "004")
        End Function

        Public Function IsNewGeneration(OrgCode As String) As Boolean
            Dim dt As DataTable = SCDAO.GetData("021", "001")
            Return dt.Select(String.Format(" CODE_DESC1 = '{0}' ", OrgCode)).Length > 0
        End Function

        Public Function GetAll(Orgocde As String, fiscalYear_id As String, Prepay_id_S As String, Prepay_id_E As String, PCList_id As String _
                            , writeOff_date As String, borrow_date_S As String, borrow_date_E As String, pettyCash_nos_S As String, pettyCash_nos_E As String _
                            , beneficiary_id As String, use_type As String, invoice_date As String, paymentVoucher_id As String) As DataTable

            Return LPMDAO.GetAll(Orgocde, fiscalYear_id, Prepay_id_S, Prepay_id_E, PCList_id, _
                              writeOff_date, borrow_date_S, borrow_date_E, pettyCash_nos_S, pettyCash_nos_E, _
                              beneficiary_id, use_type, invoice_date, paymentVoucher_id, "001")

        End Function

        Public Function GetOne(Orgocde As String, SerialNumber_id As Integer) As DataRow

            Return LPMDAO.GetOne(Orgocde, SerialNumber_id)

        End Function


        Public Sub Delete(orgCode As String, SerialNumber_id As String)
            LPMDAO.Remove(orgCode, SerialNumber_id)
        End Sub

        Public Sub Insert(orgCode As String, FiscalYear_id As String, PettyCash_nos As String, Prepay_id As String, _
                        PCList_id As String, PurchaseForm_id As String, Invoice_date As String, Beneficiary_id As String, Middleman_name As String, _
                        Use_type As String, Receipt_cnt As String, PurchaseTotal_amt As String, PurchaseAbstract_desc As String, Balance_amt As String, _
                        WriteOff_date As String, PaymentVoucher_id As String, Income_date As String, Income_amt As String, Borrow_date As String, _
                        ModUser_id As String, Mod_date As DateTime, PurchaseForm_sn As String, Middleman_id As String)
            If String.IsNullOrEmpty(Receipt_cnt) Then
                Receipt_cnt = 0
            End If
            If String.IsNullOrEmpty(PurchaseTotal_amt) Then
                PurchaseTotal_amt = 0
            End If
            If String.IsNullOrEmpty(Balance_amt) Then
                Balance_amt = 0
            End If
            If String.IsNullOrEmpty(Income_amt) Then
                Income_amt = 0
            End If

            LPMDAO.Add(orgCode, "001", FiscalYear_id, PettyCash_nos, Prepay_id, PCList_id, PurchaseForm_id, Invoice_date, Beneficiary_id, _
                       Middleman_name, Use_type, Receipt_cnt, PurchaseTotal_amt, PurchaseAbstract_desc, Balance_amt, WriteOff_date, PaymentVoucher_id, _
                       Income_date, Income_amt, Borrow_date, ModUser_id, Mod_date, PurchaseForm_sn, Middleman_id)
        End Sub

        Public Sub Update(orgCode As String, SerialNumber_id As Integer, FiscalYear_id As String, PettyCash_nos As String, Prepay_id As String, _
                         PCList_id As String, PurchaseForm_id As String, Invoice_date As String, Beneficiary_id As String, Middleman_name As String, _
                         Use_type As String, Receipt_cnt As String, PurchaseTotal_amt As String, PurchaseAbstract_desc As String, Balance_amt As String, _
                         WriteOff_date As String, PaymentVoucher_id As String, Income_date As String, Income_amt As String, Borrow_date As String, _
                         ModUser_id As String, Mod_date As DateTime, PurchaseForm_sn As String, Middleman_id As String)
            If String.IsNullOrEmpty(Receipt_cnt) Then
                Receipt_cnt = 0
            End If
            If String.IsNullOrEmpty(PurchaseTotal_amt) Then
                PurchaseTotal_amt = 0
            End If
            If String.IsNullOrEmpty(Balance_amt) Then
                Balance_amt = 0
            End If
            If String.IsNullOrEmpty(Income_amt) Then
                Income_amt = 0
            End If
            LPMDAO.Modify(SerialNumber_id, orgCode, "001", FiscalYear_id, PettyCash_nos, Prepay_id, PCList_id, PurchaseForm_id, Invoice_date, Beneficiary_id, _
                       Middleman_name, Use_type, Receipt_cnt, PurchaseTotal_amt, PurchaseAbstract_desc, Balance_amt, WriteOff_date, PaymentVoucher_id, _
                       Income_date, Income_amt, Borrow_date, ModUser_id, Mod_date, PurchaseForm_sn, Middleman_id)
        End Sub

        ''' <summary>
        ''' 回傳【VW_IGSS_PO】相關資料
        ''' </summary>
        ''' <param name="PoNoSn">請購單號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(PoYear As String, PoNo As String, PoNosn As String) As DataTable
            Dim dao2 As PAY3101DAO = New PAY3101DAO(ConnectDB.GetDianaDBString())
            Dim psn As New FSC.Logic.Personnel()
            Dim dt As DataTable = dao2.GetData(PoYear, PoNo, PoNosn)
            dt.Columns.Add("User_name")
            dt.Columns.Add("Id_card")
            For Each dr As DataRow In dt.Rows
                Dim dt2 As DataTable = psn.GetDataByADid(dr("PoId").ToString())
                If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
                    dr("Id_card") = dt2.Rows(0)("Id_card").ToString()
                    dr("User_name") = dt2.Rows(0)("User_name").ToString()
                End If
            Next
            Return dt
        End Function

    End Class
End Namespace