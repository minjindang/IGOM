Imports System.Data
Imports FSCPLM.Logic
Imports System.IO

Partial Class FSC2116_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Bind_Member()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr1.Visible = False
        End If
    End Sub

    Protected Sub Bind_Member()
        UcDDLAuthorityMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLAuthorityMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Bind_Member()
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢條件起日不可大於迄日，請重新查詢!")
            Return
        End If
        ViewState("dt") = Nothing
        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = IIf(LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral), "", UcDDLDepart.SelectedValue)
        Dim Id_card As String = UcDDLAuthorityMember.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text

        Dim bll As New FSC.Logic.FSC2116()
        Dim dt As DataTable

        Try
            dt = bll.getQueryData(Orgcode, Depart_id, Id_card, Start_date, End_date)
            ViewState("dt") = dt

            Me.gvList.DataSource = ViewState("dt")
            Me.gvList.DataBind()

            Me.gvList.Visible = True
            Me.dataList.Visible = True
            If Not Me.gvList.Rows Is Nothing AndAlso Me.gvList.Rows.Count > 0 Then
                Me.Ucpager1.Visible = True
                Me.dataList.Visible = True
                btnBackupReport.Enabled = True
                EmptyTable.Visible = False
            Else
                Me.Ucpager1.Visible = False
                Me.dataList.Visible = False
                btnBackupReport.Enabled = False
                EmptyTable.Visible = True
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
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


    Protected Function Check(ByVal vValue As Integer) As String
        Dim a As String = CStr(vValue)
        If a.Length < 2 Then
            a = "0" & a
        End If
        Return a
    End Function
    Protected Function Get_Data(ByVal vItem As String) As String
        Dim WorkStr As String = ""
        Dim Property1 As FSCorg = New FSCorg()
        Dim ds As DataSet = New DataSet()
        ds = Property1.DAO.GetDepartName(Session("Orgcode"), vItem)
        WorkStr = ds.Tables(0).Rows(0)("DepartName").ToString()
        Return WorkStr
    End Function
    Protected Function CheckNumber(ByVal vValue As String) As String
        Dim Workstr As String = ""
        If vValue = "0" Then
            Workstr = ""
        Else
            Workstr = vValue
        End If
        Return Workstr
    End Function

    'Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.Header) Then
    '        Dim Str As String = "</td></tr><tr><td rowspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>單位名稱</td><td rowspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>人員姓名</td><td rowspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>身分證號</td>"
    '        Str = Str & "<td colspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>起</td><td colspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>迄</td><td rowspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>請假<br>合計<br>日時</td><td rowspan='2' style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>請假備註</td></tr>"
    '        Str = Str & "<tr><td style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>請假日期</td><td  style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>時間</td><td style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>請假日期</td><td style='text-align: center;background-color:#b0e0e6; border:1px solid #C5C386;'>時間</td></tr>"
    '        e.Row.Cells(0).Text = Str
    '        Dim tc As New TableCell()
    '        tc.Text = Str
    '        tc.ColumnSpan = e.Row.Cells.Count '原本的欄位數 
    '        e.Row.Cells.Clear() ' 這會把原本的標題刪除 
    '        e.Row.Cells.Add(tc)
    '    End If
    'End Sub

 
    Protected Sub btnBackupReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBackupReport.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = IIf(LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral), "", UcDDLDepart.SelectedValue)
        Dim Id_card As String = UcDDLAuthorityMember.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text

        Dim bll As New FSC.Logic.FSC2116()
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            dt = bll.getQueryData(Orgcode, Depart_id, Id_card, Start_date, End_date)
        End If

        Dim theDTReport As CommonLib.DTReport

        theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2116_RPT.mht"), dt)

        theDTReport.ExportFileName = "國旅卡休假查詢紀錄表"
        theDTReport.ExportToExcel()
        dt.Dispose()

        'Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=" & "ADMSave" & Replace(Format(Now.Date, "yyMMdd"), "/", "") & ".csv") 'excel檔名   'ADMSaveYYMMDD
        'Response.ContentType = "application/vnd.ms-excel"
        'Response.Charset = "UTF-8"
        'Dim sw As StringWriter = New StringWriter()
        'Response.ContentEncoding = System.Text.Encoding.GetEncoding("Big5")

        'sw.WriteLine("員工編號,姓名,身分證字號,單位,休假起迄日,時數,異動者")

        'For Each dr As DataRow In dt.Rows
        '    'sw.WriteLine(dt.Rows(0))
        '    sw.Write("'" + dr("Id_card").ToString().Trim() & ",")
        '    sw.Write(dr("User_name").ToString().Trim() & ",")
        '    sw.Write(dr("Id_number").ToString().Trim() & ",")
        '    sw.Write(dr("Depart_name").ToString().Trim() & ",")
        '    sw.Write(dr("Start_date").ToString().Trim() & "~" & dr("End_date").ToString().Trim() & ",")
        '    sw.Write(dr("Leave_hours").ToString().Trim() & ",")
        '    sw.Write(dr("Change_userid").ToString().Trim() & ",")
        '    sw.Write(sw.NewLine)
        'Next


        'Response.Write(sw.ToString())
        'Response.End()
    End Sub

    Protected Sub btnBankReport_Click(sender As Object, e As EventArgs) Handles btnBankReport.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = IIf(LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral), "", UcDDLDepart.SelectedValue)
        Dim Id_card As String = UcDDLAuthorityMember.SelectedValue
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text

        Dim bll As New FSC.Logic.FSC2116()
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            dt = bll.getQueryData(Orgcode, Depart_id, Id_card, Start_date, End_date)
        End If

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & "ADMSend" & Replace(Format(Now.Date, "yyMMdd"), "/", "") & ".txt") 'txt檔名ADMSaveYYMMDD
        Response.ContentType = "application/vnd.ms-excel"
        Response.Charset = "UTF-8"
        Dim sw As StringWriter = New StringWriter()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("Big5")

        For Each dr As DataRow In dt.Rows
            sw.Write(dr("Orgcode").ToString().Trim() & "!")
            sw.Write(dr("ChangeCode").ToString().Trim() & "!")
            sw.Write("A" & "!")
            sw.Write(dr("Id_number").ToString().Trim() & "!")
            sw.Write(dr("Start_date").ToString().Trim() & "!")
            sw.Write(sw.NewLine)
        Next
        Response.Write(sw.ToString())
        Response.End()
    End Sub
End Class
