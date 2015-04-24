Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2_FSC2119_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        ' 繫結【提報單位】
        Me.bindDeputyDep()

        ' 繫結【日期】
        Me.UcCouncilDateStart.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        Me.UcCouncilDateEnd.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
    End Sub

    ''' <summary>
    ''' 繫結【提報單位】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindDeputyDep()
        Dim bll As New FSC.Logic.FSC2119()

        Me.cblDept.DataTextField = "DepartName"
        Me.cblDept.DataValueField = "DepartID"
        Me.cblDept.DataSource = bll.GetRewordDepart()
        Me.cblDept.DataBind()
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Me.gvList01.Visible = False
        Me.gvList02.Visible = False

        If Me.UcCouncilDateStart.Text = "" And Me.UcCouncilDateEnd.Text <> "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【考績會日期】起日未輸入，請重新查詢!")
            Return
        End If
        If Me.UcCouncilDateStart.Text > Me.UcCouncilDateEnd.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【考績會日期】起日不可大於迄日，請重新查詢!")
            Return
        End If

        ' 依查詢條件顯示查詢結果
        Me.ShowList(Me.ddlReportType.SelectedValue, "1")

    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <param name="szType">1:【敘獎提案數統計表】/2:【敘獎統計表】</param>
    ''' <param name="szAction">1:【查詢】/2:【匯出】</param>
    ''' <remarks></remarks>
    Protected Sub ShowList(ByVal szType As String, ByVal szAction As String)
        Dim bll As New FSC.Logic.FSC2119()
        Dim dtData As DataTable

        ' 串連【提報單位】已勾選的單位名稱
        Dim szDept As String = String.Empty

        For index = 0 To Me.cblDept.Items.Count - 1
            If cblDept.Items(index).Selected Then
                If szDept = "" Then
                    szDept += "'" + cblDept.Items(index).Value + "'"
                Else
                    szDept += ",'" + cblDept.Items(index).Value + "'"
                End If
            End If
        Next

        ' 【考績會名稱】資料，置入陣列
        dtData = bll.GetRewordCouncilName(szDept, Me.UcCouncilDateStart.Text, Me.UcCouncilDateEnd.Text)

        If szType = "1" Then
            dtData = bll.GetReportData01(szDept, Me.UcCouncilDateStart.Text, Me.UcCouncilDateEnd.Text, dtData)
            ViewState("dt1") = dtData
            If szAction = "1" Then
                Me.gvList01.DataSource = dtData
                Me.gvList01.DataBind()

                Me.gvList01.Visible = True
            Else
                Me.grdExcel.DataSource = dtData
                Me.grdExcel.DataBind()
            End If
            
        Else
            dtData = bll.GetReportData02(szDept, Me.UcCouncilDateStart.Text, Me.UcCouncilDateEnd.Text, dtData)
            ViewState("dt2") = dtData
            If szAction = "1" Then
                Me.gvList02.DataSource = dtData
                Me.gvList02.DataBind()

                Me.gvList02.Visible = True
            Else
                Me.grdExcel.DataSource = dtData
                Me.grdExcel.DataBind()
            End If
        End If
    End Sub
    Protected Sub gvList01_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvList01.PageIndexChanging
        Me.gvList01.PageIndex = e.NewPageIndex

        ' 依查詢條件顯示查詢結果
        Me.ShowList(Me.ddlReportType.SelectedValue, "1")
    End Sub

    Protected Sub gvList02_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvList02.PageIndexChanging
        Me.gvList02.PageIndex = e.NewPageIndex

        ' 依查詢條件顯示查詢結果
        Me.ShowList(Me.ddlReportType.SelectedValue, "1")
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Response.Clear()
        If Me.ddlReportType.SelectedValue = "1" Then
            Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("敘獎提案數統計表", UTF8Encoding.UTF8) & ".xls")
        Else
            Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("敘獎提案數統計表", UTF8Encoding.UTF8) & ".xls")
        End If

        Response.ContentType = "application/vnd.xls"
        Dim sw As New System.IO.StringWriter
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)


        Dim szHeader As String = String.Empty

        If Me.ddlReportType.SelectedValue = "1" Then
            szHeader += "敘獎提案數統計表<br/>"
        Else
            szHeader += "敘獎統計表<br/>"
        End If

        ' 串連【提報單位】已勾選的單位名稱
        Dim szDept As String = String.Empty

        For index = 0 To Me.cblDept.Items.Count - 1
            If cblDept.Items(index).Selected Then
                If szDept = "" Then
                    szDept += "'" + cblDept.Items(index).Value + "'"
                Else
                    szDept += ",'" + cblDept.Items(index).Value + "'"
                End If
            End If
        Next

        If szDept <> "" Then
            szHeader += "提報單位：" + szDept + "<br/>"
        End If


        If Me.UcCouncilDateStart.Text <> "" Then
            szHeader += "考績會日期：" + Me.UcCouncilDateStart.Text
            If Me.UcCouncilDateEnd.Text <> "" Then
                szHeader += "~" + Me.UcCouncilDateEnd.Text
            End If
            szHeader += "<br/>"
        End If

        szHeader += "<br/>"

        htw.WriteLine(szHeader)

        '顯示列印資料
        grdExcel.Visible = True

        '關閉分頁排序
        grdExcel.AllowPaging = False
        grdExcel.AllowSorting = False

        '查詢需列印之資料
        Me.ShowList(Me.ddlReportType.SelectedValue, "2")

        '交付選擇之資料
        grdExcel.RenderControl(htw)

        '設定編碼為UTF-8
        Response.ContentEncoding = Encoding.GetEncoding("big5")

        '丟出完成之資料
        Response.Write(sw.ToString())
        Response.End()

        '開啟分頁排序
        grdExcel.AllowPaging = True
        grdExcel.AllowSorting = True

        '關閉列印資料
        grdExcel.Visible = False
        grdExcel.DataBind()
    End Sub

    '防止 runat=server錯誤使用
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
    End Sub

    Protected Sub gvList01_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gvList01.RowCreated
        Dim dt As DataTable = CType(ViewState("dt1"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                For i As Integer = 2 To dt.Columns.Count - 1
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right
                Next
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                Dim footer As TableCellCollection = e.Row.Cells
                footer.Clear()
                Dim tc1 As New TableCell()
                tc1.Text = "合計"
                tc1.ColumnSpan = 2
                tc1.HorizontalAlign = HorizontalAlign.Right
                footer.Add(tc1)

                For i As Integer = 2 To dt.Columns.Count - 1
                    Dim tc2 As New TableCell()
                    For Each gvr As GridViewRow In gvList01.Rows
                        tc2.Text = CommonFun.getInt(tc2.Text) + CommonFun.getInt(gvr.Cells(i).Text)
                    Next
                    tc2.HorizontalAlign = HorizontalAlign.Right
                    footer.Add(tc2)
                Next
            End If
        End If
    End Sub

    Protected Sub gvList02_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gvList02.RowCreated
        Dim dt As DataTable = CType(ViewState("dt2"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                For i As Integer = 3 To dt.Columns.Count - 1
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right
                Next
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                Dim footer As TableCellCollection = e.Row.Cells
                footer.Clear()
                Dim tc1 As New TableCell()
                tc1.Text = "合計"
                tc1.ColumnSpan = 3
                tc1.HorizontalAlign = HorizontalAlign.Right
                footer.Add(tc1)

                For i As Integer = 3 To dt.Columns.Count - 1
                    Dim tc2 As New TableCell()
                    For Each gvr As GridViewRow In gvList02.Rows
                        tc2.Text = CommonFun.getInt(tc2.Text) + CommonFun.getInt(gvr.Cells(i).Text)
                    Next
                    tc2.HorizontalAlign = HorizontalAlign.Right
                    footer.Add(tc2)
                Next
            End If
        End If
    End Sub

    Protected Sub grdExcel_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdExcel.RowCreated
        Dim dt As DataTable = New DataTable
        Dim beginCells As Integer = 0
        If Me.ddlReportType.SelectedValue = "1" Then
            dt = CType(ViewState("dt1"), DataTable)
            beginCells = 2
        Else
            dt = CType(ViewState("dt2"), DataTable)
            beginCells = 3
        End If

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim footer As TableCellCollection = e.Row.Cells
                footer.Clear()
                Dim tc1 As New TableCell()
                tc1.Text = "合計"
                tc1.ColumnSpan = beginCells
                tc1.HorizontalAlign = HorizontalAlign.Right
                footer.Add(tc1)

                For i As Integer = beginCells To dt.Columns.Count - 1
                    Dim tc2 As New TableCell()
                    For Each gvr As GridViewRow In grdExcel.Rows
                        tc2.Text = CommonFun.getInt(tc2.Text) + CommonFun.getInt(gvr.Cells(i).Text)
                    Next
                    tc2.HorizontalAlign = HorizontalAlign.Right
                    footer.Add(tc2)
                Next
            End If
        End If
    End Sub
End Class
