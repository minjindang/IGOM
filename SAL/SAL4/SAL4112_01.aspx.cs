
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


public partial class SAL_SAL4_SAL4112 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_orgid.Text =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        TextBox_mid.Text = LoginManager.UserId;   //Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString
              
        if (Page.IsPostBack) return;
        get_ym_sql();
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;     
    }
      

    private void get_ym_sql() //add tear
    {
        SAL4112 sal4112 = new SAL4112();
        DataTable addYear = sal4112.queryYearData();
        DropDownList_Year.Items.Clear();

        if (addYear != null && addYear.Rows.Count > 0)
        {
            for (int i = 0; i < addYear.Rows.Count; i++)
            {
                string ddltext = addYear.Rows[i]["ymstr"].ToString();
                string ddlva = addYear.Rows[i]["tax_ym"].ToString();
                ListItem item = new ListItem();
                item.Value = ddlva;
                item.Text = ddltext;
                DropDownList_Year.Items.Add(item);
            }  
        }
    }
          
    //查詢按鈕
    protected void Button_Search_Click(object sender, EventArgs e)
    {
        get_SaTax_sql(DropDownList_Year.SelectedValue);
    }

    private void get_SaTax_sql(string ym) //查詢
    {
        addPanel.Visible = false;
        editPanel.Visible = false;
        SAL4112 sal4112 = new SAL4112();
        DataTable Searchdata = sal4112.get_SaTax_sql(ym);

        if (Searchdata != null && Searchdata.Rows.Count > 0)
        {
            GridView1.DataSource = Searchdata;
            GridView1.DataBind();
            GridView1.Visible = true;     
            UcPager.Visible = true;
            view.Visible = true;
        }
        else
        {
   /*         Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
    */
            GridView1.DataSource = Searchdata;
            GridView1.DataBind();
            GridView1.Visible = true;          
            view.Visible = true;
            if (GridView1.Rows.Count > 0)
            {
                UcPager.Visible = true;
            }
            else
            {
                UcPager.Visible = false;
            }
            get_ym_sql();
        }
    }

  
    //維護欄位按鈕
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //維護button
        {
            int index = Convert.ToInt32(e.CommandArgument);         
            editPanel.Visible = true;
            title.Visible = false;
            GridView1.Visible = false;
            UcPager.Visible = false;
            view.Visible = false;

            EditYM.Text = "啟用年月：民國" + SALARY.Logic.app.Date_str(DropDownList_Year.SelectedValue); //日期
            Label v_strs = (Label)GridView1.Rows[index].Cells[0].FindControl("Label_lev");
            string[] str = v_strs.Text.Split('~');
            Editlow.Text= str[0];
            Editup.Text = str[1];
            Edit_p0.Text = GridView1.Rows[index].Cells[3].Text;
            Edit_p1.Text = GridView1.Rows[index].Cells[4].Text;
            Edit_p2.Text = GridView1.Rows[index].Cells[5].Text;
            Edit_p3.Text = GridView1.Rows[index].Cells[6].Text;
            Edit_p4.Text = GridView1.Rows[index].Cells[7].Text;
            Edit_p5.Text = GridView1.Rows[index].Cells[8].Text;
            Edit_p6.Text = GridView1.Rows[index].Cells[9].Text;
            Edit_p7.Text = GridView1.Rows[index].Cells[10].Text;
            Edit_p8.Text = GridView1.Rows[index].Cells[11].Text;
            Edit_p9.Text = GridView1.Rows[index].Cells[12].Text;
            Edit_p10.Text = GridView1.Rows[index].Cells[13].Text;
            Edit_p11.Text = GridView1.Rows[index].Cells[14].Text;
        }
    }

    //新增按鈕
    protected void Button_add_Click(object sender, EventArgs e)
    {
        ucDateTextBox.DateStr = DropDownList_Year.SelectedValue;
        addPanel.Visible = true;
        GridView1.Visible = false;
        UcPager.Visible = false;
        view.Visible = false;
        editPanel.Visible = false;
        title.Visible = false;
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
        if (ucDateTextBox.DateStr == "")
        {
            if (msg != "")
                msg += ",";
            msg += "實施日期";
        }
        if (TextBox_low.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得下限";
        }
        if (TextBox_up.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "月薪資所得上限";
        }
        if (tax_p0TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "0人(扶養人數)應扣稅額";
        }
        if (tax_p1TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "1人(扶養人數)應扣稅額";
        }
        if (tax_p2TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "2人(扶養人數)應扣稅額";
        }
        if (tax_p3TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "3人(扶養人數)應扣稅額";
        }
        if (tax_p4TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "4人(扶養人數)應扣稅額";
        }
        if (tax_p5TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "5人(扶養人數)應扣稅額";
        }
        if (tax_p6TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "6人(扶養人數)應扣稅額";
        }
        if (tax_p7TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "7人(扶養人數)應扣稅額";
        }
        if (tax_p8TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "8人(扶養人數)應扣稅額";
        }
        if (tax_p9TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "9人(扶養人數)應扣稅額";
        }
        if (tax_p10TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "10人(扶養人數)應扣稅額";

        }
        if (tax_p11TextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "11人(扶養人數)應扣稅額";

        }   

        if(msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:"+msg, "", "");
            this.Page = tempPage;
            return;
        }    

 
              
        string ym = ucDateTextBox.DateStr;
        string low = TextBox_low.Text;
        string up = TextBox_up.Text;
        string tax_p0 = tax_p0TextBox.Text;
        string tax_p1 = tax_p1TextBox.Text;
        string tax_p2 = tax_p2TextBox.Text;
        string tax_p3 = tax_p3TextBox.Text;
        string tax_p4 = tax_p4TextBox.Text;
        string tax_p5 = tax_p5TextBox.Text;
        string tax_p6 = tax_p6TextBox.Text; 
        string tax_p7 = tax_p7TextBox.Text;
        string tax_p8 = tax_p8TextBox.Text;
        string tax_p9 = tax_p9TextBox.Text;
        string tax_p10 = tax_p10TextBox.Text;
        string tax_p11 = tax_p11TextBox.Text;
        
        SAL4112 sal4112 = new SAL4112();

        DataTable chdt = sal4112.checkdata(ym, low, up);
        if (chdt.Rows.Count > 0)
        {
            Page temp = this.Page;
            CommonFun.MsgShow(ref temp, CommonFun.Msg.Custom, "已有相同資料", "", "");
            this.Page = temp;
            return;
        }

        sal4112.queryaddData(ym, low, up, tax_p0, tax_p1, tax_p2, tax_p3, tax_p4, tax_p5, tax_p6, tax_p7, tax_p8, tax_p9,
            tax_p10,tax_p11 );

        Page mp = this.Page;
        CommonFun.MsgShow(ref mp, CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = mp;

        addPanel.Visible = false;
        title.Visible = true;
        resetNewPandel();
        get_ym_sql();        
    }

    // 清空輸入項目
    private void resetNewPandel()
    {
        TextBox_low.Text = TextBox_up.Text = tax_p0TextBox.Text = tax_p1TextBox.Text = tax_p2TextBox.Text = tax_p3TextBox.Text
            = tax_p4TextBox.Text = tax_p5TextBox.Text = tax_p6TextBox.Text = tax_p7TextBox.Text = tax_p8TextBox.Text = tax_p9TextBox.Text
            = tax_p10TextBox.Text = tax_p11TextBox.Text = "";
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
        if (Edit_p0.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "0人(扶養人數)應扣稅額";
        }
        if (Edit_p1.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "1人(扶養人數)應扣稅額";
        }
        if (Edit_p2.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "2人(扶養人數)應扣稅額";
        }
        if (Edit_p3.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "3人(扶養人數)應扣稅額";
        }
        if (Edit_p4.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "4人(扶養人數)應扣稅額";
        }
        if (Edit_p5.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "5人(扶養人數)應扣稅額";
        }
        if (Edit_p6.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "6人(扶養人數)應扣稅額";
        }
        if (Edit_p7.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "7人(扶養人數)應扣稅額";
        }
        if (Edit_p8.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "8人(扶養人數)應扣稅額";
        }
        if (Edit_p9.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "9人(扶養人數)應扣稅額";
        }
        if (Edit_p10.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "10人(扶養人數)應扣稅額";

        }
        if (Edit_p11.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "11人(扶養人數)應扣稅額";

        }   

        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
            this.Page = tempPage;
            return;
        }

        string ym = DropDownList_Year.SelectedValue;
        string low = Editlow.Text;
        string up = Editup.Text;
        string p0 = Edit_p0.Text;
        string p1 = Edit_p1.Text;
        string p2 = Edit_p2.Text;
        string p3 = Edit_p3.Text;
        string p4 = Edit_p4.Text;
        string p5 = Edit_p5.Text;
        string p6 = Edit_p6.Text;
        string p7 = Edit_p7.Text;
        string p8 = Edit_p8.Text;
        string p9 = Edit_p9.Text;
        string p10 = Edit_p10.Text;
        string p11 = Edit_p11.Text;

        SAL4112 sal4112 = new SAL4112();
        sal4112.queryeditData(ym, low, up, p0, p1, p2, p3,p4,p5,p6,p7,p8,p9,p10,p11);

/*        Page temp = this.Page;
        CommonFun.MsgShow(ref temp, CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = temp;
        */

        get_SaTax_sql(DropDownList_Year.SelectedValue);
        editPanel.Visible = false;
        title.Visible = true;
  
    }
     
    //刪除
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index =int.Parse(txtFuncParam.Value.Trim());
        SAL4112 sal4112 = new SAL4112();
        Label v_strs = (Label)GridView1.Rows[index].Cells[0].FindControl("Label_lev");

        string[] str = v_strs.Text.Split('~');
        string v_low = str[0];
        string v_up = str[1];
            
        // 刪除資料
        sal4112.querydeleteData(DropDownList_Year.SelectedValue, v_low, v_up );
        get_SaTax_sql(DropDownList_Year.SelectedValue);
    }

    protected void DropDownList_Year_SelectedIndexChanged(object sender, EventArgs e)
    {      
        view.Visible = false;
    }

    //換頁
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        get_SaTax_sql(DropDownList_Year.SelectedValue);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {       
        GridView1.PageIndex = e.NewPageIndex;         
    }


    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
        GridView1.Columns[3].Visible = true;
        GridView1.Columns[4].Visible = true;
        GridView1.Columns[5].Visible = true;
        GridView1.Columns[6].Visible = true;
        GridView1.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[9].Visible = true;
        GridView1.Columns[10].Visible = true;
        GridView1.Columns[11].Visible = true;
        GridView1.Columns[12].Visible = true;
        GridView1.Columns[13].Visible = true;
        GridView1.Columns[14].Visible = true;
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        GridView1.Columns[3].Visible = false;
        GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;
        GridView1.Columns[8].Visible = false;
        GridView1.Columns[9].Visible = false;
        GridView1.Columns[10].Visible = false;
        GridView1.Columns[11].Visible = false;
        GridView1.Columns[12].Visible = false;
        GridView1.Columns[13].Visible = false;
        GridView1.Columns[14].Visible = false;
    }
}