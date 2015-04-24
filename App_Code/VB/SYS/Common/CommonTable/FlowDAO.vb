Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text
Imports CommonLib
Imports NLog

Namespace SYS.Logic
    Public Class FlowDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal flow As SYS.Logic.Flow) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", flow.Orgcode)
            d.Add("Flow_id", flow.FlowId)
            d.Add("Depart_id", flow.DepartId)
            d.Add("Apply_posid", flow.ApplyPosid)
            d.Add("Apply_idcard", flow.ApplyIdcard)
            d.Add("Apply_name", flow.ApplyName)
            d.Add("Apply_stype", flow.ApplyStype)
            d.Add("Deputy_flag", flow.DeputyFlag)
            d.Add("Deputy_orgcode", flow.DeputyOrgcode)
            d.Add("Deputy_departid", flow.DeputyDepartid)
            d.Add("Deputy_posid", flow.DeputyPosid)
            d.Add("Deputy_idcard", flow.DeputyIdcard)
            d.Add("Deputy_name", flow.DeputyName)
            d.Add("Writer_orgcode", flow.WriterOrgcode)
            d.Add("Writer_departid", flow.WriterDepartid)
            d.Add("Writer_posid", flow.WriterPosid)
            d.Add("Writer_idcard", flow.WriterIdcard)
            d.Add("Writer_name", flow.WriterName)
            d.Add("Write_time", flow.WriteTime)
            d.Add("Reason", flow.Reason)
            d.Add("Form_id", flow.FormId)
            d.Add("Change_userid", flow.ChangeUserid)
            d.Add("Change_date", flow.ChangeDate)
            d.Add("Case_status", flow.CaseStatus)
            d.Add("Budget_code", flow.Budget_code)
            d.Add("Cancel_flowid", flow.CancelFlowid)

            If flow.LastPass = 1 Then
                d.Add("Last_date", flow.LastDate)
                d.Add("Last_pass", flow.LastPass)
            End If

            Return InsertByExample("SYS_Flow", d)
        End Function


        Public Function UpdateData(ByVal flow As SYS.Logic.Flow) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", flow.Orgcode)
            d.Add("Flow_id", flow.FlowId)

            Dim v As New Dictionary(Of String, Object)
            v.Add("Depart_id", flow.DepartId)
            v.Add("Apply_posid", flow.ApplyPosid)
            v.Add("Apply_idcard", flow.ApplyIdcard)
            v.Add("Apply_name", flow.ApplyName)
            v.Add("Apply_stype", flow.ApplyStype)
            v.Add("Deputy_flag", flow.DeputyFlag)
            v.Add("Deputy_orgcode", flow.DeputyOrgcode)
            v.Add("Deputy_departid", flow.DeputyDepartid)
            v.Add("Deputy_posid", flow.DeputyPosid)
            v.Add("Deputy_idcard", flow.DeputyIdcard)
            v.Add("Deputy_name", flow.DeputyName)
            v.Add("Writer_orgcode", flow.WriterOrgcode)
            v.Add("Writer_departid", flow.WriterDepartid)
            v.Add("Writer_idcard", flow.WriterIdcard)
            v.Add("Writer_name", flow.WriterName)
            v.Add("Writer_posid", flow.WriterPosid)
            v.Add("Write_time", flow.WriteTime)
            v.Add("Reason", flow.Reason)
            v.Add("Form_id", flow.FormId)
            v.Add("Change_userid", flow.ChangeUserid)
            v.Add("Change_date", flow.ChangeDate)
            v.Add("Case_status", flow.CaseStatus)

            If flow.LastPass = 1 Then
                v.Add("Last_date", flow.LastDate)
                v.Add("Last_pass", flow.LastPass)
            End If

            Return UpdateByExample("SYS_Flow", v, d)
        End Function

        Public Function UpdateLast(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String, ByVal lastPass As String, ByVal lastDate As Date) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" update SYS_Flow ")
            sql.AppendLine(" set ")
            sql.AppendLine("    Case_status=@caseStatus, ")
            sql.AppendLine("    Last_pass=@lastPass, ")
            sql.AppendLine("    Last_date=@lastDate ")
            sql.AppendLine(" where ")
            sql.AppendLine("    (orgcode=@orgcode and flow_id=@flowId) or (merge_orgcode=@orgcode and merge_flowid=@flowId) ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@flowId", flowId), _
                New SqlParameter("@caseStatus", caseStatus), _
                New SqlParameter("@lastPass", lastPass), _
                New SqlParameter("@lastDate", lastDate)}

            Return Execute(sql.ToString(), params)
        End Function


        Public Function UpdateMergedFlow(ByVal orgcode As String, ByVal flowId As String, ByVal mergeFlag As String, _
                                         ByVal mergeOrgcode As String, ByVal mergeFlowid As String, ByVal mergeDate As Date, _
                                         ByVal mergeUorgcode As String, ByVal mergeUdepartid As String, ByVal mergeUserid As String, _
                                         ByVal lastPass As String, ByVal lastDate As Date) As Integer
            Dim v As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)

            v.Add("Merge_orgcode", mergeOrgcode)
            v.Add("Merge_flowid", mergeFlowid)
            v.Add("Merge_date", mergeDate)
            v.Add("Merge_uorgcode", mergeUorgcode)
            v.Add("Merge_udepartid", mergeUdepartid)
            v.Add("Merge_userid", mergeUserid)

            If lastPass = "1" Then
                v.Add("Last_pass", lastPass)
                v.Add("Last_date", lastDate)
            End If

            v.Add("Merge_flag", mergeFlag)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            Return UpdateByExample("SYS_Flow", v, d)
        End Function

        Public Function UpdateCancel(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String, ByVal cancelFlag As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)

            v.Add("Case_status", caseStatus)
            v.Add("Cancel_flag", cancelFlag)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return UpdateByExample("SYS_Flow", v, d)
        End Function

        Public Function UpdateCaseStatus(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)

            v.Add("case_status", caseStatus)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return UpdateByExample("SYS_Flow", v, d)
        End Function

        Public Function GetMergeFid(flowId As String) As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", flowId)
            Dim dt As DataTable = GetDataByExample("SYS_Flow", d)
            Dim mFlowId As String = String.Empty
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                mFlowId = IIf(IsDBNull(dt.Rows(0)("Merge_flowid")), "", dt.Rows(0)("Merge_flowid"))
            End If
            Return mFlowId
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("SYS_Flow", d)
        End Function

        Public Function UpdateMergedFlag(ByVal orgcode As String, ByVal flowId As String, ByVal mergedFlag As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)

            v.Add("Merged_flag", mergedFlag)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return UpdateByExample("SYS_Flow", v, d)
        End Function

        Public Function GetDataByOrgMergeFid(ByVal orgcode As String, ByVal MergeflowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Merge_orgcode", orgcode)
            d.Add("Merge_flowid", MergeflowId)

            Return GetDataByExample("SYS_Flow", d)
        End Function

        Public Function UpdateMAT_ApplyOutdateByMergeFid(ByVal orgcode As String, ByVal MergeflowId As String) As Integer

            Dim sql As New System.Text.StringBuilder
            sql.Append("UPDATE MAT_ApplyMaterial_det " & vbCrLf)
            sql.Append("SET    Out_date = @Out_date " & vbCrLf)
            sql.Append("WHERE  Flow_id IN (SELECT Flow_id " & vbCrLf)
            sql.Append("                   FROM   Sys_flow " & vbCrLf)
            sql.Append("                   WHERE  merge_flowid = @Flow_id " & vbCrLf)
            sql.Append("                          AND OrgCode = @OrgCode " & vbCrLf)
            sql.Append("                   UNION " & vbCrLf)
            sql.Append("                   SELECT Flow_id " & vbCrLf)
            sql.Append("                   FROM   Sys_flow " & vbCrLf)
            sql.Append("                   WHERE  Flow_id = @Flow_id " & vbCrLf)
            sql.Append("                          AND OrgCode = @OrgCode) " & vbCrLf)
            sql.Append("       AND OrgCode = @OrgCode ")
       


            Dim params() As SqlParameter = { _
                New SqlParameter("@OrgCode", orgcode), _
                New SqlParameter("@Flow_id", MergeflowId), _
                New SqlParameter("@Out_date", CommonFun.getYYYMMDD)}

            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetDataByCancelFlowid(orgcode As String, cancelFlowid As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("Cancel_flowid", cancelFlowid)

            Return GetDataByExample("SYS_Flow", d)
        End Function

        Public Function UpdateBudgetType(orgcode As String, flowId As String, budgetType As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)

            v.Add("Budget_code", budgetType)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return UpdateByExample("SYS_Flow", v, d)

        End Function
    End Class
End Namespace
