using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add

using System.Data;
using System.Data.SqlClient;
using FSC.Logic;


/// <summary>
/// SAL3101 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3101
    {
        private SAL3101DAO DAO;
        public SAL3101()
        {
            // TODO: 在此加入建構函式的程式碼
            DAO = new SAL3101DAO();
        }

        public SAL3101(SqlConnection conn)
        {
            DAO = new SAL3101DAO(conn);
        }

        // 民國字串 -> 西元字串 EEEMMDD -> YYYYMMDD
        public static string ROCDateStrToDateStr(string ROCDateStr)
        {
            string strReturnValue = "";
            if (ROCDateStr.Trim().Length == 7)
            {
                strReturnValue =
                    Convert.ToString((Convert.ToInt32(ROCDateStr.Substring(0, 3)) + 1911)).PadLeft(4, '0') +
                    ROCDateStr.Substring(3);

            }
            return strReturnValue;
        }

        public static string DateStrToROCDateStr(string DateStr)
        {
            string strReturnValue = "";
            if (DateStr.Trim().Length == 8)
            {
                strReturnValue =
                    Convert.ToString((Convert.ToInt32(DateStr.Substring(0, 4)) - 1911)).PadLeft(3, '0') +
                    DateStr.Substring(4);
            }
            return strReturnValue;
        }


         
        // 查詢資料
        public DataTable querySalSaBase(string v_UserOrgId, string v_base_status, string v_base_prono, string v_Search_str, string departid, string idcard)
        {
            DataTable dt = DAO.querySalSaBase(v_UserOrgId, v_base_status, v_base_prono, v_Search_str, "", departid, idcard);
            return dt;
        }

     /*   public DataTable querySalSaBase(string v_UserOrgId, string v_base_status, string v_base_prono, string v_Search_str, string v_orderby)
        {
            DataTable dt = DAO.querySalSaBase(v_UserOrgId, v_base_status, v_base_prono, v_Search_str, v_orderby);
            return dt;
        }
        */

        // 查詢單一使用者資料
        public DataTable querySalSaBaseBySeqNo(string strBaseOrgID, string strBaseSeqNO)
        {
            DataTable dt = DAO.querySalSaBaseBySeqNo(strBaseOrgID, strBaseSeqNO);
            return dt;
        }

        // 查詢奉點
        public DataTable querySaleCom(
            string strLevComOrgL1,
            string strLevComOrgL2,
            string strLevComOrgL3
            )
        {
            DataTable dt = DAO.querySaleCom(strLevComOrgL1, strLevComOrgL2, strLevComOrgL3);
            return dt;
        }

        // 取得專業加給金額表
        public DataTable queryKdpSeries(
            string strSpesUp
        )
        {
            DataTable dt = DAO.queryKdpSeries(strSpesUp);
            return dt;
        }

        // 取得主管加給金額表
        public DataTable queryKdcSeries(
            string strSpesUp
            )
        {
            DataTable dt = DAO.queryKdcSeries(strSpesUp);
            return dt;
        }

        // 修改 SAL_SABASE
        public int updateSalSaBase(
            string BASE_IDNO,
            string BASE_STATUS,
            string BASE_TYPE,
            string BASE_ORGID,
            string BASE_NAME,
            string BASE_SEX,
            string BASE_JOB_DATE,
            string BASE_DEP,
            string BASE_BDATE,
            string BASE_EDATE,
            string BASE_JOB,
            string BASE_DCODE,
            string BASE_ORG_L1,
            string BASE_ORG_L2,
            string BASE_ORG_L3,
            string BASE_AGEN,
            string BASE_IN_L1,
            string BASE_IN_L3,
            string BASE_PTB,
            string BASE_PROV,
            string BASE_ADDR,
            string BASE_QUIT_DATE,
            string BASE_QUIT_REZN,
            string BASE_ERMK,
            string BASE_PRONO,
            string BASE_KDB,
            string BASE_KDC,
            string BASE_KDP,
            string BASE_KDO,
            string BASE_POL,
            string BASE_HOUS,
            string BASE_WELG,
            string BASE_WELO,
            string BASE_PRE,
            string BASE_OTHER_SAL,
            string BASE_PRED,
            string BASE_PRIZ,
            string BASE_TAX,
            string BASE_FINS_KIND,
            string BASE_PN_Y30,
            string BASE_FINS_NOQ,
            string BASE_FINS_NOH,
            string BASE_FINS_NOF,
            string BASE_FINS_NOL,
            string BASE_FINS_SELF,
            string BASE_FINS_NO,
            string BASE_DAY_SAL,
            string BASE_HOUR_SAL,
            string BASE_DCT_A,
            string BASE_DCT_B,
            string BASE_DCT_C,
            string BASE_COUNT_REMARK,
            string BASE_MEMO,
            string BASE_MUSER,
            string BASE_MDATE,
            string BASE_KDC_SERIES,
            string BASE_KDP_SERIES,
            string BASE_LABOR_SERIES,
            string BASE_PRTS,
            string BASE_FIN_AMT,
            string BASE_TAX_DCT,
            string BASE_LABOR_STATUS,
            string BASE_SENTMAIL,
            string BASE_EMAIL,
            string BASE_FIN_SUP_AMT,
            string BASE_REPLACE_AMT,
            string BASE_GOVADOF,
            string BASE_LAB_JIF,
            string base_fins_noq_nol,
            string base_fins_noh_nol,
            string BASE_FINS_Y65,
            string BASE_FINS_SERIES,
            string Base_IsMarked,
            string BASE_PEN_RATE,
            string BASE_PEN_TYPE,
            string BASE_PROF,
            string BASE_PEN_SERIES,
            string BASE_NUMERATOR,
            string BASE_DENOMINATOR,
            string BASE_PTB_TYPE,
            string BASE_ALT_AMT,
            string BASE_MEMO1,
            string BASE_MEMO2,
            string BASE_MEMO3,
            string BASE_DCODE_NAME,
            string BASE_SENTMSG,
            string BASE_FINS_HEALTH_SELF,
            string BASE_PROJ_BDATE,
            string BASE_PROJ_EDATE,
            string BASE_LAB1,
            string BASE_LAB2,
            string BASE_LAB3,
            string BASE_PARTTIME,
            string BASE_FINS_SELF_DESC,
            string BASE_FINS_PAR_DESC,
            string BASE_SERVICE_PLACE_DESC,
            string BASE_SEQNO,
            string BASE_RAMT,
            string BASE_NAMT,
            string BASE_MAMT,
            string HEALTH_SELF_DESC,
            string Budget_code
            )
        {
            return DAO.updateSalSaBase
                (
                    BASE_IDNO,
                     BASE_STATUS,
                     BASE_TYPE,
                     BASE_ORGID,
                     BASE_NAME,
                     BASE_SEX,
                     BASE_JOB_DATE,
                     BASE_DEP,
                     BASE_BDATE,
                     BASE_EDATE,
                     BASE_JOB,
                     BASE_DCODE,
                     BASE_ORG_L1,
                     BASE_ORG_L2,
                     BASE_ORG_L3,
                     BASE_AGEN,
                     BASE_IN_L1,
                     BASE_IN_L3,
                     BASE_PTB,
                     BASE_PROV,
                     BASE_ADDR,
                     BASE_QUIT_DATE,
                     BASE_QUIT_REZN,
                     BASE_ERMK,
                     BASE_PRONO,
                     BASE_KDB,
                     BASE_KDC,
                     BASE_KDP,
                     BASE_KDO,
                     BASE_POL,
                     BASE_HOUS,
                     BASE_WELG,
                     BASE_WELO,
                     BASE_PRE,
                     BASE_OTHER_SAL,
                     BASE_PRED,
                     BASE_PRIZ,
                     BASE_TAX,
                     BASE_FINS_KIND,
                     BASE_PN_Y30,
                     BASE_FINS_NOQ,
                     BASE_FINS_NOH,
                     BASE_FINS_NOF,
                     BASE_FINS_NOL,
                     BASE_FINS_SELF,
                     BASE_FINS_NO,
                     BASE_DAY_SAL,
                     BASE_HOUR_SAL,
                     BASE_DCT_A,
                     BASE_DCT_B,
                     BASE_DCT_C,
                     BASE_COUNT_REMARK,
                     BASE_MEMO,
                     BASE_MUSER,
                     BASE_MDATE,
                     BASE_KDC_SERIES,
                     BASE_KDP_SERIES,
                     BASE_LABOR_SERIES,
                     BASE_PRTS,
                     BASE_FIN_AMT,
                     BASE_TAX_DCT,
                     BASE_LABOR_STATUS,
                     BASE_SENTMAIL,
                     BASE_EMAIL,
                     BASE_FIN_SUP_AMT,
                     BASE_REPLACE_AMT,
                     BASE_GOVADOF,
                     BASE_LAB_JIF,
                     base_fins_noq_nol,
                     base_fins_noh_nol,
                     BASE_FINS_Y65,
                     BASE_FINS_SERIES,
                     Base_IsMarked,
                     BASE_PEN_RATE,
                     BASE_PEN_TYPE,
                     BASE_PROF,
                     BASE_PEN_SERIES,
                     BASE_NUMERATOR,
                     BASE_DENOMINATOR,
                     BASE_PTB_TYPE,
                     BASE_ALT_AMT,
                     BASE_MEMO1,
                     BASE_MEMO2,
                     BASE_MEMO3,
                     BASE_DCODE_NAME,
                     BASE_SENTMSG,
                     BASE_FINS_HEALTH_SELF,
                     BASE_PROJ_BDATE,
                     BASE_PROJ_EDATE,
                     BASE_LAB1,
                     BASE_LAB2,
                     BASE_LAB3,
                     BASE_PARTTIME,
                     BASE_FINS_SELF_DESC,
                     BASE_FINS_PAR_DESC,
                     BASE_SERVICE_PLACE_DESC,
                     BASE_SEQNO,
                     BASE_RAMT,
                     BASE_NAMT,
                     BASE_MAMT ,
                     HEALTH_SELF_DESC,
                     Budget_code
                );
        }

        // 查詢資料 for 順序 Edit
        public DataTable querySalSaBase4ModifyPrts(string v_UserOrgId, string sorting_string)
        {
            DataTable dt = DAO.querySalSaBase4ModifyPrts(v_UserOrgId, sorting_string);
            return dt;
        }

        // 清除列印順序
        public int clearSalSabasePrts(string strBaseOrgID)
        {
            return DAO.clearSalSabasePrts(strBaseOrgID);
        }

        // 修改列印順序
        public int updateSalSabasePrts(
            string strBaseOrgID,
            string strBaseSeqNo,
            string strBasePrts
            )
        {
            return DAO.updateSalSabasePrts(
             strBaseOrgID,
             strBaseSeqNo,
             strBasePrts
            );
        }

        // 刪除個人銀行帳戶資料
        public int deleteSalSabank(
            string strBankOrgID,
            string strBankSeqNo
            )
        {
            return DAO.deleteSalSabank(
             strBankOrgID,
             strBankSeqNo
            );

        }

        // 新增個人銀行帳號資料
        public int insertSalSabank(
            string strBankSeqNo,
            string strBankOrgID,
            string strBankCode,
            string strBankBankNo,
            string strBankMUser,
                    string strBankTdpfSeqNo
            )
        {
            return DAO.insertSalSabank(
             strBankSeqNo,
             strBankOrgID,
             strBankCode,
             strBankBankNo,
             strBankMUser,
                     strBankTdpfSeqNo
            );
        }

        public int deleteSalSaPItm(
            string strpitmOrgID,
            string strpitmSeqNo,
            string strPitmCodeSys,
            string strpitmCodeKind,
            string strpitmCodeType
            )
        {
            return DAO.deleteSalSaPItm(
             strpitmOrgID,
             strpitmSeqNo,
             strPitmCodeSys,
             strpitmCodeKind,
             strpitmCodeType
            );
        }

        public int insertSalsaPItm(
            string PITM_ORGID,
            string PITM_SEQNO,
            string PITM_CODE_SYS,
            string PITM_CODE_KIND,
            string PITM_CODE_TYPE,
            string PITM_CODE_NO,
            string PITM_CODE,
            //        string PITM_AMT,
            string PITM_MUSER
            )
        {
            return DAO.insertSalsaPItm(
                PITM_ORGID,
                PITM_SEQNO,
                PITM_CODE_SYS,
                PITM_CODE_KIND,
                PITM_CODE_TYPE,
                PITM_CODE_NO,
                PITM_CODE,
                //        string PITM_AMT,
                PITM_MUSER)
             ;
        }

        public int insertSalsaPItm(
            string PITM_ORGID,
            string PITM_SEQNO,
            string PITM_CODE_SYS,
            string PITM_CODE_KIND,
            string PITM_CODE_TYPE,
            string PITM_CODE_NO,
            string PITM_CODE,
                    string PITM_AMT,
            string PITM_MUSER
            )
        {
            return DAO.insertSalsaPItm(
                PITM_ORGID,
                PITM_SEQNO,
                PITM_CODE_SYS,
                PITM_CODE_KIND,
                PITM_CODE_TYPE,
                PITM_CODE_NO,
                PITM_CODE,
                        PITM_AMT,
                PITM_MUSER)
             ;
        }

        public int deleteSalSaPItm4OtherSal(
             string strpitmOrgID,
             string strpitmSeqNo
             )
        {
            return DAO.deleteSalSaPItm4OtherSal(
              strpitmOrgID,
              strpitmSeqNo
             );
        }
    }
}