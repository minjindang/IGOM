Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1101_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkConfirm()
        If IsPostBack Then
            Return
        End If
        initData()
        ShowReSendData()
    End Sub

    Protected Sub ShowReSendData()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then
            cbSubmit.Text = "確認"
            cbBack.Visible = True

            Dim list As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(org, fid)

            Dim isDeputyAgree As Boolean = False
            If Request.QueryString("url") = "FSC3116" Then
                Dim ddt As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(org, fid)
                For Each dr As DataRow In ddt.Rows
                    If dr("Last_idcard").ToString().Equals(f.DeputyIdcard) Then
                        If dr("Agree_flag").ToString().Equals("1") Then
                            isDeputyAgree = True
                        End If
                    End If
                Next
            End If

            Dim i As Integer = 1
            For Each lm As FSC.Logic.LeaveMain In list

                If list.Count = i Then
                    UcLeaveMember.Depart_id = lm.DepartId
                    UcLeaveMember.Apply_id = lm.IdCard
                    bindLeaveData()
                    ddlLeave_type.SelectedValue = lm.LeaveType
                    changeTableMode(lm.LeaveType)
                    cbBossAgree_flag.Checked = IIf(lm.BossAgree_flag = "1", True, False)
                    bindLeaveOtherData()
                    rblLeave_ngroup.DataBind()
                    rblLeave_ngroup.SelectedValue = lm.LeaveNgroup
                    rblLeave_ngroup_SelectedIndexChanged(Nothing, Nothing)
                    bindDeputy()
                    UcLeaveDeputy.Orgcode = f.DeputyOrgcode
                    UcLeaveDeputy.DepartId = f.DeputyDepartid
                    UcLeaveDeputy.IdCard = f.DeputyIdcard
                    rblretainFlag.SelectedValue = lm.RetainFlag
                    rblLocationFlag.SelectedValue = lm.LocationFlag
                    ShowControlByRetainLocation()
                    tbplace.Text = lm.Place
                    'cbxChinaFlag.Checked = IIf(lm.ChinaFlag = "1", True, False)
                    rblChinaFlag.SelectedValue = lm.ChinaFlag
                    ddlTarget.SelectedValue = lm.Target
                    UcDate.Text = lm.OccurDate
                    ddlBabyDays.SelectedValue = lm.BabyDays
                    tbReason.Text = lm.Reason
                    rblTravel.SelectedValue = lm.InterTravelFlag
                    If lm.LeaveType = "03" AndAlso lm.InterTravelFlag = "1" Then
                        'cbl.SelectedValue = "Travel"
                        'Dim script As String
                        'script = "<script type='text/javascript'>showCbToChina();</script>"
                        'Dim P As System.Web.UI.Page = Me
                        'P.ClientScript.RegisterStartupScript(GetType(String), "", script)
                        Travel.Visible = True
                        rblTravel.Items(0).Selected = True
                    End If
                End If

                If lm.LeaveNgroup = "A1" Then
                    UcLeaveDate.Start_date = lm.StartDate
                    UcLeaveDate.End_date = lm.EndDate
                    UcLeaveDate.Start_time = lm.StartTime
                    UcLeaveDate.End_time = lm.EndTime

                    If isDeputyAgree Then
                        ddlLeave_type.Enabled = False
                        rblLeave_ngroup.Enabled = False
                        UcLeaveMember.Enabled = False
                        UcLeaveDeputy.Enabled = False
                        UcLeaveDate.Enabled = False
                    End If
                Else
                    If i > 1 Then
                        InsertGVRow(i - 2)
                    End If

                    Dim UcLeaveDate As UControl_UcLeaveDate = CType(gv.Rows(i - 1).FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                    UcLeaveDate.Start_date = lm.StartDate
                    UcLeaveDate.End_date = lm.EndDate
                    UcLeaveDate.Start_time = lm.StartTime
                    UcLeaveDate.End_time = lm.EndTime

                    If isDeputyAgree Then
                        ddlLeave_type.Enabled = False
                        rblLeave_ngroup.Enabled = False
                        UcLeaveMember.Enabled = False
                        UcLeaveDeputy.Enabled = False
                        UcLeaveDate.Enabled = False
                    End If
                End If
                i += 1
            Next
        UcAttachment.BindUploadFile(org, fid)
        bindMemoDesc()
        End If
    End Sub
#Region "confirm 判斷"
    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim ym As String = Request.QueryString("ym")

        '按了確定要執行的程式碼
        If target = "LeaveTypeConfirm" Then
            If argument = "True" Then
                ViewState.Add("PASS_LIMIT", True)
                Submit()
            End If
        End If

        If target = "ctl00_ContentPlaceHolder1_UcDate_tbDate" Then
            bindMemoDesc()
            SetLeaveDate()
        End If

        If target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbStart_date" OrElse _
           target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbStart_time" OrElse _
           target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbEnd_date" OrElse _
           target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbEnd_time" Then
            DoAuto()
        End If
    End Sub

    Protected Sub DoAuto()
        If Not String.IsNullOrEmpty(UcLeaveDate.Start_date) AndAlso Not String.IsNullOrEmpty(UcLeaveDate.Start_time) AndAlso _
           Not String.IsNullOrEmpty(UcLeaveDate.End_date) AndAlso Not String.IsNullOrEmpty(UcLeaveDate.End_time) Then

            Dim hours As Integer = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, UcLeaveDate.End_date, UcLeaveDate.Start_time, UcLeaveDate.End_time, UcLeaveMember.Apply_id)
            If ddlLeave_type.SelectedValue = "04" Then '加班補休
                AutoOvertime(hours)
            ElseIf ddlLeave_type.SelectedValue = "20" Then '公差補休
                AutoBusiness(hours)
            ElseIf ddlLeave_type.SelectedValue = "32" Then '值日補休
                AutoSchedule(hours)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Postback的詢問視窗
    ''' </summary>
    ''' <param name="Message">訊息文字</param>
    ''' <param name="TrueScript">回應 true 時要執行的用戶端指令碼</param>
    ''' <param name="FalseScript">回應 false 時要執行的用戶端指令碼</param>
    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub

    Public Sub AutoOvertime(ByVal hours As Integer)
        For Each gvr As GridViewRow In gvOvertime.Rows
            Dim NotApplyHours As Integer = CommonFun.getInt(CType(gvr.FindControl("gv_lbNotApplyHours"), Label).Text) '可申請時數
            Dim gv_tbPSBREAKH As TextBox = CType(gvr.FindControl("gv_tbPSBREAKH"), TextBox)

            If hours <> 0 Then
                If hours > NotApplyHours Then
                    gv_tbPSBREAKH.Text = NotApplyHours
                    gv_tbPSBREAKH.BackColor = Drawing.Color.Yellow
                    hours -= NotApplyHours
                Else
                    gv_tbPSBREAKH.Text = hours
                    gv_tbPSBREAKH.BackColor = Drawing.Color.Yellow
                    hours = 0
                End If
            Else
                gv_tbPSBREAKH.Text = ""
                gv_tbPSBREAKH.BackColor = Drawing.Color.White
            End If
        Next

        If hours > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "可補休時數不足!")
            BindOvertimeData()
        End If
    End Sub

    Public Sub AutoBusiness(ByVal hours As Integer)
        For Each gvr As GridViewRow In gvSchedule.Rows
            Dim PPHDAY As Integer = CommonFun.getInt(CType(gvr.FindControl("gv_lbPPHDAY"), Label).Text) '可申請時數
            Dim gv_tbPXBREAKH As TextBox = CType(gvr.FindControl("gv_tbPXBREAKH"), TextBox)

            If hours <> 0 Then
                If hours > PPHDAY Then
                    gv_tbPXBREAKH.Text = PPHDAY
                    hours -= PPHDAY
                Else
                    gv_tbPXBREAKH.Text = hours
                    hours = 0
                End If
            Else
                gv_tbPXBREAKH.Text = ""
            End If
        Next

        If hours > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "可補休時數不足!")
            BindBusinessData()
        End If
    End Sub

    Public Sub AutoSchedule(ByVal hours As Integer)
        For Each gvr As GridViewRow In gvSchedule.Rows
            Dim schedule_hours As Integer = CommonFun.getInt(CType(gvr.FindControl("gv_lbScheduleHours"), Label).Text) '可申請時數
            Dim gv_tbBreakHours As TextBox = CType(gvr.FindControl("gv_tbBreakHours"), TextBox)

            If hours <> 0 Then
                If hours > schedule_hours Then
                    gv_tbBreakHours.Text = schedule_hours
                    hours -= schedule_hours
                    gv_tbBreakHours.BackColor = Drawing.Color.Yellow
                Else
                    gv_tbBreakHours.Text = hours
                    gv_tbBreakHours.BackColor = Drawing.Color.Yellow
                    hours = 0
                End If
            Else
                gv_tbBreakHours.Text = ""
                gv_tbBreakHours.BackColor = Drawing.Color.White
            End If
        Next

        If hours > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "可補休時數不足!")
            BindScheduleData()
        End If
    End Sub

