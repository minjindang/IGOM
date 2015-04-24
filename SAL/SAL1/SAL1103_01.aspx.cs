using FSCPLM.Logic;
using SAL.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SAL_SAL1_SAL1103_01 : BaseWebForm
{
    SAL1103 dao = new SAL1103();

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string AcademicYear = string.Empty;
            string Semester = string.Empty;
            string msg = dao.canUse(ref AcademicYear, ref Semester);
            if (!string.IsNullOrEmpty(msg))
            {
                Page p = this.Page;
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
                this.btnAdd.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnSubmit.Enabled = false;
            }
            else
            {
                UcDDLDepart.Orgcode = LoginManager.OrgCode;
                UcDDLDepart.SelectedValue = LoginManager.Depart_id;

                UcDDLMember.Orgcode = LoginManager.OrgCode;
                UcDDLMember.DepartId = UcDDLDepart.SelectedValue;
                UcDDLMember.SelectedValue = LoginManager.UserId;
                
                if (LoginManager.RoleId.IndexOf("Personnel") < 0)
                {
                    UcDDLDepart.Enabled = false;
                    UcDDLMember.Enabled = false;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    ShowReSendData();
                    this.btnSubmit.Text = "確認";
                    hfFlow_id.Value = Request.QueryString["fid"];
                    btnBack.Visible = true;
                }
                else
                {
                    SetInitialRow();
                    lblAcademicYear.Text = AcademicYear;
                    lblSemester.Text = Semester;
                    hfFlow_id.Value = Guid.NewGuid().ToString();
                }
            }
            //ucSchool_type.DDL.Items.Insert(0, new ListItem("請選擇", "-1"));
            ucSchool_type.DDLDefaultValue = true;
            //ucSchool_type.Rebind();

            //DataTable dt = (DataTable)ucSchool_type.DDL.DataSource;
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    calApply_amt(dt.Rows[0]["Code_no"].ToString());
            //}
            //hfFlow_id.Value = Guid.NewGuid().ToString();
        }
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("User_name"));
        dt.Columns.Add(new DataColumn("Child_name"));
        dt.Columns.Add(new DataColumn("Child_id"));
        dt.Columns.Add(new DataColumn("ChildBirth_date"));
        dt.Columns.Add(new DataColumn("Apply_date"));
        dt.Columns.Add(new DataColumn("Apply_yy"));
        dt.Columns.Add(new DataColumn("Period_type"));
        dt.Columns.Add(new DataColumn("School_name"));
        dt.Columns.Add(new DataColumn("School_type"));
        dt.Columns.Add(new DataColumn("School_type_name"));
        dt.Columns.Add(new DataColumn("StudyLimit_nos"));
        dt.Columns.Add(new DataColumn("Study_nos"));
        dt.Columns.Add(new DataColumn("Guid"));
        dt.Columns.Add(new DataColumn("File_name"));
        dt.Columns.Add(new DataColumn("File_size"));
        dt.Columns.Add(new DataColumn("File_type"));
        dt.Columns.Add(new DataColumn("Apply_amt", typeof(System.Int32)));
        dt.Columns.Add(new DataColumn("Attach_id", typeof(System.Int32)));

        ViewState["CurrentTable"] = dt;

        this.GridViewA.DataSource = dt;
        this.GridViewA.DataBind();
    }

    private void ShowReSendData()
    {
        DataTable dt = new SAL1103().getDataByOrgFid(Request.QueryString["org"], Request.QueryString["fid"]);

        if (dt != null && dt.Rows.Count > 0)
        {
            lblAcademicYear.Text = dt.Rows[0]["Apply_yy"].ToString();
            lblSemester.Text = dt.Rows[0]["Period_type"].ToString();
            hfFlow_id.Value = Guid.NewGuid().ToString(); //dt.Rows[0]["flow_id"].ToString();
        
           
            ViewState["CurrentTable"] = dt;

            this.GridViewA.DataSource = dt;
            this.GridViewA.DataBind();
        }
    }

    private string CheckData(string AcademicYear, string Semester, string Child_id, bool isSubmit)
    {
        string msg = string.Empty;

        if (dao.CheckChildFeeExist(AcademicYear, Semester, Child_id))
        {
            msg += string.Format("申請子女姓名{0}，本學期已申請過，不可重覆申請!\\n", Child_id);
        }

        if (!isSubmit)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow[] drs = dtCurrentTable.Select(string.Format(" Child_id = '{0}' ", Child_id));
            if (drs.Length > 0)
            {
                msg += string.Format("已有身分證字號{0}之申請資料，不可重複申請!\\n", Child_id);
            }
        }

        return msg;
    }

    private void AddNewRowToGrid()
    {
        if ((ViewState["CurrentTable"] != null))
        {
            Page p = this.Page;
            string Child_name = string.Empty;
            string msg = CheckData(this.lblAcademicYear.Text, this.lblSemester.Text, this.txtChild_id.Text,false);

            if (!string.IsNullOrEmpty(msg))
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
                return;
            }

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow dr = dtCurrentTable.NewRow();
            SACode saCode = new SACode();

            dr["User_name"] = new FSC.Logic.Personnel().GetColumnValue("User_name", UcDDLMember.SelectedValue);//LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name);
            dr["Child_name"] = txtChild_name.Text;
            dr["ChildBirth_date"] = ucChildBirth_date.Text;
            dr["Child_id"] = txtChild_id.Text;
            dr["Apply_date"] = CommonFun.getYYYMMDD();
            dr["Apply_yy"] = lblAcademicYear.Text;
            dr["Period_type"] = lblSemester.Text;
            dr["School_name"] = txtSchool_name.Text;
            dr["School_type"] = ucSchool_type.Code_no;
            dr["School_type_name"] = saCode.GetCodeDesc("006", "011", ucSchool_type.Code_no);
            dr["StudyLimit_nos"] = txtStudyLimit_nos.Text;
            dr["Study_nos"] = txtStudy_nos.Text;
            dr["Apply_amt"] = Convert.ToInt32(txtApply_amt.Text);

            if (fuAttachment.HasFile)
            {
                string guid = Guid.NewGuid().ToString();
                dr["Guid"] = guid;
                int attsize = CommonFun.getInt(ConfigurationManager.AppSettings["attsize"].ToString());

                if (fuAttachment.PostedFile.ContentLength > attsize * 1000)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "文件大小不能超過" + attsize.ToString() + "k!", "", "");
                    return;
                }

                FileInfo fi = new FileInfo(fuAttachment.PostedFile.FileName);

                bool ismatch = false;
                string[] attkinds = ConfigurationManager.AppSettings["attkind"].ToString().Split('|');
                foreach (string kind in attkinds)
                {
                    if (kind.ToLower() == fi.Extension.ToLower().Replace(".", ""))
                    {
                        ismatch = true;
                    }
                }

                if (!ismatch)
                {
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "文件格式不符", "", "");
                    return;
                }


                string tempRootPath = Server.MapPath("~/fileupload/Attachment/temp");
                if (!System.IO.Directory.Exists(tempRootPath))
                {
                    System.IO.Directory.CreateDirectory(tempRootPath);
                }
                string tempFolder = System.IO.Path.Combine(tempRootPath, hfFlow_id.Value);

                if (!System.IO.Directory.Exists(tempFolder))
                {
                    System.IO.Directory.CreateDirectory(tempFolder);
                }

                string tempFileFolder = System.IO.Path.Combine(tempFolder, guid);
                if (!System.IO.Directory.Exists(tempFileFolder))
                {
                    System.IO.Directory.CreateDirectory(tempFileFolder);
                }
                
                string fname = txtChild_name.Text;
                if (fuAttachment.FileName.Contains("."))
                    fname += "." + fuAttachment.FileName.Split('.')[1];

                dr["File_name"] = fname;
                dr["File_size"] = fuAttachment.PostedFile.ContentLength.ToString() + "kBytes"; ;
                dr["File_type"] = fuAttachment.PostedFile.ContentType;


                fuAttachment.SaveAs(System.IO.Path.Combine(tempFileFolder, fname));
            }

            dtCurrentTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtCurrentTable;
            this.GridViewA.DataSource = dtCurrentTable;
            this.GridViewA.DataBind();
        }
    }

    protected void btnMain_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((Button)sender).NamingContainer;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        hfModifyIndex.Value = gr.RowIndex.ToString();
        DataRow dr = dtCurrentTable.Rows[gr.RowIndex];
        txtChild_name.Text = CommonFun.SetDataRow(ref dr, "Child_name").ToString();
        txtChild_id.Text = CommonFun.SetDataRow(ref dr, "Child_id").ToString();
        ucChildBirth_date.Text = CommonFun.SetDataRow(ref dr, "ChildBirth_date").ToString();
        txtSchool_name.Text = CommonFun.SetDataRow(ref dr, "School_name").ToString();
        ucSchool_type.Code_no = CommonFun.SetDataRow(ref dr, "School_type").ToString();
        txtStudyLimit_nos.Text = CommonFun.SetDataRow(ref dr, "StudyLimit_nos").ToString();
        txtStudy_nos.Text = CommonFun.SetDataRow(ref dr, "Study_nos").ToString();
        txtApply_amt.Text = CommonFun.SetDataRow(ref dr, "Apply_amt").ToString();
        //if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
        //{
        //    Dictionary<string,object> condition  = new Dictionary<string,object>();
        //    condition.Add("Flow_id", Request.QueryString["fid"].ToString());
        //    DataTable dtAtt = dao.personnelDAO.DAO.GetDataByExample("Sys_Attachment", condition);
        //    DataRow[] attArys = dtAtt.Select(string.Format(" File_name like '*{0}*' ", txtChild_name.Text));
        //    if (attArys.Length > 0)
        //    {
        //        hfAttachmentId.Value = attArys[0]["id"].ToString();
        //    }
        //}
        hfAttachmentId.Value = CommonFun.SetDataRow(ref dr, "Attach_id").ToString();
        lbFile_name.Text = CommonFun.SetDataRow(ref dr, "File_name").ToString();

        this.btnAdd.Text = "更新";
        pnAttach.Visible = Convert.ToInt16(ucSchool_type.Code_no) <= 15;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((Button)sender).NamingContainer;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dtCurrentTable.Rows.RemoveAt(gr.RowIndex);
        ViewState["CurrentTable"] = dtCurrentTable;
        this.GridViewA.DataSource = dtCurrentTable;
        this.GridViewA.DataBind();
    }

    protected void ucSchool_type_CodeChanged(object sender, EventArgs e)
    {
        pnAttach.Visible = Convert.ToInt16(ucSchool_type.Code_no) <= 15;
        calApply_amt(ucSchool_type.Code_no);
    }

    private void calApply_amt(string schoolTypeCodeNo)
    {
        DataTable dt = dao.ssmDAO.GetAll("P", schoolTypeCodeNo, "006", "011", "");
        if (dt != null && dt.Rows.Count > 0)
        {
            int retval;
            bool a = Int32.TryParse(dt.Rows[0]["PARAMETER_VALUE"].ToString(), out retval);
            txtApply_amt.Text = retval.ToString();
        }
        else
        {
            txtApply_amt.Text = "0";
        }
    }

    /// <summary>
    /// 【帶入上期申請資料】按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLast_Click(object sender, EventArgs e)
    {
        string idCard = UcDDLMember.SelectedValue; //LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card);
        string szAcademicYearAndSemester = string.Empty; // 申請學年度
        string szDateToday = (int.Parse(DateTime.Today.ToString("yyyy")) - 1911).ToString(); // 系統年度

        if (this.lblAcademicYear.Text == szDateToday)
        {
            szAcademicYearAndSemester = this.lblAcademicYear.Text;
        }
        else
        {
            szAcademicYearAndSemester = szDateToday;
        }

        if (this.lblSemester.Text == "2")
        {
            szAcademicYearAndSemester = szAcademicYearAndSemester + "1";
        }
        else
        {
            szAcademicYearAndSemester = (int.Parse(szAcademicYearAndSemester) -1) + "2";
        }

        this.GridViewB.DataSource = dao.GetLastestFee(szAcademicYearAndSemester, idCard);
        this.GridViewB.DataBind();

        if (this.GridViewB.Rows.Count == 0)
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "未有上期申請資料", "", "");

            this.div2.Visible = false;
        }
        else
        {
            this.div2.Visible = true;
        }
     
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        int Num;

        if (string.IsNullOrEmpty(txtStudyLimit_nos.Text) )
        {
            msg += @"請輸入「修業年限」\n";
        }
        if ( !int.TryParse(txtStudyLimit_nos.Text, out Num))
        {
            msg += @"「修業年限」只能輸入數字\n";
        }

        if (string.IsNullOrEmpty(this.txtStudy_nos.Text) )
        {
            msg += @"請輸入「就讀年級」\n";
        }
        if ( !int.TryParse(txtStudy_nos.Text, out Num))
        {
            msg += @"「就讀年級」只能輸入數字\n";
        }
        if (string.IsNullOrEmpty(this.txtChild_name.Text))
        {
            msg += @"請輸入子女姓名\n";
        }
        else if (this.txtChild_name.Text.Length > 10)
        {
            msg += @"子女姓名只能輸入10個字\n";
        }
        if (string.IsNullOrEmpty(this.txtChild_id.Text))
        {
            msg += @"請輸入身分證字號\n";
        }
        else if (this.txtChild_id.Text.Length > 10)
        {
            msg += @"身分證字號只能輸入10個字\n";
        }
        if (string.IsNullOrEmpty(this.txtSchool_name.Text))
        {
            msg += @"請輸入學校名稱科系\n";
        }
        else if (this.txtSchool_name.Text.Length > 20)
        {
            msg += @"學校名稱科系號只能輸入20個字\n";
        }
        if (string.IsNullOrEmpty(this.ucChildBirth_date.Text))
        {
            msg += @"請輸入子女出生日期\n";
        }
        if (string.IsNullOrEmpty(this.txtStudy_nos.Text))
        {
            msg += @"請輸入就讀年級\n";
        }
        if (ucSchool_type.SelectedValue != "-1" && (ucSchool_type.SelectedValue != "017" && ucSchool_type.SelectedValue != "016"))
        {
            if (fuAttachment.HasFile == false && string.IsNullOrEmpty(lbFile_name.Text))
            {
                msg += @"高中以上申請補助費需檢附證明\n";
            }
        }

        if (string.IsNullOrEmpty(msg))
        {
            if (string.IsNullOrEmpty(hfModifyIndex.Value))
            {
                AddNewRowToGrid();
            }
            else
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow dr = dtCurrentTable.Rows[Convert.ToInt16(hfModifyIndex.Value)];
                dr["Child_id"] = txtChild_id.Text;
                dr["Child_name"] = txtChild_name.Text;
                dr["ChildBirth_date"] = ucChildBirth_date.Text;
                dr["Apply_date"] = CommonFun.getYYYMMDD();
                dr["Apply_yy"] = lblAcademicYear.Text;
                dr["Period_type"] = lblSemester.Text;
                dr["School_name"] = txtSchool_name.Text;
                dr["School_type"] = ucSchool_type.Code_no;
                dr["StudyLimit_nos"] = txtStudyLimit_nos.Text;
                dr["Study_nos"] = txtStudy_nos.Text;
                dr["Apply_amt"] = Convert.ToInt32(txtApply_amt.Text);
                

                if (fuAttachment.HasFile)
                {
                    //dr["Attach_id"] = Convert.ToInt32(this.hfAttachmentId.Value);
                    if (fuAttachment.HasFile)
                    {
                        string guid = Guid.NewGuid().ToString();
                        dr["Guid"] = guid;
                        int attsize = CommonFun.getInt(ConfigurationManager.AppSettings["attsize"].ToString());

                        Page p = this.Page;
                        if (fuAttachment.PostedFile.ContentLength > attsize * 1000)
                        {
                            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "文件大小不能超過" + attsize.ToString() + "k!", "", "");
                            return;
                        }

                        FileInfo fi = new FileInfo(fuAttachment.PostedFile.FileName);

                        bool ismatch = false;
                        string[] attkinds = ConfigurationManager.AppSettings["attkind"].ToString().Split('|');
                        foreach (string kind in attkinds)
                        {
                            if (kind.ToLower() == fi.Extension.ToLower().Replace(".", ""))
                            {
                                ismatch = true;
                            }
                        }

                        if (!ismatch)
                        {
                            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "文件格式不符", "", "");
                            return;
                        }


                        string tempRootPath = Server.MapPath("~/fileupload/Attachment/temp");
                        if (!System.IO.Directory.Exists(tempRootPath))
                        {
                            System.IO.Directory.CreateDirectory(tempRootPath);
                        }
                        string tempFolder = System.IO.Path.Combine(tempRootPath, hfFlow_id.Value);

                        if (!System.IO.Directory.Exists(tempFolder))
                        {
                            System.IO.Directory.CreateDirectory(tempFolder);
                        }

                        string tempFileFolder = System.IO.Path.Combine(tempFolder, guid);
                        if (!System.IO.Directory.Exists(tempFileFolder))
                        {
                            System.IO.Directory.CreateDirectory(tempFileFolder);
                        }

                        string fname = txtChild_name.Text;
                        if (fuAttachment.FileName.Contains("."))
                            fname += "." + fuAttachment.FileName.Split('.')[1];
                        
                        dr["File_name"] = fname;
                        dr["File_size"] = fuAttachment.PostedFile.ContentLength.ToString() + "kBytes"; ;
                        dr["File_type"] = fuAttachment.PostedFile.ContentType;


                        fuAttachment.SaveAs(System.IO.Path.Combine(tempFileFolder, fname));
                    }
                }
                

                ViewState["CurrentTable"] = dtCurrentTable;
                this.GridViewA.DataSource = dtCurrentTable;
                this.GridViewA.DataBind();

                hfModifyIndex.Value = "";

                this.btnAdd.Text = "新增";
            }
        }
        else
        {
            Page p = this.Page;
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        if (dtCurrentTable == null || dtCurrentTable.Rows.Count <= 0)
        {
            msg += "至少輸入一筆申請\\n";
        }
        else
        {
            if (string.IsNullOrEmpty(Request.QueryString["org"]) || string.IsNullOrEmpty(Request.QueryString["fid"]))
            {
                foreach (DataRow dr in dtCurrentTable.Rows)
                {
                    msg += CheckData(dr["Apply_yy"].ToString(), dr["Period_type"].ToString(), dr["Child_id"].ToString(), true);
                }
            }
        }

        Page p = this.Page;
        if (string.IsNullOrEmpty(msg))
        {
            try
            {
                bool isUpdate = false;
                string flow_id = string.Empty;

                if (!string.IsNullOrEmpty(Request.QueryString["org"]) && !string.IsNullOrEmpty(Request.QueryString["fid"]))
                {
                    isUpdate = true;
                    flow_id = Request.QueryString["fid"];
                    string orgcode = Request.QueryString["org"];
                    dao.update(lblAcademicYear.Text, lblSemester.Text, orgcode, flow_id, dtCurrentTable);
                }
                else
                {
                    flow_id = dao.Add(UcDDLDepart.SelectedValue, UcDDLMember.SelectedValue, lblAcademicYear.Text, lblSemester.Text, hfFlow_id.Value, dtCurrentTable);
                    CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, "申請已送出", "", "");
                }

                //this.UcAttachment.FlowId = hfFlow_id.Value;
                //this.UcAttachment.SaveFile();
                //this.btnAdd.Enabled = false;
                // this.btnSubmit.Enabled = false;
                //this.btnLast.Enabled = false;
                //string yy = flow_id.Substring(3, 2);
                //string Filepath = Server.MapPath(@"~\fileupload\Attachment\" + yy + @"\") + flow_id;
                //if (!System.IO.Directory.Exists(Filepath))
                //{
                //    System.IO.Directory.CreateDirectory(Filepath);
                //}
                //foreach (GridViewRow gr in GridViewA.Rows)
                //{
                //    Button btnDelete = (Button)gr.FindControl("btnDelete");
                //    Button btnMain = (Button)gr.FindControl("btnMain");
                //    //btnDelete.Enabled = false;
                //    //btnMain.Enabled = false;
                //    HiddenField hfGuid = (HiddenField)gr.FindControl("hfGuid");
                //    HiddenField hfFile_name = (HiddenField)gr.FindControl("hfFile_name");
                //    HiddenField hfFile_size = (HiddenField)gr.FindControl("hfFile_size");
                //    HiddenField hfFile_type = (HiddenField)gr.FindControl("hfFile_type");
                //    HiddenField hfAttach_id = (HiddenField)gr.FindControl("hfAttach_id");
                //    if (!string.IsNullOrEmpty(hfGuid.Value))
                //    {
                //        SYS.Logic.Attachment att = new SYS.Logic.Attachment();
                //        if (!string.IsNullOrEmpty(hfAttachmentId.Value) && Convert.ToInt32(hfAttachmentId.Value) > 0)
                //        {
                //            att.DeleteAttachById(Convert.ToInt32(hfAttachmentId.Value));
                //        }
                //        att.Flow_id = flow_id;
                //        att.File_name = gr.Cells[1].Text + "." + hfFile_name.Value.Split('.')[1];
                //        att.File_size = hfFile_size.Value;
                //        att.File_type = hfFile_type.Value;
                //        att.File_path = Filepath;
                //        att.File_real_name = hfFile_name.Value;
                //        att.Upload_userid = LoginManager.UserId;
                //        att.InsertAttach();
                //        string tempFilePath = Server.MapPath(string.Format("~/fileupload/Attachment/temp/{0}/{1}/", hfFlow_id.Value, hfGuid.Value));
                //        FileInfo f = new FileInfo(tempFilePath + hfFile_name.Value);
                //        f.MoveTo(Path.Combine(Filepath, att.File_name));
                //    }

                //}

                if (isUpdate)
                    CommonFun.MsgShow(ref p, CommonFun.Msg.UpdateOK, "", "../../FSC/FSC0/FSC0102_01.aspx", "");

            }
            catch (FlowException fex)
            {
                CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, fex.Message, "", "");
            }

        }
        else
        {
            CommonFun.MsgShow(ref p, CommonFun.Msg.Custom, msg, "", "");
        }
    }
    protected void GridViewB_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DataView")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridViewB.Rows[index];

           
            txtChild_name.Text = row.Cells[1].Text.Replace("&nbsp;","");//子女姓名
            ucChildBirth_date.Text = row.Cells[2].Text.Replace("&nbsp;", "");//子女出生日期
            txtChild_id.Text = row.Cells[3].Text.Replace("&nbsp;", "");//身分證字號
            txtSchool_name.Text = row.Cells[7].Text.Replace("&nbsp;", "");//學校名稱科系
            ucSchool_type.Code_no = ((HiddenField)row.FindControl("hfSchool_type")).Value; //子女學歷
            txtStudyLimit_nos.Text = row.Cells[9].Text.Replace("&nbsp;", "");//修業年限
            txtStudy_nos.Text = row.Cells[10].Text.Replace("&nbsp;", "");//就讀年級
            txtApply_amt.Text = row.Cells[11].Text.Replace("&nbsp;", "");//申請金額
            pnAttach.Visible = Convert.ToInt16(ucSchool_type.Code_no) <= 15;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ViewState["BackUrl"] != null)
            Response.Redirect(ViewState["BackUrl"].ToString());
    }
    protected void UcDDLDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue;
    }
}