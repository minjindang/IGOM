using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PAY_PAY2_PAY2201_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        if (ucReceipt_dateS.Text == "" || ucReceipt_dateE.Text == "")
        {
            string msg = string.Empty;
            msg = "請輸入收費起迄日期!!";
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
        else
        {
            string url = "PAY2201_02.aspx?1=1";
            url += "&Receipt_dateS=" + Server.HtmlEncode(ucReceipt_dateS.Text);
            url += "&Receipt_dateE=" + Server.HtmlEncode(ucReceipt_dateE.Text);
            url += "&PayMode_type=" + Server.HtmlEncode(ucPayMode_type.Code_no);
            url += "&Order=" + Server.HtmlEncode(ddlOrder.SelectedValue);
            Response.Redirect(url);
        }
    }
    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        MasterPage p = this.Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }
}