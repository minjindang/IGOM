using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SALPLM.Logic;
using System.Data;
using System.Data.SqlClient;
using EMPPLM.Logic;

public partial class SAL_SAL3_SAL3101_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    private string strLogIDCard;    // 登入者原邊
    protected void Page_Load(object sender, EventArgs e)
    {
        cmbDepartID.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(cmbDepart2_changed);//單位名稱

        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        strLogIDCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);

        UcSaCode1.CodeChanged +=new uc_ucSaCode.CodeChangedEventHandler(UcSaCode1_CodeChanged);

        // 
        edit_base_org_l3.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_org_l3_CodeChanged);
        edit_base_org_l1.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_org_l1_CodeChanged);
        edit_base_kdp.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_kdp_CodeChanged);
        edit_base_kdc.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_kdc_CodeChanged);
        edit_base_in_l1.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_in_l1_CodeChanged);
        edit_base_org_l2.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_org_l2_CodeChanged);
        //edit_base_kdb.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(edit_base_kdb_CodeChanged);

        if (Page.IsPostBack) return;
        cmbDepartID.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

        ddl_Depart4Edit.Orgcode = strOrgCode;
        ucSaBase_Bank_1.v_orgid = strOrgCode;


//        edit_base_kdp.Code_no = edit_base_kdp_t.Text;
    }

    protected void cmbDepart2_changed(object sender, EventArgs e)
    {
        Name_Bind();
    }

    protected void Name_Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        Emp_Member empMember = new Emp_Member();
        DataTable dt = new FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, cmbDepartID.SelectedValue);           

        ddlName.Orgcode = Orgcode;
        ddlName.DepartId = cmbDepartID.SelectedValue;

      //  upnlUserName.Update();
    }

    protected void UcSaCode1_CodeChanged(object sender, EventArgs e)
    {
        if (UcSaCode1.SelectedItem.Text == "---不設定---")
        {
        }
        else
        { 
          edit_base_memo2.Text = UcSaCode1.SelectedItem.Text;
        }
    }

    protected string GetStatus(object base_retire, object base_edate)
    {
        string rv = "在職";
        if (base_retire == "Y")
        {
            rv="已退休";
        }
        else if (base_edate!="" && base_edate!="99999999") 
        {
            rv="已離職";
        }
        return rv;

    }

    // 
    protected string FStyle(object value)
    {
        string rv = "";

        if (value.ToString() == "未設定")
        {
            rv = "color:blue";
        }
        else
        {
            rv = "";
        }

        return rv;
    }

    protected void Button_Search_Click(object sender, EventArgs e)
    {
        this.queryUser();
    }

    private void queryUser()
    {
        // 參數
        String strEmpType = ddl_emp_type.SelectedValue; // 員工類型
        String strBaseEDate = DropDownList_base_edate.SelectedValue;    // 在職類型 
        String strSearchStr = TextBox_Search_str.Text.Trim();
        string departid = cmbDepartID.SelectedValue; //單位別
        string idcard = ddlName.SelectedValue;// 員工編號

        SAL3101 sal3101 = new SAL3101();
        DataTable dt = sal3101.querySalSaBase(this.strOrgCode, strBaseEDate, strEmpType, strSearchStr, departid, idcard);

        GridView_SaBase.DataSource = dt;
        GridView_SaBase.DataBind();

        if (GridView_SaBase.Rows.Count > 0)
        {
            Ucpager2.Visible = true;
        }
        else
        {
            Ucpager2.Visible = false;
        }
        pnlQueryResult.Visible = true;
        pnlModify.Visible = false;

       
    }

    protected void GridView_SaBase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doUpdate") //修改button
        {
            string strBaseSeqNO = e.CommandArgument.ToString();
            //Response.Write(strBaseSeqNO);
            getSingleUserData(strBaseSeqNO);
        
            pndConditions.Visible = false;

            //若為出納人員(人員角色為出納人員)則<員工基本資料、薪資設定、保險資料>區塊應為唯讀，其他可維護。
            bool cashier = false;
            string Role_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);
            string[] Role = Role_id.Split(',');
            if (Role.Length > 0)
            {
                for (int i = 0; i < Role.Length; i++)
                {
                    if (Role[i].ToLower() == "cashier")
                    {
                        cashier = true;
                    }
                }            
            }

            if (cashier)
            {
                edit_base_name.Enabled = false;
                edit_base_idno.Enabled = false;
                edit_base_ermk.Enabled = false;
                edit_base_prono.Visible = false;
                lb_edit_base_prono.Visible = true;
                edit_base_parttime.Enabled = false;
                edit_base_status.Enabled = false;
                edit_base_sex.Enabled = false;
                ddl_Depart4Edit.Enabled = false;
                edit_base_bdate.Enabled = false;
                edit_base_edate.Enabled = false;
                edit_base_proj_bdate.Enabled = false;
                edit_base_proj_edate.Enabled = false;
                edit_base_quit_date.Enabled = false;
                edit_base_quit_rezn.Visible = false;
                lb_edit_base_quit_rezn.Visible = true;
                ddl_Budget_code.Visible = false;
                lb_Budget_code.Visible = true;
                edit_base_dcodesys.Visible = false;
                lb_edit_base_dcodesys.Visible = true;
                edit_base_dcode.Visible = false;
                lb_edit_base_dcode.Visible = true;
                edit_base_org_l3.Visible = false;
                lb_edit_base_org_l3.Visible = true;
                edit_base_org_l1.Visible = false;
                lb_edit_base_org_l1.Visible = true;
                edit_base_in_l1.Visible = false;
                lb_edit_base_in_l1.Visible = true;
                edit_base_in_l3.Visible = false;
                lb_edit_base_in_l3.Visible = true;
                edit_base_org_l2.Visible = false;
                lb_edit_base_org_l2.Visible = true;
                edit_base_ptb_type.Enabled = false;
                edit_base_ptb.Enabled = false;
                edit_base_alt_amt.Enabled = false;
                edit_base_kdp.Visible = false;
                lb_edit_base_kdp.Visible = true;
                edit_base_kdp_series.Visible = false;
                lb_edit_base_kdp_series.Visible = true;
                edit_base_kdc_series.Visible = false;
                lb_edit_base_kdc_series.Visible = true;


                edit_base_kdc.Visible = false;
                lb_edit_base_kdc.Visible = true;
                edit_base_kdo.Enabled = false;
                edit_base_kdb.Visible = false;
                lb_edit_base_kdb.Visible = true;
                txtSchool.Enabled = false;
                edit_base_addr.Enabled = false;

                GridView GV = (GridView)UcSaBase_Kdo_1.FindControl("GridView_pitm");
                GV.Enabled = false;

                edit_base_govadof.Enabled = false;
                r_base_govadof.Enabled = false;
                RadioButtonList1.Enabled = false;
                edit_base_priz.Enabled = false;
                edit_base_pre.Enabled = false;
                edit_base_pred.Enabled = false;
                edit_base_pol.Enabled = false;
                cmb_base_hous.Enabled = false;
                edit_base_welg.Enabled = false;
                edit_base_tax.Enabled = false;
                edit_base_tax_dct.Enabled = false;
                edit_base_numerator.Enabled = false;
                edit_base_denominator.Enabled = false;
                edit_base_other_sal.Enabled = false;

                GridView GVOther = (GridView)ucSaBase_Other_Sal1.FindControl("GridView_Other_1");
                GVOther.Enabled = false;
                GridView GVOther2 = (GridView)ucSaBase_Other_Sal1.FindControl("GridView_Other_2");
                GVOther2.Enabled = false;

                edit_base_day_sal.Enabled = false;
                edit_base_hour_sal.Enabled = false;
                edit_base_fins_kind.Enabled = false;

                DropDownList base_labor_series = (DropDownList)edit_base_labor_series.FindControl("DropDownList_level");
                base_labor_series.Enabled = false;

                DropDownList base_fins_series = (DropDownList)edit_base_fins_series.FindControl("DropDownList_level");
                base_fins_series.Enabled = false;

                edit_base_lab_jif.Enabled = false;
                edit_base_lab1.Enabled = false;
                edit_base_lab2.Enabled = false;
                edit_base_lab3.Enabled = false;
                edit_base_pn_y30.Enabled = false;
                edit_base_pen_type.Enabled = false;

                DropDownList base_pen_series = (DropDownList)edit_base_pen_series.FindControl("DropDownList_level");
                base_pen_series.Enabled = false;

                edit_base_pen_rate.Enabled = false;
                edit_base_prov.Enabled = false;
                edit_base_fins_self.Enabled = false;
                edt_BASE_FINS_SELF_DESC.Enabled = false;
                edit_base_fins_noq.Enabled = false;
                edit_base_fins_noh.Enabled = false;
                edit_base_fins_nof.Enabled = false;
                edit_base_fins_nol.Enabled = false;
                edit_base_fins_noq_nol.Enabled = false;
                edit_base_fins_noh_nol.Enabled = false;
                edit_base_fins_no.Enabled = false;
                txt_BASE_FINS_PAR_DESC.Enabled = false;
                edit_base_fins_health_self.Enabled = false;
                edit_base_fins_y65.Enabled = false;
                BASE_HEALTH_SELF_DESC.Enabled = false;
                edit_base_fin_amt.Enabled = false;
                edit_base_fin_sup_amt.Enabled = false;
            }
            else
            {
                edit_base_name.Enabled = true;
                edit_base_idno.Enabled = true;
                edit_base_ermk.Enabled = true;
                edit_base_prono.Visible = true;
                lb_edit_base_prono.Visible = false;
                edit_base_parttime.Enabled = true;
                edit_base_status.Enabled = true;
                edit_base_sex.Enabled = true;
                ddl_Depart4Edit.Enabled = true;
                edit_base_bdate.Enabled = true;
                edit_base_edate.Enabled = true;
                edit_base_proj_bdate.Enabled = true;
                edit_base_proj_edate.Enabled = true;
                edit_base_quit_date.Enabled = true;
                edit_base_quit_rezn.Visible = true;
                lb_edit_base_quit_rezn.Visible = false;
                ddl_Budget_code.Visible = true;
                lb_Budget_code.Visible = false;
                edit_base_dcodesys.Visible = true;
                lb_edit_base_dcodesys.Visible = false;
                edit_base_dcode.Visible = true;
                lb_edit_base_dcode.Visible = false;
                edit_base_org_l3.Visible = true;
                lb_edit_base_org_l3.Visible = false;
                edit_base_org_l1.Visible = true;
                lb_edit_base_org_l1.Visible = false;
                edit_base_in_l1.Visible = true;
                lb_edit_base_in_l1.Visible = false;
                edit_base_in_l3.Visible = true;
                lb_edit_base_in_l3.Visible = false;
                edit_base_org_l2.Visible = true;
                lb_edit_base_org_l2.Visible = false;
                edit_base_ptb_type.Enabled = true;
                edit_base_ptb.Enabled = true;
                edit_base_alt_amt.Enabled = true;
                edit_base_kdp.Visible = true;
                lb_edit_base_kdp.Visible = false;
                edit_base_kdp_series.Visible = true;
                lb_edit_base_kdp_series.Visible = false;
                edit_base_kdc_series.Visible = true;
                lb_edit_base_kdc_series.Visible = false;

                edit_base_kdc.Visible = true;
                lb_edit_base_kdc.Visible = false;
                edit_base_kdo.Enabled = true;
                edit_base_kdb.Visible = true;
                lb_edit_base_kdb.Visible = false;
                txtSchool.Enabled = true;
                edit_base_addr.Enabled = true;

                GridView GV = (GridView)UcSaBase_Kdo_1.FindControl("GridView_pitm");
                GV.Enabled = true;

                edit_base_govadof.Enabled = true;
                r_base_govadof.Enabled = true;
                RadioButtonList1.Enabled = true;
                edit_base_priz.Enabled = true;
                edit_base_pre.Enabled = true;
                edit_base_pred.Enabled = true;
                edit_base_pol.Enabled = true;
                cmb_base_hous.Enabled = true;
                edit_base_welg.Enabled = true;
                edit_base_tax.Enabled = true;
                edit_base_tax_dct.Enabled = true;
                edit_base_numerator.Enabled = true;
                edit_base_denominator.Enabled = true;
                edit_base_other_sal.Enabled = true;

                GridView GVOther = (GridView)ucSaBase_Other_Sal1.FindControl("GridView_Other_1");
                GVOther.Enabled = true;
                GridView GVOther2 = (GridView)ucSaBase_Other_Sal1.FindControl("GridView_Other_2");
                GVOther2.Enabled = true;

                edit_base_day_sal.Enabled = true;
                edit_base_hour_sal.Enabled = true;
                edit_base_fins_kind.Enabled = true;

                DropDownList base_labor_series = (DropDownList)edit_base_labor_series.FindControl("DropDownList_level");
                base_labor_series.Enabled = true;

                DropDownList base_fins_series = (DropDownList)edit_base_fins_series.FindControl("DropDownList_level");
                base_fins_series.Enabled = true;

                edit_base_lab_jif.Enabled = true;
                edit_base_lab1.Enabled = true;
                edit_base_lab2.Enabled = true;
                edit_base_lab3.Enabled = true;
                edit_base_pn_y30.Enabled = true;
                edit_base_pen_type.Enabled = true;

                DropDownList base_pen_series = (DropDownList)edit_base_pen_series.FindControl("DropDownList_level");
                base_pen_series.Enabled = true;

                edit_base_pen_rate.Enabled = true;
                edit_base_prov.Enabled = true;
                edit_base_fins_self.Enabled = true;
                edt_BASE_FINS_SELF_DESC.Enabled = true;
                edit_base_fins_noq.Enabled = true;
                edit_base_fins_noh.Enabled = true;
                edit_base_fins_nof.Enabled = true;
                edit_base_fins_nol.Enabled = true;
                edit_base_fins_noq_nol.Enabled = true;
                edit_base_fins_noh_nol.Enabled = true;
                edit_base_fins_no.Enabled = true;
                txt_BASE_FINS_PAR_DESC.Enabled = true;
                edit_base_fins_health_self.Enabled = true;
                edit_base_fins_y65.Enabled = true;
                BASE_HEALTH_SELF_DESC.Enabled = true;
                edit_base_fin_amt.Enabled = true;
                edit_base_fin_sup_amt.Enabled = true;
            }

        }
    }

    protected void GridView_SaBase_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strBaseSeqNO = GridView_SaBase.SelectedValue.ToString();
        getSingleUserData(strBaseSeqNO);
    }

    private void getSingleUserData(string strBaseSeqNO)
    {
        SAL3101 sal3101 = new SAL3101();
        DataTable dt = sal3101.querySalSaBaseBySeqNo(this.strOrgCode, strBaseSeqNO);
        initModifyPanel(dt);



        pnlQueryResult.Visible = false;
        pnlModify.Visible = true;
    }

    // 主管加給顯示與否
    protected void edit_base_kdc_CodeChanged(object sender, System.EventArgs e)
    {
        show_kdc(edit_base_kdc.SelectedValue);
    }

    // 專業加給顯示與否
    protected void edit_base_kdp_CodeChanged(object sender, System.EventArgs e)
    {
        show_kdp(edit_base_kdp.SelectedValue);
    }

    // 權理職等第一層改變
    protected void edit_base_in_l1_CodeChanged(object sender, System.EventArgs e)
    {
        // '' 主管加給
        this.GetKdc();
        // ''專業加給
        this.GetKdp();
    }

    // 俸階改變
    protected void edit_base_org_l2_CodeChanged(object sender, System.EventArgs e)
    {
        //' 俸點
        this.GetPoint();
        // '' 主管加給
        this.GetKdc();
        // ''專業加給
        this.GetKdp();
    }

    // 職等改變
    protected void edit_base_org_l1_CodeChanged(object sender, System.EventArgs e)
    {
        //' 俸點
        this.GetPoint();
        // '' 主管加給
        this.GetKdc();
        // ''專業加給
        this.GetKdp();
    }

    // 職別改變
    protected void edit_base_org_l3_CodeChanged(object sender, System.EventArgs e)
    {
        //' 俸點
        this.GetPoint();
        // '' 主管加給
        this.GetKdc();
        // ''專業加給
        this.GetKdp();
    }

    // 取得專業加給
    private void GetKdp()
    {
        edit_base_kdp_series.v_No = edit_base_kdp.SelectedValue;
    }

    // 取得主管加給
    private void GetKdc()
    {
        edit_base_kdc_series.v_No = edit_base_kdc.SelectedValue;
    }

    // 取得俸點
    private void GetPoint()
    {
        string v_point = "0";
        SAL3101 sal3101=new SAL3101();
        string strLevComOrgL1 = edit_base_org_l1.SelectedValue;   // 職等
        string strLevComOrgL2 = edit_base_org_l2.SelectedValue;   // 俸階
        string strLevComOrgL3 = edit_base_org_l3.SelectedValue;     // 職別

        DataTable dt = sal3101.querySaleCom(strLevComOrgL1, strLevComOrgL2, strLevComOrgL3);
        if (dt.Rows.Count > 0)
        {
            v_point = dt.Rows[0]["levcom_ptb"].ToString();
        }
        edit_base_ptb.Text = v_point;

    }

    // 重設
    private void resetModifyPanel()
    {
        // ID CARD
        string strSeqNO = "";

        edit_base_seqno.Text = strSeqNO;
        UcSaBase_Kdo_1.v_seqno = strSeqNO;
        ucSaBase_Bank_1.v_seqno = strSeqNO;

        edit_base_name.Text = "";  // 員工姓名
        edit_base_idno.Text = "";  // 身分證號

        ddl_Budget_code.Rebind();
        try {
            edit_base_prono.Rebind();
//            edit_base_prono.SelectedValue = row["BASE_PRONO"].ToString(); 
        }
        catch { } // 人員分類 
        edit_base_parttime.SelectedIndex = 0;// 兼職人員
        edit_base_status.SelectedIndex =0;// 現職員工
        try
        {
            edit_base_sex.SelectedIndex = 0; ;// 性別 
        }
        catch { }
        try
        {
            ddl_Depart4Edit.Orgcode = this.strOrgCode;
        }
        catch { }// 所屬單位
        // 簡任非主管(拿掉)
        // 到職日期
        edit_base_bdate.Text = "";
        // 離職日期
        edit_base_edate.Text = "";
        // 工作計畫日期起迄(不使用)
        edit_base_proj_bdate.Text = "";
        edit_base_proj_edate.Text = "";
        // 停職日期
        edit_base_quit_date.Text = "";
        // 停職給薪狀態
        try
        {
            edit_base_quit_rezn.Rebind();
        }
        catch
        {
        }
        // 職系
        try
        {
            edit_base_dcodesys.Rebind();
        }
        catch
        {
        }
        // 職稱
        try
        {
            edit_base_dcode.Rebind();
        }
        catch { }
        // 職等
        try
        {
            edit_base_org_l1.Rebind();
        }
        catch { }

        // 權理職等
        try
        {
            edit_base_in_l1.Rebind();
        }
        catch { }
        try
        {
            edit_base_in_l3.Rebind();
        }
        catch { }


        // 俸階 
        try
        {
            edit_base_org_l2.Rebind();
        }
        catch { }
        // 適用俸（薪）表
        try
        {
            edit_base_kdb.Rebind();
        }
        catch { }
        // 俸點(薪點)
        try
        {
            edit_base_ptb_type.SelectedIndex = 0; ;
        }
        catch { }
        edit_base_ptb.Text = "";
        edit_base_alt_amt.Text = "";

        // 專業加給
        try
        {
            edit_base_kdp.Rebind();
        }
        catch { }

        // 加給金額
        try
        {
//            edit_base_kdp_series.v_Series = edit_base_kdp.SelectedValue;
        }
        catch { }

        // 主管加給
        try
        {
            edit_base_kdc.Rebind();// .SelectedValue = row["BASE_KDC"].ToString();
        }
        catch { }
        // 加給金額
        try
        {
//            edit_base_kdc_series.v_Series = edit_base_kdc.SelectedValue;
        }
        catch { }

        // 協查研究費
        try
        {
            edit_base_kdo.SelectedIndex=0;// .SelectedValue = row["BASE_KDO"].ToString();
        }
        catch { }

        // 契約類型 (無用)
        // 學歷     (無用)
        // 學校名稱 (無用)
        // txtSchool (無用)

        // 連絡電話 ???????????????????????????
        // edit_base_tel.Text = row["BASE_KDO"].ToString();
        // 院內分機 ???????????????????????????
        // edit_base_telno.Text = row["BASE_KDO"].ToString();

        // 戶籍地址
        edit_base_addr.Text = "";
        // 聯絡地址 ??????????????????????????????
        // edit_base_addr2.Text = row["BASE_ADDR"].ToString();

        // E-Mail
      //  edit_base_email.Text = "";
        base_email.Text = "";
        // 以e-mail寄發薪水條
        try
        {
            edit_base_sentmail.Checked = false;// row["BASE_SENTMAIL"].ToString() == "Y";
        }
        catch { }

        // 車號??????????????????????
        // edit_base_carno.Text    = 
        // 車輛使用人????????????????
        // edit_base_bossname.Text     = 

        // 政務官離職儲金
        try
        {
            edit_base_govadof.Checked = false;// row["BASE_GOVADOF"].ToString() == "Y";
        }
        catch { }
        try
        {
            r_base_govadof.SelectedIndex =0;// .SelectedValue = row["BASE_GOVADOF"].ToString();
        }
        catch
        {
        }
        // 退休喪亡互助金 ??????????????
        // 年終獎金
        try
        {
            edit_base_priz.SelectedIndex=0;// .SelectedValue = row["BASE_PRIZ"].ToString();
        }
        catch { }
        // 退撫離職
        edit_base_pre.Text = "";
        // 機關負擔
        edit_base_pred.Text = "";
        // 其他薪金項目勾選
        // 警務津貼
        edit_base_pol.Checked = false;// row["BASE_POL"].ToString() == "Y";
        // 房屋津貼
        edit_base_hous_YN.Checked = false;// row["BASE_HOUS"].ToString() != "";
        try
        {
            edit_base_hous.Rebind();// .SelectedValue = row["BASE_HOUS"].ToString();
        }
        catch { }
        cmb_base_hous.SelectedIndex = 0;
        // 退休喪亡互助金
        try
        {
            edit_base_welg.Checked = false;// row["BASE_WELG"].ToString() == "Y";
        }
        catch { }
        // 所得稅扣繳
        try
        {
            edit_base_tax.SelectedIndex=0;// .SelectedValue = row["BASE_TAX"].ToString();
        }
        catch { }
        // 定額扣繳額
        edit_base_tax_dct.Text = "";
        // (分子/分母)(完全中學適用)????????????????????
        edit_base_numerator.Text = "";
        edit_base_denominator.Text = "";

        // 其他應發代扣項目
        try
        {
            edit_base_other_sal.SelectedIndex=0;// .SelectedValue = row["BASE_OTHER_SAL"].ToString();
        }
        catch { }

        // 日薪
        edit_base_day_sal.Text = "";// row["BASE_DAY_SAL"].ToString();
        // 時薪
        edit_base_hour_sal.Text = "";//row["BASE_HOUR_SAL"].ToString();

        // 保險種類
        try
        {
            edit_base_fins_kind.SelectedIndex=0;// .SelectedValue = row["BASE_FINS_KIND"].ToString();
        }
        catch { }
        // 勞保年滿65歲
        edit_base_lab_jif.Checked = false;// (row["BASE_LAB_JIF"].ToString() == "Y");
        // 普通事故
        edit_base_lab1.Checked = false;// (row["BASE_LAB1"].ToString() == "Y");
        // 就業保險
        edit_base_lab2.Checked = false;// (row["BASE_LAB2"].ToString() == "Y");
        // 職業災害
        edit_base_lab3.Checked = false;// (row["BASE_LAB3"].ToString() == "Y");

        // 公(軍)保年資
        edit_base_pn_y30.Checked = false;// (row["BASE_PN_Y30"].ToString() == "Y");
        // 勞工退休金
        try
        {
            edit_base_pen_type.SelectedIndex = 0;// .SelectedValue = row["BASE_PEN_TYPE"].ToString();
        }
        catch { }
        // 勞工退休金自行提繳率
        edit_base_pen_rate.Text = "";
        // 預定退休日 ????????????????????????????????????????????????????????????????????
        // UcDateTextBox_RetireDate.Text   = ;
        // 勞工平均月退金額 ??????????????????????????????????????????????????????????????
        // lblRetireAmt.Text
        // 扶養人數
        edit_base_prov.Text = "";
        // 保險自付註記
        try
        {
            edit_base_fins_self.SelectedIndex=0;// .SelectedValue = row["BASE_FINS_SELF"].ToString();
        }
        catch { }
        // 健保自付3/4口數(輕殘/菸捐)
        edit_base_fins_noq.Text = "";
        // ●健保自付1/2口數(中殘/菸捐)
        edit_base_fins_noh.Text = "";

        // 健保免繳口數(重殘及低收入戶)
        edit_base_fins_nof.Text = "";

        // 健保地方補助口數(65歲以上長者)
        edit_base_fins_nol.Text = "";

        // 健保自付3/4且是地方補助<u>雙重身份</u>口數(輕殘/菸捐+65歲以上長者)
        edit_base_fins_noq_nol.Text = "";

        // 健保自付1/2且是地方補助<u>雙重身份</u>口數(中殘/菸捐+65歲以上長者)
        edit_base_fins_noh_nol.Text = "";
        // 健保眷口總人數
        edit_base_fins_no.Text = "";

        // 健保自付註記
        try
        {
            edit_base_fins_health_self.SelectedIndex=0;// .SelectedValue = row["BASE_FINS_SELF"].ToString();
        }
        catch { }
        // 55歲原住民
        try
        {
            edit_base_fins_y65.SelectedIndex=0;// .SelectedValue = row["BASE_FINS_Y65"].ToString();
        }
        catch { }
        // 個人健保標準金額
        edit_base_fin_amt.Text = "";
        // 機關負擔健保金額
        edit_base_fin_sup_amt.Text = "";
        // 實物代金眷口數
        edit_base_dct_a.Text = "";
        edit_base_dct_b.Text = "";
        edit_base_dct_b.Text = "";
        // 個人實物代金註記
        try
        {
            edit_base_replace_amt.SelectedIndex=0;// .SelectedValue = row["BASE_REPLACE_AMT"].ToString();
        }
        catch { }
        // 《退休人員資訊》
        // 是否退休 ?????????????????????????????
        try
        {
            //rblRetire.SelectedValue = 
        }
        catch { }
        // 是否可領取</br>三節慰問金????????????
        try
        {
            //            rblYearamt.SelectedValue
        }
        catch { }
        // 退撫種類
        try
        {
            //            rblRetireType.SelectedValue
        }
        catch { }
        // 是否為遺族???????????????????
        // rblFamily.SelectedIndex
        // 原退休人員姓名 ??????????????
        // 其他帳戶

        // 選擇備註欄?????????????
        try
        {
            //            edit_base_memo_sel.SelectedValue = row[""].ToString();
        }
        catch { }

        // 備註一
        edit_base_memo1.Text = "";
        edit_base_memo2.Text = "";
        edit_base_memo3.Text = "";

        // 保險自付減免原因說明
        edt_BASE_FINS_SELF_DESC.Text = "";
        // 保險眷口負擔減免原因說明
        txt_BASE_FINS_PAR_DESC.Text = "";
        //貸款總金額	BASE_RAMT
        txt_BASE_RAMT.Text = "0";// (row["BASE_RAMT"].ToString().Trim() == "") ? "0" : row["BASE_RAMT"].ToString().Trim();
        // 尚未清償金額	BASE_NAMT
        txt_BASE_NAMT.Text = "0";//(row["BASE_NAMT"].ToString().Trim() == "") ? "0" : row["BASE_NAMT"].ToString().Trim();
        // 每月清償金額	BASE_MAMT
        txt_BASE_MAMT.Text = "0";//(row["BASE_MAMT"].ToString().Trim() == "") ? "0" : row["BASE_MAMT"].ToString().Trim();

        // 列印順序 
        txt_BASE_PRTS.Text = "999";// (row["BASE_PRTS"].ToString().Trim() == "") ? "999" : row["BASE_PRTS"].ToString().Trim();

        BASE_HEALTH_SELF_DESC.Text = "";
    }

    private void initModifyPanel(DataTable dt)
    {

        resetModifyPanel();
        DataRow row = dt.Rows[0];

        // ID CARD
        string strSeqNO = row["BASE_SEQNO"].ToString();

        edit_base_seqno.Text = strSeqNO;

        ucSaBase_Bank_1.v_seqno = strSeqNO;

        edit_base_name.Text = row["BASE_NAME"].ToString();  // 員工姓名
        edit_base_idno.Text = row["BASE_IDNO"].ToString();  // 身分證號
        try 
        {
            lb_edit_base_prono.Text = "";
            edit_base_prono.SelectedValue = row["BASE_PRONO"].ToString();
            lb_edit_base_prono.Text = edit_base_prono.SelectedItem.Text;
        }
        catch { } // 人員分類 
        edit_base_parttime.SelectedValue = row["BASE_PARTTIME"].ToString();// 兼職人員
        edit_base_status.SelectedValue = row["BASE_STATUS"].ToString();// 現職員工

        lb_Budget_code.Text = "";
        if(row["BASE_Budget_code"].ToString() !="")
        ddl_Budget_code.SelectedValue = row["BASE_Budget_code"].ToString();//預算來源
        lb_Budget_code.Text = ddl_Budget_code.SelectedItem.Text;

        try
        {
            edit_base_sex.SelectedValue = row["BASE_SEX"].ToString();// 性別 
        }
        catch { }
        try
        {
            ddl_Depart4Edit.SelectedValue = row["BASE_DEP"].ToString();
        }
        catch { }// 所屬單位
        // 簡任非主管(拿掉)
        // 到職日期
        edit_base_bdate.Text = SAL3101.DateStrToROCDateStr(row["BASE_BDATE"].ToString());
        // 離職日期
        edit_base_edate.Text = SAL3101.DateStrToROCDateStr(row["BASE_EDATE"].ToString());
        // 工作計畫日期起迄(不使用)
        edit_base_proj_bdate.Text = SAL3101.DateStrToROCDateStr(row["BASE_PROJ_BDATE"].ToString());
        edit_base_proj_edate.Text = SAL3101.DateStrToROCDateStr(row["BASE_PROJ_EDATE"].ToString());
        // 停職日期
        edit_base_quit_date.Text = SAL3101.DateStrToROCDateStr(row["BASE_QUIT_DATE"].ToString());
        // 停職給薪狀態
        try
        {
            lb_edit_base_quit_rezn.Text = "";
            edit_base_quit_rezn.SelectedValue = row["BASE_QUIT_REZN"].ToString();
            lb_edit_base_quit_rezn.Text = edit_base_quit_rezn.SelectedItem.Text;
        }
        catch
        {
        }

        // 官等
        try
        {
            lb_edit_base_org_l3.Text = "";
            edit_base_org_l3.SelectedValue = row["base_org_l3"].ToString();
            lb_edit_base_org_l3.Text = edit_base_org_l3.SelectedItem.Text;
        }
        catch
        {
        }

        // 職系
        try
        {
            lb_edit_base_dcodesys.Text = "";
            edit_base_dcodesys.SelectedValue = row["BASE_JOB"].ToString();
            lb_edit_base_dcodesys.Text = edit_base_dcodesys.SelectedItem.Text;
        }
        catch
        {
        }
        // 職稱
        try
        {
            lb_edit_base_dcode.Text = "";
            edit_base_dcode.SelectedValue = row["BASE_DCODE"].ToString();
            lb_edit_base_dcode.Text = edit_base_dcode.SelectedItem.Text;
        }
        catch { }
        // 職等
        try
        {
            lb_edit_base_org_l1.Text = "";
            edit_base_org_l1.SelectedValue = row["BASE_ORG_L1"].ToString();
            lb_edit_base_org_l1.Text = edit_base_org_l1.SelectedItem.Text;
        }
        catch { }

        // 權理職等
        try
        {
            lb_edit_base_in_l1.Text = "";
            edit_base_in_l1.SelectedValue = row["BASE_IN_L1"].ToString();
            lb_edit_base_in_l1.Text = edit_base_in_l1.SelectedItem.Text;
        }
        catch { }
        try
        {
            lb_edit_base_in_l3.Text = "";
            edit_base_in_l3.SelectedValue = row["BASE_IN_L3"].ToString();
            lb_edit_base_in_l3.Text = edit_base_in_l3.SelectedItem.Text;
        }
        catch { }


        // 俸階 
        try
        {
            lb_edit_base_org_l2.Text = "";
            edit_base_org_l2.SelectedValue = row["BASE_ORG_L2"].ToString();
            lb_edit_base_org_l2.Text = edit_base_org_l2.SelectedItem.Text;
        }
        catch { }
        // 適用俸（薪）表
        try
        {
            lb_edit_base_kdb.Text = "";
            edit_base_kdb.SelectedValue = row["BASE_KDB"].ToString();
            lb_edit_base_kdb.Text = edit_base_kdb.SelectedItem.Text;
        }
        catch { }
        // 俸點(薪點)
        try
        {
            edit_base_ptb_type.SelectedValue = row["BASE_PTB_TYPE"].ToString();
        }
        catch { }

        edit_base_ptb.Text = row["BASE_PTB"].ToString();
        edit_base_alt_amt.Text = row["BASE_ALT_AMT"].ToString();

        int value = Convert.ToInt32(edit_base_ptb_type.SelectedValue);
        switch (value)
        {
            case 1:
                this.div_ptb_1.Visible = true;
                this.div_ptb_2.Visible = false;
                break;
            case 2:
                this.div_ptb_1.Visible = false;
                this.div_ptb_2.Visible = true;
                break;
        }


        // 專業加給
        try
        {
            lb_edit_base_kdp.Text = "";
            edit_base_kdp.SelectedValue = row["BASE_KDP"].ToString();
            lb_edit_base_kdp.Text = edit_base_kdp.SelectedItem.Text;
        }
        catch { }

        show_kdp(edit_base_kdp.SelectedValue);
        //Response.Write(edit_base_kdp.SelectedValue);
        // 專業加給金額
//        Response.Write(row["BASE_KDP_SERIES"].ToString()+"<BR>");
        try
        {
            lb_edit_base_kdp_series.Text = "";
            edit_base_kdp_series.DataBind();
            edit_base_kdp_series.v_Series = row["BASE_KDP_SERIES"].ToString();

            DropDownList DropDownList_series = (DropDownList)edit_base_kdp_series.FindControl("DropDownList_series");
            lb_edit_base_kdp_series.Text = DropDownList_series.SelectedItem.Text;
        }
        catch {
//            Response.Write("Error<BR>");
        }
//        Response.Write(edit_base_kdp_series.v_Series + "<BR>");


        // 主管加給
        try
        {
            lb_edit_base_kdc.Text = "";
            edit_base_kdc.SelectedValue = row["BASE_KDC"].ToString();
            lb_edit_base_kdc.Text = edit_base_kdc.SelectedItem.Text;
        }
        catch { }

        show_kdc(edit_base_kdc.SelectedValue);

        // 加給金額
        try
        {
            lb_edit_base_kdc_series.Text = "";

            edit_base_kdc_series.DataBind();
            edit_base_kdc_series.v_Series = row["BASE_KDC_SERIES"].ToString();

            DropDownList DropDownList_series = (DropDownList)edit_base_kdc_series.FindControl("DropDownList_series");
            lb_edit_base_kdc_series.Text = DropDownList_series.SelectedItem.Text;
        }
        catch { 
//            Response.Write("error");
                
        }



        // 協查研究費
        try
        {
            edit_base_kdo.SelectedValue = row["BASE_KDO"].ToString();
        }
        catch { }

        // 契約類型 (無用)
        // 學歷     (無用)
        // 學校名稱 (無用)
        // txtSchool (無用)

        // 連絡電話 ???????????????????????????
        // edit_base_tel.Text = row["BASE_KDO"].ToString();
        // 院內分機 ???????????????????????????
        // edit_base_telno.Text = row["BASE_KDO"].ToString();

        // 戶籍地址
        edit_base_addr.Text = row["BASE_ADDR"].ToString();
        // 聯絡地址 ??????????????????????????????
        // edit_base_addr2.Text = row["BASE_ADDR"].ToString();

        // E-Mail
 //       edit_base_email.Text = row["BASE_EMAIL"].ToString();
        base_email.Text = row["BASE_EMAIL"].ToString();
        // 以e-mail寄發薪水條
        try
        {
            edit_base_sentmail.Checked = row["BASE_SENTMAIL"].ToString() == "Y";
        }
        catch { }

        // 車號??????????????????????
        // edit_base_carno.Text    = 
        // 車輛使用人????????????????
        // edit_base_bossname.Text     = 

        // 政務官離職儲金
        try
        {
            edit_base_govadof.Checked = row["BASE_GOVADOF"].ToString() == "Y";
        }
        catch { }
        try
        {
            r_base_govadof.SelectedValue = row["BASE_GOVADOF"].ToString();
        }
        catch
        {
        }
        // 退休喪亡互助金 ??????????????
        // 年終獎金
        try
        {
            edit_base_priz.SelectedValue = row["BASE_PRIZ"].ToString();
        }
        catch { }
        // 退撫離職
        edit_base_pre.Text = row["BASE_PRE"].ToString();
        // 機關負擔
        edit_base_pred.Text = row["BASE_PRED"].ToString();
        // 其他薪金項目勾選
        // 警務津貼
        edit_base_pol.Checked = row["BASE_POL"].ToString() == "Y";
        // 房屋津貼
//        edit_base_hous_YN.Checked = row["BASE_HOUS"].ToString() != "";
        try
        {
            cmb_base_hous.SelectedValue = row["BASE_HOUS"].ToString();
//            edit_base_hous.SelectedValue = row["BASE_HOUS"].ToString();
        }
        catch { }
        // 退休喪亡互助金
        try
        {
            edit_base_welg.Checked = row["BASE_WELG"].ToString() == "Y";
        }
        catch { }
        // 所得稅扣繳
        try
        {
            edit_base_tax.SelectedValue = row["BASE_TAX"].ToString();
        }
        catch { }
        // 定額扣繳額
        edit_base_tax_dct.Text = row["BASE_TAX_DCT"].ToString();
        // (分子/分母)(完全中學適用)????????????????????
        edit_base_numerator.Text = row["BASE_NUMERATOR"].ToString();
        edit_base_denominator.Text = row["BASE_DENOMINATOR"].ToString();

        // 其他應發代扣項目
        try
        {
            edit_base_other_sal.SelectedValue = row["BASE_OTHER_SAL"].ToString();
        }
        catch { }

        // 日薪
        edit_base_day_sal.Text = row["BASE_DAY_SAL"].ToString();
        // 時薪
        edit_base_hour_sal.Text = row["BASE_HOUR_SAL"].ToString();

        // 保險種類
        try
        {
            edit_base_fins_kind.SelectedValue = row["BASE_FINS_KIND"].ToString();
        }
        catch { }
        // 勞保年滿65歲
        edit_base_lab_jif.Checked = (row["BASE_LAB_JIF"].ToString() == "Y");
        // 普通事故
        edit_base_lab1.Checked = (row["BASE_LAB1"].ToString() == "Y");
        // 就業保險
        edit_base_lab2.Checked = (row["BASE_LAB2"].ToString() == "Y");
        // 職業災害
        edit_base_lab3.Checked = (row["BASE_LAB3"].ToString() == "Y");

        // 公(軍)保年資
        edit_base_pn_y30.Checked = (row["BASE_PN_Y30"].ToString() == "Y");
        // 勞工退休金
        try
        {
            edit_base_pen_type.SelectedValue = row["BASE_PEN_TYPE"].ToString();
        }
        catch { }
        // 勞工退休金自行提繳率
        edit_base_pen_rate.Text = row["BASE_PEN_RATE"].ToString();
        // 預定退休日 ????????????????????????????????????????????????????????????????????
        // UcDateTextBox_RetireDate.Text   = ;
        // 勞工平均月退金額 ??????????????????????????????????????????????????????????????
        // lblRetireAmt.Text
        // 扶養人數
        edit_base_prov.Text = row["BASE_PROV"].ToString();
        // 保險自付註記
        try
        {
            edit_base_fins_self.SelectedValue = row["BASE_FINS_SELF"].ToString();
        }
        catch { }
        // 健保自付3/4口數(輕殘/菸捐)
        edit_base_fins_noq.Text = row["BASE_FINS_NOQ"].ToString();
        // ●健保自付1/2口數(中殘/菸捐)
        edit_base_fins_noh.Text = row["BASE_FINS_NOH"].ToString();

        // 健保免繳口數(重殘及低收入戶)
        edit_base_fins_nof.Text = row["BASE_FINS_NOF"].ToString();

        // 健保地方補助口數(65歲以上長者)
        edit_base_fins_nol.Text = row["BASE_FINS_NOL"].ToString();

        // 健保自付3/4且是地方補助<u>雙重身份</u>口數(輕殘/菸捐+65歲以上長者)
        edit_base_fins_noq_nol.Text = row["base_fins_noq_nol"].ToString();

        // 健保自付1/2且是地方補助<u>雙重身份</u>口數(中殘/菸捐+65歲以上長者)
        edit_base_fins_noh_nol.Text = row["base_fins_noh_nol"].ToString();
        // 健保眷口總人數
        edit_base_fins_no.Text = row["BASE_FINS_NO"].ToString();

        // 健保自付註記
        try
        {
            edit_base_fins_health_self.SelectedValue = row["BASE_FINS_SELF"].ToString();
        }
        catch { }
        // 55歲原住民
        try
        {
            edit_base_fins_y65.SelectedValue = row["BASE_FINS_Y65"].ToString();
        }
        catch { }
        // 個人健保標準金額
        edit_base_fin_amt.Text = row["BASE_FIN_AMT"].ToString();
        // 機關負擔健保金額
        edit_base_fin_sup_amt.Text = row["BASE_FIN_SUP_AMT"].ToString();
        // 實物代金眷口數
        edit_base_dct_a.Text = row["BASE_DCT_A"].ToString();
        edit_base_dct_b.Text = row["BASE_DCT_B"].ToString();
        edit_base_dct_b.Text = row["BASE_DCT_C"].ToString();
        // 個人實物代金註記
        try
        {
            edit_base_replace_amt.SelectedValue = row["BASE_REPLACE_AMT"].ToString();
        }
        catch { }
        // 《退休人員資訊》
        // 是否退休 ?????????????????????????????
        try
        {
            //rblRetire.SelectedValue = 
        }catch{}
        // 是否可領取</br>三節慰問金????????????
        try
        {
//            rblYearamt.SelectedValue
        }
        catch{}
        // 退撫種類
        try
        {
//            rblRetireType.SelectedValue
        }
        catch { }
        // 是否為遺族???????????????????
        // rblFamily.SelectedIndex
        // 原退休人員姓名 ??????????????
        // 其他帳戶

        // 選擇備註欄?????????????
        try
        {
//            edit_base_memo_sel.SelectedValue = row[""].ToString();
        }
        catch { }

        // 備註一
        edit_base_memo1.Text = row["BASE_MEMO1"].ToString();
        edit_base_memo2.Text = row["BASE_MEMO2"].ToString();
        edit_base_memo3.Text = row["BASE_MEMO3"].ToString();

        // 保險自付減免原因說明
        edt_BASE_FINS_SELF_DESC.Text = row["BASE_FINS_SELF_DESC"].ToString();
        // 保險眷口負擔減免原因說明
        txt_BASE_FINS_PAR_DESC.Text = row["BASE_FINS_PAR_DESC"].ToString();
        //貸款總金額	BASE_RAMT
        txt_BASE_RAMT.Text  = (row["BASE_RAMT"].ToString().Trim()=="")?"0":row["BASE_RAMT"].ToString().Trim();
        // 尚未清償金額	BASE_NAMT
        txt_BASE_NAMT.Text  = (row["BASE_NAMT"].ToString().Trim()=="")?"0":row["BASE_NAMT"].ToString().Trim();
        // 每月清償金額	BASE_MAMT
        txt_BASE_MAMT.Text = (row["BASE_MAMT"].ToString().Trim() == "") ? "0" : row["BASE_MAMT"].ToString().Trim();

        // 列印順序 
        txt_BASE_PRTS.Text = (row["BASE_PRTS"].ToString().Trim() == "") ? "999" : row["BASE_PRTS"].ToString().Trim();

        BASE_HEALTH_SELF_DESC.Text = row["BASE_HEALTH_SELF_DESC"].ToString();



        UcSaBase_Kdo_1.v_orgid = this.strOrgCode;
        //        UcSaBase_Kdo_1.v_org_l3 = edit_base_org_l3.SelectedValue;
        //        UcSaBase_Kdo_1.v_org_l1 = edit_base_org_l1.SelectedValue;
        UcSaBase_Kdo_1.v_seqno = strSeqNO;

        ucSaBase_Other_Sal1.v_orgid = this.strOrgCode; ;
        ucSaBase_Other_Sal1.v_seqno = strSeqNO;



        
        show_other(edit_base_other_sal.SelectedValue);
        show_kdo(edit_base_kdo.SelectedValue);
        show_fins_kind(edit_base_fins_kind.SelectedValue);
        show_pen_type(edit_base_pen_type.SelectedValue);

//        edit_base_labor_series.DataBind();
//        Response.Write(row["Base_labor_series"].ToString().Trim()+"<BR>");
        try
        {
            edit_base_labor_series.v_Level = row["Base_labor_series"].ToString().Trim();
            edit_base_labor_series.DataBind();
        }
        catch
        {
        }
//        Response.Write(edit_base_labor_series.v_Level + "<BR>");
        
        try
        {
            edit_base_fins_series.v_Level = row["Base_fins_series"].ToString().Trim();
            edit_base_fins_series.DataBind();
        }
        catch
        {
        }
        
        try
        {
            edit_base_pen_series.v_Level = row["Base_pen_series"].ToString().Trim();
            edit_base_pen_series.DataBind();
        }
        catch
        {
        }
        
//        UcSaBase_Kdo_1.v_seqno;
    }

    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (RadioButtonList3.SelectedValue)
        {
            case "1":
                divshowDate.Visible = true;
                this.lbl.Text = "簡任非主管/起支日期";
                break;
            case "2":
                divshowDate.Visible = false;
                this.lbl.Text = "簡任非主管";
                break;
        }
    }

    protected void edit_base_ptb_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value = Convert.ToInt32(edit_base_ptb_type.SelectedValue);
        switch (value)
        {
            case 1:
                this.div_ptb_1.Visible = true;
                this.div_ptb_2.Visible = false;
                break;
            case 2:
                this.div_ptb_1.Visible = false;
                this.div_ptb_2.Visible = true;
                break;
        }
    }

    protected void edit_base_hous_YN_CheckedChanged(object sender, EventArgs e)
    {
        if (edit_base_hous_YN.Checked)
        {
            this.div_hous.Visible = true;
        }
        else
        {
            try
            {
                this.edit_base_hous.SelectedValue = "0";
            }
            catch { }
            this.div_hous.Visible = false;
        }

    }

    // 所得稅扣繳更改
    protected void edit_base_tax_SelectedIndexChanged(object sender, EventArgs e)
    {
        show_tax(Convert.ToInt32(edit_base_tax.SelectedValue));
    }

    // 顯示所得稅扣繳與否
    protected void show_tax(int value)
    {
        switch (value)
        {
            case 2:
                this.div_tax_1.Visible = true;
                this.div_tax_2.Visible = false;
                this.edit_base_numerator.Text = "1";
                this.edit_base_denominator.Text = "1";
                break;
            case 3:
                this.div_tax_1.Visible = false;
                this.edit_base_tax_dct.Text = "0";
                this.div_tax_2.Visible = true;
                break;
            case 4:
                this.div_tax_1.Visible = true;
                this.div_tax_2.Visible = true;
                break;
            default:
                this.div_tax_1.Visible = false;
                this.edit_base_tax_dct.Text = "0";
                this.div_tax_2.Visible = false;
                this.edit_base_numerator.Text = "1";
                this.edit_base_denominator.Text = "1";
                break;
        }
    }

    protected void edit_base_fins_kind_SelectedIndexChanged(object sender, EventArgs e)
    {
        //edit_base_fins_kind.Items[0].Text = edit_base_fins_kind.SelectedValue;
        show_fins_kind(edit_base_fins_kind.SelectedValue);

   /*     if (edit_base_fins_kind.SelectedValue == "001")
        {
            fins_kind.Visible = false;
        }
        else
        {
            fins_kind.Visible = true;
        }*/
    }

    // 保險種類改變
    protected void show_fins_kind(string value)
    {
        this.edit_base_labor_series.v_Ym = DateTime.Now.ToString("yyyyMM");
//            System.DateTime.Now.Year * 100 + 
//            System.DateTime.Now.Month.ToString().PadLeft(2, '0');
        this.edit_base_fins_series.v_Ym = DateTime.Now.ToString("yyyyMM"); 
//            System.DateTime.Now.Year * 100 + 
//            System.DateTime.Now.Month.ToString().PadLeft(2, '0');
        
        if (value == "002" || value == "003")
        {

            //' 勞保級距
            this.div_fins_series.Visible = true;
            
            //' 公(軍)保年資
            this.edit_base_pn_y30.Enabled = false;
            edit_base_pn_y30.Checked = false;
//            v_base_pn_y30 = "N";
            //' 勞工退休金
            this.div_pen_tpye.Visible = true;

            show_pen_type(edit_base_pen_type.SelectedValue);

            //' 勞保滿65歲
            if (value == "002")
            {
                this.div_fins_y65.Visible = true;
            }
            else
            {
                this.div_fins_y65.Visible = false;
            }

            //' 勞保自訂選項
            if (value == "003")
            {
                this.div_labor_chk.Visible = true;
            }
            else
            {
                this.div_labor_chk.Visible = false;
            }

        }
        else
        {

            //' 勞保級距
            this.div_fins_series.Visible = false;
            //' 公(軍)保年資
            this.edit_base_pn_y30.Enabled = true;
            //' 勞工退休金
            this.div_pen_tpye.Visible = false;
 //           show_pen_type("0");

            this.div_fins_y65.Visible = false;
            this.div_labor_chk.Visible = false;

            this.div_pen_rate.Visible = false;
            this.div_pen_series.Visible = false;		
        }
    }

    protected void show_pen_type(string value)
    {
        if (value == "2") 
        {
		    this.div_pen_rate.Visible = true;
		    this.div_pen_series.Visible = true;
	    }
        else
        {
		    this.div_pen_rate.Visible = false;
		    this.div_pen_series.Visible = false;		
	    }
    }


    protected void edit_base_pen_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        show_pen_type(edit_base_pen_type.SelectedValue);
    }

    // 是否為遺族改變
    protected void rblFamily_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((this.rblFamily.SelectedValue == "Y"))
        {
            this.lbOriScript.Visible = true;
            lbOriName.Visible = true;
        }
        else
        {
            this.lbOriScript.Visible = false;
            lbOriName.Visible = false;
        }
    }

    // 修改
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (ddl_Budget_code.SelectedValue == "N")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇預算來源", "", "");
            this.Page = tempPage; 
            return;
        }

        string BASE_IDNO   = edit_base_idno.Text.Trim();
        if (!isIdentificationId(BASE_IDNO))
        {
            edit_base_ermk.Checked = true;
            /*
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "身份證字號錯誤！", "", "");
            this.Page = tempPage; return;
             * */
        }
        else
        {
            edit_base_ermk.Checked = false;
        }

        string BASE_STATUS  = edit_base_status.SelectedValue;
        string BASE_TYPE    = "";   //非員工時用(1個人,2外僑,3公司)
        string BASE_ORGID   = this.strOrgCode;
        string BASE_NAME    = edit_base_name.Text.Trim();
        string BASE_SEX     = edit_base_sex.Text.Trim();
        string BASE_JOB_DATE= SAL3101.ROCDateStrToDateStr(edit_base_job_date.Text.Trim());
        string BASE_DEP     = ddl_Depart4Edit.SelectedValue;
        string BASE_BDATE   = SAL3101.ROCDateStrToDateStr(edit_base_bdate.Text.Trim());
        string BASE_EDATE   = SAL3101.ROCDateStrToDateStr(edit_base_edate.Text.Trim());
        string BASE_JOB     = edit_base_dcodesys.SelectedValue;
        string BASE_DCODE   = edit_base_dcode.SelectedValue;
        string BASE_ORG_L1  = edit_base_org_l1.SelectedValue;
        string BASE_ORG_L2  = edit_base_org_l2.SelectedValue;
        string BASE_ORG_L3  = edit_base_org_l3.SelectedValue;
        string BASE_AGEN    = "";   // 是否代理 , 前端無
        string BASE_IN_L1   = edit_base_in_l1.SelectedValue;
        string BASE_IN_L3   = edit_base_in_l3.SelectedValue;
        // 俸點+
        string BASE_PTB = (edit_base_ptb.Text.Trim() == "") ? "0" : edit_base_ptb.Text.Trim();// edit_base_ptb_type.SelectedValue;
        string BASE_PROV    = edit_base_prov.Text.Trim();
        string BASE_ADDR    = edit_base_addr.Text.Trim();
        string BASE_QUIT_DATE   = SAL3101.ROCDateStrToDateStr(edit_base_quit_date.Text.Trim());
        string BASE_QUIT_REZN   = edit_base_quit_rezn.SelectedValue;
        string BASE_ERMK = (edit_base_ermk.Checked) ? "Y" : "N";
        string BASE_PRONO       = edit_base_prono.SelectedValue;
        string BASE_KDB         = edit_base_kdb.SelectedValue;
        string BASE_KDC         = edit_base_kdc.SelectedValue;
        string BASE_KDP         = edit_base_kdp.SelectedValue;
        string BASE_KDO         = edit_base_kdo.SelectedValue;
        string BASE_POL         = (edit_base_pol.Checked)?"Y":"N";
