Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2120
        Private DAO As FSC2120DAO

        Public Sub New()
            DAO = New FSC2120DAO()
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

      ''' <summary>
        ''' 回傳慶生人員名單
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <param name="iMonth">月份</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="Employee_type">人員類別代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal iMonth As Integer, ByVal Depart_id As String, ByVal Employee_type As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetReportData(CODE_SYS, CODE_TYPE, iMonth, Depart_id, Employee_type)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function
    End Class
End Namespace
