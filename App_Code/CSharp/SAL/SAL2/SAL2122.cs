using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL2122
    {
        private SAL2122DAO DAO;

        public SAL2122()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL2122DAO();
        }

        public SAL2122(SqlConnection conn)
        {
            DAO = new SAL2122DAO(conn);
        }

        public DataTable queryData(
            string ym1,    // 起日
            string ym2,     // 迄日
            string strPayBudgeCode // 查詢畫面選擇之預算來源代碼
            )
        {
            DataTable dt = DAO.queryData(
                ym1,    //起日
                ym2,     // 迄日
                strPayBudgeCode // 查詢畫面選擇之預算來源代碼
             );
            return dt;
        }
    }
}