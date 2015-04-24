using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


// 對應FSC0102
public partial class Mobile_MOB0_MOB0204_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;

        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "待辦/待核清單";
        Bind();
    }

    private void Back2LastPage(object sender, EventArgs e)
    {
        Response.Redirect("~/Mobile/main.aspx");
    }


    protected void Bind()
    {
        
//        string level = Request.QueryString("level");
        string nextOrgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string nextDepartId = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string nextIdcard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();

        string formId = "001001";// 僅請假部分 // UcDDLForm.SelectedValue;
        string flowId = tbFlowId.Text.Trim();
//        string dispatchDate = "";// UcDate.Text;
        DataTable dt = new DataTable();


        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        //
        //FSC.Logic.Personnel psn = new FSC.Logic.Personnel();

/*
        if (level != null)
        {
            string parentDepartId = "";
            DataRow dr = new FSC.Logic.Org().GetDataByDepartid(nextOrgcode, nextDepartId);
            if (dr != null)
            {
                parentDepartId = dr["parent_depart_id"].ToString();

                DataTable pdt = psn.GetDataByBossLevelId(nextOrgcode, parentDepartId, level);
                if (pdt != null && pdt.Rows.Count > 0)
                {
                    foreach (DataRow pdr in pdt.Rows)
                    {
                        dt.Merge(bll.GetNextData(formId, flowId, dispatchDate, pdr["orgcode"].ToString(), pdr["depart_id"].ToString(), pdr["Id_card"].ToString()));
                    }
                }
            }

        }
        else
        {
 */
//            dt = bll.GetNextData(formId, flowId, dispatchDate, nextOrgcode, nextDepartId, nextIdcard);
//        }
        dt = wsmob.WSMOB039(formId, flowId, nextOrgcode, nextDepartId, nextIdcard);
        formId = "001002";
        dt.Merge(wsmob.WSMOB039(formId, flowId, nextOrgcode, nextDepartId, nextIdcard));

        // 相關參數帶入


        gv.DataSource = dt;
        gv.DataBind();
      
    }

    protected string getCodeType(string CodeType)
    {
        string strRv = "";
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        strRv = wsmob.WSMOB040(CodeType);
        return strRv;

    }

    protected void cbAgree_Click(object sender, EventArgs e)
    {
        RunFlow(1);
    }

    protected void RunFlow(int agreeFlag)
    {

        string lastOrgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string lastDepartId = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string lastPosid = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Title_no);
        string lastIdcard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        string lastName = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.User_name);
