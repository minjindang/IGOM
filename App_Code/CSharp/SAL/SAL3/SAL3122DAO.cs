using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>

/// </summary>
public class SAL3122DAO : BaseDAO
{
	public SAL3122DAO()
	{
		//  
		// TODO: 在此加入建構函式的程式碼
		// 
	}
    public SAL3122DAO(SqlConnection conn) 
        : base(conn)
    {

    }

    public DataTable queryData(
            string strOrgCode           
        )
    {
        string strSQL =
     " select * from sal_SAUPUNIT where UPUNIT_NO = @strOrgCode ";

            SqlParameter[] sp =
            {           
            new SqlParameter("@strOrgCode",strOrgCode)        
            };
            return Query(strSQL, sp);
    }


    public DataTable queryGridData(
          string v_YM,
        string Str
      )
    {
        string strSQL =
                  " select UPORG_TABID, UPORG_TABID, C.UPTCL_TABNAME, C.UPTCL_TYPE, COUNT(UPEMP_AMT) AS TotCnt, SUM(UPEMP_AMT) AS TotAmt "
                + " from sal_SAUPTCL C, sal_SAUPORG G "
                + " left join sal_SAUPEMP "
                + " on UPEMP_ORGID = UPORG_ID "
                + " and UPEMP_TABID = UPORG_TABID "
                + " and UPEMP_YM = @v_YM "
                + " where G.UPORG_TABID = C.UPTCL_TABID "
                + " and " + Str
                + " and G.UPORG_TABID not in ('G1001-0','G1002-0','G1003-0','G1004-0') "
                + " group by UPORG_TABID, C.UPTCL_TABNAME, C.UPTCL_TYPE "
                + " order by G.UPORG_TABID ";
            
        SqlParameter[] sp =
            {           
                new SqlParameter("@v_YM",v_YM)                
            };
        return Query(strSQL, sp);
    }

        
    public void querydeleteData(
      string v_YM,
      string strOrgCode,
      string vTabID    
   )
    {
        string strSQL =
                " DELETE sal_SAUPEMP WHERE UPEMP_YM = @v_YM AND UPEMP_ORGID = @strOrgCode "
              + " AND UPEMP_TABID = @vTabID";

        SqlParameter[] sp =
        {            
            new SqlParameter("@v_YM",v_YM) ,
            new SqlParameter("@strOrgCode",strOrgCode) , 
            new SqlParameter("@vTabID",vTabID)          
        };

        Execute(strSQL, sp);
    }
    

    public DataTable queryData1(
         string strOrgCode,
        string v_YM
     )
    {
        string strSQL =
          " SELECT BASE_SEQNO SEQNO,BASE_ORGID ORGID, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
        + " FROM sal_SAPAYOD, sal_SABASE "
        + " WHERE PAYOD_ORGID=@strOrgCode "
        + " AND PAYOD_YM = @v_YM "
        + " AND BASE_KDB = '001' "
        + " and base_prono <> '006' "
        + " AND payod_kind = '001' "
        + " AND PAYOD_CODE_SYS = '003' "
        + " AND PAYOD_CODE_KIND = 'P' "
        + " AND PAYOD_CODE_NO = '001' "
        + " AND PAYOD_CODE_TYPE = '001' "
        + " and payod_orgid = base_orgid "
        + " AND PAYOD_SEQNO = BASE_SEQNO "
        + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }


    public void querydelete1_1(
     string v_YM,
    string strOrgCode,
    string tabid  
 )
    {

        string strSQL =
         " delete sal_saupemp where UPEMP_YM=@v_YM  and UPEMP_ORGID= @strOrgCode  and UPEMP_TABID= @tabid ";      

        SqlParameter[] sp =
        {            
            new SqlParameter("@v_YM",v_YM) ,
            new SqlParameter("@strOrgCode",strOrgCode) , 
            new SqlParameter("@tabid",tabid) 
        };

        Execute(strSQL, sp);
    }


    public void querydelete1(
       string v_YM,
      string strOrgCode,
      string tabid,
      string t_orgid,
      string t_seqno,
      string t_amt,
      string t_type,
      string t_class,
      string t_qty,
      string t_kind,
      string t_FType,
      string t_DType   
   )
       {

           string strSQL = 
      //      " delete sal_saupemp where UPEMP_YM=@v_YM  and UPEMP_ORGID= @strOrgCode  and UPEMP_TABID= @tabid "
            " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT "
          + " , UPEMP_TYPE, UPEMP_CLASS, UPEMP_QTY, UPEMP_KIND "
          + " , UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
          + " VALUES (@v_YM , @t_orgid , @tabid , @t_seqno , ";
           if (t_amt != "NULL")
           {
               strSQL += " @t_amt";
           }
           else
           {
               strSQL += "NULL";
           }
           if (t_type != "NULL")
           {
               strSQL += ",@t_type";
           }
           else
           {
               strSQL += ",NULL";
           }
           if (t_class != "NULL")
           {
               strSQL += " ,@t_class";
           }
           else
           {
               strSQL += ",NULL";
           }
           if (t_qty != "NULL")
           {
               strSQL += " , @t_qty";
           }
           else
           {
               strSQL += ",NULL";
           }
        if(t_kind!="NULL")
        {
           strSQL += ", @t_kind";        
        }
        else
        {
            strSQL += ",NULL";
        }
        strSQL += ",  @t_FType , @t_DType , getdate() )";           
        
           SqlParameter[] sp =
        {            
            new SqlParameter("@v_YM",v_YM) ,
            new SqlParameter("@strOrgCode",strOrgCode) , 
            new SqlParameter("@tabid",tabid)  ,        
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@t_seqno",t_seqno) , 
            new SqlParameter("@t_amt",t_amt)  ,        
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_class",t_class) , 
            new SqlParameter("@t_qty",t_qty)  ,        
            new SqlParameter("@t_kind",t_kind) ,
            new SqlParameter("@t_FType",t_FType) , 
            new SqlParameter("@t_DType",t_DType)  
        };

           Execute(strSQL, sp);
       }


    public DataTable queryData2(
       string strOrgCode,
       string v_YM
   )
    {
        string strSQL =
                " SELECT BASE_SEQNO SEQNO,BASE_ORGID ORGID, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
            + " FROM sal_SAPAYOD, sal_SABASE "
            + " WHERE PAYOD_ORGID=@strOrgCode "
            + " AND PAYOD_YM = @v_YM "
            + " AND payod_kind = '001' "
            + " AND BASE_KDB = '004' "
            + " AND PAYOD_CODE_SYS = '003' "
            + " AND PAYOD_CODE_KIND = 'P' "
            + " AND PAYOD_CODE_NO = '001' "
            + " AND PAYOD_CODE_TYPE = '001' "
            + " and payod_orgid = base_orgid "
            + " AND PAYOD_SEQNO = BASE_SEQNO "
            + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }


