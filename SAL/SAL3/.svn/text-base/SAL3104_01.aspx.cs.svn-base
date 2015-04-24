using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SALPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using EMPPLM.Logic;

// 2014/7/19 Eliot Chen
// 新增查詢相關修改

public partial class SAL_SAL3_SAL3104 : BaseWebForm
{
    private string strOrgCode;  // 登入者機關代碼

    protected void Page_Load(object sender, EventArgs e)
    {
        cmbDepartID.SelectedIndexChanged += new UControl_UcDDLDepart.SelectedIndexChangedEventHandler(cmbDepart2_changed);//單位名稱

        // 登入者機關代碼
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

        // User Control Event Binder
        cmb_uc_SalItemType.ReturnEvent = true;
        cmb_uc_SalItemType.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(calItemChanged);
        cmb_uc_EmployeeType.ReturnEvent = true;
        cmb_uc_EmployeeType.CodeChanged += new uc_ucSaCode.CodeChangedEventHandler(EmChanged);

        if (this.Page.IsPostBack) return;

        cmbDepartID.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);

        doPayMethodChanged();

    }

    protected void cmbDepart2_changed(object sender, EventArgs e)
    {
        Name_Bind();
    }
    protected void Name_Bind()
    {
        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
      //  Emp_Member empMember = new Emp_Member();
        //DataTable dt = new FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, cmbDepartID.SelectedValue);

        ddlName.Orgcode = Orgcode;
        ddlName.DepartId = cmbDepartID.SelectedValue;

    }

    protected void EmChanged(object sender, EventArgs e)
    {

    }

    // 項目類別改變
    protected void calItemChanged(object sender, EventArgs e)
    {
        doSalItemChanged();
        // 選擇項目
        uPnlItemNeme.Update();
    }

    private void doSalItemChanged()
    {
        querySalItemName();//查詢項目名稱
    }

    protected void cmbPayMethod_SelectedIndexChanged(object sender, EventArgs e)  //發放方式
    {
        doPayMethodChanged();
   //     querySalItemName();  //查詢項目名稱
    }

    // 項目類別改變
    private void doPayMethodChanged()
    {
        // 重新設定 Code Type
        string strCodeType = cmbPayMethod.SelectedValue;
        cmb_uc_SalItemType.Code_type = strCodeType;
        cmb_uc_SalItemType.Rebind();
        uPnlItemType.Update();
//        querySalItemName();
        querySalItemName();
    }

    // 查詢項目名稱
    private void querySalItemName()
    {
        // new SAL3104
        SAL3104 sal3104 = new SAL3104();
        // 各項參數
        string strisPaywithSalary = cmbPaywithSalary.SelectedValue;       // 是否隨薪
        string strPayMethod = cmbPayMethod.SelectedValue;           // 發放方式
        string strItemType = cmb_uc_SalItemType.SelectedValue;     // 項目類別        

        // 查詢項目名稱
        DataTable dt =
            sal3104.querySalItemName(this.strOrgCode, strisPaywithSalary, strPayMethod, strItemType);

        // Dropdown 項目重置
        cmbSalItemName.Items.Clear();
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem litem = new ListItem();
                litem.Value = dt.Rows[i]["ITEM_CODE"].ToString();
                litem.Text = dt.Rows[i]["ITEM_NAME"].ToString();
                cmbSalItemName.Items.Add(litem);
            }
        }
        uPnlItemNeme.Update();
        //this.Label1.Text = "querySalItemName finished";
    }

    // 是否隨薪改變
    protected void cmbPaywithSalary_SelectedIndexChanged(object sender, EventArgs e)
    {
        querySalItemName();
    }

    // 按下『查詢』
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (cmbSalItemName.SelectedValue == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇項目名稱", "", "");
            this.Page = tempPage;
            return;
        }

        doQueryData();
        pnlDetail.Visible = false;
        gvResult.Visible = true;
        pnlResult.Visible = true;
        uPnlGrids.Update();
        pnlQuery.Visible = true;
        tr_query_result.Visible = true;
        tr_newadd.Visible = false;
    }

    private void doQueryData()
    {  
        SAL3104 sal3104 = new SAL3104();
        // 各項參數
        string strisPaywithSalary = cmbPaywithSalary.SelectedValue;       // 是否隨薪
        string strPayMethod = cmbPayMethod.SelectedValue;           // 發放方式
        string strItemType = cmb_uc_SalItemType.SelectedValue;     // 項目類別    
        string strItemNameCode = cmbSalItemName.SelectedValue;         // 項目名稱
        string strBatchNum = edtBatchNo.Text.ToString().Trim();    // 批號
        string strEmployeeType = cmb_uc_EmployeeType.SelectedValue;    // 員工類別

        string strBaseEDate = DropDownList_base_edate.SelectedValue;    // 在職類型 
        string departid = cmbDepartID.SelectedValue; //單位別
        string idcard = ddlName.SelectedValue;// 員工編號

        if (strEmployeeType == "ALL")
        {
            strEmployeeType = "";
        }

        // 查詢項目名稱
        DataTable dt = new DataTable();
        dt= sal3104.querySalPayItem(this.strOrgCode, strisPaywithSalary,
            strPayMethod, strItemType, strItemNameCode, strBatchNum, strEmployeeType, strBaseEDate, departid, idcard);
             
            // Data Binding
            gvResult.DataSource = dt;
            gvResult.DataBind();
            gvResult.Visible = true;
            pnlResult.Visible = true;

            if (gvResult.Rows.Count > 0)
            {
                btnOK.Visible = true;
                Ucpager2.Visible = true;
            }
            else
            {
                btnOK.Visible = false;
                Ucpager2.Visible = false;
            }   
    }

    // 按下『新增查詢』按鈕
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (cmbSalItemName.SelectedValue == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "請選擇項目名稱", "", "");
            this.Page = tempPage;
            return;
        }

        TxtDetailNew.Text = "NEW";
        doQuery4Edit();
        gvResult.Visible = false;
        pnlResult.Visible = false;

        pnlDetail.Visible = true;
        btnShowDetailFinish.Visible = false;
        btnNewFinish.Visible = true;

        uPnlGrids.Update();
        pnlQuery.Visible = true;
        pnlInput.Visible = false;

        tr_query_result.Visible = false;
        tr_newadd.Visible = true;
    }

    private void doQuery4Edit()
    {
        SAL3104 sal3104 = new SAL3104();
        // 各項參數
        string strisPaywithSalary = cmbPaywithSalary.SelectedValue;       // 是否隨薪
        string strPayMethod = cmbPayMethod.SelectedValue;           // 發放方式
        string strItemType = cmb_uc_SalItemType.SelectedValue;     // 項目類別    
        string strItemNameCode = cmbSalItemName.SelectedValue;         // 項目名稱
        string strBatchNum = edtBatchNo.Text.ToString().Trim();    // 批號
        string strEmployeeType = cmb_uc_EmployeeType.SelectedValue;    // 員工類別

        string strBaseEDate = DropDownList_base_edate.SelectedValue;    // 在職類型 
        string departid = cmbDepartID.SelectedValue; //單位別
        string idcard = ddlName.SelectedValue;// 員工編號

        if (strEmployeeType == "ALL")
        {
            strEmployeeType = "";
        }
        DataTable dt = new DataTable();
           dt = sal3104.querySalItemDetail4Edit(
             strPayMethod, strItemType, strItemNameCode, this.strOrgCode, strEmployeeType, strBaseEDate, departid, idcard);
             
            // Data Binding
            gvDetail.Columns[6].Visible = true;
            gvDetail.Columns[7].Visible = true;
            gvDetail.Columns[8].Visible = true;
            gvDetail.Columns[9].Visible = true;
            gvDetail.Columns[10].Visible = true;
            gvDetail.Columns[11].Visible = true;
            gvDetail.Columns[12].Visible = true;
            gvDetail.Columns[13].Visible = true;
        
            gvDetail.DataSource = dt;
            gvDetail.DataBind();

            gvDetail.Columns[6].Visible = false;
            gvDetail.Columns[7].Visible = false;
            gvDetail.Columns[8].Visible = false;
            gvDetail.Columns[9].Visible = false;
            gvDetail.Columns[10].Visible = false;
            gvDetail.Columns[11].Visible = false;
            gvDetail.Columns[12].Visible = false;
            gvDetail.Columns[13].Visible = false;
        
            for (int i = 0; i < gvDetail.Rows.Count; i++)
            {
                TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
                if (edt != null) edt.Enabled = true;

                uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
                if (ucSaCode != null) ucSaCode.Rebind();
                DropDownList cmb = (DropDownList)ucSaCode.FindControl("DropDownList_code_no");
             
            }
    }
 

    protected void btnReset_Click(object sender, EventArgs e)
    {
  /*      //        Label1.Text = "btnReset_Click";
        //        doQueryData();
        gvResult.Visible = false;
        pnlResult.Visible = false;
        pnlDetail.Visible = false;
        uPnlGrids.Update();
   */
        Response.Redirect("SAL3104_01.aspx");
    }




    private void getDetailData(string strBatchNO)
    {
        string strBaseEDate = DropDownList_base_edate.SelectedValue;    // 在職類型 
        string departid = cmbDepartID.SelectedValue; //單位別
        string idcard = ddlName.SelectedValue;// 員工編號

        SAL3104 sal3104 = new SAL3104();
        DataTable dt = sal3104.querySalPayItemDetail(this.strOrgCode, strBatchNO, strBaseEDate, departid, idcard);

        if (dt != null)
        {           
            // Data Binding
            gvDetail.Columns[6].Visible = true;
            gvDetail.Columns[7].Visible = true;
            gvDetail.Columns[8].Visible = true;
            gvDetail.Columns[9].Visible = true;
            gvDetail.Columns[10].Visible = true;
            gvDetail.Columns[11].Visible = true;
            gvDetail.Columns[12].Visible = true;
            gvDetail.Columns[13].Visible = true;
         

            gvDetail.DataSource = dt;
            gvDetail.DataBind();

            gvDetail.Columns[6].Visible = false;
            gvDetail.Columns[7].Visible = false;
            gvDetail.Columns[8].Visible = false;
            gvDetail.Columns[9].Visible = false;
            gvDetail.Columns[10].Visible = false;
            gvDetail.Columns[11].Visible = false;
            gvDetail.Columns[12].Visible = false;
            gvDetail.Columns[13].Visible = false;
        

            for (int i = 0; i < gvDetail.Rows.Count; i++)
            {
                // TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
                //if (edt != null) edt.Enabled = false;
                uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
                if (ucSaCode != null) ucSaCode.Rebind();
                ucSaCode.SelectedValue = dt.Rows[i]["PAYITEM_Budget_code"].ToString();

                DropDownList cmb = (DropDownList)ucSaCode.FindControl("DropDownList_code_no");
                if (cmb != null) cmb.Enabled = false;
            }
        }
    }

    protected void btnShowDetailFinish_Click(object sender, EventArgs e)
    {
        string[] aryBudgetCode = new string[0];
        string[] aryBatchNo = new string[0];
        // 先產生批號
        for (int i = 0; i < gvDetail.Rows.Count; i++)
        {
            // 預算來源
            uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
            string strBudgetCode = ucSaCode.SelectedValue;
            TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
            string strAmount = "";
            if (edt != null) strAmount = edt.Text.Trim();

            //Label1.Text= "["+Array.Find(aryBudgetCode, element => element.StartsWith(strBudgetCode, StringComparison.Ordinal))+"]";
           // gvDetail.Rows[i].Cells[0].Text = "";

            // 如果不是空
            if (strAmount != "" && strBudgetCode != "")
            {
                /*
                if (Array.IndexOf(aryBudgetCode, strBudgetCode) >= 0)
                //                    "" + Array.Find(aryBudgetCode, element => element.StartsWith(strBudgetCode, StringComparison.Ordinal)) == "")
                {
                    gvDetail.Rows[i].Cells[0].Text = aryBatchNo[Array.IndexOf(aryBudgetCode, strBudgetCode)];
                }
                else
                {
                    // 新增資料
                    Array.Resize(ref aryBudgetCode, aryBudgetCode.Length + 1);
                    Array.Resize(ref aryBatchNo, aryBatchNo.Length + 1);
                    aryBudgetCode[aryBudgetCode.Length - 1] = strBudgetCode;
                    string strFlowIDTemp
                        = Convert.ToString(Convert.ToInt32(DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds));
                    aryBatchNo[aryBatchNo.Length - 1] = strFlowIDTemp;// "Budge " + aryBatchNo.Length.ToString();//取得 BudgetCode,後面要改
                    gvDetail.Rows[i].Cells[0].Text = strFlowIDTemp;// "Budge " + aryBatchNo.Length.ToString();
                }
                 */

                // 參數
                string strPayitemOrgCode = gvDetail.Rows[i].Cells[6].Text.Replace("&nbsp;","");   // '上述SQL查詢之base_orgid內容'
                string strPayitemUserID = gvDetail.Rows[i].Cells[7].Text.Replace("&nbsp;", "");    // '上述SQL查詢之base_seqno內容'

                //string strPayitemFlowID = gvDetail.Rows[i].Cells[0].Text.Replace("&nbsp;", "");      // 系統取號 [後續需修改]
                string strPayitemFlowID = gvDetail.Rows[i].Cells[13].Text.Replace("&nbsp;", "");
                //    Convert.ToString(Convert.ToInt32(DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds)); 

                string strPayitemMargeFlowID = gvDetail.Rows[i].Cells[0].Text.Replace("&nbsp;", "");      // 系統取號 [後續需修改]

                string strPayitemCodeSys = gvDetail.Rows[i].Cells[8].Text.Replace("&nbsp;", "");// 上述SQL查詢之code_sys內容
                string strPayitemCodeKind = gvDetail.Rows[i].Cells[9].Text.Replace("&nbsp;", "");    // 上述SQL查詢之code_kind內容
                string strPayitemCodType = gvDetail.Rows[i].Cells[10].Text.Replace("&nbsp;", "");   // 上述SQL查詢之code_type內容
                string strPayitemCodeNo = gvDetail.Rows[i].Cells[11].Text.Replace("&nbsp;", "");  // 上述SQL查詢之code_no內容
                string strPayitemCode = gvDetail.Rows[i].Cells[12].Text.Replace("&nbsp;", "");  // 上述SQL查詢之code_no內容
                string strPayitemBudgeCode = strBudgetCode;    // 清單選擇之預算來源代碼
                string strPayitemPayAmt = strAmount;        // 清單輸入之金額
                string strPayitemModUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id);
                SAL3104 sal3104 = new SAL3104();
                sal3104.updateSAL_PAYITEMAMT(
                        strPayitemOrgCode
                    , strPayitemUserID
                    , strPayitemFlowID
                    , strPayitemMargeFlowID
                    , strPayitemCodeSys
                    , strPayitemCodeKind
                    , strPayitemCodType, strPayitemCodeNo, strPayitemCode, strPayitemBudgeCode, strPayitemPayAmt
                    , strPayitemModUserID);


            }
        }

        pnlDetail.Visible = false;
        gvResult.Visible = true;
        pnlResult.Visible = true;
        pnlInput.Visible = true;
