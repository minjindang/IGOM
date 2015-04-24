Imports FSCPLM.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Data
Imports System.Collections.Generic
Imports FSC.Logic


Partial Class FSC1102_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkConfirm()
        If IsPostBack Then
            Return
        End If
        InitData()

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
                Return
            End If

            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(org, fid)

            Dim i As Integer = 1
            For Each lm As FSC.Logic.LeaveMain In list

                If i = list.Count Then
                    ddlLeave_type.SelectedValue = lm.LeaveType
                    UcLeaveMember.Apply_id = lm.IdCard
                    BindDeputy()
                    UcLeaveDeputy.Orgcode = f.Orgcode
                    UcLeaveDeputy.DepartId = f.DeputyDepartid
                    UcLeaveDeputy.IdCard = f.DeputyIdcard
                    tbReason.Text = lm.Reason
                    rblLocationFlag.SelectedValue = lm.LocationFlag
                    'rblLocationFlag_SelectedIndexChanged(Nothing, Nothing)
                End If

                If lm.LeaveNgroup = "C1" Then
                    UcLeaveDate.Start_date = lm.StartDate
                    UcLeaveDate.End_date = lm.EndDate
                    UcLeaveDate.Start_time = lm.StartTime
                    UcLeaveDate.End_time = lm.EndTime
                    hcbx.Checked = IIf(lm.HolidayOfficalFlag = "1", True, False)
                    UcHolidayDate.Start_date = lm.HolidayDateb
                    UcHolidayDate.End_date = lm.HolidayDatee
                    UcHolidayDate.Start_time = lm.HolidayTimeb
                    UcHolidayDate.End_time = lm.HolidayTimee
                End If
                i += 1
            Next
            UcAttachment.BindUploadFile(org, fid)

            Dim lmd As New LeaveMainDetail
            Dim dt As DataTable = lmd.getDataByFid(fid)
            gv.DataSource = dt
            gv.DataBind()
        End If
    End Sub

    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        If target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbStart_date" Then
            UcLeaveDate.Start_time = "0830"
        End If
        If target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbStart_date" OrElse target = "ctl00_ContentPlaceHolder1_UcLeaveDate_tbEnd_date" Then
            If Not String.IsNullOrEmpty(UcLeaveDate.Start_date) AndAlso Not String.IsNullOrEmpty(UcLeaveDate.End_date) Then
                Dim ddt As DataTable = getDateDt(UcLeaveDate.Start_date, UcLeaveDate.End_date)
                InitLeaveDate()

                Dim dt As DataTable = CType(ViewState("dt"), DataTable)
                For Each ddr As DataRow In ddt.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("Start_date") = ddr("Leave_date").ToString
                    dr("End_date") = ddr("Leave_date").ToString
                    dt.Rows.Add(dr)
                Next

                gv.DataSource = dt
                gv.DataBind()
            End If
        End If
    End Sub

#Region "初始/設定 控制項"
    Protected Sub InitData()
        BindDeputyDep()
        UcLeaveMember.Apply_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        InitLeaveDate(True)
        LeaveDateBind()
        BindDeputy()
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

    Protected Sub BindDeputyDep()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        UcLeaveDeputy.Orgcode = orgcode
        UcLeaveDeputy.DepartId = depart_id
    End Sub

    Protected Sub BindDeputy()
        UcLeaveDeputy.ApplyIdcard = UcLeaveMember.Apply_id
    End Sub

    Protected Sub hcbx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If hcbx.Checked Then
            UcHolidayDate.Start_date = UcLeaveDate.Start_date
            UcHolidayDate.End_date = UcLeaveDate.End_date
            UcHolidayDate.Start_time = UcLeaveDate.Start_time
            UcHolidayDate.End_time = UcLeaveDate.End_time
        Else
            UcHolidayDate.Start_date = ""
            UcHolidayDate.End_date = ""
            UcHolidayDate.Start_time = ""
            UcHolidayDate.End_time = ""
        End If
    End Sub

    Protected Sub UcLeaveMember_Apply_name_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcLeaveMember.Apply_name_ValueChanged
        BindDeputy()
    End Sub

    'Protected Sub rblLocationFlag_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If rblLocationFlag.SelectedValue = "0" Then
    '        gv.Columns(1).Visible = True
    '    Else
    '        gv.Columns(1).Visible = False
    '    End If
    'End Sub
#End Region

