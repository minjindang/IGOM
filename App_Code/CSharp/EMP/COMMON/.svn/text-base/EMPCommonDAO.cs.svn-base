using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// EMPCommonDAO 的摘要描述
/// </summary>
public class EMPCommonDAO : BaseDAO
{
	public EMPCommonDAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string getOrgName(
        string strOrgCode
        )
    {
        string strReturnValue = "";
        string strSQL =
            "SELECT ORGCODE_NAME FROM FSC_ORG " +
            "WHERE ORGCODE= @OrgCode ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode", strOrgCode),
        };

        DataTable dt= Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            strReturnValue = dt.Rows[0]["ORGCODE_NAME"].ToString();
        }
        return strReturnValue;

    }

    public DataTable getApplica(string AD_id)
    {
        string sql = " select a.AD_id, a.Web_URL from EMP_Eshare_sys_prof e ";
        sql += " inner join EMP_Applica_sys_prof a on e.System_code = a.System_code ";
        sql += " where e.Id_card in (select id_card from emp_member where AD_id=@AD_id ";
        sql += " union select id_card from emp_nonmember where AD_id=@AD_id) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@AD_id", AD_id),
        };
        DataTable dt = Query(sql, sp);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            sql = " select a.AD_id, a.Web_URL from EMP_Ishare_sys_prof i ";
            sql += " inner join EMP_Applica_sys_prof a on i.System_code = a.System_code ";
            sql += " where i.Share_id in (select Employee_type from emp_member where AD_id=@AD_id ";
            sql += " union select NonEmployee_type from emp_nonmember where AD_id=@AD_id) ";

            return Query(sql, sp);
        }
    }
}