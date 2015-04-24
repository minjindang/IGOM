using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL3110 的摘要描述
/// 
/// </summary>
public class EMP3110DAO : BaseDAO
{
    public EMP3110DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼 
        //
    }
    public EMP3110DAO(SqlConnection conn)
        : base(conn)
    {

    }  
   
   //查詢 
    public DataTable querysearch(
        string strAP_IP,  
        string strAP_name,  
        string strWS_type,   
        string strAP_code, 
        string strUcDate1,   
        string strUcDate2, 
        string strIs_disable, 
        string strPurpose, 
        string strNote_desc  
        )
    {
        string strSQL = " select * from EMP_Wsregisted_prof ";
               strSQL += "where Is_disable = @strIs_disable";
        if (strAP_IP != "")
        {
            strSQL += " and AP_IP = @strAP_IP";
        }
        if (strAP_name != "")
        {
            strSQL += " and AP_name = @strAP_name";
        }
        if (strWS_type != "")
        {
            strSQL += " and WS_type = @strWS_type";
        }
        if (strAP_code != "")
        {
            strSQL += " and system_code = @strAP_code";
        }
        if (strUcDate1 != "")
        {
            strSQL += " and Use_sdate = @strUcDate1";
        }
        if (strUcDate2 != "")
        {
            strSQL += " and Use_edate = @strUcDate2";
        }
        if (strPurpose != "")
        {
            strSQL += " and Purpose = @strPurpose";
        }
        if (strNote_desc != "")
        {
            strSQL += " and Note_desc = @strNote_desc";
        }      
        

        SqlParameter[] sp =
        {
            new SqlParameter("@strAP_IP", strAP_IP),
            new SqlParameter("@strAP_name", strAP_name),
            new SqlParameter("@strWS_type", strWS_type),
            new SqlParameter("@strAP_code", strAP_code),
            new SqlParameter("@strUcDate1", strUcDate1),
            new SqlParameter("@strUcDate2", strUcDate2),
            new SqlParameter("@strIs_disable", strIs_disable),
            new SqlParameter("@strPurpose", strPurpose),
            new SqlParameter("@strNote_desc", strNote_desc)
        };

        return Query(strSQL, sp);
    }


    // 新增
    public void queryadd(
        string strAP_IP,
        string strAP_name,
        string strWS_type,
        string strAP_code,
        string strUcDate3,
        string strUcDate4,
        string strIs_disable,
        string strPurpose,
        string strNote_desc  ,
        string UserId
        )
    {
        string strSQL =
            "INSERT INTO EMP_Wsregisted_prof " +
                       "(AP_IP " +
                       ",AP_name " +
                       ",WS_type " +
                       ",system_code " +
                       ",Use_sdate " +
                       ",Use_edate " +
                       ",Is_disable " +
                       ",Purpose " +
                       ",Note_desc " +
                       ",change_userid,change_date) " +
                 "VALUES (" +
                       " @strAP_IP " +
                       ",@strAP_name " +
                       ",@strWS_type " +
                       ",@strAP_code " +
                       ",@strUcDate3 " +
                       ",@strUcDate4 " +
                       ",@strIs_disable " +
                       ",@strPurpose " +
                       ",@strNote_desc " +
                       ",@UserId,getdate()) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@strAP_IP", strAP_IP),
            new SqlParameter("@strAP_name", strAP_name),
            new SqlParameter("@strWS_type", strWS_type),
            new SqlParameter("@strAP_code", strAP_code),
            new SqlParameter("@strUcDate3", strUcDate3),
            new SqlParameter("@strUcDate4", strUcDate4),
            new SqlParameter("@strIs_disable", strIs_disable),
            new SqlParameter("@strPurpose", strPurpose),
            new SqlParameter("@strNote_desc", strNote_desc),  
            new SqlParameter("@UserId", UserId)
        };

        Execute(strSQL, sp);
    }

    //刪除
    public void querydelete(string id
        )
    {
        string strSQL = " DELETE FROM EMP_Wsregisted_prof "
                      + " WHERE id = @id";

        SqlParameter[] sp =
        {             
            new SqlParameter("@id", id)
        };

        Execute(strSQL, sp);
    }


    //修改
    public void queryedit(
        string strAP_IP,
        string strAP_name,
        string strWS_type,
        string strAP_code,
        string strUcDate3,
        string strUcDate4,
        string strIs_disable,
        string strPurpose,
        string strNote_desc,
        string UserId,
        string edit_id
    )
    {
        string strSQL=
            "UPDATE EMP_Wsregisted_prof " +
            "SET AP_IP= @strAP_IP " +
            ",AP_name=  @strAP_name " +
            ",WS_type= @strWS_type " +
            ",system_code= @strAP_code " +
            ",use_sdate= @strUcDate3 " +
            ",use_edate= @strUcDate4 " +
            ",Is_disable = @strIs_disable" +
            ",Purpose = @strPurpose" +
            ",Note_desc = @strNote_desc" +
            ",change_userid = @UserId" +
            ",change_date = getdate()" +                    
            "WHERE id= @id ";

        SqlParameter[] sp =
        {
            new SqlParameter("@strAP_IP", strAP_IP),
            new SqlParameter("@strAP_name", strAP_name),
            new SqlParameter("@strWS_type", strWS_type),
            new SqlParameter("@strAP_code", strAP_code),
            new SqlParameter("@strUcDate3", strUcDate3),
            new SqlParameter("@strUcDate4", strUcDate4),
            new SqlParameter("@strIs_disable", strIs_disable),
            new SqlParameter("@strPurpose", strPurpose),
            new SqlParameter("@strNote_desc", strNote_desc),  
            new SqlParameter("@UserId", UserId),
            new SqlParameter("@id", edit_id)
        };

        Execute(strSQL, sp);
    } 


}