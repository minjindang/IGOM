Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC3111_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack() Then
            Return
        End If

        bind()
    End Sub

    Protected Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Try
            Dim dt As DataTable = New FSC.Logic.Schedule().GetData(orgcode)
            gvList.DataSource = dt
            gvList.DataBind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
        End Try
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        Response.Redirect("FSC3111_02.aspx?id=" & id)
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        Try
            Dim re As Boolean = New FSC.Logic.Schedule().delete(CommonFun.getInt(id))
            If re Then
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteFail)
            End If
            bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
        End Try
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC3111_02.aspx")
    End Sub
End Class
