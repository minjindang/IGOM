Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class ProcessFSC
        Inherits Process

        Public Overloads Sub InitFlow(ByVal flow As SYS.Logic.Flow, ByVal lmList As List(Of FSC.Logic.LeaveMain), ByVal lmmList As List(Of FSC.Logic.LeaveMainMapping))
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            Dim Writer_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Dim Change_userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            Dim code As New FSCPLM.Logic.SACode()
            Dim nowStep As Integer = 1

            Dim fopdt As DataTable = Outpost.GetFlowOutpost(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, flow.FormId)
            If fopdt Is Nothing OrElse fopdt.Rows.Count <= 0 Then
                '沒有對應的關卡檔
                Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
            End If

            Dim employee_type As String = New FSC.Logic.Personnel().GetColumnValue("Employee_type", flow.ApplyIdcard)
            For Each leaveMain As FSC.Logic.LeaveMain In lmList
                '檢核代理表單
                Dim checkDeputyFlag As Boolean = False

                If leaveMain.LeaveType <> "80" And leaveMain.LeaveType <> "82" And leaveMain.LeaveType <> "85" And employee_type <> "13" Then
                    checkDeputyFlag = True
                End If
                'If checkDeputyFlag Then
                '    '代理表單資料
                '    'checkApplyAndDeputy(leaveMain.StartDate, leaveMain.StartTime, leaveMain.EndDate, leaveMain.endTime)
                'End If
                '
                Dim hashProxy As Boolean = False
                Dim rowIndex As Integer = 1

                For Each dr As DataRow In fopdt.Rows

                    '判斷有無代理人關卡
                    If "001" = dr("Outpost_id").ToString() Then
                        hashProxy = True
                    End If

                    '無選擇代理人則直接跳往下一關
                    If "001" = dr("Outpost_id").ToString() And String.IsNullOrEmpty(flow.DeputyIdcard) Then
                        hashProxy = True
                        nowStep = 2
                        flow.DeputyFlag = "0"
                        flow.DeputyOrgcode = ""
                        flow.DeputyDepartid = ""
                        flow.DeputyPosid = ""
                        flow.DeputyIdcard = ""
                        flow.DeputyName = ""
                    End If

                    '沒有時數限制,查下個關卡
                    If String.IsNullOrEmpty(dr("Hoursetting_id").ToString()) Then
                        Continue For
                    Else
                        Dim hoursTxt As String = code.GetCodeDesc("024", "006", dr("Hoursetting_id").ToString())
                        If Mid(hoursTxt, 1, 2) = "<=" Then
                            Dim hours As Double = Integer.Parse(Mid(hoursTxt, 3))
                            If leaveMain.LeaveHours > hours Then
                                Continue For
                            End If

                            nowStep = rowIndex
                            Exit For
                        End If
                    End If
                Next

                '若關卡檔有設定要陳核到代理人的話, 代理人才為必填欄位
                If checkDeputyFlag And hashProxy And String.IsNullOrEmpty(flow.DeputyIdcard) Then
                    Throw New FlowException("該表單需設定職務代理人!")
                End If

                If hashProxy And flow.ApplyIdcard = flow.DeputyIdcard Then
                    Throw New FlowException("職務代理人不可為申請人!")
                End If

                rowIndex += 1
            Next

            Dim reason As String = flow.Reason
            For Each leaveMain As FSC.Logic.LeaveMain In lmList
                If Not leaveMain.InsertLeaveMain(True) Then
                    Throw New FlowException("新增差假主檔時發生錯誤!")
                End If
                reason = leaveMain.Reason
            Next

            If Not lmmList Is Nothing Then
                For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                    If Not lmm.InsertData(True) Then
                        Throw New FlowException("新增差假對應檔時發生錯誤!")
                    End If
                Next
            End If

            flow.LastPass = 0
            flow.CaseStatus = 0
            flow.WriteTime = Now
            flow.Reason = reason

            If String.IsNullOrEmpty(flow.WriterIdcard) Then
                '無填寫人資料, 帶申請人資料
                flow.WriterOrgcode = flow.Orgcode
                flow.WriterDepartid = flow.DepartId
                flow.WriterPosid = flow.ApplyPosid
                flow.WriterIdcard = flow.ApplyIdcard
                flow.WriterName = flow.ApplyName
            End If

            If Not InsertFlowNext(flow, fopdt, nowStep) Then
                Throw New FlowException("新增批核人員時發生錯誤!")
            End If

            If Not flow.Insert() Then
                Throw New FlowException("新增流程時發生錯誤!")
            End If
        End Sub

        Public Overrides Sub RunAgreeFlow(ByVal flow As SYS.Logic.Flow)
            RunLastLeave(flow, True)
        End Sub


        Public Overrides Sub RunCancelFlow(ByVal flow As SYS.Logic.Flow)
            RunLastLeave(flow, False)
        End Sub

        Public Overrides Sub RunDeleteFlow(ByVal flow As SYS.Logic.Flow)

        End Sub

        Public Overrides Sub RunRejectFlow(ByVal flow As SYS.Logic.Flow)

        End Sub

        Public Sub RunLastLeave(ByVal flow As SYS.Logic.Flow, ByVal isPlus As Boolean)
            Dim leaveMainList As List(Of FSC.Logic.LeaveMain) = Nothing
            Dim lm As New FSC.Logic.LeaveMain()
            Dim isLeave As Boolean = True
            Dim code As New FSCPLM.Logic.SACode()

            Dim k As String = String.Empty
            Dim t As String = String.Empty
            If flow.FormId <> "" Then
                K = flow.FormId.Substring(0, 3)
                T = flow.FormId.Substring(3)
            End If

            Dim dtData As DataRow = code.GetRow("024", k, t)
            Try
                If String.IsNullOrEmpty(code.GetRow("024", k, t)("code_desc2").ToString()) Then
                    isLeave = False
                End If
            Catch ex As Exception

            End Try

            If Not isPlus Then
                '撤銷
                Dim fdt As DataTable = flow.GetDataByOrgFid(flow.Orgcode, flow.CancelFlowid)
                If fdt.Rows.Count <= 0 Then
                    Throw New FlowException("找不到被撤銷的表單!")
                End If

                '將被撤銷的表單 Cancel_flag 註記為 Y
                flow.UpdateCancel(flow.Orgcode, flow.CancelFlowid, "3", "Y")

                If isLeave Then
                    '取差假檔(GetObjects)
                    leaveMainList = lm.GetObjects(flow.Orgcode, flow.CancelFlowid)
                End If
            Else
                If isLeave Then
                    '取差假檔(GetObjects)
                    leaveMainList = lm.GetObjects(flow.Orgcode, flow.FlowId)
                End If
            End If


            If isLeave Then

                If leaveMainList Is Nothing Then
                    Throw New FlowException("找不到差假主檔!")
                End If

                For Each leaveMain As FSC.Logic.LeaveMain In leaveMainList
                    Dim yyy As String = leaveMain.StartDate.Substring(0, 3).ToString().PadLeft(3, "0")
                    Dim pyyys As New FSC.Logic.CPAPYYYS(yyy)

                    '依假別處理
                    RunLastLeaveByLeaveType(leaveMain, isPlus)

                    '更新勤惰統計表
                    pyyys.InsertProcess(flow.ApplyIdcard, leaveMain.LeaveType, leaveMain.StartDate, leaveMain.StartTime, leaveMain.EndDate, leaveMain.EndTime, isPlus, flow.FlowId)
                Next

            Else


                If t = "006" Then
                    '刷卡補登 

                    Dim list As List(Of FSC.Logic.ForgotClockApply) = New FSC.Logic.ForgotClockApply().GetObjects(flow.Orgcode, IIf(isPlus, flow.FlowId, flow.CancelFlowid))
                    For Each fca As FSC.Logic.ForgotClockApply In list
                        '寫回PH
                        Dim yymm As String = fca.Forgot_date.Substring(0, 5)
                        Dim phyymm As New FSC.Logic.CPAPHYYMM(yymm)

                        If isPlus Then
                            If Not phyymm.InsertCPAPHYYMM("X", fca.Apply_idcard, fca.Forgot_date, fca.Forgot_time, fca.Card_type, "") Then
                                Throw New FlowException("更新刷卡資料檔失敗!")
                            End If
                        Else
                            If Not phyymm.DeleteCPAPHYYMM("X", fca.Apply_idcard, fca.Forgot_date, fca.Forgot_time, fca.Card_type, "") Then
                                Throw New FlowException("更新刷卡資料檔失敗!")
                            End If
                        End If

                        RunPhToPk(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, fca.Forgot_date, fca.Forgot_date)
                    Next

                ElseIf t = "009" OrElse t = "013" Then
                    '專簽加班簽核

                    Dim por As New FSC.Logic.ProjectOvertimeRule()
                    Dim aproveFlag As String = IIf(isPlus, "1", "")
                    If Not por.UpdateApproveFlag(flow.Orgcode, flow.FlowId, aproveFlag) Then
                        Throw New FlowException("更新專案加班檔失敗!")
                    End If

                    If isPlus Then
                        Dim porlist As List(Of FSC.Logic.ProjectOvertimeRule) = por.GetObjects(flow.Orgcode, flow.FlowId)
                        For Each p As FSC.Logic.ProjectOvertimeRule In porlist
                            If p.isOnlyLeave = "1" AndAlso p.isShow = "0" Then '人事管理員申請之僅限補休加簽
                                Dim pr18m As New FSC.Logic.CPAPR18M
                                pr18m.Orgcode = p.Orgcode
                                pr18m.PRGUID = p.FlowId
                                pr18m.DepartId = p.DepartId
                                pr18m.PRNAME = p.UserName
                                pr18m.PRIDNO = p.IdCard
                                pr18m.PRCARD = p.IdCard
                                pr18m.PRATYPE = "2"
                                pr18m.PRADDD = p.StartDate
                                pr18m.PRADDE = p.EndDate
                                pr18m.PRSTIME = p.Start_time
                                pr18m.PRETIME = p.End_time
                                pr18m.PRADDH = p.LeaveHours
                                pr18m.isOnlyLeave = "1"
                                pr18m.InsertCPAPR18M()
                            End If
                        Next
                    Else
                        Dim pr18m As New FSC.Logic.CPAPR18M
                        pr18m.DeleteCPAPR18MByGUID(flow.FlowId)
                    End If

                ElseIf t = "010" Then
                    '值日(夜)代(換)

                    Dim dc As New FSC.Logic.DutyChange()
                    Dim ss As New FSC.Logic.ScheduleSetting()

                    dc.flow_id = flow.FlowId
                    If Not ss.updateByDutyChange(dc.getDataByFid(), isPlus) Then
                        Throw New FlowException("更新排班資料設定檔失敗!")
                    End If

                    dc.Apply_Orgcode = flow.Orgcode
                    dc.flow_id = flow.FlowId
                    Dim dt As DataTable = dc.getDataByFid()
                    For Each dr As DataRow In dt.Rows
                        Dim ddt As DataTable = New FSC.Logic.Schedule().GetData(dr("Apply_Orgcode").ToString(), dr("Shift_Schedule_id").ToString())

                        Dim Reason As String = ""
                        Reason &= "申請代(換)類別：" + IIf(dr("Duty_type").ToString() = "1", "代值", "換值") + "<br />"
                        Reason &= "申請代(換)值人員：" + dr("Apply_Username").ToString() + "<br />"
                        Reason &= "指定代(換)值人員：" + dr("Shift_Username").ToString() + "<br />"
                        Reason &= "代(換)值班日期：" + dr("Shift_Dutydate").ToString() + "<br />"
                        Reason &= "代(換)換班別：" + ddt.Rows(0)("name").ToString() + "<br />"
                        Reason &= "事由：" + dr("Duty_reason").ToString()

                        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(dr("Apply_idcard").ToString())
                        Dim FromMail As String = ConfigurationManager.AppSettings("SysMail")
                        Dim FromName As String = ConfigurationManager.AppSettings("SysName")
                        Dim ToMail As String = psn.Email
                        Dim ToName As String = psn.UserName
                        Dim Subject As String = "值班通知"

                        CommonFun.SendMail(FromMail, ToMail, FromName, ToName, Subject, Reason + "已" + IIf(isPlus, "批核", "撤銷") + "完成!請重新確認排班表!")

                        psn = New FSC.Logic.Personnel().GetObject(dr("Shift_idcard").ToString())
                        ToMail = psn.Email
                        ToName = psn.UserName

                        CommonFun.SendMail(FromMail, ToMail, FromName, ToName, Subject, Reason + "已" + IIf(isPlus, "批核", "撤銷") + "完成!請重新確認排班表!")
                    Next
                End If
            End If
        End Sub


