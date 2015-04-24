Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class ElecMaintain_det
        Public DAO As ElecMaintain_detDAO

        Public Sub New()
            DAO = New ElecMaintain_detDAO()
        End Sub

        Public Function GetOne(Flow_id As String, MtClass_type As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, MtClass_type, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional OrgCode As String = "", Optional Flow_id As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, Flow_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Flow_id As String, MtItem_type As String, MtClass_type As String, ElecExpect_type As String, _
                        MtItemOther_desc As String, Problem_desc As String, MtStartTime As DateTime, MtEndTime As DateTime, MtTime As Double, _
                        MaintainerPhone_nos As String, Maintainer_name As String, MtStatus_type As String, MtStatus_desc As String, Satisfaction_type As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@MtClass_type", MtClass_type))

           
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", DBNull.Value))
            End If 
            If Not String.IsNullOrEmpty(ElecExpect_type) Then
                psList.Add(New SqlParameter("@ElecExpect_type", ElecExpect_type))
            Else
                psList.Add(New SqlParameter("@ElecExpect_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtItemOther_desc) Then
                psList.Add(New SqlParameter("@MtItemOther_desc", MtItemOther_desc))
            Else
                psList.Add(New SqlParameter("@MtItemOther_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Problem_desc) Then
                psList.Add(New SqlParameter("@Problem_desc", Problem_desc))
            Else
                psList.Add(New SqlParameter("@Problem_desc", DBNull.Value))
            End If
            If Not MtStartTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtStartTime", MtStartTime))
            Else
                psList.Add(New SqlParameter("@MtStartTime", DBNull.Value))
            End If
            If Not MtEndTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtEndTime", MtEndTime))
            Else
                psList.Add(New SqlParameter("@MtEndTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtTime) Then
                psList.Add(New SqlParameter("@MtTime", MtTime))
            Else
                psList.Add(New SqlParameter("@MtTime", DBNull.Value))
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
            If Not String.IsNullOrEmpty(MtStatus_type) Then
                psList.Add(New SqlParameter("@MtStatus_type", MtStatus_type))
            Else
                psList.Add(New SqlParameter("@MtStatus_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtStatus_desc) Then
                psList.Add(New SqlParameter("@MtStatus_desc", MtStatus_desc))
            Else
                psList.Add(New SqlParameter("@MtStatus_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Satisfaction_type) Then
                psList.Add(New SqlParameter("@Satisfaction_type", Satisfaction_type))
            Else
                psList.Add(New SqlParameter("@Satisfaction_type", DBNull.Value))
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

        Public Sub Modify(Flow_id As String, MtClass_type As String, OrgCode As String, MtItem_type As String, ElecExpect_type As String, _
                            MtItemOther_desc As String, Problem_desc As String, MtStartTime As DateTime, MtEndTime As DateTime, MtTime As Double, _
                            MaintainerPhone_nos As String, Maintainer_name As String, MtStatus_type As String, MtStatus_desc As String, Satisfaction_type As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, MtClass_type, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@MtClass_type", MtClass_type))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", dr("MtItem_type")))
            End If
            
            If Not String.IsNullOrEmpty(ElecExpect_type) Then
                psList.Add(New SqlParameter("@ElecExpect_type", ElecExpect_type))
            Else
                psList.Add(New SqlParameter("@ElecExpect_type", dr("ElecExpect_type")))
            End If
            If Not String.IsNullOrEmpty(MtItemOther_desc) Then
                psList.Add(New SqlParameter("@MtItemOther_desc", MtItemOther_desc))
            Else
                psList.Add(New SqlParameter("@MtItemOther_desc", dr("MtItemOther_desc")))
            End If
            If Not String.IsNullOrEmpty(Problem_desc) Then
                psList.Add(New SqlParameter("@Problem_desc", Problem_desc))
            Else
                psList.Add(New SqlParameter("@Problem_desc", dr("Problem_desc")))
            End If
            If Not MtStartTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtStartTime", MtStartTime))
            Else
                psList.Add(New SqlParameter("@MtStartTime", dr("MtStartTime")))
            End If
            If Not MtEndTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtEndTime", MtEndTime))
            Else
                psList.Add(New SqlParameter("@MtEndTime", dr("MtEndTime")))
            End If
            If MtTime <> 0 Then
                psList.Add(New SqlParameter("@MtTime", MtTime))
            Else
                psList.Add(New SqlParameter("@MtTime", dr("MtTime")))
            End If
            If Not String.IsNullOrEmpty(MaintainerPhone_nos) Then
                psList.Add(New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos))
            Else
                psList.Add(New SqlParameter("@MaintainerPhone_nos", dr("MaintainerPhone_nos")))
            End If
            If Not String.IsNullOrEmpty(Maintainer_name) Then
                psList.Add(New SqlParameter("@Maintainer_name", Maintainer_name))
            Else
                psList.Add(New SqlParameter("@Maintainer_name", dr("Maintainer_name")))
            End If
            If Not String.IsNullOrEmpty(MtStatus_type) Then
                psList.Add(New SqlParameter("@MtStatus_type", MtStatus_type))
            Else
                psList.Add(New SqlParameter("@MtStatus_type", dr("MtStatus_type")))
            End If
            If Not String.IsNullOrEmpty(MtStatus_desc) Then
                psList.Add(New SqlParameter("@MtStatus_desc", MtStatus_desc))
            Else
                psList.Add(New SqlParameter("@MtStatus_desc", dr("MtStatus_desc")))
            End If
            If Not String.IsNullOrEmpty(Satisfaction_type) Then
                psList.Add(New SqlParameter("@Satisfaction_type", Satisfaction_type))
            Else
                psList.Add(New SqlParameter("@Satisfaction_type", dr("Satisfaction_type")))
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

        Public Sub Remove(Flow_id As String, MtClass_type As String, OrgCode As String)
            DAO.Delete(Flow_id, MtClass_type, OrgCode)
        End Sub

    End Class
End Namespace
