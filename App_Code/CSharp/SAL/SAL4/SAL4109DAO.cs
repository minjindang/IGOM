using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4109DAO 的摘要描述
/// </summary>
public class SAL4109DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4109DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }

    public SAL4109DAO(SqlConnection conn)
        : base(conn)
    {

    }

   //add ym
    public DataTable getYearData(string type,string no)
    {
        String strSQL = " select spesup_ym "
       + " , (cast(cast(substring(spesup_ym,1,4) as int) - 1911 as varchar) + ' 年 ' + substring(spesup_ym,5,2) + ' 月') as ymstr"
       + " from sal_saspesup "
       + " where spesup_type = @type "
       + " and spesup_no = @no "
       + " group by spesup_ym "
       + " order by spesup_ym desc ";
        

        SqlParameter[] sp = { 
                            new SqlParameter("@type", type),
                            new SqlParameter("@no", no)
                            };
        return Query(strSQL, sp);
    }


    //查詢
    public DataTable get_sastan_sql(string ym, string type, string no)
    {
        String strSQL =
               " select * from sal_saspesup "
       + " where spesup_ym = @ym "
       + " and spesup_type= @type "
       + " and spesup_no = @no "
       + " order by cast(spesup_series as int) ";
       

        SqlParameter[] sp = { 
                            new SqlParameter("@ym", ym) ,
                            new SqlParameter("@type", type),
                            new SqlParameter("@no", no)
                            };
        return Query(strSQL, sp);
    }


    //檢查
    public DataTable checkData(string ym
                , string Series
                , string SAL
                , string type
                , string no
        )
    {
        String strSQL =
               " select * from sal_saspesup "
       + " where spesup_ym = @ym "
       + " and SPESUP_SERIES= @Series "
  //     + " and SPESUP_SAL= @SAL "
       + " and spesup_type= @type "
       + " and spesup_no = @no ";
     


        SqlParameter[] sp = { 
            new SqlParameter("@ym",ym), 
            new SqlParameter("@Series",Series) ,
            new SqlParameter("@SAL",SAL), 
            new SqlParameter("@type",type),
            new SqlParameter("@no",no),
                            };
        return Query(strSQL, sp);
    }


      // 新增
      public void getaddData(               
                  string ym
                , string Series
                , string SAL
                , string type
                , string no
                , string Muser
                , string Mdate    
        )
    {
      
        String strSQL =
                 " insert into sal_saspesup( SPESUP_YM , SPESUP_SERIES, " +
                 " SPESUP_SAL, SPESUP_TYPE, SPESUP_NO, SPESUP_MUSER, SPESUP_MDATE ) "
                 + " values(@ym "
                 + "  ,@Series "
                 + "  ,@SAL "
                 + "  ,@type "
                 + "  ,@no "
                 + "  ,@Muser "
                 + "  ,@Mdate "
                 + " )"; 


        SqlParameter[] sp =
        {      
            new SqlParameter("@ym",ym), 
            new SqlParameter("@Series",Series) ,
            new SqlParameter("@SAL",SAL), 
            new SqlParameter("@type",type),
            new SqlParameter("@no",no),
            new SqlParameter("@Muser",Muser),    
            new SqlParameter("@Mdate",Mdate)
        };

        Execute(strSQL, sp);
    }

    // 維護 
    public void geteditData(
                  string ym
                , string Series
                , string SAL
                , string type
                , string no
                , string Muser
                , string Mdate    
        )
    {
        String strSQL =
              "   update sal_saspesup "
            + "   set SPESUP_SAL = @SAL "
            + "   , SPESUP_MUSER = @Muser"
            + "   , SPESUP_MDATE =@Mdate"
            + "   where SPESUP_YM = @ym"
            + "   and SPESUP_SERIES = @Series "
            + "   and SPESUP_TYPE = @type "
            + "   and SPESUP_NO = @no ";



        SqlParameter[] sp =
        {
            new SqlParameter("@ym",ym), 
            new SqlParameter("@Series",Series) ,
            new SqlParameter("@SAL",SAL), 
            new SqlParameter("@type",type),
            new SqlParameter("@no",no),
            new SqlParameter("@Muser",Muser),    
            new SqlParameter("@Mdate",Mdate)
        };

        Execute(strSQL, sp);
    }


    //刪除
    public void getdeleteData(string ym 
        , string type
        , string no
        , string v_series
      )
    {
        String strSQL =
          " delete sal_saspesup "
        + " where spesup_ym = @ym "
        + " and spesup_type = @type  "
        + " and spesup_no = @no "
        + " and spesup_series = @v_series  ";

        SqlParameter[] sp =
        {
            new SqlParameter("@ym",ym),        
            new SqlParameter("@type",type) ,
            new SqlParameter("@no",no),  
            new SqlParameter("@v_series",v_series)
        };

        Execute(strSQL, sp);
    }



}