#Region "最後批核同意時，依假別做其它動作(含撤銷差假)"


        Protected Sub RunLastLeaveByOtherType(ByVal leaveMain As FSC.Logic.LeaveMain, ByVal isPlus As Boolean)

            If leaveMain.LeaveType = "04" Then
                Dim pr18m As New FSC.Logic.CPAPR18M()
                Dim lmmList As List(Of FSC.Logic.LeaveMainMapping) = New FSC.Logic.LeaveMainMapping().GetObjects(leaveMain.Orgcode, leaveMain.FlowId)
                For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                    Dim ps19m As New FSC.Logic.CPAPS19M()
                    ps19m.Orgcode = lmm.Orgcode
                    ps19m.PSIDNO = lmm.Idcard
                    ps19m.PSCARD = lmm.Idcard
                    ps19m.PSBREAKD = lmm.StartDate
                    ps19m.PSBREAKDE = lmm.EndDate
                    ps19m.PSBREAKH = lmm.LeaveHours
                    ps19m.PSSTIME = lmm.StartTime
                    ps19m.PSETIME = lmm.EndTime
                    ps19m.PSADDD = lmm.ApplyDateb
                    ps19m.PSADDE = lmm.ApplyDatee
                    ps19m.PSOVSTIME = lmm.ApplyTimeb
                    ps19m.PSOVETIME = lmm.ApplyTimee
                    ps19m.InsertCPAPS19M()

                    Dim PRPAYH As Integer = IIf(isPlus, ps19m.PSBREAKH, 0 - ps19m.PSBREAKH)
                    '更新已休時數
                    If pr18m.UpdatePRPAYH(PRPAYH, ps19m.PSCARD, ps19m.PSADDD, ps19m.PSOVSTIME) Then
                        Throw New FlowException("更新回加班資料檔失敗!")
                    End If
                Next


            ElseIf leaveMain.LeaveType = "20" Then
                Dim pp16m As New FSC.Logic.CPAPP16M()
                Dim lmmList As List(Of FSC.Logic.LeaveMainMapping) = New FSC.Logic.LeaveMainMapping().GetObjects(leaveMain.Orgcode, leaveMain.FlowId)
                For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                    Dim px24m As New FSC.Logic.CPAPX24M()
                    px24m.Orgcode = lmm.Orgcode
                    px24m.PXIDNO = lmm.Idcard
                    px24m.PXCARD = lmm.Idcard
                    px24m.PXBREAKD = lmm.StartDate
                    px24m.PXBREAKDE = lmm.EndDate
                    px24m.PXBREAKH = lmm.LeaveHours
                    px24m.PXSTIME = lmm.StartTime
                    px24m.PXETIME = lmm.EndTime
                    px24m.PXADDD = lmm.ApplyDateb
                    px24m.PXADDE = lmm.ApplyDatee
                    px24m.PXTIMEB = lmm.ApplyTimeb
                    px24m.PXTIMEE = lmm.ApplyTimee
                    px24m.InsertCPAPX24M()

                    Dim PPPAYH As Integer = IIf(isPlus, px24m.PXBREAKH, 0 - px24m.PXBREAKH)
                    '更新已領已休時數
                    If Not pp16m.UpdatePPPAYH(PPPAYH, px24m.PXCARD, "1", px24m.PXADDD, px24m.PXTIMEB) Then
                        Throw New FlowException("更新回出差資料檔失敗!")
                    End If
                Next


            ElseIf leaveMain.LeaveType = "32" Then

                Dim lmmList As List(Of FSC.Logic.LeaveMainMapping) = New FSC.Logic.LeaveMainMapping().GetObjects(leaveMain.Orgcode, leaveMain.FlowId)
                For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                    Dim ss As New FSC.Logic.ScheduleSetting()
                    Dim restHours As Integer = IIf(isPlus, lmm.LeaveHours, 0 - lmm.LeaveHours)
                    If Not ss.UpdateRestHours(lmm.Orgcode, lmm.Idcard, lmm.ApplyDateb, restHours) Then
                        Throw New FlowException("更新回值班資料檔失敗!")
                    End If
                Next

            End If
        End Sub
        Protected Sub RunLastLeaveByLeaveType(ByVal leaveMain As FSC.Logic.LeaveMain, ByVal isPlus As Boolean)
            Dim leaveTable As String = New SYS.Logic.LeaveType().GetLeaveTable(leaveMain.LeaveType)

            If isPlus Then
                Select Case leaveTable
                    Case LeaveType.LeaveTable.CPAPO15M
                        Dim po15m As New FSC.Logic.CPAPO15M()
                        po15m.Orgcode = leaveMain.Orgcode
                        po15m.POGUID = leaveMain.FlowId
                        po15m.DepartId = leaveMain.DepartId
                        po15m.POIDNO = leaveMain.IdCard
                        po15m.POCARD = leaveMain.IdCard
                        po15m.PONAME = leaveMain.UserName
                        po15m.POVTYPE = leaveMain.LeaveType.ToString().PadLeft(2, "0")
                        po15m.POVDATEB = leaveMain.StartDate
                        po15m.POVDATEE = leaveMain.EndDate
                        po15m.POVTIMEB = leaveMain.StartTime
                        po15m.POVTIMEE = leaveMain.EndTime
                        po15m.POVDAYS = FSC.Logic.Content.ConvertDayHours(leaveMain.LeaveHours)
                        po15m.POREMARK = leaveMain.Reason
                        po15m.POUSERID = leaveMain.Change_userid
                        po15m.POUPDATE = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(leaveMain.Change_date)
                        po15m.InsertCPAPO15M()

                        RunLastLeaveByOtherType(leaveMain, isPlus)

                        insertAgent(leaveMain)

                        ToGoogleCalendar(leaveMain)

                    Case LeaveType.LeaveTable.CPAPP16M
                        Dim pp16m As New FSC.Logic.CPAPP16M()
                        pp16m.Orgcode = leaveMain.Orgcode
                        pp16m.PPGUID = leaveMain.FlowId
                        pp16m.DepartId = leaveMain.DepartId
                        pp16m.PPIDNO = leaveMain.IdCard
                        pp16m.PPCARD = leaveMain.IdCard
                        pp16m.PPNAME = leaveMain.UserName
                        pp16m.PPBUSDATEB = leaveMain.StartDate
                        pp16m.PPBUSDATEE = leaveMain.EndDate
                        pp16m.PPTIMEB = leaveMain.StartTime
                        pp16m.PPTIMEE = leaveMain.EndTime
                        pp16m.PPBUSDH = FSC.Logic.Content.ConvertDayHours(leaveMain.LeaveHours)
                        pp16m.PPBUSPLACE = leaveMain.Place
                        pp16m.PPBUSTYPE = IIf(leaveMain.LeaveType = "05", "1", "2")
                        pp16m.PPHOLIDAY = leaveMain.HolidayOfficalFlag
                        pp16m.PPHDAY = FSC.Logic.Content.ConvertDayHours(leaveMain.HolidayHours)
                        pp16m.PPREASON = leaveMain.Reason
                        pp16m.PPUSERID = leaveMain.Change_userid
                        pp16m.PPUPDATE = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(leaveMain.Change_date)
                        pp16m.InsertCPAPP16M()

                        insertAgent(leaveMain)

                        ToGoogleCalendar(leaveMain)

                    Case LeaveType.LeaveTable.CPAPR18M
                        If leaveMain.isCard = "0" Then '不需檢核刷卡
                            Dim pr18m As New FSC.Logic.CPAPR18M()
                            pr18m.Orgcode = leaveMain.Orgcode
                            pr18m.PRGUID = leaveMain.FlowId
                            pr18m.DepartId = leaveMain.DepartId
                            pr18m.PRNAME = leaveMain.UserName
                            pr18m.PRATYPE = IIf(leaveMain.LeaveType = "80", "1", "2")
                            pr18m.PRIDNO = leaveMain.IdCard
                            pr18m.PRCARD = leaveMain.IdCard
                            pr18m.PRADDD = leaveMain.StartDate
                            pr18m.PRADDE = leaveMain.EndDate
                            pr18m.PRSTIME = leaveMain.StartTime
                            pr18m.PRETIME = leaveMain.EndTime
                            pr18m.PRADDH = leaveMain.LeaveHours
                            pr18m.isOnlyLeave = leaveMain.isOnlyLeave
                            pr18m.CheckType = leaveMain.CheckType
                            'PRPAYH  '已休時數
                            'PRMNYH  '已領時數
                            pr18m.InsertCPAPR18M()
                        End If
                End Select

            Else
                '撤銷差假

                Select Case leaveTable
                    Case LeaveType.LeaveTable.CPAPO15M
                        Dim po15m As New FSC.Logic.CPAPO15M()
                        po15m.DeleteCPAPO15MByGUID(leaveMain.FlowId, leaveMain.Orgcode)

                        RunLastLeaveByOtherType(leaveMain, isPlus)
                    Case LeaveType.LeaveTable.CPAPP16M
                        Dim pp16m As New FSC.Logic.CPAPP16M()
                        pp16m.DeleteCPAPP16MByGUID(leaveMain.FlowId, leaveMain.Orgcode)

                    Case LeaveType.LeaveTable.CPAPR18M
                        Dim pr18m As New FSC.Logic.CPAPR18M()
                        pr18m.DeleteCPAPR18MByGUID(leaveMain.FlowId, leaveMain.Orgcode)

                End Select

            End If

            Select Case leaveTable
                Case LeaveType.LeaveTable.CPAPO15M, LeaveType.LeaveTable.CPAPP16M
                    Dim Today As String = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd")
                    If leaveMain.StartDate <= Today Then
                        '執行刷卡轉出勤
                        RunPhToPk(leaveMain.Orgcode, leaveMain.DepartId, leaveMain.IdCard, leaveMain.StartDate, IIf(leaveMain.EndDate > Today, Today, leaveMain.EndDate))
                    End If
            End Select
        End Sub
