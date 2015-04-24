Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3104

        Public DAO As PAY3104DAO
        Public PLMDAO As PAY_LendPetty_main
        Public PPLMDAO As PAY_PettyList_mail_Log

        Public Sub New()
            DAO = New PAY3104DAO()
            PLMDAO = New PAY_LendPetty_main()
            PPLMDAO = New PAY_PettyList_mail_Log()
        End Sub

        Public Function GetCCMember(depart_id As String) As DataTable
            Return DAO.SelectCCMember(depart_id)
        End Function

        Public Function SendMail(FiscalYear_id As String, PCList_id As String, Subject As String, CCMember As String, CCMemberEmail As String) As String
            Dim dt As DataTable = PLMDAO.DAO.GetAll(LoginManager.OrgCode, FiscalYear_id, "", "", PCList_id, _
                              "", "", "", "", "", "", "", "", "", "")
            Dim result As String = String.Empty
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                result = "該零用金清單資料不存在，請重新輸入資料。"
            End If

            If String.IsNullOrEmpty(result) Then
                Subject = Subject.Replace("@機關名稱@", LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName))
                Dim SysMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                Dim SysName As String = ConfigurationManager.AppSettings("SysName").ToString()
                Dim mailPersonContent As New StringBuilder
                Dim mailContent As New StringBuilder
                mailContent.Append("<table style='border: 1px outset gray;border-collapse: separate;border-spacing: 2px;background-color: white;'><tr><th>帳號</th><th>姓名</th><th>入帳金額</th><th>備註</th><th>零用金清單-流水號</th></tr>")
                For Each dr As DataRow In dt.Rows
                    Dim BankAccount_nos As String = CommonFun.SetDataRow(dr, "BankAccount_nos")
                    Dim Email As String = CommonFun.SetDataRow(dr, "Email")
                    Dim Beneficiary_name As String = CommonFun.SetDataRow(dr, "Beneficiary_name")
                    Dim Purchase As String = (CommonFun.SetDataRow(dr, "PurchaseTotal_amt") - CommonFun.SetDataRow(dr, "Income_amt")).ToString()
                    Dim PurchaseAbstract_desc As String = CommonFun.SetDataRow(dr, "PurchaseAbstract_desc")
                    ' Dim PCList_id As String = CommonFun.SetDataRow(dr, "PCList_id")
                    Dim PettyCash_nos As String = CommonFun.SetDataRow(dr, "PettyCash_nos")
                    '整理後寄給副本
                    mailContent.Append("<tr>")
                    mailContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", BankAccount_nos))
                    mailContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", Beneficiary_name))
                    mailContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", Purchase))
                    mailContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", PurchaseAbstract_desc))
                    mailContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}-{1}</td>", PCList_id, PettyCash_nos))
                    mailContent.Append("</tr>")
                    '寄給申請人 CC副本人員
                    mailPersonContent = New StringBuilder
                    mailPersonContent.Append("<p><table style='border: 1px outset gray;border-collapse: separate;border-spacing: 2px;background-color: white;'><tr><th>帳號</th><th>姓名</th><th>入帳金額</th><th>備註</th><th>零用金清單-流水號</th></tr>")
                    mailPersonContent.Append("<tr>")
                    mailPersonContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", BankAccount_nos))
                    mailPersonContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", Beneficiary_name))
                    mailPersonContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", Purchase))
                    mailPersonContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}</td>", PurchaseAbstract_desc))
                    mailPersonContent.Append(String.Format("<td style='border: 1px outset gray;'>{0}-{1}</td>", PCList_id, PettyCash_nos))
                    mailPersonContent.Append("</tr>")
                    mailPersonContent.Append("</table></p>")
                    mailPersonContent.Append(String.Format("<p>*已於{0}年{1}月{2}日送銀行，請核對</p>", (Now.Year - 1911), Now.Month, Now.Day))
                    CommonFun.SendMail(SysMail, Email, SysName, BankAccount_nos, Subject, mailPersonContent.ToString(), "", CCMemberEmail)
                    PPLMDAO.Add(LoginManager.OrgCode, "002", Email, CCMemberEmail, "", Subject, mailPersonContent.ToString(), LoginManager.UserId, Now)
                Next
                mailContent.Append("</table>") 


                CommonFun.SendMail(SysMail, CCMemberEmail, SysName, CCMember, Subject, mailContent.ToString())
                PPLMDAO.Add(LoginManager.OrgCode, "001", CCMemberEmail, "", "", Subject, mailPersonContent.ToString(), LoginManager.UserId, Now)

            End If


            Return result

        End Function

    End Class
End Namespace
