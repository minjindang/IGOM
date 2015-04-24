using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3102 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMP3102
    {
        private EMP3102DAO DAO;
        public EMP3102()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //

            DAO = new EMP3102DAO();
        }

        public EMP3102(SqlConnection conn)
        {
            DAO = new EMP3102DAO(conn);
        }

        public int insertEMPIshareSysProf(
            string strOrgCode,
            string strDepartID,
            string strShareID,
            string strSystemCode,
            string strChangUserId
            )
        {
            return DAO.insertEMPIshareSysProf(
                strOrgCode,
                strDepartID,
                strShareID,
                strSystemCode,
                strChangUserId
               );
        }

        // 
        public DataTable queryEMPIshareSysProfFull(string strOrgCode, string strDepartID, string strShareID)
        {
            DataTable dt = DAO.queryEMPIshareSysProf(strOrgCode, strDepartID, strShareID);

            // Add Column
            dt.Columns.Add("id");   // 機關名稱-項次
            dt.Columns.Add("DepartName");   // 機關名稱
            dt.Columns.Add("ShareName");    // 人員類別
            dt.Columns.Add("SystemNames");  // 可使用的應用系統

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得 機關名稱
                // 取得 人員類別
                // 取得可使用的系統名稱們
                DataTable dtDetail = DAO.queryEMPIshareSysProfFull(
                    strOrgCode,
                    dt.Rows[i]["DEPART_ID"].ToString(),
                    dt.Rows[i]["SHARE_ID"].ToString()
                    );
                string strSystemNames = "";
                for (int j = 0; j < dtDetail.Rows.Count; j++)
                {
                    if (strSystemNames != "") strSystemNames += ", ";
                    // 取得系統名稱
                    EMP3101DAO dao3101 = new EMP3101DAO();
                    DataTable dtSystem = dao3101.queryEMPApplicaSysProf(strOrgCode, dtDetail.Rows[j]["SYSTEM_CODE"].ToString(), "");
                    if (dtSystem.Rows.Count > 0)
                    {
                        strSystemNames +=
                            dtSystem.Rows[0]["SYSTEM_NAME"].ToString();
                    }


                }
                // 試著用這去拿...
                dt.Rows[i]["ShareName"] = SALARY.Logic.app.GetSaCode_Desc1("002", "017", dt.Rows[i]["SHARE_ID"].ToString());

                // DEPART NAME
                dt.Rows[i]["DepartName"] = DAO.getDeptNameByDepartID(strOrgCode, dt.Rows[i]["DEPART_ID"].ToString());


                dt.Rows[i]["SystemNames"] = strSystemNames;
                dt.Rows[i]["id"] = i + 1;

            }

            return dt;

        }

        public DataTable querySelectSystem
            (
            string strOrgCode,
            string strDepartID,
            string strShareID,
            string strisSelect
            )
        {
            return DAO.querySelectSystem(strOrgCode,
                strDepartID,
                strShareID, strisSelect);
        }

        public DataTable querySelectSystem_2
          (
          string strOrgCode,
          string strDepartID,
          string employee_type,
          string strisSelect
          )
        {
            return DAO.querySelectSystem_2(strOrgCode,
                strDepartID,
                employee_type, strisSelect);
        }


        public DataTable querySelectSystem_3
      (
      string strOrgCode,
      string strDepartID,
      string UcDDLMember,
      string strisSelect
      )
        {
            return DAO.querySelectSystem_3(strOrgCode,
                strDepartID,
                UcDDLMember, strisSelect);
        }



        public string getOrgParentID(
            string strOrgCode,
            string strDepartID
             )
        {
            return DAO.getOrgParentID(
                strOrgCode,
                strDepartID
             );
        }

        public int deleteEMPIshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID
        )
        {
            return DAO.deleteEMPIshareSysProf(strOrgCode,
                strDepartID,
                strShareID);
        }
    }
}