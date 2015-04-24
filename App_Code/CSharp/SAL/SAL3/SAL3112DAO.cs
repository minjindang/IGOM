using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3112DAO 的摘要描述
/// </summary> 
public class SAL3112DAO : BaseDAO
{
	public SAL3112DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL3112DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 取得發放日期
    public DataTable queryDatePayed(
        string strOrgID,            //'登入者機關代碼'
        string strPayoKind,         //'畫面選擇發放種類代碼(code_no)'
        string strPayoYymm,         //'畫面選擇之計算年月'
        string strPayoKindCode      //'發放種類非其他薪津時為''000''，發放種類為其他薪津時，取得項目名稱之代碼'
        )
    {

        string strSQL =
             "select distinct payo_date " +  //--發放日期內容(西元年)
             ",cast(payo_date as int)-19110000 as paydate " +  //--畫面顯示民國年
             "From sal_sapayo " +  
             "where payo_orgid = @OrgID " +  //'登入者機關代碼'
             "and payo_kind = @PayoKind " +  //'畫面選擇發放種類代碼(code_no)'
             "and payo_yymm = @PayoYymm " +  //'畫面選擇之計算年月'
             "and payo_kind_code = @PayoKindCode " +  //'發放種類非其他薪津時為''000''，發放種類為其他薪津時，取得項目名稱之代碼'
             "order by payo_date ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayoKind",strPayoKind),         
            new SqlParameter("@PayoYymm",strPayoYymm),         
            new SqlParameter("@PayoKindCode",strPayoKindCode)
        };

        return Query(strSQL, sp);
    }


    // 取得項目類別一
    public DataTable queryItemType1(
        string strOrgID,        // '使用者登入機關代碼'
        string strPayoYymm      //'畫面選擇之計算年月'
        )
    {
        string strSQL =
            "select distinct payo_kind_code_type " +//--下拉選單代碼
            ",isnull((select code_desc1 from sys_code " +
            "where code_orgid = payo_orgid " +
            "and code_sys='005'  " +
            "and code_type='**'  " +
            "and code_no= payo_kind_code_type ),'無類別') as type_name "+//--下拉選單文字 " 
            "from sal_sapayo " +
            "where payo_orgid = @OrgID " +// '使用者登入機關代碼'
            "and payo_kind = '005' " +
            "and payo_yymm =@PayoYymm " +//'畫面選擇之計算年月'
            "order by payo_kind_code_type ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayoYymm",strPayoYymm)
        };

        return Query(strSQL, sp);
    }


    // 取得項目類別2 
    public DataTable queryItemType2(
        string strOrgID,        // '使用者登入機關代碼'
        string strPayoYymm      //'畫面選擇之計算年月'
        ,string strPayoKindCodeType //'畫面選擇項目類別一之代碼'
        )
    {
        string strSQL =
            "select distinct payo_kind_code_no " +   //--下拉選單代碼
            ",isnull(( select code_desc1 from sys_code " +   
            "where code_orgid = payo_orgid " +   
            "and code_sys='005' " +   
            "and code_type=  @PayoKindCodeType " +   //'畫面選擇項目類別一之代碼'
            "and code_no=payo_kind_code_no ),'無類別') as item_name " +   // --下拉選單文字
            "from sal_sapayo " +   
            "where payo_orgid = @OrgID " +   //'使用者登入機關代碼'
            "and payo_kind = '005' " +   
            "and payo_yymm = @PayoYymm " +   //'畫面選擇之計算年月'
            "and payo_kind_code_type = @PayoKindCodeType " +   //'畫面選擇項目類別一之代碼'
            "order by payo_kind_code_no ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayoYymm",strPayoYymm),
            new SqlParameter("@PayoKindCodeType",strPayoKindCodeType)
        };

        return Query(strSQL, sp);
    }

    // 取得項目名稱
    public DataTable queryItemName(
        string strOrgID,        // '使用者登入機關代碼'
        string strPayoYymm      //'畫面選擇之計算年月'
        , string strPayoKindCodeType //'畫面選擇項目類別一之代碼'
        , string strPayoKindCodeNo // //'畫面選擇項目類別二之代碼'
        )
    {
        string strSQL =
            "select distinct payo_kind_code " +  //--下拉選單代碼
            ",( select isnull(item_name, '不明薪津') from sal_saitem " +  
            "where item_orgid = @OrgID " +  //'使用者登入機關代碼'
            "and item_code_sys='005' " +  
            "and item_code_type = @PayoKindCodeType " +  //'畫面選擇項目類別一之代碼'
            "and item_code_no = @PayoKindCodeNo " +  //'畫面選擇項目類別二之代碼'
            "and item_code = payo_kind_code ) as item_name " +  // --下拉選單文字
            "from sal_sapayo " +  
            "where payo_orgid = @OrgID " +  //'使用者登入機關代碼'
            "and payo_kind = '005' " +  
            "and payo_yymm = @PayoYymm " +  //'畫面選擇之計算年月'
            "and payo_kind_code_type = @PayoKindCodeType " +  //'畫面選擇項目類別一之代碼'
            "and payo_kind_code_no = @PayoKindCodeNo " +  //'畫面選擇項目類別二之代碼'
            "order by payo_kind_code ";


        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayoYymm",strPayoYymm),
            new SqlParameter("@PayoKindCodeType",strPayoKindCodeType),
            new SqlParameter("@PayoKindCodeNo",strPayoKindCodeNo)
        };

        return Query(strSQL, sp);
    }

    // 取得資料
    public DataTable queryData(
        string strOrgID,    //'登入者機關代碼' 
        string strPayoKind, //'畫面查詢之發放種類'  
        string strPayoYymm, //'畫面查詢之計算年月'
        string strPayoDate, ////'畫面查詢之發放日期'
        string strPayoKindCodeType,//--畫面查詢之項目種類一代碼
        string strPayoKindCodeNo,//--畫面查詢之項目種類二代碼
        string strPayoKindCode,//--畫面查詢之項目名稱代碼
        string strPayoName,//員工姓名
        string strPayoSeqNo,    // 員工編號
        string strPayoProno,    // 畫面查詢之員工類別代碼
        string strBaseDep      // 畫面查詢之科室代碼'
        )
    {
        string strSQL =
            "select (select Depart_name from fsc_org where Orgcode=payo_orgid and depart_id=payo_dep) as payo_dep,Payo_prono,payo_orgid, payo_yymm, payo_kind, payo_date " +
            //--, payo_kind_code_sys  [實際表格無此欄位，先移除 ]
            ", payo_kind_code_type, payo_kind_code_no, payo_kind_code " +
            ",payo_seqno " +//--員工編號
            ", payo_name " +// --姓名
            ", payo_freeze " +// --凍結狀態, 當此欄位資料=’Y’時, 隱藏清單上的刪除按鈕
            ",isNull(payo_numerator,0) as payo_numerator " +
            ",isNull(payo_denominator,0) as payo_denominator " +
            ",isnull(( " +
            "select payod_amt from sal_sapayod " +
            "where payod_ym = payo_yymm " +
            "and payod_seqno = payo_seqno " +
            "and payod_orgid = payo_orgid " +
            "and payod_date = payo_date " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003'  " +
            "and payod_code_no = '001'  " +
            "and payod_kind = payo_kind " +
            "and payod_kind_code_type = payo_kind_code_type " +
            "and payod_kind_code_no = payo_kind_code_no " +
            "and payod_kind_code = payo_kind_code " +
            "),0) as payod_amt_001  " +//--應發合計
            ",isnull(( " +
            "select payod_amt from sal_sapayod " +
            "where payod_ym = payo_yymm " +
            "and payod_seqno = payo_seqno " +
            "and payod_orgid = payo_orgid " +
            "and payod_date = payo_date " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003'  " +
            "and payod_code_no = '002'  " +
            "and payod_kind = payo_kind " +
            "and payod_kind_code_type = payo_kind_code_type " +
            "and payod_kind_code_no = payo_kind_code_no " +
            "and payod_kind_code = payo_kind_code " +
            "),0) as payod_amt_002  " +//--應扣合計
            ",isnull(( " +
            "select payod_amt from sal_sapayod " +
            "where payod_ym = payo_yymm " +
            "and payod_seqno = payo_seqno " +
            "and payod_orgid = payo_orgid " +
            "and payod_date = payo_date " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003' " +
            "and payod_code_no = '003' " +
            "and payod_kind = payo_kind " +
            "and payod_kind_code_type = payo_kind_code_type " +
            "and payod_kind_code_no = payo_kind_code_no " +
            "and payod_kind_code = payo_kind_code " +
            "),0) as payod_amt_003  " +//--實發金額
            ",payo_hous, payo_replace_amt, payo_tax " +
            ",PAYO_QUIT_DATE, PAYO_QUIT_REZN " +
            ",PAYO_FINS_KIND " +
            ",PAYO_LABOR_SERIES, PAYO_FINS_SELF, PAYO_PEN_TYPE, PAYO_PEN_RATE, PAYO_PEN_SERIES " +
            ",PAYO_LABOR_DAYS, PAYO_PEN_DAYS, PAYO_PEN_SUP_DAYS, PAYO_LAB_JIF " +
            ",PAYO_LAB1, PAYO_LAB2, PAYO_LAB3 " +
            "from sal_sapayo ,sal_sabase " +
            "where payo_orgid = base_orgid " +
            "and payo_seqno = base_seqno " +
            "and payo_orgid= @OrgID ";//'登入者機關代碼'
           if (strPayoKind != "ALL")
            {
                strSQL += "and payo_kind = @PayoKind ";//'畫面查詢之發放種類'
            }
          strSQL +=  "and payo_yymm = @PayoYymm " +//'畫面查詢之計算年月'
            "and payo_date = @PayoDate ";//'畫面查詢之發放日期'
        if (strPayoKind == "005")
        {
            strSQL +=
                 "and payo_kind_code_type = @PayoKindCodeType  " +//--畫面查詢之項目種類一代碼--發放種類若為其他薪津，增加此SQL條件
            "and payo_kind_code_no = @PayoKindCodeNo " +//--畫面查詢之項目種類二代碼--發放種類若為其他薪津，增加此SQL條件
            "and payo_kind_code = @PayoKindCode ";//--畫面查詢之項目名稱代碼--發放種類若為其他薪津，增加此SQL條件
        }
        if (strPayoName.Trim()!="")
        {
            strSQL+=
            "and payo_name like '%'+@PayoName+'%'  " ;//--當使用者輸入員工姓名欄位時，增加此查詢條件
        }
        if (strPayoSeqNo.Trim() != "")
        {
            strSQL+=
            "and payo_seqno = @PayoSeqNo " ;//--畫面查詢之員工編號  --當使用者輸入員工姓名欄位時，增加此查詢條件
        }
        if(strPayoProno!="ALL")
        {
            strSQL += "and payo_prono in (@strPayoProno) ";//'畫面查詢之員工類別代碼'
        }
        if(strBaseDep!="ALL")
        {
          strSQL+=  "and payo_dep like @strBaseDep +'%' " ;//'畫面查詢之科室代碼'
        }
          strSQL+=  "order by isnull(payo_prono,'999') ,cast(base_prts as float) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),     
            new SqlParameter("@PayoKind",strPayoKind),
            new SqlParameter("@PayoYymm",strPayoYymm),
            new SqlParameter("@PayoDate",strPayoDate),
            new SqlParameter("@PayoKindCodeType",strPayoKindCodeType),
            new SqlParameter("@PayoKindCodeNo",strPayoKindCodeNo),
            new SqlParameter("@PayoKindCode",strPayoKindCode),
            new SqlParameter("@PayoName",strPayoName),
            new SqlParameter("@PayoSeqNo",strPayoSeqNo),
            new SqlParameter("@strPayoProno",strPayoProno),
            new SqlParameter("@strBaseDep",strBaseDep)
        };

        return Query(strSQL, sp);

    }




      // 取得應發項目資料
    public DataTable querytxtData(
        string payo_orgid,    
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
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
                   + " WHERE PAYOD_ORGID =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                   + " AND PAYOD_SEQNO =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                   + " AND PAYOD_KIND =@payo_kind "//清單中所點選項目之payo_kind欄位值
                   + " AND PAYOD_YM =@payo_yymm "//清單中所點選項目之payo_yymm欄位值
                   + " AND PAYOD_DATE =@payo_date "//清單中所點選項目之payo_date欄位值
                   + " AND PAYOD_KIND_CODE_TYPE =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                   + " AND PAYOD_KIND_CODE_NO =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                   + " AND PAYOD_KIND_CODE =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
                   + " AND PAYOD_CODE_TYPE = '001'"//—應發項目增加此查詢條件
            //  AND PAYOD_CODE_TYPE = '002'—應扣項目增加此查詢條件
            //  AND PAYOD_CODE_TYPE = '007'—機關負擔增加此查詢條件
                  + "  ORDER BY PAYOD_CODE_SYS, PAYOD_CODE_TYPE, PAYOD_CODE_NO, PAYOD_CODE";
                
               SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };

        return Query(strSQL, sp);
    }

    // 取得應扣項目資料
    public DataTable querytxt2Data(
        string payo_orgid, 
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
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
                   + " WHERE PAYOD_ORGID =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                   + " AND PAYOD_SEQNO =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                   + " AND PAYOD_KIND =@payo_kind "//清單中所點選項目之payo_kind欄位值
                   + " AND PAYOD_YM =@payo_yymm "//清單中所點選項目之payo_yymm欄位值
                   + " AND PAYOD_DATE =@payo_date "//清單中所點選項目之payo_date欄位值
                   + " AND PAYOD_KIND_CODE_TYPE =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                   + " AND PAYOD_KIND_CODE_NO =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                   + " AND PAYOD_KIND_CODE =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
            //       + " AND PAYOD_CODE_TYPE = '001'"//—應發項目增加此查詢條件
            +" AND PAYOD_CODE_TYPE = '002'"//—應扣項目增加此查詢條件
            //  AND PAYOD_CODE_TYPE = '007'—機關負擔增加此查詢條件
                  + "  ORDER BY PAYOD_CODE_SYS, PAYOD_CODE_TYPE, PAYOD_CODE_NO, PAYOD_CODE";
        
        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };

        return Query(strSQL, sp);
    }

    // 取得機關負擔項目資料
    public DataTable querytxt3Data(
        string payo_orgid,
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
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
                   + " WHERE PAYOD_ORGID =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                   + " AND PAYOD_SEQNO =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                   + " AND PAYOD_KIND =@payo_kind "//清單中所點選項目之payo_kind欄位值
                   + " AND PAYOD_YM =@payo_yymm "//清單中所點選項目之payo_yymm欄位值
                   + " AND PAYOD_DATE =@payo_date "//清單中所點選項目之payo_date欄位值
                   + " AND PAYOD_KIND_CODE_TYPE =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                   + " AND PAYOD_KIND_CODE_NO =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                   + " AND PAYOD_KIND_CODE =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
            //       + " AND PAYOD_CODE_TYPE = '001'"//—應發項目增加此查詢條件
            // AND PAYOD_CODE_TYPE = '002'"//—應扣項目增加此查詢條件
                  +" AND PAYOD_CODE_TYPE = '007'"//—機關負擔增加此查詢條件
                  + "  ORDER BY PAYOD_CODE_SYS, PAYOD_CODE_TYPE, PAYOD_CODE_NO, PAYOD_CODE";
        
        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };
        return Query(strSQL, sp);
    }


    // 取得應發合計
    public DataTable querytotalData(
        string payo_orgid,
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
            string payo_kind_code_type,
            string payo_kind_code_no,
            string payo_kind_code
        )
    {
        string strSQL =
                       "  Select payod_amt"
                      +"  From sal_sapayod"
                      + "  where payod_orgid =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                      + "  and payod_seqno =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                      + "  and payod_ym =@payo_yymm "// 清單中所點選項目之payo_yymm欄位值
                      + "  and payod_kind =@payo_kind "//清單中所點選項目之payo_kind欄位值
                      + "  and payod_date =@payo_date"// 清單中所點選項目之payo_date欄位值
                      + "  and payod_kind_code_type =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                      + "  and payod_kind_code_no =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                      + "  and payod_kind_code =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
                      +"  and payod_code_sys = '003' "
                      +"  and payod_code_type = '003' "
                      +"  and payod_code_no = '001'";//—應發合計增加此查詢條件
                     //   and payod_code_no = '002'—應扣合計增加此查詢條件
                     //   and payod_code_no = '003'—實發數增加此查詢條件

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };
        return Query(strSQL, sp);
    }

    // 取得應扣合計
    public DataTable querytotal2Data(
        string payo_orgid,
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
            string payo_kind_code_type,
            string payo_kind_code_no,
            string payo_kind_code
        )
    {
        string strSQL =
                        "  Select payod_amt"
                      + "  From sal_sapayod"
                      + "  where payod_orgid =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                      + "  and payod_seqno =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                      + "  and payod_ym =@payo_yymm "// 清單中所點選項目之payo_yymm欄位值
                      + "  and payod_kind =@payo_kind "//清單中所點選項目之payo_kind欄位值
                      + "  and payod_date =@payo_date"// 清單中所點選項目之payo_date欄位值
                      + "  and payod_kind_code_type =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                      + "  and payod_kind_code_no =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                      + "  and payod_kind_code =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
                      + "  and payod_code_sys = '003' "
                      + "  and payod_code_type = '003' "
            //           + "  and payod_code_no = '001'";//—應發合計增加此查詢條件
          + " and payod_code_no = '002'";//—應扣合計增加此查詢條件
        //   and payod_code_no = '003'—實發數增加此查詢條件

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };
        return Query(strSQL, sp);
    }

    // 取得實發數
    public DataTable querytotal3Data(
        string payo_orgid,
            string payo_seqno, 
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
            string payo_kind_code_type,
            string payo_kind_code_no,
            string payo_kind_code
        )
    {
        string strSQL =
                        "  Select payod_amt"
                      + "  From sal_sapayod"
                      + "  where payod_orgid =@payo_orgid "//清單中所點選項目之payo_orgid欄位值
                      + "  and payod_seqno =@payo_seqno "//清單中所點選項目之payo_seqno欄位值
                      + "  and payod_ym =@payo_yymm "// 清單中所點選項目之payo_yymm欄位值
                      + "  and payod_kind =@payo_kind "//清單中所點選項目之payo_kind欄位值
                      + "  and payod_date =@payo_date"// 清單中所點選項目之payo_date欄位值
                      + "  and payod_kind_code_type =@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
                      + "  and payod_kind_code_no =@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
                      + "  and payod_kind_code =@payo_kind_code "//清單中所點選項目之payo_kind_code欄位值
                      + "  and payod_code_sys = '003' "
                      + "  and payod_code_type = '003' "
            //             + "  and payod_code_no = '001'";//—應發合計增加此查詢條件
            //   and payod_code_no = '002'—應扣合計增加此查詢條件
        + "   and payod_code_no = '003'";//—實發數增加此查詢條件

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)
        };
        return Query(strSQL, sp);
    }


    // 取得備註
    public DataTable querynoteData(
            string payo_orgid,
            string payo_seqno,   
            string payo_kind, 
            string payo_yymm, 
            string payo_date,
            string payo_kind_code_type,
            string payo_kind_code_no,
            string payo_kind_code,
            string payo_kind_code_sys
        )
    {
        string strSQL =
                " select memo_description from sal_samemo " 
               +" where memo_orgid=@payo_orgid "//清單中所點選項目之payo_orgid欄位值
               +" and memo_seqno=@payo_seqno "//清單中所點選項目之payo_seqno欄位值
               +" and memo_ym=@payo_yymm "//清單中所點選項目之payo_yymm欄位值
               +" and memo_date=@payo_date "//清單中所點選項目之payo_date欄位值
               +" and memo_kind=@payo_kind "//清單中所點選項目之payo_kind欄位值
               + " and memo_code_sys=@payo_kind_code_sys "//清單中所點選項目之payo_kind_code_sys欄位值
               + " and memo_code_type=@payo_kind_code_type "//清單中所點選項目之payo_kind_code_type欄位值
               + " and memo_code_no=@payo_kind_code_no "//清單中所點選項目之payo_kind_code_no欄位值
               + " and memo_code=@payo_kind_code ";//清單中所點選項目之payo_kind_code欄位值

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),     
            new SqlParameter("@payo_seqno",payo_seqno),
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type),
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code),
            new SqlParameter("@payo_kind_code_sys",payo_kind_code_sys)
        };
        return Query(strSQL, sp);
    }

    //勞保職業災害費率
    public DataTable getParam(
     string strOrgID           //'登入者機關代碼'    
     )
    {
                    string strSQL =
                         " select isnull(UNIT_LABOR_CALM_RATE, 0)"
                     +" from sal_saunit where unit_no =@OrgID ";//登入者機關代碼
        
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID)         
        };
        return Query(strSQL, sp);
    }

    //勞保普通事故保費率
    public DataTable getParam2(
     string yymm          
     )
    {
        string strSQL =
           "select dbo.Get_Para('006','P','001','010',@yymm) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@yymm",yymm)         
        };
        return Query(strSQL, sp);
    }

    //勞保就業保險費率
    public DataTable getParam3(
     string yymm         
     )
    {
        string strSQL =
           "select dbo.Get_Para('006','P','001','015',@yymm) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@yymm",yymm)         
        };
        return Query(strSQL, sp);
    }

    //勞保保費自付比率
    public DataTable getParam4(
   string yymm
   )
    {
        string strSQL =
           "select dbo.Get_Para('006','P','001','011',@yymm)";

        SqlParameter[] sp =
        {
            new SqlParameter("@yymm",yymm)         
        };
        return Query(strSQL, sp);
    }

    //勞保保費機關補助比率
    public DataTable getParam5(
    string yymm
    )
    {
        string strSQL =
           "select dbo.Get_Para('006','P','001','012',@yymm)";

        SqlParameter[] sp =
        {
            new SqlParameter("@yymm",yymm)         
        };
        return Query(strSQL, sp);
    }


    public DataTable queryitem2Data(
    string payo_orgid
    )
    {
        string strSQL =
            " select item_name from sal_saitem where item_orgid=@payo_orgid "
       + " and item_code_sys='005' and item_code_type='002'"
       + " and item_code_no='025'"
       + " and item_code='019'";

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid)         
        };
        return Query(strSQL, sp);
    }

    public DataTable queryitemData(
        string payo_orgid,
        string payod_code_sys,
        string payod_code_type,
        string payod_code_no,
        string payod_code
  )
    {
        string strSQL =
           " select item_name from sal_saitem where item_orgid=@payo_orgid "
        + " and item_code_sys=@payod_code_sys and item_code_type=@payod_code_type "
        + " and item_code_no=@payod_code_no "
        + " and item_code=@payod_code ";

        SqlParameter[] sp =
        {
            new SqlParameter("@payo_orgid",payo_orgid),    
            new SqlParameter("@payod_code_sys",payod_code_sys) ,
            new SqlParameter("@payod_code_type",payod_code_type), 
            new SqlParameter("@payod_code_no",payod_code_no) ,
            new SqlParameter("@payod_code",payod_code) 
        };
        return Query(strSQL, sp);
    }


    public DataTable queryItem_TaxData(
     string strOrgCode,
     string strPayoKindCodeType,
     string strPayoKindCodeNo,
     string strPayoKindCode
)
    {
        string strSQL =
          "  select item_tax ,item_tax_type from sal_saitem  "
        + "  where item_orgid = @strOrgCode "
        + " and item_code_type =@strPayoKindCodeType "
        + " and item_code_no = @strPayoKindCodeNo and item_code =@strPayoKindCode ";

        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),    
            new SqlParameter("@strPayoKindCodeType",strPayoKindCodeType) ,
            new SqlParameter("@strPayoKindCodeNo",strPayoKindCodeNo), 
            new SqlParameter("@strPayoKindCode",strPayoKindCode)    
        };
        return Query(strSQL, sp);
    }

    //更新 sapayod
    public void editData(string v_amt,
            string v_mid,
            string v_datetime,
            string txtpayo_yymm,
            string txtpayo_seqno,
            string txtpayo_orgid,
            string txtpayo_kind,
            string txtpayo_date,
            string txtpayo_kind_code_type,
            string txtpayo_kind_code_no,
            string txtpayo_kind_code,
            string v_code_sys,
            string v_code_type,
            string v_code_no,
            string v_code)
    {
        string strSQL =
         
         "update sal_sapayod set payod_amt= @v_amt ,"
        + "payod_muser=@v_mid,"
        + "payod_mdate=@v_datetime "
        + " where payod_ym=@txtpayo_yymm "
        + " and payod_seqno=@txtpayo_seqno"
        + " and payod_orgid=@txtpayo_orgid "
        + " and payod_kind=@txtpayo_kind"
        + " and payod_date=@txtpayo_date "
        + " and payod_kind_code_type = @txtpayo_kind_code_type "
        + " and payod_kind_code_no =@txtpayo_kind_code_no"
        + " and payod_kind_code =@txtpayo_kind_code "
        + " and payod_code_sys=@v_code_sys"
        + " and payod_code_type=@v_code_type "
        + " and payod_code_no=@v_code_no";

        if (v_code != "")
        {
            strSQL += " and payod_code=@v_code";
        }

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_amt",v_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
             new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
             new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code), 
            new SqlParameter("@v_code_sys",v_code_sys) ,
             new SqlParameter("@v_code_type",v_code_type),    
            new SqlParameter("@v_code_no",v_code_no) ,
            new SqlParameter("@v_code",v_code)            
        };
        Execute(strSQL, sp);
    }

   // 更新 sapayod 存總數(加項)
    public void editData2(string v_add_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code     
        )
    {
        string strSQL = 
         "update sal_sapayod set payod_amt=@v_add_amt, "
         + "payod_muser=@v_mid , "
         + "payod_mdate=@v_datetime "
         + " where payod_ym=@txtpayo_yymm"
         + " and payod_seqno=@txtpayo_seqno"
         + " and payod_orgid=@txtpayo_orgid"
         + " and payod_kind=@txtpayo_kind"
         + " and payod_date=@txtpayo_date"
         + " and payod_kind_code_type =@txtpayo_kind_code_type"
         + " and payod_kind_code_no =@txtpayo_kind_code_no"
         + " and payod_kind_code =@txtpayo_kind_code"
         + " and payod_code_sys='003'"
         + " and payod_code_type='003'"
         + " and payod_code_no='001'";    

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_add_amt",v_add_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code) 
        };
        Execute(strSQL, sp);
    }



    public void editData3(string v_amt,
           string v_mid,
           string v_datetime,
           string txtpayo_yymm,
           string txtpayo_seqno,
           string txtpayo_orgid,
           string txtpayo_kind,
           string txtpayo_date,
           string txtpayo_kind_code_type,
           string txtpayo_kind_code_no,
           string txtpayo_kind_code,
           string v_code_sys,
           string v_code_type,
           string v_code_no,
           string v_code)
    {
        string strSQL =
              "update sal_sapayod set payod_amt=@v_amt ,"
         + "payod_muser=@v_mid ,"
         + "payod_mdate=@v_datetime "
         + " where payod_ym=@txtpayo_yymm "
         + " and payod_seqno=@txtpayo_seqno "
         + " and payod_orgid=@txtpayo_orgid "
         + " and payod_kind=@txtpayo_kind "
         + " and payod_date=@txtpayo_date  "
         + " and payod_kind_code_type = @txtpayo_kind_code_type "
         + " and payod_kind_code_no = @txtpayo_kind_code_no "
         + " and payod_kind_code = @txtpayo_kind_code "
         + " and payod_code_sys=@v_code_sys "
         + " and payod_code_type=@v_code_type "
         + " and payod_code_no=@v_code_no ";
     
        if (v_code != "")
        {
            strSQL += " and payod_code=@v_code";
        }

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_amt",v_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code), 
            new SqlParameter("@v_code_sys",v_code_sys) ,
            new SqlParameter("@v_code_type",v_code_type),    
            new SqlParameter("@v_code_no",v_code_no) ,
            new SqlParameter("@v_code",v_code)            
        };
        Execute(strSQL, sp);
    }

    public void editData4(string v_sub_amt,
        string v_mid,
        string v_datetime,
        string txtpayo_yymm,
        string txtpayo_seqno,
        string txtpayo_orgid,
        string txtpayo_kind,
        string txtpayo_date,
        string txtpayo_kind_code_type,
        string txtpayo_kind_code_no,
        string txtpayo_kind_code
       )
    {
        string strSQL =
         "update sal_sapayod set payod_amt=@v_sub_amt, "
         + "payod_muser=@v_mid , "
         + "payod_mdate=@v_datetime "
         + " where payod_ym=@txtpayo_yymm"
         + " and payod_seqno=@txtpayo_seqno"
         + " and payod_orgid=@txtpayo_orgid"
         + " and payod_kind=@txtpayo_kind"
         + " and payod_date=@txtpayo_date"
         + " and payod_kind_code_type =@txtpayo_kind_code_type"
         + " and payod_kind_code_no =@txtpayo_kind_code_no"
         + " and payod_kind_code =@txtpayo_kind_code"
         + " and payod_code_sys='003'"
         + " and payod_code_type='003'"
         + " and payod_code_no='002'";

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_sub_amt",v_sub_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code)
        };
        Execute(strSQL, sp);
    }

    public void editData5(string v_tot_amt,
     string v_mid,
     string v_datetime,
     string txtpayo_yymm,
     string txtpayo_seqno,
     string txtpayo_orgid,
     string txtpayo_kind,
     string txtpayo_date,
     string txtpayo_kind_code_type,
     string txtpayo_kind_code_no,
     string txtpayo_kind_code
    )
    {
        string strSQL =
         "update sal_sapayod set payod_amt=@v_tot_amt, "
         + "payod_muser=@v_mid , "
         + "payod_mdate=@v_datetime "
         + " where payod_ym=@txtpayo_yymm"
         + " and payod_seqno=@txtpayo_seqno"
         + " and payod_orgid=@txtpayo_orgid"
         + " and payod_kind=@txtpayo_kind"
         + " and payod_date=@txtpayo_date"
         + " and payod_kind_code_type =@txtpayo_kind_code_type"
         + " and payod_kind_code_no =@txtpayo_kind_code_no"
         + " and payod_kind_code =@txtpayo_kind_code"
         + " and payod_code_sys='003'"
         + " and payod_code_type='003'"
         + " and payod_code_no='003'";


        SqlParameter[] sp =
        {  
            new SqlParameter("@v_tot_amt",v_tot_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code) 
        };
        Execute(strSQL, sp);
    }

    public void editData6(string v_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code,
         string v_code_sys,
         string v_code_type,
         string v_code_no,
         string v_code)
    {
        string strSQL =
              "update sal_sapayod set payod_amt=@v_amt ,"
         + "payod_muser=@v_mid ,"
         + "payod_mdate=@v_datetime "
         + " where payod_ym=@txtpayo_yymm "
         + " and payod_seqno=@txtpayo_seqno "
         + " and payod_orgid=@txtpayo_orgid "
         + " and payod_kind=@txtpayo_kind "
         + " and payod_date=@txtpayo_date  "
         + " and payod_kind_code_type = @txtpayo_kind_code_type "
         + " and payod_kind_code_no = @txtpayo_kind_code_no "
         + " and payod_kind_code = @txtpayo_kind_code "
         + " and payod_code_sys=@v_code_sys "
         + " and payod_code_type=@v_code_type "
         + " and payod_code_no=@v_code_no ";

        if (v_code != "")
        {
            strSQL += " and payod_code=@v_code";
        }    

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_amt",v_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind), 
            new SqlParameter("@txtpayo_date",txtpayo_date) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code), 
            new SqlParameter("@v_code_sys",v_code_sys) ,
            new SqlParameter("@v_code_type",v_code_type),    
            new SqlParameter("@v_code_no",v_code_no) ,
            new SqlParameter("@v_code",v_code)            
        };
        Execute(strSQL, sp);
    }

    // 取得 房屋津貼、食物代金    
    public DataTable getData(
       string txtpayo_kind,
       string txtpayo_kind_code_type,
       string txtpayo_kind_code_no,
       string txtpayo_kind_code,
       string txtpayo_yymm,
       string txtpayo_seqno,
       string txtpayo_orgid,
       string txtpayo_date
        )
    {
      string strSQL = 
         " select inco_hous_amt, inco_repl_amt from sal_sainco "
       + " where inco_code = @txtpayo_kind "
       + " and inco_kind_code_type = @txtpayo_kind_code_type "
       + " and inco_kind_code_no = @txtpayo_kind_code_no "
       + " and inco_kind_code = @txtpayo_kind_code "
       + " and inco_ym = @txtpayo_yymm "
       + " and inco_seqno = @txtpayo_seqno "
       + " and inco_orgid =@txtpayo_orgid "
       + " and inco_date=@txtpayo_date ";
     

        SqlParameter[] sp =
        {
            new SqlParameter("@txtpayo_kind",txtpayo_kind),  
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),  
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_date",txtpayo_date)            
        };
        return Query(strSQL, sp);
    }


    public void editData7(
    string v_inco_amt,
    string v_inco_txam,
    string v_inco_real_amt,
    string v_inco_kdc,
    string v_inco_fee,
    string v_inco_fees,
    string v_inco_leave_self,
    string v_inco_leave_sup,
    string v_pen_amt,
    string v_mid,
    string v_datetime,
    string txtpayo_kind,
    string txtpayo_kind_code_type,
    string txtpayo_kind_code_no,
    string txtpayo_kind_code,
    string txtpayo_yymm,
    string txtpayo_seqno,
    string txtpayo_orgid,
    string txtpayo_date
        )
    {
        string strSQL =
          "update sal_sainco set inco_amt = @v_inco_amt ,"
        + " inco_txam = @v_inco_txam,"
        + " inco_real_amt = @v_inco_real_amt,"
        + " inco_kdc_amt = @v_inco_kdc,"
        + " inco_fee=@v_inco_fee,"
        + " inco_fees=@v_inco_fees,"
        + " inco_leave_self=@v_inco_leave_self,"
        + " inco_leave_sup=@v_inco_leave_sup,"
        + " inco_pen=@v_pen_amt,"
        + " inco_muser=@v_mid,"
        + " inco_mdate=@v_datetime "
        + " where inco_code = @txtpayo_kind"
        + " and inco_kind_code_type = @txtpayo_kind_code_type"
        + " and inco_kind_code_no = @txtpayo_kind_code_no"
        + " and inco_kind_code = @txtpayo_kind_code"
        + " and inco_ym = @txtpayo_yymm"
        + " and inco_seqno = @txtpayo_seqno"
        + " and inco_orgid =@txtpayo_orgid"
        + " and inco_date=@txtpayo_date ";
     
        SqlParameter[] sp =
        {  
            new SqlParameter("@v_inco_amt",v_inco_amt),    
            new SqlParameter("@v_inco_txam",v_inco_txam) ,
            new SqlParameter("@v_inco_real_amt",v_inco_real_amt), 
            new SqlParameter("@v_inco_kdc",v_inco_kdc) ,
            new SqlParameter("@v_inco_fee",v_inco_fee),    
            new SqlParameter("@v_inco_fees",v_inco_fees) ,
            new SqlParameter("@v_inco_leave_self",v_inco_leave_self), 
            new SqlParameter("@v_inco_leave_sup",v_inco_leave_sup) ,
            new SqlParameter("@v_pen_amt",v_pen_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@txtpayo_kind",txtpayo_kind) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code)    ,
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm)   ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno)  , 
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,                   
            new SqlParameter("@txtpayo_date",txtpayo_date)   
        };
        Execute(strSQL, sp);
    }


    public void editData8(string v_adj_amt,
       string v_mid,
       string v_datetime,
       string v_adj_fee,
       string v_adj_self,
       string v_adj_sup,
       string txtpayo_yymm,
       string txtpayo_seqno,
       string txtpayo_orgid
        )
    {
        string strSQL =
           "update sal_sainco set inco_amt = @v_adj_amt,"
        + " inco_muser=@v_mid,"
        + " inco_real_amt = @v_adj_amt,"
        + " inco_mdate=@v_datetime,"
        + " inco_fee=@v_adj_fee,"
        + " inco_leave_self=@v_adj_self, "
        + " inco_leave_sup=@v_adj_sup "
        + " where inco_code = '007'"
        + " and inco_kind_code_type = '000'"
        + " and inco_kind_code_no = '000'"
        + " and inco_kind_code = '000'"
        + " and inco_ym = @txtpayo_yymm"
        + " and inco_seqno =@txtpayo_seqno"
        + " and inco_orgid =@txtpayo_orgid";

   

        SqlParameter[] sp =
        {  
            new SqlParameter("@v_adj_amt",v_adj_amt),    
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_datetime",v_datetime), 
            new SqlParameter("@v_adj_fee",v_adj_fee) ,
            new SqlParameter("@v_adj_self",v_adj_self),    
            new SqlParameter("@v_adj_sup",v_adj_sup) ,
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm), 
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno) ,
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid)
        };
        Execute(strSQL, sp);
    }


    public void editData9(string v_mid,
         string v_labor_days,
         string v_pen_days,
         string v_pen_sup_days,
         string txtpayo_orgid,
         string txtpayo_seqno,
         string txtpayo_yymm,
         string txtpayo_kind,
         string txtpayo_date
      )
    {
        string strSQL =

             " update sal_sapayo "
           + " set payo_muser = @v_mid  "
           + " ,payo_mdate = " + DateTime.Now.ToString("yyyyMMddHHmmss");

          // 勞保
          if (v_labor_days!="")
          {
              // 勞保投保天數
              strSQL += " , payo_labor_days = @v_labor_days ";
          }
          // 勞退
          if (v_pen_days!="")
          {
              // 勞退提領天數
              strSQL += " , payo_pen_days = @v_pen_days ";
          }
          if (v_pen_sup_days!="")
          {
              // 勞退機關負擔天數
              strSQL += " , payo_pen_sup_days = @v_pen_sup_days  ";
          }

          strSQL += " where payo_orgid = @txtpayo_orgid "
           + " and payo_seqno = @txtpayo_seqno "
           + " and payo_yymm = @txtpayo_yymm  "
           + " and payo_kind = @txtpayo_kind  "
           + " and payo_date = @txtpayo_date  ";
        
        SqlParameter[] sp =
        {  
          
            new SqlParameter("@v_mid",v_mid) ,
            new SqlParameter("@v_labor_days",v_labor_days), 
            new SqlParameter("@v_pen_days",v_pen_days) ,
            new SqlParameter("@v_pen_sup_days",v_pen_sup_days),    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_kind",txtpayo_kind),    
             new SqlParameter("@txtpayo_date",txtpayo_date)   
        };
        Execute(strSQL, sp);
    }


    //備註
    public void editData10(
      string txtpayo_kind,
      string txtpayo_seqno,
      string codesys,
      string txtpayo_kind_code_type,
      string txtpayo_kind_code_no,
      string txtpayo_kind_code,
      string txtpayo_yymm,
      string txtpayo_date,
      string txtpayo_orgid,
      string v_code_Kind,
      string txtMemo,
      string v_mid
     )
    {
        string strSQL =
          " Delete sal_samemo where memo_Kind=@txtpayo_kind and Memo_seqno=@txtpayo_seqno and Memo_Code_Sys=@codesys "
         + " and Memo_code_Type=@txtpayo_kind_code_type and Memo_Code_No=@txtpayo_kind_code_no and Memo_Code="
         + " @txtpayo_kind_code and memo_ym=@txtpayo_yymm and memo_date=@txtpayo_date "
         + " Insert Into sal_SAMEMO "
         + "(memo_orgid,memo_kind, memo_seqno,memo_ym,memo_date, memo_code_sys, "
         + " memo_code_kind, memo_code_type, memo_code_no, "
         + " memo_code, memo_description, memo_muser, memo_mdate) "
         + " values( "
         + " @txtpayo_orgid,@txtpayo_kind,@txtpayo_seqno,@txtpayo_yymm,@txtpayo_date,@codesys, "
         + " @v_code_Kind ,@txtpayo_kind_code_type,@txtpayo_kind_code_no, "
         + " @txtpayo_kind_code,@txtMemo,@v_mid," + DateTime.Now.ToString("yyyyMMddHHmmss") + ")";
               

        SqlParameter[] sp =
        {            
            new SqlParameter("@txtpayo_kind",txtpayo_kind) ,
            new SqlParameter("@txtpayo_seqno",txtpayo_seqno) , 
            new SqlParameter("@codesys",codesys) ,
            new SqlParameter("@txtpayo_kind_code_type",txtpayo_kind_code_type),    
            new SqlParameter("@txtpayo_kind_code_no",txtpayo_kind_code_no) ,
            new SqlParameter("@txtpayo_kind_code",txtpayo_kind_code), 
            new SqlParameter("@txtpayo_yymm",txtpayo_yymm) ,
            new SqlParameter("@txtpayo_date",txtpayo_date) ,    
            new SqlParameter("@txtpayo_orgid",txtpayo_orgid) ,
            new SqlParameter("@v_code_Kind",v_code_Kind) ,    
            new SqlParameter("@txtMemo",txtMemo) ,
            new SqlParameter("@v_mid",v_mid) 
        };

        Execute(strSQL, sp);
    }



    public DataTable getdata2(
     string strOrgID    //'登入者機關代碼'
     )
    {
        string strSQL =
             " select UNIT_PEN_RATE "
           + " ,isnull(UNIT_LABOR_CALM_RATE,0) as UNIT_LABOR_CALM_RATE "
           + " from sal_saunit "
           + " where unit_no = @strOrgID ";

        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgID",strOrgID)  

        };

        return Query(strSQL, sp);
    }

    public void deleteData(
            string payo_orgid
          , string payo_seqno
          , string payo_kind
          , string payo_yymm
          , string payo_date
          , string payo_kind_code_type
          , string payo_kind_code_no
          , string payo_kind_code        
   )
    {

        string strSQL = "";       
        string subpayod = "";
        string subpayo = "";
        string subinco = "";
        string delpits = "";
        string delfam = "";
        string sql_seq = "";

        if (payo_kind == "005")
        {
            subpayod = subpayod + " and payod_kind_code_type = @payo_kind_code_type ";
            subpayod = subpayod + " and payod_kind_code_no = @payo_kind_code_no ";
            subpayod = subpayod + " and payod_kind_code = @payo_kind_code ";
            subpayod = subpayod + " and payod_date=@payo_date ";

            subpayo = subpayo + " and payo_kind_code_type = @payo_kind_code_type ";
            subpayo = subpayo + " and payo_kind_code_no = @payo_kind_code_no ";
            subpayo = subpayo + " and payo_kind_code = @payo_kind_code ";
            subpayo = subpayo + " and payo_date=@payo_date ";

            subinco = subinco + " and inco_kind_code_type = @payo_kind_code_type ";
            subinco = subinco + " and inco_kind_code_no = @payo_kind_code_no ";
            subinco = subinco + " and inco_kind_code = @payo_kind_code ";
            subinco = subinco + " and inco_date=@payo_date ";
        }
        else
        {
            subpayod = " and payod_date=@payo_date ";
            subpayo = " and payo_date=@payo_date ";
            subinco = " and inco_date=@payo_date ";
        }

        sql_seq = " select payo_seqno from sal_sapayo ";
        sql_seq = sql_seq + " where payo_yymm=@payo_yymm ";
        sql_seq = sql_seq + " and payo_orgid=@payo_orgid ";
        sql_seq = sql_seq + " and payo_kind=@payo_kind ";
        sql_seq = sql_seq + " and ( payo_freeze <> 'Y' or payo_freeze is null ) ";
        sql_seq = sql_seq + subpayo;

        if (payo_kind != "009")
        {
            strSQL = "delete sal_sapayod ";
            strSQL += " where payod_ym=@payo_yymm ";
            strSQL += " and payod_orgid=@payo_orgid ";
            strSQL += " and payod_kind=@payo_kind ";
            strSQL += " and payod_seqno=@payo_seqno "; //tedadd
            strSQL += " and exists (select * from sal_sapayo ";
            strSQL += "         where payo_orgid=payod_orgid ";
            strSQL += "         and payo_yymm=payod_ym ";
            strSQL += "         and payo_kind=payod_kind ";
            strSQL += "         and payo_date=payod_date ";
            strSQL += "         and ( payo_freeze <> 'Y' or payo_freeze is null )";
            if (payo_kind == "005")
            {
                strSQL += " and payod_kind_code_type = payo_kind_code_type ";
                strSQL += " and payod_kind_code_no = payo_kind_code_no ";
                strSQL += " and payod_kind_code = payo_kind_code ";
            }
            strSQL += " )";
            strSQL += " and payod_seqno in (" + sql_seq + ") ";
            strSQL += subpayod + "; ";

            strSQL += "delete sal_sapayo ";
            strSQL += " where payo_yymm=@payo_yymm ";
            strSQL += " and payo_orgid=@payo_orgid ";
            strSQL += " and payo_kind=@payo_kind ";
            strSQL += " and payo_seqno=@payo_seqno "; //ted add
            strSQL += " and ( payo_freeze <> 'Y' or payo_freeze is null ) ";
            strSQL += subpayo + "; ";

            strSQL += "delete sal_sainco ";

            if (payo_kind != "001")
            {
                strSQL += " where inco_code = @payo_kind ";
            }
            else
            {
                strSQL += " where inco_code in ( @payo_kind ,'007')";
            }
            strSQL += " and inco_ym = @payo_yymm ";
            strSQL += " and inco_orgid = @payo_orgid ";
            strSQL += " and inco_seqno = @payo_seqno ";  //ted add
            strSQL += " and ( inco_freeze <> 'Y' or inco_freeze is null ) ";
            strSQL += subinco + "; ";


        }
        else
        {
            strSQL+=  " delete sal_sapayod ";
            strSQL += " where payod_ym=@payo_yymm ";
            strSQL += " and payod_orgid= @payo_orgid ";
            strSQL += " and payod_seqno=@payo_seqno ";  //tedadd
            strSQL+= " and exists (select * from sal_sapayo ";
            strSQL+= "         where payo_orgid=payod_orgid ";
            strSQL+= "         and payo_yymm=payod_ym ";
            strSQL+= "         and payo_kind=payod_kind ";
            strSQL+= "         and payo_date=payod_date ";
            strSQL+= "         and ( payo_freeze <> 'Y' or payo_freeze is null )";
            strSQL+= "         )";
          
            strSQL+= " and payod_kind='007'; ";

            strSQL += "delete sal_sapayo ";
            strSQL += " where payo_yymm=@payo_yymm ";
            strSQL += " and payo_orgid= @payo_orgid ";
            strSQL += " and payo_seqno= @payo_seqno "; //ted add
            strSQL += " and ( payo_freeze <> 'Y' or payo_freeze is null ) ";
            strSQL += " and payo_kind='007'; ";

            strSQL += "delete sal_sainco ";
            strSQL += " where inco_code = '007'";
            strSQL += " and inco_ym = @payo_yymm ";
            strSQL += " and inco_orgid = @payo_orgid ";
            strSQL += " and inco_seqno = @payo_seqno "; //ted add
            strSQL += " and ( inco_freeze <> 'Y' or inco_freeze is null ) ";
                
        }

        delpits = " delete from sal_SAPITS";
        delpits += " where pits_orgid= @payo_orgid ";
        delpits += " and pits_ym=@payo_yymm ";
        delpits += " and pits_kind=@payo_kind ";

        if(payo_kind =="005")
        {
            delpits += " and pits_code_sys='005'";
            delpits += " and pits_code_type=@payo_kind_code_type ";
            delpits += " and pits_code_no=@payo_kind_code_no ";
            delpits += " and pits_code=@payo_kind_code ";
        }

        delpits += " and pits_date=@payo_date ";

        delfam = "delete SAL_SAFAMILY "; //SAFAMILY_DESC
        delfam = delfam + " where family_orgid = @payo_orgid ";
  //      delfam = delfam + " and family_ym = @payo_yymm ";
        delfam = delfam + " and family_seqno = @payo_seqno ";

        strSQL = strSQL + ";" + delpits + ";"+ delfam + ";";

        SqlParameter[] sp =
        {            
            new SqlParameter("@payo_orgid",payo_orgid) ,  
            new SqlParameter("@payo_seqno",payo_seqno),   
            new SqlParameter("@payo_kind",payo_kind),
            new SqlParameter("@payo_yymm",payo_yymm),
            new SqlParameter("@payo_date",payo_date),
            new SqlParameter("@payo_kind_code_type",payo_kind_code_type) ,
            new SqlParameter("@payo_kind_code_no",payo_kind_code_no),
            new SqlParameter("@payo_kind_code",payo_kind_code)         
        };

        Execute(strSQL, sp);
    }



}