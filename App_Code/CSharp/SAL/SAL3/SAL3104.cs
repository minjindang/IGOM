using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3104 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3104
    {
        private SAL3104DAO DAO;

        public SAL3104()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3104DAO();
        }

        public SAL3104(SqlConnection conn)
        {
            DAO = new SAL3104DAO(conn);
        }

        public DataTable querySalItemName(
            string strOrgID,               // 機關代碼
            string strisPaywithSalary,     // 是否隨薪
            string strPayMethod,           // 發放方式
            string strItemType             // 項目類別

        )
        {
            DataTable dt = DAO.querySalItemName(strOrgID, strisPaywithSalary, strPayMethod, strItemType);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public DataTable querySalPayItem(
        string strOrgID,               // 機關代碼
        string strisPaywithSalary,     // 是否隨薪
        string strPayMethod,           // 發放方式
        string strItemType,            // 項目類別
        string strItemNameCode,         // 項目名稱
        string strBatchNum,             // 批號
        string strEmployeeType  ,        // 員工類別
           string  strBaseEDate,string departid,string idcard
        )
        {
            DataTable dt = DAO.querySalPayItem(strOrgID
                , strisPaywithSalary
                , strPayMethod, strItemType, strItemNameCode
                , strBatchNum, strEmployeeType, strBaseEDate, departid, idcard);
//            if (dt == null || dt.Rows.Count == 0)
//            {
//                return null;
//            }
//            else
//            {
                dt.Columns.Add("ItemName");//增加項目名稱欄位
                dt.Columns.Add("BudgeSource");//增加項目名稱欄位
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strItemName = "";
                    strItemName =
                    SALARY.Logic.app.GetSaCode_Desc1(
                        dt.Rows[i]["payitem_codesys"].ToString(),
                        strPayMethod,
                        strItemType);//,
                    //                        strOrgID);
                    //預算來源
                    string strSource = "";
                    strSource = SALARY.Logic.app.GetSaCode_Desc1("002", "018", dt.Rows[i]["PAYITEM_Budget_code"].ToString());
                    dt.Rows[i]["ItemName"] = strItemName;
                    dt.Rows[i]["BudgeSource"] = strSource;

                }

                return dt;
 //           }
        }


        // 明細資料
        public DataTable querySalPayItemDetail(
            string strOrgID,               // 機關代碼
            string strBatchNum             // 批號
            ,string strBaseEDate,string departid,string idcard
            )
        {
            DataTable dt = DAO.querySalPayItemDetail(strOrgID
                , strBatchNum, strBaseEDate, departid, idcard );
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                dt.Columns.Add("ItemName");//增加項目名稱欄位
                dt.Columns.Add("BudgeSource");
                dt.Columns.Add("base_name"); // 增加姓名欄位
                dt.Columns.Add("DeptName"); // 增加科室名稱欄位
                // 以下空欄位
                // 因與EDIT共用GRID所需
                dt.Columns.Add("code_sys"); 
                dt.Columns.Add("code_kind");
                dt.Columns.Add("code_type");
                dt.Columns.Add("code_no");
                dt.Columns.Add("code"); 
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strItemName = "";

                    // 項目名稱
                    strItemName =
                    SALARY.Logic.app.GetSaCode_Desc1(
                        dt.Rows[i]["payitem_codesys"].ToString(),
                        dt.Rows[i]["PAYITEM_CodeType"].ToString(),
                        dt.Rows[i]["PAYITEM_CodeNo"].ToString());//,
                    //                        strPayMethod,
                    //                        strItemType,
                    //                        strOrgID);
                    //SALARY.Logic.app.GetSaCode_Desc1(payitem_codesys, payitem_codetype, payitem_codeno, payitem_org_code)

                    //預算來源
                    string strSource = "";
                    //strSource = SALARY.Logic.app.GetSaCode_Desc1("", "", "", strOrgID);

                    string strUserName = "";
                  
                    DataTable dtUser=DAO.queryUserName(strOrgID,  dt.Rows[i]["payitem_User_id"].ToString());
                    if (dtUser == null || dtUser.Rows.Count == 0)
                    {
                        strUserName = "";
                    }
                    else
                    {
                        strUserName = dtUser.Rows[0]["BASE_NAME"].ToString();
                    }
                    

                   

                    // 科室名稱
                    // 續從人員資料去抓
                    string strDeptName = "";
                    // payitem_CodeNO 需確認是不是抓這欄位
                    DataTable dtORG = DAO.queryFCSORG(strOrgID, dt.Rows[i]["payitem_User_id"].ToString());
                    if (dtORG == null || dtORG.Rows.Count == 0)
                    {
                        strDeptName = "";
                    }
                    else
                    {
                        strDeptName = dtORG.Rows[0]["DEPART_NAME"].ToString();
                    }

                    dt.Rows[i]["ItemName"] = strItemName;
                    dt.Rows[i]["BudgeSource"] = strSource;
                    dt.Rows[i]["base_name"] = strUserName;
                    dt.Rows[i]["DeptName"] = strDeptName;

                }

                return dt;
            }
        }

        // 『新增查詢』之資料查詢部分
        public DataTable querySalItemDetail4Edit
        (
            string strPayMethod,           // 發放方式
            string strItemType,            // 項目類別
            string strItemNameCode,         // 項目名稱
            string strOrgID,               // 機關代碼
            string strEmployeeType          // 員工類別
            ,string strBaseEDate,string departid,string idcard
        )
        {
            DataTable dt = DAO.querySalItemDetail4Edit(
                strPayMethod,
                strItemType,
                strItemNameCode,
                strOrgID,
                strEmployeeType, strBaseEDate, departid, idcard);
    //       if (dt == null || dt.Rows.Count == 0)
    //        {
    //            return dt;
    //        }
    //        else
    //        {     
                dt.Columns.Add("PAYITEM_Merge_flow_id");    // 增加 PAYITEM_Merge_flow_id 欄位
                dt.Columns.Add("PAYITEM_Flow_id");    // 增加 PAYITEM_Flow_id 欄位
                dt.Columns.Add("PAYITEM_Pay_amt");          // 增加 PAYITEM_Pay_amt 欄位
    //          dt.Columns.Add("ItemName");   //增加項目名稱欄位
                dt.Columns.Add("BudgeSource");//增加項目名稱欄位
                //dt.Columns.Add("UserName"); // 增加姓名欄位
    //          dt.Columns.Add("DeptName");   // 增加科室名稱欄位   
    /*            for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["PAYITEM_Merge_flow_id"] = "";
                    // 科是名稱
                    // 續從人員資料去抓
                    string strDeptName = "";
                    // payitem_CodeNO 需確認是不是抓這欄位
                    DataTable dtORG = DAO.queryFCSORG(strOrgID, dt.Rows[i]["base_seqno"].ToString());
                    if (dtORG == null || dtORG.Rows.Count == 0)
                    {
                        strDeptName = "?";
                    }
                    else
                    {
                        strDeptName = dtORG.Rows[0]["DEPART_NAME"].ToString();
                    }


                    string strItemName = "";
                    strItemName =
                    SALARY.Logic.app.GetSaCode_Desc1(
                        dt.Rows[i]["code_sys"].ToString(),
                        dt.Rows[i]["code_type"].ToString(),
                        dt.Rows[i]["code_no"].ToString());

              //      dt.Rows[i]["ItemName"] = strItemName;
              //      dt.Rows[i]["DeptName"] = strDeptName;
                }   */
                
   //         }
            return dt;

        }

        public void insertSAL_PAYITEM(
                string strPayitemOrgCode,   // '上述SQL查詢之base_orgid內容'
                string strPayitemUserID,    // '上述SQL查詢之base_seqno內容'
                string strPayitemFlowID,     // 系統取號
                string strPayitemMargeFlowID,           // 系統取號
                string strPayitemCodeSys,   // 上述SQL查詢之code_sys內容
                string strPayitemCodeKind,    // 上述SQL查詢之code_kind內容
                string strPayitemCodType,   // 上述SQL查詢之code_type內容
                string strPayitemCodeNo,  // 上述SQL查詢之code_no內容
                string strPayitemCode, // 上述SQL查詢之code內容
                string strPayitemBudgeCode,    // 清單選擇之預算來源代碼
                string strPayitemPayAmt,        // 清單輸入之金額
                string strPayitemModUserID// 登入者 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
           )
        {
            DAO.insertSAL_PAYITEM(strPayitemOrgCode, strPayitemUserID, strPayitemFlowID, strPayitemMargeFlowID
                , strPayitemCodeSys, strPayitemCodeKind, strPayitemCodType, strPayitemCodeNo,strPayitemCode
                , strPayitemBudgeCode, strPayitemPayAmt, strPayitemModUserID);
        }

            // 更新 SAL_PAYITEM 資料
        public void updateSAL_PAYITEMAMT(
                    string strPayitemOrgCode,   // '上述SQL查詢之base_orgid內容'
            string strPayitemUserID,    // '上述SQL查詢之base_seqno內容'
            string strPayitemFlowID,     // 系統取號
            string strPayitemMargeFlowID,           // 系統取號
            string strPayitemCodeSys,   // 上述SQL查詢之code_sys內容
            string strPayitemCodeKind,    // 上述SQL查詢之code_kind內容
            string strPayitemCodType,   // 上述SQL查詢之code_type內容
            string strPayitemCodeNo,  // 上述SQL查詢之code_no內容
            string strPayitemCode, // 上述SQL查詢之code內容
            string strPayitemBudgeCode,    // 清單選擇之預算來源代碼
            string strPayitemPayAmt,        // 清單輸入之金額
            string strPayitemModUserID// 登入者 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        )
        {
            DAO.updateSAL_PAYITEMAMT(strPayitemOrgCode, strPayitemUserID, strPayitemFlowID, strPayitemMargeFlowID
                , strPayitemCodeSys, strPayitemCodeKind, strPayitemCodType, strPayitemCodeNo, strPayitemCode
                , strPayitemBudgeCode, strPayitemPayAmt, strPayitemModUserID);
        }



    }







}