Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3114_01
    Inherits BaseWebForm
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        ddlphrases_kind_Bind()
        ddlphrases_type_Bind()
    End Sub

    Protected Sub ddlphrases_kind_Bind()
        Dim c As CODE = New CODE()
        ddlphrases_kind.DataSource = c.GetData("024", "**")
        ddlphrases_kind.DataBind()
        ddlphrases_kind.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlphrases_type_Bind()
        Dim c As CODE = New CODE()
        ddlphrases_type.DataSource = c.GetData("024", ddlphrases_kind.SelectedValue)
        ddlphrases_type.DataBind()
        ddlphrases_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlphrases_kind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlphrases_kind.SelectedIndexChanged
        ddlphrases_type_Bind()
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Try
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim phrases_kind As String = ddlphrases_kind.SelectedValue()
            Dim phrases_type As String = ddlphrases_type.SelectedValue()
            Dim phrases As String = tbphrases.Text
            Dim visable_flag As String = ddlvisable_flag.SelectedValue

            Dim cp As CommonPhrases = New CommonPhrases

            Dim dt As DataTable = cp.getData(Orgcode, phrases_kind, phrases_type, phrases, visable_flag)

            gvList.DataSource = dt
            gvList.DataBind()

            dataList.Visible = True

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("SYS3114_02.aspx")
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lblID"), Label).Text
        Response.Redirect("SYS3114_02.aspx?id=" & id)
    End Sub


    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lblID"), Label).Text
        Try
            Dim cp As CommonPhrases = New CommonPhrases

            cp.id = id
            cp.delete()
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)

            bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
