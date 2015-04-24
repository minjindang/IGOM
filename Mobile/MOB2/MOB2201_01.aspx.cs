using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSC.Logic;
using System.Data;

public partial class Mobile_MOB2_MOB2201_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add 2014/07/11
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;

        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "出勤(異常)紀錄查詢";
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
        BindDepart1();
//        UserName_Bind();

        // 相關之 Enable 與 Disable
        //Response.Write("RoleId=" + MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.RoleId) + "<BR>");
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
                //       ddlDepart_01.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id).Substring(0, 3) + "000";
                BindDepart2();
                ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
                if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "" ||
                MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "0")
                {
                    txtUserID.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
                    tr1.Visible = false;
                    tr2.Visible = false;
                    tr3.Visible = false;
                    tr4.Visible = false;
                    tr5.Visible = false;
                    tr6.Visible = false;

                }
            }
            if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "2")
            {
                // 非主管
                 BindDepart2();
                 ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
              
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

            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;    
        }

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
    }

    private void getData()
    {
        // 相關參數
        string orgcode = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode);
        //機構代碼
        string departid = getDepartCode();
        string Apply_name = ddlUserName.SelectedValue;
        string Apply_idcard = txtUserID.Text;
        string Start_date = UcDate1.Text;
        string End_date = UcDate2.Text;
        string Quit_job_flag = ddlQuit_Job.SelectedValue;
        string PESEX = ddlsextype.SelectedValue;
        string Employee_type = ddlEmployeetype.SelectedValue;
        string Leavehours = string.Empty;
        string type = rblReporttype.SelectedValue;
        //Dim type As String = rblReporttype.SelectedValue

        if (string.IsNullOrEmpty(Start_date))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "「起日」欄位為必填。", "", "");
            this.Page = tempPage;
            return;
        }
        if (string.IsNullOrEmpty(End_date))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "「迄日」欄位為必填。","","");
            this.Page = tempPage;
            return;
        }
        if (Convert.ToInt32(Start_date) > Convert.ToInt32(End_date))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "「起日」欄位不可大於「迄日」欄位。","","");
            this.Page = tempPage;
            return;
        }



        if (departid == "ALL") departid = String.Empty;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

      

        DataTable dt = wsmob.WSMOB008(
            MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Orgcode), departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, type);
//        Response.Write(dt.Rows.Count.ToString());

        gvlist.DataSource = dt;
        ViewState["dt"] = dt;
        gvlist.PageIndex = 0;
        gvlist.DataBind();

        pnlResult.Visible = true;
        pnlQuery.Visible = false;
        pnlDetail.Visible = false;

    }
    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlist.PageIndex = e.NewPageIndex;
        gvlist.DataSource = (DataTable)ViewState["dt"];// CType(ViewState("dt"), DataTable)
        gvlist.DataBind();
//        getData();
    }

    protected void gvlist_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
//        Response.Write(gvlist.SelectedIndex.ToString()+ "TEST<BR>");
//        e.NewSelectedIndex;
        GridViewRow gRow = //(GridView)sender;
            gvlist.Rows[e.NewSelectedIndex];
        Label lb_pyvtype    = (Label)gRow.FindControl("lb_pyvtype");
        Label lbDepart_name = (Label)gRow.FindControl("lbDepart_name");
        Label lbPKCARD = (Label)gRow.FindControl("lbPKCARD");
        Label lbPKNAME = (Label)gRow.FindControl("lbPKNAME");
        UControl_UcShowDate UcShowDate = (UControl_UcShowDate)gRow.FindControl("UcShowDate");
        UControl_UcShowTime UcShowTimestart = (UControl_UcShowTime)gRow.FindControl("UcShowTimestart");
        UControl_UcShowTime UcShowTimeend   = (UControl_UcShowTime)gRow.FindControl("UcShowTimeend");
        Label lbPKWORKH = (Label)gRow.FindControl("lbPKWORKH");
        Label lbPKWKTPE = (Label)gRow.FindControl("lbPKWKTPE");
        Label lbLeave_type = (Label)gRow.FindControl("lbLeave_type");
        Label lbleave_hours = (Label)gRow.FindControl("lbleave_hours");
        Label lbabsenthours = (Label)gRow.FindControl("lbabsenthours");
        
        lblSerNo.Text = lb_pyvtype.Text;
        Depart_name.Text = lbDepart_name.Text;
        PKNAME.Text = lbPKNAME.Text;

        PKWDATE.Text = ((Label)UcShowDate.FindControl("lbDate")).Text ;
        PKSTIME.Text = ((Label)UcShowTimestart.FindControl("lbTime")).Text;
        PKETIME.Text = ((Label)UcShowTimeend.FindControl("lbTime")).Text;

        PKWORKH.Text = lbPKWORKH.Text;
        PKWKTPE.Text = lbPKWKTPE.Text;
        Leavetype.Text = lbLeave_type.Text;
        Leavehours.Text = lbleave_hours.Text;
        Absenthours.Text = lbabsenthours.Text;
//        Response.Write(e.NewSelectedIndex.ToString()+"TEST<BR>");

        pnlQuery.Visible = false;
        pnlResult.Visible = false;
        pnlDetail.Visible = true;
    }

    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] =
            this.Page.ClientScript.GetPostBackEventReference((GridView)sender, "Select$" + e.Row.RowIndex);
        }

    }
    protected void gvlist_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlQuery.Visible = false;
        pnlResult.Visible = true;
        pnlDetail.Visible = false;
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