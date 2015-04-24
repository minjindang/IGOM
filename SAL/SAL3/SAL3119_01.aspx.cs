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

public partial class SAL_SAL3_SAL3119 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Page.IsPostBack) return; 

       string yy = DateTime.Now.ToString("yyyy");
       int num = int.Parse(yy) - 1911;
       ddlyy.Items.Clear();
       for (int i = num - 2; i <= num+1; i++)
       {
           ListItem li = new ListItem();
           li.Text = i.ToString();
           li.Value = i.ToString();
           ddlyy.Items.Add(li);
       }

       ddlyy.SelectedValue = (num - 1).ToString();
     
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
    
    }


    //代扣稅款明細
    protected void Button_detail_Click(object sender, EventArgs e)
    {
        message.Visible = true;
        ExportDetail();
    }

    //代扣稅款明細
    private void ExportDetail()
    {        
        SAL3119 sal3119 = new SAL3119();
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string date = (int.Parse(ddlyy.SelectedValue.ToString()) + 1911).ToString() + ddlmm.SelectedValue.ToString(); //畫面年月
        string cs = "";// ddlcno.SelectedValue;  //職業類別?
        
         DataTable data = sal3119.queryData(strOrgCode,date,cs);
         if (data != null && data.Rows.Count > 0)
         {
             GridView1.DataSource = data;
             GridView1.DataBind();
             GridView1.Visible = true;
             view.Visible = true;
             UcPager.Visible = true;
         }
         else
         {  
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
         /*    Page tempPage = this.Page;
             CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
             this.Page = tempPage;  
          */ 
         }

         DataTable data2 = sal3119.queryData2(strOrgCode, date);
         string inco_amt = "無資料";
         string inco_txam = "無資料";
         if (data2 != null && data2.Rows.Count > 0)
         {
            inco_amt = data2.Rows[0]["s_inco_amt"].ToString();
            inco_txam = data2.Rows[0]["s_inco_txam"].ToString();
            if (inco_amt == "0")
            {
                inco_amt = "無資料";
                inco_txam = "無資料";
            }  
         }
         Label_inco_amt.Text = inco_amt;
         Label_inco_txam.Text = inco_txam;

        string engf_amt = "無資料";
        string engf_txam = "無資料";
        DataTable data3 = sal3119.queryData3(strOrgCode, date);
        if (data3 != null && data3.Rows.Count > 0)
        {
            engf_amt = data3.Rows[0]["s_engf_amt"].ToString();
            engf_txam = data3.Rows[0]["s_engf_txam"].ToString();
            if (engf_amt == "0")
            {
                engf_amt = "無資料";
                engf_txam = "無資料";
            }
        }
        Label_engf_amt.Text = engf_amt;
        Label_engf_txam.Text = engf_txam; 
                           
    }

    //產生所得報稅檔
    protected void Button_report_Click(object sender, EventArgs e)
    {      
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼       
        string date = (int.Parse(ddlyy.SelectedValue.ToString()) + 1911).ToString() + ddlmm.SelectedValue.ToString(); //畫面年月
        string v_mid = LoginManager.UserId;  //Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString
        SAL3119 sal3119 = new SAL3119();
        DataTable data = sal3119.queryReportData(strOrgCode);
        if (data != null && data.Rows.Count > 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "前次作業排程中!!", "", "");
            this.Page = tempPage;
        }
        else
        {
           sal3119.queryInsertData(strOrgCode, v_mid, date);
           Page tempPage = this.Page;
           CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "本次作業進入排程!!", "", "");
           this.Page = tempPage;
        }
      
    }
    protected void Button_error_Click(object sender, EventArgs e)
    {
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string date = (int.Parse(ddlyy.SelectedValue.ToString()) + 1911).ToString() + ddlmm.SelectedValue.ToString(); //畫面年月
              
          SAL3119 sal3119 = new SAL3119();
          DataTable data = sal3119.queryerror(strOrgCode,date);
          if (data != null && data.Rows.Count > 0)
          {
              for (int i = 0; i < data.Rows.Count; i++)
              {
                  if (data.Rows[i]["engf_amt"].ToString() == "")
                  {
                      data.Rows[i]["engf_amt"] = "無資料";
                  }
                  else
                  {
                      Double a = Convert.ToDouble(data.Rows[i]["engf_amt"].ToString());
                      int amt = (int)a;
                      data.Rows[i]["engf_amt"] = amt;
                  }

                  if (data.Rows[i]["engf_txam"].ToString() == "")
                  {
                      data.Rows[i]["engf_txam"] = "無資料";
                  }
                  else
                  {
                      Double a = Convert.ToDouble(data.Rows[i]["engf_txam"].ToString());
                      int amt = (int)a;
                      data.Rows[i]["engf_txam"] = amt;
                  }
              }
              GridView2.DataSource = data;
              GridView2.DataBind();
              GridView2.Visible = true;
          }
          else
          {
              GridView2.Visible = false;
              Page tempPage = this.Page;
              CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查詢資料不存在", "", "");
              this.Page = tempPage;
          }
    }
    protected void ddlyy_SelectedIndexChanged(object sender, EventArgs e)
    {
        view.Visible = false;
        message.Visible = false;
    }
    protected void ddlmm_SelectedIndexChanged(object sender, EventArgs e)
    {
        view.Visible = false;
        message.Visible = false;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ExportDetail();
    }
}