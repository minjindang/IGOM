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
    public class SAL3128
    {
        private SAL3128DAO DAO;

        public SAL3128()
        {
            DAO = new SAL3128DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL3128(SqlConnection conn)
        {
            DAO = new SAL3128DAO(conn);
        }

        //代扣稅額總計
        public DataTable queryReportData(string strOrgCode//登入者機關代碼
            , string strbase_dep        // 單位別　
            , string strcno             // 人員類別
            , string strname            // 員工姓名
            , string strno              // 員工編號 
            , string strdate1           // 給付起日
            , string strdate2           // 給付迄日
            , string strinco_amt        //所得申報
            , string strBudget_code     // 預算來源                
            )  
        {
            DataTable dt = DAO.getReportData(strOrgCode, strbase_dep, strcno, strname, strno, strdate1, strdate2
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
          , string strname            // 員工姓名
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源                
          )
        {
            DataTable dt = DAO.getSearchData(strOrgCode, strbase_dep, strcno, strname, strno, strdate1, strdate2
            , strinco_amt, strBudget_code);
 
            return dt;
        }


        //查詢清冊
        public DataTable queryDetailData(string strOrgCode//登入者機關代碼
          , string strno              // 員工編號 
          , string strdate1           // 給付起日
          , string strdate2           // 給付迄日
          , string strinco_amt        //所得申報
          , string strBudget_code     // 預算來源                
          )
        {
            DataTable dt = DAO.getDetailData(strOrgCode, strno, strdate1, strdate2, strinco_amt, strBudget_code);
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
            ,string strOrgCode
            ,string date
            ,string icode
            ,string amt
            ,string txra
            ,string txam
            ,string inco_muser
            ,string yymm
            ,string prikey
            ,string Budget_code
            ,string inco_no
            ,string Doc_type
            ,string rent_no
            ,string RENT_ADDR
            ,string VOUCHERS
            ,string SUMMONS
            , string HEALTH_EXT
)
        {
            DAO.addData(strno, strOrgCode, date, icode, amt, txra, txam, inco_muser, yymm, prikey, Budget_code,
                         inco_no, Doc_type, rent_no, RENT_ADDR, VOUCHERS, SUMMONS, HEALTH_EXT);
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
      , string inco_kind_code
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


        public DataTable getSABASE(string orgid, string idno)
        {
            return DAO.getSABASE(orgid, idno);
        }

        public void updateSABASE(string base_orgid, string base_idno, string base_name, string base_addr, string base_type, string serviceplace, string dcodename)
        {
            DAO.updateSABASE(base_orgid, base_idno, base_name, base_addr, base_type, serviceplace, dcodename);
        }

        public void insertSABASE(string base_idno, string base_name, string base_addr, string base_type, string serviceplace, string dcodename)
        {
            DAO.insertSABASE(base_idno, base_name, base_addr, base_type, serviceplace, dcodename);
        }

        public DataTable getno(string year, string icode)
        {
            return DAO.getno(year, icode);
        }

        public DataTable gettax(string UcSaCode2, string Doc_Type, int tax, string date)
        {
            return DAO.gettax(UcSaCode2, Doc_Type, tax, date);
        }

        public DataTable getpara(string type, string date)
        {
            return DAO.getpara(type,date);
        }



    }
}