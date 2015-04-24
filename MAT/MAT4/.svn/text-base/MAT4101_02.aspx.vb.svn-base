Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4101_02
    Inherits BaseWebForm

    Dim mDAO As New Material_main
    Dim mcDAO As New MaterialClass_data

    Protected Sub txtMaterialId_TextChanged(sender As Object, e As EventArgs) Handles txtMaterialId.TextChanged
        If mDAO.GetMatData(txtMaterialId.Text, txtMaterialId.Text).Rows.Count <> 0 Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "物料編號已存在")
            Me.DonBtn.Enabled = False
        Else
            Dim szMaterialClass As String = ddl_MaterialClass.SelectedValue
            Dim szMaterialId As String = Left(txtMaterialId.Text, 5)
            If szMaterialClass <> szMaterialId Then
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "此物料編號不屬顧該分類號。")
                Me.DonBtn.Enabled = False
            Else
                Me.DonBtn.Enabled = True
            End If
        End If

    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        If String.IsNullOrEmpty(ddl_MaterialClass.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇分類號!")
            Return
        End If
        If String.IsNullOrEmpty(txtMaterialId.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入物料編號!")
            Return
        End If
        If String.IsNullOrEmpty(txtMaterialName.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入物料名稱!")
            Return
        End If
        If String.IsNullOrEmpty(txtUnitLimitCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入單位領用限量(單位)")
            Return
        End If
        If String.IsNullOrEmpty(txtUnitLimitMMCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入單位領用限量(月)")
            Return
        End If
        If String.IsNullOrEmpty(txtPersonLimitCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入員工領用限量(單位)!!")
            Return
        End If
        If String.IsNullOrEmpty(txtPersonLimitMMCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入員工領用限量(月)")
            Return
        End If
        If String.IsNullOrEmpty(txtSafeCount.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入安全庫存數量")
            Return
        End If
        If String.IsNullOrEmpty(txtReserveCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入目前庫存數量!")
            Return
        End If
        If String.IsNullOrEmpty(txtAvailableCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "目前可用餘額!")
            Return
        End If
        If Not CommonFun.IsNum(txtMaterialId.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtUnitLimitCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位領用限量(單位)請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtUnitLimitMMCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位領用限量(月)請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtPersonLimitCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "員工領用限量(單位)請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtPersonLimitMMCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "員工領用限量(月)請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtSafeCount.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "安全庫存數量請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtReserveCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "目前庫存數量請輸入數字!")
            Return
        End If
        If Not CommonFun.IsNum(txtAvailableCnt.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "目前可用餘額請輸入數字!")
            Return
        End If

        Dim result As String = mDAO.Insert(Me.txtMaterialId.Text, txtMaterialName.Text, ddl_MaterialClass.SelectedValue, txtUnit.Text, _
                                           txtSafeCount.Text, txtReserveCnt.Text, txtAvailableCnt.Text, txtLoction.Text, txtPersonLimitCnt.Text, _
                                           txtPersonLimitCnt.Text, txtUnitLimitMMCnt.Text, txtUnitLimitCnt.Text, fuMaterialIcon.FileName, txtMemo.Text, _
                                           LoginManager.UserId, LoginManager.OrgCode, Now)
        If Not String.IsNullOrEmpty(result) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
        Else
            If Me.fuMaterialIcon.HasFile Then
                Me.fuMaterialIcon.PostedFile.SaveAs(IO.Path.Combine(MapPath("~/fileupload/Image"), fuMaterialIcon.FileName))
            End If
            Dim tb1 As String = Me.txtMaterialId.Text
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增物料成功!", "MAT4101_01.aspx?tb1=" + tb1 + "")
        End If
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.ddl_MaterialClass.DataSource = mcDAO.GetData("", "")
            Me.ddl_MaterialClass.DataValueField = "MaterialClass_id"
            Me.ddl_MaterialClass.DataTextField = "MaterialClass_name"
            Me.ddl_MaterialClass.DataBind()
        End If
        txtReserveCnt.Text = "0"
        txtAvailableCnt.Text = "0"
    End Sub
End Class
