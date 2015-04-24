Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class LeaveMainDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal lmain As LeaveMain) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", lmain.FlowId)
            d.Add("Orgcode", lmain.Orgcode)
            d.Add("Depart_id", lmain.DepartId)
            d.Add("Id_card", lmain.IdCard)
            d.Add("User_name", lmain.UserName)
            d.Add("Leave_group", lmain.LeaveGroup)
            d.Add("Leave_ngroup", lmain.LeaveNgroup)
            d.Add("Leave_type", lmain.LeaveType)
            d.Add("Start_date", lmain.StartDate)
            d.Add("End_date", lmain.EndDate)
            d.Add("Start_time", lmain.StartTime)
            d.Add("End_time", lmain.EndTime)
            d.Add("Leave_hours", lmain.LeaveHours)
            d.Add("Holiday_dateb", lmain.HolidayDateb)
            d.Add("Holiday_datee", lmain.HolidayDatee)
            d.Add("Holiday_timeb", lmain.HolidayTimeb)
            d.Add("Holiday_timee", lmain.HolidayTimee)
            d.Add("Holiday_hours", lmain.HolidayHours)
            d.Add("Place", lmain.Place)
            d.Add("Target", lmain.Target)
            d.Add("Baby_Days", lmain.BabyDays)
            d.Add("Retain_flag", lmain.RetainFlag)
            d.Add("Location_flag", lmain.LocationFlag)
            d.Add("China_flag", lmain.ChinaFlag)
            d.Add("Reason", lmain.Reason)
            d.Add("Occur_date", lmain.OccurDate)
            d.Add("Inter_travel_flag", lmain.InterTravelFlag)
            d.Add("Health_check_flag", lmain.HealthCheckFlag)
            d.Add("Holiday_offical_flag", lmain.HolidayOfficalFlag)
            d.Add("Class_flag", lmain.ClassFlag)
            d.Add("Overtime_flag", lmain.OvertimeFlag)
            d.Add("Place_city", lmain.PlaceCity)
            d.Add("Transport", lmain.Transport)
            d.Add("Transport_desc", lmain.TransportDesc)
            d.Add("isCard", lmain.isCard)
            d.Add("isOnlyLeave", lmain.isOnlyLeave)
            d.Add("CheckType", lmain.CheckType)
            d.Add("Project_code", lmain.Project_code)
            d.Add("BossAgree_flag", lmain.BossAgree_flag)
            d.Add("Change_userid", lmain.Change_userid)
            d.Add("Change_date", lmain.Change_date)

            Return InsertByExample("FSC_Leave_main", d)
        End Function

        Public Function UpdateData(ByVal lmain As LeaveMain) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Depart_id", lmain.DepartId)
            d.Add("Id_card", lmain.IdCard)
            d.Add("User_name", lmain.UserName)
            d.Add("Leave_group", lmain.LeaveGroup)
            d.Add("Leave_ngroup", lmain.LeaveNgroup)
            d.Add("Leave_type", lmain.LeaveType)
            d.Add("Start_date", lmain.StartDate)
            d.Add("End_date", lmain.EndDate)
            d.Add("Start_time", lmain.StartTime)
            d.Add("End_time", lmain.EndTime)
            d.Add("Leave_hours", lmain.LeaveHours)
            d.Add("Holiday_dateb", lmain.HolidayDateb)
            d.Add("Holiday_datee", lmain.HolidayDatee)
            d.Add("Holiday_timeb", lmain.HolidayTimeb)
            d.Add("Holiday_timee", lmain.HolidayTimee)
            d.Add("Holiday_hours", lmain.HolidayHours)
            d.Add("Place", lmain.Place)
            d.Add("Target", lmain.Target)
            d.Add("Baby_Days", lmain.BabyDays)
            d.Add("Retain_flag", lmain.RetainFlag)
            d.Add("Location_flag", lmain.LocationFlag)
            d.Add("China_flag", lmain.ChinaFlag)
            d.Add("Reason", lmain.Reason)
            d.Add("Occur_date", lmain.OccurDate)
            d.Add("Inter_travel_flag", lmain.InterTravelFlag)
            d.Add("Health_check_flag", lmain.HealthCheckFlag)
            d.Add("Holiday_offical_flag", lmain.HolidayOfficalFlag)
            d.Add("Class_flag", lmain.ClassFlag)
            d.Add("Overtime_flag", lmain.OvertimeFlag)
            d.Add("Place_city", lmain.PlaceCity)
            d.Add("Transport", lmain.Transport)
            d.Add("Transport_desc", lmain.TransportDesc)
            d.Add("isCard", lmain.isCard)
            d.Add("isOnlyLeave", lmain.isOnlyLeave)
            d.Add("CheckType", lmain.CheckType)
            d.Add("Project_code", lmain.Project_code)
            d.Add("BossAgree_flag", lmain.BossAgree_flag)
            d.Add("Change_userid", lmain.Change_userid)
            d.Add("Change_date", lmain.Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Flow_id", lmain.FlowId)
            cd.Add("Orgcode", lmain.Orgcode)

            Return UpdateByExample("FSC_Leave_main", d, cd)
        End Function

        Public Function DeleteData(ByVal lmain As LeaveMain) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", lmain.FlowId)
            d.Add("Orgcode", lmain.Orgcode)

            Return DeleteByExample("FSC_Leave_main", d)
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("FSC_Leave_main", d)
        End Function

        Public Function GetDataByYYYMM(ByVal idCard As String, ByVal leaveType As String, ByVal yyymm As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * FROM ")
            sql.AppendLine("    FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_Flow b on a.flow_id=b.flow_id ")
            sql.AppendLine(" WHERE  ")
            sql.AppendLine("    a.id_card=@idCard AND a.leave_type=@leaveType AND a.start_date like @yyymm+'%' and b.case_status not in (2,3,4) ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@idCard", SqlDbType.VarChar)
            params(0).Value = idCard
            params(1) = New SqlParameter("@leaveType", SqlDbType.VarChar)
            params(1).Value = leaveType
            params(2) = New SqlParameter("@yyymm", SqlDbType.VarChar)
            params(2).Value = yyymm

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByYYYMM(ByVal idCard As String, ByVal leaveType As String, ByVal yyymm As String, ByVal Retain_flag As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * FROM ")
            sql.AppendLine("    FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_Flow b on a.flow_id=b.flow_id ")
            sql.AppendLine(" WHERE  ")
            sql.AppendLine("    a.id_card=@idCard AND a.leave_type=@leaveType AND a.start_date like @yyymm+'%' and b.case_status not in (2,3,4) ")
            sql.AppendLine(" and a.Retain_flag=@Retain_flag ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@idCard", SqlDbType.VarChar)
            params(0).Value = idCard
            params(1) = New SqlParameter("@leaveType", SqlDbType.VarChar)
            params(1).Value = leaveType
            params(2) = New SqlParameter("@yyymm", SqlDbType.VarChar)
            params(2).Value = yyymm
            params(3) = New SqlParameter("@Retain_flag", SqlDbType.VarChar)
            params(3).Value = Retain_flag

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetOvertimeDataByDateTime(ByVal sdatetime As String, ByVal edatetime As String, ByVal idcard As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select id_card as idno, start_date as dateb, start_time as timeb, end_date as datee, end_time as timee ")
            sql.AppendLine("    FROM FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine("    where ((@sdatetime > a.start_date+a.start_time and @sdatetime < a.end_date+a.end_time) ")
            sql.AppendLine("        or (@edatetime > a.start_date+a.start_time and @edatetime < a.end_date+a.end_time) ")
            sql.AppendLine("        or (SUBSTRING(@sdatetime,1,7)=start_date and SUBSTRING(@edatetime,1,7)=end_date and SUBSTRING(@sdatetime,8,4)<a.start_time and SUBSTRING(@edatetime,8,4)>a.end_time) ")
            sql.AppendLine("        or @sdatetime=a.start_date+a.start_time or @edatetime=a.end_date+a.end_time ")
            sql.AppendLine("        ) and a.id_card=@idcard ")
            sql.AppendLine("    and b.case_status not in (3,4) ")
            sql.AppendLine("    and a.leave_type in (80,82) ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@sdatetime", SqlDbType.VarChar)
            params(0).Value = sdatetime
            params(1) = New SqlParameter("@edatetime", SqlDbType.VarChar)
            params(1).Value = edatetime
            params(2) = New SqlParameter("@idcard", SqlDbType.VarChar)
            params(2).Value = idcard

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByDateTime(ByVal sdate As String, ByVal edate As String, ByVal idcard As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select id_card as idno, start_date as dateb, start_time as timeb, end_date as datee, end_time as timee ")
            sql.AppendLine("    FROM FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine("    where ((@sdate > a.start_date+a.start_time and @sdate < a.end_date+a.end_time) ")
            sql.AppendLine("        or (@edate > a.start_date+a.start_time and @edate < a.end_date+a.end_time) ")
            sql.AppendLine("        or (SUBSTRING(@sdate,1,7)=start_date and SUBSTRING(@edate,1,7)=end_date and SUBSTRING(@sdate,8,4)<a.start_time and SUBSTRING(@edate,8,4)>a.end_time) ")
            sql.AppendLine("        or @sdate=a.start_date+a.start_time or @edate=a.end_date+a.end_time ")
            sql.AppendLine("        ) and a.id_card=@idcard ")
            sql.AppendLine("    and ( b.case_status not in (2,3,4) or b.case_status is null ) ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@sdate", SqlDbType.VarChar)
            params(0).Value = sdate
            params(1) = New SqlParameter("@edate", SqlDbType.VarChar)
            params(1).Value = edate
            params(2) = New SqlParameter("@idcard", SqlDbType.VarChar)
            params(2).Value = idcard

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByOccurDate(ByVal idcard As String, ByVal leaveType As String, ByVal occurDate As String) As DataTable
            Return GetDataByOccurDate(idcard, leaveType, occurDate, "")
        End Function

        Public Function GetDataByOccurDate(ByVal idcard As String, ByVal leaveType As String, _
                                           ByVal occurDate As String, ByVal yyymm As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * FROM FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine(" left outer join SYS_flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine("     WHERE a.id_card=@idcard AND a.leave_type=@leaveType ")
            sql.AppendLine("     and b.case_status not in (3,4)  ")
            If Not String.IsNullOrEmpty(occurDate) Then
                sql.AppendLine(" AND a.occur_date=@occurDate ")
            End If
            If Not String.IsNullOrEmpty(yyymm) Then
                sql.AppendLine(" AND a.occur_date like @yyymm+'%' ")
            End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@idcard", SqlDbType.VarChar)
            params(0).Value = idcard
            params(1) = New SqlParameter("@leaveType", SqlDbType.VarChar)
            params(1).Value = leaveType
            params(2) = New SqlParameter("@occurDate", SqlDbType.VarChar)
            params(2).Value = occurDate
            params(3) = New SqlParameter("@yyymm", SqlDbType.VarChar)
            params(3).Value = yyymm

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetSumLeaveHoursByYM(ByVal idcard As String, ByVal ym As String, ByVal leaveType As String) As Object
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT SUM(Leave_hours) FROM FSC_Leave_main a ")
            sql.AppendLine(" left outer join SYS_Flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine(" where id_card=@idcard and Start_date like @ym+'%' and leave_hours > 0 and leave_type=@leaveType ")
            sql.AppendLine("    and case_status not in (3,4) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@idcard", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar), _
            New SqlParameter("@leaveType", SqlDbType.VarChar)}
            params(0).Value = idcard
            params(1).Value = ym
            params(2).Value = leaveType

            Return Scalar(sql.ToString(), params)
        End Function

        Public Function GetApplyData(ByVal idCard As String, ByVal leaveType As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * FROM ")
            sql.AppendLine("    FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_Flow b on a.flow_id=b.flow_id ")
            sql.AppendLine(" WHERE  ")
            sql.AppendLine("    a.id_card=@idCard AND a.leave_type=@leaveType and b.case_status not in (2,3,4) ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@idCard", SqlDbType.VarChar)
            params(0).Value = idCard
            params(1) = New SqlParameter("@leaveType", SqlDbType.VarChar)
            params(1).Value = leaveType

            Return Query(sql.ToString(), params)
        End Function

        Public Function getInter_travel(ByVal id_card As String, ByVal ym As String) As Double
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT isnull(SUM(Leave_hours),0) FROM FSC_Leave_main a ")
            sql.AppendLine(" left outer join SYS_Flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine(" where id_card=@id_card and Start_date like @ym+'%' and leave_hours > 0 ")
            sql.AppendLine(" and Inter_travel_flag = '1' ")
            sql.AppendLine("    and case_status not in (3,4) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@id_card", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar)}
            params(0).Value = id_card
            params(1).Value = ym

            Return Scalar(sql.ToString(), params)
        End Function

        Public Function UpdateGoogleCalendar(ByVal lmain As LeaveMain) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
            d.Add("Change_date", Now)
            d.Add("isToGoogleCalendar", lmain.isToGoogleCalendar)
            d.Add("ToGoogleCalendarDate", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Flow_id", lmain.FlowId)
            cd.Add("Orgcode", lmain.Orgcode)

            Return UpdateByExample("FSC_Leave_main", d, cd)
        End Function

        Public Function getDataByProjectCode(ByVal Orgcode As String, ByVal id_card As String, ByVal Project_code As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from FSC_Leave_main l ")
            sql.AppendLine(" inner join sys_flow f on f.flow_id=l.flow_id ")
            sql.AppendLine(" where f.case_status in (0, 1) ")
            sql.AppendLine(" and l.isOnlyLeave = '1' ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and l.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and l.id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(Project_code) Then
                sql.AppendLine(" and l.Project_code=@Project_code ")
            End If

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(1).Value = id_card
            params(2) = New SqlParameter("@Project_code", SqlDbType.VarChar)
            params(2).Value = Project_code

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetDataByLeaveType(ByVal idCard As String, ByVal dateTime As String, ByVal leaveType As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * FROM ")
            sql.AppendLine("    FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SYS_Flow b on a.flow_id=b.flow_id ")
            sql.AppendLine(" WHERE  ")
            sql.AppendLine("    a.id_card=@idCard AND a.leave_type=@leaveType and b.case_status not in (3,4) ")
            sql.AppendLine("    AND @dateTime between a.start_date+a.start_time and a.end_date+a.end_time ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@idCard", SqlDbType.VarChar)
            params(0).Value = idCard
            params(1) = New SqlParameter("@leaveType", SqlDbType.VarChar)
            params(1).Value = leaveType
            params(2) = New SqlParameter("@dateTime", SqlDbType.VarChar)
            params(2).Value = dateTime

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace