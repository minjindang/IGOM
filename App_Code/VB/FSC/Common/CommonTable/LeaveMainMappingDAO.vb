Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class LeaveMainMappingDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal lmm As LeaveMainMapping) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", lmm.Orgcode)
            d.Add("Flow_id", lmm.FlowId)
            d.Add("Id_card", lmm.Idcard)
            d.Add("Start_date", lmm.StartDate)
            d.Add("End_date", lmm.EndDate)
            d.Add("Start_time", lmm.StartTime)
            d.Add("End_time", lmm.EndTime)
            d.Add("Leave_type", lmm.LeaveType)
            d.Add("Leave_hours", lmm.LeaveHours)
            d.Add("Apply_dateb", lmm.ApplyDateb)
            d.Add("Apply_datee", lmm.ApplyDatee)
            d.Add("Apply_timeb", lmm.ApplyTimeb)
            d.Add("Apply_timee", lmm.ApplyTimee)
            d.Add("Change_userid", lmm.ChangeUserid)
            d.Add("Change_date", lmm.ChangeDate)

            Return InsertByExample("FSC_Leave_main_mapping", d)
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("FSC_Leave_main_mapping", d)
        End Function

        Public Function GetDataByApplyData(ByVal orgcode As String, ByVal idcard As String, ByVal leaveType As String, ByVal applyDateb As String, ByVal applyTimeb As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT a.*, b.Last_pass FROM FSC_Leave_main_mapping a WITH(NOLOCK) ")
            sql.AppendLine(" left outer join SYS_Flow b with(nolock) on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine(" WHERE a.orgcode=@orgcode ")
            sql.AppendLine(" and a.id_card=@idcard AND a.leave_type>=@leaveType AND a.apply_dateb=@applyDateb AND a.apply_timeb=@applyTimeb ")
            sql.AppendLine(" and b.case_status not in (3,4) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@idcard", idcard), _
            New SqlParameter("@leaveType", leaveType), _
            New SqlParameter("@applyDateb", applyDateb), _
            New SqlParameter("@applyTimeb", applyTimeb)}
            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace