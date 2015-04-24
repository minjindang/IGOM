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

public partial class SAL3130_01 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        BindInit();

        if (string.IsNullOrEmpty(Request.QueryString["id"]))
            lbTitle.Text = "薪資異動通知作業";
        else
        {
            lbTitle.Text = "薪資異動檢視作業";
            BindData();
        }
    }

    protected void BindData()
    {
        SAL.Logic.PaySalChgNoticMain main = new SAL.Logic.PaySalChgNoticMain();
        DataTable dt = main.GetDataById(CommonFun.getInt(Request.QueryString["id"]));
        foreach (DataRow dr in dt.Rows)
        {
            tbId_card.Text = dr["Id_card"].ToString();
            tbUser_name.Text = dr["User_name"].ToString();
            ddlTitle_code.SelectedValue = dr["Title_code"].ToString();
            UcDDLDepart.SelectedValue = dr["Depart_id"].ToString();
            UcAssign_date.Text = dr["Assign_date"].ToString();
            tbAssign_no.Text = dr["Assign_no"].ToString();
            UcJoin_date.Text = dr["Join_date"].ToString();

            ddlL3_code.SelectedValue = dr["L3_code"].ToString();
            ddlL1_code.SelectedValue = dr["L1_code"].ToString();
            ddlL2_code.SelectedValue = dr["L2_code"].ToString();
            tbPtbPoint_nos.Text = dr["PtbPoint_nos"].ToString();
            tbPtb_amt.Text = dr["Ptb_amt"].ToString();
            tbSalary_point.Text = dr["Salary_point"].ToString();
            tbSalary_amt.Text = dr["Salary_amt"].ToString();
            tbRate_nos.Text = dr["Rate_nos"].ToString();
            tbMonth_pay.Text = dr["Month_pay"].ToString();

            rblEmployeeType.SelectedValue = dr["Employee_type"].ToString();

            if (rblEmployeeType.SelectedValue.Equals("1"))
            {
                tb1.Visible = true;
                tb2.Visible = false;
            }
            else
            {
                tb1.Visible = false;
                tb2.Visible = true;
            }

            if (rblEmployeeType.SelectedValue.Equals("1"))
            {
                tbFin_month.Text = dr["Fin_month"].ToString();
                tbFin_amt.Text = dr["Fin_amt"].ToString();
                tbFin_people.Text = dr["Fin_people"].ToString();
                tbFin_people_amt.Text = dr["Fin_people_amt"].ToString();
                tbFund_month.Text = dr["Fund_month"].ToString();
                tbFund_day.Text = dr["Fund_day"].ToString();
                tbFund_amt.Text = dr["Fund_amt"].ToString();
                tbSafety_month.Text = dr["Safety_month"].ToString();
                tbSafety_day.Text = dr["Safety_day"].ToString();
                tbSafety_amt.Text = dr["Safety_amt"].ToString();
                tbMutual_month.Text = dr["Mutual_month"].ToString();
                tbMutual_amt.Text = dr["Mutual_amt"].ToString();
                cbxlHouse_type.SelectedValue = dr["House_type"].ToString();
            }
            else
            {
                tbFin_month0.Text = dr["Fin_month"].ToString();
                tbFin_amt0.Text = dr["Fin_amt"].ToString();
                tbFin_people.Text = dr["Fin_people"].ToString();
                tbFin_people_amt0.Text = dr["Fin_people_amt"].ToString();
                tbFund_month0.Text = dr["Fund_month"].ToString();
                tbFund_day0.Text = dr["Fund_day"].ToString();
                tbFund_amt0.Text = dr["Fund_amt"].ToString();
                tbSafety_month0.Text = dr["Safety_month"].ToString();
                tbSafety_day0.Text = dr["Safety_day"].ToString();
                tbSafety_amt0.Text = dr["Safety_amt"].ToString();
            }
            cbxHead_post_plus.Checked = dr["Head_post_plus"].ToString() == "1" ? true : false;
            cbxLaw_prof_plus.Checked = dr["Law_prof_plus"].ToString() == "1" ? true : false;
            cbxGeneral_prof_plus.Checked = dr["General_prof_plus"].ToString() == "1" ? true : false;
            cbxEnviprotec_prof_plus.Checked = dr["Enviprotec_prof_plus"].ToString() == "1" ? true : false;
            cbxOperator_prof_plus.Checked = dr["Operator_prof_plus"].ToString() == "1" ? true : false;
            cbxEast_taiwan_plus.Checked = dr["East_taiwan_plus"].ToString() == "1" ? true : false;
            cbxlNatimajproj_post_plus.SelectedValue = dr["Natimajproj_post_plus"].ToString();
            cbxlTechnical_staff.SelectedValue = dr["Technical_staff"].ToString();
            tbPromo_desc.Text = dr["Promo_desc"].ToString();
        }
    }

    protected void BindInit()
    {
        UcDDLDepart.Orgcode = LoginManager.OrgCode;

        ddlL3_code.DataSource = new FSCPLM.Logic.SACode().GetData("002", "003");
        ddlL3_code.DataBind();
        ddlL3_code.Items.Insert(0, new ListItem("請選擇", ""));
        
        ddlL1_code.DataSource = new FSCPLM.Logic.SACode().GetData("002", "006");
        ddlL1_code.DataBind();
        ddlL1_code.Items.Insert(0, new ListItem("請選擇", ""));
        
        ddlL2_code.DataSource = new FSCPLM.Logic.SACode().GetData("002", "009");
        ddlL2_code.DataBind();
        ddlL2_code.Items.Insert(0, new ListItem("請選擇", ""));
        
        ddlTitle_code.DataSource = new FSCPLM.Logic.SACode().GetData("002", "002");
        ddlTitle_code.DataBind();
        ddlTitle_code.Items.Insert(0, new ListItem("請選擇", ""));
    }

    protected void cbQuery_Click(object sender, EventArgs e)
    {
        String idCard = tbId_card.Text;
        SAL3130 bll = new SAL3130();
        DataTable dt = bll.GetBt02mData(idCard);

        if (dt != null && dt.Rows.Count > 0)
        {
            tbUser_name.Text = dt.Rows[0]["B02NAME"].ToString();
            UcDDLDepart.SelectedValue = dt.Rows[0]["B02UNICOD"].ToString()+"00";

            tbPtbPoint_nos.Text = dt.Rows[0]["B02POINT"].ToString();
            UcAssign_date.Text = dt.Rows[0]["B02SERDAT"].ToString();
            tbAssign_no.Text = dt.Rows[0]["B02SEROD"].ToString();
            UcJoin_date.Text = dt.Rows[0]["B02ARVDAT"].ToString();
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        FSC.Logic.Personnel psn = new FSC.Logic.Personnel();
        SAL.Logic.PaySalChgNoticMain main = new SAL.Logic.PaySalChgNoticMain();
        //String Employee_type = psn.GetColumnValue("Employee_type", tbId_card.Text);

        main.Employee_type = rblEmployeeType.SelectedValue; //Employee_type;
        main.Id_card = tbId_card.Text;
        main.User_name = tbUser_name.Text;
        main.Org_code = LoginManager.OrgCode;
        main.Depart_id = UcDDLDepart.SelectedValue;
        main.Title_code = ddlTitle_code.SelectedValue;
        main.Assign_date = UcAssign_date.Text;
        main.Assign_no = tbAssign_no.Text;
        main.Join_date = UcJoin_date.Text;
        main.L3_code = ddlL3_code.SelectedValue;
        main.L1_code = ddlL1_code.SelectedValue;
        main.L2_code = ddlL2_code.SelectedValue;
        main.PtbPoint_nos = tbPtbPoint_nos.Text;
        main.Ptb_amt = CommonFun.getDouble(tbPtb_amt.Text);
        main.Salary_point = tbSalary_point.Text;
        main.Salary_amt = CommonFun.getDouble(tbSalary_amt.Text);
        main.Rate_nos = CommonFun.getDouble(tbRate_nos.Text);
        main.Month_pay = CommonFun.getDouble(tbMonth_pay.Text);

        if(rblEmployeeType.SelectedValue.Equals("1"))
        {
            main.Fin_month = tbFin_month.Text;
            main.Fin_amt = CommonFun.getDouble(tbFin_amt.Text);
            main.Fin_people = tbFin_people.Text;
            main.Fin_people_amt = CommonFun.getDouble(tbFin_people_amt.Text);
            main.Fund_month = tbFund_month.Text;
            main.Fund_day = tbFund_day.Text;
            main.Fund_amt = CommonFun.getDouble(tbFund_amt.Text);
            main.Safety_month = tbSafety_month.Text;
            main.Safety_day = tbSafety_day.Text;
            main.Safety_amt = CommonFun.getDouble(tbSafety_amt.Text);
            main.Mutual_month = tbMutual_month.Text;
            main.Mutual_amt = CommonFun.getDouble(tbMutual_amt.Text);
            main.House_type = cbxlHouse_type.SelectedValue;
        }
        else
        {
            main.Fin_month = tbFin_month0.Text;
            main.Fin_amt = CommonFun.getDouble(tbFin_amt0.Text);
            main.Fin_people = tbFin_people.Text;
            main.Fin_people_amt = CommonFun.getDouble(tbFin_people_amt0.Text);
            main.Fund_month = tbFund_month0.Text;
            main.Fund_day = tbFund_day0.Text;
            main.Fund_amt = CommonFun.getDouble(tbFund_amt0.Text);
            main.Safety_month = tbSafety_month0.Text;
            main.Safety_day = tbSafety_day0.Text;
            main.Safety_amt = CommonFun.getDouble(tbSafety_amt0.Text);
        }

        main.Head_post_plus = cbxHead_post_plus.Checked ? "1" : "2";
        main.Law_prof_plus = cbxLaw_prof_plus.Checked ? "1" : "2";
        main.General_prof_plus = cbxGeneral_prof_plus.Checked ? "1" : "2";
        main.Enviprotec_prof_plus = cbxEnviprotec_prof_plus.Checked ? "1" : "2";
        main.Operator_prof_plus = cbxOperator_prof_plus.Checked ? "1" : "2";
        main.East_taiwan_plus = cbxEast_taiwan_plus.Checked ? "1" : "2";
        main.Natimajproj_post_plus = cbxlNatimajproj_post_plus.SelectedValue;
        main.Technical_staff = cbxlTechnical_staff.SelectedValue;
        main.Promo_desc = tbPromo_desc.Text;
        main.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);

        Page p = this.Page;
        if (main.Insert())
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.InsertOK, "", "", "");
        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.InsertFail, "", "", "");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void rblEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblEmployeeType.SelectedValue.Equals("1"))
        {
            tb1.Visible = true;
            tb2.Visible = false;
        }
        else
        {
            tb1.Visible = false;
            tb2.Visible = true;
        }
    }
}