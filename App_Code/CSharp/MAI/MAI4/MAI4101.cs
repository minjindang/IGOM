using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MAI4101
/// </summary>
/// 

namespace FSCPLM.Logic
{
    public class MAI4101
    {

        public MaintainerMain mmDAO = null;
        public SACode saDAO = null;

	    public MAI4101()
	    {
            mmDAO = new MaintainerMain();
            saDAO = new SACode(); 
	    }

        public string Add(string MaintainerPhone_nos, string Maintainer_name, string Maintain_type, string MtItem_type, string MtUnit_code, string MtUser_id)
        {
            string msg = string.Empty;
            try
            {
                mmDAO.Add(LoginManager.OrgCode, MaintainerPhone_nos, Maintainer_name, Maintain_type, MtItem_type, LoginManager.UserId, DateTime.Now, MtUnit_code, MtUser_id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return msg;
        }

        public string Remove(string MaintainerPhone_nos) 
        {
            string msg = string.Empty;
            try
            {
                mmDAO.Remove(MaintainerPhone_nos, LoginManager.OrgCode);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string Modify(string MaintainerPhone_nos, string Maintainer_name, string Maintain_type, string MtItem_type, string MtUnit_code, string MtUser_id)
        {
            string msg = string.Empty;
            try
            {
                mmDAO.Modify(MaintainerPhone_nos, LoginManager.OrgCode, Maintainer_name, Maintain_type, MtItem_type, LoginManager.UserId, DateTime.Now, MtUnit_code, MtUser_id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        private string GetSACodeDesc(string key,ref DataTable dt)
        {
            var result = from a in dt.AsEnumerable()
                         where a.Field<string>("code_sys") + a.Field<string>("code_kind") + a.Field<string>("code_type") + a.Field<string>("code_no")  == key
                         select a.Field<string>("code_desc1") ;
            return result.FirstOrDefault();
        }

        public DataTable GetMtItem_type(string Maintain_type)
        {
            DataTable newDT = null;
            if ("001" == Maintain_type)//水電維修
            {
                newDT = saDAO.GetData("019", "008");
            }
            else //軟硬體維修
            {

                newDT = saDAO.GetData("020", "");
                newDT.DefaultView.RowFilter = " code_type <> '**' ";
                newDT = newDT.DefaultView.ToTable();
                newDT.Merge(saDAO.GetData("019", "007"));
                //newDT = saDAO.GetData("019", "019");
                //newDT.Merge(saDAO.GetData("020", "")); 
            }
            var results = from a in newDT.AsEnumerable()
                          select
                          new
                          {
                              CodeTitle = a.Field<string>("code_desc1"),
                              CodeValue = a.Field<string>("code_sys") + a.Field<string>("code_kind") + a.Field<string>("code_type") + a.Field<string>("code_no")
                          };
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CodeTitle"));
            dt.Columns.Add(new DataColumn("CodeValue"));
            foreach (var item in results)
            {
                DataRow dr = dt.NewRow();
                dr["CodeTitle"] = item.CodeTitle;
                dr["CodeValue"] = item.CodeValue;
                dt.Rows.Add(dr);
            }
            newDT = dt;
            return newDT;
        }

        public DataTable Get(string MaintainerPhone_nos, string MtUser_id, string Maintain_type, string MtItem_type, string MtUnit_code, ref string msg)
        {
            DataTable newDT = new DataTable();
            try
            {
                DataTable dt = mmDAO.GetAll(LoginManager.OrgCode, Maintain_type, MtItem_type, MtUnit_code, MtUser_id, MaintainerPhone_nos);
                DataTable dt01911 = saDAO.GetData("019", "007");
                dt01911.Merge(saDAO.GetData("019", "008"));
                dt01911.Merge(saDAO.GetData("020",""));
                if (dt != null && dt.Rows.Count > 0)
                {
                    newDT.Columns.Add(new DataColumn("MtUnit_codeName"));
                    newDT.Columns.Add(new DataColumn("MaintainerPhone_nos"));
                    newDT.Columns.Add(new DataColumn("Maintain_type"));
                    newDT.Columns.Add(new DataColumn("MtItem_type"));

                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow tempDR = dr;
                        DataRow newDR = newDT.NewRow();
                        newDR["MtUnit_codeName"] = CommonFun.SetDataRow(ref tempDR, "MtUnit_code") + " " + CommonFun.SetDataRow(ref tempDR, "Maintainer_name");
                        newDR["MaintainerPhone_nos"] = CommonFun.SetDataRow(ref tempDR, "MaintainerPhone_nos");
                        newDR["Maintain_type"] = saDAO.GetCodeDesc("019", "011", CommonFun.SetDataRow(ref tempDR, "Maintain_type").ToString());
                        string MtItem_types = CommonFun.SetDataRow(ref tempDR, "MtItem_type").ToString();
                        //MtItem_types = MtItem_types.Trim(';').Split(';');
                  
                        newDR["MtItem_type"] = MtItem_types.Trim(';').Split(';')
                                                .Select(i => i)
                                                .Aggregate((i, j) => GetSACodeDesc(i, ref dt01911) + "," + GetSACodeDesc(j, ref dt01911));
                        newDT.Rows.Add(newDR);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return newDT;
        }

      
    }
}