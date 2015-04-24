Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2_FSC2118_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        ' 繫結【提報單位】【獎懲人員單位】
        Me.bindDeputyDep()

        '繫結【官職等】
        Me.bindLevel()

        ' 繫結【日期】
        'Me.UcCouncilDateStart.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        'Me.UcCouncilDateEnd.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        'Me.UcApplyDateStart.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        'Me.UcApplyDateEnd.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        'Me.UcRewordDateStart.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        'Me.UcRewordDateEnd.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
    End Sub

    ''' <summary>
    ''' 繫結【提報單位】【獎懲人員單位】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindDeputyDep()
        Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim szDdepartID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        Me.ddlDept.Orgcode = szOrgcode
        'Me.ddlDept.SelectedValue = szDdepartID

        Me.ddlRewordDepartID.Orgcode = szOrgcode
        ddlRewordDepartID.Sub_Visible = False
        'Me.ddlRewordDepartID.SelectedValue = szDdepartID
    End Sub

    ''' <summary>
    ''' 繫結【官職等】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindLevel()
        Me.ddlRewordLevel.DataTextField = "CODE_DESC1"
        Me.ddlRewordLevel.DataValueField = "CODE_NO"
        Me.ddlRewordLevel.DataSource = New FSCPLM.Logic.SACode().GetData("023", "031")
        Me.ddlRewordLevel.DataBind()

        Me.ddlRewordLevel.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        'If Me.UcApplyDateStart.Text = "" And Me.UcApplyDateEnd.Text <> "" Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【提報日期】起日未輸入，請重新查詢!")
        '    Return
        'End If
        'If Me.UcApplyDateStart.Text <> "" And Me.UcApplyDateEnd.Text <> "" And Me.UcApplyDateStart.Text > Me.UcApplyDateEnd.Text Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【提報日期】起日不可大於迄日，請重新查詢!")
        '    Return
        'End If

        'If Me.UcRewordDateStart.Text = "" And Me.UcRewordDateEnd.Text <> "" Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【獎勵令日期】起日未輸入，請重新查詢!")
        '    Return
        'End If
        'If Me.UcRewordDateStart.Text > Me.UcRewordDateEnd.Text Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【獎勵令日期】起日不可大於迄日，請重新查詢!")
        '    Return
        'End If

        'If Me.UcCouncilDateStart.Text = "" And Me.UcCouncilDateEnd.Text <> "" Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【考績會日期】起日未輸入，請重新查詢!")
        '    Return
        'End If
        'If Me.UcCouncilDateStart.Text > Me.UcCouncilDateEnd.Text Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【考績會日期】起日不可大於迄日，請重新查詢!")
        '    Return
        'End If

        If Me.UcApplyDateStart.Text <> "" AndAlso Me.UcApplyDateEnd.Text <> "" Then
            If Me.UcApplyDateStart.Text > Me.UcApplyDateEnd.Text Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【提報日期】起日不可大於迄日，請重新查詢!")
                Return
            End If
        End If

        If Me.UcRewordDateStart.Text <> "" And Me.UcRewordDateEnd.Text <> "" Then
            If Me.UcRewordDateStart.Text > Me.UcRewordDateEnd.Text Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【獎勵令日期】起日不可大於迄日，請重新查詢!")
                Return
            End If
        End If

        If Me.UcCouncilDateStart.Text <> "" And Me.UcCouncilDateEnd.Text <> "" Then
            If UcCouncilDateStart.Text > Me.UcCouncilDateEnd.Text Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件【考績會日期】起日不可大於迄日，請重新查詢!")
                Return
            End If
        End If

        ' 依查詢條件顯示查詢結果
        ShowList()
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ShowList()
        Dim bll As New FSC.Logic.FSC2118()

        Dim dtData As DataTable = bll.getData("023", "031", Me.ddlDept.SelectedValue, Me.UcCouncilDateStart.Text, Me.UcCouncilDateEnd.Text, Me.UcApplyDateStart.Text, Me.UcApplyDateEnd.Text, Me.UcRewordDateStart.Text, Me.UcRewordDateEnd.Text, Me.tbRewordDoc.Text, Me.ddlRewordDepartID.SelectedValue, Me.ddlRewordLevel.SelectedValue)

        Me.gvList.DataSource = dtData
        Me.gvList.DataBind()
    End Sub
    ' ''' <summary>
    ' ''' 依查詢條件顯示查詢結果
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Protected Sub ShowReportList()
    '    Dim bll As New FSC.Logic.FSC2118()

    '    Dim szArray As String() = New String(16) {}
    '    szArray(0) = Me.cbExport01.Checked.ToString()
    '    szArray(1) = Me.cbExport02.Checked.ToString()
    '    szArray(2) = Me.cbExport03.Checked.ToString()
    '    szArray(3) = Me.cbExport04.Checked.ToString()
    '    szArray(4) = Me.cbExport05.Checked.ToString()
    '    szArray(5) = Me.cbExport06.Checked.ToString()
    '    szArray(6) = Me.cbExport07.Checked.ToString()
    '    szArray(7) = Me.cbExport08.Checked.ToString()
    '    szArray(8) = Me.cbExport09.Checked.ToString()
    '    szArray(9) = Me.cbExport10.Checked.ToString()
    '    szArray(10) = Me.cbExport11.Checked.ToString()
    '    szArray(11) = Me.cbExport12.Checked.ToString()
    '    szArray(12) = Me.cbExport13.Checked.ToString()
    '    szArray(13) = Me.cbExport14.Checked.ToString()
    '    szArray(14) = Me.cbExport15.Checked.ToString()
    '    szArray(15) = Me.cbExport16.Checked.ToString()
    '    szArray(16) = Me.cbExport17.Checked.ToString()

    '    Dim dtData As DataTable
    '    dtData = bll.getReportData(szArray, Me.ddlDept.SelectedValue, Me.UcCouncilDateStart.Text, Me.UcCouncilDateEnd.Text, Me.UcApplyDateStart.Text, Me.UcApplyDateEnd.Text, Me.UcRewordDateStart.Text, Me.UcRewordDateEnd.Text, Me.tbRewordDoc.Text, Me.ddlRewordDepartID.SelectedValue, Me.ddlRewordLevel.SelectedValue)

    '    Me.grdExcel.DataSource = dtData
    '    Me.grdExcel.DataBind()
    'End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        ' 依查詢條件顯示查詢結果
        ShowList()
    End Sub

