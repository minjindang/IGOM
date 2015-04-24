using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
using System.Data;
using System.Transactions;

/// <summary>
/// Summary description for SAL1104
/// </summary>

namespace SAL.Logic
{
    public class SAL1104
    {
        SAL1104DAO dao = null;

        public SAL_SABASE ssbDAO = null;
        public SAL_SABANK ssbkDAO = null;
        public SACode saDAO = null;
        public SAL_EXAMINE_fee sefDAO = null;

        public SAL1104()
        {
            dao = new SAL1104DAO();
            ssbDAO = new SAL_SABASE();
            ssbkDAO = new SAL_SABANK();
            saDAO = new SACode();
            sefDAO = new SAL_EXAMINE_fee();
        }

        public DataTable GetBankCode()
        {
            return dao.SelectBankCode(LoginManager.OrgCode);
        }

        public DataTable GetItemCode()
        {
            return dao.SelectItemCode();
        }

        public DataTable GetDataByMeetdateMeetcontent(string meetdate, string Meeting_content)
        {
            return dao.SelectDataByMeetdateMeetcontent(meetdate, Meeting_content);
        }

        public string Apply(DataTable dtDetail, string flow_id,bool isSendflow)
        {
            return Apply(dtDetail, flow_id, false, isSendflow);
        }

