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
using System.Text;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Net;
using System.Configuration;
using System.Net.Mail;


public partial class SAL_SAL3_SAL3114 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    protected void Page_Load(object sender, EventArgs e)
    {
        cmb_uc_calitem.ReturnEvent = true;
        cmb_uc_calitem.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(calItemChanged); //發放種類

        // 年月之月改變
        DropDownList cmbMonth = (DropDownList)cmbYearMonth.FindControl("ddlMonth");
        cmbMonth.AutoPostBack = true;
        cmbMonth.SelectedIndexChanged += new EventHandler(cmbmonthchangeed);
        // 年月之年改變
        DropDownList cmbYear = (DropDownList)cmbYearMonth.FindControl("ddlYear");
        cmbYear.AutoPostBack = true;
        cmbYear.SelectedIndexChanged += new EventHandler(cmbmonthchangeed);

        cmbItemType2.AutoPostBack = true;
        cmbItemType2.SelectedIndexChanged += new EventHandler(cmbItemType2_SelectedIndexChanged);

        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);


        get_unit();

        if (Page.IsPostBack) return;
            

        Page.LoadComplete += new EventHandler(Page_LoadComplete);
              
    }

    public void get_unit()
    {
         SAL3114 sal3114 = new SAL3114();
         DataTable dt = sal3114.unit_multi_monthpay(strOrgCode);
         if (dt != null && dt.Rows.Count > 0)
         {
             unit_multi_monthpay.Text = dt.Rows[0]["unit_multi_monthpay"].ToString();
         }
    }

    //發放種類2改變
    void cmbItemType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        tableGV1.Visible = false;
        GridView_trndata.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
    }

    void cmbmonthchangeed(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        tableGV1.Visible = false;
        GridView_trndata.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
        
        doCalItemChanged();
        bindDropDownData();
       

        if (rbStep1.Checked)
        {
            if (cmb_uc_calitem.SelectedValue != "005")
            {
                queryDatePayed(); //取得發放日期
            }
        }
        if (rbStep2.Checked)
        {
            getPayDate();
        }
        if (rbStep3.Checked || rbStep4.Checked || rbStep5.Checked)
        {
            getinit();
        }
    }

    void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        bindDropDownData();

        DropDownList cmbMonth = (DropDownList)cmbYearMonth.FindControl("ddlMonth");
        cmbMonth.SelectedValue = DateTime.Now.ToString("MM");
        queryDatePayed(); //取得發放日期
    }


    //發放種類2
    public void bindDropDownData()
    {      
        string strKind = cmb_uc_calitem.SelectedValue;
        string strYYMM = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        if (strKind == "005" && chkOtherPayItems.Items.Count > 0)
        {
            ListItem li = new ListItem();
            li.Text = "實發數";
            li.Value = "N_N_N_N_N_N";
            cmbItemType2.Items.Clear();
            cmbItemType2.Items.Add(li);
        }
        else if(strKind =="005" && chkOtherPayItems.Items.Count == 0)
        {
            cmbItemType2.Items.Clear();
        }
        else
        {
            SAL3114 sal3114 = new SAL3114();
            DataTable dt = sal3114.queryPayItemsDropDown(
                this.strOrgCode,
                strKind,//-- 發放種類
                strYYMM
                );

            cmbItemType2.Items.Clear();
            cmbItemType2.DataSource = dt;
            cmbItemType2.DataValueField = "CODE";
            cmbItemType2.DataTextField = "NAME";
            cmbItemType2.DataBind();
        }
    }

    // 發放種類改變
    protected void calItemChanged(object sender, EventArgs e)
    {        
        doCalItemChanged();
        bindDropDownData(); //發放種類2


        if (cmb_uc_calitem.SelectedValue != "005")
        {
            if (rbStep1.Checked)
            {
                td1.Visible = true;  // 原發放日期
                td2.Visible = true;  
                queryDatePayed(); //取得發放日期
            }
            else
            {
                td1.Visible = false;  // 原發放日期
                td2.Visible = false;
            }
          
        }
        else
        {
            td1.Visible = false;  // 原發放日期
            td2.Visible = false;
        }

        GridView1.Visible = false;
        tableGV1.Visible = false;
        GridView_trndata.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        amt.Visible = false;
        table1.Visible = false;

        if (rbStep2.Checked)
        {
            this.getPayDate();
        }

        if (rbStep3.Checked || rbStep4.Checked || rbStep5.Checked)
        {
            getinit();
        }

    }

    private void queryDatePayed()//第一步 非005 取得發放日期
    {      
        SAL3112 sal3112 = new SAL3112();
        // 參數
        string strPayoKind = cmb_uc_calitem.SelectedValue;  //畫面選擇發放種類代碼(code_no)
        string strPayoYymm = cmbYearMonth.Year.ToString().PadLeft(4, '0') +
                             cmbYearMonth.Month.ToString().PadLeft(2, '0'); //畫面選擇之計算年月

        string strPayoKindCode = "000";    

        DataTable data = sal3112.queryDatePayed(this.strOrgCode, strPayoKind, strPayoYymm, strPayoKindCode);

        DropDownList1.Items.Clear();
        if (data != null && data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = data.Rows[i]["paydate"].ToString();
                item.Value = data.Rows[i]["payo_date"].ToString();
                DropDownList1.Items.Add(item); //add發放日期
            }
        }
    }

    private void doCalItemChanged()
    {
        if (cmb_uc_calitem.SelectedValue == "005" && rbStep1.Checked)
        {
            doItemOthers();
            // 顯示其他項目
            pnlOthers.Visible = true;
        }
        else
        {
            pnlOthers.Visible = false;
        }
    }

    private void doItemOthers() //其它薪津
    {
        // 查詢其他薪津項目
        querySalSaItem();
    }

    // 查詢其他薪津項目
    private void querySalSaItem()
    {              
        string strPAYOKIND = cmb_uc_calitem.SelectedValue; ////'畫面選擇之發放種類'
        string strPAYOYYMM = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');//'畫面選擇之薪資年月'
  
        // 查詢其他薪津項目
        SAL3114 sal3114 = new SAL3114();
        DataTable dt = sal3114.querySalSaitem(this.strOrgCode, strPAYOKIND, strPAYOYYMM); 
        chkOtherPayItems.Items.Clear();
        chkOtherPayItems.DataSource = dt;
        chkOtherPayItems.DataValueField = "PAYO_KIND_CODE_NO";
        chkOtherPayItems.DataTextField = "CODE_DESC1";
        chkOtherPayItems.DataBind();      
    }

    // 更換步驟
    private void dorbStepChenged()
    {
        // 所有 button 之 Enable Disable;
        Button_transfer.Visible = rbStep1.Checked;
        Button_search.Visible = rbStep2.Checked;
        Button_download.Visible = rbStep3.Checked;
        Button_print.Visible = rbStep4.Checked;
        Button_EMail.Visible = rbStep5.Checked;

        if(rbStep5.Checked)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;        
        }
    }

    protected void rbStep2_CheckedChanged(object sender, EventArgs e)
    {
        dorbStepChenged();
        // 查詢預設資料
        initStep2();
        td1.Visible = false;  // 原發放日期
        td2.Visible = false;

        tableGV1.Visible = false;
        GridView_trndata.Visible = false;
        table1.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
        pnlOthers.Visible = false;

    }

    private void initStep2()
    {
        getPayDate();
        UcDate1.Enabled = false;
        cmbItemType2.Enabled = false;
    }

    private void getPayDate() //第二步畫面資料
    {
        SAL3114 sal3114 = new SAL3114();
        // 參數
        string strKind = cmb_uc_calitem.SelectedValue;
        string strYYMM = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        DataTable dt = sal3114.querySalBatTrns(
                           this.strOrgCode,//'使用者登入之機關代號'
                             strKind,//'畫面選擇之發放種類'
                             strYYMM//'畫面選擇之發放年月'
                             );

        if (dt.Rows.Count > 0)
        {
            UcDate1.Text =
                Convert.ToString(Convert.ToInt32(dt.Rows[0]["TRN_DATE"].ToString().Substring(0, 4)) - 1911).PadLeft(3, '0') +"/"+
                dt.Rows[0]["TRN_DATE"].ToString().Substring(4, 2).PadLeft(2, '0') +"/"+
                dt.Rows[0]["TRN_DATE"].ToString().Substring(6, 2).PadLeft(2, '0') ;
            if (strKind != "005")
            {
                cmbItemType2.SelectedValue = dt.Rows[0]["TRN_KIND"].ToString() + "_" + dt.Rows[0]["TRN_CODE_SYS"].ToString() + "_"
                                            + dt.Rows[0]["TRN_CODE_KIND"].ToString() + "_" + dt.Rows[0]["TRN_CODE_TYPE"].ToString() + "_"
                                            + dt.Rows[0]["TRN_CODE_NO"].ToString() + "_" + dt.Rows[0]["TRN_CODE"].ToString();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = "實發數";
                li.Value = "N_N_N_N_N_N";
                cmbItemType2.Items.Clear();
                cmbItemType2.Items.Add(li);
            }

            if (strKind == "005") //如果發放種類為其他薪津(005) 批號清單如trn_nstring拆解為多批號資料
            {
                string TRN_NSTRING = dt.Rows[0]["TRN_NSTRING"].ToString();
                string[] NS = TRN_NSTRING.Split(',');
                string newns="";
                for (int i = 0; i < NS.Length; i++)
                {
                    NS[i] = "'" + NS[i] + "'";
                    if (newns != "")
                        newns += ",";
                    newns += NS[i];
                }
                DataTable dtn = sal3114.queryNSTRING(newns);
                GridView2.DataSource = dtn;
                GridView2.DataBind();
                GridView2.Visible = true;
            }
        }
        else
        {
            UcDate1.Text = "";
            cmbItemType2.Items.Clear();
            GridView2.Visible = false;
        }
    }

    protected void rbStep1_CheckedChanged(object sender, EventArgs e)
    {
        dorbStepChenged();
        initStep1();
        doCalItemChanged();
        bindDropDownData(); //發放種類2
       

        tableGV1.Visible = false;
        GridView_trndata.Visible = false;
        GridView2.Visible = false;
        table1.Visible = false;
        amt.Visible = false;
        table1.Visible = false;

        UcDate1.Text = ""; 
        if (cmb_uc_calitem.SelectedValue != "005")
        {                      
                td1.Visible = true;  // 原發放日期
                td2.Visible = true;
        }
        else
        {
            td1.Visible = false;  // 原發放日期
            td2.Visible = false;
        }
    }

    private void initStep1()
    {
        UcDate1.Enabled = true;
        cmbItemType2.Enabled = true;
    }

    protected void getinit() //畫面發放日期及發放類別2
    {
        SAL3114 sal3114 = new SAL3114();
        // 參數
        string strKind = cmb_uc_calitem.SelectedValue;
        string strYYMM = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        DataTable dt = sal3114.querySalBatTrns(
                             this.strOrgCode,//'使用者登入之機關代號'
                             strKind,//'畫面選擇之發放種類'
                             strYYMM//'畫面選擇之發放年月'
                             );

        if (dt.Rows.Count > 0)
        {
            UcDate1.Text =
                Convert.ToString(Convert.ToInt32(dt.Rows[0]["TRN_DATE"].ToString().Substring(0, 4)) - 1911).PadLeft(3, '0') + "/" +
                dt.Rows[0]["TRN_DATE"].ToString().Substring(4, 2).PadLeft(2, '0') + "/" +
                dt.Rows[0]["TRN_DATE"].ToString().Substring(6, 2).PadLeft(2, '0');
        
            if (strKind != "005")
            {
                cmbItemType2.SelectedValue = dt.Rows[0]["TRN_KIND"].ToString() + "_" + dt.Rows[0]["TRN_CODE_SYS"].ToString() + "_"
                                           + dt.Rows[0]["TRN_CODE_KIND"].ToString() + "_" + dt.Rows[0]["TRN_CODE_TYPE"].ToString() + "_"
                                           + dt.Rows[0]["TRN_CODE_NO"].ToString() + "_" + dt.Rows[0]["TRN_CODE"].ToString();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = "實發數";
                li.Value = "N_N_N_N_N_N";
                cmbItemType2.Items.Clear();
                cmbItemType2.Items.Add(li);   
                
                step3nstr.Text  = dt.Rows[0]["TRN_NSTRING"].ToString();
            }

            if (strKind == "005") //如果發放種類為其他薪津(005) 批號清單如trn_nstring拆解為多批號資料
            {
                string TRN_NSTRING = dt.Rows[0]["TRN_NSTRING"].ToString();
                string[] NS = TRN_NSTRING.Split(',');
                string newns = "";
                for (int i = 0; i < NS.Length; i++)
                {
                    NS[i] = "'" + NS[i] + "'";
                    if (newns != "")
                        newns += ",";
                    newns += NS[i];
                }
                DataTable dtn = sal3114.queryNSTRING(newns);
                GridView2.DataSource = dtn;
                GridView2.DataBind();
                GridView2.Visible = true;
            }
            else
            {
                GridView2.Visible = false;
            }


        }
        else
        {
            UcDate1.Text = "";
            cmbItemType2.Items.Clear();
            GridView2.Visible = false;
        }
    }

    protected void rbStep3_CheckedChanged(object sender, EventArgs e)
    {
        dorbStepChenged();
        UcDate1.Enabled = false;
        cmbItemType2.Enabled = false;
        td1.Visible = false;  // 原發放日期
        td2.Visible = false;

        tableGV1.Visible = false;
        GridView_trndata.Visible = false;    
        table1.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
        pnlOthers.Visible = false;
        getinit();
    }
    protected void rbStep4_CheckedChanged(object sender, EventArgs e)
    {
        dorbStepChenged();
        UcDate1.Enabled = false;
        cmbItemType2.Enabled = false;
        td1.Visible = false;  // 原發放日期
        td2.Visible = false;

        tableGV1.Visible = false;
        GridView_trndata.Visible = false;    
        table1.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
        pnlOthers.Visible = false;
        getinit();
    }
    protected void rbStep5_CheckedChanged(object sender, EventArgs e)
    {
        dorbStepChenged();
        UcDate1.Enabled = true; //可填日期
        cmbItemType2.Enabled = false;
        td1.Visible = false;  // 原發放日期
        td2.Visible = false;

        tableGV1.Visible = false;
        GridView_trndata.Visible = false;    
        table1.Visible = false;
        amt.Visible = false;
        table1.Visible = false;
        pnlOthers.Visible = false;
        getinit();
    }

    //批次產生轉帳檔
    protected void Button_transfer_Click(object sender, EventArgs e)
    {
        if (cmb_uc_calitem.SelectedValue =="005" && UcDate1.Text == "") //005 一定要輸入
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + "發放日期", "", "");
            this.Page = tempPage;
            return;
        }
     
        SAL3114 sal3114 = new SAL3114();

        string strPayDate = "";
        if (UcDate1.Text != "")
        {
            strPayDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);
        }
        else
        {
           strPayDate= DropDownList1.SelectedValue;
        }

        string strPAYOKIND = cmb_uc_calitem.SelectedValue; //'畫面選擇之發放種類'
        string strPAYOYYMM = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');  

        string strPAYOMergeflowid = "";//畫面勾選之批號
        string updatePAYOMergeflowid = "";//update畫面勾選之批號 
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox ch = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch1");
            if (ch.Checked)
            {
                if (strPAYOMergeflowid != "")
                    strPAYOMergeflowid += ",";
               strPAYOMergeflowid+= GridView1.Rows[i].Cells[1].Text  ;

               if (updatePAYOMergeflowid != "")
                   updatePAYOMergeflowid += ",";
               updatePAYOMergeflowid +="'"+ GridView1.Rows[i].Cells[1].Text + "'";
            }
        }

        if (strPAYOMergeflowid == "" && cmb_uc_calitem.SelectedValue == "005")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請勾選批號", "", "");
            this.Page = tempPage;
            return;
        }

        string strTrnKind = cmb_uc_calitem.SelectedValue; // 發放種類     
        if (cmbItemType2.SelectedValue == "") //發放種類第二層    
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "無資料可轉帳", "", "");
            this.Page = tempPage;
            return;
        }   
        string[] strCodes = cmbItemType2.SelectedValue.Split('_');
         
        GetNstr();
        if (!selectSATDPM())
        {
            return;
        }
        if (! selectSATDPF())
        {
            return;
        }

        if (!checkSaBank(strPAYOYYMM, strTrnKind, strPayDate))
        {
            return;
        }

        if (cmb_uc_calitem.SelectedValue == "005")
        {
            //刪除舊資料
            sal3114.deleteSatrndata(strPAYOYYMM, strOrgCode);
            
            sal3114.insertSaBatTrn(
            this.strOrgCode, //使用者機關代號
            LoginManager.UserId, // 使用者員工編號
            strPAYOYYMM,// 畫面選擇薪資年月
            strPayDate, // 畫面選擇薪資日期
            strTrnKind, // 畫面選擇發放種類
            strCodes[1],// 畫面選擇發放種類的第二層代碼(第一組)
            strCodes[2],// 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
            strCodes[3],// 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
            strCodes[4],// 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
            strCodes[5],// 畫面選擇發放種類的第二層代碼(第五組，以底線區分)
            strPAYOMergeflowid); //當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null
            
            sal3114.updateSaPayO(
                strPayDate, //'20140321' --'畫面上選擇日期'
                this.strOrgCode,//'登入者機關代碼'
                strPAYOKIND, //'畫面選擇之發放種類'
                strPAYOYYMM, //'畫面選擇之發放年月'
                updatePAYOMergeflowid// '畫面勾選之批號'
            );
            sal3114.updateSaPayOD(
                            strPayDate, //'20140321' --'畫面上選擇日期'
                 this.strOrgCode,//'登入者機關代碼'
                 strPAYOKIND, //'畫面選擇之發放種類'
                 strPAYOYYMM, //'畫面選擇之發放年月'
                 updatePAYOMergeflowid// '畫面勾選之批號'

                );
            sal3114.updateSaInco(
                             strPayDate, //'20140321' --'畫面上選擇日期'
                 this.strOrgCode,//'登入者機關代碼'
                 strPAYOKIND, //'畫面選擇之發放種類'
                 strPAYOYYMM, //'畫面選擇之發放年月'
                 updatePAYOMergeflowid// '畫面勾選之批號'
            );

        }
        else
        {
            strPAYOMergeflowid = "";
            //刪除舊資料
            sal3114.deleteSatrndata2(strPAYOYYMM, strOrgCode, strPAYOKIND, strCodes[1], strCodes[3], strCodes[4], strCodes[5]);

            sal3114.insertSaBatTrn(
        this.strOrgCode, //使用者機關代號
        LoginManager.UserId, // 使用者員工編號
        strPAYOYYMM,// 畫面選擇薪資年月
        strPayDate, // 畫面選擇薪資日期
        strTrnKind, // 畫面選擇發放種類
        strCodes[1],// 畫面選擇發放種類的第二層代碼(第一組)
        strCodes[2],// 畫面選擇發放種類的第二層代碼(第二組，以底線區分)
        strCodes[3],// 畫面選擇發放種類的第二層代碼(第三組，以底線區分)
        strCodes[4],// 畫面選擇發放種類的第二層代碼(第四組，以底線區分)
        strCodes[5],// 畫面選擇發放種類的第二層代碼(第五組，以底線區分)
        strPAYOMergeflowid); //當發放種類為其它薪金時，畫面上所勾選的批號，多筆時以’，’區格，否則為null

            if (UcDate1.Text != "")
            {
              string newdate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);
     
                sal3114.updateSaPayO2(
            DropDownList1.SelectedValue , //原來日期
            this.strOrgCode,//'登入者機關代碼'
            strPAYOKIND, //'畫面選擇之發放種類'
            strPAYOYYMM, //'畫面選擇之發放年月'
            strPAYOMergeflowid// '畫面勾選之批號'
            , newdate //修正日期
             );
                sal3114.updateSaPayOD2(
                      DropDownList1.SelectedValue, //原來日期
                     this.strOrgCode,//'登入者機關代碼'
                     strPAYOKIND, //'畫面選擇之發放種類'
                     strPAYOYYMM, //'畫面選擇之發放年月'
                     strPAYOMergeflowid// '畫面勾選之批號'
                     , newdate //修正日期
                    );
                sal3114.updateSaInco2(
                     DropDownList1.SelectedValue, //原來日期
                     this.strOrgCode,//'登入者機關代碼'
                     strPAYOKIND, //'畫面選擇之發放種類'
                     strPAYOYYMM, //'畫面選擇之發放年月'
                     strPAYOMergeflowid// '畫面勾選之批號'
                    , newdate //修正日期
                );

            }
        }

          
        Page temp = this.Page;
        CommonFun.MsgShow(ref temp,
           CommonFun.Msg.Custom, "批次產生轉帳檔已送出，預計五分鐘完成計算，請稍候！", "", "");
        this.Page = temp;      
    }

    protected void GetNstr()
    {   

       string payo_string = "";
       string payod_string = "";
       string tdpm_string = "";

       if (cmb_uc_calitem.SelectedValue == "005")
       {
               for (int i = 0; i < GridView1.Rows.Count ; i++)
               {                
                   string code_type = "";
                   string code_no = "";
                   string code = "";

                   CheckBox ch = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch1");
                   if (ch.Checked)
                   {
                       code_type = GridView1.Rows[i].Cells[5].Text;
                       code_no = GridView1.Rows[i].Cells[6].Text;
                       code = GridView1.Rows[i].Cells[7].Text;

                       if (payo_string != "" )
                       {
                           payo_string = payo_string + " Or ";
                           payod_string = payod_string + " Or ";
                           tdpm_string = tdpm_string + " Or ";
                       }
                       payo_string += "(payo_kind_code_type='" + code_type + "' and payo_kind_code_no='" + code_no + "' and payo_kind_code='" + code + "')";
                       payod_string += "(payod_kind_code_type='" + code_type + "' and payod_kind_code_no='" + code_no + "' and payod_kind_code='" + code + "')";
                       tdpm_string += "(tdpm_code_type='" + code_type + "' and tdpm_code_no='" + code_no + "' and tdpm_code='" + code + "')";
                       
                   }                 
               } 
       }

        p_payo_str.Text = payo_string;
        p_payod_str.Text = payod_string;
        p_tdpm_str.Text= tdpm_string;

    }

    protected bool selectSATDPM()
    {
       SAL3114 sal3114 = new SAL3114();   
       string[] strCodes = cmbItemType2.SelectedValue.Split('_'); //發放種類第二層  
       DataTable dt;
       if (strCodes[0] == "N")
       {

           dt = sal3114.querydata(this.strOrgCode,p_tdpm_str.Text);
       }
       else if (strCodes[5] != "")
       {
           dt = sal3114.querydata2(this.strOrgCode, strCodes[0], strCodes[1], strCodes[2], strCodes[3], strCodes[4], strCodes[5]);       
       }
       else
       {
           dt = sal3114.querydata3(this.strOrgCode, strCodes[0], strCodes[1], strCodes[2], strCodes[3], strCodes[4]);  
       }

       if (dt != null && dt.Rows.Count > 0)
       { 
                p_tdpf_seqno.Text= dt.Rows[0]["tdpm_tdpf_seqno"].ToString();
                p_tdpm_code_sys.Text =dt.Rows[0]["tdpm_code_sys"].ToString();
                p_tdpm_code_type.Text = dt.Rows[0]["tdpm_code_type"].ToString();
                p_tdpm_code_no.Text = dt.Rows[0]["tdpm_code_no"].ToString();
                p_tdpm_code.Text = dt.Rows[0]["tdpm_code"].ToString();
            return true;
       }
       else
       {
           Page tempPage = this.Page;
           CommonFun.MsgShow(ref tempPage,
              CommonFun.Msg.Custom, "您是第一次計算此項目,請先至[各單位銀行帳號與轉帳項目對照檔維護]點選[儲存變更].再產生轉帳檔!", "", "");
           this.Page = tempPage;
           return false;
       }
    }

    protected bool selectSATDPF()
    {
        SAL3114 sal3114 = new SAL3114();
        DataTable dt = sal3114.querydataSATDPF(this.strOrgCode, p_tdpf_seqno.Text);
        if (dt != null && dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "您是第一次計算此項目,請先至[各單位銀行帳號與轉帳項目對照檔維護]點選[儲存變更].再產生轉帳檔!", "", "");
            this.Page = tempPage;
            return false;
        }
    }


    protected bool checkSaBank(string strPAYOYYMM, string strTrnKind, string strPayDate)
    {
        SAL3114 sal3114 = new SAL3114();
        sal3114.queryubStr(strOrgCode);
        sal3114.upbkStr(strOrgCode);

        string[] strCodes = cmbItemType2.SelectedValue.Split('_');

        DataTable dt = sal3114.baseStr(strOrgCode, strPayDate, strPAYOYYMM, strTrnKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5], p_tdpm_code_sys.Text
            , p_payod_str.Text, p_tdpf_seqno.Text);
        string msg = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (msg != "")
                    msg += ",";

                msg += dt.Rows[i]["base_name"].ToString();
            }
          
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, " 缺少下列人員之銀行轉帳資料, 請於員工基本資料維護中輸入銀行帳號 : " + msg, "", "");
                this.Page = tempPage;
                return false;  
        }
        else
        {
            return true; 
        }
    }


    //轉帳資料查詢
    protected void Button_search_Click(object sender, EventArgs e)
    {
        dataGridView3();
    }

      protected void dataGridView3()
      {       
        SAL3114 sal3114 = new SAL3114();
        string strTrnDataYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        string strTrnDataKind = cmb_uc_calitem.SelectedValue;
        string strPayDate = "";
        if(UcDate1.Text != "")
         strPayDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);

        DataTable dt;
        dt = sal3114.newstep2Data(strTrnDataKind, strTrnDataYm);
          
   /*   string flow_id = "";    
        if (strTrnDataKind == "005")
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (flow_id != "")
                {
                    flow_id += " or ";
                }
                flow_id = " payod_merge_flow_id='" + GridView2.Rows[i].Cells[0].Text + "' ";
            }

            dt = sal3114.queryStep2Data
            (
            this.strOrgCode,
            strTrnDataYm,
            strTrnDataKind,
           "",
           "",
           "",
           "",
            strPayDate,
            flow_id,
            unit_multi_monthpay.Text
            );
        }
        else
        {
            if (cmbItemType2.SelectedValue == "") //發放種類第二層    
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "無資料可轉帳", "", "");
                this.Page = tempPage;
                return;
            }

            string[] strCodes = cmbItemType2.SelectedValue.Split('_');

            dt = sal3114.queryStep2Data
               (
               this.strOrgCode,
               strTrnDataYm,
               strTrnDataKind,
               strCodes[1],
               strCodes[3],
               strCodes[4],
               strCodes[5],
               strPayDate,
              "",
               unit_multi_monthpay.Text
               );
        }     
          */

      
            table1.Visible = true;
            GridView3.Visible = true;
            GridView3.DataSource = dt;
            GridView3.DataBind();
            if (GridView3.Rows.Count > 0)
            {
                amt.Visible = true;
                UcPager1.Visible = true;
            }
            else
            {
                amt.Visible = false;
                UcPager1.Visible = false;
            }
         
    }

    //勾選薪津項目帶出Gridview
    protected void chkOtherPayItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gridview1();
    }

    protected void Gridview1()
    {
       string strPAYITEMCODE="";
        for (int i = 0; i < chkOtherPayItems.Items.Count; i++)
        {
            if (chkOtherPayItems.Items[i].Selected)
            {
                if (strPAYITEMCODE != "")
                    strPAYITEMCODE += ",";

                strPAYITEMCODE +="'"+ chkOtherPayItems.Items[i].Value+"'";
            }
        }

        if (strPAYITEMCODE == "")
        {
            GridView1.Visible = false;
            tableGV1.Visible = false;
            GridView_trndata.Visible = false;
            return;
        }

        string strPayed =CheckBox1.Checked.ToString();
        string strTrnDataYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
         SAL3114 sal3114 = new SAL3114();
         DataTable dt = sal3114.queryPayItemGroup(strPAYITEMCODE, cmb_uc_calitem.SelectedValue, strTrnDataYm, strPayed);
              
             tableGV1.Visible = true;
             GridView1.Visible = true;
             GridView1.Columns[5].Visible = true;
             GridView1.Columns[6].Visible = true;
             GridView1.Columns[7].Visible = true;
             GridView1.DataSource = dt;
             GridView1.DataBind();             
             GridView1.Columns[5].Visible = false;
             GridView1.Columns[6].Visible = false;
             GridView1.Columns[7].Visible = false;
           

             if (dt.Rows.Count > 0)
             {
                 UcPager.Visible = true;
             }
             else
             {
                 UcPager.Visible = false;
             }         
    }

    //GridView_trndata 明細資料
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetail")//點選清單中的員工編號或員工姓名時 下方展開該筆資料的明細
        {
           int index = Convert.ToInt32(e.CommandArgument); //索引值
           string strPAYITEMMergeflowid = GridView1.Rows[index].Cells[1].Text.Replace("&nbsp;","");// 點選資料之批號
           SAL3114 sal3114 = new SAL3114();
           DataTable dt = sal3114.queryPayItemDetail(strPAYITEMMergeflowid);
        
            if (dt != null && dt.Rows.Count > 0)
           {
               GridView_trndata.Visible = true;
               GridView_trndata.DataSource = dt;
               GridView_trndata.DataBind();
           }
           else
           {
               GridView_trndata.Visible = false;
               Page tempPage = this.Page;
               CommonFun.MsgShow(ref tempPage,
                  CommonFun.Msg.Custom, "查無資料", "", "");
               this.Page = tempPage;
           }
        }
    }
    
    //計算應發總金額、轉帳總金額
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        if (!(GridView3.Rows.Count > 0))
        {
            return;
        }
        string trndata_amt="0";
        string payod_amt ="0";
        SAL3114 sal3114 = new SAL3114();
        // 參數
        string strTrnDataYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        string strTrnDataKind = cmb_uc_calitem.SelectedValue;
        string strPayDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);

        DataTable dt;
        //計算應發總金額
        if (strTrnDataKind == "005")
        {
             dt = sal3114.amt(strOrgCode, strTrnDataYm, p_payod_str.Text, strTrnDataKind, unit_multi_monthpay.Text, strPayDate);
        }
        else
        {
            string[] strCodes = cmbItemType2.SelectedValue.Split('_');


            dt = sal3114.amt2(strOrgCode, strTrnDataYm, strTrnDataKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5], unit_multi_monthpay.Text, strPayDate);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            payod_amt = dt.Rows[0]["payod_amt"].ToString();
        }
        int amt1 =(int)Convert.ToDouble(payod_amt);
        Label_payod_amt_1.Text = amt1.ToString();

        //計算轉帳總金額
        if (strTrnDataKind == "005")
        {
            dt = sal3114.amt3(strOrgCode, strTrnDataYm);
        }
        else
        {
            string[] strCodes = cmbItemType2.SelectedValue.Split('_');
            dt = sal3114.amt4(strOrgCode, strTrnDataYm, strTrnDataKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5]);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            trndata_amt = dt.Rows[0]["trndata_amt"].ToString();
        }

        Label_trndata_amt_1.Text = trndata_amt;

        if (trndata_amt != amt1.ToString())
        {
            GridView_trndata.Visible = false;         

            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "應發總金額與轉帳總金額不符請注意", "", "");
            this.Page = tempPage;
        }
    }

    //轉帳檔下載
    protected void Button_download_Click(object sender, EventArgs e)
    {
        string strYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        string strKind = cmb_uc_calitem.SelectedValue;
        string strDate ="";
        if(UcDate1.Text != "")
         strDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);
        
        string Kind2 = cmbItemType2.SelectedValue;
        if (Kind2 == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "無資料", "", "");
            this.Page = tempPage;
            return;
        }

        if (strDate == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇發放日期", "", "");
            this.Page = tempPage;
            return;
        }


          step3GetNstr(strKind,strYm);
          GetSaTdpm(strKind, Kind2);
          GetSaTdpf();
          GetFileName();
          DownloadStart(strDate, strKind, strYm, Kind2);

          if(p_tdpf_Bank.Text == "006")
          {
                //'' 彰化銀行的核證總數
                p_TT.Text = p_AA.Text + p_BB.Text + p_BB1.Text + p_CC.Text;
                if (p_TT.Text.Length > 10 )
                {
                    p_TT.Text = p_TT.Text.Substring(p_TT.Text.Length-10,10);
                }
          
               Page tempPage = this.Page;
               CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "核證總數為" + p_TT.Text, "", "");
               this.Page = tempPage;            
          }
          ExportFile();        
    }


    protected void step3GetNstr(string kind , string ym)
    {     
        string payo_string = "";
        string payod_string = "";
        string tdpm_string = "";
        string nKeyStr = "";             

        string flow = step3nstr.Text; //XXX,XXX,XXX        
        string[] flo = flow.Split(',');
        string nflow="";
        for( int i = 0 ; i < flo.Length ; i++)
        {
            if(nflow != "")
                nflow+= ",";            
              nflow +="'"+flo[i]+"'";
        }

        SAL3114 sal3114 = new SAL3114();
        DataTable dt = sal3114.step3str(kind,ym,nflow);
        
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string code_type = "";
                string code_no = "";
                string code = "";

                code_type = dt.Rows[i]["payo_kind_code_type"].ToString();
                code_no = dt.Rows[i]["payo_kind_code_no"].ToString();
                code = dt.Rows[i]["payo_kind_code"].ToString();


                if (payo_string != "")
                {
                    payo_string = payo_string + " Or ";
                    payod_string = payod_string + " Or ";
                    tdpm_string = tdpm_string + " Or ";
                    nKeyStr += ", ";
                }

                payo_string += "(payo_kind_code_type='" + code_type + "' and payo_kind_code_no='" + code_no + "' and payo_kind_code='" + code + "')";
                payod_string += "(payod_kind_code_type='" + code_type + "' and payod_kind_code_no='" + code_no + "' and payod_kind_code='" + code + "')";
                tdpm_string += "(tdpm_code_type='" + code_type + "' and tdpm_code_no='" + code_no + "' and tdpm_code='" + code + "')";
                nKeyStr += code;


            }
        }
        else
        {
            payo_string = "(payo_kind_code_type='xxx' and payo_kind_code_no='xxx' and payo_kind_code='xxx')";
            payod_string = "(payod_kind_code_type='xxx' and payod_kind_code_no='xxx' and payod_kind_code='xxx')";
            tdpm_string = "(tdpm_code_type='xxx' and tdpm_code_no='xxx' and tdpm_code='xxx')";
        }

        step3_p_payo_str.Text = payo_string;
        step3_p_payod_str.Text = payod_string;
        step3_p_tdpm_str.Text = tdpm_string;
        step3_p_nKeyStr.Text = nKeyStr;
        
    }


    protected void GetSaTdpm(string strKind, string Kind2)
    {
        SAL3114 sal3114 = new SAL3114();
        DataTable dt;

        if (strKind == "005")
        {
            dt = sal3114.step3Tdpm(strOrgCode, step3_p_tdpm_str.Text);
        }
        else
        {
            string[] strCodes = Kind2.Split('_');
            dt = sal3114.step3Tdpm2(strOrgCode, strKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5]);
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            p_tdpm_tdpf_seqno.Text = dt.Rows[0]["tdpm_tdpf_seqno"].ToString();
        }
    }

    protected void GetSaTdpf()
    {
        SAL3114 sal3114 = new SAL3114();
        DataTable dt = sal3114.GetSaTdpf(p_tdpm_tdpf_seqno.Text);
        if (dt.Rows.Count > 0 && dt != null)
        { 
            p_tdpf_Bank.Text = dt.Rows[0]["tdpf_bank"].ToString();
            p_tdpf_Bank_No.Text = dt.Rows[0]["tdpf_bank_no"].ToString();
            p_tdpf_Medi.Text =  dt.Rows[0]["tdpf_medi"].ToString();
            p_tdpf_Title.Text =  dt.Rows[0]["tdpf_title"].ToString();
            p_tdpf_Unit.Text = dt.Rows[0]["tdpf_unit"].ToString();
            p_tdpf_entno.Text = dt.Rows[0]["tdpf_entno"].ToString();
            p_tdpf_branch.Text = dt.Rows[0]["tdpf_branch"].ToString();
            p_tdpf_no.Text = dt.Rows[0]["tdpf_no"].ToString();
            p_tdpf_custom.Text = dt.Rows[0]["tdpf_custom"].ToString();
        }
    }


    protected void GetFileName()
    {       
        if (p_tdpf_Bank.Text == "001") // 第一銀行
        {
            p_filename.Text = "SALY8.DAT";            
        }
        else if (p_tdpf_Bank.Text == "002")// 富邦銀行
        {
            p_filename.Text = "HLC.TXT";            
        }
        else if (p_tdpf_Bank.Text == "003")// 華南銀行
        {
            p_filename.Text = "HNCBRMNEW.DAT";           
        }
        else if (p_tdpf_Bank.Text == "004") // 郵局
        {
            p_filename.Text = "PSBP-PAY-NEW";         
        }
        else if (p_tdpf_Bank.Text == "006")// 彰化銀行
        {
            p_filename.Text = "PCCUT.TXT";           
        }
        else if (p_tdpf_Bank.Text == "009")// 台北國際商業銀行
        {
            p_filename.Text = "SALARY.DAT";          
        }
        else if (p_tdpf_Bank.Text == "013")// 土地銀行
        {
            p_filename.Text = "PAYROLL";       
        }
        else if (p_tdpf_Bank.Text == "015")// 華泰銀行
        {
            p_filename.Text = "TAPEHC2";          
        }
        else if (p_tdpf_Bank.Text == "017")// 大台北商業銀行(台北一信)
        {
            p_filename.Text = "salary";           
        }
        else if (p_tdpf_Bank.Text == "018")// 上海銀行
        {
            p_filename.Text = "BT000120";           
        }
        else if (p_tdpf_Bank.Text == "020")// 玉山銀行
        {
            p_filename.Text = "ESB" +  SALARY.Logic.pub.lpad(p_tdpf_Unit, 4, "0").ToString() + ".txt";
      
        }
        else if (p_tdpf_Bank.Text == "022")// 國泰世華
        {
            p_filename.Text = "OBTDTA.TXT";          
        }
        else if (p_tdpf_Bank.Text == "025")  // 台新銀行
        {
            p_filename.Text = "TSBCUST.TXT";
        }
        else //其他
        {
            p_filename.Text = strOrgCode+".TXT";
        }

    }

    
    protected void DownloadStart(string strDate, string strKind, string strYm, string Kind2)
    {   
        SAL3114 sal3114 = new SAL3114();
        string temp_sum = "";
        string temp_count = "";
        string DateString = strDate;
        DataTable dt;
        if (strKind == "005")
        {         
            dt = sal3114.DownloadStart(strYm,strOrgCode);
        }
        else
        {
            string[] strCodes = Kind2.Split('_');
            dt = sal3114.DownloadStart2(strYm, strOrgCode, strKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5]);
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            temp_sum = dt.Rows[0]["trndata_amt"].ToString();
            temp_count = dt.Rows[0]["cnt"].ToString();
        }

        //SQLs1();
        if (strKind == "005")
        {
            dt = sal3114.SQLs1(strYm, strOrgCode, p_tdpm_tdpf_seqno.Text);
        }
        else
        {
            string[] strCodes = Kind2.Split('_');
            dt = sal3114.SQLs1_1(strYm, strOrgCode, strKind, strCodes[1], strCodes[3], strCodes[4], strCodes[5], p_tdpm_tdpf_seqno.Text);
        }
        string orgString = "";
        string oraTailString ="";

        if (dt.Rows.Count > 0 && dt != null)
        {
            if (p_tdpf_Bank.Text == "001")//第一銀行
            {             
            }
            else if (p_tdpf_Bank.Text == "002")//台北富邦商業銀行
            {
                orgString = "H";
                if (p_tdpf_custom.Text.Length > 7)
                {
                    orgString += p_tdpf_custom.Text.Substring(0, 7);
                }
                else
                {
                    orgString += SALARY.Logic.pub.get_zero(p_tdpf_custom, 7);
                }
                orgString = orgString + "00000";
                orgString = orgString + "************";
                orgString = orgString + SALARY.Logic.pub.get_zero((int.Parse(strDate.Substring(0,4)) - 1911), 3) + strDate.Substring(4, 2) + strDate.Substring(6, 2);
                orgString = orgString + SALARY.Logic.pub.get_zero(temp_sum, 11) + "00";
                orgString = orgString + "          ";
            }
            else if (p_tdpf_Bank.Text == "005")//中國信託之首行
            {
                orgString = "";
                if (p_tdpf_Bank_No.Text.Length >= 12)
                {
                    orgString = orgString + (p_tdpf_Bank_No.Text.Substring(0,12));
                }
                else
                {
                    orgString = orgString + SALARY.Logic.pub.get_zero(p_tdpf_Bank_No.Text, 12);
                }

                orgString = orgString +SALARY.Logic.pub.get_zero((int.Parse(strDate.Substring(0,4)) - 1911) + strDate.Substring(4,2) + strDate.Substring(6,2), 10) + "A";
            }
            else if (p_tdpf_Bank.Text == "006")//彰化銀行之首行
            { 
                            //'--- 首行設定
                            // '--- 區別碼(length:1; position:1)
                            orgString = "1"; //'--- 編號1
                            //'--- 企業編號(length: 8; position: 2)
                            orgString = orgString + SALARY.Logic.pub.rpad(p_tdpf_entno.Text, 8, " ");
                            //'--- 日期(length: 8; position: 10)
                            orgString = orgString + strDate;
                            //'--- 存款提號(legnth: 4; position: 18)
                            orgString = orgString + "2051";
                            //'--- 磁片來源(length: 5; position: 22)
                            orgString = orgString + "CUST ";
                            //'--- 性質別(length: 1; position: 27)
                            orgString = orgString + "1";
                            //'--- 公司統一編號(length: 10; position: 28)
                            orgString = orgString +SALARY.Logic.pub.lpad(p_tdpf_no, 10, " ");
                            //'--- 公司帳號(length: 14; position: 38)
                            orgString = orgString +SALARY.Logic.pub.lpad(p_tdpf_Bank_No, 14, " ");
                            //'--- 空白欄(length: 79; position: 52)
                            orgString = orgString + "                                                                               ";
                            //'--- 尾筆設定
                           // '--- 區別碼(length:1; position:1)
                            oraTailString = "3" ;//'--- 編號3
                           // '--- 企業編號(length: 8; position: 2)
                            oraTailString = oraTailString + SALARY.Logic.pub.rpad(p_tdpf_entno, 8, " ");
                           // '--- 日期(length: 8; position: 10)
                            oraTailString = oraTailString + strDate;
                           // '--- 存款提號(legnth: 4; position: 18)
                            oraTailString = oraTailString + "2051";
                           // '--- 空白欄(length: 5; position: 22)
                            oraTailString = oraTailString + "     ";
                           // '--- 成交總金額(length: 16; position: 27)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 14) + "00";
                           // '--- 成交總筆數(length: 10; position: 43)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 10);
                           // '--- 空白欄(length: 78; position: 53)
                            oraTailString = oraTailString + "                                                                              ";

            }
        /*    else if (p_tdpf_Bank.Text == "008")//台灣銀行之首行
            {               //'--- 首行設定
                            //'--- 資料登錄日期(length:6; position:1)
                            //'1001027 modify date(yyMMdd)
                            //'orgString = orgString & CStr(CInt(Now.ToString("yyyy")) - 1911) & Now.ToString("MMdd")
                            orgString = orgString + (int.Parse(DateTime.Now.ToString("yyyy")) - 1911).ToString().Substring((int.Parse(DateTime.Now.ToString("yyyy")) - 1911).ToString().Length-2,2) + DateTime.Now.ToString("MMdd");
                            //'--- 轉帳日期(length:6; position: 7)
                            if(strDate.Length == 8) 
                            {
                               string Date = strDate;
                               // '1001027 modify date(yyMMdd)
                               // 'DateString = CStr(CInt(Mid(DateString, 1, 4)) - 1911) & Mid(DateString, 5, 8)
                                Date = (int.Parse(Date.Substring(0, 4)) - 1911).ToString().Substring((int.Parse(Date.Substring(0, 4)) - 1911).ToString().Length-2,2) + Date.Substring(4,4);
                                orgString = orgString + Date;
                            }
                            //'--- 分行代號(length: 3; position: 13)
                            orgString = orgString + p_tdpf_branch.Text;
                            //'--- 客戶營利統一編號(legnth: 8; position: 16)
                            orgString = orgString + p_tdpf_no.Text;
                            //'--- 客戶代號(length: 3; position: 24)
                            orgString = orgString + p_tdpf_custom.Text;
                            //'--- 保留欄位 全部補0(length: 14; position: 27)
                            orgString = orgString + "00000000000000";
                            //'--- 轉帳總金額(length: 12; position: 41)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_sum, 12) + SALARY.Logic.pub.get_zero(temp_count, 4) + "   9";
                            //'                createdFile.Write(orgString)  
            }*/
            else if (p_tdpf_Bank.Text == "009")//台北商銀之首行
            {
                            //'--- 識別欄(length: 13)
                            orgString = "0000000000000";
                            //'--- 企業編號(length: 5)
                            orgString = orgString + SALARY.Logic.pub.get_zero(p_tdpf_entno.Text, 5);
                            //'--- 撥帳日(length: 6)
                            string Date = (int.Parse(DateString.Substring(0, 4)) - 1911) + SALARY.Logic.pub.get_zero((DateString.Substring(4, 2)), 2) + SALARY.Logic.pub.get_zero((DateString.Substring(6, 2)), 2);
                            orgString = orgString + Date;
                            //'--- 總筆數(length: 6)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_count, 6);
                            //'--- 總金額(length: 13)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_sum, 13);
                            //'--- 小數位數(length: 2)
                            orgString = orgString + "00";
                            //'--- 借貸別(length: 1) D: 扣款; C: 存入
                            orgString = orgString + "C";
                            //'--- 備用欄位(length: 4) 0000
                            orgString = orgString + "0000";
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "010")  //台灣中小企業銀行
            { 
                            orgString = "";
                            orgString = "*";
                            orgString = orgString + (p_tdpf_Bank_No.Text.Substring(0,7));

                          string  Date = (int.Parse(DateString.Substring(0, 4)) - 1911) + (DateString.Substring(4, 2)) + (DateString.Substring(6, 2));
                          orgString = orgString + SALARY.Logic.pub.get_zero(Date, 7) + SALARY.Logic.pub.get_zero(temp_count, 9) + SALARY.Logic.pub.get_zero(temp_sum, 11) + "0" + SALARY.Logic.pub.lpad("", 92, " ");
            }
            else if (p_tdpf_Bank.Text == "013")  //土地銀行
            {
                   // '-- 首錄 orgString
                   //         '--- 錄別
                            orgString = "1";
                           // '--- 發件單位(客戶委託編號)
                            orgString = orgString + SALARY.Logic.pub.rpad(p_tdpf_custom, 8, " ");
                            //'--- 土銀收件單位
                            orgString = orgString + SALARY.Logic.pub.rpad(p_tdpf_branch, 8, " ");
                            //'--- 轉帳類別
                            orgString = orgString + "20000";
                            //'--- 轉帳日期
                            //''民國呈現(yyyymmdd)
                           string Date = SALARY.Logic.pub.lpad(int.Parse(DateString.Substring(0, 4)) - 1911 + DateString.Substring(4, 2) + DateString.Substring(6, 2), 8, "0").ToString();
                            orgString = orgString + Date;
                            //'--- 性質別
                            orgString = orgString + "1";
                            //'--- 保留欄
                            orgString = orgString + new String(' ', 169);

                            //'--- 跳行記號
                            //   orgString = orgString;

                            //'-- 尾錄 oraTailString
                            //'--- 錄別
                            oraTailString = "3";
                            //'--- 發件單位(客戶委託編號)
                            //'--- 土銀收件單位
                            //'--- 轉帳類別
                            //'--- 轉帳日期
                            //'(共29碼 同首錄)
                            oraTailString = oraTailString +orgString.Substring(1,29);

                            //'--- 成交總金額
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 14) + "00";
                            //'--- 成交總筆數
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 10);
                            //'--- 未成交總金額
                            oraTailString = oraTailString + "0000000000000000";
                            //'--- 未成交總筆數
                            oraTailString = oraTailString + "0000000000";
                            //'--- 保留欄
                            oraTailString = oraTailString + new String(' ', 118);
                            //'--- 跳行及檔尾記號
                            // oraTailString = oraTailString
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "015") //華泰銀行
            { 
                          //  '首行設定
                            //'--- 識別碼(length:1; position: 1)
                            orgString = "1";
                            //'--- 發件單位(length:8; position: 2)
                            orgString = orgString + "        ";
                            //'--- 收件單位(length:8; position: 10)
                            orgString = orgString + "102     ";
                            //'---轉帳類別(length:3; position: 18)
                            orgString = orgString + "201";
                            //'--- 轉帳日期(length: 6; position: 21)

                           string Date = strDate;

                            Date = (int.Parse(Date.Substring(0, 4)) - 1911) + (Date.Substring(4,4));
                            orgString = orgString + SALARY.Logic.pub.get_zero(Date, 7);

                            //'---代扣記號(length:1; position: 27)
                            orgString = orgString + "1";
                            //'---(length:93; position: 28)
                            orgString = orgString + "                                                                                             ";

                            //'--- 尾筆設定
                            //'--- 區別碼(length:1; position: 1)
                            oraTailString = "3";
                            //'--- 發件單位(length:8; position: 2)
                            oraTailString = oraTailString + "        ";
                            //'--- 收件單位(length:8; position: 10)
                            oraTailString = oraTailString + "102     ";
                            //'---轉帳類別(length:3; position: 18)
                            oraTailString = oraTailString + "201";
                            //'--- 轉帳日期(length: 6; position: 21)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(Date, 7);

                            //'--- 轉帳總金額(length: 16; position: 27)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 14);
                            oraTailString = oraTailString + "00";
                            //'--- 轉帳總件數(length: 5; position: 43)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 10);

                            //'--- 空白欄(length: 68; position: 48)
                            oraTailString = oraTailString + "                                                       ";
                            //' createdFile.WriteLine(orgString)
            }
            else if (p_tdpf_Bank.Text == "016") //中國國際商業銀行
            {
                 //'--- 首行設定
                   //         '--- 區別碼(length:1; position:1)
                            orgString = "1";
                     //       '--- 發件單位(length: 8; position: 2)
                            orgString = orgString + SALARY.Logic.pub.rpad(p_tdpf_branch, 8, " ");
                       //     '--- 收件單位(length: 8; position:10)
                            orgString = orgString + "017     ";
                         //   '--- 轉帳類別(length: 3; position:18)
                            orgString = orgString + "201" ;
                           // '--- 入帳日期(length: 6; position: 21)               
                           string Date = (int.Parse(strDate.Substring(0,4)) - 1911) + (strDate.Substring(4,4));
                                  Date = Date.Substring(Date.Length - 6 ,6);
                            orgString = orgString + Date;

                            //'--- 性質別(length: 1; position: 27)
                            orgString = orgString + "1";
                            //'--- 資料類別(length: 2; position: 28)
                            orgString = orgString + "01";
                            //'--- 空白欄(length: 91; position: 30)
                            orgString = orgString +  new String(' ', 91);

//                            '--- 尾筆設定
  //                          '--- 區別碼(length:1; position: 1)
                            oraTailString = "3";
    //                        '--- 發件單位(length: 8; position: 2)
                            oraTailString = oraTailString + p_tdpf_branch.Text;
      //                      '--- 收件單位(length: 8; position:10)
                            oraTailString = oraTailString + "017     ";
        //                    '--- 轉帳類別(length: 3; position:18)
                            oraTailString = oraTailString + "201";
                      //      '--- 入帳日期(length: 6; position: 21)
                            oraTailString = oraTailString + Date;

                        //    '--- 薪轉總金額(length: 16; position: 27)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 14) + "00";
                          //  '--- 薪轉總筆數(length: 10; position: 43)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 10);
                           // '--- 未成交總金額(length: 16; position: 53)
                            oraTailString = oraTailString + "0000000000000000";
                            //'--- 未成交總筆數(length: 10; position: 69)
                            oraTailString = oraTailString + "0000000000";
                            //'--- 空白欄(length: 42; position: 79)
                            oraTailString = oraTailString + new String(' ', 42);
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "017") //台北一信之尾筆
            {
                 // '--- 尾筆設定
                   //         '--- 識別碼(length:1; position: 1)
                            oraTailString = "3";
                     //       '--- 受託單位(length: 7; position: 2)
                            oraTailString = oraTailString + p_tdpf_custom.Text;
                       //     '--- 轉帳日期(length: 7; position: 9)

                            string Date = (int.Parse(strDate.Substring(0, 4)) - 1911) + (strDate.Substring(4, 4));
                           oraTailString = oraTailString + SALARY.Logic.pub.get_zero(Date, 7);

                         //   '--- 企業編號(length: 5; position: 16)
                            oraTailString = oraTailString + p_tdpf_entno.Text;
                         //   '--- 轉帳摘要(length: 3; position: 21)
                            oraTailString = oraTailString + "071";

                        //    '--- 轉帳總件數(length: 5; position: 24)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 5);
                        //    '--- 轉帳總金額(length: 15; position: 29)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 13);
                            oraTailString = oraTailString + "00";

                        //    '--- 空白欄(length: 57; position: 44)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero("", 57);
            }
            else if (p_tdpf_Bank.Text == "018") //上海銀行
            {
                orgString = p_tdpf_Bank_No.Text;
                        //    '尾筆
                            oraTailString = "END$.";
                          //  'createdFile.WriteLine(orgString)
            }
            else if (p_tdpf_Bank.Text == "021") //安泰銀行
            {
                            //'--- 首行設定
                            //'--- 區別碼(length:1; position:1)
                            orgString = "1";
                            //'--- 轉帳組別(length: 11; position: 2)
                            orgString = orgString + SALARY.Logic.pub.rpad(p_tdpf_entno, 11, " ");
                            //'--- 轉帳日期(length: 7; position: 13)

                            DateString = (int.Parse(strDate.Substring(0, 4)) - 1911) + (strDate.Substring(4,4));
                            DateString = SALARY.Logic.pub.lpad(DateString, 7, "0").ToString();
                            orgString = orgString + DateString;

                            //'--- 性質別(length: 1; position: 20)
                            orgString = orgString + " ";
                            //'--- 保留一(空白欄)(length: 44; position: 21)
                            orgString = orgString + new String(' ', 44);

                            //'--- 尾筆設定
                            //'--- 區別碼(length:1; position: 1)
                            oraTailString = "3";
                            //'--- 轉帳組別(length: 11; position: 2)
                            oraTailString = oraTailString + p_tdpf_entno.Text;
                            //'--- 轉帳日期(length: 7; position: 13)
                            oraTailString = oraTailString + DateString;

                            //'--- 薪轉總筆數(length: 14; position: 20)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 14);
                            //'--- 薪轉總金額(length: 14; position: 34)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 12) + "00";
                            //'--- 保留三(空白欄)(length: 17; position: 48)
                            oraTailString = oraTailString + new String(' ', 17);
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "024") //寶華銀行
            {
                            // '--- 首行設定
                            //'--- 磁片產生日期(6)
                            orgString = (int.Parse(DateTime.Now.ToString("yyyy")) - 1911).ToString() + DateTime.Now.ToString("MMdd");
                            //'--- 預定轉帳日期(6)

                            DateString = (int.Parse(strDate.Substring(0,4)) - 1911) + (strDate.Substring(4,4));
                            orgString = orgString + DateString;
                                
                            //'--- 代辦分行別代號(3)
                            orgString = orgString + p_tdpf_branch.Text;
                            //'--- 統一編號(8)
                            orgString = orgString + p_tdpf_no.Text;
                            //'--- 委辦客戶代號(3)
                            orgString = orgString + p_tdpf_custom.Text;
                            //'--- 委辦客戶帳號(14)
                            orgString = orgString + SALARY.Logic.pub.lpad(p_tdpf_Bank_No, 14, "0");
                            //'--- 轉帳總金額(12)

                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_sum, 12);
                            //'--- 轉帳員工總筆數(4)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_count, 4);
                            //'--- 保留空白(4)
                            orgString = orgString + new String(' ', 4);
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "025") //台新銀行 首筆 設定
            {
                            //'--- 企業編號(length: 4; position: 1)
                            orgString = p_tdpf_entno.Text.Trim();
                            //'--- 委辦帳號(length: 14; position: 5)
                            orgString = orgString + SALARY.Logic.pub.lpad(p_tdpf_Bank_No, 14, "0");
                            //'--- 轉帳日期(length: 8; position: 19)
                            orgString = orgString + SALARY.Logic.pub.get_zero(DateString, 8);
                            //'--- 轉帳項目(length: 3; position: 27)
                            orgString = orgString + "900";
                            //'--- 薪轉總金額(length: 13; position: 30)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_sum, 11) + "00";
                            //'--- 薪轉總筆數(length: 7; position: 43)
                            orgString = orgString + SALARY.Logic.pub.get_zero(temp_count, 7);
                            //'--- (空白欄)(length: 22; position: 50)
                            orgString = orgString + new String(' ', 22);
                            //'--- 傳輸結果(length: 1; position: 72)
                            orgString = orgString + "0";
                            //'createdFile.Write(orgString)
            }
            else if (p_tdpf_Bank.Text == "022") //國泰世華銀行格式調整(新增首尾行)
            {
                            //''--	首行
                            //'---	區碼別(固定1)			(長度: 1; 位置: 1)
                            orgString = "1";
                            //'---	發件單位(固定000)		(長度: 3; 位置: 2)
                            orgString = orgString + "000";
                            //'---	發件單位-客戶代號		(長度: 5; 位置: 5)
                            orgString = orgString + p_tdpf_custom.Text;
                            //'---	收件單位(固定01300000)	(長度: 8; 位置: 10)
                            orgString = orgString + "01300000";
                            //'----	指定扣帳日期(西元YYYYMMDD)	(長度: 8; 位置: 18)
                            orgString = orgString + strDate;
                            //'---	轉帳類型(900-薪資轉帳)	(長度: 3; 位置: 26)
                            orgString = orgString + "900";
                            //'---	借貸別 & 保留 (空白X2)	(長度: 2; 位置: 29)
                            orgString = orgString + new String(' ',2);
                            //'---	性質別(固定1)			(長度: 1; 位置: 31)
                            orgString = orgString + "1";
                            //'---	批號(固定99)			(長度: 2; 位置: 32)
                            orgString = orgString +"99";
                            //'---	保留欄(167個空白)		(長度: 167; 位置: 34)
                            orgString = orgString + new String(' ',167);
                                
                            //''--	尾行
                            //'---	區碼別(固定3)			(長度: 1; 位置: 1)
                            oraTailString = "3";
                            //'---	發件單位(固定000)		(長度: 3; 位置: 2)
                            oraTailString = oraTailString + "000";
                            //'---	發件單位-客戶代號		(長度: 5; 位置: 5)
                            oraTailString = oraTailString + p_tdpf_custom.Text;
                            //'---	收件單位(固定01300000)	(長度: 8; 位置: 10)
                            oraTailString = oraTailString + "01300000";
                            //'----	指定扣帳日期(西元YYYYMMDD)	(長度: 8; 位置: 18)
                            oraTailString = oraTailString + strDate;
                            //'---	轉帳類型(900-薪資轉帳)	(長度: 3; 位置: 26)
                            oraTailString = oraTailString + "900";
                            //'---	借貸別 & 保留 (空白X2)	(長度: 2; 位置: 29)
                            oraTailString = oraTailString + new String(' ',2);
                            //'---	檢核欄位(固定+)			(長度: 1; 位置: 30)
                            oraTailString = oraTailString + "+";
                            //'---	交易總金額				(長度: 15; 位置: 31)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_sum, 13) + "00";
                            //'---	交易總筆數				(長度: 10; 位置: 46)
                            oraTailString = oraTailString + SALARY.Logic.pub.get_zero(temp_count, 10);
                            //'---	檢核欄位(固定+)			(長度: 1; 位置: 56)
                            oraTailString = oraTailString + "+";
                            //'---	成功總金額(固定000000000000000)	(長度: 15; 位置: 57)	P.S末兩碼為小數位數
                            oraTailString = oraTailString + "000000000000000";
                            //'---	成功總筆數(固定0000000000)		(長度: 10; 位置: 72)
                            oraTailString = oraTailString + "0000000000";
                           // '---	檢核欄位(固定+)			(長度: 1; 位置: 82)
                            oraTailString = oraTailString + "+";
                            //'---	不成功總金額(固定000000000000000)	(長度: 15; 位置: 83)	P.S末兩碼為小數位數
                            oraTailString = oraTailString + "000000000000000";
                            //'---	不成功總筆數(固定0000000000)		(長度: 10; 位置: 98)
                            oraTailString = oraTailString + "0000000000";
                            //'---	保留欄(92個空白)		(長度: 92; 位置: 108)
                            oraTailString = oraTailString + new String(' ',92);
            }
        }
        int i = 0;
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            i = i + 1;
            if (p_tdpf_Bank.Text == "006")//彰化銀行
            {
                        string line_str = dt.Rows[j]["trndata_content"].ToString();
                        string line_date = line_str.Substring(20, 6);            // '--撥帳日期
                        string line_accno = line_str.Substring(26,14);            //    '--帳號
                        string line_accno1 = line_accno.Substring(line_accno.Length-6, 6) ;     //  '--帳號末6位
                        string line_amt = line_str.Substring(40,12);            // '--轉帳金額(取整數,不含小數)
                        p_AA.Text = line_date;                                   // '-本次轉帳資料預定撥帳日期
                      if(long.Parse(line_amt) > long.Parse(p_BB1.Text))
                      {
                            p_BB.Text = line_accno1;       // '-本次轉帳資料單筆最高轉帳金額帳戶之帳號(取6位)
                            p_BB1.Text = line_amt ;         // '-本筆帳戶之轉帳金額
                      }
                      p_CC.Text = (long.Parse(p_CC.Text) + long.Parse(line_accno1)).ToString();     // '-本次資料各筆帳號之累計數(取每一筆帳號6位,予以累加)
            }

                      if (i == 1)
                      { 
                          trndatastring.Text += dt.Rows[j]["trndata_content"].ToString();
                      }
                      else
                      {
                          trndatastring.Text += System.Environment.NewLine + dt.Rows[j]["trndata_content"].ToString();
                      } 
        }

        if( orgString != "" )
        {
           Label_download.Text += orgString + System.Environment.NewLine ;
        }

        if (trndatastring.Text != "" )
        {
            Label_download.Text += trndatastring.Text;
        }

        if (oraTailString != "")
        {
            Label_download.Text += System.Environment.NewLine + oraTailString + System.Environment.NewLine;
        }

        if (p_tdpf_Bank.Text == "008")
        {
            Label_download.Text = SALARY.Logic.DES_ECB.enCrypt(Label_download.Text, ConfigurationManager.AppSettings["DES_KEY"]);
        }

    }

    protected void ExportFile()
    {
        StringBuilder s = new StringBuilder();
        s.Append(this.Label_download.Text);
        this.Label_download.Text = s.ToString(); 

        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
        string oExcelFileName = p_filename.Text;

        Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");

        Context.Response.ContentType = "text/plain";
        Context.Response.AddHeader("Content-Disposition", "attachment;filename=" + oExcelFileName);
        this.plExport1.RenderControl(oHtmlTextWriter);

        Context.Response.Write(s.ToString());
        Context.Response.End();      
    }



    //轉帳清冊列印
    protected void Button_print_Click(object sender, EventArgs e)
    {
        string strYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        string strKind = cmb_uc_calitem.SelectedValue;
        string Kind2 = cmbItemType2.SelectedValue;

        if (Kind2 == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "無資料", "", "");
            this.Page = tempPage;
            return;
        }

        SAL3114 sal3114 = new SAL3114();
        DataTable Reportdata = sal3114.Reportdata(strOrgCode, strKind, strYm);
             
        int sum =0;

        if (Reportdata != null && Reportdata.Rows.Count > 0)
        {
            Reportdata.Columns.Add("total");
            Reportdata.Columns.Add("page");
            int count = 0; //計數 30筆
            for (int i = 0; i < Reportdata.Rows.Count; i++)
            {                   
                sum += int.Parse(Reportdata.Rows[i]["轉帳金額"].ToString());

                if (count == 29)
                {

                    for (int j = i; j >= i - 29; j--)
                    {
                        Reportdata.Rows[j]["total"] = sum;
                        Reportdata.Rows[j]["page"] = count+1;
                    }

                    sum = 0;
                    count = 0;
                }
                else
                {
                    count++;
                }

                if (i == Reportdata.Rows.Count - 1)
                {
                    for (int j = i; j >= i-(i % 30); j--)  
                    {
                        Reportdata.Rows[j]["total"] = sum;
                        Reportdata.Rows[j]["page"] = count ;
                    }
                }
            }
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
            CommonFun.Msg.Custom, "無資料", "", "");
            this.Page = tempPage;
            return;
        }
               
   
        // 匯出動作
        CommonLib.DTReport rpt;
        rpt = new CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL3114.mht"), Reportdata);
        rpt.ExportFileName = "轉帳清冊列印";

        // 參數部分
        string[] strParams = new string[3];

        strParams[0] = Reportdata.Rows[0]["表首之轉帳帳號"].ToString(); //表首之轉帳帳號

        if (UcDate1.Text != "")
        {
            strParams[1] = "民國" + UcDate1.Text.Substring(0, 3) + "年" + UcDate1.Text.Substring(3, 2) + "月" + UcDate1.Text.Substring(5, 2) + "日";
        }
        else
        {
            strParams[1] = "民國" +  " 年" + " 月" +  " 日";
        }

        if (strKind != "" && Kind2 != "")
        {
            strParams[2] = cmb_uc_calitem.SelectedItem.Text + "*" + cmbItemType2.SelectedItem.Text;
        }
        else
        {
            strParams[2] = cmb_uc_calitem.SelectedItem.Text;
        }

        rpt.Param = strParams;
        rpt.PageGroupColumns = new string[] { "total" };
        rpt.PageGroupKeyColumns = new string[] { "total" };
        rpt.ExportToWord(); 
    
    }

    //EMail傳送作業
    protected void Button_EMail_Click(object sender, EventArgs e)
    {
        string strKind = cmb_uc_calitem.SelectedValue;     
        string strYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
        string strDate = "";
        if(UcDate1.Text != "")
         strDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);

        if (strDate == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇發放日期", "", "");
            this.Page = tempPage;
            return;
        }

        string Kind2 = cmbItemType2.SelectedValue;
        string[] strCodes = Kind2.Split('_');

        SAL3114 sal3114 = new SAL3114();
        DataTable data;

        /*
        DataTable SAPAYOD = new DataTable(); //應發
        DataTable SAPAYOD_1 = new DataTable(); //應扣
        int amt_1 = 0;
        int amt_2 = 0;
        int total = 0;
     */
                  
        if (strKind != "005")
        {           
             data = sal3114.step5_1(strOrgCode, strKind, strYm, strDate); //第一層清單
             if (data != null && data.Rows.Count > 0)
             {
                 DataTable mail = sal3114.getemail(LoginManager.UserId);
                 string PAYO_SEQNO = "";
                 for (int i = 0; i < data.Rows.Count; i++) //逐筆查詢
                 {
                     /*
                     PAYO_SEQNO = data.Rows[i]["PAYO_SEQNO"].ToString();  //第一層員工編號     
                     string Payo_prono = data.Rows[i]["Payo_prono"].ToString();

                     SAPAYOD = sal3114.step5_5(strOrgCode, strKind, strYm, strDate, PAYO_SEQNO, strCodes[3], strCodes[4], strCodes[5]); //應發
                     SAPAYOD_1 = sal3114.step5_6(strOrgCode, strKind, strYm, strDate, PAYO_SEQNO, strCodes[3], strCodes[4], strCodes[5]); //應扣                     

                     amt_1 = 0;   //應發合計
                     amt_2 = 0;   //應扣合計
                     total = 0;     //實發數

                     if (SAPAYOD != null && SAPAYOD.Rows.Count > 0)
                     {
                         SAPAYOD.Columns.Add("item_name", typeof(string));    //item name
                         for (int j = 0; j < SAPAYOD.Rows.Count; j++)
                         {
                             Double amt = Convert.ToDouble(SAPAYOD.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a = (int)amt;
                             amt_1 += a;

                             string payod_code_sys = SAPAYOD.Rows[i]["payod_code_sys"].ToString();
                             string payod_code_type = SAPAYOD.Rows[i]["payod_code_type"].ToString();
                             string payod_code_no = SAPAYOD.Rows[i]["payod_code_no"].ToString();
                             string payod_code = SAPAYOD.Rows[i]["payod_code"].ToString();


                             string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, strOrgCode
                                    , Payo_prono, payod_code);

                             SAPAYOD.Rows[i]["item_name"] = rv;
                         }
                     }

                     if (SAPAYOD_1 != null && SAPAYOD_1.Rows.Count > 0)
                     {
                         SAPAYOD_1.Columns.Add("item_name", typeof(string));    //item name
                         for (int j = 0; j < SAPAYOD_1.Rows.Count; j++)
                         {
                             Double amt = Convert.ToDouble(SAPAYOD_1.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a = (int)amt;
                             amt_2 += a;

                             string payod_code_sys = SAPAYOD_1.Rows[i]["payod_code_sys"].ToString();
                             string payod_code_type = SAPAYOD_1.Rows[i]["payod_code_type"].ToString();
                             string payod_code_no = SAPAYOD_1.Rows[i]["payod_code_no"].ToString();
                             string payod_code = SAPAYOD_1.Rows[i]["payod_code"].ToString();

                             string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, strOrgCode
                              , Payo_prono, payod_code);

                             SAPAYOD_1.Rows[i]["item_name"] = rv;
                         }
                     }
                     //實發數
                     total = amt_1 - amt_2;

                      */
                     //寄送EMAIL 
                     string email = data.Rows[i]["base_email"].ToString();
                     string PAYO_IDNO = data.Rows[i]["PAYO_IDNO"].ToString();
                     string PAYO_NAME = data.Rows[i]["PAYO_NAME"].ToString();
                     string lv = data.Rows[i]["lv"].ToString();
                     string dcode = data.Rows[i]["dcode"].ToString();
               //      EMAIL(email, PAYO_IDNO, PAYO_NAME, lv, dcode, SAPAYOD, SAPAYOD_1, amt_1, amt_2, total);


                     string msg = cmb_uc_calitem.SelectedItem + "預計於" + (int.Parse(strDate.Substring(0,4))-1911).ToString()
                         + "年" + strDate.Substring(4, 2) + "月" + strDate .Substring(6,2)+ "日撥款，請於撥款後二日內核對。";

                     string frommail = mail.Rows[0]["base_email"].ToString();
                     string fromname = mail.Rows[0]["base_name"].ToString();

                     CommonFun.SendMail(frommail, email, fromname, PAYO_NAME, msg, msg, "", TextBox1.Text);

                 }
             }
             else
             {
                 Page tempPage = this.Page;
                 CommonFun.MsgShow(ref tempPage,
                 CommonFun.Msg.Custom, "無資料" , "", "");
                 this.Page = tempPage;
                 return;
             }
        }
        else // =005
        {
            string strPAYOMergeflowid = "";//畫面勾選之批號
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch1");
                if (ch.Checked)
                {
                    if (strPAYOMergeflowid != "")
                        strPAYOMergeflowid += ",";
                    strPAYOMergeflowid += "'"+GridView1.Rows[i].Cells[1].Text+"'";
                }
            }         
             data = sal3114.step5_2(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid);

             if (data != null && data.Rows.Count > 0)
             {
                 DataTable mail = sal3114.getemail(LoginManager.UserId);
                 string PAYO_SEQNO = "";
                 for (int i = 0; i < data.Rows.Count; i++) //逐筆查詢
                 {
                     /*
                     PAYO_SEQNO = data.Rows[i]["PAYO_SEQNO"].ToString();  //第一層員工編號       
                     string Payo_prono = data.Rows[i]["Payo_prono"].ToString();
                     SAPAYOD = sal3114.step5_3(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid, PAYO_SEQNO); //應發
                     SAPAYOD_1 = sal3114.step5_4(strOrgCode, strKind, strYm, strDate, strPAYOMergeflowid, PAYO_SEQNO); //應扣   

                     amt_1 = 0;
                     amt_2 = 0;
                     total = 0;
                     // 應發合計
                     if (SAPAYOD != null && SAPAYOD.Rows.Count > 0)
                     {
                         SAPAYOD.Columns.Add("item_name", typeof(string));    //item name
                         for (int j = 0; j < SAPAYOD.Rows.Count; j++)
                         {
                             Double amt = Convert.ToDouble(SAPAYOD.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a = (int)amt;
                             amt_1 += a;

                             string payod_code_sys = SAPAYOD.Rows[i]["payod_code_sys"].ToString();
                             string payod_code_type = SAPAYOD.Rows[i]["payod_code_type"].ToString();
                             string payod_code_no = SAPAYOD.Rows[i]["payod_code_no"].ToString();
                             string payod_code = SAPAYOD.Rows[i]["payod_code"].ToString();


                             string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, strOrgCode
                                    , Payo_prono, payod_code);

                             SAPAYOD.Rows[i]["item_name"] = rv;
                         }
                     }
                     //應扣合計
                     if (SAPAYOD_1 != null && SAPAYOD_1.Rows.Count > 0)
                     {
                         SAPAYOD_1.Columns.Add("item_name", typeof(string));   //item name
                         for (int j = 0; j < SAPAYOD_1.Rows.Count; j++)
                         {
                             Double amt = Convert.ToDouble(SAPAYOD_1.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a = (int)amt;
                             amt_2 += a;

                             string payod_code_sys = SAPAYOD_1.Rows[i]["payod_code_sys"].ToString();
                             string payod_code_type = SAPAYOD_1.Rows[i]["payod_code_type"].ToString();
                             string payod_code_no = SAPAYOD_1.Rows[i]["payod_code_no"].ToString();
                             string payod_code = SAPAYOD_1.Rows[i]["payod_code"].ToString();

                             string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, strOrgCode
                              , Payo_prono, payod_code);

                             SAPAYOD_1.Rows[i]["item_name"] = rv;
                         }
                     }
                     //實發數
                     total = amt_1 - amt_2;

                       */
                     //寄送EMAIL
                     string email = data.Rows[i]["base_email"].ToString();
                     string PAYO_IDNO = data.Rows[i]["PAYO_IDNO"].ToString();
                     string PAYO_NAME = data.Rows[i]["PAYO_NAME"].ToString();
                     string lv = data.Rows[i]["lv"].ToString();
                     string dcode = data.Rows[i]["dcode"].ToString();
       //              EMAIL(email, PAYO_IDNO, PAYO_NAME, lv, dcode, SAPAYOD, SAPAYOD_1, amt_1, amt_2, total);
                     
                     string msg = cmb_uc_calitem.SelectedItem + "預計於" + (int.Parse(strDate.Substring(0, 4)) - 1911).ToString()
                        + "年" + strDate.Substring(4, 2) + "月" + strDate.Substring(6, 2) + "日撥款，請於撥款後二日內核對。";
                                       
                     string frommail = mail.Rows[0]["base_email"].ToString();
                     string fromname = mail.Rows[0]["base_name"].ToString();

                     CommonFun.SendMail(frommail, email, fromname, PAYO_NAME, msg, msg, "", TextBox1.Text);
                 }
             }
             else
             {
                 Page tempPage = this.Page;
                 CommonFun.MsgShow(ref tempPage,
                 CommonFun.Msg.Custom, "無資料", "", "");
                 this.Page = tempPage;
                 return;
             }
        }

    }




    protected void EMAIL(string email, string PAYO_IDNO, string PAYO_NAME, string lv, string dcode, DataTable SAPAYOD, DataTable SAPAYOD_1
      , int amt_1, int amt_2, int total)
        {
            string strYm = cmbYearMonth.Year.ToString().PadLeft(4, '0') + cmbYearMonth.Month.ToString().PadLeft(2, '0');
            string strDate = "";
            if (UcDate1.Text != "")
                strDate = Convert.ToString(Convert.ToInt32(UcDate1.Text.Substring(0, 3)) + 1911).PadLeft(4, '0') + UcDate1.Text.Substring(3, 4);
        
                     MailMessage message = new MailMessage("", email);//MailMessage(寄信者, 收信者)
                     message.IsBodyHtml = true;
                     message.BodyEncoding = System.Text.Encoding.UTF8;//E-mail編碼
                     message.SubjectEncoding = System.Text.Encoding.UTF8;//E-mail編碼
                     message.Priority = MailPriority.Normal;//設定優先權
             
                     string Subject = (int.Parse(strYm.Substring(0, 4)) - 1911) + "年" + strYm.Substring(4, 2) + "月份["
                                       + cmb_uc_calitem.SelectedItem + "]薪資單";//E-mail主旨  
                     string Body = "<table width=800 >"//E-mail內容
                                  + "<tr><td align=\"center\" width=400 colspan=3 >" + "入帳日期：民國"
                                                             + (int.Parse(strDate.Substring(0, 4)) - 1911) + "年"
                                                             + strDate.Substring(4, 2) + "月"
                                                             + strDate.Substring(6, 2) + "日 </td>"
                                                             + "<td align=\"center\" width=400 colspan=3>" + "寄表日期：民國"
                                                             + (int.Parse(DateTime.Now.ToString("yyyy")) - 1911) + "年"
                                                             + DateTime.Now.ToString("MM") + "月"
                                                             + DateTime.Now.ToString("dd") + "日"
                                                             + DateTime.Now.ToString("HH") + "時"
                                                             + DateTime.Now.ToString("mm") + "分" + "</td></tr>";
                     Body += "<tr><td align=\"center\" colspan=6 style=\"border-width: 1px; border-style: solid\">"
                                    + (int.Parse(cmbYearMonth.Year.ToString()) - 1911) + "年" + cmbYearMonth.Month.ToString() + "月份員工薪資單"
                                    + "<br>[" + cmb_uc_calitem.SelectedItem.Text + "]</td></tr>";
                     Body += "<tr><td width=400 align=\"left\" colspan=3 style=\"border-width: 1px; border-style: solid\">身分證號：" + PAYO_IDNO + "</td><td width=400 align=\"left\" colspan=3 style=\"border-width: 1px; border-style: solid\">姓名：" + PAYO_NAME + "</td></tr>";
                     Body += "<tr><td width=400 align=\"left\" colspan=3 style=\"border-width: 1px; border-style: solid\">職等：" + lv + "</td><td  width=400 align=\"left\" colspan=3 style=\"border-width: 1px; border-style: solid\">職稱：" + dcode + "</td></tr>";
                     Body += "<tr><td width=400 align=\"center\" colspan=3 style=\"border-width: 1px; border-style: solid\">應發</td><td width=400 align=\"center\" colspan=3 style=\"border-width: 1px; border-style: solid\">應扣</td></tr>";
                     Body += "<tr><td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">項目</td>"
                                    + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">金額</td>"
                                    + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">備註</td>"
                                    + "<td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">項目</td>"
                                    + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">金額</td>"
                                    + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">備註</td></tr>";

                     int payod = SAPAYOD.Rows.Count;//應發
                     int payod_1 = SAPAYOD_1.Rows.Count;//應扣

                     if (payod > payod_1) //ex:3,2
                     {
                         for (int j = 0; j < SAPAYOD.Rows.Count; j++)
                         {
                             Double amt = Convert.ToDouble(SAPAYOD.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a = (int)amt;
                             Body += "<tr><td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\">" + SAPAYOD.Rows[j]["item_name"].ToString() + "</td>"
                                           + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + a + "</td>"
                                           + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td>";
                             if (j < SAPAYOD_1.Rows.Count)
                             {
                                 Double a1 = Convert.ToDouble(SAPAYOD_1.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                                 int a_1 = (int)a1;
                                 Body += "<td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\">" + SAPAYOD_1.Rows[j]["item_name"].ToString() + "</td>"
                                               + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + a_1 + "</td>"
                                               + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td></tr>";
                             }
                             else //空值
                             {
                                 Body += "<td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td>"
                                                 + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\"></td>"
                                                 + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td></tr>";
                             }
                         }
                     }
                     else  //ex 2, 3
                     {
                         for (int j = 0; j < SAPAYOD_1.Rows.Count; j++)
                         {
                             if (j < SAPAYOD.Rows.Count)
                             {
                                 Double amt = Convert.ToDouble(SAPAYOD.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                                 int a = (int)amt;
                                 Body += "<tr><td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\">" + SAPAYOD.Rows[j]["item_name"].ToString() + "</td>"
                                              + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + a + "</td>"
                                              + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td>";
                             }
                             else //空值
                             {
                                 Body += "<tr><td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td>"
                                                + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\"></td>"
                                                + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td>";
                             }

                             Double a1 = Convert.ToDouble(SAPAYOD_1.Rows[j]["PAYOD_AMT"].ToString()); //有小數點
                             int a_1 = (int)a1;
                             Body += "<td width=200 align=\"left\" style=\"border-width: 1px; border-style: solid\">" + SAPAYOD_1.Rows[j]["item_name"].ToString() + "</td>"
                                           + "<td width=100 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + a_1 + "</td>"
                                           + "<td width=100 align=\"left\" style=\"border-width: 1px; border-style: solid\"></td></tr>";

                         }
                     }

                     //留一空白列
                     Body += "<tr><td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td>"
                                   + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td>"
                                   + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td>"
                                   + "<td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td>"
                                   + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td>"
                                   + "<td width=100 align=\"center\" style=\"border-width: 1px; border-style: solid\">&nbsp;</td></tr>";
                     //應發應扣
                     Body += "<tr><td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">應發合計</td>"
                                   + "<td width=200 colspan=2 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + amt_1 + "</td>"
                                   + "<td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">應扣合計</td>"
                                   + "<td width=200 colspan=2 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + amt_2 + "</td></tr>";
                     //實發數
                     Body += "<tr><td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">實發合計</td>"
                                   + "<td width=600 colspan=5 align=\"right\" style=\"border-width: 1px; border-style: solid\">" + total + "</td></tr>";
                     //備註
                     Body += "<tr><td width=200 align=\"center\" style=\"border-width: 1px; border-style: solid\">備註</td>"
                                   + "<td width=600 colspan=5 align=\"left\" style=\"border-width: 1px; border-style: solid\">" + "" + "</td></tr>";

                     Body += "</table>";

                     SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);//設定gmail的smtp
                     MySmtp.Credentials = new System.Net.NetworkCredential("", "");//gmail的帳號密碼System.Net.NetworkCredential(帳號,密碼)
                     MySmtp.EnableSsl = true;//開啟ssl
                     MySmtp.Send(message);
                     MySmtp = null;
                     message.Dispose();
             

             

        }


    //get itemname
    protected string getrv(string payod_code_sys, string payod_code_type, string payod_code_no, string payo_orgid
                       , string Payo_prono, string payod_code)
    {
        string rv = "";
        switch (payod_code_sys)
        {
            case "001":
                rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_sys, payod_code_type, payod_code_no)
                      + " - " + get_item2(payo_orgid);
                break;
            case "003":
                rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_sys, payod_code_type, payod_code_no);
                switch (Payo_prono)
                {

                    case "001":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "月俸"; }
                        if (payod_code_type == "001" && payod_code_no == "003")
                        { rv = "公費"; }
                        if (payod_code_type == "001" && payod_code_no == "004")
                        { rv = ""; }
                        break;
                    case "002":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "俸額"; }
                        break;
                    case "003":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "俸額"; }
                        break;
                    case "004":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "薪資"; }
                        if (payod_code_type == "001" && payod_code_no == "003")
                        { rv = ""; }
                        if (payod_code_type == "001" && payod_code_no == "004")
                        { rv = ""; }
                        break;
                    case "005":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "薪俸"; }
                        if (payod_code_type == "001" && payod_code_no == "003")
                        { rv = ""; }
                        if (payod_code_type == "001" && payod_code_no == "004")
                        { rv = ""; }
                        break;
                    case "006":
                        if (payod_code_type == "001" && payod_code_no == "001")
                        { rv = "工餉"; }
                        if (payod_code_type == "001" && payod_code_no == "003")
                        { rv = "工作補助費"; }
                        if (payod_code_type == "001" && payod_code_no == "004")
                        { rv = ""; }
                        break;
                }

                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "020")
                {
                    rv = rv + " - " + SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "023")
                {
                    rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "024")
                {
                    rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "007")
                {
                    rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "008")
                {
                    rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                if (payod_code_type == "001" && payod_code_no == "006" && payod_code == "009")
                {
                    rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_type, payod_code_no, payod_code);
                }
                break;
            case "005":
                rv = SALARY.Logic.app.GetSaCode_Desc1(payod_code_sys, payod_code_type, payod_code_no)
                + " - " + get_item(payo_orgid, payod_code_sys, payod_code_type, payod_code_no, payod_code);
                break;
        }
        return rv;
    }

    protected string get_item2(string payo_orgid)
    {
        string rv = "";

        SAL3112 sal3112 = new SAL3112();
        DataTable dt = sal3112.queryitem2Data(payo_orgid);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                rv = dt.Rows[0]["item_name"].ToString();
            }
        }
        else
        {
            rv = "警察互助金";
        }
        return rv;
    }

    //get itemname
    protected string get_item(string payo_orgid, string payod_code_sys, string payod_code_type, string payod_code_no, string payod_code)
    {
        string rv = "";

        SAL3112 sal3112 = new SAL3112();
        DataTable dt = sal3112.queryitemData(payo_orgid, payod_code_sys, payod_code_type, payod_code_no, payod_code);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                rv = dt.Rows[0]["item_name"].ToString();
            }
        }
        else
        {
            rv = "項目不詳";
        }
        return rv;
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Gridview1();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        dataGridView3();
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Footer )
        {           
        e.Row.Cells[2].Text = "待發總金額";
        e.Row.Cells[3].Text = "0";   
        }
    
    }

    protected void ch1_CheckedChanged(object sender, EventArgs e)
    {
        int sum = 0;
        for(int i = 0 ; i< GridView1.Rows.Count ; i++)
        {
             CheckBox ch = (CheckBox)GridView1.Rows[i].FindControl("ch1");
          
             if (ch.Checked)
             {
                 if (GridView1.Rows[i].Cells[3].Text != "")
                 {
                     Double s = Convert.ToDouble(GridView1.Rows[i].Cells[3].Text);
                     sum += (int)s;
                 }
             }
        }
        GridView1.FooterRow.Cells[3].Text = sum.ToString();
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        Gridview1();
    }
}
