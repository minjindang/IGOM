using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1106DAO
/// </summary>

namespace SAL.Logic
{
    public class SAL1106DAO :BaseDAO
    {
        public SAL1106DAO()
            :base(ConnectDB.GetDBString())
        {
             
        }

        public DataTable SelectLeaveType(string OrgCode, string Depart_id, string Id_card, string Start_date, string End_date)
        {
            StringBuilder  Sql = new StringBuilder();
            Sql.Append("SELECT (SELECT Count(*) \n");
            Sql.Append("        FROM   FSC_leave_main \n");
            Sql.Append("        WHERE  Start_date >= @Start_date \n");
            Sql.Append("               AND End_date <= @End_date \n");
            Sql.Append("               AND Id_card = @Id_card \n");
            Sql.Append("               AND Depart_id = @Depart_id \n");
            Sql.Append("               AND OrgCode = @OrgCode) LeaveType1, \n");
            Sql.Append("       (SELECT Count(*) \n");
            Sql.Append("        FROM   FSC_leave_main \n");
            Sql.Append("        WHERE  Start_date >= @Start_date \n");
            Sql.Append("               AND End_date <= @End_date \n");
            Sql.Append("               AND Location_flag = '0' \n");
            Sql.Append("               AND Inter_travel_flag <> '1' \n");
            Sql.Append("               AND Id_card = @Id_card \n");
            Sql.Append("               AND Depart_id = @Depart_id \n");
            Sql.Append("               AND OrgCode = @OrgCode) LeaveType2, \n");
            Sql.Append("       (SELECT Count(*) \n");
            Sql.Append("        FROM   FSC_leave_main \n");
            Sql.Append("        WHERE  Start_date >= @Start_date \n");
            Sql.Append("               AND End_date <= @End_date \n");
            Sql.Append("               AND Location_flag = '0' \n");
            Sql.Append("               AND Inter_travel_flag = '1' \n");
            Sql.Append("               AND Id_card = @Id_card \n");
            Sql.Append("               AND Depart_id = @Depart_id \n");
            Sql.Append("               AND OrgCode = @OrgCode) LeaveType3, \n");
            Sql.Append("       (SELECT Count(*) \n");
            Sql.Append("        FROM   FSC_leave_main \n");
            Sql.Append("        WHERE  Start_date >= @Start_date \n");
            Sql.Append("               AND End_date <= @End_date \n");
            Sql.Append("               AND Location_flag = '0' \n");
            Sql.Append("               AND Inter_travel_flag <> '1' \n");
            Sql.Append("               AND Id_card = @Id_card \n");
            Sql.Append("               AND Depart_id = @Depart_id \n");
            Sql.Append("               AND OrgCode = @OrgCode) LeaveType4 ");

             SqlParameter[] sp = { 
		        new SqlParameter("@OrgCode", OrgCode),
		        new SqlParameter("@Depart_id", Depart_id),
		        new SqlParameter("@Id_card", Id_card),
		        new SqlParameter("@End_date", End_date),
		        new SqlParameter("@Start_date", Start_date)
	        };

            return Query(Sql.ToString(),sp);
    
        }

        public object GetLeaveType(string Id_card, string sDate, string eDate,string eTime, int type)
        {
            StringBuilder Sql = new StringBuilder();

            Sql.AppendLine(" SELECT ISNULL(SUM(leave_hours),0) ");
            Sql.AppendLine(" FROM FSC_leave_main a INNER JOIN FSC_CPAPO15M b on a.flow_id=b.POGUID ");
            Sql.AppendLine(" where a.Leave_type='03' and b.POVDATEB >= @sDate ");//系統年初
            //Sql.AppendLine(" AND b.POVDATEE <= @eDate ");//不可大於系統日    'hsien 20140703 先不要限制
            //Sql.AppendLine(" AND b.POVTIMEE <@eTime ");// 小於系統時間
            Sql.AppendLine(" AND a.Id_card=@Id_card ");

            // 國內(一般)天數
            if (type == 2)
            {
                Sql.AppendLine(" AND a.Location_flag = '0'  ");// 地點註記-國內
                Sql.AppendLine(" AND (a.Inter_travel_flag <> '1' or a.Inter_travel_flag is null ) ");// 不是用國旅卡
            }

            // 國內(刷卡)天數
            if (type == 3)
            {
                Sql.AppendLine(" AND a.Location_flag = '0'  ");// 地點註記-國內
                Sql.AppendLine(" AND a.Inter_travel_flag = '1' ");// 是用國旅卡
            }

            // 國外天數
            if (type == 4)
            {
                Sql.AppendLine(" AND a.Location_flag = '1'  ");// 地點註記-國外
            }

            SqlParameter[] sp = { 
		        new SqlParameter("@Id_card", Id_card),
                new SqlParameter("@sDate", sDate),
		        new SqlParameter("@eDate", eDate),
		        new SqlParameter("@eTime", eTime)
	        };

            return Scalar(Sql.ToString(), sp);
        }

        public DataTable GetDayaByOrgFid(string orgcode, string flowId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * from FSC_Settlement_Annual where orgcode=@orgcode and flow_id=@flowId ");
            
            SqlParameter[] sp = { 
		        new SqlParameter("@orgcode", orgcode),
		        new SqlParameter("@flowId", flowId)
	        };

            return Query(sql.ToString(), sp);
        }

        public DataTable getPersonnel(string id_card, string id_card2, string User_name)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * from fSC_Personnel ");
            sql.AppendLine(" where 1=1 ");

            if (!string.IsNullOrEmpty(id_card))
                sql.AppendLine(" and id_card=@id_card ");
            if (!string.IsNullOrEmpty(id_card2))
                sql.AppendLine(" and id_card=@id_card2 ");
            if (!string.IsNullOrEmpty(User_name))
                sql.AppendLine(" and User_name like @User_name ");

            SqlParameter[] sp = { 
		        new SqlParameter("@id_card", id_card),
		        new SqlParameter("@id_card2", id_card2),
		        new SqlParameter("@User_name", "%" + User_name + "%")
	        };

            return Query(sql.ToString(), sp);
        }
    }
}