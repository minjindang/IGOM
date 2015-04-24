using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Text;
using System.Collections;

public partial class MAI3101_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        cblKind.DataSource = code.GetData("020", "**");
        cblKind.DataBind();

        UcDDLAuthorityDepart.Orgcode = LoginManager.OrgCode;
        BindMember();

        if (LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) == "1")
            tr3.Visible = false;
    }
    
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Page p = this.Page;
        ArrayList kindList = new ArrayList();
        foreach (ListItem item in cblKind.Items)
        {
            if (item.Selected)
                kindList.Add(item.Value);
        }
        if (kindList.Count <= 0)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請類別至少勾選一項", "", "");
            return;
        }
        Bind();
    }
    protected void Bind()
    { 
        MAI.Logic.MAI3101 bll = new MAI.Logic.MAI3101();
        String orgcode = LoginManager.OrgCode;

        ArrayList kindList = new ArrayList();
        foreach (ListItem item in cblKind.Items)
        {
            if(item.Selected)
                kindList.Add(item.Value);
        }
        DataTable dt = bll.GetDataByQuery(orgcode, kindList, UcDateS.Text, UcDateE.Text, tbExt.Text, UcDDLAuthorityMember.SelectedValue , UcDDLAuthorityDepart.SelectedValue);

        ViewState["dt"] = dt;
        gvlist.DataSource = dt;
        gvlist.DataBind();

        tbq.Visible = gvlist.Rows.Count > 0;
        btnExport.Enabled = gvlist.Rows.Count > 0;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dt"];
        IWorkbook wb = new HSSFWorkbook();
        ISheet ws = wb.CreateSheet("報修紀錄");

        HSSFCellStyle borderStyle = null;
        borderStyle = (HSSFCellStyle)wb.CreateCellStyle();

        borderStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        borderStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        borderStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        borderStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;


        ws.CreateRow(0);//第一行為欄位名稱

        int colIndex = 0;
        foreach (ListItem item in cblColumn.Items)
        {
            if(item.Selected)
            {
                HSSFCell cell = (HSSFCell) ws.GetRow(0).CreateCell(colIndex);
                cell.SetCellValue(item.Text);
                cell.CellStyle = borderStyle;
                colIndex += 1;
            }
        }

        colIndex = 0;
        int rowIndex = 1;
        foreach (DataRow dr in dt.Rows)
        {
            ws.CreateRow(rowIndex);

            foreach (ListItem item in cblColumn.Items)
            {
                if(item.Selected)
                {
                    String val = dr[item.Value].ToString();

                    HSSFCell cell = (HSSFCell)ws.GetRow(rowIndex).CreateCell(colIndex);
                    cell.SetCellValue(val);
                    cell.CellStyle = borderStyle;

                    ws.AutoSizeColumn(colIndex);//自動調整欄位寬度
                    colIndex += 1;
                }
            }
            rowIndex += 1;
            colIndex = 0;
        }


        String fileName = Guid.NewGuid().ToString();
        FileStream file = new FileStream(Server.MapPath("~/Report/ExcelTemp/") + fileName + ".xls", FileMode.Create);//產生檔案
        wb.Write(file);
        file.Close();

        //建立檔案輸入串流物件 
        Byte[] buf = System.IO.File.ReadAllBytes(Server.MapPath("~/Report/ExcelTemp/") + fileName + ".xls");
        
        //刪除暫存檔
        File.Delete(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") + fileName + ".xls");

        Response.Clear();
        Response.HeaderEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("報修紀錄查詢", Encoding.UTF8) + ".xls");
        Response.ContentType = "Application/octet-stream";
        Response.ClearContent();
        Response.BinaryWrite(buf);

    }

    protected void lbtFlow_id_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
        String Orgcode  = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        String flow_id = ((LinkButton)sender).Text;
        Response.Redirect("../../FSC/FSC0/FSC0101_10.aspx?org=" + Orgcode + "&fid=" + flow_id);
    }
    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlist.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void cbColAll_CheckedChanged(object sender, EventArgs e)
    {
        bool chk = cbColAll.Checked;
        foreach (ListItem item in cblColumn.Items)
            item.Selected = chk;
    }
    protected void cbKindAll_CheckedChanged(object sender, EventArgs e)
    {
        bool chk = cbKindAll.Checked;
        foreach (ListItem item in cblKind.Items)
            item.Selected = chk;
    }
    protected void UcDDLAuthorityDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMember();
    }
    protected void BindMember()
    {
        UcDDLAuthorityMember.Orgcode = LoginManager.OrgCode;
        UcDDLAuthorityMember.Depart_id = UcDDLAuthorityDepart.SelectedValue;
    }
}
