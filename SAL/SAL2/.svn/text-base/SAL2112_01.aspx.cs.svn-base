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

public partial class SAL_SAL2_SAL2112 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
    }

   
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }

    //匯出
    private void ExportReport()
    {        
        SAL2112 sal2112 = new SAL2112();
        string strbase_dep = ddltype.OrgCode;       //單位別　
        string strmane = txtname.Text;              //員工姓名
        string strBASE_SEX = BASE_SEX.SelectedValue;//姓別
        string strcno = ddlcno.SelectedValue;       //人員類別
        string strno = txtno.Text;                  //員工編號
        string strdate1 = UcDate1.Text;             //發放日期
        if (strdate1 != "")
            strdate1 = (int.Parse(strdate1) + 19110000).ToString();
        string strdate2 = UcDate2.Text;             //發放日期
        if (strdate2 != "")
            strdate2 = (int.Parse(strdate2) + 19110000).ToString();
        string strBudget_code = UcSaCode1.SelectedValue;//預算來源
        string strnum = txtnum.Text;                 //所得流水號



        DataTable datat = sal2112.queryReportData(strbase_dep, strmane, strBASE_SEX, strcno, strno, strdate1, strdate2, strBudget_code, strnum);

        if (datat != null && datat.Rows.Count > 0)
        {
            // 匯出
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2112.mht"), datat);
            rpt.ExportFileName = "年度發放獎金累計查詢";
            // 參數部分
            string[] strParams = new string[1];  //沒有title資料
            strParams[0] = "";
            rpt.Param = strParams;
            rpt.ExportToExcel();           
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
        
    }

}