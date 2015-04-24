using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4102 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4102
    {
        private SAL4102DAO DAO;

        public SAL4102()
        {
            DAO = new SAL4102DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4102(SqlConnection conn)
        {
            DAO = new SAL4102DAO(conn);
        }

    
        //查詢資料
        public DataTable querySearchData(string strcode_no) //畫面選擇銀行代號
        {
            DataTable dt = DAO.getSearchData(strcode_no);
     /*       if (dt == null || dt.Rows.Count == 0)
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
        public DataTable querynumData(string strcode_no) 
        {
            DataTable dt = DAO.getnumData(strcode_no);
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
        public void queryaddData(string TRNFMT_SEQ //欄位順序       
        , string TRNFMT_BANK_CODENO         //銀行代碼
        , string TRNFMT_SOURCE_TYPE      //資料形式   
        , string TRNFMT_TABLE         //資料表名稱
        , string TRNFMT_FIELD        //欄位名稱
        , string TRNFMT_ALIGN       //起始位置
        , string TRNFMT_LENGTH       //長度
        , string TRNFMT_REPLACE      //補值
        , string TRNFMT_SUBSTART     //字串起始位址
             , string TRNFMT_SUBEND   //字串位數
             , string strmuser     //登入者員工編號
            )   
        {
            DAO.getaddData(TRNFMT_SEQ, TRNFMT_BANK_CODENO, TRNFMT_SOURCE_TYPE, TRNFMT_TABLE, TRNFMT_FIELD, TRNFMT_ALIGN
            , TRNFMT_LENGTH, TRNFMT_REPLACE, TRNFMT_SUBSTART, TRNFMT_SUBEND, strmuser);                  
        }

        //維護
        public void queryeditData(string TRNFMT_SEQ //欄位順序       
        , string TRNFMT_BANK_CODENO         //銀行代碼
        , string TRNFMT_SOURCE_TYPE      //資料形式   
        , string TRNFMT_TABLE         //資料表名稱
        , string TRNFMT_FIELD        //欄位名稱
        , string TRNFMT_ALIGN       //起始位置
        , string TRNFMT_LENGTH       //長度
        , string TRNFMT_REPLACE      //補值
        , string TRNFMT_SUBSTART     //字串起始位址
             , string TRNFMT_SUBEND   //字串位數
             , string strmuser     //登入者員工編號
          )
        {
            DAO.geteditData(TRNFMT_SEQ, TRNFMT_BANK_CODENO, TRNFMT_SOURCE_TYPE, TRNFMT_TABLE, TRNFMT_FIELD, TRNFMT_ALIGN
            , TRNFMT_LENGTH, TRNFMT_REPLACE, TRNFMT_SUBSTART, TRNFMT_SUBEND, strmuser);

        }
        //刪除
        public void querydeleteData(string TRNFMT_SEQ //欄位順序    
      , string TRNFMT_BANK_CODENO         //銀行代碼 
          )
        {
            DAO.getdeleteData(TRNFMT_SEQ, TRNFMT_BANK_CODENO);          
        }
            
    }
}