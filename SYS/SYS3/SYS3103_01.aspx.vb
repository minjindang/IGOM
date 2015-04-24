Imports System.Data
Imports System.Transactions
Imports SYS.Logic

Partial Class SYS3103_01
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
        Bind()
        setEnabled(True)
    End Sub
#End Region

#Region "下拉式選單"
    Protected Sub CODE_SYS_Bind()
        ddlCODE_SYS.Items.Insert(0, New ListItem("系統", "SYS"))
        ddlCODE_SYS.Enabled = False
    End Sub

    Protected Sub CODE_TYPE_Bind()
        ddlCODE_TYPE.Items.Insert(0, New ListItem("第一層代碼", "*"))
        ddlCODE_TYPE.Enabled = False
    End Sub
#End Region

#Region "連繫資料"
    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sc As SYS.Logic.CODE = New SYS.Logic.CODE
        Dim dt As DataTable = sc.GetData(Orgcode, "SYS", "*", "")

        For Each dr As DataRow In dt.Rows
            dr("CODE_SYS_Name") = "系統"
            dr("CODE_TYPE_Name") = "第一層代碼"
        Next

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
        cbSubmit.Visible = True
        cbCancel.Visible = True

        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        'ddlCODE_SYS.SelectedValue = CType(gvr.FindControl("lbCODE_SYS"), Label).Text
        ddlCODE_KIND.SelectedValue = CType(gvr.FindControl("lbCODE_KIND"), Label).Text
        'ddlCODE_TYPE.SelectedValue = CType(gvr.FindControl("lbCODE_TYPE"), Label).Text
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
        Dim dt As DataTable = sc.GetData(Orgcode, CODE_NO, "", "")
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "尚有下層代碼未刪除!")
            Return
        End If

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

    Protected Sub cbNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim CODE_KIND As String = CType(gvr.FindControl("lbCODE_KIND"), Label).Text
        Dim CODE_NO As String = gvr.Cells(3).Text

        Response.Redirect("SYS3103_02.aspx?sys=" + CODE_NO + "&kind=" + CODE_KIND)
    End Sub

    Public Sub setEnabled(ByVal Enabled As Boolean)
        For Each gr As GridViewRow In gvList.Rows
            Dim cbNext As Button = CType(gr.FindControl("cbNext"), Button)
            Dim cbUpdate As Button = CType(gr.FindControl("cbUpdate"), Button)
            Dim cbDelete As Button = CType(gr.FindControl("cbDelete"), Button)

            cbNext.Enabled = Enabled
            cbUpdate.Enabled = Enabled
            cbDelete.Enabled = Enabled
        Next
    End Sub

    Protected Sub gvList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvList.PageIndexChanging
        gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub
End Class
