using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4113DAO 的摘要描述
/// </summary>
public class SAL4113DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4113DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }

    public SAL4113DAO(SqlConnection conn)
        : base(conn)
    {

    }
 


    //查詢
    public DataTable get_data(string Code_no)
    {
        String strSQL =
                  " select * from sys_code "
                + " where code_sys='006' "
                + " and code_type=@Code_no ";
       

        SqlParameter[] sp = { 
                            new SqlParameter("@Code_no", Code_no)                         
                            };
        return Query(strSQL, sp);
    }


      // 新增
      public void getaddData(
                  string ym
                , string sys
                , string kind
                , string type
                , string no
                , string VALUE
                , string Muser
                , string Mdate
        )
    {
      
        String strSQL =
                 " insert into SAL_SAPARAMETER( PARAMETER_ym , PARAMETER_code_sys, " +
                 " PARAMETER_code_kind , PARAMETER_code_type, PARAMETER_code_no, PARAMETER_VALUE , PARAMETER_MUSER ,PARAMETER_MDATE ) "
                 + " values(@ym "
                 + "  ,@sys "
                 + "  ,@kind "
                 + "  ,@type "
                 + "  ,@no "
                 + "  ,@VALUE "
                 + "  ,@Muser "
                 + "  ,@Mdate "            
                 + " )"; 


        SqlParameter[] sp =
        {      
             new SqlParameter("@ym",ym), 
             new SqlParameter("@sys",sys) ,
             new SqlParameter("@kind",kind), 
             new SqlParameter("@type",type),
             new SqlParameter("@no",no),
             new SqlParameter("@VALUE",VALUE),
             new SqlParameter("@Muser",Muser),
             new SqlParameter("@Mdate",Mdate)
        };

        Execute(strSQL, sp);
    }

    // 維護 
    public void geteditData(
                  string ym
                , string sys
                , string kind
                , string type
                , string no
                , string VALUE
                , string Muser
                , string Mdate
        )
    {
        String strSQL =
              "   update SAL_SAPARAMETER "
            + "   set PARAMETER_VALUE = @VALUE "
            + "   , PARAMETER_MUSER = @Muser "
            + "   , PARAMETER_MDATE = @Mdate "
            + "   where PARAMETER_ym = @ym"
            + "   and PARAMETER_code_sys = @sys "
            + "   and PARAMETER_code_kind = @kind "
            + "   and PARAMETER_code_type = @type "
            + "   and PARAMETER_code_no = @no ";
        
        SqlParameter[] sp =
        {
             new SqlParameter("@ym",ym), 
             new SqlParameter("@sys",sys) ,
             new SqlParameter("@kind",kind), 
             new SqlParameter("@type",type),
             new SqlParameter("@no",no),
             new SqlParameter("@VALUE",VALUE),
             new SqlParameter("@Muser",Muser),
             new SqlParameter("@Mdate",Mdate)
        };

        Execute(strSQL, sp);
    }
          


}