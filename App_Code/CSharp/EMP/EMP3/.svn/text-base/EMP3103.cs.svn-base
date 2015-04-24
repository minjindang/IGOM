using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3103 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMP3103
    {
        private EMP3103DAO DAO; 
        public EMP3103()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMP3103DAO();
        }

        public EMP3103(SqlConnection conn)
        {
            DAO = new EMP3103DAO(conn);
        }

        public int insertEMPEshareSysProf(
            string strOrgCode,
            string strDepartID,
            string strShareID,
            string strSystemCode,
            string strChangUserId
            , string strIDCard
            )
        {
            return DAO.insertEMPEshareSysProf(
                strOrgCode,
                strDepartID,
                strShareID,
                strSystemCode,
                strChangUserId
                , strIDCard
               );
        }

        // 
        public DataTable queryEMPEshareSysProfFull(
            string strOrgCode,
            string strDepartID,
            string strShareID
            , string strIDCard
        )
        {
            DataTable dt = DAO.queryEMPEshareSysProf(
                strOrgCode,
                strDepartID,
                strShareID, strIDCard);

            // Add Column
            dt.Columns.Add("id");   // 機關名稱-項次
            dt.Columns.Add("OrgName");      // 機關名稱
            dt.Columns.Add("DepartName");   // 單位名稱
            dt.Columns.Add("ShareName");    // 人員類別
            dt.Columns.Add("SystemNames");  // 可使用的應用系統
            dt.Columns.Add("USER_NAME");  // 可使用的應用系統

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得 機關名稱
                // 取得 人員類別
                // 取得可使用的系統名稱們
                DataTable dtDetail = DAO.queryEMPEshareSysProfFull(
                    strOrgCode,
                    dt.Rows[i]["DEPART_ID"].ToString(),
                    dt.Rows[i]["SHARE_ID"].ToString(),
                    dt.Rows[i]["ID_CARD"].ToString()
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
                EMP3102DAO emp3102dao = new EMP3102DAO();
                dt.Rows[i]["DepartName"] = emp3102dao.getDeptNameByDepartID(strOrgCode, dt.Rows[i]["DEPART_ID"].ToString());

                // Org Name
                dt.Rows[i]["OrgName"] = EMPCommon.getOrgName(dt.Rows[i]["ORGCODE"].ToString());


                // 使用者名稱
                string strUserName = DAO.getUserName(dt.Rows[i]["ID_CARD"].ToString());
                dt.Rows[i]["USER_NAME"] = strUserName + "(" + dt.Rows[i]["ID_CARD"].ToString() + ")";


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
            , string strIDCard
            )
        {
            return DAO.querySelectSystem(strOrgCode,
                strDepartID,
                strShareID, strisSelect
                ,strIDCard);
        }



        public int deleteEMPEshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID
            , string strIDCard
        )
        {
            return DAO.deleteEMPEshareSysProf(strOrgCode,
                strDepartID,
                strShareID
                ,strIDCard);
        }

     // 取得員工姓名
        public string getUserName(string strIDCard)
        {
                // 取得員工姓名
            return DAO.getUserName(strIDCard);

        }

        public string getUserName(string strOrgCode, string strDepartCode, string strEmployeeType, string strIDCard)
        {
            return DAO.getUserName(strOrgCode, strDepartCode, strEmployeeType, strIDCard);
        }




        public DataTable querySelectnametype
         (
         string namevlue      
         )
        {
            return DAO.querySelectnametype(namevlue);            
        }


        public DataTable querySelectnonametype
    (
    string namevlue
    )
        {
            return DAO.querySelectnonametype(namevlue);
        }



    }
}