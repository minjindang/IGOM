using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4114 的摘要描述
/// </summary>
 
namespace SALPLM.Logic
{
    public class SAL4114
    {
        private SAL4114DAO DAO;

        public SAL4114()
        {
            DAO = new SAL4114DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        

        public SAL4114(SqlConnection conn)
        {
            DAO = new SAL4114DAO(conn);
        }

                

        //查詢
        public DataTable get_data(string orgid) 
        {
            DataTable dt = DAO.get_data(orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //GridView data
        public DataTable get_GridViewdata(string orgid)
        {
            DataTable dt = DAO.get_GridViewdata(orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }


        //delete data
        public DataTable GetDataBySeqno(string orgid, string seqno)
        {
            DataTable dt = DAO.GetDataBySeqno(orgid, seqno);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }



        //新增
        public void insert(
                  string orgid
                , string mid
                , string sdno
                , string Mdate
            )   
        {
            DAO.insert(orgid, mid,sdno, Mdate);    
        }


        //刪除
        public void delete(
                  string orgid
                , string seqno
            )
        {
            DAO.delete(orgid, seqno);
        }


        //修改unit
        public void queryeditData_unit(
                  string UNIT_DEP
                , string UNIT_NO
                , string UNIT_KIND
                , string UNIT_TAX
                , string UNIT_HNAME
                , string UNIT_CNAME
                , string UNIT_TEL
                , string UNIT_MEDIA
                , string UNIT_AREA
                , string UNIT_ADDR
                , string UNIT_RECOMPENSE_FUND
                , string UNIT_MULTI_MONTHPAY
                , string UNIT_LABOR_CALM_RATE
                , string UNIT_USERID
                , string UNIT_MDATE
          )
        {
            DAO.queryeditData_unit(UNIT_DEP, UNIT_NO, UNIT_KIND, UNIT_TAX, UNIT_HNAME, UNIT_CNAME, UNIT_TEL, UNIT_MEDIA, UNIT_AREA,
            UNIT_ADDR, UNIT_RECOMPENSE_FUND, UNIT_MULTI_MONTHPAY, UNIT_LABOR_CALM_RATE, UNIT_USERID, UNIT_MDATE);
        }



        //修改tdpf
        public void queryeditData_tdpf(
                  string tdpf_orgid
                , string tdpf_bank_no
                , string tdpf_bank
                , string tdpf_medi
                , string tdpf_muser
                , string tdpf_mdate
                , string tdpf_seqno
                , string tdpf_title
                , string tdpf_entno
                , string tdpf_unit
                , string tdpf_branch
                , string tdpf_custom
                , string tdpf_no
                , string tdpf_param
                , string tdpf_memo
          )
        {
            DAO.queryeditData_tdpf(tdpf_orgid, tdpf_bank_no, tdpf_bank, tdpf_medi, tdpf_muser, tdpf_mdate, tdpf_seqno, tdpf_title,
                tdpf_entno, tdpf_unit, tdpf_branch, tdpf_custom, tdpf_no, tdpf_param, tdpf_memo);
        }





    }
}