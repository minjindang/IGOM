Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_EDU_feeDtl
        Public DAO As SAL_EDU_feeDtlDAO

        Public Sub New()
            DAO = New SAL_EDU_feeDtlDAO()
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

        Public Sub Add(main_id As Integer, Child_id As String, Child_name As String, ChildBirth_date As String, School_type As String, _
                        School_name As String, File_att As String, Study_nos As Integer, StudyLimit_nos As Integer, Apply_amt As Integer, Org_code As String, _
                        ModUser_id As String, Mod_date As DateTime, Att_id As Integer)
            Dim psList As New List(Of SqlParameter)

            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Child_id) Then
                psList.Add(New SqlParameter("@Child_id", Child_id))
            Else
                psList.Add(New SqlParameter("@Child_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Child_name) Then
                psList.Add(New SqlParameter("@Child_name", Child_name))
            Else
                psList.Add(New SqlParameter("@Child_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ChildBirth_date) Then
                psList.Add(New SqlParameter("@ChildBirth_date", ChildBirth_date))
            Else
                psList.Add(New SqlParameter("@ChildBirth_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(School_type) Then
                psList.Add(New SqlParameter("@School_type", School_type))
            Else
                psList.Add(New SqlParameter("@School_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(School_name) Then
                psList.Add(New SqlParameter("@School_name", School_name))
            Else
                psList.Add(New SqlParameter("@School_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(File_att) Then
                psList.Add(New SqlParameter("@File_att", File_att))
            Else
                psList.Add(New SqlParameter("@File_att", DBNull.Value))
            End If
            If Not Study_nos = Integer.MinValue Then
                psList.Add(New SqlParameter("@Study_nos", Study_nos))
            Else
                psList.Add(New SqlParameter("@Study_nos", DBNull.Value))
            End If
            If Not StudyLimit_nos = Integer.MinValue Then
                psList.Add(New SqlParameter("@StudyLimit_nos", StudyLimit_nos))
            Else
                psList.Add(New SqlParameter("@StudyLimit_nos", DBNull.Value))
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

            psList.Add(New SqlParameter("@Att_id", Att_id))

            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Id As Integer, main_id As Integer, Child_id As String, Child_name As String, ChildBirth_date As String, School_type As String, _
School_name As String, File_att As String, Study_nos As Integer, StudyLimit_nos As Integer, Apply_amt As Integer, Org_code As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not main_id = Integer.MinValue Then
                psList.Add(New SqlParameter("@main_id", main_id))
            Else
                psList.Add(New SqlParameter("@main_id", dr("main_id")))
            End If
            If Not String.IsNullOrEmpty(Child_id) Then
                psList.Add(New SqlParameter("@Child_id", Child_id))
            Else
                psList.Add(New SqlParameter("@Child_id", dr("Child_id")))
            End If
            If Not String.IsNullOrEmpty(Child_name) Then
                psList.Add(New SqlParameter("@Child_name", Child_name))
            Else
                psList.Add(New SqlParameter("@Child_name", dr("Child_name")))
            End If
            If Not String.IsNullOrEmpty(ChildBirth_date) Then
                psList.Add(New SqlParameter("@ChildBirth_date", ChildBirth_date))
            Else
                psList.Add(New SqlParameter("@ChildBirth_date", dr("ChildBirth_date")))
            End If
            If Not String.IsNullOrEmpty(School_type) Then
                psList.Add(New SqlParameter("@School_type", School_type))
            Else
                psList.Add(New SqlParameter("@School_type", dr("School_type")))
            End If
            If Not String.IsNullOrEmpty(School_name) Then
                psList.Add(New SqlParameter("@School_name", School_name))
            Else
                psList.Add(New SqlParameter("@School_name", dr("School_name")))
            End If
            If Not String.IsNullOrEmpty(File_att) Then
                psList.Add(New SqlParameter("@File_att", File_att))
            Else
                psList.Add(New SqlParameter("@File_att", dr("File_att")))
            End If
            If Not Study_nos = Integer.MinValue Then
                psList.Add(New SqlParameter("@Study_nos", Study_nos))
            Else
                psList.Add(New SqlParameter("@Study_nos", dr("Study_nos")))
            End If
            If Not StudyLimit_nos = Integer.MinValue Then
                psList.Add(New SqlParameter("@StudyLimit_nos", StudyLimit_nos))
            Else
                psList.Add(New SqlParameter("@StudyLimit_nos", dr("StudyLimit_nos")))
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

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub

        Public Sub DeleteByFlowId(ByVal flow_id As String)
            DAO.DeleteByFlowId(flow_id)
        End Sub
    End Class
End Namespace