//        string BASE_HOUS = (edit_base_hous_YN.Checked) ? "Y" : "N";
        string BASE_HOUS = cmb_base_hous.SelectedValue;
        string BASE_WELG = (edit_base_welg.Checked) ? "Y" : "N";    // 無用
        string BASE_WELO        = "";// 無用
        string BASE_PRE         = (edit_base_pre.Text=="")?"0":edit_base_pre.Text;
        string BASE_OTHER_SAL   = edit_base_other_sal.SelectedValue;
        string BASE_PRED        = edit_base_pred.Text;
        string BASE_PRIZ        = edit_base_priz.SelectedValue;
        string BASE_TAX         = edit_base_tax.SelectedValue;
        string BASE_FINS_KIND   = edit_base_fins_kind.SelectedValue;
        string BASE_PN_Y30      = (edit_base_pn_y30.Checked)?"Y":"N";
        string BASE_FINS_NOQ    = (edit_base_fins_noq.Text.Trim()=="")?"0":edit_base_fins_noq.Text.Trim();
        string BASE_FINS_NOH    = (edit_base_fins_noh.Text.Trim()=="")?"0":edit_base_fins_noh.Text.Trim(); 
        string BASE_FINS_NOF    = (edit_base_fins_nof.Text.Trim()=="")?"0":edit_base_fins_nof.Text.Trim(); 
        string BASE_FINS_NOL    = (edit_base_fins_nol.Text.Trim()=="")?"0":edit_base_fins_nol.Text.Trim();
        string BASE_FINS_SELF = edit_base_fins_self.SelectedValue;
        string BASE_FINS_NO     = (edit_base_fins_no.Text.Trim()=="")?"0":edit_base_fins_no.Text.Trim(); 
        string BASE_DAY_SAL     = (edit_base_day_sal.Text.Trim()=="")?"0":edit_base_day_sal.Text.Trim(); 
        string BASE_HOUR_SAL    = (edit_base_hour_sal.Text.Trim()=="")?"0":edit_base_hour_sal.Text.Trim(); 
        string BASE_DCT_A       = (edit_base_dct_a.Text.Trim()=="")?"0":edit_base_dct_a.Text.Trim(); 
        string BASE_DCT_B       = (edit_base_dct_b.Text.Trim()=="")?"0":edit_base_dct_b.Text.Trim(); 
        string BASE_DCT_C       = (edit_base_dct_c.Text.Trim()=="")?"0":edit_base_dct_c.Text.Trim(); 
        string BASE_COUNT_REMARK="Y";   // 計算註記(Y/N)
        string BASE_MEMO        = edit_base_memo.Text.Trim();
        if (edit_base_memo_sel.SelectedValue == "1")
        {
            BASE_MEMO = edit_base_memo1.Text.Trim(); 
        }
        else if (edit_base_memo_sel.SelectedValue == "2")
        {
            BASE_MEMO = edit_base_memo2.Text.Trim();
        }
        else if (edit_base_memo_sel.SelectedValue == "3")
        {
            BASE_MEMO = edit_base_memo3.Text.Trim();
        }
        string BASE_MUSER       = this.strLogIDCard;
        string BASE_MDATE       = DateTime.Now.ToString("yyyyMMdd");
        string BASE_KDC_SERIES = edit_base_kdc_series.v_Series;
        string BASE_KDP_SERIES = edit_base_kdp_series.v_Series;
