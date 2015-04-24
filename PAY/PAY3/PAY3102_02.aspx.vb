Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3102_02
    Inherits BaseWebForm

    Dim dao As New PAY3102

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dtUseType As DataTable = dao.GetUse_type()
            If Not dtUseType Is Nothing AndAlso dtUseType.Rows.Count > 0 Then
                ddlUse_type.DataSource = dtUseType
                ddlUse_type.DataTextField = "code_desc1"
                ddlUse_type.DataValueField = "code_desc2"
                ddlUse_type.DataBind()
                txtUse_type.Text = dtUseType.Rows(0)("code_desc2")

                hfIsGeneration.Value = dao.IsNewGeneration(LoginManager.OrgCode).ToString().ToLower()
                If hfIsGeneration.Value = "true" Then
                    txtMiddleman_name.Enabled = False
                End If
            End If

            ucWriteOff_date.Text = DateTimeInfo.GetRocDate(Now)
            ucWriteOff_date.Enabled = False
        End If
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        Dim result As String = String.Empty

        If String.IsNullOrEmpty(txtPurchaseForm_id.Text) Then
            result &= "請輸入請購單號\n"
        End If

        If String.IsNullOrEmpty(txtReceipt_cnt.Text) Then
            result &= "請輸入單據張數\n"
        Else
            If Not CommonFun.IsNum(txtReceipt_cnt.Text) Then
                result &= "單據張數，請輸入數字\n"
            End If
        End If

        If String.IsNullOrEmpty(txtPurchaseTotal_amt.Text) Then
            result &= "請輸入請購金額\n"
        Else
            If Not CommonFun.IsNum(txtPurchaseTotal_amt.Text) Then
                result &= "請購金額，請輸入數字\n"
            End If
        End If

        If String.IsNullOrEmpty(ucInvoice_date.Text) Then
            result &= "請輸入發票日期\n"
        End If

        If String.IsNullOrEmpty(UcBeneficiary.Beneficiary_ID) OrElse String.IsNullOrEmpty(UcBeneficiary.Beneficiary_Name) Then
            result &= "請輸入受款人\n"
        End If

        If Not CommonFun.IsNum(txtPettyCash_nos.Text) Then
            result &= "零用金流水號，請輸入數字\n"
        End If

        'If Not CommonFun.IsNum(txtPaymentVoucher_id.Text) Then
        '    result &= "付款憑單編號，請輸入數字\n"
        'End If

        If Not CheckBeneficiary(UcBeneficiary.Beneficiary_ID) Then
            result &= "查無受款人，請先至受款人帳號維護\n"
        End If


        If Not String.IsNullOrEmpty(result) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
        Else
            Try
                txtPettyCash_nos.Text = dao.Insert(LoginManager.OrgCode, ucFiscalYear_id.Year.ToString(), txtPettyCash_nos.Text, ucInvoice_date.Text, txtPurchaseForm_id.Text, _
                                                   UcBeneficiary.Beneficiary_ID, txtMiddleman_name.Text, txtUse_type.Text, txtReceipt_cnt.Text, txtPurchaseTotal_amt.Text, txtPurchaseAbstract_desc.Text, _
                                                   "", ucWriteOff_date.Text, txtPaymentVoucher_id.Text, LoginManager.UserId, Now, txtPurchaseForm_sn.Text, UcBeneficiary.Beneficiary_Name, txtMiddleman_id.Text.Trim())

                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "新增成功", "PAY3102_01.aspx")
            Catch fex As FlowException
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message)
            End Try
        End If
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub txtPurchaseForm_sn_TextChanged(sender As Object, e As EventArgs) Handles txtPurchaseForm_sn.TextChanged
        'TODO 如果有二代會計系統界接去  讀View去找 受款人
        If hfIsGeneration.Value = "true" Then
            Dim dtData As DataTable = dao.GetData(ucFiscalYear_id.Year, txtPurchaseForm_id.Text, txtPurchaseForm_sn.Text)
            For Each dr As DataRow In dtData.Rows
                UcBeneficiary.Beneficiary_ID = dr("Id_card").ToString().Trim() 'dr("RecvNo").ToString()
                UcBeneficiary.Beneficiary_Name = dr("User_name").ToString().Trim() 'dr("RecvName").ToString()
                txtPurchaseAbstract_desc.Text = dr("PoreMnm").ToString().Trim()
                txtMiddleman_id.Text = dr("PoId").ToString().Trim()
                txtMiddleman_name.Text = dr("User_name").ToString().Trim()
                txtPaymentVoucher_id.Text = dr("VOUNO").ToString().Trim()
            Next
        End If
    End Sub

    Protected Sub ddlUse_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUse_type.SelectedIndexChanged
        txtUse_type.Text = ddlUse_type.SelectedValue
    End Sub


    Protected Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Response.Redirect("~/PAY/PAY3/PAY3102_01.aspx")
    End Sub


    Protected Function CheckBeneficiary(Beneficiary_id As String) As Boolean
        Dim beneficiary As New PAY_Beneficiary_data()
        Dim row As DataRow = beneficiary.GetOne(Beneficiary_id, LoginManager.OrgCode)
        If row Is Nothing Then
            Return False
        End If
        Return True
    End Function
End Class