        public string Apply(DataTable dtDetail, string flow_id, bool isResend, bool isSendflow)
        {
            string flowID = string.Empty;
            DataTable dtBudget = dtDetail.DefaultView.ToTable(true, "Budget_code");

            SYS.Logic.Flow flow = new SYS.Logic.Flow();
            flow = flow.GetObject(LoginManager.OrgCode, flow_id);

            if (isSendflow && isResend)
            {
                DataRow[] rows = dtBudget.Select("Budget_code=" + flow.Budget_code);
                if (rows == null || rows.Length <= 0)
                {
                    SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                    fd.Orgcode = LoginManager.OrgCode;
                    fd.FlowId = flow_id;
                    fd.LastOrgcode = LoginManager.OrgCode;
                    fd.LastDepartid = LoginManager.Depart_id;
                    fd.LastIdcard = LoginManager.UserId;
                    fd.LastName = LoginManager.UserName;
                    SYS.Logic.CommonFlow.RunSelfClose(fd);
                }
            }

            //if (!string.IsNullOrEmpty(flow_id) && dtBudget.Rows.Count > 1)
            //{
            //    throw new Exception("重送修改不可有不同預算來源!");
            //}

            if (isSendflow)
            {
                sefDAO.DeleteByFid(flow_id);
            }

            foreach (DataRow dr in dtBudget.Rows)
            {
                String tmpflow_id = flow_id;

                if (isSendflow && isResend && !flow.Budget_code.Equals(dr["Budget_code"].ToString()))
                    tmpflow_id = "";

                DataTable groupDT = dtDetail.Select(string.Format("Budget_code='{0}'", dr["Budget_code"])).CopyToDataTable();
                using (TransactionScope trans = new TransactionScope())
                {
                    string item_names = string.Empty;
                    foreach (DataRow groupDR in groupDT.Rows)
                    {
                        item_names += groupDR["Item_name"].ToString() + ",";
                    }
                    string applyAMTSum = groupDT.Compute("sum(Apply_amt)", "").ToString();

                    SYS.Logic.Flow f = new SYS.Logic.Flow();
                    f.Orgcode = LoginManager.OrgCode;
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                    f.FormId = "002006";
                    f.Reason = string.Format("申請{0}共計{1}元", item_names, applyAMTSum);
                    f.Budget_code = dr["Budget_code"].ToString();
                    f.FlowId = flow_id;

                    if (isSendflow)
                    {
                        if (string.IsNullOrEmpty(tmpflow_id))
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
                        }
                    }


                    flowID = f.FlowId;

                    foreach (DataRow groupDR in groupDT.Rows)
                    {
                        int applyAMT = Convert.ToInt32(groupDR["Apply_amt"]);
                        int health_Insurance = Convert.ToInt32(applyAMT>5000?applyAMT*0.02:0);
                        try
                        {
                          string Id = groupDR["Id"].ToString();
                          if (!string.IsNullOrEmpty(Id))
                          {
                              sefDAO.Modify(Convert.ToInt16(Id),flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), CommonFun.getYYYMMDD(),
                              groupDR["BASE_IDNO"].ToString(), groupDR["BASE_NAME"].ToString(), groupDR["BASE_SERVICE_PLACE_DESC"].ToString(), groupDR["BASE_DCODE_NAME"].ToString(),
                              groupDR["Meeting_pos"].ToString(), groupDR["Meeting_date"].ToString(), groupDR["Meeting_content"].ToString(), groupDR["BASE_ADDR"].ToString(),
                              groupDR["Pay_type"].ToString(), groupDR["BASE_BANK_CODE"].ToString(), groupDR["BASE_BANK_NO"].ToString(), "", groupDR["Budget_code"].ToString(), groupDR["Item_code"].ToString(),
                              applyAMT, health_Insurance, applyAMT - health_Insurance, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);
                          }
                          else {
                              sefDAO.Add(flowID, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), CommonFun.getYYYMMDD(),
                              groupDR["BASE_IDNO"].ToString(), groupDR["BASE_NAME"].ToString(), groupDR["BASE_SERVICE_PLACE_DESC"].ToString(), groupDR["BASE_DCODE_NAME"].ToString(),
                              groupDR["Meeting_pos"].ToString(), groupDR["Meeting_date"].ToString(), groupDR["Meeting_content"].ToString(), groupDR["BASE_ADDR"].ToString(),
                              groupDR["Pay_type"].ToString(), groupDR["BASE_BANK_CODE"].ToString(), groupDR["BASE_BANK_NO"].ToString(), "", groupDR["Budget_code"].ToString(), groupDR["Item_code"].ToString(),
                              applyAMT, health_Insurance, applyAMT - health_Insurance, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now);                          
                          }
                        }
                        catch (Exception ex)
                        {
                            string aa = ex.Message;
                        }
                      
                        if (!Convert.ToBoolean(groupDR["exists"]))
                        {
                            //取得新的 非員工編號
                            string newSEQNO = dao.GetNewSEQNO();

                            ssbDAO.Add(newSEQNO, groupDR["BASE_IDNO"].ToString(), "N", "1", LoginManager.OrgCode, groupDR["BASE_NAME"].ToString(), "", "", "", "", "", groupDR["Meeting_pos"].ToString(), "", "", "", "", "", "", "",
                                "", "", groupDR["BASE_ADDR"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", double.MinValue, double.MinValue, double.MinValue, double.MinValue,
                                double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, "", "", LoginManager.UserId, DateTime.Now.ToString("yyyyMMhh"),
                                "", "", "", double.MinValue, double.MinValue, double.MinValue, "", "", "", double.MinValue, double.MinValue, "", "", double.MinValue, double.MinValue, double.MinValue, "", "",
                                double.MinValue, "", "", "", double.MinValue, double.MinValue, "", double.MinValue, "", "", "", "", "", double.MinValue, "", "", "", "", "", "", "", "", "");
                            System.Diagnostics.Debug.WriteLine(string.Format("{0},{1},{2}", newSEQNO, groupDR["BASE_BANK_CODE"].ToString(), groupDR["BASE_BANK_NO"].ToString()));
                            if (!string.IsNullOrEmpty(groupDR["BASE_BANK_CODE"].ToString()) && !string.IsNullOrEmpty(groupDR["BASE_BANK_NO"].ToString()))
                            {
                                ssbkDAO.Add(newSEQNO, LoginManager.OrgCode, "", groupDR["BASE_BANK_CODE"].ToString(), groupDR["BASE_BANK_NO"].ToString(), "", "", "");
                            }
                           
                        }
                    }


                    trans.Complete();
                }
            }
            

            return flowID;

        }

        public DataTable getDataByOrgFid(string Orgcode, string flow_id)
        {
            DataTable dt = dao.getDataByOrgFid(Orgcode, flow_id);
            dt.Columns.Add(new DataColumn("exists", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("Index", typeof(System.Int16)));
            foreach (DataRow dr in dt.Rows)
            {
                dr["exists"] = "false";
            }
            return dt;
        }

        public DataTable getDataByOrgUserId(string orgcode, string userId)
        {
            DataTable dt = dao.getDataByOrgUserId(orgcode, userId);
            dt.Columns.Add(new DataColumn("exists", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("Index", typeof(System.Int16)));
            foreach (DataRow dr in dt.Rows)
            {
                dr["exists"] = "false";
            }
            return dt;
        }

        public void Delete(String id)
        {
            sefDAO.Remove(CommonFun.ConvertToInt(id));
        }
    }
}