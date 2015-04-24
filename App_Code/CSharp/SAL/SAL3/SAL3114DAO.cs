using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3114DAO 的摘要描述
/// SAL3114 基本薪資發放轉帳
/// Eliot Chen
/// </summary>
public class SAL3114DAO : BaseDAO
{

    public SAL3114DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3114DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 查詢其他薪津項目
    public DataTable querySalSaitem(
        string strOrgID, // 機關代碼
        string strPAYOKIND, ////'畫面選擇之發放種類'
        string strPAYOYYMM//'畫面選擇之薪資年月'
        )
    {
        string strSQL =
            "SELECT DISTINCT " +
            "P.PAYO_ORGID, " +
            "P.PAYO_YYMM,  " +
       //     "P.PAYO_DATE,  " + //ted 0627 只出現一筆 DESC
            "P.PAYO_KIND, " +
            "P.PAYO_KIND_CODE_TYPE, " +
            "P.PAYO_KIND_CODE_NO, " +
            "C.CODE_DESC1 " +
            "FROM SAL_SAPAYO P " +
            "LEFT JOIN sys_code C  " +
            "ON C.CODE_SYS='005' " +
            "AND C.CODE_KIND='D' " +
            "AND C.CODE_SYS=P.PAYO_KIND " +
            "AND C.CODE_TYPE=P.PAYO_KIND_CODE_TYPE " +
            "AND C.CODE_NO=P.PAYO_KIND_CODE_NO  AND C.CODE_ORGID = P.PAYO_ORGID " +
            "WHERE P.PAYO_ORGID = @orgid " +//'使用者登入機關代碼'
            "AND P.PAYO_KIND = '005' " +
            "AND P.PAYO_KIND =@PAYO_KIND  " +//'畫面選擇之發放種類'
            "AND P.PAYO_YYMM =@PAYO_YYMM  " +//'畫面選擇之薪資年月'
            "ORDER BY P.PAYO_KIND_CODE_TYPE,P.PAYO_KIND_CODE_NO ";
        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),         
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM)
        };

        return Query(strSQL, sp);
    }

    //帶出可選擇之批號
    public DataTable queryPayItemGroup
    (
  /*      string strOrgID, // 機關代碼
        string strPAYITEMCODE,  // 勾選其他薪津項目代碼
        string strPayed    // 否已轉帳       */
             string strPAYITEMCODE,
            string cmb_uc_calitem,
            string cmbYearMonth,
        string strPayed

    )
    {
        string strSQL =
            /*         "SELECT PAYITEM_CODEtype,PAYITEM_CODEno,PAYITEM_CODE,PAYITEM_MERGE_FLOW_ID " +//--批號清單顯示之批號
                     ",( " +
                     "SELECT ITEM_NAME FROM SAL_SAITEM " +
                     "WHERE ITEM_ORGID = PAYITEM_ORG_CODE " +
                     "AND ITEM_CODE = PAYITEM_CODE " +
                     ") AS ITEMNAME " +//-- 批號清單顯示之項目
                     ", SUM(PAYITEM_PAY_AMT) AS  sumPAYITEM_PAY_AMT" +// -- 批號清單顯示之金額
                     " from SAL_PAYITEM " +
                     "WHERE PAYITEM_ORG_CODE = @OrgID ";//'登入者機關代碼'
      
                     strSQL +=
                         "AND  PAYITEM_CODENO IN ( " + strPAYITEMCODE + " ) "; // '勾選其他薪津項目代碼'
                     if (strPayed == "False")
                     {
                         strSQL +=
                             //--如果於畫面上未勾選是否已轉帳者加此查詢條件
                             "AND  NOT EXISTS  " +
                             "( " +
                                    "SELECT 1 FROM SAL_SABATTRN  " +
                                    "WHERE TRN_ORGID = PAYITEM_ORG_CODE " +
                                    "AND TRN_KIND = '005' " +
                                    "AND TRN_STATUS = 'F' " +
                                    "AND TRN_NSTRING LIKE '%' + PAYITEM_MERGE_FLOW_ID + '%' " +
                             ") ";
                     }
                 strSQL +=
                     "GROUP BY PAYITEM_MERGE_FLOW_ID ,PAYITEM_ORG_CODE ,PAYITEM_CODE,PAYITEM_CODEtype,PAYITEM_CODEno,PAYITEM_CODE ";
            */
         " select PAYO_KIND , PAYO_YYMM , PAYO_DATE, PAYO_KIND_CODE_TYPE, PAYO_KIND_CODE_NO, PAYO_KIND_CODE "
        + " , PAYO_Merge_Flow_Id  "//-- 批號
        + " , ITEM_NAME "
        + " , ( "
        + "	select SUM(payod_amt) "
        + "	from SAL_SAPAYOD "
        + "	where PAYOD_KIND = PAYO_KIND "
        + "	and PAYOD_YM = PAYO_YYMM"
        + "	and PAYOD_DATE = PAYO_DATE "
        + "	and PAYOD_Merge_flow_id = PAYO_Merge_flow_id "
        + "	and PAYOD_CODE_SYS = '003'"
        + "	and PAYOD_CODE_TYPE = '003'"
        + "	and PAYOD_CODE_NO = '003'"
        + " ) as amt"
        + " from SAL_SAPAYO "
        + " left outer join SAL_SAITEM "
        + " on ITEM_CODE_SYS = '005'"
        + " and ITEM_CODE_TYPE = PAYO_KIND_CODE_TYPE "
        + " and ITEM_CODE_NO = PAYO_KIND_CODE_NO"
        + " and ITEM_CODE = PAYO_KIND_CODE "
        + " where PAYO_KIND = @cmb_uc_calitem "
        + " and PAYO_YYMM = @cmbYearMonth "
        + " and PAYO_KIND_CODE_no in (" + strPAYITEMCODE + " ) ";
           if (strPayed == "False")  //--如果於畫面上未勾選是否已轉帳者加此查詢條件
            {
                strSQL +=                  
                    " AND  NOT EXISTS  " +
                    "( " +
                           " SELECT 1 FROM SAL_SABATTRN  " +
                           " WHERE TRN_ORGID = PAYO_ORGID " +
                           " AND TRN_KIND = '005' " +
                           " AND TRN_STATUS = 'F' " +
                           " AND TRN_NSTRING LIKE '%' + PAYO_MERGE_FLOW_ID + '%' " +
                    ") ";
            }

           strSQL += " group by  PAYO_KIND, PAYO_YYMM, PAYO_DATE, PAYO_KIND_CODE_TYPE, PAYO_KIND_CODE_NO, PAYO_KIND_CODE , PAYO_Merge_Flow_Id, ITEM_NAME ";


        SqlParameter[] sp =
        {
    //        new SqlParameter("@orgid",strOrgID),     
    //        new SqlParameter("@strPAYITEMCODE",strPAYITEMCODE)   
         new SqlParameter("@cmb_uc_calitem",cmb_uc_calitem),     
         new SqlParameter("@cmbYearMonth",cmbYearMonth)
        };

        return Query(strSQL, sp);
    }

    // 取 PAYITEM_MERGE_FLOW_ID 的明細資料
    public DataTable queryPayItemDetail(
 //       string strOrgID, // 機關代碼
        string strPAYITEMMergeflowid  // 勾選其他薪津項目代碼
        )
    {
        string strSQL =
  /*          "select PAYITEM_Merge_flow_id " +// --批號清單顯示之批號
            ",base_name " +//批號清單顯示之姓名
            ",( " +
                   "select distinct item_name from sal_saitem " +
                   "where item_orgid = payitem_org_code " +
                   "and item_code = payitem_code " +
            ") as itemname  " +//  批號清單顯示之項目
            ", PAYITEM_Pay_amt " +// 批號清單顯示之金額
            "from sal_payitem  " + 
            "left outer join sal_sabase  " +
            "on BASE_ORGID = PAYITEM_Org_Code " +
            "and BASE_SEQNO = PAYITEM_User_id " +
            "where PAYITEM_Org_Code = @PAYITEM_Org_Code " +//使用者機關
            "and PAYITEM_Merge_flow_id = @PAYITEM_Merge_flow_id " +//點選資料之批號
            "order by isnull(BASE_PRONO,'999') , isnull(BASE_PRTS ,999)  ";
  */
             "  select PAYOD_Merge_flow_id "// -- 批號 
            +" , BASE_NAME "//-- 姓名
            +" , ITEM_NAME "//-- 項目名稱
            +" , PAYOD_AMT "//-- 金額
            +" from SAL_SAPAYOD "
            +" left outer join SAL_SABASE "
            +" on BASE_ORGID = PAYOD_ORGID"
            +" and BASE_SEQNO = PAYOD_SEQNO "
            +" left outer join SAL_SAITEM "
            +" on ITEM_CODE_SYS = '005'"
            +" and ITEM_CODE_TYPE = PAYOD_KIND_CODE_TYPE  "
            +" and ITEM_CODE_NO = PAYOD_KIND_CODE_NO "
            +" and ITEM_CODE = PAYOD_KIND_CODE  "
            +" where PAYOD_KIND = PAYOD_KIND "
            +" and PAYOD_Merge_flow_id = @PAYITEM_Merge_flow_id "
            +" and PAYOD_CODE_SYS = '003'"
            +" and PAYOD_CODE_TYPE = '003'"
            +" and PAYOD_CODE_NO = '003'";

        SqlParameter[] sp =
        {
  //          new SqlParameter("@PAYITEM_Org_Code",strOrgID),     
            new SqlParameter("@PAYITEM_Merge_flow_id",strPAYITEMMergeflowid)
        };

        return Query(strSQL, sp);
    }

    // 新增批次轉檔資料
    public void insertSaBatTrn(
            string strTRNORGID,// = 使用者機關代號
            string strTRN_USERID,// = 使用者員工編號      
            string strTRN_YM,// = 畫面選擇薪資年月
            string strTRN_DATE,// = 畫面選擇薪資日期
            string strTRN_KIND,// = 畫面選擇發放種類
            string strTRN_CODE_SYS,//= 畫面選擇發放種類的第二層代碼(第一組)
            string strTRN_CODE_KIND,//= 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
            string strTRN_CODE_TYPE,//= 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
            string strTRN_CODE_NO,//= 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
            string strTRN_CODE,//=畫面選擇發放種類的第二層代碼(第五組，以底線區分)
            string strTRNNSTRING // = 當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null
)
    {
        string strSQL =
            "INSERT INTO SAL_SABATTRN(" +
            "TRN_ORGID," +// = 使用者機關代號
            "TRN_USERID," +// = 使用者員工編號
            "TRN_BOOKTIME," +// = yyyyMMddHHmmss(現在時間)
            "TRN_YM," +// = 畫面選擇薪資年月
            "TRN_DATE," +// = 畫面選擇薪資日期
            //            "TRN_STARTTIME,"+// = null
            //            "TRN_STOPTIME,"+// = null
            "TRN_STATUS ," +//= 'W',
            "TRN_KIND," +// = 畫面選擇發放種類
            "TRN_CODE_SYS ," +//= 畫面選擇發放種類的第二層代碼(第一組)
            "TRN_CODE_KIND ," +//= 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
            "TRN_CODE_TYPE ," +//= 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
            "TRN_CODE_NO ," +//= 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
            "TRN_CODE ," +//=畫面選擇發放種類的第二層代碼(第五組，以底線區分)
            "TRN_NSTRING " +// = 當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null
            //            "TRN_ORDERBY,"+// = null
            //            "TRN_MSG ,"+//= null
            ")" +
            "VALUES (" +
            "@TRN_ORGID," +// = 使用者機關代號
            "@TRN_USERID," +// = 使用者員工編號
            "@TRN_BOOKTIME," +// = yyyyMMddHHmmss(現在時間)
            "@TRN_YM," +// = 畫面選擇薪資年月
            "@TRN_DATE," +// = 畫面選擇薪資日期
            //            "TRN_STARTTIME,"+// = null
            //            "TRN_STOPTIME,"+// = null
            "'W' ," +//= 'W',
            "@TRN_KIND," +// = 畫面選擇發放種類
            "@TRN_CODE_SYS ," +//= 畫面選擇發放種類的第二層代碼(第一組)
            "@TRN_CODE_KIND ," +//= 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
            "@TRN_CODE_TYPE ," +//= 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
            "@TRN_CODE_NO ," +//= 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
            "@TRN_CODE ," +//=畫面選擇發放種類的第二層代碼(第五組，以底線區分)
            "@TRN_NSTRING " +// = 當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null
            ")";
        //            "TRN_ORDERBY,"+// = null
        //            "TRN_MSG ,"+//= null
        SqlParameter[] sp =
        {
            new SqlParameter("@TRN_ORGID",strTRNORGID),     
            new SqlParameter("@TRN_USERID",strTRN_USERID),     
            new SqlParameter("@TRN_BOOKTIME",DateTime.Now.ToString("yyyyMMddHHmmss")),     
            new SqlParameter("@TRN_YM",strTRN_YM),     
            new SqlParameter("@TRN_DATE",strTRN_DATE),     
            new SqlParameter("@TRN_KIND",strTRN_KIND),     
            new SqlParameter("@TRN_CODE_SYS",strTRN_CODE_SYS),     
            new SqlParameter("@TRN_CODE_KIND",strTRN_CODE_KIND),     
            new SqlParameter("@TRN_CODE_TYPE",strTRN_CODE_TYPE),     
            new SqlParameter("@TRN_CODE_NO",strTRN_CODE_NO),
            new SqlParameter("@TRN_CODE",strTRN_CODE),
            new SqlParameter("@TRN_NSTRING",strTRNNSTRING)
        };

        Execute(strSQL, sp);
    }

    // 更新 SAL_SAPAYO
    public void updateSaPayO
        (
        string strPAYODATE, //'畫面上選擇日期'
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
        )
    {
        string strSQL =
            "update SAL_SAPAYO " +
            "set PAYO_DATE = @PAYO_DATE " +// 畫面上選擇日期'
            "where PAYO_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and PAYO_KIND = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and PAYO_YYMM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and PAYO_DATE <> @PAYO_DATE ";//'畫面上選擇日期'
        if (strPAYOKIND == "005")
        {
            strSQL +=
                //-- 發放種類為其他薪津(005)增加條件
            "and PAYO_Merge_flow_id in ( " + strPAYOMergeflowid + " )";// '畫面勾選之批號'
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@strPAYOMergeflowid",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    }

    
    // 更新 SAL_SAPAYOD
    public void updateSaPayOD
        (
         string strPAYODATE, //'畫面上選擇日期'
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
        )
    {
        string strSQL =
            "update SAL_SAPAYOD " +
            "set PAYOD_DATE = @PAYO_DATE " +//'畫面上選擇日期'
            "where PAYOD_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and PAYOD_KIND = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and PAYOD_YM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and PAYOD_DATE <> @PAYO_DATE ";//'畫面上選擇日期'
        if (strPAYOKIND == "005")
        {
            strSQL +=
                //-- 發放種類為其他薪津(005)增加條件
            "and PAYOD_Merge_flow_id in ( " +strPAYOMergeflowid +" )";// '畫面勾選之批號'
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@PAYO_Merge_flow_id",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    }

    // 更新 SAL_SAINCO
    public void updateSaInco
        (
         string strPAYODATE, //畫面上選擇日期'
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
        )
    {
        string strSQL =
            "update SAL_SAINCO " +
            "set INCO_DATE = @PAYO_DATE " +//'畫面上選擇日期'
            "where INCO_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and INCO_CODE = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and INCO_YM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and INCO_DATE <> @PAYO_DATE ";//'畫面上選擇日期'
        if (strPAYOKIND == "005")
        {
            strSQL +=
                //-- 發放種類為其他薪津(005)增加條件
            "and INCO_Merge_flow_id in ( "+strPAYOMergeflowid+" )";// '畫面勾選之批號'
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@PAYO_Merge_flow_id",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    }



    // 更新 SAL_SAPAYO
    public void updateSaPayO2
        (
        string strPAYODATE, //'原來日期
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
        , string newdate//修改日期
        )
    {
        string strSQL =
            "update SAL_SAPAYO " +
            "set PAYO_DATE = @newdate " +//修改日期
            "where PAYO_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and PAYO_KIND = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and PAYO_YYMM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and PAYO_DATE = @PAYO_DATE ";//原來日期
      
        SqlParameter[] sp =
        {
            new SqlParameter("@newdate",newdate),  
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@PAYO_Merge_flow_id",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    }


    // 更新 SAL_SAPAYOD
    public void updateSaPayOD2
        (
         string strPAYODATE, ////原來日期'
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
          , string newdate//修改日期
        )
    {
        string strSQL =
            "update SAL_SAPAYOD " +
            "set PAYOD_DATE = @newdate " +//修改日期
            "where PAYOD_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and PAYOD_KIND = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and PAYOD_YM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and PAYOD_DATE = @PAYO_DATE ";//原來日期'
     

        SqlParameter[] sp =
        {
            new SqlParameter("@newdate",newdate),  
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@PAYO_Merge_flow_id",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    } 

    // 更新 SAL_SAINCO
    public void updateSaInco2
        (
         string strPAYODATE, //原來日期'
        string strPAYOORGID,//'登入者機關代碼'
        string strPAYOKIND, //'畫面選擇之發放種類'
        string strPAYOYYMM, //'畫面選擇之發放年月'
        string strPAYOMergeflowid// '畫面勾選之批號'
       , string newdate//修改日期
        )
    {
        string strSQL =
            "update SAL_SAINCO " +
            "set INCO_DATE = @newdate " +//修改日期
            "where INCO_ORGID = @PAYO_ORGID " +//'登入者機關代碼'
            "and INCO_CODE = @PAYO_KIND " +//'畫面選擇之發放種類'
            "and INCO_YM = @PAYO_YYMM " +//'畫面選擇之發放年月'
            "and INCO_DATE = @PAYO_DATE ";//原來日期'
   

        SqlParameter[] sp =
        {
            new SqlParameter("@newdate",newdate),  
            new SqlParameter("@PAYO_DATE",strPAYODATE),     
            new SqlParameter("@PAYO_ORGID",strPAYOORGID),     
            new SqlParameter("@PAYO_KIND",strPAYOKIND),     
            new SqlParameter("@PAYO_YYMM",strPAYOYYMM),     
            new SqlParameter("@PAYO_Merge_flow_id",strPAYOMergeflowid)
        };

        Execute(strSQL, sp);
    }




    
    public DataTable queryPayItemsDropDown
        (
        string strOrgID,
        string strKind,//-- 發放種類
        string strYYMM
        )
    {
        string strSQL =
            "select payod_kind + '_' + payod_code_sys + '_' + payod_code_kind + '_' + " +
            "payod_code_type + '_' + payod_code_no + '_' + payod_code as CODE " +
            ",( " +
            "	select isnull(code_desc1,'') from sys_code  " +
            "	where payod_code_sys=code_sys " +
            "	and payod_code_type=code_type " +
            "	and payod_code_no=code_no " +
            ")  " +
            "+  " +
            "isnull(( " +
            "	select '*' + item_name " +
            "	from sal_saitem " +
            "	where payod_orgid=item_orgid " +
            "	and payod_code_sys=item_code_sys " +
            "	and payod_code_type=item_code_type " +
            "	and payod_code_no=item_code_no " +
            "	and payod_code=item_code  " +
            "),'') as NAME " +
            "from sal_sapayod  " +
            "where payod_orgid= @v_orgid " +//--@v_orgid
            "and payod_kind= @v_kind " +//--@v_kind-- 發放種類
            "and payod_ym= @v_ym " +//--@v_ym
            "and  " +
            "( " +
            "	(payod_code_sys='003' AND payod_code_kind='P' AND payod_code_type='003' AND payod_code_no='003') " +
            "	OR  " +
            "	(payod_code_sys='005' AND payod_code_kind='D' AND (payod_code_type='001' OR payod_code_type='002')) " +
            ") " +
            "group by payod_orgid, payod_kind, payod_code_sys, " +
            "payod_code_kind, payod_code_type, payod_code_no, payod_code  " +
            "order by payod_orgid, payod_kind, payod_code_sys,  " +
            "payod_code_kind, payod_code_type, payod_code_no, payod_code  ";

        SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",strOrgID),     
            new SqlParameter("@v_kind",strKind),     
            new SqlParameter("@v_ym",strYYMM)
        };

        return Query(strSQL, sp);
    }

    public DataTable querySalBatTrns(
        string strOrgID,//'使用者登入之機關代號'
        string strKind,//'畫面選擇之發放種類'
        string strYYMM//'畫面選擇之發放年月'
        )
    {
        string strSQL=
            "select top 1 * "+
            "from sal_sabattrn "+
            "where TRN_ORGID = @OrgID  "+//'使用者登入之機關代號'
            "and TRN_KIND = @TrnKind  "+//'畫面選擇之發放種類'
            "and TRN_YM = @TrnYM "+//'畫面選擇之發放年月'
            "and TRN_STATUS = 'F' "+
            "order by TRN_BOOKTIME desc ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@TrnKind",strKind),     
            new SqlParameter("@TrnYM",strYYMM)
        };

        return Query(strSQL, sp);      

    }

    public DataTable queryStep2Data
        (
        string strOrgID,
        string strTrnDataYm,
        string strTrnDataKind,
        string strTrnDataCodeSys,
        string strTrnDataCodeType,
        string strTrnDataCodeNo,
        string strTrnDataCode
        )
    {
        string strSQL=
            " SELECT base_name, base_idno,base_seqno, trndata_content, trndata_tdpf_seqno, trndata_amt "+
            " FROM sal_sabase, sal_satrndata "+
            " WHERE base_seqno = trndata_seqno "+
            " AND base_orgid = trndata_orgid"+
            " AND base_orgid= @OrgID "+
            " AND trndata_ym = @TrnDataYm "+
            " and trndata_kind= @TrnDataKind ";
        if (strTrnDataKind == "005")
        {          
            strSQL+=
                " and trndata_code_sys='003' "+
                " and trndata_code_type='003' "+
                " and trndata_code_no='003' "+
                " and trndata_code='' ";
        }
        else
        {
            strSQL +=
                " and trndata_code_sys= @TrnDataCodeSys " +
                " and trndata_code_type= @TrnDataCodeType " +
                " and trndata_code_no= @TrnDataCodeNo " +
                " and trndata_code= @TrnDataCode ";

        }
        strSQL+=
            " ORDER BY isNull(base_prts,99999) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@TrnDataYm",strTrnDataYm), 
            new SqlParameter("@TrnDataKind",strTrnDataKind),     
            new SqlParameter("@TrnDataCodeSys",strTrnDataCodeSys),     
            new SqlParameter("@TrnDataCodeType",strTrnDataCodeType),     
            new SqlParameter("@TrnDataCodeNo",strTrnDataCodeNo),     
            new SqlParameter("@TrnDataCode",strTrnDataCode)
        };

        return Query(strSQL, sp);

    }

    public DataTable getSaBand(
        string strOrgID,
        string strBankSeqNo,
        string strBankTdpfSeqNo
        )
    {
        string strSQL =
            "select * from sal_sabank " +
            "where bank_seqno= @BankSeqNo " +
            "and bank_tdpf_seqno= @BankTdpfSeqNo " +
            "and bank_orgid= @OrgID ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@BankSeqNo",strBankSeqNo),     
            new SqlParameter("@BankTdpfSeqNo",strBankTdpfSeqNo)
        };

        return Query(strSQL, sp);

    }

    public string getPayodAmount
        (
        string strOrgID,
        string strPayodYm,
        string strPayodKind,
        string strPayodSeqNo,
        string strPayodCodeSys,
        string strPayodCodeType,
        string strPayodCodeNo,
        string strPayodCode,
        string strPayodDate,
        string p_payod_str,
        string unit_multi_monthpay
        )
    {
        string strSQL=
            "select isNull(sum(payod_amt),0) as payod_amt"+
            " from sal_sapayod"+
            " where payod_orgid= @OrgID "+
            " and payod_ym= @PayodYm "+
            " and payod_kind= @PayodKind "+
            " and payod_seqno= @PayodSeqNo ";
        if (strPayodKind=="005")
        {
              strSQL+=
            " and payod_code_sys='003' "+
            " and payod_code_type='003' "+
            " and payod_code_no='003' "+
            " and (" + p_payod_str + ") ";            

        }
        else
        {
            strSQL+=
                " and payod_code_sys= @PayodCodeSys "+
                " and payod_code_type= @PayodCodeType "+
                " and payod_code_no= @PayodCodeNo "+
                " and payod_code= @PayodCode ";
        }
        if (strPayodKind != "001" || unit_multi_monthpay !="Y" ) 
        {
            strSQL+=
                " and payod_date = @PayodDate ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayodYm",strPayodYm),     
            new SqlParameter("@PayodKind",strPayodKind),     
            new SqlParameter("@PayodSeqNo",strPayodSeqNo),     
            new SqlParameter("@PayodCodeSys",strPayodCodeSys),     
            new SqlParameter("@PayodCodeType",strPayodCodeType),     
            new SqlParameter("@PayodCodeNo",strPayodCodeNo),     
            new SqlParameter("@PayodCode",strPayodCode),     
            new SqlParameter("@PayodDate",strPayodDate)
        };

        DataTable dt= Query(strSQL, sp);

        string strRetuenValue = "0";
        if (dt.Rows.Count > 0)
        {
            strRetuenValue = dt.Rows[0]["payod_amt"].ToString();
        }

        return strRetuenValue;
            
    }



    public void deleteSatrndata(
     string strPAYOYYMM,
     string strOrgCode          
      )
    {
        string strSQL =
          "delete from sal_satrndata where trndata_ym=@strPAYOYYMM "
            + " and trndata_orgid=@strOrgCode "
            + " and trndata_kind='005' "
            + " and trndata_code_sys='003' "
            + " and trndata_code_type='003' "
            + " and trndata_code_no='003' ";

        SqlParameter[] sp =
        {          
            new SqlParameter("@strPAYOYYMM",strPAYOYYMM),     
            new SqlParameter("@strOrgCode",strOrgCode)    
        };

       Execute(strSQL, sp);   
    }


   public void deleteSatrndata2(
    string strPAYOYYMM,
    string strOrgCode,
    string strTrnKind,
    string strTrnDataCodeSys,
    string strTrnDataCodeType,
    string strTrnDataCodeNo,
    string strTrnDataCode
    )
    {
        string strSQL =
          "delete from sal_satrndata where trndata_ym=@strPAYOYYMM "
            + " and trndata_orgid=@strOrgCode "
            + " and trndata_kind=@strTrnKind "
            + " and trndata_code_sys=@strTrnDataCodeSys "
            + " and trndata_code_type=@strTrnDataCodeType "
            + " and trndata_code_no=@strTrnDataCodeNo "
            + " and trndata_code=@strTrnDataCode ";

        SqlParameter[] sp =
        {          
            new SqlParameter("@strPAYOYYMM",strPAYOYYMM),     
            new SqlParameter("@strOrgCode",strOrgCode),     
            new SqlParameter("@strTrnKind",strTrnKind),     
            new SqlParameter("@strTrnDataCodeSys",strTrnDataCodeSys),     
            new SqlParameter("@strTrnDataCodeType",strTrnDataCodeType),     
            new SqlParameter("@strTrnDataCodeNo",strTrnDataCodeNo),     
            new SqlParameter("@strTrnDataCode",strTrnDataCode)   
        };

        Execute(strSQL, sp);
    }





   public DataTable querydata(
       string strOrgID // 機關代碼
       , string p_tdpm_str
       )
   {
       string strSQL =
          " select * from sal_satdpm "
        + " where tdpm_orgid=@strOrgCode "
        + " and tdpm_kind='005' "
        + " and tdpm_code_sys='005' "
        + " and (" + p_tdpm_str + ") "
        + " order by tdpm_code_sys, tdpm_code_type, tdpm_code_no, tdpm_code ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgID) 
        };

       return Query(strSQL, sp);
   }



   public DataTable querydata2(
        string strOrgID, // 機關代碼
        string tdpm_kind,
        string tdpm_code_sys,
        string tdpm_code_kind,
        string tdpm_code_type,
        string tdpm_code_no,
        string tdpm_code
     )
   {
       string strSQL =
         " select * from sal_satdpm  "
       + " where tdpm_orgid=@strOrgCode "
       + " and tdpm_kind=@tdpm_kind "
       + " and tdpm_code_sys=@tdpm_code_sys "
       + " and tdpm_code_kind=@tdpm_code_kind "
       + " and tdpm_code_type=@tdpm_code_type "
       + " and tdpm_code_no=@tdpm_code_no "
       + " and tdpm_code=@tdpm_code ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgID) ,
            new SqlParameter("@tdpm_kind",tdpm_kind) ,
            new SqlParameter("@tdpm_code_sys",tdpm_code_sys) ,
            new SqlParameter("@tdpm_code_kind",tdpm_code_kind) ,
            new SqlParameter("@tdpm_code_type",tdpm_code_type) ,
            new SqlParameter("@tdpm_code_no",tdpm_code_no) ,
            new SqlParameter("@tdpm_code",tdpm_code) 
        };

       return Query(strSQL, sp);
   }



   public DataTable querydata3(
     string strOrgID, // 機關代碼
     string tdpm_kind,
     string tdpm_code_sys,
     string tdpm_code_kind,
     string tdpm_code_type,
     string tdpm_code_no
  )
   {
       string strSQL =
         " select * from sal_satdpm  "
       + " where tdpm_orgid=@strOrgCode "
       + " and tdpm_kind=@tdpm_kind "
       + " and tdpm_code_sys=@tdpm_code_sys "
       + " and tdpm_code_kind=@tdpm_code_kind "
       + " and tdpm_code_type=@tdpm_code_type "
       + " and tdpm_code_no=@tdpm_code_no ";


       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgID) ,
            new SqlParameter("@tdpm_kind",tdpm_kind) ,
            new SqlParameter("@tdpm_code_sys",tdpm_code_sys) ,
            new SqlParameter("@tdpm_code_kind",tdpm_code_kind) ,
            new SqlParameter("@tdpm_code_type",tdpm_code_type) ,
            new SqlParameter("@tdpm_code_no",tdpm_code_no) 
        };

       return Query(strSQL, sp);
   }



   public DataTable querydataSATDPF(
  string strOrgID, // 機關代碼
  string p_tdpf_seqno
)
   {
       string strSQL =
           " select * from sal_satdpf where tdpf_seqno=@p_tdpf_seqno  and tdpf_orgid=@strOrgID ";


       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgID",strOrgID) ,
            new SqlParameter("@p_tdpf_seqno",p_tdpf_seqno)
        };

       return Query(strSQL, sp);
   }




   public void queryubStr(
     string strOrgCode
      )
   {
       string strSQL = "update sal_satdpf set tdpf_bank_no=Replace(tdpf_bank_no,'-','') "
                     + " where tdpf_orgid=@strOrgCode  and  TDPF_BANK_NO LIKE '%-%' ";      

       SqlParameter[] sp =
        {              
            new SqlParameter("@strOrgCode",strOrgCode)    
        };

       Execute(strSQL, sp);
   }


   public void upbkStr(
   string strOrgCode
    )
   {
       string strSQL = "update sal_sabank set bank_bank_no=replace(bank_bank_no,'-','') "
                     + " where bank_orgid=@strOrgCode and bank_bank_no like '%-%'";

       SqlParameter[] sp =
        {              
            new SqlParameter("@strOrgCode",strOrgCode)    
        };

       Execute(strSQL, sp);
   }




   public DataTable baseStr(
    string strOrgCode,// 機關代碼  
    string strPayDate,
    string strPAYOYYMM,
    string strTrnKind,
    string payod_code_sys,
    string payod_code_type,
    string payod_code_no,
    string payod_code,
       string p_tdpm_code_sys,
       string p_payod_str,
       string p_tdpf_seqno
)
   {
       string sql2 ="(select payod_seqno from sal_sapayod ";
       sql2 = sql2 + " where payod_orgid=@strOrgCode ";
       sql2 = sql2 + " and payod_ym=@strPAYOYYMM ";
       sql2 = sql2 + " and payod_kind=@strTrnKind ";
       sql2 = sql2 + " and base_seqno=payod_seqno ";

       if (strTrnKind == "001" &&  payod_code_sys == "005") 
       {
            sql2 = sql2 + " and payod_code_sys=@payod_code_sys ";
            sql2 = sql2 + " and payod_code_type=@payod_code_type ";
            sql2 = sql2 + " and payod_code_no =@payod_code_no ";
            sql2 = sql2 + " and payod_code =@payod_code ";
       }
        if (strTrnKind == "005") 
        {
            sql2 = sql2 + " and payod_code_sys='" + p_tdpm_code_sys + "'";
            sql2 = sql2 + " and (" + p_payod_str + ") ";
        }
        sql2 = sql2 + " and payod_date = @strPayDate";
       if((strTrnKind == "003") && (payod_code_sys == "003") && (payod_code_type == "003") && (payod_code_no == "003"))
       {
            sql2 = sql2 + " and payod_code_sys='003' and payod_code_type='003' and payod_code_no='003' and payod_amt > 0 ";
       }
       sql2 = sql2 + ") ";

       string baseStr = "";
          if (strTrnKind == "001") 
          {
            baseStr = "select base_name from sal_sabase where base_orgid = @strOrgCode  and  exists (" + sql2 + ") ";
            baseStr = baseStr + " and not exists ( select 1 from sal_sabank where bank_seqno=base_seqno and bank_orgid=base_orgid ) ";
            baseStr = baseStr + " order by cast(base_prts as float)";
          }
          else
          {
            baseStr = "select base_name from sal_sabase ";
            baseStr = baseStr + " where base_orgid = @strOrgCode ";
            baseStr = baseStr + " and exists (" + sql2 + ") ";
            baseStr = baseStr + " and not exists ( select 1 from sal_sabank where bank_seqno=base_seqno and bank_orgid=base_orgid and bank_tdpf_seqno='" + p_tdpf_seqno + "') ";
            baseStr = baseStr + " order by cast(base_prts as float)";
          }


       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strPayDate",strPayDate),
            new SqlParameter("@strPAYOYYMM",strPAYOYYMM),
            new SqlParameter("@strTrnKind",strTrnKind) ,
            new SqlParameter("@payod_code_sys",payod_code_sys),
            new SqlParameter("@payod_code_type",payod_code_type) ,
            new SqlParameter("@payod_code_no",payod_code_no),
            new SqlParameter("@payod_code",payod_code) ,
            new SqlParameter("@p_tdpm_code_sys",p_tdpm_code_sys) 
        };

       return Query(baseStr, sp);
   }



   public DataTable queryNSTRING
    (
       string TRN_NSTRING      
    )
   {
       string strSQL =
           " select distinct PAYITEM_Merge_flow_id "//--批號清單顯示之批號
          + ",( select item_name from sal_saitem "
          + " where item_orgid = payitem_org_code "
          + " and item_code = payitem_code "
          + " ) as itemname  " //-- 批號清單顯示之項目 
          + "from SAL_PAYITEM "
          + "where PAYITEM_Merge_flow_id in ( "+ TRN_NSTRING +" )";
 
       SqlParameter[] sp =
        {
            new SqlParameter("@TRN_NSTRING",TRN_NSTRING)  
        };

       return Query(strSQL, sp);
   }



   public DataTable queryStep2Data1
    (
      string strOrgID,
      string strTrnDataYm,
      string strTrnDataKind,
      string strTrnDataCodeSys,
      string strTrnDataCodeType,
      string strTrnDataCodeNo,
      string strTrnDataCode
    )
   {
       string strSQL = " SELECT base_name, base_idno,base_seqno, trndata_content, trndata_tdpf_seqno, trndata_amt"
            + " FROM sabase, satrndata "
            + " WHERE base_seqno = trndata_seqno "
            + " AND base_orgid = trndata_orgid"
            + " AND base_orgid=@strOrgID "
            + " AND trndata_ym = @strTrnDataYm "
            + " and trndata_kind=@strTrnDataKind ";
       if (strTrnDataKind == "005")
       {
           strSQL += " and trndata_code_sys='003' "
                + " and trndata_code_type='003' "
                + " and trndata_code_no='003' "
                +" and trndata_code='' ";
       }
       else
       {
           strSQL += " and trndata_code_sys=@strTrnDataCodeSys "
                 + " and trndata_code_type=@strTrnDataCodeType "
                 + " and trndata_code_no=@strTrnDataCodeNo "
                 + " and trndata_code=@strTrnDataCode ";
       }
       strSQL += " ORDER BY isNull(base_prts,99999) ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgID",strOrgID) ,
            new SqlParameter("@strTrnDataYm",strTrnDataYm),
            new SqlParameter("@strTrnDataKind",strTrnDataKind),
            new SqlParameter("@strTrnDataCodeSys",strTrnDataCodeSys) ,
            new SqlParameter("@strTrnDataCodeType",strTrnDataCodeType),
            new SqlParameter("@strTrnDataCodeNo",strTrnDataCodeNo) ,
            new SqlParameter("@strTrnDataCode",strTrnDataCode)
        };

       return Query(strSQL, sp);
   }



   public DataTable unit_multi_monthpay(
     string strOrgID //使用者登入之機關代號
     )
   {
       string strSQL = " select * from sal_saunit where unit_no = @OrgID ";

        
       SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID)
        };

       return Query(strSQL, sp);

   }


   public DataTable amt(
        string strOrgCode,
        string strTrnDataYm,
        string p_payod_str,
        string strTrnDataKind,
        string unit_multi_monthpay,
        string strPayDate
     )
   {
       string strSQL = "select isNull(sum(payod_amt),0) as payod_amt from sal_sapayod where payod_orgid=@strOrgCode "
           + " and payod_ym=@strTrnDataYm "
           + " and payod_kind='005' "
           + " and payod_code_sys='003' "
           + " and payod_code_type='003' "
           + " and payod_code_no='003' "
           + " and payod_code='' ";
       if (p_payod_str != "")
       {
           strSQL += " and (" + p_payod_str + ") ";
       }
       if (strTrnDataKind != "001" || unit_multi_monthpay != "Y")
       {
           strSQL += " and payod_date = @strPayDate ";
       }
       strSQL += " and exists (select 1 from sal_sabase where base_orgid=payod_orgid and base_seqno=payod_seqno) ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strTrnDataYm",strTrnDataYm),
            new SqlParameter("@strTrnDataKind",strTrnDataKind) ,
            new SqlParameter("@strPayDate",strPayDate) 
        };

       return Query(strSQL, sp);

   }



   public DataTable amt2(
        string strOrgCode,
        string strTrnDataYm,
        string strTrnDataKind,
        string p_code_sys,
        string p_code_type,
        string p_code_no,
        string p_code,
        string unit_multi_monthpay,
        string strPayDate
   )
   {
       string strSQL = "select isNull(sum(payod_amt),0) as payod_amt "
            + " from sal_sapayod "
            + " where payod_orgid=@strOrgCode "
            + " and payod_ym=@strTrnDataYm "
            + " and payod_kind=@strTrnDataKind "
            + " and payod_code_sys=@p_code_sys "
            + " and payod_code_type=@p_code_type "
            + " and payod_code_no=@p_code_no "
            + " and payod_code=@p_code  ";

       if (strTrnDataKind != "001" || unit_multi_monthpay != "Y")
       {
           strSQL += " and payod_date = @strPayDate ";
       }
       strSQL += " and exists (select 1 from sal_sabase where base_orgid=payod_orgid and base_seqno=payod_seqno) ";


       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strTrnDataYm",strTrnDataYm),
            new SqlParameter("@strTrnDataKind",strTrnDataKind) ,
            new SqlParameter("@p_code_sys",p_code_sys) ,
            new SqlParameter("@p_code_type",p_code_type) ,
            new SqlParameter("@p_code_no",p_code_no) ,
            new SqlParameter("@p_code",p_code) ,
            new SqlParameter("@strPayDate",strPayDate) 
        };

       return Query(strSQL, sp);

   }



   public DataTable amt3(
      string strOrgCode,
      string strTrnDataYm
 )
   {
       string strSQL = 
             "SELECT isnull(sum(trndata_amt),0) trndata_amt "
           + " FROM sal_sabase, sal_satrndata "
           + " WHERE base_seqno = trndata_seqno"
           + " AND base_orgid = trndata_orgid "
           + " AND base_orgid=@strOrgCode "
           + " AND trndata_ym = @strTrnDataYm "
           + " and trndata_kind='005' "
           + " and trndata_code_sys='003' "
           + " and trndata_code_type='003'"
           + " and trndata_code_no='003' "
           + " and trndata_code='' ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strTrnDataYm",strTrnDataYm)         
        };

       return Query(strSQL, sp);

   }



   public DataTable amt4(
        string strOrgCode,
        string strTrnDataYm,
        string strTrnDataKind,
        string p_code_sys,
        string p_code_type,
        string p_code_no,
        string p_code
)
   {
       string strSQL =   
             "SELECT isnull(sum(trndata_amt),0) trndata_amt "
           + " FROM sal_sabase, sal_satrndata "
           + " WHERE base_seqno = trndata_seqno"
           + " AND base_orgid = trndata_orgid "
           + " AND base_orgid=@strOrgCode "
           + " AND trndata_ym = @strTrnDataYm "
           + " and trndata_kind=@strTrnDataKind "
           + " and trndata_code_sys=@p_code_sys "
           + " and trndata_code_type=@p_code_type  "
           + " and trndata_code_no=@p_code_no "
           + " and trndata_code=@p_code ";         

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strTrnDataYm",strTrnDataYm),
            new SqlParameter("@strTrnDataKind",strTrnDataKind) ,
            new SqlParameter("@p_code_sys",p_code_sys) ,
            new SqlParameter("@p_code_type",p_code_type) ,
            new SqlParameter("@p_code_no",p_code_no) ,
            new SqlParameter("@p_code",p_code) 
        };

       return Query(strSQL, sp);

   }



   public DataTable step3Tdpm(
     string strOrgCode,
     string step3_p_tdpm_str
)
   {
       string strSQL =
            " select * from sal_satdpm where tdpm_kind='005' and tdpm_orgid=@strOrgCode "
          + " and tdpm_code_sys='005' and (" + step3_p_tdpm_str + ") "
          + " order by tdpm_code_sys, tdpm_code_type, tdpm_code_no, tdpm_code ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) 
        };

       return Query(strSQL, sp);

   }



   public DataTable step3Tdpm2(
            string strOrgCode,
            string strKind,
            string p_code_sys,
            string p_code_type,
            string p_code_no,
            string p_code
        )
   {
       string strSQL =
              " select * from sal_satdpm "
            + " where tdpm_kind=@strKind "
            + " and tdpm_orgid=@strOrgCode "
            + " and tdpm_code_sys=@p_code_sys "
            + " and tdpm_code_type=@p_code_type "
            + " and tdpm_code_no=@p_code_no "
            + " and tdpm_code=@p_code ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) ,
            new SqlParameter("@strKind",strKind) ,
            new SqlParameter("@p_code_sys",p_code_sys) ,
            new SqlParameter("@p_code_type",p_code_type) ,
            new SqlParameter("@p_code_no",p_code_no) ,
            new SqlParameter("@p_code",p_code) 
        };

       return Query(strSQL, sp);

   }



   public DataTable GetSaTdpf(
          string p_tdpm_tdpf_seqno
      )
   {
       string strSQL = "select * from sal_satdpf where tdpf_seqno=@p_tdpm_tdpf_seqno ";


       SqlParameter[] sp =
        {
            new SqlParameter("@p_tdpm_tdpf_seqno",p_tdpm_tdpf_seqno) 
        };

       return Query(strSQL, sp);
   }


   public DataTable DownloadStart(
            string strYm,
            string strOrgCode
    )
   {
       string strSQL = " select sum(isnull(trndata_amt,0)) trndata_amt, count(1) cnt "
           + " from sal_satrndata"
           + " where trndata_ym=@strYm "
           + " and trndata_orgid=@strOrgCode "
           + " and trndata_kind='005'";

       SqlParameter[] sp =
        {
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strOrgCode",strOrgCode)
        };

       return Query(strSQL, sp);
   }


   public DataTable DownloadStart2(
        string strYm,
        string strOrgCode,
        string strKind,
        string p_code_sys,
        string p_code_type,
        string p_code_no,
        string p_code
  )
   {
       string strSQL =
              " select sum(isnull(trndata_amt,0)) trndata_amt, count(1) cnt "
            + " from sal_satrndata "
            + " where trndata_ym=@strYm "
            + " and trndata_orgid=@strOrgCode "
            + " and trndata_kind=@strKind "
            + " and trndata_code_sys=@p_code_sys "
            + " and trndata_code_type=@p_code_type "
            + " and trndata_code_no=@p_code_no  "
            + " and trndata_code=@p_code ";


       SqlParameter[] sp =
        {
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@p_code_sys",p_code_sys),
            new SqlParameter("@p_code_type",p_code_type),
            new SqlParameter("@p_code_no",p_code_no),
            new SqlParameter("@p_code",p_code)
        };

       return Query(strSQL, sp);
   }


   public DataTable SQLs1(
          string strYm,
          string strOrgCode,
       string p_tdpm_tdpf_seqno
  )
   {
       string strSQL = "select * from sal_satrndata,sal_sabase " +
                  " where trndata_orgid=@strOrgCode " +
                  " and trndata_ym=@strYm " +
                  " and trndata_kind='005' and trndata_code_sys='003'" +
                  " and trndata_code_type='003' and trndata_code_no='003'" +
                  " and trndata_orgid=base_orgid" +
                  " and trndata_seqno=base_seqno" +
                  " and trndata_seqno in (" +
                  " select bank_seqno from sal_sabank" +
                  " where bank_orgid=@strOrgCode  and bank_tdpf_seqno=@p_tdpm_tdpf_seqno " +
                  " and (bank_bank_no is not null AND LEN(bank_bank_no)>0)) ";
        strSQL += " order by (CASE base_prono when '' then 'N' else isNull(base_prono,'N') END),isNull(base_prts,99999), base_name ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@p_tdpm_tdpf_seqno",p_tdpm_tdpf_seqno)
        };

       return Query(strSQL, sp);
   }




   public DataTable SQLs1_1(
         string strYm,
         string strOrgCode,
         string strKind,
         string p_code_sys,
         string p_code_type,
         string p_code_no,
         string p_code,
         string p_tdpm_tdpf_seqno
)
   {
       string strSQL = "select * from sal_satrndata,sal_sabase" +
                  " where trndata_orgid=@strOrgCode " +
                  " and trndata_ym=@strYm " +
                  " and trndata_kind=@strKind  and trndata_code_sys=@p_code_sys " +
                  " and trndata_code_type=@p_code_type  and trndata_code_no=@p_code_no " +
                  " and trndata_code=@p_code " +
                  " and trndata_orgid=base_orgid" +
                  " and trndata_seqno=base_seqno" +
                  " and trndata_seqno in (select bank_seqno from sal_sabank " +
                  " where bank_orgid=@strOrgCode  and bank_tdpf_seqno=@p_tdpm_tdpf_seqno and " +
                  " (bank_bank_no is not null AND LEN(bank_bank_no)>0)) ";
         strSQL+= " order by (CASE base_prono when '' then 'N' else isNull(base_prono,'N') END),isNull(base_prts,99999), base_name ";

       SqlParameter[] sp =
        {
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@p_code_sys",p_code_sys),
            new SqlParameter("@p_code_type",p_code_type),
            new SqlParameter("@p_code_no",p_code_no),
            new SqlParameter("@p_code",p_code),
            new SqlParameter("@p_tdpm_tdpf_seqno",p_tdpm_tdpf_seqno)
        };

       return Query(strSQL, sp);
   }




   public DataTable Reportdata(     
      string strOrgCode,
      string strKind,
      string strYm
)
   {
       string strSQL = 
         "  select BANK_BANK_NO as [存簿帳號]"
        +" , BASE_NAME as [戶名] "
        +" , BASE_IDNO as [身分證字號]"
        +" , TRNDATA_AMT as [轉帳金額]"
        +" , TDPF_BANK_NO as [表首之轉帳帳號]"
        +" from SAL_SATRNDATA"
        +" left outer join SAL_SABANK "
        +" on BANK_ORGID = TRNDATA_ORGID "
        +" and BANK_SEQNO = TRNDATA_SEQNO "
        +" and BANK_TDPF_SEQNO = TRNDATA_TDPF_SEQNO "
        +" left outer join SAL_SATDPF "
        +" on TDPF_ORGID = TRNDATA_ORGID "
        +" and TDPF_SEQNO = TRNDATA_TDPF_SEQNO "
        +" left outer join SAL_SABASE "
        +" on BASE_ORGID = TRNDATA_ORGID "
        +" and BASE_SEQNO = TRNDATA_SEQNO "
        + " WHERE TRNDATA_ORGID = @strOrgCode "
        + " and TRNDATA_KIND = @strKind "
        + " and TRNDATA_YM = @strYm ";


       SqlParameter[] sp =
        {
          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
        };

       return Query(strSQL, sp);
   }




   public DataTable step5_1(
   string strOrgCode,
   string strKind,
   string strYm,
   string strDate
)
   {
       string strSQL =
          "select  base_email "//  --  發信對象的EMAIL
        + " , payo_orgid, payo_yymm, payo_kind, payo_date"
        + " , isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='002' and CODE_NO = PAYO_DCODE) ,'未設定') as dcode "//-- 職稱
        + " , isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='003' and CODE_NO = PAYO_ORG_L3) ,'') +"
        + " isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='006' and CODE_NO = PAYO_ORG_L2 ) ,'') +"
        + " isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='009' and CODE_NO = PAYO_ORG_L2 ) ,'') +"
        + " case ISNULL(PAYO_PTB ,'') when '' then '' else ISNULL(PAYO_PTB ,'') + '點' end as lv "//-- 職等
        + " , PAYO_SEQNO  "//-- 員工編號
        + " , PAYO_NAME  "//-- 姓名
        + " , PAYO_IDNO  ,Payo_prono"//-- 身分證字號
        + " from SAL_SAPAYO "
        + " left outer join SAL_SABASE "
        + " on BASE_ORGID = PAYO_ORGID "
        + " and BASE_SEQNO = PAYO_SEQNO  "
        + " where payo_orgid = base_orgid"
        + " and payo_seqno = base_seqno "
        + " and payo_orgid = @strOrgCode "
        + " and payo_kind = @strKind "
        + " and payo_yymm = @strYm "
        + " and payo_date = @strDate"
        + " and BASE_SENTMAIL = 'Y'"
        + " and ISNULL(BASE_EMAIL ,'') <> ''";             

       SqlParameter[] sp =
        {
          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate)
        };

       return Query(strSQL, sp);
   }



   public DataTable step5_2(
        string strOrgCode,
        string strKind,
        string strYm,
        string strDate,
      string strPAYOMergeflowid
        )
   {
       string strSQL =
         "select BASE_EMAIL "
        +" , isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='002' and CODE_NO = BASE_DCODE) ,'未設定') as dcode "//-- 職稱
        +" , isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='003' and CODE_NO = BASE_ORG_L3) ,'') +"
        +" isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='006' and CODE_NO = BASE_ORG_L1 ) ,'') +"
        +" isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='009' and CODE_NO = BASE_ORG_L2 ) ,'') +"
        +" case ISNULL(BASE_PTB ,'') when '' then '' else ISNULL(BASE_PTB ,'') + '點' end as lv "//-- 職等
        +" , BASE_SEQNO "//-- 員工編號
        +" , BASE_NAME  "//-- 姓名
        + " , BASE_IDNO ,Payo_prono "//-- 身分證字號
        +" from SAL_SABASE  "
        + " WHERE BASE_ORGID = @strOrgCode "
        +" and BASE_SENTMAIL = 'Y'"
        +" and ISNULL(BASE_EMAIL ,'') <> ''"
        +" and exists"
        +" ("
        +" 	select 1 from SAL_SAPAYO "
        +" 	where payo_orgid = base_orgid"
        +" 	and payo_seqno = base_seqno "
        + " and payo_kind = @strKind "
        + " and payo_yymm = @strYm "
        + " and payo_date = @strDate "
        +" 	and PAYO_Merge_flow_id in ("+strPAYOMergeflowid+")"
        +" )";             

       SqlParameter[] sp =
        {          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate)
        };

       return Query(strSQL, sp);
   }



   public DataTable step5_3(
     string strOrgCode,
     string strKind,
     string strYm,
     string strDate,
     string strPAYOMergeflowid,
     string PAYO_SEQNO
     )
   {
       string strSQL =
          " select * "
        + " from SAL_SAPAYOD "
        + " where PAYOD_ORGID = @strOrgCode "
        + " AND PAYOD_SEQNO =@PAYO_SEQNO "
        + " and payod_kind = @strKind "
        + " and payod_ym = @strYm "
        + " and payod_date = @strDate "
        + " and PAYOd_Merge_flow_id in ("+strPAYOMergeflowid+")"
        + " and PAYOD_CODE_TYPE = '001'";

       SqlParameter[] sp =
        {          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@PAYO_SEQNO",PAYO_SEQNO),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate)
        };

       return Query(strSQL, sp);
   }


   public DataTable step5_4(
  string strOrgCode,
  string strKind,
  string strYm,
  string strDate,
  string strPAYOMergeflowid,
     string  PAYO_SEQNO
  )
   {
       string strSQL =
      " select * "
    + " from SAL_SAPAYOD "
    + " where PAYOD_ORGID = @strOrgCode "
    + " AND PAYOD_SEQNO =@PAYO_SEQNO "
    + " and payod_kind = @strKind "
    + " and payod_ym = @strYm "
    + " and payod_date = @strDate "
    + " and PAYOd_Merge_flow_id in ("+strPAYOMergeflowid+")"
    + " and PAYOD_CODE_TYPE = '002'";


       SqlParameter[] sp =
        {          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@PAYO_SEQNO",PAYO_SEQNO),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate)
        };

       return Query(strSQL, sp);
   }



   public DataTable step5_5(
        string strOrgCode,
        string strKind,
        string strYm,
        string strDate,
        string PAYO_SEQNO,
        string payo_kind_code_type,
        string payo_kind_code_no,
        string payo_kind_code          
        )
   {
       string strSQL =
                     " SELECT  PAYOD_AMT"//--金額顯示
                   + " , PAYOD_YM, PAYOD_SEQNO, PAYOD_ORGID, PAYOD_CODE_SYS"
                   + " , PAYOD_CODE_KIND, PAYOD_CODE_TYPE, PAYOD_CODE_NO"
                   + " , PAYOD_CODE, PAYOD_KIND, PAYOD_DATE"
                   + " , PAYOD_SIGN, PAYOD_INCOME, PAYOD_MUSER, PAYOD_MDATE"
                   + " , PAYOD_KIND_CODE_NO, PAYOD_KIND_CODE, PAYOD_KIND_CODE_TYPE"
                   + " , PAYOD_PRIKEY"
                   + " FROM SAL_SAPAYOD "
                   + " WHERE PAYOD_ORGID =@strOrgCode "
                   + " AND PAYOD_SEQNO =@PAYO_SEQNO "
                   + " AND PAYOD_KIND =@strKind "
                   + " AND PAYOD_YM =@strYm "
                   + " AND PAYOD_DATE =@strDate "
                   + " AND PAYOD_KIND_CODE_TYPE =@payo_kind_code_type "
                   + " AND PAYOD_KIND_CODE_NO =@payo_kind_code_no "
                   + " AND PAYOD_KIND_CODE =@payo_kind_code "
                   + " AND PAYOD_CODE_TYPE = '001'"  
                   + " ORDER BY PAYOD_CODE_SYS, PAYOD_CODE_TYPE, PAYOD_CODE_NO, PAYOD_CODE";


       SqlParameter[] sp =
        {          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate),
            new SqlParameter("@PAYO_SEQNO",PAYO_SEQNO),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code),
        };

       return Query(strSQL, sp);
   }



   public DataTable step5_6(
     string strOrgCode,
     string strKind,
     string strYm,
     string strDate,
     string PAYO_SEQNO,
     string payo_kind_code_type,
     string payo_kind_code_no,
     string payo_kind_code
     )
   {
       string strSQL =
                     " SELECT  PAYOD_AMT"//--金額顯示
                   + " , PAYOD_YM, PAYOD_SEQNO, PAYOD_ORGID, PAYOD_CODE_SYS"
                   + " , PAYOD_CODE_KIND, PAYOD_CODE_TYPE, PAYOD_CODE_NO"
                   + " , PAYOD_CODE, PAYOD_KIND, PAYOD_DATE"
                   + " , PAYOD_SIGN, PAYOD_INCOME, PAYOD_MUSER, PAYOD_MDATE"
                   + " , PAYOD_KIND_CODE_NO, PAYOD_KIND_CODE, PAYOD_KIND_CODE_TYPE"
                   + " , PAYOD_PRIKEY"
                   + " FROM SAL_SAPAYOD "
                   + " WHERE PAYOD_ORGID =@strOrgCode "
                   + " AND PAYOD_SEQNO =@PAYO_SEQNO "
                   + " AND PAYOD_KIND =@strKind "
                   + " AND PAYOD_YM =@strYm "
                   + " AND PAYOD_DATE =@strDate "
                   + " AND PAYOD_KIND_CODE_TYPE =@payo_kind_code_type "
                   + " AND PAYOD_KIND_CODE_NO =@payo_kind_code_no "
                   + " AND PAYOD_KIND_CODE =@payo_kind_code "
                   + " AND PAYOD_CODE_TYPE = '002'"
                   + " ORDER BY PAYOD_CODE_SYS, PAYOD_CODE_TYPE, PAYOD_CODE_NO, PAYOD_CODE";


       SqlParameter[] sp =
        {          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strKind",strKind),
            new SqlParameter("@strYm",strYm),
            new SqlParameter("@strDate",strDate),
            new SqlParameter("@PAYO_SEQNO",PAYO_SEQNO),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code),
        };

       return Query(strSQL, sp);
   }





   public DataTable getemail(
   string UserId
   )
   {
       string strSQL = " select * from sal_sabase "
                     + " where base_seqno = @UserId ";


       SqlParameter[] sp =
        {          
            new SqlParameter("@UserId",UserId)
        };

       return Query(strSQL, sp);
   }



   public DataTable step3str(
        string kind,
            string ym,
                string nflow
)
   {
       string strSQL = "select distinct payo_kind_code_type, payo_kind_code_no, payo_kind_code "
                     + " from SAL_SAPAYO "
                     + " where PAYO_KIND = @kind "  //  --  trn_kind 
                     + " and PAYO_YYMM = @ym   "// --  trn_ym"
                     + " and payo_merge_flow_id in ( " + nflow + ")  "; // -- trn_nstring


       SqlParameter[] sp =
        {          
            new SqlParameter("@kind",kind),
              new SqlParameter("@ym",ym), 
              new SqlParameter("@nflow",nflow)
        };

       return Query(strSQL, sp);
   }



   public DataTable newstep2Data(
     string strTrnDataKind,
         string strTrnDataYm         
)
   {
           string strSQL =" select BASE_NAME "//-- 姓名
        +" , base_idno "//-- 身分證字號
        +" , TRNDATA_AMT "//-- 金額
        +" , BANK_BANK_NO "//-- 帳號
        + " , TRNDATA_Merge_Flow_Id "//-- 批號
        +" from SAL_SATRNDATA "
        +" left outer join SAL_SABASE "
        +" on TRNDATA_ORGID = BASE_ORGID "
        +" and TRNDATA_SEQNO = BASE_SEQNO "
        +" left outer join SAL_SABANK "
        +" on TRNDATA_ORGID = BANK_ORGID "
        +" and TRNDATA_SEQNO = BANK_SEQNO "
        +" and TRNDATA_TDPF_SEQNO = BANK_TDPF_SEQNO "
        +" where TRNDATA_KIND = @strTrnDataKind "
        + " and TRNDATA_YM = @strTrnDataYm order by TRNDATA_Merge_Flow_Id,base_dep,base_name ";
       
       SqlParameter[] sp =
        {          
              new SqlParameter("@strTrnDataKind",strTrnDataKind), 
              new SqlParameter("@strTrnDataYm",strTrnDataYm)
        };

       return Query(strSQL, sp);
   }





}