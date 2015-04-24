Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS2106
        Private DAO As SYS2106DAO

        Public Sub New()
            DAO = New SYS2106DAO()
        End Sub

        Public Function getQueryData(ByVal message As String, _
                                     ByVal year As String, _
                                     ByVal month As String, _
                                     ByVal day As String) As DataTable
            Return DAO.getQueryData(message, year, month, day)
        End Function

    End Class
End Namespace
