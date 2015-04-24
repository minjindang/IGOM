using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSCPLM.Logic;

public partial class MAI_MAI4_MAI4101_03 : BaseWebForm
{
    private MAI4101 dao = new MAI4101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindcblMtItem_type("001");
            
            string MaintainerPhone_nos = Page.Request.QueryString["MaintainerPhone_nos"].ToString();
            BindOne(MaintainerPhone_nos);
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

    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;

        if (string.IsNullOrEmpty(ucDept.SelectedValue))
        {
            msg += @"請選擇維修人員單位\n";
        }

        if (string.IsNullOrEmpty(ucMember.SelectedValue))
        {
            msg += @"請選擇維修人員\n";
        }

        if (string.IsNullOrEmpty(txtMaintainerPhone_nos.Text))
        {
            msg += @"請輸入維修人員聯絡電話(分機)\n";
        }

        if (cblMtItem_type.Items.Cast<ListItem>()
                           .Where(a => a.Selected).Count() == 0)
        {
            msg += @"請選擇負責維修項目\n";
        }

        if (string.IsNullOrEmpty(msg))
        {
            string mtItemTypes = cblMtItem_type.Items.Cast<ListItem>()
                           .Where(a => a.Selected)
                           .Select(i => i.Value)
                           .Aggregate((i, j) => i + ";" + j);
            msg = dao.Modify(txtMaintainerPhone_nos.Text, ucMember.SelectedItem.Text, ucMaintain_type.Code_no, mtItemTypes, ucDept.SelectedValue, ucMember.SelectedValue);

            if (string.IsNullOrEmpty(msg))
            {
                Page.Response.Redirect("~/MAI/MAI4/MAI4101_01.aspx");
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

    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        string MaintainerPhone_nos = Page.Request.QueryString["MaintainerPhone_nos"].ToString();
        BindOne(MaintainerPhone_nos);
    }

    protected void ucDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucMember.DepartId = ucDept.SelectedValue;
        ucMember.Orgcode = LoginManager.OrgCode;
    }

    private void BindOne(string MaintainerPhone_nos)
    
    {
        DataRow dr = dao.mmDAO.GetOne(MaintainerPhone_nos, LoginManager.OrgCode);
        if (dr != null)
        {
            ucDept.Orgcode = LoginManager.OrgCode;
            ucDept.SelectedValue = CommonFun.SetDataRow(ref dr, "MtUnit_code").ToString();
            //ucDept.SubDepartId = CommonFun.SetDataRow(ref dr, "MtUnit_code").ToString();
            ucMember.Orgcode = LoginManager.OrgCode;
            ucMember.DepartId = ucDept.SelectedValue;
            //ucMember.SelectedValue = CommonFun.SetDataRow(ref dr, "MtUser_id").ToString();
            txtMaintainerPhone_nos.Text = MaintainerPhone_nos;
           
            ucMaintain_type.Code_no = CommonFun.SetDataRow(ref dr, "Maintain_type").ToString();
            BindcblMtItem_type(CommonFun.SetDataRow(ref dr, "Maintain_type").ToString());
            string[] itemTypes = CommonFun.SetDataRow(ref dr, "MtItem_type").ToString().Split(';');
            
            foreach (ListItem  item in cblMtItem_type.Items)
            {
                item.Selected = itemTypes.Contains(item.Value);
            }

        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "找不到維修人員資料", "", "");
            Page.Response.Redirect("~/MAI/MAI4/MAI4101_01.aspx");
        }
    }
}