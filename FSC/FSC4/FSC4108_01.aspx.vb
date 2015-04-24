Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4108_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        showDLL()
        If Not String.IsNullOrEmpty(Request.QueryString("qk")) Or _
            Not String.IsNullOrEmpty(Request.QueryString("ql")) Then
            ddlLeaveKind.SelectedValue = Request.QueryString("qk")
            ddlLeaveType.SelectedValue = Request.QueryString("ql")
            bind()
        End If
    End Sub

    Public Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable
        Try
            dt = New SYS.Logic.LeaveType().GetLeaveType(Orgcode)
            ddlLeaveType.DataTextField = "Leave_name"
            ddlLeaveType.DataValueField = "Leave_type"
            ddlLeaveType.DataSource = dt
            ddlLeaveType.DataBind()
            ddlLeaveType.Items.Insert(0, New ListItem("請選擇", ""))

            Dim lk As New SYS.Logic.LeaveKind()

            dt = lk.GetData(Orgcode, "")
            ddlLeaveKind.DataTextField = "Kind_name"
            ddlLeaveKind.DataValueField = "Leave_kind"
            ddlLeaveKind.DataSource = dt
            ddlLeaveKind.DataBind()

            '職務類別
            Dim c As New SYS.Logic.CODE
            dt = c.GetData("023", "022")
            ddlMEMCOD.DataTextField = "CODE_DESC1"
            ddlMEMCOD.DataValueField = "CODE_NO"
            ddlMEMCOD.DataSource = dt
            ddlMEMCOD.DataBind()
            ddlMEMCOD.Items.Insert(0, New ListItem("請選擇", ""))

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Try
            Dim dt As DataTable = New LeaveSetting().GetDataByLeaveKind(Orgcode, ddlLeaveKind.SelectedValue, ddlLeaveType.SelectedValue, ddlMEMCOD.SelectedValue)
            dt.Columns.Add("Leave_type_name", GetType(String))
            dt.Columns.Add("Memcod_name", GetType(String))
            dt.Columns.Add("Limit_date_format", GetType(String))
            For Each dr As DataRow In dt.Rows
                dr("Leave_type_name") = New SYS.Logic.LeaveType().GetLeaveName(dr("Leave_type").ToString())
                dr("Memcod_name") = New SYS.Logic.CODE().GetDataDESC("023", "022", dr("Memcod").ToString())
                If Not String.IsNullOrEmpty(dr("Limit_date").ToString()) Then
                    dr("Limit_date_format") = Left(dr("Limit_date").ToString(), 2) & "/" & Right(dr("Limit_date").ToString(), 2)
                End If
            Next

            gvList.DataSource = dt
            gvList.DataBind()
            DataList.Visible = True

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC4108_02.aspx")
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
        Dim leave_kind As String = CType(gvr.FindControl("lbLeave_kind"), Label).Text
        Dim leave_type As String = CType(gvr.FindControl("lbLeave_type"), Label).Text
        Dim memcod As String = CType(gvr.FindControl("lbMemcod"), Label).Text

        Response.Redirect("FSC4108_02.aspx?qk=" & ddlLeaveKind.SelectedValue & "&ql=" & ddlLeaveType.SelectedValue & "&orgcode=" & orgcode & "&leave_kind=" & leave_kind & "&leave_type=" & leave_type & "&memcod=" & memcod & "&action=update")
    End Sub

    Protected Sub cbCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
        Dim leave_kind As String = CType(gvr.FindControl("lbLeave_kind"), Label).Text
        Dim leave_type As String = CType(gvr.FindControl("lbLeave_type"), Label).Text
        Dim memcod As String = CType(gvr.FindControl("lbMemcod"), Label).Text

        Response.Redirect("FSC4108_02.aspx?qk=" & ddlLeaveKind.SelectedValue & "&ql=" & ddlLeaveType.SelectedValue & "&orgcode=" & orgcode & "&leave_kind=" & leave_kind & "&leave_type=" & leave_type & "&memcod=" & memcod & "&action=copy")
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim mid As String = CType(gvr.FindControl("lbid"), Label).Text
        Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
        Dim depart_id As String = CType(gvr.FindControl("lbDepart_id"), Label).Text
        Dim leave_kind As String = CType(gvr.FindControl("lbLeave_kind"), Label).Text
        Dim leave_type As String = CType(gvr.FindControl("lbLeave_type"), Label).Text

        Try
            Using trans As New TransactionScope()
                Dim ls As New LeaveSetting()

                Dim dt As DataTable = New LeaveSettingDetail().GetDataByMasterId(mid)
                For Each dr As DataRow In dt.Rows
                    Dim lsd As New LeaveSettingDetail()
                    Dim S As String = dr("id").ToString()
                    lsd.DeleteData(dr("id").ToString())
                Next

                ls.Orgcode = orgcode
                ls.Depart_id = depart_id
                ls.Leave_kind = leave_kind
                ls.Leave_type = leave_type
                ls.ID = Integer.Parse(mid)

                ls.delete()

                trans.Complete()
            End Using
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            bind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub gvList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvList.PageIndexChanging
        gvList.PageIndex = e.NewPageIndex
        bind()
    End Sub
End Class
