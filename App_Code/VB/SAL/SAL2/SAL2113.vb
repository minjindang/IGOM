Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SAL2113
        Private DAO As SAL2113DAO

        Public Sub New()
            DAO = New SAL2113DAO()
        End Sub

        Public Function GetExtData(v_ym As String, strBudget As String) As DataTable
            Return DAO.GetExtData(v_ym, strBudget)
        End Function

        Public Function GetNhiInfoData(v_UserOrgId As String, v_nhiym As String, strBudget As String, type As String) As DataTable
            Return DAO.GetNhiInfoData(v_UserOrgId, v_nhiym, strBudget, type)
        End Function

        Public Function GetUnit(v_UserOrgId As String) As DataTable
            Return DAO.GetUnit(v_UserOrgId)
        End Function
    End Class
End Namespace