#Region "Gridview 控制"
    Protected Sub InitLeaveDate(Optional ByVal isAdd As Boolean = False)
        Dim dt As New DataTable
        dt.Columns.Add("Start_date", GetType(String))
        dt.Columns.Add("End_date", GetType(String))
        'dt.Columns.Add("City", GetType(String))
        dt.Columns.Add("Start_place", GetType(String))
        dt.Columns.Add("End_place", GetType(String))
        dt.Columns.Add("DetailPlace", GetType(String))
        dt.Columns.Add("Transport", GetType(String))
        dt.Columns.Add("Transport_Desc", GetType(String))
        dt.Columns.Add("Reason", GetType(String))

        If isAdd Then
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
        End If

        ViewState("dt") = dt
    End Sub

    Protected Sub LeaveDateBind()
        gv.DataSource = ViewState("dt")
        gv.DataBind()
    End Sub

    Protected Sub gv_cbInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index As Integer = CType(CType(sender, Button).NamingContainer, GridViewRow).RowIndex
        GvToDt()

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        Dim dr As DataRow = dt.NewRow
        dt.Rows.InsertAt(dr, index + 1)
        ViewState("dt") = dt

        LeaveDateBind()
    End Sub

    Protected Sub gv_cbRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index As Integer = CType(CType(sender, Button).NamingContainer, GridViewRow).RowIndex
        GvToDt()

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt.Rows.Count = 1 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "至少必須填寫一筆公差明細資料!")
            Return
        End If

        dt.Rows.RemoveAt(index)
        ViewState("dt") = dt

        LeaveDateBind()
    End Sub

    Protected Sub GvToDt()
        InitLeaveDate()

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        For Each gvr As GridViewRow In gv.Rows
            Dim UcDateS As UControl_UcDate = CType(gvr.FindControl("UcDateS"), UControl_UcDate)
            Dim UcDateE As UControl_UcDate = CType(gvr.FindControl("UcDateE"), UControl_UcDate)
            'Dim ddlCity As DropDownList = CType(gvr.FindControl("ddlCity"), DropDownList)
            Dim tbStart_place As TextBox = CType(gvr.FindControl("tbStart_place"), TextBox)
            Dim tbEnd_place As TextBox = CType(gvr.FindControl("tbEnd_place"), TextBox)
            Dim tbDetailPlace As TextBox = CType(gvr.FindControl("tbDetailPlace"), TextBox)
            Dim cbxlTransport As CheckBoxList = CType(gvr.FindControl("cbxlTransport"), CheckBoxList)
            Dim tbTransportDesc As TextBox = CType(gvr.FindControl("tbTransportDesc"), TextBox)
            Dim tbReason As TextBox = CType(gvr.FindControl("tbReason"), TextBox)

            Dim dr As DataRow = dt.NewRow
            dr("Start_date") = UcDateS.Text
            dr("End_date") = UcDateE.Text
            'dr("City") = ddlCity.SelectedValue
            dr("Start_place") = tbStart_place.Text
            dr("End_place") = tbEnd_place.Text
            dr("DetailPlace") = tbDetailPlace.Text
            For Each i As ListItem In cbxlTransport.Items
                If i.Selected Then
                    dr("Transport") = dr("Transport").ToString + i.Value + ","
                End If
            Next
            dr("Transport") = dr("Transport").ToString.TrimEnd(",")
            dr("Transport_Desc") = tbTransportDesc.Text
            dr("Reason") = tbReason.Text

            dt.Rows.Add(dr)
        Next

        ViewState("dt") = dt
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Dim ddlCity As DropDownList = CType(e.Row.FindControl("ddlCity"), DropDownList)
            'ddlCity.DataSource = New SYS.Logic.CODE().GetData("023", "007")
            'ddlCity.DataBind()
            'Dim lbCity As Label = CType(e.Row.FindControl("lbCity"), Label)
            'If Not String.IsNullOrEmpty(lbCity.Text) Then
            '    ddlCity.SelectedValue = lbCity.Text
            'End If

            Dim cbxlTransport As CheckBoxList = CType(e.Row.FindControl("cbxlTransport"), CheckBoxList)
            cbxlTransport.DataSource = New SYS.Logic.CODE().GetData("023", "013")
            cbxlTransport.DataBind()
            Dim lbTransport As Label = CType(e.Row.FindControl("lbTransport"), Label)
            If Not String.IsNullOrEmpty(lbTransport.Text) Then
                For Each Transport As String In lbTransport.Text.Split(",")
                    For Each i As ListItem In cbxlTransport.Items
                        If i.Value = Transport Then
                            i.Selected = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub
#End Region