#End Region

#Region "初始/設定 控制項"

    Protected Sub rblretainFlag_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If rblretainFlag.SelectedValue = "0" OrElse rblLocationFlag.SelectedValue <> "0" Then
        '    'cbl.Visible = False
        '    'cbl.Items(0).Selected = False
        '    rblTravel.Visible = False
        '    rblTravel.Items(0).Selected = False
        '    rblTravel.Items(1).Selected = False
        'Else
        '    'cbl.Visible = True
        '    rblTravel.Visible = True
        'End If
        ShowControlByRetainLocation()
        bindMemoDesc()
    End Sub

    Protected Sub rblLocationFlag_SelectedIndexChanged(sender As Object, e As EventArgs)
        ShowControlByRetainLocation()
    End Sub

    Protected Sub ShowControlByRetainLocation()
        If rblLocationFlag.SelectedValue = "1" Then
            sp1.Visible = True
        Else
            sp1.Visible = False
            rblChinaFlag.Items(0).Selected = False
            rblChinaFlag.Items(1).Selected = False
        End If

        If rblLocationFlag.SelectedValue = "0" AndAlso rblretainFlag.SelectedValue = "1" Then
            rblTravel.Visible = True
        Else
            rblTravel.Visible = False
            rblTravel.Items(0).Selected = False
            rblTravel.Items(1).Selected = False
        End If
    End Sub

    Protected Sub initData()
        UcLeaveMember.Apply_id = LoginManager.UserId
        bindLeaveData()
        bindLeaveOtherData()
        bindBabyDaysData()
        bindDeputyDep()
        bindDeputy()
        'rblLocationFlag.Attributes.Add("onclick", "javascript:showCbToChina();")
        'rblLeave_ngroup.Attributes.Add("onclick", "javascript:chgDateTable();")
        InitLeaveDate()
    End Sub

    Protected Sub SettingUcLeaveDate(ByVal Apply_id As String, ByVal StartDate As String, ByVal EndDate As String, ByVal StartTime As String, ByVal EndTime As String, ByVal isDefault As Boolean)
        If Not isDefault Then
            UcLeaveDate.IsDefault = isDefault
            UcLeaveDate.Start_date = StartDate
            UcLeaveDate.End_date = EndDate
            UcLeaveDate.Start_time = StartTime
            UcLeaveDate.End_time = EndTime
            UcLeaveDate.Apply_id = Apply_id
        End If
    End Sub

    Protected Sub bindDeputyDep()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        UcLeaveDeputy.Orgcode = orgcode
        UcLeaveDeputy.DepartId = depart_id
    End Sub

    Protected Sub bindDeputy()
        UcLeaveDeputy.ApplyIdcard = UcLeaveMember.Apply_id
    End Sub

    Protected Sub bindBabyDaysData()
        ddlBabyDays.DataTextField = "CODE_DESC1"
        ddlBabyDays.DataValueField = "CODE_NO"
        ddlBabyDays.DataSource = New SYS.Logic.CODE().GetData("023", "032")
        ddlBabyDays.DataBind()
    End Sub

    Protected Sub bindLeaveData()
        ddlLeave_type.DataSource = New SYS.Logic.LeaveType().GetLeaveType(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), "A")
        ddlLeave_type.DataBind()
        ddlLeave_type.Items.Insert(0, New ListItem("請選擇", ""))
        changeTableMode(ddlLeave_type.SelectedValue)
    End Sub

    Protected Sub ddlLeave_type_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLeave_type.DataBound
        ControlLeaveType()
    End Sub

    Protected Sub ControlLeaveType()
        Dim idCard As String = UcLeaveMember.Apply_id
        Dim psn As New FSC.Logic.Personnel()
        Dim PESEX As String = psn.GetColumnValue("PESEX", idCard)
        Dim employee_type As String = psn.GetColumnValue("Employee_type", idCard)
        Dim lt As New SYS.Logic.LeaveType()
        Dim orgcode As String = LoginManager.OrgCode

        Dim mdt As DataTable = lt.GetDataBySexFlag(orgcode, "1")    '男性獨有假別
        Dim fdt As DataTable = lt.GetDataBySexFlag(orgcode, "2")    '女性獨有假別

        '依性別, 新增或刪除假別
        If PESEX = "1" Then
            For Each dr As DataRow In fdt.Rows
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue(dr("Leave_type").ToString()))
            Next
            'For Each dr As DataRow In mdt.Rows
            '    ddlLeave_type.Items.Add(New ListItem(dr("Leave_name").ToString(), dr("Leave_type").ToString()))
            'Next
        Else
            For Each dr As DataRow In mdt.Rows
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue(dr("Leave_type").ToString()))
            Next
            'For Each dr As DataRow In fdt.Rows
            '    ddlLeave_type.Items.Add(New ListItem(dr("Leave_name").ToString(), dr("Leave_type").ToString()))
            'Next
        End If


        '駐署人員
        If employee_type = "13" Then
            ddlLeave_type.Items.Clear()

            ddlLeave_type.Items.Add(New ListItem("事假", "01"))
            ddlLeave_type.Items.Add(New ListItem("病假", "02"))
            ddlLeave_type.Items.Add(New ListItem("公假", "06"))
            ddlLeave_type.Items.Add(New ListItem("其他假", "19"))

        End If

        '公務人員無五一勞動節
        If employee_type = "1" _
           Or employee_type = "6" _
           Or employee_type = "7" _
           Or employee_type = "9" _
           Or employee_type = "11" _
           Or employee_type = "13" Then '2,3,4,5,8,10,12,14,15

            If ddlLeave_type.Items.Contains(New ListItem("五一勞動節", "34")) Then
                ddlLeave_type.Items.Remove(ddlLeave_type.Items.FindByValue("34"))   '五一勞動節
            End If
        End If

        hfApplyEmployeeType.Value = employee_type
    End Sub

    Protected Sub ddlLeave_type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        bindLeaveOtherData()
        bindBabyDaysData()
        bindDeputyDep()
        bindDeputy()
        rblLeave_ngroup_SelectedIndexChanged(sender, e)
        InitLeaveDate()
        changeTableMode(ddlLeave_type.SelectedValue)
        lbLimit.Text = ""
        'tbReason.Text = ""

        UcLeaveDate.Start_date = DateTimeInfo.GetRocDate(Now)
        UcLeaveDate.End_date = DateTimeInfo.GetRocDate(Now)

        bindConfirmMsg()
        SetLeaveDate()
        DoAuto()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.EmployeeType) = "13" Then
            rblLeave_ngroup.DataBind()
        End If
    End Sub

    Protected Sub bindConfirmMsg()
        Dim Orgocde As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim psn As Personnel = New Personnel().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        '假別規則
        Dim ls As FSC.Logic.LeaveSetting = New FSC.Logic.LeaveSetting().GetObject(Orgocde, psn.Pekind, ddlLeave_type.SelectedValue, psn.EmployeeType)
        If ls IsNot Nothing AndAlso ls.Ifbatch_apply = "1" Then
            hfConfrimMsg.Value = ddlLeave_type.SelectedItem.Text + "需一次請畢，是否確定送申請?"
        Else
            hfConfrimMsg.Value = ""
        End If
    End Sub

    Protected Sub bindLeaveOtherData()
        'cbl.DataSource = New FSC.Logic.LeaveNGroup().GetLeaveOtherData(ddlLeave_type.SelectedValue)
        'cbl.DataBind()
        If ddlLeave_type.SelectedValue = "03" Then
            Dim Inter_travel_hours As Double = New LeaveMain().getInter_travel(UcLeaveMember.Apply_id, (Now.Year - 1911).ToString())
            If Content.ConvertDayHours(Inter_travel_hours) >= 14 Then
                lbInter_travel.Text = "註：您國民旅遊卡休假已超過14天。"
                lbInter_travel.Visible = True
                'cbl.Visible = False
                rblTravel.Visible = False
                rblTravel.Items(0).Selected = False
                rblTravel.Items(1).Selected = False
            Else
                lbInter_travel.Text = ""
                lbInter_travel.Visible = False
                'cbl.Visible = True
                rblTravel.Visible = True
            End If
        Else
            lbInter_travel.Text = ""
            lbInter_travel.Visible = False
            'cbl.Visible = False
            rblTravel.Visible = False
            rblTravel.Items(0).Selected = False
            rblTravel.Items(1).Selected = False
        End If
    End Sub

    Protected Sub rblLeave_ngroup_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblLeave_ngroup.DataBound
        rblLeave_ngroup.SelectedValue = "A1"
    End Sub


    Protected Sub bindLeaveType10ddl()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim employeeType As String = New FSC.Logic.Personnel().GetColumnValue("employee_Type", UcLeaveMember.Apply_id)
        Dim leaveKind As String = New FSC.Logic.Personnel().GetColumnValue("pekind", UcLeaveMember.Apply_id)
        Dim leaveType As String = ddlLeave_type.SelectedValue

        Dim code As New FSCPLM.Logic.SACode()
        Dim ls As New LeaveSetting()
        Dim lsd As New LeaveSettingDetail()
        Dim dt As DataTable = ls.GetDataByQuery(orgcode, leaveKind, leaveType, employeeType)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dt.Columns.Add("Code_desc1", GetType(String))
            dt.Columns.Add("Code_no", GetType(String))
            For Each dr As DataRow In dt.Rows
                dr("Code_desc1") = code.GetCodeDesc("023", "024", dr("Detail_code_id").ToString())
                dr("Code_no") = dr("Detail_code_id").ToString()
            Next
            ddlTarget.DataSource = dt
            ddlTarget.DataBind()
            ddlTarget.Items.Insert(0, New ListItem("請選擇", ""))
        End If

    End Sub


    Protected Sub changeTableMode(ByVal Leave_type As String)
        'ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "chgTableMode", "chgTableMode('" & Leave_type & "');", True)
        Travel.Visible = False
        tr2.Visible = False
        overtimeTr1.Visible = False
        overtimeTr2.Visible = False
        businessTr1.Visible = False
        businessTr2.Visible = False
        scheduleTr1.Visible = False
        scheduleTr2.Visible = False
        scheduleTr2.Visible = False
        sp1LocationFlag1.Visible = False
        sp1LocationFlag2.Visible = True
        spplace1.Visible = False
        spplace2.Visible = True
        cbBossAgree_flag.Visible = False

        If Leave_type = "04" Then
            overtimeTr1.Visible = True
            overtimeTr2.Visible = True
            BindOvertimeData()

        ElseIf Leave_type = "20" Then
            businessTr1.Visible = True
            businessTr2.Visible = True
            tr7.Visible = False
            BindBusinessData()

        ElseIf Leave_type = "32" Then
            scheduleTr1.Visible = True
            scheduleTr2.Visible = True
            BindScheduleData()

        ElseIf Leave_type = "08" Or Leave_type = "13" Or Leave_type = "22" Then
            tr6.Visible = False
            tr7.Visible = True
            cbCount.Visible = False
            cbCount2.Visible = False
            lbLimit2.Text = ""
            If Leave_type = "13" Then
                tr8.Visible = True
            End If
            If Leave_type = "08" Then
                cbBossAgree_flag.Visible = True
            End If
        ElseIf Leave_type = "09" Then
            tr6.Visible = False
            tr7.Visible = True
            cbCount.Visible = False
            cbCount2.Visible = True
            lbLimit.Text = ""
        ElseIf Leave_type = "10" Then
            tr6.Visible = True
            tr7.Visible = True
            cbCount.Visible = False
            cbCount2.Visible = False
            lbLimit2.Text = ""
            bindLeaveType10ddl()
        ElseIf Leave_type = "03" Then
            tr2.Visible = True
            Travel.Visible = True
            sp1LocationFlag2.Visible = False
            sp1LocationFlag1.Visible = True
            spplace2.Visible = False
            spplace1.Visible = True
        Else
            tr6.Visible = False
            tr7.Visible = False
            cbCount.Visible = False
            cbCount2.Visible = False
            lbLimit.Text = ""
            lbLimit2.Text = ""
            UcDate.Text = ""
        End If

        If hfApplyEmployeeType.Value = "13" Then
            tr1.Visible = False
            tr2.Visible = False
            tr3.Visible = False
            tr4.Visible = False
            trDeputy.Visible = False
        Else
            trDeputy.Visible = True
        End If
        bindMemoDesc()
    End Sub

    Protected Sub BindOvertimeData()
        Dim orgcode As String = LoginManager.OrgCode
        Dim Apply_id As String = UcLeaveMember.Apply_id
        Dim bll As New FSC.Logic.FSC1101()
        gvOvertime.DataSource = bll.GetOvertimeData(orgcode, Apply_id)
        gvOvertime.DataBind()
    End Sub

    Protected Sub BindBusinessData()
        Dim orgcode As String = LoginManager.OrgCode
        Dim Apply_id As String = UcLeaveMember.Apply_id
        Dim bll As New FSC.Logic.FSC1101()
        gvBusiness.DataSource = bll.GetBusinessData(orgcode, Apply_id)
        gvBusiness.DataBind()
    End Sub

    Protected Sub BindScheduleData()
        Dim orgcode As String = LoginManager.OrgCode
        Dim Apply_id As String = UcLeaveMember.Apply_id
        Dim bll As New FSC.Logic.FSC1101()
        gvSchedule.DataSource = bll.GetScheduleData(orgcode, Apply_id)
        gvSchedule.DataBind()
    End Sub

    Protected Sub UcLeaveMember_Apply_name_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcLeaveMember.Apply_name_ValueChanged
        bindMemoDesc()
        bindLeaveType10ddl()
        UcLeaveDate.Apply_id = UcLeaveMember.Apply_id   '重新指定申請人 設定 預設請假日期時間
        bindDeputy()

        hfApplyEmployeeType.Value = New FSC.Logic.Personnel().GetColumnValue("Employee_type", UcLeaveMember.Apply_id)
        'ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "chgDateTable", "chgTableMode('" + ddlLeave_type.SelectedValue + "');", True)
        bindLeaveData()
    End Sub

    Protected Sub ddlTarget_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTarget.SelectedIndexChanged
        bindMemoDesc()
    End Sub

    Protected Sub ddlBabyDays_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBabyDays.SelectedIndexChanged
        bindMemoDesc()
    End Sub

    Protected Sub rblLeave_ngroup_SelectedIndexChanged(sender As Object, e As EventArgs)
        'ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "chgDateTable", "chgDateTable();", True)
        If rblLeave_ngroup.Items.Count > 1 AndAlso rblLeave_ngroup.Items(1).Selected Then
            sigleDateTr.Visible = False
            multiDateTr1.Visible = True
            multiDateTr2.Visible = True
        Else
            sigleDateTr.Visible = True
            multiDateTr1.Visible = False
            multiDateTr2.Visible = False
        End If
    End Sub

    Protected Sub bindMemoDesc()
        '本sub 註解 by 修改FSC1101_01

        Dim idCard As String = UcLeaveMember.Apply_id
        Dim employee_type As String = New FSC.Logic.Personnel().GetColumnValue("employee_type", idCard)
        If employee_type = "13" Then
            lbDesc.Text = ""
            lbMemo.Text = ""
            Return
        End If


        'If PEMEMCOD = "4" And ddlLeave_type.SelectedValue = 3 Then
        '    If cbl.Items.Contains(New ListItem("國民旅遊卡", "Travel")) Then
        '        cbl.Items.Remove(cbl.Items.FindByValue("Travel"))   '國民旅遊卡
        '    End If
        'End If

        Dim Leave_type As String = ddlLeave_type.SelectedValue
        Dim ls As New FSC.Logic.LeaveSetting()

        lbDesc.Text = ls.getDesc(UcLeaveMember.Apply_id, Leave_type)

        If Leave_type = "08" Or Leave_type = "22" Then '婚假, 陪產假
            '依事實發生日統計假別目前總時數

            lbMemo.Text = ls.GetLimitDesc(UcLeaveMember.Apply_id, Leave_type, UcDate.Text)

            If Leave_type = "22" Then
                lbMemo.Text = lbMemo.Text & "需檢附相關證明文件例如出生證明影本。"
            End If

        ElseIf Leave_type = "10" Then   '喪假

            lbMemo.Text = ls.GetLimitDesc(UcLeaveMember.Apply_id, Leave_type, UcDate.Text, CommonFun.getInt(Me.ddlTarget.SelectedValue), 0)

        ElseIf Leave_type = "13" Then
            lbMemo.Text = ls.GetLimitDesc(UcLeaveMember.Apply_id, Leave_type, UcDate.Text, 0, CommonFun.getInt(Me.ddlBabyDays.SelectedValue))
        ElseIf Leave_type = "03" Then '休假
            Dim psn As Personnel = New Personnel().GetObject(UcLeaveMember.Apply_id)
            Dim PEHDAY As Double = CommonFun.getDouble(psn.Pehday)
            Dim PERDAY1 As Double = CommonFun.getDouble(psn.Perday1)
            Dim PERDAY2 As Double = CommonFun.getDouble(psn.Perday2)

            Dim limits As String = IIf(rblretainFlag.SelectedValue = "0", (PERDAY1 + PERDAY2).ToString(), PEHDAY.ToString())
            Dim hours As Double = 0

            Dim dt As DataTable = New LeaveMain().GetDataByYYYMM(UcLeaveMember.Apply_id, Leave_type, (Now.Year - 1911).ToString(), rblretainFlag.SelectedValue)
            For Each dr As DataRow In dt.Rows
                hours += CommonFun.getDouble(dr("Leave_hours"))
            Next

            Dim left_days As Double = Content.ConvertDayHours(Content.ConvertToHours(limits) - (hours))

            lbMemo.Text = "您" + rblretainFlag.SelectedItem.Text + "休假可請" + limits + "天，目前已請" + Content.ConvertDayHours(hours).ToString() + "天" + "剩餘" + left_days.ToString() + "天。"
        Else
            'ex:事假, 病假,  生理假, 家庭照顧假
            '依年月統計假別目前總時數
            lbMemo.Text = ls.GetLimitDesc(UcLeaveMember.Apply_id, Leave_type, UcLeaveDate.Start_date)
        End If

    End Sub
    'Protected Sub cbl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl.SelectedIndexChanged
    '    Dim chk As String = hfcbl.Value
    '    Dim cbl1 As CheckBoxList = sender
    '    For Each lt As ListItem In cbl.Items
    '        For i As Integer = 0 To chk.Split(";").Length - 1
    '            If lt.Selected Then
    '                If lt.Value <> Split(chk, ";")(i) Then
    '                    lt.Selected = True
    '                Else
    '                    lt.Selected = False
    '                End If

    '            End If
    '        Next

    '    Next
    '    hfcbl.Value = ""
    '    For i As Integer = 0 To cbl.Items.Count - 1
    '        If cbl.Items(i).Selected Then
    '            hfcbl.Value &= cbl.Items(i).Value & ";"
    '        End If
    '    Next
    '    hfcbl.Value = hfcbl.Value.Trim(";")
    'End Sub

    Protected Sub rblTravel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblTravel.SelectedIndexChanged
        hfcbl.Value = rblTravel.SelectedValue
    End Sub


    Protected Sub rblTimeType_SelectedIndexChanged(sender As Object, e As EventArgs)
        SetLeaveDate()
    End Sub

    '設定日期時間
    Protected Sub SetLeaveDate()
        If String.IsNullOrEmpty(UcLeaveDate.Start_date) Then
            UcLeaveDate.Start_date = DateTimeInfo.GetRocDate(Now)
        End If
        If String.IsNullOrEmpty(UcLeaveDate.End_date) Then
            UcLeaveDate.End_date = DateTimeInfo.GetRocDate(Now)
        End If

        Select Case rblTimeType.SelectedValue
            Case "1"
                CType(UcLeaveDate.FindControl("tbEnd_date"), TextBox).Enabled = False
                CType(UcLeaveDate.FindControl("tbStart_time"), TextBox).Enabled = False
                UcLeaveDate.Start_time = "0830"
                UcLeaveDate.End_time = "0930"
                UcLeaveDate.End_date = UcLeaveDate.Start_date
            Case "2"
                CType(UcLeaveDate.FindControl("tbEnd_date"), TextBox).Enabled = False
                CType(UcLeaveDate.FindControl("tbStart_time"), TextBox).Enabled = False
                CType(UcLeaveDate.FindControl("tbEnd_time"), TextBox).Enabled = False
                UcLeaveDate.Start_time = "0830"
                UcLeaveDate.End_time = "1230"
                UcLeaveDate.End_date = UcLeaveDate.Start_date

            Case "3"
                CType(UcLeaveDate.FindControl("tbEnd_date"), TextBox).Enabled = False
                CType(UcLeaveDate.FindControl("tbStart_time"), TextBox).Enabled = False
                CType(UcLeaveDate.FindControl("tbEnd_time"), TextBox).Enabled = False
                UcLeaveDate.Start_time = "1330"
                UcLeaveDate.End_time = "1730"
                UcLeaveDate.End_date = UcLeaveDate.Start_date

            Case Else
                UcLeaveDate.Enabled = True

                Dim ht As Hashtable = Content.getWorkTime(UcLeaveMember.Apply_id, UcLeaveDate.Start_date)
                UcLeaveDate.Start_time = ht("WORKTIMEB")
                UcLeaveDate.End_time = ht("WORKTIMEE")
        End Select
    End Sub

    Protected Sub rblChinaFlag_SelectedIndexChanged(sender As Object, e As EventArgs)
        If rblChinaFlag.SelectedValue = "1" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "應取得[赴大陸申請書]")
        End If
    End Sub
