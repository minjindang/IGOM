using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL4101DAO 的摘要描述
/// </summary>
public class SAL4101DAO : BaseDAO
{ 
    //private SqlConnection conn;
    public SAL4101DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }

    public SAL4101DAO(SqlConnection conn)
        : base(conn)
    {

    }

    //勞保事故保險金額分級表啟用年月
    public DataTable getYearData(string strStwsType)
    {
        String strSQL =
            " select stws_ym "//--查詢畫面之年月內容值
          + " , (cast(cast(substring(stws_ym,1,4) as int) - 1911 as varchar) + ' 年 ' + substring(stws_ym,5,2) + ' 月') as ymstr"//--查詢畫面之文字
          + " from sal_sastws "
          + " where "
          + " STWS_no=@StwsType "
          + " group by stws_ym "
          + " order by stws_ym desc ";

        SqlParameter[] sp = { 
                            new SqlParameter("@StwsType", strStwsType)
                            };
        return Query(strSQL, sp);
    }
    //依畫面選擇年月查詢
    public DataTable getSearchData(string strYear, string strno)
    {
        String strSQL =
             "  select stws_ym "//--生效年月,維護使用之資料索引值(一)
           + " ,stws_no "//--表別,維護使用之資料索引值(二)
           + " ,stws_level "//--投保金額等級,維護使用之資料索引值(三)
           + " ,cast(stws_low as int) as stws_low "//--維護時呈現之月薪資所得上限
           + " ,cast(stws_up as int) as stws_up "//--維護時呈現之月薪資所得下限
           + " ,cast(isnull(stws_dct1,0) as int) as stws_dct1 "//--查詢清單1日之金額
           + " ,cast(isnull(stws_dct2,0) as int) as stws_dct2 "//--查詢清單30日之金額
           + " ,STWS_DCT,STWS_SUP,stws_type,stws_stand from sal_sastws "
           + " where stws_ym = @strYear "
           + " and stws_no = @strno "
           + " order by cast(stws_level as int)";

        SqlParameter[] sp = { new SqlParameter("@strYear", strYear) ,
                              new SqlParameter("@strno", strno)};
        return Query(strSQL, sp);
    }

    // 新增
    public void getaddData(
          string stws_ym //年月
        , string stws_level      // 畫面輸入之投保金額等級   
        , string stws_up         //畫面輸入之月薪資所得上限
        , string stws_low        //畫面輸入之月薪資所得下限
        , string stws_dct1       //1日(投保日數)自負擔金額
        , string stws_dct2       //30日(投保日數)自負擔金額
        , string stws_muser      //登入者員工編號
        , string stws_type  // 保險種類
        , string STWS_DCT   // 自負擔
        , string STWS_SUP   // 機關負擔    
        , string strstws_stand //保險金額
        )
    {
      
        String strSQL =
                 " insert into sal_sastws(stws_no,stws_ym, stws_level, " +
                 " stws_up, stws_low, stws_dct1, stws_dct2, stws_muser, stws_mdate , STWS_DCT , STWS_SUP, stws_stand ,stws_type) "
                 + " values(@stws_type "
                 + "  ,@stws_ym" //--西元年4碼+月份2碼,畫面民國年轉西元年EX:201407        
                 + "  ,@stws_level" //新增畫面輸入之投保金額等級
                 + "  ,@stws_up" //新增畫面輸入之月薪資所得上限
                 + "  ,@stws_low"//新增畫面輸入之月薪資所得下限
                 + "  ,@stws_dct1"//新增畫面輸入之1日(投保日數)自負擔金額
                 + "  ,@stws_dct2"//新增畫面輸入之30日(投保日數)自負擔金額
                 + "  ,@stws_muser"//登入者員工編號
                 + "  ,@stws_mdate "
                 + "  ,@STWS_DCT "
                 + "  ,@STWS_SUP "
                 + "  ,@strstws_stand "
                 + ",'')"; //現在時間now.tostring("yyyyMMddHHmmss"))


        SqlParameter[] sp =
        {              
            new SqlParameter("@stws_ym",stws_ym), //畫面選單之年加月       
            new SqlParameter("@stws_level",stws_level), //新增畫面輸入之投保金額等級
            new SqlParameter("@stws_up",stws_up) ,//新增畫面輸入之月薪資所得上限
            new SqlParameter("@stws_low",stws_low), //新增畫面輸入之月薪資所得下限
            new SqlParameter("@stws_dct1",stws_dct1), //新增畫面輸入之1日(投保日數)自負擔金額
            new SqlParameter("@stws_dct2",stws_dct2), //新增畫面輸入之30日(投保日數)自負擔金額
            new SqlParameter("@stws_muser",stws_muser), //登入者員工編號 
            new SqlParameter("@stws_type",stws_type), //stws_type種類  
            new SqlParameter("@STWS_DCT",STWS_DCT),  
            new SqlParameter("@STWS_SUP",STWS_SUP), 
            new SqlParameter("@stws_mdate",DateTime.Now.ToString("yyyyMMddHHmmss")) ,
            new SqlParameter("@strstws_stand",strstws_stand)
        };

        Execute(strSQL, sp);
    }

    // 維護 
    public void geteditData(string stws_ym //年月
        , string stws_no         // 表別
        , string stws_level      // 畫面輸入之投保金額等級   
        , string stws_up         //畫面輸入之月薪資所得上限
        , string stws_low        //畫面輸入之月薪資所得下限
        , string stws_dct1       //1日(投保日數)自負擔金額
        , string stws_dct2       //30日(投保日數)自負擔金額
        , string stws_muser      //登入者員工編號
        , string strstws_stand //保險金額
        , string STWS_DCT   // 自負擔
        , string STWS_SUP   // 機關負擔    
        )
    {
        String strSQL =
              "  update sal_sastws "
            + "    set stws_low = @stws_low"
            + "    , stws_up = @stws_up"
            + "    , stws_dct1 =@stws_dct1"
            + "    , stws_dct2 = @stws_dct2"
            + "    , stws_muser = @stws_muser"
            + "    , stws_stand =@strstws_stand"
            + "    , STWS_SUP = @STWS_SUP"
            + "    , STWS_DCT = @STWS_DCT"
            + "    , stws_mdate = " + DateTime.Now.ToString("yyyyMMddHHmmss")
            + "    where stws_ym = @stws_ym"//--清單之生效年月,索引值(一) "
            + "    and stws_no = @stws_no "//--清單之表別,維護使用之資料索引值(二)
            + "    and stws_level = @stws_level ";//--清單之投保金額等級,維護使用之資料索引值(三)



        SqlParameter[] sp =
        {
            new SqlParameter("@stws_ym",stws_ym), //畫面選單之年加月       
            new SqlParameter("@stws_no",stws_no) ,//表別='001'
            new SqlParameter("@stws_level",stws_level), //新增畫面輸入之投保金額等級
            new SqlParameter("@stws_up",stws_up) ,//新增畫面輸入之月薪資所得上限
            new SqlParameter("@stws_low",stws_low), //新增畫面輸入之月薪資所得下限
            new SqlParameter("@stws_dct1",stws_dct1), //新增畫面輸入之1日(投保日數)自負擔金額
            new SqlParameter("@stws_dct2",stws_dct2), //新增畫面輸入之30日(投保日數)自負擔金額
            new SqlParameter("@stws_muser",stws_muser), //登入者員工編號 
            new SqlParameter("@STWS_DCT",STWS_DCT),  
            new SqlParameter("@STWS_SUP",STWS_SUP),
            new SqlParameter("@strstws_stand",strstws_stand)
        };

        Execute(strSQL, sp);
    }

    //刪除
    public void getdeleteData(string stws_ym //年月
      , string stws_no        
      , string stws_level      // 畫面輸入之投保金額等級  
      )
    {
        String strSQL = " delete sal_sastws "
               + " where stws_ym = @stws_ym "//--清單之生效年月,索引值(一) 
               + " and stws_no = @stws_no "//--清單之表別,維護使用之資料索引值(二)
               + " and stws_level = @stws_level";//--清單之投保金額等級,維護使用之資料索引值(三)        

        SqlParameter[] sp =
        {
            new SqlParameter("@stws_ym",stws_ym), //畫面選單之年加月       
            new SqlParameter("@stws_no",stws_no) ,
            new SqlParameter("@stws_level",stws_level), //新增畫面輸入之投保金額等級 
        };

        Execute(strSQL, sp);
    }



}