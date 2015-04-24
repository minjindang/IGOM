using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAL.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

public partial class Mobile_MOB1_MOB1203_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add 2014/07/11
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "加班費請領";
        BindMonth();
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

    public void BindMonth()
    {
        for (int i = DateTime.Now.Year - 1911; i >= 103; i += -1)
        {
            ddlYear.Items.Add(new ListItem(i.ToString().PadLeft(3, '0')));
        }

        ddlMonth.Items.Clear();
        if ((DateTime.Now.Year - 1911) == int.Parse(ddlYear.SelectedValue))
        {
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString().PadLeft(2, '0')));
            }
            ddlMonth.SelectedValue = (DateTime.Now.Month - 1).ToString().PadLeft(2, '0');
        }
        else
        {
            for (int i = 1; i <= 12; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString().PadLeft(2, '0')));
            }
        }
    }
    protected void cbQuery_Click(object sender, EventArgs e)
    {
        this.tbS.Visible = true;
        this.tbq.Visible = false;
        getData();
    }

    private void getData()
    {
        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string ID_card = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
              
        InitData();

        string ym = ddlYear.SelectedValue + ddlMonth.SelectedValue;
        //系統日期
        string ymd = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + DateTime.Now.ToString("MMdd");

        string u_fid = Request.QueryString["fid"];
        string u_org = Request.QueryString["org"];

      
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable dt = wsmob.WSMOB029(Orgcode, Depart_id,ID_card, ym, ymd);

        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add("PRATYPE_name");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PRATYPE"].ToString() == "1")
                {
                    dt.Rows[i]["PRATYPE_name"] = "一般";
                }
                else
                {
                    dt.Rows[i]["PRATYPE_name"] = "專案";
                }
            }
        }

        gv.DataSource = dt;
        gv.DataBind();

        cbConfirm.Enabled = dt.Rows.Count > 0;

        BindTip();

    }

    protected void BindTip()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string Depart_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
        string ID_card = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        string ym = ddlYear.SelectedValue + ddlMonth.SelectedValue;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        //差勤組別
        string PEKIND = wsmob.WSMOB068(ID_card);

            //每日加班時數上限(A)        
            int A = 4;
            hfA.Value = A.ToString();

        //專案加班時數上限(X) (專案加班檔)
        int X = 0;        
        DataTable rdt = wsmob.WSMOB069(Orgcode, Depart_id, ID_card, ym);
        if (rdt != null && rdt.Rows.Count > 0)
        {
            X = wsmob.WSMOB070(rdt.Rows[0]["MonOT_pay_hr"].ToString());
        }
        int Y = wsmob.WSMOB067(wsmob.WSMOB071(PEKIND));//CommonFun.ConvertToInt(New FSC.Logic.CPAPC03M().GetPCPARM1(PEKIND, "limit", "3"))


        int B = (X == 0 ? Y : X);
        hfB.Value = B.ToString();

            //若查無資料(專案加班檔裡無資料)，則X值即為B值               
            if (X == 0)
                X = B;
            hfX.Value = X.ToString();        

      
        //當月一般加班可用餘額(C) = 當月的加班數 - 已休時數 - 已領時數
        int C = 0;
        DataTable tdt = wsmob.WSMOB072(ID_card, ym,"1");
        if (tdt != null & tdt.Rows.Count > 0)
        {
            int praddh = CommonFun.ConvertToInt(tdt.Rows[0]["praddh"].ToString());
            int prpayh = CommonFun.ConvertToInt(tdt.Rows[0]["prpayh"].ToString());
            int prmnyh = CommonFun.ConvertToInt(tdt.Rows[0]["prmnyh"].ToString());

            hfC_prmnyh.Value = prmnyh.ToString();

            if (praddh - prpayh > 20)
            {
                C = 20 - prmnyh;
            }
            else
            {
                C = praddh - prpayh - prmnyh;
            }
        }
        else
        {
            C = 0;
        }
        hfC.Value = C.ToString();
        
            //當月專案加班可用餘額(D) = 當月專案加班數 - 已休時數 - 已領時數        
            int D = 0;
            DataTable tdt2 = wsmob.WSMOB072(ID_card, ym,"2");
            if (tdt2 != null & tdt2.Rows.Count > 0)
            {
                int praddh = CommonFun.ConvertToInt(tdt2.Rows[0]["praddh"].ToString());
                int prpayh = CommonFun.ConvertToInt(tdt2.Rows[0]["prpayh"].ToString());
                int prmnyh = CommonFun.ConvertToInt(tdt2.Rows[0]["prmnyh"].ToString());

                hfD_prmnyh.Value = prmnyh.ToString();

                if (praddh - prpayh > X)
                {
                    D = X - prmnyh;
                }
                else
                {
                    D = praddh - prpayh - prmnyh;
                }
            }
            else
            {
                D = 0;
            }
            hfD.Value = D.ToString();


            DataTable sdt = wsmob.WSMOB072(ID_card, ym,null);
            int total_praddh = 0;
            int total_prpayh = 0;
            int total_prmnyh = 0;

            if (sdt.Rows.Count > 0)
            {
                total_praddh = CommonFun.ConvertToInt(sdt.Rows[0]["praddh"].ToString());
                total_prpayh = CommonFun.ConvertToInt(sdt.Rows[0]["prpayh"].ToString());
                total_prmnyh = CommonFun.ConvertToInt(sdt.Rows[0]["prmnyh"].ToString());
            }
            hftotal_prmnyh.Value = total_prmnyh.ToString();


            StringBuilder tip = new StringBuilder();
            tip.AppendLine("<div style='line-height:20px; color:blue; '>");
            tip.AppendLine("<ul>");
            tip.AppendLine("<li>加班費計算方式：一般/專案加班費合併計算，且一般加班請領不大於一般加班月上限</li>");
            tip.AppendLine("<li>一般加班上限：20小時</li>");
            tip.AppendLine("<li>專案加班上限：{2}小時</li>");
            tip.AppendLine("<li><span style='color:red'>加班總數：{3} &nbsp;&nbsp;已休：{4} &nbsp;&nbsp;己領：{5} </span></li>");
            tip.AppendLine("<li><span style='color:red'>補休時數不列入加班費時數計算</span></li>");
            tip.AppendLine("<li>一般加班可領餘額：{6}小時</li>");
            tip.AppendLine("<li>專案加班可請領餘額：{7}小時</li>");
            tip.AppendLine("<li>總加加班可請領餘額：{8}小時</li>");
            tip.AppendLine("</ul>");
            tip.AppendLine("</div>");        
    }



    protected void InitData()
    {
        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string ID_card = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        string ym = ddlYear.SelectedValue + ddlMonth.SelectedValue;

        string Apply_seq = string.Empty;
        string Print_Mark = string.Empty;
        string Sum_date = string.Empty;

        //判斷案件目前請領狀態
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        DataTable omdt = wsmob.WSMOB030(Orgcode, Depart_id, ID_card, ym);

        if (omdt.Rows.Count <= 0)
        {
            //若查無資料，則表示尚未申請過，狀態為新增(Apply_Seq = ‘1’)
            Apply_seq = "1";
            ViewState["Status"] = "Add";
            cbConfirm.Visible = true;
        }
        else
        {
            ViewState["Status"] = null;

            Apply_seq = omdt.Rows[0]["Apply_seq"].ToString();
            Print_Mark = omdt.Rows[0]["Print_Mark"].ToString();
            Sum_date = omdt.Rows[0]["Sum_date"].ToString();

            ViewState["Status"] = "Lock";
            cbConfirm.Visible = false;
            cbReset.Visible = false;
        }
               
        ViewState["Apply_seq"] = Apply_seq;
 
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string ID_card = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        string ym = ddlYear.SelectedValue + ddlMonth.SelectedValue;

         MOB.MOBServices wsmob = new MOB.MOBServices();
         wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
          
            string Overtime_type = ((Label)e.Row.FindControl("gv_lbPRATYPE")).Text.Trim();
            string PRADDD = ((Label)e.Row.FindControl("gv_lbPRADDD")).Text.Trim();
            string PRADDE = ((Label)e.Row.FindControl("gv_lbPRADDE")).Text.Trim();
            string PRSTIME = ((Label)e.Row.FindControl("gv_lbPRSTIME")).Text.Trim();
            string Apply_seq = ViewState["Apply_seq"].ToString();

            string PRADDH = wsmob.WSMOB067(((Label)e.Row.FindControl("gv_lbPRADDH")).Text.Trim()).ToString();
            //加班時數
            string PRPAYH =  wsmob.WSMOB067(((Label)e.Row.FindControl("gv_lbPRPAYH")).Text.Trim()).ToString();
            //已休時數
            int PRMNYH =  wsmob.WSMOB067(((Label)e.Row.FindControl("gv_lbPRMNYH")).Text.Trim());
            //已領時數
            hfC.Value =  (wsmob.WSMOB067(hfC.Value) > 20 ? "20" : hfC.Value);

            
            int Orig_applyhour = 0;
            //本次請領時數
            int had_applyhour = 0;
            //非本次請領時數

            //取出本次請領的原本時數 及 上次請領的時數
         
            DataTable dt = wsmob.WSMOB031(Orgcode, Depart_id, ID_card, ym, PRADDD, PRSTIME);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Apply_seq"].ToString() == Apply_seq)
                    {
                        Orig_applyhour += Convert.ToInt32(dr["Apply_hour"].ToString());
                    }
                    else
                    {
                        had_applyhour += Convert.ToInt32(dr["Apply_hour"].ToString());
                    }
                }
            }
         
            //本次請領時數
            ((Label)e.Row.FindControl("gv_lbApply_hour")).Text = Orig_applyhour.ToString();

            //若P2K的已領時數，不等於PLM的本次請領時數+非本次請領時數
            //If PRMNYH <> Orig_applyhour + had_applyhour Then
            //    had_applyhour = PRMNYH
            //    CType(e.Row.FindControl("gv_lbApply_hour"), Label).Text = 0
            //    Orig_applyhour = 0
            //End If

            TextBox dllApply_hour = (TextBox)e.Row.FindControl("gv_txtApply_hour");
            dllApply_hour.Text = Orig_applyhour.ToString();


            //For i As Integer = 0 To PRADDH - PRPAYH - had_applyhour
            //    If i <= Orig_applyhour Then
            //        dllApply_hour.Items.Add(New ListItem(0 - i, 0 - i))
            //    Else
            //        dllApply_hour.Items.Add(New ListItem(i, i))
            //    End If
            //Next

