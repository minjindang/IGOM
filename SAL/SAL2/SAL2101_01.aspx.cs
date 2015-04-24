using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using System.Data;
using System.Data.SqlClient;

public partial class SAL_SAL2_SAL2101_01 : BaseWebForm
{
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
    string strIDCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        loadData();
    }

    private void loadData()
    {
        SAL2101 sal2101 = new SAL2101();
        DataTable dt = sal2101.getData(strOrgCode, strIDCard);
        dt.Columns.Add("ROC_Payo_yymm");
        dt.Columns.Add("ROC_Payo_date");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Payo_yymm"].ToString().Length == 6)
            {
                dt.Rows[i]["ROC_Payo_yymm"] =
                    Convert.ToString(Convert.ToInt32(dt.Rows[i]["Payo_yymm"].ToString().Substring(0, 4))-1911) + "/" +
                    dt.Rows[i]["Payo_yymm"].ToString().Substring(4, 2);
   
            }
            if (dt.Rows[i]["Payo_date"].ToString().Length == 8)
            {
                dt.Rows[i]["ROC_Payo_date"]=
                    Convert.ToString(Convert.ToInt32(dt.Rows[i]["Payo_date"].ToString().Substring(0, 4)) - 1911) + "/" +
                    dt.Rows[i]["Payo_date"].ToString().Substring(4,2)+"/"+
                    dt.Rows[i]["Payo_date"].ToString().Substring(6,2);
   
            }

        }



        gvResult.DataSource = dt;
        gvResult.DataBind();
    }
}