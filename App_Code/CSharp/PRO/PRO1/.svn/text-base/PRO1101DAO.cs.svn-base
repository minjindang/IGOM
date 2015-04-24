using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PRO1101DAO
/// </summary>
namespace PRO.Logic
{
    public class PRO1101DAO: BaseDAO
    {
        public PRO1101DAO()
            : base(ConnectDB.GetMeggiDBString())
        {
            
        }

        public DataTable SelectSTOREROOM(string ACCUSER)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT DISTINCT T.[FA01_STOREROOM] \n");
            sql.Append("FROM   (SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA1].[dbo].[viewFA01_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA2].[dbo].[viewFA02_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA3].[dbo].[viewFA03_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA4].[dbo].[viewFA04_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA5].[dbo].[viewFA05_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA6].[dbo].[viewFA06_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA7].[dbo].[viewFA07_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA8].[dbo].[viewFA08_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA9].[dbo].[viewFA09_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA10].[dbo].[viewFA10_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA11].[dbo].[viewFA11_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA12].[dbo].[viewFA12_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA13].[dbo].[viewFA13_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA14].[dbo].[viewFA14_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA15].[dbo].[viewFA15_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA16].[dbo].[viewFA16_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA17].[dbo].[viewFA17_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER \n");
            sql.Append("        UNION \n");
            sql.Append("        SELECT DISTINCT [FA01_STOREROOM] \n");
            sql.Append("        FROM   [FA18].[dbo].[viewFA18_All] \n");
            sql.Append("        WHERE  [FA01_ACCUSER] = @ACCUSER) T ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ACCUSER", ACCUSER)};

            return Query(sql.ToString(), sp);

        }

        public DataTable SelectFAData(string ACCUSER, string STOREROOM)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * \n");
            sql.Append("FROM ( ");

            for (int i = 1; i <= 18; i++)
            {
                sql.AppendLine("    SELECT a.* ");
                sql.AppendLine("        FROM   [FA" + i + "].[dbo].[viewFA" + i.ToString().PadLeft(2, '0') + "_All] a ");
                sql.AppendLine("               INNER JOIN [FA" + i + "].[dbo].[viewFA" + i.ToString().PadLeft(2, '0') + "_Scrap] b ");
                sql.AppendLine("                      ON a.FA01_MASTNO = b.FA01_MASTNO ");
                sql.AppendLine("        WHERE  a.[FA01_ACCUSER] = @ACCUSER ");
                sql.AppendLine("               AND ';' + @STOREROOM + ';' LIKE '%;' + Rtrim(Ltrim(a.[FA01_STOREROOM])) + ';%' ");

                if (i != 18) sql.AppendLine("        UNION ");
            }
            sql.AppendLine("   ) T ");
            
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ACCUSER", ACCUSER),
                                                     new SqlParameter("@STOREROOM", STOREROOM)};

            return Query(sql.ToString(), sp);

        }

    }
}