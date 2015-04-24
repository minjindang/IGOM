Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3105 
        Public PBYDAO As PAY_Beneficiary_data
        Public PBDAO As PAY_Bank_data
        Private LPMDAO As PAY_LendPetty_main


        Public Sub New() 
            PBYDAO = New PAY_Beneficiary_data()
            PBDAO = New PAY_Bank_data()
            LPMDAO = New PAY_LendPetty_main
        End Sub

        Public Function GetAll(Beneficiary_id As String, Beneficiary_name As String, Bank_id As String, BankAccount_nos As String) As DataTable
            Dim dt As DataTable = PBYDAO.GetAll(LoginManager.OrgCode, Beneficiary_id, Beneficiary_name, Bank_id, "N", BankAccount_nos)
            Dim newDT As New DataTable
            newDT.Columns.Add(New DataColumn("Beneficiary_id"))
            newDT.Columns.Add(New DataColumn("Beneficiary_name"))
            newDT.Columns.Add(New DataColumn("Bank_id"))
            newDT.Columns.Add(New DataColumn("Bank_name"))
            newDT.Columns.Add(New DataColumn("BankAccount_nos"))

            For Each dr As DataRow In dt.Rows

                Dim newDR As DataRow = newDT.NewRow
                newDR("Beneficiary_id") = CommonFun.SetDataRow(dr, "Beneficiary_id")
                newDR("Beneficiary_name") = CommonFun.SetDataRow(dr, "Beneficiary_name")
                newDR("Bank_id") = CommonFun.SetDataRow(dr, "Bank_id")
                newDR("Bank_name") = CommonFun.SetDataRow(PBDAO.GetOne(CommonFun.SetDataRow(dr, "Bank_id"), LoginManager.OrgCode), "Bank_name")
                newDR("BankAccount_nos") = CommonFun.SetDataRow(dr, "BankAccount_nos")
                newDT.Rows.Add(newDR)

            Next

            Return newDT
        End Function

        Public Function Remove(Beneficiary_id As String) As String
            Dim msg As String = String.Empty
            Dim cnt As Integer = LPMDAO.CheckData(LoginManager.OrgCode, Beneficiary_id)

            If cnt > 0 Then
                msg = "此人員尚有零用金未匯款，即尚未製作銀行轉帳磁片，則不可刪除"
            End If
            If String.IsNullOrEmpty(msg) Then
                PBYDAO.Remove(Beneficiary_id, LoginManager.OrgCode)
            End If

            Return msg
        End Function

        Public Function Add(User_id As String, Beneficiary_name As String, Bank_id As String, Email As String, BankAccount_nos As String) As String
            Dim Beneficiary_id As String = "000001"

            If Not String.IsNullOrEmpty(User_id) Then
                Beneficiary_id = User_id        '若為員工, 以員工編號為Beneficiary_id
            Else
                Dim tmp As String = PBYDAO.GetMaxBeneficiaryId(LoginManager.OrgCode)
                If Not String.IsNullOrEmpty(tmp) Then
                    Beneficiary_id = (Convert.ToInt32(tmp) + 1).ToString().PadLeft(10, "0")
                End If
            End If

            Dim row As DataRow = PBYDAO.GetOne(Beneficiary_id, LoginManager.OrgCode)
            If row IsNot Nothing Then
                Return "已有相同的受款人"
            End If

            PBYDAO.Add(LoginManager.OrgCode, Beneficiary_id, User_id, Beneficiary_name, Bank_id, BankAccount_nos, _
                        Email, LoginManager.UserId, Now, "N")
            Return ""
        End Function

    End Class
End Namespace

