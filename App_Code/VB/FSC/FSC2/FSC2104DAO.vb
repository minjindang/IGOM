Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2104DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal LocationFlag As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable


            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT a2.flow_id, ")
            sql.AppendLine(" (case a1.Case_status when 1 then(case a1.Last_pass when 0 then '簽核中'  when 1 then '已核准'  end) when 0 then '簽核中' when 3 then '已撤銷'  when 2 then '已退回' when 4 then '已刪除' End) as Case_status, ")
            sql.AppendLine(" a2.Id_card, a2.User_name, a2.Leave_type, a2.Leave_hours, a2.Place, a2.Start_date, a2.Start_time, a2.End_date,  a2.End_time, a2.Reason, ")
            sql.AppendLine(" SC.CODE_DESC1 AS Degree_code, a2.Location_Flag, ")
            sql.AppendLine(" a3.Level, ")
            sql.AppendLine(" (select User_name from FSC_Personnel AS f WHERE a1.Deputy_idcard = f.id_card) as Deputy, ")
            sql.AppendLine(" (select leave_name from sys_leave_type AS g WHERE g.Leave_type = a2.Leave_type) as Leave_name ")

            sql.AppendLine(" FROM FSC_Leave_main AS a2 ")
            sql.AppendLine(" INNER JOIN SYS_Leave_type a6 on a2.Leave_type = a6.Leave_type ")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS a3 ON a2.Id_card = a3.Id_card ")
            sql.AppendLine(" LEFT JOIN SYS_Flow AS a1 ON a1.Flow_id = a2.Flow_id AND a1.Orgcode=a2.Orgcode ")
            'sql.AppendLine(" LEFT JOIN SYS_Flow_detail AS a5 ON a2.Flow_id = a5.Flow_id ")
            sql.AppendLine(" LEFT JOIN SYS_CODE AS SC ON A3.Degree_code =SC.CODE_NO AND SC.CODE_SYS='023' AND SC.CODE_TYPE='031' ")
            sql.AppendLine(" WHERE 1=1 and a6.Leave_table = '16' ")


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (a2.Depart_id = @Depart_id or a2.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" and a3.Id_number in (select Id_number from FSC_Personnel where id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" and a3.Id_number in (select Id_number from FSC_Personnel where id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" and a3.Quit_job_flag = @Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and a3.PESEX = @PESEX ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and a2.Start_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and a2.End_date <= @End_date ")
            End If
            If Not String.IsNullOrEmpty(LocationFlag) Then
                sql.AppendLine(" and a2.Location_Flag = @LocationFlag ")
            End If

            Dim caseStatus1 As String = ""
            Dim caseStatus2 As String = ""
            If Not String.IsNullOrEmpty(Case_status) Then
                If Case_status.IndexOf(",") >= 0 Then
                    sql.AppendLine("AND (a1.case_status=@caseStatus1 or a1.case_status=@caseStatus2) ")
                    caseStatus1 = Case_status.Split(",")(0)
                    caseStatus2 = Case_status.Split(",")(1)
                Else
                    sql.AppendLine("AND a1.case_status=@caseStatus1 ")
                    caseStatus1 = Case_status
                End If
            End If

            If Not String.IsNullOrEmpty(lastpass) Then
                sql.AppendLine(" AND a1.Last_pass=@lastPass ")
            End If

            sql.AppendLine(" ORDER BY (case when a3.Boss_level_id=0 then 99 else a3.Boss_level_id end), a1.Apply_idcard")

            Dim aryParms(10) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@Apply_name", SqlDbType.VarChar)
            aryParms(1).Value = Apply_name
            aryParms(2) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            aryParms(2).Value = Apply_idcard
            aryParms(3) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(3).Value = Start_date
            aryParms(4) = New SqlParameter("@End_date", SqlDbType.VarChar)
            aryParms(4).Value = End_date
            aryParms(5) = New SqlParameter("@LocationFlag", SqlDbType.VarChar)
            aryParms(5).Value = LocationFlag
            aryParms(6) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            aryParms(6).Value = caseStatus1
            aryParms(7) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            aryParms(7).Value = caseStatus2
            aryParms(8) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            aryParms(8).Value = lastpass
            aryParms(9) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(9).Value = Quit_job_flag
            aryParms(10) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            aryParms(10).Value = PESEX


            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
