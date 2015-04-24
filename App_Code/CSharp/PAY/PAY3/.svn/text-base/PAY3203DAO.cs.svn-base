using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PAY3203DAO
/// </summary>

namespace PAY.Logic
{
    public class PAY3203DAO: BaseDAO
    {
        public PAY3203DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectvGetEpay(string Receipt_dateS, string Receipt_dateE)
        {
            StringBuilder sql = new StringBuilder();
            //sql.Append(" SELECT * FROM [EPAY].[dbo].vGetEpay where authorizedate between @Receipt_dateS and @Receipt_dateE ");
            sql.Append(" SELECT * FROM [TC-WEB-DB.EPA.GOV.TW].[EPAY].[dbo].vGetEpay where authorizedate between @Receipt_dateS and @Receipt_dateE ");
      SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Receipt_dateS", Receipt_dateS),
                                                     new SqlParameter("@Receipt_dateE", Receipt_dateE)};

            return Query(sql.ToString(), sp);
        }

    }
}