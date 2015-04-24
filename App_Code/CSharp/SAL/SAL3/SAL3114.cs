using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3114 的摘要描述
/// SAL3114 基本薪資發放轉帳
/// Eliot Chen
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3114
    {
        private SAL3114DAO DAO;
        public SAL3114()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3114DAO();
        }


        public SAL3114(SqlConnection conn)
        {
            DAO = new SAL3114DAO(conn);
        }

        // 查詢其他薪津項目
        public DataTable querySalSaitem(
            string strOrgID, // 機關代碼
            string strPAYOKIND, ////'畫面選擇之發放種類'
            string strPAYOYYMM//'畫面選擇之薪資年月'
            )
        {
            DataTable dt = DAO.querySalSaitem(strOrgID, strPAYOKIND, strPAYOYYMM);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //帶出可選擇之批號
        public DataTable queryPayItemGroup
        (
          /*  string strOrgID, // 機關代碼
            string strPAYITEMCODE,  // 勾選其他薪津項目代碼
            string strPayed    // 否已轉帳        */
            string strPAYITEMCODE,
            string cmb_uc_calitem,
            string cmbYearMonth,
            string strPayed
            )
        {
  //          DataTable dt = DAO.queryPayItemGroup(strOrgID, strPAYITEMCODE, strPayed);
            DataTable dt = DAO.queryPayItemGroup(strPAYITEMCODE, cmb_uc_calitem, cmbYearMonth, strPayed);  
    
            return dt;
        }

        // 取 PAYITEM_MERGE_FLOW_ID 的明細資料
        public DataTable queryPayItemDetail(
    //        string strOrgID, // 機關代碼
            string strPAYITEMMergeflowid  // 點選資料之批號
            )
        {
            DataTable dt = DAO.queryPayItemDetail( strPAYITEMMergeflowid);
    /*        if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
             
            }
            */   
            return dt;
        }

        // 新增批次轉檔資料
        public void insertSaBatTrn(
                string strTRNORGID,// = 使用者機關代號
                string strTRN_USERID,// = 使用者員工編號
            //            string strTRN_BOOKTIME,// = yyyyMMddHHmmss(現在時間)
                string strTRN_YM,// = 畫面選擇薪資年月
                string strTRN_DATE,// = 畫面選擇薪資日期
                string strTRN_KIND,// = 畫面選擇發放種類
                string strTRN_CODE_SYS,//= 畫面選擇發放種類的第二層代碼(第一組)
                string strTRN_CODE_KIND,//= 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
                string strTRN_CODE_TYPE,//= 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
                string strTRN_CODE_NO,//= 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
                string strTRN_CODE,//=畫面選擇發放種類的第二層代碼(第五組，以底線區分)
                string strTRNNSTRING // = 當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null
        )
        {
            DAO.insertSaBatTrn(
                strTRNORGID,// = 使用者機關代號
                strTRN_USERID,// = 使用者員工編號
                strTRN_YM,// = 畫面選擇薪資年月
                strTRN_DATE,// = 畫面選擇薪資日期
                strTRN_KIND,// = 畫面選擇發放種類
                strTRN_CODE_SYS,//= 畫面選擇發放種類的第二層代碼(第一組)
                strTRN_CODE_KIND,//= 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
                strTRN_CODE_TYPE,//= 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
                strTRN_CODE_NO,//= 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
                strTRN_CODE,//=畫面選擇發放種類的第二層代碼(第五組，以底線區分)
                strTRNNSTRING
                );
        }

        // 更新 SAL_SAPAYO
        public void updateSaPayO
            (
            string strPAYODATE, //'20140321' --'畫面上選擇日期'
            string strPAYOORGID,//'登入者機關代碼'
            string strPAYOKIND, //'畫面選擇之發放種類'
            string strPAYOYYMM, //'畫面選擇之發放年月'
            string strPAYOMergeflowid// '畫面勾選之批號'
            )
        {
            DAO.updateSaPayO
                (
                strPAYODATE, //'20140321' --'畫面上選擇日期'
            strPAYOORGID,//'登入者機關代碼'
            strPAYOKIND, //'畫面選擇之發放種類'
            strPAYOYYMM, //'畫面選擇之發放年月'
            strPAYOMergeflowid// '畫面勾選之批號'
            );

        }

        // 更新 SAL_SAPAYO
        public void updateSaPayOD
            (
             string strPAYODATE, //'20140321' --'畫面上選擇日期'
            string strPAYOORGID,//'登入者機關代碼'
            string strPAYOKIND, //'畫面選擇之發放種類'
            string strPAYOYYMM, //'畫面選擇之發放年月'
            string strPAYOMergeflowid// '畫面勾選之批號'
            )
        {
            DAO.updateSaPayOD
                (
                strPAYODATE, //'20140321' --'畫面上選擇日期'
                strPAYOORGID,//'登入者機關代碼'
                strPAYOKIND, //'畫面選擇之發放種類'
                strPAYOYYMM, //'畫面選擇之發放年月'
                strPAYOMergeflowid// '畫面勾選之批號'
            );
        }

        // 更新 SAL_SAPAYO
        public void updateSaInco
            (
             string strPAYODATE, //'20140321' --'畫面上選擇日期'
             string strPAYOORGID,//'登入者機關代碼'
             string strPAYOKIND, //'畫面選擇之發放種類'
             string strPAYOYYMM, //'畫面選擇之發放年月'
             string strPAYOMergeflowid// '畫面勾選之批號'
            )
        {
            DAO.updateSaInco
                (
                strPAYODATE, //'20140321' --'畫面上選擇日期'
                strPAYOORGID,//'登入者機關代碼'
                strPAYOKIND, //'畫面選擇之發放種類'
                strPAYOYYMM, //'畫面選擇之發放年月'
                strPAYOMergeflowid// '畫面勾選之批號'
            );
        }



        // 更新 SAL_SAPAYO
        public void updateSaPayO2
            (
            string strPAYODATE, //原來日期
            string strPAYOORGID,//'登入者機關代碼'
            string strPAYOKIND, //'畫面選擇之發放種類'
            string strPAYOYYMM, //'畫面選擇之發放年月'
            string strPAYOMergeflowid// '畫面勾選之批號'
            ,string newdate //修改日期
            )
        {
            DAO.updateSaPayO2
                (
                strPAYODATE,  //原來日期
            strPAYOORGID,//'登入者機關代碼'
            strPAYOKIND, //'畫面選擇之發放種類'
            strPAYOYYMM, //'畫面選擇之發放年月'
            strPAYOMergeflowid// '畫面勾選之批號'
            , newdate//修改日期
            );

        }

        // 更新 SAL_SAPAYO
        public void updateSaPayOD2
            (
             string strPAYODATE, //原來日期
            string strPAYOORGID,//'登入者機關代碼'
            string strPAYOKIND, //'畫面選擇之發放種類'
            string strPAYOYYMM, //'畫面選擇之發放年月'
            string strPAYOMergeflowid// '畫面勾選之批號'
            , string newdate//修改日期
            )
        {
            DAO.updateSaPayOD2
                (
                strPAYODATE, //'原來日期
                strPAYOORGID,//'登入者機關代碼'
                strPAYOKIND, //'畫面選擇之發放種類'
                strPAYOYYMM, //'畫面選擇之發放年月'
                strPAYOMergeflowid// '畫面勾選之批號'
                , newdate//修改日期
            );
        }

        // 更新 SAL_SAPAYO
        public void updateSaInco2
            (
             string strPAYODATE, //原來日期
             string strPAYOORGID,//'登入者機關代碼'
             string strPAYOKIND, //'畫面選擇之發放種類'
             string strPAYOYYMM, //'畫面選擇之發放年月'
             string strPAYOMergeflowid// '畫面勾選之批號'
             , string newdate//修改日期
            )
        {
            DAO.updateSaInco2
                (
                strPAYODATE, //原來日期
                strPAYOORGID,//'登入者機關代碼'
                strPAYOKIND, //'畫面選擇之發放種類'
                strPAYOYYMM, //'畫面選擇之發放年月'
                strPAYOMergeflowid// '畫面勾選之批號'
                , newdate//修改日期
            );
        }




        public DataTable queryPayItemsDropDown
            (
            string strOrgID,
            string strKind,//-- 發放種類
            string strYYMM
            )
        {
            return DAO.queryPayItemsDropDown(strOrgID, strKind, strYYMM);
        }


        public DataTable querySalBatTrns(
            string strOrgID,//'使用者登入之機關代號'
            string strKind,//'畫面選擇之發放種類'
            string strYYMM//'畫面選擇之發放年月'
            )
        {
            return DAO.querySalBatTrns(strOrgID, strKind, strYYMM);
        }

   public DataTable queryStep2Data
    (
    string strOrgID,
    string strTrnDataYm,
    string strTrnDataKind,
    string strTrnDataCodeSys,
    string strTrnDataCodeType,
    string strTrnDataCodeNo,
    string strTrnDataCode,
    string strPayDate,
       string p_payod_str ,
       string unit_multi_monthpay
    )
        {

            DataTable dt = DAO.queryStep2Data(strOrgID, strTrnDataYm, strTrnDataKind, strTrnDataCodeSys, strTrnDataCodeType, strTrnDataCodeNo, strTrnDataCode);
            dt.Columns.Add("bank_bank_no");
            dt.Columns.Add("payod_amt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["bank_bank_no"] = getSaBand
                    (strOrgID,
                    dt.Rows[i]["base_seqno"].ToString(),
                    dt.Rows[i]["trndata_tdpf_seqno"].ToString()
                    );

                dt.Rows[i]["payod_amt"] =
                    DAO.getPayodAmount
                    (strOrgID,
                    strTrnDataYm,
                    strTrnDataKind,
                    dt.Rows[i]["base_seqno"].ToString(),
                    strTrnDataCodeSys,
                    strTrnDataCodeType,
                    strTrnDataCodeNo,
                    strTrnDataCode,
                    strPayDate,
                    p_payod_str,
                    unit_multi_monthpay
                    );
            }
            return dt;
        }



        public string getSaBand(
             string strOrgID,
             string strBankSeqNo,
             string strBankTdpfSeqNo
             )
        {
            string strReturnValue = "未設定";
            DataTable dt =
             DAO.getSaBand(
             strOrgID,
             strBankSeqNo,
             strBankTdpfSeqNo
             );
            if (dt.Rows.Count > 0)
            {
                strReturnValue = dt.Rows[0]["bank_bank_no"].ToString();
            }
            return strReturnValue;

        }



        public void deleteSatrndata(
           string strPAYOYYMM,
           string strOrgCode          
           )
        {

            DAO.deleteSatrndata(strPAYOYYMM, strOrgCode);  
        }



        public void deleteSatrndata2(
      string strPAYOYYMM,
      string strOrgCode,
      string strTrnKind,
      string strTrnDataCodeSys,
      string strTrnDataCodeType,
      string strTrnDataCodeNo,
      string strTrnDataCode
      )
        {

            DAO.deleteSatrndata2(strPAYOYYMM, strOrgCode,strTrnKind,strTrnDataCodeSys,strTrnDataCodeType,strTrnDataCodeNo,strTrnDataCode);
        }



        public DataTable querydata
          (
          string strOrgID // 機關代碼    
            , string p_tdpm_str
          )
        {
            DataTable dt = DAO.querydata(strOrgID, p_tdpm_str);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public DataTable querydata2
       (
        string strOrgID ,// 機關代碼       
        string tdpm_kind,
        string tdpm_code_sys,
        string tdpm_code_kind,
        string tdpm_code_type,
        string tdpm_code_no,
        string tdpm_code
       )
        {
            DataTable dt = DAO.querydata2(strOrgID, tdpm_kind, tdpm_code_sys, tdpm_code_kind, tdpm_code_type, tdpm_code_no, tdpm_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        public DataTable querydata3
   (
    string strOrgID,// 機關代碼       
    string tdpm_kind,
    string tdpm_code_sys,
    string tdpm_code_kind,
    string tdpm_code_type,
    string tdpm_code_no
   )
        {
            DataTable dt = DAO.querydata3(strOrgID, tdpm_kind, tdpm_code_sys, tdpm_code_kind, tdpm_code_type, tdpm_code_no);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        public DataTable querydataSATDPF
        (
        string strOrgID,// 機關代碼       
        string p_tdpf_seqno
        )
        {
            DataTable dt = DAO.querydataSATDPF(strOrgID, p_tdpf_seqno);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }



        public void queryubStr(
        string strOrgCode
            )
        {

            DAO.queryubStr(strOrgCode);
        }


        public void upbkStr(
     string strOrgCode
         )
        {

            DAO.upbkStr(strOrgCode);
        }



        public DataTable baseStr
            (
            string strOrgCode,// 機關代碼   
            string strPayDate,
            string strPAYOYYMM,
            string strTrnKind,
            string payod_code_sys,
            string payod_code_type,
            string payod_code_no,
            string payod_code,
            string p_tdpm_code_sys,
            string p_payod_str,
            string p_tdpf_seqno
            )
        {
            DataTable dt = DAO.baseStr(strOrgCode,strPayDate, strPAYOYYMM, strTrnKind, payod_code_sys, payod_code_type, payod_code_no, payod_code, p_tdpm_code_sys
                , p_payod_str, p_tdpf_seqno);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }



        public DataTable queryNSTRING
     (
     string TRN_NSTRING
     )
        {
            DataTable dt = DAO.queryNSTRING(TRN_NSTRING);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }



        public DataTable queryStep2Data1
          (
          string strOrgID,
          string strTrnDataYm,
          string strTrnDataKind,
          string strTrnDataCodeSys,
          string strTrnDataCodeType,
          string strTrnDataCodeNo,
          string strTrnDataCode
          )
        {

            DataTable dt = DAO.queryStep2Data1(strOrgID, strTrnDataYm, strTrnDataKind, strTrnDataCodeSys, strTrnDataCodeType, strTrnDataCodeNo, strTrnDataCode);
 
            
            return dt;
        }



        public DataTable unit_multi_monthpay(
        string strOrgID // 機關代碼
        )
        {
            DataTable dt = DAO.unit_multi_monthpay(strOrgID);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }


        public DataTable amt
        (
        string strOrgCode,
        string strTrnDataYm,
        string p_payod_str,
        string strTrnDataKind,
        string unit_multi_monthpay,
        string strPayDate
        )
        {

            DataTable dt = DAO.amt(strOrgCode, strTrnDataYm, p_payod_str, strTrnDataKind, unit_multi_monthpay, strPayDate);

            return dt;
        }


        public DataTable amt2
     (
        string strOrgCode,
        string strTrnDataYm,
        string strTrnDataKind,
        string p_code_sys,
        string p_code_type,
        string p_code_no,
        string p_code,
        string unit_multi_monthpay,
        string strPayDate
     )
        {

            DataTable dt = DAO.amt2(strOrgCode, strTrnDataYm, strTrnDataKind, p_code_sys, p_code_type, p_code_no, p_code, unit_multi_monthpay, strPayDate);

            return dt;
        }



        public DataTable amt3
     (
        string strOrgCode,
        string strTrnDataYm     
     )
        {

            DataTable dt = DAO.amt3(strOrgCode, strTrnDataYm);

            return dt;
        }


        public DataTable amt4
             (
            string strOrgCode,
            string strTrnDataYm,
            string strTrnDataKind,
            string p_code_sys,
            string p_code_type,
            string p_code_no,
            string p_code
             )
        {

            DataTable dt = DAO.amt4(strOrgCode, strTrnDataYm,strTrnDataKind,p_code_sys,p_code_type,p_code_no,p_code);

            return dt;
        }



        public DataTable step3Tdpm
           (
          string strOrgCode,
          string step3_p_tdpm_str
           )
        {

            DataTable dt = DAO.step3Tdpm(strOrgCode, step3_p_tdpm_str);

            return dt;
        }


        public DataTable step3Tdpm2
           (
            string strOrgCode,
            string strKind,
            string p_code_sys,
            string p_code_type,
            string p_code_no,
            string p_code
           )
        {

            DataTable dt = DAO.step3Tdpm2(strOrgCode, strKind, p_code_sys, p_code_type, p_code_no, p_code);

            return dt;
        }



        public DataTable GetSaTdpf
        (
         string p_tdpm_tdpf_seqno
        )
        {

            DataTable dt = DAO.GetSaTdpf(p_tdpm_tdpf_seqno);

            return dt;
        }


        public DataTable DownloadStart
            (
            string strYm,
            string strOrgCode
            )
        {

            DataTable dt = DAO.DownloadStart(strYm, strOrgCode);

            return dt;
        }


        public DataTable DownloadStart2
        (
            string strYm,
            string strOrgCode,
            string strKind,
            string p_code_sys,
            string p_code_type,
            string p_code_no,
            string p_code
        )
        {

            DataTable dt = DAO.DownloadStart2(strYm, strOrgCode, strKind, p_code_sys, p_code_type, p_code_no, p_code);

            return dt;
        }



        public DataTable SQLs1
        (
        string strYm,
        string strOrgCode,
        string p_tdpm_tdpf_seqno
        )
        {

            DataTable dt = DAO.SQLs1(strYm, strOrgCode, p_tdpm_tdpf_seqno);

            return dt;
        }


        public DataTable SQLs1_1
     (
         string strYm,
         string strOrgCode,
         string strKind,
         string p_code_sys,
         string p_code_type,
         string p_code_no,
         string p_code,
         string p_tdpm_tdpf_seqno
     )
        {

            DataTable dt = DAO.SQLs1_1(strYm, strOrgCode, strKind, p_code_sys, p_code_type, p_code_no, p_code, p_tdpm_tdpf_seqno);

            return dt;
        }



        public DataTable Reportdata
        (
        string strOrgCode,
        string strKind,
        string strYm
        )
        {
            DataTable dt = DAO.Reportdata(strOrgCode, strKind, strYm);
            return dt;
        }



        public DataTable step5_1
     (
     string strOrgCode,
     string strKind,
     string strYm,
     string strDate
     )
        {
            DataTable dt = DAO.step5_1(strOrgCode, strKind, strYm, strDate);
            return dt;
        }



        public DataTable step5_2
         (
         string strOrgCode,
         string strKind,
         string strYm,
         string strDate,
         string strPAYOMergeflowid
         )
        {
            DataTable dt = DAO.step5_2(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid);
            return dt;
        }



        public DataTable step5_3
       (
       string strOrgCode,
       string strKind,
       string strYm,
       string strDate,
       string strPAYOMergeflowid,
           string PAYO_SEQNO
          
       )
        {
            DataTable dt = DAO.step5_3(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid, PAYO_SEQNO);
            return dt;
        }

        public DataTable step5_4
   (
   string strOrgCode,
   string strKind,
   string strYm,
   string strDate,
   string strPAYOMergeflowid,
            string PAYO_SEQNO
   )
        {
            DataTable dt = DAO.step5_4(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid, PAYO_SEQNO);
            return dt;
        }



        public DataTable step5_5
            (
                    string strOrgCode,
                    string strKind,
                    string strYm,
                    string strDate,
                    string PAYO_SEQNO,
                    string payo_kind_code_type,
                    string payo_kind_code_no,
                    string payo_kind_code          
            )
        {
            DataTable dt = DAO.step5_5(strOrgCode, strKind, strYm, strDate, PAYO_SEQNO, payo_kind_code_type, payo_kind_code_no, payo_kind_code);
            return dt;
        }



        public DataTable step5_6
            (
                string strOrgCode,
                string strKind,
                string strYm,
                string strDate,
                string PAYO_SEQNO,
                string payo_kind_code_type,
                string payo_kind_code_no,
                string payo_kind_code
            )
        {
            DataTable dt = DAO.step5_6(strOrgCode, strKind, strYm, strDate, PAYO_SEQNO, payo_kind_code_type, payo_kind_code_no, payo_kind_code);
            return dt;
        }


        public DataTable getemail
        (
            string UserId
        )
        {
            DataTable dt = DAO.getemail(UserId);
            return dt;
        }


        public DataTable step3str
    (
        string kind,
            string ym,
            string nflow
    )
        {
            DataTable dt = DAO.step3str(kind, ym, nflow);
            return dt;
        }



        public DataTable newstep2Data
    (
        string strTrnDataKind,
            string strTrnDataYm
    )
        {
            DataTable dt = DAO.newstep2Data(strTrnDataKind, strTrnDataYm);
            return dt;
        }





    }

}