using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2213DAO 的摘要描述
/// 加班費請領發放清冊
/// </summary>
public class SAL2213DAO : BaseDAO
{
	public SAL2213DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2213DAO(SqlConnection conn)
        : base(conn)
    {


    }

    // 查詢資料
    public DataTable queryData(
        string TdpmKind,
        string TdpmCodeSys,
        string TdpmCodeKind,
        string TpdmCodeType,
        string TdpmCodeNo,
        string TpdmCode,
        string FlowID
        )
    {
        string strSQL =
            "SELECT " +
            "( " +
            "SELECT BANK_BANK_NO " +
            "FROM SAL_SABANK  " +
            "LEFT OUTER JOIN SAL_SATDPM " +
            "ON TDPM_ORGID = BANK_ORGID " +
            "AND TDPM_KIND = @TdpmKind   " +  //'001'   
            "AND TDPM_CODE_SYS = @TdpmCodeSys   " + //'003'
            "AND TDPM_CODE_KIND = @TdpmCodeKind    " + //'P'
            "AND TDPM_CODE_TYPE = @TpdmCodeType  " +//'003'
            "AND TDPM_CODE_NO = @TdpmCodeNo    " + //'003' 
            "AND TDPM_CODE = @TpdmCode " + //''
            "WHERE BANK_ORGID = org_code   " +
            "AND BANK_SEQNO = USER_ID " +
            "AND BANK_TDPF_SEQNO = TDPM_TDPF_SEQNO " +
            ") AS BANK, " +
            "(	 " +
            "SELECT BASE_NAME  " +
            "FROM SAL_SABASE  " +
            "WHERE BASE_ORGID =org_code  " +
            "AND BASE_SEQNO = USER_ID  " +
            ") AS NAME " +
            ", APPLY_AMT " +
            "FROM SAL_OVERTIME_fee ";
        if (FlowID != "")
        {
            strSQL +=
            "WHERE FLOW_ID = @FlowID  ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@TdpmKind"        ,TdpmKind),
            new SqlParameter("@TdpmCodeSys"     ,TdpmCodeSys),
            new SqlParameter("@TdpmCodeKind"    ,TdpmCodeKind),
            new SqlParameter("@TpdmCodeType"    ,TpdmCodeType),
            new SqlParameter("@TdpmCodeNo"      ,TdpmCodeNo),
            new SqlParameter("@TpdmCode"        ,TpdmCode),
            new SqlParameter("@FlowID"          ,FlowID)
        };
        return Query(strSQL, sp);

    }

}