Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0101_18
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        Bind()
    End Sub

    Protected Sub Bind()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then

            UcFlowDetail.Orgcode = org
            UcFlowDetail.FlowId = fid

            Dim fca As ForgotClockApply = New ForgotClockApply
            Dim list As List(Of FSC.Logic.ForgotClockApply) = fca.GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            Dim code As New FSCPLM.Logic.SACode()
            For Each f As FSC.Logic.ForgotClockApply In list
                lbApply_name.Text = f.Apply_name
                lbForgot_date.Text = f.Forgot_date
                lbCard_type.Text = code.GetCodeDesc("023", "008", f.Card_type)
                lbReason.Text = f.Reason
            Next
        End If
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Dim url As String = ViewState("BackUrl")
        Response.Redirect(url)
    End Sub
End Class
