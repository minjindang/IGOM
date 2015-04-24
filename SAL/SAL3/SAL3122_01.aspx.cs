using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Add
using System.Collections;
using SALPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;

public partial class SAL_SAL3_SAL3122_01 : BaseWebForm 
{ 
    private string strOrgCode;  // 登入者機關代碼
  //  private string v_YM;
     
    protected void Page_Load(object sender, EventArgs e)
    {    
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
         
        DropDownList ddly = (DropDownList)ucDateDropDownList.FindControl("DropDownList_Y");
        ddly.AutoPostBack = true;
        ddly.SelectedIndexChanged +=new EventHandler(ddly_SelectedIndexChanged);

        DropDownList ddlm = (DropDownList)ucDateDropDownList.FindControl("DropDownList_M");
        ddlm.AutoPostBack = true;
        ddlm.SelectedIndexChanged += new EventHandler(ddly_SelectedIndexChanged);

        if (!Page.IsPostBack)
        {
            TextBox_ym.Text = DateTime.Now.ToString("yyyyMM");
            Get_SAUPUNIT();
            Get_SQLs1();
            GetSAUPEMPDATA();
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;    
        string year = DateTime.Now.ToString("yyyy");
        ucDateDropDownList.Kind = "YM";
        ucDateDropDownList.year_e = (int.Parse(year) +1 ).ToString();
        ucDateDropDownList.year_s = (int.Parse(year) -2 ).ToString();
        ucDateDropDownList.DateStr = DateTime.Now.ToString("yyyyMM");
    }

    protected void ddly_SelectedIndexChanged(object sender, EventArgs e) //change ucDateDropDownList
    {
        TextBox_ym.Text = ucDateDropDownList.DateStr;
        Get_SQLs1();     
    }

    protected void GetSAUPEMPDATA()
    {   
        for (int i=0; i < GridView_Uporg.Rows.Count; i++ )
        {
            if (i >= 0)
            {
                updateAmt(i);
            }
        }
    }

    protected void updateAmt(int index)
    {
        CheckBox ck = (CheckBox)GridView_Uporg.Rows[index].Cells[1].FindControl("CheckBox_chk");
        string tabid = ((Label)GridView_Uporg.Rows[index].Cells[2].FindControl("Label_tabid")).Text;
        string tabtype = ((Label)GridView_Uporg.Rows[index].Cells[2].FindControl("Label_tabtype")).Text;

        string sql = "";
        string deletesql = "";
        string t_seqno = "";
        string t_orgid = "";
        string t_amt = "";
        string t_type = "NULL";
        string t_class = "NULL";
        string t_qty = "NULL";
        string t_kind = "NULL";
        string t_FType = "";
        string t_DType = "";

        string v_PAYOD_CODE_SYS = "";
        string v_PAYOD_CODE_KIND = "";
        string v_PAYOD_CODE_TYPE = "";
        string v_PAYOD_CODE_NO = "";
        string v_PAYOD_CODE = "";
        string v_YM = TextBox_ym.Text;

        if (tabtype == "個人")
        {            
            if (tabid =="A0001")//公教人員俸表 
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData1(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    sal3122.querydelete1_1(v_YM, strOrgCode, tabid);
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a =Convert.ToDouble(t_amt);
                        int amt = (int)a;
              //          Response.Write((int)a);           
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }                  
                }
            }
            else if (tabid == "A00011") // 公教人員俸表(教育警察人員)
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData2(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }                  
                }
            }
            else if (tabid == "A00013") // 政務人員給與表
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData3(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                 }
            }
            else if (tabid == "A0002") // 雇員
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData4(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }                    
                }
            }
            else if (tabid == "A0003") // 技工工友
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData5(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "A0004") // 聘用人員
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData6(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "A0005") // 約僱人員
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData7(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B1001") // 專業表一
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData8(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B10011") // 專業表一(雇員、技工、工友)
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData9(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B1105") // 專業表五 法制人員適用
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData10(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B1019") //  專業表十九(監察人員)
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData11(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B1020") // 專業表二十 資訊人員適用
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData12(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "B1124") // 專業表二十四   醫事人員適用
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData13(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "C1001") // 公務人員主管加給 '001'
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData14(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "C1002") // 醫事人員主管加給對照表
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData15(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "C1010") // 比照簡任十四、十三職等人員主管職務加給表   
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData16(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "D1001") // 山僻地區加給表
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData17(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "D1002") // '離島地區加給表
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData18(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "D1003") //東台加給
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData19(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "E0001") //子女教育補助
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData20(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "E0002")  //結婚補助
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData21(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "E0003")  //生育補助
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData22(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "E0004")  //喪葬補助
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData23(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "F0003-0")  //兼職費
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData24(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
            else if (tabid == "F0055-0")  //未休假加班費
            {
                SAL3122 sal3122 = new SAL3122();
                DataTable data1 = sal3122.queryData25(strOrgCode, v_YM);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        t_seqno = data1.Rows[i]["SEQNO"].ToString();
                        t_orgid = data1.Rows[i]["ORGID"].ToString();
                        t_type = "0";
                        t_amt = data1.Rows[i]["AMT"].ToString();
                        Double a = Convert.ToDouble(t_amt);
                        int amt = (int)a;
                        sal3122.querydelete1(v_YM, strOrgCode, tabid, t_orgid, t_seqno, amt.ToString(), t_type, t_class, t_qty, t_kind, t_FType, t_DType);
                    }
                }
            }
        }
        else if (tabtype == "機關")
        {
            DataTable data1 = new DataTable();
            if (tabid == "E0008")  //子女教育補助(退休人員)
            {
                        v_PAYOD_CODE_SYS = "005";
                        v_PAYOD_CODE_KIND = "D";
                        v_PAYOD_CODE_TYPE = "001";
                        v_PAYOD_CODE_NO = "501";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData26(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE,v_PAYOD_CODE_NO, v_YM);             
            }
            else if (tabid == "E0009")  //子女教育補助(技工、工友)
            {
                        v_PAYOD_CODE_SYS = "005";
                        v_PAYOD_CODE_KIND = "D";
                        v_PAYOD_CODE_TYPE = "001";
                        v_PAYOD_CODE_NO = "501";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData27(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0001-1")  //加班費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "601";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0002-1")  //值班費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "602";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0004-1")  //講座鐘點費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "604";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0005-1")  //夜點費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "605";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0015-1")  //裁判費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "615";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0018-1")  //公職人員選舉投開票所工作人員津貼
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "618";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0030-1")  //協查研究費(原稱國會津貼)
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "630";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0031-1")  //協查研究費(原稱國會津貼)
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "631";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0038-1")  //'各機關聘請國外顧問、專家及學者來台工作期間支付費
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "638";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0042-1")  //考選部建立題庫各項費用
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "642";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0042-1")  //考選部建立題庫各項費用
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "642";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0043-1")  //考選部各項考試工作酬勞費用
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "643";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0044-1")  //各機關(構)學校特約(兼任)醫師(法醫師)診療報酬
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "644";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0055-1")  //未休假加班費--無法以個人報送人員(如臨時、額外人員)
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "655";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData29(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "F0056-1")  //休假補助
            {
                v_PAYOD_CODE_SYS = "005";
                v_PAYOD_CODE_KIND = "D";
                v_PAYOD_CODE_TYPE = "001";
                v_PAYOD_CODE_NO = "656";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData28(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "G1001-1")  //年終獎金
            {
                 v_PAYOD_CODE_SYS = "003";
                 v_PAYOD_CODE_KIND = "P";
                 v_PAYOD_CODE_TYPE = "003";
                 v_PAYOD_CODE_NO = "003";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData30(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "G1002-1")  //考績獎金
            {
                v_PAYOD_CODE_SYS = "003";
                v_PAYOD_CODE_KIND = "P";
                v_PAYOD_CODE_TYPE = "003";
                v_PAYOD_CODE_NO = "003";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData31(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "G1003-1")  //預借考績獎金
            {
                v_PAYOD_CODE_SYS = "003";
                v_PAYOD_CODE_KIND = "P";
                v_PAYOD_CODE_TYPE = "003";
                v_PAYOD_CODE_NO = "003";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData32(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }
            else if (tabid == "G1005-1")  //退休人員年終慰問金
            {
                v_PAYOD_CODE_SYS = "003";
                v_PAYOD_CODE_KIND = "P";
                v_PAYOD_CODE_TYPE = "003";
                v_PAYOD_CODE_NO = "003";
                SAL3122 sal3122 = new SAL3122();
                 data1 = sal3122.queryData33(v_PAYOD_CODE_SYS, v_PAYOD_CODE_KIND, v_PAYOD_CODE_TYPE, v_PAYOD_CODE_NO, v_YM);
            }

            string org_amt = "";
            if (data1 != null && data1.Rows.Count > 0)
            {
                org_amt = data1.Rows[0]["orgamt"].ToString();              
            }
            if (org_amt == "")
            {
                org_amt = "0";
            }
            Double orgamt = Convert.ToDouble(org_amt);
            int aa = (int)orgamt;
            org_amt = aa.ToString();

            Panel pn = (Panel)GridView_Uporg.Rows[index].Cells[5].FindControl("Panel1");         
            TextBox amt = (TextBox)pn.FindControl("TextBox_amt");
            amt.Text = org_amt;       
            t_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId);  // LoginManager.UserData.v_ROLE_ORGID
            
            SAL3122 s3122 = new SAL3122();
            s3122.querydelete(v_YM, strOrgCode, tabid, t_amt, org_amt);            
        }

        Get_SQLs1();
    }

    protected void Get_SAUPUNIT()
    {
        SAL3122 sal3122 = new SAL3122();
        DataTable data = sal3122.queryData(strOrgCode);
        if (data != null && data.Rows.Count > 0)
        {
            TextBox_cname.Text = data.Rows[0]["upunit_cname"].ToString();
            TextBox_ctel.Text = data.Rows[0]["upunit_ctel"].ToString();
            TextBox_cemail.Text = data.Rows[0]["upunit_cemail"].ToString();
        }     
    }

    //GridView_Uporg_DataBind
    protected void Get_SQLs1()
    {
        string v_YM = TextBox_ym.Text;
        string Str = uporgStr();
        SAL3122 sal3122 = new SAL3122();
        DataTable data = sal3122.queryGridData(v_YM, Str);
        if (data != null && data.Rows.Count > 0)
        {           
            GridView_Uporg.DataSource = data;
            GridView_Uporg.DataBind();                      
        }
        else
        {
            GridView_Uporg.DataSource = data;
            GridView_Uporg.DataBind();

            if (GridView_Uporg.Rows.Count > 0)
            {
                UcPager.Visible = true;
            }
            else
            {
                UcPager.Visible = false;
            }

     /*       Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;
      */ 
        }
    }

    protected string uporgStr()
    {
        string rv = "";
       
        if (strOrgCode == "379150000I") //--環保局
        {
            rv = " G.UPORG_ID in ('379150000I','8900000001','8900000002','8900000003','8900000004','8900000006','8900000007','8900000008','8900000009','8900000010','8900000011','8900000012','8900000013','8900000014','8900000015','8900000016','8900000041','8900000042','890000005','890000006') ";
        }
        else if (strOrgCode == "379135000C")  //--少年警察隊 
        {
            rv = " G.UPORG_ID in ('379135000C','9300000001') ";
        }
        else
        {
            rv = " G.UPORG_ID = '" + strOrgCode + "' ";
        }
        return rv;
    }

    //刪除資料button
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int index = int.Parse(txtFuncParam.Value.Trim());
        Label lb = (Label)GridView_Uporg.Rows[index].Cells[2].FindControl("Label_tabid");
        string vTabID = lb.Text;// GridView_Uporg.Rows[index].Cells[6].ToString();
   
        SAL3122 sal3122 = new SAL3122();
        sal3122.querydeleteData(TextBox_ym.Text, strOrgCode, vTabID);

        Page tempPage = this.Page;
        CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "刪除成功", "", "");
        this.Page = tempPage;
        Get_SQLs1();
    }
    protected void Update_SAUPUNIT()
    {
        string v_UserName = TextBox_cname.Text;
        string v_UserTel = TextBox_ctel.Text;
        string v_UserMail = TextBox_cemail.Text;
        SAL3122 sal3122 = new SAL3122();
        sal3122.querySAUPUNIT(strOrgCode, v_UserName, v_UserTel, v_UserMail);
    }
    protected void Update_SAUPEMP()
    {
        for (int i = 0; i < GridView_Uporg.Rows.Count; i++ )
        {
            if ((((CheckBox)GridView_Uporg.Rows[i].Cells[1].FindControl("CheckBox_chk")).Checked) && ((((TextBox)GridView_Uporg.Rows[i].Cells[5].FindControl("TextBox_amt")).Text)) != "")
            {
                if (((Label)GridView_Uporg.Rows[i].Cells[2].FindControl("Label_tabtype")).Text == "機關")
                {
                    string vAmt = ((TextBox)GridView_Uporg.Rows[i].Cells[5].FindControl("TextBox_amt")).Text;
                    string vOrgTabID = ((Label)GridView_Uporg.Rows[i].Cells[2].FindControl("Label_tabid")).Text;
                   
                    SAL3122 sal3122 = new SAL3122();
                    sal3122.querySAUPEMP(TextBox_ym.Text, strOrgCode, vOrgTabID, vAmt);  
                }
            }
        }

    }
    protected void get_file_str()
    {
        string v_YM = TextBox_ym.Text;
        Label_download.Text = "";

        //' 首錄 - SalaryM(20) to strSalaryM
        string strSalaryM = "";
        string[] SalaryM = new string[20];
        //' 檔案內容 - strSalary

        string strSalary = "";

        //' 取檔名
        string sDateTime = fFormatNumber(Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy")) - 1911), 3, 0) + fFormatNumber(DateTime.Now.ToString("MMddHHmmss"), 10, 0);
        TextBox_filename.Text = strOrgCode + "." + sDateTime;
        
      //  ============================    首錄 START  ================================

        for (int i = 0; i < SalaryM.Length; i++)
        {
            SalaryM[i] = "";
        }

        // '資料機關代號 1-10
        SalaryM[1] = fFormatChar(strOrgCode, 10);
        
        //'兼辦業務(報送)機關代號 11-20
        SalaryM[2] = fFormatChar(strOrgCode, 10);

        //'檔案壓縮加密種類 21
        SalaryM[3] = " ";

        string v_mid = LoginManager.UserId;
         // '聯絡人身分證 22-31
        SalaryM[4] = fFormatChar(v_mid, 10);

        //'聯絡人姓名 32-43
        SalaryM[5] = fFormatChar(TextBox_cname.Text, 12);

        //'聯絡人電話 44-62
        SalaryM[6] = fFormatChar(TextBox_ctel.Text, 19);

        //'聯絡人電子郵件 63-92
        SalaryM[7] = fFormatChar(TextBox_cemail.Text, 30);

        //'上傳資料人數 93-98  (先放空白,之後補上)
        SalaryM[8] = "      ";

        //'上傳資料筆數 99-104 (先放空白,之後補上)
        SalaryM[9] = "      ";

        //   '類型 105-114
        SalaryM[10] = "CPASAL0000";

        //'報送資料年月 115-119
        SalaryM[11] = fFormatNumber((int.Parse(v_YM) - 191100).ToString(), 5, 0);

        // '上傳媒體 120
        SalaryM[12] = "1";

        //'資料最新日期時間 121-133
        SalaryM[13] = sDateTime;

        //'空白 134-180
        SalaryM[14] = fFormatChar("", 47);
        //  ============================    首錄 END    ================================

        //  ============================    檔案內容 START  ============================
        
        string vSeqNo_p = "";
        // 資料筆數
        int j = 0;
        int vPCount = 0;
        string vTmpStr = "";      

        SAL3122 sal3122 = new SAL3122();
        string tab = vTabID();
     
        DataTable data = sal3122.queryfile(strOrgCode, v_YM, tab);
     
        if (data != null && data.Rows.Count > 0)
        {
        for (int i = 0; i < data.Rows.Count; i++)
        {
            if (data.Rows[i]["UPTCL_TYPE"].ToString() == " 機關")
            {
                vTmpStr = fGetOrgStr(data.Rows[i]["UPEMP_TABID"].ToString(), data.Rows[i]["UPEMP_AMT"].ToString());
            }
            else
            {
                if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0,1)=="A")
                {
                    vTmpStr = fGetTabAStr(data.Rows[i]["UPEMP_TABID"].ToString()
                        , data.Rows[i]["BASE_IDNO"].ToString()
                        , data.Rows[i]["BASE_ORG_L1"].ToString()
                        , data.Rows[i]["BASE_ORG_L2"].ToString()
                        , data.Rows[i]["BASE_PTB"].ToString()
                        , data.Rows[i]["BASE_DCODE"].ToString()
                        , data.Rows[i]["UPEMP_AMT"].ToString());
                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "B")
                {
                    vTmpStr = fGetTabBStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                                            data.Rows[i]["BASE_IDNO"].ToString(),
                                            data.Rows[i]["BASE_ORG_L1"].ToString(),
                                            data.Rows[i]["BASE_ORG_L2"].ToString(),
                                            data.Rows[i]["BASE_PTB"].ToString(),
                                            data.Rows[i]["BASE_DCODE"].ToString(),
                                            data.Rows[i]["UPEMP_AMT"].ToString(),
                                            data.Rows[i]["UPEMP_KIND"].ToString(),
                                            data.Rows[i]["UPEMP_TYPE"].ToString(),
                                            data.Rows[i]["UPEMP_QTY"].ToString());
                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "C")
                {
                    vTmpStr = fGetTabCStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                        data.Rows[i]["BASE_IDNO"].ToString(),
                        data.Rows[i]["BASE_ORG_L1"].ToString(),
                        data.Rows[i]["BASE_PTB"].ToString(),
                        data.Rows[i]["UPEMP_AMT"].ToString(),
                        data.Rows[i]["UPEMP_TYPE"].ToString());
                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "D")
                {
                    vTmpStr = fGetTabDStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                                        data.Rows[i]["BASE_IDNO"].ToString(),
                                        data.Rows[i]["BASE_ORG_L1"].ToString(),
                                        data.Rows[i]["UPEMP_AMT"].ToString());
                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "E")
                {
                    vTmpStr = fGetTabEStr(data.Rows[i]["UPEMP_TABID"].ToString()
                        , data.Rows[i]["BASE_IDNO"].ToString()
                        , data.Rows[i]["UPEMP_AMT"].ToString()
                        , data.Rows[i]["UPEMP_KIND"].ToString()
                        , data.Rows[i]["UPEMP_TYPE"].ToString()
                        , data.Rows[i]["UPEMP_QTY"].ToString()
                        , data.Rows[i]["UPEMP_CLASS"].ToString());

                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "F")
                {
                    vTmpStr = fGetTabFStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                                                    data.Rows[i]["BASE_IDNO"].ToString(),
                                                    data.Rows[i]["BASE_ORG_L1"].ToString(),
                                                    data.Rows[i]["BASE_PTB"].ToString(),
                                                    data.Rows[i]["BASE_DCODE"].ToString(),
                                                    data.Rows[i]["UPEMP_AMT"].ToString(),
                                                    data.Rows[i]["UPEMP_TYPE"].ToString());
                }
                else if ((data.Rows[i]["UPEMP_TABID"].ToString()).Substring(0, 1) == "G")
                {
                    vTmpStr = fGetTabGStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                        data.Rows[i]["BASE_IDNO"].ToString(),
                        data.Rows[i]["BASE_ORG_L1"].ToString(),
                        data.Rows[i]["UPEMP_AMT"].ToString());
                }
                else
                {
                    vTmpStr = fGetTabGStr(data.Rows[i]["UPEMP_TABID"].ToString(),
                                                      data.Rows[i]["BASE_IDNO"].ToString(),
                                                      data.Rows[i]["BASE_ORG_L1"].ToString(),
                                                      data.Rows[i]["UPEMP_AMT"].ToString());
                }
            }

                // 算人數            
                if (data.Rows[i]["UPEMP_SEQNO"].ToString() != vSeqNo_p)
                {
                    vPCount = vPCount + 1;
                }

                vSeqNo_p = data.Rows[i]["UPEMP_SEQNO"].ToString();

                strSalary = strSalary + vTmpStr + Environment.NewLine;

                j = j + 1;
            
        }
    }
    //  ============================    檔案內容 END    ============================
        //資料人數        
            SalaryM[8] = fFormatNumber(vPCount.ToString(), 6, 0);

            //資料筆數
            SalaryM[9] = fFormatNumber(j.ToString(), 6, 0);

            for (int i = 1; i <= 19; i++)
            {
                strSalaryM = strSalaryM + SalaryM[i].ToString();
            }

            strSalaryM = strSalaryM + Environment.NewLine;

            Label_download.Text += strSalaryM + strSalary;        
    }

    //組"A"類表別字串
    protected string fGetTabAStr(string tabid, string idno, string org_l1, string org_l2, string ptb, string dcode, string amt)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

            //支薪機關 1-10        
            SalaryD[1] = fFormatChar(strOrgCode, 10);

            //資料年月 11-15
            SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

            //待遇表別代碼 16-25
            SalaryD[3] = fFormatChar(tabid, 10);

            //身分證字號後五碼 26-30
            string idnum = fFormatChar(idno, 10);
            SalaryD[4] = idnum.Substring(idnum.Length-5);

            //官職等代碼 31-33
            SalaryD[5] = fFormatChar(org_l1, 3);

            //俸級代碼 34-36
            SalaryD[6] = fFormatChar(org_l2, 3);

            //薪(俸)點 37-40
            if (tabid != "A0011" && tabid != "A0014" && tabid != "A0016")
            {
                SalaryD[7] = fFormatChar(ptb, 4);
            }
            else
            {
                SalaryD[7] = "    ";
            }

            //職稱代碼 41-44
            SalaryD[8] = fFormatChar(dcode, 4);

            //折合率 45-52
            if (tabid == "A0004" | tabid == "A0005")
            {
                SalaryD[9] = fFormatNumber("121.1", 8, 1);
            }
            else
            {
                SalaryD[9] = "        ";
            }

            //定位點 53
            SalaryD[10] = "+";

            //身分證字號首碼 54
            SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

            //支領數額 55-62
            SalaryD[12] = fFormatNumber(amt, 8, 0);

            //待遇表別─類別 63-64
            SalaryD[13] = fFormatChar("", 2);

            //天(時、人、月)數 65-69
            SalaryD[14] = "     ";

            //服務地區 70-71
            SalaryD[15] = "  ";

            //班別 72-73
            SalaryD[16] = "  ";

            //親屬 74-75
            SalaryD[17] = "  ";

            //俸額 76-81
            SalaryD[18] = "      ";

            //公費 83-87
            SalaryD[19] = "      ";

            //待遇差額 88-93
            SalaryD[20] = "      ";

            //補發金額 94-99
            SalaryD[21] = "      ";

            //增支 100-105
            SalaryD[22] = "000000";

            //幣別 106-108
            SalaryD[23] = "   ";

            //國家 109-111
            SalaryD[24] = "   ";

            //城市 112-131
            SalaryD[25] = fFormatChar("", 20);

            //經費類別 132
            SalaryD[26] = "0";

            //俸額點數 133-135
            SalaryD[27] = "    ";

            //俸額折合率 137-144
            SalaryD[28] = "        ";

            //公費點數 145-148
            SalaryD[29] = "    ";

            //公費折合率 149-156
            SalaryD[30] = "        ";

            //身分證字號 2-5 碼 157-160
            SalaryD[31] = (fFormatChar(idno, 10)).Substring(1,4);

            //空白 161-180
            SalaryD[32] = fFormatChar("", 20);

            for (int i = 1; i <= 32; i++)
            {
                rv = rv + SalaryD[i];
            }
            return rv;
    }

    //組"B"類表別字串
    protected string fGetTabBStr(string tabid, string idno, string org_l1, string org_l2, string ptb, string dcode, string amt
        , string kind, string type, string qty)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

            //支薪機關 1-10        
            SalaryD[1] = fFormatChar(strOrgCode, 10);

            //資料年月 11-15
            SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

            //待遇表別代碼 16-25
            SalaryD[3] = fFormatChar(tabid, 10);

            //身分證字號後五碼 26-30
            string idnum = fFormatChar(idno, 10);
            SalaryD[4] = idnum.Substring(idnum.Length -5);

            //官職等代碼 31-33
            SalaryD[5] = fFormatChar(org_l1, 3);

            if (SalaryD[5] =="")
            {
                SalaryD[5] = "001";
            }

            //俸級代碼 34-36
            SalaryD[6] = fFormatChar(org_l2, 3);

            //薪(俸)點 37-40
            SalaryD[7] = fFormatChar(ptb, 4);

            //職稱代碼 41-44
            SalaryD[8] = fFormatChar(dcode, 4);

            //折合率 45-52
            SalaryD[9] = "        ";

            //定位點 53
            SalaryD[10] = "+";

            //身分證字號首碼 54
            SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

            //支領數額 55-62
            SalaryD[12] = fFormatNumber(amt, 8, 0);

            //待遇表別─類別 63-64
            if (tabid.ToString() == "B2005")
            {
                SalaryD[13] = SALARY.Logic.pub.lpad(kind, 2, "0").ToString();                
            }
            else
            {
                SalaryD[13] = fFormatChar(type, 2);
            }

            //天(時、人、月)數 65-69
            SalaryD[14] = "     ";

            //服務地區 70-71
            SalaryD[15] = "  ";

            //班別 72-73
            SalaryD[16] = "  ";

            //親屬 74-75
            SalaryD[17] = "  ";

            //俸額 76-81
            SalaryD[18] = "      ";

            //公費 2-87
            SalaryD[19] = "      ";

            //待遇差額 88-93
            SalaryD[20] = "      ";

            //補發金額 94-99
            SalaryD[21] = "      ";

            //增支 100-105
            if (tabid.ToString() == "B1224")
            {
                SalaryD[22] = fFormatNumber(qty, 6, 0);
            }
            else
            {
                SalaryD[22] = "000000";
            }

            //幣別 106-108
            SalaryD[23] = "   ";

            //國家 109-111
            SalaryD[24] = "   ";

            //城市 112-131
            SalaryD[25] = fFormatChar("", 20);

            //經費類別 132
            SalaryD[26] = "0";

            //俸額點數 133-135
            SalaryD[27] = "    ";

            //俸額折合率 137-144
            SalaryD[28] = "        ";

            //公費點數 145-148
            SalaryD[29] = "    ";

            //公費折合率 149-156
            SalaryD[30] = "        ";

            //身分證字號 2-5 碼 157-160
            SalaryD[31] =(fFormatChar(idno, 10)).Substring(1,4);

            //空白 161-180
            SalaryD[32] = fFormatChar("", 20);

            for (int i = 1; i <= 32; i++)
            {
                rv = rv + SalaryD[i];
            }

            return rv;
    }

    //組"C"類表別字串
    protected string fGetTabCStr(string tabid, string idno, string org_l1, string ptb, string amt, string type)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

            //支薪機關 1-10        
            SalaryD[1] = fFormatChar(strOrgCode, 10);

            //資料年月 11-15
            SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

            //待遇表別代碼 16-25
            SalaryD[3] = fFormatChar(tabid, 10);

            //身分證字號後五碼 26-30
           string idnum = fFormatChar(idno, 10);
           SalaryD[4] = idnum.Substring(idnum.Length - 5);

            //官職等代碼 31-33
            SalaryD[5] = fFormatChar(org_l1, 3);

            //俸級代碼 34-36
            SalaryD[6] = fFormatChar("", 3);

            //薪(俸)點 37-40
            if (tabid == "C1002")
            {
                SalaryD[7] = fFormatChar(ptb, 4);
            }
            else
            {
                SalaryD[7] = fFormatChar("", 4);
            }

            //職稱代碼 41-44
            if (tabid == "C2009")
            {
                SalaryD[8] = fFormatChar("", 4);
            }
            else
            {
                SalaryD[8] = fFormatChar("", 4);
            }
                //折合率 45-52                    
                SalaryD[9] = "        ";

                //定位點 53
                SalaryD[10] = "+";

                //身分證字號首碼 54
                SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);
        
                //支領數額 55-62
                SalaryD[12] = fFormatNumber(amt, 8, 0);

                //待遇表別─類別 63-64
                if (((tabid == "C1010") || (tabid == "C1011")))
                {
                    SalaryD[13] = fFormatNumber(type, 2, 0);
                }
                else if (tabid != "C1001" && tabid != "C1002" && tabid != "C1003" && tabid != "C1004")
                {
                    SalaryD[13] = fFormatChar(type, 2);
                }
                else
                {
                    SalaryD[13] = "  ";
                }

                if (tabid == "C2015")
                {
                    if (amt == "8435")
                    {
                        SalaryD[13] = "01";
                    }
                    else if (amt == "7590")
                    {
                        SalaryD[13] = "02";
                    }
                    else if (amt == "6745")
                    {
                        SalaryD[13] = "03";
                    }
                    else if (amt == "13496")
                    {
                        SalaryD[13] = "04";
                    }
                    else if (amt == "12144")
                    {
                        SalaryD[13] = "05";
                    }
                    else if (amt == "10792")
                    {
                        SalaryD[13] = "06";
                    }
                    else
                    {
                        SalaryD[13] = "  ";
                    }
                }
                    //天(時、人、月)數 65-69                
                    SalaryD[14] = "     ";

                    //服務地區 70-71
                    SalaryD[15] = "  ";

                    //班別 72-73
                    SalaryD[16] = "  ";

                    //親屬 74-75
                    SalaryD[17] = "  ";

                    //俸額 76-81
                    SalaryD[18] = "      ";

                    //公費 2-87
                    SalaryD[19] = "      ";

                    //待遇差額 88-93
                    SalaryD[20] = "      ";

                    //補發金額 94-99
                    SalaryD[21] = "      ";

                    //增支 100-105
                    SalaryD[22] = "000000";

                    //幣別 106-108
                    SalaryD[23] = "   ";

                    //國家 109-111
                    SalaryD[24] = "   ";

                    //城市 112-131
                    SalaryD[25] = fFormatChar("", 20);

                    //經費類別 132
                    SalaryD[26] = "0";

                    //俸額點數 133-135
                    SalaryD[27] = "    ";

                    //俸額折合率 137-144
                    SalaryD[28] = "        ";

                    //公費點數 145-148
                    SalaryD[29] = "    ";

                    //公費折合率 149-156
                    SalaryD[30] = "        ";

                    //身分證字號 2-5 碼 157-160
                    SalaryD[31] = (fFormatChar(idno, 10)).Substring(1,4);

                    //空白 161-180
                    SalaryD[32] = fFormatChar("", 20);

                    for (int i = 1; i <= 32; i++)
                    {
                        rv = rv + SalaryD[i];
                    }

                    return rv;
    }

    //組"D"類表別字串
    protected string fGetTabDStr(string tabid, string idno, string org_l1, string amt)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

    //支薪機關 1-10
	SalaryD[1] = fFormatChar(strOrgCode, 10);

	//資料年月 11-15
	SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

	//待遇表別代碼 16-25
	SalaryD[3] = fFormatChar(tabid, 10);

	//身分證字號後五碼 26-30
    string idnum = fFormatChar(idno, 10);
    SalaryD[4] = idnum.Substring(idnum.Length - 5);

	//官職等代碼 31-33
	SalaryD[5] = fFormatChar(org_l1, 3);

	//俸級代碼 34-36
	SalaryD[6] = fFormatChar("", 3);

	//薪(俸)點 37-40
	SalaryD[7] = fFormatChar("", 4);

	//職稱代碼 41-44
	SalaryD[8] = fFormatChar("", 4);

	//折合率 45-52
	SalaryD[9] = "        ";

	//定位點 53
	SalaryD[10] = "+";

	//身分證字號首碼 54
	SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

	//支領數額 55-62
	SalaryD[12] = fFormatNumber(amt, 8, 0);

	//待遇表別─類別 63-64
	SalaryD[13] = fFormatChar("  ", 2);

	//天(時、人、月)數 65-69
	SalaryD[14] = "     ";

	//服務地區 70-71
	SalaryD[15] = "  ";

	//班別 72-73
	SalaryD[16] = "  ";

	//親屬 74-75
	SalaryD[17] = "  ";

	//俸額 76-81
	SalaryD[18] = "      ";

	//公費 2-87
	SalaryD[19] = "      ";

	//待遇差額 88-93
	SalaryD[20] = "      ";

	//補發金額 94-99
	SalaryD[21] = "      ";

	//增支 100-105
	SalaryD[22] = "000000";

	//幣別 106-108
	SalaryD[23] = "   ";

	//國家 109-111
	SalaryD[24] = "   ";

	//城市 112-131
	SalaryD[25] = fFormatChar("", 20);

	//經費類別 132
	SalaryD[26] = "0";

	//俸額點數 133-135
	SalaryD[27] = "    ";

	//俸額折合率 137-144
	SalaryD[28] = "        ";

	//公費點數 145-148
	SalaryD[29] = "    ";

	//公費折合率 149-156
	SalaryD[30] = "        ";

	//身分證字號 2-5 碼 157-160
	SalaryD[31] = (fFormatChar(idno, 10)).Substring(2,4);

	//空白 161-180
	SalaryD[32] = fFormatChar("", 20);

	for (int i = 1; i <= 32; i++) 
    {
		rv = rv + SalaryD[i];
	}

	return rv;

    }

    //組"E"類表別字串
    protected string fGetTabEStr(string tabid, string idno, string amt, string type, string qty, string kind, string vclass)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

            //支薪機關 1-10        
            SalaryD[1] = fFormatChar(strOrgCode, 10);

            //資料年月 11-15
            SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

            //待遇表別代碼 16-25
            SalaryD[3] = fFormatChar(tabid, 10);

            //身分證字號後五碼 26-30
            string idnum = fFormatChar(idno, 10);
            SalaryD[4] = idnum.Substring(idnum.Length - 5);           

            //官職等代碼 31-33
            SalaryD[5] = fFormatChar("", 3);

            //俸級代碼 34-36
            SalaryD[6] = fFormatChar("", 3);

            //薪(俸)點 37-40
            SalaryD[7] = fFormatChar("", 4);

            //職稱代碼 41-44
            SalaryD[8] = fFormatChar("", 4);

            //折合率 45-52
            SalaryD[9] = fFormatChar("", 8);

            //定位點 53
            SalaryD[10] = "+";

            //身分證字號首碼 54
            SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

            //支領數額 55-62
            SalaryD[12] = fFormatNumber(amt, 8, 0);

            //待遇表別─類別 63-64
            if (tabid == "E1001")
            {
                SalaryD[13] = fFormatChar(type, 2);
            }
            else
            {
                SalaryD[13] = "  ";
            }

            //天(時、人、月)數 65-69
            SalaryD[14] = fFormatNumber(qty, 5, 0);

            //服務地區 70-71
            SalaryD[15] = "  ";

            //班別 72-73
            if (tabid == "E1001")
            {
                SalaryD[16] = fFormatChar(vclass, 2);
            }
            else
            {
                SalaryD[16] = "  ";
            }

            //親屬 74-75
            if (tabid == "E0004")
            {
                SalaryD[17] = fFormatNumber(kind, 2, 0);
            }
            else
            {
                SalaryD[17] = "  ";
            }

            //俸額 76-81
            SalaryD[18] = "      ";

            //公費 2-87
            SalaryD[19] = "      ";

            //待遇差額 88-93
            SalaryD[20] = "      ";

            //補發金額 94-99
            SalaryD[21] = "      ";

            //增支 100-105
            SalaryD[22] = "000000";

            //幣別 106-108
            SalaryD[23] = "   ";

            //國家 109-111
            SalaryD[24] = "   ";

            //城市 112-131
            SalaryD[25] = fFormatChar("", 20);

            //經費類別 132
            SalaryD[26] = "0";

            //俸額點數 133-135
            SalaryD[27] = "    ";

            //俸額折合率 137-144
            SalaryD[28] = "        ";

            //公費點數 145-148
            SalaryD[29] = "    ";

            //公費折合率 149-156
            SalaryD[30] = "        ";

            //身分證字號 2-5 碼 157-160
            SalaryD[31] = (fFormatChar(idno, 10)).Substring(1,4);

            //空白 161-180
            SalaryD[32] = fFormatChar("", 20);

            for (int i = 1; i <= 32; i++)
            {
                rv = rv + SalaryD[i];
            }

            return rv;
    }

    //組"F"類表別字串
    protected string fGetTabFStr(string tabid, string idno, string org_l1, string dcode, string amt, string type, string qty)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

            //支薪機關 1-10                
            SalaryD[1] = fFormatChar(strOrgCode, 10);

            //資料年月 11-15
            SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

            //待遇表別代碼 16-25
            SalaryD[3] = fFormatChar(tabid, 10);

            //身分證字號後五碼 26-30
            string idnum = fFormatChar(idno, 10);
            SalaryD[4] = idnum.Substring(idnum.Length - 5);    

            //官職等代碼 31-33
            if (tabid == "F0003" | tabid == "F0034")
            {
                SalaryD[5] = fFormatChar(org_l1, 3);
            }
            else
            {
                SalaryD[5] = "   ";
            }

            //俸級代碼 34-36
            SalaryD[6] = "   ";

            //薪(俸)點 37-40
            SalaryD[7] = "    ";

            //職稱代碼 41-44
            SalaryD[8] = fFormatChar(dcode, 4);

            //折合率 45-52
            SalaryD[9] = "        ";

            //定位點 53
            SalaryD[10] = "+";

            //身分證字號首碼 54
            SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

            //支領數額 55-62
            SalaryD[12] = fFormatNumber(amt, 8, 0);

            //待遇表別─類別 63-64
            if (tabid == "F0045" || tabid == "F0046" || tabid == "F0047" || tabid == "F0048" || tabid == "F0053")
            {
                SalaryD[13] = fFormatChar(type, 2);
            }
            else
            {
                SalaryD[13] = fFormatChar("", 2);
            }

            //天(時、人、月)數 65-69
            if (tabid == "F0055-0")
            {
                SalaryD[14] = fFormatNumber(qty, 5, 0);
            }
            else
            {
                SalaryD[14] = "     ";
            }

            //服務地區 70-71
            SalaryD[15] = "  ";

            //班別 72-73
            SalaryD[16] = "  ";

            //親屬 74-75
            SalaryD[17] = "  ";

            //俸額 76-81
            SalaryD[18] = "      ";

            //公費 83-87
            SalaryD[19] = "      ";

            //待遇差額 88-93
            SalaryD[20] = "      ";

            //補發金額 94-99
            SalaryD[21] = "      ";

            //增支 100-105
            SalaryD[22] = "000000";

            //幣別 106-108
            SalaryD[23] = "   ";

            //國家 109-111
            SalaryD[24] = "   ";

            //城市 112-131
            SalaryD[25] = fFormatChar("", 20);

            //經費類別 132
            SalaryD[26] = "0";

            //俸額點數 133-135
            SalaryD[27] = "    ";

            //俸額折合率 137-144
            SalaryD[28] = "        ";

            //公費點數 145-148
            SalaryD[29] = "    ";

            //公費折合率 149-156
            SalaryD[30] = "        ";

            //身分證字號 2-5 碼 157-160
            SalaryD[31] = (fFormatChar(idno, 10)).Substring(1,4);

            //空白 161-180
            SalaryD[32] = fFormatChar("", 20);

            for (int i = 1; i <= 32; i++)
            {
                rv = rv + SalaryD[i];
            }

            return rv;
    }
 
    //組"G"類表別字串
    protected string fGetTabGStr(string tabid, string idno, string dcode, string amt)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

        //支薪機關 1-10
        SalaryD[1] = fFormatChar(strOrgCode, 10);

        //資料年月 11-15
        SalaryD[2] = fFormatNumber(Convert.ToString(Convert.ToInt32(v_YM) - 191100), 5, 0);

        //待遇表別代碼 16-25
        SalaryD[3] = fFormatChar(tabid, 10);

        //身分證字號後五碼 26-30
        string idnum = fFormatChar(idno, 10);
        SalaryD[4] = idnum.Substring(idnum.Length - 5);    

        //官職等代碼 31-33
        SalaryD[5] = "   ";

        //俸級代碼 34-36
        SalaryD[6] = "   ";

        //薪(俸)點 37-40
        SalaryD[7] = "    ";

        //職稱代碼 41-44
        SalaryD[8] = fFormatChar(dcode, 4);

        //折合率 45-52
        SalaryD[9] = "        ";

        //定位點 53
        SalaryD[10] = "+";

        //身分證字號首碼 54
        SalaryD[11] = (fFormatChar(idno, 10)).Substring(0,1);

        //支領數額 55-62
        SalaryD[12] = fFormatNumber(amt, 8, 0);

        //待遇表別─類別 63-64
        SalaryD[13] = fFormatChar("", 2);

        //天(時、人、月)數 65-69
        SalaryD[14] = "     ";

        //服務地區 70-71
        SalaryD[15] = "  ";

        //班別 72-73
        SalaryD[16] = "  ";

        //親屬 74-75
        SalaryD[17] = "  ";

        //俸額 76-81
        SalaryD[18] = "      ";

        //公費 83-87
        SalaryD[19] = "      ";

        //待遇差額 88-93
        SalaryD[20] = "      ";

        //補發金額 94-99
        SalaryD[21] = "      ";

        //增支 100-105
        SalaryD[22] = "000000";

        //幣別 106-108
        SalaryD[23] = "   ";

        //國家 109-111
        SalaryD[24] = "   ";

        //城市 112-131
        SalaryD[25] = fFormatChar("", 20);

        //經費類別 132
        SalaryD[26] = "0";

        //俸額點數 133-135
        SalaryD[27] = "    ";

        //俸額折合率 137-144
        SalaryD[28] = "        ";


        //公費點數 145-148
        SalaryD[29] = "    ";


        //公費折合率 149-156
        SalaryD[30] = "        ";


        //身分證字號 2-5 碼 157-160
        SalaryD[31] = (fFormatChar(idno, 10)).Substring(1,4);

        //空白 161-180
        SalaryD[32] = fFormatChar("", 20);

        for (int i = 1; i <= 32; i++)
        {
            rv = rv + SalaryD[i];
        }
        return rv;
    }

    //取得機關報送之表別字串
    protected string fGetOrgStr(string tabid, string amt)
    {
        string v_YM = TextBox_ym.Text;
        string[] SalaryD = new string[35];
        for (int i = 0; i <= 34; i++)
        {
            SalaryD[i] = "";
        }
        string rv = "";

        //'支薪機關 1-10
        SalaryD[1] = fFormatChar(strOrgCode, 10);

        //'資料年月 11-15
        SalaryD[2] = fFormatNumber((int.Parse(v_YM) - 191100).ToString(), 5, 0);

        //'待遇表別代碼 16-25
        SalaryD[3] = fFormatChar(tabid, 10);

        //'身分證字號後五碼 26-30 (機關費用使用機關代碼)
        string idnum = fFormatChar(strOrgCode, 10);
        SalaryD[4] = idnum.Substring(idnum.Length-5);

        //'官職等代碼 31-33
        SalaryD[5] = fFormatChar("", 3);

         // '俸級代碼 34-36
        SalaryD[6] = fFormatChar("", 3);

        //'薪(俸)點 37-40
        SalaryD[7] = fFormatChar("", 4);

        //'職稱代碼 41-44
        SalaryD[8] = fFormatChar("", 4);

        //'折合率 45-52
        SalaryD[9] = "        ";

        //'定位點 53
        SalaryD[10] = "+";

        //身分證字號首碼 54  (機關費用使用機關代碼)
        SalaryD[11] = (fFormatChar(strOrgCode, 10)).Substring(0,1);

        //支領數額 55-62
        SalaryD[12] = fFormatNumber(amt, 8, 0);

        //待遇表別─類別 63-64
        SalaryD[13] = fFormatChar("  ", 2);

        //天(時、人、月)數 65-69
        SalaryD[14] = "     ";

        //服務地區 70-71
        SalaryD[15] = "  ";

        //班別 72-73
        SalaryD[16] = "  ";

        //親屬 74-75
        SalaryD[17] = "  ";

        //俸額 76-81
        SalaryD[18] = "      ";

        //公費 2-87
        SalaryD[19] = "      ";

        //待遇差額 88-93
        SalaryD[20] = "      ";

        //'補發金額 94-99
        SalaryD[21] = "      ";

        //'增支 100-105
        SalaryD[22] = "000000";

        //'幣別 106-108
        SalaryD[23] = "   ";

        //'國家 109-111
        SalaryD[24] = "   ";

        //'城市 112-131
        SalaryD[25] = fFormatChar("", 20);

        //'經費類別 132
        SalaryD[26] = "0";

        //'俸額點數 133-135
        SalaryD[27] = "    ";

        //'俸額折合率 137-144
        SalaryD[28] = "        ";

        //'公費點數 145-148
        SalaryD[29] = "    ";

        //'公費折合率 149-156
        SalaryD[30] = "        ";

        // '身分證字號 2-5 碼 157-160 (機關費用使用機關代碼)
        SalaryD[31] = (fFormatChar(strOrgCode, 10)).Substring(1,4);

        //空白 161-180
        SalaryD[32] = fFormatChar("", 20);

        for (int i = 1; i <= 32; i++)
        {
            rv = rv + SalaryD[i];
        }

        return rv;
    }
    
    //格式化字串
    protected string fFormatChar(string pStr, int pLen)
    {
        int iRLen = 0;
        // 因vb script 將中文字長度算為1, iRLen 為真正字串長度(中文字長度算為 2 bytes)
        //******************************
        // 非標準 Big5 碼以全形＊表示
        // 因非標準 Big5 碼會顯示成類似
        // "&#32137;"，所以遇到"&"以"＊"
        // 表示並連取8碼(追加7碼)
        //******************************

        //If IsNull(pStr) Then
        //    pStr = ""
        //End If

        for (int i = 0; i < pStr.Length; i++)
        {
            string spStr =pStr;
           
            if (spStr.Substring(i, 1) == "&")
            {
                pStr = spStr.Substring(0, i - 1) + "＊" + spStr.Substring(pStr.Length - 7);
                i = i + 7;
            }
        }
      
        for (int i = 0; i <pStr.Length; i++)
        {
            //************************
            // 判斷是否中文字
            // if ASC > 255 表中文字
            //************************          

            if ((Convert.ToInt32(pStr[i])) <= 0 || (Convert.ToInt32(pStr[i])) >= 255)
            {
                iRLen = iRLen + 2;
                // 若為中文字，每字長度加2
            }
            else
            {
                iRLen = iRLen + 1;
                // 若為英文字，每字長度加1
            }
        }

      /*  string str="A";
        int a = Convert.ToInt32(str[0]);
        Response.Write(a + "<br>");
      */
        //補空白
        while (iRLen < pLen)
        {
            pStr = pStr + " ";
            iRLen = iRLen + 1;
        }
        if (iRLen > pLen)
        {
            pStr =pStr.Substring(0,pLen);
        }      
 
        return pStr;
    }

    //格式化數字欄位
    protected string fFormatNumber(string pStr, int pLen, int pSLen)
    {
             //判斷是否須小數位       
            if (pSLen > 0)
            {
                if (pStr.IndexOf(".") > 0)
                {
                    if (pStr.Length == pStr.IndexOf("."))
                    {
                        pStr = pStr + "0";
                        
                    }
                    else if (pStr.Length - pStr.IndexOf(".") > pSLen)// 若小數位> 需要位數則四捨五入
                    {
                        pStr = Math.Round(Double.Parse(pStr), pSLen).ToString();
                    }
                }
                else
                {
                    pStr = pStr + ".";
                    for (int j = 1; j <= pSLen; j++)
                    {
                        pStr = pStr + "0";
                    }
                }
            }

            //數字長度不足左補0
            int K = 0;

            while( pStr.Length < pLen)
            {
                K = K + 1;        
                pStr = "0" + pStr;
            }

            if (pStr.Length > pLen)
            {
                pStr =pStr.Substring(0,pLen);
            }

            return pStr;  
    }


    protected void ExportFile()
    {
        try
        {
            StringBuilder s = new StringBuilder();
            s.Append(Label_download.Text);
            Label_download.Text = s.ToString();

            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            string oExcelFileName = TextBox_filename.Text;

            Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");

            Context.Response.ContentType = "application/plain";
            Context.Response.AddHeader("Content-Disposition", "attachment;filename=" + oExcelFileName);
            plExport1.RenderControl(oHtmlTextWriter);
            
            Context.Response.Write(s.ToString());
            Context.Response.End();        
  
        /*     string fileName = "年度所得清冊.xls"; //下載檔名
            fileName = Server.UrlPathEncode(fileName); //中文檔名編譯
            //下載檔案  
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName); 
            Response.ContentType = "application/vnd.ms-excel";    //application/octet-stream  
            Response.WriteFile(pathFile);
            Response.End();
        */
        }
        catch (Exception ex)
        {
        }
    }

    //轉檔及下載button
    protected void btnReport_Click(object sender, EventArgs e)
    {      
        if (checkdata())
        {
             //  更新 SAUPUNIT
            Update_SAUPUNIT();

            //  更新 SAUPEMP (機關費用)
            Update_SAUPEMP();         

            // 開始組表頭
            get_file_str();

            ExportFile();
        }           
    }

    protected bool checkdata()
    {
        bool rv = true;       

        if (TextBox_cname.Text == "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請填入連絡人姓名", "", "");
            this.Page = tempPage;

            rv = false;
        }
        if (TextBox_cemail.Text =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請填入連絡人E-mail", "", "");
            this.Page = tempPage;
          
            rv = false;
        }
        if (vTabID() =="")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "請勾選表別", "", "");
            this.Page = tempPage;
                      
            rv = false;
        }  
        
        return rv;
    }

    protected string vTabID()
    {
        string rv = "";

        for( int i=0 ; i < GridView_Uporg.Rows.Count ; i++)
        {
          CheckBox ck =  (CheckBox)GridView_Uporg.Rows[i].Cells[1].FindControl("CheckBox_chk");
            if (ck.Checked)
            {             
                if (rv=="")
                {
                    Label tab = (Label)GridView_Uporg.Rows[i].Cells[2].FindControl("Label_tabid");

                    rv += "'" + tab.Text + "'";                 
                }
                else
                {
                    Label tab = (Label)GridView_Uporg.Rows[i].Cells[2].FindControl("Label_tabid");

                    rv += ", '" + tab.Text + "'";
                }
            }
        }    
     
        return rv;
    }


    //維護button
    protected void GridView_Uporg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "doupdate") //維護button
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Label lb = (Label)GridView_Uporg.Rows[index].Cells[2].FindControl("Label_tabid");
            string vTabID = lb.Text;// GridView_Uporg.Rows[index].Cells[6].ToString();
            string vTabID2 = vTabID;
            string url = "";
            try
            {
                switch (vTabID2.Substring(0, 1))
                {
                    case "A":
                        url = "SAL3122_02.aspx";
                        break;
                    case "B":
                        url = "SAL3122_03.aspx";
                        break;
                    case "C":
                        url = "SAL3122_04.aspx";
                        break;
                    case "D":
                        url = "SAL3122_05.aspx";
                        break;
                    case "E":
                        url = "SAL3122_06.aspx";
                        break;
                    case "F":
                        url = "SAL3122_07.aspx";
                        break;
                    case "G":
                        url = "SAL3122_08.aspx";
                        break;
                }

                url += "?tabid=" + vTabID;
                url += "&ym=" + TextBox_ym.Text;
         //       url += "&btn=" +this.Button_reload.ClientID;
                Response.Redirect(url);   
            }
            catch
            {
            }
        }
    }
    protected void GridView_Uporg_PageIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView_Uporg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {       
        GridView_Uporg.PageIndex = e.NewPageIndex; 
        Get_SQLs1();     
    }
    protected void GridView_Uporg_DataBinding(object sender, EventArgs e)
    {

     

    }
    protected void GridView_Uporg_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Uporg.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView_Uporg.Rows[i].Cells[1].FindControl("CheckBox_chk");
            Label lbcnt = (Label)GridView_Uporg.Rows[i].Cells[4].FindControl("Label_TotCnt");
            if (lbcnt.Text == "0")
            {
                cb.Checked = false;
            }
            else
            {
                cb.Checked = true;
            }
            Button btnupdate = (Button)GridView_Uporg.Rows[i].Cells[5].FindControl("update");
            Label lbytpe = (Label)GridView_Uporg.Rows[i].Cells[2].FindControl("Label_tabtype");
            if (lbytpe.Text != "個人")
            {
                btnupdate.Visible = false;
            }
            else
            {
                btnupdate.Visible = true;
            }
            Panel pnl = (Panel)GridView_Uporg.Rows[i].Cells[5].FindControl("Panel1");
            if (lbytpe.Text != "機關")
            {
                pnl.Visible = false;
            }
            else
            {
                pnl.Visible = true;
            }

        }
    }
}