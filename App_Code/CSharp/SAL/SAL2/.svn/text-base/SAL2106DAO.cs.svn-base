using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 2014/5/6 Eliot
/// SaCode -> Sys_code
/// SAL2106DAO 的摘要描述
/// </summary>
public class SAL2106DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL2106DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2106DAO(SqlConnection conn)
        : base(conn)
    {

    }
    //銀行項目清單
    public DataTable getSearchData(string strOrgCode)//登入者機關代碼
    {
        String strSQL =
            " select tdpf_seqno"//--銀行代碼(查詢時的索引值) 
          + " , tdpf_bank_no"//--畫面呈現<<>>內帳號資料
         + "  , (select code_desc1 from sys_code where code_orgid = tdpf_orgid and code_sys='004' and code_type = '002' and code_no = tdpf_bank) as bank_name "//--畫面呈現之銀行名稱
         + "  from sal_satdpf "
         + "  where tdpf_orgid= @strOrgCode"
         + "  order by tdpf_bank, tdpf_seqno";


     SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode) // 登入者機關代碼
          
        };

        return Query(strSQL, sp);
    }

    // 取得報表資料
    public DataTable getReportData(  
            string strOrgCode   //登入者機關代碼
            , string strtype     //單位別
            , string strname     //員工姓名
            , string strstatus    //在職狀態
            , string strcno        //人員類別
            , string strno       //員工編號 
            , string strbank  //選取的銀行項目
        )
    {
        String strSQL =
                     " select base_idno  as [身分證字號] , base_name as [姓名] "
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='017' and code_no = base_prono)  as [人員類別]"//--當查詢畫面勾選人員類別項目，增加此查詢欄位
                   + " ,base_sex as [性別]"//--當查詢畫面勾選性別項目，增加此查詢欄位
                   + " ,(base_dep) as [科室]"//--當查詢畫面勾選科室項目，增加此查詢欄位
                   + " ,base_status as [是否府內員工]"//--當查詢畫面勾選是否府內員工項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='001' and code_no = base_job) as [職業類別]"//--當查詢畫面勾選職業類別項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='002' and code_no = base_dcode) as [職稱]"//--當查詢畫面勾選職稱項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='006' and code_no = base_org_l1) as [職等代碼]"//--當查詢畫面勾選職等代碼項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='009' and code_no = base_org_l2) as [年功俸]"//--當查詢畫面勾選年功俸項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='003' and code_no = base_org_l3) as [官等]"//--當查詢畫面勾選官等項目，增加此查詢欄位
                   + " ,base_agen as [是否代理]"//--當查詢畫面勾選是否代理項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='006' and code_no = base_in_l1) as [權理職等]"//--當查詢畫面勾選權理職等項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='002' and code_type='003' and code_no = base_in_l3) as [權理官等]"//--當查詢畫面勾選權理官等項目，增加此查詢欄位
                   + " ,BASE_PROV as [扶養人數]"//--當查詢畫面勾選扶養人數項目，增加此查詢欄位
                   + " ,base_addr as [戶籍地址]"//--當查詢畫面勾選戶籍地址項目，增加此查詢欄位
                   + "  ,base_email as [EMAIL]"//--當查詢畫面勾選EMAIL項目，增加此查詢欄位 
                   + " ,(case base_priz when 'Y' then '全年' when 'N' then '無' when 'T' then '依實際在職月份' else '' end) as [年終獎金]"//--當查詢畫面勾選年終獎金項目，增加此查詢欄位 
                   + " ,base_bdate as [到職日期]"//--當查詢畫面勾選到職日期項目，增加此查詢欄位 
                   + " ,base_edate as [離職日期]"//--當查詢畫面勾選離職日期項目，增加此查詢欄位 
                   + " ,base_quit_date as [停職日期]"//--當查詢畫面勾選停職日期項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='001' and code_type='001' and code_no = base_kdb) as [本俸種類]"//--當查詢畫面勾選本俸種類項目，增加此查詢欄位 
                   + " ,isnull(base_ptb,'') as [本俸俸點]"//--當查詢畫面勾選本俸俸點項目，增加此查詢欄位
                   + " ,case base_ptb_type when '2' then base_alt_amt else (select stan_sal from sal_sastan where stan_ym = (select max(stan_ym) from sal_sastan where stan_no = base_kdb ) and stan_type='001' and stan_no = base_kdb and stan_sal_point = base_ptb) end as [本俸金額]"//--當查詢畫面勾選性別項目，增加此查詢欄位
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='001' and code_type='004' and code_no = base_kdc) as [主管加給種類]"//--當查詢畫面勾選主管加給種類項目，增加此查詢欄位
                   + " ,base_kdc_series as [主管加給級數]"//--當查詢畫面勾選主管加給級數項目，增加此查詢欄位 
                   + " ,(select top 1 spesup_sal from sal_saspesup where spesup_type='004' and spesup_no = base_kdc and spesup_series = base_kdc_series order by spesup_ym desc) as [主管加給金額]"//--當查詢畫面勾選主管加給金額項目，增加此查詢欄位        
                   + " ,(select isnull(code_desc1,'') from sys_code where code_orgid = base_orgid and code_sys='001' and code_type='003' and code_no = base_kdp) as [專業加給種類]"//--當查詢畫面勾選專業加給種類項目，增加此查詢欄位 
                   + " ,base_kdp_series as [專業加給級數]"//--當查詢畫面勾選專業加給級數項目，增加此查詢欄位 
                   + " ,(select top 1 spesup_sal from sal_saspesup where spesup_type='003' and spesup_no = base_kdp and spesup_series = base_kdp_series order by spesup_ym desc) as [專業加給金額]"//--當查詢畫面勾選專業加給金額項目，增加此查詢欄位 
                   + " ,case base_tax when '1' then '照表扣繳' when '2' then '定額扣繳' when '3' then '比例扣繳' when '4' then '比例定額扣繳' when '5' then '5%扣繳' else '無' end as [所得稅扣繳方式]"//--當查詢畫面勾選所得稅扣繳方式項目，增加此查詢欄位
                   + " ,base_fin_amt as [個人健保標準金額]"//--當查詢畫面勾選個人健保標準金額項目，增加此查詢欄位 
                   + " ,base_fin_sup_amt as [機關負擔健保金額]"//--當查詢畫面勾選機關健保標準金額項目，增加此查詢欄位 *****機關健保標準金額
                   + " ,base_day_sal as [日薪]"//--當查詢畫面勾選日薪項目，增加此查詢欄位
                   + " ,base_hour_sal as [時薪]"//--當查詢畫面勾選時薪項目，增加此查詢欄位 
                   + " ,(select case isnull(base_hous,0) when '1' then '700' when '2' then '600' when '3' then '500' when '4' then '400' else '0' end) as [房屋津貼]"//--當查詢畫面勾選房屋津貼項目，增加此查詢欄位 
                   + " ,isnull(base_dct_a,0) as [實物代金眷口數(大口)]"//--當查詢畫面勾選實物代金(大口)項目，增加此查詢欄位 
                   + " ,isnull(base_dct_b,0) as [實物代金眷口數(中口)]"//--當查詢畫面勾選實物代金(中口)項目，增加此查詢欄位 
                   + " ,isnull(base_dct_c,0) as [實物代金眷口數(小口)]"//--當查詢畫面勾選實物代金(小口)項目，增加此查詢欄位 
                   + " ,isnull(base_replace_amt,0)  as [個人實物代金註記]"//--當查詢畫面勾選個人實物代金註記項目，增加此查詢欄位 
                   + " ,isnull(base_fins_no, 0) as [健保眷口總人數]"//--當查詢畫面勾選健保眷口總人數項目，增加此查詢欄位 
                   + " ,isnull(base_fins_nof, 0) as [健保免繳口數(重殘及低收入戶)]"//--當查詢畫面勾選健保免繳口數(重殘及低收入戶)項目，增加此查詢欄位 
                   + " ,isnull(base_fins_nol, 0) as [健保地方補助口數(65歲以上長者)]"//--當查詢畫面勾選健保地方補助口數(65歲以上長者)項目，增加此查詢欄位 
                   + " ,isnull(base_fins_noq, 0) as [健保自付3/4口數(輕殘)]"//--當查詢畫面勾選健保自付3/4口數(輕殘)項目，增加此查詢欄位 
                   + " ,isnull(base_fins_noh, 0) as [健保自付1/2口數(中殘)]"//--當查詢畫面勾選健保自付1/2口數(中殘)項目，增加此查詢欄位 
                   + " ,isnull(base_fins_noq_nol, 0) as [健保自付3/4且是地方補助雙重身份口數(輕殘+65歲以上長者)]"//--當查詢畫面勾選健保自付3/4且是地方補助雙重身份口數(輕殘+65歲以上長者)項目，增加此查詢欄位 
                   + " ,isnull(base_fins_noh_nol, 0) as [健保自付1/2且是地方補助雙重身份口數(中殘+65歲以上長者)]"//--當查詢畫面勾選健保自付1/2且是地方補助雙重身份口數(中殘+65歲以上長者)項目，增加此查詢欄位 
                   + " ,base_memo1 as [備註一]"//--當查詢畫面勾選備註一項目，增加此查詢欄位 
                   + " ,base_memo2 as [備註二]"//--當查詢畫面勾選備註二項目，增加此查詢欄位 
                   + " ,base_memo3 as [備註三]"//--當查詢畫面勾選備註三項目，增加此查詢欄位 
                   + " ,base_memo as [目前選定之備註]"//--當查詢畫面勾選目前選定之備註項目，增加此查詢欄位 
                   + " ,case base_fins_kind when '001' then '公保' when '002' then '勞保' when '003' then '勞保(自訂)' when '004' then '軍保' end as [保險種類]"//--當查詢畫面勾選保險種類項目，增加此查詢欄位 
                   + " ,case base_fins_self when '1.00' then '全額' when '0.75' then '3/4' when '0.50' then '1/2' when '0.00' then '全免' end as [保險自付註記]"//--當查詢畫面勾選健保自付註記項目，增加此查詢欄位 
                   + "  ,case base_Parttime when 'Y' then '是' when 'N' then '否' else '否' end as [是否兼職]";//--當查詢畫面勾選是否兼職項目，增加此查詢欄位 
            // --以迴圈方式取得有勾選之銀行帳號資料
            if (strbank != "")
            {
                string[] oArray = strbank.Split(','); //分解字串
                  if (oArray != null && oArray.Length > 0) 
                 {                    
                     for (int i = 0; i < oArray.Length; i++)
                     {
                         //查出銀行名稱與代號
                        DataTable bankname =getbankname(oArray[i].ToString(),strOrgCode);
                        string strbankname = " ", strbankno="";
                        if (bankname.Rows[0]["bank_name"].ToString() != "")
                        {
                           strbankname = bankname.Rows[0]["bank_name"].ToString();                        
                        }
                        if (bankname.Rows[0]["tdpf_bank_no"].ToString() != "")
                        {
                            strbankno = bankname.Rows[0]["tdpf_bank_no"].ToString();
                        }
                         strSQL += " ,(select '<' + isnull(bank_bank_no,'') + '>' from sal_sabank where bank_seqno = base_seqno and bank_orgid = base_orgid and  bank_tdpf_seqno = '"
                             + oArray[i].ToString() + "') as ["+ strbankname + strbankno+"] ";  //名稱+代號 // 因為名稱=null                                                              
                     } 
                 }  
            }
           strSQL += " from sal_sabase where base_orgid=@strOrgCode";

        if(strtype != "ALL")
        {
            strSQL += " and (BASE_DEP = @strtype or BASE_DEP  in (select depart_id from fsc_org where parent_depart_id=@strtype))";
        }
        if (strname != "")
        {
            strSQL += "  and base_name like '%' + @strname + '%'";  //--當使用者輸入員工姓名欄位時，增加此查詢條件
        }      
        if (strstatus == "0")
        {
            strSQL +=
                "  and base_status = 'Y' and (base_edate='' or base_edate='99999999' or base_edate is null)";
            //--當在職狀態為現職員工時，增加此查詢條件
        }
        else
        {
            strSQL +=
               "  and base_status = 'Y' and (base_edate <> '' and base_edate is not null )";
                //--當在職狀態為離職員工時，增加此查詢條件
        }
        if (strcno != "ALL") 
        {
            strSQL += "  and base_prono in (@strcno)"; //查詢畫面之人員類別代碼
        }
        if (strno != "")
        {
            strSQL += "  and base_seqno = @strno";//--當使用者輸入員工編號欄位時，增加此查詢條件
        }
        strSQL += "  order by base_orgid ,base_status desc ,isnull(base_prono,'9999') ,isnull(base_prts, '9999')";
        
        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  //登入者機關代碼
            new SqlParameter("@strtype",strtype),        // 單位別
            new SqlParameter("@strname",strname),        //員工姓名
            new SqlParameter("@strstatus",strstatus),    //在職狀態
            new SqlParameter("@strcno",strcno),          //人員類別
            new SqlParameter("@strno",strno)             //員工編號
        };

        return Query(strSQL, sp);
    }

    //用銀行代碼查銀行名稱與代號
    public DataTable getbankname(string tdpf_seqno, string strOrgCode)
      {
          string strSQL = " (select tdpf_seqno,tdpf_bank_no,(select code_desc1 from sys_code where code_orgid = tdpf_orgid and code_sys='004' and code_type = '002' and code_no = tdpf_bank) as bank_name "//--畫面呈現之銀行名稱
         + "  from sal_satdpf "
         + "  where tdpf_orgid= @strOrgCode and tdpf_seqno='" + tdpf_seqno + "')";

          SqlParameter[] sp = { new SqlParameter("@strOrgCode", strOrgCode) };//登入者機關代碼 
          return Query(strSQL, sp);
      }
}