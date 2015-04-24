Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Namespace FSC.Logic
    Public Class FSC2127DAO
        Inherits BaseDAO

        Function GetData(ByVal orgcode As String, departId As String, idCard As String, startDate As String, endDate As String, yyymm As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select b.User_name, a.PHIDATE, a.PHITIME, (case a.PHITYPE when 'A' then '上班進卡' when 'D' then '上班出卡' else '' end) PHITYPE from FSC_CPAPH" & yyymm & " a ")
            sql.AppendLine(" inner join FSC_Personnel b on a.phcard=b.id_card ")
            sql.AppendLine(" left outer join FSC_Depart_emp c on b.id_card=c.id_card ")
            sql.AppendLine(" where c.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (c.depart_id=@departId or c.depart_id in (select depart_id from fsc_org where parent_depart_id=@departId)) ")
            End If
            If Not String.IsNullOrEmpty(idCard) Then
                sql.AppendLine(" and b.id_number in (select id_number from FSC_Personnel where id_card=@idCard) ")
            End If

            sql.AppendLine(" and a.phidate>=@startDate ")
            sql.AppendLine(" and a.phidate<=@endDate ")

            sql.AppendLine(" order by c.depart_id, b.id_card, a.phidate, a.phitime, a.phitype ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@idCard", idCard), _
                New SqlParameter("@startDate", startDate), _
                New SqlParameter("@endDate", endDate)}

            Return Query(sql.ToString(), params)

        End Function

    End Class
End Namespace