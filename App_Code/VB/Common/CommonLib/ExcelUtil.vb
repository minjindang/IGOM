Imports Microsoft.VisualBasic
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Web
Imports System.Text
Imports System

Public Class ExcelUtil

    Public Shared Sub replaceValue(ByVal range As Excel.Range, ByVal tag As String, ByVal value As String)
        range.Value = Replace(range.Value, "##" & tag & "##", value)
    End Sub


    Public Shared Sub toFile(ByVal ap As Excel.Application, ByVal wb As Excel.Workbook, ByVal name As String)

        Dim filename As String = System.Guid.NewGuid().ToString()
        Dim exlfpath As String = HttpContext.Current.Server.MapPath("~\Report\ExcelTemp\")
        Dim exlfname As String = filename & ".xls"

        wb.SaveAs(exlfpath & exlfname, Excel.XlFileFormat.xlWorkbookNormal, , , , , , , , , , )

        ap.DisplayAlerts = False

        wb.Close()
        ap.Quit()

        releaseFile(ap, wb)

        '寫入Binary
        Dim fs As FileStream = File.OpenRead(exlfpath & exlfname)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bw As BinaryWriter = New BinaryWriter(HttpContext.Current.Response.OutputStream)
        Dim buffer(1024) As Byte
        Dim count As Integer = br.Read(buffer, 0, buffer.Length)
        Do While count > 0
            bw.Write(buffer, 0, count)
            count = br.Read(buffer, 0, buffer.Length)
        Loop
        br.Close()
        bw.Close()

        '刪除Excel
        My.Computer.FileSystem.DeleteFile(exlfpath & exlfname, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        '將 Binary 利用 Http header 匯出 Excel 檔
        HttpContext.Current.Response.ContentType = "Application/excel"
        HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & HttpUtility.UrlEncode(name, Encoding.UTF8) & ".xls")
        HttpContext.Current.Response.End()
    End Sub

    Public Shared Sub releaseFile(ByVal ap As Excel.Application, ByVal wb As Excel.Workbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(ap)
        wb = Nothing
        ap = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

End Class
