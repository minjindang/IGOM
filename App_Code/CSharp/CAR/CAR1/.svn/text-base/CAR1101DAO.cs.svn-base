using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CAR1101DAO
/// </summary>

namespace CAR.Logic
{
    public class CAR1101DAO: BaseDAO
    {
        public CAR1101DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectDataByOrgFid(string Orgcode, string flow_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select   f.* ");
           
            sql.AppendLine(" from CAR_CarDispatch_main f ");
           
            sql.AppendLine(" where f.Orgcode=@Orgcode and f.flow_id=@flow_id ");

            SqlParameter[] sp = { 
		        new SqlParameter("@Orgcode", Orgcode),
                new SqlParameter("@flow_id", flow_id)
	        };

            return Query(sql.ToString(), sp);
        }
    }
}