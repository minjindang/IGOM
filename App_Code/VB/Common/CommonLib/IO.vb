
'==========================================================================================================
'#建立日期：2007/6/1

'#類別功能：提供檔案IO相關的Function處理

'#與其它類別關聯：
' 尚無

'#修正記錄：

'===========================================================================================================

Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Security
Imports System.Web


Namespace CommonLib

    Public Class IO

        '自動下載某個檔案 (從實體路徑)
        Shared Function DownloadFile(ByVal FilePath As String)

            Dim FileName As String
            Dim buf(0) As Byte

            '取得檔名
            FileName = FilePath

            '取得檔案
            If ReadBinaryFile(buf, FileName) = False Then
                HttpContext.Current.Response.Write("讀取檔案失敗 檔名：[" & FileName & "]")
                HttpContext.Current.Response.End()
            End If

            '準備下載檔案
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Expires = 0
            HttpContext.Current.Response.Buffer = True

            '透過 Header 設定檔名
            FileName = Right(FileName, InStr(StrReverse(FileName), "\") - 1)
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) & Chr(34))
            HttpContext.Current.Response.ContentType = "Application/octet-stream"

            '傳出要讓使用者下載的內容
            HttpContext.Current.Response.BinaryWrite(buf)
            HttpContext.Current.Response.End()

        End Function

        '自動下載某個檔案 (從文字資料)
        '需設定  <globalization requestEncoding="BIG5" responseEncoding="BIG5" /> 
        Shared Function DownloadFile(ByVal FileNameWhenUserDownload As String, ByVal FileBody As String)

            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Expires = 0
            HttpContext.Current.Response.Buffer = True
            'HttpContext.Current.Response.AddHeader("Accept-Language", "zh-tw")
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(FileNameWhenUserDownload, System.Text.Encoding.UTF8) & Chr(34))
            'HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(FileNameWhenUserDownload, System.Text.Encoding.UTF8) & Chr(34))
            HttpContext.Current.Response.ContentType = "Application/octet-stream"

            HttpContext.Current.Response.Write(FileBody)
            HttpContext.Current.Response.End()

        End Function

        '讀取一個實體檔案
        Shared Function ReadBinaryFile(ByRef buffer() As Byte, ByVal FilePath As String) As Boolean

            Dim FileStream As System.IO.Stream

            '先判斷檔案是否存在
            If Not System.IO.File.Exists(FilePath) Then
                ReadBinaryFile = False
                Exit Function
            End If

            '讀取檔案內容
            FileStream = System.IO.File.OpenRead(FilePath)

            '利用StreamReader讀取檔案
            ReDim buffer(FileStream.Length)
            FileStream.Read(buffer, 0, FileStream.Length)

            '關閉物件
            FileStream.Close()

            ReadBinaryFile = True

        End Function

    End Class



End Namespace

