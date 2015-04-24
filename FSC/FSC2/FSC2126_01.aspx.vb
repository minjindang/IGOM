Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class FSC2126_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        tbq.Visible = False
        Depart_Bind()
        UserName_Bind()


    End Sub

    Protected Sub Depart_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub


#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim id_card As String = UcDDLMember.SelectedValue
        Dim id_card2 As String = UcMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim tmpdt As DataTable = New DataTable
        Dim bll As New FSC2126()
        Dim dt As DataTable
        Dim dt2 As DataTable = New DataTable
        Dim leavedays As Integer = 0


        If String.IsNullOrEmpty(UcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(UcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「迄日」欄位為必填。")
            Return
        End If

        dt = bll.getQueryData(orgcode, depart_id, id_card, id_card2, Start_date, End_date)
        dt2 = dt.Clone
        Dim count = 0
        For Each dr As DataRow In dt.Rows
            If count = 0 Then 'First Line
                If dr("PKSTIME").Equals("9999") And dr("PKETIME").Equals("0000") And dr("PKWKTPE").Equals("曠職") Then
                    leavedays = leavedays + 1
                End If
                count = count + 1
            ElseIf count <> 0 Then
                If dr("PKCARD") = dt.Rows(count - 1).Item("PKCARD") Then 'Equal Last Name
                    If dr("PKSTIME").Equals("9999") And dr("PKETIME").Equals("0000") And dr("PKWKTPE").Equals("曠職") Then 'Absent
                        leavedays = leavedays + 1  'Continue Absent Days
                        If count = dt.Rows.Count - 1 Then ' Last Column of Datatable
                            If leavedays >= 10 Then
                                For i As Integer = 1 To leavedays
                                    dt2.ImportRow(dt.Rows(count - leavedays + i))
                                Next
                                tbq.Visible = True
                            End If
                        End If
                    Else 'Not Leave Type
                        If leavedays >= 10 Then
                            For i As Integer = 1 To leavedays
                                dt2.ImportRow(dt.Rows((count - 1) - leavedays + i))
                            Next
                            tbq.Visible = True
                        End If
                        leavedays = 0 ' Not Leave Type
                    End If
                ElseIf dr("PKCARD") <> dt.Rows(count - 1).Item("PKCARD") And dr("PKSTIME").Equals("9999") And _
                    dr("PKETIME").Equals("0000") And dr("PKWKTPE").Equals("曠職") Then 'Different Name
                    If leavedays >= 10 Then
                        For i As Integer = 1 To leavedays
                            dt2.ImportRow(dt.Rows((count - 1) - leavedays + i))
                        Next
                        tbq.Visible = True
                    End If
                    leavedays = 1
                Else
                    leavedays = 0
                End If
                count = count + 1
            End If
        Next
        ViewState("dt2") = dt2
        If dt2 IsNot Nothing Then
            Me.gvlist.DataSource = dt2
            Me.gvlist.DataBind()
            dt2.Dispose()
        End If

        tbq.Visible = True

        If gvlist.Rows.Count > 0 Then
            Ucpager.Visible = True
            btnExcel.Enabled = True
        Else
            Ucpager.Visible = False
            btnExcel.Enabled = False
        End If

    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt2"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If ViewState("dt2") Is Nothing Then
            Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt2"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i).Item("PKWDATE") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                dt.Rows(i).Item("PKSTIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                dt.Rows(i).Item("PKETIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetRocTodayString("yyyy/MM/dd")

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2126_01.mht"), dt)
            theDTReport.Param = strParam 'Assign Value to Parameter
            theDTReport.ExportFileName = "連續10天(以上)曠職表"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub
End Class
