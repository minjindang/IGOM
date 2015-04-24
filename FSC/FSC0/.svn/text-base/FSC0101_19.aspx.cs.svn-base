using CommonLib;
using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FSC_FSC0_FSC0101_19 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
            this.btnMergePrint.Visible = SYS.Logic.Flow.HasMergeFlowId(Request.QueryString["fId"].ToString());
        }
    }

    private void Bind()
    {
        string flowId = Request.QueryString["fId"].ToString();
        string orgcode = Request.QueryString["org"].ToString();
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();
        this.GridViewA.DataSource = bll.GetTrafficFeeData(orgcode,flowId);
        this.GridViewA.DataBind();
        UcFlowDetail.Orgcode = orgcode;
        UcFlowDetail.FlowId = flowId;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    { 
        if(ViewState["BackUrl"]!=null)
         Response.Redirect(ViewState["BackUrl"].ToString());
    }

    protected void btnMergePrint_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/SAL/SAL2/SAL2208_01.aspx?flow_id={0}", Request.QueryString["fId"].ToString()));
    }
}