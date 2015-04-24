Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3201_03
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

                txtReceiptStart_id.Text = Request.QueryString("ReceiptStart_id")
                txtExamineIncome_type.Text = dtMainDT.Rows(0)("ExamineIncome_type")
                ddlExamineIncome.SelectedValue = dtMainDT.Rows(0)("ExamineIncome_type")

                BindOne()
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3201_01.aspx")
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindOne()
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        Dim result As String = String.Empty

        If String.IsNullOrEmpty(txtExamineIncome_type.Text) Then
            result &= "請選擇收入類別\n"
        End If
        If String.IsNullOrEmpty(txtTotalPrice_amt.Text) Then
            result &= "請輸入請總額\n"
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

            result = dao.Modify(txtExamineIncome_type.Text, txtReceiptStart_id.Text, txtReceiptEnd_id.Text, ucReceipt_date.Text, _
                              UcPayer.Payer_id, UcPayer.Payer_name, txtExamine_cnt.Text, txtUnitPrice_amt.Text, txtTotalPrice_amt.Text, _
                              ddlPayMode_type.SelectedValue, cbReceiptScrap_type.Checked, txtCheck1_nos.Text, txtCheck2_nos.Text)
            If String.IsNullOrEmpty(result) Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "修改成功!!")
                'Page.Response.Redirect("~/PAY/PAY3/PAY3201_01.aspx")
            Else
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
            End If
        End If
    End Sub

    Private Sub BindOne()
        Dim dr As DataRow = dao.EIDDAO.GetOne(txtExamineIncome_type.Text, LoginManager.OrgCode, txtReceiptStart_id.Text)
        If dr Is Nothing Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "找不到資料")
            Page.Response.Redirect("~/PAY/PAY3/PAY3201_01.aspx")
        Else
            txtReceiptEnd_id.Text = CommonFun.SetDataRow(dr, "ReceiptEnd_id")
            ucReceipt_date.Text = CommonFun.SetDataRow(dr, "Receipt_date")
            txtExamine_cnt.Text = CommonFun.SetDataRow(dr, "Examine_cnt")
            UcPayer.Payer_id = CommonFun.SetDataRow(dr, "Payer_id")
            UcPayer.Payer_name = CommonFun.SetDataRow(dr, "Payer_name")
            txtUnitPrice_amt.Text = CommonFun.SetDataRow(dr, "UnitPrice_amt")
            txtTotalPrice_amt.Text = CommonFun.SetDataRow(dr, "TotalPrice_amt")
            ddlPayMode_type.SelectedValue = CommonFun.SetDataRow(dr, "PayMode_type")
            txtCheck1_nos.Text = CommonFun.SetDataRow(dr, "Check1_nos")
            txtCheck2_nos.Text = CommonFun.SetDataRow(dr, "Check2_nos")
            cbReceiptScrap_type.Checked = CommonFun.SetDataRow(dr, "ReceiptScrap_type") = "Y"
        End If

    End Sub

    Protected Sub cbReceiptScrap_type_CheckedChanged(sender As Object, e As EventArgs)
        If cbReceiptScrap_type.Checked Then
            txtUnitPrice_amt.Text = "0"
            txtTotalPrice_amt.Text = "0"
        End If
    End Sub
End Class
