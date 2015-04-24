using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2206 的摘要描述
/// </summary>
public class SAL2206
{
    private SAL2206DAO DAO;
	public SAL2206()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2206DAO();
	}
    public SAL2206(SqlConnection conn)
        {
            DAO = new SAL2206DAO(conn);
        }

        // 查詢資料
    public DataTable queryData(
        string FlowID
        )
    {
        DataTable dt = DAO.queryData(
            "001",
            "003",
            "P",
            "003",
            "003",
            "",
            FlowID
            );
        return dt;
    }
}