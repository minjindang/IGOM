using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4101 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4101 
    {
        private SAL4101DAO DAO;

        public SAL4101()
        {
            DAO = new SAL4101DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4101(SqlConnection conn)
        {
            DAO = new SAL4101DAO(conn);
        }

        public DataTable queryYearData(string strStwsType)
        {
            DataTable dt = DAO.getYearData(strStwsType);
            return dt;
            /*
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
             * */
        }
        //查詢資料
        public DataTable querySearchData(string strYear, string strno) //畫面之年月
        {
            DataTable dt = DAO.getSearchData(strYear, strno);
      /*      if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }*/
            return dt;
        }

        public void queryaddData(
          string stws_ym //年月
        , string stws_level      // 畫面輸入之投保金額等級   
        , string stws_up         //畫面輸入之月薪資所得上限
        , string stws_low        //畫面輸入之月薪資所得下限
        , string stws_dct1       //1日(投保日數)自負擔金額
        , string stws_dct2       //30日(投保日數)自負擔金額
        , string stws_muser      //登入者員工編號
        , string stws_type  // 保險種類
        , string STWS_DCT   // 自負擔
        , string STWS_SUP   // 機關負擔    
        , string strstws_stand //保險金額
            )   
        {
            DAO.getaddData(stws_ym, stws_level, stws_up, stws_low, stws_dct1, stws_dct2, stws_muser
            , stws_type, STWS_DCT, STWS_SUP, strstws_stand
                );
            /*
            if (dt == null || dt.Rows.Count==0)
            {
                return null;
            }
            else
            {
                return dt;
            }
             * */
        }
         
        public void queryeditData(string stws_ym //年月
      , string stws_no         // 表別
      , string stws_level      // 畫面輸入之投保金額等級   
      , string stws_up         //畫面輸入之月薪資所得上限
      , string stws_low        //畫面輸入之月薪資所得下限
      , string stws_dct1       //1日(投保日數)自負擔金額
      , string stws_dct2       //30日(投保日數)自負擔金額
      , string stws_muser      //登入者員工編號 
        , string strstws_stand //保險金額
        , string STWS_DCT   // 自負擔
        , string STWS_SUP   // 機關負擔    
       
          )
        {
            DAO.geteditData(stws_ym, stws_no, stws_level, stws_up, stws_low, stws_dct1, stws_dct2, stws_muser
                , strstws_stand, STWS_DCT, STWS_SUP);
/*
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
 */ 
        }

        public void querydeleteData(string stws_ym //年月
      , string stws_no         
      , string stws_level      // 畫面輸入之投保金額等級
          )
        {
            DAO.getdeleteData(stws_ym, stws_no, stws_level);
            /*
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
             */
        }
    


    }
}