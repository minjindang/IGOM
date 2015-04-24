Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2112_01
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim Case_status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart

        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        UserName_Bind()

        'Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        'ddlEmployeetype.DataTextField = "code_desc1"   '顯示的中文名稱
        'ddlEmployeetype.DataValueField = "code_no"     '所代表的value
        'ddlEmployeetype.DataSource = dt                '指定datatable給ddl
        'ddlEmployeetype.DataBind()                     'ddl進行Databind
        'ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"
        ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", ""))
        ddlsextype.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

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
        Dim Apply_idcard As String = UcAuthorityMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim Leavehours As String = String.Empty
        Dim type As String = rblReporttype.SelectedValue
        Dim yyymm As String
        Dim tmpdt As DataTable = New DataTable
        Dim bll As New FSC2112()
        Dim dt, dt2 As DataTable

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
        Try

            If Mid(Start_date, 1, 5) = Mid(End_date, 1, 5) Then
                dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, Left(Start_date, 5), type)
            Else
                Dim S As Date = Date.Parse(Start_date.Substring(0, 3) + "/" + Start_date.Substring(3, 2) + "/" + "01")
                Dim L As Date = Date.Parse(End_date.Substring(0, 3) + "/" + End_date.Substring(3, 2) + "/" + "01")

                dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, Left(Start_date, 5), type)
                While S < L
                    S = S.AddMonths(1)
                    yyymm = S.Year.ToString() + S.Month.ToString().PadLeft(2, "0")
                    tmpdt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, yyymm, type)
                    dt.Merge(tmpdt)
                End While
            End If

            dt.Columns.Add("Leavehours")
            dt.Columns.Add("Leavetype")
            dt.Columns.Add("Absenthours")
            For Each dr As DataRow In dt.Rows
                dt2 = bll.getQueryData2(dr("PKCARD").ToString.Trim, dr("PKWDATE").ToString)
                If dt2.Rows.Count = 0 Then  'Leave_main裡沒有請假資料
                    dr("Absenthours") = 8
                End If
                For Each dr2 As DataRow In dt2.Rows
                    If Not String.IsNullOrEmpty(dr("Leavetype").ToString) Then
                        dr("Leavetype") = dr("Leavetype").ToString() + "<br />"
                    End If
                    dr("Leavetype") = dr("Leavetype").ToString() + dr2("leave_name").ToString()


                    If Not String.IsNullOrEmpty(dr("Leavehours").ToString()) Then
                        dr("Leavehours") = dr("Leavehours") & "<br />"
                    End If

                    If dr("PKWDATE") = dr2("Start_date") = dr2("End_date") Then 'same day
                        Leavehours = Content.computeNotWorkHour(dr2("Start_date").ToString, dr2("End_date").ToString, _
                                        dr2("Start_time").ToString, dr2("End_time").ToString, dr2("Id_card").ToString)
                        dr("Leavehours") = dr("Leavehours") & Content.computeNotWorkHour(dr2("Start_date").ToString, dr2("End_date").ToString, _
                                        dr2("Start_time").ToString, dr2("End_time").ToString, dr2("Id_card").ToString)
                    Else
                        Dim ht As Hashtable = Content.getWorkTime(dr("PKCARD"), dr("PKWDATE")) 'compute Id_card work hours

                        If dr("PKWDATE") = dr2("Start_date") Then
                            Leavehours = Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE").ToString, dr2("Start_time"), _
                                                                         ht.Item("WORKTIMEE").ToString, dr2("Id_card").ToString)

                            dr("Leavehours") = dr("Leavehours") & Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE").ToString, dr2("Start_time"), _
                                                                          ht.Item("WORKTIMEE").ToString, dr2("Id_card").ToString)


                        ElseIf dr("PKWDATE") > dr2("Start_date") And dr("PKWDATE") < dr2("End_date") Then
                            Leavehours = Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE"), ht.Item("WORKTIMEB"), ht.Item("WORKTIMEE"), _
                                                          dr2("Id_card").ToString)
                            dr("Leavehours") = dr("Leavehours") & Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE"), ht.Item("WORKTIMEB"), ht.Item("WORKTIMEE"), _
                                                                          dr2("Id_card").ToString)

                        ElseIf dr("PKWDATE") = dr2("End_date") Then
                            Leavehours = Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE"), ht.Item("WORKTIMEB").ToString, _
                                                                       dr2("End_time").ToString, dr2("Id_card").ToString)
                            dr("Leavehours") = dr("Leavehours") & Content.computeNotWorkHour(dr("PKWDATE"), dr("PKWDATE"), ht.Item("WORKTIMEB").ToString, _
                                                                          dr2("End_time").ToString, dr2("Id_card").ToString)
                        End If
                    End If

                    If Not String.IsNullOrEmpty(dr("Absenthours").ToString()) Then
                        dr("Absenthours") = dr("Absenthours") & "<br />"
                    End If
                    If dr("PKWKTPE").Equals("已處理") Or dr("PKWKTPE").Equals("正常") Then
                        dr("Absenthours") = dr("Absenthours") & 0
                    ElseIf dr("PKWKTPE").Equals("曠職") And dr("Leavetype") Is Nothing Then   '假單還沒有簽核完成
                        dr("Absenthours") = 8
                    Else                                                                        '假單簽核完成
                        dr("Absenthours") = 8 - dr("Leavehours")
                    End If
                Next
            Next
            tbq.Visible = True
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            'btnPrint.Enabled = True
            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExport.Enabled = True
            Else
                Ucpager.Visible = False
                btnExport.Enabled = False
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
                dt.Rows(i).Item("no") = i + 1 'EXCEL 的編號
                dt.Rows(i).Item("PKWDATE") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                dt.Rows(i).Item("PKSTIME") = FSCPLM.Logic.DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                dt.Rows(i).Item("PKETIME") = FSCPLM.Logic.DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())
                'dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("End_date").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()

            If rblReporttype.SelectedValue = 0 Then
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2112_01_RPT.mht"), dt)
                theDTReport.Param = strParam

                theDTReport.ExportFileName = "替代役出勤紀錄表"
                theDTReport.ExportToExcel()
            Else
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2112_02_RPT.mht"), dt)
                theDTReport.Param = strParam

                theDTReport.ExportFileName = "替代役出勤異常紀錄表"
                theDTReport.ExportToExcel()

            End If

            dt.Dispose()
        End If

    End Sub

#End Region

End Class
