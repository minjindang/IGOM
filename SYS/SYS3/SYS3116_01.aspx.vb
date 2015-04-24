Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3116_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLForm.Orgcode = LoginManager.OrgCode
    End Sub


    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim formId As String = UcDDLForm.SelectedValue

        Dim dt As DataTable = New FormSetting().GetDataByFormId(Orgcode, formId)

        gvList.DataSource = dt
        gvList.DataBind()
        DataList.Visible = True

    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("SYS3116_02.aspx")
    End Sub

    Protected Sub gvcbUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

        Response.Redirect("SYS3116_02.aspx?fid=" & formId)
    End Sub

    Protected Sub gvcbDelete_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

        Dim fs As New FormSetting()
        fs.Orgcode = Orgcode
        fs.Form_id = formId
        fs.delete()

        CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
        bind()
    End Sub
End Class
