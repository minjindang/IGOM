using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using EMPPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Configuration;


public partial class SYS2107_01 : BaseWebForm
{   
    protected void Page_Load(object sender, EventArgs e)
    {    
        if (Page.IsPostBack) return;  
    }   

  

    protected void btnQuery_Click(object sender, EventArgs e)
    {      
         doQueryData();
    }

    // 查詢資料
    private void doQueryData()
    {
        string userName = ADid.Text.Trim();
        if (userName == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請輸入AD帳號", "", "");
            this.Page = tempPage;
            return;
        }
        string stradIP = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_server_ip"];
        string stradID = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_id"];
        string stradPass = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_pass"];
        string stradDC = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_dc"];
        DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + stradIP, stradID, stradPass);
        System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        mySearcher.Filter = ("(cn=" + userName + ")");
        SearchResult de = mySearcher.FindOne();

        DataTable dt = new DataTable();
        dt.Columns.Add("description");
        dt.Columns.Add("displayname");
        dt.Columns.Add("telephonenumber");
        dt.Columns.Add("title");
        dt.Columns.Add("mail");


        if (de == null)
        {
            data.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                UcPager1.Visible = true;
            }
            else
            {
                UcPager1.Visible = false;
            }
        }

        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN=" + userName + "," + stradDC
         , stradID, stradPass);
   
        string description = "";
        string displayName = "";
        string telephoneNumber = "";
        string title = "";
        string mail = "";

        if (de != null)
        {           
            foreach (string key in de.Properties.PropertyNames)
            {
                foreach (object propVal in de.Properties[key])
                {
                    if (key == "description")
                    {
                        description = propVal.ToString();
                    }
                    if (key == "displayname")
                    {
                        displayName = propVal.ToString();
                    }

                    if (key == "telephonenumber")
                    {
                        telephoneNumber = propVal.ToString();
                    }

                    if (key == "title")
                    {
                      title = propVal.ToString();
                    }
                    if (key == "mail")
                    {
                       mail = propVal.ToString();
                    }                  
                }               
            }
            DataRow dr = dt.NewRow();
            dr["description"] = description;
            dr["displayName"] =displayName;
            dr["telephoneNumber"] =telephoneNumber;
            dr["title"] = title;
            dr["mail"] = mail;
            dt.Rows.Add(dr);
            data.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }        

        dirEntry.Close();
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        doQueryData();
    }
}