#Region "列印"
    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Response.Clear()
    '    Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("敘獎紀錄查詢", UTF8Encoding.UTF8) & ".xls")
    '    Response.ContentType = "application/vnd.xls"
    '    Dim sw As New System.IO.StringWriter
    '    Dim htw As New System.Web.UI.HtmlTextWriter(sw)


    '    Dim szHeader As String = String.Empty
    '    szHeader += "敘獎紀錄查詢<br/>"

    '    If Me.ddlDept.SelectedValue <> "" Then
    '        szHeader += "提報單位：" + Me.ddlDept.SelectedValue + "<br/>"
    '    End If

    '    If Me.UcCouncilDateStart.Text <> "" Then
    '        szHeader += "考績會日期：" + Me.UcCouncilDateStart.Text
    '        If Me.UcCouncilDateEnd.Text <> "" Then
    '            szHeader += "~" + Me.UcCouncilDateEnd.Text
    '        End If
    '        szHeader += "<br/>"
    '    End If

    '    If Me.UcApplyDateStart.Text <> "" Then
    '        szHeader += "提報日期：" + Me.UcApplyDateStart.Text
    '        If Me.UcApplyDateEnd.Text <> "" Then
    '            szHeader += "~" + Me.UcApplyDateEnd.Text
    '        End If
    '        szHeader += "<br/>"
    '    End If

    '    If Me.UcRewordDateStart.Text <> "" Then
    '        szHeader += "獎勵令日期：" + Me.UcRewordDateStart.Text
    '        If Me.UcRewordDateEnd.Text <> "" Then
    '            szHeader += "~" + Me.UcRewordDateEnd.Text
    '        End If
    '        szHeader += "<br/>"
    '    End If

    '    If Me.tbRewordDoc.Text <> "" Then
    '        szHeader += "獎勵令文號：" + Me.tbRewordDoc.Text + "<br/>"
    '    End If

    '    If Me.ddlRewordDepartID.SelectedValue <> "" Then
    '        szHeader += "獎懲人員單位：" + Me.ddlRewordDepartID.SelectedItem.Text + "<br/>"
    '    End If

    '    If Me.ddlRewordLevel.SelectedValue <> "" Then
    '        szHeader += "官職等：" + Me.ddlRewordLevel.SelectedItem.Text + "<br/>"
    '    End If

    '    szHeader += "<br/>"

    '    htw.WriteLine(szHeader)

    '    '顯示列印資料
    '    grdExcel.Visible = True

    '    '關閉分頁排序
    '    grdExcel.AllowPaging = False
    '    grdExcel.AllowSorting = False

    '    '查詢需列印之資料
    '    Me.ShowReportList()

    '    '交付選擇之資料
    '    grdExcel.RenderControl(htw)

    '    '設定編碼為UTF-8
    '    Response.ContentEncoding = Encoding.GetEncoding("big5")

    '    '丟出完成之資料
    '    Response.Write(sw.ToString())
    '    Response.End()

    '    '開啟分頁排序
    '    grdExcel.AllowPaging = True
    '    grdExcel.AllowSorting = True

    '    '關閉列印資料
    '    grdExcel.Visible = False
    '    grdExcel.DataBind()
    'End Sub

    '防止 runat=server錯誤使用
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
    End Sub
#End Region

End Class
