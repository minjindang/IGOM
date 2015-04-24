using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PRO.Logic
{
    public class PRO1104DAO: BaseDAO
    {
        public DataTable getData(string User_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select ");
            sql.AppendLine(" a.OfficialNumber_id, ");
            sql.AppendLine(" a.Software_id, ");
            sql.AppendLine(" a.Software_type, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code where code_sys='016' and code_type='004' and code_no=a.Software_type) as Software_type_name, ");
            sql.AppendLine(" a.Software_name, ");
            sql.AppendLine(" a.Flow_id, ");
            sql.AppendLine(" a.Unit_code, ");
            sql.AppendLine(" a.User_id ");
            sql.AppendLine(" from PRO_SwRegister_main a ");
            sql.AppendLine(" inner join SYS_Flow b on a.Flow_id=b.Flow_id ");
            sql.AppendLine(" where a.User_id =@User_id ");
            sql.AppendLine(" and b.Case_status='1' and b.Last_pass='1' ");
            sql.AppendLine(" and a.Flow_id not in ( ");
            sql.AppendLine(" select t.SR_Flow_id from PRO_SwRegister_Trans t ");
            sql.AppendLine(" inner join Sys_flow f on a.Flow_id=b.Flow_id ");
            sql.AppendLine(" where b.Case_status in ('0','1','2')) ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@User_id", User_id) };

            return Query(sql.ToString(), sp);
        }
    }
}