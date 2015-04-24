using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4113 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4113
    {
        private SAL4113DAO DAO;

        public SAL4113()
        {
            DAO = new SAL4113DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4113(SqlConnection conn)
        {
            DAO = new SAL4113DAO(conn);
        }

                

        //查詢
        public DataTable get_data(string Code_no) 
        {
            DataTable dt = DAO.get_data(Code_no);
  /*          if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
   */
            return dt;
        }



        //新增
        public void queryaddData(              
                  string ym
                , string sys
                , string kind
                , string type
                , string no
                , string VALUE
                , string Muser
                , string Mdate
            )   
        {
            DAO.getaddData(ym, sys, kind, type, no, VALUE, Muser, Mdate);    
        }

         
        //修改
        public void queryeditData(
                  string ym
                , string sys
                , string kind
                , string type
                , string no
                , string VALUE
                , string Muser
                , string Mdate
          )
        {
            DAO.geteditData(ym, sys, kind, type, no, VALUE, Muser, Mdate);
        }
                    
    


    }
}