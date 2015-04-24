using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;

public partial class PRO_PRO3_PRO3101_02 : BaseWebForm
{
    private PRO3101 dao = new PRO3101();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucUnit_code.Orgcode = LoginManager.OrgCode;
            ucUser_id.Orgcode = LoginManager.OrgCode;
            hfFlow_id.Value = Page.Request.QueryString["FlowId"].ToString();
            BindOne(hfFlow_id.Value);
            
        }
    }

    private void BindOne(string flow_id)
    {
        DataRow dr = dao.psrmDAO.GetOne(flow_id, LoginManager.OrgCode);
        txtOfficialNumber_id.Text = dr["OfficialNumber_id"].ToString();
        txtSoftware_id.Text = dr["Software_id"].ToString();
        ucSoftware_type.Code_no = dr["Software_type"].ToString();
        txtSoftware_name.Text = dr["Software_name"].ToString();
        txtVersion.Text = dr["Version"].ToString();
        txtKeyNumber_nos.Text = dr["KeyNumber_nos"].ToString();
        ucSoftwareKind_type.Code_no = dr["SoftwareKind_type"].ToString();
        txtSofeware_cnt.Text = dr["Sofeware_cnt"].ToString();
        ucObtain_type.Code_no = dr["Obtain_type"].ToString();
        txtObtainOt_desc.Text = dr["ObtainOt_desc"].ToString();
        txtSoftwareUnit_name.Text = dr["SoftwareUnit_name"].ToString();
        txtMemo.Text = dr["Memo"].ToString();
        ucStorageMedia_type.Code_no = dr["StorageMedia_type"].ToString();
        txtStorageMedia_cnt.Text = dr["StorageMedia_cnt"].ToString();
        txtRelatedPapers_name.Text = dr["RelatedPapers_name"].ToString();
        txtLifeTime.Text = dr["LifeTime"].ToString();
        txtFee_amt.Text = dr["Fee_amt"].ToString();
        txtMRent_amt.Text = dr["MRent_amt"].ToString();
        ucStart_date.Text = CommonFun.getYYYMMDD (Convert.ToDateTime(dr["Start_date"]));
        ucUnit_code.SelectedValue = dr["Unit_code"].ToString();
        ucUser_id.DepartId = dr["Unit_code"].ToString();
        //ucUser_id.BindMember();
        //ucUser_id.SelectedValue = dr["User_id"].ToString();
        ucRegister_date.Text = CommonFun.getYYYMMDD (Convert.ToDateTime(dr["Register_date"]));
    }
    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = CheckRequire();
            if (string.IsNullOrEmpty(msg))
            {

                dao.psrmDAO.Modify(LoginManager.OrgCode, hfFlow_id.Value, txtOfficialNumber_id.Text, txtSoftware_id.Text, ucSoftware_type.Code_no,
                    txtSoftware_name.Text, txtVersion.Text, txtKeyNumber_nos.Text, ucSoftwareKind_type.SelectedValue,
                    string.IsNullOrEmpty(txtNetPLimit_cnt.Text) ? Int16.MinValue : Convert.ToInt16(txtNetPLimit_cnt.Text),
                    string.IsNullOrEmpty(txtSofeware_cnt.Text) ? Int16.MinValue : Convert.ToInt16(txtSofeware_cnt.Text), ucObtain_type.SelectedValue, txtObtainOt_desc.Text, 
                    txtSoftwareUnit_name.Text, ucStorageMedia_type.SelectedValue,
                    txtStorageMediaOt_desc.Text, string.IsNullOrEmpty(txtStorageMedia_cnt.Text) ? Int16.MinValue : Convert.ToInt16(txtStorageMedia_cnt.Text),
                    txtRelatedPapers_name.Text, string.IsNullOrEmpty(txtLifeTime.Text) ? Double.MinValue : Convert.ToDouble(txtLifeTime.Text),
                    string.IsNullOrEmpty(txtFee_amt.Text) ? Double.MinValue : Convert.ToDouble(txtFee_amt.Text),
                    string.IsNullOrEmpty(txtMRent_amt.Text) ? Double.MinValue : Convert.ToDouble(txtMRent_amt.Text), 
                    ucStart_date.Text, LoginManager.Depart_id, LoginManager.UserId, ucRegister_date.Text,
                    txtMemo.Text, LoginManager.UserId, DateTime.Now);
                Page.Response.Redirect("~/PRO/PRO3/PRO3101_01.aspx");
            }
            else
            {
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
            }
           
        }
        catch (Exception ex)
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, ex.Message, "", "");
        }
        
    }
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
    }
    protected void ucUnit_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucUser_id.Orgcode = LoginManager.OrgCode;
        ucUser_id.DepartId = ucUnit_code.SelectedValue;
    }

    protected string CheckRequire() 
    {
        string msg = string.Empty;
        if( string.IsNullOrEmpty(txtSoftware_id.Text) )
            msg += @"請輸入軟體編號\n";
       
        if( string.IsNullOrEmpty(ucSoftware_type.SelectedValue)  )
            msg += @"請選擇軟體別\n";
        
        if( string.IsNullOrEmpty(ucSoftwareKind_type.SelectedValue)  )
            msg += @"請選擇使用版別\n";
      
        if( string.IsNullOrEmpty(ucObtain_type.SelectedValue)  )
            msg += @"請選擇取得方式\n";

        if( string.IsNullOrEmpty(txtSoftwareUnit_name.Text)  )
            msg += @"請輸入軟體廠商\n";
       
        if( string.IsNullOrEmpty(txtFee_amt.Text)  )
            msg += @"請輸入費用\n";
        
        if( string.IsNullOrEmpty(txtMRent_amt.Text)  )
            msg += @"請輸入月租金\n";
        
        if( string.IsNullOrEmpty(ucStart_date.Text)  )
            msg += @"請輸入啟用日期\n";
        return msg;
        
    }
}