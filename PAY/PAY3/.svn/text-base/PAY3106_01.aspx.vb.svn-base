Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3106_01
    Inherits BaseWebForm

    Dim dao As New PAY3106

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
         
        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/PAY/PAY3/PAY3106_03.aspx?Bank_id={0}", e.CommandArgument))
        ElseIf e.CommandName = "GoDelete" Then
            Dim msg As String = dao.Remove(e.CommandArgument)
            If String.IsNullOrEmpty(msg) Then
                Bind()
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If 

        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Master)
    End Sub

    Private Sub Bind()
        Dim dt As DataTable = dao.PBDAO.GetAll(txtBank_id.Text, txtBankAbbreviation_name.Text, txtBank_name.Text)
        div1.Visible = True
        'Not dt Is Nothing AndAlso dt.Rows.Count > 0
        If dt IsNot Nothing Then
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
        Bind()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3106_02.aspx")
    End Sub


End Class