#Region "檢核"
    Protected Function CheckField() As Boolean
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
        If UcHolidayDate.End_date < UcHolidayDate.Start_date Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假日執行公務申請日期起日不可大於迄日，請重新輸入!")
            Return False
        Else
            If UcHolidayDate.End_date = UcHolidayDate.Start_date Then
                If UcHolidayDate.End_time < UcHolidayDate.Start_time Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假日執行公務申請日期起日不可大於迄日，請重新輸入!")
                    Return False
                End If
            End If
        End If
        If hcbx.Checked Then
            If String.IsNullOrEmpty(UcHolidayDate.Start_date) OrElse String.IsNullOrEmpty(UcHolidayDate.End_date) OrElse _
                String.IsNullOrEmpty(UcHolidayDate.Start_time) OrElse String.IsNullOrEmpty(UcHolidayDate.End_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假日執行公務起迄日期不可空白!")
                Return False
            End If
            If (Double.Parse(UcHolidayDate.Start_date & UcHolidayDate.Start_time) < Double.Parse(UcLeaveDate.Start_date & UcLeaveDate.Start_time)) Or _
                (Double.Parse(UcHolidayDate.End_date & UcHolidayDate.End_time) > Double.Parse(UcLeaveDate.End_date & UcLeaveDate.End_time)) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "假日執行公務起迄日超出公務起迄範圍，不可指定為假日執行公務!")
                Return False
            End If
        End If

        ' 交通工具勾選飛機/高鐵時，必填理由說明
        For Each gvr As GridViewRow In gv.Rows
            Dim UcDateS As UControl_UcDate = CType(gvr.FindControl("UcDateS"), UControl_UcDate)
            If String.IsNullOrEmpty(UcDateS.Text) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(起)不可空白!")
                Return False
            End If
            Dim UcDateE As UControl_UcDate = CType(gvr.FindControl("UcDateE"), UControl_UcDate)
            If String.IsNullOrEmpty(UcDateE.Text) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(迄)不可空白!")
                Return False
            End If

            Dim tbDetailPlace As TextBox = CType(gvr.FindControl("tbDetailPlace"), TextBox)
            If tbDetailPlace.Text.Trim().Length > 100 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "出差明細地點不可超過100字!")
                Return False
            End If

            Dim tbReason As TextBox = CType(gvr.FindControl("tbReason"), TextBox)
            If tbReason.Text.Trim().Length > 30 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "事由不可超過30字!")
                Return False
            End If

            Dim cbxlTransport As CheckBoxList = CType(gvr.FindControl("cbxlTransport"), CheckBoxList)
            Dim tbTransportDesc As TextBox = CType(gvr.FindControl("tbTransportDesc"), TextBox)

            If tbTransportDesc.Text.Trim().Length > 100 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "搭乘高鐵或飛機之理由說明不可超過100字!")
                Return False
            End If

            For Each li As ListItem In cbxlTransport.Items

                If li.Selected Then
                    If li.Text = "飛機" Or li.Text = "高鐵" Then
                        If String.IsNullOrEmpty(tbTransportDesc.Text.Trim) Then
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "交通工具勾選飛機/高鐵時，理由說明不可空白，請重新輸入!")
                            Return False
                        End If
                    End If
                End If
            Next
        Next

        For i As Integer = 0 To gv.Rows.Count - 1
            Dim UcDateS As UControl_UcDate = CType(gv.Rows(i).FindControl("UcDateS"), UControl_UcDate)
            Dim UcDateE As UControl_UcDate = CType(gv.Rows(i).FindControl("UcDateE"), UControl_UcDate)

            If gv.Rows.Count = 1 Then
                If UcDateS.Text <> UcLeaveDate.Start_date Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(起)與公差日期(起)不符!")
                    Return False
                End If
                If UcDateE.Text <> UcLeaveDate.End_date Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(迄)與公差日期(迄)不符!")
                    Return False
                End If
            Else
                If i = 0 Then
                    If UcDateS.Text <> UcLeaveDate.Start_date Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(起)與公差日期(起)不符!")
                        Return False
                    End If
                Else
                    Dim LastDateE As String = FSC.Logic.DateTimeInfo.GetRocDate(FSC.Logic.DateTimeInfo.GetPublicDate(CType(gv.Rows(i - 1).FindControl("UcDateE"), UControl_UcDate).Text).AddDays(1))
                    If UcDateS.Text <> LastDateE Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期與公差日期區間不符!!")
                        Return False
                    End If

                    If i = gv.Rows.Count - 1 Then
                        If UcDateE.Text <> UcLeaveDate.End_date Then
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "明細公差日期(迄)與公差日期(迄)不符!")
                            Return False
                        End If
                    End If
                End If
            End If
        Next

        Return True
    End Function
#End Region

