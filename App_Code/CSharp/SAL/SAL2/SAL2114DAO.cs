using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2114DAO 的摘要描述
/// </summary>
public class SAL2114DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL2114DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2114DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 取得報表資料
    public DataTable getReportData(
          string strYear        // 年份
        , string strMonth       //月份
        , int strSort           // 排序
        , string strLogDeptCD   // 登入者機關代碼
        )
    {
        String strSQL =
        "  SELECT CASE INCO_CODE "
+ "WHEN '001' THEN SUBSTRING(INCO_YM, 1, 4) "
+ "WHEN '002' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '003' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '004' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '006' THEN SUBSTRING(INCO_YM, 1, 4) "
+ "WHEN '007' THEN SUBSTRING(INCO_YM, 1, 4) END AS INCO_Y " //--報表清單之年度(1)
+ ", CASE INCO_CODE "
+ "WHEN '001' THEN SUBSTRING(INCO_YM, 5, 2) "
+ "WHEN '002' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '003' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '004' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '006' THEN SUBSTRING(INCO_YM, 5, 2) "
+ "WHEN '007' THEN SUBSTRING(INCO_YM, 5, 2) END AS INCO_M"//--報表清單之月份(2)
+ ", INCO_DATE"//--報表清單之日期(3)
+ ", CASE INCO_CODE "
+ "WHEN '001' THEN '月薪' "
+ "WHEN '002' THEN '預借考績' "
+ "WHEN '003' THEN '核定考績' "
+ "WHEN '004' THEN '年終獎金' "
+ "WHEN '006' THEN '晉級補發' "
+ "WHEN '007' THEN '補發調薪差額' END AS INCO_CODE"//--報表清單之薪津項目(4)
+ ", COUNT(*) AS INCO_CNT"//--報表清單之件數(5)
+ ", SUM(INCO_AMT) AS INCO_AMT"//--報表清單之申報金額(6)
+ ", SUM(ISNULL(INCO_KDC_AMT, 0)) AS INCO_KDC_AMT"//--報表清單之主管加給(7)
+ ", SUM(ISNULL(INCO_REPL_AMT, 0)) AS INCO_REPL_AMT"//--報表清單之實物代金(8)
+ ", SUM(ISNULL(INCO_HOUS_AMT, 0)) AS INCO_HOUS_AMT"//--報表清單之房屋津貼(9)
+ ", SUM(INCO_TXAM) AS INCO_TAX"//--報表清單之扣繳金額(10)
+ ", inco_kind_code "
+ "FROM SAL_SAINCO "
+ "WHERE INCO_ORGID = @LogDeptCD "
+ "AND ((INCO_CODE IN ('001', '007') AND INCO_YM LIKE @YearMonth + '%')"
+ "OR (INCO_CODE IN ('002', '003', '004', '006') AND INCO_DATE LIKE RTRIM(@YearMonth) + '%')) "
+ "AND INCO_AMT <> 0 "
+ "GROUP BY CASE INCO_CODE "
+ "WHEN '001' THEN SUBSTRING(INCO_YM, 1, 4) "
+ "WHEN '002' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '003' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '004' THEN SUBSTRING(INCO_DATE, 1, 4) "
+ "WHEN '006' THEN SUBSTRING(INCO_YM, 1, 4) "
+ "WHEN '007' THEN SUBSTRING(INCO_YM, 1, 4) END, "
+ "CASE INCO_CODE "
+ " WHEN '001' THEN SUBSTRING(INCO_YM, 5, 2) "
+ "WHEN '002' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '003' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '004' THEN SUBSTRING(INCO_DATE, 5, 2) "
+ "WHEN '006' THEN SUBSTRING(INCO_YM, 5, 2) "
+ "WHEN '007' THEN SUBSTRING(INCO_YM, 5, 2) END, "
+ "INCO_DATE, INCO_CODE "
+ ", inco_kind_code "
+ "UNION "
+ "SELECT SUBSTRING(INCO_DATE, 1, 4) AS INCO_Y"//--報表清單之年度(1)
+ ", SUBSTRING(INCO_DATE, 5, 2) AS INCO_M"//--報表清單之月份(2)"
+ ", INCO_DATE"//--報表清單之日期(3)"
+ ", CASE isnull(PITS_MEMO,'') WHEN '' THEN ISNULL(ITEM_NAME, '不明薪津') ELSE isnull(PITS_MEMO,'') END  AS INCO_CODE"//--報表呈現之薪津項目(4)"
+ ", COUNT(*) AS INCO_CNT"//--報表清單之件數(5)"
+ ", SUM(INCO_AMT) AS INCO_AMT"//--報表清單之申報金額(6)"
+ ", SUM(ISNULL(INCO_KDC_AMT, 0)) AS INCO_KDC_AMT"//--報表清單之主管加給(7)"
+ ", SUM(ISNULL(INCO_REPL_AMT, 0)) AS INCO_REPL_AMT"//--報表清單之實物代金(8)"
+ ", SUM(ISNULL(INCO_HOUS_AMT, 0)) AS INCO_HOUS_AMT"//--報表清單之房屋津貼(9)"
+ ", SUM(INCO_TXAM) AS INCO_TAX"//--報表清單之扣繳金額(10)"
+ ", inco_kind_code"//--排序用之項目代碼(11)"
+ " FROM SAL_SAINCO "
+ "LEFT JOIN SAL_SAITEM "
+ "ON INCO_ORGID = ITEM_ORGID "
+ "AND INCO_CODE = ITEM_CODE_SYS "
+ "AND INCO_KIND_CODE_TYPE = ITEM_CODE_TYPE "
+ "AND INCO_KIND_CODE_NO = ITEM_CODE_NO "
+ "AND INCO_KIND_CODE = ITEM_CODE "
+ "LEFT JOIN SAL_SAPITS "
+ "ON PITS_ORGID = INCO_ORGID "
+ "AND PITS_KIND = INCO_CODE "
+ "AND PITS_YM = INCO_YM "
+ "AND PITS_DATE = INCO_DATE "
+ "AND PITS_CODE_TYPE = INCO_KIND_CODE_TYPE "
+ "AND PITS_CODE_NO = INCO_KIND_CODE_NO "
+ "AND PITS_CODE = INCO_KIND_CODE "
+ "WHERE INCO_ORGID = @LogDeptCD "
+ "AND INCO_DATE LIKE RTRIM(@YearMonth) + '%' "
+ "AND INCO_CODE = '005' "
+ "AND INCO_AMT <> 0 "
+ "GROUP BY SUBSTRING(INCO_DATE, 1, 4), SUBSTRING(INCO_DATE, 5, 2), INCO_DATE, ITEM_NAME"
+ ",CASE isnull(PITS_MEMO,'') WHEN '' THEN ISNULL(ITEM_NAME, '不明薪津') ELSE isnull(PITS_MEMO,'') END "
+ ", inco_kind_code";//--排序用之項目代碼(11)
        //排序方式
        if (strSort == 0)
        {
            strSQL += " ORDER BY INCO_Y, INCO_M, INCO_DATE, inco_kind_code, INCO_CODE";//--畫面排序方式選擇依所得年月排序使用此排序條件
        }
        else if (strSort == 1)
        {
            strSQL += " ORDER BY inco_kind_code, INCO_CODE, INCO_Y, INCO_M, INCO_DATE";//--畫面排序方式選擇依所得項目排序使用此排序條件
        }
        else if (strSort == 2)
        {
            strSQL += " ORDER BY INCO_AMT, INCO_Y, INCO_M, INCO_DATE, inco_kind_code, INCO_CODE";//--畫面排序方式選擇依所得金額排序使用此排序條件
        }
        else
        {
            strSQL += " ORDER BY INCO_CNT, INCO_Y, INCO_M, INCO_DATE, inco_kind_code, INCO_CODE";//--畫面排序方式選擇依所得件數排序使用此排序條件
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYear+strMonth), //畫面選單之年月       
            new SqlParameter("@LogDeptCD",strLogDeptCD) //登入者機關代碼
          
        };

        return Query(strSQL, sp);
    }



}