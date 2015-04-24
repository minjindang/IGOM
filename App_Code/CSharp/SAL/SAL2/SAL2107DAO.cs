using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2107DAO 的摘要描述
/// 考績獎金發放清冊
/// </summary>
public class SAL2107DAO : BaseDAO
{
	public SAL2107DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2107DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable queryData(
        string strPayoOrgId,    // 登入者機關代碼
        string strPayoKind,     // 查詢畫面選擇之考績種類代碼 –考績發放 
        string strPayoProno,    // 人員類別
        string strPayoYyMm,     // 查詢畫面選擇之年月
        string strPayBudgeCode // 查詢畫面選擇之預算來源代碼
    )
    {
        string strSQL =
            "select PAYO_ORGID, PAYO_SEQNO, PAYO_KIND, PAYO_YYMM, PAYO_DATE " +
            ", isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='002' and CODE_NO = PAYO_DCODE) ,'未設定') as dcode " + //-- 職稱
            ", isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='003' and CODE_NO = PAYO_ORG_L3) ,'') + " + //
            "isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='006' and CODE_NO = PAYO_ORG_L2 ) ,'') + " + //
            "isnull(( select CODE_DESC1 from SYS_CODE where CODE_SYS ='002' and CODE_TYPE='009' and CODE_NO = PAYO_ORG_L2 ) ,'') + " + //
            "case ISNULL(PAYO_PTB ,'') when '' then '' else ISNULL(PAYO_PTB ,'') + '點' end as lv  " + //-- 等級
            ", PAYO_NAME  " + //-- 姓名
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '001'),0) as item001  " + //-- 本俸
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '003'),0) as item002  " + //-- 一般專業加給
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '006'),0) as item003  " + //-- 環保專業加給
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '016'),0) as item004  " + //-- 技術加給
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '004'),0) as item005  " + //-- 主管職務加給
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '001' ),0) as item006  " + //-- 小計
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '005' and PAYOD_CODE_TYPE = '001' and PAYOD_CODE_NO = '402'),0) as item007  " + //-- 交通費
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '003' and PAYOD_CODE_NO = '001'),0) as item008  " + //-- 合計
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '001'),0) as item009  " + //-- 所得稅
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '003' and PAYOD_CODE = '001'),0) as item010  " + //-- 公保費
            ", 0 as item011   " + //-- 公健保費
            ", 0 as item012  " + //-- 眷屬健保費
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '005' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '048'),0) as item013  " + //-- 捐款, (PAYOD_CODE_NO代碼可能調整)
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '003' and PAYOD_CODE = '002'),0) as item014  " + //-- 勞保費
            ", 0 as item015  " + //-- 勞健保費
            ", 0 as item016  " + //-- 眷屬健保費
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '005' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '003'),0) as item017  " + //-- 貸款
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '005' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '002'),0) as item018  " + //-- 房租津貼
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '005' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '001'),0) as item019  " + //-- 優惠存款
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '007' and PAYOD_CODE = '002'),0) as item020  " + //-- 退撫金
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '007' and PAYOD_CODE = '002'),0) as item021  " + //-- 退職金
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '002' and PAYOD_CODE_NO = '015'),0) as item022  " + //-- 勞工自願提繳
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '003' and PAYOD_CODE_NO = '002'),0) as item023  " + //-- 合計
            ", isnull(( select sum(PAYOD_AMT) from SAL_SAPAYOD where PAYOD_ORGID = PAYO_ORGID and PAYOD_SEQNO = PAYO_SEQNO and PAYOD_KIND = PAYO_KIND and PAYOD_YM = PAYO_YYMM and PAYOD_DATE = PAYO_DATE and PAYOD_CODE_SYS = '003' and PAYOD_CODE_TYPE = '003' and PAYOD_CODE_NO = '003'),0) as item024  " + //-- 實發入帳金額
            ", ISNULL(( select top 1 BANK_BANK_NO from SAL_SABANK inner join SAL_SATDPM on TDPM_ORGID = BANK_ORGID and TDPM_KIND = PAYO_KIND and TDPM_CODE_SYS = '003' and TDPM_CODE_TYPE = '003' and TDPM_CODE_NO = '003' where BANK_ORGID = PAYO_ORGID and BANK_SEQNO = PAYO_SEQNO  ),'') as bank  " + //-- 帳號	
            ", isnull(( select Memo_Description from sal_samemo where Memo_Orgid = PAYO_ORGID and Memo_Seqno = PAYO_SEQNO and Memo_Kind = PAYO_KIND and Memo_Ym = PAYO_YYMM and Memo_Date = PAYO_DATE ),'') as memo  " + //-- 備註
            "from SAL_SAPAYO " + //
            "where PAYO_ORGID = @PayoOrgId " + // --登入者機關代碼
            "and PAYO_KIND =  @PayoKind    "; //-- 查詢畫面選擇之考績種類代碼 –考績發放
        if (strPayoProno == "2")
        {
            strSQL +=
                "and PAYO_PRONO <> '7'  "; //-- 若人員類別選擇   全部(不含臨時工)，增加此查詢條件
        }
        if (strPayoProno == "3")
        {
            strSQL +=
                "and PAYO_PRONO = '7'  "; //-- 若人員類別選擇   臨時工，增加此查詢條件
        }

        strSQL +=
            "and PAYO_YYMM = @PayoYyMm "; //查詢畫面選擇之年月

        if (strPayBudgeCode != "" && strPayBudgeCode != "ALL")
        {
            strSQL +=
            "and PAYO_Budget_code = @PayBudgeCode "; //查詢畫面選擇之預算來源代碼
        }
        strSQL +=
            "order by PAYO_PRONO ";

        SqlParameter[] sp =
        {
            new SqlParameter("@PayoOrgId",strPayoOrgId), // 登入者機關代碼
            new SqlParameter("@PayoKind",strPayoKind), 
            new SqlParameter("@PayoYyMm",strPayoYyMm), 
            new SqlParameter("@PayBudgeCode",strPayBudgeCode)
          
        };

        return Query(strSQL, sp);

    }
}