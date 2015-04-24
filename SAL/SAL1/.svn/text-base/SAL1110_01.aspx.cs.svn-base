using FSCPLM.Logic;
using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1110_01 : BaseWebForm
{

    SAL1110 dao = new SAL1110();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string msg = dao.canUse();
            if (!string.IsNullOrEmpty(msg))
            {
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
                this.btn_submit.Enabled = false;
            }
            else 
            {
                ucApply_yyy.Year = DateTime.Now.Year - 1; 
            }
            ucApply_yyy_SelectedIndexChanged(sender, e);
            ShowReSendData();
        }
    }

    protected void ShowReSendData()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
        {
            SAL1110 bll = new SAL1110();
            DataTable dt = bll.GetDataByOrgFid(org, fid);
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                dt = bll.GetDataByOrgFid(org, fid);
                this.GridViewA.DataSource = dt;
                this.GridViewA.DataBind();

                ucApply_yyy.Year = CommonFun.getInt(dt.Rows[0]["Apply_yy"].ToString()) + 1911;
            }

            btn_submit.Text = "確認";
            btn_back.Visible = true;
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];
        SAL1110 bll = new SAL1110();
        DataTable dt = new DataTable();
        Page p = this.Page;

        try
        {
            if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
            {
                dao.Upd(ucApply_yyy.Year.ToString(), org, fid);
                dt = bll.GetDataByOrgFid(org, fid);
            }
            else
            {
                string flow_id = string.Empty;
                string msg = dao.Apply(ucApply_yyy.Year.ToString(), ref flow_id);

                if (!string.IsNullOrEmpty(msg))
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
                    return;
                }
                else
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");

                dt = bll.GetDataByOrgFid(LoginManager.OrgCode, flow_id);
            }

            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ucApply_yyy_SelectedIndexChanged(sender, e);
            //this.btn_submit.Enabled = false;
        }
        catch (FlowException fex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, fex.Message, "", "");
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }

    protected void ucApply_yyy_SelectedIndexChanged(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (String.IsNullOrEmpty(fid) || String.IsNullOrEmpty(org))
        {
            SAL1110 bll = new SAL1110();
            DataTable cdt = bll.getCheckData(ucApply_yyy.Year.ToString(), LoginManager.UserId);
            if (cdt != null && cdt.Rows.Count > 0)
            {
                System.Text.StringBuilder notice = new System.Text.StringBuilder();
                foreach (DataRow dr in cdt.Rows)
                {
                    notice.Append("您已有申請" + ucApply_yyy.Year.ToString() + "年度的繳納證明，案件編號" + dr["flow_id"].ToString() + "，確定還要申請?\\n");
                }

                lbNotice.Text = notice.ToString();
            }
            else
            {
                lbNotice.Text = "";
            }
        }
    }
}