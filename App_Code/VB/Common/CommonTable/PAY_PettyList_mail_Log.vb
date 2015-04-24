Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_PettyList_mail_Log
        Public DAO As PAY_PettyList_mail_LogDAO

        Public Sub New()
            DAO = New PAY_PettyList_mail_LogDAO()
        End Sub

        Public Function GetOne(mail_id As Integer, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(mail_id, OrgCode)
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

        Public Sub Add(OrgCode As String, mail_type As String, mail_to As String, mail_cc As String, mail_bcc As String, mail_subject As String, mail_content As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_type) Then
                psList.Add(New SqlParameter("@mail_type", mail_type))
            Else
                psList.Add(New SqlParameter("@mail_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_to) Then
                psList.Add(New SqlParameter("@mail_to", mail_to))
            Else
                psList.Add(New SqlParameter("@mail_to", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_cc) Then
                psList.Add(New SqlParameter("@mail_cc", mail_cc))
            Else
                psList.Add(New SqlParameter("@mail_cc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_bcc) Then
                psList.Add(New SqlParameter("@mail_bcc", mail_bcc))
            Else
                psList.Add(New SqlParameter("@mail_bcc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_subject) Then
                psList.Add(New SqlParameter("@mail_subject", mail_subject))
            Else
                psList.Add(New SqlParameter("@mail_subject", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(mail_content) Then
                psList.Add(New SqlParameter("@mail_content", mail_content))
            Else
                psList.Add(New SqlParameter("@mail_content", DBNull.Value))
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

        Public Sub Modify(mail_id As Integer, OrgCode As String, mail_type As String, mail_to As String, mail_cc As String, mail_bcc As String, mail_subject As String, mail_content As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(mail_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@mail_id", mail_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(mail_type) Then
                psList.Add(New SqlParameter("@mail_type", mail_type))
            Else
                psList.Add(New SqlParameter("@mail_type", dr("mail_type")))
            End If
            If Not String.IsNullOrEmpty(mail_to) Then
                psList.Add(New SqlParameter("@mail_to", mail_to))
            Else
                psList.Add(New SqlParameter("@mail_to", dr("mail_to")))
            End If
            If Not String.IsNullOrEmpty(mail_cc) Then
                psList.Add(New SqlParameter("@mail_cc", mail_cc))
            Else
                psList.Add(New SqlParameter("@mail_cc", dr("mail_cc")))
            End If
            If Not String.IsNullOrEmpty(mail_bcc) Then
                psList.Add(New SqlParameter("@mail_bcc", mail_bcc))
            Else
                psList.Add(New SqlParameter("@mail_bcc", dr("mail_bcc")))
            End If
            If Not String.IsNullOrEmpty(mail_subject) Then
                psList.Add(New SqlParameter("@mail_subject", mail_subject))
            Else
                psList.Add(New SqlParameter("@mail_subject", dr("mail_subject")))
            End If
            If Not String.IsNullOrEmpty(mail_content) Then
                psList.Add(New SqlParameter("@mail_content", mail_content))
            Else
                psList.Add(New SqlParameter("@mail_content", dr("mail_content")))
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

        Public Sub Remove(mail_id As String, OrgCode As Integer)
            DAO.Delete(mail_id, OrgCode)
        End Sub

    End Class
End Namespace
