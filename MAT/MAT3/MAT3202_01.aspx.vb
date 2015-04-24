Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT3202_01
    Inherits BaseWebForm

    Dim dao As New MAT3202
    Dim InventoryDet As New InventoryDet

#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        If Page.Request.QueryString("txtMaterial_id") IsNot Nothing Then
            txtMaterial_id.Text = Page.Request.QueryString("txtMaterial_id")
        Else
            txtMaterial_id.Text = ""
        End If
        If Page.Request.QueryString("ucInv_date") IsNot Nothing Then
            ucInv_date.Text = Page.Request.QueryString("ucInv_date")
        Else
            ucInv_date.Text = ""
        End If
        BindGV()
        UcMaterialClassB.Orgcode = LoginManager.OrgCode

    End Sub
#End Region
    Private Sub BindGV()
        If Not CommonFun.IsNum(Me.txtMaterial_id.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號請輸入數字!")
            Return
        End If
        Dim dt As DataTable = dao.GetData(Me.txtMaterial_id.Text, Me.ucInv_date.Text, LoginManager.OrgCode)
        div1.Visible = True
        'div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
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
            Page.Response.Redirect(String.Format("~/MAT/MAT3/MAT3202_03.aspx?Inventory_id={0}&OrgCode={1}&Material_id={2}&txtMaterial_id={3}&ucInv_date={4}", _
                                                 Inventory_id, OrgCode, Material_id, txtMaterial_id.Text, ucInv_date.Text))
        ElseIf e.CommandName = "GoDelete" Then
            If (InventoryDet.Delete(LoginManager.OrgCode, Inventory_id, Material_id)) = True Then
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            End If
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
            Page.Response.Redirect("~/MAT/MAT3/MAT3202_02.aspx")
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        txtMaterial_id.Text = UcMaterialClassB.MaterialId
    End Sub
End Class
