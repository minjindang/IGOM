Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_DUTY_feeDtl
        Public DAO As SAL_DUTY_feeDtlDAO

        Public Sub New()
            DAO = New SAL_DUTY_feeDtlDAO()
        End Sub

        Public Function GetOne(Id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Id)
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

        Public Sub Add(main_id As Integer, Duty_date As String, Duty_sTime As String, Duty_eTime As String, Duty_Hours As String, _
ApplyHour_cnt As Integer, Apply_amt As Integer, Is_rest As String, Org_code As String, MEMO As String, ModUser_id As String, Mod_date As DateTime, _
Duty_userId As String, Duty_userUnit As String)
            Dim psList As New List(Of SqlParameter)

            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Duty_date) Then
                psList.Add(New SqlParameter("@Duty_date", Duty_date))
            Else
                psList.Add(New SqlParameter("@Duty_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Duty_sTime) Then
                psList.Add(New SqlParameter("@Duty_sTime", Duty_sTime))
            Else
                psList.Add(New SqlParameter("@Duty_sTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Duty_eTime) Then
                psList.Add(New SqlParameter("@Duty_eTime", Duty_eTime))
            Else
                psList.Add(New SqlParameter("@Duty_eTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Duty_Hours) Then
                psList.Add(New SqlParameter("@Duty_Hours", Duty_Hours))
            Else
                psList.Add(New SqlParameter("@Duty_Hours", DBNull.Value))
            End If
            If Not ApplyHour_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@ApplyHour_cnt", ApplyHour_cnt))
            Else
                psList.Add(New SqlParameter("@ApplyHour_cnt", DBNull.Value))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Is_rest) Then
                psList.Add(New SqlParameter("@Is_rest", Is_rest))
            Else
                psList.Add(New SqlParameter("@Is_rest", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MEMO) Then
                psList.Add(New SqlParameter("@MEMO", MEMO))
            Else
                psList.Add(New SqlParameter("@MEMO", DBNull.Value))
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
            If Not String.IsNullOrEmpty(Duty_userId) Then
                psList.Add(New SqlParameter("@Duty_userId", Duty_userId))
            Else
                psList.Add(New SqlParameter("@Duty_userId", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Duty_userUnit) Then
                psList.Add(New SqlParameter("@Duty_userUnit", Duty_userUnit))
            Else
                psList.Add(New SqlParameter("@Duty_userUnit", DBNull.Value))
            End If

            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Id As Integer, main_id As Integer, Duty_date As String, Duty_sTime As String, Duty_eTime As String, Duty_Hours As String, _
ApplyHour_cnt As Integer, Apply_amt As Integer, Is_rest As String, Org_code As String, MEMO As String, ModUser_id As String, Mod_date As DateTime, _
Duty_userId As String, Duty_userUnit As String)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", dr("main_id")))
            End If
            If Not String.IsNullOrEmpty(Duty_date) Then
                psList.Add(New SqlParameter("@Duty_date", Duty_date))
            Else
                psList.Add(New SqlParameter("@Duty_date", dr("Duty_date")))
            End If
            If Not String.IsNullOrEmpty(Duty_sTime) Then
                psList.Add(New SqlParameter("@Duty_sTime", Duty_sTime))
            Else
                psList.Add(New SqlParameter("@Duty_sTime", dr("Duty_sTime")))
            End If
            If Not String.IsNullOrEmpty(Duty_eTime) Then
                psList.Add(New SqlParameter("@Duty_eTime", Duty_eTime))
            Else
                psList.Add(New SqlParameter("@Duty_eTime", dr("Duty_eTime")))
            End If
            If Not String.IsNullOrEmpty(Duty_Hours) Then
                psList.Add(New SqlParameter("@Duty_Hours", Duty_Hours))
            Else
                psList.Add(New SqlParameter("@Duty_Hours", dr("Duty_Hours")))
            End If
            If Not ApplyHour_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@ApplyHour_cnt", ApplyHour_cnt))
            Else
                psList.Add(New SqlParameter("@ApplyHour_cnt", dr("ApplyHour_cnt")))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
            End If
            If Not String.IsNullOrEmpty(Is_rest) Then
                psList.Add(New SqlParameter("@Is_rest", Is_rest))
            Else
                psList.Add(New SqlParameter("@Is_rest", dr("Is_rest")))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", dr("Org_code")))
            End If
            If Not String.IsNullOrEmpty(MEMO) Then
                psList.Add(New SqlParameter("@MEMO", MEMO))
            Else
                psList.Add(New SqlParameter("@MEMO", dr("MEMO")))
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
            If Not String.IsNullOrEmpty(Duty_userId) Then
                psList.Add(New SqlParameter("@Duty_userId", Duty_userId))
            Else
                psList.Add(New SqlParameter("@Duty_userId", dr("Duty_userId")))
            End If
            If Not String.IsNullOrEmpty(Duty_userUnit) Then
                psList.Add(New SqlParameter("@Duty_userUnit", Duty_userUnit))
            Else
                psList.Add(New SqlParameter("@Duty_userUnit", dr("Duty_userUnit")))
            End If

            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub

        Public Sub RemoveByMainId(main_id As Integer)
            DAO.DeleteByMainId(main_id)
        End Sub

    End Class
End Namespace
