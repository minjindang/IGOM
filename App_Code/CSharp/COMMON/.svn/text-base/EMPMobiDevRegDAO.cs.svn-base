using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// EMPMobiDevRegDAO 的摘要描述
/// </summary>
public class EMPMobiDevRegDAO : BaseDAO
{
    public EMPMobiDevRegDAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    public EMPMobiDevRegDAO(SqlConnection conn)
        : base(conn)

    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    // 查詢資料是否存在 Method 2
    // 
    public string queryADIDByUniqueID(
        string strUniqueID,
        string strMobType
        )
    {
        string strReturnValue = "";
        string strSQL =
            "SELECT AD_ID FROM EMP_MOBIDEV_REG " +
            "WHERE MOB_TYPE=@MOBTYPE " +
            "AND [UNIQUE_ID]=@UniqueID ";
        strSQL +=
            " AND (is_disable <>'Y' OR is_disable is null)";

        SqlParameter[] sp =
        {
            new SqlParameter("@MOBTYPE", strMobType),
            new SqlParameter("@UniqueID", strUniqueID)
        };
        DataTable dt = Query(strSQL, sp);

        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["AD_ID"].ToString();
        }

        return strReturnValue;
   }
    


    // 查詢資料是否存在
    public bool isDataExists(
        string strIDCard,
        string strADID,
        string strUniqueID,
        string isRegisted
        )
    {
        string strSQL =
            "SELECT COUNT(*) CNT FROM EMP_MOBIDEV_REG " +
            "WHERE ID_CARD=@IDCard " +
            "AND AD_ID=@ADID " +
            "AND [UNIQUE_ID]=@UniqueID ";
        if (isRegisted == "Y")
        {
            strSQL +=
                "AND IS_REGISTED='Y' ";
        }
        strSQL +=
            " AND (is_disable <>'Y' OR is_disable is null)";

        SqlParameter[] sp =
        {
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ADID", strADID),
            new SqlParameter("@UniqueID", strUniqueID)
        };
        DataTable dt= Query(strSQL, sp);

        return (Convert.ToInt32(dt.Rows[0]["CNT"].ToString()) > 0);
    }

    // 新增 EMP_MOBIDEV_REG
    public int insertEmpMobidevReg(
        string strIDCard,   // 
        string strADID,
        string strUniqueID,
        string strIsRegisted,
        string strChangeUserID
        ,string strMobType
        )
    {
        string strSQL =
            "INSERT INTO EMP_MOBIDEV_REG " +
            "( ID_CARD  " +
            ", Mob_type "+
            ", AD_ID  " +
            ", [UNIQUE_ID] " +
            ", REGISTED_DATE " +
            ", IS_REGISTED  " +
            ", CONFIRM_DATE  " +
            ", CHANGE_USERID  " +
            ", CHANGE_DATE ) " +
            "VALUES " +
            "(@IDCard " +
            ",@MobType "+
            ",@ADID " +
            ",@UniqueID " +
            ",getDate() " +
            ",@IsRegisted " +
            ",null " +
            ",@ChangeUserID " +
            ",getDate()) ";
        SqlParameter[] sp =
        {
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ADID", strADID),
            new SqlParameter("@MobType", strMobType),
            new SqlParameter("@UniqueID", strUniqueID),
            new SqlParameter("@IsRegisted", strIsRegisted),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };

        return Execute(strSQL, sp);
    }

    // 更新
    public int updateEmpMobidevReg(
        string strIDCard,   // 
        string strADID,
        string strUniqueID,
        string strIsRegisted,
        string strChangeUserID,
        string strUpdateConfirmDate // 是否更新 CONFIRM_DATE( Y/N )
        )
    {
        string strSQL=
            "UPDATE EMP_MOBIDEV_REG "+
            "SET IS_REGISTED  = @IsRegisted ";
        if (strUpdateConfirmDate=="Y")
        {
            strSQL+=
               ", CONFIRM_DATE  = getDate() ";
        }

        strSQL+=     
            ", CHANGE_USERID  = strChangeUserID "+
            ", CHANGE_DATE  = getDate() "+
            "WHERE ID_CARD=@IDCard " +
            "AND AD_ID=@ADID " +
            "AND [UNIQUE ID]=@UniqueID ";

        SqlParameter[] sp =
        {
            new SqlParameter("@IDCard", strIDCard),
            new SqlParameter("@ADID", strADID),
            new SqlParameter("@UniqueID", strUniqueID),
            new SqlParameter("@IsRegisted", strIsRegisted),
            new SqlParameter("@ChangeUserID", strChangeUserID)
        };

        return Execute(strSQL, sp);
    }

}