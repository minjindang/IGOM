using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4109 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4109 
    {
        private SAL4109DAO DAO;

        public SAL4109()
        {
            DAO = new SAL4109DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4109(SqlConnection conn)
        {
            DAO = new SAL4109DAO(conn);
        }


        //add ym
        public DataTable queryYearData(string type,string no) 
        {
            DataTable dt = DAO.getYearData(type,no);
            return dt;        
        }
                

        //查詢
        public DataTable get_sastan_sql(string ym, string type, string no) 
        {
            DataTable dt = DAO.get_sastan_sql(ym, type, no);
   /*         if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
    * */
            return dt;
        }

        //檢查
        public DataTable checkData(
                  string ym
                , string Series
                , string SAL
                , string type
                , string no

            )
        {
          DataTable dt=  DAO.checkData(ym, Series, SAL, type, no);
            return dt;
        }



        //新增
        public void queryaddData(              
                  string ym
                , string Series
                , string SAL
                , string type
                , string no
                , string Muser
                , string Mdate    
            )   
        {
            DAO.getaddData(ym, Series, SAL, type, no, Muser, Mdate);          
        }
         
        //修改
        public void queryeditData(
                  string ym
                , string Series
                , string SAL
                , string type
                , string no
                , string Muser
                , string Mdate    
          )
        {
            DAO.geteditData(ym, Series, SAL, type, no, Muser, Mdate);
        }


        //刪除
        public void querydeleteData(string ym 
      , string type         
      , string no   
      , string v_series
          )
        {
            DAO.getdeleteData(ym, type, no,v_series);
        
        }
    


    }
}