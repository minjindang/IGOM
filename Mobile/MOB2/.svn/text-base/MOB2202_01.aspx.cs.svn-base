using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSC.Logic;
using System.Data;

// 對應 FSC2103
public partial class Mobile_MOB2_MOB2202_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add 2014/07/11
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "請假紀錄查詢";
        InitControl();
    }

    private void Back2LastPage(object sender, EventArgs e)
    {
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
    }

    protected void InitControl() 
    {
        string Role_id = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.RoleId);

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") + "01";
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") + System.DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString().PadLeft(2, '0');
        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        //        string strRV = wsmob.WSMOB021();


        DataTable dt = wsmob.WSMOB021();
        ddlEmployeetype.DataTextField = "code_desc1";
        //顯示的中文名稱
        ddlEmployeetype.DataValueField = "code_no";
        //所代表的value
        ddlEmployeetype.DataSource = dt;
        //指定datatable給ddl
        ddlEmployeetype.DataBind();
        //ddl進行Databind
        ddlEmployeetype.Items.Insert(0, new ListItem("請選擇", ""));
        //Index=0，插入"請選擇"
        // 單位別
        // 假別
        DataTable dt3 = wsmob.WSMOB018();
        cblLeavetype.DataTextField = "Leave_name";   //'顯示的中文名稱
        cblLeavetype.DataValueField = "Leave_type";     //'所代表的value
        cblLeavetype.DataSource = dt3 ;              //'指定datatable給ddl
        cblLeavetype.DataBind() ;                    //'ddl進行Databind

        BindDepart1();
        //        UserName_Bind();

        if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.RoleId).IndexOf("unit_window") < 0)
        {
            string strParentDepart = wsmob.WSMOB028(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id));
            ddlDepart_01.SelectedValue = strParentDepart;
            if ((MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "" ||
                MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "0" ||
                MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "3")
                )
            {
                // 非主管 或 3級主管

                ddlDepart_01.SelectedValue = strParentDepart;
                BindDepart2();
                ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
                UserName_Bind();
                if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "" ||
                MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "0")
                {
                    txtUserID.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
                    tr01.Visible = false;
                    tr02.Visible = false;
                    tr03.Visible = false;
                    tr04.Visible = false;
                    tr05.Visible = false;
                    tr06.Visible = false;
                }
                ddlDepart_02.Enabled = false;
                ddlDepart_01.Enabled = false;

            }
            if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "2")
            {
                // 非主管
                ddlDepart_01.SelectedValue = strParentDepart;
                BindDepart2();
                UserName_Bind();
                ddlDepart_01.Enabled = false;
            }
        }

        cblStatus.DataSource = wsmob.WSMOB043();
        cblStatus.DataBind();
        foreach (ListItem i in cblStatus.Items)
        {
            if (i.Value == "001" | i.Value == "003" | i.Value == "002")
            {
                i.Selected = true;
            }
        }


        if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.isGeneral) == "1")
        {
            string strParentDepart = wsmob.WSMOB028(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id));
            ddlDepart_01.SelectedValue = strParentDepart;
            BindDepart2();
            ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
            UserName_Bind();
            ddlUserName.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);

            ddlDepart_01.Enabled = false;
            ddlDepart_02.Enabled = false;
            ddlUserName.Enabled = false;

            tr03.Visible = false; 
            tr04.Visible = false;
            tr05.Visible = false;
            tr06.Visible = false;
            tr07.Visible = false;  
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
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        getData();
        pnlResult.Visible = true;
        pnlQuery.Visible = false;
    }

    private void getData()
    {
        string orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        //機構代碼
        string departid = this.getDepartCode();
        string Apply_name = ddlUserName.SelectedValue;
        string Apply_idcard = txtUserID.Text;

        string Title_no = ddlJobtype.SelectedValue;
        string Quit_job_flag = ddlQuit_Job.SelectedValue;
        string PESEX = ddlsextype.SelectedValue;
        string Start_date = UcDate1.Text;
        string End_date = UcDate2.Text;
        string Leave_type = "";// string.Empty;
        string Employee_type = ddlEmployeetype.SelectedValue;
//        string Case_status = "";// string.Empty;

        /*
        int count1 = 0;
        foreach (ListItem cbx in cblStatus.Items)
        {
            if (cbx.Selected & count1 == 0)
            {
                Case_status += cbx.Value;
                count1 = count1 + 1;
            }
            else if (cbx.Selected & count1 != 0)
            {
                Case_status += "," + cbx.Value;
            }
        }
         */

        int count = 0;
        foreach (ListItem x in cblLeavetype.Items)
        {
            if (x.Selected & count == 0)
            {
                Leave_type += x.Value;
                count = count + 1;
            }
            else if (x.Selected & count != 0)
            {
                Leave_type += "," + x.Value;
            }

        }

        if (departid == "ALL") departid = string.Empty;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        DataTable dt = new DataTable();
        foreach (ListItem i in cblStatus.Items)
        {
            if (i.Selected)
            {
//                DataRow r = new FSCPLM.Logic.SACode().GetRow("023", "002", i.Value);
//                DataRow r= wsmob.wsmob064


                string caseStatus = wsmob.WSMOB064(i.Value); //r["code_remark1"].ToString();
                string lastPass = wsmob.WSMOB065(i.Value); //r["code_remark2"].ToString();

                DataTable tmp = wsmob.WSMOB010(orgcode, Apply_idcard, departid, Apply_name,
                        Apply_idcard, Title_no, Quit_job_flag, PESEX, Start_date, End_date, Leave_type, Employee_type, caseStatus, "", "", lastPass);

                if (tmp != null && tmp.Rows.Count > 0)
                {
                    dt.Merge(tmp);
                }
            }
        }

        /*
        DataTable dt = wsmob.WSMOB010(orgcode,Apply_idcard,departid,Apply_name,
            Apply_idcard, Title_no, Quit_job_flag, PESEX, Start_date, End_date, Leave_type, Employee_type, Case_status, "", "");
         */
        gvlist.DataSource = dt;
        gvlist.DataBind();   


    }


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

        //        Response.Write(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode)+"<BR>"+getDepartCode()+" "+dt.Rows.Count.ToString());
        //        UpdatePanel2.Update();

    }


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
        //        BindDepart1();
        UserName_Bind();

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
    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlist.PageIndex = e.NewPageIndex;
        getData();
    }
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] =
            this.Page.ClientScript.GetPostBackEventReference((GridView)sender, "Select$" + e.Row.RowIndex);
        }
    }
    protected void gvlist_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow gRow = //(GridView)sender;
    gvlist.Rows[e.NewSelectedIndex];
        Label lb_pyvtype = (Label)gRow.FindControl("lb_pyvtype");
        Label lbStatus = (Label)gRow.FindControl("lbStatus");
        Label lbId_card = (Label)gRow.FindControl("lbId_card");
        Label lbUser_name = (Label)gRow.FindControl("lbUser_name");
        Label lbLeave_type = (Label)gRow.FindControl("lbLeave_type");
        Label lbLeave_hours = (Label)gRow.FindControl("lbLeave_hours");
        UControl_UcShowDate UcShowDate1 = (UControl_UcShowDate)gRow.FindControl("UcShowDate1");
        UControl_UcShowTime UcShowTime1 = (UControl_UcShowTime)gRow.FindControl("UcShowTime1");
        UControl_UcShowDate UcShowDate2 = (UControl_UcShowDate)gRow.FindControl("UcShowDate2");
        UControl_UcShowTime UcShowTime2 = (UControl_UcShowTime)gRow.FindControl("UcShowTime2");

        Label lbDeputy = (Label)gRow.FindControl("lbDeputy");
        Label lbLast_name = (Label)gRow.FindControl("lbLast_name");
        Label lbReason = (Label)gRow.FindControl("lbReason");

        lblSerNo.Text = lb_pyvtype.Text;
        Case_status.Text    = lbStatus.Text;
        Id_card.Text    = lbId_card.Text;
        User_name.Text    = lbUser_name.Text;
        Leave_name.Text = lbLeave_type.Text;
        Leave_hours.Text = lbLeave_hours.Text;
        Start_date.Text = ((Label)UcShowDate1.FindControl("lbDate")).Text;
        Start_time.Text = ((Label)UcShowTime1.FindControl("lbTime")).Text;
        End_date.Text = ((Label)UcShowDate2.FindControl("lbDate")).Text;
        End_time.Text = ((Label)UcShowTime2.FindControl("lbTime")).Text;
        Deputy.Text = lbDeputy.Text;
        Process.Text = lbLast_name.Text;
        Reason.Text = lbReason.Text;

        pnlQuery.Visible = false;
        pnlResult.Visible = false;
        pnlDetail.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlQuery.Visible = false;
        pnlResult.Visible = true;
        pnlDetail.Visible = false;
        getData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        pnlQuery.Visible = true;
        pnlResult.Visible = false;
        pnlDetail.Visible = false;
        
    }
}