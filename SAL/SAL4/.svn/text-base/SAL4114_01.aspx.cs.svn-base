
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
using System.Web.UI.HtmlControls;

public partial class SAL_SAL4_SAL4114 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_orgid.Text =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        TextBox_mid.Text = LoginManager.UserId;   //Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString
             
        if (Page.IsPostBack) return;

        GetData();
    }    

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
      
    }

    //UcSaCode_bank 改變
    protected void BankChanged(object sender, EventArgs e)
    {
        int index =int.Parse(((uc_ucSaCode)sender).CommandArgument); //抓index 

        string tdpf_bank = ((uc_ucSaCode)GridView_tdpf.Rows[index].Cells[1].FindControl("UcSaCode_bank")).Code_no; //change bank no

        HtmlTableRow dp_medi = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_medi");
        HtmlTableRow dp_title = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_title");     
        if (tdpf_bank == "004")//郵局
        {
            dp_medi.Visible = true;
            dp_title.Visible = true;
        }
        else
        {
            dp_medi.Visible = false;
            dp_title.Visible = false;
        }

        HtmlTableRow dp_no = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_no");
        //--台銀,寶華銀行,土地銀行,華南銀行,兆豐,玉山,彰化
        if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "016" || tdpf_bank == "003" || tdpf_bank == "020" || tdpf_bank == "006")
        {
            dp_no.Visible = true;
        }
        else
        {
            dp_no.Visible = false;
        }

        HtmlTableRow dp_entno = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_entno");
        //--彰銀,台北商銀,台北一信,台新銀行,永豐銀行,安泰銀行
        if (tdpf_bank == "006" || tdpf_bank == "009" || tdpf_bank == "017" || tdpf_bank == "025" || tdpf_bank == "027" || tdpf_bank == "021")
        {
            dp_entno.Visible = true;
        }
        else
        {
            dp_entno.Visible = false;
        }

        Label dp_entno_name = (Label)GridView_tdpf.Rows[index].Cells[1].FindControl("Label_tdpf_entno");
        //企業編號、轉帳組別(tdpf_entno)，中文說明
        if (tdpf_bank == "006" || tdpf_bank == "009" || tdpf_bank == "017" || tdpf_bank == "025")
        {
            //-- 彰銀,台北商銀,台北一信,台新銀行
            dp_entno_name.Text = "企業編號";
        }
        else if (tdpf_bank == "021")
        {
            //-- 安泰銀行
            dp_entno_name.Text = "轉帳組別";
        }
        else if (tdpf_bank == "027")
        {
            //-- 永豐銀行
            dp_entno_name.Text = "代理編號";
        }
        else
        {
            dp_entno_name.Text = "";
        }

        HtmlTableRow dp_unit = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_unit");
        //--合庫,玉山銀行
        if ((tdpf_bank == "011" || tdpf_bank == "020"))
        {
            dp_unit.Visible = true;
        }
        else
        {
            dp_unit.Visible = false;
        }

        HtmlTableRow dp_branch = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_branch");
        //--台銀,寶華銀行,土地銀行,華南銀行,兆豐,農民
        if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "016" || tdpf_bank == "003" || tdpf_bank == "023")
        {
            dp_branch.Visible = true;
        }
        else
        {
            dp_branch.Visible = false;
        }

        HtmlTableRow dp_custom = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_custom");
        //--台銀,寶華銀行,土地銀行,國泰,大台北商業銀行,富邦銀行
        if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "022" || tdpf_bank == "017" || tdpf_bank == "002")
        {
            dp_custom.Visible = true;
        }
        else
        {
            dp_custom.Visible = false;
        }
        Label dp_custom_name = (Label)GridView_tdpf.Rows[index].Cells[1].FindControl("Label_tdpf_custom");
        //-- 台銀,寶華銀行,土地銀行,國泰
        if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "022")
        {
            dp_custom_name.Text = "客戶代號";
        }
        else if (tdpf_bank == "017") // 大台北商業銀行
        {
            dp_custom_name.Text = "受託單位";
        }
        else if (tdpf_bank == "002")// 富邦銀行
        {
            dp_custom_name.Text = "委託單位代碼";
        }
        else
        {
            dp_custom_name.Text = "";
        }

        HtmlTableRow dp_param = (HtmlTableRow)GridView_tdpf.Rows[index].Cells[1].FindControl("tr_param");
        //權數  
        if (tdpf_bank == "022")//國泰世華
        {
            dp_param.Visible = true;
        }
        else
        {
            dp_param.Visible = false;
        }    
        
    }

    protected void GetData() //銀行資料
    {
        UNIT_DEPTextBox.Text = UNIT_NOLabel1.Text = UNIT_TAXTextBox.Text = UNIT_HNAMETextBox.Text = UNIT_CNAMETextBox.Text =
        UNIT_TELTextBox.Text = UNIT_MEDIATextBox.Text = UNIT_AREATextBox.Text = UNIT_ADDRTextBox.Text = TextBox_recompense_fund.Text =
        TextBox_multi_monthpay.Text = TextBox_labor_calm_rate.Text = TextBox_Unit_YM.Text = Label_unit_ym.Text= "";

        SAL4114 sal4114 = new SAL4114();
        DataTable data = sal4114.get_data(TextBox_orgid.Text);
        
        if (data != null && data.Rows.Count > 0)
        {
            UcSaCode_kind.Orgid = data.Rows[0]["UNIT_NO"].ToString();
            UcSaCode_kind.Code_no = data.Rows[0]["UNIT_KIND"].ToString();  
            UNIT_DEPTextBox.Text = data.Rows[0]["UNIT_DEP"].ToString();
            UNIT_NOLabel1.Text = data.Rows[0]["UNIT_NO"].ToString();
            UNIT_TAXTextBox.Text = data.Rows[0]["UNIT_TAX"].ToString();
            UNIT_HNAMETextBox.Text = data.Rows[0]["UNIT_HNAME"].ToString();
            UNIT_CNAMETextBox.Text = data.Rows[0]["UNIT_CNAME"].ToString();
            UNIT_TELTextBox.Text = data.Rows[0]["UNIT_TEL"].ToString();
            UNIT_MEDIATextBox.Text = data.Rows[0]["UNIT_MEDIA"].ToString();
            UNIT_AREATextBox.Text = data.Rows[0]["UNIT_AREA"].ToString();
            UNIT_ADDRTextBox.Text = data.Rows[0]["UNIT_ADDR"].ToString();
            if (data.Rows[0]["UNIT_RECOMPENSE_FUND"].ToString().ToLower() == "y")
            {
                CheckBox_recompense_fund.Checked = true;
            }
            else
            {
                CheckBox_recompense_fund.Checked = false;
            }
            TextBox_recompense_fund.Text = data.Rows[0]["UNIT_RECOMPENSE_FUND"].ToString();
            if (data.Rows[0]["UNIT_MULTI_MONTHPAY"].ToString().ToLower() == "y")
            {
                CheckBox_multi_monthpay.Checked = true;
            }
            else
            {
                CheckBox_multi_monthpay.Checked = false;
            }
            TextBox_multi_monthpay.Text = data.Rows[0]["UNIT_MULTI_MONTHPAY"].ToString();
            TextBox_labor_calm_rate.Text = data.Rows[0]["UNIT_LABOR_CALM_RATE"].ToString();
            Label_unit_ym.Text = SALARY.Logic.app.Date_str(data.Rows[0]["UNIT_YM"].ToString());
            TextBox_Unit_YM.Text = data.Rows[0]["UNIT_YM"].ToString();
            UcDateTextBox_ym.DateStr = data.Rows[0]["UNIT_YM"].ToString();

            view.Visible = true;
        }
        else
        {
     /*       Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
            view.Visible = false;*/
        }

        DataTable GridViewdata = sal4114.get_GridViewdata(TextBox_orgid.Text);
        if (GridViewdata != null && GridViewdata.Rows.Count > 0)
        {
            GridViewdata.Columns.Add("dp_medi");
            GridViewdata.Columns.Add("dp_no");
            GridViewdata.Columns.Add("dp_title");
            GridViewdata.Columns.Add("dp_entno");
            GridViewdata.Columns.Add("dp_entno_name");
            GridViewdata.Columns.Add("dp_unit");
            GridViewdata.Columns.Add("dp_branch");
            GridViewdata.Columns.Add("dp_custom");
            GridViewdata.Columns.Add("dp_custom_name");
            GridViewdata.Columns.Add("dp_param");
            GridViewdata.Columns.Add("de1");
            GridViewdata.Columns.Add("de2");

            for( int i=0 ; i < GridViewdata.Rows.Count ; i++)
            {
                string tdpf_bank = GridViewdata.Rows[i]["TDPF_BANK"].ToString();

                if (tdpf_bank == "004")//郵局
                {             
                    GridViewdata.Rows[i]["dp_medi"] ="true" ;
                    GridViewdata.Rows[i]["dp_title"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_medi"] ="false" ;
                    GridViewdata.Rows[i]["dp_title"] = "false";
                }

                //--台銀,寶華銀行,土地銀行,華南銀行,兆豐,玉山,彰化
                if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "016" || tdpf_bank == "003" || tdpf_bank == "020" || tdpf_bank == "006")
                { 
                   
                    GridViewdata.Rows[i]["dp_no"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_no"] = "false";
                }

                 //--彰銀,台北商銀,台北一信,台新銀行,永豐銀行,安泰銀行
                if (tdpf_bank == "006" || tdpf_bank == "009" || tdpf_bank == "017" || tdpf_bank == "025" || tdpf_bank == "027" || tdpf_bank == "021")
                {
                    GridViewdata.Rows[i]["dp_entno"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_entno"] = "false";
                }

                //企業編號、轉帳組別(tdpf_entno)，中文說明
                if (tdpf_bank == "006" || tdpf_bank == "009" || tdpf_bank == "017" || tdpf_bank == "025")
                {
                    //-- 彰銀,台北商銀,台北一信,台新銀行
                    GridViewdata.Rows[i]["dp_entno_name"] = "企業編號";
                }
                else if (tdpf_bank == "021")
                {
                    //-- 安泰銀行
                      GridViewdata.Rows[i]["dp_entno_name"]  = "轉帳組別";
                }
                else if (tdpf_bank == "027")
                {
                    //-- 永豐銀行
                      GridViewdata.Rows[i]["dp_entno_name"]  = "代理編號";
                }
                else
                {
                      GridViewdata.Rows[i]["dp_entno_name"]  = "";
                }

                 //--合庫,玉山銀行
                if ((tdpf_bank == "011" || tdpf_bank == "020"))
                {
                    GridViewdata.Rows[i]["dp_unit"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_unit"] = "false";
                }

                //--台銀,寶華銀行,土地銀行,華南銀行,兆豐,農民
                if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "016" || tdpf_bank == "003" || tdpf_bank == "023")
                {                    
                    GridViewdata.Rows[i]["dp_branch"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_branch"] = "false";
                }

                //--台銀,寶華銀行,土地銀行,國泰,大台北商業銀行,富邦銀行
                if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "022" || tdpf_bank == "017" || tdpf_bank == "002")
                {
                    GridViewdata.Rows[i]["dp_custom"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_custom"] = "false";
                }

                 //-- 台銀,寶華銀行,土地銀行,國泰
                if (tdpf_bank == "008" || tdpf_bank == "024" || tdpf_bank == "013" || tdpf_bank == "022")
                {                  
                    GridViewdata.Rows[i]["dp_custom_name"] = "客戶代號";
                }
                else if (tdpf_bank == "017") // 大台北商業銀行
                {                   
                    GridViewdata.Rows[i]["dp_custom_name"] = "受託單位";
                }
                else if (tdpf_bank == "002")// 富邦銀行
                {
                    GridViewdata.Rows[i]["dp_custom_name"] = "委託單位代碼";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_custom_name"] = "";
                }

                //權數  
                if (tdpf_bank == "022")//國泰世華
                {
                    GridViewdata.Rows[i]["dp_param"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["dp_param"] = "false";
                }

                DataTable deldata = sal4114.GetDataBySeqno(TextBox_orgid.Text, GridViewdata.Rows[i]["tdpf_seqno"].ToString());

                if (deldata != null && deldata.Rows.Count > 0)
                {
                    GridViewdata.Rows[i]["de1"] = "false";
                    GridViewdata.Rows[i]["de2"] = "true";
                }
                else
                {
                    GridViewdata.Rows[i]["de1"] = "true";
                    GridViewdata.Rows[i]["de2"] = "false";
                }
            }

            GridView_tdpf.DataSource = GridViewdata;
            GridView_tdpf.DataBind();
            GridView_tdpf.Visible = true;

          
        }
        else
        {
            GridView_tdpf.Visible = false;
        }
    }     

   
    protected void add_submit_Click(object sender, EventArgs e)
    {
    }    
  

    //修改
    protected void edit_submit_Click(object sender, EventArgs e)
    {
        string date = SALARY.Logic.pub.Nowdatetime();

        string UNIT_DEP = UNIT_DEPTextBox.Text;
        string UNIT_NO = UNIT_NOLabel1.Text;
        string UNIT_KIND = UcSaCode_kind.Code_no;
        string UNIT_TAX = UNIT_TAXTextBox.Text;
        string UNIT_HNAME = UNIT_HNAMETextBox.Text;
        string UNIT_CNAME = UNIT_CNAMETextBox.Text;
        string UNIT_TEL = UNIT_TELTextBox.Text;
        string UNIT_MEDIA = UNIT_MEDIATextBox.Text;
        string UNIT_AREA = UNIT_AREATextBox.Text;
        string UNIT_ADDR = UNIT_ADDRTextBox.Text;
        string UNIT_RECOMPENSE_FUND = "N";
        if (CheckBox_recompense_fund.Checked)
            UNIT_RECOMPENSE_FUND = "Y";

        string UNIT_MULTI_MONTHPAY = "N";
        if (CheckBox_multi_monthpay.Checked)
            UNIT_MULTI_MONTHPAY = "Y";

        string UNIT_LABOR_CALM_RATE = TextBox_labor_calm_rate.Text;
        string UNIT_USERID = TextBox_mid.Text;
        string UNIT_MDATE = date;

        SAL4114 sal4114 = new SAL4114();
        //unit
        sal4114.queryeditData_unit(UNIT_DEP, UNIT_NO, UNIT_KIND, UNIT_TAX, UNIT_HNAME, UNIT_CNAME, UNIT_TEL, UNIT_MEDIA, UNIT_AREA,
            UNIT_ADDR, UNIT_RECOMPENSE_FUND, UNIT_MULTI_MONTHPAY, UNIT_LABOR_CALM_RATE, UNIT_USERID, UNIT_MDATE);

        //tdpf 逐筆修改
        for (int i = 0; i < GridView_tdpf.Rows.Count; i++)
        {
            string tdpf_orgid = GridView_tdpf.Rows[i].Cells[3].Text; //key
            string tdpf_bank_no = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_bank_no")).Text;

            if (tdpf_bank_no == "")
            {
                Page temp = this.Page;
                CommonFun.MsgShow(ref temp,
                   CommonFun.Msg.Custom, "請輸入帳號", "", "");
                this.Page = temp;
                return;
            }
            string tdpf_memo = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_memo")).Text;

            string tdpf_bank = ((uc_ucSaCode)GridView_tdpf.Rows[i].Cells[1].FindControl("UcSaCode_bank")).Code_no;
            string tdpf_medi = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_medi")).Text;
            string tdpf_muser = TextBox_mid.Text;
            string tdpf_mdate = date;
            string tdpf_seqno = GridView_tdpf.Rows[i].Cells[4].Text; //key
            string tdpf_title = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_title")).Text;
            string tdpf_entno = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_entno")).Text;
            string tdpf_unit = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_unit")).Text;
            string tdpf_branch = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_branch")).Text;
            string tdpf_custom = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_custom")).Text;
            string tdpf_no = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_no")).Text;
            string tdpf_param = ((TextBox)GridView_tdpf.Rows[i].Cells[1].FindControl("TextBox_tdpf_param")).Text;
            
            sal4114.queryeditData_tdpf(tdpf_orgid, tdpf_bank_no, tdpf_bank, tdpf_medi, tdpf_muser, tdpf_mdate, tdpf_seqno, tdpf_title,
                tdpf_entno, tdpf_unit, tdpf_branch, tdpf_custom, tdpf_no, tdpf_param, tdpf_memo);       
        }


        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = tempPage;

        GetData();

        for (int j = 0; j < GridView_tdpf.Rows.Count; j++)
        {
            uc_ucSaCode bank = (uc_ucSaCode)GridView_tdpf.Rows[j].Cells[1].FindControl("UcSaCode_bank");
            bank.Rebind();
        }
    }       

    //刪除
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index = int.Parse(txtFuncParam.Value.Trim());
        string org = GridView_tdpf.Rows[index].Cells[3].Text;
        string sqeno = GridView_tdpf.Rows[index].Cells[4].Text;
            
        SAL4114 sal4114 = new SAL4114();
        sal4114.delete(org, sqeno);

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "刪除完成", "", "");
        this.Page = tempPage;

        GetData();

        for (int j = 0; j < GridView_tdpf.Rows.Count; j++)
        {
            uc_ucSaCode bank = (uc_ucSaCode)GridView_tdpf.Rows[j].Cells[1].FindControl("UcSaCode_bank");
            bank.Rebind();
        }
    }  

    //新增
    protected void Button_newbank_Click(object sender, EventArgs e)
    {
        SAL4114 sal4114 = new SAL4114();
        string sdno = SALARY.Logic.pub.sdno();
        string Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");

        sal4114.insert(TextBox_orgid.Text, TextBox_mid.Text, sdno, Mdate);

        GetData();

        for (int j = 0; j < GridView_tdpf.Rows.Count; j++)
        {
            uc_ucSaCode bank = (uc_ucSaCode)GridView_tdpf.Rows[j].Cells[1].FindControl("UcSaCode_bank");
            bank.Rebind();
        }
      
    }

    //回復重寫
    protected void Button_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL4114_01.aspx");
    }

    protected void GridView_tdpf_DataBinding(object sender, EventArgs e)
    {
        GridView_tdpf.Columns[2].Visible = true;
        GridView_tdpf.Columns[3].Visible = true;
        GridView_tdpf.Columns[4].Visible = true;
    }
    protected void GridView_tdpf_DataBound(object sender, EventArgs e)
    {      
        GridView_tdpf.Columns[2].Visible = false;
        GridView_tdpf.Columns[3].Visible = false;
        GridView_tdpf.Columns[4].Visible = false;
    }
}