//        StringBuilder err = new StringBuilder();

        bool chk = false;
        List<SYS.Logic.FlowDetail> fdList = new List<SYS.Logic.FlowDetail>();
        string err = "";
        foreach (System.Web.UI.WebControls.GridViewRow gvr in gv.Rows)
        {
            if (!((CheckBox)gvr.FindControl("gvcbx")).Checked)
            {
                continue;
            }

            string orgcode = ((System.Web.UI.WebControls.Label)gvr.FindControl("gvlbOrgcode")).Text;
            string flowId = ((System.Web.UI.WebControls.Label)gvr.FindControl("gvlbFlowId")).Text;
            //            string comment = ((UControl_SYS_UcComment)gvr.FindControl("gvUcComment")).Text;
            string comment = "";
            string groupId = ((System.Web.UI.WebControls.HiddenField)gvr.FindControl("gvhfGroupId")).Value;

            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
            string Submit = wsmob.WSMOB042(orgcode, flowId, groupId, agreeFlag, lastOrgcode, lastDepartId, lastIdcard, lastPosid, lastName);

            JObject obj = JsonConvert.DeserializeObject<JObject>(Submit);
            string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
            string message = obj.Property("message").Value.ToString();
            if (strisSuccess == "Y")
            {
                chk = true;
            }
            else
            {
                err += message;
            }

            /*
            try
            {
                //checkReword(orgcode, flowId) '敘獎申請最後一關檢核

                if (2 == agreeFlag & "0" != groupId)
                {
                    throw new FlowException("不可退件!");
                }

                SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                fd.Orgcode = orgcode;
                fd.FlowId = flowId;
                fd.LastOrgcode = lastOrgcode;
                fd.LastDepartid = lastDepartId;
                fd.LastPosid = lastPosid;
                fd.LastIdcard = lastIdcard;
                fd.LastName = lastName;
                fd.AgreeFlag = agreeFlag;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = comment;
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Account);
                fdList.Add(fd);


                using (TransactionScope trans = new TransactionScope())
                {
                    SYS.Logic.CommonFlow.RunFlow(fd);

                    trans.Complete();
                    chk = true;
                }

            }
            catch (FlowException fex)
            {
                err += "表單(" + flowId + ")，" + fex.Message + "。\n";
                //                err.Append("表單(" + flowId + ")，" + fex.Message() + "。\\n");
            }
            catch (Exception ex)
            {
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
                err += "批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員。\n";
                //                err.Append("批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員。\\n");
            }
             * */
        }

        if (chk)
        {
            foreach (SYS.Logic.FlowDetail fd in fdList)
            {
                // 先 MArk 
                // 會掛
                //SendNotice.sendAll(fd.Orgcode, fd.FlowId);
            }
        }
        else
        {
            if (err.Length <= 0)
            {
                err += "至少需勾選一筆。\n";
                //                err.Append("至少需勾選一筆。\\n");
            }
        }

        if (err.Length > 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, err, "", "");
            this.Page = tempPage;
            //            CommonFun.MsgShow(this, CommonFun.Msg.Custom, err.ToString());
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "批核成功!", "", "");
            this.Page = tempPage;
        }

        /*

        MOBServices wsmob = new MOBServices();
        string Submit = wsmob.WSMOB042(gv, agreeFlag, lastOrgcode, lastDepartId, lastIdcard, lastPosid, lastName);

        JObject obj = JsonConvert.DeserializeObject<JObject>(Submit);
        string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
        string message = obj.Property("message").Value.ToString();
        if (strisSuccess == "Y")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "批核成功!", "", "");
            this.Page = tempPage;
            //            Response.Redirect("MOB1203_01.aspx");
        }
        else
        {
            //false
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, message, "", "");
            this.Page = tempPage;
        }


/*
        bool chk = false;
        List<SYS.Logic.FlowDetail> fdList = new List<SYS.Logic.FlowDetail>();

        foreach (GridViewRow gvr in gv.Rows)
        {
            if (!((CheckBox)gvr.FindControl("gvcbx")).Checked)
            {
                continue;
            }
            string orgcode = ((Label)gvr.FindControl("gvlbOrgcode")).Text;
            string flowId = ((Label)gvr.FindControl("gvlbFlowId")).Text;
//            string comment = ((UControl_SYS_UcComment)gvr.FindControl("gvUcComment")).Text;
            string comment = "";
            string groupId = ((HiddenField)gvr.FindControl("gvhfGroupId")).Value;

            try
            {
                //checkReword(orgcode, flowId) '敘獎申請最後一關檢核

                if (2 == agreeFlag & "0" != groupId)
                {
                    throw new FlowException("不可退件!");
                }

                SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                fd.Orgcode = orgcode;
                fd.FlowId = flowId;
                fd.LastOrgcode = lastOrgcode;
                fd.LastDepartid = lastDepartId;
                fd.LastPosid = lastPosid;
                fd.LastIdcard = lastIdcard;
                fd.LastName = lastName;
                fd.AgreeFlag = agreeFlag;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = comment;
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Account);
                fdList.Add(fd);


                using (TransactionScope trans = new TransactionScope())
                {
                    SYS.Logic.CommonFlow.RunFlow(fd);

                    trans.Complete();
                    chk = true;
                }

            }
            catch (FlowException fex)
            {
                err.Append("表單(" + flowId + ")，" + fex.Message() + "。\\n");
            }
            catch (Exception ex)
            {
                AppException.WriteErrorLog(ex.StackTrace(), ex.Message());
                err.Append("批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員。\\n");
            }
        }

        if (chk)
        {
            foreach (SYS.Logic.FlowDetail fd in fdList)
            {
                SendNotice.sendAll(fd.Orgcode, fd.FlowId);
            }
        }
        else
        {
            if (err.Length <= 0)
            {
                err.Append("至少需勾選一筆。\\n");
            }
        }

        if (err.Length > 0)
        {
            CommonFun.MsgShow(this, CommonFun.Msg.Custom, err.ToString());
        }
        else
        {
            CommonFun.MsgShow(this, CommonFun.Msg.Custom, "批核成功!");
            Bind();
        }
 */
    }

    protected void cbQuery_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void cbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }


    protected void check_all_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gv.Rows.Count; i++)
        {
            CheckBox ch = (CheckBox)gv.Rows[i].FindControl("gvcbx");
            ch.Checked = true;
        }
    }


    protected void clean_all_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gv.Rows.Count; i++)
        {
            CheckBox ch = (CheckBox)gv.Rows[i].FindControl("gvcbx");
            ch.Checked = false;
        }
    }
}