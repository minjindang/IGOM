using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSC.Logic;
using System.Data;

public partial class Mobile_MOB2_MOB2204_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button btnBack = (Button)Master.FindControl("btnPrivous");
        btnBack.Click += new EventHandler(Back2LastPage);
        btnBack.Visible = true;
        if (Page.IsPostBack) return;
        Label lblPageTitle = (Label)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "公差紀錄查詢";
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
             
        // 單位別
        BindDepart1();
      
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
          //      ddlDepart_01.SelectedValue = (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id)).Substring(0, 3) + "000";
                BindDepart2();
                ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
                UserName_Bind();
                if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "" ||
                MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "0")
                {
                    txtUserID.Text = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card);
                    tr1.Visible = false;
                    tr2.Visible = false;
                    tr3.Visible = false;
                    tr4.Visible = false;
                    tr5.Visible = false;
                 
                }
            }
            if (MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Boss_Level_id) == "2")
            {
                // 非主管
             //   ddlDepart_01.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id).Substring(0, 3) + "000";
                BindDepart2();
                ddlDepart_02.SelectedValue = MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Depart_id);
                UserName_Bind();
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

            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;


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

    protected void btnQuery_Click(object sender, EventArgs e)
    {

        getData();
        pnlResult.Visible = true;
        pnlQuery.Visible = false;

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
//        string Leave_type = ddlStatus.SelectedValue;
        string status = string.Empty;
        string Case_status = status;
        string PESEX = ddlsextype.SelectedValue;
        string Quit_job_flag = ddQuit_Job.SelectedValue;
        string LocationFlag = ddlLocationFlag.SelectedValue;
        //cblStatus.SelectedValue

        foreach (ListItem cbx in cblStatus.Items)
        {
            if (cbx.Selected)
            {
                status += cbx.Value + ",";
            }
        }

        if (departid == "ALL") departid = String.Empty;

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];

        DataTable dt = new DataTable();

        bool isSelected = false;
        foreach (ListItem i in cblStatus.Items)
        {
            if (i.Selected)
            {
                isSelected = true;
                //DataRow r = new FSCPLM.Logic.SACode().GetRow("023", "002", i.Value);

                //string caseStatus = r["code_remark1"].ToString();
                //string lastPass = r["code_remark2"].ToString();

                string caseStatus = wsmob.WSMOB064(i.Value); //r["code_remark1"].ToString();
                string lastPass = wsmob.WSMOB065(i.Value); //r["code_remark2"].ToString();

                DataTable tmp = wsmob.WSMOB014(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, "", caseStatus ,lastPass,PESEX,Quit_job_flag);
//                    (orgcode, departid, Apply_name, Apply_idcard, Quit_job_flag, PESEX, Start_date, End_date, LocationFlag, caseStatus,
//                lastPass);

                if (tmp != null && tmp.Rows.Count > 0)
                {
                    dt.Merge(tmp);
                }
            }
        }

        if (!isSelected)
        {
            dt = wsmob.WSMOB014(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, "", "", "", PESEX, Quit_job_flag);
        }


        //DataTable dt = wsmob.WSMOB014(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Leave_type, status);

        gvlist.DataSource = dt;
        gvlist.DataBind();   
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

    protected void gvlist_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void gvlist_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow gRow = //(GridView)sender;
            gvlist.Rows[e.NewSelectedIndex];
        Label lb_pyvtype = (Label)gRow.FindControl("lb_pyvtype");
        Label lbdepart_id = (Label)gRow.FindControl("lbdepart_id");
        Label lbApply_idcard = (Label)gRow.FindControl("lbApply_idcard");
        Label lbApply_name = (Label)gRow.FindControl("lbApply_name");
        UControl_UcShowDate UcShowDate1 = (UControl_UcShowDate)gRow.FindControl("UcShowDate1");
        Label Label2 = (Label)gRow.FindControl("Label2");
        Label lbLeave_name = (Label)gRow.FindControl("lbLeave_name");
        Label lbPlace = (Label)gRow.FindControl("lbPlace");

        UControl_UcShowDate UcShowDate2 = (UControl_UcShowDate)gRow.FindControl("UcShowDate2");
        UControl_UcShowTime UcShowTime1 = (UControl_UcShowTime)gRow.FindControl("UcShowTime1");
        UControl_UcShowDate UcShowDate3 = (UControl_UcShowDate)gRow.FindControl("UcShowDate3");
        UControl_UcShowTime UcShowTime2 = (UControl_UcShowTime)gRow.FindControl("UcShowTime2");
        Label lbDeputy_idcard = (Label)gRow.FindControl("lbDeputy_idcard");
        Label lbDegree_code = (Label)gRow.FindControl("lbDegree_code");
        Label lbLevel = (Label)gRow.FindControl("lbLevel");
        Label lbReason = (Label)gRow.FindControl("lbReason");
        Label lbLast_name = (Label)gRow.FindControl("lbLast_name");
        Label lbReason2 = (Label)gRow.FindControl("lbReason2");
        Label lbFlightReason = (Label)gRow.FindControl("lbFlightReason");
        Label lbRecord = (Label)gRow.FindControl("lbRecord");
        Label Label1 = (Label)gRow.FindControl("Label1");

        lblSerNo.Text = lb_pyvtype.Text;
        Case_status.Text = lbdepart_id.Text;
        Id_card.Text = lbApply_idcard.Text;
        User_name.Text = lbApply_name.Text;
        Start_date.Text = ((Label)UcShowDate1.FindControl("lbDate")).Text;
        Leave_name.Text = lbLeave_name.Text;
        Leave_hours.Text = Label2.Text;
        Place.Text = lbPlace.Text;
        Start_date2.Text = ((Label)UcShowDate2.FindControl("lbDate")).Text;
        Start_time.Text = ((Label)UcShowTime1.FindControl("lbTime")).Text;
        End_date.Text = ((Label)UcShowDate3.FindControl("lbDate")).Text;
        End_time.Text = ((Label)UcShowTime2.FindControl("lbTime")).Text;
        Degree_code.Text = lbDegree_code.Text;
        Level.Text = lbLevel.Text;
        Reason.Text = lbReason.Text;
        Deputy.Text = lbDeputy_idcard.Text;
        Last_name.Text = lbLast_name.Text;
        Reason2.Text = lbReason2.Text;
        Leave_name2.Text = lbFlightReason.Text;
        Leave_name3.Text = Leave_name.Text;
        Leave_name4.Text = Leave_name.Text;

        pnlQuery.Visible = false;
        pnlResult.Visible = false;
        pnlDetail.Visible = true;
        /*
        PKWDATE.Text = ((Label)UcShowDate.FindControl("lbDate")).Text;
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
         * */

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