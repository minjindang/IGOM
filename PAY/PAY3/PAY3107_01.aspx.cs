using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY3_PAY3107_01 : BaseWebForm
{
    PAY3107 dao = new PAY3107();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucReceive_date.Text = CommonFun.getYYYMMDD();
            Bind();
        }
    }

    private void Bind()
    {
        GridViewA.DataSource = dao.GetPettyList();
        GridViewA.DataBind();

        string yearInitialamt = dao.GetYearInitial_amt();
        txtYearInitial_amt.Enabled = string.IsNullOrEmpty(yearInitialamt);
        txtYearInitial_amt.Text = yearInitialamt;
        this.lblBroughtForward_amt.Text = dao.pay3103.GetLastBalances_amt(LoginManager.OrgCode, (DateTime.Now.Year - 1911).ToString()).ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string msg = string.Empty ;
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("PettyCashInventory_id"));
        dt.Columns.Add(new DataColumn("PaymentVoucher_id"));
        dt.Columns.Add(new DataColumn("Income_amt"));
        dt.Columns.Add(new DataColumn("Memo"));
        int Balances_amt = 0;
        bool chk = false;
        foreach (GridViewRow gr in GridViewA.Rows)
        {
            CheckBox cbLendPetty = (CheckBox)gr.FindControl("CheckBox1");
            
            if (cbLendPetty.Checked)
            {
                chk = true;
                DataRow dr = dt.NewRow();
                TextBox txtIncome_amt = (TextBox)gr.FindControl("txtIncome_amt");
                TextBox txtMemo = (TextBox)gr.FindControl("txtMemo");
                if (string.IsNullOrEmpty(txtIncome_amt.Text))
                {
                    msg = @"收入金額不得為空\n";
                    break;
                }
                dr["PettyCashInventory_id"] = gr.Cells[2].Text;
                dr["PaymentVoucher_id"] = gr.Cells[3].Text;
                dr["Income_amt"] = Convert.ToInt32(txtIncome_amt.Text);
                dr["Memo"] = txtMemo.Text;
                dt.Rows.Add(dr);
                Balances_amt += Convert.ToInt32(txtIncome_amt.Text);
            }

        }

        if (!chk)
        {
            if(string.IsNullOrEmpty(txtYearInitial_amt.Text))
                msg = "請輸入年度初始撥入金額";
            else
                msg = "請至少勾選一筆清單";
        }

        if (string.IsNullOrEmpty(msg))
        {
           
            msg = dao.Done((DateTime.Now.Year - 1911).ToString(), ucReceive_date.Text, Convert.ToInt32(lblBroughtForward_amt.Text), Convert.ToInt32(txtYearInitial_amt.Text),Balances_amt, ref dt);
            if (!string.IsNullOrEmpty(msg))
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }
            else
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, string.Format("零用金撥入成功, 目前結存金額為：{0}",Balances_amt),"", "");
                //btnSave.Enabled = false;
                //btnClr.Enabled = false;
                Bind();
            }
            
        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {
        MasterPage p = Master;
        CommonFun.ClearContentPlaceHolder(ref p);
    }
}