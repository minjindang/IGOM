using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary> 
/// SAL3121DAO 的摘要描述
/// </summary>
public class SAL3121DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3121DAO() 
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3121DAO(SqlConnection conn)
        : base(conn)
    {

    }
 
    public DataTable querygetData(string v_orgid//登入者機關代碼        
          , string v_date   // 年月        
      )
    {
        String strSQL =   
         "select isnull(sum(inco_amt),0) as s_inco_amt, isnull(sum(inco_txam),0) as s_inco_txam from sal_sainco"
       + " where inco_orgid=@v_orgid  and ((inco_code='001'and inco_ym like @v_date+'%')or(inco_code in ('002','003','004','005','006') and inco_date like @v_date+'%')) ";


        SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid),            
            new SqlParameter("@v_date",v_date)
        };

        return Query(strSQL, sp);
    }


    public DataTable querygetData2(string v_orgid//登入者機關代碼        
        , string v_date   // 年月        
    )
    {
        String strSQL =
           "select sum(cast(substring(mediafmt_content,34,10) as numeric)) as s_media_amt,"
         + " sum(cast(substring(mediafmt_content,44,10) as numeric)) as s_media_txam"
         + " FROM sal_samediafmt,sal_sabase "
         + " where mediafmt_orgid = @v_orgid "
         + " and mediafmt_ym = @v_date "
         + " and isNumeric(substring(mediafmt_content,37,10)) = 1 "
         + " and isNumeric(substring(mediafmt_content,47,10)) = 1 "
         + " and mediafmt_seqno = base_seqno "
         + " and mediafmt_orgid = base_orgid ";

        SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid),            
            new SqlParameter("@v_date",v_date)
        };

        return Query(strSQL, sp);
    }


    public DataTable querygetData3(string v_orgid//登入者機關代碼        
      , string v_date   // 年月        
  )
    {
        v_date = v_date.Substring(0, 4);

        String strSQL =
         " select sum(cast(engf_amt as numeric)) as s_engf_amt, sum(cast(engf_txam as numeric)) as s_engf_txam "
        + " from sal_saengf where engf_orgid = @v_orgid  and engf_yy = @v_date "
        + " and engf_seqno in ("
        + " select engf_seqno "
        + " from sal_saengf where engf_orgid = @v_orgid "
        + " and engf_yy = @v_date "
        + " group by engf_seqno having sum(cast(engf_amt as int)) <= 1000 "
        + ") ";

        SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid),            
            new SqlParameter("@v_date",v_date)
        };

        return Query(strSQL, sp);
    }


    public DataTable queryData(string v_orgid//登入者機關代碼        
    , string v_date   // 年月        
    , string v_key    //選擇所得種類
    )
    {       
        String strSQL =
            "select sal_sabase.base_name,sal_sabase.base_idno,sal_sabase.base_seqno,sal_samediafmt.* "
        + " ,isnull((select code_desc1 from sys_code "
        + " where code_sys='003' and code_kind='P' and code_type='004' and code_no= mediafmt_item),'無法辨識') as form_name"
        + " FROM sal_SABASE,sal_samediafmt "
        + " where sal_sabase.base_seqno = sal_samediafmt.mediafmt_seqno "
        + " and sal_sabase.base_orgid = sal_samediafmt.mediafmt_orgid "
        + " AND sal_samediafmt.mediafmt_orgid = @v_orgid  "
        + " and mediafmt_ym = @v_date  ";

        if (v_key == "" && v_key == "000" && v_key !="ALL")
        {
            strSQL += " AND sal_samediafmt.mediafmt_item = @v_key ";
        }

        strSQL += " ORDER BY cast(isnull(base_prts,9999) as float)";

        SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid),            
            new SqlParameter("@v_date",v_date) ,
            new SqlParameter("@v_key",v_key)
        };

        return Query(strSQL, sp);
    }


    public DataTable queryData2()
    {
        String strSQL =
          "select * from sal_safmt where fmt_code_no='001' order by fmt_seqno";

        SqlParameter[] sp =
        {   
        };

        return Query(strSQL, sp);
    }


    public void queryDeleteData(string xym
            , string xit
            , string xog  
  )
    {
        String strSQL ="";
        if (xit =="ALL")
        {
            strSQL+= " delete from sal_SAMEDIAFMT where MEDIAFMT_YM = @xym and MEDIAFMT_ORGID= @xog "; 
        }
        else
        {
            strSQL += "delete from sal_SAMEDIAFMT where MEDIAFMT_YM = @xym and MEDIAFMT_ITEM= @xit and MEDIAFMT_ORGID= @xog ";
        }
        
        SqlParameter[] sp =
        {
            new SqlParameter("@xym",xym) ,
            new SqlParameter("@xit",xit) ,
            new SqlParameter("@xog",xog)  
        };

        Execute(strSQL, sp);
    }


    public DataTable queryData3(string v_key)
    {
        String strSQL =
           "select * from sys_code "
         + " where code_sys='003' "
         + " and code_kind='P' "
         + " and code_type='004' ";

        if (v_key != "000" && v_key != "ALL")
        {
           strSQL  += " and code_no = @v_key ";
        }
        strSQL += " order by cast(code_no as int)";

        SqlParameter[] sp =
        {   
        new SqlParameter("@v_key",v_key) 
        };

        return Query(strSQL, sp);
    }


    public DataTable queryexsqlData(string v_orgid, string date)
    {
        string excl_sqlstr;
        if (date.Length.ToString() == "4")
        {
            excl_sqlstr = " and engf_serial_no <> '' ";
        }
        else
        {
            excl_sqlstr = "";
        }

        String strSQL =
                "select distinct engf_form from sal_saengf " 
              +  " where engf_orgid= @v_orgid and engf_yy = @date ";

        if (excl_sqlstr !="")
        {
            strSQL+= " and engf_serial_no is not null";
        }

       strSQL+= " order by engf_form";    

        SqlParameter[] sp =
        {   
            new SqlParameter("@v_orgid",v_orgid) ,
            new SqlParameter("@date",date) 
        };

        return Query(strSQL, sp);
    }


    public DataTable queryData4(string tab, string fed, string cond, string v_orgid, string date)
    {      
          string tab2 = tab;
          String strSQL = "select ";
                
            switch (tab.ToUpper())
            {
                case "SAL_SABASE":
                    strSQL +=  " base_seqno,base_orgid,base_idno,base_name,SAL_SAENGF.*,base_type ";
                    break;
                default:
                    strSQL += " base_seqno,base_orgid,base_idno,base_name" + ","+tab+".*,base_type ";
                    break;
            }

            strSQL += " from SAL_SABASE";

            switch (tab.ToUpper())
            {
                case "SAL_SABASE":
                    strSQL += " left join SAL_SAENGF on engf_seqno = base_seqno and engf_orgid = base_orgid ";
                    break;
                case "SAL_SAUNIT":
                    strSQL += " left join SAL_SAENGF on engf_seqno = base_seqno and engf_orgid = base_orgid ";
                    strSQL += " left join " + tab + " on base_orgid=" + "UNIT_NO";
                    break;
                case "SAL_SAENGF":
                    strSQL += " left join " + tab + " on engf_seqno = base_seqno and engf_orgid = base_orgid ";
                    break;
                default:
                    strSQL += " left join SAL_SAENGF on engf_seqno = base_seqno and engf_orgid = base_orgid ";
                    strSQL += " left join " + tab + " on base_orgid=" + tab2.Substring(6) + "_ORGID";
                    break;
            }

            string excl_sqlstr;
            if (date.Length.ToString() == "4")
            {
                excl_sqlstr = " and engf_serial_no <> '' ";
            }
            else
            {
                excl_sqlstr = "";
            }

            switch (tab.ToUpper())
            {
                case "SAL_SAENGF":
                    strSQL += " where engf_form=@cond and engf_yy=@v_date and cast(engf_amt as numeric)>0 and base_orgid=@v_orgid ";
                    strSQL += excl_sqlstr;
                    strSQL += " order by base_prono,isNull(base_prts,99999),base_seqno ";
                    strSQL += ",engf_serial_no,engf_prof ";
                    break;
                case "SAL_SABASE":
                    strSQL += " where base_orgid=@v_orgid and engf_yy=@v_date and cast(engf_amt as numeric)>0 and engf_form= @cond ";
                    strSQL += excl_sqlstr;
                    strSQL += " order by base_prono,isNull(base_prts,99999),base_seqno ";
                    strSQL += ",engf_serial_no,engf_prof ";
                    break;
                default:
                    strSQL += " where base_orgid=@v_orgid and engf_yy=@v_date and cast(engf_amt as numeric)>0 and engf_form= @cond  ";
                    strSQL += excl_sqlstr;
                    strSQL += " order by base_prono,isnull(base_prts,99999),base_seqno ";
                    break;
            }        

        SqlParameter[] sp =
        {   
            new SqlParameter("@tab",tab) ,
            new SqlParameter("@fed",fed) ,
            new SqlParameter("@cond",cond) ,           
            new SqlParameter("@v_orgid",v_orgid) ,
            new SqlParameter("@v_date",date) 
        };
        return Query(strSQL, sp);  
    }


       public void queryInsert(
              string yms
            , string its
            , string ogs
            , string sqs
            , string cnts
            , string v_mid
       )
    {
        String strSQL =
            "insert into sal_samediafmt (MEDIAFMT_YM, MEDIAFMT_ITEM, MEDIAFMT_ORGID, MEDIAFMT_SEQNO, MEDIAFMT_CONTENT, MEDIAFMT_MUSER, MEDIAFMT_MDATE)"
          + " values (@yms , @its , @ogs, @sqs, @cnts, @v_mid, '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "')";
     

        SqlParameter[] sp =
           {  
                new SqlParameter("@yms",yms),
                new SqlParameter("@its",its),
                new SqlParameter("@ogs",ogs),
                new SqlParameter("@sqs",sqs),
                new SqlParameter("@cnts",cnts),
                new SqlParameter("@v_mid",v_mid)
           };

        Execute(strSQL, sp);
    }





       public DataTable queryreport(string v_orgid)
       {
           String strSQL =
                   "select * from sal_saunit where unit_no= @v_orgid ";
             
           SqlParameter[] sp =
        {   
            new SqlParameter("@v_orgid",v_orgid)       
        };

           return Query(strSQL, sp);
       }



       public DataTable queryreport2(string key)
       {
           String strSQL =
               " select * from SYS_CODE "
             + " where code_sys='003' "
             + " and code_kind='P' "
             + " and code_type='004' ";

               if (key != "000" && key !="ALL")
               {
                   strSQL += " and code_no = @key";
               }
               strSQL += " order by cast(code_no as int)";

        SqlParameter[] sp =
        {   
            new SqlParameter("@key",key)       
        };

           return Query(strSQL, sp);
       }


       public DataTable queryreport3(string v_orgid, string date, string v_key)
       {
           String strSQL =
                      " select sal_samediafmt.* "
                    + " from sal_samediafmt,sal_sabase "
                    + " where mediafmt_orgid=@v_orgid "
                    + " and mediafmt_ym= @date "
                    + " and mediafmt_item in(@v_key) "
                    + " and mediafmt_orgid=base_orgid "
                    + " and mediafmt_seqno=base_seqno"
                    + " order by mediafmt_content ";


           SqlParameter[] sp =
        {   
           new SqlParameter("@v_orgid",v_orgid)  ,   
           new SqlParameter("@date",date)  ,  
           new SqlParameter("@v_key",v_key)       
        };

           return Query(strSQL, sp);
       }



}