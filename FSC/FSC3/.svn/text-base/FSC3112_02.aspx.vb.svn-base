Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC3112_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            InitData()
            Bind()
        End If
    End Sub

#Region "顯示下拉選單"
    Protected Sub InitData()
        BindSchedule()
    End Sub

    Protected Sub BindSchedule()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sche As New FSC.Logic.Schedule()
        ddlSchedule.DataSource = sche.GetData(Orgcode)
        ddlSchedule.DataBind()
    End Sub

#End Region

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id As String = Request.QueryString("id")
        Dim sche As New FSC.Logic.ScheduleSetting()

        Dim dt As DataTable = sche.GetDataByid(id)
        For Each dr As DataRow In dt.Rows
            UcDate.Text = dr("Sche_date").ToString()
            UcUserDialog.Text = dr("User_name").ToString()
            UcUserDialog.Value = dr("Id_card").ToString()
            ddlSchedule.SelectedValue = dr("Schedule_id").ToString()
            tbScheduleHours.Text = dr("Schedule_hours").ToString()
            tbPayHours.Text = dr("Pay_hours").ToString()
            tbRestHours.Text = dr("Rest_hours").ToString()
        Next

    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC3112_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim scheSetting As New FSC.Logic.ScheduleSetting()

        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入值班日期!")
            Return
        End If
        If String.IsNullOrEmpty(UcUserDialog.Value) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇值班人員!")
            Return
        End If
        If Not CommonFun.IsNum(tbScheduleHours.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "值班時數請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(tbPayHours.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已領時數請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(tbRestHours.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已休時數請輸入數字!")
            Return
        End If

        scheSetting.id = Request.QueryString("id")
        scheSetting.Orgcode = orgcode
        scheSetting.Depart_id = UcUserDialog.DepartId
        scheSetting.Schedule_id = ddlSchedule.SelectedValue
        scheSetting.Sche_type = "1"
        scheSetting.Id_card = UcUserDialog.Value.Split(",")(0)
        scheSetting.User_name = New FSC.Logic.Personnel().GetColumnValue("User_name", UcUserDialog.Value.Split(",")(0))
        scheSetting.Sche_date = UcDate.Text
        scheSetting.Schedule_hours = CommonFun.getInt(tbScheduleHours.Text.Trim())
        scheSetting.Pay_hours = CommonFun.getInt(tbPayHours.Text.Trim())
        scheSetting.Rest_hours = CommonFun.getInt(tbRestHours.Text.Trim())

        Try
            Dim dt As DataTable = New FSC.Logic.ScheduleSetting().getCheckData(orgcode, ddlSchedule.SelectedValue, UcDate.Text, Request.QueryString("id"))
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該日期的排班資料!")
                Return
            End If

            If scheSetting.update() Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            End If

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateFail)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

End Class
