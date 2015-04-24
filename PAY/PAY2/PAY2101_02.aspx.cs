using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2101_02 : System.Web.UI.Page
{
    PAY2101 dao = new PAY2101();

    protected void Page_Load(object sender, EventArgs e)
    {
        string FiscalYear_id = Request.QueryString["FiscalYear_id"].ToString();
        string PCList_idS = Request.QueryString["PCList_idS"].ToString();
        string PCList_idE = Request.QueryString["PCList_idE"].ToString();

        Print(FiscalYear_id, PCList_idS, PCList_idE);
    }

    private void Print(string FiscalYear_id, string PCList_idS, string PCList_idE)
    {
        DataTable dt = dao.GetReportData(FiscalYear_id, PCList_idS, PCList_idE);
        if (dt.Rows.Count > 0)
        {
            CommonLib.DTReport theDTReport = default(CommonLib.DTReport);//
            string[] strParam = new string[4];

            strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
            strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParam[2] = PCList_idS;
            strParam[3] = PCList_idE;

            theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2101_02.mht"), dt);

            theDTReport.Param = strParam;
            theDTReport.ExportFileName = "零用金清單";
            theDTReport.PageGroupKeyColumns = new string[] { "LastBalances_amt", "PayBalances_amt", "CurrentBalances_amt", "Income_amt" };
            theDTReport.PageGroupColumns = new string[] { "LastBalances_amt", "PayBalances_amt", "CurrentBalances_amt", "Income_amt" };
            theDTReport.ExportToWord();

            dt.Dispose();
        }
        else
        {
            string msg = string.Empty;
            msg = "查無資料!!";
            Page p = Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "PAY2101_01.aspx", "");
        }

    }
}