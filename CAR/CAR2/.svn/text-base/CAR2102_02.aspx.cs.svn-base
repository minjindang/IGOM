using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAR.Logic;

public partial class CAR_CAR2_CAR2102_02 : BaseWebForm
{
    Car2102 dao = new Car2102();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Start_date = Request.QueryString["Start_date"].ToString();
        string End_date = Request.QueryString["End_date"].ToString();
        string pageCount = Request.QueryString["pageCount"].ToString();
        string type = Request.QueryString["type"].ToString();

        Print(type,Start_date, End_date, pageCount);
    }

    private void Print(string reportType,string Start_date, string End_date, string PageCount)
    {
        DataTable dt = dao.GetReportData(reportType, Start_date, End_date);

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
        string[] strParam = new string[6];

        if (dt != null && dt.Rows.Count > 0)
        {
            double totalHours = Convert.ToDouble(dt.Compute("Sum(Hours)", ""));
            double totalUSAGE = Convert.ToDouble(dt.Compute("Sum(Usage)", ""));
            double totalCounts = Convert.ToDouble(dt.Compute("Sum(Count)", ""));
            double totalCARS = Convert.ToDouble(dt.Compute("Sum(CARS)", ""));
            int pareamter = Convert.ToInt16(dao.saCode.GetData("015", "010").Rows[0]["CODE_NO"]);
            double days = (CommonFun.getYYYMMDD(Start_date) - CommonFun.getYYYMMDD(End_date)).TotalDays;

            strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd"); //製表日期
            strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);//製表人
            strParam[2] = (totalHours * totalCARS).ToString();//總使用時數=(13*查詢條件選擇天數)*車輛數
            strParam[3] =( totalUSAGE * totalCARS).ToString();//總使用率=使用時數/(總使用時數*車輛數)
            strParam[4] = totalCounts.ToString();// 總使用次數
            strParam[5] = reportType == "0" ? "車輛名稱" : "部門";//類別

            theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/CAR/CAR2102_01.mht"), dt);
            theDTReport.Param = strParam;
            theDTReport.ExportFileName = "派車統計報表";
            theDTReport.ExportToWord();

            dt.Dispose();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.QueryNothing, "", "CAR2102_01.aspx", "");
        }
    }
}