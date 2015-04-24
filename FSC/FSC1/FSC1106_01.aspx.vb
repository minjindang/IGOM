Imports System.Data
Imports FSC.Logic
Imports System.Transactions
Imports System.Collections.Generic

Partial Class FSC1106_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getSchedule("doPostBack")
        If IsPostBack Then
            Return
        End If
        initData()
    End Sub

#Region "初始化"
    Protected Sub initData()
        Dep_Bind()
        Apply_Name_Bind()
        Shift_Name_Bind()
        DutyChange_Bind()
        getSchedule()

        cbInsert.Visible = True
        cbSubmit.Visible = True
        cbUpdate.Visible = False
        cbCancel.Visible = False
    End Sub
#End Region

#Region "連繫資料"
    Protected Sub Dep_Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcApply_Depart.Orgcode = orgcode

        UcShift_Depart.Orgcode = orgcode
         
    End Sub

    Protected Sub Apply_Name_Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlApply_Username.Items.Clear()
        If Not String.IsNullOrEmpty(UcApply_Depart.SelectedValue) Then
            ddlApply_Username.DataSource = New FSC.Logic.Personnel().GetDataByOnDuty(orgcode, UcApply_Depart.SelectedValue.Substring(0, 2), "1")
            ddlApply_Username.DataBind()
        End If
        ddlApply_Username.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Shift_Name_Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlShift_Username.Items.Clear()
        If Not String.IsNullOrEmpty(UcShift_Depart.SelectedValue) Then
            ddlShift_Username.DataSource = New FSC.Logic.Personnel().GetDataByOnDuty(orgcode, UcShift_Depart.SelectedValue, "1")
            ddlShift_Username.DataBind()
        End If
        ddlShift_Username.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcApply_Depart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcApply_Depart.SelectedIndexChanged
        Apply_Name_Bind()
        getSchedule()
    End Sub

    Protected Sub UcShift_Depart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcShift_Depart.SelectedIndexChanged
        Shift_Name_Bind()
        getSchedule()
    End Sub

    Protected Sub ddlApply_Username_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApply_Username.SelectedIndexChanged
        getSchedule()
    End Sub

    Protected Sub ddlShift_Username_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlShift_Username.SelectedIndexChanged
        getSchedule()
    End Sub

    Protected Sub ddlDuty_type_CodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDuty_type.SelectedIndexChanged
        getSchedule()
        If Me.ddlDuty_type.SelectedValue = "2" Then
            Me.tr1.Visible = True
            Me.tr2.Visible = True
            Me.tr3.Visible = True
        Else
            Me.tbDuty_reason.Text = ""
            Me.lbSchedule_id.Text = ""
            Me.lbSchedule_Name.Text = ""
            Me.tr1.Visible = False
            Me.tr2.Visible = True
            Me.tr3.Visible = False
        End If
    End Sub

    Protected Sub DutyChange_Bind()
        Try
            Dim dt As DataTable = New DutyChange().getNotSendData()
            dt.Columns.Add("Num")
            dt.Columns.Add("Duty_typeName")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("Num") = i + 1
                dt.Rows(i)("Duty_typeName") = IIf(dt.Rows(i)("Duty_type").ToString() = "1", "代值", "換值")
            Next
            gv.DataSource = dt
            gv.DataBind()

            ViewState("dt") = dt
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, ex.Message())
        End Try
    End Sub

    Public Function getOn_DutyMember(ByVal mdt As DataTable) As DataTable
        Dim dt As DataTable = New DataTable
        If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
            dt = mdt.Clone()
            Dim tmpdt As DataTable = New Personnel().GetDataByOnDuty("1")
            For Each mdr As DataRow In mdt.Rows
                Dim tdr() As DataRow = tmpdt.Select("id_card=" + mdr("id_card").ToString() + " and isnull(Quit_job_flag,'') <> 'Y' ")
                If tdr.Length > 0 Then
                    dt.ImportRow(mdr)
                End If
            Next
        End If
        Return dt
    End Function

    Public Sub getSchedule(Optional ByVal type As String = Nothing)
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim target As String = Me.Request.Form("__EVENTTARGET")

        If (type = "doPostBack" AndAlso target = UpdatePanel3.ClientID) OrElse type Is Nothing Then
            Dim dt As DataTable = New ScheduleSetting().GetDataByQuery(orgcode, ddlApply_Username.SelectedValue, IIf(ddlDuty_type.SelectedValue = "1", UcShift_Dutydate.Text, UcOriginal_Dutydate.Text))
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                If ddlDuty_type.SelectedValue = "1" Then
                    lbShift_Schedule_id.Text = dt.Rows(0)("Schedule_Id").ToString()
                    lbShift_Schedule_Name.Text = dt.Rows(0)("Name").ToString()
                Else
                    lbSchedule_id.Text = dt.Rows(0)("Schedule_Id").ToString()
                    lbSchedule_Name.Text = dt.Rows(0)("Name").ToString()
                End If
            Else
                If ddlDuty_type.SelectedValue = "1" Then
                    lbShift_Schedule_id.Text = ""
                    lbShift_Schedule_Name.Text = ""
                Else
                    lbSchedule_id.Text = ""
                    lbSchedule_Name.Text = ""
                End If
            End If
            If ddlDuty_type.SelectedValue = "2" Then
                dt = New ScheduleSetting().GetDataByQuery(orgcode, ddlShift_Username.SelectedValue, UcShift_Dutydate.Text)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso ddlDuty_type.SelectedValue = "2" Then

                    lbShift_Schedule_id.Text = dt.Rows(0)("Schedule_Id").ToString()
                    lbShift_Schedule_Name.Text = dt.Rows(0)("Name").ToString()

                Else
                    lbShift_Schedule_id.Text = ""
                    lbShift_Schedule_Name.Text = ""
                End If
            End If
        End If
    End Sub
