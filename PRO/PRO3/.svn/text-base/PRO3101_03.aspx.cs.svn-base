using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO3_PRO3101_03 : System.Web.UI.Page
{
    private PRO3101 dao = new PRO3101();
    protected void Page_Load(object sender, EventArgs e)
    {
        string OfficialNumber_id = Request.QueryString["OfficialNumber_id"].ToString();
        string Software_id = Request.QueryString["Software_id"].ToString();
        string last_dateSS = Request.QueryString["last_dateS"].ToString();
        string last_dateES = Request.QueryString["last_dateE"].ToString();
        string SoftwareUnit_name = Request.QueryString["SoftwareUnit_name"].ToString();
        string User_id = Request.QueryString["User_id"].ToString();
        string Unit_code = Request.QueryString["Unit_code"].ToString();
        string Software_name = Request.QueryString["Software_name"].ToString();
        string fee_amtS = Request.QueryString["fee_amtS"].ToString();
        string fee_amtE = Request.QueryString["fee_amtE"].ToString();
        string fee_amtL = Request.QueryString["fee_amtL"].ToString();
        string fee_amtM = Request.QueryString["fee_amtM"].ToString();
        string Order = Request.QueryString["Order"].ToString();
        DateTime last_dateS = DateTime.MinValue;
        DateTime last_dateE = DateTime.MinValue;
        if (!string.IsNullOrEmpty(last_dateSS))
        {
            last_dateS = CommonFun.getYYYMMDD(last_dateSS);
        }
        if (!string.IsNullOrEmpty(last_dateES))
        {
            last_dateE = CommonFun.getYYYMMDD(last_dateES);
        }

        Print(OfficialNumber_id, Software_id, last_dateS, last_dateE,
            SoftwareUnit_name, Unit_code, User_id, Software_name,
            fee_amtS, fee_amtE, fee_amtL, fee_amtM, Order);
    }

    private void Print(string OfficialNumber_id, string Software_id, DateTime Last_dateS, DateTime Last_dateE,
                                   string SoftwareUnit_name, string Unit_code, string User_id, string Software_name,
                                   string Fee_amtS, string Fee_amtE, string Fee_amtL, string Fee_amtM, string Orderby)
    {
        DataTable dt = dao.GetAll(OfficialNumber_id, Software_id, Last_dateS, Last_dateE,
            SoftwareUnit_name, Unit_code, User_id, Software_name,
            Fee_amtS, Fee_amtE, Fee_amtL, Fee_amtM, Orderby);

        //dt.Columns.Add("P3", typeof(System.String));

        CommonLib.DTReport1 theDTReport = default(CommonLib.DTReport1);
        string[] strParam = new string[6];
        //int maxpageRowcnt = 10;
        string maxpagecnt = "";

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
        strParam[3] = maxpagecnt; 


        theDTReport = new CommonLib.DTReport1(Server.MapPath("~/Report/PRO/PRO3101_02.mht"), dt);
        theDTReport.breakPage = "GroupId";
        theDTReport.Param = strParam;
        theDTReport.ExportFileName = "行政院環境保護署軟體盤點清冊";

        theDTReport.ExportToHTML(Server.MapPath("~/Report/PRO/PRO3101_02.mht"));

        dt.Dispose();

    }
}