using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile_MasterPage_Mobile : System.Web.UI.MasterPage
{

    private void BasePage_PreLoad(object sender, System.EventArgs e)
    {
        
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
        }
        else
        {

            Response.Redirect("~/IGOM/Mobile/login.aspx");
        }
        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
        }
        else
        {

            Response.Redirect("~/IGOM/Mobile/login.aspx");
        }
        
    }
}
