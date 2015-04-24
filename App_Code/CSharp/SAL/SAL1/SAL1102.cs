using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for SAL1102
/// </summary>
namespace SAL.Logic
{
    public class SAL1102
    {
        private SAL1102DAO dao = null;

        public SAL_DUTY_fee sdfmDAO = null;
        public SAL_DUTY_feeDtl sdfdDAO = null;

        public SAL1102()
        {
            dao = new SAL1102DAO();
            sdfmDAO = new SAL_DUTY_fee();
            sdfdDAO = new SAL_DUTY_feeDtl();
        }

        public DataTable GetDutyInfoByFlow(string flow_id)
        {
            return dao.SelectDutyInfo(flow_id);
        }

        public DataTable GetDutyInfo(string yyyyMM)
        {
            return dao.SelectDutyInfo(LoginManager.OrgCode, yyyyMM);
        }

        public void Upd(DataTable dtDetail, string orgcode, string flowID, string Apply_ym)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.FormId = "002004";
                f.FlowId = flowID;
                f.Reason = string.Format("共申請{0}筆值班費請領。", dtDetail.Rows.Count);
                f.Budget_code = "001";
                f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.WriteTime = DateTime.Now;
                f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.CaseStatus = 2;
                f.Update();

                DataTable dt = sdfmDAO.GetAll(orgcode, "", flowID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int mid = CommonFun.getInt(dt.Rows[0]["id"].ToString());
                    sdfdDAO.RemoveByMainId(mid);
                    sdfmDAO.Remove(mid);
                }
                


                //新增主檔
                int mainID = sdfmDAO.Add(flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), "001", Apply_ym, CommonFun.getYYYMMDD(DateTime.Now),
                    "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);

                foreach (DataRow dr in dtDetail.Rows)
                {

                    sdfdDAO.Add(mainID, dr["Duty_date"].ToString(), dr["Duty_sTime"].ToString(), dr["Duty_eTime"].ToString(), dr["Duty_Hours"].ToString(), Convert.ToInt16(dr["ApplyHour_cnt"]),
                        Convert.ToInt16(dr["Apply_amt"]), dr["Is_rest"].ToString(), LoginManager.OrgCode, dr["MEMO"].ToString(), LoginManager.UserId, DateTime.Now, dr["Id_card"].ToString(),
                        dr["Depart_id"].ToString());
                }

                trans.Complete();
            }
        }

        public string Apply(string Apply_ym,DataTable dtDetail)
        {
            string flowID = string.Empty;
            using (TransactionScope trans = new TransactionScope())
            {
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.FormId = "002004";
                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = string.Format("共申請{0}筆值班費請領。", dtDetail.Rows.Count);
                f.Budget_code = "001";
                SYS.Logic.CommonFlow.AddFlow(f);

                flowID = f.FlowId;

                //新增主檔
                int mainID = sdfmDAO.Add(flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id),"001",Apply_ym, CommonFun.getYYYMMDD(DateTime.Now),
                    "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);

                foreach (DataRow dr in dtDetail.Rows)
                {

                    sdfdDAO.Add(mainID, dr["Duty_date"].ToString(), dr["Duty_sTime"].ToString(), dr["Duty_eTime"].ToString(), dr["Duty_Hours"].ToString(), Convert.ToInt16(dr["ApplyHour_cnt"]),
                        Convert.ToInt16(dr["Apply_amt"]), dr["Is_rest"].ToString(), LoginManager.OrgCode, dr["MEMO"].ToString(), LoginManager.UserId, DateTime.Now, dr["Id_card"].ToString(),
                        dr["Depart_id"].ToString());
                }


                trans.Complete();
            }


            return flowID;

        }
    }
}