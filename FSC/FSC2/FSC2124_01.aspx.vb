Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions

Partial Class FSC2124_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Depart_Bind()
        UserName_Bind()
        Employee_type_Bind()
        Quit_job_Bind()

    End Sub

    Protected Sub Depart_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Private Sub Quit_job_Bind()
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "025")
        ddlQuit_Job.DataTextField = "code_desc1"
        ddlQuit_Job.DataValueField = "code_no"
        ddlQuit_Job.DataSource = dt
        ddlQuit_Job.DataBind()
        ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Private Sub Employee_type_Bind()
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"
        ddlEmployeetype.DataValueField = "code_no"
        ddlEmployeetype.DataSource = dt
        ddlEmployeetype.DataBind()
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim id_card As String = UcDDLMember.SelectedValue
        Dim id_card2 As String = UcMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim bll As New FSC2124()
        Dim dt As DataTable = New DataTable
        Dim tmpdt As DataTable = New DataTable

        If String.IsNullOrEmpty(UcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(UcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「迄日」欄位為必填。")
            Return
        End If

        Try
            dt = bll.GetData(orgcode, depart_id, UcDate1.Text, UcDate2.Text, id_card, id_card2, Quit_job_flag, Employee_type)

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExcel.Enabled = True
            Else
                Ucpager.Visible = False
                btnExcel.Enabled = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If ViewState("dt") Is Nothing Then
            Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            Dim theDTReport As CommonLib.DTReport

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2124_01.mht"), dt)
            theDTReport.ExportFileName = "出勤異常註銷查詢"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub
End Class
