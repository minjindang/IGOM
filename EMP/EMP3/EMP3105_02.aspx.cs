using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSCPLM.Logic;
//using FSCPLM.Logic;
using EMPPLM.Logic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public partial class EMP_EMP3_EMP3105_02 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        tbYears.Enabled = false;
        tbMonths.Enabled = false;

        bindDDL();
        Bind();
    }

    protected void bindDDL()
    {
        ddlReason.DataTextField = "CODE_DESC1";
        ddlReason.DataValueField = "CODE_NO";
        ddlReason.DataSource = new SACode().GetData("023", "021");
        ddlReason.DataBind();
        ddlReason.Items.Insert(0, new ListItem("請選擇", ""));
    }

    protected void Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string Id_card = Request.QueryString["id"];

        try
        {
            FSC.Logic.LeaveYear bll = new FSC.Logic.LeaveYear();
            gvList.DataSource = bll.GetData(Orgcode, Id_card);
            gvList.DataBind();
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
//            CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }
    }

    protected void cbConfirm_Click(object sender, System.EventArgs e)
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string Id_card = Request.QueryString["id"];
        Page tempPage = this.Page;

        if (ddlReason.SelectedValue == "03")
        {
            if (string.IsNullOrEmpty(tbdays.Text))
            {
                tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年資天數為必填欄位", "", "");
                this.Page = tempPage;

                //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "年資天數為必填欄位");
                return;
            }
            if (!CommonFun.IsNum(tbdays.Text.Trim()))
            {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年資天數應為數字", "", "");
                this.Page = tempPage;
               //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "");
                return;
            }
        }
        else
        {
            if (rb1.Checked)
            {
                if (string.IsNullOrEmpty(UcDate1.Text))
                {

                  tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年資起日為必填欄位", "", "");
                this.Page = tempPage;
                   //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "年資起日為必填欄位");
                    return;
                }
                if (string.IsNullOrEmpty(UcDate2.Text))
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年資迄日為必填欄位", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "年資迄日為必填欄位");
                    return;
                }
                if (UcDate1.Text == UcDate2.Text)
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "休假年資起迄日不可同天", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "休假年資起迄日不可同天");
                    return;
                }
                if (Convert.ToInt32(UcDate1.Text) > Convert.ToInt32(UcDate2.Text))
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "休假年資起日不可大於休假年資迄日", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "休假年資起日不可大於休假年資迄日");
                    return;
                }
            }

            if (rb2.Checked)
            {
                if (string.IsNullOrEmpty(tbYears.Text) | string.IsNullOrEmpty(tbMonths.Text))
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年資年月為必填", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "年資年月為必填");
                    return;
                }
                if (!CommonFun.IsNum(tbYears.Text.Trim()))
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "年份應為數字", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "年份應為數字");
                    return;
                }
                if (!CommonFun.IsNum(tbMonths.Text.Trim()))
                {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "月份應為數字", "", "");
                this.Page = tempPage;
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "月份應為數字");
                    return;
                }

                // If tbYears.Text.Trim() = "0" Or tbMonths.Text.Trim() = "0" Then
                //CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "年月不可為0")
                //Return
                //End If
            }
        }

        if (string.IsNullOrEmpty(UcNote.Text))
        {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "備註為必填欄位", "", "");
                this.Page = tempPage;
            //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "備註為必填欄位");
            return;
        }
        if (string.IsNullOrEmpty(this.ddlYearFlag.SelectedValue))
        {
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "加減年資為必填欄位", "", "");
                this.Page = tempPage;
            //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "加減年資為必填欄位");
            return;
        }


        string joindate = new EMP3105().GetColumnValue(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode),"ACT_DATE", Id_card);

        if (!string.IsNullOrEmpty(joindate) & ddlYearFlag.SelectedValue == "2")
        {
            if (DateTimeInfo.GetPublicDate(joindate,"") > DateTimeInfo.GetPublicDate(UcDate1.Text,"") | DateTimeInfo.GetPublicDate(joindate,"") > DateTimeInfo.GetPublicDate(UcDate2.Text,""))
            {
                //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "減年資的休假年資起迄日需在初任公職日之後");
                tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "減年資的休假年資起迄日需在初任公職日之後", "", "");
                this.Page = tempPage;
                return;
            }
        }

        FSC.Logic.LeaveYear bll = new FSC.Logic.LeaveYear();
        try
        {
            bll.Orgcode = Orgcode;
            bll.Id_card = Id_card;
            bll.Year_sdate = UcDate1.Text;
            bll.Year_edate = UcDate2.Text;
            bll.Note = UcNote.Text;
            bll.Year_flag = this.ddlYearFlag.SelectedValue;
            bll.Reason = ddlReason.SelectedValue;
            bll.Years = CommonFun.getInt(tbYears.Text.Trim());
            bll.Months = CommonFun.getInt(tbMonths.Text.Trim());

            if ((ddlReason.SelectedValue == "03") & (!string.IsNullOrEmpty(tbdays.Text.Trim())))
            {
                bll.Year_days = CommonFun.getInt(tbdays.Text.Trim());
            }
            else
            {
                bll.Year_days = 0;
            }

            bll.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);

            if (string.IsNullOrEmpty(lbId.Text))
            {
                bll.Insert();
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.InsertOK, "", "", "");
                this.Page = tempPage;
                //CommonFun.MsgShow(this, CommonFun.Msg.InsertOK);
            }
            else
            {
                bll.Id = Convert.ToInt32(lbId.Text);
                bll.Update();
                 tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.UpdateOK, "", "", "");
                this.Page = tempPage;
                //CommonFun.MsgShow(this, CommonFun.Msg.UpdateOK);
            }
            resetControl();
            Bind();
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
                  tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.SystemError, "", "", "");
                this.Page = tempPage;
           //CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }
    }

    protected void resetControl()
    {
        lbId.Text = "";
        UcDate1.Text = "";
        UcDate2.Text = "";
        UcNote.Text = "";
        tbdays.Text = "";
        tbYears.Text = "";
        tbMonths.Text = "";
        ddlYearFlag.SelectedIndex = -1;
        ddlReason.SelectedIndex = -1;
        setPanel();
        cbCancelUpdate.Visible = false;
        cbBack.Visible = true;
        setRadioButtonStatus(1);
    }  

    protected void gvList_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (!(e.Row.RowType == DataControlRowType.Footer))
        {
            return;
        }

        TableCellCollection footer = e.Row.Cells;
        footer.Clear();

        TableCell tc1 = new TableCell();
        tc1.Text = "合計";
        tc1.ColumnSpan = 2;
        tc1.HorizontalAlign = HorizontalAlign.Right;
        footer.Add(tc1);

        TableCell tc2 = new TableCell();
        tc2.HorizontalAlign = HorizontalAlign.Center;
        footer.Add(tc2);

        footer.Add(new TableCell());
        footer.Add(new TableCell());
        footer.Add(new TableCell());
        footer.Add(new TableCell());

    }

    protected void gvList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Year_sdate = ((Label)e.Row.FindControl("lbYear_sdate")).Text;
            string Year_edate = ((Label)e.Row.FindControl("lbYear_edate")).Text;
            string Year_Flag = ((HiddenField)e.Row.FindControl("hdYearFlag")).Value;
            string reason = ((Label)e.Row.FindControl("lbReason")).Text;
            string Year_days = Convert.ToString( CommonFun.getInt(((Label)e.Row.FindControl("lbYear_days")).Text) );

            string Years = ((Label)e.Row.FindControl("lbYears")).Text;
            string Months = ((Label)e.Row.FindControl("lbMonths")).Text;

            // App_Code\VB\FSC\Common\CommonLib\CntLeave.vb
            FSC.Logic.ChgLeaveYearMonthDay cntht = FSC.Logic.CntLeave.CntChgYearMonth(Year_sdate, Year_edate, Year_Flag, reason, Convert.ToInt32(Year_days), CommonFun.getInt(Years), CommonFun.getInt(Months));


            if (cntht != null)
            {
                int tYear = cntht.Year;
                int tMonth = cntht.Month;

                if (e.Row.FindControl("lbYear") != null)
                {
                    //CType(e.Row.FindControl("lbYear"), Label).Text = CommonFun.getInt(d1.ToString("yy")) - 1 & "年" & CommonFun.getInt(d1.ToString("MM") - 1) & "月" & d1.ToString("dd") & "天"
                    ((Label)e.Row.FindControl("lbYear")).Text = tYear + "年" + tMonth + "個月";
                }

            }

            if (e.Row.FindControl("lbReasonName") != null & e.Row.FindControl("lbReason") != null)
            {
                ((Label)e.Row.FindControl("lbReasonName")).Text = new SACode().GetCodeDesc("023","021",((Label)e.Row.FindControl("lbReason")).Text);
            }

            if (e.Row.FindControl("hdYearFlag") != null)
            {
                string hdYearFlag = ((HiddenField)e.Row.FindControl("hdYearFlag")).Value;
                if ("1" == hdYearFlag)
                {
                    hdYearFlag = "加年資";
                }
                else
                {
                    hdYearFlag = "減年資";
                }
                ((Label)e.Row.FindControl("lbYearFlag")).Text = hdYearFlag;
            }

            if (e.Row.FindControl("lbYear_sdate") != null)
            {
                ((Label)e.Row.FindControl("lbYear_sdate")).Text = DateTimeInfo.ToDisplay(((Label)e.Row.FindControl("lbYear_sdate")).Text,"","/");
            }
            if (e.Row.FindControl("lbYear_edate") != null)
            {
                ((Label)e.Row.FindControl("lbYear_edate")).Text = DateTimeInfo.ToDisplay(((Label)e.Row.FindControl("lbYear_edate")).Text,"", "/");
            }

            if (((Label)e.Row.FindControl("lbreason")).Text == "03")
            {
                ((Panel)e.Row.FindControl("Panel1")).Visible = false;
                ((Panel)e.Row.FindControl("Panel2")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("Panel1")).Visible = true;
                ((Panel)e.Row.FindControl("Panel2")).Visible = false;
            }
        }

        int y = 0;
        int m = 0;
        int d = 0;

        long sumtick = 0;

        if (this.gvList.Rows.Count == 0)
        {
            return;
        }

        string bef_Year_edate = "";

        foreach (GridViewRow row in this.gvList.Rows)
        {
            string Year_sdate = ((Label)row.FindControl("lbYear_sdate")).Text.Replace("/", "");
            string Year_edate = ((Label)row.FindControl("lbYear_edate")).Text.Replace("/", "");
            string Year_Flag = ((HiddenField)row.FindControl("hdYearFlag")).Value;
            string reason = ((Label)row.FindControl("lbReason")).Text;

            string Years = ((Label)row.FindControl("lbYears")).Text;
            string Months = ((Label)row.FindControl("lbMonths")).Text;

            string Year_days = Convert.ToString( CommonFun.getInt(((Label)row.FindControl("lbYear_days")).Text) );

            FSC.Logic.ChgLeaveYearMonthDay cntht = FSC.Logic.CntLeave.CntChgYearMonth(Year_sdate, Year_edate, Year_Flag, reason, Convert.ToInt32(Year_days), CommonFun.getInt(Years), CommonFun.getInt(Months));

            if (cntht != null)
            {
                if (Year_Flag == "1")
                {
                    y += cntht.Year;

                    if (reason != "03")
                    {
                        m += cntht.Month;
                    }

                    d += cntht.Day;
                }
            }

            //判斷是否重疊月份
            if (!string.IsNullOrEmpty(bef_Year_edate))
            {
                DateTime d1 = DateTimeInfo.GetPublicDate(bef_Year_edate,"");
                DateTime d2 = DateTimeInfo.GetPublicDate(Year_sdate,"");

                if (d1.Year == d2.Year & d1.Month == d2.Month)
                {
                    m = m - 1;
                }
            }

            bef_Year_edate = Year_edate;
        }

        m += d / 30;
        if ((d % 30) > 0)
        {
            m += 1;
        }

        if (m >= 12)
        {
            y += m / 12;
            m = m % 12;
        }

        if ((this.gvList.FooterRow != null))
        {
            //Me.gvList.FooterRow.Cells(1).Text = y & "年" & m & "月" & d & "天"
            this.gvList.FooterRow.Cells[1].Text = y + "年" + m + "月";
        }
    }
    
    protected void cbUpdate_Click(object sender, System.EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        try
        {
            string id = ((Label)gvr.FindControl("lbId")).Text;
            FSC.Logic.LeaveYear bll = new FSC.Logic.LeaveYear();
            DataTable dt = bll.GetDataById(id);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UcDate1.Text = dr["Year_sdate"].ToString();
                    UcDate2.Text = dr["Year_edate"].ToString();
                    UcNote.Text = dr["Note"].ToString();
                    ddlYearFlag.SelectedValue = dr["Year_flag"].ToString();
                    ddlReason.SelectedValue = dr["Reason"].ToString();
                    setPanel();
                    tbdays.Text = dr["Year_days"].ToString();
                    lbId.Text = dr["Id"].ToString();

                    tbYears.Text = dr["Years"].ToString();
                    tbMonths.Text = dr["Months"].ToString();

                    if ((dr["Years"].ToString() == "0" | string.IsNullOrEmpty(dr["Years"].ToString())) & (dr["Months"].ToString() == "0" | string.IsNullOrEmpty(dr["Months"].ToString())))
                    {
                        setRadioButtonStatus(1);
                    }
                    else
                    {
                        setRadioButtonStatus(2);
                    }

                }
            }
            cbCancelUpdate.Visible = true;
            cbBack.Visible = false;
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.SystemError, "", "", "");
            this.Page = tempPage;
