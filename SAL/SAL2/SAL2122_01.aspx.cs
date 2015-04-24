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


public partial class SAL_SAL2_SAL2122_01 : BaseWebForm
{

    private string strOrgCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        if (Page.IsPostBack) return;
        ddl_Budget_code.Orgid = strOrgCode;
        ddl_PAYO_YYMM.DateStr = DateTime.Now.ToString("yyyyMM");
        UcDateDropDownList1.DateStr = DateTime.Now.ToString("yyyyMM");
    }


    protected void Button_report_Click(object sender, EventArgs e)
    {
        SAL2122 sal2122 = new SAL2122();
        // 相關參數
        string ym2 = ddl_PAYO_YYMM.DateStr;   // 迄日    
        string ym1 = UcDateDropDownList1.DateStr; //起日
        string strPayBudgeCode = ddl_Budget_code.SelectedValue; // 查詢畫面選擇之預算來源代碼

        DataTable dt = sal2122.queryData(ym1, ym2, strPayBudgeCode);

        if (dt.Rows.Count > 0)
        {
            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2122.mht"), dt);
            rpt.ExportFileName = "已扣補充保費明細查詢";
            // 參數部分

            string[] strParams = new string[5];

            strParams[0] = (int.Parse(UcDateDropDownList1.DateStr.Substring(0, 4)) - 1911).ToString();//XXX年
            strParams[1] = dt.Rows.Count.ToString()+"筆";
            int sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum +=  Convert.ToInt32( dt.Rows[i]["inco_amt"]);
            }
            strParams[2] = sum.ToString();
            strParams[3] = (int.Parse(ym1) - 191100).ToString() + " ~ " + (int.Parse(ym2) - 191100).ToString();
            strParams[4] = Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
         
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        data();
    }
    protected void data()
    {
        SAL2122 sal2122 = new SAL2122();
        string ym1 = UcDateDropDownList1.DateStr; //起
        string ym2 = ddl_PAYO_YYMM.DateStr;   // 迄
        string strPayBudgeCode = ddl_Budget_code.SelectedValue; // 查詢畫面選擇之預算來源代碼
        DataTable dt = sal2122.queryData(ym1, ym2, strPayBudgeCode);

        tableGV1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();


        if (GridView1.Rows.Count > 0)
        {
            UcPager.Visible = true;
        }
        else
        {
            UcPager.Visible = false;
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        data();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
  /*      int sum = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            sum += int.Parse(GridView1.Rows[i].Cells[6].Text);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "綜計";
            e.Row.Cells[1].Text = GridView1.Rows.Count.ToString()+"筆";
            e.Row.Cells[5].Text = "0";
            e.Row.Cells[6].Text = sum.ToString();
        }
        */
    }
}