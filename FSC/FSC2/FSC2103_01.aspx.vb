Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2103_01
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

        bindTitle()

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlEmployeetype.DataValueField = "code_no"     '所代表的value
        ddlEmployeetype.DataSource = dt                '指定datatable給ddl
        ddlEmployeetype.DataBind()                     'ddl進行Databind
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        'Dim dt2 As DataTable = New FSCPLM.Logic.SACode().GetData("023", "012")
        'ddlJobtype.DataTextField = "code_desc1"   '顯示的中文名稱
        'ddlJobtype.DataValueField = "code_no"     '所代表的value
        'ddlJobtype.DataSource = dt2               '指定datatable給ddl
        'ddlJobtype.DataBind()                     'ddl進行Databind
        'ddlJobtype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        Dim dt3 As DataTable = New SYS.Logic.LeaveType().GetData("15")
        Dim dt4 As DataTable = New DataTable

        Dim psn As Personnel = New Personnel().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        If psn.EmployeeType = "13" Then '駐署人員
            dt4 = dt3.Clone()
            For Each dr As DataRow In dt3.Rows
                If dr("Leave_type") = "01" OrElse dr("Leave_type") = "02" OrElse dr("Leave_type") = "06" OrElse dr("Leave_type") = "19" Then
                    dt4.ImportRow(dr)
                End If
            Next
        Else
            dt4 = dt3
        End If

        If psn.EmployeeType = "13" OrElse psn.EmployeeType = "14" OrElse psn.EmployeeType = "15" Then
            btn.Visible = False
        End If

        cblLeavetype.DataTextField = "Leave_name"   '顯示的中文名稱
        cblLeavetype.DataValueField = "Leave_type"     '所代表的value
        cblLeavetype.DataSource = dt4               '指定datatable給ddl
        cblLeavetype.DataBind()                     'ddl進行Databind

        For Each i As ListItem In cblLeavetype.Items
            i.Selected = True
        Next
        UserName_Bind()

        cblStatus.DataSource = New FSCPLM.Logic.SACode().GetData2("023", "P", "002")
        cblStatus.DataBind()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
            tr4.Visible = False
            tr5.Visible = False
            tr8.Visible = False
        End If

        If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            tr6.Visible = False
            tr7.Visible = False
        Else
            For Each i As ListItem In cblStatus.Items
                If i.Value = "001" Or i.Value = "002" Or i.Value = "003" Then
                    i.Selected = True
                End If
            Next
        End If
    End Sub

    Protected Sub bindTitle()
        cblTitle_no.DataSource = New SYS.Logic.CODE().GetData("023", "012")
        cblTitle_no.DataBind()
    End Sub

    Protected Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        For Each i As ListItem In cblTitle_no.Items
            i.Selected = cbAll.Checked
        Next
    End Sub
#End Region

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = IIf(LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral), "", UcDDLDepart.SelectedValue)
        Dim Apply_name As String = UcDDLMember.SelectedValue
        Dim Apply_idcard As String = txtUserID.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Leave_type As String = String.Empty
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        'Dim Case_status As String = String.Empty

        Dim bll As New FSC2103()
        Dim ddt As DataTable = New DataTable
        Dim dt As DataTable = New DataTable
        Dim count1 = 0
        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        'For Each cbx As ListItem In cblStatus.Items
        '    If cbx.Selected And count1 = 0 Then
        '        Case_status += cbx.Value
        '        count1 = count1 + 1
        '    ElseIf cbx.Selected And count1 <> 0 Then
        '        Case_status += "," + cbx.Value
        '    End If
        'Next

        Dim count = 0
        For Each x As ListItem In cblLeavetype.Items
            If x.Selected And count = 0 Then
                Leave_type += x.Value
                count = count + 1
            ElseIf x.Selected And count <> 0 Then
                Leave_type += "," + x.Value
            End If

        Next
        Try
            'dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Title_no, Quit_job_flag, PESEX, Start_date, End_date, Leave_type, _
            '                      Employee_type, Case_status)
            '=========================================
            'Dim dt2 As DataTable

            'dt.Columns.Add(New DataColumn("Last_name", GetType(String)))
            ''Dim flow_id As Integer = 0
            'Dim string1 As String = New String("")
            ''Dim sb As New System.Text.StringBuilder()

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    dt2 = bll.getQueryData2(dt.Rows(i).Item("flow_id").ToString)
            '    For j As Integer = 0 To dt2.Rows.Count - 1
            '        string1 = string1 + dt2.Rows(j).Item("Last_name").ToString & vbCrLf
            '    Next
            '    dt.Rows(i).Item("Last_name") = string1
            '    string1 = String.Empty
            'Next
            ''===============================================
            Dim isSelected As Boolean = False
            For Each i As ListItem In cblStatus.Items
                If i.Selected Then
                    isSelected = True
                    Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                    Dim caseStatus As String = r("code_remark1").ToString()
                    Dim lastPass As String = r("code_remark2").ToString()

                    Dim tmp As DataTable = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, "", Quit_job_flag, PESEX, Start_date, End_date, Leave_type, _
                                  Employee_type, caseStatus, lastPass)

                    If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                        ddt.Merge(tmp)
                    End If
                End If
            Next

            If Not isSelected Then
                ddt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, "", Quit_job_flag, PESEX, Start_date, End_date, Leave_type, _
                                  Employee_type, "", "")
            End If

            Dim Title_no As String = ""
            For Each i As ListItem In cblTitle_no.Items
                If i.Selected Then
                    Title_no &= "'" + i.Value.ToString + "',"
                End If
            Next

            dt = ddt.Clone()
            If Not String.IsNullOrEmpty(Title_no) AndAlso ddt.Rows.Count > 0 Then
                Dim rows() As DataRow = ddt.Select(String.Format(" Title_no in ({0})", Title_no.TrimEnd(",")))
                For Each dr As DataRow In rows
                    dt.ImportRow(dr)
                Next
            Else
                dt.Merge(ddt)
            End If

            dt.Columns.Add("Process")
            dt.Columns.Add("DayHours")
            For Each dr As DataRow In dt.Rows
                dr("DayHours") = Content.ConvertDayHours(dr("Leave_hours"))
                Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(dr("orgcode").ToString(), dr("flow_id").ToString())
                For Each ddr As DataRow In fd.Rows
                    If Not String.IsNullOrEmpty(dr("Process").ToString()) Then
                        dr("Process") = dr("Process").ToString() + "<br />"
                    End If
                    dr("Process") = dr("Process").ToString() + New SYS.Logic.CODE().GetFSCTitleName(ddr("Last_posid").ToString()) + " " + ddr("Last_name").ToString()
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
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i).Item("Start_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("start_date").ToString())
                dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("end_date").ToString())
                dt.Rows(i).Item("Start_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("Start_time").ToString())
                dt.Rows(i).Item("End_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("End_time").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2103_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "請假查詢紀錄表"
            theDTReport.ExportToExcel()
            dt.Dispose()
        End If
    End Sub
#End Region

    Protected Sub btn_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC2129_01.aspx")
    End Sub
End Class
