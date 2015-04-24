using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4103 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4103
    {
        private SAL4103DAO DAO;

        public SAL4103()
        {
            DAO = new SAL4103DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4103(SqlConnection conn)
        {
            DAO = new SAL4103DAO(conn);
        }

    
        //查詢資料 
        public DataTable querySearchData() 
        {
            DataTable dt = DAO.getSearchData();
      /*      if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
       */
            return dt;
        }
       


        //查欄位順序
        public DataTable queryseqData() 
        {
            DataTable dt = DAO.getseqData();
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


       
        //新增
        public void queryaddData(string fmt_seqno //序號    
        , string fmt_code_no         //固定值
        , string fmt_type      //欄位種類 
        , string fmt_format         //資料表名稱
        , string fmt_setting        //欄位名稱
        , string fmt_rule       //欄位規則
        , string fmt_align       //起始位址
        , string fmt_rep      //補值
        , string fmt_length     //長度
             , string fmt_start   //字串起始位址
             , string fmt_num     //字串位數
              , string fmt_muser     //登入者員工編號
            )   
        {
            DAO.getaddData(fmt_seqno, fmt_code_no, fmt_type, fmt_format, fmt_setting, fmt_rule,
            fmt_align, fmt_rep, fmt_length, fmt_start, fmt_num, fmt_muser);
                  
        }
     
        //維護
        public void queryeditData(        
         string fmt_type      //欄位種類 
        , string fmt_format         //資料表名稱
        , string fmt_setting        //欄位名稱
        , string fmt_rule       //欄位規則
        , string fmt_align       //起始位址
        , string fmt_rep      //補值
        , string fmt_length     //長度  
        , string fmt_start   //字串起始位址
        , string fmt_num     //字串位數                  
        , string fmt_muser     //登入者員工編號
        ,string fmt_seqno //序號  
          )
        {
            DAO.geteditData(fmt_type, fmt_format, fmt_setting, fmt_rule, fmt_align, fmt_rep,
            fmt_length, fmt_start, fmt_num, fmt_muser, fmt_seqno);

        }

        //刪除
        public void querydeleteData(string fmt_seqno //序號
            )
        {
            DAO.getdeleteData(fmt_seqno); 
        }
    


    }
}