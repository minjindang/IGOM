using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO3_PRO3101_01 : BaseWebForm
{
    private PRO3101 dao = new PRO3101();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucUnit_code.Orgcode = LoginManager.OrgCode;
        }
    }
    protected void btnQry_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void btnClr_Click(object sender, EventArgs e)
    {
        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    { 
        string fee_amtS = string.Empty;
        string fee_amtE = string.Empty;
        string fee_amtL = string.Empty;
        string fee_amtM = string.Empty; 
        if (rbRange.Checked)
        {
            fee_amtS = txtFee_amtS.Text;
            fee_amtE = txtFee_amtE.Text;
        }
        else if (rbLess.Checked)
        {
            fee_amtL = txtFee_amtL.Text;
        }
        else if (rbMore.Checked)
        {
            fee_amtM = txtFee_amtL.Text;
        }
        string url = "PRO3101_03.aspx?1=1";
        url += "&OfficialNumber_id=" + Server.HtmlEncode(txtOfficialNumber_id.Text);
        url += "&Software_id=" + Server.HtmlEncode(txtSoftware_id.Text);
        url += "&last_dateS=" + Server.HtmlEncode(ucLast_dateS.Text);
        url += "&last_dateE=" + Server.HtmlEncode(ucLast_dateE.Text);
        url += "&SoftwareUnit_name=" + Server.HtmlEncode(txtSoftwareUnit_name.Text);
        url += "&Unit_code=" + Server.HtmlEncode(ucUnit_code.SelectedValue);
        url += "&User_id=" + Server.HtmlEncode(ucUser_id.SelectedValue);
        url += "&Software_name=" + Server.HtmlEncode(txtSoftware_name.Text);
        url += "&fee_amtS=" + Server.HtmlEncode(fee_amtS);
        url += "&fee_amtE=" + Server.HtmlEncode(fee_amtE);
        url += "&fee_amtL=" + Server.HtmlEncode(fee_amtL);
        url += "&fee_amtM=" + Server.HtmlEncode(fee_amtM);
        url += "&Order=" + Server.HtmlEncode(rblOrder.SelectedValue);

        Response.Write("<script>window.open('" + url + "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;");
    }
    private void Bind()
    {
        string msg = string.Empty;
        DateTime last_dateS = DateTime.MinValue;
        DateTime last_dateE = DateTime.MinValue;
        string fee_amtS = string.Empty;
        string fee_amtE = string.Empty;
        string fee_amtL = string.Empty;
        string fee_amtM = string.Empty;

        if (!CommonFun.IsNum(txtFee_amtS.Text) || !CommonFun.IsNum(txtFee_amtE.Text) || !CommonFun.IsNum(txtFee_amtL.Text) || !CommonFun.IsNum(txtFee_amtM.Text))
	    {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "「費用」請輸入數字。", "", "");
            return;
	    }
            
        if (!string.IsNullOrEmpty(ucLast_dateS.Text))
	    {
		    last_dateS = CommonFun.getYYYMMDD(ucLast_dateS.Text);
	    }
        if (!string.IsNullOrEmpty(ucLast_dateE.Text))
	    {
		    last_dateE = CommonFun.getYYYMMDD(ucLast_dateE.Text);
	    }
        if (rbRange.Checked)
        {
            fee_amtS = txtFee_amtS.Text;
            fee_amtE = txtFee_amtE.Text;
        }
        else if (rbLess.Checked)
        {
            fee_amtL = txtFee_amtL.Text;
        }
        else if (rbMore.Checked)
        {
            fee_amtM = txtFee_amtL.Text;
        }
        DataTable dt = dao.GetAll(txtOfficialNumber_id.Text, txtSoftware_id.Text, last_dateS, last_dateE,
            txtSoftwareUnit_name.Text, ucUnit_code.SelectedValue, ucUser_id.SelectedValue, txtSoftware_name.Text,
            fee_amtS, fee_amtE, fee_amtL, fee_amtM, rblOrder.SelectedValue);
        div1.Visible = true;
            //= dt != null && dt.Rows.Count > 0;

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
        ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose();
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    }
    protected void GridViewA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Maintain")
        {
            Page.Response.Redirect(String.Format("~/PRO/PRO3/PRO3101_02.aspx?FlowId={0}", e.CommandArgument));
        }
        else if (e.CommandName == "GoDelete")
        {
            dao.psrmDAO.Remove(e.CommandArgument.ToString(), LoginManager.OrgCode);
            Bind();
        }
    }
    protected void ucUnit_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucUser_id.Orgcode = LoginManager.OrgCode;
        ucUser_id.DepartId = ucUnit_code.SelectedValue;
    }
}