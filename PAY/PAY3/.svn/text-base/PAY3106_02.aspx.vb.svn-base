Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3106_02
    Inherits BaseWebForm

    Dim dao As New PAY3106

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
                msg = dao.Add(txtBank_id.Text, txtBankAbbreviation_name.Text, txtBank_name.Text)
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

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3106_01.aspx")
    End Sub

End Class
