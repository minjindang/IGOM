Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC3201_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Dim checkDay As String = DateTimeInfo.GetRocDate(Now.AddYears(-3))

        If String.IsNullOrEmpty(UcSDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "執行起日不可空白!")
            Return
        End If
        If String.IsNullOrEmpty(UcEDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "執行迄日不可空白!")
            Return
        End If
        If UcSDate.Text > UcEDate.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "執行起日不可大於執行迄日!")
            Return
        End If
        If UcSDate.Text > checkDay OrElse UcEDate.Text > checkDay Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可結轉3年以內的資料!")
            Return
        End If

        Try
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            Dim id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            Dim fsc3201 As New FSC3201

            Using trans As New TransactionScope
                fsc3201.DoDeleteOldData(Orgcode, Depart_id, id_card, UcSDate.Text, UcEDate.Text)

                trans.Complete()
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "結轉成功!")
            End Using
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class