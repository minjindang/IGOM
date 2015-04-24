using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4112DAO 的摘要描述
/// </summary>
public class SAL4112DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4112DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }

    public SAL4112DAO(SqlConnection conn)
        : base(conn)
    {

    }

   //add ym
    public DataTable getYearData()
    {
        String strSQL = " select distinct tax_ym "
       + " , (cast(cast(substring(tax_ym,1,4) as int) - 1911 as varchar) + ' 年 ' + substring(tax_ym,5,2) + ' 月') as ymstr"
       + " from sal_satax "
       + " order by tax_ym desc ";
        

        SqlParameter[] sp = { 
                         
                            };
        return Query(strSQL, sp);
    }


    //查詢
    public DataTable get_SaTax_sql(string ym)
    {
        String strSQL =
          " select * from sal_satax "
        + " where tax_ym = @ym "
        + " order by cast(tax_sallow as int) ";
       

        SqlParameter[] sp = { 
                            new SqlParameter("@ym", ym)                         
                            };
        return Query(strSQL, sp);
    }


    //查詢
    public DataTable checkdata(string ym, string low
                , string up )
    {
        String strSQL =
          " select * from sal_satax "
        + " where tax_ym = @ym and tax_sallow=@low and tax_salup = @up";
    


        SqlParameter[] sp = { 
                            new SqlParameter("@ym", ym)   ,
                            new SqlParameter("@low",low) ,
                            new SqlParameter("@up",up), 
                            };
        return Query(strSQL, sp);
    }


      // 新增
      public void getaddData(
                  string ym
                , string low
                , string up
                , string tax_p0
                , string tax_p1
                , string tax_p2
                , string tax_p3
                , string tax_p4
                , string tax_p5
                , string tax_p6
                , string tax_p7
                , string tax_p8
                , string tax_p9
                , string tax_p10
                , string tax_p11
        )
    {
      
        String strSQL =
                 " insert into sal_satax( tax_ym , tax_sallow, " +
                 " tax_salup , tax_p0, tax_p1, tax_p2, tax_p3,tax_p4,tax_p5,tax_p6,tax_p7,tax_p8,tax_p9,tax_p10,tax_p11 ) "
                 + " values(@ym "
                 + "  ,@low "
                 + "  ,@up  "
                 + "  ,@tax_p0 "
                 + "  ,@tax_p1 "
                 + "  ,@tax_p2 "
                 + "  ,@tax_p3 "
                + "  ,@tax_p4 "
                + "  ,@tax_p5 "
                + "  ,@tax_p6 "
                + "  ,@tax_p7 "
                + "  ,@tax_p8 "
                + "  ,@tax_p9 "
                + "  ,@tax_p10 "
                + "  ,@tax_p11 "
                 + " )"; 


        SqlParameter[] sp =
        {      
             new SqlParameter("@ym",ym), 
             new SqlParameter("@low",low) ,
             new SqlParameter("@up",up), 
             new SqlParameter("@tax_p0",tax_p0),
             new SqlParameter("@tax_p1",tax_p1),
             new SqlParameter("@tax_p2",tax_p2),
             new SqlParameter("@tax_p3",tax_p3),
             new SqlParameter("@tax_p4",tax_p4),
             new SqlParameter("@tax_p5",tax_p5),
             new SqlParameter("@tax_p6",tax_p6),
             new SqlParameter("@tax_p7",tax_p7),
             new SqlParameter("@tax_p8",tax_p8),
             new SqlParameter("@tax_p9",tax_p9),
             new SqlParameter("@tax_p10",tax_p10),
             new SqlParameter("@tax_p11",tax_p11),
        };

        Execute(strSQL, sp);
    }

    // 維護 
    public void geteditData(
                  string ym
                , string low
                , string up
                , string p0
                , string p1
                , string p2
                , string p3
                , string p4
                , string p5
                , string p6
                , string p7
                , string p8
                , string p9
                , string p10
                , string p11
        )
    {
        String strSQL =
              "   update sal_satax "
            + "   set tax_p0 = @p0 "
            + "   , tax_p1 = @p1"
            + "   , tax_p2 =@p2"
            + "   , tax_p3 =@p3"
            + "   , tax_p4 =@p4"
            + "   , tax_p5 =@p5"
            + "   , tax_p6 =@p6"
            + "   , tax_p7 =@p7"
            + "   , tax_p8 =@p8"
            + "   , tax_p9 =@p9"
            + "   , tax_p10 =@p10"
            + "   , tax_p11 =@p11"
            + "   where tax_ym = @ym"
            + "   and tax_sallow = @low "
            + "   and tax_salup = @up ";
        
        SqlParameter[] sp =
        {
             new SqlParameter("@ym",ym), 
             new SqlParameter("@low",low) ,
             new SqlParameter("@up",up), 
             new SqlParameter("@p0",p0),
             new SqlParameter("@p1",p1),
             new SqlParameter("@p2",p2),
             new SqlParameter("@p3",p3),
             new SqlParameter("@p4",p4),
             new SqlParameter("@p5",p5),
             new SqlParameter("@p6",p6),
             new SqlParameter("@p7",p7),
             new SqlParameter("@p8",p8),
             new SqlParameter("@p9",p9),
             new SqlParameter("@p10",p10),
             new SqlParameter("@p11",p11),
        };

        Execute(strSQL, sp);
    }


    //刪除
    public void getdeleteData(string ym
      , string v_low
      , string v_up  
      )
    {
        String strSQL =
          " delete sal_satax "
        + " where tax_ym = @ym  "
        + " and tax_sallow = @v_low  "
        + " and tax_salup = @v_up  ";

        SqlParameter[] sp =
        {
            new SqlParameter("@ym",ym),        
            new SqlParameter("@v_low",v_low) ,
            new SqlParameter("@v_up",v_up)
        };

        Execute(strSQL, sp);
    }



}