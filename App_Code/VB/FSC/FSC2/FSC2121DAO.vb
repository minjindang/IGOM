Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2121DAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sche_month As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select ss.*,  ")
            sql.AppendLine(" (select top 1 Name from FSC_Schedule s where s.Schedule_id=ss.Schedule_id and s.orgcode=ss.orgcode ) As Sche_Name ")
            sql.AppendLine(" from FSC_Schedule_setting ss ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and ss.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (ss.Depart_id = @Depart_id or ss.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Sche_month) Then
                sql.AppendLine(" and left(ss.Sche_date,5)=@Sche_month ")
            End If

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Sche_month", SqlDbType.VarChar)
            params(2).Value = Sche_month

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
