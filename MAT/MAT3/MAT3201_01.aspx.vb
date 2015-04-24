Imports System.Data
Imports FSCPLM.Logic


Partial Class MAT_MAT3_MAT3201_01
    Inherits BaseWebForm

    Dim dao As New MAT3201

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        If dao.IsInventoring(LoginManager.OrgCode) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "已有盤點作業執行中")
        Else
            Dim msg As String = String.Empty
            If String.IsNullOrEmpty(ucInvStart_date.Text) Then
                msg &= "請輸入盤點開始日期\n"
            End If
            If String.IsNullOrEmpty(ucExpected_date.Text) Then
                msg &= "請輸入預定完成盤點日期\n"
            End If
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, msg)
            Else
                Try
                    dao.Insert(LoginManager.OrgCode, ucInvStart_date.Text, ucExpected_date.Text, LoginManager.UserId)
                    CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "註記完成")
                Catch ex As Exception
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
                End Try
            End If
        End If

    End Sub

    

End Class
