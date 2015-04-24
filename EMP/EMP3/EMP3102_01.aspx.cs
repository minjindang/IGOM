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

public partial class EMP_EMP3_EMP3102_01 : System.Web.UI.Page
{

    // 登入者機關代碼
    string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
    string strLoginUserID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
    string sttest = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);
    string strMode;// 用來判斷模式

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        get1stDept();
        strMode = "";
        this.pnlModify.Visible = false;
        this.pnlresult.Visible = false;

        bindOrg();
    }


    private void bindOrg()
    {
        cmg_uc_org1.Orgcode = cmb1stDept.SelectedValue;
    }


    // 取得機關下拉資料
    private void get1stDept()
    {
        EMP3101 emp3101 = new EMP3101();

        DataTable dt = emp3101.get1stDeptList();
        cmb1stDept.DataSource = dt;
        cmb1stDept.DataTextField = "ORGCODE_NAME";
        cmb1stDept.DataValueField = "ORGCODE";
        cmb1stDept.DataBind();
        
        cmb1stDept4Edit.DataSource = dt;
        cmb1stDept4Edit.DataTextField = "ORGCODE_NAME";
        cmb1stDept4Edit.DataValueField = "ORGCODE";
        cmb1stDept4Edit.DataBind();
        

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        getAllSystems();

        pnlModify.Visible = true;
        pnlresult.Visible = false;
        lblMode.Text = "新增";

        pnlConditions.Visible = false;

        btnAddOK.Visible = true;
        btnEditOK.Visible = false;

        showhideModifyControls(true);

        lstSelect.Items.Clear();
        cmb1stDept4Edit.SelectedIndex = 0;
        cmb_uc_idtype4Edit.Rebind();

        cmb_uc_Org4Edit.Orgcode = cmb1stDept.SelectedValue;
//        cmb_uc_idtype4Edit.SelectedValue = cmb_uc_idtype.SelectedValue;

    }

    private void getAllSystems()
    {
        // 取得相關項目
        EMP3101 emp3101 = new EMP3101();
        // 參數
        string str1stOrgCode =
            cmb1stDept.SelectedValue;
        string strisActive = "'Y'";
        DataTable dt = emp3101.queryEMPApplicaSysProf(str1stOrgCode, "", strisActive);
        lstUnSelect.DataSource = dt;
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataBind();

    }

    protected void btnSelectFun_Click(object sender, EventArgs e)
    {
        for (int i = lstUnSelect.Items.Count - 1; i >= 0; i--)
        {
            if (lstUnSelect.Items[i].Selected)
            {
                ListItem item = lstUnSelect.Items[i];
                lstSelect.Items.Add(item);
                lstUnSelect.Items.Remove(item);
            }
        }
    }
    protected void btnRemoveFun_Click(object sender, EventArgs e)
    {
        for (int i = lstSelect.Items.Count - 1; i >= 0; i--)
        {
            if (lstSelect.Items[i].Selected)
            {
                ListItem item = lstSelect.Items[i];
                lstUnSelect.Items.Add(item);
                lstSelect.Items.Remove(item);
            }
        }

    }
    protected void add_submit_Click(object sender, EventArgs e)
    {
        // 檢查
        string strMsg="";
        // 1. 是否有選單位
        if (cmb_uc_Org4Edit.SelectedValue == "")
        {
            strMsg+="請選擇單位";
        }
        if (lstSelect.Items.Count==0)
        {
            if (strMsg!="") strMsg+=", ";
            strMsg+="請選擇應用系統";
        }

        if (strMsg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, strMsg, "", "");
            this.Page = tempPage;
            return;
        }


        EMP3102 emp3102 = new EMP3102();
        // 參數
        string strDepartID = cmb_uc_Org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        DataTable dt= emp3102.queryEMPIshareSysProfFull(this.strOrgCode,strDepartID,strShareID);
        if (dt.Rows.Count>0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "已存在資料，請使用維護功能", "", "");
            this.Page = tempPage;
            return;
        }

        doInsert();

        pnlModify.Visible = false;
        pnlConditions.Visible = true;

        Page tempPage2 = this.Page;
        CommonFun.MsgShow(ref tempPage2,
           CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = tempPage2;


    }

    private void doDelete()
    {
        // 
        EMP3102 emp3102 = new EMP3102();
        // 參數
        string strDepartID = cmb_uc_Org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        emp3102.deleteEMPIshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID
            );

        pnlConditions.Visible = true;
        this.Ucpager1.PNow = 1;
        this.doQueryData();
        /*
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "新增完成", "", "");
        this.Page = tempPage;
        */
        
    }

    private void doInsert()
    {
        // 
        EMP3102 emp3102 = new EMP3102();
        // 參數
        string strDepartID = cmb_uc_Org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;

        for (int i = 0; i < lstSelect.Items.Count; i++)
        {
            string strSystemCode = lstSelect.Items[i].Value;

            emp3102.insertEMPIshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID,
                strSystemCode,
                this.strLoginUserID
                );
        }

    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        doQueryData();
        this.pnlresult.Visible = true;
