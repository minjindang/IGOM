using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2201_02 : System.Web.UI.Page
{
    PAY2201 dao = new PAY2201();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Receipt_dateS = Request.QueryString["Receipt_dateS"].ToString();
        string Receipt_dateE = Request.QueryString["Receipt_dateE"].ToString();
        string PayMode_type = Request.QueryString["PayMode_type"].ToString();
        string Order = Request.QueryString["Order"].ToString();
        Print(Receipt_dateS, Receipt_dateE, PayMode_type, Order);
    }

    private void Print(string Receipt_dateS, string Receipt_dateE, string PayMode_type,string Order)
    {
        DataTable dt = dao.GetReportData(Receipt_dateS, Receipt_dateE, PayMode_type, Order);

        dt.Columns.Add("P3", typeof(System.String));

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
        string[] strParam = new string[8];
        int maxpageRowcnt = 15;
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
        strParam[5] = FSC.Logic.DateTimeInfo.ToDisplay(Receipt_dateS, "", "/");
        strParam[6] = FSC.Logic.DateTimeInfo.ToDisplay(Receipt_dateE, "", "/");
        strParam[7] = dt.Compute("Sum(Total)","").ToString();


        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2201_01.mht"), dt);
        theDTReport.Param = strParam;
        theDTReport.ExportFileName = "歲入彙計表";
        theDTReport.ExportToWord();

        dt.Dispose();

    }

}