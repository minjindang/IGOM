using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;
/// <summary>
/// Summary description for PAY2103
/// </summary>

namespace PAY.Logic
{
    public class PAY2103
    {
        private PAY2201DAO dao = null;
        private PAY_Beneficiary_data beneficiarykDAO = null;
        private PAY_Bank_data bankDAO = null;

        public PAY2103()
        {
            beneficiarykDAO = new PAY_Beneficiary_data();
            bankDAO = new PAY_Bank_data();
        }

        public DataTable GetReportData(string Bank_id, string Beneficiary_name)
        {
            DataTable dt = beneficiarykDAO.GetAll(LoginManager.OrgCode, "", Beneficiary_name, Bank_id, "N", "");
            dt.Columns.Add(new DataColumn("Bank_name"));
            foreach (DataRow dr in dt.Rows)
            {
                DataRow bankRow = bankDAO.GetOne(dr["Bank_id"].ToString(), LoginManager.OrgCode);
                if (bankRow != null)
                {
                    dr["Bank_name"] = bankRow["Bank_name"];
                }
                else
                {
                    dr["Bank_name"] = "";
                }
            }
            dt.AcceptChanges();
            return dt;
        }
    }
}