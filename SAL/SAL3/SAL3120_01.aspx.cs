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

public partial class SAL_SAL3_SAL3120_01 : System.Web.UI.Page
{
        // 登入者機關代碼
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    string strUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack) return;
        this.TextBox_orgid.Text = strOrgCode;
        this.TextBox_mid.Text = strUserID;

//            this.TextBox_orgid.Text = this.LoginManager.UserData.v_ROLE_ORGID.ToString;
//            this.TextBox_mid.Text = this.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString;

//            this.SQLs1();
//            this.GridView_batengf.DataBind();
            getData();


    }

    private void getData()
    {
        SAL3120 sal3120 = new SAL3120();
        DataTable dt =  sal3120.getData(strOrgCode);
        GridView_batengf.DataSource = dt;
        GridView_batengf.DataBind();
    }

    protected string Unit_Name(object unit_dep, object user_name)
{
	string rv = "";

    if (!Convert.IsDBNull(unit_dep))
    {
        rv = (string)unit_dep;
    }

    if (!string.IsNullOrEmpty((string)user_name))
    {
		rv += "<br />(執行人員:" + user_name + ")";
	}

	return rv;

}

    
    protected string YM_Name(object v_ym)
    {
	    string rv = "";
        string ym = (string)v_ym;
        if (ym.Length == 4)
        {
		    rv = Convert.ToString(Convert.ToInt32(ym) - 1911) + "年";
        }
        else if (ym.Length == 6)
        {
            rv = Convert.ToString(Convert.ToInt32(ym.Substring(0, 4)) - 1911) + "年" + Convert.ToString(ym.Substring(4, 2)) + "月";
	    } else {
		    rv = "&nbsp;";
	    }
	    return rv;
    }

protected string Status_Name(object stat1, object msg)
{
	string rv = "";
	string stat = (string)stat1;
    char myChar = stat[0];
    switch (myChar)
    {
		case 'W':
			rv = "排程中";
			break;
		case 'E':
			rv = "作業中";
			break;
		case 'Y':
			rv = "作業完成";
			break;
		case 'N':
			rv = "作業失敗";
			break;
		default:
			break;
	}

	if (stat == "N") {
		rv += "<br />[" + msg + "]";
	}

	return rv;
}

    protected string Time_Name(object time1)
    {
	    string rv = "";
        string time = (string)time1;
        if (time.Length == 14)
        {
            rv = Convert.ToString(Convert.ToInt32(time.Substring(0, 4)) - 1911) + "年" + time.Substring(4, 2) + "月" + time.Substring(6, 2) + "日<br />" + time.Substring(8, 2) + "時" + time.Substring(10, 2) + "分" + time.Substring(12, 2) + "秒";
	    } else {
		    rv = time;
	    }
	    return rv;
    }

    protected void Button_qry_Click(object sender, EventArgs e)
    {
        string url = "media_f015.aspx" + ((Button)sender).CommandArgument;

        //Dim str As String = CType(sender, Button).CommandArgument
        //Me.MessageBox(str)

        //this.GotoPage(url);
        Response.Redirect(url);
    }

protected bool Btn_Vis(object status1, object orgid)
{
	bool rv = false;

	string status = (string)status1;

	if ((status == "Y") & (orgid == this.TextBox_orgid.Text)) {
		rv = true;
	}

	return rv;
}

}