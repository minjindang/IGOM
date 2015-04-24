Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Web

Namespace SAL.Logic
    Public Class SAL1113

        Dim DAO As SAL1113DAO

        Public Sub New()
            DAO = New SAL1113DAO
        End Sub

        Function doQuerySAL1113(ByVal departId As String, ByVal idNo As String, ByVal busDate As String, ByVal bueDate As String, ByVal officeOuttype As String, Optional ByVal isInit As Boolean = False) As DataTable
            Return DAO.doQuerySAL1113(departId, idNo, busDate, bueDate, officeOuttype, isInit)
        End Function

        Public Function GetSAL1113_02Data(ByVal Id_card As String, ByVal Officialout_type As String, ByVal Officialout_dateb As String, ByVal Officialout_timeb As String, ByVal ppguid As String) As DataTable
            Return DAO.GetSAL1113_02Data(Id_card, Officialout_type, Officialout_dateb, Officialout_timeb, ppguid)
        End Function

        Public Function GetSAL1113_02DataByPPGUID(ByVal Id_card As String, ByVal Officialout_type As String, ByVal ppguid As String) As DataTable
            Return DAO.GetSAL1113_02DataByPPGUID(Id_card, Officialout_type, ppguid)
        End Function

        Public Function GetFeeLimitByIdCard(ByVal IdCard As String) As DataTable
            Return DAO.GetFeeLimitByIdCard(IdCard)
        End Function

        Public Function GetLastBudget(ByVal id_card As String, ByVal Officialout_type As String, ByVal ppguid As String) As String
            Return DAO.GetLastBudget(id_card, Officialout_type, ppguid)
        End Function
    End Class
End Namespace
