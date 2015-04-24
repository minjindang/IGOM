using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace MAI.Logic
{
    /// <summary>
    /// MAI1101DAO 的摘要描述
    /// </summary>
    public class MAI1101DAO : BaseDAO
    {
        public MAI1101DAO()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }

        public DataTable GetDataByExt(String ext)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select id_card, user_name from EMP_member where Ext=@Ext ");
            sb.AppendLine(" union ");
            sb.AppendLine(" select id_card, user_name from EMP_NonMember where Ext=@Ext ");

            SqlParameter param = new SqlParameter("@ext", ext);

            return Query(sb.ToString(), param);
        }

        public DataTable GetExt(String idCard)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select ext from EMP_member where id_card=@idCard ");
            sb.AppendLine(" union ");
            sb.AppendLine(" select ext from EMP_NonMember where id_card=@idCard ");

            SqlParameter param = new SqlParameter("@idCard", idCard);

            return Query(sb.ToString(), param);
        }
    }
}