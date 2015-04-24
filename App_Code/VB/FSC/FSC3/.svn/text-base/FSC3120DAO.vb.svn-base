Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3120DAO
        Inherits BaseDAO

        Public Function getTitle() As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from sys_code ")
            sql.AppendLine(" where code_sys = '023' and code_type = '012' ")
            sql.AppendLine(" and code_desc2 in ('1','2','3') ")

            Return Query(sql.ToString())
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Title_no As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select v.*, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_org f where f.orgcode = v.orgcode and f.depart_id = v.depart_id ) as Depart_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='023' and s.code_type='012' and s.code_no=v.title_no ) as Title_name, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_org f where f.orgcode = v.orgcode and f.depart_id = v.deputy_depart_id ) as Deputy_Depart_name, ")
            sql.AppendLine(" (select top 1 User_name from FSC_personnel p where p.id_card = v.deputy_id_card) as Deputy_name ")
            sql.AppendLine(" from FSC_Deputy_vacancy v ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and v.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (v.Depart_id=@Depart_id or v.Depart_id in (select Depart_id from FSC_Org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" and v.Title_no=@Title_no ")
            End If

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            params(2).Value = Title_no

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
