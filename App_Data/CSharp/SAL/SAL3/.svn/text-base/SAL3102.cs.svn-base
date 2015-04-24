using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3102 的摘要描述
/// </summary>
public class SAL3102
{
    private SAL3102DAO DAO;
    public SAL3102()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        DAO = new SAL3102DAO();
    }

    public SAL3102(SqlConnection conn)
    {
        DAO = new SAL3102DAO(conn);
    }

    // 查詢非員工資料
    public DataTable querySalSaBaseNon(
    string strBaseOrgID,
    string strShowMark,
    string strBaseType,
    string strBaseProNo,
    string strSearchStr,
    string strOrderBy
    )
    {
        DataTable dt = DAO.querySalSaBaseNon(
         strBaseOrgID,
         strShowMark,
         strBaseType,
         strBaseProNo,
         strSearchStr,
         strOrderBy
        );
        return dt;
    }

        // 更新非員工資料
    public int updateSalSaBaseNon(
        string BASE_IDNO,
        string BASE_STATUS,
        string BASE_TYPE,
        string BASE_ORGID,
        string BASE_NAME,
        string BASE_SEX,
        string BASE_BDATE,
        string BASE_EDATE,
        string BASE_ADDR,
        string BASE_ERMK,
//        string BASE_PRONO,
        string BASE_FINS_KIND,
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
        return DAO.updateSalSaBaseNon(
         BASE_IDNO,
         BASE_STATUS,
         BASE_TYPE,
         BASE_ORGID,
         BASE_NAME,
         BASE_SEX,
         BASE_BDATE,
         BASE_EDATE,
         BASE_ADDR,
         BASE_ERMK,
//         BASE_PRONO,
         BASE_FINS_KIND,
         BASE_MEMO,
         BASE_MUSER,
         BASE_EMAIL,
         Base_IsMarked,
         BASE_PROF,
         BASE_DCODE_NAME,
         BASE_SEQNO,
         BASE_PARTTIME
        );
    }


    public int updateSalSaBaseExtBirthday(
        string BASE_ORGID,
        string BASE_IDNO,
        string BASE_BirthDay)
    {
        if (!DAO.existSalSaBaseExt(BASE_ORGID, BASE_IDNO))
        {
            DAO.insertSAL_SABASEEXT(BASE_ORGID, BASE_IDNO);
        }
        return DAO.updateSalSaBaseExtBirthday(BASE_ORGID, BASE_IDNO, BASE_BirthDay);
    }

    // 更新單一人員是否顯示住記
    public int updateSalSaBaseMark(
        string BASE_ORGID,
        string BASE_SEQNO,
        string Base_IsMarked
        )
    {
        return DAO.updateSalSaBaseMark(
            BASE_ORGID,
            BASE_SEQNO,
            Base_IsMarked
        );
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
        DAO.updateSalSaBank(
         strBankOrgID,
         strBankSeqNo,
         strBankNo,
         strBankBankNO,
         strBankUser,
         strBankMUser);
    }

}