// SAL2105	薪給發放清冊
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


public partial class SAL_SAL2_VB_Old_SAL2105_01 : BaseWebForm
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
        SAL2105 sal2105 = new SAL2105();
        // 相關參數
        string strPayoProno = ddl_PAYO_PRONO.SelectedValue;     // 人員類別
        string strPayoYyMm  = ddl_PAYO_YYMM.DateStr;            // 查詢畫面選擇之年月
        string strPayBudgeCode = ddl_Budget_code.SelectedValue; // 查詢畫面選擇之預算來源代碼

        DataTable dt = sal2105.queryData(
            this.strOrgCode,
            strPayoProno, strPayoYyMm , strPayBudgeCode);
        if (dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2105.mht"), dt);
            rpt.ExportFileName = "薪給發放清冊";
            // 參數部分

            string[] strParams = new string[12];
            
            strParams[0] = Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = TextBox1.Text;//用途說明

            int sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               Double s = Convert.ToDouble( dt.Rows[i]["item008"]);
               sum += (int)s;
            }           

            if(sum.ToString().Length >0)
                strParams[4] = sum.ToString().Substring(sum.ToString().Length - 1, 1); //元
            if (sum.ToString().Length > 1)
                strParams[5] = sum.ToString().Substring(sum.ToString().Length - 2, 1); //十
            if (sum.ToString().Length > 2)
                strParams[6] = sum.ToString().Substring(sum.ToString().Length - 3, 1);//百
            if (sum.ToString().Length > 3)
                strParams[7] = sum.ToString().Substring(sum.ToString().Length - 4, 1); //千
            if (sum.ToString().Length > 4)
                strParams[8] = sum.ToString().Substring(sum.ToString().Length - 5, 1);//萬
            if (sum.ToString().Length > 5)
                strParams[9] = sum.ToString().Substring(sum.ToString().Length - 6, 1);//十
            if (sum.ToString().Length > 6)
                strParams[10] = sum.ToString().Substring(sum.ToString().Length - 7, 1);//百
            if (sum.ToString().Length > 7)
                strParams[11] = sum.ToString().Substring(sum.ToString().Length - 8, 1);//千

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