//            CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }
    }


    protected void cbDelete_Click(object sender, System.EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Button)sender).NamingContainer;
        try
        {
            string id = ((Label)gvr.FindControl("lbId")).Text;
            FSC.Logic.LeaveYear bll = new FSC.Logic.LeaveYear();
            bool ret = bll.DeleteById(id);
            if (ret)
            {
                //CommonFun.MsgShow(this, CommonFun.Msg.DeleteOK);
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.DeleteOK, "", "", "");
                this.Page = tempPage;
            }
            Bind();
            resetControl();
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.SystemError, "", "", "");
            this.Page = tempPage;
            //CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }
    }

    protected void cbCancelUpdate_Click(object sender, System.EventArgs e)
    {
        resetControl();
    }

    protected void ddlReason_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        setPanel();
    }

    protected void setPanel()
    {
        if (ddlReason.SelectedValue == "03")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
    }

    protected void rb1_CheckedChanged(object sender, System.EventArgs e)
    {
        setRadioButtonStatus(1);
    }

    protected void rb2_CheckedChanged(object sender, System.EventArgs e)
    {
        setRadioButtonStatus(2);
    }

    
    protected void setRadioButtonStatus(int status)
    {
        if (status == 1)
        {
            tbYears.Text = "";
            tbMonths.Text = "";
            tbYears.Enabled = false;
            tbMonths.Enabled = false;
            UcDate1.Enabled = true;
            UcDate2.Enabled = true;
            rb1.Checked = true;
            rb2.Checked = false;
        }
        else
        {
            tbYears.Enabled = true;
            tbMonths.Enabled = true;
            UcDate1.Text = "";
            UcDate2.Text = "";
            UcDate1.Enabled = false;
            UcDate2.Enabled = false;
            rb1.Checked = false;
            rb2.Checked = true;
        }
    }

    protected void cbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EMP3105_01.aspx");
    }
}