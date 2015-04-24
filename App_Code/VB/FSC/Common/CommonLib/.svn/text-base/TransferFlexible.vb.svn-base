Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports FSCPLM.Logic
Imports NLog
Imports System.Collections
Imports System

Namespace FSC.Logic
    Public Class TransferFlexible
        Inherits BaseDAO


#Region "fields"
        Private v As New DataTable
        Private model As DataRow         'CPAPE05M DataRow
        Private currentDate As String = String.Empty
        Private offday As Boolean

        Private isHaveCard As Boolean = True

        Private flexibleWorkTimeBegin As String '彈性班上班開始
        Private workTimeBegin As String '正常班上班
        Private workTimeEnd As String '正常班下班
        Private flexibleWorkTimeBeginNumber As Integer
        Private flexibleWorkTimeEnd As String '彈性班上班結束
        Private flexibleWorkTimeEndNumber As Integer
        Private flexibleOffTimeBegin As String '彈性班下班進
        Private flexibleOffTimeBeginNumber As Integer
        Private flexibleOffTimeEnd As String '彈性班下班出
        Private flexibleOffTimeEndNumber As Integer
        Private flexibleOffTimeHalfBegin As String '彈性班下班進(半日)
        Private flexibleOffTimeHalfBeginNumber As Integer
        Private flexibleOffTimeHalfEnd As String '彈性班下班出(半日)
        Private flexibleOffTimeHalfEndNumber As Integer
        Private noonRestBegin As String '中午休息開始
        Private noonRestBeginNumber As Integer
        Private noonRestEnd As String '中午休息結束
        Private noonRestEndNumber As Integer
        '中午休息時間
        Private noonRestHours As Integer
        Private noonCardBegin As String '中午卡刷卡時間開始
        Private noonCardBeginNumber As Integer
        Private noonCardEnd As String '中午卡刷卡時間結束
        Private noonCardEndNumber As Integer
        Private isNoonNeedCard As String '中午需不需要刷卡 1:要 2:不要

        Private pullOffTimeBegin As Integer '上班緩衝時間
        Private pullOffTimeEnd As Integer '下班緩衝時間

        Private workHours As Integer '全天上班至少上班時數
        Private workHoursHalf As Integer '半天上班至少上班時數

        Private beginWorkCard As String = "A" '上班卡phitype
        Private endWorkCard As String = "D" '下班卡phitype
        Private noonCard As String = "A" '中午卡phitype

        Private totalHour As Integer = 0
        Private PKWKTPE As String = "8"
        Private phitimeBegin As String
        Private phitimeEnd As String

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

            workTimeBegin = CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM1")
            workTimeEnd = CType(hash.Item("normalWorkTime"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("normalWorkTime")).PCPARM3

            flexibleWorkTimeBegin = CType(hash.Item("flexibleWorkTime"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("flexibleWorkTime")).PCPARM1
            flexibleWorkTimeBeginNumber = getNumberTime(flexibleWorkTimeBegin)
            flexibleWorkTimeEnd = CType(hash.Item("flexibleWorkTime"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("flexibleWorkTime")).PCPARM3
            flexibleWorkTimeEndNumber = getNumberTime(flexibleWorkTimeEnd)
            flexibleOffTimeBegin = CType(hash.Item("flexibleOffTime"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("flexibleOffTime")).PCPARM1
            flexibleOffTimeBeginNumber = getNumberTime(flexibleOffTimeBegin)
            flexibleOffTimeEnd = CType(hash.Item("flexibleOffTime"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("flexibleOffTime")).PCPARM3
            flexibleOffTimeEndNumber = getNumberTime(flexibleOffTimeEnd)
            flexibleOffTimeHalfBegin = CType(hash.Item("flexibleOffTimeHalf"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("flexibleOffTimeHalf")).PCPARM1
            flexibleOffTimeHalfBeginNumber = getNumberTime(flexibleOffTimeHalfBegin)
            flexibleOffTimeHalfEnd = CType(hash.Item("flexibleOffTimeHalf"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("flexibleOffTimeHalf")).PCPARM3
            flexibleOffTimeHalfEndNumber = getNumberTime(flexibleOffTimeHalfEnd)
            noonRestBegin = CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("noonRestTime")).PCPARM1
            noonRestBeginNumber = getNumberTime(noonRestBegin)
            noonRestEnd = CType(hash.Item("noonRestTime"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("noonRestTime")).PCPARM3
            noonRestEndNumber = getNumberTime(noonRestEnd)
            noonRestHours = noonRestEndNumber - noonRestBeginNumber
            noonCardBegin = CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("noonCardTime")).PCPARM1
            noonCardBeginNumber = getNumberTime(noonCardBegin)
            noonCardEnd = CType(hash.Item("noonCardTime"), Hashtable).Item("PCPARM2") '((Cpapc03mData.value) hash.get("noonCardTime")).PCPARM3
            noonCardEndNumber = getNumberTime(noonCardEnd)
            isNoonNeedCard = CType(hash.Item("isNoonNeedCard"), Hashtable).Item("PCPARM1") '((Cpapc03mData.value) hash.get("isNoonNeedCard")).PCPARM1

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

                'flexibleOffTimeHalfBegin = ""
                flexibleOffTimeHalfBeginNumber = getNumberTime(flexibleOffTimeHalfBegin)
                'flexibleOffTimeHalfEnd = ""
                flexibleOffTimeHalfEndNumber = getNumberTime(flexibleOffTimeHalfEnd)

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

            'new 設定上下班中午休息時間
            istransfer.beginWorkTime = workTimeBegin
            istransfer.endWorkTime = workTimeEnd
            istransfer.beginNoonRestTime = noonRestBegin
            istransfer.endNoonRestTime = noonRestEnd

            totalHour = 0
        End Sub

        '執行刷卡轉差勤
        Public Function transfer(ByVal reportDetail As ReportDetail, ByVal Orgcode As String) As Boolean

            Dim flexible As Boolean = False

            Try
                Dim pkntime As String = "0000"
                Me.phitimeBegin = getWorkBeginCard()
                Me.phitimeEnd = getWorkEndCard()

                If Not v Is Nothing And v.Rows.Count > 0 And Not Offday Then

                    '上下班卡都有的情況
                    If (Not phitimeBegin.Equals("9999") And Not phitimeEnd.Equals("0000")) Then

                        Dim phitimeBeginNumber As Integer = getNumberTime(phitimeBegin)
                        Dim phitimeEndNumber As Integer = getNumberTime(phitimeEnd)

                        '調整上班緩衝時間
                        phitimeBeginNumber = phitimeBeginNumber - pullOffTimeBegin
                        phitimeEndNumber = phitimeEndNumber + pullOffTimeEnd

                        '上下班時間如果超過彈性上下班起迄點，則調整時間
                        phitimeBeginNumber = Math.Max(phitimeBeginNumber, flexibleWorkTimeBeginNumber)
                        phitimeEndNumber = Math.Min(phitimeEndNumber, flexibleOffTimeEndNumber)

                        '狀況一 遲到
                        '上班卡超過彈性上班，下班卡大於等於彈性下班
                        If (phitimeBeginNumber > flexibleWorkTimeEndNumber And phitimeEndNumber >= flexibleOffTimeEndNumber) Then

                            '如果上班卡的時間在中午休息以前的話，上班時數須減中午休息時數
                            If (phitimeBeginNumber < noonRestBeginNumber) Then

                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                                '上班卡的時間在中午休息時間
                            ElseIf (phitimeBeginNumber <= noonRestBeginNumber And phitimeBeginNumber >= noonRestEndNumber) Then
                                totalHour = phitimeEndNumber - noonRestEndNumber
                            Else
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            End If

                            '將分鐘轉換為小時數
                            totalHour = minuteToHour(totalHour)

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
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '狀況二 早退 
                        '上班卡小於或等於彈性下班，下班卡小於彈性下班
                        If (phitimeBeginNumber <= flexibleWorkTimeEndNumber And phitimeEndNumber < flexibleOffTimeEndNumber) Then

                            If (phitimeEndNumber > noonRestEndNumber) Then

                                'hsien 20140702
                                If istransfer.GetLeaveHours(model, currentDate, reportDetail) = 4 Then
                                    totalHour = phitimeEndNumber - phitimeBeginNumber
                                Else
                                    '如果下班卡的時間在中午休息時間以後的話，上班時數須減一小時
                                    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                                End If

                            ElseIf (phitimeEndNumber <= noonRestEndNumber And phitimeEndNumber >= noonRestBeginNumber) Then
                                '在中午休息時間中間，則最多可計算至半日彈性下班時間結束

                                '需用到彈性班半日下班時間
                                If (phitimeEndNumber > flexibleOffTimeHalfEndNumber) Then
                                    totalHour = flexibleOffTimeHalfEndNumber - phitimeBeginNumber
                                Else
                                    totalHour = phitimeEndNumber - phitimeBeginNumber
                                End If

                            ElseIf (phitimeEndNumber < noonRestBeginNumber) Then
                                '如果下班卡的時間在中午休息時間之前
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            End If

                            '將分鐘轉換為小時數
                            totalHour = minuteToHour(totalHour)

                            '上下班狀態的判斷變數(預設已處理：5)
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
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

                        '狀況三  遲到早退
                        '上班卡大於彈性上班，下班卡小於彈性下班
                        If ((phitimeBeginNumber > flexibleWorkTimeEndNumber And phitimeEndNumber < flexibleOffTimeEndNumber)) Then

                            If ((phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber <= noonRestBeginNumber) Or (phitimeBeginNumber >= noonRestEndNumber And phitimeEndNumber >= noonRestEndNumber)) Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            ElseIf (phitimeBeginNumber <= noonRestBeginNumber And phitimeEndNumber >= noonRestEndNumber) Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            ElseIf (phitimeEndNumber >= noonRestBeginNumber And phitimeEndNumber <= noonRestEndNumber) Then
                                '需用到彈性班半日下班時間
                                If (phitimeEndNumber > flexibleOffTimeHalfEndNumber) Then
                                    totalHour = flexibleOffTimeHalfEndNumber - phitimeBeginNumber
                                Else
                                    totalHour = phitimeEndNumber - phitimeBeginNumber
                                End If
                            ElseIf (phitimeBeginNumber >= noonRestBeginNumber And phitimeBeginNumber <= noonRestEndNumber) Then
                                totalHour = phitimeEndNumber - noonRestEndNumber
                            End If

                            '將分鐘轉換為小時數
                            totalHour = minuteToHour(totalHour)

                            '上下班狀態的判斷變數(預設已處理：5)
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                PKWKTPE = "4"
                                Dim reason As String = "您在 " + currentDate + " 的刷卡資料為遲到且早退，且無請假或是出差記錄。"
                                Dim errorType As String = "遲到早退"
                            End If

                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber And phitimeEndNumber > noonRestEndNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        '狀況五 正常上下班
                        If phitimeBeginNumber >= flexibleWorkTimeBeginNumber And phitimeBeginNumber <= flexibleWorkTimeEndNumber And _
                           phitimeEndNumber >= flexibleOffTimeBeginNumber And phitimeEndNumber <= flexibleOffTimeEndNumber Then

                            'hsien 20140702
                            If istransfer.GetLeaveHours(model, currentDate, reportDetail) = 4 Then
                                totalHour = phitimeEndNumber - phitimeBeginNumber
                            Else
                                totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            End If

                            totalHour = minuteToHour(totalHour)

                            '將分鐘轉換為小時數
                            If (totalHour > workHours) Then
                                totalHour = workHours
                            End If

                            '上下班狀態的判斷變數
                            PKWKTPE = "6"

                            If (totalHour < workHours) Then
                                If (istransfer.HaveNoLeave(model, currentDate, workHours - totalHour, reportDetail)) Then
                                    PKWKTPE = "2"
                                    Dim reason As String = "您在 " + currentDate + " 的刷卡資料為早退，且無請假或是出差記錄。"
                                    Dim errorType As String = "早退"
                                End If
                            End If

                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                                If (phitimeBeginNumber < noonRestBeginNumber) Then
                                    If (istransfer.HaveNoonLeave(model, currentDate)) Then
                                        If (pkntime.Equals("0000")) Then
                                            PKWKTPE = "0"
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        ElseIf (phitimeBegin.Equals("9999") And Not phitimeEnd.Equals("0000")) Then
                            '沒有刷上班卡

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

                        ElseIf (Not phitimeBegin.Equals("9999") And phitimeEnd.Equals("0000")) Then
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

                        Else
                            '處理中午卡
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                            End If

                            If istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail) Then
                                If pkntime = "0000" Then
                                    PKWKTPE = "3"   '曠職
                                Else
                                    PKWKTPE = "0"   '刷卡不一致
                                End If
                            Else
                                PKWKTPE = "5"       '已處理
                            End If

                        End If

                    flexible = True

                Else
                    '無刷卡資料

                    If istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail) And Not offday Then
                        PKWKTPE = "3"   '曠職
                    Else
                        PKWKTPE = "5"

                        If offday Then
                            Me.PKWKTPE = "6"
                        End If
                        '
                        flexible = True
                    End If
                End If
                'Dim ns As New NocardSetting()
                'Dim nsdt As DataTable = ns.getDataByQuery(Orgcode, reportDetail.peidno, currentDate)
                'If nsdt IsNot Nothing AndAlso nsdt.Rows.Count > 0 Then
                '    If Me.PKWKTPE = "3" Then
                '        Me.PKWKTPE = "5"
                '    End If
                'End If

                If New FSC.Logic.TemporarilyTransfe().getCount(reportDetail.peidno, currentDate) > 0 Then '借調期間內
                    Me.PKWKTPE = "6"
                End If

                If New FSC.Logic.LeaveYear().getCount(reportDetail.peidno, currentDate) > 0 Then '留職停薪期間內
                    Me.PKWKTPE = "6"
                End If

                'hsien 20140710
                If currentDate = DateTimeInfo.GetRocDate(Now) And Now.ToString("HHmm") < "1300" And PKWKTPE = "3" Then
                    PKWKTPE = ""
                End If

                doCpapkyymm(model, currentDate, phitimeBegin, pkntime, phitimeEnd, PKWKTPE, totalHour)

                '=============================0980815==========================================
                reportDetail.setPkwktpe(Integer.Parse(Me.PKWKTPE))
                reportDetail.workHour = Me.workHours
                reportDetail.actualWorkHour = totalHour
                reportDetail.pkstime = Me.phitimeBegin
                reportDetail.pketime = Me.phitimeEnd
                reportDetail.pkntime = pkntime
                reportDetail.setNeedNoonCard(isNoonNeedCard)

            Catch ex As Exception
                Throw ex
            End Try

            Return flexible
        End Function

        Public Function getWorkBeginCard() As String
            Dim phitime As String = "9999"
            For Each row As DataRow In v.Rows
                Dim phitype As String = row("phitype")
                If (phitype.Equals(beginWorkCard)) Then
                    phitime = row("phitime")
                    Exit For
                    '抓第一筆上班卡
                End If
            Next
            Return phitime
        End Function

        Public Function getWorkEndCard() As String
            Dim phitime As String = "0000"
            If Not v Is Nothing Then
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
            If Not v Is Nothing Then
                For Each row As DataRow In v.Rows
                    Dim phitype As String = row("phitype")
                    If (phitype.Equals(noonCard)) Then
                        Dim phitime As String = row("phitime")
                        Dim phitimeNumber As Integer = getNumberTime(phitime)
                        If ((phitimeNumber <= noonCardEndNumber) And (phitimeNumber >= noonCardBeginNumber)) Then
                            noonCard = phitime
                        End If
                    End If
                Next
            End If
            Return noonCard
        End Function

        Public Sub insertCpapkyymm(ByVal model As DataRow, ByVal currentDate As String, ByVal pkstime As String, ByVal pkntime As String, ByVal pketime As String, ByVal pkwktpe As String, ByVal pkworkh As Integer, ByVal pkforget As String)
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString() 'currentDate.Substring(1, 4)

            Dim pkupdate As String = FSCPLM.Logic.DateTimeInfo.GetRocTodayString("yyyyMMddHHmmss")

            Dim sql As String = String.Empty
            sql = "  insert into FSC_CPAPK" + yymm '+ " (PKIDNO,PKNAME,PKCARD,PKWDATE,PKSTIME,PKNTIME,PKETIME,PKWKTPE,PKWORK,PKCARDVER,PKFORGET,PKUSERID,PKUPDATE,PKREMARK) "
            sql &= " values(@PEIDNO,@PENAME,@PECARD,@CURRENTDATE,@PKSTIME,@PKNTIME,@PKETIME,@PKWKTPE,@PKWORK,'',@PKFORGET,'batch',@PKUPDATE,'') "

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
            Dim pkwktpe As String = String.Empty
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString() 'currentDate.Substring(1, 4)

            Dim sql As String = "select * from FSC_CPAPK" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params() As SqlParameter = {New SqlParameter("@PKIDNO", model("id_card").ToString()), New SqlParameter("@PKWDATE", currentDate)}
           
            Return Query(sql, params)
        End Function

        Public Sub deleteCpapkyymm(ByVal model As DataRow, ByVal currentDate As String)
            Dim yymm As String = Integer.Parse(currentDate.Substring(0, 5)).ToString()

            Dim sql As String = "delete FSC_CPAPK" + yymm + " where pkidno=@PKIDNO and pkwdate=@PKWDATE"
            Dim params() As SqlParameter = { _
                New SqlParameter("@PKIDNO", model("id_card").ToString()), _
                New SqlParameter("@PKWDATE", currentDate)}

            Execute(sql, params)

        End Sub

        Public Function getNumberTime(ByVal hhmm As String) As Integer '格式為hhmm
            Dim number As Integer = 0
            If Not hhmm Is Nothing AndAlso Not String.IsNullOrEmpty(hhmm) Then
                Dim hh As String = hhmm.Substring(0, 2)
                Dim mm As String = hhmm.Substring(2)
                number = Integer.Parse(hh) * 60 + Integer.Parse(mm)
            End If
            Return number
        End Function

        Public Function minuteToHour(ByVal number As Integer) As Integer
            Dim hour As Integer = 0
            hour = Fix(number / 60)
            Return hour
        End Function

        Public Sub doCpapkyymm(ByVal model As DataRow, ByVal currentDate As String, ByVal pkstime As String, ByVal pkntime As String, _
                                    ByVal pketime As String, ByVal PKWKTPE As String, ByVal pkworkh As Integer)

            Dim idCard As String = model("id_card").ToString()
            Dim cpapyyys As New FSC.Logic.CPAPYYYS(Mid(Me.currentDate, 1, 3))
            Dim column As String = "PYMON" & FSCPLM.Logic.DateTimeInfo.GetPublicDate(Me.currentDate).Month

            Dim pkdt As DataTable = getCpapkyymm(model, currentDate)

            If pkdt IsNot Nothing AndAlso pkdt.Rows.Count > 0 Then

                Dim origPKWKTPE As String = pkdt.Rows(0)("pkwktpe").ToString    '上下班狀態
                Dim origPKFORGET As String = pkdt.Rows(0)("pkforget").ToString  '忘刷卡註記

                If origPKWKTPE = "5" And PKWKTPE = "3" Then

                    If pkdt.Rows(0)("PKSTIME").ToString() = "9999" And pkdt.Rows(0)("PKETIME").ToString() = "0000" Then
                        deleteCpapkyymm(model, currentDate)
                        insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, origPKFORGET)
                    Else
                        Me.PKWKTPE = origPKWKTPE
                        Me.phitimeBegin = pkdt.Rows(0)("PKSTIME").ToString()
                        Me.phitimeEnd = pkdt.Rows(0)("PKETIME").ToString()
                        Me.totalHour = pkdt.Rows(0)("PKWORKH").ToString()
                    End If

                ElseIf origPKWKTPE <> "5" And origPKWKTPE <> "6" Then
                    '不是"已處理"及"正常"

                    deleteCpapkyymm(model, currentDate)
                    insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, origPKFORGET)

                    If PKWKTPE = "1" Then
                        '遲到
                        If PKWKTPE <> origPKWKTPE Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "51")
                        End If

                    ElseIf PKWKTPE = "2" Then
                        '早退
                        If PKWKTPE <> origPKWKTPE Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "52")
                        End If

                    ElseIf PKWKTPE = "3" Then
                        '曠職
                        If PKWKTPE <> origPKWKTPE Then
                            cpapyyys.UpdateDataByColumn(column, 1, idCard, "53")
                        End If

                    ElseIf PKWKTPE = "5" Or PKWKTPE = "6" Then

                        If origPKWKTPE = "1" Then
                            '遲到
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "51")
                        ElseIf origPKWKTPE = "2" Then
                            '早退
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "52")
                        ElseIf origPKWKTPE = "3" Then
                            '曠職
                            cpapyyys.UpdateDataByColumn(column, -1, idCard, "53")
                        End If

                    End If

                ElseIf (PKWKTPE = "5" Or PKWKTPE = "6") And (origPKWKTPE = "5" Or origPKWKTPE = "6") Then

                    If pkstime <> "9999" Or pketime <> "0000" Then
                        '原資料已處理或正常, 但有刷卡資料, 再次轉入
                        deleteCpapkyymm(model, currentDate)
                        insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, origPKFORGET)

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