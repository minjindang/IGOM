using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PAY2104
/// </summary>
namespace PAY.Logic
{
    public class PAY2104
    {
        PAY2104DAO dao = null;

        public PAY2104()
        {
            dao = new PAY2104DAO();
        }

        public DataTable GetReportData(string PettyCash_nosS, string PettyCash_nosE, string Borrow_dateS, string Borrow_dateE,
                                            string Income_dateS, string Income_dateE)
        {
            DataTable dt = dao.SelectReportData(LoginManager.OrgCode, PettyCash_nosS, PettyCash_nosE, Borrow_dateS, Borrow_dateE, Income_dateS, Income_dateE);

            dt.Columns.Add(new DataColumn("Note"));

            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Income_amt"].ToString()) && Convert.ToInt32(dr["Income_amt"]) > 0)
                {
                    dr["Note"] = string.Format("{0}已回收{1}", dr["Income_date"], dr["Income_amt"]);
                } 
            }

            dt.AcceptChanges();

            return dt;
        }
    }
}