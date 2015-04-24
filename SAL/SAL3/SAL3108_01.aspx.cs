using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SALPLM.Logic;
using System.Data;
using System.Data.SqlClient;


public partial class SAL_SAL3_SAL3108_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    private string strLogIDCard;    // 登入者原邊

    protected void Page_Load(object sender, EventArgs e)
    {
        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        strLogIDCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        if (Page.IsPostBack) return;
        pnlQuery.Visible = false;
        //        cmbEmployeeType.Orgid = strOrgCode;
        //        cmbEmployeeType.Rebind();
        //        Response.Write(strOrgCode);
    }

    protected void Button_Search_Click(object sender, EventArgs e)
    {
        this.getData();
//        pnlInput.Visible = false;
    }

    private void getData()
    {
        // 參數
        string v_UserOrgId = this.strOrgCode;    // 單位
        string v_bouns_year = Convert.ToString(Convert.ToInt32(cmbYear.Year.ToString()) + 1911); //cmbYear.Year.ToString();
        string v_base_job = cmbEmployeeType.SelectedValue;      // 職務類別 
        string v_base_status = ddl_status.SelectedValue;   // 在職狀態 
        string v_Search_IDCard = txtIDCard.Text; // 員工編號
        string v_Search_Name = txtEmpName.Text;   // 姓名
        string strDepart = cmbDepartID.OrgCode;       // 單位 

        SAL3108 sal3108 = new SAL3108();
        DataTable dt = sal3108.queryUser(v_UserOrgId, v_bouns_year, v_base_job, v_base_status, v_Search_IDCard, v_Search_Name, strDepart);

        gvResult.DataSource = dt;
        gvResult.DataBind();

        if (gvResult.Rows.Count > 0)
        {
            button.Visible = true;
            Ucpager1.Visible = true;
        }
        else
        {
            button.Visible = false;
            Ucpager1.Visible = false;
        }

        pnlQuery.Visible = true;
        pQueryUSer.Visible = false;

    }

    protected void Button_sabase_Click(object sender, EventArgs e)
    {
        // 參數
        string v_UserOrgId = this.strOrgCode;    // 單位
        string v_bouns_year = Convert.ToString(Convert.ToInt32(cmbYear.Year.ToString()) + 1911);//cmbYear.Year.ToString();
        SAL3108 sal3108 = new SAL3108();

        // chaeck data
        if (sal3108.CheakSalSaseBouns4Insert(v_UserOrgId, v_bouns_year))
        {
            sal3108.insertBouns(v_UserOrgId, v_bouns_year, strLogIDCard);
            getData();
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已經有已帶入的專業加給不可重覆帶入", "", "");
            this.Page = tempPage;
        }

    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            uc_ucSaCode gvddlBossAdd = (uc_ucSaCode)e.Row.FindControl("cmbBossAdd");
            gvddlBossAdd.Rebind();
            Label KDP = (Label)e.Row.FindControl("kdp");
            try
            {
                gvddlBossAdd.SelectedValue = KDP.Text.Trim();
            }
            catch
            {
            }

            uc_ucSaSpesup UcSaSpesup1 = ((uc_ucSaSpesup)e.Row.FindControl("UcSaSpesup1"));
            Label series = (Label)e.Row.FindControl("series");
            UcSaSpesup1.v_Series = series.Text.Trim();

        }
    }

    protected void CheckBox_Seqno_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox_All_CheckedChanged(object sender, EventArgs e)
    {
        bool rv = ((CheckBox)sender).Checked;

        foreach (GridViewRow gvr in this.gvResult.Rows)
        {
            ((CheckBox)gvr.FindControl("CheckBox_Seqno")).Checked = rv;
        }

        //uPnlQuery.Update();
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow info_gvr in this.gvResult.Rows)
        {
            SAL3108 emp3108 = new SAL3108();
            bool CheckBox_Seqno = ((CheckBox)info_gvr.FindControl("CheckBox_Seqno")).Checked;
            //            if (CheckBox_Seqno)
            //            {
            //Label BASE_ORGID = (Label)info_gvr.FindControl("orgid");
            Label BASE_SEQNO = (Label)info_gvr.FindControl("seqno");
            Label BOUNS_YEAR = (Label)info_gvr.FindControl("year");
            Label B_ID = (Label)info_gvr.FindControl("id");
            string BOUNS_KDP = ((uc_ucSaCode)info_gvr.FindControl("cmbBossAdd")).Code_no;
            string BOUNS_KDP_SERIES = ((uc_ucSaSpesup)info_gvr.FindControl("UcSaSpesup1")).v_Series;
            string BOUNS_KDP_MON = ((DropDownList)info_gvr.FindControl("ddl_month")).SelectedValue;
            string BOUNS_KDP_AMT = ((TextBox)info_gvr.FindControl("txt_KDP_AMT")).Text;

            string vv_id = B_ID.Text.Trim();
            string vv_year = BOUNS_YEAR.Text.Trim();
            string vv_kdp = BOUNS_KDP.Trim();
            string vv_kdp_series = BOUNS_KDP_SERIES.Trim();
            string vv_kdp_mon = BOUNS_KDP_MON.Trim();
            string vv_muser = this.strLogIDCard;


            emp3108.updateSalSaseBouns(vv_id, vv_year, vv_kdp, vv_kdp_series, vv_kdp_mon, vv_muser, BOUNS_KDP_AMT.Trim());
            //            }

        }

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "資料修改完成", "", "");
        this.Page = tempPage;
    }


    public void UcSaCode1_CodeChanged(object sender, System.EventArgs e)
    {
        //        Response.Write("UcSaCode1_CodeChanged<BR>");
        try
        {
            uc_ucSaCode UcSaCode1 = (uc_ucSaCode)sender;
            GridViewRow gvr = (GridViewRow)UcSaCode1.NamingContainer;
            uc_ucSaSpesup UcSaSpesup1 = (uc_ucSaSpesup)gvr.FindControl("UcSaSpesup1");
            UcSaSpesup1.v_No = UcSaCode1.Code_no;
        }
        catch
        {
        }
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow info_gvr in this.gvResult.Rows)
        {
            SAL3108 emp3108 = new SAL3108();
            bool CheckBox_Seqno = ((CheckBox)info_gvr.FindControl("CheckBox_Seqno")).Checked;
            if (CheckBox_Seqno)
            {
                Label BOUNS_YEAR = (Label)info_gvr.FindControl("year");
                Label B_ID = (Label)info_gvr.FindControl("id");

                string vv_id = B_ID.Text.Trim();
                string vv_year = BOUNS_YEAR.Text.Trim();


                emp3108.deleteSalSaseBouns(vv_id, vv_year);
            }
        }
        this.getData();

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "資料已刪除", "", "");
        this.Page = tempPage;

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cmbEmployeeType.Rebind();
        cmbDepartID.Rebind();
        txtIDCard.Text = "";
        txtEmpName.Text = "";
        ddl_status.SelectedIndex = 1;
        pnlQuery.Visible = false;
        pQueryUSer.Visible = false;

    }


    protected void doDelete(object sender, EventArgs e)
    {
        SAL3108 emp3108 = new SAL3108();
        Button btnDel = (Button)sender;
        DataControlFieldCell cell = (DataControlFieldCell)btnDel.Parent;
        GridViewRow row = (GridViewRow)cell.Parent;
        Label BOUNS_YEAR = (Label)row.FindControl("year");
        Label B_ID = (Label)row.FindControl("id");

        string vv_id = B_ID.Text.Trim();
        string vv_year = BOUNS_YEAR.Text.Trim();


        emp3108.deleteSalSaseBouns(vv_id, vv_year);

        this.getData();

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "資料已刪除", "", "");
        this.Page = tempPage;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SAL3108 emp3108 = new SAL3108();
        Button btnModify = (Button)sender;
        DataControlFieldCell cell = (DataControlFieldCell)btnModify.Parent;
        GridViewRow info_gvr = (GridViewRow)cell.Parent;

        Label BASE_SEQNO = (Label)info_gvr.FindControl("seqno");
        Label BOUNS_YEAR = (Label)info_gvr.FindControl("year");
        Label B_ID = (Label)info_gvr.FindControl("id");
        string BOUNS_KDP = ((uc_ucSaCode)info_gvr.FindControl("cmbBossAdd")).Code_no;
        string BOUNS_KDP_SERIES = ((uc_ucSaSpesup)info_gvr.FindControl("UcSaSpesup1")).v_Series;
        string BOUNS_KDP_MON = ((DropDownList)info_gvr.FindControl("ddl_month")).SelectedValue;
        string BOUNS_KDP_AMT = ((TextBox)info_gvr.FindControl("txt_KDP_AMT")).Text;

        string vv_id = B_ID.Text.Trim();
        string vv_year = BOUNS_YEAR.Text.Trim();
        string vv_kdp = BOUNS_KDP.Trim();
        string vv_kdp_series = BOUNS_KDP_SERIES.Trim();
        string vv_kdp_mon = BOUNS_KDP_MON.Trim();
        string vv_muser = this.strLogIDCard;


        emp3108.updateSalSaseBouns(vv_id, vv_year, vv_kdp, vv_kdp_series, vv_kdp_mon, vv_muser, BOUNS_KDP_AMT.Trim());

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "資料修改完成", "", "");
        this.Page = tempPage;

    }

    protected void Button_ShowSearch_Click(object sender, EventArgs e)
    {
        string act = this.Button_ShowSearch.CommandArgument.ToString();

        switch (act)
        {
            case "Y":
                //                this.div_search.Style .Item("display") = "block";
                div_search.Visible = true;
                this.Button_ShowSearch.CommandArgument = "N";
                this.Button_ShowSearch.Text = "關閉人員搜尋器";
                break;
            case "N":
                //                this.div_search.Style.Item("display") = "none";
                div_search.Visible = false;
                this.Button_ShowSearch.CommandArgument = "Y";
                this.Button_ShowSearch.Text = "開啟人員搜尋器";
                break;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        getData2();
    }

    private void getData2()
    {
        // 參數
        string v_UserOrgId = this.strOrgCode;    // 單位 
        string v_Search_Str = TextBox_Search_str.Text.Trim();// 依姓名或是身分證號  
        string v_Job = UcSaCode1.SelectedValue;
        string v_Proj = UcSaCode2.SelectedValue;
        string v_Dept = UcDDLDepart1.SelectedValue;
        string v_base_edate = DropDownList_edate.SelectedValue;

        SAL3107 sal3107 = new SAL3107();
        DataTable dt = sal3107.queryBase(v_UserOrgId, v_Search_Str, v_Job, v_Proj, v_Dept, v_base_edate, "");

        GridView_Base.DataSource = dt;
        GridView_Base.DataBind();

        if (GridView_Base.Rows.Count > 0)
        {
            Ucpager2.Visible = true;
            Button_Commit.Visible = true;
        }
        else
        {
            Ucpager2.Visible = false;
            Button_Commit.Visible = false;        
        }

    }

    protected void btn_New_Click(object sender, EventArgs e)
    {
        pQueryUSer.Visible = true;
        pnlQuery.Visible = false;
        pnlInput.Visible = false;
        TextBox_Search_str.Text = "";// 依姓名或是身分證號  
        UcSaCode1.Rebind();
        UcSaCode2.Rebind();
        UcDDLDepart1.Orgcode = this.strOrgCode;
        DropDownList_edate.SelectedIndex = 0;
        this.getData2();
    }
    protected void Button_Rest_Click(object sender, EventArgs e)
    {
        TextBox_Search_str.Text = "";// 依姓名或是身分證號  
        UcSaCode1.Rebind();
        UcSaCode2.Rebind();
        UcDDLDepart1.Orgcode = this.strOrgCode;
        DropDownList_edate.SelectedIndex = 0;
        this.getData2();
    }

    protected void ALLChecked(object sender, EventArgs e)
    {
        bool chk = ((CheckBox)this.GridView_Base.HeaderRow.FindControl("CheckBox_ALL")).Checked;

        foreach (GridViewRow gvr in GridView_Base.Rows)
        {
            ((CheckBox)gvr.FindControl("CheckBox_Seqno")).Checked = chk;
        }

    }

    protected void Button_Commit_Click(object sender, EventArgs e)
    {
        string v_UserOrgId = this.strOrgCode;    // 單位
        string v_bouns_year = Convert.ToString(Convert.ToInt32(cmbYear.Year.ToString()) + 1911);//cmbYear.Year.ToString();

        foreach (GridViewRow gvr in GridView_Base.Rows)
        {
            bool v_chk = ((CheckBox)gvr.FindControl("CheckBox_Seqno")).Checked;
            string v_seqno = ((TextBox)gvr.FindControl("TextBox_Seqno")).Text;
            //Response.Write(v_seqno + "/" + v_chk.ToString() + "<BR>");
            if (v_chk)
            {
                SAL3108 sal3108 = new SAL3108();
                if (sal3108.CheakSalSaseBouns4Insert(v_UserOrgId, v_bouns_year, v_seqno))
                {
                    //Response.Write("DO insert : " + v_seqno);
                    sal3108.insertBounswithBaseSeqNO(v_UserOrgId, v_bouns_year, strLogIDCard, v_seqno);
                }

            }
        }
        pQueryUSer.Visible = false;
        pnlInput.Visible = true;
        this.getData();

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlInput.Visible = true;
        pnlQuery.Visible = false;
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        this.getData();
    }
    protected void GridView_Base_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_Base.PageIndex = e.NewPageIndex;
        this.getData2();
    }
}