using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using FSC.Logic;


/// <summary>
/// SAL2116 的摘要描述
/// </summary>
/// 
namespace SALPLM.Logic
{
    public class SAL2116
    {
        private SAL2116DAO DAO;

        public SAL2116()
        {
            DAO = new SAL2116DAO();
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public SAL2116(SqlConnection conn)
        {
            DAO = new SAL2116DAO(conn);
        }

        // 查詢相關項目名稱
        public DataTable querySalItemName(
            string strOrgID,               // 機關代碼
            string strItemType             // 項目類別
            )
        {
            DataTable dt = DAO.querySalItemName(strOrgID, strItemType);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 取得相關發放日期
        public DataTable queryIncoDate(
            string strOrgID,
            string strIncoCode,     // 發放種壘 
            string strIncoYM,       // 薪資年月
            string strIncoKindCode // 項目名稱代碼 
            )
        {
            DataTable dt = DAO.queryIncoDate(strOrgID, strIncoCode, strIncoYM, strIncoKindCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        // 報表查詢
        public DataTable queryReport(
            string strOrgID,
            string strIncoCode,         // 發放種壘 
            string strIncoYM,           // 薪資年月
            string strIncoKindCode      // 項目名稱代碼 
            , string strIncoDate        //'查詢畫面第三步之發放日期'
            , string strBaseProNo       // '查詢畫面第四步之人員類別代碼(code_no)'
            , string strIncoBudGeCode   //'查詢畫面第四步之預算來源代碼(code_no)'
            , string strIncoICode       //'查詢畫面第四步之所得類別代碼(code_no)'
            )
        {
            DataTable dt1 = DAO.queryReportPart1(strOrgID, strIncoCode, strIncoYM, strIncoKindCode, strIncoDate, strBaseProNo, strIncoBudGeCode, strIncoICode);
            int iCNT_1=0;
            double fINCO_TXAM_1=0;
            double fINCO_REAL_AMT_1=0;
            double fINCO_AMT_1=0;
            if (dt1 == null || dt1.Rows.Count == 0)
            {
                iCNT_1=Convert.ToInt32(dt1.Rows[0]["CNT"].ToString());
                fINCO_TXAM_1=Convert.ToDouble(dt1.Rows[0]["INCO_TXAM"].ToString());
                fINCO_REAL_AMT_1    =Convert.ToDouble(dt1.Rows[0]["INCO_REAL_AMT"].ToString());
                fINCO_AMT_1 =Convert.ToDouble(dt1.Rows[0]["INCO_AMT"].ToString());
            }
            else
            {
                //return dt1;
            }
            DataTable dt2 = DAO.queryReportPart2(strOrgID, strIncoCode, strIncoYM, strIncoKindCode, strIncoDate, strBaseProNo, strIncoBudGeCode, strIncoICode);
            int iCNT_2=0;
            double fINCO_TXAM_2=0;
            double fINCO_REAL_AMT_2=0;
            double fINCO_AMT_2=0;
            if (dt2 == null || dt2.Rows.Count == 0)
            {
                iCNT_2=Convert.ToInt32(dt2.Rows[0]["CNT"].ToString());
                fINCO_TXAM_2=Convert.ToDouble(dt2.Rows[0]["INCO_TXAM"].ToString());
                fINCO_REAL_AMT_2    =Convert.ToDouble(dt2.Rows[0]["INCO_REAL_AMT"].ToString());
                fINCO_AMT_2 =Convert.ToDouble(dt2.Rows[0]["INCO_AMT"].ToString());
            }
            else
            {
                //return dt1;
            }
            int iCNT_3=0;
            double fINCO_TXAM_3=0;
            double fINCO_REAL_AMT_3=0;
            double fINCO_AMT_3=0;
            DataTable dt3 = DAO.queryReportPart3(strOrgID, strIncoCode, strIncoYM, strIncoKindCode, strIncoDate, strBaseProNo, strIncoBudGeCode, strIncoICode);
            if (dt3 == null || dt3.Rows.Count == 0)
            {
                iCNT_3=Convert.ToInt32(dt3.Rows[0]["CNT"].ToString());
                fINCO_TXAM_3=Convert.ToDouble(dt3.Rows[0]["INCO_TXAM"].ToString());
                fINCO_REAL_AMT_3    =Convert.ToDouble(dt3.Rows[0]["INCO_REAL_AMT"].ToString());
                fINCO_AMT_3 =Convert.ToDouble(dt3.Rows[0]["INCO_AMT"].ToString());
            }
            else
            {
                //return dt1;
            }
            DataTable dt4 = DAO.queryReportPart4(strOrgID, strIncoCode, strIncoYM, strIncoKindCode, strIncoDate, strBaseProNo, strIncoBudGeCode, strIncoICode);
                       int iCNT_4=0;
            double fINCO_TXAM_4=0;
            double fINCO_REAL_AMT_4=0;

            if (dt4 == null || dt4.Rows.Count == 0)
            {
                iCNT_4=Convert.ToInt32(dt4.Rows[0]["CNT"].ToString());
                fINCO_TXAM_4=Convert.ToDouble(dt4.Rows[0]["INCO_TXAM"].ToString());
                fINCO_REAL_AMT_4    =Convert.ToDouble(dt4.Rows[0]["INCO_REAL_AMT"].ToString());
            }
            else
            {
                //return dt1;
            }


            DataTable dt=new DataTable();//
            dt.Columns.Add("CNT_1", typeof(Int32));
            dt.Columns.Add("INCO_TXAM_1", typeof(double));
            dt.Columns.Add("INCO_REAL_AMT_1", typeof(double));
            dt.Columns.Add("INCO_AMT_1", typeof(double));
            dt.Columns.Add("CNT_2", typeof(Int32));
            dt.Columns.Add("INCO_TXAM_2", typeof(double));
            dt.Columns.Add("INCO_REAL_AMT_2", typeof(double));
            dt.Columns.Add("INCO_AMT_2", typeof(double));
            dt.Columns.Add("CNT_3", typeof(Int32));
            dt.Columns.Add("INCO_TXAM_3", typeof(double));
            dt.Columns.Add("INCO_REAL_AMT_3", typeof(double));
            dt.Columns.Add("INCO_AMT_3", typeof(double));
            dt.Columns.Add("CNT_4", typeof(Int32));
            dt.Columns.Add("INCO_TXAM_4", typeof(double));
            dt.Columns.Add("INCO_REAL_AMT_4", typeof(double));

            DataRow row = dt.NewRow();
            row["CNT_1"]=iCNT_1;
            row["INCO_TXAM_1"]=fINCO_TXAM_1;
            row["INCO_REAL_AMT_1"]=fINCO_REAL_AMT_1;
            row["INCO_AMT_1"]=fINCO_AMT_1;
            row["CNT_2"]=iCNT_2;
            row["INCO_TXAM_2"]=fINCO_TXAM_2;
            row["INCO_REAL_AMT_2"]=fINCO_REAL_AMT_2;
            row["INCO_AMT_2"]=fINCO_AMT_2;
            row["CNT_3"]=iCNT_3;
            row["INCO_TXAM_3"]=fINCO_TXAM_3;
            row["INCO_REAL_AMT_3"]=fINCO_REAL_AMT_3;
            row["INCO_AMT_3"]=fINCO_AMT_3;
            row["CNT_4"]=iCNT_4;
            row["INCO_TXAM_4"]=fINCO_TXAM_4;
            row["INCO_REAL_AMT_4"]=fINCO_REAL_AMT_4;
            dt.Rows.Add(row);

            return dt;
        }

    }
}