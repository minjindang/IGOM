Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports Microsoft.Office.Interop

Partial Class FSC2106_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then Return

        bindDep()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        cblStatus.DataSource = New FSCPLM.Logic.SACode().GetData2("023", "P", "002")
        cblStatus.DataBind()

        If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            tr1.Visible = False
        Else
            For Each i As ListItem In cblStatus.Items
                If i.Value = "001" Or i.Value = "002" Or i.Value = "003" Then
                    i.Selected = True
                End If
            Next
        End If
    End Sub

    Protected Sub bindDep()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = orgcode
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可大於迄日，請重新查詢!")
            Return
        End If
        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim isSecleted As Boolean = False
        Dim dt15 As DataTable = New DataTable()
        Dim dt16 As DataTable = New DataTable()

        For Each i As ListItem In cblStatus.Items
            If i.Selected Then
                isSecleted = True
                Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                Dim caseStatus As String = r("code_remark1").ToString()
                Dim lastPass As String = r("code_remark2").ToString()

                Dim tmpdt15 As DataTable = getTable("15", caseStatus, lastPass)
                If tmpdt15 IsNot Nothing AndAlso tmpdt15.Rows.Count > 0 Then
                    dt15.Merge(tmpdt15)
                End If

                Dim tmpdt16 As DataTable = getTable("16", caseStatus, lastPass)
                If tmpdt16 IsNot Nothing AndAlso tmpdt16.Rows.Count > 0 Then
                    dt16.Merge(tmpdt16)
                End If
            End If
        Next

        If Not isSecleted Then
            dt15 = getTable("15", "", "")
            dt16 = getTable("16", "", "")
        End If

        ViewState("dt15") = dt15
        ViewState("dt16") = dt16

        Me.gvList.DataSource = dt15
        Me.gvList.DataBind()
        If Not Me.gvList.Rows Is Nothing And Me.gvList.Rows.Count > 0 Then
            Me.dataList.Visible = True
            Me.Ucpager1.Visible = True
            EmptyTable.Visible = False
        Else
            Me.dataList.Visible = False
            Me.Ucpager1.Visible = False
            EmptyTable.Visible = True
        End If

        Me.gvList2.DataSource = dt16
        Me.gvList2.DataBind()
        If Not Me.gvList2.Rows Is Nothing And Me.gvList2.Rows.Count > 0 Then
            Me.dataList2.Visible = True
            Me.Ucpager2.Visible = True
            EmptyTable2.Visible = False
        Else
            Me.dataList2.Visible = False
            Me.Ucpager2.Visible = False
            EmptyTable2.Visible = True
        End If

        If (Not Me.gvList.Rows Is Nothing And Me.gvList.Rows.Count > 0) OrElse _
            (Not Me.gvList2.Rows Is Nothing And Me.gvList2.Rows.Count > 0) Then
            Me.btnPrint.Enabled = True
        Else
            Me.btnPrint.Enabled = False
        End If
    End Sub

    Protected Function getTable(ByVal table As String, ByVal status As String, ByVal lasspass As String) As DataTable
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DataTable()
        Dim bll As New FSC2106()
        Try
            dt = bll.getData(orgcode, Me.UcDDLDepart.SelectedValue, Me.UcDate1.Text, Me.UcDate2.Text, table, status, lasspass)
            dt.Columns.Add("FULL_Name")
            dt.Columns.Add("SEdate")
            dt.Columns.Add("Process")
            dt.Columns.Add("Dayhours")

            For Each dr As DataRow In dt.Rows
                dr("DayHours") = Content.ConvertDayHours(dr("Leave_hours").ToString())
                dr("FULL_Name") = dr("Apply_idcard").ToString() + "<br />" + dr("Apply_name").ToString()
                dr("SEdate") = DateTimeInfo.ToDisplay(dr("Start_date").ToString(), dr("Start_time").ToString(), "-") + "<br />" + _
                DateTimeInfo.ToDisplay(dr("End_date").ToString(), dr("End_time").ToString(), "-")

                Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(dr("orgcode").ToString(), dr("flow_id").ToString())
                For Each ddr As DataRow In fd.Rows
                    If Not String.IsNullOrEmpty(dr("Process").ToString()) Then
                        dr("Process") = dr("Process").ToString() + "<br />"
                    End If
                    dr("Process") = dr("Process").ToString() + New SYS.Logic.CODE().GetFSCTitleName(ddr("Last_posid").ToString()) + " " + ddr("Last_name").ToString()
                Next
            Next
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
        Return dt
    End Function

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowList()
    End Sub

