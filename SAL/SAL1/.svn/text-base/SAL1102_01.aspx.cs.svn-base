using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAL.Logic;
using System.Data;
using System.IO;

public partial class SAL_SAL1_SAL1102_01 : BaseWebForm
{
    SAL1102 dao = new SAL1102();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowReSendData();
            FSC.Logic.Personnel personnel = new FSC.Logic.Personnel();

            if (!personnel.GetColumnValue("Role_id", LoginManager.UserId).Contains("Personnel"))
            {
                this.btn_search.Enabled = false;
                this.btn_submit.Enabled = false;
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "所屬機關為人事室自動排班人員才可使用。", "", "");
            }
        }
    }

    protected void ShowReSendData()
    {
        string fid = Request.QueryString["fid"];
        string org = Request.QueryString["org"];

        if (!string.IsNullOrEmpty(fid) && !string.IsNullOrEmpty(org))
        {
            DataTable dtMain = dao.sdfmDAO.GetAll(org, "", fid);
            if (dtMain !=null && dtMain.Rows.Count > 0)
            {
                DataTable dt = dao.GetDutyInfoByFlow(fid);
                UcDate1.ROCYear = dtMain.Rows[0]["Apply_ym"].ToString().Substring(0, 3);
                UcDate1.Month = dtMain.Rows[0]["Apply_ym"].ToString().Substring(3,2);
                GridViewA.DataSource = dt;
                GridViewA.DataBind();

                foreach (GridViewRow gvr in GridViewA.Rows)
                {
                    TextBox txtSchedule_hours = (TextBox)gvr.FindControl("txtSchedule_hours");
                    Label lbApplyHour_cnt = (Label)gvr.FindControl("lbApplyHour_cnt");

                    txtSchedule_hours.Text = lbApplyHour_cnt.Text;
                }

                this.hfYearMonth.Value = dtMain.Rows[0]["Apply_ym"].ToString();
                ViewState["CurrentTable"] = dt;

                this.btn_submit.Text = "確認";
            }
           
            btn_search.Visible = false;
            BackBtn.Visible = true;
        }
        else
        {
            this.GridViewA.DataSource = dao.GetDutyInfo(UcDate1.ROCYearMonth);
            this.GridViewA.DataBind();
            this.hfYearMonth.Value = UcDate1.ROCYearMonth;
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        ShowReSendData();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        

        if (GridViewA.Rows.Count <= 0)
        {
            msg += "至少輸入一筆申請\\n";
        }

        Page p = this.Page;
        if (string.IsNullOrEmpty(msg))
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Duty_date"));
            dt.Columns.Add(new DataColumn("Duty_sTime"));
            dt.Columns.Add(new DataColumn("Duty_eTime"));
            dt.Columns.Add(new DataColumn("Duty_Hours"));
            dt.Columns.Add(new DataColumn("ApplyHour_cnt"));
            dt.Columns.Add(new DataColumn("Is_rest"));
            dt.Columns.Add(new DataColumn("MEMO"));
            dt.Columns.Add(new DataColumn("Depart_id"));
            dt.Columns.Add(new DataColumn("Id_card")); 
            dt.Columns.Add(new DataColumn("Apply_amt", typeof(System.Int32)));
            
            try
            {
                foreach (GridViewRow gr in GridViewA.Rows)
                {
                    CheckBox cbx = (CheckBox)gr.FindControl("gvCbx");
                    if (!cbx.Checked)
                        continue;
                    
                    TextBox txtSchedule_hours = (TextBox)gr.FindControl("txtSchedule_hours");
                    TextBox txtmemo = (TextBox)gr.FindControl("txtmemo");
                    TextBox txtDuty_fee = (TextBox)gr.FindControl("txtDuty_fee");
                    HiddenField hf_Depart_id = (HiddenField)gr.FindControl("hf_Depart_id");
                    HiddenField hf_id_card = (HiddenField)gr.FindControl("hf_id_card");
                    CheckBox chis_rest = (CheckBox)gr.FindControl("chis_rest");
                    DataRow dr = dt.NewRow();
                    dr["Duty_date"] = gr.Cells[3].Text;
                    dr["Duty_sTime"] = gr.Cells[4].Text;
                    dr["Duty_eTime"] = gr.Cells[5].Text;
                    dr["Duty_Hours"] = txtSchedule_hours.Text;
                    dr["Is_rest"] = chis_rest.Checked ? "Y":"N";
                    dr["MEMO"] = txtmemo.Text;
                    dr["Depart_id"] = hf_Depart_id.Value ;
                    dr["Id_card"] = hf_id_card.Value;
                    dr["ApplyHour_cnt"] = ((TextBox)gr.FindControl("txtSchedule_hours")).Text;
                    int applyAmt = string.IsNullOrEmpty(txtDuty_fee.Text) ? 0 : Convert.ToInt16(txtDuty_fee.Text);
                    dr["Apply_amt"] = applyAmt;
                    if (applyAmt != 0)
                    {
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count < 1)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請至少申請一筆", "", "");
                    return;
                }
                String fid = Request.QueryString["fid"];
                String org = Request.QueryString["org"];
                if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
                {
                   
                   
                    dao.Upd(dt, org, fid, this.hfYearMonth.Value);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
                }
                else
                {
                    dao.Apply(this.hfYearMonth.Value, dt);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請已送出", "", "");
                }
                
               // this.btn_submit.Enabled = false;
               // this.btn_search.Enabled = false;

                btn_search_Click(null,null);
            }
            catch (FormatException ex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請輸入數字", "", "");
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            }
            catch (Exception ex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            }
        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }
    protected void gvCbxAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbxAll = (CheckBox)sender;

        foreach (GridViewRow gr in GridViewA.Rows)
        {
            CheckBox cbx = (CheckBox)gr.FindControl("gvCbx");
            cbx.Checked = cbxAll.Checked;
        }
    }
    //必須覆寫 Page.VerifyRenderingInServerForm　
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btn_export_Click(object sender, EventArgs e)
    {

        string fid = Request.QueryString["fid"];
        string org = Request.QueryString["org"];
/*
        if (!string.IsNullOrEmpty(fid) && !string.IsNullOrEmpty(org))
        {
        }
        else
        {

            string filename = "值班費申請";
            string strfileext = ".xls";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

            //先把分頁關掉
            this.GridViewA.AllowPaging = false;
            this.GridViewA.DataSource = dao.GetDutyInfo(UcDate1.ROCYearMonth);
            this.GridViewA.DataBind();

            this.GridViewA.BorderStyle = Solid;

            //Get the HTML for the control.
            this.GridViewA.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();

            this.GridViewA.AllowPaging = true;
            this.GridViewA.DataBind();

            this.hfYearMonth.Value = UcDate1.ROCYearMonth;

        }
 */
        string filename = "值班費申請";
        string title = "值班費申請";

        string html = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=big5\">"
                     + "<title>值班費申請</title></head>" + title + "<br>";
        html += "<table border=\"1\">";

        //表頭
        html += "<tr>";
        for (int i = 1; i < this.GridViewA.Columns.Count; i++)
        {
            if (!this.GridViewA.Columns[i].Visible)
            {
                continue;
            }
            html += "<td bgcolor=\"#E4E4E4\">" + this.GridViewA.HeaderRow.Cells[i].Text;
        }

        html += "</tr>";

        //先把分頁關掉
        this.GridViewA.AllowPaging = false;
        this.GridViewA.DataSource = dao.GetDutyInfo(UcDate1.ROCYearMonth);
        this.GridViewA.DataBind();
        //內容
        for (int i = 0; i < this.GridViewA.Rows.Count; i++)
        {
            html += "<tr>";
            for (int c = 1; c < this.GridViewA.Columns.Count; c++)
            {
                if (!this.GridViewA.Columns[c].Visible)
                {
                    continue;
                }
                if (this.GridViewA.Rows[i].Cells[c].Controls.Count > 0)
                {
                    html += "<td>" + ((TextBox)this.GridViewA.Rows[i].Cells[c].Controls[1]).Text + "</td>";
                    //html += "<td>" + this.GridViewA.Rows[i].Cells[c].Text + "</td>";
                }
                else
                {
                    html += "<td>" + this.GridViewA.Rows[i].Cells[c].Text + "</td>";
                }

            }
            html += "</tr>";
        }
        html += "</table>";

        this.GridViewA.AllowPaging = true;
        this.GridViewA.DataBind();

        string sContentDisposition = "";
        sContentDisposition += "attachment; "; // 強制存檔，未設定則依瀏覽器預設開啟或存檔
        sContentDisposition += "filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) + ".xls"; //設定檔名可為中文_#1

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-disposition", sContentDisposition);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excle";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

        //utt8 to ascii
        Byte[] bytes = System.Text.Encoding.Unicode.GetBytes(html);
        Byte[] outByte = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, bytes);

        HttpContext.Current.Response.BinaryWrite(outByte);
        HttpContext.Current.Response.End();
  

    }
}