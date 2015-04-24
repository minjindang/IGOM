Imports System.Data
Imports System.Transactions
Imports SYS.Logic

Partial Class SYS3102_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Dep_Bind()
    End Sub

#Region "下拉式選單"
    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub
#End Region

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        gvList.DataSource = New EMP.Logic.Org().getDataByDid(Orgcode, UcDDLDepart.SelectedValue)
        gvList.DataBind()
        tbQ.Visible = True
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("SYS3102_02.aspx")
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim depart_id As String = gvr.Cells(3).Text
        Response.Redirect("SYS3102_02.aspx?d=" & depart_id)
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = gvr.Cells(3).Text

        Try
            Using trans As New TransactionScope()
                Dim eo As New EMP.Logic.Org
                Dim a As Boolean = eo.deleteData(Orgcode, depart_id)

                Dim fo As New FSC.Logic.Org
                Dim b As Boolean = fo.deleteData(Orgcode, depart_id)

                trans.Complete()
            End Using
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
