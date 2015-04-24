using FSC.Logic;
using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1106_01 : BaseWebForm
{
    SAL1106 dao = new SAL1106();

    protected void Page_Load(object sender, EventArgs e)
    {
        cmbDepartID.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(cmbDepart2_changed);

        if (!Page.IsPostBack)
        {
            this.ucDepart_id.Orgcode = LoginManager.OrgCode;
            this.ucDepart_id.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
            this.ucUser_name.Orgcode = LoginManager.OrgCode;
            this.ucUser_name.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
            this.ucUser_name.SelectedValue = LoginManager.UserId;
            this.lblApply_yyTitle.Text = CommonFun.getYYYMMDD().Substring(0, 3);


            cmbDepartID.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
            Bind(CommonFun.getYYYMMDD().Substring(0, 3), LoginManager.UserId);
            ShowReSendData();

            string msg = dao.canUse();
            if (!string.IsNullOrEmpty(msg))
            {
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
                this.btn_submit.Enabled = false;
                this.btn_query.Enabled = false;
                txtDays.Enabled = false;
                ddlHours.Enabled = false;
            }
            else
            {
                if (!dao.personnelDAO.GetColumnValue("Role_id", LoginManager.UserId).Contains("Personnel"))
                {
                    trPersonnel01.Visible = false;
                    trPersonnel02.Visible = false;
                    trDepart_id.Visible = false;
                    btn_query.Visible = false;
                }
                else
                {
                    Name_Bind();
                }
            }

       
        }
    }

    protected void Name_Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string Role_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);

        ddlName.Orgcode = Orgcode;
        ddlName.DepartId = cmbDepartID.SelectedValue;

        upnlUserName.Update();
    }

    protected void cmbDepart2_changed(object sender, EventArgs e)
    {
        Name_Bind();
    }

    protected void ShowReSendData()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
        {
            SAL1106 bll = new SAL1106();
            DataTable dt = bll.GetDayaByOrgFid(org, fid);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblUser_name.Text = dt.Rows[0]["User_name"].ToString();
                lbId_card.Text = dt.Rows[0]["Id_card"].ToString();
                lblApply_yy.Text = dt.Rows[0]["Annual_year"].ToString();
                lblPEHDAY.Text = dt.Rows[0]["Annual_days"].ToString();
                lblLeaveType1.Text = dt.Rows[0]["Vacation_days"].ToString();
                lblLeaveType2.Text = dt.Rows[0]["Vacation_internal"].ToString();
                lblLeaveType3.Text = dt.Rows[0]["Vacation_card"].ToString();
                lblLeaveType4.Text = dt.Rows[0]["Abroad_days"].ToString();
                lblPEHYEAR2.Text = dt.Rows[0]["Usable_days"].ToString();

                String payDays = dt.Rows[0]["pay_days"].ToString();
                txtDays.Text = payDays.Split('.')[0];
                if (payDays.IndexOf(".") >= 0)
                {
                    ddlHours.SelectedValue = payDays.Split('.')[1];
                }

                ucApply_yy.Year = CommonFun.getInt(dt.Rows[0]["Annual_year"].ToString());
                Cal();
            }

            btn_submit.Text = "確認";
            btn_query.Enabled = false;
            btn_back.Visible = true;
        }
    }

    private void Bind(string Apply_yy, string User_id)
    {
        Personnel personnel = dao.personnelDAO;

        lbId_card.Text = User_id;

        // 員工姓名
        lblUser_name.Text = personnel.GetColumnValue("User_name", User_id);

        // 發給年度
        lblApply_yy.Text = Apply_yy;

        // 可休天數
        lblPEHDAY.Text = personnel.GetColumnValue("PEHDAY", User_id);


        string sDate = (Convert.ToInt32(DateTime.Now.Year) - 1911) + "0101";
        string eDate = (Convert.ToInt64(DateTime.Now.ToString("yyyyMMdd")) - 19110000).ToString();
        string eTime = DateTime.Now.ToString("HHmm");


        // 實休天數
        lblLeaveType1.Text = FSC.Logic.Content.ConvertDayHours(CommonFun.getInt(dao.GetLeaveType(User_id,sDate,eDate,eTime, 1))).ToString();

        //  國內(一般)天數
        lblLeaveType2.Text = FSC.Logic.Content.ConvertDayHours(CommonFun.getInt(dao.GetLeaveType(User_id, sDate, eDate, eTime, 2))).ToString();

        // 國內(刷卡)天數
        lblLeaveType3.Text = FSC.Logic.Content.ConvertDayHours(CommonFun.getInt(dao.GetLeaveType(User_id, sDate, eDate, eTime, 3))).ToString();

        // 國外天數
        lblLeaveType4.Text = FSC.Logic.Content.ConvertDayHours(CommonFun.getInt(dao.GetLeaveType(User_id, sDate, eDate, eTime, 4))).ToString();

       
        // 可請領天數(可休天數-14-實休(若實休小於14，則實休算14))
          int PEHDAY=0;
        if (lblPEHDAY.Text != "")
        {
            PEHDAY = CommonFun.getInt(lblPEHDAY.Text);
        }
        lblPEHYEAR2.Text = CommonFun.getDouble(lblLeaveType1.Text) < 14 ? (PEHDAY - 14).ToString() : (PEHDAY - CommonFun.getDouble(lblLeaveType1.Text)).ToString();
        if (CommonFun.getDouble(lblPEHYEAR2.Text) <= 0)
        {
            lblPEHYEAR2.Text = "0";
            btn_submit.Enabled = false;
            txtApply_amount.Enabled  = btn_submit.Enabled;
            txtDays.Enabled = btn_submit.Enabled;
            ddlHours.Enabled = btn_submit.Enabled;
        }
        else
        {
            btn_submit.Enabled = true;
            txtApply_amount.ReadOnly = btn_submit.Enabled;
            txtDays.Enabled = btn_submit.Enabled;
            ddlHours.Enabled = btn_submit.Enabled;
            ucApply_yy.Enabled = false;

            txtDays.Text = lblPEHYEAR2.Text.Split('.')[0].ToString();
            if (lblPEHYEAR2.Text.Split('.').Length > 1)
            {
                ddlHours.SelectedValue = lblPEHYEAR2.Text.Split('.')[1].ToString();
            }
            Cal();
        }

        // 申請金額
        //txtApply_amount.Text = "";

        // 申請天數
        //txtDays.Text = "";
    }

    protected void btn_query_Click(object sender, EventArgs e)
    {
        string szName ="";

        if (trPersonnel01.Visible == false)
        {
            szName = ddlName.SelectedValue;
        }
        else
        {
            Page p = this.Page;
            if (string.IsNullOrEmpty(ddlName.SelectedValue) && string.IsNullOrEmpty(UcPersonal_id.PersonnelId) && 
                string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請選擇人員、輸入人員姓名或輸入員工編號!", "", "");
                return;
            }

            DataTable dt = new SAL1106().getPersonnel(this.ddlName.SelectedValue, this.UcPersonal_id.PersonnelId, this.txtUserName.Text.Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                szName = dt.Rows[0]["id_card"].ToString();
            }
            else
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.QueryNothing, "", "", "");
                return;
            }
        }

        Bind(ucApply_yy.Year.ToString(), szName);
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        string msg = string.Empty;
        Page p = this.Page;

        string flow_id = string.Empty;

        int hours = FSC.Logic.Content.ConvertToHours(CommonFun.getDouble(txtDays.Text)) + CommonFun.getInt(ddlHours.SelectedValue);
        double payDays = FSC.Logic.Content.ConvertDayHours(hours);

        if (CommonFun.getInt(this.lblPEHYEAR2.Text) < payDays)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "輸入天數超過可請領天數", "", "");
            return;
        }

        try
        {
            if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
            {
                dao.Upd(ucApply_yy.Year.ToString(), CommonFun.getInt(lblPEHDAY.Text), CommonFun.getInt(lblLeaveType1.Text),
                    CommonFun.getInt(lblLeaveType2.Text), CommonFun.getInt(lblLeaveType3.Text), CommonFun.getInt(lblLeaveType4.Text),
                    CommonFun.getInt(lblPEHYEAR2.Text), GetBaseDaySAL(), Convert.ToInt32(txtApply_amount.Text), payDays, org, fid, lbId_card.Text);

                CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
            }
            else
            {
                DataTable dt = dao.fsaDAO.GetAll(lbId_card.Text, ucApply_yy.Year.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "已申請過", "", "");
                    return;
                }

                dao.Apply(ucApply_yy.Year.ToString(), CommonFun.getInt(lblPEHDAY.Text), CommonFun.getInt(lblLeaveType1.Text),
                    CommonFun.getInt(lblLeaveType2.Text), CommonFun.getInt(lblLeaveType3.Text), CommonFun.getInt(lblLeaveType4.Text),
                    CommonFun.getInt(lblPEHYEAR2.Text), GetBaseDaySAL(), CommonFun.getInt(txtApply_amount.Text), payDays, lbId_card.Text);

                CommonFun.MsgShow(ref p, CommonFun.Msg.InsertOK, "", "", "");
                // this.btn_submit.Enabled = false;
            }
        }
        catch (FlowException fex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, fex.Message, "", "");
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    private int GetBaseDaySAL()
    {
        return CommonFun.getInt(dao.GetBASE_DAY_SAL(ucApply_yy.Year.ToString()));
    }

    private void Cal()
    {
        if (!CommonFun.IsNum(txtDays.Text))
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "天數請輸入數字!", "", "");
            return;
        }

        int canPayhours = FSC.Logic.Content.ConvertToHours(CommonFun.getDouble(lblPEHYEAR2.Text));
        int payhours = FSC.Logic.Content.ConvertToHours(CommonFun.getDouble(txtDays.Text + "." + ddlHours.SelectedValue));
        if (payhours > canPayhours)
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "不可超過可請領天數!", "", "");
            txtDays.Text = "";
            ddlHours.SelectedIndex = -1;
            return;
        }

        // 日薪
        int daySAL = GetBaseDaySAL();
        int hourSAL = daySAL / 8;

        // (日薪 * 申請天數)+日薪 * (小時/8)
        txtApply_amount.Text = (daySAL * CommonFun.getInt(txtDays.Text) + hourSAL * CommonFun.getInt(ddlHours.SelectedValue)).ToString();
    }

    /// <summary>
    /// 輸入天數，計算金額
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtDays_TextChanged(object sender, EventArgs e)
    {
        Cal();
    }

    /// <summary>
    /// 選擇時數，計算金額
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }


    protected void ucDepart_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucUser_name.DepartId = this.ucDepart_id.SelectedValue;
        ucUser_name.DataBind();
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }
}