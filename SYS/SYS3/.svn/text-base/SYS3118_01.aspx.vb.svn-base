Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3118_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.OrgCode
    End Sub


    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = UcDDLDepart.SelectedValue

        If departId.Length < 6 Then
            departId &= "0000"
        End If

        Dim dt As DataTable = New SYS.Logic.PaperFile().GetDataByOuery(Orgcode, departId)

        gvList.DataSource = dt
        gvList.DataBind()
        DataList.Visible = True

    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("SYS3118_02.aspx")
    End Sub

    Protected Sub gvcbDelete_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id As String = CType(gvr.FindControl("gvhfId"), HiddenField).Value
        Dim bll As New SYS3118()

        bll.DeleteFile(id)
        CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
        bind()

    End Sub


    Protected Sub gvcbExample_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim path As String = CType(gvr.FindControl("gvhfPath"), HiddenField).Value
        Dim name As String = CType(gvr.FindControl("gvhfRealName"), HiddenField).Value
        Dim fileName As String = CType(gvr.FindControl("gvhfFileName"), HiddenField).Value

        Dim filepath As String = path & name
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim b() As Byte = wc.DownloadData(filepath)

        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(fileName)))
        Response.BinaryWrite(b)
        Response.Flush()
        Response.End()
    End Sub

    'Protected Sub gvcbFlow_Click(sender As Object, e As EventArgs)
    '    Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
    '    Dim id As String = CType(gvr.FindControl("gvhfId"), HiddenField).Value

    '    Response.Redirect("SYS3118_03.aspx?pid=" & id)
    'End Sub

    Protected Sub gvcbUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        GvButtonEnable(False)
        ShowControl(gvr)
    End Sub

    Protected Sub gvcbConfirm_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("gvhfId"), HiddenField).Value
        Dim gvUcDate1 As UControl_UcDate = CType(gvr.FindControl("gvUcDate1"), UControl_UcDate)
        Dim gvUcDate2 As UControl_UcDate = CType(gvr.FindControl("gvUcDate2"), UControl_UcDate)
        Dim gvrblFlag As RadioButtonList = CType(gvr.FindControl("gvrblFlag"), RadioButtonList)

        If String.IsNullOrEmpty(gvUcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上架日期(起)!")
            Return
        End If
        If String.IsNullOrEmpty(gvUcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上架日期(迄)!")
            Return
        End If
        If gvUcDate1.Text > gvUcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上架日期(起)不可大於上架日期(迄)!")
            Return
        End If

        Try
            Dim pf As SYS.Logic.PaperFile = New PaperFile
            pf.Start_date = gvUcDate1.Text
            pf.End_date = gvUcDate2.Text
            pf.removed_flag = gvrblFlag.SelectedValue
            pf.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            pf.ChangeDate = Now

            pf.UpdateData(id)
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            bind()

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub gvcbCancel_Click(sender As Object, e As EventArgs)
        bind()
    End Sub

    Protected Sub ShowControl(ByVal gvr As GridViewRow)
        Dim gvcbDelete As Button = CType(gvr.FindControl("gvcbDelete"), Button)
        Dim gvcbExample As Button = CType(gvr.FindControl("gvcbExample"), Button)
        Dim gvcbUpdate As Button = CType(gvr.FindControl("gvcbUpdate"), Button)
        Dim gvcbConfirm As Button = CType(gvr.FindControl("gvcbConfirm"), Button)
        Dim gvcbCancel As Button = CType(gvr.FindControl("gvcbCancel"), Button)
        Dim UcShowDate1 As UControl_UcShowDate = CType(gvr.FindControl("UcShowDate1"), UControl_UcShowDate)
        Dim UcShowDate2 As UControl_UcShowDate = CType(gvr.FindControl("UcShowDate2"), UControl_UcShowDate)
        Dim gvUcDate1 As UControl_UcDate = CType(gvr.FindControl("gvUcDate1"), UControl_UcDate)
        Dim gvUcDate2 As UControl_UcDate = CType(gvr.FindControl("gvUcDate2"), UControl_UcDate)
        Dim gvlbremoved_flag As Label = CType(gvr.FindControl("gvlbremoved_flag"), Label)
        Dim gvrblFlag As RadioButtonList = CType(gvr.FindControl("gvrblFlag"), RadioButtonList)

        gvcbDelete.Visible = False
        gvcbExample.Visible = False
        gvcbUpdate.Visible = False
        gvcbConfirm.Visible = True
        gvcbCancel.Visible = True
        UcShowDate1.Visible = False
        UcShowDate2.Visible = False
        gvUcDate1.Visible = True
        gvUcDate2.Visible = True
        gvlbremoved_flag.Visible = False
        gvrblFlag.Visible = True
    End Sub

    Protected Sub GvButtonEnable(ByVal Enabled As Boolean)
        For Each gvr As GridViewRow In gvList.Rows
            Dim gvcbDelete As Button = CType(gvr.FindControl("gvcbDelete"), Button)
            Dim gvcbExample As Button = CType(gvr.FindControl("gvcbExample"), Button)
            Dim gvcbUpdate As Button = CType(gvr.FindControl("gvcbUpdate"), Button)
            gvcbDelete.Enabled = Enabled
            gvcbExample.Enabled = Enabled
            gvcbUpdate.Enabled = Enabled
        Next
    End Sub

    Protected Sub gvcbModify_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("gvhfId"), HiddenField).Value
        Response.Redirect("SYS3118_02.aspx?id=" & id)
    End Sub
End Class
