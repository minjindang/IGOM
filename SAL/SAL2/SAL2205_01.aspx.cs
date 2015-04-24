﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using SALPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

// SAL2205	差旅費請領發放清冊
public partial class SAL_SAL2_SAL2205_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string flow_id = "" + Request["flow_id"];
        SAL2205 sal2205 = new SAL2205();
        DataTable dt = sal2205.queryData(flow_id);
        //Response.Write(dt.Rows.Count.ToString());

        if (dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2205.mht"), dt);
            rpt.ExportFileName = "結婚生育及喪葬補助費發放清冊";
            // 參數部分

            string[] strParams = new string[4];
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = "結婚生育及喪葬補助費發放清冊";//頁次



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