//        uPnlGrids.Update();
        doQueryData();
    }

    protected void btnNewFinish_Click(object sender, EventArgs e)
    {
        doNew();

        pnlInput.Visible = true;
        tr_newadd.Visible = false;
        tr_query_result.Visible = false;

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "完成", "", "");
        this.Page = tempPage;

    }

    private void doNew()
    {
        string[] aryBudgetCode = new string[0];
        string[] aryBatchNo = new string[0];
        // 先產生批號
        for (int i = 0; i < gvDetail.Rows.Count; i++)
        {
            // 預算來源
            uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
            string strBudgetCode = ucSaCode.SelectedValue;
            TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
            string strAmount = "";
            if (edt != null) strAmount = edt.Text.Trim();

            //Label1.Text= "["+Array.Find(aryBudgetCode, element => element.StartsWith(strBudgetCode, StringComparison.Ordinal))+"]";
            gvDetail.Rows[i].Cells[0].Text = "";

            // 如果不是空
            if (strAmount != "" && strBudgetCode != "")
            {
                if (Array.IndexOf(aryBudgetCode, strBudgetCode) >= 0)
                //                    "" + Array.Find(aryBudgetCode, element => element.StartsWith(strBudgetCode, StringComparison.Ordinal)) == "")
                {
                    gvDetail.Rows[i].Cells[0].Text = aryBatchNo[Array.IndexOf(aryBudgetCode, strBudgetCode)];
                }
                else
                {
                    // 新增資料
                    Array.Resize(ref aryBudgetCode, aryBudgetCode.Length + 1);
                    Array.Resize(ref aryBatchNo, aryBatchNo.Length + 1);
                    aryBudgetCode[aryBudgetCode.Length - 1] = strBudgetCode;
                    //string strFlowIDTemp
                    //    = Convert.ToString(Convert.ToInt32(DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds));

                    SYS.Logic.FlowId fflow=new SYS.Logic.FlowId();
                    String strFlowIDTemp=
                        fflow.GetFlowId(this.strOrgCode,"00A001");
//                    Dim aaa = New SYS.Logic.FlowId
//                   Dim bbb As String = aaa.GetFlowId(機關代碼, "00A001")


//                    aryBatchNo[aryBatchNo.Length - 1] = "Budge " + aryBatchNo.Length.ToString();//取得 BudgetCode,後面要改
//                    gvDetail.Rows[i].Cells[0].Text = "Budge " + aryBatchNo.Length.ToString();
                    aryBatchNo[aryBatchNo.Length - 1] = strFlowIDTemp;//取得 BudgetCode,後面要改
                    gvDetail.Rows[i].Cells[0].Text = strFlowIDTemp;
                }

                // 參數
                string strPayitemOrgCode = gvDetail.Rows[i].Cells[6].Text.Replace("&nbsp;","");   // '上述SQL查詢之base_orgid內容'
                string strPayitemUserID = gvDetail.Rows[i].Cells[7].Text.Replace("&nbsp;", "");    // '上述SQL查詢之base_seqno內容'
                string strPayitemFlowID = gvDetail.Rows[i].Cells[0].Text;
                string strPayitemMargeFlowID = gvDetail.Rows[i].Cells[0].Text.Replace("&nbsp;", "");      // 系統取號 [後續需修改]
                string strPayitemCodeSys = gvDetail.Rows[i].Cells[8].Text.Replace("&nbsp;", "");// 上述SQL查詢之code_sys內容
                string strPayitemCodeKind = gvDetail.Rows[i].Cells[9].Text.Replace("&nbsp;", "");    // 上述SQL查詢之code_kind內容
                string strPayitemCodType = gvDetail.Rows[i].Cells[10].Text.Replace("&nbsp;", "");   // 上述SQL查詢之code_type內容
                string strPayitemCodeNo = gvDetail.Rows[i].Cells[11].Text.Replace("&nbsp;", "");  // 上述SQL查詢之code_no內容
                string strPayitemCode = gvDetail.Rows[i].Cells[12].Text.Replace("&nbsp;", "");  // 上述SQL查詢之code_no內容
                string strPayitemBudgeCode = strBudgetCode;    // 清單選擇之預算來源代碼
                string strPayitemPayAmt = strAmount;        // 清單輸入之金額
                string strPayitemModUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id);
                SAL3104 sal3104 = new SAL3104();
                sal3104.insertSAL_PAYITEM(
                        strPayitemOrgCode
                    , strPayitemUserID
                    , strPayitemFlowID
                    , strPayitemMargeFlowID
                    , strPayitemCodeSys
                    , strPayitemCodeKind
                    , strPayitemCodType, strPayitemCodeNo, strPayitemCode, strPayitemBudgeCode, strPayitemPayAmt
                    , strPayitemModUserID);


            }
        }

        doQueryData();
        pnlDetail.Visible = false;
        gvResult.Visible = true;
        pnlResult.Visible = true;
        uPnlGrids.Update();

        // 取批號
        // 判斷是否為0
        //gvResult.Visible = true;
        //pnlDetail.Visible = false;
        // 新增資料
        // 取號
        /*
        for (int i = 0; i < gvDetail.Rows.Count; i++)
        {
            // 預算來源
            uc_ucSaCode ucSaCode = (uc_ucSaCode)gvDetail.Rows[i].FindControl("cmb_uc_BudgeSource");
            string strBudgetCode = ucSaCode.SelectedValue;
            TextBox edt = (TextBox)gvDetail.Rows[i].FindControl("edtAmount");
            string strAmount = "";
            if (edt != null) strAmount = edt.Text.Trim();

            //Label1.Text= "["+Array.Find(aryBudgetCode, element => element.StartsWith(strBudgetCode, StringComparison.Ordinal))+"]";
            gvDetail.Rows[i].Cells[0].Text = "";
            if (edt != null) strAmount = edt.Text.Trim();
            // 如果不是空
            if (strAmount != "" && strBudgetCode != "")
            {
                // 參數
                string strPayitemOrgCode    = gvDetail.Rows[i].Cells[6].Text;   // '上述SQL查詢之base_orgid內容'
                string strPayitemUserID     = gvDetail.Rows[i].Cells[7].Text;    // '上述SQL查詢之base_seqno內容'

                string strPayitemFlowID = gvDetail.Rows[i].Cells[0].Text;      // 系統取號 [後續需修改]
                string strPayitemMargeFlowID = gvDetail.Rows[i].Cells[0].Text;      // 系統取號 [後續需修改]

                string strPayitemCodeSys = gvDetail.Rows[i].Cells[8].Text;// 上述SQL查詢之code_sys內容
                string strPayitemCodeKind=gvDetail.Rows[i].Cells[9].Text;    // 上述SQL查詢之code_kind內容
                string strPayitemCodType = gvDetail.Rows[i].Cells[10].Text;   // 上述SQL查詢之code_type內容
                string strPayitemCodeNo = gvDetail.Rows[i].Cells[11].Text;  // 上述SQL查詢之code_no內容
                string strPayitemCode = gvDetail.Rows[i].Cells[12].Text;  // 上述SQL查詢之code_no內容
                string strPayitemBudgeCode = strBudgetCode;    // 清單選擇之預算來源代碼
                string strPayitemPayAmt = strAmount;        // 清單輸入之金額
                string strPayitemModUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id);
                SAL3104 sal3104 = new SAL3104();
                sal3104.insertSAL_PAYITEM(
                        strPayitemOrgCode
                    , strPayitemUserID
                    , strPayitemFlowID
                    , strPayitemMargeFlowID
                    , strPayitemCodeSys
                    , strPayitemCodeKind
                    , strPayitemCodType, strPayitemCodeNo, strPayitemCode, strPayitemBudgeCode, strPayitemPayAmt
                    , strPayitemModUserID); 

            }
        }
        /*
         */



    }


    private string getSerNO()
    {
        return "";
    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {



    }
    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // 顯示明細
        if (e.CommandName == "ShowDetail")
        {
            TxtDetailNew.Text = "DETAIL";
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvResult.Rows[index];
            //            Label1.Text = row.Cells[0].Text.ToString();
            Detilindex.Text = row.Cells[0].Text.ToString();
            getDetailData(row.Cells[0].Text.ToString());
            gvResult.Visible = false;
            pnlResult.Visible = false;
            pnlDetail.Visible = true;
            btnShowDetailFinish.Visible = true;
            btnNewFinish.Visible = false;
            pnlInput.Visible = false;

        }
    }

    protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Response.Write("gvDetail_PageIndexChanging");

   /*     gvDetail.Columns[6].Visible = true;
        gvDetail.Columns[7].Visible = true;
        gvDetail.Columns[8].Visible = true;
        gvDetail.Columns[9].Visible = true;
        gvDetail.Columns[10].Visible = true;
        gvDetail.Columns[11].Visible = true;
        gvDetail.Columns[12].Visible = true;
        gvDetail.Columns[13].Visible = true;
        */
        gvDetail.PageIndex = e.NewPageIndex;
        if (TxtDetailNew.Text == "NEW")
        {
            doQuery4Edit();
            gvResult.Visible = false;
            pnlResult.Visible = false;

            pnlDetail.Visible = true;
            btnShowDetailFinish.Visible = false;
            btnNewFinish.Visible = true;

            uPnlGrids.Update();
            pnlQuery.Visible = true;
            pnlInput.Visible = false;

            tr_query_result.Visible = false;
            tr_newadd.Visible = true;           
        }
        else
        {
            getDetailData(Detilindex.Text);
        }

    }
    protected void gvDetail_PageIndexChanged(object sender, EventArgs e)
    {
        //Response.Write("gvDetail_PageIndexChanged");

   /*     gvDetail.Columns[6].Visible = false;
        gvDetail.Columns[7].Visible = false;
        gvDetail.Columns[8].Visible = false;
        gvDetail.Columns[9].Visible = false;
        gvDetail.Columns[10].Visible = false;
        gvDetail.Columns[11].Visible = false;
        gvDetail.Columns[12].Visible = false;
        gvDetail.Columns[13].Visible = false;
    * */
    }
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ///Response.Write("gvDetail_RowDataBound");
        uc_ucSaCode ucSaCode = (uc_ucSaCode)e.Row.FindControl("cmb_uc_BudgeSource");
        if (ucSaCode != null)
        {
            ucSaCode.Rebind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlInput.Visible = true;
        pnlQuery.Visible = false;
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResult.PageIndex = e.NewPageIndex;
        doQueryData();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        doQueryData();
        pnlInput.Visible = true;
        tr_newadd.Visible = false;
        tr_query_result.Visible = false;
        pnlDetail.Visible = false;

/*
        doQueryData();
        pnlDetail.Visible = false;
        gvResult.Visible = fasle;
        pnlResult.Visible = fasle;
        uPnlGrids.Update();
        pnlQuery.Visible = fasle;
        tr_query_result.Visible = true;
        tr_newadd.Visible = false;
        pnlInput.Visible = true;
 */ 
    }
}