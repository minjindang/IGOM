using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;

/// <summary>
/// SAL3125 的摘要描述
/// SAL3125  勞健保投保金額調整作業
/// Eliot Chen
/// </summary>
namespace SALPLM.Logic
{
    public class SAL3125
    {
        private SAL3125DAO DAO;

        public SAL3125()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new SAL3125DAO();

        }

        public SAL3125(SqlConnection conn)
        {
            DAO = new SAL3125DAO(conn);
        }

        private DataTable queryDataTableProcess(            
            DataTable dt,
            string strOrgID,        // 單位代碼
            string strEmployees,    // BA人員類別清單
            string strYearMonth     // 輸入年月
            )
        {
            
               // Add 欄位
                // 3 各月薪資欄位
                dt.Columns.Add("sum_payod_amt_1", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_2", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_3", typeof(Int32));
                // 加班費
                dt.Columns.Add("sum_payod_amt_005_1", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_005_2", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_005_3", typeof(Int32));
                // 不休假加班費
                dt.Columns.Add("sum_payod_amt_NoLeave", typeof(Int32));
                // 三個月平均薪資
                dt.Columns.Add("avg3Months", typeof(Int32));
                // 舊勞保金額
                dt.Columns.Add("stws_stand_001", typeof(Int32));
                // 舊勞保自付
                dt.Columns.Add("sum_payod_amt_001", typeof(Int32));
                // 新勞保金額
                dt.Columns.Add("stws_stand_001_001", typeof(Int32));
                // 新勞保自付
                dt.Columns.Add("sum_payod_amt_001_001", typeof(Int32));
                // 舊健保金額
                dt.Columns.Add("stws_stand_002", typeof(Int32));
                // 舊健保自付
                //                dt.Columns.Add("stws_stand_002", typeof(Int32));
                // 新健保金額
                dt.Columns.Add("stws_stand_002_New", typeof(Int32));
                // 新健保自付
                dt.Columns.Add("Stws_dct", typeof(Int32));

                // 新勞保級距
                dt.Columns.Add("STWS_LEVEL_New");
                // 新健保級距
                dt.Columns.Add("STWS_LEVEL_002_New");
                dt.Columns.Add("ROWSEQ");
                // 健保需角
                dt.Columns.Add("NeedPay", typeof(Double));
                // 健保已繳
                dt.Columns.Add("PayedHealth", typeof(Double));
                // 勞保已繳
                dt.Columns.Add("PayedLabor", typeof(Double));



                // 其他欄位處理
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {

                    IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
                    DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);
                    dt.Rows[iRow]["ROWSEQ"] = iRow+1;

                    for (int i = -2; i < 1; i++)
                    {
                        DateTime dt4Query = datetime4query.AddMonths(i);
                        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                        DataTable dtSalary = DAO.querySalaryByYearMonth(strDT4Query, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                        string strColumneNameTemp = "sum_payod_amt_" + (i + 3).ToString();
                        if (dtSalary == null || dtSalary.Rows.Count == 0)
                        {
                            dt.Rows[iRow][strColumneNameTemp] = 0;
                        }
                        else
                        {
                            dt.Rows[iRow][strColumneNameTemp] = dtSalary.Rows[0]["sum_payod_amt"];
                        }

                        dtSalary = DAO.queryOverTimePayByYearMonth(strDT4Query, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                        strColumneNameTemp = "sum_payod_amt_005_" + (i + 3).ToString();
                        if (dtSalary == null || dtSalary.Rows.Count == 0)
                        {
                            dt.Rows[iRow][strColumneNameTemp] = 0;
                        }
                        else
                        {
                            dt.Rows[iRow][strColumneNameTemp] = dtSalary.Rows[0]["sum_payod_amt"];
                        }
                        //                    string strYearMonth=
                        //                    dt.Columns.Add("");
                    }

                    
                    // 不休假加班費
                    // 開始年月
                    string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
                    // 結束年月
                    DateTime dt4QueryEnd = datetime4query.AddMonths(2);
                    string strDT4QueryEnd = String.Format("{0:yyyyMM}", dt4QueryEnd);

                    DataTable dtTemp =
                        DAO.queryOverTimePayOfNoLeaveByYearMonth(strDT4QueryStart, strDT4QueryEnd, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["sum_payod_amt_NoLeave"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["sum_payod_amt_NoLeave"] = dtTemp.Rows[0]["sum_payod_amt"];
                    }

                    // 3各月平均薪資
                    dt.Rows[iRow]["avg3Months"] =
                        Convert.ToInt32((
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_1"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_2"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_3"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_1"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_2"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_3"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_NoLeave"])) / 3)
                        ;
                    
                    // 舊勞保金額
                    dtTemp = DAO.queryLaborInsuranceOld(strDT4QueryStart,
                        dt.Rows[iRow]["base_labor_series"].ToString()
                    );
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_001"] = dtTemp.Rows[0]["stws_stand"];
                    }

                    // 舊勞保自付
                    dtTemp = DAO.queryLaborInsuranceOldPayBySelf
                        (strDT4QueryStart, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgID);
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["sum_payod_amt_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["sum_payod_amt_001"] = dtTemp.Rows[0]["sum_payod_amt"];
                    }


                    // 新勞保金額
                    dtTemp = DAO.queryLaborInsuranceNew(strDT4QueryStart,
                        Convert.ToSingle(dt.Rows[iRow]["avg3Months"].ToString()));
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_001_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_001_001"] = dtTemp.Rows[0]["stws_stand"];
                        dt.Rows[iRow]["STWS_LEVEL_New"] = dtTemp.Rows[0]["STWS_LEVEL"];
                    }

                    // 新勞保自付
                    // 暫缺
                    int iSumPayodAmy002 = 0;
                    for (int i = -2; i < 1; i++)
                    {
                        DateTime dt4Query = datetime4query.AddMonths(i);
                        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                        dtTemp = DAO.queryLaborInsuranceNewPayBySelf(
                            dt.Rows[iRow]["base_labor_status"].ToString(),
                            dt.Rows[iRow]["base_labor_series"].ToString(),
                            strDT4Query,
                            dt.Rows[iRow]["base_lab_jif"].ToString(),
                            dt.Rows[iRow]["base_fins_self"].ToString(),
                            dt.Rows[iRow]["BASE_BDATE"].ToString(),
                            dt.Rows[iRow]["BASE_EDATE"].ToString(),
                            "", "",
                            strOrgID,
                            dt.Rows[iRow]["base_lab1"].ToString(),
                            dt.Rows[iRow]["base_lab2"].ToString(),
                            dt.Rows[iRow]["base_lab3"].ToString(),
                            dt.Rows[iRow]["base_fins_kind"].ToString()
                            );

                        if (dtTemp.Rows.Count > 0)
                        {
                            try
                            {
                                iSumPayodAmy002 +=
                                    Convert.ToInt32(dtTemp.Rows[0]["rv"].ToString());
                            }
                            catch
                            {
                            }
                        }

                    }

                    

                    dt.Rows[iRow]["sum_payod_amt_001_001"] = iSumPayodAmy002;


                    // 舊健保金額
                    // stws_stand_002
                    dtTemp = DAO.queryStws002(strDT4QueryStart, dt.Rows[iRow]["base_fins_series"].ToString());
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_002"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_002"] = dtTemp.Rows[0]["stws_stand"];
                    }



                    // 舊健保自付
                    // 不需


                    // 新健保金額
                    // 新健保自付
                    dtTemp = DAO.queryStws002New(strDT4QueryStart,
                        Convert.ToSingle(dt.Rows[iRow]["avg3Months"].ToString()));
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_002_New"] = 0;
                        dt.Rows[iRow]["Stws_dct"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_002_New"] = dtTemp.Rows[0]["stws_stand"];
                        dt.Rows[iRow]["Stws_dct"] = dtTemp.Rows[0]["Stws_dct"];
                        dt.Rows[iRow]["STWS_LEVEL_002_New"] = dtTemp.Rows[0]["STWS_LEVEL"];

                    }
                    // 健保自付計算2
                    Double iTemp = 0;
                    for (int i = -2; i < 1; i++)
                    {

                        DateTime dt4Query = datetime4query.AddMonths(i);
                        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                        iTemp +=
                            DAO.getHelthSelfShould1(
                            dt.Rows[iRow]["base_fin_amt"].ToString(),
                            dt.Rows[iRow]["base_fins_nol"].ToString(),
                            dt.Rows[iRow]["base_fins_noq"].ToString(),
                            dt.Rows[iRow]["base_fins_noh"].ToString(),
                            dt.Rows[iRow]["base_fins_nof"].ToString(),
                            dt.Rows[iRow]["base_fins_noq_nol"].ToString(),
                            dt.Rows[iRow]["base_fins_noh_nol"].ToString(),
                            dt.Rows[iRow]["base_fins_no"].ToString(),
                            strDT4Query
                            );
                    }

                    iTemp += DAO.getHelthSelfShould2(dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgID);

                    dt.Rows[iRow]["NeedPay"] = iTemp;//NeedPay

                    string strDTNow = String.Format("{0:yyyyMM}", datetime4query);
                    string strDT3Ago = String.Format("{0:yyyyMM}", datetime4query.AddMonths(-3));

                    iTemp = DAO.getPaiedLabor(strDT3Ago, strDTNow, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgID);
                    dt.Rows[iRow]["PayedLabor"] = iTemp;
                    iTemp = DAO.getPaiedHealth(strDT3Ago, strDTNow, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgID);
                    dt.Rows[iRow]["PayedHealth"] = iTemp;
                }
                return dt;

        }