//        string BASE_KDC_SERIES = edit_base_kdc_series.v_No;
//        string BASE_KDP_SERIES = edit_base_kdp_series.v_No;
//        string BASE_LABOR_SERIES = edit_base_labor_series.v_No;
        string BASE_LABOR_SERIES = edit_base_labor_series.v_Level;
        string BASE_PRTS = (txt_BASE_PRTS.Text.Trim() == "") ? "999" : txt_BASE_PRTS.Text.Trim(); // 列印順序 
        string BASE_FIN_AMT     = (edit_base_fin_amt.Text.Trim()=="")?"0":edit_base_fin_amt.Text.Trim(); 
        string BASE_TAX_DCT     = (edit_base_tax_dct.Text.Trim()=="")?"0":edit_base_tax_dct.Text.Trim(); 
        string BASE_LABOR_STATUS= "" ;// 勞保計算方式
        string BASE_SENTMAIL    = (edit_base_sentmail.Checked)?"Y":"N";
        string BASE_EMAIL = base_email.Text.Trim(); // edit_base_email.Text.Trim();
        string BASE_FIN_SUP_AMT = (edit_base_fin_sup_amt.Text.Trim()=="")?"0":edit_base_fin_sup_amt.Text.Trim(); 
        string BASE_REPLACE_AMT = edit_base_replace_amt.SelectedValue;
        string BASE_GOVADOF     = r_base_govadof.SelectedValue;
        string BASE_LAB_JIF = (edit_base_lab_jif.Checked) ? "Y" : "N"; //(edit_base_lab_jif.Text.Trim() == "") ? "0" : edit_base_lab_jif.Text.Trim(); 
        string base_fins_noq_nol= (edit_base_fins_noq_nol.Text.Trim()=="")?"0":edit_base_fins_noq_nol.Text.Trim(); 
        string base_fins_noh_nol= (edit_base_fins_noh_nol.Text.Trim()=="")?"0":edit_base_fins_noh_nol.Text.Trim();
        string BASE_FINS_Y65 = edit_base_fins_y65.SelectedValue; // 65歲原住民註記,65歲且1/2,65歲且3/4
        string BASE_FINS_SERIES = edit_base_fins_series.v_Level;
        string Base_IsMarked    = "N"; //是否顯示註記給預設值N
        string BASE_PEN_RATE    = (edit_base_pen_rate.Text.Trim()=="")?"0":edit_base_pen_rate.Text.Trim(); 
        string BASE_PEN_TYPE    = edit_base_pen_type.SelectedValue;
        string BASE_PROF        = "";//執行業務業別
        string BASE_PEN_SERIES  = edit_base_pen_series.v_Level;
        string BASE_NUMERATOR   = (edit_base_pen_rate.Text.Trim()=="")?"1":edit_base_pen_rate.Text.Trim(); 
        string BASE_DENOMINATOR = (edit_base_denominator.Text.Trim()=="")?"1":edit_base_denominator.Text.Trim(); 
        string BASE_PTB_TYPE    = edit_base_ptb_type.SelectedValue;
        string BASE_ALT_AMT = (edit_base_alt_amt.Text.Trim() == "") ? "0" : edit_base_alt_amt.Text.Trim(); 
        string BASE_MEMO1       = edit_base_memo1.Text.Trim();
        string BASE_MEMO2       = edit_base_memo2.Text.Trim();
        string BASE_MEMO3       = edit_base_memo3.Text.Trim();
        string BASE_DCODE_NAME  = edit_base_dcode_name.Text.Trim();
        string BASE_SENTMSG     = "";//(edit_base_sentmsg.Checked)?"Y":"N"; //  無用
        string BASE_FINS_HEALTH_SELF    = edit_base_fins_health_self.SelectedValue;
        string BASE_PROJ_BDATE  = SAL3101.ROCDateStrToDateStr(edit_base_proj_bdate.Text.Trim());
        string BASE_PROJ_EDATE  = SAL3101.ROCDateStrToDateStr(edit_base_proj_edate.Text.Trim());
        string BASE_LAB1        = (edit_base_lab1.Checked)?"Y":"N";
        string BASE_LAB2        = (edit_base_lab2.Checked)?"Y":"N";
        string BASE_LAB3        = (edit_base_lab3.Checked)?"Y":"N";
        string BASE_PARTTIME = edit_base_parttime.SelectedValue;
        string BASE_FINS_SELF_DESC = edt_BASE_FINS_SELF_DESC.Text.Trim(); // 保險自付減免原因說明
        // 保險自付減免原因說明
        //string BASE_FINS_PAR_DESC   = ""; // 保險眷口負擔減免原因說明
        string BASE_SERVICE_PLACE_DESC = "";   //服務單位中文(非員工專用)
        string BASE_SEQNO       = edit_base_seqno.Text.Trim();

        //貸款總金額	BASE_RAMT
        string BASE_RAMT  = (txt_BASE_RAMT.Text.Trim() == "") ? "0" : txt_BASE_RAMT.Text.Trim();
        // 尚未清償金額	BASE_NAMT
        string BASE_NAMT = (txt_BASE_NAMT.Text.Trim() == "") ? "0" : txt_BASE_NAMT.Text.Trim();
        // 每月清償金額	BASE_MAMT
        string BASE_MAMT = (txt_BASE_MAMT.Text.Trim() == "") ? "0" : txt_BASE_MAMT.Text.Trim();

        string BASE_FINS_PAR_DESC = txt_BASE_FINS_PAR_DESC.Text.Trim();// 保險眷口負擔減免原因說明

        string HEALTH_SELF_DESC = BASE_HEALTH_SELF_DESC.Text.Trim(); //健保註記
        string Budget_code = ddl_Budget_code.SelectedValue;//預算來源

        SAL3101 sal3101=new SAL3101();

        sal3101.updateSalSaBase(
                    BASE_IDNO,
                     BASE_STATUS,
                     BASE_TYPE,
                     BASE_ORGID,
                     BASE_NAME,
                     BASE_SEX,
                     BASE_JOB_DATE,
                     BASE_DEP,
                     BASE_BDATE,
                     BASE_EDATE,
                     BASE_JOB,
                     BASE_DCODE,
                     BASE_ORG_L1,
                     BASE_ORG_L2,
                     BASE_ORG_L3,
                     BASE_AGEN,
                     BASE_IN_L1,
                     BASE_IN_L3,
                     BASE_PTB,
                     BASE_PROV,
                     BASE_ADDR,
                     BASE_QUIT_DATE,
                     BASE_QUIT_REZN,
                     BASE_ERMK,
                     BASE_PRONO,
                     BASE_KDB,
                     BASE_KDC,
                     BASE_KDP,
                     BASE_KDO,
                     BASE_POL,
                     BASE_HOUS,
                     BASE_WELG,
                     BASE_WELO,
                     BASE_PRE,
                     BASE_OTHER_SAL,
                     BASE_PRED,
                     BASE_PRIZ,
                     BASE_TAX,
                     BASE_FINS_KIND,
                     BASE_PN_Y30,
                     BASE_FINS_NOQ,
                     BASE_FINS_NOH,
                     BASE_FINS_NOF,
                     BASE_FINS_NOL,
                     BASE_FINS_SELF,
                     BASE_FINS_NO,
                     BASE_DAY_SAL,
                     BASE_HOUR_SAL,
                     BASE_DCT_A,
                     BASE_DCT_B,
                     BASE_DCT_C,
                     BASE_COUNT_REMARK,
                     BASE_MEMO,
                     BASE_MUSER,
                     BASE_MDATE,
                     BASE_KDC_SERIES,
                     BASE_KDP_SERIES,
                     BASE_LABOR_SERIES,
                     BASE_PRTS,
                     BASE_FIN_AMT,
                     BASE_TAX_DCT,
                     BASE_LABOR_STATUS,
                     BASE_SENTMAIL,
                     BASE_EMAIL,
                     BASE_FIN_SUP_AMT,
                     BASE_REPLACE_AMT,
                     BASE_GOVADOF,
                     BASE_LAB_JIF,
                     base_fins_noq_nol,
                     base_fins_noh_nol,
                     BASE_FINS_Y65,
                     BASE_FINS_SERIES,
                     Base_IsMarked,
                     BASE_PEN_RATE,
                     BASE_PEN_TYPE,
                     BASE_PROF,
                     BASE_PEN_SERIES,
                     BASE_NUMERATOR,
                     BASE_DENOMINATOR,
                     BASE_PTB_TYPE,
                     BASE_ALT_AMT,
                     BASE_MEMO1,
                     BASE_MEMO2,
                     BASE_MEMO3,
                     BASE_DCODE_NAME,
                     BASE_SENTMSG,
                     BASE_FINS_HEALTH_SELF,
                     BASE_PROJ_BDATE,
                     BASE_PROJ_EDATE,
                     BASE_LAB1,
                     BASE_LAB2,
                     BASE_LAB3,
                     BASE_PARTTIME,
                     BASE_FINS_SELF_DESC,
                     BASE_FINS_PAR_DESC,
                     BASE_SERVICE_PLACE_DESC,
                     BASE_SEQNO,
                     BASE_RAMT,
                     BASE_NAMT,
                     BASE_MAMT,
                     HEALTH_SELF_DESC,
                     Budget_code
            );

        // 更新銀行帳號
        string bank_str=ucSaBase_Bank_1.v_Bank_Str;
        sal3101.deleteSalSabank(this.strOrgCode,BASE_SEQNO);

        if (bank_str!="")
        {
            string[] kdo_strs=bank_str.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string strTemp in kdo_strs)
            {
                string str=strTemp.Replace("[", "").Replace("]", "");
                string[] strs=str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string v_tdpf_seqno = strs[0].Trim();
                string v_bank_no = strs[1].Trim();//  Trim(strs(1))
                string v_bank_code = strs[2].Trim();//  Trim(strs(2))

                if (v_bank_no!="")
                {
                    sal3101.insertSalSabank(BASE_SEQNO,this.strOrgCode,v_bank_code,v_bank_no,this.strLogIDCard,v_tdpf_seqno);
                }
            }

        }

        // 更新其他加給
        string kdo_act=UcSaBase_Kdo_1.v_Kdo_Str;
        //SAPITM 資料
        //Dim v_orgid As String = Me.TextBox_orgid.Text
        //Dim v_seqno As String = Me.TextBox_seqno.Text
        //Dim v_mid As String = Me.TextBox_userid.Text
        string v_code_sys = "001";
        string v_code_kind = "P";
        string v_code_type = "006";
        string v_code_no = "";
        string v_code = "";
        // 刪除其他加給
        sal3101.deleteSalSaPItm(this.strOrgCode, BASE_SEQNO, v_code_sys, v_code_kind, v_code_type);
        //Response.Write("v_Kdo_Str"+UcSaBase_Kdo_1.v_Kdo_Str+"<BR>");
        if (edit_base_kdo.SelectedValue=="Y")
        {
//            Response.Write();
            string[] kdo_strs = kdo_act.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string strTemp in kdo_strs)
            {
                string str = strTemp.Replace("[", "").Replace("]", "");
                string[] strs = str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                v_code_no = strs[3].Trim();
                v_code = strs[4].Trim();

                sal3101.insertSalsaPItm(
                    this.strOrgCode, BASE_SEQNO, v_code_sys, 
                                  v_code_kind, v_code_type, v_code_no, 
                                  v_code, this.strLogIDCard);

            }
        }

        // 更新其他應發代扣項目
        string other_str=ucSaBase_Other_Sal1.v_Other_Sal_Str;
      //  Response.Write(other_str+"<BR>");
        v_code_sys = "005";
        v_code_kind = "";
        v_code_type = "";
        v_code_no = "";
        v_code = "";
        string v_amt="";
        string v_accno="";
        sal3101.deleteSalSaPItm4OtherSal(this.strOrgCode, BASE_SEQNO);
        if (edit_base_other_sal.SelectedValue=="Y")
        {
            string[] kdo_strs = other_str.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string strTemp in kdo_strs)
            {
                string str = strTemp.Replace("[", "").Replace("]", "");
                string[] strs = str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                v_code_kind = strs[1].Trim();
                v_code_type = strs[2].Trim();
                v_code_no = strs[3].Trim();
                v_code = strs[4].Trim();
                v_amt = strs[5].Trim();
                //v_accno = strs[6].Trim();

                sal3101.insertSalsaPItm(
                    this.strOrgCode, BASE_SEQNO, v_code_sys,
                                  v_code_kind, v_code_type, v_code_no,
                                  v_code,v_amt, this.strLogIDCard);

            }
        }


        queryUser();
        pnlQueryResult.Visible = true;
        pnlModify.Visible = false;
        pndConditions.Visible = true;

    }

    // 按下計算
    protected void btnCalcRetire_Click(object sender, EventArgs e)
    {
        if (txtUnrestAmt.Text == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入金額", "", "");
            this.Page = tempPage; 
            return;
        }
        CalcRetire();
    }

    // 計算退休金
    protected void CalcRetire()
    {
        string retireDate = UcDateTextBox_RetireDate.Text;

        //計算勞工平均月退金額
        string v_jobno = "";
        string v_month = UcDateTextBox_RetireDate.Text;
        DateTime time = Convert.ToDateTime(
            Convert.ToString(Convert.ToInt32(v_month.ToString().Substring(0, 3))+1911) + "/" + 
            v_month.ToString().Substring(3, 2) + 
            "/01");
        string v_month1 = (time.Year * 100 + time.Month).ToString();
        string v_month2 = (time.AddMonths(-1).Year * 100 + time.AddMonths(-1).Month).ToString();
        string v_month3 = (time.AddMonths(-2).Year * 100 + time.AddMonths(-2).Month).ToString();
        string v_month4 = (time.AddMonths(-3).Year * 100 + time.AddMonths(-3).Month).ToString();
        string v_month5 = (time.AddMonths(-4).Year * 100 + time.AddMonths(-4).Month).ToString();
        string v_month6 = (time.AddMonths(-5).Year * 100 + time.AddMonths(-5).Month).ToString();
        string v_amt = txtUnrestAmt.Text;
        //' 機關代碼
        string v_orgid = this.strOrgCode;

        //計算人員
        string v_seqno = this.strLogIDCard;


        string insstr = "DECLARE\t@return_value int Exec @return_value =   dbo.sp_Labor_RetireFee_calc '" + v_month1 + "','" + v_month2 + "','" + v_month3 + "','" + v_month4 + "','" + v_month5 + "','" + v_month6 + "','" + v_amt + "','" + v_seqno + "','" + v_orgid + "'";
        insstr += " SELECT\t'Return Value' = @return_value";
	    using (DB_TableAdapters.DB_TableAdapter ta = new DB_TableAdapters.DB_TableAdapter()) {
		try {
            lblRetireAmt.Text = ta.spExeSQLGetValue(insstr).ToString(); ;
		} catch (Exception ex) {
            lblRetireAmt.Text = ex.Message.ToString();
            //Response.Write("ERROR");
//			ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "showmsg", "alert('" + ex.Message.ToString() + "')", true);
		}
	    }
    }

    // 是否為兼職人員改變
    protected void edit_base_parttime_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (edit_base_parttime.SelectedValue == "Y") 
        {
            edit_base_fins_health_self.SelectedValue = "-1.00";
            edit_base_fin_amt.Text = "0";
            edit_base_fin_sup_amt.Text = "0";
        }
     }

    protected void ButtonClose_Click(object sender, EventArgs e)
    {
        queryUser();
        pndConditions.Visible = true;
    }
    protected void Button_Sort_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3101_02.aspx");
    }


    // 身份證字號檢查
    public static bool isIdentificationId(string arg_Identify)
    {
        var d = false;
        if (arg_Identify.Length == 10)
        {
            arg_Identify = arg_Identify.ToUpper();
            if (arg_Identify[0] >= 0x41 && arg_Identify[0] <= 0x5A)
            {
                var a = new[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                var b = new int[11];
                b[1] = a[(arg_Identify[0]) - 65] % 10;
                var c = b[0] = a[(arg_Identify[0]) - 65] / 10;
                for (var i = 1; i <= 9; i++)
                {
                    b[i + 1] = arg_Identify[i] - 48;
                    c += b[i] * (10 - i);
                }
                if (((c % 10) + b[10]) % 10 == 0)
                {
                    d = true;
                }
            }
        }
        return d;
    }

    protected void edit_base_kdo_SelectedIndexChanged(object sender, EventArgs e)
    {
        show_kdo(edit_base_kdo.SelectedValue);
    }


    protected void edit_base_other_sal_SelectedIndexChanged(object sender, EventArgs e)
    {
        show_other(edit_base_other_sal.SelectedValue);
    }

    protected void show_other(string value)
    {
        if (value == "Y")
        {
            div_other_sal.Visible = true;
        }
        else
        {
            div_other_sal.Visible = false;
        }

    }

    protected void show_kdo(string value)
    {
        if (value == "Y")
        {
            div_kdo.Visible = true;
        }
        else
        {
            div_kdo.Visible = false;
        }
    }

    protected void show_kdp(string value)
    {
        GetKdp();
        if (edit_base_kdp.SelectedValue != "N" && edit_base_kdp.SelectedValue != "")
        {
            div_kdp.Visible = true;

            //            edit_base_kdp_series.v_No = edit_base_kdp.SelectedValue;
        }
        else
        {
            div_kdp.Visible = false;
        }

    }

    protected void show_kdc(string value)
    {
        GetKdc();
        if (edit_base_kdc.SelectedValue != "N" && edit_base_kdc.SelectedValue != "")
        {
            div_kdc.Visible = true;
            //            edit_base_kdc_series.v_No = edit_base_kdc.SelectedValue;
        }
        else
        {
            div_kdc.Visible = false;
        }

    }




    protected void GridView_SaBase_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView_SaBase_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_SaBase.PageIndex = e.NewPageIndex;
        this.queryUser();
    }
}