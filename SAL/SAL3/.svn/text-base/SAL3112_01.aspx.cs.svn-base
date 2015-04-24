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

public partial class SAL_SAL3_SAL3112_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    private string v_mid; 
     
    protected void Page_Load(object sender, EventArgs e)
    {
        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        v_mid = LoginManager.UserId; // Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString
             
        ucDateDropDownList.Date_Changed += new uc_ucDateDropdownList.Date_ChangedEventHandler(cmbYear_SelectedIndexChanged); //薪資年月

   //     ((DropDownList)ucDateDropDownList.FindControl("DropDownList_M")).AutoPostBack = true;
   //     ((DropDownList)ucDateDropDownList.FindControl("DropDownList_M")).SelectedIndexChanged += new EventHandler(cmbYear_SelectedIndexChanged);


        // User Control Event BinderstrOrgCode
        cmb_uc_PayType.ReturnEvent = true;
        cmb_uc_PayType.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(PayTypeChanged); //發放種類

        cmb_uc_EmpType.ReturnEvent = true;
        cmb_uc_EmpType.CodeChanged +=new uc_ucSaCode.CodeChangedEventHandler(cmb_uc_EmpType_CodeChanged); //人員類別

        DropDownList org = (DropDownList)cmb_uc_org.FindControl("ddlorg");
        org.AutoPostBack = true;
        org.SelectedIndexChanged += new EventHandler(org_SelectedIndexChanged); //單位別

        if (Page.IsPostBack) return;
        string year = DateTime.Now.ToString("yyyy");
        //ucDateDropDownList.Kind = "YM";
        ucDateDropDownList.year_e = (int.Parse(year) + 1).ToString();
        ucDateDropDownList.year_s = (int.Parse(year) - 2).ToString();

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        string year = DateTime.Now.ToString("yyyyMM");
        ucDateDropDownList.DateStr = year;
        queryDatePayed();
    }

    void cmbYear_SelectedIndexChanged(object sender, EventArgs e) //薪資年月改變
    {
        view.Visible = false;
        if (cmb_uc_PayType.SelectedValue == "005")
        {
            bindItemTyp1();
            bindItemTyp2();
            bindItemTypeName();
        }
        // 重新取得發放日期
        this.queryDatePayed();
    }

    //人員類別
    protected void cmb_uc_EmpType_CodeChanged(object sender, EventArgs e)
    {
        view.Visible = false;
    }

      //單位別
    protected void org_SelectedIndexChanged(object sender, EventArgs e)
    {
        view.Visible = false;
    }

    // 取得發放日期
    private void queryDatePayed()
    {
        SAL3112 sal3112 = new SAL3112();
        // 參數
        string strPayoKind = cmb_uc_PayType.SelectedValue;  
        string strPayoYymm = ucDateDropDownList.DateStr;

        string strPayoKindCode = "";
        if (strPayoKind == "005")
        {
            strPayoKindCode = cmbItemTypeName.SelectedValue;
        }
        else
        {
            strPayoKindCode = "000";
        }
      
        DataTable data = sal3112.queryDatePayed(this.strOrgCode, strPayoKind, strPayoYymm, strPayoKindCode);

        cmbDatePay.Items.Clear();    

        if (data != null && data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = data.Rows[i]["paydate"].ToString();
                item.Value = data.Rows[i]["payo_date"].ToString();
                cmbDatePay.Items.Add(item); //add發放日期
            }
        }
        UpdatePanel1.Update();

    }

    // 發放種類改變
    protected void PayTypeChanged(object sender, EventArgs e)
    {
        view.Visible = false;
        doPayTypeChanged();     

        if (cmb_uc_PayType.SelectedValue == "002"
         || cmb_uc_PayType.SelectedValue == "003"
         || cmb_uc_PayType.SelectedValue == "004")
        {
            ucDateDropDownList.Kind = "Y";      
        }
        else
        {
            ucDateDropDownList.Kind = "YM";          
        }   
       queryDatePayed();
    }

    private void doPayTypeChanged() //發放種類為其他薪津畫面(顯示項目類別)
    {      
        if (cmb_uc_PayType.SelectedValue == "005")  
        {
            pnlOthers.Visible = true;
            bindItemTyp1();
            bindItemTyp2();
            bindItemTypeName();
        }
        else
        {
            pnlOthers.Visible = false;
        }   
    }

    //項目類別一
    private void bindItemTyp1()
    {
        SAL3112 sal3112 = new SAL3112();
        // 參數
        string strPayoYymm = ucDateDropDownList.DateStr;// cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //  cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');//'畫面選擇之計算年月'

        DataTable data = sal3112.queryItemType1(this.strOrgCode, strPayoYymm);

        /*    cmbItemTyp1.DataSource = data;
            cmbItemTyp1.DataValueField = "payo_kind_code_type";
            cmbItemTyp1.DataTextField = "type_name";
            cmbItemTyp1.DataBind();
            */
        cmbItemTyp1.Items.Clear();
        if (data != null && data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = data.Rows[i]["type_name"].ToString();
                item.Value = data.Rows[i]["payo_kind_code_type"].ToString();
                cmbItemTyp1.Items.Add(item); 
            }
        }    
    }
    //項目類別二
    private void bindItemTyp2()
    {
        SAL3112 sal3112 = new SAL3112();
        // 參數
        string strPayoYymm = ucDateDropDownList.DateStr;// cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //  cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');//'畫面選擇之計算年月'

        string cmbItemTyp1Code  =cmbItemTyp1.SelectedValue;
        DataTable data = sal3112.queryItemType2(this.strOrgCode, strPayoYymm, cmbItemTyp1Code);
        /*   cmbItemTyp2.DataSource = data;
             cmbItemTyp2.DataValueField = "payo_kind_code_no";
             cmbItemTyp2.DataTextField = "item_name";
             cmbItemTyp2.DataBind();
         * */
        cmbItemTyp2.Items.Clear();
       if (data != null && data.Rows.Count > 0)
       {
           for (int i = 0; i < data.Rows.Count; i++)
           {
               ListItem item = new ListItem();
               item.Text = data.Rows[i]["item_name"].ToString();
               item.Value = data.Rows[i]["payo_kind_code_no"].ToString();
               cmbItemTyp2.Items.Add(item);
           }
       }    
    }
    //項目名稱
    private void bindItemTypeName()
    {
        SAL3112 sal3112 = new SAL3112();
        // 參數
        string strPayoYymm = ucDateDropDownList.DateStr;// cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //  cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');//'畫面選擇之計算年月'

        string cmbItemTyp1Code = cmbItemTyp1.SelectedValue;
        string cmbItemTyp2Code = cmbItemTyp2.SelectedValue;
        DataTable data = sal3112.queryItemName(this.strOrgCode, strPayoYymm, cmbItemTyp1Code, cmbItemTyp2Code);
        /*    cmbItemTypeName.DataSource = data;
            cmbItemTypeName.DataValueField = "payo_kind_code";
            cmbItemTypeName.DataTextField = "item_name";
            cmbItemTypeName.DataBind();*/
        cmbItemTypeName.Items.Clear();
        if (data != null && data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = data.Rows[i]["item_name"].ToString();
                item.Value = data.Rows[i]["payo_kind_code"].ToString();
                cmbItemTypeName.Items.Add(item);
            }
        }    
    }

    // 按下查詢按鈕
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        doQuery();
    }
   
    private void doQuery()
    {
        SAL3112 sal3112 = new SAL3112();
        // 各參數
        string strPayoKind  = cmb_uc_PayType.SelectedValue;         //'畫面查詢之發放種類'     
        string strPayoYymm = ucDateDropDownList.DateStr;// cmb_uc_YearMonth.Year.ToString().PadLeft(4, '0') +
        //  cmb_uc_YearMonth.Month.ToString().PadLeft(2, '0');//'畫面選擇之計算年月'
        TextBox1.Text = cmb_uc_PayType.SelectedItem.Text;
        TextBox2.Text = ucDateDropDownList.DateStr;

        string strPayoDate  =cmbDatePay.SelectedValue;              //'畫面查詢之發放日期'     
        string strPayoKindCodeType  =cmbItemTyp1.SelectedValue;     //--畫面查詢之項目種類一代碼   
        string strPayoKindCodeNo    =cmbItemTyp2.SelectedValue;     //--畫面查詢之項目種類二代碼    
        string strPayoKindCode      =cmbItemTypeName.SelectedValue; //--畫面查詢之項目名稱代碼    
        string strPayoName  =edtEmpName.Text.Trim();        //員工姓名     
        string strPayoSeqNo   =edtEmpID.Text.Trim();        // 員工編號     
        string strPayoProno =cmb_uc_EmpType.SelectedValue;  // 畫面查詢之員工類別代碼    
        string strBaseDep  =cmb_uc_org.OrgCode;             // 畫面查詢之科室代碼'     

        DataTable dt = sal3112.queryData(
            this.strOrgCode, strPayoKind, strPayoYymm, strPayoDate, strPayoKindCodeType, strPayoKindCodeNo, strPayoKindCode,
            strPayoName, strPayoSeqNo, strPayoProno, strBaseDep);
        if (dt == null || dt.Rows.Count == 0)
        {
            gvResult.DataSource = dt;
            gvResult.DataBind();
            gvResult.Visible = true;
            view.Visible = true;
            UcPager.Visible = false;       
          
        }
        else
        {
            UcPager.Visible = true;
            gvResult.Visible = true;
            view.Visible = true;

            dt.Columns.Add("data_no");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["data_no"] = i + 1;
            }

            gvResult.DataSource = dt;
            gvResult.DataBind();
          
            for (int i = 0; i < gvResult.Rows.Count; i++) 
            {
                if (gvResult.Rows[i].Cells[34].Text == "Y") //當此欄位資料=’Y’時, 隱藏清單上的刪除按鈕
                {
                    Panel Delte = (Panel)gvResult.Rows[i].Cells[7].FindControl("Panel2");
                    Delte.Visible = false; 
                }
            } 
        }
    }

    //刪除資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {    
        int index = int.Parse(txtFuncParam.Value.Trim());
     
        int nowyy = int.Parse(DateTime.Now.ToString("yyyy"));
        int nowym = int.Parse(DateTime.Now.ToString("yyyyMM"));

        string payo_kind = gvResult.Rows[index].Cells[10].Text;//清單中所點選項目之payo_kind欄位值   
        string payo_yymm = gvResult.Rows[index].Cells[11].Text;//清單中所點選項目之payo_yymm欄位值      

      
        
        if (payo_kind == "001")
        {
            if (int.Parse(payo_yymm.Substring(0, 4)) < nowyy)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "不可刪除過去年度之月薪!若確定要執行,請與資訊處聯絡!", "", "");
                this.Page = tempPage;
                return;
            }
            else if (int.Parse(payo_yymm) <= nowym)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "不可刪除過去月份之月薪!若確定要執行,請與資訊處聯絡!", "", "");
                this.Page = tempPage;
                return;
            }
        }
        
        string payo_orgid = gvResult.Rows[index].Cells[8].Text;//清單中所點選項目之payo_orgid欄位值    
        string payo_seqno = gvResult.Rows[index].Cells[9].Text;//清單中所點選項目之payo_seqno欄位值   
        string payo_date = gvResult.Rows[index].Cells[12].Text;//清單中所點選項目之payo_date欄位值
        string payo_kind_code_type = gvResult.Rows[index].Cells[13].Text;
        string payo_kind_code_no = gvResult.Rows[index].Cells[14].Text;
        string payo_kind_code = gvResult.Rows[index].Cells[15].Text; 

        SAL3112 sal3112 = new SAL3112();
        sal3112.deleteData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type, payo_kind_code_no
            , payo_kind_code );
        
        Page page = this.Page;
        CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = page;

        doQuery();     
        
    }


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
                          /*  switch (Payo_prono)
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
                            }*/

                            if (payod_code_type == "001" && payod_code_no == "006")
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

   public int index;
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetail")//點選清單中的員工編號或員工姓名時 下方展開該筆資料的明細
        {          
            
            pnlDetail.Visible = true;
            UcPager.Visible = false;
            gvResult.Visible = false;
            view.Visible = false;
            searchview.Visible = false;

            index = Convert.ToInt32(e.CommandArgument); //索引值
            indexno.Text = index.ToString();

            Label4.Text = "";
            Label5.Text = ""; 
            Label6.Text = "";
            Label7.Text = "";
            Label4.Text = gvResult.Rows[index].Cells[3].Text;
            Label5.Text = gvResult.Rows[index].Cells[9].Text;
            Label6.Text = TextBox1.Text;
            if (TextBox2.Text.Length > 4)
            {
                Label7.Text = (int.Parse(TextBox2.Text.Substring(0, 4)) - 1911).ToString() + "年" + TextBox2.Text.Substring(4, 2) + "月";
            }
            else
            {
                Label7.Text = (int.Parse(TextBox2.Text.Substring(0, 4)) - 1911).ToString() + "年";
            }
            string payo_orgid = gvResult.Rows[index].Cells[8].Text;//清單中所點選項目之payo_orgid欄位值
            txtpayo_orgid.Text = payo_orgid;
            string payo_seqno = gvResult.Rows[index].Cells[9].Text;//清單中所點選項目之payo_seqno欄位值
            txtpayo_seqno.Text = payo_seqno;
            string payo_kind = gvResult.Rows[index].Cells[10].Text;//清單中所點選項目之payo_kind欄位值
            txtpayo_kind.Text = payo_kind;
            string payo_yymm = gvResult.Rows[index].Cells[11].Text;//清單中所點選項目之payo_yymm欄位值
            txtpayo_yymm.Text = payo_yymm;
            string payo_date = gvResult.Rows[index].Cells[12].Text;//清單中所點選項目之payo_date欄位值
            txtpayo_date.Text  = payo_date;
            string payo_kind_code_type = gvResult.Rows[index].Cells[13].Text;//清單中所點選項目之payo_kind_code_type欄位值
            txtpayo_kind_code_type.Text = payo_kind_code_type;
            string payo_kind_code_no = gvResult.Rows[index].Cells[14].Text;//清單中所點選項目之payo_kind_code_no欄位值
            txtpayo_kind_code_no.Text = payo_kind_code_no;
            string payo_kind_code = gvResult.Rows[index].Cells[15].Text; //清單中所點選項目之payo_kind_code欄位值 
            txtpayo_kind_code.Text = payo_kind_code;
            string Payo_prono = gvResult.Rows[index].Cells[35].Text; //清單中所點選項目之payo_kind_code欄位值 
             

            SAL3112 sal3112 = new SAL3112();

           //========= 取得應發項目資料============
            DataTable dt = sal3112.querytxtData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
        
            // get item_name
            if (dt != null && dt.Rows.Count > 0)
            {   
                dt.Columns.Add("item_name", typeof(string));   
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string payod_code_sys = dt.Rows[i]["payod_code_sys"].ToString();
                    string payod_code_type = dt.Rows[i]["payod_code_type"].ToString();
                    string payod_code_no = dt.Rows[i]["payod_code_no"].ToString();
                    string payod_code = dt.Rows[i]["payod_code"].ToString(); 
                    string  rv= getrv( payod_code_sys, payod_code_type,  payod_code_no,  payo_orgid
                                     ,  Payo_prono,  payod_code);
                    dt.Rows[i]["item_name"] = rv;

                    if (dt.Rows[i]["PAYOD_AMT"].ToString() != "")
                    {
                        double amt = Convert.ToDouble(dt.Rows[i]["PAYOD_AMT"].ToString());
                        int a = (int)amt;
                        dt.Rows[i]["PAYOD_AMT"] = a;
                    }
                }
            }
         
            // 應發項目資料view      
            GridView_payod_001.Columns[1].Visible = true;
            GridView_payod_001.Columns[2].Visible = true;
            GridView_payod_001.Columns[3].Visible = true;
            GridView_payod_001.Columns[4].Visible = true;
            GridView_payod_001.Columns[5].Visible = true;
            GridView_payod_001.DataSource = dt;
            GridView_payod_001.DataBind();
            GridView_payod_001.Columns[1].Visible = false;
            GridView_payod_001.Columns[2].Visible = false;
            GridView_payod_001.Columns[3].Visible = false;
            GridView_payod_001.Columns[4].Visible = false;
            GridView_payod_001.Columns[5].Visible = false;
            //若清單中所點選項目[SQL1]之payo_freeze = ‘Y’，則項目內金額不可維護    
            string enb = gvResult.Rows[index].Cells[34].Text;        
            if (enb =="Y")
            {
                for (int i = 0; i < GridView_payod_001.Rows.Count; i++)
                {                    
                    TextBox txt = (TextBox)GridView_payod_001.Rows[i].Cells[0].FindControl("TextBox_amt");
                    txt.Enabled = false;
                }
            }               

            // ========取得應扣項目資料============
            DataTable dt2 = sal3112.querytxt2Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
               , payo_kind_code_no, payo_kind_code);
          
            // get item_name
            if (dt2 != null && dt2.Rows.Count > 0)
            {  
                dt2.Columns.Add("item_name", typeof(string));   
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string payod_code_sys = dt2.Rows[i]["payod_code_sys"].ToString();
                    string payod_code_type = dt2.Rows[i]["payod_code_type"].ToString();
                    string payod_code_no = dt2.Rows[i]["payod_code_no"].ToString();
                    string payod_code = dt2.Rows[i]["payod_code"].ToString();

                    string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, payo_orgid
                                , Payo_prono, payod_code);
                 
                    dt2.Rows[i]["item_name"] = rv;
                    if (dt2.Rows[i]["PAYOD_AMT"].ToString() != "")
                    {
                        double amt = Convert.ToDouble(dt2.Rows[i]["PAYOD_AMT"].ToString());
                        int a = (int)amt;
                        dt2.Rows[i]["PAYOD_AMT"] = a;
                    }
                }
            }
            // 應扣項目資料      
            GridView_payod_002.Columns[1].Visible = true;
            GridView_payod_002.Columns[2].Visible = true;
            GridView_payod_002.Columns[3].Visible = true;
            GridView_payod_002.Columns[4].Visible = true;
            GridView_payod_002.Columns[5].Visible = true;
            GridView_payod_002.DataSource = dt2;
            GridView_payod_002.DataBind();
            GridView_payod_002.Columns[1].Visible = false;
            GridView_payod_002.Columns[2].Visible = false;
            GridView_payod_002.Columns[3].Visible = false;
            GridView_payod_002.Columns[4].Visible = false;
            GridView_payod_002.Columns[5].Visible = false;

            //若清單中所點選項目[SQL1]之payo_freeze = ‘Y’，則項目內金額不可維護     
            string enb2 = gvResult.Rows[index].Cells[34].Text;
            if (enb2 == "Y")
            {
                for (int i = 0; i < GridView_payod_002.Rows.Count; i++)
                {
                    TextBox txt = (TextBox)GridView_payod_002.Rows[i].Cells[0].FindControl("TextBox_amt");
                    txt.Enabled = false;
                }
            }               

       //=========== 取得機關負擔項目資料==============
            DataTable dt3 = sal3112.querytxt3Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
             , payo_kind_code_no, payo_kind_code);
        
            // get item_name
            if (dt3 != null && dt3.Rows.Count > 0)
            {    
                dt3.Columns.Add("item_name", typeof(string));   
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    string payod_code_sys = dt3.Rows[i]["payod_code_sys"].ToString();
                    string payod_code_type = dt3.Rows[i]["payod_code_type"].ToString();
                    string payod_code_no = dt3.Rows[i]["payod_code_no"].ToString();
                    string payod_code = dt3.Rows[i]["payod_code"].ToString();

                    string rv = getrv(payod_code_sys, payod_code_type, payod_code_no, payo_orgid
                                    , Payo_prono, payod_code);

                    dt3.Rows[i]["item_name"] = rv;

                    if (dt3.Rows[i]["PAYOD_AMT"].ToString() != "")
                    {
                        double amt = Convert.ToDouble(dt3.Rows[i]["PAYOD_AMT"].ToString());
                        int a = (int)amt;
                        dt3.Rows[i]["PAYOD_AMT"] = a;
                    }
                }
            }
            // 機關負擔項目資料       
            GridView_payod_007.Columns[1].Visible = true;
            GridView_payod_007.Columns[2].Visible = true;
            GridView_payod_007.Columns[3].Visible = true;
            GridView_payod_007.Columns[4].Visible = true;
            GridView_payod_007.Columns[5].Visible = true;
            GridView_payod_007.DataSource = dt3;
            GridView_payod_007.DataBind();
            GridView_payod_007.Columns[1].Visible = false;
            GridView_payod_007.Columns[2].Visible = false;
            GridView_payod_007.Columns[3].Visible = false;
            GridView_payod_007.Columns[4].Visible = false;
            GridView_payod_007.Columns[5].Visible = false;
            //若清單中所點選項目[SQL1]之payo_freeze = ‘Y’，則項目內金額不可維護
            string enb3 = gvResult.Rows[index].Cells[34].Text;
            if (enb3 == "Y")            
             {
                for (int i = 0; i < GridView_payod_007.Rows.Count; i++)
                {
                    TextBox txt = (TextBox)GridView_payod_007.Rows[i].Cells[0].FindControl("TextBox_amt");
                    txt.Enabled = false;
                }
            } 

            // 取得應發合計
            DataTable dttotal = sal3112.querytotalData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            // 取得應扣合計
            DataTable dttotal2 = sal3112.querytotal2Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);
            // 取得實發數金額
            DataTable dttotal3 = sal3112.querytotal3Data(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
                , payo_kind_code_no, payo_kind_code);

            //取得應發合計、應扣合計、實發數金額
            if (dttotal != null && dttotal.Rows.Count > 0)
            {
                Label1.Text = dttotal.Rows[0]["payod_amt"].ToString();
            }
            if (dttotal2 != null && dttotal2.Rows.Count > 0)
            {
                Label2.Text = dttotal2.Rows[0]["payod_amt"].ToString();
            }
            if (dttotal3 != null && dttotal3.Rows.Count > 0)
            {
                Label3.Text = dttotal3.Rows[0]["payod_amt"].ToString();
            }

           //取得備註資料       
           txtMemo.Text = "";
           string payo_kind_code_sys = "";
            if (txtpayo_kind.Text != "005")
            {
                payo_kind_code_sys="003";
            }
            else
            {
                payo_kind_code_sys="005";
            }
           DataTable dtnote = sal3112.querynoteData(payo_orgid, payo_seqno, payo_kind, payo_yymm, payo_date, payo_kind_code_type
             , payo_kind_code_no, payo_kind_code, payo_kind_code_sys);

           if (dtnote != null && dtnote.Rows.Count > 0)
           {
               txtMemo.Text = dtnote.Rows[0]["memo_description"].ToString();
           } 
           
           int date=0 ;
           int date2=0 ;
           int x = 0;
           if (gvResult.Rows[index].Cells[17].Text != "" && int.TryParse(gvResult.Rows[index].Cells[17].Text,out x))
           {
                date = int.Parse(gvResult.Rows[index].Cells[17].Text.Substring(0, 6));         
           }
           if (gvResult.Rows[index].Cells[12].Text != "" && int.TryParse(gvResult.Rows[index].Cells[12].Text, out x))
           {
                date2 = int.Parse(gvResult.Rows[index].Cells[12].Text.Substring(0, 6));
           }
        
            //清單符合下列條件，則顯示試算勞保按鈕
           if (gvResult.Rows[index].Cells[7].Visible &&
               gvResult.Rows[index].Cells[10].Text == "001" &&
              (gvResult.Rows[index].Cells[16].Text == "002" || gvResult.Rows[index].Cells[16].Text == "003") &&
              ((gvResult.Rows[index].Cells[17].Text == "" && gvResult.Rows[index].Cells[18].Text == "") ||
              (date > date2 && (gvResult.Rows[index].Cells[18].Text == "001" || gvResult.Rows[index].Cells[18].Text == "002")))
              )
           {
               Button3.Visible = true;
           }
           else
           {
               Button3.Visible = false;
           }
        }
    }

    //get itemname
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

    //試算勞保按鈕
    protected void Button3_Click(object sender, EventArgs e)
    {
        index =int.Parse(indexno.Text);
        Panel1.Visible = true;
        if (gvResult.Rows[index].Cells[19].ToString() != "")
        {
            TextBox9.Text = gvResult.Rows[index].Cells[19].Text;
        }
        else { TextBox9.Text = "0"; }

        if (gvResult.Rows[index].Cells[20].ToString() != "")
        {
            TextBox10.Text = gvResult.Rows[index].Cells[20].Text;
        }
        else { TextBox10.Text = "0"; }
        if (gvResult.Rows[index].Cells[21].ToString() != "")
        {
            TextBox15.Text = gvResult.Rows[index].Cells[21].Text;
        }
        else { TextBox15.Text = "0"; }  
    }

    //關閉此畫面按鈕
    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
      
       
    }

    //試算按鈕
    protected void Button4_Click(object sender, EventArgs e)
    {
        index = int.Parse(indexno.Text);
        string yymm = gvResult.Rows[index].Cells[11].Text;
        SAL3112 sal3112 = new SAL3112();
        DataTable dt = sal3112.getParam(this.strOrgCode); //勞保職業災害費率
        string p_labor_ptb_rate3 = dt.Rows[0][0].ToString();

        DataTable dt2 = sal3112.getParam2(yymm);         //勞保普通事故保費率
        string p_labor_ptb_rate1 = dt2.Rows[0][0].ToString();

        DataTable dt3 = sal3112.getParam3(yymm);         //勞保就業保險費率
        string p_labor_ptb_rate2 = dt3.Rows[0][0].ToString();

        DataTable dt4 = sal3112.getParam4(yymm);         //勞保保費自付比率
        string p_labor_self_rate1 =  dt4.Rows[0][0].ToString();
        string p_labor_self_rate2 = p_labor_self_rate1;

        DataTable dt5 = sal3112.getParam5(yymm);         //勞保保費機關補助比率
        string p_labor_sup_rate1 = dt5.Rows[0][0].ToString();
        string p_labor_sup_rate2 = p_labor_sup_rate1;
        get_unit();

        int v_lab_amt1 = 0;
        int v_lab_amt2 = 0;
        int v_lab_amt = 0;

        int v_lab_amt_self_m1 = 0;
        int v_lab_amt_self_m2 = 0;

        int v_lab_sup1 = 0;
        int v_lab_sup2 = 0;
        int v_lab_sup3 = 0;
        int v_lab_sup = 0;

        int v_pen_amt = 0;
        int v_pen_sup = 0;

        string v_labor_days = TextBox9.Text;
        string v_pen_days = TextBox10.Text;
        string v_pen_sup_days = TextBox15.Text;

        if (v_pen_days == "")
        { v_pen_days = v_labor_days; }

        Label_payo_labor_days.Text = v_labor_days;
        Label_payo_pen_days.Text = v_pen_days;
        Label_payo_pen_sup_days.Text = v_pen_sup_days;

        //勞保費開始計算
        string p_labor_series = gvResult.Rows[index].Cells[22].Text;
        string p_fins_kind = gvResult.Rows[index].Cells[16].Text;
        string PAYO_FINS_SELF = gvResult.Rows[index].Cells[23].Text;

        if (v_labor_days != "" && p_labor_series != "" && (p_fins_kind == "002" || p_fins_kind == "003"))
        {
            try 
            {
   v_lab_amt1 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate1) / 100 * Convert.ToDouble(p_labor_self_rate1) / 100 * Convert.ToDouble(v_labor_days) / 30);
   v_lab_amt2 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate2) / 100 * Convert.ToDouble(p_labor_self_rate2) / 100 * Convert.ToDouble(v_labor_days) / 30);

   v_lab_amt_self_m1 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate1) / 100 * Convert.ToDouble(p_labor_self_rate1) /100 *
       (1 - Convert.ToDouble(PAYO_FINS_SELF)) * Convert.ToDouble(v_labor_days) / 30);
   v_lab_amt_self_m2 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate2) / 100 * Convert.ToDouble(p_labor_self_rate2) /100 *
       (1 - Convert.ToDouble(PAYO_FINS_SELF)) * Convert.ToDouble(v_labor_days) / 30);

   v_lab_sup1 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate1) / 100 * Convert.ToDouble(p_labor_sup_rate1) / 100 * Convert.ToDouble(v_labor_days) / 30);
   v_lab_sup2 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(p_labor_ptb_rate2) / 100 * Convert.ToDouble(p_labor_sup_rate2) / 100 * Convert.ToDouble(v_labor_days) / 30);
   v_lab_sup3 = Convert.ToInt32(Convert.ToDouble(p_labor_series) * Convert.ToDouble(TextBox_labor_ptb_rate3.Text) / 100 * Convert.ToDouble(v_labor_days) / 30);
            }
            catch 
            { 
                //錯誤訊息
            }
            string p_lab_jif = gvResult.Rows[index].Cells[24].Text;
            string p_lab1 = gvResult.Rows[index].Cells[25].Text;
            string p_lab2 = gvResult.Rows[index].Cells[26].Text;
            string p_lab3 = gvResult.Rows[index].Cells[27].Text;
            // 65歲以上，只有普通事故保險費金額
            if (p_fins_kind == "002" && p_lab_jif == "Y")
            {
                v_lab_amt2 = 0;
                v_lab_sup2 = 0;
                v_lab_amt_self_m2 = 0;
            }
            //勞保自訂 'fins_kind = 003
            if (p_fins_kind == "003")
            {
                if (p_lab1 == "Y")
                {
                    v_lab_amt1 = 0;
                    v_lab_sup1 = 0;
                    v_lab_amt_self_m1 = 0;
                }
                if (p_lab2 == "Y")
                {
                    v_lab_amt2 = 0;
                    v_lab_sup2 = 0;
                    v_lab_amt_self_m2 = 0;
                }
                if (p_lab3 == "Y")
                {
                    v_lab_sup3 = 0;
                }
            }

                v_lab_amt1 = v_lab_amt1 - v_lab_amt_self_m1;
                v_lab_amt2 = v_lab_amt2 - v_lab_amt_self_m2;
                v_lab_amt = v_lab_amt1 + v_lab_amt2;
                v_lab_sup = v_lab_sup1 + v_lab_sup2 + v_lab_sup3;

                Label_lab_amt1.Text = v_lab_amt1.ToString();    //普通事故保費率
                Label_lab_amt2.Text = v_lab_amt2.ToString();    //就業保險費
                Label_lab_amt.Text = v_lab_amt.ToString();      //合計
                Label_lab_sup1.Text = v_lab_sup1.ToString();    //普通事故保費率
                Label_lab_sup2.Text = v_lab_sup2.ToString();    //就業保險費
                Label_lab_sup3.Text = v_lab_sup3.ToString();    //職業災害保險費
                Label_lab_sup.Text = v_lab_sup.ToString();      //合計
        }

        string PAYO_PEN_TYPE = gvResult.Rows[index].Cells[28].Text;
        string p_pen_series = gvResult.Rows[index].Cells[29].Text;
        string p_pen_rate = gvResult.Rows[index].Cells[30].Text;     
        string p_unit_pen_rate = TextBox_unit_pen_rate.Text;

         // 勞工退休金計算 (勞退新制才有)
        if (PAYO_PEN_TYPE == "2" && p_pen_series != "")
        {
            if (v_pen_days != "")
            { 
                    try {
                         v_pen_amt = Convert.ToInt32((int.Parse(p_pen_series) * int.Parse(p_pen_rate) / 100) * int.Parse(v_pen_days) / 30);
                         }
                    catch
                    {
                       //錯誤訊息
                    }
                     Label_pen_amt.Text = v_pen_amt.ToString();
            }
             if(v_labor_days != "") 
            {
                 try
                 {
                     v_pen_sup = Convert.ToInt32((int.Parse(p_pen_series) * int.Parse(p_unit_pen_rate) / 100) * int.Parse(v_pen_sup_days) / 30);
                 } 
                 catch
                 {   
                    //錯誤訊息
                 }
                 Label_pen_sup.Text = v_pen_sup.ToString(); 
            } 
        }
    }

    protected void get_unit()
    {
        SAL3112 sal3112 = new SAL3112();
        DataTable dt = sal3112.getdata2(strOrgCode);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (double.Parse(dt.Rows[0]["UNIT_PEN_RATE"].ToString()) < 6)
            {
                TextBox_unit_pen_rate.Text = "6";
            }
            else
            {
                TextBox_unit_pen_rate.Text = dt.Rows[0]["UNIT_PEN_RATE"].ToString();
            }
            TextBox_labor_ptb_rate3.Text = dt.Rows[0]["UNIT_LABOR_CALM_RATE"].ToString();
        }
    }

    //帶入薪資維護作業
    protected void Button5_Click(object sender, EventArgs e)
    {
        //取得天數
        string v_labor_days = Label_payo_labor_days.Text;
        string v_pen_days = Label_payo_pen_days.Text;
        string v_pen_sup_days = Label_payo_pen_sup_days.Text;

        string v_labor_amt1 = Label_lab_amt1.Text;
        string v_labor_amt2 = Label_lab_amt2.Text;
        string v_labor_sup1 = Label_lab_sup1.Text;
        string v_labor_sup2 = Label_lab_sup2.Text;
        string v_labor_sup3 = Label_lab_sup3.Text;

        string v_labor_amt = Label_lab_amt.Text;
        string v_labor_sup = Label_lab_sup.Text;
        string v_pen_amt = Label_pen_amt.Text;
        string v_pen_sup = Label_pen_sup.Text;

        for (int i = 0; i < GridView_payod_002.Rows.Count; i++)
        {
            // 個人負擔勞保費 (003_002_003_002) or (003_002_003_003)
            if (GridView_payod_002.Rows[i].Cells[1].Text == "003" &&    //payod_code_sys
                GridView_payod_002.Rows[i].Cells[2].Text == "002" &&    //payod_code_type
                GridView_payod_002.Rows[i].Cells[3].Text == "003" &&    //payod_code_no
                (GridView_payod_002.Rows[i].Cells[4].Text == "002" || GridView_payod_002.Rows[i].Cells[4].Text == "003") && //payod_code
                v_labor_days != "" )
            {
                TextBox txt = (TextBox)GridView_payod_002.Rows[i].Cells[0].FindControl("TextBox_amt");
                txt.Text = v_labor_amt;
            }

            //個人負擔勞工退休金 (003_002_015_002)
            if (GridView_payod_002.Rows[i].Cells[1].Text == "003" &&  //payod_code_sys
             GridView_payod_002.Rows[i].Cells[2].Text == "002" &&     //payod_code_type
             GridView_payod_002.Rows[i].Cells[3].Text == "015" &&     //payod_code_no
             GridView_payod_002.Rows[i].Cells[4].Text == "002" &&     //payod_code
             v_pen_days != "")
            {
                TextBox txt = (TextBox)GridView_payod_002.Rows[i].Cells[0].FindControl("TextBox_amt");
                txt.Text = v_pen_amt;
            }        
        }

        for (int i = 0; i < GridView_payod_007.Rows.Count; i++)
        { 
            //機關負擔勞保費 (003_007_001_002) or (003_007_001_003)
            if (GridView_payod_007.Rows[i].Cells[1].Text == "003" &&  //payod_code_sys
            GridView_payod_007.Rows[i].Cells[2].Text == "007" &&      //payod_code_type
            GridView_payod_007.Rows[i].Cells[3].Text == "001" &&      //payod_code_no
           (GridView_payod_007.Rows[i].Cells[4].Text == "002" || GridView_payod_007.Rows[i].Cells[4].Text == "003") && //payod_code
            v_labor_days != "")
            { 
            TextBox txt = (TextBox)GridView_payod_007.Rows[i].Cells[0].FindControl("TextBox_amt");
            txt.Text = v_labor_sup;
            }

            //機關負擔勞工退休金 (003_007_006_002)
            if (GridView_payod_007.Rows[i].Cells[1].Text == "003" &&  //payod_code_sys
           GridView_payod_007.Rows[i].Cells[2].Text == "007" &&       //payod_code_type
           GridView_payod_007.Rows[i].Cells[3].Text == "006" &&       //payod_code_no
           GridView_payod_007.Rows[i].Cells[4].Text == "002" &&       //payod_code
           v_pen_days != "")
            {
                TextBox txt = (TextBox)GridView_payod_007.Rows[i].Cells[0].FindControl("TextBox_amt");
                txt.Text = v_pen_sup;
            } 
        }
        Panel1.Visible = false;
   }

   // 關閉視窗
    protected void Button2_Click(object sender, EventArgs e)
    { 
        doQuery();
        pnlDetail.Visible = false;
        UcPager.Visible = true;
        gvResult.Visible = true;
        view.Visible = true;
        searchview.Visible = true;
      
    }
    //儲存修改按鈕
    protected void Button1_Click(object sender, EventArgs e)
    {
        index = int.Parse(indexno.Text);
        //data_check
        for (int i = 0; i < GridView_payod_001.Rows.Count; i++)
        {
           Label name =(Label)GridView_payod_001.Rows[i].Cells[0].FindControl("Label_item");
           TextBox txt = (TextBox)GridView_payod_001.Rows[i].Cells[0].FindControl("TextBox_amt");                     
            double n;
            if (!double.TryParse(txt.Text, out n))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom,"應發項目 - "+ name.Text + "請輸入正確金額", "", "");
                this.Page = tempPage;
                return;
            } 
        }

        //data_check
        for (int i = 0; i < GridView_payod_002.Rows.Count; i++)
        {
            Label name = (Label)GridView_payod_002.Rows[i].Cells[0].FindControl("Label_item");
            TextBox txt = (TextBox)GridView_payod_002.Rows[i].Cells[0].FindControl("TextBox_amt");
            double n;
            if (!double.TryParse(txt.Text, out n))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "應扣項目 - " + name.Text + "請輸入正確金額", "", "");
                this.Page = tempPage;
                   return;
            }
        }
        //data_check
        for (int i = 0; i < GridView_payod_007.Rows.Count; i++)
        {
            Label name = (Label)GridView_payod_007.Rows[i].Cells[0].FindControl("Label_item");
            TextBox txt = (TextBox)GridView_payod_007.Rows[i].Cells[0].FindControl("TextBox_amt");
            double n;
            if (!double.TryParse(txt.Text, out n))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, name.Text + "請輸入正確金額", "", "");
                this.Page = tempPage;
               return;
            }
        }
        
        string v_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
    
       //    ====     總計資料變數    ====
        int v_add_amt  = 0 ;  //  應發合計
        int v_sub_amt  = 0 ;  //  應扣合計
        int v_tot_amt  = 0 ;  //  實發數(應發合計-應扣合計)

        int v_tax_amt  = 0 ;     // 所得總額
        int v_inco_amt = 0 ;     // 所得檔(申報金額)
        int v_inco_real_amt = 0 ;// 所得檔(所得金額)
        int v_inco_kdc = 0 ;     //  所得檔(主管加給)
        int v_inco_repl= 0 ;     //  所得檔(實物代金)(sainco取得)
        int v_inco_hous  = 0 ;   // 所得檔(房屋津貼)(sainco取得)
        int v_inco_txam = 0 ;    // 所得檔(所得稅)
        int v_inco_fee = 0;      // 所得檔(公勞軍保費)
        int v_inco_fees  = 0 ;   // 所得檔(健保費)
        int v_inco_leave_self  = 0 ; // 所得檔(退撫離職儲金)
        int v_inco_leave_sup  = 0 ;  // 所得檔(機關負擔退撫離職儲金)

        int v_pen_amt = 0 ;     //  勞工退休金(應扣項，但是要扣double) 所得檔(勞工退休金)

        int v_adj_amt  = 0 ;
        int v_adj_fee  = 0 ;    //  調薪補扣公勞軍保費
        int v_adj_self  = 0 ;   //  調薪補扣退撫離職儲金
        int v_adj_sup  = 0 ;    //  機關負擔退撫離職儲金   
        string v_base_tax_name  = "";

      string v_tax = gvResult.Rows[index].Cells[31].Text;

      switch (v_tax)
      {
          case "0":
              v_base_tax_name = "(無扣繳)";
              break;
          case "1":
              v_base_tax_name = "(照表扣繳)";
              break;
          case "2":
              v_base_tax_name = "(定額扣繳)";
              break;
          case "3":
              v_base_tax_name = "(比例扣繳)";
              break;
          case "4":
              v_base_tax_name = "(比例定額)";
              break;
      }

      string strPayoKindCodeType = cmbItemTyp1.SelectedValue;     //畫面查詢之項目種類一代碼
      string strPayoKindCodeNo = cmbItemTyp2.SelectedValue;       //畫面查詢之項目種類二代碼
      string strPayoKindCode = cmbItemTypeName.SelectedValue;     //畫面查詢之項目名稱代碼
      SAL3112 sal3112 = new SAL3112();
      DataTable dt = sal3112.queryItem_TaxData(this.strOrgCode, strPayoKindCodeType, strPayoKindCodeNo, strPayoKindCode);
      string v_item_tax = "";
      string v_item_type = "";
      if (dt != null && dt.Rows.Count > 0)
      {
           v_item_tax = dt.Rows[0]["item_tax"].ToString();        //是否扣稅(其他薪津)
           v_item_type = dt.Rows[0]["item_tax_type"].ToString();  // 扣繳種類(其他薪津)
      }
  /*    string v_item_type_name = "";

      switch (v_item_type)
      {
          case "A":
              v_item_type_name = "(全額扣繳)";
              break;
          case "B":
              v_item_type_name = "(比例扣繳)";
              break;
      }*/

      double v_amt = 0;
      string v_code_str = "";    //' 項目代碼
      string v_code_name = "";   //' 項目名稱(中文)
      string v_code_sys = "";    //' 項目代碼(payod_code_sys)
      string v_code_type = "";   //' 項目代碼(payod_code_type)
      string v_code_no = "";     //' 項目代碼(payod_code_no)
      string v_code = "";        //' 項目代碼(payod_code)
      string v_income = "";      //' 是否列入所得稅扣繳(Y/N)

      //====應發款====
      for (int i = 0; i < GridView_payod_001.Rows.Count; i++)
      {
          v_code_str = "";
          Label name = (Label)GridView_payod_001.Rows[i].Cells[0].FindControl("Label_item");        
          v_code_name = name.Text;
          v_code_sys = GridView_payod_001.Rows[i].Cells[1].Text.Replace("&nbsp;", "");
          v_code_type = GridView_payod_001.Rows[i].Cells[2].Text.Replace("&nbsp;", "");
          v_code_no = GridView_payod_001.Rows[i].Cells[3].Text.Replace("&nbsp;", "");
          v_code = GridView_payod_001.Rows[i].Cells[4].Text.Replace("&nbsp;", "");
          v_code_str = v_code_sys + "_" + v_code_type + "_" + v_code_no + "_" + v_code;

          TextBox txt = (TextBox)GridView_payod_001.Rows[i].Cells[0].FindControl("TextBox_amt");        
          v_amt = Convert.ToDouble(txt.Text);
          v_income = GridView_payod_001.Rows[i].Cells[5].Text.Replace("&nbsp;", "");
          //應發加總
          v_add_amt += Convert.ToInt32(v_amt);

          //所得稅
          if (v_income == "Y")
          {
              if ((v_code_sys == "003") && (v_code_type == "001") && ((v_code_no == "011") || (v_code_no == "012") || (v_code_no == "013")))
              {
                  v_adj_amt += Convert.ToInt32(v_amt);
              }
              else
              {
                  v_tax_amt += Convert.ToInt32(v_amt);
              }
          }
          //主管加給
          if ((v_code_sys == "003") && (v_code_type == "001") && (v_code_no == "004"))
          {
              v_inco_kdc = Convert.ToInt32(v_amt);
          }
          //更新 sapayod
          sal3112.editData(v_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
              , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text, v_code_sys, v_code_type, v_code_no, v_code);
      }  

      // 更新 sapayod 存總數(加項)
      sal3112.editData2(v_add_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
              , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text);


      //=====應扣款=====
      for (int i = 0; i < GridView_payod_002.Rows.Count; i++)
      {
          v_code_str = "";
          Label name = (Label)GridView_payod_002.Rows[i].Cells[0].FindControl("Label_item");
          v_code_name = name.Text;
          v_code_sys = GridView_payod_002.Rows[i].Cells[1].Text.Replace("&nbsp;", "");
          v_code_type = GridView_payod_002.Rows[i].Cells[2].Text.Replace("&nbsp;", "");
          v_code_no = GridView_payod_002.Rows[i].Cells[3].Text.Replace("&nbsp;", "");
          v_code = GridView_payod_002.Rows[i].Cells[4].Text.Replace("&nbsp;","");
          v_code_str = v_code_sys + "_" + v_code_type + "_" + v_code_no + "_" + v_code;

          TextBox txt = (TextBox)GridView_payod_002.Rows[i].Cells[0].FindControl("TextBox_amt");
          v_amt = Convert.ToDouble(txt.Text);
          v_income = GridView_payod_002.Rows[i].Cells[5].Text.Replace("&nbsp;", "");
          // 應扣加總
          v_sub_amt += Convert.ToInt32(v_amt);

          // 所得稅
          if (v_income == "Y")
          {
              v_tax_amt -= Convert.ToInt32(v_amt);
          }
             //' 調薪補扣公勞軍保費
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "012"))
          {
              v_adj_fee = Convert.ToInt32(v_amt);
          }
          
          //' 調薪補扣退撫離職儲金
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "013"))
          {
              v_adj_self = Convert.ToInt32(v_amt);
          }
             //' 勞工退休金
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "015"))
          {
              v_pen_amt = Convert.ToInt32(v_amt);
          }
              //' 健保費
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "002"))
          {
              v_inco_fees = Convert.ToInt32(v_amt);
          }
            //' 公勞軍保費
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "003"))
          {
              v_inco_fee = Convert.ToInt32(v_amt);
          }
             //' 退撫離職儲金
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "007"))
          {
              v_inco_leave_self = Convert.ToInt32(v_amt);
          }
             //' 所得稅
          if ((v_code_sys == "003") && (v_code_type == "002") && (v_code_no == "001"))
          {
              v_inco_txam = Convert.ToInt32(v_amt);
          }

          //更新 sapayod
           sal3112.editData3(v_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
              , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text, v_code_sys, v_code_type, v_code_no, v_code);
      }     

      //' 更新 sapayod 存總數(減項) 
      sal3112.editData4(v_sub_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
              , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text);


      // 實發數
      v_tot_amt = v_add_amt - v_sub_amt;

      // 更新 sapayod 存總數(實發數) 
      sal3112.editData5(v_tot_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
              , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text);

      //====機關負擔金額====
      for (int i = 0; i < GridView_payod_007.Rows.Count; i++)
      {
          v_code_str = "";
          Label name = (Label)GridView_payod_007.Rows[i].Cells[0].FindControl("Label_item");
          v_code_name = name.Text;
          v_code_sys = GridView_payod_007.Rows[i].Cells[1].Text.Replace("&nbsp;", "");
          v_code_type = GridView_payod_007.Rows[i].Cells[2].Text.Replace("&nbsp;", "");
          v_code_no = GridView_payod_007.Rows[i].Cells[3].Text.Replace("&nbsp;", "");
          v_code = GridView_payod_007.Rows[i].Cells[4].Text.Replace("&nbsp;", "");
          v_code_str = v_code_sys + "_" + v_code_type + "_" + v_code_no + "_" + v_code;

          TextBox txt = (TextBox)GridView_payod_007.Rows[i].Cells[0].FindControl("TextBox_amt");
          v_amt = Convert.ToDouble(txt.Text);
          v_income = GridView_payod_007.Rows[i].Cells[5].Text.Replace("&nbsp;", "");
           
          // 主管加給
          if ((v_code_sys == "003") && (v_code_type == "007") && (v_code_no == "004"))
          {
              v_adj_sup = Convert.ToInt32(v_amt);
          }
          // 主管加給
          if ((v_code_sys == "003") && (v_code_type == "007") && (v_code_no == "002"))
          {
              v_inco_leave_sup = Convert.ToInt32(v_amt);
          }
             // 更新 sapayod   
              sal3112.editData6(v_amt.ToString(), v_mid, v_datetime, txtpayo_yymm.Text, txtpayo_seqno.Text, txtpayo_orgid.Text, txtpayo_kind.Text, txtpayo_date.Text
                   , txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text, v_code_sys, v_code_type, v_code_no, v_code);    
      }

      // SAINCO
      // 取得 房屋津貼、食物代金      
      DataTable ndt = sal3112.getData(txtpayo_kind.Text, txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text, txtpayo_kind_code.Text, txtpayo_yymm.Text,
         txtpayo_seqno.Text, txtpayo_orgid.Text ,txtpayo_date.Text);

              if (ndt != null && ndt.Rows.Count >0 )
              {
                  string v_hous = ndt.Rows[0]["inco_hous_amt"].ToString();
                  string v_repl = ndt.Rows[0]["inco_repl_amt"].ToString();

                  if (v_hous != "")
                  {
                      v_inco_hous = Convert.ToInt32(v_hous); 
                      v_inco_repl = Convert.ToInt32(v_repl);
                  }
              }    

      v_tax_amt = v_tax_amt - v_inco_hous - v_inco_repl - v_pen_amt;  
      v_inco_real_amt = v_add_amt;
      v_inco_amt = v_tax_amt;
     string  v_numerator = gvResult.Rows[index].Cells[32].ToString();
     string  v_denominator = gvResult.Rows[index].Cells[33].ToString();

      if (cmb_uc_PayType.SelectedValue != "005")
      {
          //' 非其他薪津  
          if((v_tax == "3") || (v_tax == "4"))
          {
         
              v_inco_amt = Convert.ToInt32(Convert.ToString(v_inco_amt * Convert.ToInt32(v_numerator) / Convert.ToInt32(v_denominator)));
          }
      

          if (v_tax == "0")
          {
              v_inco_amt = 0;
          }
      }
      else  //' 其他薪津  
      {          
          if (v_item_tax == "Y")
          {       
              if (v_item_type == "A")
              {
                  //' 全額扣繳
                //  v_inco_amt = v_inco_amt; 
              }
              else
              {        
                  if ((v_tax == "3") || (v_tax == "4"))
                  {                    

                      v_inco_amt = Convert.ToInt32(Convert.ToString(v_inco_amt * Convert.ToInt32(v_numerator) / Convert.ToInt32(v_denominator)));
                  }

                  if (v_tax == "0")
                  {
                      v_inco_amt = 0;
                  }
              }
          }
          else
          {
              v_inco_amt = 0;
          }
      }         


      sal3112.editData7(v_inco_amt.ToString(), v_inco_txam.ToString(), v_inco_real_amt.ToString(), v_inco_kdc.ToString(), v_inco_fee.ToString()
          , v_inco_fees.ToString(), v_inco_leave_self.ToString(), v_inco_leave_sup.ToString()
          , v_pen_amt.ToString(), v_mid, v_datetime, txtpayo_kind.Text, txtpayo_kind_code_type.Text,
          txtpayo_kind_code_no.Text, txtpayo_kind_code.Text, txtpayo_yymm.Text, txtpayo_seqno.Text,txtpayo_orgid.Text, txtpayo_date.Text);

     
      if (v_adj_amt != 0 || v_adj_fee != 0 || v_adj_self != 0 || v_adj_sup != 0)
      {    
      sal3112.editData8(v_adj_amt.ToString(), v_mid, v_datetime, v_adj_fee.ToString(), v_adj_self.ToString()
      , v_adj_sup.ToString(), txtpayo_yymm.Text , txtpayo_seqno.Text, txtpayo_orgid.Text);       
      }   
        


      // 試算勞保, 勞退 需回存SAPAYO
      string v_labor_days = this.Label_payo_labor_days.Text;
      string v_pen_days = this.Label_payo_pen_days.Text;
      string v_pen_sup_days = this.Label_payo_pen_sup_days.Text;


      if ((!string.IsNullOrEmpty(v_labor_days)) || (!string.IsNullOrEmpty(v_pen_days)) || (!string.IsNullOrEmpty(v_pen_sup_days)))
      {     
          sal3112.editData9(v_mid, v_labor_days, v_pen_days, v_pen_sup_days, txtpayo_orgid.Text, txtpayo_seqno.Text, txtpayo_yymm.Text
              , txtpayo_kind.Text, txtpayo_date.Text);
      }

      if (txtMemo.Text != "")  //備註
      {
          string v_code_Kind = "";
          if (txtpayo_kind.Text != "005")
          {
              v_code_Kind = "P";
          }
          else
          {
              v_code_Kind = "D";
          }
          string codesys = "";
          if ((this.txtpayo_kind.Text != "005"))
          {
              codesys = "003";
          }
          else
          {
              codesys = "005";
          }        

          sal3112.editData10(txtpayo_kind.Text, txtpayo_seqno.Text, codesys, txtpayo_kind_code_type.Text, txtpayo_kind_code_no.Text
              , txtpayo_kind_code.Text, txtpayo_yymm.Text, txtpayo_date.Text, txtpayo_orgid.Text, v_code_Kind, txtMemo.Text, v_mid);
      }

   
      
      pnlDetail.Visible = false;
      Panel1.Visible = false;
        searchview.Visible = true;
      Page te = this.Page;
      CommonFun.MsgShow(ref te,
         CommonFun.Msg.Custom, "修改完成", "", "");
      this.Page = te;
      doQuery();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3112_01.aspx");
    }
    protected void cmbItemTyp1_SelectedIndexChanged(object sender, EventArgs e)
    {
        view.Visible = false;
        bindItemTyp2();
        bindItemTypeName();
        queryDatePayed();
    }
    protected void cmbItemTyp2_SelectedIndexChanged(object sender, EventArgs e)
    {
        view.Visible = false;
        bindItemTypeName();
        queryDatePayed();
    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {       
      
        gvResult.Columns[8].Visible = true;
        gvResult.Columns[9].Visible = true;
        gvResult.Columns[10].Visible = true;
        gvResult.Columns[11].Visible = true;
        gvResult.Columns[12].Visible = true;
        gvResult.Columns[13].Visible = true;
        gvResult.Columns[14].Visible = true;
        gvResult.Columns[15].Visible = true;
        gvResult.Columns[16].Visible = true;
        gvResult.Columns[17].Visible = true;
        gvResult.Columns[18].Visible = true;
        gvResult.Columns[19].Visible = true;
        gvResult.Columns[20].Visible = true;
        gvResult.Columns[21].Visible = true;
        gvResult.Columns[22].Visible = true;
        gvResult.Columns[23].Visible = true;
        gvResult.Columns[24].Visible = true;
        gvResult.Columns[25].Visible = true;
        gvResult.Columns[26].Visible = true;
        gvResult.Columns[27].Visible = true;
        gvResult.Columns[28].Visible = true;
        gvResult.Columns[29].Visible = true;
        gvResult.Columns[30].Visible = true;
        gvResult.Columns[31].Visible = true;
        gvResult.Columns[32].Visible = true;
        gvResult.Columns[33].Visible = true;
        gvResult.Columns[34].Visible = true;
        gvResult.Columns[35].Visible = true;
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
       
        gvResult.Columns[8].Visible = false;
        gvResult.Columns[9].Visible = false;
        gvResult.Columns[10].Visible = false;
        gvResult.Columns[11].Visible = false;
        gvResult.Columns[12].Visible = false;
        gvResult.Columns[13].Visible = false;
        gvResult.Columns[14].Visible = false;
        gvResult.Columns[15].Visible = false;
        gvResult.Columns[16].Visible = false;
        gvResult.Columns[17].Visible = false;
        gvResult.Columns[18].Visible = false;
        gvResult.Columns[19].Visible = false;
        gvResult.Columns[20].Visible = false;
        gvResult.Columns[21].Visible = false;
        gvResult.Columns[22].Visible = false;
        gvResult.Columns[23].Visible = false;
        gvResult.Columns[24].Visible = false;
        gvResult.Columns[25].Visible = false;
        gvResult.Columns[26].Visible = false;
        gvResult.Columns[27].Visible = false;
        gvResult.Columns[28].Visible = false;
        gvResult.Columns[29].Visible = false;
        gvResult.Columns[30].Visible = false;
        gvResult.Columns[31].Visible = false;
        gvResult.Columns[32].Visible = false;
        gvResult.Columns[33].Visible = false;
        gvResult.Columns[34].Visible = false;
        gvResult.Columns[35].Visible = false;
    }

    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        doQuery();
    }
    protected void cmbItemTypeName_SelectedIndexChanged(object sender, EventArgs e) //項目名稱改變
    {
        view.Visible = false;
        queryDatePayed();
    }
}