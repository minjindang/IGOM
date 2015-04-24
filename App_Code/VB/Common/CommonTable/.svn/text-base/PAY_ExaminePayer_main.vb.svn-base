Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_ExaminePayer_main
        Public DAO As PAY_ExaminePayer_mainDAO

        Public Sub New()
            DAO = New PAY_ExaminePayer_mainDAO()
        End Sub

        Public Function GetOne(OrgCode As String, Payer_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(OrgCode, Payer_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional Payer_id As String = "", Optional Payer_name As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, Payer_id, Payer_name)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Payer_id As String, Payer_name As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Payer_id) Then
                psList.Add(New SqlParameter("@Payer_id", Payer_id))
            Else
                psList.Add(New SqlParameter("@Payer_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Payer_name) Then
                psList.Add(New SqlParameter("@Payer_name", Payer_name))
            Else
                psList.Add(New SqlParameter("@Payer_name", DBNull.Value))
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

        Public Sub Modify(OrgCode As String, Payer_id As String, Payer_name As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(OrgCode, Payer_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@Payer_id", Payer_id))
            If Not String.IsNullOrEmpty(Payer_name) Then
                psList.Add(New SqlParameter("@Payer_name", Payer_name))
            Else
                psList.Add(New SqlParameter("@Payer_name", dr("Payer_name")))
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

        Public Sub Remove(OrgCode As String, Payer_id As String)
            DAO.Delete(OrgCode, Payer_id)
        End Sub

    End Class
End Namespace
