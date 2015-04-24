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

public partial class SAL_SAL2_SAL2116_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼

    protected void Page_Load(object sender, EventArgs e)
    {
        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        // Bind LoadComplete Event
        Page.LoadComplete += new EventHandler(Page_LoadComplete);

        // User Control Event Binder
        cmb_uc_ItemType.ReturnEvent = true;
        cmb_uc_ItemType.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(ItemChanged);

        if (Page.IsPostBack) return;

        cmb_uc_YearMonth.DateStr = DateTime.Now.ToString("yyyyMM");
    }

    // 第二步項目類別改變
    protected void ItemChanged(object sender, EventArgs e)
    {
        //Label1.Text = cmb_uc_SalItemType.Code_no;
        doItemChanged();
        // 選擇項目

    }

    private void doItemChanged()
    {
        SAL2116 sal2116 = new SAL2116();
        // 參數
        string strItemType = cmb_uc_ItemType.SelectedValue;
        DataTable dt = sal2116.querySalItemName(this.strOrgCode, strItemType);
        cmb_ItemName.Items.Clear();
        cmb_ItemName.DataSource = dt;
        cmb_ItemName.DataTextField = "item_name";
        cmb_ItemName.DataValueField = "item_code";
        cmb_ItemName.DataBind();

    }




    void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        bindYearData();
    }

    // 重新連結年份
    private void bindYearData()
    {
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
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (cmb_uc_PayType.SelectedValue == "005")
        {
            pnlStep2.Visible = true;
            upnlStep2.Update();
        }
        else
        {
            pnlStep3.Visible = true;
            upnlStep3.Update();
            gotoStep3();
        }

        pnlStep1.Visible = false;

    }


    protected void Button3_Click(object sender, EventArgs e)
    {

        pnlStep3.Visible = true;
        pnlStep2.Visible = false;
        upnlStep3.Update();

        gotoStep3();
    }

    private void queryPayDates()
    {
        SAL2116 sal2116 = new SAL2116();
        // 參數
        string strIncoCode = cmb_uc_PayType.SelectedValue;
        string strIncoYM = cmb_uc_YearMonth.DateStr;

        //           cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //           cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
        string strIncoKindCode = cmb_ItemName.SelectedValue;
        // 項目名稱代碼 

        DataTable dt = sal2116.queryIncoDate(this.strOrgCode, strIncoCode, strIncoYM, strIncoKindCode);

        cmbDateStep3.Items.Clear();
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem itm = new ListItem();
                itm.Value = dt.Rows[i]["INCO_DATE"].ToString();
                itm.Text = "民國 " +
                    Convert.ToString(
                    Convert.ToInt16(
                    dt.Rows[i]["INCO_DATE"].ToString().Substring(0, 4)) - 1911)

                    + " 年 " + dt.Rows[i]["INCO_DATE"].ToString().Substring(4, 2) + " 月";
                cmbDateStep3.Items.Add(itm);
            }

        }

        btnStep3Next.Enabled = cmbDateStep3.Items.Count > 0;


    }

    private void gotoStep3()
    {
        queryPayDates();
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        // 到 Step 5
        pnlStep5.Visible = true;
        pnlStep4.Visible = false;
        upnlStep5.Update();
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        pnlStep4.Visible = true;
        pnlStep3.Visible = false;
        upnlStep4.Update();

    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        doQueryReport();
    }

    private void doQueryReport()
    {
        SAL2116 sal2116 = new SAL2116();
        // 參數
        string strIncoCode = cmb_uc_PayType.SelectedValue;
        string strIncoYM =
            cmb_uc_YearMonth.DateStr;
        //            cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //            cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');
        string strIncoKindCode = cmb_ItemName.SelectedValue;
        string strIncoDate = cmbDateStep3.SelectedValue;//'查詢畫面第三步之發放日期'
        string strBaseProNo = cmb_uc_EmpType.SelectedValue;// '查詢畫面第四步之人員類別代碼(code_no)'
        string strIncoBudGeCode = cmb_uc_BudgeSource.SelectedValue;//'查詢畫面第四步之預算來源代碼(code_no)'
        string strIncoICode = cmb_uc_SalaryType.SelectedValue;//'查詢畫面第四步之所得類別代碼(code_no)'

        // 項目名稱代碼 


        DataTable dt = sal2116.queryReport(this.strOrgCode, strIncoCode, strIncoYM, strIncoKindCode
            , strIncoDate, strBaseProNo, strIncoBudGeCode, strIncoICode
            );

        //Response.Write(dt.Rows[0]["CNT_1"].ToString());
        
        CommonLib.DTReport rpt = new CommonLib.DTReport(Server.MapPath("../../Report/SAL/SAL2116.mht"), dt);
        string[] strParams = new string[23];
        strParams[0] = "印表日期：" + "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" +
            DateTime.Today.ToString("MM月dd日");// +"月";
        if (cmb_uc_PayType.SelectedValue == "005")
        {
            strParams[1] = cmb_uc_PayType.SelectedItem.Text.ToString() +
                "(" + cmbDateStep3.Text + ")";
        }
        else
        {
            strParams[1] = cmb_uc_PayType.SelectedItem.Text.ToString();
        }
        strParams[2] = "中華民國" + Convert.ToString(Convert.ToInt32(cmb_uc_YearMonth.DateStr.Substring(0, 4)) - 1911) +
            "年" + cmb_uc_YearMonth.DateStr.Substring(4, 2) + "月";
        strParams[3] = Convert.ToString(Convert.ToInt32(cmbDateStep3.SelectedValue.Substring(0, 4)) - 1911) + "年"
            + cmbDateStep3.Text.Substring(4, 2) + "月"
            + cmbDateStep3.Text.Substring(6, 2) + "日"
            ;
        //            cmbDateStep3.SelectedValue.Substring(0, 4) + "年" + cmbDateStep3.Text.Substring(4, 2) + "月" +
        //            cmbDateStep3.Text.Substring(6, 2) + "日";
        strParams[4] = dt.Rows[0]["CNT_1"].ToString() + "人";
        strParams[7] = dt.Rows[0]["INCO_TXAM_1"].ToString() + "元";
        strParams[5] = dt.Rows[0]["INCO_REAL_AMT_1"].ToString() + "元";
        strParams[6] = dt.Rows[0]["INCO_AMT_1"].ToString() + "元";

        strParams[8] = dt.Rows[0]["CNT_2"].ToString() + "人";
        strParams[11] = dt.Rows[0]["INCO_TXAM_2"].ToString() + "元";
        strParams[9] = dt.Rows[0]["INCO_REAL_AMT_2"].ToString() + "元";
        strParams[10] = dt.Rows[0]["INCO_AMT_2"].ToString() + "元";

        strParams[12] = dt.Rows[0]["CNT_3"].ToString() + "人";
        strParams[15] = dt.Rows[0]["INCO_TXAM_3"].ToString() + "元";
        strParams[13] = dt.Rows[0]["INCO_REAL_AMT_3"].ToString() + "元";
        strParams[14] = dt.Rows[0]["INCO_AMT_3"].ToString() + "元";

        strParams[16] = dt.Rows[0]["CNT_4"].ToString() + "人";
        strParams[18] = dt.Rows[0]["INCO_TXAM_4"].ToString() + "元";
        strParams[17] = dt.Rows[0]["INCO_REAL_AMT_4"].ToString() + "元";
        strParams[19] =
            Convert.ToString(
                Convert.ToDouble(dt.Rows[0]["CNT_1"])
                + Convert.ToDouble(dt.Rows[0]["CNT_2"])
                + Convert.ToDouble(dt.Rows[0]["CNT_3"])
                + Convert.ToDouble(dt.Rows[0]["CNT_4"])
                ) + "人"
                ;
        strParams[22] =
            Convert.ToString(
                Convert.ToDouble(dt.Rows[0]["INCO_TXAM_1"])
                + Convert.ToDouble(dt.Rows[0]["INCO_TXAM_2"])
                + Convert.ToDouble(dt.Rows[0]["INCO_TXAM_3"])
                + Convert.ToDouble(dt.Rows[0]["INCO_TXAM_4"])
                ) + "元";
        strParams[20] =
            Convert.ToString(
               Convert.ToDouble(dt.Rows[0]["INCO_REAL_AMT_1"])
                + Convert.ToDouble(dt.Rows[0]["INCO_REAL_AMT_2"])
                + Convert.ToDouble(dt.Rows[0]["INCO_REAL_AMT_3"])
                + Convert.ToDouble(dt.Rows[0]["INCO_REAL_AMT_4"])
                ) + "元";

        strParams[21] =
            Convert.ToString(
                Convert.ToDouble(dt.Rows[0]["INCO_AMT_1"])
                + Convert.ToDouble(dt.Rows[0]["INCO_AMT_2"])
                + Convert.ToDouble(dt.Rows[0]["INCO_AMT_3"])
                ) + "元";

        rpt.ExportFileName = "每月所得統計表";
        rpt.Param = strParams;
        rpt.ExportToExcel();

        //        rpt.



        /*
       Dim rpt As CommonLib.DTReport
        If Not OrgType.ToLower().Contains("expo") Then
            rpt = New CommonLib.DTReport(Server.MapPath("../../Report/FSC2/FSC2214_RPT.mht"), dt)
        Else
            rpt = New CommonLib.DTReport(Server.MapPath("../../Report/FSC2/FSC2214_RPT_expo.mht"), dt)
        End If
        Dim params(2) As String
        params(0) = FSCPLM.Logic.DateTimeInfo.GetTodayString
        params(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        params(2) = FSCPLM.Logic.DateTimeInfo.ToDisplay(dateb, "") & "~" & FSCPLM.Logic.DateTimeInfo.ToDisplay(datee, "")

        rpt.ExportFileName = "員工加班單明細"
        rpt.Param = params
        rpt.ExportToExcel()
         */

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        pnlStep1.Visible = true;
        pnlStep2.Visible = false;
        uPnlStep1.Update();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (cmb_uc_PayType.SelectedValue == "005")
        {
            pnlStep2.Visible = true;
            upnlStep2.Update();
        }
        else
        {
            pnlStep1.Visible = true;
            uPnlStep1.Update();
        }
        pnlStep3.Visible = false;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        pnlStep3.Visible = true;
        upnlStep3.Update();
        pnlStep4.Visible = false;

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        pnlStep4.Visible = true;
        upnlStep4.Update();
        pnlStep5.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        resetUI();
    }


    private void resetUI()
    {
        cmb_uc_PayType.Rebind();
        pnlStep1.Visible = true;


        pnlStep2.Visible = false;
        pnlStep3.Visible = false;
        pnlStep4.Visible = false;
        pnlStep5.Visible = false;

        uPnlStep1.Update();
        upnlStep2.Update();
        upnlStep3.Update();
        upnlStep4.Update();
        upnlStep5.Update();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        resetUI();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        resetUI();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        resetUI();
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        resetUI();
    }
}