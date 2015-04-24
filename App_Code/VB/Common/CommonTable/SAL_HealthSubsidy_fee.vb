Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_HealthSubsidy_fee
        Public DAO As SAL_HealthSubsidy_feeDAO

        Public Sub New()
            DAO = New SAL_HealthSubsidy_feeDAO()
        End Sub

        Public Function GetOne(Id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(OrgCode As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, User_id, Flow_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function


        Public Sub Add(Flow_id As String, User_id As String, Unit_code As String, Apply_date As String, Apply_yy As String, _
Check_date As String, Apply_amt As Integer, Fee_source As String, Pay_date As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

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
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_yy) Then
                psList.Add(New SqlParameter("@Apply_yy", Apply_yy))
            Else
                psList.Add(New SqlParameter("@Apply_yy", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Check_date) Then
                psList.Add(New SqlParameter("@Check_date", Check_date))
            Else
                psList.Add(New SqlParameter("@Check_date", DBNull.Value))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Fee_source) Then
                psList.Add(New SqlParameter("@Fee_source", Fee_source))
            Else
                psList.Add(New SqlParameter("@Fee_source", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", DBNull.Value))
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

        Public Sub Modify(Id As Integer, Flow_id As String, User_id As String, Unit_code As String, Apply_date As String, Apply_yy As String, _
Check_date As String, Apply_amt As Integer, Fee_source As String, Pay_date As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", dr("Flow_id")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", dr("Unit_code")))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", dr("Apply_date")))
            End If
            If Not String.IsNullOrEmpty(Apply_yy) Then
                psList.Add(New SqlParameter("@Apply_yy", Apply_yy))
            Else
                psList.Add(New SqlParameter("@Apply_yy", dr("Apply_yy")))
            End If
            If Not String.IsNullOrEmpty(Check_date) Then
                psList.Add(New SqlParameter("@Check_date", Check_date))
            Else
                psList.Add(New SqlParameter("@Check_date", dr("Check_date")))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
            End If
            If Not String.IsNullOrEmpty(Fee_source) Then
                psList.Add(New SqlParameter("@Fee_source", Fee_source))
            Else
                psList.Add(New SqlParameter("@Fee_source", dr("Fee_source")))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", dr("Pay_date")))
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

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub

        Public Function getDateByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Return DAO.getDateByOrgFid(Orgcode, Flow_id)
        End Function

        Public Sub UpdateByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String, ByVal Apply_yy As String, ByVal Check_date As String, ByVal Apply_amt As Integer)
            DAO.UpdateByOrgFid(Orgcode, Flow_id, Apply_yy, Check_date, Apply_amt)
        End Sub
    End Class
End Namespace
