using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4103DAO 的摘要描述
/// </summary>
public class SAL4103DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4103DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL4103DAO(SqlConnection conn)
        : base(conn)
    {

    }

     
    public DataTable getSearchData()
    {
        String strSQL =
                          "       select fmt_seqno"//--清單中之序號,索引值
                           + "   ,case Fmt_Type"
                           + "     when '001' then '資料庫'"
                           + "     when '002' then '日期'"
                           + "     when '003' then '序號'"
                           + "     when '004' then '空白'"
                           + "     when '005' then '自訂'"
                           + "     when '006' then '內參數'"
                           + "     end as type"//--清單中之欄位種類
                           + "     ,case fmt_align"
                           + "     when 'L' then '左'"
                           + "     when 'R' then '右'"
                           + "     end as align"//--清單中之對齊"
                           + "     ,fmt_format"//--清單中之資料表名稱
                           + "     ,fmt_setting"//--清單中之欄位名稱
                           + "     ,fmt_rep"//--清單中之填值
                           + "     ,fmt_start"//--清單中之字串起始位址
                           + "     ,fmt_num"//--清單中之字串位數
                           + "     ,fmt_length"//--清單中之欄位長度
                           + "     ,fmt_rule"//--清單中之欄位規則
                           + "     ,Fmt_Type,fmt_align"
                           + "     from sal_safmt"
                           + "     order by cast(fmt_seqno as int)";

        SqlParameter[] sp = {  };
        return Query(strSQL, sp);
    }

    
    public DataTable getseqData()
    {
        String strSQL =
                 " select isnull(max(cast(fmt_seqno as int)),0) + 1 as seq "
                 + "from sal_safmt";


        SqlParameter[] sp = {  };
        return Query(strSQL, sp);
    }     


    // 新增
    public void getaddData(string fmt_seqno //序號    
        , string fmt_code_no         //固定值
        , string fmt_type      //欄位種類 
        , string fmt_format         //資料表名稱
        , string fmt_setting        //欄位名稱
        , string fmt_rule       //欄位規則
        , string fmt_align       //起始位址
        , string fmt_rep      //補值
        , string fmt_length     //長度
             , string fmt_start   //字串起始位址
             , string fmt_num     //字串位數
              , string fmt_muser     //登入者員工編號
        )
    {
        String strSQL =
                        " INSERT INTO SAL_SAFMT (fmt_seqno,fmt_code_no,fmt_type,fmt_format,fmt_setting,fmt_rule,"
       +" fmt_align,fmt_rep,fmt_length,fmt_start,fmt_num,fmt_muser,fmt_mdate) VALUES"
                     + " (@fmt_seqno"
                     + "   ,@fmt_code_no"//--固定值
                     + "   ,@fmt_type"
                     + "   ,@fmt_format"
                     + "   ,@fmt_setting"
                     + "   ,@fmt_rule"
                     + "   ,@fmt_align"
                     + "   ,@fmt_rep"
                     + "   ,@fmt_length "
                     + "   ,@fmt_start"
                     + "   ,@fmt_num"
                     + "   ,@strmuser"
                     + "   ," + DateTime.Now.ToString("yyyyMMddHHmmss") + " )";


        SqlParameter[] sp =
        {
            new SqlParameter("@fmt_seqno",fmt_seqno), 
            new SqlParameter("@fmt_code_no",fmt_code_no) ,
            new SqlParameter("@fmt_type",fmt_type), 
            new SqlParameter("@fmt_format",fmt_format) ,
            new SqlParameter("@fmt_setting",fmt_setting), 
            new SqlParameter("@fmt_rule",fmt_rule), 
            new SqlParameter("@fmt_align",fmt_align), 
            new SqlParameter("@fmt_rep",fmt_rep), 
            new SqlParameter("@fmt_length",fmt_length),  
            new SqlParameter("@fmt_start",fmt_start) ,
            new SqlParameter("@fmt_num",fmt_num) ,
            new SqlParameter("@strmuser",fmt_muser)   
        };

        Execute(strSQL, sp);
    }



    // 維護
    public void geteditData(
        string fmt_type      //欄位種類 
        , string fmt_format         //資料表名稱
        , string fmt_setting        //欄位名稱
        , string fmt_rule       //欄位規則
        , string fmt_align       //起始位址
        , string fmt_rep      //補值
        , string fmt_length     //長度  
        , string fmt_start   //字串起始位址
        , string fmt_num     //字串位數                  
        , string fmt_muser     //登入者員工編號
        , string fmt_seqno //序號  
        )
    {
        String strSQL =
                "  UPDATE SAL_SAFMT"
               + " SET fmt_type = @fmt_type"
               + " ,fmt_format = @fmt_format"
               + " ,fmt_setting = @fmt_setting"
               + " ,fmt_rule = @fmt_rule"
               + " ,fmt_align = @fmt_align"
               + " ,fmt_rep = @fmt_rep"
               + " ,fmt_length = @fmt_length"
               + " ,fmt_start = @fmt_start"
               + " ,fmt_num = @fmt_num"
               + " ,fmt_muser = @fmt_muser"
               + " ,fmt_mdate = " + DateTime.Now.ToString("yyyyMMddHHmmss")
               + " WHERE fmt_seqno = @fmt_seqno";



        SqlParameter[] sp =
        {
             new SqlParameter("@fmt_type",fmt_type), 
            new SqlParameter("@fmt_format",fmt_format) ,
            new SqlParameter("@fmt_setting",fmt_setting), 
            new SqlParameter("@fmt_rule",fmt_rule) ,
            new SqlParameter("@fmt_align",fmt_align), 
            new SqlParameter("@fmt_rep",fmt_rep), 
            new SqlParameter("@fmt_length",fmt_length), 
            new SqlParameter("@fmt_start",fmt_start), 
            new SqlParameter("@fmt_num",fmt_num),             
            new SqlParameter("@fmt_muser",fmt_muser) ,
            new SqlParameter("@fmt_seqno",fmt_seqno)   
        };

        Execute(strSQL, sp);
    }

    //刪除
    public void getdeleteData(string fmt_seqno //序號  
      )
    {
        String strSQL =
                          " delete sal_safmt "
                    + " where fmt_seqno = @fmt_seqno ";

        SqlParameter[] sp =
        {
              new SqlParameter("@fmt_seqno",fmt_seqno)         
        };
        Execute(strSQL, sp);
    }



}