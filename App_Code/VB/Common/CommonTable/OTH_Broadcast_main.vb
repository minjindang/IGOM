Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class OTH_Broadcast_main
        Public DAO As OTH_Broadcast_mainDAO

        Public Sub New()
            DAO = New OTH_Broadcast_mainDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode)
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

        Public Sub Add(OrgCode As String, Flow_id As String, User_id As String, User_unit As String, broadcast_date1 As String, _
broadcast_time1 As String, broadcast_date2 As String, broadcast_time2 As String, broadcast_floors As String, broadcast_content As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_unit) Then
                psList.Add(New SqlParameter("@User_unit", User_unit))
            Else
                psList.Add(New SqlParameter("@User_unit", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_date1) Then
                psList.Add(New SqlParameter("@broadcast_date1", broadcast_date1))
            Else
                psList.Add(New SqlParameter("@broadcast_date1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_time1) Then
                psList.Add(New SqlParameter("@broadcast_time1", broadcast_time1))
            Else
                psList.Add(New SqlParameter("@broadcast_time1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_date2) Then
                psList.Add(New SqlParameter("@broadcast_date2", broadcast_date2))
            Else
                psList.Add(New SqlParameter("@broadcast_date2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_time2) Then
                psList.Add(New SqlParameter("@broadcast_time2", broadcast_time2))
            Else
                psList.Add(New SqlParameter("@broadcast_time2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_floors) Then
                psList.Add(New SqlParameter("@broadcast_floors", broadcast_floors))
            Else
                psList.Add(New SqlParameter("@broadcast_floors", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(broadcast_content) Then
                psList.Add(New SqlParameter("@broadcast_content", broadcast_content))
            Else
                psList.Add(New SqlParameter("@broadcast_content", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, OrgCode As String, User_id As String, User_unit As String, broadcast_date1 As String, _
broadcast_time1 As String, broadcast_date2 As String, broadcast_time2 As String, broadcast_floors As String, broadcast_content As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(User_unit) Then
                psList.Add(New SqlParameter("@User_unit", User_unit))
            Else
                psList.Add(New SqlParameter("@User_unit", dr("User_unit")))
            End If
            If Not String.IsNullOrEmpty(broadcast_date1) Then
                psList.Add(New SqlParameter("@broadcast_date1", broadcast_date1))
            Else
                psList.Add(New SqlParameter("@broadcast_date1", dr("broadcast_date1")))
            End If
            If Not String.IsNullOrEmpty(broadcast_time1) Then
                psList.Add(New SqlParameter("@broadcast_time1", broadcast_time1))
            Else
                psList.Add(New SqlParameter("@broadcast_time1", dr("broadcast_time1")))
            End If
            If Not String.IsNullOrEmpty(broadcast_date2) Then
                psList.Add(New SqlParameter("@broadcast_date2", broadcast_date2))
            Else
                psList.Add(New SqlParameter("@broadcast_date2", dr("broadcast_date2")))
            End If
            If Not String.IsNullOrEmpty(broadcast_time2) Then
                psList.Add(New SqlParameter("@broadcast_time2", broadcast_time2))
            Else
                psList.Add(New SqlParameter("@broadcast_time2", dr("broadcast_time2")))
            End If
            If Not String.IsNullOrEmpty(broadcast_floors) Then
                psList.Add(New SqlParameter("@broadcast_floors", broadcast_floors))
            Else
                psList.Add(New SqlParameter("@broadcast_floors", dr("broadcast_floors")))
            End If
            If Not String.IsNullOrEmpty(broadcast_content) Then
                psList.Add(New SqlParameter("@broadcast_content", broadcast_content))
            Else
                psList.Add(New SqlParameter("@broadcast_content", dr("broadcast_content")))
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

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
