Imports FSCPLM.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Data
Imports System.Collections.Generic
Imports FSC.Logic


Partial Class FSC_FSC1102_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        InitData()
        'gv_UcLeaveDate.Start_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        'gv_UcLeaveDate.End_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        'gv_UcLeaveDate.Start_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        'gv_UcLeaveDate.Start_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
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
                    rblLeave_ngroup.SelectedValue = lm.LeaveNgroup
                    UcLeaveMember.Apply_id = lm.IdCard
                    BindDeputy()
                    UcLeaveDeputy.Orgcode = f.Orgcode
                    UcLeaveDeputy.DepartId = f.DeputyDepartid
                    UcLeaveDeputy.IdCard = f.DeputyIdcard
                    rblLocationFlag.SelectedValue = lm.LocationFlag
                    ddlCity.SelectedValue = lm.PlaceCity
                    UcDetailPlace.Text = lm.Place

                    For Each t As String In lm.Transport.Split(",")
                        For Each item As ListItem In cbxlTransport.Items
                            If item.Value = t Then
                                item.Selected = True
                            End If
                        Next
                    Next
                    ucTransportDesc.Text = lm.TransportDesc
                    tbReason.Text = lm.Reason
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
                Else
                    If i > 1 Then
                        InsertGVRow(i)
                    End If

                    Dim UcLeaveDate As UControl_UcLeaveDate = CType(gv.Rows(i).FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                    Dim hcbx As CheckBox = CType(gv.Rows(i).FindControl("gv_cbxholiday"), CheckBox)
                    Dim UcHolidayDate As UControl_UcLeaveDate = CType(gv.Rows(i).FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate)
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
        End If
    End Sub

#Region "初始/設定 控制項"
    Protected Sub InitData()
        BindDeputyDep()
        UcLeaveMember.Apply_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        bindDeputy()
        BindCity()
        BindTrnasport()
        rblLocationFlag.Attributes.Add("onclick", "javascript:showCityDDL();")
        rblLeave_ngroup.Attributes.Add("onclick", "javascript:chgDateTable();")
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

    Protected Sub rblLeave_ngroup_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblLeave_ngroup.DataBound
        rblLeave_ngroup.SelectedValue = "C1"
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

    Protected Sub BindCity()
        Dim code As New FSCPLM.Logic.SACode()
        ddlCity.DataSource = code.GetData("023", "007")
        ddlCity.DataBind()
    End Sub

    Protected Sub BindTrnasport()
        Dim code As New FSCPLM.Logic.SACode()
        cbxlTransport.DataSource = code.GetData("023", "013")
        cbxlTransport.DataBind()
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

    Protected Sub gv_cbxholiday_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, CheckBox).NamingContainer
        Dim ucd As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
        Dim uch As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate)
        Dim cbxNight As CheckBox = CType(gvr.FindControl("gv_cbxNight"), CheckBox)

        If CType(sender, CheckBox).Checked Then
            uch.Start_date = ucd.Start_date
            uch.End_date = ucd.End_date
            uch.Start_time = ucd.Start_time
            uch.End_time = ucd.End_time
            cbxNight.Checked = False
            cbxNight.Enabled = False
        Else
            uch.Start_date = ""
            uch.End_date = ""
            uch.Start_time = ""
            uch.End_time = ""
            cbxNight.Enabled = True
        End If
    End Sub

    Protected Sub UcLeaveMember_Apply_name_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcLeaveMember.Apply_name_ValueChanged
        'bindMemoDesc()
        BindDeputy()
    End Sub
#End Region

