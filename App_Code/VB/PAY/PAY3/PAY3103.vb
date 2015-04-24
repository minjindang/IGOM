Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Xml
Imports System.Transactions

Namespace FSCPLM.Logic
    Public Class PAY3103

        Private LPMDAO As PAY_LendPetty_main
        Private PPLDAO As PAY_PettyList_main
        Private SCDAO As SACode
        Private DAO As PAY3103DAO
        Private service As PettyCashWebService.PettyCash1SoapClient

        Public Sub New()
            LPMDAO = New PAY_LendPetty_main()
            PPLDAO = New PAY_PettyList_main()
            SCDAO = New SACode()
            DAO = New PAY3103DAO()
        End Sub

        Public Function Get310301(FiscalYear_id As String, PettyCash_type As String, PCList_id As String, PettyCash_nosS As String, _
                                 PettyCash_nosE As String, Prepay_idS As String, Prepay_idE As String, WriteOff_date As String) As DataTable
            Dim dt As DataTable = DAO.SelectPAY310101(LoginManager.OrgCode, FiscalYear_id, PettyCash_type, PCList_id, PettyCash_nosS, PettyCash_nosE, _
                                                      Prepay_idS, Prepay_idE, WriteOff_date)
            dt.Columns.Add(New DataColumn("TotalSIncome"))

            For Each dr As DataRow In dt.Rows
                dr("TotalSIncome") = CommonFun.SetDataRow(dr, "PurchaseTotal_amt1") - CommonFun.SetDataRow(dr, "Income_amt1")
            Next
            Return dt
        End Function

        Public Function Get310302(FiscalYear_id As String, PettyCash_type As String, PettyCash_nosS As String, _
                                  PettyCash_nosE As String, Prepay_idS As String, Prepay_idE As String) As DataTable

            Dim dt As DataTable = DAO.GetAll(LoginManager.OrgCode, FiscalYear_id, Prepay_idS, Prepay_idE, PettyCash_nosS, PettyCash_nosE, PettyCash_type)

            dt.Columns.Add(New DataColumn("TotalSIncome"))

            For Each dr As DataRow In dt.Rows
                dr("TotalSIncome") = CommonFun.SetDataRow(dr, "PurchaseTotal_amt1") - CommonFun.SetDataRow(dr, "Income_amt2")
            Next

            dt.DefaultView.Sort = "PettyCash_nos"

            Return dt
        End Function

        Public Function Done(FiscalYear_id As String, PettyCash_type As String, PCList_id As String, WriteOff_date As String, LendPettyDT As DataTable) As String
            Dim msg As String = String.Empty
            Dim PettyCashStart_nos As String = CommonFun.SetDataRow(LendPettyDT.Rows(0), "PettyCash_nos")
            Dim PettyCashEnd_nos As String = CommonFun.SetDataRow(LendPettyDT.Rows(0), "PettyCash_nos")
            Dim PrepayStart_nos As String = CommonFun.SetDataRow(LendPettyDT.Rows(0), "Prepay_id")
            Dim PrepayEnd_nos As String = CommonFun.SetDataRow(LendPettyDT.Rows(0), "Prepay_id")
            Dim PayBalances_amt As Double = 0
            Dim LastBalances_amt As Double = 0
            Dim i As Integer = 0
            Dim bll As New PAY3102()

            Using scope As New TransactionScope

                'call webservice
                For Each dr As DataRow In LendPettyDT.Rows
                    Dim PettyCash_nos As String = dr("PettyCash_nos").ToString()    '零用金流水號
                    Dim Prepay_id As String = dr("Prepay_id").ToString()

                    If bll.IsNewGeneration(LoginManager.OrgCode) AndAlso PettyCash_type = "001" AndAlso String.IsNullOrEmpty(PettyCash_nos) Then
                        '二代會計系統介接 and 預借
                        PettyCash_nos = bll.PettyCashInsert(dr("FiscalYear_id").ToString(), dr("PurchaseForm_id").ToString(), _
                                                            dr("PurchaseForm_sn").ToString(), dr("Invoice_date").ToString(), _
                                                            dr("Beneficiary_id").ToString(), dr("Beneficiary_name").ToString(), _
                                                            dr("Middleman_id").ToString(), dr("Middleman_name").ToString(), _
                                                            dr("Use_type").ToString(), dr("PurchaseAbstract_desc").ToString(), _
                                                            dr("PurchaseTotal_amt").ToString(), dr("Receipt_cnt").ToString(), _
                                                            LoginManager.ADId)
                    End If

                    If i = 0 Then
                        PettyCashStart_nos = PettyCash_nos
                        PrepayStart_nos = Prepay_id
                    End If
                    If i = LendPettyDT.Rows.Count - 1 Then
                        PettyCashEnd_nos = PettyCash_nos
                        PrepayEnd_nos = Prepay_id
                    End If

                    i += 1
                Next

                If bll.IsNewGeneration(LoginManager.OrgCode) Then
                    '二代會計系統介接 
                    PettyCashListInsert(FiscalYear_id, _
                                        PCList_id, _
                                        PettyCashStart_nos, _
                                        PettyCashEnd_nos, _
                                        LastBalances_amt, _
                                        LastBalances_amt - PayBalances_amt, _
                                        LoginManager.ADId)
                End If



                'insert data 
                For Each dr As DataRow In LendPettyDT.Rows
                    Dim PettyCash_nos As String = dr("PettyCash_nos").ToString()    '零用金流水號
                    Dim Prepay_id As String = dr("Prepay_id").ToString()

                    PayBalances_amt += CommonFun.SetDataRow(dr, "TotalSIncome") '墊付款支出

                    If i = 0 Then
                        PettyCashStart_nos = PettyCash_nos
                        PrepayStart_nos = Prepay_id
                    End If
                    If i = LendPettyDT.Rows.Count - 1 Then
                        PettyCashEnd_nos = PettyCash_nos
                        PrepayEnd_nos = Prepay_id
                    End If

                    ModifyLandPetty(PCList_id, PettyCash_nos, WriteOff_date, CommonFun.SetDataRow(dr, "SerialNumber_id"))
                    i += 1
                Next

                LastBalances_amt = GetLastBalances_amt(LoginManager.OrgCode, FiscalYear_id)    '上期結存金額

                PPLDAO.Add(LoginManager.OrgCode, FiscalYear_id, PCList_id, PettyCash_type, PettyCashStart_nos, PettyCashEnd_nos, PrepayStart_nos, PrepayEnd_nos, _
                            LastBalances_amt - PayBalances_amt, LastBalances_amt, PayBalances_amt, "", "", LoginManager.UserId, Now)

                scope.Complete()
            End Using

            Return msg
        End Function

        Private Sub ModifyLandPetty(PCList_id As String, PettyCash_nos As String, WriteOff_date As String, SerialNumber_id As Integer)

            LPMDAO.Modify(SerialNumber_id, LoginManager.OrgCode, "", "", PettyCash_nos, "", PCList_id, "", "", "", "", "", Double.MinValue, Double.MinValue, "", Double.MinValue, _
                         WriteOff_date, "", "", Double.MinValue, "", LoginManager.UserId, Now, "", "")
        End Sub

        Public Function GetLastBalances_amt(OrgCode As String, FiscalYear_id As String) As Double
            Return DAO.SelectLastBalances_amt(OrgCode, FiscalYear_id)
        End Function

        Public Function GetPCList_id(FiscalYear_id As String) As DataTable
            Return DAO.GetPCList_id(FiscalYear_id)
        End Function


        ''' <summary>
        ''' 零用金清單新增
        ''' </summary>
        ''' <param name="LSTYEAR">會計年度</param>
        ''' <param name="LSTNO">零用金清單編號</param>
        ''' <param name="LSTMONNOFR">起始零用金流水號</param>
        ''' <param name="LSTMONNOTO">終了零用金流水號</param>
        ''' <param name="LSTLAMT">上期結存金額</param>
        ''' <param name="LSTRCVAMT">本期收入金額</param>
        ''' <param name="CUSERID">修改者代號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PettyCashListInsert(LSTYEAR As String, _
                                            LSTNO As String, _
                                            LSTMONNOFR As String, _
                                            LSTMONNOTO As String, _
                                            LSTLAMT As String, _
                                            LSTRCVAMT As String, _
                                            CUSERID As String) As String
            service = New PettyCashWebService.PettyCash1SoapClient("PettyCash1Soap")
            Dim xml As New StringBuilder()
            xml.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            xml.AppendLine("<PETTYCASHLISTINSERTINFO>")
            xml.AppendLine("  <LSTYEAR>").Append(LSTYEAR).Append("</LSTYEAR>")
            xml.AppendLine("  <LSTNO>").Append(LSTNO).Append("</LSTNO>")
            xml.AppendLine("  <LSTMONNOFR>").Append(LSTMONNOFR).Append("</LSTMONNOFR>")
            xml.AppendLine("  <LSTMONNOTO>").Append(LSTMONNOTO).Append("</LSTMONNOTO>")
            xml.AppendLine("  <LSTLAMT>").Append(LSTLAMT).Append("</LSTLAMT>")
            xml.AppendLine("  <LSTRCVAMT>").Append(LSTRCVAMT).Append("</LSTRCVAMT>")
            xml.AppendLine("  <CUSERID>").Append(CUSERID).Append("</CUSERID>")
            xml.AppendLine("</PETTYCASHLISTINSERTINFO>")

            Dim rxml As String = service.PettyCashListInsert(xml.ToString())
            Dim msg As String = ""
            Dim PCList_id As String = ""

            Dim xmlDoc As XmlDocument = New XmlDocument()
            xmlDoc.LoadXml(rxml)
            Dim status As String = xmlDoc.SelectSingleNode("/PettyCashListInsertResult/Status").InnerText
            If status.ToLower() = "success" Then
                PCList_id = xmlDoc.SelectSingleNode("/PettyCashListInsertResult/LSTNO").InnerText
            ElseIf status.ToLower() = "failure" Then
                Dim nodes As XmlNodeList = xmlDoc.SelectNodes("/PettyCashListInsertResult/ErrMsgList/ERROR")
                For Each n As XmlNode In nodes
                    msg += n.InnerText + "\n"
                Next
            End If
            If Not String.IsNullOrEmpty(msg) Then
                Throw New FlowException(msg)
            End If
            Return PCList_id
        End Function
    End Class
End Namespace