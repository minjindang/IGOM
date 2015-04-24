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
public class SAL2204
{
    private SAL2204DAO DAO;
	public SAL2204()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2204DAO();
	}
    public SAL2204(SqlConnection conn)
        {
            DAO = new SAL2204DAO(conn);
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
            "501",
            "006",
            FlowID
            );
        return dt;
    }
}