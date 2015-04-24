Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class MaintainerMain
        Public DAO As MaintainerMainDAO

        Public Sub New()
            DAO = New MaintainerMainDAO()
        End Sub

        Public Function GetByItem_type(MtItem_type As String, orgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectAll(orgCode, "", MtItem_type)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetByMaintain_type(Maintain_type As String, OrgCode As String) As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, Maintain_type)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Function GetOne(MaintainerPhone_nos As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(MaintainerPhone_nos, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(OrgCode As String, Optional Maintain_type As String = "", Optional MtItem_type As String = "", _
                                  Optional MtUnit_code As String = "", Optional MtUser_id As String = "", Optional MaintainerPhone_nos As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, Maintain_type, MtItem_type, MtUnit_code, MtUser_id, MaintainerPhone_nos)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, MaintainerPhone_nos As String, Maintainer_name As String, Maintain_type As String, MtItem_type As String, ModUser_id As String, Mod_date As DateTime, MtUnit_code As String, MtUser_id As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MaintainerPhone_nos) Then
                psList.Add(New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos))
            Else
                psList.Add(New SqlParameter("@MaintainerPhone_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Maintainer_name) Then
                psList.Add(New SqlParameter("@Maintainer_name", Maintainer_name))
            Else
                psList.Add(New SqlParameter("@Maintainer_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Maintain_type) Then
                psList.Add(New SqlParameter("@Maintain_type", Maintain_type))
            Else
                psList.Add(New SqlParameter("@Maintain_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", DBNull.Value))
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
            If Not String.IsNullOrEmpty(MtUnit_code) Then
                psList.Add(New SqlParameter("@MtUnit_code", MtUnit_code))
            Else
                psList.Add(New SqlParameter("@MtUnit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtUser_id) Then
                psList.Add(New SqlParameter("@MtUser_id", MtUser_id))
            Else
                psList.Add(New SqlParameter("@MtUser_id", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(MaintainerPhone_nos As String, OrgCode As String, Maintainer_name As String, Maintain_type As String, MtItem_type As String, ModUser_id As String, Mod_date As DateTime, MtUnit_code As String, MtUser_id As String)

            Dim dr As DataRow = GetOne(MaintainerPhone_nos, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(Maintainer_name) Then
                psList.Add(New SqlParameter("@Maintainer_name", Maintainer_name))
            Else
                psList.Add(New SqlParameter("@Maintainer_name", dr("Maintainer_name")))
            End If
            If Not String.IsNullOrEmpty(Maintain_type) Then
                psList.Add(New SqlParameter("@Maintain_type", Maintain_type))
            Else
                psList.Add(New SqlParameter("@Maintain_type", dr("Maintain_type")))
            End If
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", dr("MtItem_type")))
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
            If Not String.IsNullOrEmpty(MtUnit_code) Then
                psList.Add(New SqlParameter("@MtUnit_code", MtUnit_code))
            Else
                psList.Add(New SqlParameter("@MtUnit_code", dr("MtUnit_code")))
            End If
            If Not String.IsNullOrEmpty(MtUser_id) Then
                psList.Add(New SqlParameter("@MtUser_id", MtUser_id))
            Else
                psList.Add(New SqlParameter("@MtUser_id", dr("MtUser_id")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(MaintainerPhone_nos As String, OrgCode As String)
            DAO.Delete(MaintainerPhone_nos, OrgCode)
        End Sub


    End Class

End Namespace