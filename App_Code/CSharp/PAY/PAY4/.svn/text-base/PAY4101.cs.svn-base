using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY4101
/// </summary>
namespace PAY.Logic
{
    public class PAY4101
    {
        public PAY_ExamineIncome_main peimDAO = null;

        public PAY4101()
        {
            peimDAO = new PAY_ExamineIncome_main();
          
        }

        public string Add(string ExamineIncome_type,string ExamineIncome_name,string PaymentCode,string Unit,int UnitPrice_amt,string LatestReceipt_nos)
        {
            string msg = string.Empty;
            try
            {
                DataTable dt = GetAll(ExamineIncome_type, ref msg);
                if (dt != null && dt.Rows.Count > 0 )
                {
                    dt.DefaultView.Sort = "ExamineIncome_type desc";
                    dt = dt.DefaultView.ToTable();
                    msg = string.Format("審查收入類別重複，請重新給號(可用代號:{0})。", (Convert.ToInt32(dt.Rows[0]["ExamineIncome_type"]) + 1).ToString().PadLeft(2, '0'));
                }
                else
                {
                    peimDAO.Add(LoginManager.OrgCode, ExamineIncome_type, ExamineIncome_name, PaymentCode, Unit, UnitPrice_amt, LatestReceipt_nos, LoginManager.UserId, DateTime.Now);
                }
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string Modify(string ExamineIncome_type, string ExamineIncome_name, string PaymentCode, string Unit, int UnitPrice_amt, string LatestReceipt_nos)
        {
            string msg = string.Empty;
            try
            {
                peimDAO.Modify(LoginManager.OrgCode, ExamineIncome_type, ExamineIncome_name, PaymentCode, Unit, UnitPrice_amt, LatestReceipt_nos, LoginManager.UserId, DateTime.Now);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string Remove(string ExamineIncome_type)
        {
            string msg = string.Empty;
            try
            {
                peimDAO.Remove(ExamineIncome_type,LoginManager.OrgCode);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public DataRow GetOne(string ExamineIncome_type, ref string msg)
        {
            if (string.IsNullOrEmpty(ExamineIncome_type))
            {
                msg = "請輸入審查收入類別";
            }
            DataTable dt = GetAll(ExamineIncome_type,ref msg);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return null;
            } 
        }

        public DataTable GetAll(string ExamineIncome_type,ref string msg)
        {
            DataTable dt = null;
            try
            {
                dt = peimDAO.GetAll(ExamineIncome_type,false);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            } 
            return dt;
        }

    }
}