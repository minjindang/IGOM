Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class CntLeave


        '勞基法人員 計算 初任公職日 到 目前系統日期 的 年月
        Private Shared Function GetCntYearMonth(ByVal dateb As Date) As LeaveYearMonth

            Dim cntYear As Integer = 0
            Dim cntMonth As Integer = 0

            cntYear = DateDiff(DateInterval.Month, dateb, Now) \ 12         '計算年
            cntMonth = (DateDiff(DateInterval.Month, dateb, Now) Mod 12)    '計算月

            If dateb.Month = Now.Month And dateb.Day > Now.Day Then
                cntYear = cntYear - 1
                cntMonth = 11
            End If

            Dim lym As New LeaveYearMonth()
            lym.Year = cntYear
            lym.Month = cntMonth

            Return lym
        End Function

        '公務人 計算 初任公職日 到 去年年底 的 年月
        Private Shared Function GetCntYearMonth(ByVal dateb As Date, ByVal lastyear As Date) As LeaveYearMonth

            Dim cntYear As Integer = 0
            Dim cntMonth As Integer = 0

            cntYear = DateDiff(DateInterval.Year, dateb, lastyear)
            cntMonth = ((DateDiff(DateInterval.Month, dateb, lastyear) + 1) Mod 12)

            'If (((12 - dateb.Month) + 1) Mod 12) = 0 Then
            If ((DateDiff(DateInterval.Month, dateb, lastyear) + 1) Mod 12) = 0 Then
                cntYear += 1
                cntMonth = 0
            End If

            Dim lym As New LeaveYearMonth()
            lym.Year = cntYear
            lym.Month = cntMonth

            Return lym
        End Function

        ''' <summary>
        ''' 休假年資(年/月)
        ''' </summary>
        ''' <param name="orgCode"></param>
        ''' <param name="idcard"></param>
        ''' <param name="joindate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CntYearMonth(ByVal orgCode As String, ByVal idcard As String, ByVal joindate As String) As LeaveYearMonth

            If String.IsNullOrEmpty(joindate) Then
                Return Nothing
            End If

            Dim psn As New FSC.Logic.Personnel()
            Dim dateb As Date = DateTimeInfo.GetPublicDate(joindate)
            Dim PEMEMCOD As String = psn.GetColumnValue("employee_type", idcard)
            Dim remark1 As String = New FSCPLM.Logic.SACode().GetRow("023", "022", PEMEMCOD)("Code_remark1").ToString()

            Dim cntYear As Integer = 0
            Dim cntMonth As Integer = 0

            If "L" = remark1 Then
                '勞工

                '1. 先算年資
                If Now > dateb Then

                    Dim ld As LeaveYearMonth = GetCntYearMonth(dateb)

                    If ld IsNot Nothing Then
                        cntYear = ld.Year       '年資 , 年
                        cntMonth = ld.Month     '年資 , 月
                    End If

                End If

            ElseIf "C" = remark1 Then
                '若為公務員

                Dim lastyear As Date = New Date(Now.AddYears(-1).Year, 12, 31)  '去年12月31日
                '1. 先算年資
                If lastyear > dateb Then

                    Dim ld As LeaveYearMonth = GetCntYearMonth(dateb, lastyear)

                    If ld IsNot Nothing Then
                        cntYear = ld.Year       '年資 , 年
                        cntMonth = ld.Month     '年資 , 月
                    End If

                End If

            End If

            If 0 > cntYear Then
                cntYear = 0
            End If


            Dim ldata As New LeaveYearMonth()
            ldata.Year = cntYear
            ldata.Month = cntMonth

            Return ldata

        End Function

        ''' <summary>
        ''' 異動年資的年月日
        ''' </summary>
        ''' <param name="Year_sdate"></param>
        ''' <param name="Year_edate"></param>
        ''' <param name="Year_flag"></param>
        ''' <param name="reason"></param>
        ''' <param name="Year_days"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CntChgYearMonth(ByVal Year_sdate As String, _
                                        ByVal Year_edate As String, _
                                        ByVal Year_flag As String, _
                                        ByVal reason As String, _
                                        ByVal Year_days As Integer, _
                                        ByVal Years As Integer, _
                                        ByVal Months As Integer) As ChgLeaveYearMonthDay

            Dim y As Integer = 0
            Dim m As Integer = 0
            Dim d As Integer = 0

            If Year_sdate = "" And Year_edate = "" And Year_days = 0 Then

                y = Years
                m = Months

            Else

                Dim sdate As Date = DateTimeInfo.GetPublicDate(Year_sdate)
                Dim edate As Date = DateTimeInfo.GetPublicDate(Year_edate)

                If Year_flag = "1" And reason = "02" Then '加年資, 兵役

                    'Dim cntDay As Integer = DateDiff(DateInterval.Day, sdate, edate)

                    'Dim dMonth As Double = cntDay / 30
                    'Dim iday As Integer = cntDay Mod 30

                    'y = dMonth \ 12
                    'm = dMonth Mod 12

                    'If iday > 0 Then
                    '    m += 1
                    'End If

                    Dim sY As Integer = sdate.Year
                    Dim sM As Integer = sdate.Month
                    Dim sD As Integer = sdate.Day

                    Dim eY As Integer = edate.Year
                    Dim eM As Integer = edate.Month
                    Dim eD As Integer = edate.Day

                    If sD > eD Then
                        d = (Date.DaysInMonth(eY, eM)) + eD - sD
                        eM -= 1
                    Else
                        d = eD - sD
                    End If

                    If sM > eM Then
                        m = (12 + eM) - sM
                        eY -= 1
                    Else
                        m = eM - sM
                    End If

                    y = eY - sY

                ElseIf Year_flag = "1" And reason = "03" Then   '加年資, 兵役折抵

                    m = Year_days \ 30

                    If (Year_days Mod 30) > 0 Then
                        m += 1
                    End If

                    d = Year_days

                Else

                    Dim cntYear As Integer = (DateDiff(DateInterval.Month, sdate, edate) \ 12) '計算年
                    Dim cntMonth As Integer = ((DateDiff(DateInterval.Month, sdate, edate) + 1) Mod 12) '計算月

                    If ((DateDiff(DateInterval.Month, sdate, edate) + 1) Mod 12) = 0 Then
                        cntYear = cntYear + 1
                        cntMonth = 0
                    End If

                    If Year_flag = "1" Then
                        y = cntYear
                        m = cntMonth

                    ElseIf Year_flag = "2" And reason = "01" Then  '減年資, 離職停薪

                        If sdate.Day <> 1 Then
                            cntMonth -= 1
                        End If
                        If Date.DaysInMonth(edate.Year, edate.Month) <> edate.Day Then
                            cntMonth -= 1
                        End If

                        y = cntYear
                        m = cntMonth

                    End If

                End If

                If m >= 12 Then
                    y += m \ 12
                    m = m Mod 12
                End If

            End If

            Dim l As New ChgLeaveYearMonthDay()
            l.Year = y
            l.Month = m
            l.Day = d

            Return l
        End Function

        ''' <summary>
        ''' 異動年資
        ''' </summary>
        ''' <param name="orgCode"></param>
        ''' <param name="IDCard"></param>
        ''' <param name="joindate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetChgYear(ByVal orgCode As String, ByVal IDCard As String, ByVal joindate As String) As ChgLeaveYearMonth
            Dim bll As New LeaveYear()
            Dim LeaveYearDt As DataTable = bll.GetData(orgCode, IDCard)
            Dim cl As New ChgLeaveYearMonth()

            If Not LeaveYearDt Is Nothing Then
                Dim y As Integer = 0
                Dim m As Integer = 0
                Dim d As Integer = 0

                Dim y2 As Integer = 0
                Dim m2 As Integer = 0

                Dim bef_Year_edate As String = ""

                For Each subDr As DataRow In LeaveYearDt.Rows
                    Dim Year_sdate As String = subDr("Year_sdate").ToString()
                    Dim Year_edate As String = subDr("Year_edate").ToString()
                    Dim Year_Flag As String = subDr("Year_flag").ToString()
                    Dim reason As String = subDr("Reason").ToString()
                    Dim Year_days As Integer = CommonFun.getInt(subDr("Year_days").ToString())

                    Dim Years As String = subDr("Years").ToString()
                    Dim Months As String = subDr("Months").ToString()

                    'If lbCntYearS.Text > Year_sdate Then
                    '    lbCntYearS.Text = DateTimeInfo.ToDisplay(Year_sdate)
                    'End If

                    If DateTimeInfo.GetPublicDate(joindate) > DateTimeInfo.GetPublicDate(Year_sdate) Then
                        cl.StartDate = DateTimeInfo.ToDisplay(Year_sdate)
                    End If

                    Dim l As ChgLeaveYearMonthDay = CntChgYearMonth(Year_sdate, Year_edate, Year_Flag, reason, Year_days, CommonFun.getInt(Years), CommonFun.getInt(Months))

                    If l IsNot Nothing Then

                        If Year_Flag = "2" And reason = "01" Then
                            '減年資
                            y2 += l.Year
                            m2 += l.Month

                        ElseIf Year_Flag = "1" Then
                            '加年資

                            y += l.Year

                            If reason <> "03" Then
                                m += l.Month
                            End If

                            d += l.Day

                        End If

                    End If

                    '判斷是否重疊月份
                    If Not String.IsNullOrEmpty(bef_Year_edate) Then
                        Dim d1 As Date = DateTimeInfo.GetPublicDate(bef_Year_edate)
                        Dim d2 As Date = DateTimeInfo.GetPublicDate(Year_sdate)

                        If d1.Year = d2.Year And d1.Month = d2.Month Then
                            m = m - 1
                        End If
                    End If

                    bef_Year_edate = Year_edate
                Next

                m += d \ 30
                If (d Mod 30) > 0 Then
                    m += 1
                End If

                If m >= 12 Then
                    y += m \ 12
                    m = m Mod 12
                End If

                If m2 >= 12 Then
                    y2 += m2 \ 12
                    m2 = m2 Mod 12
                End If

                cl.Year = y
                cl.Month = m
                cl.SubYear = y2
                cl.SubMonth = m2

                Return cl
            End If

            Return Nothing
        End Function


        Public Shared Function GetScalePEHDAY(ByVal leave_days As Integer, ByVal month As Integer) As String

            Dim d As Double = Math.Round(leave_days * (month / 12) * 10) / 10
            Dim dtmp As String = d.ToString()

            If dtmp.IndexOf(".") > 0 Then
                Dim a As String = dtmp.Substring(dtmp.IndexOf(".") + 1, 1)

                If CommonFun.getInt(a) = 5 Or CommonFun.getInt(a) < 5 Then
                    Return CommonFun.getInt(dtmp.Substring(0, dtmp.IndexOf("."))) + 0.4
                ElseIf CommonFun.getInt(a) > 5 Then
                    Return CommonFun.getInt(dtmp.Substring(0, dtmp.IndexOf("."))) + 1
                End If
            End If

            Return dtmp
        End Function

        ''' <summary>
        ''' 計算休假年資 天數
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="Id_card"></param>
        ''' <param name="Join_sdate"></param>
        ''' <param name="Elected_officials_flag"></param>
        ''' <param name="PEKIND"></param>
        ''' <param name="PEMEMCOD"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetCntYearsDays(ByVal Orgcode As String, _
                                     ByVal Id_card As String, _
                                     ByVal Join_sdate As String, _
                                     ByVal Elected_officials_flag As String, _
                                     ByVal PEKIND As String, _
                                     ByVal PEMEMCOD As String) As LeaveYearDay

            Return GetCntYearsDays(Orgcode, Id_card, Join_sdate, Elected_officials_flag, PEKIND, PEMEMCOD, Now)
        End Function



        Public Shared Function GetCntYearsDays(ByVal Orgcode As String, _
                                 ByVal Id_card As String, _
                                 ByVal Join_sdate As String, _
                                 ByVal Elected_officials_flag As String, _
                                 ByVal PEKIND As String, _
                                 ByVal PEMEMCOD As String, _
                                 ByVal baseDate As Date) As LeaveYearDay

            Dim PEHYEAR As String = ""
            Dim PEHDAY As String = ""

            Dim cntYear As Integer = 0
            Dim cntMonth As Integer = 0

            If String.IsNullOrEmpty(Join_sdate) Then
                Return Nothing
            End If

            '初任公職日
            Dim dateb As DateTime = DateTimeInfo.GetPublicDate(Join_sdate)
            Dim pd04m As New CPAPD04M()
            Dim pd04mdt As DataTable = pd04m.GetDataByQuery(PEKIND, PEMEMCOD, "03")
            Dim remark1 As String = New FSCPLM.Logic.SACode().GetRow("023", "022", PEMEMCOD)("Code_remark1").ToString()

            Dim ly As New LeaveYear()
            Dim lydt As DataTable = ly.GetData(Orgcode, Id_card)

            Dim isReturnJob As Boolean = False  '是否復職未滿一年
            Dim retJobMonth As Integer = 0      '復職後在職月數

            Dim chg_y As Integer = 0
            Dim chg_m As Integer = 0
            Dim chgym As ChgLeaveYearMonth = GetChgYear(Orgcode, Id_card, Join_sdate)

            If chgym IsNot Nothing Then
                chg_y = chgym.Year
                chg_m = chgym.Month
            End If

            If "L" = remark1 Then
                '勞基法

                '1. 先算年資
                If baseDate > dateb Then

                    Dim l As LeaveYearMonth = GetCntYearMonth(dateb)

                    If l IsNot Nothing Then
                        cntYear = l.Year       '年資 - 年
                        cntMonth = l.Month     '年資 - 月
                    End If

                End If

                'hsien 20120628
                cntYear += (cntMonth + chg_m) \ 12
                cntYear += chg_y

                '2. 再算休假天數
                For Each pd04mdr As DataRow In pd04mdt.Rows
                    Dim PDYEARB As String = pd04mdr("PDYEARB").ToString().Trim()
                    Dim PDYEARE As String = pd04mdr("PDYEARE").ToString().Trim()

                    If CommonFun.getInt(PDYEARB) <= CommonFun.getInt(cntYear) _
                        And CommonFun.getInt(PDYEARE) >= CommonFun.getInt(cntYear) Then
                        PEHDAY = pd04mdr("PDDAYS").ToString()
                        Exit For
                    End If
                Next
                If CommonFun.getInt(cntYear) >= 10 Then
                    Dim PEHDAY_TMP As String = (15 + CommonFun.getInt(cntYear) - 10).ToString()
                    If CommonFun.getInt(PEHDAY_TMP) > 30 Then
                        PEHDAY = "30"
                    Else
                        PEHDAY = PEHDAY_TMP
                    End If
                End If

            Else
                '若為正式人員、約聘雇人員、技工、工友、駕駛

                Dim lastyear As DateTime = New Date(baseDate.AddYears(-1).Year, 12, 31)  '去年12月31日

                '1. 先算年資
                If lastyear > dateb Then

                    Dim l As LeaveYearMonth = GetCntYearMonth(dateb, lastyear)

                    If l IsNot Nothing Then
                        cntYear = l.Year        '年資, 年
                        cntMonth = l.Month      '年資, 月
                    End If

                    'hsien 20120628 找出復職是否未滿一年
                    If lydt IsNot Nothing Then
                        For Each dr2 As DataRow In lydt.Rows
                            Dim Year_flag As String = Convert.ToString(dr2("Year_flag"))
                            Dim reason As String = dr2("Reason").ToString()

                            If Year_flag = "2" And reason = "01" Then '減年資
                                Dim sdate As DateTime = DateTimeInfo.GetPublicDate(dr2("Year_sdate"))
                                Dim edate As DateTime = DateTimeInfo.GetPublicDate(dr2("Year_edate"))

                                If lastyear.Year = edate.Year Then
                                    isReturnJob = True

                                    'If sdate.Year = edate.Year Then
                                    '    Dim m As Integer = (DateDiff(DateInterval.Month, sdate, edate) + 1) Mod 12 '計算月

                                    '    If sdate.Day <> 1 Then
                                    '        m -= 1
                                    '    End If
                                    '    If DateTime.DaysInMonth(edate.Year, edate.Month) <> edate.Day Then
                                    '        m -= 1
                                    '    End If

                                    '    retJobMonth = 12 - m
                                    'Else
                                    retJobMonth = (DateDiff(DateInterval.Month, edate, lastyear) + 1) Mod 12 '計算月
                                    If DateTime.DaysInMonth(edate.Year, edate.Month) = edate.Day Then
                                        retJobMonth -= 1
                                    End If
                                    'End If

                                End If
                            End If
                        Next
                    End If

                    Dim tmpYear As Integer = cntYear    '初任公職日至去年12/31年資 - 年
                    Dim tmpMonth As Integer = cntMonth  '初任公職日至去年12/31年資 - 月

                    'hsien 20120628
                    cntYear += (cntMonth + chg_m) \ 12
                    cntYear += chg_y

                    If dateb.Year = lastyear.Year And cntYear < 1 Then

                        '政務人員
                        If Elected_officials_flag = "2" Then
                            PEHDAY = 7
                        Else
                            '2. 再算未滿一年的休假天數
                            Dim m As Integer = (DateDiff(DateInterval.Month, dateb, lastyear) + 1) Mod 12 '計算月

                            PEHDAY = GetScalePEHDAY(7, m)

                        End If

                    Else

                        '2. 再算休假天數
                        For Each pd04mdr As DataRow In pd04mdt.Rows
                            Dim PDYEARB As String = pd04mdr("PDYEARB").ToString().Trim()
                            Dim PDYEARE As String = pd04mdr("PDYEARE").ToString().Trim()

                            If CommonFun.getInt(PDYEARB) <= CommonFun.getInt(cntYear) _
                                And CommonFun.getInt(PDYEARE) >= CommonFun.getInt(cntYear) Then
                                PEHDAY = pd04mdr("PDDAYS").ToString()
                                Exit For
                            End If
                        Next

                        '3. 初任公職日至去年12/31年資 - 年 小於1年
                        If tmpYear < 1 Then
                            '3. 再按比列給假
                            PEHDAY = GetScalePEHDAY(PEHDAY, tmpMonth)
                        End If

                    End If

                    'hsien 20120627 復職未滿一年依比例給假
                    If isReturnJob Then
                        PEHDAY = GetScalePEHDAY(PEHDAY, retJobMonth)
                    End If

                End If

            End If

            PEHYEAR = cntYear

            Dim ld As New LeaveYearDay()
            ld.Year = CommonFun.ConvertToInt(PEHYEAR)
            ld.Day = CommonFun.ConvertToInt(PEHDAY)

            Return ld

        End Function
    End Class


    Public Class LeaveYearMonth
        Private _year As Integer
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                _year = value
            End Set
        End Property
        Private _month As Integer
        Public Property Month() As Integer
            Get
                Return _month
            End Get
            Set(ByVal value As Integer)
                _month = value
            End Set
        End Property
    End Class


    Public Class LeaveYearDay
        Private _year As Integer
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                _year = value
            End Set
        End Property
        Private _day As Integer
        Public Property Day() As Integer
            Get
                Return _day
            End Get
            Set(ByVal value As Integer)
                _day = value
            End Set
        End Property
    End Class

    Public Class ChgLeaveYearMonthDay
        Private _year As Integer
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                _year = value
            End Set
        End Property
        Private _month As Integer
        Public Property Month() As Integer
            Get
                Return _month
            End Get
            Set(ByVal value As Integer)
                _month = value
            End Set
        End Property
        Private _day As Integer
        Public Property Day() As Integer
            Get
                Return _day
            End Get
            Set(ByVal value As Integer)
                _day = value
            End Set
        End Property
    End Class


    Public Class ChgLeaveYearMonth
        Private _startDate As String
        Public Property StartDate() As String
            Get
                Return _startDate
            End Get
            Set(ByVal value As String)
                _startDate = value
            End Set
        End Property

        Private _year As Integer
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                _year = value
            End Set
        End Property
        Private _month As Integer
        Public Property Month() As Integer
            Get
                Return _month
            End Get
            Set(ByVal value As Integer)
                _month = value
            End Set
        End Property
        Private _subYear As String
        Public Property SubYear() As String
            Get
                Return _subYear
            End Get
            Set(ByVal value As String)
                _subYear = value
            End Set
        End Property
        Private _subMonth As String
        Public Property SubMonth() As String
            Get
                Return _subMonth
            End Get
            Set(ByVal value As String)
                _subMonth = value
            End Set
        End Property

    End Class
End Namespace