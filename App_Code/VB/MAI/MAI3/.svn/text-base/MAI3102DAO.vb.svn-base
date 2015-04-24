Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace MAI.Logic
    Public Class MAI3102DAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal maintain_type As String, ByVal Apply_dateS As String, ByVal Apply_dataE As String, _
                                ByVal Apply_name As String, ByVal Apply_ext As String, ByVal Depart_id As String, ByVal Case_status As String) As DataTable
            Dim type_length As Integer = IIf(String.IsNullOrEmpty(maintain_type), 0, maintain_type.Split(",").Length)
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select m.*, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=m.orgcode and f.depart_id=m.apply_departid) as Depart_Name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='020' and s.code_type='**' and s.code_no=m.Maintain_kind) as Maintain_kind_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='020' and s.code_type='005' and s.code_no=m.Maintain_type) as Maintain_type_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='006' and s.code_no=h.Status_type) as ChCase_status ")
            sql.AppendLine(" from mai_maintain_main m ")
            sql.AppendLine(" inner join mai_maintain_handle h on m.id=h.Main_id ")
            sql.AppendLine(" where 1=1 ")
            sql.AppendLine(" and Maintain_kind='005' ")

            Dim params(6 + type_length) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dataE", SqlDbType.VarChar)
            params(2).Value = Apply_dataE
            params(3) = New SqlParameter("@Apply_name", SqlDbType.VarChar)
            params(3).Value = "%" + Apply_name + "%"
            params(4) = New SqlParameter("@Apply_ext", SqlDbType.VarChar)
            params(4).Value = Apply_ext
            params(5) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(5).Value = Depart_id
            params(6) = New SqlParameter("@Case_status", SqlDbType.VarChar)
            params(6).Value = Case_status

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(maintain_type) Then
                sql.Append(" and maintain_type in ( ")
                For i As Integer = 0 To maintain_type.Split(",").Length - 1
                    If i <> 0 Then sql.Append(",")
                    sql.Append(" @maintain_type" + i.ToString())
                    params(6 + i + 1) = New SqlParameter("@maintain_type" + i.ToString(), SqlDbType.VarChar)
                    params(6 + i + 1).Value = maintain_type.Split(",")(i)
                Next
                sql.Append(") ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateS) Then
                sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            End If
            If Not String.IsNullOrEmpty(Apply_dataE) Then
                sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")
            End If
            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" and m.Apply_name like @Apply_name ")
            End If
            If Not String.IsNullOrEmpty(Apply_ext) Then
                sql.AppendLine(" and m.Apply_ext=@Apply_ext ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.apply_departid=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Case_status) Then
                If Case_status.Equals("003") Then
                    sql.AppendLine(" and h.Status_type=@Case_status ")
                Else
                    sql.AppendLine(" and h.Status_type not in (@Case_status) ")
                End If
            End If

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
