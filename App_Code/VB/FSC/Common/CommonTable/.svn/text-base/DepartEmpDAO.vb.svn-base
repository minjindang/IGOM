Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class DepartEmpDAO
        Inherits BaseDAO

        Public Function GetDataByIdcard(ByVal orgcode As String, ByVal idCard As String, ByVal rocDate As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select *, b.orgcode_name, b.depart_name from FSC_Depart_Emp a ")
            sql.AppendLine(" inner join FSC_org b on a.orgcode=b.orgcode and a.depart_id=b.depart_id ")
            sql.AppendLine(" where id_card=@idCard ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and a.orgcode=@orgcode ")
            End If

            'If Not String.IsNullOrEmpty(rocDate) Then
            '    sql.AppendLine(" and @rocDate between (case when isnull(a.Service_sdate,'')='' then '0000000' else a.Service_sdate end) and (case when isnull(a.Service_edate,'')='' then '9999999' else a.Service_edate end) ")
            'End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@idCard", idCard), _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@rocDate", rocDate)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByServiceType(ByVal orgcode As String, ByVal idCard As String, ByVal serviceType As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select *, b.orgcode_name, b.depart_name from FSC_Depart_Emp a ")
            sql.AppendLine(" inner join FSC_org b on a.orgcode=b.orgcode and a.depart_id=b.depart_id ")
            sql.AppendLine(" where id_card=@idCard and service_type=@serviceType ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and a.orgcode=@orgcode ")
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@idCard", idCard), _
                New SqlParameter("@serviceType", serviceType), _
                New SqlParameter("@orgcode", orgcode)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByDepartId(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select *, b.orgcode_name, b.depart_name from FSC_Depart_Emp a ")
            sql.AppendLine(" inner join FSC_org b on a.orgcode=b.orgcode and a.depart_id=b.depart_id ")
            sql.AppendLine(" where a.orgcode=@orgcode and a.depart_id=@departId ")

            If Not String.IsNullOrEmpty(idCard) Then
                sql.AppendLine(" and a.id_card=@idCard ")
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@idCard", idCard)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetParentDepartByIdCard(ByVal orgcode As String, ByVal idCard As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from FSC_ORG where Depart_id in ( ")
            sql.AppendLine(" select b.Parent_depart_id from FSC_Depart_EMP a ")
            sql.AppendLine("        inner join FSC_ORG b on a.Orgcode=b.Orgcode and a.Depart_id=b.Depart_id where a.Orgcode=@orgcode and a.Id_card=@idCard ")
            sql.AppendLine(" ) ")

            Dim params() As SqlParameter = { _
               New SqlParameter("@orgcode", orgcode), _
               New SqlParameter("@idCard", idCard)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDepartByParentDepartId(ByVal orgcode As String, ByVal parentDepartId As String, ByVal idCard As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select * from FSC_Depart_EMP a ")
            sql.AppendLine(" inner join FSC_ORG b on a.Orgcode=b.Orgcode and a.Depart_id=b.Depart_id ")
            sql.AppendLine(" where b.Orgcode=@orgcode and b.parent_depart_id=@parentDepartId and a.Id_card=@idCard ")


            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@parentDepartId", parentDepartId), _
                New SqlParameter("@idCard", idCard)}

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace