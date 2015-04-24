Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class LeaveMain
        Private DAO As LeaveMainDAO

        Public Sub New()
            DAO = New LeaveMainDAO()
        End Sub


#Region "Property"
        Private _flowId As String
        Public Property FlowId() As String
            Get
                Return _flowId
            End Get
            Set(ByVal value As String)
                _flowId = value
            End Set
        End Property
        Private _orgcode As String
        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property
        Private _departId As String
        Public Property DepartId() As String
            Get
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property
        Private _idCard As String
        Public Property IdCard() As String
            Get
                Return _idCard
            End Get
            Set(ByVal value As String)
                _idCard = value
            End Set
        End Property
        Private _userName As String
        Public Property UserName() As String
            Get
                Return _userName
            End Get
            Set(ByVal value As String)
                _userName = value
            End Set
        End Property
        Private _leaveGroup As String
        Public Property LeaveGroup() As String
            Get
                Return _leaveGroup
            End Get
            Set(ByVal value As String)
                _leaveGroup = value
            End Set
        End Property
        Private _leaveNgroup As String
        Public Property LeaveNgroup() As String
            Get
                Return _leaveNgroup
            End Get
            Set(ByVal value As String)
                _leaveNgroup = value
            End Set
        End Property
        Private _leaveType As String
        Public Property LeaveType() As String
            Get
                Return _leaveType
            End Get
            Set(ByVal value As String)
                _leaveType = value
            End Set
        End Property
        Private _startDate As String
        Public Property StartDate() As String
            Get
                Return _startDate
            End Get
            Set(ByVal value As String)
                _startDate = value
            End Set
        End Property
        Private _startTime As String
        Public Property StartTime() As String
            Get
                Return _startTime
            End Get
            Set(ByVal value As String)
                _startTime = value
            End Set
        End Property
        Private _endDate As String
        Public Property EndDate() As String
            Get
                Return _endDate
            End Get
            Set(ByVal value As String)
                _endDate = value
            End Set
        End Property
        Private _endTime As String
        Public Property EndTime() As String
            Get
                Return _endTime
            End Get
            Set(ByVal value As String)
                _endTime = value
            End Set
        End Property
        Private _leaveHours As Double
        Public Property LeaveHours() As Double
            Get
                Return _leaveHours
            End Get
            Set(ByVal value As Double)
                _leaveHours = value
            End Set
        End Property
        Private _holidayDateb As String
        Public Property HolidayDateb() As String
            Get
                Return _holidayDateb
            End Get
            Set(ByVal value As String)
                _holidayDateb = value
            End Set
        End Property
        Private _holidayDatee As String
        Public Property HolidayDatee() As String
            Get
                Return _holidayDatee
            End Get
            Set(ByVal value As String)
                _holidayDatee = value
            End Set
        End Property
        Private _holidayTimeb As String
        Public Property HolidayTimeb() As String
            Get
                Return _holidayTimeb
            End Get
            Set(ByVal value As String)
                _holidayTimeb = value
            End Set
        End Property
        Private _holidayTimee As String
        Public Property HolidayTimee() As String
            Get
                Return _holidayTimee
            End Get
            Set(ByVal value As String)
                _holidayTimee = value
            End Set
        End Property
        Private _holidayHours As Double
        Public Property HolidayHours() As Double
            Get
                Return _holidayHours
            End Get
            Set(ByVal value As Double)
                _holidayHours = value
            End Set
        End Property
        Private _reason As String
        Public Property Reason() As String
            Get
                Return _reason
            End Get
            Set(ByVal value As String)
                _reason = value
            End Set
        End Property
        Private _occurDate As String
        Public Property OccurDate() As String
            Get
                Return _occurDate
            End Get
            Set(ByVal value As String)
                _occurDate = value
            End Set
        End Property
        Private _place As String
        Public Property Place() As String
            Get
                Return _place
            End Get
            Set(ByVal value As String)
                _place = value
            End Set
        End Property
        Private _target As String
        Public Property Target() As String
            Get
                Return _target
            End Get
            Set(ByVal value As String)
                _target = value
            End Set
        End Property
        Private _babyDays As String
        Public Property BabyDays() As String
            Get
                Return _babyDays
            End Get
            Set(ByVal value As String)
                _babyDays = value
            End Set
        End Property
        Private _retainFlag As String
        Public Property RetainFlag() As String
            Get
                Return _retainFlag
            End Get
            Set(ByVal value As String)
                _retainFlag = value
            End Set
        End Property
        Private _locationFlag As String
        Public Property LocationFlag() As String
            Get
                Return _locationFlag
            End Get
            Set(ByVal value As String)
                _locationFlag = value
            End Set
        End Property
        Private _chinaFlag As String
        Public Property ChinaFlag() As String
            Get
                Return _chinaFlag
            End Get
            Set(ByVal value As String)
                _chinaFlag = value
            End Set
        End Property
        Private _interTravelFlag As String
        Public Property InterTravelFlag() As String
            Get
                Return _interTravelFlag
            End Get
            Set(ByVal value As String)
                _interTravelFlag = value
            End Set
        End Property
        Private _healthCheckFlag As String
        Public Property HealthCheckFlag() As String
            Get
                Return _healthCheckFlag
            End Get
            Set(ByVal value As String)
                _healthCheckFlag = value
            End Set
        End Property
        Private _holidayOfficalFlag As String
        Public Property HolidayOfficalFlag() As String
            Get
                Return _holidayOfficalFlag
            End Get
            Set(ByVal value As String)
                _holidayOfficalFlag = value
            End Set
        End Property
        Private _classFlag As String
        Public Property ClassFlag() As String
            Get
                Return _classFlag
            End Get
            Set(ByVal value As String)
                _classFlag = value
            End Set
        End Property
        Private _overtimeFlag As String
        Public Property OvertimeFlag() As String
            Get
                Return _overtimeFlag
            End Get
            Set(ByVal value As String)
                _overtimeFlag = value
            End Set
        End Property
        Private _placeCity As String
        Public Property PlaceCity() As String
            Get
                Return _placeCity
            End Get
            Set(ByVal value As String)
                _placeCity = value
            End Set
        End Property
        Private _transport As String
        Public Property Transport() As String
            Get
                Return _transport
            End Get
            Set(ByVal value As String)
                _transport = value
            End Set
        End Property
        Private _transportDesc As String
        Public Property TransportDesc() As String
            Get
                Return _transportDesc
            End Get
            Set(ByVal value As String)
                _transportDesc = value
            End Set
        End Property
        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return Me._Change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Change_userid, value) = False) Then
                    Me._Change_userid = value
                End If
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property Change_date() As System.Nullable(Of Date)
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._Change_date.Equals(value) = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property
        Private _isToGoogleCalendar As String
        Public Property isToGoogleCalendar() As String
            Get
                Return _isToGoogleCalendar
            End Get
            Set(ByVal value As String)
                _isToGoogleCalendar = value
            End Set
        End Property
        Private _isCard As String
        Public Property isCard() As String
            Get
                Return _isCard
            End Get
            Set(ByVal value As String)
                _isCard = value
            End Set
        End Property
        Private _isOnlyLeave As String
        Public Property isOnlyLeave() As String
            Get
                Return _isOnlyLeave
            End Get
            Set(ByVal value As String)
                _isOnlyLeave = value
            End Set
        End Property
        Private _CheckType As String
        Public Property CheckType() As String
            Get
                Return _CheckType
            End Get
            Set(ByVal value As String)
                _CheckType = value
            End Set
        End Property
        Private _Project_code As String
        Public Property Project_code() As String
            Get
                Return _Project_code
            End Get
            Set(ByVal value As String)
                _Project_code = value
            End Set
        End Property
        Private _BossAgree_flag As String
        Public Property BossAgree_flag() As String
            Get
                Return _BossAgree_flag
            End Get
            Set(ByVal value As String)
                _BossAgree_flag = value
            End Set
        End Property

#End Region

        Public Function InsertLeaveMain() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function


        Public Function InsertLeaveMain(ByVal checkData As Boolean) As Boolean

            If checkData Then
                CheckBeforeInsert()
            End If

            Return DAO.InsertData(Me) = 1
        End Function

        Public Function DeleteLeaveMain() As Boolean
            Return DAO.DeleteData(Me) = 1
        End Function

        Public Function UpdateLeaveMain() As Boolean
            CheckBeforeInsert()
            Return DAO.UpdateData(Me) = 1
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetHaveHoursByDate(ByVal IdCard As String, ByVal leaveType As String, ByVal startDate As String) As Integer
            Dim hours As Integer = 0
            Dim yyymm As String = startDate.Substring(0, 3).ToString()

            If "24" = leaveType Then   '生理假
                yyymm = startDate.Substring(0, 5).ToString()
            End If

            Dim dt As DataTable = DAO.GetDataByYYYMM(IdCard, leaveType, yyymm)
            For Each dr As DataRow In dt.Rows
                hours += CommonFun.getInt(dr("leave_hours").ToString())
            Next
            Return hours
        End Function

        Public Function GetHaveHoursByOccurDate(ByVal idcard As String, ByVal employeeType As String, ByVal occurDate As String) As Integer
            Dim hours As Integer = 0
            Dim dt As DataTable = DAO.GetDataByOccurDate(idcard, employeeType, occurDate)
            For Each dr As DataRow In dt.Rows
                hours += CommonFun.getInt(dr("Leave_hours").ToString())     '已存在資料庫的時數
            Next
            Return hours
        End Function

        'Public Function GetType10LimitDays(ByVal employeeType As String, ByVal target As String) As Integer

        '    Dim limitDays As Integer = -1
        '    Dim code As New FSCPLM.Logic.SACode()

        '    '1.依 employeeType 取喪假代碼的 codeType
        '    Dim r As DataRow = code.GetRow("023", "022", employeeType)
        '    Dim codeType As String = ""

        '    If r IsNot Nothing Then
        '        codeType = r("code_remark1").ToString()
        '    End If

        '    If String.IsNullOrEmpty(codeType) Then
        '        codeType = "023"    '未設定以勞基法為準
        '    End If

        '    '2.依 codeType , target 取 喪假可請天數
        '    r = code.GetRow("023", codeType, target)
        '    If r IsNot Nothing AndAlso Not String.IsNullOrEmpty(r("code_desc2").ToString()) Then
        '        limitDays = r("code_desc2").ToString()
        '    End If


        '    Return limitDays
        'End Function

        Public Function GetSpecialimitDays(ByVal ls As FSC.Logic.LeaveSetting, ByVal LeaveType As String, ByVal target As Integer, ByVal babyDays As Integer) As Integer
            Dim code As Integer = IIf(LeaveType = "10", target, babyDays)

            Dim limitDays As Integer = -1
            Dim dt As DataTable = New FSC.Logic.LeaveSettingDetail().GetDataByMasterId(ls.id)
            For Each dr As DataRow In dt.Rows
                If CommonFun.getInt(dr("Detail_code_id")) = code Then
                    limitDays = CommonFun.getInt(dr("Limitdays").ToString())
                    Exit For
                End If
            Next

            Return limitDays
        End Function

        Public Function getInter_travel(ByVal id_card As String, ByVal ym As String) As Double
            Return DAO.getInter_travel(id_card, ym)
        End Function

        Public Function GetDataByYYYMM(ByVal idCard As String, ByVal leaveType As String, ByVal yyymm As String) As DataTable
            Return DAO.GetDataByYYYMM(idCard, leaveType, yyymm)
        End Function

        Public Function GetDataByYYYMM(ByVal idCard As String, ByVal leaveType As String, ByVal yyymm As String, ByVal Retain_flag As String) As DataTable
            Return DAO.GetDataByYYYMM(idCard, leaveType, yyymm, Retain_flag)
        End Function

        Public Function GetObjects(ByVal orgcode As String, ByVal flowId As String) As List(Of LeaveMain)
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)
            Return CommonFun.ConvertToList(Of LeaveMain)(dt)
        End Function

        Public Function updateGoogleCalendar() As Boolean
            Return DAO.UpdateGoogleCalendar(Me) = 1
        End Function

        Public Function getDataByProjectCode(ByVal Orgcode As String, ByVal id_card As String, ByVal Project_code As String) As DataTable
            Return DAO.getDataByProjectCode(Orgcode, id_card, Project_code)
        End Function

        Protected Sub CheckBeforeInsert()
            Dim msg As String = ""
            Dim leaveTable As String = New SYS.Logic.LeaveType().GetLeaveTable(Me.LeaveType)

            Select Case leaveTable
                Case SYS.Logic.LeaveType.LeaveTable.CPAPO15M
                    msg = CheckData15()

                Case SYS.Logic.LeaveType.LeaveTable.CPAPP16M
                    msg = CheckData16()

                Case SYS.Logic.LeaveType.LeaveTable.CPAPR18M
                    msg = CheckData18()

            End Select

            If Not String.IsNullOrEmpty(msg) Then
                Throw New FlowException(msg)
            End If
        End Sub

