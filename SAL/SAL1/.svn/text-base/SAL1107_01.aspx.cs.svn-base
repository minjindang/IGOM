using SAL.Logic;
using FSC.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1107_01 : BaseWebForm
{

    SAL1107 dao = new SAL1107();
    string orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"])){
                ShowReSendData();
                this.SubmitBtn .Text = "確認";
            }                
            else
                Bind();
        }
    }

    protected void ShowReSendData()
    {
        DataTable dt = new FSCPLM.Logic.SAL_TRANS_feeDtl().getDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            ucApply_ym.ROCYear = dt.Rows[0]["Apply_ym"].ToString().Substring(0, 3);
            ucApply_ym.Month = dt.Rows[0]["Apply_ym"].ToString().Substring(3).PadLeft(2,'0');

            ViewState["CurrentTable"] = dt;
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();

            foreach (GridViewRow gvr in GridViewA.Rows)
            {
                TextBox txtApply_amt = (TextBox)gvr.FindControl("txtApply_amt");
                HiddenField hfNon_id = (HiddenField)gvr.FindControl("hfNon_id");
                txtApply_amt.Text = dt.Select(string.Format(" Id_card = '{0}' ", hfNon_id.Value))[0]["Apply_amt"].ToString();
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((Button)sender).NamingContainer;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        dtCurrentTable.Rows[gr.RowIndex].Delete();
        dtCurrentTable.AcceptChanges();
        ViewState["CurrentTable"] = dtCurrentTable;
        this.GridViewA.DeleteRow(gr.RowIndex); 
    }

    protected void InsertAllAmtBtn_Click(object sender, EventArgs e)
    {
        Page p = this.Page;
        if (string.IsNullOrEmpty(this.txtAllApply_amt.Text))
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "每年申請金額不得為空", "", "");
            return;
        }
        else
        {
            try
            {
                Convert.ToInt32(this.txtAllApply_amt.Text);
            }
            catch (FormatException ex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "每年申請金額必須為數字", "", "");
                return;
            }
            catch (Exception ex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
                return;
            }
        }

        foreach (GridViewRow gr in GridViewA.Rows)
        {
            TextBox txtApply_amt = (TextBox)gr.FindControl("txtApply_amt");
            //hfNon_id
            HiddenField hfNon_id = (HiddenField)gr.FindControl("hfNon_id");
            txtApply_amt.Text = this.txtAllApply_amt.Text;
        }
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        Page p = this.Page;
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Apply_amt"));
        dt.Columns.Add(new DataColumn("Non_id"));
        foreach (GridViewRow gr in GridViewA.Rows)
        {
            TextBox txtApply_amt = (TextBox)gr.FindControl("txtApply_amt");
            //hfNon_id
            HiddenField hfNon_id = (HiddenField)gr.FindControl("hfNon_id");
            if (!string.IsNullOrEmpty(txtApply_amt.Text))
            {
               
                try
                {
                    DataRow dr = dt.NewRow();
                    dr["Non_id"] = hfNon_id.Value;
                    dr["Apply_amt"] = Convert.ToInt32(txtApply_amt.Text);
                    dt.Rows.Add(dr);
                }
                catch (FormatException ex)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請金額必須為數字", "", "");
                    return;
                }
                catch (Exception ex)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
                    AppException.WriteErrorLog(ex.StackTrace, ex.Message);
                    return;
                }               
            }
        }
        
        if (dt.Rows.Count > 0)
        {
            try
            { //Convert.ToInt32(
                if (String.Compare( ucApply_ym.ROCYearMonth.ToString(), DateTimeInfo.GetRocTodayString("yyyyMM").ToString(), true) > 0)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請年月不得超過當月", "", "");
                    return;
                }
                dao.Apply(this.ucApply_ym.ROCYearMonth, dt, Request.QueryString["fid"]);
                //SubmitBtn.Enabled = false;
                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "修改完成", "", "");
                    btnMergePrint.Enabled = true;
                }
                else
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
                    btnMergePrint.Enabled = true;
                }
                foreach (GridViewRow gr in GridViewA.Rows)
                {
                    Button btnDelete = (Button)gr.FindControl("btnDelete");
                    TextBox txtApply_amt = (TextBox)gr.FindControl("txtApply_amt");
                    btnDelete.Enabled = false;
                    txtApply_amt.Enabled = false;
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

    private void Bind()
    {
        if ((ViewState["CurrentTable"] != null))
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];            
            this.GridViewA.DataSource = dtCurrentTable;
            this.GridViewA.DataBind();
        }
        else
        {
            DataTable dt = dao.GetEmployee();
            ViewState["CurrentTable"] = dt;
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
        }      
    }
        protected void GridViewA_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Bind();
    }
        protected void btnMergePrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                Response.Redirect(string.Format("~/SAL/SAL2/SAL2207_01.aspx?flow_id={0}", Request.QueryString["fId"].ToString()));
            }
            else
            {
                DataTable dt = dao.GetNewFlowid(orgcode);
                string flowid = dt.Rows[0]["flow_id"].ToString();
                Response.Redirect(string.Format("~/SAL/SAL2/SAL2207_01.aspx?flow_id={0}", flowid));
            }
        }
}