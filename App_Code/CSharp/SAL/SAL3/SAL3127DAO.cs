using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3127DAO 的摘要描述
/// </summary>
public class SAL3127DAO : BaseDAO
{
    //private SqlConnection conn;
    public SAL3127DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3127DAO(SqlConnection conn)
        : base(conn)
    {

    }


    public DataTable getddlData(string strOrgCode//登入者機關代碼
            , string strTYPE  //發放方式代碼
            , string strcode  //項目類別代碼
            , string strddl   //是否隨薪代碼
        )
    {
        String strSQL =
                  " SELECT ITEM_NAME + ' (' + ITEM_CODE + ')' as ITEM_NAME" //--下拉選項文字
                 +" ,ITEM_CODE "//--下拉選項代碼
                 +"  FROM  SAL_SAITEM"
                 +"  WHERE ( ITEM_ORGID = @strOrgCode)"
                 +"  AND ( ITEM_CODE_SYS= '005')"
                 +"  AND ( ITEM_CODE_KIND= 'D')"
                 +"  AND ( ITEM_CODE_TYPE=@strTYPE)"
                 +"  AND ( ITEM_CODE_NO=@strcode)"
                 +"  AND ( ITEM_TYPE =@strddl)"
                 +"  AND ( ITEM_SUSPEND = 'N' )";   
                    
        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@strTYPE",strTYPE),          
            new SqlParameter("@strcode",strcode) ,
            new SqlParameter("@strddl",strddl)  
        };

