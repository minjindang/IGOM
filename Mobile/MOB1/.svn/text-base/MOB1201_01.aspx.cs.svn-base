using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSC.Logic;
using System.Data;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

public partial class Mobile_MOB1_MOB1201_01 : System.Web.UI.Page
{
    public string Orgcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add 2014/07/11
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;

        Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "申請一般請假";
        InitControl(); //初始設定
        ShowReSendData();
    }

    private void Back2LastPage(object sender, EventArgs e)
    {
        Response.Redirect("~/Mobile/main.aspx");
        /*
        if (pnlDetail.Visible)
        {
            pnlDetail.Visible = false;
            pnlResult.Visible = true;
            pnlQuery.Visible = false;
        }
        else
            if (pnlResult.Visible)
            {
                pnlDetail.Visible = false;
                pnlResult.Visible = false;
                pnlQuery.Visible = true;
            }
            else
            {
                Response.Redirect("~/Mobile/main.aspx");
            }
        */
    }

    protected void ShowReSendData()
    {
        string fid = ""+Request["fid"];
        string org =""+ Request["org"];
             
        if (fid != "" && org != "")
        {
            btnQuery.Text = "確認";   

            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

            MOB.LeaveMain[] list = wsmob.WSMOB056(org, fid);
            if (list.Count() <= 0)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "查無表單資料!", "", "");
                this.Page = tempPage;
                return;
            }
            MOB.Flow f = wsmob.WSMOB057(org, fid);

            bool isDeputyAgree = false;
            if (Request["url"] == "FSC3116")
            {
                DataTable ddt = wsmob.WSMOB058(org, fid);
                foreach (DataRow dr in ddt.Rows)
                {
                    if (dr["Last_idcard"].ToString().Equals(f.DeputyIdcard))
                    {
                        if (dr["Agree_flag"].ToString().Equals("1"))
                        {
                            isDeputyAgree = true;
                        }
                    }
                }
            }
            int i = 1;

            foreach (MOB.LeaveMain lm in list)
            {
                if (i == list.Count())
                {
                    ddlLeave_type.SelectedValue = lm.LeaveType;
                    bindLeaveOtherData();
                    ddlleaveName.SelectedValue = lm.IdCard;         
                    bindDeputy();                  
                    rblretainFlag.SelectedValue = lm.RetainFlag;
                    rblLocationFlag.SelectedValue = lm.LocationFlag;
                    tbplace.Text = lm.Place;              
                    rblChinaFlag.SelectedValue = lm.ChinaFlag;
                    ddlTarget.SelectedValue = lm.Target;
                    UcDate.Text = lm.OccurDate;
                    ddlBabyDays.SelectedValue = lm.BabyDays;
                    tbReason.Text = lm.Reason;
                    rblTravel.SelectedValue = lm.InterTravelFlag;
                    if (lm.LeaveType == "03" && lm.InterTravelFlag == "1")
                    {                       
                        string script = null;
                        script = "<script type='text/javascript'>showCbToChina();</script>";
                        System.Web.UI.Page P = this;
                        P.ClientScript.RegisterStartupScript(typeof(string), "", script);
                    }
                }

              
                    UcLeaveDate.Start_date = lm.StartDate;
                    UcLeaveDate.End_date = lm.EndDate;
                    UcLeaveDate.Start_time = lm.StartTime;
                    UcLeaveDate.End_time = lm.EndTime;

                    if (isDeputyAgree)
                    {
                        ddlLeave_type.Enabled = false;
                        ddlleaveName.Enabled = false;
                        ddlDefaultDeputy.Enabled = false;
                        ddlDepart_01.Enabled = false;
                        ddlDepart_02.Enabled = false;
                        ddlUserName.Enabled = false;
                        UcLeaveDate.Enabled = false;
                    }
                

                i += 1;
            }

        //    UcAttachment.BindUploadFile(org, fid);
            bindMemoDesc();
        }        
        
    }

    protected void bindUcleaveMember()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        hfApply_name.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
        hfApply_id.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        hfApply_posid.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
        
        DataTable dt = wsmob.WSMOB027(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode),
                                                   MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id),
                                                 "");
        //請假申請人
        ddlleaveName.DataTextField = "full_name";
        ddlleaveName.DataValueField = "Id_card";
        ddlleaveName.DataSource = dt;
        ddlleaveName.DataBind();
        ddlleaveName.SelectedValue = MOBLoginManager.UserId;
        setValueAppl();


    }
    protected void InitControl()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
          
        bindUcleaveMember(); //請假申請人
        bindLeaveData(); //假別
        bindLeaveOtherData(); //國民旅遊卡
        bindBabyDaysData(); //懷孕日數 
        
        BindDepart1(); //代理人 第一層
        // 取得父 Depart
        string strParentDepart = wsmob.WSMOB028(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id));
        ddlDepart_01.SelectedValue = strParentDepart;
        if (strParentDepart != "")
        {
            BindDepart2();
            ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
            UserName_Bind();    
        }

        bindMemoDesc();
        bindDeputy();//代理人_1 
        BindPosid();
     
    }

    private void bindDeputy() //代理人_1
    {
       string ApplyIdcard =  ddlleaveName.SelectedValue;
       hfApplyIdcard.Text = ApplyIdcard;
       MOB.MOBServices wsmob = new MOB.MOBServices();
       wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
       DataTable dt = wsmob.WSMOB051(ApplyIdcard);
       if (dt.Rows.Count > 0 && dt != null)
       {
           ddlDefaultDeputy.DataValueField = "cols";
           ddlDefaultDeputy.DataTextField = "ALL_name";
           ddlDefaultDeputy.DataSource = dt;
           ddlDefaultDeputy.DataBind();

           setValue();

           rb2.Checked = false;
           rb1.Checked = true;
           rb1.Visible = true;
           ddlDefaultDeputy.Visible = true;
           ddlDepart_01.Enabled = false;
           ddlDepart_02.Enabled = false;
           ddlUserName.Enabled = false;
       }
       else
       {
           rb1.Visible = false;
           ddlDefaultDeputy.Visible = false;
           rb1.Checked = false;
           rb2.Checked = true;
           ddlDepart_01.Enabled = true;
           ddlDepart_02.Enabled = true;
           ddlUserName.Enabled = true;
       }

    }

    private void setValue()
    {
        if (rb1.Checked)
        {
            string[] value = ddlDefaultDeputy.SelectedValue.Split(',');
            hfOrgcode.Text = value[0];
            hfDepartId.Text = value[1];
            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
            hfDeputyPosid.Text = wsmob.WSMOB066("title_no", ddlleaveName.SelectedValue);
//            hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", value[2]);
                    
        }
        else if (rb2.Checked)
        {
            hfOrgcode.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
            hfDepartId.Text = ddlUserName.SelectedValue;
            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
            hfDeputyPosid.Text = wsmob.WSMOB066("title_no", ddlleaveName.SelectedValue);
            //hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", ddlUserName.SelectedValue);
        }
    }

    private void bindLeaveData() //假別
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB047(Orgcode);
        ddlLeave_type.DataTextField = "Leave_name";
        ddlLeave_type.DataValueField = "Leave_type";
        ddlLeave_type.DataSource = dt;
        ddlLeave_type.DataBind();
        ddlLeave_type.Items.Insert(0, new ListItem("請選擇", "ALL"));
        changeTableMode(ddlLeave_type.SelectedValue);
    }


    private void changeTableMode(string Leave_type) 
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chgTableMode", "chgTableMode('" + Leave_type + "');", true);
      
        if (Leave_type == "04")
        {
   //         BindOvertimeData();
        }
        else if (Leave_type == "20")
        {
   //         BindBusinessData();
        }
        else if (Leave_type == "32")
        {
   //         BindScheduleData();
        }
        else if (Leave_type == "08" | Leave_type == "13" | Leave_type == "22")
        {
            cbCount.Visible = false;
            cbCount2.Visible = false;
            lbLimit2.Text = "";
            
            if (Leave_type == "13")
            {
            }
        }
        else if (Leave_type == "09")
        {
            cbCount.Visible = false;
            cbCount2.Visible = true;
            lbLimit.Text = "";
        }
        else if (Leave_type == "10")
        {
            cbCount.Visible = false;
            cbCount2.Visible = false;
            lbLimit2.Text = "";
            bindLeaveType10ddl(); //喪假對象
        }
        else
        {
            cbCount.Visible = false;
            cbCount2.Visible = false;
            lbLimit.Text = "";
            lbLimit2.Text = "";
            UcDate.Text = "";
        }

        bindMemoDesc();
    }

    private void bindLeaveType10ddl() //喪假對象
    {      
            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

            string employeeType = wsmob.WSMOB066("employee_Type", ddlleaveName.SelectedValue);       
            string leaveKind = wsmob.WSMOB066("pekind", ddlleaveName.SelectedValue);        
            string leaveType = ddlLeave_type.SelectedValue;

        
            DataTable dt = wsmob.WSMOB049(Orgcode, employeeType, leaveKind, leaveType);

            ddlTarget.DataSource = dt;
            ddlTarget.DataBind();
            ddlTarget.Items.Insert(0, new ListItem("請選擇", ""));
    }

    private void bindBabyDaysData() //懷孕日數
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB048();
        ddlBabyDays.DataTextField = "CODE_DESC1";
        ddlBabyDays.DataValueField = "CODE_NO";
        ddlBabyDays.DataSource = dt;
        ddlBabyDays.DataBind();
    }

    private void bindLeaveOtherData() //國民旅遊卡
    {
        if (ddlLeave_type.SelectedValue == "03")
        {
            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
            double Inter_travel_hours = wsmob.WSMOB078(ddlleaveName.SelectedValue);
            // new LeaveMain().getInter_travel(ddlleaveName.SelectedValue, (DateTime.Now.Year - 1911).ToString());

            if (FSC.Logic.Content.ConvertDayHours((int)Inter_travel_hours) >= 14) 
            {
                lbInter_travel.Text = "註：您國民旅遊卡休假已超過14天。";
                lbInter_travel.Visible = true;
         
                rblTravel.Visible = false;
                rblTravel.Items[0].Selected = false;
                rblTravel.Items[1].Selected = false;
            }
            else
            {
                lbInter_travel.Text = "";
                lbInter_travel.Visible = false;           
                rblTravel.Visible = true;
            }    
        }
        else
        {
            lbInter_travel.Text = "";
            lbInter_travel.Visible = false;         
            rblTravel.Visible = false;
            rblTravel.Items[0].Selected = false;
            rblTravel.Items[1].Selected = false;
        }
      
    }



    private void bindMemoDesc() //備註
    {
        string idCard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        string Leave_type = ddlLeave_type.SelectedValue;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        lbDesc.Text = wsmob.WSMOB050(ddlleaveName.SelectedValue, Leave_type, Orgcode);


        lbMemo.Text = wsmob.WSMOB019(ddlleaveName.SelectedValue, Leave_type, UcLeaveDate.Start_date, UcDate.Text, ddlTarget.SelectedValue
            , ddlBabyDays.SelectedValue, rblretainFlag.SelectedValue, rblretainFlag.SelectedItem.Text,Orgcode);
        
    }

    //第一層
    private void BindDepart1()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB016("", MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), "", "", "");
        ddlDepart_01.DataTextField = "Depart_name";
        //顯示的中文名稱
        ddlDepart_01.DataValueField = "Depart_code";
        //所代表的value
        ddlDepart_01.DataSource = dt;
        //指定datatable給ddl
        ddlDepart_01.DataBind();
        //ddl進行Databind
        ddlDepart_01.Items.Insert(0, new ListItem("請選擇", "ALL"));


        BindDepart2();
    }
    //第二層
    private void BindDepart2()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB016(ddlDepart_01.SelectedValue, MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), "", "", "");
        ddlDepart_02.DataTextField = "Depart_name";
        //顯示的中文名稱
        ddlDepart_02.DataValueField = "Depart_code";
        //所代表的value
        ddlDepart_02.DataSource = dt;
        //指定datatable給ddl
        ddlDepart_02.DataBind();
        //ddl進行Databind
        ddlDepart_02.Items.Insert(0, new ListItem("請選擇", ""));

        UserName_Bind();
    }
    //第三層姓名
    private void UserName_Bind()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB017(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode)
            , getDepartCode(), "", "", "");
        //Id_card.User_name
        ddlUserName.DataTextField = "User_name";
        //顯示的中文名稱
        ddlUserName.DataValueField = "Id_card";
        //所代表的value
        ddlUserName.DataSource = dt;
        //指定datatable給ddl
        ddlUserName.DataBind();
        //ddl進行Databind
        ddlUserName.Items.Insert(0, new ListItem("請選擇", ""));  
    }

    private string getDepartCode()
    {
        if (ddlDepart_02.SelectedValue == "")
        {
            return ddlDepart_01.SelectedValue;
        }
        else
        {
            return ddlDepart_02.SelectedValue;
        }
    }

    protected void ddlDepart_01_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDepart2();
    }
    protected void ddlDepart_02_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserName_Bind();
    }

    protected void bindConfirmMsg()
    {
        string ID = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];


        string Pekind = wsmob.WSMOB059(ID);
        string EmployeeType = wsmob.WSMOB060(ID);

        //假別規則
        string Ifbatch_apply = wsmob.WSMOB061(Orgcode, Pekind, ddlLeave_type.SelectedValue, EmployeeType);

        if (Ifbatch_apply == "1")
        {
            hfConfrimMsg.Value = ddlLeave_type.SelectedItem.Text + "需一次請畢，是否確定送申請?";
        }
        else
        {
            hfConfrimMsg.Value = "";
        }    
    }



    //送出申請
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (CheckField())
        {
            getData();
        }
        else
        {
            return;
        }
    }

    private bool CheckField()
    {

        if (tbReason.Text  =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "事由必需輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (ddlLeave_type.SelectedValue == "ALL" || ddlLeave_type.SelectedValue == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "假別必需輸入!", "", "");
            this.Page = tempPage;
            return false;
        }

        if (UcLeaveDate.Start_date == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期起日不可空白，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (UcLeaveDate.Start_time =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期起時不可空白，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (UcLeaveDate.End_date =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期迄日不可空白，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (UcLeaveDate.End_time =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期迄時不可空白，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (int.Parse(UcLeaveDate.Start_date) > int.Parse(UcLeaveDate.End_date))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        else if (UcLeaveDate.Start_date == UcLeaveDate.End_date && int.Parse(UcLeaveDate.Start_time) > int.Parse(UcLeaveDate.End_time))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
       
        if (wsmob.WSMOB053(UcLeaveDate.Start_date) || wsmob.WSMOB053(UcLeaveDate.End_date))
        {          
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "您選擇的請假日期為假日，假日不必請假，請修正!", "", "");
            this.Page = tempPage;
            return false;
        }

        string idcard;
        if(rb1.Checked)
        {
           string[] value = ddlDefaultDeputy.SelectedValue.Split(',');
           idcard = value[2];
        }
        else
        {
           idcard = ddlUserName.SelectedValue;
        }
        if (idcard =="" && hfApplyEmployeeType.Value != "13")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "職務代理人不可空白，請重新輸入!", "", "");
            this.Page = tempPage;
            return false;
        }
        if (ddlLeave_type.SelectedValue == "13")
        {
            if (ddlBabyDays.SelectedValue =="" )
            {              
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "懷孕日數不可空白，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }
        }
        
        if (ddlLeave_type.SelectedValue == "03")
        {          
            if (rblLocationFlag.SelectedValue == "1" && rblTravel.SelectedValue == "1")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "國外休假不可勾選國民旅遊卡!", "", "");
                this.Page = tempPage;
                return false;
            }
            if (rblLocationFlag.SelectedValue == "1" && string.IsNullOrEmpty(tbplace.Text.Trim()))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "國外休假旅遊地點不可空白!", "", "");
                this.Page = tempPage;
                return false;
            }
            if (rblretainFlag.SelectedValue == "1" && rblLocationFlag.SelectedValue == "0" && !rblTravel.Items[0].Selected && !rblTravel.Items[1].Selected)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "請選擇是否使用國民旅遊卡!", "", "");
                this.Page = tempPage;
                return false;
            }
        }

        if (rblLocationFlag.SelectedValue == "1")
        {
            if (!rblChinaFlag.Items[0].Selected && !rblChinaFlag.Items[1].Selected)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "請選擇是否赴大陸地區!", "", "");
                this.Page = tempPage;
                return false;
            }
        }

        return true;
    }

    private void getData()
    {
        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);

        string u_fid = Request["fid"];
        string u_org = Request["org"];
        string url = Request["url"];

        bool isUpdate = false;

        if (!string.IsNullOrEmpty(u_fid) && !string.IsNullOrEmpty(u_org))
        {
            isUpdate = true;
        }

        string reason = tbReason.Text.Trim();
        if ("10" == ddlLeave_type.SelectedValue)
        {
            reason = "對象：" + ddlTarget.SelectedItem.Text + "，往生日：" + UcDate.Text + "，" + reason;
        }
        else if ("13" == ddlLeave_type.SelectedValue)
        {
            reason = "懷孕日數：：" + ddlBabyDays.SelectedItem.Text + "，流產日：" + UcDate.Text + "，" + reason;
        }
        
        string strLeaveType = ddlLeave_type.SelectedValue; //假別     
        string Apply_id = ddlleaveName.SelectedValue;       //申請之 ID Card
        string Apply_name = ddlleaveName.SelectedItem.Text; //申請之 name
        string[] APnames = Apply_name.Split('/');
        Apply_name = APnames[1];
        string Apply_posid = hfApply_posid.Text;
        string Apply_stype = hfApply_stype.Text;
        string DeputyDepartid = "";     //代理人 Departid 
        string DeputyIdcard = "";       //代理人 ID Card
        string DeputyName = "";         //代理人 Name
        string DeputyPosid = hfDeputyPosid.Text ;
        if (rb1.Checked)
        {
            string[] value = ddlDefaultDeputy.SelectedValue.Split(',');
            DeputyDepartid = value[1];
            DeputyIdcard = value[2];
            string[] text = ddlDefaultDeputy.SelectedItem.Text.Split('/');
            DeputyName = text[2];
        }
        else
        {
             DeputyDepartid = ddlDepart_01.SelectedValue; //單位代碼
            if (ddlDepart_02.SelectedValue != "")
                DeputyDepartid = ddlDepart_02.SelectedValue;

            DeputyIdcard = ddlUserName.SelectedValue;
            DeputyName = ddlUserName.SelectedItem.Text;
        }
        
        string OccurDate = UcDate.Text;      // 事實發生日
        string Place = tbplace.Text;         //地點
        string Target = ddlTarget.SelectedValue; //喪假對象
        string BabyDays = ddlBabyDays.SelectedValue; //懷孕日數        
        string RetainFlag = rblretainFlag.SelectedValue; //休請假別
        string LocationFlag = rblLocationFlag.SelectedValue; //種類
        string ChinaFlag = rblChinaFlag.SelectedValue;// 是否赴大陸地區旅遊
        string InterTravelFlag = rblTravel.SelectedValue; // 國民旅遊卡
        string Start_date = UcLeaveDate.Start_date;// 起價開始日期
        string End_date = UcLeaveDate.End_date; // 請假結束日期
        string Start_time = UcLeaveDate.Start_time;  // 請假開始時間
        string End_time = UcLeaveDate.End_time;   // 請假結束時間

        string WriterIdcard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Account);
        string WriterName = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.User_name);
        string WriterPosid = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Title_no);


        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        string Submit = wsmob.WSMOB004(isUpdate, u_fid, Orgcode, strLeaveType, Depart_id, Apply_id, Apply_name, Apply_posid, Apply_stype,
            DeputyDepartid, DeputyIdcard,DeputyName,DeputyPosid,reason
            , OccurDate, Place,Target,BabyDays, RetainFlag, LocationFlag, ChinaFlag, InterTravelFlag,
          Start_date, End_date, Start_time, End_time, url, WriterIdcard, WriterName, WriterPosid);


        JObject obj = JsonConvert.DeserializeObject<JObject>(Submit);
        string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
        string message = obj.Property("message").Value.ToString(); 
        if (strisSuccess == "Y")
        {
            if (message.Trim() != "")
            {
                Page tempp = this.Page;
                CommonFun.MsgShow(ref tempp,
                   CommonFun.Msg.Custom, message , "", "");
                this.Page = tempp;
            }
            Page temp = this.Page;
            CommonFun.MsgShow(ref temp,
               CommonFun.Msg.Custom, "已送出申請", "", "");
            this.Page = temp;
            
    //        Response.Redirect("MOB1201_01.aspx");
    //    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1101_01.aspx")
          
        }
        else
        {
            //false
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, message, "", "");
            this.Page = tempPage;
        }

    }

    //回上頁
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }

    protected void ddlLeave_type_SelectedIndexChanged(object sender, EventArgs e) //假別改變
    {
        bindLeaveOtherData(); //國民旅遊卡
        bindBabyDaysData();//懷孕日數
        BindDepart1(); //代理人 第一層
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        string strParentDepart = wsmob.WSMOB028(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id));
        ddlDepart_01.SelectedValue = strParentDepart;
        if (strParentDepart != "")
        {
            BindDepart2();
            ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
            UserName_Bind();                     
        }
        bindDeputy();//代理人_1 
        BindPosid();

        changeTableMode(ddlLeave_type.SelectedValue);
        lbLimit.Text = "";
        tbReason.Text = "";

        UcLeaveDate.Start_date = DateTimeInfo.GetRocDate(DateTime.Now);
        UcLeaveDate.End_date = DateTimeInfo.GetRocDate(DateTime.Now);

        string sTmp = wsmob.WSMOB076("WORKTIMEB", ddlleaveName.SelectedValue,Orgcode); 
        if (sTmp != "")
        { 
            UcLeaveDate.Start_time = sTmp; 
        }
        sTmp = wsmob.WSMOB076("WORKTIMEE", ddlleaveName.SelectedValue,Orgcode);
        if (sTmp != "")
        {
            UcLeaveDate.End_time = sTmp;
        }

        /*
        Hashtable ht = FSC.Logic.Content.getWorkTime(ddlleaveName.SelectedValue, DateTimeInfo.GetRocDate(DateTime.Now));
        if (ht != null && ht.Count > 0)
        {
            UcLeaveDate.Start_time = ht["WORKTIMEB"].ToString();
            UcLeaveDate.End_time = ht["WORKTIMEE"].ToString();
        }
        */
        bindConfirmMsg();
    } 

    protected void ddlleaveName_SelectedIndexChanged(object sender, EventArgs e) //請假申請人改變
    {
        bindMemoDesc();//備註
        bindLeaveType10ddl(); //喪假對象
        UcLeaveDate.Orgcode = Orgcode;
        UcLeaveDate.Apply_id = ddlleaveName.SelectedValue;  //重新指定申請人 設定 預設請假日期時間
        bindDeputy();//代理人_1 
        BindPosid();

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        hfApplyEmployeeType.Value = wsmob.WSMOB066("Employee_type",ddlleaveName.SelectedValue);

//        hfApplyEmployeeType.Value = new FSC.Logic.Personnel().GetColumnValue("Employee_type", ddlleaveName.SelectedValue);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "chgDateTable", "chgTableMode('" + ddlLeave_type.SelectedValue + "');", true);
        bindLeaveData();

        setValueAppl();
    }

    private void BindPosid()
    {
        string Deputy_id;
        if (rb1.Checked)
        {
            string[] value = ddlDefaultDeputy.SelectedValue.Split(',');
            Deputy_id = value[2];
            hfDepartId.Text = value[1];
        }
        else
        {
            Deputy_id = ddlUserName.SelectedValue;
            hfDepartId.Text = ddlDepart_01.SelectedValue;
            if (ddlDepart_02.SelectedValue != "")
                hfDepartId.Text = ddlDepart_02.SelectedValue;
        }
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        hfDeputyPosid.Text = wsmob.WSMOB066("title_no", ddlleaveName.SelectedValue);

        //hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", Deputy_id);
    }

    //國內外
    protected void rblLocationFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    protected void rb1_CheckedChanged(object sender, EventArgs e)
    {
        rb2.Checked = false;
        ddlDefaultDeputy.Enabled = true;
        ddlDepart_01.Enabled = false;
        ddlDepart_02.Enabled = false;
        ddlUserName.Enabled = false;
        setValue();
    }
    protected void rb2_CheckedChanged(object sender, EventArgs e)
    {
        rb1.Checked = false;
        ddlDefaultDeputy.Enabled = false;
        ddlDepart_01.Enabled = true;
        ddlDepart_02.Enabled = true;
        ddlUserName.Enabled = true;
        setValue();
    }

    //代理人_1
    protected void ddlDefaultDeputy_SelectedIndexChanged(object sender, EventArgs e)
    {
        setValue();
    }
    //代理人姓名改變
    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPosid();
    }

    //請休假別改變
    protected void rblretainFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblretainFlag.SelectedValue == "0" || rblLocationFlag.SelectedValue != "0")
        {           
            rblTravel.Visible = false;
            rblTravel.Items[0].Selected = false;
            rblTravel.Items[1].Selected = false;
        }
        else
        {
            rblTravel.Visible = true;
        }
        bindMemoDesc();//備註
    }


    //喪假對象改變
    protected void ddlTarget_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMemoDesc();//備註
    }

    //計算期限
    protected void cbCount_Click(object sender, EventArgs e)
    {     
        System.DateTime d = default(System.DateTime);
        string sdate = "" ;

        lbLimit.Text = "";
        lbLimit2.Text = "";

        if (string.IsNullOrEmpty(UcDate.Text) & ddlLeave_type.SelectedValue != "9")
        {
            return;
        }
        else
        {
            sdate = UcDate.Text;
        }

        if (string.IsNullOrEmpty(UcLeaveDate.Start_date) & ddlLeave_type.SelectedValue == "9")
        {
            return;
        }
        else if (ddlLeave_type.SelectedValue == "9")
        {
            sdate = UcLeaveDate.Start_date;
        }
        if(sdate != "")
        d = new System.DateTime(int.Parse(sdate.Substring(0, 3) + 1911), int.Parse(sdate.Substring(3, 2)), int.Parse(sdate.Substring(5, 2)));

        //婚假
        if (ddlLeave_type.SelectedValue == "8")
        {
            lbLimit.Text = "申請期限至：" + DateTimeInfo.GetRocDate(d.AddDays(31));
            //日曆天
        }

        if (ddlLeave_type.SelectedValue == "9")
        {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        lbLimit2.Text = "申請期限至：" + wsmob.WSMOB052(UcLeaveDate.Start_date);
            //工作天
        }

        //喪假
        if (ddlLeave_type.SelectedValue == "10")
        {
            lbLimit.Text = "申請期限至：" + DateTimeInfo.GetRocDate(d.AddDays(100));
            //日曆天
        }

        if (ddlLeave_type.SelectedValue == "13")
        {
            string idCard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        }
    }

    //懷孕日數改變
    protected void ddlBabyDays_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMemoDesc();//備註
    }

    private void setValueAppl() //申請人value
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        
        DataTable dt = wsmob.WSMOB054(ddlleaveName.SelectedValue);
        DataTable edt = wsmob.WSMOB055(ddlleaveName.SelectedValue);
        if (dt != null && dt.Rows.Count > 0)
        {
            hfApply_name.Text = dt.Rows[0]["User_name"].ToString();
            hfApply_id.Text = dt.Rows[0]["Id_card"].ToString();
            hfApply_posid.Text = dt.Rows[0]["Title_No"].ToString();
            hfApply_stype.Text = edt.Rows[0]["Service_type"].ToString();
        }    
    }


    protected void rblTravel_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfcbl.Value = rblTravel.SelectedValue;
    }

    
    protected void ddlLeave_type_DataBound(object sender, EventArgs e)
    {
        ControlLeaveType();
    }

    protected void ControlLeaveType()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        string idCard = MOBLoginManager.UserId;
        string PESEX = wsmob.WSMOB079(idCard);
        string employee_type = wsmob.WSMOB080(idCard);

        if (PESEX == "1")
        {
            if (ddlLeave_type.Items.Contains(new ListItem("娩假", "09")))
            {
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("09"));//產假                
            }
            if (ddlLeave_type.Items.Contains(new ListItem("流產假", "13")))
            {
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("13"));  //流產假              
            }
            if (ddlLeave_type.Items.Contains(new ListItem("產前假", "21")))
            {
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("21")); //天災               
            }
            if (ddlLeave_type.Items.Contains(new ListItem("生理假", "24")))
            {
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("24"));   //生理假             
            }
        }
        else
        {
            if (!ddlLeave_type.Items.Contains(new ListItem("娩假", "09")))
            {
                ddlLeave_type.Items.Add(new ListItem("娩假", "09"));     //產假           
            }
            if (!ddlLeave_type.Items.Contains(new ListItem("流產假", "13")))
            {
                ddlLeave_type.Items.Add(new ListItem("流產假", "13"));   //流產假             
            }
            if (!ddlLeave_type.Items.Contains(new ListItem("產前假", "21")))
            {
                ddlLeave_type.Items.Add(new ListItem("產前假", "21")); //天災               
            }
            if (!ddlLeave_type.Items.Contains(new ListItem("生理假", "24")))
            {
                ddlLeave_type.Items.Add(new ListItem("生理假", "24"));    //生理假            
            }
            if (ddlLeave_type.Items.Contains(new ListItem("陪產假", "22")))
            {
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("22"));      //天災          
            }
        }


            //一般請假中的公傷假、延長病假、器官捐贈假、天災假的假別要拿掉        
            if (ddlLeave_type.Items.Contains(new ListItem("公傷假", "15")))
            {
                ddlLeave_type.Items.Remove(new ListItem("公傷假", "15"));
            }
            if (ddlLeave_type.Items.Contains(new ListItem("延長病假", "16")))
            {
                ddlLeave_type.Items.Remove(new ListItem("延長病假", "16"));
            }
            if (ddlLeave_type.Items.Contains(new ListItem("器官捐贈假", "23")))
            {
                ddlLeave_type.Items.Remove(new ListItem("器官捐贈假", "23"));
            }
            if (ddlLeave_type.Items.Contains(new ListItem("天災假", "18")))
            {
                ddlLeave_type.Items.Remove(new ListItem("天災假", "18"));
            }

            ListItem item21 = ddlLeave_type.Items.FindByValue("21");
            ListItem item6 = ddlLeave_type.Items.FindByValue("06");

            ListItem item19 = ddlLeave_type.Items.FindByValue("19");
            if (ddlLeave_type.Items.Contains(item19))
            {
                ddlLeave_type.Items.Remove(item19);//其他假                
            }

            //駐署人員
            if (employee_type == "13")
            {
                ddlLeave_type.Items.Clear();
                ddlLeave_type.Items.Add(new ListItem("事假", "01"));
                ddlLeave_type.Items.Add(new ListItem("病假", "02"));
                ddlLeave_type.Items.Add(new ListItem("公假", "06"));
                ddlLeave_type.Items.Add(new ListItem("其他假", "19"));
            }

            hfApplyEmployeeType.Value = employee_type;    
    }



}