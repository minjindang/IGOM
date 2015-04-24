Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class MAT4103

        Dim mcDAO As MaterialClass_data
        Dim mmDAO As Material_main
        Dim amdDAO As ApplyMaterialDet
        Dim miDAO As MaterialInDet
        Dim mmsDAO As MaterialMStatDet
        Dim itDAO As InventoryDet
        Dim maccDAO As MaterialAccuDet

        Public Sub New()
            mcDAO = New MaterialClass_data()
            mmDAO = New Material_main()
            amdDAO = New ApplyMaterialDet()
            miDAO = New MaterialInDet()
            mmsDAO = New MaterialMStatDet()
            itDAO = New InventoryDet()
            maccDAO = New MaterialAccuDet()
        End Sub

        Public Function GetDataByOrgCode(OrgCode As String) As DataTable
            Return mcDAO.GetDataByOrgCode(OrgCode)
        End Function

        Public Function GetMatData(matID As String) As DataRow
            Dim dt As DataTable = mmDAO.GetMatData(matID, matID)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
        End Function

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                      ByVal OrgCode As String, ByVal Mod_date As DateTime)
            mmDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
            amdDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
            miDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
            mmsDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
            itDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
            maccDAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Function GetMatCount(ByVal Material_id As String) As Integer
            Dim count As Integer = amdDAO.GetMaterialCnt(Material_id) + miDAO.GetMaterialCnt(Material_id) + mmsDAO.GetMaterialCnt(Material_id) + itDAO.GetMaterialCnt(Material_id) + mmDAO.GetMaterialCnt(Material_id)
            Return count
        End Function

    End Class
End Namespace

