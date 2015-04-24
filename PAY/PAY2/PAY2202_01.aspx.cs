using PAY.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PAY_PAY2_PAY2202_01 : BaseWebForm
{
    PAY2202 dao = new PAY2202();
    PAY3203 dao3203 = new PAY3203();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = dao.pemDAO.GetAll("",true);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlExamineIncome_type.DataSource = dao.pemDAO.GetAll("", true);
                ddlExamineIncome_type.DataTextField = "ExamineIncome_name";
                ddlExamineIncome_type.DataValueField = "ExamineIncome_type";
                ddlExamineIncome_type.DataBind();
                txtExamineIncome_type.Text = dt.Rows[0]["ExamineIncome_type"].ToString();
            }
            
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string url = string.Empty;
        Page p = this.Page;
        if (rblPrintType.SelectedIndex == 0)//收據列印
        {
            url = "PAY2202_02.aspx?1=1";
            if (ucPayMode_type.Code_no == "002")//執行PAY3203程式先將電子付費資料取回後存入本系統資料庫
            {
                if (string.IsNullOrEmpty(ucReceipt_dateS.Text) || string.IsNullOrEmpty(ucReceipt_dateE.Text))
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請輸入收費日期起迄", "", "");
                    return;
                }
                else
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "下載檔案後執行列印請記得放入收據", "", "");
                    dao3203.Transfer(ucReceipt_dateS.Text, ucReceipt_dateE.Text);
                }
            }
        }
        else if (rblPrintType.SelectedIndex == 1)//審查/證照收入明細表
        {
            url = "PAY2202_03.aspx?1=1&printType=0";
        }
        else if (rblPrintType.SelectedIndex == 2)//付款人明細表
        {
            url = "PAY2202_04.aspx?1=1";
        }

         if (!string.IsNullOrEmpty(ucReceipt_dateS.Text))
            url += "&Receipt_dateS=" + Server.HtmlEncode(ucReceipt_dateS.Text);
         if (!string.IsNullOrEmpty(ucReceipt_dateE.Text))
            url += "&Receipt_dateE=" + Server.HtmlEncode(ucReceipt_dateE.Text);
         if (!string.IsNullOrEmpty(ucPayMode_type.Code_no))
            url += "&PayMode_type=" + Server.HtmlEncode(ucPayMode_type.Code_no);
         if (!string.IsNullOrEmpty(this.UcPayer.Payer_id))
            url += "&Payer_id=" + Server.HtmlEncode(this.UcPayer.Payer_id);
        if (rbIncome_type1.Checked)
        {
            url += "&ExamineIncome_type=" + Server.HtmlEncode(this.ddlExamineIncome_type.SelectedValue);
        }
        else
        {
            url += "&ExamineIncome_type=12-20";
        }
        Response.Redirect(url);
        //Response.Write("<script>window.open('" + url + "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        MasterPage p = Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "PAY2202_03.aspx?1=1&printType=1";
        if (string.IsNullOrEmpty(ucReceipt_dateS.Text))
            url += "&Receipt_dateS=" + Server.HtmlEncode(ucReceipt_dateS.Text);
        if (string.IsNullOrEmpty(ucReceipt_dateE.Text))
            url += "&Receipt_dateE=" + Server.HtmlEncode(ucReceipt_dateE.Text);
        if (string.IsNullOrEmpty(ucPayMode_type.Code_no))
            url += "&PayMode_type=" + Server.HtmlEncode(ucPayMode_type.Code_no);
        if (string.IsNullOrEmpty(this.UcPayer.Payer_id))
            url += "&Payer_id=" + Server.HtmlEncode(this.UcPayer.Payer_id);
        if (rbIncome_type1.Checked)
        {
            url += "&ExamineIncome_type=" + Server.HtmlEncode(this.ddlExamineIncome_type.SelectedValue);
        }
        else
        {
            url += "&ExamineIncome_type=07-20";
        }
        Response.Redirect(url);
        }

    private void EnableForType01(bool enabled)
    {
        rbIncome_type1.Enabled = enabled;
        txtExamineIncome_type.Enabled = enabled;
        ddlExamineIncome_type.Enabled = enabled;
        rbIncome_type2.Enabled = enabled;
        UcPayer.Enabled = enabled;
    }

    private void TriggerCheck()
    {
        EnableForType01(!(rblPrintType.SelectedValue == "1" && ucPayMode_type.Code_no == "002"));
    }

    protected void ddlExamineIncome_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtExamineIncome_type.Text = ddlExamineIncome_type.SelectedValue;
    }

    protected void ucPayMode_type_CodeChanged(object sender, EventArgs e)
    {
        TriggerCheck();
    }

    protected void rblPrintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnExport.Enabled = rblPrintType.SelectedIndex == 1;
        //TriggerCheck();
        btnExport.Enabled = true;

        if (rblPrintType.SelectedValue =="1")//收據列印
        {
            btnExport.Enabled=false;
        }

        if (rblPrintType.SelectedValue == "3")//PAY2202_01.aspx
        {
            btnExport.Enabled = false;
        }
    }
}