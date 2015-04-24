Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_Bank_data
        Public DAO As PAY_Bank_dataDAO

        Public Sub New()
            DAO = New PAY_Bank_dataDAO()
        End Sub

        Public Function GetOne(Bank_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Bank_id, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional Bank_id As String = "", Optional BankAbbreviation_name As String = "", _
                                  Optional Bank_name As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, Bank_id, BankAbbreviation_name, Bank_name)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Bank_id As String, BankAbbreviation_name As String, Bank_name As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Bank_id) Then
                psList.Add(New SqlParameter("@Bank_id", Bank_id))
            Else
                psList.Add(New SqlParameter("@Bank_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BankAbbreviation_name) Then
                psList.Add(New SqlParameter("@BankAbbreviation_name", BankAbbreviation_name))
            Else
                psList.Add(New SqlParameter("@BankAbbreviation_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Bank_name) Then
                psList.Add(New SqlParameter("@Bank_name", Bank_name))
            Else
                psList.Add(New SqlParameter("@Bank_name", DBNull.Value))
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

        Public Sub Modify(Bank_id As String, OrgCode As String, BankAbbreviation_name As String, Bank_name As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Bank_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Bank_id", Bank_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(BankAbbreviation_name) Then
                psList.Add(New SqlParameter("@BankAbbreviation_name", BankAbbreviation_name))
            Else
                psList.Add(New SqlParameter("@BankAbbreviation_name", dr("BankAbbreviation_name")))
            End If
            If Not String.IsNullOrEmpty(Bank_name) Then
                psList.Add(New SqlParameter("@Bank_name", Bank_name))
            Else
                psList.Add(New SqlParameter("@Bank_name", dr("Bank_name")))
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

        Public Sub Remove(Bank_id As String, OrgCode As String)
            DAO.Delete(Bank_id, OrgCode)
        End Sub

    End Class
End Namespace
