using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2118 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL2118
    {
        private SAL2118DAO DAO;
        public SAL2118()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL2118DAO();
        }

        public SAL2118(SqlConnection conn)
        {
            DAO = new SAL2118DAO(conn);
        }


        // 發放種類為其他薪津(005)時查詢項目
        public DataTable queryItemTypes
        (
        string strOrgID // 機關代號
        )
        {
            DataTable dt = DAO.queryItemTypes(strOrgID);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }


        }

        public DataTable queryReportData(
            string strOrgID,        // '登入者機關代碼'
            string strIncoCode,     // '查詢畫面之發放種類代碼'
            string strIncoTypeCode, // '查詢畫面之項目代碼'
            string strIncoDate,     // '查詢畫面之發放日期' 
            string strBaseName,     // '查詢畫面之姓名'
            string strBaseSeqNO,    // '查詢畫面之員工編號' 
            string strBaseProNo,    // '查詢畫面之員工類別'
            string strBaseDep       // '查詢畫面之單位' 
            )
        {
            DataTable dt = DAO.queryReportData(strOrgID, strIncoCode, strIncoTypeCode, strIncoDate, strBaseName, strBaseSeqNO, strBaseProNo, strBaseDep);
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