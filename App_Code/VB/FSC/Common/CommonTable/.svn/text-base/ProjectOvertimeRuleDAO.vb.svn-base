Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class ProjectOvertimeRuleDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal por As ProjectOvertimeRule) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", por.Orgcode)
            d.Add("Flow_id", por.FlowId)
            d.Add("Project_code", por.ProjectCode)
            d.Add("Project_name", por.ProjectName)
            d.Add("Project_kind", por.ProjectKind)
            d.Add("Project_desc", por.ProjectDesc)
            d.Add("Start_date", por.StartDate)
            d.Add("End_date", por.EndDate)
            d.Add("Depart_id", por.DepartId)
            d.Add("Id_card", por.IdCard)
            d.Add("User_name", por.UserName)
            d.Add("Title_no", por.TitleNo)
            d.Add("DailyOT_hr", por.DailyOTHr)
            d.Add("DailyOT_pay_hr", por.DailyOTPayHr)
            d.Add("MonOT_hr", por.MonOTHr)
            d.Add("MonOT_pay_hr", por.MonOTPayHr)
            d.Add("Start_time", por.Start_time)
            d.Add("End_time", por.End_time)
            d.Add("CheckType", por.CheckType)
            d.Add("Location", por.Location)
            d.Add("isCard", por.isCard)
            d.Add("isOnlyLeave", por.isOnlyLeave)
            d.Add("LeaveHours", por.LeaveHours)
            d.Add("isShow", por.isShow)
            d.Add("Change_userid", por.ChangeUserid)
            d.Add("Change_date", por.ChangeDate)
            Return InsertByExample("FSC_Project_overtime_rule", d)
        End Function


        Public Function UpdateData(ByVal por As ProjectOvertimeRule) As Boolean
            Dim c As New Dictionary(Of String, Object)
            c.Add("Orgcode", por.Orgcode)
            c.Add("Flow_id", por.FlowId)

            Dim d As New Dictionary(Of String, Object)
            d.Add("Project_code", por.ProjectCode)
            d.Add("Project_name", por.ProjectName)
            d.Add("Project_kind", por.ProjectKind)
            d.Add("Project_desc", por.ProjectDesc)
            d.Add("Start_date", por.StartDate)
            d.Add("End_date", por.EndDate)
            d.Add("Depart_id", por.DepartId)
            d.Add("Id_card", por.IdCard)
            d.Add("User_name", por.UserName)
            d.Add("Title_no", por.TitleNo)
            d.Add("DailyOT_hr", por.DailyOTHr)
            d.Add("DailyOT_pay_hr", por.DailyOTPayHr)
            d.Add("MonOT_hr", por.MonOTHr)
            d.Add("MonOT_pay_hr", por.MonOTPayHr)
            d.Add("Start_time", por.Start_time)
            d.Add("End_time", por.End_time)
            d.Add("CheckType", por.CheckType)
            d.Add("Location", por.Location)
            d.Add("isCard", por.isCard)
            d.Add("isOnlyLeave", por.isOnlyLeave)
            d.Add("LeaveHours", por.LeaveHours)
            d.Add("isShow", por.isShow)
            d.Add("Change_userid", por.ChangeUserid)
            d.Add("Change_date", por.ChangeDate)
            Return UpdateByExample("FSC_Project_overtime_rule", d, c)
        End Function

        Public Function UpdateApproveFlag(orgcode As String, flowId As String, approveFlag As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Dim v As New Dictionary(Of String, Object)
            v.Add("Approve_flag", approveFlag)

            Return UpdateByExample("FSC_Project_overtime_rule", v, d)
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            Return GetDataByExample("FSC_Project_overtime_rule", d)
        End Function

        Public Function GetDataByIdCard(orgcode As String, departId As String, idCard As String, approveFlag As String, isShow As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Depart_id", departId)
            d.Add("Id_card", idCard)

            If Not String.IsNullOrEmpty(approveFlag) Then
                d.Add("Approve_flag", approveFlag)
            End If
            If Not String.IsNullOrEmpty(isShow) Then
                d.Add("isShow", isShow)
            End If

            Return GetDataByExample("FSC_Project_overtime_rule", d)
        End Function

        Public Function GetDataByDate(orgcode As String, departId As String, idCard As String, sdate As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from FSC_Project_overtime_rule ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine(" and depart_id=@depart_id ")
            sql.AppendLine(" and id_card=@id_card ")
            sql.AppendLine(" and start_date<=@sdate ")
            sql.AppendLine(" and end_date>=@sdate ")
            sql.AppendLine(" and approve_flag='1' ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@depart_id", departId), _
                New SqlParameter("@id_card", idCard), _
                New SqlParameter("@sdate", sdate)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function getDataByYYYMM(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal yyymm As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from FSC_Project_overtime_rule ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and orgcode=@orgcode ")
            End If
            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" and depart_id=@depart_id ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(yyymm) Then
                sql.AppendLine(" and start_date like @yyymm ")
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@depart_id", depart_id), _
                New SqlParameter("@id_card", id_card), _
                New SqlParameter("@yyymm", yyymm + "%")}

            Return Query(sql.ToString(), params)
        End Function

        Public Function getDataByCode(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal Project_code As String) As DataTable
            Return getDataByCode(orgcode, depart_id, id_card, "", Project_code)
        End Function

        Public Function getDataByCode(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal date_time As String, ByVal Project_code As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select *, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code where code_sys = '023' and code_type = '029' and code_no=Project_kind) as Project_Kind_Name ")
            sql.AppendLine(" from FSC_Project_overtime_rule ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and orgcode=@orgcode ")
            End If
            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" and depart_id=@depart_id ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(Project_code) Then
                sql.AppendLine(" and Project_code=@Project_code ")
            End If
            If Not String.IsNullOrEmpty(date_time) Then
                sql.AppendLine(" and @date_time between start_date+start_time and end_date+(case when end_time is null then '9999' else end_time end) ")
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@depart_id", depart_id), _
                New SqlParameter("@id_card", id_card), _
                New SqlParameter("@Project_code", Project_code)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDistinctDataByOrgFid(orgcode As String, Flow_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct ")
            sql.AppendLine("    Project_code ")
            sql.AppendLine("    ,Project_name ")
            sql.AppendLine("    ,Project_kind ")
            sql.AppendLine("    ,Project_desc ")
            sql.AppendLine("    ,Start_date ")
            sql.AppendLine("    ,End_date ")
            sql.AppendLine("    ,DailyOT_hr ")
            sql.AppendLine("    ,DailyOT_pay_hr ")
            sql.AppendLine("    ,MonOT_hr ")
            sql.AppendLine("    ,MonOT_pay_hr ")
            sql.AppendLine("    ,Approve_flag ")
            sql.AppendLine(" from FSC_Project_overtime_rule ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine(" and Flow_id=@Flow_id")

            Dim params() As SqlParameter = { _
               New SqlParameter("@orgcode", orgcode), _
               New SqlParameter("@Flow_id", Flow_id)}

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace

