Imports FSCPLM.Logic
Imports System.Data

Partial Class PAY_PAY3_PAY3201_01
    Inherits BaseWebForm

    Dim dao As New PAY3201

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dtMainDT As DataTable = dao.EIMDAO.GetAll()
            If Not dtMainDT Is Nothing AndAlso dtMainDT.Rows.Count > 0 Then
                ddlExamineIncome.DataSource = dtMainDT
                ddlExamineIncome.DataTextField = "ExamineIncome_name"
                ddlExamineIncome.DataValueField = "ExamineIncome_type"
                ddlExamineIncome.DataBind()
                'ddlExamineIncome.Items.Insert(0, New ListItem("--請選擇--", ""))
                txtExamineIncome_type.Text = dtMainDT.Rows(0)("ExamineIncome_type")

            End If

            Dim dtPayMode_type As DataTable = dao.SCDAO.GetData("018", "003")
            '刪除電子付款
            'If Not dtMainDT Is Nothing AndAlso dtMainDT.Rows.Count > 0 Then
            '    dtPayMode_type.Rows(1).Delete()
            'End If
            ddlPayMode_type.DataSource = dtPayMode_type
            ddlPayMode_type.DataTextField = "CODE_DESC1"
            ddlPayMode_type.DataValueField = "CODE_NO"
            ddlPayMode_type.DataBind()
        End If
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim args() As String = e.CommandArgument.ToString().Split(";")

        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/PAY/PAY3/PAY3201_03.aspx?ExamineIncome_type={0}&ReceiptStart_id={1}", args(0), args(1)))
        ElseIf e.CommandName = "GoPrint" Then
            Page.Response.Redirect(String.Format("~/PAY/PAY3/PAY3201_03.aspx?ExamineIncome_type={0}&ReceiptStart_id={1}", args(0), args(1)))
        ElseIf e.CommandName = "GoDelete" Then
            dao.Remove(args(0), args(1))
            Bind()
        End If

    End Sub 

    Protected Sub ClrButton_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click
        CommonFun.ClearContentPlaceHolder(Master)
    End Sub

    Protected Sub GridViewA_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewA.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn1 As Button = e.Row.FindControl("btn1")
            Dim btn2 As Button = e.Row.FindControl("btn2")
            Dim btn3 As Button = e.Row.FindControl("btn3") 
            If "" <> HttpUtility.HtmlDecode(e.Row.Cells(9).Text).Trim() Then
                btn1.Enabled = False
                btn2.Enabled = False
                btn3.Enabled = False
            End If

        End If

    End Sub

    Private Sub Bind()
        Dim dt As DataTable = dao.GetAll(txtExamineIncome_type.Text, txtReceipt.Text, ucReceipt_date.Text, UcPayer.Payer_id, _
                                         ddlPayMode_type.SelectedValue, cbReceiptScrap_type.Checked, txtCheck1_nos.Text, txtCheck2_nos.Text)
        div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        Try
            If Not CommonFun.IsNum(txtReceipt.Text) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "收據編號要為數字!!")
                Return
            End If

        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

        Bind()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3201_02.aspx")
    End Sub

    Protected Sub ddlExamineIncome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExamineIncome.SelectedIndexChanged
        Dim dt As DataTable = dao.EIMDAO.GetAll()
        For Each dr As DataRow In dt.Rows
            If dr("ExamineIncome_type") = ddlExamineIncome.Text Then
                txtExamineIncome_type.Text = dr("ExamineIncome_type")
            End If
        Next
    End Sub
End Class
