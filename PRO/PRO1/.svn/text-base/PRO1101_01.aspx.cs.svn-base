using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO1_PRO1101_01 : BaseWebForm
{
    PRO1101 dao = new PRO1101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucDept.Orgcode = LoginManager.OrgCode;
            DataTable dtStoreRoom = dao.GetSTOREROOM(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name));
            if (dtStoreRoom != null && dtStoreRoom.Rows.Count > 0)
            {
                cblStoreRoom.DataSource = dtStoreRoom;
                cblStoreRoom.DataTextField = "FA01_STOREROOM";
                cblStoreRoom.DataValueField = "FA01_STOREROOM";
                cblStoreRoom.DataBind();

                foreach (ListItem i in cblStoreRoom.Items)
                {
                    i.Selected = true;
                }

                //Bind(dtStoreRoom.Rows[0]["FA01_STOREROOM"].ToString());
            }
        }
    }

    private string getStoreRooms()
    {
        string storeRooms = string.Empty;
        if (cblStoreRoom.Items.Cast<ListItem>()
                          .Where(a => a.Selected).Count() > 0)
        {
            storeRooms = cblStoreRoom.Items.Cast<ListItem>()
                          .Where(a => a.Selected)
                          .Select(i => i.Value.Trim())
                          .Aggregate((i, j) => i + ";" + j);
        }
        return storeRooms;
    }

    private void Bind(string storeRoom)
    {
        if (!string.IsNullOrEmpty(tbCount.Text.Trim()) && !CommonFun.IsNum(tbCount.Text.Trim()))
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "查詢筆數請輸入數字!", "", "");
            return;
        }

        DataTable topDt = new DataTable();
        DataTable dt = dao.GetFAData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name), storeRoom);
        div1.Visible = dt != null && dt.Rows.Count > 0;

        if (!string.IsNullOrEmpty(tbCount.Text.Trim()))
        {
            topDt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < CommonFun.getInt(tbCount.Text.Trim()))
                {
                    topDt.ImportRow(dt.Rows[i]);
                }
            }

            this.GridViewA.DataSource = topDt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = topDt; //將資料暫存起來，做為資料的跳頁等顯示
        }
        else
        {
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = dt; //將資料暫存起來，做為資料的跳頁等顯示
            //dt.Dispose();
        }
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

    protected void ucDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucMember.DepartId = ucDept.SelectedValue;
        ucMember.Orgcode = LoginManager.OrgCode;
    }
    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        //if (string.IsNullOrEmpty(txtNewLocation.Text))
        //{
        //    msg += @"請輸入新放置地點\n";
        //}
        if (string.IsNullOrEmpty(ucMember.SelectedValue) && string.IsNullOrEmpty(ucDept.SelectedValue))
        {
            msg += @"請選擇新保管單位/保管人\n";
        }

        string NewKeeper_id = LoginManager.UserId;
        string NewKeeper_name = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
        string NewUnit_name = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName );
        if (!string.IsNullOrEmpty(ucMember.SelectedValue))
        {
            NewKeeper_id = ucMember.SelectedValue;
            NewKeeper_name = ucMember.SelectedItem.Text;
        }

        if (!string.IsNullOrEmpty(ucDept.SelectedValue))
        {
            NewUnit_name = ucDept.SelectedValue;
        }

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FA01_MASTNO"));
        dt.Columns.Add(new DataColumn("FA01_CLSNO"));
        dt.Columns.Add(new DataColumn("FA01_NAME"));
        dt.Columns.Add(new DataColumn("FA01_STOREROOM"));
        dt.Columns.Add(new DataColumn("FA01_ACCUSER"));
        dt.Columns.Add(new DataColumn("FA01_LOCATION"));
        dt.Columns.Add(new DataColumn("FA01_BUYDT"));
        dt.Columns.Add(new DataColumn("FA01_KIND"));
        foreach (GridViewRow gr in GridViewA.Rows)
        {
            CheckBox cbLendPetty = (CheckBox)gr.FindControl("cbox");

            if (cbLendPetty.Checked)
            {
                DataRow dr = dt.NewRow();
                HiddenField hfFA01_MASTNO = (HiddenField)gr.FindControl("hfFA01_MASTNO");
                HiddenField hfFA01_CLSNO = (HiddenField)gr.FindControl("hfFA01_CLSNO");
                HiddenField hfFA01_NAME = (HiddenField)gr.FindControl("hfFA01_NAME");
                HiddenField hfFA01_STOREROOM = (HiddenField)gr.FindControl("hfFA01_STOREROOM");
                HiddenField hfFA01_ACCUSER = (HiddenField)gr.FindControl("hfFA01_ACCUSER");
                HiddenField hfFA01_LOCATION = (HiddenField)gr.FindControl("hfFA01_LOCATION");
                HiddenField hfFA01_BUYDT = (HiddenField)gr.FindControl("hfFA01_BUYDT");
                HiddenField hfFA01_KIND = (HiddenField)gr.FindControl("hfFA01_KIND");
                dr["FA01_MASTNO"] = hfFA01_MASTNO.Value;
                dr["FA01_CLSNO"] = hfFA01_CLSNO.Value;
                dr["FA01_NAME"] = hfFA01_NAME.Value;
                dr["FA01_STOREROOM"] = hfFA01_STOREROOM.Value;
                dr["FA01_ACCUSER"] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                dr["FA01_LOCATION"] = hfFA01_LOCATION.Value;
                dr["FA01_BUYDT"] = hfFA01_BUYDT.Value;
                dr["FA01_KIND"] = hfFA01_KIND.Value;
                dt.Rows.Add(dr);
            }

        }

        if (dt == null || dt.Rows.Count == 0)
        {
            msg += @"請至少選擇一筆資料";
        }

        if (string.IsNullOrEmpty(msg))
        {

            msg = dao.Transfer(ref dt, NewUnit_name, NewKeeper_id, NewKeeper_name, txtNewLocation.Text);
            Page p = Page;
            if (!string.IsNullOrEmpty(msg))
            {
                
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }
            else
            {
                Bind(getStoreRooms());
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
            }

        }
        else
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }

    }
    protected void QryBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        string storeRooms = getStoreRooms();

        if (cblStoreRoom.Items.Count == 0)
        {
            msg += @"無屬於您的財產資料\n";
        }
        else
        {
            if (string.IsNullOrEmpty(storeRooms))
            {
                msg += @"請選擇至少一筆原保管單位\n";
            }
        }

        if (!string.IsNullOrEmpty(msg))
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
        else
        {
            Bind(storeRooms);
        }

    }
}