using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3107 的摘要描述
/// /// SAL3107	年終獎金主管加給維護
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL3107
    {
        private SAL3107DAO DAO;
        public SAL3107()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3107DAO();
        }
        public SAL3107(SqlConnection conn)
        {
            DAO = new SAL3107DAO(conn);
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

        // 帶入主管加給
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

    // 帶入主管加給
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
            return (dt.Rows.Count==0);
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
            string v_kdc,
            string v_kdc_series,
            string v_kdc_mon,
            string v_muser,
            string v_amt// 金額
            )
        {
            return DAO.updateSalSaseBouns(
                v_id,
                v_year,
                v_kdc,
                v_kdc_series,
                v_kdc_mon,
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

            // 
        public DataTable queryBase(
            string v_UserOrgId,
            string v_Search_Str,
            string v_Job,
            string v_Proj,
            string v_Dept,
            string v_base_edate,
            string v_seqno)
        {
            DataTable dt=DAO.queryBase(
             v_UserOrgId,
             v_Search_Str,
             v_Job,
             v_Proj,
             v_Dept,
             v_base_edate,
             v_seqno);
            return dt;
        }
    }


}