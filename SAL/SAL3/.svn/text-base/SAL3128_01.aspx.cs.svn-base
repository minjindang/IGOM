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

public partial class SAL3128_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UcSaCode4.ReturnEvent = true;
        UcSaCode4.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(UcSaCode4changr);

        if (Page.IsPostBack) return;
        string date = DateTime.Now.ToString("yyyyMMdd");
        int ym = int.Parse(date) - 19110000;

        UcDate1.Text = ym.ToString().Substring(0, 5) + "01";
        UcDate2.Text = ym.ToString();
    }

   
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }

    //匯出代扣稅額總計
    private void ExportReport()
    {
        SAL3128 sal3128 = new SAL3128();
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string strbase_dep = "ALL";
        string strcno = "ALL";
        string strname = txtname.Text;              //員工姓名 
        string strno = txtno.Text;                  //身分證
        string strdate1 = UcDate1.Text;             //給付起日
        string strdate2 = UcDate2.Text;             //給付迄日
        string strinco_amt = DropDownList2.SelectedValue; //所得申報
        string strBudget_code = UcSaCode1.SelectedValue;//預算來源

        DataTable datat = sal3128.queryReportData(strOrgCode, strbase_dep, strcno, strname, strno, strdate1, strdate2
            ,strinco_amt, strBudget_code);

        if (datat != null && datat.Rows.Count > 0)
        {
          string txam=  datat.Rows[0]["txam"].ToString();
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "待扣稅額總計：" + txam + "元" , "", "");
            this.Page = tempPage;
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
        
    }

    //檢視所得項目
    protected void UcSaCode4changr(object sender, EventArgs e) 
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



    //查詢
    protected void Search_Click(object sender, EventArgs e)
    {
        Searchdata();
    }

    protected void Searchdata()   
    {
      SAL3128 sal3128 = new SAL3128();
      string strdate1 = UcDate1.Text;             //給付起日
      if (strdate1 != "")
          strdate1 = (int.Parse(strdate1) + 19110000).ToString();
      string strdate2 = UcDate2.Text;             //給付迄日
      if (strdate2 != "")
          strdate2 = (int.Parse(strdate2) + 19110000).ToString();

            string strBudget_code = UcSaCode1.SelectedValue;//預算來源
            string strinco_amt = DropDownList2.SelectedValue; //所得申報
            string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            string strbase_dep = "ALL";       //單位　
            string strcno = "ALL";     //員工類別
            string strname = txtname.Text;              //員工姓名 
            string strno = txtno.Text;                  //身分證編號       
       
        DataTable datat = sal3128.querySearchData(strOrgCode, strbase_dep, strcno, strname, strno, strdate1, strdate2
         , strinco_amt, strBudget_code);
    
        if (datat != null && datat.Rows.Count > 0)
        {
            datat.Columns.Add("alldate");//所得給付區間
            for (int i = 0; i < datat.Rows.Count; i++)
            {
                datat.Rows[i]["alldate"] = datat.Rows[i]["mindate"].ToString() + "-" + datat.Rows[i]["maxdate"].ToString();
            }
            
            GridView1.Columns[6].Visible = true;
            GridView1.Columns[7].Visible = true;
            GridView1.Columns[8].Visible = true;          
            GridView1.DataSource = datat;
            GridView1.DataBind();         
            GridView1.Columns[6].Visible = false;
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[8].Visible = false;
            view.Visible = true;
            UcPager.Visible = true;
        }
        else
        {
            view.Visible = true;           
            GridView1.DataSource = datat;
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

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        view.Visible = false;
        title.Visible = false;

        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        lbIndex.Text = gvr.RowIndex.ToString();
        name.Text = gvr.Cells[8].Text;
        idno.Text = gvr.Cells[7].Text;
        Detaildata();      
    }

    protected void Detaildata()
    {
            string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            string strno = GridView1.Rows[CommonFun.getInt(lbIndex.Text)].Cells[6].Text;  //點選人員之員工編號
            string strdate1 = UcDate1.Text;             //給付起日
            if (strdate1 != "")
                strdate1 = (int.Parse(strdate1) + 19110000).ToString();
            string strdate2 = UcDate2.Text;             //給付迄日
            if (strdate2 != "")
                strdate2 = (int.Parse(strdate2) + 19110000).ToString();
            string strinco_amt = DropDownList2.SelectedValue; //所得申報
            string strBudget_code = UcSaCode1.SelectedValue;//預算來源

            //清冊查詢
            SAL3128 sal3128 = new SAL3128();
            DataTable datat = sal3128.queryDetailData(strOrgCode, strno, strdate1, strdate2, strinco_amt, strBudget_code);
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
                GridView_Inco.Columns[1].Visible = false;         

                //ADD ddl Data   
                for (int i = 0; i < datat.Rows.Count; i++)
                {
                    DropDownList ddl = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_code");
                    ListItem item = new ListItem();
                    item.Text = SALARY.Logic.app.GetSaCode_Desc1("003", "005", datat.Rows[i]["inco_code"].ToString());
                    item.Value = datat.Rows[i]["inco_code"].ToString();
                    ddl.Items.Add(item);
                    ddl.SelectedValue = datat.Rows[i]["inco_code"].ToString();
                    ddl.Enabled = false;

                    // 發放種類為005(其他薪津時，需要呈現的項目代碼)     
                    DropDownList ddl1 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_kind_code");

                    ListItem item1 = new ListItem();
                    string inco_kind_code = datat.Rows[i]["inco_kind_code"].ToString();
                    string inco_kind_code_no = datat.Rows[i]["inco_kind_code_no"].ToString();
                    DataTable kindcode = sal3128.querykindcodeData(strOrgCode, inco_kind_code, inco_kind_code_no);
                    if (kindcode != null && kindcode.Rows.Count > 0)
                    {   //ted 0721
                        //     item1.Text = SALARY.Logic.app.GetSaCode_Desc1("003", "005", datat.Rows[i]["inco_kind_code"].ToString());
                        item1.Text = kindcode.Rows[0]["item_name"].ToString(); 
                        item1.Value = datat.Rows[i]["inco_kind_code"].ToString(); 
                        ddl1.Items.Add(item1);
                        ddl1.SelectedValue = datat.Rows[i]["inco_kind_code"].ToString();
                    }
                     
                    ddl1.Enabled = false;
                    ddl1.Visible = false;
                    if (ddl.SelectedValue == "005")   
                    {
                        ddl1.Visible = true;
                    }     
                    

                    DropDownList ddl2 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_icode");
                    ListItem item2 = new ListItem();
                    item2.Text = SALARY.Logic.app.GetSaCode_Desc1("003", "004", datat.Rows[i]["inco_icode"].ToString());
                    item2.Value = datat.Rows[i]["inco_icode"].ToString();
                    ddl2.Items.Add(item2);
                    ddl2.SelectedValue = datat.Rows[i]["inco_icode"].ToString();
                    ddl2.Enabled = false;

                    DropDownList ddl3 = (DropDownList)GridView_Inco.Rows[i].FindControl("inco_budget_code");
                    ListItem item3 = new ListItem();
                    item3.Text = SALARY.Logic.app.GetSaCode_Desc1("002", "018", datat.Rows[i]["inco_budget_code"].ToString());
                    item3.Value = datat.Rows[i]["inco_budget_code"].ToString();
                    ddl3.Items.Add(item3);
                    ddl3.SelectedValue = datat.Rows[i]["inco_budget_code"].ToString();
                    ddl3.Enabled = false;

                    Panel1.Visible = true;
                    edit.Visible = true;
                }          
            }
            else
            {
                Panel1.Visible = true;
                edit.Visible = true;               
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
                this.Page = tempPage;             
            }
      }


    // 重置
    protected void Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3128_01.aspx");
    }
    protected void GridView_Inco_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    // 刪除資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int dindex = int.Parse(txtFuncParam.Value.Trim());
        string inco_prikey = GridView_Inco.Rows[dindex].Cells[1].Text;

        SAL3128 sal3128 = new SAL3128();
        sal3128.querydeleteData(inco_prikey);
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = tempPage;
        Searchdata();
        Detaildata();    
    }

    //修改
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        SAL3128 sal3128 = new SAL3128();
        for (int i = 0; i < GridView_Inco.Rows.Count; i++)
        { 
            TextBox inco_amt = (TextBox)GridView_Inco.Rows[i].Cells[0].FindControl("inco_amt");      //申報金額
            TextBox inco_txam = (TextBox)GridView_Inco.Rows[i].Cells[0].FindControl("inco_txam");    //扣繳稅額 
            string inco_muser = LoginManager.UserId;//登入者員工編號
            string inco_prikey = GridView_Inco.Rows[i].Cells[1].Text; //key
            sal3128.queryeditData(inco_amt.Text, inco_txam.Text, inco_muser, inco_prikey);
        }
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = tempPage;
  //      Searchdata();
        Detaildata();
    }
    //維護回上頁
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        view.Visible = true;
        title.Visible = true;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3128_02.aspx");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Searchdata();
     
    }
}