using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// SAL3102DAO 的摘要描述
/// </summary>
public class SAL3102DAO : BaseDAO
{
	public SAL3102DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL3102DAO(SqlConnection conn)
        : base(conn)
    {

    }

    public DataTable querySalSaBaseNon(
        string strBaseOrgID,
        string strShowMark,
        string strBaseType,
        string strBaseProNo,
        string strSearchStr,
        string strOrderBy
        )
    {
        string strSQL =
            "select base_isMarked, base_seqno, base_idno, base_name, base_type, "+
            " base_mdate, base_prono, base_orgid from sal_sabase " +
            "where ( base_orgid= @BaseOrgID and base_status = 'N' ) ";
        if (strShowMark != "Y")
        {
            strSQL += " and ( base_isMarked = 'N' ) ";
        }
        // 身份別 
        if (strBaseType != "ALL" && strBaseType != "")
        {
            if (strBaseType != "NUL")
            {
                strSQL += " and ( base_type=@BaseType ) ";
            }
            else
            {
                strSQL += " and ( base_type='' or base_type is null or base_type not in ('1','2','3') ) ";
            }
        }
        // 工作計畫 
        if (strBaseProNo != "ALL")
        {
            strSQL += " and ( base_prono =  @BaseProNo ) ";
        }
        if (!string.IsNullOrEmpty(strSearchStr))
        {
            strSQL += " and (base_idno like '%' + @SearchStr + '%' OR base_name like '%' + @SearchStr + '%')";
        }
        if (string.IsNullOrEmpty(strOrderBy))
        {
            strSQL += " order by isNull(base_prts,99999)";
        }
        else
        {
            strSQL += " order by ltrim(" + strOrderBy + ") ";
        }

        SqlParameter[] sp =
            {
            new SqlParameter("@BaseOrgID",strBaseOrgID),
            new SqlParameter("@BaseType", strBaseType),
            new SqlParameter("@SearchStr", strSearchStr),
            new SqlParameter("@BaseProNo", strBaseProNo)
            };
        return Query(strSQL, sp);

    }

    // 更新非員工資料
    public int updateSalSaBaseNon(
        string BASE_IDNO,
        string BASE_STATUS,
        string BASE_TYPE,
        string BASE_ORGID,
        string BASE_NAME,
        string BASE_SEX,
        //string BASE_BDATE,
        //string BASE_EDATE,
        string BASE_ADDR,
        string BASE_ERMK,
        string BASE_PRONO,
        //string BASE_FINS_KIND,
        string BASE_MEMO,
        string BASE_MUSER,
        string BASE_EMAIL,
        string Base_IsMarked,
        string BASE_PROF,
        string BASE_DCODE_NAME,
        string BASE_SEQNO
        , string BASE_PARTTIME
        )
    {
        string BASE_MDATE = DateTime.Now.ToString("yyyyMMddhhmmss");
        string strSQL=
            "UPDATE SAL_SABASE " +
            "SET BASE_IDNO = @BASE_IDNO " + // <BASE_IDNO, varchar(10),>
            ",BASE_STATUS = @BASE_STATUS " + // <BASE_STATUS, varchar(3),>
            ",BASE_TYPE = @BASE_TYPE " + // <BASE_TYPE, varchar(1),>
            ",BASE_ORGID = @BASE_ORGID " + // <BASE_ORGID, varchar(10),>
            ",BASE_NAME = @BASE_NAME " + // <BASE_NAME, varchar(50),>
            ",BASE_SEX = @BASE_SEX " + // <BASE_SEX, varchar(1),>
            //",BASE_BDATE = @BASE_BDATE " + // <BASE_BDATE, varchar(8),>
            //",BASE_EDATE = @BASE_EDATE " + // <BASE_EDATE, varchar(8),>
            ",BASE_ADDR = @BASE_ADDR " + // <BASE_ADDR, varchar(60),>
            ",BASE_ERMK = @BASE_ERMK " +//<BASE_ERMK, varchar(1),>
            ",BASE_PRONO = @BASE_PRONO " +//<BASE_PRONO, varchar(3),>
            //",BASE_FINS_KIND = @BASE_FINS_KIND " +//<BASE_FINS_KIND, varchar(3),>
            ",BASE_MEMO = @BASE_MEMO " +//<BASE_MEMO, varchar(1000),>
            ",BASE_MUSER = @BASE_MUSER " +//<BASE_MUSER, varchar(10),>
            ",BASE_MDATE = @BASE_MDATE " +//<BASE_MDATE, varchar(16),>
            ",BASE_EMAIL = @BASE_EMAIL " +//<BASE_EMAIL, varchar(100),>
            ",Base_IsMarked = @Base_IsMarked " +//<Base_IsMarked, varchar(1),>
            ",BASE_PROF = @BASE_PROF " +//<BASE_PROF, varchar(2),>
            ",BASE_DCODE_NAME = @BASE_DCODE_NAME " +//<BASE_DCODE_NAME, varchar(50),>
            ",BASE_PARTTIME = @BASE_PARTTIME " +//<BASE_PARTTIME, varchar(3),>
            " WHERE BASE_SEQNO=@BASE_SEQNO ";

        SqlParameter[] sp =
            {
                new SqlParameter("@BASE_IDNO",BASE_IDNO),
                new SqlParameter("@BASE_STATUS",BASE_STATUS),
                new SqlParameter("@BASE_TYPE",BASE_TYPE),
                new SqlParameter("@BASE_ORGID",BASE_ORGID),
                new SqlParameter("@BASE_NAME",BASE_NAME),
                new SqlParameter("@BASE_SEX",BASE_SEX),
                //new SqlParameter("@BASE_BDATE",BASE_BDATE),
                //new SqlParameter("@BASE_EDATE",BASE_EDATE),
                new SqlParameter("@BASE_ADDR",BASE_ADDR),
                new SqlParameter("@BASE_ERMK",BASE_ERMK),
                new SqlParameter("@BASE_PRONO",BASE_PRONO),
                //new SqlParameter("@BASE_FINS_KIND",BASE_FINS_KIND),
                new SqlParameter("@BASE_MEMO",BASE_MEMO),
                new SqlParameter("@BASE_MUSER",BASE_MUSER),
                new SqlParameter("@BASE_MDATE",BASE_MDATE),
                new SqlParameter("@BASE_EMAIL",BASE_EMAIL),
                new SqlParameter("@Base_IsMarked",Base_IsMarked),
                new SqlParameter("@BASE_PROF",BASE_PROF),
                new SqlParameter("@BASE_DCODE_NAME",BASE_DCODE_NAME),
               new SqlParameter("@BASE_PARTTIME",BASE_PARTTIME),
               new SqlParameter("@BASE_SEQNO",BASE_SEQNO)

            };

        return Execute(strSQL, sp);

    }

