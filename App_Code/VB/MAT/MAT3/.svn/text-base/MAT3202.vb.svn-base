Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class MAT3202
        Dim itDAO As InventoryDet
        Dim mmDAO As Material_main
        Dim imDAO As InventoryMain

        Public Sub New()
            mmDAO = New Material_main()
            itDAO = New InventoryDet()
            imDAO = New InventoryMain()
        End Sub

        Public Function GetDataOne(Material_id As String, inventroyId As Integer, orgCode As String) As DataRow
            Dim dt As DataTable = itDAO.GetData(orgCode, Material_id, "", inventroyId)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
        End Function

        Public Function GetData(Material_id As String, Inv_date As String, orgCode As String) As DataTable
            Return itDAO.GetData(orgCode, Material_id, Inv_date)
        End Function

        Public Function GetMatData(matID As String) As DataRow
            Dim dt As DataTable = mmDAO.GetMatData(matID, matID)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
        End Function
        Public Function GetDataMaterial(ByVal Orgcode As String, ByVal UserId As String, ByVal Material_id As String) As DataTable
            Dim dt As DataTable = mmDAO.GetDataMaterial(Orgcode, UserId, Material_id)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If
        End Function
        Public Function GetInventoryIdd(orgCode As String) As Integer
            Dim dr As DataRow = imDAO.GetMemoStar(orgCode)
            If dr Is Nothing Then
                Return 0
            Else
                Return dr("Inventory_id")
            End If
        End Function


        Public Function Insert(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                         InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String) As String
            Dim msg As String = String.Empty
            Try
                Dim dt As DataTable = itDAO.GetData(OrgCode, Material_id, "", Inventory_id)
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    itDAO.Insert(OrgCode, Inventory_id, Material_id, Inv_date, InvBefore_cnt, InvAfter_cnt, InvModify_cnt, Diff_desc, ModUser_id, Now)
                Else
                    msg = "盤點明細已存在-請聯絡管理員"
                End If
            Catch ex As Exception
                msg = ex.Message
            End Try

            Return msg
        End Function

        Public Function Update(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                         InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String) As String
            Dim msg As String = String.Empty
            Try
                Dim dt As DataTable = itDAO.GetData(OrgCode, Material_id, "", Inventory_id)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    itDAO.Update(OrgCode, Inventory_id, Material_id, Inv_date, InvBefore_cnt, InvAfter_cnt, InvModify_cnt, Diff_desc, ModUser_id, Now)
                Else
                    msg = "盤點明細不存在-請聯絡管理員"
                End If
            Catch ex As Exception
                msg = ex.Message
            End Try
            Return msg
        End Function
    End Class

End Namespace