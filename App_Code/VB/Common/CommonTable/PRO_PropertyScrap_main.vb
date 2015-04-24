Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PRO_PropertyScrap_main
        Public DAO As PRO_PropertyScrap_mainDAO

        Public Sub New()
            DAO = New PRO_PropertyScrap_mainDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String, Property_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode, Property_id)
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

        Public Sub Add(OrgCode As String, Flow_id As String, Property_id As String, Property_clsno As String, Scrap_unit As String, _
                        Scrap_id As String, Property_name As String, Property_type As String, Location As String, LifeTime As Double, _
                        Buy_date As String, AllowScrap_date As String, Scrap_date As String, ScrapReason_type As String, ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(Property_clsno) Then
                psList.Add(New SqlParameter("@Property_clsno", Property_clsno))
            Else
                psList.Add(New SqlParameter("@Property_clsno", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Scrap_unit) Then
                psList.Add(New SqlParameter("@Scrap_unit", Scrap_unit))
            Else
                psList.Add(New SqlParameter("@Scrap_unit", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Scrap_id) Then
                psList.Add(New SqlParameter("@Scrap_id", Scrap_id))
            Else
                psList.Add(New SqlParameter("@Scrap_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_name) Then
                psList.Add(New SqlParameter("@Property_name", Property_name))
            Else
                psList.Add(New SqlParameter("@Property_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Location) Then
                psList.Add(New SqlParameter("@Location", Location))
            Else
                psList.Add(New SqlParameter("@Location", DBNull.Value))
            End If
            If Not LifeTime = Double.MinValue Then
                psList.Add(New SqlParameter("@LifeTime", LifeTime))
            Else
                psList.Add(New SqlParameter("@LifeTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Buy_date) Then
                psList.Add(New SqlParameter("@Buy_date", Buy_date))
            Else
                psList.Add(New SqlParameter("@Buy_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(AllowScrap_date) Then
                psList.Add(New SqlParameter("@AllowScrap_date", AllowScrap_date))
            Else
                psList.Add(New SqlParameter("@AllowScrap_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Scrap_date) Then
                psList.Add(New SqlParameter("@Scrap_date", Scrap_date))
            Else
                psList.Add(New SqlParameter("@Scrap_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ScrapReason_type) Then
                psList.Add(New SqlParameter("@ScrapReason_type", ScrapReason_type))
            Else
                psList.Add(New SqlParameter("@ScrapReason_type", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, OrgCode As String, Property_id As String, Property_clsno As String, Scrap_unit As String, _
                        Scrap_id As String, Property_name As String, Property_type As String, Location As String, LifeTime As Double, _
                        Buy_date As String, AllowScrap_date As String, Scrap_date As String, ScrapReason_type As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode, Property_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@Property_id", Property_id))
            If Not String.IsNullOrEmpty(Property_clsno) Then
                psList.Add(New SqlParameter("@Property_clsno", Property_clsno))
            Else
                psList.Add(New SqlParameter("@Property_clsno", dr("Property_clsno")))
            End If
            If Not String.IsNullOrEmpty(Scrap_unit) Then
                psList.Add(New SqlParameter("@Scrap_unit", Scrap_unit))
            Else
                psList.Add(New SqlParameter("@Scrap_unit", dr("Scrap_unit")))
            End If
            If Not String.IsNullOrEmpty(Scrap_id) Then
                psList.Add(New SqlParameter("@Scrap_id", Scrap_id))
            Else
                psList.Add(New SqlParameter("@Scrap_id", dr("Scrap_id")))
            End If
            If Not String.IsNullOrEmpty(Property_name) Then
                psList.Add(New SqlParameter("@Property_name", Property_name))
            Else
                psList.Add(New SqlParameter("@Property_name", dr("Property_name")))
            End If
            If Not String.IsNullOrEmpty(Property_type) Then
                psList.Add(New SqlParameter("@Property_type", Property_type))
            Else
                psList.Add(New SqlParameter("@Property_type", dr("Property_type")))
            End If
            If Not String.IsNullOrEmpty(Location) Then
                psList.Add(New SqlParameter("@Location", Location))
            Else
                psList.Add(New SqlParameter("@Location", dr("Location")))
            End If
            If Not LifeTime = Double.MinValue Then
                psList.Add(New SqlParameter("@LifeTime", LifeTime))
            Else
                psList.Add(New SqlParameter("@LifeTime", dr("LifeTime")))
            End If
            If Not String.IsNullOrEmpty(Buy_date) Then
                psList.Add(New SqlParameter("@Buy_date", Buy_date))
            Else
                psList.Add(New SqlParameter("@Buy_date", dr("Buy_date")))
            End If
            If Not String.IsNullOrEmpty(AllowScrap_date) Then
                psList.Add(New SqlParameter("@AllowScrap_date", AllowScrap_date))
            Else
                psList.Add(New SqlParameter("@AllowScrap_date", dr("AllowScrap_date")))
            End If
            If Not String.IsNullOrEmpty(Scrap_date) Then
                psList.Add(New SqlParameter("@Scrap_date", Scrap_date))
            Else
                psList.Add(New SqlParameter("@Scrap_date", dr("Scrap_date")))
            End If
            If Not String.IsNullOrEmpty(ScrapReason_type) Then
                psList.Add(New SqlParameter("@ScrapReason_type", ScrapReason_type))
            Else
                psList.Add(New SqlParameter("@ScrapReason_type", dr("ScrapReason_type")))
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

        Public Sub RemoveByFid(ByVal flow_id As String)
            DAO.DeleteByFid(flow_id)
        End Sub

        Public Function GetApplyPropertyId() As DataTable
            Return DAO.GetApplyPropertyId()
        End Function

        Public Function getMaxWsStatus(Flow_id As String, OrgCode As String) As String
            Return DAO.getMaxWsStatus(Flow_id, OrgCode)
        End Function

    End Class
End Namespace
