using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// EmpMemberDAO 的摘要描述
/// </summary>
public class EmpMemberDAO : BaseDAO
{
	public EmpMemberDAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public EmpMemberDAO(SqlConnection conn)
        : base(conn)
    {

    }

    
    public DataTable queryEmpMember(
        string strADID, // AD_ID
        string strDeptID,    // DeptID
        string strBirthday  // 生日
        )
    {
        string strCondition="";
        if (strADID!="")
        {
            strCondition+=
                "AND EMP_MEMBER.AD_id= @AdID ";
        }

        if (strDeptID != "")
        {
            strCondition +=
                "AND EMP_MEMBER.id_card in (" +
                "SELECT id_card FROM EMP_Depart_EMP " +
                "WHERE Depart_id like @DeptID+'%') ";
        }

        if (strBirthday != "")
        {
            strCondition +=
                "AND EMP_MEMBER.id_card in (" +
                "SELECT id_card FROM EMP_STAFFINTRO_MAIN " +
                "WHERE Birth_date like '%'+@BirthDay) ";
        }

        string strSQL =
            "SELECT EMP_MEMBER.ID_CARD,AD_ID,USER_NAME,EMAIL,EMPLOYEE_TYPE, " +
            "BOSS_LEVEL_ID,ACT_DATE,LEFT_DATE,LIVE_PHONE,PHONE,EXT,DELETE_FLAG,QUIT_JOB_FLAG,EMP_ORG.DEPART_ID,EMP_ORG.DEPART_NAME,EMP_ORG.Orgcode,EMP_ORG.Orgcode_name,First_gov_date " +
            ",'' AS GENDER,Birth_date,Service_sdate,Service_edate,Service_type " +
            "FROM EMP_MEMBER,EMP_STAFFINTRO_MAIN,EMP_DEPART_EMP,EMP_ORG " +
            "WHERE EMP_MEMBER.ID_CARD*=EMP_STAFFINTRO_MAIN.ID_CARD " +
            "AND EMP_MEMBER.ID_CARD *=EMP_DEPART_EMP.ID_CARD " +
            "AND EMP_ORG.ORGCODE=EMP_DEPART_EMP.ORGCODE " +
            "AND EMP_ORG.DEPART_ID=EMP_DEPART_EMP.DEPART_ID " +
            strCondition +
            "UNION " +
            "SELECT EMP_NONMEMBER.ID_CARD,AD_ID,USER_NAME,EMAIL,NONEMPLOYEE_TYPE AS EMPLOYEE_TYPE, " +
            "'' AS BOSS_LEVEL_ID,ACT_DATE,LEFT_DATE,'' AS LIVE_PHONE,PHONE,EXT,'' AS DELETE_FLAG,'' AS QUIT_JOB_FLAG,EMP_ORG.DEPART_ID,EMP_ORG.DEPART_NAME,EMP_ORG.Orgcode,EMP_ORG.Orgcode_name,ACT_DATE as First_gov_date " +
            ",GENDER,Birth_date,Service_sdate,Service_edate,Service_type " +
            "FROM EMP_NONMEMBER,EMP_STAFFINTRO_MAIN,EMP_DEPART_EMP,EMP_ORG " +
            "WHERE EMP_NONMEMBER.ID_CARD*=EMP_STAFFINTRO_MAIN.ID_CARD " +
            "AND EMP_NONMEMBER.ID_CARD *=EMP_DEPART_EMP.ID_CARD " +
            "AND EMP_ORG.ORGCODE=EMP_DEPART_EMP.ORGCODE " +
            "AND EMP_ORG.DEPART_ID=EMP_DEPART_EMP.DEPART_ID " +
            strCondition.Replace("EMP_MEMBER.id_card", "EMP_NONMEMBER.id_card").Replace("EMP_MEMBER.AD_id", "EMP_NONMEMBER.AD_id");

        SqlParameter[] sp =
        {
            new SqlParameter("@AdID",strADID),
            new SqlParameter("@DeptID",strDeptID),
            new SqlParameter("@BirthDay",strBirthday)
        };
        return Query(strSQL, sp);
    }


