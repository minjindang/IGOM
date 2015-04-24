using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;
/// <summary>
/// Summary description for PRO2101
/// </summary>
/// 
namespace PRO.Logic
{
    public class PRO2101
    {
        private PRO2101DAO dao = null;
        private SACode saCodeDAO = null;
        public PRO_PropertyTran_det pptdDAO = null;

        public PRO2101()
        {
            dao = new PRO2101DAO();
            saCodeDAO = new SACode();
            pptdDAO = new PRO_PropertyTran_det();
        }

        public DataTable Get01All(string FA01_KIND, string FA01_MASTNO, string FA01_CLSNO, string FA01_STOREROOM, string FA01_ACCUSER,
                                        string FA01_BUYDTS, string FA01_BUYDTE, string FA01_AMT, string FA01_SUBDUE, string expire)
        {


            return dao.SelectAll(saCodeDAO.GetCodeDesc("016", "006", FA01_KIND), FA01_MASTNO, FA01_CLSNO, FA01_STOREROOM, FA01_ACCUSER, FA01_BUYDTS, FA01_BUYDTE, FA01_AMT, FA01_SUBDUE, expire);
        }

        public DataTable Get02All(string Property_id, string Property_class)
        {
            DataTable dt = pptdDAO.GetAll(Property_id, Property_class);

            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Index"));
                dt.Columns.Add(new DataColumn("Property_id_class"));

                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Index"] = i++;
                    dr["Property_id_class"] = dr["Property_id"] + "=" + dr["Property_class"];
                }

                dt.AcceptChanges();
            }
           

            return dt;
        }
    }
}