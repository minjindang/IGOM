Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2111DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal BossLevel As String, ByVal Sdate As String, _
                                ByVal Edate As String, ByVal Case_status As String, ByVal lastPass As String) As DataTable
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

            'If Case_status = "0" Then '申請中
            '    sql.AppendLine(" and f.Last_pass = 0 and f.case_status in (0, 1) ")
            'ElseIf Case_status = "1" Then '已決行
            '    sql.AppendLine(" and f.Last_pass = 1 and f.case_status in (1) ")
            'ElseIf Case_status = "2" Then '已撤銷
            '    sql.AppendLine(" and f.Last_pass = 1 and f.case_status in (3) ")
            'Else
            '    sql.AppendLine(" and f.case_status not in (4) ")
            'End If

            If String.IsNullOrEmpty(BossLevel) Then
                sql.AppendLine(" and p.Boss_level_id <> '0' ")
            Else
                sql.AppendLine(" and p.Boss_level_id =@BossLevel ")
            End If

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and l.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (l.Depart_id = @Depart_id or l.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
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
            If Not String.IsNullOrEmpty(lastPass) Then
                sql.AppendLine(" AND f.Last_pass=@lastPass ")
            End If

            sql.AppendLine(" order by (case when p.Boss_level_id=0 then 99 else p.Boss_level_id end), p.Id_card ")

            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@BossLevel", SqlDbType.VarChar)
            params(2).Value = BossLevel
            params(3) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(3).Value = Sdate
            params(4) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(4).Value = Edate
            params(5) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            params(5).Value = caseStatus1
            params(6) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            params(6).Value = caseStatus2
            params(7) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            params(7).Value = lastPass


            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
