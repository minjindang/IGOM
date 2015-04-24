using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PAY_PAY2_PAY2103_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        string url = "PAY2103_02.aspx?1=1";
        url += "&Bank_id=" + Server.HtmlEncode(this.ucBank.Bank_ID);
        url += "&Beneficiary_name=" + Server.HtmlEncode(this.txtBeneficiary_name.Text);
        Response.Redirect(url);
        //Response.Write("<script>window.open('" + url + "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;");
    }

    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        MasterPage p = this.Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }
}