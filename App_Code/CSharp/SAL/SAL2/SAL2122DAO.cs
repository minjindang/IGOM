using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// </summary>
public class SAL2122DAO : BaseDAO
{
    public SAL2122DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL2122DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable queryData(
        string ym1,    
        string ym2,     
        string strPayBudgeCode 
    )
    {
        string strSQL = " Select substring(inco_date,5,2) as mm "
                    +" , c1.code_desc1 "//-- 薪資種類
                    +" , Depart_name "//-- 單位
                    +" , BASE_NAME   "//-- 姓名
                    +" , c2.code_desc1 as desc2 "//-- 職員類別
                    +" , inco_amt  ,0 as mout"//    -- 給付金額
                    +" From sal_sainco "
                    +" Left outer join sal_sabase "
                    +" On BASE_ORGID = inco_orgid "
                    +" and BASE_SEQNO = inco_seqno "
                    +" left outer join FSC_ORG "
                    +" on BASE_DEP = Depart_id "
                    +" left outer join SYS_CODE c1 "
                    +" on c1.CODE_SYS = '003' "
                    +" and c1.CODE_TYPE = '004' "
                    +" and c1.CODE_NO = inco_icode "
                    +" left outer join SYS_CODE c2 "
                    +" on c2.CODE_SYS = '002' "
                    +" and c2.CODE_TYPE = '001' "
                    +" and c2.CODE_NO = BASE_PRONO "
                    +" where substring(inco_date,1,6) between @ym1 and @ym2 "
                    +" and INCO_Budget_code = @strPayBudgeCode ";


        SqlParameter[] sp =
        {
            new SqlParameter("@ym1",ym1),
            new SqlParameter("@ym2",ym2), 
            new SqlParameter("@strPayBudgeCode",strPayBudgeCode)          
        };

        return Query(strSQL, sp);

    }
}