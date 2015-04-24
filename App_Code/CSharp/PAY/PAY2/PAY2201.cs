using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PAY2201
/// </summary>
/// 

namespace PAY.Logic
{
    public class PAY2201
    {
        private PAY2201DAO dao = null;

        public PAY2201()
        {
            dao = new PAY2201DAO();
        }

        public DataTable GetReportData(string Receipt_dateS, string Receipt_dateE, string PayMode_type, string Order)
        {
            return dao.SelectReportData(LoginManager.OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, Order);
        }
    }
}