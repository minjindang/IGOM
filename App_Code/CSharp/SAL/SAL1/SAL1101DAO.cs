using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace SAL.Logic
{
    /// <summary>
    /// SAL1101DAO 的摘要描述
    /// </summary>
    public class SAL1101DAO : BaseDAO
    {
        public SAL1101DAO()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }

        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" select d.Depart_name, ");
            sql.AppendLine("        (select code_desc1 from sys_code where code_sys='023' and code_type='022' and code_no=c.employee_type) PEMEMCOD, ");
            sql.AppendLine("        c.user_name, a.* ");
            sql.AppendLine(" from SAL_TRAFFIC_FEE a ");
            sql.AppendLine("    inner join FSC_personnel c on a.user_id=c.id_card ");
            sql.AppendLine("    inner join FSC_org d on a.org_code=d.orgcode and a.unit_code=d.depart_id ");

            sql.AppendLine(" where a.org_code=@orgcode and a.flow_id=@flow_id ");

            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@orgcode", orgcode),
                new SqlParameter("@flow_id", flowId)};
            
            return Query(sql.ToString(), param);
        }

    }
}
