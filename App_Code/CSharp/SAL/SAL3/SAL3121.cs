using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary> 
/// SAL3121 的摘要描述
/// </summary>

namespace SALPLM.Logic 
{
    public class SAL3121
    {
        private SAL3121DAO DAO;

        public SAL3121()
        {
            DAO = new SAL3121DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL3121(SqlConnection conn)
        {
            DAO = new SAL3121DAO(conn);
        }   

        
        public DataTable querygetData(string strOrgCode//登入者機關代碼
          , string v_date        // 年月             
          )
        {
            DataTable dt = DAO.querygetData(strOrgCode, v_date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public DataTable querygetData2(string strOrgCode//登入者機關代碼
       , string v_date        // 年月             
       )
        {
            DataTable dt = DAO.querygetData2(strOrgCode, v_date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public DataTable querygetData3(string strOrgCode//登入者機關代碼
          , string v_date        // 年月             
         )
        {
            DataTable dt = DAO.querygetData3(strOrgCode, v_date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }


        public DataTable queryData(string strOrgCode//登入者機關代碼
       , string v_date        // 年月     
       , string v_key         //選擇所得種類
      )
        {
            DataTable dt = DAO.queryData(strOrgCode, v_date, v_key);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public DataTable queryData2()
        {
            DataTable dt = DAO.queryData2();
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }
        

        public void queryDeleteData(string xym
            , string xit
            , string xog  
)
        {
            DAO.queryDeleteData(xym, xit, xog);
        }


        public DataTable queryData3(string v_key)
        {
            DataTable dt = DAO.queryData3(v_key);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public DataTable queryexsqlData(string v_orgid, string date)
        {
            DataTable dt = DAO.queryexsqlData(v_orgid, date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public DataTable queryData4(string tab,string fed,string cond,string v_orgid, string date)
        {
            DataTable dt = DAO.queryData4(tab, fed, cond, v_orgid, date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }
      
        public void queryInsert(string yms
            , string its
            , string ogs
            , string sqs
            , string cnts
            ,string v_mid)
        {
            DAO.queryInsert(yms, its, ogs, sqs, cnts, v_mid);
        }



        public DataTable queryreport(string v_orgid)
        {
            DataTable dt = DAO.queryreport(v_orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable queryreport2(string key)
        {
            DataTable dt = DAO.queryreport2(key);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable queryreport3(string v_orgid,string date,string v_key)
        {
            DataTable dt = DAO.queryreport3(v_orgid, date, v_key);
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