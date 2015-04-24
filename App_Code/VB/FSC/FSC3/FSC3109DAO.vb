Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3109DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal employee_type As String, _
                                     ByVal Leave_types As String, _
                                     ByVal dateb As String, _
                                     ByVal datee As String, _
                                     ByVal case_status As String, _
                                     Optional ByVal isA4 As Boolean = True) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" (select top 1 Orgcode_name from FSC_Org where Orgcode=m.Orgcode and Depart_id=m.Depart_id ) Orgcode_name, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_Org where Orgcode=m.Orgcode and Depart_id=m.Depart_id) Depart_name, ")
            sql.AppendLine(" m.Orgcode, p.User_name, p.Id_card, (select leave_name from SYS_leave_type where leave_type=m.leave_type) as leave_name, ")
            sql.AppendLine(" f.flow_id, m.Start_date, m.End_date, m.Start_time, m.End_time, m.reason, f.case_status ")
            sql.AppendLine(" FROM sys_flow f ")
            sql.AppendLine("    inner join fsc_leave_main m on f.flow_id = m.flow_id ")
            sql.AppendLine("    inner join fsc_personnel p on f.apply_idcard = p.id_card  ")
            sql.AppendLine("    inner join SYS_leave_type t on m.leave_type = t.leave_type ")
            sql.AppendLine(" where m.orgcode=@orgcode ")

            If isA4 Then
                sql.AppendLine(" and m.leave_ngroup='A4' ")
            Else
                sql.AppendLine(" and t.Leave_table = '15'  ")
            End If

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (m.Depart_id = @Depart_id or m.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and p.ID_card = @Id_card ")
            End If
            If Not String.IsNullOrEmpty(employee_type) Then
                sql.AppendLine(" and p.employee_type = @employee_type ")
            End If
            If Not String.IsNullOrEmpty(Leave_types) Then
                sql.AppendLine(" and m.Leave_type in (" & Leave_types & ") ")
            End If
            If Not String.IsNullOrEmpty(dateb) Then
                sql.AppendLine(" and m.start_date >= @dateb ")
            End If
            If Not String.IsNullOrEmpty(datee) Then
                sql.AppendLine(" and m.end_date <= @datee ")
            End If
            If Not String.IsNullOrEmpty(case_status) Then
                sql.AppendLine(" and f.case_status = @case_status ")
            End If

            Dim aryParms(6) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(2).Value = Id_card
            aryParms(3) = New SqlParameter("@dateb", SqlDbType.VarChar)
            aryParms(3).Value = dateb
            aryParms(4) = New SqlParameter("@datee", SqlDbType.VarChar)
            aryParms(4).Value = datee
            aryParms(5) = New SqlParameter("@case_status", SqlDbType.VarChar)
            aryParms(5).Value = case_status
            aryParms(6) = New SqlParameter("@employee_type", SqlDbType.VarChar)
            aryParms(6).Value = employee_type

            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace