using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMP3110 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMP3110
    {

        private EMP3110DAO DAO;
        public EMP3110() 
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMP3110DAO();
        }

        public EMP3110(SqlConnection conn)
        {
            DAO = new EMP3110DAO(conn);
        }


        public DataTable querysearch(
        string strAP_IP,
        string strAP_name,
        string strWS_type,
        string strAP_code,
        string strUcDate1,
        string strUcDate2,
        string strIs_disable,
        string strPurpose,
        string strNote_desc)
        {
            DataTable dt = DAO.querysearch(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate1, strUcDate2, strIs_disable, strPurpose
                                         , strNote_desc);
            return dt;
        }


        public void queryadd(
        string strAP_IP,
        string strAP_name,
        string strWS_type,
        string strAP_code,
        string strUcDate3,
        string strUcDate4,
        string strIs_disable,
        string strPurpose,
        string strNote_desc,
            string UserId
            )
        {
            DAO.queryadd(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate3, strUcDate4, strIs_disable, strPurpose
                                         , strNote_desc, UserId);
        }


        public void querydelete(
           string id
            )
        {
            DAO.querydelete(id);
        }

        public void queryedit(
        string strAP_IP,
        string strAP_name,
        string strWS_type,
        string strAP_code,
        string strUcDate3,
        string strUcDate4,
        string strIs_disable,
        string strPurpose,
        string strNote_desc,
        string UserId,
        string edit_id //key
        )
        {
            DAO.queryedit(strAP_IP, strAP_name, strWS_type, strAP_code, strUcDate3, strUcDate4, strIs_disable, strPurpose
                                         , strNote_desc, UserId, edit_id);
        }

    

    }
}