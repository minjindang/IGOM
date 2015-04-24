
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



public partial class SAL_SAL4_SAL4102 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
       string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //code_orgid=使用者機關代碼
       ucSaCode.ReturnEvent = true;
       ucSaCode.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(ItemChanged);//畫面下拉變更時     
       if (Page.IsPostBack) return;
    }

    //畫面下拉查詢銀行代碼
    protected void ItemChanged(object sender, EventArgs e)
    {
        // 畫面選擇銀行代碼      
        string strcode_no = ucSaCode.Code_no;
        doQueryData(strcode_no);
    }

    //查詢資料
    private void doQueryData(string strcode_no)
    {
        addPanel.Visible = false;
        editPanel.Visible = false;

        SAL4102 sal4102 = new SAL4102();
        DataTable searchdata = sal4102.querySearchData(strcode_no);

        if (searchdata != null)
        {

            GridView1.Columns[7].Visible = true;
            GridView1.Columns[8].Visible = true;
            GridView1.Columns[9].Visible = true;
            GridView1.Columns[10].Visible = true;
            GridView1.Visible = true;
            GridView1.DataSource = searchdata;
            GridView1.DataBind();
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[10].Visible = false;
            view.Visible = true;
            UcPager.Visible = true;
        }
        else
        {
            GridView1.DataSource = searchdata;
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

         /*   Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
          */ 
        }
    }

    //新增按鈕
    protected void Button_add_Click(object sender, EventArgs e)
    {
        if (ucSaCode.SelectedItem.ToString() == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇銀行", "", "");
            this.Page = tempPage;
            return;
        }

        lbbankno.Text = ucSaCode.SelectedItem.ToString();     
        SAL4102 sal4102 = new SAL4102();
        DataTable numdata = sal4102.querynumData(ucSaCode.Code_no);
        if (numdata != null)
        {
            lbseq.Text = numdata.Rows[0]["seq"].ToString(); 
        }

        txtdatetable.Text = txtfleld.Text = txtLENGTH.Text = txtREPLACE.Text = txtSUBSTART.Text = txtSUBEND.Text = "";
        addPanel.Visible = true;     
        editPanel.Visible = false;
        pSearch.Visible = false;
        GridView1.Visible = false;
        view.Visible = false;
        UcPager.Visible = false;
    }

     
    //取消關閉新增
    protected void add_cancel_Click(object sender, EventArgs e)
    {
        addPanel.Visible = false;
        GridView1.Visible = true;
        view.Visible = true;
        UcPager.Visible = true;
        pSearch.Visible = true;
    }
    //確定新增
    protected void add_submit_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txtdatetable.Text == "" )
        {
            if (msg != "")
                msg += ",";
          msg += "資料表名稱";
        }
        if (txtfleld.Text == "")
        {
            if (msg != "")
                msg += ",";
          msg += "欄位名稱";
        }
        if(txtLENGTH.Text == "" )
        {
            if (msg != "")
                msg += ",";
        msg += "長度";
        }
        if(txtREPLACE.Text == "")
        {
            if (msg != "")
                msg += ",";
         msg += "使用者自訂值/補值";
        }
        if( txtSUBSTART.Text == "" )
        {
            if (msg != "")
                msg += ",";
        msg += "字串起始位址";
        }
        if(txtSUBEND.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "字串位數";   
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
            this.Page = tempPage;
            return;
        }

        string TRNFMT_SEQ = lbseq.Text; //欄位順序        
        string TRNFMT_BANK_CODENO = ucSaCode.Code_no; //銀行代碼
        string TRNFMT_SOURCE_TYPE = datatype.SelectedValue; //資料形式
        string TRNFMT_TABLE = txtdatetable.Text;//資料表名稱
        string TRNFMT_FIELD = txtfleld.Text;//欄位名稱
        string TRNFMT_ALIGN = ALIGN.SelectedValue; //起始位置
        string TRNFMT_LENGTH = txtLENGTH.Text; //長度
        string TRNFMT_REPLACE = txtREPLACE.Text; //補值
        string TRNFMT_SUBSTART = txtSUBSTART.Text; //字串起始位址
        string TRNFMT_SUBEND = txtSUBEND.Text; //字串位數
        string strmuser = LoginManager.UserId; //登入者員工編號

        SAL4102 sal4102 = new SAL4102();
        sal4102.queryaddData(TRNFMT_SEQ, TRNFMT_BANK_CODENO, TRNFMT_SOURCE_TYPE, TRNFMT_TABLE, TRNFMT_FIELD, TRNFMT_ALIGN
            , TRNFMT_LENGTH, TRNFMT_REPLACE, TRNFMT_SUBSTART, TRNFMT_SUBEND, strmuser);
        doQueryData(ucSaCode.Code_no);
        pSearch.Visible = true;
    }

    //維護欄位按鈕
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //維護button
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            addPanel.Visible = false;
            editPanel.Visible = true;
            pSearch.Visible = false;
            GridView1.Visible = false;
            view.Visible = false;
            UcPager.Visible = false;

            edit_bankno.Text = ucSaCode.SelectedItem.ToString().Replace("&nbsp;", "");
            edit_seq.Text = GridView1.Rows[index].Cells[0].Text.Replace("&nbsp;", "");
            edit_TYPE.SelectedValue = GridView1.Rows[index].Cells[7].Text;
            edit_TABLE.Text = GridView1.Rows[index].Cells[1].Text.Replace("&nbsp;", "");
            edit_FIELD.Text = GridView1.Rows[index].Cells[2].Text.Replace("&nbsp;", "");          
            edit_ALIGN.SelectedValue =GridView1.Rows[index].Cells[8].Text;
            edit_LENGTH.Text = GridView1.Rows[index].Cells[4].Text.Replace("&nbsp;", "");
            edit_REPLACE.Text = GridView1.Rows[index].Cells[5].Text.Replace("&nbsp;", "");
            edit_SUBSTART.Text = GridView1.Rows[index].Cells[9].Text.Replace("&nbsp;", "");
            edit_SUBEND.Text = GridView1.Rows[index].Cells[10].Text.Replace("&nbsp;", "");
        }
    }

    //取消關閉視窗
    protected void edit_cancel_Click(object sender, EventArgs e)
    {
        editPanel.Visible = false;
        GridView1.Visible = true;
        view.Visible = true;
        UcPager.Visible = true;    
        pSearch.Visible = true;
    }

    //修改儲存
    protected void edit_submit_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (edit_TABLE.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "資料表名稱";
        }
        if (edit_FIELD.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "欄位名稱";
        }
        if (edit_LENGTH.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "長度";
        }
        if (edit_REPLACE.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "使用者自訂值/補值";
        }
        if (edit_SUBSTART.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "字串起始位址";
        }
        if (edit_SUBEND.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "字串位數";
        }
        if( msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:"+msg, "", "");
            this.Page = tempPage;
            return;
        }


        string TRNFMT_SEQ = edit_seq.Text; //欄位順序        
        string TRNFMT_BANK_CODENO = ucSaCode.Code_no; //銀行代碼
        string TRNFMT_SOURCE_TYPE = edit_TYPE.SelectedValue; //資料形式
        string TRNFMT_TABLE = edit_TABLE.Text;//資料表名稱
        string TRNFMT_FIELD = edit_FIELD.Text;//欄位名稱
        string TRNFMT_ALIGN = edit_ALIGN.SelectedValue; //起始位置
        string TRNFMT_LENGTH = edit_LENGTH.Text; //長度
        string TRNFMT_REPLACE = edit_REPLACE.Text; //補值
        string TRNFMT_SUBSTART = edit_SUBSTART.Text; //字串起始位址
        string TRNFMT_SUBEND = edit_SUBEND.Text; //字串位數
        string strmuser = LoginManager.UserId; //登入者員工編號

        SAL4102 sal4102 = new SAL4102();
        sal4102.queryeditData(TRNFMT_SEQ, TRNFMT_BANK_CODENO, TRNFMT_SOURCE_TYPE, TRNFMT_TABLE, TRNFMT_FIELD, TRNFMT_ALIGN
            , TRNFMT_LENGTH, TRNFMT_REPLACE, TRNFMT_SUBSTART, TRNFMT_SUBEND, strmuser);
        doQueryData(ucSaCode.Code_no);
        pSearch.Visible = true;
    }

    //刪除
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index = int.Parse(txtFuncParam.Value.Trim());
        GridViewRow row = GridView1.Rows[index];
        SAL4102 sal4102 = new SAL4102();

        string TRNFMT_SEQ = GridView1.Rows[index].Cells[0].Text;//欄位順序 
        string TRNFMT_BANK_CODENO = ucSaCode.Code_no; //銀行代碼
        // 刪除資料
        sal4102.querydeleteData(TRNFMT_SEQ, TRNFMT_BANK_CODENO);
        doQueryData(ucSaCode.Code_no);           
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        // 畫面選擇銀行代碼      
        string strcode_no = ucSaCode.Code_no;
        doQueryData(strcode_no);
    }
}