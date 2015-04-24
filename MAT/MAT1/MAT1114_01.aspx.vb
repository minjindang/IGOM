Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT_MAT1_MAT1114_01
    Inherits BaseWebForm

    Dim dao As New MAT1114

    Private Sub BindGV()
        Dim dt As DataTable = dao.GetData(Me.txtMaterial_id.Text, Me.ucInv_date.Text, LoginManager.OrgCode)
        div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim arguments() As String = e.CommandArgument.ToString().Split(";")
        Dim OrgCode As String = arguments(0)
        Dim Inventory_id As String = arguments(1)
        Dim Material_id As String = arguments(2)
        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/MAT/MAT1/MAT1114_03.aspx?Inventory_id={0}&OrgCode={1}&Material_id={2}", Inventory_id, OrgCode, Material_id))
        ElseIf e.CommandName = "GoDelete" Then

          
            BindGV()
        End If

    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As System.EventArgs) Handles QryBtn.Click
        BindGV()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As System.EventArgs) Handles AddBtn.Click
        Dim inventoryid As Integer = dao.GetInventoryIdd(LoginManager.OrgCode)

        If inventoryid = 0 Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "尚未開始進行盤點，不可使用")
        Else
            Page.Response.Redirect("~/MAT/MAT1/MAT1114_02.aspx")
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

End Class
