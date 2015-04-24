using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2201DAO
/// </summary>

namespace PAY.Logic
{
    public class PAY2201DAO : BaseDAO
    {
        public PAY2201DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectReportData(string OrgCode,string Receipt_dateS, string Receipt_dateE, string PayMode_type, string Order)
        {
            StringBuilder  sql = new StringBuilder();
            sql.Append("SELECT b.ExamineIncome_name, \n");
            sql.Append("       a.ReceiptStart_id, \n");
            sql.Append("       a.ReceiptEnd_id, \n");
            sql.Append("       b.PaymentCode, \n");
            sql.Append("       a.Examine_cnt, \n");
            sql.Append("       a.UnitPrice_amt, \n");
            sql.Append("       ( a.Examine_cnt * a.UnitPrice_amt ) Total, \n");
            sql.Append("       ''                                  Note \n");
            sql.Append("FROM   PAY_ExamineIncome_det a \n");
            sql.Append("       LEFT JOIN PAY_ExamineIncome_main b \n");
            sql.Append("              ON a.OrgCode = b.OrgCode \n");
            sql.Append("                 AND a.ExamineIncome_type = b.ExamineIncome_type \n");
            sql.Append("WHERE  a.OrgCode = @OrgCode ");

            if (!string.IsNullOrEmpty(Receipt_dateS ))
            {
                sql.Append(" AND  a.Receipt_date >= @Receipt_dateS ");
            }
            if (!string.IsNullOrEmpty(Receipt_dateE))
            {
                sql.Append(" AND  a.Receipt_date <= @Receipt_dateE ");
            }

            if ("PaymentCode" == Order)
            {
                sql.Append(" ORDER BY b.PaymentCode ");
            }
            else
            {
                sql.Append(" ORDER BY b.ExamineIncome_name ");
            }

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode), 
                                                     new SqlParameter("@Receipt_dateS", Receipt_dateS),
                                                     new SqlParameter("@Receipt_dateE", Receipt_dateE),
                                                     new SqlParameter("@PayMode_type", PayMode_type)};

            return Query(sql.ToString(), sp);
        }

    }
}