using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PRO1102
/// </summary>
namespace PRO.Logic
{
    public class PRO1102
    {
        private PRO1102DAO dao = null;
        private PRO_PropertyScrap_main ppsmDAO = null;
        public SACode saCode = null;

        public PRO1102()
        {
            dao = new PRO1102DAO();
            saCode = new SACode();
            ppsmDAO = new PRO_PropertyScrap_main();
        }

        public DataTable GetSTOREROOM(string ACCUSER)
        {
            return dao.SelectSTOREROOM(ACCUSER);
        }

        public DataTable GetFAData(string ACCUSER, string STOREROOM)
        {
            DataTable FAdt =  dao.SelectFAData(ACCUSER, STOREROOM);
            DataTable ppsmdt = ppsmDAO.GetApplyPropertyId();

            //WHERE  FA01_MASTNO not in (  select distinct Property_id from PRO_PropertyScrap_main a left join SYS_Flow b on a.Flow_id = b.Flow_id where b.Case_status in ('0','1','2'))
            DataTable dt = new DataTable();
            dt = FAdt.Clone();

            if (ppsmdt != null && ppsmdt.Rows.Count > 0)
            {
                foreach (DataRow fadr in FAdt.Rows)
                {
                    bool isAdd = true;
                    foreach (DataRow ppsmdr in ppsmdt.Rows)
                    {
                        if (fadr["FA01_MASTNO"].ToString() == ppsmdr["Property_id"].ToString())
                            isAdd = false;
                    }

                    if (isAdd)
                        dt.ImportRow(fadr);
                }
            }
            else
                dt = FAdt;
            return dt;
        }

        public DataTable GetDataByOrgFid(string Orgcode, string flow_id)
        {
            return dao.SelectDataByOrgFid(Orgcode, flow_id);
        }

