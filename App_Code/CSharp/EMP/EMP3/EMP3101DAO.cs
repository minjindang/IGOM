using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// EMP3101 的摘要描述
/// 應用程式設定作業
/// </summary>
public class EMP3101DAO : BaseDAO
{
    public EMP3101DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    public EMP3101DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable get1stDeptList()
    {
        return get1stDeptList("");
    }

    public DataTable get1stDeptList(string strOrgCode)
    {
        string strSQL =
           "SELECT DISTINCT ORGCODE,ORGCODE_NAME FROM EMP_ORG ";
        if (strOrgCode != "")
        {
            strSQL +=
                "WHERE ORGCODE= @OrgCode ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode)
        };
        return Query(strSQL, sp);
    }


    public DataTable queryEMPApplicaSysProf
        (
        string strORGCode,
        string strSystemCode,
        string strIsActiveFlag
        )
    {
        string strSQL =
            "SELECT ID,ORGCODE,SYSTEM_CODE " +
            ",SYSTEM_NAME " +
            ",SERVER_IP " +
            ",WEB_URL " +
            ",IS_ACTIVE_FLAG " +
            ",NOTE_DESC " +
            ",CHANGE_USERID " +
            ",CHANGE_DATE"+
            // 20140410 改 AP_NAME
            ",AP_NAME " +
            "FROM EMP_APPLICA_SYS_PROF ";
        strSQL+=
            "WHERE ORGCODE= @OrgCode ";
        if (strSystemCode != "")
        {
            strSQL +=
                "AND SYSTEM_CODE = @SystemCode ";
        }
        if (strIsActiveFlag != "")
        {
            strSQL +=
                "AND IS_ACTIVE_FLAG IN (" + strIsActiveFlag + ") ";
        }


        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strORGCode),
            new SqlParameter("@SystemCode", strSystemCode)
        };
        return Query(strSQL, sp);

    }

    // 新增資料
    public void insertEMPApplicaSysProf(
        string strOrgCode,  // 機關代碼
        string strSystemCode,   // 應用系統代碼
        string strSystemName,   // 應用系統名稱
        string strServerIP,  // 伺服器位址
        string strWebURL,   // 應用系統網址
        string strisActiveFlag, // 是否啟用
        string strNoteDesc, // 備註說明
        string strChangeUserID, // 異動人員
        string strAPIdCard  // 應用系統負責人
        )
    {
        string strSQL =
            "INSERT INTO EMP_APPLICA_SYS_PROF " +
                       "(ORGCODE " +
                       ",SYSTEM_CODE " +
                      " ,SYSTEM_NAME " +
                       ",SERVER_IP " +
                       ",WEB_URL " +
                       ",IS_ACTIVE_FLAG " +
                       ",NOTE_DESC " +
                       ",CHANGE_USERID " +
                       ",CHANGE_DATE " +
//                       ",AP_IDCARD) " +
                       ",AP_NAME) " +
                 "VALUES (" +
                       "@OrgCode " +
                       ",@SystemCode " +
                       ",@SystemName " +
                       ",@ServerIP " +
                      " ,@WebURL " +
                       ",@isActiveFlag " +
                       ",@NoteDesc " +
                       ",@ChangeUserID " +
                       ",REPLACE(CONVERT(NVARCHAR, GETDATE(), 23), '-', '') " +
                       ",@APIdCard) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@SystemCode", strSystemCode),
            new SqlParameter("@SystemName", strSystemName),
            new SqlParameter("@ServerIP", strServerIP),
            new SqlParameter("@WebURL", strWebURL),
            new SqlParameter("@isActiveFlag", strisActiveFlag),
            new SqlParameter("@NoteDesc", strNoteDesc),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@APIdCard", strAPIdCard)
        };

        Execute(strSQL, sp);
    }

    public void editEMPApplicaSysProf(
        string strSystemName,   // 應用系統名稱
        string strServerIP,  // 伺服器位址
        string strWebURL,   // 應用系統網址
        string strisActiveFlag, // 是否啟用
        string strNoteDesc, // 備註說明
        string strChangeUserID, // 異動人員
        string strAPIdCard,  // 應用系統負責人
        string strID
    )
    {
        string strSQL =
            "UPDATE EMP_APPLICA_SYS_PROF " +
            "SET SYSTEM_NAME= @SystemName " +
            ",SERVER_IP=  @ServerIP " +
            ",WEB_URL= @WebURL " +
            ",IS_ACTIVE_FLAG= @isActiveFlag " +
            ",NOTE_DESC= @NoteDesc " +
            ",AP_NAME=@AP_NAME "+
            ",CHANGE_USERID= @ChangeUserID " +
            ",CHANGE_DATE=REPLACE(CONVERT(NVARCHAR, GETDATE(), 23), '-', '') "+
            "WHERE ID= @ID ";

        SqlParameter[] sp =
        {
            new SqlParameter("@SystemName", strSystemName),
            new SqlParameter("@ServerIP", strServerIP),
            new SqlParameter("@WebURL", strWebURL),
            new SqlParameter("@isActiveFlag", strisActiveFlag),
            new SqlParameter("@NoteDesc", strNoteDesc),
            new SqlParameter("@ChangeUserID", strChangeUserID),
            new SqlParameter("@AP_NAME", strAPIdCard),
            new SqlParameter("@ID", strID)
        };

        Execute(strSQL, sp);
    }

    public void DeleteEMPApplicaSysProf(string OrgCode,
            string AP_idcard,
            string ID
        )
    {
        string strSQL = " DELETE FROM EMP_APPLICA_SYS_PROF "
                   + " WHERE OrgCode = @OrgCode"
//                   + "  AND AP_idcard = @AP_idcard"
                   + "  AND ID = @ID";
        

        SqlParameter[] sp =
        {    
            new SqlParameter("@OrgCode", OrgCode),
            new SqlParameter("@AP_idcard", AP_idcard),
            new SqlParameter("@ID", ID)
        };

        Execute(strSQL, sp);
    }


    public bool isSystemCodeUsed(
        string OrgCode,
        string strSystemCode
        )
    {
        string strSQL=
            "SELECT COUNT(*) AS CNT FROM EMP_Ishare_sys_prof "+
            "WHERE Orgcode= @OrgCode "+
            "AND SYSTEM_CODE= @SystemCode ";
        SqlParameter[] sp1 =
        {    
            new SqlParameter("@OrgCode", OrgCode),
            new SqlParameter("@SystemCode", strSystemCode),
        };

        DataTable dt1= Query(strSQL,sp1);

        strSQL =
            "SELECT  COUNT(*) AS CNT FROM EMP_Eshare_sys_prof " +
            "WHERE Orgcode= @OrgCode " +
            "AND SYSTEM_CODE= @SystemCode ";
        SqlParameter[] sp2 =
        {    
            new SqlParameter("@OrgCode", OrgCode),
            new SqlParameter("@SystemCode", strSystemCode),
        };
        DataTable dt2 = Query(strSQL, sp2);

        return (Convert.ToInt32(dt1.Rows[0]["CNT"].ToString()) > 0 || Convert.ToInt32(dt2.Rows[0]["CNT"].ToString()) > 0);

    }


}