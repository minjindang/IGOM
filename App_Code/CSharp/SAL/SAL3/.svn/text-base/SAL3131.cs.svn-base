using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SALPLM.Logic
{
    public class SAL3131
    {
        private SAL3131DAO DAO;
        public SAL3131()
        {
            // TODO: 在此加入建構函式的程式碼
            DAO = new SAL3131DAO();
        }

        public DataTable getData(string Orgcode, string flow_id)
        {
            return DAO.getData(Orgcode, flow_id);
        }

        public void updateEXAMINE_fee(string id, string BASE_ADDR)
        {
            DAO.updateEXAMINE_fee(id, BASE_ADDR);
        }

        public void UpdateSABASE(string BASE_IDNO, string BASE_NAME, string BASE_SERVICE_PLACE_DESC, string BASE_DCODE_NAME, string BASE_ADDR, string BANK_CODE, string BANK_BANK_NO)
        {
            DAO.UpdateSABASE(BASE_IDNO, BASE_NAME, BASE_SERVICE_PLACE_DESC, BASE_DCODE_NAME, BASE_ADDR, BANK_CODE, BANK_BANK_NO);
        }
    }
}