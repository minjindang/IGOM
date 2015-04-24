Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT3202_03
    Inherits BaseWebForm

    Dim dao As New MAT3202
    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = String.Empty

        If String.IsNullOrEmpty(Me.txtMaterial_id.Text) Then
            msg += "請輸入物料編號\n"
        End If

        If String.IsNullOrEmpty(Me.ucInv_date.Text) Then
            msg += "請輸入盤點日期\n"
        End If

        If String.IsNullOrEmpty(Me.txtInvAfter_cnt.Text) Then
            msg += "請輸入盤點數量\n"
        End If


        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        Else
            Dim inventoryid As Integer = dao.GetInventoryIdd(LoginManager.OrgCode)
            Dim msgInsert As String = dao.Update(LoginManager.OrgCode, inventoryid, txtMaterial_id.Text, ucInv_date.Text, _
                                                 txtInvBefore_cnt.Text, txtInvAfter_cnt.Text, txtInvModify_cnt.Text, txtDiff_desc.Text, LoginManager.UserId)
            Dim dt As DataTable = New DataTable
            dt = dao.GetDataMaterial(LoginManager.OrgCode, LoginManager.UserId, txtMaterial_id.Text)
            'New FSCPLM.Logic.Material_main().UpdateAvaiable(LoginManager.OrgCode, dt.Rows(0).Item("Available_cnt"), txtMaterial_id.Text, txtInvBefore_cnt.Text, txtInvAfter_cnt.Text)
            Dim materialMain As New Material_main
            materialMain.UpdateAvaiable(LoginManager.OrgCode, txtMaterial_id.Text, txtInvBefore_cnt.Text, txtInvAfter_cnt.Text)
            If Not String.IsNullOrEmpty(msgInsert) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msgInsert)
            Else

                Dim oritxtMaterial_id, oriucInv_date As String
                oritxtMaterial_id = Page.Request.QueryString("txtMaterial_id")
                oriucInv_date = Page.Request.QueryString("ucInv_date")
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「修改盤點資料成功」", "MAT3202_01.aspx?oritxtMaterial_id=" + oritxtMaterial_id + "oriucInv_date=" + oriucInv_date)
                'Page.Response.Redirect(String.Format("~/MAT/MAT3/MAT3202_01.aspx?txtMaterial_id={0}&ucInv_date={1}", _
                '                                         oritxtMaterial_id, oriucInv_date))
            End If
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        'CommonFun.ClearContentPlaceHolder(Me.Master)
        hfInventory.Value = Page.Request.QueryString("Inventory_id")
        Me.txtMaterial_id.Text = Page.Request.QueryString("Material_id")
        BindMaterialInfo(Me.txtMaterial_id.Text)
        BindInventory(Me.txtMaterial_id.Text, hfInventory.Value)
        ucDiff_desc.DDL.AutoPostBack = True
    End Sub

    Protected Sub txtMaterialId_TextChanged(sender As Object, e As EventArgs) Handles txtMaterial_id.TextChanged
        BindMaterialInfo(Me.txtMaterial_id.Text)
    End Sub

    Private Sub BindMaterialInfo(materialID As String)
        Dim dr As DataRow = dao.GetMatData(materialID)
        If Not dr Is Nothing Then
            Me.txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
            Me.txtMaterial_name.Text = CommonFun.SetDataRow(dr, "Material_name")
            Me.txtInvBefore_cnt.Text = CommonFun.SetDataRow(dr, "Reserve_cnt")
        End If
    End Sub

    Private Sub BindInventory(materialID As String, inventoryID As Integer)
        Dim dr As DataRow = dao.GetDataOne(materialID, inventoryID, LoginManager.OrgCode)
        If Not dr Is Nothing Then
            Me.ucInv_date.Text = CommonFun.SetDataRow(dr, "Inv_date")
            Me.txtInvBefore_cnt.Text = CommonFun.SetDataRow(dr, "InvBefore_cnt")
            Me.txtInvAfter_cnt.Text = CommonFun.SetDataRow(dr, "InvAfter_cnt")
            Me.txtInvModify_cnt.Text = CommonFun.SetDataRow(dr, "InvModify_cnt")
            Me.txtDiff_desc.Text = CommonFun.SetDataRow(dr, "Diff_desc")
        End If
    End Sub

    Protected Sub txtInvAfter_cnt_TextChanged(sender As Object, e As EventArgs) Handles txtInvAfter_cnt.TextChanged
        If Not CommonFun.IsNum(txtInvAfter_cnt.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「盤點數量」請輸入數字。")
            Return
        End If
        Me.txtInvModify_cnt.Text = Me.txtInvAfter_cnt.Text - Me.txtInvBefore_cnt.Text

    End Sub

    Protected Sub ucDiff_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ucDiff_desc.CodeChanged

        txtDiff_desc.Text = Me.ucDiff_desc.SelectedItem.Text

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dt As DataTable = New DataTable
            Dim materialMain As New Material_main
         
            hfInventory.Value = Page.Request.QueryString("Inventory_id")
            Me.txtMaterial_id.Text = Page.Request.QueryString("Material_id")
            dt = materialMain.CheckInvMainExist(LoginManager.OrgCode, txtMaterial_id.Text, hfInventory.Value)
            If dt.Rows(0).Item("InvEnd_date").ToString = "" Then
                BindMaterialInfo(Me.txtMaterial_id.Text)
                BindInventory(Me.txtMaterial_id.Text, hfInventory.Value)
                ucDiff_desc.DDL.AutoPostBack = True
            Else
                BindMaterialInfo(Me.txtMaterial_id.Text)
                BindInventory(Me.txtMaterial_id.Text, hfInventory.Value)
                ucDiff_desc.DDL.AutoPostBack = True
                txtMaterial_id.Enabled = False
                ucInv_date.Enabled = False
                txtInvAfter_cnt.Enabled = False

            End If
        End If

    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Dim oritxtMaterial_id, oriucInv_date As String
        oritxtMaterial_id = Page.Request.QueryString("txtMaterial_id")
        oriucInv_date = Page.Request.QueryString("ucInv_date")
        Page.Response.Redirect(String.Format("~/MAT/MAT3/MAT3202_01.aspx?txtMaterial_id={0}&ucInv_date={1}", _
                                                 oritxtMaterial_id, oriucInv_date))
    End Sub
End Class
