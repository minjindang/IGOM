/*
 * 2014/3/15
 * Eliot Chen
 * 與上月薪資發放比較
 */
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



public partial class SAL_SAL2_SAL2111 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        UcDate1.DateStr = DateTime.Now.ToString("yyyyMM");
    }

    // 列印按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }


    // 製作報表
    private void ExportReport()
    {
        // new SAL2111
        SAL2111 sal2111 = new SAL2111();
        // 取得輸入條件
        // 登入者機關代碼
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        // 臨時人員代碼 ?
        string strProNO = "";
        strProNO = cmb_uc_UserType.SelectedValue;
        if (strProNO == "ALL")
            strProNO = "";
        /*
        // 先帶 空白
        if (cmb_uc_UserType.SelectedValue == "007")
        {
            strProNO = "007";
        }
         */
        // 預算代碼
        string strBudgeCode = cmbBudget.SelectedValue;
        // 年月
        string strYesrSelected = UcDate1.DateStr.Substring(0,4).ToString();//  .Year.ToString();
        string strMonthSelected = String.Format("{0:00}", Convert.ToInt16(UcDate1.DateStr.Substring(4,2).ToString()));

        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime dt = DateTime.ParseExact(strYesrSelected + strMonthSelected + "01", "yyyyMMdd", culture);
        DateTime dtLastMonth = dt.AddMonths(-1);
        //Response.Write(dt.ToString() + "<BR>" + dtLastMonth.ToString());
        string strYearMonthSelect = String.Format("{0:yyyyMM}", dt);
        string strYearMonthLast = String.Format("{0:yyyyMM}", dtLastMonth);

        // 實際取得資料
        // 目前表格中無資料無法測試
        DataTable datat =
            sal2111.queryReportData(strYearMonthLast, strYearMonthSelect, strProNO, strBudgeCode, strOrgCode);
        //GridView1.DataSource = datat;
        //GridView1.DataBind();

        if (datat != null && datat.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;    
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2111.mht"), datat);
            //modify 7.27
            //rpt.ExportFileName = "與上月薪資發放比較表";
            rpt.ExportFileName = "薪津異動清單";
            // 參數部分
            string[] strParams = new string[5];
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;

            rpt.Param = strParams;
            rpt.ExportToExcel();
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
        
    }
}