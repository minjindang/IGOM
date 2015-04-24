using FSC.Logic;
using FSCPLM.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for SAL1103
/// </summary>

namespace SAL.Logic
{
    public class SAL1103
    {
        public Personnel personnelDAO = null;
        public SAL_EDU_Setting sesDAO = null;
        public SAL_SAPARAMETER ssmDAO = null;
        private SAL1103DAO dao = null;
        private SAL_EDU_fee sefmDAO = null;
        private SAL_EDU_feeDtl sefdDAO = null; 

        public SAL1103()
	    {
            personnelDAO = new Personnel();
            sesDAO = new SAL_EDU_Setting();
            ssmDAO = new SAL_SAPARAMETER();
            dao = new SAL1103DAO();
            sefmDAO = new SAL_EDU_fee();
            sefdDAO = new SAL_EDU_feeDtl();
	    }

        public string GetLastestFee_source()
        {
            DataTable dtMain = sefmDAO.GetAll(LoginManager.OrgCode,LoginManager.UserId,"");
            if (dtMain != null && dtMain.Rows.Count > 0)
            {
                return dtMain.Rows[0]["Fee_source"].ToString();
            }
            return "001";
        }

        public bool CheckChildFeeExist(string Apply_yy, string Period_type, string Child_id)
        {
            DataTable dtFee = dao.SelectChildFeeInfo(Apply_yy, Period_type, Child_id);

            if (dtFee.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetLastestFee(string Apply_yy, string Period_type)
        {
            return dao.SelectvLastestFee(Apply_yy, Period_type);
        }

        public string canUse(ref string AcademicYear, ref string Semester)
        {
            string msg = string.Empty;
            string Employee_type = personnelDAO.GetColumnValue("Employee_type", LoginManager.UserId);
            switch (Employee_type)
            {
                case "1":
                case "3":
                case "8":
                case "11":
                    break;
                default:
                    msg += @"員工類別為 正式人員、技工工友、司機、駐衛警 方可使用\n";
                    break;
            }
            DataTable dt = sesDAO.GetAll(LoginManager .OrgCode,"001");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string now = CommonFun.getYYYMMDD() + DateTime.Now.ToString("hhmm");
                AcademicYear = dr["AcademicYear"].ToString();
                Semester = dr["Semester"].ToString();
                if (dr["Status"].ToString() != "Y" ||
                    Convert.ToInt64(now) < Convert.ToInt64((dr["Apply_sDate"].ToString() + dr["Apply_sTime"].ToString())) ||
                    Convert.ToInt64(now) > Convert.ToInt64((dr["Apply_eDate"].ToString() + dr["Apply_eTime"].ToString())))
                {
                    msg += @"此作業鎖定 不可申請\n";
                }
                
            }
            return msg;
        }

        public string Add(string Depart_id, string Id_card, string Apply_date,string Period_type, string fguid, DataTable dtDetail)
        {
            string flowID = string.Empty;
            FSC.Logic.Personnel p = new Personnel().GetObject(Id_card);
            if (p == null) throw new FlowException("無申請人資料!");

            using (TransactionScope trans = new TransactionScope())
            {
                string Fee_source = GetLastestFee_source();
                SYS.Logic.Flow f = new SYS.Logic.Flow();
                f.Orgcode = LoginManager.OrgCode;
                f.DepartId = Depart_id;
                f.ApplyPosid = p.TitleNo;
                f.ApplyIdcard = Id_card;
                f.ApplyName = p.UserName;
                f.FormId = "002005";
                f.WriterIdcard = LoginManager.UserId;
                f.WriterDepartid = LoginManager.Depart_id;
                f.WriterOrgcode = LoginManager.OrgCode;
                f.WriterPosid = LoginManager.TitleNo;
                f.WriteTime = DateTime.Now;
                f.FlowId = new SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId);
                f.Reason = string.Format("{0}年度{1}學期,共申請{2}筆資料", Apply_date, Period_type, dtDetail.Rows.Count);
                f.Budget_code = Fee_source;
                SYS.Logic.CommonFlow.AddFlow(f);

                flowID = f.FlowId;

                //新增主檔
                int mainID = sefmDAO.Add(flowID, Id_card, Depart_id, CommonFun.getYYYMMDD(DateTime.Now),
                    Fee_source, Apply_date, Period_type, "", LoginManager.OrgCode, LoginManager.UserId, DateTime.Now, LoginManager.UserId, LoginManager.Depart_id);
            
                string yy = flowID.Substring(3, 2);
                string Filepath = HttpContext.Current.Server.MapPath(@"~\fileupload\Attachment\" + yy + @"\") + flowID;
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }


                foreach (DataRow dr in dtDetail.Rows)
                {

                    String fileName = dr["File_name"].ToString();
                    String fileSize = dr["File_size"].ToString();
                    String fileType = dr["File_type"].ToString();
                    String guid = dr["Guid"].ToString();
                    int attId = CommonFun.getInt(dr["Attach_id"].ToString());

                    if (!string.IsNullOrEmpty(guid))
                    {
                        SYS.Logic.Attachment att = new SYS.Logic.Attachment();
                        //if (!string.IsNullOrEmpty(hfAttachmentId.Value) && Convert.ToInt32(hfAttachmentId.Value) > 0)
                        //{
                        //    att.DeleteAttachById(Convert.ToInt32(hfAttachmentId.Value));
                        //}

                        att.DeleteAttachById(attId);

                        string realname = guid;
                        if(fileName.Contains("."))
                            realname +=  "." + fileName.Split('.')[1];

                        att.Flow_id = flowID;
                        att.File_name = fileName;
                        att.File_size = fileSize;
                        att.File_type = fileType;
                        att.File_path = Filepath;
                        att.File_real_name = realname;
                        att.Upload_userid = LoginManager.UserId;
                        attId = att.InsertAttach();

                        string tempFilePath = HttpContext.Current.Server.MapPath(string.Format("~/fileupload/Attachment/temp/{0}/{1}/", fguid, guid));
                        FileInfo finfo = new FileInfo(tempFilePath + fileName);
                        if (finfo != null)
                        {
                            finfo.MoveTo(Path.Combine(Filepath, realname));
                        }
                    }


                    sefdDAO.Add(mainID, dr["Child_id"].ToString(), dr["Child_name"].ToString(), dr["ChildBirth_date"].ToString(), dr["School_type"].ToString(),
                        dr["School_name"].ToString(), "", Convert.ToInt32(dr["Study_nos"]), Convert.ToInt32(dr["StudyLimit_nos"]), Convert.ToInt32(dr["Apply_amt"]),
                        LoginManager.OrgCode, LoginManager.UserId, DateTime.Now, attId);


                }
                trans.Complete();
            }

            return flowID;

        }

