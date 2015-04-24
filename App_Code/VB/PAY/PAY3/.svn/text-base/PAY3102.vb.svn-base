Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Xml

Namespace FSCPLM.Logic
    Public Class PAY3102

        Private LPMDAO As PAY_LendPetty_main
        Private SCDAO As SACode
        Private bll3101 As PAY3101DAO
        Private service As PettyCashWebService.PettyCash1SoapClient

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

        Public Function GetAll(Orgocde As String, fiscalYear_id As String, PCList_id As String _
                            , writeOff_date As String, borrow_date_S As String, borrow_date_E As String, pettyCash_nos_S As String, pettyCash_nos_E As String _
                            , beneficiary_id As String, use_type As String, invoice_date As String) As DataTable

            Return LPMDAO.GetAll(Orgocde, fiscalYear_id, "", "", PCList_id, _
                              writeOff_date, borrow_date_S, borrow_date_E, pettyCash_nos_S, pettyCash_nos_E, _
                              beneficiary_id, use_type, invoice_date, "", "002")

        End Function

        Public Function GetOne(Orgocde As String, SerialNumber_id As Integer) As DataRow

            Return LPMDAO.GetOne(Orgocde, SerialNumber_id)

        End Function


        Public Sub Delete(orgCode As String, SerialNumber_id As String)
            LPMDAO.Remove(orgCode, SerialNumber_id)
        End Sub

        Public Function Insert(orgCode As String, FiscalYear_id As String, PettyCash_nos As String, _
                          Invoice_date As String, PurchaseForm_id As String, Beneficiary_id As String, Middleman_name As String, _
                        Use_type As String, Receipt_cnt As String, PurchaseTotal_amt As String, PurchaseAbstract_desc As String, Balance_amt As String, _
                        WriteOff_date As String, PaymentVoucher_id As String, _
                        ModUser_id As String, Mod_date As DateTime, PurchaseForm_sn As String, Beneficiary_name As String, Middleman_id As String) As String
            If String.IsNullOrEmpty(Receipt_cnt) Then
                Receipt_cnt = 0
            End If
            If String.IsNullOrEmpty(PurchaseTotal_amt) Then
                PurchaseTotal_amt = 0
            End If
            If String.IsNullOrEmpty(Balance_amt) Then
                Balance_amt = 0
            End If

            If Not IsNewGeneration(LoginManager.OrgCode) Then
                '無二代會計系統界接 給零用金流水號
                PettyCash_nos = GetNextPettyCash_nos(LoginManager.OrgCode)
            Else
                '二代會計系統界接
                PettyCash_nos = PettyCashInsert(FiscalYear_id, PurchaseForm_id, _
                                                PurchaseForm_sn, Invoice_date, _
                                                Beneficiary_id, Beneficiary_name, _
                                                Middleman_id, Middleman_name, _
                                                Use_type, PurchaseAbstract_desc, _
                                                PurchaseTotal_amt, Receipt_cnt, _
                                                LoginManager.ADId)

            End If

            LPMDAO.Add(orgCode, "002", FiscalYear_id, PettyCash_nos, "", "", PurchaseForm_id, Invoice_date, Beneficiary_id, _
                       Middleman_name, Use_type, Receipt_cnt, PurchaseTotal_amt, PurchaseAbstract_desc, Balance_amt, WriteOff_date, PaymentVoucher_id, _
                       "", 0, "", ModUser_id, Mod_date, PurchaseForm_sn, Middleman_id)


            Return PettyCash_nos
        End Function

        Public Sub Update(orgCode As String, SerialNumber_id As Integer, FiscalYear_id As String, PettyCash_nos As String, _
                          Invoice_date As String, PurchaseForm_id As String, Beneficiary_id As String, Middleman_name As String, _
                         Use_type As String, Receipt_cnt As String, PurchaseTotal_amt As String, PurchaseAbstract_desc As String, Balance_amt As String, _
                         WriteOff_date As String, PaymentVoucher_id As String, _
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
            LPMDAO.Modify(SerialNumber_id, orgCode, "002", FiscalYear_id, PettyCash_nos, "", "", PurchaseForm_id, Invoice_date, Beneficiary_id, _
                       Middleman_name, Use_type, Receipt_cnt, PurchaseTotal_amt, PurchaseAbstract_desc, Balance_amt, WriteOff_date, PaymentVoucher_id, _
                       "", 0, "", ModUser_id, Mod_date, PurchaseForm_sn, Middleman_id)
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


        ''' <summary>
        ''' 零用金新增
        ''' </summary>
        ''' <param name="monyear">會計年度</param>
        ''' <param name="monpono">請購單號</param>
        ''' <param name="monponosn">請購單序號</param>
        ''' <param name="monvouday">發票日期</param>
        ''' <param name="monrcvno">受款人代號</param>
        ''' <param name="monrcvnm">受款人</param>
        ''' <param name="monpocode">經手人代號</param>
        ''' <param name="monponm">經手人</param>
        ''' <param name="monfor">用途別</param>
        ''' <param name="mondesc">摘要</param>
        ''' <param name="monamt">請購金額</param>
        ''' <param name="monnum">單據張數</param>
        ''' <param name="cuserid">建立者代號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PettyCashInsert(monyear As String, _
                                        monpono As String, _
                                        monponosn As String, _
                                        monvouday As String, _
                                        monrcvno As String, _
                                        monrcvnm As String, _
                                        monpocode As String, _
                                        monponm As String, _
                                        monfor As String, _
                                        mondesc As String, _
                                        monamt As String, _
                                        monnum As String, _
                                        cuserid As String) As String
            service = New PettyCashWebService.PettyCash1SoapClient("PettyCash1Soap")
            Dim xml As New StringBuilder()
            xml.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            xml.AppendLine("<PETTTYCASHINSERTINFO>")
            xml.AppendLine(" <MONYEAR>").Append(monyear).Append("</MONYEAR> ")
            xml.AppendLine("  <MONPONO>").Append(monpono).Append("</MONPONO>")
            xml.AppendLine(" <MONPONOSN>").Append(monponosn).Append("</MONPONOSN>")
            xml.AppendLine(" <MONVOUDAY>").Append(monvouday).Append("</MONVOUDAY>")
            xml.AppendLine(" <MONRCVNO>").Append(monrcvno).Append("</MONRCVNO>")
            xml.AppendLine(" <MONRCVNM>").Append(monrcvnm).Append("</MONRCVNM>")
            xml.AppendLine(" <MONPOCODE>").Append(monpocode).Append("</MONPOCODE>")
            xml.AppendLine(" <MONPONM>").Append(monponm).Append("</MONPONM>")
            xml.AppendLine(" <MONFOR>").Append(monfor).Append("</MONFOR>")
            xml.AppendLine(" <MONDESC>").Append(mondesc).Append("</MONDESC>")
            xml.AppendLine(" <MONAMT>").Append(monamt).Append("</MONAMT>")
            xml.AppendLine(" <MONNUM>").Append(monnum).Append("</MONNUM>")
            xml.AppendLine(" <CUSERID>").Append(cuserid).Append("</CUSERID>")
            xml.AppendLine("</PETTTYCASHINSERTINFO>")

            Dim rxml As String = service.PettyCashInsert(xml.ToString())
            Dim msg As String = ""
            Dim PettyCash_nos As String = ""

            Dim xmlDoc As XmlDocument = New XmlDocument()
            xmlDoc.LoadXml(rxml)
            Dim status As String = xmlDoc.SelectSingleNode("/PettyCashInsertResult/Status").InnerText
            If status.ToLower() = "success" Then
                PettyCash_nos = xmlDoc.SelectSingleNode("/PettyCashInsertResult/MonNo").InnerText
            ElseIf status.ToLower() = "failure" Then
                Dim nodes As XmlNodeList = xmlDoc.SelectNodes("/PettyCashInsertResult/ErrMsgList/Error")
                For Each n As XmlNode In nodes
                    msg += n.InnerText + "\n"
                Next
            End If
            If Not String.IsNullOrEmpty(msg) Then
                Throw New FlowException(msg)
            End If

            Return PettyCash_nos
        End Function
    End Class
End Namespace