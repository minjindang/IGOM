using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SAL3104DAO 的摘要描述
/// 各項補發代扣維護
/// Elio Chen
/// </summary>
public class SAL3104DAO : BaseDAO
{
	public SAL3104DAO()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public SAL3104DAO(SqlConnection conn)
        : base(conn)
    {

    }


    // 查詢相關項目名稱
    public DataTable querySalItemName(
        string strOrgID,               // 機關代碼
        string strisPaywithSalary,     // 是否隨薪
        string strPayMethod,           // 發放方式
        string strItemType             // 項目類別

        )
    {
        string strSQL =
            "select  item_name ," +      //--項目名稱代碼中下拉的中名文稱
            "item_code " +               //--項目名稱代碼中下拉的代碼
            "from sal_saitem " +
            "where item_orgid = @OrgID ";
        if (strisPaywithSalary != "")
        {
            strSQL +=
               "and item_type = @isPaywithSalary ";
        }
        strSQL+=
            "and item_code_sys = '005' " +
            "and item_code_type = @PayMethod " +
            "and item_code_no = @ItemType ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@isPaywithSalary", strisPaywithSalary),
            new SqlParameter("@PayMethod", strPayMethod),
            new SqlParameter("@ItemType", strItemType)
        };
        return Query(strSQL, sp);
    }

    // 查詢補發代扣資料
    public DataTable querySalPayItem(
        string strOrgID,               // 機關代碼
        string strisPaywithSalary,     // 是否隨薪
        string strPayMethod,           // 發放方式
        string strItemType,            // 項目類別
        string strItemNameCode,         // 項目名稱
        string strBatchNum,             // 批號
        string strEmployeeType  ,        // 員工類別
        string strBaseEDate,string departid,string idcard
        )
    {
        string strSQL =
            "select PAYITEM_CodeSys , PAYITEM_Merge_flow_id , PAYITEM_Budget_code, SUM(PAYITEM_Pay_amt)  as sum_PAYITEM_Pay_amt " +
            "from SAL_PAYITEM inner join SAL_SABASE s on PAYITEM_Org_Code = BASE_ORGID and PAYITEM_User_id = BASE_seqno left outer join sal_sabaseext e on s.base_idno=e.base_idno " +
            "left join SAL_SAITEM   " +
            "on ITEM_ORGID = PAYITEM_Org_Code " +
            "and ITEM_CODE_SYS = PAYITEM_CodeSys " +
            "and ITEM_CODE_kind = PAYITEM_codekind " +
            "and ITEM_CODE_type = PAYITEM_CodeType " +
            "and ITEM_CODE_NO = PAYITEM_CodeNo " +
            "and ITEM_CODE = PAYITEM_Code " +
            "where ITEM_ORGID = @OrgID " +              // 機關代碼
            "and ITEM_type = @isPaywithSalary " +       // 是否隨薪
            "and ITEM_CODE_TYPE = @PayMethod " +     // 發放方式
            "and ITEM_CODE_NO  = @ItemType " +          // 項目類別
            "and ITEM_CODE = @ItemNameCode ";           // 項目名稱
        if (strBatchNum!="")
        {
            strSQL+=
            "and PAYITEM_Merge_flow_id = @BatchNum ";   //--若有輸入批號才要加此條件
        }
        if (strEmployeeType != "")
        {
   /*         strSQL +=
                "and exists  " +//--此段為若有輸入員工類別才要加此條件選全部則不需此條件
                "( " +
                    "select 1 from SAL_SABASE  " +
                    "where BASE_ORGID = PAYITEM_Org_Code " +
                    "and BASE_SEQNO = PAYITEM_User_id " +
                    "and BASE_PRONO in (@EmployeeType) "+   // 員工類別
            ") ";  */

            strSQL += "and s.BASE_PRONO in (@EmployeeType) ";   // 員工類別
        }
        //ted add 0729
        int vv_base_status = 0;

        if (!String.IsNullOrEmpty(strBaseEDate.Trim())) vv_base_status = Convert.ToInt32(strBaseEDate);
        switch (vv_base_status)
        {
            case 0:
                break;
            //' 全部
            case 1:
                //' 在職
                strSQL += " and (s.base_edate='' or s.base_edate='99999999' or s.base_edate is null) and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 2:
                //' 已離職
                strSQL += " and s.base_edate <> '' and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 3:
                //' 已退休
                strSQL += " and e.base_retire='Y'";
                break;
        }
        //單位別
        if (departid != "ALL" && departid != "")
        {
            strSQL += " and ( s.base_DEP like @departid + '%' ) ";
        }
        //idcard
        if (idcard != "ALL" && idcard != "")
        {
            strSQL += " and ( s.base_seqno = @idcard ) ";
        } 

        strSQL+=
            "group by PAYITEM_Budget_code,PAYITEM_Merge_flow_id,PAYITEM_CodeSys   ";
        SqlParameter[] sp={
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@isPaywithSalary", strisPaywithSalary),
            new SqlParameter("@PayMethod", strPayMethod),
            new SqlParameter("@ItemType", strItemType),
            new SqlParameter("@ItemNameCode", strItemNameCode),
             new SqlParameter("@departid", departid),
              new SqlParameter("@idcard", idcard)
        };
        if (strBatchNum!="")
        {
            Array.Resize(ref sp, sp.Length + 1);
            sp[sp.Length-1] = new SqlParameter("@BatchNum", strBatchNum);
        }
        if (strEmployeeType != "")
        {
            Array.Resize(ref sp, sp.Length + 1);
            sp[sp.Length - 1] = new SqlParameter("@EmployeeType", strEmployeeType);
        }

        return Query(strSQL, sp);
    }

    // 明細資料
    public DataTable querySalPayItemDetail(
        string strOrgID,               // 機關代碼
        string strBatchNum             // 批號
        ,string strBaseEDate,string departid,string idcard
        )
    {
        string strSQL =
            "select * " +
            "from sal_payitem " +
            "left outer join sal_sabase s" +
            " on s.BASE_ORGID = PAYITEM_Org_Code " +
            "and s.BASE_SEQNO = PAYITEM_User_id left outer join sal_sabaseext e on s.base_idno=e.base_idno " +
            "where PAYITEM_Org_Code = @OrgID " + //'使用者機關'
            "and PAYITEM_Merge_flow_id = @BatchNum "; // 點選資料之批號
         
            //ted add 0729
        int vv_base_status = 0;

        if (!String.IsNullOrEmpty(strBaseEDate.Trim())) vv_base_status = Convert.ToInt32(strBaseEDate);
        switch (vv_base_status)
        {
            case 0:
                break;
            //' 全部
            case 1:
                //' 在職
                strSQL += " and (s.base_edate='' or s.base_edate='99999999' or s.base_edate is null) and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 2:
                //' 已離職
                strSQL += " and s.base_edate <> '' and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 3:
                //' 已退休
                strSQL += " and e.base_retire='Y'";
                break;
        }
        //單位別
        if (departid != "ALL" && departid != "")
        {
            strSQL += " and ( s.base_DEP like @departid + '%' ) ";
        }
        //idcard
        if (idcard != "ALL" && idcard != "")
        {
            strSQL += " and ( s.base_seqno = @idcard ) ";
        } 

       strSQL+=  " order by isnull(BASE_PRONO,'999') , isnull(BASE_PRTS ,999) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@BatchNum", strBatchNum),
              new SqlParameter("@departid", departid),
                new SqlParameter("@idcard", idcard)
        };
        return Query(strSQL, sp);

    }

    // 『新增查詢』之資料查詢部分
    public DataTable querySalItemDetail4Edit
        (
            string strPayMethod,           // 發放方式
            string strItemType,            // 項目類別
            string strItemNameCode,         // 項目名稱
            string strOrgID,               // 機關代碼
            string strEmployeeType          // 員工類別
        ,string strBaseEDate,string departid,string idcard
        )
    {
        string strSQL =
            "  select s.base_orgid " +   //-- 存入SAL_PAYITEM.PAYITEM_Org_Code
            ", base_seqno " +        //-- 存入SAL_PAYITEM.PAYITEM_User_id
            ", base_name " +         //-- 清單呈現之員工姓名
            ", '005' as code_sys " + //-- 存入SAL_PAYITEM.PAYITEM_CODESys
            ", 'D' as code_kind " +  //-- 存入SAL_PAYITEM.PAYITEM_CODEKind
            ", @PayMethod as code_type " +          // '查詢畫面之C.發放方式' -- 存入SAL_PAYITEM.PAYITEM_CODEType
            ", @ItemType as code_no " +             //'查詢畫面之D.項目類別'-- 存入SAL_PAYITEM.PAYITEM_CODENo
            ", @ItemNameCode as code " +             //-- '查詢畫面之F.項目名稱' 存入SAL_PAYITEM.PAYITEM_CODE
            // 2014/7/19 Eliot Chen
            // 增加相關JOIN與欄位
            ", DEPART_NAME as DeptName " +
            ",(SELECT CODE_DESC1 FROM SYS_CODE WHERE CODE_SYS='005' AND CODE_KIND='D' "+
            "AND CODE_TYPE=@PayMethod AND CODE_NO=@ItemType) as ItemName " +
            "from SAL_SABASE s left outer join sal_sabaseext e on s.base_idno=e.base_idno left join FSC_ORG on s.BASE_DEP=FSC_ORG.DEPART_ID" +
            " where s.BASE_ORGID =  @OrgID ";  // '登入者機關代碼'
        if (strEmployeeType!="" && strEmployeeType!="ALL")
        {
            strSQL +=
            "and s.BASE_PRONO in (@EmployeeType)";  // '(查詢畫面之A.員工類別)'
        }
        //ted add 0729
        int vv_base_status = 0;

        if (!String.IsNullOrEmpty(strBaseEDate.Trim())) vv_base_status = Convert.ToInt32(strBaseEDate);
        switch (vv_base_status)
        {
            case 0:
                break;
            //' 全部
            case 1:
                //' 在職
                strSQL += " and (s.base_edate='' or s.base_edate='99999999' or s.base_edate is null) and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 2:
                //' 已離職
                strSQL += " and s.base_edate <> '' and (e.base_retire='N' or isnull(e.base_retire,'')='')";
                break;
            case 3:
                //' 已退休
                strSQL += " and e.base_retire='Y'";
                break;
        }
        //單位別
        if (departid != "ALL" && departid != "")
        {
            strSQL += " and ( s.base_DEP like @departid + '%' ) ";
        }
        //idcard
        if (idcard != "ALL" && idcard != "")
        {
            strSQL += " and ( s.base_seqno = @idcard ) ";
        } 

     //   strSQL +=
     //       "and s.BASE_DEP*=FSC_ORG.DEPART_ID ";

        strSQL+=
            " order by isnull(s.BASE_PRONO,'999') , isnull(s.BASE_PRTS ,999) ";

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@PayMethod", strPayMethod),
            new SqlParameter("@ItemType", strItemType),
            new SqlParameter("@ItemNameCode", strItemNameCode),
            new SqlParameter("@EmployeeType", strEmployeeType),
              new SqlParameter("@departid", departid),
                new SqlParameter("@idcard", idcard)
        };
        return Query(strSQL, sp);

    }

    // 取科室名稱
    public DataTable queryFCSORG(
            string strOrgID,               // 機關代碼
//            string strDepartID              // 科室代碼類別
        string strUserSeqNO
    )
    {
        string strSQL =
            "SELECT * FROM SAL_SABASE,FSC_ORG " +
            "WHERE SAL_SABASE.BASE_DEP=FSC_ORG.DEPART_ID " +
            "AND SAL_SABASE.BASE_SEQNO=@UserSeqNO ";
        /*
        string strSQL =
            "SELECT DEPART_NAME FROM FSC_ORG " +
            "WHERE ORGCODE=@OrgID "+
            "AND DEPART_ID=@DepartID ";
         */
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@UserSeqNO", strUserSeqNO),
        };
        return Query(strSQL, sp);
            

    }


    // 取使用者名稱
    public DataTable queryUserName(
            string strOrgID,               // 機關代碼
            string strBaseSeqNO              // 使用者 SEQNO
        )
    {
        string strSQL=
            "SELECT BASE_NAME FROM SAL_SABASE "+
            "WHERE BASE_ORGID=@OrdID " +
            "AND BASE_SEQNO=@BaseSeqNO ";
        SqlParameter[] sp =
        {
            new SqlParameter("@OrdID",strOrgID),
            new SqlParameter("@BaseSeqNO", strBaseSeqNO)
        };
        return Query(strSQL, sp);

    }

    // 更新 SAL_PAYITEM 資料
    public void updateSAL_PAYITEMAMT(
            string strPayitemOrgCode,   // '上述SQL查詢之base_orgid內容'
            string strPayitemUserID,    // '上述SQL查詢之base_seqno內容'
            string strPayitemFlowID,     // 系統取號
            string strPayitemMargeFlowID,           // 系統取號
            string strPayitemCodeSys,   // 上述SQL查詢之code_sys內容
            string strPayitemCodeKind,    // 上述SQL查詢之code_kind內容
            string strPayitemCodType,   // 上述SQL查詢之code_type內容
            string strPayitemCodeNo,  // 上述SQL查詢之code_no內容
            string strPayitemCode, // 上述SQL查詢之code內容
            string strPayitemBudgeCode,    // 清單選擇之預算來源代碼
            string strPayitemPayAmt,        // 清單輸入之金額
            string strPayitemModUserID// 登入者 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
    )
    {
        // 資料是否存在?
        string strSQL =
            "SELECT COUNT(*) CNT FROM SAL_PAYITEM " +
            "WHERE PAYITEM_Org_Code=@PAYITEM_Org_Code " +
            "AND PAYITEM_User_id=@User_id " +
            "AND PAYITEM_Flow_id=@Flow_id " +
            "AND PAYITEM_Merge_Flow_id=@PAYITEM_Merge_Flow_id ";
        SqlParameter[] sp =
        {
            new SqlParameter("@PAYITEM_Org_Code",strPayitemOrgCode),
            new SqlParameter("@User_id", strPayitemUserID),
            new SqlParameter("@Flow_id", strPayitemFlowID),
            new SqlParameter("@PAYITEM_Merge_Flow_id", strPayitemMargeFlowID)
        };
        DataTable dt = Query(strSQL, sp);
        if (dt.Rows.Count > 0)
        {
            // 修改
            strSQL=
                "UPDATE SAL_PAYITEM "+
                "SET PAYITEM_Pay_amt=@Pay_amt " +
                "WHERE PAYITEM_Org_Code=@PAYITEM_Org_Code " +
                "AND PAYITEM_User_id=@User_id " +
                "AND PAYITEM_Flow_id=@Flow_id " +
                "AND PAYITEM_Merge_Flow_id=@PAYITEM_Merge_Flow_id ";
            SqlParameter[]  sp2 =
            {
                new SqlParameter("@PAYITEM_Org_Code",strPayitemOrgCode),
                new SqlParameter("@User_id", strPayitemUserID),
                new SqlParameter("@Flow_id", strPayitemFlowID),
                new SqlParameter("@Pay_amt", strPayitemPayAmt),
                new SqlParameter("@PAYITEM_Merge_Flow_id", strPayitemMargeFlowID)
            };
            Execute(strSQL, sp2);        
        }
        else
        {
            // 新增
            insertSAL_PAYITEM(strPayitemOrgCode, strPayitemUserID, strPayitemFlowID, strPayitemMargeFlowID
                , strPayitemCodeSys, strPayitemCodeKind, strPayitemCodType, strPayitemCodeNo, strPayitemCode
                , strPayitemBudgeCode, strPayitemPayAmt, strPayitemModUserID);
        }



    }




    public void insertSAL_PAYITEM(
            string strPayitemOrgCode,   // '上述SQL查詢之base_orgid內容'
            string strPayitemUserID,    // '上述SQL查詢之base_seqno內容'
            string strPayitemFlowID,     // 系統取號
            string strPayitemMargeFlowID,           // 系統取號
            string strPayitemCodeSys,   // 上述SQL查詢之code_sys內容
            string strPayitemCodeKind,    // 上述SQL查詢之code_kind內容
            string strPayitemCodType,   // 上述SQL查詢之code_type內容
            string strPayitemCodeNo,  // 上述SQL查詢之code_no內容
            string strPayitemCode, // 上述SQL查詢之code內容
            string strPayitemBudgeCode,    // 清單選擇之預算來源代碼
            string strPayitemPayAmt,        // 清單輸入之金額
            string strPayitemModUserID// 登入者 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
       )

    {
        string strSQL=
            "insert into SAL_PAYITEM "+
            "(PAYITEM_Org_Code "+
            ",PAYITEM_User_id "+
            ",PAYITEM_Flow_id "+
            ",PAYITEM_Merge_flow_id "+
            ",PAYITEM_CodeSys "+
            ",PAYITEM_CodeKind "+
            ",PAYITEM_CodeType "+
            ",PAYITEM_CodeNo "+
            ",PAYITEM_Code "+
            ",PAYITEM_Budget_code "+
            ",PAYITEM_Pay_amt "+
            ",PAYITEM_ModUser_id "+
            ",PAYITEM_Mod_date "+
            ") "+
            "values "+
            "(@PayitemOrgCode " +   // '上述SQL查詢之base_orgid內容'
            ",@PayitemUserID " +    // '上述SQL查詢之base_seqno內容'
            ",@PayitemFlowID "+     // 系統取號
            ",@PayitemMargeFlowID " +           // 系統取號
            ",@PayitemCodeSys " +   // 上述SQL查詢之code_sys內容
            ",@PayitemCodeKind " +    // 上述SQL查詢之code_kind內容
            ",@PayitemCodType " +    // 上述SQL查詢之code_type內容
            ",@PayitemCodeNo " +  // 上述SQL查詢之code_no內容
            ",@PayitemCode " + // 上述SQL查詢之code內容
            ",@PayitemBudgeCode " +    // 清單選擇之預算來源代碼
            ",@PayitemPayAmt " +        // 清單輸入之金額
            ",@PayitemModUserID " + // 登入者 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
            ",getDate()) "; // 系統時間
//            ",'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' "; // 系統時間
        SqlParameter[] sp =
        {
            new SqlParameter("@PayitemOrgCode",strPayitemOrgCode),
            new SqlParameter("@PayitemUserID", strPayitemUserID),
            new SqlParameter("@PayitemFlowID", strPayitemFlowID),
            new SqlParameter("@PayitemMargeFlowID", strPayitemMargeFlowID),
            new SqlParameter("@PayitemCodeSys", strPayitemCodeSys),
            new SqlParameter("@PayitemCodeKind", strPayitemCodeKind),
            new SqlParameter("@PayitemCodType", strPayitemCodType),
            new SqlParameter("@PayitemCodeNo", strPayitemCodeNo),
            new SqlParameter("@PayitemCode", strPayitemCode),
            new SqlParameter("@PayitemBudgeCode", strPayitemBudgeCode),
            new SqlParameter("@PayitemPayAmt", strPayitemPayAmt),
            new SqlParameter("@PayitemModUserID", strPayitemModUserID)
        };

        Execute(strSQL, sp);


    }

}