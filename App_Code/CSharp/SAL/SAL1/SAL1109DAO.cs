using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SAL1109DAO
/// </summary>
namespace SAL.Logic
{
    public class SAL1109DAO : BaseDAO
    {
        public SAL1109DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }


        public DataTable SelectBaseSalary(string OrgCode, string UserId)
        {
            string StrSQL = string.Empty;

            StrSQL = "SELECT m.id_card, sa.BASE_KDB, sa.BASE_PTB FROM emp_member m LEFT JOIN SAL_SABASE sa ON m.id_number = sa.BASE_IDNO  Where sa.BASE_ORGID=@Orgcode ";
            StrSQL += " AND m.id_card = @UserId ";
          
      
            SqlParameter[] sp = {
		        new SqlParameter("@Orgcode", OrgCode),
		        new SqlParameter("@UserId", UserId)
	        };

            return Query(StrSQL, sp);

        }

        public DataTable GetDataByOrgFid(string orgcode, string flowId)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine(" select distinct b.user_name, ");
            sql.AppendLine("        c.orgcode_name Org_name, ");
            sql.AppendLine("        (select code_desc1 from sys_code where code_sys=\'023\' and code_type=\'022\' and code_no=b.employee_type) emp_type, ");
            sql.AppendLine("        a.Apply_date, ");
            sql.AppendLine("        (select code_desc1 from sys_code where code_sys=\'006\' and code_type=\'015\' and code_no=a.Apply_type) Applytype_name, ");
            sql.AppendLine("        Apply_amt, Apply_type, Relation_type,a.Event_date ");
            sql.AppendLine(" from SAL_ALLOWANCE_fee a ");
            sql.AppendLine("    inner join FSC_personnel b on a.user_id=b.id_card ");
            sql.AppendLine("    inner join FSC_org c on a.org_code=c.orgcode  ");
            sql.AppendLine(" where Org_code=@orgcode and flow_id=@flowId ");
            SqlParameter[] ps = {
            new SqlParameter("@orgcode", orgcode),
            new SqlParameter("@flowId", flowId)};

                return Query(sql.ToString(), ps);
        }
        public DataTable CheckApply(string Apply_type, string userid)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine(" select a.* ");
            sql.AppendLine("        from SAL_ALLOWANCE_fee a inner join SYS_Flow b on a.Flow_id=b.Flow_id ");
            sql.AppendLine("       where a.Apply_type=@Apply_type");
            sql.AppendLine("        and b.Case_status in ('0','1','2') ");
            sql.AppendLine("     and a.User_id =@userid");

            SqlParameter[] ps = {
            new SqlParameter("@Apply_type", Apply_type),
            new SqlParameter("@userid", userid)};

            return Query(sql.ToString(), ps);
        }
    }
}