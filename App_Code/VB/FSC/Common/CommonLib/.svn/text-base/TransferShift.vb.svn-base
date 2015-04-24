Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports FSCPLM.Logic
Imports System.Collections
Imports System

Namespace FSC.Logic

    Public Class TransferShift
        Inherits BaseDAO

        Private v As New DataTable
        Private model As DataRow         'CPAPE05M DataRow
        Private currentDate As String = String.Empty

        Private workTimeBegin As String = String.Empty '正常班上班
        Private workTimeBeginNumber As Integer
        Private workTimeEnd As String = String.Empty '正常班下班
        Private workTimeEndNumber As Integer
        Private workTimeHalfBegin As String = String.Empty '正常班上班(半日)
        Private workTimeHalfBeginNumber As Integer
        Private workTimeHalfEnd As String = String.Empty '正常班下班(半日)
        Private workTimeHalfEndNumber As Integer
        Private noonRestBegin As String = String.Empty '中午休息開始
        Private noonRestBeginNumber As Integer
        Private noonRestEnd As String = String.Empty '中午休息結束
        Private noonRestEndNumber As Integer
        '中午休息時間
        'Private noonRestHours As Integer
        'Private noonCardBegin As String = String.Empty '中午卡刷卡時間開始
        'Private noonCardBeginNumber As Integer
        'Private noonCardEnd As String = String.Empty '中午卡刷卡時間結束
        'Private noonCardEndNumber As Integer
        Private isNoonNeedCard As String = String.Empty '中午需不需要刷卡 1:要 2:不要

        Private workHours As Integer '全天上班至少上班時數
        Private workHoursHalf As Integer '半天上班至少上班時數

        Private pullOffTimeBegin As Integer '上班緩衝時間
        Private pullOffTimeEnd As Integer '下班緩衝時間

        Private beginWorkCard As String = "A" '上班卡phitype
        Private endWorkCard As String = "D" '下班卡phitype
        Private noonCard As String = "A" '中午卡phitype


        Private totalHour As Integer = 0
        Private PKWKTPE As String = "8"
        Private phitimeBegin As String
        Private phitimeEnd As String

        Private istransfer As Istransfer

        'Public Sub New(ByVal conn As SqlConnection)
        '    MyBase.New(conn)
        '    istransfer = New Istransfer(conn)
        'End Sub

        Public Sub New()
            MyBase.New()
            istransfer = New Istransfer()
        End Sub

        Public Sub Init(ByVal hash As Hashtable, ByVal phyymm As DataTable, ByVal vmodel As DataRow, ByVal vcurrentDate As String, ByVal pmstype As String)

            Me.v = phyymm
            Me.model = vmodel
            Me.currentDate = vcurrentDate

            workTimeBegin = CType(CType(hash.Item("shiftTime" & pmstype), Hashtable).Item("PCPARM1"), String)
            workTimeBeginNumber = getNumberTime(workTimeBegin)
            workTimeEnd = CType(CType(hash.Item("shiftTime" & pmstype), Hashtable).Item("PCPARM2"), String)
            workTimeEndNumber = getNumberTime(workTimeEnd)

            'workTimeHalfBegin = CType(CType(hash.Item("normalWorkTimeHalf"), Hashtable).Item("PCPARM1"), String)
            'workTimeHalfBeginNumber = getNumberTime(workTimeHalfBegin)
            'workTimeHalfEnd = CType(CType(hash.Item("normalWorkTimeHalf"), Hashtable).Item("PCPARM2"), String)
            'workTimeHalfEndNumber = getNumberTime(workTimeHalfEnd)

            noonRestBegin = CType(CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM1"), String)
            noonRestBeginNumber = getNumberTime(noonRestBegin)
            noonRestEnd = CType(CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM2"), String)
            noonRestEndNumber = getNumberTime(noonRestEnd)
            'noonRestHours = noonRestEndNumber - noonRestBeginNumber
            'noonCardBegin = CType(CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM1"), String)
            'noonCardBeginNumber = getNumberTime(noonCardBegin)
            'noonCardEnd = CType(CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM2"), String)
            'noonCardEndNumber = getNumberTime(noonCardEnd)
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


            'new 設定上下班中午休息時間
            istransfer.beginWorkTime = workTimeBegin
            istransfer.endWorkTime = workTimeEnd
            istransfer.beginNoonRestTime = noonRestBegin
            istransfer.endNoonRestTime = noonRestEnd

            totalHour = 0
        End Sub

        Public Function transfer(ByVal reportDetail As ReportDetail) As Boolean

            Dim normal As Boolean = True

            Try
                deleteCpapi09m(model)

                Dim pkntime As String = "0000"
                Me.phitimeBegin = getWorkBeginCard()
                Me.phitimeEnd = getWorkEndCard()

                If Not v Is Nothing And v.Rows.Count > 0 Then

                    '上下班卡都有的情況
                    If (Not phitimeBegin.Equals("9999")) And (Not phitimeEnd.Equals("0000")) Then

                        Dim phitimeBeginNumber As Integer = getNumberTime(phitimeBegin)
                        Dim phitimeEndNumber As Integer = getNumberTime(phitimeEnd)

                        '調整上班緩衝時間
                        phitimeBeginNumber = phitimeBeginNumber - pullOffTimeBegin

                        '調整下班緩衝時間
                        phitimeEndNumber = phitimeEndNumber + pullOffTimeEnd


                        '上下班時間如果超過輪班上下班起迄點，則調整時間
                        phitimeBeginNumber = Math.Max(phitimeBeginNumber, workTimeBeginNumber)
                        phitimeEndNumber = Math.Min(phitimeEndNumber, workTimeEndNumber)

                        '正常上班
                        If phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber Then

                            totalHour = phitimeEndNumber - phitimeBeginNumber '- noonRestHours
                            totalHour = minuteToHour(totalHour)

                            '將分鐘轉換為小時數
                            If (totalHour > workHours) Then
                                totalHour = workHours
                            End If

                            '上下班狀態的判斷變數(預設正常：6)
                            PKWKTPE = "6"

                            '如果需要刷中午卡，則判斷是否有刷中午卡
                            If isNoonNeedCard = "1" Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If pkntime.Equals("0000") Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If


                        '狀況一 遲到
                        '上班卡超過彈性上班，下班卡大於等於彈性下班
                        If (phitimeBeginNumber > workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber) Then

                            '如果上班卡的時間在中午休息以前的話，上班時數須減中午休息時數
                            'If (phitimeBeginNumber < noonRestBeginNumber) Then
                            '    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            '    '上班卡的時間在中午休息時間
                            'ElseIf (phitimeBeginNumber <= noonRestBeginNumber And phitimeBeginNumber >= noonRestEndNumber) Then
                            '    totalHour = phitimeEndNumber - noonRestEndNumber
                            'Else
                            totalHour = phitimeEndNumber - phitimeBeginNumber
                            'End If

                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數

                            '上下班狀態的判斷變數(預設已處理：5)
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                PKWKTPE = "1"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為遲到，且無請假或是出差記錄。"
                                Dim errorType As String = "遲到"
                            End If

                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber) Then
                                    If istransfer.HaveNoonLeave(model, currentDate) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '早退
                        If (phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber < workTimeEndNumber) Then

                            '如果下班卡的時間在中午休息時間以後的話，上班時數須減一小時；在中午休息時間中間，則用中午休息開始當作下班時間
                            'If (phitimeEndNumber > noonRestEndNumber) Then
                            '    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            'ElseIf (phitimeEndNumber <= noonRestEndNumber And phitimeEndNumber >= noonRestBeginNumber) Then
                            '    '需用到彈性班半日下班時間
                            '    If (phitimeEndNumber > workTimeHalfEndNumber) Then
                            '        totalHour = workTimeHalfEndNumber - phitimeBeginNumber
                            '    Else
                            '        totalHour = phitimeEndNumber - phitimeBeginNumber
                            '    End If
                            'ElseIf (phitimeEndNumber < noonRestBeginNumber) Then
                            totalHour = phitimeEndNumber - phitimeBeginNumber
                            'End If
                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數

                            '上下班狀態的判斷變數
                            PKWKTPE = "5"

                            If istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail) Then
                                PKWKTPE = "2"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為早退，且無請假或是出差記錄。"
                                Dim errorType As String = "早退"
                            End If
                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                                If (phitimeEndNumber > noonRestEndNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '遲到早退
                        If (phitimeBeginNumber > workTimeBeginNumber And phitimeEndNumber < workTimeEndNumber) Then

                            'If ((phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber <= noonRestBeginNumber) Or (phitimeBeginNumber >= noonRestEndNumber And phitimeEndNumber >= noonRestEndNumber)) Then

                            '    totalHour = phitimeEndNumber - phitimeBeginNumber

                            'ElseIf phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber >= noonRestEndNumber Then
                            '    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            'ElseIf (phitimeEndNumber >= noonRestBeginNumber And phitimeEndNumber <= noonRestEndNumber) Then
                            '    If (phitimeEndNumber > workTimeHalfEndNumber) Then
                            '        totalHour = workTimeHalfEndNumber - phitimeBeginNumber
                            '    Else
                            '        totalHour = phitimeEndNumber - phitimeBeginNumber
                            '    End If
                            'ElseIf phitimeBeginNumber >= noonRestBeginNumber And phitimeBeginNumber <= noonRestEndNumber Then
                            totalHour = phitimeEndNumber - phitimeBeginNumber
                            'End If
                            totalHour = minuteToHour(totalHour)
                            '將分鐘轉換為小時數
                            '上下班狀態的判斷變數
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                PKWKTPE = "4"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為遲到且早退，且無請假或是出差記錄。"
                                Dim errorType As String = "遲到早退"
                            End If

                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber And phitimeEndNumber > noonRestBeginNumber) Then

                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        ElseIf phitimeBegin.Equals("9999") And (Not phitimeEnd.Equals("0000")) Then
                            '沒有刷上班卡

                            If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                                '刷卡不一致
                                PKWKTPE = "0"
                            Else
                                PKWKTPE = "5"
                            End If

                        ElseIf (Not phitimeBegin.Equals("9999")) And phitimeEnd.Equals("0000") Then
                            '沒有刷下班卡

                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                            End If

                            If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                                '刷卡不一致
                                PKWKTPE = "0"
                            Else
                                PKWKTPE = "5"
                            End If

                        End If

                        doCpapkyymm(model, currentDate, phitimeBegin, pkntime, phitimeEnd, PKWKTPE, totalHour)
                        normal = True

                    Else
                        '無刷卡資料, 曠職

                        Dim isnoleave As Boolean = istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)

                        If isnoleave Then
                            'insertCpapi09m(model)
                            normal = False
                            PKWKTPE = "3"
                        Else
                            PKWKTPE = "5"
                        End If

                        doCpapkyymm(model, currentDate, phitimeBegin, pkntime, phitimeEnd, PKWKTPE, totalHour)

                    End If

                    reportDetail.setPkwktpe(Integer.Parse(PKWKTPE))
                    reportDetail.workHour = workHours
                    reportDetail.actualWorkHour = totalHour
                    reportDetail.pkstime = phitimeBegin
                    reportDetail.pketime = phitimeEnd
                    reportDetail.pkntime = pkntime
                    reportDetail.setNeedNoonCard(isNoonNeedCard)

                End If

            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace, ex.Message())
            End Try

            Return normal

        End Function

        Public Sub insertCpapi09m(ByVal model As DataRow)

            Dim piname As String = model("pename")
            Dim picard As String = model("pecard")
            Dim piidno As String = model("peidno")
            Dim piupdate As String = Content.toTaiwanDateMinute(Content.formatCurrentDateMinute())

            Dim sql As String = "insert into cpapi09m values(@PENAME,@PECARD,@PEIDNO,@CURRENTDATE,'intranet',@PIUPDATE)"
            Dim params() As SqlParameter = {New SqlParameter("@PENAME", piname), _
            New SqlParameter("@PECARD", picard), _
            New SqlParameter("@PEIDNO", piidno), _
            New SqlParameter("@CURRENTDATE", currentDate), _
            New SqlParameter("@PIUPDATE", piupdate)}

            Execute(sql, params)

        End Sub

        Public Function getWorkBeginCard() As String
            Dim phitime As String = "9999"
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
                    'If ((phitimeNumber <= noonCardEndNumber) And (phitimeNumber >= noonCardBeginNumber)) Then
                    '    noonCard = phitime
                    '    Exit For
                    'End If
                    'End If
                Next
            End If
            Return noonCard
        End Function


        Public Sub insertCpapkyymm(ByVal model As DataRow, ByVal currentDate As String, ByVal pkstime As String, ByVal pkntime As String, ByVal pketime As String, ByVal pkwktpe As String, ByVal pkworkh As Integer, ByVal pkforget As String)

            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString()
            Dim pkupdate As String = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(Now)
            Dim sql As String = String.Empty
            sql = " insert into cpapk" + yymm + " "
            sql &= " (PKIDNO, PKNAME, PKCARD, PKWDATE, PKSTIME, PKNTIME, PKETIME, PKWKTPE, PKWORKH, PKCARDVER, PKFORGET, PKUSERID, PKUPDATE) "
            sql &= " values "
            sql &= " (@PEIDNO, @PENAME, @PECARD, @CURRENTDATE, @PKSTIME, @PKNTIME, @PKETIME, @PKWKTPE,@PKWORK,'',@PKFORGET,'intranet',@PKUPDATE)"

            Dim params() As SqlParameter = {New SqlParameter("@PEIDNO", model("peidno")), _
            New SqlParameter("@PENAME", model("pename")), _
            New SqlParameter("@PECARD", model("pecard")), _
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

        Public Sub deleteCpapi09m(ByVal model As DataRow)
            Dim sql As String = "delete cpapi09m where piidno=@PKIDNO and piidate=@PKWDATE "
            Dim params2() As SqlParameter = { _
            New SqlParameter("@PKIDNO", model("peidno")), _
            New SqlParameter("@PKWDATE", currentDate)}

            Execute(sql, params2)
        End Sub


        Public Function getCpapkyymm(ByVal model As DataRow, ByVal currentDate As String) As DataTable
            Dim pkwktpe As String = String.Empty
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString()

            Dim sql As String = "select * from cpapk" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PKIDNO", model("peidno")), _
            New SqlParameter("@PKWDATE", currentDate)}

            Return Query(sql, params)
        End Function

        Public Function deleteCpapkyymm(ByVal model As DataRow, ByVal currentDate As String) As String
            Dim pkforget As String = ""
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString() 'currentDate.Substring(1, 4)

            'Dim sql1 As String = "select pkforget from cpapk" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            'Dim params() As SqlParameter = {New SqlParameter("@PKIDNO", model("peidno")), New SqlParameter("@PKWDATE", currentDate)}
            'Dim dt As DataTable = adp.ExecQueryCmd(sql1, params)

            'If Not dt Is Nothing Then
            '    For Each row As DataRow In dt.Rows
            '        pkforget = row("pkforget")
            '    Next
            'End If

            Dim sql As String = "delete cpapk" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params2() As SqlParameter = { _
            New SqlParameter("@PKIDNO", model("peidno")), _
            New SqlParameter("@PKWDATE", currentDate)}

            Execute(sql, params2)

            Return pkforget
        End Function

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


        Public Sub doCpapkyymm(ByVal model As DataRow, ByVal currentDate As String, ByVal pkstime As String, ByVal pkntime As String, _
                                   ByVal pketime As String, ByVal PKWKTPE As String, ByVal pkworkh As Integer)

            Dim cpapyyys As New FSC.Logic.CPAPYYYS(Mid(Me.currentDate, 1, 3))

            Dim column As String = "PYMON" & FSCPLM.Logic.DateTimeInfo.GetPublicDate(Me.currentDate).Month

            Dim pkdt As DataTable = getCpapkyymm(model, currentDate)

            If pkdt IsNot Nothing AndAlso pkdt.Rows.Count > 0 Then

                Dim org_pkwktpe As String = pkdt.Rows(0)("pkwktpe").ToString    '上下班狀態
                Dim org_pkforget As String = pkdt.Rows(0)("pkforget").ToString  '忘刷卡註記

                If org_pkwktpe = "5" And PKWKTPE = "3" Then

                    If pkdt.Rows(0)("PKSTIME").ToString() = "9999" And pkdt.Rows(0)("PKETIME").ToString() = "0000" Then
                        insertCpapi09m(model)
                        deleteCpapkyymm(model, currentDate)
                        insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, org_pkforget)
                    Else
                        Me.PKWKTPE = org_pkwktpe
                        Me.phitimeBegin = pkdt.Rows(0)("PKSTIME").ToString()
                        Me.phitimeEnd = pkdt.Rows(0)("PKETIME").ToString()
                        Me.totalHour = pkdt.Rows(0)("PKWORKH").ToString()
                    End If

                ElseIf org_pkwktpe <> "5" And org_pkwktpe <> "6" Then
                    '不是"已處理"及"正常"

                    deleteCpapkyymm(model, currentDate)
                    insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, org_pkforget)

                    If PKWKTPE = "1" Then
                        '遲到
                        If PKWKTPE <> org_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "51")
                        End If

                    ElseIf PKWKTPE = "2" Then
                        '早退
                        If PKWKTPE <> org_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "52")
                        End If

                    ElseIf PKWKTPE = "3" Then
                        '曠職
                        If PKWKTPE <> org_pkwktpe Then
                            insertCpapi09m(model)
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "53")
                        End If

                    ElseIf PKWKTPE = "5" Or PKWKTPE = "6" Then

                        If org_pkwktpe = "1" Then
                            '遲到
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "51")
                        ElseIf org_pkwktpe = "2" Then
                            '早退
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "52")
                        ElseIf org_pkwktpe = "3" Then
                            '曠職
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "53")
                        End If

                    End If

                End If

            Else

                insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, "")

                If PKWKTPE = "1" Then
                    '遲到
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "51")
                ElseIf PKWKTPE = "2" Then
                    '早退
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "52")
                ElseIf PKWKTPE = "3" Then
                    '曠職
                    insertCpapi09m(model)
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "53")
                End If

            End If


        End Sub

    End Class

End Namespace