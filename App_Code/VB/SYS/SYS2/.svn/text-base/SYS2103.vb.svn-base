Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS2103
        Private DAO As SYS2103DAO

        Public Sub New()
            DAO = New SYS2103DAO()
        End Sub
        Public Function getQueryData(ByVal idcard As String, _
                                    ByVal Start_date As String) As DataTable
            Return DAO.getQueryData(idcard, Start_date)
        End Function

       
    End Class
End Namespace
