using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2106 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL2106
    {
        private SAL2106DAO DAO;

        public SAL2106()
        {
            DAO = new SAL2106DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2106(SqlConnection conn)
        {
            DAO = new SAL2106DAO(conn);
        }

        //銀行項目清單
        public DataTable querySearchData(string strOrgCode)//登入者機關代碼
        {
            DataTable dt = DAO.getSearchData(strOrgCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }
        //用銀行代碼查銀行名稱與代號
        public DataTable getbankname(string tdpf_seqno, string strOrgCode)
        {
            DataTable dt = DAO.getbankname(tdpf_seqno,strOrgCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //匯出
        public DataTable queryReportData(
            string strOrgCode   //登入者機關代碼
            , string strtype     //單位別
            , string strname     //員工姓名
            , string strstatus    //在職狀態
            , string strcno        //人員類別
            , string strno       //員工編號
            , string strbank  //選取的銀行項目
            )
        {
            DataTable dt = DAO.getReportData(strOrgCode, strtype, strname, strstatus, strcno, strno, strbank);
            if (dt == null || dt.Rows.Count==0)
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