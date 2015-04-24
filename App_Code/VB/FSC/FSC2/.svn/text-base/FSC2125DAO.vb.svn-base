Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2125DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal yyymm As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine(" PRCARD, PRNAME, ")
            sql.AppendLine(" substring(PRADDD,1,3) + '年' + substring(PRADDD,4,2) + '月' as PRYYYMM, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_Org f where f.orgcode=r.orgcode and f.depart_id=r.depart_id) as Depart_name,")
            sql.AppendLine(" sum(Leave_hours) as Leave_hours, ")
            sql.AppendLine(" sum(PRADDH) as PRADDH, ")
            sql.AppendLine(" sum(PRPAYH) as PRPAYH, ")
            sql.AppendLine(" sum(PRMNYH) as PRMNYH, ")
            sql.AppendLine(" sum(PRPAYFEE) as PRPAYFEE ")
            sql.AppendLine(" from FSC_CPAPR18M r ")
            sql.AppendLine(" inner join FSC_Leave_main l on l.flow_id=r.PRGUID ")
            sql.AppendLine(" inner join FSC_Personnel p on r.PRCARD=p.id_card ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and r.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (r.Depart_id = @Depart_id or r.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and r.PRCARD=@id_card ")
            End If
            If Not String.IsNullOrEmpty(yyymm) Then
                sql.AppendLine(" and substring(r.PRADDD,1,5) = @yyymm ")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            sql.AppendLine(" group by PRCARD, PRNAME, r.orgcode, r.depart_id, substring(PRADDD,1,3) + '年' + substring(PRADDD,4,2) + '月' ")
            sql.AppendLine(" order by  r.orgcode, r.depart_id, PRCARD ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(2).Value = id_card
            params(3) = New SqlParameter("@yyymm", SqlDbType.VarChar)
            params(3).Value = yyymm

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
