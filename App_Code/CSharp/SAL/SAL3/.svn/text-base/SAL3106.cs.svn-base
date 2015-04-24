using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3106 的摘要描述 
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3106
    {
        private SAL3106DAO DAO;

        public SAL3106()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3106DAO();
        }

        public SAL3106(SqlConnection conn)
        {
            DAO = new SAL3106DAO(conn);
        }
         

        public DataTable queryData( 
            string strOrgCode,
            string strID,      //員工編號      
            string strname,    //人員姓名    
            string strym,      //請選擇晉級前最後年月
            string stract,     //在職狀態 
            string strcno,     //員工類別    
            string RoleId,
            string strorg
            )
        {
            DataTable dt = DAO.queryData(strOrgCode, strID, strname, strym, stract, strcno, RoleId, strorg);
       
                return dt;
            
        }        


      public void querydeleteData(
      string c_promo_seqno,
      string c_promo_ym,
      string strOrgCode    
     )
      {
          DAO.querydeleteData(c_promo_seqno, c_promo_ym , strOrgCode);
      }


      public DataTable querycheckData(
       string strOrgCode,
       string strID,//員工編號
       string strname    //人員姓名  
       )
      {
          DataTable dt = DAO.querycheckData(strOrgCode, strID, strname);
          if (dt == null || dt.Rows.Count == 0)
          {
              return null;
          }
          else
          {
              return dt;
          }
      }



      public DataTable queryaddData(
       string v_Promo_Ym,
       string strOrgCode,
       string base_seqno     
       )
      {
          DataTable dt = DAO.queryaddData(v_Promo_Ym, strOrgCode, base_seqno);
          if (dt == null || dt.Rows.Count == 0)
          {
              return null;
          }
          else
          {
              return dt;
          }
      }



      public void queryInsertData(
          string v_Promo_Ym, 
          string strOrgCode,
          string base_seqno,
          string v_Promo_Start_Payym,
          string v_Promo_Stop_Payym,
          string v_Promo_muser,
          string v_Promo_Mdate,
          string v_Promo_Effect_Date
     )
      {
          DAO.queryInsertData(v_Promo_Ym, strOrgCode, base_seqno, v_Promo_Start_Payym, v_Promo_Stop_Payym, v_Promo_muser, v_Promo_Mdate, v_Promo_Effect_Date);
      }



      public DataTable queryadd2Data(
         string strOrgCode,
         string v_nowdate,
         string v_Promo_Start_Payym,
         string v_proj_code
 )
      {
          DataTable dt = DAO.queryadd2Data(strOrgCode, v_nowdate, v_Promo_Start_Payym, v_proj_code);
          if (dt == null || dt.Rows.Count == 0)
          {
              return null;
          }
          else
          {
              return dt;
          }
      }


      public void queryInsert2Data(
       string v_Promo_Ym,
       string strOrgCode,
       string v_Base_Seqno,
       string v_Promo_Start_Payym,
       string v_Promo_Stop_Payym,
       string v_Promo_muser,
       string v_Promo_Mdate,
       string v_Promo_Effect_Date
  )
      {
          DAO.queryInsertData(v_Promo_Ym, strOrgCode, v_Base_Seqno, v_Promo_Start_Payym, v_Promo_Stop_Payym
                    , v_Promo_muser, v_Promo_Mdate, v_Promo_Effect_Date);
      }



      public void queryupdateData(
      string c_promo_seqno,
      string c_promo_ym,
      string strOrgCode,
      string c_promo_start_payym,
      string c_promo_stop_payym
     )
      {
          DAO.queryupdateData(c_promo_seqno, c_promo_ym, strOrgCode, c_promo_start_payym, c_promo_stop_payym);
      }




       

    }   

}