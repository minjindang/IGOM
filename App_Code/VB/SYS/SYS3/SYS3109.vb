Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS3109
        Private DAO As SYS3109DAO

        Public Sub New()
            DAO = New SYS3109DAO()
        End Sub


        Public Function GetData(ByVal FromName As String, ByVal FromMail As String, ByVal ToName As String, ByVal ToMail As String, ByVal dateS As String, ByVal dateE As String, ByVal ErrorM As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetData(FromName, FromMail, ToName, ToMail, dateS, dateE, ErrorM)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

    End Class
End Namespace
