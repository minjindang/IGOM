using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;
using EMPPLM.Logic;
using FSCPLM.Logic;
using System.Collections;
using System.IO;
using System.Configuration;
using System.DirectoryServices;
using System.Transactions;
//using System.DirectoryServices.AccountManagement;

public partial class EMP_EMP3_EMP3105_01 : BaseWebForm
{

    // 登入者機關代碼
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    string strLoginUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
    string strRoldID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);

    const string strPersonnel = "Personnel";
    const string strunit_window = "unit_window";


    protected void Page_Load(object sender, EventArgs e)
    {
        cmbDepartID.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(cmbDepart2_changed);
             
        Session["Orgcode"] = strOrgCode;

        if (Page.IsPostBack) return;

        cmbDepartID.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        Name_Bind();
        Title_Bind();
        getSysLeaveKind();
        //bindSysRole();
        EmployeeType_Bind();
        //
        showHideRoleControls(strRoldID);
    }

    protected void EmployeeType_Bind()
    {
        ddlPEMEMCOD.DataSource = new SYS.Logic.CODE().GetData("023", "022");
        ddlPEMEMCOD.DataBind();
        ddlPEMEMCOD.Items.Insert(0, new ListItem("---請選擇---", ""));
    }

  

    //private void bindSysRole()
    //{
    //    EMP3105 emp3105 = new EMP3105();
    //    DataTable dt = emp3105.getSysRole(this.strOrgCode, "", "", "", "", "N");
    //    cblRoleName.DataSource = dt;
    //    cblRoleName.DataTextField = "ROLE_NAME";
    //    cblRoleName.DataValueField = "ROLE_ID";
    //    cblRoleName.DataBind();
    //}


    private void showHideRoleControls(string strRoleID)
    {
        bool bPersonnel = strRoleID.Contains(strPersonnel);
        //        Response.Write(bPersonnel.ToString());
        bool bUnit = strRoleID.Contains(strunit_window);
        btnAdd.Visible = bPersonnel;

        txtId_card.Enabled = bPersonnel;
        //txtPersonnel_id.Enabled = bPersonnel;

        txtADID4Edit.Enabled = bPersonnel;

        cmbBossLevelID.Enabled = bPersonnel;

        txtUser_Name.Enabled = bPersonnel;
        txtUser_password.Enabled = bPersonnel;
        //txtEmail.Enabled = bPersonnel;
        //        cmbTitleNo4Edit.Enabled = bPersonnel;
        DropDownList cmb = (DropDownList)cmbTitleNo4Edit.FindControl("DropDownList_code_no");
        cmb.Enabled = bPersonnel;


        ddlPEKIND.Enabled = bPersonnel;
        //        cmbShiftType4Edit.Enabled = bPersonnel;
        RadioButtonList rbl = (RadioButtonList)cmbShiftType4Edit.FindControl("RadioButton_Code_no");
        rbl.Enabled = bPersonnel;
        
        rblPESEX.Enabled = bPersonnel;
        //        ddlPECRKCOD.Enabled = bPersonnel;
        cmb = (DropDownList)ddlPECRKCOD.FindControl("DropDownList_code_no");
        cmb.Enabled = bPersonnel;
        //        ddlPEMEMCOD.Enabled = bPersonnel;
        //cmb = (DropDownList)ddlPEMEMCOD.FindControl("DropDownList_code_no");
        cmb = ddlPEMEMCOD;
        cmb.Enabled = bPersonnel;
        txtPEPROFESS.Enabled = bPersonnel;
        txtPECHIEF.Enabled = bPersonnel;
        ddlPEYKIND.Enabled = bPersonnel;

        txtPEACTDATE.Enabled = bPersonnel;
        UcJoinDate.Enabled = bPersonnel;
        txtPELEVDATE.Enabled = bPersonnel;
        ddlLoginType.Enabled = bPersonnel;
        txtPEHDAY2.Enabled = bPersonnel;
        txtPEHDAY3.Enabled = bPersonnel;
        txtPEHDAY.Enabled = bPersonnel;

        cbCount.Enabled = bPersonnel;
        //        cbYear.Enabled = bPersonnel;
        txtPerday1.Enabled = bPersonnel;
        txtPerday2.Enabled = bPersonnel;


        //cblRoleName.Enabled = bPersonnel;
        txtPEHDAY.Enabled = bPersonnel;

        txtIntro_desc.Enabled = !bUnit;
        txtSkill_desc.Enabled = !bUnit;
        txtSpecialty_desc.Enabled = !bUnit;
        txtMood_desc.Enabled = !bUnit;
        FileUpload1.Enabled = !bUnit;
        Button1.Enabled = !bUnit;


        if (!bPersonnel && !bUnit)
        {
            UcPersonal_id.PersonnelId = this.strLoginUserID;
            TextBox txt = (TextBox)UcPersonal_id.FindControl("tbPersonnelId");
            txt.Enabled = bPersonnel;
        }

        if (!bPersonnel && bUnit)
        {
            // 單位管理
        }
    }


    protected void cmbSubDepart4Edit_changed(object sender, EventArgs e)
    {
        //        hfDepartID.Value = cmbSubDepart4Edit.OrgCode;
    }


    protected void cmbDepart4Edit_changed(object sender, EventArgs e)
    {
        /*
        cmbSubDepart4Edit.ParentId = cmbDepart4Edit.OrgCode;
        cmbSubDepart4Edit.Rebind();
        tr8.Visible = (cmbDepart4Edit.OrgCode != "" && cmbDepart4Edit.OrgCode != "ALL");
        //        cmbDepart2.Visible = (cmbDepart1.OrgCode != "ALL");
         * */
    }


    protected void cmbDepart1_changed(object sender, EventArgs e)
    {/*
        cmbDepart2.ParentId = cmbDepart1.OrgCode;
        cmbDepart2.Rebind();
        //        cmbDepart2.Visible = (cmbDepart1.OrgCode != "ALL");
      * */
    }
    protected void cmbDepart2_changed(object sender, EventArgs e)
    {
        Name_Bind();
    }
    
    protected void Name_Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        //Response.Write(DateTime.Now.ToString()+" : "+ Orgcode+"<BR>");

        string Role_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);
        //Response.Write(DateTime.Now.ToString() + " : " + Role_id + "<BR>");

        Emp_Member empMember = new Emp_Member();
        //DataTable dt = empMember.queryEmpMember("", cmbDepartID.SelectedValue);
        DataTable dt = new FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, cmbDepartID.SelectedValue);

        //        ddlName.DataSource = new FSCPLM.Logic.Member().GetDLLDataByODS(Orgcode, cmbDepart1.OrgCode, Role_id, cmbDepart2.OrgCode, "", "", "");
        //ddlName.DataSource = dt;
        //ddlName.DataValueField = "ID_CARD";
        //ddlName.DataTextField = "full_name";

        //ddlName.DataBind();
        //ddlName.Items.Insert(0, new ListItem("請選擇", ""));

        ddlName.Orgcode = Orgcode;
        ddlName.DepartId = cmbDepartID.SelectedValue ;

        upnlUserName.Update();
    }


    protected void Title_Bind()
    {
        //若登入者的角色為人事管理員,則目前職稱顯示要多加個條件plmdb.. Detail_code. Db_flag=’1’,
        //若登入的角色為庶務管理員,在顯示目前職稱的下拉式選單增加的判斷為plmdb.. Detail_code. Db_flag=’2’
        //若登入角色為系統管理員在顯示目前職稱的下拉式選單增加的判斷為plmdb.. Detail_code. Db_flag in(‘1’,’2’)
        string Db_flag = "";
        string RoleId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);

        //Personnel  人事管理員  
        if (RoleId == "Personnel")
        {
            Db_flag = "1";
        }
        else if (RoleId == "TWDAdmin" | RoleId == "GenServAdmin")
        {
            //TWDAdmin  庶務管理員、庶務管理員(正) 
            Db_flag = "2";
        }

        /*
        //職稱
        ddlTitleNo.DataSource = new DetailCode().GetDetailCodeBymcIDDbFlag("1012", Db_flag);
        ddlTitleNo.DataBind();
        ddlTitleNo.Items.Insert(0, new ListItem("請選擇", ""));
         */
    }

    protected void gvddlOrgcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((DropDownList)sender).NamingContainer;

     //   UpdatePanel panel = (UpdatePanel)gvr.FindControl("UpdatePanel1");
        DropDownList gvddlOrgcode = (DropDownList)gvr.FindControl("gvddlOrgcode");
        Label lb3 = (Label)gvr.FindControl("Label3");
        lb3.Text = gvddlOrgcode.SelectedValue;

        UControl_UcDDLDepart gvDeaprtId = (UControl_UcDDLDepart)gvr.FindControl("ddlgvDeaprtId");
        gvDeaprtId.Orgcode =  gvddlOrgcode.SelectedValue;

        UControl_UcDDLDepart gvBossDeaprtId = (UControl_UcDDLDepart)gvr.FindControl("ddlgvBossDeaprtId");
        gvBossDeaprtId.Orgcode = gvddlOrgcode.SelectedValue;

        GvBoss_Bind(gvr, gvBossDeaprtId);
    }




    protected void gvddlDepartID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void doDelete(object sender, EventArgs e)
    {
        Button btnDel = (Button)sender;
        DataControlFieldCell cell = (DataControlFieldCell)btnDel.Parent;
        GridViewRow row = (GridViewRow)cell.Parent;
        int index = row.RowIndex;

        DataTable dt = GvToDt();
        dt.Rows.RemoveAt(index);
        ViewState["gvListData"] = dt;

        this.gvList.DataSource = (DataTable)ViewState["gvListData"];
        this.gvList.DataBind();
    }

    // 刪除資料
    protected void btnDel_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;

        //        string org = ((Label)gvr.FindControl("lbOrgcode")).Text.Trim();
        //        string card = ((Label)gvr.FindControl("lbPersonnel_id")).Text.Trim();
        string idno = ((Label)gvr.FindControl("lblIdCard")).Text.Trim();

        EMP3105 emp3105 = new EMP3105();
        emp3105.deleteEMPMemberNonMember(idno);

        ShowGridView();
        /*
        using (Transactions.TransactionScope trans = new Transactions.TransactionScope())
        {
            //hfPerson_type='2'為刪舊帳號,反之則刪新帳號
            try
            {
                if (hfPerson_type.Value.Equals("2"))
                {
                    FSCPLM.Logic.OldMember oldm = new FSCPLM.Logic.OldMember();
                    oldm.DeletePersonId(org, card);
                }
                else
                {
                    FSCPLM.Logic.CPAPE05M pe05m = new FSCPLM.Logic.CPAPE05M();
                    pe05m.delete(org, card, idno);

                    FSCPLM.Logic.Member m = new FSCPLM.Logic.Member();
                    m.DeleteIdcard(org, idno);
                }
                trans.Complete();

                CommonFun.MsgShow(this.Page, CommonFun.Msg.DeleteOK);

            }
            catch (Exception ex)
            {
                CommonFun.MsgShow(this.Page, CommonFun.Msg.DeleteFail);
            }

        }

        ShowGridView();
         * */
        //


    }

    private void getSysLeaveKind()
    {
        EMP3105 emp3105 = new EMP3105();
        DataTable dt = emp3105.querySysLeaveKind(this.strOrgCode);
        ddlPEKIND.DataSource = dt;
        ddlPEKIND.DataTextField = "KIND_NAME";
        ddlPEKIND.DataValueField = "LEAVE_KIND";
        ddlPEKIND.DataBind();
        ddlPEKIND.Items.Insert(0, new ListItem("請選擇", ""));
    }


    protected void cbCount_Click(object sender, EventArgs e)
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string id_card = txtPersonnel_id.Text.Trim();

        //設定休假天數
        string PEMEMCOD = ddlPEMEMCOD.SelectedValue;
        string PEKIND = ddlPEKIND.SelectedValue;
        string PEHYEAR = "0";
        string PEHDAY = "0";
        string PEHMONTH = "0";
        int cntYear = 0;
        //總休假年資 - 年
        int cntMonth = 0;
        //總休假年資 - 月
        string Join_sdate = UcJoinDate.Text;
        string Elected_officials_flag = "N";// ddlElected_officials_flag.SelectedValue;


        if (string.IsNullOrEmpty(PEMEMCOD) || string.IsNullOrEmpty(PEKIND) || string.IsNullOrEmpty(Join_sdate))
        {
            //Response.Write("QUIT");
            return;
        }


        //取 PEHYEAR, PEDAY
        LeaveYearDay ht = CntLeave.GetCntYearsDays(Orgcode, id_card, Join_sdate, Elected_officials_flag, PEKIND, PEMEMCOD);

        if (ht != null)
        {
            PEHYEAR = ht.Year.ToString();
            PEHDAY = ht.Day.ToString();
        }

        txtPEHYEAR.Text = PEHYEAR;
        txtPEHDAY.Text = PEHDAY;
        lbYear.Text = PEHYEAR;
    }



    protected DataTable getDataTable()
    {
        //        try
        //        {
        string orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        //機構代碼
        string departid = cmbDepartID.SelectedValue;
        //        string subdepid = cmbDepart2.OrgCode;
        string idcard = ddlName.SelectedValue;
        string username = txtUserName.Text.Trim();
        string personnelid = UcPersonal_id.PersonnelId.Trim();
        string Pememcod_id = ddlPememcodID.SelectedValue;
        string TitleNo = ddlTitleNo.SelectedValue;
        /*
                string OldpersonnelId = UcOldPersonal_id.PersonnelId.Trim();
                hfPerson_type.Value = "2";
                //1代表查詢非舊員工編號,2代表查詢舊員工編號

                if (!string.IsNullOrEmpty(personnelid) & !string.IsNullOrEmpty(OldpersonnelId))
                {
                    Page tempPage2 = this.Page;
                    CommonFun.MsgShow(ref tempPage2,
                       CommonFun.Msg.Custom, "員工編號與舊員工編號請擇一查詢", "", "");
                    this.Page = tempPage2;

                    return null;
                }
                if (string.IsNullOrEmpty(OldpersonnelId))
                {
                    hfPerson_type.Value = "1";
                }
                else
                {
                    personnelid = OldpersonnelId;
                }
         */

        EMP3105 emp3105 = new EMP3105();
        DataTable dt = emp3105.queryData(
            orgcode, departid, username, Pememcod_id, personnelid, idcard, ddQuit_Job.SelectedValue, TitleNo
            );
    
           

    /*    // EMP_STAFFINTRO_MAIN 相關欄位
        dt.Columns.Add("BIRTH_DATE");
        dt.Columns.Add("INTRO_DESC");
        dt.Columns.Add("SKILL_DESC");
        dt.Columns.Add("SPECIALTY_DESC");
        dt.Columns.Add("PICFILE_PATH");
        dt.Columns.Add("MOOD_DESC");

        for (int i = 0; i < dt.Rows.Count; i++)
        {     
           
            // EMP_STAFFINTRO_MAIN
            DataTable dtEmpStaffIntroMain = emp3105.queryEmpStaffIntroMain(dt.Rows[i]["ID_CARD"].ToString());
            if (dtEmpStaffIntroMain.Rows.Count > 0)
            {
                if (!Convert.IsDBNull(dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"]))
                {
                    dt.Rows[i]["BIRTH_DATE"] = dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"].ToString();
                    //                            ConvertDate2ROCDateString(Convert.ToDateTime(dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"]));
                }
                dt.Rows[i]["INTRO_DESC"] = dtEmpStaffIntroMain.Rows[0]["INTRO_DESC"].ToString();
                dt.Rows[i]["SKILL_DESC"] = dtEmpStaffIntroMain.Rows[0]["SKILL_DESC"].ToString();
                dt.Rows[i]["SPECIALTY_DESC"] = dtEmpStaffIntroMain.Rows[0]["SPECIALTY_DESC"].ToString();
                dt.Rows[i]["MOOD_DESC"] = dtEmpStaffIntroMain.Rows[0]["MOOD_DESC"].ToString();
                dt.Rows[i]["PICFILE_PATH"] = dtEmpStaffIntroMain.Rows[0]["PICFILE_PATH"].ToString();
            }
        }

        */
        return dt;

        /*
        FSC3401 fsc3401 = new FSC3401();
        DataTable dt = null;


        string Id_card = string.Empty;
        string name = string.Empty;
        if (!string.IsNullOrEmpty(ddlName.SelectedValue))
        {
            Id_card = ddlName.SelectedValue.Split('/')[0];
            name = new FSCPLM.Logic.Member().GetColumnValue("User_name", Id_card).ToString();
        }

        string Quit_job_flag = ddQuit_Job.SelectedValue;
        //IIf(cbxQuit_job.Checked, "Y", "N")

        dt = fsc3401.getQueryData(orgcode, departid, subdepid, idcard, username, personnelid, Quit_job_flag, Pememcod_id, TitleNo, hfPerson_type.Value);
        foreach (DataRow dr in dt.Rows)
        {
            string role_Name = "";
            foreach (string role_id in dr["role_id"].ToString().Split('、'))
            {
                if (role_Name.Length > 0)
                {
                    role_Name += "、";
                }
                DataTable dtRL = new RoleDAO(new System.Data.SqlClient.SqlConnection(ConnectDB.GetDBString())).Get_Role(orgcode, role_id);
                if (dtRL != null && dtRL.Rows.Count > 0)
                {
                    role_Name += dtRL.Rows[0]["Role_name"].ToString();
                }
            }
            dr["RoleName"] = role_Name;
        }
        tbQ.Visible = true;
        return dt;
         * */

        //       }
        //       catch (Exception ex)
        //       {
        //           AppException.ShowError_ByPage(ex);
        //      }

        //       return null;
    }

    //主管層級
    public string getBossLevelName(string input)
    {
        EMP3105 emp3105 = new EMP3105();
        return emp3105.getBOSS_LEVEL_Name(input);
    }

    //機關名稱
    public string getOrgName(string input)
    {
        return EMPCommon.getOrgName(input);
    }

    //單位名稱
    public string getDepartName(string input)
    {
        EMP3102DAO emp3102dao = new EMP3102DAO();
        string strDepartName = emp3102dao.getDeptNameByDepartID(strOrgCode, input);
        if (strDepartName != "")
        {
           return strDepartName;
        }
        else
        {
           return "";
        }
    }

    //職稱
    public string getTitle_name(string input)
    {
        return SALARY.Logic.app.GetSaCode_Desc1("023", "012", input);             
    }

    //人員類別
    public string getEMPLOYEEname(string input)
    {
        string strEmployeeTypeName = SALARY.Logic.app.GetSaCode_Desc1("023", "022", input );

        if (strEmployeeTypeName != "")
        {
            return strEmployeeTypeName;
        }
        else
        {
            return "";
        }
    }

    //角色
    public string getRoleName(string input,string input2)
    {
        string[] strRoles = input.Split(',');
        string strRoleNames = "";
        for (int j = 0; j < strRoles.Length; j++)
        {
            if (strRoleNames != "") strRoleNames += ",";

            DataTable dtRole = new SYS.Logic.Role().GetRole(input2, strRoles[j]);
            if (dtRole != null && dtRole.Rows.Count > 0)
                strRoleNames += dtRole.Rows[0]["Role_Name"].ToString();
        }
        return strRoleNames;
    }

    //直屬主管
    public string getBossName(string input )
    {
        EMP3103 emp3103 = new EMP3103();
        string strBossName = emp3103.getUserName(input);
        return strBossName;
    }


    public void ShowGridView()
    {
        //        try
        //        {
        this.gvResult.DataSource = getDataTable();
        this.gvResult.DataBind();
        if (gvResult.Rows.Count > 0)
        {
            Ucpager1.Visible = true;
        }
        else
        {
            Ucpager1.Visible = false;
        }

        ViewState["DataTable"] = this.gvResult.DataSource;
        //將資料暫存起來，做為資料的跳頁等顯示
        if ((this.gvList.Rows != null) && this.gvList.Rows.Count > 0)
        {
            btnExport.Enabled = true;
        }
        this.gvList.Dispose();

        //        }
        //        catch (Exception ex)
        //        {
        //            Page tempPage2 = this.Page;
        //            CommonFun.MsgShow(ref tempPage2,
        //               CommonFun.Msg.SystemError ,"","","");
        //            this.Page = tempPage2;

        //            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        //        }

    }
    /// <summary>
    /// 查詢按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ShowGridView();

        this.pnlQueryEdit.Visible = true; // 查詢條件隱藏
        this.pnlQuery.Visible = true;//查詢結果隱藏
        this.pnlEdit.Visible = false;// 資料區塊
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (this.hfMode.Value == "Edit")
        {
            if (doUpdateData())
            {
                // 正式上線時再取消
                // this.modifyADUser();
                pnlEdit.Visible = false;
                pnlQuery.Visible = true;
                pnlQueryEdit.Visible = true;
                this.hfMode.Value = "";

            }

        }
        else
        {
            if (doInsertDate())
            {
                // 正式上線時再取消
                //this.createADUSer();
                pnlEdit.Visible = false;
                pnlQuery.Visible = false;
                pnlQueryEdit.Visible = true;
                this.hfMode.Value = "";
            }

        }


    }

    private bool doUpdateData()
    {
        if (!checkFields()) return false;
        // 檢查資料

        if (!chkEmpDepartEmp()) return false;

        // 參數
        ///        string strIdCard    =txtPersonnel_id.Text.Trim();
        ///         
        EMP3105 emp3105 = new EMP3105();

        string strIdCard = txtPersonnel_id.Text.Trim();    // 員工編號
        string strAdId = txtADID4Edit.Text.Trim();   // AD帳號
        string strUserName = txtUser_Name.Text.Trim();  // 人員姓名
        string strEmail = txtEmail.Text.Trim();      // 電子郵件
        string strEmployeeType = ddlPEMEMCOD.SelectedValue.Trim();  // 職務類別
        string strTitlnNo = cmbTitleNo4Edit.SelectedValue.Trim();   // 目前職稱
        string strBossLevelID = "";
        try
        {
            strBossLevelID = cmbBossLevelID.SelectedValue;           // 主管層級?
        }
        catch { }
        //        string strActDate = EMP3105.convertROCDate2DateString(txtPEACTDATE.Text); // 到職日
        //        string strFirstGovDate = EMP3105.convertROCDate2DateString(UcJoinDate.Text);    // 初任公職日
        //        string strLeftDate = EMP3105.convertROCDate2DateString(txtPELEVDATE.Text);  //離職日期
        string strActDate = txtPEACTDATE.Text.Trim(); // 到職日
        string strFirstGovDate = UcJoinDate.Text.Trim();    // 初任公職日
        string strLeftDate = txtPELEVDATE.Text.Trim();  //離職日期
        if (strLeftDate == "0000000") strLeftDate = "";

        string strLivePhone = txtLivePhone4Edit.Text.Trim();    // 直撥電話 
        string strPhone = txtOffice_tel.Text.Trim();            // 辦公室電話 
        string strExt = txtOffice_ext.Text.Trim();              // 分機
        string strDeleteFlag = "N";
        string strQuitJobFlag = "N";
        if (txtPELEVDATE.Text.Trim() != "") strQuitJobFlag = "Y";
        string strChangeUserID = this.strLoginUserID;
        string strIDNumber = txtId_card.Text.ToUpper();  // 身分證號
        string strGender = rblPESEX.SelectedValue;      // 性別
        string strPassword = txtUser_password.Text;// 密碼

        // FSC_Personnel
        string strPeKind = ddlPEKIND.SelectedValue;      // 差勤組別
        string strLevel = ddlPECRKCOD.SelectedValue;    // 職等
        string strLeaveYrAdd = lbChgYear.Text;          // 異動年資
        string strLeaveYrBDate = lbYearStartDate.Text;  // 休假年資計算起日
        string strShiftType = cmbShiftType4Edit.SelectedValue;  // 上班別
        string strPehYear = lbYear.Text;    // 休假年資
        string strPehDay = txtPEHDAY.Text;  // 本年休假天數
        string strPehDay2 = txtPEHDAY2.Text;  // 事假天數
        string strPehDay3 = txtPEHDAY3.Text;  // 病假天數
        string strPerday1 = txtPerday1.Text;    // 前一年保留天數
        string strPerday2 = txtPerday2.Text;    // 前兩年保留天數
        string strPePoint = txtPEPOINT.Text;//俸點
        string strPeProFess = txtPEPROFESS.Text.Trim();//專業加給
        string strPeChief = txtPECHIEF.Text.Trim();// 主管職務加給
        string strPeyKind = ddlPEYKIND.SelectedValue;  // 年制別
        string strLoginType = ddlLoginType.SelectedValue;// 登入類型
        // 事假天數
        // 留職停薪年資
        // 休假總年資
        string strRoleID = hfRole.Value;  // 角色
        //for (int i = 0; i <= cblRoleName.Items.Count - 1; i++)
        //{
        //    if (cblRoleName.Items[i].Selected)
        //    {
        //        if (strRoleID != "") strRoleID += ",";
        //        strRoleID += cblRoleName.Items[i].Value;
        //    }
        //}
        string strYoyoCard = txtYoyoCard4Edit.Text.Trim(); ;//悠遊卡


        // EMP_STAFFINTRO_MAIN
        //        string strBirthDate = EMP3105.convertROCDate2DateString(txtPEBIRTHD.Text);  // 出生年月日
        string strBirthDate = txtPEBIRTHD.Text.Trim();  // 出生年月日
        string strIntroDesc = txtIntro_desc.Text.Trim();                            // 自述
        string strSkillDesc = txtSkill_desc.Text.Trim();                            // 專長
        string strSpecialtyDesc = txtSpecialty_desc.Text.Trim();                    // 興趣
        string strMoodDesc = txtMood_desc.Text.Trim();                              // 心情感言
        string strPicfilePath = txtPicFile_path.Text.Trim();

        string strActDateO = txtPEACTDATE.Text;
        string strFirstGovDateO = UcJoinDate.Text;
        string strLeftDateO = txtPELEVDATE.Text;

        // 是否可使用人員切換
        string strSysloginFlag = rblSyslogin.SelectedValue;
        // 是否為值班人員
        string strOnDuty = rbOnDuty.SelectedValue;
        // 是否可跨處室設定代理人
        string strMutiDepartDeputy_flag = rblMutiDepartDeputy_flag.SelectedValue;
        // 服務年資
        string strServiceyear = txtServiceYear.Text.Trim();

        string strYoyoCard_Change_flag = hfOldYoyoCard.Value.Equals(txtYoyoCard4Edit.Text.Trim()) ? "0" : "1";

        if (strEmployeeType == "13" || strEmployeeType == "14" || strEmployeeType == "15")
        {
            // 非員工
            emp3105.UpdateEmpNonMember(
                 strIdCard,
                 strAdId,
                 strUserName,
                 strEmail,
                 strEmployeeType,
                 strActDate,
                 strLeftDate,
                 strPhone,
                 strExt,
                 strChangeUserID,
                 strIDNumber,
                 strGender,
                 strYoyoCard,
                 strServiceyear
                );
        }
        else
        {
            // 員工 1~XX
            emp3105.updaeEmpMember(
                 strIdCard,
                 strAdId,
                 strUserName,
                 strEmail,
                 strEmployeeType,
                 strBossLevelID,
                 strActDate,
                 strFirstGovDate,
                 strLeftDate,
                 strLivePhone,
                 strPhone,
                 strExt,
                 strDeleteFlag,
                 strQuitJobFlag,
                 strChangeUserID,
                 strIDNumber,
                 strTitlnNo,
                 strGender, 
                 strYoyoCard,
                 strServiceyear

            );

        }


        // 
        emp3105.UpdateFscPersonnel(strIdCard,
             strTitlnNo,
             strUserName,
             strEmployeeType,
             strLevel,
             strActDateO,
             strFirstGovDateO,
             strLeftDateO,
             strLeaveYrAdd,
             strLeaveYrBDate,
             strShiftType,
             strPehYear,
             strPehDay,
             strPehDay2,
             strPehDay3,
             strPeKind,
             strPerday1,
             strPerday2,
             strRoleID,
             strChangeUserID,
             strPePoint,
             strPeProFess,
             strPeChief,
             strPeyKind,
             strLoginType
             , strSysloginFlag
             , strOnDuty
             , strIDNumber
             , strGender
             , strBirthDate
             , strBossLevelID
             , strEmail
             , strAdId
             , strMutiDepartDeputy_flag
             , strServiceyear
             , strYoyoCard_Change_flag
             );

        string old_Service_dep = new FSC.Logic.DepartEmp().getServiceDep(strOrgCode, strIdCard);

        // 刪 EMP_DEPART_EMP
        emp3105.deleteEmpDepartEmp("", strIdCard, "", "", "");
        // 刪 FSC_Personnel_Boss
        emp3105.deleteFSCPERSONNELBOSS(strIdCard, "", "");

        // 新增 EMP_DEPART_EMP
        DataTable dt = GvToDt();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strGVOrgCode = dt.Rows[i]["ORGCODE"].ToString();
            string strGVDepartId = dt.Rows[i]["DEPART_ID"].ToString();
            string strGVServiceType = dt.Rows[i]["SERVICE_TYPE"].ToString();  // 預設佔缺單位
            //            string strServicesSDate = String.Format("{0:yyyy/MM/dd}", dt.Rows[i]["SERVICE_SDATE"]);
            //            string strServicesEDate = String.Format("{0:yyyy/MM/dd}", dt.Rows[i]["SERVICE_EDATE"]);
            string strServicesSDate = dt.Rows[i]["SERVICE_SDATE"].ToString();
            string strServicesEDate = dt.Rows[i]["SERVICE_EDATE"].ToString();
            string strGVBossDepartId = dt.Rows[i]["BOSS_DEPART_ID"].ToString();
            string strBossIDCard = dt.Rows[i]["BOSS_IDCARD"].ToString();
            emp3105.insertEmpDepartEmp(strGVOrgCode, strGVDepartId, strIdCard, strServicesSDate, strServicesEDate, strGVServiceType, strChangeUserID);

            // Boss
            emp3105.insertFscPersonnelBoss(strGVOrgCode, strGVDepartId, strIdCard, strGVServiceType, strGVBossDepartId, strBossIDCard, strChangeUserID);
        }

        // UpdateEmpStaffIntroMain
        //emp3105.UpdateEmpStaffIntroMain(strBirthDate, strIntroDesc, strSkillDesc, strSpecialtyDesc, strMoodDesc, strPicfilePath, strChangeUserID, strIdCard);

        string new_Service_dep = new FSC.Logic.DepartEmp().getServiceDep(strOrgCode, strIdCard);

        if (!old_Service_dep.Equals(new_Service_dep))
        {
            Personnel p = new Personnel();
            p.UpdateDepart_Change_flag(strIdCard, "1");
        }

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.UpdateOK, "", "", "");
        ShowGridView();
        this.Page = tempPage;

        return true;
    }

    private bool checkPassword()
    {
        if (string.IsNullOrEmpty(txtUser_password.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "密碼為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }
        return true;
    }

    protected bool checkFields()
    {
        if (string.IsNullOrEmpty(txtId_card.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "身分證號為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }
        else
        {
            string msg = "";
            if (txtId_card.Text.Trim().Length != 10)
                msg = "身分證號請輸入10碼";
            else if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(txtId_card.Text.Trim().Substring(0, 1).ToUpper()) < 0)
                msg = "身分證號第一碼請輸入英文";
            else if ("12".IndexOf(txtId_card.Text.Trim().Substring(1, 1)) < 0)
                msg = "身分證號第二碼必須為1或2";
            else if (!CommonFun.IsNum(txtId_card.Text.Trim().Substring(2)))
                msg = "身分證號後7碼必須為數字";

            if (!string.IsNullOrEmpty (msg))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, msg, "", "");
                this.Page = tempPage;
                return false;
            }
        }

        if (string.IsNullOrEmpty(txtADID4Edit.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "AD帳號為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        String err = CommonFun.CheckNumEng(txtADID4Edit.Text.Trim());
        if (!"".Equals(err))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "AD帳號" + err, "", "");
            this.Page = tempPage;
            return false;
        }

        //預設 AD 密碼
        txtUser_password.Text = "@AD" + txtADID4Edit.Text.Trim();

        if (!"".Equals(txtYoyoCard4Edit.Text.Trim()))
        {
            err = CommonFun.CheckNumEng(txtYoyoCard4Edit.Text.Trim());
            if (!"".Equals(err))
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "感應卡號" + err, "", "");
                this.Page = tempPage;
                return false;
            }
        }

        if (string.IsNullOrEmpty(cmbBossLevelID.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "主管層級為必填欄位", "", "");
            this.Page = tempPage;
            //            CommonFun.MsgShow(this, CommonFun.Msg.Custom, "人員姓名為必填欄位");
            return false;
        }
        if (string.IsNullOrEmpty(txtUser_Name.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "人員姓名為必填欄位", "", "");
            this.Page = tempPage;
            //            CommonFun.MsgShow(this, CommonFun.Msg.Custom, "人員姓名為必填欄位");
            return false;
        }
        /*
        if (string.IsNullOrEmpty(txtUser_password.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "密碼為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }
        /*
        if (string.IsNullOrEmpty(txtUser_password.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "密碼為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }
         * 
        if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "電子郵件為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }
        */
        if (string.IsNullOrEmpty(cmbTitleNo4Edit.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "目前職稱為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(ddlPEKIND.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "差勤組別為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(cmbShiftType4Edit.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "上班別為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(rblPESEX.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "性別為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(ddlPECRKCOD.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "官職等為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(ddlPEMEMCOD.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "職務類別為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(txtPEACTDATE.Text))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "到職日為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (string.IsNullOrEmpty(txtPEBIRTHD.Text))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "出生年月日為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        //if (string.IsNullOrEmpty(UcJoinDate.Text))
        //{
        //    Page tempPage = this.Page;
        //    CommonFun.MsgShow(ref tempPage,
        //       CommonFun.Msg.Custom, "初任公職日為必填欄位", "", "");
        //    this.Page = tempPage;
        //    return false;
        //}
        if (string.IsNullOrEmpty(ddlLoginType.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "登入類型為必填欄位", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPEPOINT.Text.Trim()) && !CommonFun.IsNum(txtPEPOINT.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "俸點請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPECHIEF.Text.Trim()) && !CommonFun.IsNum(txtPECHIEF.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "主管職務加給請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPEPROFESS.Text.Trim()) && !CommonFun.IsNum(txtPEPROFESS.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "專業加給請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPEHDAY2.Text.Trim()) && !CommonFun.IsNum(txtPEHDAY2.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "事假天數請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPEHDAY3.Text.Trim()) && !CommonFun.IsNum(txtPEHDAY3.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "病假天數請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPEHDAY.Text.Trim()) && !CommonFun.IsNum(txtPEHDAY.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "本年休假天數請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPerday1.Text.Trim()) && !CommonFun.IsNum(txtPerday1.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "前一年保留天數請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtPerday2.Text.Trim()) && !CommonFun.IsNum(txtPerday2.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "前兩年保留天數請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        if (!string.IsNullOrEmpty(txtServiceYear.Text.Trim()) && !CommonFun.IsNum(txtServiceYear.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "服務年資請輸入數字", "", "");
            this.Page = tempPage;
            return false;
        }

        return true;
    }

    private bool chkEmpDepartEmp()
    {
        DataTable dt = GvToDt();
        if (dt.Rows.Count == 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請至少輸輸入一個所屬單位", "", "");
            this.Page = tempPage;
            return false;
        }

        // 佔缺僅能一個
        int iSericeType0Count = 0;
        bool bLostDepart = false;
        bool bLostStartDate = false;
        bool bLostBossDepart = false;
        bool blostBoss = false;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["SERVICE_TYPE"].ToString() == "0")
            {
                iSericeType0Count++;
            }

            if (string.IsNullOrEmpty(dt.Rows[i]["DEPART_ID"].ToString()))
            {
                bLostDepart = true;
            }

            if (string.IsNullOrEmpty(dt.Rows[i]["SERVICE_SDATE"].ToString()))
            {
                bLostStartDate = true;
            }

            if (string.IsNullOrEmpty(dt.Rows[i]["BOSS_DEPART_ID"].ToString()))
            {
                bLostBossDepart = true;
            }

            if (string.IsNullOrEmpty(dt.Rows[i]["BOSS_IDCARD"].ToString()))
            {
                blostBoss = true;
            }
        }

        if (iSericeType0Count > 1)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "僅能有一個佔缺單位", "", "");
            this.Page = tempPage;
            return false;
        }
        if (bLostDepart)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇單位名稱", "", "");
            this.Page = tempPage;
            return false;
        }
        //if (bLostStartDate)
        //{
        //    Page tempPage = this.Page;
        //    CommonFun.MsgShow(ref tempPage,
        //       CommonFun.Msg.Custom, "請輸入服務時間(起)", "", "");
        //    this.Page = tempPage;
        //    return false;
        //}
        //if (bLostBossDepart)
        //{
        //    Page tempPage = this.Page;
        //    CommonFun.MsgShow(ref tempPage,
        //       CommonFun.Msg.Custom, "請選擇主管單位名稱", "", "");
        //    this.Page = tempPage;
        //    return false;
        //}
        //if (blostBoss)
        //{
        //    Page tempPage = this.Page;
        //    CommonFun.MsgShow(ref tempPage,
        //       CommonFun.Msg.Custom, "請輸入主管", "", "");
        //    this.Page = tempPage;
        //    return false;
        //}

        return true;



    }



    protected void cbjoin_Click(object sender, EventArgs e)
    {
        /*
        DataTable dt = GvToDt();

        DataRow newRow = dt.NewRow();

        dt.Rows.InsertAt(newRow, dt.Rows.Count + 1);

        ViewState["gvListData"] = dt;

        gvList.DataSource = dt;
        gvList.DataBind();
         * 
         */

        newEmpDepartEmp();
    }

    private void newEmpDepartEmp()
    {
        DataTable dt = GvToDt();

        DataRow newRow = dt.NewRow();
        newRow["SERVICE_SDATE"] = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd");

        dt.Rows.InsertAt(newRow, dt.Rows.Count + 1);

        ViewState["gvListData"] = dt;

        gvList.DataSource = dt;
        gvList.DataBind();
    }

    protected DataTable GvToDt()
    {
        DataTable dt = (DataTable)ViewState["gvListData"];

        //            ",ORGCODE " +
        //            ",DEPART_ID " +
        //            ",ID_CARD " +
        //            ",SERVICE_SDATE " +
        //            ",SERVICE_EDATE " +
        //            ",SERVICE_TYPE " +
        //            ",CHANGE_USERID " +
        //            ",CHANGE_DATE " +
        if (dt == null)// || dt.Rows.Count < 0)
        {
            dt = new DataTable();
            dt.Columns.Add("ORGCODE");
            dt.Columns.Add("DEPART_ID");
            dt.Columns.Add("SERVICE_TYPE"); // 服務類別
            dt.Columns.Add("SERVICE_SDATE"); // 服務開始時間
            dt.Columns.Add("SERVICE_EDATE"); // 服務結束時間
            dt.Columns.Add("BOSS_DEPART_ID");
            dt.Columns.Add("BOSS_IDCARD"); // Boss

            //            dt.Columns.Add("Sub_depart_id");
            //            dt.Columns.Add("Title_no");
            //            dt.Columns.Add("isContact");
            //            dt.Columns.Add("Position");
            ViewState["gvListData"] = dt;
            return dt;
        }

        for (int i = 0; i <= gvList.Rows.Count - 1; i++)
        {
            GridViewRow gr = gvList.Rows[i];
            DataRow dr = dt.Rows[i];
            DropDownList gvddlOrgcode = (DropDownList)gr.FindControl("gvddlOrgcode");
            UControl_UcDDLDepart gvDepart4Edit = (UControl_UcDDLDepart)gr.FindControl("ddlgvDeaprtId");
            DropDownList ddlgvServicesType = (DropDownList)gr.FindControl("ddlgvServicesType");
            UControl_UcDate gvtxtServiceSDate = (UControl_UcDate)gr.FindControl("gvtxtServiceSDate");
            UControl_UcDate gvtxtServiceEDate = (UControl_UcDate)gr.FindControl("gvtxtServiceEDate");
            //            UControl_UcMember ucgvtxtBoss = (UControl_UcMember)gr.FindControl("ucgvtxtBoss");
            UControl_UcDDLDepart gvddlBossDeaprtId = (UControl_UcDDLDepart)gr.FindControl("ddlgvBossDeaprtId");
            DropDownList cmbGvBoss = (DropDownList)gr.FindControl("cmbGvBoss");

            //            DropDownList gvddlSub_depart_id = (DropDownList)gr.FindControl("gvddlSub_depart_id");
            //            DropDownList gvddlTitleNo = (DropDownList)gr.FindControl("gvddlTitleNo");
            //            DropDownList gvddlContact = (DropDownList)gr.FindControl("gvddlContact");
            //            DropDownList gvddlPosition = (DropDownList)gr.FindControl("gvddlPosition");

            dr["Orgcode"] = gvddlOrgcode.SelectedValue;
            dr["Depart_id"] = gvDepart4Edit.SelectedValue;
            dr["SERVICE_TYPE"] = ddlgvServicesType.SelectedValue;


            dr["SERVICE_SDATE"] = gvtxtServiceSDate.Text.Trim(); //EMP3105.convertROCDate2Date(gvtxtServiceSDate.Text);
            dr["SERVICE_EDATE"] = gvtxtServiceEDate.Text.Trim(); //EMP3105.convertROCDate2Date(gvtxtServiceEDate.Text);
            dr["BOSS_DEPART_ID"] = gvddlBossDeaprtId.SelectedValue;
            dr["BOSS_IDCARD"] = cmbGvBoss.SelectedValue;
            //            dr["SERVICE_EDATE"] = gvtxtServiceEDate.Text;

            //            dr["Depart_id"] = gvddlDepartID.SelectedValue;
            //            dr["Sub_depart_id"] = gvddlSub_depart_id.SelectedValue;
            //            dr["Title_no"] = gvddlTitleNo.SelectedValue;
            //            dr["isContact"] = (gvddlContact.SelectedValue == "1" ? true : false);
            //            dr["Position"] = gvddlPosition.SelectedValue;
        }

        ViewState["gvListData"] = dt;
        return dt;
    }


    protected void bindEmpDepartEmp(string id_card)
    {
        SubDeptemp sd = new SubDeptemp();
        DataTable dt = new DataTable();

        EMP3105 emp3105 = new EMP3105();
        dt = emp3105.getEmpDepartEmp(this.strOrgCode, id_card, "", "");

        //dt = sd.GetDataByMember_id(  sd.GetDataByMember_id(id_card);
        ViewState["gvListData"] = dt;

        gvList.DataSource = dt;
        gvList.DataBind();

    }
    /// <summary>
    /// 新增按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bindEmpDepartEmp("-");
        this.hfMode.Value = "New";

        this.pnlQueryEdit.Visible = false; // 查詢條件隱藏
        this.pnlQuery.Visible = false;//查詢結果隱藏
        this.pnlEdit.Visible = true;// 資料區塊

        initInsertPanel();

        newEmpDepartEmp();
    }

    private void initInsertPanel()
    {
        txtId_card.Text = "";
        txtPersonnel_id.Text = "";
        txtADID4Edit.Text = "";
        txtUser_password.Text = "";
        cmbBossLevelID.SelectedIndex = 0;
        txtUser_Name.Text = "";
        txtEmail.Text = "";
        // 
        cmbTitleNo4Edit.Mode = "selectone";
        cmbTitleNo4Edit.Rebind();
        txtLivePhone4Edit.Text = "";
        //
        txtOffice_tel.Text = "23117722";
        txtOffice_ext.Text = "";
        cmbTitleNo4Edit.Rebind();
        txtOffice_tel.Text = "";
        // 職務類別
        try
        {
            ddlPEMEMCOD.SelectedIndex = 0;
        }
        catch
        {
        }
        // 差勤組別?
        try
        {
            ddlPEKIND.SelectedValue = "A";// dt.Rows[0]["PEKIND"].ToString();
        }
        catch
        {
        }

        // ddlPEKIND.SelectedValue = dt.Rows[0][""].ToString();
        // 上班別
        try
        {
            cmbShiftType4Edit.Rebind();
            cmbShiftType4Edit.SelectedValue = "1";
        }
        catch
        {
        }
        try
        {
            rblPESEX.SelectedIndex = 0;
        }
        catch
        {
        }
        txtPEBIRTHD.Text = "";
        // 關職等
        try
        {
//            ddlPECRKCOD.SelectedValue = "";
            ddlPECRKCOD.Mode = "selectone";
            ddlPECRKCOD.Rebind();
            ddlPECRKCOD.SelectedValue = "001";//預設到無
            
        }
        catch { }
        txtPEPOINT.Text = "";
        txtPEPROFESS.Text = "";
        txtPECHIEF.Text = "";
//        ddlPEYKIND.SelectedIndex = 0;

        txtYoyoCard4Edit.Text = "";
        hfOldYoyoCard.Value = "";



        // Edit 2014/7/4
        // Request By Chih-Li
        /*
        // 到職日
        txtPEACTDATE.Text = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString();
        // 初任公職日
        UcJoinDate.Text = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString();
         * */
        txtPEACTDATE.Text = "";
        UcJoinDate.Text = "";



        // 離職日期
        txtPELEVDATE.Text = "";
        // 登入類型?
        ddlLoginType.SelectedIndex = 0;
        // 休假年資計算起日
        lbYearStartDate.Text = "";
        // 事假天數
        txtPEHDAY2.Text = "";
        // 病假天數
        txtPEHDAY3.Text = "";
        // 休假年資
        lbYear.Text = "";
        // 本年休假天數
        txtPEHDAY.Text = "";
        // 留職停薪年資 ? 
        lbChgCntYear2.Text = "";
        // 異動年資
        lbChgYear.Text = "";
        // 休假總年資 ?
        lbTotalYear.Text = "";
        // 前一年保留天數
        txtPerday1.Text = "";
        // 前兩年保留天數
        txtPerday2.Text = "";
        // 休假天數凍結（起日）?
        // ColdDateS.Text = dt.Rows[0][""].ToString();
        // 休假天數凍結（迄日）
        // ColdDateE.Text = dt.Rows[0][""].ToString();
        // 角色
        txtServiceYear.Text = "";

        //for (int i = 0; i <= cblRoleName.Items.Count - 1; i++)
        //{

        //    if (cblRoleName.Items[i].Value == "General")
        //        cblRoleName.Items[i].Selected = true;
        //    else
        //        cblRoleName.Items[i].Selected = false;

        //}

        hfRole.Value = "General";

        // 取得相關服務資料
        bindEmpDepartEmp("-");

        // 
        txtPEBIRTHD.Text = "";
        txtIntro_desc.Text = "";
        txtSkill_desc.Text = "";
        txtSpecialty_desc.Text = "";
        txtMood_desc.Text = "";
        txtPicFile_path.Text = "";
        imgPic.ImageUrl = "";
    }



    protected void gvList_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvList.Rows)
        {
            int index = gr.RowIndex;
            DropDownList gvddlOrgcode = (DropDownList)gr.FindControl("gvddlOrgcode");
            UControl_UcDDLDepart gvddlDepartID = (UControl_UcDDLDepart)gr.FindControl("ddlgvDeaprtId");
            DropDownList ddlgvServicesType = (DropDownList)gr.FindControl("ddlgvServicesType");
            UControl_UcDate gvtxtServiceSDate = (UControl_UcDate)gr.FindControl("gvtxtServiceSDate");
            UControl_UcDate gvtxtServiceEDate = (UControl_UcDate)gr.FindControl("gvtxtServiceEDate");
            //            UControl_UcMember ucgvtxtBoss = (UControl_UcMember)gr.FindControl("ucgvtxtBoss");
            UControl_UcDDLDepart ddlgvBossDeaprtId = (UControl_UcDDLDepart)gr.FindControl("ddlgvBossDeaprtId");
            DropDownList cmbGvBoss = (DropDownList)gr.FindControl("cmbGvBoss");
            UpdatePanel upnl = (UpdatePanel)gr.FindControl("PnlGVBoss");

            //UControl_UcSelectOrg gvddlDepartCode = (UControl_UcSelectOrg) gr.FindControl("gvddlDepartCode");


            EMP3101 emp3101 = new EMP3101();
            DataTable dtDept = emp3101.get1stDeptList();
            dtDept = new FSC.Logic.Org().GetOrgcode();
            gvddlOrgcode.DataSource = dtDept;
            gvddlOrgcode.DataTextField = "ORGCODE_NAME";
            gvddlOrgcode.DataValueField = "ORGCODE";
            gvddlOrgcode.DataBind();

            gvddlDepartID.Orgcode = gvddlOrgcode.SelectedValue;
            //gvddlDepartCode.Rebind();
            //DropDownList cmb = (DropDownList)gvddlDepartCode.FindControl("ddlorg");
            //cmb.SelectedIndexChanged += new EventHandler(gvddlDepartCode_SelectedIndexChanged);

            /*
            string RoleId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);
            string Db_flag = "";
            //Personnel  人事管理員  
            if (RoleId.IndexOf("Personnel") >= 0)
            {
                Db_flag = "1";
            }
            else if (RoleId.IndexOf("TWDAdmin") >= 0 | RoleId.IndexOf("GenServAdmin") >= 0)
            {
                //TWDAdmin = 庶務管理員 , GenServAdmin = 庶務管理員(正)
                Db_flag = "2";
            }

            /*
            dt = new DetailCode().GetDetailCodeBymcIDDbFlag("1012", Db_flag);
            gvddlTitleNo.DataSource = dt;
            gvddlTitleNo.DataBind();

            bindGvddlDepartID(gvddlOrgcode, gvddlDepartID);
            bindgvddlSub_depart_id(gvddlOrgcode, gvddlDepartID, gvddlSub_depart_id);
             * */

            DataTable dt = (DataTable)ViewState["gvListData"];

            if (dt != null && dt.Rows.Count > 0)
            {
                gvddlOrgcode.SelectedValue = dt.Rows[index]["Orgcode"].ToString();
                gvddlDepartID.Orgcode = gvddlOrgcode.SelectedValue;
                gvddlDepartID.SelectedValue = dt.Rows[index]["DEPART_ID"].ToString();
                ddlgvServicesType.SelectedValue = dt.Rows[index]["SERVICE_TYPE"].ToString();
                if (!Convert.IsDBNull(dt.Rows[index]["SERVICE_SDATE"]))
                {
                    gvtxtServiceSDate.Text = dt.Rows[index]["SERVICE_SDATE"].ToString(); ;
                    //EMP3105.ConvertDate2ROCDateString(Convert.ToDateTime(dt.Rows[index]["SERVICE_SDATE"]));
                }
                if (!Convert.IsDBNull(dt.Rows[index]["SERVICE_EDATE"]))
                {

                    gvtxtServiceEDate.Text = dt.Rows[index]["SERVICE_EDATE"].ToString();
                    //EMP3105.ConvertDate2ROCDateString(Convert.ToDateTime(dt.Rows[index]["SERVICE_EDATE"]));
                }
                //                ucgvtxtBoss.PersonnelId = dt.Rows[index]["BOSS_IDCARD"].ToString();


                //                DropDownList ddlgvServicesType = (DropDownList)gr.FindControl("ddlgvServicesType");
                //                UControl_UcDate gvtxtServiceSDate = (UControl_UcDate)gr.FindControl("gvtxtServiceSDate");
                //                UControl_UcDate gvtxtServiceEDate = (UControl_UcDate)gr.FindControl("gvtxtServiceSDate");

                //gvddlSub_depart_id.SelectedValue = dt.Rows[index]["Sub_depart_id"].ToString();
                //gvddlTitleNo.SelectedValue = dt.Rows[index]["Title_no"].ToString();
                //gvddlContact.SelectedValue = (dt.Rows[index]["isContact"].ToString() == "true" ? 1 : 0);
                //gvddlPosition.SelectedValue = dt.Rows[index]["Position"].ToString();

                ddlgvBossDeaprtId.Orgcode = gvddlOrgcode.SelectedValue;
                ddlgvBossDeaprtId.SelectedValue = dt.Rows[index]["BOSS_DEPART_ID"].ToString();
                //Emp_Member empMember = new Emp_Member();
                //DataTable dt2 = empMember.queryEmpMember("", ddlgvBossDeaprtId.SelectedValue);

                //        ddlName.DataSource = new FSCPLM.Logic.Member().GetDLLDataByODS(Orgcode, cmbDepart1.OrgCode, Role_id, cmbDepart2.OrgCode, "", "", "");
                cmbGvBoss.Items.Clear();
                if (!string.IsNullOrEmpty(ddlgvBossDeaprtId.SelectedValue))
                {
                    cmbGvBoss.DataSource = new FSC.Logic.Personnel().GetDataByOrgDep(gvddlOrgcode.SelectedValue, ddlgvBossDeaprtId.SelectedValue);
                    cmbGvBoss.DataValueField = "ID_CARD";
                    cmbGvBoss.DataTextField = "FULL_NAME";

                    cmbGvBoss.DataBind();
                }
                cmbGvBoss.Items.Insert(0, new ListItem("請選擇", ""));

                try
                {
                    cmbGvBoss.SelectedValue = dt.Rows[index]["BOSS_IDCARD"].ToString();
                }
                catch
                {
                }

                upnl.Update();

            }
            //            Response.Write(gvddlDepartID.SelectedValue + "<BR>");


        }


    }


    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //        Response.Write(e.CommandName);
        if (e.CommandName == "doUpdate") //修改button
        {
            this.hfMode.Value = "Edit";

            this.pnlQueryEdit.Visible = false; // 查詢條件隱藏
            this.pnlQuery.Visible = false;//查詢結果隱藏
            this.pnlEdit.Visible = true;// 資料區塊

            //int index = //Convert.ToInt32(e.CommandArgument);
            //            Response.Write(e.CommandArgument.ToString());
            //            HiddenField hfIDCard = (HiddenField)gvResult.Rows[index].FindControl("hfgvResultIDCard");
            initUpdateData(e.CommandArgument.ToString());

        }
        else if (e.CommandName == "doCheckIn")
        {
            EMP3105 emp3105 = new EMP3105();
            DataTable dt = emp3105.queryData(this.strOrgCode, "", "", "", e.CommandArgument.ToString(), "", "", "");

            if (dt != null && dt.Rows.Count > 0)
            {
                string Orgcode = dt.Rows[0]["ORGCODE"].ToString();
                string Depart_id = dt.Rows[0]["DEPART_ID"].ToString();
                string Id_card = dt.Rows[0]["ID_CARD"].ToString();
                string User_name = dt.Rows[0]["USER_NAME"].ToString();
                string Title_no = dt.Rows[0]["TITLE_NO"].ToString();
                string Service_type = dt.Rows[0]["Service_type"].ToString();
                Response.Redirect("../../FSC/FSC1/FSC1109_01.aspx?org=" + Orgcode + "&did=" + Depart_id + "&id=" + Id_card + "&name=" + User_name + "&tno=" + Title_no + "&st=" + Service_type);
            }
        }
        else if (e.CommandName == "doYear")
        {
            Response.Redirect("EMP3105_02.aspx?id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "doToOut")
        {
            Response.Redirect("EMP3105_03.aspx?id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "doChange")
        {
            Page pp = this.Page;
            try
            {
                Personnel p = new Personnel().GetObject(e.CommandArgument.ToString());
                DataTable dt = new DepartEmp().GetDataByServiceType(p.IdCard, "0");
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.WriteTime = DateTime.Now;
                f.FormId = "001017";
                f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);

                if (p.YoyoCard_Change_flag == "1")
                {
                    f.Reason = f.Reason + p.UserName + "(" + p.IdCard + ")感應卡號變更為" + p.Yoyo_card + "，請調整門禁系統設定。\n";
                    p.UpdateYoyoCard_Change_flag(p.IdCard, "0");
                }
                if (p.Depart_Change_flag == "1")
                {
                    DataRow dr = new DepartEmp().getServiceDepRow("", p.IdCard);
                    if (dr != null)
                    {
                        f.Reason = f.Reason + p.UserName + "(" + p.IdCard + ")服務單位變更為" + new Org().GetDepartName(dr["Orgcode"].ToString(), dr["Depart_id"].ToString()) + "，感應卡號為" + p.Yoyo_card + "，請調整門禁系統設定。\n";
                        p.UpdateDepart_Change_flag(p.IdCard, "0");
                    }
                }

                using (TransactionScope trans = new TransactionScope())
                {
                    string Flow_id = new SYS.Logic.FlowId().GetFlowId(f.Orgcode, "001017");
                    f.FlowId = Flow_id;
                    SYS.Logic.CommonFlow.AddFlow(f);

                    trans.Complete();
                }

                CommonFun.MsgShow(ref pp, CommonFun.Msg.Custom, "通知成功!", "", "");
                ShowGridView();
            }
            catch (FlowException fex)
            {
                CommonFun.MsgShow(ref pp, CommonFun.Msg.Custom, fex.Message, "", "");
            }
            catch (Exception ex)
            {
                CommonFun.MsgShow(ref pp, CommonFun.Msg.SystemError, "", "", "");
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            }
        }
    }


    private void initUpdateData(string strIDCard)
    {
        //        Response.Write(strIDCard);
        // 取得資料
        EMP3105 emp3105 = new EMP3105();
        DataTable dt = emp3105.queryData(this.strOrgCode, "", "", "", strIDCard, "", "", "");

        txtId_card.Text = dt.Rows[0]["Id_number"].ToString();
        txtPersonnel_id.Text = dt.Rows[0]["ID_CARD"].ToString();
        txtUser_Name.Text = dt.Rows[0]["USER_NAME"].ToString();
        // 電子郵件
        txtEmail.Text = dt.Rows[0]["Email"].ToString();
        // 主管層級
        try
        {
            cmbBossLevelID.SelectedValue = dt.Rows[0]["Boss_level_id"].ToString();
        }
        catch { }
        // AD 帳號
        txtADID4Edit.Text = dt.Rows[0]["AD_ID"].ToString();
        // 直撥電話
        txtLivePhone4Edit.Text = dt.Rows[0]["Live_Phone"].ToString();
        // 
        txtOffice_ext.Text = dt.Rows[0]["Ext"].ToString();
        // 差勤組別?
        try
        {
            ddlPEKIND.SelectedValue = dt.Rows[0]["PEKIND"].ToString();
        }
        catch
        {
        }
        //職稱
        try
        {
            cmbTitleNo4Edit.SelectedValue = dt.Rows[0]["Title_no"].ToString();
        }
        catch
        {
        }
        // ddlPEKIND.SelectedValue = dt.Rows[0][""].ToString();
        // 上班別
        //Shift_type
        try
        {
            cmbShiftType4Edit.SelectedValue = dt.Rows[0]["Shift_type"].ToString();
        }
        catch
        {
        }
        try
        {
            rblPESEX.SelectedValue = dt.Rows[0]["GENDER"].ToString();
        }
        catch
        {
        }
        txtPEBIRTHD.Text = (dt.Rows[0]["Birth_date"].ToString() == "" ? "" : dt.Rows[0]["Birth_date"].ToString().PadLeft(7, '0'));
        // 職務類別
        try
        {
            ddlPEMEMCOD.SelectedValue = dt.Rows[0]["EMPLOYEE_TYPE"].ToString();
        }
        catch { }
        // 官職等
        try
        {

            ddlPECRKCOD.SelectedValue = dt.Rows[0]["Degree_code"].ToString();
            if (ddlPEMEMCOD.SelectedValue.Equals("10"))
            {
                ddlPECRKCOD.SelectedValue = "J20";
            } 
        }
        catch { }
        // 到職日
        txtPEACTDATE.Text = (dt.Rows[0]["ACT_DATE"].ToString() == "" ? "" : dt.Rows[0]["ACT_DATE"].ToString().PadLeft(7, '0'));
        // 初任公職日
        UcJoinDate.Text = (dt.Rows[0]["Fisrt_gov_date"].ToString() == "" ? "" : dt.Rows[0]["Fisrt_gov_date"].ToString().PadLeft(7, '0'));
        // 離職日期
        txtPELEVDATE.Text = (dt.Rows[0]["Left_date"].ToString() == "" ? "" : dt.Rows[0]["Left_date"].ToString().PadLeft(7, '0'));
        if (txtPELEVDATE.Text == "0") txtPELEVDATE.Text = "";
        // 登入類型?
        // 休假年資計算起日
        lbYearStartDate.Text = dt.Rows[0]["Leave_yr_bdate"].ToString();
        // 事假天數
        txtPEHDAY2.Text = dt.Rows[0]["PEHDAY2"].ToString();
        // 病假天數
        txtPEHDAY3.Text = dt.Rows[0]["PEHDAY3"].ToString();
        // 休假年資
        lbYear.Text = dt.Rows[0]["PEHYEAR"].ToString();
        // 本年休假天數
        txtPEHDAY.Text = dt.Rows[0]["PEHDAY"].ToString();
        // 留職停薪年資 ? 
        //lbChgCntYear2.Text = 
        // 異動年資
        lbChgYear.Text = dt.Rows[0]["Leave_yr_add"].ToString();
        // 休假總年資 ?
        // lbTotalYear.Text = 
        // 前一年保留天數
        txtPerday1.Text = dt.Rows[0]["PERDAY1"].ToString();
        // 前兩年保留天數
        txtPerday2.Text = dt.Rows[0]["PERDAY2"].ToString();
        // 休假天數凍結（起日）?
        // ColdDateS.Text = dt.Rows[0][""].ToString();
        // 休假天數凍結（迄日）
        // ColdDateE.Text = dt.Rows[0][""].ToString();
        // 角色
        txtServiceYear.Text = dt.Rows[0]["Service_year"].ToString();

        //bindSysRole();
        //foreach (string RoleId in dt.Rows[0]["ROLE_ID"].ToString().Split(','))
        //{
        //    for (int i = 0; i <= cblRoleName.Items.Count - 1; i++)
        //    {
        //        if (RoleId == cblRoleName.Items[i].Value)
        //        {
        //            cblRoleName.Items[i].Selected = true;
        //        }
        //    }
        //}

        hfRole.Value = dt.Rows[0]["ROLE_ID"].ToString();

        txtYoyoCard4Edit.Text = dt.Rows[0]["Yoyo_Card"].ToString();
        hfOldYoyoCard.Value = dt.Rows[0]["Yoyo_Card"].ToString();

        // 是否可使用人員切換
        try
        {
            rblSyslogin.SelectedValue = dt.Rows[0]["Syslogin_flag"].ToString();
        }
        catch { }
        // 是否為值班人員
        try
        {
            rbOnDuty.SelectedValue = dt.Rows[0]["On_Duty"].ToString();
        }
        catch { }

        try
        {
            rblMutiDepartDeputy_flag.SelectedValue = dt.Rows[0]["MutiDepartDeputy_flag"].ToString();
        }
        catch { }

        // 取得相關服務資料
        bindEmpDepartEmp(dt.Rows[0]["ID_CARD"].ToString());


        //txtIntro_desc.Text = txtSkill_desc.Text = txtSpecialty_desc.Text = txtMood_desc.Text = txtPicFile_path.Text = "";

           // EMP_STAFFINTRO_MAIN
        //DataTable dtEmpStaffIntroMain = emp3105.queryEmpStaffIntroMain(strIDCard);
        //    if (dtEmpStaffIntroMain.Rows.Count > 0)
        //    {
        //        if (!Convert.IsDBNull(dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"]))
        //        {
        //            txtPEBIRTHD.Text = dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"].ToString();
        //        }
        //        txtIntro_desc.Text = dtEmpStaffIntroMain.Rows[0]["INTRO_DESC"].ToString();
        //        txtSkill_desc.Text = dtEmpStaffIntroMain.Rows[0]["SKILL_DESC"].ToString();
        //        txtSpecialty_desc.Text = dtEmpStaffIntroMain.Rows[0]["SPECIALTY_DESC"].ToString();
        //        txtMood_desc.Text = dtEmpStaffIntroMain.Rows[0]["MOOD_DESC"].ToString();
        //        txtPicFile_path.Text = dtEmpStaffIntroMain.Rows[0]["PICFILE_PATH"].ToString();
        //    }

    /*    txtPEBIRTHD.Text = dt.Rows[0]["BIRTH_DATE"].ToString();
        txtIntro_desc.Text = dt.Rows[0]["INTRO_DESC"].ToString();
        txtSkill_desc.Text = dt.Rows[0]["SKILL_DESC"].ToString();
        txtSpecialty_desc.Text = dt.Rows[0]["SPECIALTY_DESC"].ToString();
        txtMood_desc.Text = dt.Rows[0]["MOOD_DESC"].ToString();
        txtPicFile_path.Text = dt.Rows[0]["PICFILE_PATH"].ToString();
     */ 
    }


    private bool doInsertDate()
    {
        if (!checkFields()) return false;

        if (!checkPassword()) return false;
        // 檢查資料

        if (!chkEmpDepartEmp()) return false;

        EMP3105 emp3105 = new EMP3105();
        string strIDNumber = txtId_card.Text.ToUpper();  // 身分證號

        if (emp3105.isUserExists(strIDNumber) && emp3105.isUserExists2(strIDNumber))
        {

            Page tempPagee = this.Page;
            CommonFun.MsgShow(ref tempPagee,
               CommonFun.Msg.Custom, "身份證字號" + strIDNumber + "資料已存在,無法新增", "", "");
            this.Page = tempPagee;
            return false;

        }

        // 參數
        ///        string strIdCard    =txtPersonnel_id.Text.Trim();
        ///         
        string strIdCard = emp3105.genIDCard(this.strOrgCode, ddlPEMEMCOD.SelectedValue.Trim());    // 員工編號
        string strAdId = txtADID4Edit.Text.Trim();   // AD帳號

        if (emp3105.isADExists(strAdId))
        {

            Page tempPagee = this.Page;
            CommonFun.MsgShow(ref tempPagee,
               CommonFun.Msg.Custom, "AD帳號" + strAdId + "資料已存在,無法新增", "", "");
            this.Page = tempPagee;
            return false;

        }

        string strUserName = txtUser_Name.Text.Trim();  // 人員姓名
        string strEmail = txtEmail.Text.Trim();      // 電子郵件
        string strEmployeeType = ddlPEMEMCOD.SelectedValue.Trim();  // 職務類別
        string strTitlnNo = cmbTitleNo4Edit.SelectedValue.Trim();   // 目前職稱
        string strBossLevelID = cmbBossLevelID.SelectedValue;           // 主管層級?
        //        string strActDate = EMP3105.convertROCDate2DateString(txtPEACTDATE.Text); // 到職日
        //        string strFirstGovDate = EMP3105.convertROCDate2DateString(UcJoinDate.Text);    // 初任公職日
        //        string strLeftDate = EMP3105.convertROCDate2DateString(txtPELEVDATE.Text);  //離職日期
        string strActDate = txtPEACTDATE.Text.Trim(); // 到職日
        string strFirstGovDate = UcJoinDate.Text.Trim();    // 初任公職日
        string strLeftDate = txtPELEVDATE.Text.Trim();  //離職日期
        string strLivePhone = txtLivePhone4Edit.Text.Trim();    // 直撥電話 
        string strPhone = txtOffice_tel.Text.Trim();            // 辦公室電話 
        string strExt = txtOffice_ext.Text.Trim();              // 分機
        string strDeleteFlag = "N";
        string strQuitJobFlag = "N";
        if (txtPELEVDATE.Text.Trim() != "") strQuitJobFlag = "Y";
        string strChangeUserID = this.strLoginUserID;
        string strGender = rblPESEX.SelectedValue;      // 性別
        string strPassword = txtUser_password.Text;// 密碼

        // FSC_Personnel
        string strPeKind = ddlPEKIND.SelectedValue;      // 差勤組別
        string strLevel = cmbBossLevelID.SelectedValue;    // 職等
        string strLeaveYrAdd = lbChgYear.Text;          // 異動年資
        string strLeaveYrBDate = lbYearStartDate.Text;  // 休假年資計算起日
        string strShiftType = cmbShiftType4Edit.SelectedValue;  // 上班別
        string strPehYear = lbYear.Text;    // 休假年資
        string strPehDay = txtPEHDAY.Text;  // 本年休假天數
        string strPehDay2 = txtPEHDAY2.Text;  // 事假天數
        string strPehDay3 = txtPEHDAY3.Text;  // 病假天數
        string strPerday1 = txtPerday1.Text;    // 前一年保留天數
        string strPerday2 = txtPerday2.Text;    // 前兩年保留天數
        string strPePoint = txtPEPOINT.Text;//俸點
        string strPeProFess = txtPEPROFESS.Text.Trim();//專業加給
        string strPeChief = txtPECHIEF.Text.Trim();// 主管職務加給
        string strPeyKind = ddlPEYKIND.SelectedValue;  // 年制別
        string strLoginType = ddlLoginType.SelectedValue;// 登入類型
        // 事假天數
        // 留職停薪年資
        // 休假總年資
        string strRoleID = hfRole.Value ;  // 角色
        //for (int i = 0; i <= cblRoleName.Items.Count - 1; i++)
        //{
        //    if (cblRoleName.Items[i].Selected)
        //    {
        //        if (strRoleID != "") strRoleID += ",";
        //        strRoleID += cblRoleName.Items[i].Value;
        //    }
        //}


        // EMP_STAFFINTRO_MAIN
        string strBirthDate = txtPEBIRTHD.Text.Trim();  // 出生年月日
        string strIntroDesc = txtIntro_desc.Text.Trim();                            // 自述
        string strSkillDesc = txtSkill_desc.Text.Trim();                            // 專長
        string strSpecialtyDesc = txtSpecialty_desc.Text.Trim();                    // 興趣
        string strMoodDesc = txtMood_desc.Text.Trim();                              // 心情感言
        string strPicfilePath = txtPicFile_path.Text.Trim();
        //        string strChangeUserID,
        //        string strIDCard

        // 


        string strActDateO = txtPEACTDATE.Text;
        string strFirstGovDateO = UcJoinDate.Text;
        string strLeftDateO = txtPELEVDATE.Text;

        string strYoyoCard = txtYoyoCard4Edit.Text.Trim();//Yoyo Card
        string strServiceyear = txtServiceYear.Text.Trim();

        if (string.IsNullOrEmpty(strYoyoCard))
        {
            Page tempPagee = this.Page;
            CommonFun.MsgShow(ref tempPagee,
               CommonFun.Msg.Custom, "感應卡號不可空白!", "", "");
            this.Page = tempPagee;
            return false;
        }
        else if (emp3105.isyoyoExists(strYoyoCard))
        {

            Page tempPagee = this.Page;
            CommonFun.MsgShow(ref tempPagee,
               CommonFun.Msg.Custom, "感應卡號" + strYoyoCard + "資料已存在,無法新增", "", "");
            this.Page = tempPagee;
            return false;

        }

        // 是否可使用人員切換
        string strSysloginFlag = rblSyslogin.SelectedValue;
        // 是否為值班人員
        string strOnDuty = rbOnDuty.SelectedValue;
        //是否可跨處室設定代理人
        string strMutiDepartDeputy_flag = rblMutiDepartDeputy_flag.SelectedValue;


        // 新增
        if (strEmployeeType == "13" || strEmployeeType == "14" || strEmployeeType == "15")
        {
            // 非員工
            emp3105.insertNonEmpMember(
                 strIdCard,
                 strAdId,
                 strUserName,
                 strEmail,
                 strEmployeeType,
                 strActDate,
                 strLeftDate,
                 strPhone,
                 strExt,
                 strChangeUserID,
                 strIDNumber,
                 strGender,
                 strYoyoCard,
                 strServiceyear
                );
        }
        else
        {
            // 員工 1~XX
            emp3105.insertEmpMember(
                 strIdCard,
                 strAdId,
                 strUserName,
                 strEmail,
                 strEmployeeType,
                 strBossLevelID,
                 strActDate,
                 strFirstGovDate,
                 strLeftDate,
                 strLivePhone,
                 strPhone,
                 strExt,
                 strDeleteFlag,
                 strQuitJobFlag,
                 strChangeUserID,
                 strIDNumber,
                 strTitlnNo,
                 strGender,
                 strYoyoCard,
                 strServiceyear
            );

        }

        // 部門資料
        string strOrgCode = this.strOrgCode;
        //        string strDepartId  = cmbDepartID4Edit.SelectedValue;
        string strServiceType = "0";  // 預設佔缺單位
        //        emp3105.insertEmpDepartEmp(strOrgCode, strDepartId, strIdCard, strActDate, "", strServiceType, strChangeUserID);


        emp3105.insertFscPersonnel(
             strIdCard,
             strTitlnNo,
             strUserName,
             strEmployeeType,
             strLevel,
             strActDateO,
             strFirstGovDateO,
             strLeftDateO,
             strLeaveYrAdd,
             strLeaveYrBDate,
             strShiftType,
             strPehYear,
             strPehDay,
             strPehDay2,
             strPehDay3,
             strPeKind,
             strPerday1,
             strPerday2,
             strRoleID,
             strChangeUserID,
             strPePoint,
             strPeProFess,
             strPeChief,
             strPeyKind,
             strLoginType
                          , strSysloginFlag
             , strOnDuty
             , strIDNumber
             , strGender
             , strBirthDate
             , strBossLevelID
             , strEmail
             , strAdId
             , strMutiDepartDeputy_flag
             , strServiceyear
             );


        emp3105.insertEmpStaffintroMain(
            strBirthDate, strIntroDesc, strSkillDesc, strSpecialtyDesc, strMoodDesc, strPicfilePath, strChangeUserID, strIdCard
            );





        // EMP_DEPART_EMP
        // 新增 GRID 中資料
        // 刪 EMP_DEPART_EMP
        emp3105.deleteEmpDepartEmp("", strIdCard, "", "", "");
        // 刪 FSC_Personnel_Boss
        emp3105.deleteFSCPERSONNELBOSS(strIdCard, "", "");

        // 新增 EMP_DEPART_EMP
        DataTable dt = GvToDt();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strGVOrgCode = dt.Rows[i]["ORGCODE"].ToString();
            string strGVDepartId = dt.Rows[i]["DEPART_ID"].ToString();
            string strGVServiceType = dt.Rows[i]["SERVICE_TYPE"].ToString();  // 預設佔缺單位
            //            string strServicesSDate = String.Format("{0:yyyy/MM/dd}", dt.Rows[i]["SERVICE_SDATE"]);
            //            string strServicesEDate = String.Format("{0:yyyy/MM/dd}", dt.Rows[i]["SERVICE_EDATE"]);
            string strServicesSDate = dt.Rows[i]["SERVICE_SDATE"].ToString();
            string strServicesEDate = dt.Rows[i]["SERVICE_EDATE"].ToString();
            string strGVBOSSDepartId = dt.Rows[i]["BOSS_DEPART_ID"].ToString();
            string strBossIDCard = dt.Rows[i]["BOSS_IDCARD"].ToString();
            emp3105.insertEmpDepartEmp(strGVOrgCode, strGVDepartId, strIdCard, strServicesSDate, strServicesEDate, strGVServiceType, strChangeUserID);

            // Boss
            emp3105.insertFscPersonnelBoss(strGVOrgCode, strGVDepartId, strIdCard, strGVServiceType, strGVBOSSDepartId, strBossIDCard, strChangeUserID);
        }

        /*
        try
        {
 //           createADUSer();
        }
        catch { }
         * */

        //新增一筆當日的上班卡
        CPAPHYYMM bll = new CPAPHYYMM((DateTime.Now.Year - 1911).ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0'));
        bll.InsertCPAPHYYMM("001", strIdCard, FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString(), "0830", "A", "");
        
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "新增員工完成,編號:" + strIdCard, "", "");
        this.Page = tempPage;

        return true;
    }

    /// <summary>
    /// 取消按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.pnlQueryEdit.Visible = false; // 查詢條件隱藏
        this.pnlQuery.Visible = false;//查詢結果隱藏
        this.pnlEdit.Visible = false;// 資料區塊

        if (this.hfMode.Value == "Edit")
        {
            this.pnlQuery.Visible = true;
            this.pnlQueryEdit.Visible = true; // 查詢條件隱藏
        }
        else
        {
            this.pnlQuery.Visible = true;
            this.pnlQueryEdit.Visible = true; // 查詢條件隱藏
        }
        this.hfMode.Value = "";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string FileUploadPath = ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "EMP\\";
        string filepath = Server.MapPath(FileUploadPath);
        // 負檔名
        string I_type = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1);
        string strFileName = DateTime.Now.ToString("EMP_yyyyMMddHHmmssfffff");
        string strFileNameFull = String.Format("{0}", strFileName) + "." + I_type;
        txtPicFile_path.Text = FileUploadPath + strFileNameFull;

        FileUpload1.SaveAs(filepath + strFileNameFull);
        imgPic.ImageUrl = txtPicFile_path.Text;
    }

    /*
    private void createADUSer()
    {
        
        PrincipalContext ouContex = new PrincipalContext(ContextType.Domain,
                                                         "TestDomain.local",
                                                         "OU=TestOU,DC=TestDomain,DC=local");

        try
        {
            UserPrincipal up = new UserPrincipal(ouContex);
            up.SamAccountName = txtADID4Edit.Text;
            up.SetPassword(txtUser_password.Text);
            up.Enabled = true;
            up.ExpirePasswordNow();
            up.Save();
        }
        catch (Exception ex)
        {
        }
        
    }
     * */
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvddlBossDepartID_changed(object sender, EventArgs e)
    {
        UControl_UcDDLDepart Depart = ((UControl_UcDDLDepart)((DropDownList)sender).NamingContainer);
        GridViewRow row = (GridViewRow)(Depart.NamingContainer);
   
        string strDepartID = Depart.SelectedValue;

        //                GridViewRow row = Depart.NamingContainer as GridViewRow;
        //                UControl_UcMember ucgvtxtBoss = (UControl_UcMember)row.FindControl("ucgvtxtBoss");
        //                ucgvtxtBoss.PersonnelId = "";
        GvBoss_Bind(row, Depart);
    }

    protected void GvBoss_Bind(GridViewRow row, UControl_UcDDLDepart Depart)
    {
        //Emp_Member empMember = new Emp_Member();
        //DataTable dt = empMember.queryEmpMember("", Depart.SelectedValue);
        DropDownList gvddlOrgcode = (DropDownList)row.FindControl("gvddlOrgcode");
        DropDownList cmbGvBoss = (DropDownList)row.FindControl("cmbGvBoss");
        //        ddlName.DataSource = new FSCPLM.Logic.Member().GetDLLDataByODS(Orgcode, cmbDepart1.OrgCode, Role_id, cmbDepart2.OrgCode, "", "", "");
        cmbGvBoss.Items.Clear();
        if (!string.IsNullOrEmpty(Depart.SelectedValue))
        {
     //       Label lb3 = (Label)row.FindControl("Label3");
            cmbGvBoss.DataSource = new FSC.Logic.Personnel().GetDataByOrgDep(gvddlOrgcode.SelectedValue, Depart.SelectedValue);
            cmbGvBoss.DataValueField = "ID_CARD";
            cmbGvBoss.DataTextField = "FULL_NAME";

            cmbGvBoss.DataBind();
        }
        cmbGvBoss.Items.Insert(0, new ListItem("請選擇", ""));


        UpdatePanel upnl = (UpdatePanel)row.FindControl("PnlGVBoss");
        upnl.Update();
    }

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HiddenField hfOrgCode = (HiddenField)e.Row.FindControl("hfOrgCode");
            //HiddenField hfDepartId = (HiddenField)e.Row.FindControl("HiddenField1");
            //Label lblIdCard = (Label)e.Row.FindControl("lblIdCard");
            Button btnCheckIn = (Button)e.Row.FindControl("btnCheckIn");
            Label lbInitflag = (Label)e.Row.FindControl("lbInitflag");
            Button btnChange = (Button)e.Row.FindControl("btnChange");
            Label lbYoyoCard_Change_flag = (Label)e.Row.FindControl("lbYoyoCard_Change_flag");
            Label lbDepart_Change_flag = (Label)e.Row.FindControl("lbDepart_Change_flag");

            //FSC.Logic.StaffRegister sr = new FSC.Logic.StaffRegister();
            //sr.Apply_Orgcode = hfOrgCode.Value;
            //sr.Apply_Depart_id = hfDepartId.Value;
            //sr.Apply_Idcard = lblIdCard.Text.Trim();
            //DataTable dt = sr.getData();

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    btnCheckIn.Enabled = false;
            //}

            if (lbInitflag.Text == "1")
                btnCheckIn.Enabled = false;
            if (lbYoyoCard_Change_flag.Text == "1" || lbDepart_Change_flag.Text == "1")
                btnChange.Visible = true;
        }
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        ShowGridView();
    }
    protected void cmbBossLevelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbBossLevelID.SelectedValue == "0")
        {
            //for (int i = 0; i < cblRoleName.Items.Count - 1 ; i++)
            //{
            //    if (cblRoleName.Items[i].Value == "OrgHead" || cblRoleName.Items[i].Value == "DeptHead" || cblRoleName.Items[i].Value == "Master")
            //        cblRoleName.Items[i].Selected = false;
            //}
            hfRole.Value = "General";
        }
        else if (cmbBossLevelID.SelectedValue == "1")
        {
            //for (int i = 0; i < cblRoleName.Items.Count - 1; i++)
            //{
            //    if (cblRoleName.Items[i].Value == "DeptHead" || cblRoleName.Items[i].Value == "Master")
            //        cblRoleName.Items[i].Selected = false;
            //    else if (cblRoleName.Items[i].Value == "OrgHead")
            //        cblRoleName.Items[i].Selected = true;
            //}
            hfRole.Value = "OrgHead";
        }
        else if (cmbBossLevelID.SelectedValue == "2")
        {
            //for (int i = 0; i < cblRoleName.Items.Count - 1; i++)
            //{
            //    if (cblRoleName.Items[i].Value == "OrgHead" || cblRoleName.Items[i].Value == "Master")
            //        cblRoleName.Items[i].Selected = false;
            //    else if (cblRoleName.Items[i].Value == "DeptHead")
            //        cblRoleName.Items[i].Selected = true;
            //}
            hfRole.Value = "DeptHead";
        }
        else if (cmbBossLevelID.SelectedValue == "3")
        {
            //for (int i = 0; i < cblRoleName.Items.Count - 1; i++)
            //{
            //    if (cblRoleName.Items[i].Value == "OrgHead" || cblRoleName.Items[i].Value == "DeptHead")
            //        cblRoleName.Items[i].Selected = false;
            //    else if (cblRoleName.Items[i].Value == "Master")
            //        cblRoleName.Items[i].Selected = true;
            //}
            hfRole.Value = "Master";
        }
    }
    protected void ddlPEMEMCOD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPEMEMCOD.SelectedValue == "13") //駐署人員
        {
            txtEmail.Enabled = true;
            txtEmail.Text = "";
            ddlPECRKCOD.SelectedValue = "001";
            cmbTitleNo4Edit.SelectedValue = "9999";


            foreach (GridViewRow gvr in gvList.Rows)
            {
                DropDownList ddlgvServicesType = (DropDownList)gvr.FindControl("ddlgvServicesType");
                ddlgvServicesType.SelectedValue = "1";
                ddlgvServicesType.Enabled = ddlPEMEMCOD.SelectedValue != "13";
            }

            //for (int i = 0; i <= cblRoleName.Items.Count - 1; i++)
            //{

            //    if (cblRoleName.Items[i].Value == "Maintain_vendors")
            //        cblRoleName.Items[i].Selected = true;
            //    else
            //        cblRoleName.Items[i].Selected = false;

            //}
            hfRole.Value = "Maintain_vendors";
        }
        else
        {
            if (ddlPEMEMCOD.SelectedValue.Equals("10"))
            {
                ddlPECRKCOD.SelectedValue = "J20";
            } 
            txtEmail.Enabled = false;
            ddlPECRKCOD.SelectedValue = (ddlPEMEMCOD.SelectedValue == "10" ? "J20" : "");
            cmbTitleNo4Edit.SelectedValue = "";
            txtEmail.Text = txtADID4Edit.Text.Trim() + new SYS.Logic.CODE().GetDataDESC("023","033",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode));

            foreach (GridViewRow gvr in gvList.Rows)
            {
                DropDownList ddlgvServicesType = (DropDownList)gvr.FindControl("ddlgvServicesType");
                ddlgvServicesType.SelectedValue = "0";
                ddlgvServicesType.Enabled = ddlPEMEMCOD.SelectedValue != "13";
            }
        }

        if (ddlPEMEMCOD.SelectedValue == "5") //約聘僱人員
        {
            ddlPECRKCOD.SelectedValue = "001";
        }    

        DropDownList ddl1 = (DropDownList)ddlPECRKCOD.FindControl("DropDownList_code_no");
        ddl1.Enabled = ddlPEMEMCOD.SelectedValue != "13";
        DropDownList ddl2 = (DropDownList)cmbTitleNo4Edit.FindControl("DropDownList_code_no");
        ddl2.Enabled = ddlPEMEMCOD.SelectedValue != "13";
    }



    private void createADUSer()
    {
        // 取得 Web Config 相關參數
        string stradIP = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_server_ip"];
        string stradID = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_id"];
        string stradPass = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_pass"];
        string stradDC = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_dc"];

        string strAdId = txtADID4Edit.Text.Trim();   // AD帳號
        string strUserName = txtUser_Name.Text.Trim();  // 人員姓名
        string strEmail = txtEmail.Text.Trim();      // 電子郵件
        string strEmployeeType = ddlPEMEMCOD.SelectedValue.Trim();  // 職務類別
        string strTitlnNo = cmbTitleNo4Edit.SelectedValue.Trim();   // 目前職稱
        string strExt = txtOffice_ext.Text.Trim();              // 分機
        string strPassword = txtUser_password.Text;// 密碼
        string strDepartName = "";
        string strDepartID = "";
        DataTable dt = GvToDt();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            EMP3105 emp3105 = new EMP3105();
            string strGVDepartId = dt.Rows[i]["DEPART_ID"].ToString();
            if (i == 0)
            {
                //                strDepartName = emp3102.getDeptNameByDepartID(this.strOrgCode, strGVDepartId);
                strDepartName = emp3105.getParentDeptNameByDepartID(strGVDepartId);
                strDepartID = strGVDepartId;
            }
            if (dt.Rows[i]["SERVICE_TYPE"].ToString() == "0")
            {
                //                strDepartName = emp3102.getDeptNameByDepartID(this.strOrgCode, strGVDepartId);
                strDepartName = emp3105.getParentDeptNameByDepartID(strGVDepartId);
                strDepartID = strGVDepartId;
            }
        }
        //return;

        DirectoryEntry dirEntry;
        // Check AD 目錄
        string strOU = "OU=epais";
        string strOUOK = strOU;
        string strOUOK2 = "";
        //label2.Text = "LDAP://" + stradIP + "/" + strOU + "," + stradDC;
        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
        strOU = "OU=" + strDepartID.Substring(0, 2) + "," + strOU;

        System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        //label2.Text = strDepartID.Substring(0, 2);
        mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 2) + ")");
        //label2.Text = "a2";

        //de = mySearcher.FindOne();
        SearchResult de = mySearcher.FindOne();
        //                    label2.Text = "";

        if (de != null)
        {
            strOUOK = strOU;
            strOUOK2 = strDepartID.Substring(0, 2);
            dirEntry.Close();

            dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
            strOU = "OU=" + strDepartID.Substring(0, 4) + "," + strOU;

            mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
            mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 4) + ")");
            de = mySearcher.FindOne();

            if (de != null)
            {
                strOUOK = strOU;
                strOUOK2 = strDepartID.Substring(0, 4);
            }
            else
            {

            }
        }
        else
        {

        }
        //                }

        //                    label2.Text = strOUOK2;
        //label2.Text += strOUOK2 + "\n";
        dirEntry.Close();

        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOUOK + "," + stradDC, stradID, stradPass);
        // AD 不存在

        // 新增 AD USER
        DirectoryEntry newUser = dirEntry.Children.Add("CN=" + strAdId, "user");
        // 帳號
        try
        {
            newUser.Properties["samAccountName"].Value = strAdId;
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();
        }
        // 名
        try
        {
            newUser.Properties["givenName"].Value = strUserName.Substring(1);
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();

        }
        // 姓
        try
        {
            newUser.Properties["sn"].Value = strUserName.Substring(0, 1);
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();
        }
        // 全名
        try
        {
            newUser.Properties["displayName"].Value = strUserName;
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();
        }

        //EMP3102DAO emp3102dao = new EMP3102DAO();
        //dt.Rows[i]["DepartName"] = emp3102dao.getDeptNameByDepartID(strOrgCode, dt.Rows[i]["DEPART_ID"].ToString());
        // 描述,給單位名稱
        try
        {
            newUser.Properties["description"].Value = strDepartName;
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();

        }
        if (strEmployeeType == "13")
        {
            // 辦公室 - 住屬人員才需要
            try
            {
                newUser.Properties["physicalDeliveryOfficeName"].Value = "";
                newUser.CommitChanges();
            }
            catch
            {
                newUser.RefreshCache();

            }
        }
        // 電話
        try
        {
            newUser.Properties["telephoneNumber"].Value = strExt;
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();

        }
        // EMail
        try
        {
            newUser.Properties["mail"].Value = strEmail;
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();
        }
        // 職稱
        try
        {
            newUser.Properties["title"].Value = strTitlnNo;// SALARY.Logic.app.GetSaCode_Desc1("023", "012", strTitlnNo);
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();
        }
        // 
        /*
                        try
                        {
                            newUser.CommitChanges();
                        }
                        catch (Exception e)
                        {
                            label2.Text += strAdId + " Error :" + e.Message;
                            listBox1.Items.Add(DateTime.Now.ToString() +" : "+ strAdId + " Error :" + e.Message);
                        }
        */
        try
        {
            newUser.Invoke("SetPassword", new object[] { "@" + strAdId });
            newUser.CommitChanges();
        }
        catch
        {
            newUser.RefreshCache();

        }


        //label2.Text += strAdId + ":" + (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) - 19110000).ToString();
        string strJoinDate = UcJoinDate.Text;
        if (!string.IsNullOrEmpty(strJoinDate))
        {
            if (Convert.ToInt32(UcJoinDate.Text) <= Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) - 19110000)
            {
                try
                {
                    // 啟用帳戶
                    int val = (int)newUser.Properties["userAccountControl"].Value;
                    newUser.Properties["userAccountControl"].Value = val & ~0x2;
                    newUser.CommitChanges();
                    newUser.Close();
                }
                catch
                {
                    newUser.RefreshCache();

                }
            }
        }
        dirEntry.Close();

    }

    private void modifyADUser()
    {
        // 取得 Web Config 相關參數
        string stradIP = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_server_ip"];
        string stradID = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_id"];
        string stradPass = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_pass"];
        string stradDC = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_dc"];

        string strAdId = txtADID4Edit.Text.Trim();   // AD帳號
        string strUserName = txtUser_Name.Text.Trim();  // 人員姓名
        string strEmail = txtEmail.Text.Trim();      // 電子郵件
        string strEmployeeType = ddlPEMEMCOD.SelectedValue.Trim();  // 職務類別
        string strTitlnNo = cmbTitleNo4Edit.SelectedValue.Trim();   // 目前職稱
        string strExt = txtOffice_ext.Text.Trim();              // 分機
        string strPassword = txtUser_password.Text;// 密碼
        string strDepartName = "";
        string strDepartID = "";
        DataTable dt = GvToDt();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            EMP3105 emp3105 = new EMP3105();
            string strGVDepartId = dt.Rows[i]["DEPART_ID"].ToString();
            if (i == 0)
            {
                //                strDepartName = emp3102.getDeptNameByDepartID(this.strOrgCode, strGVDepartId);
                strDepartName = emp3105.getParentDeptNameByDepartID(strGVDepartId);
                strDepartID = strGVDepartId;
            }
            if (dt.Rows[i]["SERVICE_TYPE"].ToString() == "0")
            {
                //                strDepartName = emp3102.getDeptNameByDepartID(this.strOrgCode, strGVDepartId);
                strDepartName = emp3105.getParentDeptNameByDepartID(strGVDepartId);
                strDepartID = strGVDepartId;
            }
        }

        DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + stradIP //+ "/" 
            //                + "CN="+strAdId+"," + stradDC 
            , stradID, stradPass);
        System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        mySearcher.Filter = ("(cn=" + strAdId + ")");
        SearchResult de = mySearcher.FindOne();

        if (de == null)
        {
            createADUSer();
        }
        else
        {
            // 修改
            string stradspath = "";
            string strdistinguishedname = "";
            foreach (string key in de.Properties.PropertyNames)
            {

                foreach (object propVal in de.Properties[key])
                {
                    //label2.Text += key + " : " + propVal.ToString() + "\n";
                    //listBox1.Items.Add(DateTime.Now.ToString() + " : " + key +" : " + propVal.ToString());
                    if (key == "adspath")
                    {
                        stradspath = propVal.ToString();
                        //                        Response.Write(propVal + "<BR>");
                    }
                    if (key == "istinguishedname")
                    {
                        strdistinguishedname = propVal.ToString();
                        //                        Response.Write(propVal + "<BR>");
                    }
                }
            }


            //label2.Text += stradspath+"\n";


            //            dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/"
            //                                + "CN=" + strAdId + "," + stradDC
            //                            , stradID, stradPass);
            dirEntry = new DirectoryEntry(stradspath
                            , stradID, stradPass);


            // 名
            try
            {
                dirEntry.Properties["givenName"].Value = strUserName.Substring(1);
                dirEntry.CommitChanges();
            }
            catch (Exception e)
            {
                dirEntry.RefreshCache();

            }
            // 姓
            try
            {
                dirEntry.Properties["sn"].Value = strUserName.Substring(0, 1);
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
            // 全名
            try
            {
                dirEntry.Properties["displayName"].Value = strUserName;
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }

            try
            {
                dirEntry.Properties["description"].Value = strDepartName;
                dirEntry.CommitChanges();
            }
            catch 
            {
                dirEntry.RefreshCache();
            }
            if (strEmployeeType == "13")
            {
                try
                {
                    // 辦公室 - 住屬人員才需要
                    dirEntry.Properties["physicalDeliveryOfficeName"].Value = "";
                    dirEntry.CommitChanges();
                }
                catch
                {
                    dirEntry.RefreshCache();
                }
            }

            // 電話
            try
            {
                dirEntry.Properties["telephoneNumber"].Value = strExt;
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
            // EMail
            try
            {
                dirEntry.Properties["mail"].Value = strEmail;
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
            // 職稱
            try
            {
                dirEntry.Properties["title"].Value = strTitlnNo;
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
            /*               
                           try
                           {
                               //dirEntry.Invoke("SetPassword", new object[] { "@" + strAdId });
                               dirEntry.Invoke("SetPassword", new object[] { "@a0-igss" });
                               dirEntry.CommitChanges();
                           }
                           catch (Exception e)
                           {
                               listBox1.Items.Add(DateTime.Now.ToString() + " : " + " SetPassword[密碼] 發生問題 " + strAdId + " / " + e.Message + "\n"+e.StackTrace);
                               dirEntry.Close();
                               dirEntry = new DirectoryEntry(stradspath
                                               , stradID, stradPass);
                           }
                           try
                           {
                               // 啟用帳戶
                               int val = (int)dirEntry.Properties["userAccountControl"].Value;
                               //listBox1.Items.Add(DateTime.Now.ToString() + " 1 ");
                               dirEntry.Properties["userAccountControl"].Value = val & ~0x2;
                               //listBox1.Items.Add(DateTime.Now.ToString() + " 2 ");
                               dirEntry.CommitChanges();
                               //listBox1.Items.Add(DateTime.Now.ToString() + " 3 ");
                              // dirEntry.Close();
                           }
                           catch (Exception e)
                           {
                               listBox1.Items.Add(DateTime.Now.ToString() + " : " + " 啟用帳號發生問題 " + strAdId + " / " + e.Message);
                               dirEntry.Close();
                               dirEntry = new DirectoryEntry(stradspath
                                               , stradID, stradPass);
                           }
           */

            string strTemp = txtPELEVDATE.Text;
            //label2.Text += strAdId +" : LEFT : "+strTemp + "\n";
            if (!String.IsNullOrEmpty(strTemp))
            {
                if (Convert.ToInt32(txtPELEVDATE.Text.Trim()) <=
                    Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) - 19110000)
                {

                    try
                    {
                        // 停用帳戶
                        int val = (int)dirEntry.Properties["userAccountControl"].Value;
                        //label2.Text += "1 Disable OK \n";
                        dirEntry.Properties["userAccountControl"].Value = val | 0x2;
                        //label2.Text += "2 Disable OK \n";
                        dirEntry.CommitChanges();

                        //dirEntry.Close();
                        //label2.Text += "3 Disable OK \n";
                    }
                    catch (Exception e)
                    {
                        dirEntry.RefreshCache();
                    }
                }
            }

            if (strEmployeeType == "13")
            {

                try
                {
                    dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN=a0-operatoe,CN=Users," + stradDC, stradID, stradPass);
                    //                    dirEntry.Properties["member"].Add("CN=" + strAdId + "," + stradDC);
                    dirEntry.Properties["member"].Add(strdistinguishedname);
                    dirEntry.CommitChanges();
                }

                catch
                {
                    dirEntry.RefreshCache();
                }
            }
            /*
            try
            {
                dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN=epa,CN=KLAdmins," + stradDC, stradID, stradPass);
                //                    dirEntry.Properties["member"].Add("CN=" + strAdId + "," + stradDC);
                dirEntry.Properties["member"].Add(strdistinguishedname);
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
            try
            {
                dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN=umepa,CN=Users," + stradDC, stradID, stradPass);
                //                    dirEntry.Properties["member"].Add("CN=" + strAdId + "," + stradDC);
                dirEntry.Properties["member"].Add(strdistinguishedname);
                dirEntry.CommitChanges();
            }
            catch
            {
                dirEntry.RefreshCache();
            }
             */

            // 移動位置
            string strOU = "OU=epais";
            string strOUOK = strOU;
            string strOUOK2 = "";
            //label2.Text = "LDAP://" + stradIP + "/" + strOU + "," + stradDC;
            dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
            //L
            //                if (strOUOK.Length >= 6)
            //                {
            strOU = "OU=" + strDepartID.Substring(0, 2) + "," + strOU;

            mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
            //label2.Text = strDepartID.Substring(0, 2);
            mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 2) + ")");
            //label2.Text = "a2";

            //de = mySearcher.FindOne();
            de = mySearcher.FindOne();
            //                    label2.Text = "";

            if (de != null)
            {
                strOUOK = strOU;
                strOUOK2 = strDepartID.Substring(0, 2);
                dirEntry.Close();

                dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
                strOU = "OU=" + strDepartID.Substring(0, 4) + "," + strOU;

                mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
                mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 4) + ")");
                de = mySearcher.FindOne();

                if (de != null)
                {
                    strOUOK = strOU;
                    strOUOK2 = strDepartID.Substring(0, 4);
                }
                else
                {
                }
            }
            else
            {
                //                        label2.Text = "not found";
            }
            //                }

            //                    label2.Text = strOUOK2;
            //label2.Text += strOUOK2 + "\n";
            dirEntry.Close();

            try
            {
                //dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOUOK + "," + stradDC, stradID, stradPass);
                DirectoryEntry eLocation = dirEntry = new DirectoryEntry(stradspath
                                , stradID, stradPass);
                DirectoryEntry nLocation = new DirectoryEntry("LDAP://" + stradIP + "/" + strOUOK + "," + stradDC, stradID, stradPass);
                string newName = eLocation.Name;
                eLocation.MoveTo(nLocation, newName);
                nLocation.Close();
                eLocation.Close();

            }
            catch (Exception e)
            {
                dirEntry.RefreshCache();
            }


        }

    }
    protected void txtId_card_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtId_card.Text.Trim()) && txtId_card.Text.Trim().Length >= 2)
        {
            if (txtId_card.Text.Trim().Substring(1, 1) == "1")
            {
                rblPESEX.SelectedValue = "1";
            }
            else if (txtId_card.Text.Trim().Substring(1, 1) == "2")
            {
                rblPESEX.SelectedValue = "0";
            }
        }
    }
}