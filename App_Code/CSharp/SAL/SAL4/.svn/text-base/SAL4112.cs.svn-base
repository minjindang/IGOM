using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4112 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4112
    {
        private SAL4112DAO DAO;

        public SAL4112()
        {
            DAO = new SAL4112DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4112(SqlConnection conn)
        {
            DAO = new SAL4112DAO(conn);
        }


        //add ym
        public DataTable queryYearData() 
        {
            DataTable dt = DAO.getYearData();
            return dt;        
        }
                

        //查詢
        public DataTable get_SaTax_sql(string ym) 
        {
            DataTable dt = DAO.get_SaTax_sql(ym);
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
        public DataTable checkdata(string ym, string low, string up)
        {
            DataTable dt = DAO.checkdata(ym, low, up);
         
            return dt;
        }


        //新增
        public void queryaddData(              
                  string ym
                , string low
                , string up
                , string tax_p0
                , string tax_p1
                , string tax_p2
                , string tax_p3
                , string tax_p4
                , string tax_p5
                , string tax_p6
                , string tax_p7
                , string tax_p8
                , string tax_p9
                , string tax_p10
                , string tax_p11
            )   
        {
            DAO.getaddData(ym, low, up, tax_p0, tax_p1, tax_p2, tax_p3, tax_p4, tax_p5, tax_p6, tax_p7, tax_p8, tax_p9,
            tax_p10, tax_p11);    
        }
         
        //修改
        public void queryeditData(
                  string ym
                , string low
                , string up
                , string p0
                , string p1
                , string p2
                , string p3
                , string p4
                , string p5
                , string p6
                , string p7
                , string p8
                , string p9
                , string p10
                , string p11
          )
        {
            DAO.geteditData(ym, low, up, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
        }


        //刪除
        public void querydeleteData(string ym
      , string v_low
      , string v_up   

          )
        {
            DAO.getdeleteData(ym, v_low, v_up );
        
        }
    


    }
}