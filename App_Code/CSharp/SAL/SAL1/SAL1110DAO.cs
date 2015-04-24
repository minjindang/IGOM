using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for SAL1110DAO
/// </summary>
namespace SAL.Logic
{
    public class SAL1110DAO : BaseDAO
    {
        public SAL1110DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine(" select distinct b.user_name, a.Apply_yy, a.Apply_date ");
            sql.AppendLine(" from SAL_PROOF_rpt a ");
            sql.AppendLine("    inner join FSC_personnel b on a.user_id=b.id_card ");
            sql.AppendLine(" where Org_code=@orgcode and flow_id=@flowId ");
            SqlParameter[] ps = {
            new SqlParameter("@orgcode", orgcode),
            new SqlParameter("@flowId", flowId)};

            return Query(sql.ToString(), ps);
        }

        public DataTable getCheckData(string Apply_yy, string User_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select a.* from sal_proof_rpt a ");
            sql.AppendLine(" inner join SYS_Flow b on a.flow_id=b.flow_id ");
            sql.AppendLine(" where a.Apply_yy=@Apply_yy ");
            sql.AppendLine(" and a.User_id=@User_id ");
            sql.AppendLine(" and b.case_status in (0, 1, 2) ");

            SqlParameter[] ps = {
            new SqlParameter("@Apply_yy", Apply_yy),
            new SqlParameter("@User_id", User_id)};

            return Query(sql.ToString(), ps);
        }
    }
}