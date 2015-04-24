Imports System.Data
Imports System.Data.SqlClient

Partial Class SAL2113_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            Dim chk As String = checkrequest()
            If chk <> "" Then
                Response.Write("<script language='javascript'>")
                Response.Write("alert('" & chk.Replace(",", "\n") & "');")
                Response.Write("window.close();")
                Response.Write("</script>")
                Response.End()
                Exit Sub
            End If

            GetReport()

        End If
    End Sub

    Protected Sub GetReport()

        Dim v_UserId As String = LoginManager.UserId      '------------- 使用者身分證號
        Dim v_UserOrgId As String = LoginManager.OrgCode  '--------------------使用者 機關代號 
        Dim v_nhino As String = HttpUtility.HtmlEncode(Request("nhino").ToString)
        Dim v_amt As String = HttpUtility.HtmlEncode(Request("amt").ToString)
        Dim v_ym As String = HttpUtility.HtmlEncode(Request("ym").ToString)

        Dim rpt_nhi_name As String = ""
        Dim rpt_nhi_code As String = ""
        Dim rpt_unit_tel As String = ""
        Dim rpt_ym As String = ""
        Dim rpt_datelimit As String = ""


        ' '' 取得 機關基本資料
        'Using cmd As SqlCommand = New SqlCommand()
        '    cmd.CommandText = "select * from sal_saunit where unit_no = @orgid "
        '    cmd.Parameters.AddWithValue("@orgid", v_UserOrgId)

        '    'Dim rs As SqlDataReader = Me.GetExecuteReaderBySqlCommand(cmd)

        '    'If rs.Read Then
        '    '    rpt_nhi_name = rs("unit_dep").ToString
        '    '    'If rs("unit_short_name").ToString <> "" Then
        '    '    '    rpt_nhi_name = rpt_nhi_name & "(" & rs("unit_short_name").ToString & ")"
        '    '    'End If

        '    '    rpt_unit_tel = rs("unit_tel").ToString
        '    'End If
        'End Using

        'Using cmd As SqlCommand = New SqlCommand
        '    cmd.CommandText = "select * from sal_sanhi where nhi_orgid = @orgid and nhi_no = @nhino"
        '    cmd.Parameters.AddWithValue("@orgid", v_UserOrgId)
        '    cmd.Parameters.AddWithValue("@nhino", v_nhino)

        '    'Dim rs As SqlDataReader = Me.GetExecuteReaderBySqlCommand(cmd)

        '    'If rs.Read Then
        '    '    ''rpt_nhi_name = rs("nhi_name").ToString
        '    '    rpt_nhi_code = rs("nhi_code").ToString
        '    'End If

        'End Using


        '' 取得 繳費年月資料
        Dim pay_ym As Date = Date.Parse(CStr(CInt(Left(v_ym, 3)) + 1911) & "-" & v_ym.Substring(3, 2) & "-01")
        pay_ym = DateAdd(DateInterval.Month, 2, pay_ym)
        pay_ym = DateAdd(DateInterval.Day, -1, pay_ym)

        rpt_ym = v_ym.Substring(0, 3) & "/" & v_ym.Substring(3, 2)

        Me.lbUNhiCode.Text = rpt_nhi_code
        Me.lbUNhiCode2.Text = rpt_nhi_code

        Me.lbNhiName.Text = rpt_nhi_name
        Me.lbUnitTel.Text = rpt_unit_tel

        Me.lbYM.Text = rpt_ym
        Me.lbYM2.Text = rpt_ym

        Me.lbPayLimit.Text = CStr(CInt(pay_ym.ToString("yyyy")) - 1911) & pay_ym.ToString("/MM/dd")

        Me.lbAmt.Text = FormatNumber(v_amt, 0)
        Me.lbAmt2.Text = FormatNumber(v_amt, 0)
        Me.lbPrintDate.Text = CStr(CInt(Now.ToString("yyyy")) - 1911) & Now.ToString("/MM/dd")

        '' ======== 第一段條碼（9）：滯納金起算日 (501231)+ 代收項目(600)
        Dim barcode1 As String = "501231600"

        '' ======== 第二段條碼（16）：
        Dim barcode2 As String = ""

        '' 1-2(2碼) 檢查碼 外廠商固定放00
        barcode2 &= "00"

        '' 3-4(2碼) 繳款別
        barcode2 &= "61"

        '' 5-12(8碼) 扣費單位統一編號 前8碼
        barcode2 &= Left(rpt_nhi_code, 8)

        '' 13-15(3碼) 給付年月(編碼)
        barcode2 &= getcodeym(v_ym)

        '' 16(1碼)列印來源 外廠商固定放5
        barcode2 &= "5"

        '' ======== 第三段條碼（15）：
        Dim barcode3 As String = ""
        Dim barcode3_1 As String = ""
        Dim barcode3_2 As String = ""
        Dim barcode3_3 As String = ""

        '' 1-4(4碼) 所得給付年月yymm（4）
        barcode3_1 &= v_ym.Substring(1, 4)

        '' 7-15(9碼) 應繳金額（9）
        'barcode3_3 &= lpad(v_amt, 9, "0")

        '' 5-6(2碼) 檢碼（2）
        barcode3_2 = barcode3_check(barcode1, barcode2, barcode3_1, barcode3_3)

        barcode3 = barcode3_1 & barcode3_2 & barcode3_3

        Me.lbBarCode.Text = barcode1 & "<br />" & barcode2 & "<br />" & barcode3

        Me.imgCode1.ImageUrl = "code39.aspx?mycode=" & barcode1
        Me.imgCode2.ImageUrl = "code39.aspx?mycode=" & barcode2
        Me.imgCode3.ImageUrl = "code39.aspx?mycode=" & barcode3

    End Sub

    Protected Function checkrequest() As String
        Dim rv As String = ""
        Dim v_nhino As String = HttpUtility.HtmlEncode(Request("nhino").ToString)
        Dim v_amt As String = HttpUtility.HtmlEncode(Request("amt").ToString)
        Dim v_ym As String = HttpUtility.HtmlEncode(Request("ym").ToString)

        Try
            If CInt(v_amt) <= 0 Then
                rv &= "繳款金額錯誤,"
            End If
        Catch ex As Exception
            rv &= "繳款金額錯誤,"
        End Try

        If (v_ym.Length <> 5) Or (CStr(v_ym) < 10112) Then
            rv &= "給付年月錯誤,"
        Else
            Try
                Dim t_date As Date = Date.Parse(CStr(CInt(Left(v_ym, 3)) + 1911) & "-" & v_ym.Substring(3, 2) & "-01")
            Catch ex As Exception
                rv &= "給付年月錯誤,"
            End Try
        End If

        ' '' 取得 機關基本資料
        'Dim v_UserId As String = LoginManager.UserId      '------------- 使用者身分證號
        'Dim v_UserOrgId As String = LoginManager.OrgCode  '--------------------使用者 機關代號 
        'Using cmd As SqlCommand = New SqlCommand
        '    cmd.CommandText = "select * from sal_sanhi where nhi_orgid = @orgid and nhi_no = @nhino"
        '    cmd.Parameters.AddWithValue("@orgid", v_UserOrgId)
        '    cmd.Parameters.AddWithValue("@nhino", v_nhino)

        '    'Dim rs As SqlDataReader = Me.GetExecuteReaderBySqlCommand(cmd)

        '    'If rs.Read Then
        '    '    ' 檢查投保單位代碼
        '    '    Dim v_nhicode As String = rs("nhi_code").ToString

        '    '    If v_nhicode.Length < 8 Then
        '    '        rv &= "投保單位資料錯誤,"
        '    '    End If
        '    'Else
        '    '    rv &= "投保單位資料錯誤,"
        '    'End If

        'End Using

        Return rv
    End Function

    Protected Function barcode3_check(ByVal barcode1 As String, ByVal barcode2 As String, ByVal barcode3_1 As String, ByVal barcode3_3 As String) As String
        Dim rv As String = ""

        Dim chk1 As Integer = 0
        Dim chk2 As Integer = 0

        For i As Integer = 0 To barcode1.Length - 1
            If (i + 1) Mod 2 = 1 Then
                '' 單數
                chk1 += CInt(barcode1.Substring(i, 1))
            Else
                chk2 += CInt(barcode1.Substring(i, 1))
            End If
        Next

        For i As Integer = 0 To barcode2.Length - 1
            If (i + 1) Mod 2 = 1 Then
                '' 單數
                chk1 += CInt(barcode2.Substring(i, 1))
            Else
                chk2 += CInt(barcode2.Substring(i, 1))
            End If
        Next

        For i As Integer = 0 To barcode3_1.Length - 1
            If (i + 1) Mod 2 = 1 Then
                '' 單數
                chk1 += CInt(barcode3_1.Substring(i, 1))
            Else
                chk2 += CInt(barcode3_1.Substring(i, 1))
            End If
        Next

        For i As Integer = 0 To barcode3_3.Length - 1
            If (i + 1) Mod 2 = 1 Then
                '' 單數
                chk1 += CInt(barcode3_3.Substring(i, 1))
            Else
                chk2 += CInt(barcode3_3.Substring(i, 1))
            End If
        Next

        chk1 = chk1 Mod 11
        chk2 = chk2 Mod 11

        If chk1 = 0 Then
            rv &= "A"
        ElseIf chk1 = 10 Then
            rv &= "B"
        Else
            rv &= CStr(chk1)
        End If

        If chk2 = 0 Then
            rv &= "X"
        ElseIf chk2 = 10 Then
            rv &= "Y"
        Else
            rv &= CStr(chk2)
        End If

        Return rv
    End Function

    Protected Function getcodeym(ByVal v_ym As String) As String
        Dim rv As String = ""
        Dim i As Integer = 0

        Dim yy As Integer = CInt(v_ym.Substring(0, 3))
        If yy < 102 Then
            i = 0
        Else
            i = Int((yy - 102) / 10) + 1
        End If

        Dim ym As Integer = v_ym.Substring(2, 3)
        ym = ym + (i * 20)
        rv = CStr(ym)

        Return rv
    End Function

    ' MonthLastDay  ' 傳回某月最後一天的日期 '
    Protected Function MonthLastDay(ByVal pDate As Date) As Date
        Return DateAdd("d", -1, DateSerial(Year(Now), Month(Now), 1))
    End Function

End Class
