Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_EDU_Setting
        Public DAO As SAL_EDU_SettingDAO

        Public Sub New()
            DAO = New SAL_EDU_SettingDAO()
        End Sub

        Public Function GetOne(Id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional Org_code As String = "", Optional Apply_Type As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(Org_code, Apply_Type)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(Apply_type As String, AcademicYear As String, Semester As String, Apply_sDate As String, Apply_sTime As String, _
Apply_eDate As String, Apply_eTime As String, Status As String, ModUser_id As String, Mod_date As DateTime, Org_code As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Apply_type) Then
                psList.Add(New SqlParameter("@Apply_type", Apply_type))
            Else
                psList.Add(New SqlParameter("@Apply_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(AcademicYear) Then
                psList.Add(New SqlParameter("@AcademicYear", AcademicYear))
            Else
                psList.Add(New SqlParameter("@AcademicYear", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Semester) Then
                psList.Add(New SqlParameter("@Semester", Semester))
            Else
                psList.Add(New SqlParameter("@Semester", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_sDate) Then
                psList.Add(New SqlParameter("@Apply_sDate", Apply_sDate))
            Else
                psList.Add(New SqlParameter("@Apply_sDate", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_sTime) Then
                psList.Add(New SqlParameter("@Apply_sTime", Apply_sTime))
            Else
                psList.Add(New SqlParameter("@Apply_sTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_eDate) Then
                psList.Add(New SqlParameter("@Apply_eDate", Apply_eDate))
            Else
                psList.Add(New SqlParameter("@Apply_eDate", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_eTime) Then
                psList.Add(New SqlParameter("@Apply_eTime", Apply_eTime))
            Else
                psList.Add(New SqlParameter("@Apply_eTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Status) Then
                psList.Add(New SqlParameter("@Status", Status))
            Else
                psList.Add(New SqlParameter("@Status", DBNull.Value))
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
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Id As Integer, Apply_type As String, AcademicYear As String, Semester As String, Apply_sDate As String, Apply_sTime As String, _
Apply_eDate As String, Apply_eTime As String, Status As String, ModUser_id As String, Mod_date As DateTime, Org_code As String)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not String.IsNullOrEmpty(Apply_type) Then
                psList.Add(New SqlParameter("@Apply_type", Apply_type))
            Else
                psList.Add(New SqlParameter("@Apply_type", dr("Apply_type")))
            End If
            If Not String.IsNullOrEmpty(AcademicYear) Then
                psList.Add(New SqlParameter("@AcademicYear", AcademicYear))
            Else
                psList.Add(New SqlParameter("@AcademicYear", dr("AcademicYear")))
            End If
            If Not String.IsNullOrEmpty(Semester) Then
                psList.Add(New SqlParameter("@Semester", Semester))
            Else
                psList.Add(New SqlParameter("@Semester", dr("Semester")))
            End If
            If Not String.IsNullOrEmpty(Apply_sDate) Then
                psList.Add(New SqlParameter("@Apply_sDate", Apply_sDate))
            Else
                psList.Add(New SqlParameter("@Apply_sDate", dr("Apply_sDate")))
            End If
            If Not String.IsNullOrEmpty(Apply_sTime) Then
                psList.Add(New SqlParameter("@Apply_sTime", Apply_sTime))
            Else
                psList.Add(New SqlParameter("@Apply_sTime", dr("Apply_sTime")))
            End If
            If Not String.IsNullOrEmpty(Apply_eDate) Then
                psList.Add(New SqlParameter("@Apply_eDate", Apply_eDate))
            Else
                psList.Add(New SqlParameter("@Apply_eDate", dr("Apply_eDate")))
            End If
            If Not String.IsNullOrEmpty(Apply_eTime) Then
                psList.Add(New SqlParameter("@Apply_eTime", Apply_eTime))
            Else
                psList.Add(New SqlParameter("@Apply_eTime", dr("Apply_eTime")))
            End If
            If Not String.IsNullOrEmpty(Status) Then
                psList.Add(New SqlParameter("@Status", Status))
            Else
                psList.Add(New SqlParameter("@Status", dr("Status")))
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
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", dr("Org_code")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub

    End Class
End Namespace