#Region "Gridview 控制"
    Protected Sub InitLeaveDate()
        Dim dt As New DataTable
        dt.Columns.Add("Start_date", GetType(String))
        dt.Columns.Add("Start_Time", GetType(String))
        dt.Columns.Add("End_date", GetType(String))
        dt.Columns.Add("End_Time", GetType(String))
        dt.Columns.Add("Holiday_dateb", GetType(String))
        dt.Columns.Add("Holiday_Timeb", GetType(String))
        dt.Columns.Add("Holiday_datee", GetType(String))
        dt.Columns.Add("Holiday_Timee", GetType(String))
        Dim dr As DataRow = dt.NewRow
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

    Protected Sub InsertGVRow(rowi As Integer)
        Dim dt As DataTable = ViewState("dt")

        '把Gridview控制項裡的值放回DataTable
        Dim i As Integer = 0
        For Each gvr As GridViewRow In gv.Rows
            dt.Rows(i)("Start_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_date
            dt.Rows(i)("End_date") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_date
            dt.Rows(i)("Start_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).Start_time
            dt.Rows(i)("End_time") = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate).End_time
            dt.Rows(i)("Holiday_dateb") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).Start_date
            dt.Rows(i)("Holiday_datee") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).End_date
            dt.Rows(i)("Holiday_Timeb") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).Start_time
            dt.Rows(i)("Holiday_Timee") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).End_time
            i += 1
        Next

        Dim ndt As New DataTable
        ndt = dt.Clone
        Dim ndr As DataRow

        i = 0
        For Each dr As DataRow In dt.Rows
            ndr = ndt.NewRow
            ndr("Start_date") = dr("Start_date")
            ndr("Start_Time") = dr("Start_Time")
            ndr("End_date") = dr("End_date")
            ndr("End_Time") = dr("End_Time")
            ndr("Holiday_dateb") = dr("Holiday_dateb")
            ndr("Holiday_Timeb") = dr("Holiday_Timeb")
            ndr("Holiday_datee") = dr("Holiday_datee")
            ndr("Holiday_Timee") = dr("Holiday_Timee")
            ndt.Rows.Add(ndr)
            If i = rowi Then
                ndr = ndt.NewRow
                ndr("Start_date") = dr("Start_date").ToString()
                ndr("End_date") = dr("End_date").ToString()
                ndr("Start_time") = dr("Start_time").ToString()
                ndr("End_time") = dr("End_time").ToString()
                ndr("Holiday_dateb") = dr("Holiday_dateb")
                ndr("Holiday_Timeb") = dr("Holiday_Timeb")
                ndr("Holiday_datee") = dr("Holiday_datee")
                ndr("Holiday_Timee") = dr("Holiday_Timee")
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
            dt.Rows(i)("Holiday_dateb") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).Start_date
            dt.Rows(i)("Holiday_datee") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).End_date
            dt.Rows(i)("Holiday_Timeb") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).Start_time
            dt.Rows(i)("Holiday_Timee") = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate).End_time
            i += 1
        Next
        If rowi <> 0 Then
            dt.Rows.RemoveAt(rowi)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "第一筆請假資料不能刪除!")
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
#End Region

    Protected Function CheckField() As Boolean
        If rblLeave_ngroup.SelectedValue = "C1" Then
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
        Else
            For Each gvr As GridViewRow In gv.Rows
                Dim UcLeaveDate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                Dim UcHolidayDate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate)
                Dim hcbx As CheckBox = CType(gvr.FindControl("gv_cbxholiday"), CheckBox)

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
            Next
        End If

        ' 交通工具勾選飛機/高鐵時，必填理由說明
        For Each li As ListItem In cbxlTransport.Items

            If li.Selected Then
                If li.Text = "飛機" Or li.Text = "高鐵" Then
                    If String.IsNullOrEmpty(Me.ucTransportDesc.Text) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "交通工具勾選飛機/高鐵時，理由說明不可空白，請重新輸入!")
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

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

                Dim transport As String = ""
                For Each item As ListItem In cbxlTransport.Items
                    If item.Selected Then
                        If Not String.IsNullOrEmpty(transport) Then
                            transport &= ","
                        End If
                        transport &= item.Value
                    End If
                Next

                Dim lmList As New List(Of LeaveMain)

                If rblLeave_ngroup.SelectedValue = "C1" Then
                    Dim lm As New FSC.Logic.LeaveMain()
                    lm.FlowId = fid
                    lm.Orgcode = OrgCode
                    lm.DepartId = Depart_id
                    lm.IdCard = UcLeaveMember.Apply_id
                    lm.UserName = UcLeaveMember.Apply_name
                    lm.LeaveGroup = "C"
                    lm.LeaveNgroup = "C1"
                    lm.LeaveType = ddlLeave_type.SelectedValue
                    lm.LocationFlag = rblLocationFlag.SelectedValue
                    lm.Place = UcDetailPlace.Text.Trim()
                    If rblLocationFlag.SelectedValue = "0" Then
                        lm.PlaceCity = ddlCity.SelectedValue
                    End If
                    lm.Transport = transport
                    lm.TransportDesc = ucTransportDesc.Text.Trim()
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
                    lm.Reason = reason
                    lmList.Add(lm)
                Else
                    For Each gvr As GridViewRow In gv.Rows
                        Dim lm As New FSC.Logic.LeaveMain()
                        lm.FlowId = fid
                        lm.Orgcode = OrgCode
                        lm.DepartId = Depart_id
                        lm.IdCard = UcLeaveMember.Apply_id
                        lm.UserName = UcLeaveMember.Apply_name
                        lm.LeaveGroup = "C"
                        lm.LeaveNgroup = "C1"
                        lm.LeaveType = ddlLeave_type.SelectedValue
                        lm.LocationFlag = rblLocationFlag.SelectedValue
                        lm.Place = UcDetailPlace.Text.Trim()
                        If rblLocationFlag.SelectedValue = "0" Then
                            lm.PlaceCity = ddlCity.SelectedValue
                        End If
                        lm.Transport = transport
                        lm.TransportDesc = ucTransportDesc.Text.Trim()
                        lm.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                        lm.Change_date = Date.Now

                        Dim ucdate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcLeaveDate"), UControl_UcLeaveDate)
                        hours = FSC.Logic.Content.computeNotWorkHour(ucdate.Start_date, ucdate.End_date, ucdate.Start_time, ucdate.End_time, UcLeaveMember.Apply_id)
                        lm.StartDate = ucdate.Start_date
                        lm.EndDate = ucdate.End_date
                        lm.StartTime = ucdate.Start_time
                        lm.EndTime = ucdate.End_time
                        lm.LeaveHours = hours
                        If hcbx.Checked Then
                            Dim uchdate As UControl_UcLeaveDate = CType(gvr.FindControl("gv_UcHolidayDate"), UControl_UcLeaveDate)
                            hhours = FSC.Logic.Content.computeHolidayWorkHour(uchdate.Start_date, uchdate.End_date, uchdate.Start_time, uchdate.End_time, UcLeaveMember.Apply_id)
                            lm.HolidayOfficalFlag = "1"
                            lm.HolidayDateb = uchdate.Start_date
                            lm.HolidayDatee = uchdate.End_date
                            lm.HolidayTimeb = uchdate.Start_time
                            lm.HolidayTimee = uchdate.End_time
                            lm.HolidayHours = hhours
                            reason = "「假日執行公務」" & hhours & "小時，" & reason
                        End If
                        lm.Reason = reason
                        lmList.Add(lm)
                    Next
                End If

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


                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                If isUpdate Then
                    f.CaseStatus = "2"
                    f.Update()
                    For Each lm As LeaveMain In lmList
                        lm.UpdateLeaveMain()
                    Next
                Else
                    SYS.Logic.CommonFlow.AddFlow(f, lmList)
                End If

                trans.Complete()
            End Using

            '如果交易成功寄送email
            SendNotice.send(OrgCode, fid)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC1/FSC1102_01.aspx")
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
