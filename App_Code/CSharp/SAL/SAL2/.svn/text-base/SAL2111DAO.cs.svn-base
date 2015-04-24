using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2111DAO 的摘要描述
/// </summary>
public class SAL2111DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL2111DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2111DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 取得報表資料
    public DataTable getReportData(
        string strLastYM // 前一月月份 YYMM
        , string strYM    // 當月月份
        , string strProNO    // 臨時人員代碼
        , string strBudgeCode    // 預算代碼
        , string strLogDeptCD    // 登入者機關代碼
        )
    {
        String strSQL =
            "select PAYO_NAME "           //--員工姓名
            + ",@LastYearMonth AS yymm_1"   //--前一月月份
            + ",@YearMonth as yymm2 "          //--當月月份

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '001' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID),0) as payod_kdb_1 " //--前一月本俸

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '001' and payod_kind = '001' "
            + "and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID),0) as payod_kdb_2 " //--當月本俸

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '003' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_kdp_1 " //--前一月專業加給

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '003' and payod_kind = '001' "
            + "and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID ),0) as payod_kdp_2 "  //--當月專業加給

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '004' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_kdc_1 "//--前一月主管加給

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '004' and payod_kind = '001' "
            + "and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID ),0) as payod_kdc_2 "//--當月主管加給

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '005' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '402' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_402_1 "//--前一月交通費

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '005' "
            + "AND PAYOD_CODE_TYPE = '001' AND PAYOD_CODE_NO = '402' and payod_kind = '001' "
            + "and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID ),0) as payod_402_2 "      //--當月交通費

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '002' AND PAYOD_CODE_NO = '001' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_002_1 " //--前一月所得稅

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            + "AND PAYOD_CODE_TYPE = '002' AND PAYOD_CODE_NO = '001' and payod_kind = '001' "
            + "and payod_ym =  @YearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_002_2 " //--當月所得稅

//            +", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '003' "
            //           +",AND PAYOD_CODE_TYPE = '002' AND PAYOD_CODE_NO = '001' and payod_kind = '001' "
            //           +"and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID ),0) as payod_002_2 "   //--當月所得稅

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '005' "
            + "AND PAYOD_CODE_TYPE = '002' AND PAYOD_CODE_NO = '007' and payod_kind = '001' "
            + "and payod_ym = @LastYearMonth  and payod_orgid = PAYO_ORGID ),0) as payod_002_1 "//--前一月退職金

            + ", isnull((select sum(payod_amt) from sal_sapayod where payod_seqno = payo_seqno and PAYOD_CODE_SYS = '005' "
            + "AND PAYOD_CODE_TYPE = '002' AND PAYOD_CODE_NO = '007' and payod_kind = '001' "
            + "and payod_ym = @YearMonth and payod_orgid = PAYO_ORGID ),0) as payod_002_2 "//--當月退職金

            + "from SAL_SAPAYO "
            + "where PAYO_ORGID = @LogDeptCD "//登入者機關代碼
            + "and PAYO_KIND = '001' "//--固定月薪001
            + "and PAYO_YYMM in (@LastYearMonth,@YearMonth) ";//畫面選擇之年月前一月, 畫面選擇之年月 )
//            + "and PAYO_PRONO <>@ProNo "// --若人員類別為全部(不含臨時人員) XXX為臨時人員代碼

        if (strProNO != "")
        {
            strSQL +=
               "and PAYO_PRONO  = @ProNo ";// --若人員類別為全部(不含臨時人員) XXX為臨時人員代碼
        }

        if (strBudgeCode != "")
        {
            strSQL +=
            "and PAYO_Budget_code = @BudgeCode ";
            // -- XXX為預算來源代碼

        }

        strSQL+=
             "order by PAYO_ORGID , isnull(payo_prono,'999'), PAYO_PRTS ";

        SqlParameter[] sp =
        {
            new SqlParameter("@LastYearMonth",strLastYM), //--前一月月份
            new SqlParameter("@YearMonth",strYM),           // 當前月份
            new SqlParameter("@ProNo",strProNO),            // 臨時人員代碼
            new SqlParameter("@BudgeCode",strBudgeCode),    // 預算代碼
            new SqlParameter("@LogDeptCD",strLogDeptCD)
          
        };

        return Query(strSQL, sp);
    }



}