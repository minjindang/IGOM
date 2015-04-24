using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO2_PRO2101_01 : BaseWebForm
{
    PRO2101 dao = new PRO2101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucFA01_KIND.DDL.Items.Insert(0, ("請選擇"));
            UcDDLAuthorityDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

            string Role_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);
            string Boss_level_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id);
            if (Role_id.IndexOf("Pro_Manager") < 0 || Role_id.IndexOf("Goo_Manager") < 0 || Role_id.IndexOf("Apply_UnitWindow") < 0 ||
                Boss_level_id != "1" || Boss_level_id != "2")
            {
                txtFA01_ACCUSER.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                txtFA01_ACCUSER.Enabled = false;
            }
        }
    } 

    private void Bind()
    {
        if (!string.IsNullOrEmpty(tbCount.Text.Trim()) && !CommonFun.IsNum(tbCount.Text.Trim()))
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "查詢筆數請輸入數字!", "", "");
            return;
        }

        DataTable topDt = new DataTable();
        DataTable dt = dao.Get01All(ucFA01_KIND.Code_no, txtFA01_MASTNO.Text, txtFA01_CLSNO.Text, (string.IsNullOrEmpty(UcDDLAuthorityDepart.SelectedValue) ? "" : UcDDLAuthorityDepart.SelectedItem.Text), txtFA01_ACCUSER.Text, 
            ucFA01_BUYDTS.Text, ucFA01_BUYDTE.Text, txtFA01_AMT.Text, rblFA01_SUBDUE.SelectedValue, rblFA01_BUYDT.SelectedValue);
        div1.Visible = dt != null && dt.Rows.Count > 0;

        if (!string.IsNullOrEmpty(tbCount.Text.Trim()))
        {
            topDt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < CommonFun.getInt(tbCount.Text.Trim()))
                {
                    topDt.ImportRow(dt.Rows[i]);
                }
            }

            this.GridViewA.DataSource = topDt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = topDt; //將資料暫存起來，做為資料的跳頁等顯示
        }
        else
        {
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
            //dt.Dispose();
        }
    } 

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    } 
    protected void QryBtn_Click(object sender, EventArgs e)
    {

        if (!CommonFun.IsNum(txtFA01_AMT.Text))
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "金額請輸入數字", "", "");
            this.Page = p;
            return;
        }

        Bind();
    }
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
    }
    protected void ExportBtn_Click(object sender, EventArgs e)
    {
        DataTable dt = dao.Get01All(ucFA01_KIND.Code_no, txtFA01_MASTNO.Text, txtFA01_CLSNO.Text, (string.IsNullOrEmpty(UcDDLAuthorityDepart.SelectedValue) ? "" : UcDDLAuthorityDepart.SelectedItem.Text), txtFA01_ACCUSER.Text,
            ucFA01_BUYDTS.Text, ucFA01_BUYDTE.Text, txtFA01_AMT.Text, rblFA01_SUBDUE.SelectedValue, rblFA01_BUYDT.SelectedValue);

        dt.Columns.Add("P4", typeof(System.String));


        string[] strParam = new string[4];
        int maxpageRowcnt = 25;
        string maxpagecnt = "";

        //取得總頁數
        if ((dt.Rows.Count % maxpageRowcnt) != 0)
        {
            maxpagecnt = (dt.Rows.Count / maxpageRowcnt + 1).ToString();
        }
        else
        {
            maxpagecnt = (dt.Rows.Count / maxpageRowcnt).ToString();
        }

        //取得分頁數P4
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            dt.Rows[i]["P4"] = (i / maxpageRowcnt) + 1;
        }

        dt.AcceptChanges();

        strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
        strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
        strParam[2] = "";
        strParam[3] = maxpagecnt;

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PRO/PRO2101_01.mht"), dt);
        theDTReport.breakPage = "P4";
        theDTReport.Param = strParam;
        theDTReport.ExportFileName = "保管財產清冊";
        theDTReport.ExportToExcel();
        dt.Dispose();
    }
    protected void GridViewA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String FA01_MASTNO = ((HiddenField)e.Row.FindControl("lbFA01_MASTNO")).Value;
            String FA01_CLSNO = ((HiddenField)e.Row.FindControl("lbFA01_CLSNO")).Value;

            DataTable dt = dao.Get02All(FA01_MASTNO, FA01_CLSNO);

            if (dt == null || dt.Rows.Count <= 0)
            {
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "";
            }
                        
        }
    }
}