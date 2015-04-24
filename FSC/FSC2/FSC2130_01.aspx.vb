Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC2130_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        For i As Integer = 103 To Now.Year - 1911
            ddlYear.Items.Add(i.ToString())
        Next

        For j As Integer = 1 To 12
            ddlMonth.Items.Add(j.ToString().PadLeft(2, "0"))
        Next
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Try
            Dim Employee_type As String = "12" '臨時工
            Dim Limits As Integer = 2 '累積天數
            Dim bll As New FSC2130
            Dim dt As DataTable = New DataTable

            Dim sdt As DataTable = bll.getSumData(Employee_type, ddlYear.SelectedValue & ddlMonth.SelectedValue)
            For Each dr As DataRow In sdt.Rows
                If CommonFun.getDouble(dr("TotalHours")) >= Limits Then
                    Dim tmp As DataTable = bll.getData(dr("PYIDNO").ToString(), ddlYear.SelectedValue & ddlMonth.SelectedValue)
                    If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                        dt.Merge(tmp)
                    End If
                End If
            Next

            dt.Columns.Add("DayHours")
            For Each dr As DataRow In dt.Rows
                dr("DayHours") = Content.ConvertDayHours(dr("Leave_hours"))
            Next

            tbq.Visible = True
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
                dt.Rows(i).Item("Start_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("start_date").ToString())
                dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("end_date").ToString())
                dt.Rows(i).Item("Start_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("Start_time").ToString())
                dt.Rows(i).Item("End_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("End_time").ToString())
            Next

            Dim params(1) As String
            params(0) = ddlYear.SelectedValue
            params(1) = ddlMonth.SelectedValue

            Dim theDTReport As CommonLib.DTReport

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2130_RPT.mht"), dt)
            theDTReport.Param = params
            theDTReport.ExportFileName = "臨時工每月累積達2天以上人員報表"
            theDTReport.ExportToExcel()
            dt.Dispose()
        End If
    End Sub
#End Region

End Class
