Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL1111DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetData(ByVal PRIDNO As String, ByVal departId As String, ByVal ym As String, ByVal ymd As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT c.*, isnull(b.apply_hour,0) as apply_hour ")
            sql.AppendLine(" FROM FSC_CPAPR18M c WITH(NOLOCK) ")
            sql.AppendLine("    left outer join SAL_Overtime_Fee_Detail b with(nolock) on b.depart_id=c.depart_id and b.id_card=c.PRIDNO and b.overtime_date=c.PRADDD and b.Overtime_Start=c.PRSTIME ")

            sql.AppendLine(" where c.PRCARD = @PRCARD  ")
            sql.AppendLine("    and c.PRADDD like @ym+'%'  ")
            sql.AppendLine("    and c.PRADDH > 0 ")
            sql.AppendLine("    and c.PRADDD < @ymd ")
            sql.AppendLine("    and (c.isOnlyLeave is null or isOnlyLeave <> '1') ")
            sql.AppendLine("    and c.depart_id=@departId")
            sql.AppendLine(" ORDER BY PRADDD, PRSTIME ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRCARD", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar), _
            New SqlParameter("@ymd", SqlDbType.VarChar), _
            New SqlParameter("@departId", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = ym
            params(2).Value = ymd
            params(3).Value = departId

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


        Public Function GetSAL1111_02Data(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT CASE WHEN ofd.Overtime_type='1' THEN '一般' WHEN ofd.Overtime_type='2' THEN '專案' ELSE '' END AS Overtime_type, ")
            sql.AppendLine("        ofd.Overtime_date, ofd.Overtime_End_Date, ofd.Overtime_start, ofd.Overtime_end, ofd.Overtime_hour, ofd.Apply_hour, ofd.Reason, ")
            sql.AppendLine("        isnull((ofd.Apply_hour * ims.BASE_HOUR_SAL),0) AS Apply_money, m.budget_type, m.user_name, m.Title_no, dc.CODE_DESC1 as title_name ")
            sql.AppendLine(" FROM SAL_Overtime_Fee_detail ofd ")
            sql.AppendLine("        INNER JOIN FSC_Personnel m ON ofd.Orgcode=m.Orgcode AND ofd.Depart_id=m.Depart_id AND ofd.Id_card=m.Id_card ")
            sql.AppendLine("        LEFT OUTER JOIN SAL_SABASE ims ON ims.BASE_ORGID=ofd.Orgcode AND ims.BASE_DEP=ofd.Depart_id AND ims.BASE_SEQNO=ofd.Id_card ")
            sql.AppendLine("        left outer join SYS_CODE dc on dc.CODE_NO=m.title_no and dc.CODE_SYS='023' and dc.CODE_TYPE='012' ")
            sql.AppendLine(" WHERE ofd.Orgcode=@Orgcode AND ofd.Id_card=@Id_card AND ofd.Fee_ym=@Fee_ym AND ofd.Apply_seq=@Apply_seq ")
            sql.AppendLine(" order by ofd.Overtime_date, ofd.Overtime_start ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card
            params(2).Value = Fee_ym
            params(3).Value = Apply_seq
            Return Query(sql.ToString(), params)
        End Function

        Public Function GetLastBudget(ByVal id_card As String) As String
            Dim sql As New StringBuilder
            sql.AppendLine(" select top 1 * from SAL_Overtime_Fee_Master where Id_card=@Id_card order by Fee_Ym desc ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = id_card

            Dim dt As DataTable = Query(sql.ToString(), params)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("Budget_type").ToString()
            Else
                Return "001"
            End If
        End Function

        Public Function getSALData(ByVal Orgcode As String, ByVal Id_card As String, ByVal yyyymm As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select base_name, base_seqno, BASE_HOUR_SAL, ")
            sql.AppendLine(" round(cast((dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,@yyyymm, base_ptb_type,base_alt_amt)) as decimal(12,2)),0) ")
            sql.AppendLine(" + round((dbo.get_kdc_kdp_kdo('004' ,base_kdc,base_kdc_series,@yyyymm)),0)")
            sql.AppendLine(" + round((dbo.get_kdc_kdp_kdo('003' ,base_kdp,base_kdp_series,@yyyymm)),0) as month_pay, ")
            sql.AppendLine(" round(cast((dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,@yyyymm, base_ptb_type,base_alt_amt)) as decimal(12,2)),0) as main_pay, ")
            sql.AppendLine(" round((dbo.get_kdc_kdp_kdo('003' ,base_kdp,base_kdp_series,@yyyymm)),0) as pro_pay, ")
            sql.AppendLine(" round((dbo.get_kdc_kdp_kdo('004' ,base_kdc,base_kdc_series,@yyyymm)),0) as boss_pay ")
            sql.AppendLine(" from SAL_SABASE  ")
            sql.AppendLine(" where BASE_ORGID=@Orgcode ")
            sql.AppendLine(" and BASE_SEQNO=@Id_card ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("Id_card", SqlDbType.VarChar)
            params(1).Value = Id_card
            params(2) = New SqlParameter("yyyymm", SqlDbType.VarChar)
            params(2).Value = yyyymm

            Return Query(sql.ToString, params)
        End Function



    End Class
End Namespace