using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3103DAO 的摘要描述
/// </summary>
public class EMP3103DAO : BaseDAO
{
	public EMP3103DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼 
		//
	}
    public EMP3103DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public int insertEMPEshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID,
        string strSystemCode,
        string strChangUserId
        ,string strIDCard
        )
    {
        string strSQL =
            "INSERT INTO EMP_ESHARE_SYS_PROF " +
                       "(ORGCODE " +
                       ",DEPART_ID " +
                       ",SHARE_ID " +
                       ",SYSTEM_CODE " +
                       ",changeUser_id " +
                       ",CHANGE_DATE "+
                       ",ID_CARD) " +
                 "VALUES " +
                       "(@OrgCode " +
                       ",@DepartID " +
                       ",@ShareID " +
                       ",@SystemCode " +
                       ",@ChangUserId " +
            //",REPLACE(CONVERT(NVARCHAR, GETDATE(), 23), '-', '') "+
                       ",getDate() " +
                       ",@IdCard "+
                       ") ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@ShareID", strShareID),
            new SqlParameter("@SystemCode", strSystemCode),
            new SqlParameter("@IdCard", strIDCard),
            new SqlParameter("@ChangUserId", strChangUserId)
        };

        return Execute(strSQL, sp);
    }

    public DataTable queryEMPEshareSysProfFull(
         string strOrgCode,
         string strDepartID,
         string strShareID,
         string strIDCard
        )
    {
        string strSQL =
           "SELECT ORGCODE, DEPART_ID " +
           ",SHARE_ID " +
           ",SYSTEM_CODE " +
           ",changeUser_id " +
           ",CHANGE_DATE " +
           ",ID_CARD "+
           " FROM EMP_ESHARE_SYS_PROF " +
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

        if (strIDCard != "ALL" && strIDCard != "")
        {
            strSQL +=
                " AND ID_CARD = @IdCard ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IdCard", strIDCard),
            new SqlParameter("@ShareID", strShareID)
        };

        return Query(strSQL, sp);
    }

    public DataTable queryEMPEshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID,
        string strIDCard
        )
    {
        string strSQL =
            "SELECT DISTINCT ORGCODE, DEPART_ID " +
            ",SHARE_ID,ID_CARD " +
            " FROM EMP_ESHARE_SYS_PROF " +
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

        if (strIDCard != "ALL" && strIDCard != "")
        {
            strSQL +=
                " AND ID_CARD = @IdCard ";
        }


        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IdCard", strIDCard),
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
        ,string strIDCard
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

        if (strShareID != "ALL" && strShareID != "")
        {
            strSQL +=
                " AND SHARE_ID = @ShareID ";
        }
        if (strIDCard != "ALL" && strIDCard != "")
        {
            strSQL +=
                " AND ID_CARD = @IdCard ";
        }

        strSQL +=
            " ) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IdCard", strIDCard),
            new SqlParameter("@ShareID", strShareID)
        };


        return Query(strSQL, sp);

    }


    // 刪除
    public int deleteEMPEshareSysProf(
        string strOrgCode,
        string strDepartID,
        string strShareID,
        string strIDCard
        )
    {
        string strSQL =
            "DELETE FROM EMP_ESHARE_SYS_PROF " +
            "WHERE ORGCODE = @OrgCode " +
            "AND DEPART_ID = @DepartID " +
            "AND SHARE_ID = @ShareID "+
            "AND ID_CARD = @IdCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartID),
            new SqlParameter("@IdCard", strIDCard),
            new SqlParameter("@ShareID", strShareID)
        };
        return Execute(strSQL, sp);
    }

    // 取得員工姓名
    public string getUserName(string strIDCard)
    {
        /*
        string strReturnValue="";
        string strSQL =
            "SELECT USER_NAME FROM EMP_MEMBER "+
            "WHERE ID_CARD= @IdCard "+
            "UNION "+
            "SELECT USER_NAME FROM EMP_NONMEMBER "+
            "WHERE ID_CARD= @IdCard ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IdCard", strIDCard)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["USER_NAME"].ToString();
        }
        */


        return getUserName("","","",strIDCard);
    }

    public string getUserName(string strOrgCode, string strDepartCode, string strEmployeeType, string strIDCard)
    {
        string strReturnValue = "";
        string strSQL =
            "SELECT USER_NAME FROM EMP_MEMBER " +
            "WHERE ID_CARD IN " +
            "(SELECT ID_CARD FROM EMP_DEPART_EMP " +
            "WHERE 1=1 ";
        if (strOrgCode!="")
        {
            strSQL +=
                "AND ORGCODE= @OrdCode ";
        }
        if (strDepartCode != "")
        {
            strSQL +=
                "AND DEPART_ID=@DepartID ";
        }
        strSQL +=
            " ) "+
            "AND ID_CARD= @IdCard ";
        if (strEmployeeType != "")
        {
            strSQL +=
            "AND EMPLOYEE_TYPE =@EmployeeType ";
        }
        strSQL +=
            " UNION ";
        strSQL+=
            "SELECT USER_NAME FROM EMP_NONMEMBER " +
            "WHERE ID_CARD IN " +
            "(SELECT ID_CARD FROM EMP_DEPART_EMP " +
            "WHERE 1=1 ";
        if (strOrgCode != "")
        {
            strSQL +=
                "AND ORGCODE= @OrdCode ";
        }
        if (strDepartCode != "")
        {
            strSQL +=
                "AND DEPART_ID=@DepartID  ";
        }
        strSQL +=
            " ) "+
            "AND ID_CARD= @IdCard ";
        if (strEmployeeType != "")
        {
            strSQL +=
            "AND NONEMPLOYEE_TYPE =@EmployeeType ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrdCode", strOrgCode),
            new SqlParameter("@DepartID", strDepartCode),
            new SqlParameter("@IdCard", strIDCard),
            new SqlParameter("@EmployeeType", strEmployeeType)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["USER_NAME"].ToString();
        }

        return strReturnValue;
    }





    public DataTable querySelectnametype
      (
      string namevlue  
      )
    {
        string strSQL =
            "SELECT * " +
            "FROM EMP_Member " +
            "WHERE id_card = @namevlue";
     

        SqlParameter[] sp =
        {
            new SqlParameter("@namevlue", namevlue)
         
        };

        return Query(strSQL, sp);
    }



    public DataTable querySelectnonametype
    (
    string namevlue
    )
    {
        string strSQL =
            "SELECT * " +
            "FROM EMP_NonMember " +
            "WHERE id_card = @namevlue";


        SqlParameter[] sp =
        {
            new SqlParameter("@namevlue", namevlue)
         
        };

        return Query(strSQL, sp);
    }



}