Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2110DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Id_card2 As String, _
                                ByVal Q_job As String, ByVal Sex As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal LeaveType As String, ByVal Employee_type As String, ByVal Case_status As String, ByVal lastpass As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select l.*, f.*, p.*, ")
            sql.AppendLine(" (select case when last_pass=0 and case_status in (0, 1) then '簽核中' ")
            sql.AppendLine(" when last_pass=1 and case_status in (1) then '已核准' ")
            sql.AppendLine(" when last_pass=1 and case_status in (4) then '已刪除' ")
            sql.AppendLine(" when last_pass=0 and case_status in (2) then '已退回' ")
            sql.AppendLine(" when last_pass=1 and case_status in (3) then '已撤銷' end) as Status ")
            sql.AppendLine(" from FSC_leave_main l ")
            sql.AppendLine(" inner join sys_flow f on l.flow_id = f.flow_id ")
            sql.AppendLine(" inner join FSC_Personnel p on l.Id_card = p.Id_card ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and f.Deputy_orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (f.Deputy_departid=@Depart_id  or f.Deputy_departid in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and p.id_number in (select id_number from FSC_Personnel where id_card=@Id_card) ")
            End If
            If Not String.IsNullOrEmpty(Id_card2) Then
                sql.AppendLine(" and f.id_number in (select id_number from FSC_Personnel where id_card=@Id_card2) ")
            End If
            If Not String.IsNullOrEmpty(Q_job) Then
                sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(Sex) Then
                sql.AppendLine(" and p.PESEX=@PESEX ")
            End If
            If Not String.IsNullOrEmpty(LeaveType) Then
                sql.AppendLine(" and l.Leave_type=@LeaveType ")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type=@Employee_type ")
            End If
            If Not String.IsNullOrEmpty(Sdate) Then
                sql.AppendLine(" and l.Start_date>=@Sdate ")
            End If
            If Not String.IsNullOrEmpty(Edate) Then
                sql.AppendLine(" and l.End_date<=@Edate ")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            Dim caseStatus1 As String = ""
            Dim caseStatus2 As String = ""
            If Not String.IsNullOrEmpty(Case_status) Then
                If Case_status.IndexOf(",") >= 0 Then
                    sql.AppendLine("AND (f.case_status=@caseStatus1 or f.case_status=@caseStatus2) ")
                    caseStatus1 = Case_status.Split(",")(0)
                    caseStatus2 = Case_status.Split(",")(1)
                Else
                    sql.AppendLine("AND f.case_status=@caseStatus1 ")
                    caseStatus1 = Case_status
                End If
            End If

            If Not String.IsNullOrEmpty(lastpass) Then
                sql.AppendLine(" AND f.Last_pass=@lastPass ")
            End If

            sql.AppendLine(" order by (case when p.Boss_level_id=0 then 99 else p.Boss_level_id end) , p.Id_card ")

            Dim params(12) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(2).Value = Id_card
            params(3) = New SqlParameter("@Id_card2", SqlDbType.VarChar)
            params(3).Value = Id_card2
            params(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            params(4).Value = Q_job
            params(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            params(5).Value = Sex
            params(6) = New SqlParameter("@LeaveType", SqlDbType.VarChar)
            params(6).Value = LeaveType
            params(7) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            params(7).Value = Employee_type
            params(8) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(8).Value = Sdate
            params(9) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(9).Value = Edate
            params(10) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            params(10).Value = caseStatus1
            params(11) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            params(11).Value = caseStatus2
            params(12) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            params(12).Value = lastpass

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
