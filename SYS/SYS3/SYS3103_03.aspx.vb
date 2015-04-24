Imports System.Data
Imports System.Transactions
Imports SYS.Logic

Partial Class SYS3103_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        initData()
    End Sub

#Region "初始化"
    Protected Sub initData()
        cbAdd.Visible = True
        cbBack.Visible = True
        cbSubmit.Visible = False
        cbCancel.Visible = False
        tbCODE_NO.Enabled = True
        tbCODE_NO.Text = ""
        tbCODE_DESC1.Text = ""
        tbCODE_DESC2.Text = ""
        tbCODE_REMARK1.Text = ""
        tbCODE_REMARK2.Text = ""
        tbCODE_SORT.Text = ""

        CODE_SYS_Bind()
        CODE_TYPE_Bind()
        CODE_KIND_Bind()
        Bind()
        setEnabled(True)
    End Sub
#End Region

#Region "下拉式選單"
    Protected Sub CODE_SYS_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim CODE_SYS As String = Request.QueryString("sys")
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE
        ddlCODE_SYS.DataTextField = "CODE_DESC1"
        ddlCODE_SYS.DataValueField = "CODE_NO"
        ddlCODE_SYS.DataSource = sc.GetData(Orgcode, "SYS", "*", "")
        ddlCODE_SYS.DataBind()
        ddlCODE_SYS.SelectedValue = CODE_SYS
        ddlCODE_SYS.Enabled = False
    End Sub

    Protected Sub CODE_TYPE_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim CODE_SYS As String = Request.QueryString("sys")
        Dim CODE_TYPE As String = Request.QueryString("type")
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE
        ddlCODE_TYPE.DataTextField = "CODE_DESC1"
        ddlCODE_TYPE.DataValueField = "CODE_NO"
        ddlCODE_TYPE.DataSource = sc.GetData(Orgcode, CODE_SYS, "**", "")
        ddlCODE_TYPE.DataBind()
        ddlCODE_TYPE.SelectedValue = CODE_TYPE
        ddlCODE_TYPE.Enabled = False
    End Sub

    Protected Sub CODE_KIND_Bind()
        Dim CODE_KIND As String = Request.QueryString("kind")
        ddlCODE_KIND.SelectedValue = CODE_KIND
        ddlCODE_KIND.Enabled = False
    End Sub
#End Region

#Region "連繫資料"
    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim CODE_SYS As String = Request.QueryString("sys")
        Dim CODE_TYPE As String = Request.QueryString("type")
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE
        Dim dt As DataTable = sc.GetData(Orgcode, CODE_SYS, CODE_TYPE, "")

        gvList.DataSource = dt
        gvList.DataBind()
    End Sub
#End Region

#Region "新增"
    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Dim Orgocde As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE

        If String.IsNullOrEmpty(tbCODE_NO.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "代碼編號不可為空白!")
            Return
        End If
        If String.IsNullOrEmpty(tbCODE_DESC1.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "代碼說明(1)不可為空白!")
            Return
        End If

        Dim dt As DataTable = sc.GetData(Orgocde, ddlCODE_SYS.SelectedValue, ddlCODE_TYPE.SelectedValue, tbCODE_NO.Text.Trim())
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該代碼編號!")
            Return
        End If
        If Not IsNumeric(Me.tbCODE_SORT.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "排序請輸入數字!")
            Exit Sub
        End If
        sc.CODE_SYS = ddlCODE_SYS.SelectedValue
        sc.CODE_KIND = ddlCODE_KIND.SelectedValue
        sc.CODE_TYPE = ddlCODE_TYPE.SelectedValue
        sc.CODE_NO = tbCODE_NO.Text.Trim()
        sc.CODE_DESC1 = tbCODE_DESC1.Text.Trim()
        sc.CODE_DESC2 = tbCODE_DESC2.Text.Trim()
        sc.CODE_REMARK1 = tbCODE_REMARK1.Text.Trim()
        sc.CODE_REMARK2 = tbCODE_REMARK2.Text.Trim()
        sc.CODE_SORT = CommonFun.getInt(tbCODE_SORT.Text.Trim())
        sc.CODE_MUSERID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        sc.CODE_ORGID = Orgocde
    

        Try
            sc.insert()
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            initData()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

