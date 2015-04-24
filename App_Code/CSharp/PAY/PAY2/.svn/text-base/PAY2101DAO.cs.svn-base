using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PAY2101DAO
/// </summary>

namespace PAY.Logic
{
    public class PAY2101DAO: BaseDAO
    {
        public PAY2101DAO()
            : base(ConnectDB.GetDBString())
        {
            
        }

        public DataTable SelectReportData(string OrgCode, string FiscalYear_id, string PCList_idS, string PCList_idE)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ( Ltrim(Rtrim(Isnull(b.PoPln+b.PoSub+b.PoFor, ''))) ");
            sql.AppendLine("         + '<br />' ");
            sql.AppendLine("         + Ltrim(Rtrim(Isnull(b.SubName+b.ForName, ''))) ");
            sql.AppendLine("         + '<br />' ");
            sql.AppendLine("         + (SELECT CODE_DESC1 ");
            sql.AppendLine("            FROM   sys_code ");
            sql.AppendLine("            WHERE  code_desc2 = Use_type ");
            sql.AppendLine("                   AND code_sys = '018' ");
            sql.AppendLine("                   AND code_type = '004') )    Col1, ");
            sql.AppendLine("       ( a.Prepay_id + '<br />' + a.PurchaseForm_id + '<br />' ");
            sql.AppendLine("         + Use_type )                          Col2, ");
            sql.AppendLine("       ( a.PurchaseAbstract_desc + '<br />' ");
            sql.AppendLine("         + Ltrim(Rtrim(Isnull(b.PoPln, ''))) ) Col3, ");
            sql.AppendLine("       a.Use_type, ");
            sql.AppendLine("       a.Receipt_cnt, ");
            sql.AppendLine("       ( a.PurchaseTotal_amt - a.Income_amt )      PurchaseTotalSIncome, ");
            sql.AppendLine("       a.PCList_id, ");
            sql.AppendLine("       DENSE_RANK() over (order by a.PCList_id,a.FiscalYear_id) P3, ");
            sql.AppendLine("       cast(c.LastBalances_amt as varchar) LastBalances_amt, ");
            sql.AppendLine("       cast(c.PayBalances_amt as varchar) PayBalances_amt, ");
            sql.AppendLine("       cast(c.CurrentBalances_amt as varchar) CurrentBalances_amt, ");
            sql.AppendLine("       cast(d.Income_amt as varchar) Income_amt "); 
            sql.AppendLine("FROM   dbo.PAY_LendPetty_main a ");
            sql.AppendLine("       LEFT JOIN VW_IGSS_PO b ");
            sql.AppendLine("              ON a.FiscalYear_id + a.PurchaseForm_id + a.PurchaseForm_sn = b.PoYear + b.PoNo + b. PoNoSn ");
            sql.AppendLine("      left join PAY_PettyList_main c on a.PCList_id = c.PCList_id and a.OrgCode = c.OrgCode and a.FiscalYear_id = c.FiscalYear_id  ");
            sql.AppendLine("      left join PAY_PettyReturn_main d on a.OrgCode = d.OrgCode and a.FiscalYear_id = d.FiscalYear_id  ");
            sql.AppendLine("       WHERE a.OrgCode=@OrgCode ");

            if (!string.IsNullOrEmpty(FiscalYear_id))
            {
                sql.AppendLine("  AND a.FiscalYear_id = @FiscalYear_id ");
            }


            if (!string.IsNullOrEmpty(PCList_idS))
            {
                sql.AppendLine("  AND a.PCList_id >= @PCList_idS ");
            }

            if (!string.IsNullOrEmpty(PCList_idE))
            {
                sql.AppendLine("  AND a.PCList_id <= @PCList_idE ");
            }

            sql.AppendLine("  ORDER BY a.PettyCash_type,a.PettyCash_nos ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode), 
                                                     new SqlParameter("@FiscalYear_id", FiscalYear_id), 
                                                     new SqlParameter("@PCList_idS", PCList_idS),
                                                     new SqlParameter("@PCList_idE", PCList_idE)};

            return Query(sql.ToString(), sp);
        }

        public DataTable SelectReportData2(string OrgCode, string FiscalYear_id, string PCList_idS, string PCList_idE)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT x.*,DENSE_RANK() over (order by x.PCList_id,x.FiscalYear_id)   groupid ");
            sql.AppendLine("FROM   (SELECT a.SerialNumber_id,a.PettyCash_type,a.PCList_id, ");
            sql.AppendLine("               a.FiscalYear_id, ");
            sql.AppendLine("               a.PettyCash_nos, ");
            sql.AppendLine("               a.Prepay_id, ");
            sql.AppendLine("               CASE WHEN A.PettyCash_type='001' THEN a.Borrow_date ELSE a.WriteOff_date END Borrow_date, ");
            sql.AppendLine("               a.PurchaseForm_id, ");
            sql.AppendLine("               a.PurchaseAbstract_desc, ");
            sql.AppendLine("               b.Beneficiary_name, ");
            sql.AppendLine("               a.Income_amt, ");
            sql.AppendLine("               a.PurchaseTotal_amt, ");
            sql.AppendLine("               0                                          LastBalances_amt, "); 
            sql.AppendLine("               2                                          indexId ");
            sql.AppendLine("        FROM   PAY_LendPetty_main a ");
            sql.AppendLine("               LEFT JOIN PAY_Beneficiary_data b ");
            sql.AppendLine("                      ON a.Beneficiary_id = b.Beneficiary_id ");
            sql.AppendLine("       ");
            sql.AppendLine("        UNION ");
            sql.AppendLine("        SELECT 0,a.PettyCash_type,a.PCList_id, ");
            sql.AppendLine("               a.FiscalYear_id, ");
            sql.AppendLine("               '上期結存', ");
            sql.AppendLine("               '', ");
            sql.AppendLine("               CONVERT(VARCHAR, Mod_date, 111), ");
            sql.AppendLine("               '', ");
            sql.AppendLine("               '上次結餘', ");
            sql.AppendLine("               '', ");
            sql.AppendLine("               0, ");
            sql.AppendLine("               0, ");
            sql.AppendLine("               LastBalances_amt, "); 
            sql.AppendLine("               1 indexId ");
            sql.AppendLine("        FROM   PAY_PettyList_main a ");
            sql.AppendLine("         ) x WHERE 1=1 ");
         


            if (!string.IsNullOrEmpty(FiscalYear_id))
            {
                sql.AppendLine("  AND x.FiscalYear_id = @FiscalYear_id ");
            }

            if (!string.IsNullOrEmpty(PCList_idS))
            {
                sql.AppendLine("  AND x.PCList_id >= @PCList_idS ");
            }

            if (!string.IsNullOrEmpty(PCList_idE))
            {
                sql.AppendLine("  AND x.PCList_id <= @PCList_idE ");
            }

            sql.AppendLine(" ORDER  BY x.PCList_id, ");
            sql.AppendLine("          x.groupid, ");
            sql.AppendLine("          x.indexId ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OrgCode", OrgCode), 
                                                     new SqlParameter("@FiscalYear_id", FiscalYear_id), 
                                                     new SqlParameter("@PCList_idS", PCList_idS),
                                                     new SqlParameter("@PCList_idE", PCList_idE)};

            return Query(sql.ToString(), sp);
        }
    }
}