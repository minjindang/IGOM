using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
using System.Data;
using System.Transactions;

/// <summary>
/// Summary description for SAL1105
/// </summary>
/// 

namespace SAL.Logic
{

    public class SAL1105
    {
        public SAL_HealthSubsidy_fee shsfDAO = null;
        SAL1105DAO dao = null;

        public SAL1105()
        {
            shsfDAO = new SAL_HealthSubsidy_fee();
            dao = new SAL1105DAO();
        } 

        public string GetLastestFee_source()
        {
            DataTable dtMain = shsfDAO.GetAll(LoginManager.OrgCode,LoginManager.UserId,"");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        }

        public string Apply(string Apply_yy, string Check_date, int Apply_amt, string flow_id)
        {
            string flowID = flow_id; //string.Empty;
            using (TransactionScope trans = new TransactionScope())
            {
                string Fee_source = GetLastestFee_source();
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.FormId = "002007";
                f.Reason = string.Format("申請年度：{0}年，健檢日期：{1}，申請金額：{2}", Apply_yy, Check_date, Apply_amt);
                f.Budget_code = Fee_source;

                if (string.IsNullOrEmpty(flow_id))
                {
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                    SYS.Logic.CommonFlow.AddFlow(f);

                    shsfDAO.Add(f.FlowId, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), CommonFun.getYYYMMDD(),
                        Apply_yy, Check_date, Apply_amt, Fee_source, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);
                }
                else
                {
                    f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                    f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                    f.WriteTime = DateTime.Now;
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                    f.FlowId = flow_id;
                    f.CaseStatus = 2;
                    f.Update();

                    shsfDAO.UpdateByOrgFid(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), f.FlowId, Apply_yy, Check_date, Apply_amt);
                }
                flowID = f.FlowId;

                trans.Complete();
            }


            return flowID;

        }

        public DataTable GetReportData( string Apply_yy)
        {
            return dao.SelectReportData(LoginManager.OrgCode, LoginManager.UserId, Apply_yy);
        }
    }
}