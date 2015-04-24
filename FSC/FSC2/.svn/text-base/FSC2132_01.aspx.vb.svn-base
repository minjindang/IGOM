Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC2132_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLAuthorityDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        UcDateS.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.Month.ToString.PadLeft(2, "0") & "01"
        UcDateE.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.Month.ToString.PadLeft(2, "0") & Date.DaysInMonth(Now.Year, Now.Month).ToString
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLAuthorityDepart.SelectedValue
        Dim limit As Double = 15 * 8 '天數 * 8小時
        Dim bll As New FSC2104

        If String.IsNullOrEmpty(UcDateS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入出差日期(起)!")
            Return
        End If
        If String.IsNullOrEmpty(UcDateE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入出差日期(迄)!")
            Return
        End If
        If UcDateS.Text > UcDateE.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "出差日期(起)不可大於出差日期(迄)!")
            Return
        End If

        Try
            Dim tmp As DataTable = bll.getQueryData(Orgcode, Depart_id, "", "", "", "", UcDateS.Text, UcDateE.Text, "", "1", "1")
            Dim dt As DataTable = tmp.Clone()
            For Each dr As DataRow In tmp.Rows
                If CommonFun.getDouble(dr("Leave_hours")) > limit Then
                    dt.ImportRow(dr)
                End If
            Next

            dt.Columns.Add("DayHours")
            dt.Columns.Add("Location_Name")
            For Each dr As DataRow In dt.Rows
                dr("DayHours") = Content.ConvertDayHours(dr("Leave_hours").ToString())
                dr("Location_Name") = IIf(dr("Location_flag") = "0", "國內", "國外")
            Next

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

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
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i)("Start_date") = DateTimeInfo.ToDisplay(dt.Rows(i)("Start_date").ToString())
                dt.Rows(i)("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i)("End_date").ToString())
                dt.Rows(i)("Start_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i)("Start_time").ToString())
                dt.Rows(i)("End_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i)("End_time").ToString())
            Next

            Dim params(1) As String
            params(0) = DateTimeInfo.ConvertToDisplay(UcDateS.Text)
            params(1) = DateTimeInfo.ConvertToDisplay(UcDateE.Text)

            Dim theDTReport As CommonLib.DTReport

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2132_RPT.mht"), dt)
            theDTReport.ExportFileName = "出差單筆超過15天報表"
            theDTReport.Param = params
            theDTReport.ExportToExcel()
            dt.Dispose()
        End If
    End Sub
#End Region

End Class
