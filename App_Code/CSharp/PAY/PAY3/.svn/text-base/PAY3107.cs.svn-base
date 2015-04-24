using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY3107
/// </summary>

namespace PAY.Logic
{
    public class PAY3107
    {
        private PAY3107DAO dao = null;
        private PAY_PettyReturn_main PPRDao = null;
        public  PAY3103 pay3103 = null;

        public PAY3107()
        {
            dao = new PAY3107DAO();
            PPRDao = new PAY_PettyReturn_main();
            pay3103 = new PAY3103();
        }

        public DataTable GetPettyList()
        {
            return dao.SelectPettyList(LoginManager.OrgCode);
        }

        public string GetYearInitial_amt()
        {
            DataTable dt = PPRDao.GetAll((DateTime.Now.Year - 1911).ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["YearInitial_amt"].ToString();
            }
            return "";
        }

        public string Done(string FiscalYear_id, string Receive_date, int BroughtForward_amt, int YearInitial_amt, int Balances_amt,ref DataTable dt)
        {
            string msg = string.Empty;
            try
            {
                //Balances_amt = BroughtForward_amt + Convert.ToInt32(dt.Compute("Sum(Convert(Income_amt, 'System.Int32'))", ""));

                if (dt == null || dt.Rows.Count <= 0)
                {
                    PPRDao.Add(LoginManager.OrgCode, FiscalYear_id, Receive_date, "", YearInitial_amt,
                                BroughtForward_amt, Balances_amt, "", 0, "", LoginManager.UserId, DateTime.Now);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PPRDao.Add(LoginManager.OrgCode, FiscalYear_id, Receive_date, dr["PettyCashInventory_id"].ToString(), YearInitial_amt,
                            BroughtForward_amt, Balances_amt, dr["PaymentVoucher_id"].ToString(), Convert.ToInt32(dr["Income_amt"]),
                            dr["Memo"].ToString(), LoginManager.UserId, DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}