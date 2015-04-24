Imports System.Data
Imports System.Transactions
Imports SYS.Logic

Partial Class SYS3119_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        gvList.DataSource = New SYS.Logic.Org().GetDataByQuery(tbOrgcode.Text, tbOrgcodeName.Text)
        gvList.DataBind()
        tbQ.Visible = True
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("SYS3119_02.aspx")
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = gvr.Cells(0).Text
        Response.Redirect("SYS3119_02.aspx?org=" & orgcode)
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Orgcode As String = gvr.Cells(0).Text

        Try
            Using trans As New TransactionScope()
                Dim org As New SYS.Logic.Org
                org.deleteByOrgcode(Orgcode)

                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
                bind()
            End Using
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
