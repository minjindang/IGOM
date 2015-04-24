using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3105DAO 的摘要描述
/// 人員資料設定
/// </summary>
public class EMP3105DAO : BaseDAO
{
	public EMP3105DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public EMP3105DAO(SqlConnection conn)
        : base(conn)
    {

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
        string strSQL =
            "INSERT INTO EMP_MEMBER " +
            "(ID_CARD " +
           ",AD_ID " +
           ",USER_NAME " +
           ",EMAIL " +
           ",EMPLOYEE_TYPE " +
           ",BOSS_LEVEL_ID " +
           ",ACT_DATE " +
           ",FIRST_GOV_DATE " +
           ",LEFT_DATE " +
           ",LIVE_PHONE " +
           ",PHONE " +
           ",EXT " +
           ",DELETE_FLAG " +
           ",QUIT_JOB_FLAG " +
           ",CHANGE_USERID " +
           ",ID_NUMBER " +
           ",GENDER " +
           ",TITLe_NO " +
           ",CHANGE_DATE "+
           ",Yoyo_Card " +
            ",Service_year) " +
     "VALUES " +
           "(@IdCard " +//<ID_CARD, VARCHAR(20),>
           ",@AdId " +//<AD_ID, VARCHAR(20),>
           ",@UserName " +   //<USER_NAME, NVARCHAR(50),>
           ",@Email " +   // <EMAIL, NVARCHAR(50),>
           ",@EmployeeType " +   // <EMPLOYEE_TYPE, VARCHAR(2),>
           ",@BossLevelID " + // <BOSS_LEVEL_ID, VARCHAR(2),>
           ",@ActDate " + //<ACT_DATE, DATETIME,>
           ",@FirstGovDate " +// <FIRST_GOV_DATE, DATETIME,>
           "";
        if (strLeftDate!="")
        {
            strSQL +=
           ",@LeftDate ";//<LEFT_DATE, DATETIME,>
        }
            else{
                strSQL +=
                    " ,null ";
        }
        strSQL+=
           ",@LivePhone " +//<LIVE_PHONE, VARCHAR(20),>
           ",@Phone " +//<PHONE, VARCHAR(20),>
           ",@Ext " +//<EXT, VARCHAR(10),>
           ",@DeleteFlag " + // <DELETE_FLAG, VARCHAR(1),>
           ",@QuitJobFlag " + // <QUIT_JOB_FLAG, VARCHAR(1),>
           ",@ChangeUserID " +//<CHANGE_USERID, VARCHAR(10),>
           ",@IDNumber " +//<CHANGE_USERID, VARCHAR(10),>
           ",@Gender "+
           ",@TitleNo "+
          ",getDate() "+
          ",@YoyoCard "+
          ",@Service_year " +
        ") "; //<CHANGE_DATE, DATETIME,>

        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@AdId", strAdId),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@EmployeeType", strEmployeeType),
            new SqlParameter("@BossLevelID", strBossLevelID),
            new SqlParameter("@ActDate", strActDate),
            new SqlParameter("@FirstGovDate", strFirstGovDate),
            new SqlParameter("@LeftDate", strLeftDate),
            new SqlParameter("@LivePhone", strLivePhone),
            new SqlParameter("@Phone", strPhone),
            new SqlParameter("@Ext", strExt),
            new SqlParameter("@DeleteFlag", strDeleteFlag),
            new SqlParameter("@QuitJobFlag", strQuitJobFlag),
            new SqlParameter("@IDNumber", strIDNumber),
            new SqlParameter("@Gender", strGender),
            new SqlParameter("@TitleNo", strTitleNo),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@YoyoCard", strYoyoCard),
            new SqlParameter("@Service_year", strServiceyear)
        };

        return Execute(strSQL, sp);
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
        string strSQL =
           "INSERT INTO EMP_NONMEMBER " +
           "(ID_CARD " +
           ",AD_ID " +
           ",USER_NAME " +
           ",EMAIL " +
           ",NONEMPLOYEE_TYPE " +
            //           ",BOSS_LEVEL_ID " +
           ",ACT_DATE " +
            //           ",FIRST_GOV_DATE " +
           ",LEFT_DATE " +
            //           ",LIVE_PHONE " +
           ",PHONE " +
           ",EXT " +
            //           ",DELETE_FLAG " +
            //           ",QUIT_JOB_FLAG " +
           ",CHANGE_USERID " +
           ",ID_NUMBER " +
           ",GENDER " +
           ",CHANGE_DATE "+
           ", Yoyo_card "+
           ", Service_year " +
        ") " +
     "VALUES " +
           "(@IdCard " +//<ID_CARD, VARCHAR(20),>
           ",@AdId " +//<AD_ID, VARCHAR(20),>
           ",@UserName " +   //<USER_NAME, NVARCHAR(50),>
           ",@Email " +   // <EMAIL, NVARCHAR(50),>
           ",@EmployeeType " +   // <EMPLOYEE_TYPE, VARCHAR(2),>
            //           ",@BossLevelID " + // <BOSS_LEVEL_ID, VARCHAR(2),>
           ",@ActDate ";//<ACT_DATE, DATETIME,>
//           ",@FirstGovDate " +// <FIRST_GOV_DATE, DATETIME,>
        if (strLeftDate!="")
        {
            strSQL +=
           ",@LeftDate ";//<LEFT_DATE, DATETIME,>
        }
            else{
                strSQL +=
                    " ,null ";
        }
        strSQL+=
//           ",@LivePhone " +//<LIVE_PHONE, VARCHAR(20),>
           ",@Phone " +//<PHONE, VARCHAR(20),>
           ",@Ext " +//<EXT, VARCHAR(10),>
//           ",@DeleteFlag " + // <DELETE_FLAG, VARCHAR(1),>
//           ",@QuitJobFlag " + // <QUIT_JOB_FLAG, VARCHAR(1),>
           ",@ChangeUserID " +//<CHANGE_USERID, VARCHAR(10),>
           ",@IDNumber " +//<CHANGE_USERID, VARCHAR(10),>
           ",@Gender "+
           ",getDate() "+
           ",@YoyoCard "+
           ",@Service_year " +
        ") "; //<CHANGE_DATE, DATETIME,>

        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@AdId", strAdId),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@EmployeeType", strNonEmployeeType),
//            new SqlParameter("@BossLevelID", strBossLevelID),
            new SqlParameter("@ActDate", strActDate),
//            new SqlParameter("@FirstGovDate", strFirstGovDate),
            new SqlParameter("@LeftDate", strLeftDate),
//            new SqlParameter("@LivePhone", strLivePhone),
            new SqlParameter("@Phone", strPhone),
            new SqlParameter("@Ext", strExt),
