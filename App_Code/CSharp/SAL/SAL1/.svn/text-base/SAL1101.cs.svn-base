using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
using System.Data;
using System.Transactions;
using FSC.Logic;

/// <summary>
/// Summary description for SAL1101
/// </summary>
/// 

namespace SAL.Logic
{
    public class SAL1101
    {
        public SAL_TRAFFIC_FEE stfmDAO = null;
        public Personnel personnelDAO = null;
        public Org orgDAO = null;
        public SAL1101DAO dao = null;

	    public SAL1101()
	    {
            stfmDAO = new SAL_TRAFFIC_FEE();
            personnelDAO = new Personnel();
            dao = new SAL1101DAO();
            orgDAO = new Org();
	    } 

        public string GetLastestFee_source()
        {
            DataTable dtMain = stfmDAO.GetAll(LoginManager.OrgCode,LoginManager.UserId,"");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        }

        public DataTable GetData(String orgcode, String userId)
        {
            SACode code = new SACode();
            DataTable dt = stfmDAO.GetDataByNoFlowId(orgcode, userId);

            dt.Columns.Add(new DataColumn("Depart_name"));
            dt.Columns.Add(new DataColumn("PEMEMCOD"));
            dt.Columns.Add(new DataColumn("User_name"));

            foreach (DataRow dr in dt.Rows)
            {
                dr["Depart_name"] = orgDAO.GetDepartName(orgcode, dr["unit_code"].ToString());

                dr["PEMEMCOD"] = code.GetCodeDesc("023", "022", personnelDAO.GetColumnValue("Employee_type", dr["User_id"].ToString()));
                dr["User_name"] = personnelDAO.GetColumnValue("User_name", dr["User_id"].ToString());
            }

            return dt;
        }

        public void InsertFee(String flowId, String departId, String userId, String Cost_date, int Apply_amt, String Apply_desc)
        {
            string Fee_source = GetLastestFee_source();

            stfmDAO.Add(flowId, departId, userId, CommonFun.getYYYMMDD(DateTime.Now),
                "", Fee_source, LoginManager.OrgCode, LoginManager.Account, DateTime.Now, Cost_date, Apply_amt, Apply_desc);
        }

        public void UpdateFee(String id, String Cost_date, int Apply_amt, String Apply_desc)
        {
            stfmDAO.Modify(CommonFun.ConvertToInt(id), "", "", "", "",
                "", "", "", LoginManager.Account, DateTime.Now, Cost_date, Apply_amt, Apply_desc);
        }

        public void DeleteFee(String id)
        {
            stfmDAO.Remove(CommonFun.ConvertToInt(id));
        }

        public string Add(DataTable dt)
        {
            string flowID = string.Empty;
            using (TransactionScope trans = new TransactionScope())
            {
                string Apply_amt = dt.Compute("sum(Apply_amt)", "").ToString();
                string Fee_source = GetLastestFee_source();
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.FormId = "002003";
                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = "共申請金額:" + Apply_amt;
                f.Budget_code = Fee_source;
                SYS.Logic.CommonFlow.AddFlow(f);

                flowID = f.FlowId;

                foreach (DataRow dr in dt.Rows)
                {
                    //update flow_id 
                    stfmDAO.Modify(CommonFun.ConvertToInt(dr["id"].ToString()), flowID, "", "", "",
                        "", "", "", LoginManager.Account, DateTime.Now, "", -1, "");
                }
                                
                trans.Complete();
            }

            return flowID;

        }

        public void Upd(DataTable dt, string orgcode, string flowID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                string Fee_source = GetLastestFee_source();
                string Apply_amt = dt.Compute("sum(Apply_amt)", "").ToString();

                SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(orgcode, flowID);
                f.Reason = "共申請金額:" + Apply_amt;                
                f.Update();

                trans.Complete();
            }
        }

        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {            
            return dao.GetDataByOrgFid(orgcode, flowId);
        }
    }
}