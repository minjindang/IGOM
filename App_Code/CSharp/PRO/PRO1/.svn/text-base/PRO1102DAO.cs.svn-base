using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PRO1102DAO
/// </summary>
namespace PRO.Logic
{
    public class PRO1102DAO : PRO1101DAO
    {
        public PRO1102DAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectFAData(string ACCUSER, string STOREROOM)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * \n");
            sql.Append("FROM  ( ");

            for (int i = 1; i <= 18; i++)
            {
                sql.AppendLine("    SELECT a.*, ");
                sql.AppendLine("            CONVERT(INTEGER,a.FA01_BUYDT)+CONVERT(INTEGER, CONVERT(VARCHAR(10),a.FA02_RANGE)+'0000') as FA02_DELDT ");
                sql.AppendLine("        FROM   [FA" + i + "].[dbo].[viewFA" + i.ToString().PadLeft(2, '0') + "_All] a ");
                sql.AppendLine("               INNER JOIN [FA" + i + "].[dbo].[viewFA" + i.ToString().PadLeft(2, '0') + "_Scrap] b ");
                sql.AppendLine("                      ON a.FA01_MASTNO = b.FA01_MASTNO ");
                sql.AppendLine("        WHERE  a.[FA01_ACCUSER] = @ACCUSER ");
                sql.AppendLine("               AND ';' + @STOREROOM + ';' LIKE '%;' + Rtrim(Ltrim(a.[FA01_STOREROOM])) + ';%' ");
                sql.AppendLine("               AND CONVERT(INTEGER,a.FA01_BUYDT)+CONVERT(INTEGER, CONVERT(VARCHAR(10),a.FA02_RANGE)+'0000')<@NOWDATE ");

                if (i != 18) sql.AppendLine("        UNION ");                 
            }

            sql.AppendLine("   ) T ");


            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ACCUSER", ACCUSER),
                                                     new SqlParameter("@STOREROOM", STOREROOM),
                                                     new SqlParameter("@NOWDATE", FSC.Logic.DateTimeInfo.GetRocTodayString(DateTime.Now.ToString("yyyyMMdd")))};

            return Query(sql.ToString(), sp);

        }

        public DataTable SelectDataByOrgFid(string Orgcode, string flow_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select     ");  
            sql.Append("Property_id  FA01_MASTNO, \n");
            sql.Append("Property_clsno  FA01_CLSNO, \n");
            sql.Append("Property_name  FA01_NAME, \n");
            sql.Append("(select top 1 CODE_DESC1 from SYS_CODE where code_sys='016' and code_type='006' and code_no=f.Property_type)  FA01_KIND, \n");
            sql.Append("LOCATION  FA01_LOCATION, \n");
            sql.Append("LifeTime  FA02_RANGE, \n");
            sql.Append("Buy_date  FA01_BUYDT, \n");
            sql.Append("Scrap_date  FA02_CLSNO");
            sql.AppendLine(" from PRO_PropertyScrap_main f ");
            sql.AppendLine(" where f.Orgcode=@Orgcode and f.flow_id=@flow_id ");

            SqlParameter[] sp = { 
		        new SqlParameter("@Orgcode", Orgcode),
                new SqlParameter("@flow_id", flow_id)
	        };

            return Query(sql.ToString(), sp);
        }
    }
}