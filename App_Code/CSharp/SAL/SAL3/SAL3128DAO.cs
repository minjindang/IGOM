using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3118DAO 的摘要描述
/// </summary>
public class SAL3128DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3128DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3128DAO(SqlConnection conn)
        : base(conn)
    {

    }

    //代扣稅額總計
    public DataTable getReportData(string strOrgCode//登入者機關代碼
            , string strbase_dep        // 單位　
            , string strcno             // 人員類別
            , string strname            // 員工姓名
            , string strno              // 員工編號 
            , string strdate1           // 給付起日
            , string strdate2           // 給付迄日
            , string strinco_amt        //所得申報
            , string strBudget_code     // 預算來源
        )
    {
        String strSQL =
                   " select sum(inco_txam) as txam"
                   + " from sal_sainco"
                   + " inner join sal_sabase"
                   + " on base_orgid = inco_orgid"
                   + " and base_seqno = inco_seqno"
                   + " where base_orgid = @strOrgCode"
                   + " and base_status = 'N'";
                    if(strbase_dep !="ALL")
                    {
                        strSQL += " and base_dep = @strbase_dep";
                    }
                    if (strcno != "ALL")
                    {
                        strSQL += " and base_prono = @strcno";
                    }
                    if(strno !="")
                    {
                        strSQL += "  and base_seqno=@strno ";
                    }
                    if(strname !="")
                    {
                        strSQL += "  and base_name like '%'+ @strname +'%'";
                    }
                    if (strdate1 != "" || strdate2 != "")
                    {
                        strSQL += "  and inco_date between @strdate1 and @strdate2 ";
                    }
                  if(strinco_amt =="Y")
                  {
                   strSQL+= " and inco_amt <> 0 ";//-- 查詢之所得申報=Y,增加此條件"
                  }
                  else if(strinco_amt=="N")
                  {
                      strSQL += " and inco_amt = 0 ";//-- 查詢之所得申報=N,增加此條件"
                  }
                  if (strBudget_code != "ALL")
                  {
                      strSQL += " and INCO_Budget_code = @strBudget_code";
                  }
        
    
        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@strbase_dep",strbase_dep),          
            new SqlParameter("@strcno",strcno),             
            new SqlParameter("@strno",strno),    
            new SqlParameter("@strname",strname)  ,
            new SqlParameter("@strdate1",strdate1),        
            new SqlParameter("@strdate2",strdate2),         
            new SqlParameter("@strBudget_code",strBudget_code)                   
        };

        return Query(strSQL, sp);
    }

    //查詢
    public DataTable getSearchData(string strOrgCode//登入者機關代碼
          , string strbase_dep        // 單位　
          , string strcno             // 人員類別
          , string strname            // 員工姓名
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源
      )
    {
        String strSQL =
                    "  select distinct base_type,base_idno,base_seqno,base_name,base_job,base_dcode"
                  + " ,isNull(base_edate,'') as base_edate,isNull(base_quit_date,'') as base_quit_date,base_status "
                  + "  , '非員工' as status_name "
                  + "  ,(  select min(inco_date) "
                  + "  from sal_sainco inco1 "
                  + "  where inco1.inco_orgid=base_orgid "
                  + "  and base_status = 'N' "
                  + "  and inco1.inco_seqno=base_seqno ";
                    if (strdate1 != "" || strdate2 != "")
                    {
                        strSQL += "  and inco1.inco_date between @strdate1 and @strdate2";
                    }
                    if (strinco_amt == "Y")//-- 查詢之所得申報=Y,增加此條件"
                    {
                        strSQL += " and inco1.inco_amt <> 0";
                    }
                    else if (strinco_amt == "N")//-- 查詢之所得申報=N,增加此條件"
                    {
                        strSQL += " and inco1.inco_amt = 0";
                    } 
                    if(strBudget_code!="ALL")
                    {
                        strSQL += " and inco1.INCO_Budget_code = @strBudget_code";
                    }
                     strSQL  += "  ) as mindate"
                       + "  ,("
                       + "  select max(inco_date) "
                       + "  from sal_sainco inco2 "
                       + "  where inco2.inco_orgid=base_orgid "
                       + "  and inco2.inco_seqno=base_seqno ";
                    if (strdate1 != "" || strdate2 != "")
                    {
                        strSQL += "  and inco2.inco_date between @strdate1 and @strdate2";
                    }
                     if (strinco_amt == "Y")//-- 查詢之所得申報=Y,增加此條件"
                    {
                        strSQL += " and inco2.inco_amt <> 0";
                    }
                    else if (strinco_amt == "N")//-- 查詢之所得申報=N,增加此條件"
                    {
                        strSQL += " and inco2.inco_amt = 0";
                    }
                    if(strBudget_code!="ALL")
                    {
                        strSQL += "  and inco2.INCO_Budget_code = @strBudget_code";
                    }
        strSQL += "  ) as maxdate"
                     + "  ,( select count(*) "
                     + "  from sal_sainco inco3 "
                     + "  where inco3.inco_orgid=base_orgid "
                     + "  and inco3.inco_seqno=base_seqno ";
                    if (strdate1 != "" || strdate2 != "")
                    {
                     strSQL+= "  and inco3.inco_date between @strdate1 and @strdate2 ";
                    }
                     if (strinco_amt == "Y")//-- 查詢之所得申報=Y,增加此條件"
                    {
                        strSQL += " and inco3.inco_amt <> 0";
                    }
                    else if (strinco_amt == "N")//-- 查詢之所得申報=N,增加此條件"
                    {
                        strSQL += " and inco3.inco_amt = 0";
                    }
                     if(strBudget_code!="ALL")
                     {
                         strSQL += " and inco3.INCO_Budget_code = @strBudget_code";
                     }
         strSQL += "   ) as incorec"
                     + "   from sal_sabase"
                     + "   where base_orgid = @strOrgCode"
                     + "   and base_status = 'N'"
               
                  //ted add 0718  date is not null          
                  +"and ( "
                  +"(  select min(inco_date)"
                  + "  from sal_sainco inco1 "
                  + "  where inco1.inco_orgid=base_orgid "
                  + "  and base_status = 'N' "
                  + "  and inco1.inco_seqno=base_seqno ";
                     if (strdate1 != "" || strdate2 != "")
                    {
                        strSQL += "  and inco1.inco_date between @strdate1 and @strdate2";
                    }
                     if (strinco_amt == "Y")//-- 查詢之所得申報=Y,增加此條件"
                    {
                        strSQL += " and inco1.inco_amt <> 0";
                    }
                    else if (strinco_amt == "N")//-- 查詢之所得申報=N,增加此條件"
                    {
                        strSQL += " and inco1.inco_amt = 0";
                    } 
                    if(strBudget_code!="ALL")
                    {
                        strSQL += " and inco1.INCO_Budget_code = @strBudget_code ";
                    }
                strSQL += "   ) is not null or "
                       + " ( select max(inco_date) "
                       + "  from sal_sainco inco2 "
                       + "  where inco2.inco_orgid=base_orgid "
                       + "  and inco2.inco_seqno=base_seqno ";
                    if (strdate1 != "" || strdate2 != "")
                    {
                        strSQL += "  and inco2.inco_date between @strdate1 and @strdate2";
                    }
                     if (strinco_amt == "Y")
                    {
                        strSQL += " and inco2.inco_amt <> 0";
                    }
                    else if (strinco_amt == "N")
                    {
                        strSQL += " and inco2.inco_amt = 0";
                    }
                    if(strBudget_code!="ALL")
                    {
                        strSQL += "  and inco2.INCO_Budget_code = @strBudget_code";
                    }
                        strSQL += " ) is not null ) ";
                    //----
    
    /*    if(strbase_dep !="ALL")
        {
            strSQL += "  and base_dep = @strbase_dep";
        }
        if (strcno != "ALL")
        {
            strSQL += "  and base_prono = @strcno";
        }  */
        if(strno!="")
        {
            strSQL += "   and base_idno=@strno";
        }
        if (strname != "")
        {
            strSQL += "   and base_name like '%'+ @strname +'%'";
        }

     
        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@strbase_dep",strbase_dep),          
            new SqlParameter("@strcno",strcno),             
            new SqlParameter("@strno",strno),    
            new SqlParameter("@strname",strname)  ,
            new SqlParameter("@strdate1",strdate1),        
            new SqlParameter("@strdate2",strdate2),         
            new SqlParameter("@strBudget_code",strBudget_code)                   
        };

        return Query(strSQL, sp);
    }


    //查詢清冊
    public DataTable getDetailData(string strOrgCode//登入者機關代碼        
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源
      )
    {
        String strSQL =
                    "  select inco_code "//-- 發放種類，需要代碼轉文字app.GetSaCode_Desc1("003","005",inco_code)"
                    + ",inco_kind_code,inco_kind_code_no "// – 發放種類為005(其他薪津時，需要呈現的項目代碼)"
                    + ",inco_ym "// -- 所得年月"
                    + ",inco_date "//-- 給付日期"
                    + ",inco_icode "// -- 所得格式，需要代碼轉文字app.GetSaCode_Desc1("003","004",inco_icode)"
                    + ",inco_amt "//-- 申報金額(可維護)"
                    + ",inco_txra "//-- 扣繳稅率"
                    + ",inco_txam "//-- 扣繳稅額(可維護)"
                    + ",inco_budget_code "//-- 預算來源代碼，需要代碼轉文字app.GetSaCode_Desc1("002","018", inco_budget_code)"
                    + ",inco_prikey "//-- 資料鍵值"
                    + "from sal_sainco "
                    + "where inco_orgid = @strOrgCode "
                    + "and inco_seqno = @strno ";
        if (strdate1 != "" || strdate2 != "")
        {
            strSQL += "and inco_date between @strdate1 and @strdate2 ";
        }
                  if (strinco_amt == "Y")//-- 查詢之所得申報=Y,增加此條件"
                    {
                        strSQL+="and inco_amt <> 0 ";
                    }
                  else if (strinco_amt == "N")//-- 查詢之所得申報=N,增加此條件"
                    {
                        strSQL += "and inco_amt = 0 ";
                    }
        if(strBudget_code !="ALL")
        {
            strSQL += "and INCO_Budget_code = @strBudget_code ";
        }
        strSQL += " order by inco_date desc";

        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),            
            new SqlParameter("@strno",strno),  
            new SqlParameter("@strdate1",strdate1),        
            new SqlParameter("@strdate2",strdate2),         
            new SqlParameter("@strBudget_code",strBudget_code)                   
        };

        return Query(strSQL, sp);
    }

    //刪除
    public void getdeleteData(string inco_prikey)
    {
        String strSQL = " delete sal_sainco where inco_prikey =@inco_prikey"; //該筆資料之inco_prikey" 

        SqlParameter[] sp =
        {
            new SqlParameter("@inco_prikey",inco_prikey)
        };

        Execute(strSQL, sp);
    }

    //修改
    public void editData(string inco_amt//申報金額
      , string inco_txam              // 扣繳稅額 
      , string inco_muser             // 員工編號
      , string inco_prikey            // Key
     )
    {
        String strSQL =
            "  update sal_sainco"
          + "  set inco_amt = @inco_amt "  //申報金額
          + "  ,inco_txam = @inco_txam "  // 扣繳稅額
          + "  ,inco_muser =@inco_muser " //登入者員工編號
          + "  ,inco_mdate = " + DateTime.Now.ToString("yyyyMMddHHmmss") //現在時間(now.tostring(“yyyyMMddHHmmss”))
          + "  where inco_prikey = @inco_prikey "; //該筆資料之inco_prikey
                        
        SqlParameter[] sp =
        {
            new SqlParameter("@inco_amt",inco_amt),            
            new SqlParameter("@inco_txam",inco_txam),  
            new SqlParameter("@inco_muser",inco_muser),        
            new SqlParameter("@inco_prikey",inco_prikey)  
        };

        Execute(strSQL, sp);
    }

    //get key
    public DataTable getkeyData()
    { 
     String strSQL =
         " declare @seqno int  declare @lpad_seqno varchar(8000) "
      +  " exec get_sequenceno @seqno output   exec lpad @seqno ,12,'0',@lpad_seqno output "
      +  " select @lpad_seqno";

           SqlParameter[] sp = { };

        return Query(strSQL, sp);

    }

    //新增
    public void addData(
              string strno
            , string strOrgCode
            , string date
            , string icode
            , string amt
            , string txra
            , string txam
            , string inco_muser
            , string yymm
            , string prikey
            , string Budget_code
            , string inco_no
            , string Doc_type
            , string rent_no
            , string RENT_ADDR
            , string VOUCHERS
            , string SUMMONS
            , string HEALTH_EXT
  )
    {
        String strSQL =
                "insert into sal_sainco (inco_code ,inco_seqno, inco_orgid "
                + " , inco_date, inco_icode "
                + " , inco_amt, inco_txra"
                + " , inco_txam, inco_fee,inco_fees, inco_leave_self ,inco_leave_sup "
                + " , inco_muser, inco_mdate, inco_ym, inco_prikey"
                + " , inco_kind_code_type"
                + " , inco_kind_code_no"
                + " , inco_kind_code ,inco_KDC_AMT , inco_REPL_AMT, inco_HOUS_AMT ,inco_real_amt,inco_pen , INCO_Budget_code "
                + "  , INCO_NO,INCO_DOC_TYPE,INCO_RENT_NO,INCO_RENT_ADDR,INCO_Vouchers,INCO_Summons,INCO_HEALTH_EXT) "
                + " values('005', @strno , @strOrgCode,@date "
                + " ,@icode , ";
                if(amt !="")
                {
                    strSQL+= " @amt , ";
                }
                else
                {
                    strSQL += " NULL , ";
                }
                if (txra != "")
                {
                    strSQL += "   @txra , ";
                }
                else
                {
                    strSQL += "  NULL , ";
                }
                if (txam != "")
                {
                    strSQL += "   @txam , ";
                }
                else
                {
                    strSQL += "  NULL , ";
                }

                strSQL += " 0,0,0,0, @inco_muser," + DateTime.Now.ToString("yyyyMMddHHmmss")
                           + " ,@yymm ,@prikey, '000','000','000',0,0,0, ";
                if(amt !="")
                {
                    strSQL+= " @amt , ";
                }
                else
                {
                    strSQL += " NULL , ";
                }

                strSQL += "  0 , @Budget_code ,@inco_no, @Doc_type "
                       + " ,@rent_no , @RENT_ADDR ,@VOUCHERS"
                       + " ,@SUMMONS , ";
                if (HEALTH_EXT != "")
                {
                    strSQL+= " @HEALTH_EXT  ";
                }
                else
                {
                    strSQL += " NULL  ";
                }
        strSQL+= "  ) ";      
        
        SqlParameter[] sp =
        {
            new SqlParameter("@strno",strno),            
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@date",date),        
            new SqlParameter("@icode",icode) , 
            new SqlParameter("@amt",amt),
            new SqlParameter("@txra",txra),
            new SqlParameter("@txam",txam), 
            new SqlParameter("@inco_muser",inco_muser),
            new SqlParameter("@yymm",yymm),
            new SqlParameter("@prikey",prikey),        
            new SqlParameter("@Budget_code",Budget_code)  ,
            new SqlParameter("@inco_no",inco_no)  ,
            new SqlParameter("@Doc_type",Doc_type)  ,
            new SqlParameter("@rent_no",rent_no)  ,
            new SqlParameter("@RENT_ADDR",RENT_ADDR)  ,
            new SqlParameter("@VOUCHERS",VOUCHERS)  ,
            new SqlParameter("@SUMMONS",SUMMONS)  ,
            new SqlParameter("@HEALTH_EXT",HEALTH_EXT) 
        };

        Execute(strSQL, sp);
    }


    //get ddl2 其他薪津
    public DataTable getddlData(string orgid)
    {
        String strSQL =
          "  select item_code_type+'_'+item_code_no+'_'+item_code+'_'+item_icode as pitm_code" //-- 下拉選單代碼(多組中間以底線區隔，寫入資料庫需拆解)
         + "  , item_name" // -- 下拉選單文字內容 
         + "  from sal_saitem "
         + "  where item_orgid = @orgid"
         + "  and item_code_sys ='005'"
         + "  and item_code_kind ='D' "
         + "  and item_code_type = '001'"
         + "  and item_suspend = 'N'"
         + "  order by item_code_type, item_code_no, item_code";


        SqlParameter[] sp = { new SqlParameter("@orgid",orgid)  };

        return Query(strSQL, sp);

    }

    public DataTable querykindcodeData(string orgid
    , string inco_kind_code
    , string inco_kind_code_no)
    {
        String strSQL =
           "  select item_code_type+'_'+item_code_no+'_'+item_code+'_'+item_icode as pitm_code" //-- 下拉選單代碼(多組中間以底線區隔，寫入資料庫需拆解)
         + "  , item_name"
         + "  from sal_saitem "
         + "  where item_orgid = @orgid"
         + "  and item_code_sys ='005'"
         + "  and item_code_kind ='D' "
         + "  and item_code_type = '001'"
         + "  and item_suspend = 'N'"
         + "  and item_code_no =@inco_kind_code_no "
         + "  and item_code = @inco_kind_code ";


        SqlParameter[] sp = {
                                new SqlParameter("@orgid", orgid) ,
                             new SqlParameter("@inco_kind_code", inco_kind_code) ,
                              new SqlParameter("@inco_kind_code_no", inco_kind_code_no) 
                            };

        return Query(strSQL, sp);

    }


    public DataTable getSABASE(string orgid, string idno)
    {
        string sql = " select * from sal_sabase where base_orgid=@base_orgid and base_idno=@base_idno ";

        SqlParameter[] sp = {
        new SqlParameter ("@base_orgid",orgid ),
        new SqlParameter ("@base_idno",idno )};

        return Query(sql, sp);
    }

    public void updateSABASE(string base_orgid, string base_idno, string base_name, string base_addr, string base_type, string serviceplace, string dcodename)
    {
        string sql = " update sal_sabase set base_name=@base_name, "
            + " base_type=@base_type , base_addr=@base_addr, "
            + " BASE_SERVICE_PLACE_DESC=@serviceplace , BASE_DCODE_NAME=@dcodename, "
            + " base_muser=@base_muser, base_mdate=@base_mdate "
            + " where base_orgid=@base_orgid and base_idno=@base_idno ";

        SqlParameter[] sp = {
        new SqlParameter ("@base_orgid",base_orgid ),
        new SqlParameter ("@base_idno",base_idno ),
        new SqlParameter ("@base_name",base_name ),
        new SqlParameter ("@base_type",base_type ),
        new SqlParameter ("@base_addr",base_addr ),
        new SqlParameter ("@serviceplace",serviceplace ),
        new SqlParameter ("@dcodename",dcodename ),
        new SqlParameter ("@base_muser",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)),
        new SqlParameter ("@base_mdate",DateTime.Now.ToString("yyyyMMddHHmmss"))};

        Execute(sql, sp);
    }

    public void insertSABASE(string base_idno, string base_name, string base_addr, string base_type, string serviceplace, string dcodename)
    {
        string sql = " insert into sal_sabase(base_seqno, base_idno, base_name, "
            + "base_type, base_addr, base_orgid, base_muser,base_mdate, BASE_STATUS"
            + ",BASE_SERVICE_PLACE_DESC, BASE_DCODE_NAME )values("
            + " (Select '#' + RIGHT( '000000' + cast(isnull(max(substring(base_seqno,2,5)) ,0) + 1 as varchar),5) from sal_sabase where base_seqno like '#%' and len(base_seqno) = 6 ), "
            + " @base_idno, @base_name, @base_type, @base_addr, @base_orgid, "
            + " @base_muser, @base_mdate ,@BASE_STATUS, @serviceplace, @dcodename)";

        SqlParameter[] sp = {
        new SqlParameter ("@base_orgid",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)),
        new SqlParameter ("@base_idno",base_idno ),
        new SqlParameter ("@base_name",base_name ),
        new SqlParameter ("@base_type",base_type ),
        new SqlParameter ("@base_addr",base_addr ),
        new SqlParameter ("@serviceplace",serviceplace ),
        new SqlParameter ("@dcodename",dcodename ),
        new SqlParameter ("@base_muser",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)),
        new SqlParameter ("@base_mdate",DateTime.Now.ToString("yyyyMMddHHmmss")),
        new SqlParameter ("@BASE_STATUS","N")};

        Execute(sql, sp);
    }

    public DataTable getno(string year, string icode)
    {
        string sql = " select isnull(max(inco_no),0)+1 from sal_sainco where inco_date like @year + '%'  and inco_icode =@icode  ";

        SqlParameter[] sp = {
        new SqlParameter ("@year",year ),
        new SqlParameter ("@icode",icode )};

        return Query(sql, sp);
    }


    public DataTable gettax(string UcSaCode2, string Doc_Type, int tax, string date)
    {
        string sql = " select dbo.get_tax_otherpay( @UcSaCode2 ,@Doc_Type , @tax , @date )  ";

        SqlParameter[] sp = 
        {
        new SqlParameter ("@UcSaCode2",UcSaCode2 ),
        new SqlParameter ("@Doc_Type",Doc_Type ),
        new SqlParameter ("@tax",tax ),
        new SqlParameter ("@date",date )    
        };

        return Query(sql, sp);
    }

    public DataTable getpara(string type ,string date)
    {
        string sql = " select dbo.Get_para('006', 'P', '001', '" + type + "', @date ) ";

        SqlParameter[] sp = 
        {
        new SqlParameter ("@date",date )    
        };

        return Query(sql, sp);
    }


}