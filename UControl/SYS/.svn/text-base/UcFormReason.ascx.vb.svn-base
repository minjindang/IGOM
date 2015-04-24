Imports System.Data
Imports System.Collections.Generic
Imports FSC.Logic

Partial Class UControl_SYS_UcFormReason
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(value As String)
            hfFlowId.Value = value
            SetReason()
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(value As String)
            hfOrgcode.Value = value
        End Set
    End Property

    Public Property FormId() As String
        Get
            Return hfFormId.Value
        End Get
        Set(value As String)
            hfFormId.Value = value
            SetReason()
        End Set
    End Property
#End Region

    Public Sub SetReason()
        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(hfOrgcode.Value, hfFlowId.Value)
        If f Is Nothing Then Return

        If Not String.IsNullOrEmpty(hfFormId.Value) Then
            If hfFormId.Value.Substring(0, 3) = "001" Then '人事類申請
                Dim Reason As String = String.Empty

                If Right(hfFormId.Value, 3) = "001" Then '請假申請
                    Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(hfOrgcode.Value, hfFlowId.Value)
                    For Each lm As LeaveMain In lmList
                        Reason &= IIf(Not String.IsNullOrEmpty(Reason), "<br />", "") + "假別：" + New SYS.Logic.LeaveType().GetLeaveName(lm.LeaveType) + IIf(lm.LeaveType = "03", IIf(lm.RetainFlag = "1", "(今年)", "(保留)"), "") + "<br />"
                        Reason &= "請假期間：" + DateTimeInfo.ToDisplay(lm.StartDate, lm.StartTime) + " 至 " + DateTimeInfo.ToDisplay(lm.EndDate, lm.EndTime) + "<br />"
                        Reason &= "請假時間：" + getDayHours(lm.LeaveHours) + "<br />"
                        Reason &= "請假事由：" + lm.Reason + "<br />"
                        Reason &= "代理人員：" + f.DeputyName
                        If lm.LeaveType = "08" OrElse lm.LeaveType = "09" OrElse lm.LeaveType = "10" OrElse lm.LeaveType = "13" OrElse lm.LeaveType = "22" Then
                            Reason &= "<br />事實發生日：" + DateTimeInfo.ToDisplay(lm.OccurDate)
                        End If
                    Next
                ElseIf Right(hfFormId.Value, 3) = "003" Then '出差申請
                    Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(hfOrgcode.Value, hfFlowId.Value)
                    For Each lm As LeaveMain In lmList
                        Reason &= "出差期間：" + DateTimeInfo.ToDisplay(lm.StartDate, lm.StartTime) + " 至 " + DateTimeInfo.ToDisplay(lm.EndDate, lm.EndTime) + "<br />"
                        Reason &= "出差天數：" + getDayHours(lm.LeaveHours) + "<br />"
                        Reason &= "出差地點：" + IIf(lm.LocationFlag = "0", "國內", "國外") + "<br />"
                        Reason &= "出差事由：" + lm.Reason + "<br />"
                        Reason &= "代理人員：" + f.DeputyName
                    Next
                ElseIf Right(hfFormId.Value, 3) = "005" Then '加班/專案加班申請
                    Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(hfOrgcode.Value, hfFlowId.Value)
                    For Each lm As LeaveMain In lmList
                        Reason &= "加班日期：" + DateTimeInfo.ToDisplay(lm.StartDate, lm.StartTime) + " 至 " + DateTimeInfo.ToDisplay(lm.EndDate, lm.EndTime) + "<br />"
                        Reason &= "加班時數：" + getDayHours(lm.LeaveHours) + "<br />"
                        Reason &= "加班事由：" + lm.Reason + "<br />"
                    Next
                ElseIf Right(hfFormId.Value, 3) = "006" Then '刷卡補登申請
                    Dim dt As DataTable = New ForgotClockApply().GetDataByOrgFid(hfOrgcode.Value, hfFlowId.Value)
                    For Each dr As DataRow In dt.Rows
                        Reason &= "刷卡日期：" + DateTimeInfo.ToDisplay(dr("Forgot_date").ToString(), dr("Forgot_time").ToString()) + "<br />"
                        Reason &= "卡別：" + IIf(dr("Card_type").ToString() = "A", "上班卡", "下班卡") + "<br />"
                        Reason &= "補登事由：" + dr("Reason").ToString()
                    Next
                ElseIf Right(hfFormId.Value, 3) = "008" Then '敘獎申請
                    Dim dt As DataTable = New RewordMain().getDataByFid(hfFlowId.Value)
                    For Each dr As DataRow In dt.Rows
                        Reason &= "提報單位：" + New Org().GetDepartName(dr("Orgcode").ToString(), dr("Depart_id").ToString()) + "<br />"
                        Reason &= "提報日期：" + DateTimeInfo.ToDisplay(("Apply_date").ToString()) + "<br />"
                        Reason &= "敘獎事由：" + dr("Reason").ToString()
                    Next
                ElseIf Right(hfFormId.Value, 3) = "009" OrElse Right(hfFormId.Value, 3) = "013" Then '專簽加班簽核
                    Dim dt As DataTable = New ProjectOvertimeRule().GetDistinctDataByOrgFid(hfOrgcode.Value, hfFlowId.Value)
                    For Each dr As DataRow In dt.Rows
                        Reason &= "專案代號：" + dr("Project_code").ToString() + "<br />"
                        Reason &= "專案名稱：" + dr("Project_name").ToString() + "<br />"
                        Reason &= "專案說明：" + dr("Project_desc").ToString() + "<br />"
                        Reason &= "專案類別：" + New SYS.Logic.CODE().GetDataDESC("023", "029", dr("Project_kind").ToString()) + "<br />"
                        Reason &= "專案加班起(迄)日：" + DateTimeInfo.ToDisplay(dr("Start_date").ToString()) + " 至 " + DateTimeInfo.ToDisplay(dr("End_date").ToString())
                    Next
                ElseIf Right(hfFormId.Value, 3) = "010" Then '值日(夜)代(換)值申請
                    Dim d As DutyChange = New DutyChange
                    d.Apply_Orgcode = hfOrgcode.Value
                    d.flow_id = hfFlowId.Value
                    Dim dt As DataTable = d.getDataByFid()
                    For Each dr As DataRow In dt.Rows
                        Dim ddt As DataTable = New Schedule().GetData(dr("Apply_Orgcode").ToString(), dr("Shift_Schedule_id").ToString())
                        Dim ddt2 As DataTable = New Schedule().GetData(dr("Apply_Orgcode").ToString(), dr("Schedule_id").ToString())
                        Reason &= "申請代(換)類別：" + IIf(dr("Duty_type").ToString() = "1", "代值", "換值") + "<br />"
                        Reason &= "申請代(換)值人員：" + dr("Apply_Username").ToString() + "<br />" 
                        Reason &= "指定代(換)值人員：" + dr("Shift_Username").ToString() + "<br />"
                        If (dr("Duty_type").ToString() <> "1") Then 
                            Reason &= "原值班日期：" + dr("Original_Dutydate").ToString() + "<br />"
                        End If 
                        Reason &= "代(換)值班日期：" + dr("Shift_Dutydate").ToString() + "<br />"
                        If (dr("Duty_type").ToString() <> "1") Then 
                            Reason &= "原班別：" + IIf(Not IsNothing(ddt2), ddt2.Rows(0)("name").ToString(), "") + "<br />"
                        End If
                        Reason &= "代(換)換班別：" + ddt.Rows(0)("name").ToString() + "<br />"
                        Reason &= "事由：" + dr("Duty_reason").ToString()
                    Next
                ElseIf Right(hfFormId.Value, 3) = "011" Then '在職/服務中文證明申請
                    Dim list As List(Of WorkserviceProof) = New FSC.Logic.WorkserviceProof().GetObjects(hfOrgcode.Value, hfFlowId.Value)
                    For Each w As WorkserviceProof In list
                        Reason &= "申請種類：" + New SYS.Logic.CODE().GetDataDESC("023", "010", w.ApplyType) + "<br />"
                        Reason &= "申請份數：" + w.ApplyCopies + "<br />"
                        Reason &= "用途：" + w.Purpose
                    Next
                Else
                    Reason = f.Reason
                End If
                Dim lmList2 As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(hfOrgcode.Value, hfFlowId.Value)
                For Each lm As LeaveMain In lmList2
                    If lm.InterTravelFlag = "1" Then
                        Reason &= "<br />" + "(本筆有申請國旅卡)"
                    End If
                Next
                lbReason.Text = Reason
            Else
                lbReason.Text = f.Reason
            End If
        End If
    End Sub

    Public Function getDayHours(ByVal leave_hour As Integer) As String
        Dim dayHours As String = String.Empty

        Dim i As Double = Content.ConvertDayHours(leave_hour)

        If i < 1 Then
            If i = 0 Then
                dayHours = "0小時"
            Else
                dayHours = i.ToString().Split(".")(1) + "小時"
            End If
        Else
            If i.ToString().Split(".").Length > 1 Then
                dayHours = i.ToString().Split(".")(0) + "天" + i.ToString().Split(".")(1) + "小時"
            Else
                dayHours = i.ToString() + "天"
            End If
        End If

        Return dayHours
    End Function
End Class