    // 查詢調升或調降
        public DataTable queryUpandDown1(
            string strOrgID,        // 單位代碼
            string strEmployees,     // BA人員類別清單
            string strYearMonth
            , int itype
            )
        {
            string strParaEmployee = strEmployees;
            if (strEmployees == "ALL")
                strParaEmployee = "";

            DataTable dt = DAO.queryUpandDown1(strOrgID, strParaEmployee, strYearMonth, itype);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                dt = queryDataTableProcess(dt, strOrgID, strEmployees, strYearMonth);
            }
            return dt;
        }

        // 取得 sal_sabase 資料
        public DataTable querySalSaBase(
            string strOrgID,        // 單位代碼
            string strEmployees,    // BA人員類別清單
            string strYearMonth,     // 輸入年月
            string mode
            )
        {
            string strParaEmployee = strEmployees;
            if (strEmployees == "ALL")
                strParaEmployee = "";

            DataTable dt = DAO.querySalSaBase(strOrgID, strParaEmployee);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dt;
            }
            else
            {
                if (mode != "search")//ted add 0730
                {
                    dt = queryDataTableProcess(dt, strOrgID, strEmployees, strYearMonth);
                }

                /*
                // Add 欄位
                // 3 各月薪資欄位
                dt.Columns.Add("sum_payod_amt_1", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_2", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_3", typeof(Int32));
                // 加班費
                dt.Columns.Add("sum_payod_amt_005_1", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_005_2", typeof(Int32));
                dt.Columns.Add("sum_payod_amt_005_3", typeof(Int32));
                // 不休假加班費
                dt.Columns.Add("sum_payod_amt_NoLeave", typeof(Int32));
                // 三個月平均薪資
                dt.Columns.Add("avg3Months", typeof(Int32));
                // 舊勞保金額
                dt.Columns.Add("stws_stand_001", typeof(Int32));
                // 舊勞保自付
                dt.Columns.Add("sum_payod_amt_001", typeof(Int32));
                // 新勞保金額
                dt.Columns.Add("stws_stand_001_001", typeof(Int32));
                // 新勞保自付
                dt.Columns.Add("sum_payod_amt_001_001", typeof(Int32));
                // 舊健保金額
                dt.Columns.Add("stws_stand_002", typeof(Int32));
                // 舊健保自付
                //                dt.Columns.Add("stws_stand_002", typeof(Int32));
                // 新健保金額
                dt.Columns.Add("stws_stand_002_New", typeof(Int32));
                // 新健保自付
                dt.Columns.Add("Stws_dct", typeof(Int32));

                // 新勞保級距
                dt.Columns.Add("STWS_LEVEL_New");
                // 新健保級距
                dt.Columns.Add("STWS_LEVEL_002_New");



                // 其他欄位處理
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {

                    IFormatProvider culture = new System.Globalization.CultureInfo("zh-TW", true);
                    DateTime datetime4query = DateTime.ParseExact(strYearMonth + "01", "yyyyMMdd", culture);

                    for (int i = -2; i < 1; i++)
                    {
                        DateTime dt4Query = datetime4query.AddMonths(i);
                        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                        DataTable dtSalary = DAO.querySalaryByYearMonth(strDT4Query, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                        string strColumneNameTemp = "sum_payod_amt_" + (i + 3).ToString();
                        if (dtSalary == null || dtSalary.Rows.Count == 0)
                        {
                            dt.Rows[iRow][strColumneNameTemp] = 0;
                        }
                        else
                        {
                            dt.Rows[iRow][strColumneNameTemp] = dtSalary.Rows[0]["sum_payod_amt"];
                        }

                        dtSalary = DAO.queryOverTimePayByYearMonth(strDT4Query, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                        strColumneNameTemp = "sum_payod_amt_005_" + (i + 3).ToString();
                        if (dtSalary == null || dtSalary.Rows.Count == 0)
                        {
                            dt.Rows[iRow][strColumneNameTemp] = 0;
                        }
                        else
                        {
                            dt.Rows[iRow][strColumneNameTemp] = dtSalary.Rows[0]["sum_payod_amt"];
                        }
                        //                    string strYearMonth=
                        //                    dt.Columns.Add("");
                    }


                    // 不休假加班費
                    // 開始年月
                    string strDT4QueryStart = String.Format("{0:yyyyMM}", datetime4query);
                    // 結束年月
                    DateTime dt4QueryEnd = datetime4query.AddMonths(2);
                    string strDT4QueryEnd = String.Format("{0:yyyyMM}", dt4QueryEnd);

                    DataTable dtTemp =
                        DAO.queryOverTimePayOfNoLeaveByYearMonth(strDT4QueryStart, strDT4QueryEnd, strOrgID,
                            dt.Rows[iRow]["BASE_SEQNO"].ToString());
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["sum_payod_amt_NoLeave"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["sum_payod_amt_NoLeave"] = dtTemp.Rows[0]["sum_payod_amt"];
                    }

                    // 3各月平均薪資
                    dt.Rows[iRow]["avg3Months"] =
                        Convert.ToInt32((
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_1"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_2"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_3"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_1"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_2"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_005_3"]) +
                        Convert.ToInt32(dt.Rows[iRow]["sum_payod_amt_NoLeave"])) / 3)
                        ;

                    // 舊勞保金額
                    dtTemp = DAO.queryLaborInsuranceOld(strDT4QueryStart,
                        dt.Rows[iRow]["base_labor_series"].ToString()
                    );
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_001"] = dtTemp.Rows[0]["stws_stand"];
                    }

                    // 舊勞保自付
                    dtTemp = DAO.queryLaborInsuranceOldPayBySelf
                        (strDT4QueryStart, dt.Rows[iRow]["BASE_SEQNO"].ToString(), strOrgID);
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["sum_payod_amt_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["sum_payod_amt_001"] = dtTemp.Rows[0]["sum_payod_amt"];
                    }


                    // 新勞保金額
                    dtTemp = DAO.queryLaborInsuranceNew(strDT4QueryStart,
                        Convert.ToSingle(dt.Rows[iRow]["avg3Months"].ToString()));
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_001_001"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_001_001"] = dtTemp.Rows[0]["stws_stand"];
                        dt.Rows[iRow]["STWS_LEVEL_New"] = dtTemp.Rows[0]["STWS_LEVEL"];
                    }

                    // 新勞保自付
                    // 暫缺
                    int iSumPayodAmy002 = 0;
                    for (int i = -2; i < 1; i++)
                    {
                        DateTime dt4Query = datetime4query.AddMonths(i);
                        string strDT4Query = String.Format("{0:yyyyMM}", dt4Query);

                        dtTemp = DAO.queryLaborInsuranceNewPayBySelf(
                            dt.Rows[iRow]["base_labor_status"].ToString(),
                            dt.Rows[iRow]["base_labor_series"].ToString(),
                            strDT4Query,
                            dt.Rows[iRow]["base_lab_jif"].ToString(),
                            dt.Rows[iRow]["base_fins_self"].ToString(),
                            dt.Rows[iRow]["BASE_BDATE"].ToString(),
                            dt.Rows[iRow]["BASE_EDATE"].ToString(),
                            "","",
                            strOrgID,
                            dt.Rows[iRow]["base_lab1"].ToString(),
                            dt.Rows[iRow]["base_lab2"].ToString(),
                            dt.Rows[iRow]["base_lab3"].ToString(),
                            dt.Rows[iRow]["base_fins_kind"].ToString()
                            );

                        if (dtTemp.Rows.Count > 0)
                        {
                            try
                            {
                                iSumPayodAmy002 +=
                                    Convert.ToInt32(dtTemp.Rows[0]["rv"].ToString());
                            }
                            catch
                            {
                            }
                        }

                    }

                    dt.Rows[iRow]["sum_payod_amt_001_001"] = iSumPayodAmy002;


                    // 舊健保金額
                    // stws_stand_002
                    dtTemp = DAO.queryStws002(strDT4QueryStart, dt.Rows[iRow]["base_fins_series"].ToString());
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_002"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_002"] = dtTemp.Rows[0]["stws_stand"];
                    }



                    // 舊健保自付
                    // 不需


                    // 新健保金額
                    // 新健保自付
                    dtTemp = DAO.queryStws002New(strDT4QueryStart,
                        Convert.ToSingle(dt.Rows[iRow]["avg3Months"].ToString()));
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        dt.Rows[iRow]["stws_stand_002_New"] = 0;
                        dt.Rows[iRow]["Stws_dct"] = 0;
                    }
                    else
                    {
                        dt.Rows[iRow]["stws_stand_002_New"] = dtTemp.Rows[0]["stws_stand"];
                        dt.Rows[iRow]["Stws_dct"] = dtTemp.Rows[0]["Stws_dct"];
                        dt.Rows[iRow]["STWS_LEVEL_002_New"] = dtTemp.Rows[0]["STWS_LEVEL"];

                    }
                    // 新健保自付


                }
                */


                return dt;
            }

        }


        public void doAdjestSaBase(
            string strOrgID,        // 單位代號
            string strBaseSeqNO,    // 人員代號
            string strBase_labor_series,    //新勞保級距
            string strBase_fins_series,     // 新健保級距
            Single BASE_FINS_HEALTH_SELF,//自付
            Single Base_fin_amt
            )
        {
            DAO.doAdjestSaBase
                (
                strOrgID,        // 單位代號
                strBaseSeqNO,    // 人員代號
                strBase_labor_series,    //新勞保級距
                strBase_fins_series,     // 新健保級距
                BASE_FINS_HEALTH_SELF,
                Base_fin_amt
               );
        }


        public DataTable querySalaryByYearMonth(
          string strDT4Query,        
          string strOrgID,    
          string BASE_SEQNO    
          )
        {

          return  DAO.querySalaryByYearMonth(strDT4Query, strOrgID, BASE_SEQNO );
        }

        public DataTable queryOverTimePayByYearMonth(
       string strDT4Query,
       string strOrgID,
       string BASE_SEQNO
       )
        {

            return DAO.queryOverTimePayByYearMonth(strDT4Query, strOrgID, BASE_SEQNO);
        }

        public DataTable queryOverTimePayOfNoLeaveByYearMonth(
    string strDT4QueryStart,
    string strDT4QueryEnd,
    string strOrgCode,
    string Base_seqno
    )
        {

            return DAO.queryOverTimePayOfNoLeaveByYearMonth(strDT4QueryStart, strDT4QueryEnd, strOrgCode, Base_seqno);
        }


        public DataTable queryLaborInsuranceOld(
             string strDT4QueryStart,
             string base_labor_series
             )
        {
            return DAO.queryLaborInsuranceOld(strDT4QueryStart, base_labor_series);
        }


        public DataTable queryLaborInsuranceOldPayBySelf(
          string strDT4QueryStart,
          string BASE_SEQNO,
            string strOrgCode
          )
        {
            return DAO.queryLaborInsuranceOldPayBySelf(strDT4QueryStart, BASE_SEQNO, strOrgCode);
        }

        public DataTable queryLaborInsuranceNew(
        string strYearMonth,        // 畫面上輸入之年月
        Single fSalaryAvg3Month     // 三個月平均工資
      )
        {
            return DAO.queryLaborInsuranceNew(strYearMonth, fSalaryAvg3Month);
        }


        public DataTable queryLaborInsuranceNewPayBySelf(
        string str_base_labor_status,
        string str_base_labor_series,
        string str_YearMonths,
        string str_base_lab_jif,
        string str_base_fins_self,
        string str_bdate,
        string str_edate,
        string str_proj_bdate,
        string str_proj_edate,
        string strOrgID,
        string str_base_lab1,
        string str_base_lab2,
        string str_base_lab3,
        string str_base_fins_kind
 )
        {
            return DAO.queryLaborInsuranceNewPayBySelf(str_base_labor_status,
                   str_base_labor_series,
                    str_YearMonths,
                    str_base_lab_jif,
                    str_base_fins_self,
                    str_bdate,
                    str_edate,
                    "", "",
                    strOrgID,
                    str_base_lab1,
                    str_base_lab2,
                    str_base_lab3,
                    str_base_fins_kind);
        }



        public DataTable queryStws002(
            string strYearMonth,
            string strbase_fins_series   
 )
        {
            return DAO.queryStws002(strYearMonth, strbase_fins_series);
        }


        public DataTable queryStws002New(
         string strYearMonth,
        Single fAvg3Month
)
        {
            return DAO.queryStws002New(strYearMonth, fAvg3Month);
        }




    }
}