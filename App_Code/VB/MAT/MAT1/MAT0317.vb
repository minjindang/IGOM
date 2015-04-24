Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT0317
        Public DAO As MAT0317DAO

        Public Sub New()
            DAO = New MAT0317DAO()
        End Sub

        Public Function GetUnitID() As DataTable
            Dim dt As DataTable

            dt = DAO.GetUnitID()

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function getApplyMAT(ByVal type As String, ByVal MatNo1 As String, ByVal MatNo2 As String, ByVal OutDate1 As String, _
                                    ByVal OutDate2 As String, ByVal Ucode As String, ByVal Uid As String) As DataTable
            Dim dt As DataTable

            dt = DAO.getApplyMAT(type, MatNo1, MatNo2, OutDate1, OutDate2, Ucode, Uid)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function getApplyPrintMAT(ByVal type As String, ByVal Ucode As String, ByVal Uid As String, _
                                         ByVal MatNo1 As String, ByVal MatNo2 As String, ByVal OutDate1 As String, _
                                    ByVal OutDate2 As String) As DataTable
            Dim dt As DataTable

            dt = DAO.getApplyPrintMAT(type, Ucode, Uid, MatNo1, MatNo2, OutDate1, OutDate2)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class
End Namespace
