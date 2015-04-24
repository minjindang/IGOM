Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT_MAT3_MAT3203_01
    Inherits BaseWebForm

    Dim dao As New MAT3203

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
       
        Dim msg As String = String.Empty
        Try
            If String.IsNullOrEmpty(ucInvEnd_date.Text) Then
                msg &= "請輸入完成盤點日期\n"
            End If

            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, msg)
            Else
                msg = dao.Done(LoginManager.OrgCode, ucInvEnd_date.Text, LoginManager.UserId)
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, msg)
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

End Class
