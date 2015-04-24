Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class FSC3121DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetDepart(orgcode As String) As DataTable
            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode)}

            Return Query("select * from FSC_ORG where Parent_depart_id is null and orgcode=@orgcode", params)
        End Function

        Public Function GetPersonelData(depart_id As String, Employee_type As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.* ")
            sql.AppendLine(" from FSC_Personnel a ")
            sql.AppendLine("  inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine(" where a.quit_job_flag<>'Y' ")
            'sql.AppendLine("    and a.employee_type in ('1','3','8') ")
            sql.AppendLine("    and (b.depart_id=@depart_id or depart_id in (select depart_id from fsc_org where parent_depart_id=@depart_id)) ")

            If String.IsNullOrEmpty(Employee_type) Then
                If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
                    sql.AppendLine(" and a.employee_type in ('1','2') ")
                End If
                If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Sec_PerManager") >= 0 Then
                    sql.AppendLine(" and a.employee_type in ('3','8') ")
                End If
            Else
                sql.AppendLine(" and a.employee_type = @Employee_type ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@depart_id", depart_id), _
            New SqlParameter("@Employee_type", Employee_type)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetData(orgcode As String, ByVal Id_card As String, ByVal yyy As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT a.* ")
            sql.AppendLine(" FROM FSC_Leave_main a WITH(NOLOCK) ")
            sql.AppendLine("    inner join SYS_Flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.AppendLine(" where a.Leave_type='03' ")
            sql.AppendLine("    and a.orgcode=@orgcode ")
            sql.AppendLine("    and a.Id_card=@Id_card ")
            sql.AppendLine("    and SUBSTRING(a.Start_date, 1, 3)=@yyy ")
            sql.AppendLine("    and b.case_status in (0,1,2) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@yyy", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = Id_card
            params(2).Value = yyy

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT c.*, a.fee_ym, b.apply_hour ")
            sql.AppendLine(" FROM SAL_Overtime_Fee_Master a WITH(NOLOCK) ")
            sql.AppendLine("    inner join SAL_Overtime_Fee_Detail b with(nolock) on a.orgcode=b.orgcode and a.depart_id=b.depart_id and a.id_card=b.id_card and a.fee_ym=b.fee_ym and a.apply_seq=b.apply_seq ")
            sql.AppendLine("    inner join FSC_CPAPR18M c on b.id_card=c.PRIDNO and b.overtime_date=c.PRADDD and b.Overtime_Start=c.PRSTIME ")
            sql.AppendLine(" where a.orgcode=@orgcode and a.flow_id=@flowId ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@flowId", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = flowId

            Return Query(sql.ToString(), params)
        End Function


    End Class
End Namespace