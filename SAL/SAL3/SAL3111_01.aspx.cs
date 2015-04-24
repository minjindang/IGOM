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

public partial class SAL_SAL3_SAL3111 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    private string strUserID;  

    protected void Page_Load(object sender, EventArgs e)
    {
        // 測試 ucSaCode 的 autoPostBack
        // User Control Event Binder
        cmb_uc_calitem.ReturnEvent = true;
        cmb_uc_calitem.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(calItemChanged);// 計算項目改變
       

        chkOtherItem.SelectedIndexChanged += new EventHandler(chkOtherItem_SelectedIndexChanged);

        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        strUserID = LoginManager.UserId;//GetTicketUserData(LoginManager.LoginUserData.Personnel_id);
        
        if (Page.IsPostBack) return;
     
        this.doCalItemChanged();
        this.doRangeChange();
        UcROCYearMonth1.DateStr = DateTime.Now.ToString("yyyyMM");

        UcDDLDepart.Orgcode = UcDDLDepart1.Orgcode = strOrgCode;
            
    }

    // 計算項目改變
    protected void calItemChanged(object sender, EventArgs e)
    {
        gvResult.Visible = false;
        pnlDetail.Visible = false;
        GridView1.Visible = false;


        if (cmb_uc_calitem.SelectedValue == "008")
        {
            txtUcDate.Visible = false;
            Label1.Visible = false;
        }
        else
        {
            Label1.Visible = true;
            txtUcDate.Visible = true;
        }

        if (cmb_uc_calitem.SelectedValue == "005")
        {
            ListItem li = new ListItem();
            li.Text = "依批號查詢";
            li.Value = "004";
            cmbRangeSelection.Items.Add(li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = "依批號查詢";
            li.Value = "004";
            cmbRangeSelection.Items.Remove(li);
        }


        Button_Caculate.Visible = true;
        doCalItemChanged();
        // 選擇項目
        if (cmb_uc_calitem.SelectedValue == "002" || 
            cmb_uc_calitem.SelectedValue == "003" || 
            cmb_uc_calitem.SelectedValue == "004")
        {
            UcROCYearMonth1.Kind = "Y";
        }
        else
        {
            UcROCYearMonth1.Kind = "YM";
        }
      

        if (cmbRangeSelection.SelectedItem.Value == "004" && cmb_uc_calitem.SelectedValue == "005")
        {
            // 依批號查詢
            pnlSerNO.Visible = true;
        }
        else
        {
            pnlSerNO.Visible = false;
        }

    }
    
 

    private void doCalItemChanged()
    {
        String strCodeNo = cmb_uc_calitem.Code_no;
        // 隱藏其他項目
        pnlOthers.Visible = false;
        pnlMonths.Visible = false;
        gvResult.Visible = false;
        gvDetail.Visible = false;
         if (strCodeNo == "001")
        {
            //月薪
        }
        else if (strCodeNo == "002")
        {
            // 預借考績
        }
        else if (strCodeNo == "003")
        {
            // 預借考績
        }
        else if (strCodeNo == "004")
        {
            // 年終獎金
            pnlMonths.Visible = true;
        }
        else if (strCodeNo == "005")
        {
            // 其它薪津
            doItemOthers();
        }
        else if (strCodeNo == "006")
        {
            // 預借考績
        }
    }

    // 其它薪津
    private void doItemOthers()
    {
        // 顯示其他項目
        pnlOthers.Visible = true;
        // 查詢其他薪津項目
        querySalSaItem();

    }

   // 查詢其他薪津項目
    private void querySalSaItem()
    {
        SAL3111 sal3111 = new SAL3111();

        DataTable dt = sal3111.querySalSaItem(this.strOrgCode);
        chkOtherItem.DataSource = dt;
        chkOtherItem.DataValueField = "item_code";
        chkOtherItem.DataTextField = "item_name";
        chkOtherItem.DataBind();

    }


    protected void cmb_uc_rangeselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        doRangeChange();
    }

    // 計算範圍更改 
    private void doRangeChange()
    {
        // 顯示使用者選項
        pnlUserOptions.Visible = false;
        // 選擇批號部分
        pnlSerNO.Visible = false;
        Button_Search.Visible = false;
    
        if (cmbRangeSelection.SelectedItem.Value == "005")
        {
            // 挑選人員
            pnlUserOptions.Visible = true;
            Button_Search.Visible = true;
        }
        else if (cmbRangeSelection.SelectedItem.Value == "004" && cmb_uc_calitem.SelectedValue=="005")
        {
            // 依批號查詢
            pnlSerNO.Visible = true;
        }
    }

    // 查詢批號清單
    private void doQuerySalPayItem()
    {
        gvResult.Visible = false;
        // 參數
        string strItemCodes="";  
        string strMergeFlowID="";    // 畫面條件中之批號
        // 選批號
        if (cmbRangeSelection.SelectedItem.Value == "2")
        {
           
            // 判斷輸入
            if (edtBatNo.Text.ToString().Trim() == "")
            {
                //Label1.Text = "請輸入批號";
                Page tmp = this.Page;
                CommonFun.MsgShow(ref tmp, 
                    CommonFun.Msg.Custom ,
                    "請輸入批號" , "","");   
                this.Page = tmp;
                return;
            }

            strMergeFlowID = edtBatNo.Text.ToString().Trim();
        }
        else
        {
            strMergeFlowID = "";
        }

        // 需計算之其他項目
        // 無資料先帶空
        for (int i = 0; i < chkOtherItem.Items.Count; i++)
        {
            if (chkOtherItem.Items[i].Selected)
            {
                if (strItemCodes != "") strItemCodes += "','";
                strItemCodes += chkOtherItem.Items[i].Value.Trim();
            }
        }
        if (strItemCodes != "")
        {
            strItemCodes = "'" + strItemCodes + "'";
        }


        if (strMergeFlowID == "" && strItemCodes == "")
        {
            // 兩者皆空不做
            return;
        }
        if (strItemCodes == "")
        {
            return;
        }

        // new SAL3111
        SAL3111 sal3111 = new SAL3111();
        // 查詢其他薪津項目
        DataTable dt =  sal3111.querySalPayItem(this.strOrgCode, strItemCodes, strMergeFlowID);
        gvResult.DataSource = dt;

        Button_Caculate.Visible = (dt.Rows.Count > 0);

        gvResult.Columns[1].Visible = true;
        gvResult.Columns[2].Visible = true;

        gvResult.DataBind();
        gvResult.Visible = true;

        gvResult.Columns[1].Visible = false;
        gvResult.Columns[2].Visible = false;
        
    }


    //按下計算按鈕
    protected void Button_Caculate_Click(object sender, EventArgs e)
    {
        SAL3111 sal3111 = new SAL3111();
        string strCalType = cmbRangeSelection.SelectedValue.Trim(); ;  // 計算範圍
        string strBaseProNO = ddlType.SelectedValue;     //人員類別選項
        string strOnJob     = cmbOnJob.SelectedValue;    // 在職狀態
        string strUserName  = txtUserName.Text.Trim();   // 姓名
        string strPayDate   = SAL3101.ROCDateStrToDateStr(txtUcDate.Text);  // 發放日期
        string strMonths = txtMonths.Text;

        if (strPayDate == "" && cmb_uc_calitem.SelectedValue != "008")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入發放日期", "", "");
            this.Page = tempPage;
            return;
        };

        if (cmb_uc_calitem.SelectedValue == "004")
        {
            if (strMonths.Trim() == "")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "請輸入獎金月數", "", "");
                this.Page = tempPage;
                return;
            }
        }

        if (cmb_uc_calitem.SelectedValue == "005") //計算項目=005其他新金
        {
            // 刪除資料
            sal3111.deleteSalSaCalCBase(this.strOrgCode, UcROCYearMonth1.DateStr );
            
            // 新增資料
            if (GridView1.Rows.Count > 0 && strCalType =="005") //挑選人員
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox chb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                    if (chb.Checked)
                    {
                        strUserName = GridView1.Rows[i].Cells[2].Text;
                        sal3111.insertSalSacalcbase(UcROCYearMonth1.DateStr
                            , this.strOrgCode, strCalType, strBaseProNO, strOnJob, strUserName);
                    }
                }
            }
            else
            {
                sal3111.insertSalSacalcbase(UcROCYearMonth1.DateStr
                           , this.strOrgCode, strCalType, strBaseProNO, strOnJob, strUserName);
            }

            // 針對 Grid 中資料輸入
            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                //find checkbox
                CheckBox chk = (CheckBox)gvResult.Rows[i].FindControl("chkSelect");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        // 參數
                        string strSerNO = sal3111.getSerNO();                      
                        sal3111.insertSalSabatJob(strSerNO, this.strOrgCode, this.strUserID, "005", cmbRangeSelection.SelectedValue);
                  //      sal3111.insertSalSacalcbase(UcROCYearMonth1.DateStr, this.strOrgCode, strCalType, strSerNO, strBaseProNO, strUserName);

                        sal3111.insertSalSaBatPara(strSerNO, "1", 
                            UcROCYearMonth1.DateStr );
                        sal3111.insertSalSaBatPara(strSerNO, "2", strPayDate);
                        sal3111.insertSalSaBatPara(strSerNO, "3", gvResult.Rows[i].Cells[3].Text);
                    }
                }
            }

        }
        else
        {
            // 參數
            string strSerNO = sal3111.getSerNO();
            //Response.Write(strSerNO);
            //若計算範圍非全部(含臨時工)時，執行下列SQL
            if (strCalType != "001" )
            {
                if (GridView1.Rows.Count > 0 && strCalType == "005") //挑選人員
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        CheckBox chb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ch");
                        if (chb.Checked)
                        {
                            strUserName = GridView1.Rows[i].Cells[2].Text;
                            sal3111.updateSABase(this.strOrgCode, strCalType, strBaseProNO, strOnJob, strUserName);
                        }
                    }
                }
                else
                {
                    sal3111.updateSABase(this.strOrgCode, strCalType, strBaseProNO, strOnJob, strUserName);
                }
            }

            // insertSalSabatJob
            sal3111.insertSalSabatJob(strSerNO, this.strOrgCode, this.strUserID, cmb_uc_calitem.SelectedValue, cmbRangeSelection.SelectedValue);

            if (cmb_uc_calitem.SelectedValue == "001")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                    UcROCYearMonth1.DateStr);
                sal3111.insertSalSaBatPara(strSerNO, "2",
                    strPayDate);
            }
            if (cmb_uc_calitem.SelectedValue == "002")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                    UcROCYearMonth1.DateStr.Substring(0,4));
                sal3111.insertSalSaBatPara(strSerNO, "2",
                    strPayDate);
            }
            else if (cmb_uc_calitem.SelectedValue == "003")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                    UcROCYearMonth1.DateStr.Substring(0, 4));
                sal3111.insertSalSaBatPara(strSerNO, "2",
                    strPayDate);
                    //UcROCYearMonth1.Year.ToString().PadLeft(4, '0') + UcROCYearMonth1.Month.ToString().PadLeft(2, '0'));
            }
            else if (cmb_uc_calitem.SelectedValue == "004")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                    UcROCYearMonth1.DateStr.Substring(0, 4));
                sal3111.insertSalSaBatPara(strSerNO, "2", strMonths);   // 僅獎金月數
                sal3111.insertSalSaBatPara(strSerNO, "3", strPayDate);
            }
            else if (cmb_uc_calitem.SelectedValue == "006" || cmb_uc_calitem.SelectedValue == "012")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                    UcROCYearMonth1.DateStr);
                sal3111.insertSalSaBatPara(strSerNO, "2",
                    strPayDate);
            }
            else if (cmb_uc_calitem.SelectedValue == "008")
            {
                sal3111.insertSalSaBatPara(strSerNO, "1",
                   UcROCYearMonth1.DateStr);
            }
        }

        gvResult.Visible = false;
        gvDetail.Visible = false;
        btnShowDetailFinish.Visible = false;

        Page tempPage2 = this.Page;
        CommonFun.MsgShow(ref tempPage2,
           CommonFun.Msg.Custom, "批次計算送出，預計十分鐘完成計算，請在十分鐘後，至薪資計算結果查詢與維護查詢計算結果", "", "");
        this.Page = tempPage2;
    }

    //需計算之其他薪津項目
    protected void chkOtherItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDetail.Visible = false;
        // 取得資料
        getOthersData();
    }

    private void getOthersData()
    {
//        Response.Write("chkOtherItem_SelectedIndexChanged");
        doQuerySalPayItem();
    }



    private void getDetailData(string strBatchNO)
    {
        SAL3111 sal3111 = new SAL3111();
        DataTable dt =
            sal3111.querySalSaitemDetail(this.strOrgCode, strBatchNO);

        gvDetail.DataSource=dt;
        gvDetail.Columns[5].Visible = true;
        gvDetail.Columns[6].Visible = true;
        gvDetail.Columns[7].Visible = true;
        gvDetail.Columns[8].Visible = true;
        gvDetail.Columns[9].Visible = true;
        gvDetail.Columns[10].Visible = true;
        gvDetail.Columns[11].Visible = true;
        gvDetail.DataBind();
        gvDetail.Columns[5].Visible = false;
        gvDetail.Columns[6].Visible = false;
        gvDetail.Columns[7].Visible = false;
        gvDetail.Columns[8].Visible = false;
        gvDetail.Columns[9].Visible = false;
        gvDetail.Columns[10].Visible = false;
        gvDetail.Columns[11].Visible = false;

        gvDetail.Visible = true;    
        pnlDetail.Visible = true;
//        Response.Write("Get Detail");
        for (int i = 0; i < gvDetail.Rows.Count; i++)
        {
//            TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
//            if (edt != null) edt.Enabled = false;
            uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
            if (ucSaCode != null) ucSaCode.Rebind();
            ucSaCode.SelectedValue = dt.Rows[i]["PAYITEM_Budget_code"].ToString();

            DropDownList cmb = (DropDownList)ucSaCode.FindControl("DropDownList_code_no");
            if (cmb != null) cmb.Enabled = false;
        }

        btnShowDetailFinish.Visible = true;
        Button_Caculate.Visible = false;

    }


    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // 顯示明細
        if (e.CommandName == "ShowDetail")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvResult.Rows[index];
            getDetailData(row.Cells[3].Text.ToString());
        
        }
    }

    protected void btnShowDetailFinish_Click(object sender, EventArgs e)
    {
        // 明細資料回存資料庫
        // 參數
        for (int i = 0; i < gvDetail.Rows.Count; i++)
        {
            TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
            string strAmount = "";
            if (edt.Text != null)
            {
                strAmount = edt.Text.Trim();
            }
            string strMergeFlowID = gvDetail.Rows[i].Cells[0].Text;
            string strPayitemUserID = gvDetail.Rows[i].Cells[6].Text;
            SAL3111 sal3111 = new SAL3111();
            sal3111.updateOthersDetail(strAmount, this.strOrgCode, strMergeFlowID, strPayitemUserID);
        }

        gvDetail.Visible = false;
        doQuerySalPayItem();
        btnShowDetailFinish.Visible = false;
        Button_Caculate.Visible = true;

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "儲存完成", "", "");
        this.Page = tempPage;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Server.Transfer(Request.Path);
    }

    //執行查詢
    protected void Button_Search_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "" && UcDDLDepart.SelectedValue == "" && UcDDLDepart1.SelectedValue=="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請填姓名查詢或選佔缺、服務單位", "", "");
            this.Page = tempPage;
            return;
        }

        string strtype = ddlType.SelectedValue;
        string Job = cmbOnJob.SelectedValue;
        string UserName = txtUserName.Text;
        string Depart = UcDDLDepart.SelectedValue;
        string Depart1 = UcDDLDepart1.SelectedValue;

        SAL3111 sal3111 = new SAL3111();
        DataTable dt =  sal3111.detail1(strtype, Job, UserName, Depart, Depart1);

        if (dt != null && dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
        else
        {
            GridView1.Visible = false;
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
        }

    }
}