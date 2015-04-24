using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1108DAO
/// </summary>

namespace SAL.Logic
{
    public class SAL1108DAO : BaseDAO
    {
        public SAL1108DAO()
            : base(ConnectDB.GetDBString())
        {
             
        }

        public DataTable SelectSAbase(string BASE_IDNO, string BASE_NAME, string BASE_JOB,string BASE_STATUS)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT BASE_SEQNO,  \n");
            sql.Append("       BASE_NAME  \n");
            sql.Append("FROM   sal_sabase \n");
            sql.Append("WHERE  BASE_JOB = @BASE_JOB \n");
            sql.Append("       AND BASE_STATUS = @BASE_STATUS ");

            if (!string.IsNullOrEmpty(BASE_IDNO))
                sql.AppendLine(" AND BASE_IDNO=@BASE_IDNO ");
            
            if (!string.IsNullOrEmpty(BASE_NAME))
                sql.AppendLine(" AND BASE_NAME like @BASE_NAME ");
            
            SqlParameter[] sp = new SqlParameter[] { 
                new SqlParameter("@BASE_JOB", BASE_JOB),
                new SqlParameter("@BASE_STATUS", BASE_STATUS),
                new SqlParameter("@BASE_IDNO", BASE_IDNO),
                new SqlParameter("@BASE_NAME", "%"+BASE_NAME+"%")};

            return Query(sql.ToString(), sp);
        }

        public DataTable getCheckData(string Apply_ym, string vol_user_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select *, ");
            sql.AppendLine(" (select top 1 User_name from FSC_Personnel where id_card=b.vol_user_id) as User_name ");
            sql.AppendLine(" from SAL_VOL_fee a ");
            sql.AppendLine(" inner join SAL_VOL_feeDtl b on a.Id=b.main_id ");
            sql.AppendLine(" inner join SYS_Flow c on a.Flow_id=c.flow_id ");
            sql.AppendLine(" where c.Case_status in ('0','1','2') ");
            sql.AppendLine(" and a.Apply_ym=@Apply_ym ");
            sql.AppendLine(" and b.vol_user_id=@vol_user_id ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Apply_ym", Apply_ym),
                                                     new SqlParameter("@vol_user_id", vol_user_id)};

            return Query(sql.ToString(), sp);
        }
    }
}