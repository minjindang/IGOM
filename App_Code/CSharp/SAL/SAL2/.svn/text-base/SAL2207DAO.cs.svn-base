using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2207DAO 的摘要描述
/// 替代役交通費發放清冊
/// </summary>
public class SAL2207DAO : BaseDAO
{
	public SAL2207DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2207DAO(SqlConnection conn)
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
            "AND TDPM_CODE_NO = @TdpmCodeNo    " + //'451' 
            "AND TDPM_CODE = @TpdmCode " + //002''
            "WHERE BANK_ORGID = SAL_TRANS_fee.org_code   " +
            "AND BANK_SEQNO = USER_ID " +
            "AND BANK_TDPF_SEQNO = TDPM_TDPF_SEQNO " +
            ") AS BANK, " +
            " (SELECT User_name FROM FSC_Personnel where Id_card = Non_id) AS NAME	 " +
            
            ", APPLY_AMT " +
            "FROM SAL_TRANS_fee,SAL_TRANS_feeDtl " +
            "WHERE SAL_TRANS_fee.id=SAL_TRANS_feeDtl.main_id ";
        if (FlowID != "")
        {
            strSQL +=
            "AND FLOW_ID = @FlowID  ";
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