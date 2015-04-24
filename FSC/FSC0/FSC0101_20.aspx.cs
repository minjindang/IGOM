using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FSC_FSC0_FSC0101_20 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        string flowId = Request.QueryString["fId"].ToString();
        string orgcode = Request.QueryString["org"].ToString();
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();
        this.GridViewA.DataSource = bll.GetDUTYFeeData(orgcode, flowId);
        this.GridViewA.DataBind();
        UcFlowDetail.Orgcode = orgcode;
        UcFlowDetail.FlowId = flowId;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridViewA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow )
        //{
        //    e.Row.Cells[5].Text = e.Row.Cells[5].Text == "Y" ? "是" : "否";
        //}
    }
}