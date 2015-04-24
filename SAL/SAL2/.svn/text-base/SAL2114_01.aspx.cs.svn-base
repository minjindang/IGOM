/*
 * 2014/3/17
 * ted
 * 所得額統計表
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



public partial class SAL_SAL2_SAL2114 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    { 

        if (Page.IsPostBack) return;
        //年份,民國=西元-1911,增加今年-2至今年+1年 
        string Year = DateTime.Now.ToString("yyyy");
        DropDownList_Year.Items.Clear();
        DropDownList_Year.Items.Add((int.Parse(Year) - 1913).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1912).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1911).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1910).ToString());
      
    }

    // 列印按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }


    // 製作報表
    private void ExportReport()
    {     
        SAL2114 sal2114 = new SAL2114();

        if (DropDownList_Month.SelectedIndex == 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇月份", "", "");
            this.Page = tempPage;
            return;
        }

        //登入者機關代碼
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        //年份(西元+1911)
        string strYearSelected = (int.Parse(DropDownList_Year.SelectedValue) + 1911).ToString();        
        //月份
        string strMonthSelected = DropDownList_Month.SelectedValue.ToString();  
        //排序  
        int strSort = ddlsort.SelectedIndex;

        DataTable datat = sal2114.queryReportData(strYearSelected, strMonthSelected, strSort, strOrgCode);//年,月,排序,登入者機關代碼
   //   Response.Write(strYearSelected + strMonthSelected+strSort);
        if (datat == null || datat.Rows.Count == 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;

            return;
        }

        // 匯出動作
        CommonLib.DTReport rpt;  
        rpt=new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2114.mht"),datat);
        rpt.ExportFileName = "所得額統計表";
        // 參數部分
        string[] strParams = new string[7];
        strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
        int INCO_CNT = 0;
        int INCO_AMT = 0;
        int INCO_KDC_AMT = 0;
        int INCO_REPL_AMT = 0;
        int INCO_HOUS_AMT = 0;
        int INCO_TAX = 0; 
        for(int i=0; i<datat.Rows.Count;i++)
        {
            INCO_CNT += int.Parse(datat.Rows[i]["INCO_CNT"].ToString());
            INCO_AMT += int.Parse(datat.Rows[i]["INCO_AMT"].ToString());
            INCO_KDC_AMT += int.Parse(datat.Rows[i]["INCO_KDC_AMT"].ToString());
            INCO_REPL_AMT += int.Parse(datat.Rows[i]["INCO_REPL_AMT"].ToString());
            INCO_HOUS_AMT += int.Parse(datat.Rows[i]["INCO_HOUS_AMT"].ToString());
            INCO_TAX += int.Parse(datat.Rows[i]["INCO_TAX"].ToString());
        }

        strParams[1] = INCO_CNT.ToString();
        strParams[2] = INCO_AMT.ToString();
        strParams[3] = INCO_KDC_AMT.ToString();
        strParams[4] = INCO_REPL_AMT.ToString();
        strParams[5] = INCO_HOUS_AMT.ToString();
        strParams[6] = INCO_TAX.ToString();
        rpt.Param = strParams;
        rpt.ExportToExcel();
       
    }
}