#End Region

#Region "執行刷卡轉出勤"
        Protected Sub RunPhToPk(ByVal Orgcode As String, _
                                ByVal depart_id As String, _
                                ByVal id_card As String, _
                                ByVal sdate As String, _
                                ByVal edate As String)

            If sdate < FSCPLM.Logic.DateTimeInfo.GetRocDate(Now) Then
                'hsien 20130225
                'Dim bll As New FSC3301Bll()
                'bll.transfer(sdate, edate, depart_id, "", id_card, "", Orgcode, p2kconnstring)

                Dim bll As New FSC.Logic.FSC4202()
                bll.Transfer(Orgcode, depart_id, id_card, id_card, sdate, edate)
            End If

        End Sub
#End Region

#Region "寫入代理資料"
        Public Sub insertAgent(ByVal leaveMain As FSC.Logic.LeaveMain)
            Dim a As EMP.Logic.Agent = New EMP.Logic.Agent
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
            f.GetObject(leaveMain.Orgcode, leaveMain.FlowId)

            a.Agent_idcard = f.DeputyIdcard
            a.Agent_Orgcode = f.DeputyOrgcode
            a.Id_card = f.ApplyIdcard
            a.Orgcode = f.Orgcode
            a.Agent_sdate = leaveMain.StartDate
            a.Agent_stime = leaveMain.StartTime
            a.Agent_edate = leaveMain.EndDate
            a.Agent_etime = leaveMain.EndTime
            a.Note_desc = leaveMain.Reason
            a.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Try
                a.insert()
            Catch ex As Exception
                Throw New FlowException("新增請假代理人資料失敗!")
            End Try
        End Sub
