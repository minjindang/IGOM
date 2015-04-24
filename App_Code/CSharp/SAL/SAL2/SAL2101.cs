using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 2014/4/29
/// SAL2101 薪餉單查詢
/// SAL2101 的摘要描述
/// </summary>
public class SAL2101 
{
    private SAL2101DAO DAO;

	public SAL2101()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        DAO = new SAL2101DAO();
	}

    public SAL2101(SqlConnection conn)
    {
        DAO = new SAL2101DAO(conn);
    }

    public DataTable getData(
    string strPayoOrgID,
    string strPayoSeqNo
    )
    {
        DataTable dt= DAO.getData(
            strPayoOrgID,
            strPayoSeqNo
        );
        return dt;
    }
}