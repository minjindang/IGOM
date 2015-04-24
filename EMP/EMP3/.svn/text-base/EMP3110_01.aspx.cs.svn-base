using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using EMPPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public partial class EMP_EMP3_EMP3110_01 : BaseWebForm
{
    // 登入者機關代碼
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack) return;  
    }


    private bool doInsertData()
    {
        string strAP_IP = AP_IP_1.Text;
        string strAP_name = AP_name_1.Text;
        string strWS_type = WS_type_1.Text;
        string strAP_code = AP_code_1.Text;
        string strUcDate3 = UcDate3.Text;
        string strUcDate4 = UcDate4.Text;
        string strIs_disable = DropDownList1.SelectedValue;
        string strPurpose = Purpose_1.Text;
        string strNote_desc = Note_desc_1.Text;
               
        // 輸入檢查
        string strMsg="";
        if (strAP_IP == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統主機位址";
        }
        if (strAP_name == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統管理單位名稱";
        }
        if (strWS_type == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調類別";
        }
        if (strAP_code == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統代碼";
        }
        if (strUcDate3 == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調期間(起)";
        }
        if (strUcDate4 == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調期間(迄)";
        }
       
        if (strIs_disable == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "是否停用";
        }

        if (strMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下欄位資料 : "+strMsg, "", "");
            this.Page = tempPage;

            return false;
        }

        string UserId = LoginManager.UserId;
        strUcDate3 = (int.Parse(strUcDate3) + 19110000).ToString();
        strUcDate4 = (int.Parse(strUcDate4) + 19110000).ToString();

        EMP3110 emp3110 = new EMP3110();
        emp3110.queryadd(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate3, strUcDate4, strIs_disable, strPurpose
                                         , strNote_desc, UserId);
        return true;    
    }
 

    private bool doModify()
    {
        string strAP_IP = AP_IP_1.Text;
        string strAP_name = AP_name_1.Text;
        string strWS_type = WS_type_1.Text;
        string strAP_code = AP_code_1.Text;
        string strUcDate3 = UcDate3.Text;
        string strUcDate4 = UcDate4.Text;
        string strIs_disable = DropDownList1.SelectedValue;
        string strPurpose = Purpose_1.Text;
        string strNote_desc = Note_desc_1.Text; 
       
        // 輸入檢查
        string strMsg = "";
        if (strAP_IP == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統主機位址";
        }
        if (strAP_name == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統管理單位名稱";
        }
        if (strWS_type == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調類別";
        }
        if (strAP_code == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統代碼";
        }
        if (strUcDate3 == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調期間(起)";
        }
        if (strUcDate4 == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "資料查調期間(迄)";
        }

        if (strIs_disable == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "是否停用";
        }

        if (strMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下欄位資料 : " + strMsg, "", "");
            this.Page = tempPage;

            return false;
        }

        string UserId = LoginManager.UserId;
        strUcDate3 = (int.Parse(strUcDate3) + 19110000).ToString();
        strUcDate4 = (int.Parse(strUcDate4) + 19110000).ToString();

        EMP3110 emp3110 = new EMP3110();
        emp3110.queryedit(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate3, strUcDate4, strIs_disable, strPurpose
                                         , strNote_desc, UserId, edit_id.Text);
  
        return true;
      
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {     
         doQueryData();
    }

    // 查詢資料
    private void doQueryData()
    {   
        string strAP_IP = AP_IP.Text;
        string strAP_name = AP_name.Text;
        string strWS_type = WS_type.Text;
        string strAP_code = AP_code.Text;
        string strUcDate1 = UcDate1.Text;
        string strUcDate2 = UcDate2.Text;
        string strIs_disable = Is_disable.SelectedValue;
        string strPurpose = "";
        string strNote_desc = "";

        if (strUcDate1 != "")
        {
            strUcDate1 = (int.Parse(strUcDate1) + 19110000).ToString();
        }
        if (strUcDate2 != "")
        {
            strUcDate2 = (int.Parse(strUcDate2) + 19110000).ToString();
        }

        pnlNew.Visible = false;
        pnlQuery.Visible = true;

        EMP3110 emp3110 = new EMP3110();
        DataTable dt = emp3110.querysearch(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate1, strUcDate2, strIs_disable, strPurpose
                                         , strNote_desc);


        if (dt != null && dt.Rows.Count > 0)
        {
            dt.Columns.Add("start");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Is_disable"].ToString() == "0")
                {
                    dt.Rows[i]["start"] = "啟用";
                }
                else
                {
                    dt.Rows[i]["start"] = "停用";
                }
            }

            gvResult.DataSource = dt;
            gvResult.DataBind();
        }
        else
        {
    /*      Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
            */
            gvResult.DataSource = dt;
            gvResult.DataBind();

        

            if(gvResult.Rows.Count >0)
            {
                Ucpager1.Visible = true;
            }
            else
            {
                Ucpager1.Visible = false;
            }

        }


    }



    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //修改button
        {          
            pnlNew.Visible = true;
            pnlQuery.Visible = false;
            search.Visible = false;
            btnAddOK.Visible = false;
            btnEditOK.Visible = true;
            Label1.Text = "維護";
            int index = Convert.ToInt32(e.CommandArgument);
            initUpdate(index);           
        }
    }

    //修改帶入資料
    private void initUpdate(int index)// Grid 列
    {
        if (gvResult.Rows[index].Cells[4].Text.ToString().Trim() != "" && gvResult.Rows[index].Cells[4].Text.Length > 10 )
        {         
            DateTime d1 = Convert.ToDateTime(gvResult.Rows[index].Cells[4].Text);
            string date = d1.ToString("yyyyMMdd");
            UcDate3.Text = (int.Parse(date.Substring(0, 4)) - 1911).ToString() + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);    
        }
        if (gvResult.Rows[index].Cells[5].Text.ToString().Trim() != "" && gvResult.Rows[index].Cells[5].Text.Length > 10 )
        {
            DateTime d2 = Convert.ToDateTime(gvResult.Rows[index].Cells[5].Text);
            string date1 = d2.ToString("yyyyMMdd");
            UcDate4.Text = (int.Parse(date1.Substring(0, 4)) - 1911).ToString() + "/" + date1.Substring(4, 2) + "/" + date1.Substring(6, 2);
        }
    
          AP_IP_1.Text =  gvResult.Rows[index].Cells[0].Text;
          AP_name_1.Text = gvResult.Rows[index].Cells[1].Text;
          WS_type_1.Text = gvResult.Rows[index].Cells[2].Text;
          AP_code_1.Text = gvResult.Rows[index].Cells[3].Text;

          if (gvResult.Rows[index].Cells[6].Text == "啟用")
          {
              DropDownList1.SelectedValue = "0";
          }
          else
          {
              DropDownList1.SelectedValue = "1";
          }
          Purpose_1.Text = gvResult.Rows[index].Cells[7].Text.Replace("&nbsp;","");
          Note_desc_1.Text = gvResult.Rows[index].Cells[8].Text.Replace("&nbsp;", "");
          edit_id.Text = gvResult.Rows[index].Cells[12].Text; 
    }


    //刪除按鈕
    protected void btnSubmit_Click(object sender, EventArgs e)  
    {     
        int index = int.Parse(txtFuncParam.Value.Trim());
        string id = gvResult.Rows[index].Cells[12].Text; //key

        EMP3110 emp3110 = new EMP3110();
        emp3110.querydelete(id);

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = tempPage;

        doQueryData();
    }
  
    //新增按鈕
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //init text
        AP_IP_1.Text = AP_name_1.Text = WS_type_1.Text = AP_code_1.Text
      = UcDate3.Text = UcDate4.Text = Purpose_1.Text = Note_desc_1.Text
      = "";
        DropDownList1.SelectedValue = "0";
        pnlNew.Visible = true;
        pnlQuery.Visible = false;
        btnAddOK.Visible = true;
        btnEditOK.Visible = false;
        search.Visible = false;
        Label1.Text = "新增";
    }

    //取消按鈕
    protected void cancel_Click(object sender, EventArgs e)
    {
         search.Visible = true;
         pnlNew.Visible =false;
         if (Label1.Text == "新增")
         {         
         }
         else
         {         
             doQueryData();
         }
    } 

    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
        gvResult.Columns[12].Visible = true; //key
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        gvResult.Columns[12].Visible = false;  //key
    }

    protected void add_submit_Click(object sender, EventArgs e)
    {
        if (doInsertData())
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "新增成功", "", "");
            this.Page = tempPage;
            pnlNew.Visible = false;
            pnlQuery.Visible = false;
            search.Visible = true;
        }  
    }

    protected void edit_submit_Click(object sender, EventArgs e)
    {
        if (doModify())
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "修改成功", "", "");
            this.Page = tempPage;
            pnlNew.Visible = false;
            pnlQuery.Visible = true;
            search.Visible = true;
            doQueryData();
        }
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        doQueryData();
    }
}
