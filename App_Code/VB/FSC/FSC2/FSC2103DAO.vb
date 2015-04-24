Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2103DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Title_no As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Leave_type As String, _
                                     ByVal Employee_type As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT")
            sql.AppendLine(" a.orgcode,")
            sql.AppendLine(" b.Flow_id,")
            sql.AppendLine(" (case b.Case_status  when 1 then(case b.Last_pass when 0 then '簽核中' when 1 then '已核准' end)")
            sql.AppendLine(" when 0 then '簽核中'")
            sql.AppendLine(" when 2 then '已退回'")
            sql.AppendLine(" when 4 then '已刪除'")
            sql.AppendLine(" when 3 then '已撤銷' end )as Case_status,")
            sql.AppendLine(" a.Id_card,")
            sql.AppendLine(" a.User_name,")
            sql.AppendLine(" f.Title_no,")
            sql.AppendLine(" c.Leave_name,")
            sql.AppendLine(" a.Leave_hours,")
            sql.AppendLine(" a.Start_date,")
            sql.AppendLine(" a.Start_time,")
            sql.AppendLine(" a.End_date,")
            sql.AppendLine(" a.End_time,")
            sql.AppendLine(" (select User_name from FSC_Personnel AS f WHERE b.Deputy_idcard = f.id_card) as Deputy,")
            sql.AppendLine(" a.Place,")
            sql.AppendLine(" a.Reason")

            sql.AppendLine(" FROM FSC_Leave_main AS a")
            sql.AppendLine(" INNER JOIN SYS_Leave_Type AS c ON c.Orgcode = a.Orgcode AND c.Leave_type = a.Leave_type")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS f ON f.Id_card = a.Id_card")
            'sql.AppendLine(" INNER JOIN FSC_ORG AS e ON e.Orgcode=a.Orgcode and e.Depart_id= a.Depart_id")
            sql.AppendLine(" LEFT JOIN SYS_Flow AS b ON  b.Flow_id = a.Flow_id AND b.Orgcode = a.Orgcode")
            sql.AppendLine(" WHERE 1=1 and c.Leave_table = '15' ")


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (b.Depart_id = @Depart_id or b.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If

            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" and f.Id_number in (select Id_number from FSC_Personnel where id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" and f.Id_number in (select Id_number from FSC_Personnel where id_card=@Apply_idcard) ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" and f.Title_no  = @Title_no ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" and f.Quit_job_flag = @Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and f.PESEX = @PESEX ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and a.Start_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and a.End_date <= @End_date ")
            End If
            Dim a = 0
            If Not String.IsNullOrEmpty(Leave_type) Then
                sql.AppendLine(" AND ( ")
                For Each s As String In Leave_type.Split(",")
                    If a = "0" Then
                        sql.AppendLine(" a.Leave_type =  @s" & a)
                    Else
                        sql.AppendLine(" OR a.Leave_type = @s" & a)
                    End If
                    a = a + 1
                Next
                sql.AppendLine(" ) ")
            End If

            Dim caseStatus1 As String = ""
            Dim caseStatus2 As String = ""
            If Not String.IsNullOrEmpty(Case_status) Then
                If Case_status.IndexOf(",") >= 0 Then
                    sql.AppendLine("AND (b.case_status=@caseStatus1 or b.case_status=@caseStatus2) ")
                    caseStatus1 = Case_status.Split(",")(0)
                    caseStatus2 = Case_status.Split(",")(1)
                Else
                    sql.AppendLine("AND b.case_status=@caseStatus1 ")
                    caseStatus1 = Case_status
                End If
            End If

            If Not String.IsNullOrEmpty(lastpass) Then
                sql.AppendLine(" AND b.Last_pass=@lastPass ")
            End If

            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and f.Employee_type = @Employee_type ")
            End If

            sql.AppendLine(" ORDER BY (case when f.Boss_level_id = 0 then 99 else f.Boss_level_id end), a.Id_card, a.Start_date, a.Start_time ")

            Dim aryParms(12 + Leave_type.Split(",").Length - 1) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@Apply_name", SqlDbType.VarChar)
            aryParms(1).Value = Apply_name
            aryParms(2) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            aryParms(2).Value = Apply_idcard

            aryParms(3) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            aryParms(3).Value = Title_no

            aryParms(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(4).Value = Quit_job_flag
            aryParms(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            aryParms(5).Value = PESEX
            aryParms(6) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(6).Value = Start_date
            aryParms(7) = New SqlParameter("@End_date", SqlDbType.VarChar)
            aryParms(7).Value = End_date
            aryParms(8) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            aryParms(8).Value = Employee_type
            aryParms(9) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            aryParms(9).Value = caseStatus1
            aryParms(10) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            aryParms(10).Value = caseStatus2
            aryParms(11) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            aryParms(11).Value = lastpass

            For i As Integer = 0 To Leave_type.Split(",").Length - 1
                aryParms(12 + i) = New SqlParameter("@s" & i, SqlDbType.VarChar)
                aryParms(12 + i).Value = Leave_type.Split(",")(i)
            Next
            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function getQueryData2(ByVal flowid As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT")
            sql.AppendLine(" a.Last_name")
            sql.AppendLine(" from SYS_Flow_detail AS a")
            sql.AppendLine(" LEFT JOIN SYS_Flow AS b ON b.Flow_id = a.Flow_id AND b.Orgcode = a.Orgcode")
            sql.AppendLine(" WHERE 1=1")


            If Not String.IsNullOrEmpty(flowid) Then
                sql.AppendLine(" and b.flow_id = @flowid ")
            End If
      
            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@flowid", SqlDbType.VarChar)
            aryParms(0).Value = flowid
            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
