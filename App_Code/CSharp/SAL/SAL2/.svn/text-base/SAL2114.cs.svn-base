using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2114 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL2114
    {
        private SAL2114DAO DAO;

        public SAL2114()
        {
            DAO = new SAL2114DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2114(SqlConnection conn)
        {
            DAO = new SAL2114DAO(conn);
        }

        public DataTable queryReportData(string strYear //年份
        ,string strMonth        // 月份
        ,int strSort            // 排序   
        ,string strLogDeptCD)   // 登入者機關代碼
        {
            DataTable dt = DAO.getReportData(strYear, strMonth, strSort, strLogDeptCD);
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