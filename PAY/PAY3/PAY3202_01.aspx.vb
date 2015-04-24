Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3202_01
    Inherits BaseWebForm

    Dim dao As New PAY3202

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request("types") = "insert" Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "新增成功!!!")
            End If

            If Request("types") = "update" Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "修改成功!!!")
            End If
        End If
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/PAY/PAY3/PAY3202_03.aspx?Payer_id={0}", e.CommandArgument))
        ElseIf e.CommandName = "GoDelete" Then
            dao.EPMDAO.Remove(LoginManager.OrgCode, e.CommandArgument)
            Bind()
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Master)
    End Sub 

    Private Sub Bind()
        Dim dt As DataTable = dao.EPMDAO.GetAll(txtPayer_id.Text, txtPayer_name.Text)
        div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridViewA.DataSource = dt
            Me.GridViewA.DataBind()
            ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose()
        End If
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        If Not CommonFun.IsNum(txtPayer_id.Text) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "付款人編號請輸入數字!!!")
        End If
        Bind()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3202_02.aspx")
    End Sub
End Class
