Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class ElecMaintain_main
        Public DAO As ElecMaintain_mainDAO

        Public Sub New()
            DAO = New ElecMaintain_mainDAO()
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

        Public Sub Add(OrgCode As String, Flow_id As String, Phone_nos As String, Unit_code As String, User_id As String, _
                        User_name As String, ApplyTime As DateTime, Attachment As String, Memo As String, CaseClose_type As String, _
                        ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                psList.Add(New SqlParameter("@User_name", User_name))
            Else
                psList.Add(New SqlParameter("@User_name", DBNull.Value))
            End If
            If Not ApplyTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ApplyTime", ApplyTime))
            Else
                psList.Add(New SqlParameter("@ApplyTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Attachment) Then
                psList.Add(New SqlParameter("@Attachment", Attachment))
            Else
                psList.Add(New SqlParameter("@Attachment", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(CaseClose_type) Then
                psList.Add(New SqlParameter("@CaseClose_type", CaseClose_type))
            Else
                psList.Add(New SqlParameter("@CaseClose_type", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, OrgCode As String, Phone_nos As String, Unit_code As String, User_id As String, _
                        User_name As String, ApplyTime As DateTime, Attachment As String, Memo As String, CaseClose_type As String, _
                        ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", dr("Phone_nos")))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", dr("Unit_code")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                psList.Add(New SqlParameter("@User_name", User_name))
            Else
                psList.Add(New SqlParameter("@User_name", dr("User_name")))
            End If
            If Not ApplyTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ApplyTime", ApplyTime))
            Else
                psList.Add(New SqlParameter("@ApplyTime", dr("ApplyTime")))
            End If
            If Not String.IsNullOrEmpty(Attachment) Then
                psList.Add(New SqlParameter("@Attachment", Attachment))
            Else
                psList.Add(New SqlParameter("@Attachment", dr("Attachment")))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", dr("Memo")))
            End If
            If Not String.IsNullOrEmpty(CaseClose_type) Then
                psList.Add(New SqlParameter("@CaseClose_type", CaseClose_type))
            Else
                psList.Add(New SqlParameter("@CaseClose_type", dr("CaseClose_type")))
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

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
