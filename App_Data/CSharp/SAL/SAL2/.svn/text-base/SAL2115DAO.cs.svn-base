using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2115DAO 的摘要描述
/// </summary>
public class SAL2115DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL2115DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2115DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 取得報表資料
    public DataTable getReportData(
          string strYear        // 年份
        , string strMonth       //月份   
        , string strUnit        //單位別
        , string strName        //員工姓名
        , string strtype        //人員類別
        , string strNum         //員工編號   
        , string strLogDeptCD   // 登入者機關代碼
        )
    {
        String strSQL =
              " SELECT DISTINCT B.BASE_SEQNO" //--人員編號(第二層SQL查詢使用)
            + ", B.BASE_NAME"//--人員姓名
            + ", B.BASE_IDNO"//--身分證字號 
            + " FROM SAL_SAINCO I, SAL_SABASE B "
            + " WHERE I.INCO_SEQNO = B.BASE_SEQNO "
            + " AND I.INCO_ORGID = B.BASE_ORGID "
            + "  AND B.BASE_IDNO IS NOT NULL "
            + " AND B.BASE_NAME IS NOT NULL "
            + " AND ("
            + "    (I.INCO_CODE IN ('001', '007') AND I.INCO_YM LIKE @YearMonth + '%') "
            + "    OR (I.INCO_CODE IN ('002', '003', '004','005', '006') AND I.INCO_DATE LIKE RTRIM(@YearMonth) + '%')"
            + "   )"
            + "  AND I.INCO_ORGID = @LogDeptCD ";
            if(strName !="")
            {
                strSQL += "  AND B.BASE_NAME LIKE '%' + @strName + '%'";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if(strNum !="")
            {
                strSQL += "  AND B.BASE_SEQNO = @strNum";//--當使用者輸入員工編號欄位時，增加此查詢條件
            }
            strSQL += "  AND B.BASE_PRONO IN (@strtype)"
            + "  AND B.BASE_DEP IN (@strUnit)"
            + "  ORDER BY BASE_IDNO ";


        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYear+strMonth), //畫面選單之年加月       
            new SqlParameter("@LogDeptCD",strLogDeptCD) ,//登入者機關代碼
            new SqlParameter("@strName",strName), //員工姓名
            new SqlParameter("@strNum",strNum) ,//員工編號
            new SqlParameter("@strtype",strtype), //人員類別   
            new SqlParameter("@strUnit",strUnit) //單位          
        };

        return Query(strSQL, sp);
    }

    public DataTable getReportData2(
        string strYear        // 年份
      , string strMonth       //月份   
      , string strLogDeptCD   // 登入者機關代碼
      , string BASE_SEQNO  //列印之人員
        )
    {
        String strSQL =
                "SELECT ISNULL((CASE INCO_CODE "
              + " WHEN '001' THEN '月薪' "
              + " WHEN '002' THEN '預借考績' "
              + " WHEN '003' THEN '核定考績' "
              + "  WHEN '004' THEN '年終獎金' "
              + "  WHEN '006' THEN '晉級補發' "
              + "  WHEN '007' THEN '補發調薪差額' "
              + "  WHEN '005' THEN ITEM_NAME "
              + "  ELSE '' END), '不明薪津') AS INCO_ITEM "//--報表呈現之所得項目
              + "  , I.INCO_SEQNO, I.INCO_YM "
              + "  , I.INCO_DATE "//報表呈現之給付日期
              + "  , I.INCO_CODE "
              + "  , I.INCO_ICODE "//--所得格式代碼(表尾統計分類用)
              + "  , C2.CODE_DESC1 INCO_KIND "//--報表呈現之所得格式
              + "  , ISNULL(I.INCO_AMT, 0) AS INCO_AMT "//--報表呈現之申報金額
              + "  , ISNULL( ( select payod_amt from sal_sapayod where payod_orgid = inco_orgid and payod_seqno = inco_seqno and payod_kind = inco_code and payod_ym = inco_ym and payod_date = inco_date and payod_kind_code_type = inco_kind_code_type and payod_kind_code_no = inco_kind_code_no and payod_kind_code = inco_kind_code and payod_code_sys = '003' and payod_code_type = '003' and payod_code_no = '001' ),0) AS PAYOD_AMT "//--報表呈現之應發金額(一)，若此金額為0，則改用應發金額(二)之金額
              + "  , ISNULL(I.INCO_REAL_AMT, 0) AS INCO_REAL_AMT "//--報表呈現之應發金額(二)，若應發金額(一)金額為0，則改用應發金額(二)之金額
              + "  , ISNULL(I.INCO_TXRA, 0) AS INCO_TXRA "
              + "  , ISNULL(I.INCO_TXAM, 0) AS INCO_TXAM "//--報表呈現之扣繳稅額金額
              + "  , ISNULL(I.INCO_KDC_AMT, 0) AS INCO_KDC_AMT "
              + "  , ISNULL(I.INCO_REPL_AMT, 0) AS INCO_REPL_AMT "
              + "  , ISNULL(I.INCO_HOUS_AMT, 0) AS INCO_HOUS_AMT "
              + "  FROM SAL_SAINCO I "
              + "  LEFT outer JOIN SAL_SAITEM "
              + "  ON INCO_ORGID = ITEM_ORGID "
              + "  AND INCO_CODE = ITEM_CODE_SYS "
              + "  AND INCO_KIND_CODE_TYPE = ITEM_CODE_TYPE "
              + "  AND INCO_KIND_CODE_NO = ITEM_CODE_NO "
              + "  AND INCO_KIND_CODE = ITEM_CODE "
              + "  , SACODE C2 "
              + "  WHERE I.INCO_SEQNO = @BASE_SEQNO "
              + "  AND I.INCO_ORGID = @LogDeptCD "
              + "  AND ("
              + "  (I.INCO_CODE IN ('001', '007') AND I.INCO_YM LIKE @YearMonth + '%')"
              + "  OR (I.INCO_CODE IN ('002', '003', '004','005', '006') AND I.INCO_DATE LIKE RTRIM(@YearMonth) + '%')"
              + "  ) "
              + "  AND I.INCO_KIND_CODE_TYPE <> '002' "
              + "  AND C2.CODE_SYS = '003' "
              + "  AND C2.CODE_TYPE = '004' "
              + "  AND C2.CODE_NO = I.INCO_ICODE "
              + "  ORDER BY INCO_DATE, INCO_CODE, INCO_KIND_CODE_TYPE, INCO_KIND_CODE_NO, INCO_KIND_CODE ";
         
        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYear+strMonth), //畫面選單之年加月       
            new SqlParameter("@LogDeptCD",strLogDeptCD) ,//登入者機關代碼       
            new SqlParameter("@BASE_SEQNO",BASE_SEQNO) ,//第一層取得之人員編號(BASE_SEQNO)         
        };

        return Query(strSQL, sp);
    }


}