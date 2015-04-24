using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 2014/4/29
/// SAL2101薪餉單查詢
/// </summary>
public class SAL2101DAO : BaseDAO
{
	public SAL2101DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2101DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable getData(
        string strPayoOrgID,
        string strPayoSeqNo
        )
    {
        // 昨天
        string strYesterDay = DateTime.Now.AddDays(-1).ToString("yyyyMMdd"); //String.Format("{0,yyyyMMdd}" , DateTime.Now.AddDays(-1));
        // 3個月前
        string str3MonthAgo = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd"); //String.Format("{0,yyyyMMdd}", DateTime.Now.AddMonths(-3));

        string strSQL =
            "select PAYO_ORGID, PAYO_SEQNO, PAYO_YYMM, PAYO_DATE, payo_kind, payo_kind_code_type, payo_kind_code_no, payo_kind_code " +
            ", case payo_kind  " +
            "when '005' then ( select item_name from sal_saitem where item_orgid = payo_orgid and item_code_sys = payo_kind and item_code_type = payo_kind_code_type and item_code_no = payo_kind_code_no and item_code = payo_kind_code ) " +
            "else ( select code_desc1 from sys_code where code_sys = '003' and code_type='005' and code_no = payo_kind)  " +
            "end as kind_name " +
            ",isnull(( " +
            "select payod_amt from sal_sapayod  " +
            "where payod_ym = payo_yymm  " +
            "and payod_seqno = payo_seqno  " +
            "and payod_orgid = payo_orgid  " +
            "and payod_date = payo_date  " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003'  " +
            "and payod_code_no = '001'  " +
            "and payod_kind = payo_kind  " +
            "and payod_kind_code_type = payo_kind_code_type  " +
            "and payod_kind_code_no = payo_kind_code_no  " +
            "and payod_kind_code = payo_kind_code  " +
            "),0) as payod_amt_001  " +//--應發合計
            ",isnull(( " +
            "select payod_amt from sal_sapayod  " +
            "where payod_ym = payo_yymm  " +
            "and payod_seqno = payo_seqno  " +
            "and payod_orgid = payo_orgid  " +
            "and payod_date = payo_date  " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003'  " +
            "and payod_code_no = '002'  " +
            "and payod_kind = payo_kind  " +
            "and payod_kind_code_type = payo_kind_code_type  " +
            "and payod_kind_code_no = payo_kind_code_no  " +
            "and payod_kind_code = payo_kind_code  " +
            "),0) as payod_amt_002  " +//--應扣合計
            ",isnull(( " +
            "select payod_amt from sal_sapayod  " +
            "where payod_ym = payo_yymm  " +
            "and payod_seqno = payo_seqno  " +
            "and payod_orgid = payo_orgid  " +
            "and payod_date = payo_date  " +
            "and payod_code_sys = '003'  " +
            "and payod_code_type = '003'  " +
            "and payod_code_no = '003'  " +
            "and payod_kind = payo_kind  " +
            "and payod_kind_code_type = payo_kind_code_type  " +
            "and payod_kind_code_no = payo_kind_code_no  " +
            "and payod_kind_code = payo_kind_code  " +
            "),0) as payod_amt_003  " +//--實發金額
            "from sal_SAPAYO  " +
            "where PAYO_ORGID = @PayoOrgID " +//'登入者機關代號'
            "and PAYO_SEQNO = @PayoSeqNo " +//'登入者員工編號'
            "and PAYO_DATE between  @3MonthAge  and  @Yestorday " +//
            "order by PAYO_DATE desc, PAYO_KIND ";

        SqlParameter[] sp =
        {
            new SqlParameter("@PayoOrgID",strPayoOrgID), // 登入者機關代碼
            new SqlParameter("@PayoSeqNo",strPayoSeqNo), 
            new SqlParameter("@3MonthAge",str3MonthAgo), 
            new SqlParameter("@Yestorday",strYesterDay) 
          
        };

        return Query(strSQL, sp);
    }


}