#Region "列印"
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If ViewState("dt15") Is Nothing AndAlso ViewState("dt16") Is Nothing Then
            ShowList()
        End If
        Dim dt15 As DataTable = CType(ViewState("dt15"), DataTable)
        Dim dt16 As DataTable = CType(ViewState("dt16"), DataTable)

        If (dt15 Is Nothing OrElse dt15.Rows.Count <= 0) AndAlso (dt16 Is Nothing OrElse dt16.Rows.Count <= 0) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else

            Dim ap As New Excel.Application
            Dim wb As Excel.Workbook
            Dim ws As New Excel.Worksheet
            ap.DisplayAlerts = False
            wb = ap.Workbooks.Add(HttpContext.Current.Server.MapPath("~/Report/FSC/FSC2106_01.xls"))

            If dt15 IsNot Nothing AndAlso dt15.Rows.Count > 0 Then
                ws = CType(wb.Worksheets(1), Excel.Worksheet)
                ws.Activate()
                Dim j As Integer = 0
                For i As Integer = 0 To dt15.Rows.Count - 1
                    j = i + 3
                    ws.Cells(j, 1) = dt15.Rows(i)("Status").ToString()
                    ws.Cells(j, 2) = dt15.Rows(i)("FULL_Name").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 3) = dt15.Rows(i)("DayHours").ToString()
                    ws.Cells(j, 4) = dt15.Rows(i)("SEdate").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 5) = dt15.Rows(i)("Deputy_name").ToString()
                    ws.Cells(j, 6) = dt15.Rows(i)("Process").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 7) = dt15.Rows(i)("Reason").ToString()
                Next
                ws.Range(ws.Cells(3, 1), ws.Cells(j, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            Else
                ws = CType(wb.Worksheets(1), Excel.Worksheet)
                ws.Activate()
                ws.Cells(3, 1) = "無請假資料"
                ws.Range(ws.Cells(3, 1), ws.Cells(3, 7)).Merge()
                ws.Range(ws.Cells(3, 1), ws.Cells(3, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If

            If dt16 IsNot Nothing AndAlso dt16.Rows.Count > 0 Then
                ws = CType(wb.Worksheets(2), Excel.Worksheet)
                ws.Activate()
                Dim j As Integer = 0
                For i As Integer = 0 To dt16.Rows.Count - 1
                    j = i + 3
                    ws.Cells(j, 1) = dt15.Rows(i)("Status").ToString()
                    ws.Cells(j, 2) = dt15.Rows(i)("FULL_Name").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 3) = dt15.Rows(i)("DayHours").ToString()
                    ws.Cells(j, 4) = dt15.Rows(i)("SEdate").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 5) = dt15.Rows(i)("Deputy_name").ToString()
                    ws.Cells(j, 6) = dt15.Rows(i)("Process").ToString().Replace("<br />", Chr(10))
                    ws.Cells(j, 7) = dt15.Rows(i)("Reason").ToString()
                Next
                ws.Range(ws.Cells(3, 1), ws.Cells(j, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            Else
                ws = CType(wb.Worksheets(2), Excel.Worksheet)
                ws.Activate()
                ws.Cells(3, 1) = "無公差資料"
                ws.Range(ws.Cells(3, 1), ws.Cells(3, 7)).Merge()
                ws.Range(ws.Cells(3, 1), ws.Cells(3, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If

            ExcelUtil.toFile(ap, wb, "單位差假現況")
        End If

    End Sub
#End Region

End Class
