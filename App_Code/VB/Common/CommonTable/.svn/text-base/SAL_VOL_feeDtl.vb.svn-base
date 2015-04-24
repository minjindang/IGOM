Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_VOL_feeDtl
        Public DAO As SAL_VOL_feeDtlDAO

        Public Sub New()
            DAO = New SAL_VOL_feeDtlDAO()
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


        Public Sub Add(main_id As Integer, vol_user_id As String, Apply_amt As Integer, Org_code As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(vol_user_id) Then
                psList.Add(New SqlParameter("@vol_user_id", vol_user_id))
            Else
                psList.Add(New SqlParameter("@vol_user_id", DBNull.Value))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", DBNull.Value))
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

        Public Sub Modify(id As Integer, main_id As Integer, vol_user_id As String, Apply_amt As Integer, Org_code As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@id", id))
            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", dr("main_id")))
            End If
            If Not String.IsNullOrEmpty(vol_user_id) Then
                psList.Add(New SqlParameter("@vol_user_id", vol_user_id))
            Else
                psList.Add(New SqlParameter("@vol_user_id", dr("vol_user_id")))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
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
        Public Sub RemoveMainId(mainid As String)
            DAO.RemoveMainId(mainid)
        End Sub
        '1030528_Ray
        Public Function getDataByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Return DAO.getDataByOrgFid(Orgcode, Flow_id)
        End Function
        '1030619_Ray
        Public Sub DeleteAfterModify(idcard As String, mainid As String)
            DAO.DeleteAfterModify(idcard, mainid)
        End Sub
    End Class
End Namespace
