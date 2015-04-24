Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2122_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then Return

        bindDep()
        bindName()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Now.Day.ToString.PadLeft(2, "0")

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
        End If
    End Sub

#Region "初始化"
    Protected Sub bindDep()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = orgcode
    End Sub

    Protected Sub bindName()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLAuthorityMember.Orgcode = orgcode
        UcDDLAuthorityMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        bindName()
    End Sub
#End Region

#Region "查詢"
    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If String.IsNullOrEmpty(Me.UcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可空白，請重新查詢!")
            Return
        End If
        If String.IsNullOrEmpty(Me.UcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件迄日不可空白，請重新查詢!")
            Return
        End If
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可大於迄日，請重新查詢!")
            Return
        End If

        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DataTable()
        Dim departId As String = UcDDLDepart.SelectedValue

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            departId = ""
        End If

        If Mid(UcDate1.Text, 1, 5) = Mid(UcDate2.Text, 1, 5) Then
            Dim bll As CPAPHYYMM = New CPAPHYYMM(Mid(UcDate1.Text, 1, 5))
            dt = bll.get2122Data(orgcode, departId, UcDDLAuthorityMember.SelectedValue, UcMember.PersonnelId, UcDate1.Text, UcDate2.Text)
        Else
            Dim DateS As String = UcDate1.Text.Substring(0, 3) + "/" + UcDate1.Text.Substring(3, 2) + "/" + "01"
            Dim DateE As String = UcDate2.Text.Substring(0, 3) + "/" + UcDate2.Text.Substring(3, 2) + "/" + "01"

            Dim S As Date = Date.Parse(DateS)
            Dim E As Date = Date.Parse(DateE)

            Dim bll As CPAPHYYMM = New CPAPHYYMM(S.Year.ToString() + S.Month.ToString().PadLeft(2, "0"))
            dt = bll.get2122Data(orgcode, departId, UcDDLAuthorityMember.SelectedValue, UcMember.PersonnelId, UcDate1.Text, UcDate2.Text)
            While S < E
                S = S.AddMonths(1)
                bll = New CPAPHYYMM(S.Year.ToString() + S.Month.ToString().PadLeft(2, "0"))
                Dim tmpdt As DataTable = bll.get2122Data(orgcode, departId, UcDDLAuthorityMember.SelectedValue, UcMember.PersonnelId, UcDate1.Text, UcDate2.Text)
                dt.Merge(tmpdt)
            End While
        End If

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dt.Columns.Add("Num")
            dt.Columns.Add("FULL_Name")
            dt.Columns.Add("PHI_datetime")

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("Num") = i + 1
                dt.Rows(i)("FULL_Name") = dt.Rows(i)("User_Name").ToString() + "(" + dt.Rows(i)("PHCARD").ToString + ")"
                dt.Rows(i)("PHI_datetime") = DateTimeInfo.ToDisplay(dt.Rows(i)("PHIDATE").ToString().Trim(), dt.Rows(i)("PHITIME").ToString(), "-")
                dt.Rows(i)("PHITYPE") = IIf(dt.Rows(i)("PHITYPE").ToString() = "A", "上班卡", "下班卡")
                dt.Rows(i)("PHADDR") = "L1(線上刷卡)"
            Next
        End If

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

            Dim para(0) As String
            para(0) = "查詢期間：" + DateTimeInfo.ConvertToDisplay(UcDate1.Text) & "~" & DateTimeInfo.ConvertToDisplay(UcDate2.Text)

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2122_01.mht"), dt)
            theDTReport.Param = para
            theDTReport.ExportFileName = "線上刷卡紀錄查詢"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If

    End Sub
#End Region

End Class
