Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class FSC2107_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        ' 資料初始化
        InitControl()
    End Sub

    ''' <summary>
    ''' 資料初始化
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlEmployeetype.DataValueField = "code_no"     '所代表的value
        ddlEmployeetype.DataSource = dt                '指定datatable給ddl
        ddlEmployeetype.DataBind()                     'ddl進行Databind
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

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
            tr4.Visible = False
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

    'Sub Clean() Handles btnReset.Click
    '    UcDDLDepart.SelectedValue = ""
    '    txtUsername.Text = String.Empty
    '    txtUserID.Text = String.Empty
    '    UcDate1.Text = String.Empty
    '    UcDate2.Text = String.Empty
    '    ddlQuit_Job.SelectedValue = ""
    '    ddlEmployeetype.SelectedValue = ""

    '    cblStatus.ClearSelection()  'CheckBoxList重置清除勾選

    'End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Depart_id As String = UcDDLDepart.SelectedValue()
        Dim User_name As String = UcDDLMember.SelectedValue
        Dim Id_card As String = UcAuthorityMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        'Dim Case_status As String = String.Empty
        Dim bll As New FSC2107()
        Dim dt As DataTable = New DataTable

        If Start_date > End_date Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位不可大於「迄日」欄位。")
            Return
        End If
        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If

        'For Each cbx As ListItem In cblStatus.Items
        '    If cbx.Selected Then
        '        Case_status += cbx.Value + ","
        '    End If
        'Next

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            Depart_id = ""
        End If

        Try
            'dt = bll.getQueryData(orgcode, Depart_id, User_name, Id_card, Start_date, End_date, Quit_job_flag, Employee_type, Case_status)
            Dim isSelected As Boolean = False
            For Each i As ListItem In cblStatus.Items
                If i.Selected Then
                    isSelected = True
                    Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                    Dim caseStatus As String = r("code_remark1").ToString()
                    Dim lastPass As String = r("code_remark2").ToString()

                    Dim tmp As DataTable = bll.getQueryData(orgcode, Depart_id, User_name, Id_card, Start_date, End_date, Quit_job_flag, Employee_type, caseStatus, lastPass)

                    If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                        dt.Merge(tmp)
                    End If
                End If
            Next

            If Not isSelected Then
                dt = bll.getQueryData(orgcode, Depart_id, User_name, Id_card, Start_date, End_date, Quit_job_flag, Employee_type, "", "")
            End If

            dt.Columns.Add("Process")
            For Each dr As DataRow In dt.Rows
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
            'If gvlist.Rows.Count > 0 Then
            '    Ucpager.Visible = True
            '    btnPrint.Enabled = True
            'Else
            '    Ucpager.Visible = False
            '    btnPrint.Enabled = False
            'End If

            btnPrint.Enabled = True
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub

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
                dt.Rows(i).Item("Forgot_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("Forgot_date").ToString())
                dt.Rows(i).Item("Forgot_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("Forgot_time").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()


            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2107_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "刷卡補登紀錄表"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub
End Class
