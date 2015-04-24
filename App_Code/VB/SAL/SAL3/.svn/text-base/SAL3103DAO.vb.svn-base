Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SAL.Logic
    Public Class SAL3103DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getList_Code(ByVal Orgcode As String, ByVal operation As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" SELECT * ")
            sql.AppendLine(" FROM sys_code ")
            sql.AppendLine(" WHERE code_sys = '005' ")
            sql.AppendLine(" AND code_kind = 'D' ")
            sql.AppendLine(" AND code_type IN ('001','002') ")
            sql.AppendLine(" AND exists ( ")
            sql.AppendLine(" select * from SAL_SAITEM where item_orgid=@orgid ")
            sql.AppendLine(" and item_code_sys=code_sys ")
            sql.AppendLine(" and item_code_kind=code_kind ")
            sql.AppendLine(" and item_code_type=code_type ")
            sql.AppendLine(" and item_code_no=code_no ")
            If Not String.IsNullOrEmpty(operation) Then
                sql.AppendLine(" and item_operation=@operation ")
            End If
            sql.AppendLine(")")
            sql.AppendLine(" ORDER BY code_type,cast(code_no AS int) ")

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("orgid", SqlDbType.VarChar)
            param(0).Value = Orgcode
            param(1) = New SqlParameter("operation", SqlDbType.VarChar)
            param(1).Value = operation

            Return Query(sql.ToString, param)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Operate As String, ByVal Code As String, ByVal Suspend As String) As DataTable
            Dim rv As String = ""

            rv = " select * "
            rv &= " ,isnull((select code_desc1 from sys_code where code_sys=item_code_sys and code_type=item_code_type and code_no=item_code_no),'') as item_desc"
            rv &= " ,case item_operation when '+' then '加' when '-' then '減' else '無法辨識' end as operation_name "
            rv &= " ,isnull(( select code_desc1 from sys_code where code_sys='003' and code_kind='P' and code_type='004' and code_no=item_icode),'無') as icode_name"
            rv &= " ,case item_tax when 'Y' then '是' when 'N' then '否' else '-' end as tax_name "
            rv &= " ,case item_type when 'Y' then '是' when 'N' then '否' else '-' end as type_name "
            rv &= " ,case ITEM_AddINCO when 'Y' then '是' when 'N' then '否' else '-' end as add_inco "
            rv &= " ,case (select count(*) from SAL_sapitm "
            rv &= "        where pitm_orgid = item_orgid "
            rv &= "        and pitm_code_type = item_code_type "
            rv &= "        and pitm_code_no = item_code_no "
            rv &= "        and pitm_code = item_code ) "
            rv &= "  when 0 then 'true' else 'false' end as show_del "
            rv &= " from SAL_saitem "
            rv &= " where item_orgid=@Orgcode "

            If Not String.IsNullOrEmpty(Operate) Then
                rv &= " and item_operation = @Operate "
            End If
            If Not String.IsNullOrEmpty(Code) Then
                rv &= " and item_code_no = @Code "
            End If

            If Suspend = "N" Then
                rv &= " and item_suspend='N' "
            End If

            rv &= " order by item_code"

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("Operate", SqlDbType.VarChar)
            params(1).Value = Operate
            params(2) = New SqlParameter("Code", SqlDbType.VarChar)
            params(2).Value = Code

            Return Query(rv, params)
        End Function

        Public Function delete(ByVal Orgcode As String, ByVal item_code As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" delete from SAL_sapitm ")
            sql.AppendLine(" where pitm_orgid=@Orgcode ")
            sql.AppendLine(" and pitm_code=@item_code ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("item_code", SqlDbType.VarChar)
            params(1).Value = item_code

            Return Execute(sql.ToString(), params)
        End Function

        Public Function deleteSuspend(ByVal Orgcode As String, ByVal item_code As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update sal_saitem set item_suspend='Y' ")
            sql.AppendLine(" where item_orgid=@Orgcode ")
            sql.AppendLine(" and item_code=@item_code ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("item_code", SqlDbType.VarChar)
            params(1).Value = item_code

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace

