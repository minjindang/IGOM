using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3108 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3108
    {
        private SAL3108DAO DAO;

        public SAL3108()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3108DAO();
        }

        public SAL3108(SqlConnection conn)
        {
            DAO = new SAL3108DAO(conn);
        }

        public DataTable queryUser(
            string v_UserOrgId,     // 單位
            string v_bouns_year,
            string v_base_job,      // 職務類別 
            string v_base_status,   // 在職狀態 
            string v_Search_IDCard, // 員工編號
            string v_Search_Name,   // 姓名
            string strDepart        // 單位 
            )
        {
            DataTable dt = DAO.queryUser(
                v_UserOrgId,     // 單位
                v_bouns_year,
                v_base_job,      // 職務類別 
                v_base_status,   // 在職狀態 
                v_Search_IDCard, // 員工編號
                v_Search_Name,
                strDepart        // 單位 
                );
            return dt;
        }

        // 帶入專業加給
        public int insertBouns(
            string v_orgid, //
            string v_year,
            string v_muser
            )
        {
            return DAO.insertBouns(
                v_orgid,
                v_year,
                v_muser
            );
        }

        // 帶入專業加給
        public int insertBounswithBaseSeqNO(
            string v_orgid,
            string v_year,
            string v_muser,
            string v_BaseSeqNo
            )
        {
            return DAO.insertBounswithBaseSeqNO(
                v_orgid,
                v_year,
                v_muser,
                v_BaseSeqNo
            );
        }

        // 檢查資料
        public bool CheakSalSaseBouns4Insert(
            string v_orgid,
            string v_year
        )
        {
            DataTable dt = DAO.CheakSalSaseBouns(v_orgid, v_year);
            return (dt.Rows.Count == 0);
        }

        // 檢查資料 
        public bool CheakSalSaseBouns4Insert(
            string v_orgid,
            string v_year,
            string v_BaseSeqNo
        )
        {
            DataTable dt = DAO.CheakSalSaseBouns(v_orgid, v_year, v_BaseSeqNo);
            return (dt.Rows.Count == 0);
        }

        // 更改資料
        public int updateSalSaseBouns(
            string v_id,
            string v_year,
            string v_kdp,
            string v_kdp_series,
            string v_kdp_mon,
            string v_muser,
            string v_amt// 金額
            )
        {
            return DAO.updateSalSaseBouns(
                v_id,
                v_year,
                v_kdp,
                v_kdp_series,
                v_kdp_mon,
                v_muser,
                v_amt// 金額
            );
        }

        // 刪除資料
        public int deleteSalSaseBouns(
            string v_id,
            string v_year)
        {
            return DAO.deleteSalSaseBouns(v_id, v_year);
        }
    }
}