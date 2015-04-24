Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class ForgotClockApply
        Public dao As ForgotClockApplyDAO


#Region "Property"
        Private _Flow_id As String                  ' 流程代碼
        Private _Orgcode As String                  ' 機關代號
        Private _Depart_id As String                ' 申請人單位 
        Private _Apply_idcard As String             ' 申請人
        Private _Apply_name As String               ' 申請人位置代碼 
        Private _Apply_posid As String
        Private _Forgot_date As String              ' 起始時間
        Private _Forgot_time As String              ' 起始時間
        Private _Case_status As Integer
        Private _Card_type As String
        Private _Reason As String
        Private _Change_userid As String            ' 加班種類
        Private _Change_date As Date = Now          ' 撤銷假單表單編號

        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property
        ''' <summary>
        ''' 機關代號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        ''' <summary>
        ''' 申請人單位
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        ''' <summary>
        ''' 請假人身分證字號:FK_Member.ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_idcard() As String
            Get
                Return _Apply_idcard
            End Get
            Set(ByVal value As String)
                _Apply_idcard = value
            End Set
        End Property

        Public Property Apply_posid() As String
            Get
                Return _Apply_posid
            End Get
            Set(ByVal value As String)
                _Apply_posid = value
            End Set
        End Property

        ''' <summary>
        ''' 申請人位置代碼:FK_Position.Posid
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_name() As String
            Get
                Return _Apply_name
            End Get
            Set(ByVal value As String)
                _Apply_name = value
            End Set
        End Property
        ''' <summary>
        ''' 起始時間
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Forgot_date() As String
            Get
                Return _Forgot_date
            End Get
            Set(ByVal value As String)
                _Forgot_date = value
            End Set
        End Property
        ''' <summary>
        ''' 起始時間
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Forgot_time() As String
            Get
                Return _Forgot_time
            End Get
            Set(ByVal value As String)
                _Forgot_time = value
            End Set
        End Property
        ''' <summary>
        ''' 卡別 1:上班卡 2:下班卡
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Card_type() As String
            Get
                Return _Card_type
            End Get
            Set(ByVal value As String)
                _Card_type = value
            End Set
        End Property

        ''' <summary>
        ''' 事由
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Reason() As String
            Get
                Return _Reason
            End Get
            Set(ByVal value As String)
                _Reason = value
            End Set
        End Property
        Public Property Case_status() As Integer
            Get
                Return _Case_status
            End Get
            Set(ByVal value As Integer)
                _Case_status = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            dao = New ForgotClockApplyDAO
        End Sub


        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Return dao.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetObjects(orgcode As String, flowId As String) As List(Of ForgotClockApply)
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)
            Return CommonFun.ConvertToList(Of ForgotClockApply)(dt)
        End Function

        Public Function GetForgotClockApplyByFlow_id(ByVal Flow_id As String) As DataTable
            Return dao.GetDataByFlow_id(Flow_id)
        End Function

        Public Function CheckInserData() As String

            'Dim pkym As New CPAPKYYMM(Integer.Parse(Me.Forgot_Date.Substring(0, 5)).ToString(), p2kConn)

            'If Not pkym.HasTable Then
            '    Return "無員工每日出勤紀錄資料檔!"
            'End If


            'Dim nowdate As String = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMdd")

            'If Me.Forgot_Date > nowdate Then
            '    Return "不可申請未來時間的忘帶刷卡證!"
            'End If

            ''忘刷卡申請期限日期 (遇假日順延) 

            'Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            'Dim dt As DataTable = New ForgetClockSetting().GetForgetclockSettingByOrgcode(Orgcode)

            'If dt.Rows.Count <= 0 Then Return String.Empty

            'Dim Unlimited_time As String = dt.Rows(0)("Unlimited_time").ToString()
            'Dim Year_time As String = dt.Rows(0)("Year_time").ToString()
            'Dim Month_time As String = dt.Rows(0)("Month_time").ToString()

            'If Unlimited_time <> "1" Then Return String.Empty

            'Dim forgot_year As Integer = dao.GetCountByYear(Me.Apply_id, Mid(Me.Forgot_Date, 1, 3))
            'Dim forgot_month As Integer = dao.GetCountByMonth(Me.Apply_id, Mid(Me.Forgot_Date, 1, 5))
            'Dim cnt As Integer = dao.GetDataCardTypeByApply_id(Me.Apply_id, Me.Forgot_Date, Me.Card_type)
            'If cnt > 0 Then
            '    Return "你已重覆申請。"
            'End If

            'If Integer.Parse(Year_time) <> 0 And Integer.Parse(Year_time) <= forgot_year Then
            '    Return "你的忘帶刷卡證次數已超過上限。"
            'End If

            'If Integer.Parse(Month_time) <> 0 And Integer.Parse(Month_time) <= forgot_month Then
            '    Return "你的忘帶刷卡證次數已超過上限。"
            'End If

            '' 預設 部份org無須 時間判斷
            'Dim SysName As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
            'If (SysName.ToLower().Contains("nuk")) Then

            'Else

            '    Dim isNormal As Boolean = False
            '    Dim cpadb As String = ConfigurationManager.AppSettings(Orgcode).ToString().Split(",")(0)
            '    Dim FSC3603 As New FSC3603()
            '    dt = FSC3603.getDataByDate(cpadb, Orgcode, Depart_id, "", Apply_id, "", Forgot_Date)
            '    Dim hhmmss As String = Now().ToString("HHmmss")
            '    Dim yyymmdd As String = DateTimeInfo.GetRocDate(Now)
            '    If dt.Rows.Count <= 0 Then
            '        isNormal = True
            '    Else
            '        Dim schedule_id As String = dt.Rows(0)("schedule_id").ToString()
            '        Dim schedule As New Schedule()
            '        If "" = schedule_id Or String.IsNullOrEmpty(schedule_id) Then
            '            isNormal = True
            '        Else
            '            dt = schedule.GetDataById(schedule_id)
            '            If dt.Rows.Count <= 0 Then
            '                isNormal = True
            '            Else
            '                Dim _Start_time As String = dt.Rows(0)("Start_time").ToString()
            '                Dim _End_time As String = dt.Rows(0)("End_time").ToString()
            '                Dim _Noon_stime As String = dt.Rows(0)("Noon_stime").ToString()
            '                Dim _Nonn_etime As String = dt.Rows(0)("Noon_etime").ToString()
            '                Dim _Nooncard_stime As String = dt.Rows(0)("Nooncard_stime").ToString()
            '                Dim _Nooncard_etime As String = dt.Rows(0)("Nooncard_etime").ToString()

            '                If "" = _Start_time Or String.IsNullOrEmpty(_Start_time) Then
            '                    _Start_time = "0800"
            '                End If
            '                If "" = _End_time Or String.IsNullOrEmpty(_End_time) Then
            '                    _End_time = "1730"
            '                End If
            '                If "" = _Nooncard_stime Or String.IsNullOrEmpty(_Nooncard_stime) Then
            '                    _Nooncard_stime = "1300"
            '                End If

            '                '排班忘刷卡的規則()
            '                '在上班時間起的前20分鐘至上班時間起的後10分鐘內可申請免刷卡()
            '                '在中午刷卡時間起的前20分鐘至中午刷卡時間迄的後10分鐘內可申請免刷卡()
            '                '在下班時間的後40分鐘內可申請免刷卡()
            '                '例如：0800~1600班別
            '                '0800-1600班  08:00 ~ 16:00  ~  13:10 ~ 13:30  
            '                '可在07:40:00~08:10:59這段時間內可申請上班卡忘刷卡
            '                '可在13:10:00~13:40:59這段時間內可申請中午卡忘刷卡
            '                '可在16:00:00~16:40:59這段時間內可申請下班卡忘刷卡
            '                '申請上班卡忘刷卡, 若核准, 則以0800為忘刷卡時間
            '                '申請中午卡忘刷卡, 若核准, 則以1200為忘刷卡時間
            '                '申請下班卡忘刷卡, 若核准, 則以1600為忘刷卡時間

            '                Dim _theStartDateTime As Date = DateTimeInfo.GetPublicDate(nowdate & _Start_time)
            '                Dim _theEndDateTime As Date = DateTimeInfo.GetPublicDate(nowdate & _End_time)
            '                Dim _theNooncardSDateTime As Date = DateTimeInfo.GetPublicDate(nowdate & _Nooncard_stime)
            '                Dim _theNooncardEDateTime As Date = DateTimeInfo.GetPublicDate(nowdate & _Nooncard_etime)

            '                Dim _compareStarttime As String = ""
            '                Dim _compareEndtime As String = ""

            '                If "1" = Card_type Then '上班卡
            '                    _compareStarttime = _theStartDateTime.AddMinutes(-20).ToString("HHmmss")
            '                    _compareEndtime = _theStartDateTime.AddMinutes(10).AddSeconds(59).ToString("HHmmss")
            '                    If hhmmss < _compareStarttime Or hhmmss > _compareEndtime Then
            '                        Return "目前時段不可申請上班卡忘帶刷卡證"
            '                    End If
            '                    Forgot_time = _Start_time
            '                ElseIf "2" = Card_type Then '下班卡
            '                    _compareStarttime = _theEndDateTime.ToString("HHmmss")
            '                    _compareEndtime = _theEndDateTime.AddMinutes(40).AddSeconds(59).ToString("HHmmss")
            '                    If hhmmss < _compareStarttime Or hhmmss > _compareEndtime Then
            '                        Return "目前時段不可申請下班卡忘帶刷卡證"
            '                    End If
            '                    Forgot_time = _End_time
            '                Else '中午卡
            '                    _compareStarttime = _theNooncardSDateTime.ToString("HHmmss")
            '                    _compareEndtime = _theNooncardEDateTime.AddMinutes(10).AddSeconds(59).ToString("HHmmss")
            '                    If hhmmss < _compareStarttime Or hhmmss > _compareEndtime Then
            '                        Return "目前時段不可申請中午卡忘帶刷卡證"
            '                    End If
            '                    Forgot_time = _Nooncard_etime
            '                End If
            '            End If
            '        End If
            '    End If
            '    If isNormal Then
            '        '正常班標準(上班時間0800~1730)

            '        'hsien 20130219
            '        Dim cpaDAO As New CPAPO15MDAO(p2kConn)
            '        Dim p2kdt As DataTable = cpaDAO.GetDataByDate(yyymmdd, Apply_id, True)
            '        Dim err As String = ""

            '        Dim isCard1 As Boolean = True   '是否可申請上班卡
            '        Dim isCard2 As Boolean = True   '是否可申請下班卡
            '        Dim isCard3 As Boolean = True   '是否可申請中午卡

            '        Dim canApply As Boolean = False

            '        If p2kdt IsNot Nothing AndAlso p2kdt.Rows.Count > 0 Then
            '            '有差假記錄

            '            Dim PEKIND As String = New CPAPE05M(p2kConn).GetColumnValue("PEKIND", Apply_id)
            '            Dim WORKTIMEB As String = ""
            '            Dim WORKTIMEE As String = ""
            '            Dim NOONTIMEB As String = ""
            '            Dim NOONTIMEE As String = ""

            '            '1. 先取差勤組別的班別資料
            '            Dim pc03mdt As Data.DataTable = New CPAPC03M(p2kConn).GetData(PEKIND, "worktime")
            '            If pc03mdt Is Nothing OrElse pc03mdt.Rows.Count <= 0 Then
            '                Return Nothing
            '            End If
            '            Dim pc03mdr() As Data.DataRow

            '            pc03mdr = pc03mdt.Select(" PCCODE='0' ")
            '            If pc03mdr IsNot Nothing AndAlso pc03mdr.Length > 0 Then
            '                WORKTIMEB = pc03mdr(0)("PCPARM1").ToString()
            '                WORKTIMEE = pc03mdr(0)("PCPARM2").ToString()
            '            End If

            '            pc03mdr = pc03mdt.Select(" PCCODE='11' ")
            '            If pc03mdr IsNot Nothing AndAlso pc03mdr.Length > 0 Then
            '                NOONTIMEB = pc03mdr(0)("PCPARM1").ToString()
            '                NOONTIMEE = pc03mdr(0)("PCPARM2").ToString()
            '            End If

            '            For Each dr As DataRow In p2kdt.Rows
            '                Me.Forgot_time = ""

            '                Dim sdate As String = dr("dateb").ToString()    '差假起日
            '                Dim stime As String = dr("timeb").ToString()    '差假起時
            '                Dim edate As String = dr("datee").ToString()    '差假迄日
            '                Dim etime As String = dr("timee").ToString()    '差假迄時

            '                If sdate <> edate Then
            '                    If sdate < yyymmdd Then
            '                        stime = WORKTIMEB
            '                    ElseIf edate > yyymmdd Then
            '                        etime = WORKTIMEE
            '                    End If
            '                End If

            '                Dim _sdatetime As DateTime = DateTimeInfo.GetPublicDate(sdate & stime)
            '                Dim _edatetime As DateTime = DateTimeInfo.GetPublicDate(edate & etime)

            '                Dim _apply_start As DateTime    '申請的開始時間
            '                Dim _apply_end As DateTime      '申請的結束時間

            '                If stime = WORKTIMEB And etime < NOONTIMEB Then
            '                    '請假時間:0800~0900
            '                    '可申請忘刷卡時間為0830:00~0900:00,忘刷卡寫入時間0900

            '                    _apply_start = _edatetime.AddMinutes(-30)
            '                    _apply_end = _edatetime

            '                    If hhmmss >= _apply_start.ToString("HHmmss") And hhmmss <= _apply_end.ToString("HHmmss") Then
            '                        Forgot_time = _edatetime.ToString("HHmm")
            '                        canApply = True
            '                    End If

            '                    isCard1 = False

            '                ElseIf etime = WORKTIMEE And stime > NOONTIMEE Then
            '                    '請假時間:1630~1730
            '                    '可申請忘刷卡時間為1630:00~1659:59,忘刷卡寫入時間1630

            '                    _apply_start = _sdatetime
            '                    _apply_end = _sdatetime.AddMinutes(29).AddSeconds(59)

            '                    If hhmmss >= _apply_start.ToString("HHmmss") And hhmmss <= _apply_end.ToString("HHmmss") Then
            '                        Forgot_time = _sdatetime.ToString("HHmm")
            '                        canApply = True
            '                    End If

            '                    isCard2 = False

            '                ElseIf stime = WORKTIMEB And etime = NOONTIMEB Then
            '                    '請假時間:0800~1200

            '                    isCard1 = False

            '                ElseIf stime = NOONTIMEE And etime = WORKTIMEE Then
            '                    '請假時間:1330~1730

            '                    If hhmmss >= "120000" And hhmmss <= "124059" Then
            '                        Forgot_time = "1200"
            '                        canApply = True
            '                    End If

            '                    isCard2 = False
            '                    isCard3 = False

            '                ElseIf stime > WORKTIMEB And etime < WORKTIMEE Then
            '                    '請假時間:0900~1000

            '                    If stime <> NOONTIMEE Then
            '                        '請假時間:1000~1200
            '                        _apply_start = _sdatetime
            '                        _apply_end = _sdatetime.AddMinutes(29).AddSeconds(59)
            '                        If hhmmss >= _apply_start.ToString("HHmmss") And hhmmss <= _apply_end.ToString("HHmmss") Then
            '                            Forgot_time = _sdatetime.ToString("HHmm")
            '                            canApply = True
            '                        End If
            '                    End If

            '                    If etime <> NOONTIMEB Then
            '                        '請假時間:1330~1430
            '                        _apply_start = _edatetime.AddMinutes(-30)
            '                        _apply_end = _edatetime
            '                        If hhmmss >= _apply_start.ToString("HHmmss") And hhmmss <= _apply_end.ToString("HHmmss") Then
            '                            Forgot_time = _edatetime.ToString("HHmm")
            '                            canApply = True
            '                        End If
            '                    End If

            '                    If stime = NOONTIMEE Then
            '                        isCard3 = False
            '                    End If

            '                End If

            '                If canApply Then
            '                    err = ""
            '                Else
            '                    err = "目前時段不可申請忘帶刷卡證"
            '                End If
            '            Next
            '        End If


            '        If Not canApply Then

            '            '可在07:40:00~08:10:59這段時間內可申請上班卡忘刷卡 ,
            '            '可在13:10:00~13:40:59這段時間內可申請中午卡忘刷卡
            '            '可在17:30:00~18:10:59這段時間內可申請下班卡忘刷卡
            '            '申請上班卡忘刷卡, 若核准, 時間則以0800為忘刷卡時間
            '            '申請中午卡忘刷卡, 若核准, 時間則以1200為忘刷卡時間
            '            '申請下班卡忘刷卡, 若核准, 時間則以1730為忘刷卡時間
            '            If "1" = Card_type And isCard1 Then '上班卡
            '                If hhmmss < "074000" Or hhmmss > "081059" Then
            '                    err = "目前時段不可申請上班卡忘帶刷卡證"
            '                Else
            '                    err = ""
            '                    Forgot_time = "0800"
            '                End If
            '            ElseIf "2" = Card_type And isCard2 Then '下班卡
            '                If hhmmss < "173000" Or hhmmss > "181059" Then
            '                    err = "目前時段不可申請下班卡忘帶刷卡證"
            '                Else
            '                    err = ""
            '                    Forgot_time = "1730"
            '                End If
            '            ElseIf "3" = Card_type And isCard3 Then '中午卡
            '                If hhmmss < "131000" Or hhmmss > "134059" Then
            '                    err = "目前時段不可申請中午卡忘帶刷卡證"
            '                Else
            '                    err = ""
            '                    Forgot_time = "1330"
            '                End If
            '            End If

            '        End If

            '        If err <> "" Then
            '            Return err
            '        End If
            '    End If
            'End If

            Return String.Empty
        End Function


        Public Function InsertForgotClockApply() As Boolean
            Return dao.InsertData(Me) = 1
        End Function

        Public Function UpdateForgotClockApply() As Boolean
            Return dao.UpdateData(Me) = 1
        End Function

        Public Function getDesc(ByVal Apply_id As String, ByVal Apply_date As String) As String
            'Dim sb As StringBuilder = New StringBuilder
            'Dim ds As DataSet = dao.GetDataByApply_id(Apply_id)
            'Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            'Dim dt As DataTable = New ForgetClockSetting().GetForgetclockSettingByOrgcode(Orgcode)
            'Dim Year_time As String = dt.Rows(0)("Year_time").ToString()
            'If Not ds Is Nothing Then
            '    Dim dt1 As DataTable = ds.Tables(0)
            '    '   If Not dt Is Nothing And dt.Rows.Count > 0 Then
            '    sb.Append("，您已申請").Append(dt1.Rows.Count).Append("次，剩餘").Append(Year_time - dt1.Rows.Count).Append("次")
            'End If
            'Return sb.ToString()
            Dim bll As New FSC4103_01DAO
            Dim ds As DataSet = bll.GetData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
            If ds IsNot Nothing Then
                If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("Times").ToString() = "0" Then
                        Return "刷卡補登不限次數"
                    Else
                        Dim YearTimes As String = ds.Tables(0).Rows(0)("YearTimes").ToString()
                        Dim MonthTimes As String = ds.Tables(0).Rows(0)("MonthTimes").ToString()
                        Dim YearCount As Integer = CommonFun.getInt(dao.GetCountByYear(Apply_id, Left(Apply_date, 3)))
                        Dim MonthCOunt As Integer = CommonFun.getInt(dao.GetCountByMonth(Apply_id, Mid(Apply_date, 4, 2)))

                        If Not String.IsNullOrEmpty(YearTimes) AndAlso Not String.IsNullOrEmpty(MonthTimes) Then
                            Return "每年上限" + YearTimes + "次， 且每月上限" + MonthTimes + "次，您目前已申請" + YearCount.ToString() + "次。"
                        ElseIf Not String.IsNullOrEmpty(YearTimes) Then
                            Return "每年上限" + YearTimes + "次，您目前已申請" + YearCount.ToString() + "次。"
                        ElseIf Not String.IsNullOrEmpty(MonthTimes) Then
                            Return "每月上限" + MonthTimes + "次，您目前已申請" + MonthCOunt.ToString() + "次。"
                        End If
                    End If
                End If
            End If
            Return ""
        End Function

        Public Function getData(ByVal Apply_idcard As String, ByVal forgot_date As String, ByVal card_type As String) As DataTable
            Return dao.getData(Apply_idcard, forgot_date, card_type)
        End Function
    End Class
End Namespace