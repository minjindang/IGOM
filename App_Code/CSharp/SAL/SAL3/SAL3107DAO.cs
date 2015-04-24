using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3107DAO 的摘要描述
/// SAL3107	年終獎金主管加給維護
/// </summary>
public class SAL3107DAO : BaseDAO
{
    public SAL3107DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    public SAL3107DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable queryUser(
        string v_UserOrgId,     // 組織
        string v_bouns_year,
        string v_base_job,      // 職務類別 
        string v_base_status,   // 在職狀態 
        string v_Search_IDCard, // 員工編號
        string v_Search_Name,   // 姓名
        string strDepart        // 單位   
        )
    {
        //' SQL_select
        string strSQL = "SELECT BASE_SEQNO, BASE_IDNO, BASE_NAME, BASE_ORGID, BASE_JOB, BASE_PRONO, BASE_KDC, BASE_KDC_SERIES, BOUNS_ID," +
                    "BOUNS_ORGID," +
                    "BOUNS_SEQNO," +
                    "BOUNS_YEAR," +
                    "BOUNS_KDC," +
                    "BOUNS_KDC_SERIES," +
                    "BOUNS_KDC_MON," +
                    "BOUNS_MUSER," +
                    "BOUNS_MDATE," +
                    "BOUNS_KDP," +
                    "BOUNS_KDP_SERIES," +
                    "BOUNS_KDP_MON," +
                    "isnull(cast(BOUNS_KDC_AMT as varchar),'')  BOUNS_KDC_AMT," +
                    "isnull(cast(BOUNS_KDP_AMT as varchar),'')  BOUNS_KDP_AMT " +
                "FROM SAL_SABASE, SAL_SASE_BOUNS WHERE " +
                "(SAL_SABASE.BASE_ORGID = SAL_SASE_BOUNS.BOUNS_ORGID AND " +
                "SAL_SABASE.BASE_SEQNO = SAL_SASE_BOUNS.BOUNS_SEQNO " +
                "AND SAL_SABASE.BASE_ORGID = @BaseOrgID ) " +
                "AND (BOUNS_YEAR = @BounsYear ) " +
                "AND (BOUNS_KDC is not null )";

        if (v_base_status == "1")
        {
            strSQL += "AND (BASE_EDATE='' OR base_edate='99999999' OR base_edate IS NULL) ";
        }
        if (v_base_status == "2")
        {
            strSQL += "AND BASE_EDATE <> ''  ";
        }



        //' 單位
        if (v_base_job != "ALL" || v_base_job == "")
        {
            strSQL += "AND (BASE_JOB = @BaseJob ) ";
        }
        //' 職務類別 
        if (strDepart != "ALL" || strDepart == "")
        {
            strSQL += "and (SAL_SABASE.Base_Dep = @BaseDep or SAL_SABASE.Base_Dep in (select depart_id from fsc_org where parent_depart_id=@BaseDep)) ";
        }


        //' 員工編號或姓名
        if (!string.IsNullOrEmpty(v_Search_IDCard))
        {
            strSQL += "AND BASE_SEQNO = @BaseSerNo ";
            //rv += "AND (BASE_IDNO LIKE '%" + vv_Search_str + "%' OR BASE_NAME LIKE '%" + vv_Search_str + "%') ";
        }
        if (!string.IsNullOrEmpty(v_Search_Name))
        {
            strSQL += "AND BASE_NAME = @v_Search_Name ";
            //strSQL += "AND BASE_NAME = LIKE '%" + v_Search_Name.Replace("'", "''") + "%' ";
        }

        strSQL += " order by isNull(base_prts,99999)";

        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",v_UserOrgId),
            new SqlParameter("@BounsYear", v_bouns_year),
            new SqlParameter("@BaseJob", v_base_job),
            new SqlParameter("@BaseDep", strDepart),
            new SqlParameter("@v_Search_Name", v_Search_Name),
            new SqlParameter("@BaseSerNo", v_Search_IDCard)
            };
        return Query(strSQL, sp);
    }

    // 帶入主管加給
    public int insertBouns(
        string v_orgid,
        string v_year,
        string v_muser
        )
    {
        string sql = "";
        sql += " insert SAL_SASE_BOUNS ";
        sql += "(BOUNS_ORGID,BOUNS_SEQNO,BOUNS_YEAR,BOUNS_KDC,BOUNS_KDC_SERIES,BOUNS_KDC_MON,BOUNS_MUSER,BOUNS_MDATE,BOUNS_KDP,BOUNS_KDP_SERIES,BOUNS_KDP_MON,BOUNS_KDC_AMT,BOUNS_KDP_AMT) ";
        sql += " select BASE_ORGID, BASE_SEQNO, @BounsYear ";
        sql += " , BASE_KDC, BASE_KDC_SERIES, '12' ";
        sql += " , @BoundMUser ";
        sql += " ,'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' ";
        sql += " , null, null, null,null,null ";
        sql += " from SAL_SABASE ";
        sql += " where BASE_ORGID = @BaseOrgID ";
        sql += " and BASE_STATUS = 'Y' ";

        //' 有主管加給
        sql += " and (BASE_KDC <> '' and BASE_KDC <> 'N' and BASE_KDC is not NULL ) ";

        //' 在職狀態
        sql += " and ( (BASE_BDATE is NULL) or (BASE_BDATE = '') or (BASE_BDATE < '" + v_year + "9999') ) ";
        sql += " and ( (BASE_EDATE is NULL) or (BASE_EDATE = '') or (BASE_EDATE > '" + v_year + "0000') ) ";

        SqlParameter[] sp =
        {
        new SqlParameter("@BaseOrgID",v_orgid),
        new SqlParameter("@BounsYear", v_year),
        new SqlParameter("@BoundMUser", v_muser)

        };
        return Execute(sql, sp);
    }

    // 帶入主管加給
    public int insertBounswithBaseSeqNO(
        string v_orgid,
        string v_year,
        string v_muser,
        string v_BaseSeqNo
        )
    {
        string sql = "";
        sql += " insert SAL_SASE_BOUNS ";
        sql += "(BOUNS_ORGID,BOUNS_SEQNO,BOUNS_YEAR,BOUNS_KDC,BOUNS_KDC_SERIES,BOUNS_KDC_MON,BOUNS_MUSER,BOUNS_MDATE,BOUNS_KDP,BOUNS_KDP_SERIES,BOUNS_KDP_MON,BOUNS_KDC_AMT,BOUNS_KDP_AMT) ";
        sql += " select BASE_ORGID, BASE_SEQNO, @BounsYear ";
        sql += " , 'Y', BASE_KDC_SERIES, '12' ";
        sql += " , @BoundMUser ";
        sql += " ,'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' ";
        sql += " , null, null, null,null,null ";
        sql += " from SAL_SABASE ";
        sql += " where BASE_ORGID = @BaseOrgID ";
        sql += " AND BASE_SEQNO = @BaseSeqNO ";
//        sql += " and BASE_STATUS = 'Y' ";

        //' 有主管加給
//        sql += " and (BASE_KDC <> '' and BASE_KDC <> 'N' and BASE_KDC is not NULL ) ";

        //' 在職狀態
        sql += " and ( (BASE_BDATE is NULL) or (BASE_BDATE = '') or (BASE_BDATE < '" + v_year + "9999') ) ";
        sql += " and ( (BASE_EDATE is NULL) or (BASE_EDATE = '') or (BASE_EDATE > '" + v_year + "0000') ) ";

        SqlParameter[] sp =
        {
        new SqlParameter("@BaseOrgID",v_orgid),
        new SqlParameter("@BounsYear", v_year),
        new SqlParameter("@BoundMUser", v_muser),
        new SqlParameter("@BaseSeqNO", v_BaseSeqNo)

        };
        return Execute(sql, sp);
    }


    // 檢查資料
    public DataTable CheakSalSaseBouns(
        string v_orgid,
        string v_year
        )
    {
        return CheakSalSaseBouns(v_orgid, v_year, "");
    }

    // 檢查資料 with v_BaseSeqNO
    public DataTable CheakSalSaseBouns(
        string v_orgid,
        string v_year,
        string v_BaseSeqNo
        )
    {
        string sql = "";
        sql += " select * from  SAL_SASE_BOUNS INNER JOIN SAL_SABASE ON BASE_SEQNO=BOUNS_SEQNO ";
        sql += " where BOUNS_ORGID = @BaseOrgID ";
       
        sql += " and Bouns_Year= @BounsYear ";
        sql += " and Bouns_KDC is not null";
        if (v_BaseSeqNo != "" && v_BaseSeqNo != "ALL")
        {
            sql += " AND SAL_SABASE.BASE_SEQNO=@BaseSeqNo ";
        }
        else
        {
            sql += " and BASE_STATUS = 'Y ' ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@BaseOrgID",v_orgid),
            new SqlParameter("@BounsYear", v_year),
            new SqlParameter("@BaseSeqNo", v_BaseSeqNo)
        };
        return Query(sql, sp);

    }



    // 更改資料
    public int updateSalSaseBouns(
        string v_id,
        string v_year,
        string v_kdc,
        string v_kdc_series,
        string v_kdc_mon,
        string v_muser,
        string v_amt// 金額
        )
    {

        String strSQL = "UPDATE SAL_SASE_BOUNS " +
            " SET BOUNS_KDC = @BounsKdc , " +
            " BOUNS_KDC_SERIES = @BounsKdcSeries , " +
            " BOUNS_KDC_MON = @BounsKdcMon ," +
            " BOUNS_MUSER = @BounsMUser, " +
            " BOUNS_MDATE = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'," +
            " BOUNS_KDC_AMT= case @KdcAmt when '' then null else @KdcAmt end " +
            " WHERE BOUNS_ID = @BounsID AND BOUNS_YEAR = @BounsYear";
        SqlParameter[] sp =
        {
            new SqlParameter("@BounsKdc",v_kdc),
            new SqlParameter("@BounsKdcSeries", v_kdc_series),
            new SqlParameter("@BounsKdcMon", v_kdc_mon),
            new SqlParameter("@BounsMUser", v_muser),
            new SqlParameter("@KdcAmt", v_amt),
            new SqlParameter("@BounsID", v_id),
            new SqlParameter("@BounsYear", v_year)
        };
        return Execute(strSQL, sp);
    }




    // 刪除資料
    public int deleteSalSaseBouns(
        string v_id,
        string v_year)
    {
        string strSQL =
            "DELETE FROM SAL_SASE_BOUNS " +
            "WHERE BOUNS_ID = @BounsID AND BOUNS_YEAR = @BounsYear";

        SqlParameter[] sp =
        {
            new SqlParameter("@BounsID", v_id),
            new SqlParameter("@BounsYear", v_year)
        };
        return Execute(strSQL, sp);
    }

    // 
    public DataTable queryBase(
        string v_UserOrgId, 
        string v_Search_Str, 
        string v_Job, 
        string v_Proj, 
        string v_Dept, 
        string v_base_edate, 
        string v_seqno)
    {
        string strSQL =
            " SELECT SAL_SABASE.BASE_IDNO, SAL_SABASE.BASE_NAME, SAL_SABASE.BASE_SEQNO, SAL_SABASE.BASE_Dcode_Name AS Job, c1.CODE_DESC1 AS Class " +
            " FROM SAL_SABASE " +
            " LEFT OUTER JOIN SYS_CODE c1 " +
            " ON SAL_SABASE.BASE_ORG_L3 = c1.CODE_NO " +
            " AND c1.CODE_SYS = '002' " +
            " AND c1.CODE_TYPE = '003' " +
            " WHERE (SAL_SABASE.BASE_ORGID = @BaseOrgID)";
        //' 關鍵字查詢
        if (!string.IsNullOrEmpty(v_Search_Str))
        {
            strSQL += " AND (BASE_NAME like '%'+@BaseName+'%' or BASE_IDNO like '%'+@BaseIDNo+'%' )  ";
        }

        //' 職業類別
        if (v_Job != "ALL")
        {
            strSQL += " and base_job = @BaseJob ";
        }

        //' 人員類別
        if (v_Proj != "ALL")
        {
            strSQL += " and base_prono = @BaseProno ";
        }

        //' 科室
        if (v_Dept != "ALL" && v_Dept != "")
        {
            strSQL += " and base_dep = @BaseDept ";
        }

        //' 在職狀態
        if (v_base_edate == "1")
        {
            //在職
            strSQL += " and (base_edate='' or base_edate='99999999' or base_edate is null) AND SAL_SABASE.BASE_STATUS='Y'";
        }
        if (v_base_edate == "2")
        {
            //已離職
            strSQL += " and base_edate <> '' AND SAL_SABASE.BASE_STATUS='Y'";
        }

        /*
            //' 已選擇人員不顯示
            if (!string.IsNullOrEmpty(v_seqno)) {
                rv += " And BASE_SEQNO NOT IN (" + app.GetSQL_seqno(v_seqno) + ")";
            }
         */

        strSQL += " order by cast(base_prts as float)";

        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",v_UserOrgId),
            new SqlParameter("@BaseName", v_Search_Str),
            new SqlParameter("@BaseIDNo", v_Job),
            new SqlParameter("@BaseJob", v_Proj),
            new SqlParameter("@BaseProno", v_Dept),
            new SqlParameter("@BaseDept", v_seqno)
            };
        return Query(strSQL, sp);

    }



}