//            new SqlParameter("@DeleteFlag", strDeleteFlag),
//            new SqlParameter("@QuitJobFlag", strQuitJobFlag),
            new SqlParameter("@IDNumber", strIDNumber),
            new SqlParameter("@Gender", strGender),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@YoyoCard", strYoyoCard),
            new SqlParameter("@Service_year", strServiceyear)
        };

        return Execute(strSQL, sp);
    }


    // 新增資料
    // FSC_Personnel
    public int insertFscPersonnel(
            string strIdCard,
            string strTitleNo,
            string strUserName,
            string strEmployeeType,
            string strDegree_code,
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
            ,string strIdNumber    // 身份證
            , string strPESEX      // 性別
            ,string BirthDate      // 生日
            , string strBoss_level_id
            , string strEmail
            , string strAdId
            , string strMutiDepartDeputy_flag
            , string strServiceyear
        )
    {
        string strSQL =
            "INSERT INTO FSC_PERSONNEL " +
           "(ID_CARD " +
           ",TITLE_NO " +
           ",USER_NAME " +
           ",EMPLOYEE_TYPE " +
           ",Degree_code " +
           ",LEVEL " +
           ",ACT_DATE " +
           ",FISRT_GOV_DATE " +
           ",LEFT_DATE " +
           ",LEAVE_YR_ADD " +
           ",LEAVE_YR_BDATE " +
           ",SHIFT_TYPE " +
           ",PEHYEAR " +
           ",PEHDAY " +
           ",PEHDAY2 " +
           ",PEHDAY3 " +
           ",PEKIND " +
//           ",PEOVERHFEE " +
//           ",PEOVERDATE " +
//           ",PEOLDFEE " +
           ",PEPOINT " +
           ",PEPROFESS " +
           ",PECHIEF " +
           ",PEYKIND " +
//           ",PERDAY " +
           ",PERDAY1 " +
           ",PERDAY2 " +
//           ",PEALIMT " +
//           ",PEBLIMT " +
//           ",PEPAYDAYA " +
//           ",PEPAYDAYB " +
//           ",PEPAYHDAY " +
//           ",PERDAYK " +
           ",ROLE_ID " +
//           ",LOGIN_STATUS " +
//           ",MESSAGE_YN " +
//           ",EMAIL_YN " +
//           ",SEND_TIME1 " +
//           ",SEND_TIME2 " +
//           ",SEND_TIME3 " +
//           ",SEND_TIME4 " +
//           ",SEND_TIME5 " +
//           ",SEND_TIME6 " +
           ",LOGIN_TYPE "+
           ",CHANGE_USERID " +
           ",On_Duty "+
           ",Syslogin_flag "+
           ",ID_NUMBER "+
           ",PESEX " +
           ",BIRTH_DATE " +
           ",Boss_level_id " +
           ",Email " +
           ",AD_id " +
           ",MutiDepartDeputy_flag " +
           ",Service_year " +
           ",CHANGE_DATE) " +
     "VALUES " +
           "(@IdCard " +    //<ID_CARD, VARCHAR(10),>
           ",@TitleNo " + // <TITLE_NO, VARCHAR(4),>
           ",@UserName " +           // <USER_NAME, VARCHAR(50),>
           ",@EmployeeType " +   // <EMPLOYEE_TYPE, VARCHAR(2),>
           ",@Degree_code " +   // <Degree_code, VARCHAR(3),>
           ",@Level " +   // <LEVEL, VARCHAR(2),>
           ",@ActDate " +   // <ACT_DATE, VARCHAR(7),>
           ",@FirstGovDate " +   // <FISRT_GOV_DATE, VARCHAR(7),>
           ",@LeftDate " +   // <LEFT_DATE, VARCHAR(7),>
           ",@LeaveYrAdd " +   // <LEAVE_YR_ADD, INT,>
           ",@LeaveYrBDate " +   // <LEAVE_YR_BDATE, VARCHAR(7),>
           ",@ShiftType " +//<SHIFT_TYPE, VARCHAR(1),>
           ",@PehYear " +   // <PEHYEAR, VARCHAR(2),>
           ",@PehDay " +   // <PEHDAY, REAL,>
           ",@PehDay2 " +
           ",@PehDay3 " +
           ",@PeKind " +   // <PEKIND, VARCHAR(1),>
//           ",<PEOVERHFEE, INT,> " +
//           ",<PEOVERDATE, VARCHAR(7),> " +
//           ",<PEOLDFEE, INT,> " +
           ",@PrPoint " +   // <PEPOINT, VARCHAR(4),>
           ",@PeProfess " +   // <PEPROFESS, INT,>
           ",@PrChidf " +   // <PECHIEF, INT,>
           ",@PeyKind " +   // <PEYKIND, VARCHAR(1),>
//           ",<PERDAY, FLOAT,> " +
           ",@Perday1 " +   // <PERDAY1, FLOAT,>
           ",@Perday2 " +   // <PERDAY2, FLOAT,>
//           ",<PEALIMT, FLOAT,> " +
//           ",<PEBLIMT, FLOAT,> " +
//           ",<PEPAYDAYA, FLOAT,> " +
//           ",<PEPAYDAYB, FLOAT,> " +
//           ",<PEPAYHDAY, INT,> " +
//           ",<PERDAYK, VARCHAR(2),> " +
           ",@RoleID " +    // <ROLE_ID, VARCHAR(32),>
//           ",<LOGIN_STATUS, INT,> " +
//           ",<MESSAGE_YN, VARCHAR(1),> " +
//           ",<EMAIL_YN, VARCHAR(1),> " +
//           ",<SEND_TIME1, VARCHAR(4),> " +
//           ",<SEND_TIME2, VARCHAR(4),> " +
//           ",<SEND_TIME3, VARCHAR(4),> " +
//           ",<SEND_TIME4, VARCHAR(4),> " +
//           ",<SEND_TIME5, VARCHAR(4),> " +
//           ",<SEND_TIME6, VARCHAR(4),> " +
           ",@LoginType "+
           ",@ChangeUserID " +   // <CHANGE_USERID, VARCHAR(10),>
           ",@OnDuty " +
           ",@Sysloginflag " +
           ",@IdNumber " +
           ",@PESEX " +
           ",@BirthDate " +
           ",@Boss_level_id " +
           ",@Email " +
           ",@AD_id " +
           ",@MutiDepartDeputy_flag " +
           ",@Service_year " +
           ",getDate()) ";   // <CHANGE_DATE, DATETIME,>

        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@TitleNo", strTitleNo),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@EmployeeType", strEmployeeType),
            new SqlParameter("@Degree_code", strDegree_code),
            new SqlParameter("@Level", (strDegree_code == "001" ? "0" : CommonFun.getInt(strDegree_code.Substring(1)).ToString())),
            new SqlParameter("@ActDate", strActDate),
            new SqlParameter("@FirstGovDate", strFirstGovDate),
            new SqlParameter("@LeftDate", strLeftDate),
            new SqlParameter("@LeaveYrAdd", strLeaveYrAdd),
            new SqlParameter("@LeaveYrBDate", strLeaveYrBDate),
            new SqlParameter("@ShiftType", strShiftType),
            new SqlParameter("@PehYear", strPehYear),
            new SqlParameter("@PehDay", strPehDay),
            new SqlParameter("@PehDay2", strPehDay2),
            new SqlParameter("@PehDay3", strPehDay3),
            new SqlParameter("@PeKind", strPeKind),
            new SqlParameter("@PrPoint", strPrPoint),
            new SqlParameter("@PeProfess", strProfess),
            new SqlParameter("@PrChidf", strChidf),
            new SqlParameter("@PeyKind", strKind),
            new SqlParameter("@Perday1", strPerday1),
            new SqlParameter("@Perday2", strPerday2),
            new SqlParameter("@RoleID", strRoleID),
            new SqlParameter("@LoginType", strLoginType),
            new SqlParameter("@OnDuty", strOnDuty),
            new SqlParameter("@Sysloginflag", strSyslogin),
            new SqlParameter("@IdNumber", strIdNumber),
            new SqlParameter("@PESEX", strPESEX),
            new SqlParameter("@BirthDate", BirthDate),
            new SqlParameter("@Boss_level_id", strBoss_level_id),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@AD_id", strAdId),
            new SqlParameter("@MutiDepartDeputy_flag", strMutiDepartDeputy_flag),
            new SqlParameter("@Service_year", strServiceyear),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };

        return Execute(strSQL, sp);
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
        string strSQL =
            "INSERT INTO EMP_DEPART_EMP " +
            "           (ORGCODE " +
            "           ,DEPART_ID " +
            "           ,ID_CARD " +
            "           ,SERVICE_SDATE " +
            "           ,SERVICE_EDATE " +
            "           ,SERVICE_TYPE " +
            "           ,CHANGE_USERID " +
            "           ,CHANGE_DATE) " +
            "     VALUES " +
            "           ( @OrgCode " + // <ORGCODE, VARCHAR(10),>
            "           , @DepartId " +    // <DEPART_ID, VARCHAR(6),>
            "           , @IDCard " +    // <ID_CARD, VARCHAR(20),>
            "           , @ServiceSDate ";    // <SERVICE_SDATE, DATETIME,>
        if (strServiceType.Trim() == "")
        {
            strSQL +=
                 "           , null ";
        }
        else
        {
            strSQL +=
                "           , @ServiceEDate ";
        }
        strSQL+=    
            "           , @ServiceType " +    // <SERVICE_TYPE, VARCHAR(2),>
            "           , @ChangeUserID " +    // <CHANGE_USERID, VARCHAR(10),>
            "           , getDate()) ";   // <CHANGE_DATE, DATETIME,>
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartId", strDepartId),
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ServiceSDate", strServiceSDate),
            new SqlParameter("@ServiceEDate", strServiceEDate),
            new SqlParameter("@ServiceType", strServiceType),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };
        return Execute(strSQL, sp);
    }

    // 新增 FSC_PERSONNEL_BOSS
    // 主管
    public int insertFscPersonnelBoss(
        string strOrgCode,
        string strDepartID,
        string strIDCard,
        string strServiceType,
        string strBossOrgCode,
        string strBossDepartID,
        string strBossPosID,
        string strBossIDCard,
        string strBossSType,
        string strChangeUserID
        )
    {
        string strSQL =
            "INSERT INTO FSC_PERSONNEL_BOSS " +
            "           (ORGCODE " +
            "           ,DEPART_ID " +
            "           ,ID_CARD " +
            "           ,SERVICE_TYPE " +
            "           ,BOSS_ORGCODE " +
            "           ,BOSS_DEPARTID " +
            "           ,BOSS_POSID " +
            "           ,BOSS_IDCARD " +
            "           ,BOSS_STYPE " +
            "           ,CHANGE_USERID " +
            "           ,CHANGE_DATE) " +
            "     VALUES " +
            "           ( @OrgCode " +   // <ORGCODE, VARCHAR(10),>
            "           , @DepartID " +   // <DEPART_ID, VARCHAR(10),>
            "           , @IDCard " +   // <ID_CARD, VARCHAR(10),>
            "           , @ServiceType " +   // <SERVICE_TYPE, VARCHAR(1),>
            "           , @BossOrgCode " +   // <BOSS_ORGCODE, VARCHAR(10),>
            "           , @BossDepartID" +   // <BOSS_DEPARTID, VARCHAR(10),>
            "           , @BossPosID " +   // <BOSS_POSID, VARCHAR(10),>
            "           , @BossIDCard " +   // <BOSS_IDCARD, VARCHAR(10),>
            "           , @BossSType " +   // <BOSS_STYPE, VARCHAR(1),>
            "           , @ChangeUserID " +   // <CHANGE_USERID, VARCHAR(10),>
            "           , getDate()) ";   // <CHANGE_DATE, DATETIME,>
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ServiceType", strServiceType),
            new SqlParameter("@BossOrgCode", strBossOrgCode),
            new SqlParameter("@BossDepartID", strBossDepartID),
            new SqlParameter("@BossPosID", strBossPosID),
            new SqlParameter("@BossIDCard", strBossIDCard),
            new SqlParameter("@BossSType", strBossSType),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };
        return Execute(strSQL, sp);

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
        string strSQL =
            "INSERT INTO EMP_STAFFINTRO_MAIN " +
            "           (BIRTH_DATE " +
            "           ,INTRO_DESC " +
            "           ,SKILL_DESC " +
            "           ,SPECIALTY_DESC " +
            "           ,MOOD_DESC " +
            "           ,PICFILE_PATH " +
            "           ,CHANGE_USERID " +
            "           ,CHANGE_DATE " +
            "           ,ID_CARD) " +
            "     VALUES " +
            "           ( ";
        if (strBirthDate!="")
        {
            strSQL +=
           "@BirthDate ";// <BIRTH_DATE, DATETIME,>
        }
            else{
                strSQL +=
                    " null ";
        }
            //"   @BirthDate " +   // <BIRTH_DATE, DATETIME,>
        strSQL+=
            "           , @IntroDesc " +   // <INTRO_DESC, NVARCHAR(600),>
            "           , @SkillDesc " +   // <SKILL_DESC, NVARCHAR(300),>
            "           , @SpecialtyDesc " +   // <SPECIALTY_DESC, NVARCHAR(300),>
            "           , @MoodDesc " + // <MOOD_DESC, NVARCHAR(600),>
            "           , @PicfilePath " + //<PICFILE_PATH, VARCHAR(300),>
            "           , @ChangeUserID" + // <CHANGE_USERID, VARCHAR(10),>
            "           , getDate() " + // <CHANGE_DATE, DATETIME,>
            "           , @IDCard) ";   // <ID_CARD, VARCHAR(6),>
        SqlParameter[] sp =
        {
            new SqlParameter("@BirthDate", strBirthDate),
            new SqlParameter("@IntroDesc", strIntroDesc),
            new SqlParameter("@SkillDesc", strSkillDesc),
            new SqlParameter("@SpecialtyDesc", strSpecialtyDesc),
            new SqlParameter("@MoodDesc", strMoodDesc),
            new SqlParameter("@PicfilePath", strPicfilePath),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@IDCard", strIDCard)
        };
        return Execute(strSQL, sp);

    }



    // 取得職務類別
    public DataTable querySysLeaveKind(
        string strOrgCode
        )
    {
        string strSQL =
            "SELECT ORGCODE " +
                  ",LEAVE_KIND " +
                  ",KIND_NAME " +
//                  ",METADB_ID " +
                  ",CHANGE_USERID " +
                  ",CHANGE_DATE " +
                  ",ID " +
              "FROM SYS_LEAVE_KIND ";
        strSQL +=
            "WHERE ORGCODE=@OrgCode ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode)
        };
        return Query(strSQL,sp);

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
        string strCondition = "";
        if (strOrgCode != "")
        {
            strCondition +=
                "AND B.ORGCODE= @OrgCode ";
        }

        if (strDepartID != "" && strDepartID != "ALL")
        {
            strCondition +=
                "AND (B.DEPART_ID= @DepartID or B.DEPART_ID in (select DEPART_ID from FSC_Org where Parent_depart_id=@DepartID )) ";
            strCondition +=
                "AND A.ID_CARD IN (SELECT ID_CARD FROM EMP_DEPART_EMP WHERE DEPART_ID=@DepartID or DEPART_ID in (select DEPART_ID from FSC_Org where Parent_depart_id=@DepartID )) ";
        }
        else
        {

        }
