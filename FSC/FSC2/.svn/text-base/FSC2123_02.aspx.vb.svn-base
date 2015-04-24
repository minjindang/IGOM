Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2123_02
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim Case_status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        Bind()
    End Sub
    'Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
    '    UserName_Bind()
    'End Sub

    Private Sub UserName_Bind()
        'UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub
    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = Request.QueryString("dep")
        Dim Start_date As String = Request.QueryString("startdate")

        Dim bll As New FSC2123()
        Dim dt, dt2 As DataTable

        Dim count = 0
        departid = Left(departid, 3) & "%"

        Try
            dt = bll.getQueryDataDep(orgcode, departid)
            dt.Columns.Add("leavetype")
            For Each dr As DataRow In dt.Rows
                dt2 = bll.getQueryDataLea(orgcode, Start_date)

                For Each dr2 As DataRow In dt2.Rows 'Print Leave Detail
                    If dr("Id_card") = dr2("Id_card") Then
                        If Not String.IsNullOrEmpty(dr2("Leave_name").ToString()) Then
                            dr("leavetype") = dr("leavetype").ToString() + dr2("Leave_name").ToString() + "<br />"
                        End If
                        dr("leavetype") = dr("leavetype").ToString() + DateTimeInfo.ToDisplay(dr2("Start_date").ToString(), dr2("Start_time").ToString()) + "~" + DateTimeInfo.ToDisplay(dr2("End_date").ToString(), dr2("End_time").ToString()) + "<br />"
                    End If
                Next
            Next

            tbq.Visible = True
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

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

        If ViewState("dt") Is Nothing Then
            'Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1 'EXCEL 的編號

                'dt.Rows(i).Item("Start_time") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                'dt.Rows(i).Item("Start_date") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                'dt.Rows(i).Item("End_time") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())
                'dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("End_date").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = Request.QueryString("startdate") '查詢頁面的日期

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            'strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2123_02.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "單位查勤清單紀錄"
            theDTReport.ExportToExcel()
        End If
        dt.Dispose()
    End Sub
#End Region
End Class
