Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class CAR_CarDispatch_det
        Public DAO As CAR_CarDispatch_detDAO

        Public Sub New()
            DAO = New CAR_CarDispatch_detDAO()
        End Sub

        Public Function GetOne(DispatchRecords_id As String, Flow_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(DispatchRecords_id, Flow_id, OrgCode)
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

        Public Sub Add(OrgCode As String, Flow_id As String, Car_id As String, Dispatch_date As String, Start_time As String, _
End_time As String, Is_return As Boolean, DriverUser_id As String, ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(Car_id) Then
                psList.Add(New SqlParameter("@Car_id", Car_id))
            Else
                psList.Add(New SqlParameter("@Car_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Dispatch_date) Then
                psList.Add(New SqlParameter("@Dispatch_date", Dispatch_date))
            Else
                psList.Add(New SqlParameter("@Dispatch_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Start_time) Then
                psList.Add(New SqlParameter("@Start_time", Start_time))
            Else
                psList.Add(New SqlParameter("@Start_time", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(End_time) Then
                psList.Add(New SqlParameter("@End_time", End_time))
            Else
                psList.Add(New SqlParameter("@End_time", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Is_return) Then
                psList.Add(New SqlParameter("@Is_return", Is_return))
            Else
                psList.Add(New SqlParameter("@Is_return", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(DriverUser_id) Then
                psList.Add(New SqlParameter("@DriverUser_id", DriverUser_id))
            Else
                psList.Add(New SqlParameter("@DriverUser_id", DBNull.Value))
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

        Public Sub Modify(DispatchRecords_id As String, Flow_id As String, OrgCode As String, Car_id As String, Dispatch_date As String, Start_time As String, _
End_time As String, Is_return As Boolean, DriverUser_id As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(DispatchRecords_id, Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@DispatchRecords_id", DispatchRecords_id))
            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(Car_id) Then
                psList.Add(New SqlParameter("@Car_id", Car_id))
            Else
                psList.Add(New SqlParameter("@Car_id", dr("Car_id")))
            End If
            If Not String.IsNullOrEmpty(Dispatch_date) Then
                psList.Add(New SqlParameter("@Dispatch_date", Dispatch_date))
            Else
                psList.Add(New SqlParameter("@Dispatch_date", dr("Dispatch_date")))
            End If
            If Not String.IsNullOrEmpty(Start_time) Then
                psList.Add(New SqlParameter("@Start_time", Start_time))
            Else
                psList.Add(New SqlParameter("@Start_time", dr("Start_time")))
            End If
            If Not String.IsNullOrEmpty(End_time) Then
                psList.Add(New SqlParameter("@End_time", End_time))
            Else
                psList.Add(New SqlParameter("@End_time", dr("End_time")))
            End If
            If Not String.IsNullOrEmpty(Is_return) Then
                psList.Add(New SqlParameter("@Is_return", Is_return))
            Else
                psList.Add(New SqlParameter("@Is_return", dr("Is_return")))
            End If
            If Not String.IsNullOrEmpty(DriverUser_id) Then
                psList.Add(New SqlParameter("@DriverUser_id", DriverUser_id))
            Else
                psList.Add(New SqlParameter("@DriverUser_id", dr("DriverUser_id")))
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

        Public Sub Remove(DispatchRecords_id As String, Flow_id As String, OrgCode As String)
            DAO.Delete(DispatchRecords_id, Flow_id, OrgCode)
        End Sub

        'DeleteByFlow_id
        Public Sub RemoveByFlow_id(Flow_id As String, OrgCode As String)
            DAO.DeleteByFlow_id(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
