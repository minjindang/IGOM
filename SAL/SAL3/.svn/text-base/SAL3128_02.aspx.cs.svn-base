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
using System.Transactions;

public partial class SAL3128_02 : BaseWebForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UcSaCode2.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(UcSaCode2_CodeChanged); //所得格式

        if (Page.IsPostBack) return;
        init();
    }
    protected void UcSaCode2_CodeChanged(object sender, EventArgs e) //所得格式
    {
        switch (UcSaCode2.SelectedValue)
        {
            case "014":
                Doc_Type.Visible = true;
                Doc_Type.Items.Clear();
                
                ListItem lit = new ListItem("---不設定---", "N");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("98 非自行出版之稿費、版稅等七項", "98");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("99 自行出版之稿費、版稅、作曲等", "99");
                Doc_Type.Items.Add(lit);
                break;
            case "012":
                Doc_Type.Visible = true;
                Doc_Type.Items.Clear();

                lit = new ListItem("---不設定---", "N");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("80 汽車駕駛訓練補習班", "80");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("81 文理、升學、語文、法商職業補習班", "81");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("82 縫紉、美容、美髮、音樂、舞蹈技藝及其他補習班", "82");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("83 私立托兒所", "83");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("84 私立幼稚園", "84");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("85 托育中心", "85");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("86 安親班", "86");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("87 私立養護、療養院所", "87");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("88 私立護理機構及依老人福利機構設置標準設立", "88");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8A 職工福利金", "8A");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8B 違約金", "8B");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8C 佃農因終止375租約取得之補償費", "8C");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8D 個人遷讓非自有房屋、土地所取得之補償費", "8D");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8E 多層次傳銷參加人直接進貨取得之業績獎金或各種補助費", "8E");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("8Z 其他", "8Z");
                Doc_Type.Items.Add(lit);
                break;
            case "017":
                Doc_Type.Visible = true;
                Doc_Type.Items.Clear();

                lit = new ListItem("---不設定---", "N");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("A 實報實銷", "A");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("B 非實報實銷", "B");
                Doc_Type.Items.Add(lit);

                break;

            case "011":
                Doc_Type.Visible = true;
                Doc_Type.Items.Clear();
                lit = new ListItem("91　競技競賽及機會中獎獎金", "");
                Doc_Type.Items.Add(lit);
                lit = new ListItem("91D 政府舉辦獎券中獎獎金", "D");
                Doc_Type.Items.Add(lit);
                break;
            default:
                Doc_Type.Visible = false;
                Doc_Type.Items.Clear(); 
                lit = new ListItem("", "");
                Doc_Type.Items.Add(lit);
                break;
        }

    }

    protected void init()
    {
        tbidno.Text =tbName.Text =tbAddress.Text = INCO_HEALTH_EXT.Text = INCO_RENT_ADDR.Text = INCO_VOUCHERS.Text = INCO_RENT_NO.Text
            =INCO_SUMMONS.Text =  UcDate3.Text = TextBox1.Text = TextBox2.Text = TextBox3.Text = "";

        DDL_Bind(); //所得年月
    }

    protected void DDL_Bind() //所得年月
    {
        for (int i = DateTime.Now.Year - 1911 - 2; i <= DateTime.Now.Year - 1911 + 1; i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.SelectedValue = (DateTime.Now.Year - 1911).ToString();

        for (int i = 1; i <= 12; i++)
        {
            ddlMonth.Items.Add(i.ToString().PadLeft(2, '0'));
        }
        ddlMonth.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, '0');
    }

    protected void btn_cancel_Click(object sender, EventArgs e) //回上頁
    {
        Response.Redirect("SAL3128_01.aspx");
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        doOK(false);
    }

    protected void btn_ok_back_Click(object sender, EventArgs e)
    {
        doOK(true);
    }

    protected void doOK(bool isBack)
    {
        string base_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        if (string.IsNullOrEmpty (tbidno.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "身分證字號不可空白!", "", "");
            return;
        }
        if (string.IsNullOrEmpty(tbName.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "人員姓名不可空白!", "", "");
            return;
        }
        if (string.IsNullOrEmpty(tbAddress.Text.Trim()))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "地址不可空白!", "", "");
            return;
        }      
        if (string.IsNullOrEmpty(UcSaCode2.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請選擇所得格式!", "", "");
            return;
        }
        if (string.IsNullOrEmpty(UcSaCode3.SelectedValue))
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請選擇預算來源!", "", "");
            return;
        }

        SAL3128 SAL3128 = new SAL3128();
        using (TransactionScope trans = new TransactionScope())
        {
            if (lbStatus.Text == "add")
            {
                SAL3128.insertSABASE(tbidno.Text.Trim(), tbName.Text.Trim(), tbAddress.Text.Trim(), ddl_base_type.SelectedValue, tbServicePlace.Text, tbDcodeName.Text );
            }
            else if (lbStatus.Text == "update")
            {
                SAL3128.updateSABASE(base_orgid, tbidno.Text.Trim(), tbName.Text.Trim(), tbAddress.Text.Trim(), ddl_base_type.SelectedValue, tbServicePlace.Text, tbDcodeName.Text );
            }
            else
            {
                Page tempPage = this.Page;
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請勿輸入正式員工!", "", "");
                return;
            }          
                
                DataTable datat = SAL3128.querykeyData();
                string prikey = DateTime.Now.ToString("yyyyMMdd") + datat.Rows[0][0].ToString(); //prikey
                string strno = SAL3128.getSABASE(base_orgid, tbidno.Text.Trim()).Rows[0]["base_seqno"].ToString(); //員工編號
                string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼 
            
                string yymm = (CommonFun.getInt(ddlYear.SelectedValue) + 1911).ToString() + ddlMonth.SelectedValue.ToString();//所得年月
                string date = UcDate3.Text;//給付日期
                if(date !="")
                date = (int.Parse(date.Substring(0, 3)) + 1911).ToString() + date.Substring(3, 4);
                string icode = UcSaCode2.SelectedValue;//所得格式;
                string amt = TextBox1.Text;//所得額
                string txra = TextBox2.Text; //稅率
                string txam = TextBox3.Text;//所得稅
                string Budget_code = UcSaCode3.SelectedValue;//預算來源;
              
                DataTable dt_no = SAL3128.getno((int.Parse(ddlYear.SelectedValue) + 1911).ToString() , icode);
                string inco_no = dt_no.Rows[0][0].ToString(); //流水號
                string Doc_type = Doc_Type.SelectedValue; //所得明細帶號
                string rent_no = INCO_RENT_NO.Text; //房屋稅籍編號
                string RENT_ADDR = INCO_RENT_ADDR.Text; //房屋地址
                string VOUCHERS = INCO_VOUCHERS.Text;//付款憑單
                string SUMMONS = INCO_SUMMONS.Text ;//收入傳票
                string HEALTH_EXT = INCO_HEALTH_EXT.Text; //補充保費
                string inco_muser = LoginManager.UserId;//登入者員工編號

                SAL3128.queryaddData(strno, strOrgCode, date, icode, amt, txra, txam, inco_muser, yymm, prikey, Budget_code,
                         inco_no,  Doc_type, rent_no,  RENT_ADDR, VOUCHERS,SUMMONS,HEALTH_EXT );

                trans.Complete();

                string url = (isBack ? "SAL3128_01.aspx" : "");
                Page pPage = this.Page;
                CommonFun.MsgShow(ref pPage, CommonFun.Msg.Custom, "流水號: " + inco_no + "，新增成功", url, "");
                this.Page = pPage;
                lbStatus.Text = "update";
        
        }
    }

    protected void tbidno_TextChanged(object sender, EventArgs e)
    {

        Page tempPage = this.Page;
        if (tbidno.Text.Trim().Length != 10)
        {
            tbidno.Text = "";
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "身分證字號須為10碼!", "", "");
            return;
        }
        else if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf (tbidno .Text.Trim().Substring (0,1)) < 0)
        {
            tbidno.Text = "";
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "身分證字號第一碼為英文字母大寫!", "", "");
            return;
        }
        else if ("12".IndexOf(tbidno.Text.Trim().Substring(1, 1)) < 0)
        {
            tbidno.Text = "";
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "身分證字號第二碼為1或2!", "", "");
            return;
        }
        else if (!CommonFun.IsNum(tbidno.Text.Trim().Substring(2)))
        {
            tbidno.Text = "";
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "身分證字號後7碼為數字!", "", "");
            return;
        }
  

        string orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        DataTable dt = new SAL3128().getSABASE(orgid, tbidno.Text.Trim());
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["base_status"].ToString() == "Y")
            {
                string msg = dt.Rows[0]["base_seqno"].ToString() + "-" + dt.Rows[0]["base_name"].ToString() + "(" + dt.Rows[0]["base_idno"].ToString() + ")此為正式員工。";
                lbStatus.Text = "";
                CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, msg, "", "");
                return;
            }
            if (dt.Rows[0]["base_type"].ToString() != "")
            {
                ddl_base_type.SelectedValue = dt.Rows[0]["base_type"].ToString();
            }
            tbName.Text = dt.Rows[0]["base_name"].ToString();
            tbAddress.Text = dt.Rows[0]["base_addr"].ToString();
            tbServicePlace.Text = dt.Rows[0]["BASE_SERVICE_PLACE_DESC"].ToString();
            tbDcodeName.Text = dt.Rows[0]["BASE_DCODE_NAME"].ToString();

            if (dt.Rows[0]["base_Budget_code"].ToString() != "")
            {
                UcSaCode3.SelectedValue = dt.Rows[0]["base_Budget_code"].ToString();
            }

            lbStatus.Text = "update"; //判斷新增或更新
        }
        else
        {
          tbName.Text = tbAddress.Text = INCO_HEALTH_EXT.Text = INCO_RENT_ADDR.Text = INCO_VOUCHERS.Text = INCO_RENT_NO.Text
           = INCO_SUMMONS.Text = UcDate3.Text = TextBox1.Text = TextBox2.Text = TextBox3.Text = "";

            lbStatus.Text = "add";//判斷新增或更新
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e) //自動計算所得稅
    {
            string date = UcDate3.Text;//給付日期
                if(date !="")
                date = (int.Parse(date.Substring(0, 3)) + 1911).ToString() + date.Substring(3, 2);
        SAL3128 SAL3128 = new SAL3128();
        DataTable dt = SAL3128.gettax(UcSaCode2.SelectedValue, Doc_Type.SelectedValue, int.Parse(TextBox1.Text), date);

        TextBox3.Text = dt.Rows[0][0].ToString();

        if (DropDownList2.SelectedValue == "Y")
        {
            DataTable dt_1 = SAL3128.getpara("023", date);
            Double lb1 =  Convert.ToDouble(dt_1.Rows[0][0]);
            int int1 = (int)lb1;

            DataTable dt_2 = SAL3128.getpara("024", date);
            Double lb2 = Convert.ToDouble(dt_2.Rows[0][0]);
            int int2 = (int)lb2;

            DataTable dt_3 = SAL3128.getpara("025", date);
            Double lb3 = Convert.ToDouble(dt_3.Rows[0][0]);
            int int3 = (int)lb3;

            string val = TextBox1.Text;
            if (int.Parse(val) > int3)
            {
                val = int3.ToString();
            }
            else if (int.Parse(val) < int2)
            {
                val = int2.ToString();
            }            
            INCO_HEALTH_EXT.Text = ((int)(int.Parse(TextBox1.Text) * int1 / 100)).ToString(); 
        }

    }

    protected void ddl_base_type_Selected_Changed(object sender, EventArgs e)
    {
        if (this.ddl_base_type.SelectedValue == "1")
        { 
            this.tr_1.Visible = true; 
        }
        else
        {
            this.tbServicePlace.Text = "";
            this.tbDcodeName.Text = "";
            this.tr_1.Visible = false; 
        }
    }

}