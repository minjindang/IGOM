Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports CommonLib
Imports System.Collections.Generic

' 2014/7/19 Eliot Chen
' 欄位錯誤修正

Partial Class FSC0101_13
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim nextStep As String = Request.QueryString("step")
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()
        Dim dt As DataTable = bll.GetOTHBroadcastMainData(Orgcode, flowId)

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

        cbxBroadcast_floors.DataSource = code.GetData("022", "001")
        cbxBroadcast_floors.DataBind()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim r As DataRow = dt.Rows(0)
            lbBroadcast_date1.Text = DateTimeInfo.ToDisplay(r("Broadcast_date1").ToString())
            lbBroadcast_time1.Text = DateTimeInfo.ToDisplayTime(r("Broadcast_time1").ToString())
            lbBroadcast_date2.Text = DateTimeInfo.ToDisplay(r("Broadcast_date2").ToString())
            lbBroadcast_time2.Text = DateTimeInfo.ToDisplayTime(r("Broadcast_time2").ToString())

            ' 欄位錯誤修正
            ' 2014/7/19 Eliot Chen
            Dim floors As String = r("Broadcast_floors").ToString()
            For Each floor In floors.Split(",")
                For Each item As ListItem In cbxBroadcast_floors.Items
                    If floor = item.Value Then
                        item.Selected = True
                    End If
                Next
            Next
            lbBroadcast_content.Text = r("Broadcast_content").ToString()
        End If


        Dim fn As New SYS.Logic.FlowNext()
        Dim ndt As DataTable = fn.GetData(Orgcode, flowId, LoginManager.OrgCode, LoginManager.Depart_id, LoginManager.UserId, nextStep)
        If ndt IsNot Nothing AndAlso ndt.Rows.Count > 0 Then
            cbConfirm.Visible = True
            cbxBroadcast_floors.Enabled = True
        Else
            cbConfirm.Visible = False
            cbxBroadcast_floors.Enabled = False
        End If
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl"))
        End If
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()
        Dim err As New StringBuilder()

        Try
            bll.ConfirmOTHBroadcastData(Orgcode, flowId)

        Catch fex As FlowException
            err.Append("表單(" & flowId & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("確認表單(" & flowId & ")時，系統發生錯誤，請洽人事管理人員。\n")
        End Try

        If err.Length > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
        Else
            SendNotice.sendAll(Orgcode, flowId)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "確認成功!", "FSC0101_02.aspx")
        End If
    End Sub

End Class
