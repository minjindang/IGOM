
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


public partial class SAL_SAL4_SAL4109 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_orgid.Text =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
  //      TextBox_role.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId); //Me.LoginManager.UserData.v_ROLE_KIND.ToString
        TextBox_mid.Text = LoginManager.UserId;   //Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString

        cmbTypes.ReturnEvent = true;
        cmbTypes.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(TypeChange);
 
        if (Page.IsPostBack) return;

        //主管加給對照表維護(004)
        TextBox_type.Text = "004";
        cmbTypes.Code_sys = "001";
        cmbTypes.Code_type = TextBox_type.Text;
        get_ym_sql(TextBox_type.Text, "001");
 //       Button_add.Visible = Convert.ToBoolean(SALARY.Logic.app.show_edit(TextBox_role.Text));
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;     
    }

    void TypeChange(object sender, EventArgs e)
    {
        view.Visible = false;
        get_ym_sql(TextBox_type.Text, cmbTypes.Code_no);   
    }

    private void get_ym_sql(string type ,string no)  //ddl year
    {
        SAL4109 sal4109 = new SAL4109();
        DataTable addYear = sal4109.queryYearData(type,no);
        DropDownList_Year.Items.Clear();
        if (addYear != null && addYear.Rows.Count > 0)
        {
            for (int i = 0; i < addYear.Rows.Count; i++)
            {
                string ddltext = addYear.Rows[i]["ymstr"].ToString();
                string ddlva = addYear.Rows[i]["spesup_ym"].ToString();
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
        get_sastan_sql(DropDownList_Year.SelectedValue, TextBox_type.Text, cmbTypes.Code_no);
    }

    private void get_sastan_sql(string ym, string type, string no) //查詢
    {
        addPanel.Visible = false;
        editPanel.Visible = false;
        SAL4109 sal4109 = new SAL4109();
        DataTable Searchdata = sal4109.get_sastan_sql(ym, type, no);

        if (Searchdata != null && Searchdata.Rows.Count > 0)
        {
            for (int i = 0; i < Searchdata.Rows.Count; i++)
            {
                double a = Convert.ToDouble(Searchdata.Rows[i]["Spesup_Sal"]);
                Searchdata.Rows[i]["Spesup_Sal"] = ((int)a).ToString();
            }
            GridView1.DataSource = Searchdata;
            GridView1.DataBind();
            GridView1.Visible = true;
            UcPager.Visible = true;
            view.Visible = true;
        }
        else
        {
            /*  Page tempPage = this.Page;
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

            EditKind.Text = SALARY.Logic.app.GetSaCode_Desc1("001", TextBox_type.Text, cmbTypes.Code_no); // 種類
            EditYM.Text ="民國"+ SALARY.Logic.app.Date_str(DropDownList_Year.SelectedValue)+"實施"; //日期
            Label ser = (Label)GridView1.Rows[index].Cells[0].FindControl("Label_series");
            EditSer.Text = ser.Text.Replace("&nbsp;", ""); //級數
            Label sal = (Label)GridView1.Rows[index].Cells[1].FindControl("Label_sal");
            EditSal.Text = sal.Text.Replace("&nbsp;", ""); //金額       
        }
    }

    //新增按鈕
    protected void Button_add_Click(object sender, EventArgs e)
    {
        Label_kind.Text = SALARY.Logic.app.GetSaCode_Desc1("001", TextBox_type.Text, cmbTypes.Code_no);
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
        if (TextBox_Series.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "加給級數";
        }
        if (TextBox_SAL.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "加給金額";
        }          
        if(msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:"+msg, "", "");
            this.Page = tempPage;
            return;
        }    

     /*   msg = "";
        int x = 0;
        if (!int.TryParse(ucDateTextBox.DateStr, out x))
        {
            if (msg != "")
                msg += ",";
          msg += "實施日期";
        }
        if (!int.TryParse(TextBox_Series.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "加給級數";
        }
        if (!int.TryParse(TextBox_SAL.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "加給金額";
        }  
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "以下欄位請輸入數值:"+msg, "", "");
            this.Page = tempPage;
            return;
        }
      * */
              
        string ym = ucDateTextBox.DateStr;   
        string Series = TextBox_Series.Text.PadLeft(2, '0');       
        string SAL = TextBox_SAL.Text;
        string type = TextBox_type.Text;
        string no = cmbTypes.Code_no;
        string Muser = TextBox_mid.Text;
        string Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
        
        SAL4109 sal4109 = new SAL4109();

      DataTable chdt= sal4109.checkData(ym, Series, SAL, type, no);
      if (chdt.Rows.Count > 0)
      {
          Page temp = this.Page;
          CommonFun.MsgShow(ref temp, CommonFun.Msg.Custom, "已有相同資料", "", "");
          this.Page = temp;
          return;
      }

        sal4109.queryaddData( ym, Series, SAL, type, no, Muser, Mdate);

        Page te = this.Page;
        CommonFun.MsgShow(ref te, CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = te;

        addPanel.Visible = false;
        title.Visible = true;
        resetNewPandel();
        get_ym_sql(TextBox_type.Text, cmbTypes.Code_no);   
    }

    // 清空輸入項目
    private void resetNewPandel()
    {
        TextBox_Series.Text = "";
        TextBox_SAL.Text = "";
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
        if (EditSal.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "加給金額";
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
        if (!int.TryParse(EditSal.Text, out x))
        {
            if (msg != "")
                msg += ",";
            msg += "加給金額";
        } 
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "以下欄位請輸入數值:" + msg, "", "");
            this.Page = tempPage;
            return;
        }  

        SAL4109 sal4109 = new SAL4109();
        string Muser = TextBox_mid.Text;
        string Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
        string ym = DropDownList_Year.SelectedValue;
        string Series = EditSer.Text;
        string SAL = EditSal.Text;
        string type = TextBox_type.Text;
        string no = cmbTypes.Code_no;
        
        sal4109.queryeditData(ym, Series, SAL, type, no, Muser, Mdate);

        get_sastan_sql(DropDownList_Year.SelectedValue, TextBox_type.Text, cmbTypes.Code_no);
        editPanel.Visible = false;
        title.Visible = true;
    }
     
    //刪除
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index =int.Parse(txtFuncParam.Value.Trim());
        SAL4109 sal4109 = new SAL4109();
        Label ser = (Label)GridView1.Rows[index].Cells[0].FindControl("Label_series");
        string v_series = ser.Text;
      
        // 刪除資料
        sal4109.querydeleteData(DropDownList_Year.SelectedValue, TextBox_type.Text, cmbTypes.Code_no, v_series);
        get_sastan_sql(DropDownList_Year.SelectedValue, TextBox_type.Text, cmbTypes.Code_no);
    }

    protected void DropDownList_Year_SelectedIndexChanged(object sender, EventArgs e)
    {      
        view.Visible = false;
    }

    //換頁
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        get_sastan_sql(DropDownList_Year.SelectedValue, TextBox_type.Text, cmbTypes.Code_no);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {       
        GridView1.PageIndex = e.NewPageIndex;         
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) //加給種類
    {
        view.Visible = false;

        if (DropDownList1.SelectedValue == "0")
        {
            //主管加給對照表維護(004)
            TextBox_type.Text = "004";
            cmbTypes.Code_type = TextBox_type.Text;
            cmbTypes.Rebind();
            get_ym_sql(TextBox_type.Text, cmbTypes.Code_no);
        }
        else if (DropDownList1.SelectedValue == "1")
        {         
            // 專業加給對照表維護(003)
            TextBox_type.Text = "003";
            cmbTypes.Code_type = TextBox_type.Text;
            cmbTypes.Rebind();
            get_ym_sql(TextBox_type.Text, cmbTypes.Code_no);
        }
        else if (DropDownList1.SelectedValue == "2")
        { 
            //其他加給對照表維護(006)
            TextBox_type.Text = "006";
            cmbTypes.Code_type = TextBox_type.Text;
            cmbTypes.Rebind();
            get_ym_sql(TextBox_type.Text, cmbTypes.Code_no);
        }
    }
}