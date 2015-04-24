using FSCPLM.Logic;
using SALARY.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAL.Logic;

public partial class SAL_SAL1_SAL1101_01 : BaseWebForm
{
    SAL1101 dao = new SAL1101();

    public void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hfOrgcode.Value = LoginManager.OrgCode;
            hfDepartId.Value = LoginManager.Depart_id;
            hfUserId.Value = LoginManager.UserId;

            Bind();
        }
    }

    protected void ShowReSendData()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
        {
            DataTable dt = dao.GetDataByOrgFid(org, fid);

            GridViewA.DataSource = dt;
            GridViewA.DataBind();
            ViewState["CurrentTable"] = dt;

            SubmitBtn.Text = "確認";
            BackBtn.Visible = true;

            SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(org, fid);
            if (f != null)
            {
                hfOrgcode.Value = f.Orgcode;
                hfDepartId.Value = f.DepartId;
                hfUserId.Value = f.ApplyIdcard;
            }
        }
    }

    protected void Bind()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
            ShowReSendData();
        else
        {
            DataTable dt = dao.GetData(LoginManager.OrgCode, LoginManager.UserId);
            GridViewA.DataSource = dt;
            GridViewA.DataBind();
            ViewState["CurrentTable"] = dt;
        }
    }


    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        string msg = string.Empty;
        if (string.IsNullOrEmpty(txtApply_desc.Text))
        {
            msg += @"請輸入事由\n";
        }
        if (string.IsNullOrEmpty(this.ucCost_date.Text))
        {
            msg += @"請輸入乘車日期\n";
        }
        else
        {
            long iDate = 0;
            long iDateToday = 0;
            iDate = long.Parse(this.ucCost_date.Text.Replace("/", ""));
            iDateToday = long.Parse(DateTime.Today.ToString("yyyyMMdd")) - 19110000;
            if (iDate > iDateToday)
            {
                msg += @"申請日期不可大於系統日期\n";
            }
        }

        if (string.IsNullOrEmpty(this.txtApply_amt.Text))
        {
            msg += @"請輸入車費\n";
        }
        if (!CommonFun.IsNum(txtApply_amt.Text.Trim()))
        {
            msg += @"車費請輸入數字\n";
        }
        if (string.IsNullOrEmpty(msg))
        {
            if (string.IsNullOrEmpty(hfModifyIndex.Value))
            {
                dao.InsertFee(fid, hfDepartId.Value, hfUserId.Value, ucCost_date.Text, CommonFun.ConvertToInt(txtApply_amt.Text), txtApply_desc.Text);
            }
            else
            {
                dao.UpdateFee(hfModifyIndex.Value, ucCost_date.Text, CommonFun.ConvertToInt(txtApply_amt.Text), txtApply_desc.Text);
                hfModifyIndex.Value = "";
                InsertBtn.Text = "新增";
            }

            txtApply_desc.Text = "";
            txtApply_amt.Text = "";
            ucCost_date.Text = "";
            Bind();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }

    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        string msg = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("Apply_amt", typeof(Int32));
        foreach (GridViewRow gvr in GridViewA.Rows)
        {
            CheckBox cbx = (CheckBox)gvr.FindControl("cbx");
            if (cbx.Checked)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = ((HiddenField)gvr.FindControl("hfId")).Value;
                dr["Apply_amt"] = CommonFun.ConvertToInt(((HiddenField)gvr.FindControl("hfApply_amt")).Value);
                dt.Rows.Add(dr);
            }
        }
        if (dt == null || dt.Rows.Count <= 0)
        {
            msg += "至少勾選一筆申請\\n";
        }

        Page p = this.Page;
        if (string.IsNullOrEmpty(msg))
        {

            try
            {
                if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
                {
                    dao.Upd(dt, org, fid);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
                }
                else
                {
                    this.hfFlow_id.Value = dao.Add(dt);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請已送出", "", "");
                    Bind();
                }
               
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

    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        //string url = "SAL1101_02.aspx?1=1";
        //url += "&Cost_date=" + HttpUtility.UrlEncode(ucCost_date.Text.Substring(0, 3));
        //url += "&Flow_id=" + HttpUtility.UrlEncode(hfFlow_id.Value);
        //url += "&Apply_desc=" + HttpUtility.UrlEncode(txtApply_desc.Text);
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        string Apply_desc = string.Empty;
        string Cost_date = string.Empty;
        foreach (DataRow ddr in dtCurrentTable.Rows)
        {
            if (string.IsNullOrEmpty(Cost_date))
                Cost_date = ddr["Cost_date"].ToString();
            Apply_desc += new FSC.Logic.Org().GetDepartName(hfOrgcode.Value, ddr["unit_code"].ToString()) + " " + new FSC.Logic.Personnel().GetColumnValue("User_name", ddr["User_id"].ToString())
                + "申請短程車費：" + FSC.Logic.DateTimeInfo.ConvertToDisplay(ddr["Cost_date"].ToString(), "/") + "  : " + ddr["Apply_desc"].ToString() + "<br />";
        }
        //url += "&Apply_desc=" + desc;
        ////url += "&Apply_amt=" + HttpUtility.UrlEncode(dtCurrentTable.Compute("sum(Convert(Apply_amt, 'System.Int32'))", "").ToString()); 
        //url += "&Apply_amt=" + HttpUtility.UrlEncode(dtCurrentTable.Compute("sum(Apply_amt)", "").ToString());
        //Response.Redirect(url);
        //Response.Write("<script>window.open('" + url + "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;");

        string Apply_amt = dtCurrentTable.Compute("sum(Apply_amt)", "").ToString();
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("Cost_date"));
        dt.Columns.Add(new DataColumn("Flow_id"));
        dt.Columns.Add(new DataColumn("Apply_desc"));
        dt.Columns.Add(new DataColumn("HundredMillion"));
        dt.Columns.Add(new DataColumn("TenMillion"));
        dt.Columns.Add(new DataColumn("Million"));
        dt.Columns.Add(new DataColumn("HundredThousand"));
        dt.Columns.Add(new DataColumn("TenThousand"));
        dt.Columns.Add(new DataColumn("Thousand"));
        dt.Columns.Add(new DataColumn("Hundred"));
        dt.Columns.Add(new DataColumn("Ten"));
        dt.Columns.Add(new DataColumn("Unit"));

        Apply_amt = ("$" + Apply_amt).PadLeft(9, ' ');

        DataRow dr = dt.NewRow();
        //dr["Even_date"] = dr["Cost_date"].ToString();
        dr["Cost_date"] = Cost_date.Substring(0, 3);
        dr["Flow_id"] = "";
        dr["Apply_desc"] = Apply_desc;
        dr["HundredMillion"] = Apply_amt.Substring(0, 1);
        dr["TenMillion"] = Apply_amt.Substring(1, 1);
        dr["Million"] = Apply_amt.Substring(2, 1);
        dr["HundredThousand"] = Apply_amt.Substring(3, 1);
        dr["TenThousand"] = Apply_amt.Substring(4, 1);
        dr["Thousand"] = Apply_amt.Substring(5, 1);
        dr["Hundred"] = Apply_amt.Substring(6, 1);
        dr["Ten"] = Apply_amt.Substring(7, 1);
        dr["Unit"] = Apply_amt.Substring(8, 1);

        dt.Rows.Add(dr);

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL1101_01.mht"), dt);
        //theDTReport.breakPage = "Cost_date"; 
        theDTReport.ExportFileName = "支出憑證黏存單";
        theDTReport.ExportToWord();

        dt.Dispose();
    }

    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        MasterPage m = this.Master;
        CommonFun.ClearContentPlaceHolder(ref m);
        hfModifyIndex.Value = "";
        InsertBtn.Text = "新增";
    }
    
    protected void btnMain_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((System.Web.UI.WebControls.Button)sender).NamingContainer;
        hfModifyIndex.Value = ((HiddenField)gr.FindControl("hfId")).Value;
        txtApply_desc.Text = ((HiddenField)gr.FindControl("hfApply_desc")).Value;
        ucCost_date.Text = ((HiddenField)gr.FindControl("hfCost_date")).Value;
        txtApply_amt.Text = ((HiddenField)gr.FindControl("hfApply_amt")).Value;
        InsertBtn.Text = "更新";
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((System.Web.UI.WebControls.Button)sender).NamingContainer;
        String id = ((HiddenField)gr.FindControl("hfId")).Value;
        dao.DeleteFee(id);
        Bind();
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        if(ViewState["BackUrl"]!=null)
            Response.Redirect(ViewState["BackUrl"].ToString());
    }
}