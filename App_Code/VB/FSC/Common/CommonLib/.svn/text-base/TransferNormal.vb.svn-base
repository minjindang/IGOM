Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports NLog
Imports System.Collections
Imports System
Imports System.Configuration
Imports FSCPLM.Logic


Namespace FSC.Logic
    Public Class TransferNormal
        Inherits BaseDAO

#Region "fields"
        Private v As New DataTable
        Private model As DataRow         'CPAPE05M DataRow
        Private currentDate As String = String.Empty
        Private offday As Boolean


        Private workTimeBegin As String = "" '正常班上班
        Private workTimeBeginNumber As Integer = 0
        Private workTimeEnd As String = "" '正常班下班
        Private workTimeEndNumber As Integer = 0
        Private workTimeHalfBegin As String = "" '正常班上班(半日)
        Private workTimeHalfBeginNumber As Integer = 0
        Private workTimeHalfEnd As String = "" '正常班下班(半日)
        Private workTimeHalfEndNumber As Integer = 0
        Private noonRestBegin As String = "" '中午休息開始
        Private noonRestBeginNumber As Integer = 0
        Private noonRestEnd As String = "" '中午休息結束
        Private noonRestEndNumber As Integer = 0
        '中午休息時間
        Private noonRestHours As Integer = 0
        Private noonCardBegin As String = "" '中午卡刷卡時間開始
        Private noonCardBeginNumber As Integer = 0
        Private noonCardEnd As String = "" '中午卡刷卡時間結束
        Private noonCardEndNumber As Integer = 0
        Private isNoonNeedCard As String = "" '中午需不需要刷卡 1:要 2:不要

        Private workHours As Integer = 0 '全天上班至少上班時數
        Private workHoursHalf As Integer = 0  '半天上班至少上班時數

        Private pullOffTimeBegin As Integer = 0 '上班緩衝時間
        Private pullOffTimeEnd As Integer = 0  '下班緩衝時間

        Private beginWorkCard As String = "A" '上班卡phitype
        Private endWorkCard As String = "D" '下班卡phitype
        Private noonCard As String = "A" '中午卡phitype

        Private totalHour As Integer = 0
        Private PKWKTPE As String = "8"
        Private phitimeBegin As String = ""
        Private phitimeEnd As String = ""

        Private istransfer As Istransfer

