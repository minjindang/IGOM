using FSC.Logic;
using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1105_01 : BaseWebForm
{
    SAL1105 dao = new SAL1105();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.btn_print.Enabled = false;
            Personnel personnel = new Personnel();
            string Birth_date = personnel.GetColumnValue("Birth_date", LoginManager.UserId);
            DateTime brDate = CommonFun.getYYYMMDD(Birth_date);
            Page p = this.Page;
            if (DateTime.Now.Year - brDate.Year <= 40)
            {
                this.btn_submit.Enabled = false;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "40歲以下人員不可申請。", "", "");
            }

            FSCPLM.Logic.SACode saDAO = new FSCPLM.Logic.SACode();
            string Degree_code = personnel.GetColumnValue("Degree_code", LoginManager.UserId);
            string CodeDesc = saDAO.GetCodeDesc("023", "030", Degree_code);
            //40歲以上，且為12職等以上主管，每年可申請一次健檢費
            if (!string.IsNullOrEmpty(CodeDesc))
            {
                txtApply_amt.Text = "14000";
            }
            else
            {
                txtApply_amt.Text = "3500";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                ShowReSendData();
                this.btn_submit.Text = "確認";
            }
                
        }
    }

    private void ShowReSendData()
    {
        DataTable dt = new FSCPLM.Logic.SAL_HealthSubsidy_fee().getDateByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            ucApply_yy.Year = CommonFun.getInt(dt.Rows[0]["Apply_yy"]);
            ucCheck_date.Text = dt.Rows[0]["Check_date"].ToString();
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Page p = this.Page;
        string msg = string.Empty;
        if (string.IsNullOrEmpty(ucCheck_date.Text))
        {
           CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "健檢日期為必填!!", "", "");
        }
        if (string.IsNullOrEmpty(Request.QueryString["org"]) && string.IsNullOrEmpty(Request.QueryString["fid"]))
        {
            DataTable dtRecord = dao.shsfDAO.GetAll(LoginManager.OrgCode, LoginManager.UserId, "");
            if (dtRecord != null && dtRecord.Rows.Count > 0)
            {
                // 取出職等
                Personnel personnel = new Personnel();
                string Degree_code = personnel.GetColumnValue("Degree_code", LoginManager.UserId);
                FSCPLM.Logic.SACode saDAO = new FSCPLM.Logic.SACode();
                string CodeDesc = saDAO.GetCodeDesc("023", "030", Degree_code);

                // 取出年紀
                string Birth_date = personnel.GetColumnValue("Birth_date", LoginManager.UserId);
                if (Convert.ToInt32(DateTime.Now.ToString("yyyy")) - 1911 - Convert.ToInt32(Birth_date.Substring(0, 3)) <= 40)
                {
                    msg = "40歲以下不可申請";
                }
                else
                {
                    DataTable dtApply_yy = dtRecord.DefaultView.ToTable(true, "Apply_yy");
                    //40歲以上，且為12職等以上主管，每年可申請一次健檢費
                    if (!string.IsNullOrEmpty(CodeDesc) && dtApply_yy.Select(string.Format(" Apply_yy = '{0}' ", ucApply_yy.Year)).Count() > 0)
                    {
                        msg = "40歲以上，12職等以上之正式人員，限每年申請一次";
                    }
                    else
                    {
                        //40歲以上，且為正式人員(FSC_Personnel.Employee_type=1),二年只能申請一次健檢費用
                        string Employee_type = personnel.GetColumnValue("Employee_type", LoginManager.UserId);
                        if (Employee_type == "1" && dtApply_yy.Select(string.Format(" Apply_yy = '{0}' OR Apply_yy = '{1}' ", (DateTime.Now.Year - 1911 - 1), (DateTime.Now.Year - 1911))).Count() > 0)
                        {
                            msg = "40歲以上，不滿12職等之正式人員，限每兩年申請一次";
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        //Page p = this.Page;
        if (string.IsNullOrEmpty(msg))
        {
            string flow_id = Request.QueryString["fid"]; //string.Empty;
            try
            {
                dao.Apply(ucApply_yy.Year.ToString(), ucCheck_date.Text, Convert.ToInt32(txtApply_amt.Text), flow_id);
                if (string.IsNullOrEmpty(flow_id))
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
                }
                else
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "完成修改", "", "");
                }
                
               
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("User_name"));
                dt.Columns.Add(new DataColumn("Apply_yy"));
                dt.Columns.Add(new DataColumn("Check_date"));
                dt.Columns.Add(new DataColumn("Apply_amt"));

                DataRow dr = dt.NewRow();
                dr["User_name"] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                dr["Apply_yy"] = ucApply_yy.Year;
                dr["Check_date"] = ucCheck_date.Text;
                dr["Apply_amt"] = this.txtApply_amt.Text;

                dt.Rows.Add(dr);

                this.GridViewA.DataSource = dt;
                this.GridViewA.DataBind();
                // this.btn_submit.Enabled = false;
                this.btn_print.Enabled = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            }

            if (!string.IsNullOrEmpty(msg))
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }

        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        DataTable dt = dao.GetReportData(ucApply_yy.Year.ToString());

        if ((dt.Rows.Count) > 0)
        {
            string url = "SAL1105_02a.aspx";
            url += "?Apply_yy=" + ucApply_yy.Year.ToString();
            Response.Redirect(url);
            //string script = "window.open( '{0}' ); ";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "WindowOpenz", string.Format(script, url), true);

        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ucApply_yy.Year.ToString() + "年度並無任何申請資料", "", "");
        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FSC/FSC0/FSC0102_01.aspx");
    }
}