using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;


/// <summary>
/// EmpMember 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class Emp_Member
    {
        private EmpMemberDAO DAO;
        public Emp_Member()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EmpMemberDAO();
        }

        public Emp_Member(SqlConnection conn)
        {
            DAO = new EmpMemberDAO(conn);
        }


        public DataTable queryEmpMobiDevReg(
        string strADID,
        string strDeptID
        )
        {
            DataTable dt = DAO.queryEmpMobiDevReg(strADID, strDeptID);
            return dt;
        }

        // 查詢組織架構檔
        public DataTable queryEmpOrg()
        {
            DataTable dt = DAO.queryEmpOrg();
            return dt;
        }

        // 查詢記錄
        public void addQueryRecord(
            string strQueryIP,
            string strWsType,
            string strQueryCount,
            string strNoteDesc,
            string strChangeUserID
            )
        {
            DAO.addQueryRecord(strQueryIP, strWsType, strQueryCount, strNoteDesc, strChangeUserID);
        }

        // 查詢員工資料
        public DataTable queryEmpMember(
            string strADID, // AD_ID
            string strDeptID    // DeptID
            )
        {
            DataTable dt = DAO.queryEmpMember(strADID, strDeptID,"");
            return dt;
        }

        public DataTable queryEmpMember(
            string strADID, // AD_ID
            string strDeptID,    // DeptID
            string strBirthday
        )
        {
            DataTable dt = DAO.queryEmpMember(strADID, strDeptID, strBirthday);
            return dt;
        }

        public DataTable queryEmpOrg(
            string strADID,
            string strDeptID
            )
        {
            DataTable dt = DAO.queryEmpOrg(strADID, strDeptID);
            return dt;
        }

     // 是否可使用WS
        public bool canUserWS(
            string strAPIP,
            string strWsType,
            string strSystemCode
            )
        {
            return DAO.canUserWS(
            strAPIP,
            strWsType,
            strSystemCode
            );
        }

            // 查詢代理人
        public DataTable queryAgent(
            string strADID,
            string strDeptID
        )
        {
            return DAO.queryAgent(
                strADID,
                strDeptID
           );
        }

        public DataTable querySystemCanUse(
            string strADID,
            string strDeptID
            )
        {
            return DAO.querySystemCanUse(
                strADID,
                strDeptID
           );

        }

    }
}