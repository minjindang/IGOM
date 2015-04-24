Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class InventoryDet
        Public DAO As InventoryDetDAO

        Public Sub New()
            DAO = New InventoryDetDAO()
        End Sub
        Public Function Delete(ByVal orgcode As String, ByVal Inventory_id As String, ByVal Material_id As String) As Boolean
            Return DAO.Delete(orgcode, Inventory_id, Material_id)
        End Function

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return DAO.GetMaterialCnt(Material_id)
        End Function

        Public Function GetData(orgCode As String, Optional Material_id As String = "", Optional Inv_date As String = "", Optional inventory As Integer = 0) As DataTable
            Return DAO.GetData(Material_id, Inv_date, orgCode, inventory)
        End Function

        Public Sub Insert(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                         InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String, Mod_date As DateTime)
            DAO.Insert(OrgCode, Inventory_id, Material_id, Inv_date, InvBefore_cnt, InvAfter_cnt, InvModify_cnt, Diff_desc, ModUser_id, Mod_date)
        End Sub

        Public Sub Update(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                        InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String, Mod_date As DateTime)
            DAO.Update(OrgCode, Inventory_id, Material_id, Inv_date, InvBefore_cnt, InvAfter_cnt, InvModify_cnt, Diff_desc, ModUser_id, Mod_date)
        End Sub

        Public Function GetOut_cnt(orgCode As String, yearMonth As String) As DataTable
            Return DAO.GetOut_cnt(orgCode, yearMonth)
        End Function

        Public Function GetOut_cnt(orgCode As String, yearMonth As String, materialID As String) As Integer
            Dim dt As DataTable = GetOut_cnt(orgCode, yearMonth)
            Dim dtRows() As DataRow = dt.Select(String.Format(" Material_id = '{0}' ", materialID))
            If Not dtRows Is Nothing AndAlso dtRows.Length > 0 Then
                dt = dtRows.CopyToDataTable()
                Return dt.Rows(0)("Out_cnt")
            Else
                Return 0
            End If
        End Function

        Public Function MAT2202select(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal UcDate1 As String, _
                                     ByVal UcDate2 As String) As DataTable
            Return DAO.MAT2202select(tbMaterial_id1, tbMaterial_id2, UcDate1, UcDate2)
        End Function

        Public Function FindMinDate() As DataTable
            Return DAO.FindMinDate()
        End Function

    End Class
End Namespace

