using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using SALPLM.Logic;
using System.Data;
using System.Configuration;

public partial class SAL3130_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        UcDDLDepart.Orgcode = LoginManager.OrgCode;
    }
    
    protected void cbSearch_Click(object sender, EventArgs e)
    {
        Bind();
    }

    protected void Bind()
    {
        String orgcode = LoginManager.OrgCode;
        String departId = UcDDLDepart.SelectedValue;
        String idCard = txtId_card.Text;
        String sendStatus = ddlSend_status.SelectedValue;

        SAL3130 bll = new SAL3130();
        DataTable dt = bll.GetQueryData(orgcode, departId, idCard, sendStatus);

        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void cbInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3130_02.aspx");
    }
    protected void cbSendList_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3130_03.aspx");
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        String id = ((HiddenField)gvr.FindControl("hfId")).Value;
        SAL3130 bll = new SAL3130();
        SAL.Logic.PaySalChgNoticMain pscn = new SAL.Logic.PaySalChgNoticMain();
        FSC.Logic.Personnel psn = new FSC.Logic.Personnel();
        Boolean b = false;

        Page p = this.Page;

        SALARY.Logic.PaySalChgNoticSendList sl = new SALARY.Logic.PaySalChgNoticSendList();
        sl.Send_orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        DataTable dt = sl.getDataByOrg();

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                String femail = ConfigurationManager.AppSettings["SysMail"].ToString();
                String fname = ConfigurationManager.AppSettings["SysName"].ToString();
                String temail = psn.GetColumnValue("email", dr["send_idcard"].ToString());
                String tname = psn.GetColumnValue("User_name", dr["send_idcard"].ToString());
                String content = bll.GetContent(CommonFun.getInt(id));

                if (!String.IsNullOrEmpty(content))
                {
                    CommonFun.SendMail(femail, temail, fname, tname, "職員敍薪(異動)通知", content, "", "");
                    pscn.UpdateSendStatus(CommonFun.getInt(id), "1");
                    b = true;
                }
            }
        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "尚未設定發送名單", "", "");
            return;
        }
    
        if(b) CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "發送成功", "", "");
        else CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "發送失敗", "", "");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        String id = ((HiddenField)gvr.FindControl("hfId")).Value;
        Response.Redirect("SAL3130_02.aspx?id=" + id);
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        Bind();
    }
}