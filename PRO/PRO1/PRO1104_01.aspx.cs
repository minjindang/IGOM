using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRO.Logic;
using System.Transactions;

public partial class PRO1104_01 : BaseWebForm
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ucDept.Orgcode = LoginManager.OrgCode;
            Name_bind();

            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                ShowResentData();
            }
            else
            {
                Bind();
            }
        }
    }

    protected void ShowResentData()
    {
        PRO_SwRegister_Trans swt = new PRO_SwRegister_Trans();
        DataTable tmp = swt.getDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);
        DataTable dt = new FSCPLM.Logic.PRO_SwRegister_main().GetAll().Clone();

        foreach (DataRow dr in tmp.Rows)
        {
            ucDept.SelectedValue = dr["NewUnit_code"].ToString();
            Name_bind();
            ucMember.SelectedValue = dr["NewKeeper_id"].ToString();
            dt.ImportRow(new FSCPLM.Logic.PRO_SwRegister_main().GetOne(dr["SR_Flow_id"].ToString(), Request.QueryString["org"]));
        }

        dt.Columns.Add("Software_type_name");
        foreach (DataRow dr in dt.Rows)
        {
            dr["Software_type_name"] = new SYS.Logic.CODE().GetDataDESC("016", "004", dr["Software_type"].ToString());
        }

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
        ViewState["dt"] = dt;
    }

    private void Bind()
    {
        PRO1104 bll = new PRO1104();
        DataTable dt = bll.getData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card));
        div1.Visible = dt != null && dt.Rows.Count > 0;
        DoneBtn.Enabled = dt != null && dt.Rows.Count > 0;
        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
        ViewState["dt"] = dt;
    }

    protected void ClrBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRO1104_01.aspx");
    }

    protected void GridViewA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewA.PageIndex = e.NewPageIndex;
        GridViewA.DataSource = (DataTable)ViewState["dt"];
        GridViewA.DataBind();
    }

    protected void ucDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        Name_bind();
    }

    protected void Name_bind()
    {
        ucMember.Orgcode = LoginManager.OrgCode;
        ucMember.DepartId = ucDept.SelectedValue;
    }

    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        Page p = this.Page;

        if (string.IsNullOrEmpty(ucMember.SelectedValue))
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請選擇新保管人!", "", "");
            return;
        }

        string Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        string NEW_User_id = ucMember.SelectedValue;
        string NEW_Depart_id = new FSC.Logic.DepartEmp().GetDepartId(ucMember.SelectedValue);
        string flow_id = string.Empty;

        PRO_SwRegister_Trans swt = new PRO_SwRegister_Trans();
        SYS.Logic.Flow f = new SYS.Logic.Flow();

        try
        {
            string url = "";
            bool isUpdate = false;
            if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                url = "../../FSC/FSC0/FSC0102_01.aspx";
                isUpdate = true;
            }

            string msg = "您已送出\\n";
            using (TransactionScope trans = new TransactionScope())
            {
                flow_id = (isUpdate ? Request.QueryString["fid"] : new SYS.Logic.FlowId().GetFlowId(Orgcode, "004091"));
                f.FlowId = flow_id;
                f.Orgcode = Orgcode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.WriterOrgcode = Orgcode;
                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.WriteTime = DateTime.Now;
                f.FormId = "004091";
                f.Reason = "";
                f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);

                if (isUpdate)
                {
                    swt.OrgCode = Request.QueryString["org"];
                    swt.Flow_id = Request.QueryString["fid"];
                    swt.delete();
                }

                int count = 0;
                foreach (GridViewRow gvr in GridViewA.Rows)
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("cb");
                    if (cb.Checked)
                    {
                        count += 1;
                        swt = new PRO_SwRegister_Trans();
                        Label lbFlow_id = (Label)gvr.FindControl("lbFlow_id");
                        Label lbUnit_code = (Label)gvr.FindControl("lbUnit_code");
                        Label lbUser_id = (Label)gvr.FindControl("lbUser_id");

                        swt.OrgCode = Orgcode;
                        swt.Flow_id = flow_id;
                        swt.SR_Flow_id = lbFlow_id.Text;
                        swt.OldUnit_code = lbUnit_code.Text;
                        swt.OldKeeper_id = lbUser_id.Text;
                        swt.NewUnit_code = NEW_Depart_id;
                        swt.NewKeeper_id = NEW_User_id;
                        swt.Trans_Apply_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString();
                        swt.ModUser_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                        swt.insert();
                        msg += "軟體編號：" + gvr.Cells[2].Text + " 軟體名稱：" + gvr.Cells[4].Text + "\\n";
                    }
                }
                msg += "軟體轉移申請成功!";

                if (count == 0)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "請至少勾選一項軟體!", "", "");
                    return;
                }
                else
                {
                    f.Reason = "轉移軟體項目共" + count.ToString() + "項";
                    if (isUpdate)
                    {
                        f.CaseStatus = 2;
                        f.Update();
                    }
                    else
                    {
                        SYS.Logic.CommonFlow.AddFlow(f);
                    }
                }

                trans.Complete();
            }
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, url, "");
            Bind();
        }
        catch (FlowException fex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom,fex.Message, "", "");
        }
        catch (Exception ex)
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.SystemError, "", "", "");
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
        }
    }

    protected void cbAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll = (CheckBox)sender;

        foreach (GridViewRow gvr in GridViewA.Rows)
        {
            CheckBox cb = (CheckBox)gvr.FindControl("cb");
            cb.Checked = cbAll.Checked;
        }
    }
}