#Region "更新"
    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        cbAdd.Visible = False
        cbBack.Visible = False
        cbSubmit.Visible = True
        cbCancel.Visible = True

        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        ddlCODE_SYS.SelectedValue = CType(gvr.FindControl("lbCODE_SYS"), Label).Text
        ddlCODE_KIND.SelectedValue = CType(gvr.FindControl("lbCODE_KIND"), Label).Text
        ddlCODE_TYPE.SelectedValue = CType(gvr.FindControl("lbCODE_TYPE"), Label).Text
        tbCODE_NO.Text = gvr.Cells(3).Text.Replace("&nbsp;", "")
        tbCODE_DESC1.Text = gvr.Cells(4).Text.Replace("&nbsp;", "")
        tbCODE_DESC2.Text = gvr.Cells(5).Text.Replace("&nbsp;", "")
        tbCODE_REMARK1.Text = gvr.Cells(6).Text.Replace("&nbsp;", "")
        tbCODE_REMARK2.Text = gvr.Cells(7).Text.Replace("&nbsp;", "")
        tbCODE_SORT.Text = gvr.Cells(8).Text.Replace("&nbsp;", "")

        ddlCODE_TYPE.Enabled = False
        tbCODE_NO.Enabled = False

        setEnabled(False)
    End Sub

    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        Dim Orgocde As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE

        If Not IsNumeric(Me.tbCODE_SORT.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "排序請輸入數字!")
            Exit Sub
        End If

        sc.CODE_SYS = ddlCODE_SYS.SelectedValue
        sc.CODE_KIND = ddlCODE_KIND.SelectedValue
        sc.CODE_TYPE = ddlCODE_TYPE.SelectedValue
        sc.CODE_NO = tbCODE_NO.Text.Trim()
        sc.CODE_DESC1 = tbCODE_DESC1.Text.Trim()
        sc.CODE_DESC2 = tbCODE_DESC2.Text.Trim()
        sc.CODE_REMARK1 = tbCODE_REMARK1.Text.Trim()
        sc.CODE_REMARK2 = tbCODE_REMARK2.Text.Trim()
        sc.CODE_SORT = CommonFun.getInt(tbCODE_SORT.Text.Trim())
        sc.CODE_MUSERID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        sc.CODE_ORGID = Orgocde

        Try
            sc.update()
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            initData()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

#Region "刪除"
    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim CODE_SYS As String = CType(gvr.FindControl("lbCODE_SYS"), Label).Text
        Dim CODE_TYPE As String = CType(gvr.FindControl("lbCODE_TYPE"), Label).Text
        Dim CODE_NO As String = gvr.Cells(3).Text

        Dim sc As SYS.Logic.CODE = New CODE

        Try
            sc.CODE_SYS = CODE_SYS
            sc.CODE_TYPE = CODE_TYPE
            sc.CODE_NO = CODE_NO
            sc.CODE_ORGID = Orgcode
            sc.delete()

            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            initData()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        initData()
    End Sub

    Public Sub setEnabled(ByVal Enabled As Boolean)
        For Each gr As GridViewRow In gvList.Rows
            Dim cbNext As Button = CType(gr.FindControl("cbNext"), Button)
            Dim cbUpdate As Button = CType(gr.FindControl("cbUpdate"), Button)
            Dim cbDelete As Button = CType(gr.FindControl("cbDelete"), Button)

            cbUpdate.Enabled = Enabled
            cbDelete.Enabled = Enabled
        Next
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Dim CODE_SYS As String = Request.QueryString("sys")
        Dim CODE_KIND As String = Request.QueryString("kind")

        Response.Redirect("SYS3103_02.aspx?sys=" + CODE_SYS + "&kind=" + CODE_KIND)
    End Sub

    Protected Sub gvList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvList.PageIndexChanging
        gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub
End Class
