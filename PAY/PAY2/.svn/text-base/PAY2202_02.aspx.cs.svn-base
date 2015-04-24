using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAY.Logic;

public partial class PAY_PAY2_PAY2202_02 : BaseWebForm
{
    PAY2202 dao = new PAY2202();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Receipt_dateS="";
        string Receipt_dateE="";
        string PayMode_type ="";
        string Payer_id="";
        string ExamineIncome_type="";
        Receipt_dateS = Request.QueryString["Receipt_dateS"];
        Receipt_dateE = Request.QueryString["Receipt_dateE"];
        PayMode_type = Request.QueryString["PayMode_type"];
        Payer_id = Request.QueryString["Payer_id"];
        ExamineIncome_type = Request.QueryString["ExamineIncome_type"];
        //ExamineIncome_type = Request.QueryString["ExamineIncome_type"];
        //if (string.IsNullOrEmpty(Request.QueryString["ExamineIncome_type"].ToString()))
            
        if (PayMode_type == "002")
        {
            ExamineIncome_type = "";
            Payer_id = "";
        }
        Print(Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
    }

    private void Print(string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
    {
        DataTable dt = dao.GetReportDataPrintType1(Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        if (dt != null && dt.Rows.Count > 0)
        {
            CommonLib.DTReport theDTReport = default(CommonLib.DTReport);
            string[] strParam = new string[2];
            strParam[0] = (DateTime.Now.Year - 1911).ToString().PadLeft(3, '0') + "/" + DateTime.Today.ToString("MM/dd");
            strParam[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);


            theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2202_02.mht"), dt);

            theDTReport.Param = strParam;
            theDTReport.ExportFileName = "收據列印";
            theDTReport.ExportToWord();
            dt.Dispose();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.QueryNothing, "", "PAY2202_01.aspx", "");
        }
    }
}