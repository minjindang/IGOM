Imports System.Data
Imports FSCPLM.Logic
Imports System.Transactions

Partial Class MAT3_MAT3102_02
    Inherits BaseWebForm

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            UcMaterialId.Orgcode = LoginManager.OrgCode
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

            If String.IsNullOrEmpty(Me.txtMaterialName.Text) Then
                msg += "此物料不存在\n"
            End If
            If (Me.txtMemo.Text.Length > 255) Then
                msg += "備註不能輸入超過255個字!\n"
            End If

            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            Else
                Using trans As New TransactionScope
                    Dim materialDetDAO As New MaterialInDet
                    Dim materialMain As New Material_main
                    materialDetDAO.Insert(LoginManager.OrgCode, Me.UcMaterialId.MaterialId, ucInDate.Text, txtInCnt.Text, txtUnit.Text, ucBuyDate.Text, txtBuyCnt.Text, txtUnitPriceAmt.Text, txtCompanyName.Text, txtMemo.Text, LoginManager.UserId, Now)
                    materialMain.updateReserveCnt(LoginManager.OrgCode, Me.UcMaterialId.MaterialId, 0, txtInCnt.Text.Trim())
                    materialMain.update3102AvailableCnt(txtInCnt.Text, Me.UcMaterialId.MaterialId, LoginManager.OrgCode)

                    trans.Complete()
                End Using
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "物品入庫新增成功", "MAT3102_01.aspx")
                'Page.Response.Redirect("~/MAT/MAT3/MAT3102_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub UcMaterialId_Checked(sender As Object, e As EventArgs)
        txtMaterialId.Text = Me.UcMaterialId.MaterialId
        Dim materialDAO As New Material_main
        Dim materialDT As DataTable = materialDAO.GetMatData(Me.UcMaterialId.MaterialId, Me.UcMaterialId.MaterialId)
        If Not materialDT Is Nothing AndAlso materialDT.Rows.Count > 0 Then
            Dim materialDR As DataRow = materialDT.Rows(0)
            Me.txtMaterialName.Text = CommonFun.SetDataRow(materialDR, "Material_name")
            Me.txtUnit.Text = CommonFun.SetDataRow(materialDR, "Unit")
            Me.txtSafeCount.Text = CommonFun.SetDataRow(materialDR, "Safe_cnt")
            Me.txtReserveCnt.Text = CommonFun.SetDataRow(materialDR, "Reserve_cnt")
        End If
    End Sub
End Class