/*          for (int i = 0; i <= Convert.ToInt32(PRADDH) - Convert.ToInt32(PRPAYH) - Convert.ToInt32(PRMNYH); i++)
            {
                dllApply_hour.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            if (Convert.ToInt32(dllApply_hour.Items[dllApply_hour.Items.Count - 1].Value) > 0)
            {
                dllApply_hour.SelectedIndex = dllApply_hour.Items.Count - 1;
            }

            if (Orig_applyhour == 0 & had_applyhour == 0 & Convert.ToInt32(PRADDH) == Convert.ToInt32(PRMNYH))
            {
                ((DropDownList)e.Row.FindControl("gv_ddlApply_hour")).Enabled = false;
            }

            //加班時數 = 已休時數,　不可修改
            if (PRADDH == PRPAYH)
            {
                ((DropDownList)e.Row.FindControl("gv_ddlApply_hour")).Enabled = false;
            }
*/

            if (ViewState["Status"] == "Lock")
            {
                ((TextBox)e.Row.FindControl("gv_txtApply_hour")).Enabled = false;
            }

            ((TextBox)e.Row.FindControl("gv_txtApply_hour")).Attributes.Add("onchange", "checkApplyHour('" + PRADDH + "', '" + PRPAYH + "', '" + PRMNYH + "', this.id, '" + Overtime_type + "');");

           // ((Label)e.Row.FindControl("gv_lbNo")).Text = (e.Row.DataItemIndex + 1).ToString();
     
        }
        
    }

    protected void cbConfirm_Click(object sender, EventArgs e)
    {
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string Depart_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        string ID_card = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        string Account = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Account);
        string ym = ddlYear.SelectedValue + ddlMonth.SelectedValue;

        int PRADDH = 0;
        int PRPAYH = 0;
        int PRMNYH = 0;
        int Apply_hour = 0;
        string overtime_type = null;
        string overtime_date = null;
        string overtime_end_date = null;
        string Applytime_start = null;
        string Applytime_end = null;
        string Overtime_start = null;
        string Overtime_end = null;
        string reason = null;
        string budget_type = string.Empty;
        int Normal_hour = 0;
        int Project_hour = 0;
        int Monthly_pay = 0;
        int Hour_pay = 0;
        int Orig_applyhour = 0;
        string Status = "" + ViewState["Status"].ToString();
        string Apply_seq = "" + ViewState["Apply_seq"].ToString();
        

        bool result = false;      

        string u_fid = "" + Request["fid"];
        string u_org = "" + Request["org"];
        bool isUpdate = false;
        string flow_id = "";

        if (!string.IsNullOrEmpty(u_fid) && !string.IsNullOrEmpty(u_org))
        {
            isUpdate = true;
            /*      Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
            ID_card = f.ApplyIdcard
             */
        }

        string strModifyAccount = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);


        DataTable sadt = wsmob.WSMOB006_1(Orgcode, ID_card, (int.Parse(ddlYear.SelectedValue)+ 1911).ToString(), ddlMonth.SelectedValue);
        if (sadt != null && sadt.Rows.Count > 0)
        {
            Monthly_pay =(int)Convert.ToDouble(sadt.Rows[0]["month_pay"].ToString());
            Hour_pay = int.Parse(sadt.Rows[0]["BASE_HOUR_SAL"].ToString());
        }


        foreach (System.Web.UI.WebControls.GridViewRow gvr in gv.Rows)
        {
            PRADDH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDH")).Text.Trim());
            //加班時數
            PRPAYH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRPAYH")).Text.Trim());
            //已休時數
            PRMNYH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRMNYH")).Text.Trim());
            //已領時數
            overtime_type = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRATYPE")).Text.Trim();
            //加班類別
            overtime_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDD")).Text.Trim();
            //加班日期
            overtime_end_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDE")).Text.Trim();
            //加班日期迄
            Applytime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbStart_time")).Text.Replace(":", "");
            //加班申請時間起
            Applytime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbEnd_time")).Text.Replace(":", "");
            //加班申請時間迄
            Overtime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRSTIME")).Text.Trim();
            //加班時間起
            Overtime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRETIME")).Text.Trim();
            //加班時迄
            reason = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRREASON")).Text.Trim();
            //事由
            Orig_applyhour = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbApply_hour")).Text.Trim());
         
            int x=0;
            if(!int.TryParse(((System.Web.UI.WebControls.TextBox)gvr.FindControl("gv_txtApply_hour")).Text.Trim(),out x))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                CommonFun.Msg.Custom, "請領時數需為數字!", "", "");
                this.Page = tempPage;
                return;
            }

            Apply_hour =int.Parse(((System.Web.UI.WebControls.TextBox)gvr.FindControl("gv_txtApply_hour")).Text.Trim());
            //請領時數

            if (Apply_hour > PRADDH - PRPAYH - (PRMNYH - Apply_hour))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                CommonFun.Msg.Custom, "請領時數需小於等於(加班時數-已休時數-已領時數)!", "", "");
                this.Page = tempPage;
                return;
            }
       
        }                    


        foreach (System.Web.UI.WebControls.GridViewRow gvr in gv.Rows)
        {
            PRADDH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDH")).Text.Trim());
            //加班時數
            PRPAYH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRPAYH")).Text.Trim());
            //已休時數
            PRMNYH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRMNYH")).Text.Trim());
            //已領時數
            overtime_type = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRATYPE")).Text.Trim();
            //加班類別
            overtime_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDD")).Text.Trim();
            //加班日期
            overtime_end_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDE")).Text.Trim();
            //加班日期迄
            Applytime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbStart_time")).Text.Replace(":", "");
            //加班申請時間起
            Applytime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbEnd_time")).Text.Replace(":", "");
            //加班申請時間迄
            Overtime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRSTIME")).Text.Trim();
            //加班時間起
            Overtime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRETIME")).Text.Trim();
            //加班時迄
            reason = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRREASON")).Text.Trim();
            //事由

            Orig_applyhour = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbApply_hour")).Text.Trim());

            Apply_hour = wsmob.WSMOB067(((System.Web.UI.WebControls.TextBox)gvr.FindControl("gv_txtApply_hour")).Text.Trim());
            //請領時數
                  

            if (overtime_type == "1")
            {
                Normal_hour += Apply_hour;
                //一般時數請領加總
            }
            else if (overtime_type == "2")
            {
                Project_hour += Apply_hour;
                //專案時數請領加總
            }

            wsmob.WSMOB006(Orgcode, ID_card, (int.Parse(ddlYear.SelectedValue) + 1911).ToString() ,
                ddlMonth.SelectedValue, Status, Depart_id, ym, Apply_seq, overtime_type, overtime_date, overtime_end_date,
                Applytime_start, Applytime_end, Overtime_start, Overtime_end, PRADDH, reason, strModifyAccount, Orig_applyhour, Apply_hour, Hour_pay);  
        }

        if (Normal_hour > 20)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
            CommonFun.Msg.Custom, "超過一般加班上限!", "", "");
            this.Page = tempPage;
            return;
        }

        if (Project_hour > wsmob.WSMOB067(hfX.Value))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
            CommonFun.Msg.Custom, "超過專案加班上限!", "", "");
            this.Page = tempPage;
            return;
        }

        if (Normal_hour + Project_hour > wsmob.WSMOB067(hfB.Value))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
            CommonFun.Msg.Custom, "超過每月請領加班上限!", "", "");
            this.Page = tempPage;
            return;
        }
        
     
              string ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
              string ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
              string ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
         

        string Submit = wsmob.WSMOB044(flow_id, isUpdate, u_fid, Orgcode, budget_type, ID_card, Status, Depart_id, ym, Apply_seq,
            strModifyAccount, Normal_hour, Project_hour, Monthly_pay, Hour_pay
           , ApplyName, ApplyPosid, ApplyStype, Account);

        JObject obj = JsonConvert.DeserializeObject<JObject>(Submit);
        string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
        string message = obj.Property("message").Value.ToString();
        if (strisSuccess == "Y")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已送出申請", "", "");
            this.Page = tempPage;

            getData();
        }
        else
        {  //false          
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, message, "", "");
            this.Page = tempPage;
        }

    }

    
    protected void cbBack_Click(object sender, EventArgs e)
    {
        tbS.Visible = false;
        tbq.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }
}