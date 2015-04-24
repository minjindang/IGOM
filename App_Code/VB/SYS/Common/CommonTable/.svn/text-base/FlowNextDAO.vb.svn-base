Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace SYS.Logic
    Public Class FlowNextDAO
        Inherits BaseDAO

        Public Function insertData(ByVal flowNext As FlowNext) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", flowNext.Orgcode)
            d.Add("Flow_id", flowNext.FlowId)
            d.Add("Next_orgcode", flowNext.NextOrgcode)
            d.Add("Next_departid", flowNext.NextDepartid)
            d.Add("Next_posid", flowNext.NextPosid)
            d.Add("Next_idcard", flowNext.NextIdcard)
            d.Add("Next_name", flowNext.NextName)
            d.Add("Next_step", flowNext.NextStep)
            d.Add("Group_id", flowNext.GroupId)
            d.Add("Group_step", flowNext.GroupStep)
            d.Add("Custom_flag", flowNext.CustomFlag)
            d.Add("Replace_flag", flowNext.ReplaceFlag)
            d.Add("Replace_orgcode", flowNext.ReplaceOrgcode)
            d.Add("Replace_departid", flowNext.ReplaceDepartid)
            d.Add("Replace_posid", flowNext.ReplacePosid)
            d.Add("Replace_idcard", flowNext.ReplaceIdcard)
            d.Add("Replace_name", flowNext.ReplaceName)
            d.Add("Mail_flag", flowNext.MailFlag)
            d.Add("Deputy_flag", flowNext.DeputyFlag)
            d.Add("Change_userid", flowNext.ChangeUserid)
            d.Add("Change_date", flowNext.ChangeDate)

            Return InsertByExample("SYS_Flow_next", d)
        End Function

        Public Function GetData(orgcode As String, flowId As String, nextOrgcode As String, nextDepartid As String, nextIdcard As String, nextStep As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * ")
            sql.AppendLine(" from SYS_Flow_next with(nolock) ")
            sql.AppendLine(" where orgcode=@orgcode and flow_id=@flowId ")

            sql.AppendLine("    and Next_orgcode=@NextOrgcode ")
            sql.AppendLine("    and Next_departid=@NextDepartid ")
            sql.AppendLine("    and Next_idcard=@NextIdcard ")

            If Not String.IsNullOrEmpty(nextStep) AndAlso nextStep <> "0" Then
                sql.AppendLine("    and next_step=@nextStep ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId), _
            New SqlParameter("@nextOrgcode", nextOrgcode), _
            New SqlParameter("@nextDepartid", nextDepartid), _
            New SqlParameter("@nextIdcard", nextIdcard), _
            New SqlParameter("@nextStep", nextStep)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("SYS_Flow_next", d)
        End Function

        Public Function DeleteData(ByVal orgcode As String, ByVal flowId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return DeleteByExample("SYS_Flow_next", d)
        End Function

        Public Function DeleteData(ByVal orgcode As String, ByVal flowId As String, ByVal groupId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            d.Add("Group_id", groupId)

            Return DeleteByExample("SYS_Flow_next", d)
        End Function

        Public Function getDataByFid(ByVal flow_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * ")
            sql.AppendLine(" from SYS_Flow_next with(nolock) ")
            sql.AppendLine(" where flow_id=@flow_id ")
            sql.AppendLine(" order by next_step ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdateNextById(id As Integer, nextOrgcode As String, nextDepartid As String, nextIdcard As String, nextPosid As String, nextName As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            v.Add("Next_orgcode", nextOrgcode)
            v.Add("Next_departid", nextDepartid)
            v.Add("Next_posid", nextPosid)
            v.Add("Next_idcard", nextIdcard)
            v.Add("Next_name", nextName)

            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return UpdateByExample("SYS_Flow_next", v, d)
        End Function
    End Class
End Namespace