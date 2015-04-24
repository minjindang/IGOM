Imports System.Data

Partial Class SAL2113_02
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
        Dim v_UserOrgId As String = LoginManager.OrgCode   '--------------------使用者 機關代號 
        Dim v_kind_code As String = HttpUtility.HtmlEncode(Request("kind").ToString)
        Dim v_kind As String = ""

        'Select Case v_kind
        '    Case "62"
        '        Me.lbKind.Text = "62<br/>逾當月投保金額四倍之部分獎金"
        '        Me.lbKind2.Text = "62<br/>逾當月投保金額四倍之部分獎金"
        '    Case "63"
        '        Me.lbKind.Text = "63<br/>非所屬投保單位給付之薪資所得"
        '        Me.lbKind2.Text = "63<br/>非所屬投保單位給付之薪資所得"
        '    Case "65"
        '        Me.lbKind.Text = "65<br/>執行業務收入"
        '        Me.lbKind2.Text = "65<br/>執行業務收入"
        '    Case "67"
        '        Me.lbKind.Text = "67<br/>利息所得－非信託"
        '        Me.lbKind2.Text = "67<br/>利息所得－非信託"
        '    Case "68"
        '        Me.lbKind.Text = "68<br/>租金收入－非信託"
        '        Me.lbKind2.Text = "68<br/>租金收入－非信託"
        '    Case Else
        '        Me.lbKind.Text = "<br/>"
        '        Me.lbKind2.Text = "<br/>"
        'End Select

        Select Case v_kind_code
            Case "001" '薪資所得格式50(薪資）
                v_kind = "62" '逾當月投保金額四倍之部分獎金
            Case "0011"
                v_kind = "63" '非所屬投保單位給付之薪資所得
            Case "002" '薪資所得格式51（租賃）
                v_kind = "68"
            Case "003" '薪資所得格式52（短期票券）
                v_kind = "66"
            Case "005" '薪資所得格式54（盈餘）
                v_kind = "66"
            Case "006" '薪資所得格式5A（利息(享儲蓄投資特扣額)）
                v_kind = "67"
            Case "007" '薪資所得格式5B（利息(未享儲蓄投資特扣額)）
                v_kind = "67"
            Case "013" '薪資所得格式9A（執行業務所得）
                v_kind = "65"
            Case "014" '薪資所得格式9B（稿費所得）
                v_kind = "65"
            Case Else
                v_kind = "--"
        End Select
        '", CASE C2.CODE_NO  " & _
        '  "WHEN '001' THEN  PAYO_PARTTIME  " & 
        '  "WHEN '002' THEN '租金收入' _
        '  "WHEN '003' THEN '利息所得'  " & _
        '  "WHEN '005' THEN '股利所得'  " & _
        '  "WHEN '006' THEN '利息所得'  " & _
        '  "WHEN '007' THEN '利息所得'  " & _
        '  "WHEN '013' THEN '執行業務收入'  " & _
        '  "WHEN '014' THEN '執行業務收入'  " & _
        'END AS ITEMNAME " & _

        Dim v_amt As String = HttpUtility.HtmlEncode(Request("amt").ToString)
        Dim v_ym As String = HttpUtility.HtmlEncode(Request("ym").ToString)

        Dim rpt_unit_name As String = ""
        Dim rpt_unit_no As String = ""
        Dim rpt_unit_tel As String = ""
        Dim rpt_ym As String = ""
        Dim rpt_datelimit As String = ""


        '' 取得 機關基本資料
        Dim sql As String = "select * from SAL_saunit where unit_no ='" & v_UserOrgId & "'"
        Using ta As New DB_TableAdapters.DB_TableAdapter
            Using t As DataTable = ta.spExeSQLGetDataTable(sql)
                If t.Rows.Count > 0 Then
                    Dim rs As DataRow = t.Rows(0)
                    rpt_unit_name = rs("unit_dep").ToString
                    rpt_unit_no = rs("unit_tax").ToString
                    rpt_unit_tel = rs("unit_tel").ToString
                End If
            End Using
        End Using
        '' 取得 繳費年月資料
        Dim pay_ym As Date = Date.Parse(CStr(CInt(Left(v_ym, 3)) + 1911) & "-" & v_ym.Substring(3, 2) & "-01")
        pay_ym = DateAdd(DateInterval.Month, 2, pay_ym)
        pay_ym = DateAdd(DateInterval.Day, -1, pay_ym)

        rpt_ym = v_ym.Substring(0, 3) & "/" & v_ym.Substring(3, 2)

        Me.lbUnitNo.Text = rpt_unit_no
        Me.lbUnitNo2.Text = rpt_unit_no

        Me.lbUnitName.Text = rpt_unit_name
        Me.lbUnitTel.Text = rpt_unit_tel

        Me.lbYM.Text = rpt_ym
        Me.lbYM2.Text = rpt_ym

        Me.lbPayLimit.Text = CStr(CInt(pay_ym.ToString("yyyy")) - 1911) & pay_ym.ToString("/MM/dd")
        '  Case "001" '薪資所得格式50(薪資）
        'v_kind = "63" '逾當月投保金額四倍之部分獎金
        '    Case "0011"
        'v_kind = "62" '非所屬投保單位給付之薪資所得
        '    Case "002" '薪資所得格式51（租賃）
        'v_kind = "68"
        '    Case "003" '薪資所得格式52（短期票券）
        'v_kind = "66"
        '    Case "005" '薪資所得格式54（盈餘）
        'v_kind = "66"
        '    Case "006" '薪資所得格式5A（利息(享儲蓄投資特扣額)）
        'v_kind = "67"
        '    Case "007" '薪資所得格式5B（利息(未享儲蓄投資特扣額)）
        'v_kind = "67"
        '    Case "013" '薪資所得格式9A（執行業務所得）
        'v_kind = "65"
        '    Case "014" '薪資所得格式9B（稿費所得）
        'v_kind = "65"
        '    Case Else
        'v_kind = "--"
        Select Case v_kind
            Case "62"
                Me.lbKind.Text = "62<br/>逾當月投保金額四倍之部分獎金"
                Me.lbKind2.Text = "62<br/>逾當月投保金額四倍之部分獎金"
            Case "63"
                Me.lbKind.Text = "63<br/>非所屬投保單位給付之薪資所得"
                Me.lbKind2.Text = "63<br/>非所屬投保單位給付之薪資所得"
            Case "65"
                Me.lbKind.Text = "65<br/>執行業務收入"
                Me.lbKind2.Text = "65<br/>執行業務收入"
            Case "66"
                Me.lbKind.Text = "66<br/>股利所得"
                Me.lbKind2.Text = "66<br/>股利所得"
            Case "67"
                Me.lbKind.Text = "67<br/>利息所得－非信託"
                Me.lbKind2.Text = "67<br/>利息所得－非信託"
            Case "68"
                Me.lbKind.Text = "68<br/>租金收入－非信託"
                Me.lbKind2.Text = "68<br/>租金收入－非信託"
            Case Else
                Me.lbKind.Text = "<br/>"
                Me.lbKind2.Text = "<br/>"
        End Select

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
        barcode2 &= v_kind

        '' 5-12(8碼) 扣費單位統一編號
        barcode2 &= rpt_unit_no

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
        barcode3_3 &= lpad(v_amt, 9, "0")

        '' 5-6(2碼) 檢碼（2）
        barcode3_2 = barcode3_check(barcode1, barcode2, barcode3_1, barcode3_3)

        barcode3 = barcode3_1 & barcode3_2 & barcode3_3

        Me.lbBarCode.Text = barcode1 & "<br />" & barcode2 & "<br />" & barcode3

        Me.imgCode1.ImageUrl = "code39.aspx?mycode=" & barcode1
        Me.imgCode2.ImageUrl = "code39.aspx?mycode=" & barcode2
        Me.imgCode3.ImageUrl = "code39.aspx?mycode=" & barcode3

    End Sub
    Shared Function lpad(ByVal str, ByVal fulllen, ByVal fulltext)  '// 左補字串 from amman

        Dim strlen = 0
        Dim text = ""

        strlen = str.ToString.Length
        text = str
        While strlen < fulllen
            strlen = strlen + 1
            text = fulltext & text
        End While
        lpad = text
    End Function

    Protected Function checkrequest() As String
        Dim rv As String = ""

        Dim v_kind_code As String = HttpUtility.HtmlEncode(Request("kind").ToString)
        Dim v_amt As String = HttpUtility.HtmlEncode(Request("amt").ToString)
        Dim v_ym As String = HttpUtility.HtmlEncode(Request("ym").ToString)

        '' 繳款別 62-68
        '   001 =      逾當月投保金額四倍之部分獎金(62)---薪資科目50
        '   002 =      非所屬投保單位給付之薪資所得(63)---薪資科目50
        '   003 =      執行業務收入(65)---薪資科目9A
        '   005 =      利息所得(67)---薪資科目5A,5B
        '   006 =      租金所得(68)---薪資科目51


        '", CASE C2.CODE_NO  " & _
        '  "WHEN '001' THEN  PAYO_PARTTIME  " & _
        '  "WHEN '013' THEN '執行業務收入'  " & _
        '  "WHEN '014' THEN '執行業務收入'  " & _
        '  "WHEN '005' THEN '股利所得'  " & _
        '  "WHEN '006' THEN '利息所得'  " & _
        '  "WHEN '007' THEN '利息所得'  " & _
        '  "WHEN '003' THEN '利息所得'  " & _
        '  "WHEN '002' THEN '租金收入' END AS ITEMNAME " & _

        Select Case v_kind_code
            Case "001", "0011", "002", "003", "005", "006", "007", "013", "014"
            Case Else
                rv &= "繳款別代碼錯誤,"
        End Select

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

        '' 取得 機關基本資料
        Dim v_UserId As String = LoginManager.UserId      '------------- 使用者身分證號
        Dim v_UserOrgId As String = LoginManager.OrgCode   '--------------------使用者 機關代號 
        Dim sql As String = "select * from SAL_saunit where unit_no ='" & v_UserOrgId & "'"
        Using ta As New DB_TableAdapters.DB_TableAdapter
            Using t As DataTable = ta.spExeSQLGetDataTable(sql)
                If t.Rows.Count > 0 Then
                    Dim rs As DataRow = t.Rows(0)
                    Dim unit_tax As String = rs("unit_tax").ToString

                    If unit_tax.Length = 8 Then
                        Dim res(8) As Integer
                        Dim key As String = "12121241"
                        Dim isModeTwo As Boolean = False
                        Dim result As Integer = 0

                        For i As Integer = 0 To 7
                            Dim tmp As Integer = CInt(unit_tax.Substring(i, 1)) * CInt(key.Substring(i, 1))
                            res(i) = Int(tmp / 10) + CInt(tmp Mod 10)

                            If (i = 6) And (CInt(unit_tax.Substring(i, 1)) = 7) Then
                                isModeTwo = True
                            End If
                        Next

                        For s As Integer = 0 To 7
                            result += res(s)
                        Next

                        If isModeTwo Then
                            If ((result Mod 10) <> 0) And (((result + 1) Mod 10) <> 0) Then
                                rv &= "統一編號編碼不正確,"
                            End If
                        Else
                            If ((result Mod 10) <> 0) Then
                                rv &= "統一編號編碼不正確,"
                            End If
                        End If
                    Else
                        rv &= "統一編號錯誤,"
                    End If

                End If
            End Using
        End Using
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
