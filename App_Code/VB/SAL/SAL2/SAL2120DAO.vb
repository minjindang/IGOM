Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SAL2120DAO
    Inherits BaseDAO

    Public Function getProj(ByVal v_orgid As String) As DataTable
        Dim sql As String = " select proj_code, proj_code_name from sal_saproj where proj_orgid=@proj_orgid order by proj_code "

        Dim param() As SqlParameter = {New SqlParameter("@proj_orgid", v_orgid)}

        Return Query(sql, param)
    End Function

    Public Function getJob(ByVal v_orgid As String, ByVal code_sys As String, ByVal code_type As String) As DataTable
        Dim sql As String = ""
        sql &= " select CODE_NO, code_desc1 from sys_code "
        sql &= " where CODE_SYS = @sys and CODE_TYPE = @type "

        Dim param() As SqlParameter = {New SqlParameter("@orgid", v_orgid), _
                                       New SqlParameter("@sys", code_sys), _
                                       New SqlParameter("@type", code_type)}

        Return Query(sql, param)
    End Function

    Public Function getData(ByVal v_UserOrgId As String, ByVal s_date As String, ByVal s_name As String, ByVal s_proj As String, _
                            ByVal s_job As String, ByVal s_bdate As String) As DataTable
        Dim sql As StringBuilder = New StringBuilder
        sql.AppendLine(" select PAYO_SEQNO ")
        sql.AppendLine(" , case PAYO_PARTTIME when 'N' then '62' else '63' end as NHIKIND ")
        sql.AppendLine(" , PAYO_NAME ")
        sql.AppendLine(" , PAYO_KIND ")
        sql.AppendLine(" , PAYO_KIND_CODE_TYPE ")
        sql.AppendLine(" , PAYO_KIND_CODE_NO ")
        sql.AppendLine(" , ( ")
        sql.AppendLine(" select SUM(d.PAYOD_AMT)  ")
        sql.AppendLine(" from sal_SAPAYOD d ")
        sql.AppendLine(" where d.PAYOD_ORGID = PAYO_ORGID ")
        sql.AppendLine(" and d.PAYOD_SEQNO = PAYO_SEQNO ")
        sql.AppendLine(" and d.PAYOD_KIND = PAYO_KIND ")
        sql.AppendLine(" and d.PAYOD_YM = PAYO_YYMM ")
        sql.AppendLine(" and d.PAYOD_DATE = PAYO_DATE ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE_TYPE  = PAYO_KIND_CODE_TYPE ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE_NO = PAYO_KIND_CODE_NO ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE = PAYO_KIND_CODE ")
        sql.AppendLine(" and d.PAYOD_CODE_TYPE = '001' ")
        sql.AppendLine(" and d.PAYOD_INCOME = 'Y' ")
        sql.AppendLine(" ) as AMT ")
        sql.AppendLine(" , PAYO_DATE ")
        sql.AppendLine(" , PAYOD_AMT as EXT ")
        sql.AppendLine(" from SAL_SABASE ")
        sql.AppendLine(" inner join SAL_SAPAYO ")
        sql.AppendLine(" on BASE_ORGID = PAYO_ORGID ")
        sql.AppendLine(" and BASE_SEQNO = PAYO_SEQNO   ")
        sql.AppendLine(" inner join SAL_SAPAYOD   ")
        sql.AppendLine(" on PAYOD_ORGID = PAYO_ORGID  ")
        sql.AppendLine(" and PAYOD_SEQNO = PAYO_SEQNO  ")
        sql.AppendLine(" and PAYOD_KIND = PAYO_KIND ")
        sql.AppendLine(" and PAYOD_YM = PAYO_YYMM ")
        sql.AppendLine(" and PAYOD_DATE = PAYO_DATE  ")
        sql.AppendLine(" and PAYOD_KIND_CODE_TYPE  = PAYO_KIND_CODE_TYPE  ")
        sql.AppendLine(" and PAYOD_KIND_CODE_NO = PAYO_KIND_CODE_NO   ")
        sql.AppendLine(" and PAYOD_KIND_CODE = PAYO_KIND_CODE  ")
        sql.AppendLine(" and PAYOD_CODE_SYS = '003' ")
        sql.AppendLine(" and PAYOD_CODE_KIND = 'P' ")
        sql.AppendLine(" and PAYOD_CODE_TYPE = '002' ")
        sql.AppendLine(" and PAYOD_CODE_NO = '017' ")
        sql.AppendLine(" and PAYOD_AMT > 0   ")
        sql.AppendLine(" where PAYO_ORGID   =   @v_UserOrgId ")
        sql.AppendLine(" and PAYO_DATE like  @s_date ")

        If Not String.IsNullOrEmpty(s_name) Then
            sql.AppendLine(" and ( base_idno like @s_name or base_name like @s_name) ")
        End If
        If Not String.IsNullOrEmpty(s_proj) Then
            sql.AppendLine(" and base_prono = @s_proj ")
        End If
        If Not String.IsNullOrEmpty(s_job) Then
            sql.AppendLine(" and.base_job = @s_job ")
        End If

        If s_bdate = "1" Then      '--在職員工
            sql.AppendLine(" and (base_edate > @now or base_edate is null or base_edate = '') ")
            sql.AppendLine(" and isnull(base_quit_date,'') = '' ")
            sql.AppendLine(" and base_status = 'Y' ")
        End If
        If s_bdate = "2" Then      '--離職員工
            sql.AppendLine(" and ( ")
            sql.AppendLine("      (base_edate <= @now and base_edate<>'') ")
            sql.AppendLine("      or  (base_quit_date <>'') ")
            sql.AppendLine(" ) ")
            sql.AppendLine(" and base_status = 'Y' ")
        End If
        If s_bdate = "3" Then      '--非員工
            sql.AppendLine(" and base_status = 'N' ")
        End If

        'sql.AppendLine(" order by cast(isnull(c.proj_sort,999) as float), cast(isnull(b.base_prts,999) as float), inco_date, inco_code ")

        Dim params() As SqlParameter = {New SqlParameter("@v_UserOrgId", v_UserOrgId), _
                                        New SqlParameter("@s_date", s_date + "%"), _
                                        New SqlParameter("@s_name", "%" + s_name + "%"), _
                                        New SqlParameter("@s_proj", s_proj), _
                                        New SqlParameter("@s_job", s_job)}

        Return Query(sql.ToString(), params)
    End Function

    Public Function getData2(ByVal v_UserOrgId As String, ByVal s_year As String, ByVal s_name As String, ByVal s_proj As String, _
                            ByVal s_job As String, ByVal s_bdate As String) As DataTable
        Dim sql As StringBuilder = New StringBuilder
        sql.AppendLine(" select PAYO_SEQNO, NHIKIND, PAYO_NAME ")
        sql.AppendLine(" , SUM(AMT) as AMT ")
        sql.AppendLine(" , SUM(EXT) as EXT ")
        sql.AppendLine(" from  ")
        sql.AppendLine(" ( ")
        sql.AppendLine(" select PAYO_SEQNO ")
        sql.AppendLine(" , case PAYO_PARTTIME when 'N' then '62' else '63' end as NHIKIND ")
        sql.AppendLine(" , PAYO_NAME ")
        sql.AppendLine(" , ( ")
        sql.AppendLine(" select SUM(d.PAYOD_AMT)  ")
        sql.AppendLine(" from SAL_SAPAYOD d ")
        sql.AppendLine(" where d.PAYOD_ORGID = PAYO_ORGID  ")
        sql.AppendLine(" and d.PAYOD_SEQNO = PAYO_SEQNO  ")
        sql.AppendLine(" and d.PAYOD_KIND = PAYO_KIND ")
        sql.AppendLine(" and d.PAYOD_YM = PAYO_YYMM ")
        sql.AppendLine(" and d.PAYOD_DATE = PAYO_DATE  ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE_TYPE  = PAYO_KIND_CODE_TYPE  ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE_NO = PAYO_KIND_CODE_NO   ")
        sql.AppendLine(" and d.PAYOD_KIND_CODE = PAYO_KIND_CODE  ")
        sql.AppendLine(" and d.PAYOD_CODE_TYPE = '001' ")
        sql.AppendLine(" and d.PAYOD_INCOME = 'Y' ")
        sql.AppendLine(" ) as AMT ")
        sql.AppendLine(" , PAYOD_AMT as EXT ")
        sql.AppendLine(" from SAL_SABASE ")
        sql.AppendLine(" inner join SAL_SAPAYO ")
        sql.AppendLine(" on BASE_ORGID = PAYO_ORGID ")
        sql.AppendLine(" and BASE_SEQNO = PAYO_SEQNO ")
        sql.AppendLine(" inner join SAL_SAPAYOD   ")
        sql.AppendLine(" on PAYOD_ORGID = PAYO_ORGID  ")
        sql.AppendLine(" and PAYOD_SEQNO = PAYO_SEQNO  ")
        sql.AppendLine(" and PAYOD_KIND = PAYO_KIND ")
        sql.AppendLine(" and PAYOD_YM = PAYO_YYMM ")
        sql.AppendLine(" and PAYOD_DATE = PAYO_DATE  ")
        sql.AppendLine(" and PAYOD_KIND_CODE_TYPE  = PAYO_KIND_CODE_TYPE  ")
        sql.AppendLine(" and PAYOD_KIND_CODE_NO = PAYO_KIND_CODE_NO   ")
        sql.AppendLine(" and PAYOD_KIND_CODE = PAYO_KIND_CODE  ")
        sql.AppendLine(" and PAYOD_CODE_SYS = '003' ")
        sql.AppendLine(" and PAYOD_CODE_KIND = 'P' ")
        sql.AppendLine(" and PAYOD_CODE_TYPE = '002' ")
        sql.AppendLine(" and PAYOD_CODE_NO = '017' ")
        sql.AppendLine(" and PAYOD_AMT > 0   ")

        sql.AppendLine(" where PAYO_ORGID   =   @v_UserOrgId ")
        sql.AppendLine(" and PAYO_DATE like  @s_year ")

        If Not String.IsNullOrEmpty(s_name) Then
            sql.AppendLine(" and ( base_idno like @s_name or base_name like @s_name) ")
        End If
        If Not String.IsNullOrEmpty(s_proj) Then
            sql.AppendLine(" and base_prono = @s_proj ")
        End If
        If Not String.IsNullOrEmpty(s_job) Then
            sql.AppendLine(" and.base_job = @s_job ")
        End If

        If s_bdate = "1" Then      '--在職員工
            sql.AppendLine(" and (base_edate > @now or base_edate is null or base_edate = '') ")
            sql.AppendLine(" and isnull(base_quit_date,'') = '' ")
            sql.AppendLine(" and base_status = 'Y' ")
        End If
        If s_bdate = "2" Then      '--離職員工
            sql.AppendLine(" and ( ")
            sql.AppendLine("      (base_edate <= @now and base_edate<>'') ")
            sql.AppendLine("      or  (base_quit_date <>'') ")
            sql.AppendLine(" ) ")
            sql.AppendLine(" and base_status = 'Y' ")
        End If
        If s_bdate = "3" Then      '--非員工
            sql.AppendLine(" and base_status = 'N' ")
        End If

        sql.AppendLine(" ) a ")
        sql.AppendLine(" group by PAYO_SEQNO, NHIKIND, PAYO_NAME ")
        'sql.AppendLine(" order by cast(isnull(c.proj_sort,999) as float), cast(isnull(b.base_prts,999) as float), inco_date, inco_code ")

        Dim params() As SqlParameter = {New SqlParameter("@v_UserOrgId", v_UserOrgId), _
                                        New SqlParameter("@s_year", s_year + "%"), _
                                        New SqlParameter("@s_name", "%" + s_name + "%"), _
                                        New SqlParameter("@s_proj", s_proj), _
                                        New SqlParameter("@s_job", s_job)}

        Return Query(sql.ToString(), params)
    End Function
End Class