        return Query(strSQL, sp);
    }

     
    public DataTable getddl2Data(string strOrgCode//登入者機關代碼
          , string name  //項目名稱代碼
      )
    {
        String strSQL =
              " select item_icode"
              + "  from sal_saitem"
              + "  where item_orgid =@strOrgCode"
              + "  and item_code =@name";


        SqlParameter[] sp =
        {
            new SqlParameter("@strOrgCode",strOrgCode),  
            new SqlParameter("@name",name)  
        };

        return Query(strSQL, sp);
    }


    public DataTable getddl2textData(string textno//所得格式代碼
   )
    {
        String strSQL =
                " Select code_desc1 from sys_code "
             +  " Where code_sys = '003'"
             +  " And code_type = '004'"
             + " And code_no =@textno ";

        SqlParameter[] sp =
        {
            new SqlParameter("@textno",textno)         
        };

        return Query(strSQL, sp);
    }



       public void querydeleteData(string strOrgCode//登入者機關代碼
            )
       {
           String strSQL ="delete from sal_saincobak where inco_orgid=@strOrgCode ";

           SqlParameter[] sp =
           {
               new SqlParameter("@strOrgCode",strOrgCode)             
           };

           Execute(strSQL, sp);
       }

       //查員工編號  
       public DataTable getseqnoData(string strOrgCode
           , string idno      
  )
       {
           String strSQL =
              "select base_seqno from sal_sabase where base_orgid=@orgid and base_idno=@idno";

           SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgCode)  ,      
            new SqlParameter("@idno",idno)        
        };

           return Query(strSQL, sp);
       }

       //所得類別代碼
       public DataTable geticode(string v_icode )
       {
           String strSQL = " select * from sys_code  " +
                           " where code_sys='003' and code_type = '004' and CODE_DESC1  like '%' + @v_icode + '%' ";

           SqlParameter[] sp =
        {
            new SqlParameter("@v_icode",v_icode) 
        };

           return Query(strSQL, sp);
       }

       public void insertSABASE(string v_idno, string v_name, string v_inco_addr)
       {
           string sql = " insert into sal_sabase(base_seqno, base_idno, base_name, "
               + " base_addr, base_orgid, base_muser,base_mdate ) values("
               + " (Select '#' + RIGHT( '000000' + cast(isnull(max(substring(base_seqno,2,5)) ,0) + 1 as varchar),5) from sal_sabase where base_seqno like '#%' and len(base_seqno) = 6 ), "
               + " @v_idno, @v_name , @v_inco_addr, @base_orgid, "
               + " @base_muser, @base_mdate )";

           SqlParameter[] sp = {
        new SqlParameter ("@base_orgid",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)),
        new SqlParameter ("@v_idno",v_idno ),
        new SqlParameter ("@v_name",v_name ),
        new SqlParameter ("@v_inco_addr",v_inco_addr ),
        new SqlParameter ("@base_muser",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)),
        new SqlParameter ("@base_mdate",DateTime.Now.ToString("yyyyMMddHHmmss"))};

           Execute(sql, sp);
       }

       public void updateSABASE(string v_orgid, string v_seqno, string v_idno, string v_name, string v_inco_addr)
       {
           string sql = " update sal_sabase set base_name=@base_name, "
               + "  base_addr=@base_addr, "
               + " base_muser=@base_muser, base_mdate=@base_mdate "
               + " where base_orgid=@base_orgid and base_idno=@base_idno and base_seqno=@base_seqno ";

           SqlParameter[] sp = {
        new SqlParameter ("@base_orgid",v_orgid ),
        new SqlParameter ("@base_idno",v_idno ),
        new SqlParameter ("@base_name",v_name ),    
        new SqlParameter ("@base_seqno",v_seqno ),
        new SqlParameter ("@base_addr",v_inco_addr ),
        new SqlParameter ("@base_muser",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)),
        new SqlParameter ("@base_mdate",DateTime.Now.ToString("yyyyMMddHHmmss"))};

           Execute(sql, sp);
       }


       //get prikey
       public DataTable getprikeyData(
  )
       {
           String strSQL =
            " declare @seqno int  declare @lpad_seqno varchar(8000) "
          + " exec get_sequenceno @seqno output   exec lpad @seqno ,12,'0',@lpad_seqno output "
          + " select @lpad_seqno ";


           SqlParameter[] sp =
        {           
        };

           return Query(strSQL, sp);
       }


       //轉檔
       public void queryinsertData(
              string v_orgid
            , string v_seqno
            , string PAYITEM_flow_id
            , string PAYITEM_merge_flow_id
            , string v_code_sys
            , string v_code_type
            , string v_code_no
            , string v_code
            , string PAYITEM_Budget_code
            , string v_amt
            , string v_mid
          
           )
       {
           String strSQL =
               //0517
    /*           " insert into sapitmbak(pitm_orgid, pitm_seqno, pitm_code_sys, pitm_code_kind, pitm_code_type, "
           + " pitm_code_no, pitm_code, pitm_amt, pitm_muser, pitm_mdate ) values"
           + " (@v_orgid ,@v_seqno ,@v_code_sys ,'D',@v_code_type , "
           + " @v_code_no ,@v_code ,@v_amt,@v_mid ,@v_mdate )";
    */
             " insert into SAL_PAYITEM(PAYITEM_org_code, PAYITEM_user_id, PAYITEM_flow_id, PAYITEM_merge_flow_id,PAYITEM_codesys,PAYITEM_codekind"
           + " , PAYITEM_codetype , PAYITEM_codeno , PAYITEM_code,PAYITEM_Budget_code, PAYITEM_pay_amt , PAYITEM_moduser_id, PAYITEM_Mod_date ) "
           + " values"
           + " (@v_orgid ,@v_seqno,@PAYITEM_flow_id,@PAYITEM_merge_flow_id ,@v_code_sys ,'D',@v_code_type , "
           + " @v_code_no ,@v_code ,@PAYITEM_Budget_code ,@v_amt,@v_mid ,GETDATE() )";

           SqlParameter[] sp =
           {              
                new SqlParameter("@v_orgid",v_orgid),
                new SqlParameter("@v_seqno",v_seqno),
                new SqlParameter("@PAYITEM_flow_id",PAYITEM_flow_id),
                new SqlParameter("@PAYITEM_merge_flow_id",PAYITEM_merge_flow_id),
                new SqlParameter("@v_code_sys",v_code_sys),
                new SqlParameter("@v_code_type",v_code_type),
                new SqlParameter("@v_code_no",v_code_no),
                new SqlParameter("@v_code",v_code),
                new SqlParameter("@PAYITEM_Budget_code",PAYITEM_Budget_code),
                new SqlParameter("@v_amt",v_amt),
                new SqlParameter("@v_mid",v_mid)                         
           };

           Execute(strSQL, sp);
       }

    /*
       //將暫存資料轉入 SaPitm (同一人的金額會加總)
       public void querygropData(string v_mid
        , string v_mdate
        , string v_orgid
        , string v_code_sys
        , string v_code_type
        , string v_code_no
        , string v_code
           )
       {
           String strSQL =
          " insert into sapitm(pitm_orgid, pitm_seqno, pitm_code_sys, pitm_code_kind, pitm_code_type, "
        + " pitm_code_no, pitm_code, pitm_amt, pitm_muser, pitm_mdate) "
        + " select t.pitm_orgid, t.pitm_seqno, t.pitm_code_sys, t.pitm_code_kind, t.pitm_code_type, "
        + " t.pitm_code_no, t.pitm_code, t.tot_amt, @v_mid , @v_mdate "
        + " from ("
        + " select pitm_orgid, pitm_seqno, pitm_code_sys, pitm_code_kind, pitm_code_type, "
        + " pitm_code_no, pitm_code, sum(pitm_amt) as tot_amt "
        + " from sapitmbak "
        + " where pitm_orgid=@v_orgid "
        + " and pitm_code_sys=@v_code_sys "
        + " and pitm_code_type=@v_code_type "
        + " and pitm_code_no=@v_code_no"
        + " and pitm_code=@v_code "
        + " group by pitm_orgid, pitm_seqno, pitm_code_sys, pitm_code_kind, pitm_code_type, pitm_code_no, pitm_code "
        + " ) t";

           SqlParameter[] sp =
           {  
                new SqlParameter("@v_mid",v_mid),
                new SqlParameter("@v_mdate",v_mdate),           
                new SqlParameter("@v_orgid",v_orgid),             
                new SqlParameter("@v_code_sys",v_code_sys),
                new SqlParameter("@v_code_type",v_code_type),
                new SqlParameter("@v_code_no",v_code_no),
                new SqlParameter("@v_code",v_code), 
           };

           Execute(strSQL, sp);
       }
    */

       public void querydelete2Data(
        string strOrgCode     
          )
       {
           String strSQL = "delete from sapitmbak where pitm_orgid=@strOrgCode"; 
       

           SqlParameter[] sp =
           {  
                new SqlParameter("@strOrgCode",strOrgCode)
              
           };

           Execute(strSQL, sp);
       }


       public void querydelete3Data(
          string strOrgCode
        , string v_code_sys
        , string v_code_type
        , string v_code_no
        , string v_code
          )
       {
           String strSQL = "delete from sal_sapitm "
       +" where pitm_orgid=@v_orgid"
       +" and pitm_code_sys=@v_code_sys"
       +" and pitm_code_type=@v_code_type"
       +" and pitm_code_no=@v_code_no"
       +" and pitm_code=@v_code";

           SqlParameter[] sp =
           {  
                new SqlParameter("@strOrgCode",strOrgCode),
                new SqlParameter("@v_code_sys",v_code_sys),
                new SqlParameter("@v_code_type",v_code_type),
                new SqlParameter("@v_code_no",v_code_no),
                new SqlParameter("@v_code",v_code)
           };

           Execute(strSQL, sp);
       }



     public void queryinsert2Data(string v_kind
    , string v_seqno
    , string v_orgid
    , string v_inco_date
    , string v_icode
    , string v_inco_amt
    , string v_inco_txra
    , string v_inco_txam
    , string v_inco_fee
    , string v_inco_fees
    , string v_inco_leave_self
    , string v_inco_leave_sup
    , string v_mid
    , string v_mdate
    , string v_inco_ym
    , string key
    , string v_code_type
    , string v_code_no
    , string v_code
          )
       {
           String strSQL =
           "declare @seqno int "
         + "declare @lpad_seqno varchar(8000) "
         + "exec get_sequenceno @seqno output "
         + "exec lpad @seqno,12,'0',@lpad_seqno output "
         + " insert into sal_saincobak(inco_code, inco_seqno, inco_orgid, inco_date, inco_icode, "
         + " inco_amt, inco_txra, inco_txam, inco_fee, inco_fees, "
         + " inco_leave_self, inco_leave_sup, inco_muser, inco_mdate, inco_ym, "
         + " inco_prikey, inco_kind_code_type ,inco_kind_code_no ,inco_kind_code ) "
         + " values( @v_kind , @v_seqno , @v_orgid , @v_inco_date , @v_icode,"
         + " @v_inco_amt , "+v_inco_txra +", @v_inco_txam , @v_inco_fee , @v_inco_fees ,"
         + " @v_inco_leave_self , @v_inco_leave_sup , @v_mid , @v_mdate , @v_inco_ym ,"
         + "  @key, @v_code_type, @v_code_no ,@v_code )";


           SqlParameter[] sp =
           {              
                new SqlParameter("@v_kind",v_kind),
                new SqlParameter("@v_seqno",v_seqno),
                new SqlParameter("@v_orgid",v_orgid),
                new SqlParameter("@v_inco_date",v_inco_date),
                new SqlParameter("@v_icode",v_icode),
                new SqlParameter("@v_inco_amt",v_inco_amt),
                new SqlParameter("@v_inco_txra",v_inco_txra),
                new SqlParameter("@v_inco_txam",v_inco_txam),
                new SqlParameter("@v_inco_fee",v_inco_fee),
                new SqlParameter("@v_inco_fees",v_inco_fees),
                new SqlParameter("@v_inco_leave_self",v_inco_leave_self),
                new SqlParameter("@v_inco_leave_sup",v_inco_leave_sup),
                new SqlParameter("@v_mid",v_mid),
                new SqlParameter("@v_mdate",v_mdate),
                new SqlParameter("@v_inco_ym",v_inco_ym),
                new SqlParameter("@key",key),
                new SqlParameter("@v_code_type",v_code_type),
                new SqlParameter("@v_code_no",v_code_no),
                new SqlParameter("@v_code",v_code)        
           };

           Execute(strSQL, sp);
       }


     public void insertinco(
           string v_orgid
         , string v_seqno
         , string v_icode
         , string v_inco_date
         , string v_inco_ym
         , string v_inco_no
         , string v_inco_amt
         , string v_inco_real_amt
         , string v_inco_txam
         , string v_inco_rent_no
         , string v_inco_vouchers
         , string v_inco_summons
         , string key
         , string budget_code
        )
     {
         String strSQL ="INSERT INTO SAL_SAINCO "+
                        " (inco_code,INCO_KIND_CODE_TYPE,INCO_KIND_CODE_NO,INCO_KIND_CODE "+
                        " ,inco_orgid,inco_seqno,inco_icode,inco_date "+
                        " ,inco_ym,INCO_NO,inco_amt,inco_real_amt "+
                        " ,inco_txam,INCO_RENT_NO,INCO_Vouchers,INCO_Summons "+
                        " ,inco_muser,inco_mdate,inco_prikey,INCO_Budget_code "+
                        " ) VALUES "+
                        " ('005' "+
                        " ,'000' "+
                        " ,'000' " +
                        " ,'000' "+
                        " ,@v_orgid "+
                        " ,@v_seqno "+
                        " ,@v_icode " +
                        " ,@v_inco_date "+
                        " ,@v_inco_ym "+
                        " ,@v_inco_no "+
                        " ,@v_inco_amt "+
                        " ,@v_inco_real_amt "+
                        " ,@v_inco_txam "+
                        " ,@v_inco_rent_no "+
                        " ,@v_inco_vouchers "+
                        " ,@v_inco_summons "+
                        " ,@muser " +
                        " ,@mdate "+
                        " ,@key "+
                        " ,@budget_code "+
                        " )  ";


     

         SqlParameter[] sp =
           {       
                new SqlParameter("@v_orgid",v_orgid),        
                new SqlParameter("@v_seqno",v_seqno),               
                new SqlParameter("@v_icode",v_icode),
                new SqlParameter("@v_inco_date",v_inco_date),
                new SqlParameter("@v_inco_ym",v_inco_ym),
                new SqlParameter("@v_inco_no",v_inco_no),
                new SqlParameter("@v_inco_amt",v_inco_amt),
                new SqlParameter("@v_inco_real_amt",v_inco_real_amt),
                new SqlParameter("@v_inco_txam",v_inco_txam),
                new SqlParameter("@v_inco_rent_no",v_inco_rent_no),
                new SqlParameter("@v_inco_vouchers",v_inco_vouchers),
                new SqlParameter("@v_inco_summons",v_inco_summons),
                new SqlParameter("@key",key),
                new SqlParameter("@budget_code",budget_code),
                new SqlParameter ("@muser",LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)),
                new SqlParameter ("@mdate",DateTime.Now.ToString("yyyyMMddHHmmss"))
           };

         Execute(strSQL, sp);
     }


     
     public DataTable getkindData(string v_orgid//登入者機關代碼
     )
     {
         String strSQL = "select inco_code from sal_saincobak where inco_orgid=@v_orgid";
          


         SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid)     
        };

         return Query(strSQL, sp);
     }

     //GridView1 data
     public DataTable gettableData(string v_orgid//登入者機關代碼
    )
     {
         String strSQL = 
              " select b.base_idno,b.base_name,isnull(c.item_name,'') as item_name,a.* "
            + " from sal_sabase b, sal_saincobak a left join sal_saitem c "
            + " on a.inco_orgid = c.item_orgid "
            + " and a.inco_kind_code_type = c.item_code_type "
            + " and a.inco_kind_code_no = c.item_code_no "
            + " and a.inco_kind_code = c.item_code "
            + " where a.inco_orgid = @v_orgid "
            + " and a.inco_orgid = b.base_orgid "
            + " and a.inco_seqno = b.base_seqno"
            + " order by inco_prikey";

         SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid)     
        };

         return Query(strSQL, sp);
     }
    
     //Columns[0]
     public DataTable exists_flag(string v_orgid
            , string inco_code
            , string inco_icode
            , string inco_seqno
            , string inco_date
            , string inco_kind_code_type
            , string inco_kind_code_no
            , string inco_kind_code        
        )
     {
         String strSQL =
                "select * from sal_sainco "
             + " where inco_orgid = @v_orgid "
             + " and inco_code = @inco_code "
             + " and inco_icode = @inco_icode "
             + " and inco_seqno = @inco_seqno "
             + " and inco_date = @inco_date";

         if (inco_code == "005")
         {
             strSQL += " and inco_kind_code_type = @inco_kind_code_type "
             + " and inco_kind_code_no = @inco_kind_code_no  "
             + " and inco_kind_code = @inco_kind_code ";
         }           

         SqlParameter[] sp =
        {
            new SqlParameter("@v_orgid",v_orgid) ,
            new SqlParameter("@inco_code",inco_code)    ,
            new SqlParameter("@inco_icode",inco_icode)  ,  
            new SqlParameter("@inco_seqno",inco_seqno)  ,  
            new SqlParameter("@inco_date",inco_date)    ,
            new SqlParameter("@inco_kind_code_type",inco_kind_code_type) ,   
            new SqlParameter("@inco_kind_code_no",inco_kind_code_no)    ,
            new SqlParameter("@inco_kind_code",inco_kind_code)   
        };

         return Query(strSQL, sp);
     }



     public void queryinsert3Data(string v_orgid, string v_chg_kind, string v_kind)
     {
         String strSQL =
           "insert into sal_sainco(inco_code,inco_seqno,inco_orgid,inco_date,inco_icode,inco_amt,"
         + " inco_txra,inco_txam,inco_fee,inco_fees,inco_leave_self,inco_leave_sup,"
         + " inco_muser,inco_mdate,inco_ym,inco_prikey,inco_kind_code_type,inco_kind_code_no,inco_kind_code,inco_real_amt)"
         + " select a.inco_code,a.inco_seqno,a.inco_orgid,a.inco_date,a.inco_icode,a.inco_amt,a.inco_txra,a.inco_txam,"
         + " a.inco_fee,a.inco_fees,a.inco_leave_self,a.inco_leave_sup,a.inco_muser,a.inco_mdate,a.inco_ym,a.inco_prikey,"
         + " a.inco_kind_code_type,a.inco_kind_code_no,a.inco_kind_code,a.inco_amt from sal_saincobak a"
         + " where a.inco_orgid = @v_orgid  "
         + " and not exists (select 1 from sal_sainco b where a.inco_orgid = b.inco_orgid and a.inco_seqno = b.inco_seqno";

         if (v_chg_kind == "Y")
         {
             strSQL += " and a.inco_code = b.inco_code and a.inco_icode = b.inco_icode and a.inco_ym = b.inco_ym and a.inco_date = b.inco_date";
         }
         else
         {
             strSQL += " and a.inco_code = b.inco_code and a.inco_icode = b.inco_icode and a.inco_date = b.inco_date";
         }

         if (v_kind == "005")
         {
             strSQL += " and a.inco_kind_code_type = b.inco_kind_code_type and a.inco_kind_code_no = b.inco_kind_code_no and a.inco_kind_code = b.inco_kind_code";
         }

         strSQL += ")";


         SqlParameter[] sp =
           {
                new SqlParameter("@v_orgid",v_orgid) 
           };

         Execute(strSQL, sp);
     }




}