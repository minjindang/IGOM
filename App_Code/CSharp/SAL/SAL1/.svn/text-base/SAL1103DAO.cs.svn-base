using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SAL1103DAO
/// </summary>

namespace SAL.Logic
{
    public class SAL1103DAO : BaseDAO
    {
        public SAL1103DAO()
            : base(ConnectDB.GetDBString())
        {

        }

        public DataTable SelectvLastestFee(string Apply_Period, string User_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select p.User_name, ");//申請人姓名
            sql.Append(" b.Child_name, ");//子姓姓名
            sql.Append(" b.ChildBirth_date, ");//子女生日
            sql.Append(" b.child_id, ");//身份證字號
            sql.Append(" a.Apply_date, ");//申請日期
            sql.Append(" a.Apply_yy, ");//學年度
            sql.Append(" a.Period_type, ");//學期
            sql.Append(" b.School_name, ");//學校名稱科系
            sql.Append(" b.School_type, ");//學歷
            sql.Append(" (select code_desc1 from sys_code where CODE_SYS='006' and CODE_TYPE='011' and code_no=b.School_type) as School_type_name, ");//學歷
            sql.Append(" b.StudyLimit_nos, ");//修業年限
            sql.Append(" b.Study_nos, ");//就讀年級
            sql.Append(" b.Apply_amt ");//申請金額
            sql.Append(" From SAL_EDU_fee a ");
            sql.Append(" inner join SAL_EDU_feeDtl b 	On a.Id=b.main_id ");
            sql.Append(" inner join SYS_Flow c on a.Flow_id=c.Flow_id ");
            sql.Append(" inner join FSC_Personnel p on p.Id_card=a.user_id ");
            sql.Append(" where a.Apply_yy+a.Period_type = @Apply_Period  ");
            sql.Append(" and a.User_id=@User_id ");
            sql.Append(" and c.Case_status = '1' ");// 已核準

            SqlParameter[] sp = new SqlParameter[] { 
                new SqlParameter("@Apply_Period", Apply_Period),
                new SqlParameter("@User_id", User_id)
            };

            return Query(sql.ToString(), sp);
        }

        public DataTable SelectChildFeeInfo(string Apply_yy, string Period_type, string Child_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select b.Child_id ");
            sql.Append(" from SAL_EDU_fee a inner join SAL_EDU_feeDtl b on a.Id=b.main_id ");
            sql.Append(" inner join SYS_Flow c on a.Flow_id=c.flow_id ");
            sql.Append(" where b.Child_id=@Child_id ");
            sql.Append(" and a.Apply_yy=@Apply_yy ");
            sql.Append(" and a.Period_type=@Period_type");
            sql.Append(" and c.Case_status in ('0','1','2') ");//送出、核準、退回修改中

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Apply_yy", Apply_yy),
                new SqlParameter("@Child_id", Child_id),
                new SqlParameter("@Period_type", Period_type)
            };

            return Query(sql.ToString(), sp);
        }

        public DataTable getDataByOrgFid(string Orgcode, string flow_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select distinct d.*, m.Apply_date, m.Apply_yy, m.Period_type, ");
            sql.AppendLine(" m.flow_id, '' Guid, a.File_name, a.File_size, a.File_type, ");
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where code_sys='006' and code_type='011' and code_no=d.School_type) School_type_name, ");
            sql.AppendLine(" (select top 1 User_Name from FSC_Personnel p WHERE p.id_card=m.User_id ) User_Name ,a.id Attach_id");
            sql.AppendLine(" from SAL_EDU_feeDtl d ");
            sql.AppendLine(" inner join SAL_EDU_fee m on m.id=d.main_id and m.Org_code=@Orgcode and m.flow_id=@flow_id ");
            sql.AppendLine(" left join SYS_Attachment a on m.flow_id = a.flow_id and d.Att_id=a.id ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Orgcode", Orgcode),
                                                     new SqlParameter("@flow_id", flow_id)};

            return Query(sql.ToString(), sp);
        }

        public int DeleteAttach(string flow_id, ArrayList attIdlist)
        {
            string id = "";
            foreach (int i in attIdlist)
            {
                if (!id.Equals("")) id += ",";
                id += i.ToString();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" delete from SYS_Attachment where flow_id=@flow_id and id not in ("+ id +") ");

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@flow_id", flow_id)};

            return Execute(sql.ToString(), sp);

        }
    }
}