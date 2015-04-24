Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2113DAO
        Inherits BaseDAO

        Public Function getData(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String, _
                                ByVal Leave_type As String) As DataTable

            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select p.*, @yyy as YYY, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=d.orgcode and f.depart_id = d.depart_id) as Depart_Name, ")
            sql.AppendLine(" (select top 1 Leave_name from SYS_Leave_type where Leave_type=@Leave_type) as Leave_name, ")
            sql.AppendLine(" (select isnull(sum(cast(PDDAYS as int)),0) from FSC_CPAPD04M where PDKIND=p.PEKIND and PDMEMCOD=p.Employee_type and PDVTYPE=@Leave_type ) as limitday, ")
            sql.AppendLine(" (select isnull(sum(Leave_hours),0) from FSC_Leave_main l inner join sys_flow f on f.flow_id=l.flow_id where left(l.start_date,3)=@yyy and Leave_type=@Leave_type  ")
            sql.AppendLine(" and l.Id_card=p.Id_card and l.orgcode=d.orgcode and l.depart_id=d.depart_id and f.Case_status not in (3,4)) as realday")
            sql.AppendLine(" from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_depart_emp d on d.id_card=p.id_card ")
            sql.AppendLine(" where 1=1 ")


            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and d.orgcode=@orgcode")
            End If
            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine("  and (d.Depart_id = @Depart_id or d.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and p.id_card=@id_card")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" and p.id_card=@id_card2")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                If Quit_job_flag = "N" Then
                    sql.AppendLine(" and (p.Quit_job_flag=@Quit_job_flag or p.Quit_job_flag='' or p.Quit_job_flag is null) ")
                Else
                    sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag")
                End If
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and p.PESEX=@PESEX")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type=@Employee_type")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            sql.AppendLine(" order by p.Boss_level_id, p.id_card ")

            Dim paras(8) As SqlParameter
            paras(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            paras(0).Value = orgcode
            paras(1) = New SqlParameter("@depart_id", SqlDbType.VarChar)
            paras(1).Value = depart_id
            paras(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            paras(2).Value = id_card
            paras(3) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            paras(3).Value = id_card2
            paras(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            paras(4).Value = Quit_job_flag
            paras(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            paras(5).Value = PESEX
            paras(6) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            paras(6).Value = Employee_type
            paras(7) = New SqlParameter("@Leave_type", SqlDbType.VarChar)
            paras(7).Value = Leave_type
            paras(8) = New SqlParameter("@yyy", SqlDbType.VarChar)
            paras(8).Value = yyy


            Return Query(sql.ToString, paras)
        End Function

        Public Function getDataSettlementAnnual(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String) As DataTable

            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select s.*, f.Last_pass, f.Case_status, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=s.orgcode and f.depart_id = s.depart_id) as Depart_Name ")
            sql.AppendLine(" from FSC_Settlement_Annual s ")
            sql.AppendLine(" inner join sys_flow f on s.flow_id = f.flow_id")
            sql.AppendLine(" inner join FSC_Personnel p on s.id_card=p.id_card ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(yyy) Then
                sql.AppendLine(" and s.Annual_year=@yyy ")
            End If
            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and s.orgcode=@orgcode")
            End If
            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" and (s.Depart_id = @Depart_id or s.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and p.id_card=@id_card")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" and p.id_card=@id_card2")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                If Quit_job_flag = "N" Then
                    sql.AppendLine(" and (p.Quit_job_flag=@Quit_job_flag or p.Quit_job_flag='' or p.Quit_job_flag is null) ")
                Else
                    sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag")
                End If
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and p.PESEX=@PESEX")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type=@Employee_type")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            sql.AppendLine(" order by p.Boss_level_id, p.id_card ")

            Dim paras(7) As SqlParameter
            paras(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            paras(0).Value = orgcode
            paras(1) = New SqlParameter("@depart_id", SqlDbType.VarChar)
            paras(1).Value = depart_id
            paras(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            paras(2).Value = id_card
            paras(3) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            paras(3).Value = id_card2
            paras(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            paras(4).Value = Quit_job_flag
            paras(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            paras(5).Value = PESEX
            paras(6) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            paras(6).Value = Employee_type
            paras(7) = New SqlParameter("@yyy", SqlDbType.VarChar)
            paras(7).Value = yyy

            Return Query(sql.ToString, paras)
        End Function

        Public Function getNonSettlementAnnual(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String) As DataTable

            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select p.*, @yyy as Annual_year, isnull(PEHDAY,0) as Annual_days, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=d.orgcode and f.depart_id = d.depart_id) as Depart_Name, ")
            sql.AppendLine(" (select isnull(sum(Leave_hours),0) from FSC_Leave_main l inner join sys_flow f on f.flow_id=l.flow_id where left(l.start_date,3)=@yyy and Leave_type='03'  ")
            sql.AppendLine(" and l.Id_card=p.Id_card and l.orgcode=d.orgcode and l.depart_id=d.depart_id and f.Case_status not in (3,4)) as Vacation_days, ")
            sql.AppendLine(" (select isnull(sum(Leave_hours),0) from FSC_Leave_main l inner join sys_flow f on f.flow_id=l.flow_id where left(l.start_date,3)=@yyy and Leave_type='03'  ")
            sql.AppendLine(" and l.Id_card=p.Id_card and l.orgcode=d.orgcode and l.depart_id=d.depart_id and f.Case_status not in (3,4) and l.Inter_travel_flag = '1') as Vocation_internal ")
            sql.AppendLine(" from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_depart_emp d on d.id_card=p.id_card ")
            sql.AppendLine(" where 1=1 ")
            sql.AppendLine(" and p.id_card not in ")
            sql.AppendLine(" (select id_card from FSC_Settlement_Annual where Annual_year=@yyy and Orgcode=d.orgcode ")
            sql.AppendLine(" and Depart_id=d.depart_id and id_card=p.id_card ) ")


            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and d.orgcode=@orgcode")
            End If
            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" and d.depart_id=@depart_id")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and p.id_card=@id_card")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" and p.id_card=@id_card2")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                If Quit_job_flag = "N" Then
                    sql.AppendLine(" and (p.Quit_job_flag=@Quit_job_flag or p.Quit_job_flag='' or p.Quit_job_flag is null) ")
                Else
                    sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag")
                End If
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and p.PESEX=@PESEX")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type=@Employee_type")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            sql.AppendLine(" order by p.Boss_level_id, p.id_card ")

            Dim paras(7) As SqlParameter
            paras(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            paras(0).Value = orgcode
            paras(1) = New SqlParameter("@depart_id", SqlDbType.VarChar)
            paras(1).Value = depart_id
            paras(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            paras(2).Value = id_card
            paras(3) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            paras(3).Value = id_card2
            paras(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            paras(4).Value = Quit_job_flag
            paras(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            paras(5).Value = PESEX
            paras(6) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            paras(6).Value = Employee_type
            paras(7) = New SqlParameter("@yyy", SqlDbType.VarChar)
            paras(7).Value = yyy

            Return Query(sql.ToString, paras)
        End Function
    End Class
End Namespace
