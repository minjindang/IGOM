Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3110_02
    Inherits BaseWebForm

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return
        showDDL()
        bind()
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

        dt = New DataTable
        dt = New SYS.Logic.Role().GetData(Orgcode)
        Me.cblRoleName.DataTextField = "Role_name"
        Me.cblRoleName.DataValueField = "Role_id"
        Me.cblRoleName.DataSource = dt
        Me.cblRoleName.DataBind()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id As String = Request.QueryString("id")
        Dim leaveGroup As String = ddlleaveGroup.SelectedValue
        Dim LeaveType As String = ddlLeaveType.SelectedValue
        Dim cl As New SYS.Logic.CustomLeaveSetting
        Try
            Dim dt As DataTable = cl.GetData(Orgcode, leaveGroup, LeaveType)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                If id <> dt.Rows(0)("id").ToString() OrElse (id = dt.Rows(0)("id").ToString() And isCopy.Text = "Y") Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該自訂表單設定!")
                    Return
                End If
            End If

            cl.id = CInt(id)
            cl.Orgcode = Orgcode
            cl.Leave_group_id = leaveGroup
            cl.Leave_type = LeaveType
            cl.isApply = IIf(cbIsApply.Checked, "Y", "N")
            cl.isApllyDate = IIf(cbIsApllyDate.Checked, "Y", "N")
            cl.isApllyDateSE = IIf(cbIsApllyDateSE.Checked, "Y", "N")
            cl.isReason = IIf(cbIsReason.Checked, "Y", "N")
            cl.isAttach = IIf(cbIsAttach.Checked, "Y", "N")
            'cl.isDetail = IIf(cbIsDetail.Checked, "Y", "N")
            'cl.Explanation = tbExplanation.Text.Trim()
            cl.Mark = tbMark.Text.Trim()
            cl.isCustom1 = IIf(cbIsCustom1.Checked, "Y", "N")
            cl.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Using trans As New TransactionScope
                If id <> "" AndAlso isCopy.Text <> "Y" Then
                    cl.UpdateData()
                    saveRoleCustom(id)
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
                    showDDL()
                    bind()
                Else
                    cl.InsertData()
                    dt = cl.GetData(Orgcode, leaveGroup, LeaveType)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        saveRoleCustom(dt.Rows(0)("id").ToString())
                    End If
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "SYS3110_01.aspx")
                End If

                trans.Complete()
            End Using

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub saveRoleCustom(ByVal CusId As String)
        Dim rc As New RoleCustomLeave

        rc.DeleteDataByCusId(CInt(CusId))

        For i As Integer = 0 To cblRoleName.Items.Count - 1
            If cblRoleName.Items(i).Selected Then
                rc.Role_id = cblRoleName.Items(i).Value
                rc.Custom_leave_setting_id = CInt(CusId)
                rc.change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                rc.InsertData()
            End If
        Next
    End Sub

    Protected Sub bind()
        Dim id As String = Request.QueryString("id")
        If id <> "" Then
            Dim cl As New SYS.Logic.CustomLeaveSetting
            Dim dt As DataTable = cl.GetDataById(CInt(id))
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ddlleaveGroup.SelectedValue = dt.Rows(0)("Leave_group_id")
                ddlLeaveType.SelectedValue = dt.Rows(0)("Leave_type")
                cbIsApply.Checked = IIf(dt.Rows(0)("isApply").ToString() = "Y", True, False)
                cbIsApllyDate.Checked = IIf(dt.Rows(0)("isApllyDate").ToString() = "Y", True, False)
                cbIsApllyDateSE.Checked = IIf(dt.Rows(0)("isApllyDateSE").ToString() = "Y", True, False)
                cbIsReason.Checked = IIf(dt.Rows(0)("isReason").ToString() = "Y", True, False)
                cbIsAttach.Checked = IIf(dt.Rows(0)("isAttach").ToString() = "Y", True, False)
                'cbIsDetail.Checked = IIf(dt.Rows(0)("isDetail").ToString() = "Y", True, False)
                cbIsCustom1.Checked = IIf(dt.Rows(0)("isCustom1").ToString() = "Y", True, False)
                'tbExplanation.Text = dt.Rows(0)("Explanation").ToString()
                tbMark.Text = dt.Rows(0)("Mark").ToString()
            End If

            dt = New RoleCustomLeave().GetDataByCusId(CInt(id))
            For Each dr As DataRow In dt.Rows
                For i As Integer = 0 To cblRoleName.Items.Count - 1
                    If cblRoleName.Items(i).Value = dr("Role_id").ToString Then
                        cblRoleName.Items(i).Selected = True
                        Exit For
                    End If
                Next
            Next
        Else
            cbCopy.Enabled = False
        End If
    End Sub

    Protected Sub cbCopy_Click(sender As Object, e As EventArgs) Handles cbCopy.Click
        isCopy.Text = "Y"
        cbCopy.Enabled = False
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
