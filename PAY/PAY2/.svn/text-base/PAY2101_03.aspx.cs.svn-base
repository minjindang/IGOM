using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2101_03 : System.Web.UI.Page
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
        DataTable tmp = dao.GetReportData2(FiscalYear_id, PCList_idS, PCList_idE);
        if (tmp.Rows.Count > 0)
        {
            DataView dv = tmp.DefaultView;
            dv.Sort = " Prepay_id desc , PettyCash_nos ";
            DataTable dt = dv.ToTable();
            dt.Columns.Add("Point");

            foreach (DataRow dr in dt.Rows)
            {
                dr["Point"] = string.IsNullOrEmpty(dr["Prepay_id"].ToString()) ? "" : "*";
            }

            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
            //dt.Columns.Add("P3", typeof(System.String));

            CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
            string[] strParam = new string[4];
            //int maxpageRowcnt = 10;
            //string maxpagecnt = "";

            ////取得總頁數
            //if ((dt.Rows.Count % maxpageRowcnt) != 0)
            //{
            //    maxpagecnt = (dt.Rows.Count / maxpageRowcnt + 1).ToString();
            //}
            //else
            //{
            //    maxpagecnt = (dt.Rows.Count / maxpageRowcnt).ToString();
            //}

            ////取得分頁數P4
            //for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //{
            //    dt.Rows[i]["P3"] = (i / maxpageRowcnt) + 1;
            //}

            //dt.AcceptChanges();
            strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
            strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParam[2] = "";
            strParam[3] = lastRow["groupid"].ToString();


            theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2101_03.mht"), dt);
            //theDTReport.breakPage = "groupid";
            theDTReport.Param = strParam;
            theDTReport.ExportFileName = "零用金墊付現今明細表備查簿";
            //theDTReport.PageGroupKeyColumns = new string[] { "LastBalances_amt", "PayBalances_amt", "CurrentBalances_amt", "Income_amt" };
            //theDTReport.PageGroupColumns = new string[] { "LastBalances_amt", "PayBalances_amt", "CurrentBalances_amt", "Income_amt" };
            theDTReport.ExportToWord();
            //theDTReport.ExportToHTML(Server.MapPath("~/Report/PAY/PAY2101_03.mht"));

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