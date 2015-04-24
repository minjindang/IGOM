using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MAI.Logic
{
    /// <summary>
    /// MAI3101DAO 的摘要描述
    /// </summary>
    public class MAI3101DAO : BaseDAO
    {
        public MAI3101DAO()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }

        public DataTable GetDataByQuery(String orgcode, ArrayList maintainKinds, String applyDateS, String applyDateE, String applyExt, String applyIdcard, String applyDepartid)
        { 
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine(" select ");
            sql.AppendLine(" m.Orgcode, ");
            sql.AppendLine(" m.Flow_id, ");
            sql.AppendLine(" m.Apply_ext, ");
            sql.AppendLine(" m.Apply_departid, ");
            sql.AppendLine(" m.Apply_idcard, ");
            sql.AppendLine(" m.Apply_name, ");
            sql.AppendLine(" m.Apply_date, ");
            sql.AppendLine(" m.Writer_ext, ");
            sql.AppendLine(" m.Writer_departid, ");
            sql.AppendLine(" m.Writer_idcard, ");
            sql.AppendLine(" m.Writer_name, ");
            sql.AppendLine(" m.Problem_desc, ");
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=m.orgcode and f.depart_id=m.apply_departid) as Depart_Name, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='020' and s.code_type='**' and s.code_no=m.Maintain_kind) as Maintain_kind, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='020' and s.code_type=m.Maintain_kind and s.code_no=m.Maintain_type) as Maintain_type, ");
            sql.AppendLine(" case when m.Maintain_kind='005'  ");
            sql.AppendLine(" then (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='006' and s.code_no=h.Status_type) ");
            sql.AppendLine(" else (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='003' and s.code_no=h.Status_type) end case_status, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='001' and s.code_no=h.Operate_type) as Operate_type, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='002' and s.code_no=h.Service_type) as Service_type, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='019' and s.code_type='004' and s.code_no=h.Handle_type) as Handle_type, ");
            sql.AppendLine(" h.*, ");
            sql.AppendLine(" (select old_flowid from SYS_Flow where orgcode=m.orgcode and flow_id=m.flow_id) old_flowid, '' as record ");
            sql.AppendLine(" from mai_maintain_main m ");
            sql.AppendLine(" left outer join mai_maintain_handle h on m.id=h.Main_id ");
            sql.AppendLine(" where m.orgcode=@orgcode ");

            if (!String.IsNullOrEmpty(applyDateS))
                sql.AppendLine(" and m.apply_date>=@applyDateS ");
            if (!String.IsNullOrEmpty(applyDateE))
                sql.AppendLine(" and m.apply_date<=@applyDateE ");
            if (!String.IsNullOrEmpty(applyExt))
                sql.AppendLine(" and m.apply_ext=@applyExt ");
            if (!String.IsNullOrEmpty(applyIdcard))
                sql.AppendLine(" and m.apply_idcard=@applyIdcard ");
            if (!String.IsNullOrEmpty(applyDepartid))
                sql.AppendLine(" and m.apply_departid=@applyDepartid ");

            int arrLen = 6 + maintainKinds.Count;

            SqlParameter[] param = new SqlParameter[arrLen];
            param[0] = new SqlParameter("@orgcode", orgcode);
            param[1] = new SqlParameter("@applyDateS", applyDateS);
            param[2] = new SqlParameter("@applyDateE", applyDateE);
            param[3] = new SqlParameter("@applyExt", applyExt);
            param[4] = new SqlParameter("@applyIdcard", applyIdcard);
            param[5] = new SqlParameter("@applyDepartid", applyDepartid);
            
            sql.AppendLine(" and ( ");
            for (int i = 0; i < maintainKinds.Count; i++)
            {
                if (i != 0) sql.Append(" or ");
                sql.Append(" m.maintain_kind=@maintainKind" + i.ToString());

                param[6 + i] = new SqlParameter("@maintainKind" + i.ToString(), maintainKinds[i]);
            }
            sql.AppendLine(" ) ");

            return Query(sql.ToString(), param);

        }
    }
}