using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL3120DAO 的摘要描述
/// </summary>
public class SAL3120DAO: BaseDAO
{
	public SAL3120DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL3120DAO(SqlConnection conn)
        : base(conn)
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    // 取得資料
    public DataTable getData(
        string strOrgCode
        )
    {
        string strSQL = " SELECT top 100 SAL_SABATENGF.*, sal_saunit.unit_dep ";
//        strSQL += " ,isnull((select top 1 role_employees_name from sarole_new where role_orgid=engf_orgid and role_employees_id=engf_userid),'') as user_name";
        strSQL += " ,isnull((select top 1 user_name from emp_member where id_card=engf_userid),'') as user_name";

        strSQL += " FROM SAL_SABATENGF ";

        strSQL += " left join sal_saunit ";
        strSQL += " on SAL_SABATENGF.ENGF_ORGID=sal_saunit.unit_no ";
        strSQL += " where 1=1 ";

        if (!(strOrgCode == "3799999999"))
        {
            strSQL = strSQL + " AND ENGF_ORGID= @OrgCode ";
        }

        strSQL += " ORDER BY ENGF_BOOKTIME DESC";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgCode",strOrgCode) //--年月 YYYYMM
         };

        return Query(strSQL, sp);

    }




}