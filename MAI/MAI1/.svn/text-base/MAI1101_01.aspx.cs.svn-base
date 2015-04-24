using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data;

public partial class MAI1101_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        BindInit();
        ShowReSendData();
    }
    protected void ShowReSendData()
    {
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];

        if (String.IsNullOrEmpty(org) || String.IsNullOrEmpty(fid))
            return;

        cbConfirm.Text = "確認";
        cbBack.Visible = true;

        SYS.Logic.Flow f = new SYS.Logic.Flow();
        MAI.Logic.MaintainMain main = new MAI.Logic.MaintainMain();

        f = f.GetObject(org, fid);
        main = main.GetObject(org, fid);

        if (main != null)
        {
            hfMainId.Value = main.Id.ToString();
            lbFlowId.Text = fid;
            lblUserInfo.Text = main.Apply_name;
            txtPhone_ext.Text = main.Apply_ext;
            rblMaintain_kind.SelectedValue = main.Maintain_kind;
            BindType();
            ddlMaintain_type.SelectedValue = main.Maintain_type;
            UcProblem_desc.Text = main.Problem_desc;
            
            rblMaintain_kind.Enabled = false;
            ddlMaintain_type.Enabled = false;
            UcProblem_desc.Enabled = false;
            
            UcAttachment.FlowId = fid;
            UcAttachment.isBind = true;
            UcAttachment.isUpload = true;


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
    protected void BindInit()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        rblMaintain_kind.DataSource = code.GetData("020", "**");
        rblMaintain_kind.DataBind();
        rblMaintain_kind.SelectedIndex = 0;

        ddlMaintain_type.DataSource = code.GetData("020", rblMaintain_kind.SelectedValue);
        ddlMaintain_type.DataBind();
        ddlMaintain_type.Items.Insert(0, new ListItem("請選擇", ""));
        
        lblUserInfo.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
        hfIdCard.Value = LoginManager.UserId;

        MAI.Logic.MAI1101 bll = new MAI.Logic.MAI1101();
        DataTable dt = bll.GetExt(hfIdCard.Value);
        if (dt != null && dt.Rows.Count > 0)
        {
            txtPhone_ext.Text = dt.Rows[0]["ext"].ToString();
        }
    }
    protected void rblMaintain_kind_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindType();
        BindTable();
    }

    protected void ddlMaintain_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTable();
    }

    protected void BindType()
    {
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        ddlMaintain_type.DataSource = code.GetData("020", rblMaintain_kind.SelectedValue);
        ddlMaintain_type.DataBind();
    }
    protected void cbConfirm_Click(object sender, EventArgs e)
    {
        bool isUpdate = false;
        String org = Request.QueryString["org"];
        String fid = Request.QueryString["fid"];

        if (!String.IsNullOrEmpty(org) && !String.IsNullOrEmpty(fid))
            isUpdate = true;

        String orgcode = LoginManager.OrgCode;
        String departId = LoginManager.Depart_id;
        String formId = "";
        String flowId = "";
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        FSC.Logic.Personnel p = new FSC.Logic.Personnel();
        MAI.Logic.MAI1101 bll = new MAI.Logic.MAI1101();

        Page page = this.Page;
        if (string.IsNullOrEmpty(ddlMaintain_type.SelectedValue))
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "請選擇申請項目!", "", "");
            return;
        }

        DataRow r = code.GetRow("020", "**", rblMaintain_kind.SelectedValue);
        if (r != null)
        {
            formId = r["code_remark1"].ToString();
        }

        try
        {   
            SYS.Logic.Flow f = new SYS.Logic.Flow();
            f.Orgcode = orgcode;
            f.DepartId = new FSC.Logic.DepartEmp().GetDepartId(hfIdCard.Value);
            f.ApplyIdcard = hfIdCard.Value;
            f.ApplyName = lblUserInfo.Text;
            f.ApplyPosid = p.GetColumnValue("title_no", hfIdCard.Value);
            f.WriterOrgcode = orgcode;
            f.WriterDepartid = departId;
            f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
            f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
            f.WriteTime = DateTime.Now;
            f.FormId = formId;
            f.Reason = UcProblem_desc.Text;
            f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
            
            MAI.Logic.MaintainMain main = new MAI.Logic.MaintainMain();
            main.Orgcode = orgcode;
            main.Apply_ext = txtPhone_ext.Text;
            main.Apply_departid = new FSC.Logic.DepartEmp().GetDepartId(hfIdCard.Value);
            main.Apply_idcard = hfIdCard.Value;
            main.Apply_name = lblUserInfo.Text;
            main.Maintain_kind = rblMaintain_kind.SelectedValue;
            main.Apply_date = FSCPLM.Logic.DateTimeInfo.GetRocDate(DateTime.Now);
            main.Maintain_type = ddlMaintain_type.SelectedValue;
            main.Problem_desc = UcProblem_desc.Text;

            DataTable dt = bll.GetExt(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account));
            if (dt != null && dt.Rows.Count > 0)
                main.Writer_ext = dt.Rows[0]["ext"].ToString();            
            main.Writer_departid = LoginManager.Depart_id;
            main.Writer_idcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
            main.Writer_name = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            main.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
           
            using (TransactionScope scope = new TransactionScope())
            {
                if (isUpdate)
                {
                    flowId = fid;
                    main.Flow_id = flowId;
                    main.Update();

                    AddDetialData(CommonFun.getInt(hfMainId.Value), orgcode, flowId, true);
                }
                else
                {
                    flowId = new SYS.Logic.FlowId().GetFlowId(orgcode, formId);
                    main.Flow_id = flowId;
                    main.Insert();
                    
                    AddDetialData(main.Id, orgcode, flowId, false);

                    f.FlowId = flowId;
                    SYS.Logic.CommonFlow.AddFlow(f);
                }

                UcAttachment.FlowId = flowId;
                UcAttachment.SaveFile();

                scope.Complete();
            }
            if(isUpdate)
                CommonFun.MsgShow(ref page, CommonFun.Msg.UpdateOK, "", "", "");
            else
                CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "申請成功!", "MAI1101_01.aspx", "");
            
        }
        catch (FlowException ex)
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, ex.Message, "", "");
        }
    }

    protected void AddDetialData(int mainId, String orgcode, String flowId, bool isUpdate) 
    {
        if (rblMaintain_kind.SelectedValue == "003")
        {
            if (ddlMaintain_type.SelectedValue == "001")
            {
                if (isUpdate)
                {
                    MAI.Logic.MaintainNet net = new MAI.Logic.MaintainNet();
                    net.DeleteDataByMainId(mainId);
                }

                foreach (GridViewRow gvr in gvNet.Rows) {
                    MAI.Logic.MaintainNet net = new MAI.Logic.MaintainNet();
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
                if (isUpdate)
                {
                    MAI.Logic.MaintainDns dns = new MAI.Logic.MaintainDns();
                    dns.DeleteDataByMainId(mainId);
                }

                foreach (GridViewRow gvr in gvDNS.Rows)
                {
                    MAI.Logic.MaintainDns dns = new MAI.Logic.MaintainDns();
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
                if (isUpdate)
                {
                    MAI.Logic.MaintainServer serv = new MAI.Logic.MaintainServer();
                    serv.DeleteDataByMainId(mainId);
                }

                foreach (GridViewRow gvr in gvServ.Rows)
                {
                    MAI.Logic.MaintainServer serv = new MAI.Logic.MaintainServer();
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
                if (isUpdate)
                {
                    MAI.Logic.MaintainAcc acc = new MAI.Logic.MaintainAcc();
                    acc.DeleteDataByMainId(mainId);
                }

                foreach (GridViewRow gvr in gvAcc.Rows)
                {
                    MAI.Logic.MaintainAcc acc = new MAI.Logic.MaintainAcc();
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
            if (isUpdate)
            {
                MAI.Logic.MaintainOther oth = new MAI.Logic.MaintainOther();
                oth.DeleteDataByMainId(mainId);
            }

            foreach (GridViewRow gvr in gvOth.Rows)
            {
                MAI.Logic.MaintainOther oth = new MAI.Logic.MaintainOther();
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
            if (isUpdate)
            {
                MAI.Logic.MaintainEroom room1 = new MAI.Logic.MaintainEroom();
                room1.DeleteDataByMainId(mainId);
                MAI.Logic.MaintainEroomDet rdet = new MAI.Logic.MaintainEroomDet();
                rdet.DeleteDataByMainId(mainId);
            }

            MAI.Logic.MaintainEroom room = new MAI.Logic.MaintainEroom();
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
            room.Change_userid = LoginManager.Account;
            room.Insert();

            foreach (GridViewRow gvr in gvEroom.Rows)
            {
                MAI.Logic.MaintainEroomDet rdet = new MAI.Logic.MaintainEroomDet();
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

        if( idx != 0)
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
            dt.Rows[i]["Intra_flag"] = ((CheckBox)r.FindControl("gvtbIntra_flag")).Checked;
            dt.Rows[i]["Outer_flag"] = ((CheckBox)r.FindControl("gvtbOuter_flag")).Checked;

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
            dt.Rows[i]["Intra_flag"] = ((CheckBox)r.FindControl("gvtbIntra_flag")).Checked;
            dt.Rows[i]["Outer_flag"] = ((CheckBox)r.FindControl("gvtbOuter_flag")).Checked;
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

    protected void txtPhone_ext_TextChanged(object sender, EventArgs e)
    {
        MAI.Logic.MAI1101 bll = new MAI.Logic.MAI1101();
        FSC.Logic.DepartEmp dep = new FSC.Logic.DepartEmp();
        FSC.Logic.Personnel psn = new FSC.Logic.Personnel();

        DataTable dt = bll.GetDataByExt(txtPhone_ext.Text);

        if (dt != null && dt.Rows.Count > 0)
        {
            lblUserInfo.Text = dt.Rows[0]["User_name"].ToString();
            hfIdCard.Value = dt.Rows[0]["Id_card"].ToString();
            hfDepartid.Value =  dep.GetDepartId(hfIdCard.Value);
        }

    }
    protected void cbBack_Click(object sender, EventArgs e)
    {
        if(ViewState["BackUrl"]!=null)
        Response.Redirect(ViewState["BackUrl"].ToString());
    }
}