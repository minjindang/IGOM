
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
using System.Text.RegularExpressions; 


public partial class SAL_SAL4_SAL4101 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cmbTypes.ReturnEvent = true;
        cmbTypes.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(TypeChange);
 
        if (Page.IsPostBack) return;
     //   initData();        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        initData();        
    }

    void TypeChange(object sender, EventArgs e)
    {
        initData();
        view.Visible = false;

    }

    private void initData()  //新增畫面之啟用年月至DropDownList_Year
    {      
        SAL4101 sal4101 = new SAL4101();
        string strType = cmbTypes.SelectedValue;
        DataTable addYear = sal4101.queryYearData(strType);
        DropDownList_Year.Items.Clear();
        if (addYear != null && addYear.Rows.Count > 0)
        {          
            for (int i = 0; i < addYear.Rows.Count; i++)
            {
                string ddltext = addYear.Rows[i]["ymstr"].ToString();
                string ddlva = addYear.Rows[i]["stws_ym"].ToString();
                ListItem item = new ListItem();
                item.Value = ddlva;
                item.Text = ddltext;
                DropDownList_Year.Items.Add(item);           
            }            
        }
    }

    // 列印按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }
    // 製作報表
    private void ExportReport()
    {
        SAL4101 sal4101 = new SAL4101();

        //抓出畫面所選生效年月
        string strYear = ""; 
        strYear = DropDownList_Year.SelectedValue;
        string strno = cmbTypes.SelectedValue;
        //查詢資料(依畫面年月)
        DataTable Reportdata = sal4101.querySearchData(strYear, strno);

        // 匯出動作
        CommonLib.DTReport rpt;
        rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL4101.mht"), Reportdata);
        rpt.ExportFileName = "勞保事故保險金額分級表";
   
        // 參數部分
        string[] strParams = new string[2];

        int year = int.Parse(strYear.Substring(0, 4)) - 1911;
        string month = strYear.Substring(4, 2);      

        strParams[0] = "民國"+ year.ToString() + "年" + month + "月";
        strParams[1] = "民國" + Convert.ToInt16(DateTime.Today.AddYears(-1911).Year) + "年" + DateTime.Today.ToString("MM月dd日");
        rpt.Param = strParams;
        rpt.ExportToExcel();        
    }

    //新增按鈕
    protected void Button_add_Click(object sender, EventArgs e)
    {
        addPanel.Visible = true;
        GridView1.Visible = false;
        UcPager.Visible = false;
        view.Visible = false;
        editPanel.Visible = false;
        title.Visible = false;
    }

    //查詢按鈕
    protected void Button_Search_Click(object sender, EventArgs e)
    {
        doQueryData();    
        editPanel.Visible = false;
        addPanel.Visible = false;
    }

    private void doQueryData() //查詢資料
    {      
        SAL4101 sal4101 = new SAL4101();

        //抓出畫面選擇之生效年月
        string strYear = "";
        strYear = DropDownList_Year.SelectedValue;
        string strno = cmbTypes.SelectedValue;
        //查詢
        DataTable Searchdata = sal4101.querySearchData(strYear, strno);

        if (Searchdata != null && Searchdata.Rows.Count > 0 )
        {
            Searchdata.Columns.Add("data_no");
            for (int i = 0; i < Searchdata.Rows.Count; i++)
            {
                Searchdata.Rows[i]["data_no"] = i + 1;
            }
            GridView1.Columns[9].Visible = true;
            GridView1.Columns[11].Visible = true;  
            GridView1.DataSource = Searchdata;
            GridView1.DataBind();   
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[11].Visible = false;   
            GridView1.Visible = true;
            UcPager.Visible = true;
            view.Visible = true;
        }
        else
        {         
    /*        Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
     */
            GridView1.DataSource = Searchdata;
            GridView1.DataBind();   
            view.Visible = true;
            GridView1.Visible = true;
            if (GridView1.Rows.Count > 0)
            {
                UcPager.Visible = true;
            }
            else
            {
                UcPager.Visible = false;
            }

            initData();

        }
    }
    //維護欄位按鈕
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //維護button
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            editPanel.Visible = true;
            title.Visible = false;
            string yearmonth = GridView1.Rows[index].Cells[9].Text.ToString();
            int year = int.Parse(yearmonth.Substring(0, 4)) - 1911;
            string month = yearmonth.Substring(4, 2);
            YearMonth.Text = year.ToString() + "年" + month + "月";
            level.Text = GridView1.Rows[index].Cells[1].Text.Replace("&nbsp;", "");
            txt_up.Text = GridView1.Rows[index].Cells[2].Text.Replace("&nbsp;", "");
            txt_low.Text = GridView1.Rows[index].Cells[3].Text.Replace("&nbsp;", "");
            txt_dct1.Text = GridView1.Rows[index].Cells[5].Text.Replace("&nbsp;", "");
            txt_dct30.Text = GridView1.Rows[index].Cells[6].Text.Replace("&nbsp;", "");
            edtYM4Edit.Text = yearmonth;

            if (GridView1.Rows[index].Cells[4].Text.Replace("&nbsp;", "") != "")
            {
                Double a1 = Convert.ToDouble(GridView1.Rows[index].Cells[4].Text.Replace("&nbsp;", ""));
                TextBox1.Text = ((int)a1).ToString();
            }
            else
            {
                TextBox1.Text = GridView1.Rows[index].Cells[4].Text.Replace("&nbsp;", "");
            }

            if (GridView1.Rows[index].Cells[7].Text.Replace("&nbsp;", "") != "")
            {
                Double a2 = Convert.ToDouble(GridView1.Rows[index].Cells[7].Text.Replace("&nbsp;", ""));
                TextBox2.Text = ((int)a2).ToString();
            }
            else
            {
                TextBox2.Text = GridView1.Rows[index].Cells[7].Text.Replace("&nbsp;", "");
            }

            if (GridView1.Rows[index].Cells[8].Text.Replace("&nbsp;", "") != "")
            {
                Double a3 = Convert.ToDouble(GridView1.Rows[index].Cells[8].Text.Replace("&nbsp;", ""));
                TextBox3.Text = ((int)a3).ToString();
            }
            else
            {
                TextBox3.Text = GridView1.Rows[index].Cells[8].Text.Replace("&nbsp;", "");
            }
         


            DropDownList aa = (DropDownList)UcSaCode2.FindControl("DropDownList_code_no");
            aa.Enabled = false;
            UcSaCode2.SelectedValue = GridView1.Rows[index].Cells[11].Text;

            GridView1.Visible = false;
            UcPager.Visible = false;
            view.Visible = false;
        } 
    }
    //新增取消
    protected void add_cancel_Click(object sender, EventArgs e)
    {
        resetNewPandel();
        addPanel.Visible = false;
        GridView1.Visible = false;
        UcPager.Visible = false;
        view.Visible = false;
        title.Visible = true;
    }
    //確定新增
    protected void add_submit_Click(object sender, EventArgs e)
    {
        string msg ="";
        if ( txtYear.Text == "" || txtMonth.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg +="啟用年月";
        }
        if( stws_level.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg +="投保金額等級";
        }
        if(stws_up.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg +="月薪資所得上限";
        }
        if(stws_low.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg +="月薪資所得下限";
        }
        if( stws_stand.Text =="" )
        {
            if (msg != "")
                msg += ",";
            msg += "保險金額";
        }          
        if(msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:"+msg, "", "");
            this.Page = tempPage;
            return;
        }    

        msg = "";
        int x = 0;
        if (!int.TryParse(txtYear.Text, out x) || !int.TryParse(txtMonth.Text, out x))
        {
            if (msg != "")
                msg += ",";
          msg +="啟用年月";
        }
        if( !int.TryParse(stws_level.Text, out x) )
        {
            if (msg != "")
                msg += ",";
          msg +="投保金額等級";
        }
        if( !int.TryParse(stws_up.Text, out x) )
        {
            if (msg != "")
                msg += ",";
          msg +="月薪資所得上限";
        }
        if( !int.TryParse(stws_low.Text, out x) )
        {
            if (msg != "")
                msg += ",";
          msg +="月薪資所得下限";
        }
        if(!int.TryParse(dct1.Text, out x) && dct1.Text != "")
        {
            if (msg != "")
                msg += ",";
          msg +="1日(投保日數)自負擔金額";
        }
        if(!int.TryParse(dct30.Text, out x) && dct30.Text != "")
        {
            if (msg != "")
                msg += ",";
          msg +="30日(投保日數)自負擔金額";
        }
        if(!int.TryParse(stws_stand.Text, out x) )
        {
            if (msg != "")
                msg += ",";
          msg +="保險金額";
        }
        if(!int.TryParse(STWS_DCT.Text, out x) && STWS_DCT.Text != "" )
        {
            if (msg != "")
                msg += ",";
          msg += "自負擔";
        }
        if (!int.TryParse(STWS_SUP.Text, out x) && STWS_SUP.Text != "")
        {
            if (msg != "")
                msg += ",";
            msg += "機關負擔";
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "以下欄位請輸入數值:"+msg, "", "");
            this.Page = tempPage;
            return;
        }

        int strYear = int.Parse(txtYear.Text) + 1911;//民國+1911
        int strMonth = int.Parse(txtMonth.Text);
        string stws_ym = strYear.ToString().PadLeft(4,'0')+ strMonth.ToString().PadLeft(2,'0'); //畫面年月      
        string strlevel = stws_level.Text; //畫面輸入之投保金額等級
        string strup = stws_up.Text; //畫面輸入之月薪資所得上限
        string strlow = stws_low.Text;//畫面輸入之月薪資所得下限
        string strdct1 = dct1.Text;//1日(投保日數)自負擔金額
        string strdct30 = dct30.Text;//30日(投保日數)自負擔金額
        string strmuser = LoginManager.UserId; //登入者員工編號
        string strstws_ym = UcSaCode1.SelectedValue; //保險種類
        string strSTWS_DCT  = STWS_DCT.Text.Trim();
        string strSTWS_SUP = STWS_SUP.Text.Trim();
        string strstws_stand = stws_stand.Text.Trim();

        if (strdct1 == "")
            strdct1 = "0";
        if (strdct30 == "")
            strdct30 = "0";
        if (strSTWS_SUP == "")
            strSTWS_SUP = "0";
        if (strSTWS_DCT == "")
            strSTWS_DCT = "0";

        SAL4101 sal4101 = new SAL4101();
        sal4101.queryaddData(stws_ym, strlevel, strup, strlow, strdct1, strdct30, strmuser
            , strstws_ym, strSTWS_DCT, strSTWS_SUP, strstws_stand
            );

        initData();
        addPanel.Visible = false;
        title.Visible = true;
        resetNewPandel();
    }

    // 清空輸入項目
    private void resetNewPandel()
    {
        txtYear.Text = "";
        txtMonth.Text = "";
        stws_level.Text = "";
        stws_up.Text = "";
        stws_low.Text = "";
        dct1.Text = "";
        dct30.Text = "";
        STWS_DCT.Text = "";
        STWS_SUP.Text = "";
        stws_stand.Text = "";
    }
    //取消修改
    protected void edit_cancel_Click(object sender, EventArgs e)
    {
        editPanel.Visible = false;
        GridView1.Visible = true;
        UcPager.Visible = true;
        view.Visible = true;
        title.Visible = true;
    }

    //確定修改
    protected void edit_submit_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txt_up.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得上限";
        }
        if (txt_low.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得下限";
        }
        if (TextBox1.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "保險金額";
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
            this.Page = tempPage;
            return;
        }

        msg = "";
        int x = 0;
        if (!int.TryParse(txt_up.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得上限";
        }
        if (!int.TryParse(txt_low.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得下限";
        }
        if (!int.TryParse(txt_dct1.Text, out x) && txt_dct1.Text != "")
        {
            if (msg != "")
                msg += ",";
            msg += "1日(投保日數)自負擔金額";
        }
        if (!int.TryParse(txt_dct30.Text, out x) && txt_dct30.Text != "")
        {
            if (msg != "")
                msg += ",";
            msg += "30日(投保日數)自負擔金額";
        }
        if (!int.TryParse(TextBox1.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "保險金額";
        }
        if (!int.TryParse(TextBox2.Text, out x) && TextBox2.Text != "")
        {
            if (msg != "")
                msg += ",";
            msg += "自負擔";
        }
        if (!int.TryParse(TextBox3.Text, out x) && TextBox3.Text != "")
        {
            if (msg != "")
                msg += ",";
            msg += "機關負擔";
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "以下欄位請輸入數值:" + msg, "", "");
            this.Page = tempPage;
            return;
        }  

        SAL4101 sal4101 = new SAL4101();
        string strup = txt_up.Text; //畫面輸入之月薪資所得上限
        string strlow = txt_low.Text;//畫面輸入之月薪資所得下限
        string strdct1 = txt_dct1.Text;//1日(投保日數)自負擔金額
        string strdct30 = txt_dct30.Text;//30日(投保日數)自負擔金額
        string strmuser = LoginManager.UserId; //登入者員工編號
        string strstws_stand = TextBox1.Text;//保險金額
        string strSTWS_DCT = TextBox2.Text;//自負
        string strSTWS_SUP = TextBox3.Text;//機關負擔
        string stws_no = UcSaCode2.SelectedValue;

        if (strdct1 == "")
            strdct1 = "0";
        if (strdct30 == "")
            strdct30 = "0";
        if (strSTWS_SUP == "")
            strSTWS_SUP = "0";
        if (strSTWS_DCT == "")
            strSTWS_DCT = "0";

        string stws_ym = edtYM4Edit.Text;//清單之生效年月,索引值(一) 
        string strlevel = level.Text;//清單之投保金額等級,維護使用之資料索引值(三)

        sal4101.queryeditData(stws_ym, stws_no, strlevel, strup, strlow, strdct1, strdct30, strmuser, 
            strstws_stand, strSTWS_DCT, strSTWS_SUP);

        doQueryData();
        GridView1.Visible = true;
        UcPager.Visible = true;
        view.Visible = true;
        editPanel.Visible = false;
        title.Visible = true;
    }
     
    //刪除按鈕
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index =int.Parse(txtFuncParam.Value.Trim());
        SAL4101 sal4101 = new SAL4101();
        string stws_ym = GridView1.Rows[index].Cells[9].Text.ToString();  //清單之生效年月,索引值(一)
        string strlevel = GridView1.Rows[index].Cells[1].Text;   //清單之投保金額等級,維護使用之資料索引值(三)
        string stws_no = GridView1.Rows[index].Cells[11].Text; 

        // 刪除資料
        sal4101.querydeleteData(stws_ym, stws_no, strlevel);
        doQueryData();
    }
    protected void DropDownList_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        UcPager.Visible = false;
        view.Visible = false;
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        doQueryData(); 
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {       
        GridView1.PageIndex = e.NewPageIndex;         
    }
}