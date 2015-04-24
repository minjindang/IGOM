Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic

    Public Class FSC3112DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub


        Public Function GetData(ByVal orgcode As String, _
                                ByVal departid As String, _
                                ByVal idcard As String, _
                                ByVal yyymm As String, _
                                ByVal scheduleId As String, _
                                ByVal quitJobFlag As String, _
                                ByVal employeeType As String, _
                                ByVal target As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.*, b.name, b.Start_time, b.End_time, ")
            sql.AppendLine(" (select top 1 (case when b.parent_depart_id is not null then (select depart_name from FSC_Org c where b.orgcode=c.orgcode and b.parent_depart_id=c.depart_id ) else b.Depart_Name end) from FSC_Org b where b.orgcode=a.orgcode and b.depart_id=a.depart_id) as Depart_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='023' and code_type = '012' and code_no=c.title_no) as Title_name ")

            If target = "0" Then
                sql.AppendLine(" from FSC_Schedule_base a ")
            Else
                sql.AppendLine(" from FSC_Schedule_setting a ")
            End If
            sql.AppendLine("    inner join FSC_Personnel c on a.id_card=c.id_card ")
            sql.AppendLine("    left outer join FSC_Schedule b on a.orgcode=b.orgcode and a.schedule_id=b.schedule_id ")
            sql.AppendLine(" where substring(a.Sche_date,1,5)=@yyymm ")

            If Not String.IsNullOrEmpty(departid) Then
                sql.AppendLine(" and (a.depart_id=@depart_id or a.depart_id in (select depart_id from FSC_Org where parent_depart_id=@depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(idcard) Then
                sql.AppendLine(" and a.id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(scheduleId) Then
                sql.AppendLine(" and a.schedule_id=@scheduleId ")
            End If
            If Not String.IsNullOrEmpty(quitJobFlag) Then
                sql.AppendLine(" and c.quit_job_flag=@quitJobFlag ")
            End If
            If Not String.IsNullOrEmpty(employeeType) Then
                sql.AppendLine(" and c.employee_type=@employeeType ")
            End If

            sql.AppendLine(" order by a.Sche_date ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@yyymm", yyymm), _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@depart_id", departid), _
            New SqlParameter("@id_card", idcard), _
            New SqlParameter("@scheduleId", scheduleId), _
            New SqlParameter("@quitJobFlag", quitJobFlag), _
            New SqlParameter("@employeeType", employeeType)}

            Return Query(sql.ToString(), ps)
        End Function



        Public Function GetFlowData(ByVal orgcode As String, ByVal id_card As String, ByVal sdate As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from flow ")
            sql.AppendLine(" where case_status in ('0','1') and leave_type<>'85' and leave_type<>'84' and cancel_flag<>'Y' ")
            sql.AppendLine(" and orgcode=@orgcode and Apply_id=@id_card ")
            sql.AppendLine(" and start_date<=@sdate and end_date>=@sdate ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@id_card", id_card), _
            New SqlParameter("@sdate", sdate)}

            Return Query(sql.ToString(), ps)
        End Function

        Public Function getDataByDate(ByVal cpadb As String, _
                        ByVal orgcode As String, _
                        ByVal departid As String, _
                        ByVal idcard As String, _
                        ByVal personnelid As String, _
                        ByVal yyymmdd As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.*, b.orgcode, b.depart_id, b.sub_depart_id, b.personnel_id, b.id_card, b.user_name, c.schedule_id, ")
            sql.AppendLine(" (select seq from detail_code where detail_code_id=b.title_no and master_code_id='1012') as seq ")
            sql.AppendLine(" from " & cpadb & "..CPAPB02M a ")
            sql.AppendLine(" inner join member b on b.orgcode=@orgcode  ")
            sql.AppendLine(" left outer join Schedule_setting c on a.PBDDATE=c.sche_date and b.orgcode=c.orgcode and b.depart_id=c.depart_id and b.id_card=c.id_card ")
            sql.AppendLine(" where a.PBDDATE=@yyymmdd and b.quit_job_flag<>'Y' and b.role_id<>'SysAdmin' ")

            If Not String.IsNullOrEmpty(departid) Then
                sql.AppendLine(" and b.depart_id=@depart_id ")
            End If
            If Not String.IsNullOrEmpty(idcard) Then
                sql.AppendLine(" and b.id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(personnelid) Then
                sql.AppendLine(" and b.Personnel_id=@personnelid ")
            End If

            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) = "TWDAdmin" Then
                sql.AppendLine(" and b.Metadb_id='2' ")
            ElseIf LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) = "GenServAdmin" Then
                sql.AppendLine(" and b.Metadb_id='2' ")
            ElseIf LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) = "Personnel" Then
                sql.AppendLine(" and b.Metadb_id='1' ")
            ElseIf LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) = "SchedulerGeneral" Then

            ElseIf LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) = "SchedulerOther" Then

            End If

            sql.AppendLine(" order by b.seq, b.id_card, a.PBDDATE ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@yyymmdd", yyymmdd), _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@depart_id", departid), _
            New SqlParameter("@id_card", idcard), _
            New SqlParameter("@personnelid", personnelid) _
            }

            Return Query(sql.ToString(), ps)
        End Function



        Public Function GetDataByOnDutySex(ByVal onDuty As String, ByVal sex As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select isnull(c.depart_name,'')+'/'+isnull(e.code_desc1,'')+'/'+a.user_name as full_name,  a.* from fsc_personnel a  ")
            sql.AppendLine("    left join fsc_depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    left join fsc_org c on b.orgcode=c.orgcode and b.depart_id=c.depart_id ")
            sql.AppendLine("    left join sys_code e on e.code_sys='023' and e.code_type='012' and e.code_no=a.title_no ")
            sql.AppendLine(" where on_duty=@onDuty and b.depart_id not like 'L0%'")

            Dim len As Integer = 0
            If Not String.IsNullOrEmpty(sex) Then
                len = sex.Split(",").Length
                sql.AppendLine(" and ( ")
                For i As Integer = 0 To len - 1
                    If i <> 0 Then
                        sql.AppendLine(" or ")
                    End If
                    sql.AppendLine("  pesex=@sex" & i)
                Next
                sql.AppendLine(" ) ")
            End If
            sql.AppendLine(" order by id_number ")

            Dim params(0 + len) As SqlParameter
            params(0) = New SqlParameter("@onDuty", onDuty)
            For i As Integer = 0 To len - 1
                params(1 + i) = New SqlParameter("@sex" & i, sex.Split(",")(i))
            Next


            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
