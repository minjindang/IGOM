Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC3114_01
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDate.Text = DateTimeInfo.GetRocDate(Now)
        UcDate.Enabled = False
    End Sub

    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If String.IsNullOrEmpty(tbAD_id.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入AD帳號!")
            Return
        End If
        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入刷卡日期!")
            Return
        End If

        Dim type As String = IIf(rbType1.Checked, "A", "D")

        Dim Id_card As String = String.Empty
        Dim psn As DataTable = New Personnel().GetDataByADid(tbAD_id.Text.Trim)
        If psn Is Nothing OrElse psn.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "無此人員!")
            Return
        Else
            Id_card = psn.Rows(0)("Id_card").ToString()
        End If


        Try
            Dim dt As DataTable = New DataTable()
            Dim bll As CPAPHYYMM = New CPAPHYYMM((Now.Year - 1911).ToString() + Now.Month.ToString().PadLeft(2, "0"))

            dt = bll.GetData(Id_card, UcDate.Text, type)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有刷卡紀錄!")
                Return
            End If
            'If dt.Rows(0).Item("PBDTYPE") = "2" Then
            '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "當天為假日!!")
            '    Return
            'End If
            Dim time As String = Now.Hour.ToString().PadLeft(2, "0") + Now.Minute.ToString().PadLeft(2, "0")

            Using trans As New TransactionScope
                bll.InsertCPAPHYYMM("L1", Id_card, UcDate.Text, time, type, Nothing)
                trans.Complete()

                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "線上刷卡成功(刷卡時間：" + DateTimeInfo.ToDisplayTime(time) + ")!")
            End Using
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class