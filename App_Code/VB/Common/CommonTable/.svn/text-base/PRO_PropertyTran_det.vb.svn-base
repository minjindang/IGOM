Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PRO_PropertyTran_det
        Public DAO As PRO_PropertyTran_detDAO

        Public Sub New()
            DAO = New PRO_PropertyTran_detDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String, Property_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode, Property_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional Property_id As String = "", Optional Property_class As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, Property_id, Property_class)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Flow_id As String, Property_id As String, Property_class As String, Property_name As String, _
OldUnit_code As String, OldKeeper_id As String, OldKeeper_name As String, OldLocation As String, OldBoss As String, _
OldProManager As String, NewUnit_code As String, NewKeeper_id As String, NewKeeper_name As String, NewLocation As String, _
NewBoss As String, NewProManager As String, Buy_date As String, Property_type As String, Fund As String, PropertyTran_date As String, Scrap_date As String, ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(Property_id) Then
                psList.Add(New SqlParameter("@Property_id", Property_id))
            Else
                psList.Add(New SqlParameter("@Property_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_class) Then
                psList.Add(New SqlParameter("@Property_class", Property_class))
            Else
                psList.Add(New SqlParameter("@Property_class", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_name) Then
                psList.Add(New SqlParameter("@Property_name", Property_name))
            Else
                psList.Add(New SqlParameter("@Property_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldUnit_code) Then
                psList.Add(New SqlParameter("@OldUnit_code", OldUnit_code))
            Else
                psList.Add(New SqlParameter("@OldUnit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldKeeper_id) Then
                psList.Add(New SqlParameter("@OldKeeper_id", OldKeeper_id))
            Else
                psList.Add(New SqlParameter("@OldKeeper_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldKeeper_name) Then
                psList.Add(New SqlParameter("@OldKeeper_name", OldKeeper_name))
            Else
                psList.Add(New SqlParameter("@OldKeeper_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldLocation) Then
                psList.Add(New SqlParameter("@OldLocation", OldLocation))
            Else
                psList.Add(New SqlParameter("@OldLocation", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldBoss) Then
                psList.Add(New SqlParameter("@OldBoss", OldBoss))
            Else
                psList.Add(New SqlParameter("@OldBoss", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OldProManager) Then
                psList.Add(New SqlParameter("@OldProManager", OldProManager))
            Else
                psList.Add(New SqlParameter("@OldProManager", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewUnit_code) Then
                psList.Add(New SqlParameter("@NewUnit_code", NewUnit_code))
            Else
                psList.Add(New SqlParameter("@NewUnit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_id) Then
                psList.Add(New SqlParameter("@NewKeeper_id", NewKeeper_id))
            Else
                psList.Add(New SqlParameter("@NewKeeper_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_name) Then
                psList.Add(New SqlParameter("@NewKeeper_name", NewKeeper_name))
            Else
                psList.Add(New SqlParameter("@NewKeeper_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewLocation) Then
                psList.Add(New SqlParameter("@NewLocation", NewLocation))
            Else
                psList.Add(New SqlParameter("@NewLocation", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewBoss) Then
                psList.Add(New SqlParameter("@NewBoss", NewBoss))
            Else
                psList.Add(New SqlParameter("@NewBoss", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(NewProManager) Then
                psList.Add(New SqlParameter("@NewProManager", NewProManager))
            Else
                psList.Add(New SqlParameter("@NewProManager", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Buy_date) Then
                psList.Add(New SqlParameter("@Buy_date", Buy_date))
            Else
                psList.Add(New SqlParameter("@Buy_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Fund) Then
                psList.Add(New SqlParameter("@Fund", Fund))
            Else
                psList.Add(New SqlParameter("@Fund", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PropertyTran_date) Then
                psList.Add(New SqlParameter("@PropertyTran_date", PropertyTran_date))
            Else
                psList.Add(New SqlParameter("@PropertyTran_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Scrap_date) Then
                psList.Add(New SqlParameter("@Scrap_date", Scrap_date))
            Else
                psList.Add(New SqlParameter("@Scrap_date", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, OrgCode As String, Property_id As String, Property_class As String, Property_name As String, _
OldUnit_code As String, OldKeeper_id As String, OldKeeper_name As String, OldLocation As String, OldBoss As String, _
OldProManager As String, NewUnit_code As String, NewKeeper_id As String, NewKeeper_name As String, NewLocation As String, _
NewBoss As String, NewProManager As String, Buy_date As String, Property_type As String, Fund As String, PropertyTran_date As String, Scrap_date As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode, Property_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@Property_id", Property_id))
            If Not String.IsNullOrEmpty(Property_class) Then
                psList.Add(New SqlParameter("@Property_class", Property_class))
            Else
                psList.Add(New SqlParameter("@Property_class", dr("Property_class")))
            End If
            If Not String.IsNullOrEmpty(Property_name) Then
                psList.Add(New SqlParameter("@Property_name", Property_name))
            Else
                psList.Add(New SqlParameter("@Property_name", dr("Property_name")))
            End If
            If Not String.IsNullOrEmpty(OldUnit_code) Then
                psList.Add(New SqlParameter("@OldUnit_code", OldUnit_code))
            Else
                psList.Add(New SqlParameter("@OldUnit_code", dr("OldUnit_code")))
            End If
            If Not String.IsNullOrEmpty(OldKeeper_id) Then
                psList.Add(New SqlParameter("@OldKeeper_id", OldKeeper_id))
            Else
                psList.Add(New SqlParameter("@OldKeeper_id", dr("OldKeeper_id")))
            End If
            If Not String.IsNullOrEmpty(OldKeeper_name) Then
                psList.Add(New SqlParameter("@OldKeeper_name", OldKeeper_name))
            Else
                psList.Add(New SqlParameter("@OldKeeper_name", dr("OldKeeper_name")))
            End If
            If Not String.IsNullOrEmpty(OldLocation) Then
                psList.Add(New SqlParameter("@OldLocation", OldLocation))
            Else
                psList.Add(New SqlParameter("@OldLocation", dr("OldLocation")))
            End If
            If Not String.IsNullOrEmpty(OldBoss) Then
                psList.Add(New SqlParameter("@OldBoss", OldBoss))
            Else
                psList.Add(New SqlParameter("@OldBoss", dr("OldBoss")))
            End If
            If Not String.IsNullOrEmpty(OldProManager) Then
                psList.Add(New SqlParameter("@OldProManager", OldProManager))
            Else
                psList.Add(New SqlParameter("@OldProManager", dr("OldProManager")))
            End If
            If Not String.IsNullOrEmpty(NewUnit_code) Then
                psList.Add(New SqlParameter("@NewUnit_code", NewUnit_code))
            Else
                psList.Add(New SqlParameter("@NewUnit_code", dr("NewUnit_code")))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_id) Then
                psList.Add(New SqlParameter("@NewKeeper_id", NewKeeper_id))
            Else
                psList.Add(New SqlParameter("@NewKeeper_id", dr("NewKeeper_id")))
            End If
            If Not String.IsNullOrEmpty(NewKeeper_name) Then
                psList.Add(New SqlParameter("@NewKeeper_name", NewKeeper_name))
            Else
                psList.Add(New SqlParameter("@NewKeeper_name", dr("NewKeeper_name")))
            End If
            If Not String.IsNullOrEmpty(NewLocation) Then
                psList.Add(New SqlParameter("@NewLocation", NewLocation))
            Else
                psList.Add(New SqlParameter("@NewLocation", dr("NewLocation")))
            End If
            If Not String.IsNullOrEmpty(NewBoss) Then
                psList.Add(New SqlParameter("@NewBoss", NewBoss))
            Else
                psList.Add(New SqlParameter("@NewBoss", dr("NewBoss")))
            End If
            If Not String.IsNullOrEmpty(NewProManager) Then
                psList.Add(New SqlParameter("@NewProManager", NewProManager))
            Else
                psList.Add(New SqlParameter("@NewProManager", dr("NewProManager")))
            End If
            If Not String.IsNullOrEmpty(Buy_date) Then
                psList.Add(New SqlParameter("@Buy_date", Buy_date))
            Else
                psList.Add(New SqlParameter("@Buy_date", dr("Buy_date")))
            End If
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", dr("Property_type")))
            End If
            If Not String.IsNullOrEmpty(Fund) Then
                psList.Add(New SqlParameter("@Fund", Fund))
            Else
                psList.Add(New SqlParameter("@Fund", dr("Fund")))
            End If
            If Not String.IsNullOrEmpty(PropertyTran_date) Then
                psList.Add(New SqlParameter("@PropertyTran_date", PropertyTran_date))
            Else
                psList.Add(New SqlParameter("@PropertyTran_date", dr("PropertyTran_date")))
            End If
            If Not String.IsNullOrEmpty(Scrap_date) Then
                psList.Add(New SqlParameter("@Scrap_date", Scrap_date))
            Else
                psList.Add(New SqlParameter("@Scrap_date", dr("Scrap_date")))
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

        Public Sub Remove(Flow_id As String, OrgCode As String, Property_id As String)
            DAO.Delete(Flow_id, OrgCode, Property_id)
        End Sub

        Public Function GetApplyPropertyId() As DataTable
            Return DAO.GetApplyPropertyId()
        End Function
    End Class
End Namespace
