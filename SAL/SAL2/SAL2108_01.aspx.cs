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

public partial class SAL_SAL2_SAL2108_01 : BaseWebForm
{
    private string strOrgCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        if (Page.IsPostBack) return;
        ddl_Budget_code.Orgid = strOrgCode;
        ddl_PAYO_YYMM.DateStr = DateTime.Now.ToString("yyyyMM");
    }


    protected void Button_report_Click(object sender, EventArgs e)
    {
        SAL2108 sal2108 = new SAL2108();
        // 相關參數
        string strPayoProno = ddl_PAYO_PRONO.SelectedValue;     // 人員類別
        string strPayoYyMm = ddl_PAYO_YYMM.DateStr;            // 查詢畫面選擇之年月
        string strPayBudgeCode = ddl_Budget_code.SelectedValue; // 查詢畫面選擇之預算來源代碼

        DataTable dt = sal2108.queryData(
            this.strOrgCode,
            strPayoProno, strPayoYyMm, strPayBudgeCode);
        if (dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2108.mht"), dt);
            rpt.ExportFileName = "年終工作獎金發放清冊";
            // 參數部分

            string[] strParams = new string[3];

            strParams[0] = Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次



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