using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2103_02 : System.Web.UI.Page
{
    PAY2103 dao = new PAY2103();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Bank_id = Server.HtmlDecode(Request.QueryString["Bank_id"].ToString());
        string Beneficiary_name = Server.HtmlDecode(Request.QueryString["Beneficiary_name"].ToString());
        Print(Bank_id, Beneficiary_name);
    }

    private void Print(string Bank_id, string Beneficiary_name)
    {
        DataTable dt = dao.GetReportData(Bank_id, Beneficiary_name);

        if(dt==null ||dt.Rows.Count<=0)
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.QueryNothing, "", "", "");
            this.Page = p;
        }

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


        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2103_01.mht"), dt);
        theDTReport.Param = strParam;
        theDTReport.ExportFileName = "受款人明細表";
        theDTReport.ExportToWord();
        dt.Dispose();

    }
}