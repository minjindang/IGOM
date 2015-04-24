using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using SALPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public partial class SAL_SAL2_SAL2118 : System.Web.UI.Page
{
    private string strOrgCode;// 登入者機關代碼
    protected void Page_Load(object sender, EventArgs e)
    {
        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

        cmb_uc_itemType.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(eventItemChanged);


        if (Page.IsPostBack) return;

 
    }

    // 項目類別改變
    protected void eventItemChanged(object sender, EventArgs e)
    {
        //Label1.Text = cmb_uc_SalItemType.Code_no;
        doSalItemChanged();
        // 選擇項目

    }

    private void doSalItemChanged()
    {
        // 項目的顯示與否
        if (cmb_uc_itemType.SelectedValue=="005")
        {
            lblItemName.Visible     = true;
            cmbOtherItems.Visible   = true;
        }
        else
        {
            lblItemName.Visible     = false;
            cmbOtherItems.Visible   = false;
        }

        getITems();

        // 更新 其他 Panel
        upnl_OtherItems.Update();
        upnl_OtherItemLabel.Update();
    }

    private void getITems()
    {
        SAL2118 sal2118 = new SAL2118();
        // 查詢項目名稱
        DataTable dt =
            sal2118.queryItemTypes(this.strOrgCode);
        if (dt != null)
        {
            cmbOtherItems.DataSource = dt;
            cmbOtherItems.DataTextField = "ITEM_NAME";
            cmbOtherItems.DataValueField    = "INCO_KIND_CODE";
            cmbOtherItems.DataBind();
        }

    }


    protected void Button_report_Click(object sender, EventArgs e)
    {
        // 參數
        string strIncoCode      = cmb_uc_itemType.SelectedValue;     // '查詢畫面之發放種類代碼'
        string strIncoTypeCode  = cmbOtherItems.SelectedValue; // '查詢畫面之項目代碼'
        string strIncoDate      = ucDatePay.Text;           // '查詢畫面之發放日期' 
        string strBaseName      = txtUserName.Text.Trim();     // '查詢畫面之姓名'
        string strBaseSeqNO     = txtUserNO.Text.Trim();    // '查詢畫面之員工編號' 
        string strBaseProNo     = cmb_uc_UserType.SelectedValue;// '查詢畫面之員工類別'
        string strBaseDep = cmb_uc_Org.OrgCode; // '查詢畫面之單位' 

        // 錯誤判斷
        string strErrMsg = "";
        if (strIncoDate == "")
        {
            strErrMsg += "請輸入發放日期";
        }
        if (strBaseProNo == "")
        {
            if (strErrMsg != "") strErrMsg += ",";
            strErrMsg += "請選擇員工類別";
        }
        if (strBaseDep == "")
        {
            if (strErrMsg != "") strErrMsg += ",";
            strErrMsg += "請選擇單位別";
        }

        if (strErrMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, strErrMsg , "", "");
            this.Page = tempPage;
            return;
        }

        // 日期
        int iDate=Convert.ToInt32(strIncoDate);
        iDate += 19110000;
        strIncoDate = Convert.ToString(iDate);

        // 查詢資料
        SAL2118 sal2118 = new SAL2118();
        DataTable datat =
             sal2118.queryReportData(
             this.strOrgCode,
                    strIncoCode, // '查詢畫面之發放種類代碼'
        strIncoTypeCode,// '查詢畫面之項目代碼'
        strIncoDate,// '查詢畫面之發放日期' 
        strBaseName,// '查詢畫面之姓名'
        strBaseSeqNO,// '查詢畫面之員工編號' 
        strBaseProNo,// '查詢畫面之員工類別'
        strBaseDep
             );

        if (datat != null && datat.Rows.Count > 0)
        {
            /*
            // 匯出動作
            CommonLib.DTReport rpt;

            // 目前還沒有這個報表檔案

            // 先 MARK
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL2111.mht"), datat);
            rpt.ExportFileName = "與上月薪資發放比較";
            // 參數部分
            string[] ary_params = { "TEST" };
            rpt.Param = ary_params;
            rpt.ExportToExcel();
             * */
            // 直接匯出 CSV
            // 檔頭
            string strExport = "";
            string strLine = "";
            for (int i = 0; i < datat.Columns.Count; i++)
            {
                if (strLine != "") strLine += ",";
                strLine += "\""+ datat.Columns[i].Caption +"\"";
            }
            strExport += strLine;

            for (int i=0;i<datat.Rows.Count; i++)
            {
                strLine = "";
                for (int j = 0; j < datat.Columns.Count ; j++)
                {
                    if (strLine != "") strLine += ",";
                    strLine += "\"" + datat.Rows[i][datat.Columns[j].Caption].ToString()+ "\"";
                }
                strExport += Environment.NewLine + strLine;
            }
            
            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment; filename=" + "員工所得扣繳資料查詢" + ".csv");
            Response.HeaderEncoding = System.Text.Encoding.GetEncoding("big5");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");
            Response.Write(strExport);
            Response.End();
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmb_uc_Org.ParentId = "";
        txtUserName.Text = "";
        cmb_uc_UserType.Rebind();
        txtUserNO.Text = "";
        cmb_uc_itemType.Rebind();
        cmbOtherItems.Items.Clear();
        ucDatePay.Text = "";
    }
}