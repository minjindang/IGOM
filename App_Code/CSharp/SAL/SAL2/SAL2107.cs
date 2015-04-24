using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2107 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL2107
    {
        private SAL2107DAO DAO;

        public SAL2107()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL2107DAO();
        }

        public SAL2107(SqlConnection conn)
        {
            DAO = new SAL2107DAO(conn);
        }

        public DataTable queryData(
            string strPayoOrgId,    // 登入者機關代碼
            string strPayoKind,     // 查詢畫面選擇之考績種類代碼 –考績發放 
            string strPayoProno,    // 人員類別
            string strPayoYyMm,     // 查詢畫面選擇之年月
            string strPayBudgeCode // 查詢畫面選擇之預算來源代碼
            )
        {
            DataTable dt = DAO.queryData(
                strPayoOrgId,    // 登入者機關代碼
                strPayoKind,     // 查詢畫面選擇之考績種類代碼 –考績發放 
                strPayoProno,    // 人員類別
                strPayoYyMm,     // 查詢畫面選擇之年月
                strPayBudgeCode // 查詢畫面選擇之預算來源代碼
             );
            return dt;
        }
    }
}