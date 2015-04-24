using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using FSCPLM.Logic;

/// <summary>
/// Summary description for PRO1101
/// </summary>
namespace PRO.Logic
{
    public class PRO1101
    {
        private PRO1101DAO dao = null;
        private PRO_PropertyTran_det pptdDAO = null;
        private PRO_PropertyTran_main pptmDAO = null;
        public SACode saCode = null;

        public PRO1101()
        {
            dao = new PRO1101DAO();
            saCode = new SACode();
            pptdDAO = new PRO_PropertyTran_det();
            pptmDAO = new PRO_PropertyTran_main();
        }


        public DataTable GetSTOREROOM(string ACCUSER)
        {
            return dao.SelectSTOREROOM(ACCUSER);
        }

        public DataTable GetFAData(string ACCUSER, string STOREROOM){
            DataTable FAdt = dao.SelectFAData(ACCUSER, STOREROOM);
            DataTable pptddt = pptdDAO.GetApplyPropertyId();

            DataTable dt = new DataTable();
            dt = FAdt.Clone();

            if (pptddt != null && pptddt.Rows.Count > 0)
            {
                foreach (DataRow fadr in FAdt.Rows)
                {
                    bool isAdd = true;
                    foreach (DataRow ppsmdr in pptddt.Rows)
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

        public string Transfer(ref DataTable dt, string NewUnit_name, string NewKeeper_id, string NewKeeper_name, string NewLocation)
        {
            string msg = string.Empty;
            try
            {
                DataRow[] drs1 = dt.Select(string.Format(" FA01_ACCUSER <> '{0}' ", NewKeeper_name));//財產移轉申請-換保管人 
                DataRow[] drs2 = dt.Select(string.Format(" FA01_ACCUSER = '{0}' ", NewKeeper_name));//財產移轉申請-不換保管人
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
                    //財產移轉申請-資訊類-土污基金一萬元以上
                    foreach (DataRow drg3 in dtGroup3.Rows)
                    {
                        DataRow[] drs3 = dtGroup1.Select(string.Format(" FA01_KIND = '{0}' ", drg3["FA01_KIND"]));
                        DataRow[] formIds = dtFormCode.Select(string.Format("CODE_DESC1='財產移轉申請-換保管人-{0}'", drg3["FA01_KIND"]));
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
                            f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                            f.Reason = string.Format(LoginManager.UserName + "移轉財產加物品共{0}項", drs3.Length);
                            SYS.Logic.CommonFlow.AddFlow(f);

                            flowID = f.FlowId;
                            DataRow[] codes = dtKindCode.Select(string.Format("CODE_DESC1='{0}'", drg3["FA01_KIND"]));
                            if (codes.Length == 0)
                            {
                                msg += string.Format(@"{0}找不到對應代碼檔}\n", drg3["FA01_KIND"]);
                                continue;
                            }
                            //新增主檔
                            pptmDAO.Add(LoginManager.OrgCode, flowID, codes[0]["CODE_NO"].ToString(), NewUnit_name, NewKeeper_id,
                                         NewLocation, LoginManager.Depart_id , LoginManager.UserId, LoginManager.Account, DateTime.Now, "");
                            //新增明細
                            foreach (DataRow detail in dtGroup4.Rows)
                            {
                                pptdDAO.Add(LoginManager.OrgCode, flowID, detail["FA01_MASTNO"].ToString(), detail["FA01_CLSNO"].ToString(), detail["FA01_NAME"].ToString(),
                                            LoginManager.Depart_id, LoginManager.UserId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name), detail["FA01_LOCATION"].ToString(), "",
                                            detail["FA01_ACCUSER"].ToString(), NewUnit_name, NewKeeper_id, NewKeeper_name, NewLocation,
                                            "", "", detail["FA01_BUYDT"].ToString(), codes[0]["CODE_NO"].ToString(), "",
                                            "","" , LoginManager.Account, DateTime.Now);
                            }
                            trans.Complete();
                        }

                    }

                }

                if (dtGroup2 != null && dtGroup2.Rows.Count > 0)
                {
                    DataTable dtGroup3 = dtGroup2.DefaultView.ToTable(true, "FA01_KIND");
                    //財產移轉申請-非資訊類-本署一萬元以上
                    foreach (DataRow drg3 in dtGroup3.Rows)
                    {
                        DataRow[] drs3 = dtGroup2.Select(string.Format(" FA01_KIND = '{0}' ", drg3["FA01_KIND"]));
                        DataRow[] formIds = dtFormCode.Select(string.Format("CODE_DESC1='財產移轉申請-不換保管人-{0}'", drg3["FA01_KIND"]));
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
                            f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                            f.Reason = string.Format("財產移轉申請-不換保管人-{0}共{1}筆", drg3["FA01_KIND"], dtGroup2.Rows.Count);
                            SYS.Logic.CommonFlow.AddFlow(f);

                            flowID = f.FlowId;
                            DataRow[] codes = dtKindCode.Select(string.Format("CODE_DESC1='{0}'", drg3["FA01_KIND"]));
                            if (codes.Length == 0)
                            {
                                msg += string.Format(@"{0}找不到對應代碼檔}\n", drg3["FA01_KIND"]);
                                continue;
                            }
                            //新增主檔
                            pptmDAO.Add(LoginManager.OrgCode, flowID, codes[0]["CODE_NO"].ToString(), NewUnit_name, NewKeeper_id,
                                         NewLocation, "", "", LoginManager.UserId, DateTime.Now, "");
                            //新增明細
                            foreach (DataRow detail in dtGroup2.Rows)
                            {
                                pptdDAO.Add(LoginManager.OrgCode, flowID, detail["FA01_MASTNO"].ToString(), detail["FA01_CLSNO"].ToString(), detail["FA01_NAME"].ToString(),
                                            LoginManager.Depart_id, LoginManager.UserId , LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name), detail["FA01_LOCATION"].ToString(), "",
                                            detail["FA01_ACCUSER"].ToString(), NewUnit_name, NewKeeper_id, NewKeeper_name, NewLocation,
                                            "", "", detail["FA01_BUYDT"].ToString(), codes[0]["CODE_NO"].ToString(), "",
                                            "", "", LoginManager.UserId, DateTime.Now);
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