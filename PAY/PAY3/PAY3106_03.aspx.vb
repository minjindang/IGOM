Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3106_03
    Inherits BaseWebForm

    Dim dao As New PAY3106

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtBank_id.Text = Page.Request.QueryString("Bank_id")
            BindOne()
        End If
    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Try
            Dim msg As String = String.Empty

            If String.IsNullOrEmpty(txtBank_id.Text) Then
                msg += "請輸入銀行代碼\n"
            End If

            If String.IsNullOrEmpty(Me.txtBank_name.Text) Then
                msg += "請輸入銀行名稱\n"
            End If


            If String.IsNullOrEmpty(Me.txtBankAbbreviation_name.Text) Then
                msg += "請輸入銀行簡稱\n"
            End If

            If String.IsNullOrEmpty(msg) Then
                msg = dao.Modify(txtBank_id.Text, txtBankAbbreviation_name.Text, txtBank_name.Text)
                If String.IsNullOrEmpty(msg) Then
                    Page.Response.Redirect("~/PAY/PAY3/PAY3106_01.aspx")
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
        Dim dr As DataRow = dao.PBDAO.GetOne(txtBank_id.Text, LoginManager.OrgCode)
        If Not dr Is Nothing Then
            txtBank_name.Text = CommonFun.SetDataRow(dr, "Bank_name")
            txtBankAbbreviation_name.Text = CommonFun.SetDataRow(dr, "BankAbbreviation_name")
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "找不到銀行資料")
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindOne()
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3106_01.aspx")
    End Sub

End Class
