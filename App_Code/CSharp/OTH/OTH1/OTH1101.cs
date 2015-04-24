using FSCPLM.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for OTH1101
/// </summary>
namespace OTH.Logic
{
    public class OTH1101
    {
        private OTH_Broadcast_main obm = null;
        public SACode saDAO = null;

        public OTH1101()
        {
            obm = new OTH_Broadcast_main();
            saDAO = new SACode();
        }

        public string Done(string broadcast_date1, string broadcast_time1, string broadcast_date2, string broadcast_time2, string broadcast_floors, string broadcast_content)
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
                    f.FormId = "003010";
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);

                    f.Reason = "廣播時間：" + broadcast_date1 + broadcast_time1;
                    if (broadcast_date2 != "" && broadcast_time2 != "")
                    {
                        f.Reason += "、" + broadcast_date2 + broadcast_time2;
                    }

                    SYS.Logic.CommonFlow.AddFlow(f);

                    flowID = f.FlowId;

                    // OTH_Broadcast_main
                    obm.Add(LoginManager.OrgCode, flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id),
                        broadcast_date1, broadcast_time1, broadcast_date2, broadcast_time2, broadcast_floors, broadcast_content, LoginManager.UserId, DateTime.Now);



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