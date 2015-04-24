using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2207 的摘要描述
/// </summary>
public class SAL2207
{
    private SAL2207DAO DAO;
	public SAL2207()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2207DAO();
	}
    public SAL2207(SqlConnection conn)
        {
            DAO = new SAL2207DAO(conn);
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
            "451",
            "002",
            FlowID
            );
        return dt;
    }
}