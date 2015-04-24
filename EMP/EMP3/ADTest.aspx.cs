using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Configuration;

public partial class EMP_EMP3_ADTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string oGUID = string.Empty;
//        ent = New DirectoryEntry("LDAP://A1.B2.C3.D4.E5", TX_User.Text, TX_Passwd.Text)
//        System.Configuration.Configuration rootWebConfig1 =
//				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
        string stradIP = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_server_ip"];
        string stradID = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_id"];
        string stradPass = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_pass"];
        string stradDC = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_dc"];

        DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + stradIP 
//            +  "/" + "OU=test," + stradDC
            , 
            stradID, stradPass);



//        Response.Write(dirEntry.Properties["distinguishedName"].ToString());
        
        string userName = "eliotchen2";
        if (Request.QueryString.ToString() != "")
        {
            userName = Request.QueryString.ToString();
        }
        else
        {
            Response.Write("需要 AD 帳號");
            return;
        }
        
        System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        mySearcher.Filter = ("(cn=" + userName + ")");
        SearchResult de = mySearcher.FindOne();

        if (de == null)
        {
            Response.Write("找不到");
            return;
        }
/*        
        if (de != null)
        {
            Response.Write("使用者已存在");
            return;
        }

        // Check AD 目錄
        string strDepartID = "L00300";
        string strOU = "OU=epais";
        string strOUOK = strOU;
        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
        
        strOU = "OU=" + strDepartID.Substring(0, 2) + "," + strOU;
        mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 2) + ")");
        de = mySearcher.FindOne();

        if (de != null)
        {
            strOUOK = strOU;
            
            dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOU + "," + stradDC, stradID, stradPass);
            strOU = "OU=" + strDepartID.Substring(0, 4) + "," + strOU;

            mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
            mySearcher.Filter = ("(ou=" + strDepartID.Substring(0, 4) + ")"); 
            de = mySearcher.FindOne();

            if (de != null)
            {
                strOUOK = strOU;
            }
        }

        
        Response.Write("LDAP://" + stradIP + "/" + strOUOK + "," + stradDC);
        

        
        //if (strOUOK != "")
        //{
        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + strOUOK + "," + stradDC, stradID, stradPass);
        
        
        DirectoryEntry newUser = dirEntry.Children.Add("CN=" + userName, "user");
        newUser.Properties["samAccountName"].Value = userName;
        newUser.Properties["givenName"].Value = "userInfo.FirstName";
        newUser.Properties["sn"].Value = "userInfo.LastName";
        newUser.Properties["displayName"].Value = "userInfo.LoginName";
        newUser.Properties["telephoneNumber"].Value = "userInfo.ContactNumber";
        newUser.Properties["mail"].Value = "userInfo.EmailAddress";
        newUser.Properties["proxyAddresses"].Value = "userInfo.EmailAddress";
        newUser.Properties["title"].Value = "userInfo.JobTitle";
        newUser.Properties["company"].Value = "userInfo.Company";
        
        newUser.CommitChanges();
        oGUID = newUser.Guid.ToString();
        newUser.Invoke("SetPassword", new object[] { "userPassword" });
        newUser.CommitChanges();
//        newUser.Invoke(
        int val = (int)newUser.Properties["userAccountControl"].Value;
        newUser.Properties["userAccountControl"].Value = val & ~0x2;
        newUser.CommitChanges();
        newUser.Close();

        newUser.Close();
//        dirEntry.Properties["member"].Add(userName);

        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN=Domain Admins,CN=Users," + stradDC, stradID, stradPass);
        
        Response.Write(dirEntry.Username.ToString()+"<BR>");

        dirEntry.Properties["member"].Add("CN=" + userName + "," + strOUOK + ",DC=ad,DC=ysbsoft,DC=com");
        dirEntry.CommitChanges();
        dirEntry.Close();

        

        
        //System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);
        dirEntry = new DirectoryEntry("LDAP://" + stradIP
            //            +  "/" + "OU=test," + stradDC
                    ,
                    stradID, stradPass);
        mySearcher.Filter = ("(cn=" + userName + ")");
  
        de = mySearcher.FindOne();
 * */

        dirEntry = new DirectoryEntry("LDAP://" + stradIP + "/" + "CN="+userName+"," + stradDC
            , stradID, stradPass);
//        dirEntry.Properties["company"].Value = "公司";
        
//        dirEntry.CommitChanges();
       
        string value = string.Empty;

        if (de != null)
        {
            foreach (string key in de.Properties.PropertyNames)
            {
                foreach (object propVal in de.Properties[key])
                {
                    value = key + " = " + propVal;
                    Response.Write(value + "<BR>");
                }
            }
        }

        ;

        foreach (string key in de.Properties.PropertyNames)
        {
            foreach (object propVal in de.Properties[key])
            {
                if (key == "adspath")
                {
                    value = key + " = " + propVal;
                    Response.Write(propVal.ToString() + "<BR>");
                }
            }
        }
//        Response.Write(de.Properties["adspath"].ToString());
        

        dirEntry.Close();

         
    }
}