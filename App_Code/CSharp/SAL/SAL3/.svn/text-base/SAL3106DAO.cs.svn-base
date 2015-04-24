using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
 
/// </summary>
public class SAL3106DAO : BaseDAO
{
	public SAL3106DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public SAL3106DAO(SqlConnection conn)
        : base(conn)
    {

    } 

    public DataTable queryData(
            string strOrgCode,
            string strID,
            string strname,
            string strym,
            string stract,
            string strcno,
            string RoleId,
            string strorg
        )
    {
        string strSQL =
       " select B.base_seqno,B.base_name,B.base_idno,P.*,cast(substring(p.promo_start_payym,1,4) - 1911 as varchar) + substring(p.promo_start_payym,5,4) as promo_start_payym1,cast(substring(p.promo_stop_payym,1,4) - 1911 as varchar) + substring(p.promo_stop_payym,5,4) as promo_stop_payym1  "
     + " from sal_sabase B,sal_sapromo P where base_seqno = promo_seqno and base_orgid = promo_orgid "
     + " AND promo_orgid=@strOrgCode"
     + " and base_status = 'Y' ";
        if (strorg != "ALL")
        {
            strSQL += " and (b.base_dep = @strorg or b.base_dep in (select depart_id from fsc_org where parent_depart_id=@strorg))  "; 
        }
        if (strID != "")
        {
            strSQL += " and  b.base_seqno = @strID ";
        }
        if (strname != "")
        {
            strSQL += " AND b.base_name = @strname ";
        }
        strSQL += " and p.promo_ym=@strym ";

        if (stract == "1")
        {
            strSQL += " and (base_edate='' or base_edate='99999999' or base_edate is null) ";
        }
        else if (stract == "2")
        {
            strSQL += " and base_edate <> '' ";
        }   
        if (strcno == "ALL")
        {
            switch (RoleId)  
            {
                case "001":
                    break;
                case "004":
                    break;
                case "005":
                    break;
                case "002":
                    strSQL += " and b.base_prono in ('001','002','003','004','005','007') ";
                    break;
                case "003":
                    strSQL += " and b.base_prono in ('001','002','003','004','005','007') ";
                    break;
                case "010":
                    strSQL += " and b.base_prono ='006' ";
                    break;
            }
        }
        if ((strcno != "ALL") && strcno != "")
        {
            strSQL += " and b.base_prono=@strcno ";
        }
        strSQL += " order by cast(base_prts as float) ";
              
            SqlParameter[] sp =
            {           
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strID",strID),
            new SqlParameter("@strname", strname),
            new SqlParameter("@strym", strym),
            new SqlParameter("@stract", stract),
            new SqlParameter("@strcno", strcno),
            new SqlParameter("@RoleId", RoleId),
            new SqlParameter("@strorg", strorg)
            };
            return Query(strSQL, sp);
    }
    
    
    public void querydeleteData(
      string c_promo_seqno,
      string c_promo_ym,
      string strOrgCode    
   )
    {
        string strSQL =
            "delete from sal_sapromo where promo_ym=@c_promo_ym AND promo_orgid= @strOrgCode  AND promo_seqno= @c_promo_seqno ";
                  
        SqlParameter[] sp =
        {            
            new SqlParameter("@c_promo_seqno",c_promo_seqno) ,
            new SqlParameter("@c_promo_ym",c_promo_ym) , 
            new SqlParameter("@strOrgCode",strOrgCode)          
        };

        Execute(strSQL, sp);
    }


    public void queryupdateData(
    string c_promo_seqno,
    string c_promo_ym,
    string strOrgCode,
    string c_promo_start_payym,
    string c_promo_stop_payym
 )
    {
        string strSQL =
            " update sal_sapromo set promo_start_payym=@c_promo_start_payym , promo_stop_payym =@c_promo_stop_payym "
           +" where promo_ym=@c_promo_ym AND promo_orgid= @strOrgCode  AND promo_seqno= @c_promo_seqno ";

        SqlParameter[] sp =
        {            
            new SqlParameter("@c_promo_seqno",c_promo_seqno) ,
            new SqlParameter("@c_promo_ym",c_promo_ym) , 
            new SqlParameter("@strOrgCode",strOrgCode)  ,
            new SqlParameter("@c_promo_start_payym",c_promo_start_payym) , 
            new SqlParameter("@c_promo_stop_payym",c_promo_stop_payym)          
        };

        Execute(strSQL, sp);
    }



    public DataTable querycheckData(
          string strOrgCode,
          string strID,
          string strname         
      )
    {
        string strSQL ="select * from sal_sabase where base_orgid = @strOrgCode ";

        if (strID != "")
        {
           strSQL+= " and base_seqno= @strID ";
        }

        if(strname != "")
        {
        strSQL+=" AND  base_name = @strname ";
        }

        SqlParameter[] sp =
            {           
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@strID",strID),
            new SqlParameter("@strname", strname)
            };
        return Query(strSQL, sp);
    }



