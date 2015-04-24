Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC2123_01
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

        'UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd")

        Dim dt3 As DataTable = New FSC.Logic.Org().GetDataByOrgAndParentId("355000000I")
        cblDeparts.DataTextField = "Depart_name"   '顯示的中文名稱
        cblDeparts.DataValueField = "Depart_id"     '所代表的value
        cblDeparts.DataSource = dt3               '指定datatable給ddl
        cblDeparts.DataBind()                     'ddl進行Databind

        cbxDepALL.Attributes.Add("onclick", "checkCheckBox('" & cbxDepALL.ClientID & "','" & cblDeparts.ClientID & "')")

    End Sub


    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = String.Empty
        Dim Start_date As String = UcDate1.Text

        Dim bll As New FSC2123()
        Dim dt As DataTable

        Dim count = 0
        For Each x As ListItem In cblDeparts.Items
            If x.Selected And count = 0 Then
                departid += x.Value
                count = count + 1
            ElseIf x.Selected And count <> 0 Then
                departid += "," + x.Value
            End If
        Next


        If String.IsNullOrEmpty(Start_date) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「日期」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(departid) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位別至少選擇一項")
            Return
        End If

        Try
            dt = bll.getQueryData(orgcode, departid, Start_date)
            dt.Columns.Add("Start_date")
            For Each dr As DataRow In dt.Rows
                dr("Start_date") = UcDate1.Text
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

    Protected Sub btnLook_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer

        Dim departid As String = CType(gvr.FindControl("lbDepart_id"), HiddenField).Value
        Dim startdate As String = CType(gvr.FindControl("lbStart_date"), Label).Text
        Response.Redirect("FSC2123_02.aspx?dep=" + departid + "&startdate=" + startdate)
    End Sub


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
                'dt.Rows(i).Item("PKWDATE") = DateTimeInfo.ToDisplay(dt.Rows(i).Item("PKWDATE").ToString())
                'dt.Rows(i).Item("PKSTIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKSTIME").ToString())
                'dt.Rows(i).Item("PKETIME") = DateTimeInfo.ToDisplayTime(dt.Rows(i).Item("PKETIME").ToString())

            Next

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim tmp1 As String = UcDate1.Text '查詢頁面的"起"日期
            'Dim tmp2 As String = UcDate2.Text '查詢頁面的"迄"日期

            strParam(0) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(1) = DateTimeInfo.ToDisplay(tmp1)
            'strParam(2) = DateTimeInfo.ToDisplay(tmp2)
            strParam(3) = DateTimeInfo.GetRocTodayString("yyyy/MM/dd")

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2123_01.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "單位查勤紀錄"
            theDTReport.ExportToExcel()

        End If

        dt.Dispose()

    End Sub

#End Region

End Class
