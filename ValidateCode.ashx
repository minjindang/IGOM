<%@ WebHandler Language="VB" Class="ValidateCode" %>
Imports System.Web
Imports System.Drawing
Imports System.Web.SessionState

Public Class ValidateCode
    Implements IHttpHandler
    Implements IRequiresSessionState

    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        CreateCheckCodeImage(GenerateCheckCode(context), context)
    End Sub

    Private Function GenerateCheckCode(context As HttpContext) As String
        Dim checkCode As String = [String].Empty
                
        '驗證碼的字元集，去掉了一些容易混淆的字元
        Dim oCharacter As Char() = {"2"c, "3"c, "4"c, "5"c, "6"c, "8"c, _
                                    "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, _
                                    "F"c, "G"c, "H"c, "J"c, "K"c, "L"c, _
                                    "M"c, "N"c, "P"c, "R"c, "S"c, "T"c, _
                                    "W"c, "X"c, "Y"c}
        Dim oRnd As New Random()
        Dim N1 As Integer
        
        '生成驗證碼字串
        For N1 = 0 To 4
            checkCode += oCharacter(oRnd.Next(oCharacter.Length))
        Next
        
        '儲存在cookie
        'context.Response.Cookies.Add(New HttpCookie("CheckCode", checkCode))

        '儲存在session
        context.Session("CheckCode") = checkCode

        Return checkCode
    End Function

    Private Sub CreateCheckCodeImage(checkCode As String, context As HttpContext)
        If checkCode Is Nothing OrElse checkCode.Trim() = [String].Empty Then
            Return
        End If

        Dim image As New System.Drawing.Bitmap(CInt(Math.Truncate(Math.Ceiling((checkCode.Length * 12.5)))), 22)
        Dim g As Graphics = Graphics.FromImage(image)

        Try
            '生成?机生成器
            Dim random As New Random()

            '清空?片背景色
            g.Clear(Color.White)

            '??片的背景噪音?
            For i As Integer = 0 To 24
                Dim x1 As Integer = random.[Next](image.Width)
                Dim x2 As Integer = random.[Next](image.Width)
                Dim y1 As Integer = random.[Next](image.Height)
                Dim y2 As Integer = random.[Next](image.Height)

                g.DrawLine(New Pen(Color.Silver), x1, y1, x2, y2)
            Next

            Dim font As Font = New System.Drawing.Font("Arial", 11, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic))
            Dim brush As New System.Drawing.Drawing2D.LinearGradientBrush(New Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, True)
            g.DrawString(checkCode, font, brush, 2, 2)

            '??片的前景噪音?
            For i As Integer = 0 To 99
                Dim x As Integer = random.[Next](image.Width)
                Dim y As Integer = random.[Next](image.Height)

                image.SetPixel(x, y, Color.FromArgb(random.[Next]()))
            Next

            '??片的?框?
            g.DrawRectangle(New Pen(Color.Silver), 0, 0, image.Width + 5 , image.Height)

            Dim ms As New System.IO.MemoryStream()
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            context.Response.ClearContent()
            context.Response.ContentType = "image/Gif"
            context.Response.BinaryWrite(ms.ToArray())
        Finally
            g.Dispose()
            image.Dispose()
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
