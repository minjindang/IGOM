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

public partial class EMP_EMP3_EMP3101_01 : BaseWebForm
{
    // 登入者機關代碼
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        get1stDept();
        getSystemNames();
    }

    // 取得機關下拉資料
    private void get1stDept()
    {
        EMP3101 emp3101 = new EMP3101();

        DataTable dt = emp3101.get1stDeptList();
        cmb1stDept.DataSource = dt;
        cmb1stDept.DataTextField = "ORGCODE_NAME";
        cmb1stDept.DataValueField = "ORGCODE";
        cmb1stDept.DataBind();
        cmb1stDept4Edit.DataSource = dt;
        cmb1stDept4Edit.DataTextField = "ORGCODE_NAME";
        cmb1stDept4Edit.DataValueField = "ORGCODE";
        cmb1stDept4Edit.DataBind();

    }


    // 取得應用程式下拉部分
    private void getSystemNames()
    {
        EMP3101 emp3101 = new EMP3101();
        string str1stOrgCode =
            cmb1stDept.SelectedValue;

        DataTable dt = emp3101.queryEMPApplicaSysProf(str1stOrgCode, "", "");
        cmbSystemNames.DataSource = dt;
        cmbSystemNames.DataTextField = "SYSTEM_NAME";
        cmbSystemNames.DataValueField = "SYSTEM_CODE";
        cmbSystemNames.DataBind();
        // 家一郭空白的
        ListItem itm=new ListItem();
        itm.Text    ="";
        itm.Value   ="";
        cmbSystemNames.Items.Insert(0,itm);

    }


    private bool doInsertData()
    {
        // 參數
        string strOrgCode   = cmb1stDept4Edit.SelectedValue;  // 機關代碼
        string strSystemCode= txtSystemCode.Text.Trim();   // 應用系統代碼
        string strSystemName= txtsystemName.Text.Trim();   // 應用系統名稱
        string strServerIP  = txtServerIP.Text.Trim();  // 伺服器位址
        string strWebURL    = txtWebURL.Text.Trim();   // 應用系統網址
        string strisActiveFlag  = "";
        if (chkisActive.Checked)
        {
            strisActiveFlag="Y";
        }
        else
        {
            strisActiveFlag="N";
        }
        string strNoteDesc  = txtNoteDesc.Text.Trim(); // 備註說明
        string strChangeUserID  =LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card); // 異動人員
        string strAPIdCard  =txtAPIdCard.Text.Trim();  // 應用系統負責人

        // 輸入檢查
        string strMsg="";
        if (strSystemCode == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統代碼";
        }
        if (strSystemName == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統名稱";
        }
        if (strServerIP == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "伺服器位址";
        }
        if (strWebURL == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用程式網址";
        }
        if (strAPIdCard == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統負責人";
        }

        if (strMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下欄位資料 : "+strMsg, "", "");
            this.Page = tempPage;

            return false;
        }

        EMP3101 emp3101 = new EMP3101();
        // 檢查 =====================================================
        // 系統代號存在否?
        DataTable dt = emp3101.queryEMPApplicaSysProf(this.strOrgCode, strSystemCode, "");
        if (dt.Rows.Count > 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "應用系統代碼 " + strSystemCode + " 已存在資料，請使用維護功能", "", "");
            this.Page = tempPage;
            return false;
        }
        // IShare是否使用中？
        // EShare使用中？


        emp3101.insertEMPApplicaSysProf(
            strOrgCode,  // 機關代碼
            strSystemCode,   // 應用系統代碼
            strSystemName,   // 應用系統名稱
            strServerIP,  // 伺服器位址
            strWebURL,   // 應用系統網址
            strisActiveFlag, // 是否啟用
            strNoteDesc, // 備註說明
            strChangeUserID, // 異動人員
            strAPIdCard  // 應用系統負責人
            );
        return true;
    
    }

    protected void btnOK_Click1(object sender, EventArgs e)
    {

        if (mode.Text == "EDIT")
        {
            doModify();
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "修改成功", "", "");
            this.Page = tempPage;
            pnlNew.Visible = false;
            pnlQuery.Visible = true;
            doQueryData();
        }
        else
        {
            if (doInsertData()) {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "新增成功", "", "");
            this.Page = tempPage;
            pnlNew.Visible = false;
            pnlQuery.Visible = false;
            doQueryData();
            }
        }
        mode.Text = "";
    }

    private bool doModify()
    {
        // 參數
        string strOrgCode = cmb1stDept4Edit.SelectedValue;  // 機關代碼
        string strSystemCode = txtSystemCode.Text.Trim();   // 應用系統代碼
        string strSystemName = txtsystemName.Text.Trim();   // 應用系統名稱
        string strServerIP = txtServerIP.Text.Trim();  // 伺服器位址
        string strWebURL = txtWebURL.Text.Trim();   // 應用系統網址
        string strisActiveFlag = "";
        if (chkisActive.Checked)
        {
            strisActiveFlag = "Y";
        }
        else
        {
            strisActiveFlag = "N";
        }
        string strNoteDesc = txtNoteDesc.Text.Trim(); // 備註說明
        string strChangeUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card); // 異動人員
        string strAPIdCard = txtAPIdCard.Text.Trim();  // 應用系統負責人

        this.getUserName();

        // 輸入檢查
        string strMsg = "";
        if (strSystemCode == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統代碼";
        }
        if (strSystemName == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統名稱";
        }
        if (strServerIP == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "伺服器位址";
        }
        if (strWebURL == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用程式網址";
        }
        if (strAPIdCard == "")
        {
            if (strMsg != "") strMsg += ",";
            strMsg += "應用系統負責人";
        }
        else
        {

        }

        if (strMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入以下欄位資料 : " + strMsg, "", "");
            this.Page = tempPage;

            return false;
        }

        /*
        string strAPName = labAPName.Text.Trim();
        if (strAPName == "")
        {
            Page tempPage2 = this.Page;
            CommonFun.MsgShow(ref tempPage2,
               CommonFun.Msg.Custom, strAPIdCard +" 不是正確的人員代號" ,"", "");
            this.Page = tempPage2;

            return false;
        }
         */



        EMP3101 emp3101 = new EMP3101();
        emp3101.editEMPApplicaSysProf(
            strSystemName,   // 應用系統名稱
            strServerIP,  // 伺服器位址
            strWebURL,   // 應用系統網址
            strisActiveFlag, // 是否啟用
            strNoteDesc, // 備註說明
            strChangeUserID, // 異動人員
            strAPIdCard  // 應用系統負責人
            ,lblID.Text
            );
        return true;
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = false;
        pnlQuery.Visible = true;
