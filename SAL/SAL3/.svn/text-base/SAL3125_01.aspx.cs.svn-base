using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using System.Collections;
using SALPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public partial class SAL_SAL3_SAL3125 : BaseWebForm
{

    private string strOrgCode;  // 登入者機關代碼

    private bool bDoAdj;

    private string strType;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        // Bind LoadComplete Event
        Page.LoadComplete += new EventHandler(Page_LoadComplete);

        try
        {
            //addHeaders();
        }
        catch
        {
        }


        if (Page.IsPostBack) return;

        strType = "";
        cmb_uc_YearMonth.DateStr = DateTime.Now.ToString("yyyyMM");
        txtMode.Text = "";
        pnlResult.Visible = false;
    }


    void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        bindYearData();
    }

    // 重新連結年份
    private void bindYearData()
    {
        /*
        Label1.Text = "bindYearData";
        DropDownList cmb = (DropDownList)cmb_uc_YearMonth.FindControl("ddlYear");
        if (cmb != null)
        {
            cmb.Items.Clear();

            ArrayList yearList = new ArrayList();

            for (int i = 1; i > -3; i--)
            {
                int iYear = DateTime.Now.Year - 1911 + i;
                ListItem litem = new ListItem();
                litem.Text = iYear.ToString();
                litem.Value = iYear.ToString().PadLeft(3, '0');
                yearList.Add(litem);
            }
            cmb.DataSource = yearList;
            cmb.DataBind();

            cmb.SelectedValue = (DateTime.Now.Year - 1911).ToString();

            //Label1.Text = "DataBind";
        }

        */

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        btnAdjOK.Visible = false;
        strType = "query";
        txtMode.Text = strType;
        gvResult.Columns[0].Visible = false;
        queryData();
        pnlResult.Visible = true;
        
    }

    protected void queryData()
    {

        SAL3125 sal3125 = new SAL3125();
        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dt = sal3125.querySalSaBase(strOrgCode, strEmployees, strYearMonth,"search");
      
  /*      dt.Columns.Add("ROWSEQ");
        // 健保需角
        dt.Columns.Add("NeedPay", typeof(Double));
        // 健保已繳
        dt.Columns.Add("PayedHealth", typeof(Double));
        // 勞保已繳
        dt.Columns.Add("PayedLabor", typeof(Double));
        
        // 其他欄位處理
        for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
            DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
            dt.Rows[iRow]["ROWSEQ"] = iRow + 1;
            string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
                  
            // 健保自付計算2
            Double iTemp = 0;
            for (int i = -2; i < 1; i++)
            {

                DateTime dt4Query = datetime4query.AddMonths(i);
                string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                iTemp +=
                    DAO.getHelthSelfShould1(
                    dt.Rows[iRow]["base_fin_amt"].ToString(),
                    dt.Rows[iRow]["base_fins_nol"].ToString(),
                    dt.Rows[iRow]["base_fins_noq"].ToString(),
                    dt.Rows[iRow]["base_fins_noh"].ToString(),
                    dt.Rows[iRow]["base_fins_nof"].ToString(),
                    dt.Rows[iRow]["base_fins_noq_nol"].ToString(),
                    dt.Rows[iRow]["base_fins_noh_nol"].ToString(),
                    dt.Rows[iRow]["base_fins_no"].ToString(),
                    strDT4Query
                    );
            }

            iTemp += DAO.getHelthSelfShould2(dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgCode);

            dt.Rows[iRow]["NeedPay"] = iTemp;//NeedPay

            string strDTNow = String.Format("{0:yyyyMM}", datetime4query);
            string strDT3Ago = String.Format("{0:yyyyMM}", datetime4query.AddMonths(-3));

            iTemp = DAO.getPaiedLabor(strDT3Ago, strDTNow, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgCode);
            dt.Rows[iRow]["PayedLabor"] = iTemp;
            iTemp = DAO.getPaiedHealth(strDT3Ago, strDTNow, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgCode);
            dt.Rows[iRow]["PayedHealth"] = iTemp;
        }
  */    

            gvResult.DataSource = dt;
            gvResult.DataBind();        

        if (gvResult.Rows.Count > 0)
        {
            Ucpager1.Visible = true;
        }
        else
        {
            Ucpager1.Visible = false;
        }
    }

    protected string stws_stand_002_New(string BASE_SEQNO)   // 新健保金額
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
       
        DataTable dtTemp = sal3125.queryStws002New(strDT4QueryStart,
            Convert.ToSingle(avg3Months(BASE_SEQNO)));
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            return dtTemp.Rows[0]["stws_stand"].ToString();
        }
    }

    protected string Stws_dct(string BASE_SEQNO)   // 新健保自付
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
     
        DataTable dtTemp = sal3125.queryStws002New(strDT4QueryStart,
            Convert.ToSingle(avg3Months(BASE_SEQNO)));
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "0";
        }
        else
        {          
           return dtTemp.Rows[0]["Stws_dct"].ToString();
        }
    }

    protected string STWS_LEVEL_002_New(string BASE_SEQNO)   // 新健保自付
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();

        DataTable dtTemp = sal3125.queryStws002New(strDT4QueryStart,
            Convert.ToSingle(avg3Months(BASE_SEQNO)));
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "";
        }
        else
        {
            return dtTemp.Rows[0]["STWS_LEVEL"].ToString();
        }
    }


    protected string stws_stand_002(string base_fins_series) // 舊健保金額
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
        DataTable dtTemp = sal3125.queryStws002(strDT4QueryStart, base_fins_series);
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
           return "0";
        }
        else
        {
            return dtTemp.Rows[0]["stws_stand"].ToString();
        }
    }

    protected string sum_payod_amt_001_001(string base_labor_status ,//新勞保自付
        string base_labor_series,
        string base_lab_jif, 
        string base_fins_self, 
        string BASE_BDATE, 
        string BASE_EDATE ,
        string base_lab1, 
        string base_lab2, 
        string base_lab3, 
        string base_fins_kind  ) 
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();

            int iSumPayodAmy002 = 0;
            for (int i = -2; i < 1; i++)
            {
                DateTime dt4Query = datetime4query.AddMonths(i);
                string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                DataTable dtTemp = sal3125.queryLaborInsuranceNewPayBySelf(
                   base_labor_status,
                   base_labor_series,
                    strDT4Query,
                    base_lab_jif,
                    base_fins_self,
                    BASE_BDATE,
                    BASE_EDATE,
                    "", "",
                    strOrgCode,
                    base_lab1,
                    base_lab2,
                    base_lab3,
                    base_fins_kind
                    );

                if (dtTemp.Rows.Count > 0)
                {
                    try
                    {
                        iSumPayodAmy002 +=  Convert.ToInt32(dtTemp.Rows[0]["rv"].ToString());
                    }
                    catch
                    {
                    }
                }

            }
           return iSumPayodAmy002.ToString();
    }

    protected string stws_stand_001_001(string BASE_SEQNO) // 新勞保金額
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
        // 新勞保金額
       DataTable dtTemp = sal3125.queryLaborInsuranceNew(strDT4QueryStart,
            Convert.ToSingle(avg3Months(BASE_SEQNO)));
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            return dtTemp.Rows[0]["stws_stand"].ToString();           
        }
    }

    protected string STWS_LEVEL_New(string BASE_SEQNO) //新勞保級距
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
        
        DataTable dtTemp = sal3125.queryLaborInsuranceNew(strDT4QueryStart,
             Convert.ToSingle(avg3Months(BASE_SEQNO)));
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "";
        }
        else
        {
            return  dtTemp.Rows[0]["STWS_LEVEL"].ToString();
        }
    }


    protected string sum_payod_amt_001(string BASE_SEQNO) // 舊勞保自付
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
        DataTable dtTemp = sal3125.queryLaborInsuranceOldPayBySelf(strDT4QueryStart, BASE_SEQNO, strOrgCode);
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
           return "0";
        }
        else
        {
            return dtTemp.Rows[0]["sum_payod_amt"].ToString();
        }
    }

    protected string stws_stand_001(string base_labor_series) //舊勞保金額
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);      
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        SAL3125 sal3125 = new SAL3125();
        // 舊勞保金額
        DataTable dtTemp = sal3125.queryLaborInsuranceOld(strDT4QueryStart, base_labor_series);
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            return dtTemp.Rows[0]["stws_stand"].ToString();
        }
    }

    protected string avg3Months(string Base_seqno) // 3各月平均薪資
    {       
       return Convert.ToString((int.Parse(sum_payod_amt_1(Base_seqno)) +
            int.Parse(sum_payod_amt_2(Base_seqno)) +
            int.Parse(sum_payod_amt_3(Base_seqno)) +
            int.Parse(sum_payod_amt_005_1(Base_seqno)) +
            int.Parse(sum_payod_amt_005_2(Base_seqno)) +
            int.Parse(sum_payod_amt_005_3(Base_seqno)) +
            int.Parse(sum_payod_amt_NoLeave(Base_seqno))) / 3);
    }

    protected string sum_payod_amt_NoLeave(string Base_seqno)//取得不休假加班費
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        // 不休假加班費
        // 開始年月
        string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
        // 結束年月
        DateTime dt4QueryEnd = datetime4query.AddMonths(2);
        string strDT4QueryEnd = String.Format("{0:yyyyMM}", dt4QueryEnd);

        DataTable dtTemp =
          sal3125.queryOverTimePayOfNoLeaveByYearMonth(strDT4QueryStart, strDT4QueryEnd, strOrgCode,Base_seqno);
        if (dtTemp == null || dtTemp.Rows.Count == 0)
        {
          return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtTemp.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        //    return dtTemp.Rows[0]["sum_payod_amt"].ToString();
        }

    }

    protected string sum_payod_amt_1(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = -2;
  
            DateTime dt4Query = datetime4query.AddMonths(i);
            string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

            DataTable dtSalary = sal3125.querySalaryByYearMonth(strDT4Query, strOrgCode, Base_seqno);
                
            if (dtSalary == null || dtSalary.Rows.Count == 0)
            {
                return "0";
            }
            else
            {
                int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
                return a.ToString();
            }         
    }

    protected string sum_payod_amt_2(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = -1;

        DateTime dt4Query = datetime4query.AddMonths(i);
        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

        DataTable dtSalary = sal3125.querySalaryByYearMonth(strDT4Query, strOrgCode, Base_seqno);

        if (dtSalary == null || dtSalary.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        }
    }

    protected string sum_payod_amt_3(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = 0;

        DateTime dt4Query = datetime4query.AddMonths(i);
        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

        DataTable dtSalary = sal3125.querySalaryByYearMonth(strDT4Query, strOrgCode, Base_seqno);

        if (dtSalary == null || dtSalary.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        }
    }

    protected string sum_payod_amt_005_1(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = -2;
        DateTime dt4Query = datetime4query.AddMonths(i);
        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

        DataTable dtSalary = sal3125.queryOverTimePayByYearMonth(strDT4Query, strOrgCode, Base_seqno);
    
        if (dtSalary == null || dtSalary.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        }   
    }

    protected string sum_payod_amt_005_2(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = -1;
        DateTime dt4Query = datetime4query.AddMonths(i);
        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

        DataTable dtSalary = sal3125.queryOverTimePayByYearMonth(strDT4Query, strOrgCode, Base_seqno);

        if (dtSalary == null || dtSalary.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        }
    }

    protected string sum_payod_amt_005_3(string Base_seqno)
    {
        string strYearMonth = cmb_uc_YearMonth.DateStr;
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        SAL3125 sal3125 = new SAL3125();
        int i = 0;
        DateTime dt4Query = datetime4query.AddMonths(i);
        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

        DataTable dtSalary = sal3125.queryOverTimePayByYearMonth(strDT4Query, strOrgCode, Base_seqno);

        if (dtSalary == null || dtSalary.Rows.Count == 0)
        {
            return "0";
        }
        else
        {
            int a = (int)(Convert.ToDouble(dtSalary.Rows[0]["sum_payod_amt"]));
            return a.ToString();
        }
    }


    /*
    private void addHeaders()
    {
        
        GridViewRow header = gvResult.HeaderRow;

        SortedList FormatCells = new SortedList();

        string strYearMonth = "";
        if (Page.IsPostBack)
        {
            strYearMonth =
                cmb_uc_YearMonth.DateStr;
            //                cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //               cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
        }
        else
        {
            strYearMonth = "200001";
        }
        IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);


        DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
        DateTime dt4Query = datetime4query.AddMonths(-2);
        string strDT4Query = String.Format("{0:MM}", dt4Query);

        if (gvResult.Columns[0].Visible)
        {
            FormatCells.Add("00", " ,1,2");
        }
        FormatCells.Add("01", "姓名,1,2");
        FormatCells.Add("02", strDT4Query + "月,2,1");
        dt4Query = dt4Query.AddMonths(1);
        strDT4Query = String.Format("{0:MM}", dt4Query);
        FormatCells.Add("03", strDT4Query + "月,2,1");
        dt4Query = dt4Query.AddMonths(1);
        strDT4Query = String.Format("{0:MM}", dt4Query);
        FormatCells.Add("04", strDT4Query + "月,2,1");
        FormatCells.Add("05", "不休假加班費,1,2");
        FormatCells.Add("06", "三個月平均工資,1,1");
        FormatCells.Add("07", "舊勞保,2,1");
        FormatCells.Add("08", "新勞保,2,1");
        FormatCells.Add("09", "舊健保,2,1");
        FormatCells.Add("10", "新健保,2,1");


        SortedList FormatCells2 = new SortedList();
        FormatCells2.Add("01", "薪資,1,1");
        FormatCells2.Add("02", "加班費,1,1");
        FormatCells2.Add("03", "薪資,1,1");
        FormatCells2.Add("04", "加班費,1,1");
        FormatCells2.Add("05", "薪資,1,1");
        FormatCells2.Add("06", "加班費,1,1");
        FormatCells2.Add("07", "投保金額,1,1");

        FormatCells2.Add("08", "投保金額,1,1");
        FormatCells2.Add("09", "自付額,1,1");
        FormatCells2.Add("10", "投保金額,1,1");
        FormatCells2.Add("11", "自付額,1,1");
        FormatCells2.Add("12", "投保金額,1,1");
        FormatCells2.Add("13", "自付額,1,1");
        FormatCells2.Add("14", "投保金額,1,1");
        FormatCells2.Add("15", "自付額,1,1");


        GetMultiRowHeader2(header, FormatCells2);
        GetMultiRowHeader2(header, FormatCells);


    }
    */

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
  /*      if (txtMode.Text == "query")
        {
            GridViewRow gvRow = e.Row;
            if (gvRow.RowType == DataControlRowType.Header)
            {
                SortedList FormatCells = new SortedList();

                string strYearMonth =
                   cmb_uc_YearMonth.DateStr;
                //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
                //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
                IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

                DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
                DateTime dt4Query = datetime4query.AddMonths(-2);
                string strDT4Query = String.Format("{0:MM}", dt4Query);

                if (gvResult.Columns[0].Visible)
                {
                    FormatCells.Add("00", " ,1,2");
                }
                FormatCells.Add("01", "姓名,1,2");
                FormatCells.Add("02", strDT4Query + "月,2,1");
                dt4Query = dt4Query.AddMonths(1);
                strDT4Query = String.Format("{0:MM}", dt4Query);
                FormatCells.Add("03", strDT4Query + "月,2,1");
                dt4Query = dt4Query.AddMonths(1);
                strDT4Query = String.Format("{0:MM}", dt4Query);
                FormatCells.Add("04", strDT4Query + "月,2,1");
                FormatCells.Add("05", "不休假加班費,1,2");
                FormatCells.Add("06", "三個月平均工資,1,1");
                FormatCells.Add("07", "舊勞保,2,1");
                FormatCells.Add("08", "新勞保,2,1");
                FormatCells.Add("09", "舊健保,2,1");
                FormatCells.Add("10", "新健保,2,1");


                SortedList FormatCells2 = new SortedList();
                FormatCells2.Add("01", "薪資,1,1");
                FormatCells2.Add("02", "加班費,1,1");
                FormatCells2.Add("03", "薪資,1,1");
                FormatCells2.Add("04", "加班費,1,1");
                FormatCells2.Add("05", "薪資,1,1");
                FormatCells2.Add("06", "加班費,1,1");
                FormatCells2.Add("07", "投保金額,1,1");

                FormatCells2.Add("08", "投保金額,1,1");
                FormatCells2.Add("09", "自付額,1,1");
                FormatCells2.Add("10", "投保金額,1,1");
                FormatCells2.Add("11", "自付額,1,1");
                FormatCells2.Add("12", "投保金額,1,1");
                FormatCells2.Add("13", "自付額,1,1");
                FormatCells2.Add("14", "投保金額,1,1");
                FormatCells2.Add("15", "自付額,1,1");

                GetMultiRowHeader(e, FormatCells2);
                GetMultiRowHeader(e, FormatCells);
            }

            //            Response.Write(gvResult.Rows.Count.ToString() + "<BR>");
        }

        */

    }

    public void GetMultiRowHeader(GridViewRowEventArgs e, SortedList GetCels)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = default(GridViewRow);
            IDictionaryEnumerator enumCels = GetCels.GetEnumerator();

            row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

            while (enumCels.MoveNext())
            {
                string[] count = enumCels.Value.ToString().Split(Convert.ToChar(","));
                TableCell Cell = default(TableCell);
                Cell = new TableCell();
                Cell.RowSpan = Convert.ToInt16(count[2].ToString());
                Cell.ColumnSpan = Convert.ToInt16(count[1].ToString());
                Cell.Controls.Add(new LiteralControl(count[0].ToString()));
                Cell.HorizontalAlign = HorizontalAlign.Center;
                Cell.CssClass = "Grid th";
                //                Cell.ForeColor = System.Drawing.Color.White;
                row.Cells.Add(Cell);
            }

            e.Row.Parent.Controls.AddAt(0, row);
        }
    }

    public void GetMultiRowHeader2(GridViewRow header, SortedList GetCels)
    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        GridViewRow row = default(GridViewRow);
        IDictionaryEnumerator enumCels = GetCels.GetEnumerator();

        row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

        while (enumCels.MoveNext())
        {
            string[] count = enumCels.Value.ToString().Split(Convert.ToChar(","));
            TableCell Cell = default(TableCell);
            Cell = new TableCell();
            Cell.RowSpan = Convert.ToInt16(count[2].ToString());
            Cell.ColumnSpan = Convert.ToInt16(count[1].ToString());
            Cell.Controls.Add(new LiteralControl(count[0].ToString()));
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.CssClass = "Grid th";
            //                Cell.ForeColor = System.DrabtnPrint_Clickwing.Color.White;
            row.Cells.Add(Cell);
        }

        header.Parent.Controls.AddAt(0, row);
    }
    //    }


    protected void btnAdjust_Click(object sender, EventArgs e)
    {
        strType = "Adj";
        txtMode.Text = strType;
        gvResult.Columns[0].Visible = true;
        queryData();
        btnAdjOK.Visible = true;
        pnlResult.Visible = true;

    }
    protected void btnAdjOK_Click(object sender, EventArgs e)
    {
        btnAdjOK.Visible = false;
        //gvResult.DataBind();
        //        bDoAdj = true;
     
        doAdjustData();

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "調整完成", "", "");
        this.Page = tempPage;

        
        gvResult.Columns[0].Visible = false;
        strType = "query";
        txtMode.Text = strType;
        // 重新讀取
        queryData();       

    }

    private void doAdjustData()
    {
        //        gvResult.DataBind();
        //gvResult.c
        int iAdj = 0;
        for (int i = 0; i < gvResult.Rows.Count; i++)
        {
            GridViewRow gvRow = gvResult.Rows[i];


            if (gvRow.RowType == DataControlRowType.Header)
            {
                //                Response.Write(i.ToString() + ":" + gvResult.Rows[i].Cells[1].ToString());
            }
            else
            {
                //Response.Write(i.ToString() + "<BR>");
                CheckBox chk = (CheckBox)gvResult.Rows[i].FindControl("chkSelect");
                if (chk != null)
                {
                    //                    Response.Write(i.ToString() + "/" + chk.Checked.ToString() + "<BR>");
                    if (chk.Checked)
                    {
                        //iAdj++;

                        SAL3125 sal3125 = new SAL3125();

                        Label lblBaseSeqNO          = (Label)gvResult.Rows[i].FindControl("lbl_BASE_SEQNO");
                        Label lblBase_labor_series  = (Label)gvResult.Rows[i].FindControl("lbl_STWS_LEVEL_New");
                        Label lblBase_fins_series = (Label)gvResult.Rows[i].FindControl("lbl_STWS_LEVEL_002_New");

                        string strBaseSeqNO = lblBaseSeqNO.Text;// gvResult.Rows[i].Cells[1].Text.ToString();    // 人員代號
                        string strBase_labor_series = lblBase_labor_series.Text;// gvResult.Rows[i].Cells[2].Text.ToString();      //新勞保級距
                        string strBase_fins_series = lblBase_fins_series.Text;// gvResult.Rows[i].Cells[3].Text.ToString();      // 新健保級距
                        //Response.Write(gvResult.Rows[i].Cells[20].Text.ToString());
                       /*
                        Response.Write(
                            i.ToString()+","+strBaseSeqNO+","+
                            strBase_labor_series+","+
                            strBase_fins_series+"<BR>"
                            );
                        * */


                        Label lblfBase_fins_amt = (Label)gvResult.Rows[i].FindControl("lbl_Stws_dct");
                        Single fBase_fins_amt = Convert.ToSingle(lblfBase_fins_amt.Text);//gvResult.Rows[i].Cells[20].Text.ToString());
                        Label lbl_stws_stand_002_New = (Label)gvResult.Rows[i].FindControl("lbl_stws_stand_002_New");
                        Single fstws_stand_002_New = Convert.ToSingle(lbl_stws_stand_002_New.Text);
                        sal3125.doAdjestSaBase(
                            this.strOrgCode,
                            strBaseSeqNO, strBase_labor_series, strBase_fins_series, fBase_fins_amt, fstws_stand_002_New

                            );
                        //                        Response.Write(gvResult.Rows[i].Cells[20].Text.ToString() + "<BR>");
                    }
                }
            }

        }      
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        pnlResult.Visible = false;
        if (cmbReportType.SelectedValue == "001")
        {
            doPrintType001();
        }
        else if (cmbReportType.SelectedValue == "002")
        {
        doPrintType002();
        }
        else if (cmbReportType.SelectedValue == "003")
        {
            doPrintType003();
        }
        else if (cmbReportType.SelectedValue == "004")
        {
            doPrintType004();
        }
        else if (cmbReportType.SelectedValue == "005")
        {
            doPrintType005();
        }

        //doPrintType001();
        //doPrintType002();
        //doPrintType003();
//        doPrintType004();
//        doPrintType005();

    }

    private void doPrintType005()
    {
        SAL3125 sal3125 = new SAL3125();

        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dtTemp = sal3125.querySalSaBase(strOrgCode, strEmployees, strYearMonth,"print");

        DataRow[] drs = dtTemp.Select("sum_payod_amt_001_001<PayedLabor OR NeedPay<PayedHealth");
        DataTable dt = dtTemp.Clone();
        foreach (DataRow d in drs)
        {
            dt.ImportRow(d);
        }
        Response.Write(dt.Rows.Count.ToString() + "<BR>");
        if (dt != null && dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3125_03.mht"), dt);
            rpt.ExportFileName = "退回勞健保及眷屬健保費自付差額明細表";
            // 參數部分
            string[] strParams = new string[0];
//            strParams[0] = "退回";
            // 參數部分
            /*
            string[] strParams = new string[3];

            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            strParams[0] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[1] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[2] = String.Format("{0:MM}", dt4Query) + "月";

            /*
            
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;
             */

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

        /*
        Response.Write(dt2.Rows.Count.ToString() + "<BR>");
        dt.Select("Stws_dct>PayedLabor OR PayedHealth>NeedPay");
        DataTable dt3 = dt.Clone();
        foreach (DataRow d in drs)
        {
            dt3.ImportRow(d);
        }
        Response.Write(dt3.Rows.Count);
         */
    }


    private void doPrintType004()
    {
        SAL3125 sal3125 = new SAL3125();

        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dtTemp = sal3125.querySalSaBase(strOrgCode, strEmployees, strYearMonth, "print");

        DataRow[] drs = dtTemp.Select("sum_payod_amt_001_001>PayedLabor OR NeedPay>PayedHealth");
        DataTable dt = dtTemp.Clone();
        foreach (DataRow d in drs)
        {
            dt.ImportRow(d);
        }
        Response.Write(dt.Rows.Count.ToString() + "<BR>");
        if (dt != null && dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3125_03.mht"), dt);
            rpt.ExportFileName = "補收勞健保及眷屬健保費自付差額明細表";
            // 參數部分
            string[] strParams = new string[0];
//            strParams[0] = "補收";

            /*
            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            strParams[0] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[1] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[2] = String.Format("{0:MM}", dt4Query) + "月";

            /*
            
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;
             */

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

        /*
        Response.Write(dt2.Rows.Count.ToString() + "<BR>");
        dt.Select("Stws_dct>PayedLabor OR PayedHealth>NeedPay");
        DataTable dt3 = dt.Clone();
        foreach (DataRow d in drs)
        {
            dt3.ImportRow(d);
        }
        Response.Write(dt3.Rows.Count);
         */
    }

    private void doPrintType002()
    {
        SAL3125 sal3125 = new SAL3125();

        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dt = sal3125.queryUpandDown1(strOrgCode, strEmployees, strYearMonth, 1);
        if (dt != null && dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3125_02.mht"), dt);
            rpt.ExportFileName = "調昇勞健保投保金額明細表";
            // 參數部分
            string[] strParams = new string[6];

            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            strParams[0] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[1] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[2] = String.Format("{0:MM}", dt4Query) + "月";
            strParams[3] = String.Format("{0:yyyy}", dt4Query);
            strParams[4] = String.Format("{0:MM}", dt4Query);
            strParams[5] = "調昇";

            /*
            
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;
             */

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

    private void doPrintType003()
    {
        SAL3125 sal3125 = new SAL3125();

        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dt = sal3125.queryUpandDown1(strOrgCode, strEmployees, strYearMonth, 2);
        if (dt != null && dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3125_02.mht"), dt);
            rpt.ExportFileName = "調降勞健保投保金額明細表";

            // 參數部分
            string[] strParams = new string[6];

            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            strParams[0] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[1] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[2] = String.Format("{0:MM}", dt4Query) + "月";
            strParams[3] = String.Format("{0:yyyy}", dt4Query) ;
            strParams[4] = String.Format("{0:MM}", dt4Query);
            strParams[5] = "調降";
            /*
            
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;
             */

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


    private void doPrintType001()
    {
        SAL3125 sal3125 = new SAL3125();

        // 相關參數
        string strEmployees = cmb_uc_EmployeeType.SelectedValue;
        string strYearMonth = cmb_uc_YearMonth.DateStr;

        DataTable dt = sal3125.querySalSaBase(strOrgCode, strEmployees, strYearMonth,"print");
        if (dt != null && dt.Rows.Count > 0)
        {

            // 匯出動作
            CommonLib.DTReport rpt;
            rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3125_01.mht"), dt);
            rpt.ExportFileName = "勞健保投保金額調整計算表";
            // 參數部分
//            string[] strParams = new string[0];
            string[] strParams = new string[3];

            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            strParams[0] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[1] = String.Format("{0:MM}", dt4Query) + "月";
            dt4Query = dt4Query.AddMonths(1);
            strParams[2] = String.Format("{0:MM}", dt4Query) + "月";
            //strParams[3] = String.Format("{0:yyyy}", dt4Query);
            /*
            
            strParams[0] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
            strParams[1] = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            strParams[2] = "";//頁次
            strParams[3] = strYearMonthLast;
            strParams[4] = strYearMonthSelect;
             */

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

    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
        /*
        gvResult.Columns[1].Visible = true;
        gvResult.Columns[2].Visible = true;
        gvResult.Columns[3].Visible = true;
         */

//        Response.Write(DateTime.Now.ToString("yyyyMMddhhmmss") + " :gvResult_DataBinding<br>");
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
//        gvResult.Columns[1].Visible = false;
//        gvResult.Columns[2].Visible = false;
//        gvResult.Columns[3].Visible = false;

//        Response.Write(DateTime.Now.ToString("yyyyMMddhhmmss") + " :gvResult_DataBound<br>");
        if (gvResult.Rows.Count > 0)
        {
            string strYearMonthDis =
               cmb_uc_YearMonth.DateStr;
            //                    cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
            //                   cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
            IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);

            DateTime datetime4query = DateTime.ParseExact(strYearMonthDis + "01", "yyyyMMdd", culture);
            DateTime dt4Query = datetime4query.AddMonths(-2);
            Label head1 = (Label)gvResult.HeaderRow.FindControl("lbheader1");
            head1.Text = String.Format("{0:MM}", dt4Query) + "月";

            Label head2 = (Label)gvResult.HeaderRow.FindControl("lbheader2");
            dt4Query = dt4Query.AddMonths(1);
            head2.Text = String.Format("{0:MM}", dt4Query) + "月";

            Label head3 = (Label)gvResult.HeaderRow.FindControl("lbheader3");
            dt4Query = dt4Query.AddMonths(1);
            head3.Text = String.Format("{0:MM}", dt4Query) + "月";
        }
     

    }
 
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvResult.Rows.Count; i++)
        {
            GridViewRow gvRow = gvResult.Rows[i];
            if (gvRow.RowType == DataControlRowType.Header)
            {
               
            }
            else
            {
                //Response.Write(i.ToString() + "<BR>");
                CheckBox chk = (CheckBox)gvResult.Rows[i].FindControl("chkSelect");
                CheckBox chk2 = (CheckBox)gvResult.HeaderRow.FindControl("chkAll");
                chk.Checked =  chk2.Checked;
            }
        }
    }

    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        queryData();
    }
}