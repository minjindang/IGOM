Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2104_01
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim Case_status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        '        Bind_Member()
        UserName_Bind()

        cblStatus.DataSource = New FSCPLM.Logic.SACode().GetData2("023", "P", "002")
        cblStatus.DataBind()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
        End If

        If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            tr0.Visible = False
            tr4.Visible = False
            tr5.Visible = False
        Else
            For Each i As ListItem In cblStatus.Items
                If i.Value = "001" Or i.Value = "002" Or i.Value = "003" Then
                    i.Selected = True
                End If
            Next
        End If
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = UcDDLDepart.SelectedValue()
        Dim Apply_name As String = UcDDLMember.SelectedValue
        Dim Apply_idcard As String = txtUserID.Text
        Dim Quit_job_flag As String = ddQuit_Job.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim LocationFlag As String = ddlLocationFlag.SelectedValue
        Dim status As String = String.Empty
        'Dim Case_status As String = status
        'cblStatus.SelectedValue
        Dim bll As New FSC2104()
        Dim dt As DataTable = New DataTable

        'For Each cbx As ListItem In cblStatus.Items
        '    If cbx.Selected Then
        '        status += cbx.Value + ","
        '    End If
        '    '        'x = x + 1
        '    '        'ElseIf cbx.Selected And x <> 0 Then
        '    '        '    If status <> "" Then
        '    '        '        status += "," + cbx.Value
        '    '        '    Else
        '    '        '        status += cbx.Value
        '    '        '    End If
        '    '        '    x = x + 1
        'Next

        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            departid = ""
        End If

        Try
            'dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Leave_type, status)
            Dim isSelected As Boolean = False
            For Each i As ListItem In cblStatus.Items
                If i.Selected Then
                    isSelected = True
                    Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                    Dim caseStatus As String = r("code_remark1").ToString()
                    Dim lastPass As String = r("code_remark2").ToString()

                    Dim tmp As DataTable = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Quit_job_flag, PESEX, Start_date, End_date, LocationFlag, caseStatus, lastPass)

                    If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                        dt.Merge(tmp)
                    End If
                End If
            Next

            If Not isSelected Then
                dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Quit_job_flag, PESEX, Start_date, End_date, LocationFlag, "", "")
            End If

            tbq.Visible = True
            dt.Columns.Add("Last_name")
            dt.Columns.Add("DayHours")
            dt.Columns.Add("DetailPlaces")
            dt.Columns.Add("Transport_desc")
            For Each dr As DataRow In dt.Rows
                dr("DayHours") = Content.ConvertDayHours(dr("Leave_hours"))
                dr("Last_name") = ""
                Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(orgcode, dr("flow_id").ToString())
                For Each ddr As DataRow In fd.Rows
                    If Not String.IsNullOrEmpty(dr("Last_name").ToString()) Then
                        dr("Last_name") = dr("Last_name").ToString() + "<br />"
                    End If
                    dr("Last_name") = dr("Last_name").ToString() + New SYS.Logic.CODE().GetFSCTitleName(ddr("Last_posid").ToString()) + " " + ddr("Last_name").ToString()
                Next

                Dim ddt As DataTable = New LeaveMainDetail().getDataByFid(dr("flow_id").ToString())
                For Each ddr As DataRow In ddt.Rows
                    If Not String.IsNullOrEmpty(ddr("DetailPlace").ToString()) Then
                        If ddr("Start_date").ToString = ddr("End_date").ToString Then
                            dr("DetailPlaces") = dr("DetailPlaces").ToString + DateTimeInfo.ToDisplay(ddr("Start_date").ToString) + " " + ddr("DetailPlace").ToString + "<br />"
                        Else
                            dr("DetailPlaces") = dr("DetailPlaces").ToString + DateTimeInfo.ToDisplay(ddr("Start_date").ToString) + "~" + DateTimeInfo.ToDisplay(ddr("End_date").ToString) + " " + ddr("DetailPlace").ToString + "<br />"
                        End If
                    End If
                    If Not String.IsNullOrEmpty(ddr("Transport_desc").ToString()) Then
                        If ddr("Start_date").ToString = ddr("End_date").ToString Then
                            dr("Transport_desc") = dr("Transport_desc").ToString + DateTimeInfo.ToDisplay(ddr("Start_date").ToString) + " " + ddr("Transport_desc").ToString + "<br />"
                        Else
                            dr("Transport_desc") = dr("Transport_desc").ToString + DateTimeInfo.ToDisplay(ddr("Start_date").ToString) + "~" + DateTimeInfo.ToDisplay(ddr("End_date").ToString) + " " + ddr("DetailPlace").ToString + "<br />"
                        End If
                    End If
                Next
            Next

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnPrint.Enabled = True
            Else
                Ucpager.Visible = False
                btnPrint.Enabled = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
#Region "頁數改變時"


    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvList.DataBind()
    End Sub
#End Region

#Region "報表"
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If ViewState("dt") Is Nothing Then
            'Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i).Item("Start_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("Start_date").ToString())
                dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("End_date").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()


            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2104_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "公差紀錄查詢"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If

    End Sub

#End Region

End Class
