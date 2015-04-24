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

// SAL2209	環保志工服務費發放清冊
public partial class SAL_SAL2_SAL2209_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string flow_id = "" + Request["flow_id"];
        SAL2209 sal2209 = new SAL2209();
        DataTable dt = sal2209.queryData(flow_id);
        //Response.Write(dt.Rows.Count.ToString());

        if (dt.Rows.Count > 0)
        {
            int sum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sum = sum + Convert.ToInt32(dr["Apply_amt"].ToString());
            }

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2209.mht"), dt);
            rpt.ExportFileName = "環保志工服務費發放清冊";
            // 參數部分

            string[] strParams = new string[5];
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName);
            strParams[3] = "環保志工服務費發放清冊";
            strParams[4] = Convert.ToString(sum);


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