using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO1_PRO1102_01 : BaseWebForm
{
    PRO1102 dao = new PRO1102();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
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

            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                ShowReSendData();
                this.DoneBtn .Text = "確認"; 
            } 
        }
    }

    private void ShowReSendData()
    {
        DataTable dt = dao.GetDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);

        if (dt != null && dt.Rows.Count > 0)
        { 
            ViewState["CurrentTable"] = dt; 
            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();             
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

    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FA01_MASTNO"));
        dt.Columns.Add(new DataColumn("FA01_CLSNO"));
        dt.Columns.Add(new DataColumn("FA01_NAME"));
        dt.Columns.Add(new DataColumn("FA01_KIND"));
        dt.Columns.Add(new DataColumn("FA01_LOCATION"));
        dt.Columns.Add(new DataColumn("FA02_RANGE"));
        dt.Columns.Add(new DataColumn("FA01_BUYDT"));
        dt.Columns.Add(new DataColumn("FA02_DELDT"));
        foreach (GridViewRow gr in GridViewA.Rows)
        {
            CheckBox cbLendPetty = (CheckBox)gr.FindControl("cbox");

            if (cbLendPetty.Checked)
            {
                DataRow dr = dt.NewRow();
                HiddenField hfFA01_MASTNO = (HiddenField)gr.FindControl("hfFA01_MASTNO");
                HiddenField hfFA01_CLSNO = (HiddenField)gr.FindControl("hfFA01_CLSNO");
                HiddenField hfFA01_NAME = (HiddenField)gr.FindControl("hfFA01_NAME");
                HiddenField hfFA01_KIND = (HiddenField)gr.FindControl("hfFA01_KIND");
                HiddenField hfFA01_LOCATION = (HiddenField)gr.FindControl("hfFA01_LOCATION");
                HiddenField hfFA02_RANGE = (HiddenField)gr.FindControl("hfFA02_RANGE");
                HiddenField hfFA01_BUYDT = (HiddenField)gr.FindControl("hfFA01_BUYDT");
                HiddenField hfFA02_DELDT = (HiddenField)gr.FindControl("hfFA02_DELDT");
                dr["FA01_MASTNO"] = hfFA01_MASTNO.Value;
                dr["FA01_CLSNO"] = hfFA01_CLSNO.Value;
                dr["FA01_NAME"] = hfFA01_NAME.Value;
                dr["FA01_KIND"] = hfFA01_KIND.Value;
                dr["FA01_LOCATION"] = hfFA01_LOCATION.Value;
                dr["FA02_RANGE"] = hfFA02_RANGE.Value;
                dr["FA01_BUYDT"] = hfFA01_BUYDT.Value;
                dr["FA02_DELDT"] = hfFA02_DELDT.Value;
                dt.Rows.Add(dr);
            }

        }

        if (dt == null || dt.Rows.Count == 0)
        {
            msg = "請至少選擇一筆資料";
        }

        if (string.IsNullOrEmpty(msg))
        {

            msg = dao.Scrapped(ref dt, ucScrapReason_type.Code_no, Request.QueryString["org"], Request.QueryString["fid"]);
            if (!string.IsNullOrEmpty(msg))
            {
                Page p = Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, @msg, "", "");
            }
            else
            {
                Bind(getStoreRooms());
                Page p = Page;
                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "修改完成", "", "");
                }
                else
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請完成", "", "");
                }
                
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
                msg += @"請選擇至少一筆保管單位\n";
            }
        }

        if (!string.IsNullOrEmpty(msg))
        {
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, @msg, "", "");
        }
        else
        {
            Bind(storeRooms);
        }
        
    }
}