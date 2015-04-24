Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2121
        Private DAO As FSC2121DAO

        Public Sub New()
            DAO = New FSC2121DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sche_month As String) As DataTable
            Dim dt As DataTable = DAO.getData(Orgcode, Depart_id, Sche_month)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class
End Namespace
