using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2208 的摘要描述
/// </summary>
public class SAL2208
{
    private SAL2208DAO DAO;
	public SAL2208()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2208DAO();
	}
    public SAL2208(SqlConnection conn)
        {
            DAO = new SAL2208DAO(conn);
        }

        // 查詢資料
    public DataTable queryData(
        string FlowID
        )
    {
        DataTable dt = DAO.queryData(
            "005",
            "005",
            "D",
            "001",
            "450",
            "001",
            FlowID
            );
        return dt;
    }
}