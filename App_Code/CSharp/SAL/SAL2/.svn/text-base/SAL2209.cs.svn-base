using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2209 的摘要描述
/// </summary>
public class SAL2209
{
    private SAL2209DAO DAO;
	public SAL2209()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2209DAO();
	}
    public SAL2209(SqlConnection conn)
        {
            DAO = new SAL2209DAO(conn);
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
            "453",
            "004",
            FlowID
            );
        return dt;
    }
}