using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data;

public partial class FSC0101_10 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        BindInit();
        BindData();
    }

    protected void BindInit()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();

        //申請類別
        rblMaintain_kind.DataSource = code.GetData("020", "**");
        rblMaintain_kind.DataBind();
        rblMaintain_kind.SelectedIndex = 0;

        //申請項目
        ddlMaintain_type.DataSource = code.GetData("020", rblMaintain_kind.SelectedValue);
        ddlMaintain_type.DataBind();

        //作業類別
        ddlOperate_type.DataSource = code.GetData("019", "001");
        ddlOperate_type.DataBind();

        //服務類型
        ddlService_type.DataSource = code.GetData("019", "002");
        ddlService_type.DataBind();

        //處理狀態
        ddlStatus_type.DataSource = code.GetData("019", "003");
        ddlStatus_type.DataBind();

        //處理型態
        ddlHandle_type.DataSource = code.GetData("019", "004");
        ddlHandle_type.DataBind();

        //維運登錄
        ddlMaintain_code.DataSource = code.GetData("019", "013");
        ddlMaintain_code.Items.Insert(0, new ListItem("請選擇", ""));
                        
        //轉單申請類別
        rblChangeMaintain_kind.DataSource = code.GetData("020", "**");
        rblChangeMaintain_kind.DataBind();
        rblChangeMaintain_kind.SelectedIndex = 0;

        //轉單申請項目
        ddlChangeMaintain_type.DataSource = code.GetData("020", rblChangeMaintain_kind.SelectedValue);
        ddlChangeMaintain_type.DataBind();
        
        //拆單申請類別
        rblDividMaintain_kind.DataSource = code.GetData("020", "**");
        rblDividMaintain_kind.DataBind();
        rblDividMaintain_kind.SelectedIndex = 0;

        //拆單申請項目
        ddlDividMaintain_type.DataSource = code.GetData("020", rblDividMaintain_kind.SelectedValue);
        ddlDividMaintain_type.DataBind();   
    }

    protected void BindAuthority(String kind, String type)
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        Panel1.Visible = false; //轉單
        Panel2.Visible = false; //拆單

        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];
        String step = Request.QueryString["step"];

        SYS.Logic.FlowNext fn = new SYS.Logic.FlowNext();
        fn = fn.GetObject(org, fid, LoginManager.OrgCode, LoginManager.Depart_id, LoginManager.UserId, step);
        

        if (kind == "004")
        {
            //進出電腦機房申請 (第三類)
            tbHandle.Visible = false;

            SYS.Logic.Flow f = new SYS.Logic.Flow();
            f = f.GetObject (org,fid);

            DataRow r = code.GetRow("020", kind, type);
            if (LoginManager.RoleId.IndexOf(r["code_remark1"].ToString()) > 0 || f.LastPass == 1)
                tbHandleEroom.Visible = true;

            if ((f.CaseStatus == 0 && f.ApplyIdcard != LoginManager.UserId) || (f.CaseStatus == 1 && f.LastPass != 1))
            {
                tbStatus.Visible = true;
                cbConfirm.Visible = true;
            }
            else
                SetAllReadOnly();
        }
        else if(kind == "005")
        {
            //水電報修 (第二類)
            SYS.Logic.Flow f = new SYS.Logic.Flow();
            f = f.GetObject(org, fid);

            //DataRow r = code.GetRow("020", kind, type);
            //if (LoginManager.RoleId.IndexOf(r["code_remark1"].ToString()) > 0 && LoginManager.UserId != f.ApplyIdcard)
            if ((f.CaseStatus == 0 && f.ApplyIdcard != LoginManager.UserId) || (f.CaseStatus == 1 && f.LastPass != 1))
            {
                tbStatus.Visible = true;
                cbConfirm.Visible = true;
            }
            else
            {
                tbStatus.Visible = false;
                cbConfirm.Visible = false;
                SetAllReadOnly();
            }
        }
        else
        { 
            // (第一類)
            trClass1.Visible = true;
            
            DataRow r = code.GetRow("020", kind, type);

            if (r != null && fn != null)
            {
                bool c = false;
                bool b = false;
                if ((fn.NextStep == 3 || fn.NextStep == 99) && LoginManager.UserId == r["code_remark1"].ToString())
                {
                    //承辦人
                    hfMaintainerType.Value = Convert.ToString((int)MAI.Logic.MAI1101.Maintainer_type.UnderTaker);
                    b = true;
                }
                if ((fn.NextStep == 1 || fn.NextStep == 99) && LoginManager.RoleId.Contains(r["code_remark2"].ToString()))
                {
                    //廠商
                    hfMaintainerType.Value = Convert.ToString((int)MAI.Logic.MAI1101.Maintainer_type.Firm);
                    b = true;
                }
                if (fn.NextIdcard == LoginManager.UserId)
                    c = true;

                if (c || b)
                {
                    tbStatus.Visible = true;
                    cbConfirm.Visible = true;

                    if (b && kind != "004" && kind != "005")
                    {

                        if (fn.NextStep != 99)
                        {
                            cbChangeForm.Visible = true;
                            cbDividForm.Visible = true;
                            Panel1.Visible = true;
                            Panel2.Visible = true;

                            if (hfMaintainerType.Value == "1")
                                lbTip.Visible = true;
                        }
                        else
                        {
                            cbCase_status_N.Visible = false;

                            if (hfMaintainerType.Value == "2")
                                lbTip.Visible = true;
                        }
                    }
                }
                else
                {
                    SetAllReadOnly();
                    UcMaiAttachment.isUpload = false;
                }
            }
            else
            {
                SetAllReadOnly();
                UcMaiAttachment.isUpload = false;
            }
        }

        UcFlowDetail.Orgcode = org;
        UcFlowDetail.FlowId = fid;
    }
    protected void SetAllReadOnly()
    {     
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "setAllReadOnly();", true);  
    }
    protected void BindData()
    {
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];

        SYS.Logic.Flow f = new SYS.Logic.Flow();
        MAI.Logic.MaintainMain main = new MAI.Logic.MaintainMain();

        f = f.GetObject(org, fid);
        main = main.GetObject(org, fid);

        SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
        List<SYS.Logic.FlowDetail> fdList =  fd.GetObjects(org, fid);
        if (fdList != null)
        {
            int i = 1;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (SYS.Logic.FlowDetail d in fdList)
            {
                sb.Append(i.ToString()+".").Append(d.LastName).Append("於"+d.AgreeTime).Append(d.AgreeFlag==1?"確認":"退件").Append("，"+d.Comment).Append("<br/>");
                i += 1;
            }
            lbFlowDetail.Text = sb.ToString();
        }


        if (main != null)
        {
            lbFlowId.Text = fid;

            lbUserName.Text = main.Apply_name;
            lbUserExt.Text = main.Apply_ext;
            rblMaintain_kind.SelectedValue = main.Maintain_kind;
            BindType();
            ddlMaintain_type.SelectedValue = main.Maintain_type;
            UcProblem_desc.Text = main.Problem_desc;
            hfMainId.Value = main.Id.ToString();
            lbWriter.Text = main.Writer_name;
            lbWriterExt.Text = main.Writer_ext;

            UcAttachment.FlowId = fid;
            UcAttachment.isUpload = false;

            rblMaintain_kind.Enabled = false;
            ddlMaintain_type.Enabled = false;
            UcProblem_desc.Enabled = false;
            
            MAI.Logic.MaintainHandle handle = new MAI.Logic.MaintainHandle();
            handle = handle.GetObject(CommonFun.getInt(hfMainId.Value));

            UcMaiAttachment.Orgcode = org;
            UcMaiAttachment.FlowId = fid;
            UcMaiAttachment.MainId = hfMainId.Value;
            UcMaiAttachment.isBind = true;

            BindAuthority(main.Maintain_kind, main.Maintain_type);

            FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
            DataRow r = code.GetRow("020", rblMaintain_kind.SelectedValue, ddlMaintain_type.SelectedValue);
            String roleId = r["code_remark2"].ToString();
            DataTable pdt = new FSC.Logic.Personnel().GetDataByRoleId(LoginManager.OrgCode, "", roleId);

            ddlHandle_idcard.DataSource = pdt;
            ddlHandle_idcard.DataBind();
            ddlHandle_idcard.Items.Insert(0, new ListItem("請選擇", ""));

            ddlConfirm_idcard.DataSource = pdt;
            ddlConfirm_idcard.DataBind();
            ddlConfirm_idcard.Items.Insert(0, new ListItem("請選擇", ""));

            if (main.Maintain_kind == "005")
            {
                //水電報修
                
                //處理狀態
                ddlStatus_type.DataSource = code.GetData("019", "006");
                ddlStatus_type.DataBind();

                ddlConfirm_idcard.Visible = false;
                ddlHandle_idcard.Visible = false;
            }

            if (handle != null)
            {
                ddlConfirm_idcard.SelectedValue = handle.Confirm_idcard;
                tbConfirm_name.Text = handle.Confirm_name;
                tbConfirm_ext.Text = handle.Confirm_ext;
                UcProblem_analyze.Text = handle.Problem_analyze;
                UcPredict_date.Text = handle.Predict_date;
                ddlHandle_idcard.SelectedValue = handle.Handle_idcard;
                tbHandle_name.Text = handle.Handle_name;
                tbHandle_ext.Text = handle.Handle_ext;
                ddlOperate_type.SelectedValue = handle.Operate_type.Trim();
                ddlService_type.SelectedValue = handle.Service_type.Trim();
                ddlStatus_type.SelectedValue = handle.Status_type.Trim();
                ddlHandle_type.SelectedValue = handle.Handle_type.Trim();
                UcHandle_desc.Text = handle.Handle_desc;
                UcDateTimeS.Text = handle.Handle_sdate;
                UcDateTimeS.Time = handle.Handle_stime;
                UcDateTimeE.Text = handle.Handle_edate;
                UcDateTimeE.Time = handle.Handle_etime;
                tbHandle_hours.Text = handle.Handle_hours;
                UcReply_date.Text = handle.Reply_date;
                ddlMaintain_code.SelectedValue = handle.Maintain_code;
                if (handle.Case_status.Equals("1"))
                    cbCase_status_Y.Checked = true;
                else if (handle.Case_status.Equals("2"))
                    cbCase_status_N.Checked = true;

                hfHandleId.Value = handle.Id.ToString();
                
            }

            if (rblMaintain_kind.SelectedValue == "003")
            {
                if (ddlMaintain_type.SelectedValue == "001")
                {
                    tbNet.Visible = true;

                    MAI.Logic.MaintainNet net = new MAI.Logic.MaintainNet();
                    DataTable dt = net.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                    ViewState["Netdt"] = dt;
                    gvNet.DataSource = dt;
                    gvNet.DataBind();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UcNetUse_sdate.Text = dt.Rows[0]["Use_sdate"].ToString();
                        UcNetUse_edate.Text = dt.Rows[0]["Use_edate"].ToString();
                    }
                    else BindTable();
                }
                else if (ddlMaintain_type.SelectedValue == "002")
                {

                    tbDNS.Visible = true;

                    MAI.Logic.MaintainDns dns = new MAI.Logic.MaintainDns();
                    DataTable dt = dns.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                    ViewState["Dnsdt"] = dt;
                    gvDNS.DataSource = dt;
                    gvDNS.DataBind();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UcDnsUse_sdate.Text = dt.Rows[0]["Use_sdate"].ToString();
                        UcDnsUse_edate.Text = dt.Rows[0]["Use_edate"].ToString();
                    }
                    else BindTable();

                }
                else if (ddlMaintain_type.SelectedValue == "003")
                {
                    tbServ.Visible = true;

                    MAI.Logic.MaintainServer serv = new MAI.Logic.MaintainServer();
                    DataTable dt = serv.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                    ViewState["Servdt"] = dt;
                    gvServ.DataSource = dt;
                    gvServ.DataBind();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UcServUse_sdate.Text = dt.Rows[0]["Use_sdate"].ToString();
                        UcServUse_edate.Text = dt.Rows[0]["Use_edate"].ToString();
                    }
                    else BindTable();
                }
            }
            else if (rblMaintain_kind.SelectedValue == "006")
            {
                if (ddlMaintain_type.SelectedValue == "001")
                {
                    tbAcc.Visible = true;

                    MAI.Logic.MaintainAcc acc = new MAI.Logic.MaintainAcc();
                    DataTable dt = acc.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                    ViewState["Accdt"] = dt;
                    gvAcc.DataSource = dt;
                    gvAcc.DataBind();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UcAccUse_sdate.Text = dt.Rows[0]["Use_sdate"].ToString();
                        UcAccUse_edate.Text = dt.Rows[0]["Use_edate"].ToString();
                    }
                    else BindTable();
                }
            }
            else if (rblMaintain_kind.SelectedValue == "007")
            {
                tbOth.Visible = true;

                MAI.Logic.MaintainOther oth = new MAI.Logic.MaintainOther();
                DataTable dt = oth.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                ViewState["Othdt"] = dt;
                gvOth.DataSource = dt;
                gvOth.DataBind();

                if (dt != null && dt.Rows.Count > 0)
                {
                    UcOthUse_sdate.Text = dt.Rows[0]["Use_sdate"].ToString();
                    UcOthUse_edate.Text = dt.Rows[0]["Use_edate"].ToString();
                }
                else BindTable();
            }
            else if (rblMaintain_kind.SelectedValue == "004")
            {
                tbEroom.Visible = true;
                MAI.Logic.MaintainEroom room = new MAI.Logic.MaintainEroom();
                DataTable dt = room.GetDataByMainId(CommonFun.getInt(hfMainId.Value));

                if (dt != null && dt.Rows.Count > 0)
                {
                    UcEnterDateTime.Text = dt.Rows[0]["Enter_date"].ToString();
                    UcEnterDateTime.Time = dt.Rows[0]["Enter_time"].ToString();
                    tbServer_name.Text = dt.Rows[0]["Server_name"].ToString();
                    tbApplication_name.Text = dt.Rows[0]["Application_name"].ToString();
                    rblCard_type.SelectedValue = dt.Rows[0]["Card_type"].ToString();
                    tbCard_nos.Text = dt.Rows[0]["Card_nos"].ToString();
                    rblDesc_flag.SelectedValue = dt.Rows[0]["Desc_flag"].ToString();
                    tbDescribe.Text = dt.Rows[0]["Describe"].ToString();
                    UcEquipment_desc.Text = dt.Rows[0]["Equipment_desc"].ToString();

                    UcEnterRealDateTime.Text = dt.Rows[0]["Enter_realdate"].ToString();
                    UcEnterRealDateTime.Time = dt.Rows[0]["Enter_realtime"].ToString();
                    tbEnter_signname.Text = dt.Rows[0]["Enter_signname"].ToString();

                    UcLeftRealDateTime.Text = dt.Rows[0]["Left_realdate"].ToString();
                    UcLeftRealDateTime.Time = dt.Rows[0]["Left_realtime"].ToString();
                    tbLeft_signname.Text = dt.Rows[0]["Left_signname"].ToString();
                }
                else BindTable();

                MAI.Logic.MaintainEroomDet rdet = new MAI.Logic.MaintainEroomDet();
                dt = rdet.GetDataByMainId(CommonFun.getInt(hfMainId.Value));
                ViewState["Eroomdt"] = dt;
                gvEroom.DataSource = dt;
                gvEroom.DataBind();

            }
        }
    }
    protected void rblMaintain_kind_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindType();
    }
    protected void BindType()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        ddlMaintain_type.DataSource = code.GetData("020", rblMaintain_kind.SelectedValue);
        ddlMaintain_type.DataBind();
    }
    protected void cbConfirm_Click(object sender, EventArgs e)
    {
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];

        MAI.Logic.MaintainMain main = new MAI.Logic.MaintainMain().GetObject(org,fid);
        Page p = this.Page;

        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (cbCase_status_N.Checked)
                    main.Maintain_step = null;
                
                main.Id = CommonFun.getInt(hfMainId.Value);
                main.Maintain_kind = rblMaintain_kind.SelectedValue;
                main.Maintain_type = ddlMaintain_type.SelectedValue;
                main.Problem_desc = UcProblem_desc.Text;
                main.Update();

                if (rblMaintain_kind.SelectedValue != "004")
                {
                    bool b = false;

                    MAI.Logic.MaintainHandle handle = new MAI.Logic.MaintainHandle();
                    handle.Orgcode = org;
                    handle.Flow_id = fid;
                    handle.Confirm_idcard = ddlConfirm_idcard.SelectedValue;
                    handle.Confirm_name = tbConfirm_name.Text;
                    handle.Confirm_ext = tbConfirm_ext.Text;
                    handle.Problem_analyze = UcProblem_analyze.Text;
                    handle.Predict_date = UcPredict_date.Text;

                    handle.Handle_idcard = ddlHandle_idcard.SelectedValue;
                    handle.Handle_name = tbHandle_name.Text;
                    handle.Handle_ext = tbHandle_ext.Text;
                    handle.Operate_type = ddlOperate_type.SelectedValue;
                    handle.Service_type = ddlService_type.SelectedValue;
                    handle.Status_type = ddlStatus_type.SelectedValue;
                    handle.Handle_type = ddlHandle_type.SelectedValue;
                    handle.Handle_desc = UcHandle_desc.Text;
                    handle.Handle_sdate = UcDateTimeS.Text;
                    handle.Handle_stime = UcDateTimeS.Time;
                    handle.Handle_edate = UcDateTimeE.Text;
                    handle.Handle_etime = UcDateTimeE.Time;
                    handle.Handle_hours = tbHandle_hours.Text;
                    handle.Reply_date = UcReply_date.Text;
                    handle.Case_status = "";

                    handle.Comment = UcComment.Text;
                    handle.Main_id = main.Id;

                    DataTable dt = handle.GetDataByMainId(main.Id);
                    if (dt == null || dt.Rows.Count <= 0)
                        b = handle.Insert();
                    else
                    {
                        handle.Id = CommonFun.getInt(hfHandleId.Value);
                        b = handle.Update();
                    }
                    if (!b)
                    {
                        CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateFail, "", "", "");
                        return;
                    }
                }

                AddDetialData(CommonFun.getInt(hfMainId.Value), org, fid);

                string Case_status = string.Empty;
                if (cbCase_status_Y.Checked)
                    Case_status = "1";
                else if (cbCase_status_N.Checked)
                    Case_status = "2";

                if (!string.IsNullOrEmpty(Case_status))
                {
                    SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                    fd.Orgcode = org;
                    fd.FlowId = fid;
                    fd.LastOrgcode = LoginManager.OrgCode;
                    fd.LastDepartid = LoginManager.Depart_id;
                    fd.LastPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                    fd.LastIdcard = LoginManager.UserId;
                    fd.LastName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                    fd.AgreeFlag = CommonFun.getInt(Case_status);
                    fd.AgreeTime = DateTime.Now;
                    fd.Comment = UcComment.Text;
                    fd.ChangeDate = DateTime.Now;
                    fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);

                    if (ddlStatus_type.SelectedValue == "003" && lbTip.Visible)
                        //處理完成
                        SYS.Logic.CommonFlow.RunSelfClose(fd);
                    else
                        SYS.Logic.CommonFlow.RunFlow(fd);

                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "批核成功!", "FSC0101_02.aspx", "");
                }
                else 
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
                    BindData();
                }

                scope.Complete();                
            }
        }
        catch (FlowException fex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, fex.Message, "", "");
        }
        
    }
    
    protected void AddDetialData(int mainId, String orgcode, String flowId)
    {
        if (rblMaintain_kind.SelectedValue == "003")
        {
            if (ddlMaintain_type.SelectedValue == "001")
            {
                MAI.Logic.MaintainNet net = new MAI.Logic.MaintainNet();
                net.DeleteDataByMainId(mainId);

                foreach (GridViewRow gvr in gvNet.Rows)
                {
                    net = new MAI.Logic.MaintainNet();
                    net.Main_id = mainId;
                    net.Orgcode = orgcode;
                    net.Flow_id = flowId;
                    net.Use_sdate = UcNetUse_sdate.Text;
                    net.Use_edate = UcNetUse_edate.Text;
                    net.Apply_type = ((RadioButtonList)gvr.FindControl("rblApply_type")).SelectedValue;
                    net.User_unit = ((TextBox)gvr.FindControl("gvtbUser_unit")).Text;
                    net.User_name = ((TextBox)gvr.FindControl("gvtbUser_name")).Text;
                    net.User_phone = ((TextBox)gvr.FindControl("gvtbUser_phone")).Text;
                    net.Mac_addr = ((TextBox)gvr.FindControl("gvtbMac_addr")).Text;
                    net.Old_macaddr = ((TextBox)gvr.FindControl("gvtbOld_macaddr")).Text;
                    net.Change_userid = LoginManager.Account;
                    net.Insert();
                }
            }
            else if (ddlMaintain_type.SelectedValue == "002")
            {
                MAI.Logic.MaintainDns dns = new MAI.Logic.MaintainDns();
                dns.DeleteDataByMainId(mainId);

                foreach (GridViewRow gvr in gvDNS.Rows)
                {
                    dns = new MAI.Logic.MaintainDns();
                    dns.Main_id = mainId;
                    dns.Orgcode = orgcode;
                    dns.Flow_id = flowId;
                    dns.Use_sdate = UcNetUse_sdate.Text;
                    dns.Use_edate = UcNetUse_edate.Text;
                    dns.Apply_type = ((RadioButtonList)gvr.FindControl("rblApply_type")).SelectedValue;
                    dns.Server_name = ((TextBox)gvr.FindControl("gvtbServer_name")).Text;
                    dns.Server_ip = ((TextBox)gvr.FindControl("gvtbServer_ip")).Text;
                    dns.Dns_name = ((TextBox)gvr.FindControl("gvtbDns_name")).Text;
                    dns.Firewall_port = ((TextBox)gvr.FindControl("gvtbFirewall_port")).Text;
                    dns.Change_userid = LoginManager.Account;
                    dns.Insert();
                }
            }
            else if (ddlMaintain_type.SelectedValue == "003")
            {
                MAI.Logic.MaintainServer serv = new MAI.Logic.MaintainServer();
                serv.DeleteDataByMainId(mainId);

                foreach (GridViewRow gvr in gvServ.Rows)
                {
                    serv = new MAI.Logic.MaintainServer();
                    serv.Main_id = mainId;
                    serv.Orgcode = orgcode;
                    serv.Flow_id = flowId;
                    serv.Use_sdate = UcNetUse_sdate.Text;
                    serv.Use_edate = UcNetUse_edate.Text;
                    serv.Apply_type = ((RadioButtonList)gvr.FindControl("rblApply_type")).SelectedValue;
                    serv.Server_name = ((TextBox)gvr.FindControl("gvtbServer_name")).Text;
                    serv.Cpu_nos = ((TextBox)gvr.FindControl("gvtbCpu_nos")).Text;
                    serv.Ram_size = ((TextBox)gvr.FindControl("gvtbRam_size")).Text;
                    serv.Hd_size = ((TextBox)gvr.FindControl("gvtbHd_size")).Text;
                    serv.Windows_ver = ((TextBox)gvr.FindControl("gvtbWindows_ver")).Text;
                    serv.Other_ver = ((TextBox)gvr.FindControl("gvtbOther_ver")).Text;
                    serv.Intra_flag = ((CheckBox)gvr.FindControl("gvtbIntra_flag")).Checked ? "1" : "0";
                    serv.Outer_flag = ((CheckBox)gvr.FindControl("gvtbOuter_flag")).Checked ? "1" : "0";
                    serv.Change_userid = LoginManager.Account;
                    serv.Insert();
                }
            }
        }
        else if (rblMaintain_kind.SelectedValue == "006")
        {
            if (ddlMaintain_type.SelectedValue == "001")
            {
                MAI.Logic.MaintainAcc acc = new MAI.Logic.MaintainAcc();
                acc.DeleteDataByMainId(mainId);

                foreach (GridViewRow gvr in gvAcc.Rows)
                {
                    acc = new MAI.Logic.MaintainAcc();
                    acc.DeleteDataByMainId(mainId);
                    acc.Main_id = mainId;
                    acc.Orgcode = orgcode;
                    acc.Flow_id = flowId;
                    acc.Use_sdate = UcNetUse_sdate.Text;
                    acc.Use_edate = UcNetUse_edate.Text;
                    acc.Apply_type = ((RadioButtonList)gvr.FindControl("rblApply_type")).SelectedValue;
                    acc.User_name = ((TextBox)gvr.FindControl("gvtbUser_name")).Text;
                    acc.Account = ((TextBox)gvr.FindControl("gvtbAccount")).Text;
                    acc.Change_userid = LoginManager.Account;
                    acc.Insert();
                }
            }
        }
        else if (rblMaintain_kind.SelectedValue == "007")
        {
            MAI.Logic.MaintainOther oth = new MAI.Logic.MaintainOther();
            oth.DeleteDataByMainId(mainId);

            foreach (GridViewRow gvr in gvOth.Rows)
            {
                oth = new MAI.Logic.MaintainOther();
                oth.Main_id = mainId;
                oth.Orgcode = orgcode;
                oth.Flow_id = flowId;
                oth.Use_sdate = UcNetUse_sdate.Text;
                oth.Use_edate = UcNetUse_edate.Text;
                oth.Apply_type = ((RadioButtonList)gvr.FindControl("rblApply_type")).SelectedValue;
                oth.User_name = ((TextBox)gvr.FindControl("gvtbUser_name")).Text;
                oth.Memo = ((TextBox)gvr.FindControl("gvtbMemo")).Text;
                oth.Change_userid = LoginManager.Account;
                oth.Insert();
            }
        }
        else if (rblMaintain_kind.SelectedValue == "004")
        {
            MAI.Logic.MaintainEroom room = new MAI.Logic.MaintainEroom();
            room.DeleteDataByMainId(mainId);

            room.Main_id = mainId;
            room.Orgcode = orgcode;
            room.Flow_id = flowId;
            room.Enter_date = UcEnterDateTime.Text;
            room.Enter_time = UcEnterDateTime.Time;
            room.Server_name = tbServer_name.Text;
            room.Application_name = tbApplication_name.Text;
            room.Card_type = rblCard_type.SelectedValue;
            room.Card_nos = tbCard_nos.Text;
            room.Desc_flag = rblDesc_flag.SelectedValue;
            room.Describe = tbDescribe.Text;
            room.Equipment_desc = UcEquipment_desc.Text;
            room.Enter_realdate = UcEnterRealDateTime.Text;
            room.Enter_realtime = UcEnterRealDateTime.Time;
            room.Enter_signname = tbEnter_signname.Text;
            room.Left_realdate = UcLeftRealDateTime.Text;
            room.Left_realtime = UcLeftRealDateTime.Time;
            room.Left_signname = tbLeft_signname.Text;
            room.Change_userid = LoginManager.Account;
            room.Insert();

            MAI.Logic.MaintainEroomDet rdet = new MAI.Logic.MaintainEroomDet();
            rdet.DeleteDataByMainId(mainId);

            foreach (GridViewRow gvr in gvEroom.Rows)
            {
                rdet = new MAI.Logic.MaintainEroomDet();
                rdet.Main_id = mainId;
                rdet.Orgcode = orgcode;
                rdet.Flow_id = flowId;
                rdet.Company = ((TextBox)gvr.FindControl("gvtbCompany")).Text;
                rdet.User_name = ((TextBox)gvr.FindControl("gvtbUser_name")).Text;
                rdet.Phone = ((TextBox)gvr.FindControl("gvtbPhone")).Text;
                rdet.Change_userid = LoginManager.Account;
                rdet.Insert();
            }

        }
    }

    #region "轉單"
    protected void rblChangeMaintain_kind_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChangeType();
        btnQuery_ModalPopupExtender.Show();
    }
    protected void BindChangeType()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        ddlChangeMaintain_type.DataSource = code.GetData("020", rblChangeMaintain_kind.SelectedValue);
        ddlChangeMaintain_type.DataBind();
    }
    protected void cbChangeCancel_Click(object sender, EventArgs e)
    {
        btnQuery_ModalPopupExtender.Hide();
    }
    protected void cbChangConfirm_Click(object sender, EventArgs e)
    {
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];
        Page page = this.Page;
        MAI.Logic.MAI1101 bll = new MAI.Logic.MAI1101();

        if (rblMaintain_kind.SelectedValue == rblChangeMaintain_kind.SelectedValue && ddlMaintain_type.SelectedValue == ddlChangeMaintain_type.SelectedValue)
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "與原申請項目相同!", "", "");            
            return;
        }

        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bll.ChangeFlow(org, 
                    fid, 
                    rblChangeMaintain_kind.SelectedValue, 
                    ddlChangeMaintain_type.SelectedValue, 
                    CommonFun.getInt(hfMaintainerType.Value), 
                    CommonFun.getInt(hfMainId.Value), 
                    UcComment.Text);
                             
                scope.Complete();
            }
            CommonFun.MsgShow(ref page, CommonFun.Msg.UpdateOK, "", "FSC0101_02.aspx", "");
        }
        catch (FlowException ex)
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, ex.Message, "", "");
        }
        btnQuery_ModalPopupExtender.Show();     
    }
    #endregion

    #region "拆單"
    protected void rblDividMaintain_kind_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDividType();
        btnQuery_ModalPopupExtender1.Show();
    }
    protected void BindDividType()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        ddlDividMaintain_type.DataSource = code.GetData("020", rblDividMaintain_kind.SelectedValue);
        ddlDividMaintain_type.DataBind();
    }
    protected void cbDividConfirm_Click(object sender, EventArgs e)
    {
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];
        Page page = this.Page;
        MAI.Logic.MAI1101 bll = new MAI.Logic.MAI1101();

        if (rblMaintain_kind.SelectedValue == rblDividMaintain_kind.SelectedValue && ddlMaintain_type.SelectedValue == ddlDividMaintain_type.SelectedValue)
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "與原申請項目相同!", "", "");
            return;
        }

        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bll.DividFlow(org,
                    fid,
                    rblDividMaintain_kind.SelectedValue,
                    ddlDividMaintain_type.SelectedValue, 
                    CommonFun.getInt(hfMaintainerType.Value),
                    CommonFun.getInt(hfMainId.Value));

                scope.Complete();
            }
            CommonFun.MsgShow(ref page, CommonFun.Msg.UpdateOK, "", "FSC0101_02.aspx", "");
        }
        catch (FlowException ex)
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, ex.Message, "", "");
        }
        btnQuery_ModalPopupExtender1.Show();
    }
    protected void cbDividCancel_Click(object sender, EventArgs e)
    {
        btnQuery_ModalPopupExtender1.Hide();
    }
    #endregion
    
    #region "GridView 控制"

    protected void BindTable()
    {
        tbNet.Visible = false;
        tbDNS.Visible = false;
        tbServ.Visible = false;
        tbAcc.Visible = false;
        tbOth.Visible = false;
        tbEroom.Visible = false;

        if (rblMaintain_kind.SelectedValue == "003")
        {
            if (ddlMaintain_type.SelectedValue == "001")
            {
                tbNet.Visible = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Apply_type", typeof(String));
                dt.Columns.Add("User_unit", typeof(String));
                dt.Columns.Add("User_name", typeof(String));
                dt.Columns.Add("User_phone", typeof(String));
                dt.Columns.Add("Mac_addr", typeof(String));
                dt.Columns.Add("Old_macaddr", typeof(String));

                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
                ViewState["Netdt"] = dt;
                gvNet.DataSource = dt;
                gvNet.DataBind();
            }
            else if (ddlMaintain_type.SelectedValue == "002")
            {
                tbDNS.Visible = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Apply_type", typeof(String));
                dt.Columns.Add("Server_name", typeof(String));
                dt.Columns.Add("Server_ip", typeof(String));
                dt.Columns.Add("Dns_name", typeof(String));
                dt.Columns.Add("Firewall_port", typeof(String));

                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
                ViewState["DNSdt"] = dt;
                gvDNS.DataSource = dt;
                gvDNS.DataBind();
            }
            else if (ddlMaintain_type.SelectedValue == "003")
            {
                tbServ.Visible = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Apply_type", typeof(String));
                dt.Columns.Add("Server_name", typeof(String));
                dt.Columns.Add("Cpu_nos", typeof(String));
                dt.Columns.Add("Ram_size", typeof(String));
                dt.Columns.Add("Hd_size", typeof(String));
                dt.Columns.Add("Windows_ver", typeof(String));
                dt.Columns.Add("Other_ver", typeof(String));
                dt.Columns.Add("Intra_flag", typeof(String));
                dt.Columns.Add("Outer_flag", typeof(String));

                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
                ViewState["Servdt"] = dt;
                gvServ.DataSource = dt;
                gvServ.DataBind();
            }
        }
        else if (rblMaintain_kind.SelectedValue == "006")
        {
            if (ddlMaintain_type.SelectedValue == "001")
            {
                tbAcc.Visible = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Apply_type", typeof(String));
                dt.Columns.Add("User_name", typeof(String));
                dt.Columns.Add("Account", typeof(String));

                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
                ViewState["Accdt"] = dt;
                gvAcc.DataSource = dt;
                gvAcc.DataBind();
            }
        }
        else if (rblMaintain_kind.SelectedValue == "007")
        {
            tbOth.Visible = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Apply_type", typeof(String));
            dt.Columns.Add("User_name", typeof(String));
            dt.Columns.Add("memo", typeof(String));

            DataRow dr = dt.NewRow();
            dr["Apply_type"] = "I";
            dt.Rows.Add(dr);
            ViewState["Othdt"] = dt;
            gvOth.DataSource = dt;
            gvOth.DataBind();
        }
        else if (rblMaintain_kind.SelectedValue == "004")
        {
            tbEroom.Visible = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Company", typeof(String));
            dt.Columns.Add("User_name", typeof(String));
            dt.Columns.Add("Phone", typeof(String));

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["Eroomdt"] = dt;
            gvEroom.DataSource = dt;
            gvEroom.DataBind();
        }
    }

    protected void gvcbNetInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Netdt"];
        int i = 0;
        foreach (GridViewRow r in gvNet.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_unit"] = ((TextBox)r.FindControl("gvtbUser_unit")).Text;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["User_phone"] = ((TextBox)r.FindControl("gvtbUser_phone")).Text;
            dt.Rows[i]["Mac_addr"] = ((TextBox)r.FindControl("gvtbMac_addr")).Text;
            dt.Rows[i]["Old_macaddr"] = ((TextBox)r.FindControl("gvtbOld_macaddr")).Text;

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["Netdt"] = dt;
        gvNet.DataSource = dt;
        gvNet.DataBind();
    }
    protected void gvcbNetDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Netdt"];
        int i = 0;
        foreach (GridViewRow r in gvNet.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_unit"] = ((TextBox)r.FindControl("gvtbUser_unit")).Text;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["User_phone"] = ((TextBox)r.FindControl("gvtbUser_phone")).Text;
            dt.Rows[i]["Mac_addr"] = ((TextBox)r.FindControl("gvtbMac_addr")).Text;
            dt.Rows[i]["Old_macaddr"] = ((TextBox)r.FindControl("gvtbOld_macaddr")).Text;
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["Netdt"] = dt;
        gvNet.DataSource = dt;
        gvNet.DataBind();
    }

    protected void gvcbDnsInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["DNSdt"];
        int i = 0;
        foreach (GridViewRow r in gvDNS.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["Server_name"] = ((TextBox)r.FindControl("gvtbServer_name")).Text;
            dt.Rows[i]["Server_ip"] = ((TextBox)r.FindControl("gvtbServer_ip")).Text;
            dt.Rows[i]["Dns_name"] = ((TextBox)r.FindControl("gvtbDns_name")).Text;
            dt.Rows[i]["Firewall_port"] = ((TextBox)r.FindControl("gvtbFirewall_port")).Text;

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["DNSdt"] = dt;
        gvDNS.DataSource = dt;
        gvDNS.DataBind();
    }
    protected void gvcbDnsDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["DNSdt"];
        int i = 0;
        foreach (GridViewRow r in gvDNS.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["Server_name"] = ((TextBox)r.FindControl("gvtbServer_name")).Text;
            dt.Rows[i]["Server_ip"] = ((TextBox)r.FindControl("gvtbServer_ip")).Text;
            dt.Rows[i]["Dns_name"] = ((TextBox)r.FindControl("gvtbDns_name")).Text;
            dt.Rows[i]["Firewall_port"] = ((TextBox)r.FindControl("gvtbFirewall_port")).Text;
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["DNSdt"] = dt;
        gvDNS.DataSource = dt;
        gvDNS.DataBind();
    }
    protected void gvcbServInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Servdt"];
        int i = 0;
        foreach (GridViewRow r in gvServ.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["Server_name"] = ((TextBox)r.FindControl("gvtbServer_name")).Text;
            dt.Rows[i]["Cpu_nos"] = ((TextBox)r.FindControl("gvtbCpu_nos")).Text;
            dt.Rows[i]["Ram_size"] = ((TextBox)r.FindControl("gvtbRam_size")).Text;
            dt.Rows[i]["Hd_size"] = ((TextBox)r.FindControl("gvtbHd_size")).Text;
            dt.Rows[i]["Windows_ver"] = ((TextBox)r.FindControl("gvtbWindows_ver")).Text;
            dt.Rows[i]["Other_ver"] = ((TextBox)r.FindControl("gvtbOther_ver")).Text;
            dt.Rows[i]["Intra_flag"] = ((CheckBox)r.FindControl("gvtbIntra_flag")).Checked ? "1" : "0";
            dt.Rows[i]["Outer_flag"] = ((CheckBox)r.FindControl("gvtbOuter_flag")).Checked ? "1" : "0";

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["Servdt"] = dt;
        gvServ.DataSource = dt;
        gvServ.DataBind();
    }
    protected void gvcbServDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Servdt"];
        int i = 0;
        foreach (GridViewRow r in gvServ.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["Server_name"] = ((TextBox)r.FindControl("gvtbServer_name")).Text;
            dt.Rows[i]["Cpu_nos"] = ((TextBox)r.FindControl("gvtbCpu_nos")).Text;
            dt.Rows[i]["Ram_size"] = ((TextBox)r.FindControl("gvtbRam_size")).Text;
            dt.Rows[i]["Hd_size"] = ((TextBox)r.FindControl("gvtbHd_size")).Text;
            dt.Rows[i]["Windows_ver"] = ((TextBox)r.FindControl("gvtbWindows_ver")).Text;
            dt.Rows[i]["Other_ver"] = ((TextBox)r.FindControl("gvtbOther_ver")).Text;
            dt.Rows[i]["Intra_flag"] = ((CheckBox)r.FindControl("gvtbIntra_flag")).Checked ? "1":"0";
            dt.Rows[i]["Outer_flag"] = ((CheckBox)r.FindControl("gvtbOuter_flag")).Checked ? "1" : "0";
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["Servdt"] = dt;
        gvServ.DataSource = dt;
        gvServ.DataBind();
    }
    protected void gvcbAccInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Accdt"];
        int i = 0;
        foreach (GridViewRow r in gvAcc.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Account"] = ((TextBox)r.FindControl("gvtbAccount")).Text;

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["Accdt"] = dt;
        gvAcc.DataSource = dt;
        gvAcc.DataBind();
    }
    protected void gvcbAccDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Accdt"];
        int i = 0;
        foreach (GridViewRow r in gvAcc.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Account"] = ((TextBox)r.FindControl("gvtbAccount")).Text;
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["Accdt"] = dt;
        gvAcc.DataSource = dt;
        gvAcc.DataBind();
    }
    protected void gvcbOthInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Othdt"];
        int i = 0;
        foreach (GridViewRow r in gvOth.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Memo"] = ((TextBox)r.FindControl("gvtbMemo")).Text;

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dr["Apply_type"] = "I";
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["Othdt"] = dt;
        gvOth.DataSource = dt;
        gvOth.DataBind();
    }
    protected void gvcbOthDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Othdt"];
        int i = 0;
        foreach (GridViewRow r in gvOth.Rows)
        {
            dt.Rows[i]["Apply_type"] = ((RadioButtonList)r.FindControl("rblApply_type")).SelectedValue;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Memo"] = ((TextBox)r.FindControl("gvtbMemo")).Text;
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["Othdt"] = dt;
        gvOth.DataSource = dt;
        gvOth.DataBind();
    }

    protected void gvcbEroomInsert_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Eroomdt"];
        int i = 0;
        foreach (GridViewRow r in gvEroom.Rows)
        {
            dt.Rows[i]["Company"] = ((TextBox)r.FindControl("gvtbCompany")).Text;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Phone"] = ((TextBox)r.FindControl("gvtbPhone")).Text;

            if (idx == r.RowIndex)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            i += 1;
        }

        ViewState["Eroomdt"] = dt;
        gvEroom.DataSource = dt;
        gvEroom.DataBind();
    }
    protected void gvcbEroomDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        int idx = gvr.RowIndex;

        DataTable dt = (DataTable)ViewState["Eroomdt"];
        int i = 0;
        foreach (GridViewRow r in gvOth.Rows)
        {
            dt.Rows[i]["Company"] = ((TextBox)r.FindControl("gvtbCompany")).Text;
            dt.Rows[i]["User_name"] = ((TextBox)r.FindControl("gvtbUser_name")).Text;
            dt.Rows[i]["Phone"] = ((TextBox)r.FindControl("gvtbPhone")).Text;
            i += 1;
        }

        if (idx != 0)
            dt.Rows.RemoveAt(idx);
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "第一筆資料不能刪除!", "", "");
        }

        ViewState["Eroomdt"] = dt;
        gvEroom.DataSource = dt;
        gvEroom.DataBind();
    }
    #endregion

    protected void cbBack_Click(object sender, EventArgs e)
    {
        if(ViewState["BackUrl"]!=null)
            Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void cbToFirm_Click(object sender, EventArgs e)
    {
        //送維運廠商
    }
    protected void cbCase_status_Y_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCase_status_Y.Checked)
            cbCase_status_N.Checked = false;
    }
    protected void cbCase_status_N_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCase_status_N.Checked)
            cbCase_status_Y.Checked = false;
    }
    protected void cbCase_status_1_CheckedChanged(object sender, EventArgs e)
    {

    }
}