        public string Scrapped(ref DataTable dt, string ScrapReason_type, string orgcode, string flow_id)
        {
            string msg = string.Empty;
            try
            {
                //若Property_clsno的開頭為314或60114-20，則LEAVE_TYPE=''：其他LEAVE_TYPE='',
                DataRow[] drs1 = dt.Select(" FA01_CLSNO like '314*' OR FA01_CLSNO like '60114-20*' ");//資訊類
                DataRow[] drs2 = dt.Select(" FA01_CLSNO not like '314*' AND FA01_CLSNO not like '60114-20*' ");//非資訊類
                DataTable dtGroup1 = null;
                DataTable dtGroup2 = null;
                if (drs1 != null && drs1.Length > 0)
                {
                    dtGroup1 = drs1.CopyToDataTable();
                }
                if (drs2 != null && drs2.Length > 0)
                {
                    dtGroup2 = drs2.CopyToDataTable();
                }
                DataTable dtKindCode = saCode.GetData("016", "006");
                DataTable dtFormCode = saCode.GetData("024", "004");
                if (dtGroup1 != null && dtGroup1.Rows.Count > 0)
                {
                    DataTable dtGroup3 = dtGroup1.DefaultView.ToTable(true, "FA01_KIND");
                    //財產報廢申請-資訊類-土污基金一萬元以上
                    foreach (DataRow drg3 in dtGroup3.Rows)
                    {
                        DataRow[] drs3 = dtGroup1.Select(string.Format(" FA01_KIND = '{0}' ", drg3["FA01_KIND"]));
                        DataRow[] formIds = dtFormCode.Select(string.Format("CODE_DESC1='財產報廢申請-資訊類-{0}'", drg3["FA01_KIND"]));
                        if (formIds.Length == 0)
                        {
                            msg += string.Format(@"{0}找不到流程對應代碼檔}\n", drg3["FA01_KIND"]);
                            continue;
                        }
                        string formId = formIds[0]["CODE_TYPE"].ToString() + formIds[0]["CODE_NO"].ToString();
                        DataTable dtGroup4 = null;
                        if (drs3 != null && drs3.Length > 0)
                        {
                            dtGroup4 = drs3.CopyToDataTable();
                        }

                        string flowID = string.Empty;
                        //flowID = new Random().Next(1000000).ToString().PadLeft(7,'0');
                        using (TransactionScope trans = new TransactionScope())
                        {
                            SYS.Logic.Flow f = new SYS.Logic.Flow();
                            f.Orgcode = LoginManager.OrgCode;
                            f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                            f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                            f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                            f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                            f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                            f.FormId = formId;
                            //f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                            string reason = string.Format("財產報廢申請-資訊類-{0}共{1}筆", drg3["FA01_KIND"], dtGroup4.Rows.Count);
                            //SYS.Logic.CommonFlow.AddFlow(f);

                            if (string.IsNullOrEmpty(flow_id))
                            {
                                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                                f.Reason = reason;
                                SYS.Logic.CommonFlow.AddFlow(f);
                            }
                            else
                            {
                                f = new SYS.Logic.Flow().GetObject(orgcode, flow_id);
                                f.Reason = reason;
                                f.CaseStatus = 2;
                                f.Update();

                                ppsmDAO.RemoveByFid(flow_id);
                            }

                            flowID = f.FlowId;
                            foreach (DataRow dr in dtGroup4.Rows)
                            {
                                DataRow[] codes = dtKindCode.Select(string.Format("CODE_DESC1='{0}'", dr["FA01_KIND"]));
                                if (codes.Length == 0)
                                {
                                    msg += string.Format(@"{0}找不到對應代碼檔}\n", dr["FA01_KIND"]);
                                    continue;
                                }
                                ppsmDAO.Add(LoginManager.OrgCode, flowID, dr["FA01_MASTNO"].ToString(), dr["FA01_CLSNO"].ToString(), LoginManager.Depart_id , LoginManager.UserId , 
                                    dr["FA01_NAME"].ToString(),
                                    codes[0]["CODE_NO"].ToString(), dr["FA01_LOCATION"].ToString(), Convert.ToDouble(dr["FA02_RANGE"]), dr["FA01_BUYDT"].ToString(),
                                    dr["FA02_DELDT"].ToString(), CommonFun.getYYYMMDD(), "", LoginManager.UserId, DateTime.Now);
                            }
                            trans.Complete();
                        }
                         
                    }
                    
                }

                if (dtGroup2 != null && dtGroup2.Rows.Count > 0)
                {
                    DataTable dtGroup3 = dtGroup2.DefaultView.ToTable(true, "FA01_KIND");
                    //財產報廢申請-非資訊類-本署一萬元以上
                    foreach (DataRow drg3 in dtGroup3.Rows)
                    {
                        DataRow[] drs3 = dtGroup2.Select(string.Format(" FA01_KIND = '{0}' ", drg3["FA01_KIND"]));
                        DataRow[] formIds = dtFormCode.Select(string.Format("CODE_DESC1='財產報廢申請-非資訊類-{0}'", drg3["FA01_KIND"]));
                        if (formIds.Length == 0)
                        {
                            msg += string.Format(@"{0}找不到流程對應代碼檔\n", drg3["FA01_KIND"]);
                            continue;
                        }
                        string formId = formIds[0]["CODE_TYPE"].ToString() + formIds[0]["CODE_NO"].ToString();
                        DataTable dtGroup4 = null;
                        if (drs3 != null && drs3.Length > 0)
                        {
                            dtGroup4 = drs3.CopyToDataTable();
                        }
                        string flowID = string.Empty;
                        //flowID = new Random().Next(1000000).ToString().PadLeft(7,'0');
                        using (TransactionScope trans = new TransactionScope())
                        {
                            SYS.Logic.Flow f = new SYS.Logic.Flow();
                            f.Orgcode = LoginManager.OrgCode;
                            f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                            f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                            f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
                            f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                            f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type);
                            f.FormId = formId;
                            //f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                            f.Reason = string.Format("財產報廢申請-非資訊類-{0}共{1}筆", drg3["FA01_KIND"], dtGroup4.Rows.Count);
                            //SYS.Logic.CommonFlow.AddFlow(f);

                            if (string.IsNullOrEmpty(flow_id))
                            {
                                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                                SYS.Logic.CommonFlow.AddFlow(f);
                            }
                            else
                            {
                                f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode);
                                f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id);
                                f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                                f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                                f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                                f.WriteTime = DateTime.Now;
                                f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                                f.FlowId = flow_id;
                                f.CaseStatus = 2;
                                f.Update();

                                ppsmDAO.RemoveByFid(flow_id);

                            }

                            flowID = f.FlowId;


                            foreach (DataRow dr in dtGroup4.Rows)
                            {
                                DataRow[] codes = dtKindCode.Select(string.Format("CODE_DESC1='{0}'", dr["FA01_KIND"]));
                                if (codes.Length == 0)
                                {
                                    msg += string.Format(@"{0}找不到對應代碼檔}\n", dr["FA01_KIND"]);
                                    continue;
                                }
                                ppsmDAO.Add(LoginManager.OrgCode, flowID, dr["FA01_MASTNO"].ToString(), dr["FA01_CLSNO"].ToString(), LoginManager.Depart_id, LoginManager.UserId , dr["FA01_NAME"].ToString(),
                                    codes[0]["CODE_NO"].ToString(), dr["FA01_LOCATION"].ToString(), Convert.ToDouble(dr["FA02_RANGE"]), dr["FA01_BUYDT"].ToString(),
                                    dr["FA02_DELDT"].ToString(), CommonFun.getYYYMMDD(), ScrapReason_type, LoginManager.UserId, DateTime.Now);
                            }
                            trans.Complete();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }

    }
}