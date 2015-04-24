using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1101_02 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string Cost_date = HttpUtility.UrlDecode(Request.QueryString["Cost_date"].ToString());
        string Flow_id = HttpUtility.UrlDecode(Request.QueryString["Flow_id"].ToString());
        string Apply_desc = HttpUtility.UrlDecode(Request.QueryString["Apply_desc"].ToString());
        string Apply_amt = HttpUtility.UrlDecode(Request.QueryString["Apply_amt"].ToString());

        Print(Cost_date, Flow_id, Apply_desc, Apply_amt);
    }

    private void Print(string Cost_date, string Flow_id, string Apply_desc,string Apply_amt)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("Cost_date"));
        dt.Columns.Add(new DataColumn("Flow_id"));
        dt.Columns.Add(new DataColumn("Apply_desc"));
        dt.Columns.Add(new DataColumn("HundredMillion"));
        dt.Columns.Add(new DataColumn("TenMillion"));
        dt.Columns.Add(new DataColumn("Million"));
        dt.Columns.Add(new DataColumn("HundredThousand"));
        dt.Columns.Add(new DataColumn("TenThousand"));
        dt.Columns.Add(new DataColumn("Thousand"));
        dt.Columns.Add(new DataColumn("Hundred"));
        dt.Columns.Add(new DataColumn("Ten"));
        dt.Columns.Add(new DataColumn("Unit"));

        Apply_amt = ("$" + Apply_amt).PadLeft(9, ' ');

        DataRow dr = dt.NewRow();
        dr["Cost_date"] = Cost_date;
        dr["Flow_id"] = Flow_id;
        dr["Apply_desc"] = Apply_desc;
        dr["HundredMillion"] = Apply_amt.Substring(0,1);
        dr["TenMillion"] = Apply_amt.Substring(1, 1);
        dr["Million"] = Apply_amt.Substring(2, 1);
        dr["HundredThousand"] = Apply_amt.Substring(3, 1);
        dr["TenThousand"] = Apply_amt.Substring(4, 1);
        dr["Thousand"] = Apply_amt.Substring(5, 1);
        dr["Hundred"] = Apply_amt.Substring(6, 1);
        dr["Ten"] = Apply_amt.Substring(7, 1);
        dr["Unit"] = Apply_amt.Substring(8, 1);

        dt.Rows.Add(dr);

        CommonLib.DTReport theDTReport = default(CommonLib.DTReport);       
        theDTReport = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL1101_01.mht"), dt);
        //theDTReport.breakPage = "Cost_date"; 
        theDTReport.ExportFileName = "支出憑證黏存單";
        theDTReport.ExportToWord();

        dt.Dispose();

    }
}