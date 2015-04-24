using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PRO2101DAO
/// </summary>

namespace PRO.Logic
{
    public class PRO2101DAO : BaseDAO
    {
        public PRO2101DAO() 
            : base(ConnectDB.GetMeggiDBString ())
        {

        }

        public DataTable SelectAll(string FA01_KIND, string FA01_MASTNO, string FA01_CLSNO, string FA01_STOREROOM, string FA01_ACCUSER,
                                        string FA01_BUYDTS, string FA01_BUYDTE, string FA01_AMT, string FA01_SUBDUE, string expire)
        {
            string whereSql = string.Empty;
            if (!string.IsNullOrEmpty(FA01_KIND))
            {
                whereSql += "  AND FA01_KIND =@FA01_KIND ";
            }
            if (!string.IsNullOrEmpty(FA01_MASTNO))
            {
                whereSql += " AND FA01_MASTNO =@FA01_MASTNO ";
            }
            if (!string.IsNullOrEmpty(FA01_CLSNO))
            {
                whereSql += " AND FA01_CLSNO =@FA01_CLSNO ";
            }
            if (!string.IsNullOrEmpty(FA01_STOREROOM))
            {
                whereSql += " AND FA01_STOREROOM like '%' + @FA01_STOREROOM + '%' ";
            }
            if (!string.IsNullOrEmpty(FA01_ACCUSER))
            {
                whereSql += " AND FA01_ACCUSER like '%' + @FA01_ACCUSER + '%' ";
            }
            if (!string.IsNullOrEmpty(FA01_BUYDTS))
            {
                whereSql += " AND FA01_BUYDT >=@FA01_BUYDTS ";
            }
            if (!string.IsNullOrEmpty(FA01_BUYDTE))
            {
                whereSql += " AND FA01_BUYDT <=@FA01_BUYDTE ";
            }
            if (!string.IsNullOrEmpty(FA01_AMT))
            {
                whereSql += " AND FA01_AMT >=@FA01_AMT ";
            }
            if (!string.IsNullOrEmpty(FA01_SUBDUE))
            {
                whereSql += " AND FA01_SUBDUE =@FA01_SUBDUE "; 
            }
            if (!string.IsNullOrEmpty(expire))
            {
                if (expire == "Y")
                {
                    whereSql += " AND [FA01_BUYDT]   < ";
                    whereSql += " replicate('0', 3 - len((YEAR(GETDATE()) - 1911 - FA02_RANGE) )) + cast ((YEAR(GETDATE()) - 1911 - FA02_RANGE) as varchar) +  ";
                    whereSql += " replicate('0', 2 - len((MONTH(GETDATE()) ) )) + cast ((MONTH(GETDATE())) as varchar) + ";
                    whereSql += " replicate('0', 2 - len((DAY(GETDATE())) )) + cast ((DAY(GETDATE())) as varchar) ";
                }
                else
                {
                    whereSql += " AND [FA01_BUYDT]   > ";
                    whereSql += " replicate('0', 3 - len((YEAR(GETDATE()) - 1911 - FA02_RANGE) )) + cast ((YEAR(GETDATE()) - 1911 - FA02_RANGE) as varchar) +  ";
                    whereSql += " replicate('0', 2 - len((MONTH(GETDATE()) ) )) + cast ((MONTH(GETDATE())) as varchar) + ";
                    whereSql += " replicate('0', 2 - len((DAY(GETDATE())) )) + cast ((DAY(GETDATE())) as varchar) ";
                }
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ROW_NUMBER() OVER (order by FA01_KIND)  [Index] , * \n");
            sql.Append("FROM   ( \n");
           
            for (int i = 1; i < 19; i++)
            {
                 sql.Append("        SELECT * \n");
                 if (i == 1)
                 {
                     sql.Append(string.Format("        FROM [viewFA{1}_All] \n", i.ToString(), i.ToString().PadLeft(2, '0')));
                 }
                 else
                 {
                     sql.Append(string.Format("        FROM [FA{0}].[dbo].[viewFA{1}_All]", i.ToString(), i.ToString().PadLeft(2, '0')));
                 }
                 sql.Append("        WHERE  1=1 \n");
                 sql.Append(whereSql);
                 if (i!=18)
                 {
                     sql.Append("        UNION \n");
                 }
            }

            sql.Append("         ) T ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@FA01_KIND", FA01_KIND),
                                                    new SqlParameter("@FA01_MASTNO", FA01_MASTNO),
                                                    new SqlParameter("@FA01_CLSNO", FA01_CLSNO),
                                                    new SqlParameter("@FA01_STOREROOM", FA01_STOREROOM),
                                                    new SqlParameter("@FA01_ACCUSER", FA01_ACCUSER),
                                                    new SqlParameter("@FA01_BUYDTS", FA01_BUYDTS),
                                                    new SqlParameter("@FA01_BUYDTE", FA01_BUYDTE),
                                                    new SqlParameter("@FA01_AMT", FA01_AMT),
                                                    new SqlParameter("@FA01_SUBDUE", FA01_SUBDUE)};

            return Query(sql.ToString(), sp);
        }



    }
}