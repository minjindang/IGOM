Imports Microsoft.VisualBasic
Imports NLog
Imports System
Imports System.Web
Imports System.Configuration

Public Class AppException
    Inherits System.Exception
    Private Shared _log As Logger = LogManager.GetLogger("AppException")

#Region "WriteErrorLog：將錯誤訊息寫入Log檔"

    Public Shared Sub WriteErrorLog(ByVal StackTrace As String, ByVal Message As String)

        _log.Error(Message & vbCrLf & StackTrace)

        Dim e As SYS.Logic.ErrorLog = New SYS.Logic.ErrorLog
        e.insert(Message & vbCrLf & StackTrace)

        '' 取得HTTPContext
        'Dim context As HttpContext = HttpContext.Current

        'Dim blnFlag As Boolean = True
        'Dim sw As System.IO.StreamWriter

        'Dim logpath As String = ConfigurationManager.AppSettings("LogFilePath").ToString()

        ''取得本次要寫入Error時，Log檔的路徑( Log檔案會每天的記錄在當天的那個Log檔案中,Ex:ErrorLog_200781)
        'Dim strLogPath As String = HttpContext.Current.Server.MapPath(logpath & "\ErrorLog_" & Format(Now, "yyyyMMdd") & ".txt")

        ''若今日的Error Log檔案不存在，則建立檔案
        'If Not IO.File.Exists(strLogPath) Then
        '    blnFlag = CreateErrorLogFile(strLogPath)
        'End If

        ''Log檔案建立成功，才能寫入Log
        'If blnFlag = True Then

        '    '建立Log檔的StreamWriter物件
        '    sw = New System.IO.StreamWriter(strLogPath, True)

        '    ' 寫入錯誤訊息到Log檔
        '    Try
        '        sw.WriteLine()
        '        sw.WriteLine("** " & Format(Now, "yyyy/MM/dd HH:mm:ss.ffff") & ", 錯誤編號：" & ErrorCode & ", 錯誤程式：" & HttpContext.Current.Request.Url.ToString & " **")
        '        sw.WriteLine()
        '        sw.WriteLine(Message)
        '        sw.WriteLine()
        '        sw.WriteLine("============================================================================================================================================")
        '        sw.Close()
        '    Catch

        '    End Try

        'End If

    End Sub

#End Region

#Region "建立Error Log檔案"

    '因為Error Log的檔案容量會隨著時間而增長，為避免單一Log檔過大，造成檔案載入過久等問題，所以採用每天一個Log檔案
    Public Shared Function CreateErrorLogFile(ByVal FilePath As String) As Boolean

        Try
            '建立當日的Error Log檔案
            If Not IO.File.Exists(FilePath) Then
                Dim fs As IO.FileStream
                fs = IO.File.Create(FilePath)
                fs.Close()
                fs.Dispose()
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

#End Region

    Public Shared Sub ShowError_ByPage(ByVal currentError As Exception)
        '產生此次錯誤的錯誤編號
        Dim strErrorCode As String = Now.Year & Right("00" & Now.Month, 2) & Right("00" & Now.Day, 2) & Right("00" & Now.Hour, 2) & Right("00" & Now.Minute, 2) & Right("00" & Now.Second, 2) & Right("00" & Now.Millisecond, 2)

        '將錯誤訊息寫入Log記錄檔中
        If Not (TypeOf currentError Is AppException) Then
            AppException.WriteErrorLog(currentError.StackTrace, strErrorCode)
        End If

        Dim context As HttpContext = HttpContext.Current
        Try

            '取得錯誤訊息要顯示的模式
            Dim strShowErrorMode As String = ConfigurationManager.AppSettings("ShowErrorMode").ToString

            If strShowErrorMode = "On" Then '顯示詳細的系統錯誤資訊
                context.Response.Redirect("../../ErrorLog/Error.aspx?ErrorCode=" & strErrorCode & "&ErrorCode2=" & context.Request.Url.ToString)
            End If

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
End Class