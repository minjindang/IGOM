Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2107DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal Employee_type As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" (CASE f.Case_status  WHEN 1 then(CASE f.Last_pass WHEN 0 THEN '簽核中' WHEN 1 THEN '已核准' END) WHEN 0 then '簽核中' WHEN 3 then '已撤銷' when 2 then '已退回' when 4 then '已刪除' END) AS Case_status, ")
            sql.AppendLine(" e.Orgcode,")
            sql.AppendLine(" e.Depart_name,")
            sql.AppendLine(" a.flow_id,")
            sql.AppendLine(" a.Apply_idcard,")
            sql.AppendLine(" a.Apply_name,")
            sql.AppendLine(" a.Forgot_date,")
            sql.AppendLine(" a.Forgot_time,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE as i where CODE_SYS = '023' and CODE_TYPE ='008' and i.CODE_NO = a.Card_type) as Card_type,")
            sql.AppendLine(" a.Reason, ")
            sql.AppendLine(" (select top 1 change_date from sys_flow_detail fd where fd.flow_id in (select flow_id from sys_flow f2 where f2.flow_id =f.flow_id and f2.orgcode=f.orgcode and f2.case_status = 1 and f2.last_pass = 1 ) and agree_flag = 1 order by change_date desc ) Change_date ")
            sql.AppendLine(" FROM FSC_Forgot_clock_apply AS a")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS c ON c.Id_card = a.Apply_idcard")
            sql.AppendLine(" INNER JOIN SYS_Flow AS f ON f.Flow_id = a.Flow_id AND f.Orgcode = a.Orgcode")
            sql.AppendLine(" LEFT JOIN FSC_ORG AS e ON e.Depart_id= a.Depart_id AND e.Orgcode = a.Orgcode")
            sql.AppendLine(" WHERE 1=1")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" AND (a.Depart_id = @Depart_id or a.depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" AND c.Id_number in (select id_number from FSC_Personnel where id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" AND c.Id_number in (select id_number from FSC_Personnel where id_card=@Apply_idcard) ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" AND a.Forgot_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" AND a.Forgot_date <= @End_date ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" AND c.Quit_job_flag = @Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" AND c.Employee_type = @Employee_type ")
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

            sql.AppendLine(" ORDER BY (case when c.Boss_level_id=0 then 99 else c.Boss_level_id end), c.id_card, a.Forgot_date desc ")

            Dim aryParms(9) As SqlParameter
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
            aryParms(5) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(5).Value = Quit_job_flag
            aryParms(6) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            aryParms(6).Value = Employee_type
            aryParms(7) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            aryParms(7).Value = caseStatus1
            aryParms(8) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            aryParms(8).Value = caseStatus2
            aryParms(9) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            aryParms(9).Value = lastpass

            Return Query(sql.ToString(), aryParms)
        End Function
    End Class
End Namespace
