using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2104DAO
/// </summary>

namespace PAY.Logic
{
    public class PAY2104DAO : BaseDAO
    {
        public PAY2104DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectReportData(string OrgCode, string PettyCash_nosS, string PettyCash_nosE, string Borrow_dateS, string Borrow_dateE,
                                            string Income_dateS, string Income_dateE)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT a.Prepay_id, \n");
            sql.Append("       a.PettyCash_nos, \n");
            sql.Append("       a.Borrow_date, \n");
            sql.Append("       a.PurchaseAbstract_desc, \n");
            sql.Append("       b.Beneficiary_name, \n");
            sql.Append("       b.User_unit, \n");
            sql.Append("       a.WriteOff_date, \n");
            sql.Append("       a.Income_amt, \n");
            sql.Append("       a.Income_date, \n");
            sql.Append("       ( a.PurchaseTotal_amt - a.Income_amt ) PurchaseTotalSIncome \n");
            sql.Append("FROM   PAY_LendPetty_main a \n");
            sql.Append("       LEFT JOIN dbo.PAY_Beneficiary_data b \n");
            sql.Append("              ON a.Beneficiary_id = b.Beneficiary_id \n");
            sql.Append("WHERE  a.PettyCash_type = '001' AND a.OrgCode=@OrgCode ");

            if (!string.IsNullOrEmpty(PettyCash_nosS))
            {
                sql.Append("  AND a.PettyCash_nos >= @PettyCash_nosS ");
            }

            if (!string.IsNullOrEmpty(PettyCash_nosE))
            {
                sql.Append("  AND a.PettyCash_nos <= @PettyCash_nosE ");
            }

            if (!string.IsNullOrEmpty(Borrow_dateS))
            {
                sql.Append("  AND a.Borrow_date >= @Borrow_dateS ");
            }

            if (!string.IsNullOrEmpty(Borrow_dateE))
            {
                sql.Append("  AND a.Borrow_date <= @Borrow_dateE ");
            }

            if (!string.IsNullOrEmpty(Income_dateS))
            {
                sql.Append("  AND a.Income_date >= @Income_dateS ");
            }

            if (!string.IsNullOrEmpty(Income_dateE))
            {
                sql.Append("  AND a.Income_date <= @Income_dateE ");
            }


            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode), 
                                                     new SqlParameter("@Borrow_dateS", Borrow_dateS),
                                                     new SqlParameter("@Borrow_dateE", Borrow_dateE),
                                                     new SqlParameter("@PettyCash_nosS", PettyCash_nosS),
                                                     new SqlParameter("@PettyCash_nosE", PettyCash_nosE),
                                                     new SqlParameter("@Income_dateS", Income_dateS),
                                                     new SqlParameter("@Income_dateE", Income_dateE)};

            return Query(sql.ToString(), sp);
        }


    }
}