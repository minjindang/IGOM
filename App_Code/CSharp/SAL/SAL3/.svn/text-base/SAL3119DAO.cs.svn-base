using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3119DAO 的摘要描述 
/// </summary>
public class SAL3119DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3119DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3119DAO(SqlConnection conn)
        : base(conn)
    {

    }


    public DataTable getData(string strOrgCode//登入者機關代碼
            , string date  //畫面年月
            , string cs
        )
    {
        String strSQL =
         "SELECT sal_saengf.* "
       + " ,isnull((select code_desc1 from sys_code "
       + "     where code_sys='003' and code_kind='P' and code_type='004' and code_no= engf_form),'無法辨識') as form_name   "//
       + " ,Case base_status when 'Y' then '署內' when 'N' then '署外' else '無法辨識' end base_name  "//-- 署內/署外
       + " ,isnull((select code_desc1 from sys_code "
       + "      where code_sys='002' and code_kind='P' and code_type='018' and code_no= BASE_Budget_code),'無法辨識') as budget_name   "//-- 預算來源 
       + " FROM sal_saengf, sal_sabase "
       + " WHERE engf_yy=@date "
       + " AND engf_seqno=base_seqno "
       + " AND engf_orgid=base_orgid "
       + " AND base_orgid= @strOrgCode "
       +"  order by BASE_STATUS desc, BASE_Budget_code ";
        /*     if(cs!="" && cs !="000")
             {
                 if(cs =="999")
                 {
                     strSQL +=" and base_status='N' ";
                 }
                 else
                 {
                  strSQL +=" and base_status='Y' and base_job=@cs ";
                 }
             }
            */
        //strSQL += " order by cast(isNull(base_prts,9999) as float)";

        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@date",date),          
            new SqlParameter("@cs",cs) 
        };

        return Query(strSQL, sp);
    }


    public DataTable getData2(string strOrgCode//登入者機關代碼
          , string date //畫面年月
      )
    {
        String strSQL =
          "select isnull(sum(cast(engf_amt as numeric)),0) as s_inco_amt,"
        + " isnull(sum(cast(engf_txam as numeric)),0) as s_inco_txam"
        + " from "
        + " ("
        + " select isnull(sum(cast(inco_amt as numeric)),0) as engf_amt,inco_code,"
        + " isnull(sum(cast(inco_txam as numeric)),0) as engf_txam"
        + " from sal_sainco  where inco_date like @date+'%' "
        + " and ( inco_kind_code_type<>'000' or inco_code<>'001') "
        + " and inco_orgid=@strOrgCode group by inco_code"
        + " union"
        + " select isnull(sum(cast(inco_amt as numeric)),0) as engf_amt,inco_code,"
        + " isnull(sum(cast(inco_txam as numeric)),0) as engf_txam"
        + " from sal_sainco  where inco_ym like @date+'%' "
        + " and ( inco_kind_code_type='000' and inco_code='001') "
        + " and inco_orgid=@strOrgCode group by inco_code"
        + " )as new ";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@date",date)       
    
        };

        return Query(strSQL, sp);
    }


    public DataTable getData3(string strOrgCode//登入者機關代碼
        , string date  //畫面年月
    )
    {
        String strSQL =
          " select isnull(sum(cast(engf_amt as numeric)),0) as s_engf_amt, isnull(sum(cast(engf_txam as numeric)),0) as s_engf_txam "
        + " from sal_saengf "
        + " where engf_yy=@date "
        + " and engf_orgid=@strOrgCode "
        + " and cast(isnull(ltrim(rtrim(engf_amt)),'0') as numeric) > 0";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@date",date)       
    
        };

        return Query(strSQL, sp);
    }


    public DataTable getReportData(string strOrgCode//登入者機關代碼
 )
    {
        String strSQL =
        " select * from sal_sabatengf where engf_orgid = @strOrgCode and engf_status in ('W','E')";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode)  
        };

        return Query(strSQL, sp);
    }


    public void queryInsertData(string strOrgCode//登入者機關代碼
        , string v_mid
        , string date) //畫面年月
    {
        String strSQL =
          " insert into sal_sabatengf (engf_orgid, engf_userid, engf_booktime, engf_ym, engf_starttime, engf_stoptime, engf_status, engf_msg) "
          + " values(@strOrgCode,@v_mid,'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "',@date,'','','W','') ";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode), 
            new SqlParameter("@v_mid",v_mid),
            new SqlParameter("@date",date)  
        };

        Execute(strSQL, sp);
    }



    public DataTable queryerror(string strOrgCode//登入者機關代碼
      , string date  //畫面年月
  )
    {
        String strSQL =
             "SELECT SAL_saengf.* "
           + " ,isnull((select code_desc1 from sys_code "
           + " where code_sys='003' and code_kind='P' and code_type='004' and code_no= engf_form),'無法辨識') as form_name"
           + " FROM sal_saengf, SAL_sabase "
           + " WHERE engf_yy=@date "
           + " AND engf_seqno=base_seqno "
           + " AND engf_orgid=base_orgid "
           + " AND base_orgid=@strOrgCode "
           + " and engf_amt <= 0 "
           + " order by cast(isNull(base_prts,9999) as float)";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@date",date)       
    
        };

        return Query(strSQL, sp);
    }




}