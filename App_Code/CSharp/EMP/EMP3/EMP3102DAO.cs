using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3102DAO 的摘要描述
/// </summary>
public class EMP3102DAO : BaseDAO
{
    public EMP3102DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    public EMP3102DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public int insertEMPIshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID,
        string strSystemCode,
        string strChangUserId
        )
    {
        string strSQL =
            "INSERT INTO EMP_ISHARE_SYS_PROF " +
                       "(ORGCODE " +
                       ",DEPART_ID " +
                       ",SHARE_ID " +
                       ",SYSTEM_CODE " +
                       ",CHANGE_USERID " +
                       ",CHANGE_DATE) " +
                 "VALUES " +
                       "(@OrgCode " +
                       ",@DepartID " +
                       ",@ShareID " +
                       ",@SystemCode " +
                       ",@ChangUserId " +
            //",REPLACE(CONVERT(NVARCHAR, GETDATE(), 23), '-', '') "+
                       ",getDate() " +
                       ") ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID),
            new SqlParameter("@SystemCode", strSystemCode),
            new SqlParameter("@ChangUserId", strChangUserId)
        };

        return Execute(strSQL, sp);
    }

    public DataTable queryEMPIshareSysProfFull(
         string strOrgCode,
         string strDepartID,
         string strShareID)
    {
        string strSQL =
           "SELECT ORGCODE, DEPART_ID " +
           ",SHARE_ID " +
           ",SYSTEM_CODE " +
           ",CHANGE_USERID " +
           ",CHANGE_DATE " +
           " FROM EMP_ISHARE_SYS_PROF " +
           " WHERE ORGCODE= @OrgCode ";
        if (strDepartID != "ALL" && strDepartID != "")
        {
            strSQL +=
                " AND  (Depart_id = @DepartID or Depart_id in (select depart_id from fsc_org where parent_depart_id=@DepartID)) ";
        }

        if (strShareID != "ALL" && strShareID != "")
        {
            strSQL +=
                " AND SHARE_ID = @ShareID ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID)
        };

        return Query(strSQL, sp);
    }

    public DataTable queryEMPIshareSysProf(string strOrgCode, string strDepartID, string strShareID)
    {
        string strSQL = "SELECT DISTINCT ORGCODE, DEPART_ID,SHARE_ID ";
        strSQL += " FROM EMP_ISHARE_SYS_PROF ";
        strSQL += " WHERE ORGCODE= @OrgCode  ";

        if (strDepartID != "ALL" && strDepartID != "")
        {
            strSQL += " AND (Depart_id = @DepartID or Depart_id in (select depart_id from fsc_org where parent_depart_id=@DepartID)) ";
        }

        string szSharedID = string.Empty;

        string[] words = strShareID.Split(';');
        foreach (string word in words)
        {
            if (word.Length>0)
            {
            szSharedID += word + ",";
            }
        }

        int length = szSharedID.Length;
        szSharedID = szSharedID.Substring(0, length - 1);

        if (strShareID != "ALL" && strShareID != "")
        {
            strSQL += " AND CAST(share_id AS INT) IN (" + szSharedID + ") ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID)
        };

        return Query(strSQL, sp);
    }


    public DataTable querySelectSystem
        (
        string strOrgCode,
        string strDepartID,
        string strShareID,
        string strisSelect
        )
    {
        string strSQL =
            "SELECT SYSTEM_CODE " +
            ",SYSTEM_NAME " +
            "FROM EMP_APPLICA_SYS_PROF ";
        strSQL +=
            "WHERE ORGCODE= @OrgCode " +
            " AND IS_ACTIVE_FLAG = 'Y' ";
        strSQL +=
            " AND SYSTEM_CODE ";

        if (strisSelect == "Y")
        {
            strSQL +=
                " IN ";
        }
        else
        {
            strSQL +=
               " NOT IN ";
        }
        strSQL +=
            " ( SELECT SYSTEM_CODE " +
            " FROM EMP_ISHARE_SYS_PROF " +
            " WHERE ORGCODE= @OrgCode ";
        if (strDepartID != "ALL" && strDepartID != "")
        {
            strSQL +=
                " AND DEPART_ID = @DepartID ";
        }

        if (strShareID != "ALL" && strShareID != "")
        {
            strSQL +=
                " AND SHARE_ID = @ShareID ";
        }
        strSQL +=
            " ) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID)
        };


        return Query(strSQL, sp);

    }


    public DataTable querySelectSystem_2
     (
     string strOrgCode,
     string strDepartID,
     string employee_type,
     string strisSelect
     )
    {
        string strSQL =
       "SELECT SYSTEM_CODE " +
       ",SYSTEM_NAME " +
       "FROM EMP_APPLICA_SYS_PROF ";
        strSQL +=
            "WHERE ORGCODE= @OrgCode " +
            " AND IS_ACTIVE_FLAG = 'Y' ";
        strSQL +=
            " AND SYSTEM_CODE ";

        if (strisSelect == "Y")
        {
            strSQL +=
                " IN ";
        }
        else
        {
            strSQL +=
               " NOT IN ";
        }
        strSQL +=
            " ( SELECT SYSTEM_CODE " +
            " FROM EMP_ISHARE_SYS_PROF " +
            " WHERE ORGCODE= @OrgCode ";
        if (strDepartID != "ALL" && strDepartID != "")
        {
            strSQL +=
                " AND DEPART_ID = @DepartID ";
        }

        if (employee_type != "ALL" && employee_type != "")
        {
            strSQL +=
                " AND SHARE_ID = @ShareID ";
        }
        strSQL +=
            " ) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", employee_type)
        };
        return Query(strSQL, sp);
    }


    public DataTable querySelectSystem_3
   (
   string strOrgCode,
   string strDepartID,
   string UcDDLMember,
   string strisSelect
   )
    {
        string strSQL =
       "SELECT SYSTEM_CODE " +
       ",SYSTEM_NAME " +
       "FROM EMP_APPLICA_SYS_PROF ";
        strSQL +=
            "WHERE ORGCODE= @OrgCode " +
            " AND IS_ACTIVE_FLAG = 'Y' ";
        strSQL +=
            " AND SYSTEM_CODE ";

        if (strisSelect == "Y")
        {
            strSQL +=
                " IN ";
        }
        else
        {
            strSQL +=
               " NOT IN ";
        }
        strSQL +=
            " ( SELECT SYSTEM_CODE " +
            " FROM EMP_ESHARE_SYS_PROF " +
            " WHERE ORGCODE= @OrgCode ";
        if (strDepartID != "ALL" && strDepartID != "")
        {
            strSQL +=
                " AND DEPART_ID = @DepartID ";
        }

        if (UcDDLMember != "ALL" && UcDDLMember != "")
        {
            strSQL +=
                " AND ID_CARD = @ShareID ";
        }
        strSQL +=
            " ) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", UcDDLMember)
        };
        return Query(strSQL, sp);
    }



    public string getOrgParentID(
            string strOrgCode,
            string strDepartID
      )
    {
        string strReturnValue = "";
        string strSQL =
            "SELECT PARENT_DEPART_ID FROM EMP_ORG " +
            "WHERE ORGCODE= @OrgCode " +
            "AND DEPART_ID= @DepartID ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID)
        };

        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            strReturnValue =
                dt.Rows[0]["PARENT_DEPART_ID"].ToString();
        }


        return strReturnValue;

    }

    // 刪除
    public int deleteEMPIshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID
        )
    {
        string strSQL =
            "DELETE FROM EMP_ISHARE_SYS_PROF " +
            "WHERE ORGCODE = @OrgCode " +
            "AND DEPART_ID = @DepartID " +
            "AND SHARE_ID = @ShareID ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID)
        };
        return Execute(strSQL, sp);
    }

    // Get Depart Name 
    public string getDeptNameByDepartID
        (
        string strOrgCode,
        string strDepartID
        )
    {
        string strReturnValue = "";
        string strSQL =
            "SELECT DEPART_NAME FROM EMP_ORG " +
            "WHERE DEPART_ID = @DepartID ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID)
        };
        DataTable dt = Query(strSQL, sp);

        if (dt.Rows.Count > 0)
        {
            strReturnValue =
                dt.Rows[0]["DEPART_NAME"].ToString();
        }

        return strReturnValue;
    }

}