    // 新增非員工資料
    public int insertSalSaBaseNon(
        string BASE_IDNO,
        string BASE_STATUS,
        string BASE_TYPE,
        string BASE_ORGID,
        string BASE_NAME,
        string BASE_SEX,
        //string BASE_BDATE,
        //string BASE_EDATE,
        string BASE_ADDR,
        string BASE_ERMK,
        string BASE_PRONO,
        //string BASE_FINS_KIND,
        string BASE_MEMO,
        string BASE_MUSER,
        string BASE_EMAIL,
        string Base_IsMarked,
        string BASE_PROF,
        string BASE_DCODE_NAME,
        string BASE_SEQNO,
        string BASE_PARTTIME
        )
    {
        string BASE_MDATE = DateTime.Now.ToString("yyyyMMddhhmmss");
        string strSQL =
            "INSERT INTO SAL_SABASE ( " +
            " BASE_SEQNO " +
            ",BASE_IDNO " + // <BASE_IDNO, varchar(10),>
            ",BASE_STATUS " + // <BASE_STATUS, varchar(3),>
            ",BASE_TYPE " + // <BASE_TYPE, varchar(1),>
            ",BASE_ORGID " + // <BASE_ORGID, varchar(10),>
            ",BASE_NAME " + // <BASE_NAME, varchar(50),>
            ",BASE_SEX " + // <BASE_SEX, varchar(1),>
            //",BASE_BDATE " + // <BASE_BDATE, varchar(8),>
            //",BASE_EDATE " + // <BASE_EDATE, varchar(8),>
            ",BASE_ADDR " + // <BASE_ADDR, varchar(60),>
            ",BASE_ERMK " +//<BASE_ERMK, varchar(1),>
            ",BASE_PRONO " +//<BASE_PRONO, varchar(3),>
            //",BASE_FINS_KIND " +//<BASE_FINS_KIND, varchar(3),>
            ",BASE_MEMO " +//<BASE_MEMO, varchar(1000),>
            ",BASE_MUSER " +//<BASE_MUSER, varchar(10),>
            ",BASE_MDATE " +//<BASE_MDATE, varchar(16),>
            ",BASE_EMAIL " +//<BASE_EMAIL, varchar(100),>
            ",Base_IsMarked " +//<Base_IsMarked, varchar(1),>
            ",BASE_PROF " +//<BASE_PROF, varchar(2),>
            ",BASE_DCODE_NAME " +//<BASE_DCODE_NAME, varchar(50),>
            ",BASE_PARTTIME " +//<BASE_PARTTIME, varchar(3),>
            " ) select "+
            " '#' + RIGHT( '000000' + cast(isnull(max(substring(base_seqno,2,5)) ,0) + 1 as varchar),5) " +
            ",@BASE_IDNO " + // <BASE_IDNO, varchar(20),>
            ",@BASE_STATUS " + // <BASE_STATUS, varchar(3),>
            ",@BASE_TYPE " + // <BASE_TYPE, varchar(1),>
            ",@BASE_ORGID " + // <BASE_ORGID, varchar(10),>
            ",@BASE_NAME " + // <BASE_NAME, varchar(50),>
            ",@BASE_SEX " + // <BASE_SEX, varchar(1),>
            //",@BASE_BDATE " + // <BASE_BDATE, varchar(8),>
            //",@BASE_EDATE " + // <BASE_EDATE, varchar(8),>
            ",@BASE_ADDR " + // <BASE_ADDR, varchar(60),>
            ",@BASE_ERMK " +//<BASE_ERMK, varchar(1),>
            ",@BASE_PRONO " +//<BASE_PRONO, varchar(3),>
            //",@BASE_FINS_KIND " +//<BASE_FINS_KIND, varchar(3),>
            ",@BASE_MEMO " +//<BASE_MEMO, varchar(1000),>
            ",@BASE_MUSER " +//<BASE_MUSER, varchar(10),>
            ",@BASE_MDATE " +//<BASE_MDATE, varchar(16),>
            ",@BASE_EMAIL " +//<BASE_EMAIL, varchar(100),>
            ",@Base_IsMarked " +//<Base_IsMarked, varchar(1),>
            ",@BASE_PROF " +//<BASE_PROF, varchar(2),>
            ",@BASE_DCODE_NAME " +//<BASE_DCODE_NAME, varchar(50),>
            ",@BASE_PARTTIME from SAL_SABASE";//<BASE_PARTTIME, varchar(3),>
            
            

        SqlParameter[] sp =
            {
                new SqlParameter("@BASE_IDNO",BASE_IDNO),
                new SqlParameter("@BASE_STATUS",BASE_STATUS),
                new SqlParameter("@BASE_TYPE",BASE_TYPE),
                new SqlParameter("@BASE_ORGID",BASE_ORGID),
                new SqlParameter("@BASE_NAME",BASE_NAME),
                new SqlParameter("@BASE_SEX",BASE_SEX),
                //new SqlParameter("@BASE_BDATE",BASE_BDATE),
                //new SqlParameter("@BASE_EDATE",BASE_EDATE),
                new SqlParameter("@BASE_ADDR",BASE_ADDR),
                new SqlParameter("@BASE_ERMK",BASE_ERMK),
                new SqlParameter("@BASE_PRONO",BASE_PRONO),
                //new SqlParameter("@BASE_FINS_KIND",BASE_FINS_KIND),
                new SqlParameter("@BASE_MEMO",BASE_MEMO),
                new SqlParameter("@BASE_MUSER",BASE_MUSER),
                new SqlParameter("@BASE_MDATE",BASE_MDATE),
                new SqlParameter("@BASE_EMAIL",BASE_EMAIL),
                new SqlParameter("@Base_IsMarked",Base_IsMarked),
                new SqlParameter("@BASE_PROF",BASE_PROF),
                new SqlParameter("@BASE_DCODE_NAME",BASE_DCODE_NAME),
                new SqlParameter("@BASE_PARTTIME",BASE_PARTTIME),

            };

        return Execute(strSQL, sp);

    }

