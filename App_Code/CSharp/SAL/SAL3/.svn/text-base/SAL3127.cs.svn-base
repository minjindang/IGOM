using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3127 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL3127
    {
        private SAL3127DAO DAO;

        public SAL3127()
        {
            DAO = new SAL3127DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL3127(SqlConnection conn)
        {
            DAO = new SAL3127DAO(conn);
        }

        //ddldata
        public DataTable queryddlData(string strOrgCode//登入者機關代碼
            , string strTYPE  //發放方式代碼
            , string strcode  //項目類別代碼
            , string strddl   //是否隨薪代碼
            )  
        {
            DataTable dt = DAO.getddlData(strOrgCode, strTYPE, strcode, strddl);
            if (dt == null || dt.Rows.Count==0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }


        //ddl2data 
        public DataTable queryddl2Data(string strOrgCode//登入者機關代碼
            , string name  //項目名稱代碼           
            )
        {
            DataTable dt = DAO.getddl2Data(strOrgCode, name);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        //ddl2datatext
        public DataTable queryddl2textData(string textno//所得格式代碼         
            )
        {
            DataTable dt = DAO.getddl2textData(textno);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        public void querydeleteData(string strOrgCode//登入者機關代碼
            )
        {
            DAO.querydeleteData(strOrgCode);  
        }


        //查員工編號  
        public DataTable queryseqnoData(string strOrgCode
            , string idno         
            )
        {
            DataTable dt = DAO.getseqnoData(strOrgCode, idno);
         
                return dt;

        }

        //所得類別代碼 
        public DataTable geticode(string v_icode
            )
        {
            DataTable dt = DAO.geticode(v_icode);        
                return dt;
        }

        public void insertSABASE(string v_idno, string v_name, string v_inco_addr)
        {
            DAO.insertSABASE(v_idno, v_name, v_inco_addr);
        }

        public void updateSABASE(string v_orgid, string v_seqno, string v_idno, string v_name, string v_inco_addr)
        {
            DAO.updateSABASE(v_orgid, v_seqno, v_idno, v_name, v_inco_addr);
        }


        //get prikey
        public DataTable querydprikeyData( )
        {
            DataTable dt = DAO.getprikeyData();
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }


        public void queryinsertData(
              string v_orgid
            , string v_seqno
            , string PAYITEM_flow_id
            , string PAYITEM_merge_flow_id
            , string v_code_sys
            , string v_code_type
            , string v_code_no
            , string v_code
            , string PAYITEM_Budget_code
            , string v_amt
            , string v_mid
       
        )
        {
            DAO.queryinsertData(v_orgid, v_seqno, PAYITEM_flow_id, PAYITEM_merge_flow_id, v_code_sys, v_code_type, v_code_no, v_code,
                PAYITEM_Budget_code, v_amt, v_mid);
        }

/*
        public void querygropData(string v_mid
        , string v_mdate
        , string v_orgid
        , string v_code_sys
        , string v_code_type
        , string v_code_no
        , string v_code
    )
        {
            DAO.querygropData(v_mid, v_mdate, v_orgid, v_code_sys, v_code_type, v_code_no, v_code);
        }
*/

        public void querydelete2Data(string strOrgCode  
)
        {
            DAO.querydelete2Data(strOrgCode);
        }

        public void querydelete3Data(string strOrgCode    
        , string v_code_sys
        , string v_code_type
        , string v_code_no
        , string v_code
)
        {
            DAO.querydelete3Data(strOrgCode, v_code_sys, v_code_type, v_code_no, v_code);
        }


        public void queryinsert2Data(string v_kind
    , string v_seqno
    , string v_orgid
    , string v_inco_date
    , string v_icode
    , string v_inco_amt
    , string v_inco_txra
    , string v_inco_txam
    , string v_inco_fee
    , string v_inco_fees
    , string v_inco_leave_self
    , string v_inco_leave_sup
    , string v_mid
    , string v_mdate
    , string v_inco_ym
    , string key
    , string v_code_type
    , string v_code_no
    , string v_code
)
        {
            DAO.queryinsert2Data(v_kind, v_seqno, v_orgid, v_inco_date, v_icode,
                v_inco_amt, v_inco_txra, v_inco_txam, v_inco_fee, v_inco_fees,
               v_inco_leave_self, v_inco_leave_sup, v_mid, v_mdate, v_inco_ym, key
               ,v_code_type,v_code_no,v_code);
        }


        public void insertinco(string v_orgid
         , string v_seqno
         , string v_icode
         , string v_inco_date
         , string v_inco_ym
         , string v_inco_no
         , string v_inco_amt
         , string v_inco_real_amt
         , string v_inco_txam
         , string v_inco_rent_no
         , string v_inco_vouchers
         , string v_inco_summons
         , string key
         , string budget_code
)
        {
            DAO.insertinco(v_orgid, v_seqno, v_icode, v_inco_date, v_inco_ym, v_inco_no, v_inco_amt, v_inco_real_amt, v_inco_txam
                , v_inco_rent_no, v_inco_vouchers, v_inco_summons, key, budget_code);
        }



        public DataTable querykindData(string v_orgid
                 
            )
        {
            DataTable dt = DAO.getkindData(v_orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }

        }

        //GridView1 data
        public DataTable querytableData(string v_orgid
          )
        {
            DataTable dt = DAO.gettableData(v_orgid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        //Columns[0]
        public DataTable exists_flag(string v_orgid
            , string inco_code
            , string inco_icode
            , string inco_seqno
            , string inco_date
            , string inco_kind_code_type
            , string inco_kind_code_no
            , string inco_kind_code        
      )
        {
            DataTable dt = DAO.exists_flag(v_orgid, inco_code, inco_icode, inco_seqno, inco_date, inco_kind_code_type, inco_kind_code_no, inco_kind_code);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }



        public void queryinsert3Data(string v_orgid, string v_chg_kind, string v_kind)
        {
            DAO.queryinsert3Data(v_orgid, v_chg_kind, v_kind);
        }


    }
}