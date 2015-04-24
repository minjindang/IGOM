using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL2112DAO 的摘要描述
/// 2014/5/6 Eliot
/// SaCode -> Sys_Code
/// </summary>
public class SAL2112DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL2112DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2112DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 報表資料
    public DataTable getReportData(string strbase_dep // 單位別　
        , string strmane                 // 員工姓名
        , string strBASE_SEX             // 姓別
        , string strcno                  // 人員類別
        , string strno                   // 員工編號
        , string strdate1                // 發放日期
        , string strdate2                // 發放日期
        , string strBudget_code          // 預算來源
        , string strnum                  //所得流水號
        )
    {
        String strSQL =
                        " select * from ( "
            + "	Select p.PAYO_Budget_code,a.BASE_IDNO,a.BASE_NAME, ITEM_NAME,d1.PAYOD_YM as '發放年月', d1.PAYOD_AMT as '支領金額'"
            + "	, d1.payod_date as '發放日期', d2.PAYOD_AMT as '扣繳補充保費', it.CODE_DESC1 as '所得類別'"
            + "	, dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,d1.PAYOD_YM, base_ptb_type,base_alt_amt)+dbo.get_kdc_kdp_kdo('003' ,base_kdc,base_kdc_series,d1.PAYOD_YM) +dbo.get_kdc_kdp_kdo('004' ,base_kdp,base_kdp_series,d1.PAYOD_YM) as '本俸+專業加給+主管加給'"
            + "	, 4 * dbo.Get_Health_amt(a.BASE_SEQNO, BASE_ORGID, BASE_FINS_KIND, BASE_FINS_SERIES, BASE_LABOR_STATUS, BASE_LABOR_SERIES, @strdate2) 四倍投保金額"
            + "	, dbo.get_bonus_amt('005', BASE_ORGID, a.BASE_SEQNO, @strdate1, '','') 全年獎金累計金額"
            + "	FROM SAL_SAPAYOD d1 "
            + "	inner join SAL_SAPAYOD d2 "
            + "	on d2.PAYOD_SEQNO=d1.PAYOD_SEQNO "
            + "	and d2.PAYOD_YM=d1.PAYOD_YM "
            + "	and d2.PAYOD_DATE=d1.PAYOD_DATE "
            + "	and d2.PAYOD_CODE_SYS=d1.PAYOD_CODE_SYS "
            + "	and d2.PAYOD_CODE_KIND=d1.PAYOD_CODE_KIND "
            + "	and d1.PAYOD_KIND_CODE_NO=d2.PAYOD_KIND_CODE_NO "
            + "	and d1.PAYOD_KIND_CODE=d2.PAYOD_KIND_CODE "
            + "	and d2.PAYOD_CODE_SYS='003' "
            + "	and d2.PAYOD_CODE_KIND='P' "
            + "	and d2.PAYOD_CODE_TYPE='002' "
            + "	and d2.PAYOD_CODE_NO='017' "
            + "	inner join SAL_SABASE a on a.BASE_SEQNO=d1.PAYOD_SEQNO ";
            if (strcno != "ALL") 
            {
            strSQL += "	and BASE_PRONO in (@strcno)";//--當人員類別項目非全部時，增加此查詢條件
            }
            if (strmane != "")
            {
                strSQL+= "	and (base_name like '%' + @strmane + '%' ) ";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if (strbase_dep != "ALL")
            {
                strSQL += "	and base_dep in (@strbase_dep)";//--當查詢畫面單位別，非全部時，增加此查詢條件
            }

            strSQL+="	and BASE_STATUS = 'Y' ";

            if(strBASE_SEX != "ALL")
            {
                strSQL += "	and BASE_SEX = @strBASE_SEX"; //--當查詢畫面性別選項，非全部時，增加此查詢條件
            }
            if (strno != "")
            {
            strSQL += "	and base_seqno = @strno";//--當使用者輸入員工員工編號欄位時，增加此查詢條件
            }
            strSQL += "	inner join"
                + "	( select ITEM_NAME, ITEM_ORGID,ITEM_CODE_SYS,ITEM_CODE_KIND,ITEM_CODE_TYPE,ITEM_CODE_NO,CODE_DESC1,CODE_NO "
                + "		from SAL_SAITEM t "
                + "		inner join sys_code c "
                + "		on t.ITEM_ICODE=c.CODE_NO"
                + "		and c.CODE_SYS='003' "
                + "		and c.CODE_KIND='P' "
                + "		and c.CODE_TYPE='004' "
                + "		where ITEM_ADD_HealthPlus='Y' "
                + "		and ITEM_ADD_HealthPlusbonus='Y' "
                + "	)it	on d2.PAYOD_kind_CODE_TYPE=it.ITEM_CODE_TYPE"
                + "	and d2.PAYOD_kind_CODE_NO=it.ITEM_CODE_NO"
                + "	left outer join SAL_SAPAYO p"
                + "	on p.PAYO_ORGID = d1.PAYOD_ORGID"
                + "	and p.PAYO_SEQNO = d1.PAYOD_SEQNO"
                + "	and p.PAYO_YYMM = d1.PAYOD_YM"
                + "	and p.PAYO_DATE = d1.PAYOD_DATE"
                + "	and p.PAYO_KIND = d1.PAYOD_KIND"
                + "	and p.PAYO_KIND_CODE_TYPE=d1.PAYOD_KIND_CODE_TYPE "
                + "	and p.PAYO_KIND_CODE_NO=d1.PAYOD_KIND_CODE_NO"
                + "	and p.PAYO_KIND_CODE=d1.PAYOD_KIND_CODE"
                + "	and p.PAYO_Merge_flow_id=d1.PAYOD_Merge_flow_id";
            if (strBudget_code != "ALL" && strBudget_code != "")
            {
                strSQL +=
                         "	and p.PAYO_Budget_code = @strBudget_code";
            }
            strSQL+=
                 "	WHERE substring(d1.PAYOD_DATE, 1, 4) = substring(@strdate2 , 1, 4)"
                + "	and d1.PAYOD_CODE_SYS = '003' "
                + "	and d1.PAYOD_CODE_KIND = 'P' "
                + "	and d1.PAYOD_CODE_TYPE = '003' "
                + "	and d1.PAYOD_CODE_no = '001' "
                + "	and d1.payod_date between @strdate1 and @strdate2"
                + "	UNION Select p.PAYO_Budget_code,a.BASE_IDNO,a.BASE_NAME, ITEM_NAME,d1.PAYOD_YM as '發放年月', 0 as '支領金額'"
                + "	, d1.payod_date as '發放日期', d1.PAYOD_AMT as '扣繳補充保費', '薪資(50)' as '所得類別'"
                + "	, dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,d1.PAYOD_YM, base_ptb_type,base_alt_amt)+ dbo.get_kdc_kdp_kdo('003' ,base_kdc,base_kdc_series,d1.PAYOD_YM) + dbo.get_kdc_kdp_kdo('004' ,base_kdp,base_kdp_series,d1.PAYOD_YM) as '本俸+專業加給+主管加給'"
                + "	, 4 * dbo.Get_Health_amt(a.BASE_SEQNO, BASE_ORGID, BASE_FINS_KIND, BASE_FINS_SERIES, BASE_LABOR_STATUS, BASE_LABOR_SERIES, @strdate2) 四倍投保金額"
                + "	, dbo.get_bonus_amt('005', BASE_ORGID, a.BASE_SEQNO, @strdate1,'','') 全年獎金累計金額"
                + "	from SAL_SAPAYOD d1 "
                + "	inner join SAL_SABASE a "
                + "	on a.BASE_SEQNO=d1.PAYOD_SEQNO ";
            if (strcno != "ALL"){
                strSQL += "	and BASE_PRONO in (@strcno)";//--當人員類別項目非全部時，增加此查詢條件
            }
            if (strmane != "")
            {
                strSQL += "	and (base_name like '%' + @strmane + '%' ) ";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if (strbase_dep != "ALL")
            {
                strSQL += "	and base_dep in (@strbase_dep)";//--當查詢畫面單位別，非全部時，增加此查詢條件
            }
            strSQL += "	and BASE_STATUS = 'Y' ";
              if(strBASE_SEX != "ALL")
            {
                strSQL += "	and BASE_SEX = @strBASE_SEX";//--當查詢畫面性別選項，非全部時，增加此查詢條件
             }
              if (strno != "")
              {
                  strSQL += "	and base_seqno = @strno";//--當使用者輸入員工員工編號欄位時，增加此查詢條件
              }
            strSQL+= "	inner join SAL_SAITEM it "
            + "	on it.ITEM_OPERATION='-' "
            + "	and it.ITEM_BELONG='017'"
            + "	and ITEM_CODE_SYS=d1.PAYOD_CODE_SYS "
            + "	and ITEM_CODE_KIND=d1.PAYOD_CODE_KIND "
            + "	and ITEM_CODE_TYPE=d1.PAYOD_CODE_TYPE "
            + "	and ITEM_CODE_NO =d1.PAYOD_CODE_NO "
            + "	and ITEM_CODE=d1.PAYOD_CODE "
            + "	left outer join SAL_SAPAYO p"
            + "	on p.PAYO_ORGID = d1.PAYOD_ORGID"
            + "	and p.PAYO_SEQNO = d1.PAYOD_SEQNO"
            + "	and p.PAYO_YYMM = d1.PAYOD_YM"
            + "	and p.PAYO_DATE = d1.PAYOD_DATE"
            + "	and p.PAYO_KIND = d1.PAYOD_KIND"
            + "	and p.PAYO_KIND_CODE_TYPE=d1.PAYOD_KIND_CODE_TYPE "
            + "	and p.PAYO_KIND_CODE_NO=d1.PAYOD_KIND_CODE_NO"
            + "	and p.PAYO_KIND_CODE=d1.PAYOD_KIND_CODE"
            + "	and p.PAYO_Merge_flow_id=d1.PAYOD_Merge_flow_id";
            if (strBudget_code != "ALL" && strBudget_code != "")
            {
                strSQL +=
                         "	and p.PAYO_Budget_code = @strBudget_code";
            }
            strSQL +=
             "	where PAYOD_YM = substring(@strdate2 , 1, 4)"
            + "	and d1.payod_date between @strdate1 and @strdate2	"
            + "	UNION select p.PAYO_Budget_code,a.BASE_IDNO,a.BASE_NAME, '年終獎金' as ITEM_NAME,d1.PAYOD_YM as '發放年月', d1.PAYOD_AMT as '支領金額'	, d1.payod_date as '發放日期', d2.PAYOD_AMT as '扣繳補充保費', '薪資(50)' as '所得類別'"
            + "	, dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,d1.PAYOD_YM, base_ptb_type,base_alt_amt)+ dbo.get_kdc_kdp_kdo('003' ,base_kdc,base_kdc_series,d1.PAYOD_YM) + dbo.get_kdc_kdp_kdo('004' ,base_kdp,base_kdp_series,d1.PAYOD_YM) as '本俸+專業加給+主管加給'"
            + "	, 4 * dbo.Get_Health_amt(a.BASE_SEQNO, BASE_ORGID, BASE_FINS_KIND, BASE_FINS_SERIES, BASE_LABOR_STATUS, BASE_LABOR_SERIES, @strdate2) 四倍投保金額"
            + "	, dbo.get_bonus_amt('005', BASE_ORGID, a.BASE_SEQNO, @strdate1,'','') 全年獎金累計金額"
            + "	from SAL_SAPAYOD d1 "
            + "	inner join SAL_SABASE a "
            + "	on a.BASE_SEQNO=d1.PAYOD_SEQNO ";
            if (strcno != "ALL")
            {
                strSQL += "	and BASE_PRONO in (@strcno)";//--當人員類別項目非全部時，增加此查詢條件
            }
            if (strmane != "")
            {
                strSQL += "	and (base_name like '%' + @strmane + '%' ) ";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if (strbase_dep != "ALL")
            {
                strSQL += "	and base_dep in (@strbase_dep)";//--當查詢畫面單位別，非全部時，增加此查詢條件
            } 
              strSQL+="	and BASE_STATUS = 'Y' ";
             if (strBASE_SEX != "ALL")
                {
            strSQL += "	and BASE_SEX = @strBASE_SEX";//--當查詢畫面性別選項，非全部時，增加此查詢條件
               }
               if (strno != "")
               {
            strSQL += "	and base_seqno = @strno";//--當使用者輸入員工員工編號欄位時，增加此查詢條件
               }
               strSQL += "	left outer join SAL_SAPAYOD d2 "
               + "	on d2.PAYOD_SEQNO=d1.PAYOD_SEQNO "
               + "	and d2.PAYOD_YM=d1.PAYOD_YM "
               + "	and d2.PAYOD_DATE=d1.PAYOD_DATE "
               + "	and d2.PAYOD_CODE_SYS=d1.PAYOD_CODE_SYS "
               + "	and d2.PAYOD_CODE_KIND=d1.PAYOD_CODE_KIND "
               + "	and d1.PAYOD_KIND_CODE_NO=d2.PAYOD_KIND_CODE_NO "
               + "	and d1.PAYOD_KIND_CODE=d2.PAYOD_KIND_CODE "
               + "	and d2.PAYOD_CODE_SYS='003' "
               + "	and d2.PAYOD_CODE_KIND='P' "
               + "	and d2.PAYOD_CODE_TYPE='002' "
               + "	and d2.PAYOD_CODE_NO='017' "
               + "	left outer join SAL_SAPAYO p"
               + "	on p.PAYO_ORGID = d1.PAYOD_ORGID"
               + "	and p.PAYO_SEQNO = d1.PAYOD_SEQNO"
               + "	and p.PAYO_YYMM = d1.PAYOD_YM"
               + "	and p.PAYO_DATE = d1.PAYOD_DATE"
               + "	and p.PAYO_KIND = d1.PAYOD_KIND";
               ;
               if (strBudget_code != "ALL" && strBudget_code != "")
               {
                   strSQL +=
                            "	and p.PAYO_Budget_code = @strBudget_code";
               }
               strSQL +=
             "	WHERE d1.PAYOD_KIND ='004' "
            + "	and substring(d1.PAYOD_DATE, 1, 4) = substring(@strdate2 , 1, 4) "
            + "	and d1.PAYOD_CODE_SYS = '003' "
            + "	and d1.PAYOD_CODE_KIND = 'P' "
            + "	and d1.PAYOD_CODE_TYPE = '003' "
            + "	and d1.PAYOD_CODE_no = '001' "
            + "	and d1.payod_date between @strdate1 and @strdate2	"
            + "	UNION select p.PAYO_Budget_code,a.BASE_IDNO,a.BASE_NAME, (case d1.PAYOD_KIND when '002' then'預借考績獎金' when '003' then '核定考績獎金' end) as ITEM_NAME"
            + "	,d1.PAYOD_YM as '發放年月', d1.PAYOD_AMT as '支領金額', d1.payod_date as '發放日期', d2.PAYOD_AMT as '扣繳補充保費', '薪資(50)' as '所得類別'"
            + "	, dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,d1.PAYOD_YM, base_ptb_type,base_alt_amt)+ dbo.get_kdc_kdp_kdo('003' ,base_kdc,base_kdc_series,d1.PAYOD_YM) + dbo.get_kdc_kdp_kdo('004' ,base_kdp,base_kdp_series,d1.PAYOD_YM) as '本俸+專業加給+主管加給'"
            + "	, 4 * dbo.Get_Health_amt(a.BASE_SEQNO, BASE_ORGID, BASE_FINS_KIND, BASE_FINS_SERIES, BASE_LABOR_STATUS, BASE_LABOR_SERIES, @strdate2) 四倍投保金額"
            + "	, dbo.get_bonus_amt('005', BASE_ORGID, a.BASE_SEQNO, @strdate1,'','') 全年獎金累計金額"
            + "	from SAL_SAPAYOD d1 "
            + "	inner join SAL_SABASE a "
            + "	on a.BASE_SEQNO=d1.PAYOD_SEQNO ";
            if (strcno != "ALL")
            {
                strSQL += "	and BASE_PRONO in (@strcno)";//--當人員類別項目非全部時，增加此查詢條件
            }
            if (strmane != "")
            {
                strSQL += "	and (base_name like '%' + @strmane + '%' ) ";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if (strbase_dep != "ALL")
            {
                strSQL += "	and base_dep in (@strbase_dep)";//--當查詢畫面單位別，非全部時，增加此查詢條件
            }
            strSQL += "	and BASE_STATUS = 'Y' ";
            if (strBASE_SEX != "ALL")
            {
                strSQL += "	and BASE_SEX = @strBASE_SEX";//--當查詢畫面性別選項，非全部時，增加此查詢條件
            }
            if (strno != "")
            {
                strSQL += "	and base_seqno = @strno";//--當使用者輸入員工員工編號欄位時，增加此查詢條件
            }
            strSQL += "	left outer join SAL_SAPAYOD d2 "
               + "	on d2.PAYOD_SEQNO=d1.PAYOD_SEQNO "
               + "	and d2.PAYOD_YM=d1.PAYOD_YM "
               + "	and d2.PAYOD_DATE=d1.PAYOD_DATE "
               + "	and d2.PAYOD_CODE_SYS='003' "
               + "	and d2.PAYOD_CODE_KIND='P' "
               + "	and d2.PAYOD_CODE_TYPE='002' "
               + "	and d2.PAYOD_CODE_NO='017' "
               + "	left outer join SAL_SAPAYO p"
               + "	on p.PAYO_ORGID = d1.PAYOD_ORGID"
               + "	and p.PAYO_SEQNO = d1.PAYOD_SEQNO"
               + "	and p.PAYO_YYMM = d1.PAYOD_YM"
               + "	and p.PAYO_DATE = d1.PAYOD_DATE"
               + "	and p.PAYO_KIND = d1.PAYOD_KIND";
             if (strBudget_code != "ALL" && strBudget_code != "")
             {
                 strSQL +=
                          "	and p.PAYO_Budget_code = @strBudget_code";
             }
             strSQL +=
                 "	WHERE d1.PAYOD_KIND in ('002','003') "
                + "	and substring(d1.PAYOD_DATE, 1, 4) = substring(@strdate2 , 1, 4)"
                + "	and d1.PAYOD_CODE_SYS = '003' "
                + "	and d1.PAYOD_CODE_KIND = 'P' "
                + "	and d1.PAYOD_CODE_TYPE = '003' "
                + "	and d1.PAYOD_CODE_no = '001' "
                + "	and d1.payod_date between @strdate1 and @strdate2	"
                + "	UNION select p.PAYO_Budget_code,a.BASE_IDNO,a.BASE_NAME, '兼職所得' as ITEM_NAME"
                + "	,d1.PAYOD_YM as '發放年月', d1.PAYOD_AMT as '支領金額', d1.payod_date as '發放日期', d2.PAYOD_AMT as '扣繳補充保費', '薪資(50)' as '所得類別'"
                + "	, dbo.getPerson_PtbAmt2('1' ,base_job,base_kdb,base_ptb,d1.PAYOD_YM, base_ptb_type,base_alt_amt)+ dbo.get_kdc_kdp_kdo('003' ,base_kdc,base_kdc_series,d1.PAYOD_YM) + dbo.get_kdc_kdp_kdo('004' ,base_kdp,base_kdp_series,d1.PAYOD_YM) as '本俸+專業加給+主管加給'"
                + "	, 4 * dbo.Get_Health_amt(a.BASE_SEQNO, BASE_ORGID, BASE_FINS_KIND, BASE_FINS_SERIES, BASE_LABOR_STATUS, BASE_LABOR_SERIES, @strdate2) 四倍投保金額"
                + "	, dbo.get_bonus_amt('005', BASE_ORGID, a.BASE_SEQNO, @strdate1, '','') 全年獎金累計金額"
                + "	from SAL_SAPAYOD d1 "
                + "	inner join SAL_SABASE a "
                + "	on a.BASE_SEQNO=d1.PAYOD_SEQNO ";
            if (strcno != "ALL")
            {
                strSQL += "	and BASE_PRONO in (@strcno)";//--當人員類別項目非全部時，增加此查詢條件
            }
            if (strmane != "")
            {
                strSQL += "	and (base_name like '%' + @strmane + '%' ) ";//--當使用者輸入員工姓名欄位時，增加此查詢條件
            }
            if (strbase_dep != "ALL")
            {
                strSQL += "	and base_dep in (@strbase_dep)";//--當查詢畫面單位別，非全部時，增加此查詢條件
            }
            strSQL += "	and BASE_STATUS = 'Y' ";
            if (strBASE_SEX != "ALL")
            {
                strSQL += "	and BASE_SEX = @strBASE_SEX";//--當查詢畫面性別選項，非全部時，增加此查詢條件
            }
            if (strno != "")
            {
                strSQL += "	and base_seqno = @strno";//--當使用者輸入員工員工編號欄位時，增加此查詢條件
            }

            strSQL += "	left outer join SAL_SAPAYOD d2 "
            + "	on d2.PAYOD_SEQNO=d1.PAYOD_SEQNO "
            + "	and d2.PAYOD_YM=d1.PAYOD_YM "
            + "	and d2.PAYOD_DATE=d1.PAYOD_DATE "
            + "	and d2.PAYOD_CODE_SYS='003' "
            + "	and d2.PAYOD_CODE_KIND='P' "
            + "	and d2.PAYOD_CODE_TYPE='002' "
            + "	and d2.PAYOD_CODE_NO='017' "
            + "	left outer join SAL_SAPAYO p"
            + "	on p.PAYO_ORGID = d1.PAYOD_ORGID"
            + "	and p.PAYO_SEQNO = d1.PAYOD_SEQNO"
            + "	and p.PAYO_YYMM = d1.PAYOD_YM"
            + "	and p.PAYO_DATE = d1.PAYOD_DATE"
            + "	and p.PAYO_KIND = d1.PAYOD_KIND";
            
            if (strBudget_code != "ALL" && strBudget_code != "")
            {
                strSQL +=
                         "	and p.PAYO_Budget_code = @strBudget_code";
            }
            strSQL +=
            "	WHERE d1.PAYOD_KIND in ('001') "
            + "	and substring(d1.PAYOD_DATE, 1, 4) = substring(@strdate2 , 1, 4)"
            +"	and d1.PAYOD_CODE_SYS = '003' "
            +"	and d1.PAYOD_CODE_KIND = 'P' "
            +"	and d1.PAYOD_CODE_TYPE = '003' "
            +"	and d1.PAYOD_CODE_no = '001' "
            +"	and BASE_PARTTIME='Y' "
            + "	and d1.payod_date between @strdate1 and @strdate2"
            +" )asaaa"
            +" order by base_idno" ;
        
    
        SqlParameter[] sp =
        {
            new SqlParameter("@strbase_dep",strbase_dep),   // 單位別　
            new SqlParameter("@strmane",strmane),           // 員工姓名
            new SqlParameter("@strBASE_SEX",strBASE_SEX),   // 姓別
            new SqlParameter("@strcno",strcno),             // 人員類別
            new SqlParameter("@strno",strno),               //員工編號
            new SqlParameter("@strdate1",strdate1),         //發放日期
            new SqlParameter("@strdate2",strdate2),         //發放日期
            new SqlParameter("@strBudget_code",strBudget_code), //預算來源
            new SqlParameter("@strnum",strnum)              //所得流水號  
        };

        return Query(strSQL, sp);
    }



}