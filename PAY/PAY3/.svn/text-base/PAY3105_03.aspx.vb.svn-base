Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3105_03
    Inherits BaseWebForm

    Dim dao As New PAY3105

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            txtBeneficiary_id.Text = Page.Request.QueryString("Beneficiary_id")
            BindOne()
        End If
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
                Try
                    If rblEmp.SelectedValue = "Y" Then
                        dao.PBYDAO.Modify(txtBeneficiary_id.Text, LoginManager.OrgCode, UcDDLMember.SelectedValue, UcDDLMember.SelectedItem.Text, _
                   ucBank.Bank_ID, txtBankAccount_nos.Text, txtEmail.Text, LoginManager.UserId, Now, "")
                    Else
                        dao.PBYDAO.Modify(txtBeneficiary_id.Text, LoginManager.OrgCode, "", txtBeneficiary_name.Text, _
                   ucBank.Bank_ID, txtBankAccount_nos.Text, txtEmail.Text, LoginManager.UserId, Now, "")
                    End If

                Catch ex As Exception
                    msg = ex.Message
                End Try

                If String.IsNullOrEmpty(msg) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "PAY3105_01.aspx")
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

    Private Sub BindOne()
        Dim dr As DataRow = dao.PBYDAO.GetOne(txtBeneficiary_id.Text, LoginManager.OrgCode)
        If Not dr Is Nothing Then
            txtBeneficiary_name.Text = CommonFun.SetDataRow(dr, "Beneficiary_name")
            txtBankAccount_nos.Text = CommonFun.SetDataRow(dr, "BankAccount_nos")
            txtEmail.Text = CommonFun.SetDataRow(dr, "Email")
            ucBank.Bank_ID = CommonFun.SetDataRow(dr, "Bank_ID")
            ucBank.Bank_Name = CommonFun.SetDataRow(dao.PBDAO.GetOne(CommonFun.SetDataRow(dr, "Bank_id"), LoginManager.OrgCode), "Bank_name")
            Dim User_id As String = CommonFun.SetDataRow(dr, "User_id")
            trEmpY.Visible = Not String.IsNullOrEmpty(User_id)
            trEmpN.Visible = String.IsNullOrEmpty(User_id)
            rblEmp.SelectedValue = IIf(String.IsNullOrEmpty(User_id), "N", "Y")
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "找不到受款人資料")
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindOne()
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3105_01.aspx")
    End Sub

    Protected Sub rblEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblEmp.SelectedIndexChanged
        trEmpY.Visible = rblEmp.SelectedValue = "Y"
        trEmpN.Visible = rblEmp.SelectedValue = "N"
    End Sub


End Class
