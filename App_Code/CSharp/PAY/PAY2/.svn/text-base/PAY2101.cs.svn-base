using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2101
/// </summary>
namespace PAY.Logic
{
    public class PAY2101
    {
        private PAY2101DAO dao = null;
        public PAY_PettyList_main pplmDAO = null;

        public PAY2101()
        {
            dao = new PAY2101DAO();
            pplmDAO = new PAY_PettyList_main();
        }



        public DataTable GetReportData(string FiscalYear_id, string PCList_idS, string PCList_idE)
        {
            DataTable dt = dao.SelectReportData(LoginManager.OrgCode, FiscalYear_id,PCList_idS, PCList_idE);
 

            return dt;
        }

        public DataTable GetReportData2(string FiscalYear_id, string PCList_idS, string PCList_idE)
        {
            DataTable dt = dao.SelectReportData2(LoginManager.OrgCode, FiscalYear_id, PCList_idS, PCList_idE);
            double LastBalances_amt = 0;
            DataTable newDt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow cDr = newDt.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    cDr[dc.ColumnName] = dr[dc.ColumnName];
                }
                if (cDr["indexId"].ToString() == "1")
                {
                    cDr["Borrow_date"] = CommonFun.getYYYMMDD(DateTime.ParseExact(dr["Borrow_date"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture));
                    LastBalances_amt = Convert.ToDouble(dr["LastBalances_amt"]); 
                }
                else
                {
                    if (!string.IsNullOrEmpty(dr["Income_amt"].ToString()) && !string.IsNullOrEmpty(dr["PurchaseTotal_amt"].ToString())
                        && Convert.ToDouble(dr["Income_amt"].ToString()) > 0 && Convert.ToDouble(dr["PurchaseTotal_amt"].ToString()) > 0)
                    {
                        if (cDr["PettyCash_type"] == "001")
                        {
                            cDr["PettyCash_nos"] = "*" + dr["PettyCash_nos"];
                        }
                        else
                        {
                            cDr["PettyCash_nos"] = dr["PettyCash_nos"];
                        }
                        DataRow newDR = newDt.NewRow();
                        newDR["SerialNumber_id"] = dr["SerialNumber_id"];
                        newDR["PettyCash_type"] = dr["PettyCash_type"];
                        newDR["PCList_id"] = dr["PCList_id"];
                        newDR["FiscalYear_id"] = dr["FiscalYear_id"];
                        newDR["PettyCash_nos"] = dr["PettyCash_nos"];
                        newDR["Prepay_id"] = dr["Prepay_id"];
                        newDR["Borrow_date"] = dr["Borrow_date"];
                        newDR["PurchaseForm_id"] = dr["PurchaseForm_id"];
                        newDR["PurchaseAbstract_desc"] = string.Format("收回零用金{0}元", dr["Income_amt"]);
                        newDR["Beneficiary_name"] = "";
                        newDR["Income_amt"] = dr["Income_amt"];
                        newDR["PurchaseTotal_amt"] = 0;
                        newDR["LastBalances_amt"] = LastBalances_amt += Convert.ToDouble(dr["Income_amt"]);
                        newDR["groupid"] = dr["groupid"];
                        newDR["indexId"] = "2";
                        newDt.Rows.Add(newDR);

                        cDr["Income_amt"] = 0;
                        cDr["LastBalances_amt"] = LastBalances_amt -= Convert.ToDouble(dr["PurchaseTotal_amt"]);

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dr["Income_amt"].ToString()) && Convert.ToDouble(dr["Income_amt"].ToString()) > 0)
                        {
                            cDr["PurchaseAbstract_desc"] = string.Format("收回零用金{0}元", dr["Income_amt"]);
                            cDr["LastBalances_amt"] = LastBalances_amt += Convert.ToDouble(dr["Income_amt"]);
                        }else{
                            cDr["LastBalances_amt"] = LastBalances_amt -= Convert.ToDouble(dr["PurchaseTotal_amt"]);
                        }
                    }
                }
                newDt.Rows.Add(cDr);
            }
           // dt.DefaultView.Sort = "PCList_id,groupid,indexId,SerialNumber_id";
           // dt = dt.DefaultView.ToTable();

            return newDt;
        }


    }
}