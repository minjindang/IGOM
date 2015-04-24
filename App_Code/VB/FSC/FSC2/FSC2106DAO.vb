Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2106DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal leave_table As String, ByVal Case_status As String, ByVal lastpass As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select l.*, f.*, ")
            sql.AppendLine(" (case f.Case_status  when 1 then(case f.Last_pass when 0 then '簽核中' when 1 then '已核准' end)")
            sql.AppendLine(" when 0 then '簽核中'")
            sql.AppendLine(" when 2 then '已退回'")
            sql.AppendLine(" when 4 then '已刪除'")
            sql.AppendLine(" when 3 then '已撤銷' end ) as status")
            sql.AppendLine(" from FSC_leave_main l ")
            sql.AppendLine(" inner join sys_flow f on l.flow_id = f.flow_id ")
            sql.AppendLine(" inner join sys_leave_type t on l.leave_type = t.leave_type ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and l.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (l.Depart_id=@Depart_id or l.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Sdate) Then
                sql.AppendLine(" and l.Start_date>=@Sdate ")
            End If
            If Not String.IsNullOrEmpty(Edate) Then
                sql.AppendLine(" and l.End_date<=@Edate ")
            End If
            If Not String.IsNullOrEmpty(leave_table) Then
                sql.AppendLine(" and t.leave_table=@leave_table ")
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

            sql.AppendLine(" order by f.apply_idcard ")

            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(2).Value = Sdate
            params(3) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(3).Value = Edate
            params(4) = New SqlParameter("@leave_table", SqlDbType.VarChar)
            params(4).Value = leave_table
            params(5) = New SqlParameter("@caseStatus1", SqlDbType.VarChar)
            params(5).Value = caseStatus1
            params(6) = New SqlParameter("@caseStatus2", SqlDbType.VarChar)
            params(6).Value = caseStatus2
            params(7) = New SqlParameter("@lastpass", SqlDbType.VarChar)
            params(7).Value = lastpass

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
