using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY3203
/// </summary>
namespace PAY.Logic
{
    public class PAY3203
    {
        private PAY3203DAO dao = null;
        private PAY_ExamineIncome_det peidDAO = null;
        private PAY_ExamineIncome_main peimDAO = null;
        private PAY_ExaminePayer_main pepmDAO = null;

        public PAY3203()
        {
            dao = new PAY3203DAO();
            peidDAO = new PAY_ExamineIncome_det();
            peimDAO = new PAY_ExamineIncome_main();
            pepmDAO = new PAY_ExaminePayer_main();
        }

        public string Transfer(string Receipt_dateS, string Receipt_dateE)
        {
            string msg = string.Empty;
            DateTime Receipt_dateDTS = CommonFun.getYYYMMDD(Receipt_dateS);
            DateTime Receipt_dateDTE = CommonFun.getYYYMMDD(Receipt_dateE);
            Receipt_dateS = Receipt_dateDTS.ToString("yyyyMMdd")+"000000";
            Receipt_dateE = Receipt_dateDTE.ToString("yyyyMMdd") + "999999";
            DataTable dt = dao.SelectvGetEpay(Receipt_dateS, Receipt_dateE);
            DataRow dr01 = peimDAO.GetOne("01",LoginManager.OrgCode);
            DataRow dr88 = peimDAO.GetOne("88",LoginManager.OrgCode);
            int LatestReceipt_nos01 = Convert.ToInt32(dr01["LatestReceipt_nos"]);
            int LatestReceipt_nos88 = Convert.ToInt32(dr88["LatestReceipt_nos"]);
            int counter01 = 1;
            int counter88 = 1;
            if (dr01 == null )
            {
                msg += @"環境用藥審查收入類別,請先建立\n";
            }
            if (dr88 == null)
            {
                msg += @"空氣污染物驗證核章費用收入類別,請先建立\n";
            }
            if (string.IsNullOrEmpty(msg))
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string payer_id = string.Empty;
                        string payer_name = string.Empty;
                        DataTable dtPayer = pepmDAO.GetAll("", dr["title"].ToString());
                        if (dtPayer == null || dtPayer.Rows.Count == 0)
                        {
                            dt = pepmDAO.GetAll("","");
                            dt.DefaultView.Sort = "Payer_id desc";
                            dt = dt.DefaultView.ToTable();
                            payer_id = (Convert.ToInt32(dt.Rows[0]["Payer_id"]) + 1).ToString().PadLeft(4, '0');
                            payer_name = dr["title"].ToString();
                            pepmDAO.Add(LoginManager.OrgCode, payer_id, payer_name, LoginManager.UserId, DateTime.Now);
                        }
                        else
                        {
                            payer_id = dtPayer.Rows[0]["Payer_id"].ToString();
                            payer_name = dtPayer.Rows[0]["Payer_name"].ToString();
                        }
                        if (dr["PayType"].ToString().Trim() == "空氣污染物驗證核章費用")
                        {
                            string ReceiptStart_id = (LatestReceipt_nos88 + counter88).ToString().PadLeft(7, '0');
                            DateTime authorizedate = DateTime.ParseExact(dr["authorizedate"].ToString(), "yyyyMMddhhmmss", CultureInfo.InvariantCulture); //Convert.ToDateTime(dr["authorizedate"]);
                            peidDAO.Add(LoginManager.OrgCode, "88", ReceiptStart_id, ReceiptStart_id, CommonFun.getYYYMMDD(authorizedate), payer_id, payer_name,
                                Convert.ToDouble(dr["qty"]), Convert.ToDouble(dr["price"]), Convert.ToDouble(dr["PayMoney"]), "002", "", "", "", "",
                                LoginManager.UserId, DateTime.Now);
                            counter88++;
                        }
                        else
                        {
                            string ReceiptStart_id = (LatestReceipt_nos01 + counter01).ToString().PadLeft(7, '0');
                            peidDAO.Add(LoginManager.OrgCode, "01", ReceiptStart_id, ReceiptStart_id, dr["authorizedate"].ToString(), payer_id, payer_name,
                                Convert.ToDouble(dr["qty"]), Convert.ToDouble(dr["price"]), Convert.ToDouble(dr["PayMoney"]), "002", "", "", "", "",
                                LoginManager.UserId, DateTime.Now);
                            counter01++;
                        }
                    }
                    peimDAO.Modify("01", LoginManager.OrgCode, "", "", "", double.MinValue, (LatestReceipt_nos01 + counter01 -1).ToString(), LoginManager.UserId, DateTime.Now);
                    peimDAO.Modify("88", LoginManager.OrgCode, "", "", "", double.MinValue, (LatestReceipt_nos88 + counter88 -1).ToString(), LoginManager.UserId, DateTime.Now);
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return msg;
        }
    }
}