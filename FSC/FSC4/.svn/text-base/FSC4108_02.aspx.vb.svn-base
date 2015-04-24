Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4108_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        ' 繫結 假別/差勤組別/職務類別
        showDLL()

        ' 依傳入值顯示相關資料
        bind()
    End Sub

    ''' <summary>
    ''' 「取消」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC4108_01.aspx?qk=" & Request.QueryString("qk") & "&ql=" & Request.QueryString("ql"))
    End Sub

    ''' <summary>
    ''' 「確認」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ls As New LeaveSetting()

        If String.IsNullOrEmpty(ddlLeaveType.SelectedValue()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「假別」欄位為必填!")
            Return
        End If

        If String.IsNullOrEmpty(ddlMEMCOD.SelectedValue()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「職務類別」欄位為必填!")
            Return
        End If

        If rblMustAttachYN.SelectedValue = "Y" AndAlso tbManyDays.Text.Trim() = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "勾選必須上傳附件必輸入天數!")
            Return
        End If

        If UcStopDate.Start_date > UcStopDate.End_date Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "停止請假期間起日不可大於迄日，請重新輸入!")
            Return
        ElseIf UcStopDate.Start_date = UcStopDate.End_date And UcStopDate.Start_time > UcStopDate.End_time Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "停止請假期間起日不可大於迄日，請重新輸入!")
            Return
        End If

        If Not String.IsNullOrEmpty(tbLimit.Text.Trim()) AndAlso Not CommonFun.IsNum(tbLimit.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請期限天數請輸入數字!")
            Return
        End If

        If Not String.IsNullOrEmpty(tbReciprocalDays.Text.Trim()) AndAlso Not CommonFun.IsNum(tbReciprocalDays.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請畢天數請輸入數字!")
            Return
        End If

        If Not String.IsNullOrEmpty(tblimit_Date.Text.Trim()) Then
            If Not CommonFun.IsNum(tblimit_Date.Text.Trim()) OrElse tblimit_Date.Text.Trim.Length <> 4 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請期限日期格式不正確!")
                Return
            End If
        End If

        If (tbDesc.Text.Trim.ToString().Length > 250) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「假別說明」只能填250個字!")
            Return
        End If

        Try

            Dim action As String = Request.QueryString("action")
            Dim dt As DataTable = ls.GetDataByLeaveKind(Orgcode, ddlLeaveKind.SelectedValue, ddlLeaveType.SelectedValue, ddlMEMCOD.SelectedValue)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso action <> "update" Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "資料庫已有該組設定!")
                Return
            End If

            ls.Describe = tbDesc.Text.Trim()
            ls.Orgcode = Orgcode
            ls.Depart_id = Depart_id
            ls.Update_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            If Me.ddlLeaveType.SelectedValue = "10" Then
                If Not checkDetail() Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可重複設定喪假之親屬!")
                    Return
                End If
            End If

            If Me.ddlLeaveType.SelectedValue = "13" Then
                If Not checkDetail02() Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可重複設定流產假之懷孕日數!")
                    Return
                End If
            End If

            If action = "copy" Or dt.Rows.Count <= 0 Then
                ls.Leave_kind = ddlLeaveKind.SelectedValue
                ls.Leave_type = ddlLeaveType.SelectedValue
                ls.Memcod = ddlMEMCOD.SelectedValue
                ls.Limit = CommonFun.getDouble(tbLimit.Text.Trim())
                ls.limit_date = tblimit_Date.Text.Trim()
                ls.Min_hour = CommonFun.ConvertToDouble(ddlMinHour.SelectedValue)
                ls.Ifholiday_flag = rblHolidayYN.SelectedValue
                ls.Ifoccur_date_flag = rblOccurDateYN.SelectedValue
                ls.Ifmustattach_flag = rblMustAttachYN.SelectedValue
                ls.many_days = IIf(rblMustAttachYN.SelectedValue = "0", CommonFun.ConvertToDouble(tbManyDays.Text.Trim()), 0)
                ls.Ifattach_flag = rblReAttachYN.SelectedValue
                ls.Message_flag = CommonFun.ConvertToDouble(tbMessage.Text.Trim())
                ls.Applystop_sdate = UcStopDate.Start_date
                ls.Applystop_edate = UcStopDate.End_date
                ls.Applystop_stime = UcStopDate.Start_time
                ls.Applystop_etime = UcStopDate.End_time
                ls.Ifbatch_apply = rblBatchApply.SelectedValue
                ls.Reciprocal_days = CommonFun.ConvertToDouble(tbReciprocalDays.Text.Trim())

                Using trans As New TransactionScope
                    ls.Insert()
                    dt = ls.GetDataByLeaveKind(Orgcode, ddlLeaveKind.SelectedValue, ddlLeaveType.SelectedValue, ddlMEMCOD.SelectedValue)
                    If dt Is Nothing Then Return
                    Dim id As Integer = CInt(dt.Rows(0)("id").ToString())

                    ' 假別如為「喪假」，提供「加入親屬」按鈕
                    If Me.ddlLeaveType.SelectedValue = "10" Then
                        ' 儲存 親屬設定
                        saveDetail(id)
                    End If

                    ' 假別如為「流產假」，提供「流產設定」按鈕
                    If Me.ddlLeaveType.SelectedValue = "13" Then
                        ' 儲存 流產假設定
                        saveDetail02(id)
                    End If

                    trans.Complete()
                End Using

                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "FSC4108_01.aspx?qk=" & Request.QueryString("qk") & "&ql=" & Request.QueryString("ql"))
            Else
                ls.Leave_kind = dt.Rows(0)("Leave_kind").ToString()
                ls.Leave_type = dt.Rows(0)("Leave_type").ToString()
                ls.Memcod = dt.Rows(0)("Memcod").ToString()
                ls.Limit = CommonFun.getDouble(tbLimit.Text.Trim())
                ls.limit_date = tblimit_Date.Text.Trim()
                ls.Min_hour = CommonFun.ConvertToDouble(ddlMinHour.SelectedValue)
                ls.Ifholiday_flag = rblHolidayYN.SelectedValue
                ls.Ifoccur_date_flag = rblOccurDateYN.SelectedValue
                ls.Ifmustattach_flag = rblMustAttachYN.SelectedValue
                ls.many_days = IIf(rblMustAttachYN.SelectedValue = "0", CommonFun.ConvertToDouble(tbManyDays.Text.Trim()), 0)
                ls.Ifattach_flag = rblReAttachYN.SelectedValue
                ls.Message_flag = CommonFun.ConvertToDouble(tbMessage.Text.Trim())
                ls.Applystop_sdate = UcStopDate.Start_date
                ls.Applystop_edate = UcStopDate.End_date
                ls.Applystop_stime = UcStopDate.Start_time
                ls.Applystop_etime = UcStopDate.End_time
                ls.Ifbatch_apply = rblBatchApply.SelectedValue
                ls.Reciprocal_days = CommonFun.ConvertToDouble(tbReciprocalDays.Text.Trim())

                Using trans As New TransactionScope
                    ls.Update()
                    Dim id As Integer = CInt(dt.Rows(0)("id").ToString())

                    ' 假別如為「喪假」，提供「加入親屬」按鈕
                    If Me.ddlLeaveType.SelectedValue = "10" Then
                        saveDetail(id)
                    End If

                    ' 假別如為「流產假」，提供「流產設定」按鈕
                    If Me.ddlLeaveType.SelectedValue = "13" Then
                        saveDetail02(id)
                    End If

                    trans.Complete()
                End Using

                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "FSC4108_01.aspx?qk=" & Request.QueryString("qk") & "&ql=" & Request.QueryString("ql"))
            End If

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    ''' <summary>
    ''' 「加入親屬設定」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbJoin_Click(sender As Object, e As EventArgs) Handles cbJoin.Click
        Dim dt As DataTable = CType(ViewState("gvListData"), DataTable)

        If dt Is Nothing Then
            dt = New DataTable()
            dt.Columns.Add("id")
            dt.Columns.Add("Detail_code_id")
            dt.Columns.Add("Limitdays")
            dt.Columns.Add("Leave_setting_id")
        End If

        For i As Integer = 0 To gvList.Rows.Count - 1
            Dim gr As GridViewRow = gvList.Rows(i)
            Dim dr As DataRow = dt.Rows(i)
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays"), TextBox)

            dr("Detail_code_id") = ddl.SelectedValue
            dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
        Next

        Dim newRow As DataRow = dt.NewRow()

        dt.Rows.InsertAt(newRow, dt.Rows.Count + 1)
        ViewState("gvListData") = dt
        gvListBind()
    End Sub

    ''' <summary>
    ''' 「流產假設定」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbSet_Click(sender As Object, e As EventArgs) Handles cbSet.Click
        Dim dt As DataTable = CType(ViewState("gvListData02"), DataTable)

        If dt Is Nothing Then
            dt = New DataTable()
            dt.Columns.Add("id")
            dt.Columns.Add("Detail_code_id")
            dt.Columns.Add("Limitdays")
            dt.Columns.Add("Leave_setting_id")
        End If

        For i As Integer = 0 To gvList02.Rows.Count - 1
            Dim gr As GridViewRow = gvList02.Rows(i)
            Dim dr As DataRow = dt.Rows(i)
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode02"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays02"), TextBox)

            dr("Detail_code_id") = ddl.SelectedValue
            dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
        Next

        Dim newRow As DataRow = dt.NewRow()

        dt.Rows.InsertAt(newRow, dt.Rows.Count + 1)
        ViewState("gvListData02") = dt
        gvListBind02()
    End Sub

    ''' <summary>
    ''' 繫結 假別/差勤組別/職務類別
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim lk As New SYS.Logic.LeaveKind()
        Dim c As New SYS.Logic.CODE()

        Try
            ' 繫結 假別
            Me.ddlLeaveType.DataTextField = "Leave_name"
            Me.ddlLeaveType.DataValueField = "Leave_type"
            Me.ddlLeaveType.DataSource = New SYS.Logic.LeaveType().GetLeaveType(Orgcode)
            Me.ddlLeaveType.DataBind()
            ddlLeaveType.Items.Insert(0, New ListItem("請選擇", ""))

            ' 繫結 差勤組別
            Me.ddlLeaveKind.DataTextField = "Kind_name"
            Me.ddlLeaveKind.DataValueField = "Leave_kind"
            Me.ddlLeaveKind.DataSource = lk.GetData(Orgcode, "")
            Me.ddlLeaveKind.DataBind()

            ' 繫結 職務類別
            Me.ddlMEMCOD.DataTextField = "CODE_DESC1"
            Me.ddlMEMCOD.DataValueField = "CODE_NO"
            Me.ddlMEMCOD.DataSource = c.GetData("023", "022")
            Me.ddlMEMCOD.DataBind()
            Me.ddlMEMCOD.Items.Insert(0, New ListItem("請選擇", ""))

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub ddlLeaveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLeaveType.SelectedIndexChanged
        showButton()
    End Sub

    Protected Sub showButton()
        '還原預設值
        Label_TR05.Text = "申請期限日期/天數"
        TR06.Visible = True
        TR09.Visible = True
        rblBatchApply.Items(0).Selected = True
        rblBatchApply.Items(1).Selected = False
        TR10.Visible = True
        rblHolidayYN.Items(0).Selected = True
        rblHolidayYN.Items(1).Selected = False
        TR11.Visible = True
        rblOccurDateYN.Items(0).Selected = True
        rblOccurDateYN.Items(1).Selected = False
        rblMustAttachYN.Items(0).Selected = True
        rblMustAttachYN.Items(1).Selected = False
        cbJoin.Visible = False
        cbSet.Visible = False
        rbdays.Checked = False
        rbdate.Checked = True
        tblimit_Date.Text = ""
        tblimit_Date.Enabled = True
        tbLimit.Text = ""
        tbLimit.Enabled = False

        ' 流產假，提供「流產設定」按鈕
        If ddlLeaveType.SelectedValue = "13" Then
            cbJoin.Visible = False
            cbSet.Visible = True
        End If

        ' 陪產假
        If Me.ddlLeaveType.SelectedValue = "22" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR10.Visible = False
            rblHolidayYN.SelectedValue = "1"
        End If

        ' 家庭照顧假
        If Me.ddlLeaveType.SelectedValue = "25" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
        End If

        ' 器官捐贈假
        If Me.ddlLeaveType.SelectedValue = "23" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
        End If

        ' 五一勞動節 / 公出 / 天災假 / 出差補休 / 生理假 / 加班假 / 休假 / 病假 / 事假
        If Me.ddlLeaveType.SelectedValue = "34" Or Me.ddlLeaveType.SelectedValue = "07" Or Me.ddlLeaveType.SelectedValue = "18" Or Me.ddlLeaveType.SelectedValue = "20" Or Me.ddlLeaveType.SelectedValue = "24" Or Me.ddlLeaveType.SelectedValue = "04" Or Me.ddlLeaveType.SelectedValue = "03" Or Me.ddlLeaveType.SelectedValue = "02" Or Me.ddlLeaveType.SelectedValue = "01" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR09.Visible = False
            rblBatchApply.SelectedValue = "0"
            TR10.Visible = False
            rblHolidayYN.SelectedValue = "1"
            TR11.Visible = False
            rblOccurDateYN.SelectedValue = "1"
            rblMustAttachYN.SelectedValue = "1"
        End If

        ' 加班
        If Me.ddlLeaveType.SelectedValue = "80" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR09.Visible = False
            rblBatchApply.SelectedValue = "0"
            TR11.Visible = False
            rblHolidayYN.SelectedValue = "1"
            rblMustAttachYN.SelectedValue = "1"
        End If

        ' 值班補休
        If Me.ddlLeaveType.SelectedValue = "32" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR09.Visible = False
            rblBatchApply.SelectedValue = "0"
            TR10.Visible = False
            rblHolidayYN.SelectedValue = "1"
            TR11.Visible = False
            rblOccurDateYN.SelectedValue = "1"
        End If

        ' 專案加班
        If Me.ddlLeaveType.SelectedValue = "82" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR09.Visible = False
            rblBatchApply.SelectedValue = "0"
            TR11.Visible = False
            rblOccurDateYN.SelectedValue = "1"
        End If

        ' 產前假
        If Me.ddlLeaveType.SelectedValue = "21" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR10.Visible = False
            rblHolidayYN.SelectedValue = "1"
            TR11.Visible = False
            rblOccurDateYN.SelectedValue = "1"
        End If

        ' 娩假 / 婚假
        If Me.ddlLeaveType.SelectedValue = "09" Or Me.ddlLeaveType.SelectedValue = "08" Then
            Label_TR05.Text = "補申請期限日期/天數"
        End If

        ' 喪假，提供「加入親屬」按鈕
        If ddlLeaveType.SelectedValue = "10" Then
            cbJoin.Visible = True
            cbSet.Visible = False
            Label_TR05.Text = "補申請期限日期/天數"
        End If

        ' 公差
        If Me.ddlLeaveType.SelectedValue = "05" Then
            Label_TR05.Text = "補申請期限日期/天數"
            TR06.Visible = False
            tbReciprocalDays.Text = "0"
            TR09.Visible = False
            rblBatchApply.SelectedValue = "0"
            TR11.Visible = False
            rblOccurDateYN.SelectedValue = "1"
            rblMustAttachYN.SelectedValue = "1"
        End If
    End Sub
    ''' <summary>
    ''' 依傳入值顯示相關資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bind()
        Dim orgcode As String = Request.QueryString("orgcode")
        Dim leave_kind As String = Request.QueryString("leave_kind")
        Dim leave_type As String = Request.QueryString("leave_type")
        Dim memcod As String = Request.QueryString("memcod")
        Dim action As String = Request.QueryString("action")
        Dim lsd As New LeaveSettingDetail()

        If String.IsNullOrEmpty(orgcode) Or String.IsNullOrEmpty(leave_kind) Or String.IsNullOrEmpty(leave_type) Then
            Return
        End If

        Me.ddlLeaveKind.SelectedValue = leave_kind
        Me.ddlLeaveKind.Enabled = False
        Me.ddlLeaveType.SelectedValue = leave_type
        Me.ddlLeaveType.Enabled = False

        If action <> "copy" Then
            Me.ddlMEMCOD.SelectedValue = memcod
            Me.ddlMEMCOD.Enabled = False
        End If

        Try
            Dim dt As DataTable = New LeaveSetting().GetDataByLeaveKind(orgcode, leave_kind, leave_type, memcod)

            For Each dr As DataRow In dt.Rows
                Me.ddlLeaveKind.SelectedValue = dr("leave_kind").ToString()
                Me.ddlLeaveType.SelectedValue = dr("leave_type").ToString()
                showButton()
                Me.ddlMEMCOD.SelectedValue = dr("Memcod").ToString()
                Me.tbDesc.Text = dr("Describe").ToString()

                If Not String.IsNullOrEmpty(dr("Limit_date").ToString()) Then
                    rbdays.Checked = False
                    rbdate.Checked = True
                    Me.tblimit_Date.Text = dr("Limit_date").ToString()
                    Me.tblimit_Date.Enabled = True
                    Me.tbLimit.Text = ""
                    Me.tbLimit.Enabled = False
                ElseIf Not String.IsNullOrEmpty(dr("Limit").ToString()) Then
                    rbdays.Checked = True
                    rbdate.Checked = False
                    Me.tblimit_Date.Enabled = False
                    Me.tblimit_Date.Text = ""
                    Me.tbLimit.Text = dr("Limit").ToString()
                    Me.tbLimit.Enabled = True
                End If

                Me.ddlMinHour.SelectedValue = dr("Min_hour").ToString()
                Me.rblHolidayYN.SelectedValue = dr("Ifholiday_flag").ToString()
                Me.rblOccurDateYN.SelectedValue = dr("Ifoccur_date_flag").ToString()
                Me.rblMustAttachYN.SelectedValue = dr("Ifmustattach_flag").ToString()
                ShowManyDays()
                Me.tbManyDays.Text = dr("many_days").ToString()
                Me.rblReAttachYN.SelectedValue = dr("Ifattach_flag").ToString()
                Me.tbMessage.Text = dr("Message_flag").ToString()
                Me.UcStopDate.Start_date = dr("Applystop_sdate").ToString()
                Me.UcStopDate.End_date = dr("Applystop_edate").ToString()
                Me.UcStopDate.Start_time = dr("Applystop_stime").ToString()
                Me.UcStopDate.End_time = dr("Applystop_etime").ToString()
                Me.rblBatchApply.SelectedValue = dr("Ifbatch_apply").ToString()
                Me.tbReciprocalDays.Text = dr("Reciprocal_days").ToString()

                Dim dtDetail As DataTable = lsd.GetDataByMasterId(CInt(dr("id").ToString()))


                ' 假別如為「喪假」，提供「加入親屬」按鈕
                If Me.ddlLeaveType.SelectedValue = "10" Then
                    Me.gvList.DataSource = dtDetail
                    Me.gvList.DataBind()

                    ViewState("gvListData") = dtDetail
                End If

                ' 假別如為「流產假」，提供「流產設定」按鈕
                If Me.ddlLeaveType.SelectedValue = "13" Then
                    Me.gvList02.DataSource = dtDetail
                    Me.gvList02.DataBind()

                    ViewState("gvListData02") = dtDetail
                End If
            Next

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    ''' <summary>
    ''' 是否必須上傳附件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub rblMustAttachYN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblMustAttachYN.SelectedIndexChanged
        ShowManyDays()
    End Sub

    Protected Sub ShowManyDays()
        If rblMustAttachYN.SelectedValue = "0" Then
            tbManyDays.Visible = True
            Label1.Visible = True
        Else
            tbManyDays.Visible = False
            Label1.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' 儲存 親屬設定
    ''' </summary>
    ''' <param name="Leave_setting_id"></param>
    ''' <remarks></remarks>
    Protected Sub saveDetail(Optional ByVal Leave_setting_id As Integer = Nothing)
        Dim userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim lsd As New LeaveSettingDetail

        For Each gr As GridViewRow In gvList.Rows
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays"), TextBox)
            Dim lbID As Label = CType(gr.FindControl("lbID"), Label)

            If lbID.Text <> "" Then
                lsd.Detail_code_id = ddl.SelectedValue
                lsd.Leave_setting_id = Leave_setting_id
                lsd.Limitdays = CommonFun.ConvertToDouble(tb.Text)
                lsd.update_userid = userid
                lsd.id = CInt(lbID.Text)
                lsd.UpdateData()
            Else
                lsd.Detail_code_id = ddl.SelectedValue
                lsd.Leave_setting_id = Leave_setting_id
                lsd.Limitdays = CommonFun.ConvertToDouble(tb.Text)
                lsd.update_userid = userid
                lsd.InsertData()
            End If
        Next
    End Sub

    Protected Function checkDetail() As Boolean
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("Detail_code_id")
        dt.Columns.Add("Limitdays")
        dt.Columns.Add("Leave_setting_id")

        For i As Integer = 0 To gvList.Rows.Count - 1
            Dim gr As GridViewRow = gvList.Rows(i)
            Dim dr As DataRow = dt.NewRow()
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays"), TextBox)

            dr("Detail_code_id") = ddl.SelectedValue
            dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
            dt.Rows.Add(dr)
        Next

        Dim tmp As DataTable = dt.DefaultView.ToTable(True, New String() {"Detail_code_id"})
        For Each dr As DataRow In tmp.Rows
            Dim rows() As DataRow = dt.Select(String.Format("Detail_code_id = '{0}'", dr("Detail_code_id").ToString()))
            If rows.Length > 1 Then
                Return False
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' 儲存 流產假設定
    ''' </summary>
    ''' <param name="Leave_setting_id"></param>
    ''' <remarks></remarks>
    Protected Sub saveDetail02(Optional ByVal Leave_setting_id As Integer = Nothing)
        Dim userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim lsd As New LeaveSettingDetail
        For Each gr As GridViewRow In gvList02.Rows
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode02"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays02"), TextBox)
            Dim lbID As Label = CType(gr.FindControl("lbID02"), Label)

            If lbID.Text <> "" Then
                lsd.Detail_code_id = ddl.SelectedValue
                lsd.Leave_setting_id = Leave_setting_id
                lsd.Limitdays = CommonFun.ConvertToDouble(tb.Text)
                lsd.update_userid = userid
                lsd.id = CInt(lbID.Text)
                lsd.UpdateData()
            Else
                lsd.Detail_code_id = ddl.SelectedValue
                lsd.Leave_setting_id = Leave_setting_id
                lsd.Limitdays = CommonFun.ConvertToDouble(tb.Text)
                lsd.update_userid = userid
                lsd.InsertData()
            End If
        Next
    End Sub

    Protected Function checkDetail02() As Boolean
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("Detail_code_id")
        dt.Columns.Add("Limitdays")
        dt.Columns.Add("Leave_setting_id")

        For i As Integer = 0 To gvList02.Rows.Count - 1
            Dim gr As GridViewRow = gvList02.Rows(i)
            Dim dr As DataRow = dt.NewRow()
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode02"), DropDownList)
            Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays02"), TextBox)

            dr("Detail_code_id") = ddl.SelectedValue
            dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
            dt.Rows.Add(dr)
        Next

        Dim tmp As DataTable = dt.DefaultView.ToTable(True, New String() {"Detail_code_id"})
        For Each dr As DataRow In tmp.Rows
            Dim rows() As DataRow = dt.Select(String.Format("Detail_code_id = '{0}'", dr("Detail_code_id").ToString()))
            If rows.Length > 1 Then
                Return False
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' 刪除 親屬設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub doDelete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDel As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnDel.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim lbId As Label = CType(row.FindControl("lbID"), Label)
        Dim lsd As New LeaveSettingDetail
        Dim index As Integer = row.RowIndex
        Try
            If lbId.Text <> "" Then
                lsd.DeleteData(CInt(lbId.Text))
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            End If

            Dim dt As DataTable = CType(ViewState("gvListData"), DataTable)
            For i As Integer = 0 To gvList.Rows.Count - 1
                Dim gr As GridViewRow = gvList.Rows(i)
                Dim dr As DataRow = dt.Rows(i)
                Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode"), DropDownList)
                Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays"), TextBox)

                dr("Detail_code_id") = ddl.SelectedValue
                dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
            Next

            dt.Rows.RemoveAt(index)
            ViewState("gvListData") = dt
            gvListBind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    ''' <summary>
    ''' 刪除 流產假設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub doDelete02(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDel As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnDel.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim lbId As Label = CType(row.FindControl("lbID02"), Label)
        Dim lsd As New LeaveSettingDetail
        Dim index As Integer = row.RowIndex
        Try
            If lbId.Text <> "" Then
                lsd.DeleteData(CInt(lbId.Text))
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            End If

            Dim dt As DataTable = CType(ViewState("gvListData02"), DataTable)
            For i As Integer = 0 To gvList.Rows.Count - 1
                Dim gr As GridViewRow = gvList.Rows(i)
                Dim dr As DataRow = dt.Rows(i)
                Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode02"), DropDownList)
                Dim tb As TextBox = CType(gr.FindControl("ltbLimitdays02"), TextBox)

                dr("Detail_code_id") = ddl.SelectedValue
                dr("Limitdays") = CommonFun.ConvertToDouble(tb.Text)
            Next

            dt.Rows.RemoveAt(index)
            ViewState("gvListData02") = dt
            gvListBind02()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    ''' <summary>
    ''' bind 親屬設定 資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub gvListBind()
        Me.gvList.DataSource = CType(ViewState("gvListData"), DataTable)
        Me.gvList.DataBind()
    End Sub

    ''' <summary>
    ''' bind 流產假設定 資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub gvListBind02()
        Me.gvList02.DataSource = CType(ViewState("gvListData02"), DataTable)
        Me.gvList02.DataBind()
    End Sub

    ''' <summary>
    ''' 資料繫結 親屬設定
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub gvList_DataBound(sender As Object, e As EventArgs) Handles gvList.DataBound
        For Each gr As GridViewRow In gvList.Rows
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode"), DropDownList)
            Dim lbDetailCode As Label = CType(gr.FindControl("lbDetailCode"), Label)
            Dim lbID As Label = CType(gr.FindControl("lbID"), Label)

            ddl.DataTextField = "CODE_DESC1"
            ddl.DataValueField = "CODE_NO"
            ddl.DataSource = New SYS.Logic.CODE().GetData("023", "024")
            ddl.DataBind()

            If lbDetailCode.Text <> "" Then
                ddl.SelectedValue = lbDetailCode.Text
            End If
            If lbID.Text <> "" Then
                ddl.Enabled = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' 資料繫結 流產假設定
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub gvList02_DataBound(sender As Object, e As EventArgs) Handles gvList02.DataBound
        For Each gr As GridViewRow In gvList02.Rows
            Dim ddl As DropDownList = CType(gr.FindControl("ddlDetailCode02"), DropDownList)
            Dim lbDetailCode As Label = CType(gr.FindControl("lbDetailCode02"), Label)
            Dim lbID As Label = CType(gr.FindControl("lbID02"), Label)

            ddl.DataTextField = "CODE_DESC1"
            ddl.DataValueField = "CODE_NO"
            ddl.DataSource = New SYS.Logic.CODE().GetData("023", "032")
            ddl.DataBind()

            If lbDetailCode.Text <> "" Then
                ddl.SelectedValue = lbDetailCode.Text
            End If
            If lbID.Text <> "" Then
                ddl.Enabled = False
            End If
        Next
    End Sub

    Protected Sub rbdate_CheckedChanged(sender As Object, e As EventArgs) Handles rbdate.CheckedChanged
        If rbdate.Checked Then
            tbLimit.Text = ""
            tblimit_Date.Enabled = True
            tbLimit.Enabled = False
        End If
    End Sub

    Protected Sub rbdays_CheckedChanged(sender As Object, e As EventArgs) Handles rbdays.CheckedChanged
        If rbdays.Checked Then
            tblimit_Date.Text = ""
            tblimit_Date.Enabled = False
            tbLimit.Enabled = True
        End If
    End Sub
End Class