//        pnlInput.Visible = false;
//        this.Ucpager1.PSize = 10;
        this.Ucpager1.PNow = 1;
        doQueryData();

    }

    // 取得資料
    private void doQueryData()
    {
        //
        EMP3101 emp3101 = new EMP3101();
        string str1stOrgCode =
            cmb1stDept.SelectedValue;
        string strSystemCode = cmbSystemNames.SelectedValue;
        string strisActive = "";
        if (chkActive.Checked) strisActive += "'Y\'";
        if (chkDisable.Checked)
        {
            if (strisActive != "") strisActive += ",";
            strisActive += "'N'";
        }
        DataTable dt = emp3101.queryEMPApplicaSysProf(str1stOrgCode, strSystemCode, strisActive);

        showhidecol(true);
        gvResult.DataSource = dt;
        gvResult.DataBind();
        showhidecol(false);

    }

    private void showhidecol(bool bshow)
    {
        gvResult.Columns[0].Visible = bshow;
        gvResult.Columns[1].Visible = bshow;
        gvResult.Columns[2].Visible = bshow;
        gvResult.Columns[3].Visible = bshow;
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //修改button
        {          
            pnlNew.Visible = true;         
            int index = Convert.ToInt32(e.CommandArgument);
            initUpdate(index);           
        }
    }

    //修改帶入資料
    private void initUpdate(int index)// Grid 列
    {
        mode.Text = "EDIT";
        cmb1stDept4Edit.Enabled = false;
//        txtAPIdCard.Enabled = false;
        txtSystemCode.Enabled = false;

        cmb1stDept4Edit.SelectedValue = gvResult.Rows[index].Cells[0].Text;
        txtAPIdCard.Text = gvResult.Rows[index].Cells[1].Text;
        txtSystemCode.Text = gvResult.Rows[index].Cells[7].Text;
        txtsystemName.Text = gvResult.Rows[index].Cells[6].Text;
        txtServerIP.Text = gvResult.Rows[index].Cells[8].Text;
        txtWebURL.Text = gvResult.Rows[index].Cells[9].Text;
        txtNoteDesc.Text = gvResult.Rows[index].Cells[3].Text.Replace("&nbsp;", "");
        if (gvResult.Rows[index].Cells[2].Text.ToString().Trim() == "Y")
        {
            chkisActive.Checked = true;
        }
        else
        {
            chkisActive.Checked = false;
        }
        lblID.Text = gvResult.Rows[index].Cells[4].Text;
//        this.getUserName();
        pnlQuery.Visible = false;
        btnAddOK.Visible = false;
        btnEditOK.Visible = true;
        pnlInput.Visible = false;
    }


    //刪除按鈕
    protected void btnSubmit_Click(object sender, EventArgs e)  
    {
        // 檢查是否使用
        // 
        EMP3101 emp3101 = new EMP3101();

        int index = int.Parse(txtFuncParam.Value.Trim());
        string OrgCode = gvResult.Rows[index].Cells[0].Text;
        string SystemCode = gvResult.Rows[index].Cells[7].Text;
        if (emp3101.isSystemCodeUsed(OrgCode, SystemCode))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "應用系統使用中，無法刪除", "", "");
            this.Page = tempPage;
            return;
        }

        string AP_idcard = gvResult.Rows[index].Cells[1].Text;
        string ID = gvResult.Rows[index].Cells[4].Text;
        emp3101.DeleteEMPApplicaSysProf(OrgCode, AP_idcard, ID);

        doQueryData();
        getSystemNames();
    }

    //匯出按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        //依查詢條件匯出
        EMP3101 emp3101 = new EMP3101();
        string str1stOrgCode =
            cmb1stDept.SelectedValue;
        string strSystemCode = cmbSystemNames.SelectedValue;
        string strisActive = "";
        if (chkActive.Checked) strisActive += "'Y\'";
        if (chkDisable.Checked)
        {
            if (strisActive != "") strisActive += ",";
            strisActive += "'N'";
        }
        DataTable dt = emp3101.queryEMPApplicaSysProf(str1stOrgCode, strSystemCode, strisActive);

        // 匯出動作
        CommonLib.DTReport rpt;
        rpt = new CommonLib.DTReport(Server.MapPath("~/Report/EMP/EMP3101.mht"), dt);
        rpt.ExportFileName = "應用系統設定作業";

        // 參數部分
        string[] strParams = new string[1];
        strParams[0] = "";

        rpt.Param = strParams;
        rpt.ExportToExcel();        

    }
    //新增按鈕
    protected void btnNew_Click(object sender, EventArgs e)
    {
        mode.Text = "ADD";
        cmb1stDept4Edit.Enabled = true;
        txtAPIdCard.Enabled = true;
        txtSystemCode.Enabled = true;
        //init
        txtAPIdCard.Text = "";
        txtSystemCode.Text = "";
        txtsystemName.Text = "";
        txtServerIP.Text = "";
        txtWebURL.Text = "";
        txtNoteDesc.Text = "";
        chkisActive.Checked = false;

        pnlNew.Visible = true;
        pnlQuery.Visible = false;
        pnlInput.Visible = false;

        btnAddOK.Visible = true;
        btnEditOK.Visible = false;



    }
    //取消按鈕
    protected void cancel_Click(object sender, EventArgs e)
    {
         pnlNew.Visible =false;
         pnlInput.Visible = true;
    }
    protected void btnGetUserName_Click(object sender, EventArgs e)
    {
        getUserName();
    }

    private void getUserName()
    {
        EMP3103 emp3103 = new EMP3103();
        labAPName.Text = emp3103.getUserName(txtAPIdCard.Text.Trim());
    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
        this.showhidecol(true);
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        this.showhidecol(false);
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
            doQueryData();
            pnlInput.Visible = true;
        }
        mode.Text = "";

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
            pnlInput.Visible = true;
            doQueryData();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = false;
        pnlQuery.Visible = false;
        pnlInput.Visible = true;
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        doQueryData();
    }
    protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}