//            strCondition +=
//                "AND B.SERVICE_TYPE='0' ";  // 先只抓取佔缺單位
       


        if (strUserName != "")
        {
            strCondition +=
                "AND A.USER_NAME LIKE '%" + strUserName + "%'  ";
        }
        if (strEmployeeType != "" && strEmployeeType != "ALL")
        {
            strCondition +=
                "AND A.EMPLOYEE_TYPE IN (" + strEmployeeType + ")  ";
        }
        if (strIDCard != "")
        {
            strCondition +=
                "AND A.ID_CARD=@IDCard ";
        }
        if (strIDCard2 != "")
        {
            strCondition +=
            "AND A.ID_CARD= @IDCard2 ";
        }
        if (strQuitJob != "")
        {
            if (strQuitJob == "N")
            {
                strCondition +=
                    "AND (A.LEFT_DATE IS NULL OR A.LEFT_DATE='' OR  A.LEFT_DATE > '" + CommonFun.getYYYMMDD() + "' ) ";
            }
            else
            {
               
                strCondition +=
                    "AND (A.LEFT_DATE IS NOT NULL AND A.LEFT_DATE<>'' AND A.LEFT_DATE <= '" + CommonFun.getYYYMMDD() + "'  )";
            }
        }


        if (strTitleNo != "" && strTitleNo != "ALL")
        {
            strCondition +=
                "AND A.TITLE_NO = @TitleNo ";
        }

        

