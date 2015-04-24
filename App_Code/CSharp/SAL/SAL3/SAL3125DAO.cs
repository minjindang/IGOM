/*
 * Create 2014/3/17 Eliot
 * 勞健保投保金額調整作業
 * 相關資料庫存取
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3125DAO 的摘要描述
/// </summary>
public class SAL3125DAO : BaseDAO
{
    public SAL3125DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3125DAO(SqlConnection conn)
        : base(conn)
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    // 取得 sal_sabase 資料
    public DataTable querySalSaBase(
        string strOrgID,        // 單位代碼
        string strEmployees     // BA人員類別清單
        )
    {
        string strSQL =
            "select SAL_SABASE.BASE_SEQNO " +   //--員工編號
            ", SAL_SABASE.BASE_NAME" +          //--員工姓名
            ", SAL_SABASE.base_orgid " +
            ", SAL_SABASE.base_fins_kind " +
            ", SAL_SABASE.base_labor_status " +
            ", SAL_SABASE.base_labor_series " +
            ", SAL_SABASE.base_lab_jif " +
            ", SAL_SABASE.base_fins_self " +
            ", SAL_SABASE.base_lab1, SAL_SABASE.base_lab2, SAL_SABASE.base_lab3 " +
            ", SAL_SABASE.base_fin_amt " +
            ", SAL_SABASE.base_fins_nol " +
            ", SAL_SABASE.base_fins_noq " +
            ", SAL_SABASE.base_fins_noh " +
            ", SAL_SABASE.base_fins_nof " +
            ", SAL_SABASE.base_fins_noq_nol " +
            ", SAL_SABASE.base_fins_noh_nol " +
            ", SAL_SABASE.base_fins_no " +
            ", SAL_SABASE.BASE_FINS_HEALTH_SELF " +
            ", SAL_SABASE.base_fins_series " +
            ", SAL_SABASE.BASE_BDATE " +
            ", SAL_SABASE.BASE_EDATE " +
            ", SAL_SABASE.BASE_IDNO " +
            ", SAL_SABASEEXT.BASE_BirthDay "+
            "from SAL_SABASE,SAL_SABASEEXT " +
            "where SAL_SABASE.BASE_ORGID = @OrdID " +
            "AND SAL_SABASE.BASE_IDNO*=SAL_SABASEEXT.BASE_IDNO "+
            "and SAL_SABASE.BASE_STATUS = 'Y' ";
        if (strEmployees != "")
        {
            strSQL +=
                "and SAL_SABASE.BASE_PRONO = @Employees ";
        }
        strSQL+=
            "and SAL_SABASE.BASE_FINS_KIND in ('002','003') ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrdID",strOrgID), 
            new SqlParameter("@Employees",strEmployees)
//            new SqlParameter("@Employees",strEmployees), 
         };




        return Query(strSQL, sp);
     }

    // 查詢調升或調降
    public DataTable queryUpandDown1(        
        string strOrgID,        // 單位代碼
        string strEmployees,     // BA人員類別清單
        string strYearMonth
        ,int itype
        )
    {
        string strSQL=
            "Select payo_labor_series,payo_fins_series,base_labor_series,BASE_FINS_SERIES,  "+
            "BASE_SEQNO  "+//     --員工編號
                        ", BASE_NAME  "+//         --員工姓名
                        ", base_orgid   "+
                        ", base_fins_kind   "+
                        ", base_labor_status   "+
                        ", base_labor_series   "+
                        ", base_lab_jif   "+
                        ", base_fins_self   "+
                        ", base_lab1, base_lab2, base_lab3   "+
                        ", base_fin_amt   "+
                        ", base_fins_nol   "+
                        ", base_fins_noq   "+
                        ", base_fins_noh   "+
                        ", base_fins_nof   "+
                        ", base_fins_noq_nol   "+
                        ", base_fins_noh_nol   "+
                        ", base_fins_no   "+
                        ", BASE_FINS_HEALTH_SELF   "+
                        ", base_fins_series   "+
                        ", BASE_BDATE   "+
                        ", BASE_EDATE   "+
            "From sal_sapayo,sal_sabase  "+
            "where BASE_ORGID = @OrdID " +
            "and BASE_STATUS = 'Y' "+
        "AND payo_kind='001'  " +
        "And PAYO_YYMM=@strYearMonth "+
        "and BASE_SEQNO=PAYO_SEQNO  ";
        if (strEmployees != "")
        {
            strSQL +=
                "and BASE_PRONO = @Employees ";
        }
        strSQL +=
            "and BASE_FINS_KIND in ('002','003') ";
        if (itype == 0)
        {
            // 調升
            strSQL +=
                "AND (payo_labor_series>base_labor_series OR payo_fins_series>BASE_FINS_SERIES) ";
        }
        else
        {
            // 調降
            strSQL +=
                "AND (payo_labor_series<base_labor_series OR payo_fins_series<BASE_FINS_SERIES) ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@strYearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@OrdID",strOrgID), 
            new SqlParameter("@Employees",strEmployees)
         };

        return Query(strSQL, sp);
    }




    // 取得年月薪資
    public DataTable querySalaryByYearMonth(
        string strYearMonth,
        string strOrgID,        // 單位代號
        string strBaseSeqNO)    // 人員代號
    {
        string strSQL =
            "Select  isnull(sum(payod_amt),0) as sum_payod_amt  from SAL_SAPAYOD " +
            "where ( (payod_code_sys='003' and payod_code_type='001' and payod_code_no='001')" +
            "or (payod_code_sys='003' and payod_code_type='001' and payod_code_no='003')" +
            "or (payod_code_sys='003' and payod_code_type='001' and payod_code_no='004')" +
            "or (payod_code_sys='003' and payod_code_type='001' and payod_code_no='006'))" +
            "and payod_kind='001' " +  //--月薪
            "and payod_ym=@strYearMonth " + //--依月份各別讀取
            // Add 2014/3/22
            "and payod_orgid = @OrgID " +//—人員清單讀取之base_orgid
            "and payod_seqno = @BaseSeqNO ";//—人員清單讀取之base_seqno


        SqlParameter[] sp =
        {
            new SqlParameter("@strYearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@OrgID",strOrgID), //--年月 YYYYMM
            new SqlParameter("@BaseSeqNO",strBaseSeqNO), //--年月 YYYYMM
         };

        return Query(strSQL, sp);
    }

    // 取得年月加班費
    public DataTable queryOverTimePayByYearMonth(
        string strYearMonth,
        string strOrgID,        // 單位代號
        string strBaseSeqNO)    // 人員代號

    {
        String strSQL =
             "Select  isnull(sum(payod_amt),0) sum_payod_amt  from SAL_SAPAYOD " +
             "where (payod_code_sys='005' and payod_code_type='001' and payod_code_no='601') " +
             "and payod_kind='005' " +//    --其他薪津
             "and payod_ym=@strYearMonth ";// --依月份各別讀取
        // Add 2014/3/22
        strSQL+=
            "and payod_orgid = @OrgID " +//—人員清單讀取之base_orgid
            "and payod_seqno = @BaseSeqNO ";//—人員清單讀取之base_seqno


        SqlParameter[] sp =
        {
             new SqlParameter("@strYearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@OrgID",strOrgID), //--年月 YYYYMM
            new SqlParameter("@BaseSeqNO",strBaseSeqNO), //--年月 YYYYMM
         };

        return Query(strSQL, sp);
    }

    // 取得不休假加班費
    public DataTable queryOverTimePayOfNoLeaveByYearMonth(
        string strYearMonthStart,   // 3個前的年月
        string strYearMonthEnd,
        string strOrgID,        // 單位代號
        string strBaseSeqNO)    // 人員代號
    {
        string strSQL =
             "Select isnull(sum(payod_amt),0) sum_payod_amt  from SAL_SAPAYOD " +
             "where (payod_code_sys='005' and payod_code_type='001' and payod_code_no='655') " +
             "and payod_kind='005' " +//--其他薪津
             "and payod_ym>=@strYearMonthStart " +
             "and payod_ym<=@strYearMonthEnd "; //--讀取回推三個月的金額
        // Add 2014/3/22
        strSQL +=
            "and payod_orgid = @OrgID " +//—人員清單讀取之base_orgid
            "and payod_seqno = @BaseSeqNO ";//—人員清單讀取之base_seqno

           

        SqlParameter[] sp =
        {
            new SqlParameter("@strYearMonthStart",strYearMonthStart), //--年月 YYYYMM
            new SqlParameter("@strYearMonthEnd",strYearMonthEnd), //--年月 YYYYMM
            new SqlParameter("@OrgID",strOrgID), //--年月 YYYYMM
            new SqlParameter("@BaseSeqNO",strBaseSeqNO), //--年月 YYYYMM
         };

        return Query(strSQL, sp);
    }


    // 取得舊勞保投保金額
    public DataTable queryLaborInsuranceOld(
        string strYearMonth,        // 畫面上輸入之年月
        string strBaseLaborSeries   // sal_sabase檔中的base_labor_series
        )
    {
        string strSQL =
            "Select stws_stand, " +  // --投保金額,
            "Stws_dct " +            //--自負額
            "from sal_sastws " +
            "Where stws_ym = " +
            "(select max(stws_ym) from sal_sastws where stws_ym<@YearMonth and stws_type='001') " +
            "And stws_type='001' " +
            "And stws_level=@BaseLaborSeries ";

        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@BaseLaborSeries",strBaseLaborSeries) //--年月 YYYYMM
         };

        return Query(strSQL, sp);
    }

    // 取得舊勞保自付額
    public DataTable queryLaborInsuranceOldPayBySelf(
        string strYearMonth,            // 畫面上輸入之年月
        string strEmployeeNo,           // 員工編號
        string strRegNo                 // 員工所屬機關
        )
    {
        string strSQL =
            "Select  isnull(sum(payod_amt),0) as sum_payod_amt  from SAL_SAPAYOD " +
            " where (payod_code_sys='003' and payod_code_type='002' and payod_code_no='003') " +
            " and payod_kind='001' " +        //--月薪
            " and payod_ym=@YearMonth ";// +     // 畫面上輸入之年月 
        // Marked 2014/3/22
//            " and PAYOD_SEQNO=@EmployeeNo " + // 員工編號   
//            " and PAYOD_ORGID=@RegNo ";      // 員工所屬機關   
        // Add 2014/3/22
        strSQL +=
            "and payod_orgid = @OrgID " +//—人員清單讀取之base_orgid
            "and payod_seqno = @BaseSeqNO ";//—人員清單讀取之base_seqno


        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@BaseSeqNO",strEmployeeNo), //--年月 YYYYMM
            new SqlParameter("@OrgID",strRegNo), //--年月 YYYYMM
         };
        return Query(strSQL, sp);
    }

    // 取得新勞保金額 - 投保金額
    public DataTable queryLaborInsuranceNew(
        string strYearMonth,        // 畫面上輸入之年月
        Single fSalaryAvg3Month     // 三個月平均工資
        )
    {
        string strSQL =
            "Select stws_stand, "+   //--投保金額,
            "STWS_LEVEL "+          //--新勞保級距
            "from sal_sastws "+
            "Where stws_ym = "+
            "(select max(stws_ym)  from sal_sastws where stws_ym<@YearMonth and stws_type='001') " +
            "And stws_type='001' "+
            "And @SalaryAvg3Month between stws_low and stws_up ";

        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYearMonth), //--年月 YYYYMM
            new SqlParameter("@SalaryAvg3Month",fSalaryAvg3Month) //--年月 YYYYMM
         };

        return Query(strSQL, sp);
    }


    // 取得新勞保 自付額
    // 需 Stored Procedure get_labor_fee
    public DataTable queryLaborInsuranceNewPayBySelf(
        string str_base_labor_status,
        string str_base_labor_series,
        string str_YearMonths,
        string str_base_lab_jif,
        string str_base_fins_self,
        string str_bdate,
        string str_edate,
        string str_proj_bdate,
        string str_proj_edate,
        string strOrgID,
        string str_base_lab1,
        string str_base_lab2,
        string str_base_lab3,
        string str_base_fins_kind
        )
    {
        string strSQL =
            "select isnull(dbo.get_labor_fee(" +
            "@base_labor_status, " +
            "@base_labor_series, " +
            "'001'," +
            "@YearMonths," +
            "@base_lab_jif," +
            "@base_fins_self," +
            "Dbo.get_para('006','P','001','010',@YearMonths)," +
            "Dbo.get_para('006','P','001','015',@YearMonths)," +
            "Dbo.get_para('006','P','001','011',@YearMonths)," +
            "Dbo.get_para('006','P','001','012',@YearMonths)," +
            "@base_fins_kind,";
        strSQL +=
            "Dbo.getWorkDays_multi30 " +
            "(@YearMonths,@bdate, " +
            "@edate, " +
            "Dbo.last_day(@YearMonths), " +
            "@proj_bdate, " +
            "@proj_edate, " +
            "'N'), ";
        strSQL +=
            "(select unit_labor_calm_rate from sal_saunit where unit_no=@OrgID),";
        strSQL +=
            "@base_lab1, " +
            "@base_lab2, " +
            "@base_lab3, " +
            "'A' " +
            "),0) as rv ";

        SqlParameter[] sp =
        {
            new SqlParameter("@base_labor_status",str_base_labor_status), 
            new SqlParameter("@base_labor_series",str_base_labor_series), 
            new SqlParameter("@base_fins_kind",str_base_labor_series), 
            new SqlParameter("@YearMonths",str_YearMonths), 
            new SqlParameter("@base_lab_jif",str_base_lab_jif), 
            new SqlParameter("@base_fins_self",str_base_fins_self), 
            new SqlParameter("@bdate",str_bdate), 
            new SqlParameter("@edate",str_edate), 
            new SqlParameter("@proj_bdate",str_proj_bdate), 
            new SqlParameter("@proj_edate",str_proj_edate), 
            new SqlParameter("@OrgID",strOrgID), 
            new SqlParameter("@base_lab1",str_base_lab1), 
            new SqlParameter("@base_lab2",str_base_lab2), 
            new SqlParameter("@base_lab3",str_base_lab3)
        };

        return Query(strSQL, sp);
    }

    public Double getPaiedHealth(string payod_ym_3_age,
        string payod_ym,
        string PAYOD_SEQNO,
        string PAYOD_ORGID
        )
    {
        string strSQL =
            "Select  isnull(sum(payod_amt),0) amt  from SAL_SAPAYOD " +
            "where (payod_code_sys='003' and payod_code_type='002' and payod_code_no='002') " +
            "and payod_kind='001' " +//-月薪
            "and (payod_ym between @payod_ym_3_age and @payod_ym) " +
            "and PAYOD_SEQNO =@PAYOD_SEQNO " +//員工編號
            "And PAYOD_ORGID =@PAYOD_ORGID ";//員工所屬機關
        SqlParameter[] sp =
        {
            new SqlParameter("@payod_ym_3_age",payod_ym_3_age), 
            new SqlParameter("@payod_ym",payod_ym), 
            new SqlParameter("@PAYOD_SEQNO",PAYOD_SEQNO), 
            new SqlParameter("@PAYOD_ORGID",PAYOD_ORGID)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            return Convert.ToDouble(dt.Rows[0]["amt"].ToString());
        }
        else
        {
            return 0;
        }
    }


    public Double getPaiedLabor(
        string payod_ym_3_age,
        string payod_ym,
        string PAYOD_SEQNO,
        string PAYOD_ORGID
        )
    {
        string strSQL=
            "Select  isnull(sum(payod_amt),0) amt  from SAL_SAPAYOD "+ 
            "where (payod_code_sys='003' and payod_code_type='002' and payod_code_no='003') "+
            "and payod_kind='001' "+//-月薪
            "and (payod_ym between @payod_ym_3_age and @payod_ym) "+
            "and PAYOD_SEQNO =@PAYOD_SEQNO "+//員工編號
            "And PAYOD_ORGID =@PAYOD_ORGID ";//員工所屬機關
        SqlParameter[] sp =
        {
            new SqlParameter("@payod_ym_3_age",payod_ym_3_age), 
            new SqlParameter("@payod_ym",payod_ym), 
            new SqlParameter("@PAYOD_SEQNO",PAYOD_SEQNO), 
            new SqlParameter("@PAYOD_ORGID",PAYOD_ORGID)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            return Convert.ToDouble(dt.Rows[0]["amt"].ToString());
        }
        else
        {
            return 0;
        }


    }

    public Double getHelthSelfShould2(
        string BASE_SEQNO,
        string BASE_ORGID
        )
    {
        string strSQL =
            "Select isnull(round(base_fins_health_self*base_fin_amt ,0),0) amt from sal_sabase " +
            "Where BASE_SEQNO=@BASE_SEQNO " +
            "And BASE_ORGID=@BASE_ORGID ";
        SqlParameter[] sp =
        {
            new SqlParameter("@BASE_SEQNO",BASE_SEQNO), 
            new SqlParameter("@BASE_ORGID",BASE_ORGID)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            return Convert.ToDouble(dt.Rows[0]["amt"].ToString());
        }
        else
        {
            return 0;
        }
    }


    public Double getHelthSelfShould1(
        string base_fin_amt,
        string base_fins_nol,
        string base_fins_noq,
        string base_fins_noh,
        string base_fins_nof,
        string base_fins_noq_nol,
        string base_fins_noh_nol,
        string base_fins_no,
        string YearMonths
        )
    {
        string strSQL=
            "select isnull(dbo.count_health( "+
            "@base_fin_amt, "+
            "@base_fins_nol, "+
            "@base_fins_noq, "+
            "@base_fins_noh, "+
            "@base_fins_nof, "+
            "@base_fins_noq_nol, "+
            "@base_fins_noh_nol, "+
            "@base_fins_no, "+
            "dbo.get_para('006','P','006','001', @YearMonths), " +
            "dbo.get_para('006','P','008','007', @YearMonths) " +
            ") " +
            ",0) as rv ";
        SqlParameter[] sp =
        {
            new SqlParameter("@base_fin_amt",base_fin_amt), 
            new SqlParameter("@base_fins_nol",base_fins_nol), 
            new SqlParameter("@base_fins_noq",base_fins_noq), 
            new SqlParameter("@base_fins_noh",base_fins_noh), 
            new SqlParameter("@base_fins_nof",base_fins_nof), 
            new SqlParameter("@base_fins_noq_nol",base_fins_noq_nol), 
            new SqlParameter("@base_fins_noh_nol",base_fins_noh_nol), 
            new SqlParameter("@base_fins_no",base_fins_no), 
            new SqlParameter("@YearMonths",YearMonths)
        };
        DataTable dt = Query(strSQL, sp);
        // 需附額 1
        Double iTemp = Convert.ToDouble(dt.Rows[0]["rv"].ToString());

//        return Query(strSQL, sp);

        return iTemp;

    }


    // 舊健保-投保金額 
    public DataTable queryStws002(
        string strYearMonth,
        string strbase_fins_series
        )
    {
        string strSQL=
            "Select stws_stand "+   //--投保金額
            "from sal_sastws "+
            "Where stws_ym = (select max(stws_ym) from sal_sastws where stws_ym<@YearMonth and stws_type='002') "+
            "And stws_type='002' "+
            "And stws_level= @base_fins_series ";//'sal_sabase.base_fins_series'
        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYearMonth), 
            new SqlParameter("@base_fins_series",strbase_fins_series)
        };

        return Query(strSQL, sp);

    }

    // 新健保--投保額、自付費
    public DataTable queryStws002New(
        string strYearMonth,
        Single fAvg3Month
        )
    {
        string strSQL=
            "Select stws_stand, "+      //--投保金額,
            "STWS_LEVEL, "+             //--新健保級距
            "Stws_dct "+                //--自付額
            "from sal_sastws "+
            "Where stws_ym = (select max(stws_ym) from sal_sastws where stws_ym<@YearMonth and stws_type='002') " +
            "And stws_type='002' "+
            "And @Avg3Month between STWS_LOW and stws_up ";
        SqlParameter[] sp =
        {
            new SqlParameter("@YearMonth",strYearMonth), 
            new SqlParameter("@Avg3Month",fAvg3Month)
        };

        return Query(strSQL, sp);
    }

    // 調整
    public void doAdjestSaBase(
        string strOrgID,        // 單位代號
        string strBaseSeqNO,    // 人員代號
        string strBase_labor_series,    //新勞保級距
        string strBase_fins_series,     // 新健保級距
        Single BASE_FINS_HEALTH_SELF,//自付
        Single Base_fin_amt

    )
    {
        string strSQL =
            "update sal_sabase " +
            "set Base_labor_series=@Base_labor_series " +
            ",Base_fins_series=@Base_fins_series " +
            ",Base_fin_amt=@Base_fins_amt " +
            ",BASE_FINS_HEALTH_SELF=@BASE_FINS_HEALTH_SELF " +
            "where BASE_SEQNO=@BaseSeqNO ";
//            "where payod_orgid = @OrgID " +//—人員清單讀取之base_orgid
//            "and BASE_SEQNO = @BaseSeqNO ";//—人員清單讀取之base_seqno
        SqlParameter[] sp =
        {
//            new SqlParameter("@OrgID",strOrgID), 
            new SqlParameter("@BaseSeqNO",strBaseSeqNO),
            new SqlParameter("@Base_labor_series",strBase_labor_series),
            new SqlParameter("@Base_fins_series",strBase_fins_series),
            new SqlParameter("@Base_fins_amt",Base_fin_amt),
            new SqlParameter("@BASE_FINS_HEALTH_SELF",BASE_FINS_HEALTH_SELF)
        };

        Execute(strSQL, sp);

   }


}