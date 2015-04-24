using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Car2102DAO
/// </summary>
namespace CAR.Logic
{
    public class Car2102DAO : BaseDAO
    {
        public Car2102DAO()
            : base(ConnectDB.GetDBString())
        {

        }

        public DataTable SelectReportDataGroupByCar(string OrgCode, string dateS, string dateE)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT CM.Car_id  AS [Name],ISNULL(TMP.[Hours],0) [Hours],ISNULL(TMP.TCOUNT,0) TCOUNT,ISNULL(TMP.Usage,0) Usage,ISNULL(TMP.[Count],0) [Count],TMP.LINKS,TMP.CARS ");
            sql.Append(" FROM CAR_Car_main CM ");
            sql.Append(" LEFT JOIN ");
            sql.Append(" ( ");

            sql.Append(" SELECT 1 AS CARS,");
            sql.Append(" '~/CAR/CAR2/CAR2102_03.aspx?cardid='+ CCDD.Car_id +'&sdate=' +@dateS +'&edate=' +@dateE  AS LINKS,");

            // 車牌號碼
            sql.Append(" CCDD.Car_id AS [Name],");

            // 使用時數
            sql.Append(" CONVERT(NUMERIC(18,2),SUM(DATEDIFF(MINUTE,C1.CODE_DESC1+':00',C2.CODE_DESC1+':00'))/60.0) AS [Hours], ");

            // 總使用時數=13*查詢條件天數
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) AS TCOUNT,");

