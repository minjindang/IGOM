using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FSC_FSC0_FSC0101_21 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
            //this.btnMergePrint.Visible = SYS.Logic.Flow.HasMergeFlowId(Request.QueryString["fId"].ToString());
            FSC.Logic.Personnel personnel = new FSC.Logic.Personnel();
            if (!personnel.GetColumnValue("Role_id", LoginManager.UserId).Contains("Edu_sec"))
            {
                this.btnMergePrint.Visible = false;
                Page p = this.Page;
                //CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "秘書室審核人員才可發放清冊。", "", "");
            }
        }
    }

    private void Bind()
    {
        string flowId = Request.QueryString["fId"].ToString();
        string orgcode = Request.QueryString["org"].ToString();
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();
        this.GridViewA.DataSource = bll.GetEDUFeeData(orgcode, flowId);
        this.GridViewA.DataBind();
        UcFlowDetail.Orgcode = orgcode;
        UcFlowDetail.FlowId = flowId;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void btnMergePrint_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/SAL/SAL2/SAL2204_01.aspx?flow_id={0}", Request.QueryString["fId"].ToString()));
    }
}