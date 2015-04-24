using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EMP.Logic;
using IGOM.Logic;
using EMPPLM.Logic;
using FSC.Logic; 
using FSCPLM.Logic; 

using System.Data;
using System.Data.SqlClient;
using System.Text; 
using System.Collections; 
using System.Transactions;
using CommonLib;
using SAL.Logic;
using System.DirectoryServices;

using System.IO;
 
/// <summary>  
/// MOBServices 的摘要描述
/// Created 2014/5/21 Eliot
/// 2014/7/31 Eliot Chen
/// 086
/// 由性別取得假別
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class MOBServices : System.Web.Services.WebService
{
    private const string strNoData = "查無資料";

    public MOBServices()
    {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    // WSMOB01
    // 登入作業
    public string WSMOB001(
        string ID,          // 帳號
        string password,    // 密碼
        string Device_Type, // 裝置類型, 先不使用
        string Device_ID,   // 裝置代碼, 先不使用
        string Auth_Code    // 驗證碼, 先不使用
        )
    {
        string strResult;


        if (!chackAuth(""))
        {
            strResult = "{" + "驗證碼錯誤" + "}";
            return strResult;
        }

        // 先使用AD登入
        // 取得 Web Config 相關參數
        string stradIP = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_server_ip"];
        string stradID = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_id"];
        string stradPass = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_pass"];
        string stradDC = System.Web.Configuration.WebConfigurationManager.AppSettings["ad_dc"];

        DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + stradIP
        , ID, password);
        DirectorySearcher adsSearcher = new DirectorySearcher(dirEntry);
        //adsSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
        adsSearcher.Filter = "(sAMAccountName=" + ID + ")";

        try
        {
            SearchResult adsSearchResult = adsSearcher.FindOne();
        }
        catch (Exception ex)
        {
            strResult = "{" + buildJSONErr("AD 登入失敗!") + "}";
            return strResult;
        }


        //  由 AD 去取得 ID_CARD
        //FSC.Logic.Personnel psn = null;
        DataTable dt = new FSC.Logic.Personnel().GetDataByADid(ID.Trim());
        string strIDCard = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            strIDCard = dt.Rows[0]["ID_CARD"].ToString();
        }


//        string messageInfo = LoginInfo.CheckAccPass(ID.Trim());
        string messageInfo = LoginInfo.CheckAccPass(strIDCard);
        if (!string.IsNullOrEmpty(ID.Trim()) && !"".Equals(messageInfo))
        {
            strResult = "{" + buildJSONErr(messageInfo) + "}";
            return strResult;
        }

        FSC.Logic.Personnel psn = new FSC.Logic.Personnel().GetObject(strIDCard);
        //return "test";

        if (psn != null)
        {
            string Account = psn.IdCard;
            string UserData = LoginInfo.GetUserData(psn, Account);
            //return "test";

            if (string.IsNullOrEmpty(UserData))
            {
                strResult = "{" + buildJSONErr("登入失敗!") + "}";
                return strResult;
            }
            else
            {
                //設定驗證票
                //LoginManager.SetAuthenTicket(UserData, Account);
                // 回傳訊息JSON

                strResult =
                   "\"isSuccess\":\"Y\"";
                strResult +=
                    ",\"message\":\"" + "登入成功!" + "\"" +
                    ",\"UserData\":\"" + UserData + "\"" +
                    "";

                return "{" + strResult + "}";

            }
        }
        else
        {
            strResult = "{" + buildJSONErr("帳號密碼錯誤![" + strIDCard+"]") + "}";
            return strResult;
            //           CommonFun.MsgShow(this, CommonFun.Msg.Custom, "帳號密碼錯誤!");
        }

        //return "";
    }


    [WebMethod]
    // WSMOB002
    // 裝置註冊
    public string WSMOB002(
        string id_card,     // ID CARD
        string AD_id,       // AD帳號
        string Device_Type, // 裝置類型 (I : IOS, A:Android)
        string Device_ID,   // 裝置代碼
        string Auth_Code    // 驗證碼, 先不使用
        )
    {
        string strResult = "";
        if (!chackAuth(""))
        {
            strResult = "{" + "驗證碼錯誤" + "}";
            return strResult;
        }

        EMPMobiDevReg empMobiDevReg = new EMPMobiDevReg();
        empMobiDevReg.insertEmpMobidevReg(id_card, AD_id, Device_ID, "N", id_card, Device_Type);

        strResult =
           "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "資料新增成功!" + "\"";
        return "{" + strResult + "}";

    }

    // WSMOB003
    // 裝置註冊查詢
    [WebMethod]
    public string WSMOB003(
        string id_card,     // ID CARD
        string AD_id,       // AD帳號
        string Device_Type, // 裝置類型 (I : IOS, A:Android)
        string Device_ID,   // 裝置代碼
        string Auth_Code    // 驗證碼, 先不使用    
        )
    {
        string strResult = "";
        if (!chackAuth(""))
        {
            strResult = "{" + "驗證碼錯誤" + "}";
            return strResult;
        }
        EMPMobiDevReg empMobiDevReg = new EMPMobiDevReg();
        // 先查是否以註冊成功
        if (!empMobiDevReg.isDataExists(id_card, AD_id, Device_ID, "Y"))
        {
            if (empMobiDevReg.isDataExists(id_card, AD_id, Device_ID, "N"))
            {
                // 未完成註冊
                strResult =
                    "\"isSuccess\":\"Y\"";
                strResult +=
                    ",\"message\":\"" + "未完成註冊,等待審核中" + "\"" +
                    ",\"status_cd\":\"" + "2" + "\"";
            }
            else
            {
                // 無資料
                strResult =
                    "\"isSuccess\":\"Y\"";
                strResult +=
                    ",\"message\":\"" + "無相關註冊資料" + "\"" +
                    ",\"status_cd\":\"" + "1" + "\"";
            }
        }
        else
        {
            // 無資料
            strResult =
                "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"" + "此裝置已完成註冊" + "\"" +
                ",\"status_cd\":\"" + "3" + "\"";
        }

        return "{" + strResult + "}";
    }

    // WSMOB004
    // 一般請假申請
    [WebMethod]
    public string WSMOB004
    (
        bool isUpdate,       // 新增或更新判斷
        string Requestfid,     // 傳入之 fid
        string Orgcode,        // Org Code
        string strLeaveType,     // 假別
        string Depart_id,       // 單位代碼
        string Apply_id,        // 申請之 ID Card
        string Apply_name,
        string Apply_posid,
        string Apply_stype,

        string DeputyDepartid,  // 代理之 Depart ID
        string DeputyIdcard,    // 代理人之 ID Card
        string DeputyName,      //代理人name
        string DeputyPosid,

        string reason,          // 理由
        string OccurDate,       // 事實發生日
        string Place,           // 旅遊地點
        string Target,         //喪假對象
        string BabyDays        //懷孕日數

        , string RetainFlag      // 請休假別
        , string LocationFlag    // 種類
        , string ChinaFlag       // 是否赴大陸地區旅遊 
        , string InterTravelFlag // 國民旅遊卡
        , string Start_date      // 起價開始日期
        , string End_date        // 請假結束日期
        , string Start_time      // 請假開始時間
        , string End_time        // 請假結束時間
        , string url
        , string WriterIdcard
        , string WriterName
        , string WriterPosid
        , DataSet ds
//        , DataTable dt
//        , DataTable dtAtt
        )
    {
        string fid = "";
        string msg = "";
        try
        {
            using (TransactionScope trans = new TransactionScope())
            {
                fid = (isUpdate ? Requestfid :
                    new SYS.Logic.FlowId().GetFlowId(Orgcode, "001001", Convert.ToInt32(strLeaveType)));
                List<LeaveMain> lmList = new List<LeaveMain>();

                // 只有一次請假，所以一定是A1
                //		        if (rblLeave_ngroup.SelectedValue == "A1") {
                FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
                lm.FlowId = fid;
                lm.Orgcode = Orgcode;
                lm.DepartId = Depart_id;
                lm.IdCard = Apply_id;
                lm.UserName = Apply_name;
                lm.LeaveGroup = "A";
                lm.LeaveNgroup = "A1";
                lm.LeaveType = strLeaveType;
                lm.Reason = reason;
                lm.OccurDate = OccurDate; // 事實發生日
                lm.Place = Place; // 旅遊地點
                lm.Target = Target;    // 喪假對象  
                lm.BabyDays = BabyDays;   // 懷孕日數 

                if ("03" == strLeaveType)
                {
                    lm.RetainFlag = RetainFlag;
                    lm.InterTravelFlag = InterTravelFlag;
                }
                lm.LocationFlag = LocationFlag;
                if (LocationFlag == "1")
                {
                    lm.ChinaFlag = ChinaFlag;
                }

                lm.Change_userid = WriterIdcard;
                lm.Change_date = System.DateTime.Now;
                int hours = computeNotWorkHour(Start_date, End_date, Start_time, End_time, Apply_id, Orgcode);

                lm.StartDate = Start_date;
                lm.EndDate = End_date;
                lm.StartTime = Start_time;
                lm.EndTime = End_time;
                lm.LeaveHours = hours;
                lmList.Add(lm);

                //事假檢核上限天數提示訊息
                //{
                int totalHours = 0;
                int count = 1;
                foreach (LeaveMain l in lmList)
                {
                    if (count == lmList.Count)
                    {
                        //事假 含 家庭照顧假
                        if (l.LeaveType == "01")
                        {
                            totalHours += new LeaveMain().GetHaveHoursByDate(l.IdCard, l.LeaveType, l.StartDate);
                            totalHours += new LeaveMain().GetHaveHoursByDate(l.IdCard, "25", l.StartDate);
                            //病假 含 生理假
                        }
                        else if (l.LeaveType == "02")
                        {
                            totalHours += new LeaveMain().GetHaveHoursByDate(l.IdCard, l.LeaveType, l.StartDate);
                            totalHours += new LeaveMain().GetHaveHoursByDate(l.IdCard, "24", l.StartDate);
                        }
                    }

                    totalHours += (int)l.LeaveHours;
                    //再加上這次申請的時數
                    count += 1;
                }

                if (strLeaveType == "01" || strLeaveType == "02")
                {
                    double limitDays = 0;
                    Personnel psn = new Personnel().GetObject(Apply_id);
                    if (strLeaveType == "01" && psn.Pehday2.ToString() != "")
                    {
                        limitDays = CommonFun.getDouble(psn.Pehday2);
                    }
                    else if (strLeaveType == "02" && psn.Pehday3.ToString() != "")
                    {
                        limitDays = CommonFun.getDouble(psn.Pehday3);
                    }
                    else
                    {
                        //                            DataTable pd04mdt = new CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, ddlLeave_type.SelectedValue);
                        DataTable pd04mdt = new CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, strLeaveType);
                        if (pd04mdt != null && pd04mdt.Rows.Count > 0)
                        {
                            limitDays = CommonFun.getDouble(pd04mdt.Rows[0]["PDDAYS"].ToString());
                        }
                    }

                    if (limitDays >= 0 & totalHours > Content.ConvertToHours(limitDays))
                    {
                        string leave_type = (strLeaveType == "01" ? "事假" : "病假");
                        //CommonFun.MsgShow(Me, CommonFun.Msg.Custom, leave_type + "已超過可休上限(" & limitDays & "天)!")
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid.ToString(), "alert('已超過可休上限(" + limitDays + "天)!');", true);
                        msg = leave_type + "已超過可休上限(" + limitDays + "天)!";
                    }
                }


                //補休資料
                //		        List<LeaveMainMapping> lmmList = GetLeaveMainMappingData(fid, hours);
                DataTable dt = ds.Tables["data"];
                List<LeaveMainMapping> lmmList = new List<LeaveMainMapping>();
                lmmList = GetLeaveMainMappingData(fid, hours, strLeaveType, Apply_id, Start_date, End_date, Start_time, End_time, dt,Orgcode);

                //AppException.WriteErrorLog("kmmList", "[" + lmmList[0].LeaveHours.ToString() + "]");
                // 附件處理
                DataTable dtAtt = ds.Tables["att"];
                string tmpFolder = Guid.NewGuid().ToString();
//                AppException.WriteErrorLog("dtAtt.Rows.Count", "1");
//                AppException.WriteErrorLog("dtAtt.Rows.Count", "[" + dtAtt.Rows.Count.ToString() + "]");
//                AppException.WriteErrorLog("dtAtt.Rows.Count", "2");
                for (int i = 0; i < dtAtt.Rows.Count; i++)
                {
                    string Filepath = Server.MapPath("~\\fileupload\\Attachment\\temp\\" + tmpFolder + "\\");
                    // Create Temp Folder
                    //建立附件目錄
                    if (!Directory.Exists(Filepath))
                    {
                        Directory.CreateDirectory(Filepath);
                    }

                    byte[] filebytes = Convert.FromBase64String(dtAtt.Rows[i]["base64str"].ToString());
                    FileStream fs = new FileStream(Filepath + dtAtt.Rows[i]["gv_hdfileRealName"].ToString(),
                                                   FileMode.CreateNew,
                                                   FileAccess.Write,
                                                   FileShare.None);
                    fs.Write(filebytes, 0, filebytes.Length);
                    fs.Close(); 
                    // FLOW 處理
                    SYS.Logic.Attachment att=new SYS.Logic.Attachment();
//                    att = att.GetObjectById(Convert.ToInt32(dtAtt.Rows[i]["gv_hfId"].ToString()));
                    att.File_name = dtAtt.Rows[i]["gv_lbtnAttachFile"].ToString();
                    att.File_path = Server.MapPath("~\\fileupload\\Attachment\\temp\\" + tmpFolder + "\\");
                    att.File_real_name = dtAtt.Rows[i]["gv_hdfileRealName"].ToString();
                    att.File_size = dtAtt.Rows[i]["gv_lbFile_size"].ToString();
                    att.File_type = dtAtt.Rows[i]["gv_lbFile_type"].ToString();
                    att.Id=att.InsertAttach().ToString();
//                    att.Id = (i + 1).ToString();// dtAtt.Rows[i]["gv_hfId"].ToString();
                    att.CopyFile(fid,tmpFolder);

                }


                    if (msg == "")
                    {
                        if (isUpdate)
                        {
                            AppException.WriteErrorLog("Status", "[isUpdate]");
                            SYS.Logic.Flow f = new SYS.Logic.Flow();
                            f.FlowId = fid;
                            f.Orgcode = Orgcode;
                            f.DepartId = Depart_id;
                            f.ApplyIdcard = Apply_id;
                            f.ApplyName = Apply_name;
                            f.ApplyPosid = Apply_posid;
                            f.ApplyStype = Apply_stype;
                            f.DeputyOrgcode = Orgcode;
                            f.DeputyDepartid = DeputyDepartid;
                            f.DeputyIdcard = DeputyIdcard;
                            f.DeputyName = DeputyName;
                            f.DeputyPosid = DeputyPosid;
                            f.WriterOrgcode = Orgcode;
                            f.WriterDepartid = Depart_id;
                            f.WriterIdcard = WriterIdcard;
                            f.WriterName = WriterName;
                            f.WriterPosid = WriterPosid;
                            f.WriteTime = System.DateTime.Now;
                            f.FormId = "001001";
                            f.Reason = reason;
                            f.ChangeUserid = WriterIdcard;

                            if (url != "FSC3116")
                            {
                                f.CaseStatus = 2;
                            }

                            f.Update();
                            foreach (LeaveMain lme in lmList)
                            {
                                lme.UpdateLeaveMain();
                            }
                        }
                        else
                        {
                            AppException.WriteErrorLog("Status", "[isNew]");

                            SYS.Logic.Flow f = new SYS.Logic.Flow();
                            f.FlowId = fid;
                            f.Orgcode = Orgcode;
                            f.DepartId = Depart_id;
                            f.ApplyIdcard = Apply_id;
                            f.ApplyName = Apply_name;
                            f.ApplyPosid = Apply_posid;
                            f.ApplyStype = Apply_stype;
                            f.DeputyOrgcode = Orgcode;
                            f.DeputyDepartid = DeputyDepartid;
                            f.DeputyIdcard = DeputyIdcard;
                            f.DeputyName = DeputyName;
                            f.DeputyPosid = DeputyPosid;
                            f.WriterOrgcode = Orgcode;
                            f.WriterDepartid = Depart_id;
                            f.WriterIdcard = WriterIdcard;
                            f.WriterName = WriterName;
                            f.WriterPosid = WriterPosid;
                            f.WriteTime = System.DateTime.Now;
                            f.FormId = "001001";
                            f.Reason = reason;
                            f.ChangeUserid = WriterIdcard;

                            SYS.Logic.CommonFlow.AddFlow(f, lmList, lmmList);
                        }

                        trans.Complete();
                    }
                    else
                    {
                        trans.Dispose();
                    }
            }


            //如果交易成功寄送email
            // 先 Mark
            //    SendNotice.send(Orgcode, fid);
        }

        catch (FlowException fex)
        {
            AppException.WriteErrorLog(fex.StackTrace, fex.Message);
            AppException.WriteErrorLog(fex.StackTrace, "{" + buildJSONErr(fex.Message) + "}");
            return "{" + buildJSONErr(fex.Message) + "}";
            //            strEMessage = fex.Message;
            //return false;
            //	        CommonFun.MsgShow(this, CommonFun.Msg.Custom, fex.Message());

        }
        catch (Exception ex)
        {
            //            strEMessage = ex.Message;
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            AppException.WriteErrorLog(ex.StackTrace, "{" + buildJSONErr(ex.Message) + "}");
            return "{" + buildJSONErr(ex.Message) + "}";
            //return false;
            //	        CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }
        //        strEMessage = "";

        if (msg != "")
        {
            return "{" + buildJSONErr(msg) + "}";
        }
        else
        {
            string strResult =
               "\"isSuccess\":\"Y\"";

            strResult +=
                ",\"message\":\"" + msg + "\"";


            return "{" + strResult + "}";
        }


    }


    protected int computeNotWorkHour(string Start_date, string End_date, string Start_time, string End_time, string Apply_id, string Orgcode)
    {
        if (int.Parse(Start_date) > int.Parse(End_date))
        {
            return 0;
        }

        int hours = 0;
        int minutes = 0;
        int minutesAday = 0;
        bool offday = false;
        System.DateTime today = default(System.DateTime);

        try
        {
            DateTime vBegin = FSC.Logic.DateTimeInfo.GetPublicDate(Start_date + Start_time,"");
            DateTime vEnd = FSC.Logic.DateTimeInfo.GetPublicDate(End_date + End_time,"");

        
            CalendarRegion cr1 = new CalendarRegion();
            CalendarRegion cr2 = new CalendarRegion();
            CalendarRegion cr3 = new CalendarRegion();

            cr1.vBegin = vBegin;
            cr1.vEnd = vEnd;
            int count = 0;
            do
            {
                try
                {
         //           if (cr2.vBegin == null)
                    if(count == 0)
                    {
                        cr2.vBegin = vBegin;
                    }
         //           if (cr3.vBegin == null)
                    if(count ==0)
                    {
                        cr3.vBegin = vBegin;
                    }

                    Hashtable ht = FSC.Logic.Content.getWorkTime(Apply_id, FSC.Logic.DateTimeInfo.GetRocDate(cr2.vBegin), Orgcode);

                    string worktimeb = "";
                    string worktimee = "";
                    string noontimeb = "";
                    string noontimee = "";

                    if (ht != null && ht.Count > 0)
                    {
                        worktimeb = ht["WORKTIMEB"].ToString();
                        worktimee = ht["WORKTIMEE"].ToString();
                        noontimeb = ht["NOONTIMEB"].ToString();
                        noontimee = ht["NOONTIMEE"].ToString();
                        offday = Convert.ToBoolean(ht["OFFDAY"].ToString());
                    }
                    else
                    {
                        throw new FlowException("無班表資料!");
                    }

                    int beginWorkerTimeHour = int.Parse(worktimeb.Substring(0, 2));
                    int beginWorkerTimeMinute = int.Parse(worktimeb.Substring(2));
                    int endWorkerTimeHour = int.Parse(worktimee.Substring(0, 2));
                    int endWorkerTimeMinute = int.Parse(worktimee.Substring(2));

                    int beginNoonRestTimeHour = int.Parse(noontimeb.Substring(0, 2));
                    int beginNoonRestTimeMinute = int.Parse(noontimeb.Substring(2));
                    int endNoonRestTimeHour = int.Parse(noontimee.Substring(0, 2));
                    int endNoonRestTimeMinute = int.Parse(noontimee.Substring(2));

                    cr2.vBegin = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0);
                    cr2.vEnd = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second);

                    cr3.vBegin = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0);
                    cr3.vEnd = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second);

                }
                catch (FlowException fex)
                {
                    throw new FlowException(fex.Message);              
                }
                catch (Exception ex)
                {
                    cr2.vBegin = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 8, 0, 0);
                    cr2.vEnd = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second);

                    cr3.vBegin = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 13, 30, 0);
                    cr3.vEnd = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second);
                }

             
                if (!offday)
                {
                    minutesAday = FSC.Logic.Content.getIntersectionMinutes(cr1, cr2) + FSC.Logic.Content.getIntersectionMinutes(cr1, cr3);

                    if (minutesAday > 480)
                        minutesAday = 480;
                    minutes += minutesAday;
                }

                if (cr2.vBegin.Date.Equals(vEnd.Date))
                    break; // TODO: might not be correct. Was : Exit Do

                cr2.vBegin = cr2.vBegin.AddDays(1);
                cr2.vEnd = cr2.vEnd.AddDays(1);
                cr3.vBegin = cr3.vBegin.AddDays(1);
                cr3.vEnd = cr3.vEnd.AddDays(1);

                count++;

            } while (true);

        }
        catch (Exception fex)
        {
            throw new FlowException(fex.Message);
        }

            hours = (minutes + 59)/60 ;

            return hours;

    }

    protected int computeHolidayWorkHour(string Start_date, string End_date, string Start_time, string End_time, string Apply_id, string Orgcode)
    {
        if (int.Parse(Start_date) > int.Parse(End_date))
        {
            return 0;
        }

        int hours = 0;
        int minutes = 0;
        int minutesAday = 0;
        bool offday = false;

        try
        {
            DateTime vBegin = FSC.Logic.DateTimeInfo.GetPublicDate(Start_date + Start_time, "");
            DateTime vEnd = FSC.Logic.DateTimeInfo.GetPublicDate(End_date + End_time, "");


            CalendarRegion cr1 = new CalendarRegion();
            CalendarRegion cr2 = new CalendarRegion();
            CalendarRegion cr3 = new CalendarRegion();

            cr1.vBegin = vBegin;
            cr1.vEnd = vEnd;
            int count = 0;
            do
            {
                try
                {
                    //           if (cr2.vBegin == null)
                    if (count == 0)
                    {
                        cr2.vBegin = vBegin;
                    }
                    //           if (cr3.vBegin == null)
                    if (count == 0)
                    {
                        cr3.vBegin = vBegin;
                    }

                    Hashtable ht = FSC.Logic.Content.getWorkTime(Apply_id, FSC.Logic.DateTimeInfo.GetRocDate(cr2.vBegin), Orgcode);

                    string worktimeb = "";
                    string worktimee = "";
                    string noontimeb = "";
                    string noontimee = "";

                    if (ht != null && ht.Count > 0)
                    {
                        worktimeb = ht["WORKTIMEB"].ToString();
                        worktimee = ht["WORKTIMEE"].ToString();
                        noontimeb = ht["NOONTIMEB"].ToString();
                        noontimee = ht["NOONTIMEE"].ToString();
                        offday = Convert.ToBoolean(ht["OFFDAY"].ToString());
                    }
                    else
                    {
                        throw new FlowException("無班表資料!");
                    }

                    int beginWorkerTimeHour = int.Parse(worktimeb.Substring(0, 2));
                    int beginWorkerTimeMinute = int.Parse(worktimeb.Substring(2));
                    int endWorkerTimeHour = int.Parse(worktimee.Substring(0, 2));
                    int endWorkerTimeMinute = int.Parse(worktimee.Substring(2));

                    int beginNoonRestTimeHour = int.Parse(noontimeb.Substring(0, 2));
                    int beginNoonRestTimeMinute = int.Parse(noontimeb.Substring(2));
                    int endNoonRestTimeHour = int.Parse(noontimee.Substring(0, 2));
                    int endNoonRestTimeMinute = int.Parse(noontimee.Substring(2));

                    cr2.vBegin = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0);
                    cr2.vEnd = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second);

                    cr3.vBegin = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0);
                    cr3.vEnd = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second);

                }
                catch (FlowException fex)
                {
                    throw new FlowException(fex.Message);
                }
                catch (Exception ex)
                {
                    cr2.vBegin = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 8, 0, 0);
                    cr2.vEnd = new DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second);

                    cr3.vBegin = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 13, 30, 0);
                    cr3.vEnd = new DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second);
                }


                string taiwanDate = (int.Parse(cr2.vBegin.ToString("yyyy")) - 1911).ToString() + cr2.vBegin.ToString("MMdd");


                if (!offday)
                {
                    minutesAday = FSC.Logic.Content.getIntersectionMinutes(cr1, cr2) + FSC.Logic.Content.getIntersectionMinutes(cr1, cr3);

                    if (minutesAday > 480)
                        minutesAday = 480;
                    minutes += minutesAday;
                }

                if (cr2.vBegin.Date.Equals(vEnd.Date))
                    break; // TODO: might not be correct. Was : Exit Do

                cr2.vBegin = cr2.vBegin.AddDays(1);
                cr2.vEnd = cr2.vEnd.AddDays(1);
                cr3.vBegin = cr3.vBegin.AddDays(1);
                cr3.vEnd = cr3.vEnd.AddDays(1);

                count++;

            } while (true);

        }
        catch (Exception fex)
        {
            throw new FlowException(fex.Message);
        }

        hours = minutes  / 60;

        return hours;

    }
  

    // WSMOB005
    // 公差申請
    [WebMethod]
    public string WSMOB005
    (
          bool isUpdate         // 新增或更新判斷
        , string Requestfid     // 傳入之 fid
        , string OrgCode        // Org Code
        , string strLeaveType   // 假別
        , string transport      // 交通工具
        , string Depart_id      // 申請人單位代碼
        , string Apply_id       // 申請人IDCard
        , string Apply_name     // 申請人NAME
        , string Apply_posid
        , string Apply_stype
        , string DeputyDepartid // 代理之 Depart ID
        , string DeputyIdcard   // 代理人之 ID Card
        , string DeputyName
        , string DeputyPosid

        , string WriterIdcard    // 處理人員
        , string WriterName      // 處理人員姓名
        , string WriterPosid     // 處理人員TitleNO
        , string reason          // 理由
        , string Place           //工差明細地點
        , string LocationFlag    // 公差地點

        , string Start_date      // 起價開始日期
        , string End_date        // 請假結束日期
        , string Start_time      // 請假開始時間
        , string End_time        // 請假結束時間
        , string HStart_date     // 假日執行公務開始日期
        , string HEnd_date       // 假日執行公務結束日期
        , string HStart_time     // 假日執行公務開始時間
        , string HEnd_time       // 假日執行公務結束時間
        , string PlaceCity       // 城市
        , string TransportDesc   // 搭乘高鐵或飛機之理由說明
        , bool hcbx              //假日執行公務時間
        )
    {
        string strResult = "";
        string fid = "";
        try
        {
            using (TransactionScope trans = new TransactionScope())
            {

                fid = (isUpdate ? Requestfid : new SYS.Logic.FlowId().GetFlowId(OrgCode, "001003", Convert.ToInt32(strLeaveType)));

                // 交通工具部分
                // 前端組合好後送
                List<LeaveMain> lmList = new List<LeaveMain>();
                // 一定是 C1
                // 因為只做一次申請
                FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
                lm.FlowId = fid;
                lm.Orgcode = OrgCode;
                lm.DepartId = Depart_id;
                lm.IdCard = Apply_id;
                lm.UserName = Apply_name;
                lm.LeaveGroup = "C";
                lm.LeaveNgroup = "C1";
                lm.LeaveType = strLeaveType;
                lm.LocationFlag = LocationFlag;
                lm.Place = Place;
                if (LocationFlag == "0")
                {
                    lm.PlaceCity = PlaceCity;
                }
                lm.Transport = transport;
                lm.TransportDesc = TransportDesc;
                lm.Change_userid = WriterIdcard;
                lm.Change_date = System.DateTime.Now;

         //       int hours = FSC.Logic.Content.computeNotWorkHour(Start_date, End_date, Start_time, End_time, Apply_id);
                int hours = computeNotWorkHour(Start_date, End_date, Start_time, End_time, Apply_id, OrgCode);

                lm.StartDate = Start_date;
                lm.EndDate = End_date;
                lm.StartTime = Start_time;
                lm.EndTime = End_time;
                lm.LeaveHours = hours;

                if (hcbx)
                {
           //         int hhours = FSC.Logic.Content.computeHolidayWorkHour(HStart_date, HEnd_date, HStart_time, HEnd_time, Apply_id);
                    int hhours = computeHolidayWorkHour(HStart_date, HEnd_date, HStart_time, HEnd_time, Apply_id, OrgCode);
                    lm.HolidayOfficalFlag = "1";
                    lm.HolidayDateb = HStart_date;
                    lm.HolidayDatee = HEnd_date;
                    lm.HolidayTimeb = HStart_time;
                    lm.HolidayTimee = HEnd_time;
                    lm.HolidayHours = hhours;
                    reason = "「假日執行公務」" + hhours + "小時，" + reason;
                }
                lm.Reason = reason;
                lmList.Add(lm);
              

                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.FlowId = fid;
                f.Orgcode = OrgCode;
                f.DepartId = Depart_id;
                f.ApplyIdcard = Apply_id;
                f.ApplyName = Apply_name;
                f.ApplyPosid = Apply_posid;
                f.ApplyStype = Apply_stype;


                f.DeputyOrgcode = OrgCode;
                f.DeputyDepartid = DeputyDepartid;
                f.DeputyIdcard = DeputyIdcard;
                f.DeputyName = DeputyName;
                f.DeputyPosid = DeputyPosid;

                f.WriterOrgcode = OrgCode;
                f.WriterDepartid = Depart_id;
                f.WriterIdcard = WriterIdcard;
                f.WriterName = WriterName;
                f.WriterPosid = WriterPosid;
                f.WriteTime = System.DateTime.Now;
                f.FormId = "001003";
                f.Reason = reason;
                f.ChangeUserid = WriterIdcard;
                
                if (isUpdate)
                {
                    f.CaseStatus = 2;
                    f.Update();
                    foreach (LeaveMain lm2 in lmList)
                    {
                        lm2.UpdateLeaveMain();
                    }
                }
                else
                {
                    SYS.Logic.CommonFlow.AddFlow(f, lmList);
                }

                trans.Complete();
            }

            //如果交易成功寄送email
            //先 MArk 
            //	        SendNotice.send(OrgCode, fid);
            /*
            if (isUpdate) {
                CommonFun.MsgShow(this, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx");
            } else {
                CommonFun.MsgShow(this, CommonFun.Msg.InsertOK, , "../FSC1/FSC1102_01.aspx");
            }
             */

        }
        catch (FlowException fex)
        {

            AppException.WriteErrorLog(fex.StackTrace, fex.Message);
            //	        CommonFun.MsgShow(this, CommonFun.Msg.Custom, fex.Message());
            strResult = "{" + buildJSONErr(fex.Message) + "}";
            return strResult;
            //                        return false;

        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            strResult = "{" + buildJSONErr(ex.Message) + "}";
            return strResult;
            //  CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
        }

        strResult =
           "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "已送出申請!" + "\"";
        /*
            ",\"Id_card\":\"" + psn.IdCard + "\"" +
            ",\"User_name\":\"" + psn.UserName + "\"" +
            ",\"Employee_type\":\"" + psn.EmployeeType + "\"" +
            ",\"Employee_type_name\":\"" + "" + "\"" +
            ",\"Boss_level_id\":\"" + psn.Boss_level_id + "\"" +
            ",\"Role_id\":\"" + psn.RoleId + "\"" +
            ",\"AD_ID\":\"" + psn.ADId + "\"";
         */

        return "{" + strResult + "}";
        //        return true;
    }

    // WSMOB005
    // 公差申請
    [WebMethod]
    public string WSMOB005_1
    (
          bool isUpdate         // 新增或更新判斷
        , string Requestfid     // 傳入之 fid
        , string OrgCode        // Org Code
        , string strLeaveType   // 假別
        , string transport      // 交通工具
        , string Depart_id      // 申請人單位代碼
        , string Apply_id       // 申請人IDCard
        , string Apply_name     // 申請人NAME
        , string Apply_posid
        , string Apply_stype
        , string DeputyDepartid // 代理之 Depart ID
        , string DeputyIdcard   // 代理人之 ID Card
        , string DeputyName
        , string DeputyPosid

        , string WriterIdcard    // 處理人員
        , string WriterName      // 處理人員姓名
        , string WriterPosid     // 處理人員TitleNO
        , string reason          // 理由
        , string Place           //工差明細地點
        , string LocationFlag    // 公差地點

        , string Start_date      // 起價開始日期
        , string End_date        // 請假結束日期
        , string Start_time      // 請假開始時間
        , string End_time        // 請假結束時間
        , string HStart_date     // 假日執行公務開始日期
        , string HEnd_date       // 假日執行公務結束日期
        , string HStart_time     // 假日執行公務開始時間
        , string HEnd_time       // 假日執行公務結束時間
        , string PlaceCity       // 城市
        , string TransportDesc   // 搭乘高鐵或飛機之理由說明
        , bool hcbx              //假日執行公務時間
        , DataTable dt
        , string Id_card
        )
    {
        string strResult = "";
        string fid = "";
        try
        {
            using (TransactionScope trans = new TransactionScope())
            {

                fid = (isUpdate ? Requestfid : new SYS.Logic.FlowId().GetFlowId(OrgCode, "001003", Convert.ToInt32(strLeaveType)));

                List<LeaveMain> lmList = new List<LeaveMain>();
                // 一定是 C1
                // 因為只做一次申請
                FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
                lm.FlowId = fid;
                lm.Orgcode = OrgCode;
                lm.DepartId = Depart_id;
                lm.IdCard = Apply_id;
                lm.UserName = Apply_name;
                lm.LeaveGroup = "C";
                lm.LeaveNgroup = "C1";
                lm.LeaveType = strLeaveType;
                lm.Change_userid = WriterIdcard;
                lm.Change_date = System.DateTime.Now;
                //       int hours = FSC.Logic.Content.computeNotWorkHour(Start_date, End_date, Start_time, End_time, Apply_id);       
                int hours = computeNotWorkHour(Start_date, End_date, Start_time, End_time, Apply_id, OrgCode);
                lm.StartDate = Start_date;
                lm.EndDate = End_date;
                lm.StartTime = Start_time;
                lm.EndTime = End_time;
                lm.LeaveHours = hours;

                if (hcbx)
                {
                    //         int hhours = FSC.Logic.Content.computeHolidayWorkHour(HStart_date, HEnd_date, HStart_time, HEnd_time, Apply_id);
                    int hhours = computeHolidayWorkHour(HStart_date, HEnd_date, HStart_time, HEnd_time, Apply_id, OrgCode);
                    lm.HolidayOfficalFlag = "1";
                    lm.HolidayDateb = HStart_date;
                    lm.HolidayDatee = HEnd_date;
                    lm.HolidayTimeb = HStart_time;
                    lm.HolidayTimee = HEnd_time;
                    lm.HolidayHours = hhours;
                    reason = "「假日執行公務」" + hhours + "小時，" + reason;
                }

                lm.LocationFlag = LocationFlag;
                lm.Place = "";
                /*      if (LocationFlag == "0")
                      {
                          lm.PlaceCity = PlaceCity;
                      }
                      lm.Transport = transport;
                      lm.TransportDesc = TransportDesc;                        
                */
                lm.Reason = reason;
                lmList.Add(lm);

                LeaveMainDetail lmd = new LeaveMainDetail();
                lmd.Flow_id = fid;
                lmd.delete();

                foreach (DataRow dr in dt.Rows)
                {
                    lmd = new LeaveMainDetail();
                    lmd.Flow_id = fid;
//                    lmd.Leave_date = dr["leave_date"].ToString();
/*
                    if (LocationFlag == "0")
                    {
                        lmd.city = dr["City"].ToString();
                    }
 */
                    lmd.Start_date = dr["Start_date"].ToString();
                    lmd.End_date = dr["End_date"].ToString();
                    lmd.Start_place = dr["Start_place"].ToString();
                    lmd.End_place = dr["End_place"].ToString();
                    lmd.DetailPlace = dr["DetailPlace"].ToString();
                    lmd.Transport = dr["Transport"].ToString();
                    lmd.Transport_desc = dr["Transport_Desc"].ToString();
                    lmd.Reason = dr["Reason"].ToString();
                    lmd.Change_userid = Id_card;

                    lmd.insert();
                    /*
                For Each dr As DataRow In dt.Rows
                    lmd = New LeaveMainDetail
                    lmd.Flow_id = fid
                    lmd.Start_date = dr("Start_date").ToString()
                    lmd.End_date = dr("End_date").ToString()
                    'If rblLocationFlag.SelectedValue = "0" Then
                    '    lmd.city = dr("City").ToString()
                    'End If
                    lmd.Start_place = dr("Start_place").ToString()
                    lmd.End_place = dr("End_place").ToString()
                    lmd.DetailPlace = dr("DetailPlace").ToString()
                    lmd.Transport = dr("Transport").ToString()
                    lmd.Transport_desc = dr("Transport_Desc").ToString()
                    lmd.Reason = dr("Reason").ToString()
                    lmd.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

                    lmd.insert()
                Next
                     */
                }

                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.FlowId = fid;
                f.Orgcode = OrgCode;
                f.DepartId = Depart_id;
                f.ApplyIdcard = Apply_id;
                f.ApplyName = Apply_name;
                f.ApplyPosid = Apply_posid;
                f.ApplyStype = Apply_stype;

                f.DeputyOrgcode = OrgCode;
                f.DeputyDepartid = DeputyDepartid;
                f.DeputyIdcard = DeputyIdcard;
                f.DeputyName = DeputyName;
                f.DeputyPosid = DeputyPosid;

                f.WriterOrgcode = OrgCode;
                f.WriterDepartid = Depart_id;
                f.WriterIdcard = WriterIdcard;
                f.WriterName = WriterName;
                f.WriterPosid = WriterPosid;
                f.WriteTime = System.DateTime.Now;
                f.FormId = "001003";
                f.Reason = reason;
                f.ChangeUserid = WriterIdcard;

                /*    if (isUpdate)
                    {
                        f.CaseStatus = 2;
                        f.Update();
                        foreach (LeaveMain lm2 in lmList)
                        {
                            lm2.UpdateLeaveMain();
                        }
                    }
                    else
                    {*/
                SYS.Logic.CommonFlow.AddFlow(f, lmList);
                //     }

                trans.Complete();
            }

            //如果交易成功寄送email
            //先 MArk 
            //	        SendNotice.send(OrgCode, fid);
            /*
            if (isUpdate) {
                CommonFun.MsgShow(this, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx");
            } else {
                CommonFun.MsgShow(this, CommonFun.Msg.InsertOK, , "../FSC1/FSC1102_01.aspx");
            }
             */

        }
        catch (FlowException fex)
        {
            AppException.WriteErrorLog(fex.StackTrace, fex.Message);
            strResult = "{" + buildJSONErr(fex.Message) + "}";
            return strResult;

        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            strResult = "{" + buildJSONErr(ex.Message) + "}";
            return strResult;
        }

        strResult =
           "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "已送出申請!" + "\"";


        return "{" + strResult + "}";

    }

    [WebMethod]
    public DataTable WSMOB006_1(
          string Orgcode
        , string ID_card
        , string Year
        , string Month)
    {              

        DataTable sadt = new SAL1111().getSALData(Orgcode, ID_card, Year + Month);

        return sadt;
    }

    // WSMOB006_2
    // 加班費申請-新版
    // 2014/8/2 Eliot Chen
    [WebMethod]
    public string WSMOB006_2(
          string Orgcode    //
        , string ID_Card    //
        , string Year       //
        , string Month      //
        , string Limit      // 專案加班總時數
        , string fF1
        , string fF2
        , string Depart_id
        , string ApplyName
        , string ApplyPosid
        , string ApplyStype

/*      
        , string Status
        
        , string ym
        , string Apply_seq
        , string overtime_type
        , string overtime_date
        , string overtime_end_date
        , string Applytime_start
        , string Applytime_end
        , string Overtime_start
        , string Overtime_end
        , int PRADDH
        , string reason
        , string strModifyAccount
        , int Orig_applyhour
        , int Apply_hour
        , int Hour_pay   
*/
        , DataSet ds    // 各項 Grid 轉 DataSet 後傳入
        )
    {
        string strResult = "";

        DataTable dt=ds.Tables["data"];

        if (ds == null || ds.Tables == null) {
	        strResult = "{" + buildJSONErr("沒有申請資料") + "}";
            return strResult;
        }

        string YearMonth = Year + Month;
        int total_hours = 0;
        //加班總時數
        int project_total_hour = 0;
        //專案加班總時數
        int limit = CommonFun.getInt(Limit);
        //上限時數
//        bool isUpdate = false;
        string flow_id = "";
        StringBuilder TotalMsg = new StringBuilder();
        string formId = "002001";
        double F1 = CommonFun.ConvertToDouble(fF1);//hfF1.Value);
        double F2 = CommonFun.ConvertToDouble(fF2);//hfF2.Value);
        string PEMEMCOD = new FSC.Logic.Personnel().GetColumnValue("Employee_type", ID_Card);//hfPerId.Value);
        //職務類別
        int totalOvertimePay = 0;
        SAL1112 bll = new SAL1112();

        //set apply_hour to apply_hour_1, apply_hour_2, apply_hour_3
        // 移到前端處理
        //SetOtherApplyHours();

        try {
	        using (TransactionScope trans = new TransactionScope()) {
                flow_id = new SYS.Logic.FlowId().GetFlowId(Orgcode, formId);

//		        foreach (GridViewRow gvr in this.gvList.Rows) 
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    DataRow row=dt.Rows[i];
			        int hourPay = 0;
			        int totalSa = 0;
			        //月薪
			        double OvertimePay = 0;

			        string PRADDD = row["hfPRADDD"].ToString();   // ((HiddenField)gvr.FindControl("hfPRADDD")).Value;
			        int PRADDE = CommonFun.getInt(row["hfPRADDE"].ToString());   //((HiddenField)gvr.FindControl("hfPRADDE")).Value;
			        int PRADDH = CommonFun.getInt(row["lbPRADDH"].ToString());   //((Label)gvr.FindControl("lbPRADDH")).Text;
			        int PRPAYH = CommonFun.getInt(row["lbPRPAYH"].ToString());   //((Label)gvr.FindControl("lbPRPAYH")).Text;
			        string PRSTIME = row["hfPRSTIME"].ToString();   //((HiddenField)gvr.FindControl("hfPRSTIME")).Value;
			        string PRETIME = row["hfPRETIME"].ToString();   //((HiddenField)gvr.FindControl("hfPRETIME")).Value;
			        string PRATYPE = row["hfPRATYPE"].ToString();   //((HiddenField)gvr.FindControl("hfPRATYPE")).Value;
			        string REASON = row["lbPRREASON"].ToString();   //((Label)gvr.FindControl("lbPRREASON")).Text;

			        int applyHour1 = CommonFun.getInt(row["tbApplyHour1"].ToString());//  ((TextBox)gvr.FindControl("tbApplyHour1")).Text);
			        int applyHour2 = CommonFun.getInt(row["tbApplyHour2"].ToString());//((TextBox)gvr.FindControl("tbApplyHour2")).Text);
			        int applyHour3 = CommonFun.getInt(row["tbApplyHour3"].ToString());//((TextBox)gvr.FindControl("tbApplyHour3")).Text);

//			        if (((HiddenField)gvr.FindControl("hfCheckType")).Value == "1") {
			        if (row["hfCheckType"].ToString() == "1") {
				        PRATYPE = "1";
			        }

			        //檢核時數
			        string msg = "";

			        if (applyHour1 != 0 | applyHour2 != 0 | applyHour3 != 0) {
				        int tmp_hours = 0;
				        if (applyHour3 >= 1 & applyHour3 <= 8) {
					        tmp_hours += (applyHour1 + applyHour2 + 8);
				        } else {
					        tmp_hours += (applyHour1 + applyHour2 + applyHour3);
				        }

				        if (PRATYPE == "2") {
					        project_total_hour += tmp_hours;
					        //專案加班
				        } else if (PRATYPE == "1" & (PEMEMCOD.Equals("3") | PEMEMCOD.Equals("4") | PEMEMCOD.Equals("8"))) {
					        total_hours += tmp_hours;
					        //技工工友、臨時人員、駕駛一般加班要納入請領上限,大批加班不用納入請領上限
				        } else if (!(PEMEMCOD.Equals("3") | PEMEMCOD.Equals("4") | PEMEMCOD.Equals("8"))) {
					        total_hours += tmp_hours;
					        //人事人員一般加班、大批加班皆要納入請領上限
				        }

				        //msg = bll.CheckApplyHours(PRADDD, PRADDH, PRPAYH, applyHour1, applyHour2, applyHour3)

				        msg += bll.doUpdateDetailCheckInput(PRADDD, ID_Card, limit, total_hours, project_total_hour);
			        }


			        if (string.IsNullOrEmpty(msg)) {
				        //取申請時, 當下的月薪, 時薪
				        DataTable sadt = new SAL1111().getSALData(Orgcode, ID_Card, (CommonFun.getInt(Year) + 1911).ToString() + Month);
				        if (sadt != null && sadt.Rows.Count > 0) {
					        totalSa = CommonFun.getInt(sadt.Rows[0]["month_pay"].ToString());
					        hourPay = CommonFun.getInt(sadt.Rows[0]["BASE_HOUR_SAL"].ToString());
				        }

				        OvertimePay = bll.CountOvertimePay(applyHour1, applyHour2, applyHour3, F1, F2, totalSa, PEMEMCOD);

				        totalOvertimePay += CommonFun.getInt(OvertimePay);

				        bll.doDetailUpdate(Orgcode, Depart_id, YearMonth, ID_Card, PRADDD, PRSTIME, 
                            PRETIME, PRADDH, FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString(), applyHour1,
				        applyHour2, applyHour3, OvertimePay, REASON, flow_id);

			        } else {
				        TotalMsg.Append(msg).Append("\\n");
			        }
		        }

		        bll.doMasterUpdate(Orgcode, Depart_id, YearMonth, ID_Card, flow_id);

		        if (!string.IsNullOrEmpty(TotalMsg.ToString())) {
                    strResult=
                        "{" + buildJSONErr(TotalMsg.ToString()) + "}";
//			        CommonFun.MsgShow(this, CommonFun.Msg.Custom, TotalMsg.ToString());
//			        trans.Dispose();
			        return strResult;
		        }

		        SYS.Logic.Flow f = new SYS.Logic.Flow();
		        string flowReason = "請領加班費：" + totalOvertimePay.ToString() + "元";

			    f.FlowId = flow_id;
			    f.Orgcode = Orgcode;
			    f.DepartId = Depart_id;
			    f.ApplyIdcard = ID_Card;
			    f.ApplyName = ApplyName;
			    f.ApplyPosid = ApplyPosid;
			    f.ApplyStype = ApplyStype;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
			    f.WriterOrgcode = Orgcode;
			    f.WriterDepartid = Depart_id;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
			    f.WriterIdcard = ID_Card;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
			    f.WriterName = ApplyName;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
			    f.WriterPosid = ApplyPosid;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
			    f.WriteTime = System.DateTime.Now;
			    f.FormId = formId;
			    f.Reason = flowReason;
			    f.Budget_code = new SAL1112().GetLastBudget(ID_Card);
			    f.ChangeUserid = ID_Card;//LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                AppException.WriteErrorLog(
                    "[" + flow_id+"]"+
                    "[" + Orgcode+"]"+
                    "[" + Depart_id+"]"+
                    "[" + ApplyName+"]"+
                    "[" + ApplyPosid+"]"+
                    "[" + ApplyStype+"]"+
                    "[" + formId+"]"+
                    "[" + f.Budget_code+"]"
                    ,
                    
                    "Test Point 1");
			    SYS.Logic.CommonFlow.AddFlow(f);
                AppException.WriteErrorLog("Test Point 1", "Test Point 2");

		        trans.Complete();
	        }

	        //SendNotice.send(Orgcode, flow_id);

        } catch (FlowException fex) {
            strResult   =
                "{" + buildJSONErr(fex.Message.ToString()) + "}";
            return strResult;
//	        CommonFun.MsgShow(this, CommonFun.Msg.Custom, fex.Message());
        } catch (Exception ex) {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            strResult =
                "{" + buildJSONErr(CommonFun.Msg.SystemError.ToString()) + "}";
            return strResult;
            //CommonFun.MsgShow(this, CommonFun.Msg.SystemError.ToString());
        }

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + CommonFun.Msg.InsertOK.ToString() + "\"";

        return "{" + strResult + "}";

        return strResult;
    }




    // WSMOB006
    // 一般加班費申請
    [WebMethod]
    public string WSMOB006(
          string Orgcode
        , string ID_card
        , string Year
        , string Month
        , string Status
        , string Depart_id
        , string ym
        , string Apply_seq
        , string overtime_type
        , string overtime_date
        , string overtime_end_date
        , string Applytime_start
        , string Applytime_end
        , string Overtime_start
        , string Overtime_end
        , int PRADDH
        , string reason
        , string strModifyAccount
        , int Orig_applyhour
        , int Apply_hour
        , int Hour_pay
        )
    {
        string strResult = "";

        OvertimeFeeDetail ofd = new OvertimeFeeDetail();

        bool result = false;
    

        if (Status == "Add")
        {
            //新申請
            //請領時數為0時，不新增，前往下一筆
            if (Apply_hour <= 0)
            {
                /*       strResult =
                           "\"isSuccess\":\"Y\"";
                       strResult +=
                           ",\"message\":\"" + "請領時數為0時，不新增!" + "\"";


                       return "{" + strResult + "}"; */
            }
            else
            {
                result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Applytime_start, Applytime_end, Overtime_start,
                Overtime_end, PRADDH, Apply_hour, reason, strModifyAccount);
            }
        }
        else
        {
            //修改資料
            if (ofd.GetCount(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start) > 0)
            {  //存在明細檔裡              
                if (Apply_hour == 0)
                {
                    //請領時數為0時，刪除明細檔
                    result = ofd.DeleteOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start);
                }
                else
                {
                    //更新明細檔
                    result = ofd.UpdateApply_hour(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start, Apply_hour, strModifyAccount);
                }
            }
            else
            {   //不存在明細檔裡，新增明細檔

                //請領時數為0時，不新增，前往下一筆
                if (Apply_hour <= 0)
                {
                    /*           strResult =
                                   "\"isSuccess\":\"Y\"";
                               strResult +=
                                   ",\"message\":\"" + "請領時數為0時，不新增!" + "\"";
                    
                               return "{" + strResult + "}"; 
                     */
                }
                else
                {
                    result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Applytime_start, Applytime_end, Overtime_start,
                    Overtime_end, PRADDH, Apply_hour, reason, ID_card);
                }
            }
        }

        //更新回P2K
        result = new FSC.Logic.CPAPR18M().UpdatePRMNYH(ID_card, overtime_date, Overtime_start, Orig_applyhour, Apply_hour, Hour_pay, DateTime.Now.ToString("yyyyMMddHHmm"));

        strResult =
            "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "已送出申請!" + "\"";
        
        return "{" + strResult + "}";
        
    }


    // WSMOB044
    // 加班費請領 Master Part
    [WebMethod]
    public string WSMOB044(
         string flow_id
        , bool isUpdate
        , string Request_fid
        , string Orgcode
        , string budget_type
        , string ID_card
        , string Status
        , string Depart_id
        , string ym
        , string Apply_seq
        , string strModifyAccount
        , int Normal_hour
        , int Project_hour
        , int Monthly_pay
        , int Hour_pay
        , string ApplyName
        , string ApplyPosid
        , string ApplyStype
        , string Account
        )
    {
        bool result = false;
        string strResult = "";

        SYS.Logic.Flow f = new SYS.Logic.Flow();
        flow_id = (isUpdate ? Request_fid : new SYS.Logic.FlowId().GetFlowId(Orgcode, "002001"));
        budget_type = new SAL1111().GetLastBudget(ID_card);

        OvertimeFeeMaster ofm = new OvertimeFeeMaster();

        if (Status == "Add")
        {
            //新申請
            result = ofm.InsertOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, budget_type, Normal_hour, Project_hour, Monthly_pay, Hour_pay,
            "N", flow_id);
        }
        else
        {
            result = ofm.UpdateOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, Normal_hour, Project_hour, Monthly_pay, Hour_pay);
        }

        f.FlowId = flow_id;
        f.Orgcode = Orgcode;
        f.DepartId = Depart_id;
        f.ApplyIdcard = ID_card;
        f.ApplyName = ApplyName;
        f.ApplyPosid = ApplyPosid;
        f.ApplyStype = ApplyStype;
        f.WriterOrgcode = Orgcode;
        f.WriterDepartid = Depart_id;
        f.WriterIdcard = Account;
        f.WriterName = ApplyName;
        f.WriterPosid = ApplyPosid;
        f.WriteTime = System.DateTime.Now;
        f.FormId = "002001";
        f.Reason = "";
        f.Budget_code = budget_type;
        f.ChangeUserid = strModifyAccount;

        if (isUpdate)
        {
            f.CaseStatus = 2;
            f.Update();
        }
        else
        {
            SYS.Logic.CommonFlow.AddFlow(f);
        }

        strResult =
           "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "已送出申請!" + "\"";


        return "{" + strResult + "}";

    }

    /*
    [WebMethod]
    public string WSMOB006(
        System.Web.UI.WebControls.GridView gv
        , string Orgcode
        , string Depart_id
        , string ID_card
        , string Year
        , string Month
        , string ym
        , string Status
        , string Apply_seq
        , string strModifyAccount
        , int hfX
        , int hfB
        , bool isUpdate
        , string Request_fid
        )
    {

        
        string strResult = "";
        OvertimeFeeMaster ofm = new OvertimeFeeMaster();
        OvertimeFeeDetail ofd = new OvertimeFeeDetail();
        bool result = false;
        string flow_id;
        int PRADDH = 0;
        int PRPAYH = 0;
        int PRMNYH = 0;
        int hours = 0;
        int Apply_hour = 0;
        string overtime_type = null;
        string overtime_date = null;
        string overtime_end_date = null;
        string Applytime_start = null;
        string Applytime_end = null;
        string Overtime_start = null;
        string Overtime_end = null;
        string reason = null;
        string budget_type = string.Empty;
        int Normal_hour = 0;
        int Project_hour = 0;
        int Monthly_pay = 0;
        int Hour_pay = 0;
        int Orig_applyhour = 0;

        try
        {
            using (TransactionScope trans = new TransactionScope())
            {

                DataTable sadt = new SAL1111().getSALData(Orgcode, ID_card, Year + Month);
                if (sadt != null && sadt.Rows.Count > 0)
                {
                    Monthly_pay = CommonFun.ConvertToInt(sadt.Rows[0]["month_pay"].ToString());
                    Hour_pay = CommonFun.ConvertToInt(sadt.Rows[0]["BASE_HOUR_SAL"].ToString());
                }


                foreach (System.Web.UI.WebControls.GridViewRow gvr in gv.Rows)
                {
                    PRADDH = CommonFun.ConvertToInt(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDH")).Text.Trim());
                    //加班時數
                    PRPAYH = CommonFun.ConvertToInt(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRPAYH")).Text.Trim());
                    //已休時數
                    PRMNYH = CommonFun.ConvertToInt(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRMNYH")).Text.Trim());
                    //已領時數
                    overtime_type = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRATYPE")).Text.Trim();
                    //加班類別
                    overtime_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDD")).Text.Trim();
                    //加班日期
                    overtime_end_date = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRADDE")).Text.Trim();
                    //加班日期迄
                    Applytime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbStart_time")).Text.Replace(":", "");
                    //加班申請時間起
                    Applytime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbEnd_time")).Text.Replace(":", "");
                    //加班申請時間迄
                    Overtime_start = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRSTIME")).Text.Trim();
                    //加班時間起
                    Overtime_end = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRETIME")).Text.Trim();
                    //加班時迄
                    reason = ((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbPRREASON")).Text.Trim();
                    //事由

                    Orig_applyhour = CommonFun.ConvertToInt(((System.Web.UI.WebControls.Label)gvr.FindControl("gv_lbApply_hour")).Text.Trim());

                    hours = CommonFun.ConvertToInt(((System.Web.UI.WebControls.DropDownList)gvr.FindControl("gv_ddlApply_hour")).Text.Trim());
                    //請領時數

                    if (hours < 0)
                    {
                        //欲請領的時數小於零時
                        Apply_hour = hours + CommonFun.ConvertToInt(Orig_applyhour);

                    }
                    else if (hours > 0)
                    {
                        //欲請領的時數大於零時

                        Apply_hour = hours;

                    }
                    else if (hours == 0)
                    {
                        //欲請領的時數等於零時

                        Apply_hour = CommonFun.ConvertToInt(Orig_applyhour);

                    }

                    if (Apply_hour > PRADDH - PRPAYH - (PRMNYH - Apply_hour))
                    {
                        //				        CommonFun.MsgShow(this, CommonFun.Msg.Custom, "請領時數需小於等於(加班時數-已休時數-已領時數)");
                        return "{" + buildJSONErr("請領時數需小於等於(加班時數-已休時數-已領時數)") + "}";
                    }

                    if (overtime_type == "1")
                    {
                        Normal_hour += Apply_hour;
                        //一般時數請領加總
                    }
                    else if (overtime_type == "2")
                    {
                        Project_hour += Apply_hour;
                        //專案時數請領加總
                    }

                    if (Status == "Add")
                    {
                        //新申請

                        //請領時數為0時，不新增，前往下一筆
                        if (Apply_hour <= 0)
                            continue;

                        result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Applytime_start, Applytime_end, Overtime_start,
                        Overtime_end, PRADDH, Apply_hour, reason, strModifyAccount);
                    }
                    else
                    {
                        //修改資料

                        if (ofd.GetCount(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start) > 0)
                        {
                            //存在明細檔裡

                            if (Apply_hour == 0)
                            {
                                //請領時數為0時，刪除明細檔
                                result = ofd.DeleteOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start);
                            }
                            else
                            {
                                //更新明細檔
                                result = ofd.UpdateApply_hour(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start, Apply_hour, strModifyAccount);
                            }

                        }
                        else
                        {
                            //不存在明細檔裡，新增明細檔

                            //請領時數為0時，不新增，前往下一筆
                            if (Apply_hour <= 0)
                                continue;

                            result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Applytime_start, Applytime_end, Overtime_start,
                            Overtime_end, PRADDH, Apply_hour, reason, ID_card);
                        }
                    }

                    //更新回P2K
                    result = new FSC.Logic.CPAPR18M().UpdatePRMNYH(ID_card, overtime_date, Overtime_start, Orig_applyhour, Apply_hour, Hour_pay, DateTime.Now.ToString("yyyyMMddHHmm"));

                }

                if (Normal_hour > 20)
                {
                    return "{" + buildJSONErr("超過一般加班上限!") + "}";
                    //			        CommonFun.MsgShow(this, CommonFun.Msg.Custom, "超過一般加班上限!");
                    //			        trans.Dispose();
                    //			        return;
                }

                if (Project_hour > hfX)
                {
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "超過專案加班上限!");
                    //trans.Dispose();
                    //return;
                    return "{" + buildJSONErr("超過專案加班上限!") + "}";
                }

                if (Normal_hour + Project_hour > hfB)
                {
                    //CommonFun.MsgShow(this, CommonFun.Msg.Custom, "超過每月請領加班上限!");
                    //trans.Dispose();
                    //return;
                    return "{" + buildJSONErr("超過每月請領加班上限!") + "}";
                }

                SYS.Logic.Flow f = new SYS.Logic.Flow();
                flow_id = (isUpdate ? Request_fid : new SYS.Logic.FlowId().GetFlowId(Orgcode, "002001"));
                budget_type = new SAL1111().GetLastBudget(ID_card);

                if (Status == "Add")
                {
                    //新申請
                    result = ofm.InsertOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, budget_type, Normal_hour, Project_hour, Monthly_pay, Hour_pay,
                    "N", flow_id);
                }
                else
                {
                    result = ofm.UpdateOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, Normal_hour, Project_hour, Monthly_pay, Hour_pay);
                }

                f.FlowId = flow_id;
                f.Orgcode = Orgcode;
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.ApplyIdcard = ID_card;
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                f.WriterOrgcode = Orgcode;
                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                f.WriteTime = System.DateTime.Now;
                f.FormId = "002001";
                f.Reason = "";
                f.Budget_code = budget_type;
                f.ChangeUserid = strModifyAccount;

                if (isUpdate)
                {
                    f.CaseStatus = 2;
                    f.Update();
                }
                else
                {
                    SYS.Logic.CommonFlow.AddFlow(f);
                }

                trans.Complete();

            }

            // 先 Mark 這個
            //	        SendNotice.send(Orgcode, flow_id);

            strResult =
               "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"" + "已送出申請!" + "\"";


            return "{" + strResult + "}";



            //CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請列印加班單明細!", "../../FSC/FSC0/FSC0101_01.aspx")
            //Bind()
        }
        catch (FlowException fex)
        {
            return "{" + buildJSONErr(fex.Message) + "}";
            //	        CommonFun.MsgShow(this, CommonFun.Msg.Custom, fex.Message());
        }
        catch (Exception ex)
        {
            //	        CommonFun.MsgShow(this, CommonFun.Msg.SystemError);
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            return "{" + buildJSONErr(ex.Message) + "}";
        }


        //return strResult;
    }
     * */

    //WSMOB007
    // 加班費申請(勞基法)
    [WebMethod]
    public string WSMOB007(  
        string PRADDD, 
        int PRADDH,
        int PRPAYH, 
        int Apply_Hour_1, 
        int Apply_Hour_2, 
        int Apply_Hour_3
        ,string Id_Card
        , int limit
        , int total_hours
        , int project_total_hour
        )
    {

        string msg = "";
                    SAL1112 bll = new SAL1112();
                    msg = bll.CheckApplyHours(PRADDD, PRADDH, PRPAYH, Apply_Hour_1, Apply_Hour_2, Apply_Hour_3);
                    msg += bll.doUpdateDetailCheckInput(PRADDD, Id_Card, limit, total_hours, project_total_hour);
                           
                    return msg;
    }

    [WebMethod]
    public DataTable WSMOB007_1(
        string Orgcode,
     string Id_Card,
        string ym
        )
    {

      DataTable dt =  new SAL1111().getSALData(Orgcode, Id_Card, ym);
        return dt;
    }

    [WebMethod]
    public double WSMOB007_2(
        int Apply_Hour_1,
        int Apply_Hour_2,
        int Apply_Hour_3
        , double F1
        , double F2
        , int total_sa
        , string PEMEMCOD
        , string hdOrgcode
        , string hdDepart_id
        , string YearMonth
        , string hdPerId
        , string PRADDD
        , string PRSTIME
        , string PRETIME
        , int PRADDH
        , string REASON
        , string flow_id
        )
    {

      
        double Overtime_Pay=0;
        SAL1112 bll = new SAL1112();
      
        Overtime_Pay = bll.CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, total_sa, PEMEMCOD)    ;           

        bll.doDetailUpdate(hdOrgcode, hdDepart_id, YearMonth, hdPerId, PRADDD, PRSTIME, PRETIME, PRADDH,
                            FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd").ToString(), Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay, REASON, flow_id);

        return Overtime_Pay;
    }



    [WebMethod]
    public string WSMOB045(string Orgcode)
    {
        return new SYS.Logic.FlowId().GetFlowId(Orgcode, "002014");
    }


    [WebMethod]
    public string WSMOB046(
        string flow_id,
        string Orgcode,
        string DepartId,
        string Id_Card,
        string User_name,
        string Title_no,
        string Service_type,
        string Account,
        string formId,
        string flowReason
        )
    {
        string strResult = "";
        try
        {

        SYS.Logic.Flow f = new SYS.Logic.Flow();
        f.FlowId = flow_id;
        f.Orgcode = Orgcode;
        f.DepartId = DepartId;
        f.ApplyIdcard = Id_Card;
        f.ApplyName = User_name;
        f.ApplyPosid = Title_no;
        f.ApplyStype = Service_type;
        f.WriterOrgcode = Orgcode;
        f.WriterDepartid = DepartId;
        f.WriterIdcard = Account;
        f.WriterName = User_name;
        f.WriterPosid = Title_no;
        f.WriteTime = System.DateTime.Now;
        f.FormId = formId;
        f.Reason = flowReason;
        f.Budget_code = new SAL1112().GetLastBudget(Id_Card);
        f.ChangeUserid = Account;
             
        SYS.Logic.CommonFlow.AddFlow(f);
        
        }
        catch (FlowException fex)
        {
            AppException.WriteErrorLog(fex.StackTrace, fex.Message);
            strResult = "{" + buildJSONErr(fex.Message) + "}";
            return strResult;
        }
        catch (Exception ex)
        {
            AppException.WriteErrorLog(ex.StackTrace, ex.Message);
            strResult = "{" + buildJSONErr(ex.Message) + "}";
            return strResult;
        }

         strResult =
           "\"isSuccess\":\"Y\"";
        strResult +=
            ",\"message\":\"" + "已送出申請!" + "\"";
        
        return "{" + strResult + "}";

    }
    

    // WSMOB008
    // 出勤異常記錄查詢
    [WebMethod]
    public DataTable WSMOB008
        (
        string orgcode,
        string departid,
        string Apply_name,
        string Apply_idcard,
        string Start_date,
        string End_date,
        string Quit_job_flag,
        string PESEX,
        string Employee_type,
        string type
        )
    {
        string Leavehours = "";
        FSC2102 fsc2102 = new FSC2102();
        //        DataTable dt = fsc2102.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type);
        string yyymm = "";
        DataTable dt, tmpdt;

  //      if (Start_date.Substring(0, 5) == End_date.Substring(0, 5))
  //      {
        dt = fsc2102.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, type);//Start_date.Substring(0, 5));
  //      }
  //      else
  //      {
  //          System.DateTime S = System.DateTime.Parse(Start_date.Substring(0, 3) + "/" + Start_date.Substring(3, 2) + "/" + "01");
  //          System.DateTime L = System.DateTime.Parse(End_date.Substring(0, 3) + "/" + End_date.Substring(3, 2) + "/" + "01");

  //          dt = fsc2102.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, type);//Start_date.Substring(0, 5));
  //          while (S < L)
  //          {
  //              S = S.AddMonths(1);
  //             yyymm = S.Year.ToString() + S.Month.ToString().PadLeft(2, '0');
  //              tmpdt = fsc2102.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, yyymm);
  //              dt.Merge(tmpdt);
  //          }
  //      }

        

        // 以下可能移出比較好
        string stag = "<span style='color:#FF8C00; text-decoration: underline;' class='Mobtext'>";
        string etag = "</span>";
        dt.Columns.Add("Leavehours");
        dt.Columns.Add("Leavetype");
        dt.Columns.Add("Absenthours");
        foreach (DataRow dr in dt.Rows)
        {
            DataTable dt2 = fsc2102.getQueryData2(dr["PKCARD"].ToString().Trim(), dr["PKWDATE"].ToString());

            //20140620 先mark 
            //If Not dr("PKWKTPE").Equals("已處理") And Not dr("PKWKTPE").Equals("正常") And dt2.Rows.Count = 0 Then  'Leave_main裡沒有請假資料
            //    dr("Absenthours") = 8
            //End If

            int hours = 0;

            foreach (DataRow dr2 in dt2.Rows)
            {
                hours += CommonFun.getInt(dr2["Leave_hours"].ToString());

                string lastPass = dr2["Last_pass"].ToString();
                if (lastPass == "1")
                {
                    stag = "";
                    etag = "";
                }

                if (!string.IsNullOrEmpty(dr["Leavetype"].ToString()))
                {
                    dr["Leavetype"] += "<br />";
                }
                if (!string.IsNullOrEmpty(dr["Leavehours"].ToString()))
                {
                    dr["Leavehours"] += "<br />";
                }

                dr["Leavetype"] += stag + dr2["leave_name"].ToString() + etag;
                dr["Leavehours"] += stag + dr2["Leave_hours"].ToString() + etag;
            }

            //20140620 先mark 
            //If Not String.IsNullOrEmpty(dr("Absenthours").ToString()) Then
            //    dr("Absenthours") = dr("Absenthours") & "<br />"
            //End If
            //If dr("PKWKTPE").Equals("已處理") Or dr("PKWKTPE").Equals("正常") Then
            //    dr("Absenthours") = dr("Absenthours") & 0
            //ElseIf dr("PKWKTPE").Equals("曠職") And dr("Leavetype") Is Nothing Then   '假單還沒有簽核完成
            //    dr("Absenthours") = 8
            //Else                                                                        '假單簽核完成
            //    dr("Absenthours") = 8 - hours
            //End If
        }


        /*
        foreach (DataRow dr in dt.Rows)
        {
            DataTable dt2 = fsc2102.getQueryData2(dr["PKCARD"].ToString().Trim(), dr["PKWDATE"].ToString());
            if (dt2.Rows.Count == 0)
            {
                dr["Absenthours"] = 8;
            }
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (dt2.Rows.Count != 1)
                {
                    if (!string.IsNullOrEmpty(dr["Leavetype"].ToString()))
                    {
                        dr["Leavetype"] = dr["Leavetype"].ToString() + "<br />";
                    }
                    dr["Leavetype"] = dr["Leavetype"].ToString() + dr2["leave_name"].ToString();


                    if (!string.IsNullOrEmpty(dr["Leavehours"].ToString()))
                    {
                        dr["Leavehours"] = dr["Leavehours"] + "<br />";
                    }

                    //same day
                    if (dr["PKWDATE"] == dr2["Start_date"] && dr["PKWDATE"] == dr2["End_date"])
                    {
                        Leavehours = Content.computeNotWorkHour(
                                dr2["Start_date"].ToString(), dr2["End_date"].ToString(), dr2["Start_time"].ToString(), dr2["End_time"].ToString(), dr2["Id_card"].ToString()).ToString();
                        dr["Leavehours"] = Convert.ToInt32(dr["Leavehours"].ToString()) +
                            Content.computeNotWorkHour(dr2["Start_date"].ToString(), dr2["End_date"].ToString(), dr2["Start_time"].ToString(), dr2["End_time"].ToString(),
                                dr2["Id_card"].ToString());
                    }
                    else
                    {
                        Hashtable ht = Content.getWorkTime(dr["PKCARD"].ToString(), dr["PKWDATE"].ToString());
                        //compute Id_card work hours

                        if (dr["PKWDATE"] == dr2["Start_date"])
                        {
                            Leavehours = Content.computeNotWorkHour(dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(), dr2["Start_time"].ToString(),
                                ht["WORKTIMEE"].ToString(), dr2["Id_card"].ToString()).ToString();

                            dr["Leavehours"] = Convert.ToInt32(dr["Leavehours"].ToString()) +
                                    Content.computeNotWorkHour(dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(),
                                    dr2["Start_time"].ToString(), ht["WORKTIMEE"].ToString(), dr2["Id_card"].ToString());


                        }
                        else if (Convert.ToInt32(dr["PKWDATE"].ToString()) > Convert.ToInt32(dr2["Start_date"].ToString()) &&
                            Convert.ToInt32(dr["PKWDATE"].ToString()) < Convert.ToInt32(dr2["End_date"].ToString()))
                        {
                            Leavehours = Content.computeNotWorkHour(dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(),
                                ht["WORKTIMEB"].ToString(), ht["WORKTIMEE"].ToString(), dr2["Id_card"].ToString()).ToString();
                            dr["Leavehours"] = Convert.ToInt32(dr["Leavehours"].ToString()) + Content.computeNotWorkHour(
                                dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(), ht["WORKTIMEB"].ToString(), ht["WORKTIMEE"].ToString(), dr2["Id_card"].ToString());

                        }
                        else if (dr["PKWDATE"] == dr2["End_date"])
                        {
                            Leavehours = Content.computeNotWorkHour(dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(),
                                ht["WORKTIMEB"].ToString(), dr2["End_time"].ToString(), dr2["Id_card"].ToString()).ToString();
                            dr["Leavehours"] = Convert.ToInt32(dr["Leavehours"].ToString()) +
                                Content.computeNotWorkHour(dr["PKWDATE"].ToString(), dr["PKWDATE"].ToString(), ht["WORKTIMEB"].ToString(),
                                dr2["End_time"].ToString(), dr2["Id_card"].ToString());
                        }
                    }

                    if (!string.IsNullOrEmpty(dr["Absenthours"].ToString()))
                    {
                        dr["Absenthours"] = dr["Absenthours"] + "<br />";
                    }
                    if (dr["PKWKTPE"].Equals("已處理") | dr["PKWKTPE"].Equals("正常"))
                    {
                        dr["Absenthours"] = Convert.ToInt32(dr["Absenthours"].ToString()) + 0;
                    }

                }
            }
            

        }
         * */
        return dt;

    }


    // WSMOIB010
    // 請假記錄查詢清單
    [WebMethod]
    //    public string WSMOB010
    public DataTable WSMOB010
    (
        string Orgcode,	    //組織代碼
        string Id_Card,//帳號
        string Depart_id,//單位代碼
        string User_name,//員工姓名
        string Id_card_q,//員工編號
        string Title_no,//職稱
        string Quit_job_flag,//在職狀態
        string PESEX,//性別
        string Start_date,//請假日期 - 起
        string End_date,//請假日期 - 迄
        string Leave_type,//假別 
        string Employee_type,//人員類別
        string Case_status,//狀態
        string Device_ID,	//裝置 Device ID
        string Auth_Code	//驗證碼
        ,string lastpass

        )
    {
        DataTable dt;
        FSC2103 fsc2103 = new FSC2103();
        // 取得資料
        dt = fsc2103.getQueryData(Orgcode, Depart_id, User_name, Id_card_q, Title_no, Quit_job_flag, PESEX, 
            Start_date, End_date, Leave_type,
                                  Employee_type, Case_status, lastpass);
        dt.Columns.Add("Process");
        foreach (DataRow dr in dt.Rows)
        {
            DataTable fd = new SYS.Logic.FlowDetail().GetDataByFlow_id(dr["orgcode"].ToString(), dr["flow_id"].ToString());
            foreach (DataRow ddr in fd.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Process"].ToString()))
                {
                    dr["Process"] = dr["Process"].ToString() + "<br />";
                }
                dr["Process"] = dr["Process"].ToString() + new SYS.Logic.CODE().GetFSCTitleName(ddr["Last_posid"].ToString()) + " " + ddr["Last_name"].ToString();
            }
        }

        return dt;


    }

    // WSMOB012
    // 加班記錄查詢
    [WebMethod]
    public DataTable WSMOB012
    (
        string Orgcode      // 組織代碼
        , string Depart_id  // 單位代碼
        , string PRCARD
        , string PRNAME
        , string PRADDD      // 開始時間
        , string PRADDE      // 結束時間
        , string Case_status    // 狀態
        , string lastpass
        )
    {
        FSC2105 fsc2105 = new FSC2105();
        DataTable dt;
        dt = fsc2105.getQueryData(Orgcode, Depart_id, PRCARD, PRNAME, "", PRADDD, PRADDE, Case_status, lastpass);
        dt.Columns.Add("Last_name");
        foreach (DataRow dr in dt.Rows)
        {
            dr["Last_name"] = "";
            DataTable fd = new SYS.Logic.FlowDetail().GetDataByFlow_id(Orgcode, dr["flow_id"].ToString());
            foreach (DataRow ddr in fd.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Last_name"].ToString()))
                {
                    dr["Last_name"] = dr["Last_name"].ToString() + "<br />";
                }
                dr["Last_name"] = dr["Last_name"].ToString() + new SYS.Logic.CODE().GetFSCTitleName(ddr["Last_posid"].ToString()) + " " + ddr["Last_name"].ToString();
            }
        }

        return dt;

    }


    [WebMethod]
    public DataTable WSMOB012_1
    (
        string Orgcode      
        , string flow_id        
        )
    {
      
        DataTable dt;
        dt = new SYS.Logic.FlowDetail().GetDataByFlow_id(Orgcode, flow_id);
        return dt;

    }


    [WebMethod]
    public string WSMOB012_2
    (
        string Last_posid
        )
    {      
        return new SYS.Logic.CODE().GetFSCTitleName(Last_posid);
    }



    // WSMOB014
    // 公差記錄查詢
    [WebMethod]
    public DataTable WSMOB014
    (
        string orgcode,     // 組織代碼
        string departid,    // 單位代碼
        string Apply_name,  //員工姓名
        string Apply_idcard,//員工編號  
        string Start_date,  // 日期 - 起
        string End_date,    // 日期 - 迄
        string Leave_type,  // 公差類型
        string status       // 狀態
        ,string lastpass
        ,string PESEX
        , string Quit_job_flag
        )
    {
        FSC2104 fsc2014 = new FSC2104();
        DataTable dt = fsc2014.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Quit_job_flag, PESEX,
            Start_date, End_date, Leave_type, status , lastpass);

        dt.Columns.Add("Last_name");
        foreach (DataRow dr in dt.Rows)
        {
            dr["Last_name"] = "";
            DataTable fd = new SYS.Logic.FlowDetail().GetDataByFlow_id(orgcode, dr["flow_id"].ToString());
            foreach (DataRow ddr in fd.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Last_name"].ToString()))
                {
                    dr["Last_name"] = dr["Last_name"].ToString() + "<br />";
                }
                dr["Last_name"] = dr["Last_name"].ToString() +
                    new SYS.Logic.CODE().GetFSCTitleName(ddr["Last_posid"].ToString()) + " " + ddr["Last_name"].ToString();
            }
        }


        return dt;
    }

    // WSMOB16
    // 回傳 OrgCode 下所有單位資料
    [WebMethod]
    public DataTable WSMOB016(
        string ParentId,    // 父代碼
        string Orgcode,	    //組織代碼-無用
        string Id_Card,	    //員工編號-無用
        string Device_ID,	//裝置 Device ID-無用
        string Auth_Code	//驗證碼-無用
        )
    {
        DataTable dt;
        FSCORG1DAO fdao = new FSCORG1DAO();
        dt = fdao.GetDataByParentid(ParentId).Tables[0];
        return dt;
        /*
        string strResult = "";
        // 驗證碼檢查
        if (!chackAuth(""))
        {
            strResult = "{" + "驗證碼錯誤" + "}";
            return strResult;
        }
        // 裝置檢查
        if (!chackIDandDvice(Id_Card, Device_ID))
        {
            strResult = "{" + "裝置未完成註冊" + "}";
            return strResult;
        }

        // 取得資料
        DataTable dt = EMPCommon.getFscOrg(Orgcode);
        if (dt.Rows.Count > 0)
        {
            strResult =
                "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"資料筆數:" + dt.Rows.Count.ToString() + "\"";
            string strData = "";
            strData = DataTableToJsonString(dt);
            strResult = "{" + strResult + "," + strData + "}";
            return strResult;
        }
        else
        {
            // 查無資料
            strResult = "{" + buildJSONErr(strNoData) + "}";
            return strResult;
        }
         */

    }

    // WSMOB017
    // 回傳單位下人員清單
    [WebMethod]
    public DataTable WSMOB017(
        string Orgcode,	    //組織代碼
        string DeptID,	    //單位代碼
        string Id_Card,	    //員工編號
        string Device_ID,	//裝置 Device ID
        string Auth_Code	//驗證碼
        )
    {
        DataTable dt;
        FSC.Logic.Member member = new FSC.Logic.Member();
        dt = member.GetDataByOrgDep(Orgcode, DeptID);
        return dt;
        /*
        string strResult = "";
        // 驗證碼檢查
        if (!chackAuth(""))
        {
            strResult = "{" + buildJSONErr("驗證碼錯誤") + "}";
            return strResult;
        }
        // 裝置檢查
        if (!chackIDandDvice(Id_Card, Device_ID))
        {
            strResult = "{" + buildJSONErr("裝置未完成註冊") + "}";
            return strResult;
        }
        // 取得資料
        DataTable dt = EMPCommon.getSaBaseBasic(Orgcode, DeptID);
        if (dt.Rows.Count > 0)
        {
            strResult =
                "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"資料筆數:" + dt.Rows.Count.ToString() + "\"";
            string strData = "";
            strData = DataTableToJsonString(dt);
            strResult = "{" + strResult + "," + strData + "}";
            return strResult;
        }
        else
        {
            // 查無資料
            strResult = "{" + buildJSONErr(strNoData) + "}";
            return strResult;
        }
         * */


    }

    // WSMOB018
    // 取得假別清單
    [WebMethod]
    public DataTable WSMOB018()
    {
        DataTable dt;
        dt = new SYS.Logic.LeaveType().GetData("15");
        return dt;
    }


    public string GetLimitDesc(string Apply_id, string Leave_type, string UcDate, int target, int BabyDays, Boolean withoutTexDesc, string Orgcode)
    {
        if (Apply_id == "")
        {
            return "";
        }
        Personnel psn = new Personnel().GetObject(Apply_id);
        if (psn == null)
        {
            return string.Empty;
        }

        FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();

            Double Limitdays   = 0.0;
            int hours  = 0;
            Double Leftdays = 0.0;
            string employeeType = psn.EmployeeType;
            string PEKIND = psn.Pekind;
            string PEHYEAR = psn.Pehday.ToString();
            Double PEHDAY  = CommonFun.getDouble(psn.Pehday);
            Double PERDAY1 = CommonFun.getDouble(psn.Perday1);
            Double PERDAY2 = CommonFun.getDouble(psn.Perday2);
            StringBuilder otherdesc = new StringBuilder();

            Double otherLimitdays  = 0.0;
            int otherhours = 0;
            Double otherLeftdays  = 0.0;
            string otherLeavetype = "";
            Leave_type = Leave_type.PadLeft(2, '0');

            string NowYear =(int.Parse(DateTime.Now.ToString("yyyy"))-1911).ToString();
            string NextYear  = (int.Parse(DateTime.Now.ToString("yyyy"))-1911+1).ToString();
            string NowMMDD   = DateTime.Now.ToString("MMdd");
            Boolean isCrossYear = false;

            if(UcDate != "" && "03" == Leave_type )
            {
                if(NextYear == UcDate.Substring(0, 3) || NextYear == UcDate.Substring(0, 3) )
              {
                  isCrossYear = true;
              } 
            }

            //請假規則
            FSC.Logic.LeaveSetting ls = new FSC.Logic.LeaveSetting().GetObject(Orgcode, PEKIND, Leave_type, employeeType);

            if (Leave_type == "08" || Leave_type == "10" || Leave_type == "22" || Leave_type == "13")
            {    // 婚假, 喪假, 陪產假
                 //依事實發生日統計假別目前總時數

                if (UcDate == "")
                {
                    UcDate = FSC.Logic.DateTimeInfo.GetRocDate(DateTime.Now);
                }
                hours = lm.GetHaveHoursByOccurDate(Apply_id, Leave_type, UcDate);
            }
            else
            {   //ex:事假, 病假, 休假,  生理假, 家庭照顧假, 延休假
                //依年月統計假別目前總時數

                if (UcDate == "")
                {
                    UcDate = FSC.Logic.DateTimeInfo.GetRocDate(DateTime.Now);
                }

                hours = lm.GetHaveHoursByDate(Apply_id, Leave_type, UcDate);

                    if( Leave_type == "01") // '事假 含 家庭照顧假
                    {
                          otherLeavetype = "25";
                          otherhours = lm.GetHaveHoursByDate(Apply_id, otherLeavetype, UcDate);
                    if( otherhours > 0 )
                    {
                        otherdesc.Append("，已請").Append("家庭照顧假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours).ToString()));
                    }

                    }

                    if( Leave_type == "25") 
                    {//'家庭照顧假 含 事假
                        otherLeavetype = "01";
                        otherhours = lm.GetHaveHoursByDate(Apply_id, otherLeavetype, UcDate);
                        if( otherhours > 0 )
                        {
                            otherdesc.Append("，已請").Append("事假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours).ToString()));
                        }

                        DataTable pd04mdt = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, otherLeavetype);
                           for ( int i = 0 ; i < pd04mdt.Rows.Count ;i++)
                            {
                                otherLimitdays = CommonFun.getDouble(pd04mdt.Rows[i]["PDDAYS"].ToString());
                            }
                    }

                      if( Leave_type == "02" )   //'病假 含 生理假
                      {
                            otherLeavetype = "24";
                            otherhours = lm.GetHaveHoursByDate(Apply_id, otherLeavetype, UcDate);
                            if( otherhours > 0 )
                            {
                                otherdesc.Append("，已請").Append("生理假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours).ToString()));
                            }
                      }

                  if (Leave_type == "24" )  // '生理假 含 病假
                  {  
                    otherLeavetype = "02";
                    otherhours = lm.GetHaveHoursByDate(Apply_id, otherLeavetype, UcDate);
                    if( otherhours > 0 )
                    {
                        otherdesc.Append("，已請").Append("病假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours).ToString()));
                    }

                    DataTable pd04mdt  = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, otherLeavetype);
                    for ( int i = 0 ; i < pd04mdt.Rows.Count ;i++)
                    {
                        otherLimitdays = CommonFun.getDouble(pd04mdt.Rows[i]["PDDAYS"].ToString());
                    }
                  }
            }

            if (Leave_type == "01")//'事假
            {
                DataTable dt = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type);
                if (dt.Rows.Count > 0)
                {
                    Limitdays = Convert.ToDouble(dt.Rows[0]["PDDAYS"]);
                }
            }
            else if (Leave_type == "03") //休假
            {
                Limitdays = Content.ConvertDayHours(Content.ConvertToHours(PEHDAY) + Content.ConvertToHours(PERDAY1) + Content.ConvertToHours(PERDAY2));
            }
            else if (Leave_type == "30")
            {
                DataTable dt = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type);
                if (dt.Rows.Count > 0)
                {
                    Limitdays = Convert.ToDouble(dt.Rows[0]["PDDAYS"]);
                }
            }
            else if (Leave_type == "31")
            {
                DataTable dt = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type);
                if (dt.Rows.Count > 0)
                {
                    Limitdays = Convert.ToDouble(dt.Rows[0]["PDDAYS"]);
                }
            }
            else if (Leave_type == "10")
            {
                Limitdays = new LeaveMain().GetSpecialimitDays(ls, Leave_type, target, 0);
            }
            else if (Leave_type == "13")
            {
                Limitdays = new LeaveMain().GetSpecialimitDays(ls, Leave_type, 0, BabyDays);
            }
            else
            {

                DataTable pd04mdt = new CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type.ToString().PadLeft(2, '0'));

                foreach (DataRow dr in pd04mdt.Rows)
                {
                    Limitdays = CommonFun.getDouble(dr["PDDAYS"].ToString());
                }

                if (Limitdays == 0)
                {
                    return string.Empty;
                }

            }


            if (isCrossYear)
            {
                //(1)	若為正式人員、約聘僱人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
                //(2)	承(1)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。
                //(3)	若為臨時人員、技工、工友、駕駛、定期僱用、約用人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
                //(4)	承(3)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。

                //取 PEHYEAR, PEDAY
                System.DateTime baseDate = FSC.Logic.DateTimeInfo.GetPublicDate(NextYear + "0101","");

                string Join_sdate = string.Empty;
                string Elected_officials_flag = string.Empty;
                string vPEKIND = string.Empty;
                string vPEMEMCOD = string.Empty;
                string Metadb_id = "";
                DataTable pe05md2t = new Personnel().GetDataByIdCard(Apply_id);
                if (pe05md2t != null && pe05md2t.Rows.Count > 0)
                {
                    DataRow dr = pe05md2t.Rows[0];
                    vPEKIND = dr["PEKIND"].ToString();
                    //vPEMEMCOD = dr("PEMEMCOD").ToString()
                }

                FSC.Logic.Personnel p = new FSC.Logic.Personnel();
                DataTable dt = new DataTable();
                dt = p.GetDataByIdCard(Apply_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    //Elected_officials_flag = row("Elected_officials_flag").ToString()
                    Join_sdate = row["join_sdate"].ToString();
                }

                LeaveYearDay l = CntLeave.GetCntYearsDays(Orgcode, Apply_id, Join_sdate, Elected_officials_flag, vPEKIND, vPEMEMCOD, baseDate);
                if (l != null)
                {
                    Limitdays = CommonFun.getDouble(l.Day);
                }

            }

            Leftdays = Content.ConvertDayHours(Content.ConvertToHours(Limitdays) - (hours + otherhours));
            if (Leftdays < 0)
            {
                Leftdays = 0;
            }

            otherLeftdays = Content.ConvertDayHours(Content.ConvertToHours(otherLimitdays) - otherhours);
            if (otherLeftdays < 0)
            {
                otherLeftdays = 0;
            }


            if (isCrossYear)
            {
            }

            if (Limitdays < 0)
            {
                Limitdays = 0;
            }

            StringBuilder ret = new StringBuilder();

            if (withoutTexDesc)
            {               
                ret.Append(Limitdays).Append(",");
                ret.Append(Content.ConvertDayHours(hours)).Append(",");
                ret.Append(Leftdays);
            }
            else
            {
                ret.Append("<span style='line-height:22px;'>");
                ret.AppendLine("您").Append(new SYS.Logic.LeaveType().GetLeaveName(Leave_type)).Append("可請").Append(CommonFun.getShowDayHours(Limitdays.ToString())).Append("，目前已請").Append(new SYS.Logic.LeaveType().GetLeaveName(Leave_type)).Append(CommonFun.getShowDayHours(Content.ConvertDayHours(hours).ToString())).Append(otherdesc.ToString()).Append("，剩餘").Append(CommonFun.getShowDayHours(Leftdays.ToString()));
                ret.Append("</span>");

                if (otherLeftdays == 0 & otherLimitdays != 0 & otherhours != 0)
                {
                    ret.Append("<br/><span style='color:red; line-height:22px;'>");
                    ret.AppendLine("您").Append(new SYS.Logic.LeaveType().GetLeaveName(otherLeavetype)).Append("剩餘").Append(CommonFun.getShowDayHours(otherLeftdays.ToString())).Append("，若提出").Append(new SYS.Logic.LeaveType().GetLeaveName(Leave_type)).Append("將會被扣薪，請確定是否要提出申請。");
                    ret.Append("</span>");
                }
            }

            return ret.ToString();

     }

    


    // WSMOB019
    // 一般請假取得備註
    // Edit 2014/7/30 Eliot Chen
    [WebMethod]
    public string WSMOB019
    (
        string Apply_id,    // 員工編號
        string Leave_type,  // 假別
        string Start_date,  // 開始日期
        string UcDate,      //事實發生日
        string Target,      //喪假對象
        string BabyDays  //懷孕日數
        , string rblretainFlag
        , string rblretainFlagText
        , string Orgcode
        )
    {
        FSC.Logic.LeaveSetting ls = new FSC.Logic.LeaveSetting();
        string lbMemo = "";

        //婚假, 陪產假
        if (Leave_type == "08" | Leave_type == "22")
        {
            //依事實發生日統計假別目前總時數

            lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, UcDate);

            if (Leave_type == "22")
            {
                lbMemo = lbMemo + "需檢附相關證明文件例如出生證明影本。";
            }

            //喪假
        }
        else if (Leave_type == "10")
        {
            /*
            AppException.WriteErrorLog(Target,"Target");
            if (Target=="")
            {
                Target = "0";
            }
             */
            lbMemo = GetLimitDesc(Apply_id, Leave_type, UcDate, CommonFun.getInt(Target), 0, false, Orgcode);

        }
        else if (Leave_type == "13")
        {
            //lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, UcDate , CommonFun.getInt(BabyDays));
            //休假
            lbMemo = GetLimitDesc(Apply_id, Leave_type, UcDate, 0, CommonFun.getInt(BabyDays), false, Orgcode);
        }
        else if (Leave_type == "03")
        {
            Personnel psn = new Personnel().GetObject(Apply_id);
            double PEHDAY = CommonFun.getDouble(psn.Pehday);
            double PERDAY1 = CommonFun.getDouble(psn.Perday1);
            double PERDAY2 = CommonFun.getDouble(psn.Perday2);

            string limits = (rblretainFlag == "0" ? (PERDAY1 + PERDAY2).ToString() : PEHDAY.ToString());
            double hours = 0;

            DataTable dt = new LeaveMain().GetDataByYYYMM(Apply_id, Leave_type, (DateTime.Now.Year - 1911).ToString(), rblretainFlag);
            foreach (DataRow dr in dt.Rows)
            {
                hours += CommonFun.getDouble(dr["Leave_hours"].ToString());
            }

            double left_days = Content.ConvertDayHours(Convert.ToInt16(Content.ConvertToHours(Convert.ToDouble(limits)) - hours));

            lbMemo = "您" + rblretainFlagText + "休假可請" + limits + "天，目前已請" + Content.ConvertDayHours((int)hours).ToString() + "天" + "剩餘" + left_days.ToString() + "天。";

        }
        else
        {
            //ex:事假, 病假,  生理假, 家庭照顧假
            //依年月統計假別目前總時數
            lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, Start_date);
        }
        return lbMemo;


        /*
        FSC.Logic.LeaveSetting ls = new FSC.Logic.LeaveSetting();
        string lbMemo = "";
               
        if (Leave_type == "08" | Leave_type == "22") //婚假, 陪產假
        {
            //依事實發生日統計假別目前總時數

            lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, UcDate);

            if (Leave_type == "22")
            {
                lbMemo = lbMemo + "需檢附相關證明文件例如出生證明影本。";
            }          
        }
        else if (Leave_type == "10")  //喪假
        {
    //        lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, UcDate, CommonFun.getInt(Target), 0);
            lbMemo = GetLimitDesc(Apply_id, Leave_type, UcDate, CommonFun.getInt(Target), 0, false, Orgcode);
        }
        else if (Leave_type == "13")
        {
   //         lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, UcDate, 0, CommonFun.getInt(BabyDays)); 
            lbMemo = GetLimitDesc(Apply_id, Leave_type, UcDate, 0,CommonFun.getInt(BabyDays), false, Orgcode);
        }
        else if (Leave_type == "03") //休假
        {
            Personnel psn = new Personnel().GetObject(Apply_id);
            double PEHDAY = CommonFun.getDouble(psn.Pehday);
            double PERDAY1 = CommonFun.getDouble(psn.Perday1);
            double PERDAY2 = CommonFun.getDouble(psn.Perday2);

            string limits = (rblretainFlag == "0" ? (PERDAY1 + PERDAY2).ToString() : PEHDAY.ToString());
            double hours = 0;
            string Date = "";
            if (UcDate != "")
               Date= UcDate.Substring(0, 3);

            DataTable dt = new LeaveMain().GetDataByYYYMM(Apply_id, Leave_type, Date, rblretainFlag);
            foreach (DataRow dr in dt.Rows)
            {
                hours += CommonFun.getDouble(dr["Leave_hours"]);
            }

            double left_days = Content.ConvertDayHours(Convert.ToInt16(Content.ConvertToHours(Convert.ToDouble(limits)) - hours));

            lbMemo = "您" + rblretainFlagText + "休假可請" + limits + "天，目前已請" + Content.ConvertDayHours((int)hours).ToString() + "天" + "剩餘" + left_days.ToString() + "天。";
        }
        else
        {
            //ex:事假, 病假,  生理假, 家庭照顧假
            //依年月統計假別目前總時數
            lbMemo = ls.GetLimitDesc(Apply_id, Leave_type, Start_date);
        }

        return lbMemo;
         */
    }


    // WSMOB020
    // 取得職稱
    [WebMethod]
    public DataTable WSMOB020()
    {
        DataTable dt;
        dt = new FSCPLM.Logic.SACode().GetData("023", "022");
        return dt;
    }

    // WSMOB021
    // 取得人員類別
    [WebMethod]
    public DataTable WSMOB021()
    {
        DataTable dt;
        dt = new FSCPLM.Logic.SACode().GetData("023", "022");
        return dt;
    }


    // WSMOB024
    // 取得 Flow ID
    [WebMethod]
    public string WSMOB024
    (
        string Orgcode,
        int Leave_type
        )
    {
        return new SYS.Logic.FlowId().GetFlowId(Orgcode, "001001", Leave_type);
    }

    // WSMOB025
    // 取得 Personnel 物件

    // WSMOB025
    // 驗證帳號
    // 對應 LoginInfo.CheckAccPass
    [WebMethod]
    public string WSMOB025
    (
        string strAcc   // 帳號
        )
    {
        return LoginInfo.CheckAccPass(strAcc);
    }


    // WSMOB027
    // 取得請假人員清單
    [WebMethod]
    public DataTable WSMOB027
    (
        string Orgcode,
        string Depart_id,
        string MetadbID
        )
    {
        DataTable dt;
    /*    FSCPLM.Logic.MemberDAO mdao = new FSCPLM.Logic.MemberDAO();

        FSC.Logic.Member myMember = new FSC.Logic.Member();
        dt = myMember.GetDataByOrgDep(Orgcode, Depart_id);
     */ 
        /*
        dt = mdao.GetDataNoSelf(Orgcode,
            Depart_id,
            "", "",
            MetadbID,
            "").Tables[0];
         */

        Personnel m = new Personnel();

        dt = m.GetDataByOrgDep(Orgcode, Depart_id);
    
        return dt;

    }

    // WSMOB028
    // 
    [WebMethod]
    public string WSMOB028(
        string Orgcode, 
        string DepartID
        )
    {
        FSC.Logic.Org org = new FSC.Logic.Org();
        DataRow dr = org.GetDataByDepartid(Orgcode, DepartID);
        if (dr==null)
        {
            return "";
        }
        else
        {
            return dr["Parent_depart_id"].ToString();
        }
    }


    // WSMOB029 
    // 取得個人加班記錄
    [WebMethod]
    public DataTable WSMOB029
        (
        string orgcode,
        string Depart_id,
        string ID_card,
        string ym,
        string ymd
        )
    {
        DataTable dt;
        dt = new SAL1111().GetSAL1111Data(orgcode, Depart_id, ID_card, ym, ymd);
        return dt;
    }

    // WSMOB029_1
    // Eliot Chen
    // 取得個人加班記錄
    [WebMethod]
    public DataTable WSMOB029_1
        (
        string orgcode,
        string Depart_id,
        string ym,
        string ID_card
        )
    {
        DataTable dt;
        dt = new SAL1112().doQuerySAL1112(orgcode, Depart_id,  ym,ID_card);
        return dt;
    }

    // WSMOB030
    // 對應 OvertimeFeeMaster().GetOvertimeFeeMasterByQuery
    [WebMethod]
    public DataTable WSMOB030(string Orgcode, string Depart_id, string Id_card, string Fee_ym)
    {
        DataTable dt;
        dt = new OvertimeFeeMaster().GetOvertimeFeeMasterByQuery(Orgcode, Depart_id, Id_card, Fee_ym);
        return dt;
    }

    // WSMOB031
    // 加班費取出本次請領的原本時數 及 上次請領的時數
    [WebMethod]
    public DataTable WSMOB031(
        string Orgcode,
        string Depart_id,
        string ID_card,
        string ym,
        string PRADDD,
        string PRSTIME
        )
    {
        OvertimeFeeDetail ofd = new OvertimeFeeDetail();
        DataTable dt = ofd.GetData(Orgcode, Depart_id, ID_card, ym, PRADDD, PRSTIME);
        return dt;
    }

    // WSMOB032
    // 取得交通工具
    [WebMethod]
    public DataTable WSMOB032()
    {
        DataTable dt;
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        dt = code.GetData("023", "013");
        return dt;
    }

    // WSMOB033
    // 取得城市列表
    [WebMethod]
    public DataTable WSMOB033()
    {
        DataTable dt;
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        dt = code.GetData("023", "007");
        return dt;
    }

    // WSMOB034
    // 取得 SABASE 資料
    [WebMethod]
    public DataTable WSMOB034(string OrgCode,string IDCard)
    {
//        DataTable dt;
//        SABASETableAdapters.SAL_SABASETableAdapter sab = new SABASETableAdapters.SAL_SABASETableAdapter();
//        dt = sab.GetDataByBASE_SEQNO(IDCard);
        SALPLM.Logic.SAL3101 sal3101 = new SALPLM.Logic.SAL3101();
        DataTable dt = sal3101.querySalSaBaseBySeqNo(OrgCode, IDCard);
        return dt;
    }

    // WSMOB035
    // 取得個人 Personnel
    [WebMethod]
    public string WSMOB035(string hdPerId)
    {
       
        return new FSC.Logic.Personnel().GetColumnValue("Employee_type", hdPerId);
    }

    //WSMOB036
    [WebMethod]
    public DataTable WSMOB036(string Kind)
    {
        DataTable pc03mdt = new FSC.Logic.CPAPC03M().DAO.GetDataByKind(Kind);
        return pc03mdt;
    }

    // WSMOB037
    // 取得個人加班記錄 - 勞基法
    [WebMethod]
    public DataTable WSMOB037(
        string OrgCode, string Unit, string YearMonth, string PEIDNO)
    {
        SAL1112 bll = new SAL1112();
        DataTable dt = bll.doQuerySAL1112(OrgCode, Unit, YearMonth, PEIDNO);
        return dt;
    }

    // WSMOB038
    // 加班費自動計算 For 勞基法
    // 沒用
    [WebMethod]
    public bool WSMOB038(
        string OrgCode
        ,string Depart_id
        ,string YearMonth
        ,string[] PerId
        ,bool isUpdate
        ,string flow_id)
    {
        SAL1112 bll = new SAL1112();
        bll.doConfirm(OrgCode, Depart_id, YearMonth, PerId, isUpdate, flow_id);
        return true;
    }

    // WSMOB039
    // 取得待審核項目資料
    [WebMethod]
    public DataTable WSMOB039
    (
        string formId
        ,string flowId
        ,string Orgcode
        ,string DepartId
        ,string IDCard
        )
    {
        FSC.Logic.FSC0101 fsc0101 = new FSC.Logic.FSC0101();

        DataTable dt = fsc0101.GetNextData(
            formId, flowId, "", Orgcode, DepartId, IDCard ,"","");

        dt.Columns.Add("type_name");
        dt.Columns.Add("type_name_2");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            
            string name = "";
            FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
            name = code.GetCodeDesc("024", "**", dt.Rows[i]["form_id"].ToString().Substring(0, 3));
            dt.Rows[i]["type_name"] = name;
            name = "";
            DataRow r = null;
            if (!string.IsNullOrEmpty(flowId) && !string.IsNullOrEmpty(formId) && formId.Length >= 6)
            {
                r = code.GetRow("024", formId.Substring(0, 3), formId.Substring(3));
            }
            r = code.GetRow("024", formId.Substring(0, 3), formId.Substring(3));

            if (r != null)
            {
                if ("001" == formId.Substring(0, 3))// & !string.IsNullOrEmpty(r["code_desc2"].ToString()))
                {
                    string leaveType = "";
                    FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
                    SYS.Logic.LeaveType lt = new SYS.Logic.LeaveType();
                    DataTable dt2 = lm.GetDataByOrgFid(Orgcode, dt.Rows[i]["Flow_id"].ToString());
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        leaveType = dt2.Rows[0]["Leave_type"].ToString();
                    }
                    name = lt.GetLeaveName(leaveType);
                }
                else
                {
                    name = r["code_desc1"].ToString();
                }
            }
            dt.Rows[i]["type_name_2"] = name;
        }
        return dt;

    }

    //WSMOB040
    // 取得申請種類
    [WebMethod]
    public string WSMOB040
        (string typecode)
    {
        string name="";
        FSCPLM.Logic.SACode code=new FSCPLM.Logic.SACode();
        name = code.GetCodeDesc("024", "**", typecode.Substring(0, 3));
        return name;
    }

    // WSMOB041
    [WebMethod]
    public string WSMOB041(
        string orgcode
        , string flowId
        , string formId 
        )
    {
        string name = "";
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        DataRow r = null;
        if (!string.IsNullOrEmpty(flowId) && !string.IsNullOrEmpty(formId) && formId.Length >= 6)
        {
            r = code.GetRow("024", formId.Substring(0, 3), formId.Substring(3));
        }

        if (r != null)
        {
            if ("001" == formId.Substring(0, 3) & !string.IsNullOrEmpty(r["code_desc2"].ToString()))
            {
                string leaveType = "";
                FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
                SYS.Logic.LeaveType lt = new SYS.Logic.LeaveType();
                DataTable dt = lm.GetDataByOrgFid(orgcode, flowId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    leaveType = dt.Rows[0]["Leave_type"].ToString();
                }
                name = lt.GetLeaveName(leaveType);
            }
            else
            {
                name = r["code_desc1"].ToString();
            }

/*
            string url = r["CODE_REMARK1"].ToString();
            if (!string.IsNullOrEmpty(url))
            {
//                lbFormType.PostBackUrl = url + "?org=" + orgcode + "&fid=" + flowId;
            }
            else
            {
                lbFormType.Attributes("href") = "";
                lbFormType.OnClientClick = "return false;";
                lbFormType.Style("cursor") = "default";
                lbFormType.CssClass = "noLink";
            }
 */ 
        }
        return name;
    }

    // WSMOB042
    // 
    [WebMethod]
    public string WSMOB042(
        string orgcode
        ,string flowId
        ,string groupId
        , string nextStep
        , int agreeFlag
        , string lastOrgcode
        , string lastDepartId
        , string lastIdcard
        , string lastPosid
        , string lastName
        , string Account
        )
    {
        List<SYS.Logic.FlowDetail> fdList = new List<SYS.Logic.FlowDetail>();
            string comment = "";
            try
            {
                if (2 == agreeFlag & "0" != groupId)
                {
                    throw new FlowException("不可退件!");
                }

                SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                fd.Orgcode = orgcode;
                fd.FlowId = flowId;
                fd.LastOrgcode = lastOrgcode;
                fd.LastDepartid = lastDepartId;
                fd.LastPosid = lastPosid;
                fd.LastIdcard = lastIdcard;
                fd.LastName = lastName;
                fd.AgreeFlag = agreeFlag;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = comment;
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = Account;

                fd.AgreeStep = CommonFun.getInt(nextStep);


                fdList.Add(fd);


                using (TransactionScope trans = new TransactionScope())
                {
                    SYS.Logic.CommonFlow.RunFlow(fd);

                    trans.Complete();

                }

            }
            catch (FlowException fex)
            {
                string strResult = "{" + buildJSONErr("表單(" + flowId + ")，" + fex.Message + "。\n") + "}";
                return strResult;
            }
            catch (Exception ex)
            {
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
                string strResult = "{" + buildJSONErr("批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員") + "}";
                return strResult;
            }

            string strResult2 =
               "\"isSuccess\":\"Y\"";
            strResult2 +=
                ",\"message\":\"" + "批核成功!" + "\"";

            return "{" + strResult2 + "}";
    }

    /*
    [WebMethod]
    public string WSMOB042(
        System.Web.UI.WebControls.GridView gv
        ,int agreeFlag
        , string lastOrgcode
        , string lastDepartId
        , string lastIdcard
        , string lastPosid
        , string lastName
        )
    {
        bool chk = false;
        List<SYS.Logic.FlowDetail> fdList = new List<SYS.Logic.FlowDetail>();
        string err="";
        foreach (System.Web.UI.WebControls.GridViewRow gvr in gv.Rows)
        {
            if (!((System.Web.UI.WebControls.CheckBox)gvr.FindControl("gvcbx")).Checked)
            {
                continue;
            }

            string orgcode = ((System.Web.UI.WebControls.Label)gvr.FindControl("gvlbOrgcode")).Text;
            string flowId = ((System.Web.UI.WebControls.Label)gvr.FindControl("gvlbFlowId")).Text;
            //            string comment = ((UControl_SYS_UcComment)gvr.FindControl("gvUcComment")).Text;
            string comment = "";
            string groupId = ((System.Web.UI.WebControls.HiddenField)gvr.FindControl("gvhfGroupId")).Value;

            try
            {
                //checkReword(orgcode, flowId) '敘獎申請最後一關檢核

                if (2 == agreeFlag & "0" != groupId)
                {
                    throw new FlowException("不可退件!");
                }

                SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
                fd.Orgcode = orgcode;
                fd.FlowId = flowId;
                fd.LastOrgcode = lastOrgcode;
                fd.LastDepartid = lastDepartId;
                fd.LastPosid = lastPosid;
                fd.LastIdcard = lastIdcard;
                fd.LastName = lastName;
                fd.AgreeFlag = agreeFlag;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = comment;
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                fdList.Add(fd);


                using (TransactionScope trans = new TransactionScope())
                {
                    SYS.Logic.CommonFlow.RunFlow(fd);

                    trans.Complete();
                    chk = true;
                }

            }
            catch (FlowException fex)
            {
                err += "表單(" + flowId + ")，" + fex.Message + "。\n";
//                err.Append("表單(" + flowId + ")，" + fex.Message() + "。\\n");
            }
            catch (Exception ex)
            {
                AppException.WriteErrorLog(ex.StackTrace, ex.Message);
                err += "批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員。\n";
//                err.Append("批核表單(" + flowId + ")時，系統發生錯誤，請洽人事管理人員。\\n");
            }
        }

        if (chk)
        {
            foreach (SYS.Logic.FlowDetail fd in fdList)
            {
                // 先 MArk 
                // 會掛
                //SendNotice.sendAll(fd.Orgcode, fd.FlowId);
            }
        }
        else
        {
            if (err.Length <= 0)
            {
                err += "至少需勾選一筆。\n";
//                err.Append("至少需勾選一筆。\\n");
            }
        }

        if (err.Length > 0)
        {
            return "{" + buildJSONErr(err) + "}";
//            CommonFun.MsgShow(this, CommonFun.Msg.Custom, err.ToString());
        }
        else
        {

            string strResult =
               "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"" + "批核成功!" + "\"";


            return "{" + strResult + "}";
        }
    }
     */
    [WebMethod]
    public string WSMOB042_1(string Orgcode, string flow_id)
    {

        SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(Orgcode, flow_id);

        return f.FormId;
    }

    [WebMethod]
    public string WSMOB042_2(string Orgcode, string flow_id)
    {

        SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(Orgcode, flow_id);

        return f.Orgcode;
    }

    [WebMethod]
    public string WSMOB042_3(string Orgcode, string flow_id)
    {

        SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(Orgcode, flow_id);

        return f.FlowId;
    }


    [WebMethod]
    public string WSMOB042_4(string f_Orgcode, string f_FlowId)
    {
        string msg = "";
        List<FSC.Logic.ForgotClockApply> list = new FSC.Logic.ForgotClockApply().GetObjects(f_Orgcode, f_FlowId);
        foreach (FSC.Logic.ForgotClockApply fca in list)
        {
            string yymm = fca.Forgot_date.Substring(0, 5);
            FSC.Logic.CPAPHYYMM phyymm = new FSC.Logic.CPAPHYYMM(yymm);

            DataTable chdt = phyymm.GetData(fca.Apply_idcard, fca.Forgot_date, fca.Card_type);
            if (chdt != null && chdt.Rows.Count > 0)
            {
                msg = "已有該日期卡別刷卡資料!";
            }
        }

        return msg;
    }

    //WSMOB043
    // 取得假別狀態
    [WebMethod]
    public DataTable WSMOB043(
        )
    {
        DataTable dt = new FSCPLM.Logic.SACode().GetData2("023", "P", "002");
        return dt;
    }


    //假別
    [WebMethod]
    public DataTable WSMOB047(string Orgcode)
    {
        DataTable dt;
        dt = new SYS.Logic.LeaveType().GetLeaveType(Orgcode, "A");
        return dt;
    }

    //懷孕日數
    [WebMethod]
    public DataTable WSMOB048()
    {
        DataTable dt;
        dt = new SYS.Logic.CODE().GetData("023", "032");
        return dt;
    }


    //喪假對象
    [WebMethod]
    public DataTable WSMOB049(string orgcode,string employeeType,string leaveKind,string leaveType)
    {
        DataTable dt;
        FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
        LeaveSetting ls = new LeaveSetting();
        LeaveSettingDetail lsd = new LeaveSettingDetail();
        dt = ls.GetDataByQuery(orgcode, leaveKind, leaveType, employeeType);
        if (dt != null && dt.Rows.Count > 0)
        {
            dt.Columns.Add("Code_desc1", typeof(string));
            dt.Columns.Add("Code_no", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["Code_desc1"] = code.GetCodeDesc("023", "024", dr["Detail_code_id"].ToString());
                dr["Code_no"] = dr["Detail_code_id"].ToString();
            }         
        }

        return dt;
    }


    //假別說明
    [WebMethod]
    public string WSMOB050(string Id_card, string Leave_type, string Orgcode)
    {
        if (string.IsNullOrEmpty(Id_card) | string.IsNullOrEmpty(Leave_type))
        {
            return "";
        }
       
        DataTable dt = new Personnel().GetDataByIdCard(Id_card);

        if (dt != null && dt.Rows.Count > 0)
        {
            string employee_type = dt.Rows[0]["employee_type"].ToString();
            DataTable lsdt = new LeaveSetting().GetDataByLeaveKind(Orgcode, dt.Rows[0]["PEKIND"].ToString(), Leave_type, employee_type);
            if (lsdt != null && lsdt.Rows.Count > 0)
            {
                return new SYS.Logic.LeaveType().GetLeaveName(Leave_type) + "：" + lsdt.Rows[0]["Describe"].ToString();
            }
        }
        return "";       
    }

    //代理人_1
    [WebMethod]
    public DataTable WSMOB051(string ApplyIdcard)
    {    
        FSC.Logic.DeputyDet dd = new FSC.Logic.DeputyDet();
        DataTable dt = dd.GetDeputyDetByID_card(ApplyIdcard);


            return dt;
    }

    //計算期限
    [WebMethod]
    public string WSMOB052(string Start_date)
    {
        CPAPB02M pb02m = new CPAPB02M();
        string str = pb02m.GetLimitDate(Start_date, 41, true);
        return str;
    }

    //判斷假日
    [WebMethod]
    public bool WSMOB053(string Date)
    {
        CPAPB02M pb02 = new CPAPB02M();
        bool str = pb02.IsHoliday(Date);
        return str;
    }


    //申請人value
    [WebMethod]
    public DataTable WSMOB054(string ddlleaveName)
    {
        DataTable dt = new Personnel().GetDataByIdCard(ddlleaveName);
        return dt;
    }

    //申請人value
    [WebMethod]
    public DataTable WSMOB055(string ddlleaveName)
    {
        DataTable dt = new FSC.Logic.DepartEmp().GetDataByIdcard(ddlleaveName);
        return dt;
    }

    [WebMethod]
    public List<FSC.Logic.LeaveMain> WSMOB056(string org,string fid)
    {
        List<FSC.Logic.LeaveMain> list = new FSC.Logic.LeaveMain().GetObjects(org, fid);

        return list;
    }


    [WebMethod]
    public SYS.Logic.Flow WSMOB057(string org, string fid)
    {
        SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(org, fid);

        return f; 
    }


    [WebMethod]
    public DataTable WSMOB058(string org, string fid)
    {
        DataTable dt = new SYS.Logic.FlowDetail().GetDataByFlow_id(org, fid);

        return dt;
    }


    [WebMethod]
    public string WSMOB059(string id)
    {
        Personnel psn = new Personnel().GetObject(id);
        if (psn.Pekind != "")
        {
            return psn.Pekind;
        }
        else
        {
            return "";
        }
    }

    [WebMethod]
    public string WSMOB060(string id)
    {
        Personnel psn = new Personnel().GetObject(id);
        if (psn.EmployeeType != "")
        {
            return psn.EmployeeType;
        }
        else
        {
            return "";
        }
    }

 
    [WebMethod]
    public string WSMOB061(string Orgcode,string Pekind,string ddlLeave_type,string EmployeeType)
    {
        FSC.Logic.LeaveSetting ls = new FSC.Logic.LeaveSetting().GetObject(Orgcode, Pekind, ddlLeave_type, EmployeeType);
        if (ls == null)
        {
            return "";
        }
        if (ls.Ifbatch_apply != "")
        {
            return ls.Ifbatch_apply;
        }

        return "";
    }




    // WSMOB062
    // 裝置註冊查詢
    [WebMethod]
    public string WSMOB062(
        string Device_Type, // 裝置類型 (I : IOS, A:Android)
        string Device_ID,   // 裝置代碼
        string Auth_Code    // 驗證碼, 先不使用    
        )
    {
        EMPMobiDevReg empMobiDevReg = new EMPMobiDevReg();
        string strRv= empMobiDevReg.queryADIDByUniqueID(Device_ID, Device_Type);
        if (strRv == "")
        {
            string strResult = "{" + buildJSONErr("查無資料!") + "}";
            return strResult;
        }
        else
        {
            string strResult =
               "\"isSuccess\":\"Y\"";
            strResult +=
                ",\"message\":\"" + "OK!" + "\"" +
                ",\"ADID\":\"" + strRv + "\"" +
                "";

            return "{" + strResult + "}";
        }
    }


    // WSMOB063
    // 取得特定 ID 之相關 USER Data
    [WebMethod]
    public string WSMOB063(
        string ID,          // 帳號
        string Auth_Code    // 驗證碼, 先不使用
        )
    {
        string strResult;

        if (!chackAuth(""))
        {
            strResult = "{" + "驗證碼錯誤" + "}";
            return strResult;
        }

        string messageInfo = LoginInfo.CheckAccPass(ID.Trim());
        if (!string.IsNullOrEmpty(ID.Trim()) && !"".Equals(messageInfo))
        {
            strResult = "{" + buildJSONErr(messageInfo) + "}";
            return strResult;
        }


        //  由 AD 去取得 ID_CARD
        //FSC.Logic.Personnel psn = null;
        DataTable dt = new FSC.Logic.Personnel().GetDataByADid(ID.Trim());
        string strIDCard = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            strIDCard = dt.Rows[0]["ID_CARD"].ToString();
        }

