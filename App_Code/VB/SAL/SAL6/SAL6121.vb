Imports Microsoft.VisualBasic
Imports System.Data

Namespace SALARY.Logic
    Public Class SAL6121
        Public DAO As SAL6121DAO
        Public Sub New()
            DAO = New SAL6121DAO()
        End Sub
        Public Function SAL6121SelectData(ByVal Apply_yy As String) As DataTable
            Dim dt As DataTable
            dt = DAO.SAL6121SelectData(Apply_yy)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        Public Function SAL6121PrintData(ByVal Apply_yy As String, ByVal SpecialInquiry As String, ByVal Type As String, ByVal PAYOD_CODE As String) As DataTable
            Dim dt As DataTable
            dt = DAO.SAL6121PrintData(Apply_yy, SpecialInquiry, Type, PAYOD_CODE)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace