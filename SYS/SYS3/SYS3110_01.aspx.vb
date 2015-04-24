Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class SYS3110_01
    Inherits BaseWebForm

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return
        showDDL()
        'bind()
    End Sub

    Public Sub showDDL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable
        Dim lt As New SYS.Logic.LeaveType
        Dim lg As New SYS.Logic.LeaveGroup

        dt = lg.GetCustomGroup(Orgcode)
        ddlleaveGroup.DataTextField = "Leave_group_name"
        ddlleaveGroup.DataValueField = "leave_group_id"
        ddlleaveGroup.DataSource = dt
        ddlleaveGroup.DataBind()

        dt = New DataTable
        dt = lt.GetLeaveType(Orgcode, ddlleaveGroup.SelectedValue)
        ddlLeaveType.DataTextField = "LeaveName"
        ddlLeaveType.DataValueField = "LeaveType"
        ddlLeaveType.DataSource = dt
        ddlLeaveType.DataBind()

    End Sub

    Protected Sub DropDownList_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLeaveType.DataBound
        Dim ddl As DropDownList = CType(sender, DropDownList)
        ddl.Items.Insert(0, New ListItem("--查詢全部--", ""))
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim leaveGroup As String = ddlleaveGroup.SelectedValue
        Dim leaveType As String = ddlleaveType.SelectedValue

        Dim dt As DataTable
        Dim cl As New SYS.Logic.CustomLeaveSetting

        dt = cl.GetData(Orgcode, leaveGroup, leaveType, role_id)
        gvList.DataSource = dt
        gvList.DataBind()
    End Sub

    Protected Sub doUpdate(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDel As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnDel.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim lbId As Label = CType(row.FindControl("lbID"), Label)
        Dim id As String = lbId.Text

        Response.Redirect("SYS3110_02.aspx?id=" + id)
    End Sub

    Protected Sub doDelete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDel As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnDel.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim lbId As Label = CType(row.FindControl("lbID"), Label)
        Dim id As Integer = CInt(lbId.Text)
        Dim cl As New SYS.Logic.CustomLeaveSetting
        Try
            cl.DeleteData(id)
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)

            showDDL()
            bind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub ddlleaveGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlleaveGroup.SelectedIndexChanged
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim lt As New SYS.Logic.LeaveType
        Dim dt As DataTable
        dt = lt.GetLeaveType(Orgcode, ddlleaveGroup.SelectedValue)
        ddlLeaveType.DataTextField = "LeaveName"
        ddlLeaveType.DataValueField = "LeaveType"
        ddlLeaveType.DataSource = dt
        ddlLeaveType.DataBind()
    End Sub
End Class
