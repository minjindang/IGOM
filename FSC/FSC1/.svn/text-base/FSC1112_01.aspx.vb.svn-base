Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC1112_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        initData()
        ShowReSendData()
    End Sub

    Protected Sub initData()
        ddlPaper_Bind()
        UcDDLDepart_Bind()
    End Sub

    Protected Sub ddlPaper_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable = New SYS.Logic.PaperFile().GetData(Orgcode, Depart_id.Substring(0, 2) & "0000")
        ddlPaper.DataSource = dt
        ddlPaper.DataBind()
    End Sub

    Protected Sub UcDDLDepart_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Public Sub ShowReSendData()
        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Dim pf As New FSC.Logic.PaperForm
            pf.Orgcode = Request.QueryString("org")
            pf.FlowId = Request.QueryString("fid")

            Dim dt As DataTable = pf.getDataByOrgFid()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                UcLeaveMember.Apply_id = dt.Rows(0)("id_card").ToString()
                UcDate.Text = dt.Rows(0)("apply_date").ToString()
                ddlPaper.SelectedValue = dt.Rows(0)("paper_id").ToString()
                tbReason.Text = dt.Rows(0)("Reason").ToString()

                gvAtt.DataSource = dt
                gvAtt.DataBind()
                gvAtt.Visible = True

                UcAttachment.FlowId = pf.FlowId
                UcAttachment.isBind = True

                trNext.Visible = False
            End If
        End If
    End Sub

    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = New DepartEmp().GetDepartId(UcLeaveMember.Apply_id)
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False
        Dim fid As String = String.Empty

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入申請日期!")
            Return
        End If
        If String.IsNullOrEmpty(tbReason.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入申請事由!")
            Return
        End If

        If tbReason.Text.Length > 400 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期以400字為限!")
            Return
        End If
        If Not fuFile.HasFile AndAlso gvAtt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請上傳紙本表單檔案!")
            Return
        End If
        If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) OrElse String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            If Not isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇審核人員!")
                Return
            End If
        End If

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, "001015"))

                Dim fn As New SYS.Logic.FlowNext
                If Not isUpdate Then
                    Dim p As Personnel = New Personnel().GetObject(UcDDLMember.SelectedValue)
                    fn.Orgcode = Orgcode
                    fn.FlowId = fid
                    fn.NextOrgcode = Orgcode
                    fn.NextDepartid = UcDDLDepart.SelectedValue
                    fn.NextIdcard = UcDDLMember.SelectedValue
                    fn.NextName = p.UserName
                    fn.NextPosid = p.TitleNo
                End If

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                Dim pf As New FSC.Logic.PaperForm
                pf.Orgcode = Orgcode
                pf.DepartId = Depart_id
                pf.FlowId = fid
                pf.IdCard = UcLeaveMember.Apply_id
                pf.ApplyName = UcLeaveMember.Apply_name
                pf.ApplyDate = UcDate.Text
                pf.Reason = tbReason.Text.Trim()
                pf.PaperId = ddlPaper.SelectedValue
                pf.PaperName = ddlPaper.SelectedItem.Text
                pf.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                pf.ChangeDate = Now

                If fuFile.HasFile Then
                    'If System.IO.Path.GetExtension(fuFile.FileName).ToUpper <> ".DOC" Then
                    '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "可上傳WORD格式(.doc)的紙本表單檔案!")
                    '    Return
                    'End If

                    Dim yy As String = (Now.Year - 1911).ToString()
                    Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\PaperForm\Apply\" & yy & "\")

                    If Not My.Computer.FileSystem.DirectoryExists(Filepath & fid) Then
                        My.Computer.FileSystem.CreateDirectory(Filepath & fid)
                    End If

                    fuFile.SaveAs(Path.Combine(Filepath & fid, String.Format("{0}", fuFile.FileName)))

                    Dim sr As New StreamReader(Path.Combine(Filepath & fid, String.Format("{0}", fuFile.FileName)))
                    Dim str As String = sr.ReadToEnd()
                    str = str.Replace("Flow_id", fid)
                    sr.Close()
                    sr.Dispose()

                    Dim sw As New StreamWriter(Path.Combine(Filepath & fid, String.Format("{0}", fuFile.FileName)))
                    sw.WriteLine(str)
                    sw.Close()
                    sw.Dispose()

                    pf.FileName = fuFile.FileName
                    pf.FilePath = Filepath & fid
                Else
                    Dim gvr As GridViewRow = gvAtt.Rows(0)
                    pf.FileName = CType(gvr.FindControl("gv_lbtnAttachFile"), LinkButton).Text
                    pf.FilePath = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value
                End If

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = tbReason.Text.Trim()
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.CaseStatus = "2"
                    f.Update()
                    pf.UpdateData()
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "001015"
                    f.Reason = tbReason.Text.Trim()
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddFlow(f, fn)
                    pf.InsertData()
                End If
                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(Orgcode, fid)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1112_01.aspx")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub gv_lcbDel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim attName As String = CType(gvr.FindControl("gv_lbtnAttachFile"), LinkButton).Text
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & attName

        Dim att As New SYS.Logic.Attachment()

        CommonFun.DeleteFile(attPath)
        gvAtt.DataSource = New DataTable
        gvAtt.DataBind()
        gvAtt.Visible = False
    End Sub

    Protected Sub gv_lbtnAttachFile_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim attName As String = CType(gvr.FindControl("gv_lbtnAttachFile"), LinkButton).Text
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & attName
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim a() As Byte = wc.DownloadData(attPath)
        Dim FileName As String = System.IO.Path.GetFileName(attPath)
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(FileName)))
        Response.BinaryWrite(a)
        Response.Flush()
        Response.End()
    End Sub
End Class
