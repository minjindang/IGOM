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
using System.Text.RegularExpressions;
 
public partial class SAL_SAL3_SAL3106_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼

    
    protected void Page_Load(object sender, EventArgs e)
    {      
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        errorInfo.Visible = false;
        if (Page.IsPostBack) return;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {     
        string year = DateTime.Now.ToString("yyyy");
        ucDateDropDownList.Kind = "YM";
        ucDateDropDownList.year_e = (int.Parse(year) +1 ).ToString();
        ucDateDropDownList.year_s = (int.Parse(year) -2 ).ToString();
        if (Page.IsPostBack) return;
        ucDateDropDownList.DateStr = DateTime.Now.ToString("yyyyMM");
    }

    //重置
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3106_01.aspx");
    }

    //查詢
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        GetData();
    }//查詢
    protected void GetData() 
    {
        string strID = edtEmpID.Text; //員工編號
        string strname = edtEmpName.Text; //人員姓名  
        string strym = ucDateDropDownList.DateStr;//請選擇晉級前最後年月
        string stract = ddlstatus.SelectedValue;//在職狀態
        string strcno = ddlcno.SelectedValue; //員工類別    
        string RoleId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);   //LoginManager.UserData.v_ROLE_KIND   
        string strorg = cmb_uc_org.OrgCode; //單位                
       

        SAL3106 sal3106 = new SAL3106();
        DataTable data = sal3106.queryData(strOrgCode, strID, strname, strym, stract, strcno, RoleId, strorg);

        if (data != null )
        {
            data.Columns.Add("data_no");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["data_no"] = i + 1;
                data.Rows[i]["promo_start_payym"] = (Convert.ToInt32(data.Rows[i]["promo_start_payym"].ToString().Substring(0, 4)) - 1911) + "/"
                    + data.Rows[i]["promo_start_payym"].ToString().Substring(4, 2) + "/"
                    + data.Rows[i]["promo_start_payym"].ToString().Substring(6, 2) ;

                data.Rows[i]["promo_stop_payym"] = (Convert.ToInt32(data.Rows[i]["promo_stop_payym"].ToString().Substring(0, 4)) - 1911) + "/"
                 + data.Rows[i]["promo_stop_payym"].ToString().Substring(4, 2) + "/"
                 + data.Rows[i]["promo_stop_payym"].ToString().Substring(6, 2);
            }

            GridView1.DataSource = data;
            GridView1.DataBind();
            GridView1.Visible = true;
            search.Visible = true;
            if (GridView1.Rows.Count > 0)
            {
              
                UcPager.Visible = true;
                button.Visible = true; //gv button
            }
            else
            {
              
                UcPager.Visible = false;
                button.Visible = false; //gv button
            }
        }
        else
        {
            GridView1.Visible = false;
            search.Visible = false;        
    
            UcPager.Visible = false;
            button.Visible = false; //gv button

        }
    }

    //刪除資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index = int.Parse(txtFuncParam.Value.Trim());
        Label c_promo_seqno = (Label)GridView1.Rows[index].Cells[6].FindControl("c_promo_seqno");
        Label c_promo_ym = (Label)GridView1.Rows[index].Cells[5].FindControl("c_promo_ym");
   
        SAL3106 sal3106 = new SAL3106();
        sal3106.querydeleteData(c_promo_seqno.Text, c_promo_ym.Text, strOrgCode);

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = tempPage;
        GetData();
    }

    //多筆刪除
    protected void b_DeleteMulti_Click(object sender, EventArgs e)
    {
            int ck = 0;    

            for(int i = 0 ; i < GridView1.Rows.Count ;i++)
            {
                CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].Cells[1].FindControl("CheckBox1");
                string c_promo_seqno = ((Label)GridView1.Rows[i].Cells[6].FindControl("c_promo_seqno")).Text;
                string c_promo_ym = ((Label)GridView1.Rows[i].Cells[4].FindControl("c_promo_ym")).Text;

                    if (CheckBox1.Checked)
                    {
                        ck += 1;
                        SAL3106 sal3106 = new SAL3106();
                        sal3106.querydeleteData(c_promo_seqno, c_promo_ym, strOrgCode);                      
                    }  
            }
            if (ck == 0)
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請勾選要刪除的資料", "", "");
                this.Page = tempPage;
            }
            else
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "刪除成功", "", "");
                this.Page = tempPage;
                GetData();
            }
    }

    //新增
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string _errorInfo = ""; //message
        string strID = edtEmpID.Text; //員工編號
        string strname = edtEmpName.Text; //人員姓名  

        if (Regex.IsMatch(strID, @"[\W_]+") || Regex.IsMatch(strname, @"[\W_]+"))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "不可輸入特殊字元", "", "");
            this.Page = tempPage;
            return;
        }

        if (strID == "" && strname == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請輸入身分證字號或姓名", "", "");
            this.Page = tempPage;
        }
        else
        {       
            SAL3106 sal3106 = new SAL3106();
            DataTable data = sal3106.querycheckData(strOrgCode, strID, strname); //檢查是否員工
            if (data != null && data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string v_Promo_Ym = ucDateDropDownList.DateStr;//晉級前最後年月
                    string base_seqno = data.Rows[i]["base_seqno"].ToString();


                    DataTable data2 = sal3106.queryaddData(v_Promo_Ym, strOrgCode, base_seqno); //已有相同資料
                    if (data2 != null && data2.Rows.Count > 0)
                    {
                        Page tempPage = this.Page;
                        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "已有相同資料，無法新增!!", "", "");
                        this.Page = tempPage;
                        _errorInfo += data.Rows[i]["base_name"].ToString() + " ( " + data.Rows[i]["base_seqno"].ToString() + " ) 已存在 , 無法新增 ! <br>";

                    }
                    else   // 無相同資料,可以新增 
                    {
                        string v_Promo_Start_Payym = UcDate1.Text;// 補發開始日期
                        string v_Promo_Stop_Payym = UcDate2.Text; //補發結束日期
                        string v_Promo_muser = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);  //Me.LoginManager.UserData.v_ROLE_USERID
                        string v_Promo_Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string v_Promo_Effect_Date = "";
                        if (UcDate1.Text != "")
                        {
                             v_Promo_Effect_Date = UcDate1.Text.Substring(0, 5) + "01";
                        }
                        sal3106.queryInsertData(v_Promo_Ym, strOrgCode, base_seqno, v_Promo_Start_Payym,
                            v_Promo_Stop_Payym, v_Promo_muser, v_Promo_Mdate, v_Promo_Effect_Date);

                        Page tempPage = this.Page;
                        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "新增成功", "", "");
                        this.Page = tempPage;
                      
                        edtEmpID.Text = "";
                        edtEmpName.Text = "";
                        GetData();
                    }
                }
            }
            else
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "新增之員工編號錯誤或非該機關人員", "", "");
                this.Page = tempPage;            
            }
        }
        if (_errorInfo != "")
        {
            errorInfo.Text = _errorInfo;
            errorInfo.Visible = true;
        }
        else
        {
            errorInfo.Visible = false;
        }
    }

    //整批新增
    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        string v_nowdate = DateTime.Now.ToString("yyyyMM");
        string v_Promo_Start_Payym = UcDate1.Text;// 補發開始日期
        string v_proj_code = ddlcno.SelectedValue; //員工類別
        SAL3106 sal3106 = new SAL3106();
        DataTable data = sal3106.queryadd2Data(strOrgCode, v_nowdate, v_Promo_Start_Payym, v_proj_code);
        string message = "";
        if (data != null && data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string v_Promo_Ym = ucDateDropDownList.DateStr;//晉級前最後年月
                string base_seqno = data.Rows[i]["base_seqno"].ToString();

                DataTable data2 = sal3106.queryaddData(v_Promo_Ym, strOrgCode, base_seqno); //已有相同資料
                if (data2 != null && data2.Rows.Count > 0)
                {
                    message += data.Rows[i]["base_name"].ToString() + " ( " + data.Rows[i]["base_seqno"].ToString() + " ) 已存在 , 無法新增 ! <br>";
                }
                else
                {
                    string v_Base_Seqno = data.Rows[i]["Base_Seqno"].ToString();
                    string v_Promo_Stop_Payym = UcDate2.Text; //補發結束日期
                    string v_Promo_muser = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card); //Me.LoginManager.UserData.v_ROLE_USERID
                    string v_Promo_Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string v_Promo_Effect_Date = "";
                    if (UcDate1.Text != "")
                    {
                        v_Promo_Effect_Date = UcDate1.Text.Substring(0, 5) + "01";
                    }
                    sal3106.queryInsert2Data(v_Promo_Ym, strOrgCode, v_Base_Seqno, v_Promo_Start_Payym, v_Promo_Stop_Payym
                        , v_Promo_muser, v_Promo_Mdate, v_Promo_Effect_Date);

                    edtEmpID.Text = "";
                    edtEmpName.Text = "";
                }
               
            }
                GetData();
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "新增成功", "", "");
                this.Page = tempPage;
                if (message != "")
                {
                    errorInfo.Text = message;
                    errorInfo.Visible = true;
                }
                else
                {
                    errorInfo.Visible = false;
                }
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "新增條件不符合", "", "");
            this.Page = tempPage;    
        }     
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //維護button
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Label c_promo_seqno = (Label)GridView1.Rows[index].Cells[6].FindControl("c_promo_seqno");
            Label c_promo_ym = (Label)GridView1.Rows[index].Cells[5].FindControl("c_promo_ym");
            
            TextBox txtd1 = (TextBox)GridView1.Rows[index].Cells[7].FindControl("GridUcDate3").FindControl("tbDate");
            TextBox txtd2 = (TextBox)GridView1.Rows[index].Cells[8].FindControl("GridUcDate4").FindControl("tbDate");
                         
            SAL3106 sal3106 = new SAL3106();
            sal3106.queryupdateData(c_promo_seqno.Text, c_promo_ym.Text, strOrgCode, txtd1.Text.Replace("/",""), txtd2.Text.Replace("/",""));

            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "修改成功", "", "");
            this.Page = tempPage;
            GetData();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {      
        GridView1.PageIndex = e.NewPageIndex;  
        GetData();
    }


    protected void select_all_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].Cells[1].FindControl("CheckBox1");
            CheckBox1.Checked = true;
        }
    }
    protected void select_clean_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].Cells[1].FindControl("CheckBox1");
            CheckBox1.Checked = false;
        }
    }
}