using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PAY_PAY2_PAY2101_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        string url = "PAY2101_02.aspx?1=1";
        Print(url);
    }
    protected void Print2Btn_Click(object sender, EventArgs e)
    {
        string url = "PAY2101_03.aspx?1=1";
        Print(url);
    }

    private void Print(string url)
    {  
        url += "&FiscalYear_id=" + Server.HtmlEncode(ucFiscalYear_id.Year.ToString());
        url += "&PCList_idS=" + Server.HtmlEncode(this.txtPCList_idS.Text);
        url += "&PCList_idE=" + Server.HtmlEncode(txtPCList_idE.Text);
        Response.Redirect(url);
    }

    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        MasterPage p = Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }
}