Imports System.Data
Imports System.IO
Imports System.Text
Imports FSC.Logic
Imports Microsoft.Office.Interop

Partial Class FSC4104_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return

    End Sub

    Protected Sub cbImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbImport.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim User_IdCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim sw As StreamWriter
        Dim swd As StreamWriter
        Dim RtnMsg As String = String.Empty
        Dim UpFileStatus As Boolean = True
        Dim FileName As String = fuFile.PostedFile.FileName
        Dim FileExtension As String = Path.GetExtension(FileName)

        If Not fuFile.HasFile Then
            CommonFun.MsgShow(Me, CommonFun.Msg.NotSelectItem)
            Return
            'RtnMsg = CommonFun.Msg.NotSelectItem
            'UpFileStatus = False
        End If


        If FileExtension <> ".xls" And UpFileStatus = True Then
            RtnMsg = "只能上傳xls格式"
            UpFileStatus = False
        End If

        If UpFileStatus And (FileName.ToLower().Replace(".xls", "").Length > 6 Or Not IsNumeric(FileName.ToLower().Replace(".xls", ""))) Then
            RtnMsg = "檔名錯誤，格式為：四碼西元年加兩碼月份(201312)"
            UpFileStatus = False
        End If

        If Not UpFileStatus Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, RtnMsg)
            Return
        End If

        Dim lpath As String = Server.MapPath(ConfigurationManager.AppSettings("ImpSchedulingLogPath").ToString() & _
                                             "\" & DateTimeInfo.GetRocDate(Now).Substring(0, 3))

        Dim d As New DirectoryInfo(lpath)
        If Not d.Exists() Then
            d.Create()
        End If

        Dim logfname As String = Now.ToString("yyyyMMddHHmmss") & "(" & fuFile.FileName.ToLower().Substring(0, fuFile.FileName.IndexOf("."))

        'LOG
        Dim f As FileInfo = New FileInfo(lpath & "\" & logfname & ")_log.txt")
        Dim fd As FileInfo = New FileInfo(lpath & "\" & logfname & ")_double_log.txt")

        sw = New StreamWriter(f.FullName, False, System.Text.Encoding.Default)
        swd = New StreamWriter(fd.FullName, False, System.Text.Encoding.Default)

        Dim ht As New Hashtable()

        Dim fpath As String = lpath & "\" & fuFile.FileName
        Dim app As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        Dim range As Excel.Range

        Try
            fuFile.PostedFile.SaveAs(fpath)

            Dim xlsContent As String = ""
            book = app.Workbooks.Open(fpath)
            sheet = book.Sheets(1)
            Dim TotalColumns As Integer = sheet.UsedRange.Columns.Count
            Dim TotalRows As Integer = sheet.UsedRange.Rows.Count
            Dim scheduleYear As Integer = FileName.Substring(0, 4)
            Dim scheduleMonth As Integer = FileName.Substring(4, 2)
            Dim Tdays As Integer = DateTime.DaysInMonth(scheduleYear, scheduleMonth)

            If (TotalRows - 2) <> Tdays Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "天數錯誤")
                Return
            End If

            '查詢excel內的年度與檔名是否相符
            range = sheet.Cells(2, 1)
            Dim YearContent As String = range.Value
            If Not YearContent.Contains(scheduleYear - 1911) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "內容年度與檔名不符")
                Return
            End If

            '查詢excel內的月份與檔名是否相符
            Dim ex_Y As String = YearContent.Substring(0, 3)
            Dim ex_M As String = YearContent.Substring(3, 2)
            Dim MonthContent As DateTime = New DateTime(scheduleYear, Integer.Parse(ex_M), 1)
            If scheduleMonth <> MonthContent.Month Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "內容月份與檔名不符")
                Return
            End If

            Dim dt As DataTable = New DataTable()
            dt.Columns.Add("Orgcode", GetType(String))
            dt.Columns.Add("Depart_id", GetType(String))
            dt.Columns.Add("PBDDATE", GetType(String))
            dt.Columns.Add("PBDWEEK", GetType(String))
            dt.Columns.Add("PBDTYPE", GetType(String))
            dt.Columns.Add("PBDDESC", GetType(String))
            dt.Columns.Add("Change_userid", GetType(String))
            dt.Columns.Add("Change_date", GetType(String))
            dt.Columns.Add("RtnCode", GetType(Integer))

            Dim i As Integer = 0
            Dim j As Integer = 0
            '先把excel裡的資料存進dt裡
            For i = 2 To Tdays
                'sheet.cells(列，欄)
                Dim dr As DataRow = dt.NewRow()
                dr("Orgcode") = orgcode
                dr("Depart_id") = depart_id
                range = sheet.Cells(i, 1)
                dr("PBDDATE") = range.Value
                range = sheet.Cells(i, 2)
                dr("PBDWEEK") = range.Value
                range = sheet.Cells(i, 3)
                dr("PBDTYPE") = IIf(range.Value Is Nothing, 0, range.Value)
                range = sheet.Cells(i, 4)
                dr("PBDDESC") = IIf(range.Value Is Nothing, "", range.Value)
                dr("Change_date") = Now
                dr("Change_userid") = User_IdCard
                dr("RtnCode") = "0"
                dt.Rows.Add(dr)
            Next

            Dim pb02m As New CPAPB02M()

            pb02m.Batch_Insert(dt)
            Dim ErrorCounts As Integer = 0
            Dim SuccessCounts As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("RtnCode").ToString() = "101" Then
                    ErrorCounts += 1
                ElseIf dt.Rows(i)("RtnCode").ToString() = "1" Then
                    SuccessCounts += 1
                End If
            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增成功：" & SuccessCounts & "筆，失敗：" & ErrorCounts & "筆", "FSC4104_01.aspx")

        Catch ex As Exception
            sw.WriteLine(ex.Message)
            swd.WriteLine(ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        Finally

            app.Workbooks.Close()
            sw.Flush()
            sw.Close()
            sw.Dispose()

            swd.Flush()
            swd.Close()
            swd.Dispose()
        End Try
    End Sub


End Class
