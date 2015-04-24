using FSCPLM.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web; 
/// <summary>
/// Summary description for CAR1101
/// </summary>
/// 
namespace CAR.Logic
{
    public class CAR1101
    {
        private CAR1101DAO dao = null;
        public SACode saCode = null;
        public CAR_CarDispatch_main ccdmDAO = null;
        public CAR_CarDispatch_det  ccddDAO = null;
        public Car_main cmDAO = null;

        public CAR1101()
        {
            dao = new CAR1101DAO();
            saCode = new SACode();
            ccdmDAO = new CAR_CarDispatch_main();
            ccddDAO = new CAR_CarDispatch_det();
            cmDAO = new Car_main();
            
        }

        public string Apply(string Car_type, string Car_id, string Car_name, int Passenger_cnt, string Start_date, string End_date, 
            string Start_time, string End_time, string Departure_date, string Departure_time, string Reason_desc, string Use_type, 
            string Urgent_type, string Destination_desc, string Location, string Use_frequency, string Repeat_weekday, string Repeat_day,string flow_id )
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
                f.FormId = "003006";
                //f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName) + LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name) + "申請"+ Car_name+ Reason_desc ;
                //SYS.Logic.CommonFlow.AddFlow(f);

                if (string.IsNullOrEmpty(flow_id))
                {
                    f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                    SYS.Logic.CommonFlow.AddFlow(f);
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

                    ccddDAO.RemoveByFlow_id(flow_id, LoginManager.OrgCode);
                    ccdmDAO.Remove(flow_id, LoginManager.OrgCode);
                }

                flowID = f.FlowId;

                //新增主檔
                //int mainID = stfmDAO.Add(flowID, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, CommonFun.getYYYMMDD(DateTime.Now),
                //    "", GetLastestFee_source(), LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);

                //DataTable dtTimes = saCode.GetData("015", "006");

                if (Use_frequency == "001")//單日
                {
                    End_date = Start_date; 
                    //End_time = dtTimes.Rows[dtTimes.Rows.Count - 1]["CODE_DESC1"].ToString();
                    ccddDAO.Add(LoginManager.OrgCode, flowID, Car_id, Start_date, Start_time,End_time, false, "", LoginManager.UserId, DateTime.Now);
                    Repeat_weekday = "";
                    Repeat_day = "";
                }
                else if (Use_frequency == "002")//每日重覆
                {
                    DateTime dtStart = CommonFun.getYYYMMDD(Start_date);
                    DateTime dtEnd = CommonFun.getYYYMMDD(End_date);
                    TimeSpan ts1 = new TimeSpan(dtStart.Ticks );
                    TimeSpan ts2 = new TimeSpan(dtEnd.Ticks );
                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                    for (int i = 0; i <= ts.Days ; i++)
			        {
                        ccddDAO.Add(LoginManager.OrgCode, flowID, Car_id, CommonFun.getYYYMMDD(dtStart.AddDays(i)), Start_time, End_time, false, 
                           "", LoginManager.UserId, DateTime.Now);
			        }
                    Repeat_weekday = "";
                    Repeat_day = "";
                }
                else if (Use_frequency == "003")//每週重覆
                {
                    DateTime dtStart = CommonFun.getYYYMMDD(Start_date);
                    DateTime dtEnd = CommonFun.getYYYMMDD(End_date);
                    TimeSpan ts1 = new TimeSpan(dtStart.Ticks);
                    TimeSpan ts2 = new TimeSpan(dtEnd.Ticks);
                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                    for (int i = 0; i <= ts.Days/7; i++)
                    {
                        ccddDAO.Add(LoginManager.OrgCode, flowID, Car_id, CommonFun.getYYYMMDD(dtStart.AddDays(7 * i)), Start_time, End_time, false,
                            "", LoginManager.UserId, DateTime.Now);
                    }
                    Repeat_day = "";
                }
                else if (Use_frequency == "004")//每月重覆
                {
                    DateTime dtStart = CommonFun.getYYYMMDD(Start_date);
                    DateTime dtEnd = CommonFun.getYYYMMDD(End_date);
                    int Months = dtEnd.Month - dtStart.Month;

                    for (int i = 0; i <= Months; i++)
                    {
                        ccddDAO.Add(LoginManager.OrgCode, flowID, Car_id, CommonFun.getYYYMMDD(dtStart.AddMonths(i)), Start_time, End_time, false,
                           "", LoginManager.UserId, DateTime.Now);
                    }
                    Repeat_weekday = "";
                }

                ccdmDAO.Add(LoginManager.OrgCode, flowID, Car_type, Car_id, Passenger_cnt, Start_date, End_date, Start_time, End_time, Departure_date, Departure_time,
                    Reason_desc, Use_type, Urgent_type, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, "", Destination_desc,
                    LoginManager.UserId, DateTime.Now, Location, Use_frequency, Repeat_weekday, Repeat_day);

                //foreach (DataRow dr in dtDetail.Rows)
                //{

                //    stfdDAO.Add(mainID, dr["Cost_date"].ToString(), Convert.ToInt32(dr["Apply_amt"]), dr["Apply_desc"].ToString(), LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);
                //}
                trans.Complete();
            }

            return flowID;

        }

        public DataTable GetDataByOrgFid(string Orgcode, string flow_id)
        {
            return dao.SelectDataByOrgFid(Orgcode, flow_id);
        }
    }
}