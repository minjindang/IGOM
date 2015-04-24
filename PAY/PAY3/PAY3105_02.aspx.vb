Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3105_02
    Inherits BaseWebForm

    Dim dao As New PAY3105

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Try
            Dim msg As String = String.Empty

            If String.IsNullOrEmpty(Me.ucBank.Bank_ID) OrElse String.IsNullOrEmpty(Me.ucBank.Bank_Name) Then
                msg += "請輸入銀行代碼/名稱\n"
            End If


            If String.IsNullOrEmpty(Me.txtBankAccount_nos.Text) Then
                msg += "請輸入受款人帳號\n"
            End If

            If txtBeneficiary_name.Text.Length > 70 Then
                msg += "受款人姓名長度不得大於70個中文字\n"
            End If

            If String.IsNullOrEmpty(msg) Then
                If rblEmp.SelectedValue = "Y" Then
                    msg = dao.Add(UcDDLMember.SelectedValue, UcDDLMember.SelectedItem.Text.Split("/")(1), ucBank.Bank_ID, txtEmail.Text, txtBankAccount_nos.Text)
                Else
                    msg = dao.Add("", txtBeneficiary_name.Text, ucBank.Bank_ID, txtEmail.Text, txtBankAccount_nos.Text)
                End If
                If String.IsNullOrEmpty(msg) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "PAY3105_01.aspx")
                    'Page.Response.Redirect("~/PAY/PAY3/PAY3105_01.aspx")
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

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub rblEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblEmp.SelectedIndexChanged
        trEmpY.Visible = rblEmp.SelectedValue = "Y"
        trEmpN.Visible = rblEmp.SelectedValue = "N"
    End Sub

    Protected Sub BackBtn_Click1(sender As Object, e As EventArgs)
        Response.Redirect("PAY3105_01.aspx")
    End Sub
End Class
