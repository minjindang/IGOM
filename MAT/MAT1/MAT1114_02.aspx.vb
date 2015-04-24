Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT_MAT1_MAT1114_02
    Inherits BaseWebForm

    Dim dao As New MAT1114

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
            If Not String.IsNullOrEmpty(msgInsert) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msgInsert)
            Else
                Page.Response.Redirect("~/MAT/MAT1/MAT1114_01.aspx")
            End If
        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub txtMaterialId_TextChanged(sender As Object, e As EventArgs) Handles txtMaterial_id.TextChanged
        Dim dr As DataRow = dao.GetMatData(Me.txtMaterial_id.Text)
        If Not dr Is Nothing Then
            Me.txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
            Me.txtMaterial_name.Text = CommonFun.SetDataRow(dr, "Material_name")
            Me.txtInvBefore_cnt.Text = CommonFun.SetDataRow(dr, "Reserve_cnt")
        End If
    End Sub

    Protected Sub txtInvAfter_cnt_TextChanged(sender As Object, e As EventArgs) Handles txtInvAfter_cnt.TextChanged
        Me.txtInvModify_cnt.Text = Me.txtInvAfter_cnt.Text - Me.txtInvBefore_cnt.Text
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.ucInv_date.Text = CommonFun.getYYYMMDD
            ucDiff_desc.DDL.AutoPostBack = True
        End If

    End Sub

    Protected Sub ucDiff_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ucDiff_desc.CodeChanged

        txtDiff_desc.Text = Me.ucDiff_desc.SelectedItem.Text 

    End Sub

End Class