            // 使用率=使用時數/總使用時數
            sql.Append(" CASE WHEN ");
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) =0 THEN 0 ");
            sql.Append(" ELSE ");
            sql.Append(" CONVERT(NUMERIC(18,2), ");
            sql.Append(" (SUM(DATEDIFF(MINUTE,C1.CODE_DESC1+':00',C2.CODE_DESC1+':00'))/60.0+0.0)/ ");
            sql.Append(" ( ");
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) ");
            sql.Append(" )*100) END AS Usage, ");

            //  使用次數
            sql.Append(" Count(CCDD.Car_id) [Count] ");

            sql.Append(" FROM CAR_CarDispatch_main CCDM ");
            sql.Append(" INNER JOIN CAR_CarDispatch_det CCDD ON CCDM.Flow_id=CCDD.Flow_id ");
            sql.Append(" LEFT JOIN SYS_CODE C1 ON C1.CODE_NO=CCDD.Start_time AND C1.CODE_SYS='015' AND C1.CODE_TYPE='006' ");
            sql.Append(" LEFT JOIN SYS_CODE C2 ON C2.CODE_NO=CCDD.End_time AND C2.CODE_SYS='015' AND C2.CODE_TYPE='006' ");
            sql.Append(" WHERE CCDM.OrgCode=@OrgCode AND CCDD.Dispatch_date BETWEEN @dateS AND @dateE AND CCDD.Car_id IS NOT NULL ");
            sql.Append(" GROUP BY CCDD.Car_id ");

            sql.Append(" ) TMP ON CM.Car_id =TMP.Name ");
            sql.Append(" ORDER BY CM.Car_id ");

            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@dateS", dateS),
                new SqlParameter("@dateE", dateE),
                new SqlParameter("@OrgCode", OrgCode)
            };

            return Query(sql.ToString(), sp);
        }

        public DataTable SelectReportDataGroupByDepart(string OrgCode, string dateS, string dateE)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT 1 AS CARS,");
            sql.Append(" '~/CAR/CAR2/CAR2102_03.aspx?cardid='+ CCDD.Car_id +'&sdate=' +@dateS +'&edate=' +@dateE  AS LINKS,");

            // 部門名稱
            sql.Append(" F.Depart_name AS [Name],");

            // 使用時數
            sql.Append(" CONVERT(NUMERIC(18,2),SUM(DATEDIFF(MINUTE,C1.CODE_DESC1+':00',C2.CODE_DESC1+':00'))/60.0) AS [Hours], ");

            // 總使用時數=13*查詢條件天數
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) AS TCOUNT,");

            // 使用率=使用時數/總使用時數
            sql.Append(" CASE WHEN ");
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) =0 THEN 0 ");
            sql.Append(" ELSE ");
            sql.Append(" CONVERT(NUMERIC(18,2), ");
            sql.Append(" (SUM(DATEDIFF(MINUTE,C1.CODE_DESC1+':00',C2.CODE_DESC1+':00'))/60.0+0.0)/ ");
            sql.Append(" ( ");
            sql.Append(" (SELECT CODE_DESC1 FROM SYS_CODE C3 WHERE C3.CODE_SYS='015' AND C3.CODE_TYPE='010') * CAST(DATEDIFF(DAY,dbo.Roctoad(@dateS),dbo.Roctoad(@dateE)) AS INT) ");
            sql.Append(" )*100) END AS Usage, ");

            //  使用次數
            sql.Append(" Count(CCDD.Car_id) [Count] ");


            sql.Append(" FROM CAR_CarDispatch_main CCDM ");
            sql.Append(" INNER JOIN CAR_CarDispatch_det CCDD ON CCDM.Flow_id=CCDD.Flow_id ");
            sql.Append(" LEFT JOIN SYS_CODE C1 ON C1.CODE_NO=CCDD.Start_time AND C1.CODE_SYS='015' AND C1.CODE_TYPE='006' ");
            sql.Append(" LEFT JOIN SYS_CODE C2 ON C2.CODE_NO=CCDD.End_time AND C2.CODE_SYS='015' AND C2.CODE_TYPE='006' ");
            sql.Append(" LEFT JOIN fsc_org F ON F.Depart_id= CCDM.Unit_code ");
            sql.Append(" WHERE CCDM.OrgCode=@OrgCode AND CCDD.Dispatch_date BETWEEN @dateS AND @dateE AND F.Depart_name IS NOT NULL ");
            sql.Append(" GROUP BY F.Depart_name,CCDD.Car_id  ");

            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@dateS", dateS),
                new SqlParameter("@dateE", dateE),
                new SqlParameter("@OrgCode", OrgCode)
            };

            return Query(sql.ToString(), sp);
        }

        public DataTable CardList(string OrgCode, string carID, string sdate, string edate)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append(" LEFT(CAST(CCDD.Dispatch_date AS int)+19110000,4)+'-'+ ");
            sql.Append(" SUBSTRING(CAST(CAST(CCDD.Dispatch_date AS int)+19110000 AS VARCHAR(8)),5,2)+'-'+ ");
            sql.Append(" SUBSTRING(CAST(CAST(CCDD.Dispatch_date AS int)+19110000 AS VARCHAR(8)),7,2) AS DATES, ");
            sql.Append(" C1.CODE_DESC1+'~'+C2.CODE_DESC1 AS TIMES, ");
            sql.Append(" P1.User_name AS u1, ");
            sql.Append(" CCDM.car_delegate, ");
            sql.Append(" P2.User_name AS u2, ");
            sql.Append(" CCDM.Reason_desc, ");
            sql.Append(" CCDM.Destination_desc ");
            sql.Append(" FROM CAR_CarDispatch_main CCDM ");
            sql.Append(" INNER JOIN CAR_CarDispatch_det CCDD ON CCDM.Flow_id=CCDD.Flow_id AND CCDM.OrgCode=CCDD.OrgCode ");
            sql.Append(" LEFT JOIN FSC_Personnel P1 ON CCDM.User_id=P1.Id_card ");
            sql.Append(" LEFT JOIN FSC_Personnel P2 ON CCDM.User_id=P2.Id_card ");
            sql.Append(" LEFT JOIN SYS_CODE C1 ON C1.CODE_NO=CCDD.Start_time AND C1.CODE_SYS='015' AND C1.CODE_TYPE='006' ");
            sql.Append(" LEFT JOIN SYS_CODE C2 ON C2.CODE_NO=CCDD.End_time AND C2.CODE_SYS='015' AND C2.CODE_TYPE='006' ");
            sql.Append(" WHERE 1=1 ");
            sql.Append(" AND CCDM.OrgCode=@OrgCode AND CCDD.Car_id=@Car_id ");
            sql.Append(" AND CCDD.Dispatch_date>=@sdate and CCDD.Dispatch_date<=@edate ");
            sql.Append(" ORDER BY CCDD.Dispatch_date,CCDD.Start_time,CCDD.End_time ");

            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@Car_id", carID),
                new SqlParameter("@OrgCode", OrgCode),
                new SqlParameter("@sdate", sdate),
                new SqlParameter("@edate", edate)
            };

            return Query(sql.ToString(), sp);
        }
    }
}