    // 查詢代理人
    public DataTable queryAgent(
        string strADID,
        string strDeptID
    )
    {

        string strCondition = "";
        if (strADID != "")
        {
            strCondition +=
                "AND B.AD_id= @AdID ";
        }

        if (strDeptID != "")
        {
            strCondition +=
                "AND B.id_card in (" +
                "SELECT id_card FROM EMP_Depart_EMP " +
                "WHERE Depart_id= @DeptID) ";
        }

        string strSQL =
            "SELECT A.AGENT_IDCARD,B.AD_ID,B.USER_NAME AS AGENT_USERNAME , " +
            "B.QUIT_JOB_FLAG AS AGENT_QUIT_JOB_FLAG,B.BOSS_LEVEL_ID AS AGENT_BOSS_LEVEL_ID, " +
            "A.AGENT_ORGCODE,C.DEPART_NAME AS AGENT_DEPARTNAME, " +
            "A.ID_CARD,D.AD_ID,D.USER_NAME, AGENT_SDATE+AGENT_STIME AS STARTDATE, AGENT_EDATE+AGENT_ETIME AS ENDDATE " +
            "FROM EMP_AGENT A, EMP_MEMBER B , EMP_ORG C , EMP_MEMBER D " +
            "WHERE A.AGENT_IDCARD=B.ID_CARD " +
            "AND A.AGENT_ORGCODE=C.DEPART_ID " +
            "AND A.ID_CARD= D.ID_CARD ";
        strSQL +=
            strCondition;

        SqlParameter[] sp =
        {
            new SqlParameter("@AdID",strADID),
            new SqlParameter("@DeptID",strDeptID)
        };
        return Query(strSQL, sp);
    }
    


    // 查詢行動裝置註冊檔
    public DataTable queryEmpMobiDevReg(
        string strADID,
        string strDeptID
        )

