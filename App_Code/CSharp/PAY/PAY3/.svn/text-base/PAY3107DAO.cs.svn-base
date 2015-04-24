using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY3107DAO
/// </summary>
namespace PAY.Logic
{
    public class PAY3107DAO : BaseDAO
    {
        public PAY3107DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectPettyList(string OrgCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT distinct \n");
            sql.Append("       a.PCList_id as PettyCashInventory_id, \n");
            sql.Append("       a.PaymentVoucher_id, \n");
            sql.Append("       a.PayBalances_amt \n");
            sql.Append("FROM   PAY_PettyList_main a \n");
            sql.Append("       INNER JOIN PAY_LendPetty_main b \n");
            sql.Append("               ON a.FiscalYear_id=b.FiscalYear_id and a.PCList_id = b.PCList_id \n");
            sql.Append("WHERE  b.WriteOff_date <> '' \n");
            sql.Append("       AND a.PCList_id NOT IN (SELECT isnull(PettyCashInventory_id,'') \n");
            sql.Append("                               FROM   PAY_PettyReturn_main) \n");
            sql.Append("       AND a.OrgCode = @OrgCode ");


            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode)};

            return Query(sql.ToString(), sp);
        }
    }
}