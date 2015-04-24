Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2109_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then Return

        bindDep()
        bindName()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
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
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可大於迄日，請重新查詢!")
            Return
        End If
        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DataTable()
        Dim bll As New FSC2109()

        dt = bll.GetData(orgcode, UcDDLDepart.SelectedValue, UcDDLAuthorityMember.SelectedValue, UcAuthorityMember.PersonnelId, ddlQuit.SelectedValue, _
                          ddlSex.SelectedValue, UcDate1.Text, UcDate2.Text)

        For Each dr As DataRow In dt.Rows
            dr("Sche_date") = DateTimeInfo.ConvertToDisplay(dr("Sche_date").ToString(), "-")
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

            Dim para(0) As String
            para(0) = "署內值日表"

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2109_01.mht"), dt)
            theDTReport.Param = para
            theDTReport.ExportFileName = "署內值日表"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If

    End Sub
#End Region

End Class
