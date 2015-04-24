using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2112 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL2112
    {
        private SAL2112DAO DAO;

        public SAL2112()
        {
            DAO = new SAL2112DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2112(SqlConnection conn)
        {
            DAO = new SAL2112DAO(conn);
        }

        public DataTable queryReportData(string strbase_dep // 單位別　
        , string strmane            // 員工姓名
        , string strBASE_SEX        // 姓別
        , string strcno             // 人員類別
        , string strno              // 員工編號
        , string strdate1           // 發放日期
        , string strdate2           // 發放日期
        , string strBudget_code     // 預算來源
        , string strnum             //所得流水號
            )  
        {
            DataTable dt = DAO.getReportData(strbase_dep, strmane, strBASE_SEX, strcno, strno, strdate1, strdate2, strBudget_code, strnum);
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