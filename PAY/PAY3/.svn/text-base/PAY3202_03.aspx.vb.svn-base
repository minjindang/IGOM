Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3202_03
    Inherits BaseWebForm

    Dim dao As New PAY3202

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtPayer_id.Text = Page.Request.QueryString("Payer_id")
            BindOne()
        End If
    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Try
            Dim msg As String = String.Empty

            If String.IsNullOrEmpty(txtPayer_id.Text) Then
                msg += "請輸入付款人編號\n"
            Else
                If Not CommonFun.IsNum(txtPayer_id.Text) Then
                    msg += "付款人編號，請輸入數字\n"
                End If
            End If

            If String.IsNullOrEmpty(Me.txtPayer_name.Text) Then
                msg += "請輸入付款人名稱\n"
            End If

            If String.IsNullOrEmpty(msg) Then
                msg = dao.Modify(txtPayer_id.Text, txtPayer_name.Text)

                If String.IsNullOrEmpty(msg) Then
                    Page.Response.Redirect("~/PAY/PAY3/PAY3202_01.aspx?types=update")
                Else
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                End If
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub

    Private Sub BindOne()
        Dim dr As DataRow = dao.EPMDAO.GetOne(LoginManager.OrgCode, txtPayer_id.Text)
        If Not dr Is Nothing Then
            txtPayer_name.Text = CommonFun.SetDataRow(dr, "Payer_name")
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "找不到付款人資料")
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindOne()
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3202_01.aspx")
    End Sub

End Class
