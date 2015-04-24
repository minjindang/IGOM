using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1102DAO
/// </summary>
namespace SAL.Logic
{
    public class SAL1102DAO : BaseDAO
    {
        public SAL1102DAO()
            :base (ConnectDB.GetDBString())
        {
             
        }

        public DataTable SelectDutyInfo(string flow_id)
        {
             StringBuilder  sql = new StringBuilder();
             sql.Append("SELECT (SELECT Depart_name \n");
             sql.Append("        FROM   EMP_ORG \n");
             sql.Append("        WHERE  Depart_id = (select case when Parent_depart_id is null then Depart_id else Parent_depart_id end FROM  EMP_ORG where Depart_id= c.Depart_id ) )                        Depart_name, \n");
             sql.Append("       c.Depart_id, \n");
             sql.Append("       c.Id_card, \n");
             sql.Append("       (SELECT User_name \n");
             sql.Append("        FROM   FSC_Personnel \n");
             sql.Append("        WHERE  Id_card = c.Id_card)                            User_name, \n");
             sql.Append("       c.Sche_date, \n");
             sql.Append("       d.Start_time, \n");
             sql.Append("       d.End_time, \n");
             sql.Append("       c.Schedule_hours, \n");
             sql.Append("       a.Apply_amt as Duty_fee, \n");
             sql.Append("       a.ApplyHour_cnt, \n");
             sql.Append("       (SELECT Isnull(Sum(Leave_hours), 0) \n");
             sql.Append("        FROM   FSC_leave_main_mapping \n");
             sql.Append("        WHERE  Leave_type = '32' \n");
             sql.Append("               AND Id_card = c.Id_card \n");
             sql.Append("               AND Orgcode = c.Orgcode \n");
             sql.Append("               AND Apply_dateb = Substring(c.Sche_date, 1, 5)) Leave_hours \n");
             sql.Append("FROM   SAL_DUTY_feeDtl a \n");
             sql.Append("       LEFT JOIN SAL_DUTY_fee b \n");
             sql.Append("              ON a.main_id = b.Id \n");
             sql.Append("       LEFT JOIN FSC_Schedule_setting c \n");
             sql.Append("              ON a.Duty_userId = c.Id_card \n");
             sql.Append("                 AND a.Duty_date = c.Sche_date \n");
             sql.Append("       LEFT JOIN FSC_Schedule d \n");
             sql.Append("              ON c.Schedule_ID = d.Schedule_ID \n");
             sql.Append("WHERE  b.Flow_id = @Flow_id "); 


             SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Flow_id", flow_id)};

            return Query(sql.ToString(), sp);
        }

        public DataTable SelectDutyInfo(string Orgcode, string yyyyMM)
        {
            StringBuilder sql = new StringBuilder();
//            sql.Append("SELECT (SELECT Depart_name \n");
//            sql.Append("        FROM   EMP_ORG \n");
//            sql.Append("        WHERE  Depart_id = b.Depart_id) Depart_name, \n");
            sql.Append("SELECT (SELECT Depart_name \n");
            sql.Append("        FROM   EMP_ORG \n");
            sql.Append("        WHERE  Depart_id = (select case when Parent_depart_id is null then Depart_id else Parent_depart_id end FROM  EMP_ORG where Depart_id= b.Depart_id ) )                        Depart_name, \n");
            sql.Append("       b.Depart_id, \n");
            sql.Append("       a.Id_card, \n");
            sql.Append("       a.User_name, \n");
            sql.Append("       b.Sche_date, \n");
            sql.Append("       c.Start_time, \n");
            sql.Append("       c.End_time, \n");
            sql.Append("       b.Schedule_hours, \n");
            sql.Append("       c.Duty_fee, \n");
            sql.Append("       '' as ApplyHour_cnt, \n");
            sql.Append("       (SELECT Isnull(Sum(Leave_hours), 0) \n");
            sql.Append("        FROM   FSC_leave_main_mapping \n");
            sql.Append("        WHERE  Leave_type = '32' \n");
            sql.Append("               AND Id_card = a.Id_card \n");
            sql.Append("               AND Orgcode = b.Orgcode \n");
            sql.Append("               AND Apply_dateb = Substring(b.Sche_date, 1, 5)) Leave_hours \n");
            sql.Append("FROM   FSC_Personnel a \n");
            sql.Append("       INNER JOIN FSC_Schedule_setting b \n");
            sql.Append("               ON a.Id_card = b.id_card \n");
            sql.Append("       INNER JOIN FSC_Schedule c \n");
            sql.Append("               ON b.Schedule_ID = c.Schedule_ID \n");
            sql.Append("WHERE  a.On_Duty = '1' \n");
            sql.Append("       AND b.Orgcode = @Orgcode \n");
            sql.Append("       AND c.Orgcode = @Orgcode \n");
            sql.Append("       AND Substring(b.Sche_date, 1, 5) = @yyyyMM \n");
            sql.Append("       AND a.Id_card not in ( \n");
            sql.Append("         select b.Duty_userId \n");
            sql.Append("         from SAL_DUTY_fee a inner join SAL_DUTY_feeDtl b on a.Id=b.main_id \n");
            sql.Append("         inner join SYS_Flow c on a.Flow_id=c.Flow_id \n");
            sql.Append("         where a.Apply_ym = @yyyyMM  \n");
            sql.Append("         and c.Case_status in ('0','1','2') \n"); //送出、核準、退回修改中
            sql.Append("       ) \n");
			


            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@yyyyMM", yyyyMM),
                                                     new SqlParameter("@Orgcode", Orgcode)};

            return Query(sql.ToString(), sp);
        }

    }
}