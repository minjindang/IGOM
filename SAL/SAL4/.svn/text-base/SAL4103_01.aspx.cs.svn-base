
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

  
public partial class SAL_SAL4_SAL4103 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
        if (Page.IsPostBack) return;
        doQueryData(); //查詢資料
    }
  
    //查詢資料
    private void doQueryData()
    {
        addPanel.Visible = false;
        editPanel.Visible = false;

        SAL4103 sal4103 = new SAL4103();
        DataTable searchdata = sal4103.querySearchData();

        if (searchdata != null)
        {
            GridView1.Columns[11].Visible = true;
            GridView1.Columns[12].Visible = true;
            GridView1.Visible = true;
            GridView1.DataSource = searchdata;
            GridView1.DataBind();
            GridView1.Columns[11].Visible = false;
            GridView1.Columns[12].Visible = false;
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
        SAL4103 sal4103 = new SAL4103();
        DataTable seqdata = sal4103.queryseqData();
        if (seqdata != null)
        {
            lbseq.Text = seqdata.Rows[0]["seq"].ToString();
        }

        addtable.Text = addfleld.Text = addrule.Text = addREPLACE.Text
            = addSUBSTART.Text = addSUBEND.Text = addLENGTH.Text = "";

        addPanel.Visible = true;     
        editPanel.Visible = false;
        pnlNew.Visible = false;
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
        pnlNew.Visible = true;
    }
    //確定新增
    protected void add_submit_Click(object sender, EventArgs e)
    {      
          string msg = "";
          if (addtable.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "資料表名稱";
          }
          if (addfleld.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "欄位名稱";
          }
          if (addREPLACE.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "使用者自訂值/補值";
          }       
          if (addSUBSTART.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "字串起始位址";
          }
          if (addSUBEND.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "字串位數";
          }
          if (addLENGTH.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "長度";
          }
          if (addrule.Text == "")
          {
              if (msg != "")
                  msg += ",";
              msg += "欄位規則";
          }    
          if (msg != "")
          {
              Page tempPage = this.Page;
              CommonFun.MsgShow(ref tempPage,
                 CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
              this.Page = tempPage;
              return;
          }

      /*    if (Regex.IsMatch(addtable.Text, @"[\W_]+") ||
              Regex.IsMatch(addfleld.Text, @"[\W_]+") ||
              Regex.IsMatch(addREPLACE.Text, @"[\W_]+") ||
              Regex.IsMatch(addSUBSTART.Text, @"[\W_]+") ||
              Regex.IsMatch(addSUBEND.Text, @"[\W_]+") ||
              Regex.IsMatch(addLENGTH.Text, @"[\W_]+"))
          {
              Page tempPage = this.Page;
              CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "不可輸入特殊字元", "", "");
              this.Page = tempPage;
              return;
          }
        */

        string fmt_seqno = lbseq.Text;  //序號
        string fmt_code_no = "001"; //固定值
        string fmt_type = addtype.SelectedValue; //欄位種類
        string fmt_format = addtable.Text;//資料表名稱
        string fmt_setting = addfleld.Text;//欄位名稱
        string fmt_rule = addrule.Text;//欄位規則
        string fmt_align= addALIGN.SelectedValue; //起始位置
        string fmt_rep = addREPLACE.Text; //補值
        string fmt_start = addSUBSTART.Text; //字串起始位址
        string fmt_num = addSUBEND.Text; //字串位數
        string fmt_length = addLENGTH.Text; //長度  
        string fmt_muser = LoginManager.UserId; //登入者員工編號
      
        SAL4103 sal4103 = new SAL4103();
        sal4103.queryaddData(fmt_seqno, fmt_code_no, fmt_type, fmt_format, fmt_setting, fmt_rule,
            fmt_align, fmt_rep, fmt_length, fmt_start, fmt_num, fmt_muser);

        doQueryData();       
      
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
            GridView1.Visible = false;
            view.Visible = false;
            UcPager.Visible = false;
            pnlNew.Visible = false;
  
            edit_seq.Text = GridView1.Rows[index].Cells[0].Text.Replace("&nbsp;","");  //序號
            edit_TYPE.SelectedValue = GridView1.Rows[index].Cells[11].Text; //欄位種類
            edit_TABLE.Text = GridView1.Rows[index].Cells[3].Text.Replace("&nbsp;", ""); //資料表名稱
            edit_FIELD.Text = GridView1.Rows[index].Cells[4].Text.Replace("&nbsp;", ""); //欄位名稱
            edit_ALIGN.SelectedValue =GridView1.Rows[index].Cells[12].Text;    //起始位置
            edit_LENGTH.Text = GridView1.Rows[index].Cells[8].Text.Replace("&nbsp;", "");  //長度
            edit_REPLACE.Text = GridView1.Rows[index].Cells[5].Text.Replace("&nbsp;", ""); //補值
            edit_SUBSTART.Text = GridView1.Rows[index].Cells[6].Text.Replace("&nbsp;", "");  //字串起始位址
            edit_SUBEND.Text = GridView1.Rows[index].Cells[7].Text.Replace("&nbsp;", "");        //字串位數
            edit_rule.Text = GridView1.Rows[index].Cells[9].Text.Replace("&nbsp;", "");     //規則
        }
    }

    //取消關閉視窗
    protected void edit_cancel_Click(object sender, EventArgs e)
    {
        editPanel.Visible = false;
        GridView1.Visible = true;
        view.Visible = true;
        UcPager.Visible = true;
        pnlNew.Visible = true;
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
        if (edit_LENGTH.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "長度";
        }
        if (edit_rule.Text == "")
        {
            if (msg != "")
                msg += ",";
            msg += "欄位規則";
        }
        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下資料:" + msg, "", "");
            this.Page = tempPage;
            return;
        }

  /*      if (Regex.IsMatch(edit_TABLE.Text, @"[\W_]+") ||
           Regex.IsMatch(edit_FIELD.Text, @"[\W_]+") ||
           Regex.IsMatch(edit_REPLACE.Text, @"[\W_]+") ||
           Regex.IsMatch(edit_SUBSTART.Text, @"[\W_]+") ||
           Regex.IsMatch(edit_SUBEND.Text, @"[\W_]+") ||
           Regex.IsMatch(edit_LENGTH.Text, @"[\W_]+"))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "不可輸入特殊字元", "", "");
            this.Page = tempPage;
            return;
        }
        */

        string fmt_type = edit_TYPE.SelectedValue; //欄位種類
        string fmt_format = edit_TABLE.Text;//資料表名稱
        string fmt_setting = edit_FIELD.Text;//欄位名稱
        string fmt_rule = edit_rule.Text;//欄位規則
        string fmt_align = edit_ALIGN.SelectedValue; //起始位置
        string fmt_rep = edit_REPLACE.Text; //補值
        string fmt_start = edit_SUBSTART.Text; //字串起始位址
        string fmt_num = edit_SUBEND.Text; //字串位數
        string fmt_length = edit_LENGTH.Text; //長度  
        string fmt_muser = LoginManager.UserId; //登入者員工編號
        string fmt_seqno = edit_seq.Text;  //序號 
        SAL4103 sal4103 = new SAL4103();
        sal4103.queryeditData(fmt_type, fmt_format, fmt_setting, fmt_rule, fmt_align, fmt_rep,
            fmt_length, fmt_start, fmt_num, fmt_muser, fmt_seqno);
        doQueryData();       
   
    }
    //刪除
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        int index = int.Parse(txtFuncParam.Value.Trim());
        GridViewRow row = GridView1.Rows[index];
        SAL4103 sal4103 = new SAL4103();
        string fmt_seqno = GridView1.Rows[index].Cells[0].Text; //序號 
        // 刪除資料
        sal4103.querydeleteData(fmt_seqno);
        doQueryData();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        doQueryData(); //查詢資料
    }
}