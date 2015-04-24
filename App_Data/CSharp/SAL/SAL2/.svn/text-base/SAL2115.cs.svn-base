using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2115 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL2115
    {
        private SAL2115DAO DAO;

        public SAL2115()
        {
            DAO = new SAL2115DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2115(SqlConnection conn)
        {
            DAO = new SAL2115DAO(conn);
        }
        public DataTable queryReportData(string strYear //年份
        ,string strMonth         // 月份       
        , string strUnit         //單位別
        , string strName         //員工姓名
        , string strtype         //人員類別
        , string strNum          //員工編號   
        ,string strLogDeptCD)    // 登入者機關代碼
        {
            DataTable dt = DAO.getReportData(strYear, strMonth, strUnit, strName, strtype, strNum,strLogDeptCD);
            if (dt == null || dt.Rows.Count==0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable queryReportData2(string strYear //年份
     , string strMonth         // 月份   
     , string strLogDeptCD    // 登入者機關代碼
     , string BASE_SEQNO   //列印之人員
            )  
        {
            DataTable dt = DAO.getReportData2(strYear, strMonth, strLogDeptCD, BASE_SEQNO);
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