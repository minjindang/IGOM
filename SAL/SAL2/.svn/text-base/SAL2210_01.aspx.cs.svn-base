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

// SAL2210	差旅費請領發放清冊
public partial class SAL_SAL2_SAL2210_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string flow_id = "" + Request["flow_id"];
        SAL2210 sal2210 = new SAL2210();
        DataTable dt = sal2210.queryData(flow_id);
        //Response.Write(dt.Rows.Count.ToString());

        if (dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2210_01.mht"), dt);
            rpt.ExportFileName = "未休假加班費發放清冊";
            // 參數部分
            dt.Columns.Add(new DataColumn("day"));
            dt.Columns.Add(new DataColumn("hour")); 

            foreach (DataRow dr in dt.Rows)
            {
                dr["day"] = dr["Pay_days"].ToString().Split('.')[0];
                if (dr["Pay_days"].ToString().IndexOf(".") >= 0)
                    dr["hour"] = dr["Pay_days"].ToString().Split('.')[1];
                else
                    dr["hour"] = "0";
            }


            string[] strParams = new string[5];
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName);
            strParams[3] = "未休假加班費發放清冊";
            strParams[4] =DateTime.Today.AddYears(-1911).Year.ToString();


            
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