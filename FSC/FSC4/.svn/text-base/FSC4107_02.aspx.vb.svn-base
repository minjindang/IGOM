Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4107_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        showDLL()

    End Sub

    Public Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable
        Dim KindList() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Try
            Dim lk As New SYS.Logic.LeaveKind()

            dt = lk.GetData(Orgcode, Depart_id)

            For Each kind As String In KindList
                Dim ins As Boolean = True
                For Each dr As DataRow In dt.Rows
                    If kind.Equals(dr("Leave_kind").ToString()) Then
                        ins = False
                    End If
                Next
                If ins Then
                    ddlPDKIND.Items.Add(New ListItem(kind, kind))
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        If String.IsNullOrEmpty(tbKindName.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「組別名稱」欄位為必填。")
            Return
        End If
        Try
            Dim lk As New SYS.Logic.LeaveKind()
            Dim cpapc03 As CPAPC03M = New CPAPC03M
            lk.Orgcode = Orgcode
            lk.Depart_id = Depart_id
            lk.Leave_kind = ddlPDKIND.SelectedValue()
            lk.Kind_name = tbKindName.Text.Trim()

            Using trans As New TransactionScope
                lk.Insert()
                cpapc03.insertNewData(lk.Leave_kind)

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "FSC4107_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
