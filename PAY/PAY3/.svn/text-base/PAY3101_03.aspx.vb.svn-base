Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3101_03
    Inherits BaseWebForm

    Dim dao As New PAY3101 

    Private Sub BindOne()
        Dim dr As DataRow = dao.GetOne(LoginManager.OrgCode, hfSerialNumber_id.Value)
        If Not dr Is Nothing Then
            Dim iYezr As Integer = Integer.Parse(CommonFun.SetDataRow(dr, "FiscalYear_id").ToString.Trim()) + 1911
            ucFiscalYear_id.Year = iYezr
            txtPettyCash_nos.Text = CommonFun.SetDataRow(dr, "PettyCash_nos").ToString.Trim()
            txtPrepay_id.Text = CommonFun.SetDataRow(dr, "Prepay_id").ToString.Trim().ToString.Trim()
            txtPurchaseForm_id.Text = CommonFun.SetDataRow(dr, "PurchaseForm_id").ToString.Trim()
            txtPurchaseForm_sn.Text = CommonFun.SetDataRow(dr, "PurchaseForm_sn").ToString.Trim()
            'ucIncome_date.Text = CommonFun.SetDataRow(dr, "Income_date")
            UcBeneficiary.Beneficiary_ID = CommonFun.SetDataRow(dr, "Beneficiary_ID").ToString.Trim()
            UcBeneficiary.Beneficiary_Name = CommonFun.SetDataRow(dr, "Beneficiary_Name").ToString.Trim()
            txtMiddleman_id.Text = CommonFun.SetDataRow(dr, "Middleman_id").ToString.Trim()
            txtMiddleman_name.Text = CommonFun.SetDataRow(dr, "Middleman_name").ToString.Trim()
            txtUse_type.Text = CommonFun.SetDataRow(dr, "Use_type").ToString.Trim()
            ddlUse_type.SelectedValue = CommonFun.SetDataRow(dr, "Use_type").ToString.Trim()
            txtReceipt_cnt.Text = CommonFun.SetDataRow(dr, "Receipt_cnt").ToString.Trim()
            txtPurchaseTotal_amt.Text = CommonFun.SetDataRow(dr, "PurchaseTotal_amt").ToString.Trim()
            txtPurchaseAbstract_desc.Text = CommonFun.SetDataRow(dr, "PurchaseAbstract_desc").ToString.Trim()

            ucWriteOff_date.Text = CommonFun.SetDataRow(dr, "WriteOff_date").ToString.Trim()
            txtPaymentVoucher_id.Text = CommonFun.SetDataRow(dr, "PaymentVoucher_id").ToString.Trim()
            ucIncome_date.Text = CommonFun.SetDataRow(dr, "Income_date").ToString.Trim()
            ucInvoice_date.Text = CommonFun.SetDataRow(dr, "Invoice_date").ToString.Trim()
            txtIncome_amt.Text = CommonFun.SetDataRow(dr, "Income_amt").ToString.Trim()
            ucBorrow_date.Text = CommonFun.SetDataRow(dr, "Borrow_date").ToString.Trim()

            hfIsGeneration.Value = dao.IsNewGeneration(LoginManager.OrgCode).ToString().ToLower()
            If hfIsGeneration.Value = "true" Then
                txtMiddleman_name.Enabled = False
            End If
            If Not String.IsNullOrEmpty(ucWriteOff_date.Text) Then
                DonBtn.Enabled = False
                ResetBtn.Enabled = False
            End If
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

        If Not CommonFun.IsNum(txtPrepay_id.Text) Then
            result &= "墊付款編號，請輸入數字\n"
        End If

        If Not CommonFun.IsNum(txtPettyCash_nos.Text) Then
            result &= "零用金流水號，請輸入數字\n"
        End If

        If Not CommonFun.IsNum(txtPaymentVoucher_id.Text) Then
            result &= "付款憑單編號，請輸入數字\n"
        End If

        If Not CommonFun.IsNum(txtIncome_amt.Text) Then
            result &= "收回金額，請輸入數字\n"
        End If

        If Not String.IsNullOrEmpty(result) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
        Else

            dao.Update(LoginManager.OrgCode, hfSerialNumber_id.Value, ucFiscalYear_id.Year.ToString(), txtPettyCash_nos.Text, txtPrepay_id.Text, "", txtPurchaseForm_id.Text, ucIncome_date.Text, _
                       UcBeneficiary.Beneficiary_ID, txtMiddleman_name.Text, txtUse_type.Text, txtReceipt_cnt.Text, txtPurchaseTotal_amt.Text, txtPurchaseAbstract_desc.Text, _
                       "", ucWriteOff_date.Text, txtPaymentVoucher_id.Text, ucIncome_date.Text, txtIncome_amt.Text, ucBorrow_date.Text, LoginManager.UserId, Now, txtPurchaseForm_sn.Text, txtMiddleman_id.Text.Trim())

            Page.Response.Redirect("~/PAY/PAY3/PAY3101_01.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hfSerialNumber_id.Value = Page.Request.QueryString("SerialNumber_id")
            BindOne()
            Dim dtUseType As DataTable = dao.GetUse_type()
            If Not dtUseType Is Nothing AndAlso dtUseType.Rows.Count > 0 Then
                ddlUse_type.DataSource = dtUseType
                ddlUse_type.DataTextField = "code_desc1"
                ddlUse_type.DataValueField = "code_desc2"
                ddlUse_type.DataBind() 
            End If
        End If

    End Sub

    Protected Sub ddlUse_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUse_type.SelectedIndexChanged
        txtUse_type.Text = ddlUse_type.SelectedValue
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindOne()
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/PAY/PAY3/PAY3101_01.aspx")
    End Sub

End Class
