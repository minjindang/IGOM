using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// EMPCommon 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMPCommon
    {
        public EMPCommon()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public static string getOrgName(string strOrgCode)
        {
            EMPCommonDAO DAO=new EMPCommonDAO();
            return DAO.getOrgName(strOrgCode);
        }


        public DataTable getApplica(string AD_id)
        {
            EMPCommonDAO DAO = new EMPCommonDAO();
            return DAO.getApplica(AD_id);
        }
    }
}