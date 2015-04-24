/*
 * 2014/3/24
 * ted
 * 加值匯出員工薪資資料
 */
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


public partial class SAL_SAL2_SAL2106 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        doQueryData(); //查詢銀行項目資料
    }

    //銀行項目至CheckBoxList
    private void doQueryData()
    {
      string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
      SAL2106 sal2106 = new SAL2106();
      DataTable searchdata = sal2106.querySearchData(strOrgCode);

      if (searchdata != null) //add CheckBoxList
        {
            if (searchdata.Rows.Count > 0)
            {
                for (int i = 0; i < searchdata.Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = searchdata.Rows[i]["bank_name"].ToString() + "<<" + searchdata.Rows[i]["tdpf_bank_no"].ToString() + ">>";
                    item.Value = searchdata.Rows[i]["tdpf_seqno"].ToString();
                    CheckBoxList21.Items.Add(item);                  
                }
            }
        }
    }

    // 匯出按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }

    // 匯出
    private void ExportReport()
    {

        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string strtype = ddltype.OrgCode;     //單位別
        string strname = txtname.Text;                          //員工姓名
        string strstatus = ddlstatus.SelectedValue.ToString();  //在職狀態
        string strcno = ucSaCode.SelectedValue;          //人員類別
        string strno = txtno.Text;  //員工編號
        string strbank="";  //選取的銀行項目
        //傳全部選取的銀行號碼
        for (int i = 0; i < CheckBoxList21.Items.Count; i++)
        { 
             if (CheckBoxList21.Items[i].Selected)
            {
                if (strbank != "") strbank += ",";
                strbank += CheckBoxList21.Items[i].Value;
            }
        }   

       SAL2106 sal2106 = new SAL2106();
        //全部欄位及資料
       DataTable datat = sal2106.queryReportData(strOrgCode, strtype, strname, strstatus, strcno, strno, strbank);
        //抓出選取的欄位
        DataTable newtable = Createtable();  

       if (datat != null && datat.Rows.Count > 0)
       {     
           string strExport = "";
           string strLine = "";
           for (int i = 0; i < newtable.Columns.Count; i++)
           {
               if (strLine != "") strLine += ",";
               strLine += "\"" + newtable.Columns[i].Caption + "\"";
           }

           strExport += strLine;

           for (int i = 0; i < datat.Rows.Count; i++)
           {
               strLine = "";
               for (int j = 0; j < newtable.Columns.Count; j++)
               {
                   if (strLine != "") strLine += ",";
                   strLine += "\"" + datat.Rows[i][newtable.Columns[j].Caption].ToString() + "\"";
               }
               strExport += Environment.NewLine + strLine;
           }

           Response.ContentType = "text/plain";
           Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("加值匯出員工薪資資料") + ".csv");
           Response.HeaderEncoding = System.Text.Encoding.GetEncoding("big5");
           Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");
           Response.Write(strExport);
           Response.End();

       }
       else
       {
           Page tempPage = this.Page;
           CommonFun.MsgShow(ref tempPage,
              CommonFun.Msg.Custom, "查無資料", "", "");
           this.Page = tempPage;
       }
    
    }
    //抓出匯出時要的欄位
    protected DataTable Createtable()
    {
        DataTable newtable = new DataTable() ;

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {          
                newtable.Columns.Add(CheckBoxList1.Items[i].ToString());      
        }         

          
           for (int i = 0; i < CheckBoxList2.Items.Count; i++)
           {
               if (CheckBoxList2.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList2.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList3.Items.Count; i++)
           {
               if (CheckBoxList3.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList3.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList4.Items.Count; i++)
           {
               if (CheckBoxList4.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList4.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList5.Items.Count; i++)
           {
               if (CheckBoxList5.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList5.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList6.Items.Count; i++)
           {
               if (CheckBoxList6.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList6.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList7.Items.Count; i++)
           {
               if (CheckBoxList7.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList7.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList8.Items.Count; i++)
           {
               if (CheckBoxList8.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList8.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList9.Items.Count; i++)
           {
               if (CheckBoxList9.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList9.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList10.Items.Count; i++)
           {
               if (CheckBoxList10.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList10.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList11.Items.Count; i++)
           {
               if (CheckBoxList11.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList11.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList12.Items.Count; i++)
           {
               if (CheckBoxList12.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList12.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList13.Items.Count; i++)
           {
               if (CheckBoxList13.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList13.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList14.Items.Count; i++)
           {
               if (CheckBoxList14.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList14.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList15.Items.Count; i++)
           {
               if (CheckBoxList15.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList15.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList16.Items.Count; i++)
           {
               if (CheckBoxList16.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList16.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList17.Items.Count; i++)
           {
               if (CheckBoxList17.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList17.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList18.Items.Count; i++)
           {
               if (CheckBoxList18.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList18.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList19.Items.Count; i++)
           {
               if (CheckBoxList19.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList19.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList20.Items.Count; i++)
           {
               if (CheckBoxList20.Items[i].Selected)
               {
                   newtable.Columns.Add(CheckBoxList20.Items[i].ToString());
               }
           }
           for (int i = 0; i < CheckBoxList21.Items.Count; i++)
           {
               if (CheckBoxList21.Items[i].Selected)
               {
                   SAL2106 sal2106 = new SAL2106();
                   string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
                   DataTable bankname = sal2106.getbankname(CheckBoxList21.Items[i].Value, strOrgCode);  //查銀行名稱與代號
                   string strbankname = " ",strbankno="";
                   if (bankname != null && bankname.Rows.Count>0)
                   {
                       if (bankname.Rows[0]["bank_name"].ToString() != "" )
                       {
                           strbankname = bankname.Rows[0]["bank_name"].ToString();                          
                       }
                       if (bankname.Rows[0]["tdpf_bank_no"].ToString() != "")
                       {
                           strbankno = bankname.Rows[0]["tdpf_bank_no"].ToString();
                       }
                   }
                   newtable.Columns.Add(strbankname + strbankno); //欄位=名稱+編號 // 因為名稱=null
               }
           }
           return newtable;
    }
    //全選按鈕
    protected void allbutton_Click(object sender, EventArgs e)
    {      
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        { CheckBoxList2.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList3.Items.Count; i++)
        { CheckBoxList3.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList4.Items.Count; i++)
        { CheckBoxList4.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList5.Items.Count; i++)
        { CheckBoxList5.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList6.Items.Count; i++)
        { CheckBoxList6.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList7.Items.Count; i++)
        { CheckBoxList7.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList8.Items.Count; i++)
        { CheckBoxList8.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList9.Items.Count; i++)
        { CheckBoxList9.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList10.Items.Count; i++)
        { CheckBoxList10.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList11.Items.Count; i++)
        { CheckBoxList11.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList12.Items.Count; i++)
        { CheckBoxList12.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList13.Items.Count; i++)
        { CheckBoxList13.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList14.Items.Count; i++)
        { CheckBoxList14.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList15.Items.Count; i++)
        { CheckBoxList15.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList16.Items.Count; i++)
        { CheckBoxList16.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList17.Items.Count; i++)
        { CheckBoxList17.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList18.Items.Count; i++)
        { CheckBoxList18.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList19.Items.Count; i++)
        { CheckBoxList19.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList20.Items.Count; i++)
        { CheckBoxList20.Items[i].Selected = true; }
        for (int i = 0; i < CheckBoxList21.Items.Count; i++)
        { CheckBoxList21.Items[i].Selected = true; }

    }
    //清除按鈕
    protected void cleanbutton_Click(object sender, EventArgs e)
    {      
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        { CheckBoxList2.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList3.Items.Count; i++)
        { CheckBoxList3.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList4.Items.Count; i++)
        { CheckBoxList4.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList5.Items.Count; i++)
        { CheckBoxList5.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList6.Items.Count; i++)
        { CheckBoxList6.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList7.Items.Count; i++)
        { CheckBoxList7.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList8.Items.Count; i++)
        { CheckBoxList8.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList9.Items.Count; i++)
        { CheckBoxList9.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList10.Items.Count; i++)
        { CheckBoxList10.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList11.Items.Count; i++)
        { CheckBoxList11.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList12.Items.Count; i++)
        { CheckBoxList12.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList13.Items.Count; i++)
        { CheckBoxList13.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList14.Items.Count; i++)
        { CheckBoxList14.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList15.Items.Count; i++)
        { CheckBoxList15.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList16.Items.Count; i++)
        { CheckBoxList16.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList17.Items.Count; i++)
        { CheckBoxList17.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList18.Items.Count; i++)
        { CheckBoxList18.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList19.Items.Count; i++)
        { CheckBoxList19.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList20.Items.Count; i++)
        { CheckBoxList20.Items[i].Selected = false; }
        for (int i = 0; i < CheckBoxList21.Items.Count; i++)
        { CheckBoxList21.Items[i].Selected = false; }
    }
}