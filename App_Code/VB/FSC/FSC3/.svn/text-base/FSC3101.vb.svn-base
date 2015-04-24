Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC3101
        Private DAO As FSC3101DAO

        Public Sub New()
            DAO = New FSC3101DAO()
        End Sub

        Public Function GetDeputyDetByQuery(ByVal Orgcode As String, ByVal ID_card As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByQuery(Orgcode, ID_card)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function deleteData(ByVal id As Integer) As Boolean
            Return DAO.deleteData(id) > 0
        End Function
    End Class
End Namespace
