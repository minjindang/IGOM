Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class FSC2105_01
    Inherits BaseWebForm

    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart
        InitControl()
    End Sub

#Region "顯示下拉選單"

    Protected Sub InitControl()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        UserName_Bind()

        cblStatus.DataSource = New FSCPLM.Logic.SACode().GetData2("023", "P", "002")
        cblStatus.DataBind()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
        End If

        If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            tr2.Visible = False
            tr3.Visible = False
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

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可大於迄日，請重新查詢!")
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue

        Dim PRCARD As String = UcPersonal_id.PersonnelId
        Dim PRNAME As String = UcDDLMember.SelectedValue
        Dim PRADDD As String = UcDate1.Text
        Dim PRADDE As String = UcDate2.Text
        Dim status As String = String.Empty
        'Dim Case_status As String = status
        'cblStatus.SelectedValue
        Dim bll As New FSC.Logic.FSC2105()
        Dim dt As DataTable = New DataTable

        'For Each cbx As ListItem In cblStatus.Items
        '    If cbx.Selected Then
        '        status += cbx.Value + ","
        '    End If
        'Next
        'Dim count1 = 0
        'For Each cbx As ListItem In cblStatus.Items
        '    If cbx.Selected And count1 = 0 Then
        '        Case_status += cbx.Value
        '        count1 = count1 + 1
        '    ElseIf cbx.Selected And count1 <> 0 Then
        '        Case_status += "," + cbx.Value
        '    End If
        'Next

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            Depart_id = ""
        End If

        Try
            'dt = bll.getQueryData(Orgcode, Depart_id, PRCARD, PRNAME, PRADDD, PRADDE, Case_status)
            Dim isSelected As Boolean = False
            For Each i As ListItem In cblStatus.Items
                If i.Selected Then
                    isSelected = True
                    Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                    Dim caseStatus As String = r("code_remark1").ToString()
                    Dim lastPass As String = r("code_remark2").ToString()

                    Dim tmp As DataTable = bll.getQueryData(Orgcode, Depart_id, PRCARD, PRNAME, PESEX, PRADDD, PRADDE, caseStatus, lastPass)

                    If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                        dt.Merge(tmp)
                    End If
                End If
            Next

            If Not isSelected Then
                dt = bll.getQueryData(Orgcode, Depart_id, PRCARD, PRNAME, PESEX, PRADDD, PRADDE, "", "")
            End If

            tbq.Visible = True
            dt.Columns.Add("Last_name")
            For Each dr As DataRow In dt.Rows
                dr("Last_name") = ""
                Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(Orgcode, dr("flow_id").ToString())
                For Each ddr As DataRow In fd.Rows
                    If Not String.IsNullOrEmpty(dr("Last_name").ToString()) Then
                        dr("Last_name") = dr("Last_name").ToString() + "<br />"
                    End If
                    dr("Last_name") = dr("Last_name").ToString() + New SYS.Logic.CODE().GetFSCTitleName(ddr("Last_posid").ToString()) + " " + ddr("Last_name").ToString()
                Next
            Next

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            If gvlist.Rows.Count > 0 Then
                btnExport.Enabled = True
            Else
                btnExport.Enabled = False
            End If

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

    Protected Sub gvlist_DataBound(sender As Object, e As EventArgs) Handles gvlist.DataBound

        '產發會不顯示以下欄位 by jessica modi 20131217
        If OrgType.ToLower().Contains("expo") Then
            gvlist.Columns(11).Visible = False
            gvlist.Columns(14).Visible = False
        End If
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

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()


            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2105_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "加班紀錄查詢" '& Format(Now.Date, "yyMMdd")
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub
#End Region

End Class
