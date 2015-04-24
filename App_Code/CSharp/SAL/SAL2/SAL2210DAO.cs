using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL2210DAO 的摘要描述
/// 不休假加班費發放清冊
/// </summary>
public class SAL2210DAO : BaseDAO
{
	public SAL2210DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL2210DAO(SqlConnection conn)
        : base(conn)
    {


    }

    // 查詢資料
    public DataTable queryData(string FlowID)
    {
        string strSQL =
            "select * from FSC_Settlement_Annual where 1=1  ";
        if (FlowID != "")
        {
            strSQL +=
            " and ( Flow_id=@Flow_id or Flow_id in (select Flow_id from SYS_Flow where Merge_flowid=@Flow_id) ) ";
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@Flow_id",FlowID)
        };
        return Query(strSQL, sp);
    }
}