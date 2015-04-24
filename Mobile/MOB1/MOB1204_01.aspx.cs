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

public partial class Mobile_MOB1_MOB1204_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "加班費請領(適用勞基法)";
        BindMonth();
        InitData();
    }

    private void Back2LastPage(object sender, EventArgs e)
    {
        Response.Redirect("~/Mobile/main.aspx");      
    }

    protected void InitData()
    {
        hdOrgcode.Value = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        hdDepart_id.Value = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
        hdPerId.Value = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
        lbUserName.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.User_name);

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

    /*  int hour_pay = 0;

        DataTable dt = wsmob.WSMOB034(hdOrgcode.Value,hdPerId.Value);
        
        if (dt != null && dt.Rows.Count > 0)
        {
            hour_pay = CommonFun.ConvertToInt(dt.Rows[0]["BASE_HOUR_SAL"].ToString());
        }

        this.lbHourPay.Text = hour_pay.ToString();
        */

        lbHourPay.Text = wsmob.WSMOB073(hdPerId.Value);

        DataTable pdt = wsmob.WSMOB075(hdOrgcode.Value, hdDepart_id.Value, hdPerId.Value);
        if ((pdt != null) && pdt.Rows.Count > 0)
        {
            this.hdPESEX.Value = pdt.Rows[0]["PESEX"].ToString();
            this.hdPEKIND.Value = pdt.Rows[0]["PEKIND"].ToString();
        }

        string param = string.Empty;
        string param1 = string.Empty;

        switch (this.hdPESEX.Value)
        {
            case "1":
                //男
                param = "18";
                param1 = "20";
                break;
            case "0":
                //女
                param = "19";
                param1 = "21";
                break;
        }

        DataTable pc03mdt =  wsmob.WSMOB036(hdPEKIND.Value);
            //new FSC.Logic.CPAPC03M().DAO.GetDataByKind(hdPEKIND.Value);
        if (pc03mdt.Rows.Count > 0)
        {
            foreach (DataRow dr in pc03mdt.Rows)
            {
                if (param == dr["PCCODE"].ToString())
                {
                    lbLimit.Text = dr["PCPARM1"].ToString();
                }
                if (param1 == dr["PCCODE"].ToString())
                {
                    lbLimit_H.Text = dr["PCPARM1"].ToString();
                }
            }
        }

        if (string.IsNullOrEmpty(lbLimit_H.Text) || lbLimit_H.Text=="")
        {
            //若含假日請領上限為空, 則同請領上限
            lbLimit_H.Text = lbLimit.Text;
        }

        lbLimit.Text = (string.IsNullOrEmpty(lbLimit.Text) ? "0" : lbLimit.Text);
        lbLimit_H.Text = (string.IsNullOrEmpty(lbLimit_H.Text) ? "0" : lbLimit_H.Text);
        

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
        tbS.Visible = true;
        tbq.Visible = false;
        Bind();
    }

    protected void Bind()
    {
        hdYear.Value = ddlYear.SelectedValue;
        hdMonth.Value = ddlMonth.SelectedValue;

        string u_fid = ""+Request["fid"];
        string u_org = ""+Request["org"];


        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        DataTable dt = wsmob.WSMOB037(hdOrgcode.Value, hdDepart_id.Value, hdYear.Value + hdMonth.Value, hdPerId.Value);
        this.gvList.DataSource = dt;
        this.gvList.DataBind();

     /*   if (gvList.Rows.Count > 0)
        {
            toUpdate.Visible = true;
        }
        else
        {
            toUpdate.Visible = false;
        }

        */

    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button toUpdate = (Button)e.Row.FindControl("toUpdate");
        if ((toUpdate != null))
        {
            toUpdate.CommandArgument = e.Row.RowIndex.ToString();
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox tbApplyHour1 = (TextBox)e.Row.FindControl("tbApplyHour1");
            TextBox tbApplyHour2 = (TextBox)e.Row.FindControl("tbApplyHour2");
            TextBox tbApplyHour3 = (TextBox)e.Row.FindControl("tbApplyHour3");

            string chgApplyHours = "chgApplyHours('" + tbApplyHour1.ClientID + "','" + tbApplyHour2.ClientID + "','" + tbApplyHour3.ClientID + "');";
            if (tbApplyHour1 != null)
            {
                tbApplyHour1.Attributes.Add("onblur", chgApplyHours + "AutoCount('tbApplyHour1')");
            }

            if (tbApplyHour2 != null)
            {
                tbApplyHour2.Attributes.Add("onblur", chgApplyHours + "AutoCount('tbApplyHour2')");
            }

            if (tbApplyHour3 != null)
            {
                tbApplyHour3.Attributes.Add("onblur", chgApplyHours + "AutoCount('tbApplyHour3')");
            }
        }
    }

    protected void toCount_Click(object sender, EventArgs e)
    {

    }

    protected void toUpdate_Click(object sender, EventArgs e)
    {
        	
        if (this.gvList == null || this.gvList.Rows.Count == null) {
		    return;
	    }

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        string Orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        string DepartID = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
	    string YearMonth = hdYear.Value + hdMonth.Value;
	    string Id_Card = hdPerId.Value;
        int total_hours = 0; //加班總時數       
        int project_total_hour = 0; //專案加班總時數                
        int limit = wsmob.WSMOB070(lbLimit.Text); //上限時數
        string u_fid = Request["fid"];
        string u_org = Request["org"];
        bool isUpdate = false;
        string flow_id = "";
        string formId = "002014";

        StringBuilder TotalMsg = new StringBuilder();

	    //取得限制參數，至機關制度參數資料檔
	    double F1 = 0;
	    double F2 = 0;    
	    DataTable dtCPAPC03M = wsmob.WSMOB036(hdPEKIND.Value);
        if ((dtCPAPC03M != null) && dtCPAPC03M.Rows.Count >0)
        {
		    foreach (DataRow rowCPAPC03M in dtCPAPC03M.Rows) 
            {
			    //PCCODE = 15 : 加班前二小時倍數()
			    //PCCODE = 16 : 加班後二小時後倍數()
			    switch (rowCPAPC03M["PCCODE"].ToString()) 
                {
				    case "15":
					    F1 = Convert.ToDouble(rowCPAPC03M["PCPARM1"]);
					    break;
				    case "16":
                        F2 = Convert.ToDouble(rowCPAPC03M["PCPARM1"]);
					    break;
			    }
		    }
	    }
      
	    //職務類別	  
        string PEMEMCOD = wsmob.WSMOB035(hdPerId.Value);
        if (PEMEMCOD == "10")
        {
            //特約人員時，走不同流程
            formId = "002019";
        }

        //月薪        
        int total_sa = 0;        
        int totalOvertimePay = 0;

        if (!string.IsNullOrEmpty(u_fid) && !string.IsNullOrEmpty(u_org))
        {
            isUpdate = true;
        }                       

                flow_id = (isUpdate ? u_fid : wsmob.WSMOB045(Orgcode));
        
                foreach (System.Web.UI.WebControls.GridViewRow row in gvList.Rows)
                {
                    int hour_pay = 0;
                    double Overtime_Pay = 0;

                    string PRADDD = ((System.Web.UI.WebControls.Label)row.FindControl("lblPRADDD")).Text;//row.Cells[0].Text;
                    string REASON = ((System.Web.UI.WebControls.Label)row.FindControl("lblPRREASON")).Text;//row.Cells[2].Text;
                    int PRADDH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)row.FindControl("lblPRADDH")).Text);//CommonFun.ConvertToInt(row.Cells[5].Text);
                    int PRADDE = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)row.FindControl("lblPRADDE")).Text);//CommonFun.ConvertToInt(row.Cells[1].Text);
                    int PRPAYH = wsmob.WSMOB067(((System.Web.UI.WebControls.Label)row.FindControl("lblPRPAYH")).Text);//CommonFun.ConvertToInt(row.Cells[6].Text);

                    string PRSTIME = ((System.Web.UI.WebControls.HiddenField)row.FindControl("hdOvertimeStart")).Value;
                    string PRETIME = ((System.Web.UI.WebControls.HiddenField)row.FindControl("hdOvertimeEnd")).Value;
                    string PRATYPE = ((System.Web.UI.WebControls.HiddenField)row.FindControl("hdPRATYPE")).Value;

                    int Apply_Hour_1 = Convert.ToInt16(((System.Web.UI.WebControls.TextBox)row.FindControl("tbApplyHour1")).Text);
                    int Apply_Hour_2 = Convert.ToInt16(((System.Web.UI.WebControls.TextBox)row.FindControl("tbApplyHour2")).Text);
                    int Apply_Hour_3 = Convert.ToInt16(((System.Web.UI.WebControls.TextBox)row.FindControl("tbApplyHour3")).Text);

                    //檢核時數
                    string msg = "";

                    if (Apply_Hour_1 != 0 | Apply_Hour_2 != 0 | Apply_Hour_3 != 0)
                    {
                        int tmp_hours = 0;
                        if (Apply_Hour_3 >= 1 & Apply_Hour_3 <= 8)
                        {
                            tmp_hours += (Apply_Hour_1 + Apply_Hour_2 + 8);
                        }
                        else
                        {
                            tmp_hours += (Apply_Hour_1 + Apply_Hour_2 + Apply_Hour_3);
                        }

                        if (PRATYPE == "2")
                        {
                            project_total_hour += tmp_hours; //專案加班
                        }
                        else if (PRATYPE == "1" && (PEMEMCOD.Equals("3") || PEMEMCOD.Equals("4") || PEMEMCOD.Equals("8")))
                        {
                            total_hours += tmp_hours;
                            //技工工友、臨時人員、駕駛一般加班要納入請領上限,大批加班不用納入請領上限
                        }
                        else if (!(PEMEMCOD.Equals("3") || PEMEMCOD.Equals("4") || PEMEMCOD.Equals("8")))
                        {
                            total_hours += tmp_hours;
                            //人事人員一般加班、大批加班皆要納入請領上限
                        }

                         msg = wsmob.WSMOB007(PRADDD, PRADDH, PRPAYH, Apply_Hour_1, Apply_Hour_2, Apply_Hour_3
                            , Id_Card, limit, total_hours, project_total_hour);  
                    }

                    if (msg == "")
                    {
                        //取申請時, 當下的月薪, 時薪                        
                        DataTable sadt = wsmob.WSMOB007_1(Orgcode, Id_Card, (int.Parse(ddlYear.SelectedValue) + 1911).ToString() + ddlMonth.SelectedValue);
                        if (sadt != null && sadt.Rows.Count > 0)
                        {
                            total_sa = Convert.ToInt32(sadt.Rows[0]["month_pay"]);
                            hour_pay = Convert.ToInt32(sadt.Rows[0]["BASE_HOUR_SAL"]);
                        }

                        Overtime_Pay = wsmob.WSMOB007_2(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, total_sa, PEMEMCOD,
                            hdOrgcode.Value, hdDepart_id.Value, YearMonth, hdPerId.Value, PRADDD, PRSTIME, PRETIME, PRADDH,
                                              REASON, flow_id);
                        totalOvertimePay += (int)Overtime_Pay;   
                    }
                    else
                    {
                        TotalMsg.Append(msg).Append("\n");
                    }

             
                }
                
                if (!string.IsNullOrEmpty(TotalMsg.ToString()))
                {
                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage,
                    CommonFun.Msg.Custom, TotalMsg.ToString(), "", "");
                    this.Page = tempPage;
                    return;                
                }

                string flowReason = "請領加班費：" + totalOvertimePay.ToString() + "元";

        string User_name =  MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.User_name);
        string Title_no = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Title_no);
        string Service_type =  MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Service_type);
        string Account = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
        String Submit2 = wsmob.WSMOB046(flow_id, Orgcode, DepartID, Id_Card, User_name,Title_no
                , Service_type, Account, formId, flowReason);

        JObject obj2 = JsonConvert.DeserializeObject<JObject>(Submit2);
        string strisSuccess2 = obj2.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N
        string message2 = obj2.Property("message").Value.ToString();
        if (strisSuccess2 == "Y")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已送出申請", "", "");
            this.Page = tempPage;
            tbS.Visible = false;
        }
        else
        {
            //false
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, message2, "", "");
            this.Page = tempPage;
        }     


    }            
    

    protected void Button1_Click1(object sender, EventArgs e)
    {
        tbS.Visible = false;
        tbq.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }

    protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
               
        string A =  (wsmob.WSMOB074(this.hdPEKIND.Value, "15"));
        string B = (wsmob.WSMOB074(this.hdPEKIND.Value, "16"));
        string C = "1";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Overtime_Pay_H = (Label)e.Row.FindControl("Overtime_Pay_Head");
            Overtime_Pay_H.Text ="(1)*" + A + "+(2)*" + B + "+(3)*" + C;

        }
    }

    protected void gvList_DataBound(object sender, EventArgs e)
    {
        double sum1 = 0;
        double sum2 = 0;
        double sum3 = 0;
        double sum4 = 0;
        double sum5 = 0;
        double sum6 = 0;
        double sum7 = 0;
        bool isLock = false;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
              

        DataTable dtFeeMaster =wsmob.WSMOB081(hdOrgcode.Value, hdDepart_id.Value, hdPerId.Value, hdYear.Value , hdMonth.Value);

        if ((dtFeeMaster != null) && dtFeeMaster.Rows.Count > 0)
        {
            string u_fid = Request["fid"];
            string u_org = Request["org"];


            if (string.IsNullOrEmpty(u_fid) || string.IsNullOrEmpty(u_org))
            {
                isLock = true;
                toUpdate.Visible = false;
                toReset.Visible = false;
            }
        }

        foreach (GridViewRow row in this.gvList.Rows)
        {
            TextBox tbApplyHour1 = (TextBox)row.FindControl("tbApplyHour1");
            TextBox tbApplyHour2 = (TextBox)row.FindControl("tbApplyHour2");
            TextBox tbApplyHour3 = (TextBox)row.FindControl("tbApplyHour3");
         
            if (isLock)
            {
                tbApplyHour1.Enabled = false;
                tbApplyHour2.Enabled = false;
                tbApplyHour3.Enabled = false;
                tbApplyHour1.Enabled = false;
                tbApplyHour2.Enabled = false;
                tbApplyHour3.Enabled = false;
                this.toCount.Visible = false;
                this.toUpdate.Visible = false;
                this.toReset.Visible = false;
                this.toPrint.Visible = false;
                this.cbRTP2.Visible = false;
            }         

            sum1 += ((tbApplyHour1 != null || tbApplyHour1.Text != "") ? Convert.ToDouble(tbApplyHour1.Text) : 0);
            sum2 += ((tbApplyHour2 != null || tbApplyHour2.Text != "") ? Convert.ToDouble(tbApplyHour2.Text) : 0);
            sum3 += ((tbApplyHour3 != null || tbApplyHour3.Text != "") ? Convert.ToDouble(tbApplyHour3.Text) : 0);

            Label lblPRADDH = (Label)row.FindControl("lblPRADDH");
            Label lblPRPAYH = (Label)row.FindControl("lblPRPAYH");
            Label lblPRMNYH = (Label)row.FindControl("lblPRMNYH");
            Label lblOvertime_Pay = (Label)row.FindControl("lblOvertime_Pay");

            sum4 += ((lblPRADDH.Text != "") ? Convert.ToDouble(lblPRADDH.Text.Trim()) : 0);
            sum5 += ((lblPRPAYH.Text != "") ? Convert.ToDouble(lblPRPAYH.Text.Trim()) : 0);
            sum6 += ((lblPRMNYH.Text != "") ? Convert.ToDouble(lblPRMNYH.Text.Trim()) : 0);
            sum7 += ((lblOvertime_Pay.Text != "") ? Convert.ToDouble(lblOvertime_Pay.Text.Trim()) : 0);
        }
        
        if ((this.gvList.FooterRow != null))
        {
            ((Label)gvList.FooterRow.FindControl("footPRADDH")).Text = sum4.ToString();
            ((Label)gvList.FooterRow.FindControl("footPRPAYH")).Text = sum5.ToString();
            ((Label)gvList.FooterRow.FindControl("footPRMNYH")).Text = sum6.ToString();
            ((Label)gvList.FooterRow.FindControl("foot1")).Text = sum1.ToString();
            ((Label)gvList.FooterRow.FindControl("foot2")).Text = sum2.ToString();
            ((Label)gvList.FooterRow.FindControl("foor3")).Text = sum3.ToString();
            ((Label)gvList.FooterRow.FindControl("foot4")).Text = sum7.ToString();
        }

    }


}