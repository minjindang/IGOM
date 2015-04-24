Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3201_02
    Inherits BaseWebForm

    Dim dao As New PAY3201
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim dtMainDT As DataTable = dao.EIMDAO.GetAll()
                If Not dtMainDT Is Nothing AndAlso dtMainDT.Rows.Count > 0 Then
                    ddlExamineIncome.DataSource = dtMainDT
                    ddlExamineIncome.DataTextField = "ExamineIncome_name"
                    ddlExamineIncome.DataValueField = "ExamineIncome_type"
                    ddlExamineIncome.DataBind()

                    txtExamineIncome_type.Text = dtMainDT.Rows(0)("ExamineIncome_type")
                    txtUnitPrice_amt.Text = dtMainDT.Rows(0)("UnitPrice_amt")

                    Dim inos As Integer = 0
                    If IsDBNull(dtMainDT.Rows(0)("LatestReceipt")) Then
                        inos = 1
                    Else
                        inos = Convert.ToInt32(dtMainDT.Rows(0)("LatestReceipt")) + 1
                    End If
                    txtReceiptStart_id.Text = inos.ToString().PadLeft(6, "0")
                End If

                Dim dtPayMode_type As DataTable = dao.SCDAO.GetData("018", "003")
                '刪除電子付款
                If Not dtMainDT Is Nothing AndAlso dtMainDT.Rows.Count > 0 Then
                    dtPayMode_type.Rows(1).Delete()
                End If
                ddlPayMode_type.DataSource = dtPayMode_type
                ddlPayMode_type.DataTextField = "CODE_DESC1"
                ddlPayMode_type.DataValueField = "CODE_NO"
                ddlPayMode_type.DataBind()
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        Dim result As String = String.Empty

        If String.IsNullOrEmpty(txtExamineIncome_type.Text) Then
            result &= "請選擇收入類別\n"
        End If
        If String.IsNullOrEmpty(txtExamine_cnt.Text) Then
            result &= "請輸入件數\n"
        Else
            If Not CommonFun.IsNum(txtExamine_cnt.Text) Then
                result &= "件數要為數字\n"
            End If
        End If
        If String.IsNullOrEmpty(txtTotalPrice_amt.Text) Then
            result &= "請輸入總額\n"
        End If

        If String.IsNullOrEmpty(ucReceipt_date.Text) Then
            result &= "請輸入收款日期\n"
        End If

        If String.IsNullOrEmpty(UcPayer.Payer_id) OrElse String.IsNullOrEmpty(UcPayer.Payer_name) Then
            result &= "請輸入付款人\n"
        End If

        If Not String.IsNullOrEmpty(result) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
        Else

            result = dao.Add(txtExamineIncome_type.Text, txtReceiptStart_id.Text, txtReceiptEnd_id.Text, ucReceipt_date.Text, _
                              UcPayer.Payer_id, UcPayer.Payer_name, txtExamine_cnt.Text, txtUnitPrice_amt.Text, txtTotalPrice_amt.Text, _
                              ddlPayMode_type.SelectedValue, cbReceiptScrap_type.Checked, txtCheck1_nos.Text, txtCheck2_nos.Text)
            If String.IsNullOrEmpty(result) Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "新增成功!!")
            Else
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
            End If
        End If
    End Sub

    Protected Sub CopyBtn_Click(sender As Object, e As EventArgs) Handles CopyBtn.Click
        Dim result As String = String.Empty

        If String.IsNullOrEmpty(txtExamineIncome_type.Text) Then
            result &= "請選擇收入類別\n"
        End If
       
        If Not String.IsNullOrEmpty(result) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
        Else
           
            Dim dt As DataTable = dao.EIMDAO.CopySelect(orgcode, txtExamineIncome_type.Text)
            Dim szReceiptStart_id As String = String.Empty
            Dim szReceiptEnd_id As String = String.Empty
            Dim szReceipt_date As String = String.Empty
            Dim szPayer_id As String = String.Empty
            Dim szPayer_name As String = String.Empty
            Dim szExamine_cnt As String = String.Empty
            Dim szUnitPrice_amt As String = String.Empty
            Dim szTotalPrice_amt As String = String.Empty
            Dim szPayMode_type As String = String.Empty
            Dim szReceiptScrap_type As String = String.Empty

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    szReceiptStart_id = dr("NReceiptStart_id").ToString()
                    szReceiptEnd_id = dr("NReceiptEnd_id").ToString()
                    szReceipt_date = dr("Receipt_date").ToString()
                    szPayer_id = dr("Payer_id").ToString()
                    szPayer_name = dr("Payer_name").ToString()
                    szExamine_cnt = dr("Examine_cnt").ToString()
                    szUnitPrice_amt = dr("UnitPrice_amt").ToString()
                    szTotalPrice_amt = dr("TotalPrice_amt").ToString()
                    szPayMode_type = dr("PayMode_type").ToString()
                    szReceiptScrap_type = dr("ReceiptScrap_type").ToString()
                Next
            End If

            If szReceiptScrap_type.ToUpper = "N" Then
                szReceiptScrap_type = "False"
            Else
                szReceiptScrap_type = "true"
            End If

            txtReceiptStart_id.Text = szReceiptStart_id
            txtReceiptEnd_id.Text = szReceiptEnd_id
            ucReceipt_date.Text = szReceipt_date
            UcPayer.Payer_id = szPayer_id
            txtExamine_cnt.Text = szExamine_cnt
            txtUnitPrice_amt.Text = szUnitPrice_amt
            txtTotalPrice_amt.Text = szTotalPrice_amt
            ddlPayMode_type.SelectedValue = szPayMode_type
            cbReceiptScrap_type.Checked = (szReceiptScrap_type = "Y")

            'result = dao.Add(txtExamineIncome_type.Text, szReceiptStart_id, szReceiptEnd_id, szReceipt_date, _
            '                 szPayer_id, szPayer_name, szExamine_cnt, szUnitPrice_amt, szTotalPrice_amt, szPayMode_type, szReceiptScrap_type, "", "")
            'If String.IsNullOrEmpty(result) Then
            '    CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "複製成功!!")
            'Else
            '    CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
            'End If
        End If
    End Sub

    Protected Sub txtExamine_cnt_TextChanged(sender As Object, e As EventArgs) Handles txtExamine_cnt.TextChanged
        Try
            If String.IsNullOrEmpty(txtReceiptStart_id.Text) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "收據編號必填!!")
                Return
            End If
            If Not CommonFun.IsNum(txtExamine_cnt.Text) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "件數要為數字!!")
                Return
            End If

            If txtExamine_cnt.Text < 1 Then
                txtExamine_cnt.Text = 1
            End If

            txtTotalPrice_amt.Text = txtUnitPrice_amt.Text * txtExamine_cnt.Text
            txtReceiptEnd_id.Text = (Convert.ToInt32(txtReceiptStart_id.Text) + Convert.ToInt32(txtExamine_cnt.Text) - 1).ToString().PadLeft(6, "0")

        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub

    Protected Sub ddlExamineIncome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExamineIncome.SelectedIndexChanged
        txtExamineIncome_type.Text = ddlExamineIncome.SelectedValue
        Dim dtMainDR As DataRow = dao.EIMDAO.GetOne(txtExamineIncome_type.Text, orgcode)
        Dim dt As DataTable = dao.EIDDAO.GetAll(orgcode, txtExamineIncome_type.Text, "", "", "", "", "", "", "")

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            txtReceiptStart_id.Text = (dt.Rows(dt.Rows.Count() - 1)("ReceiptEnd_id") + 1).ToString.PadLeft(6, "0")
        Else
            txtReceiptStart_id.Text = "000001"
        End If
        txtUnitPrice_amt.Text = dtMainDR("UnitPrice_amt")
        txtReceiptEnd_id.Text = ""
        txtExamine_cnt.Text = ""
        txtTotalPrice_amt.Text = ""

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("~/PAY/PAY3/PAY3201_01.aspx")
    End Sub

    Protected Sub cbReceiptScrap_type_CheckedChanged(sender As Object, e As EventArgs)
        If cbReceiptScrap_type.Checked Then
            txtUnitPrice_amt.Text = "0"
            txtTotalPrice_amt.Text = "0"
        End If
    End Sub
End Class
