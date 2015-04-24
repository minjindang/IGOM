using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY4_PAY4101_03 : BaseWebForm
{
    PAY4101 dao = new PAY4101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindcblMtItem_type("001");

            string ExamineIncome_type = Page.Request.QueryString["ExamineIncome_type"].ToString();
            BindOne(ExamineIncome_type);
        }

    } 
    

    protected void DoneBtn_Click(object sender, EventArgs e)
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

            msg = dao.Modify(txtExamineIncome_type.Text, txtExamineIncome_name.Text, txtPaymentCode.Text, txtUnit.Text, Convert.ToInt32(txtUnitPrice_amt.Text), txtLatestReceipt_nos.Text);

            if (string.IsNullOrEmpty(msg))
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "PAY4101_01.aspx", "");
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


    private void BindOne(string ExamineIncome_type)
    {
        string msg = string.Empty;
        DataRow dr = dao.GetOne(ExamineIncome_type, ref msg);
        if (dr != null && string.IsNullOrEmpty(msg))
        {
            txtExamineIncome_type.Text = CommonFun.SetDataRow(ref dr, "ExamineIncome_type").ToString();
            txtExamineIncome_name.Text = CommonFun.SetDataRow(ref dr, "ExamineIncome_name").ToString();
            txtPaymentCode.Text = CommonFun.SetDataRow(ref dr, "PaymentCode").ToString();
            txtUnit.Text = CommonFun.SetDataRow(ref dr, "Unit").ToString();
            txtUnitPrice_amt.Text = CommonFun.SetDataRow(ref dr, "UnitPrice_amt").ToString();
            txtLatestReceipt_nos.Text = CommonFun.SetDataRow(ref dr, "LatestReceipt_nos").ToString();
        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "找不到審查收入類別", "", "");
            Page.Response.Redirect("~/PAY/PAY4/PAY4101_01.aspx");
        }
    }
    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        string ExamineIncome_type = Page.Request.QueryString["ExamineIncome_type"].ToString();
        BindOne(ExamineIncome_type);
    }
}