using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4102DAO 的摘要描述
/// </summary>
public class SAL4102DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4102DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL4102DAO(SqlConnection conn)
        : base(conn)
    {

    }


    public DataTable getSearchData(string strcode_no)//依畫面選擇銀行代號
    {
        String strSQL =
                                 "   select trnfmt_bank_codeno"//--銀行別代碼,索引值(一)
                     + "   , trnfmt_seq"//--清單中之欄位順序,索引值(二)
                     + "   , case trnfmt_source_type when '001' then trnfmt_table"
                     + "   when '002' then '日期格式'"
                     + "   when '003' then '序號格式'"
                     + "   when '004' then '空白格式'"
                     + "   when '005' then '使用者自訂'"
                     + "   when '006' then '檢查碼'"
                     + "   end as 資料表名稱"//--清單中之資料表名稱
                     + "   , case trnfmt_source_type when '001' then trnfmt_field"
                     + "   when '002' then '日期格式'"
                     + "   when '003' then '序號格式'"
                     + "   when '004' then '空白格式'"
                     + "   when '005' then '使用者自訂'"
                     + "   when '006' then '檢查碼'"
                     + "   end as 欄位名稱"//--清單中之資欄位名稱
                     + "   , case trnfmt_align "
                     + "   when 'L' then '左'"
                     + "   when 'R' then '右'"
                     + "   end as 起始位置"//--清單中之起始位置
                     + "   , trnfmt_length "//--清單中之長度
                     + "   , trnfmt_replace "//--清單中之補值
                     + "   , trnfmt_source_type,trnfmt_table,trnfmt_field,trnfmt_align,trnfmt_substart,trnfmt_subend"//--維護用
                     + "   from sal_satrnfmt"
                     + "   where trnfmt_bank_codeno = @strcode_no"
                     + "   order by cast(trnfmt_seq as int)";



        SqlParameter[] sp = { new SqlParameter("@strcode_no", strcode_no) };
        return Query(strSQL, sp);
    }

    //查欄位順序
    public DataTable getnumData(string strcode_no)
    {
        String strSQL =
                    " select isnull(max(cast(trnfmt_seq as int)),0) + 1 as seq "
               + " from sal_satrnfmt "
               + " where trnfmt_bank_codeno = @strcode_no";

        SqlParameter[] sp = { new SqlParameter("@strcode_no", strcode_no) };
        return Query(strSQL, sp);
    }     


    // 新增
    public void getaddData(string TRNFMT_SEQ //欄位順序       
        , string TRNFMT_BANK_CODENO         //銀行代碼
        , string TRNFMT_SOURCE_TYPE      //資料形式   
        , string TRNFMT_TABLE         //資料表名稱
        , string TRNFMT_FIELD        //欄位名稱
        , string TRNFMT_ALIGN       //起始位置
        , string TRNFMT_LENGTH       //長度
        , string TRNFMT_REPLACE      //補值
        , string TRNFMT_SUBSTART     //字串起始位址
             , string TRNFMT_SUBEND   //字串位數
             , string strmuser     //登入者員工編號
        )
    {
        String strSQL =
                          " INSERT INTO SAL_SATRNFMT (TRNFMT_SEQ, TRNFMT_BANK_CODENO, TRNFMT_SOURCE_TYPE, TRNFMT_TABLE, TRNFMT_FIELD, "
       + " TRNFMT_ALIGN, TRNFMT_LENGTH, TRNFMT_REPLACE, TRNFMT_SUBSTART, TRNFMT_SUBEND, TRNFMT_MUSER, TRNFMT_MDATE) "
                          + "  VALUES (@TRNFMT_SEQ "
                          + "  , @TRNFMT_BANK_CODENO "
                          + "  , @TRNFMT_SOURCE_TYPE   "
                          + "  , @TRNFMT_TABLE"
                          + "  , @TRNFMT_FIELD   "
                          + "  , @TRNFMT_ALIGN"
                          + "  , @TRNFMT_LENGTH   "
                          + "  , @TRNFMT_REPLACE"
                          + "  , @TRNFMT_SUBSTART"
                          + "  , @TRNFMT_SUBEND"
                          + "  , @strmuser"
                          + "  , " + DateTime.Now.ToString("yyyyMMddHHmmss") + " )";


        SqlParameter[] sp =
        {
            new SqlParameter("@TRNFMT_SEQ",TRNFMT_SEQ), 
            new SqlParameter("@TRNFMT_BANK_CODENO",TRNFMT_BANK_CODENO) ,
            new SqlParameter("@TRNFMT_SOURCE_TYPE",TRNFMT_SOURCE_TYPE), 
            new SqlParameter("@TRNFMT_TABLE",TRNFMT_TABLE) ,
            new SqlParameter("@TRNFMT_FIELD",TRNFMT_FIELD), 
            new SqlParameter("@TRNFMT_ALIGN",TRNFMT_ALIGN), 
            new SqlParameter("@TRNFMT_LENGTH",TRNFMT_LENGTH), 
            new SqlParameter("@TRNFMT_REPLACE",TRNFMT_REPLACE), 
            new SqlParameter("@TRNFMT_SUBSTART",TRNFMT_SUBSTART),  
            new SqlParameter("@TRNFMT_SUBEND",TRNFMT_SUBEND) ,
            new SqlParameter("@strmuser",strmuser)   
        };

        Execute(strSQL, sp);
    }



    // 維護
    public void geteditData(string TRNFMT_SEQ //欄位順序       
        , string TRNFMT_BANK_CODENO         //銀行代碼
        , string TRNFMT_SOURCE_TYPE      //資料形式   
        , string TRNFMT_TABLE         //資料表名稱
        , string TRNFMT_FIELD        //欄位名稱
        , string TRNFMT_ALIGN       //起始位置
        , string TRNFMT_LENGTH       //長度
        , string TRNFMT_REPLACE      //補值
        , string TRNFMT_SUBSTART     //字串起始位址
             , string TRNFMT_SUBEND   //字串位數
             , string strmuser     //登入者員工編號
        )
    {
        String strSQL =
                                    "  UPDATE SAL_SATRNFMT "
                          + "  SET TRNFMT_SOURCE_TYPE = @TRNFMT_SOURCE_TYPE "
                          + "  , TRNFMT_TABLE = @TRNFMT_TABLE"
                          + "  , TRNFMT_FIELD = @TRNFMT_FIELD"
                          + "  , TRNFMT_ALIGN = @TRNFMT_ALIGN"
                          + "  , TRNFMT_LENGTH = @TRNFMT_LENGTH"
                          + "  , TRNFMT_REPLACE = @TRNFMT_REPLACE"
                          + "  , TRNFMT_SUBSTART = @TRNFMT_SUBSTART"
                          + "  , TRNFMT_SUBEND = @TRNFMT_SUBEND"
                          + "  , TRNFMT_MUSER = @strmuser"
                          + "  , TRNFMT_MDATE = " + DateTime.Now.ToString("yyyyMMddHHmmss")
                          + "  WHERE TRNFMT_BANK_CODENO =@TRNFMT_BANK_CODENO"
                          + "  AND TRNFMT_SEQ =@TRNFMT_SEQ";


        SqlParameter[] sp =
        {
             new SqlParameter("@TRNFMT_SEQ",TRNFMT_SEQ), 
            new SqlParameter("@TRNFMT_BANK_CODENO",TRNFMT_BANK_CODENO) ,
            new SqlParameter("@TRNFMT_SOURCE_TYPE",TRNFMT_SOURCE_TYPE), 
            new SqlParameter("@TRNFMT_TABLE",TRNFMT_TABLE) ,
            new SqlParameter("@TRNFMT_FIELD",TRNFMT_FIELD), 
            new SqlParameter("@TRNFMT_ALIGN",TRNFMT_ALIGN), 
            new SqlParameter("@TRNFMT_LENGTH",TRNFMT_LENGTH), 
            new SqlParameter("@TRNFMT_REPLACE",TRNFMT_REPLACE), 
            new SqlParameter("@TRNFMT_SUBSTART",TRNFMT_SUBSTART),  
            new SqlParameter("@TRNFMT_SUBEND",TRNFMT_SUBEND) ,
            new SqlParameter("@strmuser",strmuser)   
        };

        Execute(strSQL, sp);
    }

    //刪除
    public void getdeleteData(string TRNFMT_SEQ //欄位順序    
      , string TRNFMT_BANK_CODENO         //銀行代碼 
      )
    {
        String strSQL =
                " DELETE FROM SAL_SATRNFMT "
              + " WHERE TRNFMT_BANK_CODENO = @TRNFMT_BANK_CODENO"
              + "  AND TRNFMT_SEQ = @TRNFMT_SEQ";

        SqlParameter[] sp =
        {
              new SqlParameter("@TRNFMT_SEQ",TRNFMT_SEQ), 
            new SqlParameter("@TRNFMT_BANK_CODENO",TRNFMT_BANK_CODENO) 
        };

        Execute(strSQL, sp);
    }



}