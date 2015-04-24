Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class PersonnelBossDAO
        Inherits BaseDAO

        Public Function GetData(orgcode As String, departId As String, idCard As String, serviceType As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select boss_orgcode, boss_departid, boss_posid, boss_idcard, Boss_stype ")
            sql.AppendLine(" from FSC_Personnel_boss ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine(" and depart_id=@departId ")
            sql.AppendLine(" and id_card=@idCard ")

            If Not String.IsNullOrEmpty(serviceType) Then
                sql.AppendLine(" and service_type=@serviceType ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@serviceType", serviceType)}

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace