using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAR.Logic;

public partial class CAR_CAR2_CAR2102_03 : BaseWebForm
{

    Car2102 dao = new Car2102();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string getString = Request["cardid"] != null ? Request["cardid"] : "";
            string sdate = Request["sdate"] != null ? Request["sdate"] : "";
            string edate = Request["edate"] != null ? Request["edate"] : "";

            lbCar_id.Text = getString;
            lbStart_date.Text = sdate;
            lbEnd_date.Text = edate;

            DataTable dt = dao.CardList(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), lbCar_id.Text, sdate, edate);

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

    protected void cbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CAR2102_01.aspx?sdate=" + lbStart_date.Text + "&edate=" + lbEnd_date.Text);
    }
}