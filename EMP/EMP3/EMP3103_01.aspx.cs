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

public partial class EMP_EMP3_EMP3103_01 : BaseWebForm
{

    // 登入者機關代碼 
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    string strLoginUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
   

    protected void Page_Load(object sender, EventArgs e)
    {
       
        cmb_uc_org4Edit.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(subDept_change); //單位名稱
        
    //    cmb_uc_idtype4Edit.ReturnEvent = true;
    //    cmb_uc_idtype4Edit.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(code_changed); //人員類別

        UcDDLMember.SelectedIndexChanged += new UControl_UcDDLMember.SelectedIndexChangedEventHandler(namecgange); //人員姓名

     

        if (Page.IsPostBack) return;
        get1stDept(); //取得機關下拉資料
       
        this.pnlModify.Visible = false;
        this.pnlresult.Visible = false;
        mode.Text = "";
        bindDept();
    
    }

    private void bindDept()
    {
        cmb_uc_org.Orgcode =   cmb1stDept.SelectedValue;
    }

    protected void namecgange(object sender, EventArgs e)  //change 人員姓名
    {      
        this.queryUseDefaultSystems();
    }

    protected void subDept_change(object sender, EventArgs e)  //change 單位名稱
    {     
        UcDDLMember.Orgcode = strOrgCode;
        UcDDLMember.DepartId = cmb_uc_org4Edit.SelectedValue; //add 人員姓名

        lstSelect.Items.Clear();
    }

 /*   protected void code_changed(object sender, EventArgs e) //change 人員類別
    {

    }*/


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




    protected void btnQuery_Click(object sender, EventArgs e)
    {
        doQueryData();   
    }

