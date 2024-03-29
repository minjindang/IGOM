﻿using System;
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
using System.Text;

public partial class SAL_SAL3_Trans_f101 : System.Web.UI.Page
{
    private string strOrgCode;  // 登入者機關代碼
    private string v_mid;

    protected void Page_Load(object sender, EventArgs e)
    {      

        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        v_mid = LoginManager.UserId;

        TextBox_tabid.Text = "" + Request["tabid"];
        TextBox_ym.Text = "" + Request["ym"];

        Label_tabname.Text = get_tabname(TextBox_tabid.Text);
        TextBox_btn.Text = "" + Request["btn"];

        get_OrgidStr();
        SQL_saupemp();
        if (Page.IsPostBack) return;   

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {     
      
    }

    protected string get_tabname(string tabid)
    {
        string rv = "";

        SAL3122 sal3122 = new SAL3122();
        DataTable data = sal3122.queryf101(tabid);


                 if (data!= null && data.Rows.Count > 0)
                {
                    rv = data.Rows[0]["uptcl_tabname"].ToString();
                }            
        
        return rv;
    }

    protected void get_OrgidStr()
    {
        this.TextBox_baseStr.Text = SALARY.Logic.app.trans_baseOrgidStr(strOrgCode);// app.trans_baseOrgidStr(strOrgCode);
        this.TextBox_payodStr.Text = SALARY.Logic.app.trans_payodOrgidStr(strOrgCode);// app.trans_payodOrgidStr(strOrgCode);
        this.TextBox_upempStr.Text = SALARY.Logic.app.trans_upempOrgidStr(strOrgCode);// app.trans_upempOrgidStr(strOrgCode);
    }

    protected void SQL_saupemp() //GridView_SaUpemp
    {

        SAL3122 sal3122 = new SAL3122();
        DataTable data = sal3122.queryf101saupemp(TextBox_ym.Text, TextBox_upempStr.Text, TextBox_tabid.Text);
        if (data != null && data.Rows.Count > 0)
        {
            GridView_SaUpemp.DataSource = data;
            GridView_SaUpemp.DataBind();
            div_gv_upemp.Visible = true;
        }
        else
        {
            div_gv_upemp.Visible = false;
            // 當月符合條件名單
            SQL_search();
        }
    }

    protected void SQL_search() //GridView_Search
    {
        SAL3122 sal3122 = new SAL3122();
        DataTable data=new DataTable();
        if (TextBox_tabid.Text == "A0001") //公務人員
        {
             data = sal3122.queryf101A0001(TextBox_ym.Text, TextBox_payodStr.Text);
        }
        else if (TextBox_tabid.Text == "A0002 ")  //雇員
        {
             data = sal3122.queryf101A0002(TextBox_ym.Text, TextBox_payodStr.Text);        
        }
        else if (TextBox_tabid.Text == "A0003 ")  //技工工友
        {
            data = sal3122.queryf101A0003(TextBox_ym.Text, TextBox_payodStr.Text);
        }
        else if (TextBox_tabid.Text == "A0004 ")  //聘用人員
        {
            data = sal3122.queryf101A0004(TextBox_ym.Text, TextBox_payodStr.Text);
        }
        else if (TextBox_tabid.Text == "A0005 ")  //約僱人員
        {
            data = sal3122.queryf101A0005(TextBox_ym.Text, TextBox_payodStr.Text);
        }
        else if (TextBox_tabid.Text == "A00011 ")  //教育警察
        {
            data = sal3122.queryf101A00011(TextBox_ym.Text, TextBox_payodStr.Text);
        }
        else if (TextBox_tabid.Text == "A00013 ")  //政務人員給與表
        {
            data = sal3122.queryf101A00013(TextBox_ym.Text, TextBox_payodStr.Text);
        }

        if (data != null && data.Rows.Count > 0)
        {
            GridView_Search.DataSource = data;
            GridView_Search.DataBind();
            div_gv_search.Visible = true;
        }
        else
        {
            div_gv_search.Visible = false;        
        }

    }
    //查 詢button
    protected void Button_search_Click(object sender, EventArgs e)
    {
        string vIDNo = SALARY.Logic.pub.SQLp(TextBox_src_idno.Text);// pub.SQLp(Me.TextBox_src_idno.Text);
        string vName = SALARY.Logic.pub.SQLp(TextBox_src_name.Text);// pub.SQLp(Me.TextBox_src_name.Text)
        TextBox_src_idno.Text = "";
        TextBox_src_name.Text = "";

        SAL3122 sal3122 = new SAL3122();
        DataTable data = sal3122.queryf101search(TextBox_baseStr.Text, vIDNo, vName);
        if (data != null && data.Rows.Count > 0)
        {
            GridView_Search.DataSource = data;
            GridView_Search.DataBind();
            div_gv_search.Visible = true;
        }
        else
        {
            div_gv_search.Visible = false;
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }
    }
    //加入清單button
    protected void Button_insert_Click(object sender, EventArgs e)
    {
        string t_seqno = "";
        string t_orgid = "";
        string t_amt = "NULL";
        string t_type = "NULL";
        string t_class = "NULL";
        string t_qty = "NULL";
        string t_kind = "NULL";
        string t_FType = "";
        string t_DType = "";

        if (check_data_search())
        {
            for (int i = 0; i < GridView_Search.Rows.Count; i++)
            { 
              CheckBox cb = (CheckBox)GridView_Search.Rows[i].Cells[1].FindControl("CheckBox_chk");
              if (cb.Checked)
              {
             TextBox seqno = (TextBox)GridView_Search.Rows[i].Cells[1].FindControl("TextBox_seqno");
             t_seqno = seqno.Text;
             TextBox orgid = (TextBox)GridView_Search.Rows[i].Cells[1].FindControl("TextBox_orgid");
             t_orgid = orgid.Text;
             DropDownList type = (DropDownList)GridView_Search.Rows[i].Cells[4].FindControl("DropDownList_Type");
             t_type = type.Text;
             TextBox amt = (TextBox)GridView_Search.Rows[i].Cells[5].FindControl("TextBox_amt");
             t_amt = amt.Text;

             SAL3122 sal3122 = new SAL3122();
             sal3122.queryf101insert(TextBox_ym.Text, t_orgid, TextBox_tabid.Text, t_seqno, t_amt, t_type, t_class, t_qty
                 , t_kind, t_FType, t_DType);
              }
            }

            div_gv_search.Visible = false;
            SQL_saupemp();

  /*         ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "reload_Click",
               "opener.$get('" + this.TextBox_btn.Text + "').click(); void(0);", true);
          */
        }

    }

    protected bool check_data_search()
    {
        bool rv = true;
        string ms = "";
        for (int i = 0; i < GridView_Search.Rows.Count; i++ )
        {
            CheckBox cb = (CheckBox)GridView_Search.Rows[i].Cells[1].FindControl("CheckBox_chk");
            if (cb.Checked)
            {
                TextBox t_amt = (TextBox)GridView_Search.Rows[i].Cells[5].FindControl("TextBox_amt");
                int x=0;
                if (t_amt.Text == "")
                {
                    t_amt.Text = "0";
                }
                else if(!int.TryParse(t_amt.Text,out x))
                { 
                    Label name = (Label)GridView_Search.Rows[i].Cells[3].FindControl("Label_name");
                    rv = false;
                    ms +=name.Text+"的支領數額應為數字!<br>";         
                }
            }
        }
        if (ms != "")
        {
            msg.Text = ms;
            msg.Visible = true;
        }
        else
        {
            msg.Visible = false;
        }
          return rv;
    }
    
    //全選
    protected void ImageButton_select_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_SaUpemp.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("CheckBox_chk");
            cb.Checked = true;
        }
    }
    //清除
    protected void ImageButton_clean_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_SaUpemp.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("CheckBox_chk");
            cb.Checked = false;
        }
    }

    //存檔
    protected void Button_update_Click(object sender, EventArgs e)
    {
        string t_seqno = "";
        string t_orgid = "";
        string t_amt = "NULL";
        string t_type = "NULL";
        string t_class = "NULL";
        string t_qty = "NULL";
        string t_kind = "NULL";
        string t_FType = "";
        string t_DType = "";

        if (check_data_upemp()) 
        {
            SAL3122 sal3122 = new SAL3122();
            sal3122.queryf101delete(TextBox_ym.Text, TextBox_upempStr.Text, TextBox_tabid.Text);
                        
            for (int i = 0; i < GridView_SaUpemp.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("CheckBox_chk");
                if (cb.Checked)
                {
                    TextBox seqno = (TextBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("TextBox_seqno");
                    t_seqno = seqno.Text;
                    TextBox orgid = (TextBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("TextBox_orgid");
                    t_orgid = orgid.Text;
                    DropDownList type = (DropDownList)GridView_SaUpemp.Rows[i].Cells[4].FindControl("DropDownList_Type");
                    t_type = type.Text;
                    TextBox amt = (TextBox)GridView_SaUpemp.Rows[i].Cells[5].FindControl("TextBox_amt");
                    t_amt = amt.Text;   
                 
                    sal3122.queryf101update(TextBox_ym.Text, t_orgid, TextBox_tabid.Text, t_seqno, t_amt, t_type, t_class, t_qty
                        , t_kind, t_FType, t_DType);
                }
            }
            SQL_saupemp();
   /*         ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "reload_Click", "opener.$get('"
                + this.TextBox_btn.Text + "').click(); void(0);", true);
    */
        }


    }

    protected bool check_data_upemp()
    {
        bool rv = true;
        string ms = "";
        for (int i = 0; i < GridView_SaUpemp.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView_SaUpemp.Rows[i].Cells[1].FindControl("CheckBox_chk");
            if (cb.Checked)
            {
                TextBox t_amt = (TextBox)GridView_SaUpemp.Rows[i].Cells[5].FindControl("TextBox_amt");
                int x = 0;
                if (t_amt.Text =="")
                {
                    t_amt.Text = "0";
                }
                else if (!int.TryParse(t_amt.Text, out x))
                {
                    rv = false;
                    Label name = (Label)GridView_SaUpemp.Rows[i].Cells[3].FindControl("Label_name");
                    ms +=name.Text + "的支領數額應為數字!<br>";          
                }
            }
        }
        if (ms != "")
        {
            msg.Text = ms;
            msg.Visible = true;
        }
        else
        {
            msg.Visible = false;
        }
        return rv;
    }

    //關閉
    protected void Button_close_Click(object sender, EventArgs e)
    {
        Response.Write("SAL3122_01.aspx");
    }
}