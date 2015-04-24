using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MAI.Logic
{
    /// <summary>
    /// MAI1101 的摘要描述
    /// </summary>
    public class MAI1101
    {
        private MAI1101DAO DAO;

        public enum Maintainer_type : int
        {
            Firm = 1,
            UnderTaker = 2
        }

        public MAI1101()
        {
            DAO = new MAI1101DAO();
        }

        public void ChangeFlow(String orgcode, String flowId, String mKind, String mType, int merType, int mainId, String comment)
        {
            FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
            SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
            SYS.Logic.FlowNext fn = new SYS.Logic.FlowNext();
            FSC.Logic.Personnel p = new FSC.Logic.Personnel();
            FSC.Logic.DepartEmp d = new FSC.Logic.DepartEmp();
            MAI.Logic.MaintainMain main = new MAI.Logic.MaintainMain();


            DataRow r = code.GetRow("020", mKind, mType);

            if (r != null)
            {
                String idCard = "";
                String serviceType = "0";
                if (merType == (int)Maintainer_type.Firm)
                    idCard = r["code_remark2"].ToString();
                if (merType == (int)Maintainer_type.UnderTaker)
                    idCard = r["code_remark1"].ToString();

                fn.Orgcode = orgcode;
                fn.FlowId = flowId;

                p = p.GetObject(idCard);

                if (p != null)
                {
                    fn.NextIdcard = p.IdCard;
                    fn.NextPosid = p.TitleNo;
                    fn.NextName = p.UserName;
                }

                if (p.EmployeeType == "9")
                    serviceType = "1";

                DataTable dt = d.GetDataByServiceType(idCard, serviceType);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fn.NextOrgcode = dt.Rows[0]["Orgcode"].ToString();
                    fn.NextDepartid = dt.Rows[0]["Depart_id"].ToString();
                }

                fd.Orgcode = orgcode;
                fd.FlowId = flowId;
                fd.LastOrgcode = LoginManager.OrgCode;
                fd.LastDepartid = LoginManager.Depart_id;
                fd.LastPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                fd.LastIdcard = LoginManager.UserId;
                fd.LastName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                fd.AgreeFlag = 1;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = comment;
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);
                
                SYS.Logic.CommonFlow.TransFlow(fd, fn);

                main.Update(mKind, mType, mainId);

           
            }
        }

        public void DividFlow(String orgcode, String flowId, String mKind, String mType, int merType, int mainId)
        {
            String formId = "";
            FSCPLM.Logic.SACode code = new FSCPLM.Logic.SACode();
            FSC.Logic.Personnel p = new FSC.Logic.Personnel();
            FSC.Logic.DepartEmp d = new FSC.Logic.DepartEmp();
            SYS.Logic.Flow f = new SYS.Logic.Flow();
            SYS.Logic.FlowNext fn = new SYS.Logic.FlowNext();
            SYS.Logic.FlowDetail fd = new SYS.Logic.FlowDetail();
            MAI.Logic.MaintainMain main = new MaintainMain();
            MAI.Logic.MaintainHandle handle = new MaintainHandle();
            
            DataRow r = code.GetRow("020", "**", mKind);
            if (r != null)
                formId = r["code_remark1"].ToString();  //get form_id

            f = f.GetObject(orgcode, flowId);
            String newFlowid = new SYS.Logic.FlowId().GetFlowId(orgcode, formId);

                       
            r = code.GetRow("020", mKind, mType);
            if (r != null)
            {
                f.FlowId = newFlowid;
                f.Insert();     //add new flow
                
                List<SYS.Logic.FlowDetail> fdList = fd.GetObjects(orgcode, flowId);
                foreach (SYS.Logic.FlowDetail det in fdList)
                {
                    det.FlowId = newFlowid;
                    det.InsertFlowDetail(); //add new flow_detail
                }

                List<SYS.Logic.FlowNext> fnList = fn.GetObjects(orgcode, flowId);
                foreach (SYS.Logic.FlowNext n in fnList)
                {
                    n.FlowId = newFlowid;
                    n.Insert();
                }
                
                String idCard = "";
                String serviceType = "0";
                if (merType == (int)Maintainer_type.Firm)
                    idCard = r["code_remark2"].ToString();
                if (merType == (int)Maintainer_type.UnderTaker)
                    idCard = r["code_remark1"].ToString();

                fn.Orgcode = orgcode;
                fn.FlowId = newFlowid;

                p = p.GetObject(idCard);

                if (p != null)
                {
                    fn.NextIdcard = p.IdCard;
                    fn.NextPosid = p.TitleNo;
                    fn.NextName = p.UserName;

                    if (p.EmployeeType == "9")
                        serviceType = "1";
                    
                    DataTable dt = d.GetDataByServiceType(idCard, serviceType);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        fn.NextOrgcode = dt.Rows[0]["Orgcode"].ToString();
                        fn.NextDepartid = dt.Rows[0]["Depart_id"].ToString();
                    }
                }
                else 
                {
                    throw new FlowException("查無人員資料!");
                }
                
                fd.Orgcode = orgcode;
                fd.FlowId = newFlowid;
                fd.LastOrgcode = LoginManager.OrgCode;
                fd.LastDepartid = LoginManager.Depart_id;
                fd.LastPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no);
                fd.LastIdcard = LoginManager.UserId;
                fd.LastName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
                fd.AgreeFlag = 1;
                fd.AgreeTime = DateTime.Now;
                fd.Comment = "";
                fd.ChangeDate = DateTime.Now;
                fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account);

                SYS.Logic.CommonFlow.TransFlow(fd, fn);
            }
            
            main = main.GetObject(orgcode, flowId);

            if (main != null)
            {
                main.Maintain_kind = mKind;
                main.Maintain_type = mType;
                main.Flow_id = f.FlowId;
                main.Insert();

                handle = handle.GetObject(mainId);  // get old handle
                if (handle != null)
                {
                    handle.Main_id = main.Id;   //replace main_id
                    handle.Insert();
                }
            }

        }
        
        public DataTable GetDataByExt(String ext)
        {
            return DAO.GetDataByExt(ext);
        }


        public DataTable GetExt(String idCard)
        {
            return DAO.GetExt(idCard);
        }
    }

}