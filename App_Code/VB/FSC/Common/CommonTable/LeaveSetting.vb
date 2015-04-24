Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace FSC.Logic
    Public Class LeaveSetting
        Public DAO As LeaveSettingDAO

#Region "Property"
        Private _ID As Integer
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Leave_kind As String
        Private _Leave_type As String
        Private _Memcod As String
        Private _Limit As Double
        Private _Inholiday As String
        Private _Describe As String
        Private _Min_hour As Double
        Private _Ifholiday_flag As String
        Private _Ifoccur_date_flag As String
        Private _Ifmustattach_flag As String
        Private _many_days As Double
        Private _Ifattach_flag As String
        Private _Message_flag As Double
        Private _Applystop_sdate As String
        Private _Applystop_edate As String
        Private _Applystop_stime As String
        Private _Applystop_etime As String
        Private _Ifbatch_apply As String
        Private _Reciprocal_days As Double
        Private _update_userid As String
        Private _limit_date As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property Leave_kind() As String
            Get
                Return _Leave_kind
            End Get
            Set(ByVal value As String)
                _Leave_kind = value
            End Set
        End Property
        Public Property Leave_type() As String
            Get
                Return _Leave_type
            End Get
            Set(ByVal value As String)
                _Leave_type = value
            End Set
        End Property
        Public Property Memcod() As String
            Get
                Return _Memcod
            End Get
            Set(value As String)
                _Memcod = value
            End Set
        End Property
        Public Property Limit() As Double
            Get
                Return _Limit
            End Get
            Set(ByVal value As Double)
                _Limit = value
            End Set
        End Property
        Public Property Inholiday() As String
            Get
                Return _Inholiday
            End Get
            Set(ByVal value As String)
                _Inholiday = value
            End Set
        End Property
        Public Property Describe() As String
            Get
                Return _Describe
            End Get
            Set(ByVal value As String)
                _Describe = value
            End Set
        End Property
        Public Property Min_hour() As Double
            Get
                Return _Min_hour
            End Get
            Set(ByVal value As Double)
                _Min_hour = value
            End Set
        End Property
        Public Property Ifholiday_flag() As String
            Get
                Return _Ifholiday_flag
            End Get
            Set(ByVal value As String)
                _Ifholiday_flag = value
            End Set
        End Property
        Public Property Ifoccur_date_flag() As String
            Get
                Return _Ifoccur_date_flag
            End Get
            Set(ByVal value As String)
                _Ifoccur_date_flag = value
            End Set
        End Property
        Public Property Ifmustattach_flag() As String
            Get
                Return _Ifmustattach_flag
            End Get
            Set(ByVal value As String)
                _Ifmustattach_flag = value
            End Set
        End Property
        Public Property many_days() As Double
            Get
                Return _many_days
            End Get
            Set(ByVal value As Double)
                _many_days = value
            End Set
        End Property
        Public Property Ifattach_flag() As String
            Get
                Return _Ifattach_flag
            End Get
            Set(ByVal value As String)
                _Ifattach_flag = value
            End Set
        End Property
        Public Property Message_flag() As Double
            Get
                Return _Message_flag
            End Get
            Set(ByVal value As Double)
                _Message_flag = value
            End Set
        End Property
        Public Property Applystop_sdate() As String
            Get
                Return _Applystop_sdate
            End Get
            Set(ByVal value As String)
                _Applystop_sdate = value
            End Set
        End Property
        Public Property Applystop_edate() As String
            Get
                Return _Applystop_edate
            End Get
            Set(ByVal value As String)
                _Applystop_edate = value
            End Set
        End Property
        Public Property Applystop_stime() As String
            Get
                Return _Applystop_stime
            End Get
            Set(ByVal value As String)
                _Applystop_stime = value
            End Set
        End Property
        Public Property Applystop_etime() As String
            Get
                Return _Applystop_etime
            End Get
            Set(ByVal value As String)
                _Applystop_etime = value
            End Set
        End Property
        Public Property Ifbatch_apply() As String
            Get
                Return _Ifbatch_apply
            End Get
            Set(ByVal value As String)
                _Ifbatch_apply = value
            End Set
        End Property
        Public Property Reciprocal_days() As Double
            Get
                Return _Reciprocal_days
            End Get
            Set(ByVal value As Double)
                _Reciprocal_days = value
            End Set
        End Property
        Public Property Update_userid() As String
            Get
                Return _update_userid
            End Get
            Set(ByVal value As String)
                _update_userid = value
            End Set
        End Property
        Public Property id() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public Property limit_date() As String
            Get
                Return _limit_date
            End Get
            Set(ByVal value As String)
                _limit_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New LeaveSettingDAO
        End Sub

        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Leave_kind", Leave_kind)
            d.Add("Leave_type", Leave_type)
            d.Add("Memcod", Memcod)
            d.Add("Limit", Limit)
            d.Add("Describe", Describe)
            d.Add("Min_hour", Min_hour)
            d.Add("Ifholiday_flag", Ifholiday_flag)
            d.Add("Ifoccur_date_flag", Ifoccur_date_flag)
            d.Add("Ifmustattach_flag", Ifmustattach_flag)
            d.Add("many_days", many_days)
            d.Add("Ifattach_flag", Ifattach_flag)
            d.Add("Message_flag", Message_flag)
            d.Add("Applystop_sdate", Applystop_sdate)
            d.Add("Applystop_edate", Applystop_edate)
            d.Add("Applystop_stime", Applystop_stime)
            d.Add("Applystop_etime", Applystop_etime)
            d.Add("Ifbatch_apply", Ifbatch_apply)
            d.Add("Reciprocal_days", Reciprocal_days)
            d.Add("limit_date", limit_date)
            d.Add("update_userid", Update_userid)
            d.Add("update_date", Now)

            Return DAO.InsertByExample("FSC_Leave_setting", d) >= 1
        End Function

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Limit", Limit)
            d.Add("Describe", Describe)
            d.Add("Min_hour", Min_hour)
            d.Add("Ifholiday_flag", Ifholiday_flag)
            d.Add("Ifoccur_date_flag", Ifoccur_date_flag)
            d.Add("Ifmustattach_flag", Ifmustattach_flag)
            d.Add("many_days", many_days)
            d.Add("Ifattach_flag", Ifattach_flag)
            d.Add("Message_flag", Message_flag)
            d.Add("Applystop_sdate", Applystop_sdate)
            d.Add("Applystop_edate", Applystop_edate)
            d.Add("Applystop_stime", Applystop_stime)
            d.Add("Applystop_etime", Applystop_etime)
            d.Add("Ifbatch_apply", Ifbatch_apply)
            d.Add("Reciprocal_days", Reciprocal_days)
            d.Add("limit_date", limit_date)
            d.Add("update_userid", Update_userid)
            d.Add("update_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Leave_kind", Leave_kind)
            cd.Add("Leave_type", Leave_type)
            cd.Add("Memcod", Memcod)

            Return DAO.UpdateByExample("FSC_Leave_setting", d, cd) >= 1
        End Function

        Public Function delete() As Boolean

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Leave_kind", Leave_kind)
            cd.Add("Leave_type", Leave_type)
            cd.Add("ID", ID)

            Return DAO.DeleteByExample("FSC_Leave_setting", cd) >= 1
        End Function

        Public Function GetDataByLeaveKind(ByVal Orgcode As String, _
                                           ByVal Leave_kind As String, _
                                           ByVal Leave_type As String, _
                                           ByVal Memcod As String) As DataTable

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Leave_kind", Leave_kind)
            If Not String.IsNullOrEmpty(Leave_type) Then
                d.Add("Leave_type", Leave_type)
            End If
            If Not String.IsNullOrEmpty(Memcod) Then
                d.Add("Memcod", Memcod)
            End If

            Return DAO.GetDataByExample("FSC_Leave_setting", d)
        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, _
                                       ByVal LeaveKind As String, _
                                       ByVal LeaveType As String, _
                                       ByVal employeeType As String) As DataTable
            Return DAO.GetDataByQuery(Orgcode, LeaveKind, LeaveType, employeeType)

        End Function

        Public Function GetObject(ByVal Orgcode As String, _
                                    ByVal Leave_kind As String, _
                                    ByVal Leave_type As String, _
                                    ByVal Memcod As String) As LeaveSetting
            Dim dt As DataTable = GetDataByLeaveKind(Orgcode, Leave_kind, Leave_type, Memcod)
            Dim list As List(Of LeaveSetting) = CommonFun.ConvertToList(Of LeaveSetting)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function

        Public Function GetDataByLeaveType(ByVal Orgcode As String, ByVal Leave_type As String) As DataTable

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Leave_type", Leave_type)

            Return DAO.GetDataByExample("FSC_Leave_setting", d)
        End Function


        Public Function GetApplyLimit(ByVal Orgcode As String, _
                                      ByVal Leave_kind As String, _
                                      ByVal Leave_type As String) As Double

            Dim dt As DataTable = GetDataByLeaveKind(Orgcode, Leave_kind, Leave_type, Memcod)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("Limit").ToString()
            End If

            Return 0.0
        End Function

        Public Function getDesc(ByVal Id_card As String, ByVal Leave_type As String) As String
            If String.IsNullOrEmpty(Id_card) Or String.IsNullOrEmpty(Leave_type) Then
                Return ""
            End If
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim dt As DataTable = New Personnel().GetDataByIdCard(Id_card)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim employee_type As String = dt.Rows(0)("employee_type").ToString()
                Dim lsdt As DataTable = New LeaveSetting().GetDataByLeaveKind(Orgcode, dt.Rows(0)("PEKIND").ToString(), Leave_type, employee_type)
                If lsdt IsNot Nothing AndAlso lsdt.Rows.Count > 0 Then
                    Return New SYS.Logic.LeaveType().GetLeaveName(Leave_type) & "：" & lsdt.Rows(0)("Describe").ToString()
                End If
            End If
            Return ""
        End Function

        Public Function GetLimitDesc(ByVal Id_card As String, _
                                     ByVal Leave_type As String, _
                                     ByVal sdate As String) As String
            Return GetLimitDesc(Id_card, Leave_type, sdate, 0, 0, False)
        End Function

        Public Function GetLimitDesc(ByVal Id_card As String, _
                                     ByVal Leave_type As String, _
                                     ByVal sdate As String, _
                                     ByVal target As Integer) As String
            Return GetLimitDesc(Id_card, Leave_type, sdate, target, 0, False)
        End Function

        Public Function GetLimitDesc(ByVal Id_card As String, _
                             ByVal Leave_type As String, _
                             ByVal sdate As String, _
                             ByVal target As Integer, _
                             ByVal BabyDays As Integer) As String
            Return GetLimitDesc(Id_card, Leave_type, sdate, target, BabyDays, False)
        End Function

        Public Function GetLimitDesc(ByVal Id_card As String, _
                                     ByVal Leave_type As String, _
                                     ByVal sdate As String, _
                                     ByVal target As Integer, _
                                     ByVal BabyDays As Integer, _
                                     ByVal withoutTexDesc As Boolean) As String

            If String.IsNullOrEmpty(Id_card) Then
                Return ""
            End If
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim psn As Personnel = New Personnel().GetObject(Id_card)
            If psn Is Nothing Then
                Return String.Empty
            End If
            Dim lm As New LeaveMain()

            Dim Limitdays As Double = 0.0
            Dim hours As Integer = 0
            Dim Leftdays As Double = 0.0
            Dim employeeType As String = psn.EmployeeType
            Dim PEKIND As String = psn.Pekind
            Dim PEHYEAR As String = psn.Pehday
            Dim PEHDAY As Double = CommonFun.getDouble(psn.Pehday)
            Dim PERDAY1 As Double = CommonFun.getDouble(psn.Perday1)
            Dim PERDAY2 As Double = CommonFun.getDouble(psn.Perday2)

            Dim otherdesc As New StringBuilder()

            Dim otherLimitdays As Double = 0.0
            Dim otherhours As Integer = 0
            Dim otherLeftdays As Double = 0.0
            Dim otherLeavetype As String = ""

            Leave_type = Leave_type.PadLeft(2, "0")

            Dim NowYear As String = Right("0" & Today.Year - 1911, 3)
            Dim NextYear As String = Right("0" & Today.Year - 1911 + 1, 3)
            Dim NowMMDD As String = Right("0" & Today.Month, 2) & Right("0" & Today.Day, 2)
            Dim isCrossYear As Boolean = False
            If Not String.IsNullOrEmpty(sdate) And "03" = Leave_type Then
                If NextYear = sdate.Substring(0, 3) Or NextYear = sdate.Substring(0, 3) Then
                    isCrossYear = True
                End If
            End If

            '請假規則
            Dim ls As FSC.Logic.LeaveSetting = New FSC.Logic.LeaveSetting().GetObject(Orgcode, PEKIND, Leave_type, employeeType)

            If Leave_type = "08" Or Leave_type = "10" Or Leave_type = "22" Or Leave_type = "13" Then '婚假, 喪假, 陪產假
                '依事實發生日統計假別目前總時數

                If String.IsNullOrEmpty(sdate) Then
                    sdate = DateTimeInfo.GetRocDate(Now)
                End If

                hours = lm.GetHaveHoursByOccurDate(Id_card, Leave_type, sdate)

            Else
                'ex:事假, 病假, 休假,  生理假, 家庭照顧假, 延休假
                '依年月統計假別目前總時數

                If String.IsNullOrEmpty(sdate) Then
                    sdate = DateTimeInfo.GetRocDate(Now)
                End If

                hours = lm.GetHaveHoursByDate(Id_card, Leave_type, sdate)

                If Leave_type = "01" Then '事假 含 家庭照顧假
                    otherLeavetype = "25"
                    otherhours = lm.GetHaveHoursByDate(Id_card, otherLeavetype, sdate)
                    If otherhours > 0 Then
                        otherdesc.Append("，已請").Append("家庭照顧假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours)))
                    End If

                End If

                If Leave_type = "25" Then   '家庭照顧假 含 事假
                    otherLeavetype = "01"
                    otherhours = lm.GetHaveHoursByDate(Id_card, otherLeavetype, sdate)
                    If otherhours > 0 Then
                        otherdesc.Append("，已請").Append("事假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours)))
                    End If

                    Dim pd04mdt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, otherLeavetype)
                    For Each dr As DataRow In pd04mdt.Rows
                        otherLimitdays = CommonFun.getDouble(dr("PDDAYS").ToString()).ToString()
                    Next
                End If

                If Leave_type = "02" Then   '病假 含 生理假
                    otherLeavetype = "24"
                    otherhours = lm.GetHaveHoursByDate(Id_card, otherLeavetype, sdate)
                    If otherhours > 0 Then
                        otherdesc.Append("，已請").Append("生理假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours)))
                    End If

                End If

                If Leave_type = "24" Then   '生理假 含 病假
                    otherLeavetype = "02"
                    otherhours = lm.GetHaveHoursByDate(Id_card, otherLeavetype, sdate)
                    If otherhours > 0 Then
                        otherdesc.Append("，已請").Append("病假").Append(CommonFun.getShowDayHours(Content.ConvertDayHours(otherhours)))
                    End If

                    Dim pd04mdt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, otherLeavetype)
                    For Each dr As DataRow In pd04mdt.Rows
                        otherLimitdays = CommonFun.getDouble(dr("PDDAYS").ToString()).ToString()
                    Next
                End If

            End If


            Select Case Leave_type
                Case "01"
                    '事假
                    If Not String.IsNullOrEmpty(psn.Pehday2.ToString()) Then
                        Limitdays = psn.Pehday2.ToString()
                    Else
                        Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type)
                        If dt.Rows.Count > 0 Then
                            Limitdays = dt.Rows(0)("PDDAYS").ToString()
                        End If
                    End If

                Case "03"
                    '休假
                    Limitdays = Content.ConvertDayHours(Content.ConvertToHours(PEHDAY) + Content.ConvertToHours(PERDAY1) + Content.ConvertToHours(PERDAY2))
                    'Limitdays = PEHDAY
                    'Limitdays = PERDAY1 +PERDAY1 +PERDAY2
                    'by jessica modi 1030102 LeaveType:30為暑休、31為寒休
                    'Case "30"
                    '    '前一年延休假
                    '    Limitdays = PERDAY1

                    'Case "31"
                    '    '前二年延休假
                    '    Limitdays = PERDAY2
                Case "30"
                    Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type)
                    If dt.Rows.Count > 0 Then
                        Limitdays = dt.Rows(0)("PDDAYS").ToString()
                    End If
                Case "31"
                    Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type)
                    If dt.Rows.Count > 0 Then
                        Limitdays = dt.Rows(0)("PDDAYS").ToString()
                    End If
                Case "10"
                    Limitdays = New LeaveMain().GetSpecialimitDays(ls, Leave_type, target, 0)
                Case "13"

                    'Limitdays = New LeaveMain().GetType10LimitDays(employeeType, target)
                    Limitdays = New LeaveMain().GetSpecialimitDays(ls, Leave_type, 0, BabyDays)

                Case Else

                    Dim pd04mdt As DataTable = New CPAPD04M().GetDataByQuery(PEKIND, employeeType, Leave_type.ToString().PadLeft(2, "0"))

                    For Each dr As DataRow In pd04mdt.Rows
                        Limitdays = CommonFun.getDouble(dr("PDDAYS").ToString()).ToString()
                    Next

                    If Limitdays = 0 Then
                        Return String.Empty
                    End If

            End Select

            If isCrossYear Then
                '(1)	若為正式人員、約聘僱人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
                '(2)	承(1)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。
                '(3)	若為臨時人員、技工、工友、駕駛、定期僱用、約用人員，以下年度1/1為基準，計算個人的年資，若年資不足一年，則下年度的休假天數為0。
                '(4)	承(3)，若計算出來的年資大於1年或以上，則依年資給予對應的休假天數。

                '取 PEHYEAR, PEDAY
                Dim baseDate As Date = DateTimeInfo.GetPublicDate(NextYear & "0101")

                Dim Join_sdate As String = String.Empty
                Dim Elected_officials_flag As String = String.Empty
                Dim vPEKIND As String = String.Empty
                Dim vPEMEMCOD As String = String.Empty
                Dim Metadb_id As String = ""
                Dim pe05md2t As DataTable = New Personnel().GetDataByIdCard(Id_card)
                If pe05md2t IsNot Nothing AndAlso pe05md2t.Rows.Count > 0 Then
                    Dim dr As DataRow = pe05md2t.Rows(0)
                    vPEKIND = dr("PEKIND").ToString()
                    'vPEMEMCOD = dr("PEMEMCOD").ToString()
                End If

                Dim p As New FSC.Logic.Personnel()
                Dim dt As DataTable
                dt = p.GetDataByIdCard(Id_card)
                If dt.Rows.Count > 0 Then
                    Dim row As DataRow = dt.Rows(0)
                    'Elected_officials_flag = row("Elected_officials_flag").ToString()
                    Join_sdate = row("join_sdate").ToString()
                End If

                Dim l As LeaveYearDay = CntLeave.GetCntYearsDays(Orgcode, Id_card, Join_sdate, Elected_officials_flag, vPEKIND, vPEMEMCOD, baseDate)
                If l IsNot Nothing Then
                    Limitdays = CommonFun.getDouble(l.Day)
                End If

            End If

            Leftdays = Content.ConvertDayHours(Content.ConvertToHours(Limitdays) - (hours + otherhours))
            If Leftdays < 0 Then
                Leftdays = 0
            End If

            otherLeftdays = Content.ConvertDayHours(Content.ConvertToHours(otherLimitdays) - otherhours)
            If otherLeftdays < 0 Then
                otherLeftdays = 0
            End If

            If isCrossYear Then

            End If

            If Limitdays < 0 Then
                Limitdays = 0
            End If

            Dim ret As New StringBuilder()
            If withoutTexDesc Then
                'ret.Append(New LeaveType().GetLeave_name(Leave_type)).Append(",")

                ret.Append(Limitdays).Append(",")
                ret.Append(Content.ConvertDayHours(hours)).Append(",")
                ret.Append(Leftdays)
            Else
                ret.Append("<span style='line-height:22px;'>")
                ret.AppendLine("您").Append(New SYS.Logic.LeaveType().GetLeaveName(Leave_type)) _
                            .Append("可請").Append(CommonFun.getShowDayHours(Limitdays)) _
                            .Append("，目前已請").Append(New SYS.Logic.LeaveType().GetLeaveName(Leave_type)).Append(CommonFun.getShowDayHours(Content.ConvertDayHours(hours))) _
                            .Append(otherdesc.ToString()) _
                            .Append("，剩餘").Append(CommonFun.getShowDayHours(Leftdays))
                ret.Append("</span>")

                If otherLeftdays = 0 And otherLimitdays <> 0 And otherhours <> 0 Then
                    ret.Append("<br/><span style='color:red; line-height:22px;'>")
                    ret.AppendLine("您").Append(New SYS.Logic.LeaveType().GetLeaveName(otherLeavetype)).Append("剩餘").Append(CommonFun.getShowDayHours(otherLeftdays)).Append("，若提出").Append(New SYS.Logic.LeaveType().GetLeaveName(Leave_type)).Append("將會被扣薪，請確定是否要提出申請。")
                    ret.Append("</span>")
                End If
            End If


            Return ret.ToString()
        End Function


    End Class
End Namespace
