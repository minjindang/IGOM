Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4101_03
    Inherits BaseWebForm

    Dim mDAO As New Material_main
    Dim mcDAO As New MaterialClass_data


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Me.ddl_MaterialClass.DataSource = mcDAO.GetData("", "")
            Me.ddl_MaterialClass.DataValueField = "MaterialClass_id"
            Me.ddl_MaterialClass.DataTextField = "MaterialClass_name"
            Me.ddl_MaterialClass.DataBind()
            Me.txtMaterialId.Text = Me.Request.QueryString("Material_id")
            BindData()
        End If
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click

        Try
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
            If String.IsNullOrEmpty(txtUnit.Text.Trim) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入單位!")
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
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "單位領用限量(月)請輸入數字!")
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

            If Me.fuMaterialIcon.HasFile Then
                mDAO.Update(txtMaterialId.Text, txtMaterialName.Text, ddl_MaterialClass.SelectedValue, txtUnit.Text, _
                       txtSafeCount.Text, txtReserveCnt.Text, txtAvailableCnt.Text, txtLoction.Text, txtPersonLimitMMCnt.Text, _
                       txtPersonLimitCnt.Text, txtUnitLimitMMCnt.Text, txtUnitLimitCnt.Text, fuMaterialIcon.FileName, txtMemo.Text, _
                       LoginManager.UserId, LoginManager.OrgCode, Now)
                Me.fuMaterialIcon.PostedFile.SaveAs(IO.Path.Combine(MapPath("~/fileupload/Image"), fuMaterialIcon.FileName))
            Else
                mDAO.Update(txtMaterialId.Text, txtMaterialName.Text, ddl_MaterialClass.SelectedValue, txtUnit.Text, _
                       txtSafeCount.Text, txtReserveCnt.Text, txtAvailableCnt.Text, txtLoction.Text, txtPersonLimitMMCnt.Text, _
                       txtPersonLimitCnt.Text, txtUnitLimitMMCnt.Text, txtUnitLimitCnt.Text, "", txtMemo.Text, _
                       LoginManager.UserId, LoginManager.OrgCode, Now)
            End If
            Dim tb1 As String = Request.QueryString("Material_id")
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料更新成功!", "MAT4101_01.aspx?tb1=" + tb1 + "")
            'Page.Response.Redirect("~/MAT/MAT4/MAT4101_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Private Sub BindData()
        Dim dr As DataRow = mDAO.GetOne(txtMaterialId.Text)
        txtMaterialId.Text = CommonFun.SetDataRow(dr, "Material_id")
        txtMaterialName.Text = CommonFun.SetDataRow(dr, "Material_name")
        ddl_MaterialClass.SelectedValue = CommonFun.SetDataRow(dr, "MaterialClass_id")
        txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
        txtSafeCount.Text = CommonFun.SetDataRow(dr, "Safe_cnt")
        txtReserveCnt.Text = CommonFun.SetDataRow(dr, "Reserve_cnt")
        txtAvailableCnt.Text = CommonFun.SetDataRow(dr, "Available_cnt")
        txtLoction.Text = CommonFun.SetDataRow(dr, "Location")
        txtPersonLimitMMCnt.Text = CommonFun.SetDataRow(dr, "PersonLimitMM_cnt")
        txtPersonLimitCnt.Text = CommonFun.SetDataRow(dr, "PersonLimit_cnt")
        txtUnitLimitMMCnt.Text = CommonFun.SetDataRow(dr, "UnitLimitMM_cnt")
        txtUnitLimitCnt.Text = CommonFun.SetDataRow(dr, "UnitLimit_cnt")
        If Not String.IsNullOrEmpty(dr("MaterialIcon").ToString) Then
            ibMaterialIcon.ImageUrl = "~/fileupload/Image/" + dr("MaterialIcon") 'IO.Path.Combine(MapPath("~/fileupload/Image"), dr("MaterialIcon")) 
        Else
            ibMaterialIcon.Visible = False
        End If
        txtMemo.Text = CommonFun.SetDataRow(dr, "Memo")
    End Sub

    Protected Sub RestoreBtn_Click(sender As Object, e As EventArgs) Handles RestoreBtn.Click
        BindData()
    End Sub

    Protected Sub ibMaterialIcon_Click(sender As Object, e As ImageClickEventArgs) Handles ibMaterialIcon.Click
        Response.Redirect(ibMaterialIcon.ImageUrl)
    End Sub
    Protected Sub back()
        Dim tb1 As String = Request.QueryString("Material_id")
        Response.Redirect("MAT4101_01.aspx?tb1=" + tb1 + "")
    End Sub
End Class
