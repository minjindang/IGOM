using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OTH.Logic;

public partial class OTH_OTH1_OTH1102_01 : BaseWebForm
{
    OTH1102 dao = new OTH1102();

    protected void ucApply_type_CodeChanged(object sender, EventArgs e)
    {
        if (ucApply_type.Code_no != "004")
        {
            txtApply_type_desc.Text = "";
        }
    } 

    protected void ucequipRoom_type_CodeChanged(object sender, EventArgs e)
    {
        if (ucequipRoom_type.Code_no != "003")
        {
            txtEquipRoom_Memo.Text = "";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            SetInitialRow(); 
        }

    } 

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("direction"));
        dt.Columns.Add(new DataColumn("resource_ip"));
        dt.Columns.Add(new DataColumn("goal_ip"));
        dt.Columns.Add(new DataColumn("reason"));
        dt.Rows.Add(dt.NewRow());
        ViewState["CurrentTable"] = dt;
        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        if ((ViewState["CurrentTable"] != null))
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    RadioButtonList rbldirection = (RadioButtonList)this.GridViewA.Rows[rowIndex].Cells[0].FindControl("rbldirection");
                    TextBox txtresource_ip = (TextBox)this.GridViewA.Rows[rowIndex].Cells[1].FindControl("txtresource_ip");
                    TextBox txtgoal_ip = (TextBox)this.GridViewA.Rows[rowIndex].Cells[2].FindControl("txtgoal_ip");
                    TextBox txtreason = (TextBox)this.GridViewA.Rows[rowIndex].Cells[3].FindControl("txtreason");
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["direction"] = rbldirection.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["resource_ip"] = txtresource_ip.Text;
                    dtCurrentTable.Rows[i - 1]["goal_ip"] = txtgoal_ip.Text;
                    dtCurrentTable.Rows[i - 1]["reason"] = txtreason.Text;
                    rowIndex = rowIndex + 1;

                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                this.GridViewA.DataSource = dtCurrentTable;
                this.GridViewA.DataBind();


            }
        }
    }

    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        GridViewRow gr = (GridViewRow)(((Button)sender).NamingContainer);
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        
        dtCurrentTable.Rows.RemoveAt(gr.RowIndex);
        for (int i = 0; i <= dtCurrentTable.Rows.Count - 1; i++)
        {
            dtCurrentTable.Rows[i]["Index"] = i + 1;
        }
        ViewState["CurrentTable"] = dtCurrentTable;
        this.GridViewA.DataSource = dtCurrentTable;
        this.GridViewA.DataBind();

    }

    protected void OkBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        if (string.IsNullOrEmpty(this.ucApply_type.Code_no))
        {
            msg += @"請選擇申請類別\n";
        }
        if (string.IsNullOrEmpty(this.txtApply_reason.Text))
        {
            msg += @"請輸入申請事由\n";
        }
        if (ucApply_type.Code_no == "004" && string.IsNullOrEmpty(txtApply_type_desc.Text))
        {
            msg += @"請輸入申請類別-其它\n";
        }
        if (ucequipRoom_type.Code_no == "003" && string.IsNullOrEmpty(txtEquipRoom_Memo.Text))
        {
            msg += @"請輸入伺服器進機房-其它\n";
        }
        if (string.IsNullOrEmpty(msg))
        {
            if (this.GridViewA.Rows.Count > 0)
            {
                DataTable detailDT = new DataTable();
                detailDT.Columns.Add(new DataColumn("direction"));
                detailDT.Columns.Add(new DataColumn("resource_ip"));
                detailDT.Columns.Add(new DataColumn("goal_ip"));
                detailDT.Columns.Add(new DataColumn("reason"));
                foreach (GridViewRow gr in this.GridViewA.Rows)
                {
                    DataRow detailDR = detailDT.NewRow();
                    RadioButtonList rbldirection = (RadioButtonList)gr.Cells[0].FindControl("rbldirection");
                    TextBox txtresource_ip = (TextBox)gr.Cells[1].FindControl("txtresource_ip");
                    TextBox txtgoal_ip = (TextBox)gr.Cells[2].FindControl("txtgoal_ip");
                    TextBox txtreason = (TextBox)gr.Cells[3].FindControl("txtreason");
                    detailDR["direction"] = rbldirection.SelectedValue;
                    detailDR["resource_ip"] = txtresource_ip.Text;
                    detailDR["goal_ip"] = txtgoal_ip.Text;
                    detailDR["reason"] = txtreason.Text;
                    detailDT.Rows.Add(detailDR);
                }
                if (ucApply_type.Code_no != "004")
                {
                    txtApply_type_desc.Text = "";
                } 
                if (ucequipRoom_type.Code_no != "003")
                {
                    txtEquipRoom_Memo.Text = "";
                }
                msg = dao.Done(ucApply_type.Code_no, txtApply_type_desc.Text, txtApply_reason.Text, ucApply_StartDate.Text, ucApply_EndDate.Text,
                    ucapply_acc_req.Code_no, txtnewMac_addr.Text, txtchgMac_addr.Text, txtoldMac_addr.Text, ucequipRoom_type.Code_no, txtEquipRoom_Memo.Text,
                    txtdns_ip.Text, txtdns_host.Text, rblport_open.SelectedValue, txtadmin_sys.Text, ref detailDT);
                if (!string.IsNullOrEmpty(msg))
                {
                    Page page = this.Page;
                    CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, @msg, "", "");
                }
                else
                {
                    Response.Redirect("~/FSC/FSC0/FSC0101_01.aspx");
                }
            }
            else
            {
                Page page = this.Page;
                CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "至少要申請一筆", "", "");
            }
        }
        else
        {
            Page page = this.Page;
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, @msg, "", "");
        }
    }
}