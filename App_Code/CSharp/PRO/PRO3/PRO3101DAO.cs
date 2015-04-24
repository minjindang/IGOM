using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PRO3101DAO
/// </summary>
namespace PRO.Logic
{
    public class PRO3101DAO :BaseDAO
    {
        public PRO3101DAO() : base(ConnectDB.GetDBString())
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectAll(string OrgCode, string OfficialNumber_id, string Software_id, DateTime Last_dateS, DateTime Last_dateE,
                                   string SoftwareUnit_name, string Unit_code, string User_id, string Software_name,
                                   string Fee_amtS, string Fee_amtE, string Fee_amtL, string Fee_amtM, string Orderby)
        { 
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format(" SELECT ROW_NUMBER() OVER (order by {0}) [Index],",Orderby));
            sql.Append(string.Format(" DENSE_RANK() over (order by {0}) [GroupId], ",Orderby));
            sql.Append(string.Format(" (select  top 1 Depart_name from  FSC_ORG as b where b.Depart_id = a.Unit_code) as departname,"));
            sql.Append(string.Format(" (select  top 1 User_name from  FSC_Personnel as b where b.Id_card = a.ModUser_id) as username,"));
            sql.Append(" * FROM PRO_SwRegister_main as a where OrgCode=@OrgCode");


            if (!string.IsNullOrEmpty(OfficialNumber_id))
            {
                sql.Append(" AND OfficialNumber_id=@OfficialNumber_id ");
            }
            if (!string.IsNullOrEmpty(Software_id))
            {
                sql.Append(" AND Software_id=@Software_id ");
            }
            if (Last_dateS != DateTime.MinValue || Last_dateE != DateTime.MinValue)
            {
                sql.Append(" AND Flow_id in ( ");
                sql.Append(" SELECT  [Flow_id]  FROM  [dbo].[SYS_Flow] where OrgCode= @OrgCode and Form_id in ('004006','004007') ");
                if (Last_dateS != DateTime.MinValue)
                {
                    sql.Append(" and Last_date >= @Last_dateS ");
                }
                if (Last_dateE != DateTime.MinValue)
                {
                    sql.Append(" and Last_date <= @Last_dateE ");
                }
                sql.Append(" ) ");
            }
            else
            {
                Last_dateS = DateTime.Now;
                Last_dateE = DateTime.Now;
            }
            if (!string.IsNullOrEmpty(SoftwareUnit_name))
            {
                sql.Append(" AND SoftwareUnit_name=@SoftwareUnit_name ");
            }
            if (!string.IsNullOrEmpty(Unit_code))
            {
                sql.Append(" AND Unit_code=@Unit_code ");
            }
            if (!string.IsNullOrEmpty(User_id))
            {
                sql.Append(" AND User_id=@User_id ");
            }
            if (!string.IsNullOrEmpty(Software_name))
            {
                sql.Append(" AND Software_name=@Software_name ");
            }
            if (!string.IsNullOrEmpty(Fee_amtS))
            {
                sql.Append(" AND Fee_amt >= @Fee_amtS ");
            }
            if (!string.IsNullOrEmpty(Fee_amtE))
            {
                sql.Append(" AND Fee_amt <= @Fee_amtE ");
            }
            if (!string.IsNullOrEmpty(Fee_amtL))
            {
                sql.Append(" AND Fee_amt < @Fee_amtL ");
            }
            if (!string.IsNullOrEmpty(Fee_amtM))
            {
                sql.Append(" AND Fee_amt > @Fee_amtM ");
            }
            sql.Append(" ORDER BY  " +Orderby);


            SqlParameter[] sp = new SqlParameter[] {new SqlParameter("@OrgCode", OrgCode),
                                                    new SqlParameter("@OfficialNumber_id", OfficialNumber_id),
                                                    new SqlParameter("@Software_id", Software_id),
                                                    new SqlParameter("@Last_dateS", Last_dateS),
                                                    new SqlParameter("@Last_dateE", Last_dateE),
                                                    new SqlParameter("@SoftwareUnit_name", SoftwareUnit_name),
                                                     new SqlParameter("@Unit_code", Unit_code),
                                                    new SqlParameter("@User_id", User_id),
                                                    new SqlParameter("@Software_name", Software_name),
                                                    new SqlParameter("@Fee_amtS", Fee_amtS),
                                                    new SqlParameter("@Fee_amtE", Fee_amtE),
                                                    new SqlParameter("@Fee_amtL", Fee_amtL),
                                                    new SqlParameter("@Fee_amtM", Fee_amtM)};

            return Query(sql.ToString(), sp);
        }
    }
}