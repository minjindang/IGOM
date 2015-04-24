Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports CommonLib

Partial Class FSC0101_06
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = Request.QueryString("org")
        Dim flowId As String = Request.QueryString("fId")
        Dim roleId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim endDate As String = ""
        Dim unitCode As String = ""
        Dim cdm As New CarDispatchMain()
        Dim psn As New FSC.Logic.Personnel()
        Dim flow As New SYS.Logic.Flow()
        flow.GetObject(orgcode, flowId)
        UcComment.FormId = flow.FormId
        Dim dt As DataTable = cdm.GetDataByFlowId(orgcode, flowId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso flow IsNot Nothing Then
            Dim r As DataRow = dt.Rows(0)
            lbApplyName.Text = flow.ApplyName
            lbCardName.Text = r("Car_name").ToString()
            lbDatetime.Text = DateTimeInfo.ToDisplay(r("Start_date").ToString(), r("Start_time").ToString()) & "~" & DateTimeInfo.ToDisplay(r("End_date").ToString(), r("End_time").ToString())
            lbReasonDesc.Text = r("Reason_desc").ToString()
            lbDesc.Text = "出發時間" & DateTimeInfo.ConvertToDisplay(r("Departure_date").ToString()) & " " & r("Departure_time").ToString() & ";上車地點：" & r("Location").ToString()
            lbUserId.Text = psn.GetColumnValue("User_name", r("User_id").ToString())
            lbPassengerCnt.Text = r("Passenger_cnt").ToString()
            lbDestinationDesc.Text = r("Destination_desc").ToString()
            If "001" = r("Use_type").ToString() Then
                rbxUseType.SelectedValue = "Y"
            Else
                rbxUseType.SelectedValue = "N"
            End If

            endDate = r("End_date").ToString()
            unitCode = r("Unit_code").ToString()
        End If

        If roleId.Contains("CarAdmin") Then
            tbEdit.Visible = True
            cbConfirm.Visible = True
            BindConfirmArea(endDate, unitCode)
        End If

        UcFlowDetail.Orgcode = orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub BindConfirmArea(endDate As String, unitCode As String)
        Dim bll As New FSC.Logic.FSC0101()

        ddlCarId.DataSource = bll.GetExistsCars(endDate, unitCode)
        ddlCarId.DataBind()

        ddlDriverUserid.DataSource = bll.GetDrivers()
        ddlDriverUserid.DataTextField = "user_name"
        ddlDriverUserid.DataValueField = "id_card"
        ddlDriverUserid.DataBind()

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = Request.QueryString("org")
        Dim flowId As String = Request.QueryString("fId")
        Dim bll As New FSC.Logic.FSC0101()
        Dim err As New StringBuilder()

        Try
            bll.ConfirmCarData(orgcode, flowId, rbxCaseStatus.SelectedValue, UcComment.Text, rbxIsReturn.SelectedValue, ddlCarId.SelectedValue, ddlDriverUserid.SelectedValue)

        Catch fex As FlowException
            err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("確認表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
        End Try

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            SendNotice.sendAll(orgcode, flowId)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "確認成功!", "FSC0101_02.aspx")
        End If
    End Sub
End Class
