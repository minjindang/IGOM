using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3118 的摘要描述
/// </summary>

namespace SALPLM.Logic
{ 
    public class SAL3118
    { 
        private SAL3118DAO DAO;

        public SAL3118()
        {
            DAO = new SAL3118DAO(); 
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL3118(SqlConnection conn)
        {
            DAO = new SAL3118DAO(conn);
        }

        //代扣稅額總計
        public DataTable queryReportData(string strOrgCode//登入者機關代碼
            , string strbase_dep        // 單位別　
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
            DataTable dt = DAO.getReportData(strOrgCode, strbase_dep, strcno, strAct, strname, strno, strdate1, strdate2
            , strinco_amt, strBudget_code);
            if (dt == null || dt.Rows.Count==0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        //查詢
        public DataTable querySearchData(string strOrgCode//登入者機關代碼
          , string strbase_dep        // 單位別　
          , string strcno             // 人員類別
          , string strAct             //在職狀態
          , string strname            // 員工姓名
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源       
            , string strinco_code //薪資種類
          )
        {
            DataTable dt = DAO.getSearchData(strOrgCode, strbase_dep, strcno, strAct, strname, strno, strdate1, strdate2
            , strinco_amt, strBudget_code, strinco_code);
  
            return dt;
        }


        //查詢清冊
        public DataTable queryDetailData(string strOrgCode//登入者機關代碼
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源      
            , string strinco_code //薪資種類
          )
        {
            DataTable dt = DAO.getDetailData(strOrgCode, strno, strdate1, strdate2, strinco_amt, strBudget_code, strinco_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }
        //刪除
        public void querydeleteData(string inco_prikey)
        {
            DAO.getdeleteData(inco_prikey);
        }

        //修改
        public void queryeditData(string inco_amt//申報金額
      , string inco_txam              // 扣繳稅額 
      , string inco_muser             // 員工編號
      , string inco_prikey            // Key
        
      )
        {
            DAO.editData(inco_amt, inco_txam, inco_muser, inco_prikey);   
        }

        //get key
        public DataTable querykeyData()
        {
            DataTable dt = DAO.getkeyData();

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
        public void queryaddData(string strno
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
      ,string ddl2
            , string inco_budget_code
)
        {
            DAO.addData(strno, strOrgCode, strcodeno, yymm, date, type, inco_amt, inco_txra, inco_txam, inco_muser, prikey, ddl2, inco_budget_code);
        }


        //get ddl2 其他薪津
        public DataTable queryddlData(string orgid)
        {
            DataTable dt = DAO.getddlData(orgid);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        //get ddl2 其他薪津
        public DataTable querykindcodeData(string orgid
      ,   string inco_kind_code
      , string inco_kind_code_no)
        {
            DataTable dt = DAO.querykindcodeData(orgid, inco_kind_code, inco_kind_code_no);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }




    }
}