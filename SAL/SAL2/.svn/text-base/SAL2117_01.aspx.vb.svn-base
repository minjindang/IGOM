Imports SALARY.Logic

Partial Class SAL2117_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then
            Me.TextBox_orgid.Text = LoginManager.OrgCode
            Me.TextBox_mid.Text = LoginManager.UserId
            Dim y As String = Now.ToString("yyyyMM")
            ddl_Budget_code.Orgid = LoginManager.OrgCode
            Me.UcDateDropDownList_YM_Start.Kind = "YM"
            Me.UcDateDropDownList_YM_Start.year_s = CInt(Now.ToString("yyyy")) - 2
            Me.UcDateDropDownList_YM_Start.DateStr = y
        End If

    End Sub

    Protected Sub Button_reportCover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_reportCover.Click
        'Dim url As String = "SAL2117_02.aspx"
        'url &= "?startYYMM=" & UcDateDropDownList_YM_Start.DateStr
        'CommonFun.OpenWindow(Me, url, "top=5,left=50,width=750,height=450,toolbar=yes,scrollbars=yes,menubar=yes")

        Me.reportPrint()
    End Sub

    Dim v_startYYMM, strPayBudgeCode As String '查詢條件起迄時間
    Dim show_MM As String '顯示的月份
    Dim v_year, v_month, v_day As String '印表時間(年月日)
    Dim Sql As String '用到的sql語法
    Dim v_content, v_Report_Title, v_head As String '表單內文
    Dim pagelineHeight As Integer = 800 + 15    ' 每頁資料行高800(25筆資料 for A3)
    Dim lineHeight As Integer = 0    ' 目前資料行高
    Dim pageCount, totalCnt, totalAmt1, totalAmt2, totalAmt3, totalAmt4, totalAmt5, totalAmt6, totalAmt7 As Integer '總人數及總計金額

    Protected Sub reportPrint()
        v_startYYMM = UcDateDropDownList_YM_Start.DateStr
        show_MM = IIf(v_startYYMM.Substring(4, 2).StartsWith("0"), v_startYYMM.Substring(5, 1), v_startYYMM.Substring(4, 2))
        strPayBudgeCode = ddl_Budget_code.SelectedValue
        v_year = DateTime.Now.Year - 1911 '現在民國年
        v_month = DateTime.Now.Month '現在月份
        v_day = DateTime.Now.Day '現在日期

        Me.start()
        '  ToExcel()
    End Sub

    Protected Sub start()
        Dim bll As New SAL.Logic.SAL2117()

        Using t As DB_.DB_DataTable = bll.GetStartData(v_startYYMM, strPayBudgeCode)
            totalCnt = t.Rows.Count

            If (totalCnt > 0) Then
                For j As Int32 = 0 To totalCnt - 1
                    If j = 0 Then
                        PageStart()
                    End If

                    Dim Amt1 As Integer
                    Dim Amt2 As Integer
                    Dim Amt3 As Integer
                    Dim Amt4 As Integer
                    Dim Amt5 As Integer
                    Dim Amt6 As Integer
                    Dim Amt7 As Integer

                    Amt1 = t.Rows(j)("工餉")
                    Amt2 = t.Rows(j)("工作補助費")
                    Amt3 = t.Rows(j)("協查研究費")
                    Amt4 = t.Rows(j)("調整待遇-工餉")
                    Amt5 = t.Rows(j)("調整待遇-工作補助費")
                    Amt6 = t.Rows(j)("交通費")
                    Amt7 = t.Rows(j)("應發數")

                    totalAmt1 += Amt1
                    totalAmt2 += Amt2
                    totalAmt3 += Amt3
                    totalAmt4 += Amt4
                    totalAmt5 += Amt5
                    totalAmt6 += Amt6
                    totalAmt7 += Amt7

                    v_content = "<tr>"
                    v_content &= "<td align=center height=32>"
                    v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("職別") & "</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=center>"
                    v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("姓名") & "</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=center>"
                    v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("餉級") & "</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=center>"
                    v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("薪點") & "</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt1) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt2) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt3) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt4) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt5) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt6) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=right>"
                    v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt7) & "&nbsp;</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=left id='en_newline'>" '設此id是為了讓英數字能滿長換行
                    v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("備註") & "</font>"
                    v_content &= "</td>"
                    v_content &= "</tr>"

                    Dim dataHeight As Double = 0 '行高
                    Dim RemarkBits As Int32 = System.Text.Encoding.Default.GetBytes(t.Rows(j)("備註")).Length() '判斷備註的位元長度(中文兩位元 英數字一位元)

                    If RemarkBits <= 24 Then '一行能容納12個中文字或24個半形英數字
                        dataHeight = 32 '若備註只有一行則行高設為32
                    Else
                        If RemarkBits Mod 24 = 0 Then '一行能容納12個中文字或24個半形英數字
                            dataHeight = (RemarkBits \ 24) * 18.85  '1行平均行高是18.85
                        Else
                            dataHeight = (RemarkBits \ 24 + 1) * 18.85  '1行平均行高是18.85
                        End If
                    End If

                    lineHeight += dataHeight '表身資料高度
                    If lineHeight >= pagelineHeight Then
                        lineHeight = dataHeight
                        Me.Literal1.Text += "</table>"
                        PageSeprator() '加上分頁符號
                        PageStart()
                        Me.Literal1.Text += v_content
                    Else
                        Me.Literal1.Text += v_content
                    End If

                Next

                For i As Int32 = 0 To (pagelineHeight - lineHeight) / 32 - 1
                    v_content = "<tr>"
                    For k As Int32 = 0 To 11
                        v_content &= "<td align=left height=32>"
                        v_content &= "<font size='3'>&nbsp;</font>"
                        v_content &= "</td>"
                    Next
                    v_content &= "</tr>"
                    Me.Literal1.Text += v_content
                Next
                v_content = "<tr>"
                v_content &= "<td align=center height=32>"
                v_content &= "<font face='標楷體' size='3'>總計</font>"
                v_content &= "</td>"
                v_content &= "<td align=center>"
                v_content &= "<font face='標楷體' size='3'>" & totalCnt & "人</font>"
                v_content &= "</td>"
                v_content &= "<td align=left>"
                v_content &= "<font size='3'>&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=left>"
                v_content &= "<font size='3'>&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt1) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt2) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt3) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt4) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt5) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt6) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=right>"
                v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt7) & "&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "<td align=left>"
                v_content &= "<font size='3'>&nbsp;</font>"
                v_content &= "</td>"
                v_content &= "</tr>"
                Me.Literal1.Text += v_content
                Me.Literal1.Text += "</table>"

                ToExcel()
            Else
                '  ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('查無資料');window.close(); void(0);", True)
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無資料")
                Return
            End If

        End Using

    End Sub

    Protected Sub PageStart()
        pageCount += 1 '頁數加1
        v_Report_Title = "<style type='text/css'>"
        v_Report_Title &= " #en_newline{word-break:break-all;}"
        v_Report_Title &= "</style>"
        v_Report_Title &= "<table width=100% border='0' cellspacing='0' cellpadding='0'>"
        v_Report_Title &= "<tr>"
        v_Report_Title &= "<td width='20%' align=center></td>"
        v_Report_Title &= "<td width='60%' align=center>"
        v_Report_Title &= "<font face='標楷體' size='5'>監察院技工、工友" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        v_Report_Title &= "</td>"
        v_Report_Title &= "<td width='10%' align=center>"
        v_Report_Title &= "<font face='標楷體' size='2'>第" & pageCount & "頁</font>"
        v_Report_Title &= "</td>"
        v_Report_Title &= "<td width='10%' align=center>"
        v_Report_Title &= "<font face='標楷體' size='2'>" & v_year & "/" & v_month & "/" & v_day & "</font>"
        v_Report_Title &= "</td>"
        v_Report_Title &= "</tr>"
        v_Report_Title &= "</table>"
        v_head = "<table width=100% border='1' cellspacing='0' cellpadding='0'>"
        v_head &= "<tr>"
        v_head &= "<td rowspan=2 align=center width='7.1%'>"
        v_head &= "<font face='標楷體' size='3'>" & "職別" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='7.1%'>"
        v_head &= "<font face='標楷體' size='3'>" & "姓名" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='7.1%'>"
        v_head &= "<font face='標楷體' size='3'>" & "餉級" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='7.1%'>"
        v_head &= "<font face='標楷體' size='3'>" & "薪點" & "</font>"
        v_head &= "</td>"
        v_head &= "<td colspan=3 align=center>"
        v_head &= "<font face='標楷體' size='3'>" & "工餉" & "</font>"
        v_head &= "</td>"
        v_head &= "<td colspan=2 align=center>"
        v_head &= "<font face='標楷體' size='3'>" & "調整待遇" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "交通費" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='14.4%'>"
        v_head &= "<font face='標楷體' size='3'>" & "應發數" & "</font>"
        v_head &= "</td>"
        v_head &= "<td rowspan=2 align=center width='14%'>"
        v_head &= "<font face='標楷體' size='3'>" & "備註" & "</font>"
        v_head &= "</td>"
        v_head &= "</tr>"
        v_head &= "<tr>"
        v_head &= "<td align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "工餉" & "</font>"
        v_head &= "</td>"
        v_head &= "<td align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "工作補助費" & "</font>"
        v_head &= "</td>"
        v_head &= "<td align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "協查研究費" & "</font>"
        v_head &= "</td>"
        v_head &= "<td align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "工餉" & "</font>"
        v_head &= "</td>"
        v_head &= "<td align=center width='7.2%'>"
        v_head &= "<font face='標楷體' size='3'>" & "工作補助費" & "</font>"
        v_head &= "</tr>"
        Me.Literal1.Text += v_Report_Title & v_head
    End Sub

    Protected Sub PageSeprator()
        Me.Literal1.Text += "<p style='page-break-before:always'>"
    End Sub

    Function ToExcel() As Boolean
        Response.Clear()
        Response.ClearHeaders()
        Response.ContentType = "application\vnd.ms-excel"
        Response.AddHeader("Content-disposition", "attachment;filename=Export.xls")
        Response.Charset = ""
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        Literal1.Visible = True
        Literal1.RenderControl(hw)
        Response.Write(sw.ToString())
        Response.End()
    End Function

End Class