#Region "一般請假檢核"
        Protected Function CheckData15() As String

            If Me.LeaveHours = 0 Then
                Return "差假時數不可為0!"
            End If

            'If Not Me.LeaveType = "03" And String.IsNullOrEmpty(Me.Reason) Then
            If String.IsNullOrEmpty(Me.Reason) Then
                Return "事由為必填欄位!"
            End If

            Dim tmp_POREMARK As String = Me.Reason
            If Me.Reason.IndexOf("[出國請示]") > 0 Then
                Dim tmpLength As Integer = Me.Reason.IndexOf("[出國請示]") + "[出國請示]".Length
                tmp_POREMARK = Me.Reason.Substring(tmpLength, Me.Reason.Length - tmpLength)
            End If

            If "13" = Me.LeaveType Then
                Dim remark() As String = tmp_POREMARK.Split("，")

                '沒輸入
                If remark.Length = 2 Then

                Else
                    '有輸入
                    If remark(2).Length > 30 Then
                        Return "輸入事由請勿超出30個字"
                    End If
                End If

            Else
                If tmp_POREMARK.Length > 30 And Me.Reason.IndexOf("[赴大陸地區]所屬中央機關、直轄市、縣(市)政府或授權機關同意或核定") < 0 Then
                    Return "輸入事由請勿超出30個字"
                End If
            End If

            If Me.EndDate < Me.StartDate Then
                Return "申請日期起日不可大於迄日，請重新輸入!"
            Else
                If Me.EndDate = Me.StartDate Then
                    If Me.EndTime < Me.StartTime Then
                        Return "申請日期起日不可大於迄日，請重新輸入!"
                    End If
                End If
            End If

            Dim ddt As DataTable = DAO.GetDataByDateTime(Me.StartDate & Me.StartTime, Me.EndDate & Me.EndTime, Me.IdCard)
            If ddt.Rows.Count > 0 Then
                Dim ss As String = String.Empty
                For Each dr As DataRow In ddt.Rows
                    ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ",\n"
                Next
                ss = Mid(ss, 1, ss.Length - 3)
                Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重複申請!"
            End If

            If Me.LeaveType = "03" And Me.HolidayOfficalFlag = "1" Then
                Me.Reason = "#國民旅遊卡休假#" & Me.Reason
            End If

            If Me.LeaveType = "06" Then
                If Me.HealthCheckFlag = "1" Then
                    Me.Reason = "#健康檢查#" & Me.Reason
                End If
                If Me.ClassFlag = "1" Then
                    Me.Reason = "#奉(指)派上課#" & Me.Reason
                    Me.LeaveHours = Content.computeWorkHourIncludeHolidy(Me.StartDate, Me.EndDate, Me.StartTime, Me.EndTime, Me.IdCard)
                End If
            End If

            '要請隔年的休假
            '1.	前提：系統必須存在下年度的行事曆，才可申請下年度的休假。
            '2.	系統開放當年度12月15日之後，才能提出下年度休假申請。
            '3.	申請下年度的休假時，若請假的日期在2/1之後，則不允許送出申請，僅能申請1/1至1/31之間的休假。
            '4.	當請假日期（起日）為本年度日期，而請假日期（迄日）為下年度日期時，不允許送出申請，因為請假不可跨年度。
            Dim NowYear As String = Right("0" & Today.Year - 1911, 3)
            Dim NextYear As String = Right("0" & Today.Year - 1911 + 1, 3)
            Dim NowMMDD As String = Right("0" & Today.Month, 2) & Right("0" & Today.Day, 2)
            Dim isCrossYear As Boolean = False
            Dim pb02m As New FSC.Logic.CPAPB02M()
            Dim pd04m As New FSC.Logic.CPAPD04M()
            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(Me.IdCard)

            '昨天民國年日期
            Dim yest As String = DateTimeInfo.GetRocDate(Now.AddDays(-1))
            Dim leaveName As String = New SYS.Logic.LeaveType().GetLeaveName(Me.LeaveType)
            Dim limitDays As Double = -1
            Dim employeeType As String = psn.EmployeeType   '職務類別
            Dim PEKIND As String = psn.Pekind               '差勤組別
            Dim PESEX As String = psn.Pesex                 '性別
            Dim PEHDAY As String = psn.Pehday               '休假天數
            Dim PEHDAY2 As String = psn.Pehday2             '事假天數
            Dim PERDAY As String = psn.Perday
            Dim PERDAY1 As String = psn.Perday1
            Dim PERDAY2 As String = psn.Perday2
            Dim totalHours As Integer = 0

            If PESEX <> "0" AndAlso (Me.LeaveType = "09" Or Me.LeaveType = "13" Or Me.LeaveType = "21" Or Me.LeaveType = "24") Then
                '性別為“男性”而且又選擇「產假(09)」、「流產假(13)」、「產前假(21)」或「生理假(24)」
                Return "必須女性才能申請產假、生理假、產前假及流產假!"
            ElseIf PESEX <> "1" AndAlso Me.LeaveType = "22" Then
                '性別為"女性"而且又選擇「陪產假(22)」
                Return "必須男性才能申請陪產假!"
            End If

            '假別規則
            Dim ls As FSC.Logic.LeaveSetting = New FSC.Logic.LeaveSetting().GetObject(Me.Orgcode, PEKIND, Me.LeaveType, employeeType)

            '差假上限
            Dim pd04mdt As DataTable = pd04m.GetDataByQuery(PEKIND, employeeType, Me.LeaveType)
            If pd04mdt IsNot Nothing AndAlso pd04mdt.Rows.Count > 0 Then
                limitDays = CommonFun.getDouble(pd04mdt.Rows(0)("PDDAYS").ToString())
            End If

            If "" = Me.LeaveType Then
                If NextYear = Me.StartDate.Substring(0, 3) Or NextYear = Me.EndDate.Substring(0, 3) Then
                    isCrossYear = True
                    '1

                    Dim pb02mdt As DataTable = pb02m.getDataByYYY(NextYear)
                    If pb02mdt Is Nothing OrElse pb02mdt.Rows.Count <= 0 Then
                        Throw New FlowException("系統必須存在下年度的行事曆，才可申請下年度的休假!")
                    End If

                    '2
                    'If NowMMDD <= "1215" Then
                    '    Return "需12月15日之後，才能提出下年度休假申請!"
                    'End If

                    '4
                    If Me.StartDate.Substring(0, 3) <> Me.EndDate.Substring(0, 3) Then
                        Return "請假不可跨年度，請重新輸入!"
                    End If

                    '3
                    If Me.StartDate.Substring(0, 3) = NextYear Then
                        If Me.StartDate > (NextYear & "0131") Then
                            Return "僅能申請1/1至1/31之間的休假!"
                        End If
                    End If
                    If Me.EndDate.Substring(0, 3) = NextYear Then
                        If Me.EndDate > (NextYear & "0131") Then
                            Return "僅能申請1/1至1/31之間的休假!"
                        End If
                    End If
                End If
            End If



            If Me.LeaveType = "13" Or Me.LeaveType = "09" Then
                '13 流產假, 9 娩假

                If "4".Equals(employeeType) Or _
                    "9".Equals(employeeType) Or _
                    "A".Equals(employeeType) Then
                    Me.LeaveHours = Content.computeWorkHourIncludeHolidy(Me.StartDate, Me.EndDate, Me.StartTime, Me.EndTime, Me.IdCard)
                End If
            End If


            'hsien remark
            'If isCrossYear Then
            '    '(1)	若為正式人員、約聘僱人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
            '    '(2)	承(1)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。
            '    '(3)	若為臨時人員、技工、工友、駕駛、定期僱用、約用人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
            '    '(4)	承(3)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。

            '    '取 PEHYEAR, PEDAY
            '    Dim bll As New FSC3401()
            '    Dim baseDate As Date = DateTimeInfo.GetPublicDate(NextYear & "0101")

            '    Dim Join_sdate As String = String.Empty
            '    Dim Elected_officials_flag As String = String.Empty
            '    Dim vPEKIND As String = String.Empty
            '    Dim vPEMEMCOD As String = String.Empty

            '    Dim pdt As DataTable = psn.GetDataByIdCard(Me.Idcard)
            '    If pdt IsNot Nothing AndAlso pdt.Rows.Count > 0 Then
            '        Dim dr As DataRow = pdt.Rows(0)
            '        vPEKIND = dr("PEKIND").ToString()
            '        vPEMEMCOD = dr("PEMEMCOD").ToString()
            '    End If

            '    Dim fsc3401 As New FSC3401()
            '    Dim dt As DataTable
            '    dt = fsc3401.getQueryData(Orgcode, "", "", Me.Idcard, "", "", "", "", "", "1")
            '    If dt.Rows.Count > 0 Then
            '        Dim row As DataRow = dt.Rows(0)
            '        Elected_officials_flag = row("Elected_officials_flag").ToString()
            '        Join_sdate = row("join_sdate").ToString()
            '    End If

            '    Dim ht As Hashtable = bll.cntYearsDays(Orgcode, Me.Idcard, Join_sdate, Elected_officials_flag, vPEKIND, vPEMEMCOD, baseDate)
            '    If ht IsNot Nothing Then
            '        limitDays = CommonFun.getDouble(ht("PEHDAY").ToString())
            '    End If

            'End If


            If Me.LeaveType = "01" Or Me.LeaveType = "02" Or Me.LeaveType = "03" Or Me.LeaveType = "24" Or Me.LeaveType = "25" Or Me.LeaveType = "30" Or Me.LeaveType = "31" Then
                '事假, 病假, 休假,  生理假, 家庭照顧假, 前一年延休假, 前二年延休假
                '依年月統計假別目前總時數
                If totalHours = 0 Then
                    totalHours += GetHaveHoursByDate(Me.IdCard, Me.LeaveType, Me.StartDate)
                End If
                totalHours += Me.LeaveHours '再加上這次申請的時數

                If Me.LeaveType = "01" Then '事假 含 家庭照顧假
                    totalHours += GetHaveHoursByDate(Me.IdCard, "25", Me.StartDate)
                End If

                '事假含家庭照顧假超過上限, 家庭照顧假依然可以申請
                'If Me.leaveType = "25" Then   '家庭照顧假 含 事假
                '    totalHours += getHaveHoursByDate(Me.idCard, "01", me.StartDate, cpaDAO, DAO)
                'End If

                If Me.LeaveType = "02" Then   '病假 含 生理假
                    totalHours += GetHaveHoursByDate(Me.IdCard, "24", Me.StartDate)
                End If

                '病假含生理假超過上限, 生理假依然可以申請
                'If Me.leaveType = "24" Then   '生理假 含 病假
                '    totalHours += getHaveHoursByDate(Me.idCard, "02", me.StartDate, cpaDAO, DAO)
                'End If

                If Me.LeaveType = "03" Then '休假需判斷請休假別
                    Dim hours As Integer = 0
                    Dim yyymm As String = Me.StartDate.Substring(0, 3).ToString()

                    Dim dt As DataTable = DAO.GetDataByYYYMM(Me.IdCard, Me.LeaveType, yyymm, Me.RetainFlag)
                    For Each dr As DataRow In dt.Rows
                        hours += CommonFun.getInt(dr("leave_hours").ToString())
                    Next

                    totalHours = hours + Me.LeaveHours
                End If

            ElseIf Me.LeaveType = "08" Or Me.LeaveType = "10" Or Me.LeaveType = "22" Or Me.LeaveType = "13" Or Me.LeaveType = "09" Then
                '婚假, 喪假, 陪產假, 流產假, 娩假
                '依事實發生日統計假別目前總時數
                If totalHours = 0 Then
                    totalHours += GetHaveHoursByOccurDate(Me.IdCard, Me.LeaveType, Me.OccurDate)
                End If
                totalHours += Me.LeaveHours     '再加上這次申請的時數
            End If


            If ls IsNot Nothing Then

                '申請期限天數
                If ls.Limit <> 0 And Me.StartDate < DateTimeInfo.GetRocDate(Now) And Content.computeDaysIncludeHoliday(Me.StartDate, yest) > ls.Limit Then
                    Return leaveName & "需於差假日期後" & ls.Limit & "天內申請!"
                End If

                '申請期限
                If Not String.IsNullOrEmpty(ls.limit_date) AndAlso Me.StartDate > Left(Me.StartDate, 3) & ls.limit_date Then
                    Return leaveName & "已超過申請期限" & Left(Me.StartDate, 3) & "/" & Left(ls.limit_date, 2) & "/" & Right(ls.limit_date, 2)
                End If

                '請畢天數
                If ls.Reciprocal_days <> 0 andalso Me.BossAgree_flag <> "1" Then
                    Dim d As Date = DateTimeInfo.GetPublicDate(Me.OccurDate).AddDays(1)
                    If DateTimeInfo.GetPublicDate(Me.EndDate) > d.AddDays(ls.Reciprocal_days) Then
                        Return leaveName & "需於事實發生日後" & ls.Reciprocal_days & "天內請畢!"
                    End If
                End If

                '停止請假期間
                If Not String.IsNullOrEmpty(ls.Applystop_sdate) Then

                    If Me.StartDate & Me.StartTime <= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime >= ls.Applystop_edate & ls.Applystop_etime Then
                        Return leaveName & "於停止請假期間內!"
                    End If

                    If Me.StartDate & Me.StartTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return leaveName & "於停止請假期間內!"
                    End If

                    If Me.StartDate & Me.StartTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.StartDate & Me.StartTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return leaveName & "於停止請假期間內!"
                    End If

                    If Me.EndDate & Me.EndTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return leaveName & "於停止請假期間內!"
                    End If
                End If

                '最小單位時數
                If ls.Min_hour <> 0 Then
                    If Me.LeaveHours Mod ls.Min_hour <> 0 Then
                        Return leaveName & "需以" & ls.Min_hour & "小時為單位!"
                    End If
                End If

                '是否可分次申請
                If ls.Ifbatch_apply = "1" Then
                    '否
                    Dim dt As DataTable = DAO.GetDataByOccurDate(Me.IdCard, Me.LeaveType, Me.OccurDate)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Return leaveName & "應一次請畢，目前已有申請記錄!"
                    End If
                End If

                '是否含假日
                If ls.Ifholiday_flag = "0" Then

                End If

                '是否含事實發生日
                If ls.Ifoccur_date_flag = "0" Then
                    If String.IsNullOrEmpty(Me.OccurDate) Then
                        Return leaveName & "需填寫實事發生日!"
                    End If
                End If

                If Me.BossAgree_flag = "1" Then
                    Dim att As New SYS.Logic.Attachment()
                    Dim dt As DataTable = att.GetAttachByFlowId(Me.FlowId)
                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        Return leaveName & "勾選經長官核准需上傳附件!"
                    End If
                End If

                If ls.Ifmustattach_flag = "0" Then
                    If Content.ConvertDayHours(Me.LeaveHours) > ls.many_days Then
                        Dim att As New SYS.Logic.Attachment()
                        Dim dt As DataTable = att.GetAttachByFlowId(Me.FlowId)
                        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                            Return leaveName & "需上傳附件!"
                        End If
                    End If
                End If

            End If


            If Me.LeaveType = "01" Then
                '事假

                '依個人不同
                'If Not String.IsNullOrEmpty(PEHDAY2) And PEHDAY2 <> "0" Then
                '    limitDays = CommonFun.getDouble(PEHDAY2)
                'End If

                'If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                '    Return leaveName & "已超過可休上限(" & limitDays & "天)!"
                'End If

            ElseIf Me.LeaveType = "02" Then
                '病假

                'If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                '    Return leaveName & "已超過可休上限(" & limitDays & "天)!"
                'End If

            ElseIf Me.LeaveType = "03" Then
                '休假

                If Me.LeaveHours = 4 Then
                    If Me.StartDate <> Me.EndDate Then
                        Return leaveName & "4小時，起迄日期應該相同!"
                    End If
                End If

                '保留假
                If Me.RetainFlag = "0" And CommonFun.getDouble(PERDAY1) = 0 And CommonFun.getDouble(PERDAY2) = 0 Then
                    Return "無保留假可以申請!"
                End If

                Dim TotallimitDays As Integer = 0
                If Not isCrossYear Then
                    TotallimitDays = Content.ConvertDayHours(Content.ConvertToHours(CommonFun.getDouble(PEHDAY)) _
                                                        + Content.ConvertToHours(CommonFun.getDouble(PERDAY1)) _
                                                        + Content.ConvertToHours(CommonFun.getDouble(PERDAY2)))

                    If Me.RetainFlag = "0" Then '保留
                        limitDays = Content.ConvertDayHours(Content.ConvertToHours(CommonFun.getDouble(PERDAY1)) _
                                                            + Content.ConvertToHours(CommonFun.getDouble(PERDAY2)))
                    ElseIf Me.RetainFlag = "1" Then '今年
                        limitDays = Content.ConvertDayHours(Content.ConvertToHours(CommonFun.getDouble(PEHDAY)))
                    End If
                End If

                Dim PERDAY_HOURS As Integer = Content.ConvertToHours(CommonFun.getDouble(PERDAY))                   '擬保留日數
                Dim PEPAYDAYA_HOURS As Integer = 0 'Content.ConvertToHours(pe05dt.Rows(0)("PEPAYDAYA").ToString)    '擬請領日數

                'hsien 2010-12-28 
                Dim sett As New SettlementAnnualDAO()
                Dim dt As DataTable = sett.GetDataByIdcard(Orgcode, "", Me.IdCard, Me.StartDate.Substring(0, 3).ToString())
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    PEPAYDAYA_HOURS = Content.ConvertToHours(CommonFun.getDouble(dt.Rows(0)("pay_days").ToString()))
                End If
                'hsien 2010-12-28

                Dim limit_PP As Integer = (Content.ConvertToHours(TotallimitDays) - PERDAY_HOURS - PEPAYDAYA_HOURS)

                If totalHours > limit_PP And (PERDAY_HOURS <> 0 Or PEPAYDAYA_HOURS <> 0) Then
                    Return "已超過保留至本年底休假日數!"
                End If

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "已超過可休上限(" & limitDays & "天)!"
                End If

                If Me.InterTravelFlag = "1" Then
                    Dim Inter_travel_hours As Double = New LeaveMain().getInter_travel(Me.IdCard, (Now.Year - 1911).ToString())
                    Inter_travel_hours += Me.LeaveHours

                    If Content.ConvertDayHours(Inter_travel_hours) > 14 Then
                        Return "國民旅遊卡休假已超過14天!"
                    End If
                End If

            ElseIf Me.LeaveType = "04" Then
                '加班假

            ElseIf Me.LeaveType = "06" Then
                '公假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then

                Else
                    If "4".Equals(employeeType) Then
                        Return "臨時人員不可自行申請" & leaveName
                    End If
                End If

                If Me.OccurDate > Me.StartDate Then
                    Return "事實發生日不可小於請假日期!"
                End If


            ElseIf Me.LeaveType = "08" Then
                '婚假

                If Me.LeaveHours = 4 Then
                    If Me.StartDate <> Me.EndDate Then
                        Return leaveName & "4小時，起迄日期應該相同!"
                    End If
                End If

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "您申請的婚假天數已超過可請天數" & limitDays & "天!"
                End If


            ElseIf Me.LeaveType = "09" Then
                '娩假

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "只能申請" & limitDays & "天!"
                End If

                Dim dt As DataTable = DAO.GetApplyData(Me.IdCard, Me.LeaveType)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Return "已有審核中的娩假申請!"
                End If

            ElseIf Me.LeaveType = "10" Then
                '喪假

                If Me.LeaveHours = 4 Then
                    If Me.StartDate <> Me.EndDate Then
                        Return leaveName & "4小時，起迄日期應該相同!"
                    End If
                End If

                If String.IsNullOrEmpty(Me.Target) Then
                    Return "未選擇喪假對象!"
                End If

                If String.IsNullOrEmpty(Me.OccurDate) Then
                    Return "事實發生日不可空白!"
                Else
                    If OccurDate > FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd") Then
                        Return "事實發生日不可為未來日!"
                    End If

                    If OccurDate > Me.StartDate Then
                        Return leaveName & "請假日期不可早於事實發生日!"
                    End If
                End If

                Dim cdt As DataTable = DAO.GetDataByOccurDate(Me.IdCard, Me.LeaveType, Me.OccurDate)
                For Each dr As DataRow In cdt.Rows
                    If dr("Target") <> Me.Target Then
                        Return "事實發生日與喪假對象不符!"
                    End If
                Next

                Dim target As Integer = CommonFun.getInt(Me.Target)

                'hsien 20120927
                'limitDays = GetType10LimitDays(employeeType, target)
                limitDays = GetSpecialimitDays(ls, Me.LeaveType, CommonFun.getInt(Me.Target), 0)

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "您申請的喪假天數已超過可請天數" & limitDays & "天!"
                End If


            ElseIf Me.LeaveType = "13" Then
                '流產假
                'limitDays = Me.BabyDays

                If String.IsNullOrEmpty(Me.OccurDate) Then
                    Return "事實發生日不可空白!"
                Else
                    If OccurDate > FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd") Then
                        Return "事實發生日不可為未來日!"
                    End If
                End If

                If OccurDate > Me.StartDate Then
                    Return leaveName & "請假日期不可早於事實發生日!"
                End If

                Dim dt As DataTable = DAO.GetDataByOccurDate(Me.IdCard, Me.LeaveType, Me.OccurDate)
                If dt.Rows.Count > 0 Then
                    Return leaveName & "應一次請畢，目前已有申請記錄!"
                End If

                limitDays = GetSpecialimitDays(ls, Me.LeaveType, 0, CommonFun.getInt(Me.BabyDays))

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "只能申請" & limitDays & "天!"
                End If

            ElseIf Me.LeaveType = "15" Then
                '公傷假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then
                Else
                    Return "同仁不可自行申請" & leaveName
                End If

            ElseIf Me.LeaveType = "16" Then
                '延長病假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then
                Else
                    Return "同仁不可自行申請" & leaveName
                End If

            ElseIf Me.LeaveType = "18" Then
                '天災假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then
                Else
                    Return "同仁不可自行申請" & leaveName
                End If

            ElseIf Me.LeaveType = "19" Then
                '其他假


            ElseIf Me.LeaveType = "20" Then
                '出差補假


            ElseIf Me.LeaveType = "21" Then
                '產前假


                If limitDays >= 0 And Me.LeaveHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "只能申請" & limitDays & "天!"
                End If

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then

                Else
                    If "4".Equals(employeeType) Then
                        Return "臨時人員不可自行申請" & leaveName
                    End If
                End If

            ElseIf Me.LeaveType = "22" Then
                '陪產假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then

                Else
                    If "4".Equals(employeeType) Then
                        Return "臨時人員不可自行申請" & leaveName
                    End If
                End If

                If Me.LeaveHours = 4 Then
                    If Me.StartDate <> Me.EndDate Then
                        Return leaveName & "4小時，起迄日期應該相同!"
                    End If
                End If

                Dim days As Integer = 0
                Dim dayLimit As Integer = 2

                If Me.OccurDate < Me.StartDate Then    '事實發生日 小於 開始日期
                    days = Content.computeDays(Me.IdCard, Me.OccurDate, Me.StartDate)
                End If
                If days > dayLimit Then
                    Return leaveName & "需於生產前後" & dayLimit.ToString() & "天內必須申請!"
                End If

                If Me.OccurDate > Me.StartDate Then    '事實發生日 大於 開始日期
                    days = Content.computeDays(Me.IdCard, Me.StartDate, Me.OccurDate)
                End If
                If days > dayLimit Then
                    Return leaveName & "需於生產前後" & dayLimit.ToString() & "天內必須申請!"
                End If

                If Me.OccurDate < Me.EndDate Then    '事實發生日 小於 結束日期
                    days = Content.computeDays(Me.IdCard, Me.OccurDate, Me.EndDate)
                End If
                If days > dayLimit Then
                    Return leaveName & "需於生產前後" & dayLimit.ToString() & "天內必須申請!"
                End If

                If Me.OccurDate > Me.EndDate Then    '事實發生日 大於 結束日期
                    days = Content.computeDays(Me.IdCard, Me.EndDate, Me.OccurDate)
                End If
                If days > dayLimit Then
                    Return leaveName & "需於生產前後" & dayLimit.ToString() & "天內必須申請!"
                End If

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "只能申請" & limitDays & "天!"
                End If

            ElseIf Me.LeaveType = "23" Then
                '器官捐贈假

                Dim account_roleid As String = psn.GetColumnValue("Role_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                If account_roleid = "Personnel" Or account_roleid = "TWDAdmin" Or account_roleid = "GenServAdmin" Then
                Else
                    Return "同仁不可自行申請" & leaveName
                End If

            ElseIf Me.LeaveType = "24" Then
                '生理假

                If Me.StartDate <> Me.EndDate Then
                    Return leaveName & "每次只能申請1天!"
                End If

                'Limitdays = 8

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "每月只能請" & limitDays & "天!"
                End If

                Dim dt As DataTable = DAO.GetApplyData(Me.IdCard, Me.LeaveType)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Return "您本月已有申請生理假，不可重複申請!"
                End If

            ElseIf Me.LeaveType = "25" Then
                '家庭照顧假


                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "每年最多" & limitDays & "天!"
                End If

            ElseIf Me.LeaveType = "27" Then
                '連續假日出國請示
                If Not Content.checkIsHoliday(Me.StartDate, Me.EndDate) Then
                    Return leaveName & "差假期間必須為假日!"
                End If

            ElseIf Me.LeaveType = "28" Then
                '原住民歲時祭儀假

                Dim Indigenous_flag As String = psn.GetColumnValue("Indigenous_flag", Me.IdCard)

                If Not "Y".Equals(Indigenous_flag) Then
                    Return leaveName & "申請人身份必需為原住民!"
                End If

            ElseIf Me.LeaveType = "30" Or Me.LeaveType = "31" Then
                'by jessica modi 1030102 POVTYPE = "30"為暑休
                ''前一年延休假
                'Limitdays = PERDAY1

                Dim pc03m As New FSC.Logic.CPAPC03M()
                '要檢查請假期間是否為暑休期間
                Dim PCCODE As String = IIf(Me.LeaveType = "30", "17", "18")
                Dim SummerSD As String = pc03m.GetPCPARM1(PEKIND, "worktime", PCCODE)
                Dim SummerED As String = pc03m.GetPCPARM2(PEKIND, "worktime", PCCODE)
                If Me.StartDate.Substring(3, 4) < SummerSD Or Me.EndDate.Substring(3, 4) > SummerED Then
                    Return leaveName & "請假時間非" & IIf(Me.LeaveType = "30", "暑", "寒") & "休期間!"
                End If

                '再檢查是否超過可休上限天數
                Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, Me.LeaveType)
                If dt.Rows.Count > 0 Then
                    limitDays = dt.Rows(0)("PDDAYS").ToString()
                End If

                If limitDays >= 0 And totalHours > Content.ConvertToHours(limitDays) Then
                    Return leaveName & "已超過可休上限(" & limitDays & "天)!"
                End If

                'ElseIf Me.leaveType = "31" Then
                'by jessica modi 1030102 POVTYPE = "31"為寒休
                ''前二年延休假
                'Limitdays = PERDAY2

                'If Limitdays >= 0 And totalHours > Content.ConvertToHours(Limitdays) Then
                '    Return leave_name & "已超過可休上限(" & Limitdays & "天)!"
                'End If
            ElseIf Me.LeaveType = "34" Then '五一勞動節
                If Not employeeType.Equals("3") AndAlso Not employeeType.Equals("4") AndAlso Not employeeType.Equals("8") AndAlso _
                   Not employeeType.Equals("10") AndAlso Not employeeType.Equals("12") Then
                    Return "非技工工友、臨時人員、司機、特約人員、臨時工不可申請五一勞動節!"
                End If
                If Me.StartDate < Left(Me.StartDate, 3) & "0501" Then
                    Return "五一勞動節只能申請5/1之後的日期!"
                End If
                If psn.Act_date > Left(Me.StartDate, 3) & "0501" Then
                    Return "不可申請尚未到職之五一勞動節!"
                End If

                totalHours = GetHaveHoursByDate(Me.IdCard, Me.LeaveType, Me.StartDate)
                totalHours += Me.LeaveHours

                If Me.StartDate <> Me.EndDate Or totalHours > 8 Then
                    Return "五一勞動節只能申請一天!"
                End If
            End If

            Return String.Empty
        End Function
