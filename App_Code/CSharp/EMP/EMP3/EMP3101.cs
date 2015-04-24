using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3101 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMP3101
    {

        private EMP3101DAO DAO;
        public EMP3101()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMP3101DAO();
        }

        public EMP3101(SqlConnection conn)
        {
            DAO = new EMP3101DAO(conn);
        }

        public DataTable queryEMPApplicaSysProf
            (
            string strORGCode,
            string strSystemCode,
            string strIsActiveFlag
            )
        {
            DataTable dt = DAO.queryEMPApplicaSysProf
                (strORGCode, strSystemCode, strIsActiveFlag);
            // 增加欄位
            dt.Columns.Add("DeptName");
            dt.Columns.Add("isActiveDisplay");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtDept=DAO.get1stDeptList(dt.Rows[i]["Orgcode"].ToString());
                if (dtDept.Rows.Count>0)
                {
                    dt.Rows[i]["DeptName"]=dtDept.Rows[0]["ORGCODE_NAME"].ToString();
                }
                else
                {
                    dt.Rows[i]["DeptName"]="";
                }

                if (dt.Rows[i]["IS_ACTIVE_FLAG"].ToString() == "Y")
                {
                    dt.Rows[i]["isActiveDisplay"] = "啟用";
                }
                else
                {
                    dt.Rows[i]["isActiveDisplay"] = "停用";
                }

            }
            return dt;
        }

        public DataTable get1stDeptList()
        {
            DataTable dt = DAO.get1stDeptList();
            return dt;
        }



            // 新增資料
        public void insertEMPApplicaSysProf(
            string strOrgCode,  // 機關代碼
            string strSystemCode,   // 應用系統代碼
            string strSystemName,   // 應用系統名稱
            string strServerIP,  // 伺服器位址
            string strWebURL,   // 應用系統網址
            string strisActiveFlag, // 是否啟用
            string strNoteDesc, // 備註說明
            string strChangeUserID, // 異動人員
            string strAPIdCard  // 應用系統負責人
            )
        {
            DAO.insertEMPApplicaSysProf(
                strOrgCode,  // 機關代碼
                strSystemCode,   // 應用系統代碼
                strSystemName,   // 應用系統名稱
                strServerIP,  // 伺服器位址
                strWebURL,   // 應用系統網址
                strisActiveFlag, // 是否啟用
                strNoteDesc, // 備註說明
                strChangeUserID, // 異動人員
                strAPIdCard  // 應用系統負責人
            );
        }

        public void editEMPApplicaSysProf(
            string strSystemName,   // 應用系統名稱
            string strServerIP,  // 伺服器位址
            string strWebURL,   // 應用系統網址
            string strisActiveFlag, // 是否啟用
            string strNoteDesc, // 備註說明
            string strChangeUserID, // 異動人員
            string strAPIdCard,  // 應用系統負責人
            string strID
        )
        {
            DAO.editEMPApplicaSysProf
                (
                strSystemName,   // 應用系統名稱
                strServerIP,  // 伺服器位址
                strWebURL,   // 應用系統網址
                strisActiveFlag, // 是否啟用
                strNoteDesc, // 備註說明
                strChangeUserID, // 異動人員
                strAPIdCard,  // 應用系統負責人
                strID
               );
        }

        public void DeleteEMPApplicaSysProf(string OrgCode,
            string AP_idcard,
            string ID
            )
        {
            DAO.DeleteEMPApplicaSysProf(OrgCode, AP_idcard, ID);
        }

        public bool isSystemCodeUsed(
            string OrgCode,
            string strSystemCode
            )
        {
            return DAO.isSystemCodeUsed(OrgCode, strSystemCode);
        }

    }
}