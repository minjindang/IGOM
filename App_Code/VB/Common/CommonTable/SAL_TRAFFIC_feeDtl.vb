Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_TRAFFIC_feeDtl
        Public DAO As SAL_TRAFFIC_feeDtlDAO

        Public Sub New()
            DAO = New SAL_TRAFFIC_feeDtlDAO()
        End Sub

        Public Function GetOne(id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim dt As DataTable = DAO.SelectAll(main_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(main_id As Integer, Cost_date As String, Apply_amt As Integer, Apply_desc As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Cost_date) Then
                psList.Add(New SqlParameter("@Cost_date", Cost_date))
            Else
                psList.Add(New SqlParameter("@Cost_date", DBNull.Value))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_desc) Then
                psList.Add(New SqlParameter("@Apply_desc", Apply_desc))
            Else
                psList.Add(New SqlParameter("@Apply_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", DBNull.Value))
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

        Public Sub Modify(id As Integer, main_id As Integer, Cost_date As String, Apply_amt As Integer, Apply_desc As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@id", id))
            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", dr("main_id")))
            End If
            If Not String.IsNullOrEmpty(Cost_date) Then
                psList.Add(New SqlParameter("@Cost_date", Cost_date))
            Else
                psList.Add(New SqlParameter("@Cost_date", dr("Cost_date")))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
            End If
            If Not String.IsNullOrEmpty(Apply_desc) Then
                psList.Add(New SqlParameter("@Apply_desc", Apply_desc))
            Else
                psList.Add(New SqlParameter("@Apply_desc", dr("Apply_desc")))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", dr("Org_code")))
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

        Public Sub Remove(id As Integer)
            DAO.Delete(id)
        End Sub

        Public Function DeleteByMainId(mainId As Integer) As Boolean
            Return DAO.DeleteByMainId(mainId) > 0
        End Function
    End Class
End Namespace
