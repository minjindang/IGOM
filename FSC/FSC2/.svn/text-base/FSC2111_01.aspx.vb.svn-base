Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2111_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then Return

        bindDep()
        bindTitle()
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

#Region "初始化"
    Protected Sub bindDep()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = orgcode
    End Sub

    Protected Sub bindTitle()
        cbAll.Checked = False
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DataTable
        If String.IsNullOrEmpty(ddlBossLevel.SelectedValue) Then
            For i As Integer = 1 To 3
                dt.Merge(New FSC.Logic.Personnel().GetTitleDataByOrgDep(orgcode, UcDDLDepart.SelectedValue, "", i.ToString))
            Next
        Else
            dt = New FSC.Logic.Personnel().GetTitleDataByOrgDep(orgcode, UcDDLDepart.SelectedValue, "", ddlBossLevel.SelectedValue)
        End If
        cblTitle_no.DataSource = dt
        cblTitle_no.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        bindTitle()
    End Sub

    Protected Sub ddlBossLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBossLevel.SelectedIndexChanged
        bindTitle()
    End Sub

    Protected Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        For Each i As ListItem In cblTitle_no.Items
            i.Selected = cbAll.Checked
        Next
    End Sub
#End Region

#Region "查詢"
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
        Dim dt As DataTable = New DataTable()
        Dim ddt As DataTable = New DataTable()
        Dim bll As New FSC2111()

        'For i = 0 To cblStatus.Items.Count - 1
        '    If cblStatus.Items(i).Selected = True Then
        '        isSecleted = True
        '        Dim tmpdt As DataTable = bll.GetData(orgcode, UcDDLDepart.SelectedValue, ddlBossLevel.SelectedValue, UcDate1.Text, UcDate2.Text, cblStatus.Items(i).Value)
        '        If tmpdt IsNot Nothing AndAlso tmpdt.Rows.Count > 0 Then
        '            dt.Merge(tmpdt)
        '        End If
        '    End If
        'Next

        'If Not isSecleted Then
        '    dt = bll.GetData(orgcode, UcDDLDepart.SelectedValue, ddlBossLevel.SelectedValue, UcDate1.Text, UcDate2.Text, "")
        'End If
        For Each i As ListItem In cblStatus.Items
            If i.Selected Then
                isSecleted = True
                Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", i.Value)

                Dim caseStatus As String = r("code_remark1").ToString()
                Dim lastPass As String = r("code_remark2").ToString()

                Dim tmp As DataTable = bll.GetData(orgcode, UcDDLDepart.SelectedValue, ddlBossLevel.SelectedValue, UcDate1.Text, UcDate2.Text, caseStatus, lastPass)

                If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                    ddt.Merge(tmp)
                End If
            End If
        Next

        If Not isSecleted Then
            ddt = bll.GetData(orgcode, UcDDLDepart.SelectedValue, ddlBossLevel.SelectedValue, UcDate1.Text, UcDate2.Text, "", "")
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

        dt.Columns.Add("FULL_Name")
        dt.Columns.Add("SEdate")
        dt.Columns.Add("TypeHours")
        dt.Columns.Add("Process")
        For Each dr As DataRow In dt.Rows
            dr("FULL_Name") = dr("Apply_idcard").ToString() + "<br />" + dr("Apply_name").ToString()
            dr("SEdate") = DateTimeInfo.ToDisplay(dr("Start_date").ToString(), dr("Start_time").ToString(), "-") + "<br />" + _
            DateTimeInfo.ToDisplay(dr("End_date").ToString(), dr("End_time").ToString(), "-")
            dr("TypeHours") = New SYS.Logic.LeaveType().GetDataByLeave_type(dr("Leave_type").ToString()).Rows(0)("Leave_Name").ToString() + _
            "<br />" + Content.ConvertDayHours(dr("Leave_hours").ToString()).ToString()

            Dim fd As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(dr("orgcode").ToString(), dr("flow_id").ToString())
            For Each ddr As DataRow In fd.Rows
                If Not String.IsNullOrEmpty(dr("Process").ToString()) Then
                    dr("Process") = dr("Process").ToString() + "<br />"
                End If
                dr("Process") = dr("Process").ToString() + New SYS.Logic.CODE().GetFSCTitleName(ddr("Last_posid").ToString()) + " " + ddr("Last_name").ToString()
            Next
        Next

        ViewState("dt") = dt

        gvList.DataSource = dt
        gvList.DataBind()
        If Not Me.gvList.Rows Is Nothing And Me.gvList.Rows.Count > 0 Then
            Me.dataList.Visible = True
            Me.Ucpager1.Visible = True
            EmptyTable.Visible = False
            btnPrint.Enabled = True
        Else
            Me.dataList.Visible = False
            Me.Ucpager1.Visible = False
            EmptyTable.Visible = True
            btnPrint.Enabled = False
        End If
    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowList()
    End Sub
#End Region

#Region "列印"
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If ViewState("dt") Is Nothing Then
            ShowList()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()


            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2111_01.mht"), dt)
            theDTReport.ExportFileName = "主管差假紀錄表"
            theDTReport.Param = strParam
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If

    End Sub
#End Region

End Class
