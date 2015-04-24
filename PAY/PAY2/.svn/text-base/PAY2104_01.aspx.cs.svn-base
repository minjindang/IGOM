using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2104_01 : BaseWebForm
{
    private PAY2104 dao = new PAY2104();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindGV();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string url = "PAY2104_02.aspx?1=1";
        url += "&PettyCash_nosS=" + Server.HtmlEncode(txtPettyCash_nosS.Text);
        url += "&PettyCash_nosE=" + Server.HtmlEncode(txtPettyCash_nosE.Text);
        url += "&Borrow_dateS=" + Server.HtmlEncode(ucBorrow_dateS.Text);
        url += "&Borrow_dateE=" + Server.HtmlEncode(ucBorrow_dateE.Text);
        url += "&Income_dateS=" + Server.HtmlEncode(ucIncome_dateS.Text);
        url += "&Income_dateE=" + Server.HtmlEncode(ucIncome_dateE.Text);
        Response.Redirect(url);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        MasterPage p = this.Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }

    private void BindGV()
    {
        string msg = string.Empty;
        DataTable dt = dao.GetReportData(txtPettyCash_nosS.Text, txtPettyCash_nosE.Text, ucBorrow_dateS.Text, ucBorrow_dateE.Text, ucIncome_dateS.Text, ucIncome_dateE.Text);
        if (string.IsNullOrEmpty(msg))
        {
            div1.Visible = true;
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose();
        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }
    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    }
}