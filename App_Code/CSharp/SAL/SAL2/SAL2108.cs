using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2108 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL2108
    {
        private SAL2108DAO DAO;

        public SAL2108()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL2108DAO();
        }

        public SAL2108(SqlConnection conn)
        {
            DAO = new SAL2108DAO(conn);
        }

        public DataTable queryData(
            string strPayoOrgId,    // 登入者機關代碼
            string strPayoProno,    // 人員類別
            string strPayoYyMm,     // 查詢畫面選擇之年月
            string strPayBudgeCode // 查詢畫面選擇之預算來源代碼
            )
        {
            DataTable dt = DAO.queryData(
                strPayoOrgId,    // 登入者機關代碼
                strPayoProno,    // 人員類別
                strPayoYyMm,     // 查詢畫面選擇之年月
                strPayBudgeCode // 查詢畫面選擇之預算來源代碼
             );
            return dt;
        }
    }
}