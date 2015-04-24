using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for Car2102
/// </summary>
namespace CAR.Logic
{
    public class Car2102
    { 

        private Car2102DAO dao = null;
        public SACode saCode = null;

        public Car2102()
        {
            dao = new Car2102DAO();
            saCode = new SACode();
            
        }

        public DataTable GetReportData(string reportType, string dateS, string dateE)
        {
            DataTable dt; 
            if (reportType == "0")
            {
                dt = dao.SelectReportDataGroupByCar(LoginManager.OrgCode, dateS, dateE);
            }
            else
            {
                dt = dao.SelectReportDataGroupByDepart(LoginManager.OrgCode, dateS, dateE);
            }

            //dt.Columns.Add(new DataColumn("Usage"));

            //int pareamter = Convert.ToInt16(saCode.GetData("015", "010").Rows[0]["CODE_NO"]);
            //double days = (CommonFun.getYYYMMDD(dateE) - CommonFun.getYYYMMDD(dateS)).TotalDays;

            //foreach (DataRow dr in dt.Rows)
            //{
            //    dr["Usage"] = Convert.ToDouble(dr["Hours"]) / pareamter * days;
            //}
            //dt.AcceptChanges();

            return dt;
        }

        public DataTable CardList(string OrgCode, string carID,string sdate,string edate)
        {
            DataTable dt = dao.CardList(LoginManager.OrgCode, carID,sdate, edate);

            return dt;
        }

    }
}