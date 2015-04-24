using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY4_PAY4101_02 : BaseWebForm
{
    PAY4101 dao = new PAY4101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }

    
    protected void btnDone_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;

        if (string.IsNullOrEmpty(txtExamineIncome_type.Text))
        {
            msg += @"請輸入審查收入類別\n";
        }

        if (string.IsNullOrEmpty(txtExamineIncome_name.Text))
        {
            msg += @"請輸入審查收入名稱\n";
        }

        if (string.IsNullOrEmpty(txtUnit.Text))
        {
            msg += @"請輸入計費單位\n";
        }

        if (string.IsNullOrEmpty(txtUnitPrice_amt.Text))
        {
            msg += @"請輸入計費單價\n";
        }

        if (string.IsNullOrEmpty(txtPaymentCode.Text))
        {
            msg += @"請輸入收據字號\n";
        }

        if (string.IsNullOrEmpty(txtLatestReceipt_nos.Text))
        {
            msg += @"請輸目入前使用收據編號\n";
        }

        
        if (string.IsNullOrEmpty(msg))
        {
            if (!CommonFun.IsNum(txtUnitPrice_amt.Text.Trim()))
            {
                Page tmpPage = this.Page;
                CommonFun.MsgShow(ref tmpPage, CommonFun.Msg.Custom, "計費單價請輸入數字!", "", "");
                return;
            }

            msg = dao.Add(txtExamineIncome_type.Text, txtExamineIncome_name.Text, txtPaymentCode.Text, txtUnit.Text, Convert.ToInt16(txtUnitPrice_amt.Text), txtLatestReceipt_nos.Text);

            if (string.IsNullOrEmpty(msg))
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.InsertOK, "", "PAY4101_01.aspx", "");
                //Page.Response.Redirect("~/PAY/PAY4/PAY4101_01.aspx");
            }
            else
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }
        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }

    }

    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
    }
}