#End Region

#Region "同步至Google行事曆"
        Public Sub ToGoogleCalendar(ByVal leaveMain As FSC.Logic.LeaveMain)
            Dim ws As GoogleCalendarWebService.GoogleAPI = New GoogleCalendarWebService.GoogleAPI
            Dim lm As FSC.Logic.LeaveMain = New FSC.Logic.LeaveMain

            Try
                Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(leaveMain.IdCard)
                'Dim strUserID As String = psn.ADId + "@epa.gov.tw"
                Dim strUserID As String = "chotseng@epa.gov.tw"  '測試時使用承辦人的AD
                Dim Sdate As String = 1911 + CommonFun.getInt(leaveMain.StartDate.Substring(0, 3)) & leaveMain.StartDate.Substring(3)
                Dim Edate As String = 1911 + CommonFun.getInt(leaveMain.EndDate.Substring(0, 3)) & leaveMain.EndDate.Substring(3)
                Dim strStartTime As String = FSC.Logic.DateTimeInfo.ConvertToDisplay(Sdate) & " " & FSC.Logic.DateTimeInfo.ToDisplayTime(leaveMain.StartTime) & ":00"
                Dim strEndTime As String = FSC.Logic.DateTimeInfo.ConvertToDisplay(Edate) & " " & FSC.Logic.DateTimeInfo.ToDisplayTime(leaveMain.EndTime) & ":00"
                Dim strTitle As String = New SYS.Logic.LeaveType().GetLeaveName(leaveMain.LeaveType)
                Dim strDesc As String = leaveMain.Reason

                If psn.ADId <> "nayu" Then '馬昱特別不寫入
                    'ws.Post_Google_Calendar_Data(strUserID, strStartTime, strEndTime, strTitle, strDesc, "", "eod")
                End If

                lm.Orgcode = leaveMain.Orgcode
                lm.FlowId = leaveMain.FlowId
                lm.isToGoogleCalendar = "1"
                lm.updateGoogleCalendar()

            Catch ex As Exception
                Throw New FlowException("同步至Google行事曆失敗!")
            End Try
        End Sub
#End Region
    End Class
End Namespace