#Region "送出申請"
    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = New DepartEmp().GetDepartId(UcLeaveMember.Apply_id)

        If Not CheckField() Then
            Return
        End If

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        Dim reason As String = tbReason.Text.Trim()
        Dim fid As String = String.Empty
        Dim hours As Integer = 0
        Dim hhours As Integer = 0

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(OrgCode, "001003", ddlLeave_type.SelectedValue))

                Dim lmList As New List(Of LeaveMain)

                Dim lm As New FSC.Logic.LeaveMain()
                lm.FlowId = fid
                lm.Orgcode = OrgCode
                lm.DepartId = Depart_id
                lm.IdCard = UcLeaveMember.Apply_id
                lm.UserName = UcLeaveMember.Apply_name
                lm.LeaveGroup = "C"
                lm.LeaveNgroup = "C1"
                lm.LeaveType = ddlLeave_type.SelectedValue
                lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                lm.Change_date = Date.Now

                hours = FSC.Logic.Content.computeNotWorkHour(UcLeaveDate.Start_date, UcLeaveDate.End_date, UcLeaveDate.Start_time, UcLeaveDate.End_time, UcLeaveMember.Apply_id)
                lm.StartDate = UcLeaveDate.Start_date
                lm.EndDate = UcLeaveDate.End_date
                lm.StartTime = UcLeaveDate.Start_time
                lm.EndTime = UcLeaveDate.End_time
                lm.LeaveHours = hours

                If hcbx.Checked Then
                    hhours = FSC.Logic.Content.computeHolidayWorkHour(UcHolidayDate.Start_date, UcHolidayDate.End_date, UcHolidayDate.Start_time, UcHolidayDate.End_time, UcLeaveMember.Apply_id)
                    lm.HolidayOfficalFlag = "1"
                    lm.HolidayDateb = UcHolidayDate.Start_date
                    lm.HolidayDatee = UcHolidayDate.End_date
                    lm.HolidayTimeb = UcHolidayDate.Start_time
                    lm.HolidayTimee = UcHolidayDate.End_time
                    lm.HolidayHours = hhours
                    reason = "「假日執行公務」" & hhours & "小時，" & reason
                End If
                lm.LocationFlag = rblLocationFlag.SelectedValue
                lm.Place = ""
                lm.Reason = reason
                lmList.Add(lm)

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                GvToDt()
                Dim dt As DataTable = CType(ViewState("dt"), DataTable)
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入公差明細資料!")
                    Return
                End If

                Dim lmd As New LeaveMainDetail

                lmd.Flow_id = fid
                lmd.delete()
                For Each dr As DataRow In dt.Rows
                    lmd = New LeaveMainDetail
                    lmd.Flow_id = fid
                    lmd.Start_date = dr("Start_date").ToString()
                    lmd.End_date = dr("End_date").ToString()
                    'If rblLocationFlag.SelectedValue = "0" Then
                    '    lmd.city = dr("City").ToString()
                    'End If
                    lmd.Start_place = dr("Start_place").ToString()
                    lmd.End_place = dr("End_place").ToString()
                    lmd.DetailPlace = dr("DetailPlace").ToString()
                    lmd.Transport = dr("Transport").ToString()
                    lmd.Transport_desc = dr("Transport_Desc").ToString()
                    lmd.Reason = dr("Reason").ToString()
                    lmd.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

                    lmd.insert()
                Next

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.DeputyOrgcode = OrgCode
                    f.DeputyDepartid = UcLeaveDeputy.DepartId
                    f.DeputyIdcard = UcLeaveDeputy.IdCard
                    f.DeputyName = UcLeaveDeputy.UserName
                    f.DeputyPosid = UcLeaveDeputy.Posid
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.CaseStatus = "2"
                    f.Update()

                    For Each l As LeaveMain In lmList
                        l.UpdateLeaveMain()
                    Next
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = OrgCode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = UcLeaveMember.Apply_id
                    f.ApplyName = UcLeaveMember.Apply_name
                    f.ApplyPosid = UcLeaveMember.Apply_posid
                    f.ApplyStype = UcLeaveMember.Apply_stype
                    f.DeputyOrgcode = OrgCode
                    f.DeputyDepartid = UcLeaveDeputy.DepartId
                    f.DeputyIdcard = UcLeaveDeputy.IdCard
                    f.DeputyName = UcLeaveDeputy.UserName
                    f.DeputyPosid = UcLeaveDeputy.Posid
                    f.WriterOrgcode = OrgCode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "001003"
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddFlow(f, lmList)
                End If

                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(OrgCode, fid)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1102_02.aspx")
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
#End Region
    
    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub

    Protected Function getDateDt(ByVal Start_date As String, ByVal End_date As String) As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Leave_date")
        Dim S_Date As Date = FSC.Logic.DateTimeInfo.GetPublicDate(Start_date)
        Dim E_Date As Date = FSC.Logic.DateTimeInfo.GetPublicDate(End_date)

        Dim dr As DataRow = dt.NewRow
        dr("Leave_date") = FSC.Logic.DateTimeInfo.GetRocDate(S_Date)
        dt.Rows.Add(dr)

        While S_Date < E_Date
            S_Date = S_Date.AddDays(1)
            dr = dt.NewRow
            dr("Leave_date") = FSC.Logic.DateTimeInfo.GetRocDate(S_Date)
            dt.Rows.Add(dr)
        End While

        Return dt
    End Function
End Class
