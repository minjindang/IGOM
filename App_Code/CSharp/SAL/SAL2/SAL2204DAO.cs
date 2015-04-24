using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2204DAO 的摘要描述
/// 休假補助費發放清冊
/// </summary>
public class SAL2204DAO : BaseDAO
{
    public SAL2204DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2204DAO(SqlConnection conn)
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
            "AND TDPM_KIND = @TdpmKind   " +  //'005'   
            "AND TDPM_CODE_SYS = @TdpmCodeSys   " + //'005'
            "AND TDPM_CODE_KIND = @TdpmCodeKind    " + //'D'
            "AND TDPM_CODE_TYPE = @TpdmCodeType  " +//'001'
            "AND TDPM_CODE_NO = @TdpmCodeNo    " + //'501' 
            "AND TDPM_CODE = @TpdmCode " + //006''
            "WHERE BANK_ORGID = SAL_EDU_fee.org_code   " +
            "AND BANK_SEQNO = SAL_EDU_fee.USER_ID " +
            "AND BANK_TDPF_SEQNO = TDPM_TDPF_SEQNO " +
            ") AS BANK, " +
            "(	 " +
            "SELECT BASE_NAME  " +
            "FROM SAL_SABASE  " +
            "WHERE BASE_ORGID =SAL_EDU_fee.org_code  " +
            "AND BASE_SEQNO = SAL_EDU_fee.USER_ID  " +
            ") AS NAME " +
            ", APPLY_AMT " +
            "FROM SAL_EDU_fee,SAL_EDU_feedtl, SYS_Flow " +
            "where SAL_EDU_feedtl.main_id=SAL_EDU_fee.id " +
            " AND SYS_Flow.Flow_id=SAL_EDU_fee.Flow_id ";

        if (FlowID != "")
        {
            strSQL +=
            "AND (SAL_EDU_fee.FLOW_ID = @FlowID or SYS_Flow.Merge_flowid = @FlowID)  ";
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