Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT_MAT3_MAT3101_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''initfunction()
        If Not (IsPostBack) Then
            Dim details_id As Integer = Request.QueryString("Details_id")
            hfDetailID.Value = details_id
            Bind(details_id)
        End If
    End Sub

    Private Sub Bind(ByVal details_id As Integer)
        Dim pm As PurchaseMain = New PurchaseMain()
        ddlFlowId.DataSource = pm.GetImporrtOtMtrNOTYData(LoginManager.OrgCode)
        ddlFlowId.DataTextField = "Flow_id"
        ddlFlowId.DataValueField = "Flow_id"
        ddlFlowId.DataBind()
        ddlFlowId.Items.Insert(0, New ListItem("請選擇", String.Empty))
        ddlFlowId.SelectedIndex = 0
        Dim detail As New ApplyOtherMtrDet
        Dim main As New ApplyOtherMtrMain
        Dim detailDR As DataRow = detail.GetOne(details_id)
        Dim mainDR As DataRow = main.GetOne(detailDR("Form_id"))
        '主檔
        Me.hfFormIDc.Value = CommonFun.SetDataRow(mainDR, "Form_id")
        Me.ucApply_date.Text = CommonFun.SetDataRow(mainDR, "Apply_date")
        Me.ddlDept.SelectedValue = CommonFun.SetDataRow(mainDR, "Unit_Code")
        Me.txtUser_Id.Text = CommonFun.SetDataRow(mainDR, "User_id")
        Me.ddlFlowId.SelectedValue = CommonFun.SetDataRow(mainDR, "Flow_id")
        Me.ddlFlowId.Enabled = False
        '明細
        Me.txtMaterialName.Text = CommonFun.SetDataRow(detailDR, "Material_name")
        Me.txtUnit.Text = CommonFun.SetDataRow(detailDR, "Unit")
        Me.txtOutCnt.Text = Convert.ToInt32(CommonFun.SetDataRow(detailDR, "Out_cnt"))
        Me.txtTotalPriceAmt.Text = Convert.ToInt32(CommonFun.SetDataRow(detailDR, "TotalPrice_amt"))
        Me.txtCompanyName.Text = CommonFun.SetDataRow(detailDR, "Company_name")
        Me.txtMemo.Text = CommonFun.SetDataRow(detailDR, "Memo")

    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As System.EventArgs) Handles DonBtn.Click
        Try
            If Not CommonFun.IsNum(txtOutCnt.Text) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "領用數量需為數字!")
                Return
            End If
            If Not CommonFun.IsNum(txtTotalPriceAmt.Text) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "總價需為數字!")
                Return
            End If
            Dim detail As New ApplyOtherMtrDet
            Dim main As New ApplyOtherMtrMain
            detail.Update(hfDetailID.Value, hfFormIDc.Value, txtMaterialName.Text, txtUnit.Text, txtOutCnt.Text, txtTotalPriceAmt.Text, txtCompanyName.Text, txtMemo.Text, LoginManager.UserId, Now, LoginManager.OrgCode)
            main.Update(hfFormIDc.Value, ddlFlowId.SelectedValue, ucApply_date.Text, ddlDept.SelectedValue, txtUser_Id.Text, 0, LoginManager.UserId, Now, LoginManager.OrgCode)
            Page.Response.Redirect("~/MAT/MAT3/MAT3101_01.aspx?types=update")
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Protected Sub RestoreBtn_Click(sender As Object, e As System.EventArgs) Handles RestoreBtn.Click
        Dim details_id As Integer = Request.QueryString("Details_id")
        Bind(details_id)
    End Sub

    'RestoreBtn

End Class
