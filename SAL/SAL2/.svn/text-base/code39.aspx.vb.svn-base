Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Drawing.Text
Imports System.Drawing.Imaging

Partial Class Salary_test_code39
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁 
        Dim mycode As String = Request("mycode")
        If Not (mycode = "") Then
            Dim sstr, schr As String
            'sstr = "*-%$*" 
            sstr = "*" & mycode & "*"
            Dim hbh, hbw, px, py, pw, i, j As Integer
            py = 30
            pw = 0
            hbh = 45
            hbw = sstr.Length * 13
            Dim BMP As Bitmap = New Bitmap(hbw, hbh, Imaging.PixelFormat.Format32bppPArgb)
            Dim G As Graphics = Graphics.FromImage(BMP)
            G.TextRenderingHint = TextRenderingHint.AntiAlias
            G.Clear(Color.White)
            Dim ps1 As Brush = New SolidBrush(Color.White)
            G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            G.FillRectangle(ps1, 0, 0, hbw, hbh)
            For i = 0 To sstr.Length - 1
                schr = barcode(sstr.Substring(i, 1).ToUpper)

                For j = 0 To 3
                    If schr.Substring(j, 1).Equals("0") Then
                        G.DrawLine(Pens.Black, px, 0, px, py)
                    Else
                        G.DrawLine(Pens.Black, px, 0, px, py)
                        G.DrawLine(Pens.Black, px + 1, 0, px + 1, py)
                        px += 1
                    End If
                    px += 1
                    If schr.Substring(j + 5, 1).Equals("0") Then
                        G.DrawLine(Pens.White, px, 0, px, py)
                    Else
                        G.DrawLine(Pens.White, px, 0, px, py)
                        G.DrawLine(Pens.White, px + 1, 0, px + 1, py)
                        px += 1
                    End If
                    px += 1
                Next j
                If schr.Substring(4, 1).Equals("0") Then
                    G.DrawLine(Pens.Black, px, 0, px, py)
                Else
                    G.DrawLine(Pens.Black, px, 0, px, py)
                    G.DrawLine(Pens.Black, px + 1, 0, px + 1, py)
                    px += 1
                End If
                px += 2

            Next i
            Dim x As Integer = 0
            Dim addx As Integer
            addx = 13
            'G.DrawString("-", New Font("Arial", 10, FontStyle.Italic), SystemBrushes.WindowText, New PointF(x, 20))
            x += addx
            For i = 0 To mycode.Length - 1
                G.DrawString(mycode.Chars(i), New Font("Arial", 10, FontStyle.Italic), SystemBrushes.WindowText, New PointF(x, 30))
                x = x + addx
            Next
            'G.DrawString("-", New Font("Arial", 10, FontStyle.Italic), SystemBrushes.WindowText, New PointF(x, 20))

            BMP.Save(Response.OutputStream, ImageFormat.Jpeg)
            G.Dispose()
            BMP.Dispose()
        Else
            Dim hbh, hbw, px, py, pw, i, j As Integer
            py = 20
            pw = 0
            hbh = 35
            hbw = 100
            Dim BMP As Bitmap = New Bitmap(hbw, hbh, Imaging.PixelFormat.Format32bppPArgb)
            Dim G As Graphics = Graphics.FromImage(BMP)
            G.TextRenderingHint = TextRenderingHint.AntiAlias
            G.Clear(Color.White)
            G.DrawString("無條碼產生", _
                              New Font("標楷體", 12, FontStyle.Regular), _
                               SystemBrushes.WindowText, New PointF(0, 20))

            BMP.Save(Response.OutputStream, ImageFormat.Jpeg)
            G.Dispose()
            BMP.Dispose()

        End If
    End Sub

    Function barcode(ByVal code As String) As String
        Select Case code
            Case 0
                code = "001100100"
            Case 1
                code = "100010100"
            Case 2
                code = "010010100"
            Case 3
                code = "110000100"
            Case 4
                code = "001010100"
            Case 5
                code = "101000100"
            Case 6
                code = "011000100"
            Case 7
                code = "000110100"
            Case 8
                code = "100100100"
            Case 9
                code = "010100100"
            Case "A"
                code = "100010010"
            Case "B"
                code = "010010010"
            Case "C"
                code = "110000010"
            Case "D"
                code = "001010010"
            Case "E"
                code = "101000010"
            Case "F"
                code = "011000010"
            Case "G"
                code = "000110010"
            Case "H"
                code = "100100010"
            Case "I"
                code = "010100010"
            Case "J"
                code = "001100010"
            Case "K"
                code = "100010001"
            Case "L"
                code = "010010001"
            Case "M"
                code = "110000001"
            Case "N"
                code = "001010001"
            Case "O"
                code = "101000001"
            Case "P"
                code = "011000001"
            Case "Q"
                code = "000110001"
            Case "R"
                code = "100100001"
            Case "S"
                code = "010100001"
            Case "T"
                code = "001100001"
            Case "U"
                code = "100011000"
            Case "V"
                code = "010011000"
            Case "W"
                code = "110001000"
            Case "X"
                code = "001011000"
            Case "Y"
                code = "101001000"
            Case "Z"
                code = "011001000"
            Case "*"
                code = "001101000"
            Case "-"
                code = "000111000" '好像變識不出來 
            Case "%"
                code = "100101000" '好像變識不出來 
            Case "$"
                code = "010101000" '好像變識不出來 
            Case Else
                code = "010101000" '都不是就印$ 
        End Select

        Return code
    End Function

End Class
