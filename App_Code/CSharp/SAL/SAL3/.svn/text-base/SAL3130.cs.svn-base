using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// SAL3118 的摘要描述
/// </summary>

namespace SALPLM.Logic
{
    public class SAL3130
    {
        private SAL3130DAO DAO;

        public SAL3130()
        {
            DAO = new SAL3130DAO();
        }        

        public DataTable GetBt02mData(String idCard)
        {
            FSC.Logic.Personnel p = new FSC.Logic.Personnel();
            String idno = p.GetColumnValue("id_number", idCard);
            String conn = ConfigurationManager.AppSettings["DBString_Synchronous01"].ToString();

            FSCPLM.Logic.CPABT02M bt02m = new FSCPLM.Logic.CPABT02M(conn);

            DataTable dt = bt02m.GetBT02MByB02IDNO(idno);

            return dt;
        }

        public DataTable GetQueryData(String orgcode, String departId, String idCard, String sendStatus)
        {
            return DAO.GetQueryData(orgcode, departId, idCard, sendStatus);
        }


        public String GetContent(int id)
        {
            SAL.Logic.PaySalChgNoticMain ps = new SAL.Logic.PaySalChgNoticMain();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            ps = ps.GetObject(id);
            if (ps == null)
                return "";

            //sb.Append("填單日期：xxx年xx月xx日");
            //sb.Append("異動人員：｛姓名｝");
            //sb.Append("異動時間：xxx年xx月xx日　時：分：秒");
            //sb.Append("備註：");
            //sb.Append("人事室核填");
            sb.Append("職員：").Append(ps.User_name).Append("(").Append(ps.Id_card).Append(")").Append("\n");
            sb.Append("暫支俸額").Append("\n");

            if (ps.Employee_type.Equals("1"))
            {
                sb.Append("官等：").Append(ps.L3_code).Append("\n");
                sb.Append("職等：").Append(ps.L1_code).Append("\n");
                sb.Append("奉階：").Append(ps.L2_code).Append("\n");
                sb.Append("俸(薪)：").Append(ps.PtbPoint_nos).Append("點").Append(ps.Ptb_amt).Append("元").Append("\n");
                sb.Append("\n");
                sb.Append("代扣款起始日期及每月代扣金額").Append("\n");
                sb.Append("全民健保：").Append("\n");
                sb.Append(ps.Fin_month).Append("月").Append(ps.Fin_amt).Append("元").Append("\n");
                sb.Append(ps.Fin_people).Append("眷屬").Append(ps.Fin_people_amt).Append("元").Append("\n");
                sb.Append("退撫基金：").Append("\n");
                sb.Append(ps.Fund_month).Append("月").Append(ps.Fund_day).Append("日").Append(ps.Fund_amt).Append("元").Append("\n");
                sb.Append("公保：").Append("\n");
                sb.Append(ps.Safety_month).Append("月").Append(ps.Safety_day).Append("日").Append(ps.Salary_amt).Append("元").Append("\n");
                sb.Append("福利互助：").Append("\n");
                sb.Append(ps.Mutual_month).Append("月").Append(ps.Mutual_amt).Append("元").Append("\n");
                sb.Append("房屋貸款：").Append("\n");
                if (ps.House_type.Equals("1")) sb.Append("有").Append("\n");
                else sb.Append("無").Append("\n");
                    
            }
            else
            {
                sb.Append("薪點：").Append(ps.Salary_point).Append("點").Append(ps.Salary_amt).Append("元").Append("\n");
                sb.Append("折合率：").Append(ps.Rate_nos).Append("\n");
                sb.Append("每月報酬：").Append(ps.Safety_month).Append("元").Append("\n");
                sb.Append("\n");
                sb.Append("代扣款起始日期及每月代扣金額").Append("\n");
                sb.Append("全民健保：").Append("\n");
                sb.Append(ps.Fin_month).Append("月").Append(ps.Fin_amt).Append("元").Append("\n");
                sb.Append(ps.Fin_people).Append("眷屬").Append(ps.Fin_people_amt).Append("元").Append("\n");
                sb.Append("離職儲金：").Append("\n");
                sb.Append(ps.Fund_month).Append("月").Append(ps.Fund_day).Append("日").Append(ps.Fund_amt).Append("元").Append("\n");
                sb.Append("勞保：").Append("\n");
                sb.Append(ps.Safety_month).Append("月").Append(ps.Safety_day).Append("日").Append(ps.Salary_amt).Append("元").Append("\n");
            }
            
            sb.Append("主管或專業技術加給：").Append("\n");
            if(ps.Head_post_plus.Equals("1")) sb.Append("主管職務加給").Append("\n");
            if(ps.General_prof_plus.Equals("1")) sb.Append("一般公務人員專業加給").Append("\n");
            if(ps.Enviprotec_prof_plus.Equals("1")) sb.Append("環保人員專業加給").Append("\n");
            if(ps.Operator_prof_plus.Equals("1")) sb.Append("電子作業人員專業加給").Append("\n");
            if(ps.East_taiwan_plus.Equals("1")) sb.Append("東台加給").Append("\n");

            if (!String.IsNullOrEmpty(ps.Natimajproj_post_plus))
            {
                sb.Append("簡任國家重大工程職務加給").Append("\n");
                sb.Append("薦任國家重大工程職務加給").Append("\n");
                sb.Append("委任國家重大工程職務加給").Append("\n");
            }
            if (ps.Technical_staff.Equals("1"))
            {
                sb.Append("技術人員").Append("\n");
            }
            else if (ps.Technical_staff.Equals("2"))
            {
                sb.Append("行政人員").Append("\n");
            }

            return sb.ToString();
        }
    }
}