Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_Beneficiary_data
        Public DAO As PAY_Beneficiary_dataDAO

        Public Sub New()
            DAO = New PAY_Beneficiary_dataDAO()
        End Sub

        Public Function GetAll(Optional OrgCode As String = "", Optional Beneficiary_id As String = "", _
                               Optional Beneficiary_name As String = "", Optional Bank_id As String = "", _
                               Optional isDel As String = "N", Optional BankAccount_nos As String = "") As DataTable
            Return DAO.SelectAll(OrgCode, Beneficiary_id, Beneficiary_name, Bank_id, isDel, BankAccount_nos)
        End Function


        Public Function GetOne(Beneficiary_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Beneficiary_id, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function 

        Public Sub Add(OrgCode As String, Beneficiary_id As String, User_id As String, Beneficiary_name As String, Bank_id As String, _
                        BankAccount_nos As String, Email As String, ModUser_id As String, Mod_date As DateTime, isDel As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Beneficiary_id) Then
                psList.Add(New SqlParameter("@Beneficiary_id", Beneficiary_id))
            Else
                psList.Add(New SqlParameter("@Beneficiary_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Beneficiary_name) Then
                psList.Add(New SqlParameter("@Beneficiary_name", Beneficiary_name))
            Else
                psList.Add(New SqlParameter("@Beneficiary_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Bank_id) Then
                psList.Add(New SqlParameter("@Bank_id", Bank_id))
            Else
                psList.Add(New SqlParameter("@Bank_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BankAccount_nos) Then
                psList.Add(New SqlParameter("@BankAccount_nos", BankAccount_nos))
            Else
                psList.Add(New SqlParameter("@BankAccount_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Email) Then
                psList.Add(New SqlParameter("@Email", Email))
            Else
                psList.Add(New SqlParameter("@Email", DBNull.Value))
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
            If Not String.IsNullOrEmpty(isDel) Then
                psList.Add(New SqlParameter("@isDel", isDel))
            Else
                psList.Add(New SqlParameter("@isDel", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Beneficiary_id As String, OrgCode As String, User_id As String, Beneficiary_name As String, Bank_id As String, _
                            BankAccount_nos As String, Email As String, ModUser_id As String, Mod_date As DateTime, isDel As String)

            Dim dr As DataRow = GetOne(Beneficiary_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Beneficiary_id", Beneficiary_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Beneficiary_name) Then
                psList.Add(New SqlParameter("@Beneficiary_name", Beneficiary_name))
            Else
                psList.Add(New SqlParameter("@Beneficiary_name", dr("Beneficiary_name")))
            End If
            If Not String.IsNullOrEmpty(Bank_id) Then
                psList.Add(New SqlParameter("@Bank_id", Bank_id))
            Else
                psList.Add(New SqlParameter("@Bank_id", dr("Bank_id")))
            End If
            If Not String.IsNullOrEmpty(BankAccount_nos) Then
                psList.Add(New SqlParameter("@BankAccount_nos", BankAccount_nos))
            Else
                psList.Add(New SqlParameter("@BankAccount_nos", dr("BankAccount_nos")))
            End If
            If Not String.IsNullOrEmpty(Email) Then
                psList.Add(New SqlParameter("@Email", Email))
            Else
                psList.Add(New SqlParameter("@Email", dr("Email")))
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
            If Not String.IsNullOrEmpty(isDel) Then
                psList.Add(New SqlParameter("@isDel", isDel))
            Else
                psList.Add(New SqlParameter("@isDel", dr("isDel")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Beneficiary_id As String, OrgCode As String)
            DAO.Delete(Beneficiary_id, OrgCode)
        End Sub

        Public Function GetMaxBeneficiaryId(orgcode As String) As String
            Return DAO.GetMaxBeneficiaryId(orgcode).ToString()
        End Function
    End Class

End Namespace
