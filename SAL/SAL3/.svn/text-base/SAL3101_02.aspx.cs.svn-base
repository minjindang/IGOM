using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SALPLM.Logic;
using System.Data;
using System.Data.SqlClient;

public partial class SAL_SAL3_VBOld_SAL3101_02 : BaseWebForm
{

    private string strOrgCode;  // 登入者機關代碼
    private string strLogIDCard;    // 登入者原邊
    protected void Page_Load(object sender, EventArgs e)
    {
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        strLogIDCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        if (Page.IsPostBack) return;
        DataTable dt=getData();
        BindData(dt);

    }

    private void BindData(DataTable dt)
    {
        GridView_SaBase.DataSource = dt;
        GridView_SaBase.DataBind();
    }

    private DataTable getData()
    {
        string[] orders =
            {
                DropDownList_order1.SelectedValue,
                DropDownList_order2.SelectedValue,
                DropDownList_order3.SelectedValue,
                DropDownList_order4.SelectedValue,
                DropDownList_order5.SelectedValue,
                DropDownList_order6.SelectedValue
            };
        string sorting_string = "";

        for (int i = 0; i <= orders.Length - 1; i++)
        {
            if (!(orders[i] == "disable"))
            {
                if (string.IsNullOrEmpty(sorting_string))
                {
                    sorting_string = orders[i];
                }
                else
                {
                    sorting_string = sorting_string + ", " + orders[i];
                }
                if (orders[i] == "base_org_l1")
                {
                    sorting_string = sorting_string + " desc";
                }
                else if (orders[i] == "base_ptb")
                {
                    sorting_string = sorting_string + " desc";
                }
            }
        }

        SAL3101 sal3101 = new SAL3101();
        DataTable dt = sal3101.querySalSaBase4ModifyPrts(this.strOrgCode, sorting_string);
        return dt;
        


    }

    protected string FStyle(object value)
    {
        string rv = "";

        if (value.ToString() == "未設定")
        {
            rv = "color:blue";
        }
        else
        {
            rv = "";
        }

        return rv;
    }
    protected void Button_SortReset_Click(object sender, EventArgs e)
    {
        if (!check_orders()) return;
        // Clear
        SAL3101 sal3101 = new SAL3101();
        sal3101.clearSalSabasePrts(this.strOrgCode);

        DataTable dt = getData();
        for (int i=0;i < dt.Rows.Count ;i++)
        {
            sal3101.updateSalSabasePrts(this.strOrgCode,
                dt.Rows[i]["BASE_SEQNO"].ToString(),
                (i+1).ToString()
                
                );
        }

        dt= this.getData();
        this.BindData(dt);

        string msg = "";
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "設定完成！", "", "");
        this.Page = tempPage;
    }

    // 檢查順序
    protected bool check_orders()
    {
        bool rv = true;
        string[] orders =
            {
                DropDownList_order1.SelectedValue,
                DropDownList_order2.SelectedValue,
                DropDownList_order3.SelectedValue,
                DropDownList_order4.SelectedValue,
                DropDownList_order5.SelectedValue,
                DropDownList_order6.SelectedValue
            };

        try
        {


            for (int i = 0; i <= orders.Length - 2; i++)
            {
                for (int j = i + 1; j <= orders.Length - 1; j++)
                {
                    if ((orders[i] == orders[j]) & (orders[i] != "disable"))
                    {
                        rv = false;
                    }
                }
            }


        }
        catch (Exception ex)
        {
        }

        if (!rv)
        {
            string msg = "";
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "順序項目請勿重覆選擇！", "", "");
            this.Page = tempPage;


        }

        return rv;
    }



    protected void Button_Update_Click(object sender, EventArgs e)
    {
        SAL3101 sal3101 = new SAL3101();
        foreach (GridViewRow gvr in this.GridView_SaBase.Rows)
        {
            try
            {
                string v_base_seqno = ((TextBox)gvr.FindControl("TextBox_base_seqno")).Text;
                string v_base_prts = ((TextBox)gvr.FindControl("TextBox_base_prts")).Text;
                string v_base_prts_Ori = ((TextBox)gvr.FindControl("TextBox_base_prts_Ori")).Text;
                //新增判斷條件如果USER有輸入變更才更新資料庫
                if ((v_base_prts != v_base_prts_Ori))
                {
                    sal3101.updateSalSabasePrts(this.strOrgCode,
                                    v_base_seqno,
                                    v_base_prts

                                    );
                }




            }
            catch (Exception ex)
            {
            }

        }

        DataTable dt = this.getData();
        this.BindData(dt);

        string msg = "";
        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage,
           CommonFun.Msg.Custom, "設定完成！", "", "");
        this.Page = tempPage;

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3101_01.aspx");
    }
    protected void GridView_SaBase_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView_SaBase_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_SaBase.PageIndex = e.NewPageIndex;
        DataTable dt = getData();
        BindData(dt);
    }
}