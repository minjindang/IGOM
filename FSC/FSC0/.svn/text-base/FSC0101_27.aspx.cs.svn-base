using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FSC_FSC0_FSC0101_27 : BaseWebForm
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
        this.GridViewA.DataSource = bll.GetAllowanceFeeData(orgcode, flowId);
        this.GridViewA.DataBind();
        UcFlowDetail.Orgcode = orgcode;
        UcFlowDetail.FlowId = flowId;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }

}