//        strCondition +=
//            "AND D.Service_type='0' ";


        // E.Agent_idcard,
        string strSQL =
            "(SELECT DISTINCT " +
            "B.ORGCODE,B.DEPART_ID,A.USER_NAME,A.TITLE_NO,A.ID_CARD,A.AD_ID,A.EMPLOYEE_TYPE,C.ROLE_ID,C.PEHYEAR,C.PEHDAY,C.PEHDAY2,C.PEHDAY3" +
            ",D.BOSS_IDCARD,C.BOSS_LEVEL_ID,C.ROLE_ID,A.Email,C.MutiDepartDeputy_flag,C.Service_year " +
            ",A.Live_Phone,A.Ext,C.Shift_type,A.GENDER,C.Birth_date,C.PEKIND,C.Leave_yr_add " +
            ",C.YoyoCard_Change_flag,C.Depart_Change_flag,C.PERDAY1,C.PERDAY2 " +
            ",C.PEPOINT,C.PEPROFESS,C.PECHIEF,C.PEYKIND,C.LOGIN_TYPE " +

            ",A.ID_NUMBER,c.ACT_DATE,c.Fisrt_gov_date,c.Left_date,c.Leave_yr_bdate,C.Degree_code,A.Yoyo_card,C.Syslogin_flag,C.On_Duty,B.Service_type, C.Init_flag " +
            "FROM EMP_MEMBER A, " +
            "(SELECT * FROM ( " +
            "SELECT RANK() OVER (PARTITION BY ID_CARD ORDER BY SERVICE_TYPE, SERVICE_SDATE) SRANK  ,* FROM  " +
            "EMP_DEPART_EMP  " +
            ") TMP " +
            "WHERE SRANK=1 ) B, " +
            "FSC_PERSONNEL C, "+
            "(SELECT * FROM ( "+
                        "SELECT RANK() OVER (PARTITION BY ID_CARD ORDER BY SERVICE_TYPE) SRANK  ,* FROM   "+
                        "fsc_personnel_boss )  tmp2 " +
                        "where srank=1) D, "+
            "EMP_AGENT E,EMP_StaffIntro_main F " +
            "WHERE A.ID_CARD*=B.ID_CARD " +
            //            "AND B.Service_type='0' " +
            "AND A.ID_CARD*=C.ID_CARD " +
            "AND A.ID_CARD*=E.ID_CARD " +
            "AND A.ID_CARD*=F.ID_CARD " +
            "AND (A.DELETE_FLAG<>'Y' OR A.DELETE_FLAG IS NULL) " +
            "AND A.ID_CARD*=D.ID_CARD ";
        strSQL +=
            strCondition+" ) ";



        //E.Agent_idcard,
        strSQL +=
            "UNION " +
            "( SELECT DISTINCT B1.ORGCODE,B1.DEPART_ID,A1.USER_NAME,C1.TITLE_NO AS TITLE_NO,A1.ID_CARD,A1.AD_ID, "+
            "A1.NONEMPLOYEE_TYPE AS EMPLOYEE_TYPE,C1.ROLE_ID,C1.PEHYEAR,C1.PEHDAY2, "+
            "C1.PEHDAY3, C1.PEHDAY,D1.BOSS_IDCARD,C1.BOSS_LEVEL_ID,C1.ROLE_ID,A1.Email ,C1.MutiDepartDeputy_flag,C1.Service_year, '' AS Live_Phone,A1.Ext, " +
            "C1.Shift_type,A1.Gender, C1.Birth_date,C1.PEKIND,C1.Leave_yr_add , "+
            "C1.YoyoCard_Change_flag,C1.Depart_Change_flag,C1.PERDAY1,C1.PERDAY2 , " +
            "C1.PEPOINT,C1.PEPROFESS,C1.PECHIEF,C1.PEYKIND,C1.LOGIN_TYPE, "+
            "A1.ID_NUMBER,C1.ACT_DATE, "+
            "C1.Fisrt_gov_date,C1.Left_date,c1.Leave_yr_bdate , "+

            "C1.Degree_code,A1.Yoyo_card,C1.Syslogin_flag,C1.On_Duty,B1.Service_type,  "+
            "C1.Init_flag  " +
            "FROM EMP_NONMEMBER A1, " +
            "(SELECT * FROM ( " +
            "SELECT RANK() OVER (PARTITION BY ID_CARD ORDER BY SERVICE_TYPE, SERVICE_SDATE) SRANK  ,* FROM  " +
            "EMP_DEPART_EMP  " +
            ") TMP " +
            "WHERE SRANK=1 ) B1, " +
            "FSC_PERSONNEL C1, "+
            "(SELECT * FROM ( " +
                        "SELECT RANK() OVER (PARTITION BY ID_CARD ORDER BY SERVICE_TYPE) SRANK  ,* FROM   " +
                        "fsc_personnel_boss )  tmp2 " +
                        "where srank=1) D1, " + 
                        "EMP_AGENT E1,EMP_StaffIntro_main F1 " +
            "WHERE A1.ID_CARD*=B1.ID_CARD " +
            //            "AND B.Service_type='0' " +

            "AND A1.ID_CARD=C1.ID_CARD AND A1.ID_CARD*=E1.ID_CARD AND A1.ID_CARD*=F1.ID_CARD AND A1.ID_CARD*=D1.ID_CARD ";
        strSQL +=
            strCondition.Replace("A.EMPLOYEE_TYPE", "C1.EMPLOYEE_TYPE").Replace("A.TITLE_NO", "C1.TITLE_NO")
            .Replace("A.","A1.").Replace("B.","B1.").Replace("C.","C1.").Replace("D.","D1.").Replace("E.","E1.").Replace("F.","F1.")
            +" ) ";// NONMEMBER 沒 TITLE_NO

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@IDCard2", strIDCard2),
            new SqlParameter("@TitleNo", strTitleNo)
        };
        return Query(strSQL, sp);

    }





    public DataTable getEmpDepartEmp(
        string strOrgCode,
        string strIDCard,
        string strDepartID,
        string strServiceType
        )
    {
        string strSQL =
            "SELECT ID " +
            ",ORGCODE " +
            ",DEPART_ID " +
            ",ID_CARD " +
            ",SERVICE_SDATE " +
            ",SERVICE_EDATE " +
            ",SERVICE_TYPE " +
            ",CHANGE_USERID " +
            ",CHANGE_DATE " +
            "FROM EMP_DEPART_EMP "+
            "WHERE ORGCODE=@OrgCode ";
        if (strIDCard != "")
        {
            strSQL +=
                "AND ID_CARD = @IDCard ";
        }
        if (strDepartID != "")
        {
            strSQL +=
                "AND DEPART_ID = @DepartID ";
        }
        if (strServiceType != "")
        {
            strSQL+=
                "AND SERVICE_TYPE IN (" + strServiceType + ") ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@DepartID", strDepartID)
        };
        return Query(strSQL, sp);
    }

    public string getRoleName(
        string strOrgCode,
        string strRoleID
        )
    {
        string strReturnValue = "";
        DataTable dt =
            getSysRole(strOrgCode, "", strRoleID, "", "", "");
        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["ROLE_NAME"].ToString();
        }
        return strReturnValue;
        
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
        string strSQL =
            "SELECT ID " +
            "      ,ORGCODE " +
            "      ,DEPART_ID " +
            "      ,ROLE_ID " +
            "      ,ROLE_NAME " +
            "      ,MANAGER_FLAG " +
            "      ,ROLE_STATUS " +
            "      ,DELETE_FLAG " +
            "      ,CHANGE_USERID " +
            "      ,CHANGE_DATE " +
            "  FROM SYS_ROLE " +
            "WHERE ORGCODE=@OrgCode ";
        if (strDepartID != "" && strDepartID != "ALL")
        {
            strSQL +=
                "AND DEPART_ID=@DepartID ";
        }
        if (strRoleID != "" && strRoleID != "ALL")
        {
            strSQL +=
                "AND ROLE_ID=@RoleID ";
        }
        if (strManagerFlag != "" && strManagerFlag != "ALL")
        {
            strSQL +=
                "AND MANAGER_FLAG=@ManagerFlag ";
        }
        if (strRoleStatus != "" && strRoleStatus != "ALL")
        {
            strSQL +=
                "AND ROLE_STATUS=@RoleStatus ";
        }
        if (strDeleteFlag != "" && strDeleteFlag != "ALL")
        {
            strSQL +=
                "AND DELETE_FLAG=@DeleteFlag ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@RoleID", strRoleID),
            new SqlParameter("@ManagerFlag", strManagerFlag),
            new SqlParameter("@RoleStatus", strRoleStatus),
            new SqlParameter("@DeleteFlag", strDeleteFlag)
        };
        return Query(strSQL, sp);
    }

    public DataTable queryEmpStaffIntroMain(
        string strIdCard
        )
  
    {
        String strSQL =
            "SELECT ID " +
            //            "      ,PERSONNEL_ID " +
            "      ,BIRTH_DATE " +
            "      ,INTRO_DESC " +
            "      ,SKILL_DESC " +
            "      ,SPECIALTY_DESC " +
            "      ,MOOD_DESC " +
            "      ,PICFILE_PATH " +
            "      ,CHANGE_USERID " +
            "      ,CHANGE_DATE " +
            "      ,ID_CARD " +
            "FROM EMP_STAFFINTRO_MAIN " +
            "WHERE ID_CARD=@IdCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
        };
        return Query(strSQL, sp);

    }

    public int insertFscPersonalBoss(
        string strOrgCode ,
        string strDepartID ,
        string strIDCard ,
        string strServiceType ,
        string strBoosOrgCode ,
        string strBossDepartID ,
        string strBossPosID ,
        string strBossIDCard ,
        string strBossSType ,
        string strChangeUserID
        )
    {
        string strSQL =
            "INSERT INTO FSC_PERSONNEL_BOSS " +
            "           (ORGCODE " +
            "           ,DEPART_ID " +
            "           ,ID_CARD " +
            "           ,SERVICE_TYPE " +
            "           ,BOSS_ORGCODE " +
            "           ,BOSS_DEPARTID " +
            "           ,BOSS_POSID " +
            "           ,BOSS_IDCARD " +
            "           ,BOSS_STYPE " +
            "           ,CHANGE_USERID " +
            "           ,CHANGE_DATE) " +
            "     VALUES " +
            "           ( @OrgCode " +   // <ORGCODE, VARCHAR(10),>
            "           , @DepartID " +   // <DEPART_ID, VARCHAR(10),>
            "           , @IDCard " +   // <ID_CARD, VARCHAR(10),>
            "           , @ServiceType " +   // <SERVICE_TYPE, VARCHAR(1),>
            "           , @BoosOrgCode " +   // <BOSS_ORGCODE, VARCHAR(10),>
            "           , @BossDepartID " +   // <BOSS_DEPARTID, VARCHAR(10),>
            "           , @BossPosID " +   // <BOSS_POSID, VARCHAR(10),>
            "           , @BossIDCard " +   // <BOSS_IDCARD, VARCHAR(10),>
            "           , @BossSType " +   // <BOSS_STYPE, VARCHAR(1),>
            "           , @ChangeUserID " +   // <CHANGE_USERID, VARCHAR(10),>
            "           , getDate() ) ";   // <CHANGE_DATE, DATETIME,>

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ServiceType", strServiceType),
            new SqlParameter("@BoosOrgCode", strBoosOrgCode),
            new SqlParameter("@BossDepartID", strBossDepartID),
            new SqlParameter("@BossPosID", strBossPosID),
            new SqlParameter("@BossIDCard", strBossIDCard),
            new SqlParameter("@BossSType", strBossSType),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };
        return Execute(strSQL, sp);
    }

    // 取得最大序號之員工代碼
    public string getMaxIdCard(string strEmployeeType)
    {
        string strSQL="";
        string strReturnValue = "";
        if (strEmployeeType == "13" || strEmployeeType == "14" || strEmployeeType == "15")
        {
            strReturnValue = "0000";
            strSQL =
                "SELECT ISNULL(MAX(SUBSTRING(ID_CARD,2,4)),'0000')MID FROM EMP_NONMEMBER " +
                "WHERE ISNUMERIC(SUBSTRING(ID_CARD,2,4))=1 " +
                "AND SUBSTRING(ID_CARD,1,1)='Z' ";
        }
        else
        {
            strReturnValue = "04999";
            strSQL =
                "SELECT ISNULL(MAX(SUBSTRING(ID_CARD,1,5)),'04999')MID FROM EMP_MEMBER " +
                "WHERE ID_CARD NOT IN('888888','999999') " +
                //"AND ISNUMERIC(SUBSTRING(ID_CARD,1,5))=1 "+
                "AND SUBSTRING(ID_CARD,1,5)>='05000' " +
                "AND SUBSTRING(ID_CARD,1,1)<>'Z' " +
                "AND len(id_card) = 6 and id_card not like '@%' ";
        }

        SqlParameter[] sp =
        {

        };
        DataTable dt= Query(strSQL, sp);

        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["MID"].ToString();
        }
        return strReturnValue;
    }

    public DataTable getFscPersonalBoss(
        string strOrgCode ,
        string strDepartID ,
        string strIDCard 
        )
    {
        string strSQL =
            "SELECT ID,ORGCODE,DEPART_ID,ID_CARD,SERVICE_TYPE, " +
            "BOSS_ORGCODE,BOSS_DEPARTID,BOSS_POSID,BOSS_IDCARD,BOSS_STYPE,CHANGE_USERID,CHANGE_DATE " +
            "FROM FSC_PERSONNEL_BOSS  " +
            "WHERE ORGCODE=@OrgCode " +
            "AND DEPART_ID=@DepartID " +
            "AND ID_CARD=@IDCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IDCard", strIDCard)
        };
        return Query(strSQL, sp);

               
    }

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
        string strSQL=
            "UPDATE EMP_MEMBER "+
            "   SET ID_CARD = @IdCard " +   // <ID_CARD, VARCHAR(20),>
            "      ,AD_ID = @AdId " + // <AD_ID, VARCHAR(20),>
            "      ,USER_NAME = @UserName " + //<USER_NAME, NVARCHAR(50),> 
            "      ,EMAIL = @Email " + // <EMAIL, NVARCHAR(50),>
            "      ,EMPLOYEE_TYPE = @EmployeeType " + // <EMPLOYEE_TYPE, VARCHAR(2),> 
            "      ,BOSS_LEVEL_ID = @BossLevelID " + // <BOSS_LEVEL_ID, VARCHAR(2),>
            "      ,ACT_DATE = @ActDate " +  // <ACT_DATE, DATETIME,>
            "      ,FIRST_GOV_DATE = @FirstGovDate " +    // <FIRST_GOV_DATE, DATETIME,>
            "      ,LEFT_DATE = @LeftDate " + // <LEFT_DATE, DATETIME,>
            "      ,LIVE_PHONE = @LivePhone  " +    // <LIVE_PHONE, VARCHAR(20),>
            "      ,PHONE = @Phone " + // <PHONE, VARCHAR(20),>
            "      ,EXT = @Ext " +   // <EXT, VARCHAR(10),>
            "      ,DELETE_FLAG = @DeleteFlag " +   // <DELETE_FLAG, VARCHAR(1),>
            "      ,QUIT_JOB_FLAG = @QuitJobFlag " + // <QUIT_JOB_FLAG, VARCHAR(1),>
            "      ,CHANGE_USERID = @ChangeUserID " + // <CHANGE_USERID, VARCHAR(10),>
            "      ,CHANGE_DATE = getdate() " +   // <CHANGE_DATE, DATETIME,>
            "      ,TITLE_NO = @TitleNo " +  // <TITLE_NO, VARCHAR(4),>
            "      ,GENDER = @Gender " +    // <GENDER, VARCHAR(1),>
            "      ,ID_NUMBER = @IDNumber " +    // <ID_NUMBER, VARCHAR(10),>
            "      ,Yoyo_card = @YoyoCard " +    // <ID_NUMBER, VARCHAR(10),>
            "      ,Service_year = @Service_year " +
            " WHERE ID_CARD = @IdCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@AdId", strAdId),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@EmployeeType", strEmployeeType),
            new SqlParameter("@BossLevelID", strBossLevelID),
            new SqlParameter("@ActDate", strActDate),
            new SqlParameter("@FirstGovDate", strFirstGovDate),
            new SqlParameter("@LeftDate", strLeftDate),
            new SqlParameter("@LivePhone", strLivePhone),
            new SqlParameter("@Phone", strPhone),
            new SqlParameter("@Ext", strExt),
            new SqlParameter("@DeleteFlag", strDeleteFlag),
            new SqlParameter("@QuitJobFlag", strQuitJobFlag),
            new SqlParameter("@IDNumber", strIDNumber),
            new SqlParameter("@Gender", strGender),
            new SqlParameter("@TitleNo", strTitleNo),
            new SqlParameter("@ChangeUserID", strChangeUserID)
            ,new SqlParameter("@YoyoCard", strYoyoCard),
            new SqlParameter("@Service_year", strServiceyear)
        };

        return Execute(strSQL, sp);
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
        string strSQL=
            "UPDATE EMP_NONMEMBER "+
            "   SET ID_CARD = @IdCard " + //<ID_CARD, VARCHAR(20),>
            "      ,AD_ID = @AdId " + // <AD_ID, VARCHAR(20),>
            "      ,USER_NAME = @UserName " + // <USER_NAME, NVARCHAR(50),>
            "      ,EMAIL = @Email " + //<EMAIL, NVARCHAR(50),>
            "      ,NONEMPLOYEE_TYPE = @EmployeeType " +  // <NONEMPLOYEE_TYPE, VARCHAR(3),>
            "      ,GENDER = @Gender " +    // <GENDER, VARCHAR(1),>
            "      ,ACT_DATE = @ActDate " +  // <ACT_DATE, DATETIME,>
            "      ,LEFT_DATE = @LeftDate " + // <LEFT_DATE, DATETIME,>
            "      ,PHONE = @Phone " + // <PHONE, VARCHAR(20),>
            "      ,EXT = @Ext " +   // <EXT, VARCHAR(10),>
            "      ,CHANGE_USERID = @ChangeUserID " + // <CHANGE_USERID, VARCHAR(10),>
            "      ,CHANGE_DATE = getDate() "+
            "      ,ID_NUMBER = @IDNumber " + // <ID_NUMBER, VARCHAR(10),>
            "      ,Yoyo_Card = @YoyoCard " + // <ID_NUMBER, VARCHAR(10),>
            "      ,Service_year = @Service_year " +
            " WHERE ID_CARD=@IdCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@AdId", strAdId),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@EmployeeType", strNonEmployeeType),
            new SqlParameter("@ActDate", strActDate),
            new SqlParameter("@LeftDate", strLeftDate),
            new SqlParameter("@Phone", strPhone),
            new SqlParameter("@Ext", strExt),
            new SqlParameter("@IDNumber", strIDNumber),
            new SqlParameter("@Gender", strGender),
            new SqlParameter("@ChangeUserID", strChangeUserID)
           , new SqlParameter("@YoyoCard", strYoyoCard),
           new SqlParameter("@Service_year", strServiceyear)
        };

        return Execute(strSQL, sp);
    }


    public bool isFscPersonnelExists(
    string strIdCard
    )
    {
        bool bRetuen = false;
        string strSQL =
            "SELECT COUNT(*) AS CNT FROM FSC_PERSONNEL " +
            "WHERE ID_CARD=@IDCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard)
        };
        DataTable dt = Query(strSQL, sp);

        if ( Convert.ToInt32(dt.Rows[0]["CNT"].ToString())>0)
        {
            bRetuen = true;
        }
        

        return bRetuen;
    }

    public int UpdateFscPersonnel(
                    string strIdCard,
            string strTitleNo,
            string strUserName,
            string strEmployeeType,
            string strDegree_code,
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
            , string strPESEX      // 性別
            , string BirthDate      // 生日
            , string strBoss_level_id
            , string strEmail
            , string strAdId
            , string strMutiDepartDeputy_flag
            , string strServiceyear
            , string strYoyoCard_Change_flag
        )
    {
        string strSQL =
            "UPDATE FSC_PERSONNEL " +
            "   SET ID_CARD = @IdCard " + //<ID_CARD, VARCHAR(10),>
            "      ,TITLE_NO = @TitleNo " + //<TITLE_NO, VARCHAR(4),>
            "      ,USER_NAME = @UserName " + //<USER_NAME, VARCHAR(50),>
            "      ,EMPLOYEE_TYPE = @EmployeeType " +// <EMPLOYEE_TYPE, VARCHAR(2),>
//            "      ,ON_DUTY =  " +   // <ON_DUTY, VARCHAR(1),>
            "      ,Degree_code=@Degree_code " +
            "      ,LEVEL = @Level " + // <LEVEL, VARCHAR(2),>
            "      ,ACT_DATE = @ActDate " +  // <ACT_DATE, VARCHAR(7),>
            "      ,FISRT_GOV_DATE = @FirstGovDate " + //<FISRT_GOV_DATE, VARCHAR(7),>
            "      ,LEFT_DATE = @LeftDate " + //<LEFT_DATE, VARCHAR(7),>
            "      ,LEAVE_YR_ADD = @LeaveYrAdd " + //<LEAVE_YR_ADD, INT,>
            "      ,LEAVE_YR_BDATE = @LeaveYrBDate " +//<LEAVE_YR_BDATE, VARCHAR(7),>
            "      ,SHIFT_TYPE = @ShiftType  " +//<SHIFT_TYPE, VARCHAR(3),>
//            "      ,PESEX =  " +//<PESEX, VARCHAR(1),>
            "      ,PEHYEAR = @PehYear " +//<PEHYEAR, VARCHAR(2),>
            "      ,PEHDAY = @PehDay " +//<PEHDAY, REAL,>
            "      ,PEHDAY2 = @PehDay2 " +
            "      ,PEHDAY3 = @PehDay3 " +
            "      ,PEKIND = @PeKind " +//<PEKIND, VARCHAR(1),>
//            "      ,PEOVERHFEE =  " +//<PEOVERHFEE, INT,>
//            "      ,PEOVERDATE =  " +//<PEOVERDATE, VARCHAR(7),>
//            "      ,PEOLDFEE =  " +//<PEOLDFEE, INT,>
            "      ,PEPOINT = @PrPoint " +//<PEPOINT, VARCHAR(4),>
            "      ,PEPROFESS = @PeProfess " +//<PEPROFESS, INT,>
            "      ,PECHIEF = @PrChidf " +//<PECHIEF, INT,>
            "      ,PEYKIND = @PeyKind " +//<PEYKIND, VARCHAR(1),>
//            "      ,PERDAY =  " +//<PERDAY, FLOAT,>
            "      ,PERDAY1 = @Perday1 " +//<PERDAY1, FLOAT,>
            "      ,PERDAY2 = @Perday2 " +//<PERDAY2, FLOAT,>
//            "      ,PEALIMT =  " +//<PEALIMT, FLOAT,>
//            "      ,PEBLIMT =  " +//<PEBLIMT, FLOAT,>
//            "      ,PEPAYDAYA =  " +//<PEPAYDAYA, FLOAT,>
//            "      ,PEPAYDAYB =  " +//<PEPAYDAYB, FLOAT,>
//            "      ,PEPAYHDAY =  " +//<PEPAYHDAY, INT,>
//            "      ,PERDAYK =  " +//<PERDAYK, VARCHAR(2),>
            "      ,ROLE_ID = @RoleID " +//<ROLE_ID, VARCHAR(32),>
//            "      ,LOGIN_STATUS =  " +//<LOGIN_STATUS, INT,>
//            "      ,MESSAGE_YN = " +//<MESSAGE_YN, VARCHAR(1),> 
//            "      ,EMAIL_YN =  " +//<EMAIL_YN, VARCHAR(1),>
//            "      ,SEND_TIME1 =  " +//<SEND_TIME1, VARCHAR(4),>
//            "      ,SEND_TIME2 =  " +//<SEND_TIME2, VARCHAR(4),>
//            "      ,SEND_TIME3 =  " +//<SEND_TIME3, VARCHAR(4),>
//            "      ,SEND_TIME4 =  " +//<SEND_TIME4, VARCHAR(4),>
//            "      ,SEND_TIME5 =  " +//<SEND_TIME5, VARCHAR(4),>
//            "      ,SEND_TIME6 =  " +//<SEND_TIME6, VARCHAR(4),>
//            "      ,QUIT_JOB_FLAG =  " +//<QUIT_JOB_FLAG, VARCHAR(1),>
            "      ,CHANGE_USERID = @ChangeUserID " +//<CHANGE_USERID, VARCHAR(10),>
            "      ,CHANGE_DATE = getDate() " +
            "      ,LOGIN_TYPE = @LoginType " +//<LOGIN_TYPE, VARCHAR(1),>
           ",On_Duty = @OnDuty" +
           ",Syslogin_flag= @SysLoginFlag" +
           ",id_number=@IdNumber " +
           ",PESEX=@PESEX " +
           ",Birth_date=@BirthDate " +
           ",Boss_level_id=@Boss_level_id"+
           ",Email=@Email" +
           ",AD_id=@AD_id" +
           ",MutiDepartDeputy_flag=@MutiDepartDeputy_flag" +
           ",Service_year=@Service_year" +
           ",YoyoCard_Change_flag=@YoyoCard_Change_flag" +

            " WHERE ID_CARD= @IdCard ";

        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@TitleNo", strTitleNo),
            new SqlParameter("@UserName", strUserName),
            new SqlParameter("@EmployeeType", strEmployeeType),
            new SqlParameter("@Degree_code", strDegree_code),
            new SqlParameter("@Level", (strDegree_code == "001" ? "0" : CommonFun.getInt(strDegree_code.Substring(1)).ToString())),
            new SqlParameter("@ActDate", strActDate),
            new SqlParameter("@FirstGovDate", strFirstGovDate),
            new SqlParameter("@LeftDate", strLeftDate),
            new SqlParameter("@LeaveYrAdd", strLeaveYrAdd),
            new SqlParameter("@LeaveYrBDate", strLeaveYrBDate),
            new SqlParameter("@ShiftType", strShiftType),
            new SqlParameter("@PehYear", strPehYear),
            new SqlParameter("@PehDay", strPehDay),
            new SqlParameter("@PehDay2", strPehDay2),
            new SqlParameter("@PehDay3", strPehDay3),
            new SqlParameter("@PeKind", strPeKind),
            new SqlParameter("@PrPoint", strPrPoint),
            new SqlParameter("@PeProfess", strProfess),
            new SqlParameter("@PrChidf", strChidf),
            new SqlParameter("@PeyKind", strKind),
            new SqlParameter("@Perday1", strPerday1),
            new SqlParameter("@Perday2", strPerday2),
            new SqlParameter("@RoleID", strRoleID),
            new SqlParameter("@LoginType", strLoginType),
            new SqlParameter("@OnDuty", strOnDuty),
            new SqlParameter("@Sysloginflag", strSyslogin),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@IdNumber", strIdNumber),
            new SqlParameter("@BirthDate", BirthDate),
            new SqlParameter("@PESEX", strPESEX),
            new SqlParameter("@Boss_level_id", strBoss_level_id),
            new SqlParameter("@Email", strEmail),
            new SqlParameter("@AD_id", strAdId),
            new SqlParameter("@MutiDepartDeputy_flag", strMutiDepartDeputy_flag),
            new SqlParameter("@Service_year", strServiceyear),
            new SqlParameter("@YoyoCard_Change_flag", strYoyoCard_Change_flag)
        };

        return Execute(strSQL, sp);
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
        string strSQL =
            "UPDATE EMP_STAFFINTRO_MAIN " +
            "   SET "+
 //       "PERSONNEL_ID = @IDCard " +//<PERSONNEL_ID, VARCHAR(10),>
