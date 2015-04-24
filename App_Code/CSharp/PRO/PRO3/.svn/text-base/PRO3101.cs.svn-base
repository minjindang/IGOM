using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PRO3101
/// </summary>
namespace PRO.Logic
{
    public class PRO3101
    {

        PRO3101DAO dao = null;
        public PRO_SwRegister_main psrmDAO = null;
        SACode saDAO = null;

        public PRO3101()
        {
            dao = new PRO3101DAO();
            psrmDAO = new PRO_SwRegister_main();
            saDAO = new SACode();
        }

        public DataTable GetAll(string OfficialNumber_id, string Software_id, DateTime Last_dateS, DateTime Last_dateE,
                                   string SoftwareUnit_name, string Unit_code, string User_id, string Software_name,
                                   string Fee_amtS, string Fee_amtE, string Fee_amtL, string Fee_amtM, string Orderby)
        {
            DataTable dt = dao.SelectAll(LoginManager.OrgCode, OfficialNumber_id, Software_id, Last_dateS, Last_dateE,
                SoftwareUnit_name, Unit_code, User_id, Software_name, Fee_amtS, Fee_amtE, Fee_amtL, Fee_amtM, Orderby);
            foreach (DataRow dr in dt.Rows)
            {
                dr["Software_type"] = saDAO.GetCodeDesc("016", "004", dr["Software_type"].ToString());
                dr["SoftwareKind_type"] = saDAO.GetCodeDesc("016", "001", dr["SoftwareKind_type"].ToString()); 
            }
            return dao.SelectAll(LoginManager.OrgCode, OfficialNumber_id, Software_id, Last_dateS, Last_dateE,
                SoftwareUnit_name, Unit_code, User_id, Software_name, Fee_amtS, Fee_amtE, Fee_amtL, Fee_amtM, Orderby);
        }
    }
}