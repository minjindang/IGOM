Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports System.IO

Partial Class FSC0101_28
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Public Sub Bind()
        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Dim pf As New FSC.Logic.PaperForm
            pf.Orgcode = Request.QueryString("org")
            pf.FlowId = Request.QueryString("fid")

            Dim dt As DataTable = pf.getDataByOrgFid()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                lbFlow_id.Text = dt.Rows(0)("flow_id").ToString()
                lbApplyName.Text = dt.Rows(0)("apply_name").ToString()
                lbChange_date.Text = dt.Rows(0)("change_date").ToString()
                lbPaperName.Text = dt.Rows(0)("Paper_Name").ToString()
                lbReason.Text = dt.Rows(0)("Reason").ToString()
                lbtnAttachFile.Text = dt.Rows(0)("File_Name").ToString()
                hdfilePath.Value = dt.Rows(0)("File_Path").ToString()

                If LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) <> dt.Rows(0)("id_card").ToString() Then
                    UcCustomNext.Text = "不決行，選擇審核人員"
                    UcCustomNext.Visible = True
                End If
            End If

            UcAttachment.FlowId = Request.QueryString("fid")
            UcAttachment.isUpload = False

            UcFlowDetail.Orgcode = pf.Orgcode
            UcFlowDetail.FlowId = pf.FlowId

        End If
    End Sub

    Protected Sub lbtnAttachFile_Click(sender As Object, e As EventArgs) Handles lbtnAttachFile.Click
        Dim attName As String = lbtnAttachFile.Text
        Dim attPath As String = hdfilePath.Value.Replace("\", "/") & "/" & attName
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim a() As Byte = wc.DownloadData(attPath)
        Dim FileName As String = System.IO.Path.GetFileName(attPath)
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(FileName)))
        Response.BinaryWrite(a)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Dim url As String = ViewState("BackUrl")
        Response.Redirect(url)
    End Sub

    Protected Sub UcCustomNext_Click(sender As Object, e As EventArgs)
        Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim err As New StringBuilder()

        Dim orgcode As String = Request.QueryString("org")
        Dim flowId As String = Request.QueryString("fid")
        Dim comment As String = ""

        Dim fd As New SYS.Logic.FlowDetail()
        fd.Orgcode = orgcode
        fd.FlowId = flowId
        fd.LastOrgcode = lastOrgcode
        fd.LastDepartid = lastDepartId
        fd.LastPosid = lastPosid
        fd.LastIdcard = lastIdcard
        fd.LastName = lastName
        fd.AgreeFlag = "1"
        fd.AgreeTime = Now
        fd.Comment = comment
        fd.ChangeDate = Now
        fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        Dim fn As New SYS.Logic.FlowNext()
        fn.Orgcode = orgcode
        fn.FlowId = flowId
        fn.NextOrgcode = UcCustomNext.NextOrgcode
        fn.NextDepartid = UcCustomNext.NextDepartid
        fn.NextPosid = UcCustomNext.NextPosid
        fn.NextIdcard = UcCustomNext.NextIdcard
        fn.NextName = UcCustomNext.NextName

        Try
            Using trans As New TransactionScope
                SYS.Logic.CommonFlow.RunFlow(fd, fn)
                trans.Complete()
            End Using

        Catch fex As FlowException
            err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("批核表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
        End Try

        SendNotice.sendAll(fd.Orgcode, fd.FlowId)

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "批核成功!", "FSC0101_02.aspx")
        End If
    End Sub
End Class
