Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2117_01
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

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "012")
        ddlTitle_name.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlTitle_name.DataValueField = "code_no"     '所代表的value
        ddlTitle_name.DataSource = dt                '指定datatable給ddl
        ddlTitle_name.DataBind()                     'ddl進行Databind
        ddlTitle_name.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        Dim dt2 As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlEmployeetype.DataValueField = "code_no"     '所代表的value
        ddlEmployeetype.DataSource = dt2                '指定datatable給ddl
        ddlEmployeetype.DataBind()                     'ddl進行Databind
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

        ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", ""))

        UserName_Bind()
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
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = UcDDLDepart.SelectedValue
        Dim Apply_name As String = UcDDLMember.SelectedValue
        Dim Apply_idcard As String = UcAuthorityMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim Title_no As String = ddlTitle_name.SelectedValue
        Dim yyymm As String = ""

        Dim bll As New FSC2117()
        Dim dt As DataTable

        If Start_date > End_date Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位不可大於「迄日」欄位。")
            Return
        End If
        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(End_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If

        Try
            dt = bll.getQueryData(orgcode, departid, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, Employee_type, Title_no)

            dt.Columns.Add("Absent")
            For Each dr As DataRow In dt.Rows
                dr("Absent") = IIf(dr("PKWKTPE").Equals("3"), "V", "")
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
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvList.DataBind()
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
                dt.Rows(i).Item("PKWDATE") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                dt.Rows(i).Item("PKSTIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                dt.Rows(i).Item("PKETIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())
                'dt.Rows(i).Item("End_date") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("End_date").ToString())
            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text '查詢頁面的"起"日期
            Dim tmp2 As String = UcDate2.Text '查詢頁面的"迄"日期

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetTodayString()

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2117_RPT.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "悠遊卡刷卡紀錄"
            theDTReport.ExportToExcel()

        End If

        dt.Dispose()

    End Sub

#End Region

End Class
