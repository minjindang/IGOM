using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2116DAO 的摘要描述
/// SAL2116 每月所得統計表
///  Eliot Chen
/// </summary>
/// 

public class SAL2116DAO : BaseDAO
{
    public SAL2116DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2116DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 查詢相關項目名稱
    public DataTable querySalItemName(
        string strOrgID,               // 機關代碼
        string strItemType             // 項目類別
        )
    {
        string strSQL =
            "select item_code " +    //--下拉選單代碼
            ",item_name " +          //--下拉選單文字
            //--項目名稱代碼中下拉的代碼
            "from sal_saitem " +
            "where item_orgid = @OrgID " +
            "and item_code_no = @ItemType ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@ItemType", strItemType)
        };
        return Query(strSQL, sp);
    }

    // 取得相關發放日期
    public DataTable queryIncoDate(
        string strOrgID,
        string strIncoCode,     // 發放種壘 
        string strIncoYM,       // 薪資年月
        string strIncoKindCode // 項目名稱代碼 
        )
    {
        string strSQL =
            "SELECT DISTINCT INCO_DATE " +//--下拉選單日期內容
            ",cast(INCO_DATE as int)-19110000 as paydate " +//--下拉選單日期文字
            "FROM SAL_SAINCO " +//
            "WHERE INCO_ORGID = @OrgID " +//'登入者機關代碼'
            "AND INCO_CODE = @IncoCode ";//'第一步查詢畫面之發放種類代碼(code_no)'
        if (strIncoCode == "002" || strIncoCode == "003" || strIncoCode == "004")
        {
            //'第一步畫面之薪資年月，當發放種類代碼為002,003,004時，只要取得年度'
            strIncoYM = strIncoYM.Substring(0, 4);
        }
        strSQL +=
            "AND INCO_YM = @IncoYM ";
        if (strIncoCode == "005")
        {
            strSQL +=
                "AND INCO_KIND_CODE = @IncoKindCode ";   //'第二步畫面之項目名稱代碼—當發放種類代碼為005, 增加此查詢條件'
        }
        strSQL +=
            "GROUP BY INCO_DATE " +//
            "ORDER BY INCO_DATE ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoYM",strIncoYM),
            new SqlParameter("@IncoKindCode", strIncoKindCode)
        };
        return Query(strSQL, sp);

    }

    // 報表查詢
    public DataTable queryReportPart1(
        string strOrgID,
        string strIncoCode,         // 發放種壘 
        string strIncoYM,           // 薪資年月
        string strIncoKindCode      // 項目名稱代碼 
        , string strIncoDate        //'查詢畫面第三步之發放日期'
        , string strBaseProNo       // '查詢畫面第四步之人員類別代碼(code_no)'
        , string strIncoBudGeCode   //'查詢畫面第四步之預算來源代碼(code_no)'
        , string strIncoICode       //'查詢畫面第四步之所得類別代碼(code_no)'
        )
    {
        if (strIncoCode == "002" || strIncoCode == "003" || strIncoCode == "004")
        {
            //'第一步畫面之薪資年月，當發放種類代碼為002,003,004時，只要取得年度'
            strIncoYM = strIncoYM.Substring(0, 4);
        }

        string strSQL =
            "select count(*) as CNT " +//--人數
            ",ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//--應扣繳稅額
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//--給付所得總額
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT " +//--申報所得總額
            "from ( " +//
            "SELECT ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT  " +//
            "FROM  SAL_SAINCO " +//
            "INNER JOIN  SAL_SABASE " +//
            "ON BASE_SEQNO=INCO_SEQNO  " +//
            "AND BASE_ORGID=INCO_ORGID  " +//
            "WHERE INCO_ORGID = @OrgID " +//'登入者機關代碼'
            "AND INCO_CODE = @IncoCode " +//'查詢畫面第一步之發放種類代碼(code_no)'
            "AND INCO_YM = @IncoYM ";//'查詢畫面第一步之薪資年月，若發放種類代碼=002,003,00則只取年度資料'

        if (strIncoCode == "005")
        {
            strSQL +=
                "AND INCO_KIND_CODE_NO = @IncoKinCodeNo ";//'查詢畫面第二步之項目名稱代碼--若發放種類代碼=005，增加此查詢條件'
        }

        strSQL +=
            "AND INCO_DATE = @IncoDate  " +//'查詢畫面第三步之發放日期'
            "AND BASE_PRONO IN ( @BaseProNo )  " +// '查詢畫面第四步之人員類別代碼(code_no)'
            "AND INCO_Budget_code = @IncoBudGeCode " +//'查詢畫面第四步之預算來源代碼(code_no)'
            "AND INCO_icode = @IncoICode " +//'查詢畫面第四步之所得類別代碼(code_no)'
            "AND INCO_AMT<>0  AND INCO_TXAM<>0  " +//--(1)
            "Group by inco_seqno ) a ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoYM",strIncoYM),
            new SqlParameter("@IncoKindCode", strIncoKindCode),
            new SqlParameter("@IncoDate", strIncoDate),
            new SqlParameter("@BaseProNo", strBaseProNo),
            new SqlParameter("@IncoBudGeCode", strIncoBudGeCode),
            new SqlParameter("@IncoICode", strIncoICode)
        };
        return Query(strSQL, sp);
    }

    // 報表查詢
    // 每月給付之薪資：選擇按5%扣繳
    public DataTable queryReportPart2(
        string strOrgID,
        string strIncoCode,         // 發放種壘 
        string strIncoYM,           // 薪資年月
        string strIncoKindCode      // 項目名稱代碼 
        , string strIncoDate        //'查詢畫面第三步之發放日期'
        , string strBaseProNo       // '查詢畫面第四步之人員類別代碼(code_no)'
        , string strIncoBudGeCode   //'查詢畫面第四步之預算來源代碼(code_no)'
        , string strIncoICode       //'查詢畫面第四步之所得類別代碼(code_no)'
        )
    {
        if (strIncoCode == "002" || strIncoCode == "003" || strIncoCode == "004")
        {
            //'第一步畫面之薪資年月，當發放種類代碼為002,003,004時，只要取得年度'
            strIncoYM = strIncoYM.Substring(0, 4);
        }

        string strSQL =
            "select count(*) as CNT " +//--人數
            ",ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//--應扣繳稅額
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//--給付所得總額
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT " +//--申報所得總額
            "from ( " +//
            "SELECT ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT  " +//
            "FROM  SAL_SAINCO " +//
            "INNER JOIN  SAL_SABASE " +//
            "ON BASE_SEQNO=INCO_SEQNO  " +//
            "AND BASE_ORGID=INCO_ORGID  " +//
            "WHERE INCO_ORGID = @OrgID " +//'登入者機關代碼'
            "AND INCO_CODE = @IncoCode " +//'查詢畫面第一步之發放種類代碼(code_no)'
            "AND INCO_YM = @IncoYM ";//'查詢畫面第一步之薪資年月，若發放種類代碼=002,003,00則只取年度資料'

        if (strIncoCode == "005")
        {
            strSQL +=
                "AND INCO_KIND_CODE_NO = @IncoKinCodeNo ";//'查詢畫面第二步之項目名稱代碼--若發放種類代碼=005，增加此查詢條件'
        }

        strSQL +=
            "AND INCO_DATE = @IncoDate  " +//'查詢畫面第三步之發放日期'
            "AND BASE_PRONO IN ( @BaseProNo )  " +// '查詢畫面第四步之人員類別代碼(code_no)'
            "AND INCO_Budget_code = @IncoBudGeCode " +//'查詢畫面第四步之預算來源代碼(code_no)'
            "AND INCO_icode = @IncoICode " +//'查詢畫面第四步之所得類別代碼(code_no)'
            "AND INCO_AMT<>0  AND INCO_TXAM=0 AND INCO_CODE='001' "+
            "Group by inco_seqno ) a ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoYM",strIncoYM),
            new SqlParameter("@IncoKindCode", strIncoKindCode),
            new SqlParameter("@IncoDate", strIncoDate),
            new SqlParameter("@BaseProNo", strBaseProNo),
            new SqlParameter("@IncoBudGeCode", strIncoBudGeCode),
            new SqlParameter("@IncoICode", strIncoICode)
        };
        return Query(strSQL, sp);
    }

    // 報表查詢
    // 獎金、津貼、補助費等非每月給付之薪資及兼職所得：按5%扣繳
    public DataTable queryReportPart3(
        string strOrgID,
        string strIncoCode,         // 發放種壘 
        string strIncoYM,           // 薪資年月
        string strIncoKindCode      // 項目名稱代碼 
        , string strIncoDate        //'查詢畫面第三步之發放日期'
        , string strBaseProNo       // '查詢畫面第四步之人員類別代碼(code_no)'
        , string strIncoBudGeCode   //'查詢畫面第四步之預算來源代碼(code_no)'
        , string strIncoICode       //'查詢畫面第四步之所得類別代碼(code_no)'
        )
    {
        if (strIncoCode == "002" || strIncoCode == "003" || strIncoCode == "004")
        {
            //'第一步畫面之薪資年月，當發放種類代碼為002,003,004時，只要取得年度'
            strIncoYM = strIncoYM.Substring(0, 4);
        }

        string strSQL =
            "select count(*) as CNT " +//--人數
            ",ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//--應扣繳稅額
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//--給付所得總額
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT " +//--申報所得總額
            "from ( " +//
            "SELECT ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT  " +//
            "FROM  SAL_SAINCO " +//
            "INNER JOIN  SAL_SABASE " +//
            "ON BASE_SEQNO=INCO_SEQNO  " +//
            "AND BASE_ORGID=INCO_ORGID  " +//
            "WHERE INCO_ORGID = @OrgID " +//'登入者機關代碼'
            "AND INCO_CODE = @IncoCode " +//'查詢畫面第一步之發放種類代碼(code_no)'
            "AND INCO_YM = @IncoYM ";//'查詢畫面第一步之薪資年月，若發放種類代碼=002,003,00則只取年度資料'

        if (strIncoCode == "005")
        {
            strSQL +=
                "AND INCO_KIND_CODE_NO = @IncoKinCodeNo ";//'查詢畫面第二步之項目名稱代碼--若發放種類代碼=005，增加此查詢條件'
        }

        strSQL +=
            "AND INCO_DATE = @IncoDate  " +//'查詢畫面第三步之發放日期'
            "AND BASE_PRONO IN ( @BaseProNo )  " +// '查詢畫面第四步之人員類別代碼(code_no)'
            "AND INCO_Budget_code = @IncoBudGeCode " +//'查詢畫面第四步之預算來源代碼(code_no)'
            "AND INCO_icode = @IncoICode " +//'查詢畫面第四步之所得類別代碼(code_no)'
            "AND INCO_AMT<>0  AND INCO_TXAM=0 AND INCO_CODE<>'001' "+//-- (3)
            "Group by inco_seqno ) a ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoYM",strIncoYM),
            new SqlParameter("@IncoKindCode", strIncoKindCode),
            new SqlParameter("@IncoDate", strIncoDate),
            new SqlParameter("@BaseProNo", strBaseProNo),
            new SqlParameter("@IncoBudGeCode", strIncoBudGeCode),
            new SqlParameter("@IncoICode", strIncoICode)
        };
        return Query(strSQL, sp);
    }

    // 報表查詢
    // 未預扣繳
    public DataTable queryReportPart4(
        string strOrgID,
        string strIncoCode,         // 發放種壘 
        string strIncoYM,           // 薪資年月
        string strIncoKindCode      // 項目名稱代碼 
        , string strIncoDate        //'查詢畫面第三步之發放日期'
        , string strBaseProNo       // '查詢畫面第四步之人員類別代碼(code_no)'
        , string strIncoBudGeCode   //'查詢畫面第四步之預算來源代碼(code_no)'
        , string strIncoICode       //'查詢畫面第四步之所得類別代碼(code_no)'
        )
    {
        if (strIncoCode == "002" || strIncoCode == "003" || strIncoCode == "004")
        {
            //'第一步畫面之薪資年月，當發放種類代碼為002,003,004時，只要取得年度'
            strIncoYM = strIncoYM.Substring(0, 4);
        }

        string strSQL =
            "select count(*) as CNT " +//--人數
            ",ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//--應扣繳稅額
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//--給付所得總額
            "from ( " +//
            "SELECT ISNULL(SUM(INCO_TXAM), 0) AS INCO_TXAM " +//
            ", ISNULL(SUM(INCO_REAL_AMT), 0) AS INCO_REAL_AMT " +//
            ", ISNULL(SUM(INCO_AMT),0) as INCO_AMT  " +//
            "FROM  SAL_SAINCO " +//
            "INNER JOIN  SAL_SABASE " +//
            "ON BASE_SEQNO=INCO_SEQNO  " +//
            "AND BASE_ORGID=INCO_ORGID  " +//
            "WHERE INCO_ORGID = @OrgID " +//'登入者機關代碼'
            "AND INCO_CODE = @IncoCode " +//'查詢畫面第一步之發放種類代碼(code_no)'
            "AND INCO_YM = @IncoYM ";//'查詢畫面第一步之薪資年月，若發放種類代碼=002,003,00則只取年度資料'

        if (strIncoCode == "005")
        {
            strSQL +=
                "AND INCO_KIND_CODE_NO = @IncoKinCodeNo ";//'查詢畫面第二步之項目名稱代碼--若發放種類代碼=005，增加此查詢條件'
        }

        strSQL +=
            "AND INCO_DATE = @IncoDate  " +//'查詢畫面第三步之發放日期'
            "AND BASE_PRONO IN ( @BaseProNo )  " +// '查詢畫面第四步之人員類別代碼(code_no)'
            "AND INCO_Budget_code = @IncoBudGeCode " +//'查詢畫面第四步之預算來源代碼(code_no)'
            "AND INCO_icode = @IncoICode " +//'查詢畫面第四步之所得類別代碼(code_no)'
            "AND INCO_AMT=0 "+
            "Group by inco_seqno ) a ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoYM",strIncoYM),
            new SqlParameter("@IncoKindCode", strIncoKindCode),
            new SqlParameter("@IncoDate", strIncoDate),
            new SqlParameter("@BaseProNo", strBaseProNo),
            new SqlParameter("@IncoBudGeCode", strIncoBudGeCode),
            new SqlParameter("@IncoICode", strIncoICode)
        };
        return Query(strSQL, sp);
    }


}