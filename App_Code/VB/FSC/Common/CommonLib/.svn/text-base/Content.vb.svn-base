Imports Microsoft.VisualBasic
Imports System.Data
Imports FSCPLM.Logic
Imports System.Collections
Imports System

Namespace FSC.Logic
    Public Class Content

        Public Shared Function computeDays(ByVal id_card As String, ByVal start_date As String, ByVal end_date As String) As Integer
            If start_date > end_date Then
                Return 0
            End If
            'Dim OffDay_dt As DataTable = New CPAPB02M().GetOffDateByPBDDATE(start_date, end_date)
            Dim dateb As Date = DateTimeInfo.GetPublicDate(start_date)
            Dim datee As Date = DateTimeInfo.GetPublicDate(end_date)

            Dim days As Integer = 0
            Do
                Dim taiwanDate As String = DateTimeInfo.GetRocDate(dateb)

                Dim ht As Hashtable = getWorkTime(id_card, taiwanDate)

                If Not "True".Equals(ht("OFFDAY").ToString()) Then
                    dateb = dateb.AddDays(1)
                    If dateb.ToString("yyyyMMdd") >= datee.ToString("yyyyMMdd") Then Exit Do
                    Continue Do
                End If
                days += 1
                Dim strdateb As String = dateb.ToString("yyyyMMdd")
                Dim strdatee As String = datee.ToString("yyyyMMdd")
                If strdateb >= strdatee Then Exit Do
                dateb = dateb.AddDays(1)
            Loop
            Return days
        End Function

        Public Shared Function checkIsHoliday(ByVal start_date As String, ByVal end_date As String) As Boolean
            If start_date > end_date Then
                Return 0
            End If

            Dim OffDay_dt As DataTable = New CPAPB02M().GetOffDateByPBDDATE(start_date, end_date)
            Dim dateb As Date = DateTimeInfo.GetPublicDate(start_date)
            Dim datee As Date = DateTimeInfo.GetPublicDate(end_date)

            If OffDay_dt.Rows.Count <= 0 Then
                Return False
            End If

            Do
                Dim taiwanDate As String = (dateb.Year - 1911).ToString.PadLeft(3, "0") & dateb.ToString("MMdd")

                Dim drs As DataRow() = OffDay_dt.Select("PBDDATE=" & taiwanDate)

                If drs.Length <= 0 Then
                    Return False
                End If

                If dateb.Equals(datee) Then Exit Do
                dateb = dateb.AddDays(1)
            Loop
            Return True
        End Function

        Public Shared Function computeDaysIncludeHoliday(ByVal start_date As String, ByVal end_date As String) As Integer
            If start_date > end_date Then
                Return 0
            End If
            Dim dateb As Date = DateTimeInfo.GetPublicDate(start_date)
            Dim datee As Date = DateTimeInfo.GetPublicDate(end_date)
            Dim days As Integer = 0
            Do
                Dim taiwanDate As String = (dateb.Year - 1911).ToString.PadLeft(3, "0") & dateb.ToString("MMdd")
                days += 1
                If dateb.Equals(datee) Then Exit Do
                dateb = dateb.AddDays(1)
            Loop
            Return days
        End Function

        Public Shared Function formatCurrentDateMinute() As String
            Return System.DateTime.Now.ToLongTimeString()
        End Function

        Public Shared Function toTaiwanDateMinute() As String
            Return (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMddHHmmss")
        End Function

        Public Shared Function ConvertDayHours(ByVal hours As Integer) As Double
            Return Convert.ToDouble(hours \ 8) + Convert.ToDouble(hours Mod 8) / 10L
        End Function

        Public Shared Function ConvertToHours(ByVal dayhours As Double) As Integer
            Return Fix(dayhours) * 8 + FormatNumber(dayhours - Fix(dayhours), 1) * 10
        End Function

        Public Shared Function computeHourForOvertime(ByVal Start_time As String, ByVal End_time As String, ByVal Id_card As String) As Integer
            If Start_time > End_time Then
                Return 0
            End If
            Dim timeb As DateTime
            Dim timee As DateTime

            timeb = DateTimeInfo.GetPublicDate(Start_time)

            'hsien 20120809
            If Right(End_time, 4) = "2400" Then
                timee = DateTimeInfo.GetPublicDate(End_time.Substring(0, 7) & "2359")
            Else
                timee = DateTimeInfo.GetPublicDate(End_time)
            End If

            Dim offday As Boolean = False
            Dim PRADDD As String = Start_time.Substring(0, 7)
            Dim PRSTIME As String = Start_time.Substring(7)
            Dim PRETIME As String = End_time.Substring(7)

            Dim ht As Hashtable = getWorkTime(Id_card, PRADDD)
            Dim worktimeb As String = "0000"
            Dim worktimee As String = "0000"
            Dim noontimeb As String = "0000"
            Dim noontimee As String = "0000"

            If ht IsNot Nothing AndAlso ht.Count > 0 Then
                worktimeb = ht("WORKTIMEB").ToString()
                worktimee = ht("WORKTIMEE").ToString()
                noontimeb = ht("NOONTIMEB").ToString()
                noontimee = ht("NOONTIMEE").ToString()
                offday = CType(ht("OFFDAY").ToString(), Boolean)
            Else
                Throw New FlowException("無班表資料!")
            End If

            Dim hours As Integer = 0
            Try
                If offday Then

                    If timee.ToString("HHmm") = "2359" Then
                        hours = Math.Floor((((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L) + 1) / 60L)
                    Else
                        hours = Math.Floor((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L / 60L)
                    End If

                ElseIf PRSTIME <= worktimeb And PRETIME >= worktimee Then
                    Dim mins As Integer = 0

                    Dim timeedate As DateTime = DateTimeInfo.GetPublicDate(PRADDD & worktimeb)
                    mins = mins + (Math.Floor((timeedate.Ticks - timeb.Ticks) / 10000L / 1000L / 60L))

                    If noontimeb <> noontimee Then
                        Dim noontimebdate As DateTime = DateTimeInfo.GetPublicDate(PRADDD & noontimeb)
                        Dim noontimeedate As DateTime = DateTimeInfo.GetPublicDate(PRADDD & noontimee)
                        mins = mins + (Math.Floor((noontimeedate.Ticks - noontimebdate.Ticks) / 10000L / 1000L / 60L))
                    End If

                    Dim timebdate As DateTime = DateTimeInfo.GetPublicDate(PRADDD & worktimee)
                    mins = mins + (Math.Floor((timee.Ticks - timebdate.Ticks) / 10000L / 1000L / 60L))

                    hours = Math.Floor(mins / 60L)
                Else
                    If timee.ToString("HHmm") = "2359" Then
                        hours = Math.Floor((((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L) + 1) / 60L)
                    Else
                        hours = Math.Floor((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L / 60L)
                    End If
                End If

            Catch ex As Exception

            End Try

            Return hours
        End Function


        Public Shared Function computeHourForBusiness(ByVal Start_date As String, ByVal End_date As String, ByVal Start_time As String, ByVal End_time As String, ByVal Id_card As String) As Integer
            If Start_time > End_time Then
                Return 0
            End If

            Dim offday As Boolean = False
            Dim PPBUSDATEB As String = Start_date

            Dim ht As Hashtable = getWorkTime(Id_card, PPBUSDATEB)
            Dim worktimeb As String = "0000"
            Dim worktimee As String = "0000"
            Dim noontimeb As String = "0000"
            Dim noontimee As String = "0000"

            If ht IsNot Nothing AndAlso ht.Count > 0 Then
                worktimeb = ht("WORKTIMEB").ToString()
                worktimee = ht("WORKTIMEE").ToString()
                noontimeb = ht("NOONTIMEB").ToString()
                noontimee = ht("NOONTIMEE").ToString()
                offday = CType(ht("OFFDAY").ToString(), Boolean)
                Start_time = IIf(Start_time <= worktimee, worktimee, Start_time)
            Else
                Throw New FlowException("無班表資料!")
            End If

            Dim timeb As DateTime = DateTimeInfo.GetPublicDate(Start_date & Start_time)
            Dim timee As DateTime = DateTimeInfo.GetPublicDate(End_date & End_time)

            Dim PPTIMEB As String = Start_time
            Dim PPTIMEE As String = End_time

            Dim minutes As Integer = 0
            Try
                If Right(End_time, 4) = "2359" Then
                    minutes = Math.Floor((((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L) + 1))
                Else
                    minutes = Math.Floor((timee.Ticks - timeb.Ticks) / 10000L / 1000L / 60L)
                End If

            Catch ex As Exception

            End Try
            Return minutes \ 60
        End Function

        Public Shared Function computeWorkHourIncludeHolidy(ByVal Start_date As String, _
                                                            ByVal End_date As String, _
                                                            ByVal Start_time As String, _
                                                            ByVal End_time As String, _
                                                            ByVal Id_card As String) As Integer
            If Start_date > End_date Then
                Return 0
            End If

            Dim hours As Integer = 0
            Dim minutes As Integer = 0
            Dim minutesAday As Integer = 0
            Dim offday As Boolean = False

            Try
                Dim vBegin As DateTime = DateTimeInfo.GetPublicDate(Start_date & Start_time)
                Dim vEnd As DateTime = DateTimeInfo.GetPublicDate(End_date & End_time)

                Dim cr1 As New CalendarRegion()
                Dim cr2 As New CalendarRegion()
                Dim cr3 As New CalendarRegion()

                cr1.vBegin = vBegin
                cr1.vEnd = vEnd

                Do
                    Try
                        If cr2.vBegin = Nothing Then
                            cr2.vBegin = vBegin
                        End If
                        If cr3.vBegin = Nothing Then
                            cr3.vBegin = vBegin
                        End If

                        Dim ht As Hashtable = getWorkTime(Id_card, DateTimeInfo.GetRocDate(cr2.vBegin))

                        Dim worktimeb As String = "0000"
                        Dim worktimee As String = "0000"
                        Dim noontimeb As String = "0000"
                        Dim noontimee As String = "0000"

                        If ht IsNot Nothing AndAlso ht.Count > 0 Then
                            worktimeb = ht("WORKTIMEB").ToString()
                            worktimee = ht("WORKTIMEE").ToString()
                            noontimeb = ht("NOONTIMEB").ToString()
                            noontimee = ht("NOONTIMEE").ToString()
                            offday = CType(ht("OFFDAY").ToString(), Boolean)
                        Else
                            Throw New FlowException("無班表資料!")
                        End If

                        Dim beginWorkerTimeHour As Integer = Integer.Parse(worktimeb.Substring(0, 2))
                        Dim beginWorkerTimeMinute = Integer.Parse(worktimeb.Substring(2))
                        Dim endWorkerTimeHour = Integer.Parse(worktimee.Substring(0, 2))
                        Dim endWorkerTimeMinute = Integer.Parse(worktimee.Substring(2))

                        Dim beginNoonRestTimeHour = Integer.Parse(noontimeb.Substring(0, 2))
                        Dim beginNoonRestTimeMinute = Integer.Parse(noontimeb.Substring(2))
                        Dim endNoonRestTimeHour = Integer.Parse(noontimee.Substring(0, 2))
                        Dim endNoonRestTimeMinute = Integer.Parse(noontimee.Substring(2))

                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second)

                    Catch ex As Exception

                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 8, 0, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 13, 30, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second)

                    End Try

                    Dim taiwanDate As String = (Integer.Parse(cr2.vBegin.ToString("yyyy")) - 1911).ToString.PadLeft(3, "0") & cr2.vBegin.ToString("MMdd")

                    minutesAday = getIntersectionMinutes(cr1, cr2) + getIntersectionMinutes(cr1, cr3)

                    If minutesAday > 480 Then minutesAday = 480
                    minutes += minutesAday

                    If cr2.vBegin.Date.Equals(vEnd.Date) Then Exit Do

                    cr2.vBegin = cr2.vBegin.AddDays(1)
                    cr2.vEnd = cr2.vEnd.AddDays(1)
                    cr3.vBegin = cr3.vBegin.AddDays(1)
                    cr3.vEnd = cr3.vEnd.AddDays(1)

                Loop

            Catch fex As Exception
                Throw New FlowException(fex.Message())
            End Try

            hours = (minutes + 59) \ 60
            Return hours
        End Function

        Public Shared Function computeHolidayWorkHour(ByVal Start_date As String, _
                                                      ByVal End_date As String, _
                                                      ByVal Start_time As String, _
                                                      ByVal End_time As String, _
                                                      ByVal Id_card As String) As Integer
            If Start_date > End_date Then
                Return 0
            End If

            Dim hours As Integer = 0
            Dim minutes As Integer = 0
            Dim minutesAday As Integer = 0
            Dim offday As Boolean = False

            Try
                Dim vBegin As DateTime = DateTimeInfo.GetPublicDate(Start_date & Start_time)
                Dim vEnd As DateTime = DateTimeInfo.GetPublicDate(End_date & End_time)

                Dim cr1 As New CalendarRegion()
                Dim cr2 As New CalendarRegion()
                Dim cr3 As New CalendarRegion()

                cr1.vBegin = vBegin
                cr1.vEnd = vEnd

                Do
                    Try
                        If cr2.vBegin = Nothing Then
                            cr2.vBegin = vBegin
                        End If
                        If cr3.vBegin = Nothing Then
                            cr3.vBegin = vBegin
                        End If

                        Dim ht As Hashtable = getWorkTime(Id_card, DateTimeInfo.GetRocDate(cr2.vBegin))

                        Dim worktimeb As String = ""
                        Dim worktimee As String = ""
                        Dim noontimeb As String = ""
                        Dim noontimee As String = ""

                        If ht IsNot Nothing AndAlso ht.Count > 0 Then
                            worktimeb = ht("WORKTIMEB").ToString()
                            worktimee = ht("WORKTIMEE").ToString()
                            noontimeb = ht("NOONTIMEB").ToString()
                            noontimee = ht("NOONTIMEE").ToString()
                            offday = CType(ht("OFFDAY").ToString(), Boolean)
                        Else
                            Throw New FlowException("無班表資料!")
                        End If

                        Dim beginWorkerTimeHour As Integer = Integer.Parse(worktimeb.Substring(0, 2))
                        Dim beginWorkerTimeMinute = Integer.Parse(worktimeb.Substring(2))
                        Dim endWorkerTimeHour = Integer.Parse(worktimee.Substring(0, 2))
                        Dim endWorkerTimeMinute = Integer.Parse(worktimee.Substring(2))

                        Dim beginNoonRestTimeHour = Integer.Parse(noontimeb.Substring(0, 2))
                        Dim beginNoonRestTimeMinute = Integer.Parse(noontimeb.Substring(2))
                        Dim endNoonRestTimeHour = Integer.Parse(noontimee.Substring(0, 2))
                        Dim endNoonRestTimeMinute = Integer.Parse(noontimee.Substring(2))

                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second)

                    Catch ex As Exception

                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 8, 0, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 13, 30, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second)

                    End Try

                    Dim taiwanDate As String = (Integer.Parse(cr2.vBegin.ToString("yyyy")) - 1911).ToString.PadLeft(3, "0") & cr2.vBegin.ToString("MMdd")

                    If offday Then
                        minutesAday = getIntersectionMinutes(cr1, cr2) + getIntersectionMinutes(cr1, cr3)

                        If minutesAday > 480 Then minutesAday = 480
                        minutes += minutesAday
                    End If

                    If cr2.vBegin.Date.Equals(vEnd.Date) Then Exit Do

                    cr2.vBegin = cr2.vBegin.AddDays(1)
                    cr2.vEnd = cr2.vEnd.AddDays(1)
                    cr3.vBegin = cr3.vBegin.AddDays(1)
                    cr3.vEnd = cr3.vEnd.AddDays(1)

                Loop

            Catch fex As Exception
                Throw New FlowException(fex.Message())
            End Try

            hours = minutes \ 60
            Return hours
        End Function

        Public Shared Function computeNotWorkHour(ByVal Start_date As String, _
                                                  ByVal End_date As String, _
                                                  ByVal Start_time As String, _
                                                  ByVal End_time As String, _
                                                  ByVal Id_card As String) As Integer
            If Start_date > End_date Then
                Return 0
            End If
            'Dim OffDay_dt As DataTable = New CPAPB02M().GetOffDateByPBDDATE(Start_date, End_date)

            Dim hours As Integer = 0
            Dim minutes As Integer = 0
            Dim minutesAday As Integer = 0
            Dim offday As Boolean = False

            Try
                Dim vBegin As DateTime = DateTimeInfo.GetPublicDate(Start_date & Start_time)
                Dim vEnd As DateTime = DateTimeInfo.GetPublicDate(End_date & End_time)

                Dim cr1 As New CalendarRegion()
                Dim cr2 As New CalendarRegion()
                Dim cr3 As New CalendarRegion()

                cr1.vBegin = vBegin
                cr1.vEnd = vEnd

                Do
                    Try
                        If cr2.vBegin = Nothing Then
                            cr2.vBegin = vBegin
                        End If
                        If cr3.vBegin = Nothing Then
                            cr3.vBegin = vBegin
                        End If

                        'Dim PCKIND As String = New CPAPE05M().GetPEKIND(Id_card)
                        'Dim ht As Hashtable = New CPAPC03M().GetWorkNoonDataByPCKIND(PCKIND)
                        Dim ht As Hashtable = getWorkTime(Id_card, DateTimeInfo.GetRocDate(cr2.vBegin))

                        Dim worktimeb As String = ""
                        Dim worktimee As String = ""
                        Dim noontimeb As String = ""
                        Dim noontimee As String = ""

                        If ht IsNot Nothing AndAlso ht.Count > 0 Then
                            worktimeb = ht("WORKTIMEB").ToString()
                            worktimee = ht("WORKTIMEE").ToString()
                            noontimeb = ht("NOONTIMEB").ToString()
                            noontimee = ht("NOONTIMEE").ToString()
                            offday = CType(ht("OFFDAY").ToString(), Boolean)
                        Else
                            Throw New FlowException("無班表資料!")
                        End If

                        Dim beginWorkerTimeHour As Integer = Integer.Parse(worktimeb.Substring(0, 2))
                        Dim beginWorkerTimeMinute = Integer.Parse(worktimeb.Substring(2))
                        Dim endWorkerTimeHour = Integer.Parse(worktimee.Substring(0, 2))
                        Dim endWorkerTimeMinute = Integer.Parse(worktimee.Substring(2))

                        Dim beginNoonRestTimeHour = Integer.Parse(noontimeb.Substring(0, 2))
                        Dim beginNoonRestTimeMinute = Integer.Parse(noontimeb.Substring(2))
                        Dim endNoonRestTimeHour = Integer.Parse(noontimee.Substring(0, 2))
                        Dim endNoonRestTimeMinute = Integer.Parse(noontimee.Substring(2))

                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second)

                    Catch ex As Exception
                        cr2.vBegin = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 8, 0, 0)
                        cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second)

                        cr3.vBegin = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 13, 30, 0)
                        cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second)
                    End Try

                    'Dim taiwanDate As String = (Integer.Parse(cr2.vBegin.ToString("yyyy")) - 1911).ToString.PadLeft(3, "0") & cr2.vBegin.ToString("MMdd")
                    'If OffDay_dt.Rows.Count <= 0 OrElse OffDay_dt.Select("PBDDATE=" & taiwanDate).Length <= 0 Then

                    If Not offday Then
                        minutesAday = getIntersectionMinutes(cr1, cr2) + getIntersectionMinutes(cr1, cr3)

                        If minutesAday > 480 Then minutesAday = 480
                        minutes += minutesAday
                    End If

                    If cr2.vBegin.Date.Equals(vEnd.Date) Then Exit Do

                    cr2.vBegin = cr2.vBegin.AddDays(1)
                    cr2.vEnd = cr2.vEnd.AddDays(1)
                    cr3.vBegin = cr3.vBegin.AddDays(1)
                    cr3.vEnd = cr3.vEnd.AddDays(1)

                Loop

            Catch fex As Exception
                Throw New FlowException(fex.Message())
            End Try

            hours = (minutes + 59) \ 60
            Return hours
        End Function


        Public Shared Function computeNotWorkHourForOneDay(ByVal begintime As String, _
                                                           ByVal endtime As String, _
                                                           ByVal beginWorkTime As String, _
                                                           ByVal endWorkTime As String, _
                                                           ByVal beginNoonRestTime As String, _
                                                           ByVal endNoonRestTime As String, _
                                                           ByVal caculateDate As String) As Integer

            Dim info As New FSCPLM.Logic.DateTimeInfo()

            Dim hours As Integer = 0
            Dim minutes As Integer = 0

            Try

                Dim vBegin As DateTime = DateTimeInfo.GetPublicDate(begintime)
                Dim vEnd As DateTime = DateTimeInfo.GetPublicDate(endtime)

                Dim cr1 As New CalendarRegion()
                Dim cr2 As New CalendarRegion()
                Dim cr3 As New CalendarRegion()

                cr1.vBegin = vBegin
                cr1.vEnd = vEnd

                Try

                    Dim beginWorkerTimeHour As Integer = Integer.Parse(beginWorkTime.Substring(0, 2))
                    Dim beginWorkerTimeMinute = Integer.Parse(beginWorkTime.Substring(2))
                    Dim endWorkerTimeHour = Integer.Parse(endWorkTime.Substring(0, 2))
                    Dim endWorkerTimeMinute = Integer.Parse(endWorkTime.Substring(2))
                    Dim beginNoonRestTimeHour = Integer.Parse(beginNoonRestTime.Substring(0, 2))
                    Dim beginNoonRestTimeMinute = Integer.Parse(beginNoonRestTime.Substring(2))
                    Dim endNoonRestTimeHour = Integer.Parse(endNoonRestTime.Substring(0, 2))
                    Dim endNoonRestTimeMinute = Integer.Parse(endNoonRestTime.Substring(2))

                    cr2.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0)
                    cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second)

                    cr3.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0)
                    cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second)

                Catch ex As Exception

                    cr2.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, 8, 0, 0)
                    cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second)

                    cr3.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, 13, 30, 0)
                    cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second)

                End Try

                Dim isCaculated As Boolean = False

                While (True)

                    If (cr2.vBegin.CompareTo(vEnd) > -1 Or isCaculated) Then
                        Exit While
                    End If

                    Dim taiwanDate As String = (cr2.vBegin.Year - 1911).ToString.PadLeft(3, "0") & cr2.vBegin.ToString("MMdd")

                    If (taiwanDate.Equals(caculateDate)) Then
                        isCaculated = True
                    End If

                    If (isCaculated) Then
                        minutes = minutes + getIntersectionMinutes(cr1, cr2)
                        minutes = minutes + getIntersectionMinutes(cr1, cr3)
                    End If

                    cr2.vBegin = cr2.vBegin.AddDays(1)
                    cr2.vEnd = cr2.vEnd.AddDays(1)
                    cr3.vBegin = cr3.vBegin.AddDays(1)
                    cr3.vEnd = cr3.vEnd.AddDays(1)

                End While

            Catch ex As Exception

            End Try
            hours = (minutes + 59) \ 60
            Return hours

        End Function


        Public Shared Function computeWorkHourForOneDay(ByVal begintime As String, _
                                                        ByVal endtime As String, _
                                                        ByVal beginWorkTime As String, _
                                                        ByVal endWorkTime As String, _
                                                        ByVal beginNoonRestTime As String, _
                                                        ByVal endNoonRestTime As String, _
                                                        ByVal caculateDate As String) As Integer

            Dim info As New FSCPLM.Logic.DateTimeInfo()

            Dim hours As Integer = 0
            Dim minutes As Integer = 0

            Try

                Dim vBegin As DateTime = DateTimeInfo.GetPublicDate(begintime)
                Dim vEnd As DateTime = DateTimeInfo.GetPublicDate(endtime)

                Dim cr1 As New CalendarRegion()
                Dim cr2 As New CalendarRegion()
                Dim cr3 As New CalendarRegion()

                cr1.vBegin = vBegin
                cr1.vEnd = vEnd

                Try

                    Dim beginWorkerTimeHour As Integer = Integer.Parse(beginWorkTime.Substring(0, 2))
                    Dim beginWorkerTimeMinute = Integer.Parse(beginWorkTime.Substring(2))
                    Dim endWorkerTimeHour = Integer.Parse(endWorkTime.Substring(0, 2))
                    Dim endWorkerTimeMinute = Integer.Parse(endWorkTime.Substring(2))
                    Dim beginNoonRestTimeHour = Integer.Parse(beginNoonRestTime.Substring(0, 2))
                    Dim beginNoonRestTimeMinute = Integer.Parse(beginNoonRestTime.Substring(2))
                    Dim endNoonRestTimeHour = Integer.Parse(endNoonRestTime.Substring(0, 2))
                    Dim endNoonRestTimeMinute = Integer.Parse(endNoonRestTime.Substring(2))

                    cr2.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, beginWorkerTimeHour, beginWorkerTimeMinute, 0)
                    cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, beginNoonRestTimeHour, beginNoonRestTimeMinute, cr2.vBegin.Second)

                    cr3.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, endNoonRestTimeHour, endNoonRestTimeMinute, 0)
                    cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, endWorkerTimeHour, endWorkerTimeMinute, cr3.vBegin.Second)

                Catch ex As Exception

                    cr2.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, 8, 30, 0)
                    cr2.vEnd = New DateTime(cr2.vBegin.Year, cr2.vBegin.Month, cr2.vBegin.Day, 12, cr2.vBegin.Minute, cr2.vBegin.Second)

                    cr3.vBegin = New DateTime(vBegin.Year, vBegin.Month, vBegin.Day, 13, 30, 0)
                    cr3.vEnd = New DateTime(cr3.vBegin.Year, cr3.vBegin.Month, cr3.vBegin.Day, 17, cr3.vBegin.Minute, cr3.vBegin.Second)

                End Try

                Dim isCaculated As Boolean = False

                While (True)

                    If (cr2.vBegin.CompareTo(vEnd) > -1 Or isCaculated) Then
                        Exit While
                    End If

                    Dim taiwanDate As String = (cr2.vBegin.Year - 1911).ToString.PadLeft(3, "0") & cr2.vBegin.ToString("MMdd")

                    If (taiwanDate.Equals(caculateDate)) Then
                        isCaculated = True
                    End If

                    If (isCaculated) Then
                        minutes = minutes + getIntersectionMinutes(cr1, cr2)
                        minutes = minutes + getIntersectionMinutes(cr1, cr3)
                    End If

                    cr2.vBegin = cr2.vBegin.AddDays(1)
                    cr2.vEnd = cr2.vEnd.AddDays(1)
                    cr3.vBegin = cr3.vBegin.AddDays(1)
                    cr3.vEnd = cr3.vEnd.AddDays(1)

                End While

            Catch ex As Exception

            End Try
            hours = (minutes + 59) \ 60
            Return hours

        End Function

        Public Shared Function getIntersectionMinutes(ByVal cr1 As CalendarRegion, ByVal cr2 As CalendarRegion) As Integer
            Dim lr1 As New LongRegion()
            Dim lr2 As New LongRegion()

            lr1.vBegin = cr1.vBegin.Ticks / 10000L
            lr1.vEnd = cr1.vEnd.Ticks / 10000L
            lr2.vBegin = cr2.vBegin.Ticks / 10000L
            lr2.vEnd = cr2.vEnd.Ticks / 10000L
            Dim lr As LongRegion = getIntersection(lr1, lr2)

            Return ((lr.vEnd - lr.vBegin) / 1000L / 60L)
        End Function


        Public Shared Function getIntersection(ByVal r1 As LongRegion, ByVal r2 As LongRegion) As LongRegion
            Dim r = New LongRegion()
            r.vBegin = Math.Max(r1.vBegin, r2.vBegin)
            r.vEnd = Math.Min(r1.vEnd, r2.vEnd)
            If r.vbegin > r.vend Then
                r.vBegin = r.vEnd
            End If
            Return r
        End Function

        Public Shared Function getWorkTime(ByVal idCard As String, ByVal currentdate As String) As Hashtable
            Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Return GetWorkTime(idCard, currentdate, orgcode)
        End Function

        Public Shared Function getWorkTime(ByVal idCard As String, ByVal currentdate As String, ByVal orgcode As String) As Hashtable
            Dim PEKIND As String = New FSC.Logic.Personnel().GetColumnValue("PEKIND", idCard)
            Dim pc03m As New CPAPC03M()
            Dim hash As Hashtable = pc03m.GetHashTableData(PEKIND)
            Return GetWorkTime(orgcode, idCard, PEKIND, currentdate, hash)
        End Function

        Public Shared Function GetWorkTime(orgcode As String, idCard As String, pekind As String, currentdate As String, hash As Hashtable) As Hashtable
            Dim WORKTIMEB As String = CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM1")
            Dim WORKTIMEE As String = CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM2")
            Dim NOONTIMEB As String = CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM1")
            Dim NOONTIMEE As String = CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM2")
            Dim NOONCARDTIMEB As String = CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM1")
            Dim NOONCARDTIMEE As String = CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM2")
            Dim OFFDAY As Boolean = New CPAPB02M().IsHoliday(currentdate)

            '2. 查排班資料, 若有則依排班資料為主
            Dim ss As New FSC.Logic.ScheduleSetting()
            Dim dt As DataTable = ss.GetDataByQuery(orgcode, idCard, currentdate)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                If "2".Equals(dt.Rows(0)("Sche_type").ToString()) Then
                    OFFDAY = True
                Else
                    WORKTIMEB = dt.Rows(0)("Start_time").ToString()
                    WORKTIMEE = dt.Rows(0)("End_time").ToString()
                    NOONTIMEB = dt.Rows(0)("Noon_stime").ToString()
                    NOONTIMEE = dt.Rows(0)("Noon_etime").ToString()
                    NOONCARDTIMEB = dt.Rows(0)("Nooncard_stime").ToString()
                    NOONCARDTIMEE = dt.Rows(0)("Nooncard_etime").ToString()

                    If String.IsNullOrEmpty(NOONTIMEB) Or String.IsNullOrEmpty(NOONTIMEE) Then
                        Dim tmp As Integer = CommonFun.getInt(WORKTIMEB) + 400
                        If 2400 - tmp < 400 Then
                            tmp = Math.Abs(tmp - 2400)
                        End If
                        NOONTIMEB = tmp.ToString().PadLeft(4, "0")
                        NOONTIMEE = NOONTIMEB
                    End If
                    OFFDAY = False
                End If
            End If

            If "".Equals(WORKTIMEB) Or "".Equals(WORKTIMEE) Or _
                "".Equals(NOONTIMEB) Or "".Equals(NOONTIMEE) Then
                Return Nothing
            End If

            Dim ht As New Hashtable()
            ht.Add("WORKTIMEB", WORKTIMEB)
            ht.Add("WORKTIMEE", WORKTIMEE)
            ht.Add("NOONTIMEB", NOONTIMEB)
            ht.Add("NOONTIMEE", NOONTIMEE)
            ht.Add("NOONCARDTIMEB", NOONCARDTIMEB)
            ht.Add("NOONCARDTIMEE", NOONCARDTIMEE)
            ht.Add("OFFDAY", OFFDAY)

            Return ht
        End Function

        Public Shared Function getNumberTime(ByVal hhmm As String) As Integer '格式為hhmm
            Dim number As Integer = 0

            Try
                Dim hh As String = hhmm.Substring(0, 2)
                Dim mm As String = hhmm.Substring(2)
                number = Integer.Parse(hh) * 60 + Integer.Parse(mm)
            Catch ex As Exception

            End Try

            Return number
        End Function

    End Class
End Namespace