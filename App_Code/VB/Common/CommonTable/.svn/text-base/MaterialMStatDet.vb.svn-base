Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class MaterialMStatDet
        Public DAO As MaterialMStatDetDAO

        Public Sub New()
            DAO = New MaterialMStatDetDAO()
        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return DAO.GetMaterialCnt(Material_id)
        End Function

    
        Public Function InsertOrUpdate(OrgCode As String, Year_id As String, ByVal Material_id As String, Unit_code As String, month As String, value As String, isOverwirte As Boolean, ModUser_id As String) As String
            Dim dt As DataTable = DAO.GetOne(OrgCode, Year_id, Material_id, Unit_code)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                If isOverwirte Then 'AndAlso Not String.IsNullOrEmpty(CommonFun.SetDataRow(dt.Rows(0), month & "MOut_amt")) Then 
                    DAO.Update(OrgCode, Year_id, Material_id, Unit_code, month, value, ModUser_id)
                    Return ""
                Else
                    Return String.Format("{0}年{1}月結算資料已存在，是否重新計算", Year_id, month)
                End If
            Else
                DAO.Insert(OrgCode, Year_id, Material_id, Unit_code)
                DAO.Update(OrgCode, Year_id, Material_id, Unit_code, month, value, ModUser_id)
                Return ""
            End If
        End Function

        Public Function MAT2108_Print(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal ddlyear As String) As DataTable
            Return DAO.MAT2108_Print(tbMaterial_id1, tbMaterial_id2, ddlyear)
        End Function

        Public Function get2108SumData(ByVal Material_id As String, ByVal Year_id As String) As DataTable
            Return DAO.get2108SumData(Material_id, Year_id)
        End Function
    End Class

End Namespace
