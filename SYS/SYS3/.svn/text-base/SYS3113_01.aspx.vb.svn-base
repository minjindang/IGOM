Imports System
Imports System.Data
Imports FSCPLM.Logic
Imports System.Transactions

Partial Class SYS3_SYS3113_01
    Inherits BaseWebForm

    Dim dtData As DataTable
    Dim bll As New SYS.Logic.SYS3113()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If

        ' 繫結【功能名稱-父選單】
        Me.ddlFuncFlag.DataTextField = "Func_name"
        Me.ddlFuncFlag.DataValueField = "Func_id"
        Me.ddlFuncFlag.DataSource = bll.GetFuncFlag()
        Me.ddlFuncFlag.DataBind()

        Dim dt As DataTable = bll.GetFuncName(Me.ddlFuncFlag.SelectedValue)
        ' 繫結【功能名稱-子選單】
        Me.ddlFuncName.DataTextField = "Func_name"
        Me.ddlFuncName.DataValueField = "Func_id"
        Me.ddlFuncName.DataSource = dt
        Me.ddlFuncName.DataBind()
        Me.ddlFuncName.Visible = dt IsNot Nothing AndAlso dt.Rows.Count > 0

    End Sub

    Protected Sub ddlFuncFlag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFuncFlag.SelectedIndexChanged
        Dim dt As DataTable = bll.GetFuncName(Me.ddlFuncFlag.SelectedValue)
        Me.ddlFuncName.DataTextField = "Func_name"
        Me.ddlFuncName.DataValueField = "Func_id"
        Me.ddlFuncName.DataSource = dt
        Me.ddlFuncName.DataBind()
        Me.ddlFuncName.Visible = dt IsNot Nothing AndAlso dt.Rows.Count > 0
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        'If Me.ddlFuncName.SelectedValue = "" Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【功能名稱-子選單】未輸入，請重新查詢!")
        '    Return
        'End If
        Dim Func_id As String = IIf(Not String.IsNullOrEmpty(ddlFuncName.SelectedValue), ddlFuncName.SelectedValue, ddlFuncFlag.SelectedValue)
        dtData = bll.GetDepartName(Me.ddlFuncFlag.SelectedValue, Func_id)

        Me.gvList.DataSource = dtData
        Me.gvList.DataBind()

        ' 依功能選單之狀態，變換按鈕文字
        For i As Integer = 0 To (gvList.Rows.Count - 1)
            Dim lbUpdate As LinkButton = gvList.Rows(i).FindControl("lbUpdate")
            Dim lbFreeze As Label = gvList.Rows(i).FindControl("lbFreeze")

            If lbFreeze.Text = "1" Then
                lbUpdate.Text = "開放"
            Else
                lbUpdate.Text = "關閉"
            End If
        Next
    End Sub

    ''' <summary>
    ''' GridView 中的鎖定/解除鎖定按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub lbUpdate_Click(sender As Object, e As EventArgs)
        ' 取得該列數
        Dim Row As System.Web.UI.WebControls.GridViewRow
        Dim RowIndex As Integer
        Row = CType(sender, LinkButton).NamingContainer
        RowIndex = Row.RowIndex

        ' 取得該列的資料
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Change_userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim Change_date As DateTime = DateTime.Now
        Dim lbDepartId As Label = gvList.Rows(RowIndex).FindControl("lbDepartId")
        Dim lbFreeze As Label = gvList.Rows(RowIndex).FindControl("lbFreeze")
        Dim lbUpdate As LinkButton = gvList.Rows(RowIndex).FindControl("lbUpdate")
        Dim Depart_id As String = lbDepartId.Text
        Dim Func_id As String = IIf(Not String.IsNullOrEmpty(ddlFuncName.SelectedValue), ddlFuncName.SelectedValue, ddlFuncFlag.SelectedValue)
        Dim isFreeze As String = "0"
        If lbUpdate.Text = "關閉" Then
            isFreeze = "1"
        End If


        ' 新增功能選單狀態
        Dim iCounts As Integer = 0
        iCounts = bll.InsertData(Orgcode, Depart_id, Func_id, isFreeze, Change_userid, Change_date)

        If iCounts > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, lbUpdate.Text + "成功!")
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "關閉失敗!")
        End If

        '呼叫查詢按鈕，重新載入Gridview
        btnQuery_Click(Me, EventArgs.Empty)
    End Sub

    Protected Sub lbLockAll_Click(sender As Object, e As EventArgs)
        BatchUpdate("1")
    End Sub

    Protected Sub lbUnLockAll_Click(sender As Object, e As EventArgs)
        BatchUpdate("0")
    End Sub

    Protected Sub BatchUpdate(ByVal isFreeze As String)
        Try
            Using trans As New TransactionScope
                For Each gvr As GridViewRow In gvList.Rows
                    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                    Dim Change_userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    Dim Change_date As DateTime = DateTime.Now
                    Dim lbDepartId As Label = gvr.FindControl("lbDepartId")
                    Dim Depart_id As String = lbDepartId.Text
                    Dim Func_id As String = IIf(Not String.IsNullOrEmpty(ddlFuncName.SelectedValue), ddlFuncName.SelectedValue, ddlFuncFlag.SelectedValue)

                    bll.InsertData(Orgcode, Depart_id, Func_id, isFreeze, Change_userid, Change_date)
                Next

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, IIf(isFreeze = "1", "關閉成功!", "開放成功!"))
            btnQuery_Click(Nothing, Nothing)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