#End Region

#Region "公差/出檢核"
        Protected Function CheckData16() As String
            If String.IsNullOrEmpty(Me.Reason) Then
                Return "事由為必填欄位!"
            End If

            If Me.LeaveHours = 0 Then
                Return "公出差時數不可為0"
            End If

            If Me.HolidayOfficalFlag = "1" Then
                Dim hdb As Date = DateTimeInfo.GetPublicDate(Me.HolidayDateb & Me.HolidayTimeb)
                Dim hde As Date = DateTimeInfo.GetPublicDate(Me.HolidayDatee & Me.HolidayTimee)

                Dim pb02m As New FSC.Logic.CPAPB02M()

                Dim hasHoliday As Boolean = False
                Dim offday As Boolean = False
                Do
                    Dim PBDDATE As String = (hdb.Year - 1911).ToString().PadLeft(3, "0") & hdb.ToString("MMdd")

                    Dim ht As Hashtable = Content.GetWorkTime(Me.IdCard, PBDDATE)
                    If ht IsNot Nothing AndAlso ht.Count > 0 Then
                        offday = CType(ht.Item("OFFDAY"), Boolean)
                    End If

                    If offday Then
                        hasHoliday = True
                    End If
                    If hdb.Date = hde.Date Then Exit Do
                    hdb = hdb.AddDays(1)
                Loop
                If Not hasHoliday Then
                    Return "假日執行公務起迄日期內無假日!不可指定為假日執行公務!"
                End If
            End If

            Dim ddt As DataTable = DAO.GetDataByDateTime(Me.StartDate & Me.StartTime, Me.EndDate & Me.EndTime, Me.IdCard)
            If ddt.Rows.Count > 0 Then
                Dim ss As String = String.Empty
                For Each dr As DataRow In ddt.Rows
                    ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ",\n"
                Next
                ss = Mid(ss, 1, ss.Length - 3)
                Return "您於公出差日期期間已申請其它差假\n(" & ss & ")，\n不可重複申請!"
            End If

            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(Me.IdCard)
            Dim employeeType As String = psn.EmployeeType   '職務類別
            Dim PEKIND As String = psn.Pekind               '差勤組別
            Dim yest As String = DateTimeInfo.GetRocDate(Now.AddDays(-1))             '昨天民國年日期
            '假別規則
            Dim ls As FSC.Logic.LeaveSetting = New FSC.Logic.LeaveSetting().GetObject(Me.Orgcode, PEKIND, Me.LeaveType, employeeType)

            If ls IsNot Nothing Then
                '申請期限天數
                If ls.Limit <> 0 And Me.StartDate < DateTimeInfo.GetRocDate(Now) And Content.computeDaysIncludeHoliday(Me.StartDate, yest) > ls.Limit Then
                    Return "公差需於公差日後" & ls.Limit & "天內申請!"
                End If

                '停止公差期間
                If Not String.IsNullOrEmpty(ls.Applystop_sdate) Then

                    If Me.StartDate & Me.StartTime <= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime >= ls.Applystop_edate & ls.Applystop_etime Then
                        Return "公差於停止公差期間內!"
                    End If

                    If Me.StartDate & Me.StartTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return "公差於停止公差期間內!"
                    End If

                    If Me.StartDate & Me.StartTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.StartDate & Me.StartTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return "公差於停止公差期間內!"
                    End If

                    If Me.EndDate & Me.EndTime >= ls.Applystop_sdate & ls.Applystop_stime And Me.EndDate & Me.EndTime <= ls.Applystop_edate & ls.Applystop_etime Then
                        Return "公差於停止公差期間內!"
                    End If
                End If

                If ls.Ifmustattach_flag = "0" Then
                    Dim att As New SYS.Logic.Attachment()
                    Dim dt As DataTable = att.GetAttachByFlowId(Me.FlowId)
                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        Return "申請公差需上傳附件!"
                    End If
                End If
            End If

            Return String.Empty
        End Function
