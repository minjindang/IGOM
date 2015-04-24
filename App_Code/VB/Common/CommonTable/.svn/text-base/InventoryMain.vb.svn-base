Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class InventoryMain
        Public DAO As InventoryMainDAO

        Public Sub New()
            DAO = New InventoryMainDAO()
        End Sub

        Public Function GetMemoMsg(orgcode As String) As String
            Dim msg As String = ""
            Dim imDAO As New InventoryMain()
            Dim InventoryDR As DataRow = imDAO.GetMemoStar(LoginManager.OrgCode)
            If Not InventoryDR Is Nothing Then
                msg = "物料盤點中,此作業暫停使用,預計盤點日期：" & InventoryDR("InvStart_date").ToString() & "至" & InventoryDR("Expected_date").ToString()
            End If
            Return msg
        End Function

        Public Function GetMemoStar(orgCode As String) As DataRow
            Dim dt As DataTable = DAO.GetMemoStar(orgCode)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
        End Function

        Public Sub Insert(orgCode As String, InvStart_date As String, Expected_date As String, InvEnd_date As String, InvMemo As String, _
                          InvClosing_ym As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)
            psList.Add(New SqlParameter("@OrgCode", orgCode))
            psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            psList.Add(New SqlParameter("@Mod_date", Mod_date))

            If Not String.IsNullOrEmpty(InvStart_date) Then
                psList.Add(New SqlParameter("@InvStart_date", InvStart_date))
            Else
                psList.Add(New SqlParameter("@InvStart_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(Expected_date) Then
                psList.Add(New SqlParameter("@Expected_date", Expected_date))
            Else
                psList.Add(New SqlParameter("@Expected_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvEnd_date) Then
                psList.Add(New SqlParameter("@InvEnd_date", InvEnd_date))
            Else
                psList.Add(New SqlParameter("@InvEnd_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvMemo) Then
                psList.Add(New SqlParameter("@InvMemo", InvMemo))
            Else
                psList.Add(New SqlParameter("@InvMemo", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvClosing_ym) Then
                psList.Add(New SqlParameter("@InvClosing_ym", InvClosing_ym))
            Else
                psList.Add(New SqlParameter("@InvClosing_ym", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Update(orgCode As String, Inventory_id As Integer, InvStart_date As String, Expected_date As String, InvEnd_date As String, InvMemo As String, _
                          InvClosing_ym As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)
            psList.Add(New SqlParameter("@OrgCode", orgCode))
            psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            psList.Add(New SqlParameter("@Mod_date", Mod_date))
            psList.Add(New SqlParameter("@Inventory_id", Inventory_id))

            If Not String.IsNullOrEmpty(InvStart_date) Then
                psList.Add(New SqlParameter("@InvStart_date", InvStart_date))
            Else
                psList.Add(New SqlParameter("@InvStart_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(Expected_date) Then
                psList.Add(New SqlParameter("@Expected_date", Expected_date))
            Else
                psList.Add(New SqlParameter("@Expected_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvEnd_date) Then
                psList.Add(New SqlParameter("@InvEnd_date", InvEnd_date))
            Else
                psList.Add(New SqlParameter("@InvEnd_date", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvMemo) Then
                psList.Add(New SqlParameter("@InvMemo", InvMemo))
            Else
                psList.Add(New SqlParameter("@InvMemo", DBNull.Value))
            End If

            If Not String.IsNullOrEmpty(InvClosing_ym) Then
                psList.Add(New SqlParameter("@InvClosing_ym", InvClosing_ym))
            Else
                psList.Add(New SqlParameter("@InvClosing_ym", DBNull.Value))
            End If


            DAO.Update(psList.ToArray())
        End Sub

    End Class
End Namespace
