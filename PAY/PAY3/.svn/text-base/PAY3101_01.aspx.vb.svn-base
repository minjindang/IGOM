Imports FSCPLM.Logic
Imports System.IO
Imports System.Data
Imports System.Transactions

Partial Class PAY_PAY3_PAY3101_01
    Inherits BaseWebForm

    Dim dao As New PAY3101

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
    
        BindGV()
    End Sub

    Private Sub BindGV() 
        Dim dt As DataTable = dao.GetAll(LoginManager.OrgCode, ucFiscalYear_id.Year.ToString(), txtPrepay_id_S.Text, txtPrepay_id_E.Text, txtPCList_id.Text, _
                                         rblWriteOff_date.SelectedValue, uc_Borrow_date_S.Text, uc_Borrow_date_E.Text, txtPettyCash_nos_S.Text, txtPettyCash_nos_E.Text, _
                                         Me.ucBeneficiary.Beneficiary_ID, txtUse_type.Text, ucInvoice_date.Text, txtPaymentVoucher_id.Text)
        div1.Visible = True

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

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim SerialNumber_id As String = e.CommandArgument

        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/PAY/PAY3/PAY3101_03.aspx?SerialNumber_id={0}", SerialNumber_id))
        ElseIf e.CommandName = "GoDelete" Then 
            dao.Delete(LoginManager.OrgCode, SerialNumber_id)
            BindGV()
        End If
    End Sub

    Protected Sub ClrButton_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Master)
    End Sub

    Protected Sub GridViewA_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewA.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hfWriteOff_date As HiddenField = e.Row.FindControl("hfWriteOff_date") 
            Dim btn2 As Button = e.Row.FindControl("btn2")
            btn2.Enabled = hfWriteOff_date.Value = ""
        End If
    End Sub

    Protected Sub ddlUse_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUse_type.SelectedIndexChanged
        txtUse_type.Text = ddlUse_type.SelectedValue
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dtUseType As DataTable = dao.GetUse_type()
            If Not dtUseType Is Nothing AndAlso dtUseType.Rows.Count > 0 Then
                ddlUse_type.DataSource = dtUseType
                ddlUse_type.DataTextField = "code_desc1"
                ddlUse_type.DataValueField = "code_desc2"
                ddlUse_type.DataBind()
                txtUse_type.Text = dtUseType.Rows(0)("code_desc2")
            End If
        End If
    End Sub

End Class
