Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2101
        Private DAO As FSC2101DAO

        Dim dtData As DataTable

        Public Sub New()
            DAO = New FSC2101DAO()
        End Sub

        ''' <summary>
        ''' 回傳 職務類別/狀況
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCODE(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            dtData = DAO.GetCODE(CODE_SYS, CODE_TYPE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal departId As String, ByVal name As String, ByVal employeeType As String, ByVal idCard As String, ByVal Quit_job_flag As String) As DataTable
            dtData = DAO.GetData(orgcode, departId, name, employeeType, idCard, Quit_job_flag)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function


    End Class
End Namespace