//        FSC.Logic.Personnel psn = new FSC.Logic.Personnel().GetObject(ID.Trim());

        FSC.Logic.Personnel psn = new FSC.Logic.Personnel().GetObject(strIDCard);

        if (psn != null)
        {
            string Account = psn.IdCard;
            string UserData = LoginInfo.GetUserData(psn, Account);
            //return "test";

            if (string.IsNullOrEmpty(UserData))
            {
                strResult = "{" + buildJSONErr("查無資料!") + "}";
                return strResult;
            }
            else
            {
                // 回傳訊息JSON
                strResult =
                   "\"isSuccess\":\"Y\"";
                strResult +=
                    ",\"message\":\"" + "登入成功!" + "\"" +
                    ",\"UserData\":\"" + UserData + "\"" +
                    "";

                return "{" + strResult + "}";

            }
        }
        else
        {
            strResult = "{" + buildJSONErr("查無資料!") + "}";
            return strResult;
        }
    }

    //WSMOB064
    // 取得code_remark1
    [WebMethod]
    public string WSMOB064
        (string strValue)
    {

        DataRow r = new FSCPLM.Logic.SACode().GetRow("023", "002", strValue);
        return r["code_remark1"].ToString();
    }

    // 取得code_remark2
    [WebMethod]
    public string WSMOB065
        (string strValue)
    {

        DataRow r = new FSCPLM.Logic.SACode().GetRow("023", "002", strValue);
        return r["code_remark2"].ToString();
    }

    // WSMOB066
    // 取得 FSC.Logic.Personnel().GetColumnValue("Employee_type","")
    [WebMethod]
    public string WSMOB066
        (string strField,string strValue)
    {
        return new FSC.Logic.Personnel().GetColumnValue(strField, strValue); 
    }
     
    [WebMethod]
    public int WSMOB067(string value)
    {
        return CommonFun.ConvertToInt(value);
    }

    [WebMethod]
    public string WSMOB068(string ID_card)
    {
        return new FSC.Logic.Personnel().GetDataByIdCard(ID_card).Rows[0]["PEKIND"].ToString();
    }

    [WebMethod]
    public DataTable WSMOB069(string Orgcode, string Depart_id, string ID_card, string ym)
    {
       DataTable dt = new FSC.Logic.ProjectOvertimeRule().getDataByYYYMM(Orgcode, Depart_id, ID_card, ym);
       return dt;
    }

    [WebMethod]
    public int WSMOB070(string value)
    {
        return CommonFun.getInt(value);
    }

       [WebMethod]
    public string WSMOB071(string PEKIND)
    {

        return new FSC.Logic.CPAPC03M().GetPCPARM1(PEKIND, "limit", "3");
    }

       [WebMethod]
       public DataTable WSMOB072(string ID_card,string ym,string type)
       {
         FSC.Logic.CPAPR18M pr18m = new FSC.Logic.CPAPR18M();
         DataTable dt = pr18m.GetSumData(ID_card, ym, type);
         return dt;
       }


       [WebMethod]
       public string WSMOB073(string hdPerId)
       {

           SAL.Logic.SABASE sabase = new SAL.Logic.SABASE();        

           return  sabase.GetColumnValue("BASE_HOUR_SAL", hdPerId);
       }

       [WebMethod]
       public string WSMOB074(string hdPEKIND,string param)
       {

           return new FSC.Logic.CPAPC03M().GetCPAPC03M(hdPEKIND, param);
       }


       [WebMethod]
       public DataTable WSMOB075(string hdOrgcode,string hdDepart_id,string hdPerId)
       {
           return new FSC.Logic.Personnel().GetDataByQuery(hdOrgcode, hdDepart_id, "", hdPerId);
       }
     

    // WSMOB076
    [WebMethod]
    public string WSMOB076
        (string strReturnField, string strValue, string Orgcode)
    {
        string strRv = "";

        Hashtable ht = FSC.Logic.Content.getWorkTime(strValue, FSC.Logic.DateTimeInfo.GetRocDate(DateTime.Now), Orgcode);

        if (ht != null && ht.Count > 0)
        {
            if (strReturnField.Trim() == "WORKTIMEB")
                strRv = ht["WORKTIMEB"].ToString();
            if (strReturnField.Trim() == "WORKTIMEE")
                strRv = ht["WORKTIMEE"].ToString();
        }
        return strRv;
    }

    // WSMOB077
    // FSC.Logic.Content.getWorkTime
    [WebMethod]
    public string  WSMOB077
        (string strReturnField,string strValue)
    {
        string strRv = "";
  
        Hashtable ht = FSC.Logic.Content.getWorkTime(strValue, FSC.Logic.DateTimeInfo.GetRocDate(DateTime.Now));

        if (ht != null && ht.Count > 0)
        {          
            if(strReturnField.Trim() == "WORKTIMEB")
                strRv = ht["WORKTIMEB"].ToString();
            if (strReturnField.Trim() == "WORKTIMEE")
                strRv = ht["WORKTIMEE"].ToString();
        }
        return strRv;
    }

   
    [WebMethod]
    public double WSMOB078(string ddlleaveName)
    {
        double Inter_travel_hours = new LeaveMain().getInter_travel(ddlleaveName, (DateTime.Now.Year - 1911).ToString());

        return Inter_travel_hours;
    }

    [WebMethod]
    public string WSMOB079(string idCard)
    {
        FSC.Logic.Personnel psn = new FSC.Logic.Personnel();
        string PESEX = psn.GetColumnValue("PESEX", idCard);

        return PESEX;
    }

    [WebMethod]
    public string WSMOB080(string idCard)
    {
        FSC.Logic.Personnel psn = new FSC.Logic.Personnel();

        string employee_type = psn.GetColumnValue("Employee_type", idCard);

        return employee_type;
    }

    [WebMethod]
    public DataTable WSMOB081(string hdOrgcode, string hdDepart_id, string hdPerId, string hdYear, string hdMonth)
    {
        LabOvertimeFeeMasterDAO daoFeeMaster = new LabOvertimeFeeMasterDAO();
        DataTable dtFeeMaster = daoFeeMaster.GetDataByQuery(hdOrgcode, hdDepart_id, hdPerId, hdYear + hdMonth);

        return dtFeeMaster;
    }

    [WebMethod]
    public string WSMOB082(string id)
    {

        SAL.Logic.SABASE sabase = new SAL.Logic.SABASE();

        return sabase.GetColumnValue("base_prono", id);
    }
    
    // 取得 flowid 相關 DataTable Flow
    [WebMethod]
    public DataTable WSMOB083(string orgcode,string flowId)
    {
        SYS.Logic.Flow lm = new SYS.Logic.Flow();
        DataTable dt = lm.GetDataByOrgFid(orgcode, flowId);
        return dt;
    }

    // 取得 FlowID 相關的 LeaveMain
    [WebMethod]
    public DataTable WSMOB084(string orgcode, string flowId)
    {
        FSC.Logic.LeaveMain lm = new FSC.Logic.LeaveMain();
        DataTable dt = lm.GetDataByOrgFid(orgcode, flowId);
        return dt;
    }

    [WebMethod]
    public String WSMOB085(string LeaveType)
    {
        String strRv = new  SYS.Logic.LeaveType().GetLeaveName(LeaveType);
        return strRv;
    }

    // 2014/7/31 Eliot Chen
    // 086
    // 由性別取得假別
    [WebMethod]
    public DataTable WSMOB086(string orgcode,string genderFlag)
    {
        SYS.Logic.LeaveType lt = new SYS.Logic.LeaveType();

        DataTable dt= lt.GetDataBySexFlag(orgcode, genderFlag);

        return dt;
    }

    // WSMOB087
    // 2014/7/31 Eliot Chen
    // 一般請假 , 取得加班資料
    [WebMethod]
    public DataTable WSMOB087(string orgcode, string Apply_id)
    {
        FSC.Logic.FSC1101 bll = new FSC.Logic.FSC1101();
        DataTable dt = bll.GetOvertimeData(orgcode, Apply_id);
        return dt;

    }

    [WebMethod]
    public string WSMOB088(string Apply_id)
    {
        return new FSC.Logic.DepartEmp().GetDepartId(Apply_id);
    }

    // WSMOB089
    // 2014/8/2 Eliot Chen
    // 取得相關公差資料
    [WebMethod]
    public DataTable WSMOB089(string orgcode, string Apply_id)
    {
        FSC.Logic.FSC1101 bll = new FSC.Logic.FSC1101();
        DataTable dt = bll.GetBusinessData(orgcode, Apply_id);
        return dt;
    } 

    // WSMON090
    // 2014/8/2 Eliot Chen
    // 取得相關值班資料
    [WebMethod]
    public DataTable WSMOB090(string orgcode, string Apply_id)
    {
        FSC.Logic.FSC1101 bll = new FSC.Logic.FSC1101();
        DataTable dt = bll.GetScheduleData(orgcode, Apply_id);
        return dt;
    } 

    //========================================================================================

    private List<LeaveMainMapping> GetLeaveMainMappingData(string flowId, int leaveHours, string strLeaveType,
        string Apply_id,string Start_date,string End_date,string Start_time,string End_time
        , DataTable dt , string orgcode)
    {
        List<LeaveMainMapping> lmmList = new List<LeaveMainMapping>();
        int breakHours = 0;

        if (strLeaveType == "04")
        {
//            foreach (DataRow row in dt)
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                DataRow row = dt.Rows[i];
                string PSBREAKH = row["PSBREAKH"].ToString().Trim();// ((TextBox)gvr.FindControl("gv_tbPSBREAKH")).Text.Trim();
                //補休時數
                string PSADDD = row["PSADDD"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPRADDD")).Text;
                //加班起日
                string PSADDE = row["PSADDE"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPRADDD")).Text;
                //加班迄日
                string PSOVSTIME = row["PSOVSTIME"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPRSTIME")).Text;
                //加班起時
                string PSOVETIME = row["PSOVETIME"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPRETIME")).Text;
                //加班迄時
                double PRADDH = CommonFun.getDouble(row["PRADDH"].ToString().Trim());
                //加班時數
                double PRPAYH = CommonFun.getDouble(row["PRPAYH"].ToString().Trim());
                //已休時數
                double PRMNYH = CommonFun.getDouble(row["PRMNYH"].ToString().Trim());
                //已領時數時

                if (string.IsNullOrEmpty(PSBREAKH) | PSBREAKH == "0")
                {
                    continue;
                }

                breakHours += CommonFun.getInt(PSBREAKH);
                LeaveMainMapping lmm = new LeaveMainMapping();
                lmm.Orgcode = orgcode;// LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                lmm.FlowId = flowId;
                lmm.Idcard = Apply_id;
                lmm.StartDate = Start_date;
                lmm.EndDate = End_date;
                lmm.StartTime = Start_time;
                lmm.EndTime = End_time;
                lmm.LeaveHours = CommonFun.getInt(PSBREAKH);
                //補休時數
                lmm.LeaveType = strLeaveType;
                lmm.ApplyDateb = PSADDD;
                lmm.ApplyDatee = PSADDE;
                lmm.ApplyTimeb = PSOVSTIME;
                lmm.ApplyTimee = PSOVETIME;

                if (PRADDH - PRPAYH - PRMNYH < lmm.LeaveHours)
                {
                    throw new FlowException("欲補休時數不可大於加班時數減去已休已領時數!");
                }

                lmmList.Add(lmm);
            }

            if (breakHours != leaveHours)
            {
                throw new FlowException("補休時數有誤，請重新確認!");
            }
        }
        else if (strLeaveType == "20")
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string PXBREAKH = row["PXBREAKH"].ToString().Trim();//((TextBox)gvr.FindControl("gv_tbPXBREAKH")).Text.Trim();
                //補休時數
                string PPBUSDATEB = row["PPBUSDATEB"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPPBUSDATEB")).Text;
                //公差起日
                string PPBUSDATEE = row["PPBUSDATEE"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPPBUSDATEE")).Text;
                //公差迄日
                string PPTIMEB = row["PPTIMEB"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPPTIMEB")).Text;
                //公差起時
                string PPTIMEE = row["PPTIMEE"].ToString().Trim();//((Label)gvr.FindControl("gv_lbPPTIMEE")).Text;
                //公差迄時
                double PPHDAY = CommonFun.getDouble(row["PPHDAY"].ToString().Trim());//((Label)gvr.FindControl("gv_lbPPHDAY")).Text);
                //可休時數
                double PRPAYH = CommonFun.getDouble(row["PPPAYH"].ToString().Trim());//((Label)gvr.FindControl("gv_lbPPPAYH")).Text);
                //已休時數

                if (string.IsNullOrEmpty(PXBREAKH) | PXBREAKH == "0")
                {
                    continue;
                }

                breakHours += CommonFun.getInt(PXBREAKH);
                LeaveMainMapping lmm = new LeaveMainMapping();
                lmm.Orgcode = orgcode;// LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                lmm.FlowId = flowId;
                lmm.Idcard = Apply_id;// UcLeaveMember.Apply_id;

                lmm.LeaveHours = CommonFun.getInt(PXBREAKH);
                lmm.StartDate = Start_date;
                lmm.EndDate = End_date;
                lmm.StartTime = Start_time;
                lmm.EndTime = End_time;
                lmm.LeaveHours = CommonFun.getInt(PXBREAKH);
                //補休時數
                lmm.LeaveType = strLeaveType;// ddlLeave_type.SelectedValue;
                lmm.ApplyDateb = PPBUSDATEB;
                lmm.ApplyDatee = PPBUSDATEE;
                lmm.ApplyTimeb = PPTIMEB;
                lmm.ApplyTimee = PPTIMEE;

                //Dim PPBUSPLACE As String = CType(gvr.FindControl("gv_lbPPBUSPLACE"), Label).Text.Trim()
                //If -1 < PPBUSPLACE.IndexOf("公假") Then
                //    hasPublicDay = True
                //End If

                if (FSC.Logic.Content.ConvertToHours(PPHDAY) - CommonFun.getInt(PRPAYH) < CommonFun.getInt(PXBREAKH))
                {
                    throw new FlowException("欲補休時數不可大於可休日時數減去已休時數!");
                }

                lmmList.Add(lmm);
            }

            if (breakHours != leaveHours)
            {
                throw new FlowException("補休時數有誤，請重新確認!");
            }

        }
        else if (strLeaveType == "32")
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string hours = row["BreakHours"].ToString().Trim();//((TextBox)gvr.FindControl("gv_tbBreakHours")).Text.Trim();
                //補休時數
                string scheDate = row["Sche_date"].ToString().Trim();//((Label)gvr.FindControl("gv_lbScheDate")).Text;
                //公差起日

                double scheduleHours = CommonFun.getDouble(row["schedule_hours"].ToString().Trim());//((Label)gvr.FindControl("gv_lbScheduleHours")).Text);
                //可休時數
                double restHours = CommonFun.getDouble(row["rest_hours"].ToString().Trim());//((Label)gvr.FindControl("gv_lbRestHours")).Text);
                //已休時數

                if (string.IsNullOrEmpty(hours) | hours == "0")
                {
                    continue;
                }

                breakHours += CommonFun.getInt(hours);
                LeaveMainMapping lmm = new LeaveMainMapping();
                lmm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                lmm.FlowId = flowId;
                lmm.Idcard = Apply_id;
                lmm.StartDate = Start_date;
                lmm.EndDate = End_date;
                lmm.StartTime = Start_time;
                lmm.EndTime = End_time;
                lmm.LeaveHours = CommonFun.getInt(hours);
                //補休時數
                lmm.LeaveType = strLeaveType;
                lmm.ApplyDateb = scheDate;
                lmm.ApplyDatee = "";
                lmm.ApplyTimeb = "";
                lmm.ApplyTimee = "";

                if (scheduleHours - CommonFun.getDouble(restHours) < CommonFun.getDouble(hours))
                {
                    throw new FlowException("欲補休時數不可大於可休日時數減去已休時數!");
                }

                lmmList.Add(lmm);
            }

            if (breakHours != leaveHours)
            {
                throw new FlowException("補休時數有誤，請重新確認!");
            }


        }

        return lmmList;
    }


    private string buildJSONErr
        (string strErrMsg)
    {
        string strResult;
        strResult =
           "\"isSuccess\":\"N\"";
        strResult +=
            ",\"message\":\"" + strErrMsg.Replace("\\", "\\\\") + "\"";
        return strResult;
    }

    // 檢查驗證碼
    private bool chackAuth(string str)
    {
        // 先不做檢查
        return true;
    }

    // 檢查員工編號之裝置是否已註冊
    private bool chackIDandDvice(string Id_Card, string Device_ID)
    {
        // 先不做檢查，後補
        return true;
    }

    // DataTable -> JSON Array in ResultList 
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
