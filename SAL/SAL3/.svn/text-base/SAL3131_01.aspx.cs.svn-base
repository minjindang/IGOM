using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Text;
using System.Collections;
using System.Transactions;
using SALPLM.Logic;

public partial class SAL3131_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

    }

    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll = (CheckBox)sender;

        foreach (GridViewRow gvr in gvlist.Rows)
        {
            CheckBox cbx = (CheckBox)gvr.FindControl("cbx");
            cbx.Checked = cbAll.Checked;
        }
    }

    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlist.PageIndex = e.NewPageIndex;
        gvlist.DataSource = (DataTable)ViewState["dt"];
        gvlist.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty (tbFlow_id.Text.Trim()))
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請輸入申請案件編號!", "", "");
            return;
        }

        Bind();
    }

    protected void Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string flow_id = tbFlow_id.Text.Trim();
        DataTable dt = new DataTable();
        SAL3131 bll = new SAL3131();

        dt = bll.getData(Orgcode, flow_id);

        //foreach (DataRow dr in dt.Rows)
        //{
        //    for (int i = 0; i <= dt.Columns.Count - 1; i++)
        //    {
        //        if (string.IsNullOrEmpty(dr[i].ToString()))
        //        {
        //            dr[i] = "無";
        //        }
        //    }
        //}

        ViewState["dt"] = dt;
        gvlist.DataSource = dt;
        gvlist.DataBind();

        tbq.Visible = true;
        btnAllUpdate.Visible = (dt != null && dt.Rows.Count > 0);
        btnAllUpdate.Enabled = (dt != null && dt.Rows.Count > 0);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        setGvButton(false);
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        Button btnUpdate = (Button)gvr.FindControl("btnUpdate");
        Button btnConfirm = (Button)gvr.FindControl("btnConfirm");
        Button btnCancel = (Button)gvr.FindControl("btnCancel");
        TextBox tbFee_BASE_ADDR = (TextBox)gvr.FindControl("tbFee_BASE_ADDR");
        Label lbFee_BASE_ADDR = (Label)gvr.FindControl("lbFee_BASE_ADDR");

        btnUpdate.Visible = false;
        btnConfirm.Enabled = true;
        btnConfirm.Visible = true;
        btnCancel.Enabled = true;
        btnCancel.Visible = true;
        tbFee_BASE_ADDR.Visible = true;
        lbFee_BASE_ADDR.Visible = false;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Page p = this.Page;
        try
        {
            SAL3131 bll = new SAL3131();
            GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
            Label lbid = (Label)gvr.FindControl("lbid");
            TextBox tbFee_BASE_ADDR = (TextBox)gvr.FindControl("tbFee_BASE_ADDR");
            bll.updateEXAMINE_fee(lbid.Text, tbFee_BASE_ADDR.Text.Trim());

            CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
            Bind();
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    protected void btnAllUpdate_Click(object sender, EventArgs e)
    {
        SAL3131 bll = new SAL3131();
        Page p = this.Page;
        bool isChk = false;

        try
        {
            using (TransactionScope trans = new TransactionScope())
            {
                foreach (GridViewRow gvr in gvlist.Rows)
                {
                    CheckBox cbx = (CheckBox)gvr.FindControl("cbx");
                    if (cbx.Checked)
                    {
                        isChk = true;
                        Label lbBASE_IDNO = (Label)gvr.FindControl("lbBASE_IDNO");
                        Label lbFee_BASE_NAME = (Label)gvr.FindControl("lbFee_BASE_NAME");
                        Label lbFee_BASE_SERVICE_PLACE_DESC = (Label)gvr.FindControl("lbFee_BASE_SERVICE_PLACE_DESC");
                        Label lbFee_BASE_DCODE_NAME = (Label)gvr.FindControl("lbFee_BASE_DCODE_NAME");
                        Label lbFee_BASE_ADDR = (Label)gvr.FindControl("lbFee_BASE_ADDR");
                        Label lbBASE_BANK_CODE = (Label)gvr.FindControl("lbBASE_BANK_CODE");
                        Label lbBASE_BANK_NO = (Label)gvr.FindControl("lbBASE_BANK_NO");

                        bll.UpdateSABASE(lbBASE_IDNO.Text, lbFee_BASE_NAME.Text, lbFee_BASE_SERVICE_PLACE_DESC.Text, lbFee_BASE_DCODE_NAME.Text,
                            lbFee_BASE_ADDR.Text, lbBASE_BANK_CODE.Text, lbBASE_BANK_NO.Text);
                    }
                }

                trans.Complete();
            }

            if (!isChk)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請至少勾選一筆申請資料!", "", "");
                return;
            }

            CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
            Bind();
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gvlist.DataSource = (DataTable)ViewState["dt"];
        gvlist.DataBind();
    }

    protected void setGvButton(bool Enabled)
    {
        foreach (GridViewRow gvr in gvlist.Rows)
        {
            CheckBox cbx = (CheckBox)gvr.FindControl("cbx");
            Button btnUpdate = (Button)gvr.FindControl("btnUpdate");
            Button btnConfirm = (Button)gvr.FindControl("btnConfirm");
            Button btnCancel = (Button)gvr.FindControl("btnCancel");

            cbx.Enabled = Enabled;
            btnUpdate.Enabled = Enabled;
            btnConfirm.Enabled = Enabled;
            btnCancel.Enabled = Enabled;
        }

        btnAllUpdate.Enabled = Enabled;
    }

}
