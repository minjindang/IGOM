using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2104_02 : System.Web.UI.Page
{
    PAY2104 dao = new PAY2104();

    protected void Page_Load(object sender, EventArgs e)
    { 
        string PettyCash_nosS = Request.QueryString["PettyCash_nosS"].ToString();
        string PettyCash_nosE = Request.QueryString["PettyCash_nosE"].ToString();
        string Borrow_dateS = Request.QueryString["Borrow_dateS"].ToString();
        string Borrow_dateE = Request.QueryString["Borrow_dateE"].ToString();
        string Income_dateS = Request.QueryString["Income_dateS"].ToString();
        string Income_dateE = Request.QueryString["Income_dateE"].ToString();
        Print(PettyCash_nosS, PettyCash_nosE, Borrow_dateS, Borrow_dateE, Income_dateS, Income_dateE);
    }

    private void Print(string PettyCash_nosS, string PettyCash_nosE, string Borrow_dateS, string Borrow_dateE,
                                            string Income_dateS, string Income_dateE)
    {
        DataTable dt = dao.GetReportData(PettyCash_nosS, PettyCash_nosE, Borrow_dateS, Borrow_dateE, Income_dateS, Income_dateE);

        dt.Columns.Add("P3", typeof(System.String));

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
        string[] strParam = new string[8];
        int maxpageRowcnt = 25;
        string maxpagecnt = "";

        //取得總頁數
        if ((dt.Rows.Count % maxpageRowcnt) != 0)
        {
            maxpagecnt = (dt.Rows.Count / maxpageRowcnt + 1).ToString();
        }
        else
        {
            maxpagecnt = (dt.Rows.Count / maxpageRowcnt).ToString();
        }

        //取得分頁數P4
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            dt.Rows[i]["P3"] = (i / maxpageRowcnt) + 1;
        }

        dt.AcceptChanges();
        strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
        strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
        strParam[2] = "";
        strParam[3] = maxpagecnt;
        strParam[4] = dt.Compute("Sum(PurchaseTotalSIncome)", "").ToString();
        strParam[5] = dt.Compute("Sum(PurchaseTotalSIncome)", "").ToString();
        strParam[6] = string.Format("已回收{0}", dt.Compute("Sum(Income_amt)", "").ToString());


        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2104_01.mht"), dt);
        theDTReport.Param = strParam;
        theDTReport.ExportFileName = "零用金墊付明細表";
        theDTReport.ExportToWord();

        dt.Dispose();

    }
}