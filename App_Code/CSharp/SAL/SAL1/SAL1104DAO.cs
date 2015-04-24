using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1104DAO
/// </summary>

namespace SAL.Logic
{
    public class SAL1104DAO : BaseDAO
    {
        public SAL1104DAO()
            :base(ConnectDB.GetDBString())
        {
             
        }

        public DataTable SelectBankCode(string OrgCode)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("SELECT CODE_DESC1, \n");
            StrSQL.Append("       CODE_NO \n");
            StrSQL.Append("FROM   sal_satdpf \n");
            StrSQL.Append("       LEFT OUTER JOIN SYS_CODE \n");
            StrSQL.Append("                    ON CODE_SYS = '004' \n");
            StrSQL.Append("                       AND CODE_TYPE = '002' \n");
            StrSQL.Append("                       AND CODE_NO = tdpf_bank \n");
            StrSQL.Append("WHERE  tdpf_orgid = @tdpf_orgid \n");
            StrSQL.Append("ORDER  BY TDPF_BANK ");

             SqlParameter[] sp = { 
		        new SqlParameter("@tdpf_orgid", OrgCode)
	        };

            return Query(StrSQL.ToString(),sp);

        }

        public DataTable SelectItemCode()
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("SELECT CODE_DESC1, \n");
            StrSQL.Append("       code_no \n");
            StrSQL.Append("FROM   SYS_CODE \n");
            StrSQL.Append("WHERE  CODE_SYS = '005' \n");
            StrSQL.Append("       AND CODE_TYPE = '001' \n");
            StrSQL.Append("       AND code_no IN ( '605', '606', '604', '608' ) \n");
            StrSQL.Append("ORDER  BY code_desc1 ");
            
             
            return Query(StrSQL.ToString());

        }

        public DataTable SelectDataByMeetdateMeetcontent(string meetdate,string Meeting_content)
        {
            string StrSQL = string.Empty;
            // 代碼尚未確認  評委出席審查、講師鐘點費的 代碼
            StrSQL = "select * from SAL_EXAMINE_fee ef where 1=1   ";

            if (!string.IsNullOrEmpty(meetdate))
            {
                StrSQL += "AND ef.meeting_date=@meetdate ";
            }

            if (!string.IsNullOrEmpty(Meeting_content))
            {
                StrSQL += "AND ef.Meeting_content=@Meeting_content ";
            }
            StrSQL += "Order By Budget_code";

            SqlParameter[] sp = { 
		        new SqlParameter("@meetdate", meetdate),
                new SqlParameter("@Meeting_content", Meeting_content)
	        };

            return Query(StrSQL, sp);

        }

        public DataTable getDataByOrgFid(string Orgcode, string flow_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select distinct f.*, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='002' and code_type='001' and code_no=f.Meeting_pos) Meeting_pos_name, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='006' and code_type='018' and code_no=f.Budget_code) Budget_name, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='005' and code_type='001' and code_no=f.Item_code) Item_name, ");
            sql.AppendLine(" case when b.BASE_IDNO is not null then 'true' else 'false' end e ");
            sql.AppendLine(" from SAL_EXAMINE_fee f ");
            sql.AppendLine(" left join SAL_SABASE b on f.BASE_IDNO=b.BASE_IDNO ");
            sql.AppendLine(" where f.Org_code=@Orgcode and f.flow_id=@flow_id ");
            SqlParameter[] sp = { 
		        new SqlParameter("@Orgcode", Orgcode),
                new SqlParameter("@flow_id", flow_id)
	        };

            return Query(sql.ToString(), sp);
        }

        public string GetNewSEQNO()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" SELECT ISNULL((SELECT TOP (1) BASE_SEQNO ");
            sql.AppendLine(" FROM  SAL_SABASE ");
            sql.AppendLine(" WHERE (BASE_SEQNO LIKE '#%') and len(BASE_SEQNO) = 6 ");
            sql.AppendLine(" ORDER BY   BASE_SEQNO DESC), '') AS BASE_SEQNO ");

            DataTable dt = Query(sql.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["BASE_SEQNO"].ToString()))
                    return "#" + (Convert.ToInt32(dt.Rows[0]["BASE_SEQNO"].ToString().Substring(1, 5).ToString()) + 1).ToString().PadLeft(5, '0');
            }

            return "#00001";
        }

        public DataTable getDataByOrgUserId(string Orgcode, string User_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select distinct f.*, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='002' and code_type='001' and code_no=f.Meeting_pos) Meeting_pos_name, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='006' and code_type='018' and code_no=f.Budget_code) Budget_name, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='005' and code_type='001' and code_no=f.Item_code) Item_name, ");
            sql.AppendLine(" case when b.BASE_IDNO is not null then 'true' else 'false' end e ");
            sql.AppendLine(" from SAL_EXAMINE_fee f ");
            sql.AppendLine(" left join SAL_SABASE b on f.BASE_IDNO=b.BASE_IDNO ");
            sql.AppendLine(" where f.Org_code=@Orgcode and f.User_id=@User_id ");
            sql.AppendLine(" and isnull(f.Flow_id,'')=''  ");

            SqlParameter[] sp = { 
		        new SqlParameter("@Orgcode", Orgcode),
                new SqlParameter("@User_id", User_id)
	        };

            return Query(sql.ToString(), sp);
        }
    }
}