//        pnlConditions.Enabled = false;
        btnEditOK.Visible = false;
        btnAddOK.Visible = true;

        btnAddOK.Visible = false;
        btnEditOK.Visible = true;

    }

    private void doQueryData()
    {
        EMP3102 emp3102 = new EMP3102();
//        string strDepartID = cmb_uc_Org12.OrgCode;
        string strDepartID = cmg_uc_org1.SelectedValue;
        string strShareID = cmb_uc_idtype.SelectedValue;

        DataTable dt = emp3102.queryEMPIshareSysProfFull(
            this.strOrgCode,
            strDepartID,
            strShareID);
        gvResult.DataSource = dt;
        gvResult.DataBind();
    }

    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
//        Response.Write("RowCommand");
        if (e.CommandName == "doupdate") //修改button
        {
            //Response.Write("EDIT");
            strMode = "EDIT";
            int index = Convert.ToInt32(e.CommandArgument);
            initUpdate(index);
            lblMode.Text = "維護";
            pnlModify.Visible = true;
            pnlresult.Visible = false;
            pnlConditions.Visible = false;
        }
    }

    private void initUpdate(int index)// Grid 列
    {
        EMP3102 emp3102 = new EMP3102();
        cmb1stDept4Edit.Enabled = false;
//        cmb_uc_Org114Edit.Enabled = false;
//        cmb_uc_Org124Edit.Enabled = false;
//        Response.Write("["+gvResult.Rows[index].Cells[1].Text.ToString()+"]<BR>");

        //DropDownList cmb = (DropDownList)cmb_uc_idtype4Edit.FindControl("DropDownList_code_no");
        //cmb.SelectedValue = gvResult.Rows[index].Cells[1].Text.ToString();
        try
        {
            cmb_uc_idtype4Edit.SelectedValue    = gvResult.Rows[index].Cells[1].Text.ToString();
        }
        catch
        {
        }

        cmb1stDept4Edit.SelectedValue = cmb1stDept.SelectedValue;

        cmb_uc_Org4Edit.Orgcode = cmb1stDept4Edit.SelectedValue;
        try
        {
            cmb_uc_Org4Edit.SelectedValue = gvResult.Rows[index].Cells[0].Text.ToString();
        }
        catch
        {
        }

        showhideModifyControls(false);

        // 取得資料
        EMP3102 emp3112=new EMP3102();
        string strDepartID = cmb_uc_Org4Edit.SelectedValue;
        string strShareID = cmb_uc_idtype4Edit.SelectedValue;
        DataTable dt = emp3112.querySelectSystem(this.strOrgCode,
            strDepartID,
            strShareID
            ,"N");
        lstUnSelect.DataSource = dt;
        lstUnSelect.DataValueField = "SYSTEM_CODE";
        lstUnSelect.DataTextField = "SYSTEM_NAME";
        lstUnSelect.DataBind();
        dt = emp3112.querySelectSystem(this.strOrgCode,
             strDepartID,
             strShareID
             , "Y");
        lstSelect.DataSource = dt;
        lstSelect.DataValueField = "SYSTEM_CODE";
        lstSelect.DataTextField = "SYSTEM_NAME";
        lstSelect.DataBind();
 

//        lblID.Text = gvResult.Rows[index].Cells[4].Text;
    }

    private void showhideModifyControls(bool bShow)
    {
        DropDownList cmb = (DropDownList)cmb_uc_idtype4Edit.FindControl("DropDownList_code_no");
        cmb.Enabled = bShow;
        /*
        cmb = (DropDownList)cmb_uc_org4Edit.FindControl("ddlDepart");
        // 取得 PArentID
        cmb.Enabled = bShow;

        cmb = (DropDownList)cmb_uc_org4Edit.FindControl("ddlSubDepart");
        cmb.Enabled = bShow;
        */
    }

    protected void edit_submit_Click(object sender, EventArgs e)
    {
        doDelete();
        doInsert();

        pnlModify.Visible = false;
        this.doQueryData();

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "修改完成", "", "");
        this.Page = tempPage;

        pnlModify.Visible = false;
        pnlConditions.Visible = true;
        pnlresult.Visible = true;




    }

    private void showhidecol(bool bshow)
    {
        gvResult.Columns[0].Visible = bshow;
        gvResult.Columns[1].Visible = bshow;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
       // Response.Write("lblSN"+lblSN.Text+"<BR>");
        EMP3102 emp3102 = new EMP3102();
        // 參數
        int index=Convert.ToInt16(lblSN.Text);
        string strDepartID = gvResult.Rows[index].Cells[0].Text.ToString();
        string strShareID = gvResult.Rows[index].Cells[1].Text.ToString();
        emp3102.deleteEMPIshareSysProf(
                this.strOrgCode,
                strDepartID,
                strShareID
            );

        this.doQueryData();

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "已刪除", "", "");
        this.Page = tempPage;

    }
    protected void btnQueryOK_Click(object sender, EventArgs e)
    {
        pnlConditions.Visible = true;
        pnlresult.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlModify.Visible = false;
        pnlConditions.Visible = true;
        pnlresult.Visible = false;
    }
    // //匯出按鈕
    protected void btnExport_Click(object sender, EventArgs e)
    {
        EMP3102 emp3102 = new EMP3102();
        string strDepartID = cmg_uc_org1.SelectedValue;
        string strShareID = cmb_uc_idtype.SelectedValue;

        DataTable dt = emp3102.queryEMPIshareSysProfFull(
            this.strOrgCode,
            strDepartID,
            strShareID);

        // 匯出動作
        CommonLib.DTReport rpt;
        rpt = new CommonLib.DTReport(Server.MapPath("~/Report/EMP/EMP3102.mht"), dt);
        rpt.ExportFileName = "共用系統權限設定-依人員類別";

        // 參數部分
        string[] strParams = new string[1];
        strParams[0] = "";

        rpt.Param = strParams;
        rpt.ExportToExcel();        
    }
    protected void cmb1stDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.bindOrg();
    }
    protected void cmb1stDept4Edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_uc_Org4Edit.Orgcode = cmb1stDept4Edit.SelectedValue;
    }
    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gvResult_PageIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        strMode = "EDIT";
        int index = Convert.ToInt32(lblSN.Text);
        initUpdate(index);
        lblMode.Text = "維護";
        pnlModify.Visible = true;
        pnlresult.Visible = false;
        pnlConditions.Visible = false;
        this.showhidecol(false);

    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        this.showhidecol(false);
    }
    protected void gvResult_DataBinding(object sender, EventArgs e)
    {
        this.showhidecol(true);
    }
}