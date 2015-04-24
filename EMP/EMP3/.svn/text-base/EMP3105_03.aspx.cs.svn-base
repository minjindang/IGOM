using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

public partial class EMP3105_03 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        Bind();
    }

    protected void Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string Id_card = Request.QueryString["id"];

        try
        {
            TemporarilyTransfe bll = new TemporarilyTransfe();
            gvList.DataSource = bll.getDataByIdcard(Id_card);
            gvList.DataBind();

            cbBack.Visible = true;
            cbCancel.Visible = false;
            lbId.Text = "";
            UcDateS.Text = "";
            UcDateE.Text = "";
            tbMemo.Text = "";
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    protected void cbConfirm_Click(object sender, System.EventArgs e)
    {
        Page p = this.Page;
        string Id_card = Request.QueryString["id"];

        if (string.IsNullOrEmpty(UcDateS.Text))
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "借調日期(起)不可空白!", "", "");
            return;
        }
        if (string.IsNullOrEmpty(UcDateE.Text))
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "借調日期(迄)不可空白!", "", "");
            return;
        }
        if (CommonFun.getInt(UcDateS.Text) > CommonFun.getInt(UcDateE.Text))
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "借調日期(起)不可大於借調日期(迄)", "", "");
            return;
        }
        if (tbMemo.Text.Trim().Length > 200)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "備註請勿輸入超過200字", "", "");
            return;
        }

        try
        {
            TemporarilyTransfe bll = new TemporarilyTransfe();
            bll.id_card = Id_card;
            bll.Start_date = UcDateS.Text;
            bll.End_date = UcDateE.Text;
            bll.Memo = tbMemo.Text;

            if (!string.IsNullOrEmpty(lbId.Text))
            {
                bll.id = CommonFun.getInt(lbId.Text);
                bll.update();

                CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
            }
            else
            {
                bll.insert();

                CommonFun.MsgShow(ref p, CommonFun.Msg.InsertOK, "", "", "");
            }

            Bind();
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }
    
    protected void cbUpdate_Click(object sender, System.EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        try
        {
            UControl_UcShowDate UcShowDateS = (UControl_UcShowDate)gvr.FindControl("UcShowDateS");
            UControl_UcShowDate UcShowDateE = (UControl_UcShowDate)gvr.FindControl("UcShowDateE");
            Label lbMemo = (Label)gvr.FindControl("lbMemo");
            Label id = (Label)gvr.FindControl("lbId");

            UcDateS.Text = UcShowDateS.Text;
            UcDateE.Text = UcShowDateE.Text;
            tbMemo.Text = lbMemo.Text;
            lbId.Text = id.Text;
            cbBack.Visible = false;
            cbCancel.Visible = true;
            setEnabled(false);
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.SystemError, "", "", "");
            this.Page = tempPage;
        }
    }


    protected void cbDelete_Click(object sender, System.EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        try
        {
            string id = ((Label)gvr.FindControl("lbId")).Text;
            TemporarilyTransfe bll = new TemporarilyTransfe();
            bll.id = CommonFun.getInt(id);
            bll.delete();

            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.DeleteOK, "", "", "");
            Bind();
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.SystemError, "", "", "");
            this.Page = tempPage;
        }
    }

    protected void cbCancel_Click(object sender, EventArgs e)
    {
        Bind();
    }

    protected void setEnabled(bool value)
    {
        foreach (GridViewRow gvr in gvList.Rows)
        {
            Button cbUpdate = (Button)gvr.FindControl("cbUpdate");
            Button cbDelete = (Button)gvr.FindControl("cbDelete");

            cbUpdate.Enabled = value;
            cbDelete.Enabled = value;
        }
    }

    protected void cbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EMP3105_01.aspx");
    }
}