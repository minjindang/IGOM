using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add 
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 與上月薪資發放比較
/// 實際資料庫存取
/// Eliot Chen
/// </summary>
public class SAL3111DAO : BaseDAO
{
    public SAL3111DAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public SAL3111DAO(SqlConnection conn)
        : base(conn)
    {

    }

    // 查詢其他薪津項目
    public DataTable querySalSaitem(
        string strOrgID // 機關代碼
        )
    {
        string strSQL =
            "select item_name , " +  //--項目名稱代碼中下拉的中名文稱
            "item_code " +        //--項目名稱代碼中下拉的代碼
            //"ITEM_CODE " +
            "from sal_saitem " +     //-- (改為 from sal_saitem)
            "where item_orgid = @orgid " +
            "and item_type = 'N' " + //-- (改為and item_type = 'N')
            "and item_code_sys = '005' AND  isnull( item_suspend ,'') <> 'Y' ";//-- (改為and item_code_sys = '005')
        strSQL +=
            " Order by ITEM_CODE ";
        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID)         
        };

        return Query(strSQL, sp);
    }

    // 查詢批號清單
    public DataTable querySalPayItem(
        string strOrgID,        // 機關代碼
        string strItemCodes,    // 其他薪津發放項目勾選之代碼
        string strMergeFlowID   // 畫面條件中之批號
        )
    {
        string strSQL =
            "select PAYITEM_Merge_flow_id ,PAYITEM_CodeSys,PAYITEM_CodeNo,PAYITEM_CodeType, PAYITEM_Code ,  PAYITEM_Budget_code, SUM(PAYITEM_Pay_amt) as sum_PAYITEM_Pay_amt " +
            "from SAL_PAYITEM " +
            "left join SAL_SAITEM " +
            "on ITEM_ORGID = PAYITEM_Org_Code " +
            "and ITEM_CODE_SYS = PAYITEM_CodeSys " +
            "and ITEM_CODE_kind = PAYITEM_codekind " +
            "and ITEM_CODE_type = PAYITEM_CodeType " +
            "and ITEM_CODE_NO = PAYITEM_CodeNo " +
            "and ITEM_CODE = PAYITEM_Code " +
            "where ITEM_ORGID = @orgid AND isnull(PAYITEM_PAY_YM,'') = '' AND isnull(PAYITEM_PAY_DATE,'') = '' ";
        if (strItemCodes != "")
        {
            strSQL +=
            "and ITEM_CODE in (" + strItemCodes + ")  and  PayItem_Code in (" + strItemCodes + ")";
        }
        if (strMergeFlowID != "")
        {
            strSQL +=
            "and PAYITEM_Merge_flow_id = @MergeFlowID ";
        }
        strSQL +=
            "group by PAYITEM_Merge_flow_id ,PAYITEM_CodeSys,PAYITEM_CodeNo,PAYITEM_CodeType, PAYITEM_Code ,  PAYITEM_Budget_code ";

        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID)  ,       
            new SqlParameter("@MergeFlowID", strMergeFlowID)
        };

        return Query(strSQL, sp);

    }


    // 查詢其他薪津項目明細
    public DataTable querySalSaitemDetail
       (
         string strOrgID,        // 機關代碼
         string strMergeFlowID   // 畫面條件中之批號
       )
    {
        string strSQL =
            "select * " +
            "from sal_payitem " +
            "left outer join sal_sabase " +
            "on BASE_ORGID = PAYITEM_Org_Code " +
            "and BASE_SEQNO = PAYITEM_User_id " +
            "where PAYITEM_Org_Code =  @orgid " +
            "and PAYITEM_Merge_flow_id = @MergeFlowID " +
            "order by isnull(BASE_PRONO,'999') , isnull(BASE_PRTS ,999) ";
        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID),
            new SqlParameter("@MergeFlowID", strMergeFlowID)
        };
        return Query(strSQL, sp);
    }

    // 更新 SAL_SABASE 
    public void updateSalSaBase(
        string strOrgID             // 機關代號
        , string strEmployeeType     // 是否為臨時工
        , string strOnJobOption      // 在職狀態選項
        , string strBasePprono       // 人員類別選項
        , string strName            // 依姓名查詢
        )
    {
        string strSQL =
            "update sal_sabase " +
            "set BASE_COUNT_REMARK = 'Y' " +
            "where base_orgid = @OrgID ";

        // 計算範圍選項
        // 後續需要修改
        if (strEmployeeType == "1")
        {
            //--計算範圍為全部(不含臨時工)增加此SQL條件
            strSQL +=
                "and base_prono<> 'XXX' ";
        }
        else if (strEmployeeType == "2")
        {
            //--計算範圍為臨時工增加此SQL條件
            strSQL +=
                "and base_prono = 'XXX' ";
        }


        //--計算範圍為挑選人員增加下列SQL
        // 在職狀態相關
        // 後續需要修改
        if (strBasePprono != "")
        {
            strSQL +=
                "and base_prono in (@BasePprono) ";
            if (strOnJobOption == "1")
            {
                //--在職狀態為在職增加此SQL條件
                strSQL +=
                    "and ( base_status = 'Y' and (base_edate='' or base_edate is null)) ";
            }
            else if (strOnJobOption == "2")
            {
                //--在職狀態為離職增加此SQL條件
                strSQL +=
                "and ( base_status = 'Y' and base_edate<> '') ";
            }
            else if (strOnJobOption == "3")
            {
                strSQL +=
                "and ( base_status = 'N' and base_ismarked<> 'Y' ) ";   //--在職狀態為非員工增加此SQL條件
            }


        }
        if (strName != "")
        {
            //--依姓名查詢增加此SQL條件
            strSQL +=
                "and base_name like '%' + '" + strName + "' + '%' ";
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID),
            new SqlParameter("@BasePprono",strBasePprono)
        };

        Execute(strSQL, sp);

    }

    // 刪除其他薪津部分
    public void deleteSalSaCalCBase(
        string strOrgID             // 機關代號
        , string strYearMonth    // 計算年月 YYYYMM
        )
    {
        string strSQL =
            "delete sal_sacalcbase " +
            "where calc_orgid = @OrgID " +
            "and calc_ym = @strYearMonth ";
        SqlParameter[] sp =
        {
            new SqlParameter("@orgid",strOrgID),
            new SqlParameter("@strYearMonth",strYearMonth)
        };

        Execute(strSQL, sp);
    }


    // 新增其他薪津
    public void insertSalSacalcbase(
        string strYM,
        string strOrgID,
        string strCalType,
        string strBaseProNO,
        string strOnJob,
        string strUserName
        )
    {
        string strSQL =
            "insert into sal_sacalcbase " +
            "select @YM as ym " +//--calc_ym
            ",base_orgid " + //--calc_orgid
            ",'005' " + //--calc_item
            ",base_seqno " +//--calc_seqno
            " from sal_sabase " +
            " where base_orgid = @OrgID ";     // '登入者機關代碼'
        if (strCalType == "002")
        {
            strSQL +=
            "and base_prono<> '007' ";     // 'XXX' --計算範圍為全部(不含臨時工)增加此SQL條件
        }
        if (strCalType == "003")
        {
            strSQL +=
                "and base_prono = '007' ";      // 'XXX' --計算範圍為臨時工增加此SQL條件
        }

        if (strCalType == "005")
        {
            strSQL +=
                //--計算範圍為挑選人員增加下列SQL
            "and base_prono in ( " + strBaseProNO + " )  ";//人員類別選項
            if (strOnJob == "1")
            {
                strSQL +=
            "and ( base_status = 'Y' and (base_edate='' or base_edate is null))   ";
            }//--在職狀態為在職增加此SQL條件
            if (strOnJob == "2")
            {
                strSQL +=
            "and ( base_status = 'Y' and base_edate<> '') ";//--在職狀態為離職增加此SQL條件
            }

            if (strOnJob == "3")
            {
                strSQL +=
            "and ( base_status = 'N' and base_ismarked<> 'Y' )   ";//--在職狀態為非員工增加此SQL條件
            }
            if (strUserName != "")
            {
                strSQL +=

            "and base_name like '%' + '" + strUserName + "' + '%'";//--依姓名查詢增加此SQL條件
            }
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID),
             new SqlParameter("@YM",strYM)
        };


        Execute(strSQL, sp);
    }


    // 更薪其他
    public void updateOthersDetail(
        string strPayItemAmt,
        string strOrgID,
        string strMergeFlowID,
        string strPayitemUserID
        )
    {
        string strSQL =
            "UPDATE sal_payitem " +
            "SET PAYITEM_Pay_amt = @PayItemAmt " +
            "where PAYITEM_Org_Code =  @OrgID " +
            "and PAYITEM_Merge_flow_id = @MergeFlowID " +
            "and PAYITEM_User_id=  @PayitemUserID ";
        SqlParameter[] sp =
        {
            new SqlParameter("@PayItemAmt",strPayItemAmt),
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@MergeFlowID",strMergeFlowID),
            new SqlParameter("@PayitemUserID",strPayitemUserID)
        };

        Execute(strSQL, sp);

    }


    public string getSerNO()
    {
        string strSQL =
            "declare @seqno int  declare @lpad_seqno varchar(8000) " +
            "exec get_sequenceno @seqno output   exec lpad @seqno ,12,'0',@lpad_seqno output  " +
            "select @lpad_seqno ";

        SqlParameter[] sp =
        {
        };

        DataTable dt = Query(strSQL, sp);
        return dt.Rows[0][0].ToString();

    }

    public void updateSABase
        (
        string strOrgID, // '登入者機關代碼'   
        string strCalType,  // 計算範圍
        string strBaseProNO,//人員類別選項
        string strOnJob,    // 在職狀態
        string strUserName  // 姓名
        )
    {
        string strSQL =
            "update sal_sabase " +
            "set BASE_COUNT_REMARK = 'Y' " +
            "where base_orgid = @OrgID ";     // '登入者機關代碼'
        if (strCalType == "002")
        {
            strSQL +=
            "and base_prono<> '007' ";     // 'XXX' --計算範圍為全部(不含臨時工)增加此SQL條件
        }
        if (strCalType == "003")
        {
            strSQL +=
                "and base_prono = '007' ";      // 'XXX' --計算範圍為臨時工增加此SQL條件
        }

        if (strCalType == "005")
        {
            strSQL +=
                //--計算範圍為挑選人員增加下列SQL
            "and base_prono in ( '" + strBaseProNO + "' )  ";//人員類別選項
            if (strOnJob == "1")
            {
                strSQL +=
            "and ( base_status = 'Y' and (base_edate='' or base_edate is null))   ";
            }//--在職狀態為在職增加此SQL條件
            if (strOnJob == "2")
            {
                strSQL +=
            "and ( base_status = 'Y' and base_edate<> '') ";//--在職狀態為離職增加此SQL條件
            }
            if (strOnJob == "3")
            {
                strSQL +=
            "and ( base_status = 'N' and base_ismarked<> 'Y' )   ";//--在職狀態為非員工增加此SQL條件
            }
            if (strUserName != "")
            {
                strSQL +=

            "and base_name like '%' + '" + strUserName + "' + '%'";//--依姓名查詢增加此SQL條件
            }
        }
        SqlParameter[] sp =
        {
            new SqlParameter("@OrgID",strOrgID)
        };

        Execute(strSQL, sp);


    }

    public void insertSalSabatJob
        (
        string strJobNO, //'job流水號'
        string strOrgID,//'登入者機關代碼'
        string strJobUserID,//'登入者員工編號'
        string strJobItem,//'計算項目代碼'
        string strType  // 計算範圍
        )
    {
        string strSQL =
            "insert into SAL_SABATJOB( " +
            "job_no,JOB_ORGID,JOB_USERID,JOB_ITEM,JOB_RANGE,JOB_BOOKTIME,JOB_STATUS,JOB_SERVERNAME,JOB_GOTO_PATH) " +
            "values " +
            "( @JobNO " +//'job流水號'
            ",@OrgID " +//'登入者機關代碼'
            ",@JobUserID " +//'登入者員工編號'
            ",@JobItem ";//'計算項目代碼'
        // --計算範圍全部(含臨時工)時為A，非全部(含臨時工)為P
        if (strType == "001")
        {
            strSQL += ",'A' ";
        }
        else
        {
            strSQL += ",'P' ";
        }
        strSQL +=
            ",'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' " +
            // ",GetDate() " +// ",'現在時間'
            ",'W','','') ";

        SqlParameter[] sp =
        {
            new SqlParameter("@JobNO",strJobNO),
            new SqlParameter("@OrgID",strOrgID),
            new SqlParameter("@JobUserID",strJobUserID),
            new SqlParameter("@JobItem",strJobItem)
        };

        Execute(strSQL, sp);


    }


    public void insertSalSaBatPara
        (
        string strParaJobNo,    // 'job流水號'
        string strParaOrderNo,
        string strParaValue     //'job使用者畫面選擇之計算年月'     
        )
    {
        string strSQL =
            "insert into sal_sabatpara (para_job_no,para_order_no,para_value) " +
            "values ( @ParaJonNo " +    // 'job流水號'
            ", @ParaOrderNo " +  // 
            ", @ParaValue) "; //'job使用者畫面選擇之計算年月'

        SqlParameter[] sp =
        {
            new SqlParameter("@ParaJonNo",strParaJobNo),
            new SqlParameter("@ParaOrderNo",strParaOrderNo),
            new SqlParameter("@ParaValue",strParaValue)
        };

        Execute(strSQL, sp);
    }


    public DataTable detail1
     (
            string strtype,
            string Job,
            string UserName,
            string Depart,
            string Depart1
     )
    {
        string strSQL =
                    " select *,isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='002' and code_no=base_dcode),'未設定') as base_dcode_name " //職稱
                  + ",isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='006' and code_no=base_org_l1),'未設定') as org_l1_name " //職等
                  + " from SAL_SABASE "
                  + " where 1=1  "
                  + " and base_prono = @strtype ";

        if (Job == "1")
        {
            strSQL +=
        " and ( base_status = 'Y' and (base_edate='' or base_edate is null))   ";
        }
        if (Job == "2")
        {
            strSQL += " and ( base_status = 'Y' and base_edate<> '') ";
        }

        if (Job == "3")
        {
            strSQL += " and ( base_status = 'N' and base_ismarked<> 'Y' )   ";
        }
        if (UserName != "")
        {
            strSQL += " and base_name like '%' + '" + UserName.Trim() + "' + '%'";//--依姓名查詢增加此SQL條件
        }

        if (Depart != "")
        {

            strSQL += " and exists"
             + "  ("
             + "  select 1 from FSC_Depart_EMP "
             + "  where Orgcode = BASE_ORGID "
             + "  and Id_card = BASE_SEQNO "
             + "  and Depart_id like @Depart + '%' "
             + "  and service_type = '0' "
             + "  ) ";// -- 有選擇 佔缺單位 再加入此查詢條件
        }
        if (Depart1 != "")
        {
            strSQL += "  and exists "
            + "  ( "
            + "  select 1 from FSC_Depart_EMP "
            + "  where Orgcode = BASE_ORGID "
            + "  and Id_card = BASE_SEQNO "
            + "  and Depart_id like @Depart1 + '%' "
            + "  and service_type = '1' "
            + "  )  ";//-- 有選擇 服務單位 再加入此查詢條
        }

        SqlParameter[] sp =
        {
            new SqlParameter("@strtype",strtype),
            new SqlParameter("@Job", Job),
            new SqlParameter("@UserName",UserName),
            new SqlParameter("@Depart", Depart),
            new SqlParameter("@Depart1", Depart1)
        };
        return Query(strSQL, sp);
    }







}