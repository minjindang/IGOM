using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3111 的摘要描述
/// 與上月薪資發放比較
/// Eliot Chen
/// </summary>
namespace SALPLM.Logic
{
    public class SAL3111
    {
        private SAL3111DAO DAO;

        public SAL3111()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3111DAO();
        }

        public SAL3111(SqlConnection conn)
        {
            DAO = new SAL3111DAO(conn);
        }

        public DataTable querySalSaItem
            (
            string strOrgID // 機關代碼
            )
        {
            DataTable dt = DAO.querySalSaitem(strOrgID);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        // 查詢批號清單
        public DataTable querySalPayItem(
        string strOrgID,        // 機關代碼
        string strItemCodes,    // 其他薪津發放項目勾選之代碼
        string strMergeFlowID   // 畫面條件中之批號
            )
        {
            DataTable dt = DAO.querySalPayItem(strOrgID, strItemCodes, strMergeFlowID);
            //            if (dt == null || dt.Rows.Count == 0)
            //            {
            //                return null;
            //            }
            //            else
            //            {
            // 增加欄位
            dt.Columns.Add("ItemName");
            dt.Columns.Add("BudgeName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["ItemName"] = SALARY.Logic.app.GetSaCode_Desc1(
                        dt.Rows[i]["PAYITEM_CodeSys"].ToString(),//payitem_codesys,
                        dt.Rows[i]["PAYITEM_CodeType"].ToString(),//payitem_codetype,
                        dt.Rows[i]["PAYITEM_Codeno"].ToString());//,//   payitem_codeno,
                //strOrgID);
                dt.Rows[i]["BudgeName"] = SALARY.Logic.app.GetSaCode_Desc1(
                        "002",//payitem_codesys,
                        "018",//payitem_codetype,
                        dt.Rows[i]["PAYITEM_Budget_code"].ToString());
            }

            return dt;
            //            }

        }


        // 查詢其他薪津項目明細
        public DataTable querySalSaitemDetail
           (
             string strOrgID,        // 機關代碼
             string strMergeFlowID   // 畫面條件中之批號
           )
        {
            DataTable dt = DAO.querySalSaitemDetail(strOrgID, strMergeFlowID);
            // 增加欄位
            dt.Columns.Add("ItemName");
            dt.Columns.Add("BudgeName");
            dt.Columns.Add("EmpName");  // 姓名

            SAL3104DAO sal3104dao = new SAL3104DAO();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["ItemName"] = SALARY.Logic.app.GetSaCode_Desc1(
                        dt.Rows[i]["PAYITEM_CodeSys"].ToString(),//payitem_codesys,
                        dt.Rows[i]["PAYITEM_CodeType"].ToString(),//payitem_codetype,
                        dt.Rows[i]["PAYITEM_Codeno"].ToString());//,//   payitem_codeno,
                //strOrgID);
                dt.Rows[i]["BudgeName"] = "";
                string strUserName = "";
                DataTable dtUser = sal3104dao.queryUserName(strOrgID,
                    dt.Rows[i]["payitem_User_id"].ToString());
                if (dtUser == null || dtUser.Rows.Count == 0)
                {
                    strUserName = "?";
                }
                else
                {
                    strUserName = dtUser.Rows[0]["BASE_NAME"].ToString();
                }
                dt.Rows[i]["EmpName"] = strUserName;
            }


            return dt;

        }

        // 更薪其他
        public void updateOthersDetail(
            string strPayItemAmt,
            string strOrgID,
            string strMergeFlowID,
            string strPayitemUserID
            )
        {
            DAO.updateOthersDetail(strPayItemAmt, strOrgID, strMergeFlowID, strPayitemUserID);
        }


        public string getSerNO()
        {
            return DAO.getSerNO();
        }


        public void updateSABase
            (
            string strOrgID, // '登入者機關代碼'   
            string strCalType,  // 計算範圍
            string strBaseProNO,//人員類別選項
            string strOnJob,    // 在職狀態
            string strUserName  // 姓名
            )
        {
            DAO.updateSABase(strOrgID, strCalType, strBaseProNO, strOnJob, strUserName);
        }

        public void insertSalSabatJob
            (
            string strJobNO, //'job流水號'
            string strOrgID,//'登入者機關代碼'
            string strJobUserID,//'登入者員工編號'
            string strJobItem,//'計算項目代碼'
            string strType  // 計算範圍
            )
        {
            DAO.insertSalSabatJob(strJobNO, strOrgID, strJobUserID, strJobItem, strType);
        }

        public void insertSalSaBatPara
             (
             string strParaJobNo,    // 'job流水號'
             string strParaOrderNo,
             string strParaValue     //'job使用者畫面選擇之計算年月'     
             )
        {
            DAO.insertSalSaBatPara(strParaJobNo, strParaOrderNo, strParaValue);
        }

            // 刪除其他薪津部分
        public void deleteSalSaCalCBase(
            string strOrgID             // 機關代號
            , string strYearMonth    // 計算年月 YYYYMM
            )
        {
            DAO.deleteSalSaCalCBase(strOrgID, strYearMonth);
        }

            
    // 新增其他薪津
        public void insertSalSacalcbase(
        string strYM,
        string strOrgID,
        string strCalType,
        string strBaseProNO,
        string strOnJob,
        string strUserName
            )
        {
            DAO.insertSalSacalcbase(strYM, strOrgID, strCalType, strBaseProNO, strOnJob, strUserName);
        }



        public DataTable detail1
          (
            string strtype,
            string Job,
            string UserName,
            string Depart,
            string Depart1
          )
        {
            DataTable dt = DAO.detail1(strtype, Job, UserName, Depart, Depart1);
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