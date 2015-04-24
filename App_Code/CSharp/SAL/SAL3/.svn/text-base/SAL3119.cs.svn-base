using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3119 的摘要描述
/// </summary> 

namespace SALPLM.Logic
{ 
    public class SAL3119
    {
        private SAL3119DAO DAO;

        public SAL3119()
        {
            DAO = new SAL3119DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL3119(SqlConnection conn)
        {
            DAO = new SAL3119DAO(conn);
        }

      
        public DataTable queryData(string strOrgCode//登入者機關代碼
            , string date  //畫面年月
            , string cs  
            )  
        {
            DataTable dt = DAO.getData(strOrgCode, date, cs);
    /*        if (dt == null || dt.Rows.Count==0)
            {
                return null;
            }
            else
            {
                return dt;
            }*/
            return dt;
        }

        public DataTable queryData2(string strOrgCode//登入者機關代碼
            , string date           //畫面年月
            )
        {
            DataTable dt = DAO.getData2(strOrgCode, date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public DataTable queryData3(string strOrgCode//登入者機關代碼
         , string date  //畫面年月
         )
        {
            DataTable dt = DAO.getData3(strOrgCode, date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }


        public DataTable queryReportData(string strOrgCode)//登入者機關代碼
        {
            DataTable dt = DAO.getReportData(strOrgCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public void queryInsertData(string strOrgCode,//登入者機關代碼
            string v_mid,
            string date) //畫面年月
        {
            DAO.queryInsertData(strOrgCode, v_mid, date);  
        }


        public DataTable queryerror(string strOrgCode//登入者機關代碼
      , string date  //畫面年月
      )
        {
            DataTable dt = DAO.queryerror(strOrgCode, date);
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