    private void doQueryData()
    {
        EMP3103 emp3103 = new EMP3103();
        string strDepartID = cmb_uc_org.SelectedValue;
        string strShareID = cmb_uc_idtype.SelectedValue;
        string strIDCard = txtIDCard.Text;

        DataTable dt = emp3103.queryEMPEshareSysProfFull(
            this.strOrgCode,
            strDepartID,
            strShareID,
            strIDCard);    

        if (dt != null && dt.Rows.Count > 0)
        {
            this.pnlresult.Visible = true;
            showhidecol(true);
            gvResult.DataSource = dt;
            gvResult.DataBind();
            showhidecol(false);
        }
        else
        {
            this.pnlresult.Visible = true;
            gvResult.DataSource = dt;
            gvResult.DataBind();

            if (gvResult.Rows.Count > 0)
            {
                Ucpager1.Visible = true;
            }
            else
            {
                Ucpager1.Visible = false;
            }

      /*      Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
       */
 
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        mode.Text = "ADD";
        pnlConditions.Visible = false;
        pnlresult.Visible = false;
        pnlModify.Visible = true;
        btnAddOK.Visible = true;
        btnEditOK.Visible = false;
        lblMode.Text = "新增";  

        getAllSystems();  //All system
     
        showhideModifyControls(true);

        lstSelect.Items.Clear();
        cmb1stDept4Edit.SelectedIndex = 0;
        cmb_uc_org4Edit.Orgcode = cmb1stDept4Edit.SelectedValue; 
        UcDDLMember.Orgcode = strOrgCode;
        UcDDLMember.DepartId = "";
    }


    private void queryUseDefaultSystems() // use listbox 
    {
        // 取得資料
        EMP3102 emp3112 = new EMP3102();
        string strDepartID = cmb_uc_org4Edit.SelectedValue; //單位名稱

        EMP3103 emp3103 = new EMP3103(); //用姓名UcDDLMember.SelectedValue查資料
        DataTable dtn = emp3103.querySelectnametype(UcDDLMember.SelectedValue); //員工編號
        string employee_type = "";

        if (dtn.Rows.Count == 0)
        {
            dtn = emp3103.querySelectnonametype(UcDDLMember.SelectedValue);
            employee_type = dtn.Rows[0]["nonemployee_type"].ToString(); //員工類別編號    
        }
        else
        {
            dtn.Rows[0]["employee_type"].ToString(); //員工類別編號  
        }
        
        //右邊存在的LIST
        DataTable dt;
        //用員工編號查 EMP_ESHARE_SYS_PROF
        dt = emp3112.querySelectSystem_3(cmb1stDept4Edit.SelectedValue,
         strDepartID,
         UcDDLMember.SelectedValue
         , "Y");
        string mode = "ESHARE";
        if (dt.Rows.Count == 0)
        {
           
            //用類別查 EMP_ISHARE_SYS_PROF
            dt = emp3112.querySelectSystem_2(cmb1stDept4Edit.SelectedValue,
             strDepartID,
             employee_type
             , "Y");
            mode = "ISHARE";
        }

        lstSelect.Items.Clear();
        lstSelect.DataSource = dt;
        lstSelect.DataValueField = "SYSTEM_CODE";
        lstSelect.DataTextField = "SYSTEM_NAME";
        lstSelect.DataBind();


        //左邊存在的要移除右邊list
        DataTable dtall;
            //員工編號 ESHARE
            dtall = emp3112.querySelectSystem_3(cmb1stDept4Edit.SelectedValue,
            strDepartID,
            UcDDLMember.SelectedValue
            , "N");

        if (mode == "ISHARE")
        {
            //用員工類別查 ISHARE
            dtall = emp3112.querySelectSystem_2(cmb1stDept4Edit.SelectedValue,
             strDepartID,
             employee_type
             , "N");
        }

        lstUnSelect.Items.Clear();
        lstUnSelect.DataSource = dtall;
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataBind();
    }

    private void getAllSystems()
    {
        // 取得相關項目
        EMP3101 emp3101 = new EMP3101();
        // 參數
        string str1stOrgCode =
            cmb1stDept.SelectedValue;
        string strisActive = "'Y'";
        DataTable dt = emp3101.queryEMPApplicaSysProf(str1stOrgCode, "", strisActive);
        lstUnSelect.DataSource = dt;
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataBind();
    }

    protected void btnSelectFun_Click(object sender, EventArgs e)
    {
        for (int i = lstUnSelect.Items.Count - 1; i >= 0; i--)
        {
            if (lstUnSelect.Items[i].Selected)
            {
                ListItem item = lstUnSelect.Items[i];
                lstSelect.Items.Add(item);
                lstUnSelect.Items.Remove(item);
            }
        }
    }
    protected void btnRemoveFun_Click(object sender, EventArgs e)
    {
        for (int i = lstSelect.Items.Count - 1; i >= 0; i--)
        {
            if (lstSelect.Items[i].Selected)
            {
                ListItem item = lstSelect.Items[i];
                lstUnSelect.Items.Add(item);
                lstSelect.Items.Remove(item);
            }
        }
    }
    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //修改button
        {
            mode.Text = "EDIT";
            int index = Convert.ToInt32(e.CommandArgument);
            initUpdate(index);
            lblMode.Text = "維護";
            pnlModify.Visible = true;
            pnlresult.Visible = false;
            pnlConditions.Visible = false;
            btnAddOK.Visible = false;
            btnEditOK.Visible = true;
        }
    }