    // 檢查IDNO是否存在 SAL_SABASE
    public bool existSalSaBase(
        string BASE_ORGID,
        string BASE_IDNO)
    {
        string strSQL =
            "SELECT COUNT(1) CNT " +
            "FROM SAL_SABASE " +
            "WHERE BASE_ORGID=@BASE_ORGID " +
            "AND BASE_IDNO=@BASE_IDNO ";
        SqlParameter[] sp =
            {
            new SqlParameter("@BASE_ORGID",BASE_ORGID),
            new SqlParameter("@BASE_IDNO", BASE_IDNO)
            };
        DataTable dt = Query(strSQL, sp);

        if (dt.Rows[0]["CNT"].ToString() == "0")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // 檢查IDNO是否存在 SAL_SABASEEXT
    public bool existSalSaBaseExt(
        string BASE_ORGID,
        string BASE_IDNO)
    {
        string strSQL =
            "SELECT COUNT(*) CNT " +
            "FROM SAL_SABASEEXT " +
            "WHERE BASE_ORGID=@BASE_ORGID " +
            "AND BASE_IDNO=@BASE_IDNO ";
        SqlParameter[] sp =
            {
            new SqlParameter("@BASE_ORGID",BASE_ORGID),
            new SqlParameter("@BASE_IDNO", BASE_IDNO)
            };
        DataTable dt= Query(strSQL, sp);

        if (dt.Rows[0]["CNT"].ToString() == "0")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // 新增資料SAL_SABASEEXT僅家 IDNO
    public int insertSAL_SABASEEXT(
        string BASE_ORGID,
        string BASE_IDNO)
    {
        string strSQL =
            "INSERT INTO SAL_SABASEEXT " +
            "(BASE_ORGID,BASE_IDNO) " +
            "VALUES " +
            "(@BASE_ORGID,@BASE_IDNO) ";
        SqlParameter[] sp =
            {
            new SqlParameter("@BASE_ORGID",BASE_ORGID),
            new SqlParameter("@BASE_IDNO", BASE_IDNO)
            };
        return Execute(strSQL, sp);
         
    }

    // 更新生日
    public int updateSalSaBaseExtBirthday(
        string BASE_ORGID,
        string BASE_IDNO,
        string BASE_BirthDay)
    {
        string strSQL =
            "UPDATE SAL_SABASEEXT " +
            "SET BASE_BirthDay=@BASE_BirthDay " +
            "WHERE BASE_ORGID=@BASE_ORGID " +
            "AND BASE_IDNO=@BASE_IDNO ";

        SqlParameter[] sp =
            {
            new SqlParameter("@BASE_BirthDay",BASE_BirthDay),
            new SqlParameter("@BASE_ORGID",BASE_ORGID),
            new SqlParameter("@BASE_IDNO", BASE_IDNO)
            };
        return Execute(strSQL, sp);
    }

    // 更新單一人員是否顯示住記
    public int updateSalSaBaseMark(
        string BASE_ORGID,
        string BASE_SEQNO,
        string Base_IsMarked
        )
    {
        string BASE_MDATE = DateTime.Now.ToString("yyyyMMddhhmmss");
        string strSQL =
            "UPDATE SAL_SABASE " +
            "SET Base_IsMarked=@Base_IsMarked " +
            ",BASE_MDATE=@BASE_MDATE "+
            "WHERE BASE_ORGID=@BASE_ORGID " +
            "AND BASE_SEQNO=@BASE_SEQNO ";

        SqlParameter[] sp =
            {
            new SqlParameter("@Base_IsMarked",Base_IsMarked),
            new SqlParameter("@BASE_ORGID",BASE_ORGID),
            new SqlParameter("@BASE_MDATE",BASE_MDATE),
            new SqlParameter("@BASE_SEQNO", BASE_SEQNO)
            };
        return Execute(strSQL, sp);
    }


    // 更該銀行帳號
    public void updateSalSaBank(
        string strBankOrgID,
        string strBankSeqNo,
        string strBankNo,
        string strBankBankNO,
        string strBankUser,
        string strBankMUser
        )
    {
        // 先刪除有沒資料

        string strSQL =
            "delete sal_sabank " +
            " where bank_orgid = @BankOrgID " +
            " and bank_seqno= @BankSeqNO ";
        SqlParameter[] sp =
            {
            new SqlParameter("@BankOrgID",strBankOrgID),
            new SqlParameter("@BankSeqNO",strBankSeqNo)
            };
        Execute(strSQL, sp);

        if ((!string.IsNullOrEmpty(strBankBankNO)))
        {
            string InsSQL = "insert into sabank (bank_seqno, bank_orgid, bank_sal_item, bank_code,";
            InsSQL += " bank_bank_no, bank_muser, bank_mdate, bank_tdpf_seqno)";
            InsSQL += " values (@BankSeqNO, @BankOrgID ,'',@BankCode,";
            InsSQL += " @BankBankNO , @BankMUser, @BankMDate, @BankTdpfSeqNo) ";

            string strBank1 = strBankNo;
            if (strBank1.Length >= 3) strBank1 = strBank1.Substring(0, 3);
            string strBank2 = strBankNo;
            if (strBank2.Length > 3) strBank2 = strBank2.Substring(3, strBank2.Length - 3);

            SqlParameter[]  sp2 =
            {
            new SqlParameter("@BankOrgID",strBankOrgID),
            new SqlParameter("@BankSeqNO",strBankSeqNo),
            new SqlParameter("@BankCode",strBank1),
            new SqlParameter("@BankBankNO",strBankBankNO),
            new SqlParameter("@BankMUser",strBankMUser),
            new SqlParameter("@BankMDate",DateTime.Now.ToString("yyyyMMddHHmmss")),
            new SqlParameter("@BankTdpfSeqNo",strBank2)
            };
           Execute(InsSQL,sp2);
        }

        
    }
 
}