Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class PAY3106

        Public PBDAO As PAY_Bank_data
        Private PBYDAO As PAY_Beneficiary_data

        Public Sub New()
            PBDAO = New PAY_Bank_data()
            PBYDAO = New PAY_Beneficiary_data()
        End Sub

        Public Function Remove(Bank_id As String) As String
            Dim msg As String = String.Empty
            Dim dt As DataTable = PBYDAO.GetAll(LoginManager.OrgCode, "", "", Bank_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                msg = "此銀行資料尚存在受款人資料中，不可刪除"
            End If
            If String.IsNullOrEmpty(msg) Then
                PBDAO.Remove(Bank_id, LoginManager.OrgCode)
            End If

            Return msg
        End Function

        Public Function Add(Bank_id As String, BankAbbreviation_name As String, Bank_name As String) As String
            Try
                Dim msg As String = CheckBank_id(Bank_id)
                If String.IsNullOrEmpty(msg) Then
                    PBDAO.Add(LoginManager.OrgCode, Bank_id, BankAbbreviation_name, Bank_name, LoginManager.UserId, Now)
                End If

                Return msg
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function Modify(Bank_id As String, BankAbbreviation_name As String, Bank_name As String) As String
            Try
                PBDAO.Modify(Bank_id, LoginManager.OrgCode, BankAbbreviation_name, Bank_name, LoginManager.UserId, Now)
                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Private Function CheckBank_id(Payer_id As String) As String
            Dim msg As String = String.Empty

            Dim dt As DataTable = PBDAO.GetAll(Payer_id)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt = PBDAO.GetAll()
                dt.DefaultView.Sort = "Bank_id desc"
                dt = dt.DefaultView.ToTable()
                msg = String.Format("此銀行資料已存在，不可重覆輸入(可用代號:{0})。", (Convert.ToInt32(dt.Rows(0)("Bank_id")) + 1).ToString().PadLeft(4, "0"))
            End If
            Return msg
        End Function

    End Class

End Namespace