    {
        string strSQL =
            "SELECT * FROM EMP_Mobidev_reg " +
            "WHERE 1=1 ";
        if (strADID!="")
        {
            strSQL+=
                "AND AD_id= @AdID ";
        }

        if (strDeptID != "")
        {
            strSQL +=
                "AND id_card in (" +
                "SELECT id_card FROM EMP_Depart_EMP " +
                "WHERE Depart_id= @DeptID) ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@AdID",strADID),
            new SqlParameter("@DeptID",strDeptID)
        };
        return Query(strSQL, sp);
    }

    // 查詢組織架構檔
    public DataTable queryEmpOrg()
    {
        string strSQL =
            "SELECT * FROM EMP_ORG ";
        SqlParameter[] sp =
        {
          
        };
        return Query(strSQL, sp);
    }


    // 查詢記錄
    public void addQueryRecord(
        string strQueryIP,
        string strWsType,
        string strQueryCount,
        string strNoteDesc,
        string strChangeUserID
        )
    {
        string strSQL =
            "INSERT INTO EMP_APQUERY_LOG " +
            "( QUERY_IP,WS_TYPE,QUERY_COUNT,QUERY_DATE,NOTE_DESC,CHANGE_USERID,CHANGE_DATE " + ") " +
            "VALUES " +
            "( @QueryIP, @WsType ,@QueryCount , getdate() , @NoteDesc , @ChangeUserID, getDate() ) ";
        SqlParameter[] sp =
        {
            new SqlParameter("@QueryIP",strQueryIP),
            new SqlParameter("@WsType", strWsType),
            new SqlParameter("@QueryCount", strQueryCount),
            new SqlParameter("@NoteDesc", strNoteDesc),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };
        Execute(strSQL, sp);


    }

    public DataTable queryEmpOrg(
        string strADID,
        string strDeptID
        )
    {
        string strCondition="";
        if (strDeptID!="")
        {
            strCondition+=
                "and Depart_id like @DeptID+'%' ";
        }

       if (strADID!="")
       {
           strCondition+=
               "and Depart_id in "+
            "(  "+
            "select Depart_id from EMP_Depart_EMP "+
            "where Id_card in "+
            "(select Id_card from EMP_Member where AD_id=@AdID "+
            "union  "+
            "select Id_card from EMP_nonMember where AD_id like @AdID+'%') "+
            ") ";
       }

        string strSQL =
            "select * from EMP_ORG "+
            "where 1=1 "+
            strCondition;

        SqlParameter[] sp =
        {
            new SqlParameter("@AdID",strADID),
            new SqlParameter("@DeptID",strDeptID)
        };
        return Query(strSQL, sp);
    }

    // 是否可使用WS
    public bool canUserWS(
        string strAPIP,
        string strWsType,
        string strSystemCode
        )
    {
        string strSQL =
            "SELECT SYSTEM_CODE FROM EMP_Wsregisted_prof " +
            "WHERE AP_IP= @APIP " +
            "AND WS_TYPE= @WsType " +
            "AND SYSTEM_CODE = @SystemCode " +
            "AND Is_disable='0' ";
        SqlParameter[] sp =
        {
            new SqlParameter("@APIP",strAPIP),
            new SqlParameter("@WsType",strWsType),
            new SqlParameter("@SystemCode",strSystemCode)
        };
        DataTable dt = Query(strSQL, sp);

        if (dt != null && dt.Rows.Count == 1 && dt.Rows[0]["SYSTEM_CODE"].ToString() == strSystemCode)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    // 
    public DataTable querySystemCanUse(
        string strADID,
        string strDeptID
        )
    {
        string strCondition = "";
        if (strADID != "")
        {
            strCondition +=
                "AND A.AD_id= @AdID ";
        }

        if (strDeptID != "")
        {
            strCondition +=
                "AND A.id_card in (" +
                "SELECT id_card FROM EMP_Depart_EMP " +
                "WHERE Depart_id= @DeptID) ";
        }
        string strSQL =
            "SELECT A.ID_CARD,A.AD_ID,A.USER_NAME,A.EMPLOYEE_TYPE,A.QUIT_JOB_FLAG " +
            ",D.ORGCODE_NAME,D.DEPART_NAME,E.SYSTEM_CODE,E.SYSTEM_NAME,E.WEB_URL " +
            "FROM EMP_ESHARE_SYS_PROF B,EMP_MEMBER A,EMP_DEPART_EMP C,FSC_ORG D,EMP_APPLICA_SYS_PROF E " +
            "WHERE A.ID_CARD=B.ID_CARD " +
            "AND A.ID_CARD=C.ID_CARD " +
            "AND B.ORGCODE=C.ORGCODE " +
            "AND B.DEPART_ID=C.DEPART_ID " +
            "AND C.ORGCODE=D.ORGCODE " +
            "AND C.DEPART_ID=D.DEPART_ID " +
            "AND B.SYSTEM_CODE=E.SYSTEM_CODE " +
            "AND B.ORGCODE=E.ORGCODE " +
            strCondition +
            "UNION " +
            "SELECT A.ID_CARD,A.AD_ID,A.USER_NAME,A.EMPLOYEE_TYPE,A.QUIT_JOB_FLAG " +
            ",D.ORGCODE_NAME,D.DEPART_NAME,E.SYSTEM_CODE,E.SYSTEM_NAME,E.WEB_URL " +
            "FROM EMP_ISHARE_SYS_PROF B,EMP_MEMBER A,EMP_DEPART_EMP C,FSC_ORG D,EMP_APPLICA_SYS_PROF E " +
            "WHERE  " +
            "A.ID_CARD=C.ID_CARD " +
            "AND B.ORGCODE=C.ORGCODE " +
            "AND B.DEPART_ID=C.DEPART_ID " +
            "AND C.ORGCODE=D.ORGCODE " +
            "AND C.DEPART_ID=D.DEPART_ID " +
            "AND B.SYSTEM_CODE=E.SYSTEM_CODE " +
            "AND B.ORGCODE=E.ORGCODE " +
            "AND A.ID_CARD NOT IN (SELECT ID_CARD FROM EMP_ESHARE_SYS_PROF) " +
            strCondition +
            "UNION " +
            "SELECT A.ID_CARD,A.AD_ID,A.USER_NAME,A.NONEMPLOYEE_TYPE,'' AS QUIT_JOB_FLAG " +
            ",D.ORGCODE_NAME,D.DEPART_NAME,E.SYSTEM_CODE,E.SYSTEM_NAME,E.WEB_URL " +
            "FROM EMP_ESHARE_SYS_PROF B,EMP_NONMEMBER A,EMP_DEPART_EMP C,FSC_ORG D,EMP_APPLICA_SYS_PROF E " +
            "WHERE A.ID_CARD=B.ID_CARD " +
            "AND A.ID_CARD=C.ID_CARD " +
            "AND B.ORGCODE=C.ORGCODE " +
            "AND B.DEPART_ID=C.DEPART_ID " +
            "AND C.ORGCODE=D.ORGCODE " +
            "AND C.DEPART_ID=D.DEPART_ID " +
            "AND B.SYSTEM_CODE=E.SYSTEM_CODE " +
            "AND B.ORGCODE=E.ORGCODE " +
            strCondition +
            "UNION " +
            "SELECT A.ID_CARD,A.AD_ID,A.USER_NAME,A.NONEMPLOYEE_TYPE,'' AS QUIT_JOB_FLAG " +
            ",D.ORGCODE_NAME,D.DEPART_NAME,E.SYSTEM_CODE,E.SYSTEM_NAME,E.WEB_URL " +
            "FROM EMP_ISHARE_SYS_PROF B,EMP_NONMEMBER A,EMP_DEPART_EMP C,FSC_ORG D,EMP_APPLICA_SYS_PROF E " +
            "WHERE  " +
            "A.ID_CARD=C.ID_CARD " +
            "AND B.ORGCODE=C.ORGCODE " +
            "AND B.DEPART_ID=C.DEPART_ID " +
            "AND C.ORGCODE=D.ORGCODE " +
            "AND C.DEPART_ID=D.DEPART_ID " +
            "AND B.SYSTEM_CODE=E.SYSTEM_CODE " +
            "AND B.ORGCODE=E.ORGCODE " +
            "AND A.ID_CARD NOT IN (SELECT ID_CARD FROM EMP_ESHARE_SYS_PROF) " +
            strCondition;
        SqlParameter[] sp =
        {
            new SqlParameter("@AdID",strADID),
            new SqlParameter("@DeptID",strDeptID)
        };
        return Query(strSQL, sp);
    }
       

}