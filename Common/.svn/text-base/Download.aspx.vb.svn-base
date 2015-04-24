Imports System.Data
Imports Microsoft.Office.Interop
Imports System.IO
Imports FSCPLM.Logic
Imports CommonLib.DTReport

Partial Class Common_Download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If "PDF".Equals(Request.QueryString("T").ToUpper()) Then
            dlPDF(Request.QueryString("F"))
        End If
    End Sub


    Protected Sub dlPDF(ByVal filename As String)

        Dim pdfpath As String = HttpContext.Current.Server.MapPath("~\Report\PdfTemp\")
        Dim pdffname As String = filename & ".pdf"

        '寫入Binary
        Dim fs As FileStream = File.OpenRead(pdfpath & pdffname)
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

        '刪除PDF
        My.Computer.FileSystem.DeleteFile(pdfpath & pdffname, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        '將 Binary 利用 Http header 匯出 PDF 檔
        HttpContext.Current.Response.ContentType = "Application/pdf"
        HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & HttpUtility.UrlEncode("支出憑證黏存單", Encoding.UTF8) & ".pdf")
        HttpContext.Current.Response.End()

    End Sub
End Class
