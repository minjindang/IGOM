using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
using System.Transactions;
using FSCPLM.Logic;

/// <summary>
/// Summary description for SAL1107
/// </summary>
namespace SAL.Logic
{
    public class SAL1107
    {
        SAL1107DAO dao = null;
        SAL_TRANS_fee sttmDAO = null;
        SAL_TRANS_feeDtl sttdDAO = null;

        public SAL1107()
        {
            dao = new SAL1107DAO();
            sttmDAO = new SAL_TRANS_fee();
            sttdDAO = new SAL_TRANS_feeDtl();
        }
        public DataTable GetNewFlowid(string OrgCode)
        {
            return sttmDAO.SelectGetNewFlowid(OrgCode);
        }
        public DataTable GetEmployee()
        {
            return dao.SelectEmployee("14");
        }

        public string GetLastestFee_source()
        {
            DataTable dtMain = sttmDAO.GetAll(LoginManager.OrgCode,LoginManager.UserId,"");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        } 

        public string Apply(string Apply_ym, DataTable dtDetail, string flow_id)
        {
            string flowID = flow_id; // string.Empty;
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
                f.FormId = "002009";
                f.Reason = string.Format("共申請{0}筆替代役交通費資料。",dtDetail.Rows.Count );
                f.Budget_code = Fee_source;

                int mainID = 0;
   
                if (string.IsNullOrEmpty(flow_id))
                {
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        DataTable dt = dao.getCheckData(Apply_ym, dr["Non_id"].ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            throw new FlowException(dt.Rows[0]["User_name"].ToString() + "已於申請年月" + Apply_ym + "已申請過，不可重複申請!");
                        }
                    }

                    SYS.Logic.CommonFlow.AddFlow(f);

                    //新增主檔
                    mainID = sttmDAO.Add(f.FlowId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, Apply_ym,
                     CommonFun.getYYYMMDD(), "", Fee_source, LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);
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

                    mainID = sttmDAO.update(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), flow_id);
                    sttdDAO.DeleteByOrgFid(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), flow_id);
                }

                flowID = f.FlowId;

                foreach (DataRow dr in dtDetail.Rows)
                {
                    sttdDAO.Add(mainID, Convert.ToInt32(dr["Apply_amt"]), dr["Non_id"].ToString(), LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);
                     
                }
                trans.Complete();
            }

            return flowID;

        }
    }
}