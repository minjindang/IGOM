using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1108_01 : BaseWebForm
{
    SAL1108 dao = new SAL1108();
    string orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                btn_submit.Visible = false;
                btn_Confirm.Visible = true;
                btnBack.Visible = true;
                ShowReSendData();
            }
            else
            {
                Bind();
            }
        }
      
    }

    private void Bind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("BASE_SEQNO"));
        dt.Columns.Add(new DataColumn("BASE_NAME"));
        dt.Columns.Add(new DataColumn("Apply_amt"));
        dt.Columns.Add(new DataColumn("main_id"));
        dt.Columns.Add(new DataColumn("Id"));

        ViewState["dt"] = dt;

    }
    private void ShowReSendData()
    {
        DataTable dt1 = new FSCPLM.Logic.SAL_VOL_feeDtl().getDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            //dt1.Columns.Add(new DataColumn("BASE_SEQNO"));
            //dt1.Columns.Add(new DataColumn("BASE_NAME"));
            //Page p = this.Page;
            //for(int i =0 ; i <dt1.Rows.Count;i++)//foreach ( DataRow dr in dt1.Rows)         //For Each dr As DataRow In dt.Rows
            //{
            //    dt1.Rows[i]["BASE_SEQNO"] = dt1.Rows[i]["vol_user_id"].ToString();
            //    dt1.Rows[i]["BASE_NAME"] = dt1.Rows[i]["User_name"].ToString();
            //}
   
            UcDate1.ROCYear = dt1.Rows[0]["Apply_ym"].ToString().Substring(0, 3);
            UcDate1.Month = dt1.Rows[0]["Apply_ym"].ToString().Substring(3,2);
            this.GridViewA.DataSource = dt1;
            this.GridViewA.DataBind();

            ViewState["dt"] = dt1;
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {     
        Page p = this.Page;

        DataTable dt = (DataTable)ViewState["dt"];

        if (dt == null || dt.Rows.Count <= 0)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請先挑選志工!", "", "");
            return;
        }

        foreach (GridViewRow gr in GridViewA.Rows)
        {
            TextBox txtApply_amt = (TextBox)gr.FindControl("txtApply_amt");
            HiddenField hfMainId = (HiddenField)gr.FindControl("hfMainId");
            HiddenField hfId = (HiddenField)gr.FindControl("hfId");
            if (!string.IsNullOrEmpty(txtApply_amt.Text))
            {
                DataRow dr = dt.Rows[gr.RowIndex];
                dr["BASE_SEQNO"] = gr.Cells[0].Text;
                dr["Apply_amt"] = CommonFun.getInt(txtApply_amt.Text);
                dr["main_id"] = CommonFun.getInt(hfMainId.Value);
                dr["Id"] = CommonFun.getInt(hfId.Value);
            }

        }   
        if (dt.Rows.Count > 0)
        {
            Int32 iDate = Int32.Parse(UcDate1.ROCYearMonth);
            Int32 iNowDate = Int32.Parse(DateTime.Now.ToString("yyyyMM"))-191100;
            if (iDate > iNowDate)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請年月不可超過當月", "", "");
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    
                    dao.Add(UcDate1.ROCYearMonth, dt, Request.QueryString["fid"]);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "更新完成", "", "");
                    btnMergePrint.Enabled = true;
                    ShowReSendData();
                }
                else
                {
                    dao.Add(UcDate1.ROCYearMonth, dt, "");
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
                    btnMergePrint.Enabled = true;


                }
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
        else
        {            
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "至少輸入一筆申請", "", "");
        }
        
    }
    protected void btnMergePrint_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["fid"]))
        {
        Response.Redirect(string.Format("~/SAL/SAL2/SAL2209_01.aspx?flow_id={0}", Request.QueryString["fId"].ToString()));
        }
        else
        {
            DataTable dt= dao.GetNewFlowid(orgcode);
            string flowid = dt.Rows[0]["flow_id"].ToString();
            Response.Redirect(string.Format("~/SAL/SAL2/SAL2209_01.aspx?flow_id={0}", flowid));
        }
    }

    protected void cbConfirm_Click(object sender, EventArgs e)
    {
        BindPeople();
        btnQuery_ModalPopupExtender.Show();
    }
    protected void BindPeople()
    {
        string base_idno = tbIDNO.Text;
        string base_name = tbName.Text;
        DataTable dt = dao.GetSAbase(base_idno, base_name);
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void cbCancel_Click(object sender, EventArgs e)
    {
        btnQuery_ModalPopupExtender.Hide();
    }
    protected void cbPick_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dt"];

        foreach (GridViewRow gvr in gv.Rows)
        {
            CheckBox cbx = (CheckBox)gvr.FindControl("gvCbx");
            if (cbx.Checked)
            {
                bool b = true;
                foreach (DataRow dr in dt.Rows) 
                {
                    if (dr["BASE_SEQNO"].ToString() == gvr.Cells[1].Text)
                        b = false;
                }
                if (b)
                {
                    DataRow ndr = dt.NewRow();
                    ndr["BASE_SEQNO"] = gvr.Cells[1].Text;
                    ndr["BASE_NAME"] = gvr.Cells[2].Text;
                    dt.Rows.Add(ndr);
                }
            }
        }
        ViewState["dt"] = dt;
        GridViewA.DataSource = dt;
        GridViewA.DataBind();

        btnQuery_ModalPopupExtender.Show();
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindPeople();

        btnQuery_ModalPopupExtender.Show();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ViewState["BackUrl"]!=null)
            Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void cbDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        DataTable dt = (DataTable)ViewState["dt"];
        dt.Rows.Remove(dt.Rows[gvr.RowIndex]);
        GridViewA.DataSource = dt;
        GridViewA.DataBind();
    }
}