    public DataTable queryData3(
     string strOrgCode,
     string v_YM
 )
    {
        string strSQL =
          " SELECT BASE_SEQNO SEQNO,BASE_ORGID ORGID, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
        + " FROM sal_SAPAYOD, sal_SABASE "
        + " WHERE PAYOD_ORGID= @strOrgCode "
        + " AND PAYOD_YM = @v_YM  "
        + " AND BASE_KDB = '013' "
        + " AND PAYOD_CODE_SYS = '003' "
        + " AND PAYOD_CODE_KIND = 'P' "
        + " AND PAYOD_CODE_NO = '001' "
        + " AND PAYOD_CODE_TYPE = '001' "
        + " and payod_orgid = base_orgid "
        + " AND PAYOD_SEQNO = BASE_SEQNO "
        + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }



    public DataTable queryData4(
    string strOrgCode,
    string v_YM
)
    {
        string strSQL =
          " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
        + " FROM sal_SAPAYOD inner join sal_SABASE on base_seqno=payod_seqno "
        + " inner join sal_SApayo on payo_seqno=payod_seqno and payo_orgid=payod_orgid and payo_kind=payod_kind and payo_date=payod_date and payo_yymm=payod_ym "
        + " WHERE PAYOD_ORGID=@strOrgCode "
        + " AND PAYOD_YM = @v_YM "
        + " AND (PAYO_PRONO='002' or PAYO_PRONO='003') "
        + " AND PAYO_dcode='141'"
        + " AND payod_kind = '001' "
        + " AND PAYOD_CODE_SYS = '003' "
        + " AND PAYOD_CODE_KIND = 'P' "
        + " AND PAYOD_CODE_NO = '001' "
        + " AND PAYOD_CODE_TYPE = '001' "
        + " and payod_orgid = base_orgid "
        + " AND PAYOD_SEQNO = BASE_SEQNO "
        + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }


