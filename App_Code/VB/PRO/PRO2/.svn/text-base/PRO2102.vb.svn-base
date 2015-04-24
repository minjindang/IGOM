Imports Microsoft.VisualBasic
Imports System.Data

Namespace PRO.Logic
    Public Class PRO2102
        Private DAO As PRO2102DAO

        Public Sub New()
            DAO = New PRO2102DAO()
        End Sub

        ''' <summary>
        ''' 回傳人員類別
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getEmployeeTypeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.getEmployeeTypeData(CODE_SYS, CODE_TYPE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        Public Function GetReportData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal Scrap_unit As String, ByVal Property_type As String, ByVal last_dateS As String, ByVal last_dateE As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetReportData(CODE_SYS, CODE_TYPE, Scrap_unit, Property_type, last_dateS, last_dateE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function
    End Class
End Namespace