    public DataTable queryaddData(
       string v_Promo_Ym,
       string strOrgCode,
       string base_seqno     
     )
    {
        string strSQL =
                  "select promo_seqno from sal_sapromo Where promo_ym = @v_Promo_Ym  and promo_orgid = @strOrgCode " 
                + "  and promo_seqno = @base_seqno ";

        SqlParameter[] sp =
            {           
            new SqlParameter("@v_Promo_Ym",v_Promo_Ym),
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@base_seqno", base_seqno)
            };
        return Query(strSQL, sp);
    }



    public void queryInsertData(
          string v_Promo_Ym,
          string strOrgCode,
          string base_seqno,
          string v_Promo_Start_Payym,
          string v_Promo_Stop_Payym,
          string v_Promo_muser,
          string v_Promo_Mdate,
          string v_Promo_Effect_Date
 )
    {
        string strSQL =         
            "Insert Into sal_sapromo ( promo_ym , promo_orgid , promo_seqno , promo_start_payym , promo_stop_payym , promo_muser , promo_mdate , promo_effect_date ) "
            + "  values( @v_Promo_Ym  , @strOrgCode  , @base_seqno , @v_Promo_Start_Payym "
            + " , @v_Promo_Stop_Payym  , @v_Promo_muser , @v_Promo_Mdate , @v_Promo_Effect_Date ) ";
                              
        SqlParameter[] sp =
        {            
            new SqlParameter("@v_Promo_Ym",v_Promo_Ym) ,          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@base_seqno",base_seqno) ,  
            new SqlParameter("@v_Promo_Start_Payym",v_Promo_Start_Payym) ,          
            new SqlParameter("@v_Promo_Stop_Payym",v_Promo_Stop_Payym),
            new SqlParameter("@v_Promo_muser",v_Promo_muser) ,  
            new SqlParameter("@v_Promo_Mdate",v_Promo_Mdate) ,          
            new SqlParameter("@v_Promo_Effect_Date",v_Promo_Effect_Date) 
        };

        Execute(strSQL, sp);
    }



    public DataTable queryadd2Data(
    string strOrgCode,
    string v_nowdate,
    string v_Promo_Start_Payym,
    string v_proj_code
   )
    {
        string strSQL =
          " select Base_Seqno,base_name,base_idno from sal_sabase where base_orgid =@strOrgCode "
        + " and base_prono in ('002','003','004','005','006') and base_status='Y' "
        + " AND (SUBSTRING(base_bdate, 1, 6) <= @v_nowdate  "
        + " OR base_bdate IS NULL OR base_bdate = '') "
        + " AND (SUBSTRING(base_edate, 1, 8) >= @v_Promo_Start_Payym  "
        + " OR base_edate IS NULL OR base_edate = '')";

        if (v_proj_code != "ALL" && v_proj_code != "")
        {
            strSQL += " and base_prono = @v_proj_code ";
        }

        strSQL += " order by cast(base_prts as float) ";

        SqlParameter[] sp =
            {           
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@v_nowdate",v_nowdate),
            new SqlParameter("@v_Promo_Start_Payym", v_Promo_Start_Payym),
            new SqlParameter("@v_proj_code", v_proj_code),
            };
        return Query(strSQL, sp);
    }




    public void queryInsert2Data(
       string v_Promo_Ym,
       string strOrgCode,
       string v_Base_Seqno,
       string v_Promo_Start_Payym,
       string v_Promo_Stop_Payym,
       string v_Promo_muser,
       string v_Promo_Mdate,
       string v_Promo_Effect_Date
 )
    {
        string strSQL = "delete sal_sapromo "
                 + "Where promo_ym=@v_Promo_Ym  and promo_orgid= @strOrgCode  "
                 + "and promo_seqno=@v_Base_Seqno  Insert Into sal_sapromo (promo_ym,promo_orgid,promo_seqno,promo_start_payym,promo_stop_payym,promo_muser,promo_mdate,promo_effect_date) "
                 + "values(@v_Promo_Ym ,@strOrgCode ,@v_Base_Seqno ,@v_Promo_Start_Payym ,@v_Promo_Stop_Payym ,@v_Promo_muser ,@v_Promo_Mdate , @v_Promo_Effect_Date) ";
                              
               
        SqlParameter[] sp =
        {            
            new SqlParameter("@v_Promo_Ym",v_Promo_Ym) ,          
            new SqlParameter("@strOrgCode",strOrgCode),
            new SqlParameter("@v_Base_Seqno",v_Base_Seqno) ,  
            new SqlParameter("@v_Promo_Start_Payym",v_Promo_Start_Payym) ,          
            new SqlParameter("@v_Promo_Stop_Payym",v_Promo_Stop_Payym),
            new SqlParameter("@v_Promo_muser",v_Promo_muser) ,  
            new SqlParameter("@v_Promo_Mdate",v_Promo_Mdate) ,          
            new SqlParameter("@v_Promo_Effect_Date",v_Promo_Effect_Date) 
        };

        Execute(strSQL, sp);
    }

      

}