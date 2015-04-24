/*
 * 2014/3/18
 * ted
 * 年度所得清冊
 */
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
using System.Drawing;
using System.Collections;
using System.IO;
using System.Net;
using System.Configuration;

public partial class SAL_SAL2_SAL2115 : BaseWebForm
{
    private string strOrgCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        if (Page.IsPostBack) return;

        ddl_Budget_code.Orgid = strOrgCode;

        //年份,民國=西元-1911,增加今年-2至今年+1年 
        string Year = DateTime.Now.ToString("yyyy");
        DropDownList_Year.Items.Clear();
        DropDownList_Year.Items.Add((int.Parse(Year) - 1913).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1912).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1911).ToString());
        DropDownList_Year.Items.Add((int.Parse(Year) - 1910).ToString());
        DropDownList_Year.SelectedIndex = 2;
        DropDownList_Month.SelectedIndex = DateTime.Now.Month;


    }

    // 列印按鈕
    protected void Button_report_Click(object sender, EventArgs e)
    {
        ExportReport();
    }


    // 製作報表
    private void ExportReport()
    {
        SAL2115 sal2115 = new SAL2115();
        //登入者機關代碼
        string strOrgCode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
        //年份(西元+1911)
        string strYearSelected = (int.Parse(DropDownList_Year.SelectedValue) + 1911).ToString();
        //月份
        string strMonthSelected = DropDownList_Month.SelectedValue.ToString();
        //單位別
        string strUnit = ddltype.OrgCode;
        //員工姓名
        string strName = txtName.Text;
        //人員類別
        string strtype = ucSaCode.SelectedValue;
        //員工編號
        string strNum = txtNum.Text;

        string strPayBudgeCode = ddl_Budget_code.SelectedValue; //預算來源代碼


        //第一階層查詢出列印之人員清單            //年,月,單位別,員工姓名,人員類別,員工編號,登入者機關代碼
        DataTable datat = sal2115.queryReportData(strYearSelected, strMonthSelected, strUnit, strName, strtype, strNum, strOrgCode, strPayBudgeCode);

        if (datat == null || datat.Rows.Count == 0)
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage,
               CommonFun.Msg.Custom, "查無資料", "", "");
            this.Page = tempPage;

            return;
        }

        //第二階層再依照第一層人員逐項查詢。
        if (datat != null && datat.Rows.Count > 0)
        {
         
            //製作excel
            Excel.Application excelApp;
            Excel._Workbook wBook;
            Excel._Worksheet wSheet;
            Excel.Range wRange;
            // 開啟一個新的應用程式
            excelApp = new Excel.Application();
            // 讓Excel文件可見
            excelApp.Visible = false;
            // 停用警告訊息
            excelApp.DisplayAlerts = false;
            // 加入新的活頁簿
            excelApp.Workbooks.Add(Type.Missing);
            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            // 設定活頁簿焦點
            wBook.Activate();

            if (ddlsort.SelectedValue == "0") //連續印
            {
                // 引用第一個工作表
                wSheet = (Excel._Worksheet)wBook.Worksheets[1];
                // 命名工作表的名稱
                // wSheet.Name = "年度所得清冊";
                // 設定工作表焦點
                wSheet.Activate();

                // 第1列資料         
                excelApp.Cells[1, 1] = "年度所得清冊";
                wRange = wSheet.get_Range(wSheet.Cells[1, 1], wSheet.Cells[1, 6]);
                wRange.Select();
                wRange.Font.Size = 20;//字體大小
                wRange.Merge(false); //設定儲存格合併
                wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //儲存格置中
                // 第2列資料
                excelApp.Cells[2, 5] = "印表日期:";
                excelApp.Cells[2, 6] = "民國" + (int.Parse(DateTime.Now.ToString("yyyy")) - 1911) + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日";
               
                //報表最後統計分類的格式代號陣列
                ArrayList INCO_ICODE = new ArrayList();
                //列數
                int r = 3;
                for (int i = 0; i < datat.Rows.Count; i++) //每個人員
                {
                    // (第3列)datat 人員資料
                 
                    excelApp.Cells[r, 1] = datat.Rows[i]["BASE_NAME"].ToString() + " " + datat.Rows[i]["BASE_IDNO"].ToString();
                    wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                    wRange.Select();
                    wRange.Merge(false);//設定儲存格合併
                    r += 1;

                    // (第4列)data2 title
                    excelApp.Cells[r, 1] = "所得項目";
                    excelApp.Cells[r, 2] = "所得格式";
                    excelApp.Cells[r, 3] = "給付日期";
                    excelApp.Cells[r, 4] = "應發金額";
                    excelApp.Cells[r, 5] = "申報金額";
                    excelApp.Cells[r, 6] = "扣繳稅額";
                    wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                    wRange.Select();
                    wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //儲存格置中
                    r += 1;
                                    

                    string BASE_SEQNO = datat.Rows[i]["BASE_SEQNO"].ToString();
                    //年,月,登入者機關代碼,列印之人員代碼
                    DataTable datat2 = new DataTable();
                    datat2 = sal2115.queryReportData2(strYearSelected, strMonthSelected, strOrgCode, BASE_SEQNO, strPayBudgeCode);
                    //人員資料
                                      

                    if (datat2 != null && datat2.Rows.Count > 0)
                    {
                        for (int j = 0; j < datat2.Rows.Count; j++)
                        {                          
                                //(第5.6.7...) data2 逐筆資料
                                excelApp.Cells[r, 1] = datat2.Rows[j]["INCO_ITEM"].ToString();
                                excelApp.Cells[r, 2] = datat2.Rows[j]["INCO_KIND"].ToString();
                                excelApp.Cells[r, 3] = datat2.Rows[j]["INCO_DATE"].ToString();
                                if (datat2.Rows[j]["PAYOD_AMT"].ToString() != "0")
                                {
                                    excelApp.Cells[r, 4] = datat2.Rows[j]["PAYOD_AMT"].ToString();
                                }
                                else //若應發金額(一)金額為0，則改用應發金額(二)之金額
                                {
                                    excelApp.Cells[r, 4] = datat2.Rows[j]["INCO_REAL_AMT"].ToString();
                                }
                                excelApp.Cells[r, 5] = datat2.Rows[j]["INCO_AMT"].ToString();
                                excelApp.Cells[r, 6] = datat2.Rows[j]["INCO_TXAM"].ToString();
                                                                                          

                                //報表最後統計分類用
                                int add = 0;
                                if (j == 0) //每個人的第一個值比對
                                {
                                    if (INCO_ICODE.Count > 0)
                                    {
                                        for (int q = 0; q < INCO_ICODE.Count; q++)
                                        {
                                            if (INCO_ICODE[q].ToString() == datat2.Rows[j]["INCO_KIND"].ToString())
                                            {
                                                add = 0;
                                                break;
                                            }
                                            else
                                            { add = 1; }
                                        }
                                    }
                                    else
                                    {
                                        INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());//第一個人的第一筆先新增     
                                     
                                    }
                                }
                                if (add == 1)
                                {
                                    INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());
                                }
                            
                                //比對全部的值
                                add = 0;
                                for (int q = 0; q < INCO_ICODE.Count; q++)
                                {
                                  
                                    if (INCO_ICODE[q].ToString().Trim() == datat2.Rows[j]["INCO_KIND"].ToString().Trim())
                                    {                                       
                                        add = 0;                                 
                                        break;
                                    }
                                    else
                                    {                           
                                        add = 1;
                                    }
                                }
                                if (add == 1)
                                {
                                    INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());
                                }                               
                                                         
                                r += 1;

                             
                         
                        }
                     
                        //小計
                        excelApp.Cells[r, 1] = "小計";
                        excelApp.Cells[r, 2] = "-";
                        excelApp.Cells[r, 3] = "-";
                        wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 3]);
                        wRange.Select();
                        wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //儲存格置中
                        //設定總和公式
                        excelApp.Cells[r, 4] = string.Format("=SUM(D{0}:D{1})", r - datat2.Rows.Count, r - 1); //第一列資料到最後一列資料總和
                        excelApp.Cells[r, 5] = string.Format("=SUM(E{0}:E{1})", r - datat2.Rows.Count, r - 1);
                        excelApp.Cells[r, 6] = string.Format("=SUM(F{0}:F{1})", r - datat2.Rows.Count, r - 1);
                        //row - 資料筆數 - title,name
                        wRange = wSheet.get_Range(wSheet.Cells[(r - datat2.Rows.Count - 2), 1], wSheet.Cells[r, 6]);
                        wRange.Select();
                        wRange.Borders.Weight = Excel.XlBorderWeight.xlThin; //設定框線
                     
                        r += 2;//空一列    
     
                      
                    }
               
                }

                //最後總計分類
                int count; //件數
                int count2;//給付金額
                int count3;//申報金額
                int count4;//扣繳稅額              

                excelApp.Cells[r, 1] = "所得項目";
                excelApp.Cells[r, 2] = "所得格式";
                excelApp.Cells[r, 3] = "件數";
                excelApp.Cells[r, 4] = "給付金額";
                excelApp.Cells[r, 5] = "申報金額";
                excelApp.Cells[r, 6] = "扣繳稅額";
                wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                r += 1;
                for (int q = 0; q < INCO_ICODE.Count; q++) //所得格式
                {
                    count = 0;
                    count2 = 0;
                    count3 = 0;
                    count4 = 0;
                    excelApp.Cells[r, 2] = INCO_ICODE[q];
                    for (int i = 0; i < datat.Rows.Count; i++) //人員清單
                    {
                        string BASE_SEQNO = datat.Rows[i]["BASE_SEQNO"].ToString();
                        //年,月,登入者機關代碼,列印之人員代碼
                        DataTable datat2 = new DataTable();
                        datat2 = sal2115.queryReportData2(strYearSelected, strMonthSelected, strOrgCode, BASE_SEQNO, strPayBudgeCode);

                        for (int j = 0; j < datat2.Rows.Count; j++) //人員資料
                        {
                            if (INCO_ICODE[q].ToString().Trim() == datat2.Rows[j]["INCO_KIND"].ToString().Trim())
                            {
                                count++;
                                if (datat2.Rows[j]["PAYOD_AMT"].ToString() != "0")
                                {
                                    count2 += (int)Convert.ToDouble(datat2.Rows[j]["PAYOD_AMT"]);
                                }
                                else //若應發金額(一)金額為0，則改用應發金額(二)之金額
                                {
                                    count2 += int.Parse(datat2.Rows[j]["INCO_REAL_AMT"].ToString());
                                }
                                count3 += int.Parse(datat2.Rows[j]["INCO_AMT"].ToString());
                                count4 += int.Parse(datat2.Rows[j]["INCO_TXAM"].ToString());
                            }
                        }
                    }
                    excelApp.Cells[r, 3] = count;
                    excelApp.Cells[r, 4] = count2;
                    excelApp.Cells[r, 5] = count3;
                    excelApp.Cells[r, 6] = count4;
                    r += 1;
                }
              
                //單位總計
                excelApp.Cells[r, 1] = "單位總計";
                wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 1]);
                wRange.Select();
                wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                // 設定總和公式 
                excelApp.Cells[r, 3] = string.Format("=SUM(C{0}:C{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 4] = string.Format("=SUM(D{0}:D{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 5] = string.Format("=SUM(E{0}:E{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 6] = string.Format("=SUM(F{0}:F{1})", r - INCO_ICODE.Count, r - 1);
                //row -count - title                 
                wRange = wSheet.get_Range(wSheet.Cells[r - INCO_ICODE.Count - 1, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.Borders.Weight = Excel.XlBorderWeight.xlThin; //框線

                // 自動調整欄寬
                wRange = wSheet.get_Range(wSheet.Cells[1, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.Columns.AutoFit();

            }
            else //一人一頁
            {
                ArrayList INCO_ICODE = new ArrayList();//最後分類格式代號用的陣列
                int r = 0; //列數
                for (int i = 3; i < datat.Rows.Count; i++)
                {
                    wBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing); //3個sheet以上需add
                }
                for (int i = 0; i < datat.Rows.Count; i++)
                {
                    // 引用第一個工作表
                    wSheet = (Excel._Worksheet)wBook.Worksheets[i + 1];
                    // 命名工作表的名稱  (人員名稱)
                    wSheet.Name = datat.Rows[i]["BASE_NAME"].ToString() + datat.Rows[i]["BASE_seqno"].ToString();
                    // 設定工作表焦點
                    wSheet.Activate();
                    // 第1列資料         
                    excelApp.Cells[1, 1] = "年度所得清冊";
                    wRange = wSheet.get_Range(wSheet.Cells[1, 1], wSheet.Cells[1, 6]);
                    wRange.Select();
                    wRange.Font.Size = 20;
                    wRange.Merge(false); //設定儲存格合併
                    wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                    // 第2列資料
                    excelApp.Cells[2, 5] = "印表日期:";
                    excelApp.Cells[2, 6] = "民國" + (int.Parse(DateTime.Now.ToString("yyyy")) - 1911) + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日";
                    //列數
                    r = 3;
                    // (第3列)datat 人員資料
                    excelApp.Cells[r, 1] = datat.Rows[i]["BASE_NAME"].ToString() + " " + datat.Rows[i]["BASE_IDNO"].ToString();
                    wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                    wRange.Select();
                    wRange.Merge(false);//設定儲存格合併
                    r += 1;

                    // (第4列)data2 title
                    excelApp.Cells[r, 1] = "所得項目";
                    excelApp.Cells[r, 2] = "所得格式";
                    excelApp.Cells[r, 3] = "給付日期";
                    excelApp.Cells[r, 4] = "應發金額";
                    excelApp.Cells[r, 5] = "申報金額";
                    excelApp.Cells[r, 6] = "扣繳稅額";
                    wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                    wRange.Select();
                    wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                    r += 1;

                    string BASE_SEQNO = datat.Rows[i]["BASE_SEQNO"].ToString();
                    //年,月,登入者機關代碼,列印之人員
                    DataTable datat2 = new DataTable();
                    datat2 = sal2115.queryReportData2(strYearSelected, strMonthSelected, strOrgCode, BASE_SEQNO,strPayBudgeCode);
                    //人員資料
                    if (datat2 != null && datat2.Rows.Count > 0)
                    {
                        for (int j = 0; j < datat2.Rows.Count; j++)
                        {
                            try
                            {
                                //(第5.6.7...) data2 逐筆資料
                                excelApp.Cells[r, 1] = datat2.Rows[j]["INCO_ITEM"].ToString();
                                excelApp.Cells[r, 2] = datat2.Rows[j]["INCO_KIND"].ToString();
                                excelApp.Cells[r, 3] = datat2.Rows[j]["INCO_DATE"].ToString();
                                if (datat2.Rows[j]["PAYOD_AMT"].ToString() != "0")
                                {
                                    excelApp.Cells[r, 4] = datat2.Rows[j]["PAYOD_AMT"].ToString();
                                }
                                else //若應發金額(一)金額為0，則改用應發金額(二)之金額
                                {
                                    excelApp.Cells[r, 4] = datat2.Rows[j]["INCO_REAL_AMT"].ToString();
                                }
                                excelApp.Cells[r, 5] = datat2.Rows[j]["INCO_AMT"].ToString();
                                excelApp.Cells[r, 6] = datat2.Rows[j]["INCO_TXAM"].ToString();

                                //報表最後統計分類用
                                int add = 0;
                                if (j == 0) //每個人的第一個值比對
                                {
                                    if (INCO_ICODE.Count > 0)
                                    {
                                        for (int q = 0; q < INCO_ICODE.Count; q++)
                                        {
                                            if (INCO_ICODE[q].ToString().Trim() == datat2.Rows[j]["INCO_KIND"].ToString().Trim())
                                            {
                                                add = 0;
                                                break;
                                            }
                                            else
                                            { add = 1; }
                                        }
                                    }
                                    else
                                    {
                                        INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());//第一個人的第一筆先新增
                                    }
                                }
                                if (add == 1)
                                {
                                    INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());
                                }
                                //比對全部的值
                                add = 0;
                                for (int q = 0; q < INCO_ICODE.Count; q++)
                                {
                                    if (INCO_ICODE[q].ToString().Trim() == datat2.Rows[j]["INCO_KIND"].ToString().Trim())
                                    {
                                        add = 0;
                                        break;
                                    }
                                    else
                                    { add = 1; }
                                }
                                if (add == 1)
                                {
                                    INCO_ICODE.Add(datat2.Rows[j]["INCO_KIND"].ToString());
                                }

                                r += 1;
                            }
                            catch (Exception ex)
                            {
                                //      Console.WriteLine("產生報表時出錯！" + Environment.NewLine + ex.Message);
                            }
                        }
                        //小計
                        excelApp.Cells[r, 1] = "小計";
                        excelApp.Cells[r, 2] = "-";
                        excelApp.Cells[r, 3] = "-";
                        wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 3]);
                        wRange.Select();
                        wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                        //設定總和公式
                        excelApp.Cells[r, 4] = string.Format("=SUM(D{0}:D{1})", r - datat2.Rows.Count, r - 1); //第一列資料到最後一列資料總和
                        excelApp.Cells[r, 5] = string.Format("=SUM(E{0}:E{1})", r - datat2.Rows.Count, r - 1);
                        excelApp.Cells[r, 6] = string.Format("=SUM(F{0}:F{1})", r - datat2.Rows.Count, r - 1);
                        //row - 資料筆數 - title,name
                        wRange = wSheet.get_Range(wSheet.Cells[r - datat2.Rows.Count - 2, 1], wSheet.Cells[r, 6]); //設定框線
                        wRange.Select();
                        wRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        // 自動調整欄寬
                        wRange = wSheet.get_Range(wSheet.Cells[1, 1], wSheet.Cells[r, 6]);
                        wRange.Select();
                        wRange.Columns.AutoFit();
                    }
                }

                wSheet = (Excel._Worksheet)wBook.Worksheets[datat.Rows.Count]; //最後一個分頁-加上總計
                r += 2;
                //最後總計分類
                int count; //件數
                int count2;//給付金額
                int count3;//申報金額
                int count4;//扣繳稅額              

                excelApp.Cells[r, 1] = "所得項目";
                excelApp.Cells[r, 2] = "所得格式";
                excelApp.Cells[r, 3] = "件數";
                excelApp.Cells[r, 4] = "給付金額";
                excelApp.Cells[r, 5] = "申報金額";
                excelApp.Cells[r, 6] = "扣繳稅額";
                wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                r += 1;
                for (int q = 0; q < INCO_ICODE.Count; q++) //所得格式
                {
                    count = 0;
                    count2 = 0;
                    count3 = 0;
                    count4 = 0;
                    excelApp.Cells[r, 2] = INCO_ICODE[q];
                    for (int i = 0; i < datat.Rows.Count; i++) //人員清單
                    {
                        string BASE_SEQNO = datat.Rows[i]["BASE_SEQNO"].ToString();
                        //年,月,登入者機關代碼,列印之人員代碼
                        DataTable datat2 = new DataTable();
                        datat2 = sal2115.queryReportData2(strYearSelected, strMonthSelected, strOrgCode, BASE_SEQNO, strPayBudgeCode);
                      
                        for (int j = 0; j < datat2.Rows.Count; j++)//人員的資料
                        {
                            if (INCO_ICODE[q].ToString().Trim() == datat2.Rows[j]["INCO_KIND"].ToString().Trim())
                            {
                                count++;
                                if (datat2.Rows[j]["PAYOD_AMT"].ToString() != "0")
                                {
                                    count2 += (int) Convert.ToDouble(datat2.Rows[j]["PAYOD_AMT"]);
                                }
                                else //若應發金額(一)金額為0，則改用應發金額(二)之金額
                                {
                                    count2 += int.Parse(datat2.Rows[j]["INCO_REAL_AMT"].ToString());
                                }
                                count3 += int.Parse(datat2.Rows[j]["INCO_AMT"].ToString());
                                count4 += int.Parse(datat2.Rows[j]["INCO_TXAM"].ToString());
                            }
                        }
                    }
                    excelApp.Cells[r, 3] = count;
                    excelApp.Cells[r, 4] = count2;
                    excelApp.Cells[r, 5] = count3;
                    excelApp.Cells[r, 6] = count4;
                    r += 1;
                }

                //單位總計
                excelApp.Cells[r, 1] = "單位總計";
                wRange = wSheet.get_Range(wSheet.Cells[r, 1], wSheet.Cells[r, 1]);
                wRange.Select();
                wRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter; //置中
                // 設定總和公式 
                excelApp.Cells[r, 3] = string.Format("=SUM(C{0}:C{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 4] = string.Format("=SUM(D{0}:D{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 5] = string.Format("=SUM(E{0}:E{1})", r - INCO_ICODE.Count, r - 1);
                excelApp.Cells[r, 6] = string.Format("=SUM(F{0}:F{1})", r - INCO_ICODE.Count, r - 1);
                //row -count - title                 
                wRange = wSheet.get_Range(wSheet.Cells[r - INCO_ICODE.Count - 1, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.Borders.Weight = Excel.XlBorderWeight.xlThin; //設框線

                // 自動調整欄寬
                wRange = wSheet.get_Range(wSheet.Cells[1, 1], wSheet.Cells[r, 6]);
                wRange.Select();
                wRange.Columns.AutoFit();

            }

            string path = ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "SAL";
            if (Directory.Exists(Server.MapPath(path)))
            { //資料夾存在                             
            }
            else
            {            
                //新增資料夾
                Directory.CreateDirectory(Server.MapPath(path));
            }
            

            //儲存檔案的路徑
            string FileUploadPath = ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "SAL\\年度所得清冊.xls";
            string pathFile =Server.MapPath(FileUploadPath);                    
           
            try
            {   //另存活頁簿
                wBook.SaveAs(pathFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {               
            }

            //關閉活頁簿
            wBook.Close(false, Type.Missing, Type.Missing);
            //關閉Excel
            excelApp.Quit();
            //釋放Excel資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            wBook = null;
            wSheet = null;
            wRange = null;
            excelApp = null;
            GC.Collect();
            Console.Read();

            string fileName = "年度所得清冊.xls"; //下載檔名
            fileName = Server.UrlPathEncode(fileName); //中文檔名編譯
            //下載檔案  
            Response.Clear(); 
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);           
            Response.ContentType = "application/vnd.ms-excel";    //application/octet-stream  
            Response.WriteFile(pathFile);
            Response.End();
      
        }
     
    }

    protected void Button_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL2115_01.aspx"); 
    }



}