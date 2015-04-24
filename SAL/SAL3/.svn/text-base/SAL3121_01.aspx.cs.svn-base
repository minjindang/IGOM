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
using System.Text; 




public partial class SAL_SAL3_SAL3121 : BaseWebForm
{

    string[] stringSeparators = new string[] { ", " };

    string v_orgid;
    protected void Page_Load(object sender, EventArgs e)
    {
         v_orgid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode); //登入者機關代碼

        if (Page.IsPostBack) return;
        string year = DateTime.Now.ToString("yyyy");
        int num = int.Parse(year) - 1911;
        ddlyear.Items.Clear();
        for (int i = num - 2; i <= num + 1; i++)
        {
            ListItem li = new ListItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
            ddlyear.Items.Add(li);
        }
         
        ddlyear.SelectedValue =  (num - 1).ToString();
    }
    //submit button  
    protected void Button_submit_Click(object sender, EventArgs e)
    {     
        string date;
        if (ddlmonth.SelectedValue.ToString() != "")
        {
            date = (int.Parse(ddlyear.SelectedValue.ToString()) + 1911).ToString() + ddlmonth.SelectedValue.ToString(); //畫面年月
        }
        else
        {
            date = (int.Parse(ddlyear.SelectedValue.ToString()) + 1911).ToString(); //產生整年度的資料不需輸入月份
        }

        if (mode.Text == "search")//媒體申報轉帳資料查詢
        {
            view.Visible = true;
            search(date);
        }
        else if (mode.Text == "gen")//產生媒體申報轉帳檔
        {
            view.Visible = false;
            Gen_to_mediafmt(date);
        }
        else if (mode.Text == "download")//媒體申報轉帳檔下載
        {
            view.Visible = false;
            ExportReport(date);
        }

        
    }
    int init2;
    //產生媒體申報轉帳檔
    private void Gen_to_mediafmt(string date)
    {
       string nowntime = DateTime.Now.ToString("yyyyMMddHHmmss");
               
        string[] typeAry = null;
        string[] seqnoAry = null;
        string[]formatAry = null;
        string[] settingAry = null;
        string[] rulesAry = null;
        string[] alignAry = null;
        string[] repAry = null;
        string[] lengthAry = null;
        string[] startAry = null;
        string[] numAry = null;
        string[] mAry = null;

        //讀取媒體格式
        SAL3121 sal3121 = new SAL3121();
        DataTable datat2 = sal3121.queryData2();
        int count = datat2.Rows.Count;
        typeAry = new string[count];
        seqnoAry = new string[count];
        formatAry = new string[count];
        settingAry = new string[count];
        rulesAry = new string[count];
        alignAry = new string[count];
        repAry = new string[count];
        lengthAry = new string[count];
        startAry = new string[count];
        numAry = new string[count];
        mAry = new string[count];

        for (int i = 0; i < datat2.Rows.Count; i++ )
        {
            typeAry[i] = datat2.Rows[i]["fmt_type"].ToString();
            seqnoAry[i] = datat2.Rows[i]["fmt_seqno"].ToString();
            formatAry[i] = datat2.Rows[i]["fmt_format"].ToString();
            settingAry[i] = datat2.Rows[i]["fmt_setting"].ToString();
            rulesAry[i] = datat2.Rows[i]["fmt_rule"].ToString();
            alignAry[i] = datat2.Rows[i]["fmt_align"].ToString();
            repAry[i] = datat2.Rows[i]["fmt_rep"].ToString();
            lengthAry[i] = datat2.Rows[i]["fmt_length"].ToString();
            startAry[i] = datat2.Rows[i]["fmt_start"].ToString();
            numAry[i] = datat2.Rows[i]["fmt_num"].ToString();             
        }

         //====== 讀取資料表欄位
        string parStr = examAvail(date);
        string[] fedAry = null;
        fedAry = new string[seqnoAry.Length];
      
        init2 = 0;

       string v_key = UcSaCode1.SelectedValue.ToString(); //選擇所得種類

       if (v_key == "000" || v_key =="ALL")
        {
            deleteData2(date, "ALL", v_orgid);
        }

       string msg = "";

        DataTable datat3 = sal3121.queryData3(v_key);
        if (datat3 != null && datat3.Rows.Count > 0)
        {
            for (int i = 0; i < datat3.Rows.Count; i++)
            {
                //--- engf_form 有資料才做
                if (HasData(parStr, datat3.Rows[i]["code_no"].ToString()))
                {
                    for (int j = 0; j < fedAry.Length; j++)
                    {
                        fedAry[j] = getField(formatAry[j], settingAry[j], datat3.Rows[i]["code_no"].ToString(), date);
                    }

                    string[] orgAry = null;

                    if (fedAry[0].IndexOf(", ") != 0)
                    {
                        orgAry = new string[fedAry[0].ToString().Split(stringSeparators,StringSplitOptions.None).Length];
                    }
                    else
                    {
                        orgAry = new string[1];
                    }

                    for (int z = 0; z < orgAry.Length; z++)
                    {
                        orgAry[z] = "";
                    }

                    for (int y = 0; y < typeAry.Length; y++)
                    {
                        switch (typeAry[y])
                        {
                            case "001":
                                //資料庫欄位                      
                                dbField(y, orgAry, fedAry, alignAry, repAry, lengthAry, startAry, numAry, rulesAry);
                                break;
                            case "002":
                                //日期
                                break;
                            case "003":
                                //序號                           
                                seqField(y, init2, orgAry, alignAry, repAry, lengthAry);
                                break;
                            case "004":
                                //空白                          
                                spaceField(y, orgAry, alignAry, repAry, lengthAry);
                                break;
                            case "005":
                                //自訂
                                break;
                        }
                    }

                    //--- 塞入資料
                    string[] base_seqno_ary = getField("XXX", "base_seqno", datat3.Rows[i]["code_no"].ToString(), date).Split(stringSeparators,StringSplitOptions.None);

                    string[] empSeqAry = getField("SAL_SAUNIT", "base_seqno", datat3.Rows[i]["code_no"].ToString(), date).Split(stringSeparators,StringSplitOptions.None);

                    deleteData2(date, datat3.Rows[i]["code_no"].ToString(), v_orgid);

                    for (int lis = 0; lis < orgAry.Length; lis++)
                    {
                        insertData(date, datat3.Rows[i]["code_no"].ToString(), v_orgid, empSeqAry[lis], orgAry[lis]);
                    }

                    Page tempPage = this.Page;
                    CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "已轉檔", "", "");
                    this.Page = tempPage;

                }
                /*
                else
                {
                    msg += datat3.Rows[i]["code_no"].ToString()+",";
                } 
                 */
            }
        }
        else
        { 
        
        }

        if (msg != "")
        {
            Page tempPage = this.Page;
            CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, msg + "無engf_form資料", "", "");
            this.Page = tempPage;
        }

    }

    private void insertData(string yms, string its, string ogs, string sqs, string cnts)
    {         
          string now_date = fillLength (DateTime.Now.ToString("MM"), "R", "2", "0") 
                          + fillLength(DateTime.Now.ToString("dd"), "R", "2", "0");
          string v_mid = LoginManager.UserId;
    
        SAL3121 sal3121 = new SAL3121();
        sal3121.queryInsert(yms, its, ogs, sqs, cnts+now_date ,v_mid);
    }


    private void spaceField(int idx, string[] org, string[] align, string[] rep, string[] length)
    {
        string[] tAry = null;
        tAry = new string[org.Length];

        for (int i = 0; i < tAry.Length; i++)
        {
            tAry[i] = " ";
        }

        packStr(tAry, align[idx], length[idx], rep[idx]);

        if (org.Length == tAry.Length )
        {
            for (int sfind = 0; sfind < org.Length; sfind++)
            {
                org[sfind] = org[sfind] + tAry[sfind];               
            }
        }

    }

    private void seqField(int idx, int init, string[] org, string[] align, string[] rep, string[] length)
    {
        string[] tAry = null;

        int init22 = 0;

        tAry = new string[org.Length];
        int x = 0;
        if (! int.TryParse(init.ToString(),out x))
        {
            init = 0;
        }
        for (int i = 0; i < tAry.Length; i++)
        {
            tAry[i] = Convert.ToString(init + i);
            init22 = init + i;
        }

        init2 = init2 + 1;
        //每一種薪資項的個人序號要往下編

        packStr(tAry, align[idx], length[idx], rep[idx]);

        if (org.Length == tAry.Length)
        {
            for (int u = 0; u < tAry.Length; u++)
            {
                org[u] = org[u] + tAry[u];        
            }
        }
    }

    //    資料庫欄位函數: 索引位置, 標的字串陣列, 資料欄位陣列, 對齊陣列, 填值陣列, 全長陣列, 起始區間陣列, 結束區間陣列
    private void dbField(int idx, string[] org, string[] fed, string[] align, string[] rep, string[] length, string[] start, string[] num, string[] rules)
    {
        string[] tAry = null;
      
        if (fed[idx].IndexOf(", ") >= 0)
        {
            tAry = fed[idx].Split(stringSeparators,StringSplitOptions.None);
        }
        else
        {
            tAry = new string[1];
            tAry[0] = fed[idx];
        }        
      
        getSegment(tAry, start[idx], num[idx]);
        //取區間

        string[] les = getLines(idx, rules[idx]);

        if (les[0].Length > 0)
        {
            for (int ipp = 0; ipp < tAry.Length; ipp++)
            {
                tAry[ipp] = EBNFParser(rules[idx], tAry[ipp], les);
            }
        }   
      
        packStr(tAry, align[idx], length[idx], rep[idx]);
        

        if (org.Length == tAry.Length)
        {
            for (int u = 0; u <tAry.Length; u++)
            {
                org[u] = org[u].ToString() + tAry[u];
            }
        }
        else if (org.Length == 0)
        {
            for (int u = 0; u < org.Length; u++)
            {
                org[u] = org[u].ToString() + tAry[u];
            }
        }
    }

    //           組字函數: 標的字串陣列, 對齊, 全長, 填值
    private void packStr(string[] ttary, string ag, string lg, string rp)
    {
        for (int w = 0; w < ttary.Length; w++)
        {
                //資料長度大於欄位長度須截斷
            if (ttary[w].Length > int.Parse(lg))
            {
                ttary[w] = filteLength(ttary[w], ag, lg, rp);             
                //資料長度小於等於欄位長度-條件正常
            }
            else
            {
                ttary[w] = fillLength(ttary[w], ag, lg, rp);                
            }           
        }
    }

    public string fillLength(string Str,string alg, string lng,string r)
    {
	    string sr = "";

	    switch ((alg)) 
        {
		    case "R":
                sr = SALARY.Logic.pub.lpad(Str, Convert.ToInt32(lng), r).ToString();
//			    sr = pub.lpad(Str, Convert.ToInt32(lng), r);
			    break;
		    case "L":
                sr = SALARY.Logic.pub.rpad(Str, Convert.ToInt32(lng), r).ToString();
//			    sr = pub.rpad(Str, Convert.ToInt32(lng), r);
			    break;
	    }
	    return sr;
    }

    public string filteLength(string Str,string alg,string lng,string r)
    {
	    string sr = "";
	    string ad = "";

	    switch ((alg)) 
        {
		    case "R":
                sr = SALARY.Logic.pub.lpad(Str, Convert.ToInt32(lng), r).ToString();
//			    sr = pub.lpad(Str, Convert.ToInt32(lng), r);
			    break;
		    case "L":
                sr = SALARY.Logic.pub.rpad(Str, Convert.ToInt32(lng), r).ToString();
//			    sr = pub.rpad(Str, Convert.ToInt32(lng), r);
			    break;
    	}
	    return sr;
    }
    
    private string EBNFParser(string arules,string key , string[] lnes)
    {
        string[] linesAry =new string[lnes.Length];

        for (int i = 0; i < lnes.Length; i++)
        {
            linesAry[i] = lnes[i];
        }

        string[] txAry = linesAry[0].Split(stringSeparators,StringSplitOptions.None);
        string[] cAry = linesAry[1].Split(stringSeparators,StringSplitOptions.None);
        int res = -1;

        for (int i = 0; i < txAry.Length; i++)
        {
            if (txAry[i] == "result")
            {
                res = i;
                break; // TODO: might not be correct. Was : Exit For
            }
        }
        //--- 利用迴圈找出最下層值, 最多限十個階層
        string rl = runLoop(res, key, txAry, cAry);

        return rl;
    }

    private string runLoop(int dx, string fkey, string[] ta, string[] ca)
    {
        string tl = "";
        int iu = 0;
        int ti = 0;

        if (iu == 0)
        {
            ti = dx;
        }
        else
        {
            ti = getIndex(ta, tl);
        }

        if (Convert.ToInt32(ti) >= 0)
        {
            tl = ca[ti];
        }

        string[] findt = tl.Split('|');

        tl = "";

        if (findt.Length >= 0)
        {
            if (!(findt.Length == 1))
            {
                for (int j = 0; j < findt.Length; j++)
                {
                    if (fkey == findt[j])
                    {
                        tl = findt[j];
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else
            {
                iu = 1000;
            }
        }
        if (getIndex(ta, tl) >= 0)
        {
            tl = getValue(ca, getIndex(ta, tl));
        }
        else
        {
            tl = "";
        }

        return tl;
    }

    private string getValue(string[] ay, int ix)
    {
        string rt = "";

        if (Convert.ToInt32(ix) <= ay.Length && 0 <= Convert.ToInt32(ix))
        {
            string xm = "";
            xm = ay[ix];
            if (xm =="")
            {
                xm = "";
            }
            rt = xm;
        }

        return rt;
    }
    private int getIndex(string[] ay, string ky)
    {
        int rt = -1;

        for (int i = 0; i < ay.Length; i++)
        {
            string xm = ay[i];
            if (xm =="")
            {
                xm = "";
            }
            if (ky == xm)
            {
                rt = i;
                break; // TODO: might not be correct. Was : Exit For
            }
        }
        return rt;
    }


   //--- 將輸入之EBNF段落解析為行列指令
   //--- 輸入全文輸出識別/內容陣列
    private string[] getLines(int icnt, string xrules)
    {
        string[] rtAry = {"",""};
        string titleStr = "";
        string contentStr = "";

        string tempRules = xrules;
        
        int lk = 0;

        while (tempRules.Length > 0)
        {
            if (lk > 0)
            {
                titleStr = titleStr + ", ";
            }
            if (lk > 0)
            {
                contentStr = contentStr + ", ";
            }
            //string temp = tempRules;
            titleStr = titleStr + (tempRules.Substring(0, tempRules.IndexOf("::=") ));
            tempRules = tempRules.Substring(tempRules.IndexOf("::=") + 3);
            contentStr = contentStr + (tempRules.Substring(0, tempRules.IndexOf(".") ));
            tempRules = tempRules.Substring(tempRules.IndexOf(".") + 1);
            lk = lk + 1;
        }

        rtAry[0] = titleStr;
        rtAry[1] = contentStr;   

        return rtAry;
    }


    private void getSegment(string[] tary, string str, string nu)
    {
        int x=0;
        if (int.TryParse(str,out x) && int.TryParse(nu,out x))
        {
            for (int i = 0; i < tary.Length; i++)
            {
                tary[i] = tary[i].Substring(int.Parse(str), int.Parse(nu));
            }
        }
    }

    private string getField(string tab, string fed, string cond,string date)
    {
        string rtStr = "";
        string tab1 = tab;
        //if (tab1.ToUpper().Substring(0, 6) == "SAL_SA")
        if ( tab1.ToUpper().IndexOf("SAL_SA") >= 0 )
        {
            SAL3121 sal3121 = new SAL3121();
            DataTable datat4 = sal3121.queryData4(tab, fed, cond, v_orgid, date);
                    
                    int x = 0;
                    string vRS_1 = null;
                    string oldchar = ",";
                    string newchar = "，";

                    if (tab!="")
                    {
                        if (datat4 != null && datat4.Rows.Count > 0)
                        {
                            for (int i = 0; i < datat4.Rows.Count; i++)
                            {
                                if (datat4.Rows[i][fed].ToString() != "")
                                {
                                    vRS_1 = datat4.Rows[i][fed].ToString();
                                }
                                else
                                {
                                    vRS_1 = "";
                                }
                                if (fed.ToUpper() == "ENGF_YY" && vRS_1.Length > 4)
                                {
                                    vRS_1 = vRS_1.Substring(0, 4);
                                }
                                if (x == 0)
                                {
                                    rtStr = vRS_1;
                                }
                                else
                                {
                                    rtStr = rtStr + ", " + vRS_1;
                                }
                                x = x + 1;
                            }
                        }
                    }
        }

        return rtStr;
    }

    private bool HasData(string exAry, string eit)
    {
        //--- 檢查是否有該所得種類(eit: 001, 002, etc.)之資料可供處理, 傳回值true: 有資料; false: 沒資料, rxAry 式呼叫fuctnion examAvail之傳回值
               
            bool hdrt = false;
            if (exAry != "")
            {
                string[] temphd = exAry.Split(stringSeparators,StringSplitOptions.None);

                for (int hdi = 0; hdi < temphd.Length; hdi++)
                {
                    if (temphd[hdi] == eit)
                    {
                        hdrt = true;
                    }
                }
            } 
            return hdrt;   
    }

    private string examAvail(string date) // 取得各所得項目之資料筆數
    {
        string exrt = "";
        SAL3121 sal3121 = new SAL3121();
        DataTable exsql = sal3121.queryexsqlData(v_orgid, date);
        if (exsql != null && exsql.Rows.Count > 0)
        {
            int exid = 0;
            for (int i = 0; i < exsql.Rows.Count; i++)
            {
                if (exid != 0)
                {
                    exrt = exrt + ", ";
                }
                exrt = exrt + exsql.Rows[i]["engf_form"].ToString();
                exid = exid + 1;
            }
        }
            return exrt;
    }


    private void deleteData2(string xym, string xit, string xog)
    {
        SAL3121 sal3121 = new SAL3121();
        sal3121.queryDeleteData(xym, xit, xog);
    }

    //查詢
    private void search(string date)
    {       
         get_inco_amt(date);
         get_media_amt(date);
         get_excl_amt(date);

         string v_key = UcSaCode1.SelectedValue.ToString(); //選擇所得種類

         SAL3121 sal3121 = new SAL3121();
         DataTable datat = sal3121.queryData(v_orgid, date, v_key);

         if (datat != null && datat.Rows.Count > 0)
         {
             GridView_mediafmt.DataSource = datat;
             GridView_mediafmt.DataBind();
             GridView_mediafmt.Visible = true;
         }
         else
         {
             view.Visible = false;
             Page tempPage = this.Page;
             CommonFun.MsgShow(ref tempPage, CommonFun.Msg.Custom, "查無資料", "", "");
             this.Page = tempPage;
         } 
    }

    private void get_inco_amt(string v_date)
    {     
        string str_inco_amt ="";
        string str_inco_txam="";

        SAL3121 sal3121 = new SAL3121();
        DataTable datat = sal3121.querygetData(v_orgid, v_date);

        if (datat != null && datat.Rows.Count > 0)
        {
            str_inco_amt = datat.Rows[0]["s_inco_amt"].ToString();
            str_inco_txam = datat.Rows[0]["s_inco_txam"].ToString(); 
        }
        if (str_inco_amt == "")
        {
            str_inco_amt = "無資料";
        }
        if (str_inco_txam == "")
        {
            str_inco_txam = "無資料";
        }
        Label_inco_amt.Text = str_inco_amt;
        Label_inco_txam.Text = str_inco_txam; 
    }

    private void get_media_amt(string v_date)
    {
      string str_media_amt = "";
      string str_media_txam = "";

     SAL3121 sal3121 = new SAL3121();
     DataTable datat = sal3121.querygetData2(v_orgid, v_date);
        
        if (datat != null && datat.Rows.Count > 0)
        {
            str_media_amt = datat.Rows[0]["s_media_amt"].ToString();
            str_media_txam = datat.Rows[0]["s_media_txam"].ToString();	
	    }
        if (str_media_amt == "")
        {
            str_media_amt = "無資料";
        }
        if (str_media_txam == "")
        {
            str_media_txam = "無資料";
        }
        Label_media_amt.Text = str_media_amt;
        Label_media_txam.Text = str_media_txam;
    }
    
    private void get_excl_amt(string v_date)
    {
        string str_excl_amt = "無資料";
        string str_excl_txam = "無資料";

        SAL3121 sal3121 = new SAL3121();
        DataTable datat = sal3121.querygetData3(v_orgid, v_date);

        if (datat != null && datat.Rows.Count > 0)
        {       
            str_excl_amt = datat.Rows[0]["s_engf_amt"].ToString();
            str_excl_txam = datat.Rows[0]["s_engf_txam"].ToString();
        }
        if (str_excl_amt == "")
        {
            str_excl_amt = "無資料";
        }
        if (str_excl_txam == "")
        {
            str_excl_txam = "無資料";
        }

     Label_excl_amt.Text = str_excl_amt;
     Label_excl_txam.Text = str_excl_txam;
    }

    //下載
    private void ExportReport(string date)
    {     
    //    string v_mid = LoginManager.UserId; 
        get_saunit(date);
        get_string(date);

        StringBuilder s = new StringBuilder();
        s.Append(Label_download.Text);
        Label_download.Text = s.ToString();

        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
        string oExcelFileName = p_filename.Text;

        Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");
        Context.Response.ContentType = "application/plain";
        Context.Response.AddHeader("Content-Disposition", "attachment;filename=" + oExcelFileName);
        plExport1.RenderControl(oHtmlTextWriter);
        Context.Response.Write(s.ToString());
        Context.Response.End();         
    }

    private void get_string(string date)
    {
        string filestr = "";
        string key= UcSaCode1.SelectedValue;
        SAL3121 sal3121 = new SAL3121();
        DataTable report = sal3121.queryreport2(key);
        if (report != null && report.Rows.Count > 0)
        {
            for (int i = 0; i < report.Rows.Count; i++)
            {
                string v_key = report.Rows[i]["code_no"].ToString();
                DataTable dt = sal3121.queryreport3(v_orgid, date, v_key);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        filestr += dt.Rows[j]["mediafmt_content"].ToString() + Environment.NewLine;
                    }
                }
            }
        }
        Label_download.Text += filestr;
    }

    private void get_saunit(string date)
    {
        SAL3121 sal3121 = new SAL3121();
        DataTable report = sal3121.queryreport(v_orgid);
        if (report != null && report.Rows.Count > 0)
        {           
            p_filename.Text = report.Rows[0]["Unit_Tax"].ToString() + "." 
                            + SALARY.Logic.pub.lpad((Convert.ToInt32(date)-1911).ToString(),3,"0" ).ToString();
                
                    string v_unit_dep = (getLargeForm(report.Rows[0]["UNIT_DEP"].ToString()));
                    if (v_unit_dep.Length > 18)
                    {
                        v_unit_dep = v_unit_dep.Substring(0, 17);
                    }
                    string v_unit_addr = (getLargeForm(report.Rows[0]["UNIT_ADDR"].ToString()));
                    if (v_unit_addr.Length > 26)
                    {
                        v_unit_addr = v_unit_addr.Substring(0, 25);
                    }
                    string v_unit_hname = (getLargeForm(report.Rows[0]["UNIT_HNAME"].ToString()));
                    if (v_unit_hname.Length > 10)
                    {
                        v_unit_hname = v_unit_hname.Substring(0, 9);
                    }
                    string v_unit_cname = (getLargeForm(report.Rows[0]["UNIT_CNAME"].ToString()));
                    if (v_unit_cname.Length > 10)
                    {
                        v_unit_cname = v_unit_cname.Substring(0, 9);
                    }

                    string headerStr = "" + SALARY.Logic.pub.lpad(report.Rows[0]["UNIT_AREA"].ToString(), 3, "0") + SALARY.Logic.pub.lpad(" ", 8, " ")
                        + SALARY.Logic.pub.lpad(report.Rows[0]["UNIT_TAX"].ToString(), 8, "0") + "1" + SALARY.Logic.pub.rpad(v_unit_dep, 18, "　")
                        + SALARY.Logic.pub.rpad(v_unit_addr, 26, "　") + SALARY.Logic.pub.rpad(v_unit_hname, 20, "　") + SALARY.Logic.pub.rpad(v_unit_cname, 20, "　")
                        + SALARY.Logic.pub.rpad(report.Rows[0]["UNIT_TEL"].ToString(), 15, " ") + SALARY.Logic.pub.lpad(" ", 30, " ") + "          "
                        + "01" + "  " + "N" + " " + "N";
               
                    Label_download.Text = headerStr + Environment.NewLine;
        }
    }

    private string getLargeForm(string aString)
    {
        if (aString != "")
        {
            for (int i = 0; i < aString.Length; i++)
            {
                string a = aString.Substring(i, 1);
                int xx = Convert.ToInt32(a[0]);
                if (122 >= xx && xx >= 48)
                {
                    aString = FormTrans(aString, xx);
                }
            }
            if (aString.IndexOf("-") != 0)
            {
                aString = aString.Replace("-", "－");
            }
        }
        return aString;
    }
    private string FormTrans(string aString ,int xx)
    {
        int evaStr;
        int repStr;
        int a=0;
        if(! int.TryParse(xx.ToString(),out a))
        {            
            evaStr = Convert.ToInt32(xx.ToString()[0]);
        }
        else
        {
            if (xx.ToString().Length == 1)
            {
                evaStr = Convert.ToInt32(xx.ToString()[0]);
            }
            else
            {
                evaStr = xx;
            }
        }
        //'--- 取得全形字元
        if ((57 >= evaStr) && (evaStr >= 48))       //0~9
        {  
            repStr = (-23889 + (evaStr - 48));
        }
        else if((118 >= evaStr) && (evaStr >= 91))  //a~v
        {
            repStr = (-23857 + (evaStr - 71));
        }
        else if ((122 >= evaStr) && (evaStr >= 119)) //w~z
        {
            repStr = (-23857 + (evaStr - 6));
        }
        else if((90 >= evaStr) && (evaStr >= 65))   //A~Z
        {
            repStr = (-23857 + (evaStr - 65));
        }
        else
        {
            repStr = evaStr;
        }
        //--- 取代字元
       string Form = aString.Replace(evaStr.ToString(), repStr.ToString());
       return Form;
    }


    //重置
    protected void Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SAL3121_01.aspx");
    }
    //Check box
 
    protected void step1_CheckedChanged(object sender, EventArgs e)
    {
        step2.Checked = false;
        step3.Checked = false;
        mode.Text = "search";
        Button_submit.Text = "媒體申報轉帳資料查詢";
    }
    protected void step2_CheckedChanged(object sender, EventArgs e)
    {
        step1.Checked = false;
        step3.Checked = false;
        view.Visible = false;
        mode.Text = "gen";
        Button_submit.Text = "產生媒體申報轉帳檔";
    }
    protected void step3_CheckedChanged(object sender, EventArgs e)
    {
        step1.Checked = false;
        step2.Checked = false;
        view.Visible = false;
        mode.Text = "download";
        Button_submit.Text = "媒體申報轉帳檔下載";
    }
    protected void GridView_mediafmt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_mediafmt.PageIndex = e.NewPageIndex;
        string date;
        if (ddlmonth.SelectedValue.ToString() != "")
        {
            date = (int.Parse(ddlyear.SelectedValue.ToString()) + 1911).ToString() + ddlmonth.SelectedValue.ToString(); //畫面年月
        }
        else
        {
            date = (int.Parse(ddlyear.SelectedValue.ToString()) + 1911).ToString(); //產生整年度的資料不需輸入月份
        }       
        search(date);
    }
}