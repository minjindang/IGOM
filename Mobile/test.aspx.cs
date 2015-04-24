using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using MobileServices;
using System.Data;

public partial class Mobile_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
//        MobileServices ms = new MobileServices();
        MOBServices rs = new MOBServices();
//        DataTable dt = rs.WSMOB016("", "", "", "", "");
//        Response.Write(dt.Rows.Count.ToString());
        

        
        
        

    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {

    }
}