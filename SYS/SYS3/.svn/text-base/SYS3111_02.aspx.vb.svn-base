Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic


Partial Class SYS3111_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return

        Role_bind()
        Personnel_bind()
    End Sub

    Protected Sub Role_bind()
        cblRole.DataTextField = "Role_name"
        cblRole.DataValueField = "Role_id"
        cblRole.DataSource = New SYS.Logic.Role().GetData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
        cblRole.DataBind()
    End Sub

    Protected Sub Personnel_bind()
        Dim psn As Personnel = New Personnel().GetObject(Request.QueryString("idcard"))
        lbId_card.Text = psn.IdCard
        lbName.Text = psn.UserName

        For Each role_id As String In psn.RoleId.Split(",")
            For Each i As ListItem In cblRole.Items
                If i.Value = role_id Then
                    i.Selected = True
                End If
            Next
        Next
    End Sub

    Protected Sub btnConfrim_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click
        Dim role As String = String.Empty

        For Each i As ListItem In cblRole.Items
            If i.Selected Then
                If Not String.IsNullOrEmpty(role) Then role &= ","
                role &= i.Value
            End If
        Next

        Try
            Dim P As Personnel = New Personnel()
            P.UpdateRole(Request.QueryString("idcard"), role)

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
