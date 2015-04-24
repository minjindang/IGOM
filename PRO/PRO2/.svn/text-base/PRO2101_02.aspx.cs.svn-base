using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO2_PRO2101_02 : BaseWebForm
{
    PRO2101 dao = new PRO2101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind(Page.Request.QueryString["FA01_MASTNO"].ToString(), Page.Request.QueryString["FA01_CLSNO"].ToString());
        }
    }

    private void Bind(string FA01_MASTNO, string FA01_CLSNO)
    {
        string msg = string.Empty;
        DataTable dt = dao.Get02All(FA01_MASTNO, FA01_CLSNO);

        if (dt != null && dt.Rows.Count > 0)
        {
            string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
            dt.Columns.Add("OldUnit_name");
            dt.Columns.Add("NewUnit_name");

            foreach (DataRow dr in dt.Rows)
            {
                dr["OldUnit_name"] = new FSC.Logic.Org().GetDepartName(Orgcode, dr["OldUnit_code"].ToString());
                dr["NewUnit_name"] = new FSC.Logic.Org().GetDepartName(Orgcode, dr["NewUnit_code"].ToString());
            }

            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
            ViewState["DataTable"] = dt;
            dt.Dispose();
        }
      
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["DataTable"];
        GridViewA.DataBind();
    }
     
}