#End Region

#Region "加班/專案加班檢核"
        Public Function CheckData18() As String
            If String.IsNullOrEmpty(Me.Reason) Then
                Return "事由為必填欄位!"
            End If

            If Me.StartTime > Me.EndTime Then
                Return "加班起時不可大於加班迄時!"
            End If

            If Me.LeaveHours < 1 Then
                Return "加班時數不可小於1個小時!"
            End If

            '加班申請時間不能超過加班日隔天中午十二點!(遇假日順延) 
            Dim worktimeb As String = "0000"
            Dim worktimee As String = "0000"
            Dim noontimeb As String = "0000"
            Dim noontimee As String = "0000"
            Dim offday As Boolean = False

            Dim ht As Hashtable = Content.GetWorkTime(Me.IdCard, Me.StartDate)
            If ht IsNot Nothing AndAlso ht.Count > 0 Then
                worktimeb = ht("WORKTIMEB").ToString()
                worktimee = ht("WORKTIMEE").ToString()
                noontimeb = ht("NOONTIMEB").ToString()
                noontimee = ht("NOONTIMEE").ToString()
                offday = CType(ht("OFFDAY").ToString(), Boolean)
            End If

            If Not offday Then
                '判斷加班時間是否為非上班時間

                'hsien 20120807
                If Me.StartTime < worktimeb And Me.EndTime > worktimeb Then
                    Return Me.UserName & "的加班時間必需為非上班時間!"
                End If

                'hsien 20120807
                If Me.StartTime < worktimee And Me.EndTime > worktimee Then
                    Return Me.UserName & "的加班時間必需為非上班時間!"
                End If

                'hsien 20120905 庶務科科長及考訓科科長都同意中午能開放同仁加班，所以系統要開放1200:1330能加班
                If Me.StartTime >= worktimeb And Me.EndTime <= worktimee Then
                    If Me.StartTime < noontimeb And Me.EndTime > noontimeb Then
                        Return Me.UserName & "的加班時間必需為非上班時間!"
                    End If
                    If Me.StartTime < noontimee And Me.EndTime > noontimee Then
                        Return Me.UserName & "的加班時間必需為非上班時間!"
                    End If
                End If

                If noontimeb = noontimee Then
                    If (Me.StartTime = worktimeb And Me.EndTime = worktimee) Or _
                        (Me.StartTime < worktimeb And Me.EndTime > worktimeb) Or _
                        (Me.StartTime < worktimee And Me.EndTime > worktimee) Then
                        Return Me.UserName & "的加班時間必需為非上班時間!"
                    End If
                End If

                'Elbert 20130607 增加上班起至中午起 及 中午迄至下班起不可加班的檢核
                If Me.StartTime >= worktimeb And Me.EndTime <= noontimeb Then
                    Return Me.UserName & "的加班時間必需為非上班時間!"
                End If

                If Me.StartTime >= noontimee And Me.EndTime <= worktimee Then
                    Return Me.UserName & "的加班時間必需為非上班時間!"
                End If
            Else
                '非上班時間

            End If

            Dim leaveName As String = New SYS.Logic.LeaveType().GetLeaveName(Me.LeaveType)
            Dim pc03m As New FSC.Logic.CPAPC03M()
            Dim dayLimit As Integer = 0         '日上限
            Dim monthLimit As Integer = 0       '月上限

            Dim daySumHours As Integer = 0          '日加班的總數
            Dim monthSumHours As Integer = 0        '月加班的總數

            daySumHours += CommonFun.getInt(DAO.GetSumLeaveHoursByYM(Me.IdCard, Me.StartDate, Me.LeaveType))
            monthSumHours += CommonFun.getInt(DAO.GetSumLeaveHoursByYM(Me.IdCard, Me.StartDate.Substring(0, 5), Me.LeaveType))

            Dim employeeType As String = New FSC.Logic.Personnel().GetColumnValue("employee_Type", IdCard)
            Dim PEKIND As String = New FSC.Logic.Personnel().GetColumnValue("PEKIND", IdCard)

            '每日加班時數上限
            dayLimit = CommonFun.getInt(pc03m.GetPCPARM1(PEKIND, "limit", "2"))
            Dim X As Integer = CommonFun.getInt(pc03m.GetPCPARM1(PEKIND, "limit", "3"))

            If Me.LeaveType = "80" Then
                '一般加班
                monthLimit = 20

                If dayLimit > 0 Then
                    If daySumHours + Me.LeaveHours > Integer.Parse(dayLimit) Then
                        Return "已超過每日加班上限!"
                    End If
                End If

                'hsien 20140727 檢核是否有公差紀錄
                Dim dt As DataTable = DAO.GetDataByLeaveType(Me.IdCard, Me.StartDate & Me.StartTime, "05")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Return "該時段已有公差紀錄!"
                End If


            ElseIf Me.LeaveType = "82" Then
                '專案加班
                monthLimit = X - 20

                Dim por As New FSC.Logic.ProjectOvertimeRule()
                Dim pordt As DataTable = por.GetDataByDate(Me.Orgcode, Me.DepartId, Me.IdCard, Me.StartDate)

                If pordt IsNot Nothing AndAlso pordt.Rows.Count > 0 Then
                    monthLimit = CommonFun.getInt(pordt.Rows(0)("MonOT_hr").ToString())
                Else
                    'Return Me.UserName & "沒有在申請專案加班人員檔內!"
                    Return "您所申請的專案加班日期，不在專簽加班的期間，不可以申請專案加班!"
                End If


                'hsien 20140727 檢核是否有公差紀錄
                Dim dt As DataTable = DAO.GetDataByLeaveType(Me.IdCard, Me.StartDate & Me.StartTime, "05")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Dim b As Boolean = False
                    pordt = por.getDataByCode(Me.Orgcode, Me.DepartId, Me.IdCard, Me.StartDate & Me.StartTime, Me.Project_code)
                    For Each pordr As DataRow In pordt.Rows
                        If pordr("Project_kind").ToString() = "E" Then  '公差加班
                            b = True
                        End If
                    Next
                    If Not b Then
                        Return "專案加班類型不為公差加班"
                    End If
                End If

            End If

            If monthSumHours + Me.LeaveHours > monthLimit Then
                Return leaveName & "已超過加班上限" & monthLimit & "小時!"
            End If

            Dim ddt As DataTable = DAO.GetOvertimeDataByDateTime(Me.StartDate & Me.StartTime, Me.EndDate & Me.EndTime, Me.IdCard)
            If ddt.Rows.Count > 0 Then
                Dim ss As String = String.Empty
                For Each dr As DataRow In ddt.Rows
                    ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ",\n"
                Next
                ss = Mid(ss, 1, ss.Length - 3)
                Return "已有該時段的加班記錄!"
            End If

            Return String.Empty
        End Function
#End Region

    End Class
End Namespace