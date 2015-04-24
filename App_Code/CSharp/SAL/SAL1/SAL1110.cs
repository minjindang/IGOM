using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;
using System.Data;
using FSC.Logic;

/// <summary>
/// Summary description for SAL1110
/// </summary>

namespace SAL.Logic
{
    public class SAL1110
    {
        SAL1110DAO dao = null;
        SAL_PROOF_rpt sprDAO = null;
        SAL_EDU_Setting sesDAO = null;
        Personnel personnelDAO = null;

        public SAL1110()
        {
            dao = new SAL1110DAO();
            sprDAO = new SAL_PROOF_rpt();
            sesDAO = new SAL_EDU_Setting();
            personnelDAO = new Personnel();
        }

        public string canUse()
        {
            string msg = string.Empty;
            
            DataTable dt = sesDAO.GetAll(LoginManager.OrgCode,"002");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string now = CommonFun.getYYYMMDD() + DateTime.Now.ToString("hhmm");
                
                if (dr["Status"].ToString() != "Y" ||
                    Convert.ToInt64(now) < Convert.ToInt64((dr["Apply_sDate"].ToString() + dr["Apply_sTime"].ToString())) ||
                    Convert.ToInt64(now) > Convert.ToInt64((dr["Apply_eDate"].ToString() + dr["Apply_eTime"].ToString())))
                {
                    msg += @"此作業鎖定 不可申請\n";
                }

            }
            return msg;
        }

        public string Apply(string Apply_yy, ref string flow_id)
        {
            string msg = string.Empty;
            try
            {
                //DataTable dt = sprDAO.GetAll(LoginManager.UserId, Apply_yy);
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    msg =  "該年度已申請過";
                //}
                using (TransactionScope trans = new TransactionScope())
                {
                    string Employee_type = personnelDAO.GetColumnValue("Employee_type", LoginManager.UserId);

                    SYS.Logic.Flow f = new SYS.Logic.Flow();
                    f.Orgcode = LoginManager.OrgCode;
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                    f.FormId = Employee_type != "3" ? "002013" : "002012";                    
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                    f.Reason = string.Format("{0}申請{1}年度之證明資料。", personnelDAO.GetColumnValue("User_name", LoginManager.UserId), Apply_yy);                     
                    SYS.Logic.CommonFlow.AddFlow(f);
                    flow_id = f.FlowId;


                    sprDAO.Add(flow_id, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), Apply_yy, CommonFun.getYYYMMDD(),
                        LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);                    

                    trans.Complete();
                }


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }


        public void Upd(string Apply_yy, string orgcode, string flow_id)
        {
            string Employee_type = personnelDAO.GetColumnValue("Employee_type", LoginManager.UserId);
            SYS.Logic.Flow f = new SYS.Logic.Flow();
            f.Orgcode = LoginManager.OrgCode;
            f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
            f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
            f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
            f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
            f.FormId = Employee_type != "3" ? "002013" : "002012";
            f.FlowId = flow_id;
            f.Reason = string.Format("{0}申請{1}年度之證明資料。", personnelDAO.GetColumnValue("User_name", LoginManager.UserId), Apply_yy);     
            f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
            f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
            f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
            f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
            f.WriteTime = DateTime.Now;
            f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
            f.CaseStatus = 2;
            f.Update();

            sprDAO.Update(Apply_yy, orgcode, flow_id);           
        }

        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {
            return dao.GetDataByOrgFid(orgcode, flowId);
        }

        public DataTable getCheckData(string Apply_yy, string User_id)
        {
            return dao.getCheckData(Apply_yy, User_id);
        }
    }
}