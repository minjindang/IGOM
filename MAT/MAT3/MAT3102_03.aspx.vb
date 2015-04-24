Imports System.Data
Imports FSCPLM.Logic
Imports System.Transactions

Partial Class MAT3_MAT3102_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Me.hfInDate.Value = Me.Request.QueryString("In_date")
            Me.hfOrgCode.Value = Me.Request.QueryString("OrgCode")
            Me.hfMaterialId.Value = Me.Request.QueryString("Material_id")
            BindData()
        End If
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        Try
            Dim msg As String = String.Empty
            If Not IsNumeric(txtBuyCnt.Text) Then
                msg += "申購數量必須為數字\n"
            End If

            If Not IsNumeric(txtReserveCnt.Text) Then
                msg += "目前庫存數量必須為數字\n"
            End If

            If Not IsNumeric(txtInCnt.Text) Then
                msg += "入庫數量必須為數字\n"
            End If
            If (Me.txtMemo.Text.Length > 255) Then
                msg += "備註不能輸入超過255個字!\n"
            End If

            If String.IsNullOrEmpty(Me.txtMaterialName.Text) Then
                msg += "此物料不存在\n"
            End If

            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            Else
                Using trans As New TransactionScope
                    Dim materialDetDAO As New MaterialInDet
                    Dim materialMain As New Material_main
                    materialDetDAO.Update(LoginManager.OrgCode, Me.txtMaterialId.Text, ucInDate.Text, txtInCnt.Text, txtUnit.Text, ucBuyDate.Text, txtBuyCnt.Text, txtUnitPriceAmt.Text, txtCompanyName.Text, txtMemo.Text, LoginManager.UserId, Now)
                    materialMain.updateReserveCnt(LoginManager.OrgCode, Me.hfMaterialId.Value, lbOriInCnt.Text.Trim(), txtInCnt.Text.Trim())
                    materialMain.update310203AvailableCnt(lbOriInCnt.Text.Trim(), txtInCnt.Text.Trim(), Me.hfMaterialId.Value, LoginManager.OrgCode)

                    trans.Complete()
                End Using
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "維護入庫資料成功", "MAT3102_01.aspx")
                'Page.Response.Redirect("~/MAT/MAT3/MAT3102_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Private Sub BindData()
        Dim materialDetDAO As New MaterialInDet
        Dim dr As DataRow = materialDetDAO.GetOne(hfOrgCode.Value, hfMaterialId.Value, hfInDate.Value)
        txtMaterialId.Text = CommonFun.SetDataRow(dr, "Material_id")
        txtMaterialName.Text = CommonFun.SetDataRow(dr, "Material_name")
        txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
        txtSafeCount.Text = CommonFun.SetDataRow(dr, "Safe_cnt")
        txtBuyCnt.Text = CommonFun.SetDataRow(dr, "Buy_cnt")
        Me.ucBuyDate.Text = CommonFun.SetDataRow(dr, "Buy_date")
        txtReserveCnt.Text = CommonFun.SetDataRow(dr, "Reserve_cnt")
        txtInCnt.Text = CommonFun.SetDataRow(dr, "In_cnt")
        lbOriInCnt.Text = CommonFun.SetDataRow(dr, "In_cnt")
        Me.ucInDate.Text = CommonFun.SetDataRow(dr, "In_date")
        txtUnitPriceAmt.Text = CType(CommonFun.SetDataRow(dr, "UnitPrice_amt"), Double)
        txtCompanyName.Text = CommonFun.SetDataRow(dr, "Company_name")
        txtMemo.Text = CommonFun.SetDataRow(dr, "Memo")
    End Sub

    Protected Sub RestoreBtn_Click(sender As Object, e As EventArgs) Handles RestoreBtn.Click
        BindData()
    End Sub

End Class
