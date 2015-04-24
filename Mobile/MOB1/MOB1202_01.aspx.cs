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

public partial class Mobile_MOB1_MOB1202_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add 2014/07/11
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "申請公差";
        InitControl(); //初始設定
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

    protected void InitControl()
    {      
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        DataTable dt = wsmob.WSMOB027(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode),
                                      MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id), "");
        //請假申請人
        UcLeaveMember.DataTextField = "full_name";
        UcLeaveMember.DataValueField = "Id_card";
        UcLeaveMember.DataSource = dt;
        UcLeaveMember.DataBind();
        UcLeaveMember.SelectedValue = MOBLoginManager.UserId;
        setValueAppl();
        
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
        bindDeputy();   //代理人_1
        BindPosid();    //value
   
        BindCity();    
        BindTransport();
        
    }

    private void setValueAppl() //申請人value
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        DataTable dt = wsmob.WSMOB054(UcLeaveMember.SelectedValue);
        DataTable edt = wsmob.WSMOB055(UcLeaveMember.SelectedValue);
        if (dt != null && dt.Rows.Count > 0)
        {
            hfApply_name.Text = dt.Rows[0]["User_name"].ToString();
            hfApply_id.Text = dt.Rows[0]["Id_card"].ToString();
            hfApply_posid.Text = dt.Rows[0]["Title_No"].ToString();
            hfApply_stype.Text = edt.Rows[0]["Service_type"].ToString();
        }
    }



    private void bindDeputy() //代理人_1
    {
        string ApplyIdcard = UcLeaveMember.SelectedValue;
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
            hfDeputyPosid.Text = wsmob.WSMOB066("title_no", UcLeaveMember.SelectedValue);
            //            hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", value[2]);

        }
        else if (rb2.Checked)
        {
            hfOrgcode.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
            hfDepartId.Text = ddlUserName.SelectedValue;
            MOB.MOBServices wsmob = new MOB.MOBServices();
            wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
            hfDeputyPosid.Text = wsmob.WSMOB066("title_no", UcLeaveMember.SelectedValue);
            //hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", ddlUserName.SelectedValue);
        }
    }

    // 城市
    private void BindCity()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB033();
        ddlCity.DataSource = dt;
        ddlCity.DataBind();
    }

    // 交通工具
    private void BindTransport()
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB032();
        cbxlTransport.DataSource = dt;
        cbxlTransport.DataBind();
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
            , getDepartCode() , "", "", "");
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

    //申請人改變
    protected void ddlleaveName_SelectedIndexChanged(object sender, EventArgs e)
    {
  //    UcLeaveDate.Apply_id = UcLeaveMember.SelectedValue;  //重新指定申請人 設定 預設請假日期時間
  //      BindDepart1(); //代理人 第一層    
        bindDeputy();//代理人_1 
        BindPosid(); 
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
        hfDeputyPosid.Text = wsmob.WSMOB066("title_no", UcLeaveMember.SelectedValue);

        //hfDeputyPosid.Text = new FSC.Logic.Personnel().GetColumnValue("title_no", Deputy_id);
    }



    protected void ddlDepart_01_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDepart2();
    }
    protected void ddlDepart_02_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserName_Bind();
    }

    protected void hcbx_CheckedChanged(object sender, System.EventArgs e)
    {
        if (hcbx.Checked)
        {
            UcHolidayDate.Start_date = UcLeaveDate.Start_date;
            UcHolidayDate.End_date = UcLeaveDate.End_date;
            UcHolidayDate.Start_time = UcLeaveDate.Start_time;
            UcHolidayDate.End_time = UcLeaveDate.End_time;
        }
        else
        {
            UcHolidayDate.Start_date = "";
            UcHolidayDate.End_date = "";
            UcHolidayDate.Start_time = "";
            UcHolidayDate.End_time = "";
        }
    }
    
    protected void gv_cbxholiday_CheckedChanged(object sender, System.EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((CheckBox)sender).NamingContainer;
        UControl_UcMOBLeaveDate ucd = (UControl_UcMOBLeaveDate)gvr.FindControl("gv_UcLeaveDate");
        UControl_UcMOBLeaveDate uch = (UControl_UcMOBLeaveDate)gvr.FindControl("gv_UcHolidayDate");
        CheckBox cbxNight = (CheckBox)gvr.FindControl("gv_cbxNight");

        if (((CheckBox)sender).Checked)
        {
            uch.Start_date = ucd.Start_date;
            uch.End_date = ucd.End_date;
            uch.Start_time = ucd.Start_time;
            uch.End_time = ucd.End_time;
            cbxNight.Checked = false;
            cbxNight.Enabled = false;
        }
        else
        {
            uch.Start_date = "";
            uch.End_date = "";
            uch.Start_time = "";
            uch.End_time = "";
            cbxNight.Enabled = true;
        }
    }


    protected bool CheckField()
    {
            if (string.IsNullOrEmpty(UcLeaveDate.Start_date))
            {            Page tempPage = this.Page;

            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期起日不可空白，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }
            if (string.IsNullOrEmpty(UcLeaveDate.Start_time))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期起時不可空白，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }
            if (string.IsNullOrEmpty(UcLeaveDate.End_date))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期迄日不可空白，請重新輸入!", "", "");

                this.Page = tempPage;
                return false;
            }
            if (string.IsNullOrEmpty(UcLeaveDate.End_time))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期迄時不可空白，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }
            if (double.Parse(UcLeaveDate.Start_date) > double.Parse(UcLeaveDate.End_date))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }
            else if (UcLeaveDate.Start_date == UcLeaveDate.End_date & double.Parse(UcLeaveDate.Start_time) > double.Parse(UcLeaveDate.End_time))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!", "", "");
                this.Page = tempPage;
                return false;
            }

             //代理人必填
            string idcard;
            if (rb1.Checked)
            {
                string[] value = ddlDefaultDeputy.SelectedValue.Split(',');
                idcard = value[2];
            }
            else
            {
                idcard = ddlUserName.SelectedValue;
            }

            if (idcard == "")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請選擇代理人!", "", "");
                this.Page = tempPage;
                return false;
            }
            //事由必填
            if (tbReason.Text.Trim() == "")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "事由不可空白!", "", "");
                this.Page = tempPage;
                return false;
            }

            if (hcbx.Checked)
            {
                if (string.IsNullOrEmpty(UcHolidayDate.Start_date) || string.IsNullOrEmpty(UcHolidayDate.End_date) || string.IsNullOrEmpty(UcHolidayDate.Start_time) || string.IsNullOrEmpty(UcHolidayDate.End_time))
                {
                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "假日執行公務起迄日期不可空白!", "", "");
                    this.Page = tempPage;
                    return false;
                }
                if ((double.Parse(UcHolidayDate.Start_date + UcHolidayDate.Start_time) < double.Parse(UcLeaveDate.Start_date + UcLeaveDate.Start_time)) | (double.Parse(UcHolidayDate.End_date + UcHolidayDate.End_time) > double.Parse(UcLeaveDate.End_date + UcLeaveDate.End_time)))
                {
                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "假日執行公務起迄日超出公務起迄範圍，不可指定為假日執行公務!", "", "");
                    this.Page = tempPage;
                    return false;
                }
                if (double.Parse(UcHolidayDate.End_date) < double.Parse(UcHolidayDate.Start_date))
                {
                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "假日執行公務申請日期起日不可大於迄日，請重新輸入!", "", "");
                    this.Page = tempPage;
                    return false;
                }
                else
                {
                    if (UcHolidayDate.End_date == UcHolidayDate.Start_date)
                    {
                        if (double.Parse(UcHolidayDate.End_time) < double.Parse(UcHolidayDate.Start_time))
                        {
                            Page tempPage = this.Page;
                            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "假日執行公務申請日期起日不可大於迄日，請重新輸入!", "", "");
                            this.Page = tempPage;
                            return false;
                        }
                    }
                }
            }
         // 交通工具勾選飛機/高鐵時，必填理由說明

        foreach (ListItem li in cbxlTransport.Items)
        {
            if (li.Selected)
            {
                if (li.Text == "飛機" | li.Text == "高鐵")
                {
                    if (string.IsNullOrEmpty(this.ucTransportDesc.Text))
                    {
                        Page tempPage = this.Page;
                        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "交通工具勾選飛機/高鐵時，理由說明不可空白，請重新輸入!", "", "");
                        this.Page = tempPage;
                        return false;
                    }
                }
            }
        }
        return true;
    }

 
    protected void cbSubmit_Click(object sender, EventArgs e)
    {
        string OrgCode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);

        if (!CheckField()) {
	        return;
        }

        string u_fid = ""+Request["fid"];
        string u_org = ""+Request["org"];
        bool isUpdate = false;

        if (!string.IsNullOrEmpty(u_fid) && !string.IsNullOrEmpty(u_org)) {
	        isUpdate = true;
        }

        string reason = tbReason.Text.Trim(); //事由

        string transport = "";  //交通工具
		        foreach (ListItem item in cbxlTransport.Items) {
			        if (item.Selected) {
				        if (!string.IsNullOrEmpty(transport)) {
					        transport += ",";
				        }
				        transport += item.Value;
			        }
		        }

      string DeputyDepartid = "";//代理人單位代碼
      string DeputyIdcard = "";  //代理人ID Card
      string DeputyName = "";    //代理人Name
      string DeputyPosid = hfDeputyPosid.Text;

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
          DeputyDepartid = ddlDepart_01.SelectedValue; 
          if (ddlDepart_02.SelectedValue != "")
              DeputyDepartid = ddlDepart_02.SelectedValue;

          DeputyIdcard = ddlUserName.SelectedValue;
          DeputyName = ddlUserName.SelectedItem.Text;
      }

       
        string WriterIdcard = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Account);
        string WriterName = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.User_name);
        string WriterPosid = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Title_no);   
        string Place=UcDetailPlace.Text.Trim();  //出差明細地點
        string LocationFlag = rblLocationFlag.SelectedValue;  //公差地點
        string Start_date = UcLeaveDate.Start_date; // 請假開始日期
        string End_date   = UcLeaveDate.End_date  ; // 請假結束日期
        string Start_time = UcLeaveDate.Start_time ;// 請假開始時間
        string End_time   = UcLeaveDate.End_time;   // 請假結束時間
        string HStart_date = UcHolidayDate.Start_date;// 假日請假開始日期
        string HEnd_date = UcHolidayDate.End_date;    // 假日請假結束日期
        string HStart_time = UcHolidayDate.Start_time;// 假日請假開始時間
        string HEnd_time = UcHolidayDate.End_time;    // 假日請假結束時間
        string PlaceCity    = ddlCity.SelectedValue;  //國內公差地點
        string TransportDesc = ucTransportDesc.Text;  //搭乘高鐵或飛機之理由說明
        string Apply_name = UcLeaveMember.SelectedItem.Text; //申請之 name
        string Apply_id = UcLeaveMember.SelectedValue;       //申請之 ID Card
        string[] APnames = Apply_name.Split('/');
        Apply_name = APnames[1];
        string Apply_posid = hfApply_posid.Text;
        string Apply_stype = hfApply_stype.Text;


        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        string Submit = wsmob.WSMOB005(isUpdate, u_fid, OrgCode, "05", transport, Depart_id,
            Apply_id, Apply_name,Apply_posid,Apply_stype, DeputyDepartid, DeputyIdcard,  DeputyName,DeputyPosid
            ,WriterIdcard,WriterName,WriterPosid,reason,Place,LocationFlag,
            Start_date,End_date, Start_time,End_time,HStart_date,HEnd_date,HStart_time,HEnd_time
            ,PlaceCity,TransportDesc,hcbx.Checked);

        JObject obj = JsonConvert.DeserializeObject<JObject>(Submit);
        string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
        string message = obj.Property("message").Value.ToString();

        if (strisSuccess == "Y")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已送出申請", "", "");
            this.Page = tempPage;
        }
        else //false
        {           
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, message, "", "");
            this.Page = tempPage;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
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
    protected void ddlDefaultDeputy_SelectedIndexChanged(object sender, EventArgs e)
    {
        setValue();
    }
    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPosid();
    }

    //選國內外
    protected void rblLocationFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblLocationFlag.SelectedValue == "0")
        {
            ddlCity.Visible = true;
        }
        else
        {
            ddlCity.Visible = false;
        }
    }
}