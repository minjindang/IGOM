Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SAL2113DAO
    Inherits BaseDAO

    Public Function GetExtData(v_ym As String, strBudget As String) As DataTable


        Dim sql As String = ""

        '003	P	004	001	薪資(50)
        '003	P	004	002	租賃(51)
        '003	P	004	003	短期票券所得(52)
        '003	P	004	005	盈餘(54)
        '003	P	004	006	利息(享儲蓄投資特扣額)(5A)
        '003	P	004	007	利息(未享儲蓄投資特扣額)(5B)
        '003	P	004	013	執行業務所得(9A)
        '003	P	004	014	稿費所得(9B)
     
        sql &= " select isnull(sum(inco_health_ext),0) as amt,'非所屬投保單位給付之薪資所得(薪資)' as code_desc1,'0011' as Code_No"
        sql &= " from"
        sql &= " sal_sainco a"
        sql &= " inner join sal_SABASE b on a.inco_seqno = BASE_SEQNO and isnull(BASE_PARTTIME,'Y') = 'Y'"
        sql &= " where (a.inco_code = '001'  or  (a.inco_code = '005' and a.inco_icode = '001')) and substring(inco_date,1,6) = @YM "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in (" & strBudget & ")  "
        End If

        sql &= " having isnull(sum(inco_health_ext), 0) > 0"
        sql &= " union"
        sql &= " select isnull(sum(inco_health_ext),0) as amt,'逾當月投保金額四倍之部份獎金(獎金)' as code_desc1,'001' as Code_No"
        sql &= " from"
        sql &= " sal_sainco a"
        sql &= " inner join sal_SABASE b on a.inco_seqno = BASE_SEQNO and isnull(BASE_PARTTIME,'Y') = 'N'"
        sql &= " where (a.inco_code in ('002','003','004') or  (a.inco_code = '005' and a.inco_icode = '001')) and substring(inco_date,1,6) = @YM "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in (" & strBudget & ")  "
        End If

        sql &= " having isnull(sum(inco_health_ext), 0) > 0"
        sql &= " union"
        sql &= " select isnull(sum(inco_health_ext),0) as amt,'執行業務所得' as code_desc1,'013' as Code_No"
        sql &= " from"
        sql &= " sal_sainco a"
        sql &= " where a.inco_icode in ('013', '014') and substring(inco_date,1,6) = @YM "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in (" & strBudget & ")  "
        End If

        sql &= " having isnull(sum(inco_health_ext), 0) > 0"
        sql &= " union"
        sql &= " select isnull(sum(inco_health_ext),0) as amt,'利息所得' as code_desc1,'006' as Code_No"
        sql &= " from"
        sql &= " sal_sainco a"
        sql &= " where a.inco_icode in ('006', '007', '003') and substring(inco_date,1,6) = @YM "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in (" & strBudget & ")  "
        End If

        sql &= " having isnull(sum(inco_health_ext), 0) > 0"
        sql &= " union"
        sql &= " select isnull(sum(inco_health_ext),0) as amt,'租金所得' as code_desc1,'002' as Code_No"
        sql &= " from"
        sql &= " sal_sainco a"
        sql &= " where a.inco_icode in ('002', '016', '017', '018', '019', '020') and substring(inco_date,1,6) = @YM "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in (" & strBudget & ")  "
        End If

        sql &= " having isnull(sum(inco_health_ext), 0) > 0"

        Dim param() As SqlParameter = {New SqlParameter("@YM", v_ym), _
                                       New SqlParameter("@strBudget", strBudget)}

        Return Query(sql, param)

    End Function


    Public Function GetNhiInfoData(v_UserOrgId As String, v_nhiym As String, strBudget As String, type As String) As DataTable
        Dim sql As String = ""

        sql &= " SELECT CASE INCO_CODE  "
        sql &= "                 WHEN '001' THEN SUBSTRING(INCO_YM, 1, 4)  "
        sql &= "                 WHEN '002' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '003' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '004' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '006' THEN SUBSTRING(INCO_YM, 1, 4)  "
        sql &= "                 WHEN '007' THEN SUBSTRING(INCO_YM, 1, 4) END AS INCO_Y,  "
        sql &= "                 CASE INCO_CODE  "
        sql &= "                 WHEN '001' THEN SUBSTRING(INCO_YM, 5, 2)  "
        sql &= "                 WHEN '002' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '003' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '004' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '006' THEN SUBSTRING(INCO_YM, 5, 2)  "
        sql &= "                 WHEN '007' THEN SUBSTRING(INCO_YM, 5, 2) END AS INCO_M, SUBSTRING(INCO_DATE, 1, 4) AS Y, SUBSTRING(INCO_DATE, 5, 2) AS M, SUBSTRING(INCO_DATE, 7, 2) AS D, INCO_DATE,  "
        sql &= "                 INCO_CODE = CASE INCO_CODE  "
        sql &= "                 WHEN '001' THEN '月薪'  "
        sql &= "                 WHEN '002' THEN '預借考績'  "
        sql &= "                 WHEN '003' THEN '核定考績'  "
        sql &= "                 WHEN '004' THEN '年終獎金'  "
        sql &= "                 WHEN '006' THEN '晉級補發'  "
        sql &= "                 WHEN '007' THEN '補發調薪差額' END,  "
        sql &= "                 COUNT(*) AS INCO_CNT, SUM(INCO_AMT) AS INCO_AMT, SUM(INCO_TXAM) AS INCO_TAX,  "
        sql &= "                 SUM(ISNULL(INCO_KDC_AMT, 0)) AS INCO_KDC_AMT, SUM(ISNULL(INCO_REPL_AMT, 0)) AS INCO_REPL_AMT, SUM(ISNULL(INCO_HOUS_AMT, 0)) AS INCO_HOUS_AMT  "
        sql &= "                 , inco_kind_code , C2.CODE_DESC1 as INCO_KIND  ,CODE_NO"
        sql &= "                 FROM SAL_SAINCO a  "
        sql &= "                 inner join SAL_sabase b on base_orgid=inco_orgid and base_seqno=inco_seqno  "
        sql &= "                  inner join SAL_sapayo y on y.payo_seqno=inco_seqno and payo_orgid=inco_orgid and y.payo_date=inco_date and y.payo_yymm=inco_ym and y.payo_kind_code=inco_kind_code  and payo_kind=inco_code "
        sql &= "                   ,sys_code c2  "
        sql &= "                 WHERE INCO_ORGID = @v_UserOrgId  "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in ( " & strBudget & ")"
        End If

        If type = "Y" Then
            sql &= " and base_status = 'Y' "
        ElseIf type = "N" Then
            sql &= " and base_status = 'N' "
        End If

        sql &= "                 and C2.CODE_SYS = '003' AND C2.CODE_TYPE = '004' AND C2.CODE_NO = a.INCO_ICODE  "
        sql &= "             AND ((INCO_CODE IN ('001', '007') AND INCO_YM LIKE @v_nhiym+'%') "
        sql &= "           OR (INCO_CODE IN ('002', '003', '004', '006') AND INCO_DATE LIKE RTRIM(@v_nhiym) + '%'))  "
        sql &= "                 AND INCO_AMT <> 0 and code_no='001'"
        sql &= "           "
        sql &= "           GROUP BY CASE INCO_CODE  "
        sql &= "                 WHEN '001' THEN SUBSTRING(INCO_YM, 1, 4)  "
        sql &= "                 WHEN '002' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '003' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '004' THEN SUBSTRING(INCO_DATE, 1, 4)  "
        sql &= "                 WHEN '006' THEN SUBSTRING(INCO_YM, 1, 4)  "
        sql &= "                 WHEN '007' THEN SUBSTRING(INCO_YM, 1, 4) END,  "
        sql &= "                 CASE INCO_CODE  "
        sql &= "                 WHEN '001' THEN SUBSTRING(INCO_YM, 5, 2)  "
        sql &= "                 WHEN '002' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '003' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '004' THEN SUBSTRING(INCO_DATE, 5, 2)  "
        sql &= "                 WHEN '006' THEN SUBSTRING(INCO_YM, 5, 2)  "
        sql &= "                 WHEN '007' THEN SUBSTRING(INCO_YM, 5, 2) END,  "
        sql &= "                 INCO_DATE, INCO_CODE  "
        sql &= "                 , inco_kind_code , C2.CODE_DESC1  ,CODE_NO"
        sql &= "                 UNION  "
        sql &= "                 SELECT SUBSTRING(INCO_DATE, 1, 4) AS INCO_Y, SUBSTRING(INCO_DATE, 5, 2) AS INCO_M, SUBSTRING(INCO_DATE, 1, 4) AS Y, SUBSTRING(INCO_DATE, 5, 2) AS M, SUBSTRING(INCO_DATE, 7, 2) AS D, INCO_DATE,  "
        sql &= "                 CASE isnull(PITS_MEMO,'') WHEN '' THEN ISNULL(ITEM_NAME, '不明薪津') ELSE isnull(PITS_MEMO,'') END  AS INCO_CODE,  "
        sql &= "                 COUNT(*) AS INCO_CNT, SUM(INCO_AMT) AS INCO_AMT, SUM(INCO_TXAM) AS INCO_TAX,  "
        sql &= "                 SUM(ISNULL(INCO_KDC_AMT, 0)) AS INCO_KDC_AMT, SUM(ISNULL(INCO_REPL_AMT, 0)) AS INCO_REPL_AMT, SUM(ISNULL(INCO_HOUS_AMT, 0)) AS INCO_HOUS_AMT  "
        sql &= "                 , inco_kind_code , C2.CODE_DESC1 as INCO_KIND  , C2.CODE_NO"
        sql &= "                 FROM SAL_SAINCO a  "
        sql &= "                 inner join SAL_sabase on base_orgid=inco_orgid and base_seqno=inco_seqno  "
        sql &= "                 LEFT JOIN SAL_SAITEM ON INCO_ORGID = ITEM_ORGID  "
        sql &= "                 AND INCO_CODE = ITEM_CODE_SYS  "
        sql &= "                 AND INCO_KIND_CODE_TYPE = ITEM_CODE_TYPE  "
        sql &= "                 AND INCO_KIND_CODE_NO = ITEM_CODE_NO  "
        sql &= "                 AND INCO_KIND_CODE = ITEM_CODE  "
        sql &= "                 LEFT JOIN SAL_SAPITS  "
        sql &= "                 ON PITS_ORGID = INCO_ORGID  "
        sql &= "                 AND PITS_KIND = INCO_CODE  "
        sql &= "                 AND PITS_YM = INCO_YM  "
        sql &= "                 AND PITS_DATE = INCO_DATE  "
        sql &= "                 AND PITS_CODE_TYPE = INCO_KIND_CODE_TYPE  "
        sql &= "                 AND PITS_CODE_NO = INCO_KIND_CODE_NO  "
        sql &= "                 AND PITS_CODE = INCO_KIND_CODE  "
        sql &= "                  inner join SAL_sapayo y on y.payo_seqno=inco_seqno and payo_orgid=inco_orgid and y.payo_date=inco_date and y.payo_yymm=inco_ym and y.payo_kind_code=inco_kind_code  and payo_kind=inco_code "
        sql &= "                 ,sys_code c2  "
        sql &= "                 WHERE INCO_ORGID = @v_UserOrgId  "

        If strBudget <> "'ALL'" Then
            sql &= " and inco_Budget_code in ( " & strBudget & ")  "
        End If

        If type = "Y" Then
            sql &= " and base_status = 'Y' "
        ElseIf type = "N" Then
            sql &= " and base_status = 'N' "
        End If

        sql &= " AND INCO_DATE LIKE RTRIM(@v_nhiym) + '%' AND INCO_CODE = '005' AND INCO_AMT <> 0  "
        sql &= "                 and C2.CODE_SYS = '003' AND C2.CODE_TYPE = '004' AND C2.CODE_NO = a.INCO_ICODE and code_no='001'"
        sql &= "            GROUP BY SUBSTRING(INCO_DATE, 1, 4), SUBSTRING(INCO_DATE, 5, 2), INCO_DATE, ITEM_NAME "
        sql &= "                 ,CASE isnull(PITS_MEMO,'') WHEN '' THEN ISNULL(ITEM_NAME, '不明薪津') ELSE isnull(PITS_MEMO,'') END  "
        sql &= "                 , inco_kind_code ,C2.CODE_DESC1,CODE_NO"

        Dim param() As SqlParameter = {New SqlParameter("@v_UserOrgId", v_UserOrgId), _
                                       New SqlParameter("@v_nhiym", v_nhiym), _
                                   New SqlParameter("@strBudget", strBudget)}

        Return Query(sql, param)

    End Function


    Public Function GetUnit(v_UserOrgId As String) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "select CODE_DESC1 + '(' + CODE_DESC2 + ')' as text"
        sql &= "  , CODE_DESC2  "
        sql &= " from SYS_CODE  "
        sql &= " where CODE_SYS = '002'"
        sql &= " and CODE_TYPE = '018'"

        Dim param() As SqlParameter = {New SqlParameter("@v_UserOrgId", v_UserOrgId)}
        Return Query(sql, param)

    End Function
End Class
