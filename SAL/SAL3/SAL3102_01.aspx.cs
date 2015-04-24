using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SALPLM.Logic;
using System.Data;
using System.Data.SqlClient;

public partial class SAL_SAL3_VBOld_SAL3102_01 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼
    private string strLogIDCard;    // 登入者原邊
    protected void Page_Load(object sender, EventArgs e)
    {
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        strLogIDCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        if (Page.IsPostBack) return;
    }

    // 按下查詢員工
    protected void b_ToSearch_Click(object sender, EventArgs e)
    {
        txtShowAll.Text = "N";
        queryData();
        pnlModify.Visible = false;
        pnlResult.Visible = true;
        MODE.Text = "Query";//狀態為查詢
    }

    // 按下新增員工
    protected void b_ToAdd_Click(object sender, EventArgs e)
    {
        pnlResult.Visible = false;
        pnlModify.Visible = true;
        pnlCondition.Visible = false;
        Label_title.Text = "新增非員工基本資料";
        ucBankNo_v2_bank.v_UserOrgId = this.strOrgCode;
        MODE.Text = "Insert"; //狀態為新增
    }
    private void getData()
    {
        if (txtShowAll.Text == "Y")
        {
            this.queryDataAll();
        }
        else
        {
            this.queryData();
        }
    }

    // 查詢員工
    private void queryData()
    {
        string strShowMark  ="N";
        string strBaseType  =v_base_type__.SelectedValue;
        string strProNo     ="ALL";
        string strSearchStr = v_Search_str__.Text.Trim();
        string strOrderBy   = v_orders__.SelectedValue;

        SAL3102 sal3102 = new SAL3102();
        DataTable dt = sal3102.querySalSaBaseNon(
            this.strOrgCode,
            strShowMark,
            strBaseType,
            strProNo,
            strSearchStr,
            strOrderBy);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    // 查詢全部
    private void queryDataAll()
    {
        string strShowMark = "Y";
        string strBaseType = v_base_type__.SelectedValue;
        string strProNo = "ALL";
        string strSearchStr = v_Search_str__.Text.Trim();
        string strOrderBy = v_orders__.SelectedValue;

        SAL3102 sal3102 = new SAL3102();
        DataTable dt = sal3102.querySalSaBaseNon(
            this.strOrgCode,
            strShowMark,
            strBaseType,
            strProNo,
            strSearchStr,
            strOrderBy);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    // 轉換 YN -> True/False
    protected bool ConvertYNtoTrueFalse(string p)
    {
        bool rv;
        switch (p.ToLower())
        {
            case "y":
                rv = true;
                break;
            case "n":
                rv = false;
                break;
            default:
                rv = false;
                break;
        }
        return rv;
    }

    protected string ConvertYNtoTrueFalse2(string p)
    {
        string rv;
        switch (p.ToLower())
        {
            case "y":
                rv = "隱藏";
                break;
            case "n":
                rv = "不隱藏";
                break;
            default:
                rv = "不隱藏";
                break;
        }
        return rv;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {

            case "EditX":
                //try
                //{
                    string[] par = e.CommandArgument.ToString().Split(';');
                    string strBaseSeqNO = par[0];
                    _base_seqno.Text = strBaseSeqNO;
                    SAL3101 sal3101 = new SAL3101();
                    DataTable dt = sal3101.querySalSaBaseBySeqNo(this.strOrgCode, strBaseSeqNO);
                    initModifyPanel(dt);
                    pnlResult.Visible = false;
                    pnlModify.Visible = true;
                    pnlCondition.Visible = false;
                    MODE.Text = "Edit"; //狀態為編輯
                //}
                //catch (Exception ex)
                //{
                //}

                break;
        }

    }

    private void initModifyPanel(DataTable dt)
    {
        // 人員姓名
        _base_name.Text = dt.Rows[0]["BASE_NAME"].ToString();
        // 隱藏註記
        _base_isMarked.Checked = (dt.Rows[0]["base_isMarked"].ToString() == "Y");
        // 身份證
        _base_idno.Text = dt.Rows[0]["BASE_IDNO"].ToString().Trim();
        // 錯誤註記
        _base_ermk.Checked = (dt.Rows[0]["BASE_ERMK"].ToString() == "Y");
        // 本院員工
        try
        {
            _base_status.SelectedValue = dt.Rows[0]["BASE_STATUS"].ToString();
        }
        catch { _base_status.SelectedValue = "N"; }
        // 性別
        try
        {
            _base_sex.SelectedValue = dt.Rows[0]["BASE_SEX"].ToString();
        }
        catch { _base_sex.SelectedIndex = 0; }
        //// 到職日期
        //edit_base_bdate.Text = SAL3101.DateStrToROCDateStr(dt.Rows[0]["BASE_BDATE"].ToString());
        //// 離職日期
        //edit_base_edate.Text = SAL3101.DateStrToROCDateStr(dt.Rows[0]["BASE_EDATE"].ToString());
        // 兼職人員
        try
        {
            edit_base_parttime.SelectedValue = dt.Rows[0]["BASE_PARTTIME"].ToString();
        }
        catch { }
        // 出生年月日
        edit_baseext_birthday.Text = dt.Rows[0]["BASE_BirthDay"].ToString();
        // 身份別
        try
        {
            _base_type.SelectedValue = dt.Rows[0]["BASE_TYPE"].ToString();
        }
        catch { _base_type.SelectedIndex = 0; }
        // 職稱 ???????????????????????????
        txtDcodeName.Text = dt.Rows[0]["BASE_DCODE_NAME"].ToString().Trim();
        // rblDcodeName.SelectedValue =
        // 地址
        _base_addr.Text = dt.Rows[0]["BASE_ADDR"].ToString().Trim();
        _base_email.Text = dt.Rows[0]["BASE_EMAIL"].ToString().Trim();
        // 執行業務別
        try
        {
            _base_prof.SelectedValue = dt.Rows[0]["BASE_PROF"].ToString();
        }
        catch { _base_prof.Rebind(); }

        //※備註
        _base_memo.Text = dt.Rows[0]["BASE_MEMO"].ToString().Trim();

        ucBankNo_v2_bank.v_UserOrgId = this.strOrgCode;
        ucBankNo_v2_bank.v_base_seqno = _base_seqno.Text.Trim();


    }
    //
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        // 檢查輸入之銀行帳號

        if ("Edit".Equals(MODE.Text))
        {
            updateSalSaBaseNon();
            getData();
            string msg = "";
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "修改完成！", "", "");
            this.Page = tempPage;
        }
        else if ("Insert".Equals(MODE.Text))
        {
            string msg = insertSalSaBaseNon();
            if ("".Equals(msg))
            {
                getData();
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "新增完成！", "", "");
                this.Page = tempPage;
                pnlResult.Visible = true;
                pnlModify.Visible = false;
                pnlCondition.Visible = true;
            }
            else
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, msg, "", "");
                this.Page = tempPage;
            }

        }
        


        


    }

    // 儲存修改
    private void updateSalSaBaseNon()
    {
        // 人員姓名
        string BASE_NAME = _base_name.Text.Trim();
        // 隱藏註記
        string base_isMarked = (_base_isMarked.Checked) ? "Y" : "N";
        // 身份證
        string BASE_IDNO = _base_idno.Text.Trim();
        // 錯誤註記
        string BASE_ERMK = (_base_ermk.Checked) ? "Y" : "N";
        // 本院員工
        string BASE_STATUS = _base_status.SelectedValue;
        // 性別
        string BASE_SEX = _base_sex.SelectedValue;
        //// 到職日期
        //string BASE_BDATE = SAL3101.ROCDateStrToDateStr(edit_base_bdate.Text);
        //// 離職日期
        //string BASE_EDATE = SAL3101.ROCDateStrToDateStr(edit_base_edate.Text);
        // 兼職人員
        string BASE_PARTTIME = edit_base_parttime.SelectedValue;
        // 出生年月日
        string BASE_BirthDay = edit_baseext_birthday.Text.Trim();
        // 身份別
        string BASE_TYPE = _base_type.SelectedValue;
        // 職稱 ???????????????????????????
        string BASE_DCODE_NAME = txtDcodeName.Text.Trim();
        // rblDcodeName.SelectedValue =
        // 地址
        string BASE_ADDR = _base_addr.Text.Trim();
        string BASE_EMAIL = _base_email.Text.Trim();
        // 執行業務別
        string BASE_PROF = _base_prof.SelectedValue;
        //人員分類 
        string BASE_PRONO = _base_prono.SelectedValue;
        // 健保種類
        //string BASE_FINS_KIND = rbt_base_fins_kind.SelectedValue;
        //※備註
        string BASE_MEMO = _base_memo.Text.Trim();
        string BASE_SEQNO = _base_seqno.Text.Trim();

        // 銀行


        SAL3102 sal3102 = new SAL3102();
        sal3102.updateSalSaBaseNon(BASE_IDNO, BASE_STATUS, BASE_TYPE, this.strOrgCode, BASE_NAME, BASE_SEX,
            BASE_ADDR, BASE_ERMK, BASE_PRONO, BASE_MEMO, this.strLogIDCard, BASE_EMAIL, base_isMarked, BASE_PROF, BASE_DCODE_NAME
            , BASE_SEQNO, BASE_PARTTIME);

        sal3102.updateSalSaBaseExtBirthday(this.strOrgCode, BASE_IDNO, BASE_BirthDay);

        string strBankNo = ucBankNo_v2_bank.SelectedValue;
        string strBankBankNO= ucBankNo_v2_bank.v_account_no;

        // 更新銀行帳號
        sal3102.updateSalSaBank(this.strOrgCode, BASE_SEQNO,
         strBankNo,
         strBankBankNO,
         BASE_IDNO,
         this.strLogIDCard);
    }

    // 儲存新增
    private string insertSalSaBaseNon()
    {
        // 人員姓名
        string BASE_NAME = _base_name.Text.Trim();
        // 隱藏註記
        string base_isMarked = (_base_isMarked.Checked) ? "Y" : "N";
        // 身份證
        string BASE_IDNO = _base_idno.Text.Trim();
        // 錯誤註記
        string BASE_ERMK = (_base_ermk.Checked) ? "Y" : "N";
        // 本院員工
        string BASE_STATUS = _base_status.SelectedValue;
        // 性別
        string BASE_SEX = _base_sex.SelectedValue;
        //// 到職日期
        //string BASE_BDATE = SAL3101.ROCDateStrToDateStr(edit_base_bdate.Text);
        //// 離職日期
        //string BASE_EDATE = SAL3101.ROCDateStrToDateStr(edit_base_edate.Text);
        // 兼職人員
        string BASE_PARTTIME = edit_base_parttime.SelectedValue;
        // 出生年月日
        string BASE_BirthDay = edit_baseext_birthday.Text.Trim();
        // 身份別
        string BASE_TYPE = _base_type.SelectedValue;
        // 職稱 ???????????????????????????
        string BASE_DCODE_NAME = txtDcodeName.Text.Trim();
        // rblDcodeName.SelectedValue =
        // 地址
        string BASE_ADDR = _base_addr.Text.Trim();
        string BASE_EMAIL = _base_email.Text.Trim();
        // 執行業務別
        string BASE_PROF = _base_prof.SelectedValue;
        //人員分類 
        string BASE_PRONO = _base_prono.SelectedValue;
        // 健保種類
        //string BASE_FINS_KIND = rbt_base_fins_kind.SelectedValue;
        //※備註
        string BASE_MEMO = _base_memo.Text.Trim();
        string BASE_SEQNO = _base_seqno.Text.Trim();

        //檢查姓名、身分證字號、地址是否有輸入
        string validateMsg = insertValidate(BASE_NAME, BASE_IDNO, BASE_ADDR);
        if ("".Equals(validateMsg))
        {
            SAL3102 sal3102 = new SAL3102();
            if (!sal3102.existSalSaBase(this.strOrgCode, BASE_IDNO))
            {
                //sal3102.insertSalSaBaseNon(BASE_IDNO, BASE_STATUS, BASE_TYPE, this.strOrgCode, BASE_NAME, BASE_SEX, BASE_BDATE, BASE_EDATE,
                //    BASE_ADDR, BASE_ERMK, BASE_FINS_KIND, BASE_MEMO, this.strLogIDCard, BASE_EMAIL, base_isMarked, BASE_PROF, BASE_DCODE_NAME
                //    , BASE_SEQNO, BASE_PARTTIME);
                sal3102.insertSalSaBaseNon(BASE_IDNO, BASE_STATUS, BASE_TYPE, this.strOrgCode, BASE_NAME, BASE_SEX,
                    BASE_ADDR, BASE_ERMK, BASE_PRONO, BASE_MEMO, this.strLogIDCard, BASE_EMAIL, base_isMarked, BASE_PROF, BASE_DCODE_NAME
                    , BASE_SEQNO, BASE_PARTTIME);

                sal3102.updateSalSaBaseExtBirthday(this.strOrgCode, BASE_IDNO, BASE_BirthDay);

                string strBankNo = ucBankNo_v2_bank.SelectedValue;
                string strBankBankNO = ucBankNo_v2_bank.v_account_no;

                // 更新銀行帳號
                sal3102.updateSalSaBank(this.strOrgCode, BASE_SEQNO,
                 strBankNo,
                 strBankBankNO,
                 BASE_IDNO,
                 this.strLogIDCard);
            }
            else
            {
                return "身份證字號已存在";
            }
            return "";
        } else {
            return validateMsg;
        }

        
       
    }


    private string insertValidate(string BASE_NAME,string BASE_IDNO,string BASE_ADDR)
    {
        if ("".Equals(BASE_NAME))
        {
            return "姓名不可為空";
        }
        else if ("".Equals(BASE_IDNO))
        {
            return "身份證字號不可為空";
        }
        else if ("".Equals(BASE_ADDR))
        {
            return "地址不可為空";
        }
        return "";
    }

    protected void b_ShowAll_Click(object sender, EventArgs e)
    {
        pnlModify.Visible = false;
        pnlResult.Visible = true;
        txtShowAll.Text = "Y";
        queryDataAll();
        MODE.Text = "Query";//狀態為查詢
    }

    protected void b_toMark_Click(object sender, EventArgs e)
    {
        SAL3102 sal3102 = new SAL3102();
        foreach (GridViewRow r in GridView1.Rows)
        {
            CheckBox cb_checkBox1 = (CheckBox)r.FindControl("cb_checkBox1");
            Label c_base_seqno = (Label)r.FindControl("c_base_seqno");
            string vmark = "";
            if ((cb_checkBox1.Checked))
            {
                vmark = "Y";
            }
            else
            {
                vmark = "N";
            }

            sal3102.updateSalSaBaseMark(this.strOrgCode, c_base_seqno.Text, vmark);
        }

        getData();

        string msg = "";
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "修改完成！", "", "");
        this.Page = tempPage;

    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        pnlResult.Visible = true;
        pnlModify.Visible = false;
        pnlCondition.Visible = true;
    }
    
    // 身份別更改
    protected void _base_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        type_changed();
    }

    protected void type_changed()
    {
        switch (_base_type.SelectedValue)
        {
            case "2":
                this.Label_name.Text = "人員姓名";
                this.Label_idno.Text = "統一證號";
                this.div_sex.Visible = true;
                this.div_sex2.Visible = true;
                this.div_status.Visible = false;
                this.div_status2.Visible = false;
                this.div_ermk.Visible = false;
                this.div_ermk2.Visible = false;
                this.div_DcodeName.Visible = false;

                //div_Dates.Visible = false;
                //div_Datee.Visible = false;
                //div_Dates2.Visible = false;
                //div_Datee2.Visible = false;
                break;
            case "3":
                this.Label_name.Text = "公司名稱";
                this.Label_idno.Text = "統一編號";
                this.div_sex.Visible = false;
                this.div_sex2.Visible = false;
                this.div_status.Visible = false;
                this.div_status2.Visible = false;
                this.div_ermk.Visible = false;
                this.div_ermk2.Visible = false;
                div_DcodeName.Visible = false;

                //div_Dates.Visible = false;
                //div_Datee.Visible = false;
                //div_Dates2.Visible = false;
                //div_Datee2.Visible = false;
                break;
            default:
                //' 1 個人
                this.Label_name.Text = "人員姓名";
                this.Label_idno.Text = "身分證字號";
                this.div_sex.Visible = true;
                this.div_sex2.Visible = true;
                this.div_status.Visible = true;
                this.div_status2.Visible = true;
                this.div_ermk.Visible = true;
                this.div_ermk2.Visible = true;

                div_DcodeName.Visible = true;
                //div_Dates.Visible = true;
                //div_Datee.Visible = true;
                //div_Dates2.Visible = true;
                //div_Datee2.Visible = true;
                break;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        queryData();
    }
}