using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1105DAO
/// </summary>

namespace SAL.Logic
{
    public class SAL1105DAO :BaseDAO
    {
        public SAL1105DAO()
            : base(ConnectDB.GetDBString())
        {
             
        }


        public DataTable SelectReportData(string Orgcode, string UserId, string Apply_yy)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("SELECT hsf.*, \n");
            StrSQL.Append("       sa.BASE_NAME, \n");
            StrSQL.Append("       sa.BASE_ORG_L1 \n");
            StrSQL.Append("FROM   SAL_HealthSubsidy_fee hsf \n");
            StrSQL.Append("       LEFT JOIN SAL_SABASE sa \n");
            StrSQL.Append("              ON hsf.user_id = sa.BASE_SEQNO \n");
            StrSQL.Append("WHERE  Org_code = @Orgcode ");

            if (!string.IsNullOrEmpty(UserId))
            {
                StrSQL.Append("  AND  User_Id=@UserId ");
            }

            if (!string.IsNullOrEmpty(Apply_yy))
            {
                StrSQL.Append("  AND  Apply_yy=@Apply_yy ");
            }


            SqlParameter[] sp = { 
		        new SqlParameter("@Orgcode", Orgcode),
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@Apply_yy", Apply_yy)
	        };

            return Query(StrSQL.ToString(), sp);

        }

    }
}