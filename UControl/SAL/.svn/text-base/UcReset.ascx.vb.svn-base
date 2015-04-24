
Partial Class UControl_SAL_UcReset
    Inherits System.Web.UI.UserControl
    Public Property btnText() As String
        Get
            Return Me.uc_btn_reset.Text
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                Me.uc_btn_reset.Text = "清空重填"
            Else
                Me.uc_btn_reset.Text = value
            End If

        End Set
    End Property
    Protected Sub uc_btn_reset_Click(sender As Object, e As EventArgs) Handles uc_btn_reset.Click
        CommonFun.cleanControl(DirectCast(sender, Button).parent.Page)
    End Sub
End Class