    public DataTable queryData5(
         string strOrgCode,
         string v_YM
)
    {
        string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD inner join sal_SABASE on base_seqno=payod_seqno "
                + " inner join sal_SApayo on payo_seqno=payod_seqno and payo_orgid=payod_orgid and payo_kind=payod_kind and payo_date=payod_date and payo_yymm=payod_ym "
                + " WHERE PAYOD_ORGID=@strOrgCode "
                + " AND PAYOD_YM = @v_YM "
                + " AND BASE_KDB = '003' "
                + " AND payod_kind = '001' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }


       public DataTable queryData6(
             string strOrgCode,
             string v_YM
)
    {
        string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD inner join sal_SABASE on base_seqno=payod_seqno "
                + " inner join sal_SApayo on payo_seqno=payod_seqno and payo_orgid=payod_orgid and payo_kind=payod_kind and payo_date=payod_date and payo_yymm=payod_ym "
                + " WHERE PAYOD_ORGID=@strOrgCode "
                + " AND PAYOD_YM = @v_YM "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND BASE_KDB = '009'"
                + " AND PAYO_PRONO='004'"
                + " AND PAYO_dcode='178'"
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

        SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
        return Query(strSQL, sp);
    }



       public DataTable queryData7(
            string strOrgCode,
            string v_YM
)
       {
           string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD inner join sal_SABASE on base_seqno=payod_seqno "
                + " inner join sal_SApayo on payo_seqno=payod_seqno and payo_orgid=payod_orgid and payo_kind=payod_kind and payo_date=payod_date and payo_yymm=payod_ym "
                + " WHERE PAYOD_ORGID=@strOrgCode "
                + " AND PAYOD_YM = @v_YM "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND BASE_KDB = '009' "
                + " AND PAYO_PRONO='004'"
                + " AND PAYO_dcode='179'"
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }




       public DataTable queryData8(
            string strOrgCode,
            string v_YM
)
       {
           string strSQL =
                 " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD, sal_SABASE "
                       + " WHERE PAYOD_ORGID=@strOrgCode "
                       + " AND PAYOD_YM = @v_YM  "
                       + " AND payod_kind = '001' "
                       + " AND BASE_KDP = '001' "
                       + " AND PAYOD_CODE_SYS = '003' "
                       + " AND PAYOD_CODE_KIND = 'P' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " AND PAYOD_CODE_NO = '003' "
                       + " and payod_orgid = base_orgid "
                       + " AND PAYOD_SEQNO = BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData9(
           string strOrgCode,
           string v_YM
)
       {
           string strSQL =
                    " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND BASE_KDP = '011' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '003' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData10(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND BASE_KDP = '005' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '003' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData11(
           string strOrgCode,
           string v_YM
)
       {
           string strSQL =
                   " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND BASE_KDP = '019' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '003' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData12(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                 " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode"
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND BASE_KDP = '020' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '003' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData13(
           string strOrgCode,
           string v_YM
)
       {
           string strSQL =
                " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD, sal_SABASE "
                       + " WHERE PAYOD_ORGID=@strOrgCode "
                       + " AND PAYOD_YM = @v_YM  "
                       + " AND payod_kind = '001' "
                       + " AND BASE_KDP = '024' "
                       + " AND PAYOD_CODE_SYS = '003' "
                       + " AND PAYOD_CODE_KIND = 'P' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " AND PAYOD_CODE_NO = '003' "
                       + " and payod_orgid = base_orgid "
                       + " AND PAYOD_SEQNO = BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }




       public DataTable queryData14(
           string strOrgCode,
           string v_YM
)
       {
           string strSQL =
                 " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND BASE_KDC = '001' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '004' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData15(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                 " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND BASE_KDC = '002' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '004' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData16(
             string strOrgCode,
             string v_YM
  )
       {
           string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '001' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '004' "
                        + " AND BASE_KDC = '010' "
                        + " and payod_amt > 0 "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData17(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                    " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD, sal_SABASE "
                       + " WHERE PAYOD_ORGID=@strOrgCode "
                       + " AND PAYOD_YM = @v_YM "
                       + " AND PAYOD_KIND = '001' "
                       + " AND PAYOD_CODE_SYS = '003' "
                       + " AND PAYOD_CODE_KIND = 'P' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " AND PAYOD_CODE_NO = '006' "
                       + " AND PAYOD_CODE='007'"
                       + " and payod_orgid = base_orgid "
                       + " AND PAYOD_SEQNO = BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData18(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                    " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD, sal_SABASE "
                       + " WHERE PAYOD_ORGID=@strOrgCode "
                       + " AND PAYOD_YM = @v_YM  "
                       + " AND PAYOD_KIND = '001' "
                       + " AND PAYOD_CODE_SYS = '003' "
                       + " AND PAYOD_CODE_KIND = 'P' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " AND PAYOD_CODE_NO = '006' "
                       + " AND PAYOD_CODE='008'"
                       + " and payod_orgid = base_orgid "
                       + " AND PAYOD_SEQNO = BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData19(
            string strOrgCode,
            string v_YM
 )
       {
           string strSQL =
                    " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND PAYOD_KIND = '001' "
                        + " AND PAYOD_CODE_SYS = '003' "
                        + " AND PAYOD_CODE_KIND = 'P' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '006' "
                        + " AND PAYOD_CODE='009'"
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData20(
           string strOrgCode,
           string v_YM
)
       {
           string YM = v_YM;
           string strSQL =
                   " SELECT SAL_SABASE.BASE_SEQNO SEQNO, sal_SABASE.BASE_IDNO AS IDNO, sal_SABASE.BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID,0 as  QTY " //e.QTY
                      + " FROM sal_SAPAYOD " +     
                      "inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                      + " inner join sal_SABASEEXT on sal_SABASE.base_idno=sal_SABASEEXT.BASE_IDNO "
                   //   + " inner join (select edu_seqno ,count(Distinct EDU_IDNO) as 'QTY' from sal_saedu where Edu_Year = '" + 
                   //   YM.Substring(0, 4) + "' group by edu_seqno) e on e.edu_seqno=base_seqno"
                      + " WHERE PAYOD_ORGID=@strOrgCode "
                      + " AND PAYOD_YM = @v_YM "
                      + " AND SAL_SABASE.BASE_PRONO <> '006'"
                      + " AND isnull(sal_SABASEEXT.BASE_RETIRE,'') <> 'Y'"
                      + " AND payod_kind = '005' "
                      + " AND PAYOD_CODE_SYS = '005' "
                      + " AND PAYOD_CODE_KIND = 'D' "
                      + " AND PAYOD_CODE_NO = '501' "
                      + " AND PAYOD_CODE_TYPE = '001' "
                      + " and payod_orgid = sal_SABASE.base_orgid "
                      + " AND PAYOD_SEQNO = sal_SABASE.BASE_SEQNO "
                      + " ORDER BY BASE_NAME ";
          
           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData21(
        string strOrgCode,
        string v_YM
)
       {
           string strSQL =
                        " SELECT sal_sabase.BASE_SEQNO SEQNO, sal_SABASE.BASE_IDNO AS IDNO, sal_SABASE.BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                        + " WHERE PAYOD_ORGID= @strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '005' "
                        + " AND PAYOD_CODE_SYS = '005' "
                        + " AND PAYOD_CODE_KIND = 'D' "
                        + " AND PAYOD_CODE_NO = '502' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " and payod_orgid = sal_SABASE.base_orgid "
                        + " AND PAYOD_SEQNO = sal_SABASE.BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData22(
        string strOrgCode,
        string v_YM
)
       {
           string strSQL =
                         " SELECT sal_SABASE.BASE_SEQNO SEQNO, sal_sabase.BASE_IDNO AS IDNO, sal_sabase.BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                        + " WHERE PAYOD_ORGID=@strOrgCode "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND payod_kind = '005' "
                        + " AND PAYOD_CODE_SYS = '005' "
                        + " AND PAYOD_CODE_KIND = 'D' "
                        + " AND PAYOD_CODE_NO = '502' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " and payod_orgid = sal_sabase.base_orgid "
                        + " AND PAYOD_SEQNO = sal_sabase.BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData23(
        string strOrgCode,
        string v_YM
)
       {
           string strSQL =
                       " SELECT sal_sabase.BASE_SEQNO SEQNO, sal_sabase.BASE_IDNO AS IDNO, sal_sabase.BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                       + " WHERE PAYOD_ORGID=@strOrgCode "
                       + " AND PAYOD_YM = @v_YM  "
                       + " AND payod_kind = '005' "
                       + " AND PAYOD_CODE_SYS = '005' "
                       + " AND PAYOD_CODE_KIND = 'D' "
                       + " AND PAYOD_CODE_NO = '502' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " and payod_orgid = sal_sabase.base_orgid "
                       + " AND PAYOD_SEQNO = sal_sabase.BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }




       public DataTable queryData24(
       string strOrgCode,
       string v_YM
)
       {
           string strSQL =
                 " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                       + " FROM sal_SAPAYOD, sal_SABASE "
                       + " WHERE PAYOD_ORGID= @strOrgCode "
                       + " AND PAYOD_YM = @v_YM  "
                       + " AND payod_kind = '005' "
                       + " AND PAYOD_CODE_SYS = '005' "
                       + " AND PAYOD_CODE_KIND = 'D' "
                       + " AND PAYOD_CODE_TYPE = '001' "
                       + " AND PAYOD_CODE_NO = '603' "
                       + " and payod_orgid = base_orgid "
                       + " AND PAYOD_SEQNO = BASE_SEQNO "
                       + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData25(
       string strOrgCode,
       string v_YM
)
       {
           string strSQL =
                  " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                        + " FROM sal_SAPAYOD, sal_SABASE "
                        + " WHERE PAYOD_ORGID= @strOrgCode "
                        + " AND PAYOD_YM = @v_YM "
                        + " AND BASE_PRONO <> '007' "
                        + " AND payod_kind = '005' "
                        + " AND PAYOD_CODE_SYS = '005' "
                        + " AND PAYOD_CODE_KIND = 'D' "
                        + " AND PAYOD_CODE_TYPE = '001' "
                        + " AND PAYOD_CODE_NO = '603' "
                        + " and payod_orgid = base_orgid "
                        + " AND PAYOD_SEQNO = BASE_SEQNO "
                        + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode)      ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData26(
          string v_PAYOD_CODE_SYS,
          string v_PAYOD_CODE_KIND,
          string v_PAYOD_CODE_TYPE,
          string v_PAYOD_CODE_NO,
          string v_YM
  )
       {
           string strSQL =
                          "select sum(Payod_amt) as orgamt from sal_SAPAYOD "
                        + " inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno"
                        + " inner join sal_SABASEEXT on sal_SABASE.base_idno=sal_SABASEEXT.BASE_IDNO where" 
                        + " PAYOD_CODE_SYS= @v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE  and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                        + " AND PAYOD_YM = @v_YM  "
                        + " AND isnull(sal_SABASEEXT.BASE_RETIRE,'') = 'Y'";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData27(
          string v_PAYOD_CODE_SYS,
          string v_PAYOD_CODE_KIND,
          string v_PAYOD_CODE_TYPE,
          string v_PAYOD_CODE_NO,
          string v_YM
  )
       {
           string strSQL =
                          "select sum(Payod_amt) as orgamt from sal_SAPAYOD "
                        + " inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno"
                        + " inner join sal_SABASEEXT on sal_SABASE.base_idno=sal_SABASEEXT.BASE_IDNO where"
                        + " PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE  and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                        + " AND PAYOD_YM = @v_YM "
                        + " AND sal_sabase.BASE_PRONO = '006'"
                        + " AND isnull(sal_SABASEEXT.BASE_RETIRE,'') <> 'Y'";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData28(
           string v_PAYOD_CODE_SYS,
           string v_PAYOD_CODE_KIND,
           string v_PAYOD_CODE_TYPE,
           string v_PAYOD_CODE_NO,
           string v_YM
   )
       {
           string strSQL =
                  "select sum(Payod_amt) as orgamt from sal_SAPAYOD where"
                + " PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                + " AND PAYOD_YM = @v_YM ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }
     



       public DataTable queryData29(
          string v_PAYOD_CODE_SYS,
          string v_PAYOD_CODE_KIND,
          string v_PAYOD_CODE_TYPE,
          string v_PAYOD_CODE_NO,
          string v_YM
  )
       {
           string strSQL =
                        "select sum(Payod_amt) as orgamt from sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno  where"
                      + " BASE_PRONO='007' and  PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND  and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO= @v_PAYOD_CODE_NO "
                      + " AND PAYOD_YM = @v_YM ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData30(
          string v_PAYOD_CODE_SYS,
          string v_PAYOD_CODE_KIND,
          string v_PAYOD_CODE_TYPE,
          string v_PAYOD_CODE_NO,
          string v_YM
  )
       {
           string strSQL =
                          "select sum(Payod_amt) as orgamt from sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                        + " inner join sal_SABASEEXT on sal_SABASE.base_idno=sal_SABASEEXT.BASE_IDNO  where "
                        + " PAYOD_KIND='004' and  PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                        + " AND SUBSTRING(PAYOD_DATE,1,6) = @v_YM  AND isnull(sal_SABASEEXT.BASE_RETIRE,'') <> 'Y'";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public DataTable queryData31(
         string v_PAYOD_CODE_SYS,
         string v_PAYOD_CODE_KIND,
         string v_PAYOD_CODE_TYPE,
         string v_PAYOD_CODE_NO,
         string v_YM
 )
       {
           string strSQL =
                  "select sum(Payod_amt) as orgamt from sal_SAPAYOD where"
                + " PAYOD_KIND='003' and  PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND  and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                + " AND SUBSTRING(PAYOD_DATE,1,6) = @v_YM ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }
    

       public DataTable queryData32(
        string v_PAYOD_CODE_SYS,
        string v_PAYOD_CODE_KIND,
        string v_PAYOD_CODE_TYPE,
        string v_PAYOD_CODE_NO,
        string v_YM
)
       {
           string strSQL =
                          "select sum(Payod_amt) as orgamt from sal_SAPAYOD where "
                        + " PAYOD_KIND='002' and  PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                        + " AND SUBSTRING(PAYOD_DATE,1,6) = @v_YM ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }


       public DataTable queryData33(
        string v_PAYOD_CODE_SYS,
        string v_PAYOD_CODE_KIND,
        string v_PAYOD_CODE_TYPE,
        string v_PAYOD_CODE_NO,
        string v_YM
)
       {
           string strSQL =
                          "select sum(Payod_amt) as orgamt from sal_SAPAYOD inner join sal_SABASE on sal_SABASE.base_seqno=payod_seqno "
                        + " inner join sal_SABASEEXT on sal_SABASE.base_idno=sal_SABASEEXT.BASE_IDNO  where "
                        + " PAYOD_KIND='004' and  PAYOD_CODE_SYS=@v_PAYOD_CODE_SYS and PAYOD_CODE_KIND=@v_PAYOD_CODE_KIND and PAYOD_CODE_TYPE=@v_PAYOD_CODE_TYPE and PAYOD_CODE_NO=@v_PAYOD_CODE_NO "
                        + " AND SUBSTRING(PAYOD_DATE,1,6) = @v_YM AND isnull(sal_SABASEEXT.BASE_RETIRE,'') = 'Y'";

           SqlParameter[] sp =
            {           
             new SqlParameter("@v_PAYOD_CODE_SYS",v_PAYOD_CODE_SYS) ,
             new SqlParameter("@v_PAYOD_CODE_KIND",v_PAYOD_CODE_KIND) ,  
             new SqlParameter("@v_PAYOD_CODE_TYPE",v_PAYOD_CODE_TYPE) ,
             new SqlParameter("@v_PAYOD_CODE_NO",v_PAYOD_CODE_NO) ,
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }



       public void querydelete(
         string v_YM,
         string strOrgCode,
         string tabid,
         string t_amt,
         string org_amt
    )
       {
           string strSQL =
                    "delete sal_saupemp where UPEMP_YM=@v_YM and UPEMP_ORGID=@strOrgCode and UPEMP_TABID=@tabid ";
              int x=0;
              if(int.TryParse(org_amt,out x))
              {
                if (int.Parse(org_amt) > 0 ) 
                {
                    t_amt = org_amt;
                    strSQL +=" INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT )"
                    + " VALUES (@v_YM, @strOrgCode , @tabid, @strOrgCode, @t_amt ) ";
                } 
              }

           SqlParameter[] sp =
        {            
            new SqlParameter("@v_YM",v_YM) ,
            new SqlParameter("@strOrgCode",strOrgCode) , 
            new SqlParameter("@tabid",tabid)  ,        
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@org_amt",org_amt) 

        };

           Execute(strSQL, sp);
       }



       public void querySAUPUNIT(
         string strOrgCode,
         string v_UserName,
         string v_UserTel,
         string v_UserMail
   )
       {
           string strSQL =
         " delete sal_SAUPUNIT where UPUNIT_NO=@strOrgCode "
       + " INSERT sal_SAUPUNIT (UPUNIT_NO, UPUNIT_CNAME, UPUNIT_CTEL, UPUNIT_CEMAIL)"
       + " VALUES(@strOrgCode , "
       + " @v_UserName , "
       + " @v_UserTel , "
       + " @v_UserMail) ";

           SqlParameter[] sp =
        {            
            new SqlParameter("@strOrgCode",strOrgCode) , 
            new SqlParameter("@v_UserName",v_UserName) ,        
            new SqlParameter("@v_UserTel",v_UserTel) ,
            new SqlParameter("@v_UserMail",v_UserMail) 
        };

           Execute(strSQL, sp);
       }



       public void querySAUPEMP(
         string v_YM,
         string strOrgCode,
         string vOrgTabID,
         string vAmt
   )
       {
           string strSQL =
            " DELETE sal_SAUPEMP WHERE UPEMP_YM = @v_YM  AND UPEMP_ORGID = @strOrgCode AND UPEMP_TABID = @vOrgTabID "
          + " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT )"
          + " VALUES (@v_YM , @strOrgCode , @vOrgTabID , @strOrgCode , @vAmt ) ";

           SqlParameter[] sp =
        {            
            new SqlParameter("@v_YM",v_YM) , 
            new SqlParameter("@strOrgCode",strOrgCode) ,        
            new SqlParameter("@vOrgTabID",vOrgTabID) ,
            new SqlParameter("@vAmt",vAmt) 
        };

           Execute(strSQL, sp);
       }


       public DataTable queryfile(
          string strOrgCode,
          string v_YM,
          string vTabID
)
       {
           string strSQL =
          " SELECT BASE_ORGID, BASE_IDNO, BASE_PTB, BASE_DCODE, BASE_ORG_L2, BASE_ORG_L1, BASE_ORG_L3, E.*, T.UPTCL_TYPE "
        + " FROM sal_SAUPEMP E left join sal_SABASE B "
        + " ON BASE_SEQNO = UPEMP_SEQNO "
        + " AND BASE_ORGID = @strOrgCode "
        + ", sal_SAUPTCL T "
        + " WHERE UPEMP_YM = @v_YM "
        + " AND UPEMP_ORGID = @strOrgCode "
        + " AND UPEMP_TABID IN ( "+ vTabID +") "
        + " AND E.UPEMP_TABID = T.UPTCL_TABID "
        + " ORDER BY BASE_IDNO, UPEMP_TABID ";

           SqlParameter[] sp =
            {           
             new SqlParameter("@strOrgCode",strOrgCode) ,
             new SqlParameter("@vTabID",vTabID) ,  
             new SqlParameter("@v_YM",v_YM)      
            };
           return Query(strSQL, sp);
       }




       public DataTable queryf101(
             string tabid
         )
       {
           string strSQL =
      " select uptcl_tabname from sal_sauptcl where uptcl_tabid=@tabid ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@tabid",tabid)        
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101saupemp(
          string TextBox_ym,
          string TextBox_upempStr,
          string TextBox_tabid
       )
       {
           string strSQL =
         " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
       + " ,isnull(UPEMP_TYPE,'0') TYPE, UPEMP_AMT AMT "
       + " ,isnull(UPEMP_KIND,'1') KIND, isnull(UPEMP_QTY,0) QTY"
       + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym  "
       + " AND " + TextBox_upempStr
       + " AND UPEMP_TABID = @TextBox_tabid  "
       + " AND UPEMP_ORGID = BASE_ORGID "
       + " AND UPEMP_SEQNO = BASE_SEQNO "
       + " ORDER BY BASE_NAME ";


           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr)     ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101A0001(
        string TextBox_ym,
        string TextBox_payodStr
     )
       {
           string strSQL =
     " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE "+TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND BASE_KDB = '001' "
                + " and base_prono <> '006' "

                + " AND payod_kind = '001' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }


       public DataTable queryf101A0002(
        string TextBox_ym,
        string TextBox_payodStr
     )
       {
           string strSQL =
        " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD inner join sal_SABASE on base_seqno=payod_seqno "
                + " inner join SApayo on payo_seqno=payod_seqno and payo_orgid=payod_orgid and payo_kind=payod_kind and payo_date=payod_date and payo_yymm=payod_ym "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND (PAYO_PRONO='002' or PAYO_PRONO='003') "
                + " AND PAYO_dcode='141'"
                + " AND payod_kind = '001' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }


       public DataTable queryf101A0003(
          string TextBox_ym,
          string TextBox_payodStr
   )
       {
           string strSQL =
      " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND BASE_KDB = '003' "
                + " AND payod_kind = '001' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }


       public DataTable queryf101A0004(
         string TextBox_ym,
         string TextBox_payodStr
  )
       {
           string strSQL =
       " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND BASE_KDB = '009' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_NO = '001' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " AND PAYO_PRONO='004'"
               + " AND PAYO_dcode='178'"
               + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101A0005(
        string TextBox_ym,
        string TextBox_payodStr
 )
       {
           string strSQL =
        " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '001' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " AND BASE_KDB = '009' "
                + " AND PAYO_PRONO='004'"
                + " AND PAYO_dcode='179'"
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101A00011(
          string TextBox_ym,
          string TextBox_payodStr
)
       {
           string strSQL =
         " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND payod_kind = '001' "
               + " AND BASE_KDB = '004' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_NO = '001' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101A00013(
         string TextBox_ym,
         string TextBox_payodStr
)
       {
           string strSQL =
         " SELECT BASE_SEQNO SEQNO, BASE_IDNO AS IDNO, BASE_NAME NAME, PAYOD_AMT AMT, '0' AS TYPE, PAYOD_ORGID as ORGID "
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND BASE_KDB = '013' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_NO = '001' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf101search(
            string TextBox_baseStr,
            string vIDNo,
            string vName
)
       {
           string strSQL =
            " select BASE_ORGID AS ORGID ,BASE_SEQNO AS SEQNO ,BASE_IDNO AS IDNO ,BASE_NAME AS NAME, '0' AS AMT, '0' AS TYPE "
          + " from sal_SABASE B "
          + " where " + TextBox_baseStr;

           if (vIDNo != "")
           {
               strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
           }
           if (vName != "")
           {
               strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
           }

           strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

           SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
           return Query(strSQL, sp);
       }



       public void queryf101insert(
      string TextBox_ym,
      string t_orgid,
      string TextBox_tabid,
      string t_seqno,
      string t_amt,
      string t_type,
      string t_class,
      string t_qty,
      string t_kind,
      string t_FType,
      string t_DType
)
       {
           string strSQL =
            " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT "
          + " , UPEMP_TYPE, UPEMP_CLASS, UPEMP_QTY, UPEMP_KIND "
          + " , UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
          + " VALUES ( @TextBox_ym , @t_orgid , @TextBox_tabid , @t_seqno , @t_amt";
           if (t_type == "NULL")
           {
               strSQL += ","+t_type  ;
           }
           else
           {
               strSQL += ", @t_type ";
           }
           if(t_class =="NULL")
           {
                 strSQL += ","+t_class  ;
           }
           else
           {
               strSQL += ", @t_class ";
           }
           if(t_qty =="NULL")
           {
                 strSQL += ","+t_qty  ;
           }
           else
           {
               strSQL += ", @t_qty ";
           }
           if(t_kind =="NULL")
           {
                 strSQL += ","+t_kind  ;
           }
           else
           {
               strSQL += ", @t_kind ";
           }

           strSQL += ", @t_FType , @t_DType , getdate() )";
       
           SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_class",t_class) ,
            new SqlParameter("@t_qty",t_qty) ,
            new SqlParameter("@t_kind",t_kind) ,
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
           Execute(strSQL, sp);
       }


       public void queryf101delete(
         string TextBox_ym,
         string TextBox_upempStr,
         string TextBox_tabid
)
       {
           string strSQL =
            " DELETE FROM sal_SAUPEMP "
        + " WHERE UPEMP_YM = @TextBox_ym  "
        + " AND " + TextBox_upempStr
        + " AND UPEMP_TABID = @TextBox_tabid ";


           SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid)      
            };
           Execute(strSQL, sp);
       }





       public void queryf101update(
    string TextBox_ym,
    string t_orgid,
    string TextBox_tabid,
    string t_seqno,
    string t_amt,
    string t_type,
    string t_class,
    string t_qty,
    string t_kind,
    string t_FType,
    string t_DType
)
       {
           string strSQL =
            " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT "
                    + " , UPEMP_TYPE, UPEMP_CLASS, UPEMP_QTY, UPEMP_KIND "
                    + " , UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
                    + " VALUES (@TextBox_ym , @t_orgid , @TextBox_tabid , @t_seqno , @t_amt";
           if (t_type == "NULL")
           {
               strSQL += "," + t_type;
           }
           else
           {
               strSQL += ", @t_type ";
           }
           if (t_class == "NULL")
           {
               strSQL += "," + t_class;
           }
           else
           {
               strSQL += ", @t_class ";
           }
           if (t_qty == "NULL")
           {
               strSQL += "," + t_qty;
           }
           else
           {
               strSQL += ", @t_qty ";
           }
           if (t_kind == "NULL")
           {
               strSQL += "," + t_kind;
           }
           else
           {
               strSQL += ", @t_kind ";
           }

           strSQL += ", @t_FType , @t_DType , getdate() )";

           SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_class",t_class) ,
            new SqlParameter("@t_qty",t_qty) ,
            new SqlParameter("@t_kind",t_kind) ,
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
           Execute(strSQL, sp);
       }



       public DataTable queryf102B1001(
        string TextBox_ym,
        string TextBox_payodStr
     )
       {
           string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,'1' as KIND, 0 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE "+TextBox_payodStr 
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '001' "
                + " AND BASE_KDP = '001' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '003' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";


           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }


       public DataTable queryf102B10011(
      string TextBox_ym,
      string TextBox_payodStr
   )
       {
           string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,'1' as KIND, 0 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '001' "
                + " AND BASE_KDP = '011' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '003' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf102B1105(
      string TextBox_ym,
      string TextBox_payodStr
   )
       {
           string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,'1' as KIND, 0 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND BASE_KDP = '005' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '003' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



       public DataTable queryf102B1019(
    string TextBox_ym,
    string TextBox_payodStr
 )
       {
           string strSQL =
              " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               + " ,'0' as TYPE, PAYOD_AMT as AMT "
               + " ,'1' as KIND, 0 as  QTY"
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND BASE_KDP = '019' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " AND PAYOD_CODE_NO = '003' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }


       public DataTable queryf102B1020(
    string TextBox_ym,
    string TextBox_payodStr
 )
       {
           string strSQL =
             " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,'1' as KIND, 0 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND BASE_KDP = '020' "
                + " AND PAYOD_CODE_SYS = '003' "
                + " AND PAYOD_CODE_KIND = 'P' "
                + " AND PAYOD_CODE_NO = '003' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }



        public DataTable queryf102B1124(
    string TextBox_ym,
    string TextBox_payodStr
 )
       {
           string strSQL =
               " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               + " ,'0' as TYPE, PAYOD_AMT as AMT "
               + " ,'1' as KIND, 0 as  QTY"
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND BASE_KDP = '024' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_NO = '003' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";

           SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
           return Query(strSQL, sp);
       }




        public DataTable queryf102search(
             string TextBox_baseStr,
             string vIDNo,
             string vName
 )
        {
            string strSQL =
           " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
       + " ,'0' as TYPE, 0 as AMT "
       + " ,'1' as KIND, 0 as  QTY"
       + " from sal_SABASE B "

       + " where " + TextBox_baseStr;

            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }

            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf103saupemp(
          string TextBox_ym,
          string TextBox_upempStr,
          string TextBox_tabid
       )
        {
            string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " , case upemp_tabid when 'C1010' then '0' when 'C1011' then '0' else isnull(UPEMP_TYPE,'0') end as TYPE"
                + " , UPEMP_AMT AMT "
                + " , isnull(UPEMP_QTY,0) QTY"
                + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym "
                + " AND "+ TextBox_upempStr
                + " AND UPEMP_TABID = @TextBox_tabid "
                + " AND UPEMP_ORGID = BASE_ORGID "
                + " AND UPEMP_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";


            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr)     ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf103C1001(
       string TextBox_ym,
       string TextBox_payodStr
    )
        {
            string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               + " ,'0' as TYPE, PAYOD_AMT as AMT "
               + " ,'1' as KIND, 0 as  QTY"
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND payod_kind = '001' "
               + " AND BASE_KDC = '001' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " AND PAYOD_CODE_NO = '004' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";

            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf103C1002(
     string TextBox_ym,
     string TextBox_payodStr
  )
        {
            string strSQL =
               " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               +" ,'0' as TYPE, PAYOD_AMT as AMT "
               +" ,'1' as KIND, 0 as  QTY"
               +" FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               +" AND PAYOD_YM = @TextBox_ym "
               +" AND BASE_KDC = '002' "
               +" AND PAYOD_CODE_SYS = '003' "
               +" AND PAYOD_CODE_KIND = 'P' "
               +" AND PAYOD_CODE_TYPE = '001' "
               +" AND PAYOD_CODE_NO = '004' "
               +" and payod_orgid = base_orgid "
               +" AND PAYOD_SEQNO = BASE_SEQNO "
               +" ORDER BY BASE_NAME ";

            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf103C1010(
        string TextBox_ym,
        string TextBox_payodStr
 )
        {
            string strSQL =
                 " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               + " ,'0' as TYPE, PAYOD_AMT as AMT "
               + " ,'1' as KIND, 0 as  QTY"
               + " FROM sal_SAPAYOD, sal_SABASE "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND payod_kind = '001' "
               + " AND PAYOD_CODE_SYS = '003' "
               + " AND PAYOD_CODE_KIND = 'P' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " AND PAYOD_CODE_NO = '004' "
               + " AND BASE_KDC = '010' "
               + " and payod_amt > 0 "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " AND BASE_KDC ='010' "
               + " ORDER BY BASE_NAME ";

            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf103search(
             string TextBox_baseStr,
             string vIDNo,
             string vName
 )
        {
            string strSQL =

                 " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                +" ,'0' as TYPE, 0 as AMT "
                +" ,'1' as KIND, 0 as  QTY"
                +" from sal_SABASE B "
                + " where " + TextBox_baseStr;  

            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }

            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf104saupemp(
          string TextBox_ym,
          string TextBox_upempStr,
          string TextBox_tabid
       )
        {
            string strSQL =
               " SELECT B.BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, UPEMP_AMT AMT, UPEMP_TYPE TYPE, B.BASE_ORGID as ORGID "
        + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym "
        + " AND " + TextBox_upempStr
        + " AND UPEMP_TABID = @TextBox_tabid "
        + " AND UPEMP_ORGID = BASE_ORGID "
        + " AND UPEMP_SEQNO = BASE_SEQNO "
        + " ORDER BY BASE_NAME ";


            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)  ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr)  ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf104search(
              string TextBox_baseStr,
              string vIDNo,
              string vName
  )
        {
            string strSQL =
                  " select BASE_ORGID AS ORGID ,BASE_SEQNO AS SEQNO ,BASE_IDNO AS IDNO ,BASE_NAME AS NAME, '0' AS AMT, '0' AS TYPE "
                + " from sal_SABASE B "
                + " where " + TextBox_baseStr;

            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }

            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }





        public void queryf104insert(
             string TextBox_ym,
             string t_orgid,
             string TextBox_tabid,
             string t_seqno,
             string t_amt,
             string t_type,
             string t_qty,
             string t_FType,
             string t_DType
)
        {
            string strSQL =
                     " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT, "
                   + " UPEMP_TYPE, UPEMP_QTY, UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
                   + " VALUES (@TextBox_ym , @t_orgid , @TextBox_tabid , @t_seqno , @t_amt ,";
            if (t_type == "NULL")
            {
                strSQL += t_type;
            }
            else
            {
                strSQL += " @t_type ";
            }
            if (t_qty == "NULL")
            {
                strSQL += ","+t_qty;
            }
            else
            {
                strSQL += ", @t_qty ";
            }
                 strSQL+=" , @t_FType , @t_DType , getdate() )";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_qty",t_qty) ,
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
            Execute(strSQL, sp);
        }



        public void queryf104update(
          string TextBox_ym,
          string t_orgid,
          string TextBox_tabid,
          string t_seqno,
          string t_amt,
          string t_type,
          string t_qty,
          string t_FType,
          string t_DType
)
        {
            string strSQL =
             " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT, "
                    + " UPEMP_TYPE, UPEMP_QTY, UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
                    + " VALUES (@TextBox_ym, @t_orgid , @TextBox_tabid, @t_seqno , @t_amt ,";
            if (t_type == "NULL")
            {
                strSQL += t_type;
            }
            else
            {
                strSQL += " @t_type ";
            }
            if (t_qty == "NULL")
            {
                strSQL += "," + t_qty;
            }
            else
            {
                strSQL += ", @t_qty ";
            }
                   strSQL+=", @t_FType , @t_DType , getdate() )";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,         
            new SqlParameter("@t_qty",t_qty) ,         
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
            Execute(strSQL, sp);
        }
    


        public DataTable queryf105saupemp(
            string TextBox_ym,
            string TextBox_upempStr,
            string TextBox_tabid
         )
        {
            string strSQL =
                " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                +" ,isnull(UPEMP_TYPE,'0') TYPE, UPEMP_AMT AMT ";
        if( TextBox_tabid == "E0001" )
        {
            strSQL+= " ,isnull(UPEMP_KIND,'1') KIND1, '1' as KIND2 ";
        }
        else if (TextBox_tabid == "E0004" )
        {
           strSQL+= " ,'1' as KIND1, isnull(UPEMP_KIND,'1') KIND2 ";
        }
        else
        {
            strSQL += " ,isnull(UPEMP_KIND,'1') KIND1, isnull(UPEMP_KIND,'1') KIND2 ";
        }

        strSQL += " ,isnull(UPEMP_CLASS,'1') CLASS, isnull(UPEMP_QTY,0) QTY"
                + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym "
                + " AND "+TextBox_upempStr
                + " AND UPEMP_TABID = @TextBox_tabid "
                + " AND UPEMP_ORGID = BASE_ORGID "
                + " AND UPEMP_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";


            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr)     ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
            return Query(strSQL, sp);
        }
    

        public DataTable queryf105E0001(
               string TextBox_ym,
               string TextBox_payodStr
)
        {
            string strSQL =
                " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,1 as KIND1,1 as CLASS,1 as KIND2,e.QTY as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE " +
                "where 1=2";
          /*      + " inner join (select edu_seqno ,count(Distinct EDU_IDNO) as 'QTY' from sal_saedu where Edu_Year = '" + TextBox_ym.Substring(0, 4) + "' group by edu_seqno) e on e.edu_seqno=base_seqno"
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '005' "
                + " AND PAYOD_CODE_SYS = '005' "
                + " AND PAYOD_CODE_KIND = 'D' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '501' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " AND BASE_PRONO <> '006' "
                + " ORDER BY BASE_NAME ";
          */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf105E0002(
               string TextBox_ym,
               string TextBox_payodStr
)
        {
            string strSQL =
               " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,cast(edu_school as int) as KIND1,1 as CLASS,1 as KIND2,1 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + "where 1=2";
             /*   + " inner join sal_saedu on edu_seqno=base_seqno and edu_year='" + TextBox_ym.Substring(0, 4) + "' "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '005' "
                + " AND PAYOD_CODE_SYS = '005' "
                + " AND PAYOD_CODE_KIND = 'D' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '502' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";
             */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }


        public DataTable queryf105E0003(
           string TextBox_ym,
           string TextBox_payodStr
)
        {
            string strSQL =
                " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,cast(edu_school as int) as KIND1,1 as CLASS,1 as KIND2,1 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE " 
                + "where 1=2";
                /*
                + " inner join sal_saedu on edu_seqno=base_seqno and edu_year='" + TextBox_ym.Substring(0, 4) + "' "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '005' "
                + " AND PAYOD_CODE_SYS = '005' "
                + " AND PAYOD_CODE_KIND = 'D' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '503' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";
                */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf105E0004(
             string TextBox_ym,
             string TextBox_payodStr
  )
        {
            string strSQL =
                 " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
               + " ,'0' as TYPE, PAYOD_AMT as AMT "
               + " ,cast(edu_school as int) as KIND1,1 as CLASS,1 as KIND2,1 as  QTY"
               + " FROM sal_SAPAYOD, sal_SABASE "
               + "where 1=2 ";
            /*
               + " inner join sal_saedu on edu_seqno=base_seqno and edu_year='" + TextBox_ym.Substring(0, 4) + "' "
               + " WHERE " + TextBox_payodStr
               + " AND PAYOD_YM = @TextBox_ym "
               + " AND payod_kind = '005' "
               + " AND PAYOD_CODE_SYS = '005' "
               + " AND PAYOD_CODE_KIND = 'D' "
               + " AND PAYOD_CODE_TYPE = '001' "
               + " AND PAYOD_CODE_NO = '504' "
               + " and payod_orgid = base_orgid "
               + " AND PAYOD_SEQNO = BASE_SEQNO "
               + " ORDER BY BASE_NAME ";
            */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }


        public DataTable queryf105E0008(
            string TextBox_ym,
            string TextBox_payodStr
 )
        {
            string strSQL =
                  " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,cast(edu_school as int) as KIND1,1 as CLASS,1 as KIND2,1 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + "where 1=2 ";
            /*
                + " inner join sal_saedu on edu_seqno=base_seqno and edu_year='" + TextBox_ym.Substring(0, 4) + "' "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '005' "
                + " AND PAYOD_CODE_SYS = '005' "
                + " AND PAYOD_CODE_KIND = 'D' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '501' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " ORDER BY BASE_NAME ";
            */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }


        public DataTable queryf105E0009(
           string TextBox_ym,
           string TextBox_payodStr
)
        {
            string strSQL =
               " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
                + " ,'0' as TYPE, PAYOD_AMT as AMT "
                + " ,cast(edu_school as int) as KIND1,1 as CLASS,1 as KIND2,1 as  QTY"
                + " FROM sal_SAPAYOD, sal_SABASE "
                + "where 1=2";
            /*
                + " inner join sal_saedu on edu_seqno=base_seqno and edu_year='" + TextBox_ym.Substring(0, 4) + "' "
                + " WHERE " + TextBox_payodStr
                + " AND PAYOD_YM = @TextBox_ym "
                + " AND payod_kind = '005' "
                + " AND PAYOD_CODE_SYS = '005' "
                + " AND PAYOD_CODE_KIND = 'D' "
                + " AND PAYOD_CODE_TYPE = '001' "
                + " AND PAYOD_CODE_NO = '501' "
                + " and payod_orgid = base_orgid "
                + " AND PAYOD_SEQNO = BASE_SEQNO "
                + " AND BASE_PRONO = '006' "
                + " ORDER BY BASE_NAME ";
            */
            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym)    ,
            new SqlParameter("@TextBox_payodStr",TextBox_payodStr)            
            };
            return Query(strSQL, sp);
        }




        public DataTable queryf105search(
              string TextBox_baseStr,
              string vIDNo,
              string vName
  )
        {
            string strSQL =
                " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
              + " ,'0' as TYPE, 0 as AMT "
              + " ,'1' as KIND1, '1' as KIND2 "
              + " ,'1' as CLASS, '0' as QTY "
              + " from sal_SABASE B "
              + " where " + TextBox_baseStr;
            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }

            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }




        public DataTable queryf106saupemp(
            string TextBox_ym,
            string TextBox_upempStr,
            string TextBox_tabid
         )
        {
            string strSQL =
              " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
        + " ,isnull(UPEMP_TYPE,'0') TYPE, UPEMP_AMT AMT "
        + " ,isnull(UPEMP_KIND,'1') KIND, isnull(UPEMP_QTY,0) QTY"
        + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym "
        + " AND " + TextBox_upempStr
        + " AND UPEMP_TABID = @TextBox_tabid "
        + " AND UPEMP_ORGID = BASE_ORGID "
        + " AND UPEMP_SEQNO = BASE_SEQNO "
        + " ORDER BY BASE_NAME ";


            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr) ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
            return Query(strSQL, sp);
        }




        public DataTable queryf106search(
              string TextBox_baseStr,
              string vIDNo,
              string vName
  )
        {
            string strSQL =
              " SELECT BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, BASE_ORGID ORGID "
            + " ,'0' as TYPE, 0 as AMT "
            + " ,'1' as KIND, 0 as  QTY"
            + " from sal_SABASE B "
            + " where " + TextBox_baseStr;

            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }
            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }


        public DataTable queryf107saupemp(
            string TextBox_ym,
            string TextBox_upempStr,
            string TextBox_tabid
         )
        {
            string strSQL =
              " SELECT B.BASE_NAME NAME, BASE_SEQNO SEQNO, BASE_IDNO IDNO, UPEMP_AMT AMT, UPEMP_TYPE TYPE, B.BASE_ORGID as ORGID "
            + " FROM sal_SAUPEMP P, sal_SABASE B WHERE UPEMP_YM = @TextBox_ym "
            + " AND " + TextBox_upempStr
            + " AND UPEMP_TABID = @TextBox_tabid "
            + " AND UPEMP_ORGID = BASE_ORGID "
            + " AND UPEMP_SEQNO = BASE_SEQNO "
            + " ORDER BY BASE_NAME ";

            SqlParameter[] sp =
            {           
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@TextBox_upempStr",TextBox_upempStr) ,   
            new SqlParameter("@TextBox_tabid",TextBox_tabid)        
            };
            return Query(strSQL, sp);
        }



        public DataTable queryf107search(
             string TextBox_baseStr,
             string vIDNo,
             string vName
 )
        {
            string strSQL =
                  " select BASE_ORGID AS ORGID ,BASE_SEQNO AS SEQNO ,BASE_IDNO AS IDNO ,BASE_NAME AS NAME, '0' AS AMT, '0' AS TYPE "
                + " from sal_SABASE B "
                + " where " + TextBox_baseStr;
            if (vIDNo != "")
            {
                strSQL += " AND BASE_IDNO LIKE '%'+@vIDNo+'%' ";
            }
            if (vName != "")
            {
                strSQL += " AND BASE_NAME LIKE '%'+@vName+'%' ";
            }
            strSQL += " ORDER BY BASE_ORGID, BASE_NAME ";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_baseStr",TextBox_baseStr) ,
            new SqlParameter("@vIDNo",vIDNo) ,
            new SqlParameter("@vName",vName)            
            };
            return Query(strSQL, sp);
        }




        public void queryf107insert(
             string TextBox_ym,
             string t_orgid,
             string TextBox_tabid,
             string t_seqno,
             string t_amt,
             string t_type,
             string t_qty,
             string t_FType,
             string t_DType
)
        {
            string strSQL =
                      " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT, "
                    + " UPEMP_TYPE, UPEMP_QTY, UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
                    + " VALUES (@TextBox_ym , @t_orgid ,  @TextBox_tabid , @t_seqno , @t_amt,";
            if (t_type == "NULL")
            {
                strSQL += t_type;
            }
            else
            {
                strSQL += "@t_type ";
            }
            if (t_qty == "NULL")
            {
                strSQL += "," +t_qty;
            }
            else
            {
                strSQL += " ,@t_qty ";
            }

                 strSQL+= " , @t_FType , @t_DType , getdate() )";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_qty",t_qty) ,
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
            Execute(strSQL, sp);
        }



        public void queryf107update(
          string TextBox_ym,
          string t_orgid,
          string TextBox_tabid,
          string t_seqno,

          string t_amt,
          string t_type,
          string t_qty,
          string t_FType,
          string t_DType
)
        {
            string strSQL =
               " INSERT sal_SAUPEMP (UPEMP_YM, UPEMP_ORGID, UPEMP_TABID, UPEMP_SEQNO, UPEMP_AMT, "
                   + " UPEMP_TYPE, UPEMP_QTY, UPEMP_FTYPE, UPEMP_DTYPE, ADD_TIME ) "
                   + " VALUES (@TextBox_ym, @t_orgid , @TextBox_tabid, @t_seqno , @t_amt ,";
            if (t_type == "NULL")
            {
                strSQL += t_type;
            }
            else
            {
                strSQL += "@t_type ";
            }
            if (t_qty == "NULL")
            {
                strSQL += "," + t_qty;
            }
            else
            {
                strSQL += " ,@t_qty ";
            }
                strSQL+=", @t_FType , @t_DType , getdate() )";

            SqlParameter[] sp =
            {         
            new SqlParameter("@TextBox_ym",TextBox_ym) ,
            new SqlParameter("@t_orgid",t_orgid) ,
            new SqlParameter("@TextBox_tabid",TextBox_tabid) ,
            new SqlParameter("@t_seqno",t_seqno) ,
            new SqlParameter("@t_amt",t_amt) ,
            new SqlParameter("@t_type",t_type) ,
            new SqlParameter("@t_qty",t_qty) ,
            new SqlParameter("@t_FType",t_FType) ,
            new SqlParameter("@t_DType",t_DType) 
            };
            Execute(strSQL, sp);
        }








}