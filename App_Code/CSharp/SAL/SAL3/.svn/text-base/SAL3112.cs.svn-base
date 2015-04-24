using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3112 的摘要描述
/// </summary>
///  
namespace SALPLM.Logic
{
    public class SAL3112
    {
        private SAL3112DAO DAO;

        public SAL3112()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3112DAO();
        }

        public SAL3112(SqlConnection conn)
        {
            DAO = new SAL3112DAO(conn);
        }

        // 取得發放日期
        public DataTable queryDatePayed(
            string strOrgID,            //'登入者機關代碼'
            string strPayoKind,         //'畫面選擇發放種類代碼(code_no)'
            string strPayoYymm,         //'畫面選擇之計算年月'
            string strPayoKindCode      //'發放種類非其他薪津時為''000''，發放種類為其他薪津時，取得項目名稱之代碼'
            )
        {
            DataTable dt = DAO.queryDatePayed(strOrgID, strPayoKind, strPayoYymm, strPayoKindCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得項目類別一
        public DataTable queryItemType1(
            string strOrgID,        // '使用者登入機關代碼'
            string strPayoYymm      //'畫面選擇之計算年月'
            )
        {
            DataTable dt = DAO.queryItemType1(strOrgID, strPayoYymm);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }
         
        // 取得項目類別2
        public DataTable queryItemType2(
            string strOrgID,        // '使用者登入機關代碼'
            string strPayoYymm      //'畫面選擇之計算年月'
            , string strPayoKindCodeType //'畫面選擇項目類別一之代碼'
            )
        {
            DataTable dt = DAO.queryItemType2(strOrgID, strPayoYymm, strPayoKindCodeType);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        // 取得項目名稱
        public DataTable queryItemName(
            string strOrgID,        // '使用者登入機關代碼'
            string strPayoYymm      //'畫面選擇之計算年月'
            , string strPayoKindCodeType //'畫面選擇項目類別一之代碼'
            , string strPayoKindCodeNo // //'畫面選擇項目類別二之代碼'
            )
        {
            DataTable dt = DAO.queryItemName(strOrgID, strPayoYymm, strPayoKindCodeType, strPayoKindCodeNo);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得資料
        public DataTable queryData(
            string strOrgID,    ////'登入者機關代碼' 
            string strPayoKind, //'畫面查詢之發放種類'  
            string strPayoYymm, //'畫面查詢之計算年月'
            string strPayoDate, ////'畫面查詢之發放日期'
            string strPayoKindCodeType,//--畫面查詢之項目種類一代碼
            string strPayoKindCodeNo,//--畫面查詢之項目種類二代碼
            string strPayoKindCode,//--畫面查詢之項目名稱代碼
            string strPayoName,//員工姓名
            string strPayoSeqNo,    // 員工編號
            string strPayoProno,    // 畫面查詢之員工類別代碼
            string strBaseDep      // 畫面查詢之科室代碼'
            )
        {
            DataTable dt = DAO.queryData(strOrgID, strPayoKind, strPayoYymm, strPayoDate, strPayoKindCodeType, strPayoKindCodeNo, strPayoKindCode, strPayoName, strPayoSeqNo
                , strPayoProno, strBaseDep);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null; 
            }
            else
            {
                return dt;
            }
        }

        // 取得應發項目資料
        public DataTable querytxtData(
            string payo_orgid,    
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code          
            )
        {
            DataTable dt = DAO.querytxtData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            return dt;
             /*
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            } */
        }
        // 取得應扣項目資料
        public DataTable querytxt2Data(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code
            )
        {
            DataTable dt = DAO.querytxt2Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            return dt;
        /*    if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
         * */
        }
        // 取得機關負擔項目資料
        public DataTable querytxt3Data(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code
            )
        {
            DataTable dt = DAO.querytxt3Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            return dt;
         /*   if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            } */
        }

        // 取得應發合計
        public DataTable querytotalData(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code
            )
        {
            DataTable dt = DAO.querytotalData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得應扣合計
        public DataTable querytotal2Data(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code
            )
        {
            DataTable dt = DAO.querytotal2Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得實發數金額
        public DataTable querytotal3Data(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code
            )
        {
            DataTable dt = DAO.querytotal3Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得備註
        public DataTable querynoteData(
            string payo_orgid,
            string payo_seqno, //  
            string payo_kind, //
            string payo_yymm, //
            string payo_date,//
            string payo_kind_code_type,//
            string payo_kind_code_no,//
            string payo_kind_code,
            string payo_kind_code_sys
            )
        {
            DataTable dt = DAO.querynoteData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code, payo_kind_code_sys);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        // 勞保職業災害費率
        public DataTable getParam(
            string strOrgID           //'登入者機關代碼'           
            )
        {
            DataTable dt = DAO.getParam(strOrgID);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 勞保普通事故保費率
        public DataTable getParam2(
            string yymm               
            )
        {
            DataTable dt = DAO.getParam2(yymm);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //勞保就業保險費率
        public DataTable getParam3(
          string yymm               
          )
        {
            DataTable dt = DAO.getParam3(yymm);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //勞保保費自付比率
        public DataTable getParam4(
          string yymm
          )
        {
            DataTable dt = DAO.getParam4(yymm);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //勞保保費機關補助比率
        public DataTable getParam5(
        string yymm
        )
        {
            DataTable dt = DAO.getParam5(yymm);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public DataTable queryitem2Data(
        string payo_orgid
        )
        {
            DataTable dt = DAO.queryitem2Data(payo_orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable queryitemData(
        string payo_orgid,
        string payod_code_sys, 
        string payod_code_type,
        string payod_code_no,
        string payod_code
        )
        {
            DataTable dt = DAO.queryitemData(payo_orgid, payod_code_sys, payod_code_type, payod_code_no, payod_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable queryItem_TaxData(
         string strOrgCode,
         string strPayoKindCodeType,
         string strPayoKindCodeNo,
         string strPayoKindCode
     )
        {
            DataTable dt = DAO.queryItem_TaxData(strOrgCode, strPayoKindCodeType, strPayoKindCodeNo, strPayoKindCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

         

        public void editData(string v_amt,
            string v_mid,
            string v_datetime,
            string txtpayo_yymm,
            string txtpayo_seqno,
            string txtpayo_orgid,
            string txtpayo_kind,
            string txtpayo_date,
            string txtpayo_kind_code_type,
            string txtpayo_kind_code_no,
            string txtpayo_kind_code,
            string v_code_sys,
            string v_code_type,
            string v_code_no,
            string v_code
            )
        {
            DAO.editData(v_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code, v_code_sys, v_code_type, v_code_no, v_code);         
        }


        public void editData2(string v_add_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code     
         )
        {
            DAO.editData2(v_add_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code);
        }

        public void editData3(string v_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code,
         string v_code_sys,
         string v_code_type,
         string v_code_no,
         string v_code
         )
        {
            DAO.editData3(v_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code, v_code_sys, v_code_type, v_code_no, v_code);
        }



        public void editData4(string v_sub_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code
         )
        {
            DAO.editData4(v_sub_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code);
        }


        public void editData5(string v_tot_amt,
         string v_mid,
         string v_datetime,
         string txtpayo_yymm,
         string txtpayo_seqno,
         string txtpayo_orgid,
         string txtpayo_kind,
         string txtpayo_date,
         string txtpayo_kind_code_type,
         string txtpayo_kind_code_no,
         string txtpayo_kind_code
         )
        {
            DAO.editData5(v_tot_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code);
        }


        public void editData6(string v_amt,
           string v_mid,
           string v_datetime,
           string txtpayo_yymm,
           string txtpayo_seqno,
           string txtpayo_orgid,
           string txtpayo_kind,
           string txtpayo_date,
           string txtpayo_kind_code_type,
           string txtpayo_kind_code_no,
           string txtpayo_kind_code,
           string v_code_sys,
           string v_code_type,
           string v_code_no,
           string v_code
       )
        {
            DAO.editData6(v_amt, v_mid, v_datetime, txtpayo_yymm, txtpayo_seqno, txtpayo_orgid, txtpayo_kind, txtpayo_date
              , txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code, v_code_sys, v_code_type, v_code_no, v_code);
        }

        // 取得 房屋津貼、食物代金    
       public DataTable getData(     
       string txtpayo_kind,
       string txtpayo_kind_code_type,
       string txtpayo_kind_code_no,
       string txtpayo_kind_code,
       string txtpayo_yymm,
       string txtpayo_seqno,
       string txtpayo_orgid,
       string txtpayo_date       
         )
        {
          DataTable dt = DAO.getData(txtpayo_kind, txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code, txtpayo_yymm,
         txtpayo_seqno, txtpayo_orgid ,txtpayo_date);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

    

    public void editData7(
        string v_inco_amt,
        string v_inco_txam,
        string v_inco_real_amt,
        string v_inco_kdc,
        string v_inco_fee,
        string v_inco_fees,
        string v_inco_leave_self,
        string v_inco_leave_sup,
        string v_pen_amt,
        string v_mid,
        string v_datetime,
        string txtpayo_kind,
        string txtpayo_kind_code_type,
        string txtpayo_kind_code_no,
        string txtpayo_kind_code,
        string txtpayo_yymm,
        string txtpayo_seqno,
        string txtpayo_orgid,
        string txtpayo_date
        )
        {
            DAO.editData7(v_inco_amt, v_inco_txam, v_inco_real_amt, v_inco_kdc, v_inco_fee, v_inco_fees, v_inco_leave_self, v_inco_leave_sup
          , v_pen_amt, v_mid, v_datetime, txtpayo_kind, txtpayo_kind_code_type, txtpayo_kind_code_no, txtpayo_kind_code
          , txtpayo_yymm, txtpayo_seqno,txtpayo_orgid, txtpayo_date);
        }

    
  

      public void editData8(
       string v_adj_amt,
       string v_mid,
       string v_datetime,
       string v_adj_fee,
       string v_adj_self,
       string v_adj_sup,
       string txtpayo_yymm,
       string txtpayo_seqno,
       string txtpayo_orgid
        )
        {
            DAO.editData8(v_adj_amt, v_mid, v_datetime, v_adj_fee, v_adj_self, v_adj_sup, txtpayo_yymm
              , txtpayo_seqno, txtpayo_orgid);
        }


      public void editData9(
         string v_mid,
         string v_labor_days,
         string v_pen_days,
         string v_pen_sup_days,
         string txtpayo_orgid,
         string txtpayo_seqno,
         string txtpayo_yymm,
         string txtpayo_kind,
         string txtpayo_date
        )
      {
          DAO.editData9(v_mid, v_labor_days, v_pen_days, v_pen_sup_days, txtpayo_orgid, txtpayo_seqno, txtpayo_yymm
              , txtpayo_kind, txtpayo_date);
      }

    // 備註
      public void editData10(
      string txtpayo_kind,
      string txtpayo_seqno,
      string codesys,
      string txtpayo_kind_code_type,
      string txtpayo_kind_code_no,
      string txtpayo_kind_code,
      string txtpayo_yymm,
      string txtpayo_date,
      string txtpayo_orgid,
      string v_code_Kind,
      string txtMemo,
      string v_mid
     )
      {
          DAO.editData10(txtpayo_kind, txtpayo_seqno, codesys, txtpayo_kind_code_type, txtpayo_kind_code_no
              , txtpayo_kind_code, txtpayo_yymm, txtpayo_date, txtpayo_orgid, v_code_Kind, txtMemo, v_mid);
      }



      public DataTable getdata2(
 string strOrgCode
)
      {
          DataTable dt = DAO.getdata2(strOrgCode);
          if (dt == null || dt.Rows.Count == 0)
          {
              return null;
          }
          else
          {
              return dt;
          }
      }


      public void deleteData(
           string payo_orgid
          ,string payo_seqno
          ,string payo_kind
          ,string payo_yymm
          ,string payo_date
          ,string payo_kind_code_type
          ,string payo_kind_code_no
          ,string payo_kind_code

      )
      {
          DAO.deleteData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type, payo_kind_code_no
            , payo_kind_code );
      }







    }   

}