Imports FSCPLM.Logic
Imports System.Data


Partial Class PAY_PAY3_PAY3103_01
    Inherits BaseWebForm

    Dim dao As New PAY3103

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then 
            ucWriteOff_date.Text = CommonFun.getYYYMMDD()
        End If
    End Sub

    Protected Sub ClrBtn_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub
 

    Private Sub BindLendPetty()
        Dim dt As DataTable = dao.Get310301(ucFiscalYear_id.Year, ucPettyCash_type.Code_no, txtPCList_id.Text, txtPettyCashStart_nos.Text, txtPettyCashEnd_nos.Text, _
                                           txtPrepayStart_nos.Text, txtPrepayEnd_nos.Text, ucWriteOff_date.Text)
        div1.Visible = True
        'Not dt Is Nothing AndAlso dt.Rows.Count > 0
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
        BindLendPetty()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Page.Response.Redirect("~/PAY/PAY3/PAY3103_02.aspx") 
    End Sub

End Class
