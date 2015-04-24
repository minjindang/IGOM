using FSCPLM.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for SAL1108
/// </summary>

namespace SAL.Logic
{
    public class SAL1108
    {
        private SAL1108DAO dao = null;
        public SAL_VOL_feeDtl svfdDAO = null;
        public SAL_VOL_fee svfmDAO = null;

        public SAL1108()
        {
            dao = new SAL1108DAO();
            svfdDAO = new SAL_VOL_feeDtl();
            svfmDAO = new SAL_VOL_fee();
        }
        public DataTable GetNewFlowid(string OrgCode)
        {
            return svfmDAO.SelectGetNewFlowid(OrgCode);
        }

        public string GetLastestFee_source()
        {
            DataTable dtMain = svfmDAO.GetAll(LoginManager.OrgCode, LoginManager.UserId, "");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        }

        public DataTable GetSAbase(string BASE_IDNO, string BASE_NAME)
        {
            return dao.SelectSAbase(BASE_IDNO, BASE_NAME, "012", "N");
        }

        public string Add(string Apply_ym, DataTable dtDetail, string flow_id)
        {
            string flowID = string.Empty;
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
                f.FormId = "002010";
                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = string.Format("共申請{0}筆環保志工服務費資料。", dtDetail.Rows.Count);
                f.Budget_code = Fee_source;
                if (string.IsNullOrEmpty(flow_id))
                {
                    SYS.Logic.CommonFlow.AddFlow(f);

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        DataTable dt = dao.getCheckData(Apply_ym, dr["BASE_SEQNO"].ToString());
                        if (dt != null && dt.Rows.Count > 0)
                            throw new FlowException(dt.Rows[0]["User_name"].ToString() + "已於申請年月" + Apply_ym + "已申請過，不可重複申請!");
                    }
                }
               
                else
                {
                    f.Orgcode = LoginManager.OrgCode;
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                    f.WriteTime = DateTime.Now;
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                    f.FlowId = flow_id;
                    f.CaseStatus = 2;
                    f.Update();

                    svfmDAO.Remove(int.Parse(dtDetail.Rows[0]["Id"].ToString()));
                    svfdDAO.RemoveMainId(dtDetail.Rows[0]["main_id"].ToString());
                }

                flowID = f.FlowId;
                ////新增主檔
                int mainID = svfmDAO.Add(flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), Apply_ym, CommonFun.getYYYMMDD(DateTime.Now),
                    Fee_source, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);

                foreach (DataRow dr in dtDetail.Rows)
                {
                    svfdDAO.Add(mainID, dr["BASE_SEQNO"].ToString(), Convert.ToInt32(dr["Apply_amt"]), LoginManager.OrgCode, LoginManager.UserId, DateTime.Now); 
                }
                trans.Complete();
            }

            return flowID;

        }

    }
}