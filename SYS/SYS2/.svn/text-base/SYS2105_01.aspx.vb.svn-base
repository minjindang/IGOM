Imports System
Imports System.Data
Imports FSCPLM.Logic

Partial Class SYS2105_01
    Inherits BaseWebForm

    Dim dtData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If

        ' 日期設定
        Me.UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        Me.UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ShowData()
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim FromName As String = Me.txtFromName.Text
        Dim FromMail As String = Me.txtFromMail.Text
        Dim ToName As String = Me.txtToName.Text
        Dim ToMail As String = Me.txtToMail.Text
        Dim dateS As String = Me.UcDate1.Text
        Dim dateE As String = Me.UcDate2.Text
        Dim ErrorM As String = Me.ddlErrorMsg.SelectedValue
        Dim bll As New SYS.Logic.SYS3109()

        Try
            dtData = bll.GetData(FromName, FromMail, ToName, ToMail, dateS, dateE, ErrorM)

            Me.gvList.DataSource = dtData
            Me.gvList.DataBind()

            ViewState("DataTableSYS3109") = dtData
            dtData.Dispose()

        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "系統發生錯誤，請稍候再試或通知系統管理者")
        End Try
    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvList.DataSource = CType(ViewState("DataTableSYS3109"), DataTable)
        Me.gvList.DataBind()
    End Sub

End Class
