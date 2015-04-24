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
public class SAL3118DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3118DAO() 
    { 
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3118DAO(SqlConnection conn)
        : base(conn)
    {

    }

    //代扣稅額總計
    public DataTable getReportData(string strOrgCode//登入者機關代碼
            , string strbase_dep        // 單位　
            , string strcno             // 人員類別
            , string strAct             //在職狀態
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
                   + " and base_status = 'Y'";
                    if(strbase_dep !="ALL")
                    {
                        strSQL += " and base_dep like @strbase_dep +'%' ";
                    }
                    if (strcno != "ALL")
                    {
                        strSQL += " and base_prono = @strcno";
                    }
                   if(strAct =="1")//--查詢之在職狀態=1,增加此條件
                   {
                       strSQL+= " and ((base_edate > ' v_Nowdate ' or base_edate is null or base_edate = '') and base_quit_date ='' ) ";
                   }
                   else if(strAct =="2")//--查詢之在職狀態=2,增加此條件
                   {
                       strSQL += " and ((base_edate <= ' v_Nowdate ' and base_edate<>'') or  base_quit_date <>'' ) ";
                   }
                    if(strno !="")
                    {
                        strSQL += "  and base_seqno=@strno ";
                    }
                    if(strname !="")
                    {
                     //   strSQL += "  and base_name like '%'+ @strname +'%'";
                        strSQL += "  and base_seqno=@strname ";
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
          , string strAct             //在職狀態
          , string strname            // 員工姓名
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源
        , string strinco_code  //薪資種類
      )
    {
        String strSQL =
                    "  select base_idno,base_seqno,base_name,base_job,base_dcode,(select Depart_name from FSC_ORG where Depart_id = base_dep and base_orgid = Orgcode ) as Depart_name"
                  + " ,isNull(base_edate,'') as base_edate,isNull(base_quit_date,'') as base_quit_date,base_status "
                  + "  ,case base_status "
                  + "   when 'Y' then isnull((select '在職員工' from sal_sabase b where b.base_seqno=sal_sabase.base_seqno and b.base_orgid=sal_sabase.base_orgid and (base_edate > ' v_Nowdate ' or base_edate is null or base_edate = '') ),'離職員工') end as status_name "
                  + "  ,(  select min(inco_date) "
                  + "  from sal_sainco inco1 "
                  + "  where inco1.inco_orgid=base_orgid "
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
                    if (strinco_code != "ALL")
                    {
                        strSQL += " and inco1.inco_code = @strinco_code";
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
                    if (strinco_code != "ALL")
                    {
                        strSQL += " and inco2.inco_code = @strinco_code";
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
                    if (strinco_code != "ALL")
                    {
                        strSQL += " and inco3.inco_code = @strinco_code";
                    }
             strSQL += "   ) as incorec"
                     + "   from sal_sabase"
                     + "   where base_orgid = @strOrgCode"
                     + "   and base_status = 'Y'"

      //ted add date is not null
                     +"and ( "
                     + "( select min(inco_date) "
                  + "  from sal_sainco inco1 "
                  + "  where inco1.inco_orgid=base_orgid "
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
         if (strBudget_code != "ALL")
         {
             strSQL += " and inco1.INCO_Budget_code = @strBudget_code";
         }
         if (strinco_code != "ALL")
         {
             strSQL += " and inco1.inco_code = @strinco_code";
         }
           strSQL  += "  ) is not null or "
                   + " ( select max(inco_date) "
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
                    if (strinco_code != "ALL")
                    {
                        strSQL += " and inco2.inco_code = @strinco_code";
                    }
                    strSQL += "  ) is not null )"; // end----



                if(strbase_dep !="ALL")
                {
                    strSQL += "  and base_dep like @strbase_dep + '%' ";
                }
                if (strcno != "ALL")
                {
                    strSQL += "  and base_prono = @strcno";
                }
                if (strAct == "1")//--查詢之在職狀態=1,增加此條件
                {
                    strSQL += " and ((base_edate > ' v_Nowdate ' or base_edate is null or base_edate = '') and base_quit_date ='' )";
                }
                else if (strAct == "2")//--查詢之在職狀態=2,增加此條件
                {
                    strSQL += " and ((base_edate <= ' v_Nowdate ' and base_edate<>'') or  base_quit_date <>'' )";
                }
                if(strno!="")
                {
                    strSQL += "   and base_seqno=@strno ";
                }
                if (strname != "")
                {
                    strSQL += "   and base_seqno=@strname ";
            //        strSQL += "   and base_name like '%'+ @strname +'%'";
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
            new SqlParameter("@strBudget_code",strBudget_code) ,
              new SqlParameter("@strinco_code",strinco_code)         
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
        , string strinco_code //薪資種類
      )
    {
        String strSQL =
                      "  select inco_code "//-- 發放種類，需要代碼轉文字app.GetSaCode_Desc1("003","005",inco_code)"
                    + ",inco_kind_code "// – 發放種類為005(其他薪津時，需要呈現的項目代碼)"
                    + ",inco_kind_code_no "// – 發放種類為005(其他薪津時，需要呈現的項目代碼)"
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
        if(strinco_code !="ALL")
        {
         strSQL += " and inco_code = @strinco_code";
        }

        strSQL += " order by inco_code,inco_kind_code,inco_date desc";

        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),            
            new SqlParameter("@strno",strno),  
            new SqlParameter("@strdate1",strdate1),        
            new SqlParameter("@strdate2",strdate2),         
            new SqlParameter("@strBudget_code",strBudget_code) , 
            new SqlParameter("@strinco_code",strinco_code)
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
      , string strcodeno
      , string yymm
      , string date
      , string type
      , string inco_amt
      , string inco_txra
      , string inco_txam
      , string inco_muser
      , string prikey
      , string ddl2
      , string inco_budget_code
  )
    {   
        String strSQL =
                  " insert into sal_sainco (inco_budget_code,inco_seqno, inco_orgid, inco_code"
                + " , inco_ym, inco_date, inco_icode"
                + " , inco_amt, inco_real_amt, inco_txra"
                + " , inco_txam, inco_fee,inco_fees"
                + " , inco_leave_self, inco_leave_sup, "
                + "  inco_muser, inco_mdate, inco_prikey"
                + " , inco_kind_code_type"
                + " , inco_kind_code_no"
                + " , inco_kind_code ) "
                + " values(@inco_budget_code,@strno,@strOrgCode,@strcodeno"
                + " ,@yymm,@date,@type"
                + " ,@inco_amt, @inco_amt,@inco_txra,@inco_txam,0,0"
                + " ,0,0,@inco_muser"
                + " ," + DateTime.Now.ToString("yyyyMMddHHmmss") + ", @prikey";

        if (ddl2 == "000")  //所得項目二代碼，非其他薪津填(000)
        {
            strSQL +=
                " , @ddl2"
              + " , @ddl2"
              + " , @ddl2"
              + "  )";
        }
        else 
        {
            string[] oArray = ddl2.Split('_'); //分解字串 有三段

            strSQL +=
              " , '" + oArray[0].ToString()
            + "' , '" + oArray[1].ToString()
            + "' , '" + oArray[2].ToString()
            + "'  )";

//            type = oArray[3].ToString();
        }
        
        SqlParameter[] sp =
        {
            new SqlParameter("@strno",strno),            
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@strcodeno",strcodeno),        
            new SqlParameter("@yymm",yymm) , 
            new SqlParameter("@date",date),            
            new SqlParameter("@type",type),  
            new SqlParameter("@inco_amt",inco_amt),     
            new SqlParameter("@inco_txra",inco_txra),      
            new SqlParameter("@inco_txam",inco_txam),      
            new SqlParameter("@inco_muser",inco_muser) , 
            new SqlParameter("@prikey",prikey),        
            new SqlParameter("@ddl2",ddl2)  ,
            new SqlParameter("@inco_budget_code",inco_budget_code)  
        };

        Execute(strSQL, sp);
    }


    //get ddl2 其他薪津
    public DataTable getddlData(string orgid)
    {
        String strSQL =
           " select  isnull (item_code_type, '')+'_'+isnull (item_code_no, '') +'_'+isnull (item_code, '')  +'_'+isnull (item_icode, '001') as pitm_code" //-- 下拉選單代碼(多組中間以底線區隔，寫入資料庫需拆解)
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
           "  select " 
         + "   item_name"
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




}