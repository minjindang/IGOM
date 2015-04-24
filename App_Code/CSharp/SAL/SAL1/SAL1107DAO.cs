using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1107DAO
/// </summary>
namespace SAL.Logic
{
    public class SAL1107DAO : BaseDAO
    {
        public SAL1107DAO()
            :base(ConnectDB.GetDBString())
        {
             
        }

        public DataTable SelectEmployee(string Employee_type)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("SELECT a.Id_card, \n");
            StrSQL.Append("       a.User_name, \n");
            StrSQL.Append("       b.Depart_id, \n");
            StrSQL.Append("       c.Depart_name, \n"); 
            StrSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='023' AND code_type='022' AND code_no=a.Employee_type) as Employee_type ");
            StrSQL.Append("FROM   FSC_Personnel a \n");
            StrSQL.Append("       INNER JOIN FSC_Depart_EMP b \n");
            StrSQL.Append("               ON a.Id_card = b.Id_card \n");
            StrSQL.Append("       INNER JOIN FSC_ORG c \n");
            StrSQL.Append("               ON b.Depart_id = c.Depart_id \n");
            StrSQL.Append("WHERE  a.Employee_type = @Employee_type \n");
            StrSQL.Append("       AND ( a.Left_date = '' \n");
            StrSQL.Append("              OR a.Left_date IS NULL ) ");
    


            SqlParameter[] sp = { 
		        new SqlParameter("@Employee_type", Employee_type)
	        };

            return Query(StrSQL.ToString(), sp);

        }

        public DataTable getCheckData(string apply_ym, string non_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select *, ");
            sql.AppendLine(" (select top 1 User_name from FSC_Personnel where id_card=b.non_id ) as User_name ");
            sql.AppendLine("from SAL_TRANS_fee a ");
            sql.AppendLine(" inner join SAL_TRANS_feeDtl b on a.id=b.main_id ");
            sql.AppendLine(" inner join SYS_Flow c on a.flow_id=c.flow_id ");
            sql.AppendLine(" where c.Case_status in (0, 1, 2) ");
            sql.AppendLine(" and a.apply_ym=@apply_ym ");
            sql.AppendLine(" and b.Non_id=@non_id ");

            SqlParameter[] sp = { 
		        new SqlParameter("@apply_ym", apply_ym),
                new SqlParameter("@non_id", non_id)
	        };

            return Query(sql.ToString(), sp);
        }
    }
}