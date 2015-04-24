
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


public partial class SAL_SAL4_SAL4113 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_orgid.Text =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        TextBox_mid.Text = LoginManager.UserId;   //Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString

        UcSaCode_parameter_type.ReturnEvent = true;
        UcSaCode_parameter_type.CodeChanged +=new uc_ucSaCode.CodeChangedEventHandler(UcSaCode_parameter_type_CodeChanged);
      
        

        if (Page.IsPostBack) return;

        UcSaCode_parameter_type.Code_sys = "006";
        UcSaCode_parameter_type.Code_type = "**";
       
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetGridViewData();
    }


    void UcSaCode_parameter_type_CodeChanged(object sender, EventArgs e)
    {
        GetGridViewData();
    }



    protected void GetGridViewData()
    { 
        string Code_no = UcSaCode_parameter_type.Code_no;
        SAL4113 sal4113 = new SAL4113();
        DataTable data = sal4113.get_data(Code_no);
        if (data != null && data.Rows.Count > 0)
        {
            GridView1.DataSource = data;
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
            GridView1.DataSource = data;
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
        if (e.CommandName == "doupdate") //維護
        {
            EditDesc.Text = "";
            int index = Convert.ToInt32(e.CommandArgument);
            editPanel.Visible = true;
            title.Visible = false;
            GridView1.Visible = false;
            UcPager.Visible = false;
            view.Visible = false;

            Editsys.Text = GridView1.Rows[index].Cells[3].Text;
            Editkind.Text = GridView1.Rows[index].Cells[4].Text;
            Edittype.Text = GridView1.Rows[index].Cells[5].Text;
            Editno.Text = GridView1.Rows[index].Cells[6].Text;
            DropDownList ddlym =(DropDownList)GridView1.Rows[index].Cells[1].FindControl("ucSaParameter_1").FindControl("DropDownList_ym");
            EditYM.Text ="民國"+ SALARY.Logic.app.Date_str(ddlym.SelectedValue)+"實施";
            EditDesc.Text = SALARY.Logic.app.GetSaCode_Desc1(Editsys.Text, Editkind.Text, Edittype.Text, Editno.Text);
            ym.Text = ddlym.SelectedValue; 

            Label lv = (Label)GridView1.Rows[index].Cells[1].FindControl("ucSaParameter_1").FindControl("Label_value");
            EditValue.Text = lv.Text;
        }
        else if (e.CommandName == "doadd") //新增
        {
            Label_Desc1.Text = "";
          int index = Convert.ToInt32(e.CommandArgument);
          addPanel.Visible = true;
          GridView1.Visible = false;
          UcPager.Visible = false;
          view.Visible = false;
          editPanel.Visible = false;
          title.Visible = false;

             v_sys.Text = GridView1.Rows[index].Cells[3].Text;
             v_kind.Text = GridView1.Rows[index].Cells[4].Text;
             v_type.Text = GridView1.Rows[index].Cells[5].Text;
             v_no.Text =  GridView1.Rows[index].Cells[6].Text;
            Label_Desc1.Text = SALARY.Logic.app.GetSaCode_Desc1(v_sys.Text, v_type.Text, v_no.Text);
            ucDateTextBox.DateStr = DateTime.Now.ToString("yyyyMM");
        }
    }


    //新增取消
    protected void add_cancel_Click(object sender, EventArgs e)
    {
        resetNewPandel();
        addPanel.Visible = false;
        GridView1.Visible = true;
        UcPager.Visible = true;
        view.Visible = true;
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
            msg += "日期";
        }        
   /*     if (PARAMETER_VALUETextBox.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "參數值";
        }          */
        if(msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:"+msg, "", "");
            this.Page = tempPage;
            return;
        }

        string ym = ucDateTextBox.DateStr;
        string sys = v_sys.Text;
        string kind = v_kind.Text;
        string type = v_type.Text;
        string no = v_no.Text;
        string VALUE = PARAMETER_VALUETextBox.Text;
        string Muser = TextBox_mid.Text;
        string Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
        
        SAL4113 sal4113 = new SAL4113();
        sal4113.queryaddData(ym, sys, kind, type, no,VALUE, Muser, Mdate);

        Page temp = this.Page;
        CommonFun.MsgShow(ref temp, CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = temp;

        addPanel.Visible = false;
        title.Visible = true;
        resetNewPandel();
        GetGridViewData();
    }

    // 清空輸入項目
    private void resetNewPandel()
    {
        PARAMETER_VALUETextBox.Text = "";
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
 /*     可NULL
        string msg = "";
        if (EditValue.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "參數值";
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
            this.Page = tempPage;
            return;
        }  
  */    
        string ymv = ym.Text;
        string sys = Editsys.Text;
        string kind = Editkind.Text;
        string type = Edittype.Text;
        string no = Editno.Text;
        string VALUE = EditValue.Text;
        string Muser = TextBox_mid.Text;
        string Mdate = DateTime.Now.ToString("yyyyMMddHHmmss");

        SAL4113 sal4113 = new SAL4113();
        sal4113.queryeditData(ymv, sys, kind, type, no, VALUE, Muser, Mdate);
        GetGridViewData();
     
        editPanel.Visible = false;
        title.Visible = true;  
    }
             

    //換頁
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GetGridViewData();
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
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        GridView1.Columns[3].Visible = false;
        GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
     
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
  
}