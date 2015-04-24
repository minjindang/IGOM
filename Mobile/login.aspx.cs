using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IGOM.Logic;
using EMP.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Mobile_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UUID = "" + Request["DID"];
        string MTYPE= "" + Request["MTYPE"];
        if (Page.IsPostBack) return;

            // 2014/7/5
            if (UUID != "" && MTYPE != "")
            {
                MOB.MOBServices wsmob = new MOB.MOBServices();
                wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
                string strRV = wsmob.WSMOB062(MTYPE, UUID, "");
                JObject obj = JsonConvert.DeserializeObject<JObject>(strRV);
                string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N   
                if (strisSuccess == "Y")
                {
                    Page.Title = obj.Property("ADID").Value.ToString();
                    txtAcc.Text = obj.Property("ADID").Value.ToString();
                    strRV = wsmob.WSMOB063(obj.Property("ADID").Value.ToString(), "");
                    obj = JsonConvert.DeserializeObject<JObject>(strRV);
                    strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N   
                    if (strisSuccess == "Y")
                    {
                        string strUserData = obj.Property("UserData").Value.ToString();  // UserData
                        //LoginManager.SetAuthenTicket(strUserData, txtAcc.Text.Trim());
                        MOBLoginManager.SetAuthenTicket(strUserData, txtAcc.Text.Trim());
                        // 直接到下一個頁面囉
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {

            }
    }

    public void Login()
    {
        /*
        if (string.IsNullOrEmpty(txtDeviceID.Text))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查不到 Device ID" , "", "");
            this.Page = tempPage;
            return;
        }
         */
         

        MOB.MOBServices wsmob = new MOB.MOBServices();
        wsmob.Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MOBWebServices"];
        string strRV = wsmob.WSMOB001(txtAcc.Text.Trim(), txtPass.Text.Trim(), "", "", "");
        JObject obj = JsonConvert.DeserializeObject<JObject>(strRV);
        string strisSuccess = obj.Property("isSuccess").Value.ToString();  // 是否登入成功 Y/N

        if (strisSuccess == "Y")
        {
            string strUserData = obj.Property("UserData").Value.ToString();  // UserData
            MOBLoginManager.SetAuthenTicket(strUserData, txtAcc.Text.Trim());

            string UUID = "" + Request["DID"];
            string MTYPE= "" + Request["MTYPE"];
            if (UUID != "" && MTYPE != "")
            {
                // 判斷裝置是否已經註冊
                strRV = wsmob.WSMOB003(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card)
                    , txtAcc.Text.Trim(), MTYPE, UUID, "");
                obj = JsonConvert.DeserializeObject<JObject>(strRV);
                string statuscd = obj.Property("status_cd").Value.ToString();
                if (statuscd == "1")
                {
                    // 註冊裝置
                    string strMsg = obj.Property("message").Value.ToString();
                    strRV = wsmob.WSMOB002(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card)
                        , txtAcc.Text.Trim(), MTYPE, UUID, "");
                }
            }

            //MOBLoginManager.SetAuthenTicket(strUserData, txtAcc.Text.Trim());
            Response.Redirect("main.aspx");
            /*

            

            // 判斷裝置是否已經註冊
            strRV = wsmob.WSMOB003(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card)
                , txtAcc.Text.Trim(), txtDeviceType.Text, txtDeviceID.Text, "");
            obj = JsonConvert.DeserializeObject<JObject>(strRV);
            string statuscd = obj.Property("status_cd").Value.ToString();
            if (statuscd != "3")
            {
                if (statuscd == "1")
                {
                    string strMsg = obj.Property("message").Value.ToString();
                    strRV = wsmob.WSMOB002(MOBLoginManager.GetTicketUserData(MOBLoginManager.LoginUserData.Id_card)
                        , txtAcc.Text.Trim(), txtDeviceType.Text, txtDeviceID.Text, "");
                    obj = JsonConvert.DeserializeObject<JObject>(strRV);
                    strisSuccess = obj.Property("isSuccess").Value.ToString();
                    if (strisSuccess == "Y")
                    {
                        Page tempPage = this.Page;
                        CommonFun.MsgShow(ref tempPage,
                           CommonFun.Msg.Custom, "Device 已註冊,等待審核" , "", "");
                        this.Page = tempPage;
                    }
                    else
                    {
                        Page tempPage = this.Page;
                        CommonFun.MsgShow(ref tempPage,
                           CommonFun.Msg.Custom, "註冊 Device 時產生錯誤", "", "");
                        this.Page = tempPage;
                    }
                }
                else
                {
                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage,
                       CommonFun.Msg.Custom, obj.Property("message").Value.ToString(), "", "");
                    this.Page = tempPage;

                }
            }
            else
            {
                Response.Redirect("main.aspx");
            }
             */
        }
        else
        {
            
            Response.Write("TEST");

            Page tempPage = this.Page;

            if (obj.Property("message").Value.ToString() != "")
            {
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, obj.Property("message").Value.ToString(), "", "");
            }
            else
            {
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "登入失敗", "", "");
            }
            this.Page = tempPage;
            return;
        }
    }


    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        Login();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Login();
    }
}