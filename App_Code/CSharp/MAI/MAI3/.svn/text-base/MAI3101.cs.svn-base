using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace MAI.Logic
{
    /// <summary>
    /// MAI3101 的摘要描述
    /// </summary>
    public class MAI3101
    {
        private MAI3101DAO DAO;

        public MAI3101()
        {
            DAO = new MAI3101DAO();
        }

        public DataTable GetDataByQuery(String orgcode, ArrayList maintainKinds, String applyDateS, String applyDateE, String applyExt, String applyIdcard, String applyDepartid)
        {
            return DAO.GetDataByQuery(orgcode, maintainKinds, applyDateS, applyDateE, applyExt, applyIdcard, applyDepartid);
        }
    }

}