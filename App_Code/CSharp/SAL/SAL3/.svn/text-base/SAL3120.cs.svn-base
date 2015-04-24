using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3120 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{

    public class SAL3120
    {
        private SAL3120DAO DAO;
        public SAL3120()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3120DAO();

        }

        public SAL3120(SqlConnection conn)
        {
            DAO = new SAL3120DAO(conn);
        }

    // 取得資料
        public DataTable getData(
            string strOrgCode
            )
        {
            DataTable dt = DAO.getData(strOrgCode);
            return dt;
        }
    }
}