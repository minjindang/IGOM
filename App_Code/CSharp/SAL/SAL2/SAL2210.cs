using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2210 的摘要描述
/// </summary>
public class SAL2210
{
    private SAL2210DAO DAO;
	public SAL2210()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2210DAO();
	}
    public SAL2210(SqlConnection conn)
        {
            DAO = new SAL2210DAO(conn);
        }

        // 查詢資料
    public DataTable queryData(string FlowID)
    {
        DataTable dt = DAO.queryData(FlowID);
        return dt;
    }
}