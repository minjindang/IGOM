using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2111 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL2111
    {
        private SAL2111DAO DAO;

        public SAL2111()
        {
            DAO = new SAL2111DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2111(SqlConnection conn)
        {
            DAO = new SAL2111DAO(conn);
        }

        public DataTable queryReportData(string strLastYM // 前一月月份 YYMM
        ,string strYM    // 當月月份
        ,string strProNO    // 臨時人員代碼
        ,string strBudgeCode    // 預算代碼
        ,string strLogDeptCD)    // 登入者機關代碼
        {
            DataTable dt=DAO.getReportData(strLastYM,strYM,strProNO,strBudgeCode,strLogDeptCD);
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