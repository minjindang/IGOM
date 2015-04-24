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

        Private workTimeBegin As String = String.Empty '���`�Z�W�Z
        Private workTimeBeginNumber As Integer
        Private workTimeEnd As String = String.Empty '���`�Z�U�Z
        Private workTimeEndNumber As Integer
        Private workTimeHalfBegin As String = String.Empty '���`�Z�W�Z(�b��)
        Private workTimeHalfBeginNumber As Integer
        Private workTimeHalfEnd As String = String.Empty '���`�Z�U�Z(�b��)
        Private workTimeHalfEndNumber As Integer
        Private noonRestBegin As String = String.Empty '���ȥ𮧶}�l
        Private noonRestBeginNumber As Integer
        Private noonRestEnd As String = String.Empty '���ȥ𮧵���
        Private noonRestEndNumber As Integer
        '���ȥ𮧮ɶ�
        'Private noonRestHours As Integer
        'Private noonCardBegin As String = String.Empty '���ȥd��d�ɶ��}�l
        'Private noonCardBeginNumber As Integer
        'Private noonCardEnd As String = String.Empty '���ȥd��d�ɶ�����
        'Private noonCardEndNumber As Integer
        Private isNoonNeedCard As String = String.Empty '���Ȼݤ��ݭn��d 1:�n 2:���n

        Private workHours As Integer '���ѤW�Z�ܤ֤W�Z�ɼ�
        Private workHoursHalf As Integer '�b�ѤW�Z�ܤ֤W�Z�ɼ�

        Private pullOffTimeBegin As Integer '�W�Z�w�Įɶ�
        Private pullOffTimeEnd As Integer '�U�Z�w�Įɶ�

        Private beginWorkCard As String = "A" '�W�Z�dphitype
        Private endWorkCard As String = "D" '�U�Z�dphitype
        Private noonCard As String = "A" '���ȥdphitype


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


            'new �]�w�W�U�Z���ȥ𮧮ɶ�
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

                    '�W�U�Z�d���������p
                    If (Not phitimeBegin.Equals("9999")) And (Not phitimeEnd.Equals("0000")) Then

                        Dim phitimeBeginNumber As Integer = getNumberTime(phitimeBegin)
                        Dim phitimeEndNumber As Integer = getNumberTime(phitimeEnd)

                        '�վ�W�Z�w�Įɶ�
                        phitimeBeginNumber = phitimeBeginNumber - pullOffTimeBegin

                        '�վ�U�Z�w�Įɶ�
                        phitimeEndNumber = phitimeEndNumber + pullOffTimeEnd


                        '�W�U�Z�ɶ��p�G�W�L���Z�W�U�Z�_���I�A�h�վ�ɶ�
                        phitimeBeginNumber = Math.Max(phitimeBeginNumber, workTimeBeginNumber)
                        phitimeEndNumber = Math.Min(phitimeEndNumber, workTimeEndNumber)

                        '���`�W�Z
                        If phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber Then

                            totalHour = phitimeEndNumber - phitimeBeginNumber '- noonRestHours
                            totalHour = minuteToHour(totalHour)

                            '�N�����ഫ���p�ɼ�
                            If (totalHour > workHours) Then
                                totalHour = workHours
                            End If

                            '�W�U�Z���A���P�_�ܼ�(�w�]���`�G6)
                            PKWKTPE = "6"

                            '�p�G�ݭn�ꤤ�ȥd�A�h�P�_�O�_���ꤤ�ȥd
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


                        '���p�@ ���
                        '�W�Z�d�W�L�u�ʤW�Z�A�U�Z�d�j�󵥩�u�ʤU�Z
                        If (phitimeBeginNumber > workTimeBeginNumber And phitimeEndNumber >= workTimeEndNumber) Then

                            '�p�G�W�Z�d���ɶ��b���ȥ𮧥H�e���ܡA�W�Z�ɼƶ���ȥ𮧮ɼ�
                            'If (phitimeBeginNumber < noonRestBeginNumber) Then
                            '    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            '    '�W�Z�d���ɶ��b���ȥ𮧮ɶ�
                            'ElseIf (phitimeBeginNumber <= noonRestBeginNumber And phitimeBeginNumber >= noonRestEndNumber) Then
                            '    totalHour = phitimeEndNumber - noonRestEndNumber
                            'Else
                            totalHour = phitimeEndNumber - phitimeBeginNumber
                            'End If

                            totalHour = minuteToHour(totalHour)
                            '�N�����ഫ���p�ɼ�

                            '�W�U�Z���A���P�_�ܼ�(�w�]�w�B�z�G5)
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                PKWKTPE = "1"
                                Dim reason As String = "�z�b " + currentDate + " ����d��Ƭ����A�B�L�а��άO�X�t�O���C"
                                Dim errorType As String = "���"
                            End If

                            '�B�z���ȥd
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

                        '���h
                        If (phitimeBeginNumber <= workTimeBeginNumber And phitimeEndNumber < workTimeEndNumber) Then

                            '�p�G�U�Z�d���ɶ��b���ȥ𮧮ɶ��H�᪺�ܡA�W�Z�ɼƶ���@�p�ɡF�b���ȥ𮧮ɶ������A�h�Τ��ȥ𮧶}�l��@�U�Z�ɶ�
                            'If (phitimeEndNumber > noonRestEndNumber) Then
                            '    totalHour = phitimeEndNumber - phitimeBeginNumber - noonRestHours
                            'ElseIf (phitimeEndNumber <= noonRestEndNumber And phitimeEndNumber >= noonRestBeginNumber) Then
                            '    '�ݥΨ�u�ʯZ�b��U�Z�ɶ�
                            '    If (phitimeEndNumber > workTimeHalfEndNumber) Then
                            '        totalHour = workTimeHalfEndNumber - phitimeBeginNumber
                            '    Else
                            '        totalHour = phitimeEndNumber - phitimeBeginNumber
                            '    End If
                            'ElseIf (phitimeEndNumber < noonRestBeginNumber) Then
                            totalHour = phitimeEndNumber - phitimeBeginNumber
                            'End If
                            totalHour = minuteToHour(totalHour)
                            '�N�����ഫ���p�ɼ�

                            '�W�U�Z���A���P�_�ܼ�
                            PKWKTPE = "5"

                            If istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail) Then
                                PKWKTPE = "2"
                                Dim reason As String = "�z�b " + currentDate + " ����d��Ƭ����h�A�B�L�а��άO�X�t�O���C"
                                Dim errorType As String = "���h"
                            End If
                            '�B�z���ȥd
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

                        '��즭�h
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
                            '�N�����ഫ���p�ɼ�
                            '�W�U�Z���A���P�_�ܼ�
                            PKWKTPE = "5"

                            If (istransfer.HaveNoLeaveType124(model, currentDate, workHours - totalHour, reportDetail)) Then
                                PKWKTPE = "4"
                                Dim reason As String = "�z�b " + currentDate + " ����d��Ƭ����B���h�A�B�L�а��άO�X�t�O���C"
                                Dim errorType As String = "��즭�h"
                            End If

                            '�B�z���ȥd
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
                            '�S����W�Z�d

                            If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                                '��d���@�P
                                PKWKTPE = "0"
                            Else
                                PKWKTPE = "5"
                            End If

                        ElseIf (Not phitimeBegin.Equals("9999")) And phitimeEnd.Equals("0000") Then
                            '�S����U�Z�d

                            '�B�z���ȥd
                            If (isNoonNeedCard.Equals("1")) Then
                                pkntime = checkNoonCard()
                            End If

                            If (istransfer.HaveNoLeave(model, currentDate, workHours, reportDetail)) Then
                                '��d���@�P
                                PKWKTPE = "0"
                            Else
                                PKWKTPE = "5"
                            End If

                        End If

                        doCpapkyymm(model, currentDate, phitimeBegin, pkntime, phitimeEnd, PKWKTPE, totalHour)
                        normal = True

                    Else
                        '�L��d���, �m¾

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
                        '��Ĥ@���W�Z�d
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
                        '��̫�@���U�Z�d
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

        Public Function getNumberTime(ByVal hhmm As String) As Integer '�榡��hhmm
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

                Dim org_pkwktpe As String = pkdt.Rows(0)("pkwktpe").ToString    '�W�U�Z���A
                Dim org_pkforget As String = pkdt.Rows(0)("pkforget").ToString  '�Ѩ�d���O

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
                    '���O"�w�B�z"��"���`"

                    deleteCpapkyymm(model, currentDate)
                    insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, org_pkforget)

                    If PKWKTPE = "1" Then
                        '���
                        If PKWKTPE <> org_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "51")
                        End If

                    ElseIf PKWKTPE = "2" Then
                        '���h
                        If PKWKTPE <> org_pkwktpe Then
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "52")
                        End If

                    ElseIf PKWKTPE = "3" Then
                        '�m¾
                        If PKWKTPE <> org_pkwktpe Then
                            insertCpapi09m(model)
                            cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "53")
                        End If

                    ElseIf PKWKTPE = "5" Or PKWKTPE = "6" Then

                        If org_pkwktpe = "1" Then
                            '���
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "51")
                        ElseIf org_pkwktpe = "2" Then
                            '���h
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "52")
                        ElseIf org_pkwktpe = "3" Then
                            '�m¾
                            cpapyyys.UpdateDataByColumn(column, -1, model("peidno"), "53")
                        End If

                    End If

                End If

            Else

                insertCpapkyymm(model, currentDate, pkstime, pkntime, pketime, PKWKTPE, pkworkh, "")

                If PKWKTPE = "1" Then
                    '���
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "51")
                ElseIf PKWKTPE = "2" Then
                    '���h
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "52")
                ElseIf PKWKTPE = "3" Then
                    '�m¾
                    insertCpapi09m(model)
                    cpapyyys.UpdateDataByColumn(column, 1, model("peidno"), "53")
                End If

            End If


        End Sub

    End Class

End Namespace