#End Region

#Region "Gridview 控制"
    Protected Sub InitLeaveDate()
        Dim dt As New DataTable
        dt.Columns.Add("Start_date", GetType(String))
        dt.Columns.Add("Start_Time", GetType(String))
        dt.Columns.Add("End_date", GetType(String))
        dt.Columns.Add("End_Time", GetType(String))
        Dim dr As DataRow = dt.NewRow
        dr("Start_date") = DateTimeInfo.GetRocTodayString("yyyyMMdd")
        dr("End_date") = DateTimeInfo.GetRocTodayString("yyyyMMdd")
        Dim ht As Hashtable = FSC.Logic.Content.getWorkTime(UcLeaveMember.Apply_id, DateTimeInfo.GetRocDate(Now))
        If ht IsNot Nothing AndAlso ht.Count > 0 Then
            dr("Start_Time") = ht("WORKTIMEB").ToString()
            dr("End_Time") = ht("WORKTIMEE").ToString()
        End If
        dt.Rows.Add(dr)
        ViewState("dt") = dt
        LeaveDateBind()
    End Sub

    Protected Sub LeaveDateBind()
        gv.DataSource = ViewState("dt")
        gv.DataBind()
    End Sub

    Protected Sub gv_cbInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowi As Integer = CType(CType(sender, Button).NamingContainer, GridViewRow).RowIndex
        InsertGVRow(rowi)
    End Sub

    Protected Sub InsertGVRow(ByVal rowi As Integer)
        Dim dt As DataTable = ViewState("dt")

        '把Gridview控制項裡的值放回DataTable
        Dim i As Integer = 0
        For Each gvr As GridViewRow In gv.Rows
            dt.Rows(i)("Start_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_date
            dt.Rows(i)("Start_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_time
            dt.Rows(i)("End_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_date
            dt.Rows(i)("End_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_time
            i += 1
        Next

        Dim ndt As New DataTable
        ndt = dt.Clone
        Dim ndr As DataRow

        i = 0
        For Each dr As DataRow In dt.Rows
            ndr = ndt.NewRow
            ndr("Start_date") = dr("Start_date")
            ndr("End_date") = dr("End_date")
            ndr("Start_Time") = dr("Start_Time")
            ndr("End_Time") = dr("End_Time")
            ndt.Rows.Add(ndr)
            If i = rowi Then
                ndr = ndt.NewRow
                ndr("Start_date") = "" 'dr("Start_date").ToString()
                ndr("End_date") = "" 'dr("End_date").ToString()
                ndr("Start_time") = dr("Start_time").ToString()
                ndr("End_time") = dr("End_time").ToString()
                ndt.Rows.Add(ndr)
            End If
            i += 1
        Next

        ViewState("dt") = ndt
        LeaveDateBind()
    End Sub

    Protected Sub gv_cbRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowi As Integer = CType(CType(sender, Button).NamingContainer, GridViewRow).RowIndex
        Dim dt As DataTable = ViewState("dt")

        '把Gridview控制項裡的值放回DataTable
        Dim i As Integer = 0
        For Each gvr As GridViewRow In gv.Rows
            dt.Rows(i)("Start_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_date
            dt.Rows(i)("End_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_date
            dt.Rows(i)("Start_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_time
            dt.Rows(i)("End_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_time
            i += 1
        Next
        If rowi <> 0 Then
            dt.Rows.RemoveAt(rowi)
        Else
            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "第一筆請假資料不能刪除!")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "alert('第一筆請假資料不能刪除!');", True)
            Return
        End If
        ViewState("dt") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("gv_lbNo"), Label).Text = e.Row.DataItemIndex + 1

            Dim ucdate As UControl_UcLeaveDate = CType(e.Row.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
            ucdate.Apply_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        End If
    End Sub

    Protected Sub gvOvertime_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOvertime.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lbPRADDH As Label = CType(e.Row.FindControl("gv_lbPRADDH"), Label)          '加班時數
            Dim lbPRPAYH As Label = CType(e.Row.FindControl("gv_lbPRPAYH"), Label)          '已休時數
            Dim lbPRMNYH As Label = CType(e.Row.FindControl("gv_lbPRMNYH"), Label)          '已領時數
            Dim lbPRATYPE As Label = CType(e.Row.FindControl("gv_lbPRATYPE"), Label)        '加班類型

            If lbPRATYPE.Text.Equals("1") Then
                lbPRATYPE.Text = "一般"
            ElseIf lbPRATYPE.Text.Equals("2") Then
                lbPRATYPE.Text = "專案"
            Else
                lbPRATYPE.Text = "大批"
            End If

            Dim tbBREAKH As TextBox = CType(e.Row.FindControl("gv_tbPSBREAKH"), TextBox)
            If CommonFun.ConvertToInt(lbPRADDH.Text) <= CommonFun.ConvertToInt(lbPRPAYH.Text) + CommonFun.ConvertToInt(lbPRMNYH.Text) Then
                tbBREAKH.Visible = False
            End If

            tbBREAKH.Attributes.Add("onchange", "changeBreakh('" & lbPRADDH.ClientID & "','" & lbPRPAYH.ClientID & "','" & lbPRMNYH.ClientID & "','" & tbBREAKH.ClientID & "')")

            Dim PRADDD As String = CType(e.Row.FindControl("gv_lbPRADDD"), Label).Text
            Dim dpraddd As Date = DateTimeInfo.GetPublicDate(PRADDD)
            Dim sixmonth As Date = dpraddd.AddMonths(6).AddDays(1)
            '可申請補休的日期期限：今日至六個月前的加班日期
            CType(e.Row.FindControl("gv_lbLIMIT"), Label).Text = (sixmonth.Year - 1911).ToString().PadLeft(3, "0") & sixmonth.Month.ToString().PadLeft(2, "0") & (sixmonth.Day).ToString().PadLeft(2, "0")

        End If
    End Sub


    Protected Sub gvBusiness_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvBusiness.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lbPPBUSDH As Label = CType(e.Row.FindControl("gv_lbPPBUSDH"), Label)          '合計日時數
            Dim lbPPHDAY As Label = CType(e.Row.FindControl("gv_lbPPHDAY"), Label)          '可休日期數
            Dim lbPPPAYH As Label = CType(e.Row.FindControl("gv_lbPPPAYH"), Label)          '己休時數

            Dim tbBREAKH As TextBox = CType(e.Row.FindControl("gv_tbPXBREAKH"), TextBox)
            If Content.ConvertToHours(CommonFun.ConvertToDouble(lbPPHDAY.Text)) <= CommonFun.ConvertToDouble(lbPPPAYH.Text) Then
                tbBREAKH.Visible = False
            End If

            CType(e.Row.FindControl("gv_lbPPBUSDH"), Label).Text = Content.ConvertToHours(CType(e.Row.FindControl("gv_lbPPBUSDH"), Label).Text)
            CType(e.Row.FindControl("gv_lbPPHDAY"), Label).Text = Content.ConvertToHours(CType(e.Row.FindControl("gv_lbPPHDAY"), Label).Text)
            CType(e.Row.FindControl("gv_lbPPPAYH"), Label).Text = CType(e.Row.FindControl("gv_lbPPPAYH"), Label).Text

            'hsien 2013/5/10 改用迄日顯示補休期限
            Dim PPBUSDATEE As String = CType(e.Row.FindControl("gv_lbPPBUSDATEE"), Label).Text
            Dim dPPBUSDATEE As Date = DateTimeInfo.GetPublicDate(PPBUSDATEE)
            Dim sixmonth As Date = dPPBUSDATEE.AddMonths(6).AddDays(1)
            '可申請補休的日期期限：今日至六個月前的加班日期
            CType(e.Row.FindControl("gv_lbLIMIT"), Label).Text = (sixmonth.Year - 1911).ToString().PadLeft(3, "0") & sixmonth.Month.ToString().PadLeft(2, "0") & (sixmonth.Day).ToString().PadLeft(2, "0")

        End If
    End Sub


    Protected Sub gvSchedule_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSchedule.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lbScheduleHours As Label = CType(e.Row.FindControl("gv_lbScheduleHours"), Label)           '可休日期數
            Dim lbRestHours As Label = CType(e.Row.FindControl("gv_lbRestHours"), Label)               '己休時數

            'Dim tbBreakHours As TextBox = CType(e.Row.FindControl("gv_tbBreakHours"), TextBox)
            'If CommonFun.ConvertToDouble(lbScheduleHours.Text) <= CommonFun.ConvertToDouble(lbRestHours.Text) Then
            '    tbBreakHours.Visible = False
            'End If

            'hsien 2013/5/10 改用迄日顯示補休期限
            Dim scheDate As String = CType(e.Row.FindControl("gv_lbScheDate"), Label).Text
            Dim sdate As Date = DateTimeInfo.GetPublicDate(scheDate)
            Dim sixmonth As Date = sdate.AddMonths(6).AddDays(1)
            '可申請補休的日期期限：今日至六個月前的日期
            CType(e.Row.FindControl("gv_lbLIMIT"), Label).Text = (sixmonth.Year - 1911).ToString().PadLeft(3, "0") & sixmonth.Month.ToString().PadLeft(2, "0") & (sixmonth.Day).ToString().PadLeft(2, "0")

        End If
    End Sub
#End Region

#Region "送出申請"
    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click

        If Not CheckField() Then
            Return
        End If

        Submit()
    End Sub

    Protected Function CheckField() As Boolean
        If String.IsNullOrEmpty(tbReason.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "事由必需輸入!")
            Return False
        End If
        If String.IsNullOrEmpty(ddlLeave_type.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假別必需輸入!")
            Return False
        End If

        Dim pb02 As New CPAPB02M
        If rblLeave_ngroup.SelectedValue = "A1" Then
            If String.IsNullOrEmpty(UcLeaveDate.Start_date) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可空白，請重新輸入!")
                Return False
            End If
            If String.IsNullOrEmpty(UcLeaveDate.Start_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起時不可空白，請重新輸入!")
                Return False
            End If
            If String.IsNullOrEmpty(UcLeaveDate.End_date) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄日不可空白，請重新輸入!")
                Return False
            End If
            If String.IsNullOrEmpty(UcLeaveDate.End_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄時不可空白，請重新輸入!")
                Return False
            End If
            If UcLeaveDate.Start_date > UcLeaveDate.End_date Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                Return False
            ElseIf UcLeaveDate.Start_date = UcLeaveDate.End_date And UcLeaveDate.Start_time > UcLeaveDate.End_time Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                Return False
            End If
            If pb02.IsHoliday(UcLeaveDate.Start_date) OrElse pb02.IsHoliday(UcLeaveDate.End_date) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "您選擇的請假日期為假日，假日不必請假，請修正!")
                Return False
            End If
        Else
            For Each gvr As GridViewRow In gv.Rows
                Dim UcLeaveDate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                If String.IsNullOrEmpty(UcLeaveDate.Start_date) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可空白，請重新輸入!")
                    Return False
                End If
                If String.IsNullOrEmpty(UcLeaveDate.Start_time) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起時不可空白，請重新輸入!")
                    Return False
                End If
                If String.IsNullOrEmpty(UcLeaveDate.End_date) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄日不可空白，請重新輸入!")
                    Return False
                End If
                If String.IsNullOrEmpty(UcLeaveDate.End_time) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期迄時不可空白，請重新輸入!")
                    Return False
                End If
                If UcLeaveDate.Start_date > UcLeaveDate.End_date Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                    Return False
                ElseIf UcLeaveDate.Start_date = UcLeaveDate.End_date And UcLeaveDate.Start_time > UcLeaveDate.End_time Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請日期起日不可大於迄日，請重新輸入!")
                    Return False
                End If
                If pb02.IsHoliday(UcLeaveDate.Start_date) OrElse pb02.IsHoliday(UcLeaveDate.End_date) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "您選擇的請假日期為假日，假日不必請假，請修正!")
                    Return False
                End If
            Next
        End If

        'If String.IsNullOrEmpty(UcLeaveDeputy.IdCard) And hfApplyEmployeeType.Value <> "13" Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "職務代理人不可空白，請重新輸入!")
        '    Return False
        'End If
        If ddlLeave_type.SelectedValue = "13" Then
            If String.IsNullOrEmpty(Me.ddlBabyDays.SelectedValue) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "懷孕日數不可空白，請重新輸入!")
                Return False
            End If
        End If

        If ddlLeave_type.SelectedValue = "03" Then
            'If rblLocationFlag.SelectedValue = "1" AndAlso cbl.SelectedValue = "Travel" Then
            If rblLocationFlag.SelectedValue = "1" AndAlso rblTravel.SelectedValue = "1" Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "國外休假不可勾選國民旅遊卡!")
                Return False
            End If
            If rblLocationFlag.SelectedValue = "1" AndAlso tbplace.Text.Trim() = "" Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "國外休假旅遊地點不可空白!")
                Return False
            End If
            If rblretainFlag.SelectedValue = "1" AndAlso rblLocationFlag.SelectedValue = "0" AndAlso _
                Not rblTravel.Items(0).Selected AndAlso Not rblTravel.Items(1).Selected Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇是否使用國民旅遊卡!")
                Return False
            End If
        End If

        If rblLocationFlag.SelectedValue = "1" Then
            If Not rblChinaFlag.Items(0).Selected AndAlso Not rblChinaFlag.Items(1).Selected Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇是否赴大陸地區!")
                Return False
            End If
        End If

        Return True
    End Function

    Protected Sub Submit()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim Depart_id As String = New DepartEmp().GetDepartId(UcLeaveMember.Apply_id)


        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True

            Dim d_lm As LeaveMain = New LeaveMain
            d_lm.Orgcode = u_org
            d_lm.FlowId = u_fid
            d_lm.DeleteLeaveMain()
        End If

        Dim reason As String = tbReason.Text.Trim()
        If "10" = ddlLeave_type.SelectedValue Then
            reason = "對象：" & ddlTarget.SelectedItem.Text & "，往生日：" & UcDate.Text & "，" & reason
        ElseIf "13" = ddlLeave_type.SelectedValue Then
            reason = "懷孕日數：：" & ddlBabyDays.SelectedItem.Text & "，流產日：" & UcDate.Text & "，" & reason
        End If
        Dim fid As String = String.Empty
        Dim hours As Integer = 0

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, "001001", ddlLeave_type.SelectedValue))

                Dim lmList As New List(Of LeaveMain)

                If rblLeave_ngroup.SelectedValue = "A1" Then
                    Dim lm As New FSC.Logic.LeaveMain()
                    lm.FlowId = fid
                    lm.Orgcode = Orgcode
                    lm.DepartId = Depart_id
                    lm.IdCard = UcLeaveMember.Apply_id
                    lm.UserName = UcLeaveMember.Apply_name
                    lm.LeaveGroup = "A"
                    lm.LeaveNgroup = "A1"
                    lm.LeaveType = ddlLeave_type.SelectedValue
                    lm.Reason = reason
                    lm.OccurDate = UcDate.Text
                    lm.Place = tbplace.Text.Trim()
                    lm.Target = ddlTarget.SelectedValue
                    lm.BabyDays = ddlBabyDays.SelectedValue
                    lm.BossAgree_flag = IIf(cbBossAgree_flag.Visible = True AndAlso cbBossAgree_flag.Checked, "1", "0")

                    If "03" = ddlLeave_type.SelectedValue Then
                        lm.RetainFlag = rblretainFlag.SelectedValue
                        lm.InterTravelFlag = rblTravel.SelectedValue  'IIf(cbl.SelectedValue = "Travel", "1", "0")
                    End If
                    lm.LocationFlag = rblLocationFlag.SelectedValue
                    If rblLocationFlag.SelectedValue = "1" Then
                        lm.ChinaFlag = rblChinaFlag.SelectedValue  'IIf(cbxChinaFlag.Checked, "1", "0")
                    End If

                    lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    lm.Change_date = Date.Now
                    hours = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, UcLeaveDate.End_date, UcLeaveDate.Start_time, UcLeaveDate.End_time, UcLeaveMember.Apply_id)
                    lm.StartDate = UcLeaveDate.Start_date
                    lm.EndDate = UcLeaveDate.End_date
                    lm.StartTime = UcLeaveDate.Start_time
                    lm.EndTime = UcLeaveDate.End_time
                    lm.LeaveHours = hours
                    lmList.Add(lm)
                Else
                    For Each gvr As GridViewRow In gv.Rows
                        Dim lm As New FSC.Logic.LeaveMain()
                        lm.FlowId = fid
                        lm.Orgcode = Orgcode
                        lm.DepartId = Depart_id
                        lm.IdCard = UcLeaveMember.Apply_id
                        lm.UserName = UcLeaveMember.Apply_name
                        lm.LeaveGroup = "A"
                        lm.LeaveNgroup = "A2"
                        lm.LeaveType = ddlLeave_type.SelectedValue
                        lm.Reason = reason
                        lm.OccurDate = UcDate.Text
                        lm.Place = tbplace.Text.Trim()
                        lm.Target = ddlTarget.SelectedValue
                        lm.BabyDays = ddlBabyDays.SelectedValue
                        lm.BossAgree_flag = IIf(cbBossAgree_flag.Visible = True AndAlso cbBossAgree_flag.Checked, "1", "0")

                        If "03" = ddlLeave_type.SelectedValue Then
                            lm.RetainFlag = rblretainFlag.SelectedValue
                            lm.InterTravelFlag = rblTravel.SelectedValue 'IIf(cbl.SelectedValue = "Travel", "1", "0")
                        End If
                        lm.LocationFlag = rblLocationFlag.SelectedValue
                        If rblLocationFlag.SelectedValue = "1" Then
                            lm.ChinaFlag = rblChinaFlag.SelectedValue  'IIf(cbxChinaFlag.Checked, "1", "0")
                        End If

                        lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                        lm.Change_date = Date.Now
                        Dim UcLeaveDate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                        hours = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, UcLeaveDate.End_date, UcLeaveDate.Start_time, UcLeaveDate.End_time, UcLeaveMember.Apply_id)
                        lm.StartDate = UcLeaveDate.Start_date
                        lm.EndDate = UcLeaveDate.End_date
                        lm.StartTime = UcLeaveDate.Start_time
                        lm.EndTime = UcLeaveDate.End_time
                        lm.LeaveHours = hours
                        lmList.Add(lm)
                    Next
                End If

                '事假檢核上限天數提示訊息
                Dim totalHours As Integer = 0
                Dim count As Integer = 1
                For Each l As LeaveMain In lmList
                    If count = lmList.Count Then
                        If l.LeaveType = "01" Then '事假 含 家庭照顧假
                            totalHours += New LeaveMain().GetHaveHoursByDate(l.IdCard, l.LeaveType, l.StartDate)
                            totalHours += New LeaveMain().GetHaveHoursByDate(l.IdCard, "25", l.StartDate)
                        ElseIf l.LeaveType = "02" Then '病假 含 生理假
                            totalHours += New LeaveMain().GetHaveHoursByDate(l.IdCard, l.LeaveType, l.StartDate)
                            totalHours += New LeaveMain().GetHaveHoursByDate(l.IdCard, "24", l.StartDate)
                        End If
                    End If

                    totalHours += l.LeaveHours '再加上這次申請的時數
                    count += 1
                Next

                If ddlLeave_type.SelectedValue = "01" OrElse ddlLeave_type.SelectedValue = "02" Then
                    Dim limitDays As Double = 0
                    Dim psn As Personnel = New Personnel().GetObject(UcLeaveMember.Apply_id)
                    If ddlLeave_type.SelectedValue = "01" AndAlso Not String.IsNullOrEmpty(psn.Pehday2) Then
                        limitDays = CommonFun.getDouble(psn.Pehday2)
                    ElseIf ddlLeave_type.SelectedValue = "02" AndAlso Not String.IsNullOrEmpty(psn.Pehday3) Then
                        limitDays = CommonFun.getDouble(psn.Pehday3)
                    Else
                        Dim pd04mdt As DataTable = New CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, ddlLeave_type.SelectedValue)
                        If pd04mdt IsNot Nothing AndAlso pd04mdt.Rows.Count > 0 Then
                            limitDays = CommonFun.getDouble(pd04mdt.Rows(0)("PDDAYS").ToString())
                        End If
                    End If

                    If limitDays > 0 And totalHours > Content.ConvertToHours(limitDays) Then
                        Dim leave_type As String = IIf(ddlLeave_type.SelectedValue = "01", "事假", "病假")
                        'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, leave_type + "已超過可休上限(" & limitDays & "天)!")
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "alert('" + leave_type + "已超過可休上限(" & limitDays & "天)!');", True)
                    End If
                End If

                '補休資料
                Dim lmmList As List(Of LeaveMainMapping) = GetLeaveMainMappingData(fid, hours)

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.DeputyDepartid = UcLeaveDeputy.DepartId
                    f.DeputyIdcard = UcLeaveDeputy.IdCard
                    f.DeputyName = UcLeaveDeputy.UserName
                    f.DeputyPosid = UcLeaveDeputy.Posid
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    If Request.QueryString("url") <> "FSC3116" Then
                        f.CaseStatus = "2"
                    End If
                    f.Update()

                    For Each lm As LeaveMain In lmList
                        lm.InsertLeaveMain(True)
                    Next
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.DeputyOrgcode = Orgcode
                    f.DeputyDepartid = UcLeaveDeputy.DepartId
                    f.DeputyIdcard = UcLeaveDeputy.IdCard
                    f.DeputyName = UcLeaveDeputy.UserName
                    f.DeputyPosid = UcLeaveDeputy.Posid
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "001001"
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddFlow(f, lmList, lmmList)
                End If

                trans.Complete()
            End Using


            '如果交易成功寄送email
            SendNotice.send(Orgcode, fid)
            If isUpdate AndAlso Request.QueryString("url") = "FSC3116" Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC3/FSC3116_01.aspx")
            ElseIf isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1101_01.aspx")
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub


    Protected Function GetLeaveMainMappingData(ByVal flowId As String, ByVal leaveHours As Integer) As List(Of LeaveMainMapping)
        Dim lmmList As New List(Of LeaveMainMapping)
        Dim breakHours As Integer = 0

        If ddlLeave_type.SelectedValue = "04" Then
            For Each gvr As GridViewRow In gvOvertime.Rows
                Dim PSBREAKH As String = CType(gvr.FindControl("gv_tbPSBREAKH"), TextBox).Text.Trim()   '補休時數
                Dim PSADDD As String = CType(gvr.FindControl("gv_lbPRADDD"), Label).Text        '加班起日
                Dim PSADDE As String = CType(gvr.FindControl("gv_lbPRADDD"), Label).Text        '加班迄日
                Dim PSOVSTIME As String = CType(gvr.FindControl("gv_lbPRSTIME"), Label).Text    '加班起時
                Dim PSOVETIME As String = CType(gvr.FindControl("gv_lbPRETIME"), Label).Text    '加班迄時
                Dim PRADDH As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbPRADDH"), Label).Text)  '加班時數
                Dim PRPAYH As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbPRPAYH"), Label).Text)  '已休時數
                Dim PRMNYH As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbPRMNYH"), Label).Text)  '已領時數時

                If String.IsNullOrEmpty(PSBREAKH) Or PSBREAKH = "0" Then
                    Continue For
                End If

                breakHours += PSBREAKH
                Dim lmm As New LeaveMainMapping()
                lmm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                lmm.FlowId = flowId
                lmm.Idcard = UcLeaveMember.Apply_id
                lmm.StartDate = UcLeaveDate.Start_date
                lmm.EndDate = UcLeaveDate.End_date
                lmm.StartTime = UcLeaveDate.Start_time
                lmm.EndTime = UcLeaveDate.End_time
                lmm.LeaveHours = CommonFun.getInt(PSBREAKH) '補休時數
                lmm.LeaveType = ddlLeave_type.SelectedValue
                lmm.ApplyDateb = PSADDD
                lmm.ApplyDatee = PSADDE
                lmm.ApplyTimeb = PSOVSTIME
                lmm.ApplyTimee = PSOVETIME

                If PRADDH - PRPAYH - PRMNYH < lmm.LeaveHours Then
                    Throw New FlowException("欲補休時數不可大於加班時數減去已休已領時數!")
                End If

                lmmList.Add(lmm)
            Next

            If breakHours <> leaveHours Then
                Throw New FlowException("補休時數有誤，請重新確認!")
            End If

        ElseIf ddlLeave_type.SelectedValue = "20" Then

            For Each gvr As GridViewRow In gvBusiness.Rows
                Dim PXBREAKH As String = CType(gvr.FindControl("gv_tbPXBREAKH"), TextBox).Text.Trim()   '補休時數
                Dim PPBUSDATEB As String = CType(gvr.FindControl("gv_lbPPBUSDATEB"), Label).Text        '公差起日
                Dim PPBUSDATEE As String = CType(gvr.FindControl("gv_lbPPBUSDATEE"), Label).Text        '公差迄日
                Dim PPTIMEB As String = CType(gvr.FindControl("gv_lbPPTIMEB"), Label).Text              '公差起時
                Dim PPTIMEE As String = CType(gvr.FindControl("gv_lbPPTIMEE"), Label).Text              '公差迄時
                Dim PPHDAY As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbPPHDAY"), Label).Text)        '可休時數
                Dim PRPAYH As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbPPPAYH"), Label).Text)        '已休時數

                If String.IsNullOrEmpty(PXBREAKH) Or PXBREAKH = "0" Then
                    Continue For
                End If

                breakHours += PXBREAKH
                Dim lmm As New LeaveMainMapping()
                lmm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                lmm.FlowId = flowId
                lmm.Idcard = UcLeaveMember.Apply_id
                lmm.StartDate = UcLeaveDate.Start_date
                lmm.EndDate = UcLeaveDate.End_date
                lmm.StartTime = UcLeaveDate.Start_time
                lmm.EndTime = UcLeaveDate.End_time
                lmm.LeaveHours = CommonFun.getInt(PXBREAKH) '補休時數
                lmm.LeaveType = ddlLeave_type.SelectedValue
                lmm.ApplyDateb = PPBUSDATEB
                lmm.ApplyDatee = PPBUSDATEE
                lmm.ApplyTimeb = PPTIMEB
                lmm.ApplyTimee = PPTIMEE

                'Dim PPBUSPLACE As String = CType(gvr.FindControl("gv_lbPPBUSPLACE"), Label).Text.Trim()
                'If -1 < PPBUSPLACE.IndexOf("公假") Then
                '    hasPublicDay = True
                'End If

                If Content.ConvertToHours(PPHDAY) - PRPAYH < PXBREAKH Then
                    Throw New FlowException("欲補休時數不可大於可休日時數減去已休時數!")
                End If

                lmmList.Add(lmm)
            Next

            If breakHours <> leaveHours Then
                Throw New FlowException("補休時數有誤，請重新確認!")
            End If

        ElseIf ddlLeave_type.SelectedValue = "32" Then

            For Each gvr As GridViewRow In gvSchedule.Rows

                Dim hours As String = CType(gvr.FindControl("gv_tbBreakHours"), TextBox).Text.Trim()    '補休時數
                Dim scheDate As String = CType(gvr.FindControl("gv_lbScheDate"), Label).Text            '公差起日

                Dim scheduleHours As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbScheduleHours"), Label).Text)     '可休時數
                Dim restHours As Double = CommonFun.getDouble(CType(gvr.FindControl("gv_lbRestHours"), Label).Text)             '已休時數

                If String.IsNullOrEmpty(hours) Or hours = "0" Then
                    Continue For
                End If

                breakHours += hours
                Dim lmm As New LeaveMainMapping()
                lmm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                lmm.FlowId = flowId
                lmm.Idcard = UcLeaveMember.Apply_id
                lmm.StartDate = UcLeaveDate.Start_date
                lmm.EndDate = UcLeaveDate.End_date
                lmm.StartTime = UcLeaveDate.Start_time
                lmm.EndTime = UcLeaveDate.End_time
                lmm.LeaveHours = CommonFun.getInt(hours) '補休時數
                lmm.LeaveType = ddlLeave_type.SelectedValue
                lmm.ApplyDateb = scheDate
                lmm.ApplyDatee = ""
                lmm.ApplyTimeb = ""
                lmm.ApplyTimee = ""

                'If scheduleHours - restHours < hours Then
                '    Throw New FlowException("欲補休時數不可大於可休日時數減去已休時數!")
                'End If

                lmmList.Add(lmm)
            Next

            If breakHours <> leaveHours Then
                Throw New FlowException("補休時數有誤，請重新確認!")
            End If

        End If

        Return lmmList
    End Function
