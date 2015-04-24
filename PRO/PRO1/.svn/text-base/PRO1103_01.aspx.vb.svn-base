Imports FSCPLM.Logic
Imports System.Data.SqlClient
Imports System.Transactions


Partial Class PRO_PRO1_PRO1103_01
    Inherits BaseWebForm

    Dim dao As New PRO1103

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.lblRegister_date.Text = CommonFun.getYYYMMDD
        Me.lblUnit_code.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
        Me.lblUser_id.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Try
            Dim msg As String = CheckRequire()

            If String.IsNullOrEmpty(msg) Then
                msg = dao.Done(txtOfficialNumber_id.Text, txtSoftware_id.Text, ucSoftware_type.SelectedValue, _
                    txtSoftware_name.Text, txtVersion.Text, txtKeyNumber_nos.Text, ucSoftwareKind_type.SelectedValue, txtNetPLimit_cnt.Text, _
                    txtSofeware_cnt.Text, ucObtain_type.SelectedValue, txtObtainOt_desc.Text, txtSoftwareUnit_name.Text, ucStorageMedia_type.SelectedValue, _
                    txtStorageMediaOt_desc.Text, IIf(String.IsNullOrEmpty(txtStorageMedia_cnt.Text), "0", txtStorageMedia_cnt.Text), txtRelatedPapers_name.Text, IIf(String.IsNullOrEmpty(txtLifeTime.Text), "0", txtLifeTime.Text), IIf(String.IsNullOrEmpty(txtFee_amt.Text), "0", txtFee_amt.Text), _
                    IIf(String.IsNullOrEmpty(txtMRent_amt.Text), "0", txtMRent_amt.Text), ucStart_date.Text, LoginManager.Depart_id, LoginManager.UserId, lblRegister_date.Text, _
                    txtMemo.Text, LoginManager.UserId, CommonFun.getYYYMMDD(lblRegister_date.Text))
                If String.IsNullOrEmpty(msg) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "送出申請")
                Else
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                End If
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, fex.Message)
        End Try
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Function CheckRequire() As String
        Dim msg As String = String.Empty
        Dim flag As Integer = 0
        Dim flagempty As Integer = 0


        If Not CommonFun.IsNum(txtOfficialNumber_id.Text) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "「公文文號」請輸入數字。")
        End If
        If Not CommonFun.IsNum(txtSoftware_id.Text) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "「軟體編號」請輸入數字。")
        End If
        If Not CommonFun.IsNum(txtSofeware_cnt.Text) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "「數量」請輸入數字。")
        End If
        If Not CommonFun.IsNum(txtFee_amt.Text) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "「費用」請輸入數字。")
            flagempty = 1
        End If
        If Not CommonFun.IsNum(txtMRent_amt.Text) And flagempty = 0 Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "「月租金」請輸入數字。")
        End If
        If String.IsNullOrEmpty(txtOfficialNumber_id.Text) Then
            msg &= "請輸入「公文文號」\n"
        End If
        If String.IsNullOrEmpty(txtSofeware_cnt.Text) Then
            msg &= "請輸入「數量」\n"
        End If
        If String.IsNullOrEmpty(txtSoftware_id.Text) Then
            msg &= "請輸入「軟體編號」\n"
        End If
        If String.IsNullOrEmpty(ucSoftware_type.SelectedValue) Then
            msg &= "請選擇「軟體別」\n"
        End If
        If String.IsNullOrEmpty(ucSoftwareKind_type.SelectedValue) Then
            msg &= "請選擇「使用版別」\n"
        End If
        If String.IsNullOrEmpty(ucObtain_type.SelectedValue) Then
            msg &= "請選擇「取得方式」\n"
        End If
        If String.IsNullOrEmpty(txtSoftwareUnit_name.Text) Then
            msg &= "請輸入「軟體廠商」\n"
        End If
        If String.IsNullOrEmpty(txtFee_amt.Text) AndAlso String.IsNullOrEmpty(txtMRent_amt.Text) Then
            msg &= "請輸入「費用或月租金」\n"
        End If
        If String.IsNullOrEmpty(ucStart_date.Text) Then
            msg &= "請輸入「啟用日期」\n"
        End If
        Return msg
    End Function

End Class
