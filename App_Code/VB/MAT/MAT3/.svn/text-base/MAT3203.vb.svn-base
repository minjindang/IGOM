Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT3203
        Dim imDAO As InventoryMain

        Public Sub New()
            imDAO = New InventoryMain()
        End Sub

        Public Function Done(orgCode As String, InvEnd_date As String, ModUser_id As String) As String
            Dim msg As String = String.Empty
            Dim InventoryDR As DataRow = imDAO.GetMemoStar(orgCode)
            If Not InventoryDR Is Nothing Then
                imDAO.Update(orgCode, InventoryDR("Inventory_id"), CommonFun.SetDataRow(InventoryDR, "InvStart_date"), CommonFun.SetDataRow(InventoryDR, "Expected_date"), InvEnd_date, _
                             "", CommonFun.SetDataRow(InventoryDR, "InvClosing_ym"), ModUser_id, Now)
                msg = "盤點完成"
            Else
                msg = "無盤點資料"
            End If
            Return msg
        End Function

    End Class
End Namespace