#End Region

#Region "計算期限"
    Protected Sub cbCount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCount.Click, cbCount2.Click
        Dim pb02m As New CPAPB02M
        Dim d As Date
        Dim sdate As String

        lbLimit.Text = ""
        lbLimit2.Text = ""

        If String.IsNullOrEmpty(UcDate.Text) And ddlLeave_type.SelectedValue <> "9" Then
            Return
        Else
            sdate = UcDate.Text
        End If

        If String.IsNullOrEmpty(UcLeaveDate.Start_date) And ddlLeave_type.SelectedValue = "9" Then
            Return
        ElseIf ddlLeave_type.SelectedValue = "9" Then
            sdate = UcLeaveDate.Start_date
        End If

        d = New Date(Integer.Parse(sdate.Substring(0, 3) + 1911), sdate.Substring(3, 2), sdate.Substring(5, 2))

        '婚假
        If ddlLeave_type.SelectedValue = "8" Then
            lbLimit.Text = "申請期限至：" & DateTimeInfo.GetRocDate(d.AddDays(31))  '日曆天
        End If

        If ddlLeave_type.SelectedValue = "9" Then
            lbLimit2.Text = "申請期限至：" & pb02m.GetLimitDate(UcLeaveDate.Start_date, 41, True)    '工作天
        End If

        '喪假
        If ddlLeave_type.SelectedValue = "10" Then
            lbLimit.Text = "申請期限至：" & DateTimeInfo.GetRocDate(d.AddDays(100))  '日曆天
        End If

        If ddlLeave_type.SelectedValue = "13" Then
            Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            'Dim thePEMEMCOD As String = New FSC.Logic.Personnel().GetColumnValue("PEMEMCOD", idCard)
            'Dim hours As Integer = 0
            'If "4".Equals(thePEMEMCOD) Or _
            '    "9".Equals(thePEMEMCOD) Or _
            '    "A".Equals(thePEMEMCOD) Then
            '    lbLimit.Text = "申請期限至：" & DateTimeInfo.GetRocDate(d.AddDays(Convert.ToInt16(Me.ddlBabyDays.SelectedValue)))  '日曆天
            'Else
            '    lbLimit2.Text = "申請期限至：" & pb02m.GetLimitDate(UcLeaveDate.Start_date, Convert.ToInt16(Me.ddlBabyDays.SelectedValue), True)    '工作天
            'End If
        End If

    End Sub
#End Region

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl"))
        End If
    End Sub
End Class
