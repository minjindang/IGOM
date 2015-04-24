Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace FSC.Logic

    Public Class FSC3107DAO
        Inherits BaseDAO

        Function GetSettlementAnnual(ByVal Orgcode As String, ByVal Depart_id As String, ByVal employeeType As String, ByVal Year As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" Select a.Annual_days, a.Pay_days, b.user_name, b.id_card, b.Pekind, b.Perday, b.employee_type, b.fisrt_gov_date, b.PERDAY1, b.PERDAY2, ")
            sql.AppendLine("    (select sum(c.leave_hours) leave_hours from FSC_Leave_main c where c.start_date like @Annual_Year+'%' and c.Retain_flag='1' and c.leave_type='03' and a.id_card=c.id_card and a.orgcode=c.orgcode) retain_leave_hours, ")
            sql.AppendLine("    (select sum(c.leave_hours) from FSC_Leave_main c where c.start_date like @Annual_Year+'%' and c.leave_type='03' and a.id_card=c.id_card and a.orgcode=c.orgcode) leave_hours  ")
            sql.AppendLine("    from FSC_Settlement_Annual a ")
            sql.AppendLine("    inner join FSC_personnel b on a.id_card=b.id_card ")
            sql.AppendLine(" where  a.Orgcode = @Orgcode ")
            sql.AppendLine("    and a.Annual_Year = @Annual_Year ")
            sql.AppendLine("    and b.employee_type in ('1','3','8') ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine("    and a.Depart_id = @Depart_id ")
            End If

            If Not String.IsNullOrEmpty(employeeType) Then
                sql.AppendLine("    and b.employee_type = @employeeType ")
            Else
                If LoginManager.RoleId.IndexOf("Personnel") >= 0 Then
                    sql.AppendLine("    and b.employee_type = '1' ")
                ElseIf LoginManager.RoleId.IndexOf("Sec_PerManager") >= 0 Then
                    sql.AppendLine("    and b.employee_type in ('3','8') ")
                End If
            End If

            sql.AppendLine("    and (a.Trans_flag<>'Y' or a.Trans_flag is null) ")

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)
            aryParms(2).Value = Year
            aryParms(3) = New SqlParameter("@employeeType", SqlDbType.VarChar)
            aryParms(3).Value = employeeType

            Return Query(sql.ToString(), aryParms)
        End Function


        Public Function GetUnApplyData(orgcode As String, depart_id As String, employeeType As String, yyy As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.Id_card, a.User_name, a.PEHDAY, b.Depart_id, SUM(c.leave_hours) Leave_hours ")
            sql.AppendLine(" from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join FSC_Leave_main c on a.id_card=c.id_card ")
            sql.AppendLine("    inner join SYS_Flow d on c.orgcode=d.orgcode and c.flow_id=d.flow_id ")
            sql.AppendLine(" where a.quit_job_flag<>'Y' ")
            sql.AppendLine("    and b.orgcode=@orgcode ")
            sql.AppendLine("    and a.employee_type in ('1','3','8') ")
            sql.AppendLine("    and c.Leave_type='03' ")
            sql.AppendLine("    and SUBSTRING(c.Start_date, 1, 3)=@yyy ")
            sql.AppendLine("    and d.case_status in (0,1,2) ")

            If Not String.IsNullOrEmpty(employeeType) Then
                sql.AppendLine(" and a.employee_type=@employeeType ")
            Else
                If LoginManager.RoleId.IndexOf("Personnel") >= 0 Then
                    sql.AppendLine("    and a.employee_type = '1' ")
                ElseIf LoginManager.RoleId.IndexOf("Sec_PerManager") >= 0 Then
                    sql.AppendLine("    and a.employee_type in ('3','8') ")
                End If
            End If

            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine("    and (b.depart_id=@depart_id or depart_id in (select depart_id from fsc_org where parent_depart_id=@depart_id)) ")
            End If
            sql.AppendLine("    and not exists (select id from FSC_Settlement_Annual where id_card=a.id_card and Annual_year=@yyy) ")

            sql.AppendLine(" group by a.Id_card, a.User_name, a.PEHDAY, b.Depart_id")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@depart_id", depart_id), _
            New SqlParameter("@employeeType", employeeType), _
            New SqlParameter("@yyy", yyy)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetLeaveHours(orgcode As String, id_card As String, yyy As String) As Object
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT SUM(a.leave_hours) ")
            sql.AppendLine(" FROM FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    inner join SYS_Flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine(" where a.Leave_type='03' ")
            sql.AppendLine("    and a.orgcode=@orgcode ")
            sql.AppendLine("    and a.id_card=@id_card ")
            sql.AppendLine("    and SUBSTRING(a.Start_date, 1, 3)=@yyy ")
            sql.AppendLine("    and b.case_status in (0,1,2) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@yyy", SqlDbType.VarChar), _
            New SqlParameter("@id_card", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = yyy
            params(2).Value = id_card

            Return Scalar(sql.ToString(), params)
        End Function
    End Class
End Namespace
