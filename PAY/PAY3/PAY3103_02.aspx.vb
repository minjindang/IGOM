Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3103_02
    Inherits BaseWebForm

    Dim dao As New PAY3103

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If ucPettyCash_type.Code_no = "001" Then '預借
            ' 鎖定流水號
            txtPettyCashStart_nos.Enabled = False
            txtPettyCashEnd_nos.Enabled = False
            txtPrepayStart_nos.Enabled = True
            txtPrepayEnd_nos.Enabled = True
            ucWriteOff_date.Text = CommonFun.getYYYMMDD()
            ucWriteOff_date.Enabled = True

            txtPettyCashStart_nos.Text = ""
            txtPettyCashEnd_nos.Text = ""
        Else
            ' 鎖定編號/核銷日期清空不可輸入
            txtPettyCashStart_nos.Enabled = True
            txtPettyCashEnd_nos.Enabled = True
            txtPrepayStart_nos.Enabled = False
            txtPrepayEnd_nos.Enabled = False
            ucWriteOff_date.Text = ""
            ucWriteOff_date.Enabled = False

            txtPrepayStart_nos.Text = ""
            txtPrepayEnd_nos.Text = ""
        End If

        If Not Page.IsPostBack Then
            DoneBtn.Enabled = False
            ucWriteOff_date.Text = CommonFun.getYYYMMDD()

            ucPettyCash_type.SelectedValue = "002"
            

        End If
    End Sub

    Protected Sub ClrBtn_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Sub BindLendPetty()
        Dim dt As DataTable = dao.Get310302(ucFiscalYear_id.Year, ucPettyCash_type.Code_no, txtPettyCashStart_nos.Text, txtPettyCashEnd_nos.Text, _
                                             txtPrepayStart_nos.Text, txtPrepayEnd_nos.Text)

        GridViewA.DataSource = dt
        GridViewA.DataBind()

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            DoneBtn.Enabled = True
            div1.Visible = True
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "查無資料")
        End If

      
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        BindLendPetty()

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = String.Empty

        If ucPettyCash_type.Code_no = "001" And String.IsNullOrEmpty(ucWriteOff_date.Text) Then '預借
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入核銷日期!")
            Return
        End If

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("SerialNumber_id"))
        dt.Columns.Add(New DataColumn("PettyCash_nos"))
        dt.Columns.Add(New DataColumn("Prepay_id"))
        dt.Columns.Add(New DataColumn("TotalSIncome"))
        dt.Columns.Add(New DataColumn("FiscalYear_id"))
        dt.Columns.Add(New DataColumn("Invoice_date"))
        dt.Columns.Add(New DataColumn("Beneficiary_id"))
        dt.Columns.Add(New DataColumn("Beneficiary_name"))
        dt.Columns.Add(New DataColumn("Middleman_id"))
        dt.Columns.Add(New DataColumn("Middleman_name"))
        dt.Columns.Add(New DataColumn("Use_type"))
        dt.Columns.Add(New DataColumn("Receipt_cnt"))
        dt.Columns.Add(New DataColumn("PurchaseTotal_amt"))
        dt.Columns.Add(New DataColumn("PurchaseAbstract_desc"))
        dt.Columns.Add(New DataColumn("PurchaseForm_id"))
        dt.Columns.Add(New DataColumn("PurchaseForm_sn"))
        dt.Columns.Add(New DataColumn("WriteOff_date"))

        For Each gr As GridViewRow In GridViewA.Rows
            Dim cbLendPetty As CheckBox = gr.FindControl("cbLendPetty")
            Dim hfSerialNumber_id As HiddenField = gr.FindControl("hfSerialNumber_id")
            If cbLendPetty.Checked Then
                Dim dr As DataRow = dt.NewRow()
                dr("SerialNumber_id") = hfSerialNumber_id.Value
                dr("PettyCash_nos") = CType(gr.FindControl("hfPettyCash_nos"), HiddenField).Value
                dr("Prepay_id") = CType(gr.FindControl("hfPrepay_id"), HiddenField).Value
                dr("TotalSIncome") = gr.Cells(5).Text
                dr("FiscalYear_id") = gr.Cells(1).Text
                dr("Invoice_date") = CType(gr.FindControl("hfInvoice_date"), HiddenField).Value
                dr("Beneficiary_id") = CType(gr.FindControl("hfBeneficiary_id"), HiddenField).Value
                dr("Beneficiary_name") = CType(gr.FindControl("hfBeneficiary_name"), HiddenField).Value
                dr("Middleman_id") = CType(gr.FindControl("hfMiddleman_id"), HiddenField).Value
                dr("Middleman_name") = CType(gr.FindControl("hfMiddleman_name"), HiddenField).Value
                dr("Use_type") = CType(gr.FindControl("hfUse_type"), HiddenField).Value
                dr("Receipt_cnt") = CType(gr.FindControl("hfReceipt_cnt"), HiddenField).Value
                dr("PurchaseTotal_amt") = CType(gr.FindControl("hfPurchaseTotal_amt"), HiddenField).Value
                dr("PurchaseAbstract_desc") = CType(gr.FindControl("hfPurchaseAbstract_desc"), HiddenField).Value
                dr("PurchaseForm_id") = CType(gr.FindControl("hfPurchaseForm_id"), HiddenField).Value
                dr("PurchaseForm_sn") = CType(gr.FindControl("hfPurchaseForm_sn"), HiddenField).Value

                If ucPettyCash_type.Code_no = "001" Then '預借
                    dr("WriteOff_date") = ucWriteOff_date.Text
                End If

                dt.Rows.Add(dr)
            End If

        Next

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "請至少選擇一筆資料")
            Return
        End If


        Dim pclist_id As String = "00001"
        ' 取最後一筆零用金清單編號
        Dim pclistdt As DataTable = dao.GetPCList_id(ucFiscalYear_id.Year)
        If pclistdt IsNot Nothing AndAlso pclistdt.Rows.Count > 0 Then
            For Each dr As DataRow In pclistdt.Rows
                pclist_id = dr("PCList_id").ToString()
            Next
        End If

        Try
            dao.Done(ucFiscalYear_id.Year, ucPettyCash_type.Code_no, pclist_id, ucWriteOff_date.Text, dt)

            BindLendPetty()
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message)
        End Try
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs)
        Response.Redirect("PAY3103_01.aspx")
    End Sub
End Class
