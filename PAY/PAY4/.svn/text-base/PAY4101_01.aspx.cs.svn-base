using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY4_PAY4101_01 : BaseWebForm
{
    private PAY4101 dao = new PAY4101();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindExamineIncome_type();
        }

    }

    private void BindExamineIncome_type()
    {
        this.ddlExamineIncome_type.DataSource = dao.peimDAO.GetAll("",false);
        ddlExamineIncome_type.DataTextField = "ExamineIncome_name";
        ddlExamineIncome_type.DataValueField = "ExamineIncome_type";
        ddlExamineIncome_type.DataBind();
        ddlExamineIncome_type.Items.Insert(0, new ListItem("--請選擇--", ""));
    } 

    protected void GridViewA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ExamineIncome_type = e.CommandArgument.ToString();
        if (e.CommandName == "Maintain")
        {
            Page.Response.Redirect(String.Format("~/PAY/PAY4/PAY4101_03.aspx?ExamineIncome_type={0}", ExamineIncome_type));
        }
        else if (e.CommandName == "GoDelete")
        {
            string msg = dao.Remove(ExamineIncome_type);
            if (string.IsNullOrEmpty(msg))
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.DeleteOK, "", "", "");
                BindGV();
            }
            else
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }
        }

    }

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/PAY/PAY4/PAY4101_02.aspx");
    }

    protected void QryBtn_Click(object sender, EventArgs e)
    {
        BindGV();
    }

    private void BindGV()
    {
        string msg = string.Empty;
        DataTable dt = dao.GetAll(ddlExamineIncome_type.SelectedValue, ref msg);
        if (string.IsNullOrEmpty(msg))
        {
            div1.Visible = dt != null && dt.Rows.Count > 0;
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose();
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

    protected void GridViewA_PageIndexChanged(object sender, EventArgs e)
    {
        BindGV();
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        //GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        //GridViewA.DataBind();
    }

    protected void ddlExamineIncome_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtExamineIncome_type.Text = ddlExamineIncome_type.SelectedValue;
    }
}