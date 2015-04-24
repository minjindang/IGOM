Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PRO_PropertyTran_main
        Public DAO As PRO_PropertyTran_mainDAO

        Public Sub New()
            DAO = New PRO_PropertyTran_mainDAO()
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

        Public Sub Add(OrgCode As String, Flow_id As String, Property_type As String, NewUnit_name As String, NewKeeper_id As String, _
NewLocation As String, ApplyTran_unit As String, ApplyTran_id As String, ModUser_id As String, Mod_date As DateTime, Fund As String)
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
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewUnit_name) Then
                psList.Add(New SqlParameter("@NewUnit_name", NewUnit_name))
            Else
                psList.Add(New SqlParameter("@NewUnit_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_id) Then
                psList.Add(New SqlParameter("@NewKeeper_id", NewKeeper_id))
            Else
                psList.Add(New SqlParameter("@NewKeeper_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewLocation) Then
                psList.Add(New SqlParameter("@NewLocation", NewLocation))
            Else
                psList.Add(New SqlParameter("@NewLocation", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ApplyTran_unit) Then
                psList.Add(New SqlParameter("@ApplyTran_unit", ApplyTran_unit))
            Else
                psList.Add(New SqlParameter("@ApplyTran_unit", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ApplyTran_id) Then
                psList.Add(New SqlParameter("@ApplyTran_id", ApplyTran_id))
            Else
                psList.Add(New SqlParameter("@ApplyTran_id", DBNull.Value))
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
            If Not String.IsNullOrEmpty(Fund) Then
                psList.Add(New SqlParameter("@Fund", Fund))
            Else
                psList.Add(New SqlParameter("@Fund", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Flow_id As String, OrgCode As String, Property_type As String, NewUnit_name As String, NewKeeper_id As String, _
NewLocation As String, ApplyTran_unit As String, ApplyTran_id As String, ModUser_id As String, Mod_date As DateTime, Fund As String)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", dr("Property_type")))
            End If
            If Not String.IsNullOrEmpty(NewUnit_name) Then
                psList.Add(New SqlParameter("@NewUnit_name", NewUnit_name))
            Else
                psList.Add(New SqlParameter("@NewUnit_name", dr("NewUnit_name")))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_id) Then
                psList.Add(New SqlParameter("@NewKeeper_id", NewKeeper_id))
            Else
                psList.Add(New SqlParameter("@NewKeeper_id", dr("NewKeeper_id")))
            End If
            If Not String.IsNullOrEmpty(NewLocation) Then
                psList.Add(New SqlParameter("@NewLocation", NewLocation))
            Else
                psList.Add(New SqlParameter("@NewLocation", dr("NewLocation")))
            End If
            If Not String.IsNullOrEmpty(ApplyTran_unit) Then
                psList.Add(New SqlParameter("@ApplyTran_unit", ApplyTran_unit))
            Else
                psList.Add(New SqlParameter("@ApplyTran_unit", dr("ApplyTran_unit")))
            End If
            If Not String.IsNullOrEmpty(ApplyTran_id) Then
                psList.Add(New SqlParameter("@ApplyTran_id", ApplyTran_id))
            Else
                psList.Add(New SqlParameter("@ApplyTran_id", dr("ApplyTran_id")))
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
            If Not String.IsNullOrEmpty(Fund) Then
                psList.Add(New SqlParameter("@Fund", Fund))
            Else
                psList.Add(New SqlParameter("@Fund", dr("Fund")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

        Public Function getMaxWsStatus(Flow_id As String, OrgCode As String) As String
            Return DAO.getMaxWsStatus(Flow_id, OrgCode)
        End Function

    End Class
End Namespace
