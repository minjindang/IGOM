Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC2131_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLAuthorityDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Name_bind()

        UcDateS.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.Month.ToString.PadLeft(2, "0") & "01"
        UcDateE.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.Month.ToString.PadLeft(2, "0") & Date.DaysInMonth(Now.Year, Now.Month).ToString
    End Sub

    Protected Sub Name_bind()
        UcDDLAuthorityMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLAuthorityMember.Depart_id = UcDDLAuthorityDepart.SelectedValue
    End Sub

    Protected Sub UcDDLAuthorityDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLAuthorityDepart.SelectedIndexChanged
        Name_bind()
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLAuthorityDepart.SelectedValue
        Dim Id_card As String = UcDDLAuthorityMember.SelectedValue
        Dim Start_date As String = UcDateS.Text
        Dim End_date As String = UcDateE.Text
        Dim limit As Double = 8 '連續天數
        Dim bll As New FSC2131

        If String.IsNullOrEmpty(UcDateS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入請假日期(起)!")
            Return
        End If
        If String.IsNullOrEmpty(UcDateE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入請假日期(迄)!")
            Return
        End If
        If UcDateS.Text > UcDateE.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請假日期(起)不可大於請假日期(迄)!")
            Return
        End If

        Try

            Dim dt As DataTable = bll.getData(Orgcode, Depart_id, Id_card, Start_date, End_date)
            If dt.Rows.Count <= 0 Then
                btnExport.Enabled = False
                Ucpager.Visible = False
                tbq.Visible = True
                gvlist.DataSource = dt
                gvlist.DataBind()
                Return
            Else
                btnExport.Enabled = True
                Ucpager.Visible = True
            End If

            Dim dt1 As New DataTable
            dt1 = dt.Clone()
            Dim tidno As String = String.Empty  '暫存idno

            '該區間內請假資料及結合連續請假資料
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim poidno As String = dt.Rows(i)("poidno").ToString
                Dim povdateb As String = dt.Rows(i)("povdateb").ToString
                Dim povtimeb As String = dt.Rows(i)("povtimeb").ToString
                Dim povdatee As String = dt.Rows(i)("povdatee").ToString
                Dim povtimee As String = dt.Rows(i)("povtimee").ToString
                Dim povdays As Double = Double.Parse(dt.Rows(i)("povdays").ToString)
                Dim j As Integer = dt1.Rows.Count

                If i = 0 Then
                    '第一筆
                    dt1.ImportRow(dt.Rows(i))
                    tidno = poidno
                    Continue For
                End If

                If tidno <> poidno Then
                    '不同人
                    dt1.ImportRow(dt.Rows(i))
                    tidno = poidno
                Else
                    '同一人
                    If getDate(dt.Rows(i - 1)("povdatee").ToString) = getDate(povdateb) Then
                        '此筆開始日期跟上筆結束日期同一天
                        If (dt.Rows(i - 1)("povtimee").ToString = "1230" And povtimeb = "1330") Or _
                            povtimeb - dt.Rows(i - 1)("povtimee").ToString <= 1 Then
                            '時間連續
                            dt1.Rows(j - 1)("povdatee") = povdatee
                            dt1.Rows(j - 1)("povtimee") = povtimee
                            dt1.Rows(j - 1)("povdays") = Content.ConvertDayHours(Content.ConvertToHours(povdays) + Content.ConvertToHours(dt1.Rows(j - 1)("povdays")))
                        Else
                            '時間不連續
                            dt1.ImportRow(dt.Rows(i))
                        End If
                    Else
                        '此筆跟上筆不同天

                        Dim iscontinue As Boolean = False

                        If getDate(dt.Rows(i - 1)("povdatee").ToString).AddDays(1) = getDate(povdateb) Then
                            iscontinue = True
                        Else
                            Dim ee As Double = getDate(povdateb).Ticks - getDate(dt.Rows(i - 1)("povdatee").ToString).Ticks

                            Dim ts As TimeSpan = New TimeSpan(ee)

                            If ts.Days > 0 Then

                                Dim yesd As Date = getDate(dt.Rows(i - 1)("povdatee").ToString)

                                For d As Integer = 1 To ts.Days - 1

                                    Dim tard As Date = yesd.AddDays(d)

                                    Dim pb02m As New CPAPB02M()

                                    If pb02m.IsHoliday(DateTimeInfo.GetRocDate(tard)) Then
                                        iscontinue = True
                                        Continue For
                                    Else
                                        iscontinue = False
                                        Exit For
                                    End If
                                Next
                            End If
                        End If

                        If iscontinue Then
                            '此筆跟上筆為連續日

                            If dt.Rows(i - 1)("povtimee").ToString >= "1730" And povtimeb <= "0830" Then
                                '時間連續, 將上筆的結束日期時間取代為這次的結束日期時間
                                dt1.Rows(j - 1)("povdatee") = povdatee
                                dt1.Rows(j - 1)("povtimee") = povtimee
                                dt1.Rows(j - 1)("povdays") = Content.ConvertDayHours(Content.ConvertToHours(povdays) + Content.ConvertToHours(dt1.Rows(j - 1)("povdays")))
                            Else
                                '時間不連續
                                dt1.ImportRow(dt.Rows(i))
                            End If
                        Else
                            '不為連續日
                            dt1.ImportRow(dt.Rows(i))
                        End If
                    End If
                End If
            Next

            '取出總共天數大於查詢的連續天數, 連續的差假期間 在 查詢的年月之中
            Dim dt2 As New DataTable
            dt2 = dt1.Clone()
            For Each dr As DataRow In dt1.Rows
                If Double.Parse(dr("povdays").ToString) >= limit Then
                    dt2.ImportRow(dr)
                End If
            Next

            Dim finaldt As New DataTable
            finaldt.Columns.Add("poidno", GetType(String))
            finaldt.Columns.Add("poname", GetType(String))
            finaldt.Columns.Add("date_detail", GetType(String))
            finaldt.Columns.Add("overdays", GetType(String))
            finaldt.Columns.Add("Totaldays", GetType(String))

            tidno = String.Empty

            Dim tmpdt As New DataTable

            For Each dr As DataRow In dt2.Rows
                Dim poidno As String = dr("poidno").ToString
                Dim poname As String = dr("poname").ToString
                Dim povdateb As String = dr("povdateb").ToString
                Dim povtimeb As String = dr("povtimeb").ToString
                Dim povdatee As String = dr("povdatee").ToString
                Dim povtimee As String = dr("povtimee").ToString
                Dim povdays As Double = Double.Parse(dr("povdays").ToString)
                Dim vdays As Double = 0

                Dim ddt As DataTable = bll.getDetailData(poidno, povdateb & povtimeb, povdatee & povtimee)
                tmpdt.Merge(ddt)

                Dim ndr As DataRow = finaldt.NewRow
                ndr("poidno") = poidno
                ndr("poname") = poname
                ndr("overdays") = Double.Parse(dr("povdays").ToString) - limit
                ndr("Totaldays") = Double.Parse(dr("povdays").ToString)

                For i As Integer = 0 To ddt.Rows.Count - 1
                    Dim ddr As DataRow = ddt.Rows(i)
                    Dim detail1 As String = New SYS.Logic.LeaveType().GetLeaveName(ddr("povtype").ToString)
                    Dim detail2 As String = ddr("povdays").ToString
                    Dim detail3 As String = DateTimeInfo.ToDisplay(ddr("povdateb").ToString, ddr("povtimeb").ToString) & "~" & DateTimeInfo.ToDisplay(ddr("povdatee").ToString, ddr("povtimee").ToString)
                    ndr("date_detail") = ndr("date_detail") & "(" & detail1 & detail2 & "天)" & detail3
                    If i <> ddt.Rows.Count - 1 Then
                        ndr("date_detail") = ndr("date_detail") & "<br />"
                    End If
                Next

                tidno = poidno

                If CommonFun.getDouble(ndr("overdays").ToString) >= 0 Then
                    finaldt.Rows.Add(ndr)
                End If
            Next

            ViewState("dt") = finaldt
            Me.gvlist.DataSource = finaldt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExport.Enabled = True
            Else
                Ucpager.Visible = False
                btnExport.Enabled = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

#Region "報表"
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
            Next

            Dim params(1) As String
            params(0) = DateTimeInfo.ConvertToDisplay(UcDateS.Text)
            params(1) = DateTimeInfo.ConvertToDisplay(UcDateE.Text)

            Dim theDTReport As CommonLib.DTReport

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2131_RPT.mht"), dt)
            theDTReport.ExportFileName = "連續8天請假報表"
            theDTReport.Param = params
            theDTReport.ExportToExcel()
            dt.Dispose()
        End If
    End Sub
#End Region

#Region "其他"
    Protected Function getDaysToMonthEnd(ByVal monthdays As Double, ByVal limit As Double, _
                                     ByVal dateb As String, ByVal datee As String, ByVal timeb As String, ByVal timee As String, ByVal idno As String) As Integer
        Dim vdays As Double = 0

        If timeb > "0830" Then
            limit += 1
        End If

        Dim monthdayb As String = dateb.Substring(0, 5) & "01"  '開始日期
        Dim limitdaye As String '= (Double.Parse(dateb) + limit + 1).ToString.PadLeft(7, "0")

        Dim i As Integer = 0
        Dim add As Integer = 0
        Dim dayb As Integer = Integer.Parse(dateb.Substring(5, 2))

        Dim lastday As String = Date.DaysInMonth(Integer.Parse(dateb.Substring(0, 3)) + 1911, Integer.Parse(dateb.Substring(3, 2)))

        Do
            Dim pb02m As New CPAPB02M()
            limitdaye = dateb.Substring(0, 5) & (dayb + add).ToString().PadLeft(2, "0")

            If (dayb + add) > Integer.Parse(lastday) Then
                limitdaye = limitdaye.Substring(0, 5) & lastday
                Exit Do
            End If

            add += 1
            If pb02m.IsHoliday(limitdaye) Then
                Continue Do
            End If
            i += 1

            If i = limit Then
                Exit Do
            End If
        Loop

        vdays = Content.ConvertDayHours(Content.computeNotWorkHour(monthdayb, limitdaye, "0830", "1730", idno))

        Return monthdays - vdays
    End Function

    Protected Function getDaysBeginToEnd(ByVal limit As Double, ByVal dateb As String, ByVal datee As String, ByVal timeb As String, ByVal timee As String, ByVal idno As String) As Integer
        Dim vdays As Double = 0
        vdays = Content.ConvertDayHours(Content.computeNotWorkHour(dateb, datee, timeb, timee, idno))
        Return vdays - limit
    End Function


    Protected Function getDaysFromMonthBegin(ByVal month As String, ByVal datee As String, ByVal timee As String, ByVal idno As String) As Integer
        Dim monthdayb As String = datee.Substring(0, 3) & month.ToString.PadLeft(2, "0") & "01"
        Return Content.ConvertDayHours(Content.computeNotWorkHour(monthdayb, datee, "0830", timee, idno))
    End Function

    Protected Function getDate(ByVal sdate As String, Optional ByVal stime As String = Nothing) As Date
        Dim y As Integer = 1911 + Integer.Parse(sdate.Substring(0, 3))
        Dim m As Integer = sdate.Substring(3, 2)
        Dim d As Integer = sdate.Substring(5, 2)

        If Not String.IsNullOrEmpty(stime) Then
            Dim hour As Integer = stime.Substring(0, 2)
            Dim min As Integer = stime.Substring(3, 2)
            Dim sec As Integer = 0
            Return New Date(y, m, d, hour, min, sec)
        End If
        Return New Date(y, m, d)
    End Function

    Protected Function GetLastDay(ByVal y As String, ByVal m As String) As String
        Select Case m
            Case "01", "03", "05", "07", "08", "10", "12"
                Return "31"
            Case "04", "06", "09", "11"
                Return "30"
            Case "02"
                If y + 1911 Mod 4 = 0 Then
                    Return "29"
                Else
                    Return "28"
                End If
            Case Else
                Return ""
        End Select
    End Function
#End Region

End Class
