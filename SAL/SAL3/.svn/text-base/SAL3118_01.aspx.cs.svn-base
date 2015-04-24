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
using EMPPLM.Logic;

public partial class SAL_SAL3_SAL3118 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e) 
    {
        cmbDepartID.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(cmbDepart2_changed);//單位名稱


        code_no.ReturnEvent = true;
        code_no.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(ItemChanged);//畫面下拉變更時  (其他薪津)

        UcSaCode4.ReturnEvent = true;
        UcSaCode4.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(UcSaCode4changr);


        DropDownList Code3 = (DropDownList)UcSaCode3.FindControl("DropDownList_code_no");
 
        if (Page.IsPostBack) return;  
        Code3.SelectedValue = "001";
        Code3.Enabled = false;
        cmbDepartID.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        ucDateDropDownList.Kind = code_no.SelectedValue.ToString();
        string year = DateTime.Now.ToString("yyyy");
        ucDateDropDownList.year_e = (int.Parse(year) - 2).ToString();
        ucDateDropDownList.year_s = (int.Parse(year) + 1).ToString();
    }

    protected void cmbDepart2_changed(object sender, EventArgs e)
    {
        Name_Bind();
    }

    protected void Name_Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        Emp_Member empMember = new Emp_Member();
        DataTable dt = new FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, cmbDepartID.SelectedValue);

        ddlName.Orgcode = Orgcode;
        ddlName.DepartId = cmbDepartID.SelectedValue;

    }

    protected void UcSaCode4changr(object sender, EventArgs e) //檢視所得項目
    {
        if (UcSaCode4.SelectedValue != "ALL")
        {
            if (GridView_Inco.Rows.Count > 0)
            {
                for (int i = 0; i < GridView_Inco.Rows.Count; i++)
                {
                    DropDownList ddl = (DropDownList)GridView_Inco.Rows[i].Cells[0].FindControl("inco_code");
                    if (ddl.SelectedValue == UcSaCode4.SelectedValue)
                    {
                        GridView_Inco.Rows[i].Visible = true;
                    }
                    else
                    {
                        GridView_Inco.Rows[i].Visible = false;
                    }
                }
            }
        }
        else
        {
            if (GridView_Inco.Rows.Count > 0)
            {
                for (int i = 0; i < GridView_Inco.Rows.Count; i++)
                {
                    GridView_Inco.Rows[i].Visible = true;
                }
            }        
        }
        
    }
    protected void ItemChanged(object sender, EventArgs e)
    {      

        //傳入參數kind=所得項目一代碼，year_s=今年-2(西元年:2012)，year_e=今年+1(西元年:2015)
        //傳回參數DateStr
        ucDateDropDownList.Kind = code_no.SelectedValue.ToString();
        string year = DateTime.Now.ToString("yyyy");
        ucDateDropDownList.year_e = (int.Parse(year) - 2).ToString();
        ucDateDropDownList.year_s = (int.Parse(year)+1).ToString();

        if (code_no.SelectedValue.ToString() == "005") //其他薪津
        {
            //所得項目二：所得項目一代碼為005時，方可顯示。
            DropDownList1.Visible = true;
            DropDownList1.Items.Clear();
            SAL3118 sal3118 = new SAL3118();
            string orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
            DataTable datat = sal3118.queryddlData(orgid);
            if (datat != null && datat.Rows.Count > 0)
            {      
                for (int i = 0; i < datat.Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = datat.Rows[i]["pitm_code"].ToString();
                    item.Text = datat.Rows[i]["item_name"].ToString();
                    DropDownList1.Items.Add(item);    
                }
                selectcode_no();
            }

            //所得項目一代碼為005時，方可顯示。其他項目固定填入公務預算(001)          
            DropDownList Code3 = (DropDownList)UcSaCode3.FindControl("DropDownList_code_no");
            Code3.Enabled = true;
        }
        else
        {
            //所得項目二：所得項目一代碼為005時，方可顯示。
            DropDownList1.Visible = false;
            //所得項目一代碼為005時，方可顯示。其他項目固定填入公務預算(001)  
            DropDownList Code3 = (DropDownList)UcSaCode3.FindControl("DropDownList_code_no");
            Code3.SelectedValue = "001";
            Code3.Enabled = false;
        }
    }
   
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }

    //匯出代扣稅額總計
    private void ExportReport()
    {        
        SAL3118 sal3118 = new SAL3118();
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string strbase_dep = cmbDepartID.SelectedValue;  //單位　
        string strcno = ddlcno.SelectedValue;       //員工類別
        string strAct = ddlAct.SelectedValue;       //在職狀態
        string strname = ddlName.SelectedValue;       //員工姓名 
        string strno = txtno.Text;                  //員工編號
        string strdate1 = UcDate1.Text;             //給付起日
        string strdate2 = UcDate2.Text;             //給付迄日
        string strinco_amt = DropDownList2.SelectedValue; //所得申報
        string strBudget_code = UcSaCode1.SelectedValue;//預算來源

        DataTable datat = sal3118.queryReportData(strOrgCode,strbase_dep, strcno,strAct,strname, strno, strdate1, strdate2
            ,strinco_amt, strBudget_code); 

        if (datat != null && datat.Rows.Count > 0)
        {
          string txam=  datat.Rows[0]["txam"].ToString();
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "代扣稅額總計: "+txam+"元" , "", "");
            this.Page = tempPage;
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
        
    }
    //查詢
    protected void Search_Click(object sender, EventArgs e)
    {
        Searchdata();
    }

    protected void Searchdata()   
    {
            SAL3118 sal3118 = new SAL3118();
            string strdate1 = UcDate1.Text;             //給付起日
            if(strdate1 !="")
            strdate1 = (int.Parse(strdate1) + 19110000).ToString();
            string strdate2 = UcDate2.Text;             //給付迄日
            if(strdate2 !="")
            strdate2 = (int.Parse(strdate2) + 19110000).ToString();
            string strBudget_code = UcSaCode1.SelectedValue;//預算來源
            string strinco_amt = DropDownList2.SelectedValue; //所得申報
            string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            string strbase_dep = cmbDepartID.SelectedValue;       //單位　
            string strcno = ddlcno.SelectedValue;       //員工類別
            string strAct = ddlAct.SelectedValue;       //在職狀態
            string strname = ddlName.SelectedValue;                 //員工姓名 
            string strno = txtno.Text;                  //員工編號       
            string strinco_code = UcSaCode5.SelectedValue; //薪資種類

        DataTable datat = sal3118.querySearchData(strOrgCode, strbase_dep, strcno, strAct, strname, strno, strdate1, strdate2
         , strinco_amt, strBudget_code ,strinco_code);

        if (datat != null && datat.Rows.Count > 0)
        {
            datat.Columns.Add("alldate");//所得給付區間

            for (int i = 0; i < datat.Rows.Count; i++)
            {
                datat.Rows[i]["alldate"] = (Convert.ToInt32(datat.Rows[i]["mindate"].ToString().Substring(0, 4)) - 1911) +"/"+
                    datat.Rows[i]["mindate"].ToString().Substring(4, 2)+"/" + datat.Rows[i]["mindate"].ToString().Substring(6, 2) +
                    "-" +
                     (Convert.ToInt32(datat.Rows[i]["maxdate"].ToString().Substring(0, 4)) - 1911) +"/"+
                    datat.Rows[i]["maxdate"].ToString().Substring(4, 2) +"/"+ datat.Rows[i]["maxdate"].ToString().Substring(6, 2);
            }

            GridView1.Columns[8].Visible = true;
            GridView1.Columns[6].Visible = true;
            GridView1.Columns[7].Visible = true;
            view.Visible = true;
            UcPager.Visible = true;
            GridView1.Visible = true;
            GridView1.DataSource = datat;
            GridView1.DataBind();
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[6].Visible = false;
            GridView1.Columns[7].Visible = false;
        }
        else
        {
            datat.Columns.Add("alldate");//所得給付區間
            view.Visible = true;
            GridView1.Visible = true;
            GridView1.Columns[8].Visible = true;
            GridView1.Columns[6].Visible = true;
            GridView1.Columns[7].Visible = true;
            GridView1.DataSource = datat;
            GridView1.DataBind();
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[6].Visible = false;
            GridView1.Columns[7].Visible = false;

            if (GridView1.Rows.Count > 0)
            {
                UcPager.Visible = true;
            }
            else
            {
                UcPager.Visible = false;
            }
        }

    }

    public int index;
    //點選清單列資料時
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetail") 
        {
            DropDownList1.Visible = false;
            index = Convert.ToInt32(e.CommandArgument);
            indexno.Text = index.ToString();

            Panel1.Visible = true;
            edit.Visible = true;
            add.Visible = false;
            add_btn.Visible = true;

            searchtitle.Visible = false;
            view.Visible = false;
            UcPager.Visible = false;

            name.Text = GridView1.Rows[index].Cells[8].Text;
            idno.Text = GridView1.Rows[index].Cells[7].Text;            
           
            Detaildata();      
        }     
    }

    protected void Detaildata()//清單資料
    {
            index = int.Parse(indexno.Text);
            string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            string strno = GridView1.Rows[index].Cells[6].Text;  //點選人員之員工編號
            string strdate1 = UcDate1.Text;             //給付起日
            if (strdate1 != "")
                strdate1 = (int.Parse(strdate1) + 19110000).ToString();
            string strdate2 = UcDate2.Text;             //給付迄日
            if (strdate2 != "")
                strdate2 = (int.Parse(strdate2) + 19110000).ToString();
            string strinco_amt = DropDownList2.SelectedValue; //所得申報
            string strBudget_code = UcSaCode1.SelectedValue;//預算來源
            string strinco_code = UcSaCode5.SelectedValue;// 薪資種類

            //清冊查詢
            SAL3118 sal3118 = new SAL3118();
            DataTable datat = sal3118.queryDetailData(strOrgCode, strno, strdate1, strdate2, strinco_amt, strBudget_code, strinco_code);

       
            if (datat != null && datat.Rows.Count > 0)
            {
                for (int i = 0; i < datat.Rows.Count; i++)
                {
                    //所得年月
                    string yymm = datat.Rows[i]["inco_ym"].ToString();
                    if (yymm.Length > 4)
                    {
                        int yy = int.Parse(yymm.Substring(0, 4)) - 1911;
                        string mm = yymm.Substring(4, 2); 
                        datat.Rows[i]["inco_ym"] = "民國" + yy + "年" + mm + "月";
                    }
                    else
                    {
                        int yy = int.Parse(yymm.Substring(0, 4)) - 1911;
                        datat.Rows[i]["inco_ym"] = "民國" + yy + "年";
                    }
                  
                    //給付日期
                    string yymmdd = datat.Rows[i]["inco_date"].ToString();
                    int yy2 = int.Parse(yymmdd.Substring(0, 4)) - 1911;
                    string mm2 = yymmdd.Substring(4, 2);
                    string dd = yymmdd.Substring(6, 2);
                    datat.Rows[i]["inco_date"] = "民國" + yy2 + "年" + mm2 + "月" + dd + "日";
                                 
                }

                GridView_Inco.Columns[1].Visible = true; //KEY
                GridView_Inco.DataSource = datat;
                GridView_Inco.DataBind();
                GridView_Inco.Visible = true;
                GridView_Inco.Columns[1].Visible = false;

             
                //ADD ddl Data   
                for (int i = 0; i < datat.Rows.Count; i++)
                {
                  //  Response.Write(datat.Rows[i]["inco_code"].ToString() + "," +
                  //      SALARY.Logic.app.GetSaCode_Desc1("003", "005", datat.Rows[i]["inco_code"].ToString())+"<br>");

                   //所得項目
                    DropDownList ddl = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_code");
                    ListItem item = new ListItem();
                    item.Text = SALARY.Logic.app.GetSaCode_Desc1("003", "005", datat.Rows[i]["inco_code"].ToString());
                    item.Value = datat.Rows[i]["inco_code"].ToString();
                    ddl.Items.Add(item);
                    ddl.SelectedValue = datat.Rows[i]["inco_code"].ToString();
                    ddl.Enabled = false;
                                
                               
                    DropDownList ddl1 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_kind_code");
                    ddl1.Items.Clear();
                    if (ddl.SelectedValue == "005")   // 發放種類為005(其他薪津時，需要呈現的項目代碼)     
                    {   
                    ListItem item1 = new ListItem();
                    string inco_kind_code = datat.Rows[i]["inco_kind_code"].ToString();
                    string inco_kind_code_no = datat.Rows[i]["inco_kind_code_no"].ToString();
                    DataTable kindcode = sal3118.querykindcodeData(strOrgCode, inco_kind_code, inco_kind_code_no);
                  
                    if (kindcode != null && kindcode.Rows.Count > 0)
                    {
                        item1.Text = kindcode.Rows[0]["item_name"].ToString(); //SALARY.Logic.app.GetSaCode_Desc1("003", "005", datat.Rows[i]["inco_kind_code"].ToString());
                        item1.Value = datat.Rows[i]["inco_kind_code"].ToString();
                        ddl1.Items.Add(item1);
                        ddl1.SelectedValue = datat.Rows[i]["inco_kind_code"].ToString();   
                    }
                        ddl1.Enabled = false;
                        ddl1.Visible = true;
                    }
                    else
                    {
                        ddl1.Visible = false;
                    }
               
                    //所得格式
                    DropDownList ddl2 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_icode");
                    ListItem item2 = new ListItem();
                    item2.Text = SALARY.Logic.app.GetSaCode_Desc1("003", "004", datat.Rows[i]["inco_icode"].ToString());
                    item2.Value = datat.Rows[i]["inco_icode"].ToString();
                    ddl2.Items.Add(item2);
                    ddl2.SelectedValue = datat.Rows[i]["inco_icode"].ToString();
                    ddl2.Enabled = false;
   
                    //預算來源
                    DropDownList ddl3 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_budget_code");
                    ListItem item3 = new ListItem();
                    item3.Text = SALARY.Logic.app.GetSaCode_Desc1("002", "018", datat.Rows[i]["inco_budget_code"].ToString());
                    item3.Value = datat.Rows[i]["inco_budget_code"].ToString();
                    ddl3.Items.Add(item3);
                    ddl3.SelectedValue = datat.Rows[i]["inco_budget_code"].ToString();
                    ddl3.Enabled = false;
            
                }          
            }
            else
            {  
             /*   Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
                this.Page = tempPage;
              */ 
                Panel1.Visible = true;
                add.Visible = false;
                edit.Visible = true;
                GridView_Inco.Visible = false;

                searchtitle.Visible = false;
                view.Visible = false;
                UcPager.Visible = false;
            }
      }


    // 重置
    protected void Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3118_01.aspx");
    }
    protected void GridView_Inco_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    // 刪除資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int dindex = int.Parse(txtFuncParam.Value.Trim());
        string inco_prikey = GridView_Inco.Rows[dindex].Cells[1].Text;
        
        SAL3118 sal3118 = new SAL3118();
        sal3118.querydeleteData(inco_prikey);
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = tempPage;    
        Detaildata();    
    }

    //修改
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        if (GridView_Inco.Rows.Count == 0)
        {
            return;
        }

        SAL3118 sal3118 = new SAL3118();
        for (int i = 0; i < GridView_Inco.Rows.Count; i++)
        { 
            TextBox inco_amt = (TextBox)GridView_Inco.Rows[i].Cells[0].FindControl("inco_amt");      //申報金額
            TextBox inco_txam = (TextBox)GridView_Inco.Rows[i].Cells[0].FindControl("inco_txam");    //扣繳稅額 
            string inco_muser = LoginManager.UserId;//登入者員工編號
            string inco_prikey = GridView_Inco.Rows[i].Cells[1].Text; //key
            sal3118.queryeditData(inco_amt.Text, inco_txam.Text, inco_muser, inco_prikey);
        }
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = tempPage;
        Detaildata();
    }
    //維護回上頁
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        add.Visible = false;

        searchtitle.Visible = true;
        view.Visible = true;
        UcPager.Visible = true;

        Searchdata();
    }
    //新增按鈕
    protected void add_btn_Click(object sender, EventArgs e)
    {
        edit.Visible = false;
        add.Visible = true;
        add_btn.Visible = false;
        DropDownList1.Visible = false;

        searchtitle.Visible = false;
        view.Visible = false;
        UcPager.Visible = false;

        Label2.Visible = false;
        UcSaCode4.Visible = false;

        code_no.SelectedValue = "001";
        UcDate3.Text = TextBox1.Text = TextBox2.Text = TextBox3.Text = "";
              
    }
    //確認新增按鈕
    protected void add_ok_Click(object sender, EventArgs e)
    {
        index = int.Parse(indexno.Text);
        if (UcDate3.Text != "" && TextBox1.Text != "")
        {
            SAL3118 sal3118 = new SAL3118();
            //(1)取得prikey
            DataTable datat = sal3118.querykeyData();
            string prikey = DateTime.Now.ToString("yyyyMMdd") + datat.Rows[0][0].ToString(); //key
            string strno = GridView1.Rows[index].Cells[6].Text;  // 員工編號
            string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            string strcodeno = code_no.SelectedValue.ToString(); //所得項目一代碼
            string yymm = ucDateDropDownList.DateStr; //所得年月
            string date = UcDate3.Text;//給付日期
            date = (int.Parse(date.Substring(0, 3)) + 1911).ToString() + date.Substring(3, 4);
            string type = UcSaCode2.SelectedValue;//所得格式代碼;
            string inco_amt = TextBox1.Text;//申報金額
            string inco_txra = TextBox2.Text;//扣繳稅率
            string inco_txam = TextBox3.Text;//扣繳稅額
            string inco_muser = LoginManager.UserId;//登入者員工編號
            string inco_budget_code = UcSaCode3.SelectedValue;//預算來源
            string ddl2;
            if (code_no.SelectedValue == "005")  //三段代碼 //非其他薪津填(000)
            {
                ddl2 = DropDownList1.SelectedValue;
            }
            else
            {
                ddl2 = "000";
            }
   
     //      Response.Write(strno+","+ strOrgCode+","+ strcodeno+","+ yymm+","+ date+","+ type+","+ inco_amt+","+ inco_txra+","+ inco_txam+","+ inco_muser+","+ prikey+","+ ddl2);

            sal3118.queryaddData(strno, strOrgCode, strcodeno, yymm, date, type, inco_amt, inco_txra, inco_txam, inco_muser,
                                 prikey, ddl2,inco_budget_code);

            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "新增成功", "", "");
            this.Page = tempPage;

            add.Visible = false;

            edit.Visible = true;
            add_btn.Visible = true;
            Label2.Visible = true;
            UcSaCode4.Visible = true;

            Detaildata();
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請輸入資料", "", "");
            this.Page = tempPage;  
        }
    }

    //新增回上頁
    protected void add_cancel_Click(object sender, EventArgs e)
    {  
     
        add.Visible = false;
        edit.Visible = true;
        add_btn.Visible = true;
        Label2.Visible = true;
        UcSaCode4.Visible = true;

        searchtitle.Visible = false;
        view.Visible = false;
        UcPager.Visible = false;

    }

    //選擇後將所得格式代碼code_no=item_icode
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectcode_no();
    }

    protected void selectcode_no()
    { 
        string code_no = DropDownList1.SelectedValue;
        string[] oArray = code_no.Split('_');
        UcSaCode2.Code_no = oArray[3].ToString();
    }

      
    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[6].Visible = true;
        GridView1.Columns[7].Visible = true;
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        GridView1.Columns[8].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;
    }
    
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
     
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex; 
        Searchdata();
    }
}