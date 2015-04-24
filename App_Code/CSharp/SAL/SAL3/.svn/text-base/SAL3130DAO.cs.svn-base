using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// SAL3118DAO 的摘要描述
/// </summary>
public class SAL3130DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3130DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }


    public DataTable GetQueryData(String orgcode, String departId, String idCard, String sendStatus)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendLine(" select a.*, b.Depart_name, ");
        sql.AppendLine("    (select code_desc1 from sys_code where code_sys='002' and code_type='003' and code_no=a.L3_code) as L3_name, ");
        sql.AppendLine("    (select code_desc1 from sys_code where code_sys='002' and code_type='006' and code_no=a.L1_code) as L1_name, ");
        sql.AppendLine("    (select code_desc1 from sys_code where code_sys='002' and code_type='009' and code_no=a.L2_code) as L2_name ");

        sql.AppendLine(" from SAL_PaySalChgNotic_main a ");
        sql.AppendLine(" inner join FSC_org b on a.Org_code=b.orgcode and a.depart_id=b.depart_id ");
        sql.AppendLine(" where a.org_code=@orgcode ");
        
        if(!String.IsNullOrEmpty(departId))
            sql.AppendLine(" and (a.depart_Id = @departId or a.depart_Id  in (select depart_id from fsc_org where parent_depart_id=@departId))");
        if (!String.IsNullOrEmpty(idCard))
            sql.AppendLine(" and a.Id_card=@idCard");
        if (!String.IsNullOrEmpty(sendStatus))
            sql.AppendLine(" and a.send_status=@sendStatus");
        
        SqlParameter[] param = {
            new SqlParameter("@orgcode", orgcode),
            new SqlParameter("@departId", departId),
            new SqlParameter("@idCard", idCard),
            new SqlParameter("@sendStatus", sendStatus)};

        return Query(sql.ToString(), param);
    }
}