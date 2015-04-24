using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for OTH1102
/// </summary>
namespace OTH.Logic
{
    public class OTH1102
    {
        private OTH_InfoNet_Service_det oisd = null;
        private OTH_InfoNet_Service_main oism = null;

        public OTH1102()
        {
            oisd = new OTH_InfoNet_Service_det();
            oism = new OTH_InfoNet_Service_main();
        }

        public string Done(string apply_type,string apply_type_desc,string apply_reason,string apply_StartDate,string apply_EndDate,
                            string apply_acc_req,string newMac_addr,string chgMac_addr,string oldMac_addr,
                            string equipRoom_type,string equipRoom_Memo,string dns_ip,string dns_host,string port_open,string admin_sys,
                            ref DataTable dt)
        {
            string msg = string.Empty;
            string flowID = string.Empty;
            //flowID = new Random().Next(1000000).ToString().PadLeft(7,'0');
            try
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
                    f.FormId = "003009";
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                    SYS.Logic.CommonFlow.AddFlow(f);

                    flowID = f.FlowId;

                    oism.Add(LoginManager.OrgCode, flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), apply_acc_req,
                        apply_type_desc, apply_reason, apply_StartDate, apply_EndDate, apply_acc_req, newMac_addr, chgMac_addr, oldMac_addr, equipRoom_type, equipRoom_Memo,
                        dns_ip, dns_host, port_open, admin_sys, LoginManager.UserId, DateTime.Now);

                    foreach (DataRow dr in dt.Rows)
                    {
                        oisd.Add(LoginManager.OrgCode, flowID, dr["direction"].ToString(), dr["resource_ip"].ToString(), dr["goal_ip"].ToString(),
                            dr["reason"].ToString(), LoginManager.UserId, DateTime.Now);

                    }

                    trans.Complete();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            

            return msg;
        }

    }
}