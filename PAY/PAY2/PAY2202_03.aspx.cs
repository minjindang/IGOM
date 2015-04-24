using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2202_03 : System.Web.UI.Page
{
    PAY2202 dao = new PAY2202();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Receipt_dateS = "";
        string Receipt_dateE = "";
        string PayMode_type = "";
        string Payer_id = "";
        string ExamineIncome_type = "";
        Receipt_dateS = Request.QueryString["Receipt_dateS"];
        Receipt_dateE = Request.QueryString["Receipt_dateE"];
        PayMode_type = Request.QueryString["PayMode_type"];
        Payer_id = Request.QueryString["Payer_id"];
        ExamineIncome_type = Request.QueryString["ExamineIncome_type"];
        string printType = Request.QueryString["printType"];//0:Html , 1:Excel
        Print(printType,Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
    }

    private void Print(string printType,string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
    {
        string ExamineIncome_name = "";
        DataTable dt = dao.GetReportDataPrintType2(Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        DataRow dr = dao.pemDAO.GetOne(ExamineIncome_type, LoginManager.OrgCode);

        if (dt != null && dt.Rows.Count > 0)
        {
            if (dr != null)
                ExamineIncome_name = dr["ExamineIncome_name"].ToString();

            if (ExamineIncome_type == "12-20")
                ExamineIncome_name = "新引擎、延用、延伸或修改及耐久性審查費";

            dt.DefaultView.Sort = "Receipt_date";
            dt = dt.DefaultView.ToTable();

            if (String.IsNullOrEmpty(Receipt_dateS))
                Receipt_dateS = dt.Rows[0]["Receipt_date"].ToString();

            if (String.IsNullOrEmpty(Receipt_dateE))
                Receipt_dateE = dt.Rows[dt.Rows.Count - 1]["Receipt_date"].ToString();

            foreach (DataRow r in dt.Rows)
                r["Receipt_date"] = FSC.Logic.DateTimeInfo.ToDisplay(r["Receipt_date"].ToString(), "", "/");
                        
            string[] strParam = new string[6];

            strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
            strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParam[2] = (ExamineIncome_type == "07-20" ? "新引擎、延用、延伸或修改及耐久性審查費" : ExamineIncome_name) + "明細表";
            strParam[3] = dt.Rows.Count.ToString();
            strParam[4] = FSC.Logic.DateTimeInfo.ToDisplay(Receipt_dateS, "", "/");
            strParam[5] = FSC.Logic.DateTimeInfo.ToDisplay(Receipt_dateE, "", "/");

            if ("0" == printType)
            {
                CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
                theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2202_03.mht"), dt);

                theDTReport.Param = strParam;
                theDTReport.ExportFileName = "審查證照收入明細表";
                theDTReport.ExportToWord();

            }
            else
            {
                CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
                theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2202_031.mht"), dt);
                theDTReport.Param = strParam;
                theDTReport.ExportFileName = "審查證照收入明細表";
                theDTReport.ExportToExcel();
            }
            dt.Dispose();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.QueryNothing, "", "PAY2202_01.aspx", "");
        }
    }
}