//            "      ,"+
            "BIRTH_DATE = @BirthDate " + //<BIRTH_DATE, DATETIME,>
            "      ,INTRO_DESC = @IntroDesc " +//<INTRO_DESC, NVARCHAR(600),>
            "      ,SKILL_DESC = @SkillDesc " +//<SKILL_DESC, NVARCHAR(300),>
            "      ,SPECIALTY_DESC = @SpecialtyDesc " +//<SPECIALTY_DESC, NVARCHAR(300),>
            "      ,MOOD_DESC = @MoodDesc " +//<MOOD_DESC, NVARCHAR(600),>
            "      ,PICFILE_PATH = @PicfilePath " +//<PICFILE_PATH, VARCHAR(300),>
            "      ,CHANGE_USERID = @ChangeUserID " +//<CHANGE_USERID, VARCHAR(10),>
            "      ,CHANGE_DATE = getDate() " +
            "      ,ID_CARD = @IDCard " +   //<ID_CARD, VARCHAR(6),>
            " WHERE ID_CARD=@IDCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@BirthDate", strBirthDate),
            new SqlParameter("@IntroDesc", strIntroDesc),
            new SqlParameter("@SkillDesc", strSkillDesc),
            new SqlParameter("@SpecialtyDesc", strSpecialtyDesc),
            new SqlParameter("@MoodDesc", strMoodDesc),
            new SqlParameter("@PicfilePath", strPicfilePath),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@IDCard", strIDCard)
        };
        return Execute(strSQL, sp);
    }

    public int deleteEmpDepartEmp(
        string strOrgCode,
        string strIdCard,
        string strDepartID,
        string strServicesType,
        string strServicesDate
        )
    {
        string strSQL =
            "DELETE FROM EMP_DEPART_EMP " +
            "WHERE ID_CARD= @IdCard ";
        if (strOrgCode != "" && strOrgCode != "ALL")
        {
            strSQL +=
            "AND ORGCODE=@OrgCode ";
        }
        if (strDepartID != "" && strDepartID != "ALL")
        {
            strSQL +=
            "AND DEPART_ID=@DepartID " ;
        }
        if (strServicesType != "" && strServicesType != "ALL")
        {
            strSQL +=
            "AND SERVICES_TYPE=@ServicesType ";
        }
        if (strServicesDate != "" && strServicesDate != "ALL")
        {
            strSQL +=
            "AND SERVICES_DATE=@ServicesDate ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ServicesType", strServicesType),
            new SqlParameter("@ServicesDate", strServicesDate)
        };
        return Execute(strSQL, sp);
    }


    public int deleteFSCPERSONNELBOSS(
        string strIdCard,   
        string strOrgCode,
        string strDepartID
        )
    {
        string strSQL =
            "DELETE FROM FSC_PERSONNEL_BOSS " +
            "WHERE ID_CARD = @IDCard ";
        if (strOrgCode != "" && strOrgCode != "ALL")
        {
            strSQL +=
                "AND ORGCODE = @OrgCode ";
        }
        if (strDepartID != "" && strDepartID != "ALL")
        {
            strSQL +=
                "AND DEPART_ID = @DepartID ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard),
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
        };
        return Execute(strSQL, sp);
    }

    public void deleteEMPMemberNonMember(string strIdCard)
    {
        string strSQL =
            "UPDATE EMP_MEMBER SET DELETE_FLAG='Y' " +
            "WHERE ID_CARD=@IDCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIdCard)
        };
        Execute(strSQL, sp);
        
        strSQL =
            "DELETE EMP_NONMEMBER " +
            "WHERE ID_CARD=@IDCard ";
        SqlParameter[] sp2 =
        {
            new SqlParameter("@IdCard", strIdCard)
        };
        Execute(strSQL, sp2);
    }


    public bool isUserExists(
        string strIdNumber
        )
    {
        string strSQL =
            "SELECT COUNT(*) AS CNT FROM ( " +
            "SELECT ID_NUMBER FROM EMP_MEMBER " +
            "UNION  " +
            "SELECT ID_NUMBER FROM EMP_NONMEMBER " +
            ")MEMBER  " +
            "WHERE ID_NUMBER = @IdNumber ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdNumber", strIdNumber)
        };
        DataTable dt = Query(strSQL, sp);

        if (Convert.ToInt32(dt.Rows[0]["CNT"].ToString())>0)
        {
            return true;
        }
        return false;
    }

    public bool isUserExists2(
    string strIdNumber
    )
    {
        string strSQL =
            "SELECT COUNT(*) AS CNT FROM ( " +
            "SELECT ID_NUMBER FROM EMP_MEMBER  where ISNULL( Left_date,'')<>'' and Left_date <='" + CommonFun.getYYYMMDD() + "' " +
            "UNION  " +
            "SELECT ID_NUMBER FROM EMP_NONMEMBER  where ISNULL( Left_date,'')<>'' and Left_date <='" + CommonFun.getYYYMMDD() + "' " +
            ")MEMBER  " +
            "WHERE ID_NUMBER = @IdNumber ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdNumber", strIdNumber)
        };
        DataTable dt = Query(strSQL, sp);

        if (Convert.ToInt32(dt.Rows[0]["CNT"].ToString()) > 0)
        {
            return false;//////已離職
        }
        return true;//////在職
    }

    public bool isADExists(
            string strADId
            )
    {
        string strSQL =
            "SELECT COUNT(*) AS CNT FROM ( " +
            "SELECT AD_Id FROM EMP_MEMBER " +
            "UNION  " +
            "SELECT AD_Id FROM EMP_NONMEMBER " +
            ")MEMBER  " +
            "WHERE AD_Id = @AD_Id ";
        SqlParameter[] sp =
        {
            new SqlParameter("@AD_Id", strADId)
        };
        DataTable dt = Query(strSQL, sp);

        if (Convert.ToInt32(dt.Rows[0]["CNT"].ToString()) > 0)
        {
            return true;
        }
        return false;
    }


    public bool isyoyoExists(
            string stryoyo
            )
    {
        string strSQL =
            "SELECT COUNT(*) AS CNT FROM ( " +
            "SELECT Yoyo_card FROM EMP_MEMBER " +
            "UNION  " +
            "SELECT Yoyo_card FROM EMP_NONMEMBER " +
            ")MEMBER  " +
            "WHERE Yoyo_card = @Yoyo_card ";
        SqlParameter[] sp =
        {
            new SqlParameter("@Yoyo_card", stryoyo)
        };
        DataTable dt = Query(strSQL, sp);

        if (Convert.ToInt32(dt.Rows[0]["CNT"].ToString()) > 0)
        {
            return true;
        }
        return false;
    }

    public int InsertSalSaBase(
        string strBaseSeqNO,
        string strIdNO,
        string strStatus,
        string strOrgID,
        string strNeme,
        string strSex,
        string strDep,
        string strBDate,
        string strEDate,
        string strBTP
        )
    {
        string strSQL =
            "INSERT INTO SAL_SABASE " +
            "           (BASE_SEQNO " +
            "           ,BASE_IDNO " +
            "           ,BASE_STATUS " +
            "           ,BASE_ORGID " +
            "           ,BASE_NAME " +
            "           ,BASE_SEX " +
            "           ,BASE_DEP " +
            "           ,BASE_BDATE " +
            "           ,BASE_EDATE " +
            "           ,BASE_PTB ) " +
            "     VALUES " +
            "( " +
            "           @BaseSeqNO " +
            "           ,@BaseIdNO " +
            "           ,@BaseStatus " +
            "           ,@BaseOrgID " +
            "           ,@BaseNeme " +
            "           ,@BaseSex " +
            "           ,@BaseDep " +
            "           ,@BaseBDate " +
            "           ,@BaseEDate " +
            "           ,@BaseBTP " +
            ") ";
        SqlParameter[] sp =
        {
            new SqlParameter("@BaseSeqNO", strBaseSeqNO),
            new SqlParameter("@BaseIdNO", strIdNO),
            new SqlParameter("@BaseStatus", strStatus),
            new SqlParameter("@BaseOrgID", strOrgID),
            new SqlParameter("@BaseNeme", strNeme),
            new SqlParameter("@BaseSex", strSex),
            new SqlParameter("@BaseDep", strDep),
            new SqlParameter("@BaseBDate", strBDate),
            new SqlParameter("@BaseEDate", strEDate),
            new SqlParameter("@BaseBTP", strBTP),
        };
        return Execute(strSQL, sp);

    }

    public int UpdateSalSaBase(
        string strBaseSeqNO,
        string strIdNO,
        string strStatus,
        string strOrgID,
        string strNeme,
        string strSex,
        string strDep,
        string strBDate,
        string strEDate,
        string strBTP
        )
    {
        string strSQL =
            "UPDATE SAL_SABASE " +
            "           SET BASE_SEQNO=@BaseSeqNO ";
        if (strIdNO != "")
        {
            strSQL +=
           "           ,BASE_IDNO=@BaseIdNO ";
        }
 
        if (strStatus != "")
        {
            strSQL +=
               "           ,BASE_STATUS=@BaseStatus ";
        }
        if (strOrgID != "")
        {
            strSQL +=
        "           ,BASE_ORGID=@BaseOrgID ";
        }
        if (strNeme != "")
        {
            strSQL +=
        "           ,BASE_NAME=@BaseNeme ";
        }
        if (strSex != "")
        {
            strSQL +=
        "           ,BASE_SEX=@BaseSex ";
        }
        if (strSex != "")
        {
            strSQL +=
        "           ,BASE_DEP=@BaseDep ";
        }
        if (strSex != "")
        {
            strSQL +=
        "           ,BASE_BDATE=@BaseBDate ";
        }
        if (strSex != "")
        {
            strSQL +=
        "           ,BASE_EDATE=@BaseEDate ";
        }
        if (strSex != "")
        {
            strSQL +=
        "           ,BASE_PTB=@BaseBTP ";
        }

        strSQL +=
        " WHERE BASE_SEQNO=@BaseSeqNO ";
        SqlParameter[] sp =
        {
            new SqlParameter("@BaseSeqNO", strBaseSeqNO),
            new SqlParameter("@BaseIdNO", strIdNO),
            new SqlParameter("@BaseStatus", strStatus),
            new SqlParameter("@BaseOrgID", strOrgID),
            new SqlParameter("@BaseNeme", strNeme),
            new SqlParameter("@BaseSex", strSex),
            new SqlParameter("@BaseDep", strDep),
            new SqlParameter("@BaseBDate", strBDate),
            new SqlParameter("@BaseEDate", strEDate),
            new SqlParameter("@BaseBTP", strBTP),
        };
        return Execute(strSQL, sp);

    }


    public bool SalSaBaseExists(        
        string strBaseSeqNO)
    {
        string strSQL=
            "SELECT * FROM SAL_SABASE "+
            " WHERE BASE_SEQNO=@BaseIdNO ";
        SqlParameter[] sp =
        {
            new SqlParameter("@BaseIdNO", strBaseSeqNO)
        };
        DataTable dt= Query(strSQL, sp);

        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public string getParentDeptNameByDepartID
    (
    //string strOrgCode,
    string strDepartID
    )
    {
        string strReturnValue = "";

        // 取得父單位代號
        string strSQL =
            "SELECT PARENT_DEPART_ID FROM FSC_ORG " +
            "WHERE DEPART_ID= @OrgCode ";
        SqlParameter[] sp =
            {
                new SqlParameter("@OrgCode", strDepartID),
            };
        DataTable dt = Query(strSQL, sp);
        string strParentDepartID = "";
        if (dt.Rows.Count > 0)
        {
            strParentDepartID = dt.Rows[0]["PARENT_DEPART_ID"].ToString();
        }

        if (string.IsNullOrEmpty(strParentDepartID))
        {
            strParentDepartID = strDepartID;
        }

        strSQL =
            "SELECT DEPART_NAME FROM FSC_ORG " +
            "WHERE DEPART_ID= @OrgCode ";
        SqlParameter[] sp2 =
            {
                new SqlParameter("@OrgCode", strParentDepartID)
            };

        dt = Query(strSQL, sp2);
        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["DEPART_NAME"].ToString();
        }
        return strReturnValue;

    }

}