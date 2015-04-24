using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSCPLM.Logic;

public partial class MAI_MAI4_MAI4101_01 : BaseWebForm
{
    private MAI4101 dao = new MAI4101();

    protected void Page_Load(object sender, EventArgs e)
    {
        //string msg = string.Empty;
        //try
        //{
        //    dao.Get("", "", "", "", "", ref msg);

        //}
        //catch (Exception ex)
        //{
        //    Page p = Page;
        //    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
        //}
      
        if (!Page.IsPostBack)
        {
            BindcblMtItem_type("001");
            ucDept.Orgcode = LoginManager.OrgCode;

        }

    }
    protected void ucMaintain_type_CodeChanged(object sender, EventArgs e)
    {
        BindcblMtItem_type(ucMaintain_type.Code_no);
    }

    private void BindcblMtItem_type(string Maintain_type)
    {
        cblMtItem_type.DataSource = dao.GetMtItem_type(Maintain_type);
        cblMtItem_type.DataTextField = "CodeTitle";
        cblMtItem_type.DataValueField = "CodeValue";
        cblMtItem_type.DataBind();
    }

    protected void ucDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucMember.DepartId = ucDept.SelectedValue;
        ucMember.Orgcode = LoginManager.OrgCode;
    }

    protected void GridViewA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string MaintainerPhone_nos = e.CommandArgument.ToString();
        if (e.CommandName == "Maintain")
        {
            Page.Response.Redirect(String.Format("~/MAI/MAI4/MAI4101_03.aspx?MaintainerPhone_nos={0}", MaintainerPhone_nos));
        }
        else if (e.CommandName == "GoDelete")
        {
            string msg = dao.Remove(MaintainerPhone_nos);
            if (string.IsNullOrEmpty(msg))
            {
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
        Page.Response.Redirect("~/MAI/MAI4/MAI4101_02.aspx");
    }

    protected void QryBtn_Click(object sender, EventArgs e)
    {
        BindGV();
    }

    private void BindGV()
    {
        string mtItemTypes = string.Empty;
        if (cblMtItem_type.Items.Cast<ListItem>()
                          .Where(a => a.Selected).Count() > 0)
        {
            mtItemTypes = cblMtItem_type.Items.Cast<ListItem>()
                          .Where(a => a.Selected)
                          .Select(i => i.Value)
                          .Aggregate((i, j) => i + ";" + j);
        }
        string msg = string.Empty;
        DataTable dt = dao.Get(this.txtMaintainerPhone_nos.Text, ucMember.SelectedValue , ucMaintain_type.Code_no, mtItemTypes, ucDept.SelectedValue, ref msg);
        div1.Visible = dt != null && dt.Rows.Count > 0;

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
        ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose();
    }

    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
    }
    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    }
}