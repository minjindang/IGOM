Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MaterialInDet
        Public DAO As MaterialInDetDAO

        Public Sub New()
            DAO = New MaterialInDetDAO()
        End Sub

        Public Function GetByMaterialID(ByVal MaterialID As Integer) As DataTable
            Return DAO.GetByMaterialID(MaterialID)
        End Function

        Public Function GetAll(ByVal materialId As String, ByVal companyName As String) As DataTable
            Dim dt As DataTable = DAO.GetAll(materialId, companyName)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt
        End Function

        Public Function GetAll(ByVal materialId As String, ByVal companyName As String, ByVal In_dateS As String, ByVal In_dateE As String) As DataTable
            Dim dt As DataTable = DAO.GetAll(materialId, companyName, In_dateS, In_dateE)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt
        End Function

        Public Function GetOne(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String) As DataRow
            Dim dt As DataTable = DAO.GetOne(OrgCode, Material_id, In_date)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt.Rows(0)
        End Function

        Public Sub Update(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String, ByVal In_cnt As Integer, ByVal Unit As String _
                      , ByVal Buy_date As String, ByVal Buy_cnt As Integer, ByVal UnitPrice_amt As Double, ByVal Company_name As String, _
                      ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime)
            DAO.Update(OrgCode, Material_id, In_date, In_cnt, Unit, Buy_date, Buy_cnt, UnitPrice_amt, Buy_cnt * UnitPrice_amt, Company_name, Memo, ModUser_id, Mod_date)
        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Sub Insert(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String, ByVal In_cnt As Integer, ByVal Unit As String _
                      , ByVal Buy_date As String, ByVal Buy_cnt As Integer, ByVal UnitPrice_amt As Double, ByVal Company_name As String, _
                      ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime)
            DAO.Insert(OrgCode, Material_id, In_date, In_cnt, Unit, Buy_date, Buy_cnt, UnitPrice_amt, Buy_cnt * UnitPrice_amt, Company_name, Memo, ModUser_id, Mod_date)
        End Sub

        Public Sub Delete(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String)
            DAO.Delete(OrgCode, Material_id, In_date)
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return DAO.GetMaterialCnt(Material_id)
        End Function

        Public Function GetIn_cnt(orgCode As String, yearMonth As String) As DataTable
            Return DAO.GetIn_cnt(orgCode, yearMonth)
        End Function

        Public Function GetIn_cnt(orgCode As String, yearMonth As String, materialID As String) As Integer
            Dim dt As DataTable = GetIn_cnt(orgCode, yearMonth)
            Dim dtRows() As DataRow = dt.Select(String.Format(" Material_id = '{0}' ", materialID))
            If Not dtRows Is Nothing AndAlso dtRows.Length > 0 Then
                dt = dtRows.CopyToDataTable()
                Return dt.Rows(0)("In_cnt")
            Else
                Return 0
            End If
        End Function

    End Class
End Namespace