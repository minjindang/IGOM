using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FSC_FSC0_FSC0101_24 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
            FSC.Logic.Personnel personnel = new FSC.Logic.Personnel();
            if (personnel.GetColumnValue("Role_id", LoginManager.UserId).Contains("Apply_UnitWindow"))
            {
                this.btnMergePrint.Visible = true;
                Page p = this.Page;
                //CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "秘書室審核人員才可發放清冊。", "", "");
            }
        }
    }

    private void Bind()
    {
        string flowId = Request.QueryString["fId"].ToString();
        string orgcode = Request.QueryString["org"].ToString();

        FSC.Logic.SettlementAnnual bll = new FSC.Logic.SettlementAnnual();
        DataTable dt = bll.getDataByOrgFid(orgcode, flowId);
        if (dt != null && dt.Rows.Count > 0)
        {
            DataList1.DataSource = dt;
            DataList1.DataBind();
            //lblUser_name.Text = dt.Rows[0]["User_name"].ToString();
            //lblApply_yy.Text = dt.Rows[0]["Annual_year"].ToString();
            //lblUser_name.Text = dt.Rows[0]["User_name"].ToString();
            //lblApply_yy.Text = dt.Rows[0]["Annual_year"].ToString();
            //lblPEHDAY.Text = dt.Rows[0]["Annual_days"].ToString();
            //lblLeaveType1.Text = dt.Rows[0]["Vacation_days"].ToString();
            //lblLeaveType2.Text = dt.Rows[0]["Vacation_internal"].ToString();
            //lblLeaveType3.Text = dt.Rows[0]["Vacation_card"].ToString();
            //lblLeaveType4.Text = dt.Rows[0]["Abroad_days"].ToString();
            //lblPEHYEAR2.Text = dt.Rows[0]["Usable_days"].ToString();
            //lblDays.Text = dt.Rows[0]["Pay_days"].ToString().Split('.')[0];
            //if (dt.Rows[0]["Pay_days"].ToString().IndexOf(".") >= 0)
            //    lblHours.Text = dt.Rows[0]["Pay_days"].ToString().Split('.')[1];
            //else
            //    lblHours.Text = "0";
            //txtApply_amount.Text = dt.Rows[0]["Apply_fee"].ToString();
        }
        UcFlowDetail.Orgcode = orgcode;
        UcFlowDetail.FlowId = flowId;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void btnMergePrint_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/SAL/SAL2/SAL2210_01.aspx?flow_id={0}", Request.QueryString["fId"].ToString()));
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
       {
            HiddenField hfPay_days = (HiddenField)e.Item.FindControl("hfPay_days");
            Label lblDays = (Label)e.Item.FindControl("lblDays");
            Label lblHours = (Label)e.Item.FindControl("lblHours");
            lblDays.Text = hfPay_days.Value.Split('.')[0];
            if (hfPay_days.Value.IndexOf(".") >= 0)
                lblHours.Text = hfPay_days.Value.Split('.')[1];
            else
                lblHours.Text = "0";
        }
    }
}