        public void update(string Apply_date, string Period_type, string orgcode, string flow_id, DataTable dtDetail)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                string Fee_source = GetLastestFee_source();
                SYS.Logic.Flow f = new SYS.Logic.Flow().GetObject(orgcode, flow_id);               
                f.Reason = string.Format("{0}年度{1}學期,共申請{2}筆資料", Apply_date, Period_type, dtDetail.Rows.Count);
                f.Budget_code = Fee_source;                
                f.CaseStatus = 2;
                f.Update();

                //更新主檔
                int mainID = sefmDAO.Update(LoginManager.OrgCode, flow_id);

                //刪除舊有明細檔
                sefdDAO.DeleteByFlowId(flow_id);

                string yy = flow_id.Substring(3, 2);
                string Filepath = HttpContext.Current.Server.MapPath(@"~\fileupload\Attachment\" + yy + @"\") + flow_id;
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }


                ArrayList attIdlist = new ArrayList();                

                //新增明細檔
                foreach (DataRow dr in dtDetail.Rows)
                {

                    String fileName = dr["File_name"].ToString();
                    String fileSize = dr["File_size"].ToString();
                    String fileType = dr["File_type"].ToString();
                    String guid = dr["Guid"].ToString();
                    int attId = CommonFun.getInt(dr["Attach_id"].ToString());
                    
                    if (!string.IsNullOrEmpty(guid))
                    {
                        SYS.Logic.Attachment att = new SYS.Logic.Attachment();
                        att.DeleteAttachById(attId);

                        string realname = guid;
                        if (fileName.Contains("."))
                            realname += "." + fileName.Split('.')[1];

                        att.Flow_id = flow_id;
                        att.File_name = fileName;
                        att.File_size = fileSize;
                        att.File_type = fileType;
                        att.File_path = Filepath;
                        att.File_real_name = realname;
                        att.Upload_userid = LoginManager.UserId;
                        attId = att.InsertAttach();

                        attIdlist.Add(attId);

                        string tempFilePath = HttpContext.Current.Server.MapPath(string.Format("~/fileupload/Attachment/temp/{0}/{1}/", flow_id, guid));
                        FileInfo finfo = new FileInfo(tempFilePath + fileName);
                        if (finfo != null)
                        {
                            finfo.MoveTo(Path.Combine(Filepath, realname));
                        }
                    }


                    sefdDAO.Add(mainID, dr["Child_id"].ToString(), dr["Child_name"].ToString(), dr["ChildBirth_date"].ToString(), dr["School_type"].ToString(),
                        dr["School_name"].ToString(), "", Convert.ToInt32(dr["Study_nos"]), Convert.ToInt32(dr["StudyLimit_nos"]), Convert.ToInt32(dr["Apply_amt"]),
                        LoginManager.OrgCode, LoginManager.UserId, DateTime.Now, attId);
                }

                if(attIdlist.Count>0)
                    dao.DeleteAttach(flow_id, attIdlist);

                trans.Complete();
            }

        }

        public DataTable getDataByOrgFid(string Orgcode, string flow_id)
        {
            return dao.getDataByOrgFid(Orgcode, flow_id);
        }
    }
}