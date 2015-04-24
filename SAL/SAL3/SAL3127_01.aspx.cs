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
using System.Collections;
using System.Configuration;
using System.IO;

public partial class SAL_SAL3_SAL3127 : BaseWebForm
{
    string v_orgid;
    protected void Page_Load(object sender, EventArgs e)
    {
        v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        addlist();
        ddlcno.ReturnEvent = true;
        ddlcno.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(ddlcnoChanged); 

        UcSaCode2.ReturnEvent = true;
        UcSaCode2.CodeChanged +=new uc_ucSaCode.CodeChangedEventHandler(UcSaCode2_CodeChanged); // 項目類別   
        get_kind();


        ddltype_SelectedIndexChanged(sender, e);

        if (Page.IsPostBack) return;   
    }  
    
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;   
        UcSaCode2.Code_type = TYPE.SelectedValue; //code_type=發放方式代碼
        UcSaCode2.Rebind();
    }      

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) //發放方式
    {
        UcSaCode2.Code_type = TYPE.SelectedValue;  //code_type=發放方式代碼      
        UcSaCode2.Rebind(); //項目類別
        addlist();
    }

    // step2 項目類別 
    protected void ddlcnoChanged(object sender, EventArgs e)
    {
        Enable_ddl();
    }

    // 項目類別 
    protected void UcSaCode2_CodeChanged(object sender, EventArgs e)
    {
        addlist();
    }

    protected void Enable_ddl() 
    {
                if (ddlcno.SelectedValue != "005")
               {
                   Label2.Visible = false;
                   DropDownList2.Visible = false;
                   //非005其他薪津發放時，代碼固定001
                    step21.Visible = false;
                    step22.Visible = false;
                    step23.Visible = false;
               }
                else  //005其他薪津發放時選擇項目名稱後，查詢SQL 所得格式
               {
                   Label2.Visible = true;
                   DropDownList2.Visible = true;
                    step21.Visible = true;
                    step22.Visible = true;
                    step23.Visible = true;

                    add_ddl2();//查詢所得格式
               }

    }
    protected void add_ddl2()  //查詢所得格式
    {
        DropDownList2.Items.Clear();
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string name = DropDownList3.SelectedValue.ToString();  //項目名稱代碼
        SAL3127 sal3127 = new SAL3127();
        DataTable data = sal3127.queryddl2Data(strOrgCode, name);
        if (data != null && data.Rows.Count > 0)
        {
            string textno = data.Rows[0]["item_icode"].ToString(); //所得格式代碼
            DataTable datatext = sal3127.queryddl2textData(textno); //文字顯示
            string ddltext="";
            if (datatext != null && datatext.Rows.Count > 0)
            {     
               ddltext = datatext.Rows[0]["code_desc1"].ToString();            
            }
           ListItem item = new ListItem();
           item.Value = textno;
           item.Text = ddltext;
           DropDownList2.Items.Add(item); 
        }
    }

    //項目名稱變更
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        add_ddl2();
    }

    
    protected void addlist() //項目名稱
    {    
        DropDownList3.Items.Clear();
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        string strTYPE = TYPE.SelectedValue.ToString();//發放方式代碼
        string strcode = UcSaCode2.SelectedValue.ToString();  //項目類別代碼
        string strddl = DropDownList1.SelectedValue.ToString();  //是否隨薪代碼
    //    Response.Write(strOrgCode+ ","+strTYPE+","+ strcode+","+ strddl);

        SAL3127 sal3127 = new SAL3127();
        DataTable data = sal3127.queryddlData(strOrgCode, strTYPE, strcode, strddl);
        if (data != null && data.Rows.Count > 0)
        {            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = data.Rows[i]["ITEM_NAME"].ToString();
                item.Value = data.Rows[i]["ITEM_CODE"].ToString();
                DropDownList3.Items.Add(item); //add項目名稱
   
            }
        }     
        add_ddl2(); //項目名稱 --> 所得格式
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) //是否隨薪
    {
        addlist();
    }

    //step1 
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedValue == "SAL_PAYITEM") //各類補發代扣檔
        {
            Label1.Visible = true;
            TextBox1.Visible = false;//第二步改 TextBox (原本的 下拉選項都移除) 但暫時不儲存到資料庫
            ddlcno.Visible = false;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            step21.Visible = true;
            step22.Visible = true;
            step23.Visible = true;
            step5.Visible = false;  //0801
       //     Label3.Text = "轉檔";
            SAL_PAYITEM_Btn.Visible = true;
            Button2.Visible = false;  //0801
        }
        else  //所得扣繳資料檔
        {
            Label1.Visible = false;
            TextBox1.Visible = true;//第二步改 TextBox (原本的 下拉選項都移除) 但暫時不儲存到資料庫
            ddlcno.Visible = false;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            step21.Visible = false;
            step22.Visible = false;
            step23.Visible = false;
            step5.Visible = false; //0801
    //        Label3.Text = "轉入暫存檔"; 
            SAL_PAYITEM_Btn.Visible = true;  //0801
            Button2.Visible = false;  //0801
            //        Enable_ddl();  第二步改 TextBox (原本的 下拉選項都移除) 但暫時不儲存到資料庫
        }
    }
    //重置按鈕
    protected void Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3127_01.aspx");
    }

  
  
    //確定上傳
    protected void Button_Upload_Click(object sender, EventArgs e)
    {
        string FileName = "";
        string FilePath = "";
        if (upload_check())
        {
            // 使用原來檔名
            FileName = this.FileUpload1.FileName;

        //  FilePath = Server.MapPath(app.FilePath); //'( * 實際磁碟路徑 Ex. FilePath == "C:\AppName\..." ; )
            string FileUploadPath = ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "SAL\\";
            FilePath = Server.MapPath(FileUploadPath);
            
            if ((!Directory.Exists(FilePath)))
            {
                Directory.CreateDirectory(FilePath);
                //My.Computer.FileSystem.CreateDirectory(FilePath); //'( * 如果資料夾不存在則新建該資料夾 ; )
            }
       
            
            string fname = ""; 
            this.FileUpload1.SaveAs(FilePath + FileName);

            lbFilename.Text = this.FileUpload1.FileName;
            TextBox_filename.Text = FileName;
            //'存檔
  //      url &= "?BTN=" & Me.Button_btn.ClientID
  //      url &= "&FNAME=" & Me.TextBox_filename.ClientID
            //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "upload_ok", "opener.$get('" + TextBox_filename.Text + "').value='" 
            //    + this.FileUpload1.FileName + "';" + "opener.$get('" + this.TextBox_btn.Text + "').click();void(0);", true);

            //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "w_close", "window.close();", true);  
          
        }
    }
    //上傳檢查
    protected bool upload_check()
    {
        bool rv = true;
        if (this.FileUpload1.PostedFile != null)
        { 
            //  Me.LoginManager.UserData.v_ROLE_ORGID.ToString
            int len = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode).Length;
            TextBox_orgid.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
            string FileName = this.FileUpload1.FileName;
            TextBox_filename.Text = FileName;

            if (string.IsNullOrEmpty(FileName))
            {
                rv = false;
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "請選擇檔案!", "", "");
                this.Page = tempPage;
                return rv;
            }
            //' 副檔名是否正確(*.CSV) 
            if ((System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower() != ".csv"))
            {
                rv = false;
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage,
                   CommonFun.Msg.Custom, "副檔名應為.csv", "", "");
                this.Page = tempPage;
                return rv;
            }
           
              //' 檔名格式檢查
              if ( FileName.Substring(0,len).ToLower() != TextBox_orgid.Text.ToLower())
               {
                   rv = false;
                   Page tempPage = this.Page;
                   CommonFun.MsgShow(ref tempPage,
                      CommonFun.Msg.Custom, "檔名格式不正確!", "", "");
                   this.Page = tempPage;       
                return rv;
               }            
        }
        else
        {
            rv = false;
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇檔案!", "", "");
            this.Page = tempPage;
            return rv;
        }

      return rv;
    }

    protected void DeletePitmbak()
    {
         v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼
        SAL3127 sal3127 = new SAL3127();
        sal3127.querydelete2Data(v_orgid);//清空暫存檔資料
         v_code_sys = "005";
         v_code_type = TYPE.SelectedValue.ToString();//發放方式代碼
         v_code_no = UcSaCode2.SelectedValue.ToString();  //項目類別代碼
         v_code = DropDownList3.SelectedValue.ToString();  //項目名稱
         sal3127.querydelete3Data(v_orgid, v_code_sys, v_code_type, v_code_no, v_code); // 清除 SaPitm 資料
    }
    protected void DeleteIncobak()
    {
        SAL3127 sal3127 = new SAL3127();      
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼      
        sal3127.querydeleteData(strOrgCode);  
    }

    int cnt=0; //資料筆數
    string ErrMesg = ""; //錯誤訊息
    
  
    string v_code_sys;
    string v_code_type;
    string v_code_no;
    string v_code;
    string v_mid;
    string v_mdate;

    //轉檔按鈕
    protected void SAL_PAYITEM_Btn_Click(object sender, EventArgs e)
    {
        string v_act = ddltype.SelectedValue.ToString();
        cnt = 0;
        //先刪除暫存資料
        if(v_act =="SAL_PAYITEM")
        {
 //            DeletePitmbak();             
        }
        else        
        {
  //          DeleteIncobak(); //暫存檔 0801 無暫存檔
            if (this.UcSaCode3.SelectedValue == "")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請選擇投保單位", "", "");
                return;
            }
            if (TextBox_filename.Text == "")
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請選擇上傳檔案", "", "");
                return;
            }
        }

        // '' 讀取檔案
        string FileName = TextBox_filename.Text;
        string FilePath = Server.MapPath( ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "SAL\\");
              
        try
        {
            using (System.IO.StreamReader fr = new System.IO.StreamReader(FilePath + FileName, System.Text.Encoding.GetEncoding("big5")))
            {   // 逐行讀取資料
                string datastr = "";
                while (!fr.EndOfStream)
                {
                    datastr = fr.ReadLine();
                    cnt = cnt + 1;

                   datastr= datastr.Replace("\"","");
              
                    if (v_act == "SAL_PAYITEM")  //各類補發代扣檔
                    {                      
                        ImportPitmbak(datastr);          //0517改 不轉入暫存檔 直接轉檔
                    }
                    else  //所得扣繳資料檔
                    {
                        NewImportInco(datastr); //0801改
                  //      ImportIncobak(datastr);   //先轉入暫存檔  //0801
                  //       step5_2();  //0801
                    }
                            
                }
                /*           if (v_act == "SAL_PAYITEM")  // 將暫存資料轉入 0517改
                             {
                                 ImportPitmFromBak();
                             }
                 */
             }
        }
        catch (Exception ex)
        {
            ErrMesg = "轉檔錯誤,無法轉檔...";
        }

        if (v_act == "SAL_PAYITEM")  //轉檔結果  //各類補發代扣檔
        {
            Label_fname.Text = FileName;
            lbcnt.Text = cnt.ToString();
            lbincnt.Text = ins_cnt.ToString();
            tran.Visible = true;

            Message();
        }
        else
        {
            Label_fname.Text = FileName;
            lbcnt.Text = cnt.ToString();
            lbincnt.Text = ins_cnt.ToString();
            tran.Visible = true;

            newMessage();
        }
          

     /*   if ((v_act == "SAL_SAINCO") & (cnt > 0) & (ins_cnt > 0))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "trans_ok", "opener.$get('" + this.TextBox_btn.Text + "').click();void(0);", true);
        }
      */ 

    }

    protected void newMessage() //0801 add
    {
        if (ErrMesg != "")
        {
            Label_ErrMsg.Text = ErrMesg;
        }
        else if (MissingCnt > 0)
        {
            this.Label_ErrMsg.Text = "下列" + Convert.ToString(MissingCnt) + "人:<br/>" + MissingList + "之所得類別錯誤,轉檔失敗!";
        }

        if (Label_ErrMsg.Text != "")
        {
            this.Label_ErrMsg.Visible = true;
        }
        else
        {
            this.Label_ErrMsg.Visible = false;
        }
    }

    protected void Message()
    {        
        if (ErrMesg !="")
        {
            Label_ErrMsg.Text = ErrMesg;
        }
        else if (MissingCnt > 0)
        {
            this.Label_ErrMsg.Text = "員工基本資料檔中無下列" + Convert.ToString(MissingCnt) + "人之身分證號:<br/>" + MissingList + "<br/>以上人員無法轉檔!";

        }

        if (Label_ErrMsg.Text != "" )
        {
            this.Label_ErrMsg.Visible = true;
        }
        else
        {
            this.Label_ErrMsg.Visible = false;
        } 
    }

    int MissingCnt = 0; //身分證號錯誤筆數
    int ins_cnt = 0; // 轉入筆數
    string MissingList = ""; //身分證號錯誤清單

    int newMissingCnt = 0; //身分證號錯誤筆數
    string newMissingList = ""; //身分證號錯誤清單

    protected void ImportPitmbak(string datastr)
    {
        string v_idno = "";
        string v_seqno = "";
        string v_amt = "";

         v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼        
         v_code_sys = "005";
         v_code_type = TYPE.SelectedValue.ToString();//發放方式代碼
         v_code_no = UcSaCode2.SelectedValue.ToString();  //項目類別代碼
         v_code = DropDownList3.SelectedValue.ToString();  //項目名稱
         v_mid = LoginManager.UserId; //登入者員工編號 
   
         string PAYITEM_Budget_code = UcSaCode1.SelectedValue; //預算來源代碼
       

        string[] DAry = datastr.Split(',');

        if (DAry.Length >= 1)   //If UBound(DAry) >= 1 Then
        {
            v_idno = DAry[0];
            v_amt = DAry[1];
        }

    
        if (v_idno !="")
        {
         
            SAL3127 sal3127 = new SAL3127();        
            DataTable data = sal3127.queryseqnoData(v_orgid, v_idno);   //idno =身分證字號
            if (data != null && data.Rows.Count > 0)
            {
                  v_seqno  = data.Rows[0]["base_seqno"].ToString();
            }       

            if (v_seqno =="")
            {
                if (MissingList !="")
                {
                    MissingList = MissingList + "<br>" + v_idno;
                }
                else
                {
                    MissingList = MissingList + v_idno;
                }
                MissingCnt = MissingCnt + 1;
            }
        }

       
        string PAYITEM_flow_id ="0";
        string PAYITEM_merge_flow_id ="0";
        int n = 0;
        if (v_seqno != "" && int.TryParse(v_amt, out n))
        {         
            SAL3127 sal3127 = new SAL3127();
            sal3127.queryinsertData(v_orgid, v_seqno, PAYITEM_flow_id, PAYITEM_merge_flow_id, v_code_sys, v_code_type, v_code_no, v_code,
                PAYITEM_Budget_code,v_amt, v_mid);             
            ins_cnt = ins_cnt + 1;       
        }
    }
    /* 將暫存資料轉入
    protected void ImportPitmFromBak()
    {
        SAL3127 sal3127 = new SAL3127();
        sal3127.querygropData(v_mid, v_mdate, v_orgid, v_code_sys, v_code_type, v_code_no, v_code); 
    }
    */

    protected void NewImportInco(string aStr) //0801 add
    {
        SAL3127 sal3127 = new SAL3127();
              
        v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼     
      
        string v_idno = "";
        string v_seqno = "";
        string v_icode = "";
        string v_inco_date = "";
        string v_inco_ym = "";
        string v_inco_no = "";
        string v_inco_amt = "";
        string v_inco_real_amt = "";
        string v_inco_txam = "";
        string v_inco_addr = "";
        string v_inco_rent_no = "";
        string v_inco_vouchers = "";
        string v_inco_summons = "";     
        string v_name ="";

        string[] DAry = aStr.Split(',');


        v_idno = DAry[0].ToString(); //先抓身分證字號，判斷是否存在SAL_SABASE
        DataTable dataseq = sal3127.queryseqnoData(v_orgid, v_idno);
        if (dataseq != null && dataseq.Rows.Count > 0)
        {
            v_seqno = dataseq.Rows[0]["base_seqno"].ToString();
        }
        //1.1若存在則更新 SAL_SABASE的資訊 地址+姓名
        //1.2不存在則新增 SAL_SABASE資料 ，取得BASE_SEQNO  
        if (v_seqno == "")
        {
            sal3127.insertSABASE(v_idno, v_name, v_inco_addr);
        }
        //else
        //{
        //    sal3127.updateSABASE(v_orgid, v_seqno, v_idno, v_name, v_inco_addr);
        //}
          string geticode="";
        for (int i = 0; i <= DAry.Length; i++)
        {
            if (i == 0) //1:身分證字號
            {               
                v_idno = DAry[i].ToString();
                DataTable data = sal3127.queryseqnoData(v_orgid, v_idno);
                if (data != null && data.Rows.Count > 0)
                {
                    v_seqno = data.Rows[0]["base_seqno"].ToString();
                }  
            }
            else if (i == 1)//2:所得類別
            {
                 geticode = DAry[i].ToString();
                DataTable data = sal3127.geticode(geticode);
                 if (data != null && data.Rows.Count > 0)
                 {
                     v_icode = data.Rows[0]["code_no"].ToString();
                 }  
            }
            else if (i == 2) //所得日期
            {               
                v_inco_date = DAry[i].ToString();
                v_inco_date = Convert.ToString(Convert.ToInt32(v_inco_date) + 19110000); //所得日期轉西元年
                v_inco_ym = v_inco_date.Substring(0, 6); //(轉西元年取前六)  
            }
            else if (i == 3) //4:姓名
            {    
                v_name =DAry[i].ToString();                 
            }
            else if (i == 4) //5:流水號
            {
                v_inco_no = DAry[i].ToString();
            }
            else if (i == 5) //6:所得額
            {
                v_inco_amt = DAry[i].ToString();
                int n = 0;
                if (int.TryParse(v_inco_amt, out n))
                {
                    //break;
                }

                //v_inco_real_amt = DAry[i].ToString();
                //n = 0;
                //if (int.TryParse(v_inco_real_amt, out n))
                //{
                //    break;
                //}

            }
            else if (i == 6) //7:所得稅
            {
                v_inco_txam = DAry[i].ToString();
                int n = 0;
                if (int.TryParse(v_inco_txam, out n))
                {
                    //break;
                }
            }
            else if (i == 7)  //8:地址
            {              
                v_inco_addr = DAry[i].ToString();
            }
            else if (i == 8)   //9:所得註記
            {
                v_inco_rent_no = DAry[i].ToString();
            }
            else if (i == 9)   //10:付款憑單
            {
                v_inco_vouchers = DAry[i].ToString();
            }
            else if (i == 10)   //11:收入傳票
            {
                v_inco_summons = DAry[i].ToString();
            }
        }

        if (v_icode == "")   //對應不到的當筆轉檔失敗
        {
            if (newMissingList != "")
            {
                newMissingList = newMissingList + "<br>" + v_name + "," + geticode;
            }
            else
            {
                newMissingList = newMissingList + v_idno;
            }
            newMissingCnt = newMissingCnt + 1;
        
        }
        
        int x = 0;
        if ( v_seqno != "" &&
            int.TryParse(v_inco_amt, out x) &&
            int.TryParse(v_inco_txam, out x) &&
            v_icode != ""
          )
        {          
            DataTable getkey = sal3127.querydprikeyData();

            string key = DateTime.Now.ToString("yyyyMMdd")
                        + getkey.Rows[0][0].ToString();

            sal3127.insertinco(v_orgid, v_seqno, v_icode, v_inco_date, v_inco_ym, v_inco_no, v_inco_amt, v_inco_amt, v_inco_txam
                , v_inco_rent_no, v_inco_vouchers, v_inco_summons, key, UcSaCode3.SelectedValue);    

            ins_cnt = ins_cnt + 1;
        }
    }



    protected void ImportIncobak(string aStr)
    {
        v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼     
        string v_idno = "";
        string v_seqno = "";
        string v_inco_amt = "";
        string v_inco_txra = "";
        string v_inco_txam = "";
        string v_inco_fee = "";
        string v_inco_fees = "";
        string v_inco_leave_self = "";
        string v_inco_leave_sup = "";

        string v_inco_ym = "";
        string v_inco_date = "";

        string v_kind = ddlcno.SelectedValue.ToString(); // 項目類別
        string v_icode = "";
//        項目類別非005其他薪津發放時，代碼固定001，
//        項目類別005其他薪津發放時選擇項目名稱後，查詢SQL
       if(ddlcno.SelectedValue.ToString() !="005") //所得格式
       {
          v_icode = codeno.Text;
          v_code_type = v_code_no = v_code = "000";
       }
       else
       {
         //v_icode = DropDownList2.SelectedValue.ToString();  //0801 第二步改 TextBox (原本的 下拉選項都移除) 但暫時不儲存到資料庫
       }
        string[] DAry = aStr.Split(',');

        for (int i = 0; i <= DAry.Length; i++)
        {
            if (i == 0)
            {
                //1:身分證字號
                v_idno = DAry[i].ToString();
                if (v_idno=="")
                {
                    break; 
                }
            }
            else if (i == 1)
            {
                //2:所得年月
                v_inco_ym = DAry[i].ToString();

                if (v_kind == "002" || v_kind == "003" || v_kind == "004")
                {
                    v_inco_ym = Convert.ToString(Convert.ToInt32(v_inco_ym) + 1911);
                }
                else
                {
                    v_inco_ym = Convert.ToString(Convert.ToInt32(v_inco_ym) + 191100);
                }
            }
            else if (i == 2)
            {
                //3:給付日期
                v_inco_date = DAry[i].ToString();
                v_inco_date = Convert.ToString(Convert.ToInt32(v_inco_date) + 19110000);
            }
            else if (i == 3)
            {
                //4:給付總額
                v_inco_amt = DAry[i].ToString();
                int n = 0;
                if (int.TryParse(v_inco_amt, out n))
                {
                    break;
                }
            }
            else if (i == 4)
            {
                //5:扣繳稅額
                v_inco_txam = DAry[i].ToString();
            }
            else if (i == 5)
            {
                //6:公勞保費
                v_inco_fee = DAry[i].ToString();
            }
            else if (i == 6)
            {
                //7:健保費
                v_inco_fees = DAry[i].ToString();
            }
            else if (i == 7)
            {
                //8:自付退職金
                v_inco_leave_self = DAry[i].ToString();
            }
            else if (i == 8)
            {
                //9:機關負擔退職金
                v_inco_leave_sup = DAry[i].ToString();
            }
        }

        if(v_inco_txra=="")
        {
            v_inco_txra = "NULL";
        }
        if(v_inco_txam =="")
        {
            v_inco_txam = "0";
        }
        if(v_inco_fee=="")
        {
            v_inco_fee = "0";
        }
        if(v_inco_fees=="")
        {
            v_inco_fees = "0";
        }
        if(v_inco_leave_self=="")
        {
            v_inco_leave_self = "0";
        }
        if(v_inco_leave_sup=="")
        {
            v_inco_leave_sup = "0";
        }
        int x = 0;
        
        if (v_idno !="" && int.TryParse(v_inco_amt, out x))
        {          
            SAL3127 sal3127 = new SAL3127();
          
            DataTable data = sal3127.queryseqnoData(v_orgid, v_idno);
            if (data != null && data.Rows.Count > 0)
            {
                v_seqno = data.Rows[0]["base_seqno"].ToString();
            }
         
            if (v_seqno=="")
            {
                if (MissingList !="")
                {
                    MissingList = MissingList + "<br>" + v_idno;
                }
                else
                {
                    MissingList = MissingList + v_idno;
                }
                MissingCnt = MissingCnt + 1;
            }
        }
 

        if( v_seqno!="" && 
            (v_inco_txra == "NULL" || int.TryParse(v_inco_txra, out x)) &&
            int.TryParse(v_inco_txam, out x) &&
            int.TryParse(v_inco_fee, out x)  && 
            int.TryParse(v_inco_fees, out x) &&
            int.TryParse(v_inco_leave_self, out x) &&
            int.TryParse(v_inco_leave_sup, out x) && 
            v_icode !=""  
          )        
        {
           
            SAL3127 sal3127 = new SAL3127();
            DataTable getkey = sal3127.querydprikeyData();

            string key = DateTime.Now.ToString("yyyyMMdd")
                        + getkey.Rows[0][0].ToString();


            sal3127.queryinsert2Data(v_kind, v_seqno, v_orgid, v_inco_date, v_icode,
                v_inco_amt, v_inco_txra, v_inco_txam, v_inco_fee, v_inco_fees,
               v_inco_leave_self, v_inco_leave_sup, v_mid, v_mdate, v_inco_ym,key,
               v_code_type,v_code_no,v_code);
            
            ins_cnt = ins_cnt + 1;
        }
    }
    
    //轉入所得檔
    protected void Button1_Click(object sender, EventArgs e)
    {
        step5_2();
    }
    protected void step5_2()
    {
         TextBox_dup.Text = "0";
        TextBox_dup1.Text = "0";

        v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼   
        v_mdate = DateTime.Now.ToString("yyyyMMddHHmmss");
        v_mid = LoginManager.UserId; //登入者員工編號    
             
        SAL3127 sal3127 = new SAL3127();
        DataTable data = sal3127.querytableData(v_orgid);//GridView1 data
        if (data != null && data.Rows.Count > 0)
        {
            data.Columns.Add("exists_flag"); //Columns[0]
            for (int i = 0; i < data.Rows.Count; i++)
            {
                       
                DataTable exists_flag = sal3127.exists_flag(v_orgid,
                    data.Rows[i]["inco_code"].ToString(),
                    data.Rows[i]["inco_icode"].ToString(),
                    data.Rows[i]["inco_seqno"].ToString(),
                    data.Rows[i]["inco_date"].ToString(),
                    data.Rows[i]["inco_kind_code_type"].ToString(),
                    data.Rows[i]["inco_kind_code_no"].ToString(),
                    data.Rows[i]["inco_kind_code"].ToString()
                    );
              int v_dup = int.Parse(TextBox_dup.Text);
              int v_dup1 = int.Parse(TextBox_dup1.Text);
              string rv = "";
              string strym = "";
              if (exists_flag != null && exists_flag.Rows.Count >0)
              {
                   strym =exists_flag.Rows[0]["inco_ym"].ToString(); 
              
                    if (data.Rows[i]["inco_ym"].ToString() == strym )
                    {
                        v_dup = v_dup + 1;

                        if (rv !="＊") 
                        {
                            rv += "＊";
                        }                     
                        Label_dup.Visible = true;
                    }
                    else
                    {
                        v_dup1 = v_dup1 + 1;

                        if (rv != "！")
                        {
                            rv += "！";
                        } 
                        this.Label_dup1.Visible = true;
                    } 
              }
                data.Rows[i]["exists_flag"] = rv;
                data.Rows[i]["Inco_Code"] = SALARY.Logic.app.GetSaCode_Desc1("003", "005", data.Rows[i]["Inco_Code"].ToString());
                data.Rows[i]["Inco_Icode"] = SALARY.Logic.app.GetSaCode_Desc1("003", "004", data.Rows[i]["Inco_Icode"].ToString());
                data.Rows[i]["Inco_Ym"] = SALARY.Logic.app.Date_str(data.Rows[i]["Inco_Ym"].ToString());
                data.Rows[i]["Inco_Date"] = SALARY.Logic.app.show_date(data.Rows[i]["Inco_Date"].ToString());
                
                TextBox_dup.Text = v_dup.ToString();
                TextBox_dup1.Text = v_dup1.ToString();
            }     
            
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        else
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "無任何資料", "", "");
            this.Page = tempPage;
        }
    }

    protected void get_kind()
    {          
        SAL3127 sal3127 = new SAL3127();
        DataTable data = sal3127.querykindData(v_orgid);
        if (data != null && data.Rows.Count > 0)
        {
            TextBox_kind.Text = data.Rows[0]["inco_code"].ToString();
        }       
    }

    //轉入正式所得檔
    protected void Button_insert_Click(object sender, EventArgs e)
    {
        if (int.Parse(TextBox_dup1.Text) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "chg_kind", "get_chg_kind();", true);
        }
        else
        {
            insert_inco_Click();
        }
    }

    protected void Button_insert_inco_Click(object sender, EventArgs e)
    {
        insert_inco_Click();
    }
    protected void insert_inco_Click()
    {
        SAL3127 sal3127 = new SAL3127();
        string v_chg_kind = TextBox_chg_kind.Text;
        string v_kind = TextBox_kind.Text;
 //       Response.Write(v_orgid + "," + v_chg_kind + "," + v_kind);
        try
        {
            sal3127.queryinsert3Data(v_orgid, v_chg_kind, v_kind);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已轉檔", "", "");
            this.Page = tempPage;
        }
        catch
        {
            sal3127.queryinsert3Data(v_orgid, v_chg_kind, v_kind);
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "轉檔失敗", "", "");
            this.Page = tempPage;
        }
    }

    protected void GridView1_DataBinding(object sender, EventArgs e)
    {        
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if ( int.Parse(TextBox_dup.Text) < GridView1.Rows.Count)
        {
            Button_insert.Visible = true;
        }
        else
        {
            Button_insert.Visible = false;
        }          
    }

    //GridView1 Footer
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            try
            {
                // 筆數、金額加總        
                int v_cnt = 0;
                int v_amt = 0;
                int v_txam = 0;
                int v_fee = 0;
                int v_fees = 0;
                int v_leave_self = 0;
                int v_leave_sup = 0;

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    v_amt += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[7].FindControl("TextBox_amt")).Text);
                    v_txam += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[9].FindControl("TextBox_txam")).Text);
                    v_fee += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[10].FindControl("TextBox_fee")).Text);
                    v_fees += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[11].FindControl("TextBox_fees")).Text);
                    v_leave_self += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[12].FindControl("TextBox_leave_self")).Text);
                    v_leave_sup += Convert.ToInt32(((TextBox)GridView1.Rows[i].Cells[13].FindControl("TextBox_leave_sup")).Text);
                    v_cnt += 1;
                }

                TableCellCollection footer = e.Row.Cells;
                footer.Clear();

                    // 合計                 
                    TableCell tc1 = new TableCell();
                    tc1.Text = "合計";
                    tc1.ColumnSpan = 6;
                    tc1.HorizontalAlign = HorizontalAlign.Left;
                    footer.Add(tc1);

                    //共 N 筆
                    TableCell tc2 = new TableCell();
                    tc2.Text = "共 " + Convert.ToString(v_cnt) + " 筆";
                    tc2.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc2);

                    // 給付總額 
                    TableCell tc3 = new TableCell();
                    tc3.Text = v_amt.ToString();
                    tc3.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc3);

                    // 扣繳稅率     
                    footer.Add(new TableCell());

                    // 扣繳稅額 
                    TableCell tc4 = new TableCell();
                    tc4.Text = v_txam.ToString();
                    tc4.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc4);

                    // 公勞保費
                    TableCell tc5 = new TableCell();
                    tc5.Text = v_fee.ToString();
                    tc5.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc5);

                    // 健保費 
                    TableCell tc6 = new TableCell();
                    tc6.Text = v_fees.ToString();
                    tc6.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc6);

                    // 自付退職金 
                    TableCell tc7 = new TableCell();
                    tc7.Text = v_leave_self.ToString();
                    tc7.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc7);

                    // 機關負擔退職金 
                    TableCell tc8 = new TableCell();
                    tc8.Text = v_leave_sup.ToString();
                    tc8.HorizontalAlign = HorizontalAlign.Right;
                    footer.Add(tc8);  
            }
            catch { }        
        
        }
    }

   
}