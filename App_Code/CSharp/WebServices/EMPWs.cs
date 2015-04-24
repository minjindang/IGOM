using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//
using EMPPLM.Logic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.Services.Protocols;
using System.Text;


/// <summary>
/// 2014/7/12 Eliot Chen
/// WS04 / WS06 不輸入條件也可查詢
/// SALSaBase 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class EMPWs : System.Web.Services.WebService {

    public EMPWs()
    {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }


    [WebMethod]
    // 第一類
    //代理人資料查調
    public string WS01(
        string strADID,
        string strDeptID,
//        string strUserID,
        string strAPCode)    // 應用系統代碼) 
    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";

        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
         */


        if (!empMember.canUserWS(IP, "W01", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }


        DataTable dt = empMember.queryAgent(strADID, strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W01", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W01", dt.Rows.Count.ToString(), "", "");

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;



        return "";
    }

    [WebMethod]
    //第二類
    //人員資料查調
    public string WS02(
        string strADID,
        string strDeptID,
//        string strUserID,// 查詢者ID
        string strAPCode    // 應用系統代碼
        )   
    {
 
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";
        /*
        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        */
        /*
        if (strUserID.Trim() == "")
        {
             strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        */

        if (!empMember.canUserWS(IP, "W02", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限 : "+IP+"\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        

        DataTable dt = empMember.queryEmpMember(strADID,
        strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W02", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W02", dt.Rows.Count.ToString(), "", "");

        for (int i = dt.Columns.Count -1; i >= 0 ; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "Id_card".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "AD_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "User_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Quit_job_flag".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Employee_type".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_ID".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_NAME".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "BOSS_LEVEL_ID".ToUpper())


            {
                dt.Columns.RemoveAt(i);
            }
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;

        /*
        XmlTable.Init();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            XmlTable.StartRow();
            XmlTable.SetColumn("Id_card", dt.Rows[i]["Id_card"].ToString());    //  員工編號
            XmlTable.SetColumn("AD_id", dt.Rows[i]["AD_id"].ToString());    // AD帳號
            XmlTable.SetColumn("User_name", dt.Rows[i]["User_name"].ToString());    // 姓名
            XmlTable.SetColumn("Quit_job_flag", dt.Rows[i]["Quit_job_flag"].ToString());    // 在職/離職註記
            XmlTable.SetColumn("Employee_type", dt.Rows[i]["Employee_type"].ToString());    // 人員類別
            XmlTable.SetColumn("DEPART_ID", dt.Rows[i]["DEPART_ID"].ToString());    // 機關代碼
            XmlTable.SetColumn("DEPART_NAME", dt.Rows[i]["DEPART_NAME"].ToString());    // 姓名
            XmlTable.SetColumn("Orgcode", dt.Rows[i]["Orgcode"].ToString());    // 姓名
            XmlTable.SetColumn("Orgcode_name", dt.Rows[i]["Orgcode_name"].ToString());    // 姓名

            XmlTable.EndRow();
        }
        return XmlTable.Xml;
         */ 
    }

    [WebMethod]
    // 第三類
    // 人員生日資料查調
    public string WS03(
        string strADID,
        string strDeptID,
//        string strUserID, // 查詢者ID
        string strAPCode,// 應用系統代碼
        string strBirthday)   
    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";
        /*
        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
         */
        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
         */


        if (!empMember.canUserWS(IP, "W03", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限 : " + IP + "\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        
        DataTable dt = empMember.queryEmpMember(strADID,
        strDeptID, strBirthday);

        // 增加查詢記錄
//        addRecord(
//            IP, "W03", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W03", dt.Rows.Count.ToString(), "", "");
        /*
        dt.Columns.Add("Birthday");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (!Convert.IsDBNull(dt.Rows[i]["Birth_date"]))
            {
                dt.Rows[i]["Birthday"]=
                    Convert.ToDateTime(dt.Rows[i]["Birth_date"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                 dt.Rows[i]["Birthday"]="";
            }
        }
         * */


        for (int i = dt.Columns.Count -1; i >= 0 ; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "Id_card".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "AD_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "User_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "EMAIL".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Employee_type".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "GENDER".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_ID".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_NAME".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Birth_date".ToUpper())
            {
                dt.Columns.RemoveAt(i);
            }
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;

        /*
        XmlTable.Init();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            XmlTable.StartRow();
            XmlTable.SetColumn("Id_card", dt.Rows[i]["Id_card"].ToString());    //  員工編號
            XmlTable.SetColumn("AD_id", dt.Rows[i]["AD_id"].ToString());    // AD帳號
            XmlTable.SetColumn("User_name", dt.Rows[i]["User_name"].ToString());    // 姓名

            XmlTable.SetColumn("EMAIL", dt.Rows[i]["EMAIL"].ToString());     //Email信箱
            XmlTable.SetColumn("Employee_type", dt.Rows[i]["Employee_type"].ToString());    // 人員類別
            XmlTable.SetColumn("GENDER", dt.Rows[i]["GENDER"].ToString()); // 性別
            if (!Convert.IsDBNull(dt.Rows[i]["Service_sdate"]))
            {
                XmlTable.SetColumn("Birth_date",
                    Convert.ToDateTime(dt.Rows[i]["Birth_date"]).ToString("yyyyMMdd"));// 生日
            }
            else
            {
                XmlTable.SetColumn("Birth_date", "");// 生日
            }
            XmlTable.SetColumn("DEPART_ID", dt.Rows[i]["DEPART_ID"].ToString());// 單位代碼    
            XmlTable.SetColumn("DEPART_NAME", dt.Rows[i]["DEPART_NAME"].ToString()); //單位名稱 
            XmlTable.SetColumn("Orgcode", dt.Rows[i]["Orgcode"].ToString()); // 機關代碼              
            XmlTable.SetColumn("Orgcode_name", dt.Rows[i]["Orgcode_name"].ToString());  //機關名稱    

            XmlTable.EndRow();
        }
        return XmlTable.Xml;
         */
    }

    [WebMethod]
    // 第四類
    // 人員資料查調(全部欄位)

    public string WS04(string strADID,
        string strDeptID,
//        string strUserID, // 查詢者ID
        string strAPCode)   // 應用系統代碼
    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";

        /*
         * remoce 2014/7/12
        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        */
        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        */
        
        if (!empMember.canUserWS(IP, "W04", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        
        
        DataTable dt = empMember.queryEmpMember(strADID,
        strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W04", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W04", dt.Rows.Count.ToString(), "", "");

        dt.Columns.Add("ActDate");
        dt.Columns.Add("FirstGovDate");
        dt.Columns.Add("LeftDate");
       dt.Columns.Add("Birthday");
       dt.Columns.Add("ServiceSdate");
        dt.Columns.Add("ServiceEdate");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            /*
            if (!Convert.IsDBNull(dt.Rows[i]["Act_date"]))
            {
                dt.Rows[i]["ActDate"] =
                    Convert.ToDateTime(dt.Rows[i]["Act_date"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["ActDate"] = "";
            }
            if (!Convert.IsDBNull(dt.Rows[i]["First_gov_date"]))
            {
                dt.Rows[i]["FirstGovDate"] =
                    Convert.ToDateTime(dt.Rows[i]["First_gov_date"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["FirstGovDate"] = "";
            }
            if (!Convert.IsDBNull(dt.Rows[i]["Left_date"]))
            {
                dt.Rows[i]["LeftDate"] =
                    Convert.ToDateTime(dt.Rows[i]["Left_date"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["LeftDate"] = "";
            }
            if (!Convert.IsDBNull(dt.Rows[i]["Birth_date"]))
            {
                dt.Rows[i]["Birthday"] =
                    Convert.ToDateTime(dt.Rows[i]["Birth_date"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["Birthday"] = "";
            }
            //Service_sdate
            if (!Convert.IsDBNull(dt.Rows[i]["Service_sdate"]))
            {
                dt.Rows[i]["ServiceSdate"] =
                    Convert.ToDateTime(dt.Rows[i]["Service_sdate"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["ServiceSdate"] = "";
            }
            //Service_edate
            if (!Convert.IsDBNull(dt.Rows[i]["Service_edate"]))
            {
                dt.Rows[i]["ServiceEdate"] =
                    Convert.ToDateTime(dt.Rows[i]["Service_edate"]).ToString("yyyyMMdd");// 生日
            }
            else
            {
                dt.Rows[i]["ServiceEdate"] = "";
            }
             * */
        }

        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "Id_card".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "AD_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "User_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "EMAIL".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Employee_type".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Act_date".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "First_gov_date".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Left_date".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Live_Phone".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Phone".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Ext".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Delete_flag".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Birth_date".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_ID".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "DEPART_NAME".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Service_sdate".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Service_edate".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Service_type".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "BOSS_LEVEL_ID".ToUpper()
                )
            {
                dt.Columns.RemoveAt(i);
            }
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;


        /*
        XmlTable.Init();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            XmlTable.StartRow();
            XmlTable.SetColumn("Id_card", dt.Rows[i]["Id_card"].ToString());    //  員工編號
            XmlTable.SetColumn("AD_id", dt.Rows[i]["AD_id"].ToString());    // AD帳號
            XmlTable.SetColumn("User_name", dt.Rows[i]["User_name"].ToString());    // 姓名
            XmlTable.SetColumn("EMAIL", dt.Rows[i]["EMAIL"].ToString());     //Email信箱
            XmlTable.SetColumn("Employee_type", dt.Rows[i]["Employee_type"].ToString());    // 人員類別

            if (!Convert.IsDBNull(dt.Rows[i]["Act_date"]))
            {
                XmlTable.SetColumn("Act_date",
                    Convert.ToDateTime(dt.Rows[i]["Act_date"]).ToString("yyyyMMdd"));// 到職日
            }
            else
            {
                XmlTable.SetColumn("Act_date","");// 到職日
            }


            if (!Convert.IsDBNull(dt.Rows[i]["First_gov_date"]))
            {

                XmlTable.SetColumn("First_gov_date",
                    Convert.ToDateTime(dt.Rows[i]["First_gov_date"]).ToString("yyyyMMdd"));// 初任公職日
            }
            else
            {
                XmlTable.SetColumn("First_gov_date", "");// 到職日
            }
           
           if (!Convert.IsDBNull(dt.Rows[i]["Left_date"]))
           {

               XmlTable.SetColumn("Left_date",
                   Convert.ToDateTime(dt.Rows[i]["Left_date"]).ToString("yyyyMMdd"));// 離職日
           }

           else
           {
               XmlTable.SetColumn("Left_date", "");// 到職日
           }
            



            XmlTable.SetColumn("Live_Phone", dt.Rows[i]["Live_Phone"].ToString());    // 直播電話
            XmlTable.SetColumn("Phone", dt.Rows[i]["Phone"].ToString());    // 總機號碼
            XmlTable.SetColumn("Ext", dt.Rows[i]["Ext"].ToString());    // 分機
            XmlTable.SetColumn("Delete_flag", dt.Rows[i]["Delete_flag"].ToString());    // 刪除註記

            if (!Convert.IsDBNull(dt.Rows[i]["Birth_date"]))
            {
                XmlTable.SetColumn("Birth_date",
                    Convert.ToDateTime(dt.Rows[i]["Birth_date"]).ToString("yyyyMMdd"));// 生日
            }
            else
            {
                XmlTable.SetColumn("Birth_date","");// 生日
            }

            XmlTable.SetColumn("DEPART_ID", dt.Rows[i]["DEPART_ID"].ToString());// 單位代碼    
            XmlTable.SetColumn("DEPART_NAME", dt.Rows[i]["DEPART_NAME"].ToString()); //單位名稱 
            XmlTable.SetColumn("Orgcode", dt.Rows[i]["Orgcode"].ToString()); // 機關代碼              
            XmlTable.SetColumn("Orgcode_name", dt.Rows[i]["Orgcode_name"].ToString());  //機關名稱  
 
            
            if (!Convert.IsDBNull(dt.Rows[i]["Service_sdate"]))
            {
            XmlTable.SetColumn("Service_sdate",
                Convert.ToDateTime(dt.Rows[i]["Service_sdate"]).ToString("yyyyMMdd"));// 服務期間(起)
            }
            else
            {
                XmlTable.SetColumn("Service_sdate","");// 服務期間(起)
            }
            if (!Convert.IsDBNull(dt.Rows[i]["Service_edate"]))
            {
                XmlTable.SetColumn("Service_edate",
                    Convert.ToDateTime(dt.Rows[i]["Service_edate"]).ToString("yyyyMMdd"));// 服務起監(迄)
            }
            else
            {
                XmlTable.SetColumn("Service_edate","");// 服務起監(迄)
            }
             

            XmlTable.SetColumn("Service_type", dt.Rows[i]["Service_type"].ToString());  //服務類別  

            XmlTable.EndRow();
        }
        return XmlTable.Xml;
         * */
    }

    [WebMethod]
    // 第五類
    // 人員使用應用系統權限查調
    public string WS05(
        string strADID,
        string strDeptID,
//        string strUserID, // 查詢者ID
        string strAPCode)   // 應用系統代碼
    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";

        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }

        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        */
        
        if (!empMember.canUserWS(IP, "W05", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限" + IP + "\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }

        DataTable dt = empMember.querySystemCanUse(strADID,
        strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W05", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W05", dt.Rows.Count.ToString(), "", "");
        /*
        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "Orgcode".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_shortname".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Depart_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Depart_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Parent_depart_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Visable_flag".ToUpper()
                )
            {
                dt.Columns.RemoveAt(i);
            }
        }
         * */

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;

    }

    [WebMethod]
    // 第六類
    // 單位資料查調
    public string WS06
        (string strADID,
        string strDeptID,
//        string strUserID, // 查詢者ID
        string strAPCode)   // 應用系統代碼

    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";
/*
//        if (strADID.Trim() == "" || strDeptID == "")
        if (strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
*/
        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
         */

        
        if (!empMember.canUserWS(IP, "W06", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        
        
        DataTable dt = empMember.queryEmpOrg(strADID,
        strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W06", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W06", dt.Rows.Count.ToString(), "", "");

        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "Orgcode".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Orgcode_shortname".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Depart_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Depart_name".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Parent_depart_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Visable_flag".ToUpper()
                )
            {
                dt.Columns.RemoveAt(i);
            }
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;

        /*

        XmlTable.Init();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            XmlTable.StartRow();
            XmlTable.SetColumn("Orgcode", dt.Rows[i]["Orgcode"].ToString());    // 機關代碼
            XmlTable.SetColumn("Orgcode_name", dt.Rows[i]["Orgcode_name"].ToString());      // 機關名稱
            XmlTable.SetColumn("Orgcode_shortname", dt.Rows[i]["Orgcode_shortname"].ToString()); //單位簡稱
            XmlTable.SetColumn("Depart_id", dt.Rows[i]["Depart_id"].ToString()); //單位代碼
            XmlTable.SetColumn("Depart_name", dt.Rows[i]["Depart_name"].ToString()); //單位名稱
            XmlTable.SetColumn("Parent_depart_id", dt.Rows[i]["Parent_depart_id"].ToString()); //上層單位代碼
            XmlTable.SetColumn("Visable_flag", dt.Rows[i]["Visable_flag"].ToString()); //是否停用記註
            XmlTable.EndRow();
        }
        return XmlTable.Xml;
         */
    }

    [WebMethod]
    // 第七類
    // 行動裝置註冊資料查調
    public string WS07(
        string strADID,
        string strDeptID,
//        string strUserID, // 查詢者ID
        string strAPCode)   // 應用系統代碼
    {
        // 呼叫者IP
        string IP = HttpContext.Current.Request.UserHostAddress;

        Emp_Member empMember = new Emp_Member();

        string strResult = "";
        /*
        if (strADID.Trim() == "" && strDeptID == "")
        {
            strResult =
               "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入單位或人員資料\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
        /*
        if (strUserID.Trim() == "")
        {
            strResult =
              "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"請輸入查詢人員代號\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }
         */


        if (!empMember.canUserWS(IP, "W07", strAPCode))
        {
            strResult =
                "\"isSuccess\":\"N\"";
            strResult +=
                ",\"message\":\"沒有權限\"";

            strResult = "{" + strResult + "}";
            return strResult;
        }

        DataTable dt = empMember.queryEmpMobiDevReg(strADID,
        strDeptID);

        // 增加查詢記錄
//        addRecord(
//            IP, "W07", dt.Rows.Count.ToString(), "", strUserID);
        addRecord(
            IP, "W07", dt.Rows.Count.ToString(), "", "");

        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            if (dt.Columns[i].ColumnName.ToUpper() != "AD_id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Unique id".ToUpper()
                && dt.Columns[i].ColumnName.ToUpper() != "Is_registed".ToUpper()
                )
            {
                dt.Columns.RemoveAt(i);
            }
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"\"";
        string strData = "";
        strData = DataTableToJsonString(dt);
        strResult = "{" + strResult + "," + strData + "}";

        return strResult;


/*
        XmlTable.Init();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            XmlTable.StartRow();
            XmlTable.SetColumn("AD_id", dt.Rows[i]["AD_id"].ToString());
            XmlTable.SetColumn("Unique id", dt.Rows[i]["Unique id"].ToString());
            XmlTable.SetColumn("Is_registed", dt.Rows[i]["Is_registed"].ToString());
            XmlTable.EndRow();
        }
        return XmlTable.Xml;
 * */
    }

    private void addRecord(
        string strQueryIP,
        string strWsType,
        string strQueryCount,
        string strNoteDesc,
        string strChangeUserID
       )
    {
        Emp_Member empMember = new Emp_Member();
        empMember.addQueryRecord(strQueryIP, strWsType, strQueryCount, strNoteDesc, strChangeUserID);
    }


    static public string DataTableToJsonString(DataTable dt)
    {
        StringBuilder JsonString = new StringBuilder();
        JsonString.Append(@"""ResultList"":[");

        if (dt != null && dt.Rows.Count > 0)
        {
            //            JsonString.Append("{");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    JsonString.Append(string.Format(@"""{0}"":""{1}""", dt.Columns[j].ColumnName, Convert.ToString(dt.Rows[i][j])));
                    if (j != dt.Columns.Count - 1) JsonString.Append(",");
                }
                JsonString.Append("}");
                if (i != dt.Rows.Count - 1) JsonString.Append(",");
            }
            //            JsonString.Append("}");
        }
        JsonString.Append("]");
        return JsonString.ToString();
    }

}
