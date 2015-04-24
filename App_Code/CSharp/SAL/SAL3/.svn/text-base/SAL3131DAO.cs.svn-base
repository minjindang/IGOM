using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class SAL3131DAO : BaseDAO
{
    public SAL3131DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public DataTable getData(string Orgcode, string flow_id)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendLine(" select ");
        sql.AppendLine(" f.id, ");
        sql.AppendLine(" f.BASE_IDNO as Fee_BASE_IDNO, ");
        sql.AppendLine(" f.BASE_NAME as Fee_BASE_NAME, ");
        sql.AppendLine(" f.BASE_SERVICE_PLACE_DESC as Fee_BASE_SERVICE_PLACE_DESC, ");
        sql.AppendLine(" f.BASE_DCODE_NAME as Fee_BASE_DCODE_NAME, ");
        sql.AppendLine(" f.BASE_ADDR as Fee_BASE_ADDR, ");
        sql.AppendLine(" f.BASE_BANK_CODE, ");
        sql.AppendLine(" f.BASE_BANK_NO, ");
        sql.AppendLine(" b.BASE_IDNO, ");
        sql.AppendLine(" b.BASE_NAME, ");
        sql.AppendLine(" b.BASE_SERVICE_PLACE_DESC, ");
        sql.AppendLine(" b.BASE_DCODE_NAME, ");
        sql.AppendLine(" b.BASE_ADDR, ");
        sql.AppendLine(" (select top 1 k.BANK_CODE from sal_sabank k where k.BANK_SEQNO=b.BASE_SEQNO) as BANK_CODE, ");
        sql.AppendLine(" (select top 1 k.BANK_BANK_NO from sal_sabank k where k.BANK_SEQNO=b.BASE_SEQNO) as BANK_BANK_NO ");
        sql.AppendLine(" from SAL_EXAMINE_fee f ");
        sql.AppendLine(" inner join sal_sabase b on f.BASE_IDNO = b.BASE_IDNO ");
        sql.AppendLine(" where 1=1 ");

        if (!string.IsNullOrEmpty(Orgcode))
        {
            sql.AppendLine(" and f.Org_code=@Orgcode ");
        }
        if (!string.IsNullOrEmpty(flow_id))
        {
            sql.AppendLine(" and f.Flow_id=@Flow_id ");
        }

        sql.AppendLine(" order by f.BASE_IDNO ");

        SqlParameter[] sp = {
            new SqlParameter ("@Orgcode",Orgcode),
            new SqlParameter ("@flow_id",flow_id)};

        return Query(sql.ToString(), sp);
    }

    public void updateEXAMINE_fee(string id, string BASE_ADDR)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendLine(" update SAL_EXAMINE_fee set BASE_ADDR=@BASE_ADDR ");
        sql.AppendLine(" where id=@id ");

        SqlParameter[] sp = {
            new SqlParameter ("@BASE_ADDR",BASE_ADDR),
            new SqlParameter ("@id",id)};

        Execute(sql.ToString(), sp);
    }

    public void UpdateSABASE(string BASE_IDNO, string BASE_NAME, string BASE_SERVICE_PLACE_DESC, string BASE_DCODE_NAME, string BASE_ADDR, string BANK_CODE, string BANK_BANK_NO)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendLine(" update sal_sabase set ");
        sql.AppendLine(" BASE_NAME=@BASE_NAME, ");
        sql.AppendLine(" BASE_SERVICE_PLACE_DESC=@BASE_SERVICE_PLACE_DESC, ");
        sql.AppendLine(" BASE_DCODE_NAME=@BASE_DCODE_NAME, ");
        sql.AppendLine(" BASE_ADDR=@BASE_ADDR ");
        sql.AppendLine(" where BASE_IDNO=@BASE_IDNO ; ");

        sql.AppendLine(" update sal_sabank set ");
        sql.AppendLine(" BANK_CODE=@BANK_CODE, ");
        sql.AppendLine(" BANK_BANK_NO=@BANK_BANK_NO ");
        sql.AppendLine(" where BANK_SEQNO in ");
        sql.AppendLine(" (select BASE_SEQNO from SAL_SABASE where BASE_IDNO=@BASE_IDNO) ");

        SqlParameter[] sp = {
            new SqlParameter ("@BASE_NAME",BASE_NAME),
            new SqlParameter ("@BASE_SERVICE_PLACE_DESC",BASE_SERVICE_PLACE_DESC),
            new SqlParameter ("@BASE_DCODE_NAME",BASE_DCODE_NAME),
            new SqlParameter ("@BASE_ADDR",BASE_ADDR),
            new SqlParameter ("@BANK_CODE",BANK_CODE),
            new SqlParameter ("@BANK_BANK_NO",BANK_BANK_NO),
            new SqlParameter ("@BASE_IDNO",BASE_IDNO)};

        Execute(sql.ToString(), sp);
    }
}