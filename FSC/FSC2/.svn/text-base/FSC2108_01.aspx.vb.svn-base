Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2108_01
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

        UcDDLDepart.orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        UserName_Bind()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
        End If
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Function Get_date(ByVal V_Date As String) As String
        If V_Date Is System.DBNull.Value Then Return ""
        Dim WorkStr As String = ""
        If Not String.IsNullOrEmpty(V_Date) Then
            WorkStr = Replace(V_Date, "-", "/")
            If CInt(Split(CStr(WorkStr), " ").Length) > 1 Then
                WorkStr = Split(WorkStr, " ")(0)
            Else
                WorkStr = WorkStr
            End If
        Else
            WorkStr = ""
        End If
        Return WorkStr
    End Function

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Depart_id As String = UcDDLDepart.SelectedValue()
        Dim User_name As String = UcDDLMember.SelectedValue
        Dim Id_card As String = UcAuthorityMember.PersonnelId
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim PESEX As String = ddlsextype.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim order As String = "" 'rblSorttype.SelectedValue
        Dim bll As New FSC2108()
        Dim dt As DataTable

        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            Depart_id = ""
        End If

        Try
            dt = bll.getQueryData(orgcode, Depart_id, User_name, Id_card, Quit_job_flag, PESEX, Start_date, End_date, order)
            dt.Columns.Add("Depart_name")

            For Each dr As DataRow In dt.Rows
                dr("Depart_name") = New Org().GetDepartNameWithoutSubDepart(orgcode, dr("Depart_id").ToString)
            Next

            tbq.Visible = True
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnPrint.Enabled = True
            Else
                Ucpager.Visible = False
                btnPrint.Enabled = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If ViewState("dt") Is Nothing Then
            'Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
                dt.Rows(i).Item("Sche_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("Sche_date").ToString())
                'dt.Rows(i).Item("end_date") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("end_date").ToString()) 顯示時間
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text
            Dim tmp2 As String = UcDate2.Text

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()


            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2108_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "值班紀錄表"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub

End Class