#End Region

        'Public Sub New(ByVal conn As SqlConnection)
        '    MyBase.New(conn)
        '    istransfer = New Istransfer(conn)
        'End Sub

        Public Sub New()
            MyBase.New()
            istransfer = New Istransfer()
        End Sub

        Public Sub Init(ByVal hash As Hashtable, ByVal phyymm As DataTable, ByVal vmodel As DataRow, ByVal vcurrentDate As String, ByVal voffday As Boolean, ByVal scheht As Hashtable)

            Me.v = phyymm
            Me.model = vmodel
            Me.currentDate = vcurrentDate
            Me.offday = voffday

            workTimeBegin = CType(CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM1"), String)
            workTimeBeginNumber = getNumberTime(workTimeBegin)
            workTimeEnd = CType(CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM2"), String)
            workTimeEndNumber = getNumberTime(workTimeEnd)
            workTimeHalfBegin = CType(CType(hash.Item("normalWorkTimeHalf"), Hashtable).Item("PCPARM1"), String)
            workTimeHalfBeginNumber = getNumberTime(workTimeHalfBegin)
            workTimeHalfEnd = CType(CType(hash.Item("normalWorkTimeHalf"), Hashtable).Item("PCPARM2"), String)
            workTimeHalfEndNumber = getNumberTime(workTimeHalfEnd)
            noonRestBegin = CType(CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM1"), String)
            noonRestBeginNumber = getNumberTime(noonRestBegin)
            noonRestEnd = CType(CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM2"), String)
            noonRestEndNumber = getNumberTime(noonRestEnd)
            noonRestHours = noonRestEndNumber - noonRestBeginNumber
            noonCardBegin = CType(CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM1"), String)
            noonCardBeginNumber = getNumberTime(noonCardBegin)
            noonCardEnd = CType(CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM2"), String)
            noonCardEndNumber = getNumberTime(noonCardEnd)
            isNoonNeedCard = CType(CType(hash.Item("isNoonNeedCard"), Hashtable).Item("PCPARM1"), String)

            If Not CType(hash.Item("workHours"), Hashtable).Item("PCPARM1") Is Nothing Then
                workHours = CommonFun.getInt(CType(hash.Item("workHours"), Hashtable).Item("PCPARM1"))
            End If

            If Not CType(hash.Item("workHoursHalf"), Hashtable).Item("PCPARM1") Is Nothing Then
                workHoursHalf = CommonFun.getInt(CType(hash.Item("workHoursHalf"), Hashtable).Item("PCPARM1"))
            End If

            If Not CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM1") Is Nothing Then
                pullOffTimeBegin = CommonFun.getInt(CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM1"))
            End If

            If Not CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM2") Is Nothing AndAlso _
               Not IsDBNull(CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM2")) AndAlso _
               Not String.IsNullOrEmpty(CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM2")) Then
                pullOffTimeEnd = CommonFun.getInt(CType(hash.Item("pullOffTime"), Hashtable).Item("PCPARM2"))
            End If

            '查排班資料, 重新給值
            If scheht IsNot Nothing Then
                workTimeBegin = scheht.Item("WORKTIMEB").ToString()
                workTimeBeginNumber = getNumberTime(workTimeBegin)
                workTimeEnd = scheht.Item("WORKTIMEE").ToString()
                workTimeEndNumber = getNumberTime(workTimeEnd)

                'workTimeHalfBegin = ""
                workTimeHalfBeginNumber = getNumberTime(workTimeHalfBegin)
                'workTimeHalfEnd = ""
                workTimeHalfEndNumber = getNumberTime(workTimeHalfEnd)

                noonRestBegin = scheht.Item("NOONTIMEB").ToString()
                noonRestBeginNumber = getNumberTime(noonRestBegin)
                noonRestEnd = scheht.Item("NOONTIMEE").ToString()
                noonRestEndNumber = getNumberTime(noonRestEnd)
                noonRestHours = noonRestEndNumber - noonRestBeginNumber

                noonCardBegin = scheht.Item("NOONCARDTIMEB").ToString()
                noonCardBeginNumber = getNumberTime(noonCardBegin)
                noonCardEnd = scheht.Item("NOONCARDTIMEE").ToString()
                noonCardEndNumber = getNumberTime(noonCardEnd)

                If String.IsNullOrEmpty(noonCardBegin) Or String.IsNullOrEmpty(noonCardEnd) Then
                    isNoonNeedCard = "2"    '不要
                Else
                    isNoonNeedCard = "1"    '要
                End If

                offday = CType(scheht("OFFDAY"), Boolean)
            End If



            'new 設定上下班, 中午休息時間
            istransfer.beginWorkTime = workTimeBegin
            istransfer.endWorkTime = workTimeEnd
            istransfer.beginNoonRestTime = noonRestBegin
            istransfer.endNoonRestTime = noonRestEnd

            totalHour = 0
        End Sub

        Public Function transfer(ByVal reportDetail As FSC.Logic.ReportDetail, ByVal Orgcode As String) As Boolean

            Dim normal As Boolean = False

            Try
                Dim pkntime As String = "0000"
                Me.phitimeBegin = getWorkBeginCard()
                Me.phitimeEnd = getWorkEndCard()

                If Not v Is Nothing And v.Rows.Count > 0 And Not offday Then

                    '上下班卡都有的情況
                    If (Not phitimeBegin.Equals("9999")) And (Not phitimeEnd.Equals("0000")) Then

                        Dim phitimeBeginNumber As Integer = getNumberTime(phitimeBegin)
                        Dim phitimeEndNumber As Integer = getNumberTime(phitimeEnd)

                        '調整上班緩衝時間
                        phitimeBeginNumber = phitimeBeginNumber - pullOffTimeBegin

                        '調整下班緩衝時間
                        phitimeEndNumber = phitimeEndNumber + pullOffTimeEnd

                        '刷卡時間如果超過上下班起迄點，則調整時間
                        phitimeBeginNumber = Math.Max(phitimeBeginNumber, workTimeBeginNumber)
                        phitimeEndNumber = Math.Min(phitimeEndNumber, workTimeEndNumber)

                        '正常上班
                        If phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber Then

                            totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            totalHour = minuteToHour(totalHour)

                            '將分鐘轉換為小時數
                            If (totalHour > workHours) Then
                                totalHour = workHours
                            End If

                            '上下班狀態的判斷變數(預設正常：6)
                            Me.PKWKTPE = "6"

                            '如果需要刷中午卡，則判斷是否有刷中午卡
                            If isNoonNeedCard = "1" Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If pkntime.Equals("0000") Then
                                            'PKWKTPE = "0"
                                            Me.PKWKTPE = "3"   '曠職
                                        End If
                                    End If
                                End If
                            End If

                            'hsien 20130613 休假時數不足8小時
                            Dim leavehours As Integer = istransfer.GetLeaveHours(model, currentDate)
                            If leavehours < workHours Then
                                Dim tmpphbegin As String = getErrWorkBeginCard()
                                Dim tmpphend As String = getErrWorkEndCard()

                                If tmpphbegin = "9999" Or tmpphend = "0000" Then
                                    Me.PKWKTPE = "3"
                                End If
                                Me.phitimeBegin = tmpphbegin
                                Me.phitimeEnd = tmpphend
                            End If

                        End If

                        '狀況一 遲到
                        '上班卡超過上班，下班卡大於等於下班
                        If (phitimeBeginNumber > workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber) Then

                            '如果上班卡的時間在中午休息以前的話，上班時數須減中午休息時數
                            If (phitimeBeginNumber < noonRestBeginNumber) Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                                '上班卡的時間在中午休息時間
                            ElseIf (phitimeBeginNumber >= noonRestBeginNumber And phitimeBeginNumber <= noonRestEndNumber) Then
                                totalHour = phitimeEndNumber - noonRestEndNumber
                            Else
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            End If

                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數

                            '上下班狀態的判斷變數(預設已處理：5)
                            Me.PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                'Me.PKWKTPE = "1"
                                Me.PKWKTPE = "3"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為遲到，且無請假或是出差記錄。"
                                Dim errorType As String = "遲到"
                            End If

                            '需刷中午卡 且 上班卡小於中午卡開始時間, 處理中午卡 
                            If (isNoonNeedCard.Equals("1")) And phitimeBeginNumber < noonCardBeginNumber Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber) Then
                                    If istransfer.HaveNoonLeave(model, currentDate) Then
                                        If (pkntime.Equals("0000")) Then
                                            'PKWKTPE = "0"
                                            Me.PKWKTPE = "3"   '曠職
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '早退
                        If (phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber < workTimeEndNumber) Then

                            '如果下班卡的時間在中午休息時間以後的話，上班時數須減一小時；在中午休息時間中間，則用中午休息開始當作下班時間
                            If (phitimeEndNumber > noonRestEndNumber) Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours

                                'hsien 20120511 
                                If istransfer.GetLeaveHours(model, currentDate) = 4 Then
                                    totalHour = phitimeEndNumber - phitimeBeginNumber
                                Else
                                    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                                End If

                            ElseIf (phitimeEndNumber <= noonRestEndNumber And phitimeEndNumber >= noonRestBeginNumber) Then
                                '需用到彈性班半日下班時間
                                'If (phitimeEndNumber > workTimeHalfEndNumber) Then
                                '    totalHour = workTimeHalfEndNumber - phitimeBeginNumber
                                'Else
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                                'End If
                            ElseIf (phitimeEndNumber < noonRestBeginNumber) Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            End If
                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數

                            '上下班狀態的判斷變數
                            Me.PKWKTPE = "5"

                            If istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail) Then
                                'Me.PKWKTPE = "2"
                                Me.PKWKTPE = "3"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為早退，且無請假或是出差記錄。"
                                Dim errorType As String = "早退"
                            End If

                            '需刷中午卡 且 下班時間大於中午卡結束時間, 處理中午卡
                            If (isNoonNeedCard.Equals("1")) And phitimeEndNumber > noonCardEndNumber Then
                                pkntime = checkNoonCard()
                                If (phitimeEndNumber > noonRestEndNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            'PKWKTPE = "0"
                                            Me.PKWKTPE = "3"   '曠職
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '遲到早退
                        If (phitimeBeginNumber > workTimeBeginNumber And phitimeEndNumber < workTimeEndNumber) Then

                            If ((phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber <= noonRestBeginNumber) Or (phitimeBeginNumber >= noonRestEndNumber And phitimeEndNumber >= noonRestEndNumber)) Then

                                totalHour = phitimeEndNumber - phitimeBeginNumber

                            ElseIf phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber >= noonRestEndNumber Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            ElseIf (phitimeEndNumber >= noonRestBeginNumber And phitimeEndNumber <= noonRestEndNumber) Then
                                '         If (phitimeEndNumber > workTimeHalfEndNumber) Then
                                '        totalHour = workTimeHalfEndNumber - phitimeBeginNumber
                                '     Else
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                                '  End If
                            ElseIf phitimeBeginNumber >= noonRestBeginNumber And phitimeBeginNumber <= noonRestEndNumber Then
                                totalHour = phitimeEndNumber - noonRestEndNumber
                            End If
                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數
                            '上下班狀態的判斷變數
                            Me.PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                'Me.PKWKTPE = "4"
                                Me.PKWKTPE = "3"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為遲到且早退，且無請假或是出差記錄。"
                                Dim errorType As String = "遲到早退"
                            End If

                            '需刷中午卡 且 上班卡小於中午卡開始時間 且 下班卡時間大於中午卡結束時間, 處理中午卡
                            If isNoonNeedCard.Equals("1") And phitimeBeginNumber < noonCardBeginNumber And phitimeEndNumber > noonCardEndNumber Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber And phitimeEndNumber > noonRestBeginNumber) Then

                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            'PKWKTPE = "0"
                                            Me.PKWKTPE = "3"   '曠職
                                        End If
                                    End If
                                End If
                            End If

                        End If


                    ElseIf phitimeBegin.Equals("9999") And Not phitimeEnd.Equals("0000") Then
                        '沒有刷上班卡

                        '處理中午卡
                        If (isNoonNeedCard.Equals("1")) Then
                            pkntime = checkNoonCard()
                        End If

                        If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                            '刷卡不一致
                            'PKWKTPE = "0"
                            Me.PKWKTPE = "3"   '曠職
                        Else
                            Me.PKWKTPE = "5"
                        End If

                    ElseIf (Not phitimeBegin.Equals("9999")) And phitimeEnd.Equals("0000") Then
                        '沒有刷下班卡

                        '處理中午卡
                        If (isNoonNeedCard.Equals("1")) Then
                            pkntime = checkNoonCard()
                        End If

                        If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                            '刷卡不一致
                            'PKWKTPE = "0"
                            Me.PKWKTPE = "3"    '曠職
                        Else
                            Me.PKWKTPE = "5"    '已處理 
                        End If


                    Else
                        '處理中午卡
                        If (isNoonNeedCard.Equals("1")) Then
                            pkntime = checkNoonCard()
                        End If

                        If istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail) Then
                            If pkntime = "0000" Then
                                Me.PKWKTPE = "3"   '曠職
                            Else
                                'Me.PKWKTPE = "0"   '刷卡不一致
                                Me.PKWKTPE = "3"
                            End If
                        Else
                            Me.PKWKTPE = "5"       '已處理
                        End If

                    End If

                    normal = True

                Else
                    '無刷卡資料

                    If istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail) And Not offday Then
                        Me.PKWKTPE = "3"
                    Else
                        Me.PKWKTPE = "5"

                        If offday Then
                            Me.PKWKTPE = "6"
                        End If

                        normal = True
                    End If

                End If

                ''依免刷卡設定
                'Dim ns As New NocardSetting()
                'Dim nsdt As DataTable = ns.getDataByQuery(Orgcode, reportDetail.peidno, currentDate)
                'If nsdt IsNot Nothing AndAlso nsdt.Rows.Count > 0 Then
                '    '整日免刷卡
                '    If nsdt.Rows(0)("Nocard_type").ToString() = "1" Then
                '        If Me.PKWKTPE = "3" Then
                '            Me.PKWKTPE = "5"
                '        End If
                '    End If

                '    '上午免刷卡
                '    If nsdt.Rows(0)("Nocard_type").ToString() = "2" Then

                '        Dim beginflexmin As String = ConfigurationManager.AppSettings("BeginFlexMin").ToString()
                '        Dim hourb As String = noonRestEnd.Substring(0, 2)
                '        Dim minb As String = noonRestEnd.Substring(2, 2)
                '        If CommonFun.getInt(minb) - CommonFun.getInt(beginflexmin) < 0 Then
                '            hourb = (CommonFun.getInt(hourb) - 1).ToString()
                '            minb = (60 - CommonFun.getInt(beginflexmin) + CommonFun.getInt(minb)).ToString()
                '        Else
                '            minb = (CommonFun.getInt(minb) - CommonFun.getInt(beginflexmin)).ToString()
                '        End If
                '        Dim workTimeBeginFlex As String = hourb.PadLeft(2, "0") & minb.PadLeft(2, "0")

                '        If totalHour >= 4 Then
                '            '上班卡
                '            If Not v Is Nothing And 0 < v.Rows.Count Then
                '                For Each row As DataRow In v.Rows
                '                    Dim phitime As String = row("phitime")

                '                    If phitime >= workTimeBeginFlex And phitime <= noonRestEnd Then
                '                        If Me.PKWKTPE = "3" And phitimeEnd <> "0000" Then
                '                            Me.PKWKTPE = "5"
                '                            phitimeBegin = phitime
                '                            Exit For
                '                        End If
                '                    End If
                '                Next
                '            End If

                '            '下班卡
                '            Dim tmpphend As String = getErrWorkEndCard()
                '            If tmpphend = "0000" Then
                '                Me.PKWKTPE = "3"
                '                phitimeEnd = tmpphend
                '            End If
                '        Else
                '            If Not istransfer.HaveNoLeaveType124(model, currentDate, 4 - totalHour, reportDetail) Then
                '                Me.PKWKTPE = "5"
                '            End If
                '        End If

                '    End If

                '    '下午免刷卡
                '    If nsdt.Rows(0)("Nocard_type").ToString() = "3" Then

                '        Dim endflexmin As String = ConfigurationManager.AppSettings("EndFlexMin").ToString()
                '        Dim houre As String = noonRestBegin.Substring(0, 2)
                '        Dim mine As String = noonRestBegin.Substring(2, 2)
                '        If CommonFun.getInt(mine) + CommonFun.getInt(endflexmin) >= 60 Then
                '            houre = (CommonFun.getInt(houre) + 1).ToString()
                '            mine = (CommonFun.getInt(mine) + CommonFun.getInt(endflexmin) - 60).ToString()
                '        Else
                '            mine = (CommonFun.getInt(mine) + CommonFun.getInt(endflexmin)).ToString()
                '        End If
                '        Dim workTimeEndFlex As String = houre.PadLeft(2, "0") & mine.PadLeft(2, "0")

                '        If totalHour >= 4 Then
                '            '下班卡
                '            If Not v Is Nothing And 0 < v.Rows.Count Then
                '                For Each row As DataRow In v.Rows
                '                    Dim phitime As String = row("phitime")
                '                    If phitime >= noonRestBegin And phitime <= workTimeEndFlex Then
                '                        If Me.PKWKTPE = "3" And phitimeBegin <> "9999" Then
                '                            Me.PKWKTPE = "5"
                '                            phitimeEnd = phitime
                '                            Exit For
                '                        End If
                '                    End If
                '                Next
                '            End If

                '            '上班卡
                '            Dim tmpphend As String = getErrWorkBeginCard()
                '            If tmpphend = "9999" Then
                '                Me.PKWKTPE = "3"
                '                phitimeBegin = tmpphend
                '            End If
                '        Else
                '            If Not istransfer.HaveNoLeaveType124(model, currentDate, 4 - totalHour, reportDetail) Then
                '                Me.PKWKTPE = "5"
                '            End If
                '        End If


                '    End If
                'End If

                If reportDetail.pewktype.Equals("免刷卡") Then
                    Me.PKWKTPE = "6"
                End If

                If New FSC.Logic.TemporarilyTransfe().getCount(reportDetail.peidno, currentDate) > 0 Then '借調期間內
                    Me.PKWKTPE = "6"
                End If

                If New FSC.Logic.LeaveYear().getCount(reportDetail.peidno, currentDate) > 0 Then '留職停薪期間內
                    Me.PKWKTPE = "6"
                End If

                doCpapkyymm(model, currentDate, Me.phitimeBegin, pkntime, Me.phitimeEnd, Me.PKWKTPE, totalHour)

                reportDetail.setPkwktpe(Integer.Parse(PKWKTPE))
                reportDetail.workHour = workHours
                reportDetail.actualWorkHour = totalHour
                reportDetail.pkstime = phitimeBegin
                reportDetail.pketime = phitimeEnd
                reportDetail.pkntime = pkntime
                reportDetail.setNeedNoonCard(isNoonNeedCard)

            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace, ex.Message())
            End Try

            Return normal
        End Function


        Public Function getWorkBeginCard() As String

            Dim phitime As String = "9999"
            'Dim workTimeBeginFlex As String = ""

            'Dim beginflexmin As String = ConfigurationManager.AppSettings("BeginFlexMin").ToString()

            'Dim hour As String = workTimeBegin.Substring(0, 2)
            'Dim min As String = workTimeBegin.Substring(2, 2)

            'If CommonFun.getInt(min) - CommonFun.getInt(beginflexmin) < 0 Then
            '    hour = CommonFun.getInt(hour) - 1
            '    min = 60 - CommonFun.getInt(beginflexmin) + CommonFun.getInt(min)
            'Else
            '    min = min - beginflexmin
            'End If
            'workTimeBeginFlex = hour.PadLeft(2, "0") & min.PadLeft(2, "0")

            'Dim dr() As DataRow = v.Select(" phitime >='" & workTimeBeginFlex & "' and phitime <='" & workTimeBegin & "'")
            'For Each row As DataRow In dr
            '    phitime = row("phitime").ToString()
            'Next

            If Not v Is Nothing And 0 < v.Rows.Count Then
                For Each row As DataRow In v.Rows
                    Dim phitype As String = row("phitype")
                    If (phitype.Equals(beginWorkCard)) Then
                        phitime = row("phitime")
                        Exit For
                        '抓第一筆上班卡
                    End If
                Next
            End If
            Return phitime
        End Function

        Public Function getWorkEndCard() As String
            Dim phitime As String = "0000"
            'Dim workTimeEndFlex As String = ""

            'Dim endflexmin As String = ConfigurationManager.AppSettings("EndFlexMin").ToString()

            'Dim hour As String = workTimeEnd.Substring(0, 2)
            'Dim min As String = workTimeEnd.Substring(2, 2)

            'If CommonFun.getInt(min) + CommonFun.getInt(endflexmin) >= 60 Then
            '    hour = CommonFun.getInt(hour) + 1
            '    min = CommonFun.getInt(min) + CommonFun.getInt(endflexmin) - 60
            'Else
            '    min = min + endflexmin
            'End If
            'workTimeEndFlex = hour.PadLeft(2, "0") & min.PadLeft(2, "0")

            'Dim dr() As DataRow = v.Select(" phitime >='" & workTimeEnd & "' and phitime <='" & workTimeEndFlex & "'")
            'For Each row As DataRow In dr
            '    phitime = row("phitime").ToString()
            'Next

            If Not v Is Nothing And 0 < v.Rows.Count Then
                For Each row As DataRow In v.Rows
                    Dim phitype As String = row("phitype")
                    If (phitype.Equals(endWorkCard)) Then
                        phitime = row("phitime")
                        '抓最後一筆下班卡
                    End If
                Next
            End If
            Return phitime
        End Function

        Public Function checkNoonCard() As String

            Dim noonCard As String = "0000"
            If Not v Is Nothing And 0 < v.Rows.Count Then
                For Each row As DataRow In v.Rows
                    Dim phitype As String = row("phitype")
                    'If (phitype.Equals(noonCard)) Then
                    Dim phitime As String = row("phitime")
                    Dim phitimeNumber As Integer = getNumberTime(phitime)
                    If ((phitimeNumber <= noonCardEndNumber) And (phitimeNumber >= noonCardBeginNumber)) Then
                        noonCard = phitime
                        Exit For
                    End If
                    'End If
                Next
            End If
            Return noonCard
        End Function

        Public Function getErrWorkBeginCard() As String

            Dim phitime As String = "9999"
            Dim workTimeBeginFlex As String = ""

            Dim beginflexmin As String = ConfigurationManager.AppSettings("BeginFlexMin").ToString()

            Dim hour As String = workTimeBegin.Substring(0, 2)
            Dim min As String = workTimeBegin.Substring(2, 2)

            If CommonFun.getInt(min) - CommonFun.getInt(beginflexmin) < 0 Then
                hour = (CommonFun.getInt(hour) - 1).ToString()
                min = (60 - CommonFun.getInt(beginflexmin) + CommonFun.getInt(min)).ToString()
            Else
                min = (CommonFun.getInt(min) - CommonFun.getInt(beginflexmin)).ToString()
            End If
            workTimeBeginFlex = hour.PadLeft(2, "0") & min.PadLeft(2, "0")

            Dim dr() As DataRow = v.Select(" phitime >='" & workTimeBeginFlex & "' and phitime <='" & workTimeBegin & "'")
            For Each row As DataRow In dr
                phitime = row("phitime").ToString()
            Next

            Return phitime
        End Function

        Public Function getErrWorkEndCard() As String

            Dim phitime As String = "0000"
            Dim workTimeEndFlex As String = ""

            Dim endflexmin As String = ConfigurationManager.AppSettings("EndFlexMin").ToString()

            Dim hour As String = workTimeEnd.Substring(0, 2)
            Dim min As String = workTimeEnd.Substring(2, 2)

            If CommonFun.getInt(min) + CommonFun.getInt(endflexmin) >= 60 Then
                hour = (CommonFun.getInt(hour) + 1).ToString()
                min = (CommonFun.getInt(min) + CommonFun.getInt(endflexmin) - 60).ToString()
            Else
                min = (CommonFun.getInt(min) + CommonFun.getInt(endflexmin)).ToString()
            End If
            workTimeEndFlex = hour.PadLeft(2, "0") & min.PadLeft(2, "0")

            Dim dr() As DataRow = v.Select(" phitime >='" & workTimeEnd & "' and phitime <='" & workTimeEndFlex & "'")
            For Each row As DataRow In dr
                phitime = row("phitime").ToString()
            Next

            Return phitime
        End Function

        Public Function checkErrNoonCard() As String

            Dim noonCard As String = "0000"
            If Not v Is Nothing And 0 < v.Rows.Count Then
                For Each row As DataRow In v.Rows
                    Dim phitype As String = row("phitype")
                    'If (phitype.Equals(noonCard)) Then
                    Dim phitime As String = row("phitime")
                    Dim phitimeNumber As Integer = getNumberTime(phitime)
                    If ((phitimeNumber <= noonCardEndNumber) And (phitimeNumber >= noonCardBeginNumber)) Then
                        noonCard = phitime
                        Exit For
                    End If
                    'End If
                Next
            End If
            Return noonCard
        End Function


        Public Sub insertCpapkyymm(ByVal model As DataRow, ByVal currentDate As String, ByVal pkstime As String, ByVal pkntime As String, ByVal pketime As String, ByVal pkwktpe As String, ByVal pkworkh As Integer, ByVal pkforget As String)

            
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString()
            Dim pkupdate As String = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(Now)
            Dim sql As String = String.Empty
            sql = " insert into FSC_CPAPK" + yymm + " "
            sql &= " (PKIDNO, PKNAME, PKCARD, PKWDATE, PKSTIME, PKNTIME, PKETIME, PKWKTPE, PKWORKH, PKCARDVER, PKFORGET, PKUSERID, PKUPDATE) "
            sql &= " values "
            sql &= " (@PEIDNO, @PENAME, @PECARD, @CURRENTDATE, @PKSTIME, @PKNTIME, @PKETIME, @PKWKTPE,@PKWORK,'',@PKFORGET,'batch',@PKUPDATE)"

            Dim params() As SqlParameter = { _
                New SqlParameter("@PEIDNO", model("id_card").ToString()), _
                New SqlParameter("@PENAME", model("user_name").ToString()), _
                New SqlParameter("@PECARD", model("id_card").ToString()), _
                New SqlParameter("@CURRENTDATE", currentDate), _
                New SqlParameter("@PKSTIME", pkstime), _
                New SqlParameter("@PKNTIME", pkntime), _
                New SqlParameter("@PKETIME", pketime), _
                New SqlParameter("@PKWKTPE", pkwktpe), _
                New SqlParameter("@PKWORK", pkworkh), _
                New SqlParameter("@PKFORGET", pkforget), _
                New SqlParameter("@PKUPDATE", pkupdate)}

            Execute(sql, params)
        End Sub


        Public Function getCpapkyymm(ByVal model As DataRow, ByVal currentDate As String) As DataTable
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString()

            Dim sql As String = "select * from FSC_CPAPK" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params() As SqlParameter = { _
                New SqlParameter("@PKIDNO", model("id_card").ToString()), _
                New SqlParameter("@PKWDATE", currentDate)}

            Return Query(sql, params)
        End Function

        Public Sub deleteCpapkyymm(ByVal model As DataRow, ByVal currentDate As String)
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString() 'currentDate.Substring(1, 4)

            'Dim sql1 As String = "select pkforget from FSC_CPAPK" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            'Dim params() As SqlParameter = {New SqlParameter("@PKIDNO", model("id_card").ToString()), New SqlParameter("@PKWDATE", currentDate)}
            'Dim dt As DataTable = adp.ExecQueryCmd(sql1, params)

            'If Not dt Is Nothing Then
            '    For Each row As DataRow In dt.Rows
            '        pkforget = row("pkforget")
            '    Next
            'End If

            Dim sql As String = "delete FSC_CPAPK" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params2() As SqlParameter = { _
                New SqlParameter("@PKIDNO", model("id_card").ToString()), _
                New SqlParameter("@PKWDATE", currentDate)}

            Execute(sql, params2)

        End Sub

        Public Function getNumberTime(ByVal hhmm As String) As Integer '格式為hhmm

            Dim number As Integer = 0

            Try
                Dim hh As String = hhmm.Substring(0, 2)
                Dim mm As String = hhmm.Substring(2)
                number = Integer.Parse(hh) * 60 + Integer.Parse(mm)
            Catch ex As Exception

            End Try

            Return number
        End Function

        Public Function minuteToHour(ByVal number As Integer) As Integer
            Dim hour As Integer = 0
            hour = Fix(number / 60)
            Return hour
        End Function


        Public Sub doCpapkyymm(ByVal model As DataRow, _
                               ByVal currentDate As String, _
                               ByVal pkstime As String, _
                               ByVal pkntime As String, _
                               ByVal pketime As String, _
                               ByVal PKWKTPE As String, _
                               ByVal pkworkh As Integer)

            Dim idCard As String = model("id_card").ToString()
            Dim cpapyyys As New FSC.Logic.CPAPYYYS(Mid(Me.currentDate, 1, 3))
            Dim column As String = "PYMON" & FSCPLM.Logic.DateTimeInfo.GetPublicDate(Me.currentDate).Month

            Dim pkdt As DataTable = getCpapkyymm(model, currentDate)

            If pkdt IsNot Nothing AndAlso pkdt.Rows.Count > 0 Then

                Dim old_pkwktpe As String = pkdt.Rows(0)("pkwktpe").ToString    '上下班狀態
                Dim old_pkforget As String = pkdt.Rows(0)("pkforget").ToString  '忘刷卡註記

                If old_pkwktpe = "5" Then

                    'If pkdt.Rows(0)("PKSTIME").ToString() = "9999" And pkdt.Rows(0)("PKETIME").ToString() = "0000" Then
                    '    insertCpapi09m(model)
                    '    deleteCpapkyymm(model, currentDate)
                    '    insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, org_pkforget)
                    'Else
                    '    Me.PKWKTPE = org_pkwktpe
                    '    Me.phitimeBegin = pkdt.Rows(0)("PKSTIME").ToString()
                    '    Me.phitimeEnd = pkdt.Rows(0)("PKETIME").ToString()
                    '    Me.totalHour = pkdt.Rows(0)("PKWORKH").ToString()
                    'End If

                    Me.PKWKTPE = old_pkwktpe
                    Me.phitimeBegin = pkdt.Rows(0)("PKSTIME").ToString()
                    Me.phitimeEnd = pkdt.Rows(0)("PKETIME").ToString()
                    Me.totalHour = pkdt.Rows(0)("PKWORKH").ToString()

                ElseIf old_pkwktpe <> "5" Then 'And old_pkwktpe <> "6" Then
                    '不是"已處理"及"正常"

                    deleteCpapkyymm(model, currentDate)
                    insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, old_pkforget)

                    If PKWKTPE = "1" Then
                        '遲到
                        If PKWKTPE <> old_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "51")
                        End If

                    ElseIf PKWKTPE = "2" Then
                        '早退
                        If PKWKTPE <> old_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "52")
                        End If

                    ElseIf PKWKTPE = "3" Then
                        '曠職
                        If PKWKTPE <> old_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "53")
                        End If

                    ElseIf PKWKTPE = "5" Or PKWKTPE = "6" Then

                        If old_pkwktpe = "1" Then
                            '遲到
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "51")
                        ElseIf old_pkwktpe = "2" Then
                            '早退
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "52")
                        ElseIf old_pkwktpe = "3" Then
                            '曠職
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "53")
                        End If

                    End If

                End If

            Else

                insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, "")

                If PKWKTPE = "1" Then
                    '遲到
                    cpapyyys.UpdateDataByColumn(column, 1, idCard, "51")
                ElseIf PKWKTPE = "2" Then
                    '早退
                    cpapyyys.UpdateDataByColumn(column, 1, idCard, "52")
                ElseIf PKWKTPE = "3" Then
                    '曠職
                    cpapyyys.UpdateDataByColumn(column, 1, idCard, "53")
                End If

            End If


        End Sub

    End Class
End Namespace