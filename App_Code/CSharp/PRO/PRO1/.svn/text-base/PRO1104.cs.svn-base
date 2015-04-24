using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;

namespace PRO.Logic
{
    public class PRO1104
    {
        private PRO1104DAO dao = null;

        public PRO1104()
        {
            dao = new PRO1104DAO();
        }

        public DataTable getData(string User_id)
        {
            return dao.getData(User_id);
        }
    }
}