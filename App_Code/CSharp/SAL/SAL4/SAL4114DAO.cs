using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4114DAO 的摘要描述
/// </summary>
public class SAL4114DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4114DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }

    public SAL4114DAO(SqlConnection conn)
        : base(conn)
    {

    }
 


    //查詢
    public DataTable get_data(string orgid)
    {
        String strSQL =
                  " select * from sal_saunit "
                + " where unit_no=@orgid ";

        SqlParameter[] sp = { 
                            new SqlParameter("@orgid", orgid)                         
                            };
        return Query(strSQL, sp);
    }


    // GridView data
    public DataTable get_GridViewdata(string orgid)
    {
        String strSQL =
                  " select * from sal_saTDPF "
                + " where tdpf_orgid=@orgid ";

        SqlParameter[] sp = { 
                            new SqlParameter("@orgid", orgid)                         
                            };
        return Query(strSQL, sp);
    }

    // delete data
    public DataTable GetDataBySeqno(string orgid,string seqno)
    {
        String strSQL =
                  " select * from sal_saBANK "
                + " where BANK_orgid=@orgid and BANK_TDPF_SEQNO=@seqno ";

        SqlParameter[] sp = { 
                            new SqlParameter("@orgid", orgid)    ,
                            new SqlParameter("@seqno", seqno)     
                            };
        return Query(strSQL, sp);
    }


      // 新增
    public void insert(
                  string orgid
                , string mid
                , string sdno
                , string Mdate
        )
    {
      
        String strSQL =
                 " insert into sal_saTDPF( TDPF_ORGID , TDPF_MUSER, " +
                 " TDPF_SEQNO , TDPF_MDATE,TDPF_BANK ) "
                 + " values(@orgid "
                 + "  ,@mid "
                 + "  ,@sdno "
                 + "  ,@Mdate "
                 + "  ,'999' " 
                 + " )"; 


        SqlParameter[] sp =
        {      
             new SqlParameter("@orgid",orgid),
             new SqlParameter("@mid",mid),
             new SqlParameter("@sdno",sdno),
             new SqlParameter("@Mdate",Mdate)
        };

        Execute(strSQL, sp);
    }

    // 刪除
    public void delete(
                  string orgid
                , string seqno
        )
    {

        String strSQL =  
                   " delete SAL_SATDPF" +
                   " where TDPF_ORGID=@orgid and TDPF_SEQNO=@seqno ";

        SqlParameter[] sp =
        {      
             new SqlParameter("@orgid",orgid),
             new SqlParameter("@seqno",seqno)
        };

        Execute(strSQL, sp);
    }



    // 維護 sal_saunit
    public void queryeditData_unit(
                  string UNIT_DEP
                , string UNIT_NO
                , string UNIT_KIND
                , string UNIT_TAX
                , string UNIT_HNAME
                , string UNIT_CNAME
                , string UNIT_TEL
                , string UNIT_MEDIA
                , string UNIT_AREA
                , string UNIT_ADDR
                , string UNIT_RECOMPENSE_FUND
                , string UNIT_MULTI_MONTHPAY
                , string UNIT_LABOR_CALM_RATE
                , string UNIT_USERID
                , string UNIT_MDATE
        )
    {
        String strSQL =
              "   update sal_saunit "
            + "   set UNIT_DEP = @UNIT_DEP "
            + "   , UNIT_KIND = @UNIT_KIND "
            + "   , UNIT_TAX = @UNIT_TAX "
            + "   , UNIT_HNAME = @UNIT_HNAME "
            + "   , UNIT_CNAME = @UNIT_CNAME "
            + "   , UNIT_TEL = @UNIT_TEL "
            + "   , UNIT_MEDIA = @UNIT_MEDIA "
            + "   , UNIT_AREA = @UNIT_AREA "
            + "   , UNIT_ADDR = @UNIT_ADDR "
            + "   , UNIT_RECOMPENSE_FUND = @UNIT_RECOMPENSE_FUND "
            + "   , UNIT_MULTI_MONTHPAY = @UNIT_MULTI_MONTHPAY "
            + "   , UNIT_LABOR_CALM_RATE = @UNIT_LABOR_CALM_RATE "
            + "   , UNIT_USERID = @UNIT_USERID "
            + "   , UNIT_MDATE = @UNIT_MDATE "
            + "   where UNIT_NO = @UNIT_NO";
         
        
        SqlParameter[] sp =
        {
             new SqlParameter("@UNIT_DEP",UNIT_DEP),
             new SqlParameter("@UNIT_NO",UNIT_NO) ,
             new SqlParameter("@UNIT_KIND",UNIT_KIND), 
             new SqlParameter("@UNIT_TAX",UNIT_TAX),
             new SqlParameter("@UNIT_HNAME",UNIT_HNAME),
             new SqlParameter("@UNIT_CNAME",UNIT_CNAME),
             new SqlParameter("@UNIT_TEL",UNIT_TEL),
             new SqlParameter("@UNIT_MEDIA",UNIT_MEDIA),
             new SqlParameter("@UNIT_AREA",UNIT_AREA),
             new SqlParameter("@UNIT_ADDR",UNIT_ADDR),
             new SqlParameter("@UNIT_RECOMPENSE_FUND",UNIT_RECOMPENSE_FUND),
             new SqlParameter("@UNIT_MULTI_MONTHPAY",UNIT_MULTI_MONTHPAY),
             new SqlParameter("@UNIT_LABOR_CALM_RATE",UNIT_LABOR_CALM_RATE),
             new SqlParameter("@UNIT_USERID",UNIT_USERID),
             new SqlParameter("@UNIT_MDATE",UNIT_MDATE)
        };

        Execute(strSQL, sp);
    }


    // 維護 sal_satdpf
    public void queryeditData_tdpf(
                  string tdpf_orgid
                , string tdpf_bank_no
                , string tdpf_bank
                , string tdpf_medi
                , string tdpf_muser
                , string tdpf_mdate
                , string tdpf_seqno
                , string tdpf_title
                , string tdpf_entno
                , string tdpf_unit
                , string tdpf_branch
                , string tdpf_custom
                , string tdpf_no
                , string tdpf_param
                , string tdpf_memo
        )
    {
        String strSQL =
              "   update SAL_SATDPF "
            + "   set tdpf_bank_no = @tdpf_bank_no "
            + "   , tdpf_bank = @tdpf_bank "
            + "   , tdpf_medi = @tdpf_medi "
            + "   , tdpf_muser = @tdpf_muser "
            + "   , tdpf_mdate = @tdpf_mdate "
            + "   , tdpf_title = @tdpf_title "
            + "   , tdpf_entno = @tdpf_entno "
            + "   , tdpf_unit = @tdpf_unit "
            + "   , tdpf_branch = @tdpf_branch "
            + "   , tdpf_custom = @tdpf_custom "
            + "   , tdpf_no = @tdpf_no "
            + "   , tdpf_param = @tdpf_param "
              + "   , tdpf_memo = @tdpf_memo "
            + "   where tdpf_orgid = @tdpf_orgid and tdpf_seqno = @tdpf_seqno ";


        SqlParameter[] sp =
        {
             new SqlParameter("@tdpf_orgid",tdpf_orgid),
             new SqlParameter("@tdpf_bank_no",tdpf_bank_no) ,
             new SqlParameter("@tdpf_bank",tdpf_bank), 
             new SqlParameter("@tdpf_medi",tdpf_medi),
             new SqlParameter("@tdpf_muser",tdpf_muser),
             new SqlParameter("@tdpf_mdate",tdpf_mdate),
             new SqlParameter("@tdpf_seqno",tdpf_seqno),
             new SqlParameter("@tdpf_title",tdpf_title),
             new SqlParameter("@tdpf_entno",tdpf_entno),
             new SqlParameter("@tdpf_unit",tdpf_unit),
             new SqlParameter("@tdpf_branch",tdpf_branch),
             new SqlParameter("@tdpf_custom",tdpf_custom),
             new SqlParameter("@tdpf_no",tdpf_no),
             new SqlParameter("@tdpf_param",tdpf_param),
             new SqlParameter("@tdpf_memo",tdpf_memo)
        };

        Execute(strSQL, sp);
    }



}