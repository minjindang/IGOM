using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3101DAO 的摘要描述
/// SAL3101 員工基本資料
/// </summary>
public class SAL3101DAO : BaseDAO
{
    public SAL3101DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3101DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 查詢資料 for 順序 Edit
    public DataTable querySalSaBase4ModifyPrts(string v_UserOrgId, string sorting_string)
    {
        string strSQL = "select base_orgid, base_seqno, base_idno, base_name, base_dcode_name, base_ptb, base_prts " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='003' and code_no=base_org_l3),'未設定') as base_org_l3_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='001' and code_no=base_org_l1),'未設定') as base_job_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='006' and code_no=base_org_l2),'未設定') as base_org_l1_name " +
            "from sal_sabase s " +
            " where ( s.base_orgid=@BaseOrgID and s.base_status = 'Y' ) " +
            " and (base_edate='' or base_edate='99999999') " +
            " order by " + sorting_string;
        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",v_UserOrgId)
            };
        return Query(strSQL, sp);
    }

    // 查詢資料
    public DataTable querySalSaBase(string v_UserOrgId, string v_base_status, string v_base_prono, string v_Search_str
        , string v_orderby, string departid, string idcard)
    {
        string strSQL = "select s.base_orgid, s.base_seqno, s.base_idno, s.base_name, base_job,  base_org_l3, base_org_l1, base_org_l2 " +
//            ",isnull((select proj_code_name from sal_saproj where proj_code=base_prono and proj_orgid=s.base_orgid ),'未設定') as job_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='017' and code_no=base_prono),'未設定') as job_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='003' and code_no=base_org_l3),'未設定') as org_l3_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='006' and code_no=base_org_l1),'未設定') as org_l1_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='009' and code_no=base_org_l2),'未設定') as org_l2_name " +
            ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='002' and code_no=base_dcode),'未設定') as base_dcode_name " +
            ",base_retire,base_edate "+
            "from sal_sabase s left outer join sal_sabaseext e on s.base_idno=e.base_idno " +
            " where ( s.base_orgid=@BaseOrgID and s.base_status = 'Y' ) ";


        //,isnull((select code_desc1 from sacode where code_sys='002' and code_kind='P' and code_type='001' and code_no=base_job),'未設定') as job_name " & _
        int vv_base_status = 0;

        if (!String.IsNullOrEmpty(v_base_status.Trim())) vv_base_status = Convert.ToInt32(v_base_status);
        switch (vv_base_status)
        {
            case 0:
                break;
            //' 全部
            case 1:
                //' 在職
                strSQL += " and (s.base_edate='' or s.base_edate='99999999' or s.base_edate is null) and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 2:
                //' 已離職
                strSQL += " and s.base_edate <> '' and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 3:
                //' 已退休
                strSQL += " and e.base_retire='Y'";
                break;
        }

        // 員工類別
        if (v_base_prono != "ALL" && v_base_prono != "")
        {
            strSQL += " and ( s.base_prono = @BaseProNo ) ";
        }
        //單位別
        if (departid != "ALL" && departid != "")
        {
            strSQL += " and ( s.base_DEP like @departid + '%' ) ";
        }
        //idcard
        if (idcard != "ALL" && idcard != "")
        {
            strSQL += " and ( s.base_seqno = @idcard ) ";
        }

        //'身分證字號或姓名
        if (!string.IsNullOrEmpty(v_Search_str))
        {
            //2014/5/21 Fixed Basename->@Basename 
            // Eliot
            strSQL += " and (s.base_seqno =@BaseIDNo OR s.base_name like '%'+@BaseName+'%')";
        }
        //strSQL += " order by isNull(s.base_prts,99999)";
        
        if (string.IsNullOrEmpty(v_orderby))
        {
            strSQL += " order by isNull(s.base_prts,99999)";
        }
        else
        {
            strSQL += " order by ltrim(" + v_orderby + ") ";
        }

        //this.TextBox_Sql_Str.Text = rv;
        

        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",v_UserOrgId),
            new SqlParameter("@BaseProNo", v_base_prono),
            new SqlParameter("@BaseIDNo", v_Search_str),
            new SqlParameter("@BaseName", v_Search_str),
            new SqlParameter("@departid", departid),
            new SqlParameter("@idcard", idcard)
            };
        return Query(strSQL, sp);
    }

    // 查詢單一使用者資料
    public DataTable querySalSaBaseBySeqNo(string strBaseOrgID, string strBaseSeqNO)
    {
        string strSQL =
            "SELECT SAL_SABASE.BASE_Budget_code,SAL_SABASE.BASE_HEALTH_SELF_DESC,SAL_SABASE.BASE_SEQNO,SAL_SABASE.BASE_IDNO,BASE_STATUS,BASE_TYPE,SAL_SABASE.BASE_ORGID,BASE_NAME,BASE_SEX,BASE_JOB_DATE,BASE_DEP," +
            "BASE_BDATE,BASE_EDATE,BASE_JOB,BASE_DCODE,BASE_ORG_L1,BASE_ORG_L2,BASE_ORG_L3,BASE_AGEN,BASE_IN_L1,BASE_IN_L3," +
            "BASE_PTB,BASE_PROV,BASE_ADDR,BASE_QUIT_DATE,BASE_QUIT_REZN,BASE_ERMK,BASE_PRONO,BASE_KDB,BASE_KDC,BASE_KDP," +
            "BASE_KDO,BASE_POL,BASE_HOUS,BASE_WELG,BASE_WELO,BASE_PRE,BASE_OTHER_SAL,BASE_PRED,BASE_PRIZ,BASE_TAX,BASE_FINS_KIND," +
            "BASE_PN_Y30,BASE_FINS_NOQ,BASE_FINS_NOH,BASE_FINS_NOF,BASE_FINS_NOL,BASE_FINS_SELF,BASE_FINS_NO,BASE_DAY_SAL,BASE_HOUR_SAL," +
            "BASE_DCT_A,BASE_DCT_B,BASE_DCT_C,BASE_COUNT_REMARK,BASE_MEMO,SAL_SABASE.BASE_MUSER,SAL_SABASE.BASE_MDATE,BASE_KDC_SERIES,BASE_KDP_SERIES," +
            "BASE_LABOR_SERIES,BASE_PRTS,BASE_FIN_AMT,BASE_TAX_DCT,BASE_LABOR_STATUS,BASE_SENTMAIL,BASE_EMAIL,BASE_FIN_SUP_AMT," +
            "BASE_REPLACE_AMT,BASE_GOVADOF,BASE_LAB_JIF,BASE_FINS_NOQ_NOL,BASE_FINS_NOH_NOL,BASE_FINS_Y65,BASE_FINS_SERIES,BASE_ISMARKED," +
            "BASE_PEN_RATE,BASE_PEN_TYPE,BASE_PROF,BASE_PEN_SERIES,BASE_NUMERATOR,BASE_DENOMINATOR,BASE_PTB_TYPE,BASE_ALT_AMT,BASE_MEMO1," +
            "BASE_MEMO2,BASE_MEMO3,BASE_DCODE_NAME,BASE_SENTMSG,BASE_FINS_HEALTH_SELF,BASE_PROJ_BDATE,BASE_PROJ_EDATE,BASE_LAB1,BASE_LAB2," +
            "BASE_LAB3,BASE_PARTTIME,BASE_FINS_SELF_DESC,BASE_FINS_PAR_DESC,BASE_SERVICE_PLACE_DESC " +
            // 2014/5/9 增加
            ",SAL_SABASE.BASE_RAMT,SAL_SABASE.BASE_NAMT,SAL_SABASE.BASE_MAMT, " +
            // 2014/5/10
            " SAL_SABASEEXT.BASE_BirthDay,SAL_SABASEEXT.BASE_DCODESYS "+
            "FROM SAL_SABASE,SAL_SABASEEXT " +
            "WHERE SAL_SABASE.BASE_SEQNO=@BaseSeqNo " +
            "AND SAL_SABASE.BASE_ORGID=@BaseOrgID " +
            // 2015/5/10 Add
            "AND SAL_SABASE.BASE_IDNO*=SAL_SABASEEXT.BASE_IDNO " +
            "AND SAL_SABASE.BASE_ORGID*=SAL_SABASEEXT.BASE_ORGID ";
        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",strBaseOrgID),
            new SqlParameter("@BaseSeqNo", strBaseSeqNO)
            };
        return Query(strSQL, sp);
    }

    // 查詢奉點
    public DataTable querySaleCom(
        string strLevComOrgL1,
        string strLevComOrgL2,
        string strLevComOrgL3
        )
    {
        string strSQL =
            "SELECT LEVCOM_ORG_L3,LEVCOM_ORG_L1,LEVCOM_PTB,LEVCOM_ORG_L2,LEVCOM_MUSER,LEVCOM_MDATE " +
            "FROM SAL_SALEVCOM " +
            "WHERE LEVCOM_ORG_L3=@LevComOrgL3 " +
            "AND LEVCOM_ORG_L1=@LevComOrgL1 " +
            "AND LEVCOM_ORG_L2=@LevComOrgL2 ";
        SqlParameter[] sp =
            {
            new SqlParameter("@LevComOrgL1",strLevComOrgL1),
            new SqlParameter("@LevComOrgL2",strLevComOrgL2),
            new SqlParameter("@LevComOrgL3", strLevComOrgL3)
            };
        return Query(strSQL, sp);
    }

    // 取得專業加給金額表
    public DataTable queryKdpSeries(
        string strSpesUp
        )
    {
        // Get YM
        string strYM =
            DateTime.Now.ToString("yyyyMM");

        string strSQL =
            "SELECT DISTINCT SPESUP_TYPE,SPESUP_NO,SPESUP_SERIES,SPESUP_SAL " +
            "FROM SAL_SASPESUP " +
            "WHERE SPESUP_TYPE='003' " +
            "AND SPESUP_NO=@SpesUp " +
            "AND SPESUP_YM=@SpesYM ";

        SqlParameter[] sp =
            {
                new SqlParameter("@SpesUp",strSpesUp),
                new SqlParameter("@SpesUp",strYM)
            };
        return Query(strSQL, sp);
    }

    // 取得主管加給金額表
    public DataTable queryKdcSeries(
        string strSpesUp
        )
    {
        // Get YM
        string strYM =
            DateTime.Now.ToString("yyyyMM");

        string strSQL =
            "SELECT DISTINCT SPESUP_TYPE,SPESUP_NO,SPESUP_SERIES,SPESUP_SAL " +
            "FROM SAL_SASPESUP " +
            "WHERE SPESUP_TYPE='004' " +
            "AND SPESUP_NO=@SpesUp " +
            "AND SPESUP_YM=@SpesYM ";

        SqlParameter[] sp =
            {
                new SqlParameter("@SpesUp",strSpesUp),
                new SqlParameter("@SpesYM",strYM)
            };
        return Query(strSQL, sp);
    }

    // 修改 SAL_SABASE
    public int updateSalSaBase(
        string BASE_IDNO,
        string BASE_STATUS,
        string BASE_TYPE,
        string BASE_ORGID,
        string BASE_NAME,
        string BASE_SEX,
        string BASE_JOB_DATE,
        string BASE_DEP,
        string BASE_BDATE,
        string BASE_EDATE,
        string BASE_JOB,
        string BASE_DCODE,
        string BASE_ORG_L1,
        string BASE_ORG_L2,
        string BASE_ORG_L3,
        string BASE_AGEN,
        string BASE_IN_L1,
        string BASE_IN_L3,
        string BASE_PTB,
        string BASE_PROV,
        string BASE_ADDR,
        string BASE_QUIT_DATE,
        string BASE_QUIT_REZN,
        string BASE_ERMK,
        string BASE_PRONO,
        string BASE_KDB,
        string BASE_KDC,
        string BASE_KDP,
        string BASE_KDO,
        string BASE_POL,
        string BASE_HOUS,
        string BASE_WELG,
        string BASE_WELO,
        string BASE_PRE,
        string BASE_OTHER_SAL,
        string BASE_PRED,
        string BASE_PRIZ,
        string BASE_TAX,
        string BASE_FINS_KIND,
        string BASE_PN_Y30,
        string BASE_FINS_NOQ,
        string BASE_FINS_NOH,
        string BASE_FINS_NOF,
        string BASE_FINS_NOL,
        string BASE_FINS_SELF,
        string BASE_FINS_NO,
        string BASE_DAY_SAL,
        string BASE_HOUR_SAL,
        string BASE_DCT_A,
        string BASE_DCT_B,
        string BASE_DCT_C,
        string BASE_COUNT_REMARK,
        string BASE_MEMO,
        string BASE_MUSER,
        string BASE_MDATE,
        string BASE_KDC_SERIES,
        string BASE_KDP_SERIES,
        string BASE_LABOR_SERIES,
        string BASE_PRTS,
        string BASE_FIN_AMT,
        string BASE_TAX_DCT,
        string BASE_LABOR_STATUS,
        string BASE_SENTMAIL,
        string BASE_EMAIL,
        string BASE_FIN_SUP_AMT,
        string BASE_REPLACE_AMT,
        string BASE_GOVADOF,
        string BASE_LAB_JIF,
        string base_fins_noq_nol,
        string base_fins_noh_nol,
        string BASE_FINS_Y65,
        string BASE_FINS_SERIES,
        string Base_IsMarked,
        string BASE_PEN_RATE,
        string BASE_PEN_TYPE,
        string BASE_PROF,
        string BASE_PEN_SERIES,
        string BASE_NUMERATOR,
        string BASE_DENOMINATOR,
        string BASE_PTB_TYPE,
        string BASE_ALT_AMT,
        string BASE_MEMO1,
        string BASE_MEMO2,
        string BASE_MEMO3,
        string BASE_DCODE_NAME,
        string BASE_SENTMSG,
        string BASE_FINS_HEALTH_SELF,
        string BASE_PROJ_BDATE,
        string BASE_PROJ_EDATE,
        string BASE_LAB1,
        string BASE_LAB2,
        string BASE_LAB3,
        string BASE_PARTTIME,
        string BASE_FINS_SELF_DESC,
        string BASE_FINS_PAR_DESC,
        string BASE_SERVICE_PLACE_DESC,

        string BASE_SEQNO,
        string BASE_RAMT,
        string BASE_NAMT,
        string BASE_MAMT,
        string HEALTH_SELF_DESC,
        string Budget_code
        )
    {
        string strSQL =
            "UPDATE SAL_SABASE " +
            "SET BASE_IDNO = @BASE_IDNO " + // <BASE_IDNO, varchar(20),>
            ",BASE_STATUS = @BASE_STATUS " + // <BASE_STATUS, varchar(3),>
            ",BASE_TYPE = @BASE_TYPE " + // <BASE_TYPE, varchar(1),>
            ",BASE_ORGID = @BASE_ORGID " + // <BASE_ORGID, varchar(10),>
            ",BASE_NAME = @BASE_NAME " + // <BASE_NAME, varchar(50),>
            ",BASE_SEX = @BASE_SEX " + // <BASE_SEX, varchar(1),>
            ",BASE_JOB_DATE = @BASE_JOB_DATE " + // <BASE_JOB_DATE, varchar(6),>
            ",BASE_DEP = @BASE_DEP " + // <BASE_DEP, varchar(6),>
            ",BASE_BDATE = @BASE_BDATE " + // <BASE_BDATE, varchar(8),>
            ",BASE_EDATE = @BASE_EDATE " + // <BASE_EDATE, varchar(8),>
            ",BASE_JOB = @BASE_JOB " + // <BASE_JOB, varchar(3),>
            ",BASE_DCODE = @BASE_DCODE " + // <BASE_DCODE, varchar(3),>
            ",BASE_ORG_L1 = @BASE_ORG_L1 " + // <BASE_ORG_L1, varchar(3),>
            ",BASE_ORG_L2 = @BASE_ORG_L2 " + // <BASE_ORG_L2, varchar(3),>
            ",BASE_ORG_L3 = @BASE_ORG_L3 " + // <BASE_ORG_L3, varchar(3),>
            ",BASE_AGEN = @BASE_AGEN " + // <BASE_AGEN, varchar(1),>
            ",BASE_IN_L1 = @BASE_IN_L1 " + // <BASE_IN_L1, varchar(3),>
            ",BASE_IN_L3 = @BASE_IN_L3 " + // <BASE_IN_L3, varchar(3),>
            ",BASE_PTB = @BASE_PTB " + // <BASE_PTB, varchar(4),>
            ",BASE_PROV = @BASE_PROV " + // <BASE_PROV, varchar(2),>
            ",BASE_ADDR = @BASE_ADDR " + // <BASE_ADDR, varchar(60),>
            ",BASE_QUIT_DATE = @BASE_QUIT_DATE " +//<BASE_QUIT_DATE, varchar(8),>
            ",BASE_QUIT_REZN = @BASE_QUIT_REZN " +//<BASE_QUIT_REZN, varchar(3),>
            ",BASE_ERMK = @BASE_ERMK " +//<BASE_ERMK, varchar(1),>
            ",BASE_PRONO = @BASE_PRONO " +//<BASE_PRONO, varchar(3),>
            ",BASE_KDB = @BASE_KDB " +//<BASE_KDB, varchar(3),>
            ",BASE_KDC = @BASE_KDC " +//<BASE_KDC, varchar(3),>
            ",BASE_KDP = @BASE_KDP " +//<BASE_KDP, varchar(3),>
            ",BASE_KDO = @BASE_KDO " +//<BASE_KDO, varchar(1),>
            ",BASE_POL = @BASE_POL " +//<BASE_POL, varchar(1),>
            ",BASE_HOUS = @BASE_HOUS " +//<BASE_HOUS, varchar(1),>
            ",BASE_WELG = @BASE_WELG " +//<BASE_WELG, varchar(1),>
            ",BASE_WELO = @BASE_WELO " +//<BASE_WELO, varchar(3),>
            ",BASE_PRE = @BASE_PRE " +//<BASE_PRE, varchar(3),>
            ",BASE_OTHER_SAL = @BASE_OTHER_SAL " +//<BASE_OTHER_SAL, varchar(1),>
            ",BASE_PRED = @BASE_PRED " +//<BASE_PRED, varchar(4),>
            ",BASE_PRIZ = @BASE_PRIZ " +//<BASE_PRIZ, varchar(1),>
            ",BASE_TAX = @BASE_TAX " +//<BASE_TAX, varchar(1),>
            ",BASE_FINS_KIND = @BASE_FINS_KIND " +//<BASE_FINS_KIND, varchar(3),>
            ",BASE_PN_Y30 = @BASE_PN_Y30 " +//<BASE_PN_Y30, varchar(1),>
            ",BASE_FINS_NOQ = @BASE_FINS_NOQ " +//<BASE_FINS_NOQ, numeric(18,0),>
            ",BASE_FINS_NOH = @BASE_FINS_NOH " +//<BASE_FINS_NOH, numeric(18,0),>
            ",BASE_FINS_NOF = @BASE_FINS_NOF " +//<BASE_FINS_NOF, numeric(18,0),>
            ",BASE_FINS_NOL = @BASE_FINS_NOL " +//<BASE_FINS_NOL, numeric(18,0),>
            ",BASE_FINS_SELF = @BASE_FINS_SELF " +//<BASE_FINS_SELF, numeric(18,2),>
            ",BASE_FINS_NO = @BASE_FINS_NO " +//<BASE_FINS_NO, numeric(18,0),>
            ",BASE_DAY_SAL = @BASE_DAY_SAL " +//<BASE_DAY_SAL, numeric(18,0),>
            ",BASE_HOUR_SAL = @BASE_HOUR_SAL " +//<BASE_HOUR_SAL, numeric(18,0),>
            ",BASE_DCT_A = @BASE_DCT_A " +//<BASE_DCT_A, numeric(2,0),>
            ",BASE_DCT_B = @BASE_DCT_B " +//<BASE_DCT_B, numeric(2,0),>
            ",BASE_DCT_C = @BASE_DCT_C " +//<BASE_DCT_C, numeric(2,0),>
            ",BASE_COUNT_REMARK = @BASE_COUNT_REMARK " +//<BASE_COUNT_REMARK, varchar(1),>
            ",BASE_MEMO = @BASE_MEMO " +//<BASE_MEMO, varchar(1000),>
            ",BASE_MUSER = @BASE_MUSER " +//<BASE_MUSER, varchar(10),>
            ",BASE_MDATE = @BASE_MDATE " +//<BASE_MDATE, varchar(16),>
            ",BASE_KDC_SERIES = @BASE_KDC_SERIES " +//<BASE_KDC_SERIES, varchar(6),>
            ",BASE_KDP_SERIES = @BASE_KDP_SERIES " +//<BASE_KDP_SERIES, varchar(6),>
            ",BASE_LABOR_SERIES = @BASE_LABOR_SERIES " +//<BASE_LABOR_SERIES, varchar(6),>
            ",BASE_PRTS = @BASE_PRTS " +//<BASE_PRTS, numeric(18,1),>
            ",BASE_FIN_AMT = @BASE_FIN_AMT " +//<BASE_FIN_AMT, numeric(18,0),>
            ",BASE_TAX_DCT = @BASE_TAX_DCT " +//<BASE_TAX_DCT, numeric(18,0),>
            ",BASE_LABOR_STATUS = @BASE_LABOR_STATUS " +//<BASE_LABOR_STATUS, varchar(1),>
            ",BASE_SENTMAIL = @BASE_SENTMAIL " +//<BASE_SENTMAIL, varchar(1),>
            ",BASE_EMAIL = @BASE_EMAIL " +//<BASE_EMAIL, varchar(100),>
            ",BASE_FIN_SUP_AMT = @BASE_FIN_SUP_AMT " +//<BASE_FIN_SUP_AMT, numeric(18,0),>
            ",BASE_REPLACE_AMT = @BASE_REPLACE_AMT " +//<BASE_REPLACE_AMT, numeric(18,0),>
            ",BASE_GOVADOF = @BASE_GOVADOF " +//<BASE_GOVADOF, varchar(1),>
            ",BASE_LAB_JIF = @BASE_LAB_JIF " +//<BASE_LAB_JIF, varchar(1),>
            ",base_fins_noq_nol = @base_fins_noq_nol " +//<base_fins_noq_nol, numeric(18,0),>
            ",base_fins_noh_nol = @base_fins_noh_nol " +//<base_fins_noh_nol, numeric(18,0),>
            ",BASE_FINS_Y65 = @BASE_FINS_Y65 " +//<BASE_FINS_Y65, decimal(18,2),>
            ",BASE_FINS_SERIES = @BASE_FINS_SERIES " +//<BASE_FINS_SERIES, varchar(6),>
            ",Base_IsMarked = @Base_IsMarked " +//<Base_IsMarked, varchar(1),>
            ",BASE_PEN_RATE = @BASE_PEN_RATE " +//<BASE_PEN_RATE, decimal(3,1),>
            ",BASE_PEN_TYPE = @BASE_PEN_TYPE " +//<BASE_PEN_TYPE, varchar(1),>
            ",BASE_PROF = @BASE_PROF " +//<BASE_PROF, varchar(2),>
            ",BASE_PEN_SERIES = @BASE_PEN_SERIES " +//<BASE_PEN_SERIES, varchar(2),>
            ",BASE_NUMERATOR = @BASE_NUMERATOR " +//<BASE_NUMERATOR, decimal(3,0),>
            ",BASE_DENOMINATOR = @BASE_DENOMINATOR " +//<BASE_DENOMINATOR, decimal(3,0),>
            ",BASE_PTB_TYPE = @BASE_PTB_TYPE " +//<BASE_PTB_TYPE, varchar(1),>
            ",BASE_ALT_AMT = @BASE_ALT_AMT " +//<BASE_ALT_AMT, numeric(6,0),>
            ",BASE_MEMO1 = @BASE_MEMO1 " +//<BASE_MEMO1, varchar(100),>
            ",BASE_MEMO2 = @BASE_MEMO2 " +//<BASE_MEMO2, varchar(100),>
            ",BASE_MEMO3 = @BASE_MEMO3 " +//<BASE_MEMO3, varchar(100),>
            ",BASE_DCODE_NAME = @BASE_DCODE_NAME " +//<BASE_DCODE_NAME, varchar(50),>
            ",BASE_SENTMSG = @BASE_SENTMSG " +//<BASE_SENTMSG, varchar(1),>
            ",BASE_FINS_HEALTH_SELF = @BASE_FINS_HEALTH_SELF " +//<BASE_FINS_HEALTH_SELF, numeric(18,2),>
            ",BASE_PROJ_BDATE = @BASE_PROJ_BDATE " +//<BASE_PROJ_BDATE, varchar(16),>
            ",BASE_PROJ_EDATE = @BASE_PROJ_EDATE " +//<BASE_PROJ_EDATE, varchar(16),>
            ",BASE_LAB1 = @BASE_LAB1 " +//<BASE_LAB1, varchar(1),>
            ",BASE_LAB2 = @BASE_LAB2 " +//<BASE_LAB2, varchar(1),>
            ",BASE_LAB3 = @BASE_LAB3 " +//<BASE_LAB3, varchar(1),>
            ",BASE_PARTTIME = @BASE_PARTTIME " +//<BASE_PARTTIME, varchar(3),>
            ",BASE_FINS_SELF_DESC = @BASE_FINS_SELF_DESC " +//<BASE_FINS_SELF_DESC, nvarchar(100),>
            ",BASE_FINS_PAR_DESC = @BASE_FINS_PAR_DESC " +//<BASE_FINS_PAR_DESC, nvarchar(100),>
            ",BASE_SERVICE_PLACE_DESC = @BASE_SERVICE_PLACE_DESC " +//<BASE_SERVICE_PLACE_DESC, nvarchar(20),>
            ",BASE_RAMT = @BASE_RAMT " +//<BASE_SERVICE_PLACE_DESC, nvarchar(20),>
            ",BASE_NAMT = @BASE_NAMT " +//<BASE_SERVICE_PLACE_DESC, nvarchar(20),>
            ",BASE_MAMT = @BASE_MAMT " +//<BASE_SERVICE_PLACE_DESC, nvarchar(20),>
            ",BASE_HEALTH_SELF_DESC = @HEALTH_SELF_DESC " +
            ",BASE_Budget_code = @Budget_code " +            
            " WHERE BASE_SEQNO=@BASE_SEQNO ";
      //  strSQL += " Exec dbo.sp_Health_calc_Single 'P', @BASE_ORGID , @BASE_MUSER , '" + DateTime.Now.ToString("yyyyMM") + "' , @BASE_SEQNO ";


        SqlParameter[] sp =
            {
                new SqlParameter("@BASE_IDNO",BASE_IDNO),
                new SqlParameter("@BASE_STATUS",BASE_STATUS),
                new SqlParameter("@BASE_TYPE",BASE_TYPE),
                new SqlParameter("@BASE_ORGID",BASE_ORGID),
                new SqlParameter("@BASE_NAME",BASE_NAME),
                new SqlParameter("@BASE_SEX",BASE_SEX),
                new SqlParameter("@BASE_JOB_DATE",BASE_JOB_DATE),
                new SqlParameter("@BASE_DEP",BASE_DEP),
                new SqlParameter("@BASE_BDATE",BASE_BDATE),
                new SqlParameter("@BASE_EDATE",BASE_EDATE),
                new SqlParameter("@BASE_JOB",BASE_JOB),
                new SqlParameter("@BASE_DCODE",BASE_DCODE),
                new SqlParameter("@BASE_ORG_L1",BASE_ORG_L1),
                new SqlParameter("@BASE_ORG_L2",BASE_ORG_L2),
                new SqlParameter("@BASE_ORG_L3",BASE_ORG_L3),
                new SqlParameter("@BASE_AGEN",BASE_AGEN),
                new SqlParameter("@BASE_IN_L1",BASE_IN_L1),
                new SqlParameter("@BASE_IN_L3",BASE_IN_L3),
                new SqlParameter("@BASE_PTB",BASE_PTB),
                new SqlParameter("@BASE_PROV",BASE_PROV),
                new SqlParameter("@BASE_ADDR",BASE_ADDR),
                new SqlParameter("@BASE_QUIT_DATE",BASE_QUIT_DATE),
                new SqlParameter("@BASE_QUIT_REZN",BASE_QUIT_REZN),
                new SqlParameter("@BASE_ERMK",BASE_ERMK),
                new SqlParameter("@BASE_PRONO",BASE_PRONO),
                new SqlParameter("@BASE_KDB",BASE_KDB),
                new SqlParameter("@BASE_KDC",BASE_KDC),
                new SqlParameter("@BASE_KDP",BASE_KDP),
                new SqlParameter("@BASE_KDO",BASE_KDO),
                new SqlParameter("@BASE_POL",BASE_POL),
                new SqlParameter("@BASE_HOUS",BASE_HOUS),
                new SqlParameter("@BASE_WELG",BASE_WELG),
                new SqlParameter("@BASE_WELO",BASE_WELO),
                new SqlParameter("@BASE_PRE",BASE_PRE),
                new SqlParameter("@BASE_OTHER_SAL",BASE_OTHER_SAL),
                new SqlParameter("@BASE_PRED",BASE_PRED),
                new SqlParameter("@BASE_PRIZ",BASE_PRIZ),
                new SqlParameter("@BASE_TAX",BASE_TAX),
                new SqlParameter("@BASE_FINS_KIND",BASE_FINS_KIND),
                new SqlParameter("@BASE_PN_Y30",BASE_PN_Y30),
                new SqlParameter("@BASE_FINS_NOQ",BASE_FINS_NOQ),
                new SqlParameter("@BASE_FINS_NOH",BASE_FINS_NOH),
                new SqlParameter("@BASE_FINS_NOF",BASE_FINS_NOF),
                new SqlParameter("@BASE_FINS_NOL",BASE_FINS_NOL),
                new SqlParameter("@BASE_FINS_SELF",BASE_FINS_SELF),
                new SqlParameter("@BASE_FINS_NO",BASE_FINS_NO),
                new SqlParameter("@BASE_DAY_SAL",BASE_DAY_SAL),
                new SqlParameter("@BASE_HOUR_SAL",BASE_HOUR_SAL),
                new SqlParameter("@BASE_DCT_A",BASE_DCT_A),
                new SqlParameter("@BASE_DCT_B",BASE_DCT_B),
                new SqlParameter("@BASE_DCT_C",BASE_DCT_C),
                new SqlParameter("@BASE_COUNT_REMARK",BASE_COUNT_REMARK),
                new SqlParameter("@BASE_MEMO",BASE_MEMO),
                new SqlParameter("@BASE_MUSER",BASE_MUSER),
                new SqlParameter("@BASE_MDATE",BASE_MDATE),
                new SqlParameter("@BASE_KDC_SERIES",BASE_KDC_SERIES),
                new SqlParameter("@BASE_KDP_SERIES",BASE_KDP_SERIES),
                new SqlParameter("@BASE_LABOR_SERIES",BASE_LABOR_SERIES),
                new SqlParameter("@BASE_PRTS",BASE_PRTS),
                new SqlParameter("@BASE_FIN_AMT",BASE_FIN_AMT),
                new SqlParameter("@BASE_TAX_DCT",BASE_TAX_DCT),
                new SqlParameter("@BASE_LABOR_STATUS",BASE_LABOR_STATUS),
                new SqlParameter("@BASE_SENTMAIL",BASE_SENTMAIL),
                new SqlParameter("@BASE_EMAIL",BASE_EMAIL),
                new SqlParameter("@BASE_FIN_SUP_AMT",BASE_FIN_SUP_AMT),
                new SqlParameter("@BASE_REPLACE_AMT",BASE_REPLACE_AMT),
                new SqlParameter("@BASE_GOVADOF",BASE_GOVADOF),
                new SqlParameter("@BASE_LAB_JIF",BASE_LAB_JIF),
                new SqlParameter("@base_fins_noq_nol",base_fins_noq_nol),
                new SqlParameter("@base_fins_noh_nol",base_fins_noh_nol),
                new SqlParameter("@BASE_FINS_Y65",BASE_FINS_Y65),
                new SqlParameter("@BASE_FINS_SERIES",BASE_FINS_SERIES),
                new SqlParameter("@Base_IsMarked",Base_IsMarked),
                new SqlParameter("@BASE_PEN_RATE",BASE_PEN_RATE),
                new SqlParameter("@BASE_PEN_TYPE",BASE_PEN_TYPE),
                new SqlParameter("@BASE_PROF",BASE_PROF),
                new SqlParameter("@BASE_PEN_SERIES",BASE_PEN_SERIES),
                new SqlParameter("@BASE_NUMERATOR",BASE_NUMERATOR),
                new SqlParameter("@BASE_DENOMINATOR",BASE_DENOMINATOR),
                new SqlParameter("@BASE_PTB_TYPE",BASE_PTB_TYPE),
                new SqlParameter("@BASE_ALT_AMT",BASE_ALT_AMT),
                new SqlParameter("@BASE_MEMO1",BASE_MEMO1),
                new SqlParameter("@BASE_MEMO2",BASE_MEMO2),
                new SqlParameter("@BASE_MEMO3",BASE_MEMO3),
                new SqlParameter("@BASE_DCODE_NAME",BASE_DCODE_NAME),
                new SqlParameter("@BASE_SENTMSG",BASE_SENTMSG),
                new SqlParameter("@BASE_FINS_HEALTH_SELF",BASE_FINS_HEALTH_SELF),
                new SqlParameter("@BASE_PROJ_BDATE",BASE_PROJ_BDATE),
                new SqlParameter("@BASE_PROJ_EDATE",BASE_PROJ_EDATE),
                new SqlParameter("@BASE_LAB1",BASE_LAB1),
                new SqlParameter("@BASE_LAB2",BASE_LAB2),
                new SqlParameter("@BASE_LAB3",BASE_LAB3),
                new SqlParameter("@BASE_PARTTIME",BASE_PARTTIME),
                new SqlParameter("@BASE_FINS_SELF_DESC",BASE_FINS_SELF_DESC),
                new SqlParameter("@BASE_FINS_PAR_DESC",BASE_FINS_PAR_DESC),
                new SqlParameter("@BASE_SERVICE_PLACE_DESC",BASE_SERVICE_PLACE_DESC),
               new SqlParameter("@BASE_RAMT",BASE_RAMT),
               new SqlParameter("@BASE_NAMT",BASE_NAMT),
               new SqlParameter("@BASE_MAMT",BASE_MAMT),
               new SqlParameter("@HEALTH_SELF_DESC",HEALTH_SELF_DESC),
               new SqlParameter("@Budget_code",Budget_code),
               new SqlParameter("@BASE_SEQNO",BASE_SEQNO)

            };

         return Execute(strSQL, sp);
    }

    // 清除列印順序
    public int clearSalSabasePrts(string strBaseOrgID)
    {
        string strSQL =
            "update sal_sabase set base_prts=0 where base_orgid= @BaseOrgID " +
            " and (base_edate <>'' or base_edate<>'99999999' or 1=1) and (base_status='N') ";
        SqlParameter[] sp =
            {
                new SqlParameter("@BaseOrgID",strBaseOrgID)
            };
        return Execute(strSQL, sp);

    }

    // 修改列印順序
    public int updateSalSabasePrts(
        string strBaseOrgID,
        string strBaseSeqNo,
        string strBasePrts
        )
    {
        string strSQL="update sal_sabase set base_prts =@BasePrts " +
            "where (base_orgid=@BaseOrgID) "+
            "and (base_seqno=@BaseSeqNo) ";
        SqlParameter[] sp =
            {
                new SqlParameter("@BaseSeqNo",strBaseSeqNo),
                new SqlParameter("@BaseOrgID",strBaseOrgID),
                new SqlParameter("@BasePrts",strBasePrts)
            };
        return Execute(strSQL, sp);
    }

    // 刪除個人銀行帳戶資料
    public int deleteSalSabank(
        string strBankOrgID,
        string strBankSeqNo
        )
    {
        string strSQL =
            " delete sal_sabank where bank_orgid= @BankOrgID and bank_seqno= @BankSeqNo ";
        SqlParameter[] sp =
            {
                new SqlParameter("@BankOrgID",strBankOrgID),
                new SqlParameter("@BankSeqNo",strBankSeqNo)
            };
        return Execute(strSQL, sp);

    }

    // 新增個人銀行帳號資料
    public int insertSalSabank(
        string strBankSeqNo,
        string strBankOrgID,
        string strBankCode,
        string strBankBankNo,
        string strBankMUser,
        string strBankTdpfSeqNo
        )
    {
        string strSQL =
            "insert into sal_sabank(BANK_SEQNO,BANK_ORGID,BANK_CODE,BANK_BANK_NO,BANK_MUSER,BANK_MDATE,BANK_TDPF_SEQNO) " +
            " values (" +
            " @BankSeqNo, @BankOrgID, @BankCode, @BankBankNo , @BankMUser , @BankMDate , @BankTdpfSeqNo " +
            ") ";
        string strBankMDate = DateTime.Now.ToString("yyyyMMddhhmmss");

        SqlParameter[] sp =
            {
                new SqlParameter("@BankSeqNo",strBankSeqNo),
                new SqlParameter("@BankOrgID",strBankOrgID),
                new SqlParameter("@BankCode",strBankCode),
                new SqlParameter("@BankBankNo",strBankBankNo),
                new SqlParameter("@BankMUser",strBankMUser),
                new SqlParameter("@BankMDate",strBankMDate),
                new SqlParameter("@BankTdpfSeqNo",strBankTdpfSeqNo)
            };
        return Execute(strSQL, sp);


        // v_seqno, v_orgid, Nothing, v_bank_code, v_bank_no
    }


    public int deleteSalSaPItm(
        string strpitmOrgID,
        string strpitmSeqNo,
        string strPitmCodeSys,
        string strpitmCodeKind,
        string strpitmCodeType
        )
    {
        string strSQL =
            " delete from sal_sapitm " +
            " where pitm_orgid= @pitmOrgID " +
            " and pitm_seqno= @pitmSeqNo " +
            " and pitm_code_sys = @PitmCodeSys " +
            " and pitm_code_kind = @pitmCodeKind " +
            " and pitm_code_type = @pitmCodeType ";
        SqlParameter[] sp =
            {
                new SqlParameter("@pitmOrgID",strpitmOrgID),
                new SqlParameter("@pitmSeqNo",strpitmSeqNo),
                new SqlParameter("@PitmCodeSys",strPitmCodeSys),
                new SqlParameter("@pitmCodeKind",strpitmCodeKind),
                new SqlParameter("@pitmCodeType",strpitmCodeType)
            };
        return Execute(strSQL, sp);

    }

    public int deleteSalSaPItm4OtherSal(
         string strpitmOrgID,
         string strpitmSeqNo
         )
    {
        string strSQL =
            " delete from sal_sapitm " +
            " where pitm_orgid=@PitmOrgID " +
            " and pitm_seqno=@PitmSeqNo " +
            " and exists (select 1 from sal_saitem " +
            "  where item_orgid = pitm_orgid " +
            "  and item_code_sys = pitm_code_sys " +
            "  and item_code_kind = pitm_code_kind " +
            "  and item_code_type = pitm_code_type " +
            "  and item_code_no = pitm_code_no " +
            "  and item_code = pitm_code " +
            "  and item_type = 'Y' " +
            " )";
        SqlParameter[] sp =
            {
                new SqlParameter("@PitmOrgID",strpitmOrgID),
                new SqlParameter("@PitmSeqNo",strpitmSeqNo)
            };
        return Execute(strSQL, sp);

    }


    public int insertSalsaPItm(
        string PITM_ORGID,
        string PITM_SEQNO,
        string PITM_CODE_SYS,
        string PITM_CODE_KIND,
        string PITM_CODE_TYPE,
        string PITM_CODE_NO,
        string PITM_CODE,
        //        string PITM_AMT,
        string PITM_MUSER
        )
    {
        string strSQL =
            "INSERT INTO  SAL_SAPITM " +
                       "( PITM_ORGID  " +
                       ", PITM_SEQNO  " +
                       ", PITM_CODE_SYS  " +
                       ", PITM_CODE_KIND  " +
                       ", PITM_CODE_TYPE  " +
                       ", PITM_CODE_NO  " +
                       ", PITM_CODE  " +
            //                       ", PITM_AMT  "+
                       ", PITM_MUSER  " +
                       ", PITM_MDATE ) " +
                 "VALUES " +
                       "(@PITM_ORGID  " +//varchar(10),>
                       ",@PITM_SEQNO   " +//varchar(20),>
                       ",@PITM_CODE_SYS   " +//varchar(3),>
                       ",@PITM_CODE_KIND  " +//char(1),>
                       ",@PITM_CODE_TYPE   " +//varchar(3),>
                       ",@PITM_CODE_NO   " +//varchar(3),>
                       ",@PITM_CODE   " +//varchar(3),>
            //                       ",@PITM_AMT,   "+//numeric(18,0),>
                       ",@PITM_MUSER  " +// varchar(10),>
                       ",@PITM_MDATE)   ";//varchar(14),>)
        string PITM_MDATE = DateTime.Now.ToString("yyyyMMddhhmmss");
        SqlParameter[] sp =
            {
                new SqlParameter("@PITM_ORGID",PITM_ORGID),
                new SqlParameter("@PITM_SEQNO",PITM_SEQNO),
                new SqlParameter("@PITM_CODE_SYS",PITM_CODE_SYS),
                new SqlParameter("@PITM_CODE_KIND",PITM_CODE_KIND),
                new SqlParameter("@PITM_CODE_TYPE",PITM_CODE_TYPE),
                new SqlParameter("@PITM_CODE_NO",PITM_CODE_NO),
                new SqlParameter("@PITM_CODE",PITM_CODE),
//                new SqlParameter("@PITM_AMT",PITM_AMT),
                new SqlParameter("@PITM_MUSER",PITM_MUSER),
                new SqlParameter("@PITM_MDATE",PITM_MDATE)
            };
        return Execute(strSQL, sp);
    }

    public int insertSalsaPItm(
        string PITM_ORGID,
        string PITM_SEQNO,
        string PITM_CODE_SYS,
        string PITM_CODE_KIND,
        string PITM_CODE_TYPE,
        string PITM_CODE_NO,
        string PITM_CODE,
              string PITM_AMT,
        string PITM_MUSER
        )
    {
        string strSQL =
            "INSERT INTO  SAL_SAPITM " +
                       "( PITM_ORGID  " +
                       ", PITM_SEQNO  " +
                       ", PITM_CODE_SYS  " +
                       ", PITM_CODE_KIND  " +
                       ", PITM_CODE_TYPE  " +
                       ", PITM_CODE_NO  " +
                       ", PITM_CODE  " +
                                 ", PITM_AMT  "+
                       ", PITM_MUSER  " +
                       ", PITM_MDATE ) " +
                 "VALUES " +
                       "(@PITM_ORGID  " +//varchar(10),>
                       ",@PITM_SEQNO   " +//varchar(20),>
                       ",@PITM_CODE_SYS   " +//varchar(3),>
                       ",@PITM_CODE_KIND  " +//char(1),>
                       ",@PITM_CODE_TYPE   " +//varchar(3),>
                       ",@PITM_CODE_NO   " +//varchar(3),>
                       ",@PITM_CODE   " +//varchar(3),>
                                ",@PITM_AMT   "+//numeric(18,0),>
                       ",@PITM_MUSER  " +// varchar(10),>
                       ",@PITM_MDATE)   ";//varchar(14),>)
        string PITM_MDATE = DateTime.Now.ToString("yyyyMMddhhmmss");
        SqlParameter[] sp =
            {
                new SqlParameter("@PITM_ORGID",PITM_ORGID),
                new SqlParameter("@PITM_SEQNO",PITM_SEQNO),
                new SqlParameter("@PITM_CODE_SYS",PITM_CODE_SYS),
                new SqlParameter("@PITM_CODE_KIND",PITM_CODE_KIND),
                new SqlParameter("@PITM_CODE_TYPE",PITM_CODE_TYPE),
                new SqlParameter("@PITM_CODE_NO",PITM_CODE_NO),
                new SqlParameter("@PITM_CODE",PITM_CODE),
                new SqlParameter("@PITM_AMT",PITM_AMT),
                new SqlParameter("@PITM_MUSER",PITM_MUSER),
                new SqlParameter("@PITM_MDATE",PITM_MDATE)
            };
        return Execute(strSQL, sp);
    }


}