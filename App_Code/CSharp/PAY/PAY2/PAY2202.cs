using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2202
/// </summary>
namespace PAY.Logic
{
    public class PAY2202
    {
        private PAY2202DAO dao = null;
        public PAY_ExamineIncome_main pemDAO = null;

        public PAY2202()
        {
            dao = new PAY2202DAO();
            pemDAO = new PAY_ExamineIncome_main();
        }

        public DataTable GetReportDataPrintType1(string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            return dao.SelectReportDataPrintType1(LoginManager.OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

        public DataTable GetReportDataPrintType2(string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            return dao.SelectReportDataPrintType2(LoginManager.OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

        public DataTable GetReportDataPrintType3(string Receipt_dateS, string Receipt_dateE,
                                            string PayMode_type, string ExamineIncome_type, string Payer_id)
        {
            return dao.SelectReportDataPrintType3(LoginManager.OrgCode, Receipt_dateS, Receipt_dateE, PayMode_type, ExamineIncome_type, Payer_id);
        }

    }
}