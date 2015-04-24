using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAR.Logic;

public partial class CAR_CAR2_CAR2102_01 : BaseWebForm
{

    Car2102 dao = new Car2102();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sdate = Request["sdate"] != null ? Request["sdate"] : "";
            string edate = Request["edate"] != null ? Request["edate"] : "";
            ucStart_date.Text = sdate;
            ucEnd_date.Text = edate;

            rblTYpe.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(ucStart_date.Text) && !string.IsNullOrEmpty(ucEnd_date.Text))
            {
                Bind();
            }
        }
    }
    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        if (string.IsNullOrEmpty(ucStart_date.Text))
        {
            msg += "請輸入派車日期(起)\\n";
        }
        if (string.IsNullOrEmpty(ucEnd_date.Text))
        {
            msg += "請輸入派車日期(起)\\n";
        }
        if (string.IsNullOrEmpty(msg))
        {
            Bind();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
        
    }
    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        string url = "CAR2102_02.aspx?1=1";

        url += "&Start_date=" + Server.HtmlEncode(this.ucStart_date.Text);
        url += "&End_date=" + Server.HtmlEncode(this.ucEnd_date.Text);
        url += "&pageCount=" + Server.HtmlEncode(this.Ucpager1.sPageSize.ToString());
        url += "&type=" + Server.HtmlEncode(rblTYpe.SelectedValue);
       
        Response.Redirect(url);
    }

    private void Bind()
    {
        DataTable dt = dao.GetReportData(rblTYpe.SelectedValue, ucStart_date.Text, ucEnd_date.Text);
        div1.Visible = dt != null && dt.Rows.Count > 0;
        if (rblTYpe.SelectedValue == "0")
        {
            this.GridViewA.Columns[0].HeaderText = "車輛名稱";
        }
        else
        {
            this.GridViewA.Columns[0].HeaderText = "部門";
        }
        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
        ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose();
    }
    protected void GridViewA_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    }
   
}