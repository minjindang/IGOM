using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
using System.Transactions;
using FSC.Logic;

/// <summary>
/// Summary description for SAL1109
/// </summary>

namespace SAL.Logic
{
    public class SAL1109
    {
        SAL1109DAO dao = null;
        SAL_SAPARAMETER ssDAO = null;
        SAL_SASTAN sstDAO = null;
        SAL_ALLOWANCE_fee safDAO = null;
        public SACode saDAO = null;
        public Personnel personnelDAO = null;

        public SAL1109()
        {
            dao = new SAL1109DAO();
            ssDAO = new SAL_SAPARAMETER();
            sstDAO = new SAL_SASTAN();
            safDAO = new SAL_ALLOWANCE_fee();
            saDAO = new SACode();
            personnelDAO = new Personnel();
        }

        public string GetLastestFee_source()
        {
            DataTable dtMain = safDAO.GetAll(LoginManager.OrgCode,LoginManager.UserId,"");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        }

        public string GetApply_amt(string codeNo, ref double value)
        {
            string msg = string.Empty;
            string ym = DateTime.Now.ToString("yyyyMM");
            //取得類別倍率    
            DataTable dt = ssDAO.GetAll("P", codeNo ,"006", "015", ym);
            if (dt != null)
            {
                //取得  kdb 本俸種類, ptb 本俸俸點
                double val1 = Convert.ToDouble(dt.Rows[0]["PARAMETER_VALUE"]);
                DataRow dr = GetBaseSalary();
                if (dr != null)
                {
                    string kdb = dr["BASE_KDB"].ToString();
                    string ptb = dr["BASE_PTB"].ToString();
                    //取得每月奉額(本俸)
                    DataTable dtTAN = sstDAO.GetAll(kdb, ptb, ym);
                    if (dtTAN != null && dtTAN.Rows.Count > 0)
                    {
                        // 申請金額 = 奉額*倍率 (val2 * val1)
                        value = val1 * Convert.ToDouble(dtTAN.Rows[0]["STAN_SAL"]);
                    }
                    else
                        msg = "無本俸";
                }else
                    msg = "無本俸設定";
            }
            else
                msg = "無類別倍率";
           
            return msg;
        }

        public DataRow GetBaseSalary()
        {
            DataTable dt = dao.SelectBaseSalary(LoginManager.OrgCode, LoginManager.UserId);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;

        }

        public string Apply(string Apply_type, string Relation_type, int Apply_amt, ref string flow_id, string Event_date)
        {
            string msg = string.Empty;
            try
            { 
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
                    f.FormId = "002011";
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                    f.Reason = saDAO.GetCodeDesc("006", "015", Apply_type) + Apply_amt + "元";
                    f.Budget_code = Fee_source;
                    SYS.Logic.CommonFlow.AddFlow(f);

                    flow_id = f.FlowId;

                    safDAO.Add(flow_id, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), CommonFun.getYYYMMDD(),
                        Fee_source, Apply_type, Relation_type, Apply_amt, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now, Event_date);
                   
                    trans.Complete();
                }

             
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public void Upd(string Apply_type, string Relation_type, int Apply_amt, string Event_date, string orgcode, string flow_id)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(orgcode, flow_id);
                f.CaseStatus = 2;
                f.Reason = saDAO.GetCodeDesc("006", "015", Apply_type) + Apply_amt + "元";
                f.Update();

                safDAO.Update(Apply_type, Relation_type, Apply_amt, Event_date, orgcode, flow_id);

                trans.Complete();
            }
        }
        public DataTable CheckApply(string Apply_type, string userid)
        {
            return dao.CheckApply(Apply_type, userid);
        }
        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {
            return dao.GetDataByOrgFid(orgcode, flowId);
        }
    }
}