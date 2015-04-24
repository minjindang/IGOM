using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL2201 的摘要描述
/// </summary>
public class SAL2201
{
    private SAL2201DAO DAO;
	public SAL2201()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2201DAO();
	}
    public SAL2201(SqlConnection conn)
        {
            DAO = new SAL2201DAO(conn);
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