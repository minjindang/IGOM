using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2203DAO 的摘要描述
/// 差旅費請領發放清冊
/// </summary>
public class SAL2203DAO : BaseDAO
{
    public SAL2203DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2203DAO(SqlConnection conn)
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
            "WHERE BANK_ORGID = orgcode   " +
            "AND BANK_SEQNO = id_card " +
            "AND BANK_TDPF_SEQNO = TDPM_TDPF_SEQNO " +
            ") AS BANK, " +
            "(	 " +
            "SELECT BASE_NAME  " +
            "FROM SAL_SABASE  " +
            "WHERE BASE_ORGID =orgcode  " +
            "AND BASE_SEQNO = id_card  " +
            ") AS NAME " +
            ", ISNULL('PANE',0)+ ISNULL('CAR',0)+ISNULL('TRAIN',0)+ISNULL('BOAT',0)+ISNULL('LIVE',0)+ISNULL('FOOD',0)+ISNULL('OTHERS',0)  APPLY_AMT " +
            "FROM SAL_officialout_fee ";
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