    private void initUpdate(int index)// Grid 列
    {
        EMP3103 emp3103 = new EMP3103();
        EMP3102 emp3102 = new EMP3102();

        cmb1stDept4Edit.Enabled = false;     
      
     ///   DropDownList cmb = (DropDownList)cmb_uc_idtype4Edit.FindControl("DropDownList_code_no");
        //cmb.SelectedValue = gvResult.Rows[index].Cells[1].Text.ToString();
      
        this.bindDept4Edit();
        cmb1stDept4Edit.SelectedValue = cmb1stDept.SelectedValue;
        cmb_uc_org4Edit.SelectedValue = gvResult.Rows[index].Cells[0].Text.ToString();

        UcDDLMember.Orgcode = strOrgCode;
        UcDDLMember.DepartId = cmb_uc_org4Edit.SelectedValue;
        UcDDLMember.SelectedValue = gvResult.Rows[index].Cells[2].Text.ToString();

   //     txtIDCard4Edit.Text = gvResult.Rows[index].Cells[2].Text.ToString();
   //     getUserName2();

        showhideModifyControls(false);

        string strDepartID = cmb_uc_org4Edit.SelectedValue;
        string employee_type = gvResult.Rows[index].Cells[1].Text.ToString();

        EMP3102 emp3112 = new EMP3102();
        DataTable dt;
        //用員工編號查 EMP_ESHARE_SYS_PROF
        dt = emp3112.querySelectSystem_3(cmb1stDept4Edit.SelectedValue,
         strDepartID,
         UcDDLMember.SelectedValue
         , "Y");

        if ( dt.Rows.Count == 0)
        {
            //用類別查 EMP_ISHARE_SYS_PROF
            dt = emp3112.querySelectSystem_2(cmb1stDept4Edit.SelectedValue,
             strDepartID,
             employee_type
             , "Y");
        }

        lstSelect.Items.Clear();
        lstSelect.DataSource = dt;
        lstSelect.DataValueField = "SYSTEM_CODE";
        lstSelect.DataTextField = "SYSTEM_NAME";
        lstSelect.DataBind();


        //左邊存在的要移除右邊list
        DataTable dtall;
        dtall = emp3112.querySelectSystem_3(cmb1stDept4Edit.SelectedValue,
        strDepartID,
        UcDDLMember.SelectedValue
        , "N");
        if (dtall.Rows.Count == 0)
        {
            //用類別查 EMP_ISHARE_SYS_PROF
            dtall = emp3112.querySelectSystem_2(cmb1stDept4Edit.SelectedValue,
             strDepartID,
             employee_type
             , "N");
        }
        lstUnSelect.Items.Clear();
        lstUnSelect.DataSource = dtall;
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataBind();


  /*      // 取得資料    
        EMP3103 emp3112 = new EMP3103();
        string strDepartID = cmb_uc_org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        string strIDCard = UcDDLMember.SelectedValue;
        DataTable dt = emp3112.querySelectSystem(this.strOrgCode,
            strDepartID,
            strShareID
            , "N"
            , strIDCard);
        lstUnSelect.DataSource = dt;
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataBind();
        dt = emp3112.querySelectSystem(this.strOrgCode,
             strDepartID,
             strShareID
             , "Y", strIDCard);
        lstSelect.DataSource = dt;
        lstSelect.DataValueField = "SYSTEM_CODE";
        lstSelect.DataTextField = "SYSTEM_NAME";
        lstSelect.DataBind();
        */

        //        lblID.Text = gvResult.Rows[index].Cells[4].Text;
    }

    private void showhideModifyControls(bool bShow)
    {
        DropDownList cmb = (DropDownList)cmb_uc_idtype4Edit.FindControl("DropDownList_code_no");
        cmb.Enabled = bShow;

        cmb = (DropDownList)cmb_uc_org4Edit.FindControl("ddlDepart");
        // 取得 PArentID
        cmb.Enabled = bShow;

        cmb = (DropDownList)cmb_uc_org4Edit.FindControl("ddlSubDepart");
        cmb.Enabled = bShow;

        cmb = (DropDownList)UcDDLMember.FindControl("ddlMember");
        cmb.Enabled = bShow;
    }

 
    protected void add_submit_Click(object sender, EventArgs e)
    {
        // 檢查
        string strMsg = "";
        // 1. 是否有選單位
        if (cmb_uc_org4Edit.SelectedValue == "")
        {
            strMsg += "請選擇單位";
        }
        if (lstSelect.Items.Count == 0)
        {
            if (strMsg != "") strMsg += ", ";
            strMsg += "請選擇應用系統";
        }
     
  /*      if (txtIDCard4Edit.Text.Trim() == "")
        {
            if (strMsg != "") strMsg += ", ";
            strMsg += "請輸入員工編號";
        }
  */
        if (strMsg != "")
        {
            Page tempPageerr = this.Page;
            CommonFun.MsgShow(ref tempPageerr,
               CommonFun.Msg.Custom, strMsg, "", "");
            this.Page = tempPageerr;
            return;
        }

   /*     string strAPName = lblUserName2.Text.Trim();
        if (strAPName == "")
        {
            Page tempPage2 = this.Page;
            CommonFun.MsgShow(ref tempPage2,
               CommonFun.Msg.Custom, txtIDCard4Edit.Text.Trim() + " 不是正確的員工編號", "", "");
            this.Page = tempPage2;

            return;
        }
       */
        EMP3103 emp3103 = new EMP3103();
        // 參數
        string strDepartID = cmb_uc_org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        DataTable dt = emp3103.queryEMPEshareSysProfFull(this.strOrgCode, strDepartID, strShareID,UcDDLMember.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            Page tempPage3 = this.Page;
            CommonFun.MsgShow(ref tempPage3,
               CommonFun.Msg.Custom, "已存在資料，請使用維護功能", "", "");
            this.Page = tempPage3;
            return;
        }



        doInsert();

        pnlModify.Visible = false;
        pnlConditions.Visible = true;

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = tempPage;
    }

