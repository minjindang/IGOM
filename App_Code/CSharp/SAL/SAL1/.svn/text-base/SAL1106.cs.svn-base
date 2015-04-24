using FSC.Logic;
using FSCPLM.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for SAL1106
/// </summary>

namespace SAL.Logic
{
    public class SAL1106
    {
        private SAL1106DAO dao = null;
        public SAL_SABASE sabaseDAO = null;
        public Personnel personnelDAO = null;
        public FSC_Settlement_Annual fsaDAO = null;
        public SAL_EDU_Setting sesDAO = null;

        public SAL1106()
        {
            dao = new SAL1106DAO();
            sabaseDAO = new SAL_SABASE();
            personnelDAO = new Personnel();
            fsaDAO = new FSC_Settlement_Annual();
            sesDAO = new SAL_EDU_Setting();
        }

        public string canUse()
        {
            string msg = string.Empty;
            string Employee_type = personnelDAO.GetColumnValue("Employee_type", LoginManager.UserId);
            switch (Employee_type)
            {
                case "1":
                case "3":
                case "8":
                //case "11":
                    break;
                default:
                    //msg += @"員工類別為 正式人員、技工工友、司機、駐衛警 方可使用\n";
                    msg += @"員工類別為 正式人員、技工工友、司機 方可使用\n";
                    break;
            }

            // 系統時間不存在於Apply_sDate+Apply_sTime,Apply_eDate+Apply_eTime區間
            // 或Status不等於'Y'
            // 則此作業鎖定所有輸入欄位及按鈕，不可讓使用者申請。
            DataTable dt = sesDAO.GetAll(LoginManager.OrgCode, "003");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                long lNow =Convert.ToInt64( CommonFun.getYYYMMDD() + DateTime.Now.ToString("hhmm"));
                long lStime=Convert.ToInt64((dr["Apply_sDate"].ToString() + dr["Apply_sTime"].ToString()));
                long lEtime=Convert.ToInt64((dr["Apply_eDate"].ToString() + dr["Apply_eTime"].ToString()));

                if (dr["Status"].ToString().ToUpper() != "Y")
                {
                    msg += @"此作業鎖定 不可申請\n";
                }

                if (lNow< lStime || lNow >lEtime)
                {
                    msg += @"此作業鎖定 不可申請\n";
                }

            }
            return msg;
        }

        public string GetLastestFee_source()
        {
            DataTable dtMain = fsaDAO.GetAll(LoginManager.UserId, "");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Budget_fee"].ToString();
            }
            return "001";
        }

        public object GetLeaveType(string Id_card, string sDate, string eDate, string eTime, int type)
        {
            return dao.GetLeaveType(Id_card, sDate, eDate, eTime, type);
        }

        public string GetBASE_DAY_SAL(string Apply_yy)
        {

            DataRow dr = sabaseDAO.GetOne(LoginManager.UserId);
            if (dr != null)
            {
                return CommonFun.SetDataRow(ref dr, "BASE_DAY_SAL").ToString();
            }
            return "0";
        }

        public string Apply(string Apply_yy, int PEHDAY, int LeaveType1, int LeaveType2, int LeaveType3, int LeaveType4,
            int PEHDAY2, int BaseDaySAL, int Apply_fee, double payDays, string User_id)
        {
            string flowID = string.Empty;
            using (TransactionScope trans = new TransactionScope())
            {
                Personnel psn = new Personnel().GetObject(User_id);
                DataTable dt = new DepartEmp().GetDataByServiceType(User_id, "0");
                if (dt == null || dt.Rows.Count <= 0)
                    throw new FlowException("查無該人員服務單位!");

                string Fee_source = GetLastestFee_source();
                string Employee_type = psn.EmployeeType;
                string User_name = psn.UserName;
                string Title_no = psn.TitleNo;
                string Orgcode = dt.Rows[0]["Orgcode"].ToString();
                string Depart_id = dt.Rows[0]["Depart_id"].ToString();

                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = Orgcode;
                f.DepartId = Depart_id;
                f.ApplyPosid = Title_no;
                f.ApplyIdcard = User_id;
                f.ApplyName = User_name;
                f.ApplyStype = "0";
                f.FormId = Employee_type == "1" ? "002008" : "002018";
                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = string.Format("申請{0}天，用計{1}元", payDays, Apply_fee);
                f.Budget_code = Fee_source;
                SYS.Logic.CommonFlow.AddFlow(f);

                flowID = f.FlowId;

                fsaDAO.Add(flowID, Orgcode, Depart_id, User_id, User_name, Title_no, CommonFun.getYYYMMDD().Substring(0, 3), CommonFun.getYYYMMDD(),
                    LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), Fee_source, PEHDAY, LeaveType1,
                    LeaveType2, LeaveType3, LeaveType4, PEHDAY2, payDays, BaseDaySAL, Apply_fee, double.MinValue, double.MinValue, double.MinValue,
                    double.MinValue, "", "", "", "", DateTime.Now);


                trans.Complete();
            }


            return flowID;

        }


        public void Upd(string Apply_yy, int PEHDAY, int LeaveType1, int LeaveType2, int LeaveType3, int LeaveType4,
                        int PEHDAY2, int BaseDaySAL, int Apply_fee, double payDays, string orgcode, string flowID, string User_id)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                Personnel psn = new Personnel().GetObject(User_id);
                DataTable dt = new DepartEmp().GetDataByServiceType(User_id, "0");
                if (dt == null || dt.Rows.Count <= 0)
                    throw new FlowException("查無該人員服務單位!");

                string Fee_source = GetLastestFee_source();
                string Employee_type = psn.EmployeeType;
                string User_name = psn.UserName;
                string Title_no = psn.TitleNo;
                string Orgcode = dt.Rows[0]["Orgcode"].ToString();
                string Depart_id = dt.Rows[0]["Depart_id"].ToString();

                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);

                f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.WriteTime = DateTime.Now;
                f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.FormId = Employee_type == "1" ? "002008" : "002018";
                f.FlowId = flowID;
                f.Reason = string.Format("申請{0}天，用計{1}元", payDays, Apply_fee);
                f.CaseStatus = 2;
                f.Update();

                fsaDAO.Delete(orgcode, flowID);

                fsaDAO.Add(flowID, Orgcode, Depart_id, User_id, User_name, Title_no, CommonFun.getYYYMMDD().Substring(0, 3), CommonFun.getYYYMMDD(),
                    LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), Fee_source, PEHDAY, LeaveType1,
                    LeaveType2, LeaveType3, LeaveType4, PEHDAY2, payDays, BaseDaySAL, Apply_fee, double.MinValue, double.MinValue, double.MinValue,
                    double.MinValue, "", "", "", "", DateTime.Now);

                trans.Complete();
            }
        }


        public DataTable GetDayaByOrgFid(string orgcode, string flowId)
        {
            return dao.GetDayaByOrgFid(orgcode, flowId);
        }

        public DataTable getPersonnel(string id_card, string id_card2, string User_name)
        {
            return dao.getPersonnel(id_card, id_card2, User_name);
        }
    }
}