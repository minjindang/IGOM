using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAL.Logic;
using System.Data;
using FSCPLM.Logic;

public partial class SAL_SAL1_SAL1104_01 : BaseWebForm
{
    string orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    SAL1104 dao = new SAL1104();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ddlItem_code.DataSource = dao.GetItemCode();
            this.ddlItem_code.DataTextField = "CODE_DESC1";
            this.ddlItem_code.DataValueField = "code_no";
            this.ddlItem_code.DataBind();

            this.ddlPrintType.SelectedValue = "1";//預設為合併列印

            this.ddlBASE_BANK_CODE.DataSource = dao.GetBankCode();
            this.ddlBASE_BANK_CODE.DataTextField = "CODE_DESC1";
            this.ddlBASE_BANK_CODE.DataValueField = "CODE_NO";
           
            this.ddlBASE_BANK_CODE.DataBind();
            this.ddlBASE_BANK_CODE.Items.Insert(0, "請選擇");

            Bind();
            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                //ShowReSendData();
                this.btn_submit.Text = "確認";
            } 
            //else
            //    SetInitialRow(); 
        }
    }

    /// <summary>
    /// 【機關審查是否匯款】元件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPay_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPay_type.SelectedValue == "0")
        {
            this.ddlBASE_BANK_CODE.Enabled = false ;
            this.txtBASE_BANK_NO.Enabled = false;
            ddlBASE_BANK_CODE.SelectedIndex = 0;
            txtBASE_BANK_NO.Text = "";
        }  
        else    
        {
            this.ddlBASE_BANK_CODE.Enabled = true;
            this.txtBASE_BANK_NO.Enabled = true;
        }
    }

    protected void txtBASE_IDNO_TextChanged(object sender, EventArgs e)
    {
        DataRow dr= dao.ssbDAO.GetIDNO(txtBASE_IDNO.Text);
        if (dr != null)
        {
            txtBASE_NAME.Text = dr["BASE_NAME"].ToString();
            txtBASE_SERVICE_PLACE_DESC.Text = dr["BASE_SERVICE_PLACE_DESC"].ToString();
            this.txtBASE_DCODE_NAME.Text = dr["BASE_DCODE_NAME"].ToString();
            this.ucMeeting_pos.Code_no = dr["BASE_JOB"].ToString();
            DataTable dtBank = dao.ssbkDAO.GetAll(dr["BASE_SEQNO"].ToString());
            if (dtBank != null && dtBank.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtBank.Rows[0]["BANK_CODE"].ToString()))
                {
                   
                   var bcList =
                    from li in ddlBASE_BANK_CODE.Items.Cast<ListItem>()
                    where li.Value == dtBank.Rows[0]["BANK_CODE"].ToString()
                    select li;
                   if (bcList.Any())
                   {
                       this.ddlBASE_BANK_CODE.SelectedValue = dtBank.Rows[0]["BANK_CODE"].ToString();
                   }
                    
                }
                
                this.txtBASE_BANK_NO.Text = dtBank.Rows[0]["BANK_BANK_NO"].ToString();
            }
            hfExists.Value = "true";
        }
        else
        {
            hfExists.Value = "false";
            txtBASE_NAME.Text = "";
            txtBASE_SERVICE_PLACE_DESC.Text ="";
            this.txtBASE_DCODE_NAME.Text = "";
        }

    }

    /// <summary>
    /// 【維護】按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMain_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((Button)sender).NamingContainer;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        hfModifyIndex.Value = gr.RowIndex.ToString();
        DataRow dr = dtCurrentTable.Rows[gr.RowIndex];
        txtBASE_NAME.Text = CommonFun.SetDataRow(ref dr, "BASE_NAME").ToString();
        txtBASE_SERVICE_PLACE_DESC.Text = CommonFun.SetDataRow(ref dr, "BASE_SERVICE_PLACE_DESC").ToString();
        txtBASE_DCODE_NAME.Text = CommonFun.SetDataRow(ref dr, "BASE_DCODE_NAME").ToString();
        txtBASE_IDNO.Text = CommonFun.SetDataRow(ref dr, "BASE_IDNO").ToString();
        ucMeeting_pos.Code_no = CommonFun.SetDataRow(ref dr, "Meeting_pos").ToString();
        ucMeeting_date.Text = CommonFun.SetDataRow(ref dr, "Meeting_date").ToString();
        txtBASE_DCODE_NAME.Text = CommonFun.SetDataRow(ref dr, "BASE_DCODE_NAME").ToString();
        if (!string.IsNullOrEmpty(CommonFun.SetDataRow(ref dr, "BASE_BANK_CODE").ToString()))
            ddlBASE_BANK_CODE.SelectedValue = CommonFun.SetDataRow(ref dr, "BASE_BANK_CODE").ToString();
        txtBASE_BANK_NO.Text = CommonFun.SetDataRow(ref dr, "BASE_BANK_NO").ToString();
        txtBASE_ADDR.Text = CommonFun.SetDataRow(ref dr, "BASE_ADDR").ToString();
        ucBudget_code.Code_no = CommonFun.SetDataRow(ref dr, "Budget_code").ToString();
        ddlItem_code.SelectedValue = CommonFun.SetDataRow(ref dr, "Item_code").ToString();
        txtApply_amt.Text = CommonFun.SetDataRow(ref dr, "Apply_amt").ToString();
        txtMeeting_content.Text = CommonFun.SetDataRow(ref dr, "Meeting_content").ToString();
        hfExists.Value = CommonFun.SetDataRow(ref dr, "exists").ToString();
        //ddlPay_type.SelectedValue = CommonFun.SetDataRow(ref dr, "index").ToString();
        if(txtBASE_BANK_NO.Text=="")
        {
            ddlPay_type.SelectedValue = "0";
            this.ddlBASE_BANK_CODE.SelectedIndex = 0;
            txtBASE_BANK_NO.Text = "";
            ddlBASE_BANK_CODE.Enabled = false;
            txtBASE_BANK_NO.Enabled = false;
        }
        else
            ddlPay_type.SelectedValue = "1";
        btn_new.Text = "更新";
        btn_new.Enabled = true;

        //7/26 一般會先列印才送出申請
        this.btn_print.Enabled = true;//列印資料
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((Button)sender).NamingContainer;
        String id = ((HiddenField)gr.FindControl("hfId")).Value;
        dao.Delete(id);
        Bind();
    }

    /// <summary>
    /// 【新增】按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_new_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        if (string.IsNullOrEmpty(this.txtBASE_IDNO.Text))
        {
            msg += @"請輸入身分證號/護照\n";
        }
        if (string.IsNullOrEmpty(this.txtBASE_NAME.Text))
        {
            msg += @"請輸入姓名\n";
        }
        if (string.IsNullOrEmpty(this.ucMeeting_date.Text))
        {
            msg += @"請輸入會議日期\n";
        }
        if (string.IsNullOrEmpty(this.txtApply_amt.Text))
        {
            msg += @"請輸入金額\n";
        }
        if (ddlPay_type.SelectedValue == "1")
        {
            if (string.IsNullOrEmpty(this.ddlBASE_BANK_CODE.Text) || string.IsNullOrEmpty(this.txtBASE_BANK_NO.Text))
            {
                msg += @"請輸入帳號\n";
            }
        }
        else
        {
            int iAmt = 0;
            try
            {
                iAmt = int.Parse(this.txtApply_amt.Text);
            }
            catch
            {
                msg += @"金額，請輸入數值\n";
            }
        }

        if (string.IsNullOrEmpty(this.txtMeeting_content.Text))
        {
            msg += @"請輸入會議說明\n";
        }

        bool isUpdate = false;
        if (Request.QueryString["org"] != null && Request.QueryString["fid"] != null)
            isUpdate = true;

        //若hfModifyIndex為空則視為新增
        if (string.IsNullOrEmpty(hfModifyIndex.Value)) {
            isUpdate = false;
        }

        // 以申請欄位之「身份證字號」、「會議日期」、「會議說明」比對主檔資料及流程狀態，若有存在則不可以再新增
        SAL_EXAMINE_fee bll = new SAL_EXAMINE_fee();
        
        DataTable dtData = bll.GetAll(this.txtBASE_IDNO.Text, this.ucMeeting_date.Text, this.txtMeeting_content.Text);
        if (!isUpdate && dtData != null && dtData.Rows.Count > 0)
        {
            msg += "已有相同之身份證字號、會議日期、會議說明，不可再新增 \\n";
        }

        if (string.IsNullOrEmpty(msg))
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            if (string.IsNullOrEmpty(hfModifyIndex.Value))
            {
                AddNewRowToGrid();
            }
            else
            {
                DataRow dr = dtCurrentTable.Rows[Convert.ToInt16(hfModifyIndex.Value)];
                dr["BASE_NAME"] = txtBASE_NAME.Text;
                dr["BASE_SERVICE_PLACE_DESC"] = txtBASE_SERVICE_PLACE_DESC.Text;
                dr["BASE_DCODE_NAME"] = txtBASE_DCODE_NAME.Text;
                dr["BASE_IDNO"] = txtBASE_IDNO.Text;
                dr["Meeting_pos"] = ucMeeting_pos.Code_no;
                dr["Meeting_pos_name"] = dao.saDAO.GetCodeDesc("002", "001", ucMeeting_pos.Code_no);
                dr["Meeting_date"] = ucMeeting_date.Text;
                dr["Meeting_content"] = txtMeeting_content.Text;
                dr["Apply_date"] = CommonFun.getYYYMMDD();
                dr["BASE_BANK_CODE"] = "請選擇" == ddlBASE_BANK_CODE.SelectedValue ? "" : ddlBASE_BANK_CODE.SelectedValue;
                dr["BASE_BANK_NO"] = txtBASE_BANK_NO.Text;
                dr["BASE_ADDR"] = txtBASE_ADDR.Text;
                dr["Pay_type"] = ddlPay_type.SelectedValue;
                dr["Apply_amt"] = Convert.ToInt32(this.txtApply_amt.Text);
                dr["Budget_code"] = ucBudget_code.Code_no;
                dr["Budget_name"] = dao.saDAO.GetCodeDesc("006", "018", ucBudget_code.Code_no);
                dr["Item_code"] = ddlItem_code.SelectedValue;
                dr["Item_name"] = dao.saDAO.GetCodeDesc("005", "001", ddlItem_code.SelectedValue);
                dr["exists"] = Convert.ToBoolean(hfExists.Value);
                dr["Meeting_content"] = txtMeeting_content.Text;

                ViewState["CurrentTable"] = dtCurrentTable;
                this.GridViewA.DataSource = dtCurrentTable;
                this.GridViewA.DataBind();
                hfModifyIndex.Value = "";
                this.btn_new.Text = "新增";

                if (isUpdate)
                    this.btn_new.Enabled = false;
            }

            String fid = Request.QueryString["fid"];
            if (!string.IsNullOrEmpty(fid))
            {
                this.hfFlow_id.Value = Request.QueryString["fid"];
                dao.Apply(dtCurrentTable, hfFlow_id.Value,false);
            }
            else
            {
                this.hfFlow_id.Value = dao.Apply(dtCurrentTable, "", false);
                hfModifyIndex.Value = "";
                this.btn_new.Text = "新增";
            }
            Bind();
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            return;
        }
        txtBASE_NAME.Text = "";
        txtBASE_SERVICE_PLACE_DESC.Text = "";
        txtBASE_DCODE_NAME.Text = "";
        txtBASE_IDNO.Text = "";
        //ucMeeting_pos.Code_no = "";
        //ucMeeting_date.Text = "";
        txtBASE_DCODE_NAME.Text = "";
        //ddlBASE_BANK_CODE.SelectedValue = "";
        txtBASE_BANK_NO.Text = "";
        txtBASE_ADDR.Text = "";
       // ucBudget_code.Code_no = "";
       // ddlItem_code.SelectedValue = "";
        txtApply_amt.Text = "";
        //txtMeeting_content.Text = "";
        //hfExists.Value = "";

        //7/26 一般會先列印才送出申請
        this.btn_print.Enabled = true;//列印資料
    }

    protected void Bind()
    {
        String fid = Request.QueryString["fid"];
        String org = Request.QueryString["org"];

        if (!String.IsNullOrEmpty(fid) && !String.IsNullOrEmpty(org))
            ShowReSendData();
        else
        {
            DataTable dt = dao.getDataByOrgUserId(LoginManager.OrgCode, LoginManager.UserId);
            GridViewA.DataSource = dt;
            GridViewA.DataBind();
            ViewState["CurrentTable"] = dt;
        }
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Id"));
        dt.Columns.Add(new DataColumn("BASE_NAME"));
        dt.Columns.Add(new DataColumn("BASE_SERVICE_PLACE_DESC"));
        dt.Columns.Add(new DataColumn("BASE_DCODE_NAME"));
        dt.Columns.Add(new DataColumn("BASE_IDNO"));
        dt.Columns.Add(new DataColumn("Meeting_pos"));
        dt.Columns.Add(new DataColumn("Meeting_pos_name"));
        dt.Columns.Add(new DataColumn("Meeting_date"));
        dt.Columns.Add(new DataColumn("Meeting_content"));
        dt.Columns.Add(new DataColumn("Apply_date"));
        dt.Columns.Add(new DataColumn("BASE_BANK_CODE"));
        dt.Columns.Add(new DataColumn("BASE_BANK_NO"));
        dt.Columns.Add(new DataColumn("BASE_ADDR"));
        dt.Columns.Add(new DataColumn("Pay_type"));
        dt.Columns.Add(new DataColumn("Apply_amt", typeof(System.Int32)));
        dt.Columns.Add(new DataColumn("Budget_code"));
        dt.Columns.Add(new DataColumn("Budget_name"));
        dt.Columns.Add(new DataColumn("Item_code"));
        dt.Columns.Add(new DataColumn("Item_name"));
        dt.Columns.Add(new DataColumn("exists",typeof(System.Boolean)));
        dt.Columns.Add(new DataColumn("Index", typeof(System.Int16)));
        ViewState["CurrentTable"] = dt;

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();

        ucMeeting_pos.SelectedValue = "010";
    }

    private void ShowReSendData()
    {
        DataTable dt = new SAL1104().getDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);

        if (dt != null && dt.Rows.Count > 0)
        {
            hfFlow_id.Value = dt.Rows[0]["flow_id"].ToString();

            ViewState["CurrentTable"] = dt;

            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();

            btn_new.Enabled = true;
            btn_back.Visible = true;
        }
    }

    private void AddNewRowToGrid()
    {
        if ((ViewState["CurrentTable"] != null))
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            bool doubleData = false;
            foreach (DataRow cdr in dtCurrentTable.Rows)
            {
                if (cdr["BASE_IDNO"].ToString().Equals(txtBASE_IDNO.Text)
                    && cdr["Meeting_date"].ToString().Equals(ucMeeting_date.Text)
                    && cdr["Meeting_content"].ToString().Equals(txtMeeting_content.Text))
                    doubleData = true;                
            }
            if (doubleData)
            {
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "已有相同之身份證字號、會議日期、會議說明，不可再新增!", "", "");
                return;
            }

            DataRow dr = dtCurrentTable.NewRow(); 
            dr["BASE_NAME"] = txtBASE_NAME.Text;
            dr["BASE_SERVICE_PLACE_DESC"] = txtBASE_SERVICE_PLACE_DESC.Text;
            dr["BASE_DCODE_NAME"] = txtBASE_DCODE_NAME.Text; 
            dr["BASE_IDNO"] = txtBASE_IDNO.Text;
            dr["Meeting_pos"] = ucMeeting_pos.Code_no;
            dr["Meeting_pos_name"] = dao.saDAO.GetCodeDesc("002", "001", ucMeeting_pos.Code_no);
            dr["Meeting_date"] = ucMeeting_date.Text;
            dr["Meeting_content"] = txtMeeting_content.Text;
            dr["Apply_date"] = CommonFun.getYYYMMDD();
            dr["BASE_BANK_CODE"] = "請選擇" == ddlBASE_BANK_CODE.SelectedValue ? "" : ddlBASE_BANK_CODE.SelectedValue;
            dr["BASE_BANK_NO"] = txtBASE_BANK_NO.Text;
            dr["BASE_ADDR"] = txtBASE_ADDR.Text;
            dr["Pay_type"] = ddlPay_type.SelectedValue;
            dr["Apply_amt"] = Convert.ToInt32(this.txtApply_amt.Text);
            dr["Budget_code"] = ucBudget_code.Code_no;
            dr["Budget_name"] =  dao.saDAO.GetCodeDesc("006", "018", ucBudget_code.Code_no);
            dr["Item_code"] = ddlItem_code.SelectedValue;
            dr["Item_name"] =  dao.saDAO.GetCodeDesc("005", "001", ddlItem_code.SelectedValue);
            dr["exists"] = Convert.ToBoolean(hfExists.Value);
            dr["Index"] = dtCurrentTable.Rows.Count + 1;

            dtCurrentTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtCurrentTable;
            this.GridViewA.DataSource = dtCurrentTable;
            this.GridViewA.DataBind();
        }
    }

   /// <summary>
    /// 【送出申請】按鈕
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //if (dtCurrentTable == null || dtCurrentTable.Rows.Count <= 0)
        //{
        //    msg += "至少輸入一筆申請\\n";
        //}

        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("Apply_amt", typeof(Int32));
        foreach (GridViewRow gvr in GridViewA.Rows)
        {
            CheckBox cbx = (CheckBox)gvr.FindControl("cbx");
            if (cbx.Checked)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = ((HiddenField)gvr.FindControl("hfId")).Value;
                dr["Apply_amt"] = CommonFun.ConvertToInt(((HiddenField)gvr.FindControl("hfApply_amt")).Value);
                dt.Rows.Add(dr);
            }
        }
        if (dt == null || dt.Rows.Count <= 0)
        {
            msg += "至少勾選一筆申請\\n";
        }


        // 以申請欄位之「身份證字號」、「會議日期」、「會議說明」比對主檔資料及流程狀態，若有存在則不可以再新增
        SAL_EXAMINE_fee bll = new SAL_EXAMINE_fee();

        //DataTable dtData = bll.GetAll(this.txtBASE_IDNO.Text, this.ucMeeting_date.Text, this.txtMeeting_content.Text);
        //if(dtData != null && dtData.Rows.Count > 0)
        //{
        //    msg += "已有相同之身份證字號、會議日期、會議說明，不可再新增 \\n";
        //}

        bool isUpdate = false;
        if (Request.QueryString["org"] != null && Request.QueryString["fid"] != null)
            isUpdate = true;

        if (!isUpdate)
        {
            foreach (DataRow cdr in dtCurrentTable.Rows)
            {
                DataTable dtData = bll.GetAll(cdr["BASE_IDNO"].ToString(), cdr["Meeting_date"].ToString(), cdr["Meeting_content"].ToString());
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    msg += "已有相同之身份證字號、會議日期、會議說明，不可再新增 \\n";
                    break;
                }
            }   
        }     

        Page p = this.Page;
        if (string.IsNullOrEmpty(msg))
        {
            try
            {
                   //if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                   //{
                   //    this.hfFlow_id.Value = Request.QueryString["fid"];
                   //    dao.Apply(dtCurrentTable, hfFlow_id.Value);
                   //    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
                   //}
                   //else
                   //{
                   //    this.hfFlow_id.Value = dao.Apply(dtCurrentTable, "");
                   //    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請已送出", "", "");
                   //}
                   //this.btn_print.Enabled = true;//送出申請後才能列印資料

                   //if(!isUpdate)
                   //     this.btn_new.Enabled = true;

                   //foreach (GridViewRow gr in GridViewA.Rows)
                   //{
                   //    Button btnMain = (Button)gr.FindControl("btnMain");
                   //    Button btnDelete = (Button)gr.FindControl("btnDelete");
                   //    btnMain.Enabled = true;
                   //    btnDelete.Enabled = true;
                   //}

                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    this.hfFlow_id.Value = Request.QueryString["fid"];
                    dao.Apply(dtCurrentTable, hfFlow_id.Value,true);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "", "");
                }
                else
                {
                    this.hfFlow_id.Value = dao.Apply(dtCurrentTable, "",true);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請已送出", "", "");
                }
                Bind();
            }
            catch (Exception ex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            }
        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
 
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        //Session.Remove("dt");
        string url = "SAL1104_02a.aspx";
        SAL_EXAMINE_fee bll = new SAL_EXAMINE_fee();
        int count;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        count = dtCurrentTable.Rows.Count;
             
        //DataTable dtID = bll.GetID(count);
        DataTable dttmp,dt = new DataTable();
        for (int i = 0; i < count; i++)
        {
            dttmp = bll.GetIDData(Convert.ToInt32(dtCurrentTable.Rows[i]["Id"]));
            dt.Merge(dttmp);
        }

        Session["dt"] = dt;
        //if (this.GridViewA.Rows.Count > 0)
        //{
            url += "?Type=1&printType=" + ddlPrintType.SelectedValue;
        //}
        //else
        //{
        //    //印空表
        //    url += "?Type=0";
        //}

        Response.Redirect(url);
    }
    protected void btn_print_empty_Click(object sender, EventArgs e)//列印空白清冊
    {
        string url = "SAL1104_02a.aspx";
            //印空表
            url += "?Type=0";
         Response.Redirect(url);
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        if(ViewState["BackUrl"]!=null)
            Response.Redirect(ViewState["BackUrl"].ToString());
    }
}