    private void doDelete()
    {         
        EMP3103 emp3103 = new EMP3103();
        // 參數
        string strDepartID = cmb_uc_org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        string strIDCard = UcDDLMember.SelectedValue;// txtIDCard4Edit.Text.Trim();
        emp3103.deleteEMPEshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID,
                strIDCard
            ); 
    }

    private void doInsert()
    {
        // 
        EMP3103 emp3103 = new EMP3103();
        // 參數
        string strDepartID = cmb_uc_org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        string strIDCard = UcDDLMember.SelectedValue;//txtIDCard4Edit.Text.Trim();

        for (int i = 0; i < lstSelect.Items.Count; i++)
        {
            string strSystemCode = lstSelect.Items[i].Value;

            emp3103.insertEMPEshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID,
                strSystemCode,
                this.strLoginUserID
                , strIDCard
                );
        }
    }
    protected void edit_submit_Click(object sender, EventArgs e)
    {
        doDelete();
        doInsert();

    
      

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = tempPage;

        pnlModify.Visible = false;
        pnlresult.Visible = true;
        pnlConditions.Visible = true; 
        this.doQueryData();
    }

    private void showhidecol(bool bshow)
    {
        gvResult.Columns[0].Visible = bshow;
        gvResult.Columns[1].Visible = bshow;
        gvResult.Columns[2].Visible = bshow;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Response.Write("lblSN"+lblSN.Text+"<BR>");
        EMP3103 emp3103 = new EMP3103();
        // 參數
        int index = Convert.ToInt16(lblSN.Text);
        string strDepartID = gvResult.Rows[index].Cells[0].Text.ToString();
        string strShareID = gvResult.Rows[index].Cells[1].Text.ToString();
        string strIDCard = gvResult.Rows[index].Cells[2].Text.ToString();
        emp3103.deleteEMPEshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID,
                strIDCard
            );      

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "已刪除", "", "");
        this.Page = tempPage;

        this.doQueryData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlConditions.Visible = true;
        pnlModify.Visible = false;
     
        if (mode.Text == "EDIT")
        {
            pnlresult.Visible = true;
        }
        else
        {
            pnlresult.Visible = false;
        }

    }
    //匯出報表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        EMP3103 emp3103 = new EMP3103();
        string strDepartID = cmb_uc_org.SelectedValue;
        string strShareID = cmb_uc_idtype.SelectedValue;
        string strIDCard = txtIDCard.Text;

        DataTable dt = emp3103.queryEMPEshareSysProfFull(
            this.strOrgCode,
            strDepartID,
            strShareID,
            strIDCard);

        // 匯出動作
        CommonLib.DTReport rpt;
        rpt = new CommonLib.DTReport(Server.MapPath("~/Report/EMP/EMP3103.mht"), dt);
        rpt.ExportFileName = "共用系統權限設定清單-依員工編號";

        // 參數部分
        string[] strParams = new string[1];
        strParams[0] = "";

        rpt.Param = strParams;
        rpt.ExportToExcel();
    }
    protected void cmb1stDept4Edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.bindDept4Edit();
        lstSelect.Items.Clear();  
    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
        this.showhidecol(true);
    }
    protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }


    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        this.showhidecol(false);

    }

    public void bindDept4Edit()
    {
        cmb_uc_org4Edit.Orgcode = cmb1stDept4Edit.SelectedValue;
    }
    protected void cmb1stDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.bindDept();
    }
    protected void btnGetUserName_Click(object sender, EventArgs e)
    {
        getUserName();
    }

    private void getUserName()
    {
        EMP3103 emp3103 = new EMP3103();
        lblUserName.Text = emp3103.getUserName(txtIDCard.Text.Trim());
    }
    protected void btnGetUserName2_Click(object sender, EventArgs e)
    {
        getUserName2();
    }

    private void getUserName2()
    {
        if (cmb_uc_org4Edit.SelectedValue == "" || cmb_uc_idtype4Edit.SelectedValue=="ALL")
        {
            lblUserName2.Text = "";
        }
        EMP3103 emp3103 = new EMP3103();
        lblUserName2.Text = emp3103.getUserName(
            cmb1stDept4Edit.SelectedValue,
            cmb_uc_org4Edit.SelectedValue,
            cmb_uc_idtype4Edit.SelectedValue,

            UcDDLMember.SelectedValue//txtIDCard4Edit.Text.Trim()
            );
    }
}