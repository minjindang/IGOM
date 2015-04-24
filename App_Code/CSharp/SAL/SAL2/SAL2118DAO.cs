using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2118DAO 的摘要描述
/// SAL2118 員工所得扣繳資料查詢
/// Eliot Chen
/// </summary>
public class SAL2118DAO : BaseDAO
{
    public SAL2118DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2118DAO(SqlConnection conn)
        : base(conn)
    {


    }


    // 發放種類為其他薪津(005)時查詢項目
    public DataTable queryItemTypes
        (
        string strOrgID // 機關代號
        )
    {
        string strSQL =
            "SELECT INCO_KIND_CODE, " +
            "( SELECT ISNULL(ITEM_NAME,'') FROM SAL_SAITEM " +
                 "WHERE ITEM_ORGID = @OrgID  " + //'登入者機關代號'
            "AND ITEM_CODE_SYS ='005' " +
            "AND ITEM_CODE_KIND ='D' " +
            "AND ITEM_CODE = INCO_KIND_CODE " +
               ") AS ITEM_NAME " +
            "FROM SAL_SAINCO " +
             "WHERE INCO_ORGID =  @OrgID " + //'登入者機關代號'
            "AND INCO_CODE = '005' " +
            "GROUP BY INCO_KIND_CODE_TYPE ,INCO_KIND_CODE_NO ,INCO_KIND_CODE " +
            "ORDER BY INCO_KIND_CODE_TYPE ,INCO_KIND_CODE_NO ,INCO_KIND_CODE ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID)
        };
        return Query(strSQL, sp);

    }

    // 
    public DataTable queryReportData(
        string strOrgID,        // '登入者機關代碼'
        string strIncoCode,     // '查詢畫面之發放種類代碼'
        string strIncoTypeCode, // '查詢畫面之項目代碼'
        string strIncoDate,     // '查詢畫面之發放日期' 
        string strBaseName,     // '查詢畫面之姓名'
        string strBaseSeqNO,    // '查詢畫面之員工編號' 
        string strBaseProNo,    // '查詢畫面之員工類別'
        string strBaseDep       // '查詢畫面之單位' 
        )
    {
        string strSQL =
            "select base_idno as[身分證字號] ,base_name as[姓名], " +
            "isnull(inco_real_amt,0) as [應發金額],isnull(inco_kdc_amt,0) as [主管加給],isnull(inco_repl_amt,0) as [實物代金],isnull(inco_hous_amt,0) as [房屋津貼], " +
            "isnull(inco_amt,0) as [申報金額] ,isnull(inco_txam,0) as [扣繳稅額] " +
            "from sal_sainco left join sal_sabase " +
            "on inco_orgid = base_orgid " +
            "and inco_seqno = base_seqno " +
            "where inco_orgid = @OrgID " +   //'登入者機關代碼'
            "and inco_code = @IncoCode " ;  // '查詢畫面之發放種類代碼'
        if (strIncoCode=="005")
        {
            strSQL+=
            //-- 如果發放種類為其他薪津，增加此列查詢條件
                "and inco_kind_code = @IncoKindCode " ;   // '查詢畫面之項目代碼'
            }
        strSQL +=
            "and inco_date = @IncoDate ";   // '查詢畫面之發放日期'

        if (strBaseName !="")
        {
            strSQL+=
            //-- 如果輸入查詢條件姓名，增加下列查詢語法
                "and base_name like '%' + @BaseName + '%' " ;   // '查詢畫面之姓名'
        }

        if (strBaseSeqNO!="")
        {
            //-- 如果輸入查詢條件員工編號，增加下列查詢語法
            strSQL+=
            "and base_seqno = @BaseSeqNO " ;       // '查詢畫面之員工編號'
        }

        if (strBaseProNo !="ALL")
        {
            //-- 如果員工類別非全部之選項，增加下列SQL 
        strSQL+=
            "and base_prono in (@BaseProNo) ";    // '查詢畫面之員工類別'
        }

        if (strBaseDep != "ALL")
        {
            //-- 如果單位非全部之選項，增加下列SQL 
            strSQL+=
            "and  (BASE_DEP = @BaseDep or BASE_DEP  in (select depart_id from fsc_org where parent_depart_id=@BaseDep))";    // '查詢畫面之單位'
        }
        strSQL+= 
            "order by isnull(base_prono ,'999'), cast(base_prts as float) ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@IncoCode",strIncoCode),
            new SqlParameter("@IncoKindCode",strIncoTypeCode),
            new SqlParameter("@IncoDate",strIncoDate),
            new SqlParameter("@BaseName",strBaseName),
            new SqlParameter("@BaseSeqNO",strBaseSeqNO),
            new SqlParameter("@BaseProNo",strBaseProNo),
            new SqlParameter("@BaseDep",strBaseDep)
        };
        return Query(strSQL, sp);

    }

}