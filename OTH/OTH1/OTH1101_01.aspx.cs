using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OTH.Logic;
using System.Data;

// 2014.7.19 Eliot Chen
// 清空重填後 Enable 送出申請

public partial class OTH_OTH1_OTH1101_01 : BaseWebForm
{
    OTH1101 dao = new OTH1101();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 【清空重填】按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        ucbroadcast_floors.CheckAll(false);

        MasterPage mp = this.Master;
        CommonFun.ClearContentPlaceHolder(ref mp);
        // 2014/7/19 Eliot Chen
        DoneBtn.Enabled = true;
    }

    private void Bind(string broadcast_date1, string broadcast_time1, string broadcast_date2, string broadcast_time2,
            string broadcast_floors, string broadcast_content)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("broadcast_dt"));
        dt.Columns.Add(new DataColumn("broadcast_floors"));
        dt.Columns.Add(new DataColumn("broadcast_content"));

        string broadcast_floorsName = string.Empty;

        foreach (string item in broadcast_floors.Split(','))
        {
            broadcast_floorsName += dao.saDAO.GetCodeDesc("022", "001", item) + ",";
        }

        broadcast_floorsName = broadcast_floorsName.TrimEnd(','); 

        DataRow dr = dt.NewRow();
        dr["broadcast_dt"] = broadcast_date1 + " " + broadcast_time1;
        dr["broadcast_floors"] = broadcast_floorsName;
        dr["broadcast_content"] = broadcast_content;
        dt.Rows.Add(dr);

        if (string.IsNullOrEmpty(broadcast_date2) && string.IsNullOrEmpty(broadcast_time2))
        {
            dr = dt.NewRow();
            dr["broadcast_dt"] = broadcast_date2 + " " + broadcast_time2;
            dr["broadcast_floors"] = broadcast_floorsName;
            dr["broadcast_content"] = broadcast_content;
            dt.Rows.Add(dr);
        } 

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
    }

    /// <summary>
    /// 【送出申請】按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DoneBtn_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;

        if (string.IsNullOrEmpty(this.ucbroadcast_date1.Text))
        {
            msg += @"請輸入第一次廣播日期\n";
        }
        if (string.IsNullOrEmpty(this.ucbroadcast_date1.Time))
        {
            msg += @"請輸入第一次廣播時間\n";
        }
        if (string.IsNullOrEmpty(this.txtbroadcast_content.Text))
        {
            msg += @"請輸入廣播內容\n";
        }

        string[] floors = ucbroadcast_floors.SelectedValue.Split(';');
        if (ucbroadcast_floors.SelectedValue=="" || floors.Length <= 0)
        {
            msg += @"請選擇廣播系統開放樓層\n";
        }

        Page page = this.Page;

        if (string.IsNullOrEmpty(msg))
        {
            msg = dao.Done(this.ucbroadcast_date1.Text, this.ucbroadcast_date1.Time, this.ucbroadcast_date2.Text, this.ucbroadcast_date2.Time, ucbroadcast_floors.SelectedValue.Replace(";",","), txtbroadcast_content.Text);

            if (string.IsNullOrEmpty(msg))
            {
                CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, @msg, "", "");

                DoneBtn.Enabled = false;
                Bind(this.ucbroadcast_date1.Text, this.ucbroadcast_date1.Time, this.ucbroadcast_date2.Text, this.ucbroadcast_date2.Time,
                ucbroadcast_floors.SelectedValue.Replace(";", ","), txtbroadcast_content.Text);

                CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, "申請完成", "", "");
            }
            else
            {
                CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, msg, "", "");
            }
        }
        else
        {
            CommonFun.MsgShow(ref page, CommonFun.Msg.Custom, msg, "", "");
        }
    }
}