#End Region

    Protected Sub GridView_SaTEL_RowCommand(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gv.Rows(index)
        Dim id As String = CType(row.FindControl("lbid"), Label).Text
        Dim dc As DutyChange = New DutyChange

        Try
            If (e.CommandName = "del") Then
                dc.id = id
                dc.delete()

                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
                initData()
            ElseIf e.CommandName = "upd" Then
                cbInsert.Visible = False
                cbSubmit.Visible = False
                cbUpdate.Visible = True
                cbCancel.Visible = True

                dc.id = id
                Dim dt As DataTable = dc.getData()
                For Each dr As DataRow In dt.Rows
                    hfid.Value = dr("id").ToString()
                    UcApply_Depart.SelectedValue = dr("Apply_Depart_id").ToString()
                    Apply_Name_Bind()
                    ddlApply_Username.SelectedValue = dr("Apply_Idcard").ToString()
                    UcShift_Depart.SelectedValue = dr("Shift_Depart_id").ToString()
                    Shift_Name_Bind()
                    ddlShift_Username.SelectedValue = dr("Shift_Idcard").ToString()
                    UcOriginal_Dutydate.Text = dr("Original_Dutydate").ToString()
                    UcShift_Dutydate.Text = dr("Shift_Dutydate").ToString()
                    ddlDuty_type.SelectedValue = dr("Duty_type").ToString()
                    lbSchedule_id.Text = dr("Schedule_id").ToString()
                    lbShift_Schedule_id.Text = dr("Shift_Schedule_id").ToString()
                    getSchedule()
                    tbDuty_reason.Text = dr("Duty_reason").ToString()
                Next
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "更新"
    Protected Sub cbUpdate_Click(sender As Object, e As EventArgs) Handles cbUpdate.Click
        Dim dc As DutyChange = New DutyChange

        If Not String.IsNullOrEmpty(checkMsg()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, checkMsg())
            Return
        End If

        Try
            dc = getDutyChange()
            dc.id = hfid.Value
            dc.update()

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            initData()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

#Region "新增"
    Protected Sub cbInsert_Click(sender As Object, e As EventArgs) Handles cbInsert.Click
        Dim dc As DutyChange = New DutyChange

        If Not String.IsNullOrEmpty(checkMsg()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, checkMsg())
            Return
        End If

        Try
            dc = getDutyChange()
            dc.insert()

            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            initData()

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

    Protected Function getDutyChange() As DutyChange
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dc As DutyChange = New DutyChange
        dc.Apply_Orgcode = orgcode
        dc.Apply_Depart_id = New FSC.Logic.DepartEmp().GetDepartId(ddlApply_Username.SelectedValue)  'UcApply_Depart.SelectedValue
        dc.Apply_Idcard = ddlApply_Username.SelectedValue
        dc.Apply_Username = ddlApply_Username.SelectedItem.Text
        dc.Apply_Date = DateTimeInfo.GetRocTodayString("yyyyMMdd")
        dc.Write_Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        dc.Write_Depart_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        dc.Write_Idcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        dc.Write_Username = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        dc.Shift_Orgcode = orgcode
        dc.Shift_Depart_id = New FSC.Logic.DepartEmp().GetDepartId(ddlShift_Username.SelectedValue)
        dc.Shift_Idcard = ddlShift_Username.SelectedValue
        dc.Shift_Username = ddlShift_Username.SelectedItem.Text
        dc.Original_Dutydate = UcOriginal_Dutydate.Text
        dc.Shift_Dutydate = UcShift_Dutydate.Text
        dc.Duty_type = ddlDuty_type.SelectedValue
        dc.Schedule_id = lbSchedule_id.Text
        dc.Shift_Schedule_id = lbShift_Schedule_id.Text
        dc.Duty_reason = tbDuty_reason.Text.Trim()
        dc.Duty_Sendtype = "0"
        dc.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        Return dc
    End Function

#Region "檢核申請資料"
    Protected Function checkMsg() As String
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(ddlApply_Username.SelectedValue) Then
            Return "請選擇申請代(換)值人員!"
        End If
        If String.IsNullOrEmpty(ddlShift_Username.SelectedValue) Then
            Return "請選擇指定代(換)值人員!"
        End If
        If String.IsNullOrEmpty(UcShift_Dutydate.Text) Then
            Return "代(換)值班日期不可空白!"
        End If
        If ddlDuty_type.SelectedValue = "2" AndAlso String.IsNullOrEmpty(UcOriginal_Dutydate.Text) Then
            Return "原值班日期不可空白!"
        End If
        If String.IsNullOrEmpty(tbDuty_reason.Text.Trim()) Then
            Return "事由不可空白!"
        ElseIf tbDuty_reason.Text.Trim.Length > 50 Then
            Return "事由請勿輸入超過50字!"
        End If
        If String.IsNullOrEmpty(lbShift_Schedule_id.Text) Then
            Return "無該時段代(換)班別!"
        End If
        If ddlDuty_type.SelectedValue = "2" AndAlso String.IsNullOrEmpty(lbSchedule_id.Text) Then
            Return "無該時段原班別!"
        End If
        Return msg
    End Function
#End Region

#Region "送出申請"
    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        Dim msg As String = String.Empty
        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "無可送出申請的資料!")
            Return
        End If

        Dim dclist As IList(Of DutyChange) = CommonFun.ConvertToList(Of DutyChange)(dt)

        For Each dc As DutyChange In dclist
            If New DutyChange().getDataByShift_Dutydate(dc.Original_Dutydate, dc.Shift_Dutydate).Rows.Count > 0 Then
                msg &= "已有代(換)值日期：" & dc.Shift_Dutydate & "的資料，不可提出申請!\n"
                Continue For
            End If
            Try
                Using trans As New TransactionScope
                    Dim flow_id As String = New SYS.Logic.FlowId().GetFlowId(dc.Apply_Orgcode, "001010")
                    Dim Service_type As String = String.Empty
                    Dim mdt As DataTable = New DepartEmp().GetDataByIdcard(dc.Apply_Idcard)
                    If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
                        Service_type = mdt.Rows(0)("Service_type").ToString()
                    End If

                    f.FlowId = flow_id
                    f.Orgcode = dc.Apply_Orgcode
                    f.DepartId = dc.Apply_Depart_id
                    f.ApplyIdcard = dc.Apply_Idcard
                    f.ApplyName = dc.Apply_Username
                    f.ApplyPosid = New Personnel().GetColumnValue("Title_no", dc.Apply_Idcard)
                    f.ApplyStype = Service_type
                    f.WriterOrgcode = dc.Write_Orgcode
                    f.WriterDepartid = dc.Write_Depart_id
                    f.WriterIdcard = dc.Write_Idcard
                    f.WriterName = dc.Write_Username
                    f.WriterPosid = New Personnel().GetColumnValue("Title_no", dc.Write_Idcard)
                    f.WriteTime = Date.Now
                    f.FormId = "001010"
                    f.Reason = dc.Duty_reason
                    f.ChangeUserid = dc.Change_userid


                    dc.flow_id = flow_id
                    dc.Duty_Sendtype = "1"

                    dc.update()

                    Dim fn As New SYS.Logic.FlowNext()
                    fn.Orgcode = dc.Apply_Orgcode
                    fn.FlowId = flow_id
                    fn.NextOrgcode = dc.Shift_Orgcode
                    fn.NextDepartid = dc.Shift_Depart_id
                    fn.NextPosid = New FSC.Logic.Personnel().GetColumnValue("title_no", dc.Shift_Idcard)
                    fn.NextIdcard = dc.Shift_Idcard
                    fn.NextName = dc.Shift_Username

                    SYS.Logic.CommonFlow.AddFlow(f, fn)

                    trans.Complete()
                End Using
            Catch fex As FlowException
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
                Return
            Catch ex As Exception
                msg &= "代(換)值日期：" & dc.Shift_Dutydate & "送出失敗!\n"
            End Try
        Next

        If String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg.TrimEnd("\n"))
        End If
        initData()
    End Sub
#End Region

End Class


