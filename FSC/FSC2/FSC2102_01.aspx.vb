Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2102_01
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

        UcDDLDepart.orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlEmployeetype.DataValueField = "code_no"     '所代表的value
        ddlEmployeetype.DataSource = dt                '指定datatable給ddl
        ddlEmployeetype.DataBind()                     'ddl進行Databind
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        UserName_Bind()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
            tr4.Visible = False
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



    Function Get_date(ByVal V_Date As String) As String
        If V_Date Is System.DBNull.Value Then Return ""
        Dim WorkStr As String = ""
        If Not String.IsNullOrEmpty(V_Date) Then
            WorkStr = Replace(V_Date, "-", "/")
            If CInt(Split(CStr(WorkStr), " ").Length) > 1 Then
                WorkStr = Split(WorkStr, " ")(0)
            Else
                WorkStr = WorkStr
            End If
        Else
            WorkStr = ""
        End If
        Return WorkStr
    End Function


    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = UcDDLDepart.SelectedValue()
        Dim Apply_name As String = UcDDLMember.SelectedValue
        Dim Apply_idcard As String = txtUserID.Text
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim Leavehours As String = String.Empty
        Dim type As String = rblReporttype.SelectedValue
        Dim dt, dt2 As DataTable
        Dim bll As New FSC2102()

        If Start_date > End_date Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位不可大於「迄日」欄位。")
            Return
        End If
        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「迄日」欄位為必填。")
            Return
        End If

        Dim Type2 As String = String.Empty

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            '指定人員時
            departid = ""
        End If

        Dim stag As String = "<span style='color:#FF8C00; text-decoration: underline;'>"
        Dim etag As String = "</span>"

        dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, type)

        dt.Columns.Add("Leavehours")
        dt.Columns.Add("Leavetype")
        dt.Columns.Add("Absenthours")


        'hsien 效能考量 移至 gvlist_RowDataBound
        'For Each dr As DataRow In dt.Rows
        '    '20140620 先mark 
        '    'If Not dr("PKWKTPE").Equals("已處理") And Not dr("PKWKTPE").Equals("正常") And dt2.Rows.Count = 0 Then  'Leave_main裡沒有請假資料
        '    '    dr("Absenthours") = 8
        '    'End If
        '    'Dim hours As Integer = 0
        '    For Each dr2 As DataRow In dt2.Rows
        '        'hours += CommonFun.getInt(dr2("Leave_hours").ToString())
        '        Dim lastPass As String = dr2("Last_pass").ToString()
        '        If lastPass = "1" Then
        '            stag = ""
        '            etag = ""
        '        End If
        '        If Not String.IsNullOrEmpty(dr("Leavetype").ToString) Then
        '            dr("Leavetype") &= "<br />"
        '        End If
        '        If Not String.IsNullOrEmpty(dr("Leavehours").ToString()) Then
        '            dr("Leavehours") &= "<br />"
        '        End If
        '        dr("Leavetype") &= stag & dr2("leave_name").ToString() & etag
        '        dr("Leavehours") &= stag & dr2("Leave_hours").ToString() & etag
        '    Next
        '    '20140620 先mark 
        '    'If Not String.IsNullOrEmpty(dr("Absenthours").ToString()) Then
        '    '    dr("Absenthours") = dr("Absenthours") & "<br />"
        '    'End If
        '    'If dr("PKWKTPE").Equals("已處理") Or dr("PKWKTPE").Equals("正常") Then
        '    '    dr("Absenthours") = dr("Absenthours") & 0
        '    'ElseIf dr("PKWKTPE").Equals("曠職") And dr("Leavetype") Is Nothing Then   '假單還沒有簽核完成
        '    '    dr("Absenthours") = 8
        '    'Else                                                                        '假單簽核完成
        '    '    dr("Absenthours") = 8 - hours
        '    'End If
        'Next

        tbq.Visible = True
        ViewState("dt") = dt
        Me.gvlist.DataSource = dt

        Me.gvlist.DataBind()
        dt.Dispose()

        If gvlist.Rows.Count > 0 Then
            Ucpager.Visible = True
            btnExport.Enabled = True
        Else
            Ucpager.Visible = False
            btnExport.Enabled = False
        End If
        tbq.Visible = True
        

    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

#Region "報表"
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If ViewState("dt") Is Nothing Then
            'Bind()
        End If
        If rblReporttype.SelectedValue.Equals("") Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「請選擇輸出報表格式」")
            Return
        End If
  
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i).Item("PKWDATE") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                dt.Rows(i).Item("PKSTIME") = FSCPLM.Logic.DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                dt.Rows(i).Item("PKETIME") = FSCPLM.Logic.DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()

            If rblReporttype.SelectedValue = 0 Then
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2102_01_RPT.mht"), dt)
                theDTReport.Param = strParam

                theDTReport.ExportFileName = "出勤紀錄表"
                theDTReport.ExportToExcel()
            Else
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2102_02_RPT.mht"), dt)
                theDTReport.Param = strParam

                theDTReport.ExportFileName = "出勤異常紀錄表"
                theDTReport.ExportToExcel()

            End If

            dt.Dispose()
        End If

    End Sub

#End Region

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim bll As New FSC2102()
            Dim PKCARD As String = CType(e.Row.FindControl("hfPKCARD"), HiddenField).Value
            Dim PKWDATE As String = CType(e.Row.FindControl("hfPKWDATE"), HiddenField).Value
            Dim stag As String = "<span style='color:#FF8C00; text-decoration: underline;'>"
            Dim etag As String = "</span>"

            Dim dt2 As DataTable = bll.getQueryData2(LoginManager.OrgCode, PKCARD, PKWDATE)
            Dim tmpLeaveType As New StringBuilder()
            Dim tmpLeaveHour As New StringBuilder()
            For Each dr2 As DataRow In dt2.Rows
                Dim lastPass As String = dr2("Last_pass").ToString()
                If lastPass = "1" Then
                    stag = ""
                    etag = ""
                End If

                If Not String.IsNullOrEmpty(tmpLeaveType.ToString()) Then
                    tmpLeaveType.Append("<br />")
                End If
                If Not String.IsNullOrEmpty(tmpLeaveHour.ToString()) Then
                    tmpLeaveHour.Append("<br />")
                End If

                tmpLeaveType.Append(stag & dr2("leave_name").ToString() & etag)
                tmpLeaveHour.Append(stag & dr2("Leave_hours").ToString() & etag)
            Next

            CType(e.Row.FindControl("lbLeave_type"), Label).Text = tmpLeaveType.ToString()
            CType(e.Row.FindControl("lbleave_hours"), Label).Text = tmpLeaveHour.ToString()

        End If



    End Sub
End Class
