Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class OTH_InfoNet_Service_det
        Public DAO As OTH_InfoNet_Service_detDAO

        Public Sub New()
            DAO = New OTH_InfoNet_Service_detDAO()
        End Sub

        Public Function GetOne(Flow_id As String, id As String, OrgCode As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, id, OrgCode)
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

        Public Sub Add(OrgCode As String, Flow_id As String, direction As String, resource_ip As String, goal_ip As String, reason As String, ModUser_id As String, Mod_date As DateTime)
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
           
            If Not String.IsNullOrEmpty(direction) Then
                psList.Add(New SqlParameter("@direction", direction))
            Else
                psList.Add(New SqlParameter("@direction", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(resource_ip) Then
                psList.Add(New SqlParameter("@resource_ip", resource_ip))
            Else
                psList.Add(New SqlParameter("@resource_ip", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(goal_ip) Then
                psList.Add(New SqlParameter("@goal_ip", goal_ip))
            Else
                psList.Add(New SqlParameter("@goal_ip", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(reason) Then
                psList.Add(New SqlParameter("@reason", reason))
            Else
                psList.Add(New SqlParameter("@reason", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, id As String, OrgCode As Integer, direction As String, resource_ip As String, goal_ip As String, reason As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@id", id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(direction) Then
                psList.Add(New SqlParameter("@direction", direction))
            Else
                psList.Add(New SqlParameter("@direction", dr("direction")))
            End If
            If Not String.IsNullOrEmpty(resource_ip) Then
                psList.Add(New SqlParameter("@resource_ip", resource_ip))
            Else
                psList.Add(New SqlParameter("@resource_ip", dr("resource_ip")))
            End If
            If Not String.IsNullOrEmpty(goal_ip) Then
                psList.Add(New SqlParameter("@goal_ip", goal_ip))
            Else
                psList.Add(New SqlParameter("@goal_ip", dr("goal_ip")))
            End If
            If Not String.IsNullOrEmpty(reason) Then
                psList.Add(New SqlParameter("@reason", reason))
            Else
                psList.Add(New SqlParameter("@reason", dr("reason")))
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

        Public Sub Remove(Flow_id As String, id As String, OrgCode As Integer)
            DAO.Delete(Flow_id, id, OrgCode)
        End Sub

    End Class
End Namespace
