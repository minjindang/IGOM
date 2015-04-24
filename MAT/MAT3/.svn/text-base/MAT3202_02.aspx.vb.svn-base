Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT3202_02
    Inherits BaseWebForm

    Dim dao As New MAT3202

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.ucInv_date.Text = CommonFun.getYYYMMDD
            UcMaterialClassB.Orgcode = LoginManager.OrgCode

            ddlDiff_desc.DataSource = New SYS.Logic.CODE().GetData("014", "003")
            ddlDiff_desc.DataBind()
            ddlDiff_desc.Items.Insert(0, New ListItem("請選擇", ""))
        End If

    End Sub

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
            Dim msgInsert As String = dao.Insert(LoginManager.OrgCode, inventoryid, txtMaterial_id.Text, ucInv_date.Text, txtInvBefore_cnt.Text, txtInvAfter_cnt.Text, txtInvModify_cnt.Text, txtDiff_desc.Text, LoginManager.UserId)
            '1030609
            Dim dt As DataTable = New DataTable
            dt = dao.GetDataMaterial(LoginManager.OrgCode, LoginManager.UserId, txtMaterial_id.Text)
            'New FSCPLM.Logic.Material_main().UpdateAvaiable(LoginManager.OrgCode, dt.Rows(0).Item("Available_cnt"), txtMaterial_id.Text, txtInvBefore_cnt.Text, txtInvAfter_cnt.Text)
            Dim materialMain As New Material_main
            materialMain.UpdateAvaiable(LoginManager.OrgCode, txtMaterial_id.Text, txtInvBefore_cnt.Text, txtInvAfter_cnt.Text)
            If Not String.IsNullOrEmpty(msgInsert) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msgInsert)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「新增盤點資料成功」", "MAT3202_01.aspx")
                'Page.Response.Redirect("~/MAT/MAT3/MAT3202_01.aspx")
            End If
        End If

    End Sub

    'Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
    '    CommonFun.ClearContentPlaceHolder(Me.Master)
    'End Sub

    Protected Sub txtMaterialId_TextChanged(sender As Object, e As EventArgs) Handles txtMaterial_id.TextChanged
        If Not CommonFun.IsNum(Me.txtMaterial_id.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號請輸入數字!")
            Return
        End If
        BindMeterialData()
    End Sub

    Protected Sub BindMeterialData()
        Dim dr As DataRow = dao.GetMatData(Me.txtMaterial_id.Text)
        If Not dr Is Nothing Then
            Me.txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
            Me.txtMaterial_name.Text = CommonFun.SetDataRow(dr, "Material_name")
            Me.txtInvBefore_cnt.Text = CommonFun.SetDataRow(dr, "Reserve_cnt")
        End If
    End Sub

    Protected Sub txtInvAfter_cnt_TextChanged(sender As Object, e As EventArgs) Handles txtInvAfter_cnt.TextChanged
        If Not CommonFun.IsNum(txtInvAfter_cnt.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「盤點數量」請輸入數字。")
            Return
        End If
        Me.txtInvModify_cnt.Text = CommonFun.getInt(Me.txtInvAfter_cnt.Text) - CommonFun.getInt(Me.txtInvBefore_cnt.Text)
        If txtInvModify_cnt.Text <> 0 Then
            If String.IsNullOrEmpty(txtDiff_desc.Text) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入「差異解釋說明」。")
            End If

        End If
    End Sub

    'Protected Sub ucDiff_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ucDiff_desc.CodeChanged
    '    txtDiff_desc.Text = Me.ucDiff_desc.SelectedItem.Text
    'End Sub

    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        txtMaterial_id.Text = UcMaterialClassB.MaterialId
        BindMeterialData()
    End Sub

    Protected Sub ddlDiff_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDiff_desc.SelectedIndexChanged
        txtDiff_desc.Text = ddlDiff_desc.SelectedItem.Text
    End Sub
End Class
