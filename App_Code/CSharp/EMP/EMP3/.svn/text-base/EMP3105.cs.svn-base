using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;
using System.Text;

using FSCPLM.Logic;

/// <summary>
/// EMP3105 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMP3105
    {
        private EMP3105DAO DAO;

        private string[] strIDCode =
        {"0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E",
            "F","G","H","J",
            "K","L","M","N",
            "P","Q","R","S","T",
            "U","V","W","X","Y","Z"};



        public EMP3105()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMP3105DAO();
        }

        public EMP3105(SqlConnection conn)
        {
            DAO = new EMP3105DAO(conn);
        }

        public int insertEmpMember(
            string strIdCard,
            string strAdId,
            string strUserName,
            string strEmail,
            string strEmployeeType,
            string strBossLevelID,
            string strActDate,
            string strFirstGovDate,
            string strLeftDate,
            string strLivePhone,
            string strPhone,
            string strExt,
            string strDeleteFlag,
            string strQuitJobFlag,
            string strChangeUserID,
            string strIDNumber,
            string strTitleNo,
            string strGender,
            string strYoyoCard,
            string strServiceyear
            )
        {
            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, strIDNumber, "Y", "", strUserName, strGender, "", "", "", "");
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, strIDNumber, "Y", "", strUserName, strGender, "", "", "", "");
            }



            return DAO.insertEmpMember(
             strIdCard,
             strAdId,
             strUserName,
             strEmail,
             strEmployeeType,
             strBossLevelID,
             strActDate,
             strFirstGovDate,
             strLeftDate,
             strLivePhone,
             strPhone,
             strExt,
             strDeleteFlag,
             strQuitJobFlag,
             strChangeUserID,
            strIDNumber,
            strTitleNo,
            strGender,
            strYoyoCard,
            strServiceyear
             );




        }

        public int insertNonEmpMember(
            string strIdCard,
            string strAdId,
            string strUserName,
            string strEmail,
            string strNonEmployeeType,
            //        string strBossLevelID,
            string strActDate,
            //        string strFirstGovDate,
            string strLeftDate,
            //        string strLivePhone,
            string strPhone,
            string strExt,
            //        string strDeleteFlag,
            //        string strQuitJobFlag,
            string strChangeUserID,
            string strIDNumber,
            string strGender,
            string strYoyoCard,
            string strServiceyear
            )
        {
            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, strIDNumber, "N", "", strUserName, strGender, "", "", "", "");
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, strIDNumber, "N", "", strUserName, strGender, "", "", "", "");
            }

            return DAO.insertNonEmpMember(
                strIdCard,
                strAdId,
                strUserName,
                strEmail,
                strNonEmployeeType,
                //        string strBossLevelID,
                strActDate,
                //        string strFirstGovDate,
                strLeftDate,
                //        string strLivePhone,
                strPhone,
                strExt,
                //        string strDeleteFlag,
                //        string strQuitJobFlag,
                strChangeUserID,
                strIDNumber,
                strGender,
                strYoyoCard,
                strServiceyear
            );

        }


        // 取得職務類別
        public DataTable querySysLeaveKind(
            string strOrgCode
            )
        {
            DataTable dt = DAO.querySysLeaveKind
                (strOrgCode);
            return dt;
        }

        // 新增資料
        // FSC_Personnel
        public int insertFscPersonnel(
                string strIdCard,
                string strTitleNo,
                string strUserName,
                string strEmployeeType,
                string strLevel,
                string strActDate,
                string strFirstGovDate,
                string strLeftDate,
                string strLeaveYrAdd,
                string strLeaveYrBDate,
                string strShiftType,
                string strPehYear,
                string strPehDay,
                string strPehDay2,
                string strPehDay3,
                string strPeKind,
                string strPerday1,
                string strPerday2,
                string strRoleID,
                string strChangeUserID,
            string strPrPoint,
            string strProfess,
            string strChidf,
            string strKind,
            string strLoginType
            , string strSyslogin // 是否可使用人員切換
            , string strOnDuty  // 是否為值班人員  
            , string strIdNumber    // 身份證
            , string strGender      // 性別
            , string BirthDate      // 生日
            , string strBoss_level_id
            , string strEmail
            , string strAdId
            , string strMutiDepartDeputy_flag
            , string strServiceyear
            )
        {

            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, "", "", "", "", "", "", "", "", strPrPoint);
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, "", "", "", "", "", "", "", "", strPrPoint);
            }

            return DAO.insertFscPersonnel(
                strIdCard,
                strTitleNo,
                strUserName,
                strEmployeeType,
                strLevel,
                strActDate,
                strFirstGovDate,
                strLeftDate,
                strLeaveYrAdd,
                strLeaveYrBDate,
                strShiftType,
                strPehYear,
                strPehDay,
                strPehDay2,
                strPehDay3,
                strPeKind,
                strPerday1,
                strPerday2,
                strRoleID,
                strChangeUserID,
             strPrPoint,
             strProfess,
             strChidf,
             strKind,
             strLoginType
            , strSyslogin // 是否可使用人員切換
            , strOnDuty  // 是否為值班人員     
            , strIdNumber    // 身份證
            , strGender      // 性別
            , BirthDate      // 生日
            , strBoss_level_id
            , strEmail
            , strAdId
            , strMutiDepartDeputy_flag
            , strServiceyear
             );

        }

        public DataTable queryData(
            string strOrgCode,
            string strDepartID,
            string strUserName,
            string strEmployeeType,
            string strIDCard,
            string strIDCard2,
            string strQuitJob,
            string strTitleNo
            )
        {
            // 這隻都先 Mark
            // SALARY.Logic.app.GetSaCode_Desc1 相關
            DataTable dt = DAO.queryData
                (strOrgCode, strDepartID, strUserName, strEmployeeType, strIDCard, strIDCard2, strQuitJob, strTitleNo);

   /*         dt.Columns.Add("RowNO");        // 象次
            dt.Columns.Add("OrgName");
            dt.Columns.Add("DepartName");
            dt.Columns.Add("Title_Name");
            dt.Columns.Add("EMPLOYEE_TYPE_NAME");
            dt.Columns.Add("BossName");
            dt.Columns.Add("RoleName");
            dt.Columns.Add("BossLevelName");
            dt.Columns.Add("AgentName");

            // EMP_STAFFINTRO_MAIN 相關欄位
            dt.Columns.Add("BIRTH_DATE");
            dt.Columns.Add("INTRO_DESC");
            dt.Columns.Add("SKILL_DESC");
            dt.Columns.Add("SPECIALTY_DESC");
            dt.Columns.Add("PICFILE_PATH");
            dt.Columns.Add("MOOD_DESC");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["RowNO"] = Convert.ToString(i + 1);
                
                dt.Rows[i]["OrgName"] = EMPCommon.getOrgName(dt.Rows[i]["ORGCODE"].ToString());
                
                
                EMP3102DAO emp3102dao = new EMP3102DAO();
                string strDepartName = emp3102dao.getDeptNameByDepartID(strOrgCode, dt.Rows[i]["DEPART_ID"].ToString());
                if (strDepartName != "")
                {
                    dt.Rows[i]["DepartName"] =
                        strDepartName;
                    //emp3102dao.getDeptNameByDepartID(strOrgCode, dt.Rows[i]["DEPART_ID"].ToString());
                }
                else
                {
                    dt.Rows[i]["DepartName"] = "";
                }
                
                
                string strEmployeeTypeName=SALARY.Logic.app.GetSaCode_Desc1("023", "022", 
                    dt.Rows[i]["EMPLOYEE_TYPE"].ToString());
                
                if (strEmployeeTypeName!="")
                {
                    dt.Rows[i]["EMPLOYEE_TYPE_NAME"] = strEmployeeTypeName;
                }
                else
                {
                    dt.Rows[i]["EMPLOYEE_TYPE_NAME"] = "";
                }
                
                //dt.Rows[i]["BossName"] = SALARY.Logic.app.GetSaCode_Desc1("002", "017", dt.Rows[i]["EMPLOYEE_TYPE"].ToString());
                
                EMP3103 emp3103 = new EMP3103();

                string strBossName = emp3103.getUserName(dt.Rows[i]["BOSS_IDCARD"].ToString());
                dt.Rows[i]["BossName"] = strBossName;

                string[] strRoles = dt.Rows[i]["Role_id"].ToString().Split(',');
                string strRoleNames = "";
                for (int j = 0; j < strRoles.Length; j++)
                {
                    if (strRoleNames != "") strRoleNames += ",";
                    //DataTable dtRole = //DAO.getSysRole(strOrgCode, "", dt.Rows[i]["ROLE_ID"].ToString(), "", "", "");

                    //    new RoleDAO(new System.Data.SqlClient.SqlConnection(ConnectDB.GetDBString())).Get_Role(
                    //        dt.Rows[i]["ORGCODE"].ToString(), dt.Rows[i]["ROLE_ID"].ToString());
                    DataTable dtRole = new SYS.Logic.Role().GetRole(dt.Rows[i]["ORGCODE"].ToString(), strRoles[j]);
                    if (dtRole != null && dtRole.Rows.Count > 0)
                        strRoleNames += dtRole.Rows[0]["Role_Name"].ToString();
                }

                
                dt.Rows[i]["Title_Name"] = SALARY.Logic.app.GetSaCode_Desc1("023", "012", dt.Rows[i]["TITLE_NO"].ToString());
               
                dt.Rows[i]["RoleName"] = strRoleNames;

                dt.Rows[i]["BossLevelName"] = getBOSS_LEVEL_Name(dt.Rows[i]["BOSS_LEVEL_ID"].ToString());
                //dt.Rows[i]["AgentName"] = emp3103.getUserName(dt.Rows[i]["Agent_idcard"].ToString());

                // EMP_STAFFINTRO_MAIN
                DataTable dtEmpStaffIntroMain = DAO.queryEmpStaffIntroMain(dt.Rows[i]["ID_CARD"].ToString());
                if (dtEmpStaffIntroMain.Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"]))
                    {
                        dt.Rows[i]["BIRTH_DATE"] = dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"].ToString();
                        //                            ConvertDate2ROCDateString(Convert.ToDateTime(dtEmpStaffIntroMain.Rows[0]["BIRTH_DATE"]));
                    }
                    dt.Rows[i]["INTRO_DESC"] = dtEmpStaffIntroMain.Rows[0]["INTRO_DESC"].ToString();
                    dt.Rows[i]["SKILL_DESC"] = dtEmpStaffIntroMain.Rows[0]["SKILL_DESC"].ToString();
                    dt.Rows[i]["SPECIALTY_DESC"] = dtEmpStaffIntroMain.Rows[0]["SPECIALTY_DESC"].ToString();
                    dt.Rows[i]["MOOD_DESC"] = dtEmpStaffIntroMain.Rows[0]["MOOD_DESC"].ToString();
                    dt.Rows[i]["PICFILE_PATH"] = dtEmpStaffIntroMain.Rows[0]["PICFILE_PATH"].ToString();
                }
                
                
            }

            */

            return dt;
        }

        public string getBOSS_LEVEL_Name(string BOSS_LEVEL_ID)
        {
            string strRetuenValue = "";
            if (BOSS_LEVEL_ID == "0")
            {
                strRetuenValue = "非主管";
            }
            else if (BOSS_LEVEL_ID == "1")
            {
                strRetuenValue = "一層主管";
            }
            else if (BOSS_LEVEL_ID == "2")
            {
                strRetuenValue = "二層主管";
            }
            else if (BOSS_LEVEL_ID == "3")
            {
                strRetuenValue = "三層主管";
            }
            else if (BOSS_LEVEL_ID == "4")
            {
                strRetuenValue = "四層主管";
            }
            return strRetuenValue;
        }

        public DataTable getEmpDepartEmp(
            string strOrgCode,
            string strIDCard,
            string strDepartID,
            string strServicesType
            )
        {
            DataTable dt = DAO.getEmpDepartEmp(
            strOrgCode,
            strIDCard,
            strDepartID,
            strServicesType
            );

            // 增加 Boss
            dt.Columns.Add("BOSS_IDCARD");
            dt.Columns.Add("BOSS_DEPART_ID");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtBoss = DAO.getFscPersonalBoss(
                    strOrgCode,
                    dt.Rows[i]["DEPART_ID"].ToString(),
                    strIDCard
                );
                if (dtBoss.Rows.Count > 0)
                {
                    dt.Rows[i]["BOSS_IDCARD"] =
                        dtBoss.Rows[0]["BOSS_IDCARD"].ToString();
                    dt.Rows[i]["BOSS_DEPART_ID"] =
                        dtBoss.Rows[0]["BOSS_DEPARTID"].ToString();
                }

            }

            return dt;

        }

        public DataTable getEmpDepartEmp(
            string strOrgCode,
            string strIDCard,
            string strDepartID
            )
        {
            return getEmpDepartEmp(
                strOrgCode, strIDCard, strDepartID, "");
        }

        public DataTable getSysRole(
            string strOrgCode,
            string strDepartID,
            string strRoleID,
            string strManagerFlag,
            string strRoleStatus,
            string strDeleteFlag
            )
        {
            DataTable dt = DAO.getSysRole(
                strOrgCode,
                strDepartID,
                strRoleID,
                strManagerFlag,
                strRoleStatus,
                strDeleteFlag
            );

            return dt;
        }

        // 新增 EMP_DEPART_EMP
        public int insertEmpDepartEmp(
            string strOrgCode,
            string strDepartId,
            string strIDCard,
            string strServiceSDate,
            string strServiceEDate,
            string strServiceType,
            string strChangeUserID
            )
        {
            if (strServiceType == "0")
            {
                string strSDate = "";
                string strEDate = "";
                if (strServiceSDate != "") strSDate = Convert.ToString(Convert.ToInt32(strServiceSDate.Substring(0, 3)) + 1911).PadLeft(4, '0') + strServiceSDate.Substring(3, 4);
                if (strServiceEDate != "") strEDate = Convert.ToString(Convert.ToInt32(strServiceEDate.Substring(0, 3)) + 1911).PadLeft(4, '0') + strServiceEDate.Substring(3, 4);

                if (DAO.SalSaBaseExists(strIDCard))
                {
                    DAO.UpdateSalSaBase(strIDCard, "", "", strOrgCode, "", "", "", strSDate, strEDate, "");
                }

                else
                {
                    DAO.InsertSalSaBase(strIDCard, "", "", strOrgCode, "", "", "", strSDate, strEDate, "");
                }
            }

            return DAO.insertEmpDepartEmp(
             strOrgCode,
             strDepartId,
             strIDCard,
             strServiceSDate,
             strServiceEDate,
             strServiceType,
             strChangeUserID
            );
        }

        // 新增 FSC_PERSONNEL_BOSS
        // 主管
        public int insertFscPersonnelBoss(
            string strOrgCode,
            string strDepartID,
            string strIDCard,
            string strServiceType,
            //            string strBossOrgCode,
            //            string strBossDepartID,
            //            string strBossPosID,
            string strBOSSDepartId,
            string strBossIDCard,
            //            string strBossSType,
            string strChangeUserID
            )
        {
            // 查詢 BOSS 資料
            DataTable dt =
                queryData(strOrgCode, strBOSSDepartId, "", "", strBossIDCard, "", "", "");
            string strBossOrgCode = "";
            string strBossDepartID = "";
            string strBossPosID = "";
            string strBossSType = "";
            if (dt.Rows.Count > 0)
            {
                strBossOrgCode = dt.Rows[0]["ORGCODE"].ToString();
                strBossDepartID = dt.Rows[0]["DEPART_ID"].ToString();
                strBossSType = dt.Rows[0]["SERVICE_TYPE"].ToString();
                strBossPosID = dt.Rows[0]["Title_no"].ToString();
            }


            return DAO.insertFscPersonnelBoss(
             strOrgCode,
             strDepartID,
             strIDCard,
             strServiceType,
             strBossOrgCode,
             strBossDepartID,
             strBossPosID,
             strBossIDCard,
             strBossSType,
             strChangeUserID
            );
        }

        public static DateTime convertROCDate2Date(string strROCYM)
        {
            if (strROCYM.Length != 7) return DateTime.MinValue;
            int iYear = Convert.ToInt32(strROCYM.Substring(0, 3)) + 1911;
            int iMonth = Convert.ToInt32(strROCYM.Substring(3, 2));
            int iDay = Convert.ToInt32(strROCYM.Substring(5, 2));
            DateTime dt = new DateTime(iYear, iMonth, iDay);
            return dt;
        }

        public static string convertROCDate2DateString(string strROCYM)
        {
            if (strROCYM.Length != 7) return "";
            int iYear = Convert.ToInt32(strROCYM.Substring(0, 3)) + 1911;
            int iMonth = Convert.ToInt32(strROCYM.Substring(3, 2));
            int iDay = Convert.ToInt32(strROCYM.Substring(5, 2));
            DateTime dt = new DateTime(iYear, iMonth, iDay);
            string strTemp = String.Format("{0:yyyy/MM/dd}", dt);
            return strTemp;
        }


        public static string ConvertDate2ROCDateString(DateTime dt)
        {
            string strTemp = String.Format("{0:yyyyMMdd}", dt);
            int iYear = Convert.ToInt32(strTemp.Substring(0, 4)) - 1911;
            strTemp =
                iYear.ToString().PadLeft(3, '0') +
                strTemp.Substring(4, 4);
            return strTemp;


        }



        // 新增 EMP_STAFFINTRO_MAIN
        public int insertEmpStaffintroMain(
            string strBirthDate,
            string strIntroDesc,
            string strSkillDesc,
            string strSpecialtyDesc,
            string strMoodDesc,
            string strPicfilePath,
            string strChangeUserID,
            string strIDCard
            )
        {
            return DAO.insertEmpStaffintroMain(
                strBirthDate,
                strIntroDesc,
                strSkillDesc,
                strSpecialtyDesc,
                strMoodDesc,
                strPicfilePath,
                strChangeUserID,
                strIDCard
            );
        }

        public int insertFscPersonalBoss(
            string strOrgCode,
            string strDepartID,
            string strIDCard,
            string strServiceType,
            string strBoosOrgCode,
            string strBossDepartID,
            string strBossPosID,
            string strBossIDCard,
            string strBossSType,
            string strChangeUserID
            )
        {
            return DAO.insertFscPersonalBoss(
             strOrgCode,
             strDepartID,
             strIDCard,
             strServiceType,
             strBoosOrgCode,
             strBossDepartID,
             strBossPosID,
             strBossIDCard,
             strBossSType,
             strChangeUserID
            );
        }

        private string IDCardString(string strIDNum, string isEmp)
        {
            int iMaxCharNum = 33;
            if (isEmp == "Y") iMaxCharNum = 32;
            // 第一個文字
            string strChar1 = strIDNum.Substring(0, 1);
            //return strChar1;

            // 第二個文字    
            string strChar2 = strIDNum.Substring(1, 1);

            int iFirst = 0;


            if (Array.IndexOf(strIDCode, strChar1) >= 0)
            {
                iFirst = (Array.IndexOf(strIDCode, strChar1)) * 100000;
            }
            //return iFirst.ToString();

            int iSecend = 0;
            if (Array.IndexOf(strIDCode, strChar2) >= 0)
            {
                iSecend = (Array.IndexOf(strIDCode, strChar2)) * 1000;
            }

            int iNumber = iFirst + iSecend + Convert.ToInt32(strIDNum.PadLeft(7, '0').Substring(4, 3));

            iNumber++;

            if (Convert.ToInt32(iNumber.ToString().PadLeft(7, '0').Substring(2, 2)) > iMaxCharNum)//33)
            {
                iNumber =
                    (Convert.ToInt32(iNumber.ToString().PadLeft(7, '0').Substring(0, 2)) + 1) * 100000 +
                    Convert.ToInt32(iNumber.ToString().PadLeft(7, '0').Substring(4, 3));
            }

            // 再拆解數字
            strChar1 = strIDCode[Convert.ToInt32(iNumber.ToString().PadLeft(7, '0').Substring(0, 2))];
            strChar2 = strIDCode[Convert.ToInt32(iNumber.ToString().PadLeft(7, '0').Substring(2, 2))];
            string strRt =
                   strChar1.PadLeft(1, '0') + strChar2.PadLeft(1, '0') +
                   iNumber.ToString().PadLeft(7, '0').Substring(4, 3);


            return strRt;
        }

        // 產生員工代碼
        public string genIDCard(
            string strOrgCode,
            string strEmployeeType)
        {
            string strRetunValue = "";
            // 取得資料庫中最大的號碼
            string strMaxID = DAO.getMaxIdCard(strEmployeeType);
            // 取一個新號碼

            //int iIDCardTemp = Convert.ToInt32(strMaxID) + 1;

            //           if (iIDCardTemp == 88888) iIDCardTemp++;
            //           if (iIDCardTemp == 99999) iIDCardTemp++;



            string strTemp = ""; //Convert.ToString(iIDCardTemp);
            int iTemp = 0;
            if (strEmployeeType == "13" || strEmployeeType == "14" || strEmployeeType == "15")
            {
                strMaxID = IDCardString(strMaxID.PadLeft(5, '0'), "N");

                strTemp = strMaxID.PadLeft(5, '0');

                iTemp =
                    3 * 1 +
                    3 * 5 +
                    Array.IndexOf(strIDCode, strTemp.Substring(1, 1)) * 4 +
                    Array.IndexOf(strIDCode, strTemp.Substring(2, 1)) * 3 +
                    Array.IndexOf(strIDCode, strTemp.Substring(3, 1)) * 2 +
                    Array.IndexOf(strIDCode, strTemp.Substring(4, 1)) * 1;
                iTemp = iTemp % 10;
                if (iTemp > 0)
                {
                    iTemp = 10 - iTemp;
                }
                strRetunValue = 'Z' + strMaxID.PadLeft(5, '0').Substring(1, 4) +
                    Convert.ToString(iTemp).PadLeft(1, '0');

            }
            else
            {
                strMaxID = IDCardString(strMaxID.PadLeft(5, '0'), "Y");
                strTemp = strMaxID.PadLeft(6, '0');
                iTemp =
                    Array.IndexOf(strIDCode, strTemp.Substring(0, 1)) * 1 +
                    Array.IndexOf(strIDCode, strTemp.Substring(1, 1)) * 5 +
                    Array.IndexOf(strIDCode, strTemp.Substring(2, 1)) * 4 +
                    Array.IndexOf(strIDCode, strTemp.Substring(3, 1)) * 3 +
                    Array.IndexOf(strIDCode, strTemp.Substring(4, 1)) * 2 +
                    Array.IndexOf(strIDCode, strTemp.Substring(5, 1)) * 1;
                iTemp = iTemp % 10;
                if (iTemp > 0)
                {
                    iTemp = 10 - iTemp;
                }
                strRetunValue = strMaxID.PadLeft(5, '0') +
                    Convert.ToString(iTemp);
            }


            return strRetunValue;// strRetunValue;
        }

        // 取得最大序號之員工代碼
        public string GetColumnValue(string strOrgCode, string strColumnNm, string strIDCarrd)
        {
            string strReturnValue = "";
            DataTable dt = DAO.queryData(strOrgCode, "", "", "", strIDCarrd, "", "", "");
            if (dt.Rows.Count > 0)
            {
                strReturnValue = dt.Rows[0][strColumnNm].ToString();
            }
            return strReturnValue;

        }

        public DataTable queryEmpStaffIntroMain(
       string ID_CARD     
       )
        {
            return DAO.queryEmpStaffIntroMain(ID_CARD);
        }



        // 
        public int updaeEmpMember(
            string strIdCard,
            string strAdId,
            string strUserName,
            string strEmail,
            string strEmployeeType,
            string strBossLevelID,
            string strActDate,
            string strFirstGovDate,
            string strLeftDate,
            string strLivePhone,
            string strPhone,
            string strExt,
            string strDeleteFlag,
            string strQuitJobFlag,
            string strChangeUserID,
            string strIDNumber,
            string strTitleNo,
            string strGender,
            string strYoyoCard,
            string strServiceyear
            )
        {
            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, strIDNumber, "Y", "", strUserName, strGender, "", "", "", "");
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, strIDNumber, "Y", "", strUserName, strGender, "", "", "", "");
            }

            return DAO.updaeEmpMember(
         strIdCard,
         strAdId,
         strUserName,
         strEmail,
         strEmployeeType,
         strBossLevelID,
         strActDate,
         strFirstGovDate,
         strLeftDate,
         strLivePhone,
         strPhone,
         strExt,
         strDeleteFlag,
         strQuitJobFlag,
         strChangeUserID,
         strIDNumber,
         strTitleNo,
         strGender,
         strYoyoCard,
         strServiceyear
        );
        }

        public int UpdateEmpNonMember(
            string strIdCard,
            string strAdId,
            string strUserName,
            string strEmail,
            string strNonEmployeeType,
            //        string strBossLevelID,
            string strActDate,
            //        string strFirstGovDate,
            string strLeftDate,
            //        string strLivePhone,
            string strPhone,
            string strExt,
            //        string strDeleteFlag,
            //        string strQuitJobFlag,
            string strChangeUserID,
            string strIDNumber,
            string strGender,
            string strYoyoCard,
            string strServiceyear)
        {
            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, strIDNumber, "N", "", strUserName, strGender, "", "", "", "");
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, strIDNumber, "N", "", strUserName, strGender, "", "", "", "");
            }

            return DAO.UpdateEmpNonMember(
             strIdCard,
             strAdId,
             strUserName,
             strEmail,
             strNonEmployeeType,
             strActDate,
             strLeftDate,
             strPhone,
             strExt,
             strChangeUserID,
             strIDNumber,
             strGender, strYoyoCard,
             strServiceyear);
        }



        public int UpdateFscPersonnel(
                string strIdCard,
        string strTitleNo,
        string strUserName,
        string strEmployeeType,
        string strLevel,
        string strActDate,
        string strFirstGovDate,
        string strLeftDate,
        string strLeaveYrAdd,
        string strLeaveYrBDate,
        string strShiftType,
        string strPehYear,
        string strPehDay,
        string strPehDay2,
        string strPehDay3,
        string strPeKind,
        string strPerday1,
        string strPerday2,
        string strRoleID,
        string strChangeUserID,
        string strPrPoint,
        string strProfess,
        string strChidf,
        string strKind,
        string strLoginType
           , string strSyslogin // 是否可使用人員切換
            , string strOnDuty  // 是否為值班人員    
            , string strIdNumber    // 身份證
            , string strGender      // 性別
            , string BirthDate      // 生日
            , string strBoss_level_id
            , string strEmail
            , string strAdId
            , string strMutiDepartDeputy_flag
            , string strServiceyear
            , string strYoyoCard_Change_flag
            )
        {

            if (DAO.SalSaBaseExists(strIdCard))
            {
                DAO.UpdateSalSaBase(strIdCard, "", "", "", "", "", "", "", "", strPrPoint);
            }

            else
            {
                DAO.InsertSalSaBase(strIdCard, "", "", "", "", "", "", "", "", strPrPoint);
            }

            if (DAO.isFscPersonnelExists(strIdCard))
            {

                return DAO.UpdateFscPersonnel(
                     strIdCard,
             strTitleNo,
             strUserName,
             strEmployeeType,
             strLevel,
             strActDate,
             strFirstGovDate,
             strLeftDate,
             strLeaveYrAdd,
             strLeaveYrBDate,
             strShiftType,
             strPehYear,
             strPehDay,
             strPehDay2,
             strPehDay3,
             strPeKind,
             strPerday1,
             strPerday2,
             strRoleID,
             strChangeUserID,
             strPrPoint,
             strProfess,
             strChidf,
             strKind,
             strLoginType
               , strSyslogin // 是否可使用人員切換
                , strOnDuty  // 是否為值班人員   
                , strIdNumber    // 身份證
                , strGender      // 性別
                , BirthDate      // 生日
                , strBoss_level_id
                , strEmail
                , strAdId
                , strMutiDepartDeputy_flag
                , strServiceyear
                , strYoyoCard_Change_flag
             );
            }
            else
            {
                // 新增
                return DAO.insertFscPersonnel(
    strIdCard,
    strTitleNo,
    strUserName,
    strEmployeeType,
    strLevel,
    strActDate,
    strFirstGovDate,
    strLeftDate,
    strLeaveYrAdd,
    strLeaveYrBDate,
    strShiftType,
    strPehYear,
    strPehDay,
    strPehDay2,
    strPehDay3,
    strPeKind,
    strPerday1,
    strPerday2,
    strRoleID,
    strChangeUserID,
 strPrPoint,
 strProfess,
 strChidf,
 strKind,
 strLoginType
, strSyslogin // 是否可使用人員切換
, strOnDuty  // 是否為值班人員     
, strIdNumber    // 身份證
, strGender      // 性別
, BirthDate      // 生日
, strBoss_level_id
, strEmail
, strAdId
, strMutiDepartDeputy_flag
, strServiceyear
 );
            }
        }

        public int UpdateEmpStaffIntroMain(
            string strBirthDate,
            string strIntroDesc,
            string strSkillDesc,
            string strSpecialtyDesc,
            string strMoodDesc,
            string strPicfilePath,
            string strChangeUserID,
            string strIDCard)
        {
            return DAO.UpdateEmpStaffIntroMain(
             strBirthDate,
             strIntroDesc,
             strSkillDesc,
             strSpecialtyDesc,
             strMoodDesc,
             strPicfilePath,
             strChangeUserID,
             strIDCard);
        }

        public int deleteEmpDepartEmp(
            string strOrgCode,
            string strIdCard,
            string strDepartID,
            string strServicesType,
            string strServicesDate
            )
        {
            return DAO.deleteEmpDepartEmp(
             strOrgCode,
             strIdCard,
             strDepartID,
             strServicesType,
             strServicesDate);
        }

        public int deleteFSCPERSONNELBOSS(
            string strIdCard,
            string strOrgCode,
            string strDepartID
            )
        {
            return DAO.deleteFSCPERSONNELBOSS(
             strIdCard,
             strOrgCode,
             strDepartID);
        }


        public void deleteEMPMemberNonMember(string strIdCard)
        {
            DAO.deleteEMPMemberNonMember(strIdCard);
        }

        public bool isUserExists(
             string strIdNumber
             )
        {
            return DAO.isUserExists(strIdNumber);
        }

        public bool isUserExists2(
           string strIdNumber
           )
        {
            return DAO.isUserExists2(strIdNumber);
        }

        public bool isADExists(
             string strADId
             )
        {
            return DAO.isADExists(strADId);
        }

        public bool isyoyoExists(
             string stryoyo
             )
        {
            return DAO.isyoyoExists(stryoyo);
        }

        public string getParentDeptNameByDepartID
        (
                    //string strOrgCode,
        string strDepartID
        )
        {
            return DAO.getParentDeptNameByDepartID(strDepartID);
        }
    }


}