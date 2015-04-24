Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2105DAO
        Inherits BaseDAO
        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal PRCARD As String, _
                                     ByVal PRNAME As String, _
                                     ByVal PESEX As String, _
                                     ByVal PRADDD As String, _
                                     ByVal PRADDE As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" c.flow_id, ")
            sql.AppendLine(" (case b.Case_status  when 1 then(case b.Last_pass when 0 then '簽核中' when 1 then '已核准' end)")
            sql.AppendLine(" when 0 then '簽核中'")
            sql.AppendLine(" when 2 then '已退回'")
            sql.AppendLine(" when 4 then '已刪除'")
            sql.AppendLine(" when 3 then '已撤銷' end )as Case_status,")
            sql.AppendLine(" c.Id_card,")
            sql.AppendLine(" c.User_name,")
            sql.AppendLine(" CASE WHEN c.Leave_type ='80' THEN '一般' WHEN c.Leave_type ='82' THEN  '專案' END  PRATYPE,   ")
            sql.AppendLine(" c.leave_hours,")
            sql.AppendLine(" c.Start_date,")
            sql.AppendLine(" c.End_date,")
            sql.AppendLine(" c.Start_time,")
            sql.AppendLine(" c.End_time,")
            'sql.AppendLine("(select User_name from FSC_Personnel AS e where d.Boss_idcard = e.Id_card) as Bossname,")
            sql.AppendLine(" c.Reason,")
            sql.AppendLine(" a.PRADDH,")
            sql.AppendLine(" a.PRMNYH,")
            sql.AppendLine(" a.PRPAYH")

            sql.AppendLine(" FROM FSC_leave_main AS c ")
            sql.AppendLine(" INNER JOIN SYS_Leave_type AS g ON g.Leave_type = c.Leave_type and Leave_table = '18'")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS e ON e.Id_card = c.Id_card")
            'sql.AppendLine(" LEFT OUTER JOIN FSC_Personnel_Boss AS d ON d.Id_card = e.Id_card")
            sql.AppendLine(" LEFT OUTER JOIN FSC_CPAPR18M AS a ON a.PRGUID = c.Flow_id")
            sql.AppendLine(" LEFT OUTER JOIN SYS_Flow AS b ON b.Flow_id = c.Flow_id AND b.Orgcode=c.Orgcode")

            sql.AppendLine(" WHERE 1=1")

            '大批加班不列
            sql.AppendLine(" and  leave_ngroup <> 'E3' ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (c.Depart_id = @Depart_id or c.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and e.PESEX = @PESEX ")
            End If
            If Not String.IsNullOrEmpty(PRNAME) Then
                sql.AppendLine(" and e.Id_number in (select id_number from FSC_Personnel where id_card=@PRNAME) ")
            End If
            If Not String.IsNullOrEmpty(PRCARD) Then
                sql.AppendLine(" and e.Id_number in (select id_number from FSC_Personnel where id_card=@PRCARD) ")
            End If
            If Not String.IsNullOrEmpty(PRADDD) Then
                sql.AppendLine(" AND c.Start_date >= @PRADDD ")
            End If
            If Not String.IsNullOrEmpty(PRADDE) Then
                sql.AppendLine(" and c.End_date <= @PRADDE ")
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

            sql.AppendLine(" ORDER BY (case when e.Boss_level_id=0 then 99 else e.Boss_level_id end), e.id_card, c.User_name")

            Dim aryParms(8) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@PRNAME", SqlDbType.VarChar)
            aryParms(1).Value = PRNAME
            aryParms(2) = New SqlParameter("@PRCARD", SqlDbType.VarChar)
            aryParms(2).Value = PRCARD
            aryParms(3) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            aryParms(3).Value = PESEX
            aryParms(4) = New SqlParameter("@PRADDD", SqlDbType.VarChar)
            aryParms(4).Value = PRADDD
            aryParms(5) = New SqlParameter("@PRADDE", SqlDbType.VarChar)
            aryParms(5).Value = PRADDE
            aryParms(6) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            aryParms(6).Value = caseStatus1
            aryParms(7) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            aryParms(7).Value = caseStatus2
            aryParms(8) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            aryParms(8).Value = lastpass


            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
