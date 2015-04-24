Imports FSC.Logic
Imports System.Transactions

Partial Class FSC3101_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        bind()
    End Sub

    Protected Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        Try
            gv.DataSource = New FSC3101().GetDeputyDetByQuery(orgcode, idcard)
            gv.DataBind()

        Catch ex As Exception
            AppException.ShowError_ByPage(ex)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub


    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("gv_lbno"), Label).Text = e.Row.DataItemIndex + 1

            CType(e.Row.FindControl("gv_lbPosid"), Label).Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            CType(e.Row.FindControl("gv_lbPosname"), Label).Text = New SYS.Logic.CODE().GetFSCTitleName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no))

            If CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text.Trim = "1" Then
                CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text = "●"
            Else
                CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text = ""
            End If
        End If
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC3101_02.aspx")
    End Sub

    Protected Sub gv_cbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As Integer = gv.DataKeys(gvr.RowIndex).Value
        Response.Redirect("FSC3101_02.aspx?id=" & id)
    End Sub

    Protected Sub gv_cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("gvlbid"), Label).Text
        Dim Deputy_idcard As String = CType(gvr.FindControl("gvlbDeputy_idcard"), Label).Text
        Try
            Dim rev As Boolean = False
            Using trans As New TransactionScope

                Dim fsc1502 As New FSC3101()
                fsc1502.deleteData(CommonFun.getInt(ID))

                'Dim fsc3409 As New FSC3409()
                'fsc3409.updateDeputyactive(Orgcode, Depart_id, Id_card, Deputy_idcard, "N", "")

                rev = True
                trans.Complete()
            End Using


            If rev Then
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteFail)
            End If
            bind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
