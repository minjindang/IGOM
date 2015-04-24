using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAL.Logic;
using System.Data;
using System.Text;

public partial class SAL_SAL1_SAL1109_01 : BaseWebForm
{
    SAL1109 dao = new SAL1109(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucApply_type.Rebind();
            GetApply_amt();
            ShowReSendData();
            ucApply_type_CodeChanged(sender, e);
        }
    }

    protected void ShowReSendData()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
        {
            DataTable dt = dao.GetDataByOrgFid(org, fid);
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                ucApply_type.SelectedValue = dt.Rows[0]["Apply_type"].ToString();
                this.trRelation_type.Visible = ucApply_type.Code_no == "003";
                if (ucApply_type.SelectedValue=="001")
                UcDateMarry1.Text = dt.Rows[0]["Event_date"].ToString();
                else if (ucApply_type.SelectedValue == "002")
                    UcDateBirth1.Text = dt.Rows[0]["Event_date"].ToString();
                else
                    UcDateDeath1.Text = dt.Rows[0]["Event_date"].ToString();
                GetApply_amt();
            }

            btn_submit.Text = "確認";
            btn_back.Visible = true;
        }
    }

    private void GetApply_amt()
    {
        double apply_amt = 0;
        string msg = dao.GetApply_amt(ucApply_type.Code_no, ref apply_amt);
        if (string.IsNullOrEmpty(msg))
        {
            txtboxAmt.Text = apply_amt.ToString();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }

    protected void ucApply_type_CodeChanged(object sender, EventArgs e)
    {
        this.trRelation_type.Visible = ucApply_type.Code_no == "003";
        this.Marry.Visible = ucApply_type.Code_no == "001";
        this.Birth.Visible = ucApply_type.Code_no == "002";
        this.Death.Visible = ucApply_type.Code_no == "003";

        if (ucApply_type.Code_no == "001")
        {
            this.label1.Visible = true;
            this.label2.Visible = false;
            this.label3.Visible = false;

        }
        else if (ucApply_type.Code_no == "002")
        {
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;
        }
        else if (ucApply_type.Code_no == "003")
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
        }
        
        GetApply_amt();

        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (String.IsNullOrEmpty(fid) || String.IsNullOrEmpty(org))
        {
            DataTable dt = new SAL1109().CheckApply(ucApply_type.Code_no, LoginManager.UserId);
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder notice = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    notice.Append("您已有申請" + new SYS.Logic.CODE().GetDataDESC("006", "015", ucApply_type.Code_no) + "，案件編號為" + dr["flow_id"].ToString() + "，確定還要申請嗎?\\n");
                }
                lbNotice.Text = notice.ToString();
            }
            else
            {
                lbNotice.Text = "";
            }
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];
        String Event_date = "";
        Page p = this.Page;
     
        DataTable dt = null;
       if(ucApply_type.Code_no == "001")
        Event_date = UcDateMarry1.Text;
       else if (ucApply_type.Code_no == "002")
           Event_date = UcDateBirth1.Text; 
       else
           Event_date = UcDateDeath1.Text;

       try
       {
           if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
           {
               dao.Upd(this.ucApply_type.Code_no,
                   ucApply_type.Code_no == "003" ? ucRelation_type.Code_no : "",
                   Convert.ToInt32(txtboxAmt.Text), Event_date, org, fid);

               CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
               dt = dao.GetDataByOrgFid(org, fid);
           }
           else
           {
               string flow_id = string.Empty;
               string msg = dao.Apply(this.ucApply_type.Code_no,
                   ucApply_type.Code_no == "003" ? ucRelation_type.Code_no : "",
                   Convert.ToInt32(txtboxAmt.Text), ref flow_id, Event_date);
               if (string.IsNullOrEmpty(msg))
               {
                   CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
                   //this.btn_submit.Enabled = false;
                   dt = dao.GetDataByOrgFid(LoginManager.OrgCode, flow_id);
               }
               else
               {
                   CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
               }
              
           }

           this.GridViewA.DataSource = dt;
           this.GridViewA.DataBind();
           ucApply_type_CodeChanged(sender, e);
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

}