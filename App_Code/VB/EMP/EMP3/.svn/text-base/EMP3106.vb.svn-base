Imports Microsoft.VisualBasic
Imports System.Data

Namespace EMP.Logic
    Public Class EMP3106
        Private DAO As EMP3106DAO

        Public Sub New()
            DAO = New EMP3106DAO()
        End Sub

        Public Function DeleteDepartEmp(ByVal id_card As String, ByVal Service_type As String) As Boolean
            Return DAO.DeleteDepartEmp(id_card, Service_type) >= 1
        End Function

        Public Function DeleteDeputy(ByVal id_card As String) As Boolean
            Return DAO.DeleteDeputy(id_card) >= 1
        End Function
    End Class
End Namespace
