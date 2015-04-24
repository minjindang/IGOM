Imports FSC.Logic
Imports System.Data
Imports System.Transactions

Partial Class FSC3101_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        lbPosid.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        lbPosname.Text = " (" & New SYS.Logic.CODE().GetFSCTitleName(lbPosid.Text) & ")"

        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            Me.lbAddModify.Text = "修改"
            Bind()
        Else
            Me.lbAddModify.Text = "新增"
        End If

    End Sub

    Protected Sub Bind()
        Dim dt As DataTable = New DeputyDet().GetDeputyDetBySerial_nos(Request.QueryString("id"))

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            Return
        Else
            For Each dr As DataRow In dt.Rows
                UcUserDialog.Value = dr("id_card").ToString()
                UcUserDialog.DepartId = dr("Deputy_departid").ToString()
                UcUserDialog.Text = dr("user_name").ToString()

                If dr("Deputy_flag").ToString().Trim = "1" Then
                    cbxDeputy_flag.Checked = True
                Else
                    cbxDeputy_flag.Checked = False
                End If
                txtDeputSeq2.Text = dr("Deputy_seq").ToString().Trim
            Next
        End If

    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC3101_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Title_no As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim Change_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        If String.IsNullOrEmpty(UcUserDialog.Value) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇職務代理人!")
            Return
        End If

        Dim dd As New DeputyDet
        Dim isDouble As Boolean = False

        If isDouble Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "該職務代理人已存在，請重新設定!")
            Return
        End If

        Dim deputy_idcard As String = UcUserDialog.Value
        Dim deputy_orgcode As String = UcUserDialog.Orgcode
        Dim deputy_departid As String = UcUserDialog.DepartId
        Dim deputy_titleno As String = ""
        Dim mdt As DataTable = New Personnel().GetDataByIdCard(deputy_idcard)

        Dim Deputy_flag As String
        If cbxDeputy_flag.Checked Then
            Deputy_flag = "1"
        Else
            Deputy_flag = "0"
        End If
        Dim Deputy_seq As Integer

        Try
            Deputy_seq = Integer.Parse(Me.txtDeputSeq2.Text)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "【順序】請輸入數字")
            Return
        End Try


        If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
            deputy_titleno = mdt.Rows(0)("Title_no").ToString()
        End If

        If String.IsNullOrEmpty(Request.QueryString("id")) Then
            '新增

            If Not dd.InsertDeputyDet(Orgcode, Depart_id, Id_card, deputy_orgcode, deputy_departid, deputy_titleno, deputy_idcard, Change_id, Deputy_flag, Deputy_seq) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定失敗")
                Return
            End If

        Else
            '更新

            If Not dd.UpdateDeputyDet(Orgcode, Depart_id, Id_card, deputy_orgcode, deputy_departid, deputy_titleno, deputy_idcard, Change_id, Request.QueryString("id"), Deputy_flag, Deputy_seq) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定失敗")
                Return
            End If
        End If

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "FSC3101_01.aspx")
    End Sub

    Protected Sub cbxDeputy_flag_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeputy_flag.CheckedChanged
        If cbxDeputy_flag.Checked = True Then
            txtDeputSeq2.Text = "1"
            txtDeputSeq2.Enabled = False
        Else
            txtDeputSeq2.Text = ""
            txtDeputSeq2.Enabled = True
        End If
    End Sub
End Class
