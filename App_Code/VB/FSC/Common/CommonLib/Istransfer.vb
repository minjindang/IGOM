Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System

Namespace FSC.Logic
    Public Class Istransfer
        Inherits BaseDAO

        Public isHaveCard As Boolean = True
        Public Shared beginWorkTime As String = String.Empty
        Public Shared endWorkTime As String = String.Empty
        Public Shared beginNoonRestTime As String = String.Empty
        Public Shared endNoonRestTime As String = String.Empty

        'Public Sub New(conn As SqlConnection)
        '    MyBase.New(conn)
        'End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetLeaveHours(ByVal model As DataRow, _
                                      ByVal currentDate As String) As Integer

            Dim haveLeave As Boolean = False
            Dim totalHours As Integer = 0
            Dim peidno As String = model("id_card").ToString()

            Try
                '判斷請假資料
                Dim sql_cpapo15m As String = "select povtimeb,povtimee,povdays,povtype,povdateb,povdatee from FSC_CPAPO15M where POIDNO=@PEIDNO and POVDATEB<= @POVDATEB and POVDATEE>= @POVDATEE "
                Dim params() As SqlParameter = { _
                New SqlParameter("@PEIDNO", peidno), _
                New SqlParameter("@POVDATEB", currentDate), _
                New SqlParameter("@POVDATEE", currentDate)}
                Dim dt As DataTable = Query(sql_cpapo15m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows

                        haveLeave = True
                        Dim povdays As Double = Double.Parse(row("povdays").ToString())
                        Dim hours As Integer = Content.ConvertToHours(povdays)
                        Dim leaveType As Integer = Integer.Parse(row("povtype").ToString())
                        Dim descr As String = New SYS.Logic.LeaveType().GetLeaveName(leaveType)

                        Try

                            Dim povdateb As String = row("povdateb")
                            Dim povtimeb As String = row("povtimeb")
                            Dim begintime As String = povdateb & povtimeb
                            Dim povdatee As String = row("povdatee")
                            Dim povtimee As String = row("povtimee")
                            Dim endtime As String = povdatee & povtimee
                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        totalHours = totalHours + hours

                    Next
                End If

                Dim sql_cpapp16m As String = "select ppbusdateb,pptimeb,ppbusdatee,pptimee,ppbusdh,ppbustype from FSC_CPAPP16M where PPIDNO=@PEIDNO and PPBUSDATEB<=@POVDATEB and PPBUSDATEE>=@POVDATEE "

                params(0) = New SqlParameter("@PEIDNO", peidno)
                params(1) = New SqlParameter("@POVDATEB", currentDate)
                params(2) = New SqlParameter("@POVDATEE", currentDate)
                dt = Query(sql_cpapp16m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows
                        haveLeave = True
                        Dim ppbusdh As Double = row("ppbusdh")
                        Dim hours As Integer = Content.ConvertToHours(ppbusdh)
                        Dim ppbustype As String = row("ppbustype")
                        ppbustype = IIf(ppbustype.Equals("1"), "公差", "公出")

                        Try

                            Dim ppbusdateb As String = row("ppbusdateb")
                            Dim pptimeb As String = row("pptimeb")
                            Dim begintime As String = ppbusdateb & pptimeb
                            Dim ppbusdatee As String = row("ppbusdatee")
                            Dim pptimee As String = row("pptimee")
                            Dim endtime As String = ppbusdatee & pptimee

                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        totalHours = totalHours + hours

                    Next
                End If

            Catch ex As Exception

            End Try

            Return totalHours
        End Function

        '在沒有刷卡資料時，判斷該日是否有請假或出差資料且是否為最少上班時數
        Public Function HaveNoLeave(ByVal model As DataRow, ByVal currentDate As String, ByVal limitHour As Integer, ByVal reportDetail As ReportDetail) As Boolean

            Dim vhaveNoLeave As Boolean = True
            Dim totalHours As Integer = 0
            Dim peidno As String = model("id_card").ToString()

            Try
                '判斷請假資料
                Dim sql_cpapo15m As String = "select povtimeb,povtimee,povdays,povtype,povdateb,povdatee from FSC_CPAPO15M where POIDNO=@POIDNO and POVDATEB<=@POVDATEB and POVDATEE>=@POVDATEE "


                Dim params() As SqlParameter = {New SqlParameter("@POIDNO", peidno), New SqlParameter("@POVDATEB", currentDate), New SqlParameter("@POVDATEE", currentDate)}
                Dim dt As DataTable = Query(sql_cpapo15m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows

                        Dim povdays As Double = row("povdays")
                        Dim hours As Integer = Content.ConvertToHours(povdays)
                        Dim leaveType As Integer = Integer.Parse(row("povtype"))
                        Dim descr As String = New SYS.Logic.LeaveType().GetLeaveName(leaveType)

                        Try

                            Dim povdateb As String = row("povdateb")
                            Dim povtimeb As String = row("povtimeb")
                            Dim begintime As String = povdateb & povtimeb
                            Dim povdatee As String = row("povdatee")
                            Dim povtimee As String = row("povtimee")
                            Dim endtime As String = povdatee & povtimee
                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = descr & hours.ToString & "小時。<br>"
                        reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If

                Dim sql_cpapp16m As String = "select ppbusdateb,pptimeb,ppbusdatee,pptimee,ppbusdh,ppbustype from FSC_CPAPP16M where PPIDNO=@PPIDNO and PPBUSDATEB<=@PPBUSDATEB and PPBUSDATEE>=@PPBUSDATEE "
                params(0) = New SqlParameter("@PPIDNO", peidno)
                params(1) = New SqlParameter("@PPBUSDATEB", currentDate)
                params(2) = New SqlParameter("@PPBUSDATEE", currentDate)
                dt = Query(sql_cpapp16m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows

                        Dim ppbusdh As Double = row("ppbusdh")
                        Dim hours As Integer = Content.ConvertToHours(ppbusdh)
                        Dim ppbustype As String = row("ppbustype")
                        ppbustype = IIf(ppbustype.Equals("1"), "公差", "公出")

                        Try

                            Dim ppbusdateb As String = row("ppbusdateb")
                            Dim pptimeb As String = row("pptimeb")
                            Dim begintime As String = ppbusdateb & pptimeb
                            Dim ppbusdatee As String = row("ppbusdatee")
                            Dim pptimee As String = row("pptimee")
                            Dim endtime As String = ppbusdatee & pptimee
                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = ppbustype & hours.ToString & "小時。<br>"
                        reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If

                If (totalHours >= limitHour) Then
                    vhaveNoLeave = False
                End If

            Catch ex As Exception
            End Try
            Return vhaveNoLeave

        End Function


        Public Function HaveNoLeaveType124(ByVal model As DataRow, ByVal currentDate As String, ByVal limitHour As Integer, ByVal reportDetail As ReportDetail) As Boolean

            Dim haveNoLeave As Boolean = True
            Dim haveLeave As Boolean = False
            Dim totalHours As Integer = 0
            Dim peidno As String = model("id_card").toString()

            Try
                '判斷請假資料
                Dim sql_cpapo15m As String = " select povtimeb,povtimee,povdays,povtype,povdateb,povdatee from FSC_CPAPO15M " & _
                                             " where POIDNO=@PEIDNO and POVDATEB<= @POVDATEB and POVDATEE>= @POVDATEE "
                Dim params() As SqlParameter = { _
                New SqlParameter("@PEIDNO", peidno), _
                New SqlParameter("@POVDATEB", currentDate), _
                New SqlParameter("@POVDATEE", currentDate)}
                Dim dt As DataTable = Query(sql_cpapo15m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows

                        haveLeave = True
                        Dim povdays As Double = Double.Parse(row("povdays").ToString())
                        Dim hours As Integer = Content.ConvertToHours(povdays)
                        Dim leaveType As Integer = Integer.Parse(row("povtype").ToString())
                        Dim descr As String = New SYS.Logic.LeaveType().GetLeaveName(leaveType)

                        Try

                            Dim povdateb As String = row("povdateb")
                            Dim povtimeb As String = row("povtimeb")
                            Dim begintime As String = povdateb & povtimeb
                            Dim povdatee As String = row("povdatee")
                            Dim povtimee As String = row("povtimee")
                            Dim endtime As String = povdatee & povtimee
                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = descr & hours.ToString() & "小時。<br>"
                        reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If

                Dim sql_cpapp16m As String = "select ppbusdateb,pptimeb,ppbusdatee,pptimee,ppbusdh,ppbustype from FSC_CPAPP16M where PPIDNO=@PEIDNO and PPBUSDATEB<=@POVDATEB and PPBUSDATEE>=@POVDATEE "

                params(0) = New SqlParameter("@PEIDNO", peidno)
                params(1) = New SqlParameter("@POVDATEB", currentDate)
                params(2) = New SqlParameter("@POVDATEE", currentDate)
                dt = Query(sql_cpapp16m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows
                        haveLeave = True
                        Dim ppbusdh As Double = row("ppbusdh")
                        Dim hours As Integer = Content.ConvertToHours(ppbusdh)
                        Dim ppbustype As String = row("ppbustype")
                        ppbustype = IIf(ppbustype.Equals("1"), "公差", "公出")

                        Try

                            Dim ppbusdateb As String = row("ppbusdateb")
                            Dim pptimeb As String = row("pptimeb")
                            Dim begintime As String = ppbusdateb & pptimeb
                            Dim ppbusdatee As String = row("ppbusdatee")
                            Dim pptimee As String = row("pptimee")
                            Dim endtime As String = ppbusdatee & pptimee

                            hours = Content.computeNotWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = ppbustype & hours.ToString() & "小時。<br>"
                        reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If
                If totalHours >= limitHour And haveLeave Then
                    haveNoLeave = False
                End If
            Catch ex As Exception

            End Try
            Return haveNoLeave
        End Function

        Public Function HaveNoonLeave(ByVal model As DataRow, ByVal currentDate As String) As Boolean
            Dim haveNoLeave As Boolean = True
            Dim totalHours As Integer = 0
            Dim peidno As String = model("id_card").toString()

            Dim sql_cpapo15m As String = "select povtimeb, povtimee , povdays , povtype from FSC_CPAPO15M where POIDNO=@PEIDNO and POVDATEB<= @POVDATEB and POVDATEE>=@POVDATEE"


            Dim params() As SqlParameter = {New SqlParameter("@PEIDNO", peidno), New SqlParameter("@POVDATEB", currentDate), New SqlParameter("@POVDATEE", currentDate)}
            Dim dt As DataTable = Query(sql_cpapo15m, params)
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows
                    haveNoLeave = False
                    Exit For
                Next
            End If
            Dim sql_cpapp16m As String = " select ppbusdateb,pptimeb,ppbusdatee,pptimee,ppbusdh,ppbustype from FSC_CPAPP16M where PPIDNO=@PEIDNO and PPBUSDATEB<=@POVDATEB and PPBUSDATEE>=@POVDATEE"
            params(0) = New SqlParameter("@PEIDNO", peidno)
            params(1) = New SqlParameter("@POVDATEB", currentDate)
            params(2) = New SqlParameter("@POVDATEE", currentDate)
            dt = Query(sql_cpapp16m, params)
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows
                    haveNoLeave = False
                    Exit For
                Next
            End If
            Return haveNoLeave
        End Function

        Public Function getUpdateTime(ByVal currentDate As String) As String
            Return FSCPLM.Logic.DateTimeInfo.GetRocDateTime(Now)
        End Function


        Public Function GetLeaveHours(ByVal model As DataRow, _
                                         ByVal currentDate As String, _
                                         ByVal reportDetail As ReportDetail) As Integer

            Dim haveLeave As Boolean = False
            Dim totalHours As Integer = 0
            Dim peidno As String = model("id_card").ToString()

            Try

                '判斷請假資料
                Dim sql_cpapo15m As String = "select povtimeb,povtimee,povdays,povtype,povdateb,povdatee from FSC_CPAPO15M where POIDNO=@PEIDNO and POVDATEB<= @POVDATEB and POVDATEE>= @POVDATEE "
                Dim params() As SqlParameter = { _
                New SqlParameter("@PEIDNO", peidno), _
                New SqlParameter("@POVDATEB", currentDate), _
                New SqlParameter("@POVDATEE", currentDate)}
                Dim dt As DataTable = Query(sql_cpapo15m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows

                        haveLeave = True
                        Dim povdays As Double = Double.Parse(row("povdays").ToString())
                        Dim hours As Integer = Content.ConvertToHours(povdays)
                        Dim leaveType As Integer = Integer.Parse(row("povtype").ToString())
                        Dim descr As String = New SYS.Logic.LeaveType().GetLeaveName(leaveType)

                        Try

                            Dim povdateb As String = row("povdateb")
                            Dim povtimeb As String = row("povtimeb")
                            Dim begintime As String = povdateb & povtimeb
                            Dim povdatee As String = row("povdatee")
                            Dim povtimee As String = row("povtimee")
                            Dim endtime As String = povdatee & povtimee
                            hours = Content.computeWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = descr & hours.ToString() & "小時。<br>"
                        'reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If

                Dim sql_cpapp16m As String = "select ppbusdateb,pptimeb,ppbusdatee,pptimee,ppbusdh,ppbustype from FSC_CPAPP16M where PPIDNO=@PEIDNO and PPBUSDATEB<=@POVDATEB and PPBUSDATEE>=@POVDATEE "

                params(0) = New SqlParameter("@PEIDNO", peidno)
                params(1) = New SqlParameter("@POVDATEB", currentDate)
                params(2) = New SqlParameter("@POVDATEE", currentDate)
                dt = Query(sql_cpapp16m, params)

                If Not dt Is Nothing Then
                    For Each row As DataRow In dt.Rows
                        haveLeave = True
                        Dim ppbusdh As Double = row("ppbusdh")
                        Dim hours As Integer = Content.ConvertToHours(ppbusdh)
                        Dim ppbustype As String = row("ppbustype")
                        ppbustype = IIf(ppbustype.Equals("1"), "公差", "公出")

                        Try

                            Dim ppbusdateb As String = row("ppbusdateb")
                            Dim pptimeb As String = row("pptimeb")
                            Dim begintime As String = ppbusdateb & pptimeb
                            Dim ppbusdatee As String = row("ppbusdatee")
                            Dim pptimee As String = row("pptimee")
                            Dim endtime As String = ppbusdatee & pptimee

                            hours = Content.computeWorkHourForOneDay(begintime, endtime, beginWorkTime, endWorkTime, beginNoonRestTime, endNoonRestTime, currentDate)

                        Catch ex As Exception

                        End Try

                        Dim report As String = ppbustype & hours.ToString() & "小時。<br>"
                        'reportDetail.list.Add(report)
                        totalHours = totalHours + hours

                    Next
                End If

            Catch ex As Exception

            End Try

            Return totalHours
        End Function
    End Class
End Namespace
