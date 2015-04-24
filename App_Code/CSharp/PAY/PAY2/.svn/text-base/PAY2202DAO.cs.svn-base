using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2202DAO
/// </summary>
namespace PAY.Logic
{
    public class PAY2202DAO : BaseDAO
    {
        public PAY2202DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectReportDataPrintType1(string OrgCode, string Receipt_dateS, string Receipt_dateE, 
                                            string PayMode_type,string ExamineIncome_type,string Payer_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("       Substring(a.Receipt_date, 1, 3)     [Year], \n");
            sql.Append("       Substring(a.Receipt_date, 4, 2)     [Month], \n");
            sql.Append("       Substring(a.Receipt_date, 6, 2)     [Day], \n");
            sql.Append("       a.Payer_name, \n");
            sql.Append("       ''                                  T1, \n");
            sql.Append("       ''                                  T2, \n");
            sql.Append("       ''                                  T3, \n");
            sql.Append("       ''                                  T4, \n");
            sql.Append("       ''                                  T5, \n");
            sql.Append("       ( a.Examine_cnt * a.UnitPrice_amt ) T6 \n");
            return SelectReportDataPrintType(sql.ToString(), OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

        public DataTable SelectReportDataPrintType2(string OrgCode, string Receipt_dateS, string Receipt_dateE,
                                           string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   ROW_NUMBER() OVER(order by a.Payer_id) AS [Index], \n");
            sql.Append("   a.Receipt_date, \n");
            sql.Append("   case when ISNULL(Examine_cnt,0) > 1 then a.ReceiptStart_id + '~' + a.ReceiptEnd_id else ReceiptStart_id end Recript_id , \n");
            sql.Append("   a.Examine_cnt, \n");
            sql.Append("   a.TotalPrice_amt, \n");
            sql.Append("   a.Payer_name \n");
            return SelectReportDataPrintType(sql.ToString(), OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

        public DataTable SelectReportDataPrintType3(string OrgCode, string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("       a.Payer_id, \n");
            sql.Append("       a.Payer_name \n");
            return SelectReportDataPrintType(sql.ToString(), OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

        public DataTable SelectReportDataPrintType(string columsSQL,string OrgCode, string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append(columsSQL);
            sql.Append(" FROM   PAY_ExamineIncome_det a \n");
            sql.Append("       LEFT JOIN PAY_ExamineIncome_main b \n");
            sql.Append("              ON a.OrgCode = b.OrgCode \n");
            sql.Append("                 AND a.ExamineIncome_type = b.ExamineIncome_type \n");
            sql.Append("WHERE  a.OrgCode = @OrgCode ");


            if (!string.IsNullOrEmpty(Receipt_dateS))
            {
                sql.Append(" AND  a.Receipt_date >= @Receipt_dateS ");
            }
            if (!string.IsNullOrEmpty(Receipt_dateE))
            {
                sql.Append(" AND  a.Receipt_date <= @Receipt_dateE ");
            }

            if (!string.IsNullOrEmpty(PayMode_type))
            {
                sql.Append(" AND  a.PayMode_type = @PayMode_type ");
            }
            if (!string.IsNullOrEmpty(ExamineIncome_type))
            {
                if ("12-20" == ExamineIncome_type)
                    sql.Append(" AND  b.ExamineIncome_type BETWEEN '12' AND '20' ");
                else
                    sql.Append(" AND  b.ExamineIncome_type = @ExamineIncome_type ");
            }
            if (!string.IsNullOrEmpty(Payer_id))
            {
                sql.Append(" AND  a.Payer_id = @Payer_id ");
            }

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode), 
                                                     new SqlParameter("@Receipt_dateS", Receipt_dateS),
                                                     new SqlParameter("@Receipt_dateE", Receipt_dateE),
                                                     new SqlParameter("@PayMode_type", PayMode_type),
                                                     new SqlParameter("@ExamineIncome_type", ExamineIncome_type),
                                                     new SqlParameter("@Payer_id", Payer_id)};

            return Query(sql.ToString(), sp);
        }
    }
}